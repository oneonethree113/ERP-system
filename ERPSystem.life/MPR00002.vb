Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class MPR00002

    Public rs_MPR00002 As DataSet
    Private Sub cboCoCde_Click()
        'txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Enq_right_local = Enq_right
        'Del_right_local = Del_right
        'tempz

    End Sub

    Private Sub Form_Load()

        Me.Icon = ERP00000.Icon

        'AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        'Enq_right_local = Enq_right
        'Del_right_local = Del_right

        'Call FillCompCombo(gsUsrID, Me)         'Get availble Company
        'Call GetDefaultCompany(Me)

        Call AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001 Change by Lewis on 2 Jul 2003






        '        Call Formstartup(Me.Name)
        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        '        If gsConnStr = "" Then
        '            gsConnStr = getConnectionString()
        '        End If

        '        Cursor = Cursors.Default







    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '        Dim S As String
        '        Dim rs() As DataSet
        Dim ReportName(0) As String
        Dim ReportRS(0) As DataSet
        'tempzz

        '-- * Check have any entry
        If txtFromQuotNo.Text = "" Or txtToQuotNo.Text = "" Then
            MsgBox("Manufacturing Purchase Order empty !")
            Exit Sub
        End If


        '-- * Past parameter to Revised Option
        Dim Rvs As String
        If chnRvsYes.Checked = True Then
            Rvs = "Y"
        Else
            Rvs = "N"
        End If


        '----------------------------------------------------------
        Me.Cursor = Cursors.WaitCursor

        gspStr = "sp_select_MPR00002 '','" & Trim(txtFromQuotNo.Text) & "','" & Trim(txtToQuotNo.Text) & "','" & Rvs & "'"
        '        gspStr = "sp_select_MPR00002 ','" & Trim(txtFromQuotNo .Text) & "','" & Trim(txtMPONoTo.Text) & "','" & _
        '           Str(dtpfromTrandat.Value) & "','" & Str(dtptoTranDat.Value) & "','X" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Sub
        End If
        If rs.Tables("result").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("Record not found!")
            Exit Sub
        Else
            Dim objRpt As New mpr00002rpt
            objRpt.SetDataSource(rs.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()

        End If
        Cursor = Cursors.Default


        'S = "㊣MPR00002※S※" & txtFromQuotNo & "※" & txtToQuotNo & "※" & Rvs
        'Screen.MousePointer = vbHourglass


        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        'Cursor = Cursors.Default

        'If rs(0)(0) <> "0" Then  '*** An error has occured
        '    MsgBox(rs(0)(0))
        'Else
        '    rs_MPR00002 = rs(1)
        '    If rs_MPR00002.recordCount = 0 Then
        '        MsgBox("No Record Found!")
        '        Exit Sub
        '    Else
        '        'Set Rpt_MPR00002 = New MPR00002Rpt
        '        'Rpt_MPR00002.Database.SetDataSource rs_MPR00002
        '        'Set frmCR.Report = Rpt_MPR00002
        '        'frmCR.Show
        '        ReportName(0) = "MPR00002.rpt"
        '        ReportRS(0) = rs_MPR00002
        '        frmReport.Show()
        '    End If
        'End If







        '----------------------------------------------------------
    End Sub

    Private Sub lblRptName_Click()

    End Sub

    Private Sub txtFromQuotNo_Change()
    End Sub


    Private Sub txtFromQuotNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromQuotNo.TextChanged
        txtToQuotNo.Text = txtFromQuotNo.Text

    End Sub
End Class
