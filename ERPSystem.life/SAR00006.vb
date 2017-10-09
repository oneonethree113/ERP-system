Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.IO
'Imports System.Text

Public Class SAR00006

    Private Enum SAREQ_enum
        vbi_venno_enum
        vbi_vensna_enum
        vbi_vennam_enum
        salPeron_enum
        ysr_saltem_enum
        Unit_enum
        cbi_cussna_enum
        cbi_cusnam_enum
        srh_cocde_enum
        srh_subcde_enum
        srh_reqno_enum
        srh_issdat_enum
        srh_rvsdat_enum
        srh_venno_enum
        srh_venadr_enum
        srh_venstt_enum
        srh_vencty_enum
        srh_venpst_enum
        srh_venctp_enum
        srh_salrep_enum
        srh_cus1no_enum
        srh_cussmppo_enum
        srh_vendeldat_enum
        srh_rmk_enum
        optSrh_Rmk_enum
        srh_vendeldatDD_enum
        srh_vendeldatMM_enum
        srd_reqseq_enum
        srd_engdsc_enum
        srd_chndsc_enum
        srd_cusitm_enum
        srd_itmno_enum
        srd_venitm_enum
        srd_vencol_enum
        srd_coldsc_enum
        srd_untcde_enum
        srd_smpunt_enum
        srd_smpqty_enum
        samplesQty_enum
        srd_note_enum
        srd_tbm_enum
        srh_tel_enum
        srh_fax_enum
        ShowCnt_enum
        srd_prdven_enum
        srd_prdsub_enum
        prdvensna_enum
        sort_enum
        yco_conam_enum
        yco_addr_enum
        yco_conamc_enum
        yco_addrc_enum
        yco_phoneno_enum
        yco_faxno_enum
        yco_logoimgpth_enum
    End Enum

    Dim SAreqno As String
    Dim CoCde As String

    Public rs_SAR00006 As DataSet
    Dim rs_EXCEL As DataSet
    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub SAR00006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)        'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        'AccessRight (Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        'AccessRight_1 (Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001 Change by Lewis on 2 Jul 2003
        'SAR00006.Width = 9750
        'SAR00006.Height = 4900
        cboReportFormat.Items.Add("Sample Request Report Format")
        cboReportFormat.Items.Add("Sample Request Excel Format")
        Call Formstartup(Me.Name)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged
        txtTo.Text = txtFm.Text
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim strExtInfo As String
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        If txtFm.Text = "" Or txtTo.Text = "" Then
            MsgBox("Request No empty !")
            Exit Sub
        End If
        Dim PrintDI As String
        'If optPDIY.checked = True Then
        '    PrintDI = "1"
        'Else
        '    PrintDI = "0"
        'End If
        PrintDI = "1"
        Dim PrintDV As String
        'If optPDVY.checked = True Then
        '    PrintDV = "1"
        'Else
        '    PrintDV = "0"
        'End If
        PrintDV = "1"
        Dim sort As String
        sort = "SEQ"
        If optSortItmNo.Checked = True Then
            sort = "ITM"
        End If
        strExtInfo = "N"
        If optExtVenShow.Checked = True Then
            strExtInfo = "Y"
        End If
        gspStr = "sp_select_SAR00006 '" & gsCompany & "','" & txtFm.Text & "','" & _
    txtTo.Text & "','" & PrintDI & "','" & PrintDV & "','" & sort & "','" & strExtInfo & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAR00006, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading rs_SAR00006 cmdShow_Click : " & rtnStr)
            Exit Sub
        End If
        If rs_SAR00006.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No record found !")
            Exit Sub
        Else
            If cboReportFormat.Text = "Sample Request Report Format" Then
                rs_SAR00006.Tables("RESULT").Columns(3).ColumnName = "salPerson"
                rs_SAR00006.Tables("RESULT").Columns(38).ColumnName = "sampleQty"
                rs_SAR00006.Tables("RESULT").Columns(48).ColumnName = "yco_conam"
                rs_SAR00006.Tables("RESULT").Columns(49).ColumnName = "yco_addr"
                rs_SAR00006.Tables("RESULT").Columns(50).ColumnName = "yco_conamc"
                rs_SAR00006.Tables("RESULT").Columns(51).ColumnName = "yco_addrc"
                rs_SAR00006.Tables("RESULT").Columns(52).ColumnName = "yco_phoneno"
                rs_SAR00006.Tables("RESULT").Columns(53).ColumnName = "yco_faxno"
                rs_SAR00006.Tables("RESULT").Columns(43).ColumnName = "input_showcnt"
                rs_SAR00006.Tables("RESULT").Columns(47).ColumnName = "optSort"
                rs_SAR00006.Tables("RESULT").Columns(54).ColumnName = "yco_logoimgpth"


                Dim newColumn As DataColumn
                newColumn = Nothing
                Dim compLogo As Byte() = imageToByteArray(rs_SAR00006.Tables("RESULT").Rows(0)("yco_logoimgpth"))
                'Dim shpmrkM As Byte() = imageToByteArray(rs_SAR00007.Tables("RESULT").Rows(0)("psm_imgpth_M"))
                newColumn = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_SAR00006.Tables("RESULT").Columns.Add(newColumn)
                rs_SAR00006.Tables("RESULT").Columns("compLogo").ReadOnly = False
                For i As Integer = 0 To rs_SAR00006.Tables("RESULT").Rows.Count - 1
                    rs_SAR00006.Tables("RESULT").Rows(i)("compLogo") = compLogo
                Next
                rs_SAR00006.Tables("RESULT").Columns("compLogo").ReadOnly = True

                Dim objRpt As New SAR00006Rpt
                objRpt.SetDataSource(rs_SAR00006.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            Else
                rs_EXCEL = rs_SAR00006.Copy 'rs_EXCEL = CopyRS(rs_SAR00006)
                CmdExportExcel_Click()
            End If
        End If


    End Sub
    Private Sub CmdExportExcel_Click()
        On Error GoTo Err_Handler
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.ApplicationClass
        Dim xlWB As Excel.Workbook = Nothing
        Dim xlWS As Excel.Worksheet = Nothing
        Dim recCount As Long

        'xxxxxxxxxxx
        Dim strCocde As String
        Dim DtlRow As Long

        Dim i As Long
        Dim indexCol As Long
        Dim intGroup As Long
        Dim strGroup As String
        Dim tmpGroup As String
        'Dim bolPO As Boolean
        Dim strCompany As String
        Dim strTitle1 As String
        Dim strTitle2 As String

        Dim strAddress1 As String
        Dim strAddress2 As String

        Dim objCell As Object
        Dim objVbreaks As Object

        Dim intIndex As Integer
        Dim strSort As String
        Dim intRow As Integer
        Dim intRowLength As Integer
        Dim strShipRmk As String

        strSort = ""
        intGroup = 0
        indexCol = 1
        DtlRow = 8





        xlApp = New Excel.Application
        xlApp.Visible = True
        xlApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlWB = xlApp.Workbooks.Add()
        xlWS = xlWB.ActiveSheet



        '        '==========================================================
        '        'xxxxxxxxxxxxxxxxxxxxx< Title Start >xxxxxxxxxxxxxxxxxxxxxx

        strTitle1 = "樣品通知書"
        strTitle2 = "SAMPLE REQUEST"
        strSort = "(This sample request is print in " & IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.sort_enum) = "ITM", "Item #", "Input") & " sequence)"
        strCocde = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.srh_cocde_enum)


        strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_conam_enum)
        If strCocde = "UCP" Then
            strAddress1 = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_addrc_enum) + _
                            "   電話: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_phoneno_enum) + _
                            "   傳真: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_faxno_enum)
            strAddress2 = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_addr_enum) + _
                            "   Tel: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_phoneno_enum) + _
                            "   Fax: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_faxno_enum)
        Else
            strAddress1 = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_addr_enum)
            strAddress2 = "Tel: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_phoneno_enum) + _
                            "   Fax: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_faxno_enum)
        End If
        xlApp.UserControl = True

        With xlWs

            'COmpany Name
            .Range(.Cells(1, 1), .Cells(1, 16)).Merge()
            .Range(.Cells(1, 1), .Cells(1, 16)).Value = strCompany
            .Range(.Cells(1, 1), .Cells(1, 10)).RowHeight = 35
            .Range(.Cells(1, 1), .Cells(1, 10)).Font.Size = 20
            .Range(.Cells(1, 1), .Cells(1, 10)).Font.Bold = True
            .Range(.Cells(1, 1), .Cells(1, 10)).HorizontalAlignment = 2
            'Company Address
            .Range(.Cells(2, 1), .Cells(2, 10)).Merge()
            .Range(.Cells(2, 1), .Cells(2, 10)).Value = strAddress1
            .Range(.Cells(2, 1), .Cells(2, 10)).Font.Size = 8
            .Range(.Cells(2, 1), .Cells(2, 10)).HorizontalAlignment = 2
            .Range(.Cells(3, 1), .Cells(3, 10)).Merge()
            .Range(.Cells(3, 1), .Cells(3, 10)).Value = strAddress2
            .Range(.Cells(3, 1), .Cells(3, 10)).Font.Size = 8
            .Range(.Cells(3, 1), .Cells(3, 10)).HorizontalAlignment = 2
            'Report Title
            .Range(.Cells(5, 6), .Cells(5, 10)).Merge()
            .Range(.Cells(5, 6), .Cells(5, 10)).Value = strTitle1
            .Range(.Cells(5, 6), .Cells(5, 10)).Font.Size = 22
            .Range(.Cells(5, 6), .Cells(5, 10)).HorizontalAlignment = 3
            .Range(.Cells(5, 6), .Cells(5, 10)).RowHeight = 30
            .Range(.Cells(6, 6), .Cells(6, 10)).Merge()
            .Range(.Cells(6, 6), .Cells(6, 10)).Value = strTitle2
            .Range(.Cells(6, 6), .Cells(6, 10)).Font.Size = 22
            .Range(.Cells(6, 6), .Cells(6, 10)).HorizontalAlignment = 3
            .Range(.Cells(6, 6), .Cells(6, 10)).RowHeight = 30
        End With
        'xxxxxxxxxxxxxxxxxxxxx< Title End >xxxxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        '==========================================================
        'xxxxxxxxxxxxxxxxxxxx< Row Header Start>xxxxxxxxxxxxxxxxxxxx

        'xxxxxxxxxxxxxxxxxxxx< Row Header End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        'xxxxxxxxxxxxxxxxxxxx< Row Detail Start >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................



        recCount = rs_EXCEL.Tables("RESULT").Rows.Count - 1

        With xlWS

            strGroup = ""
            tmpGroup = ""
            'lnghead = intGroup + i + DtlRow + 1


            For i = 0 To recCount

                tmpGroup = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_reqno_enum)
                If strGroup <> tmpGroup Then
                    'Show Footer
                    '.............................................................................................

                    If strGroup <> "" Then
                        'add code to show group footer here
                        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Merge()
                        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Value = strSort

                        If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) <> "UCPP" Then
                            .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Merge()
                            .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Value = _
                            "1.  每隻樣品請貴廠用白色招紙寫上客號/本行貨號貼/掛在樣品上不可寫廠號或有廠之招紙或吊牌。" & vbCrLf & _
                            "2.  箱外請寫上客名及收貨人以供識別。" & vbCrLf & _
                            "3.  請貼  ''MADE IN CHINA''  招紙於樣品上。"
                            intGroup = intGroup + 7
                        End If
                        intGroup = intGroup + 4
                    End If
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    strGroup = tmpGroup
                    intIndex = 0
                    '+++++++++++++++ Address to Ship Mark ++++++++++++++++++++++++++++
                    '   Top Right
                    .Cells(intGroup + i + DtlRow, indexCol + 12) = "辦單編號"
                    .Cells(intGroup + i + DtlRow, indexCol + 13) = ":"
                    .Range(.Cells(intGroup + i + DtlRow, indexCol + 14), .Cells(intGroup + i + DtlRow, indexCol + 15)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow, indexCol + 14), .Cells(intGroup + i + DtlRow, indexCol + 15)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ysr_saltem_enum) & " - " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_reqno_enum)
                    .Range(.Cells(intGroup + i + DtlRow, indexCol + 14), .Cells(intGroup + i + DtlRow, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1


                    .Cells(intGroup + i + DtlRow + 1, indexCol + 12) = "SCS REF#"
                    .Cells(intGroup + i + DtlRow + 1, indexCol + 13) = ":"
                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 14), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 14), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1


                    .Cells(intGroup + i + DtlRow + 2, indexCol + 12) = "辦單日期"
                    .Cells(intGroup + i + DtlRow + 2, indexCol + 13) = ":"
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = Format(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rvsdat_enum), "MM/dd/yyyy")
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).NumberFormatLocal = "MM/dd/yyyy"
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).HorizontalAlignment = 2
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1

                    If strCocde = "UCPP" Then
                        .Cells(intGroup + i + DtlRow + 3, indexCol + 12) = "辦到日期"
                        .Cells(intGroup + i + DtlRow + 3, indexCol + 13) = ":"
                        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).Merge()
                        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).Value = Format(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_vendeldat_enum), "MM/dd/yyyy")
                        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).NumberFormatLocal = "MM/dd/yyyy"
                        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).HorizontalAlignment = 2
                        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                    End If

                    '   Left Hand Side
                    .Cells(intGroup + i + DtlRow + 1, indexCol) = "工廠"
                    .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Value = IIf(strCocde = "UCPP", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_vensna_enum), _
                                                                                                                                rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_vennam_enum) & IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_venno_enum) = "0005", " (" & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_subcde_enum) & ")", ""))
                    .Cells(intGroup + i + DtlRow + 2, indexCol) = "致"
                    .Cells(intGroup + i + DtlRow + 2, indexCol + 1) = ":"
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 2), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 2), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 2), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_venctp_enum)

                    .Cells(intGroup + i + DtlRow + 3, indexCol) = "由"
                    .Cells(intGroup + i + DtlRow + 3, indexCol + 1) = ":"
                    .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 2), .Cells(intGroup + i + DtlRow + 3, indexCol + 6)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 2), .Cells(intGroup + i + DtlRow + 3, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 2), .Cells(intGroup + i + DtlRow + 3, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.salPeron_enum) & IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ysr_saltem_enum) = "S", "", " - " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ysr_saltem_enum))


                    '   Right Hand Side

                    .Cells(intGroup + i + DtlRow + 2, indexCol + 7) = "客人名稱"
                    .Cells(intGroup + i + DtlRow + 2, indexCol + 8) = ":"
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 9), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 9), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 9), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.cbi_cussna_enum), _
                                                                                                                                IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_venno_enum) = "0005" Or rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_venno_enum) = "0007", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.cbi_cussna_enum), _
                                                                                                                               rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cus1no_enum)))

                    .Cells(intGroup + i + DtlRow + 3, indexCol + 7) = "客人單號"
                    .Cells(intGroup + i + DtlRow + 3, indexCol + 8) = ":"
                    .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 9), .Cells(intGroup + i + DtlRow + 3, indexCol + 11)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 9), .Cells(intGroup + i + DtlRow + 3, indexCol + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 9), .Cells(intGroup + i + DtlRow + 3, indexCol + 11)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cussmppo_enum)

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                    'Column Header

                    intGroup = intGroup + 3

                    If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ShowCnt_enum) = "Y" Then
                        .Cells(intGroup + i + DtlRow + 1, indexCol) = "電話號碼"
                        .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Merge()
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_tel_enum)

                        .Cells(intGroup + i + DtlRow + 1, indexCol + 7) = "傳真號碼"
                        .Cells(intGroup + i + DtlRow + 1, indexCol + 8) = ":"
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 9), .Cells(intGroup + i + DtlRow + 1, indexCol + 13)).Merge()
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 9), .Cells(intGroup + i + DtlRow + 1, indexCol + 13)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 9), .Cells(intGroup + i + DtlRow + 1, indexCol + 13)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_fax_enum)

                        intGroup = intGroup + 1
                    End If


                    If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.optSrh_Rmk_enum) = "Y" Then
                        .Cells(intGroup + i + DtlRow + 1, indexCol) = "整體備註"
                        .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 1), .Cells(intGroup + i + DtlRow + 1, indexCol + 1)).HorizontalAlignment = 2
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Merge()
                        '.Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).NumberFormatLocal = "@"
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rmk_enum)
                        intRow = getRowCount(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rmk_enum))
                        intRowLength = Len(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rmk_enum)) / 100
                        If intRow > 1 Or intRowLength > 1 Then
                            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).RowHeight = 17 * IIf(intRow >= intRowLength, intRow, intRowLength) + 20
                            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).WrapText = True
                            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).VerticalAlignment = 1
                        End If
                        intGroup = intGroup + 1
                    End If



                    If strCocde = "UCPP" Then
                        If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.optSrh_Rmk_enum) = "N" Then
                            .Cells(intGroup + i + DtlRow + 1, indexCol) = "整體備註"
                            .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
                            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 1), .Cells(intGroup + i + DtlRow + 1, indexCol + 1)).HorizontalAlignment = 2
                        End If
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                        intGroup = intGroup + 1
                    Else
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
                        .Range(.Cells(intGroup + i + DtlRow + 1, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = _
                        "下列各項為本公司寄客戶之新樣品/客戶落單後要求之先行樣品在 " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_vendeldatMM_enum) & _
                        " 月 " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_vendeldatDD_enum) & " 日 前交本 行.   (寄送本公司樣品 希請列出要求樣品客戶名字)"
                        intGroup = intGroup + 1
                    End If


                    .Cells(intGroup + i + DtlRow + 2, indexCol) = "編碼"

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", "廠貨號" & vbCrLf & "(永久)", "廠家貨號")

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", "廠貨號" & vbCrLf & "(作參考用須更改)", "本行貨號")


                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Value = "客人貨號"

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Value = "品稱"

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Value = "顏色"

                    .Cells(intGroup + i + DtlRow + 2, indexCol + 12) = "數量"

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 13), .Cells(intGroup + i + DtlRow + 2, indexCol + 13)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 13), .Cells(intGroup + i + DtlRow + 2, indexCol + 13)).Value = "生產工廠"

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = "備註"

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1

                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).RowHeight = 40
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).HorizontalAlignment = 3

                    intGroup = intGroup + 1

                End If
                intIndex = intIndex + 1
                .Cells(intGroup + i + DtlRow + 2, indexCol) = intIndex

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Merge()
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_venitm_enum)

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Merge()
                If strCocde <> "UCPP" Then
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_itmno_enum)
                Else
                    '{SAR00006_ttx.srd_tbm} <> "N" ;
                    If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_tbm_enum) <> "N" Then
                        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_venitm_enum)
                    End If
                End If

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).NumberFormatLocal = "@"

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Merge()
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_cusitm_enum)

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Merge()
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_engdsc_enum)

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Merge()
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Value = "" & IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) = "" Or rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) = "N/A", "", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) & _
                                                                                                                            IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) <> "" And rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum) <> "", vbCrLf, "")) & _
                                                                                                                            IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum) = "" Or rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum) = "N/A", "", " " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum))

                .Cells(intGroup + i + DtlRow + 2, indexCol + 12) = Trim(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.samplesQty_enum)) & " " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.Unit_enum)

                .Cells(intGroup + i + DtlRow + 2, indexCol + 13) = Trim(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.prdvensna_enum))

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum), _
                                                                                                                             IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_tbm_enum) = "Y", "Ref# :" & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_venitm_enum) & vbCrLf & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum), rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum)))

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).RowHeight = 60
                intRow = getRowCount(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum))
                intRowLength = Len(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum)) / 25
                If intRow > 4 Or intRowLength > 4 Then
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).RowHeight = 15 * IIf(intRow >= intRowLength, intRow, intRowLength)
                End If
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).HorizontalAlignment = 3
                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).VerticalAlignment = 3

                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).WrapText = True



                'rs_EXCEL.MoveNext()

            Next

            'Show Footer
            '.............................................................................................
            If strGroup <> "" Then
                'add code to show group footer here
                'xlApp.ActiveSheet.HPageBreaks.Add .Cells(intGroup + i + DtlRow + 3, indexCol + 10)
                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Merge()
                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Value = strSort

                If strCocde <> "UCPP" Then
                    .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Merge()
                    .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Value = _
                    "1.  每隻樣品請貴廠用白色招紙寫上客號/本行貨號貼/掛在樣品上不可寫廠號或有廠之招紙或吊牌。" & vbCrLf & _
                    "2.  箱外請寫上客名及收貨人以供識別。" & vbCrLf & _
                    "3.  請貼  ''MADE IN CHINA''  招紙於樣品上。"
                    intGroup = intGroup + 7
                End If
                intGroup = intGroup + 4
            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Detail End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................



        '++++++++++++++++++++< Detail Style Start>+++++++++++++++++++
        '============================================================
        With xlWS
            .Columns.ColumnWidth = 10
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount, indexCol + 15)).Font.Size = 10

            '.Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount, indexCol + 9)).HorizontalAlignment = 2
            '.Range(.Cells(DtlRow, indexCol + 5), .Cells(intGroup + DtlRow + recCount, indexCol + 5)).HorizontalAlignment = 3
        End With
        '++++++++++++++++++++< Detail Style End  >+++++++++++++++++++
        '............................................................




        Dim lngPages As Long

        'Max FitToPagesTall of Excel = 9999
        lngPages = recCount / 6 + 2
        If lngPages > 9999 Then
            lngPages = 9999
        End If
        'Set print options

        'With xlWS.PageSetup
        '.Zoom = False
        '    .TopMargin = 5

        '    .FitToPagesWide = 1
        '    .FitToPagesTall = lngPages
        '    .Orientation = Excel.XlPageOrientation.xlLandscape
        '    .CenterFooter = "Page  &P  of  &N "
        'End With

        'xlWs.Close
        'xlApp.Quit


        rs_EXCEL = Nothing

        ' Release Excel references
        xlWS = Nothing
        xlWB = Nothing
        xlApp = Nothing



        'With Screen
        '    Me.Move (.Width - Width) \ 2, (.Height - Height) \ 2
        'End With

        Me.Cursor = Windows.Forms.Cursors.Default ' Return mouse pointer to normal.

        Exit Sub

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Me.Cursor = Windows.Forms.Cursors.Default ' Return mouse pointer to normal.

        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing


        ' Release Excel references
        xlWS = Nothing
        xlWB = Nothing
        xlApp = Nothing
    End Sub
    Function getRowCount(ByVal str As String) As Integer
        Dim i
        i = 0
        If InStr(str, Chr(10)) > 0 Then
            i = getRowCount(Strings.Right(str, Len(str) - InStr(str, Chr(10)))) + 1
        End If
        getRowCount = i
    End Function
    Private Sub AddImageColumn(ByVal objDataTable As DataTable, ByVal strFieldName As String)

        Dim objDataColumn As DataColumn = New DataColumn(strFieldName, Type.GetType("System.Byte[]"))
        objDataTable.Columns.Add(objDataColumn)

    End Sub

    Private Sub LoadImage(ByVal objDataRow As DataRow, ByVal strImageField As String, ByVal FilePath As String)

        'Dim fs As FileStream = New FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        'dim Image As byte[] = new byte[fs.Length]
        'fs.Read(Image, 0, Convert.ToInt32(fs.Length))
        'fs.Close()
        'objDataRow([strImageField] = Image)

        '===
        '        FileStream fs = new FileStream(FilePath, 
        '           System.IO.FileMode.Open, System.IO.FileAccess.Read);
        'byte[] Image = new byte[fs.Length];
        'fs.Read(Image, 0, Convert.ToInt32(fs.Length));
        'fs.Close();
        'objDataRow[strImageField] = Image;

        '===
    End Sub
    Private Function imageToByteArray(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If ImageFilePath = "" Then
            Return Nothing
        End If
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub callBySAM01(ByVal SAQno As String, ByVal ComparyCode As String)
        SAreqno = SAQno
        CoCde = ComparyCode
        'Hints: In .net, 'Shown' event is called after 'Load' event
        AddHandler Me.Shown, AddressOf callBySAM01AfterLoading
        Me.ShowDialog()

    End Sub

    Private Sub callBySAM01AfterLoading()


        txtFm.Text = SAreqno
        txtTo.Text = SAreqno
        txtFm.Enabled = False
        txtTo.Enabled = False

        cboCoCde.SelectedItem = CoCde
        cboCoCde.Enabled = False
        RemoveHandler Me.Shown, AddressOf callBySAM01AfterLoading
    End Sub
End Class