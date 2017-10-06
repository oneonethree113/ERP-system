Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class IMR00034

    Dim rs_IMR00034 As New DataSet
    Dim rs_Excel As New ADODB.Recordset

    Dim col_InputDate As Integer

    Private Sub IMR00034_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        loadItemStatus()

        cboRptFmt.Items.Add("New Format")
        'cboRptFmt.Items.Add("Standard Format (2013-04)")
        'cboRptFmt.Items.Add("Standard Format (2014-04)")
        cboRptFmt.SelectedIndex = 0
    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        If Len(Trim(txt_S_ItmNo.Text)) > 1000 Then
            MsgBox("Item Number list exceeds maximum allowable length (1000 Characters).", MsgBoxStyle.Exclamation, "Invalid Input")
            highlight_date(txt_S_ItmNo, Nothing)
            Exit Sub
        End If

        If Len(Trim(txt_S_PriCustAll.Text)) > 1000 Then
            MsgBox("Primary Customer list exceeds maximum allowable length (1000 Characters).", MsgBoxStyle.Exclamation, "Invalid Input")
            txt_S_PriCustAll.Focus()
            Exit Sub
        End If

        If Len(Trim(txt_S_SecCustAll.Text)) > 1000 Then
            MsgBox("Secondary Customer list exceeds maximum allowable length (1000 Characters).", MsgBoxStyle.Exclamation, "Invalid Input")
            txt_S_SecCustAll.Focus()
            Exit Sub
        End If

        If Len(Trim(txt_S_DV.Text)) > 1000 Then
            MsgBox("Design Vendor list exceeds maximum allowable length (1000 Characters).", MsgBoxStyle.Exclamation, "Invalid Input")
            txt_S_DV.Focus()
            Exit Sub
        End If

        If txt_S_ItmUpddatFm.Text <> "  /  /         :" Then
            If Not DateTime.TryParse(txt_S_ItmUpddatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                MsgBox("Item Update Date: Invalid Start Date", MsgBoxStyle.Information, "Invalid Input")
                highlight_date(txt_S_ItmUpddatFm, Nothing)
                Exit Sub
            End If
        End If
        If txt_S_ItmUpddatTo.Text <> "  /  /         :" Then
            If Not DateTime.TryParse(txt_S_ItmUpddatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                MsgBox("Item Update Date: Invalid End Date", MsgBoxStyle.Information, "Invalid Input")
                highlight_date(txt_S_ItmUpddatTo, Nothing)
                Exit Sub
            End If
        End If

        If txt_S_Period.Text <> "    -" Then
            If Not DateTime.TryParse(txt_S_Period.Text.Replace("   ", " "), "9999-12") Then
                MsgBox("Item Update Date: Invalid End Date", MsgBoxStyle.Information, "Invalid Input")
                highlight_date(txt_S_Period, Nothing)
                Exit Sub
            End If
        End If

        If txt_S_ItmUpddatFm.Text <> "  /  /         :" Or txt_S_ItmUpddatTo.Text <> "  /  /         :" Then
            If DateTime.TryParse(txt_S_ItmUpddatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                If Not DateTime.TryParse(txt_S_ItmUpddatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                    MsgBox("Item Update Date: Missing End Date", MsgBoxStyle.Information, "Invalid Input")
                    highlight_date(txt_S_ItmUpddatTo, Nothing)
                    Exit Sub
                End If
            End If
            If DateTime.TryParse(txt_S_ItmUpddatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                If Not DateTime.TryParse(txt_S_ItmUpddatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                    MsgBox("Item Update Date: Missing Start Date", MsgBoxStyle.Information, "Invalid Input")
                    highlight_date(txt_S_ItmUpddatFm, Nothing)
                    Exit Sub
                End If
            End If
            If txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(6, 4) > txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(6, 4) Then
                MsgBox("Item Update Date: End Year < Start Year", MsgBoxStyle.Exclamation, "Invalid Input")
                highlight_date(txt_S_ItmUpddatFm, Nothing)
                Exit Sub
            ElseIf txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(6, 4) = txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(6, 4) Then
                If txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(0, 2) > txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(0, 2) Then
                    MsgBox("Item Update Date: End Month < Start Month", MsgBoxStyle.Exclamation, "Invalid Input")
                    highlight_date(txt_S_ItmUpddatFm, Nothing)
                    Exit Sub
                ElseIf txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(0, 2) = txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(0, 2) Then
                    If txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(3, 2) > txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(3, 2) Then
                        MsgBox("Item Update Date: End Date < Start Date", MsgBoxStyle.Exclamation, "Invalid Input")
                        highlight_date(txt_S_ItmUpddatFm, Nothing)
                        Exit Sub
                    ElseIf txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(3, 2) = txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(3, 2) Then
                        If txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(11, 2) > txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(11, 2) Then
                            MsgBox("Item Update Date: End Hour < Start Hour", MsgBoxStyle.Exclamation, "Invalid Input")
                            highlight_date(txt_S_ItmUpddatFm, Nothing)
                            Exit Sub
                        ElseIf txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(11, 2) = txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(11, 2) Then
                            If txt_S_ItmUpddatFm.Text.Replace("   ", " ").Substring(14, 2) > txt_S_ItmUpddatTo.Text.Replace("   ", " ").Substring(14, 2) Then
                                MsgBox("Item Update Date: End Minute < Start Minute", MsgBoxStyle.Exclamation, "Invalid Input")
                                highlight_date(txt_S_ItmUpddatFm, Nothing)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If txt_S_PrcCredatFm.Text <> "  /  /         :" Then
            If Not DateTime.TryParse(txt_S_PrcCredatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                MsgBox("Price Create Date: Invalid Start Date", MsgBoxStyle.Information, "Invalid Input")
                highlight_date(txt_S_PrcCredatFm, Nothing)
                Exit Sub
            End If
        End If
        If txt_S_PrcCredatTo.Text <> "  /  /         :" Then
            If Not DateTime.TryParse(txt_S_PrcCredatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                MsgBox("Price Create Date: Invalid End Date", MsgBoxStyle.Information, "Invalid Input")
                highlight_date(txt_S_PrcCredatTo, Nothing)
                Exit Sub
            End If
        End If
        If txt_S_PrcCredatFm.Text <> "  /  /         :" Or txt_S_PrcCredatTo.Text <> "  /  /         :" Then
            If DateTime.TryParse(txt_S_PrcCredatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                If Not DateTime.TryParse(txt_S_PrcCredatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                    MsgBox("Price Create Date: Missing End Date", MsgBoxStyle.Information, "Invalid Input")
                    highlight_date(txt_S_PrcCredatTo, Nothing)
                    Exit Sub
                End If
            End If
            If DateTime.TryParse(txt_S_PrcCredatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                If Not DateTime.TryParse(txt_S_PrcCredatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                    MsgBox("Price Create Date: Missing Start Date", MsgBoxStyle.Information, "Invalid Input")
                    highlight_date(txt_S_PrcCredatFm, Nothing)
                    Exit Sub
                End If
            End If
            If txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(6, 4) > txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(6, 4) Then
                MsgBox("Price Create Date: End Year < Start Year", MsgBoxStyle.Exclamation, "Invalid Input")
                highlight_date(txt_S_PrcCredatFm, Nothing)
                Exit Sub
            ElseIf txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(6, 4) = txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(6, 4) Then
                If txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(0, 2) > txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(0, 2) Then
                    MsgBox("Price Create Date: End Month < Start Month", MsgBoxStyle.Exclamation, "Invalid Input")
                    highlight_date(txt_S_PrcCredatFm, Nothing)
                    Exit Sub
                ElseIf txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(0, 2) = txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(0, 2) Then
                    If txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(3, 2) > txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(3, 2) Then
                        MsgBox("Price Create Date: End Date < Start Date", MsgBoxStyle.Exclamation, "Invalid Input")
                        highlight_date(txt_S_PrcCredatFm, Nothing)
                        Exit Sub
                    ElseIf txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(3, 2) = txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(3, 2) Then
                        If txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(11, 2) > txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(11, 2) Then
                            MsgBox("Price Create Date: End Hour < Start Hour", MsgBoxStyle.Exclamation, "Invalid Input")
                            highlight_date(txt_S_PrcCredatFm, Nothing)
                            Exit Sub
                        ElseIf txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(11, 2) = txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(11, 2) Then
                            If txt_S_PrcCredatFm.Text.Replace("   ", " ").Substring(14, 2) > txt_S_PrcCredatTo.Text.Replace("   ", " ").Substring(14, 2) Then
                                MsgBox("Price Create Date: End Minute < Start Minute", MsgBoxStyle.Exclamation, "Invalid Input")
                                highlight_date(txt_S_PrcCredatFm, Nothing)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If txt_S_PrcUpddatFm.Text <> "  /  /         :" Then
            If Not DateTime.TryParse(txt_S_PrcUpddatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                MsgBox("Price Update Date: Invalid Start Date", MsgBoxStyle.Information, "Invalid Input")
                highlight_date(txt_S_PrcUpddatFm, Nothing)
                Exit Sub
            End If
        End If
        If txt_S_PrcUpddatTo.Text <> "  /  /         :" Then
            If Not DateTime.TryParse(txt_S_PrcUpddatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                MsgBox("Price Update Date: Invalid End Date", MsgBoxStyle.Information, "Invalid Input")
                highlight_date(txt_S_PrcUpddatTo, Nothing)
                Exit Sub
            End If
        End If
        If txt_S_PrcUpddatFm.Text <> "  /  /         :" Or txt_S_PrcUpddatTo.Text <> "  /  /         :" Then
            If DateTime.TryParse(txt_S_PrcUpddatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                If Not DateTime.TryParse(txt_S_PrcUpddatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                    MsgBox("Price Update Date: Missing End Date", MsgBoxStyle.Information, "Invalid Input")
                    highlight_date(txt_S_PrcUpddatTo, Nothing)
                    Exit Sub
                End If
            End If
            If DateTime.TryParse(txt_S_PrcUpddatTo.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                If Not DateTime.TryParse(txt_S_PrcUpddatFm.Text.Replace("   ", " "), "12/31/9999 23:59") Then
                    MsgBox("Price Update Date: Missing Start Date", MsgBoxStyle.Information, "Invalid Input")
                    highlight_date(txt_S_PrcUpddatFm, Nothing)
                    Exit Sub
                End If
            End If
            If txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(6, 4) > txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(6, 4) Then
                MsgBox("Price Update Date: End Year < Start Year", MsgBoxStyle.Exclamation, "Invalid Input")
                highlight_date(txt_S_PrcUpddatFm, Nothing)
                Exit Sub
            ElseIf txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(6, 4) = txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(6, 4) Then
                If txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(0, 2) > txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(0, 2) Then
                    MsgBox("Price Update Date: End Month < Start Month", MsgBoxStyle.Exclamation, "Invalid Input")
                    highlight_date(txt_S_PrcUpddatFm, Nothing)
                    Exit Sub
                ElseIf txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(0, 2) = txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(0, 2) Then
                    If txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(3, 2) > txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(3, 2) Then
                        MsgBox("Price Update Date: End Date < Start Date", MsgBoxStyle.Exclamation, "Invalid Input")
                        highlight_date(txt_S_PrcUpddatFm, Nothing)
                        Exit Sub
                    ElseIf txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(3, 2) = txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(3, 2) Then
                        If txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(11, 2) > txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(11, 2) Then
                            MsgBox("Price Update Date: End Hour < Start Hour", MsgBoxStyle.Exclamation, "Invalid Input")
                            highlight_date(txt_S_PrcUpddatFm, Nothing)
                            Exit Sub
                        ElseIf txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(11, 2) = txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(11, 2) Then
                            If txt_S_PrcUpddatFm.Text.Replace("   ", " ").Substring(14, 2) > txt_S_PrcUpddatTo.Text.Replace("   ", " ").Substring(14, 2) Then
                                MsgBox("Price Update Date: End Minute < Start Minute", MsgBoxStyle.Exclamation, "Invalid Input")
                                highlight_date(txt_S_PrcUpddatFm, Nothing)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Dim itmno As String
        Dim cus1no As String
        Dim cus2no As String
        Dim dsgvenno As String
        Dim itmUpddatFm As String
        Dim itmUpddatTo As String
        Dim prcCredatFm As String
        Dim prcCredatTo As String
        Dim prcUpddatFm As String
        Dim prcUpddatTo As String
        Dim itmsts As String
        Dim period As String
        Dim convert2PC As String

        itmno = txt_S_ItmNo.Text
        itmno = itmno.Replace("'", "''")

        cus1no = txt_S_PriCustAll.Text
        cus1no = cus1no.Replace("'", "''")

        cus2no = txt_S_SecCustAll.Text
        cus2no = cus2no.Replace("'", "''")

        dsgvenno = txt_S_DV.Text
        dsgvenno = dsgvenno.Replace("'", "''")

        If ckbCon2PC.Checked = True Then
            convert2PC = "N"
        Else
            convert2PC = "Y"
        End If

        If txt_S_Period.Text = "    -" Then
            period = ""
        Else
            period = txt_S_Period.Text
        End If

        If txt_S_ItmUpddatFm.Text = "  /  /         :" Then
            itmUpddatFm = ""
        Else
            itmUpddatFm = txt_S_ItmUpddatFm.Text.Replace("   ", " ")
        End If

        If txt_S_ItmUpddatTo.Text = "  /  /         :" Then
            itmUpddatTo = ""
        Else
            itmUpddatTo = txt_S_ItmUpddatTo.Text.Replace("   ", " ")
        End If

        If txt_S_PrcCredatFm.Text = "  /  /         :" Then
            prcCredatFm = ""
        Else
            prcCredatFm = txt_S_PrcCredatFm.Text.Replace("   ", " ")
        End If

        If txt_S_PrcCredatTo.Text = "  /  /         :" Then
            prcCredatTo = ""
        Else
            prcCredatTo = txt_S_PrcCredatTo.Text.Replace("   ", " ")
        End If

        If txt_S_PrcUpddatFm.Text = "  /  /         :" Then
            prcUpddatFm = ""
        Else
            prcUpddatFm = txt_S_PrcUpddatFm.Text.Replace("   ", " ")
        End If

        If txt_S_PrcUpddatTo.Text = "  /  /         :" Then
            prcUpddatTo = ""
        Else
            prcUpddatTo = txt_S_PrcUpddatTo.Text.Replace("   ", " ")
        End If

        If cbo_ItmSts.Text.Length > 0 Then
            itmsts = cbo_ItmSts.Text.Substring(0, 3)
        Else
            itmsts = ""
        End If

        If itmUpddatFm.Length > 0 Or prcCredatFm.Length > 0 Or prcUpddatFm.Length > 0 Then
            If cboRptFmt.SelectedIndex = 0 Then
                gspStr = "sp_select_IMR00034_NewFormat2 'UCPP','" & itmno & "','" & cus1no & "','" & cus2no & "','" & dsgvenno & "','" & _
                     itmUpddatFm & "','" & itmUpddatTo & "','" & prcCredatFm & "','" & prcCredatTo & "','" & prcUpddatFm & "','" & prcUpddatTo & _
                     "','" & itmsts & "','''" & period & "''','" & convert2PC & "','" & gsUsrID & "'"
            ElseIf cboRptFmt.SelectedIndex = 1 Then 'This choise should not be call anymore
                gspStr = "sp_select_IMR00034_NewFormat 'UCPP','" & itmno & "','" & cus1no & "','" & cus2no & "','" & dsgvenno & "','" & _
                     itmUpddatFm & "','" & itmUpddatTo & "','" & prcCredatFm & "','" & prcCredatTo & "','" & prcUpddatFm & "','" & prcUpddatTo & _
                     "','" & itmsts & "','" & gsUsrID & "'"
            Else 'This choise should not be call anymore
                gspStr = "sp_list_IMR00034 'UCPP','" & itmno & "','" & cus1no & "','" & cus2no & "','" & dsgvenno & "','" & _
                     itmUpddatFm & "','" & itmUpddatTo & "','" & prcCredatFm & "','" & prcCredatTo & "','" & prcUpddatFm & "','" & prcUpddatTo & _
                     "','" & itmsts & "','" & gsUsrID & "'"
            End If

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_IMR00034, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading IMR00034 sp_list_IMR00034 : " & rtnStr)
            Else
                If rs_IMR00034.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No record found!")
                Else
                    If cboRptFmt.SelectedIndex = 0 Then
                        ExportToExcelNewFormat2()
                    ElseIf cboRptFmt.SelectedIndex = 1 Then
                        ExportToExcelNewFormat()
                    Else
                        ExportToExcel()
                    End If

                    rs_IMR00034 = Nothing
                End If
            End If

            Me.Cursor = Windows.Forms.Cursors.Default
        Else
            MsgBox("Please enter search Parameter", MsgBoxStyle.Information, "Missing Search Parameters")
            txt_S_ItmNo.Focus()
        End If
    End Sub

    Private Sub ExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_IMR00034.Tables("RESULT").Rows.Count >= 65535 Then
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

        Dim headerRow As Integer = 2
        Dim headerCol As Integer = 1

        ' Row Header Initializing
        With xlsApp
            .Rows(headerRow).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "Cat"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Remark"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Input Date" & Environment.NewLine & "(MM-DD-YYYY HH:MM)"
            .Cells(headerRow, headerCol).WrapText = True
            .Columns(headerCol).NumberFormat = "MM-dd-yyyy HH:mm"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Pri Cust"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Sec Cust"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Temp No./ Asst No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Period" & Environment.NewLine & "(YYYY-MM)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Expiry Date" & Environment.NewLine & "(YYYY-MM-DD)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Item No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Description"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "UM"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Inner"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Master"
            headerCol += 1
            .Cells(headerRow, headerCol) = "CFT"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Conversion Factor to PCs"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "CCY"
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost A"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost B"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost C"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost D"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost Tran"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost Pack"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost (Total)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Packing Instruction"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).MergeCells = True
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).Value = "Inner Dim. (inch)"
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "L"
            headerCol += 1
            .Cells(headerRow, headerCol) = "W"
            headerCol += 1
            .Cells(headerRow, headerCol) = "H"
            headerCol += 1
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).MergeCells = True
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).Value = "Master Dim. (inch)"
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "L"
            headerCol += 1
            .Cells(headerRow, headerCol) = "W"
            headerCol += 1
            .Cells(headerRow, headerCol) = "H"
            headerCol += 1
            .Cells(headerRow, headerCol) = "內盒尺碼(寸)"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "外盒尺碼(寸)"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Light Spec."
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY" & Environment.NewLine & "MU"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "HK" & Environment.NewLine & "MU"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Basic Price" & Environment.NewLine & "(USD)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Price Term"
        End With

        'Populate Data
        headerCol = 1
        Dim entry(36) As Object
        Try
            With xlsApp
                '.Range(.Cells(3, 1), .Cells(3, rs_IMR00034.Tables("RESULT").Columns.Count)).Value = entry

                For i As Integer = 0 To rs_IMR00034.Tables("RESULT").Rows.Count - 1
                    entry(0) = rs_IMR00034.Tables("RESULT").Rows(i)("cat")
                    entry(1) = rs_IMR00034.Tables("RESULT").Rows(i)("ibi_rmk")
                    entry(2) = Format(rs_IMR00034.Tables("RESULT").Rows(i)("input_date"), "MM/dd/yyyy HH:mm:ss")
                    entry(3) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_cus1no")
                    entry(4) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_cus2no")
                    entry(5) = rs_IMR00034.Tables("RESULT").Rows(i)("temp_asst")
                    entry(6) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_period")
                    entry(7) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_expdat")
                    entry(8) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_itmno")
                    entry(9) = rs_IMR00034.Tables("RESULT").Rows(i)("ibi_engdsc")
                    entry(10) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_pckunt")
                    entry(11) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_inrqty")
                    entry(12) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_mtrqty")
                    entry(13) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_cft"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_cft"), "#.####"))
                    entry(14) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_conftr")
                    entry(15) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_curcde")
                    entry(16) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstA"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstA"), "0.00##"))
                    entry(17) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstB"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstB"), "0.00##"))
                    entry(18) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstC"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstC"), "0.00##"))
                    entry(19) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstD"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstD"), "0.00##"))
                    entry(20) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstTran"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstTran"), "0.00##"))
                    entry(21) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstPack"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstPack"), "0.00##"))
                    entry(22) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycst"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycst"), "0.00##"))
                    entry(23) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_pckitr")
                    entry(24) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrdin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrdin"), "0.####"))
                    entry(25) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrwin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrwin"), "0.####"))
                    entry(26) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrhin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrhin"), "0.####"))
                    entry(27) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrdin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrdin"), "0.####"))
                    entry(28) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrwin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrwin"), "0.####"))
                    entry(29) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrhin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrhin"), "0.####"))
                    entry(30) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrsze")
                    entry(31) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrsze")
                    entry(32) = rs_IMR00034.Tables("RESULT").Rows(i)("light_spec")
                    entry(33) = rs_IMR00034.Tables("RESULT").Rows(i)("fty_mu")
                    entry(34) = rs_IMR00034.Tables("RESULT").Rows(i)("hk_mu")
                    entry(35) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_basprc")
                    entry(36) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_hkprctrm")

                    .Range(.Cells(headerRow + 1 + i, headerCol), .Cells(headerRow + 1 + i, rs_IMR00034.Tables("RESULT").Columns.Count)).Value = entry
                Next
            End With


            ' Styling EXCEL
            With xlsApp
                .Rows("1:2").Font.Bold = True
                .Rows(2).rowheight = 40
                .Columns("B:B").WrapText = True

                .Rows("1:2").VerticalAlignment = Excel.Constants.xlCenter
                .Columns("A:AK").Font.Size = 10
                .Columns("A:AK").Font.Name = "Arial"

                .Columns("A:AK").EntireColumn.AutoFit()
                .Columns("A:A").ColumnWidth = 8
                .Columns("B:B").ColumnWidth = 23
                .Columns("F:F").ColumnWidth = 22
                .Columns("H:H").ColumnWidth = 13
                .Columns("J:J").ColumnWidth = 23
                .Columns("O:O").ColumnWidth = 11
                .Columns("X:X").ColumnWidth = 20
                .Columns("AE:AF").ColumnWidth = 20
                .Columns("AG:AG").ColumnWidth = 32
                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + rs_IMR00034.Tables("RESULT").Rows.Count)).EntireRow.AutoFit()
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
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "IMR00034 - Excel Error")
            End If
        End Try

        ' Release reference
        rs_IMR00034 = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub ExportToExcelNewFormat()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_IMR00034.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim headerRow As Integer = 2
        Dim headerCol As Integer = 1

        ' Row Header Initializing
        With xlsApp
            .Rows(headerRow).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "Cat"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Remark"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Input Date" & Environment.NewLine & "(MM-DD-YYYY HH:MM)"
            .Cells(headerRow, headerCol).WrapText = True
            .Columns(headerCol).NumberFormat = "MM-dd-yyyy HH:mm"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Pri Cust"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Sec Cust"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Temp No./ Asst No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor" & Environment.NewLine & "Code"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor" & Environment.NewLine & "Name"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Org. UM"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Period" & Environment.NewLine & "(YYYY-MM)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Expiry Date" & Environment.NewLine & "(MM-DD-YYYY)"
            .Cells(headerRow, headerCol).WrapText = True
            .Columns(headerCol).NumberFormat = "MM-dd-yyyy"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Item No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor" & Environment.NewLine & "Color" & Environment.NewLine & "Code"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Description"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "UM"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Inner"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Master"
            headerCol += 1
            .Cells(headerRow, headerCol) = "CFT"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Conversion Factor to PCs"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "CCY"
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "A"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "B"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "C"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "D"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "Tran"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "Pack"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "(Total)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Packing Instruction"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).MergeCells = True
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).Value = "Inner Dim. (inch)"
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "L"
            headerCol += 1
            .Cells(headerRow, headerCol) = "W"
            headerCol += 1
            .Cells(headerRow, headerCol) = "H"
            headerCol += 1
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).MergeCells = True
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).Value = "Master Dim. (inch)"
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "L"
            headerCol += 1
            .Cells(headerRow, headerCol) = "W"
            headerCol += 1
            .Cells(headerRow, headerCol) = "H"
            headerCol += 1
            .Cells(headerRow, headerCol) = "內盒尺碼(寸)"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "外盒尺碼(寸)"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Light Spec."
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY" & Environment.NewLine & "MU"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Price"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "HK" & Environment.NewLine & "MU"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Basic Price" & Environment.NewLine & "(USD)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Price Term"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Tran Term"
            .Cells(headerRow, headerCol).WrapText = True
        End With

        'Populate Data
        headerCol = 1
        Dim entry(42) As Object
        Try
            With xlsApp
                '.Range(.Cells(3, 1), .Cells(3, rs_IMR00034.Tables("RESULT").Columns.Count)).Value = entry

                For i As Integer = 0 To rs_IMR00034.Tables("RESULT").Rows.Count - 1
                    entry(0) = rs_IMR00034.Tables("RESULT").Rows(i)("cat")
                    entry(1) = rs_IMR00034.Tables("RESULT").Rows(i)("ibi_rmk")
                    entry(2) = Format(rs_IMR00034.Tables("RESULT").Rows(i)("input_date"), "MM/dd/yyyy HH:mm:ss")
                    entry(3) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_cus1no")
                    entry(4) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_cus2no")
                    entry(5) = rs_IMR00034.Tables("RESULT").Rows(i)("temp_asst")
                    entry(6) = rs_IMR00034.Tables("RESULT").Rows(i)("vbi_venno")
                    entry(7) = rs_IMR00034.Tables("RESULT").Rows(i)("vbi_vensna")
                    entry(8) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_orgum")
                    entry(9) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_period")
                    entry(10) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_expdat")
                    entry(11) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_itmno")
                    entry(12) = rs_IMR00034.Tables("RESULT").Rows(i)("icf_vencol")
                    entry(13) = rs_IMR00034.Tables("RESULT").Rows(i)("ibi_engdsc")
                    entry(14) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_pckunt")
                    entry(15) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_inrqty")
                    entry(16) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_mtrqty")
                    entry(17) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_cft"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_cft"), "#.####"))
                    entry(18) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_conftr")
                    entry(19) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_curcde")
                    entry(20) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstA"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstA"), "0.00##"))
                    entry(21) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstB"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstB"), "0.00##"))
                    entry(22) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstC"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstC"), "0.00##"))
                    entry(23) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstD"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstD"), "0.00##"))
                    entry(24) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstTran"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstTran"), "0.00##"))
                    entry(25) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstPack"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstPack"), "0.00##"))
                    entry(26) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycst"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycst"), "0.00##"))
                    entry(27) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_pckitr")
                    entry(28) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrdin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrdin"), "0.####"))
                    entry(29) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrwin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrwin"), "0.####"))
                    entry(30) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrhin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrhin"), "0.####"))
                    entry(31) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrdin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrdin"), "0.####"))
                    entry(32) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrwin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrwin"), "0.####"))
                    entry(33) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrhin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrhin"), "0.####"))
                    entry(34) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrsze")
                    entry(35) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrsze")
                    entry(36) = rs_IMR00034.Tables("RESULT").Rows(i)("light_spec")
                    entry(37) = rs_IMR00034.Tables("RESULT").Rows(i)("fty_mu")
                    entry(38) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftyprc"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftyprc"), "0.00##"))
                    entry(39) = rs_IMR00034.Tables("RESULT").Rows(i)("hk_mu")
                    entry(40) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_basprc")
                    entry(41) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_hkprctrm")
                    entry(42) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_trantrm")

                    .Range(.Cells(headerRow + 1 + i, headerCol), .Cells(headerRow + 1 + i, rs_IMR00034.Tables("RESULT").Columns.Count)).Value = entry
                Next
            End With


            ' Styling EXCEL
            With xlsApp
                .Rows("1:2").Font.Bold = True
                .Rows(2).rowheight = 40
                .Columns("B:B").WrapText = True

                .Rows("1:2").VerticalAlignment = Excel.Constants.xlCenter
                .Columns("A:AQ").Font.Size = 10
                .Columns("A:AQ").Font.Name = "Arial"

                '.Columns("A:AK").EntireColumn.AutoFit()
                .Columns("A:A").ColumnWidth = 14.25
                .Columns("B:B").ColumnWidth = 20
                .Columns("C:C").ColumnWidth = 20
                .Columns("D:E").ColumnWidth = 7.38
                .Columns("F:F").ColumnWidth = 22.75
                .Columns("G:I").ColumnWidth = 7.38
                .Columns("J:J").ColumnWidth = 10
                .Columns("K:K").ColumnWidth = 13
                .Columns("L:L").ColumnWidth = 14.38
                .Columns("M:M").ColumnWidth = 7.38
                .Columns("N:N").ColumnWidth = 20
                .Columns("O:Q").ColumnWidth = 5.63
                .Columns("R:R").ColumnWidth = 6.88
                .Columns("S:S").ColumnWidth = 10.14
                .Columns("T:T").ColumnWidth = 4.88
                .Columns("U:AA").ColumnWidth = 8
                .Columns("AB:AB").ColumnWidth = 20
                .Columns("AC:AH").ColumnWidth = 6
                .Columns("AI:AK").ColumnWidth = 22.75
                .Columns("AL:AL").ColumnWidth = 7.38
                .Columns("AM:AM").ColumnWidth = 11.13
                .Columns("AN:AN").ColumnWidth = 7.38
                .Columns("AO:AO").ColumnWidth = 13.5
                .Columns("AP:AQ").ColumnWidth = 12.5

                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + rs_IMR00034.Tables("RESULT").Rows.Count)).EntireRow.AutoFit()
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
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "IMR00034 - Excel Error")
            End If
        End Try

        xlsApp.Visible = True

        ' Release reference
        rs_IMR00034 = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub


    Private Sub ExportToExcelNewFormat2()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_IMR00034.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim headerRow As Integer = 2
        Dim headerCol As Integer = 1

        ' Row Header Initializing
        With xlsApp
            .Rows(headerRow).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "Cat"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Remark"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Input Date" & Environment.NewLine & "(MM-DD-YYYY HH:MM)"
            .Cells(headerRow, headerCol).WrapText = True
            .Columns(headerCol).NumberFormat = "MM-dd-yyyy HH:mm"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Pri Cust"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Sec Cust"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Temp No./ Asst No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor" & Environment.NewLine & "Code"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor" & Environment.NewLine & "Name"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Org. UM"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Period" & Environment.NewLine & "(YYYY-MM)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Expiry Date" & Environment.NewLine & "(MM-DD-YYYY)"
            .Cells(headerRow, headerCol).WrapText = True
            .Columns(headerCol).NumberFormat = "MM/dd/yyyy"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Item No."
            headerCol += 1
            .Cells(headerRow, headerCol) = "Vendor" & Environment.NewLine & "Color" & Environment.NewLine & "Code"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Description"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "UM"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Inner"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Master"
            headerCol += 1
            .Cells(headerRow, headerCol) = "CFT"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Conversion Factor to PCs"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "CCY"
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "A"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "B"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "C"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "D"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "E"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "Tran"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "Pack"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Cost" & Environment.NewLine & "(Total)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Packing Instruction"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).MergeCells = True
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).Value = "Inner Dim. (inch)"
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "L"
            headerCol += 1
            .Cells(headerRow, headerCol) = "W"
            headerCol += 1
            .Cells(headerRow, headerCol) = "H"
            headerCol += 1
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).MergeCells = True
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).Value = "Master Dim. (inch)"
            .Range(.Cells(headerRow - 1, headerCol), .Cells(headerRow - 1, headerCol + 2)).HorizontalAlignment = Excel.Constants.xlCenter
            .Cells(headerRow, headerCol) = "L"
            headerCol += 1
            .Cells(headerRow, headerCol) = "W"
            headerCol += 1
            .Cells(headerRow, headerCol) = "H"
            headerCol += 1
            .Cells(headerRow, headerCol) = "內盒尺碼(寸)"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "外盒尺碼(寸)"
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Light Spec."
            .Columns(headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY" & Environment.NewLine & "MU"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "FTY Price"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "HK" & Environment.NewLine & "MU"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Basic Price" & Environment.NewLine & "(USD)"
            .Cells(headerRow, headerCol).WrapText = True
            headerCol += 1
            .Cells(headerRow, headerCol) = "Price Term"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Tran Term"
            .Cells(headerRow, headerCol).WrapText = True
        End With

        'Populate Data
        headerCol = 1
        Dim entry(43) As Object
        Try
            With xlsApp
                '.Range(.Cells(3, 1), .Cells(3, rs_IMR00034.Tables("RESULT").Columns.Count)).Value = entry

                For i As Integer = 0 To rs_IMR00034.Tables("RESULT").Rows.Count - 1
                    entry(0) = rs_IMR00034.Tables("RESULT").Rows(i)("cat")
                    entry(1) = rs_IMR00034.Tables("RESULT").Rows(i)("ibi_rmk")
                    entry(2) = Format(rs_IMR00034.Tables("RESULT").Rows(i)("input_date"), "MM/dd/yyyy HH:mm:ss")
                    entry(3) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_cus1no")
                    entry(4) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_cus2no")
                    entry(5) = rs_IMR00034.Tables("RESULT").Rows(i)("temp_asst")
                    entry(6) = rs_IMR00034.Tables("RESULT").Rows(i)("vbi_venno")
                    entry(7) = rs_IMR00034.Tables("RESULT").Rows(i)("vbi_vensna")
                    entry(8) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_orgum")
                    entry(9) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_period")
                    entry(10) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_expdat")
                    entry(11) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_itmno")
                    entry(12) = rs_IMR00034.Tables("RESULT").Rows(i)("icf_vencol")
                    entry(13) = rs_IMR00034.Tables("RESULT").Rows(i)("ibi_engdsc")
                    entry(14) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_pckunt")
                    entry(15) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_inrqty")
                    entry(16) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_mtrqty")
                    entry(17) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_cft"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_cft"), "#.####"))
                    entry(18) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_conftr")
                    entry(19) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_curcde")
                    entry(20) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstA"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstA"), "0.00##"))
                    entry(21) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstB"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstB"), "0.00##"))
                    entry(22) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstC"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstC"), "0.00##"))
                    entry(23) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstD"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstD"), "0.00##"))
                    entry(24) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstE"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstE"), "0.00##"))
                    entry(25) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstTran"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstTran"), "0.00##"))
                    entry(26) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstPack"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycstPack"), "0.00##"))
                    entry(27) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycst"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftycst"), "0.00##"))
                    entry(28) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_pckitr")
                    entry(29) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrdin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrdin"), "0.####"))
                    entry(30) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrwin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrwin"), "0.####"))
                    entry(31) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrhin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrhin"), "0.####"))
                    entry(32) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrdin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrdin"), "0.####"))
                    entry(33) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrwin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrwin"), "0.####"))
                    entry(34) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrhin"), "#.####") = "", 0.0, Format(rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrhin"), "0.####"))
                    entry(35) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_inrsze")
                    entry(36) = rs_IMR00034.Tables("RESULT").Rows(i)("ipi_mtrsze")
                    entry(37) = rs_IMR00034.Tables("RESULT").Rows(i)("light_spec")
                    entry(38) = rs_IMR00034.Tables("RESULT").Rows(i)("fty_mu")
                    entry(39) = IIf(Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftyprc"), "#.####") = "", "0.00", Format(rs_IMR00034.Tables("RESULT").Rows(i)("imu_ftyprc"), "0.00##"))
                    entry(40) = rs_IMR00034.Tables("RESULT").Rows(i)("hk_mu")
                    entry(41) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_basprc")
                    entry(42) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_hkprctrm")
                    entry(43) = rs_IMR00034.Tables("RESULT").Rows(i)("imu_trantrm")

                    .Range(.Cells(headerRow + 1 + i, headerCol), .Cells(headerRow + 1 + i, rs_IMR00034.Tables("RESULT").Columns.Count)).Value = entry
                Next
            End With


            ' Styling EXCEL
            With xlsApp
                .Rows("1:2").Font.Bold = True
                .Rows(2).rowheight = 40
                .Columns("B:B").WrapText = True

                .Rows("1:2").VerticalAlignment = Excel.Constants.xlCenter
                .Columns("A:AR").Font.Size = 10
                .Columns("A:AR").Font.Name = "Arial"

                '.Columns("A:AK").EntireColumn.AutoFit()
                .Columns("A:A").ColumnWidth = 14.25
                .Columns("B:B").ColumnWidth = 20
                .Columns("C:C").ColumnWidth = 20
                .Columns("D:E").ColumnWidth = 7.38
                .Columns("F:F").ColumnWidth = 22.75
                .Columns("G:I").ColumnWidth = 7.38
                .Columns("J:J").ColumnWidth = 10
                .Columns("K:K").ColumnWidth = 13
                .Columns("L:L").ColumnWidth = 14.38
                .Columns("M:M").ColumnWidth = 7.38
                .Columns("N:N").ColumnWidth = 20
                .Columns("O:Q").ColumnWidth = 5.63
                .Columns("R:R").ColumnWidth = 6.88
                .Columns("S:S").ColumnWidth = 10.14
                .Columns("T:T").ColumnWidth = 4.88
                .Columns("U:AB").ColumnWidth = 8
                .Columns("AC:AC").ColumnWidth = 20
                .Columns("AD:AI").ColumnWidth = 6
                .Columns("AJ:AL").ColumnWidth = 22.75
                .Columns("AM:AM").ColumnWidth = 7.38
                .Columns("AN:AN").ColumnWidth = 11.13
                .Columns("AO:AO").ColumnWidth = 7.38
                .Columns("AP:AP").ColumnWidth = 13.5
                .Columns("AQ:AR").ColumnWidth = 12.5

                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + rs_IMR00034.Tables("RESULT").Rows.Count)).EntireRow.AutoFit()
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
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "IMR00034 - Excel Error")
            End If
        End Try

        xlsApp.Visible = True

        ' Release reference
        rs_IMR00034 = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub



    Private Sub loadItemStatus()
        cbo_ItmSts.Items.Clear()
        cbo_ItmSts.Items.Add("")
        cbo_ItmSts.Items.Add("CMP - Complete Item")
        cbo_ItmSts.Items.Add("INC - Incomplete Item")
        cbo_ItmSts.Items.Add("HLD - Item on Hold")
        cbo_ItmSts.Items.Add("DIS - Discontinue Item")
        cbo_ItmSts.Items.Add("TBC - To Be Confirmed")
        cbo_ItmSts.Items.Add("INA - Inactive Item")
        cbo_ItmSts.Items.Add("CLO - Closed Item")
        cbo_ItmSts.Items.Add("OLD - Old Item")
    End Sub

    Private Sub cmd_S_ItmNoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNoAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text
        frmComSearch.cmdSVClear.Enabled = False
        frmComSearch.cmdPVClear.Enabled = False
        frmComSearch.cmdAllClear.Enabled = False

        frmComSearch.show_frmS(Me.cmd_S_ItmNoAll)
    End Sub

    Private Sub cmd_S_PriCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCustAll)
    End Sub

    Private Sub cmd_S_SecCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCustAll.Name
        frmComSearch.callFmString = txt_S_SecCustAll.Text()

        frmComSearch.show_frmS(Me.cmd_S_SecCustAll)
    End Sub

    Private Sub cmd_S_DV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_DV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_DV.Name
        frmComSearch.callFmString = txt_S_DV.Text()

        frmComSearch.show_frmS(Me.cmd_S_DV)
    End Sub

    Private Sub highlight_date(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_ItmUpddatFm.Enter, txt_S_ItmUpddatTo.Enter, txt_S_PrcUpddatTo.Enter, txt_S_PrcUpddatFm.Enter, txt_S_PrcCredatTo.Enter, txt_S_PrcCredatFm.Enter
        sender.Focus()
        sender.SelectAll()
    End Sub
End Class