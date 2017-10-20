Option Explicit On
Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMX00007

    Private Const loc_itmno As Integer = 1
    Private Const loc_tmpitm As Integer = 2

    Dim myExcel As Excel.Application
    Dim dsApproval As New DataSet
    Dim dsInvalid As New DataSet
    Dim dvApproval As DataView
    Dim dvInvalid As DataView

    Private Sub IMXLS007_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        setStatus("init")
    End Sub

    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        Dim xlsPath As String
        Dim oldCI As Globalization.CultureInfo

        xlsPath = txtFilePath.Text

        If Trim(xlsPath) = "" Then
            MsgBox("Please select an Excel file to upload")
            cmdBrowse.Focus()
            Exit Sub
        End If
        If Not IO.File.Exists(xlsPath) Then
            MsgBox("Excel file does not exist")
            Exit Sub
        End If

        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim dtApproval As DataTable
        Dim dtInvalid As DataTable
        Dim dcExcel As DataColumn
        Dim drExcel As DataRow

        dtApproval = New DataTable("APPROVAL")
        Dim i As Integer
        For i = 0 To 3
            If i = 0 Then
                dcExcel = New DataColumn("no")
            ElseIf i = 1 Then
                dcExcel = New DataColumn("itr_itmno")
            ElseIf i = 2 Then
                dcExcel = New DataColumn("itr_tmpitm")
            ElseIf i = 3 Then
                dcExcel = New DataColumn("itr_stage")
            End If

            dcExcel.DataType = System.Type.GetType("System.String")
            dtApproval.Columns.Add(dcExcel)
        Next

        dcExcel = Nothing
        dsApproval.Tables.Add(dtApproval)

        dtInvalid = New DataTable("INVALID")
        For i = 0 To 2
            If i = 0 Then
                dcExcel = New DataColumn("itr_itmno")
            ElseIf i = 1 Then
                dcExcel = New DataColumn("itr_tmpitm")
            ElseIf i = 2 Then
                dcExcel = New DataColumn("itr_sysmsg")
            End If

            dcExcel.DataType = System.Type.GetType("System.String")
            dtInvalid.Columns.Add(dcExcel)
        Next

        dcExcel = Nothing
        dsInvalid.Tables.Add(dtInvalid)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        myExcel = New Excel.Application
        myExcel.Workbooks.Open(xlsPath)
        myExcel.Sheets(1).Select()

        Dim row As Integer = 2
        Dim sysmsg As String

        i = 1
        While (Not (myExcel.Cells(row, 1).Value Is Nothing))
            sysmsg = validateData(Replace(Trim(myExcel.Cells(row, loc_itmno).Value.ToString), "'", "''"), _
                                    Replace(Trim(myExcel.Cells(row, loc_tmpitm).Value.ToString), "'", "''"))
            If sysmsg = "ERROR" Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading IMXLS007 sp_select_IMITMDAT : " & rtnStr)
                Exit Sub
            ElseIf sysmsg = "" Then
                drExcel = dtApproval.NewRow()
                drExcel.Item("no") = i
                drExcel.Item("itr_itmno") = Replace(Trim(myExcel.Cells(row, loc_itmno).Value.ToString), "'", "''")
                drExcel.Item("itr_tmpitm") = Replace(Trim(myExcel.Cells(row, loc_tmpitm).Value.ToString), "'", "''")
                drExcel.Item("itr_stage") = "R"
                dtApproval.Rows.Add(drExcel)
                i = i + 1
            ElseIf sysmsg <> "" Then
                drExcel = dtInvalid.NewRow()
                drExcel.Item("itr_itmno") = Replace(Trim(myExcel.Cells(row, loc_itmno).Value.ToString), "'", "''")
                drExcel.Item("itr_tmpitm") = Replace(Trim(myExcel.Cells(row, loc_tmpitm).Value.ToString), "'", "''")
                drExcel.Item("itr_sysmsg") = sysmsg
                dtInvalid.Rows.Add(drExcel)
            End If
            row = row + 1
        End While

        myExcel.Workbooks.Close()
        myExcel.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel)
        myExcel = Nothing

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Me.Cursor = Windows.Forms.Cursors.Default

        generateGridData()

        setStatus("upload")
        If dsInvalid.Tables("INVALID").Rows.Count > 0 Then
            tabFrame.TabPages(2).Enabled = True
        End If
        If dsApproval.Tables("APPROVAL").Rows.Count > 0 Then
            tabFrame.SelectTab(1)
        ElseIf dsInvalid.Tables("INVALID").Rows.Count > 0 Then
            tabFrame.TabPages(1).Enabled = False
            tabFrame.SelectTab(2)
        End If

        txtApplyFrom.Text = "1"
        txtApplyTo.Text = dsApproval.Tables("APPROVAL").Rows.Count
        Dim n As Integer = 0
        n = dsApproval.Tables("APPROVAL").Rows.Count / 10
        If (dsApproval.Tables("APPROVAL").Rows.Count Mod 10) > 0 Then
            n += 1
        End If
        txtApplyFrom.MaxLength = n
        txtApplyTo.MaxLength = n

    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click

        If optApprove.Checked = False And optReject.Checked = False Then
            MsgBox("Please select one of the following options: Approval or Rejection", MsgBoxStyle.Exclamation, "Missing Decision")
            optApprove.Focus()
            Exit Sub
        End If

        Dim i As Integer
        Dim stage As String

        If optApprove.Checked = True Then
            stage = "A"
        Else
            stage = "R"
        End If

        If grdApproval.SelectedRows.Count > 0 Then
            dsApproval.Tables("APPROVAL").Columns("itr_stage").ReadOnly = False
            For i = 0 To grdApproval.SelectedRows.Count - 1
                dsApproval.Tables("APPROVAL").Rows(grdApproval.SelectedRows.Item(i).Index)("itr_stage") = stage
            Next
            dsApproval.Tables("APPROVAL").Columns("itr_stage").ReadOnly = True
        Else
            If Val(txtApplyFrom.Text) = "0" Then
                MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyFrom.Focus()
                txtApplyFrom.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyTo.Text) = "0" Then
                MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.Focus()
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyFrom.Text) > dsApproval.Tables("APPROVAL").Rows.Count Then
                MsgBox("The apply range cannot larger than the total number of records.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyFrom.Focus()
                txtApplyFrom.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyTo.Text) > dsApproval.Tables("APPROVAL").Rows.Count Then
                MsgBox("The apply range cannot larger than the total number of records.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.Focus()
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyFrom.Text) > Val(txtApplyTo.Text) Then
                MsgBox("The apply range is invalid.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.Focus()
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            dsApproval.Tables("APPROVAL").Columns("itr_stage").ReadOnly = False
            For i = Val(txtApplyFrom.Text) - 1 To Val(txtApplyTo.Text) - 1
                dsApproval.Tables("APPROVAL").Rows(i)("itr_stage") = stage
            Next
            dsApproval.Tables("APPROVAL").Columns("itr_stage").ReadOnly = True
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim rs_status As New DataSet
        Dim i As Integer

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        For i = 0 To dsApproval.Tables("APPROVAL").Rows.Count - 1
            If dsApproval.Tables("APPROVAL").Rows(i)("itr_stage") = "A" Then
                gspStr = "sp_insert_IMTMPREL 'UCPP','" & dsApproval.Tables("APPROVAL").Rows(i)("itr_itmno") & _
                         "','" & dsApproval.Tables("APPROVAL").Rows(i)("itr_tmpitm") & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_status, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading IMXLS007 sp_insert_IMTMPREL : " & rtnStr)
                    Exit Sub
                End If
            End If
        Next

        Me.Cursor = Windows.Forms.Cursors.Default

        MsgBox("Record Saved")
        cmdClear.PerformClick()
    End Sub

    Private Function validateData(ByVal itmno As String, ByVal tmpitm As String) As String
        Dim rs_validate As New DataSet
        gspStr = "sp_select_IMXLS007 '" & itmno & "','" & tmpitm & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_validate, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Return "ERROR"
        End If
        If Trim(rs_validate.Tables("RESULT").Rows(0)("sysmsg").ToString) = "" Then
            Return ""
        Else
            Return rs_validate.Tables("RESULT").Rows(0)("sysmsg").ToString
        End If
    End Function

    Private Sub generateGridData()
        dvApproval = dsApproval.Tables("APPROVAL").DefaultView

        With grdApproval
            .DataSource = Nothing
            .DataSource = dvApproval
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "No."
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 1
                        .Columns(i).HeaderText = "Real Item No."
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "Temp Item No."
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Apr/Rej"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        dvInvalid = dsInvalid.Tables("INVALID").DefaultView

        With grdInvalid
            .DataSource = Nothing
            .DataSource = dvInvalid
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Real Item No."
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Temp Item No."
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "System Message"
                        .Columns(i).Width = 220
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub setStatus(ByVal mode As String)
        If mode = "init" Then
            dsApproval = Nothing
            dsInvalid = Nothing
            dvApproval = Nothing
            dvInvalid = Nothing
            dsApproval = New DataSet
            dsInvalid = New DataSet
            dvApproval = New DataView
            dvInvalid = New DataView

            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = False
            tabFrame.TabPages(2).Enabled = False

            tabFrame.SelectTab(0)

            txtFilePath.Text = ""
        ElseIf mode = "upload" Then
            tabFrame.TabPages(0).Enabled = False
            tabFrame.TabPages(1).Enabled = True
        End If

    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        browseFileDialog.Title = "Select an Excel File to upload"
        browseFileDialog.Filter = "Excel File (*.xls)|*.xls|Excel XLSX File (*.xlsx)|*.xlsx|All Files|*.*"
        browseFileDialog.InitialDirectory = "C:\"
        browseFileDialog.ShowDialog()
    End Sub

    Private Sub browseFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles browseFileDialog.FileOk
        Dim strm As System.IO.Stream
        strm = browseFileDialog.OpenFile()
        txtFilePath.Text = browseFileDialog.FileName.ToString()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        setStatus("init")
    End Sub

    Private Sub validateInput(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApplyTo.KeyPress, txtApplyFrom.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub


    Private Sub grdApproval_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdApproval.CellMouseClick
        If grdApproval.SelectedRows.Count = 1 Or grdApproval.SelectedCells.Count = 1 Then
            If grdApproval.SelectedCells.Item(0).ColumnIndex = 3 Then
                dsApproval.Tables("APPROVAL").Columns("itr_stage").ReadOnly = False
                If dsApproval.Tables("APPROVAL").Rows(grdApproval.SelectedCells.Item(0).RowIndex)("itr_stage") = "R" Then
                    dsApproval.Tables("APPROVAL").Rows(grdApproval.SelectedCells.Item(0).RowIndex)("itr_stage") = "A"
                ElseIf dsApproval.Tables("APPROVAL").Rows(grdApproval.SelectedCells.Item(0).RowIndex)("itr_stage") = "A" Then
                    dsApproval.Tables("APPROVAL").Rows(grdApproval.SelectedCells.Item(0).RowIndex)("itr_stage") = "R"
                End If
                dsApproval.Tables("APPROVAL").Columns("itr_stage").ReadOnly = True
            End If
        End If
    End Sub
End Class