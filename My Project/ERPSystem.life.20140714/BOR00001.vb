Imports Excel = Microsoft.Office.Interop.Excel
Public Class BOR00001
    Enum BOR01_Hdr
        VenName_enu
        ItemNo_enu
        ChiDesc_enu
        UM_enu
        TtlQty_enu
        ShipStr_enu
    End Enum

    Enum BOR01_Dtl
        VenName_enu
        BOMPO_enu
        CustName_enu
        CustPO_enu
        JobNo_enu
        PJobNo_enu
        OriItemNo_enu
        ItemNo_enu
        ChiDesc_enu
        UM_enu
        OrderQty_enu
        PlcQty_enu
        AdjQty_enu
        ShipStr_enu
    End Enum
    Dim rs_EXCEL As DataSet
    Private Sub BOR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '#If useMTS Then
        '       Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        'If gsConnStr = "" Then
        '    gsConnStr = getConnectionString()
        'End If
        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Startup position
        'Me.MousePointer = vbDefault
    End Sub

    Private Sub txtVenPOFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenPOFm.TextChanged
        Me.txtVenPOTo.Text = Trim(Me.txtVenPOFm.Text)
    End Sub

    Private Sub txtVenPOFm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenPOFm.Enter
        Me.txtVenPOFm.SelectionStart = 0
        Me.txtVenPOFm.SelectionLength = Len(Me.txtVenPOFm.Text)
    End Sub


    Private Sub txtVenPOTo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenPOTo.Enter
        Me.txtVenPOTo.SelectionStart = 0
        Me.txtVenPOTo.SelectionLength = Len(Me.txtVenPOTo.Text)
    End Sub

    Private Sub optShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optShow.CheckedChanged
        Me.cmdShow.Text = "&Show Report"
        Me.Frame3.Enabled = True
        Me.optHdr.Enabled = True
        Me.optDtl.Enabled = True
    End Sub

    Private Sub optGen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optGen.CheckedChanged
        Me.cmdShow.Text = "&Generate"
        Me.optHdr.Checked = True
        Me.optHdr.Enabled = False
        Me.optDtl.Enabled = False
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If Me.optShow.Checked = True Then
            If Trim(txtVenPOFm.Text) = "" Then
                MsgBox("Please Input Vendor Purchase Order #!")
                Me.txtVenPOFm.Focus()
                Exit Sub
            End If
            If Trim(txtVenPOTo.Text) = "" Then
                Me.txtVenPOTo.Text = Trim(Me.txtVenPOFm.Text)
            End If
        End If

        'gsConnStr = getConnectionString()



        If Me.optGen.Checked = True Then
            If MsgBox("Confirm to generate Vendor Purchase Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            gsCompany = IIf(gsDefaultCompany = "MS", gsDefaultCompany, "UCPP")
            Call Update_gs_Value(gsCompany)

            Dim docno As String

            gspStr = "sp_select_DOC_GEN '" & gsCompany & "','VP','" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading BOR00001 cmdShow_Click sp_select_DOC_GEN : " & rtnStr)
                Exit Sub
            Else
                docno = rs.Tables("RESULT").Rows(0)(0)
            End If

            gspStr = "SP_INSERT_BOR00001 '" & gsCompany & "','" & docno & "','" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading BOR00001 cmdShow_Click SP_INSERT_BOR00001 : " & rtnStr)
                Exit Sub
            Else
                If rs.Tables("RESULT").Rows(0)(0) = "OK" Then
                    Me.txtVenPOFm.Text = docno
                    Me.txtVenPOTo.Text = docno
                    Me.optShow.Checked = True
                    MsgBox("Vendor Purchase Order Generated!")
                Else
                    Me.txtVenPOFm.Text = ""
                    Me.txtVenPOTo.Text = ""
                    Me.optShow.Checked = True
                    MsgBox("No data exist!")
                End If
            End If



        Else

            gspStr = "sp_select_BOR00001 '" & gsCompany & "','" & Trim(Me.txtVenPOFm.Text) & "','" & Trim(Me.txtVenPOTo.Text) & "','" & IIf(optHdr.Checked = True, "H", "D") & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading BOR00001 cmdShow_Click sp_select_BOR00001 : " & rtnStr)
                Exit Sub
            Else
                If rs_EXCEL.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Record Found!") 'msg("M00071")
                    Exit Sub
                End If
            End If

            Call ExportToExcel()

        End If
    End Sub


    Private Sub ExportToExcel()





        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.ApplicationClass
        Dim xlWb As Excel.Workbook = Nothing
        Dim xlWs As Excel.Worksheet = Nothing

        Dim recArray As Object
        Dim lngRecCount As Long

        Dim fldCount As Integer
        Dim recCount As Integer

        Dim iCol As Integer
        Dim iRow As Integer

        Dim rowHeader As Integer
        Dim rowContent As Integer


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


        xlApp = New Excel.Application
        xlApp.Visible = True
        xlApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlWb = xlApp.Workbooks.Add()
        xlWs = xlWb.ActiveSheet


        fldCount = rs_EXCEL.Tables("RESULT").Columns.Count
        For iCol = 1 To fldCount
            xlWs.Cells(rowContent - 1, iCol) = rs_EXCEL.Tables("RESULT").Columns(iCol - 1).ColumnName.ToString
            xlWs.Rows(rowContent - 1).Font.Bold = True
            xlWs.rows(rowContent - 1).Font.Size = 10
        Next

        recCount = rs_EXCEL.Tables("RESULT").Rows.Count


        Dim headerRow As Integer = 6
        Dim headerCol As Integer = 1
        Try
            With xlApp
                headerCol = 0
                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Columns.Count - 1
                    headerCol += 1
                    .Cells(headerRow, headerCol) = rs_EXCEL.Tables("RESULT").Columns(i).ColumnName.ToString
                Next
                .Range(.Cells(headerRow, 1), .Cells(headerRow, headerCol)).Font.Bold = True
                .Range(.Cells(headerRow, 1), .Cells(headerRow, headerCol)).Font.Size = 10

                Dim entry(rs_EXCEL.Tables("RESULT").Columns.Count - 1) As Object
                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    For j As Integer = 0 To rs_EXCEL.Tables("RESULT").Columns.Count - 1
                        entry(j) = IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i)(j)), "", rs_EXCEL.Tables("RESULT").Rows(i)(j))
                    Next
                    .Range(.Cells(headerRow + i + 1, 1), .Cells(headerRow + i + 1, headerCol)).Value = entry
                Next

                'Styling
                For i As Integer = 1 To rs_EXCEL.Tables("RESULT").Columns.Count
                    .Columns(i).EntireColumn.AutoFit()
                Next
                .Rows(headerRow + 1 & ":" & headerRow + rs_EXCEL.Tables("RESULT").Rows.Count).EntireRow.AutoFit()
                .Rows(headerRow).RowHeight = 24
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Or ex.Message = "Exception from HRESULT: 0x800A03EC" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlWs = Nothing
                    xlWb = Nothing
                    xlApp = Nothing
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, Me.Name.ToString & " - Excel Error")
            End If
        End Try






        With xlWs
            .Range(.Cells(rowHeader, 1), .Cells(rowHeader, 6)).Merge()
            .Range(.Cells(rowHeader, 1), .Cells(rowHeader, 6)).Value = IIf(optHdr.Checked = True, "Vendor Purchase Order Summary Report (BOM)", "Vendor Purchase Order Detail Report (BOM)")
            .Range(.Cells(rowHeader, 1), .Cells(rowHeader, 6)).Font.Size = 16
            .Range(.Cells(rowHeader, 1), .Cells(rowHeader, 6)).Font.Bold = True

            .Range(.Cells(rowHeader + 2, 1), .Cells(rowHeader + 2, 1)).Value = "Vendor Purchase # : "
            .Range(.Cells(rowHeader + 2, 2), .Cells(rowHeader + 2, 3)).Merge()
            .Range(.Cells(rowHeader + 2, 2), .Cells(rowHeader + 2, 3)).Value = IIf(Me.txtVenPOFm.Text = Me.txtVenPOTo.Text, Me.txtVenPOFm.Text, Me.txtVenPOFm.Text & " - " & Me.txtVenPOTo.Text)

            .Range(.Cells(rowHeader, 1), .Cells(rowHeader, fldCount)).VerticalAlignment = Excel.Constants.xlTop
            .Range(.Cells(rowContent - 1, 1), .Cells(rowContent - 1, fldCount)).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThick
            .Range(.Cells(rowContent - 1, 1), .Cells(rowContent - 1, fldCount)).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlThick

        End With

        If Me.optHdr.Checked = True Then
            'xxxxxx'SET HEADER REPORT FORMATxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            With xlWs
                .Range(.Cells(rowHeader, BOR01_Hdr.VenName_enu + 1), .Cells(rowContent + recCount, BOR01_Hdr.VenName_enu + 1)).ColumnWidth = 25
                .Range(.Cells(rowHeader, BOR01_Hdr.VenName_enu + 1), .Cells(rowContent + recCount, BOR01_Hdr.VenName_enu + 1)).WrapText = True
                .Range(.Cells(rowHeader, BOR01_Hdr.ItemNo_enu + 1), .Cells(rowContent + recCount, BOR01_Hdr.ItemNo_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Hdr.ChiDesc_enu + 1), .Cells(rowContent + recCount, BOR01_Hdr.ChiDesc_enu + 1)).ColumnWidth = 30
                .Range(.Cells(rowHeader, BOR01_Hdr.ChiDesc_enu + 1), .Cells(rowContent + recCount, BOR01_Hdr.ChiDesc_enu + 1)).WrapText = True
                .Range(.Cells(rowHeader, BOR01_Hdr.ShipStr_enu + 1), .Cells(rowContent + recCount, BOR01_Hdr.ShipStr_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Hdr.ShipStr_enu + 1), .Cells(rowContent + recCount, BOR01_Hdr.ShipStr_enu + 1)).WrapText = True
            End With
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        Else
            'xxxxxx'SET DETAIL REPORT FORMATxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            With xlWs
                .Range(.Cells(rowHeader, BOR01_Dtl.VenName_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.VenName_enu + 1)).ColumnWidth = 25
                .Range(.Cells(rowHeader, BOR01_Dtl.VenName_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.VenName_enu + 1)).WrapText = True
                .Range(.Cells(rowHeader, BOR01_Dtl.BOMPO_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.BOMPO_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Dtl.CustName_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.CustName_enu + 1)).ColumnWidth = 35
                .Range(.Cells(rowHeader, BOR01_Dtl.CustPO_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.CustPO_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Dtl.JobNo_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.JobNo_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Dtl.PJobNo_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.PJobNo_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Dtl.OriItemNo_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.OriItemNo_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Dtl.ItemNo_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.ItemNo_enu + 1)).ColumnWidth = 15
                .Range(.Cells(rowHeader, BOR01_Dtl.ChiDesc_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.ChiDesc_enu + 1)).ColumnWidth = 30
                .Range(.Cells(rowHeader, BOR01_Dtl.ChiDesc_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.ChiDesc_enu + 1)).WrapText = True
                .Range(.Cells(rowHeader, BOR01_Dtl.ShipStr_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.ShipStr_enu + 1)).ColumnWidth = 20
                .Range(.Cells(rowHeader, BOR01_Dtl.ShipStr_enu + 1), .Cells(rowContent + recCount, BOR01_Dtl.ShipStr_enu + 1)).WrapText = True

            End With
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        End If



        Dim lngPages As Long


        lngPages = (recCount + rowContent) / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If

        With xlWs.PageSetup
            .PrintTitleRows = "$1:$6"
            .PrintTitleColumns = ""
            .CenterFooter = "Page &P of &N"
            .Zoom = False
            .TopMargin = 10
            .LeftMargin = 0.2
            .RightMargin = 0.2
            .FitToPagesWide = 1
            .FitToPagesTall = lngPages
            If optDtl.Checked = True Then
                .Orientation = Excel.XlPageOrientation.xlLandscape
            Else
                .Orientation = Excel.XlPageOrientation.xlPortrait
            End If
        End With

        rs_EXCEL = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default

        Exit Sub


    End Sub
End Class