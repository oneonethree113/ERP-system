Imports Microsoft.Office.Interop

Public Class BJR00001

    Dim enq_right_local As Boolean
    Dim del_right_local As Boolean
    Dim flag_Add As Boolean
    Dim recordStatus As Boolean

    Dim rs_BJR00001 As DataSet
    Dim rs_BJR00001_ori As DataSet
    Dim rs_BJR00001C As DataSet
    Dim rs_Report As DataSet

    Dim dgBatchJob_Confirm As Integer

    Private Sub BJR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        enq_right_local = Enq_right
        del_right_local = Del_right

        FillCompCombo(LCase(gsUsrID), cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        cboRptFmt.Items.Clear()
        cboRptFmt.Items.Add("Production Order Report")
        cboRptFmt.Items.Add("Batch Job Item Info")

        setStatus("INIT")
    End Sub

    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            cmdAdd.Enabled = True
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True

            cboCoCde.Enabled = True
            txtCoNam.Enabled = True
            txtCoNam.ReadOnly = True

            txtBJNo.Enabled = True
            txtRunNoFrm.Enabled = False
            txtRunNoTo.Enabled = False
            txtJobOrdFrm.Enabled = False
            txtJobOrdTo.Enabled = False

            cboRptFmt.Enabled = True
            cmdApply.Enabled = False
            cmdPrint.Enabled = True
            grpOutFmt.Enabled = True
            optPDF.Enabled = True
            optExcel.Enabled = True

            txtCount.Enabled = False

            flag_Add = False
            recordStatus = False
            clearScreen()
        ElseIf mode = "ADD" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True

            cboCoCde.Enabled = False
            txtCoNam.Enabled = True
            txtCoNam.ReadOnly = True

            txtBJNo.Enabled = False
            txtRunNoFrm.Enabled = True
            txtRunNoTo.Enabled = True
            txtJobOrdFrm.Enabled = True
            txtJobOrdTo.Enabled = True

            cboRptFmt.Enabled = False
            cmdApply.Enabled = True
            cmdPrint.Enabled = False
            grpOutFmt.Enabled = False
            optPDF.Enabled = True
            optExcel.Enabled = True

            flag_Add = True
            recordStatus = False
            clearScreen()
            txtBJNo.Text = ""
        ElseIf mode = "UPDATE" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True

            cboCoCde.Enabled = False
            txtCoNam.Enabled = True
            txtCoNam.ReadOnly = True

            txtBJNo.Enabled = False
            txtRunNoFrm.Enabled = True
            txtRunNoTo.Enabled = True
            txtJobOrdFrm.Enabled = True
            txtJobOrdTo.Enabled = True

            cboRptFmt.Enabled = False
            cmdApply.Enabled = True
            cmdPrint.Enabled = False
            grpOutFmt.Enabled = False
            optPDF.Enabled = True
            optExcel.Enabled = True
        End If
    End Sub

    Private Sub clearScreen()
        txtRunNoFrm.Text = ""
        txtRunNoTo.Text = ""
        txtJobOrdFrm.Text = ""
        txtJobOrdTo.Text = ""

        cboRptFmt.SelectedIndex = 0
        optPDF.Checked = True

        rs_BJR00001 = Nothing
        rs_BJR00001C = Nothing
        dgBatchJob.DataSource = Nothing
    End Sub

    Private Sub cboCoCde_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectionChangeCommitted
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub txtBJNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBJNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdFind.PerformClick()
        End If
    End Sub

    Private Sub txtRunNoFrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRunNoFrm.TextChanged
        txtRunNoTo.Text = txtRunNoFrm.Text
    End Sub

    Private Sub txtJobOrdFrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobOrdFrm.TextChanged
        txtJobOrdTo.Text = txtJobOrdFrm.Text
    End Sub

    Private Sub cboRptFmt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRptFmt.SelectedIndexChanged
        If cboRptFmt.SelectedIndex = 0 Then
            grpOutFmt.Enabled = True
        Else
            grpOutFmt.Enabled = False
        End If
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        gspStr = ""
        If txtJobOrdFrm.Text <> "" And txtJobOrdTo.Text <> "" Then
            gspStr = "sp_select_BJR00001_2 '" & cboCoCde.Text & "','" & Replace(txtJobOrdFrm.Text, "'", "''") & "','" & Replace(txtJobOrdTo.Text, "'", "''") & "'"
        ElseIf txtRunNoFrm.Text <> "" And txtRunNoTo.Text <> "" Then
            gspStr = "sp_select_BJR00001_RUNNO_2 '" & cboCoCde.Text & "','" & Replace(txtRunNoFrm.Text, "'", "''") & "','" & Replace(txtRunNoTo.Text, "'", "''") & "'"
        End If

        If gspStr <> "" Then
            Dim rs As New DataSet
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading BJR00001 #001 sp_select_BJR00001_2 : " & rtnStr)
                Exit Sub
            End If

            For i As Integer = 0 To rs.Tables("RESULT").Columns.Count - 1
                rs.Tables("RESULT").Columns(i).ReadOnly = False
            Next

            rs_BJR00001C = rs.Copy()
            If rs_BJR00001C.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
            Else
                unionRecord()
                Dim dv As DataView = rs_BJR00001.Tables("RESULT").DefaultView
                dv.Sort = "pod_scno"
                rs_BJR00001.Tables.Remove("RESULT")
                rs_BJR00001.Tables.Add(dv.ToTable)

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                display()
                countY()
                Me.Cursor = Windows.Forms.Cursors.Default
            End If
        End If
    End Sub

    Private Sub dgBatchJob_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBatchJob.CellClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            If e.ColumnIndex = dgBatchJob_Confirm Then
                If dgBatchJob.CurrentRow.Cells("pjd_confrm").Value = "Y" Then
                    dgBatchJob.CurrentRow.Cells("pjd_confrm").Value = "N"
                Else
                    dgBatchJob.CurrentRow.Cells("pjd_confrm").Value = "Y"
                End If

                recordStatus = True
                rs_BJR00001.AcceptChanges()
                dgBatchJob.ClearSelection()
                countY()
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If Trim(txtBJNo.Text) = "" Then
            MsgBox("Batch Job No. cannot be empty", MsgBoxStyle.Information, "BJR0001 - Print Report")
            Exit Sub
        End If

        If cboRptFmt.SelectedIndex = 0 Then
            exportPOReport()
        Else
            exportBJItemReport()
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        setStatus("ADD")
        txtRunNoFrm.Focus()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim rs As DataSet

        If rs_BJR00001 Is Nothing Then
            MsgBox("No record found in this Batch Job No.", MsgBoxStyle.Exclamation, "BJR00001 - Save without Record")
            Exit Sub
        End If

        If flag_Add = False And txtBJNo.Text = "" Then
            MsgBox("Process cannot save without Batch Job No.", MsgBoxStyle.Exclamation, "BJR00001 - Save without Batch Job No")
            Exit Sub
        End If

        If recordStatus = False Then
            MsgBox("No changes have been made", MsgBoxStyle.Information, "BJR00001 - Save without changes")
            Exit Sub
        End If

        If flag_Add = True Then
            rs = Nothing
            gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','BJ','" & LCase(gsUsrID) & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading BJR00001 #003 sp_select_DOC_GEN : " & rtnStr)
                Exit Sub
            Else
                txtBJNo.Text = rs.Tables("RESULT").Rows(0)(0)
            End If
        End If

        For i As Integer = 0 To rs_BJR00001.Tables("RESULT").Rows.Count - 1
            If rs_BJR00001.Tables("RESULT").Rows(i)("pjd_recsts") = "new" Then
                gspStr = "sp_insert_PJDHONG '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & rs_BJR00001.Tables("RESULT").Rows(i)("pod_jobord") & _
                         "','" & rs_BJR00001.Tables("RESULT").Rows(i)("pjd_confrm") & "','" & LCase(gsUsrID) & "'"
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rs = Nothing
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on saving BJR00001 #004 sp_insert_PJDHONG : " & rtnStr)
                    Exit Sub
                End If
            Else
                If checkChangesMade(rs_BJR00001.Tables("RESULT").Rows(i)("pod_jobord")) = True Then
                    gspStr = "sp_update_PJDHONG '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & rs_BJR00001.Tables("RESULT").Rows(i)("pod_jobord") & _
                             "','" & rs_BJR00001.Tables("RESULT").Rows(i)("pjd_confrm") & "','" & LCase(gsUsrID) & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rs = Nothing
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on saving BJR00001 #005 sp_update_PJDHONG : " & rtnStr)
                        Exit Sub
                    End If
                End If
            End If
        Next

        gspStr = "sp_update_BJR00001 '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on saving BJR00001 #006 sp_update_BJR00001 : " & rtnStr)
            Exit Sub
        End If

        MsgBox("Record Saved", MsgBoxStyle.Information, "BJR00001 - Save Complete")
        setStatus("INIT")
        txtBJNo.Focus()
        txtBJNo.SelectAll()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim rs As New DataSet

        gspStr = "sp_select_PJDHONG '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & LCase(gsUsrID) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BJR00001 #002 sp_select_PJDHONG : " & rtnStr)
            Exit Sub
        End If

        For i As Integer = 0 To rs.Tables("RESULT").Columns.Count - 1
            rs.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_BJR00001C = rs.Copy()
        rs_BJR00001_ori = rs.Copy()
        If rs_BJR00001C.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found", MsgBoxStyle.Information)
            Exit Sub
        Else
            unionRecord()
            Dim dv As DataView = rs_BJR00001.Tables("RESULT").DefaultView
            dv.Sort = "pod_scno"
            rs_BJR00001.Tables.Remove("RESULT")
            rs_BJR00001.Tables.Add(dv.ToTable)

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            setStatus("UPDATE")
            display()
            countY()
            Me.Cursor = Windows.Forms.Cursors.Default
        End If

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If recordStatus = True Then
            If MsgBox("Changes have been made." & Environment.NewLine & "Are you sure you want to clear without saving?", MsgBoxStyle.YesNo, "BJR00001 - Clear Data") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        setStatus("INIT")
        txtBJNo.Text = ""
        txtBJNo.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If recordStatus = True Then
            If MsgBox("Changes have been made." & Environment.NewLine & "Are you sure you want to exit without saving?", MsgBoxStyle.YesNo, "BJR00001 - Exit Program") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub

    Private Sub unionRecord()
        If rs_BJR00001 Is Nothing Then
            rs_BJR00001 = rs_BJR00001C.Copy()
            recordStatus = True
        End If

        If Not rs_BJR00001C Is Nothing Then
            Dim dr() As DataRow
            Dim newRow As DataRow
            For i As Integer = 0 To rs_BJR00001C.Tables("RESULT").Rows.Count - 1
                dr = Nothing
                dr = rs_BJR00001.Tables("RESULT").Select("pod_jobord = '" & rs_BJR00001C.Tables("RESULT").Rows(i)("pod_jobord") & "'")
                newRow = Nothing

                If dr.Length = 0 Then
                    newRow = rs_BJR00001.Tables("RESULT").NewRow
                    newRow("pod_scno") = rs_BJR00001C.Tables("RESULT").Rows(i)("pod_scno")
                    newRow("pod_jobord") = rs_BJR00001C.Tables("RESULT").Rows(i)("pod_jobord")
                    newRow("pod_runno") = rs_BJR00001C.Tables("RESULT").Rows(i)("pod_runno")
                    newRow("pod_itmno") = rs_BJR00001C.Tables("RESULT").Rows(i)("pod_itmno")
                    newRow("vbi_vensna") = rs_BJR00001C.Tables("RESULT").Rows(i)("vbi_vensna")
                    newRow("pjd_confrm") = "Y"
                    newRow("pjd_batseq") = ""
                    newRow("pjd_recsts") = "new"
                    newRow("vencde") = rs_BJR00001C.Tables("RESULT").Rows(i)("vencde")
                    rs_BJR00001.Tables("RESULT").Rows.Add(newRow)
                    rs_BJR00001.AcceptChanges()

                    recordStatus = True
                End If
            Next
        End If
    End Sub

    Private Sub display()
        dgBatchJob.DataSource = rs_BJR00001.Tables("RESULT").DefaultView

        For i As Integer = 0 To rs_BJR00001.Tables("RESULT").Columns.Count - 1
            With dgBatchJob
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "SC No."
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Job No."
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "Running No."
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Item No."
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Vendor"
                        .Columns(i).Width = 100

                        .Columns(i).ReadOnly = True
                    Case 5
                        dgBatchJob_Confirm = i
                        .Columns(i).HeaderText = "Confirm"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).Width = 60

                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Seq No."
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            End With
        Next

        dgBatchJob.ClearSelection()
    End Sub

    Private Sub countY()
        If rs_BJR00001 Is Nothing Then
            txtCount.Text = ""
        Else
            Dim dr() As DataRow = rs_BJR00001.Tables("RESULT").Select("pjd_confrm = 'Y'")
            txtCount.Text = dr.Length
        End If
    End Sub

    Private Function checkChangesMade(ByVal JobNo As String) As Boolean
        Dim dr_ori() As DataRow = rs_BJR00001_ori.Tables("RESULT").Select("pod_jobord = '" & JobNo & "'")
        Dim dr() As DataRow = rs_BJR00001.Tables("RESULT").Select("pod_jobord = '" & JobNo & "'")

        If dr_ori.Length = 0 Then
            Return False
        Else
            For i As Integer = 0 To rs_BJR00001.Tables("RESULT").Columns.Count - 1
                If dr_ori(0).Item(i) <> dr(0).Item(i) Then
                    Return True
                End If
            Next
            Return False
        End If
    End Function

    Private Sub exportPOReport()
        Dim exportType As String = ""
        If optPDF.Checked = True Then
            exportType = "PDF"
        ElseIf optExcel.Checked = True Then
            exportType = "XLS"
        Else
            exportType = "XLS"
        End If

        gspStr = "sp_list_POJBBDTL_SMK_2 '" & cboCoCde.Text & "','" & Trim(txtBJNo.Text) & "','" & exportType & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_Report = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_Report, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BJR00001 #008 sp_list_POJBBDTL_SMK_2 : " & rtnStr)
            Exit Sub
        ElseIf rs_Report.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found", MsgBoxStyle.Information, "BJR00001 - PO Report")
            Exit Sub
        End If

        If exportType = "PDF" Then
            Dim objRpt As New POR00006Rpt
            Dim frmReportView As New frmReport

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            objRpt.Database.Tables("por00006").SetDataSource(rs_Report.Tables("RESULT"))
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
            Me.Cursor = Windows.Forms.Cursors.Default
        ElseIf exportType = "XLS" Then
            If rs_Report.Tables("RESULT").Rows.Count > 65535 Then
                MsgBox("Record count exceed Excel maximum allowable limit.", MsgBoxStyle.Exclamation, "BJR00001 - PO Report")
                Exit Sub
            End If

            Dim xlsApp As New Excel.ApplicationClass
            Dim xlsWB As Excel.Workbook = Nothing
            Dim xlsWS As Excel.Worksheet = Nothing

            Dim hdrRow As Integer = 1

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            xlsApp = New Excel.Application
            xlsApp.Visible = False
            xlsApp.UserControl = True

            'Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            xlsWB = xlsApp.Workbooks.Add()
            xlsWS = xlsWB.ActiveSheet

            With xlsApp
                'Header Setup
                .Rows(hdrRow).Font.Bold = True
                .Rows(hdrRow).Font.Size = 14
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).MergeCells = True
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).Value = rs_Report.Tables("RESULT").Rows(0)("conam").ToString
                hdrRow += 1
                .Rows(hdrRow).Font.Bold = True
                .Rows(hdrRow).Font.Size = 12
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).MergeCells = True
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).Value = "PRODUCTION ORDER REPORT"
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 3) = "Report ID :"
                .Range(.Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2) = "POR00006"
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                .Cells(hdrRow, 1) = "Batch No :"
                .Cells(hdrRow, 2) = Trim(txtBJNo.Text)
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 3) = "Date :"
                .Range(.Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2) = Format(Date.Today, "MM/dd/yyyy").ToString
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 3) = "Time :"
                .Range(.Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2) = Format(Date.Now, "HH:mm:ss").ToString
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                For i As Integer = 0 To rs_Report.Tables("RESULT").Columns.Count - 1
                    .Cells(hdrRow, i + 1) = rs_Report.Tables("RESULT").Columns(i).ColumnName
                Next
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                'Populate Data
                Dim entry(rs_Report.Tables("RESULT").Columns.Count - 1) As String
                For i As Integer = 0 To rs_Report.Tables("RESULT").Rows.Count - 1
                    For j As Integer = 0 To rs_Report.Tables("RESULT").Columns.Count - 1
                        entry(j) = rs_Report.Tables("RESULT").Rows(i)(j).ToString
                    Next
                    .Range(.Cells(hdrRow + i + 1, 1), .Cells(hdrRow + i + 1, rs_Report.Tables("RESULT").Columns.Count)).Value = entry
                Next
                
                'Delete Company Name Column
                .Range(.Cells(hdrRow, 9), .Cells(hdrRow, 9)).EntireColumn.Delete()

                'Styling
                .Columns(1).ColumnWidth = 10
                .Columns(2).ColumnWidth = 25
                .Columns(3).ColumnWidth = 15
                .Columns(4).ColumnWidth = 12
                .Columns(5).ColumnWidth = 18
                .Columns(6).ColumnWidth = 15
                .Columns(7).ColumnWidth = 15
                .Columns(8).ColumnWidth = 10
                .Columns(9).ColumnWidth = 15
            End With

            xlsApp.Visible = True

            ' Release reference
            rs_Report = Nothing
            xlsWS = Nothing
            xlsWB = Nothing
            xlsApp = Nothing

            Me.Cursor = Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub exportBJItemReport()
        gspStr = "sp_list_POJBBDTL_excel '" & cboCoCde.Text & "','" & Trim(txtBJNo.Text) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_Report = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_Report, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BJR00001 #007 sp_list_POJBBDTL_excel : " & rtnStr)
            Exit Sub
        End If

        If rs_Report.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found", MsgBoxStyle.Information, "BJR00001 - Batch Job Item Report")
            Exit Sub
        ElseIf rs_Report.Tables("RESULT").Rows.Count > 65535 Then
            MsgBox("Record count exceed Excel maximum allowable limit.", MsgBoxStyle.Exclamation, "BJR00001 - Batch Job Item Report")
            Exit Sub
        End If

        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        Dim hdrRow As Integer = 1

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        'Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        With xlsApp
            'Header Setup
            .Rows(hdrRow).Font.Bold = True
            .Rows(hdrRow).Font.Size = 10
            For i As Integer = 2 To rs_Report.Tables("RESULT").Columns.Count - 1
                .Cells(hdrRow, i - 1) = rs_Report.Tables("RESULT").Columns(i).ColumnName
            Next
            .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

            'Populate Data
            Dim entry(rs_Report.Tables("RESULT").Columns.Count - 2) As String
            For i As Integer = 0 To rs_Report.Tables("RESULT").Rows.Count - 1
                For j As Integer = 2 To rs_Report.Tables("RESULT").Columns.Count - 1
                    entry(j - 2) = rs_Report.Tables("RESULT").Rows(i)(j).ToString
                Next
                .Range(.Cells(hdrRow + i + 1, 1), .Cells(hdrRow + i + 1, rs_Report.Tables("RESULT").Columns.Count - 2)).Value = entry
            Next

            'Styling
            .Columns(1).ColumnWidth = 10
            .Columns(2).ColumnWidth = 15
            .Columns(3).ColumnWidth = 15
            .Columns(4).ColumnWidth = 50
            .Columns(5).ColumnWidth = 50
            .Columns(6).ColumnWidth = 15
            .Columns(7).ColumnWidth = 15
            .Columns(8).ColumnWidth = 10

        End With

        xlsApp.Visible = True

        ' Release reference
        rs_Report = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class