Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel


'Imports System.Data.OleDbsam
'Imports ADODB

Public Class CLR00004
    Inherits System.Windows.Forms.Form

    Public rs_SYMUSRCO As New DataSet
    Public rs_CLR00004 As New DataSet

    Dim rowCnt As Integer
    Dim dsNewRow As DataRow
    Dim mode As String
    Public rs_SYCLMPST As New DataSet
    Public rs_SYCLMIST As New DataSet
    Public rs_SYCLMTYP As New DataSet
    Public rs_excel As New DataSet
    Dim rs_SYSALINF_TEAM As DataSet
    Dim rs_SYSALINF_TEAM_load As DataSet
    Dim rs_curex As New DataSet
    Dim gl_rate As Decimal


    Private Sub CLR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLR00004 #001 sp_select_SYMUSRCO : " & rtnStr)
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


        gspStr = "sp_select_CLCUREX '" & gsCompany & "','','N'"
        rtnLong = execute_SQLStatement(gspStr, rs_curex, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_CLCUREX : " & rtnStr)
        End If

        gl_rate = rs_curex.Tables("RESULT").Rows(0).Item("cce_selrat")


        Call Formstartup(Me.Name)

        Call format_cboClaimPeriod()
        cboClaimPeriod.Text = ""

        cboAppLevel_cs.Items.Clear()
        cboAppLevel_cs.Items.Add("")
        cboAppLevel_cs.Items.Add("APV1a")
        cboAppLevel_cs.Items.Add("APV2a")
        cboAppLevel_cs.Items.Add("APV3a")
        cboAppLevel_cts.Items.Clear()
        cboAppLevel_cts.Items.Add("")
        cboAppLevel_cts.Items.Add("APV1b")
        cboAppLevel_cts.Items.Add("APV2b")
        cboAppLevel_cts.Items.Add("APV3b")

        gspStr = "sp_list_SYCLMPST ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMPST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMPST :" & rtnStr)
            'Exit Sub
        End If
        Call format_cboClaimPaySTS()

        gspStr = "sp_list_SYCLMIST ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMIST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMIST :" & rtnStr)
            'Exit Sub
        End If

        Call format_cboClaimIncomeSTS()

        gspStr = "sp_list_SYCLMTYP ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMTYP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMTYP :" & rtnStr)
            'Exit Sub
        End If

        Call format_cboClaimType("")

        cbo_Hdr_ClaimAmtCurrency.Items.Clear()
        cbo_Hdr_ClaimAmtCurrency.Items.Add("")
        cbo_Hdr_ClaimAmtCurrency.Items.Add("USD")
        cbo_Hdr_ClaimAmtCurrency.Items.Add("HKD")

        cbo_Hdr_ClaimAmtCurrency2.Items.Clear()
        cbo_Hdr_ClaimAmtCurrency2.Items.Add("")
        cbo_Hdr_ClaimAmtCurrency2.Items.Add("USD")
        cbo_Hdr_ClaimAmtCurrency2.Items.Add("HKD")

        cbo_ClaimToCP.Items.Clear()
        cbo_ClaimToCP.Items.Add("")
        cbo_ClaimToCP.Items.Add("USD")
        cbo_ClaimToCP.Items.Add("HKD")

        cbo_ClaimToCF.Items.Clear()
        cbo_ClaimToCF.Items.Add("")
        cbo_ClaimToCF.Items.Add("USD")
        cbo_ClaimToCF.Items.Add("HKD")

        cbo_ClaimToVP.Items.Clear()
        cbo_ClaimToVP.Items.Add("")
        cbo_ClaimToVP.Items.Add("USD")
        cbo_ClaimToVP.Items.Add("HKD")

        cbo_ClaimToVF.Items.Clear()
        cbo_ClaimToVF.Items.Add("")
        cbo_ClaimToVF.Items.Add("USD")
        cbo_ClaimToVF.Items.Add("HKD")

        gspStr = "sp_list_SYSALINF '" & gsCompany & "','TEAM'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALINF_TEAM, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading loadSYSALINF_MGR #001 sp_list_SYSALINF :" & rtnStr)
            Exit Sub
        End If
        rs_SYSALINF_TEAM_load = rs_SYSALINF_TEAM.Copy()

        cbo_ST.Items.Clear()
        cbo_ST.Items.Add("")
        For i As Integer = 0 To rs_SYSALINF_TEAM_load.Tables("RESULT").Rows.Count - 1
            cbo_ST.Items.Add(rs_SYSALINF_TEAM_load.Tables("RESULT").Rows(i)("ssi_saltem"))
        Next
        cbo_ST.Sorted = True
        cbo_ST.SelectedIndex = 0




    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_frmS(Me.cmd_S_CoCde)
    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        txt_S_PriCust.Name = "txt_S_PriCustAll"
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub




    Private Sub ExportToExcel(ByVal rs_EXCEL As ADODB.Recordset)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim title As String
        Dim i As Integer

        title = "Customer Claim Report (Summary)"

        If rs_EXCEL.RecordCount >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        'Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        'For i = 0 To rs_EXCEL.Fields.Count - 1
        '    xlsApp.Cells(2, i + 1) = rs_EXCEL.Fields(i).Name
        'Next

        'xlsWS.Rows(2).Font.Bold = True

        'xlsWS.Cells(1, 1) = title
        'xlsWS.Rows(1).Font.Bold = True

        'xlsApp.Cells(3, 1).copyfromrecordset(rs_EXCEL)

        'xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        'xlsApp.Selection.CurrentRegion.rows.AutoFit()

        ''**********make pink color*********'
        'For i = 4 To 21
        '    xlsWS.Cells(2, i).Interior.ColorIndex = 38
        'Next

        'For i = 26 To 34
        '    xlsWS.Cells(2, i).Interior.ColorIndex = 38
        'Next
        ''*********************************'

        '***********merge the field of topic*******'
        xlsWS.Range("A1:AT1").MergeCells = True

        'Dim recCount As Integer
        'Dim location As String
        'Dim j As Integer
        'recCount = rs_EXCEL.Fields.Count - 1
        'For i = 2 To recCount
        '    'location = "K" + i.ToString
        '    For j = 0 To 40
        '****************************************excel format*****************'
        'xlsWS.Range(xlsWS.Cells(2, 1), xlsWS.Cells(rs_EXCEL.Fields.Count, 60)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 11), xlsWS.Cells(rs_EXCEL.Fields.Count, 11)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 13), xlsWS.Cells(rs_EXCEL.Fields.Count, 13)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 16), xlsWS.Cells(rs_EXCEL.Fields.Count, 16)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 18), xlsWS.Cells(rs_EXCEL.Fields.Count, 18)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 20), xlsWS.Cells(rs_EXCEL.Fields.Count, 20)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 22), xlsWS.Cells(rs_EXCEL.Fields.Count, 22)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 37), xlsWS.Cells(rs_EXCEL.Fields.Count, 37)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 39), xlsWS.Cells(rs_EXCEL.Fields.Count, 39)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 42), xlsWS.Cells(rs_EXCEL.Fields.Count, 42)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 44), xlsWS.Cells(rs_EXCEL.Fields.Count, 44)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 46), xlsWS.Cells(rs_EXCEL.Fields.Count, 46)).HorizontalAlignment = 6
        Dim k As Integer
        For i = 1 To 65536
            If xlsWS.Cells(i, "A").Value = "" Then
                k = i - 1
                Exit For
            End If
        Next

        'Give total at last line
        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).FormulaR1C1 = "=SUM(R3C11:R" & k & "C11) "
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).FormulaR1C1 = "=SUM(R3C13:R" & k & "C13)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).FormulaR1C1 = "=SUM(R3C16:R" & k & "C16)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).FormulaR1C1 = "=SUM(R3C18:R" & k & "C18)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).FormulaR1C1 = "=SUM(R3C20:R" & k & "C20)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).FormulaR1C1 = "=SUM(R3C22:R" & k & "C22)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).FormulaR1C1 = "=SUM(R3C37:R" & k & "C37)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).FormulaR1C1 = "=SUM(R3C39:R" & k & "C39)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).FormulaR1C1 = "=SUM(R3C42:R" & k & "C42)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).FormulaR1C1 = "=SUM(R3C44:R" & k & "C44)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).FormulaR1C1 = "=SUM(R3C46:R" & k & "C46)"


        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).NumberFormat = "#,##0.00"

        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).Font.Bold = True

        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).Font.Underline = True

        Dim a As String
        a = "A:" + rs_EXCEL.Fields.Count.ToString

        'xlsWS.Columns("A:AT").ColumnWidth = 8
        With xlsWS
            .Columns("K").ColumnWidth = 14.63
            .Columns("M").ColumnWidth = 15.38
            .Columns("P").ColumnWidth = 15.2
            .Columns("R").ColumnWidth = 15.75
            .Columns("T").ColumnWidth = 16
            .Columns("V").ColumnWidth = 16.28
            .Columns("AK").ColumnWidth = 14.6
            .Columns("AM").ColumnWidth = 11.64
            .Columns("AP").ColumnWidth = 15
            .Columns("AR").ColumnWidth = 15.25
            .Columns("AT").ColumnWidth = 12.75
            .Columns("N").ColumnWidth = 14.63
            .Columns("W").ColumnWidth = 6
            .Columns("X").ColumnWidth = 15.6
            .Columns("Y").ColumnWidth = 7
            .Columns("Z").ColumnWidth = 9
            .Columns("AA").ColumnWidth = 5
            .Columns("AB").ColumnWidth = 10
            .Columns("AC").ColumnWidth = 9
            .Columns("AD").ColumnWidth = 10
            .Columns("AE").ColumnWidth = 7
            .Columns("AF").ColumnWidth = 14
            .Columns("AG").ColumnWidth = 10.75
            .Columns("AH").ColumnWidth = 8
            .Columns("AI").ColumnWidth = 12.75
            .Columns("AJ").ColumnWidth = 4


            .Columns("A").ColumnWidth = 6
            .Columns("B").ColumnWidth = 14.63
            .Columns("C").ColumnWidth = 6
            .Columns("D").ColumnWidth = 14.63
            .Columns("E").ColumnWidth = 12.9
            .Columns("F").ColumnWidth = 9.5
            .Columns("G").ColumnWidth = 14.63
            .Columns("H").ColumnWidth = 15.38
            .Columns("I").ColumnWidth = 6
            .Columns("J").ColumnWidth = 10
            .Columns("k").ColumnWidth = 6
            .Columns("L").ColumnWidth = 10
            .Columns("M").ColumnWidth = 6
            .Columns("N").ColumnWidth = 10
            .Columns("O").ColumnWidth = 6
            .Columns("P").ColumnWidth = 10
            .Columns("Q").ColumnWidth = 6
            .Columns("R").ColumnWidth = 10

            .Columns("S").ColumnWidth = 0
            .Columns("T").ColumnWidth = 0

            .Columns("U").ColumnWidth = 0

            .Columns("V").ColumnWidth = 6
            .Columns("W").ColumnWidth = 13
            .Columns("X").ColumnWidth = 5
            .Columns("Y").ColumnWidth = 13
            .Columns("Z").ColumnWidth = 5

            .Columns("AA").ColumnWidth = 14
            .Columns("AB").ColumnWidth = 13
            .Columns("AC").ColumnWidth = 13
            .Columns("AD").ColumnWidth = 13
            .Columns("AE").ColumnWidth = 6
            .Columns("AF").ColumnWidth = 10
            .Columns("AG").ColumnWidth = 6
            .Columns("AH").ColumnWidth = 10
            .Columns("AI").ColumnWidth = 6
            .Columns("AJ").ColumnWidth = 10
            .Columns("AK").ColumnWidth = 6
            .Columns("AL").ColumnWidth = 13
            .Columns("AM").ColumnWidth = 6
            .Columns("AN").ColumnWidth = 13
            '.Columns("AO").ColumnWidth = 4
            '.Columns("AQ").ColumnWidth = 4
            '.Columns("AS").ColumnWidth = 4
            '.Columns("AN").ColumnWidth = 6
            '.Columns("AO").ColumnWidth = 15
            '.Columns("AO").ColumnWidth = 14.88

            '.Columns("AP").ColumnWidth = 14.88

        End With

        xlsWS.Range(xlsWS.Cells(2, 1), xlsWS.Cells(k, rs_EXCEL.Fields.Count)).HorizontalAlignment = Excel.Constants.xlLeft

        Dim h As String

        h = xlsWS.Cells(2, "E").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "E").Value = h

        h = xlsWS.Cells(2, "H").Value
        h = h.Insert(InStr(1, h, "Status", CompareMethod.Text) + 6, Chr(10))
        xlsWS.Cells(2, "H").Value = h

        h = xlsWS.Cells(2, "I").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "I").Value = h

        h = xlsWS.Cells(2, "K").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "K").Value = h

        h = xlsWS.Cells(2, "R").Value
        h = h.Insert(InStr(1, h, "Vendor", CompareMethod.Text) + 6, Chr(10))
        xlsWS.Cells(2, "R").Value = h

        h = xlsWS.Cells(2, "T").Value
        h = h.Insert(InStr(1, h, "Vendor", CompareMethod.Text) + 6, Chr(10))
        xlsWS.Cells(2, "T").Value = h

        h = xlsWS.Cells(2, "M").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "M").Value = h

        'h = xlsWS.Cells(2, "N").Value
        'h = h.Insert(InStr(1, h, "Amount", CompareMethod.Text) + 6, Chr(10))
        'xlsWS.Cells(2, "N").Value = h

        h = xlsWS.Cells(2, "P").Value
        h = h.Insert(InStr(1, h, "Insurance", CompareMethod.Text) + 16, Chr(10))
        xlsWS.Cells(2, "P").Value = h

        h = xlsWS.Cells(2, "V").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "V").Value = h

        h = xlsWS.Cells(2, "W").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "W").Value = h

        'h = xlsWS.Cells(2, "X").Value
        'h = h.Insert(InStr(1, h, "Status", CompareMethod.Text) + 6, Chr(10))
        'xlsWS.Cells(2, "X").Value = h

        h = xlsWS.Cells(2, "AH").Value
        h = h.Insert(InStr(1, h, "Issue", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "AH").Value = h

        h = xlsWS.Cells(2, "AI").Value
        h = h.Insert(InStr(1, h, "Issue", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "AI").Value = h

        h = xlsWS.Cells(2, "AK").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "AK").Value = h

        'h = xlsWS.Cells(2, "AR").Value
        'h = h.Insert(InStr(1, h, "Internal", CompareMethod.Text) + 8, Chr(10))
        'xlsWS.Cells(2, "AR").Value = h

        h = xlsWS.Cells(2, "AM").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "AM").Value = h

        'h = xlsWS.Cells(2, "AN").Value
        'h = h.Insert(InStr(1, h, "Profit", CompareMethod.Text) + 6, Chr(10))
        'xlsWS.Cells(2, "AN").Value = h

        'h = xlsWS.Cells(2, "AP").Value
        'h = h.Insert(InStr(1, h, "Insurance", CompareMethod.Text) + 9, Chr(10))
        'xlsWS.Cells(2, "AP").Value = h

        'h = xlsWS.Cells(2, "AT").Value
        'h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "AT").Value = h

        xlsWS.Range(xlsWS.Cells(3, 11), xlsWS.Cells(k, 11)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 13), xlsWS.Cells(k, 13)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 14), xlsWS.Cells(k, 14)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 16), xlsWS.Cells(k, 16)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 18), xlsWS.Cells(k, 18)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 20), xlsWS.Cells(k, 20)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 22), xlsWS.Cells(k, 22)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 37), xlsWS.Cells(k, 37)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 39), xlsWS.Cells(k, 39)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 40), xlsWS.Cells(k, 40)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 42), xlsWS.Cells(k, 42)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 44), xlsWS.Cells(k, 44)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 46), xlsWS.Cells(k, 46)).HorizontalAlignment = Excel.Constants.xlRight


        xlsWS.Range(xlsWS.Cells(3, 11), xlsWS.Cells(k, 11)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 13), xlsWS.Cells(k, 13)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 16), xlsWS.Cells(k, 16)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 18), xlsWS.Cells(k, 18)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 20), xlsWS.Cells(k, 20)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 22), xlsWS.Cells(k, 22)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 37), xlsWS.Cells(k, 37)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 39), xlsWS.Cells(k, 39)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 42), xlsWS.Cells(k, 42)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 44), xlsWS.Cells(k, 44)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 46), xlsWS.Cells(k, 46)).NumberFormat = "#,##0.00"
 
        '*********************************************************************'
        'location = "M" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "P" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "R" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "T" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        '    Next
        'Next

        'Dim j As Integer
        'For i = 2 To xlsWS.Cells(1, "A").End(Excel.XlDirection.xlDown).Row
        '    For j = 1 To 44
        '        xlsWS.Cells(i, j).BorderAround(Excel.XlLineStyle.xlContinuous)
        '    Next
        'Next
        'For i = 0 To rs_EXCEL.Fields.Count - 1
        '    If xlsApp.Columns(i + 1).Width > 100 Then
        '        'xlsWS.Columns(i + 1).Width = 100.0
        '    End If
        'Next
    End Sub
    Private Sub ExportToExcel_donot_show_dtl(ByVal rs_EXCEL As ADODB.Recordset)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty
        Dim title As String
        Dim i As Integer

        title = "Customer Claim Report (Summary, do not include shipment detail )"

        If rs_EXCEL.RecordCount >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        For i = 0 To rs_EXCEL.Fields.Count - 1
            xlsApp.Cells(2, i + 1) = rs_EXCEL.Fields(i).Name
        Next

        xlsWS.Rows(2).Font.Bold = True

        xlsWS.Cells(1, 1) = title
        xlsWS.Rows(1).Font.Bold = True

        xlsApp.Cells(3, 1).copyfromrecordset(rs_EXCEL)

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        ''**********make pink color*********'
        'For i = 4 To 21
        '    xlsWS.Cells(2, i).Interior.ColorIndex = 38
        'Next

        'For i = 26 To 34
        '    xlsWS.Cells(2, i).Interior.ColorIndex = 38
        'Next
        ''*********************************'

        '***********merge the field of topic*******'
        xlsWS.Range("A1:AT1").MergeCells = True

        'Dim recCount As Integer
        'Dim location As String
        'Dim j As Integer
        'recCount = rs_EXCEL.Fields.Count - 1
        'For i = 2 To recCount
        '    'location = "K" + i.ToString
        '    For j = 0 To 40
        '****************************************excel format*****************'
        'xlsWS.Range(xlsWS.Cells(2, 1), xlsWS.Cells(rs_EXCEL.Fields.Count, 60)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 11), xlsWS.Cells(rs_EXCEL.Fields.Count, 11)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 13), xlsWS.Cells(rs_EXCEL.Fields.Count, 13)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 16), xlsWS.Cells(rs_EXCEL.Fields.Count, 16)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 18), xlsWS.Cells(rs_EXCEL.Fields.Count, 18)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 20), xlsWS.Cells(rs_EXCEL.Fields.Count, 20)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 22), xlsWS.Cells(rs_EXCEL.Fields.Count, 22)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 37), xlsWS.Cells(rs_EXCEL.Fields.Count, 37)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 39), xlsWS.Cells(rs_EXCEL.Fields.Count, 39)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 42), xlsWS.Cells(rs_EXCEL.Fields.Count, 42)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 44), xlsWS.Cells(rs_EXCEL.Fields.Count, 44)).HorizontalAlignment = 6
        'xlsWS.Range(xlsWS.Cells(3, 46), xlsWS.Cells(rs_EXCEL.Fields.Count, 46)).HorizontalAlignment = 6
        Dim k As Integer
        For i = 1 To 65536
            If xlsWS.Cells(i, "A").Value = "" Then
                k = i - 1
                Exit For
            End If
        Next

        'Give total at last line
        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).FormulaR1C1 = "=SUM(R3C11:R" & k & "C11) "
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).FormulaR1C1 = "=SUM(R3C13:R" & k & "C13)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).FormulaR1C1 = "=SUM(R3C16:R" & k & "C16)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).FormulaR1C1 = "=SUM(R3C18:R" & k & "C18)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).FormulaR1C1 = "=SUM(R3C20:R" & k & "C20)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).FormulaR1C1 = "=SUM(R3C22:R" & k & "C22)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).FormulaR1C1 = "=SUM(R3C37:R" & k & "C37)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).FormulaR1C1 = "=SUM(R3C39:R" & k & "C39)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).FormulaR1C1 = "=SUM(R3C42:R" & k & "C42)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).FormulaR1C1 = "=SUM(R3C44:R" & k & "C44)"
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).FormulaR1C1 = "=SUM(R3C46:R" & k & "C46)"


        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).NumberFormat = "#,##0.00"

        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).Font.Bold = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).Font.Bold = True

        'xlsWS.Range(xlsWS.Cells(k + 2, 11), xlsWS.Cells(k + 2, 11)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 13), xlsWS.Cells(k + 2, 13)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 16), xlsWS.Cells(k + 2, 16)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 18), xlsWS.Cells(k + 2, 18)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 20), xlsWS.Cells(k + 2, 20)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 22), xlsWS.Cells(k + 2, 22)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 37), xlsWS.Cells(k + 2, 37)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 39), xlsWS.Cells(k + 2, 39)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 42), xlsWS.Cells(k + 2, 42)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 44), xlsWS.Cells(k + 2, 44)).Font.Underline = True
        'xlsWS.Range(xlsWS.Cells(k + 2, 46), xlsWS.Cells(k + 2, 46)).Font.Underline = True

        Dim a As String
        a = "A:" + rs_EXCEL.Fields.Count.ToString

        'xlsWS.Columns("A:AT").ColumnWidth = 8
        With xlsWS

            .Columns("A").ColumnWidth = 6
            .Columns("B").ColumnWidth = 14.63
            .Columns("C").ColumnWidth = 6
            .Columns("D").ColumnWidth = 14.63
            .Columns("E").ColumnWidth = 12.9
            .Columns("F").ColumnWidth = 9.5
            .Columns("G").ColumnWidth = 14.63
            .Columns("H").ColumnWidth = 15.38
            .Columns("I").ColumnWidth = 6
            .Columns("J").ColumnWidth = 10
            .Columns("k").ColumnWidth = 6
            .Columns("L").ColumnWidth = 10
            .Columns("M").ColumnWidth = 6
            .Columns("N").ColumnWidth = 10

            .Columns("O").ColumnWidth = 6
            .Columns("P").ColumnWidth = 10
            .Columns("Q").ColumnWidth = 6
            .Columns("R").ColumnWidth = 10

            .Columns("S").ColumnWidth = 0
            .Columns("T").ColumnWidth = 0
            .Columns("U").ColumnWidth = 6
            .Columns("V").ColumnWidth = 10
            .Columns("W").ColumnWidth = 6
            .Columns("X").ColumnWidth = 10

        End With

        xlsWS.Range(xlsWS.Cells(2, 1), xlsWS.Cells(k, rs_EXCEL.Fields.Count)).HorizontalAlignment = Excel.Constants.xlLeft

        Dim h As String

        h = xlsWS.Cells(2, "E").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "E").Value = h

        h = xlsWS.Cells(2, "H").Value
        h = h.Insert(InStr(1, h, "Status", CompareMethod.Text) + 6, Chr(10))
        xlsWS.Cells(2, "H").Value = h

        h = xlsWS.Cells(2, "I").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "I").Value = h

        h = xlsWS.Cells(2, "K").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "K").Value = h

        h = xlsWS.Cells(2, "R").Value
        h = h.Insert(InStr(1, h, "Vendor", CompareMethod.Text) + 6, Chr(10))
        xlsWS.Cells(2, "R").Value = h

        h = xlsWS.Cells(2, "T").Value
        h = h.Insert(InStr(1, h, "Vendor", CompareMethod.Text) + 6, Chr(10))
        xlsWS.Cells(2, "T").Value = h

        h = xlsWS.Cells(2, "M").Value
        h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        xlsWS.Cells(2, "M").Value = h

        'h = xlsWS.Cells(2, "N").Value
        'h = h.Insert(InStr(1, h, "Amount", CompareMethod.Text) + 6, Chr(10))
        'xlsWS.Cells(2, "N").Value = h

        h = xlsWS.Cells(2, "P").Value
        h = h.Insert(InStr(1, h, "Insurance", CompareMethod.Text) + 16, Chr(10))
        xlsWS.Cells(2, "P").Value = h

        'h = xlsWS.Cells(2, "V").Value
        'h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "V").Value = h

        'h = xlsWS.Cells(2, "W").Value
        'h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "W").Value = h

        'h = xlsWS.Cells(2, "X").Value
        'h = h.Insert(InStr(1, h, "Status", CompareMethod.Text) + 6, Chr(10))
        'xlsWS.Cells(2, "X").Value = h

        'h = xlsWS.Cells(2, "AH").Value
        'h = h.Insert(InStr(1, h, "Issue", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "AH").Value = h

        'h = xlsWS.Cells(2, "AI").Value
        'h = h.Insert(InStr(1, h, "Issue", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "AI").Value = h

        'h = xlsWS.Cells(2, "AK").Value
        'h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "AK").Value = h

        'h = xlsWS.Cells(2, "AR").Value
        'h = h.Insert(InStr(1, h, "Internal", CompareMethod.Text) + 8, Chr(10))
        'xlsWS.Cells(2, "AR").Value = h

        'h = xlsWS.Cells(2, "AM").Value
        'h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "AM").Value = h

        'h = xlsWS.Cells(2, "AN").Value
        'h = h.Insert(InStr(1, h, "Profit", CompareMethod.Text) + 6, Chr(10))
        'xlsWS.Cells(2, "AN").Value = h

        'h = xlsWS.Cells(2, "AP").Value
        'h = h.Insert(InStr(1, h, "Insurance", CompareMethod.Text) + 9, Chr(10))
        'xlsWS.Cells(2, "AP").Value = h

        'h = xlsWS.Cells(2, "AT").Value
        'h = h.Insert(InStr(1, h, "Claim", CompareMethod.Text) + 5, Chr(10))
        'xlsWS.Cells(2, "AT").Value = h

        xlsWS.Range(xlsWS.Cells(3, 11), xlsWS.Cells(k, 11)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 13), xlsWS.Cells(k, 13)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 14), xlsWS.Cells(k, 14)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 16), xlsWS.Cells(k, 16)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 18), xlsWS.Cells(k, 18)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 20), xlsWS.Cells(k, 20)).HorizontalAlignment = Excel.Constants.xlRight
        xlsWS.Range(xlsWS.Cells(3, 22), xlsWS.Cells(k, 22)).HorizontalAlignment = Excel.Constants.xlRight
        'xlsWS.Range(xlsWS.Cells(3, 37), xlsWS.Cells(k, 37)).HorizontalAlignment = Excel.Constants.xlRight
        'xlsWS.Range(xlsWS.Cells(3, 39), xlsWS.Cells(k, 39)).HorizontalAlignment = Excel.Constants.xlRight
        'xlsWS.Range(xlsWS.Cells(3, 40), xlsWS.Cells(k, 40)).HorizontalAlignment = Excel.Constants.xlRight
        'xlsWS.Range(xlsWS.Cells(3, 42), xlsWS.Cells(k, 42)).HorizontalAlignment = Excel.Constants.xlRight
        'xlsWS.Range(xlsWS.Cells(3, 44), xlsWS.Cells(k, 44)).HorizontalAlignment = Excel.Constants.xlRight
        'xlsWS.Range(xlsWS.Cells(3, 46), xlsWS.Cells(k, 46)).HorizontalAlignment = Excel.Constants.xlRight


        xlsWS.Range(xlsWS.Cells(3, 11), xlsWS.Cells(k, 11)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 13), xlsWS.Cells(k, 13)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 16), xlsWS.Cells(k, 16)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 18), xlsWS.Cells(k, 18)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 20), xlsWS.Cells(k, 20)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(3, 22), xlsWS.Cells(k, 22)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(3, 37), xlsWS.Cells(k, 37)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(3, 39), xlsWS.Cells(k, 39)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(3, 42), xlsWS.Cells(k, 42)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(3, 44), xlsWS.Cells(k, 44)).NumberFormat = "#,##0.00"
        'xlsWS.Range(xlsWS.Cells(3, 46), xlsWS.Cells(k, 46)).NumberFormat = "#,##0.00"
        '*********************************************************************'
        'location = "M" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "P" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "R" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "T" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        'location = "" + i.ToString
        'xlsWS.Range(location).HorizontalAlignment = 4
        '    Next
        'Next

        'Dim j As Integer
        'For i = 2 To xlsWS.Cells(1, "A").End(Excel.XlDirection.xlDown).Row
        '    For j = 1 To 44
        '        xlsWS.Cells(i, j).BorderAround(Excel.XlLineStyle.xlContinuous)
        '    Next
        'Next
        'For i = 0 To rs_EXCEL.Fields.Count - 1
        '    If xlsApp.Columns(i + 1).Width > 100 Then
        '        'xlsWS.Columns(i + 1).Width = 100.0
        '    End If
        'Next
    End Sub

    Private Function removeduplicateItem(ByVal s As String) As String
        Return s
    End Function




    Private Sub cmdShow_Click1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Me.Cursor = Cursors.WaitCursor

        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim VendorLIST As String
        Dim By_Claim_Period
        Dim By_Claim_Case
        Dim By_CANCELLED_CASE
        Dim By_Approval_level_cs
        Dim By_Approval_level_cts
        Dim By_FA_case_complete_status
        Dim By_FA_Paid_status
        Dim By_FA_Received_status
        Dim By_Claim_category
        Dim By_Claim_amount_proposed_fr
        Dim By_Claim_amount_finalised_fr
        Dim By_Claim_To_Customer_amount_proposed_fr
        Dim By_Claim_To_Customer_amount_finalised_fr
        Dim By_Claim_To_Vendor_amount_proposed_fr
        Dim By_Claim_To_vendor__amount_finalised_fr
        Dim By_Claim_amount_proposed_to
        Dim By_Claim_amount_finalised_to
        Dim By_Claim_To_Customer_amount_proposed_to
        Dim By_Claim_To_Customer_amount_finalised_to
        Dim By_Claim_To_Vendor_amount_proposed_to
        Dim By_Claim_To_vendor__amount_finalised_to
        Dim By_Sales_team
        Dim By_Sales_div

        Dim flagcheck As Integer
        flagcheck = 0

        If Trim(Me.txt_S_CoCde.Text) = "" Then
            'MsgBox("The Company Code List is empty!")
            'flagcheck = 1
            ''Exit Sub
            '
        Else
            If Len(Me.txt_S_CoCde.Text) > 1000 Then
                MsgBox("The Company Code List is too long (1000 char)")
            End If
            COCDELIST = removeduplicateItem(Trim(Me.txt_S_CoCde.Text))
            COCDELIST = COCDELIST.Replace("'", "''")
        End If

        If Trim(Me.txt_S_PriCust.Text) = "" Then
            CUS1NOLIST = ""
        Else
            If Len(Me.txt_S_PriCust.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            CUS1NOLIST = removeduplicateItem(Trim(Me.txt_S_PriCust.Text))
            CUS1NOLIST = CUS1NOLIST.Replace("'", "''")
        End If


        If Trim(Me.txt_S_PV.Text) = "" Then
            VendorLIST = ""
        Else
            If Len(Me.txt_S_PV.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            VendorLIST = removeduplicateItem(Trim(Me.txt_S_PV.Text))
            VendorLIST = VendorLIST.Replace("'", "''")
        End If





        If check_valid() = False Then
            Exit Sub
        End If



        By_Claim_Period = cboClaimPeriod.Text.Trim

        If chkconfirmclm.Checked = True And chkvalidclm.Checked = False Then
            By_Claim_Case = "P"
        ElseIf chkconfirmclm.Checked = False And chkvalidclm.Checked = True Then
            By_Claim_Case = "V"
        Else
            By_Claim_Case = ""
        End If

        If chk_cancel_Y.Checked = True And chk_cancel_N.Checked = False Then
            By_CANCELLED_CASE = "Y"
        ElseIf chk_cancel_Y.Checked = False And chk_cancel_N.Checked = True Then
            By_CANCELLED_CASE = "N"
        Else
            By_CANCELLED_CASE = ""
        End If


        By_Approval_level_cs = cboAppLevel_cs.Text.Trim
        By_Approval_level_cts = cboAppLevel_cts.Text.Trim

        If chk_comp_Y.Checked = True And chk_comp_N.Checked = False Then
            By_FA_case_complete_status = "Y"
        ElseIf chk_comp_N.Checked = True And chk_comp_Y.Checked = False Then
            By_FA_case_complete_status = "N"
        Else
            By_FA_case_complete_status = ""
        End If


        By_FA_Paid_status = Trim(Split(cboClaimPaySTS.Text.Trim, "-")(0))
        By_FA_Received_status = Trim(Split(cboClaimIncomeSTS.Text.Trim, "-")(0))

        By_Claim_category = Trim(Split(cboClaimType.Text.Trim, "-")(0))


        By_Claim_amount_proposed_fr = Val(txt_Hdr_OrgClaimAmt_fr.Text.Trim)
        By_Claim_amount_finalised_fr = Val(txt_Hdr_ClaimAmt_fr.Text.Trim)
        By_Claim_To_Customer_amount_proposed_fr = Val(txt_cp_fr.Text.Trim)
        By_Claim_To_Customer_amount_finalised_fr = Val(txt_cf_fr.Text.Trim)
        By_Claim_To_Vendor_amount_proposed_fr = Val(txt_vp_fr.Text.Trim)
        By_Claim_To_vendor__amount_finalised_fr = Val(txt_vf_fr.Text.Trim)

        By_Claim_amount_proposed_to = Val(txt_Hdr_OrgClaimAmt_to.Text.Trim)
        By_Claim_amount_finalised_to = Val(txt_Hdr_ClaimAmt_to.Text.Trim)
        By_Claim_To_Customer_amount_proposed_to = Val(txt_cp_to.Text.Trim)
        By_Claim_To_Customer_amount_finalised_to = Val(txt_cf_to.Text.Trim)
        By_Claim_To_Vendor_amount_proposed_to = Val(txt_vp_to.Text.Trim)
        By_Claim_To_vendor__amount_finalised_to = Val(txt_vf_to.Text.Trim)

        By_Sales_team = txt_S_SalTem.Text.Trim
        By_Sales_div = txt_S_SalDiv.Text.Trim


        gspStr = "sp_list_CLR00006_dt  '" & _
                    COCDELIST & "','" & _
                    CUS1NOLIST & "','" & _
                    VendorLIST & "','" & _
By_Claim_Period & "','" & _
By_Claim_Case & "','" & _
By_CANCELLED_CASE & "','" & _
By_Approval_level_cs & "','" & _
By_Approval_level_cts & "','" & _
By_FA_case_complete_status & "','" & _
By_FA_Paid_status & "','" & _
By_FA_Received_status & "','" & _
By_Claim_category & "','" & _
By_Claim_amount_proposed_fr & "','" & _
By_Claim_amount_finalised_fr & "','" & _
By_Claim_To_Customer_amount_proposed_fr & "','" & _
By_Claim_To_Customer_amount_finalised_fr & "','" & _
By_Claim_To_Vendor_amount_proposed_fr & "','" & _
By_Claim_To_vendor__amount_finalised_fr & "','" & _
By_Claim_amount_proposed_to & "','" & _
By_Claim_amount_finalised_to & "','" & _
By_Claim_To_Customer_amount_proposed_to & "','" & _
By_Claim_To_Customer_amount_finalised_to & "','" & _
By_Claim_To_Vendor_amount_proposed_to & "','" & _
By_Claim_To_vendor__amount_finalised_to & "','" & _
By_Sales_team & "','" & _
By_Sales_div & "','" & _
                    gsUsrID & "'"

        'Dim rs As New ADODB.Recordset
        '   rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        If rb_DS_Rpt.Checked = True Then
            rtnLong = execute_SQLStatementRPT(gspStr, rs_excel, rtnStr)
        Else
            rtnLong = execute_SQLStatement(gspStr, rs_excel, rtnStr)
        End If

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLR00004 #002 sp_list_CLR00006_dt : " & rtnStr)
        Else
            If rs_excel.Tables("result").Rows.Count = 0 Then
                MsgBox("No record found!")
            Else
                Call exportExcel_ExportToExcel(rs_excel.Tables("result").Rows.Count)

            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_S_SARvsdatTo_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_S_SARvsdatFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub format_cboClaimPeriod()
        'This function is only for creating new Claim
        Dim strList As String
        Dim sFirstYear As String
        Dim sSecondYear As String

        cboClaimPeriod.Items.Clear()
        cboClaimPeriod.Items.Add("")


        If Today.Month > 3 Then
            sFirstYear = (Today.Year() - 2).ToString
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            cboClaimPeriod.Text = strList
        Else
            sFirstYear = (Today.Year() - 3).ToString
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If
            cboClaimPeriod.Text = strList

        End If



    End Sub

    Private Sub format_cboClaimPaySTS()
        Dim i As Integer
        Dim strList As String


        If rs_SYCLMPST.Tables.Count = 0 Then
            Exit Sub
        End If

        cboClaimPaySTS.Items.Clear()
        cboClaimPaySTS.Items.Add("")

        If rs_SYCLMPST.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMPST.Tables("RESULT").Rows.Count - 1

                strList = Trim(rs_SYCLMPST.Tables("RESULT").Rows(i).Item("ycp_cde")) & " - " & Trim(rs_SYCLMPST.Tables("RESULT").Rows(i).Item("ycp_dsc"))

                If strList <> "" Then
                    cboClaimPaySTS.Items.Add(strList)

                End If
            Next i
        End If
    End Sub

    Private Sub format_cboClaimIncomeSTS()
        Dim i As Integer
        Dim strList As String


        If rs_SYCLMIST.Tables.Count = 0 Then
            Exit Sub
        End If

        cboClaimIncomeSTS.Items.Clear()
        cboClaimIncomeSTS.Items.Add("")

        If rs_SYCLMIST.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMIST.Tables("RESULT").Rows.Count - 1

                strList = Trim(rs_SYCLMIST.Tables("RESULT").Rows(i).Item("yci_cde")) & " - " & Trim(rs_SYCLMIST.Tables("RESULT").Rows(i).Item("yci_dsc"))

                If strList <> "" Then
                    cboClaimIncomeSTS.Items.Add(strList)

                End If
            Next i
        End If
    End Sub

    Private Sub format_cboClaimType(ByVal claimtby As String)
        Dim i As Integer
        Dim strList As String

        Dim claimtby_check As String
        claimtby_check = ""

        If rs_SYCLMTYP.Tables.Count = 0 Then
            Exit Sub
        End If

        cboClaimType.Text = ""
        cboClaimType.Items.Clear()
        cboClaimType.Items.Add("")

        If rs_SYCLMTYP.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMTYP.Tables("RESULT").Rows.Count - 1
                strList = Trim(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde") & " - " & rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_dsc"))
                If strList <> "" Then
                    cboClaimType.Items.Add(strList)
                End If
            Next i

        End If
        '''20131205
        ''' 
    End Sub

    Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PV.Name
        frmComSearch.callFmString = txt_S_PV.Text

        frmComSearch.show_frmS(Me.cmd_S_PV)
    End Sub

    Private Function check_valid() As Boolean
        check_valid = True



        'check_valid = False

    End Function


    Private Sub txt_Hdr_OrgClaimAmt_fr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_OrgClaimAmt_fr.TextChanged

    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_fr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_OrgClaimAmt_fr.Validating
        If txt_Hdr_OrgClaimAmt_fr.Text.Trim = "" Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_OrgClaimAmt_fr.Text) Then
            MsgBox("Please input numeric data.")
            txt_Hdr_OrgClaimAmt_fr.Focus()
        End If

    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_OrgClaimAmt_to.TextChanged

    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_to_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_OrgClaimAmt_to.Validating
        If txt_Hdr_OrgClaimAmt_to.Text.Trim = "" Then
            Exit Sub
        End If
        If Not IsNumeric(txt_Hdr_OrgClaimAmt_to.Text) Then
            MsgBox("Please input numeric data.")
            txt_Hdr_OrgClaimAmt_to.Focus()
        End If

    End Sub

    Private Sub txt_Hdr_ClaimAmt_fr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimAmt_fr.TextChanged

    End Sub

    Private Sub txt_Hdr_ClaimAmt_fr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimAmt_fr.Validating
        If txt_Hdr_ClaimAmt_fr.Text.Trim = "" Then
            Exit Sub
        End If
        If Not IsNumeric(txt_Hdr_ClaimAmt_fr.Text) Then
            MsgBox("Please input numeric data.")
            txt_Hdr_ClaimAmt_fr.Focus()
        End If

    End Sub

    Private Sub txt_Hdr_ClaimAmt_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimAmt_to.TextChanged

    End Sub

    Private Sub txt_Hdr_ClaimAmt_to_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimAmt_to.Validating
        If txt_Hdr_ClaimAmt_to.Text.Trim = "" Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_ClaimAmt_to.Text) Then
            MsgBox("Please input numeric data.")
            txt_Hdr_ClaimAmt_to.Focus()
        End If

    End Sub

    Private Sub txt_cp_fr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cp_fr.TextChanged
        If txt_cp_fr.Text.Trim = "" Then
            Exit Sub
        End If

        If Not IsNumeric(txt_cp_fr.Text) Then
            MsgBox("Please input numeric data.")
            txt_cp_fr.Focus()
        End If

    End Sub

    Private Sub txt_cp_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cp_to.TextChanged

    End Sub

    Private Sub txt_cp_to_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_cp_to.Validating
        If txt_cp_to.Text.Trim = "" Then
            Exit Sub
        End If

        If Not IsNumeric(txt_cp_to.Text) Then
            MsgBox("Please input numeric data.")
            txt_cp_to.Focus()
        End If

    End Sub

    Private Sub txt_cf_fr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cf_fr.TextChanged

    End Sub

    Private Sub txt_cf_fr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_cf_fr.Validating
        If txt_cf_fr.Text.Trim = "" Then
            Exit Sub
        End If
        If Not IsNumeric(txt_cf_fr.Text) Then
            MsgBox("Please input numeric data.")
            txt_cf_fr.Focus()
        End If

    End Sub

    Private Sub txt_cf_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cf_to.TextChanged

    End Sub

    Private Sub txt_cf_to_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_cf_to.Validating
        If txt_cf_to.Text.Trim = "" Then
            Exit Sub
        End If
        If Not IsNumeric(txt_cf_to.Text) Then
            MsgBox("Please input numeric data.")
            txt_cf_to.Focus()
        End If

    End Sub

    Private Sub txt_vp_fr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vp_fr.TextChanged

    End Sub

    Private Sub txt_vp_fr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_vp_fr.Validating
        If txt_vp_fr.Text.Trim = "" Then
            Exit Sub
        End If

        If Not IsNumeric(txt_vp_fr.Text) Then
            MsgBox("Please input numeric data.")
            txt_vp_fr.Focus()
        End If

    End Sub

    Private Sub txt_vp_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vp_to.TextChanged

    End Sub

    Private Sub txt_vp_to_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_vp_to.Validating
        If txt_vp_to.Text.Trim = "" Then
            Exit Sub
        End If

        If Not IsNumeric(txt_vp_to.Text) Then
            MsgBox("Please input numeric data.")
            txt_vp_to.Focus()
        End If

    End Sub

    Private Sub txt_vf_fr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vf_fr.TextChanged

    End Sub

    Private Sub txt_vf_fr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_vf_fr.Validating
        If txt_vf_fr.Text.Trim = "" Then
            Exit Sub
        End If

        If Not IsNumeric(txt_vf_fr.Text) Then
            MsgBox("Please input numeric data.")
            txt_vf_fr.Focus()
        End If

    End Sub

    Private Sub txt_vf_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vf_to.TextChanged

    End Sub

    Private Sub txt_vf_to_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_vf_to.Validating
        If txt_vf_to.Text.Trim = "" Then
            Exit Sub
        End If
        If Not IsNumeric(txt_vf_to.Text) Then
            MsgBox("Please input numeric data.")
            txt_vf_to.Focus()
        End If

    End Sub


    Private Sub exportExcel_ExportToExcel(ByVal rowcount As Integer)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_excel.Tables("RESULT").Rows.Count >= 30000 Then
            MsgBox("There are more than 30000 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Dim al As New ArrayList





        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application



        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        ' xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

        ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\CLtemplate\CL__6.xlsx")


        xlsWS = xlsWB.ActiveSheet


        Dim entry(60) As Object

        Try

            '            With xlsApp
            '    entry(0) = ""
            '    entry(1) = ""
            '    entry(2) = ""
            '    entry(3) = ""
            '    entry(4) = ""
            '    entry(5) = ""
            '    entry(6) = ""
            '    entry(7) = ""
            '    entry(8) = ""
            '    entry(9) = ""
            '    entry(10) = ""
            '    entry(11) = ""
            '    entry(12) = ""
            '    entry(13) = "A"
            '    entry(14) = ""
            '    entry(15) = "B"
            '    entry(16) = ""
            '    entry(17) = ""
            '    entry(18) = "C"
            '    entry(19) = "D"
            '    entry(20) = "F"
            '    entry(21) = "G"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "I"
            '    entry(24) = "K"
            '    entry(25) = "K = H+J"
            '    entry(26) = "M"
            '    entry(27) = " M=(B/(1-L)+D)/(1-E)+ F "

            '    .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
            'End With


            ''Initializing Header Row'
            'With xlsApp
            '    entry(0) = "Pri Cust"
            '    entry(1) = "Org. UM"
            '    entry(2) = "Period (YYYY-MM)"
            '    entry(3) = "Item No."
            '    entry(4) = "Description"
            '    entry(5) = "UM"
            '    entry(6) = "Inner"
            '    entry(7) = "Master"
            '    entry(8) = "CFT"
            '    entry(9) = "Conversion Factor To PCs"
            '    entry(10) = "CCY"
            '    entry(11) = "FTY Cost (Total)"
            '    entry(12) = "FTY MU"
            '    entry(13) = "FTY Price"
            '    entry(14) = "HK MU"
            '    entry(15) = "Basic Price (USD)"
            '    entry(16) = "Price Term"
            '    entry(17) = "Vendor covers all transportation cost (Y/N)"
            '    entry(18) = "Markup %"
            '    entry(19) = "Packaging Cost"
            '    entry(20) = "Commission"
            '    entry(21) = "Item Comm Amt"
            '    entry(22) = "Standard Price (USD)"
            '    entry(23) = "Cushion & Costing Buffer"
            '    entry(24) = "Other Discount Limit"
            '    entry(25) = "Max. Discount Limit"
            '    entry(26) = "Adjusted Markup"
            '    entry(27) = " Adjusted Price (USD) "


            '    .Range(.Cells(hdrRow + 1, 1), .Cells(hdrRow + 1, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
            'End With

            'Dim dr_CLExcel() As DataRow
            'dr_CLExcel = rs_excel.Tables("RESULT").Select("cah_venno <> '$^&$%'")



            'With xlsApp
            '    For i As Integer = 0 To rs_excel.Tables("RESULT").Rows.Count - 2

            '        .Range("A5:AU5").Copy()

            '        .Range("A" + (i + 6).ToString).Select()
            '        xlsWS.Paste()


            '    Next

            '    .Range("A88:A88").Copy()

            'End With





            Dim seq As Integer = -1


            With xlsApp


                For i As Integer = 0 To rs_excel.Tables("RESULT").Rows.Count - 1

                    If rb_Rpt_Int.Checked = True And (rs_excel.Tables("RESULT").Rows(i)("cah_venno") = "L" Or (rs_excel.Tables("RESULT").Rows(i)("cah_venno") >= "1000" And rs_excel.Tables("RESULT").Rows(i)("cah_venno") < "9999") Or rs_excel.Tables("RESULT").Rows(i)("cah_caordsts") = "CANL") Then

                        .Range("D" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caordno")

                        .Range("F" + (i + 5).ToString).NumberFormat = "@"
                        If rs_excel.Tables("RESULT").Rows(i)("cah_caordsts") = "CANL" Then
                            .Range("F" + (i + 5).ToString).Value = "CANCELLED"
                        ElseIf rs_excel.Tables("RESULT").Rows(i)("cah_venno") = "L" Or rs_excel.Tables("RESULT").Rows(i)("cah_venno") = "1756" Then
                            .Range("F" + (i + 5).ToString).Value = "MAGICSILK FACTORY"
                        Else
                            .Range("F" + (i + 5).ToString).Value = "EXTERNAL FACTORY"
                        End If
                    Else

                        .Range("A" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_claPeriod")
                        .Range("B" + (i + 5).ToString).Value = Format(rs_excel.Tables("RESULT").Rows(i)("cah_upddat"), "MM/dd/yyyy")

                        If rs_excel.Tables("RESULT").Rows(i)("cah_claby") = "C" Then
                            .Range("C" + (i + 5).ToString).Value = "Customer"
                        ElseIf rs_excel.Tables("RESULT").Rows(i)("cah_claby") = "V" Then
                            .Range("C" + (i + 5).ToString).Value = "Vendor"
                        ElseIf rs_excel.Tables("RESULT").Rows(i)("cah_claby") = "U" Then
                            .Range("C" + (i + 5).ToString).Value = "H.K. Office"
                        End If
                        .Range("D" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caordno")
                        .Range("E" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_rplno")
                        '
                        .Range("F" + (i + 5).ToString).Value = Format(rs_excel.Tables("RESULT").Rows(i)("cah_credat"), "MM/dd/yyyy")

                        If InStr(.Range("F" + (i + 5).ToString).Value, "1900") > 0 Then
                            .Range("F" + (i + 5).ToString).Value = ""
                        End If

                        .Range("G" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cbi_saltem")
                        .Range("H" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cbi_saldiv")

                        .Range("I" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_cus1no")

                        .Range("J" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cbi_cussna")
                        '
                        If rs_excel.Tables("RESULT").Rows(i)("cah_venno") <> "" Then
                            .Range("K" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_venno") & " - " & rs_excel.Tables("RESULT").Rows(i)("vbi_vensna")
                        End If
                        '                    temp()

                        .Range("L" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_season")

                        .Range("M" + (i + 5).ToString).NumberFormat = "@"
                        .Range("M" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cuspolist")
                        .Range("N" + (i + 5).ToString).NumberFormat = "@"
                        .Range("N" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("itmnolist")



                        .Range("O" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_ref_no")

                        .Range("P" + (i + 5).ToString).Value = Format(rs_excel.Tables("RESULT").Rows(i)("cah_credat"), "MM/dd/yyyy")
                        If InStr(.Range("P" + (i + 5).ToString).Value, "1900") > 0 Then
                            .Range("P" + (i + 5).ToString).Value = ""
                        End If


                        .Range("Q" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_pot_val")


                        '''MMMMCCC

                        .Range("R" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_cacur")
                        .Range("S" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caamt_org")
                        .Range("T" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caamt_final")

                        '''get currency rate
                        ''if fin then fin, else pro; or .

                        'If Trim(rs_excel.Tables("RESULT").Rows(i)("cah_cacur")) = "USD" Then
                        '    If Val(rs_excel.Tables("RESULT").Rows(i)("cah_caamt_final")) <> 0 Then
                        '        .Range("u" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caamt_final")
                        '    ElseIf Val(rs_excel.Tables("RESULT").Rows(i)("cah_caamt_org")) <> 0 Then
                        '        .Range("u" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caamt_org")
                        '    End If

                        'ElseIf Trim(rs_excel.Tables("RESULT").Rows(i)("cah_cacur")) = "HKD" Then
                        '    If Val(rs_excel.Tables("RESULT").Rows(i)("cah_caamt_final")) <> 0 Then
                        '        .Range("u" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caamt_final") / gl_rate
                        '    ElseIf Val(rs_excel.Tables("RESULT").Rows(i)("cah_caamt_org")) <> 0 Then
                        '        .Range("u" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caamt_org") / gl_rate
                        '    End If
                        'End If




                        .Range("V" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOINSCUR")

                        .Range("W" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_ClaimToInsAmt_ori")

                        .Range("X" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOINSAMT")

                        .Range("Y" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNCUR")

                        .Range("Z" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_ClaimToVNAmt_ori")

                        .Range("AA" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNAMT")

                        '''
                        'If Trim(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNCUR")) = "USD" Then
                        '    If Val(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNAMT")) <> 0 Then
                        '        .Range("AB" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNAMT")
                        '    ElseIf Val(rs_excel.Tables("RESULT").Rows(i)("cah_ClaimToVNAmt_ori")) <> 0 Then
                        '        .Range("AB" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_ClaimToVNAmt_ori")
                        '    End If

                        'ElseIf Trim(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNCUR")) = "HKD" Then
                        '    If Val(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNAMT")) <> 0 Then
                        '        .Range("AB" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOVNAMT") / gl_rate
                        '    ElseIf Val(rs_excel.Tables("RESULT").Rows(i)("cah_ClaimToVNAmt_ori")) <> 0 Then
                        '        .Range("AB" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_ClaimToVNAmt_ori") / gl_rate
                        '    End If
                        'End If





                        .Range("AC" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOCUR")


                        .Range("AD" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_ClaimToHKOAmt_ori")
                        .Range("AE" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOAMT")


                        '''   
                        'If Trim(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOCUR")) = "USD" Then
                        '    If Val(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOAMT")) <> 0 Then
                        '        .Range("AF" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOAMT")
                        '    ElseIf Val(rs_excel.Tables("RESULT").Rows(i)("CAH_ClaimToHKOAmt_ori")) <> 0 Then
                        '        .Range("AF" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_ClaimToHKOAmt_ori")
                        '    End If

                        'ElseIf Trim(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOCUR")) = "HKD" Then
                        '    If Val(rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOAMT")) <> 0 Then
                        '        .Range("AF" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_CATOHKOAMT") / gl_rate
                        '    ElseIf Val(rs_excel.Tables("RESULT").Rows(i)("CAH_ClaimToHKOAmt_ori")) <> 0 Then
                        '        .Range("AF" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_ClaimToHKOAmt_ori") / gl_rate
                        '    End If
                        'End If

                        .Range("AG" + (i + 5).ToString).NumberFormat = "@"
                        .Range("AG" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_clatyp")

                        'If Len(Trim(.Range("AG" + (i + 5).ToString).Value)) = 1 Then

                        'End If

                        .Range("AH" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("yct_dsc")

                        .Range("AI" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_custcomment")

                        .Range("AJ" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_finding")

                        .Range("AK" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_rmk")

                        .Range("AL" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caordsts_a")

                        .Range("AM" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_cmt_a")

                        .Range("AN" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_caordsts_b")

                        .Range("AO" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_cmt_b")

                        .Range("AP" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_PAYSTS")

                        .Range("AQ" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_pay_rmk")

                        .Range("AR" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_pay_cur")

                        .Range("AS" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_pay_actamt")

                        .Range("AT" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_pay_potamt")

                        .Range("AU" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_PAIDDAT")
                        If InStr(.Range("AU" + (i + 5).ToString).Value, "1900") > 0 Then
                            .Range("AU" + (i + 5).ToString).Value = ""
                        End If

                        .Range("AV" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_SETTLE_CUS")

                        .Range("AW" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_pay_upddat")

                        If InStr(.Range("AW" + (i + 5).ToString).Value, "1900") > 0 Then
                            .Range("AW" + (i + 5).ToString).Value = ""
                        End If



                        .Range("AX" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_INCOMESTS")
                        .Range("AY" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_income_rmk")

                        .Range("AZ" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_income_cur")

                        .Range("BA" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_income_actamt")
                        .Range("BB" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_income_potamt")
                        .Range("BC" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_RCVDAT")
                        If InStr(.Range("BC" + (i + 5).ToString).Value, "1900") > 0 Then
                            .Range("BC" + (i + 5).ToString).Value = ""
                        End If

                        .Range("BD" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("CAH_SETTLE_FTY")
                        .Range("BE" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_income_upddat")
                        If InStr(.Range("BE" + (i + 5).ToString).Value, "1900") > 0 Then
                            .Range("BE" + (i + 5).ToString).Value = ""
                        End If

                        .Range("BF" + (i + 5).ToString).Value = ""
                        '
                    End If
                Next


            End With

             With xlsApp
                .Range(.Cells(5, 1), _
                    .Cells(rowcount + 4, 58)).Borders.LineStyle = 1
            End With

            With xlsApp
                .Range(.Cells(5, 21), _
                    .Cells(rowcount + 4, 21)).Interior.ColorIndex = 15
            End With

            With xlsApp
                .Range(.Cells(5, 28), _
                    .Cells(rowcount + 4, 28)).Interior.ColorIndex = 15
            End With

            With xlsApp
                .Range(.Cells(5, 32), _
                    .Cells(rowcount + 4, 32)).Interior.ColorIndex = 15
            End With

            With xlsApp
                .Range(.Cells(5, 42), _
                    .Cells(rowcount + 4, 58)).Interior.ColorIndex = 15
            End With

        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    'exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Dim file_name As String


            file_name = Now.ToString
            file_name = file_name.Replace(" ", "_")
            file_name = file_name.Replace("#", "")
            file_name = file_name.Replace(":", "_")
            file_name = file_name.Replace("/", "_")


            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                '    xlsWB.SaveAs(Filename:="C:\" + "" + "_fty", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + "" + file_name, FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_fty", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + file_name, FileFormat:=52)
            End If




            '''                xlsWB.SaveAs(Filename:="C:\" + "" + "_fty", FileFormat:=52)

        Catch ex As Exception
            'MsgBox("File " + "" + "" + "_fty" + ".xls already exist. Please delete it before export a new one.")
        End Try

        ' xlsWB.SaveAs(Filename:="C:\" + "", ReadOnlyRecommended:=False)

        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        'al.Add(xlsApp)

        ' Release reference
        'rs_Excel = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing


        ' Cursor = Cursors.Default

        'For i As Integer = 0 To al.Count - 1
        '    Dim xlx As New Excel.ApplicationClass
        '    xlx = al(i)
        '    xlx.Visible = True
        'Next
        ''rs_Excel = Nothing
        Cursor = Cursors.Default
    End Sub


    Private Sub cmd_S_ST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SalTem.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SalTem.Name
        frmComSearch.callFmString = txt_S_SalTem.Text

        frmComSearch.show_frmS(Me.cmd_S_SalTem)

    End Sub

    Private Sub cmd_S_SD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SD.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SalDiv.Name
        frmComSearch.callFmString = txt_S_SalDiv.Text

        frmComSearch.show_frmS(Me.cmd_S_SD)

    End Sub
End Class
