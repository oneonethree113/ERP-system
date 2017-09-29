


Public Class SAM00001
    ' Inherits System.Windows.Forms.Form
    ' the following variables are copied from old version
    Dim objBSGate As Object
    Dim cancel_Click_Count As Long
    Dim Current_TimeStamp As Long
    Dim EditModeHdr As String
    Dim Recordstatus As Boolean
    Dim Add_flag As Boolean
    Dim Insert_flag As Boolean
    Dim save_ok As Boolean
    Dim IsUpdated As Boolean
    Dim save_fail As Boolean
    Dim Cancel_Click As Boolean
    Dim VendorType As String
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim warn As Boolean
    Dim bookmark As Object
    Dim bolDisplay As Boolean
    Public rs_SAREQHDR As DataSet
    Public rs_VNCNTINF As DataSet
    Public rs_CUBASINF_SR As DataSet
    Public rs_SAORDSUM As DataSet
    Public rs_SAORDDTL As DataSet
    Public rs_SAREQDTL As DataSet
    Public rs_SAREQASS As DataSet
    Public rs_SYSALINF As DataSet
    Public rs_SYUSRPRF_2 As DataSet
    Dim PreviousTab As Integer

    Public rsM As DataSet
    Public rsM2 As DataSet

    Public Current_Row As Integer ' indicate the current position of sample details 
    ' old declaration
    'Public rs_SAREQHDR As ADOR.Recordset
    'Public rs_VNCNTINF As ADOR.Recordset
    'Public rs_CUBASINF_SR As ADOR.Recordset
    'Public rs_SAORDSUM As ADOR.Recordset
    'Public rs_SAORDDTL As ADOR.Recordset
    'Public rs_SAREQDTL As ADOR.Recordset
    'Public rs_SAREQASS As ADOR.Recordset

    Dim selectedRow As Integer


    Private Sub SAM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        '        AccessRight_1(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001 Change by Lewis on 2 Jul 2003
        '        Timer1.Enabled = False
        '        'AccessRight (Me.Name)
        '        Enq_right_local = Enq_right
        '        Del_right_local = Del_right

        '        Me.KeyPreview = True
        '        Dim v
        '        Screen.MousePointer = vbHourglass
        '        bolDisplay = True
        '        For Each v In Me.Controls
        '            If IsDataGrid(v) Then
        '                v.BackColor = &H80000004 ' Gray color
        '                v.TabAction = 1
        '                v.RowHeight = 190
        '                v.TabStop = True
        '                v.WrapCellPointer = False
        '            End If
        '        Next
        '       Screen.MousePointer = vbDefault
        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        Me.KeyPreview = True
        SetStatus("Init")
        Formstartup(Me.Name)
        txtReqNo.Select()
        cmdCancel.Enabled = False
        'cmdSearch.Enabled = False
    End Sub


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If Not check_Header() Then Exit Sub
        check_update_Detail()
        If Recordstatus = True Then
            Dim save_string As String
            If Add_flag Or Insert_flag Then
                save_string = "Record is newly created. Do you want to save before exit?"
            Else
                save_string = "Record has been modified. Do you want to save before clear the screen?"
            End If

            Dim result As Microsoft.VisualBasic.MsgBoxResult = MsgBox(save_string, MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                If Enq_right_local Then
                    Call cmdSave_Click(sender, e)
                    Me.Close()
                Else
                    MsgBox("You have no Save record rights!")
                End If
            ElseIf result = MsgBoxResult.No Then
                ResetDefaultDisp()
                Me.Close()
            ElseIf result = MsgBoxResult.Cancel Then
            End If

        Else
            SetStatus("Clear")
            Me.Close()
        End If
    End Sub


    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
    End Sub

    Public Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        '--- Prompt error if there is no input in sample request no. ---
        If (Trim(txtReqNo.Text) = "") Then
            If txtReqNo.Enabled = True Then txtReqNo.Focus()
            MsgBox("Pls input Sample Request No.")
            Exit Sub
        End If
        '----------------------------------------------------------------

        '-------- upcase the req no --------
        txtReqNo.Text = UCase(txtReqNo.Text)
        '-----------------------------------

        '---------------- Header------------------
        gspStr = "sp_select_SAREQHDR '" & gsCompany & "','" & txtReqNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAREQHDR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00001 sp_select_SAREQHDR : " & rtnStr)
        Else
            If rs_SAREQHDR.Tables("RESULT").Rows.Count > 0 Then
                Display_Header()
                SetStatus("Updating")
            Else
                MsgBox("No Record Found!")
                cboCoCde.Focus()
                Exit Sub
            End If
        End If
        '------------------------------------------

        '-----------------Details------------------
        gspStr = "sp_select_SAREQDTL2 '" & gsCompany & "','" & txtReqNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAREQDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00001 sp_select_SAREQDTL2 : " & rtnStr)
        Else
            If rs_SAREQDTL.Tables("RESULT").Rows.Count > 0 Then
                Call Display_Detail()
                Recordstatus = False
                checkBackNext()
                Call Display_Summary()
            End If
        End If
        '------------------------------------------

        '---------------Assortment-----------------
        gspStr = "sp_select_SAREQASS '" & gsCompany & "','" & txtReqNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAREQASS, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00001 sp_select_SAREQASS : " & rtnStr)
        Else
            If rs_SAREQASS.Tables("RESULT").Rows.Count > 0 Then
                'rs_SAREQASS.MoveFirst()
                'rs_SAREQASS.Filter = ""

                If txtReqSeq.Text <> "" Then
                    Dim drSAREQASS() As DataRow = rs_SAREQASS.Tables("RESULT").Select("sra_reqseq = " & txtReqSeq.Text)
                    If drSAREQASS.Length = 0 Then
                        cmdAss.Enabled = False
                    Else
                        cmdAss.Enabled = True
                    End If
                Else
                    cmdAss.Enabled = True
                End If
            Else
                cmdAss.Enabled = False
            End If

            'If rs_SAREQASS.Tables("RESULT").Rows.Count > 0 Then
            '    cmdAss.Enabled = True

            '    'AddHandler frm.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
            'Else
            '    cmdAss.Enabled = False
            'End If
        End If
        '------------------------------------------

    End Sub
    Private Sub Display_Header()
        '---Basic Data
        Dim dr As DataRow = rs_SAREQHDR.Tables("RESULT").Rows(0)

        cboReqSts.Text = dr.Item("srh_reqsts").ToString

        txtIssDat.Text = Format(dr.Item("srh_issdat"), "MM/dd/yyyy")
        txtRvsDat.Text = Format(dr.Item("srh_rvsdat"), "MM/dd/yyyy")

        txtVenNo.Text = dr.Item("vbi_vensna").ToString
        txtSubCde.Text = dr.Item("srh_subcde").ToString
        txtVenAdr.Text = dr.Item("srh_venadr").ToString
        txtVenStt.Text = dr.Item("srh_venstt").ToString
        txtVenCty.Text = dr.Item("srh_vencty").ToString
        txtVenPst.Text = dr.Item("srh_venpst").ToString

        txtPrcTrm.Text = dr.Item("srh_prctrm").ToString
        txtCus1No.Text = dr.Item("cbi_cus1na").ToString
        txtCus2No.Text = dr.Item("cbi_cus2na").ToString
        txtCusSmpPo.Text = dr.Item("srh_cussmppo").ToString
        txtCusDelDat.Text = Format(dr.Item("srh_cusdeldat"), "MM/dd/yyyy")
        txtVenDelDat.Text = Format(dr.Item("srh_vendeldat"), "MM/dd/yyyy")
        txtRmk.Text = dr.Item("srh_rmk").ToString

        '---Contact Person
        gspStr = "sp_select_VNCNTINF '" & gsCompany & "','" & dr.Item("srh_venno").ToString & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        cboVenCtp.Text = ""
        Dim dr2 As DataRow = rs_VNCNTINF.Tables("RESULT").Rows(0)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00001 sp_select_VNCNTINF : " & rtnStr)
        Else
            If rs_VNCNTINF.Tables("RESULT").Rows.Count > 0 Then
                For Each dr2 In rs_VNCNTINF.Tables("RESULT").Rows
                    cboVenCtp.Items.Add(dr2.Item("vci_cntctp").ToString)
                Next
                cboVenCtp.Text = dr.Item("srh_venctp").ToString
            End If
        End If

        '---Sales Rep   
        'gspStr = "sp_select_CUBASINF_SR '" & gsCompany & "','" & dr.Item("srh_salrep").ToString & "','" & gsUsrID & "'"
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_SR, rtnStr)
        'Me.Cursor = Windows.Forms.Cursors.Default
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading SAM00001 sp_select_CUBASINF_SR : " & rtnStr)
        'Else
        '    Dim dr3 As DataRow = rs_CUBASINF_SR.Tables("RESULT").Rows(0)
        '    If rs_CUBASINF_SR.Tables("RESULT").Rows.Count = 0 Then
        '        cboSalRep.Enabled = False
        '    Else
        '        cboSalRep.Enabled = True
        '        For Each dr3 In rs_CUBASINF_SR.Tables("RESULT").Rows
        '            cboSalRep.Items.Add(dr3.Item("dsc").ToString)
        '        Next
        '        cboSalRep.Text = dr.Item("salrep").ToString
        '    End If
        'End If

        '----Sales Team
        gspStr = "sp_list_SYSALINF_SAMPLE ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Display_Header sp_list_SYSALINF :" & rtnStr)
            Exit Sub
        End If
        Dim i As Integer
        Dim strList As String
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


        '----Sales Rep
        Dim team As String = Split(Split(dr.Item("srh_saltem").ToString, ")")(0), "Team ")(1)

        gspStr = "sp_list_SYUSRPRF_2 '','" & team & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYUSRPRF_2 :" & rtnStr)
            Exit Sub
        End If
       
       

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

        Call display_combo(dr.Item("srh_srname").ToString, cboSalRep)
        If dr.Item("srh_saltem").ToString <> " - Team " Then Call display_combo(dr.Item("srh_saltem").ToString, cboSalTem)

        If dr.Item("srh_saldiv").ToString = "  - Division  " Or _
        dr.Item("srh_saldiv").ToString = " - Division " Or _
        dr.Item("srh_saldiv").ToString = " - Division " Or _
        dr.Item("srh_saldiv").ToString = "" Then
            txtSalDiv.Text = ""
        Else
            txtSalDiv.Text = dr.Item("srh_saldiv").ToString '+ " - Division " + dr.Item("srh_saldiv").ToString
        End If
        txtSalMgt.Text = dr.Item("srh_salmgt").ToString

        'StatusBar.Panels(2).Text = Format(rs_SAREQHDR("srh_credat"), "MM/DD/YYYY") & " " & Format(rs_SAREQHDR("srh_upddat"), "MM/DD/YYYY") & _
        '" " & rs_SAREQHDR("srh_updusr")
    End Sub
    Private Sub Display_Detail()
        'If Not rs_SAREQDTL.BOF And Not rs_SAREQDTL.EOF Then




        txtQutNo.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_qutno").ToString
        txtReqSeq.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_reqseq").ToString
        chkTBM.Checked = IIf(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_tbm").ToString = "Y", 1, 0)
        txtItmNo.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_itmno").ToString

        txtTempItemNo.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_itmnotmp").ToString
        txtVenItemNo.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_itmnoven").ToString
        txtVenCode.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_itmnovenno").ToString

        txtItmSts.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_itmsts").ToString
        txtQutItmSts.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_qutitmsts").ToString
        txtVenItm.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_venitm").ToString
        txtCusItm.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cusitm").ToString
        txtEngDsc.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_engdsc").ToString
        txtChnDsc.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_chndsc").ToString
        txtVenCol.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_vencol").ToString
        txtCusCol.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cuscol").ToString
        txtColDsc.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_coldsc").ToString
        txtUntCde.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_untcde").ToString
        txtUntCde1.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_untcde").ToString
        txtInrQty.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_inrqty").ToString
        txtMtrQty.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_mtrqty").ToString
        txtCFT.Text = Format(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cft"), "######0.0000")
        txtSmpUnt.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_smpunt").ToString
        txtStkQty.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_stkqty").ToString
        txtCusQty.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cusqty").ToString
        txtSmpQty.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_smpqty").ToString
        txtCurCde.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_curcde").ToString
        txtCurCde1.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_curcde").ToString
        txtcurcde2.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_curcde").ToString
        txtFtyPrc.Text = Format(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_ftyprc"), "###,###,##0.0000")
        txtFtyCst.Text = Format(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_ftycst"), "###,###,##0.0000")
        txtSmpFtyPrc.Text = Format(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_smpftyprc"), "###,###,##0.0000")
        txtNote.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_note").ToString
        txtPrdVen.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_prdven").ToString
        txtPrdSub.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_prdsub").ToString
        txtEffDat.Text = Format(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_effdat"), "MM/dd/yyyy")
        txtExpDat.Text = Format(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_expdat"), "MM/dd/yyyy")

        Dim sTemp As String
        sTemp = ""
        If rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cus1no").ToString <> "" Then
            sTemp = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cus1no").ToString
            If rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cus2no").ToString <> "" Then
                sTemp = sTemp + "/" + rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cus2no").ToString
            End If
        Else
            sTemp = "Standard"
        End If
        txtPrcKey.Text = sTemp '+ "/" + rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_hkprctrm").ToString + "/" + _
        'rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_ftyprctrm").ToString(+"/" + rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_trantrm").ToString)

        txtHkPrcT.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_hkprctrm").ToString
        txtFtyPrcT.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_ftyprctrm").ToString
        txtTranPrcT.Text = rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_trantrm").ToString

        warn = True
        chkCancel.Checked = IIf(rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("cancel").ToString = "Y" Or rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_canflg").ToString = "Y", 1, 0)
        warn = False
        If rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_canflg").ToString = "Y" Then
            chkCancel.Enabled = False
            txtCusItm.Enabled = True
            txtCusItm.ReadOnly = True
            txtCusItm.BackColor = SystemColors.Window

            txtCusCol.Enabled = True
            txtCusCol.ReadOnly = True
            txtCusCol.BackColor = SystemColors.Window
            txtEngDsc.Enabled = True
            txtChnDsc.Enabled = True
            txtEngDsc.ReadOnly = True
            txtEngDsc.BackColor = SystemColors.Window
            txtChnDsc.ReadOnly = True
            txtChnDsc.BackColor = SystemColors.Window
            txtColDsc.Enabled = False
            txtNote.Enabled = False
        Else
            chkCancel.Enabled = True
            txtCusItm.Enabled = True
            txtCusCol.Enabled = True
            txtCusItm.ReadOnly = False
            txtCusCol.ReadOnly = False
            txtEngDsc.Enabled = True
            txtChnDsc.Enabled = True
            txtEngDsc.ReadOnly = False
            txtChnDsc.ReadOnly = False
            txtColDsc.Enabled = True
            txtNote.Enabled = True
        End If

        If Not rs_SAREQASS Is Nothing Then
            If txtReqSeq.Text <> "" Then
                Dim drSAREQASS() As DataRow = rs_SAREQASS.Tables("RESULT").Select("sra_reqseq = " & txtReqSeq.Text)
                If drSAREQASS.Length = 0 Then
                    cmdAss.Enabled = False
                Else
                    cmdAss.Enabled = True
                End If
            Else
                cmdAss.Enabled = True
            End If
        Else
            cmdAss.Enabled = False
        End If
    End Sub
    Private Sub Display_Summary()
        grdSummary.DataSource = rs_SAREQDTL.Tables("RESULT").DefaultView

        'grdSummary.RowHeadersWidth = 18
        'grdSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        'grdSummary.ColumnHeadersHeight = 18
        'grdSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'grdSummary.AllowUserToResizeColumns = True
        'grdSummary.AllowUserToResizeRows = False
        'grdSummary.RowTemplate.Height = 18
        'grdSummary.AllowUserToOrderColumns = True

        Dim bolShow As Boolean
        bolShow = IIf(gsFlgCst = "1" And gsFlgCstExt = "1", True, False)
        With grdSummary
            .Columns(0).Visible = False
            .Columns(0).Width = 0
            .Columns(1).Visible = False
            .Columns(1).Width = 0
            .Columns(2).Visible = False
            .Columns(2).Width = 0
            .Columns(3).HeaderCell.Value = "Seq #"
            .Columns(3).Visible = True
            '.Columns(3).Width = 600
            .Columns(3).Width = 40
            .Columns(4).HeaderCell.Value = "Item #"
            .Columns(4).Visible = True
            '.Columns(4).Width = 1200
            .Columns(5).Visible = False
            .Columns(5).Width = 0
            .Columns(6).HeaderCell.Value = "Vendor Item #"
            .Columns(6).Visible = True
            '.Columns(6).Width = 1400
            .Columns(7).HeaderCell.Value = "Cust. Item #"
            .Columns(7).Visible = True
            '.Columns(7).Width = 1000
            .Columns(8).Visible = False
            .Columns(8).Width = 0
            .Columns(9).Visible = False
            .Columns(9).Width = 0
            .Columns(10).HeaderCell.Value = "Vendor Color"
            .Columns(10).Visible = True
            '.Columns(10).Width = 1000
            .Columns(10).Width = 65
            .Columns(11).HeaderCell.Value = "Color Desc"
            .Columns(11).Visible = True
            '.Columns(11).Width = 2000
            .Columns(11).Width = 90
            .Columns(12).HeaderCell.Value = "Cust. Color"
            .Columns(12).Visible = True
            '.Columns(12).Width = 2000
            .Columns(12).Width = 90
            .Columns(13).Visible = False    'Packing Sequence
            .Columns(13).Width = 0
            .Columns(14).HeaderCell.Value = "U/M"
            .Columns(14).Visible = True
            .Columns(14).Width = 40
            '.Columns(14).Width = 600
            .Columns(15).HeaderCell.Value = "Inner"
            .Columns(15).Visible = True
            '.Columns(15).Width = 600
            .Columns(15).Width = 35
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(16).HeaderCell.Value = "Master"
            .Columns(16).Visible = True
            '.Columns(16).Width = 600
            .Columns(16).Width = 35
            .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(17).HeaderCell.Value = "CFT"
            .Columns(17).Visible = True
            '.Columns(17).Width = 600
            .Columns(17).Width = 45
            .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(18).HeaderCell.Value = "Stock Qty"
            .Columns(18).Visible = True
            '.Columns(18).Width = 800
            .Columns(18).Width = 35
            .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(19).HeaderCell.Value = "SA U/M"
            .Columns(19).Visible = True
            '.Columns(19).Width = 1000
            .Columns(19).Width = 40
            .Columns(20).HeaderCell.Value = "Cust. Qty"
            .Columns(20).Visible = True
            '.Columns(20).Width = 800
            .Columns(20).Width = 40
            .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(21).HeaderCell.Value = "Sample Qty"
            .Columns(21).Visible = True
            '.Columns(21).Width = 1000
            .Columns(21).Width = 40
            .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(22).HeaderCell.Value = "Fty Curr."
            .Columns(22).Visible = bolShow
            .Columns(22).Width = IIf(bolShow = True, 40, 0)
            .Columns(23).HeaderCell.Value = "Ttl/Item Cst U/M"
            .Columns(23).Visible = bolShow
            .Columns(23).Width = IIf(bolShow = True, 40, 0)
            .Columns(24).HeaderCell.Value = "Ttl Cst"
            .Columns(24).Visible = bolShow
            .Columns(24).Width = IIf(bolShow = True, 60, 0)
            .Columns(24).ReadOnly = True
            .Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(25).HeaderCell.Value = "Item Cst"
            .Columns(25).Visible = bolShow
            .Columns(25).Width = IIf(bolShow = True, 60, 0)
            .Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(26).HeaderCell.Value = "Fty SA Cst"
            .Columns(26).Visible = bolShow
            .Columns(26).Width = IIf(bolShow = True, 60, 0)
            .Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(27).HeaderCell.Value = "Note"
            .Columns(27).Visible = True
            '.Columns(27).Width = 1600
            .Columns(27).Width = 120
            .Columns(28).HeaderCell.Value = "TBM"
            .Columns(28).Visible = True
            '.Columns(28).Width = 600
            .Columns(28).Width = 40
            .Columns(29).Visible = False
            .Columns(29).Width = 0
            .Columns(30).Visible = False
            .Columns(30).Width = 0
            .Columns(31).HeaderCell.Value = "Cancel"
            .Columns(31).Visible = True
            '.Columns(31).Width = 700
            .Columns(31).Width = 30
            .Columns(32).Visible = False
            .Columns(32).Width = 0
            .Columns(33).Visible = False
            .Columns(33).Width = 0
            .Columns(34).Visible = False
            .Columns(34).Width = 0
            .Columns(35).HeaderCell.Value = "Ref Qut #"
            .Columns(35).Visible = True
            '.Columns(35).Width = 1200
            .Columns(36).HeaderCell.Value = "Prd Ven"
            .Columns(36).Visible = True
            '.Columns(36).Width = 1000
            .Columns(36).Width = 100
            .Columns(37).HeaderCell.Value = "Sub Code"
            .Columns(37).Visible = True
            '.Columns(37).Width = 1000
            .Columns(37).Width = 80
            .Columns(38).HeaderCell.Value = "Price Key Pri Cust"
            .Columns(38).Visible = True
            '.Columns(38).Width = 1000
            .Columns(38).Width = 80
            .Columns(39).HeaderCell.Value = "Price Key Sec Cust"
            .Columns(39).Visible = True
            '.Columns(39).Width = 1000
            .Columns(39).Width = 80
            .Columns(40).HeaderCell.Value = "Price Key HK Price Term"
            .Columns(40).Visible = True
            '.Columns(40).Width = 1000
            .Columns(40).Width = 80
            .Columns(41).HeaderCell.Value = "Price Key Fty Price Term"
            .Columns(41).Visible = True
            '.Columns(41).Width = 1000
            .Columns(41).Width = 80
            .Columns(42).HeaderCell.Value = "Price Key Tran Term"
            .Columns(42).Visible = True
            '.Columns(42).Width = 1000
            .Columns(42).Width = 80
            .Columns(43).HeaderCell.Value = "Price Key Eff Date"
            .Columns(43).Visible = True
            '.Columns(43).Width = 1000
            .Columns(43).Width = 80
            .Columns(44).HeaderCell.Value = "Price Key Exp Date"
            .Columns(44).Visible = True
            '.Columns(44).Width = 1000
            .Columns(44).Width = 80
            .Columns(45).Visible = False
            .Columns(46).Visible = False
            .Columns(47).Visible = False
        End With
    End Sub

    Private Sub txtReqNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReqNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click(sender, e)
        End If
    End Sub
    Private Sub ResetDefaultDisp()
        'Cancel_Click = False
        cancel_Click_Count = 0
        '*** Header
        cboReqSts.Text = ""
        txtIssDat.Text = ""
        txtRvsDat.Text = ""

        cboSalTem.Text = ""
        txtSalMgt.Text = ""
        txtSalDiv.Text = ""
        txtVenNo.Text = ""
        txtSubCde.Text = ""
        txtVenAdr.Text = ""
        txtVenStt.Text = ""
        txtVenCty.Text = ""
        txtVenPst.Text = ""
        cboVenCtp.Text = ""
        cboSalRep.Text = ""
        txtPrcTrm.Text = ""
        txtCus1No.Text = ""
        txtCus2No.Text = ""
        txtCusSmpPo.Text = ""
        txtCusDelDat.Text = ""
        txtVenDelDat.Text = ""
        txtRmk.Text = ""
        chkCancelAll.Checked = False
        '*** Details
        txtQutNo.Text = ""
        txtReqSeq.Text = ""
        chkTBM.Checked = False
        chkCancel.Checked = False

        txtItmNo.Text = ""
        txtVenItm.Text = ""
        txtCusItm.Text = ""
        txtItmSts.Text = ""
        txtEngDsc.Text = ""
        txtChnDsc.Text = ""
        txtVenCol.Text = ""
        txtCusCol.Text = ""
        txtColDsc.Text = ""
        txtUntCde.Text = ""
        txtUntCde1.Text = ""
        txtInrQty.Text = ""
        txtMtrQty.Text = ""
        txtCFT.Text = ""
        txtSmpUnt.Text = ""
        txtStkQty.Text = ""
        txtCusQty.Text = ""
        txtSmpQty.Text = ""
        txtCurCde.Text = ""
        txtCurCde1.Text = ""
        txtFtyPrc.Text = ""
        txtSmpFtyPrc.Text = ""
        txtNote.Text = ""

        txtQutItmSts.Text = ""
        txtcurcde2.Text = ""
        txtFtyCst.Text = ""
        txtEffDat.Text = ""
        txtExpDat.Text = ""
        txtPrcKey.Text = ""
        txtPrdVen.Text = ""

        Me.StatusBar.Items("lblLeft").Text = ""
        Me.StatusBar.Items("lblRight").Text = ""

        '************Carlos Lui added on 20120921************
        txtPrcKey.Enabled = False
        txtEffDat.Enabled = False
        txtExpDat.Enabled = False
        'txtPrcKey.ReadOnly = True
        'txtEffDat.ReadOnly = True
        'txtExpDat.ReadOnly = True
        '************Carlos Lui added on 20120921************

        'Reset other fields
        'Add codes here..........

    End Sub

    Private Sub SetStatus(ByVal Mode As String)



        If Mode = "Init" Then
            Current_Row = 0
            '    DoEvents()
            Call SetInputBoxesStatus("DisableAll")
            'DoEvents()
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            'CmdLookup.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True
            'cmdspecial.Enabled = True
            'cmdbrowlist.Enabled = True

            cmdfirst.Enabled = False
            cmdlast.Enabled = False
            cmdNext.Enabled = False
            cmdPrv.Enabled = False
            cboSalRep.Items.Clear()


            'cmdPrv.Enabled = False

            chkCancelAll.Checked = False
            chkCancel.Checked = False

            Current_Row = 0

            cboCoCde.Enabled = True

            Call ResetDefaultDisp()
            'DoEvents()
            Call SetStatusBar(Mode)


            'DoEvents()

            If gsCompany = "UCPP" Then
                If VendorType = "I" Then
                    If gsFlgCst = 1 Then
                        lblSmpFtyPrc.Visible = True
                        txtSmpFtyPrc.Visible = True
                        lblFtyPrc.Visible = True
                        txtFtyPrc.Visible = True
                        txtCurCde.Visible = True
                        txtCurCde1.Visible = True
                        lblFtyCst.Visible = True
                        txtcurcde2.Visible = True
                        txtFtyCst.Visible = True
                    Else
                        lblSmpFtyPrc.Visible = False
                        txtSmpFtyPrc.Visible = False
                        lblFtyPrc.Visible = False
                        txtFtyPrc.Visible = False
                        txtCurCde.Visible = False
                        txtCurCde1.Visible = False
                        lblFtyCst.Visible = False
                        txtcurcde2.Visible = False
                        txtFtyCst.Visible = False
                    End If
                Else
                    lblSmpFtyPrc.Text = "Factory Sample Cost :"
                    'If gsFlgCst = 1 Then
                    If gsFlgCstExt = 1 Then
                        lblSmpFtyPrc.Visible = True
                        txtSmpFtyPrc.Visible = True
                        lblFtyPrc.Visible = True
                        txtFtyPrc.Visible = True
                        txtCurCde.Visible = True
                        txtCurCde1.Visible = True
                        lblFtyCst.Visible = True
                        txtcurcde2.Visible = True
                        txtFtyCst.Visible = True
                    Else
                        lblSmpFtyPrc.Visible = False
                        txtSmpFtyPrc.Visible = False
                        lblFtyPrc.Visible = False
                        txtFtyPrc.Visible = False
                        txtCurCde.Visible = False
                        txtCurCde1.Visible = False
                        lblFtyCst.Visible = False
                        txtcurcde2.Visible = False
                        txtFtyCst.Visible = False
                    End If
                End If
            End If


            'SSTab1.Tab = 0
            Me.TabPageMain.SelectedIndex = 0
            txtReqNo.Enabled = True

            '***Reset the flag
            'addcount = 0
            Recordstatus = False
            'Cancel_Click = False
            cancel_Click_Count = 0
            Insert_flag = False

            freeze_TabControl(-1)


        ElseIf Mode = "Clear" Then
            Call SetStatus("Init")
            Call SetStatusBar(Mode)
            rs_SAREQHDR = Nothing
            rs_VNCNTINF = Nothing
            rs_CUBASINF_SR = Nothing
            rs_SAORDSUM = Nothing
            rs_SAORDDTL = Nothing
            rs_SAREQDTL = Nothing
            rs_SAREQASS = Nothing
            rsM = Nothing
            rsM2 = Nothing

            If txtReqNo.Enabled = True And txtReqNo.Visible = True Then
                txtReqNo.Focus()
            End If


            cboSalRep.Items.Clear()
            'Add your codes here
            'ElseIf mode = "ADD" Then
            '    EditModeHdr = mode
            '    DoEvents()
            '    Call SetInputBoxesStatus("EnableAll")
            '    DoEvents()
            '    cmdSave.Enabled = Enq_right_local 'True
            '    cmdDelete.Enabled = False
            '    cmdAdd.Enabled = False
            '    cmdFind.Enabled = False
            '    cmdSearch.Enabled = False
            '    cmdCopy.Enabled = False
            '    DoEvents()
            '    Call SetStatusBar(mode)
            '    DoEvents()

        ElseIf Mode = "Updating" Then
            release_TabControl()
            Call SetInputBoxesStatus("EnableAll")
            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right_local 'True
            cmdDelete.Enabled = False 'Del_right
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = False 'Enq_right 'True
            cmdDelRow.Enabled = False 'Del_right 'True
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            txtReqNo.Enabled = False
            Me.cboCoCde.Enabled = False
            cboReqSts.Enabled = False
            txtIssDat.Enabled = False
            txtRvsDat.Enabled = False
            txtVenNo.Enabled = False
            txtSubCde.Enabled = False
            txtVenAdr.Enabled = False
            txtVenStt.Enabled = False
            txtVenCty.Enabled = False
            txtVenPst.Enabled = False
            txtPrcTrm.Enabled = False
            txtCus1No.Enabled = False
            txtCus2No.Enabled = False
            If Strings.Left(rs_SAREQHDR.Tables("RESULT").Rows(0).Item("srh_reqsts").ToString, 1) = "C" Then
                chkCancelAll.Enabled = False
            Else
                chkCancelAll.Enabled = True
            End If
            txtQutNo.Enabled = False
            txtReqSeq.Enabled = False
            chkTBM.Enabled = False
            txtItmNo.Enabled = False
            txtTempItemNo.Enabled = False
            txtVenItemNo.Enabled = False
            txtVenCode.Enabled = False
            txtItmSts.Enabled = False
            txtQutItmSts.Enabled = False
            txtVenItm.Enabled = True
            txtVenItm.ReadOnly = True
            txtVenItm.BackColor = SystemColors.Window
            txtVenCol.Enabled = True
            txtVenCol.ReadOnly = True
            txtVenCol.BackColor = SystemColors.Window
            txtUntCde.Enabled = False
            txtUntCde1.Enabled = False
            txtInrQty.Enabled = False
            txtMtrQty.Enabled = False
            txtCFT.Enabled = False
            txtHkPrcT.Enabled = False
            txtFtyPrcT.Enabled = False
            txtTranPrcT.Enabled = False
            txtSmpUnt.Enabled = False
            txtStkQty.Enabled = False
            txtCusQty.Enabled = False
            txtSmpQty.Enabled = False
            txtCurCde.Enabled = False
            txtCurCde1.Enabled = False
            txtcurcde2.Enabled = False
            txtFtyPrc.Enabled = False
            txtFtyCst.Enabled = False
            txtSmpFtyPrc.Enabled = False
            txtPrdVen.Enabled = False
            txtPrdSub.Enabled = False
            'cmdBOM.Enabled = False
            Recordstatus = False
            Call SetStatusBar(Mode)
        ElseIf Mode = "Save" Then
            'If Mode = "Save" Then
            MsgBox("Record Saved!")
            Call SetStatusBar(Mode)
            rs_SAREQHDR = Nothing
            rs_SAREQDTL = Nothing
            rs_SAREQASS = Nothing

            Call SetStatus("Init")


            'ElseIf mode = "Delete" Then
            '    Call SetStatusBar(mode)
            '    'Add your codes here

            'End If
        End If
    End Sub

    Private Sub SetInputBoxesStatus(ByVal Mode As String)
        Dim v As Control

        '*** (1) If Mode = "EnableAll", enable all controls
        If Mode = "EnableAll" Then
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = True
                End If
            Next

            If EditModeHdr = "ADD" Then
                cmdSave.Enabled = False
                cmdDelete.Enabled = False

            ElseIf EditModeHdr = "Updating" Then
                cmdAdd.Enabled = False
            End If

            txtCoNam.Enabled = False
            txtCoNam.BackColor = Color.White

            '*** (2) If Mode = "DisableAll", disable all controls
        ElseIf Mode = "DisableAll" Then
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = False
                End If
            Next

        End If

    End Sub

    Public Function IsInputBoxes(ByVal v As Object) As Boolean
        If (TypeOf v Is TextBox) Or (TypeOf v Is CheckBox) Or _
           (TypeOf v Is ComboBox) Or _
           (TypeOf v Is ListBox) Or _
           (TypeOf v Is DataGrid) Then
            IsInputBoxes = True
        Else
            IsInputBoxes = False
        End If
    End Function


    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
            'Add your codes here

        ElseIf mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "ADD"
            'Add your codes here

        ElseIf mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
            'Add your codes here

        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
            'Add your codes here

        ElseIf mode = "Delete" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Deleted"
            'Add your codes here

        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
            'Add your codes here
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
            'Add your codes here
        End If

    End Sub

   
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If Not check_Header() Then Exit Sub
        check_update_Detail()
        If Recordstatus = True Then
            Dim save_string As String
            If Add_flag Or Insert_flag Then
                save_string = "Record is newly created. Do you want to save before exit?"
            Else
                save_string = "Record has been modified. Do you want to save before clear the screen?"
            End If

            Dim result As Microsoft.VisualBasic.MsgBoxResult = MsgBox(save_string, MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                If Enq_right_local Then
                    Call cmdSave_Click(sender, e)
                Else
                    MsgBox("You have no Save record rights!")
                End If
            ElseIf result = MsgBoxResult.No Then
                SetStatus("Clear")
            ElseIf result = MsgBoxResult.Cancel Then

            End If

        Else
            SetStatus("Clear")

        End If

        'If Not check_Header() Then Exit Sub
        'check_update_Detail()
        'If Recordstatus = True Then
        '    Dim save_string As String
        '    If Add_flag Or Insert_flag Then
        '        save_string = "Record is newly created. Do you want to save before exit?"
        '    Else
        '        save_string = "Record has been modified. Do you want to save before clear the screen?"
        '    End If
        '    Select Case MsgBox(save_string, MsgBoxStyle.YesNoCancel)
        '        Case MsgBoxResult.Yes
        '            If Enq_right_local Then
        '                Call cmdSave_Click(sender, e)
        '                Me.Close()
        '            Else
        '                MsgBox("You have no Save record rights!")
        '            End If
        '            Me.Cursor = Cursors.Default
        '            Exit Sub
        '        Case MsgBoxResult.No
        '            Exit Sub
        '        Case MsgBoxResult.Cancel
        '            Exit Sub
        '    End Select
        'Else
        '    SetStatus("Clear")
        'End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click


        '---------------------------------------------





        If check_Header() = False Then
            Exit Sub
        End If



        Dim S As String
        'Dim rs() As ADOR.Recordset

        Dim Cancel As String
        Dim count_Cancel As Integer
        Dim count_Detail As Integer

        'If cancel_Click_Count > 0 Then
        '    'If Cancel_Click = True Then
        '    If msg("M00431") = vbNo Then
        '        Exit Sub
        '    End If
        'End If
        If cancel_Click_Count > 0 Then
            Dim result As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Sample Request will delete Sample Order QTY and related Sample Invoice can't be generated. Continue to cancel Sample Request?", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        



        save_fail = False
        count_Cancel = 0
        count_Detail = rs_SAREQDTL.Tables("RESULT").Rows.Count


        If Me.TabPageMain.SelectedIndex = 1 Then
            check_update_Detail()
            fill_SAREQDTL()
        End If


        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        



        ''*** SAVE DETAIL
        'rs_SAREQDTL.MoveFirst()
        'While Not rs_SAREQDTL.EOF

        '    'added by tommy on 12 nov 2002


        Current_Row = 0
        For i As Integer = 0 To rs_SAREQDTL.Tables("RESULT").Rows.Count - 1
            If rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_canflg").ToString = "Y" Or rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel").ToString = "Y" Then
                count_Cancel = count_Cancel + 1
            End If

            If rs_SAREQDTL.Tables("RESULT").Rows(i).Item("mode").ToString = "UPD" Then
                If Not checkTimeStamp() Then
                    MsgBox("The record has been modified by other users, please clear and try again.")
                    Me.Cursor = Windows.Forms.Cursors.Default
                    save_ok = False
                    save_fail = True
                    Exit Sub


                Else
                    If rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_canflg").ToString = "Y" Or rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel").ToString = "Y" Then
                        Cancel = "Y"
                    Else
                        Cancel = "N"
                    End If

                    S = "sp_update_SAREQDTL '" & gsCompany & "','" & txtReqNo.Text & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqseq").ToString & "','" & _
                    Replace(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_engdsc"), "'", "''") & "','" & Replace(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_chndsc"), "'", "''") & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_cuscol").ToString & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_coldsc").ToString & "','" & _
                    Replace(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_note"), "'", "''") & "','" & Cancel & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_cusitm").ToString & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_smpqty").ToString & "','" & _
                    rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_stkqty").ToString & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_cusqty").ToString & "','" & rs_SAREQHDR.Tables("RESULT").Rows(0).Item("srh_cus1no").ToString & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_itmno").ToString & "','" & _
                    rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_colcde").ToString & "','" & gsUsrID & "'"
                    If S > "" Then
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(S, rsM, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSave_Click sp_update_SAREQDTL :" & rtnStr)
                            Exit Sub
                        Else
                            IsUpdated = True
                        End If
                    End If
                    '-----------------Save Assortment-----------------

                    If rs_SAREQASS.Tables("RESULT").Rows.Count > 0 Then
                        Dim drSAREQASS() As DataRow = rs_SAREQASS.Tables("RESULT").Select("sra_reqseq = " & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqseq"))
                        For j As Integer = 0 To drSAREQASS.Length - 1
                            S = "sp_update_SAREQASS '" & gsCompany & "','" & drSAREQASS(j).Item("sra_reqno") & "','" & drSAREQASS(j).Item("sra_reqseq") & "','" & _
                    drSAREQASS(j).Item("sra_itmno") & "','" & drSAREQASS(j).Item("sra_assitm") & "','" & drSAREQASS(j).Item("sra_assdsc") & "','" & drSAREQASS(j).Item("sra_cusitm") & "','" & _
                    drSAREQASS(j).Item("sra_colcde") & "','" & drSAREQASS(j).Item("sra_cussku") & "','" & drSAREQASS(j).Item("sra_upcean") & "','" & drSAREQASS(j).Item("sra_cusrtl") & "','" & _
                    drSAREQASS(j).Item("sra_pckunt") & "','" & drSAREQASS(j).Item("sra_inrqty") & "','" & drSAREQASS(j).Item("sra_mtrqty") & "','" & gsUsrID & "'"
                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(S, rsM2, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SAM00001 sp_update_SAREQASS :" & rtnStr)
                                Exit Sub
                            Else
                                IsUpdated = True
                            End If

                        Next
                    End If

                End If

            End If

        Next
        'added by tommy on 12 nov 2002
        Dim cancel_Header As String
        cancel_Header = "N"
        If count_Detail = count_Cancel Then
            cancel_Header = "Y"
        End If

        '-----------------Save Header-----------------
        Dim salrep As String
        If cboSalRep.Text = "" Then
            salrep = ""
        Else
            Dim aryTextFile() As String
            aryTextFile = cboSalRep.Text.Split(" - ")
            salrep = (aryTextFile(0))
        End If

        Dim saltem As String
        If cboSalTem.Text = "" Then
            saltem = ""
        Else
            Dim aryTextFile2() As String
            aryTextFile2 = cboSalTem.Text.Split(" - ")
            saltem = (aryTextFile2(0))
        End If

        Dim saldiv As String = Trim(Split(txtSalDiv.Text, " - ")(0))
        Dim salmgt As String = Trim(txtSalMgt.Text)


        gspStr = "sp_update_SAREQHDR '" & gsCompany & "','" & txtReqNo.Text & "','" & cboVenCtp.Text & "','" & _
        salrep & "','" & txtCusSmpPo.Text & "','" & txtCusDelDat.Text & "','" & txtVenDelDat.Text & "','" & _
        Replace(txtRmk.Text, "'", "''") & "','" & cancel_Header & _
        "','" & saltem & "','" & saldiv & "','" & salmgt & "','" & salrep & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAREQHDR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default


        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00001 sp_update_SAREQHDR : " & rtnStr)
        Else
            If rs_SAREQDTL.Tables("RESULT").Rows.Count > 0 Then
                IsUpdated = True


            End If
        End If
 

        If IsUpdated Then
            Call SetStatus("Save")
            save_ok = True

            If txtReqNo.Enabled = True Then
                txtReqNo.Focus()
            End If
        Else
            save_ok = False
        End If

    End Sub

    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
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
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            Me.TabPageMain.TabPages(i).Enabled = True
        Next i
    End Sub

    Private Sub CmdBackD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBackD.Click
        check_update_Detail()
        fill_SAREQDTL()
        Current_Row = Current_Row - 1
        Display_Detail()
        checkBackNext()

    End Sub

    Private Sub CmdNextD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNextD.Click
        check_update_Detail()
        fill_SAREQDTL()
        Current_Row = Current_Row + 1
        Display_Detail()
        checkBackNext()
    End Sub

    Private Sub checkBackNext()
        If Current_Row = 0 Then
            CmdBackD.Enabled = False
        Else
            CmdBackD.Enabled = True
        End If

        If Current_Row = rs_SAREQDTL.Tables("RESULT").Rows.Count - 1 Then
            CmdNextD.Enabled = False
        Else
            CmdNextD.Enabled = True
        End If
    End Sub

    Private Sub fill_SAREQDTL()
        rs_SAREQDTL.Tables("RESULT").Columns("srd_cusitm").ReadOnly = False
        rs_SAREQDTL.Tables("RESULT").Columns("srd_engdsc").ReadOnly = False
        rs_SAREQDTL.Tables("RESULT").Columns("srd_chndsc").ReadOnly = False
        rs_SAREQDTL.Tables("RESULT").Columns("srd_cuscol").ReadOnly = False
        rs_SAREQDTL.Tables("RESULT").Columns("srd_coldsc").ReadOnly = False
        rs_SAREQDTL.Tables("RESULT").Columns("srd_note").ReadOnly = False
        rs_SAREQDTL.Tables("RESULT").Columns("cancel").ReadOnly = False

        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cusitm") = txtCusItm.Text
        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_engdsc") = txtEngDsc.Text
        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_chndsc") = txtChnDsc.Text
        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cuscol") = txtCusCol.Text
        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_coldsc") = txtColDsc.Text
        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_note") = txtNote.Text
        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("cancel") = IIf(chkCancel.Checked = True, "Y", "N")

        rs_SAREQDTL.Tables("RESULT").Columns("srd_cusitm").ReadOnly = True
        rs_SAREQDTL.Tables("RESULT").Columns("srd_engdsc").ReadOnly = True
        rs_SAREQDTL.Tables("RESULT").Columns("srd_chndsc").ReadOnly = True
        rs_SAREQDTL.Tables("RESULT").Columns("srd_cuscol").ReadOnly = True
        rs_SAREQDTL.Tables("RESULT").Columns("srd_coldsc").ReadOnly = True
        rs_SAREQDTL.Tables("RESULT").Columns("srd_note").ReadOnly = True
        rs_SAREQDTL.Tables("RESULT").Columns("cancel").ReadOnly = True

    End Sub

    Private Sub cboVenCtp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCtp.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboVenCtp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCtp.TextChanged
        Recordstatus = True
    End Sub

    Private Sub cboSalRep_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSalRep.KeyUp
        auto_search_combo(cboSalRep, e.KeyCode)
    End Sub

    Private Sub cboSalRep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalRep.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboSalRep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalRep.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtCusDelDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusDelDat.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtCusSmpPo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusSmpPo.TextChanged
        Recordstatus = True
    End Sub


    Private Sub txtRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtVenDelDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenDelDat.TextChanged
        Recordstatus = True
    End Sub
    Private Sub check_update_Detail()
        Dim canflg As String

        If Not rs_SAREQDTL Is Nothing Then
            If rs_SAREQDTL.Tables("RESULT").Rows.Count > 0 Then

                If rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode").ToString <> "NEW" Then

                    If chkCancel.Checked = False Then
                        canflg = "N"
                    Else
                        canflg = "Y"
                    End If

                    rs_SAREQDTL.Tables("RESULT").Columns("mode").ReadOnly = False

                    If canflg <> rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_canflg").ToString Then
                        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"
                        Recordstatus = True
                        'Cancel_Click = True

                        Exit Sub
                    End If

                    If txtCusItm.Text <> rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cusitm").ToString Then
                        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"
                        Recordstatus = True
                        Exit Sub
                    End If

                    If txtEngDsc.Text <> rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_engdsc").ToString Then
                        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"
                        Recordstatus = True
                        Exit Sub
                    End If

                    If txtChnDsc.Text <> rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_chndsc").ToString Then
                        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"
                        Recordstatus = True
                        Exit Sub
                    End If

                    If txtCusCol.Text <> rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_cuscol").ToString Then
                        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"
                        Recordstatus = True
                        Exit Sub
                    End If

                    If txtColDsc.Text <> rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_coldsc").ToString Then
                        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"
                        Recordstatus = True
                        Exit Sub
                    End If

                    If txtNote.Text <> rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_note").ToString Then
                        rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"
                        Recordstatus = True
                        Exit Sub
                    End If

                End If
            End If
        End If
    End Sub

    Private Function checkTimeStamp() As Boolean
        Dim save_timestamp As Long
        Dim curr_timestamp As Long

        gspStr = "sp_select_SAREQHDR '" & gsCompany & "','" & txtReqNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading checkTimeStamp SAREQHDR :" & rtnStr)
            Exit Function
        End If

        save_timestamp = rs.Tables("RESULT").Rows(0).Item("srh_timstp")
        curr_timestamp = rs_SAREQHDR.Tables("RESULT").Rows(0).Item("srh_timstp")

        If save_timestamp <> curr_timestamp Then
            checkTimeStamp = False
        Else
            checkTimeStamp = True
        End If

    End Function

    Private Sub returnSelectedRecordsHandler(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal temp_ChangeMode As Boolean, ByVal temp_rs_SAREQASS As DataSet)
        'handle the passed data from SAM00001_1
        If temp_RecordStatus Then
            Recordstatus = True
            rs_SAREQASS = temp_rs_SAREQASS
        End If

        If temp_ChangeMode Then
            For i As Integer = 0 To rs_SAREQASS.Tables("RESULT").Rows.Count - 1
                rs_SAREQASS.Tables("RESULT").Columns("mode").ReadOnly = False
                If rs_SAREQASS.Tables("RESULT").Rows(0).Item("mode") <> "NEW" Then
                    rs_SAREQASS.Tables("RESULT").Rows(0).Item("mode") = "UPD"
                End If
            Next
            rs_SAREQDTL.Tables("RESULT").Columns("mode").ReadOnly = False
            rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("mode") = "UPD"

            
        End If

        'MsgBox("assortment row count = " & temp_rs_SAREQASS.Tables("RESULT").Rows.Count)


    End Sub
    Private Sub cmdAss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAss.Click
        Dim frm_SAM00001_1 As New SAM00001_1(rs_SAREQASS)
        frm_SAM00001_1.MdiParent = Me.MdiParent
        frm_SAM00001_1.Show()

        AddHandler frm_SAM00001_1.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
    End Sub


    Private Sub txtVenNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenNo.TextChanged
        If Trim(txtVenNo.Text) <> "" Then
            If Len(Trim(Split(txtVenNo.Text, "-")(0))) > 1 And Trim(Split(txtVenNo.Text, "-")(0)) <> "0005" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0006" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0007" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0008" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0009" Then
                VendorType = "E"
            Else
                VendorType = "I"
            End If
        End If


        If VendorType = "I" Then
            If gsFlgCst = 1 Then
                lblSmpFtyPrc.Visible = True
                txtSmpFtyPrc.Visible = True
                lblFtyPrc.Visible = True
                txtFtyPrc.Visible = True
                txtCurCde.Visible = True
                txtCurCde1.Visible = True
                lblFtyCst.Visible = True
                txtcurcde2.Visible = True
                txtFtyCst.Visible = True
            Else
                lblSmpFtyPrc.Visible = False
                txtSmpFtyPrc.Visible = False
                lblFtyPrc.Visible = False
                txtFtyPrc.Visible = False
                txtCurCde.Visible = False
                txtCurCde1.Visible = False
                lblFtyCst.Visible = False
                txtcurcde2.Visible = False
                txtFtyCst.Visible = False
            End If
        Else
            lblSmpFtyPrc.Text = "Factory Sample Cost :"
            'If gsFlgCst = 1 Then
            If gsFlgCstExt = 1 Then
                lblSmpFtyPrc.Visible = True
                txtSmpFtyPrc.Visible = True
                lblFtyPrc.Visible = True
                txtFtyPrc.Visible = True
                txtCurCde.Visible = True
                txtCurCde1.Visible = True
                lblFtyCst.Visible = True
                txtcurcde2.Visible = True
                txtFtyCst.Visible = True
            Else
                lblSmpFtyPrc.Visible = False
                txtSmpFtyPrc.Visible = False
                lblFtyPrc.Visible = False
                txtFtyPrc.Visible = False
                txtCurCde.Visible = False
                txtCurCde1.Visible = False
                lblFtyCst.Visible = False
                txtcurcde2.Visible = False
                txtFtyCst.Visible = False
            End If
        End If
    End Sub


    Private Sub chkCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCancel.Click
        'Lester Wu 2005/01/19 Prevent the subroutin from execute when there is no detail record
        If rs_SAREQDTL Is Nothing Then Exit Sub
        If rs_SAREQDTL.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
        '--------------------------------------------------------------------------------------

        rs_SAREQDTL.Tables("RESULT").Columns("cancel").ReadOnly = False

        If warn = False And chkCancel.Checked = True Then
            rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("cancel") = "Y"
            cancel_Click_Count = cancel_Click_Count + 1
        ElseIf warn = False Then
            rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("cancel") = "N"
            cancel_Click_Count = IIf(cancel_Click_Count > 0, cancel_Click_Count - 1, 0)
        End If
        If chkCancel.Checked = True And warn = False Then

            Dim itmNo As String
            Dim colcde As String
            gspStr = "sp_select_SAREQDTL_check '" & gsCompany & "','" & rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_reqno") & "','" & rs_SAREQDTL.Tables("RESULT").Rows(Current_Row).Item("srd_reqseq") & "','" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00001 sp_select_SAREQDTL_check : " & rtnStr)
            Else
                If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then       '***  Not Found Record
                    itmNo = rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_itmno")
                    colcde = rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_colcde")
                End If
            End If

            gspStr = "sp_select_SAORDSUM_deduct '" & gsCompany & "','" & rs_SAREQHDR.Tables("RESULT").Rows(0).Item("srh_cus1no") & "','" & itmNo & "','" & colcde & "','" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00001 sp_select_SAORDSUM_deduct : " & rtnStr)
            Else
                If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then       '***  Not Found Record
                    If rs_SAORDSUM.Tables("RESULT").Rows(0).Item("sas_osqty") < Val(txtCusQty.Text) Then
                        MsgBox("The Sample Request can't be cancelled, because some of samples have been shipped already.") 'msg("M00423")
                        chkCancel.Checked = False
                        'cancel_Click_Count = cancel_Click_Count - 1
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtEngDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngDsc.Enter
        'txtEngDsc.Height = txtEngDsc.Height + 20
    End Sub

    Private Sub txtEngDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngDsc.Leave
        ' txtEngDsc.Height = txtEngDsc.Height - 20
    End Sub

    Private Sub txtChnDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnDsc.Enter
        ' txtChnDsc.Height = txtChnDsc.Height + 20
    End Sub

    Private Sub txtChnDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnDsc.Leave
        ' txtChnDsc.Height = txtChnDsc.Height - 20
    End Sub

    Private Sub cboSalRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalRep.Click
        Recordstatus = True
    End Sub

    Private Sub cboSalRep_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalRep.Leave
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboSalRep.Items.Count
        If cboSalRep.Text <> "" And cboSalRep.Enabled = True And cboSalRep.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboSalRep.Text = cboSalRep.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Sales Rep - Data is Invalid, please select in Drop Down List.") 'msg("M00402")
                Me.TabPageMain.SelectedIndex = 0
                If cboSalRep.Enabled Then
                    cboSalRep.Focus()
                End If
                Exit Sub
            End If
        End If

        If cboSalRep.Text <> "" And cboSalRep.Items.Count <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboSalRep.Text = ""
            If cboSalRep.Enabled Then
                cboSalRep.Focus()
            End If
            Exit Sub
        End If
    End Sub
    Public Function check_Header() As Boolean
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        check_Header = True
        i = cboSalRep.Items.Count
        If cboSalRep.Text <> "" And cboSalRep.Enabled = True And cboSalRep.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboSalRep.Text = cboSalRep.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Sales Rep - Data is Invalid, please select in Drop Down List.") 'msg("M00402")  
                Me.TabPageMain.SelectedIndex = 0
                If cboSalRep.Enabled Then
                    cboSalRep.Focus()
                End If
                check_Header = False
                Exit Function
            End If
        End If

        If cboSalRep.Text <> "" And cboSalRep.Items.Count <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboSalRep.Text = ""
            If cboSalRep.Enabled Then
                cboSalRep.Focus()
            End If
            check_Header = False
            Exit Function
        End If

    End Function

    Private Sub cboVenCtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCtp.Click
        Recordstatus = True
    End Sub


    Private Sub chkCancelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCancelAll.Click
        'added by tommy on 12 nov 2002
        'Dim tmp_post As Integer
        Dim tmp_count As Integer
        Dim tmp_message As String
        tmp_message = ""
        If chkCancelAll.Checked = True Then
            'tmp_post = rs_SAREQDTL.AbsolutePosition
            'Kenny Add on 25-11-2002
            'tmp_count = rs_SAREQDTL.RecordCount
            tmp_count = 0
            'chkCancel.Value = 1
            'rs_SAREQDTL.MoveFirst()
            'MsgBox(rs_SAREQDTL.Tables("RESULT").Rows.Count)
            For i As Integer = 0 To rs_SAREQDTL.Tables("RESULT").Rows.Count - 1
                If rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_canflg") = "N" Then

                    If check_CancelAll(i) = True Then
                        tmp_message = tmp_message + IIf(Len(tmp_message) = 0, Str(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqseq")), ", " + Str(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqseq")))
                        tmp_count = tmp_count + 1
                    End If
                End If
            Next

            'rs_SAREQDTL.MoveFirst()
            'rs_SAREQDTL.Move(tmp_post - 1)
            'Kenny Add on 25-11-2002

            If tmp_count = rs_SAREQDTL.Tables("RESULT").Rows.Count Then
                chkCancelAll.Checked = False
            End If


            If tmp_message <> "" Then
                MsgBox("Seq " + tmp_message + " cannot be cancel, because some of samples have been shipped already.", vbInformation, "Warning")
            Else
                MsgBox("Some detail lines have been marked Cancel. If you want to rollback, please press Clear.", vbInformation, "Information")
                If Me.TabPageMain.SelectedIndex = 2 Then
                    Me.TabPageMain.SelectedIndex = 0
                    Me.TabPageMain.SelectedIndex = 2
                End If
            End If
            'Lester Wu 2004/03/26
            Call Display_Detail()
        Else
            'MsgBox "It will not change back the cancel flag in detail informaion.", vbInformation, "Information"
        End If
    End Sub
    Private Function check_CancelAll(ByVal i As Integer) As Boolean
        Dim itmNo As String = ""
        Dim colcde As String = ""
        gspStr = "sp_select_SAREQDTL_check '" & gsCompany & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqno") & "','" & rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqseq") & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_SAREQDTL_check : " & rtnStr)
        Else
            If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then

                itmNo = rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_itmno")
                colcde = rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_colcde")
            End If
        End If


        rs_SAREQDTL.Tables("RESULT").Columns("srd_canflg").ReadOnly = False
        rs_SAREQDTL.Tables("RESULT").Columns("mode").ReadOnly = False

        gspStr = "sp_select_SAORDSUM_deduct '" & gsCompany & "','" & rs_SAREQHDR.Tables("RESULT").Rows(0).Item("srh_cus1no") & "','" & itmNo & "','" & colcde & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_SAORDSUM_deduct : " & rtnStr)
        Else
            If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then
                If rs_SAORDSUM.Tables("RESULT").Rows(0).Item("sas_osqty") < rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_cusqty") Then
                    check_CancelAll = True
                    rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_canflg") = "N"
                    rs_SAREQDTL.Tables("RESULT").Rows(i).Item("mode") = "UPD"
                Else
                    check_CancelAll = False
                    rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_canflg") = "Y"
                    rs_SAREQDTL.Tables("RESULT").Rows(i).Item("mode") = "UPD"
                    'Cancel_Click = True
                    If Not IsDBNull(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel")) Then
                        If rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel") = "N" Then
                            cancel_Click_Count = cancel_Click_Count + 1
                        End If
                    End If

                End If
            End If
        End If

    End Function


    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged
        'Dim current_pos As Integer
        Dim i As Integer
        If Not rs_SAREQDTL Is Nothing Then
            If PreviousTab = 1 Then
                Call check_update_Detail()
                Call fill_SAREQDTL()
            End If

            If Me.TabPageMain.SelectedIndex = 1 Then

                'If rs_SAREQDTL.AbsolutePosition <> 1 Then
                '    Me.CmdBackD.Enabled = True
                'Else
                '    Me.CmdBackD.Enabled = False
                'End If
                'If rs_SAREQDTL.AbsolutePosition <> rs_SAREQDTL.recordCount Then
                '    Me.CmdNextD.Enabled = True
                'Else
                '    Me.CmdNextD.Enabled = False
                'End If
                'If PreviousTab = 2 Then
                '    Current_Row = selectedRow
                'End If


                checkBackNext()
                Call Display_Detail()




            ElseIf Me.TabPageMain.SelectedIndex = 2 Then
                If rs_SAREQDTL.Tables("RESULT").Rows.Count > 0 Then
                    'current_pos = rs_SAREQDTL.AbsolutePosition
                    'rs_SAREQDTL.MoveFirst()
                    For i = 0 To rs_SAREQDTL.Tables("RESULT").Rows.Count - 1
                        rs_SAREQDTL.Tables("RESULT").Columns("cancel").ReadOnly = False
                        If IsDBNull(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel")) Then
                            rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel") = ""
                        End If
                        rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel") = IIf(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("cancel") = "Y", "Y", IIf(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_canflg") = "Y", "Y", "N"))
                        'rs_SAREQDTL.MoveNext()
                    Next
                    'If current_pos > 0 Then
                    'rs_SAREQDTL.AbsolutePosition = current_pos
                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub TabPageMain_Deselected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabPageMain.Deselected
        PreviousTab = e.TabPageIndex
    End Sub

    Private Sub txtReqNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReqNo.Enter
        HighlightText(txtReqNo)
    End Sub
    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub SAM00001_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.PageUp And Me.TabPageMain.SelectedIndex = 1 And CmdBackD.Enabled = True Then
            Call CmdBackD_Click(Me, e)
            'KeyCode = 0
        ElseIf e.KeyCode = Keys.PageDown And Me.TabPageMain.SelectedIndex = 1 And CmdNextD.Enabled = True Then
            Call CmdNextD_Click(Me, e)
            'KeyCode = 0
        End If
    End Sub
    '    If e.KeyChar.Equals(Chr(13)) Then
    '    Call cmdFind_Click(sender, e)
    'End If

    Private Sub SAM00001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If (e.Alt) Then
            If e.KeyCode = Keys.D1 Then
                Me.TabPageMain.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 Then
                Me.TabPageMain.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.D3 Then
                Me.TabPageMain.SelectedIndex = 2
            End If
        End If
    End Sub


    Private Sub grdSummary_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellEnter
        If e.RowIndex >= 0 Then
            Dim dr() As DataRow = rs_SAREQDTL.Tables("RESULT").Select("", "srd_reqseq")
            For index As Integer = 0 To dr.Length - 1
                If rs_SAREQDTL.Tables("RESULT").DefaultView(e.RowIndex)("srd_reqseq") = dr(index)("srd_reqseq") Then
                    Current_Row = index
                End If
            Next
        End If
    End Sub



    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtReqNo.Name
        frmSYM00018.strModule = "SR"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub cboSalTem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalTem.SelectedIndexChanged

    End Sub

    Private Sub cboSalTem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalTem.Validated
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

        txtSalMgt.Text = ""
        txtSalDiv.Text = ""
        cboSalRep.Text = ""
        cboSalRep.Items.Clear()


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



        If cboSalTem.Text <> "" Then
            If Split(cboSalTem.Text, " - ")(1) <> "" Then

                gspStr = "sp_list_SYUSRPRF_2 '','" & Split(cboSalTem.Text, " - ")(0) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cboSalTem_LostFocus sp_list_SYUSRPRF_2 :" & rtnStr)
                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If





            End If

            If Not rs_SYUSRPRF_2.Tables("RESULT").Rows.Count = 0 Then
                For i = 0 To rs_SYUSRPRF_2.Tables("RESULT").Rows.Count - 1
                    cboSalRep.Items.Add(rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("ssr_salrep") + " - " + rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("yup_repnam"))
                    'txtSalMgt.Text = UCase(rs_SYSALMGR.Tables("RESULT").Rows(0).Item("yup_usrnam"))
                Next i
                cboSalRep.SelectedIndex = 0
                txtSalMgt.Text = UCase(rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("yup_mgrnam"))
                txtSalDiv.Text = rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("ssr_saldiv") + " - Division " + rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("ssr_saldiv").ToString
            End If


        End If
    End Sub

     
End Class