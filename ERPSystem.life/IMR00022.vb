Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMR00022

    Dim rs_IMR00022 As DataSet
    Dim rs_CUBASINF As DataSet
    Public dr() As DataRow
    Dim myExcel As Excel.Application


    Private Sub cboCustFm_Click()
        'Me.cboCustTo.Text = Me.cboCustFm.Text
    End Sub

    Private Sub cboCustFm_GotFocus()
        'Call hightCombo(Me.cboCustFm)
    End Sub

    Function hightCombo(ByVal cbo As ComboBox)
        'cbo.selStart = 0
        'cbo.SelLength = Len(cbo.Text)
    End Function
    Private Sub cboCustFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCustFm, KeyCode)
    End Sub

    'Private Sub cboCustFm_LostFocus()
    '    If ValidateCombo(cboCustFm) = True Then
    '        cboCustTo.Text = cboCustFm.Text
    '    End If
    'End Sub

    'Private Sub cboCustTo_GotFocus()
    '    Call hightCombo(Me.cboCustTo)
    'End Sub

    'Private Sub cboCustTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
    '    Call AutoSearch(cboCustTo, KeyCode)
    'End Sub

    'Private Sub cboCustTo_LostFocus()
    '    Call ValidateCombo(cboCustTo)
    'End Sub

    Private Sub cmdItemList_Click()
        'frmItemList.strItem = txtItemList.Text
        'frmItemList.Show(vbModal)
        'txtItemList.Text = frmItemList.strSel
    End Sub

    Private Sub cmdItemLstCust_Click()
        'frmItemList.strItem = txtCustAls.Text
        'frmItemList.Show(vbModal)
        'txtCustAls.Text = frmItemList.strSel
    End Sub

    Private Sub cmdShow_Click()

        '    Dim bolHaveValue As Boolean

        '    Dim S As String
        '    Dim rs() As ADOR.Recordset
        'ReDim ReportName(0) As String
        'ReDim ReportRS(0) As ADOR.Recordset
        '    Dim intItemCount As Integer
        '    Dim intReturn As Integer
        '    Dim i As Integer
        '    Dim itemlst As String
        '    Dim aliaslst As String
        '    Dim strcustfm As String
        '    Dim strcsutto As String
        '    Dim strSort As String


        '    bolHaveValue = False
        '    If Len(Trim(Me.txtItemList.Text)) > 0 Then bolHaveValue = True
        '    If Len(Trim(Me.txtCustAls.Text)) > 0 Then bolHaveValue = True
        '    If Len(Trim(Me.cboCustFm.Text)) > 0 Then bolHaveValue = True
        '    If Len(Trim(Me.cboCustTo.Text)) > 0 Then bolHaveValue = True

        '    If bolHaveValue = False Then
        '        Exit Sub
        '    End If

        '    If Trim(Me.cboCustFm.Text) > Trim(Me.cboCustTo.Text) Then
        '        MsgBox("Primary Customer From > To")
        '        Me.cboCustFm.SetFocus()
        '        Exit Sub
        '    End If


        '    intItemCount = 0
        '    itemlst = Me.txtItemList.Text
        '    If InStr(Me.txtItemList.Text, ",") > 0 Then
        '        intItemCount = UBound(Split(Me.txtItemList.Text, ","))
        '        If intItemCount > 50 Then
        '            intReturn = MsgBox("Number of Items is over 50" & vbCrLf & "Only the first 50 items will be processed.", vbOKCancel + vbQuestion)
        '            If intReturn = vbCancel Then Exit Sub
        '            For i = 0 To 49
        '                itemlst = itemlst & Trim(Split(Me.txtItemList.Text, ",")(i)) & ","
        '            Next i
        '            itemlst = Left(itemlst, Len(itemlst) - 1)
        '        End If
        '    End If

        '    intItemCount = 0
        '    aliaslst = Me.txtCustAls.Text
        '    If InStr(Me.txtCustAls.Text, ",") > 0 Then
        '        intItemCount = UBound(Split(Me.txtCustAls.Text, ","))
        '        If intItemCount > 50 Then
        '            intReturn = MsgBox("Number of Customer Alias Items is over 50" & vbCrLf & "Only the first 50 items will be processed.", vbOKCancel + vbQuestion)
        '            If intReturn = vbCancel Then Exit Sub
        '            For i = 0 To 49
        '                aliaslst = aliaslst & Trim(Split(Me.txtCustAls.Text, ",")(i)) & ","
        '            Next i
        '            aliaslst = Left(aliaslst, Len(aliaslst) - 1)
        '        End If
        '    End If

        '    If InStr(Me.cboCustFm.Text, "-") > 1 Then
        '        strcustfm = Trim(Split(Me.cboCustFm.Text, "-")(0))
        '    Else
        '        strcustfm = Trim(Me.cboCustFm.Text)
        '    End If

        '    If InStr(Me.cboCustTo.Text, "-") > 1 Then
        '        strcustto = Trim(Split(Me.cboCustTo.Text, "-")(0))
        '    Else
        '        strcustto = Trim(Me.cboCustTo.Text)
        '    End If

        '    strSort = "ITM"
        '    If Me.optCust.Value = True Then strSort = "CUS"
        '    If Me.optAls.Value = True Then strSort = "ALS"


        '    S = "㊣IMR00022※L※" + Trim(Me.txtItemList.Text) + _
        '                     "※" + Trim(Me.txtCustAls.Text) + _
        '                     "※" + strcustfm + _
        '                     "※" + strcustto + _
        '                     "※" + strSort

        '    Screen.MousePointer = vbHourglass

        '    rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        '    Screen.MousePointer = vbDefault

        '    If rs(0)(0) <> "0" Then  '*** An error has occured
        '        MsgBox(rs(0)(0))
        '    Else
        '        rs_IMR00022 = rs(1)
        '        If rs_IMR00022.recordCount = 0 Then
        '            msg("M00071")
        '            Exit Sub
        '        Else
        '            Call CmdExportExcel_Click()
        '        End If
        '    End If


    End Sub
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

        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True


        xlWs.Cells(1, 1) = "Item #"
        xlWs.Cells(1, 2) = "Item Description"
        xlWs.Cells(1, 3) = "Cust #"
        xlWs.Cells(1, 4) = "Customer Name"
        xlWs.Cells(1, 5) = "Cust. Alias Item #"

        xlWs.Rows(1).Font.Bold = True


        For col As Integer = 0 To rs_IMR00022.Tables("RESULT").Columns.Count - 1
            For row As Integer = 0 To rs_IMR00022.Tables("RESULT").Rows.Count - 1
                xlWs.Cells(row + 2, col + 1) = rs_IMR00022.Tables("RESULT").Rows(row).ItemArray(col)

            Next

        Next

        '        // Copy the values from a DataTable to an Excel Sheet (cell-by-cell)
        'for (int col = 0; col < dataTable.Columns.Count; col++)
        '{
        '    for (int row = 0; row < dataTable.Rows.Count; row++)
        '    {
        '        excelSheet.Cells[row + 1, col + 1] = 
        '                dataTable.Rows[row].ItemArray[col];
        '    }
        '}


        ' ''fldCount = rs_IMR00022.Tables("RESULT").Rows.Count

        ' ''For iCol = 1 To fldCount

        ' ''    ''Just input the names here

        ' ''    ''            xlWs.Cells(1, iCol).Value = rs_IMR00022.Fields(iCol - 1).Name
        ' ''    xlWs.Rows(1).Font.Bold = True
        ' ''    xlWs.Rows(1).Font.Size = 10
        ' ''    xlWs.Rows(1).Font.Underline = True
        ' ''Next

        ' ''If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then
        ' ''    xlWs.Cells(2, 1).CopyFromRecordset(rs_IMR00022)
        ' ''Else

        ' ''    MsgBox("This Option only works with EXCEL 2000 or 2002.", vbExclamation)
        ' ''    'recArray = rs_IMR00022.GetRows


        ' ''    Dim recArray(rs_IMR00022.Tables("RESULT").Rows.Count - 1, rs_IMR00022.Tables("RESULT").Columns.Count - 1) As String '(row,col)
        ' ''    For intRow As Integer = 0 To rs_IMR00022.Tables("RESULT").Rows.Count - 1
        ' ''        For intCol As Integer = 0 To rs_IMR00022.Tables("RESULT").Columns.Count - 1
        ' ''            recArray(intRow, intCol) = CStr(rs_IMR00022.Tables("RESULT").Rows(intRow).Item(intCol))
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

        xlApp.Selection.CurrentRegion.Columns.AutoFit()
        xlApp.Selection.CurrentRegion.rows.AutoFit()

        xlWs.Rows(1).RowHeight = 25

        rs_IMR00022 = Nothing


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

        rs_IMR00022 = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub

    Private Sub CmdExportExcel_Click2()

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

        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True

        fldCount = rs_IMR00022.Tables("RESULT").Rows.Count

        For iCol = 1 To fldCount

            ''Just input the names here

            ''            xlWs.Cells(1, iCol).Value = rs_IMR00022.Fields(iCol - 1).Name
            xlWs.Rows(1).Font.Bold = True
            xlWs.Rows(1).Font.Size = 10
            xlWs.Rows(1).Font.Underline = True
        Next

        If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then
            xlWs.Cells(2, 1).CopyFromRecordset(rs_IMR00022)
        Else

            MsgBox("This Option only works with EXCEL 2000 or 2002.", vbExclamation)
            'recArray = rs_IMR00022.GetRows


            Dim recArray(rs_IMR00022.Tables("RESULT").Rows.Count - 1, rs_IMR00022.Tables("RESULT").Columns.Count - 1) As String '(row,col)
            For intRow As Integer = 0 To rs_IMR00022.Tables("RESULT").Rows.Count - 1
                For intCol As Integer = 0 To rs_IMR00022.Tables("RESULT").Columns.Count - 1
                    recArray(intRow, intCol) = CStr(rs_IMR00022.Tables("RESULT").Rows(intRow).Item(intCol))
                Next intCol
            Next intRow


            recCount = UBound(recArray, 2) + 1 '+ 1 since 0-based array
            For iCol = 0 To fldCount - 1
                For iRow = 0 To recCount - 1
                    If IsDate(recArray(iCol, iRow)) Then
                        recArray(iCol, iRow) = Format(recArray(iCol, iRow))
                    ElseIf IsArray(recArray(iCol, iRow)) Then
                        recArray(iCol, iRow) = "Array Field"
                    End If
                Next iRow 'next record
            Next iCol 'next field

            xlWs.Cells(2, 1).resize(recCount, fldCount).Value = recArray

        End If

        xlApp.Selection.CurrentRegion.Columns.AutoFit()
        xlApp.Selection.CurrentRegion.rows.AutoFit()

        xlWs.Rows(1).RowHeight = 25

        rs_IMR00022 = Nothing


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

        rs_IMR00022 = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub



    Private Sub Form_Load()


        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        '        Dim S As String
        '        Dim rs() As ADOR.Recordset

        '        Screen.MousePointer = vbHourglass

        '        S = "㊣CUBASINF※L※PA"

        '        rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        '        If rs(0)(0) <> "0" Then  '*** An error has occured
        '            MsgBox(rs(0)(0))
        '        Else
        '            rs_CUBASINF = rs(1)
        '            Call FillcboCust()
        '        End If

        '        Screen.MousePointer = vbDefault

    End Sub



    Private Sub IMR00022_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Fill in Customer No and Vendor No
        Cursor = Cursors.WaitCursor

        ' cboCoCde.Text = "ALL"

        gspStr = "sp_list_CUBASINF '" & "" & "','PA'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00007_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If


        Call Formstartup(Me.Name)
        Call FillcboCust()

    End Sub




    Private Sub FillcboCust()

        If rs_CUBASINF Is Nothing Then
            Exit Sub
        End If

        cboCustNoFm.Items.Clear()
        cboCustNoFm.Items.Add("")
        cboCustNoTo.Items.Clear()
        cboCustNoTo.Items.Add("")

        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '60000'")

            For i As Integer = 0 To dr.Length - 1
                cboCustNoFm.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
                cboCustNoTo.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
            Next

            cboCustNoFm.SelectedIndex = 0
            cboCustNoTo.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If cboCustNoFm.Text > cboCustNoTo.Text Then
            MsgBox("Customer : From > To !")
            ' cboCustNoFm.SetFocus()
            Exit Sub
        End If

        If cboCustNoFm.Text = "" And cboCustNoTo.Text <> "" Then
            MsgBox("Customer Code Empty (From) !")
            ' cboCustNoFm.SetFocus()
            Exit Sub
        End If


        If cboCustNoFm.Text <> "" And cboCustNoTo.Text = "" Then
            MsgBox("Customer Code Empty (To) !")
            ' cboCustNoFm.SetFocus()
            Exit Sub
        End If


        ' Customer No --------------------------------------
        Dim CNF As String
        Dim cnt As String

        If cboCustNoFm.Text = "" Then
            CNF = ""
        Else
            CNF = Split(cboCustNoFm.Text, " - ")(0)
        End If

        If cboCustNoTo.Text = "" Then
            cnt = ""
        Else
            cnt = Split(cboCustNoTo.Text, " - ")(0)
        End If


        Dim sort As String
        If optItm.Checked = True Then
            sort = "ITM"
        ElseIf optCust.Checked = True Then
            sort = "CUS"
        Else
            sort = "ALS"
        End If



        Me.Cursor = Windows.Forms.Cursors.WaitCursor


        gspStr = "temp_sp_list_IMR00022 '','" & Trim(Me.txtItemList.Text) & _
            "','" & Trim(Me.txtCustAls.Text) & _
            "','" & CNF & "','" & cnt & _
            "','" & sort & "'"

        'S = "㊣IMR00022※L※" + Trim(Me.txtItemList.Text) + _
        '         "※" + Trim(Me.txtCustAls.Text) + _
        '         "※" + strcustfm + _
        '         "※" + strcustto + _
        '         "※" + strSort


        'gspStr = "sp_select_IMR00022 'UCP','50000','59999','','','','','','','','','03/01/2009','03/01/2013','ALL','','mis'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_IMR00022, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00033 : " & rtnStr)
            Exit Sub
        End If


        If rs_IMR00022.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("IMR00022 no record!")
            Exit Sub
        Else

            Call CmdExportExcel_Click()


            '************Sorting***********************
            ' ''If OptCust.Value = True Then
            ' ''    rs_IMR00022.sort = "Pri_Cust,Sec_Cust"
            ' ''Else
            ' ''    rs_IMR00022.sort = "sih_invno"
            ' ''End If


            'If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
            '    ReportName(0) = "IMR00022.rpt"
            'Else
            '    ReportName(0) = "IMR00022B.rpt"
            'End If


            'ReportRS(0) = rs_IMR00022
            'frmReport.Show()

            ' ''Dim objRpt As New IMR00022Rpt
            ' ''objRpt.SetDataSource(rs_IMR00022.Tables("RESULT"))

            ' ''Dim frmReportView As New frmReport
            ' ''frmReportView.CrystalReportViewer.ReportSource = objRpt
            ' ''frmReportView.Show()



        End If



        Me.Cursor = Windows.Forms.Cursors.Default





    End Sub

    Private Sub cmdItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemList.Click
        frmItemList.strItem = txtItemList.Text
        'frmItemList.Show(vbModal)
        Call frmItemList.getform("IMR00022_1")
        frmItemList.ShowDialog()
        txtItemList.Text = frmItemList.strSel
    End Sub

    Private Sub cmdItemLstCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemLstCust.Click
        frmItemList.strItem = txtCustAls.Text
        'frmItemList.Show(vbModal)
        Call frmItemList.getform("IMR00022_2")
        frmItemList.ShowDialog()
        txtCustAls.Text = frmItemList.strSel

    End Sub

    Public Function settxtItemList(ByVal strA As String)
        Me.txtItemList.Text = strA
        'Me.Show()
        'Me.Refresh()


    End Function


    Public Function settxtCustAls(ByVal strA As String)
        Me.txtCustAls.Text = strA
        'Me.Show()
        'Me.Refresh()


    End Function

    Private Sub cboCustNoFm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoFm.LostFocus
        cboCustNoTo.Text = cboCustNoFm.Text
        cboCustNoTo.Focus()
        cboCustNoTo.SelectAll()


    End Sub



    Private Sub cboCustNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SelectedIndexChanged

    End Sub

    Private Sub cboCustNoTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoTo.GotFocus
        cboCustNoTo.SelectAll()

    End Sub

    Private Sub cboCustNoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoTo.KeyUp
        Call auto_search_combo(cboCustNoTo, e.KeyCode)

    End Sub

    Private Sub cboCustNoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoTo.SelectedIndexChanged

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub txtItemList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemList.TextChanged

    End Sub

    Private Sub txtCustAls_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustAls.TextChanged

    End Sub
End Class



''Public Class IMR00022

''    Dim rs_VNBASINF As DataSet
''    Dim rs_CUBASINF As DataSet

''    Private Sub MSR00032_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
''        Formstartup(Me.Name)

''        loadComboBox()

''        GetDefaultCompany(cboCoCde, txtCoNam)
''    End Sub

''    Private Sub loadComboBox()
''        FillCompCombo(gsUsrID, cboCoCde)
''        cboCoCde.Items.Add("UC-G")

''        gspStr = "sp_list_VNBASINF ''"
''        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
''        If rtnLong <> RC_SUCCESS Then
''            MsgBox("Error on loading IMR00017_Load #001 sp_list_VNBASINF_vensna :" & rtnStr)
''        End If

''        format_cboVen()

''    End Sub

''    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

''    End Sub

''    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
''        If cboCoCde.Text <> "UC-G" Then
''            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
''        Else
''            txtCoNam.Text = "UNITED CHINESE GROUP"
''        End If
''    End Sub

''    Private Sub format_cboVen()
''        cboVenFm.Items.Items.Clear()
''        cboVenTo.Items.Items.Clear()

''        cboVenFm.Items.Add("")
''        cboVenTo.Items.Add("")

''        For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
''            cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
''            cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
''        Next
''    End Sub
''End Class