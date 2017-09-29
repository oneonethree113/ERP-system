Public Class TOM00001
    Dim mode As String
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim Recordstatus As Boolean

    Dim inputvalid As Boolean = True

    Dim rs_TOORDHDR As DataSet
    Dim rs_TOORDDTL As DataSet
    Dim rs_TODTLSHP As DataSet

    Dim rs_CUTOCUB As DataSet
    Dim rs_CUBASINF As DataSet

    Dim rs_VNBASINF As DataSet

    Dim rs_TOXLSHDR As DataSet

    Dim rs_VNCNTPER As DataSet



    Public FrmTOM0003 As TOM00003

    Dim Got_Focus_Grid As String

#Region " Datagrid Variable "
    'dgTODtl
    Dim dgTODtl_tod_cocde As Integer
    Dim dgTODtl_tod_toordno As Integer
    Dim dgTODtl_tod_toordseq As Integer
    Dim dgTODtl_tod_verno As Integer
    Dim dgTODtl_tod_latest As Integer
    Dim dgTODtl_tod_refno As Integer
    Dim dgTODtl_tod_sts As Integer
    Dim dgTODtl_tod_todat As Integer
    Dim dgTODtl_tod_customer As Integer
    Dim dgTODtl_tod_cus1no As Integer
    Dim dgTODtl_tod_cus2no As Integer
    Dim dgTODtl_tod_buyer As Integer
    Dim dgTODtl_tod_category As Integer
    Dim dgTODtl_tod_jobno As Integer
    Dim dgTODtl_tod_ftyitmno As Integer
    Dim dgTODtl_tod_itmsku As Integer
    Dim dgTODtl_tod_ftytmpitmno As Integer
    Dim dgTODtl_tod_itmdsc As Integer
    Dim dgTODtl_tod_venno As Integer
    Dim dgTODtl_tod_venitm As Integer
    Dim dgTODtl_tod_colcde As Integer
    Dim dgTODtl_tod_inrqty As Integer
    Dim dgTODtl_tod_mtrqty As Integer
    Dim dgTODtl_tod_pckunt As Integer
    Dim dgTODtl_tod_conftr As Integer
    Dim dgTODtl_tod_cft As Integer
    Dim dgTODtl_tod_period As Integer
    Dim dgTODtl_tod_fobport As Integer
    Dim dgTODtl_tod_retail As Integer
    Dim dgTODtl_tod_projqty As Integer
    Dim dgTODtl_tod_ftyshpdatstr As Integer
    Dim dgTODtl_tod_ftyshpdatend As Integer
    Dim dgTODtl_tod_dsgven As Integer
    Dim dgTODtl_tod_prdven As Integer
    Dim dgTODtl_tod_cusven As Integer
    Dim dgTODtl_tod_imgpth As Integer
    Dim dgTODtl_tod_sapno As Integer
    Dim dgTODtl_tod_cuspono As Integer
    Dim dgTODtl_tod_rmk As Integer
    Dim dgTODtl_tod_upc As Integer
    Dim dgTODtl_tod_ctnL As Integer
    Dim dgTODtl_tod_ctnW As Integer
    Dim dgTODtl_tod_ctnH As Integer
    Dim dgTODtl_tod_ctnupc As Integer
    Dim dgTODtl_tod_venstk As Integer
    Dim dgTODtl_tod_cushpdatstr As Integer
    Dim dgTODtl_tod_cushpdatend As Integer
    Dim dgTODtl_tod_fcurcde As Integer
    Dim dgTODtl_tod_ftycst As Integer
    Dim dgTODtl_tod_curcde As Integer
    Dim dgTODtl_tod_selprc As Integer
    Dim dgTODtl_tod_qtyb_cuspo As Integer
    Dim dgTODtl_tod_qtyb_ordqty As Integer
    Dim dgTODtl_tod_podat As Integer
    Dim dgTODtl_tod_pcktyp As Integer
    Dim dgTODtl_tod_qutno As Integer
    Dim dgTODtl_tod_qutseq As Integer
    Dim dgtodtl_tod_cntctp As Integer
    Dim dgTODtl_tod_creusr As Integer
    Dim dgTODtl_tod_updusr As Integer
    Dim dgTODtl_tod_credat As Integer
    Dim dgTODtl_tod_upddat As Integer
    Dim dgTODtl_tod_timstp As Integer
    Dim dgTODtl_tod_match As Integer


    'dgTOMShp
    Dim dgMshp_Gen As Integer
    Dim dgMShp_tds_cocde As Integer
    Dim dgMShp_tds_toordno As Integer
    Dim dgMShp_tds_toordseq As Integer
    Dim dgMShp_tds_verno As Integer
    Dim dgMShp_tds_shpseq As Integer
    Dim dgMShp_tds_ftyshpstr As Integer
    Dim dgMShp_tds_ftyshpend As Integer
    Dim dgMShp_tds_cushpstr As Integer
    Dim dgMShp_tds_cushpend As Integer
    Dim dgMShp_tds_shpqty As Integer
    Dim dgmshp_tds_podat As Integer
    Dim dgMShp_tds_pckunt As Integer
    Dim dgMShp_tds_creusr As Integer
    Dim dgMShp_tds_updusr As Integer
    Dim dgMShp_tds_credat As Integer
    Dim dgMShp_tds_upddat As Integer
    Dim dgMShp_tds_timstp As Integer


#End Region



    Private Sub TOM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        mode = "INIT"

        Call formInit(mode)


        gspStr = "sp_select_TOORDHDR '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_TOORDHDR, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00001_Load sp_select_TOORDHDR :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_TOORDDTL '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_TOORDDTL, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00001_Load sp_select_TOORDDTL :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_TODTLSHP '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_TODTLSHP, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00001_Load sp_select_TOORDDTL :" & rtnStr)
            Exit Sub
        End If

        'gspStr = "sp_select_CUTOCUB '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_CUTOCUB, rtnStr)

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading TOM00001_Load sp_select_CUTOCUB :" & rtnStr)
        '    Exit Sub
        'End If


        gspStr = "sp_list_CUBASINF '','A'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If


        format_cboTOStatus()
        format_cboCustomer()

        txtTONo.Select()

        'rbAll.Checked = True


        Call Formstartup(Me.Name)



        Cursor = Cursors.Default
    End Sub

    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            Call clearAllDisplay(Me)
        End If

        Call resetcmdButton(m)

        Call resetDisplay(m)

        Me.StatusBarPanel1.Text = m

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
                ElseIf Not TypeOf v Is Label Then
                    v.Enabled = False
                End If
            End If
        Next v
    End Sub


    Private Sub resetcmdButton(ByVal m As String)
        If m = "INIT" Then
            'If Enq_right_local = True Then
            '    Me.cmdAdd.Enabled = True
            'Else
            '    Me.cmdAdd.Enabled = False
            'End If

            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = True
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = True

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False
            cmdStandShip.Enabled = False
            Me.cmdExit.Enabled = True

            cmdCancelTO.Enabled = False

            freeze_TabControl(0)
        ElseIf m = "ADD" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = True
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False
            cmdStandShip.Enabled = True
            Me.cmdInsRow.Enabled = True
            Me.cmdDelRow.Enabled = True
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True
            cmdCancelTO.Enabled = False

            release_TabControl()

        ElseIf m = "UPDATE" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = True
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True
            cmdStandShip.Enabled = True
            cmdCancelTO.Enabled = True

            release_TabControl()
        ElseIf m = "READ" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True
            cmdStandShip.Enabled = False
            cmdCancelTO.Enabled = True

            release_TabControl()
        ElseIf m = "DisableAll" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False
            cmdStandShip.Enabled = False
            Me.cmdExit.Enabled = True
            cmdCancelTO.Enabled = False
        End If

    End Sub

    Private Sub resetDisplay(ByVal m As String)


        If m = "INIT" Then
            txtTONo.Enabled = True
            cboCoCde.Enabled = True

            Recordstatus = False
            TabPageMain.SelectedIndex = 0
        ElseIf m = "ADD" Then
            txtTONo.Enabled = False
            cboCoCde.Enabled = False
        ElseIf m = "UPDATE" Then
            txtMatch.Enabled = True
            txtTONo.Enabled = False
            cboCoCde.Enabled = False

            txtTO.Enabled = True
            txtCC.Enabled = True
            txtFm.Enabled = True
            txtHdrRmk.Enabled = True

            gbShow.Enabled = True
            rbLatest.Enabled = True
            rbAll.Enabled = True

            txtDtlRmk.Enabled = True
            txtPrjQty.Enabled = True
            txtMatch.Enabled = True


            txtFtyShpDateStr.Enabled = True
            txtFtyShpDateEnd.Enabled = True

            txtCustShpDateStr.Enabled = True
            txtCustShpDateEnd.Enabled = True

            cboCV.Enabled = True
            cboPV.Enabled = True
            cboDV.Enabled = False
            cboConPer.Enabled = True

            If cboBuyer.Items.Count = 1 And cboBuyer.Items.Item(0).ToString = "" Then
                cboBuyer.Enabled = False
            Else
                cboBuyer.Enabled = True
            End If



            CmdDtlPre.Enabled = True
            CmdDtlNext.Enabled = True

            cmdMShp.Enabled = True
            cmdStandShip.Enabled = True

            txtStandCustShpDateEnd.Enabled = True
            txtStandCustShpDateStr.Enabled = True
            txtStandFtyShpDateEnd.Enabled = True
            txtStandFtyShpDateStr.Enabled = True
            cmdStandShipConfrim.Enabled = True
            cmdStandShipExit.Enabled = True

            cmbTOM00003.Enabled = True
            txtPODate.Enabled = True


            cmdMShpAdd.Enabled = True
            cmdMShpSave.Enabled = True
        ElseIf m = "READ" Then
            txtTONo.Enabled = False
            cboCoCde.Enabled = False
            txtTO.Enabled = False
            txtCC.Enabled = False
            txtFm.Enabled = False
            txtHdrRmk.Enabled = False
            txtDtlRmk.Enabled = False
            txtPrjQty.Enabled = False
            txtMatch.Enabled = False

            txtFtyShpDateEnd.Enabled = False
            txtFtyShpDateStr.Enabled = False
            txtCustShpDateStr.Enabled = False
            txtCustShpDateEnd.Enabled = False
            cboDV.Enabled = False
            cboCV.Enabled = False
            cboPV.Enabled = False
            cboBuyer.Enabled = False
            cboConPer.Enabled = False
            rbAll.Enabled = True
            rbLatest.Enabled = True
            gbShow.Enabled = True
            CmdDtlNext.Enabled = True
            CmdDtlPre.Enabled = True
            cmbTOM00003.Enabled = True
            cmdMShp.Enabled = True
            cmdStandShip.Enabled = False
            cmdMShpAdd.Enabled = False
            cmdMShpSave.Enabled = False
            cmdMShpExit.Enabled = True
            txtPODate.Enabled = False


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

    Private Sub format_cboTOStatus()
        cboTOStatus.Items.Add("")
        cboTOStatus.Items.Add("OPE - Open")
        cboTOStatus.Items.Add("REL - Released")
        cboTOStatus.Items.Add("CAN - Cancelled")
    End Sub


    Private Sub format_cboCustomer()
        Dim i As Integer

        cboPriCus.Items.Clear()
        cboPriCus.Items.Add("")
        cboSecCus.Items.Clear()
        cboSecCus.Items.Add("")

        Dim dr_p() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_custyp = 'P'")
        For i = 0 To dr_p.Length - 1
            cboPriCus.Items.Add(dr_p(i).Item("cbi_cusno").ToString & " - " & dr_p(i).Item("cbi_cussna").ToString)
        Next i

        Dim dr_s() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '60000' and cbi_custyp = 'S'")
        For i = 0 To dr_s.Length - 1
            cboSecCus.Items.Add(dr_s(i).Item("cbi_cusno").ToString & " - " & dr_s(i).Item("cbi_cussna").ToString)
        Next i

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Cursor = Cursors.WaitCursor

        Dim i As Integer

        If (Trim(txtTONo.Text) = "" And txtTONo.Enabled = True) Then
            If txtTONo.Enabled And txtTONo.Visible Then
                txtTONo.Select()
                MsgBox("Pls input TO No.")
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        txtTONo.Text = txtTONo.Text.ToUpper()

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_TOORDHDR '" & cboCoCde.Text & "','" & txtTONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TOORDHDR, rtnStr)

        If rs_TOORDHDR.Tables("RESULT").Rows.Count <> 1 Then
            MsgBox("Tentative Order not found!")
            txtTONo.Select()
            Cursor = Cursors.Default
            Exit Sub
        End If


        For i = 0 To rs_TOORDHDR.Tables("RESULT").Columns.Count - 1
            rs_TOORDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        gspStr = "sp_select_TOORDDTL '" & cboCoCde.Text & "','" & txtTONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TOORDDTL, rtnStr)

        If rs_TOORDDTL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Tentative Order have no detail!")
            txtTONo.Select()
            Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_select_TODTLSHP '" & "" & "','" & txtTONo.Text & "'" 'cbocode?
        rtnLong = execute_SQLStatement(gspStr, rs_TODTLSHP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00001_Load sp_select_TODTLSHP :" & rtnStr)
            Exit Sub
        End If


        For i = 0 To rs_TODTLSHP.Tables("RESULT").Columns.Count - 1
            rs_TODTLSHP.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        For i = 0 To rs_TODTLSHP.Tables("RESULT").Rows.Count - 1
            If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpstr") = "#1/1/1900#" Then
                rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpstr") = DBNull.Value
            End If

            If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpend") = "#1/1/1900#" Then
                rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpend") = DBNull.Value
            End If

            If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpstr") = "#1/1/1900#" Then
                rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpstr") = DBNull.Value
            End If

            If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpend") = "#1/1/1900#" Then
                rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpend") = DBNull.Value
            End If

            If IsDBNull(rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat")) = True Then
                rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat") = DBNull.Value
            ElseIf rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat") = "#1/1/1900#" Then
                rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat") = DBNull.Value
            End If


        Next


        For i = 0 To rs_TOORDDTL.Tables("RESULT").Columns.Count - 1
            rs_TOORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_podat") = "#1/1/1900#" Then
                rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_podat") = DBNull.Value
            End If
        Next








        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00001_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_CUTOCUB '" & rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus1no") & "','" & rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus2no") & "'" 'cbocode?
        rtnLong = execute_SQLStatement(gspStr, rs_CUTOCUB, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00001_Load sp_list_CUTOCUB :" & rtnStr)
            Exit Sub
        End If




        'gspStr = "sp_list_VNCNTINF '','" & rs_TOORDDTL.Tables("RESULT").Rows(0).Item("tod_prdven") & "','*','PER'"
        'rtnLong = execute_SQLStatement(gspStr, rs_VNCNTPER, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_*_PER :" & rtnStr)
        '    Me.Cursor = Cursors.Default
        '    Exit Sub
        'End If


        'format_ConPerCom()

        format_VendorCombo()
        format_cbobuyer()


        If Enq_right_local = True Then
            mode = "UPDATE"
        Else
            mode = "READ"
        End If


        If rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_ordsts") = "REL" Or rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_ordsts") = "CAN" Then
            mode = "READ"
        End If

        formInit(mode)

        displayTentativeOrder()

        rbAll.Checked = True



        Cursor = Cursors.Default
        TabPageMain.SelectedIndex = 0
    End Sub


    Private Sub format_cbobuyer()
        Dim i As Integer
        Dim strList As String

        cboBuyer.Items.Clear()


        cboBuyer.Items.Add("")


        If rs_CUTOCUB.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUTOCUB.Tables("RESULT").Rows.Count - 1
                strList = rs_CUTOCUB.Tables("RESULT").Rows(i).Item("ctc_buycde")
                If strList <> "" Then
                    cboBuyer.Items.Add(strList)


                End If
            Next i
        End If

     


    End Sub

    Private Sub format_VendorCombo()
        Dim i As Integer
        Dim strList As String

        cboDV.Items.Clear()
        cboCV.Items.Clear()
        cboPV.Items.Clear()

        cboDV.Items.Add("")
        cboCV.Items.Add("")
        cboPV.Items.Add("")

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboDV.Items.Add(strList)
                    cboCV.Items.Add(strList)
                    cboPV.Items.Add(strList)

                End If
            Next i
        End If
    End Sub



    Private Sub format_ConPerCom()
        Dim i As Integer
        Dim strlist As String

        cboConPer.Items.Clear()
        cboConPer.Items.Add("")

        If rs_VNCNTPER.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNCNTPER.Tables("RESULT").Rows.Count - 1
                strlist = rs_VNCNTPER.Tables("RESULT").Rows(i).Item("vci_cntctp")
                If strlist <> "" Then
                    cboConPer.Items.Add(strlist)
                End If
            Next
        End If


    End Sub

    Private Sub displayTentativeOrder()
        txtIssDat.Text = Format(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_issdat"), "MM/dd/yyyy")
        txtRvsDat.Text = Format(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_rvsdat"), "MM/dd/yyyy")

        display_combo(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_ordsts"), cboTOStatus)

        display_combo(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus1no"), cboPriCus)
        display_combo(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus2no"), cboSecCus)

        txtSeason.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_season")
        cboCustCde.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_custcde")
        txtCustName.Text = ""
        cboBuyer.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_buyer")

        Dim dr() As DataRow
        dr = rs_CUTOCUB.Tables("RESULT").Select("ctc_buycde = '" & cboBuyer.Text & "'")
        If dr.Length = 1 Then
            txtBuyerName.Text = dr(0)("ctc_buynam").ToString
        Else
            txtBuyerName.Text = ""
        End If


        txtBuyerName.Text = ""
        cboYear.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_year")

        txtRefQut.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_refqut")

        txtTO.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_to")
        txtCC.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cc")
        txtFm.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_fm")
        txtHdrRmk.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_rmk")
        txtHdrVer.Text = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_verno")


        Call display_dgTO()

        Dim tmpseq As Integer
        Dim tmpver As Integer

        tmpseq = rs_TOORDDTL.Tables("RESULT").Rows(0).Item("tod_toordseq")
        tmpver = rs_TOORDDTL.Tables("RESULT").Rows(0).Item("tod_verno")

        Call display_TODtl(tmpseq, tmpver)

        '        Call display_dgMShp(tmpseq, tmpver)



    End Sub






    Private Sub display_TODtl(ByVal seq As Integer, ByVal ver As Integer)
        Dim loc As Integer
        loc = -1

        Dim i As Integer
        i = 0

        Dim tmpseq As Integer
        Dim tmpver As Integer
        tmpseq = 0
        tmpver = 0
        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            tmpseq = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq")
            tmpver = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno")

            If tmpseq = seq And tmpver = ver Then
                loc = i
                Exit For
            End If
        Next i

        If loc = -1 Then
            MsgBox("Tentative Order detail not found!")
            Exit Sub
        End If

        txtSeq.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_toordseq")
        txtRefNo.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_refno")
        If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_match")) Then
            txtMatch.Text = ""
        Else
            txtMatch.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_match")
        End If

        txtVerNo.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_verno")
        txtTODate.Text = Format(CDate(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_todat")), "MM/dd/yyyy")
        txtDtlStatus.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_sts")
        txtQutStatus.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_qutitmsts")

        txtFtyItmNo.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyitmno")
        txtFtyTmpItm.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftytmpitmno")
        txtItmDsc.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_itmdsc")
        cboVendor.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_venno")
        txtVenItm.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_venitm")
        txtItmCat.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_category")
        txtColcde.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_colcde")
        txtItmSKU.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_itmsku")

        txtUM.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_pckunt")
        txtInr.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_inrqty")
        txtMtr.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_mtrqty")
        txtCFT.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cft")
        txtCBM.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cbm")
        txtFactor.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_conftr")
        cboFtyPrcTrm.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyprctrm")
        cboHKPrcTrm.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_hkprctrm")
        cboTranTrm.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_trantrm")
        txtCtnDL.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ctnL")
        txtCtnDW.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ctnW")
        txtCtnDH.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ctnH")

        txtUPC.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_upc")
        txtCtnUPC.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ctnupc")
        txtDtlRmk.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_rmk")

        txtPrjQty.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_projqty")
        txtPrjQtyUM.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_pckunt")


        'txtFtyShpDateStr.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatstr")
        'txtFtyShpDateEnd.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatend")
        'txtCustShpDateStr.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatstr")
        'txtCustShpDateEnd.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatend")

        If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatstr")) = True Then
            txtFtyShpDateStr.Text = ""
        ElseIf rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatstr") = "#1/1/1900#" Then
            txtFtyShpDateStr.Text = ""
        Else
            txtFtyShpDateStr.Text = Format(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatstr"), "MM/dd/yyyy")
        End If

        If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatend")) = True Then
            txtFtyShpDateEnd.Text = ""
        ElseIf rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatend") = "#1/1/1900#" Then
            txtFtyShpDateEnd.Text = ""
        Else
            txtFtyShpDateEnd.Text = Format(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatend"), "MM/dd/yyyy")
        End If



        If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatstr")) = True Then
            txtCustShpDateStr.Text = ""
        ElseIf rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatstr") = "#1/1/1900#" Then
            txtCustShpDateStr.Text = ""
        Else
            txtCustShpDateStr.Text = Format(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatstr"), "MM/dd/yyyy")
        End If


        If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatend")) = True Then
            txtCustShpDateEnd.Text = ""
        ElseIf rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatend") = "#1/1/1900#" Then
            txtCustShpDateEnd.Text = ""
        Else
            txtCustShpDateEnd.Text = Format(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatend"), "MM/dd/yyyy")
        End If



        txtJobNo.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_jobno")
        txtCustPO.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cuspono")
        txtSAPNo.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_sapno")
        txtVenStk.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_venstk")

        txtSelCur.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_curcde")
        txtSelPrc.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_selprc")
        txtCur.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_curcde")
        txtBasPrc.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_basprc")

        txtFtyCur.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_fcurcde")
        txtFtyCst.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftycst")
        txtFOBPort.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_fobport")

        'Dim year As String = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_period")).Year
        'Dim month As String = Split(Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_period")).ToShortDateString, "/")(0)

        'If year = "1900" Then
        '    txtPeriod.Text = ""
        'Else
        '    txtPeriod.Text = year + "-" + month
        'End If

        txtPeriod.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_period")


        'txtPeriod.Text = Format(Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_period")).ToShortDateString, "yyyy/mm")

        txtCurRetail.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_curcde")
        txtRetail.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_retail")

        'txtQtyb_CustPO.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_qtyb_cuspo")
        'txtQtyb_OdrQty.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_qtyb_ordqty")
        If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_podat")) = True Then
            txtPODate.Text = ""
        ElseIf Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_podat")).Year.ToString = "1900" Then
            txtPODate.Text = ""
        Else
            txtPODate.Text = Format(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_podat"), "MM/dd/yyyy")
        End If

        txtPackType.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_pcktyp")

        txtDtlRefQU.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_qutno") & " - " & rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_qutseq")

        display_combo(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_dsgven"), cboDV)
        display_combo(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_prdven"), cboPV)
        display_combo(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cusven"), cboCV)

        txtLatest.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_latest")

        If txtLatest.Text = "N" Then
            cmdMShpAdd.Enabled = False
            cmdMShpSave.Enabled = False
            resetDisplay("READ")
        ElseIf txtLatest.Text = "Y" Then

            If mode <> "READ" Then
                cmdMShpAdd.Enabled = True
                cmdMShpSave.Enabled = True
                resetDisplay("UPDATE")
            End If
        End If


        gspStr = "sp_list_VNCNTINF '','" & rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_prdven") & "','*','PER'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTPER, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_*_PER :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        format_ConPerCom()

        If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cntctp")) = True Then
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cntctp") = ""
        End If

        display_combo(rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cntctp"), cboConPer)


        'cboPV.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_prdven")
        'cboCV.Text = rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cusven")
    End Sub

    Private Sub display_dgMShp(ByVal seq As Integer, ByVal ver As Integer)
        If rs_TODTLSHP.Tables.Count = 0 Then
            Exit Sub
        End If

        dgMShp.DataSource = rs_TODTLSHP.Tables("RESULT").DefaultView

        If rs_TODTLSHP.Tables("RESULT").Rows.Count > 0 Then
            Dim sFilter As String
            sFilter = "tds_toordseq = " & seq & " and tds_verno = " & ver
            rs_TODTLSHP.Tables("RESULT").DefaultView.RowFilter = sFilter
            'dgMShp.DataSource = rs_TODTLSHP.Tables("RESULT").DefaultView
        End If

        dgMShp.RowHeadersWidth = 18
        dgMShp.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgMShp.ColumnHeadersHeight = 18
        dgMShp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgMShp.AllowUserToResizeColumns = True
        dgMShp.AllowUserToResizeRows = False
        dgMShp.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_TODTLSHP.Tables("RESULT").Columns.Count - 1
            rs_TODTLSHP.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        'End If

        For i = 0 To dgMShp.Columns.Count - 1
            dgMShp.Columns(i).ReadOnly = False
        Next i



        i = 0
        dgMshp_Gen = i
        dgMShp.Columns(i).HeaderText = "Del"
        dgMShp.Columns(i).Width = 30
        dgMShp.Columns(i).ReadOnly = True
        i = i + 1 '1 
        dgMShp_tds_cocde = i
        dgMShp.Columns(i).Width = 30
        dgMShp.Columns(i).Visible = False
        i = i + 1 '2
        dgMShp_tds_toordno = i
        dgMShp.Columns(i).Visible = False
        i = i + 1 '3
        dgMShp_tds_toordseq = i
        dgMShp.Columns(i).Visible = False
        i = i + 1 '4
        dgMShp_tds_verno = i
        dgMShp.Columns(i).Visible = False
        i = i + 1 '5
        dgMShp_tds_shpseq = i
        dgMShp.Columns(i).HeaderText = "Seq"
        dgMShp.Columns(i).Width = 30
        dgMShp.Columns(i).ReadOnly = True
        i = i + 1 '6
        dgMShp_tds_ftyshpstr = i
        dgMShp.Columns(i).HeaderText = "Fty Shp Str"
        dgMShp.Columns(i).Width = 75
        dgMShp.Columns(i).DefaultCellStyle.Format = "MM/dd/yyyy"
        i = i + 1 '7
        dgMShp_tds_ftyshpend = i
        dgMShp.Columns(i).HeaderText = "Fty Shp End"
        dgMShp.Columns(i).Width = 75
        dgMShp.Columns(i).DefaultCellStyle.Format = "MM/dd/yyyy"
        i = i + 1 '8
        dgMShp_tds_cushpstr = i
        dgMShp.Columns(i).HeaderText = "Cus Shp Str"
        dgMShp.Columns(i).Width = 75
        dgMShp.Columns(i).DefaultCellStyle.Format = "MM/dd/yyyy"
        i = i + 1 '9
        dgMShp_tds_cushpend = i
        dgMShp.Columns(i).HeaderText = "Cus Shp End"
        dgMShp.Columns(i).Width = 75
        dgMShp.Columns(i).DefaultCellStyle.Format = "MM/dd/yyyy"
        i = i + 1 '10
        dgMShp_tds_shpqty = i
        dgMShp.Columns(i).HeaderText = "Shp Qty"
        dgMShp.Columns(i).Width = 60
        i = i + 1 '11
        dgmshp_tds_podat = i
        dgMShp.Columns(i).HeaderText = "PO Date"
        dgMShp.Columns(i).Width = 75
        i = i + 1
        dgMShp_tds_pckunt = i
        dgMShp.Columns(i).HeaderText = "UM"
        dgMShp.Columns(i).Width = 30
        dgMShp.Columns(i).ReadOnly = True
        i = i + 1 '12
        dgMShp_tds_creusr = i
        dgMShp.Columns(i).Visible = False
        i = i + 1 '13
        dgMShp_tds_updusr = i
        dgMShp.Columns(i).Visible = False
        i = i + 1 '14
        dgMShp_tds_credat = i
        dgMShp.Columns(i).Visible = False
        i = i + 1 '15
        dgMShp_tds_upddat = i
        dgMShp.Columns(i).Visible = False
        i = i + 1 '16
        dgMShp_tds_timstp = i
        dgMShp.Columns(i).Visible = False
    End Sub




    Private Sub display_dgTO()
        If rs_TOORDDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        dgTODtl.DataSource = rs_TOORDDTL.Tables("RESULT").DefaultView

        dgTODtl.RowHeadersWidth = 18
        dgTODtl.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgTODtl.ColumnHeadersHeight = 18
        dgTODtl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgTODtl.AllowUserToResizeColumns = True
        dgTODtl.AllowUserToResizeRows = False
        dgTODtl.RowTemplate.Height = 18

        Dim i As Integer

        If mode = "UPDATE" Or mode = "ADD" Or mode = "READ" Then
            For i = 0 To rs_TOORDDTL.Tables("RESULT").Columns.Count - 1
                rs_TOORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If

        i = 0
        dgTODtl_tod_cocde = i
        dgTODtl.Columns(i).HeaderText = "Del"
        dgTODtl.Columns(i).Width = 30
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1
        dgTODtl_tod_toordno = i
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '2
        dgTODtl_tod_toordseq = i
        dgTODtl.Columns(i).HeaderText = "Seq"
        dgTODtl.Columns(i).Width = 30
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '3
        dgTODtl_tod_verno = i
        dgTODtl.Columns(i).HeaderText = "Ver"
        dgTODtl.Columns(i).Width = 30
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '4
        dgTODtl_tod_latest = i
        dgTODtl.Columns(i).HeaderText = "Last"
        dgTODtl.Columns(i).Width = 30
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '5
        dgTODtl_tod_refno = i
        dgTODtl.Columns(i).HeaderText = "Ref No"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '6
        dgTODtl_tod_sts = i
        dgTODtl.Columns(i).HeaderText = "Match No"
        dgTODtl.Columns(i).Width = 90
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '7
        dgTODtl_tod_sts = i
        dgTODtl.Columns(i).HeaderText = "(IM)Sts"
        dgTODtl.Columns(i).Width = 40
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+7
        dgTODtl_tod_sts = i
        dgTODtl.Columns(i).HeaderText = "(Qut)Sts"
        dgTODtl.Columns(i).Width = 40
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+8
        dgTODtl_tod_todat = i
        dgTODtl.Columns(i).HeaderText = "TO Date"
        dgTODtl.Columns(i).Width = 100
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+9
        dgTODtl_tod_customer = i
        dgTODtl.Columns(i).HeaderText = "Customer"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+10
        dgTODtl_tod_cus1no = i
        dgTODtl.Columns(i).HeaderText = "PriCus"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+11
        dgTODtl_tod_cus2no = i
        dgTODtl.Columns(i).HeaderText = "SecCus"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+12
        dgTODtl_tod_buyer = i
        dgTODtl.Columns(i).HeaderText = "Buyer"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+13
        dgTODtl_tod_category = i
        dgTODtl.Columns(i).HeaderText = "Category"
        dgTODtl.Columns(i).Width = 150
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+14
        dgTODtl_tod_jobno = i
        dgTODtl.Columns(i).HeaderText = "Job No"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+15
        dgTODtl_tod_ftyitmno = i
        dgTODtl.Columns(i).HeaderText = "Fty Item No"
        dgTODtl.Columns(i).Width = 100
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+16
        dgTODtl_tod_itmsku = i
        dgTODtl.Columns(i).HeaderText = "Itm SKU"
        dgTODtl.Columns(i).Width = 90
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+17
        dgTODtl_tod_ftytmpitmno = i
        dgTODtl.Columns(i).HeaderText = "Fty Temp Itm"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+18
        dgTODtl_tod_itmdsc = i
        dgTODtl.Columns(i).HeaderText = "Itm Dsc"
        dgTODtl.Columns(i).Width = 200
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+19
        dgTODtl_tod_venno = i
        dgTODtl.Columns(i).HeaderText = "Venno"
        dgTODtl.Columns(i).Width = 160
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+20
        dgTODtl_tod_venitm = i
        dgTODtl.Columns(i).HeaderText = "Venitm"
        dgTODtl.Columns(i).Width = 100
        dgTODtl.Columns(i).ReadOnly = True

        i = i + 1 '1+21
        dgTODtl_tod_colcde = i
        dgTODtl.Columns(i).HeaderText = "Color"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+22
        dgTODtl_tod_inrqty = i
        dgTODtl.Columns(i).HeaderText = "Inr"
        dgTODtl.Columns(i).Width = 30
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+23
        dgTODtl_tod_mtrqty = i
        dgTODtl.Columns(i).HeaderText = "Mtr"
        dgTODtl.Columns(i).Width = 30
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+24
        dgTODtl_tod_mtrqty = i
        dgTODtl.Columns(i).HeaderText = "UM"
        dgTODtl.Columns(i).Width = 40
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+25
        dgTODtl_tod_conftr = i
        dgTODtl.Columns(i).HeaderText = "Ftr"
        dgTODtl.Columns(i).Width = 40
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+26
        dgTODtl_tod_cft = i
        dgTODtl.Columns(i).HeaderText = "CFT"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+27
        dgTODtl_tod_cft = i
        dgTODtl.Columns(i).HeaderText = "CBM"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+28
        dgTODtl_tod_cft = i
        dgTODtl.Columns(i).HeaderText = "FtyTrm"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+29
        dgTODtl_tod_cft = i
        dgTODtl.Columns(i).HeaderText = "HKTrm"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+30
        dgTODtl_tod_cft = i
        dgTODtl.Columns(i).HeaderText = "TranTrm"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+31
        dgTODtl_tod_period = i
        dgTODtl.Columns(i).HeaderText = "Period"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+32
        dgTODtl_tod_fobport = i
        dgTODtl.Columns(i).HeaderText = "FOB"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+33
        dgTODtl_tod_retail = i
        dgTODtl.Columns(i).HeaderText = "Retail"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+34
        dgTODtl_tod_projqty = i
        dgTODtl.Columns(i).HeaderText = "Prj Qty"
        dgTODtl.Columns(i).Width = 60
        If mode <> "READ" Then
            dgTODtl.Columns(i).ReadOnly = False
        End If
        i = i + 1 '1+35
        dgTODtl_tod_ftyshpdatstr = i
        dgTODtl.Columns(i).HeaderText = "Fty Str"
        dgTODtl.Columns(i).Width = 80
        If mode <> "READ" Then
            dgTODtl.Columns(i).ReadOnly = False
        End If
        i = i + 1 '1+36
        dgTODtl_tod_ftyshpdatend = i
        dgTODtl.Columns(i).HeaderText = "Fty End"
        dgTODtl.Columns(i).Width = 80
        If mode <> "READ" Then
            dgTODtl.Columns(i).ReadOnly = False
        End If
        i = i + 1 '1+37
        dgTODtl_tod_dsgven = i
        dgTODtl.Columns(i).HeaderText = "DV"
        dgTODtl.Columns(i).Width = 160
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+38
        dgTODtl_tod_prdven = i
        dgTODtl.Columns(i).HeaderText = "PV"
        dgTODtl.Columns(i).Width = 160
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+39
        dgTODtl_tod_cusven = i
        dgTODtl.Columns(i).HeaderText = "CV"
        dgTODtl.Columns(i).Width = 160
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+40
        dgTODtl_tod_imgpth = i
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+41
        dgTODtl_tod_sapno = i
        dgTODtl.Columns(i).HeaderText = "SAP No"
        dgTODtl.Columns(i).Width = 100
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+42
        dgTODtl_tod_rmk = i
        dgTODtl.Columns(i).HeaderText = "CusPO"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+43
        dgTODtl_tod_rmk = i
        dgTODtl.Columns(i).HeaderText = "Remark"
        dgTODtl.Columns(i).Width = 100
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+44
        dgTODtl_tod_upc = i
        dgTODtl.Columns(i).HeaderText = "UPC"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+45
        dgTODtl_tod_ctnL = i
        dgTODtl.Columns(i).HeaderText = "Ctn L"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+46
        dgTODtl_tod_ctnW = i
        dgTODtl.Columns(i).HeaderText = "Ctn W"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+47
        dgTODtl_tod_ctnH = i
        dgTODtl.Columns(i).HeaderText = "Ctn H"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+48
        dgTODtl_tod_ctnupc = i
        dgTODtl.Columns(i).HeaderText = "Ctn UPC"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+49
        dgTODtl_tod_venstk = i
        dgTODtl.Columns(i).HeaderText = "Vdr Stk"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+50
        dgTODtl_tod_cushpdatstr = i
        dgTODtl.Columns(i).HeaderText = "Cust Str"
        dgTODtl.Columns(i).Width = 80
        If mode <> "READ" Then
            dgTODtl.Columns(i).ReadOnly = False
        End If
        i = i + 1 '1+51
        dgTODtl_tod_cushpdatend = i
        dgTODtl.Columns(i).HeaderText = "Cust End"
        dgTODtl.Columns(i).Width = 80
        If mode <> "READ" Then
            dgTODtl.Columns(i).ReadOnly = False
        End If
        i = i + 1 '1+52
        dgTODtl_tod_fcurcde = i
        dgTODtl.Columns(i).HeaderText = "FCur"
        dgTODtl.Columns(i).Width = 40
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+53
        dgTODtl_tod_ftycst = i
        dgTODtl.Columns(i).HeaderText = "Ftycst"
        dgTODtl.Columns(i).Width = 50
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+54
        dgTODtl_tod_curcde = i
        dgTODtl.Columns(i).HeaderText = "Cur"
        dgTODtl.Columns(i).Width = 40
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+55
        dgTODtl_tod_selprc = i
        dgTODtl.Columns(i).HeaderText = "SelPrc"
        dgTODtl.Columns(i).Width = 50
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+56
        dgTODtl_tod_selprc = i
        dgTODtl.Columns(i).HeaderText = "BasPrc"
        dgTODtl.Columns(i).Width = 50
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+57
        dgTODtl_tod_qtyb_cuspo = i
        dgTODtl.Columns(i).HeaderText = "QtyB CusPO"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+58
        dgTODtl_tod_qtyb_ordqty = i
        dgTODtl.Columns(i).HeaderText = "QtyB OdrQty"
        dgTODtl.Columns(i).Width = 60
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+59
        dgTODtl_tod_podat = i
        dgTODtl.Columns(i).HeaderText = "PO Date"
        dgTODtl.Columns(i).Width = 80
        If mode <> "READ" Then
            dgTODtl.Columns(i).ReadOnly = False
        End If
        i = i + 1 '1+60
        dgTODtl_tod_pcktyp = i
        dgTODtl.Columns(i).HeaderText = "Packing Type"
        dgTODtl.Columns(i).Width = 200
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+61
        dgTODtl_tod_qutno = i
        dgTODtl.Columns(i).HeaderText = "QutNo"
        dgTODtl.Columns(i).Width = 80
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+62
        dgTODtl_tod_qutseq = i
        dgTODtl.Columns(i).HeaderText = "QutSeq"
        dgTODtl.Columns(i).Width = 50
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+63
        dgtodtl_tod_cntctp = i
        dgTODtl.Columns(i).HeaderText = "Contact Person"
        dgTODtl.Columns(i).Width = 120
        dgTODtl.Columns(i).ReadOnly = True
        i = i + 1 '1+64
        dgTODtl_tod_creusr = i
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+65
        dgTODtl_tod_updusr = i
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+66
        dgTODtl_tod_credat = i
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+67
        dgTODtl_tod_upddat = i
        dgTODtl.Columns(i).Visible = False
        i = i + 1 '1+68
        dgTODtl_tod_timstp = i
        dgTODtl.Columns(i).Visible = False

        'i = i + 1 '69
        'dgTODtl_tod_match = i  
        'dgTODtl.Columns(i).Visible = True
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim tmp_toordno As String

        If Recordstatus = True Then
            Select Case MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    If Enq_right_local Then
                        Call cmdSave_Click(sender, e)
                    Else
                        MsgBox("You have no Save record rights!")
                    End If
                    Me.Cursor = Cursors.Default
                Case MsgBoxResult.No
                    tmp_toordno = txtTONo.Text
                    formInit("INIT")
                    txtTONo.Text = tmp_toordno
                    txtTONo.Select()
                    Me.Cursor = Cursors.Default
            End Select
        Else
            tmp_toordno = txtTONo.Text
            formInit("INIT")
            txtTONo.Text = tmp_toordno
            txtTONo.Select()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If CheckShipDate() = False Then
            Exit Sub
        End If


        If save_TOORDHDR() = True Then

        Else
            MsgBox("Record Save Fail!")
            Exit Sub
        End If


        If save_TOORDDTL() = True Then
            MsgBox("Record Saved")
            Recordstatus = False
            cmdClear_Click(sender, e)
        Else
            MsgBox("Record Save Fail!")
            Exit Sub
        End If


    End Sub

    Private Function CheckShipDate() As Boolean
        Dim i As Integer
        Dim seq As Integer
        Dim ver As Integer
        Dim check As Boolean = True

        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_latest") = "Y" Then
                If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatstr")) = True Or _
                   IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatend")) = True Or _
                   IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatstr")) = True Or _
                   IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatend")) = True Then
                    seq = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq")
                    ver = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno")
                    check = False
                    Exit For
                End If
            End If
        Next

        If check = False Then
            display_TODtl(seq, ver)
            MsgBox("Please enter ship date.")
            Return False
            Exit Function
        End If




        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_latest") = "Y" Then
                If rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatstr") = "#1/1/1900#" Or _
                   rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatend") = "#1/1/1900#" Or _
                   rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatstr") = "#1/1/1900#" Or _
                   rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatend") = "#1/1/1900#" Then
                    seq = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq")
                    ver = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno")
                    check = False
                    Exit For
                End If
            End If
        Next

        If check = False Then
            display_TODtl(seq, ver)
            MsgBox("Please enter ship date.")
            Return False
            Exit Function
        Else
            Return True
            Exit Function
        End If


    End Function

    Private Sub txtTONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTONo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub CmdDtlNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlNext.Click
        Dim curseq As Integer
        Dim curver As Integer

        curseq = txtSeq.Text
        curver = txtVerNo.Text

        Dim i As Integer
        Dim loc As Integer
        loc = -1
        For i = 0 To dgTODtl.RowCount - 1
            If curseq = dgTODtl.Item(dgTODtl_tod_toordseq, i).Value And curver = dgTODtl.Item(dgTODtl_tod_verno, i).Value Then
                loc = i
                Exit For
            End If
        Next i

        If loc = dgTODtl.RowCount - 1 Then
            MsgBox("Last Reocrd")
        End If

        If loc <> -1 And loc < dgTODtl.RowCount - 1 Then
            loc = loc + 1

            Dim nextseq As Integer
            Dim nextver As Integer

            nextseq = dgTODtl.Item(dgTODtl_tod_toordseq, loc).Value
            nextver = dgTODtl.Item(dgTODtl_tod_verno, loc).Value

            UpdateDetail()
            If inputvalid = False Then
                inputvalid = True
                Exit Sub
            End If
            display_TODtl(nextseq, nextver)
            display_dgMShp(nextseq, nextver)
        End If

    End Sub


    Private Sub CmdDtlPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlPre.Click
        Dim curseq As Integer
        Dim curver As Integer

        curseq = txtSeq.Text
        curver = txtVerNo.Text

        Dim i As Integer
        Dim loc As Integer
        loc = -1
        For i = 0 To dgTODtl.RowCount - 1
            If curseq = dgTODtl.Item(dgTODtl_tod_toordseq, i).Value And curver = dgTODtl.Item(dgTODtl_tod_verno, i).Value Then
                loc = i
                Exit For
            End If
        Next i

        If loc = 0 Then
            MsgBox("First Record")
        End If

        If loc <> -1 And loc > 0 Then
            loc = loc - 1

            Dim lastseq As Integer
            Dim lastver As Integer

            lastseq = dgTODtl.Item(dgTODtl_tod_toordseq, loc).Value
            lastver = dgTODtl.Item(dgTODtl_tod_verno, loc).Value

            UpdateDetail()
            If inputvalid = False Then
                inputvalid = True
                Exit Sub
            End If
            display_TODtl(lastseq, lastver)
            display_dgMShp(lastseq, lastver)
        End If

    End Sub


    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        If rs_TOORDDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        If rs_TOORDDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        If rbAll.Checked = True Then
            Dim sFilter As String
            sFilter = ""
            rs_TOORDDTL.Tables("RESULT").DefaultView.RowFilter = sFilter
            dgTODtl.DataSource = rs_TOORDDTL.Tables("RESULT").DefaultView

            If dgTODtl.RowCount > 0 Then
                Dim seq As Integer
                Dim ver As Integer

                seq = dgTODtl.Item(dgTODtl_tod_toordseq, 0).Value
                ver = dgTODtl.Item(dgTODtl_tod_verno, 0).Value
                display_TODtl(seq, ver)
                display_dgMShp(seq, ver)
            End If
        End If
    End Sub

    Private Sub rbLatest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLatest.CheckedChanged
        If rs_TOORDDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        If rs_TOORDDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        If rbLatest.Checked = True Then
            Dim sFilter As String
            sFilter = "tod_latest = 'Y'"
            rs_TOORDDTL.Tables("RESULT").DefaultView.RowFilter = sFilter
            dgTODtl.DataSource = rs_TOORDDTL.Tables("RESULT").DefaultView

            If dgTODtl.RowCount > 0 Then
                Dim seq As Integer
                Dim ver As Integer

                seq = dgTODtl.Item(dgTODtl_tod_toordseq, 0).Value
                ver = dgTODtl.Item(dgTODtl_tod_verno, 0).Value
                display_TODtl(seq, ver)
                display_dgMShp(seq, ver)
            End If
        End If
    End Sub


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If Recordstatus = True Then
            cmdClear_Click(sender, e)
        End If
        Me.Close()
    End Sub





    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged




        If TabPageMain.SelectedIndex = 1 Then
            If inputvalid = False Then
                inputvalid = True
                Exit Sub
            End If
            If dgTODtl.RowCount > 0 Then
                If dgTODtl.SelectedCells.Count = 1 Or dgTODtl.SelectedRows.Count = 1 Then
                    Dim seq As Integer
                    Dim ver As Integer

                    If dgTODtl.SelectedCells.Count = 1 Then
                        seq = dgTODtl.Item(dgTODtl_tod_toordseq, dgTODtl.SelectedCells.Item(0).RowIndex).Value
                        ver = dgTODtl.Item(dgTODtl_tod_verno, dgTODtl.SelectedCells.Item(0).RowIndex).Value
                    Else
                        seq = dgTODtl.SelectedRows.Item(0).Cells(dgTODtl_tod_toordseq).Value
                        ver = dgTODtl.SelectedRows.Item(0).Cells(dgTODtl_tod_verno).Value
                    End If

                    ' If Not (seq = txtSeq.Text And ver = txtVerNo.Text) Then

                    display_TODtl(seq, ver)
                    display_dgMShp(seq, ver)
                    'End If
                End If
            End If
        ElseIf TabPageMain.SelectedIndex = 2 Then
            UpdateDetail()
            display_dgTO()
        End If
    End Sub

    Private Sub txtDtlRmk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDtlRmk.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtDtlRmk_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDtlRmk.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtDtlRmk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDtlRmk.LostFocus
        UpdateDetail()
    End Sub

    Private Sub txtDtlRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDtlRmk.TextChanged

    End Sub

    Private Sub txtUPC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUPC.TextChanged
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtFtyShpDateStr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFtyShpDateStr.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtFtyShpDateStr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFtyShpDateStr.LostFocus
        'UpdateDetail()
    End Sub

    Private Sub txtFtyShpDateStr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFtyShpDateStr.TextChanged

    End Sub

    Private Sub txtFtyShpDateEnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFtyShpDateEnd.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtFtyShpDateEnd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFtyShpDateEnd.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtFtyShpDateEnd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFtyShpDateEnd.LostFocus
        'UpdateDetail()
    End Sub

    Private Sub txtFtyShpDateEnd_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtFtyShpDateEnd.MaskInputRejected
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtCustShpDateStr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustShpDateStr.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtCustShpDateStr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustShpDateStr.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtCustShpDateStr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustShpDateStr.LostFocus
        'UpdateDetail()
    End Sub

    Private Sub txtCustShpDateStr_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtCustShpDateStr.MaskInputRejected
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtCustShpDateEnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustShpDateEnd.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtCustShpDateEnd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustShpDateEnd.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtCustShpDateEnd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustShpDateEnd.LostFocus
        'UpdateDetail()
    End Sub

    Private Sub txtCustShpDateEnd_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtCustShpDateEnd.MaskInputRejected
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub cmdMShp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMShp.Click


        freeze_TabControl(1)
        PanelMShp.Visible = True
        PanelMShp.Enabled = True
        display_dgMShp(txtSeq.Text, txtVerNo.Text)

        'cmdMShpSave.Enabled = True
        'cmdMShpExit.Enabled = True
    End Sub


    Private Sub cmdMShpExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMShpExit.Click
        release_TabControl()
        PanelMShp.Visible = False
    End Sub

    Private Sub cmdMShpAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMShpAdd.Click
        If txtLatest.Text <> "Y" Then
            Exit Sub
        End If

        Call add_ShpLine()
        dgMShp.Enabled = True
    End Sub

    Private Sub add_ShpLine()

        Dim rowcount As Integer
        rowcount = rs_TODTLSHP.Tables("RESULT").Rows.Count
        'Dim dr() As DataRow = rs_TODTLSHP.Tables("RESULT").Select("tds_toordno = ''")
        Dim dr() As DataRow = rs_TODTLSHP.Tables("RESULT").Select("tds_shpqty = 0 and tds_toordseq = " & txtSeq.Text & " and tds_verno = " & txtVerNo.Text)
        Dim dr2() As DataRow = rs_TODTLSHP.Tables("RESULT").Select("tds_toordseq = " & txtSeq.Text & " and tds_verno = " & txtVerNo.Text, "tds_shpseq ASC")
        'sFilter = "tds_toordseq = " & seq & " and tds_verno = " & ver

        Dim maxseq As Integer

        Dim tb As New DataTable
        tb = rs_TODTLSHP.Tables("RESULT").Clone

        Dim datar As DataRow

        For Each datar In dr2
            tb.ImportRow(datar)
        Next

        Dim seqObject As Object = tb.Compute("Max(tds_shpseq)", "")
        Dim seq As Integer
        If IsDBNull(seqObject) Then
            seq = 0 + 1
        Else
            seq = Convert.ToInt32(seqObject) + 1
        End If
        'For i As Integer = 0 To dr2.Length
        '    maxseq = i
        'Next
        'maxseq += 1

        If dr.Length = 0 Then
            rs_TODTLSHP.Tables("RESULT").Rows.Add()

            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("Gen") = ""
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_cocde") = cboCoCde.Text
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_toordno") = txtTONo.Text
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_toordseq") = txtSeq.Text
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_verno") = txtVerNo.Text
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_shpseq") = seq

            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_ftyshpstr") = DBNull.Value
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_ftyshpend") = DBNull.Value
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_cushpstr") = DBNull.Value
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_cushpend") = DBNull.Value

            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_shpqty") = 0

            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_podat") = DBNull.Value

            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_pckunt") = txtUM.Text
            rs_TODTLSHP.Tables("RESULT").Rows(rowcount).Item("tds_creusr") = "~*ADD*~"
        End If

        display_dgMShp(txtSeq.Text, txtVerNo.Text)
    End Sub

    Private Function save_TOORDHDR() As Boolean
        If rs_TOORDHDR.Tables("RESULT").Rows.Count = 0 Then
            save_TOORDHDR = True
            Exit Function
        End If

        Dim TOH_COCDE As String
        Dim TOH_TOORDNO As String
        Dim TOH_ORDSTS As String
        Dim TOH_ISSDAT As String
        Dim TOH_RVSDAT As String
        Dim TOH_SALDIV As String
        Dim TOH_SALTEM As String
        Dim TOH_SALREP As String
        Dim TOH_CUSTCDE As String
        Dim TOH_BUYER As String
        Dim TOH_YEAR As String
        Dim TOH_CUS1NO As String
        Dim TOH_CUS2NO As String
        Dim TOH_REFQUT As String
        Dim TOH_TO As String
        Dim TOH_CC As String
        Dim TOH_FM As String
        Dim TOH_RMK As String
        Dim TOH_SEASON As String
        Dim TOH_CREUSR As String


        'TOH_COCDE = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cocde")
        'TOH_TOORDNO = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_toordno")
        'TOH_ORDSTS = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_ordsts")
        'TOH_ISSDAT = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_issdat")
        'TOH_RVSDAT = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_rvsdat")
        'TOH_SALDIV = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_saldiv")
        'TOH_SALTEM = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_saltem")
        'TOH_SALREP = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_salrep")
        'TOH_CUSTCDE = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_custcde")
        'TOH_BUYER = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_buyer")
        'TOH_YEAR = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_year")
        'TOH_CUS1NO = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus1no")
        'TOH_CUS2NO = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus2no")
        'TOH_REFQUT = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_refqut")
        'TOH_TO = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_to")
        'TOH_CC = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cc")
        'TOH_FM = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_fm")
        'TOH_RMK = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_rmk")
        'TOH_SEASON = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_season")
        TOH_CREUSR = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr")

        TOH_TO = txtTO.Text
        TOH_CC = txtCC.Text
        TOH_FM = txtFm.Text
        TOH_RMK = txtHdrRmk.Text
        TOH_COCDE = cboCoCde.Text
        TOH_TOORDNO = txtTONo.Text
        TOH_BUYER = cboBuyer.Text

        gspStr = ""
        If TOH_CREUSR = "~*ADD*~" Then
            'gspStr = "sp_insert_TOORDHDR '" & TOH_COCDE & "','" & TOH_TOORDNO & "','" & TOH_ORDSTS & "','" & TOH_ISSDAT & "','" & TOH_RVSDAT & "','" & _
            '                                TOH_SALDIV & "','" & TOH_SALTEM & "','" & TOH_SALREP & "','" & TOH_CUSTCDE & "','" & TOH_BUYER & "','" & _
            '                                TOH_YEAR & "','" & TOH_CUS1NO & "','" & TOH_CUS2NO & "','" & TOH_REFQUT & "','" & TOH_TO & "','" & _
            '                                TOH_CC & "','" & TOH_FM & "','" & TOH_RMK & "','" & TOH_SEASON & "','" & gsUsrID & "'"
            'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            'If rtnLong <> RC_SUCCESS Then
            '    MsgBox("Error on loading save_TOORDHDR sp_insert_TOORDHDR :" & rtnStr)
            '    save_TOORDHDR = False
            '    Exit Function
            'End If
        ElseIf TOH_CREUSR = "~*UPD*~" Then
            gspStr = "sp_update_TOORDHDR_TOM00001 '" & TOH_COCDE & "','" & TOH_TOORDNO & "','" & TOH_TO & "','" & TOH_CC & "','" & TOH_FM & "','" & TOH_RMK & "','" & TOH_BUYER & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_TOORDHDR sp_update_TOORDHDR_TOM00001 :" & rtnStr)
                save_TOORDHDR = False
                Exit Function
            End If
        End If

        save_TOORDHDR = True
    End Function

    Private Function save_TOORDDTL() As Boolean
        If rs_TOORDDTL.Tables("RESULT").Rows.Count = 0 Then
            save_TOORDDTL = True
            Exit Function
        End If

        Dim TOD_COCDE As String
        Dim TOD_TOORDNO As String
        Dim TOD_TOORDSEQ As String
        Dim TOD_VERNO As String
        Dim TOD_LATEST As String
        Dim TOD_REFNO As String
        Dim TOD_MATCH As String
        Dim TOD_STS As String
        Dim TOD_TODAT As String
        Dim TOD_CUSTOMER As String
        Dim TOD_CUS1NO As String
        Dim TOD_CUS2NO As String
        Dim TOD_BUYER As String
        Dim TOD_CATEGORY As String
        Dim TOD_JOBNO As String
        Dim TOD_FTYITMNO As String
        Dim TOD_ITMSKU As String
        Dim TOD_FTYTMPITMNO As String
        Dim TOD_ITMDSC As String
        Dim TOD_VENNO As String
        Dim TOD_VENITM As String
        Dim TOD_COLCDE As String
        Dim TOD_INRQTY As String
        Dim TOD_MTRQTY As String
        Dim TOD_PCKUNT As String
        Dim TOD_CONFTR As String
        Dim TOD_CFT As String
        Dim TOD_CBM As String
        Dim TOD_FTYPRCTRM As String
        Dim TOD_HKPRCTRM As String
        Dim TOD_TRANTRM As String
        Dim TOD_PERIOD As String
        Dim TOD_FOBPORT As String
        Dim TOD_RETAIL As String
        Dim TOD_PROJQTY As String
        Dim TOD_FTYSHPDATSTR As String
        Dim TOD_FTYSHPDATEND As String
        Dim TOD_DSGVEN As String
        Dim TOD_PRDVEN As String
        Dim TOD_CUSVEN As String
        Dim TOD_IMGPTH As String
        Dim TOD_SAPNO As String
        Dim TOD_CUSPONO As String
        Dim TOD_RMK As String
        Dim TOD_UPC As String
        Dim TOD_CTNL As String
        Dim TOD_CTNW As String
        Dim TOD_CTNH As String
        Dim TOD_CTNUPC As String
        Dim TOD_VENSTK As String
        Dim TOD_CUSHPDATSTR As String
        Dim TOD_CUSHPDATEND As String
        Dim TOD_FCURCDE As String
        Dim TOD_FTYCST As String
        Dim TOD_CURCDE As String
        Dim TOD_SELPRC As String
        Dim TOD_QTYB_CUSPO As String
        Dim TOD_QTYB_ORDQTY As String
        Dim TOD_PODAT As String
        Dim TOD_PCKTYP As String
        Dim TOD_QUTNO As String
        Dim TOD_QUTSEQ As String
        Dim TOD_CREUSR As String
        Dim HeaderVerno As String = txtHdrVer.Text
        Dim TOD_CNTCTP As String
        Dim tod_basprc As Decimal
        Dim tod_qutitmsts As String

        Dim i As Integer

        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1

            TOD_COCDE = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cocde")
            TOD_TOORDNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordno")
            TOD_TOORDSEQ = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq")
            TOD_VERNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno")
            TOD_LATEST = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_latest")
            TOD_REFNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_refno")
            If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_match")) Then
                TOD_MATCH = ""
            Else
                TOD_MATCH = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_match")
            End If

            TOD_STS = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_sts")
            TOD_TODAT = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_todat")
            TOD_CUSTOMER = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_customer")
            TOD_CUS1NO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cus1no")
            TOD_CUS2NO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cus2no")
            TOD_BUYER = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_buyer")
            TOD_CATEGORY = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_category")
            TOD_JOBNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_jobno")
            TOD_FTYITMNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyitmno")
            TOD_ITMSKU = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_itmsku")
            TOD_FTYTMPITMNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftytmpitmno")
            TOD_ITMDSC = Replace(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_itmdsc").ToString, "'", "''")
            TOD_VENNO = Split(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_venno").ToString, " - ")(0)
            TOD_VENITM = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_venitm")
            TOD_COLCDE = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_colcde")
            TOD_INRQTY = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_inrqty")
            TOD_MTRQTY = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_mtrqty")
            TOD_PCKUNT = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_pckunt")
            TOD_CONFTR = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_conftr")
            TOD_CFT = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cft")
            TOD_CBM = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cbm")
            TOD_FTYPRCTRM = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyprctrm")
            TOD_HKPRCTRM = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_hkprctrm")
            TOD_TRANTRM = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_trantrm")
            TOD_PERIOD = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_period")
            TOD_FOBPORT = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_fobport")
            TOD_RETAIL = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_retail")
            TOD_PROJQTY = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_projqty")

            If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatstr")) = True Then
                TOD_FTYSHPDATSTR = "1/1/1900"
            Else
                TOD_FTYSHPDATSTR = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatstr"))
            End If

            'TOD_FTYSHPDATSTR = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatstr"))

            If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatend")) = True Then
                TOD_FTYSHPDATEND = "1/1/1900"
            Else
                TOD_FTYSHPDATEND = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatend"))
            End If
            'TOD_FTYSHPDATEND = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatend"))

            TOD_DSGVEN = Split(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_dsgven"), " - ")(0)
            TOD_PRDVEN = Split(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_prdven"), " - ")(0)
            TOD_CUSVEN = Split(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cusven"), " - ")(0)
            TOD_IMGPTH = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_imgpth")
            TOD_SAPNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_sapno")
            TOD_CUSPONO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cuspono")
            TOD_RMK = Replace(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_rmk").ToString, "'", "''")
            TOD_UPC = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_upc")
            TOD_CTNL = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ctnL")
            TOD_CTNW = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ctnW")
            TOD_CTNH = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ctnH")
            TOD_CTNUPC = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ctnupc")
            TOD_VENSTK = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_venstk")

            If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatstr")) = True Then
                TOD_CUSHPDATSTR = "1/1/1900"
            Else
                TOD_CUSHPDATSTR = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatstr"))
            End If

            'TOD_CUSHPDATSTR = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatstr"))

            If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatend")) = True Then
                TOD_CUSHPDATEND = "1/1/1900"
            Else
                TOD_CUSHPDATEND = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatend"))
            End If

            'TOD_CUSHPDATEND = Convert.ToDateTime(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatend"))
            TOD_FCURCDE = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_fcurcde")
            TOD_FTYCST = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftycst")
            TOD_CURCDE = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_curcde")
            TOD_SELPRC = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_selprc")
            TOD_QTYB_CUSPO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_qtyb_cuspo")
            TOD_QTYB_ORDQTY = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_qtyb_ordqty")


            If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_podat")) = True Then
                TOD_PODAT = "1/1/1900"
            Else
                TOD_PODAT = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_podat")
            End If


            TOD_PCKTYP = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_pcktyp")
            TOD_QUTNO = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_qutno")
            TOD_QUTSEQ = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_qutseq")
            TOD_CREUSR = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_creusr")

            If IsDBNull(rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cntctp")) = True Then
                TOD_CNTCTP = ""
            Else
                TOD_CNTCTP = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cntctp")
            End If

            tod_basprc = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_basprc")
            tod_qutitmsts = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_qutitmsts")


            gspStr = ""
            If TOD_CREUSR = "Y" Then

            ElseIf TOD_CREUSR = "~*ADD*~" Then

            ElseIf TOD_CREUSR = "~*UPD*~" And TOD_LATEST = "Y" And TOD_VERNO = HeaderVerno Then
                gspStr = "sp_update_TOORDDTL '" & TOD_COCDE & "','" & TOD_TOORDNO & "'," & TOD_VERNO & "," & TOD_TOORDSEQ & "," & TOD_PROJQTY & ",'" & TOD_FTYSHPDATSTR & "','" & _
                                            TOD_FTYSHPDATEND & "','" & TOD_CUSHPDATSTR & "','" & TOD_CUSHPDATEND & "','" & TOD_RMK & "','" & _
                                            TOD_DSGVEN & "','" & TOD_PRDVEN & "','" & TOD_CUSVEN & "','" & TOD_PODAT & "','" & TOD_CNTCTP & "','" & TOD_MATCH & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_TOORDDTL sp_update_TOORDDTL :" & rtnStr)
                    save_TOORDDTL = False
                    Exit Function
                End If

            ElseIf TOD_CREUSR = "~*UPD*~" And TOD_LATEST = "Y" And TOD_VERNO <> HeaderVerno Then

                gspStr = "sp_insert_TOORDDTL_TOM0001 '" & gsCompany & "','" & TOD_TOORDNO & "'," & TOD_TOORDSEQ & "," & HeaderVerno & ",'" & _
                                    TOD_LATEST & "','" & TOD_REFNO & "','" & TOD_MATCH & "','" & _
                                    TOD_STS & "','" & TOD_TODAT & "','" & TOD_CUSTOMER & "','" & _
                                    TOD_CUS1NO & "','" & TOD_CUS2NO & "','" & TOD_BUYER & "','" & _
                                    TOD_CATEGORY & "','" & TOD_JOBNO & "','" & TOD_FTYITMNO & "','" & _
                                    TOD_ITMSKU & "','" & TOD_FTYTMPITMNO & "','" & TOD_ITMDSC & "','" & _
                                    TOD_VENNO & "','" & TOD_VENITM & "','" & TOD_COLCDE & "'," & _
                                    TOD_INRQTY & "," & TOD_MTRQTY & ",'" & TOD_PCKUNT & "'," & TOD_CONFTR & "," & _
                                    TOD_CFT & "," & TOD_CBM & ",'" & TOD_FTYPRCTRM & "','" & _
                                    TOD_HKPRCTRM & "','" & TOD_TRANTRM & "','" & TOD_PERIOD & "','" & _
                                    TOD_FOBPORT & "'," & _
                                    TOD_RETAIL & "," & _
                                    TOD_PROJQTY & ",'" & TOD_FTYSHPDATSTR & "','" & _
                                    TOD_FTYSHPDATEND & "','" & _
                                    TOD_DSGVEN & "','" & TOD_PRDVEN & "','" & _
                                    TOD_CUSVEN & "','" & TOD_IMGPTH & "','" & TOD_SAPNO & "','" & _
                                    TOD_CUSPONO & "','" & _
                                    TOD_RMK & "','" & TOD_UPC & "'," & _
                                    TOD_CTNL & "," & TOD_CTNW & "," & _
                                    TOD_CTNH & ",'" & TOD_CTNUPC & "','" & _
                                    TOD_VENSTK & "','" & TOD_CUSHPDATSTR & "','" & _
                                    TOD_CUSHPDATEND & "','" & TOD_FCURCDE & "'," & _
                                    TOD_FTYCST & ",'" & TOD_CURCDE & "'," & TOD_SELPRC & ",'" & _
                                    TOD_QTYB_CUSPO & "'," & TOD_QTYB_ORDQTY & ",'" & TOD_PODAT & "','" & _
                                    TOD_PCKTYP & "','" & TOD_QUTNO & "'," & TOD_QUTSEQ & ",'" & _
                                   TOD_CNTCTP & "'," & tod_basprc & ",'" & tod_qutitmsts & "','" & gsUsrID & "'"


                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading TOM00001 save_TOORDDTL  sp_insert_TOORDDTL_TOM0001 : " & rtnStr)
                    save_TOORDDTL = False
                    Exit Function
                End If

            End If
        Next i
        save_TOORDDTL = True
    End Function

    Private Function save_TODTLSHP() As Boolean

        If rs_TODTLSHP.Tables("RESULT").Rows.Count = 0 Then
            save_TODTLSHP = True
            Exit Function
        End If

        Dim tds_cocde As String
        Dim tds_toordno As String
        Dim tds_toordseq As Integer
        Dim tds_verno As Integer
        Dim tds_shpseq As Integer
        Dim tds_ftyshpstr As DateTime
        Dim tds_ftyshpend As DateTime
        Dim tds_cushpstr As DateTime
        Dim tds_cushpend As DateTime
        Dim tds_shpqty As Integer
        Dim tds_podat As DateTime
        Dim tds_pckunt As String
        Dim tds_creusr As String
        Dim Gen As String

        Dim i As Integer

        For i = 0 To rs_TODTLSHP.Tables("RESULT").Rows.Count - 1

            tds_cocde = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cocde")
            tds_toordno = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_toordno")
            tds_toordseq = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_toordseq")
            tds_verno = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_verno")
            tds_shpseq = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_shpseq")

            If IsDBNull(rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpstr")) = True Then
                tds_ftyshpstr = "#1/1/1900#"
            Else
                tds_ftyshpstr = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpstr")
            End If

            If IsDBNull(rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpend")) = True Then
                tds_ftyshpend = "#1/1/1900#"
            Else

                tds_ftyshpend = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpend")
            End If

            If IsDBNull(rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpstr")) = True Then
                tds_cushpstr = "#1/1/1900#"
            Else
                tds_cushpstr = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpstr")
            End If

            If IsDBNull(rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpend")) = True Then
                tds_cushpend = "#1/1/1900#"
            Else
                tds_cushpend = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpend")
            End If


            If IsDBNull(rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat")) = True Then
                tds_podat = "#1/1/1900#"
            Else
                tds_podat = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat")
            End If



            tds_shpqty = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_shpqty")
            tds_pckunt = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_pckunt")
            tds_creusr = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_creusr")
            Gen = rs_TODTLSHP.Tables("RESULT").Rows(i).Item("Gen")


            gspStr = ""
            If Gen = "Y" Then
                gspStr = "sp_physical_delete_TODTLSHP '','" & tds_toordno & "'," & tds_toordseq & "," & tds_verno & "," & tds_shpseq
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_TODTLSHP sp_physical_delete_TODTLSHP:" & rtnStr)
                    save_TODTLSHP = False
                    Exit Function
                End If
            ElseIf tds_creusr = "~*ADD*~" Then
                gspStr = "sp_insert_TODTLSHP '" & tds_cocde & "','" & tds_toordno & "'," & tds_toordseq & "," & tds_verno & "," & tds_shpseq & ",'" & tds_ftyshpstr & "','" & _
                                            tds_ftyshpend & "','" & tds_cushpstr & "','" & tds_cushpend & "','" & tds_shpqty & "','" & tds_podat & "','" & tds_pckunt & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_TODTLSHP sp_insert_TODTLSHP :" & rtnStr)
                    save_TODTLSHP = False
                    Exit Function
                End If
            ElseIf tds_creusr = "~*UPD*~" Then
                gspStr = "sp_update_TODTLSHP '" & tds_cocde & "','" & tds_toordno & "'," & tds_toordseq & "," & tds_verno & "," & tds_shpseq & ",'" & tds_ftyshpstr & "','" & _
                                            tds_ftyshpend & "','" & tds_cushpstr & "','" & tds_cushpend & "','" & tds_shpqty & "','" & tds_podat & "','" & tds_pckunt & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_TODTLSHP sp_update_TODTLSHP :" & rtnStr)
                    save_TODTLSHP = False
                    Exit Function
                End If
            End If

        Next
        save_TODTLSHP = True

    End Function

    Private Sub UpdateDetail()
        Dim curseq As Integer
        Dim curver As Integer

        curseq = txtSeq.Text
        curver = txtVerNo.Text


        Dim i As Integer
        Dim loc As Integer
        loc = -1
        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If curseq = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq") And curver = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno") Then
                loc = i
                Exit For
            End If
        Next i

        'For ii As Integer = 0 To rs_TOORDDTL.Tables("RESULT").Columns.Count - 1
        '    rs_TOORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
        'Next

        If txtPrjQty.Text = "" Then
            MsgBox("Please Input Projected Quantity!")
            inputvalid = False
            TabPageMain.SelectedIndex = 1
            txtPrjQty.Focus()
            Exit Sub
        End If

        Dim sFilter As String

        sFilter = "tds_toordseq = " & txtSeq.Text & " and tds_verno = " & txtVerNo.Text

        rs_TODTLSHP.Tables("RESULT").DefaultView.RowFilter = sFilter

        Dim dr() As DataRow = rs_TODTLSHP.Tables("RESULT").Select("tds_toordseq = " & txtSeq.Text & " and tds_verno = " & txtVerNo.Text)

        If dr.Length > 0 Then
            Dim sumqty As Integer = 0


            For i = 0 To dr.Length - 1
                sumqty += dr(i)("tds_shpqty")
            Next

            If Convert.ToInt32(txtPrjQty.Text) < sumqty Then
                MsgBox("Multiple Ship QTY must not over than Projected QTY!")
                TabPageMain.SelectedIndex = 1
                txtPrjQty.Focus()
                inputvalid = False
                Exit Sub
            End If

        End If


        If Not IsDate(txtFtyShpDateStr.Text) = True Or txtFtyShpDateStr.Text.Length <> 10 And txtFtyShpDateStr.Text <> "  /  /" Then


            'abc
            If Not txtFtyShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtFtyShpDateStr.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateStr.Focus()
                    inputvalid = False
                    Exit Sub
                End If

            End If




            If txtFtyShpDateStr.Text <> "  /  /" Then
                If Convert.ToDateTime(txtFtyShpDateStr.Text).Year < 2000 And txtFtyShpDateStr.Text <> "01/01/1900" Then '+
                    MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateStr.Focus()
                    inputvalid = False
                    Exit Sub
                End If
            End If

            If txtFtyShpDateStr.Text <> "  /  /" Then
                MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                inputvalid = False
                TabPageMain.SelectedIndex = 1
                txtFtyShpDateStr.Focus()
                Exit Sub
            End If
        End If

        If Not IsDate(txtFtyShpDateEnd.Text) = True Or txtFtyShpDateEnd.Text.Length <> 10 And txtFtyShpDateEnd.Text <> "  /  /" Then



            If Not txtFtyShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtFtyShpDateEnd.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateEnd.Focus()
                    inputvalid = False
                    Exit Sub
                End If

            End If





            If txtFtyShpDateEnd.Text <> "  /  /" Then
                If Convert.ToDateTime(txtFtyShpDateEnd.Text).Year < 2000 And txtFtyShpDateEnd.Text <> "01/01/1900" Then '+
                    MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateEnd.Focus()
                    inputvalid = False
                    Exit Sub
                End If
            End If

            If txtFtyShpDateEnd.Text <> "  /  /" Then
                MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                inputvalid = False
                TabPageMain.SelectedIndex = 1
                txtFtyShpDateEnd.Focus()
                Exit Sub
            End If
        End If

        If Not IsDate(txtCustShpDateEnd.Text) = True Or txtCustShpDateEnd.Text.Length <> 10 And txtCustShpDateEnd.Text <> "  /  /" Then



            If Not txtCustShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtCustShpDateEnd.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateEnd.Focus()
                    inputvalid = False
                    Exit Sub
                End If

            End If



            If txtCustShpDateEnd.Text <> "  /  /" Then
                If Convert.ToDateTime(txtCustShpDateEnd.Text).Year < 2000 And txtCustShpDateEnd.Text <> "01/01/1900" Then '+
                    MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateEnd.Focus()
                    inputvalid = False
                    Exit Sub
                End If
            End If

            If txtCustShpDateEnd.Text <> "  /  /" Then
                MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                inputvalid = False
                TabPageMain.SelectedIndex = 1
                txtCustShpDateEnd.Focus()
                Exit Sub
            End If
        End If

        If Not IsDate(txtCustShpDateStr.Text) = True Or txtCustShpDateStr.Text.Length <> 10 And txtCustShpDateStr.Text <> "  /  /" Then


            If Not txtCustShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtCustShpDateStr.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateStr.Focus()
                    inputvalid = False
                    Exit Sub
                End If

            End If




            If txtCustShpDateStr.Text <> "  /  /" Then
                If Convert.ToDateTime(txtCustShpDateStr.Text).Year < 2000 And txtCustShpDateStr.Text <> "01/01/1900" Then '+
                    MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateStr.Focus()
                    inputvalid = False
                    Exit Sub
                End If
            End If

            If txtCustShpDateStr.Text <> "  /  /" Then
                MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                inputvalid = False
                TabPageMain.SelectedIndex = 1
                txtCustShpDateStr.Focus()
                Exit Sub
            End If
        End If


        If (Not IsDate(txtPODate.Text) = True Or txtPODate.Text.Length <> 10) And txtPODate.Text <> "  /  /" Then



            If Convert.ToDateTime(txtPODate.Text).Year < 2000 And txtPODate.Text <> "01/01/1900" Then
                MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                TabPageMain.SelectedIndex = 1
                txtPODate.Focus()
                inputvalid = False
                Exit Sub
            End If



            MsgBox("Please Input Effective Date [MM/dd/yyyy]!")
            inputvalid = False
            TabPageMain.SelectedIndex = 1
            txtPODate.Focus()
            Exit Sub
        End If



        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_projqty") = txtPrjQty.Text

        If txtFtyShpDateStr.Text = "  /  /" Then
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatstr") = DBNull.Value
        Else
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatstr") = txtFtyShpDateStr.Text
        End If

        If txtFtyShpDateEnd.Text = "  /  /" Then
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatend") = DBNull.Value
        Else
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_ftyshpdatend") = txtFtyShpDateEnd.Text
        End If

        If txtCustShpDateStr.Text = "  /  /" Then
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatstr") = DBNull.Value
        Else
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatstr") = txtCustShpDateStr.Text
        End If

        If txtCustShpDateEnd.Text = "  /  /" Then
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatend") = DBNull.Value
        Else
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cushpdatend") = txtCustShpDateEnd.Text
        End If

        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_rmk") = txtDtlRmk.Text

        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_dsgven") = cboDV.Text  'fking care
        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_prdven") = cboPV.Text
        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cusven") = cboCV.Text


        If txtPODate.Text = "  /  /" Then
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_podat") = DBNull.Value
        Else
            rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_podat") = txtPODate.Text
        End If



        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_cntctp") = cboConPer.Text
        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_match") = txtMatch.Text


    End Sub

    Private Sub MarkasUpdate()

        Dim curseq As Integer
        Dim curver As Integer

        curseq = txtSeq.Text
        curver = txtVerNo.Text

        Dim i As Integer
        Dim loc As Integer
        loc = -1
        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If curseq = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq") And curver = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno") Then
                loc = i
                Exit For
            End If
        Next i

        rs_TOORDDTL.Tables("RESULT").Rows(loc).Item("tod_creusr") = "~*UPD*~"



    End Sub

    Private Sub txtPrjQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrjQty.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

     

    Private Sub dgTODtl_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTODtl.CellClick
        If mode = "READ" Then
            Exit Sub
        End If

        If cboTOStatus.Text = "REL - Released" Then
            Exit Sub
        End If

        If dgTODtl.Item(dgTODtl_tod_latest, dgTODtl.CurrentCell.RowIndex).Value.ToString = "N" Then
            Exit Sub
        End If

        Select Case dgTODtl.CurrentCell.ColumnIndex

            Case dgTODtl_tod_prdven, dgTODtl_tod_cusven
                comboBoxCell(dgTODtl, "VN")
                'If dgTODtl.CurrentCell.ColumnIndex = dgTODtl_tod_dsgven Then
                '    Dim code As String = dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value.ToString
                '    If code <> "" Then
                '        dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value = displayVnName(code)
                '    End If
                'ElseIf dgTODtl.CurrentCell.ColumnIndex = dgTODtl_tod_prdven Then
                '    Dim code As String = dgTODtl.Item(dgTODtl_tod_prdven, dgTODtl.CurrentCell.RowIndex).Value.ToString
                '    If code <> "" Then
                '        dgTODtl.Item(dgTODtl_tod_prdven, dgTODtl.CurrentCell.RowIndex).Value = displayVnName(code)
                '    End If
                'ElseIf dgTODtl.CurrentCell.ColumnIndex = dgTODtl_tod_cusven Then
                '    Dim code As String = dgTODtl.Item(dgTODtl_tod_cusven, dgTODtl.CurrentCell.RowIndex).Value.ToString
                '    If code <> "" Then
                '        dgTODtl.Item(dgTODtl_tod_cusven, dgTODtl.CurrentCell.RowIndex).Value = displayVnName(code)
                '    End If
                'End If
            Case dgtodtl_tod_cntctp
                comboBoxCell(dgTODtl, "CNT")
        End Select


    End Sub

    Private Function displayVnName(ByVal code As String)

        For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
            If code = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") Then
                Return rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                Exit Function
            End If

        Next

        Return Split(code, " - ")(0)


    End Function


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
            Case "CNT"

                gspStr = "sp_list_VNCNTINF '','" & dgv.Item(dgTODtl_tod_prdven, iRow).Value.ToString & "','*','PER'"
                rtnLong = execute_SQLStatement(gspStr, rs_VNCNTPER, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_*_PER :" & rtnStr)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                For i = 0 To rs_VNCNTPER.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_VNCNTPER.Tables("RESULT").Rows(i).Item("vci_cntctp"))
                Next i


        End Select

        'cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub

    Private Sub dgTODtl_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTODtl.CellEndEdit

        If mode = "UPDATE" Then
            Recordstatus = True

            dgTODtl.Item(dgTODtl_tod_creusr, e.RowIndex).Value = "~*UPD*~"


        End If

    End Sub


    Private Sub dgTODtl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTODtl.CellContentClick

    End Sub

    Private Sub txtFtyShpDateStr_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtFtyShpDateStr.MaskInputRejected
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub cmdMShpSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMShpSave.Click


        If check_equalqty() = False Then
            MsgBox("Please ensure Multiple Shipment total qty is equal to Tentative's projected qty")
            Exit Sub
        End If


        If save_TODTLSHP() = True Then
            MsgBox("Record Saved")
            cmdMShpExit_Click(sender, e)

            gspStr = "sp_select_TODTLSHP '" & "" & "','" & txtTONo.Text & "'" 'cbocode?
            rtnLong = execute_SQLStatement(gspStr, rs_TODTLSHP, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading TOM00001_Load cmdMShpSave_Click :" & rtnStr)
                Exit Sub
            End If

            Dim i As Integer

            For i = 0 To rs_TODTLSHP.Tables("RESULT").Columns.Count - 1
                rs_TODTLSHP.Tables("RESULT").Columns(i).ReadOnly = False
            Next

            For i = 0 To rs_TODTLSHP.Tables("RESULT").Rows.Count - 1
                If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpstr") = "#1/1/1900#" Then
                    rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpstr") = DBNull.Value
                End If

                If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpend") = "#1/1/1900#" Then
                    rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_ftyshpend") = DBNull.Value
                End If

                If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpstr") = "#1/1/1900#" Then
                    rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpstr") = DBNull.Value
                End If

                If rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpend") = "#1/1/1900#" Then
                    rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_cushpend") = DBNull.Value
                End If

                If IsDBNull(rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat")) = True Then
                    rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat") = DBNull.Value
                ElseIf rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat") = "#1/1/1900#" Then
                    rs_TODTLSHP.Tables("RESULT").Rows(i).Item("tds_podat") = DBNull.Value
                End If

            Next

        Else
            MsgBox("Record Save Fail!")
        End If



    End Sub

    Private Function check_equalqty() As Boolean

        

        For i As Integer = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_latest") = "Y" Then
                Dim seq As Integer
                Dim ver As Integer
                Dim totalqty As Integer
                Dim ttlshpqty As Integer = 0
                seq = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq")
                ver = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno")
                totalqty = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_projqty")

                Dim dr() As DataRow = rs_TODTLSHP.Tables("RESULT").Select("tds_toordseq = " & seq & " and tds_verno = " & ver)
                If dr.Length <> 0 Then
                    For ii As Integer = 0 To dr.Length - 1
                        ttlshpqty = ttlshpqty + dr(ii)("tds_shpqty")
                    Next

                    If ttlshpqty <> totalqty Then
                        display_TODtl(seq, ver)
                        display_dgMShp(seq, ver)
                        Return False
                        Exit Function
                    End If
                End If
            End If
        Next

        Return True



    End Function


    Private Function check_SumMuitQTY() As Boolean

        If rs_TODTLSHP.Tables("RESULT").Rows.Count = 0 Then
            check_SumMuitQTY = False
            Exit Function
        End If


        For i As Integer = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_latest") = "Y" Then
                Dim seq As Integer
                Dim ver As Integer

                seq = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_toordseq")
                ver = rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_verno")



            End If
        Next




    End Function


    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click

    End Sub

    Private Sub cboDV_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDV.KeyUp
        auto_search_combo(cboDV)
    End Sub

    Private Sub cboPV_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPV.KeyUp
        auto_search_combo(cboPV)
    End Sub

    Private Sub cboCV_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCV.KeyUp
        auto_search_combo(cboCV)
    End Sub

    Private Sub cboDV_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboDV.Validating
        Dim tmpstr As String
        tmpstr = cboDV.Text

        If cboDV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Design Vendor!")
            e.Cancel = True
            Exit Sub
        End If

        If cboDV.Text <> "" Then
            If mode = "UPDATE" Then

                MarkasUpdate()
            End If
        End If

    End Sub

    Private Sub cboPV_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPV.Validating
        Dim tmpstr As String
        tmpstr = cboPV.Text

        If cboPV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Production Vendor!")
            e.Cancel = True
            Exit Sub
        End If
        If cboPV.Text <> "" Then
            If mode = "UPDATE" Then

                MarkasUpdate()
            End If
        End If
    End Sub

    Private Sub cboCV_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCV.Validating
        Dim tmpstr As String
        tmpstr = cboCV.Text

        If cboCV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Custom Vendor!")
            e.Cancel = True
            Exit Sub
        End If
        If cboCV.Text <> "" Then
            If mode = "UPDATE" Then

                MarkasUpdate()
            End If
        End If
    End Sub

    Private Sub txtPrjQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrjQty.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")

            Exit Sub
        End If

        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtFtyShpDateStr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFtyShpDateStr.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub cboDV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDV.SelectedIndexChanged

    End Sub

    Private Sub cboPV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPV.SelectedIndexChanged

        If cboPV.Text = "" Then
            Exit Sub
        End If

        Dim str As String
        str = Split(cboPV.Text, " - ")(0)


        gspStr = "sp_list_VNCNTINF '','" & str & "','*','PER'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTPER, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_*_PER :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        format_ConPerCom()

    End Sub

    Private Sub cboCV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCV.SelectedIndexChanged

    End Sub

    Private Sub cboDV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDV.LostFocus
        If cboDV.Items.IndexOf(cboDV.Text) <> -1 Then
            UpdateDetail()
        End If


    End Sub

    Private Sub cboPV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPV.LostFocus
        If cboPV.Items.IndexOf(cboPV.Text) <> -1 Then
            UpdateDetail()
        End If
    End Sub

    Private Sub cboCV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCV.LostFocus
        If cboCV.Items.IndexOf(cboCV.Text) <> -1 Then
            UpdateDetail()
        End If
    End Sub

    Private Sub dgMShp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMShp.CellClick
        If mode = "READ" Then
            Exit Sub
        End If

        If cboTOStatus.Text = "REL - Released" Then
            Exit Sub
        End If


    End Sub



    Private Sub dgMShp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMShp.CellContentClick

    End Sub

    Private Sub dgMShp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMShp.CellDoubleClick
        If mode = "READ" Then
            Exit Sub
        End If

        If cboTOStatus.Text = "REL - Released" Then
            Exit Sub
        End If


        If dgMShp.RowCount > 0 Then


            If dgMShp.CurrentCell.ColumnIndex = dgMshp_Gen Then
                Dim iCol As Integer = dgMShp.CurrentCell.ColumnIndex
                Dim iRow As Integer = dgMShp.CurrentCell.RowIndex
                Dim curvalue As String
                curvalue = dgMShp.CurrentCell.Value
                If Trim(curvalue) = "" Then

                    dgMShp.Item(dgMshp_Gen, iRow).Value = "Y"

                Else
                    dgMShp.Item(dgMshp_Gen, iRow).Value = ""
                End If

                If dgMShp.Item(dgMShp_tds_creusr, iRow).Value <> "~*ADD*~" Then
                    dgMShp.Item(dgMShp_tds_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub

    Private Sub dgMShp_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMShp.CellEndEdit
        If mode = "UPDATE" Then
            Recordstatus = True


            Select Case dgMShp.CurrentCell.ColumnIndex

                Case dgMShp_tds_ftyshpstr

                    If dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value.ToString = "" Then
                        dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value = dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value
                    End If

                Case dgMShp_tds_ftyshpend

                    If dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value.ToString = "" Then
                        dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value = dgMShp.Item(dgMShp_tds_ftyshpend, dgMShp.CurrentCell.RowIndex).Value
                    End If

            End Select



            If dgMShp.Item(dgMShp_tds_creusr, e.RowIndex).Value <> "~*ADD*~" Then
                dgMShp.Item(dgMShp_tds_creusr, e.RowIndex).Value = "~*UPD*~"

            End If
        End If





    End Sub


    Private Sub dgTODtl_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgTODtl.EditingControlShowing
        Select Case dgTODtl.CurrentCell.ColumnIndex
            Case dgTODtl_tod_dsgven, dgTODtl_tod_prdven, dgTODtl_tod_cusven
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                    End If
                End If

        End Select
    End Sub

    Private Sub dgTODtl_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgTODtl.DataError

    End Sub


    Private Sub dgTODtl_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTODtl.CellValidated
        Try
            Dim txtCell As New DataGridViewTextBoxCell
            Select Case dgTODtl.CurrentCell.ColumnIndex

                Case dgTODtl_tod_dsgven
                    'dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value = Split(dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value, " - ")(0)
                    dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex) = txtCell
                Case dgTODtl_tod_prdven
                    'dgTODtl.Item(dgTODtl_tod_prdven, dgTODtl.CurrentCell.RowIndex).Value = Split(dgTODtl.Item(dgTODtl_tod_prdven, dgTODtl.CurrentCell.RowIndex).Value, " - ")(0)
                    dgTODtl.Item(dgTODtl_tod_prdven, dgTODtl.CurrentCell.RowIndex) = txtCell
                Case dgTODtl_tod_cusven
                    'dgTODtl.Item(dgTODtl_tod_cusven, dgTODtl.CurrentCell.RowIndex).Value = Split(dgTODtl.Item(dgTODtl_tod_cusven, dgTODtl.CurrentCell.RowIndex).Value, " - ")(0)
                    dgTODtl.Item(dgTODtl_tod_cusven, dgTODtl.CurrentCell.RowIndex) = txtCell
                Case dgtodtl_tod_cntctp
                    dgTODtl.Item(dgtodtl_tod_cntctp, dgTODtl.CurrentCell.RowIndex) = txtCell

            End Select
        Catch
        End Try

    End Sub

    Private Sub dgTODtl_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgTODtl.CellValidating
        Dim row As DataGridViewRow = dgTODtl.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case dgTODtl_tod_ftyshpdatstr, dgTODtl_tod_ftyshpdatend, dgTODtl_tod_cushpdatstr, dgTODtl_tod_cushpdatend, dgTODtl_tod_podat

                    If strNewVal = "" Then
                        Exit Sub
                    End If

                    If strNewVal.Length <> 10 Or IsDate(strNewVal) = False Then
                        MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                        e.Cancel = True
                        Exit Sub
                    ElseIf Convert.ToDateTime(strNewVal).Year < 2000 And strNewVal <> "01/01/1900" Then

                        MsgBox("Please Input Effective Date [MM/dd/yyyy] & [Year>2000]!")
                        e.Cancel = True
                        Exit Sub

                   
                    End If




                    If rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_issdat") > Convert.ToDateTime(strNewVal) Then
                        MsgBox("Ship Date cannot earlier than Issue Date")
                        e.Cancel = True
                        Exit Sub
                    End If


                    If e.ColumnIndex = dgTODtl_tod_ftyshpdatstr Then




                        If IsDate(dgTODtl.Item(dgTODtl_tod_ftyshpdatend, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_ftyshpdatend, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgTODtl.Item(dgTODtl_tod_ftyshpdatend, dgTODtl.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgTODtl.Item(dgTODtl_tod_cushpdatstr, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_cushpdatstr, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgTODtl.Item(dgTODtl_tod_cushpdatstr, dgTODtl.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("Start of Customer Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If


                    If e.ColumnIndex = dgTODtl_tod_ftyshpdatend Then

                        If IsDate(dgTODtl.Item(dgTODtl_tod_ftyshpdatstr, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_ftyshpdatstr, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgTODtl.Item(dgTODtl_tod_ftyshpdatstr, dgTODtl.CurrentCell.RowIndex).Value Then
                                    MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgTODtl.Item(dgTODtl_tod_cushpdatend, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_cushpdatend, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgTODtl.Item(dgTODtl_tod_cushpdatend, dgTODtl.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If
                    'fk
                    If e.ColumnIndex = dgTODtl_tod_cushpdatstr Then


                        If IsDate(dgTODtl.Item(dgTODtl_tod_cushpdatend, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_cushpdatend, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgTODtl.Item(dgTODtl_tod_cushpdatend, dgTODtl.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgTODtl.Item(dgTODtl_tod_ftyshpdatstr, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_ftyshpdatstr, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgTODtl.Item(dgTODtl_tod_ftyshpdatstr, dgTODtl.CurrentCell.RowIndex).Value Then
                                    MsgBox("Start of Cust Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If


                    If e.ColumnIndex = dgTODtl_tod_cushpdatend Then


                        If IsDate(dgTODtl.Item(dgTODtl_tod_cushpdatstr, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_cushpdatstr, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgTODtl.Item(dgTODtl_tod_cushpdatstr, dgTODtl.CurrentCell.RowIndex).Value Then
                                    MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgTODtl.Item(dgTODtl_tod_ftyshpdatend, dgTODtl.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgTODtl.Item(dgTODtl_tod_ftyshpdatend, dgTODtl.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgTODtl.Item(dgTODtl_tod_ftyshpdatend, dgTODtl.CurrentCell.RowIndex).Value Then
                                    MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If


                Case dgTODtl_tod_projqty
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid Quantity!")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        End If
    End Sub

    Private Sub dgMShp_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgMShp.CellValidating
        Dim row As DataGridViewRow = dgMShp.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex




                Case dgMShp_tds_ftyshpstr, dgMShp_tds_ftyshpend, dgMShp_tds_cushpstr, dgMShp_tds_cushpend

                    If strNewVal = "" Then
                        Exit Sub
                    End If


                    If strNewVal.Length <> 10 Or IsDate(strNewVal) = False Then

                        If e.ColumnIndex = dgMShp_tds_ftyshpstr Then
                            MsgBox("Please Input valid Fty Ship Start Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True
                        ElseIf e.ColumnIndex = dgMShp_tds_ftyshpend Then
                            MsgBox("Please Input valid Fty Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True
                        ElseIf e.ColumnIndex = dgMShp_tds_cushpstr Then
                            MsgBox("Please Input valid Cust Ship Start Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True
                        ElseIf e.ColumnIndex = dgMShp_tds_cushpend Then
                            MsgBox("Please Input valid Cust Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True

                        End If



                       
                        Exit Sub
                    ElseIf Convert.ToDateTime(strNewVal).Year < 2000 And strNewVal <> "01/01/1900" Then

                        If e.ColumnIndex = dgMShp_tds_ftyshpstr Then
                            MsgBox("Please Input valid Fty Ship Start Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True
                        ElseIf e.ColumnIndex = dgMShp_tds_ftyshpend Then
                            MsgBox("Please Input valid Fty Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True
                        ElseIf e.ColumnIndex = dgMShp_tds_cushpstr Then
                            MsgBox("Please Input valid Cust Ship Start Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True
                        ElseIf e.ColumnIndex = dgMShp_tds_cushpend Then
                            MsgBox("Please Input valid Cust Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
                            e.Cancel = True

                        End If

                    End If


                    If e.ColumnIndex = dgMShp_tds_ftyshpstr Then

                        If IsDate(dgMShp.Item(dgMShp_tds_ftyshpend, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_ftyshpend, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgMShp.Item(dgMShp_tds_ftyshpend, dgMShp.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("Start of Customer Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If


                        If IsDate(dgMShp.Item(dgmshp_tds_podat, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Convert.ToDateTime(dgMShp.Item(dgmshp_tds_podat, dgMShp.CurrentCell.RowIndex).Value) > Convert.ToDateTime(strNewVal) Then
                                MsgBox("PO Date can not later than Fty ship start date!")
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                    End If
                    If e.ColumnIndex = dgMShp_tds_ftyshpend Then


                        If IsDate(dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value Then
                                    MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If
                    'fk
                    If e.ColumnIndex = dgMShp_tds_cushpstr Then


                        If IsDate(dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If dgMShp.Item(dgMShp_tds_cushpend, dgMShp.CurrentCell.RowIndex).Value < Convert.ToDateTime(strNewVal) Then
                                    MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value Then
                                    MsgBox("Start of Cust Ship Date must be larger than Fty Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If


                    If e.ColumnIndex = dgMShp_tds_cushpend Then


                        If IsDate(dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgMShp.Item(dgMShp_tds_cushpstr, dgMShp.CurrentCell.RowIndex).Value Then
                                    MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                        If IsDate(dgMShp.Item(dgMShp_tds_ftyshpend, dgMShp.CurrentCell.RowIndex).Value) = True Then
                            If Format(dgMShp.Item(dgMShp_tds_ftyshpend, dgMShp.CurrentCell.RowIndex).Value, "MM/dd/yyyy").Length = 10 Then
                                If Convert.ToDateTime(strNewVal) < dgMShp.Item(dgMShp_tds_ftyshpend, dgMShp.CurrentCell.RowIndex).Value Then
                                    MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    End If


                Case dgMShp_tds_shpqty

                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid Quantity!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    Dim dtlqty As Integer = txtPrjQty.Text
                    Dim currentqty As Integer = dgMShp.Item(dgMShp_tds_shpqty, dgMShp.CurrentCell.RowIndex).Value
                    Dim sumqty As Integer = 0
                    Dim newqty As Integer = strNewVal
                    Dim i As Integer

                    For i = 0 To dgMShp.Rows.Count - 1
                        sumqty = sumqty + dgMShp.Item(dgMShp_tds_shpqty, i).Value

                    Next

                    If (sumqty + newqty - currentqty) > dtlqty Then
                        MsgBox("Multiple Ship QTY must not over than Projected QTY!")
                        e.Cancel = True
                    End If

                Case dgmshp_tds_podat

                    If strNewVal = "" Then
                        Exit Sub
                    End If


                    If strNewVal.Length <> 10 Or IsDate(strNewVal) = False Then

                        MsgBox("Please Input Valid PO Date [MM/dd/yyyy] & Year must be larger than 2000!")
                        e.Cancel = True
                        Exit Sub

                    ElseIf Convert.ToDateTime(strNewVal).Year < 2000 And strNewVal <> "01/01/1900" Then

                        MsgBox("Please Input Valid PO Date [MM/dd/yyyy] & Year must be larger than 2000!")
                        e.Cancel = True
                        Exit Sub

                    Else
                        If IsDate(dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value) = True Then

                            If Convert.ToDateTime(strNewVal) > Convert.ToDateTime(dgMShp.Item(dgMShp_tds_ftyshpstr, dgMShp.CurrentCell.RowIndex).Value) Then
                                MsgBox("PO Date can not later than Fty ship start date!")
                                e.Cancel = True
                                Exit Sub
                            End If

                        End If
                    End If



            End Select
        End If
    End Sub



    Private Sub txtPrjQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPrjQty.Validating
        If IsNumeric(txtPrjQty.Text) = False Then
            MsgBox("Qty must be number")
            txtPrjQty.Focus()
            Exit Sub
        End If



        Dim sFilter As String

        sFilter = "tds_toordseq = " & txtSeq.Text & " and tds_verno = " & txtVerNo.Text

        rs_TODTLSHP.Tables("RESULT").DefaultView.RowFilter = sFilter

        Dim dr() As DataRow = rs_TODTLSHP.Tables("RESULT").Select("tds_toordseq = " & txtSeq.Text & " and tds_verno = " & txtVerNo.Text)

        If dr.Length > 0 Then
            Dim sumqty As Integer = 0
            Dim i As Integer

            For i = 0 To dr.Length - 1
                sumqty += dr(i)("tds_shpqty")
            Next

            If Convert.ToInt32(txtPrjQty.Text) < sumqty Then
                MsgBox("Multiple Ship QTY must not over than Projected QTY!")
                txtPrjQty.Focus()
                Exit Sub
            End If

        End If

        If mode = "UPDATE" Then
            Recordstatus = True
            UpdateDetail()
        End If

    End Sub

    Private Sub txtFtyShpDateStr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFtyShpDateStr.Validating




        If (IsDate(txtFtyShpDateStr.Text) = True And txtFtyShpDateStr.Text.Length = 10) Or txtFtyShpDateStr.Text = "  /  /" Then

            If Not txtFtyShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtFtyShpDateStr.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateStr.Focus()
                    Exit Sub
                End If

            End If


            If Not txtFtyShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtFtyShpDateStr.Text).Year < 2000 And txtFtyShpDateStr.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Fty Ship Start Date [MM/dd/yyyy] & Year must be lager than '2000'!")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateStr.Focus()
                    Exit Sub
                End If
            End If


            If Not txtFtyShpDateStr.Text = "  /  /" Then
                If IsDate(txtFtyShpDateEnd.Text) = True And txtFtyShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtFtyShpDateEnd.Text) < Convert.ToDateTime(txtFtyShpDateStr.Text) Then
                        MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")
                        TabPageMain.SelectedIndex = 1
                        txtFtyShpDateStr.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If Not txtFtyShpDateStr.Text = "  /  /" Then
                If IsDate(txtCustShpDateStr.Text) = True And txtCustShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtCustShpDateStr.Text) < Convert.ToDateTime(txtFtyShpDateStr.Text) Then
                        MsgBox("Start of Customer Ship Date must be larger than Fty Ship Start date!")
                        TabPageMain.SelectedIndex = 1
                        txtFtyShpDateStr.Focus()
                        Exit Sub
                    End If
                End If
            End If



            If mode = "UPDATE" Then
                Recordstatus = True
                UpdateDetail()
            End If


        Else
            MsgBox("Please Input valid Fty Ship Start Date [MM/dd/yyyy] & Year must be lager than '2000'!")
            TabPageMain.SelectedIndex = 1
            txtFtyShpDateStr.Focus()
        End If
    End Sub

    Private Sub txtFtyShpDateEnd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFtyShpDateEnd.Validating




        If (IsDate(txtFtyShpDateEnd.Text) = True And txtFtyShpDateEnd.Text.Length = 10) Or txtFtyShpDateEnd.Text = "  /  /" Then



            If Not txtFtyShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtFtyShpDateEnd.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateEnd.Focus()
                    Exit Sub
                End If
            End If


            If Not txtFtyShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtFtyShpDateEnd.Text).Year < 2000 And txtFtyShpDateEnd.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Fty Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
                    TabPageMain.SelectedIndex = 1
                    txtFtyShpDateEnd.Focus()
                    Exit Sub
                End If
            End If

            If Not txtFtyShpDateEnd.Text = "  /  /" Then
                If IsDate(txtFtyShpDateStr.Text) = True And txtFtyShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtFtyShpDateEnd.Text) < Convert.ToDateTime(txtFtyShpDateStr.Text) Then
                        MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")
                        TabPageMain.SelectedIndex = 1
                        txtFtyShpDateEnd.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If Not txtFtyShpDateEnd.Text = "  /  /" Then
                If IsDate(txtCustShpDateEnd.Text) = True And txtCustShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtCustShpDateEnd.Text) < Convert.ToDateTime(txtFtyShpDateEnd.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")
                        TabPageMain.SelectedIndex = 1
                        txtFtyShpDateEnd.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If mode = "UPDATE" Then
                Recordstatus = True
                UpdateDetail()
            End If


        Else
            MsgBox("Please Input valid Fty Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
            TabPageMain.SelectedIndex = 1
            txtFtyShpDateEnd.Focus()
        End If

    End Sub

    Private Sub txtCustShpDateStr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCustShpDateStr.Validating
        'cust
        If (IsDate(txtCustShpDateStr.Text) = True And txtCustShpDateStr.Text.Length = 10) Or txtCustShpDateStr.Text = "  /  /" Then

            If Not txtCustShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtCustShpDateStr.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateStr.Focus()
                    Exit Sub
                End If
            End If



            If Not txtCustShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtCustShpDateStr.Text).Year < 2000 And txtCustShpDateStr.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Cust Ship Start Date [MM/dd/yyyy] &  Year must be larger than 2000!")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateStr.Focus()
                    Exit Sub
                End If
            End If


            If Not txtCustShpDateStr.Text = "  /  /" Then
                If IsDate(txtCustShpDateEnd.Text) = True And txtCustShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtCustShpDateEnd.Text) < Convert.ToDateTime(txtCustShpDateStr.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")
                        TabPageMain.SelectedIndex = 1
                        txtCustShpDateStr.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If Not txtCustShpDateStr.Text = "  /  /" Then
                If IsDate(txtFtyShpDateStr.Text) = True And txtFtyShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtCustShpDateStr.Text) < Convert.ToDateTime(txtFtyShpDateStr.Text) Then
                        MsgBox("Start of Cust Ship Date must be larger than Fty Ship Start date!")
                        TabPageMain.SelectedIndex = 1
                        txtCustShpDateStr.Focus()
                        Exit Sub
                    End If
                End If
            End If




            If mode = "UPDATE" Then
                Recordstatus = True
                UpdateDetail()
            End If


        Else
            MsgBox("Please Input valid Cust Ship Start Date [MM/dd/yyyy] &  Year must be larger than 2000!")
            TabPageMain.SelectedIndex = 1
            txtCustShpDateStr.Focus()
        End If

    End Sub

    Private Sub txtCustShpDateEnd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCustShpDateEnd.Validating
        'w
        If (IsDate(txtCustShpDateEnd.Text) = True And txtCustShpDateEnd.Text.Length = 10) Or txtCustShpDateEnd.Text = "  /  /" Then


            If Not txtCustShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtCustShpDateEnd.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateEnd.Focus()
                    Exit Sub
                End If
            End If


            If Not txtCustShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtCustShpDateEnd.Text).Year < 2000 And txtCustShpDateEnd.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Cust Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
                    TabPageMain.SelectedIndex = 1
                    txtCustShpDateEnd.Focus()
                    Exit Sub
                End If
            End If

            If Not txtCustShpDateEnd.Text = "  /  /" Then
                If IsDate(txtCustShpDateStr.Text) = True And txtCustShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtCustShpDateEnd.Text) < Convert.ToDateTime(txtCustShpDateStr.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")
                        TabPageMain.SelectedIndex = 1
                        txtCustShpDateEnd.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If Not txtCustShpDateEnd.Text = "  /  /" Then
                If IsDate(txtFtyShpDateEnd.Text) = True And txtFtyShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtCustShpDateEnd.Text) < Convert.ToDateTime(txtFtyShpDateEnd.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")
                        TabPageMain.SelectedIndex = 1
                        txtCustShpDateEnd.Focus()
                        Exit Sub
                    End If
                End If
            End If


            If mode = "UPDATE" Then
                Recordstatus = True
                UpdateDetail()
            End If


        Else
            MsgBox("Please Input valid Cust Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
            TabPageMain.SelectedIndex = 1
            txtCustShpDateEnd.Focus()

        End If



    End Sub

    Private Sub txtDtlRmk_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDtlRmk.Validating
        UpdateDetail()
    End Sub

    Private Sub txtTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTO.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtTO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTO.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTO.TextChanged

    End Sub

    Private Sub txtCC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCC.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtCC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCC.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtCC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCC.TextChanged

    End Sub

    Private Sub txtFm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFm.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFm.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged

    End Sub

    Private Sub txtHdrRmk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHdrRmk.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtHdrRmk_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHdrRmk.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtHdrRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHdrRmk.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTOM00003.Click
        FrmTOM0003 = New TOM00003
        FrmTOM0003.txtFromFactory.Text = txtTONo.Text.Trim
        FrmTOM0003.txtToFactory.Text = txtTONo.Text.Trim
        FrmTOM0003.public_cboCoCde_Text = cboCoCde.Text.Trim

        FrmTOM0003.ShowDialog()

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    End Sub

    Private Sub txtPODate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPODate.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtPODate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPODate.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtPODate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtPODate.MaskInputRejected
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtPODate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPODate.Validating


        If (IsDate(txtPODate.Text) = True And txtPODate.Text.Length = 10) Or txtPODate.Text = "  /  /" Then

            If txtPODate.Text <> "  /  /" Then
                If Convert.ToDateTime(txtPODate.Text).Year < 2000 And txtPODate.Text <> "01/01/1900" Then
                    MsgBox("Please Input vlaid PO Date [MM/dd/yyyy] & Year must be larger than 2000!")
                    TabPageMain.SelectedIndex = 1
                    txtPODate.Focus()
                    Exit Sub
                End If
            End If
            If mode = "UPDATE" Then
                Recordstatus = True
                UpdateDetail()
            End If


        Else
            MsgBox("Please Input vlaid PO Date [MM/dd/yyyy] & Year must be larger than 2000!")
            TabPageMain.SelectedIndex = 1
            txtPODate.Focus()
        End If
    End Sub


    Private Sub cmdStandShipConfrim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStandShipConfrim.Click






        If (IsDate(txtStandFtyShpDateStr.Text) = True And txtStandFtyShpDateStr.Text.Length = 10) Then 'Or txtStandFtyShpDateStr.Text <> "  /  /"

            If Not txtStandFtyShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtStandFtyShpDateStr.Text).Year < 2000 And txtStandFtyShpDateStr.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Fty Ship Start Date [MM/dd/yyyy] & Year must be lager than 2000!")

                    Exit Sub
                End If
            End If


            If Not txtStandFtyShpDateStr.Text = "  /  /" Then
                If IsDate(txtStandFtyShpDateEnd.Text) = True And txtStandFtyShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandFtyShpDateEnd.Text) < Convert.ToDateTime(txtStandFtyShpDateStr.Text) Then
                        MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")

                        Exit Sub
                    End If
                End If
            End If

            If Not txtStandFtyShpDateStr.Text = "  /  /" Then
                If IsDate(txtStandCustShpDateStr.Text) = True And txtStandCustShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandCustShpDateStr.Text) < Convert.ToDateTime(txtStandFtyShpDateStr.Text) Then
                        MsgBox("Start of Customer Ship Date must be larger than Fty Ship Start date!")


                        Exit Sub
                    End If
                End If

               
            End If

            If Not txtStandFtyShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtStandFtyShpDateStr.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")
                  
                    Exit Sub
                End If
            End If




        Else
            MsgBox("Please Input valid Fty Ship Start Date [MM/dd/yyyy] & Year must be lager than 2000!")


            Exit Sub
        End If


        If (IsDate(txtStandFtyShpDateEnd.Text) = True And txtStandFtyShpDateEnd.Text.Length = 10) Then ' Or txtStandFtyShpDateEnd.Text <> "  /  /" Then

            If Not txtStandFtyShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtStandFtyShpDateEnd.Text).Year < 2000 And txtStandFtyShpDateEnd.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Fty Ship End Date [MM/dd/yyyy] & Year must be lager than 2000!")


                    Exit Sub
                End If
            End If

            If Not txtStandFtyShpDateEnd.Text = "  /  /" Then
                If IsDate(txtStandFtyShpDateStr.Text) = True And txtStandFtyShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandFtyShpDateEnd.Text) < Convert.ToDateTime(txtStandFtyShpDateStr.Text) Then
                        MsgBox("End of Fty Ship Date must be larger than Fty Ship Start date!")


                        Exit Sub
                    End If
                End If
            End If
            If Not txtStandFtyShpDateEnd.Text = "  /  /" Then
                If IsDate(txtStandCustShpDateEnd.Text) = True And txtStandCustShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandCustShpDateEnd.Text) < Convert.ToDateTime(txtStandFtyShpDateEnd.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")


                        Exit Sub
                    End If
                End If
            End If

            If Not txtStandFtyShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtStandFtyShpDateEnd.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")

                    Exit Sub
                End If
            End If




        Else
            MsgBox("Please Input valid Fty Ship End Date [MM/dd/yyyy] & Year must be lager than 2000!")


            Exit Sub
        End If


        If (IsDate(txtStandCustShpDateStr.Text) = True And txtStandCustShpDateStr.Text.Length = 10) Then 'Or txtStandCustShpDateStr.Text <> "  /  /" Then

            If Not txtStandCustShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtStandCustShpDateStr.Text).Year < 2000 And txtStandCustShpDateStr.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Cust Ship Start Date [MM/dd/yyyy] & Year must be lager than 2000!")


                    Exit Sub
                End If
            End If


            If Not txtStandCustShpDateStr.Text = "  /  /" Then
                If IsDate(txtStandCustShpDateEnd.Text) = True And txtStandCustShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandCustShpDateEnd.Text) < Convert.ToDateTime(txtStandCustShpDateStr.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")


                        Exit Sub
                    End If
                End If
            End If

            If Not txtStandCustShpDateStr.Text = "  /  /" Then
                If IsDate(txtStandFtyShpDateStr.Text) = True And txtStandFtyShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandCustShpDateStr.Text) < Convert.ToDateTime(txtStandFtyShpDateStr.Text) Then
                        MsgBox("Start of Cust Ship Date must be larger than Fty Ship Start date!")


                        Exit Sub
                    End If
                End If
            End If

            If Not txtStandCustShpDateStr.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtStandCustShpDateStr.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")

                    Exit Sub
                End If
            End If


        Else
            MsgBox("Please Input valid Cust Ship Start Date [MM/dd/yyyy] & Year must be lager than 2000!")

            Exit Sub
        End If


        If (IsDate(txtStandCustShpDateEnd.Text) = True And txtStandCustShpDateEnd.Text.Length = 10) Then 'Or txtStandCustShpDateEnd.Text <> "  /  /" Then

            If Not txtStandCustShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtStandCustShpDateEnd.Text).Year < 2000 And txtStandCustShpDateEnd.Text <> "01/01/1900" Then
                    MsgBox("Please Input valid Cust Ship End Date [MM/dd/yyyy] & Year must be lager than 2000!")


                    Exit Sub
                End If
            End If

            If Not txtStandCustShpDateEnd.Text = "  /  /" Then
                If IsDate(txtStandCustShpDateStr.Text) = True And txtStandCustShpDateStr.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandCustShpDateEnd.Text) < Convert.ToDateTime(txtStandCustShpDateStr.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Cust Ship Start date!")


                        Exit Sub
                    End If
                End If
            End If

            If Not txtStandCustShpDateEnd.Text = "  /  /" Then
                If IsDate(txtStandFtyShpDateEnd.Text) = True And txtStandFtyShpDateEnd.Text.Length = 10 Then
                    If Convert.ToDateTime(txtStandCustShpDateEnd.Text) < Convert.ToDateTime(txtStandFtyShpDateEnd.Text) Then
                        MsgBox("End of Cust Ship Date must be larger than Fty Ship End date!")


                        Exit Sub
                    End If
                End If
            End If

            If Not txtStandCustShpDateEnd.Text = "  /  /" Then
                If Convert.ToDateTime(txtIssDat.Text) > Convert.ToDateTime(txtStandCustShpDateEnd.Text) Then
                    MsgBox("Ship Date cannot earlier than Issue Date")

                    Exit Sub
                End If
            End If



        Else
            MsgBox("Please Input valid Cust Ship End Date [MM/dd/yyyy] & Year must be lager than 2000!")


            Exit Sub
        End If

        Dim i As Integer

        For i = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            If rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_latest") = "Y" Then
                rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatstr") = txtStandFtyShpDateStr.Text
                rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_ftyshpdatend") = txtStandFtyShpDateEnd.Text
                rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatstr") = txtStandCustShpDateStr.Text
                rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_cushpdatend") = txtStandCustShpDateEnd.Text
                rs_TOORDDTL.Tables("RESULT").Rows(i).Item("tod_creusr") = "~*UPD*~"
            End If
        Next i



        Call display_TODtl(txtSeq.Text, txtVerNo.Text)

        Panel1.Visible = False
        MsgBox("Update Complete")

    End Sub

    Private Sub cmdStandShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdStandShipExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStandShipExit.Click
        Panel1.Visible = False
    End Sub

    Private Sub cboConPer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConPer.LostFocus
        If cboConPer.Items.IndexOf(cboConPer.Text) <> -1 Then
            UpdateDetail()
        End If
    End Sub

    Private Sub cboConPer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConPer.SelectedIndexChanged

    End Sub

    Private Sub cboConPer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboConPer.Validating
        Dim tmpstr As String
        tmpstr = cboConPer.Text

        If cboConPer.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Contact Person")
            e.Cancel = True
            Exit Sub
        End If
        If cboConPer.Text <> "" Then
            If mode = "UPDATE" Then

                MarkasUpdate()
            End If
        End If
    End Sub

    Private Sub cboBuyer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBuyer.KeyUp
        auto_search_combo(cboBuyer)
    End Sub

    Private Sub cboBuyer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBuyer.SelectedIndexChanged

        If cboBuyer.Text = "" Then
            Exit Sub
        End If
        Dim dr() As DataRow




        dr = rs_CUTOCUB.Tables("RESULT").Select("ctc_buycde = '" & cboBuyer.Text & "'")
        If Not dr.Length > 0 Then
            MsgBox("Invalid Buyer Code")
        Else
            txtBuyerName.Text = dr(0)("ctc_buynam").ToString
        End If

    End Sub

    Private Sub cboBuyer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboBuyer.Validating
        Dim tmpstr As String
        tmpstr = cboBuyer.Text

        If cboBuyer.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Buyer Code!")
            txtBuyerName.Text = ""
            e.Cancel = True
            Exit Sub
        End If

        If cboBuyer.Text <> "" Then
            If mode = "UPDATE" Then
                Recordstatus = True
                rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_creusr") = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub cmdStandShip_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStandShip.Click
        txtStandFtyShpDateStr.Text = ""
        txtStandFtyShpDateEnd.Text = ""
        txtStandCustShpDateStr.Text = ""
        txtStandCustShpDateEnd.Text = ""
        Panel1.Visible = True
        Panel1.Enabled = True
    End Sub

    Private Sub txt_datagridDates_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbBack Or (dgMShp.CurrentCell.ColumnIndex <> dgMShp_tds_cushpend And dgMShp.CurrentCell.ColumnIndex <> dgMShp_tds_cushpstr And _
                                  dgMShp.CurrentCell.ColumnIndex <> dgMShp_tds_ftyshpend And dgMShp.CurrentCell.ColumnIndex <> dgMShp_tds_ftyshpstr And _
                                  dgMShp.CurrentCell.ColumnIndex <> dgmshp_tds_podat) Then
            Exit Sub
        End If

        Dim curvalue As String = sender.Text.ToString

        If curvalue = "" Then
            Exit Sub
        ElseIf curvalue.Length = 10 Then
            e.KeyChar = ""
        ElseIf Split(sender.Text, "/").Length > 2 And e.KeyChar = "/" Then
            e.KeyChar = ""
        End If

        If Replace(curvalue, "/", "").Length = 2 Then
            If sender.Text.ToString.Substring(sender.Text.Length - 1, 1) <> "/" Then
                sender.Text = sender.Text + "/"
            End If
            sender.Select(sender.Text.Length, 0)
        ElseIf Replace(curvalue, "/", "").Length = 4 Then
            If sender.Text.ToString.Substring(sender.Text.Length - 1, 1) <> "/" Then
                sender.Text = sender.Text + "/"
            End If
            sender.Select(sender.Text.Length, 0)
        End If


         




    End Sub

    Private Sub dgMShp_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgMShp.EditingControlShowing
        ''doing auto add /


        If sender.Focused = False Then
            Exit Sub
        End If

        Select Case dgMShp.CurrentCell.ColumnIndex
            Case dgMShp_tds_cushpend, dgMShp_tds_cushpstr, dgMShp_tds_ftyshpend, dgMShp_tds_ftyshpstr, dgmshp_tds_podat
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    AddHandler txtbox.KeyPress, AddressOf txt_datagridDates_KeyPress
                    'AddHandler txtbox.TextChanged, AddressOf txt_dgSummary_TextChanged
                End If
            Case Else
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    RemoveHandler txtbox.KeyPress, AddressOf txt_datagridDates_KeyPress
                End If
        End Select


    End Sub

    Private Sub PanelMShp_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelMShp.Paint

    End Sub

    Private Sub cmdCloseTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelTO.Click
        Dim cloqty As Integer = 0
        Dim rs_tmp As DataSet = Nothing
        Dim rs_TOITMDTL As DataSet

        If Split(cboTOStatus.Text, " - ")(0) = "CAN" Then
            MsgBox("Tentative Order has already been cancelled.", MsgBoxStyle.Information, Me.Name & " - Cancel Tentative Order")
            Exit Sub
        End If

        If MsgBox("Confirm to cancel Tentative Order?", MsgBoxStyle.YesNo, Me.Name & " - Cancel Tentative Order") = MsgBoxResult.No Then
            Exit Sub
        End If

        gspStr = "sp_select_TOITMDTL_CAN_Chk '" & cboCoCde.Text & "','" & Trim(UCase(txtTONo.Text)) & "','" & LCase(gsUsrID) & "'"
        rs_tmp = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdCancelTO_Click sp_select_TOITMDTL_CAN_Chk :" & rtnStr)
            Exit Sub
        Else
            If rs_tmp.Tables("RESULT").Rows(0)("tid_exist") = "Y" And rs_tmp.Tables("RESULT").Rows(0)("tid_valid") = "N" Then
                MsgBox("There are items within this TO which are currently in use with Sales Confirmation" & Environment.NewLine & "TO cannot be cancelled", MsgBoxStyle.Exclamation, Me.Name & " - Cancel Tentative Order")
                Exit Sub
            End If
        End If

        For i As Integer = 0 To rs_TOORDDTL.Tables("RESULT").Rows.Count - 1
            ' Check if Detail is Latest
            If rs_TOORDDTL.Tables("RESULT").Rows(i)("tod_latest") <> "Y" Then
                Continue For
            End If

            ' Update TOORDDTL
            gspStr = "sp_update_TOORDDTL_CAN '" & cboCoCde.Text & "','" & Trim(UCase(txtTONo.Text)) & "','" & _
                     rs_TOORDDTL.Tables("RESULT").Rows(i)("tod_toordseq") & "','" & LCase(gsUsrID) & "'"
            rs_tmp = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on saving cmdCancelTO_Click sp_update_TOORDDTL_CAN :" & rtnStr)
                Exit Sub
            End If

            ' Update TOITMDTL
            gspStr = "sp_update_TOITMDTL_CAN '" & cboCoCde.Text & "','" & Trim(UCase(txtTONo.Text)) & "','" & _
                     rs_TOORDDTL.Tables("RESULT").Rows(i)("tod_toordseq") & "','" & LCase(gsUsrID) & "'"
            rs_tmp = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on saving cmdCancelTO_Click sp_update_TOITMDTL_CAN :" & rtnStr)
                Exit Sub
            Else
                If rs_TOITMDTL Is Nothing Then
                    For j As Integer = 0 To rs_tmp.Tables("RESULT").Columns.Count - 1
                        rs_tmp.Tables("RESULT").Columns(j).ReadOnly = False
                    Next
                    rs_TOITMDTL = rs_tmp.Clone()
                End If

                If rs_tmp.Tables("RESULT").Rows.Count > 0 Then
                    rs_TOITMDTL.Tables("RESULT").Rows.Add()
                    For j As Integer = 0 To rs_TOITMDTL.Tables("RESULT").Columns.Count - 1
                        rs_TOITMDTL.Tables("RESULT").Rows(rs_TOITMDTL.Tables("RESULT").Rows.Count - 1)(j) = rs_tmp.Tables("RESULT").Rows(0)(j)
                    Next
                End If
            End If
        Next

        If rs_TOITMDTL.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_TOITMDTL.Tables("RESULT").Rows.Count - 1
                ' Update TOITMSUM
                gspStr = "sp_update_TOITMSUM_CAN '" & rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_cocde") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_cus1no") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_cus2no") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_year") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_assitm") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_itmno") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_tmpitmno") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_venno") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_venitmno") & "','" & _
                         rs_TOITMDTL.Tables("RESULT").Rows(i)("tid_canqty") & "','" & LCase(gsUsrID) & "'"
                rs_tmp = Nothing
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                execute_SQLStatement(gspStr, rs_tmp, rtnLong)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on saving cmdCancelTO_Click sp_update_TOITMSUM_CAN :" & rtnStr)
                    Exit Sub
                End If
            Next
        End If

        ' Update TOORDHDR
        gspStr = "sp_update_TOORDHDR_CAN '" & cboCoCde.Text & "','" & txtTONo.Text & "','" & LCase(gsUsrID) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on saving cmdCancelTO_Click sp_update_TOORDHDR_CAN :" & rtnStr)
            Exit Sub
        End If

        MsgBox("Tentative Order Sucessfully Cancelled", MsgBoxStyle.Information, Me.Name & " - Cancel Tentative Order")
        Dim tmp_toordno As String = txtTONo.Text
        formInit("INIT")
        txtTONo.Text = tmp_toordno
        txtTONo.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtMatch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMatch.KeyPress

        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtMatch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMatch.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            MarkasUpdate()
        End If
    End Sub

    Private Sub txtMatch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMatch.LostFocus

        UpdateDetail()

    End Sub

    Private Sub txtMatch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMatch.TextChanged
         

         



    End Sub

    Private Sub txtPrjQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrjQty.TextChanged

    End Sub

    Private Sub txtPrjQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrjQty.LostFocus

    End Sub
End Class