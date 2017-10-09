Imports Microsoft.Office.Interop
Imports System.IO

Public Class MSR00032

    Public rs_VNBASINF As DataSet
    Public rs_CUBASINF As DataSet
    Public rs_MSR00032 As DataSet
    Public dr() As DataRow
    Dim rs_CUBASINF_P As New DataSet


    Private Sub MSR00032_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        loadComboBox()

        Call format_cboSC()
        Call FillcboCust()
        GetDefaultCompany(cboCoCde, txtCoNam)

        cboCoCde.Text = "UC-G"
        txtCoNam.Text = "UNITED CHINESE GROUP"

        Me.Cursor = Cursors.Default


    End Sub

    Private Sub loadComboBox()
        FillCompCombo(gsUsrID, cboCoCde)
        cboCoCde.Items.Add("UC-G")

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00017_Load #001 sp_list_VNBASINF_vensna :" & rtnStr)
        End If

        format_cboVen()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click


        If Trim(txtFromItmno.Text) = "" Or Trim(txtToItmno.Text) = "" Then
            MsgBox("Please Input the Item No. Range !")
            txtFromItmno.Focus()
            Exit Sub
        End If



        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------



        'If InputIsValid = False Then
        '    Exit Sub
        'End If

        Dim S As String
        Dim Co As String
        Dim CuFm As String
        Dim CuTo As String
        Dim VnFm As String
        Dim VnTo As String
        Dim scFM As String
        Dim ScTo As String
        Dim rs() As DataSet

        'ReDim ReportName(0) As String
        'ReDim ReportRS(0) As ADOR.Recordset

        Me.Cursor = Windows.Forms.Cursors.WaitCursor


        If cboVenFm.Text = "" Then
            VnFm = ""
        Else
            VnFm = Split(cboVenFm.Text, " - ")(0)
        End If
        If cboVenTo.Text = "" Then
            VnTo = ""
        Else
            VnTo = Split(cboVenTo.Text, " - ")(0)
        End If

        If cboSCFm.Text = "" Then
            scFM = ""
        Else
            scFM = Split(cboSCFm.Text, " - ")(0)
        End If
        If cboSCTo.Text = "" Then
            ScTo = ""
        Else
            ScTo = Split(cboSCTo.Text, " - ")(0)
        End If


        If cboCUFm.Text = "" Then
            CuFm = ""
        Else
            CuFm = Split(cboCUFm.Text, " - ")(0)
        End If
        If cboCUTo.Text = "" Then
            CuTo = ""
        Else
            CuTo = Split(cboCUTo.Text, " - ")(0)
        End If


        'If Me.cboVenFm.Text > Me.cboVenTo.Text Then
        '            Me.Cursor = Windows.Forms.Cursors.Default
        '    MsgBox "Vendor No: From > To!"
        '    Exit Sub
        'End If
        'If Me.cboSCFm.Text > Me.cboSCTo.Text Then
        '            Me.Cursor = Windows.Forms.Cursors.Default
        '    MsgBox "Sub Code: From > To!"
        '    Exit Sub
        'End If
        'If Me.cboCuFm.Text > Me.cboCuTo.Text Then
        '            Me.Cursor = Windows.Forms.Cursors.Default
        '    MsgBox "Customer No: From > To!"
        '    Exit Sub
        'End If



        Me.Cursor = Windows.Forms.Cursors.WaitCursor


        'gspStr = "sp_select_MSR00033 '" & cboCoCde.Text & _
        '    "','" & CNF & "','" & cnt & _
        '    "','" & txtSIFm.Text & "','" & txtSITo.Text & _
        '    "','" & VENCDEFM & "','" & VENCDETO & _
        '    "','" & VenSubCdeFm & "','" & VenSubCdeTo & _
        '    "','" & VenTypFm & "','" & VenTypTo & _
        '    "','" & IDF & "','" & IDT & _
        '    "','" & status & _
        '    "','" & sort & "','" & gsUsrID & "'"


        gspStr = "temp_sp_select_MSR00032 '" & cboCoCde.Text & _
            "','" & UCase(txtFromItmno.Text) & _
            "','" & UCase(txtToItmno.Text) & _
            "','" & VnFm & _
            "','" & VnTo & _
            "','" & scFM & _
            "','" & ScTo & _
            "','" & CuFm & _
            "','" & CuTo & _
            "','" & gsSalTem & _
            "','" & gsUsrID & "'"

        'gspStr = "sp_select_MSR00032 'UCP','50000','59999','','','','','','','','','03/01/2009','03/01/2013','ALL','','mis'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_MSR00032, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00032 : " & rtnStr)
            Exit Sub
        End If


        If rs_MSR00032.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("M00032: Record not found!")
            Exit Sub
        End If

        If optExcel.Checked = True Then
            Call CmdExportExcel_Click()

        Else
            Dim objRpt As New MSR00032Rpt
            objRpt.SetDataSource(rs_MSR00032.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        End If




    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        '  Call cboCoCdeClick()
        If cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

            gspStr = "sp_select_CUBASINF_PC '" & cboCoCde.Text & "','" & gsUsrID & "','" & "QU" & "','Primary'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
            gspStr = ""

            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading QUM00001  sp_select_CUBASINF_P : " & rtnStr)
                Exit Sub
            End If


            Call fillcboPriCust()




        Else

            txtCoNam.Text = "UNITED CHINESE GROUP"
            Call FillcboCust()
        End If


    End Sub
    Private Sub cboCoCdeClick()
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Call getDefault_Path()

    End Sub

    Public Function ChangeCompany(ByVal CoCde As String, ByVal FormName As String) As String
        Dim dr() As DataRow

        ChangeCompany = ""
        gsCompany = CoCde

        dr = rs_SYCOMINF_NAME.Tables("RESULT").Select("yco_cocde = '" & gsCompany & "'")
        If Not dr.Length > 0 Then
            'MsgBox("Invalid Company Name")
        Else
            ChangeCompany = dr(0)("yco_conam").ToString
        End If
        Call Update_gs_Value(gsCompany)
        Call AccessRight(FormName)
        Call FillcboCust()

    End Function
    Private Sub format_cboVen()
        cboVenFm.Items.Clear()
        cboVenTo.Items.Clear()

        cboVenFm.Items.Add("")
        cboVenTo.Items.Add("")

        For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
            cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
        Next
    End Sub

    Private Sub format_cboSC()
        cboSCFm.Items.Clear()
        cboSCTo.Items.Clear()

        cboSCFm.Items.Add("")
        cboSCTo.Items.Add("")

        For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
            cboSCFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            cboSCTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
        Next
    End Sub
    'Private Sub FillcboCust()


    '    gspStr = "sp_list_CUBASINF '" & cboCoCde.Text & "','PA'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
    '    gspStr = ""

    '    Cursor = Cursors.Default

    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading Load sp_list_CUBASINF :" & rtnStr)
    '        Exit Sub
    '    End If

    '    Cursor = Cursors.WaitCursor


    '    If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then

    '        rs_CUBASINF.Tables("RESULT").DefaultView.Sort = "cbi_cusno"
    '        dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '60000'")

    '        'Dim tmp_array(0) As String
    '        'tmp_array(0) = "cbi_cusno"
    '        'dr.Sort(tmp_array)


    '        For i As Integer = 0 To dr.Length - 1
    '            cboCUFm.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
    '            cboCUTo.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
    '        Next

    '        cboCUFm.SelectedIndex = 0
    '        cboCUTo.SelectedIndex = cboCUTo.Items.Count - 1
    '    End If
    'End Sub

    Private Sub FillcboCust()

        If rs_CUBASINF Is Nothing Then
            Exit Sub
        End If


        cboCUFm.Items.Clear()
        cboCUTo.Items.Clear()
        cboCUFm.Items.Add("")
        cboCUTo.Items.Add("")

        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '60000'")

            For i As Integer = 0 To dr.Length - 1
                cboCUFm.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
                cboCUTo.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
            Next

            cboCUFm.SelectedIndex = 0
            cboCUTo.SelectedIndex = 0
        End If
    End Sub



    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtFromItmno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromItmno.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    '    Private Sub CmdExportExcel_Click()

    '        On Error GoTo Err_Handler

    '        Cursor = Cursors.WaitCursor

    '        Dim xlApp As Excel.Application
    '        Dim xlWb As Excel.Workbook
    '        Dim xlWs As Excel.Worksheet

    '        '        Dim recArray As Object

    '        Dim fldCount As Integer
    '        Dim recCount As Long
    '        Dim iCol As Integer
    '        Dim iRow As Integer

    '        xlApp = CreateObject("Excel.Application")
    '        xlWb = xlApp.Workbooks.Add
    '        xlWs = xlWb.Worksheets(1)

    '        xlApp.Visible = True
    '        xlApp.UserControl = True

    '        xlWs.Cells(1, 1) = "Itmno"
    '        xlWs.Cells(1, 2) = "Colpck"
    '        xlWs.Cells(1, 3) = "Type"
    '        xlWs.Cells(1, 4) = "DOCType"
    '        xlWs.Cells(1, 5) = "Cus1no"
    '        xlWs.Cells(1, 6) = "Cussna_sort"
    '        xlWs.Cells(1, 7) = "DocNo"
    '        xlWs.Cells(1, 8) = "Cussna"
    '        xlWs.Cells(1, 9) = "issdat"
    '        xlWs.Cells(1, 10) = "rvsdat"
    '        xlWs.Cells(1, 11) = "smpUM"
    '        xlWs.Cells(1, 12) = "venno"
    '        xlWs.Cells(1, 13) = "subcde"
    '        xlWs.Cells(1, 14) = "OrderQty"
    '        xlWs.Cells(1, 15) = "ShpQty"
    '        xlWs.Cells(1, 16) = "OSQty"
    '        xlWs.Cells(1, 17) = "ShpStr"
    '        xlWs.Cells(1, 18) = "ShpEnd"
    '        xlWs.Cells(1, 19) = "compName"


    '        For col As Integer = 9 To rs_MSR00032.Tables("RESULT").Columns.Count - 1
    '            For row As Integer = 0 To rs_MSR00032.Tables("RESULT").Rows.Count - 1
    '                xlWs.Cells(row + 1 + 1, col + 1 - 9) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(col)

    '            Next

    '        Next

    '        '        // Copy the values from a DataTable to an Excel Sheet (cell-by-cell)
    '        'for (int col = 0; col < dataTable.Columns.Count; col++)
    '        '{
    '        '    for (int row = 0; row < dataTable.Rows.Count; row++)
    '        '    {
    '        '        excelSheet.Cells[row + 1, col + 1] = 
    '        '                dataTable.Rows[row].ItemArray[col];
    '        '    }
    '        '}


    '        ' ''fldCount = rs_MSR00032.Tables("RESULT").Rows.Count

    '        ' ''For iCol = 1 To fldCount

    '        ' ''    ''Just input the names here

    '        ' ''    ''            xlWs.Cells(1, iCol).Value = rs_MSR00032.Fields(iCol - 1).Name
    '        ' ''    xlWs.Rows(1).Font.Bold = True
    '        ' ''    xlWs.Rows(1).Font.Size = 10
    '        ' ''    xlWs.Rows(1).Font.Underline = True
    '        ' ''Next

    '        ' ''If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then
    '        ' ''    xlWs.Cells(2, 1).CopyFromRecordset(rs_MSR00032)
    '        ' ''Else

    '        ' ''    MsgBox("This Option only works with EXCEL 2000 or 2002.", vbExclamation)
    '        ' ''    'recArray = rs_MSR00032.GetRows


    '        ' ''    Dim recArray(rs_MSR00032.Tables("RESULT").Rows.Count - 1, rs_MSR00032.Tables("RESULT").Columns.Count - 1) As String '(row,col)
    '        ' ''    For intRow As Integer = 0 To rs_MSR00032.Tables("RESULT").Rows.Count - 1
    '        ' ''        For intCol As Integer = 0 To rs_MSR00032.Tables("RESULT").Columns.Count - 1
    '        ' ''            recArray(intRow, intCol) = CStr(rs_MSR00032.Tables("RESULT").Rows(intRow).Item(intCol))
    '        ' ''        Next intCol
    '        ' ''    Next intRow


    '        ' ''    recCount = UBound(recArray, 2) + 1 '+ 1 since 0-based array
    '        ' ''    For iCol = 0 To fldCount - 1
    '        ' ''        For iRow = 0 To recCount - 1
    '        ' ''            If IsDate(recArray(iCol, iRow)) Then
    '        ' ''                recArray(iCol, iRow) = Format(recArray(iCol, iRow))
    '        ' ''            ElseIf IsArray(recArray(iCol, iRow)) Then
    '        ' ''                recArray(iCol, iRow) = "Array Field"
    '        ' ''            End If
    '        ' ''        Next iRow 'next record
    '        ' ''    Next iCol 'next field

    '        ' ''    xlWs.Cells(2, 1).resize(recCount, fldCount).Value = recArray

    '        ' ''End If

    '        xlApp.Selection.CurrentRegion.Columns.AutoFit()
    '        xlApp.Selection.CurrentRegion.rows.AutoFit()

    '        xlWs.Rows(1).RowHeight = 25

    '        rs_MSR00032 = Nothing


    '        xlWs = Nothing
    '        xlWb = Nothing
    '        xlApp = Nothing

    '        'With Screen
    '        '  Me.Move (.width - width) \ 2, (.Height - Height) \ 2
    '        'End With

    '        Cursor = Cursors.Default

    '        Exit Sub

    'Err_Handler:
    '        If Err.Number = -2147417851 Then
    '            Resume Next
    '        End If

    '        Cursor = Cursors.Default


    '        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    '        rs_MSR00032 = Nothing

    '        xlWs = Nothing
    '        xlWb = Nothing
    '        xlApp = Nothing


    '    End Sub




    Private Sub CmdExportExcel_Click()

        On Error GoTo Err_Handler

        Cursor = Cursors.WaitCursor

        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        '        Dim recArray As Object

        Dim fldCount As Integer
        Dim recCount As Long
        Dim iCol As Integer
        Dim iRow As Integer


        Dim HdrRow As Long
        Dim DtlRow As Long
        Dim i As Long
        Dim indexCol As Long
        Dim strCompany As String
        Dim strTitle As String

        Dim strItem As String
        Dim strColPck As String
        Dim strCust As String
        Dim strDocType As String

        indexCol = 1
        HdrRow = 8
        DtlRow = 10


        strCompany = txtCoNam.Text


        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True


        With xlWs

            'Report ID
            .Cells(1, 16) = "Report ID"
            .Cells(1, 17) = ":"
            .Cells(1, 18) = "MSR00032"

            'Date
            .Cells(2, 16) = "Date"
            .Cells(2, 17) = ":"
            .Cells(2, 18) = Format(Now, "MM/dd/yyyy")
            .Range(.Cells(2, 18), .Cells(2, 18)).NumberFormatLocal = "MM/dd/yyyy"
            'Time
            .Cells(3, 16) = "Time"
            .Cells(3, 17) = ":"
            .Cells(3, 18) = Format(Now, "HH:mm:ss")
            .Range(.Cells(3, 18), .Cells(3, 18)).NumberFormatLocal = "HH:mm:ss"
            'Page
            .Cells(4, 16) = "Page"
            .Cells(4, 17) = ":"
            .Cells(4, 18) = "1 of 1"

            .Range(.Cells(1, 18), .Cells(4, 18)).HorizontalAlignment = 2

        End With


        With xlWs



            'Item No.
            .Cells(4, 1) = "Item No."
            .Cells(4, 2) = ":"
            .Cells(4, 3) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromItmno") = "", "ALL", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromItmno"))
            .Cells(4, 4) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromItmno") = "", "", "-")
            .Cells(4, 5) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromItmno") = "", "", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_ToItmno"))



            'Vendor No.
            .Cells(5, 1) = "Vendor No."
            .Cells(5, 2) = ":"
            .Cells(5, 3) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromVenno") = "", "ALL", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromVenno"))
            .Cells(5, 4) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromVenno") = "", "", "-")
            .Cells(5, 5) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromVenno") = "", "", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_ToVenno"))



            'Sub Code
            .Cells(6, 1) = "Sub Code"
            .Cells(6, 2) = ":"
            .Cells(6, 3) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromSubcde") = "", "ALL", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromSubcde"))
            .Cells(6, 4) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromSubcde") = "", "", "-")
            .Cells(6, 5) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromSubcde") = "", "", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_ToSubcde"))



            'Customer No.
            .Cells(7, 1) = "Customer No"
            .Cells(7, 2) = ":"
            .Cells(7, 3) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromCusno") = "", "ALL", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromCusno"))
            .Cells(7, 4) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromCusno") = "", "", "-")
            .Cells(7, 5) = IIf(rs_MSR00032.Tables("RESULT").Rows(0).Item("input_FromCusno") = "", "", rs_MSR00032.Tables("RESULT").Rows(0).Item("input_ToCusno"))

            .Range(.Cells(1, indexCol), .Cells(7, indexCol + 19)).Font.Size = 8

            .Columns.ColumnWidth = 10

        End With


        With xlWs

            .Cells(HdrRow + 1, indexCol) = "Item NO."
            .Cells(HdrRow + 1, indexCol + 1) = "Color/Packing"
            .Cells(HdrRow + 1, indexCol + 3) = "Customer"
            .Cells(HdrRow + 1, indexCol + 5) = "Doc Type"
            .Cells(HdrRow + 1, indexCol + 6) = "Doc NO."
            .Cells(HdrRow + 1, indexCol + 7) = "Issue Date"
            .Cells(HdrRow + 1, indexCol + 8) = "Revise Date"
            .Cells(HdrRow + 1, indexCol + 9) = "Ship Start"
            .Cells(HdrRow + 1, indexCol + 10) = "Ship End"
            .Cells(HdrRow + 1, indexCol + 11) = "Vendor"
            .Cells(HdrRow + 1, indexCol + 13) = "Sub Code"

            .Cells(HdrRow, indexCol + 14) = "Smp."
            .Cells(HdrRow + 1, indexCol + 14) = "UM"

            .Cells(HdrRow, indexCol + 15) = "Order"
            .Cells(HdrRow + 1, indexCol + 15) = "Qty"

            .Cells(HdrRow, indexCol + 16) = "Shipped"
            .Cells(HdrRow + 1, indexCol + 16) = "Qty"

            .Cells(HdrRow, indexCol + 17) = "OS"
            .Cells(HdrRow + 1, indexCol + 17) = "Qty"


            .Range(.Cells(HdrRow, indexCol), .Cells(HdrRow, indexCol + 17)).Borders(3).LineStyle = 1
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 1, indexCol + 17)).Borders(4).LineStyle = 1

            xlWs.Rows(HdrRow).Font.Bold = True
            xlWs.Rows(HdrRow + 1).Font.Bold = True
            xlWs.Rows(HdrRow).Font.size = 9
            xlWs.Rows(HdrRow + 1).Font.size = 9
        End With


        strTitle = "Document List By Item"


        With xlWs

            .Range(.Cells(1, 5), .Cells(1, 14)).Merge()
            .Range(.Cells(1, 5), .Cells(1, 14)).Value = strCompany
            .Range(.Cells(1, 5), .Cells(1, 14)).Font.Size = 24


            .Range(.Cells(2, 6), .Cells(2, 13)).Merge()
            .Range(.Cells(2, 6), .Cells(2, 13)).Value = strTitle
            .Range(.Cells(2, 6), .Cells(2, 13)).Font.Size = 18

            .Range(.Cells(1, 5), .Cells(1, 14)).Font.Bold = True
            .Range(.Cells(1, 5), .Cells(2, 14)).HorizontalAlignment = 3

        End With


        'xlWs.Cells(1, 1) = "Itmno"
        'xlWs.Cells(1, 2) = "Colpck"
        'xlWs.Cells(1, 3) = "Type"
        'xlWs.Cells(1, 4) = "DOCType"
        'xlWs.Cells(1, 5) = "Cus1no"
        'xlWs.Cells(1, 6) = "Cussna_sort"
        'xlWs.Cells(1, 7) = "DocNo"
        'xlWs.Cells(1, 8) = "Cussna"
        'xlWs.Cells(1, 9) = "issdat"
        'xlWs.Cells(1, 10) = "rvsdat"
        'xlWs.Cells(1, 11) = "smpUM"
        'xlWs.Cells(1, 12) = "venno"
        'xlWs.Cells(1, 13) = "subcde"
        'xlWs.Cells(1, 14) = "OrderQty"
        'xlWs.Cells(1, 15) = "ShpQty"
        'xlWs.Cells(1, 16) = "OSQty"
        'xlWs.Cells(1, 17) = "ShpStr"
        'xlWs.Cells(1, 18) = "ShpEnd"
        'xlWs.Cells(1, 19) = "compName"


        '        For col As Integer =  To rs_MSR00032.Tables("RESULT").Columns.Count - 1
        For row As Integer = 0 To rs_MSR00032.Tables("RESULT").Rows.Count - 1
            If row > 0 Then

                If rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(9) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(9) Then
                    xlWs.Cells(row + 1 + 9, 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(9)
                End If

                If rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(10) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(10) _
                And rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(9) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(9) Then
                    xlWs.Cells(row + 1 + 9, 2) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 2) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(10)
                End If


                If rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(10) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(10) _
And rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(9) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(9) _
    And rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(16) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(16) Then

                    xlWs.Cells(row + 1 + 9, 3 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 3 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(16)
                End If




                If rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(10) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(10) _
And rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(9) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(9) _
    And rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(16) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(16) _
        And rs_MSR00032.Tables("RESULT").Rows(row - 1).ItemArray(12) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(12) Then
                    xlWs.Cells(row + 1 + 9, 4 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 4 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(12)
                End If


                xlWs.Cells(row + 1 + 9, 5 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(15)

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(17) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 6 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 6 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(17)
                End If

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(18) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 7 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 7 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(18)
                End If

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(25) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 8 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 8 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(25)
                End If

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(26) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 9 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 9 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(26)
                End If

                xlWs.Cells(row + 1 + 9, 10 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(20)
                xlWs.Cells(row + 1 + 9, 11 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(21)
                xlWs.Cells(row + 1 + 9, 12 + 3) = ""

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(12) = "QU" Then
                    xlWs.Cells(row + 1 + 9, 13 + 1 + 1 + 1) = ""
                    xlWs.Cells(row + 1 + 9, 14 + 1 + 1 + 1) = ""
                    xlWs.Cells(row + 1 + 9, 15 + 1 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 13 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(22)
                    xlWs.Cells(row + 1 + 9, 14 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(23)
                    xlWs.Cells(row + 1 + 9, 15 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(24)
                End If

            Else
                xlWs.Cells(row + 1 + 9, 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(9)
                xlWs.Cells(row + 1 + 9, 2) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(10)
                xlWs.Cells(row + 1 + 9, 3 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(16)
                xlWs.Cells(row + 1 + 9, 4 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(12)

                xlWs.Cells(row + 1 + 9, 5 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(15)
                'xlWs.Cells(row + 1 + 9, 6 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(17)
                'xlWs.Cells(row + 1 + 9, 7 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(18)
                'xlWs.Cells(row + 1 + 9, 8 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(25)
                'xlWs.Cells(row + 1 + 9, 9 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(26)


                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(17) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 6 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 6 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(17)
                End If

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(18) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 7 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 7 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(18)
                End If

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(25) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 8 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 8 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(25)
                End If

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(26) = "01/01/1900" Then
                    xlWs.Cells(row + 1 + 9, 9 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 9 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(26)
                End If


                xlWs.Cells(row + 1 + 9, 10 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(20)
                xlWs.Cells(row + 1 + 9, 11 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(21)
                xlWs.Cells(row + 1 + 9, 12 + 3) = ""

                If rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(12) = "QU" Then
                    xlWs.Cells(row + 1 + 9, 13 + 1 + 1 + 1) = ""
                    xlWs.Cells(row + 1 + 9, 14 + 1 + 1 + 1) = ""
                    xlWs.Cells(row + 1 + 9, 15 + 1 + 1 + 1) = ""
                Else
                    xlWs.Cells(row + 1 + 9, 13 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(22)
                    xlWs.Cells(row + 1 + 9, 14 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(23)
                    xlWs.Cells(row + 1 + 9, 15 + 1 + 1 + 1) = rs_MSR00032.Tables("RESULT").Rows(row).ItemArray(24)
                End If

            End If
        Next

        Dim last_line As Integer
        last_line = rs_MSR00032.Tables("RESULT").Rows.Count + 11

        With xlWs



            .Range(.Cells(last_line, 10), .Cells(last_line, 11)).Merge()
            .Range(.Cells(last_line, 10), .Cells(last_line, 11)).Value = "~ End ~"
            .Range(.Cells(last_line, 10), .Cells(last_line, 11)).Font.Size = 9

            .Range(.Cells(10, 1), .Cells(last_line - 1, 26)).Font.Size = 8
            .Range(.Cells(10, 1), .Cells(last_line - 1, 26)).RowHeight = 15

            .Range("C7").NumberFormat = "@"
            .Range("E7").NumberFormat = "@"

            '            .Range(.Cells(7, 8), .Cells(last_line - 1, 11)).NumberFormat = "@"
            .Range(.Cells(7, 8), .Cells(last_line - 1, 11)).HorizontalAlignment = 2

            .Range(.Cells(7, 16), .Cells(last_line - 1, 18)).NumberFormat = "@"

        End With


        'Next

        '        // Copy the values from a DataTable to an Excel Sheet (cell-by-cell)
        'for (int col = 0; col < dataTable.Columns.Count; col++)
        '{
        '    for (int row = 0; row < dataTable.Rows.Count; row++)
        '    {
        '        excelSheet.Cells[row + 1, col + 1] = 
        '                dataTable.Rows[row].ItemArray[col];
        '    }
        '}


        ' ''fldCount = rs_MSR00032.Tables("RESULT").Rows.Count

        ' ''For iCol = 1 To fldCount

        ' ''    ''Just input the names here

        ' ''    ''            xlWs.Cells(1, iCol).Value = rs_MSR00032.Fields(iCol - 1).Name
        ' ''    xlWs.Rows(1).Font.Bold = True
        ' ''    xlWs.Rows(1).Font.Size = 10
        ' ''    xlWs.Rows(1).Font.Underline = True
        ' ''Next

        ' ''If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then
        ' ''    xlWs.Cells(2, 1).CopyFromRecordset(rs_MSR00032)
        ' ''Else

        ' ''    MsgBox("This Option only works with EXCEL 2000 or 2002.", vbExclamation)
        ' ''    'recArray = rs_MSR00032.GetRows


        ' ''    Dim recArray(rs_MSR00032.Tables("RESULT").Rows.Count - 1, rs_MSR00032.Tables("RESULT").Columns.Count - 1) As String '(row,col)
        ' ''    For intRow As Integer = 0 To rs_MSR00032.Tables("RESULT").Rows.Count - 1
        ' ''        For intCol As Integer = 0 To rs_MSR00032.Tables("RESULT").Columns.Count - 1
        ' ''            recArray(intRow, intCol) = CStr(rs_MSR00032.Tables("RESULT").Rows(intRow).Item(intCol))
        ' ''        Next intCol
        ' ''    Next intRow


        ' ''    recCount = UBound(recArray, 2) + 1 '+ 1 since 0-based array
        ' ''    For iCol = 0 To fldCount - 1
        ' ''        For iRow = 0 To recCount - 1
        ' ''            If IsDate(recArray(iCol, iRow)) Then
        ' ''                recArray(iCol, iRow) = Format(recArray(iCol, iRow))
        ' ''            ElseIf IsArray(recArray(iCol, iRow)) Then
        ' ''                recArray(iCol, iRow) = "Array Field"
        ' ''            End If
        ' ''        Next iRow 'next record
        ' ''    Next iCol 'next field

        ' ''    xlWs.Cells(2, 1).resize(recCount, fldCount).Value = recArray

        ' ''End If

        '        xlApp.Selection.CurrentRegion.Columns.AutoFit()
        '       xlApp.Selection.CurrentRegion.rows.AutoFit()

        '      xlApp.Worksheets("Sheet1").Columns("A:Z").AutoFit()

        '''20130214
        'xlWs.Columns("A:A").AutoFit()
        'xlWs.Columns("C:C").AutoFit()
        'xlWs.Columns("E:K").AutoFit()
        'xlWs.Columns("M:Z").AutoFit()

        '   xlWs.Rows(1).RowHeight = 25
        '        xlWs.Columns("A:Z").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("B").ColumnWidth = 10.13
        ''xlWs.Columns("C").ColumnWidth = 10.13
        ''xlWs.Columns("D").ColumnWidth = 10.13
        ''xlWs.Columns("E").ColumnWidth = 10.13
        ''xlWs.Columns("F").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13
        ''xlWs.Columns("A").ColumnWidth = 10.13



        rs_MSR00032 = Nothing


        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        'With Screen
        '  Me.Move (.width - width) \ 2, (.Height - Height) \ 2
        'End With

        Cursor = Cursors.Default

        Exit Sub

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If

        Cursor = Cursors.Default


        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        rs_MSR00032 = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub


    Private Sub fillcboPriCust()

        Dim dr() As DataRow
        '        If addFlag = True Then

        rs_CUBASINF_P.Tables("RESULT").DefaultView.Sort = "cbi_cusno"

        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        'Else
        'dr = rs_CUBASINF_P.Tables("RESULT").Select("")
        'End If

        If dr.Length > 0 Then
            cboCUFm.Items.Clear()
            cboCUTo.Items.Clear()

            For i As Integer = 0 To dr.Length - 1
                cboCUFm.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
                cboCUTo.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If

        cboCUFm.SelectedIndex = 0
        cboCUTo.SelectedIndex = cboCUTo.Items.Count - 1
    End Sub

    Private Sub cboVenFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFm.KeyUp
        Call auto_search_combo(cboVenFm, e.KeyCode)

    End Sub

    Private Sub cboVenFm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenFm.LostFocus
        cboVenTo.Text = cboVenFm.Text
        cboVenTo.Focus()
        cboVenTo.SelectAll()

    End Sub


    Private Sub cboVenFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenFm.SelectedIndexChanged

    End Sub

    Private Sub cboVenTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenTo.GotFocus
        cboVenTo.SelectAll()

    End Sub

    Private Sub cboVenTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp
        Call auto_search_combo(cboVenTo, e.KeyCode)

    End Sub

    Private Sub cboVenTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenTo.SelectedIndexChanged

    End Sub

    Private Sub cboCUFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCUFm.KeyUp
        Call auto_search_combo(cboCUFm, e.KeyCode)

    End Sub

    Private Sub cboCUFm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCUFm.LostFocus
        cboCUTo.Text = cboCUFm.Text
        cboCUFm.Focus()
        cboCUFm.SelectAll()

    End Sub

    Private Sub cboCUFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCUFm.SelectedIndexChanged

    End Sub

    Private Sub cboCUTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCUTo.GotFocus
        cboCUTo.Focus()
        cboCUTo.SelectAll()

    End Sub

    Private Sub cboCUTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCUTo.KeyUp
        Call auto_search_combo(cboCUTo, e.KeyCode)

    End Sub

    Private Sub cboCUTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCUTo.SelectedIndexChanged

    End Sub

    Private Sub txtCoNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoNam.TextChanged

    End Sub
End Class