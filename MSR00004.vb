Public Class MSR00004
    Dim rs_CUBASINF As DataSet
    Dim rs_CUBASINF2 As DataSet
    Dim rs_VNBASINF As DataSet
    Dim rs_SYSETINF As DataSet
    Dim rs_SYSALREP As DataSet
    Dim rs_MSR00004 As DataSet
    Dim rs_EXCEL As DataSet
    Public Enum enuVen
        CoCde = 0
        pod_purord = 1
        pod_purseq = 2
        poh_venno = 3
        pod_venitm = 4
        pod_itmno = 5
        pod_engdsc = 6
        poh_purord = 7
        pod_jobord = 8
        pod_cuspno = 9
        soh_cus1no = 10
        Seccustno = 11
        pod_cusitm = 12
        pod_vencol = 13
        pod_shpstr = 14
        pod_shpend = 15
        pod_ftyprc = 16
        pod_curcde = 17
        pod_ordqty = 18
        pod_untcde = 19
        pod_balqty = 20
        pod_balamt = 21
        pod_balctn = 22
        pod_balcbm = 23
        'pod_balcft = 23
        pod_cubcft = 24
        opt_ven_Fm = 25
        opt_ven_to = 26
        opt_subcode_Fm = 27
        opt_subcode_to = 28
        opt_po_Fm = 29
        opt_po_To = 30
        opt_cus1no_Fm = 31
        opt_cus1no_To = 32
        secCNF = 33
        seccnt = 34
        opt_cusPO_Fm = 35
        opt_cusPO_To = 36
        opt_itmno_Fm = 37
        opt_itmno_To = 38
        opt_shpstr_Fm = 39
        opt_shpstr_To = 40
        Opt_PrintPO = 41
        opt_PrintFPrc = 42
        SORTBY = 43
        sortKey = 44
        opt_SC_Fm = 45
        opt_SC_To = 46
        opt_Sal_Fm = 47
        opt_Sal_To = 48
        compName = 49
    End Enum
    Private Sub MSR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        '*************Default****************
        '*** Multi-Company Name Display.
        Call FillCompCombo(gsUsrID, cboCocde)
        '*** ADD PRINT ALL COMPANY ***
        ' 2004/02/11
        'Replace ALL with UC-G
        'Me.cboCoCde.AddItem "ALL"
        If gsDefaultCompany <> "MS" Then
            cboCocde.Items.Add("UC-G")
        End If
        '*****************************
        Call GetDefaultCompany(cboCocde, txtCoNam)

        Call Formstartup(Me.Name)


        'txtDateFrom = Format(Date, "MM/DD/YYYY")
        'txtDateTo = Format(Date, "MM/DD/YYYY")

        'txtDateFrom = "  /  /    "
        'txtDateTo = "  /  /    "

       



        gspStr = "sp_list_CUBASINF '','PA'"

        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_CUBASINF:" & rtnStr)
            Exit Sub
        Else
            FillcboCust()
        End If



        '2004/02/11 Lester Wu

        gspStr = "sp_list_CUBASINF '','P'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF2, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_CUBASINF 2:" & rtnStr)
            Exit Sub
        Else

            Call FillcboCust2()
        End If
        '--------------------

        gspStr = "sp_list_VNBASINF ''"

        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_VNBASINF:" & rtnStr)
            Exit Sub
        Else

            Call FillcboVen()
        End If


        gspStr = "sp_select_SUBCDE ''"

        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)


        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading sp_select_SUBCDE:" & rtnStr)
            Exit Sub
        Else

            Call FillcboSubCde()
        End If

        If gsCompany = "UCPP" Then
            optPrintPON.Checked = True
            optPrintPOY.Checked = False
        Else
            optPrintPOY.Checked = True
            optPrintPON.Checked = False
        End If

        gspStr = "sp_list_SYSALREP_MSR00013"

        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)


        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading sp_select_SUBCDE:" & rtnStr)
            Exit Sub
        Else

            Call FillcboST()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillcboCust()
        cboCustFrom.Items.Clear()
        cboCustFrom.Items.Add("")
        cboCustTo.Items.Clear()
        cboCustTo.Items.Add("")

        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_CUBASINF.Tables("RESULT").Rows.Count - 1
                cboCustFrom.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cussna"))
                cboCustTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cussna"))

            Next
        End If
    End Sub
    Private Sub FillcboCust2()

        cboCust2From.Items.Clear()
        cboCust2From.Items.Add("")
        cboCust2To.Items.Clear()
        cboCust2To.Items.Add("")
        If rs_CUBASINF2.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_CUBASINF2.Tables("RESULT").Rows.Count - 1
                cboCust2From.Items.Add(rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cussna"))
                cboCust2To.Items.Add(rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cussna"))

            Next
        End If
    End Sub
    Private Sub FillcboVen()
        cboVenFrom.Items.Clear()
        cboVenFrom.Items.Add("")
        cboVenTo.Items.Clear()
        cboVenTo.Items.Add("")
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenFrom.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))
                cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))

            Next
        End If
    End Sub


    Private Sub FillcboSubCde()
        cboSubCdeFrom.Items.Clear()
        cboSubCdeFrom.Items.Add("")
        cboSubCdeTo.Items.Clear()
        cboSubCdeTo.Items.Add("")
        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_SYSETINF.Tables("RESULT").Rows.Count - 1
                cboSubCdeFrom.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("subcde"))
                cboSubCdeTo.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("subcde"))

            Next
        End If
    End Sub

    Private Sub FillcboST()
        cboSTFm.Items.Clear()
        cboSTTo.Items.Clear()
        cboSTFm.Items.Add("")
        cboSTTo.Items.Add("")

        If rs_SYSALREP.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_SYSALREP.Tables("RESULT").Rows.Count - 1
                cboSTFm.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(i).Item("ysr_saltem"))
                cboSTTo.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(i).Item("ysr_saltem"))

            Next
        End If
    End Sub

    Private Sub cboVenFrom_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFrom.KeyUp
        auto_search_combo(cboVenFrom)
    End Sub

    Private Sub cboVenFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenFrom.SelectedIndexChanged

    End Sub

    Private Sub cboVenTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp
        auto_search_combo(cboVenTo)
    End Sub

    Private Sub cboVenTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenTo.SelectedIndexChanged

    End Sub

    Private Sub cboSubCdeFrom_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubCdeFrom.KeyUp
        auto_search_combo(cboSubCdeFrom)
    End Sub

    Private Sub cboSubCdeFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCdeFrom.SelectedIndexChanged

    End Sub

    Private Sub cboSubCdeTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubCdeTo.KeyUp
        auto_search_combo(cboSubCdeTo)
    End Sub

    Private Sub cboSubCdeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCdeTo.SelectedIndexChanged

    End Sub

    Private Sub cboCustFrom_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustFrom.KeyUp
        auto_search_combo(cboCustFrom)
    End Sub

    Private Sub cboCustFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustFrom.SelectedIndexChanged

    End Sub

    Private Sub cboCustTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustTo.KeyUp
        auto_search_combo(cboCustTo)
    End Sub

    Private Sub cboCustTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustTo.SelectedIndexChanged

    End Sub

    Private Sub cboCust2From_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCust2From.KeyUp
        auto_search_combo(cboCust2From)
    End Sub

    Private Sub cboCust2From_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCust2From.SelectedIndexChanged

    End Sub

    Private Sub cboCust2To_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCust2To.KeyUp
        auto_search_combo(cboCust2To)
    End Sub

    Private Sub cboCust2To_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCust2To.SelectedIndexChanged

    End Sub

    Private Sub cboSTFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSTFm.KeyUp
        auto_search_combo(cboSTFm)
    End Sub

    Private Sub cboSTFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSTFm.SelectedIndexChanged

    End Sub

    Private Sub cboSTTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSTTo.KeyUp
        auto_search_combo(cboSTTo)
    End Sub

    Private Sub cboSTTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSTTo.SelectedIndexChanged

    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text = "UC-G" Then
            txtCoNam.Text = "UNITED CHINESE GROUP"
            Exit Sub
        End If

        txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------






        Dim SubCdeFrom As String
        Dim SubCdeTo As String
        Dim SORTBY As String

        'If cboCustFrom.Text = "" And cboCustTo.Text = "" Then
        '    cboCustFrom.ListIndex = 0
        '    cboCustTo.ListIndex = cboCustTo.ListCount - 1
        'End If

        If cboCustFrom.Text = "" And cboCustTo.Text <> "" Then
            cboCustFrom.Text = cboCustTo.Text
        End If

        If cboCustTo.Text = "" And cboCustFrom.Text <> "" Then
            cboCustTo.Text = cboCustFrom.Text
        End If


        ' 2004/02/11 Lester Wu

        'If checkValidCombo(Me.cboCust2NoFm, cboCust2NoFm.Text) = False And cboCust2NoFm.Text <> "" Then
        '    MsgBox("Invalid Value")
        '    cboCust2NoFm.Focus()
        '    Exit Sub
        'End If

        If checkValidCombo(Me.cboCust2From, cboCust2From.Text) = False And cboCust2From.Text <> "" Then
            MsgBox("Invalid Value")
            cboCust2From.Focus()
            Exit Sub
        End If

        If checkValidCombo(Me.cboCust2To, cboCust2From.Text) = False And cboCust2To.Text <> "" Then
            MsgBox("Invalid Value")
            cboCust2To.Focus()
            Exit Sub
        End If

        If cboCust2From.Text = "" And cboCust2To.Text <> "" Then
            cboCust2From.Text = cboCust2To.Text
        End If

        If cboCust2To.Text = "" And cboCust2From.Text <> "" Then
            cboCust2To.Text = cboCust2From.Text
        End If
        ' --------------------

        'If cboVenFrom.Text = "" And cboVenTo.Text = "" Then
        '    cboVenFrom.ListIndex = 0
        '    cboVenTo.ListIndex = cboVenTo.ListCount - 1
        'End If

        If cboVenFrom.Text = "" And cboVenTo.Text <> "" Then
            cboVenFrom.Text = cboVenTo.Text
        End If

        If cboVenTo.Text = "" And cboVenFrom.Text <> "" Then
            cboVenTo.Text = cboVenFrom.Text
        End If

        If cboSTTo.Text = "" And cboSTFm.Text <> "" Then
            cboSTTo.Text = cboSTFm.Text
        End If


        'If cboSubCdeFrom.Text = "" And cboSubCdeTo.Text = "" Then
        '    If cboSubCdeFrom.ListCount > 0 Then
        '       cboSubCdeFrom.ListIndex = 0
        '       cboSubCdeTo.ListIndex = cboSubCdeTo.ListCount - 1
        '    End If
        'End If

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


        'txtPONoFrom.Text = UCase(txtPONoFrom)
        'txtPONoTo.Text = UCase(txtPONoTo)

        'txtCusPoFrom.Text = UCase(txtCusPoFrom.Text)
        'txtCusPoTo.Text = UCase(txtCusPoTo.Text)

        'txtItemNoFrom.Text = UCase(txtItemNoFrom.Text)
        'txtItemNoTo.Text = UCase(txtItemNoTo.Text)

        If sortP.Checked = True Then
            SORTBY = "P"
        ElseIf SortC.Checked = True Then
            SORTBY = "C"
        ElseIf SortV.Checked = True Then
            SORTBY = "V"
        Else
            SORTBY = "I"
        End If




        If Not InputIsVaild Then
            Exit Sub
        End If

        
        Me.Cursor = Cursors.WaitCursor

        '   S = "㊣MSR00004※L" & _
        '        "※" & GetCtrlValue(cboVenFrom) & _
        '        "※" & GetCtrlValue(cboVenTo) & _
        '        "※" & SubCdeFrom & _
        '        "※" & SubCdeTo & _
        '        "※" & UCase(txtPONoFrom.Text) & _
        '        "※" & UCase(txtPONoTo.Text) & _
        '        "※" & GetCtrlValue(cboCustFrom) & _
        '        "※" & GetCtrlValue(cboCustTo) & _
        '        "※" & UCase(txtCusPoFrom.Text) & _
        '        "※" & UCase(txtCusPoTo.Text) & _
        '        "※" & UCase(txtSCFm.Text) & _
        '        "※" & UCase(txtSCTo.Text) & _
        '        "※" & UCase(cboSTFm.Text) & _
        '        "※" & UCase(cboSTTo.Text) & _
        '        "※" & UCase(txtItemNoFrom.Text) & _
        '        "※" & UCase(txtItemNoTo.Text) & _
        '        "※" & IIf(txtDateFrom.Text = "  /  /    ", "", txtDateFrom.Text) & _
        '        "※" & IIf(txtDateTo.Text = "  /  /    ", "", txtDateTo.Text) & _
        '        "※" & IIf(optPrintPOY.Value = True, "Y", "N") & _
        '        "※" & IIf(optPrintFPrc(0).Value = True, "Y", "N") & _
        '        "※" & SortBy & _
        '        "※" & gsUsrID
        '2004/02/11 Lester Wu

        'S = "㊣MSR00004※L" & _
        '        "※" & GetCtrlValue(cboVenFrom) & _
        '        "※" & GetCtrlValue(cboVenTo) & _
        '        "※" & SubCdeFrom & _
        '        "※" & SubCdeTo & _
        '        "※" & UCase(txtPONoFrom.Text) & _
        '        "※" & UCase(txtPONoTo.Text) & _
        '        "※" & GetCtrlValue(cboCustFrom) & _
        '        "※" & GetCtrlValue(cboCustTo) & _
        '        "※" & GetCtrlValue(cboCust2From) & _
        '        "※" & GetCtrlValue(cboCust2To) & _
        '        "※" & UCase(txtCusPoFrom.Text) & _
        '        "※" & UCase(txtCusPoTo.Text) & _
        '        "※" & UCase(txtSCFm.Text) & _
        '        "※" & UCase(txtSCTo.Text) & _
        '        "※" & UCase(cboSTFm.Text) & _
        '        "※" & UCase(cboSTTo.Text) & _
        '        "※" & UCase(txtItemNoFrom.Text) & _
        '        "※" & UCase(txtItemNoTo.Text) & _
        '        "※" & IIf(txtDateFrom.Text = "  /  /    ", "", txtDateFrom.Text) & _
        '        "※" & IIf(txtDateTo.Text = "  /  /    ", "", txtDateTo.Text) & _
        '        "※" & IIf(optPrintPOY.Value = True, "Y", "N") & _
        '        "※" & IIf(optPrintFPrc(0).Value = True, "Y", "N") & _
        '        "※" & SortBy & _
        '        "※" & gsUsrID
        Dim optprintfprc As String
        If optPrintFPrcY.Checked = True Then
            optprintfprc = "Y"
        Else
            optprintfprc = "N"
        End If


        gspStr = "sp_list_MSR00004_NET '" & cboCocde.Text & _
                "','" & GetCtrlValue(cboVenFrom) & _
                "','" & GetCtrlValue(cboVenTo) & _
                "','" & SubCdeFrom & _
                "','" & SubCdeTo & _
                "','" & UCase(txtPONoFrom.Text) & _
                "','" & UCase(txtPONoTo.Text) & _
                "','" & GetCtrlValue(cboCustFrom) & _
                "','" & GetCtrlValue(cboCustTo) & _
                "','" & GetCtrlValue(cboCust2From) & _
                "','" & GetCtrlValue(cboCust2To) & _
                "','" & UCase(txtCusPoFrom.Text) & _
                "','" & UCase(txtCusPoTo.Text) & _
                "','" & UCase(txtSCFm.Text) & _
                "','" & UCase(txtSCTo.Text) & _
                "','" & UCase(cboSTFm.Text) & _
                "','" & UCase(cboSTTo.Text) & _
                "','" & UCase(txtItemNoFrom.Text) & _
                "','" & UCase(txtItemNoTo.Text) & _
                "','" & IIf(txtDateFrom.Text = "  /  /", "", txtDateFrom.Text) & _
                "','" & IIf(txtDateTo.Text = "  /  /", "", txtDateTo.Text) & _
                "','" & IIf(optPrintPOY.Checked = True, "Y", "N") & _
                "','" & optprintfprc & _
                "','" & SORTBY & "','" & gsUsrID & "','" & gsSalTem & "'"


       

        'Relocation to report server
        '  rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        rtnLong = execute_SQLStatementRPT(gspStr, rs_MSR00004, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_MSR00004:" & rtnStr)
            Exit Sub
        Else


            'Kenny Add on 18-10-2002
            '        If SortBy = "I" Then
            '            rs_MSR00004.sort = "pod_shpstr,pod_venitm, pod_itmno, poh_purord"
            '        End If


            If rs_MSR00004.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MsgBox("No Record Found")
                Exit Sub
            Else
                If Me.chkExcel.Checked = False Then

                    Dim objRpt As New MSR00004Rpt
                    objRpt.SetDataSource(rs_MSR00004.Tables("RESULT"))

                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()

                    'ReportName(0) = "MSR00004.rpt"
                    'ReportRS(0) = rs_MSR00004
                    'frmReport.Show()
                Else
                    rs_EXCEL = rs_MSR00004
                    Call CmdExportExcel_Click()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function InputIsVaild() As Boolean

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

        If cboCustFrom.Text = "" Then
            ' Msg ("M00414")
            ' InputIsVaild = False
            ' cboCustFrom.SetFocus
            ' Exit Function
        End If

        If cboCustTo.Text = "" Then
            ' Msg ("M00414")
            ' InputIsVaild = False
            ' cboCustTo.SetFocus
            ' Exit Function
        End If

        If txtDateFrom.Text <> "  /  /" Then
            If IsDate(txtDateFrom.Text) = False Then
                MsgBox("Invalid Date")
                InputIsVaild = False
                txtDateFrom.Focus()
                Exit Function
            End If
        End If

        If txtDateTo.Text <> "  /  /" Then
            If IsDate(txtDateTo.Text) = False Then
                MsgBox("Invalid Date")
                InputIsVaild = False
                txtDateFrom.Focus()
                Exit Function
            End If
        End If

        If txtDateFrom.Text <> "  /  /" And txtDateTo.Text <> "  /  /" Then
            If CDate(txtDateFrom.Text) > CDate(Me.txtDateTo.Text) Then
                MsgBox("Invalid Date Range")
                InputIsVaild = False
                txtDateFrom.Focus()
                Exit Function
            End If
        End If

        InputIsVaild = True
    End Function

    Private Function GetCtrlValue(ByVal Ctrl As Control) As String
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
        End If
    End Function


    Private Function CmdExportExcel_Click()

        On Error GoTo Err_Handler

        Me.Cursor = Cursors.WaitCursor ' Change mouse pointer to hourglass.
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet

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


        '.Range(.Cells(HdrRow + 1, indexCol), .Cells(DtlRow + 2 * recCount + 1, indexCol + 17)).Font.Size = 10

        bolFtyPrice = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_PrintFPrc) = "Y", True, False)
        bolPO = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.Opt_PrintPO) = "Y", True, False)

        '==========================================================
        'xxxxxxxxxxxxxxxxxxxxx< Title Start >xxxxxxxxxxxxxxxxxxxxxx
        strCompany = ""
        strTitle = "OUTSTANDING ORDER REPORT VENDOR"

        'if {MSR00004_ttx.@poh_cocde} = "UCPP" then
        '
        'else if {MSR00004_ttx.@poh_cocde} = "UCP" then
        '
        'else if {MSR00004_ttx.@poh_cocde} = "PG" then
        '
        'else if {MSR00004_ttx.@poh_cocde} = "ALL" then
        '

        'Select Case rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.CoCde)
        '    Case "UCP"
        '            strCompany = "UCP INTERNATIONAL CO., LTD."
        '    Case "UCPP"
        '            strCompany = "UNITED CHINESE PLASTICS PRODUCTS CO., LTD."
        '    Case "PG"
        '            strCompany = "Pacific Global Enterprises Limited"
        '    Case "ALL"
        '            strCompany = "UNITED CHINESE GROUP"
        'End Select

        strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.compName)

        With xlWs

            'Report ID
            .Cells(1, 16) = "Report ID"
            .Cells(1, 17) = ":"
            .Cells(1, 18) = "MSR00004"

            'Date
            .Cells(2, 16) = "Date"
            .Cells(2, 17) = ":"
            .Cells(2, 18) = Format(Now, "MM/dd/yyyy")
            .Range(.Cells(2, 18), .Cells(2, 18)).NumberFormatLocal = "mm/dd/yyyy"
            'Time
            .Cells(3, 16) = "Time"
            .Cells(3, 17) = ":"
            .Cells(3, 18) = Format(Now, "HH:mm:ss")
            .Range(.Cells(3, 18), .Cells(3, 18)).NumberFormatLocal = "HH:MM:SS"
            'Page
            .Cells(4, 16) = "Page"
            .Cells(4, 17) = ":"
            .Cells(4, 18) = "1 of 1"

            'Input Parameter
            'vendor
            .Cells(4, 1) = "Vendor"
            .Cells(4, 2) = ":"
            .Cells(4, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_to) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_Fm))
            .Cells(4, 4) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_to) = "", "", "-")
            .Cells(4, 5) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_to) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_ven_to))
            'subcode
            .Cells(5, 1) = "Sub Code"
            .Cells(5, 2) = ":"
            .Cells(5, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_to) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_Fm))
            .Cells(5, 4) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_to) = "", "", "-")
            .Cells(5, 5) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_to) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_subcode_to))

            'PO NO
            .Cells(6, 1) = "PO NO."
            .Cells(6, 2) = ":"
            .Cells(6, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_To) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_Fm))
            .Cells(6, 4) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_To) = "", "", "-")
            .Cells(6, 5) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_To) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_po_To))

            'Cust NO
            .Cells(4, 6) = "Cust No."
            .Cells(4, 7) = ":"
            .Cells(4, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_To) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_Fm))
            .Cells(4, 9) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_To) = "", "", "-")
            .Cells(4, 10) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_To) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cus1no_To))


            'Sec. Cust No
            .Cells(5, 6) = "Sec. Cust No"
            .Cells(5, 7) = ":"
            .Cells(5, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.secCNF) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.seccnt) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.secCNF))
            .Cells(5, 9) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.secCNF) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.seccnt) = "", "", "-")
            .Cells(5, 10) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.secCNF) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.seccnt) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.seccnt))

            'Cust PO
            .Cells(6, 6) = "Cust PO"
            .Cells(6, 7) = ":"
            .Cells(6, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_To) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_Fm))
            .Cells(6, 9) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_To) = "", "", "-")
            .Cells(6, 10) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_To) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_cusPO_To))


            'SC No
            .Cells(7, 6) = "SC No"
            .Cells(7, 7) = ":"
            .Cells(7, 8) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_To) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_Fm))
            .Cells(7, 9) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_To) = "", "", "-")
            .Cells(7, 10) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_To) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_SC_To))

            'Sales Team
            .Cells(4, 11) = "Sales Team"
            .Cells(4, 12) = ":"
            .Cells(4, 13) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_To) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_Fm))
            .Cells(4, 14) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_To) = "", "", "-")
            .Cells(4, 15) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_To) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_Sal_To))


            'Item No
            .Cells(5, 11) = "Item No"
            .Cells(5, 12) = ":"
            .Cells(5, 13) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_To) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_Fm))
            .Cells(5, 14) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_To) = "", "", "-")
            .Cells(5, 15) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_To) = "", "", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_itmno_To))


            'Ship Date
            .Cells(6, 11) = "Ship Date"
            .Cells(6, 12) = ":"
            .Cells(6, 13) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_shpstr_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_shpstr_To) = "", "--/--/----", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_shpstr_Fm))
            .Cells(6, 14) = "-"
            .Cells(6, 15) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_shpstr_Fm) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_shpstr_To) = "", "--/--/----", rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_shpstr_To))


            'Show PO#
            .Cells(7, 11) = "Show PO#"
            .Cells(7, 12) = ":"
            .Cells(7, 13) = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.Opt_PrintPO)


            'Show Price
            .Cells(7, 14) = "Show Price :"
            .Cells(7, 15) = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.opt_PrintFPrc)

            'Sort By
            .Cells(7, 17) = "Sort By :"
            Select Case rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.SORTBY)
                Case "P"
                    .Cells(7, 18) = "Customer Short Name"
                Case "C"
                    .Cells(7, 18) = "Customer PO #"
                Case "V"
                    .Cells(7, 18) = "Vendor Item #"
                Case Else
                    .Cells(7, 18) = "Ship Date"
            End Select




            'defalut aligment
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 18)).HorizontalAlignment = 2
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 18)).Font.Size = 10

            'COmpany
            .Range(.Cells(1, 5), .Cells(1, 14)).Merge()
            .Range(.Cells(1, 5), .Cells(1, 14)).Value = strCompany
            .Range(.Cells(1, 5), .Cells(1, 14)).RowHeight = 25
            .Range(.Cells(1, 5), .Cells(1, 14)).Font.Size = 12
            .Range(.Cells(1, 5), .Cells(1, 14)).Font.Bold = True
            .Range(.Cells(1, 5), .Cells(1, 14)).HorizontalAlignment = 3
            'Report Title
            .Range(.Cells(2, 5), .Cells(2, 14)).Merge()
            .Range(.Cells(2, 5), .Cells(2, 14)).Value = strTitle
            .Range(.Cells(2, 5), .Cells(2, 14)).Font.Size = 10
            .Range(.Cells(2, 5), .Cells(2, 14)).HorizontalAlignment = 3

        End With
        'xxxxxxxxxxxxxxxxxxxxx< Title End >xxxxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        '==========================================================
        'xxxxxxxxxxxxxxxxxxxx< Row Header Start>xxxxxxxxxxxxxxxxxxxx
        With xlWs

            .Cells(HdrRow + 1, indexCol) = "Vendor Item"
            .Cells(HdrRow + 2, indexCol) = "Our Item#"
            .Cells(HdrRow + 1, indexCol + 1) = "Description"
            .Cells(HdrRow + 1, indexCol + 3) = IIf(bolPO, "PO#", "")
            .Cells(HdrRow + 2, indexCol + 3) = "JOB#"
            .Cells(HdrRow + 1, indexCol + 5) = "Cust Short Name"
            .Cells(HdrRow + 2, indexCol + 5) = "Sec. Cust Short Name"
            .Cells(HdrRow + 1, indexCol + 7) = "Cust Item"
            .Cells(HdrRow + 2, indexCol + 7) = "Cust PO#"
            .Cells(HdrRow + 1, indexCol + 8) = "Color"
            .Cells(HdrRow + 1, indexCol + 9) = "Ship" & Chr(13) & "Start Date"

            .Cells(HdrRow + 1, indexCol + 10) = "Order" & Chr(13) & "Qty"
            .Cells(HdrRow + 1, indexCol + 11) = "O/S" & Chr(13) & "Qty"
            .Cells(HdrRow + 1, indexCol + 12) = ""
            .Cells(HdrRow + 1, indexCol + 13) = IIf(bolFtyPrice, "Currency", "")
            .Cells(HdrRow + 1, indexCol + 14) = IIf(bolFtyPrice, "FTY. Price", "")
            .Cells(HdrRow + 1, indexCol + 15) = IIf(bolFtyPrice, "O/S Amount", "")
            .Cells(HdrRow + 1, indexCol + 16) = "O/S Ctn"
            .Cells(HdrRow + 1, indexCol + 17) = "O/S CBM"
            '--------------------

            '--------------------
            .Range(.Cells(HdrRow + 1, indexCol + 10), .Cells(HdrRow + 2 * i + 1, indexCol + 10)).HorizontalAlignment = 4 'Order Qty
            .Range(.Cells(HdrRow + 1, indexCol + 11), .Cells(HdrRow + 2 * i + 1, indexCol + 11)).HorizontalAlignment = 4  'O/S Qty
            .Range(.Cells(HdrRow + 1, indexCol + 13), .Cells(HdrRow + 2 * i + 1, indexCol + 13)).HorizontalAlignment = 3 'Currency
            .Range(.Cells(HdrRow + 1, indexCol + 14), .Cells(HdrRow + 2 * i + 1, indexCol + 14)).HorizontalAlignment = 4 'Fty Price
            .Range(.Cells(HdrRow + 1, indexCol + 15), .Cells(HdrRow + 2 * i + 1, indexCol + 15)).HorizontalAlignment = 4 'O/S Amount
            .Range(.Cells(HdrRow + 1, indexCol + 16), .Cells(HdrRow + 2 * i + 1, indexCol + 16)).HorizontalAlignment = 4  'O/S Ctn
            .Range(.Cells(HdrRow + 1, indexCol + 17), .Cells(HdrRow + 2 * i + 1, indexCol + 17)).HorizontalAlignment = 4 'Cuft
            '---------------------
        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Header End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        'xxxxxxxxxxxxxxxxxxxx< Row Detail Start >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................
        recCount = rs_EXCEL.Tables("RESULT").Rows.Count - 1
        With xlWs

            strGroup = ""
            tmpGroup = ""
            For i = 0 To recCount
                tmpGroup = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.poh_venno)
                If strGroup <> tmpGroup Then
                    'Show Total Field
                    '.............................................................................................
                    If strGroup <> "" Then
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 12) = "Total : "    '--Unit Code
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13) = IIf(bolFtyPrice, strCurr, "") 'Currency
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = IIf(bolFtyPrice, dblOS_Amt, "") 'Total O/S Amount
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = lngOS_Ctn    'Total O/S Ctn
                        .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = dblOS_CBM    'Total O/S CBM
                        .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17)).NumberFormatLocal = "#,##0.0000_ "
                        dblOS_CBM = 0
                        strCurr = ""
                        dblOS_Amt = 0
                        lngOS_Ctn = 0
                        intGroup = intGroup + 1
                    End If
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    strGroup = tmpGroup
                    .Cells(intGroup + DtlRow + 2 * i + 2, indexCol) = "Factory: (" & strGroup & ")"
                    .Range(.Cells(intGroup + DtlRow + 2 * i + 2, indexCol), .Cells(intGroup + DtlRow + 2 * i + 2, indexCol)).Font.Bold = True
                    intGroup = intGroup + 2
                End If
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_venitm)      'Vendor Item
                .Range(.Cells(intGroup + DtlRow + 2 * i + 2, indexCol), .Cells(intGroup + DtlRow + 2 * i + 2, indexCol)).NumberFormatLocal = "@"
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol) = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_itmno) = "", "", "(" & rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_itmno) & ")")  'Our Item #
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 1) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_engdsc)     'Description
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.Opt_PrintPO) = "Y", rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.poh_purord), "")   'PO#
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 3) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_jobord)      'JOB#
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 5) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.soh_cus1no)     'Cust Short Name
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 5) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.Seccustno)     'Sec. Cust Short Name
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 7) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_cusitm)    'Cust Item
                .Cells(intGroup + DtlRow + 2 * i + 2, indexCol + 7) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_cuspno)      'Cust PO#
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 8) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_vencol)     'Color
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 9) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_shpstr)     'Ship Start Date
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 10) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_ordqty)     'Order Qty
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 11) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balqty)    'O/S Qty
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 12) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_untcde)    '--Unit Code
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13) = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.opt_PrintFPrc) = "Y", rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_curcde), "") 'Currency
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 14) = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.opt_PrintFPrc) = "Y", rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_ftyprc), "") 'FTY Price
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.opt_PrintFPrc) = "Y", rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balamt), "") 'O/S Amount
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balctn)    'O/S Ctn
                '2004/06/23 Lester Wu
                '.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.pod_balcft)    'Cuft
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balcbm)    'Cuft
                'Group Total Field
                '-------------------------------------------------------------
                strCurr = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuVen.pod_curcde)
                dblOS_Amt = dblOS_Amt + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balamt)), 0, rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balamt))
                lngOS_Ctn = lngOS_Ctn + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balctn)), 0, rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balctn))
                dblOS_CBM = dblOS_CBM + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balcbm)), 0, rs_EXCEL.Tables("RESULT").Rows(i).Item(enuVen.pod_balcbm))
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            Next

            'Show Total Field
            '.............................................................................................
            If strGroup <> "" Then
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 12) = "Total : "    '--Unit Code
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 13) = IIf(bolFtyPrice, strCurr, "") 'Currency
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 15) = IIf(bolFtyPrice, dblOS_Amt, "") 'Total O/S Amount
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 16) = lngOS_Ctn    'Total O/S Ctn
                .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17) = dblOS_CBM    'Total O/S CBM
                .Range(.Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17), .Cells(intGroup + DtlRow + 2 * i + 1, indexCol + 17)).NumberFormatLocal = "#,##0.0000_ "
                dblOS_CBM = 0
                strCurr = ""
                dblOS_Amt = 0
                lngOS_Ctn = 0
                intGroup = intGroup + 1
            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


            .Range(.Cells(DtlRow + 1, indexCol + 9), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 9)).NumberFormatLocal = "mm/dd/yyyy" 'Ship Start Date

            .Range(.Cells(DtlRow + 1, indexCol + 10), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 10)).HorizontalAlignment = 4 'Order Qty
            .Range(.Cells(DtlRow + 1, indexCol + 11), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 11)).HorizontalAlignment = 4 'O/S Qty
            .Range(.Cells(DtlRow + 1, indexCol + 13), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 13)).HorizontalAlignment = 3 'Currency
            .Range(.Cells(DtlRow + 1, indexCol + 14), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 14)).HorizontalAlignment = 4 'Fty Price
            .Range(.Cells(DtlRow + 1, indexCol + 15), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 15)).HorizontalAlignment = 4 'O/S Amount
            .Range(.Cells(DtlRow + 1, indexCol + 16), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 16)).HorizontalAlignment = 4 'O/S Ctn
            .Range(.Cells(DtlRow + 1, indexCol + 17), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 17)).HorizontalAlignment = 4 'Cuft

            .Range(.Cells(DtlRow + 1, indexCol + 14), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 14)).NumberFormatLocal = "#,##0.0000_ " 'Fty Price
            .Range(.Cells(DtlRow + 1, indexCol + 15), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 15)).NumberFormatLocal = "#,##0.00_ " 'O/S Amount
            .Range(.Cells(DtlRow + 1, indexCol + 17), .Cells(intGroup + DtlRow + 2 * recCount + 1, indexCol + 17)).NumberFormatLocal = "#,##0.0000_ " 'O/S Amount

        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Detail End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        'xxxxxxxxxxxxxxxxxxxx< Detail Style Start>xxxxxxxxxxxxxxxxxxxxxx
        '============================================================
        With xlWs

            .Columns.ColumnWidth = 10
            'Column Header
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 2, indexCol + 17)).Font.Bold = True
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 2, indexCol + 17)).Font.Size = 9
            'Row Detail
            .Cells(intGroup + DtlRow + 2 * recCount + 4, indexCol).Value = "Recod Number: " & (recCount + 1)
            '.Range(.Cells(DtlRow + 1, indexCol), .Cells(intGroup + DtlRow + 2 * recCount + 2, indexCol + 17)).Font.Size = 8
            .Range(.Cells(DtlRow + 1, indexCol), .Cells(intGroup + DtlRow + 2 * recCount + 4, indexCol + 17)).Font.Size = 8
            .Range(.Cells(DtlRow + 1, indexCol), .Cells(intGroup + DtlRow + 2 * recCount + 4, indexCol + 17)).RowHeight = 15
        End With
        'xxxxxxxxxxxxxxxxxxxx< Detail Style End >xxxxxxxxxxxxxxxxxxxxxx
        '............................................................

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
            .Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape
        End With

        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


        'With Screen
        '    Me.Move (.Width - Width) \ 2, (.Height - Height) \ 2
        'End With

        Me.Cursor = Cursors.Default  ' Return mouse pointer to normal.

        Exit Function

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Me.Cursor = Cursors.Default  ' Return mouse pointer to normal.

        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing


        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Function


End Class