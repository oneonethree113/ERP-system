Public Class IMR00010

    Private Sub IMR00010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        dtpfromTrandat.Value = Today
        dtptoTranDat.Value = Today

        Call fillcboCus()

        Call Formstartup(Me.Name)   'Set the form Sartup position

        Me.KeyPreview = True
        Cursor = Cursors.Default
    End Sub

    Private Sub fillcboCus()
        Dim rs_CUBASINF As New DataSet

        'S = "㊣CUBASINF※L※PA"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_list_CUBASINF '" & gsCompany & "','PA'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillcboCus sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_CUBASINF.Tables("RESULT").Rows.Count - 1
                If rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno").ToString > "50000" Then
                    cboCustNoFm.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                    cboCustNoTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                End If
            Next
        End If
    End Sub

    Private Sub cboCustNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SelectedIndexChanged
        cboCustNoTo.Text = cboCustNoFm.Text
    End Sub

    Private Sub cboCustNoFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoFm.KeyUp
        Call auto_search_combo(cboCustNoFm)
    End Sub

    Private Sub cboCustNoTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoTo.KeyUp
        Call auto_search_combo(cboCustNoTo)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim AscDesc As String
        Dim rs_IMR00010 As New DataSet
        Dim tmpRecCount As Long
        Dim tmpcatlvl4 As String
        Dim j As Long
        Dim i As Integer
        Dim txtRecSts As String

        txtRecSts = ""

        If chkRecStsA.Checked Then
            txtRecSts = txtRecSts + "@A@" + ","
        End If
        If chkRecStsI.Checked Then
            txtRecSts = txtRecSts + "@I@" + ","
        End If
        If chkRecStsO.Checked Then
            txtRecSts = txtRecSts + "@O@" + ","
        End If
        If chkRecStsR.Checked Then
            txtRecSts = txtRecSts + "@R@" + ","
        End If
        If chkRecStsW.Checked Then
            txtRecSts = txtRecSts + "@W@"
        End If

        If txtRecSts = "" Then
            MsgBox("No Record Status is selected.")
            Exit Sub
        End If

        If dtptoTranDat.Value < dtpfromTrandat.Value Then
            MsgBox("Invalid Input! (Start Date <=  End Date)!")
            dtpfromTrandat.Focus()
            Exit Sub
        End If

        '***************************************************
        '*** Get System Category record  *******************
        '***************************************************
        Dim CUSTNOFM As String
        Dim CUSTNOTO As String

        If Trim(cboCustNoFm.Text) = "" Then
            CUSTNOFM = "50000"
        Else
            CUSTNOFM = Split(Trim(cboCustNoFm.Text), " - ")(0)
        End If

        If Trim(cboCustNoTo.Text) = "" Then
            CUSTNOTO = "59999"
        Else
            CUSTNOTO = Split(Trim(cboCustNoTo.Text), " - ")(0)
        End If

        'S = "㊣IMR00010※L※" + txtRecSts + "※" + CUSTNOFM + "※" + CUSTNOTO + "※" + Str(dtpfromTrandat.Value) + "※" + Str(dtptoTranDat.Value) + "※" + gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_list_IMR00010 '" & gsCompany & "','" & _
                                        txtRecSts & "','" & _
                                        CUSTNOFM & "','" & _
                                        CUSTNOTO & "','" & _
                                        dtpfromTrandat.Value.ToShortDateString & "','" & _
                                        dtptoTranDat.Value.ToShortDateString & "','" & _
                                        gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMR00010, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdShow_Click sp_list_IMR00010 :" & rtnStr)
            Exit Sub
        End If

        If rs_IMR00010.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
            Exit Sub
        Else
            Dim objRpt As New IMR00010Rpt
            objRpt.SetDataSource(rs_IMR00010.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()

            'ReportName(0) = "IMR00010.rpt"
            'ReportRS(0) = rs_IMR00004
            'frmReport.Show()
        End If
    End Sub
End Class