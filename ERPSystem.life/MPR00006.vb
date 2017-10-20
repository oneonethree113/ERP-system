Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class MPR00006

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim VendorOpt As String
    Dim ItmNoOpt As String
    Dim ItmCatOpt As String
    Dim CustCatOpt As String
    Dim MPODateOpt As String
    Dim SortOpt As String


    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"

    Public rs_SYMCATCDE As DataSet
    Public rs_EXCEL As DataSet
    Public rs_VNBASINF

    Enum enuMPR00006
        MPO_No_enu
        MPO_Date_enu
        VENNO_enu
        Vendor_Name_enu
        Item_No_enu
        Item_Name_enu
        Item_Cateogry_Code_enu
        Item_Category_Desc_enu
        Custom_Category_Code_enu
        Custom_Category_Desc_enu
        UM_enu
        Qty_enu
        Currency_enu
        Unit_Price_enu
        Total_Amount_enu
        Delivery_Qty_enu
        Shipped_Qty_enu
        OS_Qty_enu
    End Enum
    Private Sub cboCustCatFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustCatFm.SelectedIndexChanged
        cboCustCatTo.Text = cboCustCatFm.Text
    End Sub
    Private Sub cboCustCatFm_Click()
    End Sub
    Private Sub cboItemCatFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemCatFm.SelectedIndexChanged
        cboItemCatTo.Text = cboItemCatFm.Text
    End Sub

    Private Sub cboItemCatFm_Click()
    End Sub
    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        If cboVenFm.Text <> "" And cboVenFm.Text <> "" Then
            VendorOpt = "Y"
            If Split(cboVenFm.Text, " - ")(0) > Split(cboVenTo.Text, " - ")(0) Then
                MsgBox("Vendor Number To < From!")
                cboVenFm.Focus()
                Exit Sub
            End If
        Else
            VendorOpt = "N"
        End If


        If txtItmNoFm.Text <> "" And txtItmNoTo.Text <> "" Then
            ItmNoOpt = "Y"
            If txtItmNoFm.Text > txtItmNoTo.Text Then
                MsgBox("Item No.  To < From!")
                txtItmNoFm.Focus()
                Exit Sub
            End If
        Else
            ItmNoOpt = "N"
        End If

        If cboItemCatFm.Text <> "" And cboItemCatTo.Text <> "" Then
            ItmCatOpt = "Y"
            If Split(cboItemCatFm.Text, " - ")(0) > Split(cboItemCatTo.Text, " - ")(0) Then
                MsgBox("Item Category  To < From!")
                cboItemCatFm.Focus()
                Exit Sub
            End If
        Else
            ItmCatOpt = "N"
        End If


        If cboCustCatFm.Text <> "" And cboCustCatTo.Text <> "" Then
            CustCatOpt = "Y"
            If Split(cboCustCatFm.Text, " - ")(0) > Split(cboCustCatTo.Text, " - ")(0) Then
                MsgBox("Custum Category  To < From!")
                cboCustCatFm.Focus()
                Exit Sub
            End If
        Else
            CustCatOpt = "N"
        End If


        If txtMPODateFm.Text <> "  /  /" Then
            If IsDate(txtMPODateFm.Text) = False Then
                MsgBox("Invalid Date")
                txtMPODateFm.Focus()
                Exit Sub
            End If
        End If

        If txtMPODateTo.Text <> "  /  /" Then
            If IsDate(txtMPODateTo.Text) = False Then
                MsgBox("Invalid Date")
                txtMPODateTo.Focus()
                Exit Sub
            End If
        End If

        If txtMPODateFm.Text <> "  /  /" And txtMPODateTo.Text <> "  /  /" Then
            MPODateOpt = "Y"
            If CDate(txtMPODateFm.Text) > CDate(txtMPODateTo.Text) Then
                MsgBox("From Date Must earlier than To Date!")
                txtMPODateFm.Focus()
                Exit Sub
            End If
        Else
            MPODateOpt = "N"
        End If

        If optByVendor.Checked = True Then
            SortOpt = 1
        ElseIf optByItemNo.Checked = True Then
            SortOpt = 2
        ElseIf OptByItemCat.Checked = True Then
            SortOpt = 3
        ElseIf OptByCustCat.Checked = True Then
            SortOpt = 4
        End If


        Call BeforeShow()
    End Sub
    Private Function BeforeShow() As Boolean

        BeforeShow = True
        Dim S As String
        Dim rsa As New DataSet
        Dim rs As New DataSet
        Dim ReportName(0) As String
        Dim ReportRS(0) As DataSet


        S = "sp_select_MPR00006 '', '"

        If cboVenFm.Text <> "" And cboVenTo.Text <> "" Then
            S = S + VendorOpt + "','" + Split(cboVenFm.Text, " - ")(0) & "','" & Split(cboVenTo.Text, " - ")(0) & "','"
        Else
            S = S + VendorOpt + "','" + "" + "','" + "" + "','"
        End If


        S = S + ItmNoOpt + "','" + txtItmNoFm.Text + "','" + txtItmNoTo.Text + "','"

        If cboItemCatFm.Text <> "" And cboItemCatTo.Text <> "" Then
            S = S + ItmCatOpt + "','" + Split(cboItemCatFm.Text, " - ")(0) & "','" & Split(cboItemCatTo.Text, " - ")(0) & "','"
        Else
            S = S + ItmCatOpt + "','" + "" + "','" + "" + "','"
        End If

        If cboCustCatFm.Text <> "" And cboCustCatTo.Text <> "" Then
            S = S + CustCatOpt + "','" + Split(cboCustCatFm.Text, " - ")(0) & "','" & Split(cboCustCatTo.Text, " - ")(0) & "','"
        Else
            S = S + CustCatOpt + "','" + "" + "','" + "" + "','"
        End If

        If txtMPODateFm.Text <> "  /  /" And txtMPODateTo.Text <> "  /  /" Then
            S = S + MPODateOpt + "','" + txtMPODateFm.Text & "','" & txtMPODateTo.Text & "','"
        Else
            S = S + MPODateOpt + "','" + "" + "','" + "" + "','"
        End If

        S = S + SortOpt + "'"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rsa, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Function
        Else
            rs_EXCEL = rsa.Copy
        End If

        Cursor = Cursors.Default



        If rs_EXCEL.Tables("result").Rows.Count = 0 Then  '*** if no record is found, prompt user
            MsgBox("Record not found!")
            BeforeShow = False
            Exit Function
        End If

        Call ExportToExcel()
        Cursor = Cursors.Default


    End Function
    Private Sub cboVenFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenFm.SelectedIndexChanged
        cboVenTo.Text = cboVenFm.Text
    End Sub

    Private Sub cboVenFm_Click()
    End Sub

    Private Sub MPR00006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = ERP00000.Icon

        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call Formstartup(Me.Name)
        Me.Cursor = Cursors.WaitCursor
        '#If useMTS Then
        '    Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        '        Me.MousePointer = vbDefault


        Dim S As String
        Dim rs() As DataSet

        gspStr = "sp_select_SYMCATCDE_level '','0'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            If rs_SYMCATCDE.Tables("result").Rows.Count > 0 Then
                cboItemCatFm.Items.Clear()
                cboItemCatTo.Items.Clear()
                For index As Integer = 0 To rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1
                    cboItemCatFm.Items.Add(rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catcde") + " - " + rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catdsc"))
                    cboItemCatTo.Items.Add(rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catcde") + " - " + rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catdsc"))
                Next
            End If
        End If

        Cursor = Cursors.Default



        gspStr = "sp_select_SYMCATCDE_level '','1'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            If rs_SYMCATCDE.Tables("result").Rows.Count > 0 Then
                cboCustCatFm.Items.Clear()
                cboCustCatTo.Items.Clear()
                For index As Integer = 0 To rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1
                    cboCustCatFm.Items.Add(rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catcde") + " - " + rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catdsc"))
                    cboCustCatTo.Items.Add(rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catcde") + " - " + rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catdsc"))
                Next
            End If
        End If




        gspStr = "sp_list_VNBASINF '' "
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            Call FillcboVen()
        End If


    End Sub


    Private Sub ExportToExcel()

        On Error GoTo Err_Handler

        Cursor = Cursors.WaitCursor ' Change mouse pointer to hourglass.
        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        Dim recArray As Object
        Dim lngRecCount As Long
        Dim fldCount As Integer
        Dim recCount As Long
        Dim iCol As Integer
        Dim iRow As Integer
        Dim rowHeader As Long
        Dim rowContent As Long


        rowHeader = 1
        rowContent = 2
        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        lngRecCount = rs_EXCEL.Tables("result").Rows.Count + rowContent
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

        fldCount = rs_EXCEL.Tables("result").Columns.Count

        For iCol = 1 To fldCount
            xlWs.Cells(rowHeader, iCol) = rs_EXCEL.Tables("result").Columns(iCol - 1).ColumnName.ToString()


            xlWs.Rows(rowHeader).Font.Bold = True
            xlWs.Rows(rowHeader).Font.Size = 10
        Next


        recCount = rs_EXCEL.Tables("result").Rows.Count
        If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then

            Call DataTableToWorkSheet(rs_EXCEL, xlWs, 0, 0)
            'EXCEL 2000 or 2002: Use CopyFromRecordset
            '            xlWs.Cells(rowContent, 1).CopyFromRecordset(rs_EXCEL)
        Else
            Dim tmp_i As Integer
            Dim tmp_j As Integer

            tmp_i = rs_EXCEL.Tables("result").Rows.Count
            tmp_j = rs_EXCEL.Tables("result").Columns.Count
            ReDim Preserve recArray(tmp_i, tmp_j)

            For index9 As Integer = 0 To tmp_i
                For index99 As Integer = 0 To tmp_j
                    recArray(index9, index99) = rs_EXCEL.Tables("result").Rows(index9)(index99)
                Next
            Next
            'tempz

            'EXCEL 97 or earlier: Use GetRows then copy array to Excel
            '    recArray = rs_EXCEL.GetRows
            recCount = UBound(recArray, 2) + 1
            For iCol = 0 To fldCount - 1
                For iRow = 0 To recCount - 1
                    If IsDate(recArray(iCol, iRow)) Then
                        recArray(iCol, iRow) = Format(recArray(iCol, iRow))
                    ElseIf IsArray(recArray(iCol, iRow)) Then
                        recArray(iCol, iRow) = "Array Field"
                    End If
                Next iRow
            Next iCol

            xlWs.Cells(rowContent, 1).resize(recCount, fldCount).Value = recArray

        End If

        xlApp.Selection.CurrentRegion.Columns.AutoFit()

        With xlWs
            .Range(.Cells(rowContent, enuMPR00006.Unit_Price_enu + 2), .Cells(recCount + rowContent + 1, enuMPR00006.Unit_Price_enu + 2)).NumberFormatLocal = "0.00"
            .Range(.Cells(rowContent, enuMPR00006.Total_Amount_enu + 2), .Cells(recCount + rowContent + 1, enuMPR00006.Total_Amount_enu + 2)).NumberFormatLocal = "0.00"
            .Range(.Cells(rowContent, enuMPR00006.Delivery_Qty_enu + 2), .Cells(recCount + rowContent + 1, enuMPR00006.Delivery_Qty_enu + 2)).NumberFormatLocal = "0.00"
            .Range(.Cells(rowContent, enuMPR00006.Shipped_Qty_enu + 2), .Cells(recCount + rowContent + 1, enuMPR00006.Shipped_Qty_enu + 2)).NumberFormatLocal = "0.00"
            .Range(.Cells(rowContent, enuMPR00006.OS_Qty_enu + 2), .Cells(recCount + rowContent + 1, enuMPR00006.OS_Qty_enu + 2)).NumberFormatLocal = "0.00"
        End With


        xlWs.Rows(rowHeader).RowHeight = 25

        Dim lngPages As Long

        lngPages = recCount / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If

        'Set print options
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

    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("result").Rows.Count > 0 Then
            cboVenFm.Items.Clear()
            cboVenTo.Items.Clear()
            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") + " - " + rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") + " - " + rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
            Next
        End If

    End Sub

    Private Sub txtItmNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNoFm.TextChanged
        txtItmNoTo.Text = txtItmNoFm.Text
    End Sub
    Private Sub txtItmNoFm_Change()
    End Sub

    Private Sub txtMPODateFm_Change()
    End Sub

    Private Sub txtMPODateFm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPODateFm.TextChanged
        txtMPODateTo.Text = txtMPODateFm.Text

    End Sub

    Private Sub DataTableToWorkSheet(ByRef ds As DataSet, ByRef sht As Excel.Worksheet, ByVal StartRow As Integer, ByVal StartCol As Integer)
        Dim CURRENT_PROCEDURE As String = "DataTableToWorkSheet"
        Dim iRows As Integer = ds.Tables("result").Rows.Count
        Dim iCols As Integer = ds.Tables("result").Columns.Count
        Dim j As Integer = 0
        Dim i As Integer = 0
        Dim dRow As DataRow

        Try
            With ds.Tables("result")
                'Do While Not .EOF
                For j = 0 To (iRows - 1)
                    dRow = .Rows(j)
                    For i = 0 To (iCols - 1)
                        If Not IsDBNull(.Columns(i)) Then
                            sht.Cells(StartRow + j + 2, StartCol + i + 1) = rs_EXCEL.Tables("result").Rows(StartRow + j)(StartCol + i)  ' FormatValue(ds, dRow, i, ds.Tables("details").Rows.Count > 0)
                            sht.Range(Chr(StartCol + i + 1 + 65) + (StartRow + j + 2).ToString).NumberFormat = "@"


                        End If
                    Next
                    '     sht.Range("A" + (StartRow + j + 1).ToString).NumberFormat = "@"
                Next
            End With

        Catch ex As Exception
            'Err_Log(ex, CURRENT_PROCEDURE)
            'Me.ReportStatus = Rpt_Status.Rpt_Errored
        End Try
    End Sub

    Private Sub txtMPODateFm_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtMPODateFm.MaskInputRejected

    End Sub
End Class
