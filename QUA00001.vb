Imports Microsoft.Office.Interop
Imports System.IO

Public Class QUA00001
    Inherits System.Windows.Forms.Form

    Dim rs_EXCEL As DataSet
    Dim myExcel As Excel.Application
    Dim FilePattern As String = "*.xls"
    Dim filSourcePath As String = ""
    Dim numError As Integer

    Dim rs_check As New DataSet
    Dim rs_data As New DataSet
    Dim rs_check_hdr As New DataSet
    Dim rs_approve As New DataSet
    Dim rs_LIST_RESULT As New DataSet
    Dim rsM As New DataSet
    Dim tmp_cu As New DataSet

    Dim rs_IMBASINF As New DataSet ' for Item Basic
    Dim rs_IMCOLINF As New DataSet  ' for Item Color
    Dim rs_IMPRCINF As New DataSet  ' for Item Pricing
    Dim rs_IMPRCINF_NewAddItem As New DataSet
    Dim rs_IMPCKINF As New DataSet ' for Item Packing
    Dim rs_IMMATBKD As New DataSet  ' for Component Breakdown
    Dim rs_IMBOMASS As New DataSet  ' for Assorted Item
    Dim rs_IMVENINF As New DataSet  ' for Vendor Item (IMVENINF, IMPRCINF, VNBASINF)
    Public rs_QUOTNHDR As New DataSet ' for retrieve Quotation Header information

    Dim rs_CUGRPINF As New DataSet ' for Customer Group Information
    Dim rs_CUBASINF_P As New DataSet ' for Secondary Customer of Primary Customer
    Dim rs_CUBASINF_CP As New DataSet ' for Contact person of the Customer
    Dim rs_CUBASINF_A As New DataSet ' for Agent of Primary Customer

    Dim rs_QUPRCEMT_CU As New DataSet
    Public rs_QUCPTBKD As New DataSet ' for Component Breakdown information


    Dim colApv As Long
    Public uploadBatch As Date

    Dim FileToCopy As String
    Dim tmp_date As String
    Dim Alias_itm As Boolean
    Dim dr() As DataRow
    Public rs_SYHRMCDE As New DataSet ' for HSTU/Tariff #
    Dim rs_IMXCHK As New DataSet ' for multi Company item Check
    Public rs_QUOTNDTL As New DataSet ' for retrieve Quotation Details information
    Public rs_IMBASINF_A As New DataSet
    Public rs_QUASSINF As New DataSet ' for Assortment Item information
    Public rs_SYSALREL As New DataSet

    Dim drNewRow As DataRow

    Private Const cModeAdd As String = "New"
    Private Const cModeUpd As String = "Update"

    Dim txt_itmno As String

    Public rs_CUCNTINF_C As New DataSet
    Public rs_CUBASINF_S As New DataSet

    Public rs_SYTIESTR As New DataSet
    Public rs_SYCONFTR As New DataSet

    Public rs_CUBASINF_CR As New DataSet ' for Currency Rate
    Dim rs_IMTMPREL As New DataSet
    Public rs_SYUSRRIGHT_Check As New DataSet

    Private Const sMODULE As String = "QU"

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

    Dim txtCusItm_Text As String

    Public ORI_MOFLAG As String ' Define Variable to Store Original/Modified MOQ/MOA Flag
    Public ORI_MOA As String ' Define Variable to Store Original MOQ/MOA
    Public ORI_MOQ As String ' Define Variable to Store Original MOQ/MOA

    Dim org_MOFLAG_tmp As String
    Dim org_MOQ_tmp As String
    Dim org_MOA_tmp As String

    Dim org_IM_MOQ_tmp As String
    Dim org_IM_MOA_tmp As String
    Dim temp_txtQutNo As String


    Private Sub display_grdItem()
        'type
        'A - All
        'F - Functional
        'P - Pricing
        'T - Sample and TO
        'S - Summary

        If rs_LIST_RESULT.Tables.Count = 0 Then
            Exit Sub
        End If

        'grdItem.RowHeadersWidth = 18
        'grdItem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        'grdItem.ColumnHeadersHeight = 18
        'grdItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'grdItem.AllowUserToResizeColumns = True
        'grdItem.AllowUserToResizeRows = False
        'grdItem.RowTemplate.Height = 18
        'grdItem.ReadOnly = False
        'grdItem.DataSource = rs_LIST_RESULT.Tables("RESULT").DefaultView
        Dim i As Integer
        '        grdItem.Columns(grdItem_Del).Frozen = False

        For i = 0 To grdItem.ColumnCount - 1
            grdItem.Columns(i).ReadOnly = True
            grdItem.Columns(i).Visible = True
        Next



        i = 0 '0
        grdItem.Columns(i).HeaderText = "Count"
        grdItem.Columns(i).Width = 30
        i = i + 1 '1
        grdItem.Columns(i).HeaderText = "Action"
        grdItem.Columns(i).Width = 50
        grdItem.Columns(i).ReadOnly = False
        i = i + 1 '1
        grdItem.Columns(i).HeaderText = "Upload order"
        grdItem.Columns(i).Width = 37
        i = i + 1 '2
        grdItem.Columns(i).HeaderText = "Upload Item No."
        grdItem.Columns(i).Width = 90
        i = i + 1 '3
        grdItem.Columns(i).HeaderText = "Vendor No."
        grdItem.Columns(i).Width = 50
        i = i + 1 '4
        grdItem.Columns(i).HeaderText = "Vendor Name"
        grdItem.Columns(i).Width = 90
        i = i + 1 '5
        grdItem.Columns(i).HeaderText = ""   ' "Item Desc."
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False

        i = i + 1 '6
        grdItem.Columns(i).HeaderText = "color code"
        grdItem.Columns(i).Width = 50
        i = i + 1 '7
        grdItem.Columns(i).HeaderText = "UM"
        grdItem.Columns(i).Width = 50
        i = i + 1 '8
        grdItem.Columns(i).HeaderText = "Inner Quantity"
        grdItem.Columns(i).Width = 50
        i = i + 1 '9
        grdItem.Columns(i).HeaderText = "Master Quantity"
        grdItem.Columns(i).Width = 50
        i = i + 1 '10
        grdItem.Columns(i).HeaderText = "HK Price term"
        grdItem.Columns(i).Width = 90
        i = i + 1 '11
        grdItem.Columns(i).HeaderText = "FTY Price term"
        grdItem.Columns(i).Width = 90
        i = i + 1 '12
        grdItem.Columns(i).HeaderText = "Trans Term"
        grdItem.Columns(i).Width = 90

        i = i + 1 '13
        grdItem.Columns(i).HeaderText = ""
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False

        i = i + 1 '14
        grdItem.Columns(i).HeaderText = "Found Item ID"
        grdItem.Columns(i).Width = 130
        i = i + 1 '15
        grdItem.Columns(i).HeaderText = "Color code"
        grdItem.Columns(i).Width = 50
        i = i + 1 '16
        grdItem.Columns(i).HeaderText = "UM"
        grdItem.Columns(i).Width = 50
        i = i + 1 '17
        grdItem.Columns(i).HeaderText = "Inner Quantity"
        grdItem.Columns(i).Width = 90
        i = i + 1 '18
        grdItem.Columns(i).HeaderText = "master Quantity"
        grdItem.Columns(i).Width = 90
        i = i + 1 '19
        grdItem.Columns(i).HeaderText = "HK Price Term"
        grdItem.Columns(i).Width = 90
        i = i + 1 '20
        grdItem.Columns(i).HeaderText = "FTY Price Term"
        grdItem.Columns(i).Width = 90
        i = i + 1 '21
        grdItem.Columns(i).HeaderText = "Trans Term"
        grdItem.Columns(i).Width = 90

        i = i + 1 '22
        grdItem.Columns(i).HeaderText = "Message"
        grdItem.Columns(i).Width = 180
        i = i + 1 '23
        grdItem.Columns(i).HeaderText = "Act. Type"
        grdItem.Columns(i).Width = 90
        i = i + 1 '24
        grdItem.Columns(i).HeaderText = "Check"
        grdItem.Columns(i).Width = 90
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Case"
        grdItem.Columns(i).Width = 90




    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub QUAPP001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'chkQutNew.Enabled = False

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        'Call fillParameter()


        Call Formstartup(Me.Name)

        btcQUAPP001.SelectedIndex = 0
        btcQUAPP001.TabPages(0).Enabled = True
        btcQUAPP001.TabPages(1).Enabled = False


        Call resetDisplay(cModeAdd)

        txt_CusAgt_Text = ""
        txt_SalDiv_Text = ""
        txt_SalRep_Text = ""
        txt_Srname_Text = ""
        txt_SmpPrd_Text = ""
        txt_SmpFgt_Text = ""
        txtCurCde1 = ""
        quh_cugrptyp_int = ""
        quh_cugrptyp_ext = ""

        txt_PrcTrm_Text = ""
        txt_PayTrm_Text = ""

        txt_Cus1Ad_Text = ""
        txt_Cus1St_Text = ""
        txt_Cus1Cy_Text = ""
        txt_Cus1Zp_Text = ""
        txt_PrcTrm_Text = ""
        txt_PayTrm_Text = ""
        txt_SmpPrd_Text = ""
        txt_SmpFgt_Text = ""

        txt_Cus1Cp_Text = ""

        txt_Cus1CgInt_Text = ""
        txt_Cus1CgExt_Text = ""



        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btcQUAPP001_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btcQUAPP001.SelectedIndexChanged
        If btcQUAPP001.SelectedIndex = 1 Then
            optStatusG.Checked = True
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Dim NewCopy As String
        Dim filDePath As String

        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        Dim i As Integer
        Dim temp_qud_itmtyp As String
        Dim temp_qud_contopc As String
        Dim temp_pckcst As String
        Dim temp_itmComAmt As String


        Dim temp_value_P As String
        Dim temp_value_Q As String
        Dim temp_value_R As String
        Dim temp_value_S As String
        Dim temp_value_U As String
        Dim temp_value_V As String
        Dim temp_value_W As String
        Dim temp_value_X As String
        Dim temp_value_Y As String
        Dim temp_value_Z As String
        Dim temp_value_AA As String
        Dim temp_value_AC As String
        Dim temp_value_AD As String
        Dim temp_value_AE As String
        Dim temp_value_AF As String
        Dim temp_value_AG As String
        Dim temp_value_AH As String
        Dim temp_value_AL As String
        Dim temp_value_AM As String
        Dim temp_value_AN As String
        Dim temp_value_AX As String
        Dim temp_value_BE As String

        Dim temp_value_AO As String
        Dim temp_value_AU As String
        Dim temp_value_AW As String

        Dim temp_value_AT As String
        Dim temp_value_AV As String
        Dim temp_value_AZ As String
        Dim temp_value_BA As String
        Dim temp_value_BB As String
        Dim temp_value_BC As String
        Dim temp_value_BD As String


        Dim calBasicPrice As Decimal

        Dim calPckCstAmt As Decimal
        Dim calCommPer As Decimal
        Dim calCommAmt As Decimal

        Dim calCURounding As Integer

        Dim calAdjustedPrice As Decimal

        Dim cur_rate As Decimal


        'FileToCopy = filSourcePath

        'cur_rate = 1    'USD 7.75

        ''20130831
        ''no select file name
        ''filSource



        'If chkQutUpd.Checked = True Then
        '    If InStr(filSource.Text, ".") - 1 >= 0 Then
        '        If Microsoft.VisualBasic.Left(filSource.Text, InStr(filSource.Text, ".") - 1) <> txtQutNo.Text.ToString.Trim Then
        '            ' MsgBox("You have  uploaded a file with a different name to the quotation number.")
        '        End If
        '    End If
        'End If


        'NewCopy = filDePath + "\" + filSource.Text

        'If System.IO.File.Exists(FileToCopy) = True Then

        '    System.IO.File.Copy(FileToCopy, NewCopy)
        '    MsgBox("File Copied")

        'End If
        'check user right


        '''''''''''''''''''''''''''''''''''''20130831''''''''''''
        'check company


        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_SYUSRRIGHT_Check '" & cboCoCde.Text & "','" & gsUsrID & "','" & txtQutNo.Text & "','" & sMODULE & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtQutNoKeyPress sp_select_SYUSRRIGHT_Check :" & rtnStr)
            Exit Sub
        End If

        'there is not old quotation 

        If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
            'MsgBox("You have no Right access this company and its document.")
            'Exit Sub
        Else
        End If



        Cursor = Cursors.WaitCursor

        'xlsApp = New Excel.Application
        ''Set the excel invisible to prevent user interrupt the process of creating the excel
        'xlsApp.Visible = False
        'xlsApp.UserControl = False

        'Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'xlsWB = xlsApp.Workbooks.Open(FileToCopy)

        'xlsWS = xlsWB.ActiveSheet
        'xlsApp.Sheets(1).Activate()


        ''Check cus1 cus2


        Dim temp_insert_cus1no As String
        Dim temp_insert_cus2no As String

        If chkQutNew.Checked = True Then
            temp_insert_cus1no = cboCus1No.Text.Trim
            temp_insert_cus2no = cboCus2No.Text.Trim
        End If


        tmp_date = DateTime.Now.ToShortDateString & ".  " & DateTime.Now.ToLongTimeString



        MsgBox("Please Approve the Quotation and Select to Generate.")
        'btcQUAPP001.SelectedIndex(1)


        btcQUAPP001.SelectTab(1)

        btcQUAPP001.TabPages(0).Enabled = False
        btcQUAPP001.TabPages(1).Enabled = True


        gspStr = "sp_select_QUAPPDTL_approval '" & txtQutNo.Text.Trim & "'"


        rtnLong = execute_SQLStatement(gspStr, rs_LIST_RESULT, rtnStr)
        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QUAPPDTL_approval  :" & rtnStr)
            Exit Sub
        End If

        temp_txtQutNo = txtQutNo.Text.Trim

        For i = 0 To rs_LIST_RESULT.Tables("RESULT").Columns.Count - 1
            rs_LIST_RESULT.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        For i = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
            rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("tmp_count") = i + 1
        Next



        grdItem.DataSource = rs_LIST_RESULT.Tables("RESULT").DefaultView
        Call display_grdItem()



        txtFromApply.Text = "1"
        txtToApply.Text = rs_LIST_RESULT.Tables("RESULT").DefaultView.Count



    End Sub

    Private Sub cboCoCde_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.Click
        Call cboCoCdeClick()
    End Sub

    Private Sub cboCoCdeClick()
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Call getDefault_Path()

    End Sub

    Private Sub cboCoCde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoCde.KeyUp
        Call auto_search_combo(cboCoCde, e.KeyCode)
        Dim orgPos As Integer
        orgPos = cboCoCde.SelectedIndex
        If orgPos = -1 Then
            orgPos = 0
        End If
        cboCoCde.SelectedIndex = orgPos
        txtCoNam.Text = ChangeCompany(cboCoCde.SelectedItem, Me.Name)
    End Sub

    Private Sub cboCoCde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.LostFocus
        Call cboCoCdeClick()
    End Sub


    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.SelectedItem, Me.Name)

        gspStr = "sp_select_CUBASINF_P '" & cboCoCde.Text & "','Primary'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QUAPP001  sp_select_CUBASINF_P : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_CUBASINF_PRI '" & cboCoCde.Text & "','" & gsUsrID & "','" & "QU" & "'"
        'Fixing global company code problem at 20100420
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading QUM00001  sp_select_CUBASINF_PRI : " & rtnStr)
            Exit Sub
        Else
            rs_CUBASINF_P = rs.Copy() '*** Cus for company
        End If
        cboCus1No.Text = ""
        cboCus2No.Text = ""

        Call fillcboPriCust() '

    End Sub


    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        'Dim isConvert As Boolean = False
        Dim NewCopy As String
        Dim filDePath As String

        'Dim xlsApp As New Excel.ApplicationClass
        'Dim xlsWB As Excel.Workbook = Nothing
        'Dim xlsWS As Excel.Worksheet = Nothing

        Dim i As Integer
        Dim temp_qud_itmtyp As String
        Dim temp_qud_contopc As String


        Dim Message As String
        Dim tmp_type As String
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

        Dim tmp_id As String
        Dim txt_cus1na As String
        Dim txt_cus2na As String

        Dim sFilter As String
        Dim li_index_insert As Integer
        Dim li_index_seq As Integer

        Dim ta1 As Integer
        Dim ta2 As String
        Dim ta3 As String
        Dim ta4 As String
        Dim ta5 As String
        Dim ta6 As String
        Dim ta7 As String
        Dim ta8 As String

        Dim txtInvRndP_Text As Integer
        Dim max_seq_insert As Integer

        Dim temp_cus1_for_name As String
        Dim temp_cus2_for_name As String



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


        If chkQutNew.Checked = False Then
            tmp_type = "UPD"
        Else
            tmp_type = "NEW"
        End If

        Dim li_act_Y_count As Integer
        ''check at least one "Y"
        li_act_Y_count = 0
        For index_i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("tmp_action").ToString = "Y" Then
                li_act_Y_count = li_act_Y_count + 1
            End If
        Next

        If li_act_Y_count = 0 Then
            MsgBox("Please Select at least one item to generate!")
            Cursor = Cursors.Default

            Exit Sub
        End If





        '''''''##should gen only once
        cmdGen.Enabled = False


        ''Check is "NEW"
        'Setup Quotation No
        If chkQutNew.Checked Then
            Dim rs As New DataSet


            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','QO','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                Cursor = Cursors.Default

                Exit Sub
            End If

            txtQutNo.Text = rs.Tables("RESULT").Rows(0)(0).ToString
        End If

        txtQutNo2.Text = txtQutNo.Text





        'get customer name
        gspStr = "sp_select_CUBASINF_P '" & cboCoCde.Text & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QUAPP001  sp_select_CUBASINF_P : " & rtnStr)
            Cursor = Cursors.Default

            Exit Sub
        End If





        'Check Duplicate
        For index_i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("tmp_action").ToString = "Y" Then

                For index_j As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("tmp_action").ToString = "Y" Then
                        If index_i <> index_j Then

                            If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_itmno").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_itmno").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_pckunt").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_pckunt").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_inrqty").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_inrqty").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_mtrqty").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_mtrqty").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_hkprctrm").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_hkprctrm").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_ftyprctrm").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_ftyprctrm").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_colcde").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_colcde").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_trantrm").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("res_trantrm").ToString() _
                            And rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_itmno").ToString() <> "" Then
                                MsgBox("Item:" & index_i + 1 & " Item:" & index_j + 1 & " are duplcated items, please choose either one only.")
                                cmdGen.Enabled = True
                                Cursor = Cursors.Default

                                Exit Sub
                            End If

                        End If

                    End If
                Next

            End If
        Next


        gspStr = "sp_select_QUOTNDTL '" & "" & "',''"
        rtnLong = execute_SQLStatement(gspStr, rs_QUOTNDTL, rtnStr)
        gspStr = ""

        li_index_insert = -1

        ''''''''''''For Each Data Grip Rows , Gen
        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If index > rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1 Then
                Exit For
            End If

            If rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_action").ToString = "Y" Then

                li_index_seq = li_index_seq + 1

                tmp_id = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_id").ToString


                Dim cus1no As String
                Dim cus2no As String

                If Trim(cboCus1No.Text) = "" Then
                    cus1no = ""
                Else
                    cus1no = Trim(Split(cboCus1No.Text, "-")(0))
                End If

                If Trim(cboCus2No.Text) = "" Then
                    cus2no = ""
                Else
                    cus2no = Trim(Split(cboCus2No.Text, "-")(0))
                End If

                '20130909
                txt_SalRep_Text = Trim(Split(txt_SalRep_Text, "(")(0))
                txt_SalRep_Text = Microsoft.VisualBasic.Left(txt_SalRep_Text, 12)
                Dim tmp_contopc As String

                gspStr = "sp_update_QUPRCEMT_from_Excel '" & _
                   rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_acttyp").ToString.Trim & _
                   "','" & FileToCopy & _
                   "','" & tmp_date & _
                   "','" & cboCoCde.Text.Trim & _
                   "','" & txtQutNo.Text.Trim & _
                    "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_id").ToString.Trim & _
                    "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_itmno").ToString.Trim & _
                        "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_colcde").ToString.Trim & _
                     "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_pckunt").ToString.Trim & _
                    "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_inrqty").ToString.Trim & _
                    "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_mtrqty").ToString.Trim & _
                    "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_hkprctrm").ToString.Trim & _
                    "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_trantrm").ToString.Trim & _
                    "','" & Microsoft.VisualBasic.Left(cboCus1No.Text.Trim, 5) & _
                    "','" & Microsoft.VisualBasic.Left(cboCus2No.Text.Trim, 5) & _
                    "','" & txt_CusAgt_Text & _
                    "','" & txt_SalDiv_Text & _
                    "','" & txt_SalRep_Text & _
                    "','" & txt_Srname_Text & _
                    "','" & txt_SmpPrd_Text & _
                    "','" & txt_SmpFgt_Text & _
                    "','" & txtCurCde1 & _
                    "','" & txt_PrcTrm_Text & _
                    "','" & txt_PayTrm_Text & _
                    "','" & txt_Cus1Ad_Text & _
                    "','" & txt_Cus1St_Text & _
                    "','" & txt_Cus1Cy_Text & _
                    "','" & txt_Cus1Zp_Text & _
                    "','" & txt_Cus1Cp_Text & _
                    "','" & txt_Cus1CgInt_Text & _
                    "','" & txt_Cus1CgExt_Text & _
                    "','" & "N" & _
                    "'," & 0 & _
                    ",'" & gsUsrID & _
                             "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_case") & "'"

                rtnLong = execute_SQLStatement(gspStr, rsM, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default
                Message = "sp_update_QUPRCEMT_from Excel"

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on Updating: " & Message & " :" & rtnStr)
                    Cursor = Cursors.Default

                    Exit Sub
                End If

                ''get the max seq_number for insert
                If rsM.Tables("RESULT").Rows.Count > 0 Then
                    max_seq_insert = rsM.Tables("RESULT").DefaultView(0)("max_seq_insert")
                End If





                '''''''''''''''''''''''''''''''''''''''''''''''''
                'NEW & IN IM
                '''''''''''''''''''''''''''''''''''''''''''''''''
                'Insert Requote Item
                If (tmp_type = "NEW" And rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_case") = "5") Then
                    gspStr = "sp_insert_QUOTNDTL_REQUOTEITM '" & cboCoCde.Text & "','" & _
                        txtQutNo.Text & "','" & _
                        max_seq_insert & "','" & _
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_itmno") & "','" & _
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_pckunt") & "','" & _
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_inrqty") & "','" & _
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_mtrqty") & "','" & _
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_hkprctrm") & "','" & _
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_ftyprctrm") & "','" & _
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("tmp_trantrm") & "','" & _
                        gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading sp_insert_QUOTNDTL_REQUOTEITM : " & rtnStr)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    Call insert_QUOTNDTL()

                    li_index_insert = li_index_insert + 1

                ElseIf (tmp_type = "NEW" And _
                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_case") <> "4" And rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_case") <> "5") Or _
                (tmp_type = "UPD" And _
                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_acttyp") = "NEW" And _
                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_case") <> "4") Then

                    'Insert Normal Item

                    ''''***#########Change Later:  sholud be res_itmno, for the itmno of quotation '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    txt_itmno = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_itmno").ToString.Trim()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    gsCompany = Trim(cboCoCde.Text)
                    Call Update_gs_Value(gsCompany)

                    gspStr = "sp_select_IMBASINF_Q '" & cboCoCde.Text & "','" & txt_itmno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF, rtnStr)
                    gspStr = ""

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading txtItmNo_Press sp_select_IMBASINF_Q :" & rtnStr)
                        Cursor = Cursors.Default

                        Exit Sub
                    End If

                    'If not in Item Master table, then call simple insert

                    If rs_IMBASINF.Tables("RESULT").Rows.Count = 0 Then 'not in IM?
                        'case 4
                        'Item Added through sp_update_quprcemt
                        'MsgBox("OK")
                        'Maybe Update some Value Here
                        'but no  price Elements 
                    Else

                        'get Item Price
                        gsCompany = Trim(cboCoCde.Text)
                        Call Update_gs_Value(gsCompany)

                        gspStr = "sp_select_IMPRCINF_Q '" & cboCoCde.Text & "','" & txt_itmno & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF_NewAddItem, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading txtItmNo_Press sp_select_IMPRCINF_Q :" & rtnStr)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If



                        gsCompany = Trim(cboCoCde.Text)
                        Call Update_gs_Value(gsCompany)

                        gspStr = "sp_select_IMCOLINF '" & cboCoCde.Text & "','" & txt_itmno & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF, rtnStr)
                        gspStr = ""

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading txtItmNo_Press sp_select_IMCOLINF :" & rtnStr)
                            Cursor = Cursors.Default

                            Exit Sub
                        End If

                        txt_icf_colcde = rs_IMCOLINF.Tables("RESULT").Rows(0)("icf_colcde").ToString
                        If txt_icf_colcde = "" Then
                            txt_icf_colcde = "N/A"
                        End If


                        gspStr = "sp_select_IMPCKINF_Q '" & cboCoCde.Text & "','" & txt_itmno & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF, rtnStr)
                        gspStr = ""

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading txtItmNo_Press sp_select_IMPCKINF_Q :" & rtnStr)
                            Exit Sub
                        End If

                        'lloop to filer
                        For index2 As Integer = 0 To rs_IMPCKINF.Tables("RESULT").DefaultView.Count - 1
                            If rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_pckunt").ToString.Trim = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_pckunt").ToString.Trim And _
                             rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_inrqty").ToString.Trim = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrqty").ToString.Trim And _
                              rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_mtrqty").ToString.Trim = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrqty").ToString.Trim _
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
                                txt_ipi_qutdat = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_qutdat").ToString.Trim

                            End If

                        Next


                        ''' Material BreakDown
                        gspStr = "sp_select_IMMATBKD '" & cboCoCde.Text & "','" & txt_itmno & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_IMMATBKD, rtnStr)
                        gspStr = ""

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading txtItmNo_Press sp_select_IMMATBKD :" & rtnStr)
                            Exit Sub
                        End If


                        '''ASS
                        gspStr = "sp_select_IMBOMASS_Q '" & cboCoCde.Text & "','" & txt_itmno & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_IMBOMASS, rtnStr)
                        gspStr = ""

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading txtItmNo_Press sp_select_IMBOMASS_Q :" & rtnStr)
                            Exit Sub
                        End If






                        Call insert_QUOTNDTL()

                        'NOT seq#
                        li_index_insert = li_index_insert + 1



                        'update fields 
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("Del") = ""
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("mode") = ""
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("upditmdtl") = "N"
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("updmoqmoa") = "N"
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("updassbom") = "N"
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("converttopc") = "N"
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cocde") = cboCoCde.Text
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutno") = txtQutNo.Text
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

                        IsNthVenInf = False
                        IsNthCaMrk = False
                        IsNthIM = False

                        dblCstEmtPert = 0
                        dblCstEmtAmt = 0

                        '' Cursor = Cursors.WaitCursor

                        gsCompany = Trim(cboCoCde.Text)
                        Call Update_gs_Value(gsCompany)

                        '*** Phase 2  '''??ftyprctrm
                        gspStr = "sp_select_QUOTNDTL_Vendor '" & cboCoCde.Text & "','" & txt_itmno & "','" & _
                                                                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_pckunt").ToString.Trim & "','" & _
                                                                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_inrqty").ToString.Trim & "','" & _
                                                                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_mtrqty").ToString.Trim & "','" & _
                                                                cus1no & "','" & cus2no & "','" & _
                                                                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_ftyprctrm").ToString.Trim & "','" & _
                                                                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_hkprctrm").ToString.Trim & "','" & _
                                                                rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_trantrm").ToString.Trim & "','" & _
                                                                gsUsrID & "'"
                        'gspStr = "sp_select_QUOTNDTL_Vendor '" & cboCoCde.Text & "','" & _
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
                        '''End If


                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_effdat") = "01/01/1900"
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_expdat") = "01/01/1900"

                        If rs_IMVENINF.Tables("RESULT").Rows.Count > 0 Then

                            ''
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = Format(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), "########0.0000")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_venno") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_prdven")   'shortform , but: ivi_venno long form, 'qud_venno or imu_prdven

                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftyprctrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprctrm")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_prctrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_prctrm")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_trantrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_trantrm")

                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus1no")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus2no")

                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_effdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_effdat")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_expdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_expdat")

                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''
                        'end pring
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''




                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmsts") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts")

                        If Not IsDBNull(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts")) Then
                            If (Microsoft.VisualBasic.Left(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts"), 3) = "CMP") Then
                                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutitmsts") = "A"
                            ElseIf (Microsoft.VisualBasic.Left(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts"), 3) = "INC") Then
                                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutitmsts") = "W"
                            End If
                        End If



                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmno") = txt_itmno
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmtyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ")

                        '                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ")  'same?
                        If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal").trim <> "" Then
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") = "R"
                        ElseIf rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp").trim <> "" Then
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") = "T"
                        Else
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") = "V"
                        End If


                        '----------------real & temp---------------
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal") = rs_LIST_RESULT.Tables("RESULT").Rows(index).Item("res_itmno")  'same?

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
                                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp") = rs_LIST_RESULT.Tables("RESULT").Rows(index).Item("res_itmno")
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


                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoven") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ven.vbi_vensna")
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnovenno") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno")

                        'case 4  ,  Item not in IM
                        If rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_case") = "4" Then
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoven") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_itmno")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno") = ""
                        Else
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoven") = ""
                        End If



                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmdsc") = Replace(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_engdsc"), "'", "''")

                        gspStr = "sp_select_IMBASINF_Q_A '" & cboCoCde.Text & "','" & txt_itmno & "'"
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

                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_upc") = ""               '?
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde") = txt_icf_colcde
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_coldsc") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_alscolcde") = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_alscolcde")
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscol") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_pckseq") = txt_ipi_pckseq
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_packterm") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_pckunt").ToString.Trim
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrqty") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_inrqty").ToString.Trim
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrqty") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_mtrqty").ToString.Trim
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_prctrm") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_hkprctrm")
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprctrm") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftyprctrm")
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_trantrm") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_trantrm")
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_conftr") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_conftr")


                        'cus1   
                        temp_cus1_for_name = Microsoft.VisualBasic.Left(cboCus1No.Text.Trim, 5)




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
                        temp_cus2_for_name = Microsoft.VisualBasic.Left(cboCus2No.Text.Trim, 5)



                        gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & temp_cus1_for_name & "','Secondary'"
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
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutdat") = txt_ipi_qutdat 'DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
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
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_curcde") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_curcde")
                        If rs_QUOTNDTL.Tables("RESULT").Rows.Count = 1 Then
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_curcde") = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_curcde")
                        Else
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_curcde") = rs_QUOTNDTL.Tables("RESULT").Rows(0).Item("qud_curcde")
                        End If
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1sp") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2sp") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2dp") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_discnt") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_contopc") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_pcprc") = 0

                        If rs_IMVENINF.Tables("RESULT").Rows.Count > 0 Then
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_fcurcde") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_curcde")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprc") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftyprc")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftycst") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycst")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_basprc") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_basprc")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftyprctrm") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftyprctrm")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_prctrm") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_prctrm")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_trantrm") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_trantrm")
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
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cocde") = cboCoCde.Text
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_qutno") = txtQutNo.Text

                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_qutseq") = li_index_insert + 1
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_itmno") = txt_itmno
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_untcde") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_pckunt").ToString.Trim
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_inrqty") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_inrqty").ToString.Trim

                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_mtrqty") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_mtrqty").ToString.Trim
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cft") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_cft")
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cbm") = txt_ipi_cbm
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus1no") = Microsoft.VisualBasic.Left(cboCus1No.Text.Trim, 5)
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus2no") = Microsoft.VisualBasic.Left(cboCus2No.Text.Trim, 5)


                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl3")
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat") = xlsApp.Range("A" + (tmp_id + 2).ToString).Value

                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ventyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("vbi_ventyp")
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_ventranflg") = "N"
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus1no") = xlsApp.Range("D" + (tmp_id + 2).ToString).Value
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus2no") = xlsApp.Range("E" + (tmp_id + 2).ToString).Value
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl3")
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ventyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno")
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ventyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno")
                        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_ventranflg") = ""
                        '                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_prctrm") = xlsApp.Range("AP" + (tmp_id + 2).ToString).Value
                        '                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_trantrm") = xlsApp.Range("AQ" + (tmp_id + 2).ToString).Value
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_mu") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_mumin") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_muprc") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_muminprc") = 0

                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cus1sp") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cus1dp") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cushcstbufper") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cushcstbufamt") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_othdisper") = 0
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

                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_subttlper") = 0
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
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpunt") = ""
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
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusven") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cusven"), "-")(0)
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_DV") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno"), "-")(0)
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_TV") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tradeven"), "-")(0)
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyaud") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno"), "-")(0)
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cususdcur") = "USD"
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cususd") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscadcur") = "CAD"
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscad") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_note") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde") = rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_colcde").ToString

                        If IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde")) Then
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde") = "N/A"
                        Else
                            If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde") = "" Then
                                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde") = "N/A"
                            End If
                        End If

                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_note") = ""


                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_imgpth") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth")
                        If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_imgpth") <> "" Then
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
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_imrmk") = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_rmk")
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_calpmu") = 0
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_creusr") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_updusr") = ""
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_credat") = DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_upddat") = DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_timstp") = 0

                        If rs_IMBASINF.Tables("RESULT").Rows.Count > 0 Then
                            'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno") = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_venno")   'shortform , but: ivi_venno long form
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_subcde") = rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_subcde")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venitm") = rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")

                            'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusven") = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")
                            'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_dv") = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")
                            'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_tv") = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")
                            'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyaud") = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")
                        End If

                        Call retrieveMOQMOA(li_index_insert)

                        txtCusItm_Text = ""

                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusstyno") = GetCusSty2(rs_QUOTNDTL.Tables("RESULT").DefaultView(li_index_insert)("qud_itmno"), Trim(Split(cboCus1No.Text, "-")(0)), li_index_insert)
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusitm") = txtCusItm_Text

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'calcaulate Price Elements, has price elements  then Insert


                        ta1 = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq")
                        ta1 = IIf(IsDBNull(ta1), 0, ta1)
                        ta2 = cus1no
                        ta3 = cus2no
                        ta4 = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("vbi_ventyp")
                        ta4 = IIf(IsDBNull(ta4), "", ta4)

                        ta5 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat"))

                        If ta5 = "MAGICSILK" Or ta5 = "FLORAL FTY" Then
                            ta5 = ""
                        End If
                        ta6 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno"))

                        ta7 = IIf(IsDBNull(rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_hkprctrm").ToString.Trim), "", rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_hkprctrm").ToString.Trim)
                        ta8 = IIf(IsDBNull(rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_trantrm").ToString.Trim), "", rs_LIST_RESULT.Tables("RESULT").DefaultView(index)("res_trantrm").ToString.Trim)

                        If get_QUPRCEMT_CU(ta1, ta2, ta3, ta4, ta5, ta6, ta7, ta8) = True Then
                            ''If get_QUPRCEMT_CU(txtSeq.Text, Split(cboCus1No.Text, "-")(0).Trim, Split(cboCus2No.Text, "-")(0).Trim, txtVenTyp.Text.Trim, txtItmCat.Text.Trim, Split(cboVenNo.Text.Trim, "-")(0).Trim, cboDtlPrcTrm.Text, cboTranTrm.Text) = True Then


                            Call calculate_gbPandelCstEmt(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq"))


                            '*** Conversion Factor
                            '' Cursor = Cursors.WaitCursor

                            ''gsCompany = Trim(cboCoCde.Text)
                            ''Call Update_gs_Value(gsCompany)

                            ''gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde") & "','Conversion'"
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
                                    cboCoCde.Text & _
                                    "','" & txtQutNo.Text & _
                                     "','" & max_seq_insert & _
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
                                "01/01/1900" & _
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

                            '''PRCEMT
                            ''' 
                            gspStr = "sp_insert_QUPRCEMT '" & _
        cboCoCde.Text & "','" & _
        txtQutNo.Text & "','" & _
        max_seq_insert & "','" & _
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

                            '' Cursor = Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading save_Detail sp_insert_QUPRCEMT:" & rtnStr)
                                Exit Sub
                            End If




                            'Insert Additonal qutation info to QUOTNDTL and QUPRCEMT
                            gspStr = "sp_Insert_QUOTNDTL_from_Excel '" & _
                            tmp_type & _
                           "','" & FileToCopy & _
                           "','" & tmp_date & _
                           "','" & cboCoCde.Text.Trim & _
                           "','" & txtQutNo.Text.Trim & _
                                                         "','" & max_seq_insert & _
                            "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_itmno") & "'"

                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            gspStr = ""

                            '' Cursor = Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading sp_Insert_QUOTNDTL_from_Excel:" & rtnStr)
                                Exit Sub
                            End If


                            'INI Assortment
                            gsCompany = Trim(cboCoCde.Text)
                            Call Update_gs_Value(gsCompany)

                            gspStr = "sp_select_QUASSINF '" & cboCoCde.Text & "','" & txtQutNo.Text.ToString.Trim & "'"
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
                                        If rs_QUASSINF.Tables("RESULT").DefaultView(0)("qai_qutno").ToString = txtQutNo.Text And _
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
                                        If rs_QUASSINF.Tables("RESULT").DefaultView(0)("qai_qutno").ToString = txtQutNo.Text And _
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
                                    drNewRow("qai_qutno") = txtQutNo.Text
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

                                    gsCompany = Trim(cboCoCde.Text)
                                    Call Update_gs_Value(gsCompany)

                                    gspStr = "sp_insert_QUASSINF '" & cboCoCde.Text & "','" & txtQutNo.Text & "','" & max_seq_insert & "','" & _
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
                            Call save_QUCPTBKD(txt_itmno, li_index_seq)






                            ''''''''''''''''End Insert''''''''''''''''''''''''''''''

                        Else     'Do NOT has Price Elements
                            'Exit Sub
                            'Just Gen Next Item
                        End If



                    End If    ''''''''''''''''''''''''''''ITEM NOT found

                End If '''''''''''''''''''''''''''''''''NEW CASE


            End If

exit_main_loop:

        Next




        If chkQutNew.Checked = False Then
            MsgBox("Quotation Updated!")
        Else
            MsgBox("Quotation Added!")
        End If


    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Dim opt As String
        Dim intFm As Long
        Dim intTo As Long


        If rs_LIST_RESULT.Tables.Count = 0 Then Exit Sub
        If rs_LIST_RESULT.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        If Val(txtFromApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            Cursor = Cursors.Default

            txtFromApply.SelectAll()
            Exit Sub
        End If

        If Not IsNumeric(txtFromApply.Text) Then
            MsgBox("The apply range should be integers!")
            Cursor = Cursors.Default
            txtFromApply.SelectAll()
            Exit Sub
        End If

        If Val(txtToApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        If Not IsNumeric(txtToApply.Text) Then
            MsgBox("The apply range should be integers!")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        txtFromApply.Text = CInt(txtFromApply.Text)
        txtToApply.Text = CInt(txtToApply.Text)


        If Val(txtToApply.Text) > rs_LIST_RESULT.Tables("RESULT").DefaultView.Count Then
            MsgBox("The apply range cannot larger than the total number of records.")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        If Val(txtFromApply.Text) > Val(txtToApply.Text) Then
            MsgBox("The apply range is invalid.")
            txtFromApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        intFm = CLng(txtFromApply.Text)
        intTo = CLng(txtToApply.Text)

        If intTo > rs_LIST_RESULT.Tables("RESULT").DefaultView.Count Then
            intTo = rs_LIST_RESULT.Tables("RESULT").DefaultView.Count
        End If


        ''apply
        If optStatusG.Checked = True Then
            For index As Integer = intFm To intTo
                If chkallmatch.Checked = True Then
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_check") = "Y" _
                    And (Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_case")) = "1.1" _
                         Or Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_case")) = "0") Then   'whole key match:  itmno, packing, terms
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("tmp_action") = "Y"
                    End If

                Else
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_check") = "Y" Then
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("tmp_action") = "Y"
                    End If
                End If
            Next
        ElseIf optStatusN.Checked = True Then
            For index As Integer = intFm To intTo
                rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("tmp_action") = "N"
            Next
        End If

        rs_LIST_RESULT.Tables("RESULT").AcceptChanges()

    End Sub


    Private Sub chkQutNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkQutNew.CheckedChanged

        If chkQutNew.Checked = False And chkQutUpd.Checked = False Then
            Cursor = Cursors.Default
            Exit Sub
        Else
            If chkQutNew.Checked = True And chkQutUpd.Checked = True Then
                MsgBox("Please Choose either New or Update Quotation.")
                chkQutNew.Checked = False
                chkQutUpd.Checked = False
                Call resetDisplay(cModeAdd)
                Cursor = Cursors.Default

                Exit Sub
            End If

            If chkQutNew.Checked = True And chkQutUpd.Checked = False Then
                Call resetDisplay(cModeAdd)
                Cursor = Cursors.Default
                Exit Sub
            End If

            If chkQutNew.Checked = False And chkQutUpd.Checked = True Then
                Call resetDisplay(cModeUpd)
                Cursor = Cursors.Default
                Exit Sub
            End If

        End If
    End Sub

    Private Sub grdItem_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItem.CellClick
        'If e.RowIndex >= 0 Then
        '    isSorting = False
        '    dr = rs_LIST_RESULT.Tables("RESULT").Select("", "qud_qutseq")

        '    For index As Integer = 0 To dr.Length - 1
        '        If rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("qud_qutseq") = dr(index)("qud_qutseq") Then
        '            li_index_insert = index
        '        End If
        '    Next
        'Else
        '    isSorting = True
        'End If

        If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
            If grdItem.Columns(e.ColumnIndex).ReadOnly = False Then
                If rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("tmp_action").ToString = "Y" Then
                    rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("tmp_action") = "N"
                Else
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("res_check") = "Y" Then
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("tmp_action") = "Y"
                    End If
                End If
                rs_LIST_RESULT.Tables("RESULT").AcceptChanges()
            End If
        End If


    End Sub

    Private Sub grdItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItem.CellContentClick



    End Sub

    Private Function isNewItemFormat(ByVal strItem As String, Optional ByVal bolShow As Boolean = False) As Boolean
        If gsCompanyGroup = "MSG" Then
            isNewItemFormat = False
        Else
            isNewItemFormat = False
            strItem = UCase(strItem)

            If bolShow = True Then
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function

                If UCase(Mid(strItem, 7, 2)) = "AS" And _
                    Microsoft.VisualBasic.Right(strItem, 2) <> "00" And _
                    UCase(Mid(strItem, 3, 1)) <> "C" And _
                    UCase(Mid(strItem, 3, 1)) <> "D" Then Exit Function

                If UCase(Mid(strItem, 7, 2)) <> "AS" Then
                    If UCase(Mid(strItem, 3, 1)) = "U" Then
                        Exit Function
                    End If

                    If UCase(Mid(strItem, 3, 1)) = "A" Then

                    End If

                    '*** Plant CDTXV
                    If UCase(Mid(strItem, 3, 1)) = "C" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "D" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "T" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "V" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "X" Then

                    End If

                    If UCase(Mid(strItem, 3, 1)) = "B" Then
                        If (Mid(strItem, 4, 1) >= "0" And Mid(strItem, 4, 1) <= "9") Then
                            If Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9" Then
                                If (Mid(strItem, 6, 1) >= "0" And Mid(strItem, 6, 1) <= "9") Then
                                    isNewItemFormat = True
                                    Exit Function
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End If

                        If Mid(strItem, 4, 1) >= "A" And Mid(strItem, 4, 1) <= "Z" Then
                            If Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9" Then
                                If Mid(strItem, 6, 1) >= "0" And Mid(strItem, 6, 1) <= "9" Then
                                    isNewItemFormat = True
                                    Exit Function
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End If
                    End If
                Else
                    Exit Function
                End If
            Else
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function
            End If
            isNewItemFormat = True
        End If
    End Function

    Private Function not_Valid_Item(ByVal itmNo As String, ByVal cus1no As String, ByVal colcde As String) As Boolean
        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMXChk '" & cboCoCde.Text & "','" & cus1no & "','" & colcde & "','" & itmNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMXCHK, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading not_Valid_Item sp_select_IMXChk :" & rtnStr)
            Exit Function
        End If

        If rs_IMXCHK.Tables("RESULT").Rows.Count = 0 Then
            not_Valid_Item = True
            MsgBox("Item cannot Quot by this Company! Customer and Company Relation Missing.")
        Else
            If rs_IMXCHK.Tables("RESULT").Rows(0)("imx_vendef").ToString <> "Y" Then
                If MsgBox("This is not the default company to quot this item, Do you continue the quot?", vbYesNo) = vbYes Then
                    not_Valid_Item = False
                Else
                    not_Valid_Item = True
                End If
            Else
                not_Valid_Item = False
            End If
        End If
    End Function

    Private Sub GetCusSty(ByVal strItm As String)
        '*** Show Customer Alias
        Dim rsCusals As New DataSet

        'cboCusals.Items.Clear()
        'cboCusals.Text = ""

        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMCUSSTY_QU '" & cboCoCde.Text & "','" & strItm & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ")) & "'"
        rtnLong = execute_SQLStatement(gspStr, rsCusals, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading GetCusSty sp_select_IMCUSSTY_QU :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If rsCusals.Tables("RESULT").Rows.Count > 0 Then
            '   cboCusals.Items.Add("")
            For index As Integer = 0 To rsCusals.Tables("RESULT").Rows.Count - 1
                '      cboCusals.Items.Add(rsCusals.Tables("RESULT").Rows(index)("ics_cusstyno").ToString)
            Next

            ' cboCusals.SelectedIndex = 0
            'cboCusals.Enabled = True
        Else
            'cboCusals.Items.Clear()
            'cboCusals.Text = ""
            ''cboCusals.Enabled = False
        End If
    End Sub

    Public Function SearchImgPath(ByVal itmNo As String) As String
        '*** The objective of this function is to search for the sub-directory
        '*** of an item image.  This sub-directory is defined as the first 3
        '*** characters of a "revised" item number
        '*** converting format of the item no:
        itmNo = revisedItmno(itmNo)
        '*** Take the first 3 characters of the item no.
        SearchImgPath = Microsoft.VisualBasic.Left(itmNo, 8)
    End Function
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

    Private Function isABUAssortment(ByVal itmNo As String) As Boolean
        '*** FOR ALL ASSORTMENT
        Dim rs_ABUASST As New DataSet

        isABUAssortment = False

        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CHECK_ASST_FOR_PC '" & cboCoCde.Text & "','" & IIf(itmNo = "", "X", itmNo) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_ABUASST, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading isABUAssortment sp_select_CHECK_ASST_FOR_PC :" & rtnStr)
            Cursor = Cursors.Default
            Exit Function
        End If
        Cursor = Cursors.Default

        If rs_ABUASST.Tables("RESULT").Rows.Count > 0 Then
            isABUAssortment = True
        Else
            isABUAssortment = False
        End If
    End Function


    Private Sub ABUASST(ByVal itmNo As String, ByVal Action As String)
        'Select Case Action
        '    Case "SHOW"
        '        txtUMFtr.Visible = True
        '        lblUMFtr.Visible = True
        '        chkPC.Visible = True
        '        chkPC.Enabled = True
        '        If chkPC_hdr.Checked = True Then
        '            chkPC.Enabled = False
        '        Else
        '            chkPC.Enabled = True
        '        End If
        '    Case "HIDE"
        '        txtUMFtr.Visible = False
        '        chkPC.Visible = True
        '        chkPC.Enabled = True
        '        lblUMFtr.Visible = False
        '        txtUMFtr_Text = ""
        '        chkPC.Visible = False
        '        chkPC.Enabled = False
        '    Case "SHOWPRC"
        '        lblPCPrc.Visible = True
        '        txtPCPrcCur.Visible = True
        '        txtPCPrc.Visible = True

        '        txtPCPrcCur.Enabled = False
        '        txtPCPrc.Enabled = True
        '        txtCus1Dp.Enabled = False
        '    Case "HIDEPRC"
        '        lblPCPrc.Visible = False
        '        txtPCPrcCur.Visible = False
        '        txtPCPrc.Visible = False

        '        txtPCPrcCur.Enabled = False
        '        txtPCPrc.Enabled = False
        '        txtCus1Dp.Enabled = True
        '        txtPCPrc_Text = "0"
        '    Case "CHKPCK_A"
        '        If isABUAssortment(itmNo) = True Then
        '            If rs_IMPCKINF.Tables("RESULT").Rows.Count > 0 Then
        '                dr = rs_IMPCKINF.Tables("RESULT").Select("ipi_pckunt = '" & Split(cboPcking.Text, " / ")(0) & "' and ipi_inrqty = " & Split(cboPcking.Text, " / ")(1) & " and ipi_mtrqty = " & Split(cboPcking.Text, " / ")(2))
        '                If dr(0)("ipi_conftr").ToString <> "" Then
        '                    txtUMFtr_Text = dr(0)("ipi_conftr").ToString()
        '                    Call ABUASST(txtItmNo.Text, "SHOW")
        '                End If
        '            End If
        '        End If
        '    Case "CALPCPRCI"
        '        If txtCus1Sp.Text <> "" And txtUMFtr_Text <> "" Then
        '            Call txtPCPrcGotFocus()
        '            If txtDiscnt.Text <> "" And IsNumeric(txtDiscnt.Text) = True Then
        '                If Val(txtDiscnt.Text) = 0 Then
        '                    txtPCPrc_Text = Format(txtCus1Sp.Text / txtUMFtr_Text, "###,###,##0.0000")
        '                Else
        '                    txtPCPrc_Text = Format(txtCus1Dp.Text / txtUMFtr_Text, "###,###,##0.0000")
        '                End If
        '            Else
        '                txtPCPrc_Text = Format(txtCus1Sp.Text / txtUMFtr_Text, "###,###,##0.0000")
        '            End If
        '            rs_QUOTNDTL.Tables("RESULT").Rows.Item(li_index_insert)("qud_pcprc") = IIf(txtPCPrc_Text = "", 0, txtPCPrc_Text)
        '            Call txtPCPrcLostFocus()
        '        Else
        '            txtPCPrc_Text = Format(0, "###,###,##0.0000")
        '        End If
        'End Select

        'If Microsoft.VisualBasic.Left(txtQutSts.Text, 1) = "H" Or Microsoft.VisualBasic.Left(txtQutSts.Text, 1) = "C" Or Microsoft.VisualBasic.Left(txtQutSts.Text, 1) = "E" Then
        '    chkPC.Enabled = False
        '    txtPCPrc.Enabled = False

        '    txtPCPrcCur.Enabled = False
        '    chkPC_hdr.Enabled = False
        'End If
    End Sub

    Private Function insert_QUOTNDTL() As Boolean
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
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cocde") = cboCoCde.Text
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutno") = txtQutNo.Text
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
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutdat") = "01/01/1900"
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
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cocde") = cboCoCde.Text
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutno") = txtQutNo.Text
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
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muminprc") = 0
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


    Private Function check_insert_QUOTNDTL() As Boolean
        If rs_QUOTNDTL.Tables("RESULT").Rows.Count = 0 Then
            check_insert_QUOTNDTL = True
        Else
            Dim loc As Integer
            loc = rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1

            If rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_untcde") = "" Then
                check_insert_QUOTNDTL = False
            Else
                check_insert_QUOTNDTL = True
            End If
        End If
    End Function

    Private Sub tpQUXLS001_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpQUXLS001_2.Click

    End Sub
    Private Sub resetDisplay(ByVal m As String)

        If m = cModeAdd Then

            lblQutNo.Visible = True
            txtQutNo.Visible = True
            lblQutNo.Enabled = True
            txtQutNo.Enabled = True


            lblCus1No.Visible = True
            lblCus2No.Visible = True
            cboCus1No.Visible = True
            cboCus2No.Visible = True
            lblCus1No.Enabled = True
            lblCus2No.Enabled = True
            cboCus1No.Enabled = True
            cboCus2No.Enabled = True
        ElseIf m = cModeUpd Then

            lblQutNo.Visible = True
            txtQutNo.Visible = True
            lblQutNo.Enabled = True
            txtQutNo.Enabled = True


            lblCus1No.Visible = False
            lblCus2No.Visible = False
            cboCus1No.Visible = False
            cboCus2No.Visible = False
            lblCus1No.Enabled = False
            lblCus2No.Enabled = False
            cboCus1No.Enabled = False
            cboCus2No.Enabled = False
        End If

    End Sub

    Private Sub chkQutUpd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkQutUpd.CheckedChanged
        If chkQutNew.Checked = False And chkQutUpd.Checked = False Then
            Cursor = Cursors.Default
            Exit Sub
        Else
            If chkQutNew.Checked = True And chkQutUpd.Checked = True Then
                MsgBox("Please Choose either New or Update Quotation.")
                chkQutNew.Checked = False
                chkQutUpd.Checked = False
                Call resetDisplay(cModeAdd)
                Exit Sub
            End If

            If chkQutNew.Checked = True And chkQutUpd.Checked = False Then
                Call resetDisplay(cModeAdd)
                Exit Sub
            End If

            If chkQutNew.Checked = False And chkQutUpd.Checked = True Then
                Call resetDisplay(cModeUpd)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub cboCus1No_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCus1No.SelectedIndexChanged
        Call cboCus1NoClick()  'for cus2 info
        Call cboCus1NoClick2() 'for other inf
        'Recordstatus = True
    End Sub

    Private Sub cboCus1NoClick()
        If cboCus1No.Text <> "" And Validate() = True Then
            cboCus2No.Items.Clear()
            cboCus2No.Text = ""


            If InStr(cboCus1No.Text, " - ") - 1 >= 0 Then
                dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "'")
            End If

            '*** Contact Person for Primary Customer
            '' Cursor = Cursors.WaitCursor
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            '1
            gspStr = "sp_list_CUCNTINF '','" & Replace(cboCus1No.Text, "'", "''") & "','C'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_C, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading QUM00001 sp_list_CUCNTINF_C :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If





            '*** Secondary Customer for Primary Customer
            '' Cursor = Cursors.WaitCursor

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Secondary'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 2 :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                cboCus2No.Enabled = False

            Else
                cboCus2No.Enabled = True
                cboCus2No.Items.Clear()
                cboCus2No.Text = ""


                dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= 60000")

                If Not dr Is Nothing Then
                    'possible bug ?
                    'If dr.Length > 1 Then
                    If dr.Length > 0 Then
                        For index As Integer = 0 To dr.Length - 1
                            cboCus2No.Items.Add(dr(index)("csc_seccus").ToString + " - " + dr(index)("cbi_cussna").ToString)
                        Next
                    End If
                End If
            End If



        End If
    End Sub
    Private Sub fillcboPriCust()

        Dim dr() As DataRow
        '        If addFlag = True Then
        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        'Else
        'dr = rs_CUBASINF_P.Tables("RESULT").Select("")
        'End If

        If dr.Length > 0 Then
            cboCus1No.Items.Clear()

            For i As Integer = 0 To dr.Length - 1
                cboCus1No.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If

    End Sub

    Private Sub fillParameter()

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & cboCoCde.Text & "','" & gsUsrID & "','" & sMODULE & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""


        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_CUBASINF_PC :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
            cboCus1No.Items.Clear()
            cboCus1No.Text = ""

            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")

            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        cboCus1No.Items.Add(dr(index)("cbi_cusno") + " - " + dr(index)("cbi_cussna"))
                    Next index
                End If
            End If
        Else
            MsgBox("There is no function, please contact EDP or System Administrator.")
            Cursor = Cursors.Default

            Exit Sub
        End If


    End Sub

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
            Cursor = Cursors.Default
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

        calCURounding = 4 'temporary hard code : used in Standard Price and Adjusted Price

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
        'resMinMarkupPrc = round(((calBasicPrice / (1 - resMinMarkupPer / 100)) / (1 - calCommPer / 100)) + calPckCstAmt + calCommAmt, calCURounding)
        Dim calMinMarkupPrc As Decimal
        calMinMarkupPrc = round(calBasicPrice / ((1 - resMinMarkupPer / 100)), 4)
        resMinMarkupPrc = round(round((calMinMarkupPrc + calPckCstAmt) / ((1 - calCommPer / 100)), 4) + round(calCommAmt, 4), calCURounding)

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


    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtFromApply.Text = ""
        txtToApply.Text = ""
    End Sub


    Private Sub cboCus1NoClick2()
        Dim sFilter As String


        If cboCus1No.Text <> "" And Validate() = True Then

            If InStr(cboCus1No.Text, " - ") - 1 >= 0 Then
                dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "'")
            End If

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
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            '1
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


            gspStr = "sp_list_CUCNTINF '','" & Replace(Split(cboCus1No.Text, "-")(0), "'", "''") & "','C'"
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
            gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Contact Person'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CP, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 1 :" & rtnStr)
                Cursor = Cursors.Default
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

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Secondary'"
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

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Agent'"
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
                    'txt_CusAgt_Text = dr(0)("cai_cusagt").ToString + " - " + dr(0)("yai_stnam").ToString

                    '''  20130909  data-leng
                    txt_CusAgt_Text = dr(0)("cai_cusagt").ToString
                End If
            End If

            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "'")





            ''''''''''''''''''''''''''''''2

            '*** Phase 2
            '*** Sales Division, Team, & Sales Rep. for Primary Customer
            '' Cursor = Cursors.WaitCursor

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_list_SYSALREL '" & cboCoCde.Text & "'"
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
                    ' sFilter = ""

                    ''If rs_SYSALREL.Tables("RESULT").DefaultView.Count > 0 Then

                    ''    txt_SalRep_Text = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_usrnam").ToString.Trim
                    ''    txt_Srname_Text = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_salrep").ToString.Trim

                    ''    'display_combo(rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_usrnam").ToString.Trim & " (" & _
                    ''    '                    rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_salrep").ToString.Trim & ")", cboSalRep)
                    ''End If



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

        If Trim(cboCus1No.Text) = "" Then
            cus1no = ""
        Else
            cus1no = Trim(Split(cboCus1No.Text, "-")(0))
        End If

        If Trim(cboCus2No.Text) = "" Then
            cus2no = ""
        Else
            cus2no = Trim(Split(cboCus2No.Text, "-")(0))
        End If


        If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_conftr").ToString = "" Then
            txtUMFtr_Text = "1"
        Else
            txtUMFtr_Text = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_conftr").ToString
        End If

        Try
            '' Cursor = Cursors.WaitCursor

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_ItemMaster_moq_moa_qu_wunttyp '" & cboCoCde.Text & "','" & _
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

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moq") = org_MOQ_tmp

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moqunttyp") = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("UNTTYP")), "0", rs_SYTIESTR.Tables("RESULT").Rows(0)("UNTTYP"))
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moflag") = org_MOFLAG_tmp
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoq") = org_MOQ_tmp
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoa") = org_MOA_tmp


            End If
        Catch ex As Exception

        End Try
    End Function


    Private Function save_QUCPTBKD(ByVal txt_itmno, ByVal txt_qutseq) As Boolean

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



        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMMATBKD '','" & txt_itmno & "'"
        'gspStr = "sp_select_QUCPTBKD '" & "" & "','" & txtQutNo.Text & "'"
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
            QCB_COCDE = cboCus1No.Text
            QCB_QUTNO = txtQutNo2.Text
            QCB_QUTSEQ = txt_qutseq
            QCB_ITMNO = txt_itmno
            QCB_CPTSEQ = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_matseq")
            QCB_CPT = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_mat")
            QCB_CURCDE = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_curcde")
            QCB_CST = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_cst")
            QCB_CSTPCT = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_cstper")
            QCB_PCT = "0"
            QCB_CREUSR = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_creusr")


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

        gsCompany = Trim(cboCoCde.Text)
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

            If chknomsg.Checked <> True Then
                MsgBox("Item cannot be quoted due to no Quotation Pricing formula!")
            End If

            Exit Function
        End If
    End Function

    Function cal_hk_mu() As Decimal


    End Function

    Private Function GetCusSty2(ByVal strItmNo As String, ByVal strCusno As String, ByVal index As Integer) As String
        '*** Show Customer Alias
        Dim rs As New DataSet

        ' Get Cust Style No. from CIH
        'S = "?CUITMSUM_Q?S?" & cus1no & "?" & _
        '    cus2no & "?" & _
        '    strItmNo & "?" & rs_ToBeCopy("qud_colcde").Value & "?" & rs_ToBeCopy("qud_untcde").Value & "?" & rs_ToBeCopy("qud_inrqty").Value & "?" & _
        '   rs_ToBeCopy("qud_mtrqty").Value & "?" & IIf(rs_ToBeCopy("qud_conftr").Value = "", 1, rs_ToBeCopy("qud_conftr").Value) & "?" & gsUsrID
        'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text.Trim)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUITMHIS_Q '" & cboCoCde.Text.Trim & "','" & _
                                            Trim(Split(cboCus1No.Text, "-")(0)) & "','" & _
                                            Trim(Split(cboCus2No.Text, "-")(0)) & "','" & _
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

            '' ''S = "?IMCUSSTY_QU?S?" & strItmNo & "?" & strCusno
            '' ''rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            ' ''Cursor = Cursors.WaitCursor

            ' ''gsCompany = Trim(copyQutCoCde)
            ' ''Call Update_gs_Value(gsCompany)

            ' ''gspStr = "sp_select_IMCUSSTY_QU '" & copyQutCoCde & "','" & strItmNo & "','" & strCusno & "'"
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




    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        rs_LIST_RESULT.Clear()

        If rs_LIST_RESULT.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_LIST_RESULT.Tables("RESULT").Rows.Count > 1 Then
            grdItem.DataSource = rs_LIST_RESULT.Tables("RESULT").DefaultView

        End If

        btcQUAPP001.SelectedIndex = 0
        btcQUAPP001.TabPages(0).Enabled = True
        btcQUAPP001.TabPages(1).Enabled = False
        cmdGen.Enabled = True

        ''
        txtQutNo.Text = temp_txtQutNo



    End Sub

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

        calCURounding = 4 'temporary hard code : used in Standard Price and Adjusted Price

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
            samplePrice = Format(round(calAdjustedPrice, 2), "###,###,##0.0000")
        Else
            samplePrice = Format(round(calAdjustedPrice / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value"), 2), "###,###,##0.0000")
        End If

        itmtyp = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmtyp")

        If itmtyp = "ASS" Then
            If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr")) Then
                umftr = 1
            Else
                umftr = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr")
            End If

            samplePrice = Format(round(calAdjustedPrice / umftr, 2), "###,###,##0.0000")
        End If

        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpprc") = samplePrice


    End Sub

    Private Sub cboCus1No_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus1No.KeyUp
        If cboCus1No.Text.Length > 0 Then
            Call auto_search_combo(cboCus1No, e.KeyCode)
        End If
    End Sub

    Private Sub cboCus1No_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCus1No.Validating
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboCus1No.Items.Count
        If cboCus1No.Text <> "" And cboCus1No.Enabled = True And cboCus1No.Items.Count > 0 Then
            For Y = 0 To i - 1
                If Trim(cboCus1No.Text) = Trim(cboCus1No.Items(Y)) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Primary Customer - Data is Invalid, please select in Drop Down List.")
                e.Cancel = True

                cboCus1No.Text = ""
                cboCus1No.Focus()
            End If
        End If
    End Sub

    Private Sub cboCus2No_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus2No.KeyUp
        If cboCus2No.Text.Length > 0 Then
            Call auto_search_combo(cboCus2No, e.KeyCode)
        End If
    End Sub

    Private Sub cboCus2No_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCus2No.Validating
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboCus2No.Items.Count
        If cboCus2No.Text <> "" And cboCus2No.Enabled = True And cboCus2No.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboCus2No.Text = cboCus2No.Items(Y).ToString Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Secondary Customer - Data is Invalid, please select in Drop Down List.")
                e.Cancel = True
                cboCus2No.Text = ""
                cboCus2No.Focus()
            End If
        End If
    End Sub



End Class