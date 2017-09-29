Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Public Class TOM00005

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim rs_TOExcel As DataSet

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub


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

    Private Sub TOM00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Sartup position
        Cursor = Cursors.Default

        txtFromQuotNo.MaxLength = 20


        If GetDefaultCompany_Local() = "UCPP" Then
            'Opt_yes.Enabled = False
            'Opt_no.Checked = True
            'optPrintVenN.Checked = True
        End If

        Combo1.Items.Add("Export to Excel Sheet")
        Combo1.Items.Add("Export to Excel Sheet(By Vendor)")
        Combo1.Items.Add("Export to Excel Sheet(By Vendor Type)")

        Combo1.SelectedIndex = 0
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        Dim AscDesc As String

        If txtFromQuotNo.Text = "" Then
            MsgBox("Please input Tentative No.", vbCritical, "Warning")
            txtFromQuotNo.SelectAll()
            Exit Sub
        End If

        'S = "㊣QUR00001Status※S※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        'gspStr = "sp_select_QUR00001Status '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtFromQuotNo.Text & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_QUR00001Status, rtnStr)
        'gspStr = ""

        Cursor = Cursors.Default

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading cmdShow_Click sp_select_QUR00001Status :" & rtnStr)
        '    Exit Sub
        'End If

        ' ''If rs_QUR00001Status.Tables("RESULT").Rows.Count > 0 Then
        ' ''    Cursor = Cursors.Default
        ' ''    MsgBox("At least one of Quotations is not in 'Active' status, so it can't print Quotation.")
        ' ''    Exit Sub
        ' ''End If

        Dim ReportName As String
        Dim ReportRS As New DataSet

        'If txtFromQuotNo.Text > txtToQuotNo.Text Then
        '    MsgBox("Invalid Input! (From Item No. <= To Item No!)")
        '    txtFromQuotNo.SelectAll()
        '    Exit Sub
        'End If

        Dim fty As Integer
        Dim Cftr As Integer
        Dim showqa As Integer
        Dim PrintVen As String
        Dim PrintDI As String
        Dim PrintDV As String
        Dim PrintAlias As String
        Dim printGroup As String
        Dim PrintAll As String
        Dim PrintCusals As String
        Dim sorting As String

        PrintCusals = "1"


        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Dim message As String = ""



        gspStr = "sp_select_TOExportExcel '" & gsCompany & "','" & txtFromQuotNo.Text & "'"
        message = "sp_select_TOExportExcel"
        rtnLong = execute_SQLStatement(gspStr, rs_TOExcel, rtnStr)

        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_TOExportExcel " & message & " :" & rtnStr)
            Exit Sub
        End If



        If rs_TOExcel.Tables("RESULT").Rows.Count = 0 Then
            'S = "㊣QUOTNHDR※S※" & Trim(txtFromQuotNo.Text)
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
            'Dim rs As New DataSet

            'Cursor = Cursors.WaitCursor

            'gsCompany = Trim(cboCoCde.Text)
            'Call Update_gs_Value(gsCompany)

            'gspStr = "sp_select_QUOTNHDR '" & gsCompany & "','" & txtFromQuotNo.Text & "'"
            'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            'gspStr = ""

            'Cursor = Cursors.Default

            'If rtnLong <> RC_SUCCESS Then
            '    MsgBox("Error on loading cmdShow_Click sp_select_QUOTNHDR 2 :" & rtnStr)
            '    Exit Sub
            'End If


            MsgBox("No Record Found!")
            Exit Sub

        Else
            '*** Open excel format option
            If rs_TOExcel.Tables("RESULT").Rows.Count > 30000 Then
                Dim answer As String = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                If answer = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If

            'Call exportExcel_QUR0000excel()
            If Combo1.SelectedIndex = 0 Then
                Call exportExcel_TOExportToExcel()
            ElseIf Combo1.SelectedIndex = 1 Then
                Call exportExcel_TOExportToExcelVendor()
            ElseIf Combo1.SelectedIndex = 2 Then
                Call exportExcel_TOExportToExcelVendorType_int()
                Call exportExcel_TOExportToExcelVendorType_ext()
            End If

            'ReDim ReportName(0) As String
            'ReDim ReportRS(0) As ADOR.Recordset
            '   ReportName(0) = "QUR0000excel.rpt"
            '   ReportRS(0) = rs_QUR0000excel

            'Call CmdExportExcel_Click()
            Exit Sub
        End If
    End Sub

    Private Sub exportExcel_TOExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_TOExcel.Tables("RESULT").Rows.Count >= 100 Then
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
            With xlsApp
                For i As Integer = 0 To rs_TOExcel.Tables("RESULT").Rows.Count - 2
                    .Range("A12:AR12").Copy()

                    .Range("A" + (i + 13).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            Dim seq As Integer = -1
            With xlsApp
                .Range("B1").Value = rs_TOExcel.Tables("RESULT").Rows(0).Item("toh_to")
                .Range("B2").Value = rs_TOExcel.Tables("RESULT").Rows(0).Item("toh_cc")
                .Range("B4").Value = rs_TOExcel.Tables("RESULT").Rows(0).Item("toh_fm")
                For i As Integer = 0 To rs_TOExcel.Tables("RESULT").Rows.Count - 1



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
                    If rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordseq") <> seq Then

                        If IsDBNull(rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_match")) Then
                            .Range("A" + (i + 12).ToString).Value = ""

                        Else
                            .Range("A" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_match")

                        End If

                        '.Range("A" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordno") & " - " & _
                        '                                        rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordseq")



                        .Range("B" + (i + 12).ToString).Value = Format(rs_TOExcel.Tables("RESULT").Rows(i)("tod_credat"), "MM/dd/yyyy")

                        .Range("C" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_customer")


                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat"))
                        'test_DateTime = DateTime.Parse(test_str)
                        '.Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                        .Range("D" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cus1no")
                        .Range("E" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cus2no")
                        .Range("F" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_buyer")
                        .Range("G" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_category")
                        .Range("H" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_jobno")

                        'If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")) Then
                        '    ' If rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat") <> "" Then

                        '    test_str = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")
                        '    test_DateTime = DateTime.Parse(test_str)

                        '    .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        '    'Else
                        '    'End If
                        'End If

                        .Range("I" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ftyitmno")
                        .Range("J" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_itmsku")

                        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat"))
                        'test_DateTime = DateTime.Parse(test_str)

                        .Range("K" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ftytmpitmno")

                        '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                        .Range("L" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_itmdsc")

                        .Range("M" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_colcde")

                        .Range("N" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_inrqty")


                        .Range("O" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_mtrqty")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("O" + (i + 3).ToString).Value = "PC"
                        'Else
                        '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_untcde")
                        'End If

                        .Range("P" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_pckunt")
                        .Range("Q" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_conftr")

                        .Range("R" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cft")

                        'If temp_flag_is_ass = 1 Then
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                        'Else
                        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                        'End If

                        Dim year As String = Convert.ToDateTime(rs_TOExcel.Tables("RESULT").Rows(i)("tod_period")).Year
                        Dim month As String = Split(Format(Convert.ToDateTime(rs_TOExcel.Tables("RESULT").Rows(i)("tod_period")), "MM/dd/yyyy"), "/")(0)

                        If year = "1900" Then
                            .Range("S" + (i + 12).ToString).Value = ""
                        Else
                            .Range("S" + (i + 12).ToString).Value = year + "-" + month
                        End If

                        '.Range("S" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_period")
                        '
                        '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_curcde")
                        .Range("T" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_fobport")

                        'Dim temp_cur As String
                        'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_fcurcde").ToString.Trim


                        .Range("U" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_retail")
                        .Range("V" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_projqty")
                        .Range("W" + (i + 12).ToString).Value = Format(rs_TOExcel.Tables("RESULT").Rows(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("X" + (i + 12).ToString).Value = Format(rs_TOExcel.Tables("RESULT").Rows(i)("tod_cushpdatend"), "MM/dd/yyyy")
                        .Range("Y" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_dsgven")
                        .Range("Z" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_prdven")
                        .Range("AA" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cusven")

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


                        .Range("AC" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_sapno")
                        .Range("AD" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cuspono")
                        .Range("AE" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_rmk")
                        .Range("AF" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_upc")
                        .Range("AG" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnL")
                        .Range("AH" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnW")
                        .Range("AI" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnH")
                        .Range("AJ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnupc")
                        .Range("AL" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_venstk")
                        .Range("AM" + (i + 12).ToString).Value = Format(rs_TOExcel.Tables("RESULT").Rows(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        .Range("AN" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ftycst")
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
                        .Range("AO" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_selprc")

                        .Range("AP" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_qtyb_cuspo")

                        .Range("AQ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_qtyb_ordqty")
                        '''TRAN TERM
                        .Range("AR" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_podat")
                        If Trim(.Range("AR" + (i + 12).ToString).Value) = "01/01/1900" Then
                            .Range("AR" + (i + 12).ToString).Value = ""
                        End If

                        .Range("AS" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_pcktyp")

                        '.Range("AS" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cntctp")
                    Else
                        .Range("A" + (i + 12).ToString + ":AS" + (i + 12).ToString).Value = ""
                    End If
                    '分隔
                    '.Range("AT" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpseq")
                    '.Range("AU" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                    '.Range("AV" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                    '.Range("AW" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpstr")
                    '.Range("AX" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpend")
                    '.Range("AY" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpqty")
                    '.Range("AZ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_pckunt")
                    'If rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                    '    .Range("BA" + (i + 12).ToString).Value = ""
                    'Else
                    '    .Range("BA" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat")
                    'End If




                    seq = rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordseq")
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
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_TOM00005 - Excel Error")
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
                '    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text, FileFormat:=52)
            End If



        Catch ex As Exception
            MsgBox("File " + "C:\" + txtFromQuotNo.Text + ".xls already exist. Please delete it before export a new one.")
        End Try

        ' xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, ReadOnlyRecommended:=False)

        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        rs_TOExcel = Nothing
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

        If rs_TOExcel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Dim al As New ArrayList




        Dim rs_TOExcel_tmp_sorttable As DataTable = rs_TOExcel.Tables("RESULT").DefaultView.ToTable(True, "tod_prdven") 'TQ1301002

        For ii As Integer = 0 To rs_TOExcel_tmp_sorttable.Rows.Count - 1

            Dim Vendor As String = rs_TOExcel_tmp_sorttable.Rows(ii).Item(0)

            


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
                Dim dr_TOExcel() As DataRow = rs_TOExcel.Tables("RESULT").Select("tod_prdven='" & Vendor & "'")

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
                        '.Range("AT" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpseq")
                        '.Range("AU" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                        '.Range("AV" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                        '.Range("AW" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpstr")
                        '.Range("AX" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpend")
                        '.Range("AY" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpqty")
                        '.Range("AZ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_pckunt")
                        'If rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                        '    .Range("BA" + (i + 12).ToString).Value = ""
                        'Else
                        '    .Range("BA" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat")
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
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_TOM00005 - Excel Error")
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
                    '    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_" + Vendor, FileFormat:=52)
                Else
                    '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                    xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_" + Vendor, FileFormat:=52)
                End If




                '                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_" + Vendor, FileFormat:=52)

            Catch ex As Exception
                MsgBox("File " + txtFromQuotNo.Text + "_" + Vendor + ".xls already exist. Please delete it before export a new one.")
            End Try

            ' xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, ReadOnlyRecommended:=False)

            xlsApp.Visible = True

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            'al.Add(xlsApp)

            ' Release reference
            'rs_TOExcel = Nothing
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
        rs_TOExcel = Nothing
        Cursor = Cursors.Default
    End Sub


    Private Sub exportExcel_TOExportToExcelVendorType_int()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_TOExcel.Tables("RESULT").Rows.Count >= 100 Then
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
            Dim dr_TOExcel() As DataRow = rs_TOExcel.Tables("RESULT").Select("((tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ))")

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
                        '.Range("AT" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpseq")
                        '.Range("AU" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                        '.Range("AV" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                        '.Range("AW" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpstr")
                        '.Range("AX" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpend")
                        '.Range("AY" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpqty")
                        '.Range("AZ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_pckunt")
                        'If rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                        '    .Range("BA" + (i + 12).ToString).Value = ""
                        'Else
                        '    .Range("BA" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat")
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
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_TOM00005 - Excel Error")
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
                '    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
            End If




            '''                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)

        Catch ex As Exception
            MsgBox("File " + "" + txtFromQuotNo.Text + "_int" + ".xls already exist. Please delete it before export a new one.")
        End Try

            ' xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, ReadOnlyRecommended:=False)

            xlsApp.Visible = True

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            'al.Add(xlsApp)

            ' Release reference
            'rs_TOExcel = Nothing
            xlsWS = Nothing
            xlsWB = Nothing
            xlsApp = Nothing


            ' Cursor = Cursors.Default

        'For i As Integer = 0 To al.Count - 1
        '    Dim xlx As New Excel.ApplicationClass
        '    xlx = al(i)
        '    xlx.Visible = True
        'Next
        ''rs_TOExcel = Nothing
        Cursor = Cursors.Default
    End Sub
    Private Sub exportExcel_TOExportToExcelVendorType_ext()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_TOExcel.Tables("RESULT").Rows.Count >= 100 Then
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
            Dim dr_TOExcel() As DataRow = rs_TOExcel.Tables("RESULT").Select("not ((tod_prdven >='A' and tod_prdven <='Z' )  or (tod_prdven >='a' and tod_prdven <='z' ))")


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
                        '.Range("AT" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpseq")
                        '.Range("AU" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                        '.Range("AV" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                        '.Range("AW" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpstr")
                        '.Range("AX" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpend")
                        '.Range("AY" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpqty")
                        '.Range("AZ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_pckunt")
                        'If rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                        '    .Range("BA" + (i + 12).ToString).Value = ""
                        'Else
                        '    .Range("BA" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat")
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
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_TOM00005 - Excel Error")
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
                '    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_ext", FileFormat:=52)
            Else
                '                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_ext", FileFormat:=52)
            End If





            '                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_ext", FileFormat:=52)

        Catch ex As Exception
            MsgBox("File " + "" + txtFromQuotNo.Text + "_ext" + ".xls already exist. Please delete it before export a new one.")
        End Try

            ' xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, ReadOnlyRecommended:=False)

            xlsApp.Visible = True

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            'al.Add(xlsApp)

            ' Release reference
            'rs_TOExcel = Nothing
            xlsWS = Nothing
            xlsWB = Nothing
            xlsApp = Nothing


            ' Cursor = Cursors.Default

        'For i As Integer = 0 To al.Count - 1
        '    Dim xlx As New Excel.ApplicationClass
        '    xlx = al(i)
        '    xlx.Visible = True
        'Next
        rs_TOExcel = Nothing
        Cursor = Cursors.Default
    End Sub

End Class