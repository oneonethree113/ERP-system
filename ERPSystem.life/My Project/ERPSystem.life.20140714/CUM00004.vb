Public Class CUM00004

    Dim rs_CUCPTBKD As DataSet
    Dim rs_Summary As DataSet

    Private Sub CUM00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        setStatus("INIT")
    End Sub

    Private Sub CUM00004_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        If Trim(txtCus1no.Text) = "" And Trim(txtCus2no.Text) = "" And Trim(txtItmNo.Text) = "" And Trim(txtColCde.Text) = "" Then
            MsgBox("At least one search parameter must be enetered", MsgBoxStyle.Information, "CUM00004 - Find")
            Exit Sub
        End If

        If Trim(txtCus1no.Text) = "" And Trim(txtCus2no.Text) <> "" Then
            MsgBox("Secondary Customer must be entered with a Primary Customer", MsgBoxStyle.Information, "CUM00004 - Find")
            Exit Sub
        End If

        txtItmNo.Text = UCase(txtItmNo.Text)
        txtColCde.Text = UCase(txtColCde.Text)

        gspStr = "sp_select_CUCPTBKD '','" & Trim(Replace(txtCus1no.Text, "'", "''")) & "','" & _
                 Trim(Replace(txtCus2no.Text, "'", "''")) & "','" & Trim(Replace(txtItmNo.Text, "'", "''")) & _
                 "','" & Trim(Replace(txtColCde.Text, "'", "''")) & "','" & LCase(gsUsrID) & "'"
        rs_CUCPTBKD = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUCPTBKD, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CUM00004 #001 sp_select_CUCPTBKD : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_CUCPTBKD.Tables("RESULT").Columns.Count - 1
                rs_CUCPTBKD.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        If rs_CUCPTBKD.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Results Found", MsgBoxStyle.Information, "CUM00004 - Find")
            Me.Close()
            'Exit Sub
        Else
            rs_Summary = rs_CUCPTBKD.Clone()

            Dim dr As DataRow()
            Dim newRow As DataRow
            For i As Integer = 0 To rs_CUCPTBKD.Tables("RESULT").Rows.Count - 1
                dr = Nothing
                dr = rs_Summary.Tables("RESULT").Select("ccb_cus1no = '" & rs_CUCPTBKD.Tables("RESULT").Rows(i)("ccb_cus1no") & "' and " & _
                                                        "ccb_cus2no = '" & rs_CUCPTBKD.Tables("RESULT").Rows(i)("ccb_cus2no") & "' and " & _
                                                        "ccb_itmno = '" & rs_CUCPTBKD.Tables("RESULT").Rows(i)("ccb_itmno") & "' and " & _
                                                        "ccb_colcde = '" & rs_CUCPTBKD.Tables("RESULT").Rows(i)("ccb_colcde") & "'")
                If dr.Length = 0 Then
                    newRow = Nothing
                    newRow = rs_Summary.Tables("RESULT").NewRow
                    For j As Integer = 0 To rs_Summary.Tables("RESULT").Columns.Count - 1
                        newRow(j) = rs_CUCPTBKD.Tables("RESULT").Rows(i)(j)
                    Next
                    rs_Summary.Tables("RESULT").Rows.Add(newRow)
                    rs_Summary.AcceptChanges()
                End If
            Next

            setStatus("READ")

        End If

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        setStatus("INIT")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Close()
    End Sub

    Private Sub setStatus(ByVal mode As String)
        Select Case UCase(mode)
            Case "INIT"
                cmdAdd.Enabled = False
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdCopy.Enabled = False
                cmdFind.Enabled = True
                'cmdClear.Enabled = True
                cmdClear.Enabled = False
                cmdSearch.Enabled = False
                cmdInsRow.Enabled = False
                cmdDelRow.Enabled = False
                cmdFirst.Enabled = False
                cmdPrevious.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
                cmdExit.Enabled = True

                txtCus1no.Enabled = True
                txtCus2no.Enabled = True
                txtItmNo.Enabled = True
                txtColCde.Enabled = True

                txtCus1no.Text = ""
                txtCus2no.Text = ""
                txtItmNo.Text = ""
                txtColCde.Text = ""

                tabFrame.SelectedIndex = 0
                tabFrame.Enabled = False

                dgSummary.DataSource = Nothing
                rs_Summary = Nothing

                txtCPTCus1No.Enabled = False
                txtCPTCust2No.Enabled = False
                txtCPTItmNo.Enabled = False
                txtCPTColCde.Enabled = False

                txtCPTCus1No.Text = ""
                txtCPTCust2No.Text = ""
                txtCPTItmNo.Text = ""
                txtCPTColCde.Text = ""
                dgCUCPTBKD.DataSource = Nothing
                rs_CUCPTBKD = Nothing
            Case "READ"
                cmdAdd.Enabled = False
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdCopy.Enabled = False
                cmdFind.Enabled = False
                'cmdClear.Enabled = True
                cmdClear.Enabled = False
                cmdSearch.Enabled = False
                cmdInsRow.Enabled = False
                cmdDelRow.Enabled = False
                cmdFirst.Enabled = False
                cmdPrevious.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
                cmdExit.Enabled = True

                txtCus1no.Enabled = False
                txtCus2no.Enabled = False
                txtItmNo.Enabled = False
                txtColCde.Enabled = False

                tabFrame.SelectedIndex = 0
                tabFrame.Enabled = True

                txtCPTCus1No.Enabled = False
                txtCPTCust2No.Enabled = False
                txtCPTItmNo.Enabled = False
                txtCPTColCde.Enabled = False

                txtCPTCus1No.Text = ""
                txtCPTCust2No.Text = ""
                txtCPTItmNo.Text = ""
                txtCPTColCde.Text = ""

                display_dgSummary()
            Case Else

        End Select
    End Sub

    Private Sub validateCustomer(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCus2no.Validating, txtCus1no.Validating
        If cmdClear.Focused Or cmdExit.Focused Then
            Exit Sub
        End If

        If IsNumeric(Trim(sender.Text)) = False And sender.Text <> "" Then
            e.Cancel = True
            MsgBox("Invalid Customer Code", MsgBoxStyle.Information, "CUM00004 - Invalid Customer Code")
            Exit Sub
        End If
    End Sub

    Private Sub text_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNo.KeyPress, txtCus2no.KeyPress, txtCus1no.KeyPress, txtColCde.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdFind.PerformClick()
        End If
    End Sub

    Private Sub display_dgSummary()
        dgSummary.DataSource = rs_Summary.Tables("RESULT").DefaultView

        For i As Integer = 0 To dgSummary.Columns.Count - 1
            dgSummary.Columns(i).Visible = True
            dgSummary.Columns(i).ReadOnly = True
            Select Case dgSummary.Columns(i).Name
                Case "ccb_cus1no"
                    dgSummary.Columns(i).HeaderText = "Pri Cust."
                    dgSummary.Columns(i).Width = 80
                Case "ccb_cus2no"
                    dgSummary.Columns(i).HeaderText = "Sec Cust."
                    dgSummary.Columns(i).Width = 80
                Case "ccb_itmno"
                    dgSummary.Columns(i).HeaderText = "Item No."
                    dgSummary.Columns(i).Width = 120
                Case "ccb_colcde"
                    dgSummary.Columns(i).HeaderText = "Color Code"
                    dgSummary.Columns(i).Width = 120
                Case Else
                    dgSummary.Columns(i).Visible = False
            End Select
        Next

        dgSummary.ClearSelection()
    End Sub

    Private Sub display_dgCUCPTBKD()
        dgCUCPTBKD.DataSource = rs_CUCPTBKD.Tables("RESULT").DefaultView

        For i As Integer = 0 To dgCUCPTBKD.Columns.Count - 1
            dgCUCPTBKD.Columns(i).Visible = True
            dgCUCPTBKD.Columns(i).ReadOnly = True
            Select Case dgCUCPTBKD.Columns(i).Name
                Case "ccb_cpt"
                    dgCUCPTBKD.Columns(i).HeaderText = "Components"
                    dgCUCPTBKD.Columns(i).Width = 200
                Case "ccb_curcde"
                    dgCUCPTBKD.Columns(i).HeaderText = "Currency"
                    dgCUCPTBKD.Columns(i).Width = 80
                Case "ccb_cst"
                    dgCUCPTBKD.Columns(i).HeaderText = "Cost"
                    dgCUCPTBKD.Columns(i).Width = 70
                    dgCUCPTBKD.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ccb_cstpct"
                    dgCUCPTBKD.Columns(i).HeaderText = "Cost %"
                    dgCUCPTBKD.Columns(i).Width = 80
                Case "ccb_pct"
                    dgCUCPTBKD.Columns(i).HeaderText = "Weight %"
                    dgCUCPTBKD.Columns(i).Width = 80
                Case Else
                    dgCUCPTBKD.Columns(i).Visible = False
            End Select
        Next

        dgCUCPTBKD.ClearSelection()
    End Sub

    Private Sub tabFrame_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tabFrame.Selecting
        If e.TabPage.ToString = tabComponents.ToString Then
            If dgSummary.CurrentRow Is Nothing Then
                e.Cancel = True
                MsgBox("Please select a record for viewing", MsgBoxStyle.Information, "CUM00004 - Material Breakdown")
                Exit Sub
            End If

            txtCPTCus1No.Text = dgSummary.CurrentRow.Cells("ccb_cus1no").Value
            txtCPTCust2No.Text = dgSummary.CurrentRow.Cells("ccb_cus2no").Value
            txtCPTItmNo.Text = dgSummary.CurrentRow.Cells("ccb_itmno").Value
            txtCPTColCde.Text = dgSummary.CurrentRow.Cells("ccb_colcde").Value

            rs_CUCPTBKD.Tables("RESULT").DefaultView.RowFilter = "ccb_cus1no = '" & dgSummary.CurrentRow.Cells("ccb_cus1no").Value & "' and " & _
                                                                 "ccb_cus2no = '" & dgSummary.CurrentRow.Cells("ccb_cus2no").Value & "' and " & _
                                                                 "ccb_itmno = '" & dgSummary.CurrentRow.Cells("ccb_itmno").Value & "' and " & _
                                                                 "ccb_colcde = '" & dgSummary.CurrentRow.Cells("ccb_colcde").Value & "'"
            display_dgCUCPTBKD()
        End If
    End Sub
End Class