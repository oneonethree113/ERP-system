Public Class MSR00012
    Dim rs_CUBASINF As DataSet
    Dim rs_MSR00012 As DataSet
    Dim rs_EXCEL As DataSet
    Public Enum enuCust
        Sort_enu = 0
        cocde_enu = 1
        CustFrom_enu = 2
        CustTo_enu = 3
        SecCust_enu = 4
        DateFrom_enu = 5
        DateTo_enu = 6
        soh_cus1no_enu = 7
        soh_cus1nam_enu = 8
        soh_cus2no_enu = 9
        soh_cus2nam_enu = 10
        soh_curcde_enu = 11
        sod_OrdAmt_enu = 12
        sod_Eshp_enu = 13
        sod_Lshp_enu = 14
        sod_LOrd_enu = 15
        sod_LInv_enu = 16
        TotalHKD_enu = 17
        TotalUSD_enu = 18
        compName = 19
    End Enum
    Private Sub MSR00012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillCompCombo(gsUsrID, cboCocde)
        

        If gsDefaultCompany <> "MS" Then
            cboCocde.Items.Add("UC-G")
        End If
        '*****************************
        Call GetDefaultCompany(cboCocde, txtCoNam)

        Call Formstartup(Me.Name)




        Me.Cursor = Cursors.WaitCursor
        gspStr = "sp_list_CUBASINF '','PA'"

        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_CUBASINF:" & rtnStr)
            Exit Sub
        Else
            FillcboCust()
        End If


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FillcboCust()
        cboCustFrom.Items.Clear()
        cboCustTo.Items.Clear()
        cboCustTo.Items.Add("")
        cboCustFrom.Items.Add("")
        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_CUBASINF.Tables("RESULT").Rows.Count - 1
                cboCustFrom.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cussna"))
                cboCustTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cussna"))

            Next
        End If
    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text = "UC-G" Then
            txtCoNam.Text = "UNITED CHINESE GROUP"
            Exit Sub
        End If

        txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
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
    Private Function InputIsVaild() As Boolean

        'If cboCustFrom.Text = "" Then
        '    msg("M00414")
        '    InputIsVaild = False
        '    cboCustFrom.SetFocus()
        '    Exit Function
        'End If

        'If cboCustTo.Text = "" Then
        '    msg("M00414")
        '    InputIsVaild = False
        '    cboCustTo.SetFocus()
        '    Exit Function
        'End If

        '' 2004/02/12 Lester Wu ---------
        'If cboCust2From.Text = "" And cboCust2To.Text <> "" Then
        '    Msg ("M00414")
        '    InputIsVaild = False
        '    cboCust2From.SetFocus
        '    Exit Function
        'End If
        '
        'If cboCust2To.Text = "" And cboCust2From.Text <> "" Then
        '    Msg ("M00414")
        '    InputIsVaild = False
        '    cboCust2To.SetFocus
        '    Exit Function
        'End If
        '' ------------------------------

        'If CDate(txtDateFrom.Text) > CDate(Me.txtDateTo.Text) Then
        '    msg("M00415")
        '    InputIsVaild = False
        '    txtDateFrom.SetFocus()
        '    Exit Function
        'End If

        'InputIsVaild = True
    End Function

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------



        If cboCustFrom.Text = "" And cboCustTo.Text = "" Then
            MsgBox("Please select Customer")
            cboCustFrom.Focus()
            Exit Sub
        End If

        If txtDateFrom.Text <> "  /  /" And txtDateTo.Text <> "  /  /" Then
            If IsDate(txtDateFrom.Text) = True And IsDate(txtDateTo.Text) = True Then
                If CDate(txtDateFrom.Text) > CDate(Me.txtDateTo.Text) Then
                    MsgBox("Invalid Date Range")

                    txtDateFrom.Focus()
                    Exit Sub
                End If
            Else
                MsgBox("Invalid Date")
                If IsDate(txtDateFrom.Text) = False Then
                    txtDateFrom.Focus()
                ElseIf IsDate(txtDateTo.Text) = False Then
                    txtDateTo.Focus()
                End If
            End If
        End If


        '' 2004/02/12 Lester Wu ---------------------------------
        'Dim secCNF As String
        'Dim secCNT As String
        'secCNF = ""
        'If InStr(Me.cboCust2From.Text, " - ") > 0 Then
        '    secCNF = Split(Me.cboCust2From.Text, " - ")(0)
        'End If
        'secCNT = ""
        'If InStr(Me.cboCust2To.Text, " - ") > 0 Then
        '    secCNT = Split(Me.cboCust2To.Text, " - ")(0)
        'End If
        '' -------------------------------------------------------
        Dim S As String
        Dim opt As String


        ' 2004/02/17 Lester
        Dim optSecCust As String
        If optSecYes.Checked = True Then
            optSecCust = "Y"
        Else
            optSecCust = "N"
        End If
        '-------------------------------

        If OptCust.Checked = True Then
            opt = "Customer"
        Else
            opt = "Earliest Ship Date"
        End If

        '    S = "㊣MSR00012※S※" & Split(cboCustFrom.Text, " - ")(0) & _
        '        "※" & Split(cboCustTo.Text, " - ")(0) & _
        '        "※" & Format(txtDateFrom.Text, "MM-DD-YYYY") & _
        '        "※" & Format(txtDateTo.Text, "MM-DD-YYYY") & _
        '        "※" & OPT
        '' 2004/02/12
        '    S = "㊣MSR00012※S" & _
        '        "※" & Split(cboCustFrom.Text, " - ")(0) & _
        '        "※" & Split(cboCustTo.Text, " - ")(0) & _
        '        "※" & secCNF & _
        '        "※" & secCNT & _
        '        "※" & Format(txtDateFrom.Text, "MM-DD-YYYY") & _
        '        "※" & Format(txtDateTo.Text, "MM-DD-YYYY") & _
        '        "※" & OPT
        ' 2004/02/17

        Dim datefrom As String
        Dim dateto As String

        If txtDateFrom.Text = "  /  /" Then
            datefrom = Format(Date.Now, "MM-dd-yyyy")
        Else
            datefrom = txtDateFrom.Text
        End If

        If txtDateTo.Text = "  /  /" Then
            dateto = Format(Date.Now, "MM-dd-yyyy")
        Else
            dateto = txtDateTo.Text
        End If

        gspStr = "sp_select_MSR00012_NET '" & cboCocde.Text & _
            "','" & Split(cboCustFrom.Text, " - ")(0) & _
            "','" & Split(cboCustTo.Text, " - ")(0) & _
            "','" & optSecCust & _
            "','" & datefrom & _
            "','" & dateto & _
            "','" & opt & _
            "','" & gsSalTem & "'"

        Me.Cursor = Cursors.WaitCursor

        'Relocation to report server
        '    rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        rtnLong = execute_SQLStatement(gspStr, rs_MSR00012, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_MSR00012:" & rtnStr)
            Exit Sub
        Else

            If rs_MSR00012.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Cursors.Default

                MsgBox("No Record Found")
                Exit Sub
            Else
                '**************Sorting************************
                Dim Sort_rs As New DataSet
                Dim dv As New DataView

                If OptCust.Checked = True Then
                    dv = rs_MSR00012.Tables("RESULT").DefaultView
                    dv.Sort = "soh_cus1nam,soh_cus2nam asc"
                    Sort_rs.Tables.Add(dv.ToTable("RESULT"))
                    ' rs_MSR00012.sort = "soh_cus1nam,soh_cus2nam"
                ElseIf OptEShp.Checked = True Then
                    dv = rs_MSR00012.Tables("RESULT").DefaultView
                    dv.Sort = "sod_shpstr asc"
                    Sort_rs.Tables.Add(dv.ToTable("RESULT"))
                    'rs_MSR00012.sort = "sod_shpstr"
                End If

                If Me.optExcelN.Checked = True Then

                    Dim objRpt As New MSR00012Rpt
                    objRpt.SetDataSource(rs_MSR00012.Tables("RESULT"))

                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()

                    'ReportName(0) = "MSR00012.rpt"
                    'ReportRS(0) = rs_MSR00012
                    'frmReport.Show()
                Else
                    rs_EXCEL = rs_MSR00012
                    Call CmdExportExcel_Click()
                End If
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub


    Private Function CmdExportExcel_Click()

        On Error GoTo Err_Handler

        Me.Cursor = Cursors.WaitCursor  ' Change mouse pointer to hourglass.
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
        Dim ttlUSD As Double
        Dim ttlHKD As Double
        Dim strCurr As String
        Dim bolSecCust As Boolean
        'Dim bolPO As Boolean
        Dim strCompany As String
        Dim strTitle As String
        strCurr = ""
        ttlUSD = 0
        ttlHKD = 0
        intGroup = 0
        indexCol = 1
        HdrRow = 6
        DtlRow = 8
        'xxxxxxxxxxx


        'Create an instance of Excel and add a workbook
        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        'Display Excel and give user control of Excel's lifetime
        xlApp.Visible = True
        xlApp.UserControl = True






        '==========================================================
        'xxxxxxxxxxxxxxxxxxxxx< Title Start >xxxxxxxxxxxxxxxxxxxxxx
        strCompany = ""
        strTitle = "Outstanding Order Report By Customer"

        '
        'Select Case rs_EXCEL.Fields(enuCust.cocde_enu)
        '    Case "UCP"
        '            strCompany = "UCP INTERNATIONAL CO., LTD."
        '    Case "UCPP"
        '            strCompany = "UNITED CHINESE PLASTICS PRODUCTS CO., LTD."
        '    Case "PG"
        '            strCompany = "Pacific Global Enterprises Limited"
        '    Case "ALL"
        '            strCompany = "UNITED CHINESE GROUP"
        'End Select

        strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuCust.compName)

        With xlWs
            '
            'Report ID
            .Cells(1, 15) = "Report ID"
            .Cells(1, 16) = ":"
            .Cells(1, 17) = "MSR00012"

            'Date
            .Cells(2, 15) = "Date"
            .Cells(2, 16) = ":"
            .Cells(2, 17) = Format(Now, "MM/dd/yyyy")
            .Range(.Cells(2, 17), .Cells(2, 17)).NumberFormatLocal = "mm/dd/yyyy"
            'Time
            .Cells(3, 15) = "Time"
            .Cells(3, 16) = ":"
            .Cells(3, 17) = Format(Now, "HH:mm:ss")
            .Range(.Cells(3, 17), .Cells(3, 17)).NumberFormatLocal = "HH:MM:SS"
            'Page
            .Cells(4, 15) = "Page"
            .Cells(4, 16) = ":"
            .Cells(4, 17) = "1 of 1"

            'Input Parameter
            'Customer No
            .Cells(4, 1) = "Pri. Customer No :"
            .Cells(4, 3) = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuCust.CustFrom_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(enuCust.CustTo_enu)
            '    IIf(rs_excel.Fields(enuCust.CustFrom_enu) = "" And rs_excel.Fields(enuCust.CustTo_enu) = "", "ALL", _
            '                    IIf(rs_excel.Fields(enuCust.CustFrom_enu) = rs_excel.Fields(enuCust.CustTo_enu), rs_excel.Fields(enuCust.CustFrom_enu), _
            '                    rs_excel.Fields(enuCust.CustFrom_enu) & " - " & rs_excel.Fields(enuCust.CustTo_enu)))

            'Print. Secondary
            .Cells(4, 5) = "Print Secondary Customer:"
            .Cells(4, 7) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(enuCust.SecCust_enu) = "Y", "Yes", "No")

            'Ship Date
            .Cells(4, 8) = "Ship Date :"
            .Cells(4, 10) = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuCust.DateFrom_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(enuCust.DateTo_enu)


            'Sort By
            .Cells(4, 12) = "Sort By :"
            .Cells(4, 13) = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuCust.Sort_enu)



            'defalut aligment
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 17)).HorizontalAlignment = 2
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 17)).VerticalAlignment = 3
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 17)).Font.Size = 10

            'COmpany
            .Range(.Cells(1, 4), .Cells(1, 13)).Merge()
            .Range(.Cells(1, 4), .Cells(1, 13)).Value = strCompany
            .Range(.Cells(1, 4), .Cells(1, 13)).RowHeight = 25
            .Range(.Cells(1, 4), .Cells(1, 13)).Font.Size = 12
            .Range(.Cells(1, 4), .Cells(1, 13)).Font.Bold = True
            .Range(.Cells(1, 4), .Cells(1, 13)).HorizontalAlignment = 3
            'Report Title
            .Range(.Cells(2, 4), .Cells(2, 13)).Merge()
            .Range(.Cells(2, 4), .Cells(2, 13)).Value = strTitle
            .Range(.Cells(2, 4), .Cells(2, 13)).Font.Size = 10
            .Range(.Cells(2, 4), .Cells(2, 13)).HorizontalAlignment = 3

        End With
        'xxxxxxxxxxxxxxxxxxxxx< Title End >xxxxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        '==========================================================
        'xxxxxxxxxxxxxxxxxxxx< Row Header Start>xxxxxxxxxxxxxxxxxxxx
        With xlWs

            .Cells(HdrRow + 1, indexCol) = "Primary Customer"
            .Cells(HdrRow + 1, indexCol + 3) = "Secondary Customer"
            .Cells(HdrRow + 1, indexCol + 6) = "Currency"
            .Cells(HdrRow + 1, indexCol + 8) = "Oustanding Amt"
            .Cells(HdrRow + 1, indexCol + 10) = "Earliest Ship Date"
            .Cells(HdrRow + 1, indexCol + 12) = "Latest Ship Date"
            .Cells(HdrRow + 1, indexCol + 14) = "Last Order Date"
            .Cells(HdrRow + 1, indexCol + 16) = "Last Invoice Date"

            '--------------------
            .Range(.Cells(HdrRow + 1, indexCol + 6), .Cells(HdrRow + 1, indexCol + 6)).HorizontalAlignment = 3 'Currency
            .Range(.Cells(HdrRow + 1, indexCol + 8), .Cells(HdrRow + 1, indexCol + 8)).HorizontalAlignment = 4 'Oustanding Amt
            .Range(.Cells(HdrRow + 1, indexCol + 10), .Cells(HdrRow + 1, indexCol + 10)).HorizontalAlignment = 4 'Earliest Ship Date
            .Range(.Cells(HdrRow + 1, indexCol + 12), .Cells(HdrRow + 1, indexCol + 12)).HorizontalAlignment = 4 'Latest Ship Date
            .Range(.Cells(HdrRow + 1, indexCol + 14), .Cells(HdrRow + 1, indexCol + 14)).HorizontalAlignment = 4 'Last Order Date
            .Range(.Cells(HdrRow + 1, indexCol + 16), .Cells(HdrRow + 1, indexCol + 16)).HorizontalAlignment = 4 'Last Invoice Date
            '--------------------
        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Header End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        'xxxxxxxxxxxxxxxxxxxx< Row Detail Start >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................
        recCount = rs_EXCEL.Tables("RESULT").Rows.Count - 1
        With xlWs

            For i = 0 To recCount
                .Cells(DtlRow + i, indexCol) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.soh_cus1no_enu) ' "Primary Customer"
                .Cells(DtlRow + i, indexCol + 1) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.soh_cus1nam_enu) ' "Primary Customer"

                .Cells(DtlRow + i, indexCol + 3) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.soh_cus2no_enu) '"Secondary Customer"
                .Cells(DtlRow + i, indexCol + 4) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.soh_cus2nam_enu) '"Secondary Customer"
                .Cells(DtlRow + i, indexCol + 6) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.soh_curcde_enu) '"Currency"
                .Cells(DtlRow + i, indexCol + 8) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.sod_OrdAmt_enu) '"Oustanding Amt"
                .Cells(DtlRow + i, indexCol + 10) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.sod_Eshp_enu) '"Earliest Ship Date"
                .Cells(DtlRow + i, indexCol + 12) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.sod_Lshp_enu) '"Latest Ship Date"
                .Cells(DtlRow + i, indexCol + 14) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.sod_LOrd_enu) '"Last Order Date"
                .Cells(DtlRow + i, indexCol + 16) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.sod_LInv_enu) '"Last Invoice Date"
                ttlUSD = ttlUSD + rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.TotalUSD_enu)
                ttlHKD = ttlHKD + rs_EXCEL.Tables("RESULT").Rows(i).Item(enuCust.TotalHKD_enu)

            Next

            'Total Amt
            .Cells(DtlRow + recCount + 1, indexCol + 5) = "Grand Total :"
            .Cells(DtlRow + recCount + 1, indexCol + 6) = "HKD"
            .Cells(DtlRow + recCount + 1, indexCol + 8) = ttlHKD
            .Cells(DtlRow + recCount + 2, indexCol + 6) = "USD"
            .Cells(DtlRow + recCount + 2, indexCol + 8) = ttlUSD
            .Cells(DtlRow + recCount + 3, indexCol + 8) = "- END -"

            '------------

            'Dtl rows Format
            .Range(.Cells(DtlRow, indexCol + 8), .Cells(DtlRow + recCount + 2, indexCol + 8)).NumberFormatLocal = "#,##0.00_ "  'Oustanding Amt
            .Range(.Cells(DtlRow, indexCol + 10), .Cells(DtlRow + recCount + 1, indexCol + 10)).NumberFormatLocal = "mm/dd/yyyy"  'Earliest Ship Date
            .Range(.Cells(DtlRow, indexCol + 12), .Cells(DtlRow + recCount + 1, indexCol + 12)).NumberFormatLocal = "mm/dd/yyyy"  'Latest Ship Date
            .Range(.Cells(DtlRow, indexCol + 14), .Cells(DtlRow + recCount + 1, indexCol + 14)).NumberFormatLocal = "mm/dd/yyyy"  'Last Order Date
            .Range(.Cells(DtlRow, indexCol + 16), .Cells(DtlRow + recCount + 1, indexCol + 16)).NumberFormatLocal = "mm/dd/yyyy"  'Last Invoice Date

            '----------------
        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Detail End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        'xxxxxxxxxxxxxxxxxxxx< Detail Style Start>xxxxxxxxxxxxxxxxxxxxxx
        '============================================================
        With xlWs

            .Columns.ColumnWidth = 10
            '    'Column Header
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 1, indexCol + 16)).Font.Bold = True
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 1, indexCol + 16)).Font.Size = 9
            'Row Detail
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 2, indexCol + 16)).Font.Size = 8
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 4, indexCol + 16)).Font.Size = 8
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 4, indexCol + 16)).RowHeight = 15
        End With
        'xxxxxxxxxxxxxxxxxxxx< Detail Style End >xxxxxxxxxxxxxxxxxxxxxx
        '............................................................

        'Aligment of Header and Detail
        With xlWs
            .Range(.Cells(HdrRow + 1, indexCol + 6), .Cells(DtlRow + recCount + 2, indexCol + 6)).HorizontalAlignment = 3 'Currency
            .Range(.Cells(HdrRow + 1, indexCol + 8), .Cells(DtlRow + recCount + 2, indexCol + 8)).HorizontalAlignment = 4 'Oustanding Amt
            .Range(.Cells(HdrRow + 1, indexCol + 10), .Cells(DtlRow + recCount + 1, indexCol + 10)).HorizontalAlignment = 4 'Earliest Ship Date
            .Range(.Cells(HdrRow + 1, indexCol + 12), .Cells(DtlRow + recCount + 1, indexCol + 12)).HorizontalAlignment = 4 'Latest Ship Date
            .Range(.Cells(HdrRow + 1, indexCol + 14), .Cells(DtlRow + recCount + 1, indexCol + 14)).HorizontalAlignment = 4 'Last Order Date
            .Range(.Cells(HdrRow + 1, indexCol + 16), .Cells(DtlRow + recCount + 1, indexCol + 16)).HorizontalAlignment = 4 'Last Invoice Date


            .Range(.Cells(DtlRow + recCount + 1, indexCol + 5), .Cells(DtlRow + recCount + 1, indexCol + 5)).Font.Bold = True '"Grand Total :"
            .Range(.Cells(DtlRow + recCount + 3, indexCol + 7), .Cells(DtlRow + recCount + 3, indexCol + 7)).HorizontalAlignment = 3 '"- END -"

        End With
        '-----------------------------



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
        'xlApp.selection.CurrentRegion.Columns.AutoFit

        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


        Me.Cursor = Cursors.Default ' Return mouse pointer to normal.

        Exit Function

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Me.Cursor = Cursors.Default ' Return mouse pointer to normal.

        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing


        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Function
End Class