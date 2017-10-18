Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class MPR00002

    Public rs_MPR00002 As DataSet
    Private Sub cboCoCde_Click()
      
    End Sub

    Private Sub Form_Load()


       

        Call AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001 Change by Lewis on 2 Jul 2003

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

    End Sub

    Private Sub lblRptName_Click()

    End Sub

    Private Sub txtFromQuotNo_Change()
    End Sub


    Private Sub txtFromQuotNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromQuotNo.TextChanged
        txtToQuotNo.Text = txtFromQuotNo.Text

    End Sub

    Private Sub MPR00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Formstartup(Me.Name)   'Set the form Sartup position
    End Sub

    Public Sub callByMPM01(ByVal MPOno As String)
        txtFromQuotNo.Text = MPOno
        txtToQuotNo.Text = MPOno
        txtFromQuotNo.Enabled = False
        txtToQuotNo.Enabled = False
        Me.ShowDialog()
    End Sub
End Class
