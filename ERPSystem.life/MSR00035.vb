Public Class MSR00035

    Dim textboxlist As New Collection() 'a dictionary storing the index and the textbox object

    Dim ShipStrDateFrom As String
    Dim ShipStrDateTo As String
    Dim ShipEndDateFrom As String
    Dim ShipEndDateTo As String

    Dim rs_MSR00001 As DataSet
    Dim rs_EXCEL As DataSet


    Private Sub MSR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(cboCocde, txtCoNam)

        If gsDefaultCompany <> "MS" Then
            cboCocde.Items.Add("UC-G")
        End If

        Call AddSearchBtnHandler()
        cboSortBy.Items.Add("Customer PO#")
        cboSortBy.Items.Add("Ship Start Date")
        cboSortBy.Items.Add("Ship End Date")
        cboSortBy.SelectedIndex = 0

        cboGroupBy.Items.Add("Crystal Report - Base")
        cboGroupBy.Items.Add("Crystal Report - Detail")
        cboGroupBy.Items.Add("Excel - Type1")
        cboGroupBy.SelectedIndex = 0

        Call Formstartup(Me.Name)


    End Sub





    'Company Box Start
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
    'Company Box End

    'Cust No Start
    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_MSR00035(Me.cmd_S_PriCustAll)
    End Sub

    Private Sub cmd_S_SecCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCustAll.Name
        frmComSearch.callFmString = txt_S_SecCustAll.Text

        frmComSearch.show_MSR00035(Me.cmd_S_SecCustAll)
    End Sub

    Private Sub AddSearchBtnHandler()
        textboxlist.Add(txt_S_PriCustAll, "cmd_S_PriCustAll")
        textboxlist.Add(txt_S_SecCustAll, "cmd_S_SecCustAll")
        textboxlist.Add(txt_S_CustPONo, "cmd_S_CustPONo")
        textboxlist.Add(txt_S_SCNo, "cmd_S_SCNo")
        textboxlist.Add(txt_S_CustItmNo, "cmd_S_CustItmNo")
        textboxlist.Add(txt_S_ItmNo, "cmd_S_ItmNo")
        textboxlist.Add(txt_S_PV, "cmd_S_PV")
        textboxlist.Add(txt_S_FA, "cmd_S_FA")
        textboxlist.Add(txt_S_PriceTerm, "cmd_S_PriceTerm")

        AddHandler cmd_S_PriCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SecCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_CustPONo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SCNo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_CustItmNo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_ItmNo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PV.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_FA.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PriceTerm.Click, AddressOf cmd_S_Click

    End Sub

    Private Sub cmd_S_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim trigger_btn As Button = CType(sender, Button)
        Dim btn_name As String = trigger_btn.Name
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = textboxlist(btn_name).Name
        frmComSearch.callFmString = textboxlist(btn_name).Text
        frmComSearch.show_MSR00035(trigger_btn)
    End Sub
    'Cust End

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim flg_exit As Boolean = False

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)

        'Check any invalid Input and escape special character
        If CheckUsrInput() Then
            MsgBox("Generate Report Fail!")
            Exit Sub
        End If

        Dim PriCustList As String = txt_S_PriCustAll.Text.Replace("'", "''")
        Dim SecCustList As String = txt_S_SecCustAll.Text.Replace("'", "''")
        Dim CustPOList As String = txt_S_CustPONo.Text.Replace("'", "''")
        Dim SCNoList As String = txt_S_SCNo.Text.Replace("'", "''")
        Dim CustItmList As String = txt_S_CustItmNo.Text.Replace("'", "''")
        Dim ItemList As String = txt_S_ItmNo.Text.Replace("'", "''")
        Dim PVList As String = txt_S_PV.Text.Replace("'", "''")
        Dim FAList As String = txt_S_FA.Text.Replace("'", "''")
        Dim PriceTermList As String = txt_S_PriceTerm.Text.Replace("'", "''")

        Dim opt_sort As String
        If cboSortBy.Text = "Customer PO#" Then
            opt_sort = "C"
        ElseIf cboSortBy.Text = "Ship Start Date" Then
            opt_sort = "SS"
        Else
            opt_sort = "SE"
        End If

        Dim opt_group As String
        If cboGroupBy.Text = "Crystal Report - Base" Then
            opt_group = "CB"
        ElseIf cboGroupBy.Text = "Crystal Report - Detail" Then
            opt_group = "CD"
        ElseIf cboGroupBy.Text = "Excel - Type1" Then
            opt_group = "E1"
        End If

        Dim opt_unitprice As String
        If optNo.Checked Then
            opt_unitprice = "N"
        Else
            opt_unitprice = "Y"
        End If


        gspStr = "sp_select_MSR00001A '" & gsCompany & "','" & _
                    PriCustList & "','" & _
                    SecCustList & "','" & _
                    CustPOList & "','" & _
                    SCNoList & "','" & _
                    CustItmList & "','" & _
                    ItemList & "','" & _
                    PVList & "','" & _
                    FAList & "','" & _
                    PriceTermList & "','" & _
                    ShipStrDateFrom & "','" & _
                    ShipStrDateTo & "','" & _
                    ShipEndDateFrom & " ','" & _
                    ShipEndDateTo & "','" & _
                    opt_unitprice & "','" & _
                    opt_sort & "','" & _
                    opt_group & "','" & _
                    gsUsrID & "','" & _
                    gsSalTem & "'"

        Me.Cursor = Cursors.WaitCursor
        'Relocation to report server
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        rtnLong = execute_SQLStatementRPT(gspStr, rs_MSR00001, rtnStr)

        Me.Cursor = Cursors.Default

        '*** An error has occured
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_MSR00001:" & rtnStr)
            Exit Sub
        End If

        If rs_MSR00001.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No record found !")
            Exit Sub
        Else

            If opt_group = "CB" Then
                Dim objRpt As New MSR00001ARpt1

                objRpt.SetDataSource(rs_MSR00001.Tables("RESULT"))
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            ElseIf opt_group = "CD" Then
                Dim objRpt As New MSR00001ARpt2

                objRpt.SetDataSource(rs_MSR00001.Tables("RESULT"))
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            ElseIf opt_group = "E1" Then
                rs_EXCEL = rs_MSR00001
                Call GenExcel()
            End If

        End If




    End Sub

    Private Function CheckUsrInput() As Boolean
        For i As Integer = 1 To textboxlist.Count
            If (textboxlist(i).Text.Length > 1000) Then
                Dim tmp_labelname As String = "SLabel_" + i.ToString
                Dim label() As Control = GroupBox1.Controls.Find(tmp_labelname, True)

                'Me.Controls.Find(tmp_labelname, True)
                MsgBox(label(0).Text + " exceeds 1000 characters")
                Return True
            End If
        Next

        If txtShipFm.Text <> "  /  /" Then
            If Not IsDate(txtShipFm.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date From")
                txtShipFm.Focus()
                Return True
            End If
        Else

        End If

        If txtShipTo.Text <> "  /  /" Then
            If Not IsDate(txtShipTo.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date To")
                txtShipFm.Focus()
                Return True
            End If
        End If

        If txtShipEndFm.Text <> "  /  /" Then
            If Not IsDate(txtShipEndFm.Text) Then
                MsgBox("Invalid Date Format: SC Ship End Date From")
                txtShipEndFm.Focus()
                Return True
            End If
        End If

        If txtShipEndTo.Text <> "  /  /" Then
            If Not IsDate(txtShipEndTo.Text) Then
                MsgBox("Invalid Date Format: SC Ship End Date To")
                txtShipEndTo.Focus()
            End If
        End If

        ShipStrDateFrom = If(txtShipFm.Text = "  /  /", "01/01/1900", txtShipFm.Text)
        ShipStrDateTo = If(txtShipTo.Text = "  /  /", "01/01/2100", txtShipTo.Text)

        ShipEndDateFrom = If(txtShipEndFm.Text = "  /  /", "01/01/1900", txtShipEndFm.Text)
        ShipEndDateTo = If(txtShipEndTo.Text = "  /  /", "01/01/2100", txtShipEndTo.Text)


        If CDate(ShipStrDateFrom) > CDate(ShipStrDateTo) Then
            MsgBox("SC Ship Start Date From > SC Ship Start Date To")
            txtShipFm.Focus()
            Return True
        End If

        If CDate(ShipEndDateFrom) > CDate(ShipEndDateTo) Then
            MsgBox("SC Ship End Date From > SC Ship End Date To")
            txtShipEndFm.Focus()
            Return True
        End If

        Return False
    End Function

    Private Sub GenExcel()
        On Error GoTo Err_Handler

        Me.Cursor = Cursors.WaitCursor  ' Change mouse pointer to hourglass.
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet


        Dim my_table As DataTable = rs_EXCEL.Tables("RESULT")


        Dim prev_SC As String = "-1"
        Dim cnt_emptyrow As Integer = 0
        'Dim my_datarow() As DataRow = my_table.Select("sod_ordno, sod_ordseq, sod_shpstr, sod_shpend,sds_scfrom,sds_scto, sds_dest")

        'Display Excel and give user control of Excel's lifetime
        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)
        xlApp.Visible = True
        xlApp.UserControl = True

        Dim strCompany As String

        Dim header_row As Integer = 5
        Dim datastart_row As Integer = 6

        'strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item("compName")

        With xlWs
            '    '
            '    'Report ID
            '    .Cells(1, 14) = "Report ID"
            '    .Cells(1, 15) = ":"
            '    .Cells(1, 16) = "MSR00001"

            '    'Date
            '    .Cells(2, 14) = "Date"
            '    .Cells(2, 15) = ":"
            '    .Cells(2, 16) = Format(Now, "MM/dd/yyyy")
            '    .Range(.Cells(2, 16), .Cells(2, 16)).NumberFormatLocal = "mm/dd/yyyy"
            '    'Time
            '    .Cells(3, 14) = "Time"
            '    .Cells(3, 15) = ":"
            '    .Cells(3, 16) = Format(Now, "HH:mm:ss")
            '    .Range(.Cells(3, 16), .Cells(3, 16)).NumberFormatLocal = "HH:MM:SS"
            '    'Page
            '    .Cells(4, 14) = "Page"
            '    .Cells(4, 15) = ":"
            '    .Cells(4, 16) = "1 of 1"

            '    'Input Parameter
            '    'Pri Customer
            '    .Cells(4, 1) = "Customer"
            '    .Cells(4, 2) = ":"
            '    .Cells(4, 3) = If(my_table.rows(0).item("s_pricust") = "", "ALL", my_table.rows(0).item("s_pricust"))
            '    'Sec Customer
            '    .Cells(4, 5) = "Sec Customer"
            '    .Cells(4, 6) = ":"
            '    .Cells(4, 7) = If(my_table.rows(0).item("s_seccust") = "", "ALL", my_table.rows(0).item("s_seccust"))
            '    'Customer PO
            '    .Cells(4, 8) = "Customer PO"
            '    .Cells(4, 9) = ":"
            '    .Cells(4, 10) = If(my_table.rows(0).item("s_custpo") = "", "ALL", my_table.rows(0).item("s_custpo"))

            'Input Excel STart
            .Cells(1, 1) = "Report ID:"
            .Cells(1, 2) = "MSR00035"
            .Cells(1, 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight


            .Cells(2, 1) = "Print Date: "
            .Cells(2, 2) = Format(Now, "MM/dd/yyyy")
            .Range(.Cells(2, 2), .Cells(2, 2)).NumberFormatLocal = "mm/dd/yyyy"

            .Cells(3, 1) = "Print Time: "
            .Cells(3, 2) = Format(Now, "HH:mm:ss")
            .Range(.Cells(3, 2), .Cells(3, 2)).NumberFormatLocal = "HH:MM:SS"





            For i As Integer = 0 To excel_header.Length - 1
                .Cells(header_row, i + 1) = excel_header(i)
            Next

            For i As Integer = 0 To my_table.Rows.Count - 1
                'If i > 0 Then
                '    If my_table.Rows(i).Item("sod_ordno") <> prev_SC Then
                '        cnt_emptyrow = cnt_emptyrow + 1
                '    End If
                'End If

                For j As Integer = 0 To excel_header.Length - 1
                    .Cells(i + datastart_row + cnt_emptyrow, j + 1) = my_table.Rows(i).Item(excel_sqlcolname(j))
                Next
                prev_SC = my_table.Rows(i).Item("sod_ordno")
            Next
            'Input Data End

            'Apply Style Start
            xlWs.Cells(header_row, 1).EntireRow.Font.Bold = True
            xlWs.Cells.EntireColumn.AutoFit()

            Dim col_Desc As Integer = 10 'The DESCRIPTION Column
            xlWs.Cells(header_row, col_Desc).EntireColumn.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom

            'Apply Style End
        End With





        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        Me.Cursor = Cursors.Default
        Exit Sub

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
    End Sub

    Dim excel_header As String() = { _
                                    "S/C#", _
                                    "JOB#", _
                                    "PR#", _
                                    "CUST. PO#", _
                                    "RESP. PO#", _
                                    "VENDOR ITEM#", _
                                    "ITEM#", _
                                    "CUST. ITEM", _
                                    "SKU#", _
                                    "DESCRIPTION", _
                                    "TTL O/S QTY", _
                                    "", _
                                    "TTL O/S CTN", _
                                    "TTL O/S CBM", _
                                    "", _
                                    "UNIT PRICE", _
                                    "TTL AMOUNT", _
                                    "DETAILS O/S QTY", _
                                    "", _
                                    "DETAILS O/S CTN", _
                                    "DETAILS O/S CBM", _
                                    "DETAILS AMOUNT", _
                                    "DESTINATION(Header)", _
                                    "DESTINATION(Ship Dtl)", _
                                    "SHIPPING WINDOW(Detail)", _
                                    "SHIPPING WINDOW(Ship Dtl)", _
                                    "CANCEL DATE", _
                                    "PV", _
                                    "FA", _
                                    "PRICE TERM", _
                                    "PAYMENT TERM", _
                                    "DISCOUNT/PREMIUM", _
                                    "Field 1 Item Desc.", _
                                    "UM (Packing)", _
                                    "Inner (Packing)", _
                                    "Master (Packing)", _
                                    "HSTU#/Tariff" _
    }

    Dim excel_sqlcolname As String() = { _
        "sod_ordno", _
        "pod_jobord", _
        "sod_purord", _
        "sod_cuspo", _
        "sod_resppo", _
        "pod_venitm", _
        "sod_itmno", _
        "sod_cusitm", _
        "sod_cussku", _
        "sod_itmdsc", _
        "sod_ordqty", _
        "unit", _
        "sod_ttlctn", _
        "sod_cbm", _
        "soh_curcde", _
        "sod_untprc", _
        "sod_selprc", _
        "e1_ordqty", _
        "unit", _
        "e1_ttlctn", _
        "e1_cbm", _
        "e1_selprc", _
        "soh_dest", _
        "e1_dest", _
        "e1_shipwin1", _
        "e1_shipwin2", _
        "e1_candat", _
        "pvna", _
        "fana", _
        "soh_prctrm", _
        "paytrm_desc", _
        "DIS/PRE", _
        "e1_sod_dsc_f1", _
        "e1_sod_pckunt", _
        "e1_sod_inrctn", _
        "e1_sod_mtrctn", _
        "e1_sod_hrmcde" _
    }


End Class