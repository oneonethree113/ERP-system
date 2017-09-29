Public Class FQM00001

    Dim rs_FQM00001 As New DataSet
    Dim rs_FQM00001_fty As New DataSet
    Dim rs_FQM00001_aud As New DataSet
    'Dim dsNewRow As DataRow
    'Dim rs_FQC00001_applist As DataSet

    Private Sub FQC00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearAllDisplay()
        Formstartup(Me.Name)
    End Sub

    Private Sub clearAllDisplay()
        txtFtyNo.Text = ""
        txtVdrName.Text = ""
        txtFtySts.Text = ""
        txtFtyName.Text = ""
        txtCont.Text = ""
        txtTelNo.Text = ""
        txtFtyAddr.Text = ""
        dgFactory.DataSource = ""
        dgRecent.DataSource = ""
        dgPrevious.DataSource = ""
        dgOrder.DataSource = ""
    End Sub

    Private Sub txtFtyNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFtyNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            cmdFind_Click(Me, e)
        End If
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim sFtyNo As String = txtFtyNo.Text.Trim

        clearAllDisplay()

        txtFtyNo.Text = sFtyNo

        Try
            gspStr = "sp_list_FQM00001 '" & _
                        sFtyNo & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_FQM00001, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading FQM00001 #001 sp_list_FQM00001 : " & rtnStr)
                Exit Sub
            Else
                If rs_FQM00001.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Record found!")
                    txtFtyNo.Focus()
                    Exit Sub
                Else
                    reconstruct_rs_FQM00001()
                    txtFtySts.Text = rs_FQM00001.Tables("RESULT").Rows(0).Item("zftysta").ToString
                    txtVdrName.Text = rs_FQM00001.Tables("RESULT").Rows(0).Item("zname").ToString
                    txtFtyName.Text = rs_FQM00001.Tables("RESULT").Rows(0).Item("zcname").ToString
                    txtCont.Text = rs_FQM00001.Tables("RESULT").Rows(0).Item("zcontact").ToString
                    txtTelNo.Text = rs_FQM00001.Tables("RESULT").Rows(0).Item("ztelno").ToString
                    txtFtyAddr.Text = rs_FQM00001.Tables("RESULT").Rows(0).Item("zcaddress").ToString
                End If
            End If

            gspStr = "sp_list_FQM00001_fty '" & _
                        sFtyNo & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_FQM00001_fty, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading FQM00001 #002 sp_list_FQM00001_fty : " & rtnStr)
            Else
                If rs_FQM00001_fty.Tables("RESULT").Rows.Count > 0 Then
                    reconstruct_rs_FQM00001_fty()
                    dgFactory.DataSource = rs_FQM00001_fty.Tables("RESULT").DefaultView
                    Call format_dgFactory()
                    dgFactory.ClearSelection()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub reconstruct_rs_FQM00001()
        rs_FQM00001.Tables("RESULT").Columns("zftysta").ReadOnly = False
        If rs_FQM00001.Tables("RESULT").Rows(0).Item("zftysta").ToString.Trim = "A" Then
            rs_FQM00001.Tables("RESULT").Rows(0).Item("zftysta") = "A Active"
        ElseIf rs_FQM00001.Tables("RESULT").Rows(0).Item("zftysta").ToString.Trim = "I" Then
            rs_FQM00001.Tables("RESULT").Rows(0).Item("zftysta") = "I Inactive"
        Else
            rs_FQM00001.Tables("RESULT").Rows(0).Item("zftysta") = "D Discontinue"
        End If
        rs_FQM00001.Tables("RESULT").Columns("zftysta").ReadOnly = True
    End Sub

    Private Sub reconstruct_rs_FQM00001_fty()
        rs_FQM00001_fty.Tables("RESULT").Columns("zlifnr_sta").ReadOnly = False
        For index As Integer = 0 To rs_FQM00001_fty.Tables("RESULT").Rows.Count - 1
            If rs_FQM00001_fty.Tables("RESULT").Rows(index).Item("zlifnr_sta").ToString.Trim = "A" Then
                rs_FQM00001_fty.Tables("RESULT").Rows(index).Item("zlifnr_sta") = "Active"
            ElseIf rs_FQM00001_fty.Tables("RESULT").Rows(index).Item("zlifnr_sta").ToString.Trim = "I" Then
                rs_FQM00001_fty.Tables("RESULT").Rows(index).Item("zlifnr_sta") = "Inactive"
            Else
                rs_FQM00001_fty.Tables("RESULT").Rows(index).Item("zlifnr_sta") = "Discontinue"
            End If
        Next
        rs_FQM00001_fty.Tables("RESULT").Columns("zlifnr_sta").ReadOnly = True
    End Sub

    Private Sub format_dgFactory()
        ''Start Sample data for display
        'Dim rs_FQC00001_applist As New DataSet

        'rs_FQC00001_applist.Tables.Add("RESULT")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("1")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("2")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("3")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("4")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("5")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("6")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("7")
        'rs_FQC00001_applist.Tables("RESULT").Columns.Add("8")

        'dsNewRow = rs_FQC00001_applist.Tables("RESULT").NewRow()

        'dsNewRow.Item("1") = "50360"
        'dsNewRow.Item("2") = "ASSOCIATED MERCHANDISING CORPORATIO"
        'dsNewRow.Item("3") = "1616"
        'dsNewRow.Item("4") = "DUNHUANG (敦煌)"
        'dsNewRow.Item("5") = "Active"
        'dsNewRow.Item("6") = "4R44364"
        'dsNewRow.Item("7") = "4363"
        'dsNewRow.Item("8") = "4363"

        'rs_FQC00001_applist.Tables("RESULT").Rows.Add(dsNewRow)

        'dsNewRow = rs_FQC00001_applist.Tables("RESULT").NewRow()

        'dsNewRow.Item("1") = "60328"
        'dsNewRow.Item("2") = "WAL-MART INT'L"
        'dsNewRow.Item("3") = "1616"
        'dsNewRow.Item("4") = "DUNHUANG (敦煌)"
        'dsNewRow.Item("5") = "Active"
        'dsNewRow.Item("6") = "4R464"
        'dsNewRow.Item("7") = "433"
        'dsNewRow.Item("8") = "433"

        'rs_FQC00001_applist.Tables("RESULT").Rows.Add(dsNewRow)

        'dgFactory.DataSource = rs_FQC00001_applist.Tables("RESULT").DefaultView
        'End Sample data for display

        dgFactory.Columns(0).Width = 75
        dgFactory.Columns(0).HeaderText = "Cust No"
        dgFactory.Columns(0).ReadOnly = True

        dgFactory.Columns(1).Width = 150
        dgFactory.Columns(1).HeaderText = "Customer"
        dgFactory.Columns(1).ReadOnly = True

        dgFactory.Columns(2).Width = 70
        dgFactory.Columns(2).HeaderText = "Vdr No"
        dgFactory.Columns(2).ReadOnly = True

        dgFactory.Columns(3).Width = 130
        dgFactory.Columns(3).HeaderText = "Vendor"
        dgFactory.Columns(3).ReadOnly = True

        dgFactory.Columns(4).Width = 90
        dgFactory.Columns(4).HeaderText = "Vdr Status"
        dgFactory.Columns(4).ReadOnly = True

        dgFactory.Columns(5).Width = 100
        dgFactory.Columns(5).HeaderText = "Ref Vdr ID"
        dgFactory.Columns(5).ReadOnly = True

        dgFactory.Columns(6).Width = 100
        dgFactory.Columns(6).HeaderText = "Ref Fty ID"
        dgFactory.Columns(6).ReadOnly = True

        dgFactory.Columns(7).Width = 100
        dgFactory.Columns(7).HeaderText = "Contact Co"
        dgFactory.Columns(7).ReadOnly = True
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        clearAllDisplay()
    End Sub

    Private Sub dgFactory_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgFactory.CellMouseUp
        If dgFactory.SelectedRows.Count = 1 Then
            Try
                gspStr = "sp_list_FQM00001_aud '" & _
                                txtFtyNo.Text.Trim & "','" & _
                                dgFactory.SelectedRows(0).Cells("zlifnr").Value.ToString & "','" & _
                                dgFactory.SelectedRows(0).Cells("kunnr").Value.ToString & "'"

                rtnLong = execute_SQLStatement(gspStr, rs_FQM00001_aud, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading FQM00001 #003 sp_list_FQM00001_aud : " & rtnStr)
                Else
                    If rs_FQM00001_aud.Tables("RESULT").Rows.Count = 0 Then
                        dgRecent.DataSource = ""
                    Else
                        reconstruct_rs_FQM00001_aud()
                        dgRecent.DataSource = rs_FQM00001_aud.Tables("RESULT").DefaultView
                        Call format_dgRecent()
                        dgRecent.ClearSelection()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub reconstruct_rs_FQM00001_aud()
        rs_FQM00001_aud.Tables("RESULT").Columns("zauditem").ReadOnly = False
        rs_FQM00001_aud.Tables("RESULT").Columns("zaudtype").ReadOnly = False
        rs_FQM00001_aud.Tables("RESULT").Columns("zrating").ReadOnly = False
        rs_FQM00001_aud.Tables("RESULT").Columns("zrisk").ReadOnly = False
        rs_FQM00001_aud.Tables("RESULT").Columns("zresult").ReadOnly = False
        For index As Integer = 0 To rs_FQM00001_aud.Tables("RESULT").Rows.Count - 1
            If rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem").ToString.Trim = "ES" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem") = "Ethical Standards Inspection"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem").ToString.Trim = "FE" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem") = "Factory Evaluation"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem").ToString.Trim = "FCCA" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem") = "Factory Capability & Capacity Audit"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem").ToString.Trim = "GSV" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem") = "Global Security Verification"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem").ToString.Trim = "INT" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem") = "Internal Audit"
            Else
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zauditem") = "Social Compliance"
            End If

            If rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zaudtype").ToString.Trim = "I" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zaudtype") = "Initial Audit"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zaudtype").ToString.Trim = "R" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zaudtype") = "Re-audit"
            Else
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zaudtype") = "Annual Audit"
            End If

            If rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrating").ToString.Trim = "G" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrating") = "Green Light"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrating").ToString.Trim = "O" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrating") = "Orange Light"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrating").ToString.Trim = "R" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrating") = "Red Light"
            Else
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrating") = "Yellow Light"
            End If

            If rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrisk").ToString.Trim = "A" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrisk") = "Low Risk Priority"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrisk").ToString.Trim = "B" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrisk") = "Medium Risk Priority"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrisk").ToString.Trim = "C" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrisk") = "High Risk Priority"
            Else
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zrisk") = "Very High Risk Priority"
            End If

            If rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult").ToString.Trim = "01" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult") = "Scheduling"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult").ToString.Trim = "02" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult") = "Accept/Pass"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult").ToString.Trim = "03" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult") = "Accept but need improvement"
            ElseIf rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult").ToString.Trim = "04" Then
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult") = "Unaccept/Fail"
            Else
                rs_FQM00001_aud.Tables("RESULT").Rows(index).Item("zresult") = "Appeal"
            End If
        Next
        rs_FQM00001_aud.Tables("RESULT").Columns("zauditem").ReadOnly = True
        rs_FQM00001_aud.Tables("RESULT").Columns("zaudtype").ReadOnly = True
        rs_FQM00001_aud.Tables("RESULT").Columns("zrating").ReadOnly = True
        rs_FQM00001_aud.Tables("RESULT").Columns("zrisk").ReadOnly = True
        rs_FQM00001_aud.Tables("RESULT").Columns("zresult").ReadOnly = True
    End Sub

    Private Sub format_dgRecent()
        dgRecent.Columns(0).Width = 180
        dgRecent.Columns(0).HeaderText = "Audit Item"
        dgRecent.Columns(0).ReadOnly = True

        dgRecent.Columns(1).Width = 90
        dgRecent.Columns(1).HeaderText = "Audit Type"
        dgRecent.Columns(1).ReadOnly = True

        dgRecent.Columns(2).Width = 90
        dgRecent.Columns(2).HeaderText = "Request No"
        dgRecent.Columns(2).ReadOnly = True

        dgRecent.Columns(3).Width = 100
        dgRecent.Columns(3).HeaderText = "Reference No"
        dgRecent.Columns(3).ReadOnly = True

        dgRecent.Columns(4).Width = 150
        dgRecent.Columns(4).HeaderText = "Audit Company"
        dgRecent.Columns(4).ReadOnly = True

        dgRecent.Columns(5).Width = 80
        dgRecent.Columns(5).HeaderText = "Auditor"
        dgRecent.Columns(5).ReadOnly = True

        dgRecent.Columns(6).Width = 105
        dgRecent.Columns(6).HeaderText = "Schedule Date"
        dgRecent.Columns(6).ReadOnly = True

        dgRecent.Columns(7).Width = 105
        dgRecent.Columns(7).HeaderText = "Aud St Date"
        dgRecent.Columns(7).ReadOnly = True

        dgRecent.Columns(8).Width = 105
        dgRecent.Columns(8).HeaderText = "Aud End Date"
        dgRecent.Columns(8).ReadOnly = True

        dgRecent.Columns(9).Width = 80
        dgRecent.Columns(9).HeaderText = "Rating"
        dgRecent.Columns(9).ReadOnly = True

        dgRecent.Columns(10).Width = 50
        dgRecent.Columns(10).HeaderText = "Score"
        dgRecent.Columns(10).ReadOnly = True

        dgRecent.Columns(11).Width = 110
        dgRecent.Columns(11).HeaderText = "Risk Level"
        dgRecent.Columns(11).ReadOnly = True

        dgRecent.Columns(12).Width = 100
        dgRecent.Columns(12).HeaderText = "Result"
        dgRecent.Columns(12).ReadOnly = True

        dgRecent.Columns(13).Width = 105
        dgRecent.Columns(13).HeaderText = "Valid From"
        dgRecent.Columns(13).ReadOnly = True

        dgRecent.Columns(14).Width = 105
        dgRecent.Columns(14).HeaderText = "Valid To"
        dgRecent.Columns(14).ReadOnly = True

        dgRecent.Columns(15).Width = 150
        dgRecent.Columns(15).HeaderText = "Note"
        dgRecent.Columns(15).ReadOnly = True
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class