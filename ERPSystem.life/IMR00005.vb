
Imports Excel = Microsoft.Office.Interop.Excel
Public Class IMR00005

    Dim rs_IMR00005 As DataSet
    Dim rs_IMR00005_excel As New ADODB.Recordset

    Private Sub IMR00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        setDefaultValue()
    End Sub

    Private Sub setDefaultValue()
        DateTimePickerInitialize()
    End Sub

    Private Sub DateTimePickerInitialize()
        dtpFromTrand.Value = Date.Today.AddYears(-2)
        dtpFromTrand.CustomFormat = "MM/dd/yy"
        dtpToTrand.Value = Date.Today
        dtpToTrand.CustomFormat = "MM/dd/yy"
    End Sub

    Private Sub cmd_S_PriCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCustAll)
    End Sub

    Private Sub cmd_S_SecCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCustAll.Name
        frmComSearch.callFmString = txt_S_SecCustAll.Text()

        frmComSearch.show_frmS(Me.cmd_S_SecCustAll)
    End Sub
    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If txtFromItmno.Text > txtToItmno.Text Then
            MsgBox("Invalid Item No. Range: From Item No. > To Item No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtFromItmno.Focus()
            Exit Sub
        ElseIf dtpFromTrand.Value > dtpToTrand.Value Then
            MsgBox("Invalid Date Range: From Date > To Date", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            dtpFromTrand.Focus()
            Exit Sub
        End If

        ' Format Date
        Dim fromdate As String
        Dim frommth As String
        Dim fromday As String
        frommth = "0" & dtpFromTrand.Value.Month.ToString
        fromday = "0" & dtpFromTrand.Value.Day.ToString
        fromdate = dtpFromTrand.Value.Year.ToString & "-" & frommth.Substring(frommth.Length - 2, 2) & "-" & fromday.Substring(fromday.Length - 2, 2)
        Dim todate As String
        Dim tomth As String
        Dim today As String
        tomth = "0" & dtpToTrand.Value.Month.ToString
        today = "0" & dtpToTrand.Value.Day.ToString
        todate = dtpToTrand.Value.Year.ToString & "-" & tomth.Substring(tomth.Length - 2, 2) & "-" & today.Substring(today.Length - 2, 2)

        gspStr = "sp_list_IMR00005 'UCPP','" & Trim(txtFromItmno.Text) & "','" & Trim(txtToItmno.Text) & "','" & fromdate & "','" & todate & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00005, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00005 sp_list_IMR00005 : " & rtnStr)
            Exit Sub
        End If

        If rs_IMR00005.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            rs_IMR00005.Tables("RESULT").Columns(14).ColumnName = "@fromvenno "
            rs_IMR00005.Tables("RESULT").Columns(15).ColumnName = "@tovenno"
            rs_IMR00005.Tables("RESULT").Columns(16).ColumnName = "@fromcredat"
            rs_IMR00005.Tables("RESULT").Columns(17).ColumnName = "@tocredat"


            Dim objRpt As New IMR00005Rpt
            objRpt.SetDataSource(rs_IMR00005.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        End If
    End Sub

    Private Sub cmdShowExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowExcel.Click
        If txtFromItmno.Text > txtToItmno.Text Then
            MsgBox("Invalid Item No. Range: From Item No. > To Item No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtFromItmno.Focus()
            Exit Sub
        ElseIf dtpFromTrand.Value > dtpToTrand.Value Then
            MsgBox("Invalid Date Range: From Date > To Date", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            dtpFromTrand.Focus()
            Exit Sub
        End If

        ' Format Date
        Dim fromdate As String
        Dim frommth As String
        Dim fromday As String
        frommth = "0" & dtpFromTrand.Value.Month.ToString
        fromday = "0" & dtpFromTrand.Value.Day.ToString
        fromdate = dtpFromTrand.Value.Year.ToString & "-" & frommth.Substring(frommth.Length - 2, 2) & "-" & fromday.Substring(fromday.Length - 2, 2)
        Dim todate As String
        Dim tomth As String
        Dim today As String
        tomth = "0" & dtpToTrand.Value.Month.ToString
        today = "0" & dtpToTrand.Value.Day.ToString
        todate = dtpToTrand.Value.Year.ToString & "-" & tomth.Substring(tomth.Length - 2, 2) & "-" & today.Substring(today.Length - 2, 2)

        Dim cus1no As String
        Dim cus2no As String
        cus1no = txt_S_PriCustAll.Text
        cus1no = cus1no.Replace("'", "''")
        cus2no = txt_S_SecCustAll.Text
        cus2no = cus2no.Replace("'", "''")

        gspStr = "sp_list_IMR00005_excel 'UCPP','" & Trim(txtFromItmno.Text) & "','" & Trim(txtToItmno.Text) & "','" _
                     & Trim(cus1no) & "','" & Trim(cus2no) & "','" & fromdate & "','" & todate & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement_ADO(gspStr, rs_IMR00005_excel, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00005 sp_list_IMR00005_excel : " & rtnStr)
            Exit Sub
        End If

        If rs_IMR00005_excel.RecordCount = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            exportExcel(rs_IMR00005_excel)

        End If
    End Sub

    Private Sub exportExcel(ByVal rs_EXCEL As ADODB.Recordset)
        ''''Start: Dont care about this part. This is the code farmat to call a excel'''''''
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        If rs_EXCEL.RecordCount >= 65500 Then
            MsgBox("There are more than 65500 records!")
            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet
        ''''End: Dont care about this part. This is the code farmat to call a excel''''''''''''

        Const HeaderRow As Integer = 1
        Dim curCol As Integer = 1
        xlsApp.Cells(HeaderRow + 1, curCol).copyfromrecordset(rs_EXCEL)

        setExcelFormat(xlsApp, xlsWB, xlsWS, HeaderRow, curCol)

        stageRamark(rs_EXCEL, xlsApp, xlsWB, xlsWS, curCol)

        itemNoGrouping(rs_EXCEL, xlsApp, xlsWB, xlsWS)

        Me.Cursor = Windows.Forms.Cursors.Default
        xlsApp.Visible = True
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

    End Sub

    Private Sub setExcelFormat(ByVal xlsApp As Excel.Application, _
                                ByVal xlsWB As Excel.Workbook, ByVal xlsWS As Excel.Worksheet, _
                                ByVal HeaderRow As Integer, ByRef curCol As Integer)




        xlsApp.Cells(HeaderRow, curCol) = "DV"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 5

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "PV"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 5

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Item No."
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 17
        xlsApp.Range(xlsApp.Cells(HeaderRow + 1, curCol + 1), xlsApp.Cells(HeaderRow + 1, curCol + 1)).Select()
        xlsApp.ActiveWindow.FreezePanes = True

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Update Date"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 16
        xlsApp.Columns(curCol).NumberFormat = "MM/dd/yyyy HH:mm"
        xlsApp.Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Period"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 8

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Pri" + Environment.NewLine + "Cust."
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 7

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Sec" + Environment.NewLine + "Cust."
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 7

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "UM"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 7

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Ftr"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 5

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Inr"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 5

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Mtr"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 5

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "CFT"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 9

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Fty Cst TTL"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 10

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Fty Prc TTL"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 10

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Excel File"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 32

        curCol = curCol + 1
        xlsApp.Cells(HeaderRow, curCol) = "Stage"
        xlsApp.Range(xlsApp.Cells(HeaderRow, curCol), xlsApp.Cells(HeaderRow, curCol)).ColumnWidth = 7
        'set filter
        xlsApp.Range(xlsApp.Cells(HeaderRow, 3), xlsApp.Cells(HeaderRow, curCol)).AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)

        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        xlsApp.Rows(1).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        xlsApp.Rows(1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    End Sub

    Private Sub stageRamark(ByVal rs_EXCEL As ADODB.Recordset, ByVal xlsApp As Excel.Application, _
                                ByVal xlsWB As Excel.Workbook, ByVal xlsWS As Excel.Worksheet, ByRef curCol As Integer)

        xlsApp.Range(xlsApp.Cells(rs_EXCEL.RecordCount + 3, 1), xlsApp.Cells(rs_EXCEL.RecordCount + 3, curCol)).Merge()
        xlsApp.Cells(rs_EXCEL.RecordCount + 3, 1) = "Stage : A = Approved, R = Rejected, I = Invalid, O = Overwrite, W = Waiting"
        xlsWS.Rows(rs_EXCEL.RecordCount + 3).Font.Bold = True
        xlsApp.Rows(rs_EXCEL.RecordCount + 3).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        xlsApp.Rows(rs_EXCEL.RecordCount + 3).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    End Sub

    Private Sub itemNoGrouping(ByVal rs_EXCEL As ADODB.Recordset, ByVal xlsApp As Excel.Application, _
                                ByVal xlsWB As Excel.Workbook, ByVal xlsWS As Excel.Worksheet)

        Dim recordCount As Integer
        Dim itemNoCol As Integer = 3
        recordCount = rs_EXCEL.RecordCount
        For i As Integer = 1 To recordCount - 1
            If xlsApp.Cells(recordCount + 1 - i + 1, itemNoCol).Value <> xlsApp.Cells(recordCount - i + 1, itemNoCol).Value Then

                xlsWS.Rows(recordCount + 1 - i + 1).Insert()
                xlsApp.Cells(recordCount + 1 - i + 1, 1) = "***"
                xlsApp.Cells(recordCount + 1 - i + 1, 1).Font.Name = "新細明體"
                xlsApp.Cells(recordCount + 1 - i + 1, 1).Font.size = 9
                xlsApp.Cells(recordCount + 1 - i + 1, 1).VerticalAlignment = Excel.XlVAlign.xlVAlignTop

                xlsApp.Rows(recordCount + 1 - i + 1).rowheight = 16.5
            End If
        Next
    End Sub
End Class