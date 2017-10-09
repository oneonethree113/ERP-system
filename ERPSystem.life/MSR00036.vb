Imports Microsoft.Office.Interop

Public Class MSR00036
    Private data_cust As New DataSet
    Private data_cust_sec As New DataSet
    Private rs_result As New DataSet

    Private Sub MSR00036_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        Call FillCustCombo()
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    'Customer No related Start
    Private Sub FillCustCombo()
        Dim dr() As DataRow

        gspStr = "sp_list_CUBASINF '" & gsCompany & "','" & "PA" & "'"
        rtnLong = execute_SQLStatement(gspStr, data_cust, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00036 sp_list_CUBASINF : " & rtnStr & vbCrLf & "gspStr = " & gspStr)
        Else
            dr = data_cust.Tables("RESULT").Select("cbi_cusno >= '5000'")
            If dr.Length > 0 Then
                For Each tmp_dr As DataRow In dr
                    cb_custnofrom1.Items.Add(tmp_dr.Item("cbi_cusno") + " - " + tmp_dr.Item("cbi_cussna"))
                    cb_custnoto1.Items.Add(tmp_dr.Item("cbi_cusno") + " - " + tmp_dr.Item("cbi_cussna"))
                Next
            End If
        End If

        gspStr = "sp_list_CUBASINF '" & gsCompany & "','" & "P" & "'"
        rtnLong = execute_SQLStatement(gspStr, data_cust_sec, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00036 sp_list_CUBASINF : " & rtnStr & vbCrLf & "gspStr = " & gspStr)
        Else
            dr = data_cust_sec.Tables("RESULT").Select("cbi_cusno >= '6000'")
            If dr.Length > 0 Then
                For Each tmp_dr As DataRow In dr
                    cb_custnofrom2.Items.Add(tmp_dr.Item("cbi_cusno") + " - " + tmp_dr.Item("cbi_cussna"))
                    cb_custnoto2.Items.Add(tmp_dr.Item("cbi_cusno") + " - " + tmp_dr.Item("cbi_cussna"))
                Next
            End If
        End If

    End Sub

    Private Sub cb_custno_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_custnofrom1.KeyUp, cb_custnofrom2.KeyUp, cb_custnoto1.KeyUp, cb_custnoto2.KeyUp
        If e.KeyCode <> Keys.Back Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cb_custno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cb_custnofrom1.Validating, cb_custnofrom2.Validating, cb_custnoto1.Validating, cb_custnoto2.Validating
        Dim tmpbox As ComboBox = CType(sender, ComboBox)
        If tmpbox.Text = "" Then
            Exit Sub
        ElseIf tmpbox.Items.Contains(tmpbox.Text) = False Then
            MsgBox("Invalid Data! Pls try again.")
            e.Cancel = True
        End If
    End Sub
    'Customer No related End

    'Date related Start
    Private Sub text_invdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_ETDfrom.Validating, txt_ETDto.Validating
        Dim txtbox As MaskedTextBox = CType(sender, MaskedTextBox)
        Dim tmp_date As Date
        If txtbox.Text = "  /  /" Then
            Exit Sub
        End If
        If Not Date.TryParse(txtbox.Text, tmp_date) Then
            MsgBox("This is not a valid date!" + vbCrLf + "Valid Format: mm/dd/yyyy")
            txtbox.Focus()
        End If
    End Sub
    'Date related End




    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim flg_valid, flg_excel As Boolean
        Dim ETD_from, ETD_to, custnofrom, custnofrom2, custnoto, custnoto2 As String

        'Update Company Code before execute
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        flg_valid = DataValidate()
        If Not (flg_valid) Then
            MsgBox("Show report Fail!")
        Else
            flg_excel = If(chk_excel.Checked, True, False)

            ETD_from = If(txt_ETDfrom.Text = "  /  /", "01/01/1990", txt_ETDfrom.Text)
            ETD_to = If(txt_ETDto.Text = "  /  /", "01/01/2100", txt_ETDto.Text)
            custnofrom = If(cb_custnofrom1.Text <> "", cb_custnofrom1.Text.ToString.Substring(0, 5), "")
            custnofrom2 = If(cb_custnofrom2.Text <> "", cb_custnofrom2.Text.ToString.Substring(0, 5), "")
            custnoto = If(cb_custnoto1.Text <> "", cb_custnoto1.Text.ToString.Substring(0, 5), "")
            custnoto2 = If(cb_custnoto2.Text <> "", cb_custnoto2.Text.ToString.Substring(0, 5), "")

            rs_result.Reset()
            gspStr = "sp_select_MSR00036 '" & gsCompany & "','" & _
                    custnofrom & "','" & _
                    custnoto & "','" & _
                    custnofrom2 & "','" & _
                    custnoto2 & "','" & _
                    ETD_from & "','" & _
                    ETD_to & "','" & _
                    txtAAF.Text & "','" & _
                    flg_excel & "','" & _
                    gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_result, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_select_MSR00036 : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            ElseIf rs_result.Tables("Result").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No results found")
                Exit Sub
            End If


            If flg_excel Then
                Call gen_excel()
            Else
                Dim objRpt As New MSR00036Rpt
                objRpt.SetDataSource(rs_result.Tables("RESULT"))
                'Add Subreport report source
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            End If

        End If


        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Function DataValidate() As Boolean
        If cb_custnofrom1.Text > cb_custnoto1.Text Then
            MsgBox("Invalid Input! (Primary Customer No: To < From !)")
            Return False
        End If
        If cb_custnofrom2.Text > cb_custnoto2.Text Then
            MsgBox("Invalid Input! (Secondary Customer No: To < From !)")
            Return False
        End If
        'ETD Date Checkiing
        If txt_ETDfrom.Text = "  /  /" Or txt_ETDto.Text = "  /  /" Then
        ElseIf CDate(txt_ETDfrom.Text) > CDate(txt_ETDto.Text) Then
            MsgBox("Invalid Input! (ETD Date: To < From !)")
        End If

        Return True
    End Function

    Private Sub gen_excel()
        On Error GoTo Err_Handler
        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        Dim dt As DataTable = rs_result.Tables("Result")

        'Excel info
        Dim cur_row As Integer
        Dim y_offset As Integer = 5
        Dim col_list() As String = {"Primary Customer", _
                                    "Secondary Customer", _
                                    "Container Size", _
                                    "Total CBM", _
                                    "No of Container", _
                                    "No of Invoice"}

        Dim col_no As Integer = col_list.Length 'Change if column field in excel increase

        Dim comp_name_long As String = dt.Rows(0).Item("COMPNAME").ToString
        Dim criteria_ETD As String = dt.Rows(0).Item("ETDFrom").ToString + " - " + dt.Rows(0).Item("ETDTo").ToString


        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True

        'Merge Part
        xlWs.Range("A1:F1").Merge()
        xlWs.Range("A2:F2").Merge()

        'Font Size
        xlWs.Rows(1).font.size = 12
        xlWs.Rows(2).font.size = 11
        xlWs.Rows(4).font.size = 11

        'Bold
        xlWs.Rows(1).font.bold = True
        xlWs.Rows(4).font.bold = True

        'Cell Value
        xlWs.Range("A1").Value = comp_name_long
        xlWs.Range("A2").Value = criteria_ETD
        cur_row = 4
        For i As Integer = 0 To col_no - 1
            xlWs.Cells(cur_row, i + 1).Value = col_list(i)
        Next
        cur_row += 1

        For i As Integer = 0 To dt.Rows.Count - 1
            For j As Integer = 0 To col_no - 1
                xlWs.Cells(y_offset + i, j + 1) = dt.Rows(i).Item(j)
            Next
            cur_row += 1
        Next

        Dim tmp_range As String = CellIndexToCellString(y_offset, 1) + ":" + CellIndexToCellString(cur_row, col_no)
        xlWs.Range(tmp_range).Font.Size = 10


        xlWs.Cells.EntireColumn.AutoFit()

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing
        Exit Sub

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If

        Cursor = Cursors.Default


        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub



    Public Function ColumnIndexToColumnLetter(ByVal colIndex As Integer) As String
        Dim div As Integer = colIndex
        Dim colLetter As String = String.Empty
        Dim modnum As Integer = 0

        While div > 0
            modnum = (div - 1) Mod 26
            colLetter = Chr(65 + modnum)
            div = CInt((div - modnum) \ 26)
        End While

        Return colLetter
    End Function

    Public Function CellIndexToCellString(ByVal row_no As Integer, ByVal col_no As Integer) As String
        Dim colLetter As String = ColumnIndexToColumnLetter(col_no)
        Dim CellString As String = colLetter + row_no.ToString
        Return CellString
    End Function

End Class