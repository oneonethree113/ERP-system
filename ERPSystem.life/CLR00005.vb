Imports System.Collections.Generic
Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Public Class CLR00005

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim rs_Excel As DataSet
    Public rs_SYMUSRCO As New DataSet

 


    Public Function GetDefaultCompany_Local() As String
        '*** A function to get the user's default company
        GetDefaultCompany_Local = ""

        If rs_SYUSRPRF.Tables.Count = 0 Then Exit Function
        If rs_SYUSRPRF.Tables("RESULT").Rows.Count <= 0 Then Exit Function

        For index As Integer = 0 To rs_SYUSRPRF.Tables("RESULT").Rows.Count - 1
            If rs_SYUSRPRF.Tables("RESULT").Rows(index)("yuc_flgdef").ToString = "Y" Then
                GetDefaultCompany_Local = Trim(rs_SYUSRPRF.Tables("RESULT").Rows(index)("yuc_cocde"))
                Exit Function
            End If
        Next
    End Function

    Private Sub CLR00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor


        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Me.KeyPreview = True
        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLR00002 #001 sp_select_SYMUSRCO : " & rtnStr)
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

        Call Formstartup(Me.Name)
        Cursor = Cursors.Default

        Dim sFirstYear As String
        Dim sSecondYear As String
        Dim sSecondMonth As String
        Dim sSecondDay As String
        Dim sFirstMonth As String


        sFirstYear = (Today.Year().ToString)
        sFirstYear = sFirstYear - 1
        sSecondYear = sFirstYear + 1

        sSecondMonth = (Today.Month().ToString)
        If sSecondMonth.Length = 1 Then
            sSecondMonth = "0" & sSecondMonth
        End If

        sFirstMonth = Convert.ToInt32(sSecondMonth) - 1

        If sFirstMonth.Length = 1 Then
            sFirstMonth = "0" & sFirstMonth
        End If

        If Convert.ToInt32(sFirstMonth) = 0 Then
            sFirstMonth = sSecondMonth
        End If

        sSecondDay = (Today.Day().ToString)
        If sSecondDay.Length = 1 Then
            sSecondDay = "0" & sSecondDay
        End If
        '        txt_S_SCIssdatFm.Text = Format(Today.Date, "MM/dd/yyyy")
        txt_S_SAIssdatFm.Text = sFirstMonth & "/" & sSecondDay & "/" & sSecondYear
        txt_S_SAIssdatTo.Text = sSecondMonth & "/" & sSecondDay & "/" & sSecondYear



        '  Combo1.SelectedIndex = 0
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
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
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            If Len(Me.txt_S_CoCde.Text) > 1000 Then
                MsgBox("The Company Code List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
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
                Me.Cursor = Cursors.Default
                Exit Sub
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
                Me.Cursor = Cursors.Default
                Exit Sub
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
                Me.Cursor = Cursors.Default
                Exit Sub
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
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            PVLIST = removeduplicateItem(Trim(Me.txt_S_PV.Text))
            PVLIST = PVLIST.Replace("'", "''")
        End If

        If Me.txt_S_SAIssdatFm.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SAIssdatFm.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SAIssdatFm.Focus()
                flagcheck = 1
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Me.txt_S_SAIssdatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SAIssdatTo.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SAIssdatTo.Focus()
                flagcheck = 1
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SAIssdatFm.Text, 7) > Mid(Me.txt_S_SAIssdatTo.Text, 7) And flagcheck = 0 Then
            MsgBox("Claim Create Date: End Date < Start Date (YY)")
            Me.txt_S_SAIssdatFm.Focus()
            flagcheck = 1
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf Mid(Me.txt_S_SAIssdatFm.Text, 7) = Mid(Me.txt_S_SAIssdatTo.Text, 7) Then
            If Me.txt_S_SAIssdatFm.Text.Substring(0, 2) > Me.txt_S_SAIssdatTo.Text.Substring(0, 2) And flagcheck = 0 Then
                MsgBox("Claim Create Date: End Date < Start Date (MM)")
                Me.txt_S_SAIssdatFm.Focus()
                flagcheck = 1
                Me.Cursor = Cursors.Default
                Exit Sub
            ElseIf Me.txt_S_SAIssdatFm.Text.Substring(0, 2) = Me.txt_S_SAIssdatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SAIssdatFm.Text.Substring(3, 2) > Me.txt_S_SAIssdatTo.Text.Substring(3, 2) And flagcheck = 0 Then
                    MsgBox("Claim Create Date: End Date < Start Date (DD)")
                    Me.txt_S_SAIssdatFm.Focus()
                    flagcheck = 1
                    Me.Cursor = Cursors.Default
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
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Me.txt_S_SARvsdatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SARvsdatTo.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SARvsdatTo.Focus()
                flagcheck = 1
                Me.Cursor = Cursors.Default

                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SARvsdatFm.Text, 7) > Mid(Me.txt_S_SARvsdatTo.Text, 7) And flagcheck = 0 Then
            MsgBox("Claim Approval Date: End Date < Start Date (YY)")
            Me.txt_S_SARvsdatFm.Focus()
            flagcheck = 1
            Me.Cursor = Cursors.Default

            Exit Sub
        ElseIf Mid(Me.txt_S_SARvsdatFm.Text, 7) = Mid(Me.txt_S_SARvsdatTo.Text, 7) Then
            If Me.txt_S_SARvsdatFm.Text.Substring(0, 2) > Me.txt_S_SARvsdatTo.Text.Substring(0, 2) And flagcheck = 0 Then
                MsgBox("Claim Approval Date: End Date < Start Date (MM)")
                Me.txt_S_SARvsdatFm.Focus()
                flagcheck = 1
                Me.Cursor = Cursors.Default

                Exit Sub
            ElseIf Me.txt_S_SARvsdatFm.Text.Substring(0, 2) = Me.txt_S_SARvsdatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SARvsdatFm.Text.Substring(3, 2) > Me.txt_S_SARvsdatTo.Text.Substring(3, 2) And flagcheck = 0 Then
                    MsgBox("Claim Approval Date: End Date < Start Date (DD)")
                    Me.txt_S_SARvsdatFm.Focus()
                    flagcheck = 1
                    Me.Cursor = Cursors.Default

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
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Trim(Me.txt_S_CaOrdNo.Text) = "" Then
            CLMNO = ""
        Else
            If Len(Me.txt_S_CaOrdNo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Claim No is too long (1000 char)")
                flagcheck = 1
                Me.Cursor = Cursors.Default
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
                Me.Cursor = Cursors.Default
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
                Me.Cursor = Cursors.Default
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
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            CLMSTS = removeduplicateItem(Trim(Me.txt_S_CaSts.Text))
            CLMSTS = CLMSTS.Replace("'", "''")
        End If

        Dim temp_chk_donot_show_dtl As String
        If chk_donot_show_dtl.Checked = True Then
            temp_chk_donot_show_dtl = "Y"
        Else
            temp_chk_donot_show_dtl = "N"
        End If

        Dim adsd As String

        adsd = COCDELIST
        
        gspStr = "sp_list_CLR00007_dt '','D','" & _
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
                    temp_chk_donot_show_dtl & "','" & _
                    gsUsrID & "'"

        Dim rs As New ADODB.Recordset

        rtnLong = execute_SQLStatement(gspStr, rs_Excel, rtnStr)

        If rs_Excel.Tables("RESULT").Rows.Count = 0 Then

            MsgBox("No Record Found!")
            Me.Cursor = Cursors.Default

            Exit Sub

        Else
            '*** Open excel format option
            If rs_Excel.Tables("RESULT").Rows.Count > 30000 Then
                Dim answer As String = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                If answer = Windows.Forms.DialogResult.No Then
                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If
            End If
            If temp_chk_donot_show_dtl = "Y" Then
                Call exportExcel_ExportToExcelVendorType_hdr()
            Else
                Call exportExcel_ExportToExcelVendorType()
            End If

            Me.Cursor = Cursors.Default

            Exit Sub
        End If
 
        Me.Cursor = Cursors.Default

        '''''''''''''


        ''S = "㊣QUR00001Status※S※" & "" & "※" & txtToQuotNo.Text
        ''rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        'Cursor = Cursors.WaitCursor


        ''gspStr = "sp_select_QUR00001Status '" & gsCompany & "','" & "" & "','" & "" & "'"
        ''rtnLong = execute_SQLStatement(gspStr, rs_QUR00001Status, rtnStr)
        ''gspStr = ""

        'Cursor = Cursors.Default

        ''If rtnLong <> RC_SUCCESS Then
        ''    MsgBox("Error on loading cmdShow_Click sp_select_QUR00001Status :" & rtnStr)
        ''    Exit Sub
        ''End If

        '' ''If rs_QUR00001Status.Tables("RESULT").Rows.Count > 0 Then
        '' ''    Cursor = Cursors.Default
        '' ''    MsgBox("At least one of Quotations is not in 'Active' status, so it can't print Quotation.")
        '' ''    Exit Sub
        '' ''End If

        'Dim ReportName As String
        'Dim ReportRS As New DataSet

        ''If "" > txtToQuotNo.Text Then
        ''    MsgBox("Invalid Input! (From Item No. <= To Item No!)")
        ''    txtFromQuotNo.SelectAll()
        ''    Exit Sub
        ''End If

        'Dim fty As Integer
        'Dim Cftr As Integer
        'Dim showqa As Integer
        'Dim PrintVen As String
        'Dim PrintDI As String
        'Dim PrintDV As String
        'Dim PrintAlias As String
        'Dim printGroup As String
        'Dim PrintAll As String
        'Dim PrintCusals As String
        'Dim sorting As String

        'PrintCusals = "1"


        'Cursor = Cursors.WaitCursor


        'Dim message As String = ""



        'gspStr = "sp_list_CLR00007_dt "
        'message = "sp_select_TOExportExcel"
        'rtnLong = execute_SQLStatement(gspStr, rs_Excel, rtnStr)

        'gspStr = ""

        'Cursor = Cursors.Default

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading sp_select_TOExportExcel " & message & " :" & rtnStr)
        '    Exit Sub
        'End If



        'If rs_Excel.Tables("RESULT").Rows.Count = 0 Then

        '    MsgBox("No Record Found!")
        '    Exit Sub

        'Else
        '    '*** Open excel format option
        '    If rs_Excel.Tables("RESULT").Rows.Count > 30000 Then
        '        Dim answer As String = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
        '        If answer = Windows.Forms.DialogResult.No Then
        '            Exit Sub
        '        End If
        '    End If

        '    Call exportExcel_ExportToExcelVendorType()

        '    Exit Sub
        'End If


    End Sub

    Private Sub exportExcel_TOExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_Excel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application



        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        ' xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

        ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\CLtemplate\CL__8.xls")


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
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
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

            'Copy  Data
            With xlsApp
                For i As Integer = 0 To rs_Excel.Tables("RESULT").Rows.Count - 2
                    .Range("A12:AR12").Copy()

                    .Range("A" + (i + 13).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            Dim seq As Integer = -1
            With xlsApp


                For i As Integer = 0 To rs_Excel.Tables("RESULT").Rows.Count - 1
                    .Range("A" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_claPeriod")
                    .Range("B" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_claby")
                    .Range("C" + (i + 5).ToString).Value = ""

                    .Range("D" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_credat")

                    .Range("E" + (i + 5).ToString).Value = "A-Z"
                    '.Range("F" + (i + 5).ToString).Value = rs_excel.Tables("RESULT").Rows(i)("cah_cus1no")
                    .Range("G" + (i + 5).ToString).Value = ""
                    .Range("H" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_venno")
                    '                    temp()

                    .Range("I" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_season")
                    .Range("J" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_ref_no")

                    .Range("K" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_credat")

                    .Range("L" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_pot_val")
                    .Range("M" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_cacur")
                    .Range("N" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_caamt_org")
                    .Range("O" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_caamt_final")

                    .Range("P" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("CAH_CATOINSCUR")
                    .Range("Q" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("CAH_CATOINSAMT")
                Next
            End With


            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                '    xlsWB.SaveAs(Filename:="C:\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\12345678", FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "12345678", FileFormat:=52)
            End If



        Catch ex As Exception
            'MsgBox("File " + "C:\" + "" + ".xls already exist. Please delete it before export a new one.")
        End Try

        ' xlsWB.SaveAs(Filename:="C:\" + "", ReadOnlyRecommended:=False)

        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        rs_Excel = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
    End Sub

    Private Sub exportExcel_TOExportToExcelVendor()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_Excel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Dim al As New ArrayList




        Dim rs_Excel_tmp_sorttable As DataTable = rs_Excel.Tables("RESULT").DefaultView.ToTable(True, "tod_prdven") 'TQ1301002

        For ii As Integer = 0 To rs_Excel_tmp_sorttable.Rows.Count - 1

            Dim Vendor As String = rs_Excel_tmp_sorttable.Rows(ii).Item(0)




            Cursor = Cursors.WaitCursor

            xlsApp = New Excel.Application



            'Set the excel invisible to prevent user interrupt the process of creating the excel
            xlsApp.Visible = False
            xlsApp.UserControl = False


            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            ' xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

            ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
            xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\TOtemplate\TO TEMP(xls)3.xls")


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
                '    entry(20) = "E"
                '    entry(21) = "F"
                '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
                '    entry(23) = "H"
                '    entry(24) = "J"
                '    entry(25) = "K = H+J"
                '    entry(26) = "L"
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

                'Copy  Data
                Dim dr_TOExcel() As DataRow = rs_Excel.Tables("RESULT").Select("tod_prdven='" & Vendor & "'")

                With xlsApp
                    For i As Integer = 0 To dr_TOExcel.Length - 2

                        .Range("A12:AR12").Copy()

                        .Range("A" + (i + 13).ToString).Select()
                        xlsWS.Paste()


                    Next

                    .Range("A88:A88").Copy()

                End With


                Dim seq As Integer = -1

                With xlsApp
                    .Range("B1").Value = dr_TOExcel(0).Item("toh_to")
                    .Range("B2").Value = dr_TOExcel(0).Item("toh_cc")
                    .Range("B4").Value = dr_TOExcel(0).Item("toh_fm")
                    For i As Integer = 0 To dr_TOExcel.Length - 1



                        'Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc"))
                        'Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr"))


                        'Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp"))
                        'Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde"))
                        'Dim temp_flag_is_ass As Integer

                        'Dim test_str As String
                        'Dim test_DateTime As Date

                        'temp_flag_is_ass = 0

                        ' ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                        'If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                        '    temp_flag_is_ass = 1
                        'End If

                        ''New Template     
                        ''                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("ibi_catlvl3")

                        ''## Either "XMASTREE"


                        'tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat"))
                        'If tmp_cat = "XMASTREE" Then
                        '    tmp_cat = "XMAS TREE"
                        'End If
                        If dr_TOExcel(i).Item("tod_toordseq") <> seq Then

                            If IsDBNull(dr_TOExcel(i).Item("tod_match")) Then
                                .Range("A" + (i + 12).ToString).Value = ""

                            Else
                                .Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_match")

                            End If

                            '.Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_toordno") & " - " & _
                            '                                        dr_TOExcel(i).Item("tod_toordseq")



                            .Range("B" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_credat"), "MM/dd/yyyy")

                            .Range("C" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_customer")


                            'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat"))
                            'test_DateTime = DateTime.Parse(test_str)
                            '.Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                            .Range("D" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus1no")
                            .Range("E" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus2no")
                            .Range("F" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_buyer")
                            .Range("G" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_category")
                            .Range("H" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_jobno")

                            'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")) Then
                            '    ' If rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat") <> "" Then

                            '    test_str = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")
                            '    test_DateTime = DateTime.Parse(test_str)

                            '    .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                            '    'Else
                            '    'End If
                            'End If

                            .Range("I" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftyitmno")
                            .Range("J" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmsku")

                            'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat"))
                            'test_DateTime = DateTime.Parse(test_str)

                            .Range("K" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftytmpitmno")

                            '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                            .Range("L" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmdsc")

                            .Range("M" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_colcde")

                            .Range("N" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_inrqty")


                            .Range("O" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_mtrqty")

                            'If temp_flag_is_ass = 1 Then
                            '    .Range("O" + (i + 3).ToString).Value = "PC"
                            'Else
                            '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_untcde")
                            'End If

                            .Range("P" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pckunt")
                            .Range("Q" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_conftr")

                            .Range("R" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cft")

                            'If temp_flag_is_ass = 1 Then
                            '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                            'Else
                            '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                            'End If

                            Dim year As String = Convert.ToDateTime(dr_TOExcel(i)("tod_period")).Year
                            Dim month As String = Split(Format(Convert.ToDateTime(dr_TOExcel(i)("tod_period")), "MM/dd/yyyy"), "/")(0)

                            If year = "1900" Then
                                .Range("S" + (i + 12).ToString).Value = ""
                            Else
                                .Range("S" + (i + 12).ToString).Value = year + "-" + month
                            End If

                            '.Range("S" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_period")
                            '
                            '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_curcde")
                            .Range("T" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_fobport")

                            'Dim temp_cur As String
                            'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_fcurcde").ToString.Trim


                            .Range("U" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_retail")
                            .Range("V" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_projqty")
                            .Range("W" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                            .Range("X" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatend"), "MM/dd/yyyy")
                            .Range("Y" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_dsgven")
                            .Range("Z" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_prdven")
                            .Range("AA" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cusven")

                            'If temp_flag_is_ass = 1 Then
                            '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst") / temp_qud_conftr
                            'Else
                            '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst")
                            'End If

                            'Dim temp_ftyprc As Double

                            'If temp_flag_is_ass = 1 Then
                            '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")) / temp_qud_conftr
                            'Else
                            '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc"))
                            'End If

                            'Dim temp_FTY_cost As Decimal
                            'Dim temp_FTY_mu As Decimal

                            'temp_FTY_cost = Val(.Range("AA" + (i + 3).ToString).Value)
                            'If IsNumeric(.Range("AA" + (i + 3).ToString).Value) And IsNumeric(temp_ftyprc) Then
                            '    If Val(.Range("AA" + (i + 3).ToString).Value) <> 0 Then

                            '        .Range("AL" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(.Range("AA" + (i + 3).ToString).Value)
                            '        temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                            '    End If
                            'End If

                            'Dim temp_FTY_prc As Decimal

                            'temp_FTY_prc = temp_FTY_cost * temp_FTY_mu

                            'Dim temp_basprc As Decimal
                            'temp_basprc = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")

                            'Dim temp_hk_mu As Decimal
                            'temp_hk_mu = temp_basprc / temp_FTY_prc
                            '.Range("AN" + (i + 3).ToString).Value = temp_hk_mu


                            'If temp_flag_is_ass = 1 Then
                            '    temp_basprc = temp_basprc / temp_qud_conftr
                            'End If
                            'If temp_flag_is_ass = 1 Then
                            '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc") / temp_qud_conftr
                            'Else
                            '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")
                            'End If


                            .Range("AC" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_sapno")
                            .Range("AD" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cuspono")
                            .Range("AE" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_rmk")
                            .Range("AF" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_upc")
                            .Range("AG" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnL")
                            .Range("AH" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnW")
                            .Range("AI" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnH")
                            .Range("AJ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnupc")
                            .Range("AL" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_venstk")
                            .Range("AM" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                            .Range("AN" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftycst")
                            'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")) Then
                            '    If rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec") <> "" Then
                            '        .Range("AK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")
                            '    Else
                            '        gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmno") & "'"
                            '        rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                            '        gspStr = ""
                            '        Cursor = Cursors.Default
                            '        If rtnLong <> RC_SUCCESS Then
                            '            MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                            '            Exit Sub
                            '        End If

                            '        If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                            '            .Range("AK" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                            '        Else
                            '            .Range("AK" + (i + 3).ToString).Value = ""
                            '        End If

                            '    End If
                            'End If


                            ' .Range("AL" + (i + 3).ToString).Value = "1.18"
                            '.Range("AM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")
                            .Range("AO" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_selprc")

                            .Range("AP" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_cuspo")

                            .Range("AQ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_ordqty")
                            '''TRAN TERM
                            .Range("AR" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_podat")
                            If Trim(.Range("AR" + (i + 12).ToString).Value) = "01/01/1900" Then
                                .Range("AR" + (i + 12).ToString).Value = ""
                            End If

                            .Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pcktyp")

                            '.Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cntctp")
                        Else
                            .Range("A" + (i + 12).ToString + ":AS" + (i + 12).ToString).Value = ""
                        End If

                        '分隔
                        '.Range("AT" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpseq")
                        '.Range("AU" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                        '.Range("AV" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                        '.Range("AW" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpstr")
                        '.Range("AX" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpend")
                        '.Range("AY" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpqty")
                        '.Range("AZ" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_pckunt")
                        'If rs_Excel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                        '    .Range("BA" + (i + 12).ToString).Value = ""
                        'Else
                        '    .Range("BA" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_podat")
                        'End If



                        seq = dr_TOExcel(i).Item("tod_toordseq")

                    Next







                End With

                'Remark
                'With xlsApp
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
                '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
                'End With

                ' Configuring XLS Style
                With xlsApp
                    '.Rows("1:1").Font.Bold = True
                    '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                    '.Rows("1:200").Font.Name = "Arial"
                    '.Rows("1:200").Format.Align = 2

                    '.Rows("1:1").Font.Underline = True
                    '.Rows("1:1").Font.Size = 10

                    '.Columns("A:AY").WrapText = False
                    '.Columns("A:AY").EntireColumn.AutoFit()

                    ''.Columns("V:V").
                    ''.Range("F2").Formula = "=SUM(D2;E2)"
                    'For index As Integer = 1 To entry.Length
                    'If .Columns(index).ColumnWidth > 50 Then
                    '.Columns(index).ColumnWidth = 50
                    'End If
                    'Next

                End With
            Catch ex As Exception
                If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                    If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                        xlsWS = Nothing
                        xlsWB = Nothing
                        xlsApp = Nothing
                        exportExcel_TOExportToExcel()
                    End If
                Else
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
                End If
            End Try




            'Show the excel after creating process is completed
            Try
                Dim Yourpath As String


                Yourpath = "C:\" & saveto_folder.Text
                If (Not System.IO.Directory.Exists(Yourpath)) Then
                    System.IO.Directory.CreateDirectory(Yourpath)
                End If


                Vendor = Vendor.ToString.Replace("/", " ")

                If saveto_folder.Text.Trim = "" Then
                    '    xlsWB.SaveAs(Filename:="C:\" + "" + "_int", FileFormat:=52)
                    xlsWB.SaveAs(Filename:="C:\" + "" + "_" + Vendor, FileFormat:=52)
                Else
                    '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_int", FileFormat:=52)
                    xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_" + Vendor, FileFormat:=52)
                End If




                '                xlsWB.SaveAs(Filename:="C:\" + "" + "_" + Vendor, FileFormat:=52)

            Catch ex As Exception
                'MsgBox("File " + "" + "_" + Vendor + ".xls already exist. Please delete it before export a new one.")
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
        Next

        'For i As Integer = 0 To al.Count - 1
        '    Dim xlx As New Excel.ApplicationClass
        '    xlx = al(i)
        '    xlx.Visible = True
        'Next
        rs_Excel = Nothing
        Cursor = Cursors.Default
    End Sub


    Private Sub exportExcel_TOExportToExcelVendorType_int()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_Excel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
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
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\TOtemplate\TO TEMP(xls)3.xls")


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
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
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

            'Copy  Data
            Dim dr_TOExcel() As DataRow = rs_Excel.Tables("RESULT").Select("((tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ))")

            With xlsApp
                For i As Integer = 0 To dr_TOExcel.Length - 2

                    .Range("A12:AR12").Copy()

                    .Range("A" + (i + 13).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            Dim seq As Integer = -1

            With xlsApp
                .Range("B1").Value = dr_TOExcel(0).Item("toh_to")
                .Range("B2").Value = dr_TOExcel(0).Item("toh_cc")
                .Range("B4").Value = dr_TOExcel(0).Item("toh_fm")
                For i As Integer = 0 To dr_TOExcel.Length - 1



                    'Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc"))
                    'Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr"))


                    'Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp"))
                    'Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde"))
                    'Dim temp_flag_is_ass As Integer

                    'Dim test_str As String
                    'Dim test_DateTime As Date

                    'temp_flag_is_ass = 0

                    ' ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                    'If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                    '    temp_flag_is_ass = 1
                    'End If

                    ''New Template     
                    ''                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("ibi_catlvl3")

                    ''## Either "XMASTREE"


                    'tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat"))
                    'If tmp_cat = "XMASTREE" Then
                    '    tmp_cat = "XMAS TREE"
                    'End If
                    If dr_TOExcel(i).Item("tod_toordseq") <> seq Then

                        If IsDBNull(dr_TOExcel(i).Item("tod_match")) Then
                            .Range("A" + (i + 12).ToString).Value = ""

                        Else
                            .Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_match")

                        End If

                        '.Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_toordno") & " - " & _
                        '                                        dr_TOExcel(i).Item("tod_toordseq")



                        .Range("B" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_credat"), "MM/dd/yyyy")

                        .Range("C" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_customer")


                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat"))
                        'test_DateTime = DateTime.Parse(test_str)
                        '.Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                        .Range("D" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus1no")
                        .Range("E" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus2no")
                        .Range("F" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_buyer")
                        .Range("G" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_category")
                        .Range("H" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_jobno")

                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")) Then
                        '    ' If rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat") <> "" Then

                        '    test_str = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")
                        '    test_DateTime = DateTime.Parse(test_str)

                        '    .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        '    'Else
                        '    'End If
                        'End If

                        .Range("I" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftyitmno")
                        .Range("J" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmsku")

                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat"))
                        'test_DateTime = DateTime.Parse(test_str)

                        .Range("K" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftytmpitmno")

                        '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                        .Range("L" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmdsc")

                        .Range("M" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_colcde")

                        .Range("N" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_inrqty")


                        .Range("O" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_mtrqty")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("O" + (i + 3).ToString).Value = "PC"
                        'Else
                        '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_untcde")
                        'End If

                        .Range("P" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pckunt")
                        .Range("Q" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_conftr")

                        .Range("R" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cft")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                        'Else
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                        'End If

                        Dim year As String = Convert.ToDateTime(dr_TOExcel(i)("tod_period")).Year
                        Dim month As String = Split(Format(Convert.ToDateTime(dr_TOExcel(i)("tod_period")), "MM/dd/yyyy"), "/")(0)

                        If year = "1900" Then
                            .Range("S" + (i + 12).ToString).Value = ""
                        Else
                            .Range("S" + (i + 12).ToString).Value = year + "-" + month
                        End If

                        '.Range("S" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_period")
                        '
                        '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_curcde")
                        .Range("T" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_fobport")

                        'Dim temp_cur As String
                        'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_fcurcde").ToString.Trim


                        .Range("U" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_retail")
                        .Range("V" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_projqty")
                        .Range("W" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("X" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatend"), "MM/dd/yyyy")
                        .Range("Y" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_dsgven")
                        .Range("Z" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_prdven")
                        .Range("AA" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cusven")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst") / temp_qud_conftr
                        'Else
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst")
                        'End If

                        'Dim temp_ftyprc As Double

                        'If temp_flag_is_ass = 1 Then
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")) / temp_qud_conftr
                        'Else
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc"))
                        'End If

                        'Dim temp_FTY_cost As Decimal
                        'Dim temp_FTY_mu As Decimal

                        'temp_FTY_cost = Val(.Range("AA" + (i + 3).ToString).Value)
                        'If IsNumeric(.Range("AA" + (i + 3).ToString).Value) And IsNumeric(temp_ftyprc) Then
                        '    If Val(.Range("AA" + (i + 3).ToString).Value) <> 0 Then

                        '        .Range("AL" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(.Range("AA" + (i + 3).ToString).Value)
                        '        temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                        '    End If
                        'End If

                        'Dim temp_FTY_prc As Decimal

                        'temp_FTY_prc = temp_FTY_cost * temp_FTY_mu

                        'Dim temp_basprc As Decimal
                        'temp_basprc = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")

                        'Dim temp_hk_mu As Decimal
                        'temp_hk_mu = temp_basprc / temp_FTY_prc
                        '.Range("AN" + (i + 3).ToString).Value = temp_hk_mu


                        'If temp_flag_is_ass = 1 Then
                        '    temp_basprc = temp_basprc / temp_qud_conftr
                        'End If
                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc") / temp_qud_conftr
                        'Else
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")
                        'End If


                        .Range("AC" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_sapno")
                        .Range("AD" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cuspono")
                        .Range("AE" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_rmk")
                        .Range("AF" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_upc")
                        .Range("AG" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnL")
                        .Range("AH" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnW")
                        .Range("AI" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnH")
                        .Range("AJ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnupc")
                        .Range("AL" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_venstk")
                        .Range("AM" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("AN" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftycst")
                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")) Then
                        '    If rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec") <> "" Then
                        '        .Range("AK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")
                        '    Else
                        '        gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmno") & "'"
                        '        rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                        '        gspStr = ""
                        '        Cursor = Cursors.Default
                        '        If rtnLong <> RC_SUCCESS Then
                        '            MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                        '            Exit Sub
                        '        End If

                        '        If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                        '            .Range("AK" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                        '        Else
                        '            .Range("AK" + (i + 3).ToString).Value = ""
                        '        End If

                        '    End If
                        'End If


                        ' .Range("AL" + (i + 3).ToString).Value = "1.18"
                        '.Range("AM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")
                        .Range("AO" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_selprc")

                        .Range("AP" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_cuspo")

                        .Range("AQ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_ordqty")
                        '''TRAN TERM
                        .Range("AR" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_podat")
                        If Trim(.Range("AR" + (i + 12).ToString).Value) = "01/01/1900" Then
                            .Range("AR" + (i + 12).ToString).Value = ""
                        End If

                        .Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pcktyp")

                        '.Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cntctp")
                    Else
                        .Range("A" + (i + 12).ToString + ":AS" + (i + 12).ToString).Value = ""
                    End If
                    '分隔
                    '.Range("AT" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpseq")
                    '.Range("AU" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                    '.Range("AV" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                    '.Range("AW" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpstr")
                    '.Range("AX" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpend")
                    '.Range("AY" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpqty")
                    '.Range("AZ" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_pckunt")
                    'If rs_Excel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                    '    .Range("BA" + (i + 12).ToString).Value = ""
                    'Else
                    '    .Range("BA" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_podat")
                    'End If



                    seq = dr_TOExcel(i).Item("tod_toordseq")

                Next







            End With

            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                '    xlsWB.SaveAs(Filename:="C:\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + "" + "_int", FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_int", FileFormat:=52)
            End If




            '''                xlsWB.SaveAs(Filename:="C:\" + "" + "_int", FileFormat:=52)

        Catch ex As Exception
            'MsgBox("File " + "" + "" + "_int" + ".xls already exist. Please delete it before export a new one.")
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
    Private Sub exportExcel_TOExportToExcelVendorType_ext()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_Excel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
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
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\TOtemplate\TO TEMP(xls)3.xls")


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
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
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

            'Copy  Data
            Dim dr_TOExcel() As DataRow = rs_Excel.Tables("RESULT").Select("not ((tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ))")


            With xlsApp
                For i As Integer = 0 To dr_TOExcel.Length - 2

                    .Range("A12:AR12").Copy()

                    .Range("A" + (i + 13).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            Dim seq As Integer = -1

            With xlsApp
                .Range("B1").Value = dr_TOExcel(0).Item("toh_to")
                .Range("B2").Value = dr_TOExcel(0).Item("toh_cc")
                .Range("B4").Value = dr_TOExcel(0).Item("toh_fm")
                For i As Integer = 0 To dr_TOExcel.Length - 1



                    'Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc"))
                    'Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr"))


                    'Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp"))
                    'Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde"))
                    'Dim temp_flag_is_ass As Integer

                    'Dim test_str As String
                    'Dim test_DateTime As Date

                    'temp_flag_is_ass = 0

                    ' ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                    'If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                    '    temp_flag_is_ass = 1
                    'End If

                    ''New Template     
                    ''                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("ibi_catlvl3")

                    ''## Either "XMASTREE"


                    'tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat"))
                    'If tmp_cat = "XMASTREE" Then
                    '    tmp_cat = "XMAS TREE"
                    'End If
                    If dr_TOExcel(i).Item("tod_toordseq") <> seq Then

                        If IsDBNull(dr_TOExcel(i).Item("tod_match")) Then
                            .Range("A" + (i + 12).ToString).Value = ""

                        Else
                            .Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_match")

                        End If

                        '.Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_toordno") & " - " & _
                        '                                        dr_TOExcel(i).Item("tod_toordseq")



                        .Range("B" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_credat"), "MM/dd/yyyy")

                        .Range("C" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_customer")


                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat"))
                        'test_DateTime = DateTime.Parse(test_str)
                        '.Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                        .Range("D" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus1no")
                        .Range("E" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus2no")
                        .Range("F" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_buyer")
                        .Range("G" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_category")
                        .Range("H" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_jobno")

                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")) Then
                        '    ' If rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat") <> "" Then

                        '    test_str = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")
                        '    test_DateTime = DateTime.Parse(test_str)

                        '    .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        '    'Else
                        '    'End If
                        'End If

                        .Range("I" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftyitmno")
                        .Range("J" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmsku")

                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat"))
                        'test_DateTime = DateTime.Parse(test_str)

                        .Range("K" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftytmpitmno")

                        '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                        .Range("L" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmdsc")

                        .Range("M" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_colcde")

                        .Range("N" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_inrqty")


                        .Range("O" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_mtrqty")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("O" + (i + 3).ToString).Value = "PC"
                        'Else
                        '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_untcde")
                        'End If

                        .Range("P" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pckunt")
                        .Range("Q" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_conftr")

                        .Range("R" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cft")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                        'Else
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                        'End If

                        Dim year As String = Convert.ToDateTime(dr_TOExcel(i)("tod_period")).Year
                        Dim month As String = Split(Format(Convert.ToDateTime(dr_TOExcel(i)("tod_period")), "MM/dd/yyyy"), "/")(0)

                        If year = "1900" Then
                            .Range("S" + (i + 12).ToString).Value = ""
                        Else
                            .Range("S" + (i + 12).ToString).Value = year + "-" + month
                        End If

                        '.Range("S" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_period")
                        '
                        '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_curcde")
                        .Range("T" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_fobport")

                        'Dim temp_cur As String
                        'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_fcurcde").ToString.Trim


                        .Range("U" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_retail")
                        .Range("V" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_projqty")
                        .Range("W" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("X" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatend"), "MM/dd/yyyy")
                        .Range("Y" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_dsgven")
                        .Range("Z" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_prdven")
                        .Range("AA" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cusven")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst") / temp_qud_conftr
                        'Else
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst")
                        'End If

                        'Dim temp_ftyprc As Double

                        'If temp_flag_is_ass = 1 Then
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")) / temp_qud_conftr
                        'Else
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc"))
                        'End If

                        'Dim temp_FTY_cost As Decimal
                        'Dim temp_FTY_mu As Decimal

                        'temp_FTY_cost = Val(.Range("AA" + (i + 3).ToString).Value)
                        'If IsNumeric(.Range("AA" + (i + 3).ToString).Value) And IsNumeric(temp_ftyprc) Then
                        '    If Val(.Range("AA" + (i + 3).ToString).Value) <> 0 Then

                        '        .Range("AL" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(.Range("AA" + (i + 3).ToString).Value)
                        '        temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                        '    End If
                        'End If

                        'Dim temp_FTY_prc As Decimal

                        'temp_FTY_prc = temp_FTY_cost * temp_FTY_mu

                        'Dim temp_basprc As Decimal
                        'temp_basprc = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")

                        'Dim temp_hk_mu As Decimal
                        'temp_hk_mu = temp_basprc / temp_FTY_prc
                        '.Range("AN" + (i + 3).ToString).Value = temp_hk_mu


                        'If temp_flag_is_ass = 1 Then
                        '    temp_basprc = temp_basprc / temp_qud_conftr
                        'End If
                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc") / temp_qud_conftr
                        'Else
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")
                        'End If


                        .Range("AC" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_sapno")
                        .Range("AD" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cuspono")
                        .Range("AE" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_rmk")
                        .Range("AF" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_upc")
                        .Range("AG" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnL")
                        .Range("AH" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnW")
                        .Range("AI" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnH")
                        .Range("AJ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnupc")
                        .Range("AL" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_venstk")
                        .Range("AM" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("AN" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftycst")
                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")) Then
                        '    If rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec") <> "" Then
                        '        .Range("AK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")
                        '    Else
                        '        gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmno") & "'"
                        '        rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                        '        gspStr = ""
                        '        Cursor = Cursors.Default
                        '        If rtnLong <> RC_SUCCESS Then
                        '            MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                        '            Exit Sub
                        '        End If

                        '        If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                        '            .Range("AK" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                        '        Else
                        '            .Range("AK" + (i + 3).ToString).Value = ""
                        '        End If

                        '    End If
                        'End If


                        ' .Range("AL" + (i + 3).ToString).Value = "1.18"
                        '.Range("AM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")
                        .Range("AO" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_selprc")

                        .Range("AP" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_cuspo")

                        .Range("AQ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_ordqty")
                        '''TRAN TERM
                        .Range("AR" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_podat")
                        If Trim(.Range("AR" + (i + 12).ToString).Value) = "01/01/1900" Then
                            .Range("AR" + (i + 12).ToString).Value = ""
                        End If

                        .Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pcktyp")

                        '.Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cntctp")
                    Else
                        .Range("A" + (i + 12).ToString + ":AS" + (i + 12).ToString).Value = ""
                    End If
                    '分隔
                    '.Range("AT" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpseq")
                    '.Range("AU" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                    '.Range("AV" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                    '.Range("AW" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpstr")
                    '.Range("AX" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpend")
                    '.Range("AY" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpqty")
                    '.Range("AZ" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_pckunt")
                    'If rs_Excel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                    '    .Range("BA" + (i + 12).ToString).Value = ""
                    'Else
                    '    .Range("BA" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_podat")
                    'End If



                    seq = dr_TOExcel(i).Item("tod_toordseq")

                Next







            End With

            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                '    xlsWB.SaveAs(Filename:="C:\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + "" + "_ext", FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_ext", FileFormat:=52)
            End If





            '                xlsWB.SaveAs(Filename:="C:\" + "" + "_ext", FileFormat:=52)

        Catch ex As Exception
            'MsgBox("File " + "" + "" + "_ext" + ".xls already exist. Please delete it before export a new one.")
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
        rs_Excel = Nothing
        Cursor = Cursors.Default
    End Sub





    Private Sub exportExcel_TOExportToExcelVendorType_ext_1756()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_Excel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
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
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\TOtemplate\TO TEMP(xls)3.xls")


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
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
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

            'Copy  Data
            Dim dr_TOExcel() As DataRow = rs_Excel.Tables("RESULT").Select("tod_prdven ='1756' ")


            With xlsApp
                For i As Integer = 0 To dr_TOExcel.Length - 2

                    .Range("A12:AR12").Copy()

                    .Range("A" + (i + 13).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            Dim seq As Integer = -1

            With xlsApp
                .Range("B1").Value = dr_TOExcel(0).Item("toh_to")
                .Range("B2").Value = dr_TOExcel(0).Item("toh_cc")
                .Range("B4").Value = dr_TOExcel(0).Item("toh_fm")
                For i As Integer = 0 To dr_TOExcel.Length - 1



                    'Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc"))
                    'Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr"))


                    'Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp"))
                    'Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde"))
                    'Dim temp_flag_is_ass As Integer

                    'Dim test_str As String
                    'Dim test_DateTime As Date

                    'temp_flag_is_ass = 0

                    ' ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                    'If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                    '    temp_flag_is_ass = 1
                    'End If

                    ''New Template     
                    ''                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("ibi_catlvl3")

                    ''## Either "XMASTREE"


                    'tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat"))
                    'If tmp_cat = "XMASTREE" Then
                    '    tmp_cat = "XMAS TREE"
                    'End If
                    If dr_TOExcel(i).Item("tod_toordseq") <> seq Then

                        If IsDBNull(dr_TOExcel(i).Item("tod_match")) Then
                            .Range("A" + (i + 12).ToString).Value = ""

                        Else
                            .Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_match")

                        End If

                        '.Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_toordno") & " - " & _
                        '                                        dr_TOExcel(i).Item("tod_toordseq")



                        .Range("B" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_credat"), "MM/dd/yyyy")

                        .Range("C" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_customer")


                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat"))
                        'test_DateTime = DateTime.Parse(test_str)
                        '.Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                        .Range("D" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus1no")
                        .Range("E" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus2no")
                        .Range("F" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_buyer")
                        .Range("G" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_category")
                        .Range("H" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_jobno")

                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")) Then
                        '    ' If rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat") <> "" Then

                        '    test_str = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")
                        '    test_DateTime = DateTime.Parse(test_str)

                        '    .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        '    'Else
                        '    'End If
                        'End If

                        .Range("I" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftyitmno")
                        .Range("J" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmsku")

                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat"))
                        'test_DateTime = DateTime.Parse(test_str)

                        .Range("K" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftytmpitmno")

                        '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                        .Range("L" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmdsc")

                        .Range("M" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_colcde")

                        .Range("N" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_inrqty")


                        .Range("O" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_mtrqty")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("O" + (i + 3).ToString).Value = "PC"
                        'Else
                        '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_untcde")
                        'End If

                        .Range("P" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pckunt")
                        .Range("Q" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_conftr")

                        .Range("R" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cft")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                        'Else
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                        'End If

                        Dim year As String = Convert.ToDateTime(dr_TOExcel(i)("tod_period")).Year
                        Dim month As String = Split(Format(Convert.ToDateTime(dr_TOExcel(i)("tod_period")), "MM/dd/yyyy"), "/")(0)

                        If year = "1900" Then
                            .Range("S" + (i + 12).ToString).Value = ""
                        Else
                            .Range("S" + (i + 12).ToString).Value = year + "-" + month
                        End If

                        '.Range("S" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_period")
                        '
                        '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_curcde")
                        .Range("T" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_fobport")

                        'Dim temp_cur As String
                        'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_fcurcde").ToString.Trim


                        .Range("U" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_retail")
                        .Range("V" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_projqty")
                        .Range("W" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("X" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatend"), "MM/dd/yyyy")
                        .Range("Y" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_dsgven")
                        .Range("Z" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_prdven")
                        .Range("AA" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cusven")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst") / temp_qud_conftr
                        'Else
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst")
                        'End If

                        'Dim temp_ftyprc As Double

                        'If temp_flag_is_ass = 1 Then
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")) / temp_qud_conftr
                        'Else
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc"))
                        'End If

                        'Dim temp_FTY_cost As Decimal
                        'Dim temp_FTY_mu As Decimal

                        'temp_FTY_cost = Val(.Range("AA" + (i + 3).ToString).Value)
                        'If IsNumeric(.Range("AA" + (i + 3).ToString).Value) And IsNumeric(temp_ftyprc) Then
                        '    If Val(.Range("AA" + (i + 3).ToString).Value) <> 0 Then

                        '        .Range("AL" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(.Range("AA" + (i + 3).ToString).Value)
                        '        temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                        '    End If
                        'End If

                        'Dim temp_FTY_prc As Decimal

                        'temp_FTY_prc = temp_FTY_cost * temp_FTY_mu

                        'Dim temp_basprc As Decimal
                        'temp_basprc = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")

                        'Dim temp_hk_mu As Decimal
                        'temp_hk_mu = temp_basprc / temp_FTY_prc
                        '.Range("AN" + (i + 3).ToString).Value = temp_hk_mu


                        'If temp_flag_is_ass = 1 Then
                        '    temp_basprc = temp_basprc / temp_qud_conftr
                        'End If
                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc") / temp_qud_conftr
                        'Else
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")
                        'End If


                        .Range("AC" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_sapno")
                        .Range("AD" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cuspono")
                        .Range("AE" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_rmk")
                        .Range("AF" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_upc")
                        .Range("AG" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnL")
                        .Range("AH" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnW")
                        .Range("AI" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnH")
                        .Range("AJ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnupc")
                        .Range("AL" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_venstk")
                        .Range("AM" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("AN" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftycst")
                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")) Then
                        '    If rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec") <> "" Then
                        '        .Range("AK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")
                        '    Else
                        '        gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmno") & "'"
                        '        rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                        '        gspStr = ""
                        '        Cursor = Cursors.Default
                        '        If rtnLong <> RC_SUCCESS Then
                        '            MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                        '            Exit Sub
                        '        End If

                        '        If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                        '            .Range("AK" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                        '        Else
                        '            .Range("AK" + (i + 3).ToString).Value = ""
                        '        End If

                        '    End If
                        'End If


                        ' .Range("AL" + (i + 3).ToString).Value = "1.18"
                        '.Range("AM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")
                        .Range("AO" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_selprc")

                        .Range("AP" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_cuspo")

                        .Range("AQ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_ordqty")
                        '''TRAN TERM
                        .Range("AR" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_podat")
                        If Trim(.Range("AR" + (i + 12).ToString).Value) = "01/01/1900" Then
                            .Range("AR" + (i + 12).ToString).Value = ""
                        End If

                        .Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pcktyp")

                        '.Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cntctp")
                    Else
                        .Range("A" + (i + 12).ToString + ":AS" + (i + 12).ToString).Value = ""
                    End If
                    '分隔
                    '.Range("AT" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpseq")
                    '.Range("AU" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                    '.Range("AV" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                    '.Range("AW" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpstr")
                    '.Range("AX" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpend")
                    '.Range("AY" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpqty")
                    '.Range("AZ" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_pckunt")
                    'If rs_Excel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                    '    .Range("BA" + (i + 12).ToString).Value = ""
                    'Else
                    '    .Range("BA" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_podat")
                    'End If



                    seq = dr_TOExcel(i).Item("tod_toordseq")

                Next







            End With

            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                '    xlsWB.SaveAs(Filename:="C:\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + "" + "_ext", FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_ext", FileFormat:=52)
            End If





            '                xlsWB.SaveAs(Filename:="C:\" + "" + "_ext", FileFormat:=52)

        Catch ex As Exception
            '            MsgBox("File " + "" + "" + "_ext" + ".xls already exist. Please delete it before export a new one.")
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
        rs_Excel = Nothing
        Cursor = Cursors.Default
    End Sub


    Private Sub exportExcel_TOExportToExcelVendorType_hk()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_Excel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
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
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\TOtemplate\TO TEMP(xls)3.xls")


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
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
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

            'Copy  Data
            Dim dr_TOExcel() As DataRow
            If chk_int.Checked = True And chk_ext.Checked = False And chk_1756.Checked = False Then
                'int
                dr_TOExcel = rs_Excel.Tables("RESULT").Select("((tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ))")
            ElseIf chk_int.Checked = False And chk_ext.Checked = True And chk_1756.Checked = False Then
                'ext
                dr_TOExcel = rs_Excel.Tables("RESULT").Select("not ((tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ) or  tod_prdven like '%1756%' )")
            ElseIf chk_int.Checked = False And chk_ext.Checked = False And chk_1756.Checked = True Then
                '1756
                dr_TOExcel = rs_Excel.Tables("RESULT").Select("tod_prdven like '%1756%'")
            ElseIf chk_int.Checked = True And chk_ext.Checked = True And chk_1756.Checked = False Then
                'int & ext=not 1756
                dr_TOExcel = rs_Excel.Tables("RESULT").Select("not tod_prdven like '%1756%' ")
            ElseIf chk_int.Checked = True And chk_ext.Checked = False And chk_1756.Checked = True Then
                'int & 1756 = not ext
                dr_TOExcel = rs_Excel.Tables("RESULT").Select("(tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ) or  tod_prdven like '%1756%'  ")
            ElseIf chk_int.Checked = False And chk_ext.Checked = True And chk_1756.Checked = True Then
                'ext&1756 = not int
                dr_TOExcel = rs_Excel.Tables("RESULT").Select("not ((tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ))")
            ElseIf chk_int.Checked = True And chk_ext.Checked = True And chk_1756.Checked = True Then
                'all
                dr_TOExcel = rs_Excel.Tables("RESULT").Select("tod_prdven <> '$^&$%'")
            ElseIf chk_int.Checked = False And chk_ext.Checked = False And chk_1756.Checked = False Then
                'all not
                MsgBox("Please select vendor type!")
                Exit Sub
            End If

            With xlsApp
                For i As Integer = 0 To dr_TOExcel.Length - 2

                    .Range("A12:AR12").Copy()

                    .Range("A" + (i + 13).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            Dim seq As Integer = -1

            With xlsApp
                .Range("B1").Value = dr_TOExcel(0).Item("toh_to")
                .Range("B2").Value = dr_TOExcel(0).Item("toh_cc")
                .Range("B4").Value = dr_TOExcel(0).Item("toh_fm")
                For i As Integer = 0 To dr_TOExcel.Length - 1



                    'Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc"))
                    'Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr"))


                    'Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp"))
                    'Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde"))
                    'Dim temp_flag_is_ass As Integer

                    'Dim test_str As String
                    'Dim test_DateTime As Date

                    'temp_flag_is_ass = 0

                    ' ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                    'If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                    '    temp_flag_is_ass = 1
                    'End If

                    ''New Template     
                    ''                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("ibi_catlvl3")

                    ''## Either "XMASTREE"


                    'tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_fml_cat"))
                    'If tmp_cat = "XMASTREE" Then
                    '    tmp_cat = "XMAS TREE"
                    'End If
                    If dr_TOExcel(i).Item("tod_toordseq") <> seq Then

                        If IsDBNull(dr_TOExcel(i).Item("tod_match")) Then
                            .Range("A" + (i + 12).ToString).Value = ""

                        Else
                            .Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_match")

                        End If

                        '.Range("A" + (i + 12).ToString).Value = dr_TOExcel(i).Item("tod_toordno") & " - " & _
                        '                                        dr_TOExcel(i).Item("tod_toordseq")



                        .Range("B" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_credat"), "MM/dd/yyyy")

                        .Range("C" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_customer")


                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat"))
                        'test_DateTime = DateTime.Parse(test_str)
                        '.Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                        .Range("D" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus1no")
                        .Range("E" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cus2no")
                        .Range("F" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_buyer")
                        .Range("G" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_category")
                        .Range("H" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_jobno")

                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")) Then
                        '    ' If rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat") <> "" Then

                        '    test_str = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")
                        '    test_DateTime = DateTime.Parse(test_str)

                        '    .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        '    'Else
                        '    'End If
                        'End If

                        .Range("I" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftyitmno")
                        .Range("J" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmsku")

                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat"))
                        'test_DateTime = DateTime.Parse(test_str)

                        .Range("K" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftytmpitmno")

                        '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                        .Range("L" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_itmdsc")

                        .Range("M" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_colcde")

                        .Range("N" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_inrqty")


                        .Range("O" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_mtrqty")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("O" + (i + 3).ToString).Value = "PC"
                        'Else
                        '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_untcde")
                        'End If

                        .Range("P" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pckunt")
                        .Range("Q" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_conftr")

                        .Range("R" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cft")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                        'Else
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                        'End If

                        Dim year As String = Convert.ToDateTime(dr_TOExcel(i)("tod_period")).Year
                        Dim month As String = Split(Format(Convert.ToDateTime(dr_TOExcel(i)("tod_period")), "MM/dd/yyyy"), "/")(0)

                        If year = "1900" Then
                            .Range("S" + (i + 12).ToString).Value = ""
                        Else
                            .Range("S" + (i + 12).ToString).Value = year + "-" + month
                        End If

                        '.Range("S" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_period")
                        '
                        '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_curcde")
                        .Range("T" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_fobport")

                        'Dim temp_cur As String
                        'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_fcurcde").ToString.Trim


                        .Range("U" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_retail")
                        .Range("V" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_projqty")
                        .Range("W" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("X" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatend"), "MM/dd/yyyy")
                        .Range("Y" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_dsgven")
                        .Range("Z" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_prdven")
                        .Range("AA" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cusven")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst") / temp_qud_conftr
                        'Else
                        '    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftycst")
                        'End If

                        'Dim temp_ftyprc As Double

                        'If temp_flag_is_ass = 1 Then
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")) / temp_qud_conftr
                        'Else
                        '    temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc"))
                        'End If

                        'Dim temp_FTY_cost As Decimal
                        'Dim temp_FTY_mu As Decimal

                        'temp_FTY_cost = Val(.Range("AA" + (i + 3).ToString).Value)
                        'If IsNumeric(.Range("AA" + (i + 3).ToString).Value) And IsNumeric(temp_ftyprc) Then
                        '    If Val(.Range("AA" + (i + 3).ToString).Value) <> 0 Then

                        '        .Range("AL" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(.Range("AA" + (i + 3).ToString).Value)
                        '        temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                        '    End If
                        'End If

                        'Dim temp_FTY_prc As Decimal

                        'temp_FTY_prc = temp_FTY_cost * temp_FTY_mu

                        'Dim temp_basprc As Decimal
                        'temp_basprc = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")

                        'Dim temp_hk_mu As Decimal
                        'temp_hk_mu = temp_basprc / temp_FTY_prc
                        '.Range("AN" + (i + 3).ToString).Value = temp_hk_mu


                        'If temp_flag_is_ass = 1 Then
                        '    temp_basprc = temp_basprc / temp_qud_conftr
                        'End If
                        'If temp_flag_is_ass = 1 Then
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc") / temp_qud_conftr
                        'Else
                        '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_basprc")
                        'End If


                        .Range("AC" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_sapno")
                        .Range("AD" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cuspono")
                        .Range("AE" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_rmk")
                        .Range("AF" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_upc")
                        .Range("AG" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnL")
                        .Range("AH" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnW")
                        .Range("AI" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnH")
                        .Range("AJ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ctnupc")
                        .Range("AL" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_venstk")
                        .Range("AM" + (i + 12).ToString).Value = Format(dr_TOExcel(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("AN" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_ftycst")
                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")) Then
                        '    If rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec") <> "" Then
                        '        .Range("AK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_lightspec")
                        '    Else
                        '        gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmno") & "'"
                        '        rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                        '        gspStr = ""
                        '        Cursor = Cursors.Default
                        '        If rtnLong <> RC_SUCCESS Then
                        '            MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                        '            Exit Sub
                        '        End If

                        '        If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                        '            .Range("AK" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                        '        Else
                        '            .Range("AK" + (i + 3).ToString).Value = ""
                        '        End If

                        '    End If
                        'End If


                        ' .Range("AL" + (i + 3).ToString).Value = "1.18"
                        '.Range("AM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")
                        .Range("AO" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_selprc")

                        .Range("AP" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_cuspo")

                        .Range("AQ" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_qtyb_ordqty")
                        '''TRAN TERM
                        .Range("AR" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_podat")
                        If Trim(.Range("AR" + (i + 12).ToString).Value) = "01/01/1900" Then
                            .Range("AR" + (i + 12).ToString).Value = ""
                        End If

                        .Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_pcktyp")

                        '.Range("AS" + (i + 12).ToString).Value = dr_TOExcel(i)("tod_cntctp")
                    Else
                        .Range("A" + (i + 12).ToString + ":AS" + (i + 12).ToString).Value = ""
                    End If
                    '分隔
                    '.Range("AT" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpseq")
                    '.Range("AU" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                    '.Range("AV" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                    '.Range("AW" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpstr")
                    '.Range("AX" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_cushpend")
                    '.Range("AY" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_shpqty")
                    '.Range("AZ" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_pckunt")
                    'If rs_Excel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                    '    .Range("BA" + (i + 12).ToString).Value = ""
                    'Else
                    '    .Range("BA" + (i + 12).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("tds_podat")
                    'End If



                    seq = dr_TOExcel(i).Item("tod_toordseq")

                Next







            End With

            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                '    xlsWB.SaveAs(Filename:="C:\" + "" + "_hk", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + "" + "_hk", FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_hk", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + "" + "_hk", FileFormat:=52)
            End If




            '''                xlsWB.SaveAs(Filename:="C:\" + "" + "_hk", FileFormat:=52)

        Catch ex As Exception
            '            MsgBox("File " + "" + "" + "_hk" + ".xls already exist. Please delete it before export a new one.")
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


    Private Sub exportExcel_ExportToExcelVendorType()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String
        Dim txt_S_PriCust_Text As String
        Dim txt_S_SAIssdatFm_Text As String
        Dim txt_S_SAIssdatTo_Text As String

        txt_S_PriCust_Text = txt_S_PriCust.Text.Trim
        txt_S_PriCust_Text = txt_S_PriCust_Text.Replace(",", "_")
        txt_S_SAIssdatFm_Text = txt_S_SAIssdatFm.Text.Trim
        txt_S_SAIssdatFm_Text = txt_S_SAIssdatFm_Text.Replace("/", "")
        txt_S_SAIssdatTo_Text = txt_S_SAIssdatTo.Text.Trim
        txt_S_SAIssdatTo_Text = txt_S_SAIssdatTo_Text.Replace("/", "")


        If rs_Excel.Tables("RESULT").Rows.Count >= 30000 Then
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
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\CLtemplate\CL__8.xlsx")


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
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
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

            'Copy  Data
            Dim dr_CLExcel() As DataRow
            If chk_int.Checked = True And chk_ext.Checked = False And chk_1756.Checked = False Then
                'int
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("((cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ))")
            ElseIf chk_int.Checked = False And chk_ext.Checked = True And chk_1756.Checked = False Then
                'ext
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("not ((cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ) or  cah_venno like '%1756%' )")
            ElseIf chk_int.Checked = False And chk_ext.Checked = False And chk_1756.Checked = True Then
                '1756
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("cah_venno like '%1756%'")
            ElseIf chk_int.Checked = True And chk_ext.Checked = True And chk_1756.Checked = False Then
                'int & ext=not 1756
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("not cah_venno like '%1756%' ")
            ElseIf chk_int.Checked = True And chk_ext.Checked = False And chk_1756.Checked = True Then
                'int & 1756 = not ext
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("(cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ) or  cah_venno like '%1756%'  ")
            ElseIf chk_int.Checked = False And chk_ext.Checked = True And chk_1756.Checked = True Then
                'ext&1756 = not int
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("not ((cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ))")
            ElseIf chk_int.Checked = True And chk_ext.Checked = True And chk_1756.Checked = True Then
                'all
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("cah_venno <> '$^&$%'")
            ElseIf chk_int.Checked = False And chk_ext.Checked = False And chk_1756.Checked = False Then
                'all not
                MsgBox("Please select vendor type!")
                Exit Sub
            End If

            'With xlsApp
            '    For i As Integer = 0 To dr_CLExcel.Length - 2

            '        .Range("A12:AR12").Copy()

            '        .Range("A" + (i + 13).ToString).Select()
            '        xlsWS.Paste()


            '    Next

            '    .Range("A88:A88").Copy()

            'End With


            Dim seq As Integer = -1

            With xlsApp

                For i As Integer = 0 To dr_CLExcel.Length - 1
                    .Range("A" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_cus1no")
                    .Range("B" + (i + 4).ToString).Value = dr_CLExcel(i)("cbi_cussna")
                    '
                    .Range("C" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordno")
                    .Range("D" + (i + 4).ToString).Value = dr_CLExcel(i)("cad_shissdat")

                    .Range("E" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordsts")
                    .Range("F" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordsts_a")

                    .Range("G" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_cmt_a")
                    .Range("H" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordsts_b")

                    .Range("I" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_cmt_b")

                    If dr_CLExcel(i)("cah_venno") <> "" Then
                        .Range("J" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_venno") & " - " & dr_CLExcel(i)("vbi_vensna")
                    End If
                    '
                    'If rs_Excel.Tables("RESULT").Rows(i)("cah_venno") <> "" Then
                    '    .Range("H" + (i + 5).ToString).Value = rs_Excel.Tables("RESULT").Rows(i)("cah_venno") & " - " & rs_Excel.Tables("RESULT").Rows(i)("vbi_vensna")
                    'End If
                    .Range("K" + (i + 4).ToString).Value = dr_CLExcel(i)("cad_itmno")
                    .Range("L" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_reason")
                    '
                    .Range("M" + (i + 4).ToString).Value = dr_CLExcel(i)("yct_dsc")
                    .Range("N" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caamt_final")

                    .Range("O" + (i + 4).ToString).Value = dr_CLExcel(i)("CAH_CATOINSCUR")
                    .Range("P" + (i + 4).ToString).Value = dr_CLExcel(i)("CAH_CATOHKOAMT")
                    .Range("Q" + (i + 4).ToString).Value = dr_CLExcel(i)("CAH_CATOVNAMT")


                    '
                    .Range("R" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_rmk")
                    .Range("S" + (i + 4).ToString).Value = dr_CLExcel(i)("cad_rmk")

                Next
            End With

            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Dim file_name As String


            file_name = txt_S_PriCust_Text & "_" & txt_S_SAIssdatFm_Text & "_" & txt_S_SAIssdatTo_Text



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



    Private Sub exportExcel_ExportToExcelVendorType_hdr()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String
        Dim txt_S_PriCust_Text As String
        Dim txt_S_SAIssdatFm_Text As String
        Dim txt_S_SAIssdatTo_Text As String

        txt_S_PriCust_Text = txt_S_PriCust.Text.Trim
        txt_S_PriCust_Text = txt_S_PriCust_Text.Replace(",", "_")
        txt_S_SAIssdatFm_Text = txt_S_SAIssdatFm.Text.Trim
        txt_S_SAIssdatFm_Text = txt_S_SAIssdatFm_Text.Replace("/", "")
        txt_S_SAIssdatTo_Text = txt_S_SAIssdatTo.Text.Trim
        txt_S_SAIssdatTo_Text = txt_S_SAIssdatTo_Text.Replace("/", "")

        If rs_Excel.Tables("RESULT").Rows.Count >= 30000 Then
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
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\CLtemplate\CL__9.xlsx")


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
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
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

            'Copy  Data
            Dim dr_CLExcel() As DataRow
            If chk_int.Checked = True And chk_ext.Checked = False And chk_1756.Checked = False Then
                'int
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("((cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ))")
            ElseIf chk_int.Checked = False And chk_ext.Checked = True And chk_1756.Checked = False Then
                'ext
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("not ((cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ) or  cah_venno like '%1756%' )")
            ElseIf chk_int.Checked = False And chk_ext.Checked = False And chk_1756.Checked = True Then
                '1756
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("cah_venno like '%1756%'")
            ElseIf chk_int.Checked = True And chk_ext.Checked = True And chk_1756.Checked = False Then
                'int & ext=not 1756
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("not cah_venno like '%1756%' ")
            ElseIf chk_int.Checked = True And chk_ext.Checked = False And chk_1756.Checked = True Then
                'int & 1756 = not ext
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("(cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ) or  cah_venno like '%1756%'  ")
            ElseIf chk_int.Checked = False And chk_ext.Checked = True And chk_1756.Checked = True Then
                'ext&1756 = not int
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("not ((cah_venno >='A' and cah_venno <='Z' )  or (cah_venno >='a' and cah_venno <='z' ))")
            ElseIf chk_int.Checked = True And chk_ext.Checked = True And chk_1756.Checked = True Then
                'all
                dr_CLExcel = rs_Excel.Tables("RESULT").Select("cah_venno <> '$^&$%'")
            ElseIf chk_int.Checked = False And chk_ext.Checked = False And chk_1756.Checked = False Then
                'all not
                MsgBox("Please select vendor type!")
                Exit Sub
            End If

            'With xlsApp
            '    For i As Integer = 0 To dr_CLExcel.Length - 2

            '        .Range("A12:AR12").Copy()

            '        .Range("A" + (i + 13).ToString).Select()
            '        xlsWS.Paste()


            '    Next

            '    .Range("A88:A88").Copy()

            'End With


            Dim seq As Integer = -1

            With xlsApp

                For i As Integer = 0 To dr_CLExcel.Length - 1
                    .Range("A" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_cus1no")
                    .Range("B" + (i + 4).ToString).Value = dr_CLExcel(i)("cbi_cussna")
                    '
                    .Range("C" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordno")
                    '.Range("D" + (i + 4).ToString).Value = dr_CLExcel(i)("cad_shissdat")

                    .Range("D" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordsts")
                    .Range("E" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordsts_a")

                    .Range("F" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_cmt_a")
                    .Range("G" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caordsts_b")

                    .Range("H" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_cmt_b")

                    If dr_CLExcel(i)("cah_venno") <> "" Then
                        .Range("I" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_venno") & " - " & dr_CLExcel(i)("vbi_vensna")
                    End If


                    '.Range("I" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_venno")
                    '

                    '                    .Range("K" + (i + 4).ToString).Value = dr_CLExcel(i)("cad_itmno")
                    .Range("J" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_reason")
                    '
                    .Range("K" + (i + 4).ToString).Value = dr_CLExcel(i)("yct_dsc")
                    .Range("L" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_caamt_final")

                    .Range("M" + (i + 4).ToString).Value = dr_CLExcel(i)("CAH_CATOINSCUR")
                    .Range("N" + (i + 4).ToString).Value = dr_CLExcel(i)("CAH_CATOHKOAMT")
                    .Range("O" + (i + 4).ToString).Value = dr_CLExcel(i)("CAH_CATOVNAMT")


                    '
                    .Range("P" + (i + 4).ToString).Value = dr_CLExcel(i)("cah_rmk")
                    '.Range("Q" + (i + 4).ToString).Value = dr_CLExcel(i)("cad_rmk")

                Next
            End With

            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_TOExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_CLR00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Dim file_name As String


            file_name = txt_S_PriCust_Text & "_" & txt_S_SAIssdatFm_Text & "_" & txt_S_SAIssdatTo_Text



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


    Private Sub lblRptName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRptName.Click

    End Sub
    Private Function removeduplicateItem(ByVal s As String) As String
        Return s
    End Function

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_frmS(Me.cmd_S_CoCde)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCust)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
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
End Class