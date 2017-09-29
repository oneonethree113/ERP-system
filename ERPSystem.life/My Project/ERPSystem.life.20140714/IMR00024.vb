Imports Microsoft.Office.Interop

Public Class IMR00024

    Dim rs_EXCEL As New DataSet

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim colSCSeq As Integer
    Dim colUPDDate As Integer

    Dim Act As String

    Private Sub IMR00024_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Act = IIf(optUPD.Checked = True, "U", "L")

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMR00024A '" & cboCoCde.Text & "','" & txtSCFm.Text & "','" & txtSCTo.Text & _
                 "','" & txtJobFm.Text & "','" & txtJobTo.Text & "','" & Act & "','" & gsUsrID & "'"
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

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
    End Sub

    Private Sub CopyText(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCFm.TextChanged, txtJobFm.TextChanged
        Select Case sender.Name.ToString
            Case "txtSCFm"
                txtSCTo.Text = sender.Text
            Case "txtJobFm"
                txtJobTo.Text = sender.Text
        End Select
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
            .Cells(headerRow, headerCol) = "SC #"
            headerCol += 1
            .Cells(headerRow, headerCol) = "SC Seq."
            colSCSeq = headerCol
            headerCol += 1
            .Cells(headerRow, headerCol) = "Job #"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Ship Mark"
            If Act = "U" Then
                headerCol += 1
                .Cells(headerRow, headerCol) = "Action"
            End If
            headerCol += 1
            .Cells(headerRow, headerCol) = "Update User"
            headerCol += 1
            .Cells(headerRow, headerCol) = "Update Date"
            colUPDDate = headerCol
        End With

        headerCol = 1
        Dim numCol As Integer
        If Act = "U" Then
            numCol = 6
        Else
            numCol = 5
        End If

        Dim entry(numCol) As Object

        Try
            With xlsApp
                '.Range(.Cells(3, 1), .Cells(3, rs_EXCEL.Tables("RESULT").Columns.Count)).Value = entry

                Dim j As Integer = 0

                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    j = 0
                    entry(j) = rs_EXCEL.Tables("RESULT").Rows(i)("SC #")
                    j = j + 1
                    entry(j) = rs_EXCEL.Tables("RESULT").Rows(i)("SC Seq.")
                    j = j + 1
                    entry(j) = rs_EXCEL.Tables("RESULT").Rows(i)("Job #")
                    j = j + 1
                    entry(j) = rs_EXCEL.Tables("RESULT").Rows(i)("Ship Mark")
                    If Act = "U" Then
                        j = j + 1
                        entry(j) = rs_EXCEL.Tables("RESULT").Rows(i)("Action")
                    End If
                    j = j + 1
                    entry(j) = rs_EXCEL.Tables("RESULT").Rows(i)("Update User")
                    j = j + 1
                    entry(j) = IIf(rs_EXCEL.Tables("RESULT").Rows(i)("Update Date").ToString = "", "", Format(rs_EXCEL.Tables("RESULT").Rows(i)("Update Date"), "MM/dd/yyyy").ToString)

                    .Range(.Cells(headerRow + 1 + i, headerCol), .Cells(headerRow + 1 + i, rs_EXCEL.Tables("RESULT").Columns.Count)).Value = entry
                Next
            End With

            ' Styling EXCEL
            With xlsApp
                .Rows(1).Font.Bold = True
                .Rows(1).rowheight = 24.75
                .Columns("A:G").Font.Size = 10
                .Range(.Cells(headerRow + 1, colSCSeq), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colSCSeq)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(.Cells(headerRow + 1, colUPDDate), .Cells(headerRow + rs_EXCEL.Tables("RESULT").Rows.Count, colUPDDate)).HorizontalAlignment = Excel.Constants.xlRight
                Dim k As Integer = 1
                .Columns(k).ColumnWidth = 12
                k = k + 1
                .Columns(k).ColumnWidth = 7
                k = k + 1
                .Columns(k).ColumnWidth = 15
                k = k + 1
                .Columns(k).ColumnWidth = 20
                If Act = "U" Then
                    k = k + 1
                    .Columns(k).ColumnWidth = 20
                End If
                k = k + 1
                .Columns(k).ColumnWidth = 20
                k = k + 1
                .Columns(k).ColumnWidth = 20
                .Columns(k).NumberFormat = "MM/dd/yyyy"

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