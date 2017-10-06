Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class MPR00004

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim ItmNoOpt As String
    Dim ItmCatOpt As String
    Dim CustCatOpt As String
    Dim SortOpt As String



    Public rs_SYMCATCDE As DataSet
    Public rs_EXCEL As DataSet

    Enum enuMPR00004
        Item_No_enu
        Item_Name_enu
        UM_enu
        Currency_enu
        Unit_Price_enu
        Custom_UM_enu
        Item_Category_Code_enu
        Item_Category_Name_enu
        Custom_Category_Code_enu
        Custom_Category_Name_enu
    End Enum
    Private Sub cboItemCatFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemCatFm.SelectedIndexChanged
        cboItemCatTo.Text = cboItemCatFm.Text
    End Sub

    Private Sub cboCustCatFm_Click()
    End Sub
    Private Sub cboCustCatFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustCatFm.SelectedIndexChanged
        cboCustCatTo.Text = cboCustCatFm.Text
    End Sub

    Private Sub cboItemCatFm_Click()
    End Sub
    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        'If txtItmNofm.Text <> "" Then

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

        If optByItmNo.Checked = True Then
            SortOpt = 1
        ElseIf optByItmCat.Checked = True Then
            SortOpt = 2
        Else
            SortOpt = 3
        End If

        Call BeforeShow()

    End Sub
    Private Function BeforeShow() As Boolean

        BeforeShow = True
        Dim S As String
        Dim rsa As DataSet
        Dim rs As New DataSet
        Dim ReportName(0) As String
        Dim ReportRS(0) As DataSet





        S = "sp_select_MPR00004 '', '"
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

        S = S + SortOpt + "'"


        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rsa, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
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
    Private Sub MPR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Cursor = Cursors.Default


        Dim S As String
        Dim rs() As DataSet

        gspStr = "sp_select_SYMCATCDE_level '','0'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
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
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
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





        Cursor = Cursors.Default

    End Sub


    Private Sub ExportToExcel()

        On Error GoTo Err_Handler

        Cursor = Cursors.WaitCursor

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
            'EXCEL 2000 or 2002: Use CopyFromRecordset
            ' xlWs.Cells(rowContent, 1).CopyFromRecordset(rs_EXCEL)
            'tempzzzzz
            Call DataTableToWorkSheet(rs_EXCEL, xlWs, 0, 0)

        Else
            'EXCEL 97 or earlier: Use GetRows then copy array to Excel
            'recArray = rs_EXCEL.GetRows
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

            xlWs.Cells(rowContent, 1).resize(recCount, fldCount).value = recArray

        End If

        xlApp.Selection.CurrentRegion.Columns.AutoFit()

        With xlWs
            .Range(.Cells(rowContent, enuMPR00004.Unit_Price_enu + 1), .Cells(recCount + rowContent + 1, enuMPR00004.Unit_Price_enu + 1)).NumberFormatLocal = "0.00"
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

    Private Sub txtItmNoFm_Change()
    End Sub

    Private Sub txtItmNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNoFm.TextChanged
        txtItmNoTo.Text = txtItmNoFm.Text

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

    Private Sub optByCustCat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optByCustCat.CheckedChanged

    End Sub
End Class
