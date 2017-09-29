Public Class POR00003


    Public rs_POR00003 As New DataSet

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------


        '-- * Past parameter to store port (Suppress ZERO Qty)
        Dim Sup0 As String
        If OptSupY.Checked = True Then
            Sup0 = "Y"
        Else
            Sup0 = "N"
        End If


        If txtFm.Text = "" Or txtTo.Text = "" Then
            MsgBox("BOM No empty !")
            Exit Sub
        End If


        Dim S As String
        Dim rs() As ADOR.Recordset

        gspStr = "sp_select_POR00003 '" & gsCompany & "','" & txtFm.Text & "','" & txtTo.Text & "','" & Sup0 & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_POR00003, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00003 cmdShow_Click sp_select_POR00003 : " & rtnStr)
            Exit Sub
        Else

            If rs_POR00003.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No record found !")
                Exit Sub
            Else
                Dim objRpt As New POR00003Rpt
                objRpt.SetDataSource(rs_POR00003.Tables("RESULT"))
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            End If
        End If

    End Sub

    Private Sub POR00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)

        Call Formstartup(Me.Name)
    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged
        txtTo.Text = txtFm.Text
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
    End Sub


End Class