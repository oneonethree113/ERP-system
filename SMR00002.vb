Imports Excel = Microsoft.Office.Interop.Excel

Public Class SMR00002

    Public rs_EXCEL As DataSet
    Public rs_CUBASINF As DataSet
    Public rs_VNBASINF As DataSet

    Private Enq_right_local As Boolean
    Private Del_right_local As Boolean

    Public Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If

        ValidateCombo = False

        Dim i As Integer
        Dim S As String

        S = Combo1.Text

        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items.Item(i)) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next

        If Not ValidateCombo Then
            MsgBox("Invalid Data! Please try again.")
        End If
    End Function


    Private Sub selComboBox(ByRef cbo As ComboBox)
        If cbo.Enabled = True Then
            If cbo.Text <> "" Then
                cbo.SelectionStart = 0
                cbo.SelectionLength = Len(cbo.Text)
            End If
        End If
    End Sub

    Private Sub FillcboVen()
        '    If rs_VNBASINF.recordCount > 0 Then
        '        While Not rs_VNBASINF.EOF
        '            cboVenNoFm.AddItem(rs_VNBASINF("vbi_venno") & " - " & rs_VNBASINF("vbi_vensna"))
        '            cboVenNoTo.AddItem(rs_VNBASINF("vbi_venno") & " - " & rs_VNBASINF("vbi_vensna"))
        '            cboPVenNoFm.AddItem(rs_VNBASINF("vbi_venno") & " - " & rs_VNBASINF("vbi_vensna"))
        '            cboPVenNoTo.AddItem(rs_VNBASINF("vbi_venno") & " - " & rs_VNBASINF("vbi_vensna"))
        '            rs_VNBASINF.MoveNext()
        '        End While
        '    End If
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenNoFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboVenNoTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            Next
        End If
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        If cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
    End Sub


    Private Sub cboVenNoFm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenNoFm.SelectedIndexChanged
        cboVenNoTo.Text = cboVenNoFm.Text
    End Sub


    Private Sub cboVenNoFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenNoFm.GotFocus
        Call selComboBox(cboVenNoFm)
    End Sub

    Private Sub cboVenNoFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoFm.KeyUp
        Call auto_search_combo(cboVenNoFm)
    End Sub

    Private Sub cboVenNoFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenNoFm.Validating
        If ValidateCombo(cboVenNoFm) = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cboVenNoTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenNoTo.GotFocus
        Call selComboBox(cboVenNoTo)
    End Sub

    Private Sub cboVenNoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoTo.KeyUp
        auto_search_combo(cboVenNoTo)
    End Sub

    Private Sub cboVenNoTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenNoTo.Validating
        If ValidateCombo(cboVenNoTo) = False Then
            e.Cancel = True
        End If
    End Sub



    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim S As String
        Dim rs As DataSet

        '    If validateForm = False Then
        '        Exit Sub
        '    End If


        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '--------------------------------



        'ETD Date
        If Trim(Me.txtEtdDatFm.Text) <> "/  /" And Trim(Me.txtEtdDatTo.Text) = "/  /" Then
            Me.txtEtdDatTo.Text = Trim(Me.txtEtdDatFm.Text)
        End If
        If Me.txtEtdDatFm.Text = "/  /" And Me.txtEtdDatTo.Text <> "/  /" Then
            Me.txtEtdDatFm.Text = Me.txtEtdDatTo.Text
        End If

        If Trim(Me.txtEtdDatFm.Text) <> "/  /" And Trim(Me.txtEtdDatTo.Text) <> "/  /" Then
            If IsDate(Me.txtEtdDatFm.Text) = False Then
                MsgBox("Invalid ETD Date From!")
                Me.txtEtdDatFm.Focus()
                Exit Sub
            End If
            If IsDate(Trim(Me.txtEtdDatTo.Text)) = False Then
                MsgBox("Invalid ETD Date To!")
                Me.txtEtdDatTo.Focus()
                Exit Sub
            End If
            If CDate(Trim(Me.txtEtdDatFm.Text)) > CDate(Trim(Me.txtEtdDatTo.Text)) Then
                MsgBox("ETD Date : From > To !")
                Me.txtEtdDatFm.Focus()
                Exit Sub
            End If
        End If

        If Trim(Me.txtEtdDatFm.Text) = "/  /" And Trim(Me.txtEtdDatTo.Text) = "/  /" Then
            MsgBox("ETD Date is manadatory field!")
            Me.txtEtdDatFm.Focus()
            Exit Sub
        End If




        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------
        gspStr = "sp_select_SMR00002 '" & IIf(cboCoCde.Text = "UC-G", "ALL", cboCoCde.Text) & "','" & _
            IIf(Trim(Me.txtEtdDatFm.Text) = "/  /", "", Trim(Me.txtEtdDatFm.Text)) & "','" & IIf(Trim(Me.txtEtdDatTo.Text) = "/  /", "", Trim(Me.txtEtdDatTo.Text)) & "','" & _
            getComboValue(Me.cboVenNoFm) & "','" & getComboValue(Me.cboVenNoTo) & "'"


        rtnLong = execute_SQLStatementRPT(gspStr, rs_EXCEL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdShow_Click sp_select_SMR00002 :" & rtnStr)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        If rs_EXCEL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
        Else
            Call ExportToExcel()
        End If

        Cursor = Cursors.Default
    End Sub



    Private Sub ExportToExcel()
        On Error GoTo Err_Handler
        Cursor = Cursors.WaitCursor
        'Screen.MousePointer = vbHourglass ' Change mouse pointer to hourglass.
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWb As Excel.Workbook = Nothing
        Dim xlsWs As Excel.Worksheet = Nothing

        'Dim xlApp As Excel.Application
        'Dim xlWb As Excel.Workbook
        'Dim xlWs As Excel.Worksheet

        Dim recArray As Object
        Dim lngRecCount As Long
        Dim fldCount As Integer
        Dim recCount As Long
        Dim iCol As Long
        Dim iRow As Long

        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        lngRecCount = rs_EXCEL.Tables("RESULT").Rows.Count + 1
        If rs_EXCEL.Tables("RESULT").Rows.Count + 1 > 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------

        xlsApp = New Excel.Application
        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWb = xlsApp.Workbooks.Add()
        xlsWs = xlsWb.ActiveSheet


        'xlApp = CreateObject("Excel.Application")
        'xlWb = xlApp.Workbooks.Add
        'xlWs = xlWb.Worksheets(1)

        'xlApp.Visible = True
        'xlApp.UserControl = True

        'fldCount = rs_EXCEL.Fields.count

        fldCount = rs_EXCEL.Tables("RESULT").Columns.Count

        For iCol = 1 To fldCount
            'xlsWs.Cells(1, iCol).Value = rs_EXCEL.Fields(iCol - 1).Name
            'xlsWs.Cells(1, iCol).value = rs_EXCEL.Tables("RESULT").Columns(iCol - 1).name
            xlsWs.Rows(1).Font.Bold = True
            xlsWs.Rows(1).Font.Size = 10
            'xlWs.Rows(1).Font.Underline = True
        Next

        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Set Form Style

        With xlsWs
            .Range(.Cells(2, 3), .Cells(lngRecCount, 3)).NumberFormatLocal = "@" 'Pri Cust
            .Range(.Cells(2, 8), .Cells(lngRecCount, 8)).NumberFormatLocal = "@" 'Vendor No
        End With

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------

        Dim entry(rs_EXCEL.Tables("RESULT").Rows.Count, fldCount - 1) As Object
        With xlsApp
            'Initializing Header Row'
            For i As Integer = 0 To fldCount - 1
                entry(0, i) = rs_EXCEL.Tables("RESULT").Columns(i).ColumnName.ToString
            Next

            entry(0, 9) = ""
            entry(0, 11) = ""

            'Populating Data
            For j As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                For i As Integer = 0 To fldCount - 1
                    entry(j + 1, i) = rs_EXCEL.Tables("RESULT").Rows(j)(i)
                Next
            Next

            .Range(.Cells(1, 1), .Cells(rs_EXCEL.Tables("RESULT").Rows.Count + 1, fldCount)).Value = entry
        End With

        'Not done yet
        'If Val(Mid(xlsApp.Version, 1, InStr(1, xlsApp.Version, ".") - 1)) > 8 Then
        '    'EXCEL 2000 or 2002: Use CopyFromRecordset
        '    xlsWs.Cells(2, 1).CopyFromRecordset(rs_EXCEL)
        'Else
        '    'EXCEL 97 or earlier: Use GetRows then copy array to Excel
        '    recArray = rs_EXCEL.GetRows
        '    recCount = UBound(recArray, 2) + 1
        '    For iCol = 0 To fldCount - 1
        '        For iRow = 0 To recCount - 1
        '            If IsDate(recArray(iCol, iRow)) Then
        '                recArray(iCol, iRow) = Format(recArray(iCol, iRow))
        '            ElseIf IsArray(recArray(iCol, iRow)) Then
        '                recArray(iCol, iRow) = "Array Field"
        '            End If
        '        Next iRow
        '    Next iCol

        '    xlWs.Cells(2, 1).resize(recCount, fldCount).Value = recArray

        'End If

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        xlsWs.Rows(1).RowHeight = 25
        xlsApp.Visible = True

        rs_EXCEL = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default

        Exit Sub
Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Cursor = Cursors.Default
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing


    End Sub


    Private Function getComboValue(ByRef cbo As ComboBox) As String
        Dim strTemp As String
        getComboValue = ""
        strTemp = Trim(cbo.Text)
        If InStr(strTemp, " - ") > 0 Then
            'strTemp = Left(strTemp, InStr(strTemp, " - ") - 1)
            strTemp = Split(strTemp, " - ")(0)
        End If
        getComboValue = strTemp
    End Function






    Private Sub SMR00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rs As DataSet

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        If gsDefaultCompany <> "MS" Then
            cboCoCde.Items.Add("UC-G")
        End If


        gspStr = "sp_list_CUBASINF '" & cboCoCde.Text & "','PA'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SMR00002 sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNBASINF '" & cboCoCde.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SMR00002 sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If

        Dim date1 As Date = Date.Today.AddDays(-7)
        Dim date2 As Date = Date.Today.AddDays(-1)
        If gsCompanyGroup = "UCG" Then
            cboVenNoFm.Text = "1000 - ACROSS"
            cboVenNoTo.Text = "9999 - INVENTORY"
            txtEtdDatFm.Text = Format(date1, "MM/dd/yyyy")
            txtEtdDatTo.Text = Format(date2, "MM/dd/yyyy")
        End If


        Call FillcboVen()
        '================================
        Call Formstartup(Me.Name)
    End Sub
End Class