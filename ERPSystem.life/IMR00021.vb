
Imports Excel = Microsoft.Office.Interop.Excel
Public Class IMR00021


    Public rs_CUBASINF As DataSet
    Public rs_IMR00021 As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As DataSet
    Public objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Public dr() As DataRow



    Private Sub cmdItemList_Click()
        'frmItemList.strItem = txtItemList.Text
        'frmItemList.Show(vbModal)
        'txtItemList.Text = frmItemList.strSel
    End Sub

    Private Sub cmdShow_Click()


    End Sub

    Private Sub Form_Load()


        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        'optItmTyp_REG.Value = True
        'Call optItmTyp_Reg_Click()
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        'Dim itmType As String
        'Dim resultType As String
        ''Dim rs() As ADOR.Recordset

        'If Len(Trim(Me.txtItemList.Text)) <= 0 Then
        '    MsgBox("Please Input Item Number!")
        '    Exit Sub
        'End If

        '' Rem by Mark Lau 20090519
        ''    itmType = "ASS"
        ''    'If Me.optItmTyp_BOM.Value = True Then itmType = "BOM"
        ''
        ''    resultType = "ASS"
        ''    'If Me.optResult_Reg.Value = True Then resultType = "REG"
        ''    'If Me.optResult_Both.Value = True Then resultType = "BOTH"

        'If Me.optItmTyp_BOM.Checked = True Then itmType = "BOM"
        'If Me.optItmTyp_REG.Checked = True Then itmType = "REG"
        'If Me.optItmTyp_ASS.Checked = True Then itmType = "ASS"

        'resultType = "BOTH"



        'gspStr = "temp_sp_list_IMR00021   '','" + Trim(Me.txtItemList.Text) + "','" + itmType + "','" + resultType + "'"



        ''gspStr = " sp_list_IMR00021 'UCP','F10OM24158MIC,10A001A001A01,13B400-FDER080','ASS','BOTH'"

        'Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'rtnLong = execute_SQLStatement(gspStr, rs_IMR00021, rtnStr)

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMR00021 : " & rtnStr)
        '    Exit Sub
        'End If

        'Me.Cursor = Windows.Forms.Cursors.Default


        'If rs_IMR00021.Tables("RESULT").Rows.Count = 0 Then
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    MsgBox("IMR00021 no record!")
        '    Exit Sub
        'End If
        getAssItemList()

        If rs_IMR00021.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("IMR00021 no record!")
            Exit Sub
        End If

        Dim objRpt As New IMR00021Rpt
        objRpt.SetDataSource(rs_IMR00021.Tables("RESULT"))

        Dim frmReportView As New frmReport
        frmReportView.CrystalReportViewer.ReportSource = objRpt
        frmReportView.Show()



    End Sub
    Private Function anyResult() As Boolean
        anyResult = True

    End Function


    Private Sub getAssItemList()
        Dim itmType As String
        Dim resultType As String
        'Dim rs() As ADOR.Recordset

        If Len(Trim(Me.txtItemList.Text)) <= 0 Then
            MsgBox("Please Input Item Number!")
            Exit Sub
        End If

        ' Rem by Mark Lau 20090519
        '    itmType = "ASS"
        '    'If Me.optItmTyp_BOM.Value = True Then itmType = "BOM"
        '
        '    resultType = "ASS"
        '    'If Me.optResult_Reg.Value = True Then resultType = "REG"
        '    'If Me.optResult_Both.Value = True Then resultType = "BOTH"

        If Me.optItmTyp_BOM.Checked = True Then itmType = "BOM"
        If Me.optItmTyp_REG.Checked = True Then itmType = "REG"
        If Me.optItmTyp_ASS.Checked = True Then itmType = "ASS"

        resultType = "BOTH"



        gspStr = "temp_sp_list_IMR00021   '','" + Trim(Me.txtItemList.Text) + "','" + itmType + "','" + resultType + "'"



        'gspStr = " sp_list_IMR00021 'UCP','F10OM24158MIC,10A001A001A01,13B400-FDER080','ASS','BOTH'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00021, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00021 : " & rtnStr)
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.Default



    End Sub
    Private Sub cmdItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemList.Click
        frmItemList.strItem = txtItemList.Text
        'frmItemList.Show(vbModal)
        Call frmItemList.getform("IMR00021")
        frmItemList.ShowDialog()
        txtItemList.Text = frmItemList.strSel
    End Sub

    Public Function settxtItemList(ByVal strA As String)
        Me.txtItemList.Text = strA
        'Me.Show()
        'Me.Refresh()


    End Function

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub txtItemList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemList.TextChanged

    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub optItmTyp_BOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItmTyp_BOM.CheckedChanged

    End Sub
    Private Sub optItmTyp_REG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItmTyp_REG.CheckedChanged

    End Sub
    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub
    Private Sub optItmTyp_ASS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItmTyp_ASS.CheckedChanged

    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
    Private Sub optResult_Ass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optResult_Ass.CheckedChanged

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
    Private Sub grpSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpSearch.Enter

    End Sub

    Private Sub ExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExporttoExcel.Click
        If Len(Trim(Me.txtItemList.Text)) <= 0 Then
            MsgBox("Please Input Item Number!")
            Exit Sub
        End If
        getAssItemList()
        ExportToExcel()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim xlsApp As New Excel.ApplicationClass
        'Dim xlsWB As Excel.Workbook = Nothing
        'Dim xlsWS As Excel.Worksheet = Nothing

        'xlsApp = New Excel.Application



        ''Show the excel after creating process is completed
        'Try
        '    Dim Yourpath As String
        '    Yourpath = "C:\ERP_Excel"
        '    If (Not System.IO.Directory.Exists(Yourpath)) Then
        '        System.IO.Directory.CreateDirectory(Yourpath)
        '    End If


        '    '    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
        '    '            xlsWB.Application.DisplayAlerts = False
        '    xlsWB.SaveAs(Filename:="C:\ERP_Excel\" + "PGM0001AAAAAA_Excel", FileFormat:=52)




        'Catch ex As Exception
        '    MsgBox("File " + "C:\ERP_Excel\" + "PGM0001AAAAAA_Excel" + ".xls already exist. Please delete it before export a new one.")
        'End Try

        'xlsApp.Visible = True
        '' xlsWB.SaveAs(Filename:="C:\" + "PGR00001_2", ReadOnlyRecommended:=False, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)




        '' Release reference
        'rs_IMR00021 = Nothing
        ''tmp_PGM00013_hdr = Nothing

        'xlsWS = Nothing
        'xlsWB = Nothing
        'xlsApp = Nothing

        'Cursor = Cursors.Default
        'MsgBox("Generate Excel Complete.")
    End Sub
    Private Sub ExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty
        If rs_IMR00021.Tables("RESULT").Rows.Count >= 65535 Then
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

        Try
            With xlsApp
                headerCol = 1
                .Cells(headerRow, headerCol) = "Assortment".ToString

                headerCol += 1
                .Cells(headerRow, headerCol) = "Regular".ToString

                headerCol += 1
                .Cells(headerRow, headerCol) = "Color".ToString

                headerCol += 1
                .Cells(headerRow, headerCol) = "Bom".ToString

                headerCol += 1
                .Cells(headerRow, headerCol) = "Item Description".ToString


                .Range(.Cells(headerRow, 1), .Cells(headerRow, headerCol)).Font.Bold = True
                '.Range(.Cells(headerRow, 1), .Cells(headerRow, headerCol)).Font.Size = 10

                For i As Integer = 1 To rs_IMR00021.Tables("RESULT").Columns.Count
                    Select Case i
                        'Case 8, 9, 12, 13, 14, 15, 16, 32, 33, 34, 35, 36
                        Case 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 33, 34, 35, 36, 37
                            .Columns(i).NumberFormat = "@"
                    End Select
                Next

                Dim entry(rs_IMR00021.Tables("RESULT").Columns.Count - 1) As Object
                For i As Integer = 0 To rs_IMR00021.Tables("RESULT").Rows.Count - 1
                    Dim k As Integer = 0
                    For j As Integer = 0 To rs_IMR00021.Tables("RESULT").Columns.Count - 1
                        If Not (j = 0 Or j = 1 Or j = 6) Then

                            entry(k) = IIf(IsDBNull(rs_IMR00021.Tables("RESULT").Rows(i)(j)), "", rs_IMR00021.Tables("RESULT").Rows(i)(j))
                            k = k + 1
                        End If

                    Next
                    .Range(.Cells(headerRow + i + 1, 1), .Cells(headerRow + i + 1, headerCol)).Value = entry
                Next

                'Styling

                For i As Integer = 1 To rs_IMR00021.Tables("RESULT").Columns.Count
                    'If i = 18 Then
                    '    .Columns(i).WrapText = False
                    '    .Columns(i).EntireColumn.AutoFit()
                    '    .Columns(i).WrapText = True
                    '    .Columns(i).EntireColumn.AutoFit()
                    'Else
                    '    .Columns(i).EntireColumn.AutoFit()
                    'End If

                    Select Case i
                        Case 8, 9, 12, 13, 14, 15, 16, 32, 33, 34, 35, 36
                            .Columns(i).NumberFormat = "@"
                            .Columns(i).EntireColumn.AutoFit()
                        Case Else
                            .Columns(i).EntireColumn.AutoFit()
                    End Select
                Next
                .Rows(headerRow + 1 & ":" & headerRow + rs_IMR00021.Tables("RESULT").Rows.Count).EntireRow.AutoFit()
                .Rows(headerRow).RowHeight = 24
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
        rs_IMR00021 = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class