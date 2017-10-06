Public Class SAM00003

    Dim grdsumvalue As Integer
    Dim tmp_current_row As Integer
    Dim IsValaidcboitm As Boolean = True
    Dim rs_SYSALINF As New DataSet
    Dim SERVER_DATE As Date
    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Dim EditModeHdr As String
    Dim CanModify As Boolean ' Check for access right
    Dim Current_TimeStamp As Long 'For current record's time stamp
    Dim Trigger_Chgqty As Boolean
    Dim Trigger_ShpQty As Boolean
    Public gsNetAmtPct As Double
    Public gsPrdTrm As Double
    Public mLength_in As Double
    Public mwidth_in As Double
    Public mheight_in As Double
    Public mLength_cm As Double
    Public mwidth_cm As Double
    Public mheight_cm As Double
    Public l As String
    Public H As String
    Public W As String
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    '*** Folder 1
    Public rs_SAINVHDR As DataSet
    Public rs_CUAGTINF As DataSet
    Public rs_SYSALREP As DataSet
    Public rs_CUBASINF_P As DataSet
    Public rs_CUBASINF_S As DataSet
    Public rs_CUCNTINF As DataSet
    Public rs_CUCNTINF_Adr As DataSet
    Public rs_CUBASINF_CR As DataSet
    Public rs_CUBASINF_CP As DataSet
    Public cus1no As String
    Private rs_SYSETINF As DataSet
    '*** Folder 2
    Public rs_SAINVDTL As DataSet
    Public rs_SAORDSUM As DataSet
    Public rs_SAORDSUM_F As DataSet
    Public rs_SAORDDTL As DataSet
    Public rs_SAREQASS As DataSet
    Dim rs_tmp As DataSet
    Public flg_DisplaySampleHeaderData As Boolean
    Public flg_DisplaySampleDetailData As Boolean
    Public current_Row As Integer

    Dim rs_SAINVDTL_del As DataSet
    Dim rs_SAINVDTL_ins As DataSet
    Dim rs_SAINVDTL_upd As DataSet

    Dim rs_SACTNDIM_del As DataSet
    Dim rs_SACTNDIM_ins As DataSet
    Dim rs_SACTNDIM_upd As DataSet

    '*** Folder 3
    Public rs_SACTNDIM As DataSet
    Public flg_DisplayCTNDIMData As Boolean
    Dim Add_flag As Boolean     '*** Check for Add Record
    Dim save_ok As Boolean
    Dim Recordstatus As Boolean '*** Check the Current record is modified or not
    '*** This flag must used in each fields of the Screen
    Dim Grid_Got_Focus As String '*** Grid focus
    Dim flag_cat_err As Boolean '*** For Catgory grd
    Dim Col_Position As Integer '*** For grd Control
    Dim VendorType As String
    Public Recordstatus_Dtl As Boolean
    Dim rs_SERVER_DATE As DataSet
    'REMARK
    'Public sampleFreeQty As Integer
    'Public orgShpFreeDiff As Integer
    'Public orgShpQty As Integer
    'Public orgChgQty As Integer
    Public sampleFreeQty As Long
    Public orgShpFreeDiff As Long
    Public orgShpQty As Long
    Public orgChgQty As Long
    Public clearClick As Boolean
    ' Added by Mark Lau 20090811
    Public strCurExRat As String
    Public strCurExEffDat As String
    '**************Carlos Lui added on 20120922***********
    Dim sImu_cus1no As String
    Dim sImu_cus2no As String
    Dim sImu_hkprctrm As String
    Dim sImu_ftyprctrm As String
    Dim sImu_trantrm As String
    Dim dImu_effdat As Date
    Dim dImu_expdat As Date
    '**************Carlos Lui added on 20120922***********

    Dim selectedRow As Integer
    Dim PreviousTab As Integer
    Dim selectedSeq As Integer

    Public rs_SYUSRRIGHT_Check As New DataSet
    Dim rs_SYUSRPRF_2 As DataSet
    Dim rs_SYSALREP_2 As DataSet
    Dim rs_SYSALINF2 As DataSet

    Private Sub SAM00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)
        'AccessRight (Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        'AccessRight_1 (Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001 Change by Lewis on 2 Jul 2003
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        'Timer1.Enabled = False


        '#If useMTS Then
        '    Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'For Each v As Control In Me.Controls
        '    If IsInputBoxes(v) Then
        '        v.BackColor = Color.Gray ' Gray color
        '    End If
        'Next



        'If gsCompany = "UCP" Then
        '    Label37.Caption = "Sample Factory Cost"
        'Else
        '    Label37.Caption = "Sample Factory Price"
        'End If
        lblFtyPrc.Text = "Sample Cost"

        'If gsFlgCst = 1 Then
        '    Label37.Visible = True
        '    txtFCurCde.Visible = True
        '    txtFtyPrc.Visible = True
        'Else
        '    Label37.Visible = False
        '    txtFCurCde.Visible = False
        '    txtFtyPrc.Visible = False
        'End If

        If VendorType = "E" Then
            If gsFlgCst = 1 Then
                lblFtyPrc.Visible = True
                txtFCurCde.Visible = True
                txtFtyPrc.Visible = True
            Else
                lblFtyPrc.Visible = False
                txtFCurCde.Visible = False
                txtFtyPrc.Visible = False
            End If
        Else
            If gsFlgCstExt = 1 Then
                lblFtyPrc.Visible = True
                txtFCurCde.Visible = True
                txtFtyPrc.Visible = True
            Else
                lblFtyPrc.Visible = False
                txtFCurCde.Visible = False
                txtFtyPrc.Visible = False
            End If
        End If

        '*** Folder 1   **********
        txtInvNo.MaxLength = 20

        txtCus1Ad.MaxLength = 200
        txtCus1St.MaxLength = 20
        txtCus1Zp.MaxLength = 20

        txtCus2Ad.MaxLength = 200
        txtCus2St.MaxLength = 20
        txtCus2Zp.MaxLength = 20

        txtCourier.MaxLength = 80
        txtDocNo.MaxLength = 200

        txtShpRmk.MaxLength = 600
        txtRmk.MaxLength = 600
        txtHdrRmk.MaxLength = 600


        cboInvSts.Items.Add("OPE - Open")
        cboInvSts.Items.Add("REL - Released")
        cboInvSts.Items.Add("CLO - Close")
        cboInvSts.Items.Add("CAN - Cancel")
        cboInvSts.Items.Add("HLD - Waiting for Approval")

        '*** Folder 2   **********
        txtInvSeq.MaxLength = 6
        txtCusItm.MaxLength = 20
        txtCusSmpPo.MaxLength = 50
        txtItmDsc.MaxLength = 800
        txtCusCol.MaxLength = 30
        txtColDsc.MaxLength = 300
        txtUntCdeD.MaxLength = 6
        txtInrQty.MaxLength = 6
        txtMtrQty.MaxLength = 6
        txtCft.MaxLength = 10

        txtSmpUnt.MaxLength = 6
        txtShpQty.MaxLength = 6
        txtBalFreQty.MaxLength = 6
        txtChgQty.MaxLength = 6

        txtSelPrcD.MaxLength = 12
        txtUntCdeD.MaxLength = 6
        txtTtlAmtD.MaxLength = 12

        ''****** Fill Combo box Move out to fillParameter ************
        Call fillParameter()

        ''*** Folder 3   **********
        gspStr = "sp_select_SERVER_DATE '" & gsCompany & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SERVER_DATE, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 rs_SERVER_DATE : " & rtnStr)
        Else
            If rs_SERVER_DATE.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else

                SERVER_DATE = Format(rs_SERVER_DATE.Tables("RESULT").Rows(0).Item("SERVER_DATE"), "MM/dd/yyyy")
                '    SERVER_DATE = Format(rs_SERVER_DATE(0), "MM/DD/YYYY")
            End If
        End If

        ''**************************************************************
        ''*** Fill Combo box End ***************************************
        ''**************************************************************

        ''**************************************************************
        ''*** Fill List box      ***************************************
        ''**************************************************************

        ''**************************************************************
        ''*** Fill List box END  ***************************************
        ''**************************************************************

        ''***Get the Current User's access right form the DB
        ''    If (DB Value = CanModify) Then  'Get the Value from Database
        CanModify = True
        ''    Else
        ''        CanModify = False
        ''    End If

        Me.KeyPreview = True

        setStatus("Init")

        Formstartup(Me.Name)   'Set the form Sartup position

        Me.Cursor = Windows.Forms.Cursors.Default

        ''If gsUsrGrp = "MGT-S" Then
        ''    chkDiCoTi.Visible = True
        ''Else
        ''    chkDiCoTi.Visible = False
        ''End If

        clearClick = False
        txtInvNo.Select()
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
    Private Sub FillcboSalRep(ByVal Team As String)


        gspStr = "sp_select_CUBASINF_SR2 '','" & Team & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP_2, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 FillcboSalRep : " & rtnStr)
        Else
            If rs_SERVER_DATE.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else

                Dim i As Integer
                Dim strList As String
                cboSalRep.Items.Clear()
                If rs_SYSALREP_2.Tables("RESULT").Rows.Count > 0 Then
                    ' Added by Marco at 20040110 requested by Anita for sorting in sales Team and Sales Rep Name



                    For i = 0 To rs_SYSALREP_2.Tables("RESULT").Rows.Count - 1
                        strList = rs_SYSALREP_2.Tables("RESULT").Rows(i).Item("dsc")
                        'cboSalRep.AddItem(Trim(rs_SYSALREP("ysr_dsc") + " (Team " + rs_SYSALREP("ysr_saltem") + " )" + " - " + rs_SYSALREP("ysr_code1")))
                        If strList <> "" Then
                            cboSalRep.Items.Add(strList)
                        End If
                    Next i
                End If
            End If
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

    Private Sub fillParameter()
        '****************************************************************
        '*** Fill Combo box Start ***************************************
        '****************************************************************

        '*** Fill up Sales Rep combo box
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
        gspStr = "sp_list_SYSALREP '" & gsCompany & "'"
        'Marco Added for fixing global company code problem at 20040331
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_SYSALREP : " & rtnStr)
        Else
            If rs_SYSALREP.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else
                'Call fillSalRep '*** Fill up Price Terms combo box
            End If
        End If

        '*** For Primary Customer Combo Box

        'gspStr = "sp_select_CUBASINF_SAM00003_01 '" & gsCompany & "','" & gsSalTem & "','Primary'"
        gspStr = "sp_select_CUBASINF_PC '" & gsCompany & "','" & gsUsrID & "','QU','Primary'"       ' from quotation

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_CUBASINF_SAM00003_01 : " & rtnStr)
        Else
            If rs_CUBASINF_P.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else
                Call fillCus1No() '*** Fill up Currency combo box
            End If
        End If


        '*** For Secondary Customer Combo Box
        gspStr = "sp_list_CUBASINF_SAM00003_1 '" & gsCompany & "','S'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_CUBASINF_SAM00003_1 : " & rtnStr)
        End If


        '*** For Secondary Contact Person Box
        gspStr = "sp_list_CUCNTINF_SAM00003 '" & gsCompany & "','BUYR'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_CUCNTINF_SAM00003 : " & rtnStr)
        Else
            If rs_CUCNTINF.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else
                'Call fillCus2No '*** Fill up Currency combo box
            End If
        End If

        '2005/02/25 Lester Wu -- For Country
        gspStr = "sp_select_SYSETINF '" & gsCompany & "','02'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_SYSETINF : " & rtnStr)
        Else
            If rs_SYSETINF.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else
                Call fillBilCty() '*** Fill up Billing Country
            End If
        End If








    End Sub
    Private Sub fillCus1No()
        'Dim sFilter As String
        ' Marco added 20031028 start
        cboCus1No.Items.Clear()
        cboCus1No.Items.Add("")
        If Add_flag = True Then
            'sFilter = "cbi_cusno >= '50000'"
            Dim drCUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
            If Not drCUBASINF_P Is Nothing Then
                For i As Integer = 0 To drCUBASINF_P.Length - 1
                    'filter the discontinue and inactive customer 
                    If Not (drCUBASINF_P(i).Item("cbi_cussna").ToString.Contains("Discontinue") Or drCUBASINF_P(i).Item("cbi_cussna").ToString.Contains("Inactive")) Then
                        'MsgBox(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)

                        cboCus1No.Items.Add(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)
                    End If
                Next
            End If
        Else
            For i As Integer = 0 To rs_CUBASINF_P.Tables("RESULT").Rows.Count - 1
                cboCus1No.Items.Add(rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno").ToString & " - " & rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString)
            Next
        End If
        'Marco added 20031028 start
        'If Add_flag = True Then
        'sFilter = ""
        'rs_CUBASINF_P.Tables("RESULT").DefaultView.RowFilter = sFilter
        'End If
        'Marco added 20031028 end
    End Sub
    Private Sub fillBilCty()
        cboCus1Cy.Items.Clear()
        cboCus2Cy.Items.Clear()
        For i As Integer = 0 To rs_SYSETINF.Tables("RESULT").Rows.Count - 1
            cboCus1Cy.Items.Add(Trim(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde").ToString()) + " - " + Trim(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc").ToString()))
            cboCus2Cy.Items.Add(Trim(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde").ToString()) + " - " + Trim(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc").ToString()))
        Next
    End Sub
    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            SetInputBoxesStatus("DisableAll")
            mmdAdd.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            '************Carlos Lui changed on 20120921*************
            mmdCopy.Enabled = False
            '************Carlos Lui changed on 20120921*************
            mmdFind.Enabled = True
            'CmdLookup.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = False
            mmdSearch.Enabled = True
            'cmdspecial.Enabled = True
            'cmdbrowlist.Enabled = True


            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            Me.TabPageMain.SelectedIndex = 0
            gsNetAmtPct = 100

            chkApprove.Checked = False

            ResetDefaultDisp()
            SetStatusBar(Mode) 'Set Status bar
            '*** Enable key field(s) in header
            txtInvNo.Enabled = True

            cboCoCde.Enabled = True

            ' Added by Mark Lau 20090814
            strCurExRat = "0"
            strCurExEffDat = ""

            '***********Carlos Lui added on 20120922***********
            cmdBck.Enabled = False
            cmdNxt.Enabled = False
            txtPrcKey.Text = ""
            txtEffDat.Text = ""
            txtExpDat.Text = ""
            '***********Carlos Lui added on 20120922***********

            '***Reset the flag
            Recordstatus = False
            freeze_TabControl(-1)
            If txtInvNo.Enabled = True And txtInvNo.Visible = True Then
                txtInvNo.Focus()
            End If

            current_Row = 0
            cboPck.Items.Clear()



            '========================
            'Add your codes here
            rs_SAINVDTL = Nothing
        ElseIf Mode = "ADD" Then
            EditModeHdr = Mode 'Goble varible to show action
            InitGrid()
            release_TabControl()
            Call SetInputBoxesStatus("EnableAll")
            mmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            mmdDelete.Enabled = False
            mmdFind.Enabled = False
            mmdSearch.Enabled = False

            mmdAdd.Enabled = False
            cboCoCde.Enabled = False
            txtCoNam.Enabled = False

            ' Added by Mark Lau 20090814
            strCurExRat = "0"
            strCurExEffDat = ""

            'txtImgPath.Enabled = False
            'txtImgPath.Text = "\\UCPPHK6\ItemImg\"

            Call SetStatusSampleInvoiceHeader(Mode)
            Call SetStatusSampleInvoiceDetail()
            Call SetStatusCTNDIM()

            '***********Carlos Lui added on 20120924***********
            cmdBck.Enabled = False
            cmdNxt.Enabled = False
            '***********Carlos Lui added on 20120924***********

            grdCtnDim.DataSource = rs_SACTNDIM.Tables("RESULT").DefaultView
            Call DisplayCTNDIM()

            Call SetStatusBar(Mode)

            mmdInsRow.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            chkDel.Enabled = True 'Del_right_local
            cmdResetItem.Enabled = True
            'Add your codes here

        ElseIf Mode = "Updating" Then
            release_TabControl()
            SetInputBoxesStatus("EnableAll")

            If Split(cboInvSts.Text, " - ")(0) = "REL" Or Split(cboInvSts.Text, " - ")(0) = "CLO" Then 'Or Split(cboInvSts.Text, " - ")(0) = "HLD"
                mmdAdd.Enabled = False
                mmdSave.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdDelete.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdCopy.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdFind.Enabled = False
                mmdSearch.Enabled = False
                mmdInsRow.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdDelRow.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdExit.Enabled = True
                mmdClear.Enabled = True

            Else
                'If Split(cboInvSts.Text, " - ")(0) = "HLD" And gsUsRank <= 2 And gsUsrGrp = "MGT-S" Then
                If Split(cboInvSts.Text, " - ")(0) = "HLD" And gsUsrGrp = "MGT-S" Then
                    chkApprove.Enabled = True
                Else
                    chkApprove.Enabled = False
                End If

                mmdAdd.Enabled = False
                mmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001

                mmdDelete.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdCopy.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdFind.Enabled = False
                mmdSearch.Enabled = False

                mmdInsRow.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                mmdDelRow.Enabled = False
                chkDel.Enabled = True 'Del_right_local

                mmdExit.Enabled = True
                mmdClear.Enabled = True
            End If

            mmdPrint.Enabled = True
            txtInvNo.Enabled = False
            SetStatusSampleInvoiceHeader(Mode)
            SetStatusSampleInvoiceDetail()
            SetStatusCTNDIM()
            cboCoCde.Enabled = False
            txtCoNam.Enabled = False

            '***Reset the flag
            Recordstatus = False
            Call SetStatusBar(Mode)

            cmdResetItem.Enabled = False


        ElseIf Mode = "Save" Then
            MsgBox("Record Saved!")  'msg("M00025")
            Call SetStatusBar(Mode)
            Call setStatus("Init")
            'Add your codes here
        ElseIf Mode = "Delete" Then
            Call SetStatusBar(Mode)
            'Add your codes here
        ElseIf Mode = "Clear" Then
            Call setStatus("Init")
            Call ResetDefaultDisp() 'see'
            Call SetStatusBar(Mode)
            gsNetAmtPct = 100
            'txtVenNo.Focus()
        End If

        'Check for access right
        'If Not CanModify Then
        '    cmdAdd.Enabled = False
        '    cmdSave.Enabled = False
        '    cmdDelete.Enabled = False
        '    'CmdLookup.Enabled = False
        '    cmdInsRow.Enabled = False
        '    cmdDelRow.Enabled = False
        '    Call SetStatusBar("ReadOnly")
        'End If
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
                mmdSave.Enabled = False
                mmdDelete.Enabled = False

            ElseIf EditModeHdr = "Updating" Then
                mmdAdd.Enabled = False
            End If

            If Not CanModify Then   '*** Program Access right of user
                mmdAdd.Enabled = False
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                'CmdLookup.Enabled = False
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
            End If                  ' ********************************

            '*** (2) If Mode = "DisableAll", disable all controls
        ElseIf Mode = "DisableAll" Then
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = False
                End If
            Next
        End If
    End Sub
    Private Sub ResetDefaultDisp()

        flg_DisplaySampleHeaderData = True
        flg_DisplaySampleDetailData = True
        flg_DisplayCTNDIMData = True

        '********************
        '*** Folder 1 Shipping Header
        '********************

        txtSalDiv.Text = ""
        txtSalMgt.Text = ""
        cboSalTem.Items.Clear()
        cboSalTem.Text = ""


        chkApprove.Checked = False




        txtInvNo.Text = ""

        txtIssDat.Text = ""
        txtRvsDat.Text = ""

        'If cboCus1No.ListCount > 0 Then cboCus1No.ListIndex = 0
        'If cboCus2No.ListCount > 0 Then cboCus2No.ListIndex = 0
        'If cboInvSts.ListCount > 0 Then cboInvSts.ListIndex = 0
        If cboInvSts.Items.Count > 0 Then cboInvSts.SelectedIndex = 0
        'cboCus1No.ListIndex = 0

        txtCus1Ad.Text = ""
        txtCus1St.Text = ""
        '2005-02-25 Lester Wu -- use combobox instead of textbox
        'txtCus1Cy.Text = ""
        cboCus1Cy.Text = ""

        txtCus1Zp.Text = ""

        cboCus1No.Text = ""
        cboCus1Ad.Items.Clear()
        cboCus1Ad.Text = ""
        cboSalRep.Items.Clear()
        cboSalRep.Text = ""
        cboCus1Cp.Items.Clear()
        cboCus1Cp.Text = ""

        'cboCusAgt.ListIndex = 0
        'cboSalRep.ListIndex = 0

        txtSmpPrd.Text = ""
        txtSmpFgt.Text = ""
        txtCurCdeI.Text = ""

        cboCus2No.Items.Clear()
        cboCus2No.Text = ""
        txtCus2Ad.Text = ""
        txtCus2St.Text = ""
        '2005-02-25 Lester Wu -- use combobox instead of textbox
        'txtCus2Cy.Text = ""
        cboCus2Cy.Text = ""

        txtCus2Zp.Text = ""
        cboCus2Cp.Items.Clear()
        cboCus2Cp.Text = ""

        txtCourier.Text = ""

        optBL.Checked = True

        txtDocNo.Text = ""
        txtShpRmk.Text = ""
        txtRmk.Text = ""

        txtHdrRmk.Text = ""
        txtPrcTrm.Text = ""

        TxtTtlCtnI.Text = 0
        txtTtlAmtI.Text = 0
        txtNetAmtI.Text = 0
        txtDiscnt.Text = 0

        '********************
        '*** Folder 2 shipping detail
        '********************
        chkDel.Checked = False

        txtInvSeq.Text = ""
        cboItmCol.Items.Clear()
        cboItmCol.Text = ""

        cboTmpItmCol.Items.Clear()
        cboTmpItmCol.Text = ""

        cboVenItmCol.Items.Clear()
        cboVenItmCol.Text = ""

        txtCusItm.Text = ""
        txtCusSmpPo.Text = ""

        txtItmDsc.Text = ""

        cboPck.Items.Clear()
        cboPck.Text = ""

        txtCusCol.Text = ""
        txtColDsc.Text = ""
        txtColCde.Text = ""

        txtPckUnt.Text = ""
        txtInrQty.Text = 0
        txtMtrQty.Text = 0
        txtCft.Text = 0

        txtSmpUnt.Text = ""
        txtShpQty.Text = 0
        txtBalFreQty.Text = 0
        txtChgQty.Text = 0

        ' Marco added for init currency code parameter 20040202
        txtFCurCde.Text = ""
        txtCurCde1D.Text = ""
        txtCurCde2D.Text = ""
        ' Marco added for init currency code parameter 20040202

        txtSelPrcD.Text = 0
        txtTtlAmtD.Text = 0
        txtUntCdeD.Text = ""
        txtRmkD.Text = ""
        txtItmTyp.Text = ""

        txtFreQty.Text = 0
        txtOutShpQty.Text = 0
        txtOutChgQty.Text = 0
        txtOutFreQty.Text = 0

        txtOrgShpQty.Text = 0
        txtOrgChgQty.Text = 0
        txtOrgFreQty.Text = 0

        '*********Carlos Lui added on 20120921************
        txtPrcKey.Enabled = False
        txtEffDat.Enabled = False
        txtExpDat.Enabled = False
        '*********Carlos Lui added on 20120921************
        '********************
        '*** Folder 3 invoice header
        '********************

        '********************
        '*** Folder 4 Address
        '********************

        '********************
        '*** Folder 5 Address
        '********************

        rs_SAINVHDR = Nothing
        rs_CUBASINF_CR = Nothing
        rs_SAINVDTL = Nothing
        rs_SAORDSUM = Nothing
        rs_SAORDDTL = Nothing

        Me.StatusBar.Items("lblLeft").Text = ""
        Me.StatusBar.Items("lblRight").Text = ""

        'Reset other fields
        'Add codes here..........
        flg_DisplaySampleHeaderData = False
        flg_DisplaySampleDetailData = False
        flg_DisplayCTNDIMData = False
    End Sub
    Private Sub SetStatusBar(ByVal Mode As String)
        If Mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
            'Add your codes here

        ElseIf Mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "ADD"
            'Add your codes here

        ElseIf Mode = "Updating" And mmdSave.Enabled = True Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
            'Add your codes here

        ElseIf Mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
            'Add your codes here

        ElseIf Mode = "Delete" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Deleted"
            'Add your codes here

        ElseIf Mode = "ReadOnly" Or mmdSave.Enabled = False Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
            'Add your codes here

        ElseIf Mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
            'Add your codes here
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

    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        '*** perform query on database after user input an item number

        If (Trim(txtInvNo.Text) = "") Then
            If txtInvNo.Enabled Then
                txtInvNo.Focus()
            End If
            MsgBox("Invoice No. empty")
            Exit Sub
        End If

        'Marco Added for fixing global company code problem at 20040331
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)



        ''*** query item master header

        gspStr = "sp_select_SAINVHDR '" & gsCompany & "','" & txtInvNo.Text & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAINVHDR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_SAINVHDR : " & rtnStr)
        Else
            If rs_SAINVHDR.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("Sample Invoice no. not found")
                If txtInvNo.Enabled Then
                    txtInvNo.Focus()
                End If
                txtInvNo.SelectionStart = 0
                txtInvNo.SelectionLength = Len(txtInvNo.Text)
                Exit Sub
            ElseIf gsSalTem <> rs_SAINVHDR.Tables("RESULT").Rows(0).Item("ysr_saltem").ToString And gsSalTem <> "" And gsSalTem <> "S" Then
                gspStr = "sp_select_SYUSRRIGHT_Check '" & cboCoCde.Text & "','" & gsUsrID & "','" & txtQutNo.Text & "','" & "QU" & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFind_Click sp_select_SYUSRRIGHT_Check :" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("You have no Right access this document.")
                    Me.Cursor = Windows.Forms.Cursors.Default
                    Exit Sub
                End If
            End If


            Add_flag = False
            Current_TimeStamp = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_timstp") '*** Store timestamp when executing Select statement
            '***************************************************
            '*** Get Sample Invoice Detail record  *************
            '***************************************************

            gspStr = "sp_list_SAINVDTL2 '" & gsCompany & "','" & txtInvNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAINVDTL, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_list_SAINVDTL2 : " & rtnStr)
            End If
            '***************************************************
            '*** Get Sample Order Summary record      **********
            '***************************************************

            gspStr = "sp_list_SAORDSUM2 '" & gsCompany & "','" & rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1no").ToString & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_list_SAORDSUM2 : " & rtnStr)
            End If
            '***************************************************
            '*** Get Sample Order Summary record  end **********
            '***************************************************

            '***************************************************
            '*** Get Carton Dimension record   *****************
            '***************************************************


            gspStr = "sp_list_SACTNDIM '" & gsCompany & "','" & txtInvNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SACTNDIM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_list_SACTNDIM : " & rtnStr)
            End If
            '***************************************************
            '*** Get Carton Dimension record end ***************
            '***************************************************

            '*** Get Currency Exchange Rate



            gspStr = "sp_select_CUBASINF_P '" & gsCompany & "','Currency Rate'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CR, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_select_CUBASINF_P : " & rtnStr)
            ElseIf rs_CUBASINF_CR.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Currency in System.")
            End If

            gspStr = "sp_list_SYSALINF_CU ''"
            rtnLong = execute_SQLStatement(gspStr, rs_SYSALINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_SYSALINF_CU :" & rtnStr)
                Exit Sub
            End If





            Call Display()

            '*** Sales Rep for Primary Customer
            'gspStr = "sp_select_CUBASINF_SR_refresh '" & gsCompany & "','" & rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_salrep") & "','" & rs_SAINVHDR.Tables("RESULT").Rows(0).Item("cbi_salrep") & "','" & gsUsrID & "'"

            'Me.Cursor = Windows.Forms.Cursors.WaitCursor
            'rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
            'Me.Cursor = Windows.Forms.Cursors.Default
            'If rtnLong <> RC_SUCCESS Then
            '    MsgBox("Error on loading SAM00003 sp_select_CUBASINF_SR_refresh : " & rtnStr)
            'ElseIf rs_SYSALREP.Tables("RESULT").Rows.Count = 0 Then
            '    cboSalRep.Enabled = False
            'Else
            '    cboSalRep.Enabled = True
            '    cboSalRep.Items.Clear()
            '    Dim matchRow As Integer
            '    For i As Integer = 0 To rs_SYSALREP.Tables("RESULT").Rows.Count - 1
            '        cboSalRep.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(i).Item("dsc"))
            '        If rs_SYSALREP.Tables("RESULT").Rows(i).Item("ysr_code1") = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("cbi_salrep") Then
            '            matchRow = i
            '        End If
            '    Next
            '    'Dim s As String = "primaryKeyValue"
            '    'Dim foundRow As DataRow = DataSet1.Tables("AnyTable").Rows.Find(s)
            '    flg_DisplaySampleHeaderData = True
            '    cboSalRep.Text = rs_SYSALREP.Tables("RESULT").Rows(matchRow).Item("dsc")
            '    flg_DisplaySampleHeaderData = False
            'End If


            flg_DisplaySampleHeaderData = True
            ' display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_salrep"), cboSalRep)
            flg_DisplaySampleHeaderData = False

            Call setStatus("Updating")

        End If
        'Summary Page test
        grdSummary.DataSource = rs_SAINVDTL.Tables("RESULT").DefaultView
        Display_Summary()
    End Sub

    Private Sub txtInvNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call mmdFind_Click(sender, e)
        End If
    End Sub
    Private Sub Display()


        '*** Folder 1
        Call DisplaySampleInvoiceHeader()
        'Call SetStatusSampleInvoiceHeader("***")

        '*** Folder 2
        If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
            Call DisplaySampleInvoiceDetail()
            Call SetStatusSampleInvoiceDetail()
        End If

        ''*** Folder 3
        grdCtnDim.DataSource = rs_SACTNDIM.Tables("RESULT").DefaultView
        Grid_Got_Focus = "grdCtnDim"
        Call DisplayCTNDIM()
        Call SetStatusCTNDIM()

        Me.StatusBar.Items("lblRight").Text = Format(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("Sih_credat"), "MM/dd/yyyy") & " " & Format(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("Sih_upddat"), "MM/dd/yyyy") & _
                                  " " & rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_updusr").ToString
    End Sub


    Private Sub DisplaySampleInvoiceHeader()
        flg_DisplaySampleHeaderData = True
        txtInvNo.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_InvNo").ToString
        txtIssDat.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_issdat").ToString
        txtRvsDat.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_rvsdat").ToString
        display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_invsts"), cboInvSts)
        display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1no"), cboCus1No)
        fillCus2No(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1no").ToString)
        display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2no"), cboCus2No)
        txtCus1Ad.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1ad").ToString
        txtCus1St.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1st").ToString
        cboCus1Cy.Text = IIf((rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1cy")) Is Nothing, "", rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1cy").ToString)
        txtCus1Zp.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1zp").ToString
        fillCus1Cp(GetCtrlValue(cboCus1No))
        display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus1cp").ToString, cboCus1Cp)
        txtCus2Ad.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2ad").ToString
        txtCus2St.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2st").ToString
        cboCus2Cy.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2cy").ToString
        txtCus2Zp.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2zp").ToString
        fillCus2Cp(GetCtrlValue(cboCus2No))
        display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2cp").ToString, cboCus2Cp)
        display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cusagt").ToString, cboCusAgt)
        display_combo(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_salrep").ToString, cboSalRep)
        txtSmpPrd.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_smpprd").ToString
        txtSmpFgt.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_smpfgt").ToString
        txtCurCdeI.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_curcde").ToString
        txtTtlAmtI.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_ttlamt").ToString
        txtDiscnt.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_discnt").ToString
        gsNetAmtPct = 100 - rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_discnt").ToString
        txtNetAmtI.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_netamt").ToString
        TxtTtlCtnI.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_ttlctn").ToString
        txtCourier.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_courier").ToString
        If optBL.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_doctyp").ToString Then optBL.Checked = True
        If optFCR.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_doctyp").ToString Then optFCR.Checked = True
        If optAWB.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_doctyp").ToString Then optAWB.Checked = True
        txtDocNo.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_docno").ToString
        txtShpRmk.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_shprmk").ToString
        txtRmk.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_rmk").ToString
        txtHdrRmk.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_hdrrmk").ToString
        txtPrcTrm.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_prctrm").ToString
        strCurExRat = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_curexrat").ToString
        strCurExEffDat = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_curexeffdat").ToString
        FillcboSalTem()
        fillItmCol()



        Dim team As String = Split(Split(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_saltem").ToString, ")")(0), "Team ")(1)
        Dim strList As String
        Dim i As Integer
        gspStr = "sp_list_SYUSRPRF_2 '','" & team & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DisplaySampleInvoiceHeader sp_list_SYUSRPRF_2 :" & rtnStr)
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

        'rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_saltem").ToString <> " - Team "
        cboSalTem.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_saltem").ToString
        cboSalRep.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_srname").ToString

        'If rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_saldiv").ToString <> "" And _
        ' rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_saldiv").ToString <> "  - Division  " And _
        ' rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_saldiv").ToString <> " - Division " Then
        '    txtSalDiv.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_saldiv").ToString
        'Else
        '    txtSalDiv.Text = ""
        'End If

        'txtSalMgt.Text = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_salmgt").ToString




        flg_DisplaySampleHeaderData = False
    End Sub
    Private Sub release_TabControl()
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            Me.TabPageMain.TabPages(i).Enabled = True
        Next i
    End Sub
    Private Sub SetStatusSampleInvoiceHeader(ByVal Mode As String)
        If Mode = "Updating" Then
            If GetCtrlValue(cboInvSts) = "REL" Or Split(cboInvSts.Text, " - ")(0) = "CLO" Then 'Or GetCtrlValue(cboInvSts) = "HLD"

                chkApprove.Enabled = False
                txtInvNo.Enabled = False
                txtIssDat.Enabled = False
                txtRvsDat.Enabled = False
                cboInvSts.Enabled = False
                cboCus1No.Enabled = False
                txtCus1Ad.Enabled = True
                txtCus1Ad.ReadOnly = True
                txtCus1St.Enabled = False
                cboCus1Cy.Enabled = False
                txtCus1Zp.Enabled = False
                cboCus1Cp.Enabled = False
                cboCusAgt.Enabled = False
                cboSalRep.Enabled = False
                txtSmpPrd.Enabled = False
                txtSmpFgt.Enabled = False
                cboCus2No.Enabled = False
                If rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2no") = "" Then
                    txtCus2Ad.Enabled = False
                Else
                    txtCus2Ad.Enabled = True
                    txtCus2Ad.ReadOnly = True
                End If

                txtCus2St.Enabled = False
                cboCus2Cy.Enabled = False
                txtCus2Zp.Enabled = False
                cboCus2Cp.Enabled = False
                txtCourier.Enabled = True
                txtCourier.ReadOnly = True
                optBL.Enabled = False
                optFCR.Enabled = False
                optAWB.Enabled = False
                txtDocNo.Enabled = True
                txtShpRmk.Enabled = True
                txtRmk.Enabled = True
                txtCurCdeI.Enabled = False
                txtTtlAmtI.Enabled = False
                txtDiscnt.Enabled = False
                txtNetAmtI.Enabled = False
                TxtTtlCtnI.Enabled = False
                txtHdrRmk.Enabled = True
                txtPrcTrm.Enabled = False
            Else
                txtInvNo.Enabled = False
                txtIssDat.Enabled = False
                txtRvsDat.Enabled = False
                cboInvSts.Enabled = False
                cboCus1No.Enabled = False
                txtCus1Ad.Enabled = True
                txtCus1Ad.ReadOnly = False
                txtCus1St.Enabled = True
                cboCus1Cy.Enabled = True
                txtCus1Zp.Enabled = True
                cboCus1Cp.Enabled = True
                cboCusAgt.Enabled = False
                cboSalRep.Enabled = True
                txtSmpPrd.Enabled = False
                txtSmpFgt.Enabled = False
                cboCus2No.Enabled = False

                If rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2no") = "" Or (rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_cus2no") Is Nothing) Then
                    txtCus2Ad.Enabled = False
                    txtCus2St.Enabled = False
                    cboCus2Cy.Enabled = False
                    txtCus2Zp.Enabled = False
                Else
                    txtCus2Ad.Enabled = True
                    txtCus2Ad.ReadOnly = False
                    txtCus2St.Enabled = True
                    cboCus2Cy.Enabled = True
                    txtCus2Zp.Enabled = True
                End If

                cboCus2Cp.Enabled = True
                txtCourier.Enabled = True
                txtCourier.ReadOnly = False
                optBL.Enabled = True
                optFCR.Enabled = True
                optAWB.Enabled = True
                txtDocNo.Enabled = True
                txtShpRmk.Enabled = True
                txtRmk.Enabled = True
                txtCurCdeI.Enabled = False
                txtTtlAmtI.Enabled = False
                txtDiscnt.Enabled = True
                txtNetAmtI.Enabled = False
                TxtTtlCtnI.Enabled = False
                txtHdrRmk.Enabled = True
                txtPrcTrm.Enabled = False
            End If
        ElseIf Mode = "ADD" Then
            txtInvNo.Enabled = False
            txtIssDat.Enabled = False
            txtRvsDat.Enabled = False
            cboInvSts.Enabled = False
            cboCus1No.Enabled = True
            txtCus1Ad.Enabled = True
            txtCus1Ad.ReadOnly = False
            txtCus1St.Enabled = True
            cboCus1Cy.Enabled = True
            txtCus1Zp.Enabled = True
            cboCus1Cp.Enabled = True
            cboCusAgt.Enabled = True
            cboSalRep.Enabled = True
            txtSmpPrd.Enabled = False
            txtSmpFgt.Enabled = False
            cboCus2No.Enabled = True
            txtCus2Ad.Enabled = False
            txtCus2St.Enabled = False
            cboCus2Cy.Enabled = False
            txtCus2Zp.Enabled = False
            cboCus2Cp.Enabled = True
            txtCourier.Enabled = True
            optBL.Enabled = True
            optFCR.Enabled = True
            optAWB.Enabled = True
            txtDocNo.Enabled = True
            txtShpRmk.Enabled = True
            txtRmk.Enabled = True
            txtCurCdeI.Enabled = False
            txtTtlAmtI.Enabled = False
            txtDiscnt.Enabled = True
            txtNetAmtI.Enabled = False
            TxtTtlCtnI.Enabled = False
            txtHdrRmk.Enabled = True
            txtPrcTrm.Enabled = False
        End If
    End Sub
    Private Sub SetStatusSampleInvoiceDetail()
        Dim i As Integer = current_Row

        If rs_SAINVDTL.Tables("RESULT").Rows.Count <= 0 Or GetCtrlValue(cboInvSts) = "REL" Or Split(cboInvSts.Text, " - ")(0) = "CLO" Then  'Or GetCtrlValue(cboInvSts) = "HLD"
            chkDel.Enabled = False

            txtInvSeq.Enabled = False

            cboItmCol.Enabled = False
            cboTmpItmCol.Enabled = False
            cboVenItmCol.Enabled = False


            txtCusItm.Enabled = True
            txtCusItm.ReadOnly = True
            txtCusSmpPo.Enabled = True
            txtCusSmpPo.ReadOnly = True
            txtItmDsc.Enabled = True

            cboPck.Enabled = False

            txtCusCol.Enabled = True
            txtColDsc.Enabled = True
            txtColDsc.ReadOnly = True

            txtPckUnt.Enabled = False
            txtInrQty.Enabled = False
            txtMtrQty.Enabled = False
            txtCft.Enabled = False

            txtSmpUnt.Enabled = False
            txtShpQty.Enabled = False
            txtBalFreQty.Enabled = False
            txtFreQty.Enabled = False
            txtChgQty.Enabled = False

            txtCurCde1D.Enabled = False
            txtCurCde2D.Enabled = False

            txtFCurCde.Enabled = False
            txtFtyPrc.Enabled = False

            txtSelPrcD.Enabled = False
            txtTtlAmtD.Enabled = False

            txtUntCdeD.Enabled = False

            txtRmkD.Enabled = True

            'If rs_SAINVDTL("sid_itmtyp") = "ASS" Then
            '    cmdAss.Enabled = True
            'Else
            cmdAss.Enabled = False
            'End If

            Exit Sub
        End If

        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") = "~*DEL*~" Or rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") = "~*NEW*~" Then
            chkDel.Enabled = True 'Del_right_local 'True

            txtInvSeq.Enabled = False

            cboItmCol.Enabled = False

            cboTmpItmCol.Enabled = False
            cboVenItmCol.Enabled = False

            txtCusItm.Enabled = False
            txtCusSmpPo.Enabled = False

            txtItmDsc.Enabled = False

            cboPck.Enabled = False

            txtCusCol.Enabled = False
            txtColDsc.Enabled = True
            txtColDsc.ReadOnly = True

            txtPckUnt.Enabled = False
            txtInrQty.Enabled = False
            txtMtrQty.Enabled = False
            txtCft.Enabled = False

            txtSmpUnt.Enabled = False
            txtShpQty.Enabled = False
            txtBalFreQty.Enabled = False
            txtFreQty.Enabled = False
            txtChgQty.Enabled = False

            txtCurCde1D.Enabled = False
            txtCurCde2D.Enabled = False

            txtSelPrcD.Enabled = False
            txtTtlAmtD.Enabled = False

            txtFCurCde.Enabled = False
            txtFtyPrc.Enabled = False

            txtUntCdeD.Enabled = False

            txtRmkD.Enabled = False

            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmtyp") = "ASS" Then
                cmdAss.Enabled = True
            Else
                cmdAss.Enabled = False
            End If
        ElseIf rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") = "~*ADD*~" Then
            chkDel.Enabled = True 'Del_right_local 'True
            txtInvSeq.Enabled = False


            If cboItmCol.Text <> "" Then
                cboItmCol.Enabled = True
            Else
                cboItmCol.Enabled = False
            End If

            If cboVenItmCol.Text <> "" Then
                cboVenItmCol.Enabled = True
            Else
                cboVenItmCol.Enabled = False
            End If

            If cboTmpItmCol.Text <> "" Then
                cboTmpItmCol.Enabled = True
            Else
                cboTmpItmCol.Enabled = False
            End If



            '*********Kenny Add on 10-10-2002
            txtCusItm.Enabled = True
            txtCusItm.ReadOnly = False
            txtCusSmpPo.ReadOnly = False
            txtCusSmpPo.Enabled = True

            txtItmDsc.Enabled = True

            cboPck.Enabled = True

            txtCusCol.Enabled = True
            txtColDsc.Enabled = True

            txtPckUnt.Enabled = False
            txtInrQty.Enabled = False
            txtMtrQty.Enabled = False
            txtCft.Enabled = False

            txtSmpUnt.Enabled = False
            txtShpQty.Enabled = True
            txtBalFreQty.Enabled = False
            txtFreQty.Enabled = False

            txtChgQty.Enabled = True

            txtCurCde1D.Enabled = False
            txtCurCde2D.Enabled = False

            txtFCurCde.Enabled = False
            txtFtyPrc.Enabled = False

            txtSelPrcD.Enabled = False
            txtTtlAmtD.Enabled = False

            txtUntCdeD.Enabled = False
            txtRmkD.Enabled = True

            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmtyp") = "ASS" Then
                cmdAss.Enabled = True
            Else
                cmdAss.Enabled = False
            End If
        Else
            chkDel.Enabled = True ' Del_right_local 'True
            txtInvSeq.Enabled = False

            cboItmCol.Enabled = False
            cboTmpItmCol.Enabled = False
            cboVenItmCol.Enabled = False

            txtCusItm.Enabled = True
            txtCusItm.ReadOnly = False
            txtCusSmpPo.Enabled = True
            txtCusSmpPo.ReadOnly = False

            txtItmDsc.Enabled = True

            cboPck.Enabled = False

            txtCusCol.Enabled = True
            txtColDsc.Enabled = True
            txtColDsc.ReadOnly = False

            txtPckUnt.Enabled = False
            txtInrQty.Enabled = False
            txtMtrQty.Enabled = False
            txtCft.Enabled = False

            txtSmpUnt.Enabled = False
            txtShpQty.Enabled = True
            txtBalFreQty.Enabled = False
            txtFreQty.Enabled = False

            txtChgQty.Enabled = True

            txtCurCde1D.Enabled = False
            txtCurCde2D.Enabled = False

            txtFCurCde.Enabled = False
            txtFtyPrc.Enabled = False

            txtSelPrcD.Enabled = False
            txtTtlAmtD.Enabled = False

            txtUntCdeD.Enabled = False
            txtRmkD.Enabled = True

            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmtyp") = "ASS" Then
                cmdAss.Enabled = True
            Else
                cmdAss.Enabled = False
            End If
        End If
    End Sub
    Private Sub SetStatusCTNDIM()
        If GetCtrlValue(cboInvSts) = "REL" Or Split(cboInvSts.Text, " - ")(0) = "CLO" Then  'Or GetCtrlValue(cboInvSts) = "HLD"
            grdCtnDim.Enabled = True
            'grdCtnDim.AllowUpdate = True
            txtTtlGrsC.Enabled = False
            txtTtlNetC.Enabled = False
        Else
            grdCtnDim.Enabled = True
            'grdCtnDim.AllowUpdate = True
            txtTtlGrsC.Enabled = False
            txtTtlNetC.Enabled = False
        End If
    End Sub
    Private Sub fillCus2No(ByVal prmcus As String)
        'cboCus1No.Items.Clear()
        'If Add_flag = True Then
        '    Dim drCUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        '    For i As Integer = 0 To drCUBASINF_P.Length - 1
        '        cboCus1No.Items.Add(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)
        '    Next
        'Else
        '    For i As Integer = 0 To rs_CUBASINF_P.Tables("RESULT").Rows.Count - 1
        '        cboCus1No.Items.Add(rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno").ToString & " - " & rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString)
        '    Next
        'End If


        '======
        cboCus2No.Items.Clear()
        Dim drCUBASINF_S() As DataRow = rs_CUBASINF_S.Tables("RESULT").Select("cbi_cus1no = '" + Split(prmcus, " - ")(0) + "'")
        If drCUBASINF_S.Length > 0 Then
            'rs_CUBASINF_S.MoveFirst()
            cboCus2No.Items.Clear()
            '    cboCus2No.AddItem ""

            'While Not rs_CUBASINF_S.EOF
            For i As Integer = 0 To drCUBASINF_S.Length - 1
                'cboCus2No.Items.Add(Trim(rs_CUBASINF_S("cbi_cus2no")) + " - " + Trim(rs_CUBASINF_S("cbi_cussna")))
                cboCus2No.Items.Add(Trim(drCUBASINF_S(i).Item("cbi_cus2no").ToString) + " - " + Trim(drCUBASINF_S(i).Item("cbi_cussna").ToString))
                'rs_CUBASINF_S.MoveNext()
            Next

            'End While
        End If
        'rs_CUBASINF_S.Filter = ""
        '=====
        'If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
        '    Dim drCUBASINF_S() As DataRow = rs_CUBASINF_S.Tables("RESULT").Select("cbi_cus1no = '" + Split(prmcus, " - ")(0) + "'")
        '    For i As Integer = 0 To drCUBASINF_S.Length - 1
        '        cboCus2No.Items.Add(Trim(drCUBASINF_S(i).Item("cbi_cus2no").ToString) + " - " + Trim(drCUBASINF_S(i).Item("cbi_cussna").ToString))
        '    Next
        'Else
        '    For i As Integer = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
        '        cboCus2No.Items.Add(Trim(rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cus2no").ToString) + " - " + Trim(rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString))
        '    Next
        'End If
        'rs_CUBASINF_S.Tables("RESULT").DefaultView.RowFilter = ""
    End Sub
    Private Sub fillCus1Cp(ByVal prmcus As String)
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
        gspStr = "sp_select_CUBASINF_Q '" & gsCompany & "','" & Split(cboCus1No.Text, " - ")(0) & "','Contact Person'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CP, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_CUBASINF_Q : " & rtnStr)
        Else

            cboCus1Cp.Items.Clear()
            For i As Integer = 0 To rs_CUBASINF_CP.Tables("RESULT").Rows.Count - 1
                cboCus1Cp.Items.Add(rs_CUBASINF_CP.Tables("RESULT").Rows(i).Item("cci_cntctp").ToString)
            Next
        End If
    End Sub
    Private Function GetCtrlValue(ByVal Ctrl As Control) As String
        GetCtrlValue = ""
        If TypeOf Ctrl Is ComboBox Then
            If Ctrl.Text <> "" Then
                If UBound(Split(Ctrl.Text, " - ")) > 0 Then
                    GetCtrlValue = Split(Ctrl.Text, " - ")(0)
                Else
                    GetCtrlValue = Ctrl.Text
                End If
            Else
                GetCtrlValue = ""
            End If
            'ElseIf TypeOf Ctrl Is ListBox Then
            '    If Ctrl.List(Ctrl.ListIndex) <> "" Then
            '        If UBound(Split(Ctrl.List(Ctrl.ListIndex), " - ")) > 0 Then
            '            GetCtrlValue = Split(Ctrl.List(Ctrl.ListIndex), " - ")(0)
            '        Else
            '            GetCtrlValue = Ctrl.List(Ctrl.ListIndex)
            '        End If
            '    Else
            '        GetCtrlValue = ""
            '    End If
        ElseIf TypeOf Ctrl Is TextBox Then
            If Ctrl.Text = "" Then
                GetCtrlValue = ""
            Else
                GetCtrlValue = Split(Ctrl.Text, " - ")(0)
            End If
        End If
        Return GetCtrlValue
    End Function
    Private Sub fillCus2Cp(ByVal prmcus As String)
        If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        Else
            cboCus2Cp.Items.Clear()

            For i As Integer = 0 To rs_CUCNTINF.Tables("RESULT").Rows.Count - 1
                If prmcus = rs_CUCNTINF.Tables("RESULT").Rows(i).Item("cci_cusno") Then
                    cboCus2Cp.Items.Add(Trim(rs_CUCNTINF.Tables("RESULT").Rows(i).Item("cci_cntctp").ToString))
                End If
            Next
        End If

    End Sub

    Private Sub fillItmCol()



        cboItmCol.Items.Clear()
        cboTmpItmCol.Items.Clear()
        cboVenItmCol.Items.Clear()

        If rs_SAORDSUM.Tables("RESULT").Rows.Count > 0 Then
            'cboCus2No.Items.Clear()
            For i As Integer = 0 To rs_SAORDSUM.Tables("RESULT").Rows.Count - 1
                ' cboItmCol.Items.Add(Trim(rs_SAORDSUM.Tables("RESULT").Rows(i).Item("sas_itmno").ToString) + " : " + Trim(rs_SAORDSUM.Tables("RESULT").Rows(i).Item("sas_colcde").ToString))

                Dim cboitmno As String = Split(rs_SAORDSUM.Tables("RESULT").Rows(i).Item("sas_itmcol").ToString, " : ")(0).ToString
                Dim colcode As String = " : " + Split(rs_SAORDSUM.Tables("RESULT").Rows(i).Item("sas_itmcol").ToString, " : ")(1).ToString
                Dim itmno As String = Split(cboitmno, " / ")(0).ToString
                Dim itmnotmp As String = Split(cboitmno, " / ")(1).ToString
                Dim itmnoven As String = Split(cboitmno, " / ")(2).ToString
                Dim itmnovenno As String = Split(cboitmno, " / ")(3).ToString

                If itmno <> "" Then

                    If itmnotmp = "" And itmnoven = "" Then
                        cboItmCol.Items.Add(itmno + " / " + " / " + " / " + " / " + itmnovenno + colcode) 'bebe  past itmnovenno + colcode
                    ElseIf itmnotmp <> "" Then
                        cboItmCol.Items.Add(itmno + " / " + itmnotmp + " / " + " / " + " / " + itmnovenno + colcode)
                    ElseIf itmnoven <> "" Then
                        cboItmCol.Items.Add(itmno + " / " + " / " + itmnoven + " / " + itmnovenno + " / " + itmnovenno + colcode)
                    End If

                ElseIf itmnotmp <> "" Then
                    cboTmpItmCol.Items.Add(itmnotmp + " / " + itmnovenno + colcode)


                ElseIf itmnoven <> "" Then
                    cboVenItmCol.Items.Add(itmnoven + " / " + itmnovenno + colcode)
                End If

                itmno = ""
                itmnotmp = ""
                itmnoven = ""
                itmnovenno = ""
                'cboItmCol.Items.Add(rs_SAORDSUM.Tables("RESULT").Rows(i).Item("sas_itmcol"))
            Next
        End If
    End Sub

    Private Sub DisplaySampleInvoiceDetail()
        Dim i As Integer = current_Row
        If rs_SAINVDTL.Tables("RESULT").Rows.Count = 0 Then Exit Sub
        flg_DisplaySampleDetailData = True
        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("DEL").ToString = "Y" Then
            chkDel.Checked = True
        Else
            chkDel.Checked = False
        End If
        txtInvSeq.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_invseq").ToString

        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") = "~*ADD*~" Then

            cboItmCol.Items.Clear()
            cboTmpItmCol.Items.Clear()
            cboVenItmCol.Items.Clear()

            cboItmCol.Text = ""
            cboTmpItmCol.Text = ""
            cboVenItmCol.Text = ""

            fillItmCol()

            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString <> "" Then

                Dim cboitmno As String = Split(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString, " : ")(0).ToString
                Dim colcode As String = " : " + Split(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString, " : ")(1).ToString
                Dim itmno As String = Split(cboitmno, " / ")(0).ToString
                Dim itmnotmp As String = Split(cboitmno, " / ")(1).ToString
                Dim itmnoven As String = Split(cboitmno, " / ")(2).ToString
                Dim itmnovenno As String = Split(cboitmno, " / ")(3).ToString




                If itmno <> "" Then
                    '  cboItmCol.Items.Add(itmno + " / " + itmnovenno + colcode)
                    If itmnotmp = "" And itmnoven = "" Then
                        display_combo(itmno + " / " + " / " + " / " + " / " + itmnovenno + colcode, cboItmCol)
                    ElseIf itmnotmp <> "" Then
                        display_combo(itmno + " / " + itmnotmp + " / " + " / " + " / " + itmnovenno + colcode, cboItmCol)
                    ElseIf itmnoven <> "" Then
                        display_combo(itmno + " / " + " / " + itmnoven + " / " + itmnovenno + " / " + itmnovenno + colcode, cboItmCol)
                    End If

                ElseIf itmnotmp <> "" Then
                    'cboTmpItmCol.Items.Add(itmnotmp + " / " + itmnovenno + colcode)
                    display_combo(itmnotmp + " / " + itmnovenno + colcode, cboTmpItmCol)

                ElseIf itmnoven <> "" Then


                    'cboVenItmCol.Items.Add(itmnoven + " / " + itmnovenno + colcode)
                    display_combo(itmnoven + " / " + itmnovenno + colcode, cboVenItmCol)
                End If


                'display_combo(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString, cboItmCol)

            End If


        Else
            cboItmCol.Items.Clear()
            cboTmpItmCol.Items.Clear()
            cboVenItmCol.Items.Clear()

            cboItmCol.Text = ""
            cboTmpItmCol.Text = ""
            cboVenItmCol.Text = ""

            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString <> "" Then

                Dim cboitmno As String = Split(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString, " : ")(0).ToString
                Dim colcode As String = " : " + Split(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString, " : ")(1).ToString
                Dim itmno As String = Split(cboitmno, " / ")(0).ToString
                Dim itmnotmp As String = Split(cboitmno, " / ")(1).ToString
                Dim itmnoven As String = Split(cboitmno, " / ")(2).ToString
                Dim itmnovenno As String = Split(cboitmno, " / ")(3).ToString





                If itmno <> "" Then 'bebebe
                    '  cboItmCol.Items.Add(itmno + " / " + itmnovenno + colcode)

                    If itmnotmp = "" And itmnoven = "" Then
                        display_combo(itmno + " / " + " / " + " / " + " / " + itmnovenno + colcode, cboItmCol)
                    ElseIf itmnotmp <> "" Then
                        display_combo(itmno + " / " + itmnotmp + " / " + " / " + " / " + itmnovenno + colcode, cboItmCol)
                    ElseIf itmnoven <> "" Then
                        display_combo(itmno + " / " + " / " + itmnoven + " / " + itmnovenno + " / " + itmnovenno + colcode, cboItmCol)
                    End If

                ElseIf itmnotmp <> "" Then
                    'cboTmpItmCol.Items.Add(itmnotmp + " / " + itmnovenno + colcode)
                    display_combo(itmnotmp + " / " + itmnovenno + colcode, cboTmpItmCol)

                ElseIf itmnoven <> "" Then


                    'cboVenItmCol.Items.Add(itmnoven + " / " + itmnovenno + colcode)
                    display_combo(itmnoven + " / " + itmnovenno + colcode, cboVenItmCol)
                End If


                'display_combo(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString, cboItmCol)

            End If


            'cboItmCol.Items.Add(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol"))
            'display_combo(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol"), cboItmCol)
        End If



        txtColCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_colcde").ToString
        txtCusItm.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cusitm").ToString
        txtCusSmpPo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cussmppo").ToString
        txtItmTyp.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmtyp").ToString
        txtItmDsc.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmdsc").ToString
        If UCase(txtItmTyp.Text) = "ASS" Then
            cmdAss.Enabled = True
        Else
            cmdAss.Enabled = False
        End If
        txtReqNo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_reqno").ToString
        txtReqSeq.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_reqseq").ToString
        txtQutNo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_qutno").ToString
        txtQutSeq.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_qutseq").ToString
        txtVenNo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_venno").ToString
        txtSubCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_subcde").ToString
        txtCusVen.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cusven").ToString
        txtCusSub.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cussub").ToString
        txtFCurCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_fcurcde").ToString
        txtFtyPrc.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_ftyprc").ToString
        cboPck.Items.Clear()

        '===
        cboPck.Items.Add(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pck").ToString)
        'Dim TmpPck As String = "!@#$$%&*)"
        'If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then
        '    'rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = "sad_pck"


        '    Dim dv As DataView = rs_SAORDDTL.Tables("RESULT").DefaultView
        '    dv.Sort = "sad_pck"
        '    rs_SAORDDTL.Tables.Remove("RESULT")
        '    rs_SAORDDTL.Tables.Add(dv.ToTable)


        '    For j As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
        '        'While Not rs_SAORDDTL.EOF
        '        If TmpPck <> rs_SAORDDTL.Tables("RESULT").Rows(j).Item("sad_pck") Then
        '            cboPck.Items.Add(rs_SAORDDTL.Tables("RESULT").Rows(j).Item("sad_pck"))
        '            TmpPck = rs_SAORDDTL.Tables("RESULT").Rows(j).Item("sad_pck")
        '        End If
        '        '   rs_SAORDDTL.MoveNext()
        '        'End While
        '    Next

        '    rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = ""
        '    cboPck.SelectedIndex = -1
        '    'ResetPckData()

        'End If
        '===



        display_combo(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pck").ToString, cboPck)
        txtCusCol.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cuscol").ToString
        txtColCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_colcde").ToString
        txtColDsc.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_coldsc").ToString
        txtPckUnt.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pckunt").ToString
        txtInrQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_inrqty").ToString
        txtMtrQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_mtrqty").ToString
        txtCft.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cft").ToString
        txtSmpUnt.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_smpunt").ToString
        txtShpQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty").ToString
        If txtShpQty.Text = "" Then
            txtShpQty.Text = 0
        End If
        orgShpQty = txtShpQty.Text  ' Marco added at 20030922 for balance free qty calculation error fix
        txtBalFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty").ToString
        txtChgQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty").ToString
        If txtChgQty.Text = "" Then
            txtChgQty.Text = 0
        End If
        orgChgQty = txtChgQty.Text ' Marco added at 20030922 for balance free qty calculation error fix
        If txtChgQty.Text - txtShpQty.Text > 0 Then
            txtChgQty.Text = txtShpQty.Text
        End If
        txtCurCde1D.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_curcde").ToString
        txtCurCde2D.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_curcde").ToString
        txtSelPrcD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_selprc").ToString
        txtTtlAmtD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_ttlamt").ToString
        txtUntCdeD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_untcde").ToString
        txtRmkD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_rmk").ToString
        txtFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_freqty").ToString
        If txtFreQty.Text = "" Then
            txtFreQty.Text = 0
        End If
        sampleFreeQty = txtFreQty.Text
        txtOutShpQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_outshpqty").ToString
        txtOutChgQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_outchgqty").ToString
        txtOutFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_outfreqty").ToString
        txtOrgShpQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty").ToString
        txtOrgChgQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty").ToString
        txtOrgFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty").ToString
        Dim sTemp As String
        sTemp = ""
        'If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus1no") Is Nothing Then 'wtf
        '    sTemp = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus1no")
        '    If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus2no") <> "" Then
        '        sTemp = sTemp + "/" + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus2no").ToString
        '    End If
        'Else
        '    sTemp = "Standard"
        'End If
        'txtPrcKey.Text = sTemp


        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus1no").ToString <> "" Then
            sTemp = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus1no")
            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus2no") <> "" Then
                sTemp = sTemp + "/" + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus2no").ToString
            End If
        Else
            sTemp = "Standard"
        End If
        txtPrcKey.Text = sTemp


        '+ "/" + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_hkprctrm").ToString + "/" + _
        'rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_ftyprctrm").ToString(+"/" + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_trantrm").ToString)
        'MsgBox(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat").ToString)
        'MsgBox(Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat"), "MM/dd/yyyy"))
        'txtEffDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat"), "MM/dd/yyyy").ToString
        'txtExpDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat"), "MM/dd/yyyy").ToString
        If IsDBNull(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat")) Then
            txtEffDat.Text = ""
        Else
            txtEffDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat"), "MM/dd/yyyy").ToString
        End If

        If IsDBNull(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat")) Then
            txtExpDat.Text = ""
        Else
            txtExpDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat"), "MM/dd/yyyy").ToString
        End If
        'txtEffDat.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat")
        'txtExpDat.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat")
        flg_DisplaySampleDetailData = False
        Call calculateDetailFreeQtyField(False)
    End Sub

    Private Sub DisplaySampleInvoiceDetailSum(ByVal i As Integer)
        ' Dim i As Integer = current_Row

        current_Row = i
        If rs_SAINVDTL.Tables("RESULT").Rows.Count = 0 Then Exit Sub
        flg_DisplaySampleDetailData = True
        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("DEL").ToString = "Y" Then
            chkDel.Checked = True
        Else
            chkDel.Checked = False
        End If
        txtInvSeq.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_invseq").ToString
        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") = "~*ADD*~" Then
            fillItmCol()
            display_combo(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol").ToString, cboItmCol)
        Else
            cboItmCol.Items.Clear()
            cboItmCol.Items.Add(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol"))
            display_combo(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol"), cboItmCol)
        End If
        txtColCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_colcde").ToString
        txtCusItm.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cusitm").ToString
        txtCusSmpPo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cussmppo").ToString
        txtItmTyp.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmtyp").ToString
        txtItmDsc.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmdsc").ToString
        If UCase(txtItmTyp.Text) = "ASS" Then
            cmdAss.Enabled = True
        Else
            cmdAss.Enabled = False
        End If
        txtReqNo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_reqno").ToString
        txtReqSeq.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_reqseq").ToString
        txtQutNo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_qutno").ToString
        txtQutSeq.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_qutseq").ToString
        txtVenNo.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_venno").ToString
        txtSubCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_subcde").ToString
        txtCusVen.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cusven").ToString
        txtCusSub.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cussub").ToString
        txtFCurCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_fcurcde").ToString
        txtFtyPrc.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_ftyprc").ToString
        cboPck.Items.Clear()

        '===
        cboPck.Items.Add(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pck").ToString)
        'Dim TmpPck As String = "!@#$$%&*)"
        'If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then
        '    'rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = "sad_pck"


        '    Dim dv As DataView = rs_SAORDDTL.Tables("RESULT").DefaultView
        '    dv.Sort = "sad_pck"
        '    rs_SAORDDTL.Tables.Remove("RESULT")
        '    rs_SAORDDTL.Tables.Add(dv.ToTable)


        '    For j As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
        '        'While Not rs_SAORDDTL.EOF
        '        If TmpPck <> rs_SAORDDTL.Tables("RESULT").Rows(j).Item("sad_pck") Then
        '            cboPck.Items.Add(rs_SAORDDTL.Tables("RESULT").Rows(j).Item("sad_pck"))
        '            TmpPck = rs_SAORDDTL.Tables("RESULT").Rows(j).Item("sad_pck")
        '        End If
        '        '   rs_SAORDDTL.MoveNext()
        '        'End While
        '    Next

        '    rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = ""
        '    cboPck.SelectedIndex = -1
        '    'ResetPckData()

        'End If
        '===



        display_combo(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pck").ToString, cboPck)
        txtCusCol.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cuscol").ToString
        txtColCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_colcde").ToString
        txtColDsc.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_coldsc").ToString
        txtPckUnt.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pckunt").ToString
        txtInrQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_inrqty").ToString
        txtMtrQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_mtrqty").ToString
        txtCft.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cft").ToString
        txtSmpUnt.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_smpunt").ToString
        txtShpQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty").ToString
        If txtShpQty.Text = "" Then
            txtShpQty.Text = 0
        End If
        orgShpQty = txtShpQty.Text  ' Marco added at 20030922 for balance free qty calculation error fix
        txtBalFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty").ToString
        txtChgQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty").ToString
        If txtChgQty.Text = "" Then
            txtChgQty.Text = 0
        End If
        orgChgQty = txtChgQty.Text ' Marco added at 20030922 for balance free qty calculation error fix

        'If txtChgQty.Text - txtShpQty.Text > 0 Then
        '    txtChgQty.Text = txtShpQty.Text
        'End If



        txtCurCde1D.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_curcde").ToString
        txtCurCde2D.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_curcde").ToString
        txtSelPrcD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_selprc").ToString
        txtTtlAmtD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_ttlamt").ToString
        txtUntCdeD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_untcde").ToString
        txtRmkD.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_rmk").ToString
        txtFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_freqty").ToString
        If txtFreQty.Text = "" Then
            txtFreQty.Text = 0
        End If
        sampleFreeQty = txtFreQty.Text
        txtOutShpQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_outshpqty").ToString
        txtOutChgQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_outchgqty").ToString
        txtOutFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sas_outfreqty").ToString
        txtOrgShpQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty").ToString
        txtOrgChgQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty").ToString
        txtOrgFreQty.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty").ToString
        Dim sTemp As String
        sTemp = ""
        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus1no") Is Nothing Then
            sTemp = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus1no")
            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus2no") <> "" Then
                sTemp = sTemp + "/" + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_cus2no").ToString
            End If
        Else
            sTemp = "Standard"
        End If
        txtPrcKey.Text = sTemp
        '+ "/" + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_hkprctrm").ToString + "/" + _
        'rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_ftyprctrm").ToString(+"/" + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_trantrm").ToString)
        'MsgBox(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat").ToString)
        'MsgBox(Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat"), "MM/dd/yyyy"))
        'txtEffDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat"), "MM/dd/yyyy").ToString
        'txtExpDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat"), "MM/dd/yyyy").ToString
        If IsDBNull(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat")) Then
            txtEffDat.Text = ""
        Else
            txtEffDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat"), "MM/dd/yyyy").ToString
        End If

        If IsDBNull(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat")) Then
            txtExpDat.Text = ""
        Else
            txtExpDat.Text = Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat"), "MM/dd/yyyy").ToString
        End If
        'txtEffDat.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat")
        'txtExpDat.Text = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_expdat")
        flg_DisplaySampleDetailData = False
        Call calculateDetailFreeQtyField(False)
    End Sub



    Private Sub DisplayCTNDIM()
        Dim i As Integer

        'If Grid_Got_Focus = "grdCtnDim" Then
        'grdCtnDim.Focus()
        For i = 0 To grdCtnDim.Columns.Count - 1
            grdCtnDim.Columns(i).Width = 0
        Next

        With grdCtnDim
            '.Columns("DEL").Width = 500
            .Columns("DEL").ReadOnly = True
            '.Columns("scd_ctnno").Width = 500
            .Columns("scd_ctnno").HeaderCell.Value = "Carton #"
            '.Columns("scd_inch").Width = 3000
            .Columns("scd_inch").HeaderCell.Value = "Dimension inch (LxWxH)"
            '.Columns("scd_cm").Width = 3000
            .Columns("scd_cm").HeaderCell.Value = "Dimension cm (LxWxH)"
            '.Columns("scd_grswgt").Width = 1000
            .Columns("scd_grswgt").HeaderCell.Value = "GW (kg)"
            '.Columns("scd_netwgt").Width = 1000
            .Columns("scd_netwgt").HeaderCell.Value = "NW (kg)"
            '.Columns("scd_rmk").Width = 5000
            .Columns("scd_rmk").HeaderCell.Value = "Remarks"
        End With
    End Sub
    Private Sub Display_Summary()
        Dim X As Integer

        While X < rs_SAINVDTL.Tables("RESULT").Columns.Count
            grdSummary.Columns(X).Visible = False
            rs_SAINVDTL.Tables("RESULT").Columns(X).ReadOnly = False
            'grdSummary.AllowUpdate = False
            X = X + 1
        End While

        With grdSummary
            '.Columns(3).Width = 400
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False

            .Columns(3).Width = 40
            .Columns(3).HeaderCell.Value = "Seq"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(3).Visible = True

            '.Columns(4).Width = 1500
            .Columns(4).HeaderCell.Value = "Item No."
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(4).Visible = True
            '.Columns(5).Width = 1000
            .Columns(5).Width = 50
            .Columns(5).HeaderCell.Value = "Cust. Item "
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(5).Visible = True
            '.Columns(7).Width = 1000
            .Columns(7).Width = 80
            .Columns(7).HeaderCell.Value = "Color Code"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(7).Visible = True
            '.Columns(8).Width = 3000
            .Columns(8).Width = 320
            .Columns(8).HeaderCell.Value = "Packing & Terms"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(8).Visible = True
            '.Columns(13).Width = 1000
            .Columns(13).Width = 85
            .Columns(13).HeaderCell.Value = "Cust. Color"
            .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(13).Visible = True
            '.Columns(14).Width = 1000
            .Columns(14).Width = 60
            .Columns(14).HeaderCell.Value = "Cust. Sample PO"
            .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(14).Visible = True
            '.Columns(15).Width = 1000
            .Columns(15).Width = 140
            .Columns(15).HeaderCell.Value = "Color Description"
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(15).Visible = True
            '.Columns(16).Width = 800
            .Columns(16).Width = 60
            .Columns(16).HeaderCell.Value = "Selling CCY"
            .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(16).Visible = True
            '.Columns(17).Width = 800
            .Columns(17).Width = 60
            .Columns(17).HeaderCell.Value = "Selling Price"
            .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(17).Visible = True
            '.Columns(18).Width = 1200
            .Columns(18).Width = 60
            .Columns(18).HeaderCell.Value = "Selling UM"
            .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(18).Visible = True
            '.Columns(19).Width = 1000
            .Columns(19).Width = 60
            .Columns(19).HeaderCell.Value = "Total Amt/Item"
            .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(19).Visible = True
            '.Columns(20).Width = 800
            .Columns(20).Width = 60
            .Columns(20).HeaderCell.Value = "Sample UM"
            .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(20).Visible = True
            '.Columns(21).Width = 800
            .Columns(21).Width = 60
            .Columns(21).HeaderCell.Value = "Ship Qty"
            .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(21).Visible = True
            .Columns(21).ReadOnly = False
            '.Columns(22).Width = 1000
            .Columns(22).Width = 60
            .Columns(22).HeaderCell.Value = "Shipped Free Qty"
            .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(22).Visible = True
            '.Columns(23).Width = 1000
            .Columns(23).Width = 60
            .Columns(23).HeaderCell.Value = "Charged Qty"
            .Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(23).Visible = True
            .Columns(23).ReadOnly = False
            '.Columns(24).Width = 1000
            .Columns(24).Width = 60
            .Columns(24).HeaderCell.Value = "Remarks"
            .Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(24).Visible = True
            If gsFlgCst = "1" And gsFlgCstExt = "1" Then
                '.Columns(30).Width = 800
                .Columns(30).Width = 60
                .Columns(30).HeaderCell.Value = "Sample Cost CCY"
                .Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(30).Visible = True
                '.Columns(31).Width = 800
                .Columns(31).Width = 60
                .Columns(31).HeaderCell.Value = "Sample Cost"
                .Columns(31).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(31).Visible = True
            End If
            '.Columns(35).Width = 1000
            .Columns(35).Width = 60
            .Columns(35).HeaderCell.Value = "Bal Free Qty"
            .Columns(35).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(35).Visible = True

            .Columns(54).Width = 60
            .Columns(54).DisplayIndex = 5
            .Columns(54).HeaderCell.Value = "Temp Item "
            .Columns(54).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(54).Visible = True

            .Columns(55).Width = 60
            .Columns(55).DisplayIndex = 6
            .Columns(55).HeaderCell.Value = "Vendor Item "
            .Columns(55).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(55).Visible = True


            .Columns(56).Width = 60
            .Columns(56).DisplayIndex = 7
            .Columns(56).HeaderCell.Value = "Vendor "
            .Columns(56).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(56).Visible = True
            .Refresh()
        End With
    End Sub
    Private Sub calculateDetailFreeQtyField(ByVal init As Boolean)

        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String

        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If

        Dim shippedQty As Long
        Dim chargedQty As Long
        Dim remainSampleFreeQty As Long
        If UBound(Split(itmcol, " : ")) > 0 Then
            'Dim rs() As ADOR.Recordset
            'Dim S As String
            Dim temp_a As String = Split(itmcol, " : ")(0)
            Dim temp_b As String = Split(itmcol, " : ")(1)
            ' gspStr = "sp_select_SAORDSUM '" & gsCompany & "','" & Split(cboCus1No.Text)(0) & "','" & temp_a & "','" & temp_b & "',' ','" & gsUsrID & "'"
            gspStr = "sp_select_SAORDSUM '" & gsCompany & "','" & Split(cboCus1No.Text)(0) & "','" & itmno & "','" & temp_b & "',' ','" & gsUsrID & "'" '02172014 bn
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM_F, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_select_SAORDSUM : " & rtnStr)
                Exit Sub
            Else
                If rs_SAORDSUM_F.Tables("RESULT").Rows.Count > 0 Then
                    shippedQty = rs_SAORDSUM_F.Tables("RESULT").Rows(0).Item("sas_shpqty")
                    chargedQty = rs_SAORDSUM_F.Tables("RESULT").Rows(0).Item("sas_shpchgqty")
                    sampleFreeQty = rs_SAORDSUM_F.Tables("RESULT").Rows(0).Item("sas_freqty")
                Else
                    shippedQty = 0
                    chargedQty = 0
                    sampleFreeQty = 0
                End If
            End If


            remainSampleFreeQty = sampleFreeQty - (shippedQty - chargedQty)
        Else
            remainSampleFreeQty = sampleFreeQty
        End If

        If init Then
            orgShpFreeDiff = orgShpQty - orgChgQty

            txtFreQty.Text = remainSampleFreeQty
            txtBalFreQty.Text = orgShpFreeDiff
        Else
            shippedQty = txtShpQty.Text
            'chargedQty.text = 0
            chargedQty = txtChgQty.Text

            If (shippedQty < chargedQty) Then
                txtFreQty.Text = "0"
                txtBalFreQty.Text = "0"
            Else
                txtFreQty.Text = orgShpFreeDiff + remainSampleFreeQty - (shippedQty - chargedQty)
                txtBalFreQty.Text = shippedQty - chargedQty
            End If
        End If
    End Sub


    Private Sub SumcalculateDetailFreeQtyField(ByVal init As Boolean, ByVal loc As Integer)
        Dim shippedQty As Long
        Dim chargedQty As Long
        Dim remainSampleFreeQty As Long
        If UBound(Split(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_itmcol"), " : ")) > 0 Then
            'Dim rs() As ADOR.Recordset
            'Dim S As String
            Dim temp_a As String = Split(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_itmcol"), " : ")(0)
            Dim temp_b As String = Split(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_itmcol"), " : ")(1)
            gspStr = "sp_select_SAORDSUM '" & gsCompany & "','" & Split(cboCus1No.Text)(0) & "','" & temp_a & "','" & temp_b & "',' ','" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM_F, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_select_SAORDSUM : " & rtnStr)
                Exit Sub
            Else
                If rs_SAORDSUM_F.Tables("RESULT").Rows.Count > 0 Then
                    shippedQty = rs_SAORDSUM_F.Tables("RESULT").Rows(0).Item("sas_shpqty")
                    chargedQty = rs_SAORDSUM_F.Tables("RESULT").Rows(0).Item("sas_shpchgqty")
                    sampleFreeQty = rs_SAORDSUM_F.Tables("RESULT").Rows(0).Item("sas_freqty")
                Else
                    shippedQty = 0
                    chargedQty = 0
                    sampleFreeQty = 0
                End If
            End If


            remainSampleFreeQty = sampleFreeQty - (shippedQty - chargedQty)
        Else
            remainSampleFreeQty = sampleFreeQty
        End If

        If init Then
            orgShpFreeDiff = orgShpQty - orgChgQty

            rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_freqty") = remainSampleFreeQty
            rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_balfreqty") = orgShpFreeDiff
        Else
            shippedQty = rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty")
            'chargedQty.text = 0
            chargedQty = rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty")

            If (shippedQty < chargedQty) Then
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_freqty") = "0"
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_balfreqty") = "0"
            Else
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_freqty") = orgShpFreeDiff + remainSampleFreeQty - (shippedQty - chargedQty)
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_balfreqty") = shippedQty - chargedQty
            End If
        End If
    End Sub



    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim InvNo As String
        'Dim YesNoCancel As Integer

        InvNo = txtInvNo.Text
        If Recordstatus Then
            Dim save_msg As String
            If Add_flag Then
                save_msg = "Record is newly created. Do you want to save before clear the screen?" 'M00247
            Else
                save_msg = "Record has been modified. Do you want to save before clear the screen?" 'M00248
            End If

            Select Case MsgBox(save_msg, MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    If mmdSave.Enabled = True And InputSampleDetailIsValid() Then
                        mmdSave_Click(sender, e)
                        flg_DisplaySampleHeaderData = True
                        flg_DisplaySampleDetailData = True
                        Call setStatus("Clear")
                        flg_DisplaySampleHeaderData = False
                        flg_DisplaySampleDetailData = False
                        txtInvNo.Text = InvNo
                        txtInvNo.SelectionStart = 0
                        txtInvNo.SelectionLength = Len(txtInvNo.Text)
                        Recordstatus = False
                    Else
                        MsgBox("You are not allow to save record!") 'M00253
                    End If
                Case MsgBoxResult.No
                    clearClick = True
                    flg_DisplaySampleHeaderData = True
                    flg_DisplaySampleDetailData = True
                    Call setStatus("Clear")
                    flg_DisplaySampleHeaderData = False
                    flg_DisplaySampleDetailData = False
                    txtInvNo.Text = InvNo
                    txtInvNo.SelectionStart = 0
                    txtInvNo.SelectionLength = Len(txtInvNo.Text)
                    Recordstatus = False
            End Select
        Else
            flg_DisplaySampleHeaderData = True
            flg_DisplaySampleDetailData = True
            Call setStatus("Clear")
            flg_DisplaySampleHeaderData = False
            flg_DisplaySampleDetailData = False
            txtInvNo.Text = InvNo
            txtInvNo.SelectionStart = 0
            txtInvNo.SelectionLength = Len(txtInvNo.Text)
            Recordstatus = False
        End If

        clearClick = False

    End Sub

    Private Function InputSampleDetailIsValid() As Boolean
        'Dim Err As String
        Dim isValid As Boolean
        isValid = True

        Dim tmpshpqty As Long
        tmpshpqty = CLng(txtOutShpQty.Text)

        '*** Folder1
        If cboItmCol.Text = "" And cboTmpItmCol.Text = "" And cboVenItmCol.Text = "" Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("Item Color should not be empty")
            If cboItmCol.Enabled Then cboItmCol.Focus()
            isValid = False
        ElseIf cboPck.Text = "" Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("Packing info. should not be empty")
            '    If cboPck.Enabled Then cboPck.SetFocus
            If cboPck.Enabled Then cboPck.Focus()
            isValid = False
        ElseIf txtChgQty.Text = 0 And txtShpQty.Text = 0 And txtBalFreQty.Text = 0 Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("Charge Qty should not be 0")
            If txtChgQty.Text Then txtChgQty.Text = 0
            isValid = False
        ElseIf txtChgQty.Text <> rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") Then
            txtChgQty_Leave(Me, New EventArgs())
        ElseIf CLng(txtShpQty.Text) <> (CLng(txtChgQty.Text) + CLng(txtBalFreQty.Text)) Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
            If txtShpQty.Enabled Then
                txtShpQty.Focus()
                txtShpQty.SelectionStart = 0
                txtShpQty.SelectionLength = Len(txtShpQty.Text)
            End If
            isValid = False
        ElseIf tmpshpqty - (CLng(txtShpQty.Text) - CLng(txtOrgShpQty.Text)) < 0 Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("Exceed the outstanding Ship Qty = " & (tmpshpqty + CLng(txtOrgShpQty.Text)))
            Trigger_Chgqty = False
            If txtShpQty.Enabled Then
                txtShpQty.Focus()
                txtShpQty.SelectionStart = 0
                txtShpQty.SelectionLength = Len(txtShpQty.Text)
            End If
            isValid = False
        End If


        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String

        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If


        If isValid = True Then
            'Dim tmpBookMark As Long
            Dim temp_rs_SAINVDTL As DataSet
            'If rs_SAINVDTL.recordCount > 0 Then
            If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 And (cboItmCol.Enabled = True Or cboTmpItmCol.Enabled = True Or cboVenItmCol.Enabled = True) And cboPck.Enabled = True Then 'ohwtf
                'tmpBookMark = rs_SAINVDTL.AbsolutePosition
                temp_rs_SAINVDTL = rs_SAINVDTL.Copy
                'If rs.RecordCount > 0 Then rs.MoveFirst()
                For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                        If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pck") = cboPck.Text And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then  'Change this fking .text
                            If i <> current_Row Then
                                Me.TabPageMain.SelectedIndex = 1
                                MsgBox("Duplicate Item, Color and Packing")
                                'rs_SAINVDTL("sid_pck")  = ""
                                'Kenny add on 20-11-2002
                                If cboItmCol.Enabled Then
                                    cboItmCol.Focus()
                                ElseIf cboVenItmCol.Enabled Then
                                    cboVenItmCol.Focus()
                                ElseIf cboTmpItmCol.Enabled Then
                                    cboTmpItmCol.Focus()
                                End If
                                isValid = False
                                'If cboPck.Enabled = True Then
                                '    cboPck.SetFocus
                                'End If
                                'isValid = False
                            End If
                        End If
                    End If
                Next
            End If
        End If

        If isValid = True Then
            InputSampleDetailIsValid = True
        Else
            InputSampleDetailIsValid = False
        End If
    End Function

    Private Function InputSampleDetailSumIsValid() As Boolean
        'Dim Err As String
        Dim isValid As Boolean
        isValid = True

        Dim tmpshpqty As Long
        tmpshpqty = CLng(txtOutShpQty.Text)

        Dim temp_rs_SAINVDTL_2 As DataSet

        temp_rs_SAINVDTL_2 = rs_SAINVDTL.Copy

        For i As Integer = 0 To temp_rs_SAINVDTL_2.Tables("RESULT").Rows.Count - 1

            '*** Folder1
            'If cboItmCol.Text = "" Then
            '    Me.TabPageMain.SelectedIndex = 1
            '    MsgBox("Item Color should not be empty")
            '    If cboItmCol.Enabled Then cboItmCol.Focus()
            '    isValid = False
            'ElseIf cboPck.Text = "" Then
            '    Me.TabPageMain.SelectedIndex = 1
            '    MsgBox("Packing info. should not be empty")
            '    If cboPck.Enabled Then cboPck.SetFocus()
            '    If cboItmCol.Enabled Then cboItmCol.Focus()
            '    isValid = False
            Dim Outshpqty As Long = temp_rs_SAINVDTL_2.Tables("RESULT").Rows(i).Item("sas_outshpqty")
            Dim chgqty As Integer = temp_rs_SAINVDTL_2.Tables("RESULT").Rows(i).Item("sid_chgqty")
            Dim ShpQty As Integer = temp_rs_SAINVDTL_2.Tables("RESULT").Rows(i).Item("sid_shpqty")
            Dim BalFreQty As Integer = temp_rs_SAINVDTL_2.Tables("RESULT").Rows(i).Item("sid_balfreqty")
            Dim OrgShpqty As Integer = temp_rs_SAINVDTL_2.Tables("RESULT").Rows(i).Item("sid_orgshpqty")

            If chgqty = 0 And ShpQty = 0 And BalFreQty = 0 Then
                Me.TabPageMain.SelectedIndex = 2
                MsgBox("Charge Qty should not be 0")
                'If txtChgQty.Text Then txtChgQty.Text = 0
                isValid = False
                'ElseIf txtChgQty.Text <> rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") Then
                '    txtChgQty_Leave(Me, New EventArgs())
            ElseIf CLng(ShpQty) <> (CLng(chgqty) + CLng(BalFreQty)) Then
                Me.TabPageMain.SelectedIndex = 2
                MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
                'If txtShpQty.Enabled Then
                '    txtShpQty.Focus()
                '    txtShpQty.SelectionStart = 0
                '    txtShpQty.SelectionLength = Len(txtShpQty.Text)
                'End If
                isValid = False
            ElseIf Outshpqty - (CLng(ShpQty) - CLng(OrgShpqty)) < 0 Then
                Me.TabPageMain.SelectedIndex = 2
                MsgBox("Exceed the outstanding Ship Qty = " & (Outshpqty + CLng(OrgShpqty)))
                Trigger_Chgqty = False
                'If txtShpQty.Enabled Then
                '    txtShpQty.Focus()
                '    txtShpQty.SelectionStart = 0
                '    txtShpQty.SelectionLength = Len(txtShpQty.Text)
                'End If
                isValid = False
            End If

        Next


        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String


        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If

        'ohwtf2

        If isValid = True Then
            'Dim tmpBookMark As Long
            Dim temp_rs_SAINVDTL As DataSet
            'If rs_SAINVDTL.recordCount > 0 Then
            If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 And (cboItmCol.Enabled = True Or cboVenItmCol.Enabled = True Or cboTmpItmCol.Enabled = True) And cboPck.Enabled = True Then
                'tmpBookMark = rs_SAINVDTL.AbsolutePosition
                temp_rs_SAINVDTL = rs_SAINVDTL.Copy
                'If rs.RecordCount > 0 Then rs.MoveFirst()
                For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                        If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pck") = cboPck.Text And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then 'change this fking .text 
                            If i <> current_Row Then
                                Me.TabPageMain.SelectedIndex = 1
                                MsgBox("Duplicate Item, Color and Packing")
                                'rs_SAINVDTL("sid_pck")  = ""
                                'Kenny add on 20-11-2002

                                If cboItmCol.Enabled Then
                                    cboItmCol.Focus()
                                ElseIf cboVenItmCol.Enabled Then
                                    cboVenItmCol.Focus()
                                ElseIf cboTmpItmCol.Enabled Then
                                    cboTmpItmCol.Focus()
                                End If

                                isValid = False
                                'If cboPck.Enabled = True Then
                                '    cboPck.SetFocus
                                'End If
                                'isValid = False
                            End If
                        End If
                    End If
                Next
            End If
        End If

        If isValid = True Then
            InputSampleDetailSumIsValid = True
        Else
            InputSampleDetailSumIsValid = False
        End If
    End Function
    Public Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String = ""
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
    Private Sub SetSampleDetailUpdateFlag()

        If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") <> "~*ADD*~" And _
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") <> "~*UPD*~" And _
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") <> "~*DEL*~" And _
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") <> "~*NEW*~" Then
            rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = False
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*UPD*~"
            rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = True
            'rs_SAINVHDR("sih_rvsdat") = Format(Date, "mm/dd/yyyy")
        End If
        '******** Johnson Oct 15,2002
        txtRvsDat.Text = SERVER_DATE
        '******** Johnson Oct 15,2002 end
    End Sub

    Private Sub cboCus1Cp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Cp.Leave

        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True

        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboCus1Cp.Items.Count
        If cboCus1Cp.Text <> "" And cboCus1Cp.Enabled = True And cboCus1Cp.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboCus1Cp.Text = cboCus1Cp.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Contact Person of Primary Customer - Data is Invalid, please select in Drop Down List.") 'msg("M00398")   
                Me.TabPageMain.SelectedIndex = 0
                If cboCus1Cp.Enabled Then
                    cboCus1Cp.Focus()
                End If
                Exit Sub
            End If
        End If

        If cboCus1Cp.Text <> "" And cboCus1Cp.Items.Count <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboCus1Cp.Text = ""
            If cboCus1Cp.Enabled Then
                cboCus1Cp.Focus()
            End If
            Exit Sub
        End If
    End Sub


    'use cboCus1Cy_SelectedIndexChanged and cboCus1Cy_TextChanged instead of cboCus1Cy_Click
    Private Sub cboCus1Cy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Cy.SelectedIndexChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub
    Private Sub cboCus1Cy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Cy.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub


    Private Sub cboCus2Cp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2Cp.Leave
        If flg_DisplaySampleHeaderData Then Exit Sub
        'rs_SAINVHDR("sih_cus2cp")  = GetCtrlValue(cboCus2Cp)
        Recordstatus = True
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboCus2Cp.Items.Count
        If cboCus2Cp.Text <> "" And cboCus2Cp.Enabled = True And i > 0 Then
            For Y = 0 To i - 1
                If cboCus2Cp.Text = cboCus2Cp.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Contact Person of Secondary Customer - Data is Invalid, please select in Drop Down List.") 'msg("M00400")
                Me.TabPageMain.SelectedIndex = 0
                If cboCus2Cp.Enabled Then
                    cboCus2Cp.Focus()
                End If
                Exit Sub
            End If
        End If

        If cboCus2Cp.Text <> "" And i <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboCus2Cp.Text = ""
            If cboCus2Cp.Enabled Then
                cboCus2Cp.Focus()
            End If
            Exit Sub
        End If
    End Sub


    Private Sub cboCus2Cy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2Cy.SelectedIndexChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboCus2Cy_TextUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2Cy.TextUpdate
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboCus2Cy_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2Cy.Leave
        If ValidateCombo(cboCus2Cy) = True Then
            cboCus2Cy_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cboItmCol_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItmCol.Leave
        If cboItmCol.Enabled = False Then Exit Sub

        If cboItmCol.Text <> "" Then
            Dim i As Integer
            Dim Y As Integer
            Dim inCombo As Boolean

            i = cboItmCol.Items.Count
            If cboItmCol.Text <> "" And cboItmCol.Enabled = True And i > 0 Then
                For Y = 0 To i - 1
                    If cboItmCol.Text = cboItmCol.Items.Item(Y) Then
                        inCombo = True
                    End If
                Next

                If inCombo = False Then
                    MsgBox("Item & Color - Data is Invalid, please select in Drop Down List.")
                    Me.TabPageMain.SelectedIndex = 1
                    If cboItmCol.Enabled Then
                        cboItmCol.Focus()
                    End If
                    Exit Sub
                End If
            End If
        End If

        'Kenny Add on 20-11-2002
        If cboItmCol.Text <> "" And cboItmCol.Items.Count = 0 Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("No Record found")
            If cboItmCol.Enabled Then cboItmCol.Focus()
            Exit Sub
        End If

        If cboItmCol.Text = "" Then
            '  MsgBox("Item Color should not be empty!") '123''
            tmp_current_row = current_Row
            IsValaidcboitm = False
            Exit Sub
        End If

        If flg_DisplaySampleDetailData Then Exit Sub

        If cboItmCol.Text = "" And cboItmCol.Items.Count > 0 Then
            MsgBox("Item Color should not be empty!")
            If cboItmCol.Enabled Then cboItmCol.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        Dim cboitmno As String = Split(cboItmCol.Text, " : ")(0).ToString    'Here Change
        Dim itmnotmp As String = Split(cboitmno, " / ")(1).ToString
        Dim itmnovenno As String = Split(cboitmno, " / ")(3).ToString
        Dim itmno As String = Split(cboitmno, " / ")(0).ToString
        Dim itmnoven As String = Split(cboitmno, " / ")(2).ToString


        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmno") = GetCtrlValue_Colon(cboItmCol)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmno") = itmno
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnotmp") = itmnotmp
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnoven") = itmnoven
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnovenno") = itmnovenno

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde") = Split(cboItmCol.Text, " : ")(1)
        txtColCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde")


        Dim itmcol As String = itmno + " / " + itmnotmp + " / " + itmnoven + " / " + itmnovenno + " : " + txtColCde.Text

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmcol") = itmcol



        Recordstatus = True
        Dim temp_rs_SAORDSUM As DataSet = rs_SAORDSUM.Copy
        'rs_SAORDSUM.MoveFirst()



        '*** Modified by Tommy on 19 Sept 2002
        Dim dr_SAORDSUM() As DataRow = rs_SAORDSUM.Tables("RESULT").Select("sas_itmcol = '" & Replace(itmcol, "'", "''") & "'")
        If dr_SAORDSUM.Length > 0 Then
            'The status "OLD" added by Mark Lau 20060917
            If cboItmCol.Enabled = True And (dr_SAORDSUM(0).Item("ibi_itmsts") = "TBC" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "INC" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "DIS" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "OLD") Then
                MsgBox("Item is in Discontinued / Inactive / Old Item / To be confirmed status", vbExclamation)
                cboItmCol.Focus()
                Exit Sub
            End If

            'Added by Mark Lau 20060923
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_alsitmno") = dr_SAORDSUM(0).Item("sas_alsitmno")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_alscolcde") = dr_SAORDSUM(0).Item("sas_alscolcde")

            txtItmTyp.Text = dr_SAORDSUM(0).Item("sas_itmtyp")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmtyp") = txtItmTyp.Text

            txtItmDsc.Text = dr_SAORDSUM(0).Item("sas_itmdsc")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmdsc") = txtItmDsc.Text

            txtFreQty.Text = dr_SAORDSUM(0).Item("sas_freqty")
            sampleFreeQty = txtFreQty.Text
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_freqty") = txtFreQty.Text

            txtShpQty.Text = 0 'rs_SAORDSUM("sas_outshpqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text

            txtOutShpQty.Text = dr_SAORDSUM(0).Item("sas_outshpqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outshpqty") = txtOutShpQty.Text

            txtChgQty.Text = 0 'rs_SAORDSUM("sas_outshpqty") - rs_SAORDSUM("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

            txtOutChgQty.Text = dr_SAORDSUM(0).Item("sas_outchgqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outchgqty") = dr_SAORDSUM(0).Item("sas_outchgqty")

            txtBalFreQty.Text = 0 'rs_SAORDSUM("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = dr_SAORDSUM(0).Item("sas_outfreqty")

            txtOutFreQty.Text = dr_SAORDSUM(0).Item("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outfreqty") = dr_SAORDSUM(0).Item("sas_outfreqty")

            Dim tmpshpqty As Long
            Dim tmpchgqty As Long
            Dim tmpbalfreqty As Long

            tmpshpqty = CLng(txtOutShpQty.Text)
            tmpchgqty = CLng(txtOutChgQty.Text)
            tmpbalfreqty = CLng(txtOutFreQty.Text)

            'Dim Bkmark As Integer
            Dim temp_rs_SAINVDTL As New DataSet
            temp_rs_SAINVDTL = rs_SAINVDTL.Copy
            If temp_rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                'Bkmark = rs1.AbsolutePosition
                'rs1.MoveFirst()
                'While Not rs1.EOF
                For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                        If i <> current_Row Then
                            If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                                tmpshpqty = tmpshpqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                                tmpchgqty = tmpchgqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                                tmpbalfreqty = tmpbalfreqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                            End If
                        End If
                    End If
                Next
                'rs1.MoveNext()
                'End While
                'rs1.Close()
            End If

            If tmpchgqty > tmpshpqty Then
                tmpchgqty = tmpshpqty
            End If

            txtShpQty.Text = tmpshpqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text

            txtChgQty.Text = tmpchgqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

            txtBalFreQty.Text = tmpbalfreqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text
        Else
            MsgBox("No Item, Color found in Sample Order Summary")
            txtItmDsc.Text = ""
            txtShpQty.Text = 0
            txtBalFreQty.Text = 0
            txtChgQty.Text = 0
        End If

        '***************************************************
        '*** Get Sample Order detail record   **************
        '***************************************************
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_list_SAORDDTL2 '" & gsCompany & "','" & GetCtrlValue(cboCus1No) & "','" & _
        itmno & "','" & itmnotmp & "','" & itmnoven & "','" & itmnovenno & "','" & Split(itmcol, " : ")(1) & "'"

        Dim TmpPck As String
        TmpPck = "!@#$$%&*)"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_SAORDDTL2 : " & rtnStr)
        Else
            '==
            cboPck.Items.Clear()
            '==
            If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then
                'rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = "sad_pck"


                Dim dv As DataView = rs_SAORDDTL.Tables("RESULT").DefaultView
                dv.Sort = "sad_pck"
                rs_SAORDDTL.Tables.Remove("RESULT")
                rs_SAORDDTL.Tables.Add(dv.ToTable)


                For i As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
                    'While Not rs_SAORDDTL.EOF
                    'MsgBox(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck"))
                    If TmpPck <> rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck") Then
                        cboPck.Items.Add(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck"))
                        TmpPck = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck")
                    End If
                    '   rs_SAORDDTL.MoveNext()
                    'End While
                Next

                rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = ""
                cboPck.SelectedIndex = -1
                ResetPckData()

            Else
                MsgBox("No Packing in Sample Order Detail")
            End If
        End If
        Call calculateDetailFreeQtyField(False)
        cboVenItmCol.Enabled = False
        cboTmpItmCol.Enabled = False
    End Sub
    Private Function GetCtrlValue_Colon(ByVal Ctrl As Control) As String
        GetCtrlValue_Colon = ""
        If TypeOf Ctrl Is ComboBox Then
            If Ctrl.Text <> "" Then
                If UBound(Split(Ctrl.Text, " : ")) > 0 Then
                    GetCtrlValue_Colon = Split(Ctrl.Text, " : ")(0)
                Else
                    GetCtrlValue_Colon = Ctrl.Text
                End If
            Else
                GetCtrlValue_Colon = ""
            End If
            'ElseIf TypeOf Ctrl Is ListBox Then
            '    If Ctrl.List(Ctrl.ListIndex) <> "" Then
            '        If UBound(Split(Ctrl.List(Ctrl.ListIndex), " : ")) > 0 Then
            '            GetCtrlValue_Colon = Split(Ctrl.List(Ctrl.ListIndex), " : ")(0)
            '        Else
            '            GetCtrlValue_Colon = Ctrl.List(Ctrl.ListIndex)
            '        End If
            '    Else
            '        GetCtrlValue_Colon = ""
            '    End If

        ElseIf TypeOf Ctrl Is TextBox Then
            If Ctrl.Text = "" Then
                GetCtrlValue_Colon = ""
            Else
                GetCtrlValue_Colon = Split(Ctrl.Text, " : ")(0)
            End If
        End If
        Return GetCtrlValue_Colon

    End Function

    Private Sub ResetPckData()
        flg_DisplaySampleDetailData = True

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pck") = cboPck.Text

        txtPckUnt.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pckunt") = ""

        txtSmpUnt.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_untcde") = ""

        txtUntCdeD.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_smpunt") = ""

        txtInrQty.Text = 0
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_inrqty") = 0

        txtMtrQty.Text = 0
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_mtrqty") = 0

        txtCft.Text = 0
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cft") = 0

        'txtSelPrcD.Text = rs_SAORDDTL("sad_smpselprc")
        'rs_SAINVDTL("sid_selprc")  = txtSelPrcD.Text

        txtCusCol.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cuscol") = ""

        txtColDsc.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_coldsc") = ""

        txtSelPrcD.Text = 0
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_selprc") = 0

        'txtItmTyp.Text = rs_SAORDDTL("sad_itmtyp")
        'rs_SAINVDTL("sid_itmtyp")  = txtItmTyp.Text

        If UCase(txtItmTyp.Text) = "ASS" Then
            cmdAss.Enabled = True
        Else
            cmdAss.Enabled = False
        End If

        txtReqNo.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_reqno") = ""

        txtReqSeq.Text = 0
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_reqseq") = 0

        txtQutNo.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_qutno") = ""

        txtQutSeq.Text = 0
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_qutseq") = 0

        txtVenNo.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_venno") = ""

        txtSubCde.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_subcde") = ""

        txtCusVen.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cusven") = ""

        txtCusSub.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cussub") = ""

        txtFCurCde.Text = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_fcurcde") = ""

        txtFtyPrc.Text = 0
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ftyprc") = 0

        txtTtlAmtD.Text = round(CDbl(txtSelPrcD.Text) * CDbl(txtChgQty.Text), 4)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ttlamt") = txtTtlAmtD.Text

        flg_DisplaySampleDetailData = False
    End Sub

    Private Sub cmdBck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBck.Click
        Dim tempRecordstatus As Boolean = Recordstatus
        If GetCtrlValue(cboInvSts) <> "REL" And Split(cboInvSts.Text, " - ")(0) <> "CLO" And chkDel.Checked = False Then  'And GetCtrlValue(cboInvSts) <> "HLD"
            If Not InputSampleDetailIsValid() Then Exit Sub
        End If

        If rs_SAINVDTL.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
        UpdateSampleDetail()
        current_Row = current_Row - 1
        checkBackNext()
        'cmdNxt.Enabled = True
        'If rs_SAINVDTL.BOF Then
        '    rs_SAINVDTL.MoveNext()
        '    cmdBck.Enabled = False
        '    Exit Sub
        'End If

        '***********Carlos Lui added on 20120924*********
        'If current_Row <> 0 Then
        '    cmdBck.Enabled = True
        'Else
        '    cmdBck.Enabled = False
        'End If
        '***********Carlos Lui added on 20120924*********

        DisplaySampleInvoiceDetail()
        SetStatusSampleInvoiceDetail()
        Recordstatus = tempRecordstatus
    End Sub

    Private Sub checkBackNext()

        If rs_SAINVDTL.Tables("RESULT").Rows.Count <= 0 Then
            cmdBck.Enabled = False
            cmdNxt.Enabled = False
        Else
            If current_Row = 0 Then
                cmdBck.Enabled = False
            Else
                cmdBck.Enabled = True
            End If

            If current_Row = rs_SAINVDTL.Tables("RESULT").Rows.Count - 1 Then
                cmdNxt.Enabled = False
            Else
                cmdNxt.Enabled = True
            End If
        End If


    End Sub

    Private Sub cmdNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNxt.Click
        Dim tempRecordstatus As Boolean = Recordstatus
        If GetCtrlValue(cboInvSts) <> "REL" And Split(cboInvSts.Text, " - ")(0) <> "CLO" And chkDel.Checked = False Then  'And GetCtrlValue(cboInvSts) <> "HLD"
            If Not InputSampleDetailIsValid() Then Exit Sub
        End If

        If rs_SAINVDTL.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
        UpdateSampleDetail()
        current_Row = current_Row + 1
        checkBackNext()
        'cmdBck.Enabled = True
        'If rs_SAINVDTL.EOF Then
        '    rs_SAINVDTL.MovePrevious()
        '    cmdNxt.Enabled = False
        '    If cboItmCol.Enabled Then
        '        txtCusItm.SetFocus()
        '    Else
        '        If txtCusItm.Enabled Then txtCusItm.SetFocus()
        '    End If
        '    Exit Sub
        'End If

        '***********Carlos Lui added on 20120924*********
        'If rs_SAINVDTL.AbsolutePosition <> rs_SAINVDTL.recordCount Then
        '    cmdNxt.Enabled = True
        'Else
        '    cmdNxt.Enabled = False
        'End If
        '***********Carlos Lui added on 20120924*********

        DisplaySampleInvoiceDetail()
        SetStatusSampleInvoiceDetail()

        If cboItmCol.Enabled Then
            txtCusItm.Focus()
        ElseIf cboVenItmCol.Enabled Then
            txtCusItm.Focus()
        ElseIf cboTmpItmCol.Enabled Then
            txtCusItm.Focus()
        Else
            If txtCusItm.Enabled Then txtCusItm.Focus()
        End If
        Recordstatus = tempRecordstatus
    End Sub

    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged
        'SSTab1_Click

        If IsValaidcboitm = False Then
            IsValaidcboitm = True
            PreviousTab = 0
            current_Row = tmp_current_row
            'Me.TabPageMain.SelectedIndex = 1
            'Exit Sub
        End If

        Dim rs As DataSet
        Dim rs1 As New DataSet


        Dim tmpTtlAmt As Double
        Dim tmpTtlCtn As Long
        Dim tmpTtlNwg As Double
        Dim tmpTtlGwg As Double

        tmpTtlAmt = 0
        tmpTtlCtn = 0
        tmpTtlNwg = 0
        tmpTtlGwg = 0

        If clearClick = True Then Exit Sub
        'MsgBox("Previous Page = " & PreviousTab)

        If Not rs_SAINVDTL Is Nothing And PreviousTab = 1 Then
            If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                Call UpdateSampleDetail()
            End If
        End If

        If Me.TabPageMain.SelectedIndex = 0 Then

            If rs_SAINVDTL Is Nothing Then Exit Sub

            If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                Dim temp_del As String
                If IsDBNull(rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("DEL")) Then
                    temp_del = ""
                Else
                    temp_del = rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("DEL")
                End If
                If Not temp_del = "Y" Then
                    Call InputSampleDetailIsValid()
                End If

                rs = rs_SAINVDTL.Copy
                'If rs.Tables("RESULT").Rows.Count > 0 Then rs.MoveFirst()
                For i As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
                    If rs.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And rs.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                        tmpTtlAmt = tmpTtlAmt + rs.Tables("RESULT").Rows(i).Item("sid_ttlamt")
                    End If
                Next
                txtTtlAmtI.Text = round(tmpTtlAmt, 4)
                txtNetAmtI.Text = round2(round(tmpTtlAmt, 4) * gsNetAmtPct / 100)
            End If

            'Dim TmpFilter As String

            If rs_SACTNDIM Is Nothing Then Exit Sub


            'Dim TmpFilter As String
            'If rs_SACTNDIM Is Nothing Then Exit Sub
            'TmpFilter = rs_SACTNDIM.Filter
            'rs_SACTNDIM.Filter = ""
            'If rs_SACTNDIM.recordCount > 0 Then
            '    rs1 = CopyRS(rs_SACTNDIM)
            '    If rs1.recordCount > 0 Then rs1.MoveFirst()
            '    While Not rs1.EOF
            '        If rs1("scd_creusr") <> "~*DEL*~" And rs1("scd_creusr") <> "~*NEW*~" Then
            '            tmpTtlCtn = tmpTtlCtn + 1
            '        End If
            '        rs1.MoveNext()
            '    End While
            '    TxtTtlCtnI.Text = tmpTtlCtn
            'End If
            'Dim drIMBASINF() As DataRow = rs_IMBASINF.Tables("RESULT").Select("ibi_itmno = '" & Trim(txtItmNo.Text) & "'")
            'dr_SAORDSUM(0).Item("ibi_itmsts")


            If rs_SACTNDIM.Tables("RESULT").Rows.Count > 0 Then
                rs1 = rs_SACTNDIM.Copy
                'If rs1.RecordCount > 0 Then rs1.MoveFirst()
                For i As Integer = 0 To rs_SACTNDIM.Tables("RESULT").Rows.Count
                    If rs1.Tables("RESULT").Rows(current_Row).Item("scd_creusr") <> "~*DEL*~" And rs1.Tables("RESULT").Rows(current_Row).Item("scd_creusr") <> "~*NEW*~" Then
                        tmpTtlCtn = tmpTtlCtn + 1
                    End If
                Next
                TxtTtlCtnI.Text = tmpTtlCtn
            End If


        ElseIf Me.TabPageMain.SelectedIndex = 1 Then
            If rs_SAINVDTL.Tables("RESULT").Rows.Count <= 0 Then
                If cboItmCol.Enabled And cboPck.Text = "" Then
                    cboItmCol.Focus()
                ElseIf cboVenItmCol.Enabled And cboPck.Text = "" Then
                    cboVenItmCol.Focus()
                ElseIf cboTmpItmCol.Enabled And cboPck.Text = "" Then
                    cboTmpItmCol.Focus()
                ElseIf txtCusItm.Enabled Then
                    txtCusItm.Focus()
                End If
            End If


            'If PreviousTab = 2 Then

            '    For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
            '        MsgBox(selectedRow)
            '        If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_invseq") = selectedSeq Then
            '            current_Row = i
            '        End If

            '        'End If
            '    Next
            '    'current_Row = i
            'End If

            Call DisplaySampleInvoiceDetail()
            Call SetStatusSampleInvoiceDetail()

            If cboItmCol.Enabled And cboPck.Text = "" Then
                cboItmCol.Focus()
            ElseIf cboVenItmCol.Enabled And cboPck.Text = "" Then
                cboVenItmCol.Focus()
            ElseIf cboTmpItmCol.Enabled And cboPck.Text = "" Then
                cboVenItmCol.Focus()
            ElseIf txtCusItm.Enabled Then
                txtCusItm.Focus()
            End If




            checkBackNext()
            'If rs_SAINVDTL.recordCount <= 0 Then
            '    cmdBck.Enabled = False
            '    cmdNxt.Enabled = False
            'Else
            '    If rs_SAINVDTL.AbsolutePosition <> 1 Then
            '        cmdBck.Enabled = True
            '    Else
            '        cmdBck.Enabled = False
            '    End If
            '    If rs_SAINVDTL.AbsolutePosition <> rs_SAINVDTL.recordCount Then
            '        cmdNxt.Enabled = True
            '    Else
            '        cmdNxt.Enabled = False
            '    End If
            'End If
        ElseIf Me.TabPageMain.SelectedIndex = 2 Then

            If rs_SAINVDTL Is Nothing Then Exit Sub
            Display_Summary()
            If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then


                Dim temp_del As String
                If IsDBNull(rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("DEL")) Then
                    temp_del = ""
                Else
                    temp_del = rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("DEL")
                End If
                If Not temp_del = "Y" Then
                    Call InputSampleDetailIsValid()
                End If
            End If
            grdSummary.Columns(0).Visible = False

        End If
    End Sub

    Private Sub TabPageMain_Deselected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabPageMain.Deselected
        'keep track the previous tab index (0:header 1:details 2:summary)
        PreviousTab = e.TabPageIndex
    End Sub

    Private Sub UpdateSampleDetail()

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next '42

        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String 'bebebebe
        Dim itmnoven As String
        Dim itmnotmp As String
        Dim itmnovenno As String
        If cboItmCol.Text <> "" Then

            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString    'Here Change
            itmnotmp = Split(cboitmno, " / ")(1).ToString
            itmnovenno = Split(cboitmno, " / ")(3).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(2).ToString


            'cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            'colcde = Split(cboItmCol.Text, " : ")(1).ToString
            'itmno = Split(cboitmno, " / ")(0).ToString
            'itmnoven = Split(cboitmno, " / ")(1).ToString

            'itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde

            itmcol = itmno + " / " + itmnotmp + " / " + itmnoven + " / " + itmnovenno + " : " + txtColCde.Text

        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If


        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cocde") = gsCompany
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_invno") = txtInvNo.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_invseq") = txtInvSeq.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmcol") = itmcol 'ohoh
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cusitm") = txtCusItm.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cussmppo") = txtCusSmpPo.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmdsc") = txtItmDsc.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pck") = cboPck.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde") = txtColCde.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pckunt") = txtPckUnt.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_inrqty") = txtInrQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_mtrqty") = txtMtrQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cft") = txtCft.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cuscol") = txtCusCol.Text
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cussmppo")  = "" 'txtCusSmpPo.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_coldsc") = txtColDsc.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_curcde") = txtCurCde1D.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_selprc") = txtSelPrcD.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_untcde") = txtUntCdeD.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ttlamt") = txtTtlAmtD.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_smpunt") = txtSmpUnt.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_rmk") = txtRmkD.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmtyp") = txtItmTyp.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_freqty") = txtFreQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outshpqty") = txtOutShpQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outchgqty") = txtOutChgQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outfreqty") = txtOutFreQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_orgshpqty") = txtOrgShpQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_orgchgqty") = txtOrgChgQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_orgfreqty") = txtOrgFreQty.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_reqno") = txtReqNo.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_reqseq") = txtReqSeq.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_qutno") = txtQutNo.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_qutseq") = txtQutSeq.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_venno") = txtVenNo.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_subcde") = txtSubCde.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cusven") = txtCusVen.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cussub") = txtCusSub.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_fcurcde") = txtFCurCde.Text
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ftyprc") = txtFtyPrc.Text
        '************Carlos Lui added on 20120922************
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cus1no") = sImu_cus1no
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cus2no") = sImu_cus2no
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_hkprctrm") = sImu_hkprctrm
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ftyprctrm") = sImu_ftyprctrm
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_trantrm") = sImu_trantrm
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_effdat") = dImu_effdat
        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_expdat") = dImu_expdat
        '************Carlos Lui added on 20120922************



        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = True
        Next

    End Sub
    Public Function round2(ByVal Value As Double) As Double
        Dim tmp As String

        Value = round(Value, 4)

        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If Len(Strings.Right(tmp, Len(tmp) - InStr(tmp, "."))) > 2 Then
                'If CDec(right(right(tmp, Len(tmp) - InStr(tmp, ".")), Len(right(tmp, Len(tmp) - InStr(tmp, "."))) - 2)) > 0 Then
                If CDec(Strings.Right(Strings.Left(Strings.Right(tmp, Len(tmp) - InStr(tmp, ".")), 3), 1)) > 0 Then
                    round2 = CDec(tmp) + 0.01
                    round2 = CDec(Strings.Left(CStr(round2), InStr(round2, ".") + 2))
                    '*********************** unknow exit error  remark by Lewis ********************
                    'Exit Function
                Else
                    round2 = round(CDec(tmp), 4)
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


    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        '*** Folder 1
        If Me.TabPageMain.SelectedIndex = 0 Then

            '*** Folder 2
        ElseIf Me.TabPageMain.SelectedIndex = 1 Then
            'Dim maxshpseq As Integer

            If rs_SAORDSUM Is Nothing Then
                Exit Sub
            End If

            If rs_SAINVDTL.Tables("RESULT").Rows.Count <= 0 Then
                cmdBck.Enabled = False
                cmdNxt.Enabled = False
            Else
                checkBackNext()
                'If rs_SAINVDTL.AbsolutePosition < rs_SAINVDTL.recordCount And rs_SAINVDTL.AbsolutePosition > 1 Then
                '    cmdBck.Enabled = True
                '    cmdNxt.Enabled = True
                'ElseIf rs_SAINVDTL.AbsolutePosition = rs_SAINVDTL.recordCount Then
                '    cmdBck.Enabled = True
                '    cmdNxt.Enabled = False
                'Else
                '    cmdBck.Enabled = True
                '    cmdNxt.Enabled = False
                'End If
            End If
            If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                If Not InputSampleDetailIsValid() Then Exit Sub
            End If

            InsertRow_SampleDetail()
            txtRvsDat.Text = SERVER_DATE

            '*** Folder 3
        ElseIf Me.TabPageMain.SelectedIndex = 2 Then

        End If

    End Sub

    Private Sub InsertRow_SampleDetail()
        Dim maxshpseq As Integer

        flg_DisplaySampleDetailData = True

        maxshpseq = 0 'Get max shipping seq no

        'If Not rs_SAINVDTL.BOF Then
        '    rs_SAINVDTL.MoveFirst()
        'End If

        'While Not rs_SAINVDTL.EOF
        '    If maxshpseq < rs_SAINVDTL("sid_invseq") Then
        '        maxshpseq = rs_SAINVDTL("sid_invseq")
        '    End If
        '    rs_SAINVDTL.MoveNext()
        'End While
        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
            '.Tables("RESULT").Rows(current_Row).Item
            If maxshpseq < rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_invseq") Then
                maxshpseq = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_invseq")
            End If
        Next


        txtInvSeq.Text = maxshpseq + 1

        'rs_SAINVDTL.AddNew()
        'rs_SAINVDTL.Update()
        Dim anyRow As DataRow = rs_SAINVDTL.Tables("RESULT").NewRow()
        rs_SAINVDTL.Tables("RESULT").Rows.Add(anyRow)


        chkDel.Checked = False

        cboItmCol.Text = ""
        cboTmpItmCol.Text = ""
        cboVenItmCol.Text = ""

        txtCusItm.Text = ""
        txtCusSmpPo.Text = ""

        txtItmDsc.Text = ""

        cboPck.Items.Clear()

        txtCusCol.Text = ""
        txtColDsc.Text = ""
        txtColCde.Text = ""

        txtPckUnt.Text = ""
        txtInrQty.Text = 0
        txtMtrQty.Text = 0
        txtCft.Text = 0

        txtSmpUnt.Text = ""
        txtShpQty.Text = 0
        txtBalFreQty.Text = 0
        txtChgQty.Text = 0

        txtSelPrcD.Text = 0
        txtTtlAmtD.Text = 0
        txtUntCdeD.Text = ""
        txtRmkD.Text = ""
        txtItmTyp.Text = ""

        txtFreQty.Text = 0
        txtOutShpQty.Text = 0
        txtOutChgQty.Text = 0
        txtOutFreQty.Text = 0

        txtOrgShpQty.Text = 0
        txtOrgChgQty.Text = 0
        txtOrgFreQty.Text = 0

        txtReqNo.Text = ""
        txtReqSeq.Text = 0

        txtQutNo.Text = ""
        txtQutSeq.Text = 0

        txtVenNo.Text = ""
        txtSubCde.Text = ""

        txtCusVen.Text = ""
        txtCusSub.Text = ""

        txtFCurCde.Text = ""
        txtFtyPrc.Text = 0
        cboPck.Text = ""

        '***********Carlos Lui added on 20120924***********
        txtPrcKey.Text = ""
        txtEffDat.Text = ""
        txtExpDat.Text = ""
        '***********Carlos Lui added on 20120924***********

        current_Row = rs_SAINVDTL.Tables("RESULT").Rows.Count - 1 'last row


        Call UpdateSampleDetail()
        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*ADD*~"
        Call DisplaySampleInvoiceDetail()
        Call SetStatusSampleInvoiceDetail()
        checkBackNext()
        ' Marco added for fixing missing currency problem when all details are deleted at 20040202
        If txtCurCde1D.Text = "" Then
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            'gspStr = "sp_select_CUBASINF_SAM00003_01 '" & gsCompany & "','" & gsSalTem & "','Primary'"
            gspStr = "sp_select_CUBASINF_PC '" & gsCompany & "','" & gsUsrID & "','QU','Primary'"       ' from quotation


            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default


            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_select_CUBASINF_SAM00003_01 : " & rtnStr)
            Else
                If rs_CUBASINF_P.Tables("RESULT").Rows.Count = 0 Then
                    Exit Sub
                Else

                    'Dim drIMBASINF() As DataRow = rs_IMBASINF.Tables("RESULT").Select("ibi_itmno = '" & Trim(txtItmNo.Text) & "'")
                    'dr_SAORDSUM(0).Item("ibi_itmsts")

                    Dim dr_CUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = '" + GetCtrlValue(cboCus1No) + "'")


                    If dr_CUBASINF_P.Length <= 0 Then
                        'MsgBox "No Customer Found"
                        Exit Sub
                    Else
                        txtSmpPrd.Text = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_smpprd")
                        txtSmpFgt.Text = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_smpfgt")
                        txtDiscnt.Text = 100 - rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("yst_chgval")
                        gsNetAmtPct = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("yst_chgval")

                        txtTtlAmtI.Text = 0
                        txtNetAmtI.Text = 0

                        'gsPrdTrm = rs_cubasinf_P("
                        txtPrcTrm.Text = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_prctrm")

                        txtCurCdeI.Text = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_curcde")
                        txtCurCde1D.Text = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_curcde")
                        txtCurCde2D.Text = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_curcde")
                    End If
                End If
            End If
        End If

        Call UpdateSampleDetail()

        ' Marco added for fixing missing currency problem when all details are deleted at 20040202
        If cboItmCol.Enabled Then
            cboItmCol.Focus()
        ElseIf cboVenItmCol.Enabled Then
            cboVenItmCol.Focus()
        ElseIf cboTmpItmCol.Enabled Then
            cboTmpItmCol.Focus()
        End If

        flg_DisplaySampleDetailData = False
        txtInvSeq.Enabled = False 'ww

        cboItmCol.Enabled = True
        cboVenItmCol.Enabled = True
        cboTmpItmCol.Enabled = True

    End Sub



    Private Sub cboCoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.Click
        'txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Enq_right_local = Enq_right
        'Del_right_local = Del_right
        'Call fillParameter()
    End Sub

    Private Sub cboCoCde_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoCde.KeyUp
        'Call AutoSearch(cboCoCde, KeyCode)
        auto_search_combo(cboCoCde, e.KeyCode)
        Dim orgPos As Integer
        Dim needToChange As Boolean
        orgPos = cboCoCde.SelectedIndex
        If orgPos = -1 Then
            orgPos = 0
            needToChange = True
        Else
            needToChange = False
        End If

        If needToChange = True Then
            cboCoCde.Text = ""
            cboCoCde.SelectedIndex = orgPos
        End If
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub
    Private Sub txtCoNam_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoNam.Leave
        txtInvNo.Text = UCase(Trim(txtInvNo.Text))
    End Sub

    Private Sub cboInvSts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvSts.SelectedIndexChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboCus1No_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1No.Click
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboCus1No_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCus1No.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then



            '==init sec cus==
            cboCus2No.Text = ""
            txtCus2Ad.Text = ""
            txtCus2St.Text = ""
            cboCus2Cy.Text = ""
            txtCus2Zp.Text = ""
            cboCus2Cp.Text = ""
            '================

            If flg_DisplaySampleHeaderData Then Exit Sub
            If cus1no <> GetCtrlValue(cboCus1No) And rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                If MsgBox("All Sample Detail data will be deleted", vbYesNo) = vbNo Then
                    Call display_combo(cus1no, cboCus1No)
                    Exit Sub
                Else
                    'clear the dataset
                    'If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                    '    rs_SAINVDTL.MoveFirst()
                    '    While Not rs_SAINVDTL.EOF
                    '        rs_SAINVDTL.Delete()
                    '        rs_SAINVDTL.MoveNext()
                    '    End While
                    'End If

                    'If rs_SACTNDIM.recordCount > 0 Then
                    '    rs_SACTNDIM.MoveFirst()
                    '    While Not rs_SACTNDIM.EOF
                    '        rs_SACTNDIM.Delete()
                    '        rs_SACTNDIM.MoveNext()
                    '    End While
                    'End If
                    rs_SAINVDTL.Clear()
                    rs_SACTNDIM.Clear()





                    flg_DisplaySampleDetailData = True
                    chkDel.Checked = False

                    txtInvSeq.Text = ""
                    cboItmCol.Items.Clear()
                    cboItmCol.Text = ""

                    cboTmpItmCol.Items.Clear()
                    cboTmpItmCol.Text = ""

                    cboVenItmCol.Items.Clear()
                    cboVenItmCol.Text = ""

                    txtCusItm.Text = ""
                    txtCusSmpPo.Text = ""

                    txtItmDsc.Text = ""

                    cboPck.Items.Clear()

                    txtCusCol.Text = ""
                    txtColDsc.Text = ""
                    txtColCde.Text = ""

                    txtPckUnt.Text = ""
                    txtInrQty.Text = 0
                    txtMtrQty.Text = 0
                    txtCft.Text = 0

                    txtSmpUnt.Text = ""
                    txtShpQty.Text = 0
                    txtBalFreQty.Text = 0
                    txtChgQty.Text = 0

                    txtSelPrcD.Text = 0
                    txtDiscnt.Text = 0
                    txtTtlAmtD.Text = 0
                    txtUntCdeD.Text = ""
                    txtRmkD.Text = ""
                    txtItmTyp.Text = ""

                    txtFreQty.Text = 0
                    txtOutShpQty.Text = 0
                    txtOutChgQty.Text = 0
                    txtOutFreQty.Text = 0

                    txtOrgShpQty.Text = 0
                    txtOrgChgQty.Text = 0
                    txtOrgFreQty.Text = 0


                    txtReqNo.Text = ""
                    txtReqSeq.Text = 0
                    txtQutNo.Text = ""
                    txtQutSeq.Text = 0

                    txtVenNo.Text = ""
                    txtSubCde.Text = ""

                    txtCusVen.Text = ""
                    txtCusSub.Text = ""

                    txtFCurCde.Text = ""
                    txtFtyPrc.Text = 0

                    flg_DisplaySampleDetailData = False
                    Call SetStatusSampleInvoiceDetail()
                    Call SetStatusCTNDIM() 'wtf
                End If
            End If


            Dim drCUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = '" + GetCtrlValue(cboCus1No) + "'")
            If drCUBASINF_P.Length <= 0 Then
                MsgBox("No Customer Found")
                Exit Sub
            End If


            txtCus1Ad.Text = drCUBASINF_P(0).Item("cci_cntadr")
            txtCus1St.Text = drCUBASINF_P(0).Item("cci_cntstt")


            'cboCus1Cy.Text = IIf((drCUBASINF_P(0).Item("cci_cntcty")) Is Nothing, "", Trim(drCUBASINF_P(0).Item("cci_cntcty")) + " - " + Trim(drCUBASINF_P(0).Item("ysi_dsc")))
            cboCus1Cy.Text = IIf((drCUBASINF_P(0).Item("cci_cntcty")) Is Nothing, "", Trim(drCUBASINF_P(0).Item("cci_cntcty")))
            For i As Integer = 0 To cboCus1Cy.Items.Count - 1
                'If val < combo.Items(i) Then
                'Changed by Carlos Lui at 11-11-2011
                'If val = Mid(combo.Items(i), 1, val_len) Then
                If cboCus1Cy.Text = Mid(cboCus1Cy.Items(i), 1, Len(cboCus1Cy.Text)) Then
                    cboCus1Cy.Text = cboCus1Cy.Items(i)
                    'hit = True
                    Exit For
                End If
            Next
            txtCus1Zp.Text = drCUBASINF_P(0).Item("cci_cntpst")

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)


            gspStr = "sp_list_SYSALINF_CU ''"
            rtnLong = execute_SQLStatement(gspStr, rs_SYSALINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_SYSALINF_CU :" & rtnStr)
                Exit Sub
            End If

            FillcboSalTem()

            cboSalTem.Text = "Division " & drCUBASINF_P(0).Item("cbi_saldiv") & " (" & Split(drCUBASINF_P(0).Item("cbi_saltem"), " - ")(1) & ")"



            gspStr = "sp_select_CUBASINF_SR2 '" & gsCompany & "','" & Split(drCUBASINF_P(0).Item("cbi_saltem"), " - ")(0) & "','" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 rs_SYSALREP : " & rtnStr)
            Else
                If rs_SYSALREP.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                    cboSalRep.Enabled = False
                    'Exit Sub
                Else
                    cboSalRep.Enabled = True
                    cboSalRep.Items.Clear()
                    cboSalRep.Text = ""
                    'If Not rs_SYSALREP.EOF Then
                    'rs_SYSALREP.MoveFirst()
                    'End If

                    For j As Integer = 0 To rs_SYSALREP.Tables("RESULT").Rows.Count - 1
                        cboSalRep.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(j).Item("dsc").ToString)
                    Next
                    'rs_SYSALREP.MoveFirst()

                    Dim sal_rep As String = drCUBASINF_P(0).Item("cbi_srname")
                    Dim drSYSALREP() As DataRow = rs_SYSALREP.Tables("RESULT").Select("ssr_salrep = " & "'" & sal_rep & "'")
                    If drSYSALREP.Length > 0 Then
                        cboSalRep.Text = drSYSALREP(0).Item("dsc")
                    End If

                    txtSalMgt.Text = rs_SYSALREP.Tables("RESULT").Rows(0).Item("yup_mgrnam")
                    txtSalDiv.Text = rs_SYSALREP.Tables("RESULT").Rows(0).Item("ssr_saldiv")

                    'End If
                End If
            End If





            gspStr = "sp_select_CUBASINF_Q '" & gsCompany & "','" & Strings.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Agent'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_CUAGTINF, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_select_CUBASINF_Q : " & rtnStr)
            Else
                If rs_CUAGTINF.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record

                Else

                    cboCusAgt.Items.Clear()
                    cboCusAgt.Text = ""
                    If rs_CUAGTINF.Tables("RESULT").Rows.Count = 0 Then
                    Else
                        Call fillAgent() '*** Fill up Billing Country
                    End If
                End If
            End If
            display_combo(drCUBASINF_P(0).Item("cbi_srname"), cboSalRep)

            txtSmpPrd.Text = drCUBASINF_P(0).Item("cpi_smpprd")
            txtSmpFgt.Text = drCUBASINF_P(0).Item("cpi_smpfgt")
            txtDiscnt.Text = 100 - drCUBASINF_P(0).Item("yst_chgval")
            gsNetAmtPct = drCUBASINF_P(0).Item("yst_chgval")

            txtTtlAmtI.Text = 0
            txtNetAmtI.Text = 0
            txtPrcTrm.Text = drCUBASINF_P(0).Item("cpi_prctrm")

            txtCurCdeI.Text = drCUBASINF_P(0).Item("cpi_curcde")
            txtCurCde1D.Text = drCUBASINF_P(0).Item("cpi_curcde")
            txtCurCde2D.Text = drCUBASINF_P(0).Item("cpi_curcde")

            Call fillCus1Cp(GetCtrlValue(cboCus1No))


            'rs_CUBASINF_P.Filter = ""

            fillCus2No(cboCus1No.Text)



            gspStr = "sp_list_SAORDSUM2 '" & gsCompany & "','" & Split(cboCus1No.Text, " - ")(0) & "'"     'see'
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00003 sp_list_SAORDSUM2 : " & rtnStr)
            Else
                If rs_SAORDSUM.Tables("RESULT").Rows.Count > 0 Then       '***  Not Found Record

                    fillItmCol()
                End If
            End If


            flg_DisplayCTNDIMData = False
            cus1no = Split(cboCus1No.Text, " - ")(0)
        End If
    End Sub
    Private Sub fillAgent()
        'rs_CUAGTINF.MoveFirst()
        cboCusAgt.Items.Clear()

        For i As Integer = 0 To rs_CUAGTINF.Tables("RESULT").Rows.Count - 1
            cboCusAgt.Items.Add(Trim(rs_CUAGTINF.Tables("RESULT").Rows(0).Item("cai_cusagt")) + " - " + Trim(rs_CUAGTINF.Tables("RESULT").Rows(0).Item("yai_stnam")))

        Next

    End Sub

    Private Sub cboCus1No_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus1No.KeyUp
        'AutoSearch(cboCus1No, KeyCode)
        'auto_search_combo(cboCus1No)
        auto_search_combo(cboCus1No, e.KeyCode)
    End Sub

    Private Sub cboCus1No_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1No.Leave
        If flg_DisplaySampleHeaderData Then Exit Sub

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_P '" & gsCompany & "','Currency Rate'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default



        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_CUBASINF_Q : " & rtnStr)
        Else
            If rs_CUBASINF_CR.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                MsgBox("No Currency in System.")
            End If
        End If

        If cboCus1No.Text <> "" And Validate() = True Then

            Dim ee As New System.Windows.Forms.KeyPressEventArgs(Chr(13)) 'Enter
            cboCus1No_KeyPress(sender, ee)
        End If
    End Sub


    Private Sub cboCus1Ad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Ad.Click, cboCus1Ad.SelectedIndexChanged
        'MsgBox("there")
        If rs_CUCNTINF_Adr Is Nothing Then Exit Sub
        If rs_CUCNTINF_Adr.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
        If flg_DisplaySampleHeaderData Then Exit Sub
        If cboInvSts.Text <> "" Then
            If Strings.Left(cboInvSts.Text, 3) <> "OPE" Then Exit Sub
        End If

        txtCus1Ad.Text = cboCus1Ad.Text
        Dim drCUCNTINF_Adr() As DataRow = rs_CUCNTINF_Adr.Tables("RESULT").Select("cci_cntadr = '" + txtCus1Ad.Text + "'")

        If drCUCNTINF_Adr.Length = 0 Then
            txtCus1St.Text = ""
            cboCus1Cy.Text = ""
            txtCus1Zp.Text = ""
        Else

            txtCus1St.Text = drCUCNTINF_Adr(0).Item("cci_cntstt")
            Me.cboCus1Cy.Text = IIf((drCUCNTINF_Adr(0).Item("cci_cntcty")) Is Nothing, "", drCUCNTINF_Adr(0).Item("cci_cntcty"))
            txtCus1Zp.Text = drCUCNTINF_Adr(0).Item("cci_cntpst")
            txtRvsDat.Text = SERVER_DATE
        End If

    End Sub

    Private Sub cboCus1Ad_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Ad.Enter

        If cboCus1No.Text = "" Then Exit Sub
        cboCus1Ad.Items.Clear()

        gspStr = "sp_list_CUCNTINF_SAM00003_01'" & gsCompany & "','" & GetCtrlValue(cboCus1No) & "','" & gsUsrID & "'"
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_Adr, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_CUCNTINF_SAM00003_01 : " & rtnStr)
        Else
            If rs_CUCNTINF_Adr.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                MsgBox("Customer Mailing or Billing address not found!")
                Exit Sub
            Else
                For i As Integer = 0 To rs_CUCNTINF_Adr.Tables("RESULT").Rows.Count - 1
                    cboCus1Ad.Items.Add(Trim(rs_CUCNTINF_Adr.Tables("RESULT").Rows(i).Item("cci_cntadr")))
                Next
            End If
        End If

    End Sub

    Private Sub txtCus1Ad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCus1Ad.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub txtCus1St_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCus1St.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub txtCus1Zp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCus1Zp.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboCus1Cy_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus1Cy.KeyUp
        auto_search_combo(cboCus1Cy, e.KeyCode)
    End Sub

    Private Sub cboCus1Cp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Cp.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboCus1Cp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Cp.Click
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboCus1Cp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus1Cp.KeyUp
        auto_search_combo(cboCus1Cp, e.KeyCode)
    End Sub

    Private Sub cboCusAgt_TextUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCusAgt.TextUpdate
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboCusAgt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCusAgt.Click
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboCusAgt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCusAgt.KeyUp
        auto_search_combo(cboCusAgt, e.KeyCode)
    End Sub

    Private Sub cboCusAgt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCusAgt.Leave
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboCusAgt.Items.Count
        If cboCusAgt.Text <> "" And cboCusAgt.Enabled = True And cboCusAgt.Items.Count > 0 Then
            For Y = 0 To i - 1

                If cboCusAgt.Text = cboCusAgt.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Agent - Data is Invalid, please select in Drop Down List.")   'msg("M00401")
                Me.TabPageMain.SelectedIndex = 0
                If cboCusAgt.Enabled Then
                    cboCusAgt.Focus()
                End If
                Exit Sub
            End If
        End If

        If cboCusAgt.Text <> "" And cboCusAgt.Items.Count <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboCusAgt.Text = ""
            If cboCusAgt.Enabled Then
                cboCusAgt.Focus()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub cboSalRep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalRep.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboSalRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalRep.Click
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboSalRep_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSalRep.KeyUp
        auto_search_combo(cboSalRep, e.KeyCode)
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

    Private Sub chkApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApprove.Click
        If chkApprove.Checked = True Then
            mmdSave.Enabled = True
        Else
            mmdSave.Enabled = False
        End If
    End Sub

    Private Sub cboCus2No_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus2No.KeyUp
        auto_search_combo(cboCus2No, e.KeyCode)
    End Sub

    Private Sub cboCus2No_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2No.Leave
        If cboCus2No.Text <> "" Then
            Dim i As Integer
            Dim Y As Integer
            Dim inCombo As Boolean

            i = cboCus2No.Items.Count
            If cboCus2No.Text <> "" And cboCus2No.Enabled = True And cboCus2No.Items.Count > 0 Then
                For Y = 0 To i - 1
                    If cboCus2No.Text = cboCus2No.Items.Item(Y) Then
                        inCombo = True
                    End If
                Next

                If inCombo = False Then
                    MsgBox("Secondary Customer - Data is Invalid, please select in Drop Down List.") 'msg("M00399")
                    Me.TabPageMain.SelectedIndex = 0
                    If cboCus2No.Enabled Then
                        cboCus2No.Focus()
                    End If
                    Exit Sub
                End If
            End If
        End If

        If cboCus2No.Text <> "" And cboCus2No.Items.Count <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboCus2No.Text = ""
            If cboCus2No.Enabled Then
                cboCus2No.Focus()
            End If
            Exit Sub
        End If
        Call enableCus2Addr()
    End Sub

    Private Sub cboCus2No_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2No.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
        cboCus2No_Click(Me, e)
    End Sub

    Private Sub cboCus2No_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2No.Click


    End Sub

    Private Sub enableCus2Addr()
        If Me.cboCus2No.Text <> "" Then
            Me.txtCus2Ad.Enabled = True
            Me.txtCus2Ad.ReadOnly = False
            Me.txtCus2St.Enabled = True
            Me.txtCus2Zp.Enabled = True
            Me.cboCus2Cy.Enabled = True
        Else
            Me.txtCus2Ad.Text = ""
            Me.txtCus2St.Text = ""
            Me.txtCus2Zp.Text = ""
            Me.cboCus2Cy.Text = ""
            Me.txtCus2Ad.Enabled = False
            Me.txtCus2St.Enabled = False
            Me.txtCus2Zp.Enabled = False
            Me.cboCus2Cy.Enabled = False
        End If
    End Sub

    Private Sub txtCus2Ad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCus2Ad.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub txtCus2St_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCus2St.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboCus2Cy_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus2Cy.KeyUp
        auto_search_combo(cboCus2Cy, e.KeyCode)
    End Sub

    Private Sub txtCus2Zp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCus2Zp.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboCus2Cp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2Cp.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboCus2Cp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2Cp.Click
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub cboCus2Cp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus2Cp.KeyUp
        Call auto_search_combo(cboCus2Cp, e.KeyCode)
    End Sub

    Private Sub cboCus2Cp_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2Cp.Enter
        Call fillCus2Cp(GetCtrlValue(cboCus2No))
    End Sub

    Private Sub txtCourier_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCourier.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub optBL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBL.CheckedChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
    End Sub

    Private Sub optFCR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFCR.CheckedChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
    End Sub

    Private Sub optAWB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAWB.CheckedChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
    End Sub

    Private Sub txtDocNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocNo.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
    End Sub

    Private Sub txtDocNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocNo.Enter
        txtDocNo.Height = txtDocNo.Height + 50
        'txtDocNo.ZOrder(0)
        txtDocNo.BringToFront()
        If GetCtrlValue(cboInvSts) = "REL" Or Split(cboInvSts.Text, " - ")(0) = "CLO" Then 'Or GetCtrlValue(cboInvSts) = "HLD"
            txtDocNo.ReadOnly = True
        Else
            txtDocNo.ReadOnly = False
        End If
    End Sub

    Private Sub txtDocNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocNo.Leave
        txtDocNo.Height = txtDocNo.Height - 50
    End Sub

    Private Sub txtHdrRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHdrRmk.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
    End Sub

    Private Sub txtHdrRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHdrRmk.Enter
        'txtHdrRmk.Top = txtHdrRmk.Top
        'txtHdrRmk.Left = txtHdrRmk.Left
        txtHdrRmk.Height = txtHdrRmk.Height + 50
        'txtHdrRmk.ZOrder(0)
        txtHdrRmk.BringToFront()
        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then 'Or GetCtrlValue(cboInvSts) = "HLD"
            txtHdrRmk.ReadOnly = True
        Else
            txtHdrRmk.ReadOnly = False
        End If
    End Sub

    Private Sub txtHdrRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHdrRmk.Leave
        'txtHdrRmk.Top = 360
        'txtHdrRmk.Left = 120
        'txtHdrRmk.Height = 435
        txtHdrRmk.Height = txtHdrRmk.Height - 50
    End Sub

    Private Sub txtShpRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpRmk.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
    End Sub

    Private Sub txtShpRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpRmk.Enter
        'txtShpRmk.Width = 5415
        'txtShpRmk.Top = txtShpRmk.Top
        'txtShpRmk.Left = txtShpRmk.Left
        'txtShpRmk.Height = 1035
        txtShpRmk.Height = txtShpRmk.Height + 50
        'txtShpRmk.ZOrder(0)
        txtShpRmk.BringToFront()
        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then  'Or GetCtrlValue(cboInvSts) = "HLD"
            txtShpRmk.ReadOnly = True
        Else
            txtShpRmk.ReadOnly = False
        End If
    End Sub

    Private Sub txtShpRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpRmk.Leave
        'txtShpRmk.Width = 5415
        'txtShpRmk.Top = 1080
        'txtShpRmk.Left = 120
        txtShpRmk.Height = txtShpRmk.Height - 50
        'txtShpRmk.Height = 435
    End Sub

    Private Sub txtRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True
    End Sub

    Private Sub txtRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.Enter
        'txtRmk.Width = 5415
        'txtRmk.Top = txtRmk.Top - 50
        'txtRmk.Left = 120
        'txtRmk.Height = 1035
        'txtRmk.Height = txtRmk.Height + 50
        'txtRmk.ZOrder(0)
        txtRmk.BringToFront()

        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then  'Or GetCtrlValue(cboInvSts) = "HLD"
            txtRmk.ReadOnly = True
        Else
            txtRmk.ReadOnly = False
        End If
    End Sub

    Private Sub txtRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.Leave
        'txtRmk.Width = 5415
        'txtRmk.Top = txtRmk.Top + 50
        'txtRmk.Left = 120
        'txtRmk.Height = txtRmk.Height - 50
    End Sub


    Private Sub cboItmCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItmCol.Click
        cboPck.Items.Clear()
    End Sub

    Private Sub cboItmCol_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboItmCol.KeyUp
        Call auto_search_combo(cboItmCol, e.KeyCode)
    End Sub

    Private Sub cboItmCol_TextUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItmCol.TextUpdate
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        Call SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtCusItm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusItm.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_cusitm").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cusitm") = txtCusItm.Text
        Call SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtCusSmpPo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusSmpPo.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_cussmppo").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cussmppo") = txtCusSmpPo.Text
        Call SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtItmDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmDsc.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then Exit Sub 'Or GetCtrlValue(cboInvSts) = "HLD"
        Recordstatus = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_itmdsc").ReadOnly = False

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmdsc") = txtItmDsc.Text
        Call SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtItmDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmDsc.Enter
        'txtItmDsc.Width = 4455
        'txtItmDsc.Top = 720
        'txtItmDsc.Height = txtItmDsc.Height + 20
        'txtItmDsc.Left = 1320

        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then  'Or GetCtrlValue(cboInvSts) = "HLD"
            txtItmDsc.ReadOnly = True
        Else
            txtItmDsc.ReadOnly = False
        End If
    End Sub

    Private Sub txtItmDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmDsc.Leave
        'txtItmDsc.Width = 4455
        'txtItmDsc.Top = 1320
        'txtItmDsc.Height = 855
        'txtItmDsc.Left = 1320
        'txtItmDsc.Height = txtItmDsc.Height - 20
    End Sub



    Private Sub cboPck_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPck.SelectedIndexChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboPck_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPck.KeyUp
        Call auto_search_combo(cboPck, e.KeyCode)


        '===fix short key problem===
        'If (e.Alt) Then
        '    If e.KeyCode = Keys.N Then
        '        e.SuppressKeyPress = True
        '        e.Handled = True

        '    End If
        'End If


        'If (e.Alt) Then
        '    e.SuppressKeyPress = True
        'End If

        '===========================





    End Sub

    Private Sub cboPck_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPck.Leave
        If cboPck.Enabled = False Then Exit Sub

        'Dim tmpBookMark As Integer

        'Dim rs As New ADOR.Recordset

        If cboPck.Text = "" Then
            Dim i As Integer
            Dim Y As Integer
            Dim inCombo As Boolean

            i = cboPck.Items.Count
            If cboPck.Text = "" And cboPck.Enabled = True And cboPck.Items.Count > 0 Then
                For Y = 0 To i - 1
                    If cboPck.Text = cboPck.Items.Item(Y) Then
                        inCombo = True
                    End If
                Next

                If inCombo = False Then
                    MsgBox("Packing - Data is Invalid, please select in Drop Down List.")
                    Me.TabPageMain.SelectedIndex = 1
                    If txtCusCol.Enabled Then
                        txtCusCol.Focus()
                    End If
                    Exit Sub
                End If
            End If
        End If

        If rs_SAINVDTL Is Nothing Then Exit Sub


        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pck") = cboPck.Text
        ''ohohoh
        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String
        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If

        If rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
            'tmpBookMark = rs_SAINVDTL.AbsolutePosition
            Dim temp_rs_SAINVDTL As DataSet
            temp_rs_SAINVDTL = rs_SAINVDTL.Copy
            'If rs.RecordCount > 0 Then rs.MoveFirst()
            For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                'While Not rs.EOF
                If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_pck") = cboPck.Text And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                        If i <> current_Row Then
                            MsgBox("Duplicate Item, Color and Packing")
                            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pck") = ""
                            Exit Sub
                        End If
                    End If
                End If
            Next
            'rs.Close()
        End If

        If flg_DisplaySampleDetailData Then Exit Sub

        If Not rs_SAORDDTL Is Nothing Then
            If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then
                'rs_SAORDDTL.MoveFirst()

                'rs_SAORDDTL.Find("sad_pck = '" & Replace(cboPck.Text, "'", "''") & "'")


                Dim drSAORDDTL() As DataRow = rs_SAORDDTL.Tables("RESULT").Select("sad_pck = '" & Replace(cboPck.Text, "'", "''") & "'")
                If drSAORDDTL.Length > 0 Then

                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pck") = cboPck.Text

                    txtPckUnt.Text = drSAORDDTL(0).Item("sad_untcde")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_pckunt") = txtPckUnt.Text 'Packing unit

                    txtSmpUnt.Text = drSAORDDTL(0).Item("sad_smpuntcde")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_untcde") = txtSmpUnt.Text

                    txtUntCdeD.Text = drSAORDDTL(0).Item("sad_smpuntcde")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_smpunt") = txtUntCdeD.Text

                    txtInrQty.Text = drSAORDDTL(0).Item("sad_inrqty")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_inrqty") = txtInrQty.Text

                    txtMtrQty.Text = drSAORDDTL(0).Item("sad_mtrqty")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_mtrqty") = txtMtrQty.Text

                    txtCft.Text = drSAORDDTL(0).Item("sad_cft")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cft") = txtCft.Text

                    'txtSelPrcD.Text = rs_SAORDDTL("sad_smpselprc")
                    'rs_SAINVDTL("sid_selprc")  = txtSelPrcD.Text

                    '*** qud_cuscol = sad_cuscol ***
                    txtCft.Text = drSAORDDTL(0).Item("sad_cft")
                    txtCusCol.Text = drSAORDDTL(0).Item("qud_cuscol")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cuscol") = txtCusCol.Text

                    ' *** qud_coldsc = sad_coldsc ***
                    txtCft.Text = drSAORDDTL(0).Item("sad_cft")
                    txtColDsc.Text = drSAORDDTL(0).Item("qud_coldsc")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_coldsc") = txtColDsc.Text

                    ' Rem by Mark Lau 20090814, Multi Currency
                    '            ' *** qud_smpprc = sad_smpselprc
                    '            ' Add Coonvert to exising currency.
                    '            If rs_SAORDDTL("sad_curcde") <> txtCurCde1D.Text Then
                    '
                    '                rs_CUBASINF_CR.Filter = "ysi_cde = 'HKD'"
                    '                If txtCurCde1D.Text = "HKD" Then
                    '                    txtSelPrcD.Text = round2(rs_SAORDDTL("qud_smpprc") / rs_CUBASINF_CR("ysi_buyrat"))
                    '                    rs_SAINVDTL("sid_selprc")  = txtSelPrcD.Text
                    '                Else
                    '                    txtSelPrcD.Text = round2(rs_SAORDDTL("qud_smpprc") * rs_CUBASINF_CR("ysi_selrat"))
                    '                    rs_SAINVDTL("sid_selprc")  = txtSelPrcD.Text
                    '                End If
                    '
                    '            Else
                    '                txtSelPrcD.Text = rs_SAORDDTL("qud_smpprc")
                    '                rs_SAINVDTL("sid_selprc")  = txtSelPrcD.Text
                    '            End If
                    '                rs_CUBASINF_CR.Filter = ""

                    Dim strDate As String
                    Dim dblRate As Double

                    If CDbl(strCurExRat) = 0 Then
                        dblRate = GetSelRat(drSAORDDTL(0).Item("sad_curcde"), txtCurCde1D.Text, strDate)
                        strCurExRat = CStr(dblRate)
                        strCurExEffDat = strDate
                    Else
                        dblRate = CDbl(strCurExRat)
                    End If

                    txtSelPrcD.Text = drSAORDDTL(0).Item("qud_smpprc") * dblRate 'Remove Round2 Anita dun want round up 09/09/2013
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_selprc") = txtSelPrcD.Text

                    'txtItmTyp.Text = rs_SAORDDTL("sad_itmtyp")
                    'rs_SAINVDTL("sid_itmtyp")  = txtItmTyp.Text

                    If UCase(txtItmTyp.Text) = "ASS" Then
                        cmdAss.Enabled = True
                    Else
                        cmdAss.Enabled = False
                    End If

                    txtReqNo.Text = drSAORDDTL(0).Item("sad_reqno")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_reqno") = txtReqNo.Text

                    txtReqSeq.Text = drSAORDDTL(0).Item("sad_reqseq")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_reqseq") = txtReqSeq.Text

                    txtQutNo.Text = drSAORDDTL(0).Item("sad_qutno")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_qutno") = txtQutNo.Text

                    txtQutSeq.Text = drSAORDDTL(0).Item("sad_qutseq")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_qutseq") = txtQutSeq.Text

                    ' *** qud_venno = sad_venno ***
                    txtVenNo.Text = drSAORDDTL(0).Item("qud_venno")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_venno") = txtVenNo.Text

                    ' *** qud_subcde = sad_subcde ***
                    txtSubCde.Text = drSAORDDTL(0).Item("qud_subcde")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_subcde") = txtSubCde.Text

                    txtCusVen.Text = drSAORDDTL(0).Item("qud_cusven")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cusven") = txtCusVen.Text

                    txtCusSub.Text = drSAORDDTL(0).Item("qud_cussub")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cussub") = txtCusSub.Text

                    ' *** qud_subcde = sad_subcde ***
                    txtFCurCde.Text = drSAORDDTL(0).Item("qud_fcurcde")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_fcurcde") = txtFCurCde.Text

                    ' *** qud_ftyprc = sad_smpftyprc ***
                    txtFtyPrc.Text = drSAORDDTL(0).Item("qud_ftyprc")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ftyprc") = txtFtyPrc.Text

                    txtTtlAmtD.Text = round(CDbl(txtSelPrcD.Text) * CDbl(txtChgQty.Text), 4)
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ttlamt") = txtTtlAmtD.Text

                    txtCusItm.Text = drSAORDDTL(0).Item("sad_cusitm")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cusitm") = txtCusItm.Text

                    txtColCde.Text = drSAORDDTL(0).Item("sad_colcde")
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde") = txtColCde.Text

                    '**********Carlos Lui added on 20120922***************
                    Dim sTemp As String

                    sTemp = ""

                    If drSAORDDTL(0).Item("sad_imu_cus1no") <> "" Then
                        sTemp = drSAORDDTL(0).Item("sad_imu_cus1no")
                        If drSAORDDTL(0).Item("sad_imu_cus2no") <> "" Then
                            sTemp = sTemp + "/" + drSAORDDTL(0).Item("sad_imu_cus2no")
                        End If
                    Else
                        sTemp = "Standard"
                    End If

                    txtPrcKey.Text = sTemp
                    '+ "/" + drSAORDDTL(0).Item("sad_imu_hkprctrm") + "/" + _
                    '    drSAORDDTL(0).Item("sad_imu_ftyprctrm") + "/" + drSAORDDTL(0).Item("sad_imu_trantrm")
                    'Format(rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_effdat"), "MM/dd/yyyy").ToString
                    txtEffDat.Text = Format(drSAORDDTL(0).Item("sad_imu_effdat"), "MM/dd/yyyy").ToString
                    txtExpDat.Text = Format(drSAORDDTL(0).Item("sad_imu_expdat"), "MM/dd/yyyy").ToString

                    sImu_cus1no = drSAORDDTL(0).Item("sad_imu_cus1no")
                    sImu_cus2no = drSAORDDTL(0).Item("sad_imu_cus2no")
                    sImu_hkprctrm = drSAORDDTL(0).Item("sad_imu_hkprctrm")
                    sImu_ftyprctrm = drSAORDDTL(0).Item("sad_imu_ftyprctrm")
                    sImu_trantrm = drSAORDDTL(0).Item("sad_imu_trantrm")
                    dImu_effdat = drSAORDDTL(0).Item("sad_imu_effdat")
                    dImu_expdat = drSAORDDTL(0).Item("sad_imu_expdat")

                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cus1no") = sImu_cus1no
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cus2no") = sImu_cus2no
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_hkprctrm") = sImu_hkprctrm
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ftyprctrm") = sImu_ftyprctrm
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_trantrm") = sImu_trantrm
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_effdat") = dImu_effdat
                    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_expdat") = dImu_expdat
                    '**********Carlos Lui added on 20120922***************
                Else
                    If cboPck.Items.Count > 0 And Not cboItmCol.Text = "" Then 'If cboPck.Items.Count > 0 Then
                        MsgBox("No Packing record in Sample Order Detail")
                    ElseIf cboPck.Items.Count > 0 And Not cboVenItmCol.Text = "" Then
                        MsgBox("No Packing record in Sample Order Detail")
                    ElseIf cboPck.Items.Count > 0 And Not cboTmpItmCol.Text = "" Then
                        MsgBox("No Packing record in Sample Order Detail")
                    End If
                End If
            Else
                If cboPck.Items.Count > 0 Then
                    MsgBox("No Packing in Sample Order Detail")
                End If
            End If
        End If
    End Sub

    Private Sub cboPck_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPck.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
    End Sub
    Public Function GetSelRat(ByVal strFrmCur As String, ByVal strToCur As String, ByRef strEffDat As String) As Double
        Dim rs As DataSet


        If strEffDat = "" Then
            gspStr = "sp_select_SYCUREX_transaction '" & gsCompany & "','" & strFrmCur & "','" & strToCur & "','1900-01-01','X'"
        Else
            gspStr = "sp_select_SYCUREX_transaction '" & gsCompany & "','" & strFrmCur & "','" & strToCur & "','" & strEffDat & "','X'"
        End If




        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 rs : " & rtnStr)
            GetSelRat = 0
        Else

            If rs.Tables("RESULT").Rows.Count > 0 Then
                If strEffDat = "" Then
                    strEffDat = Format(rs.Tables("RESULT").Rows(0).Item("yce_effdat"), "yyyy-MM-dd")
                End If
                GetSelRat = CDbl(rs.Tables("RESULT").Rows(0).Item("yce_selrat"))
            Else
                GetSelRat = 0
            End If
        End If


    End Function


    Private Sub cboPck_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPck.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            cboPck_Leave(sender, e)
        End If
    End Sub

    Private Sub txtCusCol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusCol.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_cuscol").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_cuscol") = txtCusCol.Text
        SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtCusCol_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusCol.Enter
        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then  'Or GetCtrlValue(cboInvSts) = "HLD"
            txtCusCol.ReadOnly = True
        Else
            txtCusCol.ReadOnly = False
        End If
    End Sub

    Private Sub txtColDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColDsc.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_coldsc").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_coldsc") = txtColDsc.Text
        SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtVenNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenNo.TextChanged
        If Trim(txtVenNo.Text) <> "" Then
            If Len(Trim(Split(txtVenNo.Text, "-")(0))) > 1 And Trim(Split(txtVenNo.Text, "-")(0)) <> "0005" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0006" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0007" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0008" And Trim(Split(txtVenNo.Text, "-")(0)) <> "0009" Then
                VendorType = "E"
            Else
                VendorType = "I"
            End If
            If VendorType = "E" Then
                If gsFlgCstExt = 1 Then
                    lblFtyPrc.Visible = True
                    txtFCurCde.Visible = True
                    txtFtyPrc.Visible = True
                Else
                    lblFtyPrc.Visible = False
                    txtFCurCde.Visible = False
                    txtFtyPrc.Visible = False
                End If
            Else
                If gsFlgCst = 1 Then
                    lblFtyPrc.Visible = True
                    txtFCurCde.Visible = True
                    txtFtyPrc.Visible = True
                Else
                    lblFtyPrc.Visible = False
                    txtFCurCde.Visible = False
                    txtFtyPrc.Visible = False
                End If
            End If
        Else
            lblFtyPrc.Visible = False
            txtFCurCde.Visible = False
            txtFtyPrc.Visible = False
        End If
    End Sub

    Private Sub txtShpQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpQty.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub txtChgQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChgQty.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub txtBalFreQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalFreQty.TextChanged
        If txtBalFreQty.Text = "" Then
            Exit Sub
        End If
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_balfreqty").ReadOnly = False


        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text
        'txtFreQty = txtFreQty - txtBalFreQty.Text
        SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtRmkD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmkD.TextChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then Exit Sub 'Or GetCtrlValue(cboInvSts) = "HLD"
        Recordstatus = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_rmk").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_rmk") = txtRmkD.Text
        'rs_SAINVDTL("sid_rmk").Value = txtRmkD.Text
        Call SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Update()
    End Sub

    Private Sub txtRmkD_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmkD.Enter
        txtRmkD.Height = txtRmkD.Height + 25
        'txtRmkD.Height = 2295
        'txtRmkD.Width = 5175
        'txtRmkD.Top = 2400
        'txtRmkD.Left = 6120

        If GetCtrlValue(cboInvSts) = "REL" Or GetCtrlValue(cboInvSts) = "CLO" Then  'Or GetCtrlValue(cboInvSts) = "HLD"
            txtRmkD.ReadOnly = True
        Else
            txtRmkD.ReadOnly = False
        End If
    End Sub

    Private Sub txtRmkD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmkD.Leave
        'txtRmkD.Height = 1215
        'txtRmkD.Width = 5175
        'txtRmkD.Top = 3000
        'txtRmkD.Left = 6120
        txtRmkD.Height = txtRmkD.Height - 25
    End Sub

    Private Sub cmdAss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAss.Click 'shit

        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String
        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If

        itmcol = Split(itmcol, " : ")(0)

        gspStr = "sp_select_SAREQASS_SAM00003'" & gsCompany & "','" & txtReqNo.Text & "','" & txtReqSeq.Text & "','" & itmcol & "'"
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAREQASS, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_SAREQASS_SAM00003 : " & rtnStr)
        Else

        End If

        Dim frm_SAM00003_1 As New SAM00003_1(rs_SAREQASS)
        frm_SAM00003_1.MdiParent = Me.MdiParent
        frm_SAM00003_1.Show()
    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        Trigger_ShpQty = False

        Add_flag = True

        'Marco added 20031028 start
        Call fillParameter()
        'Marco added 20031028 end

        txtRvsDat.Text = SERVER_DATE
        txtIssDat.Text = SERVER_DATE

        txtInvNo.Text = ""
        txtInvNo.Enabled = False

        Call setStatus("ADD")

        'Summary Page test
        grdSummary.DataSource = rs_SAINVDTL.Tables("RESULT").DefaultView
        Call Display_Summary()

        If cboCus1No.Enabled Then cboCus1No.Focus()
    End Sub
    Private Sub InitGrid()
        Dim rs() As ADOR.Recordset
        Dim S As String
        Dim i As Integer

        '***************************************************
        '*** Get Sample Invoice Detail record  *************
        '***************************************************

        gspStr = "sp_list_SAINVDTL2 '" & gsCompany & "','!@#$%&*'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAINVDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_SAINVDTL2 : " & rtnStr)
        End If
        '***************************************************
        '***** Get Sample Invoice Detail record End  *******
        '***************************************************



        '***************************************************
        '*** Get Carton Dimension record   *****************
        '***************************************************

        gspStr = "sp_list_SACTNDIM '" & gsCompany & "','!@#$%&*'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SACTNDIM, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_SACTNDIM : " & rtnStr)
        End If
        '***************************************************
        '*** Get Carton Dimension record end ***************
        '***************************************************
    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        'cmdClear_Click
        Me.Close()
    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        Dim InvNo As String

        Dim cn As New ADODB.Connection
        Dim cmd As New ADODB.Command

        If rs_SAINVDTL.Tables("RESULT").Rows.Count = 0 Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("Please input Details Information")
            Exit Sub
        End If




        If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_invseq") <> Me.txtInvSeq.Text Then
            'rs_SAINVDTL.Find("sid_invseq=" & Trim(Me.txtInvSeq.Text))
            Dim dr_invseq() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("sid_invseq=" & Trim(Me.txtInvSeq.Text))
            current_Row = rs_SAINVDTL.Tables("RESULT").Rows.IndexOf(dr_invseq(0))
        End If

        '*** Check Combo in list or not ?
        If not_in_Combo() = True Then
            Exit Sub
        End If

        save_ok = True



        If GetCtrlValue(cboInvSts) <> "REL" And Split(cboInvSts.Text, " - ")(0) <> "CLO" And chkDel.Checked = False Then 'And GetCtrlValue(cboInvSts) <> "HLD"
            If Not InputIsValid() Then
                save_ok = False
                Exit Sub
            End If

            If Not InputSampleDetailIsValid() Then
                save_ok = False
                Exit Sub
            End If

            If Not InputSampleDetailSumIsValid() Then
                save_ok = False
                Exit Sub
            End If

        End If

        Dim auth As Boolean
        Dim YesNoCancel As Integer

        Me.TabPageMain.SelectedIndex = 1
        Me.TabPageMain.SelectedIndex = 0

        If Not Add_flag Then '***check timeStamp is equal
            If Not checkTimeStamp() Then
                MsgBox("The record has been modified by other users, please clear and try again.") 'msg("M00053")
                save_ok = False
                Exit Sub
            End If

            '*** Added by Tommy on 26 July 2002

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            gspStr = "sp_select_CUPRCINF '" & gsCompany & "','" & Split(cboCus1No.Text, " - ")(0) & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then

                MsgBox("Error on loading cmdSave_Click sp_select_CUPRCINF :" & rtnStr)
            Else

                If Split(cboInvSts.Text, " - ")(0) = "OPE" Then

                    '*************************************************************************************************************************************
                    '******* Modify the Credit and Risk over limit to accept add or not only, Not Hold the invlice by Lewis on 17 May 2003 ***************
                    '*************************************************************************************************************************************
                    If CDec(txtNetAmtI.Text) - rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_netamt") > 0 And CDec(txtNetAmtI.Text) - rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_netamt") > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtlmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtuse") Then
                        If gsUsrRank > 4 Then
                            If vbYes = MsgBox("Net Amount exceed Credit and the status will be 'HLD'", vbYesNo, "Question") Then
                                auth = True
                            Else
                                auth = False
                                Exit Sub
                            End If
                        Else
                            YesNoCancel = MsgBox("Net Amount exceed Credit, Confirm to Save and update Customer Credit Used?", vbYesNoCancel, "Question")

                            If YesNoCancel = vbCancel Then
                                Exit Sub
                            ElseIf YesNoCancel = vbNo Then
                                cboInvSts.Text = "HLD - Waiting for Approval"
                            End If
                        End If
                    End If

                    If CDec(txtNetAmtI.Text) - rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_netamt") > 0 And CDec(txtNetAmtI.Text) - rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_netamt") > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rsklmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rskuse") Then
                        If gsUsrRank >= 2 Then
                            If vbYes = MsgBox("Sample Invoice will Hold (Exceed Risk Limit)'", vbYesNo, "Question") Then
                                auth = True
                            Else
                                auth = False
                                Exit Sub
                            End If
                        Else
                            If vbNo = MsgBox("Sample Invoice will Hold (Exceed Risk Limit)'", vbYesNo, "Question") Then


                                cboInvSts.Text = "HLD - Waiting for Approval"
                            End If
                        End If
                    End If

                ElseIf Split(cboInvSts.Text, " - ")(0) = "HLD" And CDec(txtNetAmtI.Text) > rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_netamt") Then
                    If CDec(txtNetAmtI.Text) > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtlmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtuse") Then
                        If gsUsrRank >= 2 Then
                            auth = True

                        Else
                            YesNoCancel = MsgBox("Net Amount exceed Credit, Confirm to Save and update Customer Credit Used?", vbYesNoCancel, "Question")
                            If YesNoCancel = vbCancel Then
                                Exit Sub
                            ElseIf YesNoCancel = vbYes Then
                                cboInvSts.Text = "OPE - Open"
                            End If
                        End If
                    End If

                    If CDec(txtNetAmtI.Text) > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rsklmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rskuse") Then
                        If gsUsrRank >= 2 Then
                            auth = True

                        Else
                            If vbYes = MsgBox("Sample Invoice will Hold (Exceed Risk Limit)'", vbYesNo, "Question") Then
                                auth = True
                            Else
                                auth = False
                                Exit Sub
                            End If

                        End If
                    End If
                ElseIf Split(cboInvSts.Text, " - ")(0) = "HLD" And CDec(txtNetAmtI.Text) <= rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_netamt") Then
                    If CDec(txtNetAmtI.Text) < rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtlmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtuse") Then
                        cboInvSts.Text = "OPE - Open"
                    End If
                    If CDec(txtNetAmtI.Text) < rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rsklmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rskuse") Then
                        cboInvSts.Text = "OPE - Open"
                    Else
                        cboInvSts.Text = "HLD - Hold"
                    End If
                End If
            End If
        Else    '*** Added by Tommy on 23 July 2002


            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUPRCINF '" & gsCompany & "','" & Split(cboCus1No.Text, " - ")(0) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then

                MsgBox("Error on loading cmdSave_Click sp_select_CUPRCINF :" & rtnStr)
            Else

                If CDec(txtNetAmtI.Text) > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtlmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtuse") Then
                    If gsUsrRank > 4 Then
                        If vbYes = MsgBox("Net Amount exceed Credit and the status will be 'HLD'", vbYesNo, "Question") Then
                            auth = True
                        Else
                            auth = False
                            Exit Sub
                        End If
                    Else
                        YesNoCancel = MsgBox("Net Amount exceed Credit, Confirm to Save and update Customer Credit Used?", vbYesNoCancel, "Question")

                        If YesNoCancel = vbCancel Then
                            Exit Sub
                        ElseIf YesNoCancel = vbNo Then
                            cboInvSts.Text = "HLD - Waiting for Approval"
                        End If


                    End If
                End If

                '********** Add Check Risk Limit By Lewis on 15 May 2003 ****************
                If CDec(txtNetAmtI.Text) > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rsklmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rskuse") Then
                    If gsUsrRank >= 2 Then
                        If vbYes = MsgBox("Net Amount exceed Risk and the status will be 'HLD'", vbYesNo, "Question") Then
                            auth = True
                        Else
                            auth = False
                            Exit Sub
                        End If
                    Else
                        If vbYes = MsgBox("Sample Invoice will Hold (Exceed Risk Limit)'", vbYesNo, "Question") Then
                            auth = True
                        Else
                            auth = False
                            Exit Sub
                        End If

                    End If
                End If
                '****************  End Add ************************************************
            End If
        End If



        If Add_flag Then

            '****************************
            '*** Get New Shippment No ***
            '****************************
            Dim rs1 As DataSet
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            gspStr = "sp_select_DOC_GEN '" & gsCompany & "','SI', '" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs1, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then

                MsgBox("Error on loading cmdSave_Click sp_select_DOC_GEN :" & rtnStr)
            Else
                txtInvNo.Text = rs1.Tables("RESULT").Rows(0).Item(0)
            End If
        End If

        InvNo = txtInvNo.Text


        Dim tmpTtlAmt As Double
        tmpTtlAmt = 0
        'rs_SAINVDTL.Filter = ""
        'If rs_SAINVDTL.recordCount > 0 Then rs_SAINVDTL.MoveFirst()

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
            If rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                tmpTtlAmt = tmpTtlAmt + rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_ttlamt")
            End If
        Next

        ''Prompt warning message while the just calculated total amount not equals to the total amount show
        If round(tmpTtlAmt, 4) <> txtTtlAmtI.Text Then
            MsgBox("Total amount value mismatch with sum of detail amount!" & vbCrLf & _
                    "Please contact MIS Department.", vbCritical + vbOKOnly, "Incorrect Total Amount")

            txtTtlAmtI.Text = round(tmpTtlAmt, 4)
            txtNetAmtI.Text = round2(round(tmpTtlAmt, 4) * gsNetAmtPct / 100)

        End If

        ''*************************************************************************************
        Dim SmpShp As String

        Dim doctyp As String

        Dim IsUpdated As Boolean
        Dim IsDeleted As Boolean
        Dim IsAdded As Boolean

        IsUpdated = True
        IsDeleted = True
        IsAdded = True

        doctyp = optBL.Text
        If optBL.Checked = True Then doctyp = optBL.Text
        If optFCR.Checked = True Then doctyp = optFCR.Text
        If optAWB.Checked = True Then doctyp = optAWB.Text

        'Check Header cur

        gspStr = "sp_select_CUBASINF_PC '" & gsCompany & "','" & gsUsrID & "','QU','Primary'"       ' from quotation


        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default


        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CMDSAVE_CLICK sp_select_CUBASINF_PC : " & rtnStr)
        Else
            If rs_CUBASINF_P.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else

                'Dim drIMBASINF() As DataRow = rs_IMBASINF.Tables("RESULT").Select("ibi_itmno = '" & Trim(txtItmNo.Text) & "'")
                'dr_SAORDSUM(0).Item("ibi_itmsts")

                Dim dr_CUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = '" + GetCtrlValue(cboCus1No) + "'")


                If dr_CUBASINF_P.Length <= 0 Then
                    'MsgBox "No Customer Found"
                    Exit Sub
                Else

                    'If txtCurCdeI.Text <> rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_curcde") Then
                    If txtCurCdeI.Text <> dr_CUBASINF_P(0).Item("cpi_curcde") Then
                        MsgBox("Customer Currency Incorrect , Please Check.")
                        Exit Sub
                    End If
                End If
            End If
        End If



        If check_DTL_CUR() = False Then
            Exit Sub
        End If



        If Add_flag Then

            '******************************************
            '*** Insert Shipping Header Record      ***
            '******************************************

            '*** Add SHIPGHDR

            'Check USD HEADER



            gspStr = "sp_insert_SAINVHDR '" & gsCompany & "','" & txtInvNo.Text & "','" & txtIssDat.Text & "','" & txtRvsDat.Text & "','" & _
                     IIf(auth = True, "HLD", GetCtrlValue(cboInvSts)) & "','" & _
                     GetCtrlValue(cboCus1No) & "','" & GetCtrlValue(cboCus2No) & "','" & _
                     Replace(txtCus1Ad.Text, "'", "''") & "','" & Replace(txtCus2Ad.Text, "'", "''") & "','" & _
                     Replace(txtCus1St.Text, "'", "''") & "','" & Replace(GetCtrlValue(cboCus1Cy), "'", "''") & "','" & _
                     Replace(txtCus1Zp.Text, "'", "''") & "','" & _
                     Replace(txtCus2St.Text, "'", "''") & "','" & Replace(GetCtrlValue(cboCus2Cy), "'", "''") & "','" & _
                     Replace(txtCus2Zp.Text, "'", "''") & "','" & _
                     Replace(GetCtrlValue(cboCus1Cp), "'", "''") & "','" & _
                     Replace(GetCtrlValue(cboCus2Cp), "'", "''") & "','" & _
                     Replace(GetCtrlValue(cboSalRep), "'", "''") & "','" & _
                     cboSalTem.Text & "','" & _
                     Split(Trim(txtSalDiv.Text), " - ")(0) & "','" & _
                     txtSalMgt.Text & "','" & _
                     Split(GetCtrlValue(cboSalRep), " - ")(0) & "','" & _
                     GetCtrlValue(cboCusAgt) & "','" & _
                     Replace(txtCourier.Text, "'", "''") & "','" & doctyp & "','" & _
                     Replace(txtDocNo.Text, "'", "''") & "','" & _
                     Split(txtSmpPrd.Text, " - ")(0) & "','" & _
                     Split(txtSmpFgt.Text, " - ")(0) & "','" & _
                     txtCurCdeI.Text & "','" & txtTtlAmtI.Text & "','" & _
                     TxtTtlCtnI.Text & "','" & _
                     Replace(txtShpRmk.Text, "'", "''") & "','" & Replace(txtRmk.Text, "'", "''") & "','" & _
                     Split(txtPrcTrm.Text, " - ")(0) & "','" & _
                     Replace(txtHdrRmk.Text, "'", "''") & "','" & _
                     txtDiscnt.Text & "','" & _
                     txtNetAmtI.Text & "','" & strCurExRat & "','" & strCurExEffDat & "','" & gsUsrID & "'"

        Else
            '*************************************************
            '*** Update Sample Invoice Header Record       ***
            '*************************************************

            '*** Update Sample Invoice header

            gspStr = "sp_update_SAINVHDR '" & gsCompany & "','" & txtInvNo.Text & "','" & txtIssDat.Text & "','" & txtRvsDat.Text & "','" & _
                    IIf(auth = True, "HLD", GetCtrlValue(cboInvSts)) & "','" & _
                    GetCtrlValue(cboCus1No) & "','" & GetCtrlValue(cboCus2No) & "','" & _
                    Replace(txtCus1Ad.Text, "'", "''") & "','" & Replace(txtCus2Ad.Text, "'", "''") & "','" & _
                    Replace(txtCus1St.Text, "'", "''") & "','" & Replace(GetCtrlValue(cboCus1Cy), "'", "''") & "','" & _
                    Replace(txtCus1Zp.Text, "'", "''") & "','" & _
                    Replace(txtCus2St.Text, "'", "''") & "','" & Replace(GetCtrlValue(cboCus2Cy), "'", "''") & "','" & _
                    Replace(txtCus2Zp.Text, "'", "''") & "','" & _
                    Replace(GetCtrlValue(cboCus1Cp), "'", "''") & "','" & _
                    Replace(GetCtrlValue(cboCus2Cp), "'", "''") & "','" & _
                    Replace(GetCtrlValue(cboSalRep), "'", "''") & "','" & _
                    Split(GetCtrlValue(cboSalTem), " - ")(0) & "','" & _
                    Split(Trim(txtSalDiv.Text), " - ")(0) & "','" & _
                    txtSalMgt.Text & "','" & _
                    Split(GetCtrlValue(cboSalRep), " - ")(0) & "','" & _
                    GetCtrlValue(cboCusAgt) & "','" & _
                    Replace(txtCourier.Text, "'", "''") & "','" & doctyp & "','" & Replace(txtDocNo.Text, "'", "''") & "','" & _
                    Split(txtSmpPrd.Text, " - ")(0) & "','" & _
                    Split(txtSmpFgt.Text, " - ")(0) & "','" & _
                    txtCurCdeI.Text & "','" & _
                    txtTtlAmtI.Text & "','" & TxtTtlCtnI.Text & "','" & _
                    Replace(txtShpRmk.Text, "'", "''") & "','" & Replace(txtRmk.Text, "'", "''") & "','" & _
                    GetCtrlValue(txtPrcTrm) & "','" & _
                    Replace(txtHdrRmk.Text, "'", "''") & "','" & _
                    txtDiscnt.Text & "','" & _
            txtNetAmtI.Text & "','" & _
                    rs_SAINVHDR.Tables("RESULT").Rows(0).Item("cpi_cdtlmt") & "','" & rs_SAINVHDR.Tables("RESULT").Rows(0).Item("cpi_cdtuse") & "','" & strCurExRat & "','" & strCurExEffDat & "','" & _
chkApprove.Checked & "','" & gsUsrID & "'"
            'CInt(txtNetAmtI.Text) & "','" & _
            'CInt(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("cpi_cdtlmt")) & "','" & CInt(rs_SAINVHDR.Tables("RESULT").Rows(0).Item("cpi_cdtuse")) & "','" & strCurExRat & "','" & strCurExEffDat & "','" & _



        End If
        Dim rs As DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdSave_Click SAINVHDR :" & rtnStr)
            IsUpdated = False
        End If



        If Not IsUpdated Then
            MsgBox("Cannot update Vendor Basic Information!")
            IsUpdated = True
            IsDeleted = True
            IsAdded = True
        End If

        ''*************************************
        ''*** Delete Sample Details Record***
        ''*************************************

        Dim dr_SAINVDTL_del() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("sid_creusr = '~*DEL*~'")
        If dr_SAINVDTL_del.Length() <= 0 Then
            IsDeleted = True
        Else
            For i As Integer = 0 To dr_SAINVDTL_del.Length() - 1

                gspStr = "sp_Physical_Delete_SAINVDTL '" & gsCompany & "','" & dr_SAINVDTL_del(i).Item("sid_invno") & "','" & dr_SAINVDTL_del(i).Item("sid_invseq") & "'"

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_SAINVDTL_del, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SAM00003 sp_Physical_Delete_SAINVDTL : " & rtnStr)
                    IsDeleted = False
                End If
            Next
        End If



        '    '*************************************
        '    '*** Insert Shipping Details Record***
        '    '*************************************


        Dim dr_SAINVDTL_ins() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("sid_creusr = '~*ADD*~'")
        If dr_SAINVDTL_ins.Length() <= 0 Then
            IsAdded = True
        Else
            For i As Integer = 0 To dr_SAINVDTL_ins.Length() - 1

                'seer'

                gspStr = "sp_insert_SAINVDTL2 '" & gsCompany & "','" & _
                        txtInvNo.Text & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_invseq") & "','" & dr_SAINVDTL_ins(i).Item("sid_itmno") & "','" & dr_SAINVDTL_ins(i).Item("sid_cusitm") & "','" & _
                        Replace(dr_SAINVDTL_ins(i).Item("sid_itmdsc"), "'", "''") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_colcde") & "','" & dr_SAINVDTL_ins(i).Item("sid_alsitmno") & "','" & dr_SAINVDTL_ins(i).Item("sid_alscolcde") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_pckunt") & "','" & dr_SAINVDTL_ins(i).Item("sid_inrqty") & "','" & dr_SAINVDTL_ins(i).Item("sid_mtrqty") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_cft") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_cuscol") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_cussmppo") & "','" & _
                        Replace(dr_SAINVDTL_ins(i).Item("sid_coldsc"), "'", "''") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_curcde") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_selprc") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_untcde") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_ttlamt") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_smpunt") & "','" & dr_SAINVDTL_ins(i).Item("sid_shpqty") & "','" & dr_SAINVDTL_ins(i).Item("sid_balfreqty") & "','" & dr_SAINVDTL_ins(i).Item("sid_chgqty") & "','" & _
                        Replace(dr_SAINVDTL_ins(i).Item("sid_rmk"), "'", "''") & "','" & dr_SAINVDTL_ins(i).Item("sid_itmtyp") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_reqno") & "','" & dr_SAINVDTL_ins(i).Item("sid_reqseq") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_qutno") & "','" & dr_SAINVDTL_ins(i).Item("sid_qutseq") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_venno") & "','" & dr_SAINVDTL_ins(i).Item("sid_subcde") & "','" & dr_SAINVDTL_ins(i).Item("sid_cusven") & "','" & dr_SAINVDTL_ins(i).Item("sid_cussub") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_fcurcde") & "','" & dr_SAINVDTL_ins(i).Item("sid_ftyprc") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_cus1no") & "','" & dr_SAINVDTL_ins(i).Item("sid_cus2no") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_hkprctrm") & "','" & dr_SAINVDTL_ins(i).Item("sid_ftyprctrm") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_trantrm") & "','" & dr_SAINVDTL_ins(i).Item("sid_effdat") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_expdat") & "','" & _
                        dr_SAINVDTL_ins(i).Item("sid_itmnotmp") & "','" & dr_SAINVDTL_ins(i).Item("sid_itmnoven") & "','" & dr_SAINVDTL_ins(i).Item("sid_itmnovenno") & "','" & _
                        gsUsrID & "'"

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_SAINVDTL_ins, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SAM00003 sp_insert_SAINVDTL2 : " & rtnStr)
                    IsDeleted = False
                End If
            Next
        End If
        '    '**************************************
        '    '*** Update Sample Details Record  **
        '    '**************************************

        Dim dr_SAINVDTL_upd() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("sid_creusr = '~*UPD*~'")
        If dr_SAINVDTL_upd.Length() <= 0 Then
            IsAdded = True
        Else
            For i As Integer = 0 To dr_SAINVDTL_upd.Length() - 1

                gspStr = "sp_update_SAINVDTL '" & gsCompany & "','" & _
                        dr_SAINVDTL_upd(i).Item("sid_invno") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_invseq") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_itmno") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_cusitm") & "','" & _
                                Replace(dr_SAINVDTL_upd(i).Item("sid_itmdsc"), "'", "''") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_colcde") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_pckunt") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_inrqty") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_mtrqty") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_cft") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_cuscol") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_cussmppo") & "','" & _
                                Replace(dr_SAINVDTL_upd(i).Item("sid_coldsc"), "'", "''") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_curcde") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_selprc") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_untcde") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_ttlamt") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_smpunt") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_shpqty") & "','" & dr_SAINVDTL_upd(i).Item("sid_balfreqty") & "','" & dr_SAINVDTL_upd(i).Item("sid_chgqty") & "','" & _
                                Replace(dr_SAINVDTL_upd(i).Item("sid_rmk"), "'", "''") & "','" & dr_SAINVDTL_upd(i).Item("sid_itmtyp") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_reqno") & "','" & dr_SAINVDTL_upd(i).Item("sid_reqseq") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_qutno") & "','" & dr_SAINVDTL_upd(i).Item("sid_qutseq") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_venno") & "','" & dr_SAINVDTL_upd(i).Item("sid_subcde") & "','" & dr_SAINVDTL_upd(i).Item("sid_cusven") & "','" & dr_SAINVDTL_upd(i).Item("sid_cussub") & "','" & dr_SAINVDTL_upd(i).Item("sid_fcurcde") & "','" & dr_SAINVDTL_upd(i).Item("sid_ftyprc") & "','" & _
                                dr_SAINVDTL_upd(i).Item("sid_itmnotmp") & "','" & dr_SAINVDTL_upd(i).Item("sid_itmnoven") & "','" & dr_SAINVDTL_upd(i).Item("sid_itmnovenno") & "','" & _
                                 gsUsrID & "'"

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_SAINVDTL_upd, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SAM00003 sp_update_SAINVDTL : " & rtnStr)
                    IsUpdated = False
                End If
            Next
        End If
        If Not (IsDeleted Or IsAdded Or IsUpdated) Then
            MsgBox("Cannot update vendor's Category!")
            IsUpdated = True
            IsDeleted = True
            IsAdded = True
        End If

        ''**********************************************
        ''*** Delete Carton Dimension Record         ***
        ''**********************************************


        Dim dr_SACTNDIM_del() As DataRow = rs_SACTNDIM.Tables("RESULT").Select("scd_creusr = '~*DEL*~'")
        If dr_SACTNDIM_del.Length() <= 0 Then
            IsDeleted = True
        Else
            For i As Integer = 0 To dr_SACTNDIM_del.Length() - 1
                'get_dimension()


                gspStr = "sp_Physical_Delete_SACTNDIM '" & gsCompany & "','" & txtInvNo.Text & "','" & dr_SACTNDIM_del(i).Item("scd_invseq") & "','" & dr_SACTNDIM_del(i).Item("scd_ctnseq") & "'"

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_SACTNDIM_del, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SAM00003 sp_Physical_Delete_SACTNDIM : " & rtnStr)
                    IsDeleted = False
                End If
            Next
        End If

        '    '**********************************************
        '    '*** Insert Carton  Dimension Record        ***
        '    '**********************************************


        Dim dr_SACTNDIM_ins() As DataRow = rs_SACTNDIM.Tables("RESULT").Select("scd_creusr = '~*ADD*~'")
        If dr_SACTNDIM_ins.Length() <= 0 Then
            IsAdded = True
        Else
            For i As Integer = 0 To dr_SACTNDIM_ins.Length() - 1
                'get_dimension()
                If dr_SACTNDIM_ins(i).Item("scd_inch") <> "" Then
                    mLength_in = Split(dr_SACTNDIM_ins(i).Item("scd_inch"), "x")(0)
                    mwidth_in = Split(dr_SACTNDIM_ins(i).Item("scd_inch"), "x")(1)
                    mheight_in = Split(dr_SACTNDIM_ins(i).Item("scd_inch"), "x")(2)
                Else
                    mLength_in = 0
                    mwidth_in = 0
                    mheight_in = 0
                End If

                If dr_SACTNDIM_ins(i).Item("scd_cm") <> "" Then
                    mLength_cm = Split(dr_SACTNDIM_ins(i).Item("scd_cm"), "x")(0)
                    mwidth_cm = Split(dr_SACTNDIM_ins(i).Item("scd_cm"), "x")(1)
                    mheight_cm = Split(dr_SACTNDIM_ins(i).Item("scd_cm"), "x")(2)
                Else
                    mLength_cm = 0
                    mwidth_cm = 0
                    mheight_cm = 0
                End If
                gspStr = "sp_insert_SACTNDIM '" & gsCompany & "','" & txtInvNo.Text & "','" & _
                dr_SACTNDIM_ins(i).Item("scd_invseq") & "','" & dr_SACTNDIM_ins(i).Item("scd_ctnseq") & "','" & _
                dr_SACTNDIM_ins(i).Item("scd_ctnno") & "','" & _
                mLength_in & "','" & mwidth_in & "','" & mheight_in & "','" & _
                mLength_cm & "','" & mwidth_cm & "','" & mheight_cm & "','" & _
                dr_SACTNDIM_ins(i).Item("scd_grswgt") & "','" & dr_SACTNDIM_ins(i).Item("scd_netwgt") & "','" & _
                Replace(dr_SACTNDIM_ins(i).Item("scd_rmk"), "'", "''") & "','" & gsUsrID & "'"

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_SACTNDIM_ins, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SAM00003 sp_insert_SACTNDIM : " & rtnStr)
                    IsAdded = False
                End If
            Next
        End If

        '    '**********************************************
        '    '*** Update Carton  Dimension Record        ***
        '    '**********************************************


        Dim dr_SACTNDIM_upd() As DataRow = rs_SACTNDIM.Tables("RESULT").Select("scd_creusr = '~*UPD*~'")

        If dr_SACTNDIM_upd.Length() <= 0 Then
            IsUpdated = True
        Else
            For i As Integer = 0 To dr_SACTNDIM_upd.Length() - 1
                'get_dimension()
                If dr_SACTNDIM_ins(i).Item("scd_inch") <> "" Then
                    mLength_in = Split(dr_SACTNDIM_ins(i).Item("scd_inch"), "x")(0)
                    mwidth_in = Split(dr_SACTNDIM_ins(i).Item("scd_inch"), "x")(1)
                    mheight_in = Split(dr_SACTNDIM_ins(i).Item("scd_inch"), "x")(2)
                Else
                    mLength_in = 0
                    mwidth_in = 0
                    mheight_in = 0
                End If

                If dr_SACTNDIM_ins(i).Item("scd_cm") <> "" Then
                    mLength_cm = Split(dr_SACTNDIM_ins(i).Item("scd_cm"), "x")(0)
                    mwidth_cm = Split(dr_SACTNDIM_ins(i).Item("scd_cm"), "x")(1)
                    mheight_cm = Split(dr_SACTNDIM_ins(i).Item("scd_cm"), "x")(2)
                Else
                    mLength_cm = 0
                    mwidth_cm = 0
                    mheight_cm = 0
                End If
                gspStr = "sp_update_SACTNDIM '" & gsCompany & "','" & txtInvNo.Text & "','" & _
                dr_SACTNDIM_ins(i).Item("scd_invseq") & "','" & dr_SACTNDIM_ins(i).Item("scd_ctnseq") & "','" & _
                dr_SACTNDIM_ins(i).Item("scd_ctnno") & "','" & _
                mLength_in & "','" & mwidth_in & "','" & mheight_in & "','" & _
                mLength_cm & "','" & mwidth_cm & "','" & mheight_cm & "','" & _
                dr_SACTNDIM_ins(i).Item("scd_grswgt") & "','" & dr_SACTNDIM_ins(i).Item("scd_netwgt") & "','" & _
                Replace(dr_SACTNDIM_ins(i).Item("scd_rmk"), "'", "''") & "','" & gsUsrID & "'"

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_SACTNDIM_ins, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SAM00003 sp_update_SACTNDIM : " & rtnStr)
                    IsUpdated = False
                End If
            Next
        End If

        If Not (IsDeleted Or IsAdded Or IsUpdated) Then
            MsgBox("Cannot update Unofficial Address!")
        End If

        ''***************************************************
        ''***************************************************
        ''***************************************************

        Call setStatus("Save")
        Add_flag = False

        If txtInvNo.Enabled Then
            txtInvNo.Focus()
        End If
        txtInvNo.Text = InvNo
        txtInvNo.SelectionStart = 0
        txtInvNo.SelectionLength = Len(txtInvNo.Text)
    End Sub

    Private Function not_in_Combo() As Boolean
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        '*** Item & Color   'CARE
        If cboItmCol.Enabled = True And cboItmCol.Items.Count > 0 Then
            inCombo = False
            i = cboItmCol.Items.Count
            For Y = 0 To i - 1
                If cboItmCol.Text = cboItmCol.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False And cboItmCol.Enabled = True Then
                MsgBox("Item & Color - Data is Invalid, please select in Drop Down List.")
                Me.TabPageMain.SelectedIndex = 1
                cboItmCol.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        If cboVenItmCol.Enabled = True And cboVenItmCol.Items.Count > 0 Then
            inCombo = False
            i = cboVenItmCol.Items.Count
            For Y = 0 To i - 1
                If cboVenItmCol.Text = cboVenItmCol.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False And cboVenItmCol.Enabled = True Then
                MsgBox("Item & Color - Data is Invalid, please select in Drop Down List.")
                Me.TabPageMain.SelectedIndex = 1
                cboVenItmCol.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        If cboTmpItmCol.Enabled = True And cboTmpItmCol.Items.Count > 0 Then
            inCombo = False
            i = cboTmpItmCol.Items.Count
            For Y = 0 To i - 1
                If cboTmpItmCol.Text = cboTmpItmCol.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False And cboTmpItmCol.Enabled = True Then
                MsgBox("Item & Color - Data is Invalid, please select in Drop Down List.")
                Me.TabPageMain.SelectedIndex = 1
                cboTmpItmCol.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If


        '*** Packing
        If cboPck.Enabled = True And cboPck.Items.Count > 0 Then
            inCombo = False
            i = cboPck.Items.Count
            For Y = 0 To i - 1
                If cboPck.Text = cboPck.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False And cboPck.Enabled = True Then
                MsgBox("Packing - Data is Invalid, please select in Drop Down List.")
                Me.TabPageMain.SelectedIndex = 1
                cboPck.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        '*** Primary Customer
        If cboCus1No.Enabled = True And cboCus1No.Items.Count > 0 Then
            inCombo = False
            i = cboCus1No.Items.Count
            For Y = 0 To i - 1
                If cboCus1No.Text = cboCus1No.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Primary Customer - Data is Invalid, please select in Drop Down List.") 'msg("M00397")
                Me.TabPageMain.SelectedIndex = 0
                cboCus1No.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        '*** Contact Person - Primary Customer
        If cboCus1Cp.Text <> "" And cboCus1Cp.Enabled = True And cboCus1Cp.Items.Count > 0 Then
            inCombo = False
            i = cboCus1Cp.Items.Count
            For Y = 0 To i - 1
                If cboCus1Cp.Text = cboCus1Cp.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Contact Person of Primary Customer - Data is Invalid, please select in Drop Down List.") 'msg("M00398") 
                Me.TabPageMain.SelectedIndex = 0
                cboCus1Cp.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        '*** Secondary Customer
        If cboCus2No.Text <> "" And cboCus2No.Enabled = True And cboCus2No.Items.Count > 0 Then
            inCombo = False
            i = cboCus2No.Items.Count
            For Y = 0 To i - 1
                If cboCus2No.Text = cboCus2No.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Secondary Customer - Data is Invalid, please select in Drop Down List.") 'msg("M00399")  
                Me.TabPageMain.SelectedIndex = 0
                cboCus2No.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        '*** Contact Person - Secondary Customer
        If cboCus2Cp.Text <> "" And cboCus2Cp.Enabled = True And cboCus2Cp.Items.Count > 0 Then
            inCombo = False
            i = cboCus2Cp.Items.Count
            For Y = 0 To i - 1
                If cboCus2Cp.Text = cboCus2Cp.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Contact Person of Secondary Customer - Data is Invalid, please select in Drop Down List.") 'msg("M00400")
                Me.TabPageMain.SelectedIndex = 0
                cboCus2Cp.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        '*** Agent
        If cboCusAgt.Text <> "" And cboCusAgt.Enabled = True And cboCusAgt.Items.Count > 0 Then
            inCombo = False
            i = cboCusAgt.Items.Count
            For Y = 0 To i - 1
                If cboCusAgt.Text = cboCusAgt.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Agent - Data is Invalid, please select in Drop Down List.") 'msg("M00401")  
                Me.TabPageMain.SelectedIndex = 0
                cboCusAgt.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If

        '*** Sales Rep
        If cboSalRep.Text <> "" And cboSalRep.Enabled = True And cboSalRep.Items.Count > 0 Then
            inCombo = False
            i = cboSalRep.Items.Count
            For Y = 0 To i - 1
                If cboSalRep.Text = cboSalRep.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Sales Rep - Data is Invalid, please select in Drop Down List.") 'msg("M00402") 
                Me.TabPageMain.SelectedIndex = 0
                cboSalRep.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If


        '*** Sales Team
        If cboSalTem.Text <> "" And cboSalTem.Enabled = True And cboSalTem.Items.Count > 0 Then
            inCombo = False
            i = cboSalTem.Items.Count
            For Y = 0 To i - 1
                If cboSalTem.Text = cboSalTem.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Sales Team - Data is Invalid, please select in Drop Down List.") 'msg("M00402") 
                Me.TabPageMain.SelectedIndex = 0
                cboSalTem.Focus()
                not_in_Combo = True
                Exit Function
            End If
        End If
    End Function

    Private Function InputIsValid() As Boolean
        Dim Err As String
        Dim isValid As Boolean
        isValid = True
        InputIsValid = True

        isValid = Valid_ChgQty()

        If isValid = True Then
            InputIsValid = True
        Else
            InputIsValid = False
        End If
    End Function


    Private Function Valid_ChgQty() As Boolean
        Valid_ChgQty = True

        If txtChgQty.Enabled = False Then Exit Function
        If txtChgQty.Text = "" Then txtChgQty.Text = 0


        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        If txtShpQty.Text = 0 Then
            If txtChgQty.Text = 0 Then
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = 0
                txtBalFreQty.Text = 0
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = 0
                Valid_ChgQty = False

                Exit Function
            End If
        End If

        Dim tmpshpqty As Long
        Dim tmpchgqty As Long
        Dim tmpbalfreqty As Long

        tmpshpqty = CLng(txtOutShpQty.Text)
        tmpchgqty = CLng(txtOutChgQty.Text) '+ CLng(txtOutFreQty.Text)
        tmpbalfreqty = CLng(txtOutFreQty.Text) ' + CLng(txtOutChgQty.Text)

        Dim Bkmark As Integer
        'Dim rs As New ADOR.Recordset
        'rs = CopyRS(rs_SAINVDTL)
        'If rs.RecordCount > 0 Then
        '    Bkmark = rs.AbsolutePosition
        '    rs.MoveFirst()
        '    While Not rs.EOF
        '        If rs("sid_itmcol") = cboItmCol.Text Then
        '            If rs.AbsolutePosition <> Bkmark Then
        '                If rs("sid_creusr") <> "~*DEL*~" And rs("sid_creusr") <> "~*NEW*~" Then
        '                    tmpshpqty = tmpshpqty - (rs("sid_shpqty") - rs("sid_orgshpqty"))
        '                    tmpchgqty = tmpchgqty - (rs("sid_chgqty") - rs("sid_orgchgqty")) + (rs("sid_balfreqty") - rs("sid_orgfreqty"))
        '                    tmpbalfreqty = tmpbalfreqty - (rs("sid_balfreqty") - rs("sid_orgfreqty")) + (rs("sid_chgqty") - rs("sid_orgchgqty"))
        '                End If
        '            End If
        '        End If
        '        rs.MoveNext()
        '    End While
        '    rs.Close()
        'End If 'againfk

        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String
        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If


        Dim rs As DataSet = rs_SAINVDTL.Copy
        If rs.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
                If rs.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                    If i = current_Row Then
                        If rs.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And rs.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                            tmpshpqty = tmpshpqty - (rs.Tables("RESULT").Rows(i).Item("sid_shpqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                            tmpchgqty = tmpchgqty - (rs.Tables("RESULT").Rows(i).Item("sid_chgqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgchgqty")) + (rs.Tables("RESULT").Rows(i).Item("sid_balfreqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                            tmpbalfreqty = tmpbalfreqty - (rs.Tables("RESULT").Rows(i).Item("sid_balfreqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgfreqty")) + (rs.Tables("RESULT").Rows(i).Item("sid_chgqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                        End If
                    End If
                End If
            Next
        End If


        'If tmpchgqty < (CLng(txtChgQty.Text) - CLng(txtOrgChgQty.Text)) Then
        '    MsgBox "Exceed the outstanding Charge Qty " & tmpchgqty + CLng(txtOrgChgQty.Text)
        '    txtChgQty.SetFocus
        '    txtChgQty.SelStart = 0
        '    txtChgQty.SelLength = Len(txtChgQty.Text)
        '    Valid_ChgQty = False
        '    Exit Function
        'End If

        If CLng(txtChgQty.Text) > CLng(txtShpQty.Text) Then
            MsgBox("Charge Qty should be smaller than or equal to Ship Qty")
            If txtChgQty.Enabled Then
                txtChgQty.Focus()
            End If
            txtChgQty.SelectionStart = 0
            txtChgQty.SelectionLength = Len(txtChgQty.Text)
            Valid_ChgQty = False
            Exit Function
        End If

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

        txtBalFreQty.Text = CLng(txtShpQty.Text) - CLng(txtChgQty.Text)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text

        txtTtlAmtD.Text = round(CDbl(txtSelPrcD.Text) * CDbl(txtChgQty.Text), 4)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ttlamt") = txtTtlAmtD.Text

        If CLng(txtShpQty.Text) <> (CLng(txtChgQty.Text) + CLng(txtBalFreQty.Text)) Then
            MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
            If txtShpQty.Enabled Then
                txtShpQty.Focus()
            End If
            txtShpQty.SelectionStart = 0
            txtShpQty.SelectionLength = Len(txtShpQty.Text)
            Valid_ChgQty = False
            Exit Function
        End If

        If CLng(txtBalFreQty.Text) > (tmpbalfreqty + CLng(txtOrgFreQty.Text)) Then
            'MsgBox "Free Qty should be smaller than or equal to " & (tmpbalfreqty + CLng(txtOrgFreQty.Text))
            'MsgBox "Invoice will be held for approval"

            'txtChgQty.Text = 0
            'rs_SAINVDTL("sid_chgqty") = 0

            'txtBalFreQty.Text = 0
            'rs_SAINVDTL("sid_balfreqty") = 0

            'txtShpQty.SetFocus
            'txtShpQty.SelStart = 0
            'txtShpQty.SelLength = Len(txtShpQty.Text)
        End If
    End Function
    Private Function checkTimeStamp() As Boolean

        Dim Save_TimeStamp As Long

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_SAINVHDR '" & gsCompany & "','" & txtInvNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAINVHDR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading checkTimeStamp sp_select_SAINVHDR :" & rtnStr)
        Else
            Save_TimeStamp = rs_SAINVHDR.Tables("RESULT").Rows(0).Item("sih_timstp")
        End If

        If Current_TimeStamp <> Save_TimeStamp Then
            checkTimeStamp = False
        Else
            checkTimeStamp = True
        End If

    End Function
    Public Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If
        ValidateCombo = False
        Dim i As Integer
        Dim S As String
        S = Combo1.Text
        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items.Item(i)) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next
        If Not ValidateCombo Then
            MsgBox("Invalid Data! Please try again.") 'msg("M00018")
            On Error Resume Next
            Combo1.Focus()
            'On Error GoTo 0
        End If
    End Function

    Private Sub cboCus1Cy_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1Cy.Leave
        If ValidateCombo(cboCus1Cy) = True Then
            Call cboCus1Cy_TextChanged(Me, e)
        End If
    End Sub


    Private Sub cboCus1No_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1No.SelectedIndexChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        Recordstatus = True
    End Sub

    Private Sub cboCus2No_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2No.SelectedIndexChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        Recordstatus = True

        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
        If rs_CUBASINF_S.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
        'rs_CUBASINF_S.Filter = "cbi_cus2no = '" + GetCtrlValue(cboCus2No) + "'"
        Dim drCUBASINF_S() As DataRow = rs_CUBASINF_S.Tables("RESULT").Select("cbi_cus2no = '" + GetCtrlValue(cboCus2No) + "'")
        If drCUBASINF_S.Length > 0 Then
            txtCus2Ad.Text = drCUBASINF_S(0).Item("cci_cntadr")
            txtCus2St.Text = drCUBASINF_S(0).Item("cci_cntstt")
            cboCus2Cy.Text = IIf((drCUBASINF_S(0).Item("cci_cntcty")) Is Nothing, "", IIf(drCUBASINF_S(0).Item("cci_cntcty") = " - ", "", drCUBASINF_S(0).Item("cci_cntcty")))
            txtCus2Zp.Text = drCUBASINF_S(0).Item("cci_cntpst")
        Else
            txtCus2Ad.Text = ""
            txtCus2St.Text = ""
            cboCus2Cy.Text = ""
            txtCus2Zp.Text = ""
        End If
        'rs_CUBASINF_S.Filter = ""
        Call enableCus2Addr()
        flg_DisplaySampleHeaderData = False
    End Sub

    Private Sub txtChgQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChgQty.KeyPress
        'Dim KeyAscii As Long = Asc(e.KeyChar)
        'If ((KeyAscii > 26) Or (KeyAscii < 0)) And (InStr("0123456789", Chr(KeyAscii)) = 0) Then
        '    'KeyAscii = 0
        '    MsgBox("Please input integer value.") 'msg("M00249")
        '    Exit Sub
        'End If
        If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            MsgBox("Please input integer value.") 'msg("M00249")
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtChgQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChgQty.Leave
        If txtChgQty.Enabled = False Then Exit Sub
        If txtChgQty.Text = "" Then txtChgQty.Text = 0

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        If txtShpQty.Text = 0 Then
            If txtChgQty.Text = 0 Then
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = 0
                txtBalFreQty.Text = 0
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = 0
                Exit Sub
            End If
        End If

        Call calculateDetailFreeQtyField(False)

        Dim tmpshpqty As Long
        Dim tmpchgqty As Long
        Dim tmpbalfreqty As Long

        tmpshpqty = CLng(txtOutShpQty.Text)
        tmpchgqty = CLng(txtOutChgQty.Text) '+ CLng(txtOutFreQty.Text)
        tmpbalfreqty = CLng(txtOutFreQty.Text) ' + CLng(txtOutChgQty.Text)

        'ho

        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String
        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If

        'Dim Bkmark As Integer
        Dim temp_rs_SAINVDTL As DataSet
        temp_rs_SAINVDTL = rs_SAINVDTL.Copy
        If temp_rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
            'Bkmark = rs.AbsolutePosition
            'rs.MoveFirst()
            'While Not rs.EOF
            For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
                temp_rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                    If i <> current_Row Then
                        If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                            tmpshpqty = tmpshpqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                            tmpchgqty = tmpchgqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty")) + (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                            tmpbalfreqty = tmpbalfreqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty")) + (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                        End If
                    End If
                End If
            Next
            'rs.MoveNext()
            'End While
            'rs.Close()
        End If

        If tmpchgqty < (CLng(txtChgQty.Text) - CLng(txtOrgChgQty.Text)) Then
            If vbCancel = MsgBox("Exceed the outstanding Charge Qty " & tmpchgqty + CLng(txtOrgChgQty.Text), vbOKCancel, "Question") Then
                If txtChgQty.Enabled Then
                    txtChgQty.Focus()
                End If
                txtChgQty.SelectionStart = 0
                txtChgQty.SelectionLength = Len(txtChgQty.Text)
                Exit Sub
            Else
                'txtBalFreQty.Text = CLng(txtShpQty.Text) - CLng(txtChgQty.Text)
            End If
        End If

        If CLng(txtChgQty.Text) > CLng(txtShpQty.Text) Then
            MsgBox("Charge Qty should be smaller than or equal to Ship Qty")
            If txtChgQty.Enabled Then
                txtChgQty.Focus()
            End If
            txtChgQty.SelectionStart = 0
            txtChgQty.SelectionLength = Len(txtChgQty.Text)
            Exit Sub
        End If
        If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") <> CLng(txtChgQty.Text) Then SetSampleDetailUpdateFlag()
        'rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Columns("sid_chgqty").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Columns("sid_balfreqty").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Columns("sid_ttlamt").ReadOnly = False
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text

        txtTtlAmtD.Text = round(CDbl(txtSelPrcD.Text) * CDbl(txtChgQty.Text), 4)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ttlamt") = txtTtlAmtD.Text
        rs_SAINVDTL.Tables("RESULT").Columns("sid_chgqty").ReadOnly = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_balfreqty").ReadOnly = True
        rs_SAINVDTL.Tables("RESULT").Columns("sid_ttlamt").ReadOnly = True
        If CLng(txtShpQty.Text) <> (CLng(txtChgQty.Text) + CLng(txtBalFreQty.Text)) Then
            MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
            If txtShpQty.Enabled Then
                txtShpQty.Focus()
            End If
            txtShpQty.SelectionStart = 0
            txtShpQty.SelectionLength = Len(txtShpQty.Text)
            Exit Sub
        End If

        If txtFreQty.Text < 0 Then
            Dim reply As Integer
            reply = MsgBox("Free Qty is greater than " & sampleFreeQty, vbOKCancel)
            If reply <> 1 Then
                If txtChgQty.Enabled Then
                    txtChgQty.Focus()
                End If
                txtChgQty.SelectionLength = Len(txtChgQty.Text)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtDiscnt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscnt.TextChanged
        If flg_DisplaySampleHeaderData Then Exit Sub
        txtRvsDat.Text = SERVER_DATE
    End Sub

    Private Sub txtDiscnt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscnt.KeyPress
        'Dim KeyAscii As Long = Asc(e.KeyChar)
        'If ((KeyAscii > 26) Or (KeyAscii < 0)) And (InStr("0123456789", Chr(KeyAscii)) = 0) Then
        '    'KeyAscii = 0
        '    MsgBox("Please input integer value.") 'msg("M00249")
        '    Exit Sub
        'End If
        If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            MsgBox("Please input integer value.") 'msg("M00249")
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtDiscnt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscnt.Leave
        If txtDiscnt.Enabled = False Then Exit Sub
        If txtDiscnt.Text = "" Then txtDiscnt.Text = 0
        If txtDiscnt.Text = 0 Then
        End If
        gsNetAmtPct = 100 - txtDiscnt.Text
        txtNetAmtI.Text = round2(CDbl(IIf(txtTtlAmtI.Text = "", 0, txtTtlAmtI.Text)) * gsNetAmtPct / 100)
    End Sub

    Private Sub chkDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDel.CheckedChanged
        If flg_DisplaySampleDetailData Then Exit Sub
        If chkDel.Enabled = False Then Exit Sub

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next



        If chkDel.Checked = True Then
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("DEL") = "Y"
            If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*ADD*~" Then
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*NEW*~"
            Else
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*DEL*~"
            End If

            '******** Johnson Oct 15,2002
            txtRvsDat.Text = SERVER_DATE
            '******** Johnson Oct 15,2002 end

            txtShpQty.Text = 0
            txtChgQty.Text = 0
            txtBalFreQty.Text = 0
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = 0
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = 0
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = 0

        Else
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("DEL") = ""
            If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*NEW*~" Then
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*ADD*~"
            Else
                rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_creusr") = "~*UPD*~"
            End If

            '******** Johnson Oct 15,2002
            txtRvsDat.Text = SERVER_DATE
            '******** Johnson Oct 15,2002 end

        End If
        Call SetStatusSampleInvoiceDetail()

        If chkDel.Checked = False And cboItmCol.Enabled = True Then
            cboItmCol.Focus()
        ElseIf chkDel.Checked = False And cboTmpItmCol.Enabled = True Then
            cboTmpItmCol.Focus()
        ElseIf chkDel.Checked = False And cboVenItmCol.Enabled = True Then
            cboVenItmCol.Focus()
        End If

        'rs_SAINVDTL.Update()
    End Sub
    Private Sub SAM00003_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode >= 112 And e.KeyCode <= 123 Then
            Call DefinedKey(sender, e)
        End If
        '------------------------------------------
        'Call MapEnterToTab(Me, KeyAscii)
        '------------------------------------------
    End Sub

    Private Sub DefinedKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If (KeyCode = vbKeyF3) And (cmdClear.Enabled = True) Then
        '    Call cmdClear_Click()     'Hot Key for Clear (F3)

        'ElseIf (KeyCode = vbKeyF5) And (cmdfirst.Enabled = True) Then
        '    Call cmdfirst_Click()     'Hot Key for Move First (F5)

        'ElseIf (KeyCode = vbKeyF6) And (cmdPrv.Enabled = True) Then
        '    Call cmdPrv_Click()       'Hot Key for Move Previous (F6)

        'ElseIf (KeyCode = vbKeyF7) And (cmdNext.Enabled = True) Then
        '    Call cmdNext_Click()      'Hot Key for Move Next (F7)

        'ElseIf (KeyCode = vbKeyF8) And (cmdlast.Enabled = True) Then
        '    Call cmdlast_Click()      'Hot Key for Move Last (F8)
        'End If

        If (e.KeyCode = 114) And (mmdClear.Enabled = True) Then
            Call mmdClear_Click(sender, e)     'Hot Key for Clear (F3)
        End If

    End Sub
    'Public Sub MapEnterToTab(ByVal f As Form, ByVal KeyCode As Integer)
    '    If KeyCode = 13 Then
    '        If TypeOf f.ActiveControl Is TextBox Then
    '            If f.ActiveControl.MultiLine = False Then
    '                SendKeys.Send("{TAB}")
    '            End If
    '        Else
    '            SendKeys.Send("{TAB}")
    '        End If
    '    End If
    'End Sub




    Private Sub txtInvNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvNo.Leave
        txtInvNo.Text = UCase(Trim(txtInvNo.Text))
    End Sub

    Private Sub txtShpQty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpQty.Enter
        txtShpQty.SelectionStart = 0
        txtShpQty.SelectionLength = Len(txtShpQty.Text)
    End Sub

    Private Sub txtShpQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpQty.KeyPress
        'Dim KeyAscii As Long = Asc(e.KeyChar)
        'If ((KeyAscii > 26) Or (KeyAscii < 0)) And (InStr("0123456789", Chr(KeyAscii)) = 0) Then
        '    'KeyAscii = 0
        '    MsgBox("Please input integer value.") 'msg("M00249")
        '    Exit Sub
        'End If
        If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            MsgBox("Please input integer value.") 'msg("M00249")
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtShpQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpQty.Leave
        If txtShpQty.Enabled = False Then Exit Sub
        If flg_DisplaySampleDetailData Then Exit Sub
        If txtShpQty.Text = "" Then txtShpQty.Text = 0
        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        If txtShpQty.Text = 0 Then
            txtChgQty.Text = 0
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = 0
            txtBalFreQty.Text = 0
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = 0
            Exit Sub
        End If

        Call calculateDetailFreeQtyField(False)

        Dim tmpshpqty As Long
        Dim tmpchgqty As Long
        Dim tmpbalfreqty As Long

        tmpshpqty = CLng(txtOutShpQty.Text)
        tmpchgqty = CLng(txtOutChgQty.Text)
        tmpbalfreqty = CLng(txtOutFreQty.Text)

        'fkno

        Dim cboitmno As String

        Dim itmcol As String
        Dim itmno As String

        Dim colcde As String
        Dim itmnoven As String
        If cboItmCol.Text <> "" Then
            cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
            colcde = Split(cboItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboTmpItmCol.Text <> "" Then
            cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
            colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
        ElseIf cboVenItmCol.Text <> "" Then
            cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
            colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
            itmno = Split(cboitmno, " / ")(0).ToString
            itmnoven = Split(cboitmno, " / ")(1).ToString

            itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

        End If


        Dim temp_rs_SAINVDTL As DataSet
        temp_rs_SAINVDTL = rs_SAINVDTL.Copy

        If temp_rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then

            For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                    If i <> current_Row Then
                        If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                            tmpshpqty = tmpshpqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                            tmpchgqty = tmpchgqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                            tmpbalfreqty = tmpbalfreqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                        End If
                    End If
                End If
            Next
        End If

        If tmpshpqty - (CLng(txtShpQty.Text) - CLng(txtOrgShpQty.Text)) < 0 Then
            MsgBox("Exceed the outstanding Ship Qty = " & (tmpshpqty + CLng(txtOrgShpQty.Text)))
            txtShpQty.SelectionStart = 0
            txtShpQty.SelectionLength = Len(txtShpQty.Text)
            Trigger_Chgqty = False

            Me.TabPageMain.SelectedIndex = 1
            If txtShpQty.Enabled Then
                txtShpQty.Focus()
            End If

            Exit Sub
        End If

        Trigger_Chgqty = True

        txtTtlAmtD.Text = round(CDbl(txtSelPrcD.Text) * CLng(txtChgQty.Text), 4)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ttlamt") = txtTtlAmtD.Text


        If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") <> CLng(txtShpQty.Text) Then Call SetSampleDetailUpdateFlag()

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text


    End Sub


    Private Sub cboItmCol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItmCol.SelectedIndexChanged
        cboPck.Items.Clear()
    End Sub

    Private Sub cboItmCol_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItmCol.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            cboItmCol_Leave(sender, e)
        End If
    End Sub

    Private Sub SAM00003_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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



    Private Sub cboCus1No_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCus1No.Validating
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboCus1Cp.Items.Count
        If cboCus1Cp.Text <> "" And cboCus1Cp.Enabled = True And cboCus1Cp.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboCus1Cp.Text = cboCus1Cp.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Primary Customer - Data is Invalid, please select in Drop Down List.")
                Me.TabPageMain.SelectedIndex = 0
                If cboCus1No.Enabled Then
                    cboCus1No.Focus()
                End If
                Exit Sub
            End If
        End If
        'End If
        If cboCus1No.Text <> "" And cboCus1No.Items.Count <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboCus1No.Text = ""
            If cboCus1No.Enabled Then
                cboCus1No.Focus()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub grdSummary_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdSummary.CellBeginEdit
        grdsumvalue = grdSummary.CurrentCell.Value
    End Sub

    Private Sub grdSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim dr() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("", "sid_invseq")

                For index As Integer = 0 To dr.Length - 1
                    If rs_SAINVDTL.Tables("RESULT").DefaultView(e.RowIndex)("sid_invseq") = dr(index)("sid_invseq") Then
                        current_Row = index
                    End If
                Next
            End If

        Catch ex As Exception
            ' for the case that add new details, skip the cell enter event
        End Try
    End Sub

    Private Sub grdSummary_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellEndEdit

        Dim tmpseq As String
        Dim curseq As String
        tmpseq = ""
        curseq = grdSummary.Item(3, e.RowIndex).Value

        Dim i As Integer
        Dim loc As Integer

        loc = -1

        For i = 0 To rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
            tmpseq = rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_invseq")
            If tmpseq = curseq Then
                loc = i
                Exit For
            End If
        Next i

        If loc = -1 Then
            Exit Sub
        End If

        '-----------------''fku'
        If e.ColumnIndex = 21 Then 'ShipQty
            If txtShpQty.Enabled = False Then Exit Sub
            If flg_DisplaySampleDetailData Then Exit Sub
            If rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty").ToString = "" Then rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty") = 0

            For i = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
                rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next

            If rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty") = 0 Then
                '  txtChgQty.Text = 0
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty") = 0
                ' txtBalFreQty.Text = 0
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_balfreqty") = 0
                Exit Sub
            End If

            Call SumcalculateDetailFreeQtyField(False, loc)

            Dim tmpshpqty As Long
            Dim tmpchgqty As Long
            Dim tmpbalfreqty As Long

            tmpshpqty = CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_outshpqty"))
            tmpchgqty = CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_outchgqty"))
            tmpbalfreqty = CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_outfreqty"))


            Dim temp_rs_SAINVDTL As DataSet
            temp_rs_SAINVDTL = rs_SAINVDTL.Copy

            If temp_rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then

                For i = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_itmcol") Then
                        If i <> loc Then
                            If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                                tmpshpqty = tmpshpqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                                tmpchgqty = tmpchgqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                                tmpbalfreqty = tmpbalfreqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                            End If
                        End If
                    End If
                Next
            End If

            If tmpshpqty - (CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty")) - CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_orgshpqty"))) < 0 Then
                MsgBox("Exceed the outstanding Ship Qty = " & (tmpshpqty + CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_orgshpqty"))))
                'txtShpQty.SelectionStart = 0
                ' txtShpQty.SelectionLength = Len(txtShpQty.Text)
                Trigger_Chgqty = False

                '  Me.TabPageMain.SelectedIndex = 1
                If txtShpQty.Enabled Then
                    '     txtShpQty.Focus()
                End If

                Exit Sub
            End If

            Trigger_Chgqty = True

            rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_ttlamt") = round(CDbl(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_selprc")) _
                                                                              * CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty")), 4)
            'rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_ttlamt") = txtTtlAmtD.Text


            ' If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") <> CLng(txtShpQty.Text) Then Call

            'SetSampleDetailUpdateFlag()
            'Get from ^ 'not the best sol

            If grdsumvalue <> rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty") Then
                If rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*ADD*~" And _
                   rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*UPD*~" And _
                   rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*DEL*~" And _
                   rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*NEW*~" Then
                    rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = False
                    rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") = "~*UPD*~"
                    rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = True
                    'rs_SAINVHDR("sih_rvsdat") = Format(Date, "mm/dd/yyyy")
                End If
                '******** Johnson Oct 15,2002
                txtRvsDat.Text = SERVER_DATE
            End If '******** Johnson Oct 15,2002 end


            DisplaySampleInvoiceDetailSum(loc)
        ElseIf e.ColumnIndex = 23 Then 'ChgQty


            If txtChgQty.Enabled = False Then Exit Sub


            If rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty").ToString = "" Then rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty") = 0

            For i = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
                rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next

            If rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty") = 0 Then
                '  txtChgQty.Text = 0
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty") = 0
                ' txtBalFreQty.Text = 0
                rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_balfreqty") = 0
                Exit Sub
            End If




            Call SumcalculateDetailFreeQtyField(False, loc)

            Dim tmpshpqty As Long
            Dim tmpchgqty As Long
            Dim tmpbalfreqty As Long

            tmpshpqty = CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_outshpqty"))
            tmpchgqty = CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_outchgqty"))
            tmpbalfreqty = CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_outfreqty"))

            'sss

            Dim cboitmno As String

            Dim itmcol As String
            Dim itmno As String

            Dim colcde As String
            Dim itmnoven As String
            If cboItmCol.Text <> "" Then
                cboitmno = Split(cboItmCol.Text, " : ")(0).ToString
                colcde = Split(cboItmCol.Text, " : ")(1).ToString
                itmno = Split(cboitmno, " / ")(0).ToString
                itmnoven = Split(cboitmno, " / ")(1).ToString

                itmcol = itmno + " / " + "" + " / " + "" + " / " + itmnoven + " : " + colcde
            ElseIf cboTmpItmCol.Text <> "" Then
                cboitmno = Split(cboTmpItmCol.Text, " : ")(0).ToString
                colcde = Split(cboTmpItmCol.Text, " : ")(1).ToString
                itmno = Split(cboitmno, " / ")(0).ToString
                itmnoven = Split(cboitmno, " / ")(1).ToString

                itmcol = "" + " / " + itmno + " / " + "" + " / " + itmnoven + " : " + colcde
            ElseIf cboVenItmCol.Text <> "" Then
                cboitmno = Split(cboVenItmCol.Text, " : ")(0).ToString
                colcde = Split(cboVenItmCol.Text, " : ")(1).ToString
                itmno = Split(cboitmno, " / ")(0).ToString
                itmnoven = Split(cboitmno, " / ")(1).ToString

                itmcol = "" + " / " + "" + " / " + itmno + " / " + itmnoven + " : " + colcde

            End If
            'Dim Bkmark As Integer
            Dim temp_rs_SAINVDTL As DataSet
            temp_rs_SAINVDTL = rs_SAINVDTL.Copy
            If temp_rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                'Bkmark = rs.AbsolutePosition
                'rs.MoveFirst()
                'While Not rs.EOF
                For i = 0 To temp_rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
                    temp_rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
                Next
                For i = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                        If i <> loc Then
                            If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                                tmpshpqty = tmpshpqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                                tmpchgqty = tmpchgqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty")) + (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                                tmpbalfreqty = tmpbalfreqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty")) + (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                            End If
                        End If
                    End If
                Next
                'rs.MoveNext()
                'End While
                'rs.Close()
            End If







            If tmpchgqty < (CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty")) - CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_orgchgqty"))) Then
                If vbCancel = MsgBox("Exceed the outstanding Charge Qty " & tmpchgqty + CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_orgchgqty")), vbOKCancel, "Question") Then
                    'If txtChgQty.Enabled Then
                    '    txtChgQty.Focus()
                    'End If
                    'txtChgQty.SelectionStart = 0
                    'txtChgQty.SelectionLength = Len(txtChgQty.Text)
                    Exit Sub
                Else
                    'txtBalFreQty.Text = CLng(txtShpQty.Text) - CLng(txtChgQty.Text)
                End If
            End If

            If CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty")) > CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty")) Then
                MsgBox("Charge Qty should be smaller than or equal to Ship Qty")
                'If txtChgQty.Enabled Then
                '    txtChgQty.Focus()
                'End If
                'txtChgQty.SelectionStart = 0
                'txtChgQty.SelectionLength = Len(txtChgQty.Text)
                Exit Sub
            End If
            'If rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") <> CLng(txtChgQty.Text) Then

            'End If
            '  SetSampleDetailUpdateFlag() 'be care
            If grdsumvalue <> rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty") Then
                If rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*ADD*~" And _
                   rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*UPD*~" And _
                   rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*DEL*~" And _
                   rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") <> "~*NEW*~" Then
                    rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = False
                    rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_creusr") = "~*UPD*~"
                    'rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = True
                    'rs_SAINVHDR("sih_rvsdat") = Format(Date, "mm/dd/yyyy")
                End If
                '******** Johnson Oct 15,2002
                txtRvsDat.Text = SERVER_DATE
                '******** Johnson Oct 15,2002 end
            End If


            'rs_SAINVDTL.Tables("RESULT").Columns("sid_creusr").ReadOnly = False
            rs_SAINVDTL.Tables("RESULT").Columns("sid_chgqty").ReadOnly = False
            rs_SAINVDTL.Tables("RESULT").Columns("sid_balfreqty").ReadOnly = False
            rs_SAINVDTL.Tables("RESULT").Columns("sid_ttlamt").ReadOnly = False
            '   rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

            '    rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text

            rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_ttlamt") = round(CDbl(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_selprc")) _
                                                                               * CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty")), 4)

            '  rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_ttlamt") = txtTtlAmtD.Text
            'rs_SAINVDTL.Tables("RESULT").Columns("sid_chgqty").ReadOnly = True
            'rs_SAINVDTL.Tables("RESULT").Columns("sid_balfreqty").ReadOnly = True
            'rs_SAINVDTL.Tables("RESULT").Columns("sid_ttlamt").ReadOnly = True
            If CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_shpqty")) <> (CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_chgqty")) + CLng(rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sid_balfreqty"))) Then
                MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
                'If txtShpQty.Enabled Then
                '    txtShpQty.Focus()
                'End If
                'txtShpQty.SelectionStart = 0
                'txtShpQty.SelectionLength = Len(txtShpQty.Text)
                Exit Sub
            End If

            If rs_SAINVDTL.Tables("RESULT").Rows(loc).Item("sas_freqty") < 0 Then
                Dim reply As Integer
                reply = MsgBox("Free Qty is greater than " & sampleFreeQty, vbOKCancel)
                If reply <> 1 Then
                    'If txtChgQty.Enabled Then
                    '    txtChgQty.Focus()
                    'End If
                    'txtChgQty.SelectionLength = Len(txtChgQty.Text)
                    Exit Sub
                End If
            End If


            DisplaySampleInvoiceDetailSum(loc)

        End If

        ' rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text

    End Sub



    Private Sub grdSummary_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellEnter

        'If IsValaidcboitm = False Then
        '    Exit Sub
        'End If

        'Try
        '    If e.RowIndex >= 0 Then
        '        Dim dr() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("", "sid_invseq")

        '        For index As Integer = 0 To dr.Length - 1
        '            If rs_SAINVDTL.Tables("RESULT").DefaultView(e.RowIndex)("sid_invseq") = dr(index)("sid_invseq") Then
        '                current_Row = index
        '            End If
        '        Next
        '    End If

        'Catch ex As Exception
        '    ' for the case that add new details, skip the cell enter event
        'End Try

    End Sub

    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtInvNo.Name
        frmSYM00018.strModule = "SA"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub txtNetAmtI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNetAmtI.TextChanged

    End Sub

    Private Sub SAM00003_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub cboCus1Ad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboSalTem_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSalTem.KeyUp
        auto_search_combo(cboSalTem, e.KeyCode)
    End Sub

    Private Sub cboSalTem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalTem.Leave
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboSalTem.Items.Count
        If cboSalTem.Text <> "" And cboSalTem.Enabled = True And cboSalTem.Items.Count > 0 Then
            For Y = 0 To i - 1

                If cboSalTem.Text = cboSalTem.Items.Item(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("SalesTeam - Data is Invalid, please select in Drop Down List.")   'msg("M00401")
                Me.TabPageMain.SelectedIndex = 0
                If cboSalTem.Enabled Then
                    cboSalTem.Focus()
                End If
                Exit Sub
            End If
        End If

        If cboSalTem.Text <> "" And cboSalTem.Items.Count <= 0 Then
            MsgBox("Drop Down is empty, cannot input other data.")
            cboSalTem.Text = ""
            If cboSalTem.Enabled Then
                cboSalTem.Focus()
            End If
            Exit Sub
        End If
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

        If Trim(cboSalTem.Text) = "" Then
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
                    MsgBox("Error on loading cboSalTem_Validated sp_list_SYUSRPRF_2 :" & rtnStr)
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




    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        Call fillParameter()
    End Sub

    Private Sub txtSelPrcD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelPrcD.TextChanged

    End Sub

    Private Sub cboTmpItmCol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTmpItmCol.Click
        cboPck.Items.Clear()
    End Sub

    Private Sub cboTmpItmCol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTmpItmCol.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            cboTmpItmCol_Leave(sender, e)
        End If
    End Sub

    Private Sub cboTmpItmCol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTmpItmCol.KeyUp
        Call auto_search_combo(cboTmpItmCol, e.KeyCode)
    End Sub

    Private Sub cboTmpItmCol_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTmpItmCol.Leave
        If cboTmpItmCol.Enabled = False Then Exit Sub

        If cboTmpItmCol.Text <> "" Then
            Dim i As Integer
            Dim Y As Integer
            Dim inCombo As Boolean

            i = cboTmpItmCol.Items.Count
            If cboTmpItmCol.Text <> "" And cboTmpItmCol.Enabled = True And i > 0 Then
                For Y = 0 To i - 1
                    If cboTmpItmCol.Text = cboTmpItmCol.Items.Item(Y) Then
                        inCombo = True
                    End If
                Next

                If inCombo = False Then
                    MsgBox("Item & Color - Data is Invalid, please select in Drop Down List.")
                    Me.TabPageMain.SelectedIndex = 1
                    If cboTmpItmCol.Enabled Then
                        cboTmpItmCol.Focus()
                    End If
                    Exit Sub
                End If
            End If
        End If

        'Kenny Add on 20-11-2002
        If cboTmpItmCol.Text <> "" And cboTmpItmCol.Items.Count = 0 Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("No Record found")
            If cboTmpItmCol.Enabled Then cboTmpItmCol.Focus()
            Exit Sub
        End If

        If cboTmpItmCol.Text = "" Then
            '  MsgBox("Item Color should not be empty!") '123''
            tmp_current_row = current_Row
            IsValaidcboitm = False
            Exit Sub
        End If

        If flg_DisplaySampleDetailData Then Exit Sub

        If cboTmpItmCol.Text = "" And cboTmpItmCol.Items.Count > 0 Then
            MsgBox("Item Color should not be empty!")
            If cboTmpItmCol.Enabled Then cboTmpItmCol.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        Dim cboitmno As String = Split(cboTmpItmCol.Text, " : ")(0).ToString    'Here Change
        Dim itmnotmp As String = Split(cboitmno, " / ")(0).ToString
        Dim itmnovenno As String = Split(cboitmno, " / ")(1).ToString
        Dim itmno As String = ""
        Dim itmnoven As String = ""


        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmno") = GetCtrlValue_Colon(cbotmpItmCol)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmno") = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnotmp") = itmnotmp
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnoven") = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnovenno") = itmnovenno

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde") = Split(cboTmpItmCol.Text, " : ")(1)
        txtColCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde")


        Dim itmcol As String = itmno + " / " + itmnotmp + " / " + itmnoven + " / " + itmnovenno + " : " + txtColCde.Text

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmcol") = itmcol



        Recordstatus = True
        Dim temp_rs_SAORDSUM As DataSet = rs_SAORDSUM.Copy
        'rs_SAORDSUM.MoveFirst()



        '*** Modified by Tommy on 19 Sept 2002
        Dim dr_SAORDSUM() As DataRow = rs_SAORDSUM.Tables("RESULT").Select("sas_itmcol = '" & Replace(itmcol, "'", "''") & "'")
        If dr_SAORDSUM.Length > 0 Then
            'The status "OLD" added by Mark Lau 20060917
            If cboTmpItmCol.Enabled = True And (dr_SAORDSUM(0).Item("ibi_itmsts") = "TBC" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "INC" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "DIS" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "OLD") Then
                MsgBox("Item is in Discontinued / Inactive / Old Item / To be confirmed status", vbExclamation)
                cboTmpItmCol.Focus()
                Exit Sub
            End If

            'Added by Mark Lau 20060923
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_alsitmno") = dr_SAORDSUM(0).Item("sas_alsitmno")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_alscolcde") = dr_SAORDSUM(0).Item("sas_alscolcde")

            txtItmTyp.Text = dr_SAORDSUM(0).Item("sas_itmtyp")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmtyp") = txtItmTyp.Text

            txtItmDsc.Text = dr_SAORDSUM(0).Item("sas_itmdsc")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmdsc") = txtItmDsc.Text

            txtFreQty.Text = dr_SAORDSUM(0).Item("sas_freqty")
            sampleFreeQty = txtFreQty.Text
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_freqty") = txtFreQty.Text

            txtShpQty.Text = 0 'rs_SAORDSUM("sas_outshpqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text

            txtOutShpQty.Text = dr_SAORDSUM(0).Item("sas_outshpqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outshpqty") = txtOutShpQty.Text

            txtChgQty.Text = 0 'rs_SAORDSUM("sas_outshpqty") - rs_SAORDSUM("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

            txtOutChgQty.Text = dr_SAORDSUM(0).Item("sas_outchgqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outchgqty") = dr_SAORDSUM(0).Item("sas_outchgqty")

            txtBalFreQty.Text = 0 'rs_SAORDSUM("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = dr_SAORDSUM(0).Item("sas_outfreqty")

            txtOutFreQty.Text = dr_SAORDSUM(0).Item("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outfreqty") = dr_SAORDSUM(0).Item("sas_outfreqty")

            Dim tmpshpqty As Long
            Dim tmpchgqty As Long
            Dim tmpbalfreqty As Long

            tmpshpqty = CLng(txtOutShpQty.Text)
            tmpchgqty = CLng(txtOutChgQty.Text)
            tmpbalfreqty = CLng(txtOutFreQty.Text)

            'Dim Bkmark As Integer
            Dim temp_rs_SAINVDTL As New DataSet
            temp_rs_SAINVDTL = rs_SAINVDTL.Copy
            If temp_rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                'Bkmark = rs1.AbsolutePosition
                'rs1.MoveFirst()
                'While Not rs1.EOF
                For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                        If i <> current_Row Then
                            If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                                tmpshpqty = tmpshpqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                                tmpchgqty = tmpchgqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                                tmpbalfreqty = tmpbalfreqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                            End If
                        End If
                    End If
                Next
                'rs1.MoveNext()
                'End While
                'rs1.Close()
            End If

            If tmpchgqty > tmpshpqty Then
                tmpchgqty = tmpshpqty
            End If

            txtShpQty.Text = tmpshpqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text

            txtChgQty.Text = tmpchgqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

            txtBalFreQty.Text = tmpbalfreqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text
        Else
            MsgBox("No Item, Color found in Sample Order Summary")
            txtItmDsc.Text = ""
            txtShpQty.Text = 0
            txtBalFreQty.Text = 0
            txtChgQty.Text = 0
        End If

        '***************************************************
        '*** Get Sample Order detail record   **************
        '***************************************************
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_list_SAORDDTL2 '" & gsCompany & "','" & GetCtrlValue(cboCus1No) & "','" & _
        itmno & "','" & itmnotmp & "','" & itmnoven & "','" & itmnovenno & "','" & Split(itmcol, " : ")(1) & "'"

        Dim TmpPck As String
        TmpPck = "!@#$$%&*)"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_SAORDDTL2 : " & rtnStr)
        Else
            '==
            cboPck.Items.Clear()
            '==
            If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then
                'rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = "sad_pck"


                Dim dv As DataView = rs_SAORDDTL.Tables("RESULT").DefaultView
                dv.Sort = "sad_pck"
                rs_SAORDDTL.Tables.Remove("RESULT")
                rs_SAORDDTL.Tables.Add(dv.ToTable)


                For i As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
                    'While Not rs_SAORDDTL.EOF
                    'MsgBox(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck"))
                    If TmpPck <> rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck") Then
                        cboPck.Items.Add(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck"))
                        TmpPck = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck")
                    End If
                    '   rs_SAORDDTL.MoveNext()
                    'End While
                Next

                rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = ""
                cboPck.SelectedIndex = -1
                ResetPckData()

            Else
                MsgBox("No Packing in Sample Order Detail")
            End If
        End If
        Call calculateDetailFreeQtyField(False)
        cboItmCol.Enabled = False
        cboVenItmCol.Enabled = False
    End Sub

    Private Sub cboTmpItmCol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTmpItmCol.SelectedIndexChanged

    End Sub

    Private Sub cboVenItmCol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenItmCol.Click
        cboPck.Items.Clear()
    End Sub

    Private Sub cboVenItmCol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVenItmCol.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            cboVenItmCol_Leave(sender, e)
        End If
    End Sub

    Private Sub cboVenItmCol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenItmCol.KeyUp
        Call auto_search_combo(cboVenItmCol, e.KeyCode)
    End Sub

    Private Sub cboVenItmCol_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenItmCol.Leave
        If cboVenItmCol.Enabled = False Then Exit Sub

        If cboVenItmCol.Text <> "" Then
            Dim i As Integer
            Dim Y As Integer
            Dim inCombo As Boolean

            i = cboVenItmCol.Items.Count
            If cboVenItmCol.Text <> "" And cboVenItmCol.Enabled = True And i > 0 Then
                For Y = 0 To i - 1
                    If cboVenItmCol.Text = cboVenItmCol.Items.Item(Y) Then
                        inCombo = True
                    End If
                Next

                If inCombo = False Then
                    MsgBox("Item & Color - Data is Invalid, please select in Drop Down List.")
                    Me.TabPageMain.SelectedIndex = 1
                    If cboVenItmCol.Enabled Then
                        cboVenItmCol.Focus()
                    End If
                    Exit Sub
                End If
            End If
        End If

        'Kenny Add on 20-11-2002
        If cboVenItmCol.Text <> "" And cboVenItmCol.Items.Count = 0 Then
            Me.TabPageMain.SelectedIndex = 1
            MsgBox("No Record found")
            If cboVenItmCol.Enabled Then cboVenItmCol.Focus()
            Exit Sub
        End If

        If cboVenItmCol.Text = "" Then
            '  MsgBox("Item Color should not be empty!") '123''
            tmp_current_row = current_Row
            IsValaidcboitm = False
            Exit Sub
        End If

        If flg_DisplaySampleDetailData Then Exit Sub

        If cboVenItmCol.Text = "" And cboVenItmCol.Items.Count > 0 Then
            MsgBox("Item Color should not be empty!")
            If cboVenItmCol.Enabled Then cboVenItmCol.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
            rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        Dim cboitmno As String = Split(cboVenItmCol.Text, " : ")(0).ToString    'Here Change
        Dim itmnotmp As String = ""
        Dim itmnovenno As String = Split(cboitmno, " / ")(1).ToString
        Dim itmno As String = ""
        Dim itmnoven As String = Split(cboitmno, " / ")(0).ToString


        'rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmno") = GetCtrlValue_Colon(cboVenItmCol)
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmno") = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnotmp") = ""
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnoven") = itmnoven
        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmnovenno") = itmnovenno

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde") = Split(cboVenItmCol.Text, " : ")(1)
        txtColCde.Text = rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_colcde")


        Dim itmcol As String = itmno + " / " + itmnotmp + " / " + itmnoven + " / " + itmnovenno + " : " + txtColCde.Text

        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmcol") = itmcol



        Recordstatus = True
        Dim temp_rs_SAORDSUM As DataSet = rs_SAORDSUM.Copy
        'rs_SAORDSUM.MoveFirst()



        '*** Modified by Tommy on 19 Sept 2002
        Dim dr_SAORDSUM() As DataRow = rs_SAORDSUM.Tables("RESULT").Select("sas_itmcol = '" & Replace(itmcol, "'", "''") & "'")
        If dr_SAORDSUM.Length > 0 Then
            'The status "OLD" added by Mark Lau 20060917
            If cboVenItmCol.Enabled = True And (dr_SAORDSUM(0).Item("ibi_itmsts") = "TBC" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "INC" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "DIS" Or dr_SAORDSUM(0).Item("ibi_itmsts") = "OLD") Then
                MsgBox("Item is in Discontinued / Inactive / Old Item / To be confirmed status", vbExclamation)
                cboVenItmCol.Focus()
                Exit Sub
            End If

            'Added by Mark Lau 20060923
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_alsitmno") = dr_SAORDSUM(0).Item("sas_alsitmno")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_alscolcde") = dr_SAORDSUM(0).Item("sas_alscolcde")

            txtItmTyp.Text = dr_SAORDSUM(0).Item("sas_itmtyp")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmtyp") = txtItmTyp.Text

            txtItmDsc.Text = dr_SAORDSUM(0).Item("sas_itmdsc")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_itmdsc") = txtItmDsc.Text

            txtFreQty.Text = dr_SAORDSUM(0).Item("sas_freqty")
            sampleFreeQty = txtFreQty.Text
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_freqty") = txtFreQty.Text

            txtShpQty.Text = 0 'rs_SAORDSUM("sas_outshpqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text

            txtOutShpQty.Text = dr_SAORDSUM(0).Item("sas_outshpqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outshpqty") = txtOutShpQty.Text

            txtChgQty.Text = 0 'rs_SAORDSUM("sas_outshpqty") - rs_SAORDSUM("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

            txtOutChgQty.Text = dr_SAORDSUM(0).Item("sas_outchgqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outchgqty") = dr_SAORDSUM(0).Item("sas_outchgqty")

            txtBalFreQty.Text = 0 'rs_SAORDSUM("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = dr_SAORDSUM(0).Item("sas_outfreqty")

            txtOutFreQty.Text = dr_SAORDSUM(0).Item("sas_outfreqty")
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sas_outfreqty") = dr_SAORDSUM(0).Item("sas_outfreqty")

            Dim tmpshpqty As Long
            Dim tmpchgqty As Long
            Dim tmpbalfreqty As Long

            tmpshpqty = CLng(txtOutShpQty.Text)
            tmpchgqty = CLng(txtOutChgQty.Text)
            tmpbalfreqty = CLng(txtOutFreQty.Text)

            'Dim Bkmark As Integer
            Dim temp_rs_SAINVDTL As New DataSet
            temp_rs_SAINVDTL = rs_SAINVDTL.Copy
            If temp_rs_SAINVDTL.Tables("RESULT").Rows.Count > 0 Then
                'Bkmark = rs1.AbsolutePosition
                'rs1.MoveFirst()
                'While Not rs1.EOF
                For i As Integer = 0 To temp_rs_SAINVDTL.Tables("RESULT").Rows.Count - 1
                    If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_itmcol") = itmcol Then
                        If i <> current_Row Then
                            If temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
                                tmpshpqty = tmpshpqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_shpqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
                                tmpchgqty = tmpchgqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_chgqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
                                tmpbalfreqty = tmpbalfreqty - (temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_balfreqty") - temp_rs_SAINVDTL.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
                            End If
                        End If
                    End If
                Next
                'rs1.MoveNext()
                'End While
                'rs1.Close()
            End If

            If tmpchgqty > tmpshpqty Then
                tmpchgqty = tmpshpqty
            End If

            txtShpQty.Text = tmpshpqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_shpqty") = txtShpQty.Text

            txtChgQty.Text = tmpchgqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = txtChgQty.Text

            txtBalFreQty.Text = tmpbalfreqty
            rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = txtBalFreQty.Text
        Else
            MsgBox("No Item, Color found in Sample Order Summary")
            txtItmDsc.Text = ""
            txtShpQty.Text = 0
            txtBalFreQty.Text = 0
            txtChgQty.Text = 0
        End If

        '***************************************************
        '*** Get Sample Order detail record   **************
        '***************************************************
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_list_SAORDDTL2 '" & gsCompany & "','" & GetCtrlValue(cboCus1No) & "','" & _
        itmno & "','" & itmnotmp & "','" & itmnoven & "','" & itmnovenno & "','" & Split(itmcol, " : ")(1) & "'"

        Dim TmpPck As String
        TmpPck = "!@#$$%&*)"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_SAORDDTL2 : " & rtnStr)
        Else
            '==
            cboPck.Items.Clear()
            '==
            If rs_SAORDDTL.Tables("RESULT").Rows.Count > 0 Then
                'rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = "sad_pck"


                Dim dv As DataView = rs_SAORDDTL.Tables("RESULT").DefaultView
                dv.Sort = "sad_pck"
                rs_SAORDDTL.Tables.Remove("RESULT")
                rs_SAORDDTL.Tables.Add(dv.ToTable)


                For i As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
                    'While Not rs_SAORDDTL.EOF
                    'MsgBox(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck"))
                    If TmpPck <> rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck") Then
                        cboPck.Items.Add(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck"))
                        TmpPck = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_pck")
                    End If
                    '   rs_SAORDDTL.MoveNext()
                    'End While
                Next

                rs_SAORDDTL.Tables("RESULT").DefaultView.Sort = ""
                cboPck.SelectedIndex = -1
                ResetPckData()

            Else
                MsgBox("No Packing in Sample Order Detail")
            End If
        End If
        Call calculateDetailFreeQtyField(False)

        cboItmCol.Enabled = False
        cboTmpItmCol.Enabled = False
    End Sub

    Private Sub cboVenItmCol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenItmCol.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetItem.Click
        cmdAss.Enabled = False

        cboItmCol.Enabled = True
        cboVenItmCol.Enabled = True
        cboTmpItmCol.Enabled = True

        cboItmCol.Text = ""
        cboVenItmCol.Text = ""
        cboTmpItmCol.Text = ""

        cboItmCol.Text = ""
        cboTmpItmCol.Text = ""
        cboVenItmCol.Text = ""

        txtCusItm.Text = ""
        txtCusSmpPo.Text = ""

        txtItmDsc.Text = ""

        cboPck.Items.Clear()

        txtCusCol.Text = ""
        txtColDsc.Text = ""
        txtColCde.Text = ""

        txtPckUnt.Text = ""
        txtInrQty.Text = 0
        txtMtrQty.Text = 0
        txtCft.Text = 0

        txtSmpUnt.Text = ""
        txtShpQty.Text = 0
        txtBalFreQty.Text = 0
        txtChgQty.Text = 0

        txtSelPrcD.Text = 0
        txtTtlAmtD.Text = 0
        txtUntCdeD.Text = ""
        txtRmkD.Text = ""
        txtItmTyp.Text = ""

        txtFreQty.Text = 0
        txtOutShpQty.Text = 0
        txtOutChgQty.Text = 0
        txtOutFreQty.Text = 0

        txtOrgShpQty.Text = 0
        txtOrgChgQty.Text = 0
        txtOrgFreQty.Text = 0

        txtReqNo.Text = ""
        txtReqSeq.Text = 0

        txtQutNo.Text = ""
        txtQutSeq.Text = 0

        txtVenNo.Text = ""
        txtSubCde.Text = ""

        txtCusVen.Text = ""
        txtCusSub.Text = ""

        txtFCurCde.Text = ""
        txtFtyPrc.Text = 0
        cboPck.Text = ""

        '***********Carlos Lui added on 20120924***********
        txtPrcKey.Text = ""
        txtEffDat.Text = ""
        txtExpDat.Text = ""



    End Sub

    Private Sub chkApprove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApprove.CheckedChanged

    End Sub

    Private Sub cboItmCol_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItmCol.SelectedValueChanged

    End Sub

    Private Sub cboTmpItmCol_TextUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTmpItmCol.TextUpdate
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        Call SetSampleDetailUpdateFlag()
    End Sub

    Private Sub cboVenItmCol_TextUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenItmCol.TextUpdate
        If flg_DisplaySampleDetailData Then Exit Sub
        Recordstatus = True
        Call SetSampleDetailUpdateFlag()
    End Sub

    Private Sub txtCurCde1D_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurCde1D.TextChanged

    End Sub
    Private Function check_DTL_CUR() As Boolean
        Dim dr_SAINVDTL_ins() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("sid_creusr = '~*ADD*~'")
        'check dtl cur 
        Dim rs_check As DataSet
        For i As Integer = 0 To dr_SAINVDTL_ins.Length() - 1
            Dim qutno As String = dr_SAINVDTL_ins(i).Item("sid_qutno")
            Dim qutseq As Integer = dr_SAINVDTL_ins(i).Item("sid_qutseq")
            Dim reqno As String = dr_SAINVDTL_ins(i).Item("sid_reqno")
            Dim reqseq As Integer = dr_SAINVDTL_ins(i).Item("sid_reqseq")
            Dim cus1no As String = GetCtrlValue(cboCus1No)

            gspStr = "sp_select_SAINVDTL_CHECK '" & cus1no & "','" & qutno & "'," & qutseq & ",'" & reqno & "'," & reqseq


            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default


            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading check_DTL_CUR sp_select_SAINVDTL_CHECK : " & rtnStr)
            Else
                If rs_check.Tables("RESULT").Rows.Count = 0 Then
                    'Exit Sub
                Else
                    If rs_check.Tables("RESULT").Rows(0).Item(0) <> dr_SAINVDTL_ins(i).Item("sid_curcde") Then
                        MsgBox(dr_SAINVDTL_ins(i).Item("sid_invseq") & " Currency Incorrect, Please Check.")
                        Return False
                        Exit Function
                    End If

                End If
            End If
        Next

        Dim dr_SAINVDTL_upd() As DataRow = rs_SAINVDTL.Tables("RESULT").Select("sid_creusr = '~*UPD*~'")
        For i As Integer = 0 To dr_SAINVDTL_upd.Length() - 1
            Dim qutno As String = dr_SAINVDTL_upd(i).Item("sid_qutno")
            Dim qutseq As Integer = dr_SAINVDTL_upd(i).Item("sid_qutseq")
            Dim reqno As String = dr_SAINVDTL_upd(i).Item("sid_reqno")
            Dim reqseq As Integer = dr_SAINVDTL_upd(i).Item("sid_reqseq")
            Dim cus1no As String = GetCtrlValue(cboCus1No)

            gspStr = "sp_select_SAINVDTL_CHECK '" & cus1no & "','" & qutno & "'," & qutseq & ",'" & reqno & "'," & reqseq


            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default


            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading check_DTL_CUR sp_select_SAINVDTL_CHECK : " & rtnStr)
            Else
                If rs_check.Tables("RESULT").Rows.Count = 0 Then
                    'Exit Sub
                Else
                    If rs_check.Tables("RESULT").Rows(0).Item(0) <> dr_SAINVDTL_upd(i).Item("sid_curcde") Then
                        MsgBox(dr_SAINVDTL_upd(i).Item("sid_invseq") & " Currency Incorrect, Please Check.")
                        Return False
                        Exit Function
                    End If

                End If
            End If
        Next
        Return True

    End Function

    Private Sub InvoiceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoiceReportToolStripMenuItem.Click
        If Recordstatus = True Then
            MessageBox.Show("Sample Invoice has been changed. Please save before printing.")
        Else
            Dim SAR00005 As New SAR00005
            SAR00005.callbySAM03(txtInvNo.Text, cboCoCde.Text)

        End If
    End Sub

    Private Sub PackingListReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackingListReportToolStripMenuItem.Click
        If Recordstatus = True Then
            MessageBox.Show("Sample Invoice has been changed. Please save before printing.")
        Else
            Dim SAR00007 As New SAR00007
            SAR00007.callBySAM03(txtInvNo.Text, cboCoCde.Text)

        End If
    End Sub
End Class

