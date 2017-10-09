Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Data.OleDbsam
'Imports ADODB

Public Class CLR00003
    Inherits System.Windows.Forms.Form

    Public rs_SYMUSRCO As New DataSet
    Public rs_CLR00003 As New DataSet

    Dim rowCnt As Integer
    Dim dsNewRow As DataRow
    Dim mode As String
    Dim xlsApp As New Excel.ApplicationClass
    Dim xlsWB As Excel.Workbook = Nothing
    Dim xlsWS As Excel.Worksheet = Nothing


    Private Sub CLR00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLR00003 #001 sp_select_SYMUSRCO : " & rtnStr)
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

        Me.txt_S_SAIssdatTo.Text = "  /  /"
        Me.txt_S_SAIssdatFm.Text = "  /  /"

        cmd_S_CoCde.Enabled = True
        cmd_S_ItmNo.Enabled = True
        cmd_S_PriCust.Enabled = True
        cmd_S_SecCust.Enabled = True
        cmd_S_PV.Enabled = True
        cmd_S_SCNo.Enabled = True
        cmd_S_PONo.Enabled = True
        cmd_S_CaSts.Enabled = True

        txt_S_ItmNo.Enabled = True
        txt_S_PV.Enabled = True
        txt_S_PriCust.Enabled = True
        txt_S_SecCust.Enabled = True
        txt_S_SCNo.Enabled = True
        txt_S_PONo.Enabled = True
        txt_S_CaSts.Enabled = True

        Call format_cboClaimPeriod()

        Call Formstartup(Me.Name)
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
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCust)
    End Sub

    Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PV.Name
        frmComSearch.callFmString = txt_S_PV.Text

        frmComSearch.show_frmS(Me.cmd_S_PV)
    End Sub

    Private Sub cmd_S_Clmno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_Clmno.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CaOrdNo.Name
        frmComSearch.callFmString = txt_S_CaOrdNo.Text

        frmComSearch.show_frmS(Me.cmd_S_Clmno)
    End Sub

    Private Sub ExportToExcel(ByVal sheet_ord As Integer, ByVal rs_EXCEL As ADODB.Recordset)
        Dim strCocde As String = String.Empty
        Dim titletest As String
        Dim i As Integer


        If rs_EXCEL.RecordCount >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        If sheet_ord = 1 Then
            titletest = "Customer Claim Exception Reports (Claim total amount > USD5000)."
            ''titletest = "12345"
            xlsWB.Sheets(1).Activate()
            xlsWB.Sheets(1).name = ">5000"
        ElseIf sheet_ord = 2 Then
            titletest = "Customer Claim Exception Reports (Claim total amount>20% of this shipment amount)."
            xlsWB.Sheets(2).Activate()
            xlsWB.Sheets(2).name = ">20% shipment amount"
        Else
            titletest = "Customer Claim Exception Reports (Claim total amount>1% of shipped shipment this financial year less already claimed)."
            xlsWB.Sheets(3).Activate()
            xlsWB.Sheets(3).name = ">1% financial year amount"
        End If


        xlsWS = xlsWB.ActiveSheet

        For i = 0 To rs_EXCEL.Fields.Count - 1
            xlsApp.Cells(2, i + 1) = rs_EXCEL.Fields(i).Name
        Next

        xlsWS.Rows(2).Font.Bold = True

        xlsWS.Cells(1, 1) = titletest
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
            .Columns("AC").ColumnWidth = 7
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
            .Columns("R").ColumnWidth = 0
            .Columns("S").ColumnWidth = 0
            .Columns("T").ColumnWidth = 0
            .Columns("U").ColumnWidth = 6
            .Columns("AA").ColumnWidth = 14
            .Columns("AC").ColumnWidth = 13
            .Columns("AD").ColumnWidth = 6
            .Columns("AE").ColumnWidth = 10
            .Columns("AF").ColumnWidth = 6
            .Columns("AG").ColumnWidth = 10
            .Columns("AH").ColumnWidth = 6

            .Columns("AJ").ColumnWidth = 6
            .Columns("AL").ColumnWidth = 6
            '.Columns("AO").ColumnWidth = 4
            '.Columns("AQ").ColumnWidth = 4
            '.Columns("AS").ColumnWidth = 4
            .Columns("AN").ColumnWidth = 14.88
            .Columns("AO").ColumnWidth = 14.88

            .Columns("AP").ColumnWidth = 14.88

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
        xlsWS.Range(xlsWS.Cells(3, 47), xlsWS.Cells(k, 47)).NumberFormat = "#,##0.00"
        xlsWS.Range(xlsWS.Cells(3, 48), xlsWS.Cells(k, 48)).NumberFormat = "#,##0.00"
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

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        frmComSearch.show_frmS(Me.cmd_S_SCNo)
    End Sub

    Private Sub cmd_S_PONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PONo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PONo.Name
        frmComSearch.callFmString = txt_S_PONo.Text

        frmComSearch.show_frmS(Me.cmd_S_PONo)
    End Sub

    Private Sub cmd_S_CaSts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CaSts.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CaSts.Name
        frmComSearch.callFmString = txt_S_CaSts.Text

        frmComSearch.show_frmS(Me.cmd_S_CaSts)
    End Sub

    Private Sub cmdShow_Click1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Me.Cursor = Cursors.WaitCursor

        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        Dim ITMNOLIST As String
        Dim PVLIST As String
        Dim SAISSDATFM As String
        Dim SAISSDATTO As String
        Dim SARVSDATFM As String
        Dim SARVSDATTO As String
        Dim CLMNO As String
        Dim SCNO As String
        Dim PONO As String
        Dim CLMSTS As String
        Dim flagcheck As Integer
        flagcheck = 0

        If Trim(Me.txt_S_CoCde.Text) = "" Then
            MsgBox("The Company Code List is empty!")
            flagcheck = 1
            'Exit Sub
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

        If Trim(Me.txt_S_SecCust.Text) = "" Then
            CUS2NOLIST = ""
        Else
            If Len(Me.txt_S_SecCust.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Secondary Customer List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            CUS2NOLIST = removeduplicateItem(Trim(Me.txt_S_SecCust.Text))
            CUS2NOLIST = CUS2NOLIST.Replace("'", "''")
        End If
        'CUS2NOLIST = ""

        If Trim(Me.txt_S_ItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(Me.txt_S_ItmNo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Item No List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            ITMNOLIST = removeduplicateItem(Trim(Me.txt_S_ItmNo.Text))
            ITMNOLIST = ITMNOLIST.Replace("'", "''")
        End If

        If Trim(Me.txt_S_PV.Text) = "" Then
            PVLIST = ""
        Else
            If Len(Me.txt_S_PV.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Production Vendor List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            PVLIST = removeduplicateItem(Trim(Me.txt_S_PV.Text))
            PVLIST = PVLIST.Replace("'", "''")
        End If

        If Me.txt_S_SAIssdatFm.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SAIssdatFm.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SAIssdatFm.Focus()
                flagcheck = 1
                Exit Sub
            End If
        End If

        If Me.txt_S_SAIssdatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SAIssdatTo.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SAIssdatTo.Focus()
                flagcheck = 1
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SAIssdatFm.Text, 7) > Mid(Me.txt_S_SAIssdatTo.Text, 7) And flagcheck = 0 Then
            MsgBox("Claim by Customer Confirmed Date: End Date < Start Date (YY)")
            Me.txt_S_SAIssdatFm.Focus()
            flagcheck = 1
            Exit Sub
        ElseIf Mid(Me.txt_S_SAIssdatFm.Text, 7) = Mid(Me.txt_S_SAIssdatTo.Text, 7) Then
            If Me.txt_S_SAIssdatFm.Text.Substring(0, 2) > Me.txt_S_SAIssdatTo.Text.Substring(0, 2) And flagcheck = 0 Then
                MsgBox("Claim by Customer Confirmed Date: End Date < Start Date (MM)")
                Me.txt_S_SAIssdatFm.Focus()
                flagcheck = 1
                Exit Sub
            ElseIf Me.txt_S_SAIssdatFm.Text.Substring(0, 2) = Me.txt_S_SAIssdatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SAIssdatFm.Text.Substring(3, 2) > Me.txt_S_SAIssdatTo.Text.Substring(3, 2) And flagcheck = 0 Then
                    MsgBox("Claim by Customer Confirmed Date: End Date < Start Date (DD)")
                    Me.txt_S_SAIssdatFm.Focus()
                    flagcheck = 1
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_SAIssdatFm.Text = "  /  /" Then
            SAISSDATFM = "01/01/1900"
        Else
            SAISSDATFM = Me.txt_S_SAIssdatFm.Text
        End If

        If Me.txt_S_SAIssdatTo.Text = "  /  /" Then
            SAISSDATTO = "01/01/1900"
        Else
            SAISSDATTO = Me.txt_S_SAIssdatTo.Text
        End If

        If Me.txt_S_SARvsdatFm.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SARvsdatFm.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SARvsdatFm.Focus()
                flagcheck = 1
                'Exit Sub
            End If
        End If

        If Me.txt_S_SARvsdatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SARvsdatTo.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SARvsdatTo.Focus()
                flagcheck = 1
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SARvsdatFm.Text, 7) > Mid(Me.txt_S_SARvsdatTo.Text, 7) And flagcheck = 0 Then
            MsgBox("Claim Approval Date: End Date < Start Date (YY)")
            Me.txt_S_SARvsdatFm.Focus()
            flagcheck = 1
            Exit Sub
        ElseIf Mid(Me.txt_S_SARvsdatFm.Text, 7) = Mid(Me.txt_S_SARvsdatTo.Text, 7) Then
            If Me.txt_S_SARvsdatFm.Text.Substring(0, 2) > Me.txt_S_SARvsdatTo.Text.Substring(0, 2) And flagcheck = 0 Then
                MsgBox("Claim Approval Date: End Date < Start Date (MM)")
                Me.txt_S_SARvsdatFm.Focus()
                flagcheck = 1
                Exit Sub
            ElseIf Me.txt_S_SARvsdatFm.Text.Substring(0, 2) = Me.txt_S_SARvsdatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SARvsdatFm.Text.Substring(3, 2) > Me.txt_S_SARvsdatTo.Text.Substring(3, 2) And flagcheck = 0 Then
                    MsgBox("Claim Approval Date: End Date < Start Date (DD)")
                    Me.txt_S_SARvsdatFm.Focus()
                    flagcheck = 1
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_SARvsdatFm.Text = "  /  /" Then
            SARVSDATFM = "01/01/1900"
        Else
            SARVSDATFM = Me.txt_S_SARvsdatFm.Text
        End If

        If Me.txt_S_SARvsdatTo.Text = "  /  /" Then
            SARVSDATTO = "01/01/1900"
        Else
            SARVSDATTO = Me.txt_S_SARvsdatTo.Text
        End If

        If SAISSDATFM = "01/01/1900" And SAISSDATTO = "01/01/1900" And SARVSDATFM = "01/01/1900" And SARVSDATTO = "01/01/1900" And flagcheck = 0 Then '
            MsgBox("Claim by Customer Confirmed Date must have values!")
            Me.txt_S_SAIssdatFm.Focus()
            flagcheck = 1
            Exit Sub
        End If

        If Trim(Me.txt_S_CaOrdNo.Text) = "" Then
            CLMNO = ""
        Else
            If Len(Me.txt_S_CaOrdNo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Claim No is too long (1000 char)")
                flagcheck = 1
                Exit Sub
            End If
            CLMNO = removeduplicateItem(Trim(Me.txt_S_CaOrdNo.Text))
            CLMNO = CLMNO.Replace("'", "''")
        End If

        If Trim(Me.txt_S_SCNo.Text) = "" Then
            SCNO = ""
        Else
            If Len(Me.txt_S_SCNo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The SC No is too long (1000 char)")
                flagcheck = 1
                Exit Sub
            End If
            SCNO = removeduplicateItem(Trim(Me.txt_S_CaOrdNo.Text))
            SCNO = SCNO.Replace("'", "''")
        End If

        If Trim(Me.txt_S_PONo.Text) = "" Then
            PONO = ""
        Else
            If Len(Me.txt_S_PONo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The PO No is too long (1000 char)")
                flagcheck = 1
                Exit Sub
            End If
            PONO = removeduplicateItem(Trim(Me.txt_S_PONo.Text))
            PONO = SCNO.Replace("'", "''")
        End If

        If Trim(Me.txt_S_CaSts.Text) = "" Then
            CLMSTS = ""
        Else
            If Len(Me.txt_S_PONo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The claim state is too long (1000 char)")
                flagcheck = 1
                Exit Sub
            End If
            CLMSTS = removeduplicateItem(Trim(Me.txt_S_CaSts.Text))
            CLMSTS = CLMSTS.Replace("'", "''")
        End If
        'If flagcheck = 0 Then
        'gspStr = "sp_list_CLR00003 '','" & _
        '           COCDELIST & "','" & _
        '          CUS1NOLIST & "','" & _
        '         CUS2NOLIST & "','" & _
        '        ITMNOLIST & "','" & _
        '       DVLIST & "','" & _
        '      PVLIST & "','" & _
        '     SAISSDATFM & "','" & _
        '    SAISSDATTO & "','" & _
        '   SARVSDATFM & "','" & _
        '  SARVSDATTO & "','" & _
        ' gsUsrID & "'"

        ''''''''''set COCDELIST and gsUsrID to default''''''''
        'COCDELIST = ""
        'gsUsrID = ""
        '''''''''''''''''''''''''''''''''''''''''
        'If CheckClmhdr.Checked = True Then
        'gspStr = "sp_list_CLR00003 '','" & _
        '          COCDELIST & "','" & _
        '         CUS1NOLIST & "','" & _
        '        CUS2NOLIST & "','" & _
        '       PVLIST & "','" & _
        '      SAISSDATFM & "','" & _
        '     SAISSDATTO & "','" & _
        '    SARVSDATFM & "','" & _
        '   SARVSDATTO & "','" & _
        '  CLMNO & "','" & _
        ' gsUsrID & "'"

        'gspStr = "sp_list_CLR00003_dt '','H','" & _
        '            COCDELIST & "','" & _
        '            CUS1NOLIST & "','" & _
        '            CUS2NOLIST & "','" & _
        '            ITMNOLIST & "','" & _
        '            PVLIST & "','" & _
        '            SAISSDATFM & "','" & _
        '            SAISSDATTO & "','" & _
        '            SARVSDATFM & "','" & _
        '            SARVSDATTO & "','" & _
        '            CLMNO & "','" & _
        '            SCNO & "','" & _
        '            PONO & "','" & _
        '            CLMSTS & "','" & _
        '            gsUsrID & "'"

        'Dim rs As New ADODB.Recordset
        'rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        'MsgBox("Error on loading CLR00003 #002 sp_list_CLR00003 : " & rtnStr)
        'Else
        'If rs.RecordCount = 0 Then
        'MsgBox("No record found!")
        'Else
        'Call ExportToExcel(rs)
        'End If
        'End If
        'End If

        'If CheckClmdtl.Checked = True Then

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


        xlsWB = xlsApp.Workbooks.Add()



        gspStr = "sp_list_CLR00003_dt '','D','" & _
                    COCDELIST & "','" & _
                    CUS1NOLIST & "','" & _
                    CUS2NOLIST & "','" & _
                    ITMNOLIST & "','" & _
                    PVLIST & "','" & _
                    SAISSDATFM & "','" & _
                    SAISSDATTO & "','" & _
                    SARVSDATFM & "','" & _
                    SARVSDATTO & "','" & _
                    CLMNO & "','" & _
                    SCNO & "','" & _
                    PONO & "','" & _
                    CLMSTS & "','" & _
                    gsUsrID & "'"

        Dim rs As New ADODB.Recordset

        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLR00003 #002 sp_list_CLR00003_dt : " & rtnStr)
        Else
            If rs.RecordCount = 0 Then
                MsgBox("No record found!")
            Else
                Call ExportToExcel(1, rs)
            End If
        End If

        Me.Cursor = Cursors.Default

        gspStr = ""
        gspStr = "sp_list_CLR00004_dt '','D','" & _
                    COCDELIST & "','" & _
                    CUS1NOLIST & "','" & _
                    CUS2NOLIST & "','" & _
                    ITMNOLIST & "','" & _
                    PVLIST & "','" & _
                    SAISSDATFM & "','" & _
                    SAISSDATTO & "','" & _
                    SARVSDATFM & "','" & _
                    SARVSDATTO & "','" & _
                    CLMNO & "','" & _
                    SCNO & "','" & _
                    PONO & "','" & _
                    CLMSTS & "','" & _
                    gsUsrID & "'"

        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLR00003 #002 sp_list_CLR00004_dt : " & rtnStr)
        Else
            If rs.RecordCount = 0 Then
                MsgBox("No record found!")
            Else
                Call ExportToExcel(3, rs)
            End If
        End If

        Me.Cursor = Cursors.Default


        gspStr = "sp_list_CLR00005_dt '','D','" & _
                    COCDELIST & "','" & _
                    CUS1NOLIST & "','" & _
                    CUS2NOLIST & "','" & _
                    ITMNOLIST & "','" & _
                    PVLIST & "','" & _
                    SAISSDATFM & "','" & _
                    SAISSDATTO & "','" & _
                    SARVSDATFM & "','" & _
                    SARVSDATTO & "','" & _
                    CLMNO & "','" & _
                    SCNO & "','" & _
                    PONO & "','" & _
                    CLMSTS & "','" & _
                    gsUsrID & "'"

        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLR00003 #002 sp_list_CLR00005_dt : " & rtnStr)
        Else
            If rs.RecordCount = 0 Then
                MsgBox("No record found!")
            Else
                Call ExportToExcel(2, rs)
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

    Private Sub lblClaimPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClaimPeriod.Click

    End Sub

    Private Sub cboClaimPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaimPeriod.SelectedIndexChanged

    End Sub


    Private Sub format_cboClaimPeriod()
        'This function is only for creating new Claim
        Dim strList As String
        Dim sFirstYear As String
        Dim sSecondYear As String

        cboClaimPeriod.Items.Clear()

        cboClaimPeriod.Items.Add("All")

        If Today.Month > 3 Then
            sFirstYear = (Today.Year() - 2).ToString
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            cboClaimPeriod.Items.Add(strList)

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            cboClaimPeriod.Items.Add(strList)

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            cboClaimPeriod.Items.Add(strList)
            cboClaimPeriod.Text = strList
        Else
            sFirstYear = (Today.Year() - 3).ToString
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            cboClaimPeriod.Items.Add(strList)

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            cboClaimPeriod.Items.Add(strList)

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            cboClaimPeriod.Items.Add(strList)
            cboClaimPeriod.Text = strList

        End If



    End Sub

End Class