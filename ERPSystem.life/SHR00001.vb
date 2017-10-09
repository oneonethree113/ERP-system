Public Class SHR00001

    Private Sub SHR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Initialize
        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        'ComboBox_rpformat.Items.Add("Container List Standard Format 1")
        ComboBox_rpformat.Items.Add("Container List Standard Format 2")
        ComboBox_rpformat.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox_rpformat.SelectedIndex = 0
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim rs_Result As DataSet

        'Update Company Code before execute
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'Check Container #
        If txtFromContain.Text > txtToContain.Text Then
            MsgBox("Invalid Input! (From item No. <= To Item No!)")
            Me.Cursor = Windows.Forms.Cursors.Default
            txtFromContain.Focus()
            Exit Sub
        End If

        gspStr = "sp_select_SHR00001_container_NET '" & gsCompany & "','" & txtFromContain.Text & "','" & txtToContain.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SHR00001_container_NET : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If rs_Result.Tables("Result").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No results found")
            Exit Sub
        Else
            Dim objRpt As New SHR00001Rpt2
            objRpt.SetDataSource(rs_Result.Tables("RESULT"))
            'Add Subreport report source
            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub
End Class