Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class MPR00001

    Public rs_MPR00001 As DataSet
    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim AscDesc As String

        Dim S As String
        Dim rs As DataSet
        Dim ReportName(0) As String
        Dim ReportRS(0) As DataSet
        ReDim Preserve ReportName(0)
        ReDim Preserve ReportRS(0)

        Dim tmpRecCount As Long
        Dim tmpcatlvl4 As String
        Dim j As Long

        Dim i As Integer
        Dim txtRecSts As String

        If Me.txtMPONoFm.Text <> "" And Me.txtMPONoTo.Text = "" Then
            Me.txtMPONoTo.Text = Me.txtMPONoFm.Text
        End If


        If dtptoTranDat.Value < dtpfromTrandat.Value Then
            'temp
            MsgBox("Invalid Input! (Start Date <=  End  Date)!")
            dtpfromTrandat.Focus()
            Exit Sub
        End If

        If txtMPONoFm.Text > txtMPONoTo.Text Then
            MsgBox("Invalid Input ! (From PO No. < To PO No.) ")
            txtMPONoFm.Focus()
            Exit Sub
        End If



        '***************************************************
        '*** Get System Category record  *******************
        '***************************************************


        '    S = "㊣MPR00001','S','" + Trim(txtMPONoFm.Text) + "','" + Trim(txtMPONoTo.Text) + "','" + _
        '        str(dtpfromTrandat.value) + "','" + str(dtptoTranDat.value) + "','X"

        Me.Cursor = Cursors.WaitCursor

        gspStr = "sp_select_MPR00001 '','" & Trim(txtMPONoFm.Text) & "','" & Trim(txtMPONoTo.Text) & "','" & _
            (dtpfromTrandat.Value) & "','" & (dtptoTranDat.Value) & "','X" & "'"
        '        gspStr = "sp_select_MPR00001 ','" & Trim(txtMPONoFm.Text) & "','" & Trim(txtMPONoTo.Text) & "','" & _
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
            Dim objRpt As New mpr00001rpt
            objRpt.SetDataSource(rs.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()

        End If



    End Sub

    Private Sub cmdShow_Click()
    End Sub








    Private Sub txtMPONoFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPONoFm.GotFocus
        Me.txtMPONoFm.SelectionStart = 0
        Me.txtMPONoFm.SelectionLength = Len(Me.txtMPONoFm.Text)
    End Sub

    Private Sub txtMPONoFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPONoFm.LostFocus
        txtMPONoFm.Text = UCase(txtMPONoFm.Text)
        Me.txtMPONoTo.Text = Me.txtMPONoFm.Text
    End Sub

    Private Sub txtMPONoTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPONoTo.GotFocus
        Me.txtMPONoTo.SelectionStart = 0
        Me.txtMPONoTo.SelectionLength = Len(Me.txtMPONoTo.Text)
    End Sub

    Private Sub txtMPONoTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPONoTo.LostFocus
        txtMPONoTo.Text = UCase(txtMPONoTo.Text)
    End Sub



    Private Sub MPR00001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Call MapEnterToTab(Me, Asc(e.KeyCode))
    End Sub

    Private Sub MPR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor


        '*** Folder 1   **********

        txtMPONoFm.MaxLength = 20
        txtMPONoTo.MaxLength = 20


        dtpfromTrandat.Value = Format(Date.Today, "MM/dd/yyyy").ToString
        dtptoTranDat.Value = Format(Date.Today, "MM/dd/yyyy").ToString

        Call Formstartup(Me.Name)   'Set the form Sartup position
        Me.KeyPreview = True
        Me.Cursor = Cursors.Default

    End Sub

    Public Function MapEnterToTab(ByVal f As Form, ByVal KeyCode As Integer) As String
        If KeyCode = 13 Then
            My.Computer.Keyboard.SendKeys(vbTab)
        End If

    End Function



    Private Sub txtMPONoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMPONoFm.TextChanged

    End Sub



    Private Sub txtMPONoTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMPONoTo.TextChanged

    End Sub
End Class




