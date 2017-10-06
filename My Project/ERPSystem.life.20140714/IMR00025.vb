Imports Microsoft.Office.Interop

Public Class IMR00025

    Const colCustPODate As Integer = 5
    Const colCmpMOQ As Integer = 7
    Const colOrdQty As Integer = 8
    Const colMOQCur As Integer = 9
    Const colCmpMOA As Integer = 10
    Const colOrdAmt As Integer = 11
    Const colPrdVen As Integer = 12

    Dim rs_EXCEL As New DataSet

    Dim Act As String

    Private Sub IMR00025_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If Trim(txtItmFm.Text) <> "" And Trim(txtItmTo.Text) = "" Then
            txtItmTo.Text = Trim(txtItmFm.Text)
        End If


        If Trim(txtItmFm.Text) <> "" Then
            If txtMOQSCFm.Text = "" And txtSCFm.Text = "" Then
                MsgBox("Please input MOQ SC# or Sales Confirmation No.")
                txtMOQSCFm.Focus()
                Exit Sub
            End If
        End If

        If Trim(txtMOQSCFm.Text) <> "" And Trim(txtSCFm.Text) <> "" Then
            MsgBox("Please input either MOQ SC# or Sales Confirmation No. only")
            txtMOQSCFm.Focus()
            Exit Sub
        End If

        If optINT.Checked = True Then
            Act = "I"
        ElseIf optEXT.Checked = True Then
            Act = "E"
        Else
            Act = "B"
        End If

        gspStr = "sp_select_IMR00025 '" & gsCompany & "','" & Trim(txtMOQSCFm.Text) & "','" & Trim(txtSCFm.Text) & _
                 "','" & Trim(txtItmFm.Text) & "','" & Trim(txtItmTo.Text) & "','" & Act & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_EXCEL = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00025 #001 sp_select_IMR00009A : " & rtnStr)
            Exit Sub
        End If

        If rs_EXCEL.Tables("RESULT").Rows.Count = 0 Then  '*** if no record is found, prompt user
            MsgBox("No Record Found!")
            Exit Sub
        End If

        If rs_EXCEL.Tables("RESULT").Columns.Count = 1 And rs_EXCEL.Tables("RESULT").Rows.Count = 1 Then
            MsgBox(rs_EXCEL.Tables("RESULT").Rows(0)(0).ToString, , "Message")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        ExportToExcel()
        Me.Cursor = Windows.Forms.Cursors.Default
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

        Try
            Dim headerCol As Integer = 1

            Dim ttlMOQ As Integer = 0
            Dim ttlMOA As Double = 0

            Dim custName As String = ""
            Dim key As String = UCase(rs_EXCEL.Tables("RESULT").Rows(0)("Cust. Name") & "_" & _
                                      rs_EXCEL.Tables("RESULT").Rows(0)("MOQ SC") & "_" & _
                                      rs_EXCEL.Tables("RESULT").Rows(0)("Item No.") & "_" & _
                                      rs_EXCEL.Tables("RESULT").Rows(0)("Color Code") & "_" & _
                                      rs_EXCEL.Tables("RESULT").Rows(0)("Packing"))
            Dim cur_key As String
            Dim itm As String = ""
            Dim cur_itm As String
            Dim rowAdj As Integer = 2

            Dim entry(11) As String
            With xlsApp
                .Columns(colCustPODate).HorizontalAlignment = Excel.Constants.xlRight
                .Columns(colCmpMOQ).HorizontalAlignment = Excel.Constants.xlRight
                .Columns(colOrdQty).HorizontalAlignment = Excel.Constants.xlRight
                .Columns(colMOQCur).HorizontalAlignment = Excel.Constants.xlRight
                .Columns(colCmpMOA).HorizontalAlignment = Excel.Constants.xlRight
                .Columns(colOrdAmt).HorizontalAlignment = Excel.Constants.xlRight

                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    cur_key = UCase(rs_EXCEL.Tables("RESULT").Rows(i)("Cust. Name") & "_" & _
                                          rs_EXCEL.Tables("RESULT").Rows(i)("MOQ SC") & "_" & _
                                          rs_EXCEL.Tables("RESULT").Rows(i)("Item No.") & "_" & _
                                          rs_EXCEL.Tables("RESULT").Rows(i)("Color Code") & "_" & _
                                          rs_EXCEL.Tables("RESULT").Rows(i)("Packing"))

                    If key <> cur_key Then
                        If ttlMOQ > 0 Then
                            .Range(.Cells(i + rowAdj - 1, colOrdQty), .Cells(i + rowAdj - 1, colOrdQty)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(i + rowAdj, colOrdQty) = ttlMOQ
                            .Range(.Cells(i + rowAdj, colOrdQty), .Cells(i + rowAdj, colOrdQty)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
                        End If
                        If ttlMOA > 0 Then
                            .Range(.Cells(i + rowAdj - 1, colOrdAmt), .Cells(i + rowAdj - 1, colOrdAmt)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(i + rowAdj, colOrdAmt) = Format(ttlMOA, "###,###,###.#0")
                            .Range(.Cells(i + rowAdj, colOrdAmt), .Cells(i + rowAdj, colOrdAmt)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
                        End If
                        key = cur_key
                        rowAdj = rowAdj + 2
                    End If

                    If custName <> rs_EXCEL.Tables("RESULT").Rows(i)("Cust. Name") Then
                        If custName.Length > 0 Then
                            rowAdj = rowAdj + 2
                        End If
                        headerCol = 1
                        .Cells(i + rowAdj, headerCol) = "Cust. Name :"
                        .Cells(i + rowAdj, headerCol).Font.Bold = True
                        headerCol = headerCol + 1
                        .Range(.Cells(i + rowAdj, headerCol), .Cells(i + rowAdj, headerCol + 3)).MergeCells = True
                        .Range(.Cells(i + rowAdj, headerCol), .Cells(i + rowAdj, headerCol + 3)).Value = rs_EXCEL.Tables("RESULT").Rows(i)("Cust. Name")
                        .Range(.Cells(i + rowAdj, headerCol), .Cells(i + rowAdj, headerCol + 3)).HorizontalAlignment = Excel.Constants.xlLeft
                        .Cells(i + rowAdj, headerCol) = rs_EXCEL.Tables("RESULT").Rows(i)("Cust. Name")
                        rowAdj = rowAdj + 2
                        headerCol = 1
                        .Cells(i + rowAdj, headerCol) = "Item No."
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Color Code"
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Packing"
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "SC No."
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Cust PO Date"
                        .Cells(i + rowAdj, headerCol).HorizontalAlignment = Excel.Constants.xlLeft
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Job No."
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Comp. MOQ (SC)"
                        .Cells(i + rowAdj, headerCol).HorizontalAlignment = Excel.Constants.xlLeft
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Order Qty (CTN)"
                        .Cells(i + rowAdj, headerCol).HorizontalAlignment = Excel.Constants.xlLeft
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "MOA Curr. (SC)"
                        .Cells(i + rowAdj, headerCol).HorizontalAlignment = Excel.Constants.xlLeft
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Comp. MOA (SC)"
                        .Cells(i + rowAdj, headerCol).HorizontalAlignment = Excel.Constants.xlLeft
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Order Amount"
                        .Cells(i + rowAdj, headerCol).HorizontalAlignment = Excel.Constants.xlLeft
                        headerCol = headerCol + 1
                        .Cells(i + rowAdj, headerCol) = "Prd. Ven"

                        .Rows(i + rowAdj).Font.Bold = True
                        .Range(.Cells(i + rowAdj, 1), .Cells(i + rowAdj, headerCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(i + rowAdj, 1), .Cells(i + rowAdj, headerCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThick


                        rowAdj = rowAdj + 1
                        custName = rs_EXCEL.Tables("RESULT").Rows(i)("Cust. Name")
                    End If

                    cur_itm = UCase(rs_EXCEL.Tables("RESULT").Rows(i)("Item No.") & "_" & _
                                    rs_EXCEL.Tables("RESULT").Rows(i)("Color Code") & "_" & _
                                    rs_EXCEL.Tables("RESULT").Rows(i)("Packing"))
                    If itm <> cur_itm Then
                        entry(0) = rs_EXCEL.Tables("RESULT").Rows(i)("Item No.")
                        entry(1) = rs_EXCEL.Tables("RESULT").Rows(i)("Color Code")
                        entry(2) = rs_EXCEL.Tables("RESULT").Rows(i)("Packing")
                        itm = cur_itm
                    Else
                        entry(0) = ""
                        entry(1) = ""
                        entry(2) = ""
                    End If
                    entry(3) = rs_EXCEL.Tables("RESULT").Rows(i)("SC No.")
                    entry(4) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("Cust PO Date").ToString = "", "", Format(rs_EXCEL.Tables("RESULT").Rows(i)("Cust PO Date"), "MM/dd/yyyy"))
                    entry(5) = rs_EXCEL.Tables("RESULT").Rows(i)("Job No.")
                    If rs_EXCEL.Tables("RESULT").Rows(i)("Comp MOQ (SC)") > 0 Then
                        entry(6) = rs_EXCEL.Tables("RESULT").Rows(i)("Comp MOQ (SC)")
                        entry(7) = rs_EXCEL.Tables("RESULT").Rows(i)("Order Qty (Ctn)")
                    Else
                        entry(6) = ""
                        entry(7) = ""
                    End If
                    If rs_EXCEL.Tables("RESULT").Rows(i)("Comp MOA (SC)") > 0 Then
                        entry(8) = rs_EXCEL.Tables("RESULT").Rows(i)("MOA Curr. (SC)")
                        entry(9) = rs_EXCEL.Tables("RESULT").Rows(i)("Comp MOA (SC)")
                        entry(10) = rs_EXCEL.Tables("RESULT").Rows(i)("Order Amount")
                    Else
                        entry(8) = ""
                        entry(9) = ""
                        entry(10) = ""
                    End If
                    entry(11) = rs_EXCEL.Tables("RESULT").Rows(i)("Prd Ven")

                    .Range(.Cells(i + rowAdj, 1), .Cells(i + rowAdj, headerCol)).Value = entry

                    ttlMOQ = rs_EXCEL.Tables("RESULT").Rows(i)("ttlctn")
                    ttlMOA = rs_EXCEL.Tables("RESULT").Rows(i)("ttlamt")
                Next

                If ttlMOQ > 0 Then
                    .Range(.Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdQty), .Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdQty)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    rowAdj = rowAdj + 1
                    .Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdQty) = ttlMOQ
                    .Range(.Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdQty), .Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdQty)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
                End If
                If ttlMOA > 0 Then
                    .Range(.Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdAmt), .Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdAmt)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    rowAdj = rowAdj + 1
                    .Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdAmt) = Format(ttlMOA, "###,###,###.#0")
                    .Range(.Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdAmt), .Cells(rs_EXCEL.Tables("RESULT").Rows.Count - 1 + rowAdj, colOrdAmt)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
                End If
            End With

            'Styling
            With xlsApp
                .Rows(1).RowHeight = 24.75
                .Columns("A:L").ColumnWidth = 15.57
                .Columns(colPrdVen).EntireColumn.AutoFit()
            End With

            Dim lngPages As Integer = (rs_EXCEL.Tables("RESULT").Rows.Count + rowAdj) / 20 + 1
            If lngPages > 9999 Then
                lngPages = 9999
            End If

            With xlsWS.PageSetup
                .Zoom = False
                .TopMargin = 10
                .LeftMargin = 0.2
                .RightMargin = 0.2
                .FitToPagesWide = 1
                .FitToPagesTall = lngPages
                .Orientation = Excel.XlPageOrientation.xlLandscape
                .PrintTitleRows = "$1:$4"
                .PrintTitleColumns = ""
                .CenterFooter = "Page &P of &N"
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Or ex.Message = "Exception from HRESULT: 0x800A03EC" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    ExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, Me.Name.ToString & " - Excel Error")
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