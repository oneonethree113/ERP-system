Public Class QCM00001
    Dim conf_weekshown As Integer = 3  'Control how many weeks should show
    Public ma As QCM00002 'This should be declared in QCM00002
    Public str_typ As String

    Dim rs As New DataSet
    Dim rs_QCM00001 As DataSet
    Dim tbl_QCM00001_header As DataTable
    Dim dg_DetailView As DataView
    Dim dg_HeaderView As DataView

    'Search Tab Related
    Dim textboxlist As New Collection() 'a dictionary storing the index and the textbox object
    Dim POShipDateFm As String
    Dim POShipDateTo As String
    Dim SCShipDateFm As String
    Dim SCShipdateto As String

    Dim tbl_Detail As DataTable
    Dim tbl_Header As DataTable

    Dim Msg As String
    Dim today As Date = Date.Today

    Dim mmdPrint_Right As Boolean = False

    Private Sub QCM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(cboCocde, txtCoNam)

        TabControl1.SelectedIndex = 0
        TabControl1.TabPages(0).Enabled = True
        TabControl1.TabPages(1).Enabled = False
        TabControl1.TabPages(2).Enabled = False
        TabControl1.TabPages(3).Enabled = False



        FillYearBox()
        'FillWeekBox()
        FillWeekBox2(cbo_year.Text)
        UpdateWeekDate()



        Call AddSearchBtnHandler()
        AddHandler dg_Detail.CellClick, AddressOf dgValid_CellClick
        AddHandler dg_Header.CellClick, AddressOf dgValid_CellClick

        mmdAdd.Enabled = False
        mmdSave.Enabled = False
        mmdDelete.Enabled = False
        mmdCopy.Enabled = False
        mmdFind.Enabled = False
        mmdInsRow.Enabled = False
        mmdDelRow.Enabled = False

        mmdPrint.Enabled = False
        mmdAttach.Enabled = False
        mmdFunction.Enabled = False
        mmdLink.Enabled = False



        If ma Is Nothing Then
            'Not from QCM00002
        Else
            'From QCM0002
            QCM00002_INIT()
        End If



    End Sub

#Region "QCM00002 related"


    Private Sub QCM00002_INIT()

        Me.Name = "QCM00001 - Insert Item Detail to QCM00002"

        Dim Hdrtbl As DataTable = ma.rs_QCM00002Hdr.Tables("RESULT")
        txt_S_PriCustAll.Text = Hdrtbl.Rows(0).Item("qch_prmcus")
        txt_S_SecCustAll.Text = Hdrtbl.Rows(0).Item("qch_seccus")
        txt_S_PV.Text = Hdrtbl.Rows(0).Item("qch_venno")
        txt_S_CV.Text = Hdrtbl.Rows(0).Item("qch_venno")
        txt_S_FA.Text = Hdrtbl.Rows(0).Item("qch_venno")

        For i As Integer = 0 To cboCocde.Items.Count - 1
            If String.Compare(cboCocde.Items(i), Hdrtbl.Rows(0).Item("qch_cocde")) = 0 Then
                cboCocde.SelectedIndex = i
            End If
        Next



        cboCocde.Enabled = False
        txt_S_PriCustAll.Enabled = False
        txt_S_SecCustAll.Enabled = False
        txt_S_PV.Enabled = False
        txt_S_CV.Enabled = False
        txt_S_FA.Enabled = False
        cmd_S_PriCustAll.Enabled = False
        cmd_S_SecCustAll.Enabled = False
        cmd_S_PV.Enabled = False
        cmd_S_CV.Enabled = False
        cmd_S_FA.Enabled = False



        cbo_year.Enabled = False
        cbo_week.Enabled = False
        cbo_year.Items(0) = Hdrtbl.Rows(0).Item("qch_inspyear")
        cbo_week.Items.Clear()
        cbo_week.Items.Add(gen_WeekString(Hdrtbl.Rows(0).Item("qch_inspyear"), Hdrtbl.Rows(0).Item("qch_inspweek")))
        cbo_week.SelectedIndex = 0

        'Apply Groupbox handle
        For Each ctrl As Control In GroupBox2.Controls
            If ctrl.GetType() Is GetType(RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If String.Compare(Convert_Insptype(rb.Text), Hdrtbl.Rows(0).Item("qch_insptyp")) = 0 Then
                    rb.Enabled = True
                    rb.Checked = True
                Else
                    rb.Enabled = False
                    rb.Checked = False
                End If
            End If
        Next

        'Apply CY Date and SI Date
        txt_SZdate.Text = If(Hdrtbl.Rows(0).Item("qch_sidate").ToString() = "01/01/1900", "", Hdrtbl.Rows(0).Item("qch_sidate").ToString())
        txt_CYdate.Text = If(Hdrtbl.Rows(0).Item("qch_cydate").ToString() = "01/01/1900", "", Hdrtbl.Rows(0).Item("qch_cydate").ToString())
        txt_CustInspDate.Text = If(Hdrtbl.Rows(0).Item("qch_cispdate").ToString() = "01/01/1900", "", Hdrtbl.Rows(0).Item("qch_cispdate").ToString())
        txt_SZdate.Enabled = False
        txt_CYdate.Enabled = False
        txt_CustInspDate.Enabled = False



        'Differnt handle: PO insertion and  IM insertion
        If String.Compare(str_typ, "PO") = 0 Then
            'Do nothing

        ElseIf String.Compare(str_typ, "ITM") = 0 Then
            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = False
            TabControl1.TabPages(2).Enabled = False
            TabControl1.TabPages(3).Enabled = True

            GroupBox1.Enabled = False

            mmdSave.Enabled = True
            cmdSelectAll.Enabled = False
            cmdApply.Enabled = False

            TabControl1.SelectedIndex = 3

            'Get Empty table tbl_Detail
            gspStr = "sp_select_QCM00001_empty"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_select_QCM00001_empty:" & rtnStr)
                Exit Sub
            End If

            tbl_Detail = rs.Tables("RESULT")

            Exit Sub
        End If

        


    End Sub

    Private Function QCM00002_SAVE() As Boolean
        QCM00002_SAVE = False

        If String.Compare(str_typ, "ITM") = 0 Then

            '20151023 - Remove Checking 
            'If Not check_ApplyParameters() Then
            '    Exit Function
            'End If

            'Additional Check
            If txt_ItmNo.Text = "" Then
                MsgBox("Item No cannot be empty!")
                Exit Function
            End If



            Dim new_row As DataRow = tbl_Detail.NewRow
            Dim row_mapping As New Hashtable()


            Dim qcd_mon As String = If(chk_day1.Checked, "Y", "")
            Dim qcd_tue As String = If(chk_day2.Checked, "Y", "")
            Dim qcd_wed As String = If(chk_day3.Checked, "Y", "")
            Dim qcd_thur As String = If(chk_day4.Checked, "Y", "")
            Dim qcd_fri As String = If(chk_day5.Checked, "Y", "")
            Dim qcd_sat As String = If(chk_day6.Checked, "Y", "")
            Dim qcd_sun As String = If(chk_day7.Checked, "Y", "")

            Dim qcd_samhdl As String = If(opt_samphandle1.Checked, opt_samphandle1.Text.ToString(), opt_samphandle2.Text.ToString())
            'Dim qcd_sidate As String = If(String.Compare(txt_SZdate.Text, "  /  /") = 0, "", txt_SZdate.Text)
            'Dim qcd_cydate As String = If(String.Compare(txt_CYdate.Text, "  /  /") = 0, "", txt_CYdate.Text)
            Dim qcd_rmk As String = txtRmk.Text


            'Without PO Part
            Dim qcd_xitmno As String = txt_ItmNo.Text
            Dim qcd_xitmdsc As String = txt_ItmDesc.Text
            Dim qcd_xcolor As String = txt_Color.Text
            Dim qcd_xpack As String = txt_PackInstruction.Text
            Dim qcd_mtrdcm As String = If(Trim(txtMtrdcm.Text) = "", "0", txtMtrdcm.Text)
            Dim qcd_mtrwcm As String = If(Trim(txtMtrwcm.Text) = "", "0", txtMtrwcm.Text)
            Dim qcd_mtrhcm As String = If(Trim(txtMtrhcm.Text) = "", "0", txtMtrhcm.Text)
            Dim qcd_inrdcm As String = If(Trim(txtInrdcm.Text) = "", "0", txtInrdcm.Text)
            Dim qcd_inrwcm As String = If(Trim(txtInrwcm.Text) = "", "0", txtInrwcm.Text)
            Dim qcd_inrhcm As String = If(Trim(txtInrhcm.Text) = "", "0", txtInrhcm.Text)
            Dim qcd_grswgt As String = If(Trim(txt_GrossW.Text) = "", "0", txt_GrossW.Text)
            Dim qcd_netwgt As String = If(Trim(txt_NetW.Text) = "", "0", txt_NetW.Text)
            Dim qcd_ordqty As String = If(Trim(txt_Ordqty.Text) = "", "0", txt_Ordqty.Text)



            row_mapping.Add("qcd_mon", qcd_mon)
            row_mapping.Add("qcd_tue", qcd_tue)
            row_mapping.Add("qcd_wed", qcd_wed)
            row_mapping.Add("qcd_thur", qcd_thur)
            row_mapping.Add("qcd_fri", qcd_fri)
            row_mapping.Add("qcd_sat", qcd_sat)
            row_mapping.Add("qcd_sun", qcd_sun)
            row_mapping.Add("qcd_samhdl", qcd_samhdl)
            'row_mapping.Add("qcd_sidate", qcd_sidate)
            'row_mapping.Add("qcd_cydate", qcd_cydate)
            row_mapping.Add("qcd_rmk", qcd_rmk)

            'Without PO Part
            row_mapping.Add("qcd_xitmno", qcd_xitmno)
            row_mapping.Add("qcd_xitmdsc", qcd_xitmdsc)
            row_mapping.Add("qcd_xcolor", qcd_xcolor)
            row_mapping.Add("qcd_xpack", qcd_xpack)
            row_mapping.Add("qcd_xmtrdcm", qcd_mtrdcm)
            row_mapping.Add("qcd_xmtrwcm", qcd_mtrwcm)
            row_mapping.Add("qcd_xmtrhcm", qcd_mtrhcm)
            row_mapping.Add("qcd_xinrdcm", qcd_inrdcm)
            row_mapping.Add("qcd_xinrwcm", qcd_inrwcm)
            row_mapping.Add("qcd_xinrhcm", qcd_inrhcm)
            row_mapping.Add("qcd_xgrswgt", qcd_grswgt)
            row_mapping.Add("qcd_xnetwgt", qcd_netwgt)
            row_mapping.Add("qcd_ordqty", qcd_ordqty)


            ma.InsertIMRowsFrom_QCM00001(row_mapping)
        ElseIf String.Compare(str_typ, "PO") = 0 Then

            If Not check_QCM00002Constraint() Then
                Exit Function
            End If

            Dim upd_rows As DataRow() = tbl_Detail.Select("ACT='Y'")
            ma.InsertRowsFrom_QCM00001(upd_rows)



        End If




        QCM00002_SAVE = True
    End Function

    Private Function check_QCM00002Constraint()
        check_QCM00002Constraint = False
        Dim Hdrtbl As DataTable = ma.rs_QCM00002Hdr.Tables("RESULT")
        Dim Dtltbl As DataTable = ma.rs_QCM00002.Tables("RESULT")

        Dim upd_rows As DataRow() = tbl_Detail.Select("ACT='Y'")

        If upd_rows.Length = 0 Then
            MsgBox("No Rows need to update!")
            Exit Function
        End If

        'If upd_rows.Length > 1 Then
        '    MsgBox("Can Only insert one row")
        '    Exit Function
        'End If

        'Dim upd_tbl As DataTable = tbl_Detail.Clone()
        'For i As Integer = 0 To upd_rows.Length - 1
        '    upd_tbl.ImportRow(upd_rows(i))
        'Next

        For i As Integer = 0 To upd_rows.Length - 1
            If String.Compare(upd_rows(i).Item("GenBy Vendor"), Hdrtbl.Rows(0).Item("qch_venno")) <> 0 Then
                MsgBox("GenBy Vendor not equivalent to QC Request Vendor")
                Exit Function
            End If

            If upd_rows(i).Item("CY Date") <> Trim(Hdrtbl.Rows(0).Item("qch_cydate").ToString) Then
                MsgBox("CY Date not equivalent to QC CY Date")
                Exit Function
            End If

            If upd_rows(i).Item("SI Date") <> Trim(Hdrtbl.Rows(0).Item("qch_sidate").ToString) Then
                MsgBox("SI Date not equivalent to QC SI Date")
                Exit Function
            End If


            For j As Integer = 0 To Dtltbl.Rows.Count - 1
                'If String.Compare(upd_rows(i).Item("PO No"), Dtltbl.Rows(j).Item("qcd_purord")) = 0 And String.Compare(upd_rows(i).Item("PO_Seq"), Dtltbl.Rows(j).Item("qcd_purseq")) = 0 Then
                If upd_rows(i).Item("PO No") = Dtltbl.Rows(j).Item("qcd_purord") And upd_rows(i).Item("PO_Seq") = Dtltbl.Rows(j).Item("qcd_purseq") Then
                    MsgBox("[PO No, PO Seq] exists already")
                    Exit Function
                End If
            Next

        Next

        check_QCM00002Constraint = True
    End Function

#End Region



#Region "Search Tab Related"
    'Search Tab Related Start
    Private Sub cboCocde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCocde.KeyUp
        auto_search_combo(cboCocde)
    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text = "UC-G" Then
            txtCoNam.Text = "UNITED CHINESE GROUP"
        Else
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        End If

    End Sub

    Private Sub AddSearchBtnHandler()
        textboxlist.Add(txt_S_PriCustAll, "cmd_S_PriCustAll")
        textboxlist.Add(txt_S_SecCustAll, "cmd_S_SecCustAll")
        textboxlist.Add(txt_S_PV, "cmd_S_PV")
        textboxlist.Add(txt_S_CV, "cmd_S_CV")
        textboxlist.Add(txt_S_FA, "cmd_S_FA")
        textboxlist.Add(txt_S_SCNo, "cmd_S_SCNo")
        textboxlist.Add(txt_S_PONo, "cmd_S_PONo")
        textboxlist.Add(txt_S_CustPONo, "cmd_S_CustPONo")
        textboxlist.Add(txt_S_ItmNo, "cmd_S_ItmNo")

        AddHandler cmd_S_PriCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SecCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PV.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_CV.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_FA.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SCNo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PONo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_CustPONo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_ItmNo.Click, AddressOf cmd_S_Click


    End Sub


    Private Sub cmd_S_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim trigger_btn As Button = CType(sender, Button)
        Dim btn_name As String = trigger_btn.Name
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = textboxlist(btn_name).Name
        frmComSearch.callFmString = textboxlist(btn_name).Text
        frmComSearch.show_frmS(trigger_btn)
    End Sub

    Private Function CheckSearchCriteria() As Boolean
        CheckSearchCriteria = True
        For i As Integer = 1 To textboxlist.Count
            If (textboxlist(i).Text.Length > 1000) Then
                Dim tmp_labelname As String = "SLabel_" + i.ToString

                MsgBox(" exceeds 1000 characters")
                Return False
            End If
        Next


        If txtSCShipDateFm.Text <> "  /  /" Then
            If Not IsDate(txtSCShipDateFm.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date From")
                txtSCShipDateFm.Focus()
                Return True
            End If
        Else

        End If

        If txtSCShipDateTo.Text <> "  /  /" Then
            If Not IsDate(txtSCShipDateTo.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date To")
                txtSCShipDateTo.Focus()
                Return True
            End If
        End If

        SCShipDateFm = If(txtSCShipDateFm.Text = "  /  /", "01/01/1900", txtSCShipDateFm.Text)
        SCShipDateTo = If(txtSCShipDateTo.Text = "  /  /", "01/01/2100", txtSCShipDateTo.Text)





        If txtPOShipDateFm.Text <> "  /  /" Then
            If Not IsDate(txtPOShipDateFm.Text) Then
                MsgBox("Invalid Date Format: PO Ship Start Date From")
                txtPOShipDateFm.Focus()
                Return True
            End If
        Else

        End If

        If txtPOShipDateTo.Text <> "  /  /" Then
            If Not IsDate(txtPOShipDateTo.Text) Then
                MsgBox("Invalid Date Format: PO Ship Start Date To")
                txtPOShipDateTo.Focus()
                Return True
            End If
        End If

        POShipDateFm = If(txtPOShipDateFm.Text = "  /  /", "01/01/1900", txtPOShipDateFm.Text)
        POShipDateTo = If(txtPOShipDateTo.Text = "  /  /", "01/01/2100", txtPOShipDateTo.Text)



    End Function

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        ToStage("LOAD")

        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)

        If Not CheckSearchCriteria() Then
            MsgBox("Search Fail!")
            Exit Sub
        End If

        Dim PriCustList As String = txt_S_PriCustAll.Text.Replace("'", "''")
        Dim SecCustList As String = txt_S_SecCustAll.Text.Replace("'", "''")
        Dim PVList As String = txt_S_PV.Text.Replace("'", "''")
        Dim CVList As String = txt_S_CV.Text.Replace("'", "''")
        Dim FAList As String = txt_S_FA.Text.Replace("'", "''")
        Dim SCNoList As String = txt_S_SCNo.Text.Replace("'", "''")
        Dim PONoList As String = txt_S_PONo.Text.Replace("'", "''")
        Dim CustPOList As String = txt_S_CustPONo.Text.Replace("'", "''")
        Dim ItemList As String = txt_S_ItmNo.Text.Replace("'", "''")

        Dim VENNo As String = ""
        'This should be empty, only used when load from QCM000002
        If Not ma Is Nothing Then
            PVList = ""
            CVList = ""
            FAList = ""
            VENNo = ma.rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno")
        End If


        gspStr = "sp_select_QCM00001 '" & gsCompany & "','" & _
                    PriCustList & "','" & _
                    SecCustList & "','" & _
                    PVList & "','" & _
                    CVList & "','" & _
                    FAList & "','" & _
                    SCNoList & "','" & _
                    PONoList & "','" & _
                    CustPOList & "','" & _
                    ItemList & "','" & _
                    POShipDateFm & "','" & _
                    POShipDateTo & "','" & _
                    SCShipDateFm & "','" & _
                    SCShipdateto & "','" & _
                    VENNo & "','" & _
                    gsUsrID & "'"


        Me.Cursor = Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_QCM00001, rtnStr)

        Me.Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QCM00001:" & rtnStr)
            Exit Sub
        End If

        If rs_QCM00001.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Records Found")
            Exit Sub
        End If

        'Show result 
        TabControl1.SelectedIndex = 1
        TabControl1.TabPages(0).Enabled = False
        TabControl1.TabPages(1).Enabled = True
        TabControl1.TabPages(2).Enabled = True

        SetupStyle_dg()
        mmdSave.Enabled = True

        'tbl_QCM00001_header = rs_QCM00001.Tables("RESULT").DefaultView.ToTable(True, "Order Qty")
        'dg_Header.DataSource = tbl_QCM00001_header.DefaultView()


    End Sub
    'Search Tab Related End
#End Region

    Private Sub SetupStyle_dg()
        dg_DetailView = New DataView(rs_QCM00001.Tables("RESULT"))
        tbl_Detail = dg_DetailView.ToTable(False, view_detail_arr)

        dg_HeaderView = New DataView(rs_QCM00001.Tables("RESULT"))
        tbl_Header = dg_HeaderView.ToTable(True, view_header_arr)


        'dg_HeaderView.RowFilter = "PO_Seq > 1"

        dg_Detail.DataSource = tbl_Detail.DefaultView

        dg_Header.DataSource = tbl_Header.DefaultView



        For i As Integer = 0 To tbl_Detail.Columns.Count - 1
            tbl_Detail.Columns(i).ReadOnly = False
        Next

        For i As Integer = 0 To tbl_Header.Columns.Count - 1
            tbl_Header.Columns(i).ReadOnly = False
        Next



        With dg_Detail
            .Columns("ACT").Width = 40
            .Columns("PO No").Width = 80
            '.Columns("PO_Seq").Width = 40
            .Columns("PO_Seq").Visible = False
            .Columns("Year").Width = 40
            '.Columns("Week").Width = 40
            .Columns("Week").Visible = False
            .Columns("Week_r").Width = 100
            .Columns("Week_r").HeaderText = "Week"
            .Columns("Mon").Width = 30
            .Columns("Tue").Width = 30
            .Columns("Wed").Width = 30
            .Columns("Thur").Width = 30
            .Columns("Fri").Width = 30
            .Columns("Sat").Width = 30
            .Columns("Sun").Width = 30
            .Columns("Insp. Typ").Width = 60
            .Columns("Sample").Width = 60
            .Columns("SI Date").Width = 80
            .Columns("CY Date").Width = 80
            .Columns("GenBy").Width = 40
            .Columns("GenBy Vendor").Width = 40

            .Columns("CV_r").Visible = False
            .Columns("PV_r").Visible = False
            .Columns("FA_r").Visible = False
            .Columns("CV").Width = 40
            .Columns("PV").Width = 40
            .Columns("FA").Width = 40
            .Columns("Pri. Cust").Width = 60
            .Columns("Sec. Cust").Width = 60
            .Columns("SC No").Width = 90
            .Columns("Cust. PO").Width = 90
            .Columns("Item Number").Width = 110
            .Columns("Cust. Item No.").Width = 80
            .Columns("Vendor Item No.").Width = 80
            .Columns("Color").Width = 60
            .Columns("Packing & Terms").Width = 170
            .Columns("Order Qty").Width = 60
            .Columns("SC Detail Ship Date").Width = 120
            .Columns("PO Detail Ship Date").Width = 120
            .Columns("Remark").Width = 60


        End With

        With dg_Header
            .Columns("ACT").Width = 40
            .Columns("PO No").Width = 80
            .Columns("Year").Width = 40
            '.Columns("Week").Width = 40
            .Columns("Week").Visible = False
            .Columns("Week_r").Width = 100
            .Columns("Week_r").HeaderText = "Week"
            .Columns("Mon").Width = 30
            .Columns("Tue").Width = 30
            .Columns("Wed").Width = 30
            .Columns("Thur").Width = 30
            .Columns("Fri").Width = 30
            .Columns("Sat").Width = 30
            .Columns("Sun").Width = 30
            .Columns("Insp. Typ").Width = 60
            .Columns("Sample").Width = 60
            .Columns("SI Date").Width = 80
            .Columns("CY Date").Width = 80
            .Columns("GenBy").Width = 40

            .Columns("CV_r").Visible = False
            .Columns("PV_r").Visible = False
            .Columns("FA_r").Visible = False
            .Columns("CV").Width = 40
            .Columns("PV").Width = 40
            .Columns("FA").Width = 40

            .Columns("Pri. Cust").Visible = False
            .Columns("Sec. Cust").Visible = False
            .Columns("pricust_r").Width = 60
            .Columns("pricust_r").HeaderText = "Pri. Cust"
            .Columns("seccust_r").Width = 60
            .Columns("seccust_r").HeaderText = "Sec. Cust"

            .Columns("SC No").Width = 90
            .Columns("Cust. PO").Width = 90
            .Columns("SC Header Ship Date").Width = 120
            .Columns("PO Header Ship Date").Width = 120
            .Columns("Remark").Width = 60


        End With

        'For i As Integer = 0 To dg_Header.Columns.Count - 1
        '    dg_Header.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        'Next

        'For i As Integer = 0 To dg_Detail.Columns.Count - 1
        '    dg_Detail.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        'Next



    End Sub

#Region "Display Column Config"
    Dim view_detail_arr As String() = { _
        "ACT", _
        "PO No", _
        "PO_Seq", _
        "Cust. PO", _
        "Year", _
        "Week_r", _
        "Mon", _
        "Tue", _
        "Wed", _
        "Thur", _
        "Fri", _
        "Sat", _
        "Sun", _
        "Insp. Typ", _
        "Sample", _
        "SI Date", _
        "CY Date", _
        "Customer Inspection Date", _
        "GenBy", _
        "GenBy Vendor", _
 _
        "CV_r", _
        "PV_r", _
        "FA_r", _
        "CV", _
        "PV", _
        "FA", _
        "pricust_r", _
        "seccust_r", _
        "Pri. Cust", _
        "Sec. Cust", _
        "SC No", _
        "Item Number", _
        "Cust. Item No.", _
        "Vendor Item No.", _
        "Color", _
        "Packing & Terms", _
        "Order Qty", _
        "SC Detail Ship Date", _
        "PO Detail Ship Date", _
 _
        "Remark", _
        "Week" _
    }

    Dim view_header_arr As String() = { _
        "ACT", _
        "PO No", _
        "Cust. PO", _
        "Year", _
        "Week_r", _
        "Mon", _
        "Tue", _
        "Wed", _
        "Thur", _
        "Fri", _
        "Sat", _
        "Sun", _
        "Insp. Typ", _
        "Sample", _
        "SI Date", _
        "CY Date", _
        "Customer Inspection Date", _
        "GenBy", _
 _
        "CV_r", _
        "PV_r", _
        "FA_r", _
        "CV", _
        "PV", _
        "FA", _
        "pricust_r", _
        "seccust_r", _
        "Pri. Cust", _
        "Sec. Cust", _
        "SC No", _
        "SC Header Ship Date", _
        "PO Header Ship Date", _
 _
        "Remark", _
        "Week" _
    }
#End Region


#Region "Basic Form Control"
    'Form QCM00001 Related Start
    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        Frm_Clear()
    End Sub


    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        Me.Close()
    End Sub

    Private Sub Frm_Clear()
        ToStage("INIT")
        TabControl1.SelectedIndex = 0
        TabControl1.TabPages(0).Enabled = True
        TabControl1.TabPages(1).Enabled = False
        TabControl1.TabPages(2).Enabled = False


        txtRmk.Text = ""
        dg_Detail.DataSource = ""
        dg_Header.DataSource = ""
    End Sub

    'Form QCM00001 Related End
#End Region

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            GroupBox1.Parent = TabPage2
        ElseIf TabControl1.SelectedIndex = 2 Then
            GroupBox1.Parent = TabPage3
        ElseIf TabControl1.SelectedIndex = 3 Then
            GroupBox1.Parent = TabPage4
        End If
    End Sub


    Private Sub cbo_year_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_year.SelectedIndexChanged
        FillWeekBox2(cbo_year.SelectedItem)
    End Sub

    Private Sub FillYearBox()
        today = Date.Today
        Dim cur_year As Integer = today.Year
        cbo_year.Items.Add(cur_year)
        'cbo_year.Items.Add(cur_year + 1)
        cbo_year.SelectedIndex = 0

    End Sub

#Region "Old FillWeekBox"
    'Private Sub FillWeekBox()
    '    Dim flg_from_lastyear As Boolean = False
    '    Dim flg_overlap_nextyear As Boolean = False
    '    Dim cur_year As Integer = today.Year
    '    Dim prev_year As Integer = cur_year - 1
    '    Dim next_year As Integer = cur_year + 1


    '    Dim cur_week As Integer = GetCurrentWeek()

    '    If cur_week = -1 Then
    '        flg_from_lastyear = True
    '    End If

    '    If cur_week <= LastWeekOfYear(cur_year) And cur_week > LastWeekOfYear(cur_year) - conf_weekshown + 1 Then
    '        flg_overlap_nextyear = True
    '    End If

    '    If flg_from_lastyear Then
    '        Dim _week As Integer = LastWeekOfYear(prev_year)

    '        cbo_week.Items.Add(gen_WeekString(prev_year, LastWeekOfYear(prev_year)))


    '        For i As Integer = 0 To conf_weekshown - 2
    '            cbo_week.Items.Add(gen_WeekString(cur_year, i + 1))
    '        Next
    '    ElseIf flg_overlap_nextyear Then
    '        Dim week_cnt As Integer = LastWeekOfYear(cur_year) - cur_week + 1

    '        For i As Integer = 1 To week_cnt
    '            cbo_week.Items.Add(gen_WeekString(cur_year, LastWeekOfYear(cur_year) - week_cnt + i))

    '        Next

    '        For i As Integer = 1 To conf_weekshown - week_cnt
    '            cbo_week.Items.Add(gen_WeekString(next_year, i))

    '        Next
    '    Else
    '        For i As Integer = 0 To conf_weekshown - 1
    '            cbo_week.Items.Add(gen_WeekString(cur_year, cur_week + i))

    '        Next
    '    End If

    '    cbo_week.SelectedIndex = 0


    'End Sub
#End Region

    Private Sub FillWeekBox2(ByVal _year As Integer)
        today = Date.Today
        Dim cur_year As Integer = today.Year
        Dim flg_from_lastyear As Boolean = False
        Dim flg_overlap_nextyear As Boolean = False
        Dim flg_count_as_nextyear As Boolean = False
        cbo_week.Items.Clear()



        Dim cur_week As Integer = GetCurrentWeek()

        If cur_week = 0 Then
            flg_from_lastyear = True
        End If

        If Not (today.AddDays(3).Year = today.Year) And (today.DayOfWeek = DayOfWeek.Monday Or today.DayOfWeek = DayOfWeek.Tuesday Or today.DayOfWeek = DayOfWeek.Wednesday) Then
            flg_count_as_nextyear = True
        End If

        If cur_week <= LastWeekOfYear(cur_year) And cur_week >= LastWeekOfYear(cur_year) - conf_weekshown + 1 And Not (flg_count_as_nextyear) Then
            flg_overlap_nextyear = True

            cbo_year.Enabled = True


        End If


        If (_year > cur_year) And flg_overlap_nextyear Then
            Dim diff As Integer = DateDiff(DateInterval.Day, FirstDateOfWeekISO8601(_year, 1), today.Date)
            If Math.Abs(diff) <= 14 And Math.Abs(diff) > 7 Then

                cbo_week.Items.Add(gen_WeekString(_year, 1))
                cbo_week.SelectedIndex = 0
            ElseIf Math.Abs(diff) <= 7 And Math.Abs(diff) > 0 Then
                For i As Integer = 0 To 1
                    cbo_week.Items.Add(gen_WeekString(_year, i + 1))
                    cbo_week.SelectedIndex = 0
                Next
            End If
            Exit Sub
        End If


        If flg_from_lastyear Then
            Dim _week As Integer = LastWeekOfYear(cur_year - 1)
            'cbo_week.Items.Add(gen_WeekString(_year, LastWeekOfYear(_year - 1)))


            If cbo_year.Items.Contains(cur_year - 1) = False Then ' add the previous year option
                cbo_year.Items.Add(cur_year - 1)

            End If

            'sort the year
            If cbo_year.Items.Count() = 2 And cbo_year.Items.Item(0) > cbo_year.Items.Item(1) Then
                Dim temp As Integer = cbo_year.Items.Item(0)
                cbo_year.Items.Item(0) = cbo_year.Items.Item(1)
                cbo_year.Items.Item(1) = temp
            End If
            cbo_year.Enabled = True
            If cbo_year.SelectedItem = cur_year Then
                For i As Integer = 0 To conf_weekshown - 2
                    cbo_week.Items.Add(gen_WeekString(cur_year, i + 1))
                Next
            Else
                cbo_week.Items.Add(gen_WeekString(cur_year - 1, LastWeekOfYear(cur_year - 1)))
            End If
        ElseIf flg_overlap_nextyear Then
            Dim week_cnt As Integer = LastWeekOfYear(_year) - cur_week + 1
            If cbo_year.Items.Contains(cur_year + 1) = False Then ' add the next year option
                cbo_year.Items.Add(cur_year + 1)
            End If

            For i As Integer = 1 To week_cnt
                cbo_week.Items.Add(gen_WeekString(_year, LastWeekOfYear(_year) - week_cnt + i))
            Next

        ElseIf flg_count_as_nextyear Then

            For i As Integer = 0 To conf_weekshown - 1
                cbo_week.Items.Add(gen_WeekString(cur_year + 1, i + 1))
            Next
            If cbo_year.SelectedItem = cur_year Then

                cbo_year.Items.Clear()
                cbo_year.Items.Add(cur_year + 1)
            End If
            cbo_year.SelectedIndex = 0


        Else
            For i As Integer = 0 To conf_weekshown - 1
                cbo_week.Items.Add(gen_WeekString(_year, cur_week + i))
            Next
        End If
        cbo_week.SelectedIndex = 0


    End Sub

    Private Sub UpdateWeekDate()
        Dim curweek As String = Split(Split(cbo_week.Text, " - ")(0), " ")(1)

        Dim firstdate As Date = FirstDateOfWeekISO8601(cbo_year.Text, curweek)

        lbl_mon.Text = firstdate.ToString("MM/dd")
        lbl_tue.Text = firstdate.AddDays(1).ToString("MM/dd")
        lbl_wed.Text = firstdate.AddDays(2).ToString("MM/dd")
        lbl_thur.Text = firstdate.AddDays(3).ToString("MM/dd")
        lbl_fri.Text = firstdate.AddDays(4).ToString("MM/dd")
        lbl_sat.Text = firstdate.AddDays(5).ToString("MM/dd")
        lbl_sun.Text = firstdate.AddDays(6).ToString("MM/dd")

    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Dim row_cnt As Integer

        'Check Input parameter
        If Not check_ApplyParameters() Then
            Exit Sub
        End If


        If TabControl1.SelectedIndex = 1 Then
            'Header Grid
            row_cnt = dg_Header.SelectedRows.Count
            If row_cnt = 0 Then
                MsgBox("No rows are selected")
                Exit Sub
            Else
                For i As Integer = 0 To row_cnt - 1
                    Dim cur_row = dg_Header.SelectedRows(i)
                    update_GridHeaderRow(cur_row.Index)


                Next
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then
            'Detail Grid
            row_cnt = dg_Detail.SelectedRows.Count
            If row_cnt = 0 Then
                MsgBox("No rows are selected")
                Exit Sub
            Else
                For i As Integer = 0 To row_cnt - 1
                    Dim cur_row As DataGridViewRow = dg_Detail.SelectedRows(i)
                    update_GridDetailRow(cur_row.Index)
                Next
            End If
        End If
    End Sub

    Private Function check_ApplyParameters() As Boolean
        check_ApplyParameters = False

        Dim flg_haveReqDates As Boolean = False
        'Request dates
        For Each ctrl As Control In GroupBox5.Controls
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

        'Request Week
        If cbo_week.SelectedItem = "" Then
            MsgBox("No Valid request week!")
            Exit Function
        End If

        If txt_CYdate.Text <> "  /  /" Then
            If (Not IsDate(txt_CYdate.Text) Or txt_CYdate.Text.Length <> 10) Then
                MsgBox("Invalid CY Date!")
                Exit Function
            End If
        End If

        If txt_SZdate.Text <> "  /  /" Then
            If (Not IsDate(txt_SZdate.Text) Or txt_SZdate.Text.Length <> 10) Then
                MsgBox("Invalid SI Date!")
                Exit Function
            End If
        End If

        If txt_CustInspDate.Text <> "  /  /" Then
            If (Not IsDate(txt_CustInspDate.Text) Or txt_CustInspDate.Text.Length <> 10) Then
                MsgBox("Invalid Customer Inspection Date!")
                Exit Function
            End If
        End If


        'If opt_date.Checked Then
        '    If (Not IsDate(txt_InspectDate.Text) Or txt_InspectDate.Text.Length <> 10) Then
        '        MsgBox("Invalid Inspection Date!")
        '        check_ApplyParameters = False
        '    Else
        '        Dim dif As Integer = DateDiff(DateInterval.Day, DateTime.Parse(txt_InspectDate.Text), Today.Date)
        '        If dif > 30 Then
        '            MsgBox("Today - Req. Inspection Date excceds 30 days. Date Difference = " + dif.ToString)
        '            check_ApplyParameters = False
        '        End If
        '    End If
        'Else
        '    If Integer.Parse(Split(Split(cbo_weekfm.Text, " - ")(0), " ")(1).ToString()) > Integer.Parse(Split(Split(cbo_weekto.Text, " - ")(0), " ")(1).ToString()) Then
        '        'Week From > Week To Case
        '        MsgBox("Inspection Week From > Inspection Week To")
        '        check_ApplyParameters = False
        '    End If
        'End If

        check_ApplyParameters = True

    End Function



    Private Sub update_GridDetailRow(ByVal rowindex As Integer)
        Dim current_row As DataGridViewRow = dg_Detail.Rows(rowindex)

        GridRowUpdate(dg_Detail, rowindex)


    End Sub

    Private Sub update_GridHeaderRow(ByVal rowindex As Integer)
        GridRowUpdate(dg_Header, rowindex)

        Dim POno As String = dg_Header.Rows(rowindex).Cells("PO No").Value.ToString()
        Dim CV As String = dg_Header.Rows(rowindex).Cells("CV_r").Value.ToString()
        Dim PV As String = dg_Header.Rows(rowindex).Cells("PV_r").Value.ToString()
        Dim FA As String = dg_Header.Rows(rowindex).Cells("FA_r").Value.ToString()

        'Need to do
        'Select row by PO num, use the PO num to update GridDetail


        For i As Integer = 0 To dg_Detail.Rows.Count - 1
            If String.Compare(dg_Detail.Rows(i).Cells("PO No").Value, POno) = 0 And _
                String.Compare(dg_Detail.Rows(i).Cells("CV_r").Value, CV) = 0 And _
                String.Compare(dg_Detail.Rows(i).Cells("PV_r").Value, PV) = 0 And _
                String.Compare(dg_Detail.Rows(i).Cells("FA_r").Value, FA) = 0 Then
                ' If string.Compare(dg_Detail.Rows(i).Cells(
                GridRowUpdate(dg_Detail, i)
            End If
        Next


    End Sub


    'Update common column of dg_header and dg_detail, typically when apply is pressed
    Private Sub GridRowUpdate(ByVal dg As DataGridView, ByVal rowindex As Integer)
        Dim current_row As DataGridViewRow = dg.Rows(rowindex)


        'Common columns Start

        'Request Dates
        For Each ctrl As Control In GroupBox5.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                If chk.Checked Then
                    'Use chkbox Text as weekday for simplicity
                    dg.Rows(rowindex).Cells(chk.Text.ToString).Value = "Y"
                Else
                    dg.Rows(rowindex).Cells(chk.Text.ToString).Value = ""
                End If
            End If
        Next

        current_row.Cells("Year").Value = cbo_year.Text
        current_row.Cells("Week").Value = Split(Split(cbo_week.Text, " - ")(0), " ")(1)
        current_row.Cells("Week_r").Value = Split(Split(cbo_week.Text, " - ")(0), " ")(1) + " [" + Split(cbo_week.Text, " - ")(1) + "]"


        'current_row.Cells("CY Date").Value = If(String.Compare(current_row.Cells("CY Date").Value, "") = 0, "", txt_CYdate.Text)
        'current_row.Cells("SI Date").Value = If(String.Compare(current_row.Cells("SI Date").Value, "") = 0, "", txt_SZdate.Text)

        current_row.Cells("CY Date").Value = If(String.Compare(txt_CYdate.Text, "  /  /") = 0, "", txt_CYdate.Text)
        current_row.Cells("SI Date").Value = If(String.Compare(txt_SZdate.Text, "  /  /") = 0, "", txt_SZdate.Text)
        current_row.Cells("Customer Inspection Date").Value = If(String.Compare(txt_CustInspDate.Text, "  /  /") = 0, "", txt_CustInspDate.Text)


        'If opt_week.Checked = True Then

        '    current_row.Cells("Date").Value = FirstDateOfWeekISO8601(Today.Year, Split(Split(cbo_weekfm.Text, " - ")(0), " ")(1))
        '    current_row.Cells("Week Fm").Value = Split(Split(cbo_weekfm.Text, " - ")(0), " ")(1)
        '    current_row.Cells("Week To").Value = Split(Split(cbo_weekto.Text, " - ")(0), " ")(1)
        'Else
        '    dg.Rows(rowindex).Cells("Date").Value = txt_InspectDate.Text
        '    Dim tmp_date As Date = CDate(txt_InspectDate.Text)
        '    dg.Rows(rowindex).Cells("Week Fm").Value = GetWeekByDate(tmp_date)
        '    dg.Rows(rowindex).Cells("Week To").Value = GetWeekByDate(tmp_date)
        'End If


        'If isOverlappedYear_Date(dg.Rows(rowindex).Cells("Date").Value, Today.Year) Then
        '    current_row.Cells("Year").Value = Today.Year - 1
        'Else
        '    current_row.Cells("Year").Value = Today.Year
        'End If

        'Inspection Type
        For Each ctrl As Control In GroupBox2.Controls
            If ctrl.GetType() Is GetType(RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If rb.Checked Then
                    dg.Rows(rowindex).Cells("Insp. Typ").Value = rb.Text.ToString()
                    Exit For
                End If
            End If
        Next


        'Sampling Handling
        dg.Rows(rowindex).Cells("Sample").Value = If(opt_samphandle1.Checked, opt_samphandle1.Text.ToString(), opt_samphandle2.Text.ToString())

        'Generated By
        For Each ctrl As Control In GroupBox4.Controls
            If ctrl.GetType() Is GetType(RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If rb.Checked Then
                    dg.Rows(rowindex).Cells("GenBy").Value = rb.Text.ToString()
                End If
            End If
        Next

        dg.Rows(rowindex).Cells("Remark").Value = txtRmk.Text
        'dg.Rows(rowindex).Cells("InspectMode").Value = If(opt_date.Checked, "Date", "Week")
        dg.Rows(rowindex).Cells("ACT").Value = "Y"

        'Common Columns End

        'dg_Detail Only
        If dg.Name = "dg_Detail" Then
            Dim ven As String = dg.Rows(rowindex).Cells(dg.Rows(rowindex).Cells("GenBy").Value + "_r").Value
            dg.Rows(rowindex).Cells("GenBy Vendor").Value = ven
            'dg.Rows(rowindex).Cells("GenBy Vendor").Value

        End If



    End Sub


    Private Sub dgValid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim dg As DataGridView = CType(sender, DataGridView)

        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
            Exit Sub
        End If
        Dim row As Integer = dg.CurrentCell.RowIndex
        Dim col As Integer = dg.CurrentCell.ColumnIndex


        If col = 0 Then
            UpdateUPDval(dg, row)
            '    ElseIf col = 4 Then
            '        createComboBoxCell(row, 4) 'Pack & Terms
            '    ElseIf col = 5 Then
            '        createComboBoxCell(row, 5) 'Color
        End If
    End Sub

    Private Sub UpdateUPDval(ByVal dg As DataGridView, ByVal row As Integer)

        'UPD col index = 0
        If dg.Rows(row).Cells("ACT").Value = "N" Then
            If dg.Rows(row).Cells("Insp. Typ").Value <> "" Then
                'If dg.Rows(row).Cells("Insp. Typ").Value <> "" And dg.Rows(row).Cells("Date").Value <> "" Then
                dg.Rows(row).Cells("ACT").Value = "Y"
            End If
        ElseIf dg.Rows(row).Cells(0).Value = "Y" Then
            dg.Rows(row).Cells("ACT").Value = "N"
        End If

        If String.Compare(dg.Name, "dg_Header") = 0 Then
            Dim POno As String = dg_Header.Rows(row).Cells("PO No").Value.ToString()

            For i As Integer = 0 To dg_Detail.Rows.Count - 1
                If String.Compare(dg_Detail.Rows(i).Cells("PO No").Value, POno) = 0 Then
                    'If dg_Detail.Rows(i).Cells("Insp. Typ").Value <> "" And dg_Detail.Rows(i).Cells("Date").Value <> "" Then
                    If dg_Detail.Rows(i).Cells("Insp. Typ").Value <> "" Then
                        dg_Detail.Rows(i).Cells("ACT").Value = dg.Rows(row).Cells("ACT").Value
                    End If
                End If
            Next
        End If
    End Sub



    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        dg_Detail.ClearSelection()
        dg_Header.ClearSelection()
        Msg = ""
        Dim flg_savesucess As Boolean = True

        dg_Header.EndEdit()
        dg_Detail.EndEdit()
        dg_Detail.Refresh()

        For i As Integer = 0 To dg_Detail.Rows.Count - 1
            For j As Integer = 0 To dg_Detail.Columns.Count - 1
                tbl_Detail.Rows(i).Item(j) = dg_Detail.Rows(i).Cells(j).Value
            Next
        Next


        dg_Detail.Refresh()
        tbl_Detail.AcceptChanges()

        'QCM00002 Case, will exit after passing data to QCM00002
        If Not ma Is Nothing Then
            If QCM00002_SAVE() Then

                Me.Close()
                'Exit the form
            Else

            End If
            Exit Sub
        End If



        Dim upd_rows As DataRow() = tbl_Detail.Select("ACT='Y'")
        Dim upd_tbl As DataTable = tbl_Detail.Clone()
        For i As Integer = 0 To upd_rows.Length - 1
            upd_tbl.ImportRow(upd_rows(i))
        Next




        Dim arr_key As String() = {"GenBy Vendor", "Pri. Cust", "Sec. Cust", "Year", "Week", "Insp. Typ", "CY Date", "SI Date", "Customer Inspection Date", "Sample"}
        Dim key_tbl As DataTable = upd_tbl.DefaultView.ToTable(True, arr_key)

        For i As Integer = 0 To key_tbl.Rows.Count - 1
            Dim row As DataRow = key_tbl.Rows(i)
            If Not QC_Save2(row, upd_tbl) Then
                flg_savesucess = False
            End If
            'MsgBox(row.Item(0) + "," + row.Item(1) + "," + row.Item(2) + "," + row.Item(3) + "," + row.Item(4) + "," + row.Item(5))
        Next

        'Dim tmp_tbl As DataTable = New DataTable()
        'Dim tmp_tbl2 As DataTable = tbl_Detail.Clone()
        'Dim arr_distinct As String() = {"GenBy Vendor"}
        'tmp_tbl = tbl_Detail.DefaultView.ToTable(True, arr_distinct)

        'For i As Integer = 0 To tmp_tbl.Rows.Count
        '    If tmp_tbl.Rows(i).Item("GenBy Vendor") <> "" Then
        '        Dim Rows_GenBy As DataRow() = tbl_Detail.Select("ACT='Y' AND `GenBy Vendor`='" & tmp_tbl.Rows(i).Item("GenBy Vendor") & "'")
        '        For j As Integer = 0 To Rows_GenBy.Length - 1
        '            tmp_tbl2.ImportRow(Rows_GenBy(j))
        '        Next
        '    End If
        'Next



        'Dim arr_GenBy As String() = {"PV", "CV", "FA"}
        'For i As Integer = 0 To arr_GenBy.Length - 1
        '    Dim Rows_GenBy As DataRow() = tbl_Detail.Select("ACT='Y' AND GenBy='" & arr_GenBy(i) & "'")


        '    If Rows_GenBy.Length <> 0 Then
        '        Dim tmp_tbl As DataTable = tbl_Detail.Clone
        '        For j As Integer = 0 To Rows_GenBy.Length - 1
        '            tmp_tbl.ImportRow(Rows_GenBy(j))
        '        Next

        '        Dim tmp_arr As String() = {arr_GenBy(i)}
        '        Dim tmp_tbl2 As DataTable = New DataView(tmp_tbl).ToTable(True, tmp_arr)
        '        'Dim tmp_venno As String = tmp_tbl2.Rows(
        '        For k As Integer = 0 To tmp_tbl2.Rows.Count() - 1
        '            If Not QC_Save(arr_GenBy(i), tmp_tbl2.Rows(k).Item(arr_GenBy(i))) Then
        '                Msg = Msg & "Save Fail!" & vbCrLf
        '                flg_savesucess = False
        '            End If

        '        Next

        '    End If
        'Next

        If flg_savesucess Then
            MsgBox(Msg & "All QC Request Save Success!")
        Else
            MsgBox(Msg & "Save Fail!")
        End If

        txtResult.AppendText(Environment.NewLine)

        Frm_Clear()

        Cursor = Cursors.Default

    End Sub


    'Select Rows fulfill Key to upd_rows()
    'Find distinct PO No in upd_rows()
    'Loop through PO No, Po Seq, 
    'Insert QCREQDTL, QCPORDTL, QCREQHDR
    Private Function QC_Save2(ByVal key_row As DataRow, ByVal tbl As DataTable) As Boolean
        QC_Save2 = False

        Dim tmp_str As String = "`GenBy Vendor` ='" & key_row(0) & "' And " & _
            "`Pri. Cust` ='" & key_row(1) & "' And " & _
            "`Sec. Cust` ='" & key_row(2) & "' And " & _
            "`Year` = '" & key_row(3) & "' And " & _
            "`Week` = '" & key_row(4) & "' And " & _
            "`Insp. Typ` ='" & key_row(5) & "' And " & _
            "`CY Date` ='" & key_row(6) & "' AND " & _
            "`SI Date` ='" & key_row(7) & "' AND " & _
            "`Customer Inspection Date` ='" & key_row(8) & "' AND " & _
            "`Sample` ='" & key_row(9) & "'"


        'Get QC No
        Cursor = Cursors.WaitCursor
        Dim rs_docno As DataSet
        gspStr = "sp_select_DOC_GEN '" & "','QC','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_docno, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_DOC_GEN:" & rtnStr)
            Exit Function
        End If

        Dim QCNo = rs_docno.Tables("RESULT").Rows(0).Item(0).ToString
        Dim QCSeq As Integer = 1

        Dim upd_rows() As DataRow = tbl.Select(tmp_str, "PO No, PO_Seq")
        Dim upd_tbl As DataTable = tbl_Detail.Clone()

        'If upd_rows.Length = 0 Then
        '    'Should not occur
        '    Dim msg As String = "[" + key_row.Item(0) + "," + key_row.Item(1) + "," + key_row.Item(2) + "," + key_row.Item(3) + "," + key_row.Item(4) + "," + key_row.Item(5) + "] have no update rows"
        '    txtResult.AppendText(msg)
        '    Exit Function
        'End If

        For i As Integer = 0 To upd_rows.Length - 1
            upd_tbl.ImportRow(upd_rows(i))
        Next

        'Find PO No key
        Dim PO_key As String() = {"PO No"}
        Dim POkey_tbl As DataTable = upd_tbl.DefaultView.ToTable(True, PO_key)

        Dim QCWeekDay As WeekDay = New WeekDay()

        For i As Integer = 0 To POkey_tbl.Rows.Count - 1
            Dim PO_updrows() As DataRow = upd_tbl.Select("`PO No` ='" & POkey_tbl.Rows(i).Item("PO No") & "'")

            Dim POWeekDay As WeekDay = New WeekDay()

            For j As Integer = 0 To PO_updrows.Length - 1
                Dim cur_row As DataRow = PO_updrows(j)

                POWeekDay.Mon = If(cur_row.Item("Mon") = "Y", True, POWeekDay.Mon)
                POWeekDay.Tue = If(cur_row.Item("Tue") = "Y", True, POWeekDay.Tue)
                POWeekDay.Wed = If(cur_row.Item("Wed") = "Y", True, POWeekDay.Wed)
                POWeekDay.Thur = If(cur_row.Item("Thur") = "Y", True, POWeekDay.Thur)
                POWeekDay.Fri = If(cur_row.Item("Fri") = "Y", True, POWeekDay.Fri)
                POWeekDay.Sat = If(cur_row.Item("Sat") = "Y", True, POWeekDay.Sat)
                POWeekDay.Sun = If(cur_row.Item("Sun") = "Y", True, POWeekDay.Sun)

                QCWeekDay.Mon = If(cur_row.Item("Mon") = "Y", True, QCWeekDay.Mon)
                QCWeekDay.Tue = If(cur_row.Item("Tue") = "Y", True, QCWeekDay.Tue)
                QCWeekDay.Wed = If(cur_row.Item("Wed") = "Y", True, QCWeekDay.Wed)
                QCWeekDay.Thur = If(cur_row.Item("Thur") = "Y", True, QCWeekDay.Thur)
                QCWeekDay.Fri = If(cur_row.Item("Fri") = "Y", True, QCWeekDay.Fri)
                QCWeekDay.Sat = If(cur_row.Item("Sat") = "Y", True, QCWeekDay.Sat)
                QCWeekDay.Sun = If(cur_row.Item("Sun") = "Y", True, QCWeekDay.Sun)

                'Insert QCREQDTL
                Dim qcd_dtlsts As String = "OPE"
                Dim qcd_qcposeq As Integer = i + 1
                Dim qcd_flgpolink As String = "Y"


                gspStr = "sp_insert_QCREQDTL_QCM00001 '" & gsCompany & "','" & _
                    QCNo & "','" & _
                    QCSeq & "','" & _
                    qcd_dtlsts & "','" & _
                    cur_row.Item("GenBy") & "','" & _
                    qcd_flgpolink & "','" & _
                    qcd_qcposeq & "','" & _
                    cur_row.Item("PO No") & "','" & _
                    cur_row.Item("PO_Seq") & "','" & _
 _
                    cur_row.Item("Mon") & "','" & _
                    cur_row.Item("Tue") & "','" & _
                    cur_row.Item("Wed") & "','" & _
                    cur_row.Item("Thur") & "','" & _
                    cur_row.Item("Fri") & "','" & _
                    cur_row.Item("Sat") & "','" & _
                    cur_row.Item("Sun") & "','" & _
                    cur_row.Item("Sample") & "','" & _
                    gsUsrID & "'"


                '                gspStr = "sp_insert_QCREQDTL '" & gsCompany & "','" & _
                '                    QCNo & "','" & _
                '                    QCSeq & "','" & _
                '                    qcd_dtlsts & "','" & _
                '                    cur_row.Item("GenBy") & "','" & _
                '                    qcd_flgpolink & "','" & _
                '                    qcd_qcposeq & "','" & _
                '                    cur_row.Item("PO No") & "','" & _
                '                    cur_row.Item("PO_Seq") & "','" & _
                '_
                '                    cur_row.Item("Mon") & "','" & _
                '                    cur_row.Item("Tue") & "','" & _
                '                    cur_row.Item("Wed") & "','" & _
                '                    cur_row.Item("Thur") & "','" & _
                '                    cur_row.Item("Fri") & "','" & _
                '                    cur_row.Item("Sat") & "','" & _
                '                    cur_row.Item("Sun") & "','" & _
                '                    cur_row.Item("Sample") & "','" & _
                '                    cur_row.Item("SI Date") & "','" & _
                '                    cur_row.Item("CY Date") & "','" & _
                '                    cur_row.Item("Remark") & "','" & _
                '                    qcd_xitmno & "','" & _
                '                    gsUsrID & "'"






                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Dim msg As String = "[" + key_row.Item(0) + "," + key_row.Item(1) + "," + key_row.Item(2) + "," + key_row.Item(3) + "," + key_row.Item(4) + "," + key_row.Item(5) + _
                        cur_row.Item("PO No") + cur_row.Item("PO_Seq").ToString + "] Save Fail"
                    txtResult.AppendText(msg)
                    MsgBox("Error on loading sp_insert_QCREQDTL_QCM00001:" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Function
                End If

                QCSeq = QCSeq + 1
            Next


            'Insert QCPORDTL
            Dim qpd_qcposeq As Integer = i + 1
            gspStr = "sp_insert_QCPORDTL '" & gsCompany & "','" & _
                QCNo & "','" & _
                qpd_qcposeq & "','" & _
                PO_updrows(0).Item("PO No") & "','" & _
                POWeekDay.to_YFormat(1) & "','" & _
                POWeekDay.to_YFormat(2) & "','" & _
                POWeekDay.to_YFormat(3) & "','" & _
                POWeekDay.to_YFormat(4) & "','" & _
                POWeekDay.to_YFormat(5) & "','" & _
                POWeekDay.to_YFormat(6) & "','" & _
                POWeekDay.to_YFormat(7) & "','" & _
                "" & "','" & _
                gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Dim msg As String = "[" + key_row.Item(0) + "," + key_row.Item(1) + "," + key_row.Item(2) + "," + key_row.Item(3) + "," + key_row.Item(4) + "," + key_row.Item(5) + _
                    PO_updrows(0).Item("PO No") + "] Save Fail"
                txtResult.AppendText(msg)
                MsgBox("Error on loading sp_insert_QCPORDTL:" & rtnStr)
                Cursor = Cursors.Default
                Exit Function
            End If
        Next


        'Insert QCVENINF
        'key_row(0) is vendor
        gspStr = "sp_insert_QCVENINF_QCM00001 '" & gsCompany & "','" & QCNo & "','" & _
            key_row(0) & "','" & _
            gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Dim msg As String = "[" + key_row.Item(0) + "," + key_row.Item(1) + "," + key_row.Item(2) + "," + key_row.Item(3) + "," + key_row.Item(4) + "," + key_row.Item(5) + _
                QCNo + "] Save Fail"
            txtResult.AppendText(msg)
            MsgBox("Error on loading sp_insert_QCVENINF_QCM00001:" & rtnStr)
            Cursor = Cursors.Default
            Exit Function
        End If






        Dim hdr_insptyp As String = Convert_Insptype(key_row(5))


        'Select Case key_row(5)
        '    Case "Pre-Pro"
        '        hdr_insptyp = "P"
        '    Case "PP-Meeting"
        '        hdr_insptyp = "M"
        '    Case "In-Line"
        '        hdr_insptyp = "D"
        '    Case "In-Line (Customer)"
        '        hdr_insptyp = "DC"
        '    Case "Final"
        '        hdr_insptyp = "F"
        '    Case "Final (Customer)"
        '        hdr_insptyp = "FC"
        '    Case Else
        '        hdr_insptyp = "E"
        'End Select


        'Insert QCREQHDR
        Dim qch_qcsts As String = "OPE"
        Dim qch_flgautogen As String = "Y"
        Dim qch_rmk As String = txtRmk.Text
        'Dim qch_samhdl As String =  
        gspStr = "sp_insert_QCREQHDR '" & gsCompany & "','" & _
            QCNo & "','" & _
            qch_qcsts & "','" & _
            qch_flgautogen & "','" & _
            key_row(0) & "','" & _
            key_row(1) & "','" & _
            key_row(2) & "','" & _
            key_row(3) & "','" & _
            key_row(4) & "','" & _
            hdr_insptyp & "','" & _
            QCWeekDay.to_YFormat(1) & "','" & _
            QCWeekDay.to_YFormat(2) & "','" & _
            QCWeekDay.to_YFormat(3) & "','" & _
            QCWeekDay.to_YFormat(4) & "','" & _
            QCWeekDay.to_YFormat(5) & "','" & _
            QCWeekDay.to_YFormat(6) & "','" & _
            QCWeekDay.to_YFormat(7) & "','" & _
            key_row(9) & "','" & _
            key_row(6) & "','" & _
            key_row(7) & "','" & _
            key_row(8) & "','" & _
            qch_rmk & "','" & _
            gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Dim msg As String = "[" + key_row.Item(0) + "," + key_row.Item(1) + "," + key_row.Item(2) + "," + key_row.Item(3) + "," + key_row.Item(4) + "," + _
                key_row.Item(5) + "," + key_row.Item(6) + "," + key_row.Item(7) + "," + key_row.Item(8) + "," + key_row.Item(9) + _
                QCNo(+"] Save Fail")
            txtResult.AppendText(msg)
            MsgBox("Error on loading sp_insert_QCREQHDR:" & rtnStr)
            Cursor = Cursors.Default
            Exit Function
        End If


        txtResult.AppendText(QCNo + " Save Success! Key=[" + _
                             key_row.Item(0) + "," + key_row.Item(1) + "," + key_row.Item(2) + "," + key_row.Item(3) + "," + key_row.Item(4) + _
                             "," + key_row.Item(5) + "," + key_row.Item(6) + "," + key_row.Item(7) + "," + key_row.Item(8) + "," + key_row.Item(9) + "]" + _
                            Environment.NewLine)


        QC_Save2 = True
    End Function

#Region "Old Save Funcition"

    '    Private Function QC_Save(ByVal GenBy As String, ByVal Venno As String) As Boolean
    '        QC_Save = False

    '        Dim tmp_str As String = "ACT='Y' And GenBy='" & GenBy & "' And " & GenBy & "='" & Venno & "'"


    '        Dim QCNo As String
    '        Dim UpdRow() As DataRow = tbl_Detail.Select(tmp_str, "PO No, PO_Seq")


    '        If UpdRow.Length = 0 Then
    '            MsgBox("No rows need to update")
    '            Exit Function
    '        End If

    '        Cursor = Cursors.WaitCursor
    '        'Get Document String
    '        Dim rs_docno As DataSet
    '        gspStr = "sp_select_DOC_GEN '" & "','QC','" & gsUsrID & "'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_docno, rtnStr)

    '        If rtnLong <> RC_SUCCESS Then
    '            Cursor = Cursors.Default
    '            MsgBox("Error on loading sp_select_DOC_GEN:" & rtnStr)
    '            Exit Function
    '        End If

    '        Dim arr_wkfm(UpdRow.Length - 1) As Integer
    '        Dim arr_wkto(UpdRow.Length - 1) As Integer
    '        Dim arr_year(UpdRow.Length - 1) As Integer



    '        For m As Integer = 0 To UpdRow.Length - 1
    '            arr_wkfm(m) = UpdRow(m).Item("Week Fm")
    '            arr_wkto(m) = UpdRow(m).Item("Week To")
    '            arr_year(m) = UpdRow(m).Item("Year")
    '        Next

    '        Array.Sort(arr_wkfm)
    '        Array.Sort(arr_wkto)
    '        Array.Sort(arr_year)

    '        Dim minWeekfm As Integer = arr_wkfm(0)
    '        Dim maxWeekto As Integer = arr_wkto(UpdRow.Length - 1)
    '        Dim minyear As Integer = arr_year(0)

    '        QCNo = rs_docno.Tables("RESULT").Rows(0).Item(0).ToString

    '        Dim tmp_qch_qcsts As String = "OPEN"
    '        Dim tmp_qch_autogen As String = "Y"
    '        Dim tmp_qch_transactyp As String = "S"
    '        Dim tmp_qch_inspmode As String = "WEEK"

    '        gspStr = "sp_insert_QCREQHDR '" & gsCompany & "','" & _
    '            QCNo & "','" & _
    '            tmp_qch_qcsts & "','" & _
    '            tmp_qch_autogen & "','" & _
    '            GenBy & "','" & _
    '            Venno & "','" & _
    '            tmp_qch_transactyp & "','" & _
    '            tmp_qch_inspmode & "'," & _
    '            minyear & "," & _
    '            minWeekfm & "," & _
    '            maxWeekto & ",'" & _
    '            FirstDateOfWeekISO8601(minyear, minWeekfm) & "','" & _
    '            gsUsrID & "','" & _
    '            gsUsrID & "'"

    '        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading sp_insert_QCREQHDR:" & rtnStr)
    '            Cursor = Cursors.Default
    '            Exit Function
    '        End If

    '        For m As Integer = 0 To UpdRow.Length - 1
    '            gspStr = "sp_insert_QCREQDTL '" & gsCompany & "','" & _
    '                QCNo & "'," & _
    '                m + 1 & ",'" & _
    '                "OPEN" & "','" & _
    '                UpdRow(m).Item("InspectMode").ToString.ToUpper & "'," & _
    '                UpdRow(m).Item("Year") & "," & _
    '                UpdRow(m).Item("Week Fm") & "," & _
    '                UpdRow(m).Item("Week To") & ",'" & _
    '                UpdRow(m).Item("Date") & "','" & _
    '                UpdRow(m).Item("Insp. Typ") & "','" & _
    '                UpdRow(m).Item("GenBy") & "','" & _
    '                UpdRow(m).Item("Sample") & "','" & _
    '                UpdRow(m).Item("Remark") & "','" & _
    '                UpdRow(m).Item("PO No") & "'," & _
    '                UpdRow(m).Item("PO_Seq") & ",'" & _
    '                gsUsrID & "','" & _
    '                gsUsrID & "'"

    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                Cursor = Cursors.Default
    '                MsgBox("Error on loading sp_insert_QCREQDTL:" & rtnStr)
    '                Exit Function
    '            End If
    '        Next

    '        Msg = Msg & QCNo & "Save Sucess. (GenBy='" & GenBy & "', VenNo='" & Venno & "')" & vbCrLf

    '        QC_Save = True
    '    End Function
#End Region

    Private Sub ToStage(ByVal _stage As String)
        Select Case _stage
            Case "INIT"
                'Header Command
                mmdSave.Enabled = False
                mmdClear.Enabled = False


            Case "LOAD"
                mmdSave.Enabled = True
                mmdClear.Enabled = True

        End Select
    End Sub


#Region "User Change - Itm Dtl"
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


    End Sub

    Private Sub txt_Ordqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Ordqty.KeyPress
        If Not (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9") Then
            e.KeyChar = ""
        End If
    End Sub
#End Region


    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        If TabControl1.SelectedIndex = 1 Then

            dg_Header.ClearSelection()
            dg_Header.SelectAll()
        ElseIf TabControl1.SelectedIndex = 2 Then
            dg_Detail.ClearSelection()
            dg_Detail.SelectAll()
        End If





    End Sub

    Private Sub cbo_week_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_week.SelectedIndexChanged
        UpdateWeekDate()
    End Sub

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

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCopy.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        ' If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
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
