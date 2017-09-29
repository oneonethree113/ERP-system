Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class MSR00005
    'Option Explicit


    ''Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"

    '    Dim Rpt_SCR00002 As SCR00002Rpt
    '    Dim Rpt_SCR00002A As SCR00002RptA
    '    Dim Rpt_SCR00002B As SCR00002RptB

    Public rs_CUBASINF As DataSet
    Public rs_CUBASINF2 As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As DataSet
    Public rs_SYSALREP As DataSet
    Public rs_MSR00005 As DataSet
    Public rs_EXCEL As DataSet
    Dim count_msg As Integer

    Public Enum enuPO
        cocde_enu = 0
        opt1Fm_enu = 1
        opt1To_enu = 2
        opt2Fm_enu = 3
        opt2To_enu = 4
        opt3Fm_enu = 5
        opt3To_enu = 6
        seccnf_enu = 7
        seccnt_enu = 8
        opt4Fm_enu = 9
        opt4To_enu = 10
        opt5Fm_enu = 11
        opt5To_enu = 12
        opt6Fm_enu = 13
        opt6To_enu = 14
        opt7Fm_enu = 15
        opt7To_enu = 16
        optPrintPO_enu = 17
        poh_purord_enu = 18
        pod_jobord_enu = 19
        pod_cusitm_enu = 20
        pod_venitm_enu = 21
        pod_engdsc_enu = 22
        sod_subcde_enu = 23
        pod_ordqty_enu = 24
        pod_untcde_enu = 25
        pod_itmno_enu = 26
        sod_colcde_enu = 27
        pod_balqty_enu = 28
        pod_balctn_enu = 29
        pod_shpstr_enu = 30
        pod_shpend_enu = 31
        Qty_enu = 32
        poh_venno_enu = 33
        pod_cuspno_enu = 34
        cbi_cussna_enu = 35
        secCustSNa_enu = 36
        opt8Fm_enu = 37
        opt8To_enu = 38
        opt9Fm_enu = 39
        opt9To_enu = 40
        Sort_enu = 41
        pod_balcbm_enu = 42
        compName = 43
    End Enum


    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        '    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'XXXXXXXXXXXXXXXXXXXXX
        ' 2004/02/11 Lester Wu
        'Lester Wu 2005-03-21 Replace "ALL" with "UC-G"
        If Me.cboCocde.Text <> "UC-G" Then
            'If Me.cboCoCde.Text <> "ALL" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
        'XXXXXXXXXXXXXXXXXXXXX
    End Sub

    Private Sub cboCust2From_Click()
    End Sub

    Private Sub cboCust2From_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        '    ''Call AutoSearch(Me.cboCust2From, KeyCode)
    End Sub

    Private Sub cboCust2From_LostFocus()
        If ValidateCombo(Me.cboCust2From) = True Then
            Me.cboCust2To.Text = Me.cboCust2From.Text
        End If
    End Sub

    Private Sub cboCust2To_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(Me.cboCust2To, KeyCode)
    End Sub

    Private Sub cboCust2To_LostFocus()
        Call ValidateCombo(Me.cboCust2To)
    End Sub

    Private Sub cboCustFrom_Change()
        'cboCustTo.Text = cboCustFrom.Text
    End Sub

    Private Sub cboCustFrom_Click()
        cboCustTo.Text = cboCustFrom.Text
    End Sub

    Private Sub cboCustFrom_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(cboCustFrom, KeyCode)
        '''Call AutoSearch(cboCustTo, KeyCode)
    End Sub

    Private Sub cboCustFrom_LostFocus()
        If ValidateCombo(cboCustFrom) = True Then
            Me.cboCustTo.Text = Me.cboCustFrom.Text
        End If
    End Sub
    Private Sub cboCustTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(cboCustTo, KeyCode)
    End Sub
    'Private Sub cboCustTo_LostFocus()
    '    Call ValidateCombo(cboCustTo)
    'End Sub
    Private Sub cboSTFm_Click()
        cboSTTo.Text = cboSTFm.Text
    End Sub
    Private Sub cboSTFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(cboSTFm, KeyCode)
        'cboSTTo.Text = cboSTFm.Text
    End Sub
    Private Sub cboSTFm_LostFocus()
        If ValidateCombo(cboSTFm) = True Then
            Me.cboSTTo.Text = Me.cboSTFm.Text
        End If
    End Sub
    'Private Sub cboSTo_LostFocus()
    '    Call ValidateCombo(cboSTTo)
    'End Sub

    Private Sub cboSTTo_LostFocus()
        Call ValidateCombo(Me.cboSTTo)
    End Sub

    Private Sub cboSubCdeFrom_Change()
        'cboSubCdeTo.Text = cboSubCdeFrom.Text
    End Sub

    Private Sub cboSubCdeFrom_Click()
        cboSubCdeTo.Text = cboSubCdeFrom.Text
    End Sub

    Private Sub cboSubCdeFrom_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(cboSubCdeFrom, KeyCode)
        '''Call AutoSearch(cboSubCdeTo, KeyCode)
    End Sub

    Private Sub cboSubCdeFrom_LostFocus()
        If ValidateCombo(cboSubCdeFrom) = True Then
            Me.cboSubCdeTo.Text = Me.cboSubCdeFrom.Text
        End If
    End Sub


    Private Sub cboSubCdeTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(cboSubCdeTo, KeyCode)
    End Sub

    'Private Sub cboSubCdeTo_LostFocus()
    '    Call ValidateCombo(cboSubCdeTo)
    'End Sub

    Private Sub cboVenFrom_Change()
        'cboVenTo.Text = cboVenFrom.Text

    End Sub

    Private Sub cboVenFrom_Click()
        cboVenTo.Text = cboVenFrom.Text
    End Sub

    Private Sub cmdShow_Click()
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------




        Dim ReportName As String
        Dim ReportRS As Dataset
        Dim SubCdeFrom As String
        Dim SubCdeTo As String
        Dim CustFrom As String
        Dim CustTo As String
        ' 2004/02/11 Lester Wu
        Dim Cust2From As String
        Dim Cust2To As String
        ' --------------------
        Dim VenFrom As String
        Dim VenTo As String
        Dim SORTBY As String

        Call ValidateCombo(cboVenFrom)
        Call ValidateCombo(cboVenTo)
        Call ValidateCombo(cboCustFrom)
        Call ValidateCombo(cboCustTo)
        ' 2004/02/11 Lester
        Call ValidateCombo(cboCust2From)
        Call ValidateCombo(cboCust2To)
        '-------------------
        Call ValidateCombo(cboSubCdeFrom)
        Call ValidateCombo(cboSubCdeTo)

        'txtPONoFrom.Text = UCase(txtPONoFrom.Text)
        'txtPONoTo.Text = UCase(txtPONoTo.Text)
        'txtCusPoFrom.Text = UCase(txtCusPoFrom.Text)
        'txtCusPoTo.Text = UCase(txtCusPoTo.Text)
        'txtItemNoFrom.Text = UCase(txtItemNoFrom.Text)
        'txtItemNoTo.Text = UCase(txtItemNoTo.Text)

        If cboSubCdeFrom.Text = "" And cboSubCdeTo.Text <> "" Then
            cboSubCdeFrom.Text = cboSubCdeTo.Text
        End If
        If cboSubCdeTo.Text = "" And cboSubCdeFrom.Text <> "" Then
            cboSubCdeTo.Text = cboSubCdeFrom.Text
        End If

        If cboCustFrom.Text = "" And cboCustTo.Text <> "" Then
            cboCustFrom.Text = cboCustTo.Text
        End If
        If cboCustTo.Text = "" And cboCustFrom.Text <> "" Then
            cboCustTo.Text = cboCustFrom.Text
        End If
        ' 2004/02/11 Lester Wu
        If cboCust2From.Text = "" And cboCust2To.Text <> "" Then
            cboCust2From.Text = cboCust2To.Text
        End If
        If cboCust2To.Text = "" And cboCust2From.Text <> "" Then
            cboCust2To.Text = cboCust2From.Text
        End If
        ' --------------------
        If cboSTTo.Text = "" And cboSTFm.Text <> "" Then
            cboSTTo.Text = cboSTFm.Text
        End If
        If cboVenFrom.Text = "" And cboVenTo.Text <> "" Then
            cboVenFrom.Text = cboVenTo.Text
        End If
        If cboVenTo.Text = "" And cboVenFrom.Text <> "" Then
            cboVenTo.Text = cboVenFrom.Text
        End If

        'If txtDateFrom.Text = "  /  /" And txtDateTo.Text <> "  /  /" Then
        'txtDateFrom.Text = "01/01/1900"
        'End If
        'If txtDateTo.Text = "  /  /" And txtDateFrom.Text <> "  /  /" Then
        'txtDateTo.Text = "01/01/1900"
        'End If

        CustFrom = cboCustFrom.Text
        CustTo = cboCustTo.Text

        If Len(Trim(CustFrom)) > 0 Then
            CustFrom = Split(cboCustFrom.Text, " - ")(0)
        Else
            CustFrom = ""
        End If

        If Len(Trim(CustTo)) > 0 Then
            CustTo = Split(cboCustTo.Text, " - ")(0)
        Else
            CustTo = ""
        End If
        ' 2004/02/11 Lester Wu
        Cust2From = cboCust2From.Text
        Cust2To = cboCust2To.Text

        If Len(Trim(Cust2From)) > 0 Then
            Cust2From = Split(cboCust2From.Text, " - ")(0)
        Else
            Cust2From = ""
        End If

        If Len(Trim(Cust2To)) > 0 Then
            Cust2To = Split(cboCust2To.Text, " - ")(0)
        Else
            Cust2To = ""
        End If
        ' --------------------
        VenFrom = cboVenFrom.Text
        VenTo = cboVenTo.Text

        If Len(Trim(VenFrom)) > 0 Then
            VenFrom = Split(cboVenFrom.Text, " - ")(0)
        Else
            VenFrom = ""
        End If

        If Len(Trim(VenTo)) > 0 Then
            VenTo = Split(cboVenTo.Text, " - ")(0)
        Else
            VenTo = ""
        End If

        SubCdeFrom = cboSubCdeFrom.Text
        SubCdeTo = cboSubCdeTo.Text

        If Len(Trim(SubCdeFrom)) > 0 Then
            SubCdeFrom = Split(cboSubCdeFrom.Text, " - ")(0)
        Else
            SubCdeFrom = ""
        End If

        If Len(Trim(SubCdeTo)) > 0 Then
            SubCdeTo = Split(cboSubCdeTo.Text, " - ")(0)
        Else
            SubCdeTo = ""
        End If

        If optCustSNa.Checked = True Then
            SORTBY = "P"
        ElseIf optCusPO.Checked = True Then
            SORTBY = "C"
        ElseIf optVenItm.Checked = True Then
            SORTBY = "V"
        ElseIf optShpDat.Checked = True Then
            SORTBY = "S"
        End If

        If Not InputIsVaild() Then
            Exit Sub
        End If

        Dim S As String
        Dim rs As DataSet
        Cursor = Cursors.WaitCursor

        If cboCocde.Text.Trim = "" Then
            MsgBox("Please select company coec!")
            Exit Sub
            cboCocde.Focus()

        End If

        '    S = "sp_select_MSR00005','S','" & SubCdeFrom & _
        '        "','" & SubCdeTo & _
        '        "','" & VenFrom & _
        '        "','" & VenTo & _
        '        "','" & CustFrom & _
        '        "','" & CustTo & _
        '        "','" & UCase(txtCusPoFrom.Text) & _
        '        "','" & UCase(txtCusPoTo.Text) & _
        '        "','" & UCase(txtCPOsc.Text) & _
        '        "','" & UCase(txtSCFm.Text) & _
        '        "','" & UCase(txtSCTo.Text) & _
        '        "','" & UCase(cboSTFm.Text) & _
        '        "','" & UCase(cboSTTo.Text) & _
        '        "','" & UCase(txtItemNoFrom.Text) & _
        '        "','" & UCase(txtItemNoTo.Text) & _
        '        "','" & IIf(txtDateFrom.Text = "  /  /" And txtDateTo.Text = "  /  /", "", Format(txtDateFrom.Text, "MM/dd/yyyy")) & _
        '        "','" & IIf(txtDateFrom.Text = "  /  /" And txtDateTo.Text = "  /  /", "", Format(txtDateTo.Text, "MM/dd/yyyy")) & _
        '        "','" & UCase(txtPONoFrom.Text) & _
        '        "','" & UCase(txtPONoTo.Text) & _
        '        "','" & IIf(optPrintPOY.checked = True, "Y", "N") & _
        '        "','" & SortBy & _
        '        "','" & gsUsrID & "'"

        Dim from_date As String
        Dim to_date As String
        If (txtDateFrom.Text = "  /  /" And txtDateTo.Text = "  /  /") Then
            from_date = ""
        Else
            from_date = Format(CDate(txtDateFrom.Text.Trim), "MM/dd/yyyy")
        End If

        If (txtDateFrom.Text = "  /  /" And txtDateTo.Text = "  /  /") Then
            to_date = ""
        Else
            to_date = Format(CDate(txtDateTo.Text.Trim), "MM/dd/yyyy")
        End If

        S = "sp_select_MSR00005 '" & cboCocde.Text.Trim & "','" & SubCdeFrom & _
                "','" & SubCdeTo & _
                "','" & VenFrom & _
                "','" & VenTo & _
                "','" & CustFrom & _
                "','" & CustTo & _
                "','" & Cust2From & _
                "','" & Cust2To & _
                "','" & UCase(txtCusPoFrom.Text) & _
                "','" & UCase(txtCusPoTo.Text) & _
                "','" & UCase(txtCPOsc.Text) & _
                "','" & UCase(txtSCFm.Text) & _
                "','" & UCase(txtSCTo.Text) & _
                "','" & UCase(cboSTFm.Text) & _
                "','" & UCase(cboSTTo.Text) & _
                "','" & UCase(txtItemNoFrom.Text) & _
                "','" & UCase(txtItemNoTo.Text) & _
                "','" & from_date & _
                "','" & to_date & _
                "','" & UCase(txtPONoFrom.Text) & _
                "','" & UCase(txtPONoTo.Text) & _
                "','" & IIf(optPrintPOY.Checked = True, "Y", "N") & _
                "','" & SORTBY & _
                "','" & gsUsrID & "','" & "_" & gsSalTem & "'"
        'Relocation to report server
        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_MSR00005, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        End If

        If rs_MSR00005.Tables("RESULT").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("No Record Found!")
            Exit Sub
        Else
            If Me.optExcelN.Checked = True Then

                Dim objRpt As New MSR00005rpt
                objRpt.SetDataSource(rs_MSR00005.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

            Else
                rs_EXCEL = rs_MSR00005.Copy
                Call CmdExportExcel_Click()
            End If
        End If

        Cursor = Cursors.Default
    End Sub
    Private Function InputIsVaild() As Boolean

        If txtPONoTo.Text < txtPONoFrom.Text Then
            MsgBox("PO No. To must <= PO No. From")
            InputIsVaild = False
            txtPONoTo.Focus()
            Exit Function
        End If
        If txtCusPoTo.Text < txtCusPoFrom.Text Then
            MsgBox("Customer PO To must <= Customer PO From")
            InputIsVaild = False
            txtCusPoTo.Focus()
            Exit Function
        End If
        If txtSCTo.Text < txtSCFm.Text Then
            MsgBox("SC No. To must <= SC No. From")
            InputIsVaild = False
            txtSCTo.Focus()
            Exit Function
        End If
        If txtDateFrom.Text <> "  /  /" And txtDateTo.Text <> "  /  /" Then
            If CDate(txtDateFrom.Text) > CDate(Me.txtDateTo.Text) Then
                MsgBox("Start Date > End Date")
                InputIsVaild = False
                txtDateFrom.Focus()
                Exit Function
            End If
        End If
        If txtItemNoTo.Text < txtItemNoFrom.Text Then
            MsgBox("Item No. To must <= Item No. From")
            InputIsVaild = False
            txtItemNoTo.Focus()
            Exit Function
        End If
        InputIsVaild = True
    End Function


    Private Sub Form_Load()
        '#If useMTS Then
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        Cursor = Cursors.WaitCursor
        '*************Default****************
        '*** Multi-Company Name Display.
        Call FillCompCombo(gsUsrID, cboCocde)
        '        Call FillCompCombo(gsUsrID, cbococde)
        '*** ADD PRINT ALL COMPANY ***
        ' 2004/02/11
        'Lester Wu 2005-03-21 Replace "ALL" with "UC-G"
        'Me.cboCoCde.Items.add "ALL"
        If gsDefaultCompany <> "MS" Then
            Me.cboCocde.Items.Add("UC-G")
        End If
        '*****************************
        Call GetDefaultCompany(Me.cboCocde, Me.txtCoNam)

        Call Formstartup(Me.Name)

        'txtDateFrom = Format(Date.Today, "MM/dd/yyyy").ToString
        'txtDateTo = Format(Date.Today, "MM/dd/yyyy").ToString

        Dim S As String
        Dim rs As DataSet

        Cursor = Cursors.WaitCursor

        S = "sp_list_CUBASINF '','PA'"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            Call FillcboCust()
        End If


        S = "sp_list_CUBASINF  '','P'"
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF2, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            Call FillcboCust2()
        End If


        S = "sp_list_VNBASINF ''"
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            Call FillcboVen()
        End If


        S = "sp_select_SUBCDE ''"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            Call FillcboSubCde()
        End If


        S = "sp_list_SYSALREP_MSR00013 ''"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            Call FillcboST()
        End If

        '    If gsCompany = "UCPP" Then
        optPrintPOY.Checked = True
        '    End If


        Cursor = Cursors.Default
    End Sub

    Private Sub FillcboCust()
        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_CUBASINF.Tables("RESULT").Rows.Count - 1
                cboCustFrom.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                cboCustTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
            Next
        End If
    End Sub

    Private Sub FillcboCust2()
        If rs_CUBASINF2.Tables("RESULT").Rows.Count > 0 Then

            For index As Integer = 0 To rs_CUBASINF2.Tables("RESULT").Rows.Count - 1
                cboCust2From.Items.Add(rs_CUBASINF2.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF2.Tables("RESULT").Rows(index)("cbi_cussna"))
                cboCust2To.Items.Add(rs_CUBASINF2.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF2.Tables("RESULT").Rows(index)("cbi_cussna"))
            Next

        End If
    End Sub


    Private Sub txtCusPoFrom_Change()
        txtCusPoTo.Text = txtCusPoFrom.Text
    End Sub

    Private Sub txtDateFrom_Change()
        txtDateTo.Text = txtDateFrom.Text
    End Sub

    Private Sub txtDateFrom_GotFocus()
        Call HighlightMask(txtDateFrom)
    End Sub

    Private Sub txtDateFrom_LostFocus()
        If Trim(txtDateFrom.Text) <> "  /  /" Then
            If Not IsDate(txtDateFrom.Text) Then
                MsgBox(" ")
                txtDateFrom.Focus()
            End If
        End If
    End Sub
    Private Sub txtDateTo_GotFocus()
        Call HighlightMask(txtDateTo)
    End Sub

    Private Sub txtDateTo_LostFocus()
        If Trim(txtDateTo.Text) = "" Then
            txtDateTo.Text = "  /  /"
        End If

        If txtDateTo.Text <> "  /  /" Then
            If IsDate(txtDateFrom.Text) Then
                If Not IsDate(txtDateTo.Text) Then
                    MsgBox("Date is Invalid !")
                    txtDateTo.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenFrom.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
            Next
        End If
    End Sub

    Private Sub cboVenFrom_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(cboVenFrom, KeyCode)
        '''Call AutoSearch(cboVenTo, KeyCode)
    End Sub

    Private Sub cboVenFrom_LostFocus()
        If ValidateCombo(cboVenFrom) = True Then
            Me.cboVenTo.Text = Me.cboVenFrom.Text
        End If
    End Sub

    Private Sub cboVenTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(cboVenTo, KeyCode)
    End Sub

    Private Sub cboVenTo_LostFocus()
        Call ValidateCombo(cboVenTo)
    End Sub
    Private Sub txtItemNoFrom_Change()
        txtItemNoTo.Text = txtItemNoFrom.Text
    End Sub

    Private Sub txtPONoFrom_Change()
        txtPONoTo.Text = txtPONoFrom.Text
    End Sub

    Private Sub FillcboSubCde()
        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_SYSETINF.Tables("RESULT").Rows.Count - 1
                cboSubCdeFrom.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                cboSubCdeTo.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
            Next

        End If
    End Sub
    Private Sub FillcboST()
        If rs_SYSALREP.Tables("RESULT").Rows.Count > 0 Then

            For index As Integer = 0 To rs_SYSALREP.Tables("RESULT").Rows.Count - 1
                cboSTFm.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(index)("ysr_saltem"))
                cboSTTo.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(index)("ysr_saltem"))
            Next

        End If
    End Sub

    Private Sub txtSCfm_Change()
        txtSCTo.Text = txtSCFm.Text
    End Sub


    Private Function CmdExportExcel_Click()

        On Error GoTo Err_Handler

        Cursor = Cursors.WaitCursor ' Change mouse pointer to hourglass.
        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        Dim recArray As Object

        Dim fldCount As Long
        Dim recCount As Long
        Dim iCol As Integer
        Dim iRow As Integer

        'xxxxxxxxxxx
        Dim contRow As Long
        Dim HdrRow As Long
        Dim DtlRow As Long


        Dim HdrCol As Long
        Dim DtlCol As Long
        Dim i As Long
        Dim indexCol As Long
        Dim intGroup As Long
        Dim strGroup As String
        Dim tmpGroup As String
        Dim dblOS_Amt As Double
        Dim lngOS_Ctn As Long
        Dim strCurr As String
        Dim bolFtyPrice As Boolean
        Dim bolPO As Boolean
        Dim strCompany As String
        Dim strTitle As String
        Dim dblOS_CBM As Double

        dblOS_CBM = 0
        strCurr = ""
        dblOS_Amt = 0
        lngOS_Ctn = 0
        intGroup = 0
        indexCol = 1
        HdrRow = 8
        DtlRow = 10
        'xxxxxxxxxxx


        'Create an instance of Excel and add a workbook
        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        'Display Excel and give user control of Excel's lifetime
        xlApp.Visible = True
        xlApp.UserControl = True
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


        '.Range(.Cells(HdrRow + 1, indexCol), .Cells(DtlRow + 2 * recCount + 1, indexCol + 17)).Font.Size = 10


        bolPO = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.optPrintPO_enu) = "Y", True, False)

        '==========================================================
        'xxxxxxxxxxxxxxxxxxxxx< Title Start >xxxxxxxxxxxxxxxxxxxxxx
        strCompany = ""
        strTitle = "OUTSTANDING ORDER REPORT PURCHASE ORDER"

        'if {MSR00004_ttx.@poh_cocde} = "UCPP" then
        '
        'else if {MSR00004_ttx.@poh_cocde} = "UCP" then
        '
        'else if {MSR00004_ttx.@poh_cocde} = "PG" then
        '
        'else if {MSR00004_ttx.@poh_cocde} = "ALL" then
        '


        'Select Case rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.cocde_enu)
        '    Case "UCP"
        '            strCompany = "UCP INTERNATIONAL CO., LTD."
        '    Case "UCPP"
        '            strCompany = "UNITED CHINESE PLASTICS PRODUCTS CO., LTD."
        '    Case "PG"
        '            strCompany = "Pacific Global Enterprises Limited"
        '    Case "ALL"
        '            strCompany = "UNITED CHINESE GROUP"
        'End Select


        strCompany = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.compName)

        Dim colRptID As Integer

        'colRptID = 16   'set starting column of report id
        colRptID = 15   'set starting column of report id

        With xlWs

            'Report ID
            .Cells(1, colRptID) = "Report ID"
            .Cells(1, colRptID + 1) = ":"
            .Cells(1, colRptID + 2) = "MSR00005"

            'Date
            .Cells(2, colRptID) = "Date"
            .Cells(2, colRptID + 1) = ":"
            .Cells(2, colRptID + 2) = Format(Now, "MM/dd/yyyy")
            .Range(.Cells(2, colRptID + 2), .Cells(2, colRptID + 2)).NumberFormatLocal = "MM/dd/yyyy"
            'Time
            .Cells(3, colRptID) = "Time"
            .Cells(3, colRptID + 1) = ":"
            .Cells(3, colRptID + 2) = Format(Now, "HH:mm:ss")
            .Range(.Cells(3, colRptID + 2), .Cells(3, colRptID + 2)).NumberFormatLocal = "HH:mm:ss"
            'Page
            .Cells(4, colRptID) = "Page"
            .Cells(4, colRptID + 1) = ":"
            .Cells(4, colRptID + 2) = "1 of 1"

            'Input Parameter
            'vendor
            .Cells(4, 1) = "Vendor"
            .Cells(4, 2) = ":"
            .Cells(4, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt2Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt2To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt2Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt2To_enu))
            'subcode
            .Cells(5, 1) = "Sub Code"
            .Cells(5, 2) = ":"
            .Cells(5, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt1Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt1To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt1Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt1To_enu))

            'PO NO
            .Cells(6, 1) = "PO NO."
            .Cells(6, 2) = ":"
            .Cells(6, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt7Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt7To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt7Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt7To_enu))

            'Pri. Cust NO
            .Cells(4, 6) = "Pri. Cust No."
            .Cells(4, 7) = ":"
            .Cells(4, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt3Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt3To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt3Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt3To_enu))


            'Sec. Cust No
            .Cells(5, 6) = "Sec. Cust No"
            .Cells(5, 7) = ":"
            .Cells(5, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.seccnf_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.seccnt_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.seccnf_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.seccnt_enu))

            'SC No
            .Cells(6, 6) = "SC No"
            .Cells(6, 7) = ":"
            .Cells(6, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt8Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt8To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt8Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt8To_enu))

            'Sales Team
            .Cells(7, 6) = "Sales Team"
            .Cells(7, 7) = ":"
            .Cells(7, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt9Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt9To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt9Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt9To_enu))


            'Cust PO
            .Cells(4, 11) = "Cust PO"
            .Cells(4, 12) = ":"
            .Cells(4, 13) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt4Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt4To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt4To_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt4To_enu))


            'Item No
            .Cells(5, 11) = "Item No"
            .Cells(5, 12) = ":"
            .Cells(5, 13) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt5Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt5To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt5Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt5To_enu))


            'Ship Date
            .Cells(6, 11) = "Ship Date"
            .Cells(6, 12) = ":"
            .Cells(6, 13) = IIf(Microsoft.VisualBasic.Left(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt6Fm_enu), 10) = "01/01/1900" And Microsoft.VisualBasic.Left(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt6To_enu), 10) = "01/01/1900", "--/--/---- - --/--/----", rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt6Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.opt6To_enu))





            'Show PO#
            .Cells(7, 11) = "Sort By "
            .Cells(7, 12) = ":"
            Select Case rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.Sort_enu)
                Case "P"
                    .Cells(7, 13) = "Customer Short Name"
                Case "C"
                    .Cells(7, 13) = "Customer PO #"
                Case "V"
                    .Cells(7, 13) = "Vendor Item #"
                Case Else
                    .Cells(7, 13) = "Ship Date"
            End Select




            'defalut aligment
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 18)).HorizontalAlignment = 2
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 18)).Font.Size = 10

            'Lester Wu 20040626
            '    'COmpany
            '    .Range(.Cells(1, 5), .Cells(1, 13)).Merge
            '    .Range(.Cells(1, 5), .Cells(1, 13)).value = strCompany
            '    .Range(.Cells(1, 5), .Cells(1, 13)).RowHeight = 25
            '    .Range(.Cells(1, 5), .Cells(1, 13)).Font.Size = 12
            '    .Range(.Cells(1, 5), .Cells(1, 13)).Font.Bold = True
            '    .Range(.Cells(1, 5), .Cells(1, 13)).HorizontalAlignment = 3
            '    'Report Title
            '    .Range(.Cells(2, 5), .Cells(2, 13)).Merge
            '    .Range(.Cells(2, 5), .Cells(2, 13)).value = strTitle
            '    .Range(.Cells(2, 5), .Cells(2, 13)).Font.Size = 10
            '    .Range(.Cells(2, 5), .Cells(2, 13)).HorizontalAlignment = 3

            'COmpany
            .Range(.Cells(1, 5), .Cells(1, 13)).Merge()
            .Range(.Cells(1, 5), .Cells(1, 13)).Value = strCompany
            .Range(.Cells(1, 5), .Cells(1, 13)).RowHeight = 25
            .Range(.Cells(1, 5), .Cells(1, 13)).Font.Size = 12
            .Range(.Cells(1, 5), .Cells(1, 13)).Font.Bold = True
            .Range(.Cells(1, 5), .Cells(1, 13)).HorizontalAlignment = 3
            'Report Title
            .Range(.Cells(2, 5), .Cells(2, 13)).Merge()
            .Range(.Cells(2, 5), .Cells(2, 13)).Value = strTitle
            .Range(.Cells(2, 5), .Cells(2, 13)).Font.Size = 10
            .Range(.Cells(2, 5), .Cells(2, 13)).HorizontalAlignment = 3

        End With
        'xxxxxxxxxxxxxxxxxxxxx< Title End >xxxxxxxxxxxxxxxxxxxxxxxx
        '...............


        '==========================================================
        'xxxxxxxxxxxxxxxxxxxx< Row Header Start>xxxxxxxxxxxxxxxxxxxx
        With xlWs

            .Cells(HdrRow + 1, indexCol) = IIf(bolPO, "PO#", "")
            .Cells(HdrRow + 2, indexCol) = "Job No."

            'Lester Wu 20040626
            '.Cells(HdrRow + 1, indexCol + 2) = "Pri. Cust. Short Name"
            '.Cells(HdrRow + 2, indexCol + 2) = "Cust PO#"
            '.Cells(HdrRow + 1, indexCol + 4) = "Sec. Cust Short Name"
            '.Cells(HdrRow + 1, indexCol + 6) = "Cust. Item No."

            .Cells(HdrRow + 1, indexCol + 2) = "Pri. Cust. Short Name"
            .Cells(HdrRow + 2, indexCol + 2) = "Sec. Cust Short Name"
            .Cells(HdrRow + 1, indexCol + 4) = "Cust PO#"
            .Cells(HdrRow + 2, indexCol + 4) = "Cust. Item No."



            'Lester Wu 20040626
            '.Cells(HdrRow + 1, indexCol + 8) = "Vendor Item No."
            '.Cells(HdrRow + 2, indexCol + 8) = "Our Item No."
            '.Cells(HdrRow + 1, indexCol + 10) = "Color Code"
            '.Cells(HdrRow + 1, indexCol + 11) = "Description"

            .Cells(HdrRow + 1, indexCol + 6) = "Vendor Item No."
            .Cells(HdrRow + 2, indexCol + 6) = "Our Item No."
            .Cells(HdrRow + 1, indexCol + 8) = "Color Code"
            .Cells(HdrRow + 1, indexCol + 9) = "Description"



            'Lester Wu 2004/06/13
            '.Cells(HdrRow + 1, indexCol + 14) = "Order Qty"
            '.Cells(HdrRow + 1, indexCol + 15) = ""
            '.Cells(HdrRow + 1, indexCol + 16) = "O/S Qty"
            '.Cells(HdrRow + 1, indexCol + 17) = "O/S Carton"

            'Lester Wu 20040626
            '.Cells(HdrRow + 1, indexCol + 13) = "Order Qty"
            '.Cells(HdrRow + 1, indexCol + 14) = ""
            '.Cells(HdrRow + 1, indexCol + 15) = "O/S Qty"
            '.Cells(HdrRow + 1, indexCol + 16) = "O/S Carton"
            '.Cells(HdrRow + 1, indexCol + 17) = "O/S CBM"
            '.Cells(HdrRow + 1, indexCol + 18) = "Ship"
            '.Cells(HdrRow + 2, indexCol + 18) = "Start Date"

            .Cells(HdrRow + 1, indexCol + 11) = "Order Qty"
            .Cells(HdrRow + 1, indexCol + 12) = ""
            .Cells(HdrRow + 1, indexCol + 13) = "O/S Qty"
            .Cells(HdrRow + 1, indexCol + 14) = "O/S Carton"
            .Cells(HdrRow + 1, indexCol + 15) = "O/S CBM"
            .Cells(HdrRow + 1, indexCol + 16) = "Ship"
            .Cells(HdrRow + 2, indexCol + 16) = "Start Date"

            '--------------------

            '--------------------
            'Lester Wu 2004/06/23
            '.Range(.Cells(HdrRow + 1, indexCol + 14), .Cells(HdrRow + 1, indexCol + 14)).HorizontalAlignment = 4 '"Order Qty"
            '.Range(.Cells(HdrRow + 1, indexCol + 16), .Cells(HdrRow + 1, indexCol + 16)).HorizontalAlignment = 4 '"O/S Qty"
            '.Range(.Cells(HdrRow + 1, indexCol + 17), .Cells(HdrRow + 1, indexCol + 17)).HorizontalAlignment = 4 '"O/S Carton"
            'Lester Wu 20040626
            '.Range(.Cells(HdrRow + 1, indexCol + 13), .Cells(HdrRow + 1, indexCol + 13)).HorizontalAlignment = 4 '"Order Qty"
            '.Range(.Cells(HdrRow + 1, indexCol + 15), .Cells(HdrRow + 1, indexCol + 15)).HorizontalAlignment = 4 '"O/S Qty"
            '.Range(.Cells(HdrRow + 1, indexCol + 16), .Cells(HdrRow + 1, indexCol + 16)).HorizontalAlignment = 4 '"O/S Carton"
            '.Range(.Cells(HdrRow + 1, indexCol + 17), .Cells(HdrRow + 1, indexCol + 17)).HorizontalAlignment = 4 '"O/S CBM"
            .Range(.Cells(HdrRow + 1, indexCol + 11), .Cells(HdrRow + 1, indexCol + 11)).HorizontalAlignment = 4 '"Order Qty"
            .Range(.Cells(HdrRow + 1, indexCol + 13), .Cells(HdrRow + 1, indexCol + 13)).HorizontalAlignment = 4 '"O/S Qty"
            .Range(.Cells(HdrRow + 1, indexCol + 14), .Cells(HdrRow + 1, indexCol + 14)).HorizontalAlignment = 4 '"O/S Carton"
            .Range(.Cells(HdrRow + 1, indexCol + 15), .Cells(HdrRow + 1, indexCol + 15)).HorizontalAlignment = 4 '"O/S CBM"
            'Lester Wu 20040626
            '.Range(.Cells(HdrRow + 1, indexCol + 18), .Cells(HdrRow + 2, indexCol + 18)).HorizontalAlignment = 4 '"Ship Start Date"
            .Range(.Cells(HdrRow + 1, indexCol + 16), .Cells(HdrRow + 2, indexCol + 16)).HorizontalAlignment = 4 '"Ship Start Date"

            '---------------------
        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Header End >xxxxxxxxxxxxxxxxxxxxxx
        '...............


        'xxxxxxxxxxxxxxxxxxxx< Row Detail Start >xxxxxxxxxxxxxxxxxxxxxx
        '...............
        recCount = rs_EXCEL.Tables("RESULT").Rows.Count - 1
        With xlWs
            .Range("E:E").NumberFormat = "@"

            strGroup = ""
            tmpGroup = ""
            For i = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                'For i = 0 To recCount

                tmpGroup = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.poh_venno_enu)

                If strGroup <> tmpGroup Then
                    'Show Total Field
                    '........................
                    If strGroup <> "" Then
                        '        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = "Total :"
                        '        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = lngOS_Ctn    'Total O/S Ctn
                        '        .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17)).Font.Bold = True
                        'Lester Wu 20040626
                        '        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = "Total :"
                        '        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = lngOS_Ctn    'Total O/S Ctn
                        '        .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16)).Font.Bold = True
                        '        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = dblOS_CBM    'Total O/S CBM
                        '        .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17)).NumberFormatLocal = "#,##0.0000_ "
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13) = "Total :"
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 14) = lngOS_Ctn    'Total O/S Ctn
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = dblOS_CBM    'Total O/S CBM
                        .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15)).NumberFormatLocal = "#,##0.0000_ "
                        .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15)).Font.Bold = True

                        dblOS_CBM = 0
                        lngOS_Ctn = 0
                        intGroup = intGroup + 1
                    End If
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    strGroup = tmpGroup
                    .Cells(intGroup + DtlRow + 2 * i + 2, indexCol) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.poh_venno_enu)
                    .Range(.Cells(intGroup + DtlRow + 2 * i + 2, indexCol), .Cells(intGroup + DtlRow + 2 * i + 2, indexCol)).Font.Bold = True
                    intGroup = intGroup + 2
                End If
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol) = IIf(bolPO, rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.poh_purord_enu), "") 'PO#
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_jobord_enu) '"Job No."

                'Lester Wu 20040626
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 2) = rs_excel.Tables("RESULT").Rows(i)(enuPO.cbi_cussna_enu) '"Pri. Cust. Short Name"
                '.Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 2) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_cuspno_enu) '"Cust PO#"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 4) = rs_excel.Tables("RESULT").Rows(i)(enuPO.secCustSNa_enu) '"Sec. Cust Short Name"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 6) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_cusitm_enu) '"Cust. Item No."

                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 2) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.cbi_cussna_enu) '"Pri. Cust. Short Name"
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 2) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.secCustSNa_enu) '"Sec. Cust Short Name"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 4) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_cuspno_enu) '"Cust PO#"
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 4) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_cusitm_enu) '"Cust. Item No."

                'Lester Wu 20040626
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 8) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_venitm_enu) '"Vendor Item No."
                '.Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 8) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_itmno_enu) '"Our Item No."
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 10) = rs_excel.Tables("RESULT").Rows(i)(enuPO.sod_colcde_enu) '"Color Code"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 11) = Microsoft.VisualBasic.Left(Replace(rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_engdsc_enu), vbCrLf, " "), 20) '"Description"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 6) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_venitm_enu) '"Vendor Item No."
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 6) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_itmno_enu) '"Our Item No."
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 8) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.sod_colcde_enu)  '"Color Code"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 9) = Microsoft.VisualBasic.Left(Replace(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_engdsc_enu), vbCrLf, " "), 20)  '"Description"

                'Lester Wu 2004/06/23
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 14) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_ordqty_enu) '"Order Qty"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_untcde_enu) 'Unit Code
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_balqty_enu) '"O/S Qty"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_balctn_enu) '"O/S Carton"

                'Lester Wu 20040626
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_ordqty_enu) '"Order Qty"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 14) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_untcde_enu) 'Unit Code
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_balqty_enu) '"O/S Qty"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_balctn_enu) '"O/S Carton"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_balcbm_enu) '"O/S CBM"
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 18) = rs_excel.Tables("RESULT").Rows(i)(enuPO.pod_shpstr_enu) '"Ship Start Date"

                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 11) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_ordqty_enu) '"Order Qty"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 12) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_untcde_enu) 'Unit Code
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_balqty_enu) '"O/S Qty"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 14) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_balctn_enu) '"O/S Carton"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_balcbm_enu) '"O/S CBM"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_shpstr_enu) '"Ship Start Date"



                ''Group Total Field
                ''-------------------------------------------------------------
                lngOS_Ctn = lngOS_Ctn + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_balctn_enu)), 0, rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_balctn_enu))
                dblOS_CBM = dblOS_CBM + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_balcbm_enu)), 0, rs_EXCEL.Tables("RESULT").Rows(i)(enuPO.pod_balcbm_enu))
                ''xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                'rs_EXCEL.MoveNext()

            Next

            'Show Total Field
            'Same as the in with the for loop
            '........................
            If strGroup <> "" Then
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13) = "Total :"
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 14) = lngOS_Ctn    'Total O/S Ctn
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = dblOS_CBM    'Total O/S CBM
                .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15)).NumberFormatLocal = "#,##0.0000_ "
                .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15)).Font.Bold = True
                intGroup = intGroup + 1
            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Detail End >xxxxxxxxxxxxxxxxxxxxxx
        '...............


        'xxxxxxxxxxxxxxxxxxxx< Detail Style Start>xxxxxxxxxxxxxxxxxxxxxx
        '============================================================
        With xlWs

            '    .Range(.Cells(DtlRow + 1, indexCol + 14), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 14)).HorizontalAlignment = 4 '"Order Qty"
            '    .Range(.Cells(DtlRow + 1, indexCol + 16), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 16)).HorizontalAlignment = 4  '"O/S Qty"
            '    .Range(.Cells(DtlRow + 1, indexCol + 17), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 17)).HorizontalAlignment = 4   '"O/S Carton"
            .Range(.Cells(DtlRow + 1, indexCol + 11), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 11)).HorizontalAlignment = 4 '"Order Qty"
            .Range(.Cells(DtlRow + 1, indexCol + 13), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 13)).HorizontalAlignment = 4  '"O/S Qty"
            .Range(.Cells(DtlRow + 1, indexCol + 14), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 14)).HorizontalAlignment = 4   '"O/S Carton"
            .Range(.Cells(DtlRow + 1, indexCol + 15), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 15)).HorizontalAlignment = 4   '"O/S CBM"

            .Range(.Cells(DtlRow + 1, indexCol + 16), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 16)).HorizontalAlignment = 4   '"Ship Start Date"

            .Range(.Cells(DtlRow + 1, indexCol + 16), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 16)).NumberFormatLocal = "MM/dd/yyyy"
            .Range(.Cells(DtlRow + 1, indexCol + 15), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 15)).NumberFormatLocal = "0.0000_ " 'O/S CBM


            .Columns.ColumnWidth = 10
            'Column Header
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 2, indexCol + 16)).Font.Bold = True
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 2, indexCol + 16)).Font.Size = 9
            'Row Detail
            .Range(.Cells(DtlRow + 1, indexCol), .Cells(intGroup + DtlRow + 2 * recCount + 4, indexCol + 16)).Font.Size = 8
            .Range(.Cells(DtlRow + 1, indexCol), .Cells(intGroup + DtlRow + 2 * recCount + 4, indexCol + 16)).RowHeight = 15


        End With
        'xxxxxxxxxxxxxxxxxxxx< Detail Style End >xxxxxxxxxxxxxxxxxxxxxx
        '...............

        Dim lngPages As Long

        'Max FitToPagesTall of Excel = 9999
        lngPages = recCount / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If
        'Set print options
        With xlWs.PageSetup
            .Zoom = False
            .TopMargin = 10
            .FitToPagesWide = 1
            .FitToPagesTall = lngPages
            .Orientation = Excel.XlPageOrientation.xlLandscape

        End With

        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


        'With Screen
        '    Me.Move (.Width - Width) \ 2, (.Height - Height) \ 2
        'End With

        Cursor = Cursors.Default ' Return mouse pointer to normal.

        Exit Function

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Cursor = Cursors.Default ' Return mouse pointer to normal.

        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing


        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Function


    Private Sub MSR00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShow_Click()


    End Sub

    Private Sub cboCust2From_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCust2From.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCust2From_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCust2From.LostFocus
        'If ValidateCombo(Me.cboCust2From) = True Then
        '    Me.cboCust2To.Text = Me.cboCust2From.Text
        'End If

    End Sub

    Private Sub cboCust2From_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCust2From.SelectedIndexChanged
        Me.cboCust2To.Text = Me.cboCust2From.Text

    End Sub

    Private Sub cboCust2To_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCust2To.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCust2To_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCust2To.LostFocus
        'Call ValidateCombo(Me.cboCust2To)

    End Sub

    Private Sub cboCust2To_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCust2To.SelectedIndexChanged

    End Sub

    Private Sub cboCustFrom_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustFrom.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCustFrom_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustFrom.LostFocus
        'If ValidateCombo(cboCustFrom) = True Then
        '    Me.cboCustTo.Text = Me.cboCustFrom.Text
        'End If

    End Sub

    Private Sub cboCustFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustFrom.SelectedIndexChanged
        cboCustTo.Text = cboCustFrom.Text
    End Sub

    Private Sub cboCustTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCustTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustTo.LostFocus
        'Call ValidateCombo(cboCustTo)

    End Sub

    Private Sub cboCustTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustTo.SelectedIndexChanged

    End Sub

    Private Sub cboSTFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSTFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSTFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSTFm.LostFocus
        'If ValidateCombo(cboSTFm) = True Then
        '    Me.cboSTTo.Text = Me.cboSTFm.Text
        'End If

    End Sub

    Private Sub cboSTFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSTFm.SelectedIndexChanged
        cboSTTo.Text = cboSTFm.Text

    End Sub

    Private Sub cboSTTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSTTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSTTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSTTo.LostFocus
        'Call ValidateCombo(Me.cboSTTo)

    End Sub

    Private Sub cboSTTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSTTo.SelectedIndexChanged

    End Sub

    Private Sub cboSubCdeFrom_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubCdeFrom.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSubCdeFrom_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCdeFrom.LostFocus
        Me.cboSubCdeTo.Text = Me.cboSubCdeFrom.Text

        'If ValidateCombo(cboSubCdeFrom) = True Then
        '    Me.cboSubCdeTo.Text = Me.cboSubCdeFrom.Text
        'End If

    End Sub

    Private Sub cboSubCdeFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCdeFrom.SelectedIndexChanged
        cboSubCdeTo.Text = cboSubCdeFrom.Text

    End Sub

    Private Sub cboSubCdeTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubCdeTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSubCdeTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCdeTo.LostFocus
        'Call ValidateCombo(cboSubCdeTo)

    End Sub

    Private Sub cboSubCdeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCdeTo.SelectedIndexChanged

    End Sub

    Private Sub cboVenFrom_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFrom.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenFrom.SelectedIndexChanged
        cboVenTo.Text = cboVenFrom.Text

    End Sub

    Private Sub cboVenTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenTo.SelectedIndexChanged

    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        '*** Multi-Company Name Display.
        '    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'XXXXXXXXXXXXXXXXXXXXX
        ' 2004/02/11 Lester Wu
        'Lester Wu 2005-03-21 Replace "ALL" with "UC-G"
        If Me.cboCocde.Text <> "UC-G" Then
            'If Me.cboCoCde.Text <> "ALL" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
        'XXXXXXXXXXXXXXXXXXXXX

    End Sub

    Private Sub txtPONoFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONoFrom.TextChanged
        txtPONoTo.Text = txtPONoFrom.Text

    End Sub
    Private Sub txtSCFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCFm.TextChanged
        txtSCTo.Text = txtSCFm.Text
    End Sub

    Private Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        count_msg = 0
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If
        ValidateCombo = False
        Dim i As Integer
        Dim S As String
        S = Combo1.Text
        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items(i).ToString) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next
        If Not ValidateCombo Then
            If count_msg = 0 Then
                MsgBox("Invalid Data! Please try again.")
                count_msg = 1
                On Error Resume Next
                Combo1.Focus()
                On Error GoTo 0
            End If
        End If
    End Function



    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub txtItemNoTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemNoTo.TextChanged

    End Sub

    Private Sub txtItemNoFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemNoFrom.LostFocus
        txtItemNoTo.Text = txtItemNoFrom.Text


    End Sub

    Private Sub txtItemNoFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemNoFrom.TextChanged

    End Sub

    Private Sub cboCustTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCustTo.Validating
        Call ValidateCombo(cboCustTo)
    End Sub

    Private Sub cboSubCdeTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSubCdeTo.Validating
        Call ValidateCombo(cboSubCdeTo)
    End Sub

    Private Sub cboSubCdeFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSubCdeFrom.Validating
        ValidateCombo(cboSubCdeFrom)
    End Sub

    Private Sub cboVenFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenFrom.Validating
        ValidateCombo(cboVenFrom)
    End Sub

    Private Sub cboVenTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenTo.Validating
        ValidateCombo(cboVenTo)
    End Sub

    Private Sub cboCustFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCustFrom.Validating
        ValidateCombo(cboCustFrom)
    End Sub

    Private Sub cboCust2From_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCust2From.Validating
        ValidateCombo(cboCust2From)

    End Sub

    Private Sub cboCust2To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCust2To.Validating
        ValidateCombo(cboCust2To)
    End Sub

    Private Sub cboSTFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSTFm.Validating
        ValidateCombo(cboSTFm)
    End Sub

    Private Sub cboSTTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSTTo.Validating
        ValidateCombo(cboSTTo)
    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub txtDateFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDateFrom.Validating
        If Trim(txtDateFrom.Text) = "" Then
            txtDateFrom.Text = "  /  /"
        End If

        If (txtDateFrom.Text) <> "  /  /" Then
            If Not IsDate(txtDateFrom.Text) Then
                MsgBox("Date is Invalid !")
                txtDateFrom.Focus()
            End If
        End If

    End Sub

    Private Sub txtDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateTo.MaskInputRejected

    End Sub

    Private Sub txtDateTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDateTo.Validating
        If Trim(txtDateTo.Text) = "" Then
            txtDateTo.Text = "  /  /"
        End If

        If txtDateTo.Text <> "  /  /" Then
            If IsDate(txtDateFrom.Text) Then
                If Not IsDate(txtDateTo.Text) Then
                    MsgBox("Date is Invalid !")
                    txtDateTo.Focus()
                End If
            End If
        End If

    End Sub
End Class
