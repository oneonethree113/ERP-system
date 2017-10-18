Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class IMR00018

    Dim rs_IMR00018 As DataSet

    Private Sub IMR00018_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize Date Time Picker
        dtpFromTrand.Value = Date.Today
        dtpFromTrand.CustomFormat = "MM/dd/yy"
        dtpToTrand.Value = Date.Today
        dtpToTrand.CustomFormat = "MM/dd/yy"

        txtFromVenNc.MaxLength = 4
        txtToVenNc.MaxLength = 4

        Call Formstartup(Me.Name)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim txtRecSts As String = ""

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
        If txtFromVenNc.Text = "" Then
            MsgBox("Missing From Vendor No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtFromVenNc.Focus()
            Exit Sub
        ElseIf txtToVenNc.Text = "" Then
            MsgBox("Missing To Vendor No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtToVenNc.Focus()
            Exit Sub
        End If
        If txtFromVenNc.Text > txtToVenNc.Text Then
            MsgBox("Invalid Vendor Number Range: From Vendor. > To Vendor No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtFromVenNc.Focus()
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

        gspStr = "sp_select_IMR00018 '','" & txtRecSts & "','" & Trim(txtFromVenNc.Text) & "','" & _
                 Trim(txtToVenNc.Text) & "','" & fromdate & "','" & todate & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00018, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00018 #001 sp_select_IMR00018 : " & rtnStr)
            Exit Sub
        End If
        If rs_IMR00018.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            rs_IMR00018.Tables("RESULT").Columns(13).ColumnName = "@stage"
            rs_IMR00018.Tables("RESULT").Columns(14).ColumnName = "@fromvenno"
            rs_IMR00018.Tables("RESULT").Columns(15).ColumnName = "@tovenno"
            rs_IMR00018.Tables("RESULT").Columns(16).ColumnName = "@fromcredat"
            rs_IMR00018.Tables("RESULT").Columns(17).ColumnName = "@tocredat"
            Dim objRpt As New IMR00018Rpt
            objRpt.SetDataSource(rs_IMR00018.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        End If

    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Dim txtRecSts As String = ""

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
        If txtFromVenNc.Text = "" Then
            MsgBox("Missing From Vendor No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtFromVenNc.Focus()
            Exit Sub
        ElseIf txtToVenNc.Text = "" Then
            MsgBox("Missing To Vendor No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtToVenNc.Focus()
            Exit Sub
        End If
        If txtFromVenNc.Text > txtToVenNc.Text Then
            MsgBox("Invalid Vendor Number Range: From Vendor. > To Vendor No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtFromVenNc.Focus()
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

        gspStr = "sp_select_IMR00018_xls '','" & txtRecSts & "','" & Trim(txtFromVenNc.Text) & "','" & _
                 Trim(txtToVenNc.Text) & "','" & fromdate & "','" & todate & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Dim rs As New ADODB.Recordset
        rtnLong = execute_SQLStatement_ADO(gspStr, rs, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00018 #002 sp_select_IMR00018_xls : " & rtnStr)
            Exit Sub
        End If
        If rs.RecordCount = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            ExportToExcel(rs)
        End If

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
        xlsApp.Cells(1, 2) = "Item No."
        xlsApp.Cells(1, 3) = "D. Ven"
        xlsApp.Cells(1, 4) = "P. Ven"
        xlsApp.Cells(1, 5) = "Date"
        xlsApp.Cells(1, 6) = "Prod. Line"
        xlsApp.Cells(1, 7) = "English Desc."
        xlsApp.Cells(1, 8) = "UM"
        xlsApp.Cells(1, 9) = "Conv. Factor"
        xlsApp.Cells(1, 10) = "Inner"
        xlsApp.Cells(1, 11) = "Master"
        xlsApp.Cells(1, 12) = "Factory Price"
        xlsApp.Cells(1, 13) = "System Message"


        xlsWS.Rows(1).Font.Bold = True


        xlsApp.Cells(2, 1).copyfromrecordset(rs_EXCEL)

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub validateInput(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromVenNc.KeyPress, txtToVenNc.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class