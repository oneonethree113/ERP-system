Imports Microsoft.Office.Interop

Public Class IMR00009

    Dim rs_EXCEL As New DataSet
    Dim data_cust As New DataSet

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim colEngDesc As Integer
    Dim colUSD As Integer
    Dim colCAD As Integer
    Dim colInner As Integer
    Dim colMaster As Integer
    Dim colCFT As Integer
    Dim colShipStrDate As Integer
    Dim colShipEndDate As Integer
    Dim colPOStrDate As Integer
    Dim colPOEndDate As Integer
    Dim colRemark As Integer
    Dim colPORemark As Integer
    Dim colHSTU As Integer

    Private Sub IMR00009_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        FillCustCombo()
        GetDefaultCompany(cboCoCde, txtCoNam)
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        If Not InputIsValid = False Then
            IMR00009_BeforeShow()
        End If
    End Sub

    Private Sub FillCustCombo()
        Dim dr() As DataRow
        gspStr = "sp_list_CUBASINF '" & gsCompany & "','" & "PA" & "'"
        rtnLong = execute_SQLStatement(gspStr, data_cust, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00009 sp_list_CUBASINF : " & rtnStr & vbCrLf & "gspStr = " & gspStr)
        Else
            dr = data_cust.Tables("RESULT").Select("cbi_cusno >= '5000'")
            If dr.Length > 0 Then
                For Each tmp_dr As DataRow In dr
                    cbo_pricustfrom.Items.Add(tmp_dr("cbi_cusno") + " - " + tmp_dr("cbi_cussna"))
                    cbo_pricustto.Items.Add(tmp_dr("cbi_cusno") + " - " + tmp_dr("cbi_cussna"))
                Next
            End If
        End If


        ' Data source.

    End Sub



    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
    End Sub

    Private Sub txtFromSCNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromSCNo.TextChanged
        txtToSCNo.Text = txtFromSCNo.Text
    End Sub

    Private Sub cbo_pricust_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_pricustfrom.KeyUp, cbo_pricustto.KeyUp
        If (e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.ShiftKey) Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cbo_custno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_pricustfrom.Validating, cbo_pricustto.Validating
        Dim tmpbox As ComboBox = CType(sender, ComboBox)
        If tmpbox.Text = "" Then
            Exit Sub
        ElseIf tmpbox.Items.Contains(tmpbox.Text) = False Then
            MsgBox("Invalid Data! Pls try again.")
            e.Cancel = True
        End If
    End Sub
    'Customer No related End




    Private Function InputIsValid() As Boolean

        'If Trim(txtFromSCNo.Text) = "" Then
        '    txtFromSCNo.Text = "0"
        'End If

        'If Trim(txtToSCNo.Text) = "" Then
        '    txtToSCNo.Text = "ZZZZZZZZZZ"
        'End If

        If (Trim(txtFromSCNo.Text) = "" Or Trim(txtToSCNo.Text) = "") Then
            MsgBox("SC No Cannot be empty")
            Return False
        End If


        If cbo_pricustfrom.Text > cbo_pricustto.Text Then
            cbo_pricustto.Focus()
            MsgBox("To Primary Customer No cannot be greater than From Primary Customer No")
            Return False
        End If

        If txtFromSCNo.Text > txtToSCNo.Text Then
            txtFromSCNo.Focus()
            MsgBox("To Customer Item No  cannot be greater than From Customer Item No", MsgBoxStyle.Information, "Message")
            Return False
        End If
        Return True
    End Function



    Private Sub IMR00009_BeforeShow()
        Dim PriCustFrom As String = If(cbo_pricustfrom.Text = "", "", cbo_pricustfrom.Text.ToString.Substring(0, 5))
        Dim PriCustTo As String = If(cbo_pricustto.Text = "", "", cbo_pricustto.Text.ToString.Substring(0, 5))

        gspStr = "sp_select_IMR00009A '" & cboCoCde.Text & "','" & _
                    PriCustFrom & "','" & PriCustTo & "','" & _
                    txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_EXCEL = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00009 #001 sp_select_IMR00009A : " & rtnStr)
            Exit Sub
        End If

        If rs_EXCEL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
            Exit Sub
        End If

        ExportToExcel()
    End Sub

    Private Sub ExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_EXCEL.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim headerRow As Integer = 1
        Dim headerCol As Integer = 1

        ' Row Header Initializing
        With xlsApp

            For i As Integer = 0 To excelheader_list.Length - 1
                .Cells(headerRow, i + 1) = excelheader_list(i)
            Next

            colEngDesc = Array.FindIndex(excelheader_list, Function(s) s.Contains("English Desc.")) + 1
            colUSD = Array.FindIndex(excelheader_list, Function(s) s.Contains("USD")) + 1
            colCAD = Array.FindIndex(excelheader_list, Function(s) s.Contains("CAD")) + 1
            colInner = Array.FindIndex(excelheader_list, Function(s) s.Contains("Inner")) + 1
            colMaster = Array.FindIndex(excelheader_list, Function(s) s.Contains("Master")) + 1
            colCFT = Array.FindIndex(excelheader_list, Function(s) s.Contains("CFT")) + 1

            colShipStrDate = Array.FindIndex(excelheader_list, Function(s) s.Contains("S/C Ship Start Date")) + 1
            colShipEndDate = Array.FindIndex(excelheader_list, Function(s) s.Contains("S/C Ship End Date")) + 1
            colPOStrDate = Array.FindIndex(excelheader_list, Function(s) s.Contains("PO Ship Start Date")) + 1
            colPOEndDate = Array.FindIndex(excelheader_list, Function(s) s.Contains("PO Ship End Date")) + 1
            colRemark = Array.FindIndex(excelheader_list, Function(s) s.Contains("Remark")) + 1
            colPORemark = Array.FindIndex(excelheader_list, Function(s) s.Contains("PO Remark")) + 1
            colHSTU = Array.FindIndex(excelheader_list, Function(s) s.Contains("HSTU#")) + 1

            .Columns(colUSD).NumberFormat = "#,##0.00"
            .Columns(colCAD).NumberFormat = "#,##0.00"
            .Columns(colShipStrDate).NumberFormat = "MM/dd/yyyy"
            .Columns(colShipEndDate).NumberFormat = "MM/dd/yyyy"
            .Columns(colPOStrDate).NumberFormat = "MM/dd/yyyy"
            .Columns(colPOEndDate).NumberFormat = "MM/dd/yyyy"


        End With

        headerCol = 1
        Dim entry(45) As String 'Object

        Try
            With xlsApp
                .Range(.Cells(3, 1), .Cells(3, rs_EXCEL.Tables("RESULT").Columns.Count)).Value = entry

                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    For j As Integer = 0 To excelheader_list.Length - 1
                        Dim tmp_value = If(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i)(excelheader_list(j))), "", rs_EXCEL.Tables("RESULT").Rows(i)(excelheader_list(j)))

                        If (j = colUSD - 1 Or j = colCAD - 1) Then
                            entry(j) = Format(tmp_value, "0.00")

                        ElseIf (j = colShipStrDate - 1 Or j = colShipEndDate - 1 Or j = colPOStrDate - 1 Or j = colPOEndDate - 1) Then
                            entry(j) = If(tmp_value.ToString = "", "", Format(CDate(tmp_value), "MM/dd/yyyy"))
                        Else
                            entry(j) = tmp_value
                        End If

                    Next
                    .Range(.Cells(headerRow + 1 + i, headerCol), .Cells(headerRow + 1 + i, rs_EXCEL.Tables("RESULT").Columns.Count)).Value = entry
                Next

                'For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                '    entry(0) = rs_EXCEL.Tables("RESULT").Rows(i)("Custom Vendor")
                '    entry(1) = rs_EXCEL.Tables("RESULT").Rows(i)("Vendor")
                '    entry(2) = rs_EXCEL.Tables("RESULT").Rows(i)("Sub Code")
                '    entry(3) = rs_EXCEL.Tables("RESULT").Rows(i)("PO No.")
                '    entry(4) = rs_EXCEL.Tables("RESULT").Rows(i)("Job Order No.")
                '    entry(5) = rs_EXCEL.Tables("RESULT").Rows(i)("Item No")
                '    entry(6) = rs_EXCEL.Tables("RESULT").Rows(i)("Vendor Item No.")
                '    entry(7) = rs_EXCEL.Tables("RESULT").Rows(i)("Customer Item#")
                '    entry(8) = rs_EXCEL.Tables("RESULT").Rows(i)("Sec. Customer Item #")
                '    entry(9) = rs_EXCEL.Tables("RESULT").Rows(i)("Customer SKU No.")
                '    entry(10) = rs_EXCEL.Tables("RESULT").Rows(i)("English Desc.")
                '    entry(11) = rs_EXCEL.Tables("RESULT").Rows(i)("Color Code")
                '    entry(12) = rs_EXCEL.Tables("RESULT").Rows(i)("Customer Color")
                '    entry(13) = rs_EXCEL.Tables("RESULT").Rows(i)("Color Desc.")
                '    entry(14) = rs_EXCEL.Tables("RESULT").Rows(i)("Dept")
                '    entry(15) = Format(rs_EXCEL.Tables("RESULT").Rows(i)("USD"), "0.00")
                '    entry(16) = Format(rs_EXCEL.Tables("RESULT").Rows(i)("CAD"), "0.00")
                '    entry(17) = rs_EXCEL.Tables("RESULT").Rows(i)("UM")
                '    entry(18) = rs_EXCEL.Tables("RESULT").Rows(i)("Inner ")
                '    entry(19) = rs_EXCEL.Tables("RESULT").Rows(i)("Master ")
                '    entry(20) = rs_EXCEL.Tables("RESULT").Rows(i)("CFT")
                '    entry(21) = rs_EXCEL.Tables("RESULT").Rows(i)("Packing Inst.")
                '    entry(22) = rs_EXCEL.Tables("RESULT").Rows(i)("Cust PO# (Header)")
                '    entry(23) = rs_EXCEL.Tables("RESULT").Rows(i)("Cust PO# (Detail)")
                '    entry(24) = rs_EXCEL.Tables("RESULT").Rows(i)("Resp. PO# (Header)")
                '    entry(25) = rs_EXCEL.Tables("RESULT").Rows(i)("Resp. PO# (Detail)")
                '    entry(26) = rs_EXCEL.Tables("RESULT").Rows(i)("Merchandise")
                '    entry(27) = rs_EXCEL.Tables("RESULT").Rows(i)("Conversion Factor")
                '    entry(28) = rs_EXCEL.Tables("RESULT").Rows(i)("Order Qty")
                '    entry(29) = rs_EXCEL.Tables("RESULT").Rows(i)("Inner")
                '    entry(30) = rs_EXCEL.Tables("RESULT").Rows(i)("I/ Qty")
                '    entry(31) = rs_EXCEL.Tables("RESULT").Rows(i)("Side")
                '    entry(32) = rs_EXCEL.Tables("RESULT").Rows(i)("M/ Qty")
                '    entry(33) = rs_EXCEL.Tables("RESULT").Rows(i)("Start Ctn")
                '    entry(34) = rs_EXCEL.Tables("RESULT").Rows(i)("End Ctn")
                '    'entry(35) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date")), "MM/dd/yyyy"))
                '    If rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date").ToString = "" Then
                '        entry(35) = ""
                '    Else
                '        entry(35) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date")), "MM/dd/yyyy")
                '    End If
                '    'entry(36) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date")), "MM/dd/yyyy"))
                '    If rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date").ToString = "" Then
                '        entry(36) = ""
                '    Else
                '        entry(36) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date")), "MM/dd/yyyy")
                '    End If
                '    'entry(37) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date")), "MM/dd/yyyy"))
                '    If rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date").ToString = "" Then
                '        entry(37) = ""
                '    Else
                '        entry(37) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date")), "MM/dd/yyyy")
                '    End If
                '    'entry(38) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date")), "MM/dd/yyyy"))
                '    If rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date").ToString = "" Then
                '        entry(38) = ""
                '    Else
                '        entry(38) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date")), "MM/dd/yyyy")
                '    End If
                '    entry(39) = rs_EXCEL.Tables("RESULT").Rows(i)("hstu#")
                '    entry(40) = rs_EXCEL.Tables("RESULT").Rows(i)("Remark")
                '    entry(41) = rs_EXCEL.Tables("RESULT").Rows(i)("PO Remark")

                '    .Range(.Cells(headerRow + 1 + i, headerCol), .Cells(headerRow + 1 + i, rs_EXCEL.Tables("RESULT").Columns.Count)).Value = entry
                'Next

            End With

            ' Styling EXCEL
            With xlsApp
                .Rows(1).Font.Bold = True
                .Rows(1).rowheight = 24.75
                '.Columns("B:B").WrapText = True

                '.Rows("1:2").VerticalAlignment = Excel.Constants.xlCenter
                .Columns("A:AT").Font.Size = 10
                '.Columns("A:AK").Font.Name = "Arial"
                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count)).Font.Name = "Arial"
                .Columns(colEngDesc).ColumnWidth = 50
                .Columns(colEngDesc).WrapText = True
                .Range(.Cells(headerRow + 1, colUSD), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colUSD)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colCAD), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colCAD)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colInner), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colInner)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colMaster), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colMaster)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colCFT), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colCFT)).HorizontalAlignment = Excel.Constants.xlRight
                .Columns("A:AT").EntireColumn.AutoFit()
                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count)).EntireRow.AutoFit()

                .Columns(colRemark).columnWidth = 40
                .Columns(colPORemark).columnWidth = 40
                .Columns(colHSTU).columnWidth = 12.5
                .Columns(colRemark).NumberFormat = "@"
                .Columns(colPORemark).NumberFormat = "@"
                .Columns(colRemark).VerticalAlignment = Excel.Constants.xlCenter
                .Columns(colPORemark).VerticalAlignment = Excel.Constants.xlCenter
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    ExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "IMR00009 - Excel Error")
            End If
        End Try

        ' Release reference
        rs_EXCEL = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub


    Dim excelheader_list() As String = { _
        "Custom Vendor", _
        "Vendor", _
        "PO No.", _
 _
        "SC No.", _
        "SC Status", _
        "Primary Customer", _
        "Secondary Customer", _
 _
        "Job Order No.", _
        "Item No", _
        "Vendor Item No.", _
        "Customer Item#", _
        "Sec. Customer Item #", _
        "Customer SKU No.", _
        "English Desc.", _
        "Color Code", _
        "Customer Color", _
        "Color Desc.", _
        "Dept", _
        "USD", _
        "CAD", _
        "UM", _
        "Inner ", _
        "Master ", _
        "CFT", _
        "Packing Inst.", _
        "Cust PO# (Header)", _
        "Cust PO# (Detail)", _
        "Resp. PO# (Header)", _
        "Resp. PO# (Detail)", _
        "UPC/EAN#(M)", _
        "Conversion Factor", _
        "Order Qty", _
        "UPC/EAN#(I)", _
        "I/ Qty", _
        "UPC/EAN#(C)", _
        "M/ Qty", _
        "Start Ctn", _
        "End Ctn", _
        "S/C Ship Start Date", _
        "S/C Ship End Date", _
        "PO Ship Start Date", _
        "PO Ship End Date", _
        "HSTU#", _
        "Remark", _
        "PO Remark" _
    }


End Class