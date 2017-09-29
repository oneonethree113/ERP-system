Imports Microsoft.Office.Interop

Public Class IMR00030

    Dim rs_hdr As DataSet
    Dim rs_rpt As DataSet

    Dim col_inr As Integer
    Dim col_mtr As Integer
    Dim col_dvftycst As Integer
    Dim col_dvbomcst As Integer
    Dim col_dvftyprc As Integer
    Dim col_itmcst_bef As Integer
    Dim col_itmcst_aft As Integer
    Dim col_bomcst As Integer
    Dim col_ttlcst_bef As Integer
    Dim col_ttlcst_aft As Integer
    Dim col_credat As Integer
    Dim col_sapno As Integer
    Dim col_saplnno As Integer

    Private Sub IMR00030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        txtProcDatFm.Text = Format(Date.Now, "MM/dd/yyyy")
        txtProcDatTo.Text = Format(Date.Now, "MM/dd/yyyy")
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim strProcDatFm As String = ""
        Dim strProcDatTo As String = ""

        If txtProcDatFm.Text = "  /  /" Or txtProcDatFm.Text = "  /  /" Then
            MsgBox("Please input Process Date.")
            Exit Sub
        End If

        If txtProcDatFm.Text <> "  /  /" Then
            If IsDate(txtProcDatFm.Text) = False Then
                MsgBox("Invalid Date : Process Date From")
                txtProcDatFm.Focus()
                txtProcDatFm.SelectAll()
                Exit Sub
            Else
                strProcDatFm = txtProcDatFm.Text
            End If
        End If

        If txtProcDatTo.Text <> "  /  /" Then
            If IsDate(txtProcDatTo.Text) = False Then
                MsgBox("Invalid Date : Process Date To")
                txtProcDatTo.Focus()
                txtProcDatTo.SelectAll()
                Exit Sub
            Else
                strProcDatTo = txtProcDatTo.Text
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = "sp_select_IMR00030 '" & gsCompany & "','" & strProcDatFm & "','" & strProcDatTo & "','Y'"
        rs_hdr = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_hdr, rtnStr)
        gspStr = ""
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading IMR00030 #001 sp_select_IMR00030 : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_IMR00030 '" & gsCompany & "','" & strProcDatFm & "','" & strProcDatTo & "','N'"
        rs_rpt = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_rpt, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00030 #002 sp_select_IMR00030 : " & rtnStr)
            Exit Sub
        End If

        If rs_rpt.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
            Exit Sub
        Else
            ExportToExcel()
        End If
    End Sub

    Private Sub txtProcDatFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcDatFm.TextChanged
        txtProcDatTo.Text = txtProcDatFm.Text
    End Sub

    Private Sub ExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_rpt.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim headerRow As Integer = 1
        Dim headerCol As Integer = 1

        Try
            With xlsApp
                .Cells(headerRow, headerCol) = "Factory Data Batch Report"
                .Cells(headerRow, headerCol).Font.Bold = True
                .Cells(headerRow, headerCol).Font.Size = 20
                headerRow += 1

                headerCol += 11
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).MergeCells = True
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).Value = "CV"
                headerCol += 2
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).MergeCells = True
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).Value = "PV"
                headerCol += 2
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 3)).MergeCells = True
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 3)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 3)).Value = "DV"
                headerCol += 5
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).MergeCells = True
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).Value = "SC ITEM CST"
                headerCol += 3
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).MergeCells = True
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(headerRow, headerCol), .Cells(headerRow, headerCol + 1)).Value = "SC TTL CST"

                headerRow += 1
                headerCol = 1

                .Cells(headerRow, headerCol) = "Co."
                headerCol += 1
                .Cells(headerRow, headerCol) = "Job No#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Pri Cus"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Sec Cus"
                headerCol += 1
                .Cells(headerRow, headerCol) = "SC No#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "PO No#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Item#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "UM"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Inr"
                col_inr = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "Mtr"
                col_mtr = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "DV"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Before"
                headerCol += 1
                .Cells(headerRow, headerCol) = "After"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Before"
                headerCol += 1
                .Cells(headerRow, headerCol) = "After"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Curr."
                headerCol += 1
                .Cells(headerRow, headerCol) = "Item Cst"
                col_dvftycst = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "BOM Cst"
                col_dvbomcst = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "Ttl Cst"
                col_dvftyprc = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "Curr."
                headerCol += 1
                .Cells(headerRow, headerCol) = "Before"
                col_itmcst_bef = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "After"
                col_itmcst_aft = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "SC BOM CST"
                col_bomcst = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "Before"
                col_ttlcst_bef = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "After"
                col_ttlcst_aft = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "New PO No."
                headerCol += 1
                .Cells(headerRow, headerCol) = "Proc. Dat."
                col_credat = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "SAP No."
                col_sapno = headerCol
                headerCol += 1
                .Cells(headerRow, headerCol) = "SAP Ln. No."
                col_saplnno = headerCol

                .Range(.Cells(headerRow, 1), .Cells(headerRow, headerCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                'headerRow += 1

                Dim entry(29) As String
                Dim filter() As DataRow

                For i As Integer = 0 To rs_hdr.Tables("RESULT").Rows.Count - 1
                    entry(0) = rs_hdr.Tables("RESULT").Rows(i)("soh_cocde")
                    entry(1) = rs_hdr.Tables("RESULT").Rows(i)("sbd_jobord")
                    entry(2) = rs_hdr.Tables("RESULT").Rows(i)("soh_cus1no") & " - " & rs_hdr.Tables("RESULT").Rows(i)("pricussna")
                    If rs_hdr.Tables("RESULT").Rows(i)("soh_cus2no") <> "" Then
                        entry(3) = rs_hdr.Tables("RESULT").Rows(i)("soh_cus2no") & " - " & rs_hdr.Tables("RESULT").Rows(i)("seccussna")
                    Else
                        entry(3) = ""
                    End If
                    entry(4) = rs_hdr.Tables("RESULT").Rows(i)("sod_ordno")
                    entry(5) = rs_hdr.Tables("RESULT").Rows(i)("pod_purord")
                    entry(6) = rs_hdr.Tables("RESULT").Rows(i)("sod_itmno")
                    entry(7) = rs_hdr.Tables("RESULT").Rows(i)("sod_pckunt")
                    entry(8) = rs_hdr.Tables("RESULT").Rows(i)("sod_inrctn")
                    entry(9) = rs_hdr.Tables("RESULT").Rows(i)("sod_mtrctn")
                    entry(10) = rs_hdr.Tables("RESULT").Rows(i)("sod_dv")
                    entry(15) = rs_hdr.Tables("RESULT").Rows(i)("sod_dvfcurcde")
                    entry(16) = rs_hdr.Tables("RESULT").Rows(i)("sod_dvftycst")
                    entry(17) = rs_hdr.Tables("RESULT").Rows(i)("sod_dvbomcst")
                    entry(18) = rs_hdr.Tables("RESULT").Rows(i)("sod_dvftyprc")

                    filter = Nothing
                    filter = rs_rpt.Tables("RESULT").Select("sbd_lotno = '" & rs_hdr.Tables("RESULT").Rows(i)("sbd_lotno") & "' and sbd_jobord = '" & rs_hdr.Tables("RESULT").Rows(i)("sbd_jobord") & "'")
                    If filter.Length > 0 Then
                        For j As Integer = 0 To filter.Length - 1
                            Select Case filter(j).Item("sbd_chgtyp").ToString
                                Case "01"
                                    entry(20) = Format(CDbl(filter(j).Item("sbd_before")), "#0.0000")
                                    entry(21) = Format(CDbl(filter(j).Item("sbd_after")), "#0.0000")
                                Case "02"
                                    entry(23) = Format(CDbl(filter(j).Item("sbd_before")), "#0.0000")
                                    entry(24) = Format(CDbl(filter(j).Item("sbd_after")), "#0.0000")
                                Case "05"
                                    entry(11) = filter(j).Item("sbd_before")
                                    entry(12) = filter(j).Item("sbd_after")
                                Case "06"
                                    entry(13) = filter(j).Item("sbd_before")
                                    entry(14) = filter(j).Item("sbd_after")
                                Case ""
                                    entry(25) = Trim(Split(Split(filter(j).Item("yct_desc"), "-")(1), "/")(0))
                            End Select
                        Next

                        entry(19) = filter(0).Item("sod_fcurcde")
                        entry(22) = Format(CDbl(filter(0).Item("sod_bomcst")), "#0.0000")
                        entry(26) = Format(CDate(filter(0).Item("sbd_credat")), "MM/dd/yyyy")
                        entry(27) = filter(0).Item("sod_zorvbeln")
                        entry(28) = filter(0).Item("sod_zorposnr")
                    End If
                    .Range(.Cells(headerRow + i + 1, 1), .Cells(headerRow + i + 1, headerCol)).Value = entry
                Next

                'Styling
                .Range(.Cells(1, 1), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, headerCol)).Font.Name = "Arial"
                .Range(.Cells(2, 1), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, headerCol)).Font.Size = 8

                For i As Integer = 1 To 25
                    If i = 1 Then
                        .Columns(i).ColumnWidth = 5
                    Else
                        .Columns(i).EntireColumn.AutoFit()
                    End If
                Next
                .Columns(col_credat).ColumnWidth = 10.57
                .Columns(col_sapno).ColumnWidth = 9.14
                .Columns(col_saplnno).ColumnWidth = 8.43

                .Range(.Cells(headerRow + 1, col_inr), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_inr)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_mtr), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_mtr)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_dvftycst), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_dvftycst)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_dvbomcst), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_dvbomcst)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_dvftyprc), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_dvftyprc)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_itmcst_bef), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_itmcst_bef)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_itmcst_aft), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_itmcst_aft)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_bomcst), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_bomcst)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_ttlcst_bef), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_ttlcst_bef)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_ttlcst_aft), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_ttlcst_aft)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, col_credat), .Cells(headerRow + rs_hdr.Tables("RESULT").Rows.Count, col_credat)).HorizontalAlignment = Excel.Constants.xlRight
                .Rows(headerRow + 1 & ":" & headerRow + rs_hdr.Tables("RESULT").Rows.Count).EntireRow.AutoFit()
            End With

            Dim lngPages As Integer = (rs_hdr.Tables("RESULT").Rows.Count) / 20 + 1
            If lngPages > 9999 Then
                lngPages = 9999
            End If

            With xlsWS.PageSetup
                .Zoom = False
                .TopMargin = 10
                .LeftMargin = 0.2
                .RightMargin = 0.2
                .FitToPagesWide = 1
                .FitToPagesTall = lngPages
                .Orientation = Excel.XlPageOrientation.xlLandscape
                .PrintTitleRows = "$1:$4"
                .PrintTitleColumns = ""
                .CenterFooter = "Page &P of &N"
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Or ex.Message = "Exception from HRESULT: 0x800A03EC" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    ExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, Me.Name.ToString & " - Excel Error")
            End If
        End Try
        ' Release reference
        rs_hdr = Nothing
        rs_rpt = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class