Imports Microsoft.Office.Interop

Public Class IMR00009

    Dim rs_EXCEL As New DataSet

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim colEngDesc As Integer
    Dim colUSD As Integer
    Dim colCAD As Integer
    Dim colInner As Integer
    Dim colMaster As Integer
    Dim colCFT As Integer

    Private Sub IMR00009_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        If Not InputIsValid = False Then
            IMR00009_BeforeShow()
        End If
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
    End Sub

    Private Sub txtFromSCNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromSCNo.TextChanged
        txtToSCNo.Text = txtFromSCNo.Text
    End Sub

    Private Function InputIsValid() As Boolean

        If Trim(txtFromSCNo.Text) = "" Then
            txtFromSCNo.Text = "0"
        End If

        If Trim(txtToSCNo.Text) = "" Then
            txtToSCNo.Text = "ZZZZZZZZZZ"
        End If

        If txtFromSCNo.Text > txtToSCNo.Text Then
            txtFromSCNo.Focus()
            MsgBox("To Customer Item No  cannot be greater than From Customer Item No", MsgBoxStyle.Information, "Message")
            Return False
        End If
        Return True
    End Function

    Private Sub IMR00009_BeforeShow()
        gspStr = "sp_select_IMR00009A '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
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
            .Cells(headerRow, headerCol) = "Custom Vendor"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Sub Code"
            headerCol += 1
            .Cells(headerRow, headerCol) = "PO No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Job Order No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "item No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor Item #"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Customer Item #"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Sec. Customer Item #"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Customer SKU No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "English Desc."
            colEngDesc = headerCol
            headerCol += 1
            .Cells(headerRow, headerCol) = "Color Code"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Customer Color"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Color Desc."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Dept"
            headerCol += 1
            .Cells(headerRow, headerCol) = "USD"
            colUSD = headerCol
            headerCol += 1
            .Cells(headerRow, headerCol) = "CAD"
            colCAD = headerCol
            headerCol += 1
            .Cells(headerRow, headerCol) = "UM"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Inner"
            colInner = headerCol
            headerCol += 1
            .Cells(headerRow, headerCol) = "Master"
            colMaster = headerCol
            headerCol += 1
            .Cells(headerRow, headerCol) = "CFT"
            colCFT = headerCol
            headerCol += 1
            .Cells(headerRow, headerCol) = "Packing Instr."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Cust PO# (Header)"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Cust PO# (Detail)"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Resp. PO# (Header)"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Resp. PO# (Detail)"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Merchandise"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Conversion Factor"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Order Qty"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Inner"
            headerCol += 1
            .Cells(headerRow, headerCol) = "I/ Qty"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Side"
            headerCol += 1
            .Cells(headerRow, headerCol) = "M/ Qty"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Start Ctn"
            headerCol += 1
            .Cells(headerRow, headerCol) = "End Ctn"
            headerCol += 1
            .Cells(headerRow, headerCol) = "S/C Ship Start Date"
            .Columns(headerCol).NumberFormat = "MM/dd/yyyy"
            headerCol += 1
            .Cells(headerRow, headerCol) = "S/C Ship End Date"
            .Columns(headerCol).NumberFormat = "MM/dd/yyyy"
            headerCol += 1
            .Cells(headerRow, headerCol) = "PO Ship Start Date"
            .Columns(headerCol).NumberFormat = "MM/dd/yyyy"
            headerCol += 1
            .Cells(headerRow, headerCol) = "PO Ship End Date"
            .Columns(headerCol).NumberFormat = "MM/dd/yyyy"
            headerCol += 1
            .Cells(headerRow, headerCol) = "HSTU#"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Remark"
        End With

        headerCol = 1
        Dim entry(40) As String 'Object

        Try
            With xlsApp
                .Range(.Cells(3, 1), .Cells(3, rs_EXCEL.Tables("RESULT").Columns.Count)).Value = entry

                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    entry(0) = rs_EXCEL.Tables("RESULT").Rows(i)("Custom Vendor")
                    entry(1) = rs_EXCEL.Tables("RESULT").Rows(i)("Vendor")
                    entry(2) = rs_EXCEL.Tables("RESULT").Rows(i)("Sub Code")
                    entry(3) = rs_EXCEL.Tables("RESULT").Rows(i)("PO No.")
                    entry(4) = rs_EXCEL.Tables("RESULT").Rows(i)("Job Order No.")
                    entry(5) = rs_EXCEL.Tables("RESULT").Rows(i)("Item No")
                    entry(6) = rs_EXCEL.Tables("RESULT").Rows(i)("Vendor Item No.")
                    entry(7) = rs_EXCEL.Tables("RESULT").Rows(i)("Customer Item#")
                    entry(8) = rs_EXCEL.Tables("RESULT").Rows(i)("Sec. Customer Item #")
                    entry(9) = rs_EXCEL.Tables("RESULT").Rows(i)("Customer SKU No.")
                    entry(10) = rs_EXCEL.Tables("RESULT").Rows(i)("English Desc.")
                    entry(11) = rs_EXCEL.Tables("RESULT").Rows(i)("Color Code")
                    entry(12) = rs_EXCEL.Tables("RESULT").Rows(i)("Customer Color")
                    entry(13) = rs_EXCEL.Tables("RESULT").Rows(i)("Color Desc.")
                    entry(14) = rs_EXCEL.Tables("RESULT").Rows(i)("Dept")
                    entry(15) = Format(rs_EXCEL.Tables("RESULT").Rows(i)("USD"), "0.00")
                    entry(16) = Format(rs_EXCEL.Tables("RESULT").Rows(i)("CAD"), "0.00")
                    entry(17) = rs_EXCEL.Tables("RESULT").Rows(i)("UM")
                    entry(18) = rs_EXCEL.Tables("RESULT").Rows(i)("Inner ")
                    entry(19) = rs_EXCEL.Tables("RESULT").Rows(i)("Master ")
                    entry(20) = rs_EXCEL.Tables("RESULT").Rows(i)("CFT")
                    entry(21) = rs_EXCEL.Tables("RESULT").Rows(i)("Packing Inst.")
                    entry(22) = rs_EXCEL.Tables("RESULT").Rows(i)("Cust PO# (Header)")
                    entry(23) = rs_EXCEL.Tables("RESULT").Rows(i)("Cust PO# (Detail)")
                    entry(24) = rs_EXCEL.Tables("RESULT").Rows(i)("Resp. PO# (Header)")
                    entry(25) = rs_EXCEL.Tables("RESULT").Rows(i)("Resp. PO# (Detail)")
                    entry(26) = rs_EXCEL.Tables("RESULT").Rows(i)("Merchandise")
                    entry(27) = rs_EXCEL.Tables("RESULT").Rows(i)("Conversion Factor")
                    entry(28) = rs_EXCEL.Tables("RESULT").Rows(i)("Order Qty")
                    entry(29) = rs_EXCEL.Tables("RESULT").Rows(i)("Inner")
                    entry(30) = rs_EXCEL.Tables("RESULT").Rows(i)("I/ Qty")
                    entry(31) = rs_EXCEL.Tables("RESULT").Rows(i)("Side")
                    entry(32) = rs_EXCEL.Tables("RESULT").Rows(i)("M/ Qty")
                    entry(33) = rs_EXCEL.Tables("RESULT").Rows(i)("Start Ctn")
                    entry(34) = rs_EXCEL.Tables("RESULT").Rows(i)("End Ctn")
                    'entry(35) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date")), "MM/dd/yyyy"))
                    If rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date").ToString = "" Then
                        entry(35) = ""
                    Else
                        entry(35) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship Start Date")), "MM/dd/yyyy")
                    End If
                    'entry(36) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date")), "MM/dd/yyyy"))
                    If rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date").ToString = "" Then
                        entry(36) = ""
                    Else
                        entry(36) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("S/C Ship End Date")), "MM/dd/yyyy")
                    End If
                    'entry(37) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date")), "MM/dd/yyyy"))
                    If rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date").ToString = "" Then
                        entry(37) = ""
                    Else
                        entry(37) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship Start Date")), "MM/dd/yyyy")
                    End If
                    'entry(38) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date").ToString = "", "", Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date")), "MM/dd/yyyy"))
                    If rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date").ToString = "" Then
                        entry(38) = ""
                    Else
                        entry(38) = Format(CDate(rs_EXCEL.Tables("RESULT").Rows(i)("PO Ship End Date")), "MM/dd/yyyy")
                    End If
                    entry(39) = rs_EXCEL.Tables("RESULT").Rows(i)("hstu#")
                    entry(40) = rs_EXCEL.Tables("RESULT").Rows(i)("Remark")

                    .Range(.Cells(headerRow + 1 + i, headerCol), .Cells(headerRow + 1 + i, rs_EXCEL.Tables("RESULT").Columns.Count)).Value = entry
                Next
            End With

            ' Styling EXCEL
            With xlsApp
                .Rows(1).Font.Bold = True
                .Rows(1).rowheight = 24.75
                '.Columns("B:B").WrapText = True

                '.Rows("1:2").VerticalAlignment = Excel.Constants.xlCenter
                .Columns("A:AO").Font.Size = 10
                '.Columns("A:AK").Font.Name = "Arial"
                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count)).Font.Name = "Arial"
                .Columns(colEngDesc).ColumnWidth = 50
                .Columns(colEngDesc).WrapText = True
                .Range(.Cells(headerRow + 1, colUSD), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colUSD)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colCAD), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colCAD)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colInner), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colInner)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colMaster), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colMaster)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colCFT), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colCFT)).HorizontalAlignment = Excel.Constants.xlRight
                .Columns("A:AO").EntireColumn.AutoFit()
                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count)).EntireRow.AutoFit()
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
End Class