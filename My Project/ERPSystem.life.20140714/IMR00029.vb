Imports Microsoft.Office.Interop

Public Class IMR00029

    Dim rs_EXCEL As DataSet

    Private Sub IMR00029_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        ' Initialize Date Time Picker
        dtpFrom.Value = Date.Today
        dtpFrom.CustomFormat = "MM/dd/yyyy"
        dtpTo.Value = Date.Today
        dtpTo.CustomFormat = "MM/dd/yyyy"
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim status As String
        Dim exception As String

        If dtpTo.Value < dtpFrom.Value Then
            MsgBox("Invalid Input! (Start Date <=  End Date)!")
            dtpFrom.Focus()
            Exit Sub
        End If

        If optLatest.Checked = True Then
            status = "L"
        ElseIf optHistory.Checked = True Then
            status = "H"
        End If

        If optE_All.Checked = True Then
            Exception = "A"
        ElseIf optE_CVPV.Checked = True Then
            exception = "V"
        ElseIf optE_FtyCst.Checked = True Then
            Exception = "C"
        ElseIf optE_Pck.Checked = True Then
            Exception = "P"
        ElseIf optE_SAPSONo.Checked = True Then
            Exception = "S"
        End If

        gspStr = "sp_select_IMR00029 '" & gsCompany & "','" & status & "','" & exception & "','" & dtpFrom.Value.ToString & _
                 "','" & dtpTo.Value.ToString & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_EXCEL = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00029 #001 sp_select_IMR00029 : " & rtnStr)
            Exit Sub
        End If

        If rs_EXCEL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
            Exit Sub
        End If

        ExportToExcel()
    End Sub

    Private Sub ExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_EXCEL.Tables("RESULT").Rows.Count >= 65535 Then
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
                .Cells(headerRow, headerCol) = "Factory Data Comparison Report"
                .Rows(headerRow).rowHeight = 25
                .Cells(headerRow, headerCol).Font.Size = 20
                headerRow += 1

                Dim rptstatus As String
                Dim rptstage As String
                If optLatest.Checked = True Then rptstatus = "Latest" Else rptstatus = "History"

                If optE_All.Checked = True Then
                    rptstage = "Exception-All"
                ElseIf optE_CVPV.Checked = True Then
                    rptstage = "Exception-PV"
                ElseIf optE_FtyCst.Checked = True Then
                    rptstage = "Exception-FtyCst"
                Else
                    rptstage = "Exception"
                End If
                .Cells(headerRow, headerCol) = "Status: " & rptstatus & "   Stage: " & rptstage & "   Date from: " & dtpFrom.Value.ToString & "   Date to: " & dtpTo.Value.ToString
                .Cells(headerRow, headerCol).Font.Size = 12
                headerRow += 1

                .Cells(headerRow, headerCol) = "Co."
                headerCol += 1
                .Cells(headerRow, headerCol) = "SC No#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Pri Cus"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Job No#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Item#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "UM"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Inr"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Mtr"
                headerCol += 1
                .Cells(headerRow, headerCol) = "OdrQty"
                headerCol += 1
                .Cells(headerRow, headerCol) = "ShpQty"
                headerCol += 1
                .Cells(headerRow, headerCol) = "OSQty"
                headerCol += 1
                .Cells(headerRow, headerCol) = "SAP CV"
                headerCol += 1
                .Cells(headerRow, headerCol) = "HK CV"
                headerCol += 1
                .Cells(headerRow, headerCol) = "SAP PV"
                headerCol += 1
                .Cells(headerRow, headerCol) = "HK PV"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Curr"
                headerCol += 1
                .Cells(headerRow, headerCol) = "ZI03"
                headerCol += 1
                .Cells(headerRow, headerCol) = "HK DV FtyPrc"
                headerCol += 1
                .Cells(headerRow, headerCol) = "ZI01"
                headerCol += 1
                .Cells(headerRow, headerCol) = "HK PV FtyPrc"
                headerCol += 1
                .Cells(headerRow, headerCol) = "ZI02"
                headerCol += 1
                .Cells(headerRow, headerCol) = "ZI04"
                headerCol += 1
                .Cells(headerRow, headerCol) = "ZI05"
                headerCol += 1
                .Cells(headerRow, headerCol) = "PO Shpstr"
                headerCol += 1
                .Cells(headerRow, headerCol) = "PO Shpend"
                headerCol += 1
                .Cells(headerRow, headerCol) = "SAP SO#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "Line#"
                headerCol += 1
                .Cells(headerRow, headerCol) = "lastest"
                headerCol += 1
                .Cells(headerRow, headerCol) = "PV Approve Flag"
                headerCol += 1
                .Cells(headerRow, headerCol) = "PV Approve Date"
                headerCol += 1
                .Cells(headerRow, headerCol) = "CV Approve Flag"
                headerCol += 1
                .Cells(headerRow, headerCol) = "CV Approve Date"

                ' Data Population
                Dim entry(headerCol - 1) As Object

                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    entry(0) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_cocde")
                    entry(1) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_scno")
                    entry(2) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_cusno")
                    entry(3) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_jobord")
                    entry(4) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_itmno")
                    entry(5) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKuntcde")
                    entry(6) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKinrqty")
                    entry(7) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKmtrqty")
                    entry(8) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_odrqty")
                    entry(9) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_shpqty")
                    entry(10) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_osqty")
                    entry(11) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_ftyCVApp")
                    entry(12) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKCV")
                    entry(13) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_ftyPV")
                    entry(14) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKPV")
                    entry(15) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKPVftyprcCurr")
                    entry(16) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_fty03prc")
                    entry(17) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKDVftyprc")
                    entry(18) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_fty01prc")
                    entry(19) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKPVftyprc")
                    entry(20) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_fty02prc")
                    entry(21) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_fty04prc")
                    entry(22) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_fty05prc")
                    entry(23) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_poshpstr")
                    entry(24) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_poshpend")
                    entry(25) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKSAPSONo")
                    entry(26) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_HKSAPSOLine")
                    entry(27) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_lastest")
                    entry(28) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_apprvflg")
                    entry(29) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_apprvdt")
                    entry(30) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_cvapprvflg")
                    entry(31) = rs_EXCEL.Tables("RESULT").Rows(i)("tmp_cvapprvdt")

                    .Range(.Cells(headerRow + i + 1, 1), .Cells(headerRow + i + 1, headerCol)).Value = entry
                Next

                .Columns(1).ColumnWidth = 12
                For j As Integer = 2 To headerCol
                    .Columns(j).EntireColumn.AutoFit()
                Next
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
        rs_EXCEL = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class