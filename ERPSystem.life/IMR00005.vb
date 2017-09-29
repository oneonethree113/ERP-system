Public Class IMR00005

    Dim rs_IMR00005 As DataSet

    Private Sub IMR00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        ' Initialize Date Time Picker
        dtpFromTrand.Value = Date.Today
        dtpFromTrand.CustomFormat = "MM/dd/yy"
        dtpToTrand.Value = Date.Today
        dtpToTrand.CustomFormat = "MM/dd/yy"

        txtFromItmno.MaxLength = 20
        txtToItmno.MaxLength = 20
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If txtFromItmno.Text > txtToItmno.Text Then
            MsgBox("Invalid Item No. Range: From Item No. > To Item No.", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            txtFromItmno.Focus()
            Exit Sub
        ElseIf dtpFromTrand.Value > dtpToTrand.Value Then
            MsgBox("Invalid Date Range: From Date > To Date", MsgBoxStyle.Exclamation, "Invalid Input Parameters")
            dtpFromTrand.Focus()
            Exit Sub
        End If

        ' Format Date
        Dim fromdate As String
        Dim frommth As String
        Dim fromday As String
        frommth = "0" & dtpFromTrand.Value.Month.ToString
        fromday = "0" & dtpFromTrand.Value.Day.ToString
        fromdate = dtpFromTrand.Value.Year.ToString & "-" & frommth.Substring(frommth.Length - 2, 2) & "-" & fromday.Substring(fromday.Length - 2, 2)
        Dim todate As String
        Dim tomth As String
        Dim today As String
        tomth = "0" & dtpToTrand.Value.Month.ToString
        today = "0" & dtpToTrand.Value.Day.ToString
        todate = dtpToTrand.Value.Year.ToString & "-" & tomth.Substring(tomth.Length - 2, 2) & "-" & today.Substring(today.Length - 2, 2)

        gspStr = "sp_list_IMR00005 'UCPP','" & Trim(txtFromItmno.Text) & "','" & Trim(txtToItmno.Text) & "','" & fromdate & "','" & todate & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00005, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00005 sp_list_IMR00005 : " & rtnStr)
            Exit Sub
        End If

        If rs_IMR00005.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            rs_IMR00005.Tables("RESULT").Columns(14).ColumnName = "@fromvenno "
            rs_IMR00005.Tables("RESULT").Columns(15).ColumnName = "@tovenno"
            rs_IMR00005.Tables("RESULT").Columns(16).ColumnName = "@fromcredat"
            rs_IMR00005.Tables("RESULT").Columns(17).ColumnName = "@tocredat"


            Dim objRpt As New IMR00005Rpt
            objRpt.SetDataSource(rs_IMR00005.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        End If
    End Sub
End Class