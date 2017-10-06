Imports Microsoft.Office.Interop
Public Class MSR00009
    Private data_cust As New DataSet

    Protected Overridable Sub MSR00009_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        Call FillCustCombo()
        Call init_invstatus()

        Dim tmp_string As String = Format(Now, "MM/dd/yyyy").ToString
        text_invdatefrom.Text = tmp_string
        text_invdateto.Text = tmp_string

        rb_sort_inv.Checked = True
        rb_toexcel2.Checked = True
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub


    'Customer No related Start
    Protected Overridable Sub FillCustCombo()
        gspStr = "sp_list_CUBASINF '" & gsCompany & "','" & "PA" & "'"
        rtnLong = execute_SQLStatement(gspStr, data_cust, rtnStr)


        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00004 sp_list_CUBASINF : " & rtnStr)
        Else
            Dim dt As DataTable = data_cust.Tables("RESULT")
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    cb_custnofrom.Items.Add(dr.Item("cbi_cusno") + " - " + dr.Item("cbi_cussna"))
                    cb_custnoto.Items.Add(dr.Item("cbi_cusno") + " - " + dr.Item("cbi_cussna"))

                Next
            End If
        End If
    End Sub

    Private Sub cb_custno_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_custnofrom.KeyUp, cb_custnoto.KeyUp
        If e.KeyCode <> Keys.Back Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cb_custno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cb_custnofrom.Validating, cb_custnoto.Validating
        Dim tmpbox As ComboBox = CType(sender, ComboBox)
        If tmpbox.Text = "" Then
            Exit Sub
        ElseIf tmpbox.Items.Contains(tmpbox.Text) = False Then
            MsgBox("Invalid Data! Pls try again.")
            e.Cancel = True
        End If
    End Sub
    'Customer No related End

    'Invoice Date related Start
    Private Sub text_invdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles text_invdatefrom.Validating, text_invdateto.Validating
        Dim txtbox As MaskedTextBox = CType(sender, MaskedTextBox)
        Dim tmp_date As Date
        If txtbox.Text = "  /  /" Then
            Exit Sub
        End If
        If Not Date.TryParse(txtbox.Text, tmp_date) Then
            MsgBox("This is not a valid date!")
            txtbox.Focus()
        End If
    End Sub
    'Invoice Date related End

    'Invoice Status related Start
    Protected Sub init_invstatus()
        cb_invstatus.Items.Add("ALL")
        cb_invstatus.Items.Add("OPEN")
        cb_invstatus.Items.Add("HOLD")
        cb_invstatus.Items.Add("RELEASED")
        cb_invstatus.Items.Add("CLOSE")
        cb_invstatus.SelectedIndex = 0
    End Sub
    'Invoice Status related End

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim rs_Result As DataSet
        Dim sort_by As String
        Dim InvSts As String
        Dim date_from As String
        Dim date_to As String
        Dim etd_from As String
        Dim etd_to As String
        Dim custnofrom As String
        Dim custnoto As String
        Dim flg_excel As Boolean

        'Update Company Code before execute
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim check_date_ok As Integer

        check_date_ok = 0

        Dim flg_valid As Boolean = DataValidate()
        If flg_valid = True Then
            flg_excel = IIf(rb_toexcel1.Checked = True, True, False)
            sort_by = IIf(rb_sort_inv.Checked = True, "I", "C")

            If cb_invstatus.Text = "ALL" Then
                InvSts = "'OPE','HOL','REL','CLO'"
            Else
                InvSts = "'" + cb_invstatus.Text.ToString.Substring(0, 3) + "'"
            End If

            If text_invdatefrom.Text = "  /  /" Then
                date_from = "01/01/1900"
            Else
                date_from = text_invdatefrom.Text
            End If

            If text_invdateto.Text = "  /  /" Then
                date_to = "01/01/2100"
            Else
                date_to = text_invdateto.Text
            End If



            If date_from <> "01/01/1900" And date_to <> "01/01/2100" Then
                check_date_ok = 1
            End If

            If text_etddatefrom.Text = "  /  /" Then
                etd_from = "01/01/1900"
            Else
                etd_from = text_etddatefrom.Text
            End If


            If text_etddateto.Text = "  /  /" Then
                etd_to = "01/01/2100"
            Else
                etd_to = text_etddateto.Text
            End If


            If etd_from <> "01/01/1900" And etd_to <> "01/01/2100" Then
                check_date_ok = 1
            End If


            If check_date_ok = 0 Then
                MsgBox("Please input an Invoice date range or ETD date range!")
                Me.Cursor = Windows.Forms.Cursors.Default

                Exit Sub

            End If


            If cb_custnofrom.Text <> "" Then
                custnofrom = cb_custnofrom.Text.ToString.Substring(0, 5)
            End If
            If cb_custnoto.Text <> "" Then
                custnoto = cb_custnoto.Text.ToString.Substring(0, 5)
            End If

            gspStr = "sp_select_MSR00009_NET '" & gsCompany & "','" & _
                txtFromInvoice.Text & "','" & _
                txtToInvoice.Text & "','" & _
                custnofrom & "','" & _
                custnoto & "','" & _
                date_from & "','" & _
                date_to & "','" & _
                etd_from & "','" & _
                etd_to & "','" & _
                sort_by & "','" & _
                InvSts.Replace("'", "''") & "','" & _
                gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_select_MSR00009_NET : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            End If

            If rs_Result.Tables("Result").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No results found")
                Exit Sub
            Else
                If flg_excel = True Then
                    Call gen_excel(rs_Result)
                Else
                    Dim objRpt As New MSR00009Rpt
                    objRpt.SetDataSource(rs_Result.Tables("RESULT"))
                    'Add Subreport report source
                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()
                End If
            End If




        Else
            MsgBox("Show Report Fail!")
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Function DataValidate() As Boolean
        Dim flg_valid As Boolean = True

        'Invoice No Checking
        If txtFromInvoice.Text > txtToInvoice.Text Then
            MsgBox("Invalid Input! (From Invoice No. < To Invoice No!)")
            flg_valid = False
        End If

        'Customer No Checking
        If cb_custnofrom.SelectedText > cb_custnoto.SelectedText Then
            MsgBox("invalid Input! (From Customer No. < To Customer No!)")
            flg_valid = False
        End If

        'Invoice Date Checkiing
        If text_invdatefrom.Text = "  /  /" Or text_invdateto.Text = "  /  /" Then

        ElseIf CDate(text_invdatefrom.Text) > CDate(text_invdateto.Text) Then
            MsgBox("Invalid Input! (From Invoice date < To Invoice date!)")
        End If

        Return flg_valid

    End Function

    Protected Sub gen_excel(ByVal ds As DataSet)
        On Error GoTo Err_Handler

        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim dt As DataTable = ds.Tables("RESULT")

        Dim col_list() As String = {"Primary Customer", _
                                    "Secondary Customer", _
                                    "Invoice No.", _
                                    "Status", _
                                    "Invoice Date", _
                                    "Shipping No.", _
                                    "Vessel", _
                                    "Voyage", _
                                    "Sailing Date", _
                                    "Destination", _
                                    "Price Term", _
                                    "Payment Term", _
                                    "CCY", _
                                    "Inv Amount"}

        Dim sql_map() As Integer = {3, 5, 6, 18, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16} 'the order of field in data table

        Dim col_no = col_list.Length
        Dim cur_row As Integer

        Dim comp_name_long As String = dt.Rows(0).Item("yco_conam").ToString
        Dim title As String = "Invoice Summary Report"
        Dim report_id As String = "MSR00009"
        Dim cur_day As String = Format(Now, "MM/dd/yyyy")
        Dim cur_time As String = Format(Now, "HH:mm:ss")
        Dim page_no As String = "1 of 1"
        Dim criteria_invno As String = get_excel_criteria_FrmTo(dt.Rows(0), "opt1Fm_invNo", "opt1To_invNo")
        Dim criteria_invdate As String = get_excel_criteria_FrmTo(dt.Rows(0), "opt3Fm_INVDAT", "opt3To_INVDAT")
        Dim criteria_status As String = dt.Rows(0).Item("optShpsts")
        Dim criteria_custno As String = get_excel_criteria_FrmTo(dt.Rows(0), "opt2Fm_CUST", "opt2To_CUST")
        Dim criteria_sort As String = IIf(dt.Rows(0).Item("optSortBy") = "I", "Invoice No.", "Customer Name")

        Dim total_inv_amt As Double = 0

        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True

        'Merge Part
        xlWs.Range("A1:N1").Merge()
        xlWs.Range("A2:N2").Merge()

        'Font Size
        xlWs.Rows(1).font.size = 12
        xlWs.Range("A3:N7").Font.Size = 10
        xlWs.Rows(8).font.size = 9

        'Bold
        xlWs.Rows(1).Font.Bold = True
        xlWs.Rows(2).font.bold = True
        xlWs.Rows(8).font.bold = True

        'Aligment
        xlWs.Range("A1:N2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        'Cell Value
        xlWs.Cells(1, 1) = comp_name_long
        xlWs.Cells(2, 1) = title
        xlWs.Cells(4, 1) = "Report ID:"
        xlWs.Cells(4, 2) = report_id
        xlWs.Cells(4, 5) = "Date:"
        xlWs.Cells(4, 6) = cur_day
        xlWs.Cells(4, 9) = "Time:"
        xlWs.Cells(4, 10) = cur_time
        'xlWs.Cells(4, 13) = "Page"
        'xlWs.Cells(4, 14) = page_no
        xlWs.Cells(5, 1) = "Invoice No:"
        xlWs.Cells(5, 2) = criteria_invno
        xlWs.Cells(5, 5) = "Invoice Date:"
        xlWs.Cells(5, 6) = criteria_invdate
        xlWs.Cells(5, 9) = "Status:"
        xlWs.Cells(5, 10) = criteria_status
        xlWs.Cells(6, 1) = "Cust No"
        xlWs.Cells(6, 2) = criteria_custno
        xlWs.Cells(6, 5) = "Sort By:"
        xlWs.Cells(6, 6) = criteria_sort


        For i As Integer = 0 To col_no - 1
            xlWs.Cells(8, i + 1) = col_list(i)
        Next

        Dim y_offset As Integer = 9
        cur_row = y_offset
        For i As Integer = 0 To dt.Rows.Count - 1
            For j As Integer = 0 To col_no - 1

                'If j + 1 = 9 Then
                '    xlWs.Cells(y_offset + i, j + 1).NumberFormat = "@"
                'End If
                xlWs.Cells(y_offset + i, j + 1) = dt.Rows(i).Item(sql_map(j))

                If j = col_no - 1 Then
                    total_inv_amt = total_inv_amt + dt.Rows(i).Item(sql_map(j))
                End If
            Next
            cur_row = cur_row + 1
            ' xlWs.Rows(y_offset + i).font.size = 8
        Next

        Dim tmp_range As String = "A" + y_offset.ToString + ":" + "N" + (cur_row).ToString
        xlWs.Range(tmp_range).Font.Size = 8

        tmp_range = "N" + y_offset.ToString + ":" + "N" + (cur_row).ToString
        xlWs.Range(tmp_range).NumberFormat = "#,##0.00"

        xlWs.Cells(cur_row, 12) = "Total Invoice Amount:"
        xlWs.Cells(cur_row, 13) = xlWs.Cells(cur_row - 1, 13)
        xlWs.Cells(cur_row, 14) = total_inv_amt
        xlWs.Rows(cur_row).font.bold = True


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

    Private Function get_excel_criteria_FrmTo(ByVal dr As DataRow, ByVal from_name As String, ByVal to_name As String) As String
        Dim criteria_string As String
        If dr.Item(from_name) = "" And dr.Item(to_name) = "" Then
            criteria_string = ""
        Else
            criteria_string = dr.Item(from_name) + " - " + dr.Item(to_name)
        End If
        Return criteria_string
    End Function


    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

















    Private Sub cb_inv_status_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtFromInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromInvoice.TextChanged
        txtToInvoice.Text = txtFromInvoice.Text


    End Sub

    Private Sub cb_custnofrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_custnofrom.SelectedIndexChanged
        cb_custnoto.Text = cb_custnofrom.Text


    End Sub

    Private Sub text_invdatefrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles text_invdatefrom.MaskInputRejected
        text_invdateto.Text = text_invdatefrom.Text


    End Sub

    Private Sub text_etddatefrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles text_etddatefrom.MaskInputRejected

    End Sub

    Private Sub text_etddatefrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles text_etddatefrom.TextChanged
        text_etddateto.Text = text_etddatefrom.Text


    End Sub

    Private Sub txtCoNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoNam.TextChanged

    End Sub

    Private Sub text_invdateto_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles text_invdateto.MaskInputRejected

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cb_invstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_invstatus.SelectedIndexChanged

    End Sub
End Class