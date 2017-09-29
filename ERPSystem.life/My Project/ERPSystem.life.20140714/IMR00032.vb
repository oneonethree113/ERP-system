Imports Microsoft.Office.Interop

Public Class IMR00032

    Dim rs_EXCEL As DataSet

    Private Sub IMR00032_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gsDefaultCompany = "MS" Then
            gsCompany = "MS"
        End If

        Dim grp As String = Split(gsUsrGrp, "-")(0)

        optPrintAmtYes.Enabled = False
        optPrintAmtNo.Enabled = False


        If grp = "CED" Then
            optPrintAmtYes.Checked = True
            optPrintAmtNo.Checked = False
        Else
            optPrintAmtYes.Checked = False
            optPrintAmtNo.Checked = True
        End If

        cboCustomer.Items.Add("All Customer Shipment Report")
        cboCustomer.Items.Add("50068 - HOBBY LOBBY Late Shipment Report")
        cboCustomer.SelectedIndex = 0
        txtDateRange.Text = "SC Ship End"

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged
        If cboCustomer.SelectedIndex = 0 Then
            txtDateRange.Text = "SC Ship End"
        Else
            txtDateRange.Text = "ETD Date"
        End If
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim CUSTOMER As String
        Dim ETDDATEFM As String
        Dim ETDDATETO As String
        Dim PRINTAMT As String

        If Trim(cboCustomer.Text) = "" Then
            MsgBox("Customer Selection cannot empty!")
            cboCustomer.Focus()
            Exit Sub
        Else
            CUSTOMER = Split(cboCustomer.Text, " - ")(0)
        End If

        If Mid(txtETDDateFm.Text, 7) > Mid(txtETDDateTo.Text, 7) Then
            MsgBox("ETD Date: End Date < Start date ! (YY)")
            txtETDDateFm.Focus()
            txtETDDateFm.SelectAll()
            Exit Sub
        ElseIf Mid(txtETDDateFm.Text, 7) = Mid(txtETDDateTo.Text, 7) Then
            If txtETDDateFm.Text.Substring(0, 2) > txtETDDateTo.Text.Substring(0, 2) Then
                MsgBox("ETD Date: End Date < Start date ! (MM)")
                txtETDDateFm.Focus()
                txtETDDateFm.SelectAll()
                Exit Sub
            ElseIf txtETDDateFm.Text.Substring(0, 2) = txtETDDateTo.Text.Substring(0, 2) Then
                If Mid(txtETDDateFm.Text, 4, 2) > Mid(txtETDDateTo.Text, 4, 2) Then
                    MsgBox("ETD Date: End Date < Start date ! (DD)")
                    txtETDDateFm.Focus()
                    txtETDDateFm.SelectAll()
                    Exit Sub
                End If
            End If
        End If

        If txtETDDateFm.Text <> "  /  /" Then
            If IsDate(txtETDDateFm.Text) = False Then
                MsgBox("Invalid Enter in ETD Date!")
                txtETDDateFm.Focus()
                txtETDDateFm.SelectAll()
                Exit Sub
            End If
        End If

        If txtETDDateTo.Text <> "  /  /" Then
            If IsDate(txtETDDateTo.Text) = False Then
                MsgBox("Invalid Enter in ETD Date!")
                txtETDDateTo.Focus()
                txtETDDateTo.SelectAll()
                Exit Sub
            End If
        End If

        If txtETDDateFm.Text = "  /  /" Then
            MsgBox("Please enter ETD Date Fm")
            txtETDDateFm.Focus()
            txtETDDateFm.SelectAll()
            Exit Sub
        Else
            ETDDATEFM = Format(CDate(txtETDDateFm.Text), "yyyy-MM-dd")
        End If

        If txtETDDateTo.Text = "  /  /" Then
            MsgBox("Please enter ETD Date To")
            txtETDDateTo.Focus()
            txtETDDateTo.SelectAll()
            Exit Sub

            ETDDATETO = "1900-01-01"
        Else
            ETDDATETO = Format(CDate(txtETDDateTo.Text), "yyyy-MM-dd")
        End If


        If optPrintAmtYes.Checked = True Then
            PRINTAMT = "Y"
        Else
            PRINTAMT = "N"
        End If



        If cboCustomer.SelectedIndex = 0 Then
            gspStr = "sp_list_IMR00032A '" & gsCompany & "','" & CUSTOMER & "','" & ETDDATEFM & "','" & ETDDATETO & _
                     "','" & PRINTAMT & "','" & gsUsrID & "'"
        Else
            gspStr = "sp_list_IMR00032 '" & gsCompany & "','" & CUSTOMER & "','" & ETDDATEFM & "','" & ETDDATETO & _
                     "','" & gsUsrID & "'"
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_EXCEL = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00032 #001 sp_list_IMR00032 : " & rtnStr)
            Exit Sub
        End If

        If rs_EXCEL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Records Found!")
            Exit Sub
        Else
            ExportToExcel()
        End If
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

        Try
            With xlsApp
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