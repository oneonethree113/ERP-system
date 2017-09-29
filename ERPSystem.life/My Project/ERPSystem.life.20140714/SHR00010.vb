Public Class SHR00010

    Public rs_SHR00010 As New DataSet

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        gspStr = "sp_select_SHR00010 '','" & Me.txtdocno.Text & "', 'E'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHR00010, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHR00010 #001 sp_select_SHR00010 : " & rtnStr)
            Exit Sub
        End If


        'If cmbImageOnly.ListIndex = 0 Then
        '    Rpt_BSP00001 = New BSP00001Rpt
        '    Rpt_BSP00001.Database.SetDataSource(rs_BSP00001)
        '    frmCR.Report = Rpt_BSP00001
        'Else
        '    Rpt_BSP00002 = New BSP00002Rpt
        '    Rpt_BSP00002.Database.SetDataSource(rs_BSP00001)
        '    frmCR.Report = Rpt_BSP00002
        'End If

        'frmCR.Show()

        Dim objRpt As New SHR00010RptE
        objRpt.SetDataSource(rs_SHR00010.Tables("RESULT"))

        Dim frm As New frmReport
        frm.CrystalReportViewer.ReportSource = objRpt
        frm.Show()



    End Sub

    Private Sub SHR00010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
    End Sub

    Private Sub txtdocno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdocno.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdShow_Click(sender, e)
        End If
    End Sub


End Class