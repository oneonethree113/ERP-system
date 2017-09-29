Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource

Public Class IAR00001

    Dim rs_IAR00001 As New DataSet
    Dim rs_IAR00002 As New DataSet
    Dim rs_IAR00002SUB As New DataSet
    Dim rs_IAR00003 As New DataSet

    Private Sub IAR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        Dim month As String
        Dim day As String
        month = "0" + Date.Today.Month.ToString
        day = "0" + Date.Today.Day.ToString
        txtTranFromDate.Text = month.Substring(month.Length - 2, 2) + "/" + day.Substring(day.Length - 2, 2) + "/" + CStr(Date.Today.Year)
        txtTranToDate.Text = month.Substring(month.Length - 2, 2) + "/" + day.Substring(day.Length - 2, 2) + "/" + CStr(Date.Today.Year)
        optByExcel.Select()
        txtItmNo.Focus()
        txtItmNo.Select()
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click

        If Not IsDate(txtTranFromDate.Text) And (optByExcel.Checked = True Or optByExcel_New.Checked = True) Then
            MsgBox("Invalid Transaction Date", MsgBoxStyle.Information, "Invalid Input Parameter")
            txtTranFromDate.Focus()
            txtTranFromDate.SelectAll()
            Exit Sub
        End If
        If Not IsDate(txtTranToDate.Text) And (optByExcel.Checked = True Or optByExcel_New.Checked = True) Then
            MsgBox("Invalid Transaction Date", MsgBoxStyle.Information, "Invalid Input Parameter")
            txtTranToDate.Focus()
            txtTranToDate.SelectAll()
            Exit Sub
        End If
        If CDate(txtTranFromDate.Text) > CDate(txtTranToDate.Text) And (optByExcel.Checked = True Or optByExcel_New.Checked = True) Then
            MsgBox("Transaction End Date must be later or equal to Start Date", MsgBoxStyle.Information, "Invalid Input Parameter")
            txtTranToDate.Focus()
            txtTranToDate.SelectAll()
            Exit Sub
        End If
        If (Trim(txtItmNo.Text).Length = 0) Then
            MsgBox("Please Enter " & IIf(optBOMItm.Checked = True, "BOM ", "") & "Item No.", MsgBoxStyle.Information, "Missing Input Parameter")
            txtItmNo.Focus()
            txtItmNo.SelectAll()
            Exit Sub
        End If

        Dim itmList As String = ""
        Dim ttl As Integer
        Dim i As Integer

        'txtItmNo.Text = Replace(Replace(txtItmNo.Text, Chr(10), ""), Chr(13), "")
        txtItmNo.Text = txtItmNo.Text.Replace(Chr(10), "").Replace(Chr(13), "")
        ttl = UBound(Split(txtItmNo.Text, "*"))

        If Trim(txtItmNo.Text = "*") Then
            itmList = ""
        Else
            For i = 0 To ttl
                If i = ttl Then
                    itmList = itmList & "''" & Split(txtItmNo.Text, "*")(i) & "''"
                Else
                    itmList = itmList & "''" & Split(txtItmNo.Text, "*")(i) & "'',"
                End If
            Next
        End If

        If itmList = "" Then

            'If optByExl.Value = True Then
            If optByExcel.Checked = True Or optByExcel_New.Checked = True Then
                itmList = "''"
                Me.txtItmNo.Text = "*"
            Else
                MsgBox("Item List is Empty!")
                If Me.txtItmNo.Enabled And Me.txtItmNo.Visible Then txtItmNo.Focus()
                Exit Sub
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If optItmMtr.Checked = True Then
            gspStr = "sp_select_IAR00002 'UCPP','" & itmList & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IAR00002, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading IAR00001 sp_select_IAR00002 : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_IAR00002SUB 'UCPP'"
            rtnLong = execute_SQLStatement(gspStr, rs_IAR00002SUB, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading IAR00001 sp_select_IAR00002SUB : " & rtnStr)
                Exit Sub
            End If
        Else
            If optByExcel.Checked = True Then
                gspStr = "sp_select_IAR00001 'UCPP','" & txtTranFromDate.Text & "','" & txtTranToDate.Text & "','" & itmList & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IAR00001, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading IAR00001 sp_select_IAR00001 : " & rtnStr)
                    Exit Sub
                End If
            ElseIf optByExcel_New.Checked = True Then
                gspStr = "sp_select_IAR00001_new 'UCPP','" & txtTranFromDate.Text & "','" & txtTranToDate.Text & "','" & itmList & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IAR00001, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading IAR00001 sp_select_IAR00001_new : " & rtnStr)
                    Exit Sub
                End If
            ElseIf optBOMItm.Checked = True Then
                gspStr = "sp_select_IAR00003 'UCPP','" & Trim(txtItmNo.Text) & "','" & chkAssort.Checked & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IAR00003, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading IAR00001 sp_select_IAR00003 : " & rtnStr)
                    Exit Sub
                End If
            Else
                MsgBox("Please select a search method", MsgBoxStyle.Information, "Missing Search Parameter")
                optByExcel.Focus()
                Exit Sub
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
        Dim answer As Integer

        If optByExcel.Checked = True Or optByExcel_New.Checked = True Then
            If rs_IAR00001.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            Else
                If chkExcel.Checked = True Then
                    If rs_IAR00001.Tables("RESULT").Rows.Count > 30000 Then
                        answer = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                        If answer = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                    End If
                    exportExcel_IAR00001(rs_IAR00001)
                Else
                    Dim objRpt As Object
                    If optByExcel.Checked = True Then
                        objRpt = New IAR00001Rpt
                    Else
                        objRpt = New IAR00001NRpt
                    End If
                    objRpt.SetDataSource(rs_IAR00001.Tables("RESULT"))

                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()
                End If
            End If
        ElseIf optItmMtr.Checked = True Then
            If rs_IAR00002.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            Else
                If chkExcel.Checked = True Then
                    If rs_IAR00002.Tables("RESULT").Rows.Count > 30000 Then
                        answer = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                        If answer = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                    End If
                    exportExcel_IAR00002(rs_IAR00002, rs_IAR00002SUB)
                Else

                    Dim objRpt As New IAR00002Rpt
                    objRpt.SetDataSource(rs_IAR00002.Tables("RESULT"))
                    'Add Subreport report source
                    objRpt.Subreports.Item("IAR00002SUB.rpt").SetDataSource(rs_IAR00002SUB.Tables("RESULT"))
                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()
                End If
            End If
        ElseIf optBOMItm.Checked = True Then
            If rs_IAR00003.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            Else
                If chkExcel.Checked = True Then
                    If rs_IAR00003.Tables("RESULT").Rows.Count > 30000 Then
                        answer = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                        If answer = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                        exportExcel_IAR00003(rs_IAR00003)
                    End If
                Else
                    Dim objRpt As New IAR00003Rpt
                    objRpt.SetDataSource(rs_IAR00003.Tables("RESULT"))
                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()
                End If
            End If
        End If

    End Sub

    Private Sub exportExcel_IAR00001(ByVal rs_EXCEL As DataSet)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        If rs_EXCEL.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        'Initializing Header Row'
        With xlsApp
            .Cells(hdrRow, 1) = "Pri Cust."
            .Cells(hdrRow, 2) = "Sec Cust."
            .Cells(hdrRow, 3) = "Item No"
            .Cells(hdrRow, 4) = "Item Description"
            .Cells(hdrRow, 5) = "Vendor Item"
            .Cells(hdrRow, 6) = "Vendor Code"
            .Cells(hdrRow, 7) = "Revised Date"
            .Cells(hdrRow, 8) = "Original Packing / Terms"
            .Cells(hdrRow, 9) = "New Packing / Terms"
            .Cells(hdrRow, 10) = "Original Fty Prc"
            .Cells(hdrRow, 11) = "New Fty Prc"
            .Cells(hdrRow, 12) = "Original Basic Price"
            .Cells(hdrRow, 13) = "New Basic Price"
            .Cells(hdrRow, 14) = "Fty Prc Diff (%)"
            .Cells(hdrRow, 15) = "Basic Price Diff (%)"
            .Cells(hdrRow, 16) = "Old IM Period"
            .Cells(hdrRow, 17) = "New IM Period"
            .Cells(hdrRow, 18) = "Old BOM Info"
            .Cells(hdrRow, 19) = "New BOM Info"
            .Cells(hdrRow, 20) = "Type"
            .Cells(hdrRow, 21) = "Pri Cus"
            .Cells(hdrRow, 22) = "Sec Cus"
            .Cells(hdrRow, 23) = "Quotation No"
            .Cells(hdrRow, 24) = "Quotation Date"
            .Cells(hdrRow, 25) = "S/C No"
            .Cells(hdrRow, 26) = "Issue Date"
            .Cells(hdrRow, 27) = "Job No"
            .Cells(hdrRow, 28) = "Basic Price"
            .Cells(hdrRow, 29) = "Selling Price"
            .Cells(hdrRow, 30) = "Order Qty"
            .Cells(hdrRow, 31) = "Shipped Qty"
            .Cells(hdrRow, 32) = "Outstanding Qty"
            .Cells(hdrRow, 33) = "Ship Start Date"
            .Cells(hdrRow, 34) = "Validity Date"
            .Cells(hdrRow, 35) = "Ship End Date"
        End With

        'Populating Data
        With xlsApp
            For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                If rs_EXCEL.Tables("RESULT").Rows(i)("type").ToString = "Q" Then
                    type = "Q"
                Else
                    type = "S"
                End If

                .Cells(hdrRow + 1 + i, 1) = rs_EXCEL.Tables("RESULT").Rows(i)("imu_cus1no")
                .Cells(hdrRow + 1 + i, 2) = rs_EXCEL.Tables("RESULT").Rows(i)("imu_cus2no")
                .Cells(hdrRow + 1 + i, 3) = rs_EXCEL.Tables("RESULT").Rows(i)("ibi_itmno")
                .Cells(hdrRow + 1 + i, 4) = rs_EXCEL.Tables("RESULT").Rows(i)("ibi_engdsc")
                .Cells(hdrRow + 1 + i, 5) = rs_EXCEL.Tables("RESULT").Rows(i)("iid_venitm")
                .Cells(hdrRow + 1 + i, 6) = rs_EXCEL.Tables("RESULT").Rows(i)("ibi_venno").ToString & " - " & rs_IAR00001.Tables("RESULT").Rows(i)("vbi_vensna").ToString
                .Cells(hdrRow + 1 + i, 7) = rs_EXCEL.Tables("RESULT").Rows(i)("ibi_upddat")
                .Cells(hdrRow + 1 + i, 8) = rs_EXCEL.Tables("RESULT").Rows(i)("pck_packing")
                .Cells(hdrRow + 1 + i, 9) = rs_EXCEL.Tables("RESULT").Rows(i)("dat_packing")
                .Cells(hdrRow + 1 + i, 10) = rs_EXCEL.Tables("RESULT").Rows(i)("mup_curftyprc")
                .Cells(hdrRow + 1 + i, 11) = rs_EXCEL.Tables("RESULT").Rows(i)("dat_curftyprc")
                .Cells(hdrRow + 1 + i, 12) = rs_EXCEL.Tables("RESULT").Rows(i)("imu_basprc")
                .Cells(hdrRow + 1 + i, 13) = rs_EXCEL.Tables("RESULT").Rows(i)("iid_ftyprc")
                .Cells(hdrRow + 1 + i, 14) = Format(CDbl(rs_EXCEL.Tables("RESULT").Rows(i)("newbasicprice")), "#,###.00")
                .Cells(hdrRow + 1 + i, 15) = Format(CDbl(rs_EXCEL.Tables("RESULT").Rows(i)("newbasicprice2")), "#,###.00")
                .Cells(hdrRow + 1 + i, 16) = rs_EXCEL.Tables("RESULT").Rows(i)("pck_qutdat")
                .Cells(hdrRow + 1 + i, 17) = rs_EXCEL.Tables("RESULT").Rows(i)("dat_qutdat")
                .Cells(hdrRow + 1 + i, 18) = rs_EXCEL.Tables("RESULT").Rows(i)("bomlist_bef")
                .Cells(hdrRow + 1 + i, 19) = rs_EXCEL.Tables("RESULT").Rows(i)("bomlist_aft")
                .Cells(hdrRow + 1 + i, 20) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("quh_cus1no").ToString <> "", IIf(type = "Q", "Quotation", "S/C"), "")
                If (rs_EXCEL.Tables("RESULT").Rows(i)("quh_cus1no").ToString <> "") Then
                    .Cells(hdrRow + 1 + i, 21) = rs_EXCEL.Tables("RESULT").Rows(i)("quh_cus1no").ToString & " - " & rs_EXCEL.Tables("RESULT").Rows(i)("cbi_cussna_pri").ToString
                    .Cells(hdrRow + 1 + i, 22) = rs_EXCEL.Tables("RESULT").Rows(i)("quh_cus2no").ToString & " - " & rs_EXCEL.Tables("RESULT").Rows(i)("cbi_cussna_sec").ToString
                    .Cells(hdrRow + 1 + i, 23) = IIf(type = "Q", rs_EXCEL.Tables("RESULT").Rows(i)("quh_qutno"), "")
                    .Cells(hdrRow + 1 + i, 24) = IIf(type = "Q", rs_EXCEL.Tables("RESULT").Rows(i)("quh_rvsdat"), "")
                    .Cells(hdrRow + 1 + i, 25) = IIf(type = "S", rs_EXCEL.Tables("RESULT").Rows(i)("quh_qutno"), "")
                    .Cells(hdrRow + 1 + i, 26) = IIf(type = "S", rs_EXCEL.Tables("RESULT").Rows(i)("quh_rvsdat"), "")
                    .Cells(hdrRow + 1 + i, 27) = rs_EXCEL.Tables("RESULT").Rows(i)("pod_jobord")
                    .Cells(hdrRow + 1 + i, 28) = rs_EXCEL.Tables("RESULT").Rows(i)("quh_curcde").ToString & rs_EXCEL.Tables("RESULT").Rows(i)("selprc").ToString
                    .Cells(hdrRow + 1 + i, 29) = rs_EXCEL.Tables("RESULT").Rows(i)("quh_curcde").ToString & rs_EXCEL.Tables("RESULT").Rows(i)("qud_basprc").ToString
                    .Cells(hdrRow + 1 + i, 30) = rs_EXCEL.Tables("RESULT").Rows(i)("ordqty")
                    .Cells(hdrRow + 1 + i, 31) = rs_EXCEL.Tables("RESULT").Rows(i)("sod_shpqty")
                    .Cells(hdrRow + 1 + i, 32) = rs_EXCEL.Tables("RESULT").Rows(i)("ordqty") - rs_EXCEL.Tables("RESULT").Rows(i)("sod_shpqty")
                    .Cells(hdrRow + 1 + i, 33) = rs_EXCEL.Tables("RESULT").Rows(i)("quh_shpstr")
                    .Cells(hdrRow + 1 + i, 34) = IIf(type = "Q", rs_EXCEL.Tables("RESULT").Rows(i)("quh_shpstr"), "")
                    .Cells(hdrRow + 1 + i, 35) = IIf(type = "S", rs_EXCEL.Tables("RESULT").Rows(i)("quh_shpend"), "")
                End If
            Next
        End With

        ' Configuring XLS Style
        With xlsApp
            .Rows("1:1").Font.Bold = True
            .Columns("A:BR").EntireColumn.AutoFit()
            .Columns("D:D").ColumnWidth = 35
            .Columns("R:S").ColumnWidth = 35

            .Columns("D:D").WrapText = True
            .Columns("R:S").WrapText = True
        End With

        ' Release reference
        rs_EXCEL = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub exportExcel_IAR00002(ByVal rs_EXCEL As DataSet, ByVal rs_EXCEL_SUB As DataSet)
        Dim xlsApp As Excel.Application
        Dim xlsWB As Excel.Workbook
        Dim xlsWS As Excel.Worksheet

        Dim HdrRow As Long
        Dim DtlRow As Long

        Dim lngRptInfo As Long
        Dim lngCompany As Long
        Dim lngTitle As Long
        Dim lngCompanyLen As Long
        Dim lngTitleLen As Long

        Dim intGroup As Long
        Dim i As Long
        Dim lngRecCount As Long

        Dim lngPages As Long


        Dim strCompany As String
        Dim strTitle As String
        Dim strGroup As String
        Dim strTemp As String

        Dim intComFontSize As Integer
        Dim intTitleFontSize As Integer
        Dim intRptInfoFontSize As Integer
        Dim intColHdrFontSize As Integer
        Dim intContFontSize As Integer

        'Variable unique for this function only
        Dim strSeq As String
        Dim strItmno As String
        Dim oriFtyPrc As String
        Dim newFtyPrc As String
        Dim oriBscPrc As String
        Dim newBscPrc As String
        Dim dblOriFtyPrc As Double
        Dim dblNewFtyPrc As Double
        Dim dblOriBscPrc As Double
        Dim dblNewBscPrc As Double
        Dim j As Long
        Dim strGroup_sub As String
        Dim strTemp_sub As String
        Dim beforepacking As String
        Dim oriperiod As String
        Dim afterpacking As String
        Dim newperiod As String

        Dim dr_IAR00002SUB() As DataRow

        If rs_EXCEL.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        lngRptInfo = 18
        lngCompany = 8
        lngTitle = 8
        lngCompanyLen = 5
        lngTitleLen = 5


        intComFontSize = 14
        intTitleFontSize = 12
        intRptInfoFontSize = 9
        intColHdrFontSize = 9
        intContFontSize = 9

        HdrRow = 1
        DtlRow = 5

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        strCompany = "UNITED CHINESE GROUP"
        strTitle = "IMPACT ANALYSIS REPORT"

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        With xlsApp
            ' Company
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).MergeCells = True
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).Font.Size = intComFontSize
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).HorizontalAlignment = 3
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).Font.Bold = True
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).Value = strCompany

            ' Title
            .Range(.Cells(HdrRow + 3, lngTitle), .Cells(HdrRow + 3, lngTitle + lngTitleLen - 1)).MergeCells = True
            .Range(.Cells(HdrRow + 3, lngTitle), .Cells(HdrRow + 3, lngTitle + lngTitleLen - 1)).Font.Size = intTitleFontSize
            .Range(.Cells(HdrRow + 3, lngTitle), .Cells(HdrRow + 3, lngTitle + lngTitleLen - 1)).HorizontalAlignment = 3
            .Range(.Cells(HdrRow + 3, lngTitle), .Cells(HdrRow + 3, lngTitle + lngTitleLen - 1)).Font.Bold = True
            .Range(.Cells(HdrRow + 3, lngTitle), .Cells(HdrRow + 3, lngTitle + lngTitleLen - 1)).Value = strTitle
        End With

        With xlsApp
            .Range(.Cells(HdrRow, lngRptInfo), .Cells(HdrRow + 3, lngRptInfo + 2)).Font.Size = intRptInfoFontSize
            .Range(.Cells(HdrRow, lngRptInfo + 1), .Cells(HdrRow + 3, lngRptInfo + 1)).Value = ":"
            .Range(.Cells(HdrRow, lngRptInfo), .Cells(HdrRow + 3, lngRptInfo + 2)).HorizontalAlignment = 2
            ' Report ID
            .Range(.Cells(HdrRow, lngRptInfo), .Cells(HdrRow, lngRptInfo + 2)).VerticalAlignment = 3
            .Cells(HdrRow, lngRptInfo) = "Report ID"
            .Cells(HdrRow, lngRptInfo + 2) = "IAR00002"
            ' Date
            .Cells(HdrRow + 1, lngRptInfo) = "Date"
            .Range(.Cells(HdrRow + 1, lngRptInfo + 2), .Cells(HdrRow + 1, lngRptInfo + 2)).NumberFormatLocal = "mm/dd/yyyy"
            .Cells(HdrRow + 1, lngRptInfo + 2) = Format(Now, "mm/dd/yyyy")

            ' Time
            .Cells(HdrRow + 2, lngRptInfo) = "Time"
            .Range(.Cells(HdrRow + 2, lngRptInfo + 2), .Cells(HdrRow + 2, lngRptInfo + 2)).NumberFormatLocal = "HH:MM:SS AM/PM"
            .Cells(HdrRow + 2, lngRptInfo + 2) = Format(Now, "HH:mm:ss")

            ' Page
            .Cells(HdrRow + 3, lngRptInfo) = "Page"
            .Cells(HdrRow + 3, lngRptInfo + 2) = "1 of 1"
        End With

        strGroup = ""
        strTemp = ""
        strItmno = ""
        strSeq = ""
        lngRecCount = rs_EXCEL.Tables("RESULT").Rows.Count
        intGroup = 0
        dr_IAR00002SUB = Nothing

        rs_EXCEL.Tables("RESULT").Select(Nothing, "ibi_itmno,ipi_pckunt,imu_ftyprc,imu_basprc,ipi_pckseq,ipi_credat")

        For i = 1 To rs_EXCEL.Tables("RESULT").Rows.Count
            strTemp = Trim(rs_EXCEL.Tables("RESULT").Rows(i - 1)("ibi_itmno").ToString) & Trim(rs_EXCEL.Tables("RESULT").Rows(i - 1)("ipi_pckunt").ToString) & Trim(rs_EXCEL.Tables("RESULT").Rows(i - 1)("imu_ftyprc").ToString) & Trim(rs_EXCEL.Tables("RESULT").Rows(i - 1)("imu_basprc").ToString)

            If strGroup <> strTemp Then
                If strGroup <> "" Then
                    intGroup = intGroup + 1
                    xlsApp.Cells(DtlRow + i + intGroup, 1) = "Records will not be shown under same Packing information or (Factory Price + Basic Price)"
                    intGroup = intGroup + 1
                    If Not rs_EXCEL_SUB Is Nothing Then
                        If rs_EXCEL_SUB.Tables("RESULT").Rows.Count > 0 Then
                            dr_IAR00002SUB = rs_EXCEL_SUB.Tables("RESULT").Select("ibi_itmno='" & strItmno & "' and ipi_pckseq='" & strSeq & "'")
                            If dr_IAR00002SUB.GetUpperBound(0) > 0 Then
                                strGroup_sub = ""
                                strTemp_sub = ""
                                For j = 0 To dr_IAR00002SUB.GetUpperBound(0)
                                    strTemp_sub = dr_IAR00002SUB(j).Item("type").ToString
                                    If strGroup_sub <> strTemp_sub Then
                                        If strGroup_sub <> "" Then
                                            If strGroup_sub = "Q" Then
                                                xlsApp.Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes expired Quotation"
                                            Else
                                                xlsApp.Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes closed Sales Confirmation"
                                            End If
                                            intGroup = intGroup + 2
                                        End If
                                        xlsApp.Cells(DtlRow + i + intGroup + 1, 1) = "Item No"
                                        xlsApp.Cells(DtlRow + i + intGroup + 1, 2) = ":"
                                        xlsApp.Cells(DtlRow + i + intGroup + 1, 3) = dr_IAR00002SUB(j).Item("ibi_itmno").ToString


                                        xlsApp.Cells(DtlRow + i + intGroup + 2, 1) = "Primary"
                                        xlsApp.Cells(DtlRow + i + intGroup + 3, 1) = "Customer"

                                        xlsApp.Cells(DtlRow + i + intGroup + 2, 3) = "Secondary"
                                        xlsApp.Cells(DtlRow + i + intGroup + 3, 3) = "Customer"

                                        xlsApp.Cells(DtlRow + i + intGroup + 2, 5) = IIf(strTemp_sub = "Q", "Quotation No", "SC No")

                                        xlsApp.Cells(DtlRow + i + intGroup + 2, 7) = IIf(strTemp_sub = "Q", "Quotation Date", "Issue Date")

                                        xlsApp.Cells(DtlRow + i + intGroup + 2, 9) = "Basic"
                                        xlsApp.Cells(DtlRow + i + intGroup + 3, 9) = "Price"

                                        xlsApp.Cells(DtlRow + i + intGroup + 2, 11) = "Selling"
                                        xlsApp.Cells(DtlRow + i + intGroup + 3, 11) = "Price"

                                        If strTemp_sub <> "Q" Then
                                            xlsApp.Cells(DtlRow + i + intGroup + 2, 13) = "Order"
                                            xlsApp.Cells(DtlRow + i + intGroup + 3, 13) = "Quantity"

                                            xlsApp.Cells(DtlRow + i + intGroup + 2, 14) = "Shipped"
                                            xlsApp.Cells(DtlRow + i + intGroup + 3, 14) = "Quantity"

                                            xlsApp.Cells(DtlRow + i + intGroup + 2, 15) = "Outstanding"
                                            xlsApp.Cells(DtlRow + i + intGroup + 3, 15) = "Quantity"

                                            xlsApp.Cells(DtlRow + i + intGroup + 2, 17) = "Ship"
                                            xlsApp.Cells(DtlRow + i + intGroup + 3, 17) = "Start Date"

                                            xlsApp.Cells(DtlRow + i + intGroup + 2, 18) = "Ship"
                                            xlsApp.Cells(DtlRow + i + intGroup + 3, 18) = "End Date"

                                        Else
                                            xlsApp.Cells(DtlRow + i + intGroup + 2, 18) = "Validity"
                                            xlsApp.Cells(DtlRow + i + intGroup + 3, 18) = "Date"
                                        End If

                                        xlsApp.Cells(DtlRow + i + intGroup + 2, 19) = "Action"
                                        xlsApp.Range(xlsApp.Cells(DtlRow + i + intGroup + 3, 1), xlsApp.Cells(DtlRow + i + intGroup + 3, lngRptInfo + 2)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                                        strGroup_sub = strTemp_sub
                                        intGroup = intGroup + 4
                                    End If

                                    ' SUBREPORT CONTENT START
                                    With xlsApp
                                        .Range(.Cells(DtlRow + i + intGroup, 7), .Cells(DtlRow + i + intGroup, 7)).NumberFormatLocal = "mm/dd/yyyy"
                                        .Range(.Cells(DtlRow + i + intGroup, 17), .Cells(DtlRow + i + intGroup, 16)).NumberFormatLocal = "mm/dd/yyyy"
                                        .Range(.Cells(DtlRow + i + intGroup, 18), .Cells(DtlRow + i + intGroup, 18)).NumberFormatLocal = "mm/dd/yyyy"

                                        .Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, 2)).Merge()
                                        .Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, 2)).WrapText = True
                                        .Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, 2)).Value = dr_IAR00002SUB(j).Item("quh_cus1no").ToString & " - " & dr_IAR00002SUB(j).Item("cbi_cussna_pri").ToString
                                        .Range(.Cells(DtlRow + i + intGroup, 3), .Cells(DtlRow + i + intGroup, 4)).Merge()
                                        .Range(.Cells(DtlRow + i + intGroup, 3), .Cells(DtlRow + i + intGroup, 4)).WrapText = True
                                        .Range(.Cells(DtlRow + i + intGroup, 3), .Cells(DtlRow + i + intGroup, 4)).Value = IIf(dr_IAR00002SUB(j).Item("quh_cus2no").ToString <> "", dr_IAR00002SUB(j).Item("quh_cus2no").ToString & " - " & dr_IAR00002SUB(j).Item("cbi_cussna_sec").ToString, "")
                                        .Cells(DtlRow + i + intGroup, 5) = dr_IAR00002SUB(j).Item("quh_qutno").ToString
                                        .Cells(DtlRow + i + intGroup, 7) = dr_IAR00002SUB(j).Item("quh_rvsdat").ToString
                                        .Cells(DtlRow + i + intGroup, 9) = dr_IAR00002SUB(j).Item("qud_curcde").ToString & " " & Format(dr_IAR00002SUB(j).Item("qud_basprc"), "#,###.0000").ToString
                                        .Cells(DtlRow + i + intGroup, 11) = dr_IAR00002SUB(j).Item("qud_curcde").ToString & " " & Format(dr_IAR00002SUB(j).Item("qud_cus1sp"), "#,###.0000").ToString

                                        If strTemp_sub <> "Q" Then
                                            .Cells(DtlRow + i + intGroup, 13) = dr_IAR00002SUB(j).Item("sod_ordqty").ToString
                                            .Cells(DtlRow + i + intGroup, 14) = dr_IAR00002SUB(j).Item("sod_shpqty").ToString
                                            .Cells(DtlRow + i + intGroup, 15) = IIf(dr_IAR00002SUB(j).Item("sod_ordqty") - dr_IAR00002SUB(j).Item("sod_shpqty") = 0, "", dr_IAR00002SUB(j).Item("sod_ordqty") - dr_IAR00002SUB(j).Item("sod_shpqty"))
                                            .Cells(DtlRow + i + intGroup, 17) = dr_IAR00002SUB(j).Item("quh_shpstr").ToString
                                            .Cells(DtlRow + i + intGroup, 18) = dr_IAR00002SUB(j).Item("quh_shpend").ToString

                                        Else
                                            .Cells(DtlRow + i + intGroup, 18) = dr_IAR00002SUB(j).Item("quh_shpend").ToString
                                        End If
                                        If Len(.Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, 1)).Text) > 18 Or _
                                            Len(.Range(.Cells(DtlRow + i + intGroup, 3), .Cells(DtlRow + i + intGroup, 3)).Text) > 18 Then
                                            .Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, lngRptInfo + 2)).RowHeight = 2 * .Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, 2)).RowHeight
                                            .Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, lngRptInfo + 2)).VerticalAlignment = 1
                                        End If
                                    End With
                                    ' SUBREPORT CONTENT END
                                    intGroup = intGroup + 1
                                Next
                                If strGroup_sub <> "" Then
                                    If strGroup_sub = "Q" Then
                                        xlsApp.Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes expired Quotation"
                                    Else
                                        xlsApp.Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes closed Sales Confirmation"
                                    End If
                                    intGroup = intGroup + 2
                                End If
                            End If
                            dr_IAR00002SUB = Nothing
                        End If
                    End If
                End If
                If rs_EXCEL.Tables("RESULT").Rows(i - 1)("ibi_cocde").ToString <> "UCPP" Then
                    xlsApp.Cells(DtlRow + i + intGroup + 1, 1) = "Vendor Item No"
                End If
                xlsApp.Cells(DtlRow + i + intGroup + 2, 1) = "Item No."
                xlsApp.Cells(DtlRow + i + intGroup + 3, 1) = "Description"
                xlsApp.Cells(DtlRow + i + intGroup + 4, 1) = "Packing"
                '            .Cells(DtlRow + i + intGroup + 5, 1) = "Formula"
                If rs_EXCEL.Tables("RESULT").Rows(i - 1)("ibi_cocde").ToString <> "UCPP" Then
                    xlsApp.Range(xlsApp.Cells(DtlRow + i + intGroup + 2, 3), xlsApp.Cells(DtlRow + i + intGroup + 5, 3)).Value = ":"
                End If
                If rs_EXCEL.Tables("RESULT").Rows(i - 1)("ibi_cocde").ToString <> "UCPP" Then
                    xlsApp.Range(xlsApp.Cells(DtlRow + i + intGroup + 1, 3), xlsApp.Cells(DtlRow + i + intGroup + 1, 3)).Value = ":"
                    xlsApp.Cells(DtlRow + i + intGroup + 1, 4) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("ivi_venitm").ToString
                End If
                xlsApp.Cells(DtlRow + i + intGroup + 2, 4) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("ibi_itmno").ToString
                xlsApp.Cells(DtlRow + i + intGroup + 3, 4) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("ibi_engdsc").ToString
                xlsApp.Cells(DtlRow + i + intGroup + 4, 4) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("ipi_pckunt").ToString

                xlsApp.Cells(DtlRow + i + intGroup + 6, 1) = "Revised Date"
                xlsApp.Cells(DtlRow + i + intGroup + 6, 3) = "Packing Seq"
                xlsApp.Cells(DtlRow + i + intGroup + 6, 5) = "Original Packing"
                xlsApp.Cells(DtlRow + i + intGroup + 6, 7) = "New Packing"

                xlsApp.Cells(DtlRow + i + intGroup + 6, 9) = "Original"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 9) = "Factory Price"

                xlsApp.Cells(DtlRow + i + intGroup + 6, 11) = "New"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 11) = "Pactory Price"

                xlsApp.Cells(DtlRow + i + intGroup + 6, 13) = "Original"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 13) = "Basic Price"

                xlsApp.Cells(DtlRow + i + intGroup + 6, 15) = "New"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 15) = "Basic Price"

                xlsApp.Cells(DtlRow + i + intGroup + 6, 17) = "Fty Price"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 17) = "Diff (%)"

                xlsApp.Cells(DtlRow + i + intGroup + 6, 18) = "Basic Price"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 18) = "Diff (%)"


                xlsApp.Cells(DtlRow + i + intGroup + 6, 19) = "Original"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 19) = "Period"

                xlsApp.Cells(DtlRow + i + intGroup + 6, 20) = "New"
                xlsApp.Cells(DtlRow + i + intGroup + 7, 20) = "Period"

                xlsApp.Range(xlsApp.Cells(DtlRow + i + intGroup + 6, 1), xlsApp.Cells(DtlRow + i + intGroup + 7, lngRptInfo + 2)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                xlsApp.Range(xlsApp.Cells(DtlRow + i + intGroup + 6, 1), xlsApp.Cells(DtlRow + i + intGroup + 7, lngRptInfo + 2)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1

                intGroup = intGroup + 8
                strItmno = Trim(rs_EXCEL.Tables("RESULT").Rows(i - 1)("ibi_itmno").ToString)
                strSeq = Trim(CStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("ipi_pckseq")))
                strGroup = strTemp
            End If
            xlsApp.Range(xlsApp.Cells(DtlRow + i + intGroup, 1), xlsApp.Cells(DtlRow + i + intGroup, lngRptInfo + 2)).NumberFormatLocal = "@"
            xlsApp.Range(xlsApp.Cells(DtlRow + i + intGroup, 1), xlsApp.Cells(DtlRow + i + intGroup, 1)).NumberFormatLocal = "mm/dd/yyyy"
            xlsApp.Cells(DtlRow + i + intGroup, 1) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("ipi_credat").ToString.Replace("-", "/")
            xlsApp.Cells(DtlRow + i + intGroup, 3) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("ipi_pckseq").ToString

            beforepacking = ""
            oriperiod = ""
            afterpacking = ""
            newperiod = ""

            If Not (rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking")) Is Nothing Then
                If rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString <> "" Then
                    If InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking"), ";") > 1 Then
                        beforepacking = rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString.Substring(0, InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString, ";") - 1)
                    End If
                    If rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString.Length > InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString, ";") Then
                        oriperiod = rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString.Substring(InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString, ";") - 1, rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString.Length - InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforepacking").ToString, ";"))
                    End If
                End If
            End If
            xlsApp.Cells(DtlRow + i + intGroup, 5) = beforepacking
            xlsApp.Cells(DtlRow + i + intGroup, 19) = oriperiod


            If Not rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking") Is Nothing Then
                If rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString <> "" Then
                    If InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString, ";") > 1 Then
                        afterpacking = rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString.Substring(0, InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString, ";") - 1)
                    End If
                    If rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString.Length > InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString, ";") Then
                        newperiod = rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString.Substring(InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString, ";") - 1, rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString.Length - InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterpacking").ToString, ";"))
                    End If
                End If
            End If
            xlsApp.Cells(DtlRow + i + intGroup, 7) = afterpacking
            xlsApp.Cells(DtlRow + i + intGroup, 20) = newperiod

            oriFtyPrc = ""
            newFtyPrc = ""
            oriBscPrc = ""
            newBscPrc = ""
            If Not rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc") Is Nothing Then
                If rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString <> "" Then
                    If InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString, ";") > 1 Then
                        oriFtyPrc = rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString.Substring(0, InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc"), ";") - 1)
                    End If
                    If rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString.Length > InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString, ";") Then
                        oriBscPrc = rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString.Substring(InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString, ";"), rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString.Length - InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("beforeftyprc").ToString, ";"))
                    End If
                End If
            End If

            If Not rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc") Is Nothing Then
                If rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString <> "" Then
                    If InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString, ";") > 1 Then
                        newFtyPrc = rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString.Substring(0, InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc"), ";") - 1)
                    End If
                    If rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString.Length > InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString, ";") Then
                        newBscPrc = rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString.Substring(InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString, ";"), rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString.Length - InStr(rs_EXCEL.Tables("RESULT").Rows(i - 1)("afterftyprc").ToString, ";"))
                    End If
                End If
            End If

            xlsApp.Cells(DtlRow + i + intGroup, 9) = oriFtyPrc
            xlsApp.Cells(DtlRow + i + intGroup, 11) = newFtyPrc
            xlsApp.Cells(DtlRow + i + intGroup, 13) = oriBscPrc
            xlsApp.Cells(DtlRow + i + intGroup, 15) = newBscPrc
            dblOriFtyPrc = 0
            dblNewFtyPrc = 0
            If oriFtyPrc <> "" Then
                dblOriFtyPrc = CDbl(Mid(oriFtyPrc, 4, Len(oriFtyPrc) - 3))
            End If
            If newFtyPrc <> "" Then
                dblNewFtyPrc = CDbl(Mid(newFtyPrc, 4, Len(newFtyPrc) - 3))
            End If
            If dblOriFtyPrc > 0 Then
                xlsApp.Cells(DtlRow + i + intGroup, 17) = Format(((dblNewFtyPrc - dblOriFtyPrc) / dblOriFtyPrc) * 100, "#,###.00")
            End If

            dblOriBscPrc = 0
            dblNewBscPrc = 0
            If oriBscPrc <> "" Then
                dblOriBscPrc = CDbl(Mid(oriBscPrc, 4, Len(oriBscPrc) - 3))
            End If
            If newBscPrc <> "" Then
                dblNewBscPrc = CDbl(Mid(newBscPrc, 4, Len(newBscPrc) - 3))
            End If
            If dblOriBscPrc > 0 Then
                xlsApp.Cells(DtlRow + i + intGroup, 18) = Format(((dblNewBscPrc - dblOriBscPrc) / dblOriBscPrc) * 100, "#,###.00")
            End If
        Next
        If strGroup <> "" Then
            intGroup = intGroup + 1
            xlsApp.Cells(DtlRow + i + intGroup, 1) = "Records will not be shown under same Packing information or (Factory Price + Basic Price)"
            intGroup = intGroup + 1
            If Not rs_EXCEL_SUB.Tables("RESULT") Is Nothing Then
                If rs_EXCEL_SUB.Tables("RESULT").Rows.Count > 0 Then
                    dr_IAR00002SUB = rs_EXCEL_SUB.Tables("RESULT").Select("ibi_itmno='" & strItmno & "' and ipi_pckseq='" & strSeq & "'")
                    If dr_IAR00002SUB.GetUpperBound(0) > 0 Then
                        strGroup_sub = ""
                        strTemp_sub = ""
                        With xlsApp
                            For j = 0 To dr_IAR00002SUB.GetUpperBound(0)
                                strTemp_sub = dr_IAR00002SUB(j).Item("type").ToString
                                If strGroup_sub <> strTemp_sub Then
                                    If strGroup_sub <> "" Then
                                        If strGroup_sub = "Q" Then
                                            .Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes expired Quotation"
                                        Else
                                            .Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes closed Sales Confirmation"
                                        End If
                                        intGroup = intGroup + 2
                                    End If
                                    .Cells(DtlRow + i + intGroup + 1, 1) = "Item No"
                                    .Cells(DtlRow + i + intGroup + 1, 2) = ":"
                                    .Cells(DtlRow + i + intGroup + 1, 3) = dr_IAR00002SUB(j).Item("ibi_itmno").ToString


                                    .Cells(DtlRow + i + intGroup + 2, 1) = "Primary"
                                    .Cells(DtlRow + i + intGroup + 3, 1) = "Customer"

                                    .Cells(DtlRow + i + intGroup + 2, 3) = "Secondary"
                                    .Cells(DtlRow + i + intGroup + 3, 3) = "Customer"

                                    .Cells(DtlRow + i + intGroup + 2, 5) = IIf(strTemp_sub = "Q", "Quotation No", "SC No")

                                    .Cells(DtlRow + i + intGroup + 2, 7) = IIf(strTemp_sub = "Q", "Quotation Date", "Issue Date")

                                    .Cells(DtlRow + i + intGroup + 2, 9) = "Basic"
                                    .Cells(DtlRow + i + intGroup + 3, 9) = "Price"

                                    .Cells(DtlRow + i + intGroup + 2, 11) = "Selling"
                                    .Cells(DtlRow + i + intGroup + 3, 11) = "Price"

                                    If strTemp_sub <> "Q" Then
                                        .Cells(DtlRow + i + intGroup + 2, 13) = "Order"
                                        .Cells(DtlRow + i + intGroup + 3, 13) = "Quantity"

                                        .Cells(DtlRow + i + intGroup + 2, 14) = "Shipped"
                                        .Cells(DtlRow + i + intGroup + 3, 14) = "Quantity"

                                        .Cells(DtlRow + i + intGroup + 2, 15) = "Outstanding"
                                        .Cells(DtlRow + i + intGroup + 3, 15) = "Quantity"

                                        .Cells(DtlRow + i + intGroup + 2, 17) = "Ship"
                                        .Cells(DtlRow + i + intGroup + 3, 17) = "Start Date"

                                        .Cells(DtlRow + i + intGroup + 2, 18) = "Ship"
                                        .Cells(DtlRow + i + intGroup + 3, 18) = "End Date"

                                    Else
                                        .Cells(DtlRow + i + intGroup + 2, 18) = "Validate"
                                        .Cells(DtlRow + i + intGroup + 3, 18) = "Date"
                                    End If

                                    .Cells(DtlRow + i + intGroup + 2, 19) = "Action"
                                    .Range(.Cells(DtlRow + i + intGroup + 3, 1), .Cells(DtlRow + i + intGroup + 3, lngRptInfo + 2)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                                    strGroup_sub = strTemp_sub
                                    intGroup = intGroup + 4
                                End If
                                '=================== Sub Report Content - Start ==================================

                                .Range(.Cells(DtlRow + i + intGroup, 7), .Cells(DtlRow + i + intGroup, 7)).NumberFormatLocal = "mm/dd/yyyy"
                                .Range(.Cells(DtlRow + i + intGroup, 17), .Cells(DtlRow + i + intGroup, 16)).NumberFormatLocal = "mm/dd/yyyy"
                                .Range(.Cells(DtlRow + i + intGroup, 18), .Cells(DtlRow + i + intGroup, 18)).NumberFormatLocal = "mm/dd/yyyy"

                                .Cells(DtlRow + i + intGroup, 1) = dr_IAR00002SUB(j).Item("quh_cus1no").ToString & " - " & dr_IAR00002SUB(j).Item("cbi_cussna_pri").ToString
                                .Cells(DtlRow + i + intGroup, 3) = IIf(dr_IAR00002SUB(j).Item("quh_cus2no").ToString <> "", dr_IAR00002SUB(j).Item("quh_cus2no").ToString & " - " & dr_IAR00002SUB(j).Item("cbi_cussna_sec").ToString, "")
                                .Cells(DtlRow + i + intGroup, 5) = dr_IAR00002SUB(j).Item("quh_qutno").ToString
                                .Cells(DtlRow + i + intGroup, 7) = dr_IAR00002SUB(j).Item("quh_rvsdat").ToString
                                .Cells(DtlRow + i + intGroup, 9) = dr_IAR00002SUB(j).Item("qud_curcde").ToString & " " & Format(dr_IAR00002SUB(j).Item("qud_basprc"), "#,###.0000")
                                .Cells(DtlRow + i + intGroup, 11) = dr_IAR00002SUB(j).Item("qud_curcde").ToString & " " & Format(dr_IAR00002SUB(j).Item("qud_cus1sp"), "#,###.0000")

                                If strTemp_sub <> "Q" Then
                                    .Cells(DtlRow + i + intGroup, 13) = dr_IAR00002SUB(j).Item("sod_ordqty").ToString
                                    .Cells(DtlRow + i + intGroup, 14) = dr_IAR00002SUB(j).Item("sod_shpqty").ToString
                                    .Cells(DtlRow + i + intGroup, 15) = IIf(dr_IAR00002SUB(j).Item("sod_ordqty") - dr_IAR00002SUB(j).Item("sod_shpqty") = 0, "", dr_IAR00002SUB(j).Item("sod_ordqty") - dr_IAR00002SUB(j).Item("sod_shpqty"))
                                    .Cells(DtlRow + i + intGroup, 17) = dr_IAR00002SUB(j).Item("quh_shpstr")
                                    .Cells(DtlRow + i + intGroup, 18) = dr_IAR00002SUB(j).Item("quh_shpend")

                                Else
                                    .Cells(DtlRow + i + intGroup, 18) = dr_IAR00002SUB(j).Item("quh_shpend")
                                End If

                                '=================== Sub Report Content -  End==================================
                                intGroup = intGroup + 1
                            Next
                            If strGroup_sub <> "" Then
                                If strGroup_sub = "Q" Then
                                    .Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes expired Quotation"
                                Else
                                    .Cells(DtlRow + i + intGroup + 1, 1) = "* This report excludes closed Sales Confirmation"
                                End If
                                intGroup = intGroup + 2
                            End If
                        End With
                    End If
                    dr_IAR00002SUB = Nothing
                End If
            End If
        End If


        'Set Page Layout
        With xlsApp
            .Columns.ColumnWidth = 9.4
        End With

        lngPages = (lngRecCount + intGroup) / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If

        With xlsWS.PageSetup
            .Zoom = False
            .TopMargin = 10
            .FitToPagesTall = lngPages
            .FitToPagesWide = 1
            .Orientation = Excel.XlPageOrientation.xlLandscape
        End With

        xlsApp.Columns("T:T").EntireColumn.AutoFit()


        ' Release reference
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub exportExcel_IAR00003(ByVal rs_EXCEL As DataSet)
        Dim xlsApp As Excel.Application
        Dim xlsWB As Excel.Workbook
        Dim xlsWS As Excel.Worksheet

        Dim HdrRow As Long
        Dim DtlRow As Long

        Dim lngRptInfo As Long
        Dim lngCompany As Long
        Dim lngTitle As Long
        Dim lngCompanyLen As Long
        Dim lngTitleLen As Long

        Dim intGroup As Long

        Dim i As Long
        Dim lngRecCount As Long

        Dim lngPages As Long


        Dim strCompany As String
        Dim strTitle As String

        Dim strGroup As String
        Dim strTemp As String

        Dim intComFontSize As Integer
        Dim intTitleFontSize As Integer
        Dim intRptInfoFontSize As Integer
        Dim intColHdrFontSize As Integer
        Dim intContFontSize As Integer

        lngRptInfo = 11
        lngCompany = 4
        lngTitle = 5
        lngCompanyLen = 7
        lngTitleLen = 5


        intComFontSize = 18
        intTitleFontSize = 14
        intRptInfoFontSize = 12
        intColHdrFontSize = 12
        intContFontSize = 12

        HdrRow = 1
        DtlRow = 6

        If rs_EXCEL.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        strCompany = "UNITED CHINESE GROUP"
        strTitle = "IMPACT ANALYSIS REPORT"

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        With xlsApp
            ' Company
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).MergeCells = True
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).Font.Size = intComFontSize
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).HorizontalAlignment = 3
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).Font.Bold = True
            .Range(.Cells(HdrRow, lngCompany), .Cells(HdrRow, lngCompany + lngCompanyLen - 1)).Value = strCompany

            ' Title
            .Range(.Cells(HdrRow + 1, lngTitle), .Cells(HdrRow + 1, lngTitle + lngTitleLen - 1)).MergeCells = True
            .Range(.Cells(HdrRow + 1, lngTitle), .Cells(HdrRow + 1, lngTitle + lngTitleLen - 1)).Font.Size = intTitleFontSize
            .Range(.Cells(HdrRow + 1, lngTitle), .Cells(HdrRow + 1, lngTitle + lngTitleLen - 1)).HorizontalAlignment = 3
            .Range(.Cells(HdrRow + 1, lngTitle), .Cells(HdrRow + 1, lngTitle + lngTitleLen - 1)).Font.Bold = True
            .Range(.Cells(HdrRow + 1, lngTitle), .Cells(HdrRow + 1, lngTitle + lngTitleLen - 1)).Value = strTitle
        End With

        With xlsApp
            .Columns(lngRptInfo + 2).ColumnWidth = 9.8
            .Range(.Cells(HdrRow, lngRptInfo), .Cells(HdrRow + 3, lngRptInfo + 2)).Font.Size = intRptInfoFontSize
            .Range(.Cells(HdrRow, lngRptInfo + 1), .Cells(HdrRow + 3, lngRptInfo + 1)).Value = ":"
            .Range(.Cells(HdrRow, lngRptInfo), .Cells(HdrRow + 3, lngRptInfo + 2)).HorizontalAlignment = 2
            ' Report ID
            .Range(.Cells(HdrRow, lngRptInfo), .Cells(HdrRow, lngRptInfo + 2)).VerticalAlignment = 3
            .Cells(HdrRow, lngRptInfo) = "Report ID"
            .Cells(HdrRow, lngRptInfo + 2) = "IAR00003"
            ' Date
            .Cells(HdrRow + 1, lngRptInfo) = "Date"
            .Range(.Cells(HdrRow + 1, lngRptInfo + 2), .Cells(HdrRow + 1, lngRptInfo + 2)).NumberFormatLocal = "mm/dd/yyyy"
            .Cells(HdrRow + 1, lngRptInfo + 2) = Format(Now, "mm/dd/yyyy")

            ' Time
            .Cells(HdrRow + 2, lngRptInfo) = "Time"
            .Range(.Cells(HdrRow + 2, lngRptInfo + 2), .Cells(HdrRow + 2, lngRptInfo + 2)).NumberFormatLocal = "HH:MM:SS AM/PM"
            .Cells(HdrRow + 2, lngRptInfo + 2) = Format(Now, "HH:MM:SS")

            ' Page
            .Cells(HdrRow + 3, lngRptInfo) = "Page"
            .Cells(HdrRow + 3, lngRptInfo + 2) = "1 of 1"
        End With

        strGroup = ""
        strTemp = ""
        intGroup = 0

        With xlsApp

            'Column Header
            .Range(.Cells(DtlRow, 1), .Cells(DtlRow, lngRptInfo + 2)).Font.Bold = True
            .Range(.Cells(DtlRow, 1), .Cells(DtlRow, lngRptInfo + 2)).Font.Size = intColHdrFontSize
            .Range(.Cells(DtlRow, 1), .Cells(DtlRow, lngRptInfo + 2)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
            .Cells(DtlRow, 1) = "BOM Item NO"
            .Cells(DtlRow, 5) = "Item No"
            .Cells(DtlRow, 8) = "Item Type"

            For i = 1 To rs_EXCEL.Tables("RESULT").Rows.Count
                strTemp = Trim(rs_EXCEL.Tables("RESULT").Rows(i - 1)("iba_assitm").ToString)
                If strGroup <> strTemp Then
                    If strGroup <> "" Then
                        .Cells(DtlRow + i + intGroup, 1) = "***"
                        intGroup = intGroup + 1
                    End If
                    strGroup = strTemp
                End If
                .Range(.Cells(DtlRow + i + intGroup, 1), .Cells(DtlRow + i + intGroup, lngRptInfo + 2)).NumberFormatLocal = "@"

                .Cells(DtlRow + i + intGroup, 1) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("iba_assitm")
                .Cells(DtlRow + i + intGroup, 5) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("iba_itmno")
                .Cells(DtlRow + i + intGroup, 8) = rs_EXCEL.Tables("RESULT").Rows(i - 1)("Item Type")
            Next
            If strGroup <> "" Then
                .Cells(DtlRow + i + intGroup, 1) = "***"
            End If
            .Range(.Cells(DtlRow, 1), .Cells(DtlRow + lngRecCount + intGroup, lngRptInfo + 2)).Font.Size = intContFontSize

        End With

        With xlsApp
            .Columns(lngRptInfo + 2).ColumnWidth = 11.13
        End With

        lngPages = lngRecCount / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If

        With xlsWS.PageSetup
            .Zoom = False
            .TopMargin = 10
            .FitToPagesTall = lngPages
            .FitToPagesWide = 1
            .Orientation = Excel.XlPageOrientation.xlPortrait
        End With

        ' Release reference
        rs_EXCEL = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

    End Sub

    Private Sub optPressed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optByExcel.CheckedChanged, optByExcel_New.CheckedChanged, optItmMtr.CheckedChanged, optBOMItm.CheckedChanged
        If optByExcel.Checked = True Then
            lblSearchParam.Visible = True
            lblSearchParam.Text = "Transaction Date"
            txtTranFromDate.Visible = True
            lblTranDateTo.Visible = True
            txtTranToDate.Visible = True
            chkAssort.Visible = False
        ElseIf optByExcel_New.Checked = True Then
            lblSearchParam.Visible = True
            lblSearchParam.Text = "Transaction Date"
            txtTranFromDate.Visible = True
            lblTranDateTo.Visible = True
            txtTranToDate.Visible = True
            chkAssort.Visible = False
        ElseIf optItmMtr.Checked = True Then
            lblSearchParam.Visible = False
            txtTranFromDate.Visible = False
            lblTranDateTo.Visible = False
            txtTranToDate.Visible = False
            chkAssort.Visible = False
        ElseIf optBOMItm.Checked = True Then
            lblSearchParam.Visible = True
            lblSearchParam.Text = "Show Assortment Item"
            txtTranFromDate.Visible = False
            lblTranDateTo.Visible = False
            txtTranToDate.Visible = False
            chkAssort.Visible = True
            chkAssort.Checked = True
        End If
    End Sub

    Private Sub enterKeyPressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNo.KeyPress, txtTranToDate.KeyPress, txtTranFromDate.KeyPress
        If e.KeyChar = Chr(13) Then
            cmdShowReport.PerformClick()
        End If
    End Sub

    Private Sub highlight_date(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTranFromDate.GotFocus, txtTranToDate.GotFocus
        sender.SelectAll()
    End Sub
End Class