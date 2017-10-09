Imports Excel = Microsoft.Office.Interop.Excel

Public Class QCM00005
    Dim rs_QCM00005 As DataSet

    Private Sub QCM00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(cboCocde, txtCoNam)

        Dim today As Date = New Date()

        FillYearBox()
        'txt_WeekFm.Text = GetCurrentWeek()
        'txt_WeekTo.Text = GetCurrentWeek()
        FillInspBox()
        FillStatusBox()


        AddSearchBtnHandler()
    End Sub

    Private Function Convert_Insptype(ByVal insptype As String) As String
        Dim ret As String
        Select Case insptype
            Case "ALL"
                ret = "ALL"
            Case "Pre-Pro"
                ret = "P"
            Case "PP Meeting"
                ret = "PP"
            Case "In-Line"
                ret = "M"
            Case "Customer In-Line"
                ret = "CM"
            Case "Customer In-line with QC"
                ret = "DCM"
            Case "Final"
                ret = "F"
            Case "Customer Final"
                ret = "CF"
            Case "Customer Final with QC"
                ret = "DCF"
            Case Else
                ret = "E"
        End Select

        Return ret
    End Function



#Region "Search Page"
    Dim textboxlist As New Collection() 'a dictionary storing the index and the textbox object
    Private Sub AddSearchBtnHandler()
        textboxlist.Add(txt_S_PriCustAll, "cmd_S_PriCustAll")
        textboxlist.Add(txt_S_SecCustAll, "cmd_S_SecCustAll")
        textboxlist.Add(txt_S_PV, "cmd_S_PV")

        AddHandler cmd_S_PriCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SecCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PV.Click, AddressOf cmd_S_Click

    End Sub

    Private Sub cmd_S_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim trigger_btn As Button = CType(sender, Button)
        Dim btn_name As String = trigger_btn.Name
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = textboxlist(btn_name).Name
        frmComSearch.callFmString = textboxlist(btn_name).Text
        frmComSearch.show_frmS(trigger_btn)
    End Sub

    Private Sub FillYearBox()
        cbo_inspyear.Items.Clear()
        Dim cur_year As Integer = Date.Today.Year
        cbo_inspyear.Items.Add(cur_year - 1)
        cbo_inspyear.Items.Add(cur_year)
        cbo_inspyear.Items.Add(cur_year + 1)
        cbo_inspyear.SelectedIndex = 1
    End Sub

    Private Sub FillInspBox()
        cbo_insptype.Items.Clear()
        cbo_insptype.Items.Add("ALL")
        cbo_insptype.Items.Add("Pre-Pro")
        cbo_insptype.Items.Add("PP Meeting")
        cbo_insptype.Items.Add("In-Line")
        'cbo_insptype.Items.Add("Customer In-Line")
        cbo_insptype.Items.Add("Customer In-line with QC")
        cbo_insptype.Items.Add("Final")
        'cbo_insptype.Items.Add("Customer Final")
        cbo_insptype.Items.Add("Customer Final with QC")

        cbo_insptype.SelectedIndex = 0
    End Sub

    Private Sub FillStatusBox()
        cbo_status.Items.Clear()
        cbo_status.Items.Add("ALL")
        cbo_status.Items.Add("OPE")
        cbo_status.Items.Add("REL")
        cbo_status.Items.Add("CAN")

        cbo_status.SelectedIndex = 0
    End Sub


    Private Sub txtWeekFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_WeekFm.TextChanged
        txt_WeekTo.Text = txt_WeekFm.Text

    End Sub


    Private Sub txtWeekTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_WeekTo.TextChanged
    End Sub


    Private Sub cboCocde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCocde.KeyUp
        auto_search_combo(cboCocde)
    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text = "UC-G" Then
            txtCoNam.Text = "UNITED CHINESE GROUP"
        Else
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        End If

    End Sub

#End Region


#Region "Function - Core"
    Private Function QC_Find() As Boolean
        QC_Find = False

        If Not QC_Find_Check() Then
            Exit Function
        End If

        gspStr = "sp_select_QCM00005 '" & gsCompany & "','" & _
            txt_S_PriCustAll.Text & "','" & _
            txt_S_SecCustAll.Text & "','" & _
            txt_S_PV.Text & "','" & _
            cbo_inspyear.Text & "','" & _
            txt_WeekFm.Text & "','" & _
            txt_WeekTo.Text & "','" & _
            Convert_Insptype(cbo_insptype.Text) & "','" & _
            cbo_status.Text & "','" & _
            gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_QCM00005, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QCM00005:" & rtnStr)
            Exit Function
        End If

        If rs_QCM00005.Tables(0).Rows.Count = 0 Then
            MsgBox("No Records found OR NO Access Rights!")
            Exit Function
        End If


        QC_Find = True
    End Function

    Private Function QC_Find_Check() As Boolean
        QC_Find_Check = False

        Dim weekfm As Integer
        Dim weekto As Integer
        If txt_WeekFm.Text <> "" And Not Int32.TryParse(txt_WeekFm.Text, weekfm) Then
            MsgBox("Invalid Week From!")
            Exit Function
        End If

        If txt_WeekTo.Text <> "" And Not Int32.TryParse(txt_WeekTo.Text, weekto) Then
            MsgBox("Invalid Week To!")
            Exit Function
        End If


        If weekto < weekfm Then
            MsgBox("Week To < Week From!")
            txt_WeekFm.Focus()
            Exit Function
        End If


        QC_Find_Check = True
    End Function

    Private Function QC_Export() As Boolean
        QC_Export = False

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

        lngRecCount = rs_QCM00005.Tables("RESULT").Rows.Count + 1
        If rs_QCM00005.Tables("RESULT").Rows.Count + 1 > 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Function
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

        fldCount = rs_QCM00005.Tables("RESULT").Columns.Count

        For iCol = 1 To fldCount
            'xlsWs.Cells(1, iCol).Value = rs_EXCEL.Fields(iCol - 1).Name
            'xlsWs.Cells(1, iCol).value = rs_EXCEL.Tables("RESULT").Columns(iCol - 1).name
            xlsWs.Rows(1).Font.Bold = True
            xlsWs.Rows(1).Font.Size = 10
            'xlWs.Rows(1).Font.Underline = True
        Next

        For i As Integer = 1 To fldCount

            If i = 11 Or i = 12 Or i = 13 Or i = 14 Or i = 16 Or i = 17 Then
                xlsWs.Columns(i).WrapText = True
                xlsWs.Columns(i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                xlsWs.Columns(i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                xlsWs.Rows(1).WrapText = False
            End If

            'If i = 17 Then
            '    xlsWs.Columns(i).numberformat("mm/dd/yyyy")

            'End If
        Next
        xlsWs.Range("R2", "R50000").NumberFormat = "mm/dd/yyyy"
        xlsWs.Range("S2", "S50000").NumberFormat = "mm/dd/yyyy"
        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Set Form Style


        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------

        Dim entry(rs_QCM00005.Tables("RESULT").Rows.Count, fldCount - 1) As Object
        With xlsApp
            'Initializing Header Row'
            For i As Integer = 0 To fldCount - 1
                entry(0, i) = rs_QCM00005.Tables("RESULT").Columns(i).ColumnName.ToString
            Next

            'Populating Data
            For j As Integer = 0 To rs_QCM00005.Tables("RESULT").Rows.Count - 1
                For i As Integer = 0 To fldCount - 1
                    '   If i = 17 Or i = 18 Then
                    'entry(j + 1, i) = rs_QCM00005.Tables("RESULT").Rows(j)(i).ToString("MM/dd/yyyy")
                    '    Else
                    entry(j + 1, i) = rs_QCM00005.Tables("RESULT").Rows(j)(i)
                    '   End If
                Next
            Next

            .Range(.Cells(1, 1), .Cells(rs_QCM00005.Tables("RESULT").Rows.Count + 1, fldCount)).Value = entry
        End With

        '   xlsWs.Columns("S").NumberFormat = "mm/dd/yyyy"

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsWs.Columns(12).ColumnWidth = 12
        xlsWs.Columns(13).ColumnWidth = 12
        xlsWs.Columns(16).ColumnWidth = 12
        xlsWs.Columns(17).ColumnWidth = 12
        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        xlsWs.Rows(1).RowHeight = 25


        MsgBox("Excel Generation Complete.")

        xlsApp.Visible = True

        rs_QCM00005 = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default


        Exit Function
Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Cursor = Cursors.Default
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_QCM00005 = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing


        QC_Export = True
    End Function

#End Region


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Cursor = Cursors.WaitCursor
        If QC_Find() Then
            QC_Export()
        End If

        Cursor = Cursors.Default
    End Sub


    Private Sub txt_DateFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_DateFm.TextChanged
        txt_DateTo.Text = txt_DateFm.Text
    End Sub

    Private Sub txt_DateFm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DateFm.Validating
        Dim tmpstr As String
        tmpstr = txt_DateFm.Text

        If tmpstr = "  /  /" Then
            Exit Sub
        End If

        If Not IsDate(tmpstr) Then
            MsgBox("Not a valid date!")
            txt_DateFm.Focus()
        Else
            Dim tmpdate As Date = CDate(txt_DateFm.Text)

            If cbo_inspyear.Text <> tmpdate.Year Then
                MsgBox("Year not matched")
                txt_DateFm.Focus()
                Exit Sub
            End If

            Dim Week As Integer = GetWeekByDate(tmpdate)
            txt_WeekFm.Text = Week
        End If
    End Sub



    Private Sub txt_DateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DateTo.Validating
        Dim tmpstr As String
        tmpstr = txt_DateTo.Text

        If tmpstr = "  /  /" Then
            Exit Sub
        End If

        If Not IsDate(tmpstr) Then
            MsgBox("Not a valid date!")
            txt_DateTo.Focus()
        Else
            Dim tmpdate As Date = CDate(txt_DateTo.Text)

            If cbo_inspyear.Text <> tmpdate.Year Then
                MsgBox("Year not matched")
                txt_DateTo.Focus()
                Exit Sub
            End If

            Dim Week As Integer = GetWeekByDate(tmpdate)
            txt_WeekTo.Text = Week
        End If
    End Sub


    Private Sub cbo_inspyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_inspyear.SelectedIndexChanged
        txt_DateFm.Text = "  /  /"
        txt_DateTo.Text = "  /  /"
    End Sub



End Class