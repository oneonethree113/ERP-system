Imports CrystalDecisions.Shared

Public Class POR00003


    Public rs_POR00003 As New DataSet

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Public init_PONo As String = ""
    Public init_cocde As String = ""


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


        Dim Revised As String
        If rdbRevisedY.Checked = True Then
            Revised = "Y"
        Else
            Revised = "N"
        End If

        If txtFm.Text = "" Or txtTo.Text = "" Then
            MsgBox("BOM No empty !")
            Exit Sub
        End If


        Dim S As String
        Dim rs() As ADOR.Recordset

        gspStr = "sp_select_POR00003 '" & gsCompany & "','" & txtFm.Text.Trim & "','" & txtTo.Text.Trim & "','" & Sup0 & "','" & Revised & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_POR00003, rtnStr)

        Dim rs_POR00003A As New DataSet
        gspStr = "sp_select_POR00003A '" & gsCompany & "','" & txtFm.Text.Trim & "','" & txtTo.Text.Trim & "','" & Sup0 & "','" & Revised & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_POR00003A, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00003 cmdShow_Click sp_select_POR00003A : " & rtnStr)
            Exit Sub
        Else
            'If rs_POR00003.Tables("RESULT").Rows.Count <> rs_POR00003A.Tables("RESULT").Rows.Count Then
            '    ''''''''''''''''
            '    MsgBox("Not all PO in CLO or REL status with Final Approval")
            '    Exit Sub
            'Else
            If rs_POR00003.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No record found !")
                Exit Sub
            ElseIf cboReportFormat.SelectedIndex = 0 Then

                Dim objRpt As New POR00003Rpt
                objRpt.SetDataSource(rs_POR00003.Tables("RESULT"))
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            ElseIf cboReportFormat.SelectedIndex = 1 Then
                Dim strDir As String
                strDir = "C:\ERP PDF"
                Dim dir As New IO.DirectoryInfo(strDir)
                If dir.Exists = False Then
                    MsgBox("The Following Directory Does not exist: " & strDir)
                    Exit Sub
                End If

                Try
                    gspStr = "sp_select_POR00003_PDF '" & gsCompany & "','" & txtFm.Text.Trim & "','" & txtTo.Text.Trim & "','" & Sup0 & "','" & Revised & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Dim rs_POR00003_purord As New DataSet
                    rtnLong = execute_SQLStatement(gspStr, rs_POR00003_purord, rtnStr)
                    For i As Integer = 0 To rs_POR00003_purord.Tables("RESULT").Rows.Count - 1

                        gspStr = "sp_select_POR00003_genPDF '" & gsCompany & "','" & rs_POR00003_purord.Tables("RESULT").Rows(i)("bompo") & "','" & Sup0 & "','" & Revised & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_POR00003, rtnStr)
                        Dim objRpt As New POR00003Rpt
                        objRpt.SetDataSource(rs_POR00003.Tables("RESULT"))

                        objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, strDir & "\" & rs_POR00003_purord.Tables("RESULT").Rows(i)("bompo") & ".pdf")

                    Next

                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Total " & rs_POR00003_purord.Tables("RESULT").Rows.Count & " BomPO(s) has/have been converted successfully.")
                Catch ex As Exception
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("An Error has occurred during the data extraction process :" & ex.ToString, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try
            End If
        End If

    End Sub

    Private Sub POR00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        cboReportFormat.Items.Add("Standard Format")
        cboReportFormat.Items.Add("PDF Format")
        cboReportFormat.SelectedIndex = 0

        If init_cocde <> "" Then
            cboCoCde.Text = init_cocde
            cboCoCde.Enabled = False
        End If
        If init_PONo <> "" Then
            txtFm.Text = init_PONo
            txtFm.ReadOnly = True
            txtTo.Text = init_PONo
            txtTo.ReadOnly = True
        End If

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