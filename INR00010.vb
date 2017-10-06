Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class INR00010
    '*** Program ID     :SCR00002
    '*** Author         :Kenny Chan
    '*** Creation Date  :19-12-2001
    '*** Description    :SC
    '*** Logic          :
    '***
    '************************************************************************************************************************
    '*** Modification History
    '************************************************************************************************************************
    '*** Modified by        Modified on         Description
    '************************************************************************************************************************
    '*** Lester Wu          30th Mar, 2005      replace ALL with UC-G, not show UC-G for MS company's users
    '***                                        show MS company data in a separate report
    '*** Lester Wu          2nd Dec, 2005       Error when output data to excel
    '************************************************************************************************************************


    '    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As DataSet
    Public rs_SYCATCDE As DataSet

    Private rs_EXCEL As DataSet

    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        'Lester Wu 2005-03-30, replace ALL with UC-G
        'If cboCocde.Text <> "ALL" Then
        If cboCocde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
    End Sub

    Private Sub ChkALL_Click()
        Dim ii As Integer
        If ChkALL.Checked = True Then
            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SelectedItems(ii) = True
            Next
        Else
            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SelectedItems(ii) = False
            Next
        End If
    End Sub


    Private Sub lstVendorFrom_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(lstVendorFrom, KeyCode)
    End Sub

    Private Sub lstVendorFrom_LostFocus()
        'Call ValidateCombo(lstVendorFrom)
    End Sub
    Private Sub cboSCFm_Click()
        cboSCTo.Text = cboSCFm.Text
    End Sub
    Private Sub cboSCFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSCFm, KeyCode)
    End Sub
    Private Sub cboSCFm_LostFocus()
        Call ValidateCombo(cboSCFm)
        cboSCTo.Text = cboSCFm.Text
    End Sub
    Private Sub cboSCTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSCTo, KeyCode)
    End Sub
    Private Sub cboSCTo_LostFocus()
        Call ValidateCombo(cboSCTo)
    End Sub

    Private Sub cboCatlevel_Fm_Click()
        cboCatlevel_To.Text = cboCatlevel_Fm.Text
    End Sub
    Private Sub cboCatlevel_click()

        Dim S As String
        Dim rs As DataSet

        Cursor = Cursors.WaitCursor

        S = "sp_list_SYCATCDE_MSR00015   '','" + GetCtrlValue(cboCatlevel) + "','" + gsUsrID & "'"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillCatLevel()
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default


    End Sub

    Private Sub cboCatlevel_Fm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCatlevel_Fm, KeyCode)
        cboCatlevel_To.Text = cboCatlevel_Fm.Text
    End Sub
    Private Sub cboCatlevel_Fm_LostFocus()
        Call ValidateCombo(cboCatlevel_Fm)
    End Sub

    Private Sub cboCatlevel_To_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCatlevel_To, KeyCode)

    End Sub

    Private Sub cboCatlevel_To_LostFocus()
        Call ValidateCombo(cboCatlevel_To)
    End Sub

    Private Sub cmdShow_Click()
        If (txtDateFrom.Text = "  /  /" Or txtDateTo.Text = "  /  /") Then
            MsgBox("Please input Date!")
            Exit Sub
        End If

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------


        Dim S As String
        Dim rs As DataSet
        Dim ReportName As String
        Dim ReportRS As DataSet
        Dim DateFrom As Date
        Dim DateTo As Date
        Dim i As Integer
        Dim Z As Integer
        Dim j As Integer

        Dim rs_Temp As New DataSet
        Dim rs_Date As New DataSet

        Dim VendorString As String
        Dim VendorString_Lable As String

        Dim rpttyp As String

        Dim Arr(1000) As String

        'If cboSCFm.Text = "" And cboSCTo.Text = "" Then
        '    cboSCFm.selectedIndex = 0
        '    cboSCTo.selectedIndex = cboSCTo.Items.Count - 1
        'End If

        If Not IsDate(txtDateFrom.Text) Then
            MsgBox("Date is Invalid !")
            txtDateFrom.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDateTo.Text) Then
            MsgBox("Date is Invalid !")
            txtDateTo.Focus()
            Exit Sub
        End If

        If cboCatlevel_Fm.Text = "" And cboCatlevel_To.Text <> "" Then
            cboCatlevel_To.Text = cboCatlevel_Fm.Text
        End If

        If Not InputIsVaild() Then
            Exit Sub
        End If



        For i = 0 To lstVendorFrom.Items.Count - 1
            VendorString = VendorString + Split(lstVendorFrom.Items(i), " - ")(0) & ","
            VendorString_Lable = VendorString_Lable & lstVendorFrom.Items(i) & IIf((i + 1) Mod 2 = 0, Chr(13) & Chr(10), StrDup(Math.Abs(20 - Len(lstVendorFrom.Items(i))), " "))
        Next

        'For i = 0 To lstVendorFrom.Items.Count - 1
        '    For i2 As Integer = 0 To lstVendorFrom.SelectedItems.Count - 1
        '        If lstVendorFrom.Items(i) = lstVendorFrom.SelectedItems(i2) Then
        '            VendorString = VendorString + Split(lstVendorFrom.Items(i), " - ")(0) & ","
        '            VendorString_Lable = VendorString_Lable & lstVendorFrom.Items(i) & IIf((i + 1) Mod 2 = 0, Chr(13) & Chr(10), StrDup(Math.Abs(20 - Len(lstVendorFrom.Items(i))), " "))
        '        End If
        '    Next
        'Next
        If VendorString = "" Then
            MsgBox("No Vendor selected")
            Exit Sub
        End If
        VendorString = Microsoft.VisualBasic.Left(VendorString, Len(VendorString) - 1)

        If ChkALL.Checked = True Then
            VendorString_Lable = "ALL Vendors"
        End If

        DateFrom = CDate(txtDateFrom.Text)
        DateTo = CDate(txtDateTo.Text)

        If opt2w.Checked = True Then
            rpttyp = "2"
        ElseIf opt4w.Checked = True Then
            rpttyp = "4"
        Else
            rpttyp = "1"
        End If

        'Lester Wu 2005-12-02, pass empty VendorString instead of a long and rebust string
        '    S = "sp_select_INR00010','S','" & VendorString & _
        '        "','" & VendorString_Lable & _
        '        "','" & cboSCFm.Text & _
        '        "','" & cboSCTo.Text & _
        '        "','" & GetCtrlValue(cboCatlevel) & _
        '        "','" & GetCtrlValue(cboCatlevel_Fm) & _
        '        "','" & GetCtrlValue(cboCatlevel_To) & _
        '        "','" & DateFrom + " 00:00:00" & _
        '        "','" & DateTo + " 23:59:59"
        S = "sp_select_INR00010   '" & cboCocde.Text.Trim() & "'  ,'" & _
                "','" & VendorString_Lable & _
                "','" & cboSCFm.Text & _
                "','" & cboSCTo.Text & _
                "','" & GetCtrlValue(cboCatlevel) & _
                "','" & GetCtrlValue(cboCatlevel_Fm) & _
                "','" & GetCtrlValue(cboCatlevel_To) & _
                "','" & DateFrom + " 00:00:00" & _
                "','" & DateTo + " 23:59:59" & _
                "','" & rpttyp & "'"

        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        End If

        '        rs = objBSGate.Enquire(gsConnStrRpt, "sp_general", S)
        '    rs_Date.Delete
        '*****************
        'Generate report
        '*****************
        'Lester Wu 2005-12-02, add error checking for the result set receive
        'Dim ReportName(0 To 1) As String
        'ReDim ReportRS(0 To 1) As Dataset
        If Me.cboCocde.Text = "MS" Then
            rs_Date = rs.Copy

            Dim objRpt As New INR00010_MS
            objRpt.SetDataSource(rs_Date.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            'ReportName = "INR00010_MS.rpt"
            'ReportRS = rs_Date
            'frmReport.Show()

        Else
            rs_EXCEL = rs.Copy

            Call ExportToExcel_UC()
            'ReportName = "INR00010.rpt"
        End If
        '                Set ReportRS = rs_Date
        'ReportName(1) = "subreport00004"
        'Set ReportRS(1) = rs_QUR0000A
        '                frmReport.Show

        Cursor = Cursors.Default
    End Sub
    Private Function InputIsVaild() As Boolean
        'If lstVendorFrom.Text = "" And cboVendorTo.Text = "" Then
        '    lstVendorFrom.selectedIndex = 0
        '    cboVendorTo.selectedIndex = cboVendorTo.Items.Count - 1
        'End If

        'If lstVendorFrom.Text = "" Then
        '   Msg .Tables("RESULT").Rows(index)("M00414")
        '    InputIsVaild = False
        '    lstVendorFrom.SetFocus
        '    Exit Function
        'End If

        'If cboVendorTo.Text = "" Then
        '    Msg .Tables("RESULT").Rows(index)("M00414")
        '    InputIsVaild = False
        '    cboVendorTo.SetFocus
        '    Exit Function
        'End If

        If cboSCTo.Text < cboSCFm.Text Then
            MsgBox("Sub-Code No. To must >= Sub-Code No. From", vbExclamation, "Error")
            InputIsVaild = False
            cboSCTo.Focus()
            Exit Function
        End If

        If CDate(txtDateFrom.Text) > CDate(Me.txtDateTo.Text) Then
            MsgBox("Start Date > End Date")
            InputIsVaild = False
            txtDateFrom.Focus()
            Exit Function
        End If

        InputIsVaild = True
    End Function
    Private Sub Form_Load()
        '#If useMTS Then
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        Cursor = Cursors.WaitCursor

        '*************Default****************
        '*** Multi-Company Name Display.
        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(Me.cboCocde, Me.txtCoNam)

        If gsDefaultCompany <> "MS" Then
            '*** Add print all company ***
            'Lester Wu 2005-03-30, replace ALL with UC-G
            'cboCocde.Items.add "ALL"
            cboCocde.Items.Add("UC-G")
            '*****************************
        End If

        Call Formstartup(Me.Name)
        txtDateFrom.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        txtDateTo.Text = Format(Date.Today, "MM/dd/yyyy").ToString

        Dim S As String
        Dim rs As DataSet

        S = "sp_list_VNBASINF '' "

        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_VNBASINF   :" & rtnStr)
        Else
            Call FillcboVendor()
        End If


        S = "sp_select_SUBCDE  '' "

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboSC()
        End If


        cboCatlevel.Items.Clear()
        cboCatlevel.Items.Add("0 - Category 0")
        cboCatlevel.Items.Add("1 - Category 1")
        cboCatlevel.Items.Add("2 - Category 2")
        cboCatlevel.Items.Add("3 - Category 3")
        cboCatlevel.Items.Add("4 - Category 4")
        cboCatlevel.SelectedIndex = 0
        Cursor = Cursors.Default

        '*** Hard Code Select all vendor
        Dim ii As Integer
        If ChkALL.Checked = True Then
            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SetSelected(ii, True)
            Next
        Else
            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SetSelected(ii, False)
            Next
        End If
        lstVendorFrom.Enabled = False
        ChkALL.Enabled = False


    End Sub

    Private Sub FillcboVendor()
        '------------------------------------------------------------------
        'Show factory 0002 and K for MS company
        If gsDefaultCompany = "MS" Then
            If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
                rs_VNBASINF.Tables("RESULT").DefaultView.RowFilter = "vbi_venno = '0002' or vbi_venno = 'K'"
            End If
        End If
        '------------------------------------------------------------------
        If rs_VNBASINF.Tables("RESULT").DefaultView.Count > 0 Then

            With rs_VNBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    lstVendorFrom.Items.Add(rs_VNBASINF.Tables("RESULT").DefaultView(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").DefaultView(index)("vbi_vensna"))
                Next
            End With

        End If
    End Sub
    Private Sub FillcboSC()
        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then
            With rs_SYSETINF
                For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                    cboSCFm.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                    cboSCTo.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                Next
            End With
        End If
    End Sub
    Private Sub FillCatLevel()
        cboCatlevel_Fm.Items.Clear()
        cboCatlevel_To.Items.Clear()
        cboCatlevel_Fm.Text = ""
        cboCatlevel_To.Text = ""

        If rs_SYCATCDE.Tables("RESULT").Rows.Count > 0 Then
            With rs_SYCATCDE
                For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                    cboCatlevel_Fm.Items.Add(rs_SYCATCDE.Tables("RESULT").Rows(index)("ycc_catcde"))
                    cboCatlevel_To.Items.Add(rs_SYCATCDE.Tables("RESULT").Rows(index)("ycc_catcde"))
                Next
            End With

        End If
    End Sub

    Private Sub lstVendorFrom_MouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
        'If lstVendorFrom.Selected(lstVendorFrom.SelectedIndex) = False Then
        '    ChkALL.Checked = False
        'End If
    End Sub

    Private Sub txtDateFrom_GotFocus()
        Call HighlightMask(txtDateFrom)
    End Sub

    Private Sub txtDateFrom_LostFocus()
        If Not IsDate(txtDateFrom.Text) Then
            MsgBox("Date is Invalid !")
            txtDateFrom.Focus()
        End If

    End Sub
    Private Sub txtDateTo_GotFocus()
        Call HighlightMask(txtDateTo)
    End Sub

    Private Sub txtDateTo_LostFocus()
        If Not IsDate(txtDateTo.Text) Then
            MsgBox("Date is Invalid !")
            txtDateTo.Focus()
        End If
    End Sub
    'Private Function GetCtrlValue(ByVal Ctrl As Control) As String
    '    If TypeOf Ctrl Is ComboBox Then
    '        If Ctrl.Text <> "" Then
    '            If UBound(Split(Ctrl.Text, " - ")) > 0 Then
    '                GetCtrlValue = Split(Ctrl.Text, " - ")(0)
    '            Else
    '                GetCtrlValue = Ctrl.Text
    '            End If
    '        Else
    '            GetCtrlValue = ""
    '        End If

    '    ElseIf TypeOf Ctrl Is ListBox Then

    '        If Ctrl.List(Ctrl.selectedIndex) <> "" Then
    '            If UBound(Split(Ctrl.List(Ctrl.selectedIndex), " - ")) > 0 Then
    '                GetCtrlValue = Split(Ctrl.List(Ctrl.selectedIndex), " - ")(0)
    '            Else
    '                GetCtrlValue = Ctrl.List(Ctrl.selectedIndex)
    '            End If
    '        Else
    '            GetCtrlValue = ""
    '        End If
    '    End If
    'End Function

    Private Function GetCtrlValue(ByVal Ctrl As Control) As String
        If TypeOf Ctrl Is ComboBox Then
            If Ctrl.Text <> "" Then
                If UBound(Split(Ctrl.Text, " - ")) > 0 Then
                    GetCtrlValue = Split(Ctrl.Text, " - ")(0)
                Else
                    GetCtrlValue = Ctrl.Text
                End If
            Else
                GetCtrlValue = ""
            End If
        ElseIf TypeOf Ctrl Is ListBox Then
            'tempzz,
            If Trim(Ctrl.Text) <> "" Then
                If UBound(Split(Ctrl.Text, " - ")) > 0 Then
                    GetCtrlValue = Split(Ctrl.Text, " - ")(0)
                Else
                    GetCtrlValue = Ctrl.Text
                End If
            Else
                GetCtrlValue = ""
            End If
        End If
    End Function

    Private Sub ExportToExcel_UC()

        On Error GoTo Err_Handler

        Cursor = Cursors.WaitCursor ' Change mouse pointer to hourglass.
        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        Dim recArray As Object
        Dim lngRecCount As Long

        Dim fldCount As Integer
        Dim recCount As Long

        Dim iCol As Long
        Dim iRow As Long

        Dim rowHeader As Long
        Dim rowContent As Long


        rowHeader = 1
        rowContent = 7
        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        lngRecCount = rs_EXCEL.Tables("RESULT").Rows.Count + rowContent
        If lngRecCount > 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------


        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True


        recCount = rs_EXCEL.Tables("RESULT").Rows.Count

        ''        If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then
        'EXCEL 2000 or 2002: Use CopyFromRecordset
        ''xlWs.Cells(rowContent, 1).CopyFromRecordset(rs_EXCEL)
        ''       Else
        '        'EXCEL 97 or earlier: Use GetRows then copy array to Excel
        Dim tmp_i As Integer
        Dim tmp_j As Integer

        tmp_i = rs_EXCEL.Tables("result").Rows.Count
        tmp_j = rs_EXCEL.Tables("result").Columns.Count
        ReDim Preserve recArray(tmp_i, tmp_j)

        For index9 As Integer = 0 To tmp_i - 1
            For index99 As Integer = 0 To tmp_j - 1
                recArray(index9, index99) = rs_EXCEL.Tables("result").Rows(index9)(index99)
            Next
        Next
        'tempz

        '            recArray = rs_EXCEL.GetRows
        recCount = UBound(recArray, 1)
        '        recCount = UBound(recArray, 2) + 1
        For iCol = 0 To fldCount - 1
            For iRow = 0 To recCount - 1
                If IsDate(recArray(iCol, iRow)) Then
                    recArray(iCol, iRow) = Format(recArray(iCol, iRow))
                ElseIf IsArray(recArray(iCol, iRow)) Then
                    recArray(iCol, iRow) = "Array Field"
                End If
            Next iRow
        Next iCol

        xlWs.Cells(rowContent, 1) = recArray

        '''goto
        Dim tmp_str As String

        'tmp_str = "A" & CStr(rowContent) & ":" & "Z" & CStr(1)
        'xlApp.Range(tmp_str).Select()

        'xlWs.Cells(rowContent, 1).resize(recCount, fldCount).Value = recArray

        'With xlApp
        '    For index9 As Integer = 0 To tmp_i - 1
        '        For index99 As Integer = 0 To tmp_j - 1
        '            .Range(Chr(64 + index9) + index99.ToString).Value = recArray(index9, index99)
        '        Next
        '    Next
        'End With





        '        xlWs.Cells(rowContent, 1).resize(recCount, fldCount).Value = recArray


        '        xlWs.Cells(rowContent, 1).resize(recCount, fldCount).Value = recArray

        ''     End If

        Dim iStart As Integer
        Dim iLen As Integer
        Dim strCocde As String

        iStart = IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(0)("cntStart")), 0, rs_EXCEL.Tables("RESULT").Rows(0)("cntStart"))
        iLen = IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(0)("cntCount")), 0, rs_EXCEL.Tables("RESULT").Rows(0)("cntCount"))

        With xlWs

            For index9 As Integer = 0 To tmp_i - 1
                For index99 As Integer = 2 To tmp_j - 1
                    '                    .Range(Chr(64 + index9) + index99.ToString).Value = recArray(index9, index99)
                    .Cells(rowContent + index9, index99 + 1) = recArray(index9, index99)

                Next
            Next

            .Range(.Cells(rowContent, iStart + (2 * iLen)), .Cells(rowContent + recCount, iStart + (2 * iLen) + 2)).Delete(-4159)
            .Range(.Cells(rowContent, 3), .Cells(rowContent + recCount, iStart + iLen - 1)).Delete(-4159)

            .Range(.Cells(rowContent - 1, 1), .Cells(rowContent - 1, 2)).Merge()

            .Cells(rowContent - 1, 1) = "PRODUCTION PERIOD"
            ''            .Range(.Cells(rowContent - 1, 1), .Cells(rowContent - 1, 2)) = "PRODUCTION PERIOD"
            'DateFrom
            'DateTo
            Dim index
            index = 0

            If rs_EXCEL.Tables("RESULT").Rows.Count > 0 Then

                'Header Content
                .Range(.Cells(1, 1), .Cells(1, 5)).Merge()
                .Cells(1, 1) = rs_EXCEL.Tables("RESULT").Rows(index)("compName")
                '                    .Range(.Cells(1, 1), .Cells(1, 5)) = rs_EXCEL.Tables("RESULT").Rows(index)("compName")

                .Range(.Cells(1, 1), .Cells(1, 5)).Font.Bold = True

                .Cells(1, iLen + 1) = "Report ID  : "
                .Cells(1, iLen + 2) = "INR00010"

                .Range(.Cells(2, 1), .Cells(2, 5)).Merge()
                .Cells(2, 1) = "CBM ORDERED REPORT (Factory Shipdate)"
                .Range(.Cells(2, 1), .Cells(2, 5)).Font.Bold = True

                .Range(.Cells(4, 1), .Cells(4, 5)).Merge()
                .Cells(4, 1) = "Date Range : " & Format(rs_EXCEL.Tables("RESULT").Rows(index)("Select_Date_Fm"), "MM/dd/yyyy") & " - " & Format(rs_EXCEL.Tables("RESULT").Rows(index)("Select_Date_To"), "MM/dd/yyyy")
                .Range(.Cells(4, 1), .Cells(4, 5)).Font.Bold = True

                strCocde = rs_EXCEL.Tables("RESULT").Rows(index)("cocde")
                'Column Header
                For iCol = 0 To iLen - 1
                    .Cells(rowContent - 1, iCol + 3) = rs_EXCEL.Tables("RESULT").Rows(index)(CInt(iStart + iCol - 1)).ToString
                    'tempzzz

                Next iCol
                'Production Period
                iRow = 0
                For index = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    .Cells(rowContent + iRow, 1) = ""
                    .Range(.Cells(rowContent + iRow, 1), .Cells(rowContent + iRow, 2)).Merge()
                    .Cells(rowContent + iRow, 1) = Format(rs_EXCEL.Tables("RESULT").Rows(index)("DateFrom"), "MM/dd/yyyy") & " - " & Format(rs_EXCEL.Tables("RESULT").Rows(index)("DateTo"), "MM/dd/yyyy")
                    iRow = iRow + 1
                Next
            End If

            .Range(.Cells(rowContent - 1, 1), .Cells(rowContent - 1, iLen + 2)).Font.Bold = True

            .Range(.Cells(rowContent - 1, 1), .Cells(rowContent - 1, iLen + 2)).Borders(8).Weight = 4
            .Range(.Cells(rowContent - 1, 1), .Cells(rowContent - 1, iLen + 2)).Borders(9).Weight = 4

            .Range(.Cells(rowContent - 1, 1), .Cells(recCount + rowContent, 2)).HorizontalAlignment = -4131
            .Range(.Cells(rowContent - 1, 3), .Cells(recCount + rowContent, iLen + 2)).HorizontalAlignment = -4152

            .Range(.Cells(rowContent + recCount, 3), .Cells(rowContent + recCount, iLen + 2)).Borders(8).Weight = 4
            .Range(.Cells(rowContent + recCount, 3), .Cells(rowContent + recCount, iLen + 2)).Borders(9).Weight = 4

            For iCol = 3 To iLen + 2
                .Range(.Cells(rowContent + recCount + 1, iCol), .Cells(rowContent + recCount + 1, iCol)).FormulaR1C1 = "=SUM(R[-" & recCount + 1 & "]C:R[-2]C)"
                .Range(.Cells(rowContent + recCount, iCol), .Cells(rowContent + recCount, iCol)).Value = .Range(.Cells(rowContent + recCount + 1, iCol), .Cells(rowContent + recCount + 1, iCol)).Value
            Next iCol

            .Range(.Cells(rowContent + recCount + 1, 3), .Cells(rowContent + recCount + 1, iLen + 2)).EntireRow.Delete()
            .Cells(rowContent + recCount, 1) = ""
            .Range(.Cells(rowContent + recCount, 1), .Cells(rowContent + recCount, 2)).Merge()
            .Cells(rowContent + recCount, 1) = "Total CBM : "


            .Cells(rowContent + recCount + 2, 1) = ""
            .Range(.Cells(rowContent + recCount + 2, 1), .Cells(rowContent + recCount + 2, 10)).Merge()
            .Cells(rowContent + recCount + 2, 1) = "Remark : All figures are based on the order carton and shipping start-date from Purchase Order."

            If strCocde = "UC-G" Then
                .Cells(rowContent + recCount + 3, 1) = ""
                .Range(.Cells(rowContent + recCount + 3, 1), .Cells(rowContent + recCount + 3, 10)).Merge()
                .Cells(rowContent + recCount + 3, 1) = "* United Chinese Group including ""UCP/UCPP/PG/EW/TT/HB/HX/HH/GU"" company data"
            End If

            .Range(.Cells(1, 1), .Cells(rowContent + recCount + 3, iLen + 2)).Columns.ColumnWidth = 10
            .Range(.Cells(1, 1), .Cells(rowContent + recCount + 3, iLen + 2)).Columns.Font.Size = 10
            '        .rows(rowHeader).RowHeight = 25

        End With

        'xlApp.selection.CurrentRegion.Columns.AutoFit




        Dim lngPages As Long


        lngPages = recCount / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If

        With xlWs.PageSetup
            .Zoom = False
            .TopMargin = 10
            .LeftMargin = 0.2
            .RightMargin = 0.2
            .FitToPagesWide = 1
            .FitToPagesTall = lngPages
            .Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape
        End With

        rs_EXCEL = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        Cursor = Cursors.Default ' Return mouse pointer to normal.

        Exit Sub
Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Cursor = Cursors.Default ' Return mouse pointer to normal.
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub


    Private Sub INR00010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        Call cmdShow_Click()

    End Sub

    Private Sub cboSCFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSCFm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSCFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCFm.LostFocus
        cboSCTo.Text = cboSCFm.Text

    End Sub

    Private Sub cboSCFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCFm.SelectedIndexChanged

    End Sub

    Private Sub cboSCTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSCTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSCTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCTo.LostFocus


    End Sub

    Private Sub cboSCTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCTo.SelectedIndexChanged

    End Sub

    Private Sub cboCatlevel_Fm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCatlevel_Fm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCatlevel_Fm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCatlevel_Fm.LostFocus
        'Call ValidateCombo(cboCatlevel_Fm)

    End Sub

    Private Sub cboCatlevel_Fm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel_Fm.SelectedIndexChanged
        cboCatlevel_To.Text = cboCatlevel_Fm.Text

    End Sub

    Private Sub cboCatlevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel.SelectedIndexChanged
        Call cboCatlevel_click()

    End Sub

    Private Sub cboCatlevel_To_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCatlevel_To.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCatlevel_To_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCatlevel_To.LostFocus
        'Call ValidateCombo(cboCatlevel_To)


    End Sub

    Private Sub cboCatlevel_To_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel_To.SelectedIndexChanged

    End Sub

    Private Sub lstVendorFrom_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstVendorFrom.MouseUp
        If lstVendorFrom.Items.Count <> lstVendorFrom.SelectedItems.Count Then
            ChkALL.Checked = False
        End If
    End Sub

    Private Sub lstVendorFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVendorFrom.SelectedIndexChanged

    End Sub

    Private Sub txtDateFrom_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.GotFocus
        Call HighlightMask(txtDateFrom)

    End Sub

    Private Sub txtDateFrom_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.LostFocus
        If Not IsDate(txtDateFrom.Text) Then
            MsgBox("Date is Invalid !")
            txtDateFrom.Focus()
        End If

    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub txtDateTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateTo.GotFocus
        Call HighlightMask(txtDateTo)

    End Sub

    Private Sub txtDateTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateTo.LostFocus
        If Not IsDate(txtDateTo.Text) Then
            MsgBox("Date is Invalid !")
            txtDateTo.Focus()
        End If

    End Sub

    Private Sub txtDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateTo.MaskInputRejected

    End Sub

    Private Sub ChkALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkALL.CheckedChanged

    End Sub

    Private Sub ChkALL_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkALL.Click
        ChkALL_Click()
    End Sub

    Private Sub cboSCFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSCFm.Validating
        If ValidateCombo(cboSCFm) <> True Then
            cboSCFm.Focus()
        End If

    End Sub

    Private Sub cboSCTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSCTo.Validating
        If ValidateCombo(cboSCTo) <> True Then
            cboSCTo.Focus()
        End If
    End Sub

    Private Sub cboCatlevel_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCatlevel_Fm.Validating
        If ValidateCombo(cboCatlevel_Fm) <> True Then
            cboCatlevel_Fm.Focus()
        End If

    End Sub

    Private Sub cboCatlevel_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCatlevel_To.Validating
        If ValidateCombo(cboCatlevel_To) <> True Then
            cboCatlevel_To.Focus()
        End If

    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If

    End Sub
End Class