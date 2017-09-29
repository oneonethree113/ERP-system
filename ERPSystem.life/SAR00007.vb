Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.IO
'Imports System.Text

Public Class SAR00007
    Public rs_SAR00007 As DataSet
    Public rs_EXCEL As DataSet
    Dim CoCde As String
    Public Enum enuPack
        sih_invno_enu
        sih_cocde_enu
        sih_cus1no_enu
        sih_cus1ad_enu
        sih_cus1st_enu
        sih_cus1cy_enu
        sih_cus1zp_enu
        sih_cus1cp_enu
        sih_rvsdat_enu
        sih_shprmk_enu
        sih_rmk_enu
        sid_itmno_enu
        sid_smpunt_enu
        sid_colcde_enu
        sid_shpqty_enu
        sid_shpqtyStr_enu
        cbi_cussna_enu
        cbi_cusnam_enu
        ysi_dsc_enu
        yco_conam
        yco_addr
        yco_addrC
        yco_phoneno
        yco_faxno
        yco_logoimgpth
    End Enum

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        If txtFm.Text = "" Or txtTo.Text = "" Then
            MsgBox("Invoice No empty !")
            Exit Sub
        End If



        gspStr = "sp_select_SAR00007 '" & gsCompany & "','" & txtFm.Text & "','" & txtTo.Text & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAR00007, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAR00007 cmdShow_Click  : " & rtnStr)
        ElseIf rs_SAR00007.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No record found !")
        Else
            If Me.cboReportFormat.SelectedIndex = 1 Then
                rs_EXCEL = rs_SAR00007.Copy 'rs_EXCEL = CopyRS(rs_SAR00007)
                Call CmdExportExcel_Click()
            Else


                ' rs_SAR00007.Tables("RESULT").Columns(18).ColumnName = "smpunt"
                rs_SAR00007.Tables("RESULT").Columns(18).ColumnName = "smpunt"
                rs_SAR00007.Tables("RESULT").Columns(19).ColumnName = "yco_conam"
                rs_SAR00007.Tables("RESULT").Columns(20).ColumnName = "yco_addr"
                rs_SAR00007.Tables("RESULT").Columns(21).ColumnName = "yco_addrc"
                rs_SAR00007.Tables("RESULT").Columns(22).ColumnName = "yco_phoneno"
                rs_SAR00007.Tables("RESULT").Columns(23).ColumnName = "yco_faxno"
                rs_SAR00007.Tables("RESULT").Columns(24).ColumnName = "yco_logoimgpth"

                Dim newColumn As DataColumn
                newColumn = Nothing
                Dim compLogo As Byte() = imageToByteArray(rs_SAR00007.Tables("RESULT").Rows(0)("yco_logoimgpth"))
                'Dim shpmrkM As Byte() = imageToByteArray(rs_SAR00007.Tables("RESULT").Rows(0)("psm_imgpth_M"))
                newColumn = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_SAR00007.Tables("RESULT").Columns.Add(newColumn)
                rs_SAR00007.Tables("RESULT").Columns("compLogo").ReadOnly = False
                For i As Integer = 0 To rs_SAR00007.Tables("RESULT").Rows.Count - 1
                    rs_SAR00007.Tables("RESULT").Rows(i)("compLogo") = compLogo
                Next
                rs_SAR00007.Tables("RESULT").Columns("compLogo").ReadOnly = True

                Dim objRpt As New SAR00007Rpt
                objRpt.SetDataSource(rs_SAR00007.Tables("RESULT"))


                'TextBox1.Text = ""
                'For i As Integer = 0 To rs_SAR00007.Tables("RESULT").Columns.Count - 1
                '    TextBox1.Text = TextBox1.Text + rs_SAR00007.Tables("RESULT").Columns(i).ColumnName + " (" + i.ToString + ")= " + rs_SAR00007.Tables("RESULT").Rows(0).Item(i).ToString + vbCrLf
                'Next

                

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            End If
        End If
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged
        txtTo.Text = txtFm.Text
    End Sub

    Private Sub SAR00007_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        'SAR00007.Width = 9750
        'SAR00007.Height = 4805
        Call Formstartup(Me.Name)
        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        'If gsConnStr = "" Then
        '    gsConnStr = getConnectionString()
        'End If
        Me.cboReportFormat.Items.Clear()
        Me.cboReportFormat.Items.Add("Packing List Standard Format")
        Me.cboReportFormat.Items.Add("Packing List Export to Excel")
        Me.cboReportFormat.SelectedIndex = 0
        'Screen.MousePointer = vbDefault
    End Sub

    Private Sub CmdExportExcel_Click()
        On Error GoTo Err_Handler

        Me.Cursor = Windows.Forms.Cursors.WaitCursor ' Change mouse pointer to hourglass.
        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        Dim recCount As Long

        'xxxxxxxxxxx

        Dim HdrRow As Long
        Dim DtlRow As Long

        Dim DtlCol As Long
        Dim i As Long
        Dim indexCol As Long
        Dim intGroup As Long
        Dim strGroup As String
        Dim tmpGroup As String
        'Dim bolPO As Boolean
        Dim strCompany As String
        Dim strTitle As String
        Dim strAddress As String
        Dim strTel As String
        Dim intRowsShpMrk As Integer
        Dim intRowsAddr As Integer
        Dim objCell As Object
        Dim objVbreaks As Object
        'strCurr = ""
        'dblOS_Amt = 0
        'lngOS_Ctn = 0
        intGroup = 0
        indexCol = 1
        HdrRow = 5
        DtlRow = 6

        'xxxxxxxxxxx


        'Create an instance of Excel and add a workbook
        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        'Display Excel and give user control of Excel's lifetime
        xlApp.Visible = True
        '    xlApp.UserControl = True


        '==========================================================
        'xxxxxxxxxxxxxxxxxxxxx< Title Start >xxxxxxxxxxxxxxxxxxxxxx
        strCompany = ""
        strTitle = "Packing List"
        strAddress = ""
        strTel = ""

        'Lester Wu 2005-03-14 Retrieve company information form database instead of hardcode
        'Select Case rs_EXCEL.Fields(enuPack.sih_cocde_enu)
        '    Case "UCP"
        '            strCompany = "UCP INTERNATIONAL CO., LTD."
        '            strAddress = "Blk C, 3/F, Eldex Industrial Building, 21 Ma Tau Wai Road, Hung Hom, Kowloon, HK."
        '            strTel = "Tel: (852) 2334 2435        Fax: (852) 2764 0443 "
        '    Case "UCPP"
        '            strCompany = "UNITED CHINESE PLASTICS PRODUCTS CO., LTD."
        '            strAddress = "Blk C, 6/F, Eldex Industrial Building, 21 Ma Tau Wai Road, Hunghom, Kowloon, HK."
        '            strTel = "Tel: (852) 2362 4279       Fax: (852) 2765 8015 "
        '    Case "PG"
        '            strCompany = "Pacific Global Enterprises Limited"
        '            strAddress = "8/F, BLK. C, ELDEX IND'L BLDG., 21 MA TAU WAI RD., HUNGHOM, KLN., H.K."
        ''           strTel = "TEL: (852) 2363 9993  FAX: (852) 2333 3539   Email: akoo@pacificglobal.com.hk"
        '            strTel = "TEL: (852) 2363 9993  FAX: (852) 2333 3539"
        'End Select

        strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuPack.yco_conam)
        strAddress = rs_EXCEL.Tables("RESULT").Rows(0).Item(enuPack.yco_addr)
        strTel = "Tel: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(enuPack.yco_phoneno) + "        Fax: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(enuPack.yco_faxno)


        With xlWs
            'defalut aligment
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 10)).HorizontalAlignment = 2
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 10)).VerticalAlignment = 3
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 10)).Font.Size = 10

            'COmpany Name
            .Range(.Cells(1, 1), .Cells(1, 10)).Merge()
            .Range(.Cells(1, 1), .Cells(1, 10)).Value = strCompany
            .Range(.Cells(1, 1), .Cells(1, 10)).RowHeight = 35
            .Range(.Cells(1, 1), .Cells(1, 10)).Font.Size = 24
            .Range(.Cells(1, 1), .Cells(1, 10)).Font.Bold = True
            .Range(.Cells(1, 1), .Cells(1, 10)).HorizontalAlignment = 2
            'Company Address
            .Range(.Cells(2, 1), .Cells(2, 10)).Merge()
            .Range(.Cells(2, 1), .Cells(2, 10)).Value = strAddress
            .Range(.Cells(2, 1), .Cells(2, 10)).Font.Size = 12
            .Range(.Cells(2, 1), .Cells(2, 10)).HorizontalAlignment = 2
            'Company Tel
            .Range(.Cells(3, 1), .Cells(3, 10)).Merge()
            .Range(.Cells(3, 1), .Cells(3, 10)).Value = strTel
            .Range(.Cells(3, 1), .Cells(3, 10)).Font.Size = 12
            .Range(.Cells(3, 1), .Cells(3, 10)).HorizontalAlignment = 2
            'Report Title
            .Range(.Cells(5, 1), .Cells(5, 10)).Merge()
            .Range(.Cells(5, 1), .Cells(5, 10)).Value = strTitle
            .Range(.Cells(5, 1), .Cells(5, 10)).Font.Size = 20
            .Range(.Cells(5, 1), .Cells(5, 10)).HorizontalAlignment = 2
            .Range(.Cells(5, 1), .Cells(5, 10)).RowHeight = 30
        End With
        'xxxxxxxxxxxxxxxxxxxxx< Title End >xxxxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        '==========================================================
        'xxxxxxxxxxxxxxxxxxxx< Row Header Start>xxxxxxxxxxxxxxxxxxxx

        'xxxxxxxxxxxxxxxxxxxx< Row Header End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................






        'xxxxxxxxxxxxxxxxxxxx< Row Detail Start >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................
        '
        recCount = rs_EXCEL.Tables("RESULT").Rows.Count - 1





        With xlWs

            strGroup = ""
            tmpGroup = ""
            'lnghead = intGroup + i + DtlRow + 1

            For i = 0 To recCount

                tmpGroup = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_invno_enu)
                If strGroup <> tmpGroup Then
                    'Show Total Field
                    '.............................................................................................
                    If strGroup <> "" Then
                        .Cells(intGroup + i + DtlRow + 2, indexCol) = "Total"
                        .Cells(intGroup + i + DtlRow + 2, indexCol + 2) = "CTNS"
                        .Cells(intGroup + i + DtlRow + 2, indexCol + 4) = "CBM"
                        .Cells(intGroup + i + DtlRow + 2, indexCol + 6) = "KG"
                        .Cells(intGroup + i + DtlRow + 4, indexCol) = "This shipment contains no solid wood materials."
                        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 4, indexCol + 7)).Font.Bold = True
                        xlApp.ActiveSheet.HPageBreaks.Add.Cells(intGroup + i + DtlRow + 3, indexCol + 10)
                        intGroup = intGroup + 8
                    End If
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    strGroup = tmpGroup
                    '+++++++++++++++ Address to Ship Mark ++++++++++++++++++++++++++++
                    '   Left Hand Side
                    .Cells(intGroup + i + DtlRow + 2, indexCol) = "To"
                    .Cells(intGroup + i + DtlRow + 2, indexCol + 1) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.cbi_cussna_enu)
                    .Cells(intGroup + i + DtlRow + 4, indexCol + 1) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_cus1ad_enu) & "," & rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_cus1st_enu) & vbCrLf & _
                                                                      rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_cus1zp_enu) & "," & rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_cus1cy_enu)
                    .Range(.Cells(intGroup + i + DtlRow + 4, indexCol + 1), .Cells(intGroup + i + DtlRow + 4, indexCol + 4)).Merge()

                    '   Right Hand Side
                    .Cells(intGroup + i + DtlRow + 2, indexCol + 5) = "Date :"
                    .Cells(intGroup + i + DtlRow + 2, indexCol + 6) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_rvsdat_enu)
                    .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 6), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).NumberFormatLocal = "MM/dd/yyyy"
                    .Cells(intGroup + i + DtlRow + 4, indexCol + 5) = "Ship Mark :"
                    .Cells(intGroup + i + DtlRow + 4, indexCol + 6) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_shprmk_enu)
                    .Range(.Cells(intGroup + i + DtlRow + 4, indexCol + 6), .Cells(intGroup + i + DtlRow + 4, indexCol + 9)).Merge()

                    .Range(.Cells(intGroup + i + DtlRow + 4, indexCol), .Cells(intGroup + i + DtlRow + 4, indexCol + 9)).VerticalAlignment = 1
                    intRowsShpMrk = (getRowCount(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sih_shprmk_enu)) + 1)

                    .Range(.Cells(intGroup + i + DtlRow + 4, indexCol), .Cells(intGroup + i + DtlRow + 4, indexCol + 9)).RowHeight = IIf(intRowsShpMrk > 2, intRowsShpMrk, 3) * 12 + 10


                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    .Cells(intGroup + i + DtlRow + 6, indexCol) = "Cnt #"
                    .Cells(intGroup + i + DtlRow + 6, indexCol + 1) = "Item #"
                    .Cells(intGroup + i + DtlRow + 6, indexCol + 3) = "Color Cod"
                    .Cells(intGroup + i + DtlRow + 6, indexCol + 5) = "Qty"
                    .Cells(intGroup + i + DtlRow + 6, indexCol + 6) = "Unit"
                    .Cells(intGroup + i + DtlRow + 6, indexCol + 7) = "GW (KG)"
                    .Cells(intGroup + i + DtlRow + 6, indexCol + 8) = "Measurement(CM)"
                    .Range(.Cells(intGroup + i + DtlRow + 6, indexCol), .Cells(intGroup + i + DtlRow + 6, indexCol + 9)).Font.Bold = True

                    intGroup = intGroup + 6

                End If

                .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sid_itmno_enu)
                .Cells(intGroup + i + DtlRow + 1, indexCol + 3) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sid_colcde_enu)
                .Cells(intGroup + i + DtlRow + 1, indexCol + 5) = LTrim(rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sid_shpqtyStr_enu))
                .Cells(intGroup + i + DtlRow + 1, indexCol + 6) = rs_EXCEL.Tables("RESULT").Rows(i).Item(enuPack.sid_smpunt_enu)

                'rs_EXCEL.MoveNext()

            Next

            'Show Total Field
            '.............................................................................................
            If strGroup <> "" Then

                .Cells(intGroup + i + DtlRow + 2, indexCol) = "Total"
                .Cells(intGroup + i + DtlRow + 2, indexCol + 2) = "CTNS"
                .Cells(intGroup + i + DtlRow + 2, indexCol + 4) = "CBM"
                .Cells(intGroup + i + DtlRow + 2, indexCol + 6) = "KG"
                .Cells(intGroup + i + DtlRow + 4, indexCol) = "This shipment contains no solid wood materials."


                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 4, indexCol + 7)).Font.Bold = True
                '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 4, indexCol + 7)).Select

                intGroup = intGroup + 8
                '        lngHead = intGroup + i + DtlRow + 1
            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Detail End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................



        '++++++++++++++++++++< Detail Style Start>+++++++++++++++++++
        '============================================================
        With xlWs
            .Columns.ColumnWidth = 10
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount, indexCol + 9)).Font.Size = 9
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount, indexCol + 9)).HorizontalAlignment = 2
            .Range(.Cells(DtlRow, indexCol + 5), .Cells(intGroup + DtlRow + recCount, indexCol + 5)).HorizontalAlignment = 3
        End With
        '++++++++++++++++++++< Detail Style End  >+++++++++++++++++++
        '............................................................


        xlApp.UserControl = True

        Dim lngPages As Long

        'Max FitToPagesTall of Excel = 9999
        lngPages = recCount / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If
        'Set print options
        'With xlWs.PageSetup
        '.Zoom = False
        '    .TopMargin = 5

        '    .FitToPagesWide = 1
        '    .FitToPagesTall = lngPages
        '    .Orientation = Excel.XlPageOrientation.xlPortrait
        '    .CenterFooter = "Page  &P  of  &N "
        'End With


        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
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
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

    End Sub
    Function getRowCount(ByVal str As String) As Integer
        Dim i As Integer
        i = 0
        If InStr(str, Chr(10)) > 0 Then
            i = getRowCount(Strings.Right(str, Len(str) - InStr(str, Chr(10)))) + 1
        End If
        getRowCount = i
    End Function
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
    Public Sub callBySAM03(ByVal SAQno As String, ByVal ComparyCode As String)

        txtFm.Text = SAQno
        txtTo.Text = SAQno
        CoCde = ComparyCode
        'Hints: In .net, 'Shown' event is called after 'Load' event
        AddHandler Me.Shown, AddressOf callBySAM03AfterLoading
        Me.ShowDialog()

    End Sub

    Private Sub callBySAM03AfterLoading()

        txtFm.Enabled = False
        txtTo.Enabled = False

        cboCoCde.SelectedItem = CoCde
        cboCoCde.Enabled = False
        RemoveHandler Me.Shown, AddressOf callBySAM03AfterLoading
    End Sub
End Class