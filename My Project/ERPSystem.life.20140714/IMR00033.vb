Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class IMR00033

    Private Sub IMR00033_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        ' Initialize Date Time Picker
        dtpFromTrand.Value = Date.Today
        dtpFromTrand.CustomFormat = "MM/dd/yy"
        dtpToTrand.Value = Date.Today
        dtpToTrand.CustomFormat = "MM/dd/yy"

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim txtRecSts As String = ""
        Dim rs_IMR00033 As New DataSet

        'Retrieve Record Status Flags
        If chkRecStsA.Checked Then
            txtRecSts = txtRecSts + "@A@,"
        End If
        If chkRecStsI.Checked Then
            txtRecSts = txtRecSts + "@I@,"
        End If
        If chkRecStsO.Checked Then
            txtRecSts = txtRecSts + "@O@,"
        End If
        If chkRecStsR.Checked Then
            txtRecSts = txtRecSts + "@R@,"
        End If
        If chkRecStsW.Checked Then
            txtRecSts = txtRecSts + "@W@,"
        End If

        ' Verify Inputs
        If txtRecSts = "" Then
            MsgBox("Missing Record Status", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            Exit Sub
        Else
            txtRecSts = txtRecSts.Substring(0, txtRecSts.Length - 1)
        End If

        If dtpFromTrand.Value > dtpToTrand.Value Then
            MsgBox("Invalid Date Range: From Date > To Date", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            dtpFromTrand.Focus()
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        gspStr = "sp_list_IMR00033 '','" & txtRecSts & "','" & dtpFromTrand.Value.ToString.Substring(0, 10) & "','" & _
                 dtpToTrand.Value.ToString.Substring(0, 10) & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00033, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00033 #001 sp_list_IMR00033 : " & rtnStr)
            Exit Sub
        End If
        If rs_IMR00033.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            Dim objRpt As New IMR00033Rpt
            objRpt.SetDataSource(rs_IMR00033.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Dim txtRecSts As String = ""
        Dim rs_IMR00033 As New DataSet

        'Retrieve Record Status Flags
        If chkRecStsA.Checked Then
            txtRecSts = txtRecSts + "@A@,"
        End If
        If chkRecStsI.Checked Then
            txtRecSts = txtRecSts + "@I@,"
        End If
        If chkRecStsO.Checked Then
            txtRecSts = txtRecSts + "@O@,"
        End If
        If chkRecStsR.Checked Then
            txtRecSts = txtRecSts + "@R@,"
        End If
        If chkRecStsW.Checked Then
            txtRecSts = txtRecSts + "@W@,"
        End If

        ' Verify Inputs
        If txtRecSts = "" Then
            MsgBox("Missing Record Status", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            Exit Sub
        Else
            txtRecSts = txtRecSts.Substring(0, txtRecSts.Length - 1)
        End If

        If dtpFromTrand.Value > dtpToTrand.Value Then
            MsgBox("Invalid Date Range: From Date > To Date", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            dtpFromTrand.Focus()
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        gspStr = "sp_list_IMR00033_xls '','" & txtRecSts & "','" & dtpFromTrand.Value.ToString.Substring(0, 10) & "','" & _
                 dtpToTrand.Value.ToString.Substring(0, 10) & "','" & gsUsrID & "'"

        Dim rs As New ADODB.Recordset
        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00033 #002 sp_list_IMR00033_xls : " & rtnStr)
            Exit Sub
        End If
        If rs.RecordCount = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            ExportToExcel(rs)
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub ExportToExcel(ByVal rs_EXCEL As ADODB.Recordset)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_EXCEL.RecordCount >= 65535 Then
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

        xlsApp.Cells(1, 1) = "Stage"
        xlsApp.Cells(1, 2) = "Date"
        xlsApp.Cells(1, 3) = "Item No."
        xlsApp.Cells(1, 4) = "Prod. Line"
        xlsApp.Cells(1, 5) = "English Desc."
        xlsApp.Cells(1, 6) = "UM"
        xlsApp.Cells(1, 7) = "Conv. Factor"
        xlsApp.Cells(1, 8) = "Inner"
        xlsApp.Cells(1, 9) = "Master"
        xlsApp.Cells(1, 10) = "Factory Cost"
        xlsApp.Cells(1, 11) = "System Message"


        xlsWS.Rows(1).Font.Bold = True


        xlsApp.Cells(2, 1).copyfromrecordset(rs_EXCEL)

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub
End Class