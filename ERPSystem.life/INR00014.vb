Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class INR00014
    Inherits System.Windows.Forms.Form

    Public rs_SYMUSRCO As New DataSet
    Public rs_EXCEL As New DataSet
    Dim mode As String
    Dim rowCnt As Integer

    Private Sub INR00014_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Call FillCompCombo(gsUsrID, cboCoCde)
        'Call GetDefaultCompany(cboCoCde, txtCoNam)

        'If gsDefaultCompany <> "MS" Then
        '    Me.cboCoCde.Items.Add("UC-G")
        'End If

        Call Formstartup(Me.Name)

        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00010 #001 sp_select_SYMUSRCO : " & rtnStr)
        Else
            Dim i As Integer
            Dim strCocde As String
            strCocde = ""

            If rs_SYMUSRCO.Tables("RESULT").Rows.Count > 0 Then
                For i = 0 To rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1
                    If rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") <> "MS" Then
                        If i <> rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1 Then
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") + ","
                        Else
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde")
                        End If
                    End If
                Next i
            End If

            Me.txt_S_CoCde.Text = strCocde
        End If

        'Me.txt_S_CoCde.Text = "UCPP,UCP,PG,EW,TT,HB"
        'Me.txt_S_VdrCde.Text = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z"
        'Me.txt_S_DateFm.CtlText = "08/21/2010"
        'Me.txt_S_DateTo.CtlText = "09/21/2010"

        Me.txt_S_DateFm.Text = System.DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy")
        Me.txt_S_DateTo.Text = System.DateTime.Now.ToString("MM/dd/yyyy")
        Me.optView1.Checked = True
        Me.opt1w.Checked = True
        Me.optALL.Checked = True

        mode = "INIT"
        'Call formInit(mode)
    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_INR00014(Me)
    End Sub

    Private Sub cmd_S_VdrCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_VdrCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_VdrCde.Name
        frmComSearch.callFmString = txt_S_VdrCde.Text

        frmComSearch.show_INR00014(Me)
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim COCDELIST As String
        Dim VDRCDELIST As String
        Dim DATFM As String
        Dim DATTO As String
        Dim rptType As String
        Dim rptPeriod As String
        Dim shipSts As String

        Try
            Me.Cursor = Cursors.WaitCursor

            If Trim(Me.txt_S_CoCde.Text) = "" Then
                MsgBox("The Company Code List is empty!")
                Exit Sub
            Else
                If Len(Me.txt_S_CoCde.Text) > 1000 Then
                    MsgBox("The Company Code List is too long (1000 char)")
                    Exit Sub
                End If
                COCDELIST = removeDuplicateItem(Trim(Me.txt_S_CoCde.Text))
                COCDELIST = COCDELIST.Replace("'", "''")
            End If

            If Trim(Me.txt_S_VdrCde.Text) = "" Then
                MsgBox("Vendor List is empty!")
                Exit Sub
            Else
                If Len(Me.txt_S_VdrCde.Text) > 1000 Then
                    MsgBox("The Vendor List is too long (1000 char)")
                    Exit Sub
                End If
                VDRCDELIST = removeDuplicateItem(Trim(Me.txt_S_VdrCde.Text))
                VDRCDELIST = VDRCDELIST.Replace("'", "''")
            End If

            If Me.txt_S_DateFm.Text <> "__/__/____" Then
                If Not IsDate(Me.txt_S_DateFm.Text) Then
                    MsgBox("Invalid Date Format: Date From")
                    Me.txt_S_DateFm.Focus()
                    Exit Sub
                End If
            End If

            If Me.txt_S_DateTo.Text <> "__/__/____" Then
                If Not IsDate(Me.txt_S_DateTo.Text) Then
                    MsgBox("Invalid Date Format: Date To")
                    Me.txt_S_DateTo.Focus()
                    Exit Sub
                End If
            End If

            If Mid(Me.txt_S_DateFm.Text, 7) > Mid(Me.txt_S_DateTo.Text, 7) Then
                MsgBox("Date: End Date < Start Date (YY)")
                Me.txt_S_DateFm.Focus()
                Exit Sub
            ElseIf Mid(Me.txt_S_DateFm.Text, 7) = Mid(Me.txt_S_DateTo.Text, 7) Then
                If Me.txt_S_DateFm.Text.Substring(0, 2) > Me.txt_S_DateTo.Text.Substring(0, 2) Then
                    MsgBox("Date: End Date < Start Date (MM)")
                    Me.txt_S_DateFm.Focus()
                    Exit Sub
                ElseIf Me.txt_S_DateFm.Text.Substring(0, 2) = Me.txt_S_DateTo.Text.Substring(0, 2) Then
                    If Me.txt_S_DateFm.Text.Substring(4, 2) > Me.txt_S_DateTo.Text.Substring(4, 2) Then
                        MsgBox("Date: End Date < Start Date (DD)")
                        Me.txt_S_DateFm.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If Me.txt_S_DateFm.Text = "__/__/____" Then
                DATFM = "01/01/1900"
            Else
                DATFM = Me.txt_S_DateFm.Text
            End If

            If Me.txt_S_DateTo.Text = "__/__/____" Then
                DATTO = "01/01/1900"
            Else
                DATTO = Me.txt_S_DateTo.Text
            End If

            ' C-All Shipment, P-Partial Shipment
            If Me.optALL.Checked = True Then
                shipSts = "C"
            Else
                shipSts = "P"
            End If

            If Me.opt2w.Checked = True Then
                rptPeriod = "2"
            ElseIf Me.opt4w.Checked = True Then
                rptPeriod = "4"
            Else
                rptPeriod = "1"
            End If

            If Me.optView1.Checked = True Then
                rptType = "1"
            Else
                ' ???
                rptType = "2"
            End If

            gspStr = "sp_select_INR00014 '" & _
                        COCDELIST & "','" & _
                        VDRCDELIST & "','" & _
                        DATFM & "','" & _
                        DATTO & " 23:59:59','" & _
                        rptType & "','" & _
                        shipSts & "','" & _
                        rptPeriod & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00014 #002 sp_list_INR00014 : " & rtnStr)
            Else
                rowCnt = rs_EXCEL.Tables("RESULT").Rows.Count

                If rowCnt = 0 Then
                    MsgBox("No Record found!")
                Else
                    Call ExportToExcel(rptType, shipSts, rptPeriod)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ExportToExcel(ByVal strRptType As String, ByVal strShipSts As String, ByVal strPeriod As String)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim dt, dtCo, dtVdr, dtDate As DataTable
        Dim dr, drCo, drVdr, drDate As System.Data.DataRow
        Dim da() As DataRow
        Dim dv As DataView
        Dim i, iCol, iRow As Integer
        Dim shpCBM, ordCBM As Double
        Dim colDataSt, colDataEnd, rowDataSt, rowDataEnd As Integer
        Dim strCocde As String = String.Empty

        Try
            Me.Cursor = Cursors.WaitCursor
            dt = rs_EXCEL.Tables("RESULT")

            ' Create Company Index Table
            dtCo = rs_EXCEL.Tables.Add("COMPANY")
            dtCo.Columns.Add("cocde", Type.GetType("System.String"))
            dtCo.Columns.Add("coName", Type.GetType("System.String"))

            For Each dr In dt.Rows
                da = dtCo.Select("cocde = '" & dr.Item("cocde").ToString & "'")
                If Not da.Length > 0 Then
                    drCo = dtCo.NewRow
                    drCo(0) = dr.Item("cocde").ToString
                    drCo(1) = dr.Item("coName").ToString
                    dtCo.Rows.Add(drCo)
                End If
            Next

            ' Create Date Index Table
            dtDate = rs_EXCEL.Tables.Add("DATE")
            dtDate.Columns.Add("dateFm", Type.GetType("System.DateTime"))
            dtDate.Columns.Add("dateTo", Type.GetType("System.DateTime"))

            For Each dr In dt.Rows
                da = dtDate.Select("dateFm = '" & dr.Item("dateFm").ToString & "'")
                If Not da.Length > 0 Then
                    drDate = dtDate.NewRow
                    drDate(0) = dr.Item("dateFm").ToString
                    drDate(1) = dr.Item("dateTo").ToString
                    dtDate.Rows.Add(drDate)
                End If
            Next

            ' Create Vendor Index Table
            dtVdr = rs_EXCEL.Tables.Add("VENDOR")
            dtVdr.Columns.Add("venno", Type.GetType("System.String"))
            dtVdr.Columns.Add("venName", Type.GetType("System.String"))
            dtVdr.Columns.Add("ordCBM", Type.GetType("System.Double"))
            dtVdr.Columns.Add("shpCBM", Type.GetType("System.Double"))

            For Each dr In dt.Rows
                If CType(dr.Item("CBM"), Double) > 0 Then
                    da = dtVdr.Select("venno = '" & dr.Item("venno").ToString & "'")
                    If Not da.Length > 0 Then
                        drVdr = dtVdr.NewRow
                        drVdr(0) = dr.Item("venno").ToString
                        drVdr(1) = dr.Item("venName").ToString
                        drVdr(2) = 0
                        drVdr(3) = 0
                        dtVdr.Rows.Add(drVdr)
                    End If
                End If
            Next

            If dtVdr.Rows.Count = 0 Then
                MsgBox("No data for the chosen selection!")
                Exit Sub
            End If

            colDataSt = 3
            rowDataSt = 8
            colDataEnd = (colDataSt - 1) + 2 * dtVdr.Rows.Count
            rowDataEnd = (rowDataSt - 1) + dtDate.Rows.Count

            If colDataEnd > 256 Then
                MsgBox("There are more than 256 columns!")
                Exit Sub
            End If

            If rowDataEnd + 4 > 65536 Then
                MsgBox("There are more than 65536 rows!")
                Exit Sub
            End If

            xlsApp = New Excel.Application
            xlsApp.Visible = True
            xlsApp.UserControl = True

            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            xlsWB = xlsApp.Workbooks.Add()
            xlsWS = xlsWB.ActiveSheet

            With xlsApp

                ' Write Header to Excel
                ' Row 1
                .Range(.Cells(1, 1), .Cells(1, 5)).Merge()
                For Each drCo In dtCo.Rows
                    If Me.txt_S_CoCde.Text.Trim = drCo.Item("cocde").ToString Then
                        strCocde = drCo.Item("coName").ToString
                    End If
                Next

                If strCocde = String.Empty Then
                    .Cells(1, 1) = "UNITED CHINESE GROUP (" & Me.txt_S_CoCde.Text.Replace(",", "/") & ")"
                Else
                    .Cells(1, 1) = strCocde
                End If
                .Cells(1, 1).Font.Bold = True

                If colDataEnd >= 6 Then
                    .Cells(1, colDataEnd - 1) = "Report ID :"
                    .Cells(1, colDataEnd) = "INR00014"

                    .Cells(2, colDataEnd - 1) = "Print Date/Time :"
                    .Cells(2, colDataEnd) = Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss")
                End If

                ' Row 2
                .Range(.Cells(2, 1), .Cells(2, 5)).Merge()
                .Cells(2, 1) = "SCHEDULED SHIPMENT VS ACTUAL SHIPMENT REPORT"
                .Cells(2, 1).Font.Bold = True

                ' Row 3
                .Range(.Cells(3, 1), .Cells(3, 5)).Merge()
                If strShipSts = "C" Then
                    .Cells(3, 1) = "Order Status : All"
                Else
                    .Cells(3, 1) = "Order Status : OS"
                End If
                .Cells(3, 1).Font.Bold = True

                .Cells(4, 1).Font.Bold = True

                ' Row 4
                .Range(.Cells(4, 1), .Cells(4, 5)).Merge()
                .Cells(4, 1) = "Date Range : " & Me.txt_S_DateFm.Text & " - " & Me.txt_S_DateTo.Text
                .Cells(4, 1).Font.Bold = True

                ' Row 6
                .Range(.Cells(6, 1), .Cells(6, 2)).Merge()
                .Cells(6, 1) = "PERIOD"
                .Cells(6, 1).EntireRow.Font.Bold = True

                ' Write Vendor Header
                dv = dtDate.DefaultView
                dv.Sort = "dateFm asc"
                dtDate = dv.ToTable

                dv = dtVdr.DefaultView
                dv.Sort = "venno asc"
                dtVdr = dv.ToTable

                iCol = colDataSt
                For Each drVdr In dtVdr.Rows
                    .Range(.Cells(6, iCol), .Cells(6, iCol + 1)).Merge()
                    .Cells(6, iCol) = drVdr.Item("venName").ToString & " (" & drVdr.Item("venno").ToString & ")"

                    If strShipSts = "C" Then
                        .Cells(7, iCol) = "Ordered"
                        .Cells(7, iCol + 1) = "Shipped"
                    Else
                        .Cells(7, iCol) = "OS"
                        .Cells(7, iCol + 1) = "Expired"
                    End If
                    iCol = iCol + 2
                Next

                ' Write Data to Excel 
                iRow = rowDataSt
                For Each drDate In dtDate.Rows

                    .Range(.Cells(iRow, 1), .Cells(iRow, 2)).Merge()
                    .Cells(iRow, 1) = Format(drDate.Item("dateFm"), "MM/dd/yyyy") & " - " & Format(drDate.Item("dateTo"), "MM/dd/yyyy")

                    iCol = colDataSt
                    For Each drVdr In dtVdr.Rows
                        da = dt.Select("venno = '" & drVdr.Item("venno").ToString & "' and dateFm = '" & drDate.Item("dateFm").ToString & "'")

                        shpCBM = 0
                        ordCBM = 0
                        If da.Length > 0 Then
                            For i = 0 To da.Length - 1
                                If da(i).Item("cbmType").ToString = "O" Then
                                    ordCBM = ordCBM + CType(da(i).Item("CBM"), Double)
                                End If

                                If da(i).Item("cbmType").ToString = "S" Then
                                    shpCBM = shpCBM + CType(da(i).Item("CBM"), Double)
                                End If
                            Next i
                        End If

                        .Cells(iRow, iCol) = Math.Round(ordCBM).ToString
                        .Cells(iRow, iCol + 1) = Math.Round(shpCBM).ToString
                        drVdr.Item("ordCBM") = drVdr.Item("ordCBM") + Math.Round(ordCBM)
                        drVdr.Item("shpCBM") = drVdr.Item("shpCBM") + Math.Round(shpCBM)

                        iCol = iCol + 2
                    Next
                    iRow = iRow + 1
                Next

                ' Write Total to Excel
                .Range(.Cells(rowDataEnd + 1, 1), .Cells(rowDataEnd + 1, 2)).Merge()
                .Cells(rowDataEnd + 1, 1) = "Total CBM :"

                dv = dtVdr.DefaultView
                dv.Sort = "venno asc"

                iCol = colDataSt
                For Each drVdr In dtVdr.Rows
                    .Range(.Cells(6, iCol), .Cells(rowDataEnd + 1, iCol)).Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Excel.XlBorderWeight.xlMedium
                    .Cells(iRow, 1) = "Total CBM :"
                    .Cells(iRow, iCol) = drVdr.Item("ordCBM").ToString
                    .Cells(iRow, iCol + 1) = drVdr.Item("shpCBM").ToString
                    iCol = iCol + 2
                Next

                ' Write Remarks
                .Cells(rowDataEnd + 3, 1) = "Remark : "

                If strShipSts = "C" Then
                    .Cells(rowDataEnd + 4, 1) = "CBM Ordered figure are based on the order carton and shipping start-date from SC Order."
                    .Cells(rowDataEnd + 5, 1) = "CBM Shipped figure are based on the shipped carton and shipping issue-date from Shipping Maintenance"
                Else
                    .Cells(rowDataEnd + 4, 1) = "CBM Outstanding figure are based on the order carton and shipping start-date from outstanding SC Order."
                    .Cells(rowDataEnd + 5, 1) = "Expired: Shippment schedule has been expired & waiting for sales further information."
                End If

                ' Set Border, Align, Font, ColumnWidth
                .Range(.Cells(6, 1), .Cells(6, colDataEnd)).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlMedium
                .Range(.Cells(6, colDataSt), .Cells(6, colDataEnd)).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThin
                .Range(.Cells(7, 1), .Cells(7, colDataEnd)).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium

                .Range(.Cells(6, 1), .Cells(rowDataEnd + 1, colDataEnd)).Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Excel.XlBorderWeight.xlMedium
                .Range(.Cells(6, 1), .Cells(rowDataEnd + 1, colDataEnd)).Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Excel.XlBorderWeight.xlMedium

                .Range(.Cells(rowDataEnd + 1, 1), .Cells(rowDataEnd + 1, colDataEnd)).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlMedium
                .Range(.Cells(rowDataEnd + 1, 1), .Cells(rowDataEnd + 1, colDataEnd)).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium

                .Range(.Cells(6, colDataSt), .Cells(7, colDataEnd)).HorizontalAlignment = Excel.Constants.xlCenter

                .Range(.Cells(1, 1), .Cells(rowDataEnd + 5, colDataEnd)).Font.Size = 10
                .Range(.Cells(1, 1), .Cells(rowDataEnd + 5, colDataEnd)).ColumnWidth = 10.5
            End With

            'xlsWB.Close()
            'xlsApp.Quit()

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            If Not rs_EXCEL Is Nothing Then
                rs_EXCEL = Nothing
            End If
            'releaseObject(xlsWS)
            'releaseObject(xlsWB)
            'releaseObject(xlsApp)

            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
        End Try
    End Sub

    Private Function removeDuplicateItem(ByVal s As String) As String
        Return s
    End Function
End Class