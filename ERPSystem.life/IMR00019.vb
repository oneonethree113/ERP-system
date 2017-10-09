Public Class IMR00019
    Dim rs_VNBASINF As DataSet
    Dim rs_IMR00019_S As DataSet
    Dim rs_Excel_S As DataSet
    Dim rs_IMR00019 As DataSet
    Dim rs_EXCEL As DataSet
    Private Sub IMR00019_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor


        Call Formstartup(Me.Name)

        Call Update_gs_Value("UCPP")
 


        cboRptTyp.Items.Add("External Item Image List (Detail)")
        cboRptTyp.Items.Add("External Item Image List (Summary)")

        cboRptTyp.SelectedIndex = 0

        gspStr = "sp_list_VNBASINF ''"

        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_VNBASINF:" & rtnStr)
            Exit Sub
        Else

            Call FillcboVen()
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FillcboVen()
        cboVnFm.Items.Clear()
        cboVnFm.Items.Add("")
       
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVnFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))


            Next
        End If
    End Sub

    Private Sub cboRptTyp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRptTyp.KeyUp
        auto_search_combo(cboRptTyp)
    End Sub

    Private Sub cboRptTyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRptTyp.SelectedIndexChanged

    End Sub

    Private Sub cboVnFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVnFm.KeyUp
        auto_search_combo(cboVnFm)
    End Sub

    Private Sub cboVnFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVnFm.SelectedIndexChanged

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim S As String
        Dim Co As String
        Dim VnFm As String
        Dim ITMCREDATFM As String
        Dim ITMCREDATTO As String
        Dim rs() As ADOR.Recordset

        Me.Cursor = Cursors.WaitCursor


        If cboRptTyp.SelectedIndex = 0 Then
            If cboVnFm.Text = "" Then
                VnFm = ""
            Else
                VnFm = Split(cboVnFm.Text, " - ")(0)
            End If

            If cboVnFm.Text = "" Then
                MsgBox("Please Input the Vendor", vbInformation, "Message")
                cboVnFm.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If cboVnFm.Text > "999999999" Then
                MsgBox("Vendor is invalid", vbInformation, "Message")
                cboVnFm.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        'XXXXXXXXXXXXXXXXXXXX
        ITMCREDATFM = txtItmCreDatFm.Text
        ITMCREDATTO = txtItmCreDatTo.Text

        'XXXXXXXXXXXXXXXXXXXXX
        If txtItmCreDatFm.Text <> "  /  /" Then
            If IsDate(txtItmCreDatFm.Text) = False Then
                MsgBox("Item Create From Date invalid !", vbInformation, "Message")
                txtItmCreDatFm.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If txtItmCreDatTo.Text <> "  /  /" Then
            If IsDate(txtItmCreDatTo.Text) = False Then
                MsgBox("Item Create To Date invalid !", vbInformation, "Message")
                txtItmCreDatTo.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If



        If txtItmCreDatFm.Text <> "  /  /" And txtItmCreDatTo.Text <> "  /  /" Then
            If Mid(txtItmCreDatFm.Text, 7) > Mid(txtItmCreDatTo.Text, 7) Then
                MsgBox("Item Create Date: End Date < Start date ! (YY)", vbInformation, "Message")
                txtItmCreDatFm.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            ElseIf Mid(txtItmCreDatFm.Text, 7) = Mid(txtItmCreDatTo.Text, 7) Then
                If Strings.Left(txtItmCreDatFm.Text, 2) > Strings.Left(txtItmCreDatTo.Text, 2) Then
                    MsgBox("Item Create Date: End Date < Start date ! (MM)", vbInformation, "Message")
                    txtItmCreDatFm.Focus()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                ElseIf Strings.Left(txtItmCreDatFm.Text, 2) = Strings.Left(txtItmCreDatTo.Text, 2) Then
                    If Mid(txtItmCreDatFm.Text, 4, 2) > Mid(txtItmCreDatTo.Text, 4, 2) Then
                        MsgBox("Item Create Date: End Date < Start date ! (DD)", vbInformation, "Message")
                        txtItmCreDatFm.Focus()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            End If
        End If

        If txtItmCreDatFm.Text = "  /  /" Then
            ITMCREDATFM = ""
        Else
            ITMCREDATFM = txtItmCreDatFm.Text & " 00:00:00.000"
        End If

        If txtItmCreDatTo.Text = "  /  /" Then
            ITMCREDATTO = ""
        Else
            ITMCREDATTO = txtItmCreDatTo.Text & " 23:59:59.99"
        End If




        'Hardcode for temp use
        Call Update_gs_Value("UCPP")


        If cboRptTyp.SelectedIndex = 1 Then
            gspStr = "sp_select_IMR00019_S ''," & _
                "'" & ITMCREDATFM & _
                "','" & ITMCREDATTO & _
                "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_IMR00019_S, rtnStr)


            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on cmdShow_Click sp_select_IMR00019_S:" & rtnStr)
            Else

                If rs_IMR00019_S.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Cursors.Default
                    MsgBox("No Record Found")

                    Exit Sub
                Else
                    rs_Excel_S = rs_IMR00019_S
                    Call CmdExportExcel_S_Click()
                End If
            End If
        Else
            gspStr = "sp_select_IMR00019 ''" & _
                ",'" & VnFm & _
                "','" & ITMCREDATFM & _
                "','" & ITMCREDATTO & _
                "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_IMR00019, rtnStr)


            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on cmdShow_Click sp_select_IMR00019:" & rtnStr)
            Else

                If rs_IMR00019.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Cursors.Default
                    MsgBox("No Record Found")

                    Exit Sub
                Else
                    rs_EXCEL = rs_IMR00019
                    Call CmdExportExcel_Click()
                End If
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Function CmdExportExcel_Click()

        Me.Cursor = Cursors.WaitCursor ' Change mouse pointer to hourglass.

        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet

        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True

        xlApp.UserControl = True

        Dim col As Integer
        Dim row As Integer

        With xlWs

            '------------------------------------------------------------------
            ' HEADER INFORMATION
            '------------------------------------------------------------------

            ' Factoy Name
            Dim sFactoryName As String
            sFactoryName = "Factory Name : " + rs_EXCEL.Tables("RESULT").Rows(0).Item("vbi_vennam")

            .Range(.Cells(1, 1), .Cells(1, 10)).Merge()
            .Range(.Cells(1, 1), .Cells(1, 10)).Value = sFactoryName
            .Range(.Cells(1, 1), .Cells(1, 10)).RowHeight = 16.5
            .Range(.Cells(1, 1), .Cells(1, 10)).Font.Size = 12
            .Range(.Cells(1, 1), .Cells(1, 10)).Font.Bold = False
            .Range(.Cells(1, 1), .Cells(1, 10)).HorizontalAlignment = 2


            ' Factoy Address
            Dim sAddress As String
            sAddress = "Address : " + rs_EXCEL.Tables("RESULT").Rows(0).Item("vci_adr")

            .Range(.Cells(2, 1), .Cells(2, 1)).Merge()
            .Range(.Cells(2, 1), .Cells(2, 1)).Value = sAddress
            .Range(.Cells(2, 1), .Cells(2, 1)).RowHeight = 16.5
            .Range(.Cells(2, 1), .Cells(2, 1)).Font.Size = 12
            .Range(.Cells(2, 1), .Cells(2, 1)).Font.Bold = False
            .Range(.Cells(2, 1), .Cells(2, 1)).HorizontalAlignment = 2
            .Range(.Cells(2, 1), .Cells(2, 1)).WrapText = False
            '        .Range(.Cells(2, 1), .Cells(2, 10)).EntireRow.AutoFit

            ' Date Range
            Dim sDateRange As String
            sDateRange = "Item Create Date from " + rs_EXCEL.Tables("RESULT").Rows(0).Item("itmcredateFm") + " to " + rs_EXCEL.Tables("RESULT").Rows(0).Item("itmcredateto")

            .Range(.Cells(1, 20), .Cells(1, 29)).Merge()
            .Range(.Cells(1, 20), .Cells(1, 29)).Value = sDateRange
            .Range(.Cells(1, 20), .Cells(1, 29)).RowHeight = 16.5
            .Range(.Cells(1, 20), .Cells(1, 29)).Font.Size = 12
            .Range(.Cells(1, 20), .Cells(1, 29)).Font.Bold = False
            .Range(.Cells(1, 20), .Cells(1, 29)).HorizontalAlignment = 4



            ' Column 1 - Vendor Item No.
            row = 4
            col = 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "Vendor Item No."
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 16
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 2 - UCP Item No.
            row = 4
            'col = 2
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "UCP Item No."
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 16
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 3 - English Description
            row = 4
            'col = 3
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "English Description"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 35
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 4 - Photo
            row = 4
            'col = 4
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "Photo"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 18
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 5 - UM
            row = 4
            'col = 5
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "UM"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 6 to 8 - Packing
            row = 4
            'col = 6
            col = col + 1
            .Range(.Cells(row, col), .Cells(row, col + 2)).Merge()
            .Range(.Cells(row, col), .Cells(row, col + 2)).Value = "Packing"
            .Range(.Cells(row, col), .Cells(row, col + 2)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row, col + 2)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row, col + 2)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col + 2)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 2)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col + 2)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 2)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 2)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 2)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            row = 5
            'col = 6
            col = col
            .Cells(row, col).Value = "Inner"
            .Cells(row, col).RowHeight = 16.5
            .Cells(row, col).ColumnWidth = 6
            .Cells(row, col).Font.Size = 12
            .Cells(row, col).Font.Bold = True
            .Cells(row, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Cells(row, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Cells(row, col).WrapText = True

            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            row = 5
            'col = 7
            col = col + 1
            .Cells(row, col).Value = "Master"
            .Cells(row, col).RowHeight = 16.5
            .Cells(row, col).ColumnWidth = 7
            .Cells(row, col).Font.Size = 12
            .Cells(row, col).Font.Bold = True
            .Cells(row, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Cells(row, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Cells(row, col).WrapText = True

            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            row = 5
            'col = 8
            col = col + 1
            .Cells(row, col).Value = "CBM"
            .Cells(row, col).RowHeight = 16.5
            .Cells(row, col).ColumnWidth = 6
            .Cells(row, col).Font.Size = 12
            .Cells(row, col).Font.Bold = True
            .Cells(row, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Cells(row, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Cells(row, col).WrapText = True

            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(row, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 9 - Packing Instruction
            row = 4
            'col = 9
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "Packing Instruction"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 25
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 10 to 13 - Factory Cost
            row = 4
            'col = 10
            col = col + 1
            .Range(.Cells(row, col), .Cells(row, col + 3)).Merge()
            .Range(.Cells(row, col), .Cells(row, col + 3)).Value = "Factory Cost"
            .Range(.Cells(row, col), .Cells(row, col + 3)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row, col + 3)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row, col + 3)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col + 3)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col + 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 3)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 3)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col + 3)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 3)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 3)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 3)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            row = 5
            'col = 10
            col = col
            .Cells(row, col).ColumnWidth = 5
            .Cells(row, col + 1).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row, col + 1)).Merge()
            .Range(.Cells(row, col), .Cells(row, col + 1)).Value = "Item Cost"
            .Range(.Cells(row, col), .Cells(row, col + 1)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row, col + 1)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row, col + 1)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col + 1)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 1)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            row = 5
            'col = 12
            col = col + 2
            .Cells(row, col).ColumnWidth = 5
            .Cells(row, col + 1).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row, col + 1)).Merge()
            .Range(.Cells(row, col), .Cells(row, col + 1)).Value = "BOM Cost"
            .Range(.Cells(row, col), .Cells(row, col + 1)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row, col + 1)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row, col + 1)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col + 1)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col + 1)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 14 to 15 - Total Cost
            row = 4
            'col = 14
            col = col + 2
            .Cells(row, col).ColumnWidth = 5
            .Cells(row, col + 1).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Value = "Total Cost"
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row + 1, col + 1)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            'Lester Wu 2005-04-27
            ' Fty Price Term
            'Lester Wu 2005-04-27
            row = 4
            'col = 16
            col = col + 2
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "Fty Price Term"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 16 - IM Markup
            row = 4
            'col = 16
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "IM Markup"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            'Item Price
            row = 4
            'col = 14
            col = col + 1
            .Cells(row, col).ColumnWidth = 5
            .Cells(row, col + 1).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Value = "Item Price"
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row + 1, col + 1)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            'BOM Price
            row = 4
            'col = 14
            col = col + 2
            .Cells(row, col).ColumnWidth = 5
            .Cells(row, col + 1).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Value = "BOM Price"
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row + 1, col + 1)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 17 to 18 - Basic Price
            row = 4
            'col = 17
            col = col + 2
            .Cells(row, col).ColumnWidth = 5
            .Cells(row, col + 1).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Value = "Basic Price"
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row + 1, col + 1)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            ' Column 19 - Price Term
            row = 4
            'col = 19
            col = col + 2
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "Price Term"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 20 - MOQ
            row = 4
            'col = 20
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "MOQ (Ctn)"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 21 to 22 - MOA
            row = 4
            'col = 21
            col = col + 1
            .Cells(row, col).ColumnWidth = 5
            .Cells(row, col + 1).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Value = "MOA"
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).RowHeight = 16.5
            '        .Range(.Cells(row, col), .Cells(row + 1, col + 1)).ColumnWidth = 5
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col + 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous



            ' Column 23 - Mold Cost
            row = 4
            'col = 23
            col = col + 2
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "Mold Cost"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 24 - Mold Charge
            row = 4
            'col = 24
            col = col + 1
            .Range(.Cells(row, col), .Cells(row + 1, col)).Merge()
            .Range(.Cells(row, col), .Cells(row + 1, col)).Value = "Mold Charge"
            .Range(.Cells(row, col), .Cells(row + 1, col)).RowHeight = 16.5
            .Range(.Cells(row, col), .Cells(row + 1, col)).ColumnWidth = 8
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row + 1, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row + 1, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row + 1, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row + 1, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            Dim sResultString As String

            For row = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                For col = 1 To 27

                    sResultString = ""

                    Select Case col
                        Case 1
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ivi_venitm")
                            .Cells(row + 5 + 1, col).NumberFormatLocal = "@"
                            .Cells(row + 5 + 1, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                            '                    .Cells(row + 5, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
                        Case 2
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_itmno")
                            .Cells(row + 5 + 1, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                            '                    .Cells(row + 5, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
                        Case 3
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_engdsc")
                            .Cells(row + 5 + 1, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                            '                    .Cells(row + 5, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
                        Case 4
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_imgpth")
                            If sResultString <> "" Then
                                Call InsertPictureInRange(sResultString, xlWs.Range(Chr(Asc("A") + col - 1) & Trim(Str(row + 5 + 1)) & ":" & Chr(Asc("A") + col - 1) & Trim(Str(row + 1 + 5))), xlWs)
                            End If
                        Case 5
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ipi_pckunt")
                        Case 6
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ipi_inrqty")
                        Case 7
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ipi_mtrqty")
                        Case 8
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ipi_cbm")
                        Case 9
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ipi_pckitr")
                            .Cells(row + 5 + 1, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                            '                    .Cells(row + 5, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
                        Case 10
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_curcde")
                        Case 11
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_ftyprc")
                        Case 12
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_curcde")
                        Case 13
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_bomcst")
                        Case 14
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_curcde")
                        Case 15
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_ttlcst")
                        Case 16
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_ftyprctrm")       ' Fty Price Term
                        Case 17
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("yfi_fml")
                        Case 18
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_bcurcde")       'Item Price Curr
                        Case 19
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_itmprc")       'Item Price Value
                        Case 20
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_bcurcde")       'BOM Price Curr
                        Case 21
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_bomprc")       'BOM Price Value
                        Case 22
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_bcurcde")
                        Case 23
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_basprc")
                        Case 24
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("imu_prctrm")
                        Case 25
                            sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_moqctn")
                        Case 26
                            If rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_moqctn") = 0 Then
                                sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_curcde")
                            End If
                        Case 27
                            If rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_moqctn") = 0 Then
                                sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("ibi_moa")
                            End If
                    End Select

                    If col <> 4 Then
                        .Cells(row + 5 + 1, col).Value = sResultString
                        .Cells(row + 5 + 1, col).RowHeight = 100
                        .Cells(row + 5 + 1, col).Font.Size = 12
                        .Cells(row + 5 + 1, col).Font.Bold = False
                        .Cells(row + 5 + 1, col).WrapText = True
                    End If

                    '                .Cells(row + 5, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
                    '                .Cells(row + 5, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = xlContinuous
                    '                .Cells(row + 5, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = xlContinuous
                    '                .Cells(row + 5, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = xlContinuous
                    '                .Cells(row + 5, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = xlContinuous
                Next col

            Next row

            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(5, 1), .Cells(row + 4 + 1, 29)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous




        End With


        Dim lngPages As Long

        lngPages = rs_EXCEL.Tables("RESULT").Rows.Count / 8 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If


        With xlWs.PageSetup
            .PrintTitleRows = "$4:$5"
            .LeftHeader = ""
            .CenterHeader = ""
            .RightHeader = ""
            .LeftFooter = ""
            .CenterFooter = "&P / &N"
            .RightFooter = ""
            .LeftMargin = xlApp.InchesToPoints(0.196850393700787)
            .RightMargin = xlApp.InchesToPoints(0.196850393700787)
            .TopMargin = xlApp.InchesToPoints(0.78740157480315)
            .BottomMargin = xlApp.InchesToPoints(0.393700787401575)
            .HeaderMargin = xlApp.InchesToPoints(0.47244094488189)
            .FooterMargin = xlApp.InchesToPoints(0.196850393700787)
            .PrintHeadings = False
            .PrintGridlines = False
            .PrintComments = Microsoft.Office.Interop.Excel.XlPrintLocation.xlPrintNoComments
            .PrintQuality = 600
            .CenterHorizontally = True
            .CenterVertically = False
            .FitToPagesWide = 1
            .FitToPagesTall = lngPages
            .Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape
            .Draft = False
            .PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4
            .FirstPageNumber = Microsoft.Office.Interop.Excel.Constants.xlAutomatic
            .Order = Microsoft.Office.Interop.Excel.XlOrder.xlDownThenOver
            .BlackAndWhite = False
            '.Zoom = 55
            .Zoom = False
            '       .PrintErrors = xlPrintErrorsDisplayed
        End With


        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        Me.Cursor = Cursors.Default

    End Function
    Sub InsertPictureInRange(ByVal PictureFileName As String, ByVal TargetCells As Microsoft.Office.Interop.Excel.Range, ByRef xls As Microsoft.Office.Interop.Excel.Worksheet)
        Dim p As Object, t As Double, l As Double, W As Double, H As Double


        If Dir(PictureFileName) = "" Then Exit Sub

        With xls
            If Dir(PictureFileName) <> "" Then
                p = .Pictures.Insert(PictureFileName)
                ' determine positions
                With TargetCells
                    t = .Top
                    l = .Left
                    'w = .Offset(0, .Columns.count).left - .left
                    'h = .Offset(.rows.count, 0).top - .top
                    H = .Offset(0, .Columns.Count).Left - .Left
                    W = .Offset(.Rows.Count, 0).Top - .Top
                End With
                ' position picture
                If W > H Then
                    H = H * (95 / W)
                    W = 95
                Else
                    W = W * (95 / H)
                    H = 95
                End If

                With p
                    .Top = t
                    .Left = l
                    .width = W
                    .Height = H
                End With
                p = Nothing
            End If
        End With
    End Sub
    Private Function CmdExportExcel_S_Click()

        Me.Cursor = Cursors.WaitCursor  ' Change mouse pointer to hourglass.
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet



        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True

        xlApp.UserControl = True

        Dim col As Integer
        Dim row As Integer

        With xlWs
            ' Column 1 - Vendor Name
            row = 1
            col = 1
            .Range(.Cells(row, col), .Cells(row, col)).Merge()
            .Range(.Cells(row, col), .Cells(row, col)).Value = "Vendor Name"
            .Range(.Cells(row, col), .Cells(row, col)).RowHeight = 40
            .Range(.Cells(row, col), .Cells(row, col)).ColumnWidth = 55
            .Range(.Cells(row, col), .Cells(row, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 2 - Total No. Of Item
            row = 1
            col = 2
            .Range(.Cells(row, col), .Cells(row, col)).Merge()
            .Range(.Cells(row, col), .Cells(row, col)).Value = "Total No. Of Item"
            .Range(.Cells(row, col), .Cells(row, col)).RowHeight = 40
            .Range(.Cells(row, col), .Cells(row, col)).ColumnWidth = 15
            .Range(.Cells(row, col), .Cells(row, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            ' Column 3 - Missing Packing & Item Cost
            row = 1
            col = 3
            .Range(.Cells(row, col), .Cells(row, col)).Merge()
            .Range(.Cells(row, col), .Cells(row, col)).Value = "Missing Packing & Item Cost"
            .Range(.Cells(row, col), .Cells(row, col)).RowHeight = 40
            .Range(.Cells(row, col), .Cells(row, col)).ColumnWidth = 15
            .Range(.Cells(row, col), .Cells(row, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            ' Column 4 - Missing Item Cost
            row = 1
            col = 4
            .Range(.Cells(row, col), .Cells(row, col)).Merge()
            .Range(.Cells(row, col), .Cells(row, col)).Value = "Missing Item Cost"
            .Range(.Cells(row, col), .Cells(row, col)).RowHeight = 40
            .Range(.Cells(row, col), .Cells(row, col)).ColumnWidth = 15
            .Range(.Cells(row, col), .Cells(row, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            ' Column 5 - Missing Photo
            row = 1
            col = 5
            .Range(.Cells(row, col), .Cells(row, col)).Merge()
            .Range(.Cells(row, col), .Cells(row, col)).Value = "Missing Photo"
            .Range(.Cells(row, col), .Cells(row, col)).RowHeight = 40
            .Range(.Cells(row, col), .Cells(row, col)).ColumnWidth = 15
            .Range(.Cells(row, col), .Cells(row, col)).Font.Size = 12
            .Range(.Cells(row, col), .Cells(row, col)).Font.Bold = True
            .Range(.Cells(row, col), .Cells(row, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
            .Range(.Cells(row, col), .Cells(row, col)).WrapText = True

            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(row, col), .Cells(row, col)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


            Dim sResultString As String
            'For row = 2 To rs_Excel_S.Tables("RESULT").Rows.Count + 1
            For row = 0 To rs_Excel_S.Tables("RESULT").Rows.Count - 1
                For col = 1 To 5

                    sResultString = ""

                    Select Case col
                        Case 1
                            sResultString = rs_Excel_S.Tables("RESULT").Rows(row).Item("vendor")
                            .Cells(row + 2, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                        Case 2
                            sResultString = rs_Excel_S.Tables("RESULT").Rows(row).Item("total")
                            .Cells(row + 2, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                        Case 3
                            sResultString = rs_Excel_S.Tables("RESULT").Rows(row).Item("miss_cst_pck")
                            .Cells(row + 2, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                        Case 4
                            sResultString = rs_Excel_S.Tables("RESULT").Rows(row).Item("miss_cst")
                            .Cells(row + 2, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                        Case 5
                            sResultString = rs_Excel_S.Tables("RESULT").Rows(row).Item("miss_image")
                            .Cells(row + 2, col).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                    End Select

                    .Cells(row + 2, col).Value = sResultString
                    .Cells(row + 2, col).RowHeight = 16.5
                    .Cells(row + 2, col).Font.Size = 12
                    .Cells(row + 2, col).Font.Bold = False
                    .Cells(row + 2, col).WrapText = True

                    .Cells(row + 2, col).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
                    .Cells(row + 2, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Cells(row + 2, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Cells(row + 2, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Cells(row + 2, col).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Next col


            Next row






        End With


        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        Me.Cursor = Cursors.Default

    End Function







End Class