Public Class SCR00003

    Const strModule As String = "SC"

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, "SCR00003")
    End Sub

    Private Sub SCR00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)
        Formstartup(Me.Name)

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If Trim(Me.txtSCFm.Text) = "" Then
            MsgBox("Please Input SC From!")
            Me.txtSCFm.Focus()
            Exit Sub
        End If
        If Trim(Me.txtSCTo.Text) = "" Then
            MsgBox("Please Input SC To!")
            Me.txtSCTo.Focus()
            Exit Sub
        End If

        If Trim(Me.txtSCFm.Text) > Trim(Me.txtSCTo.Text) Then
            MsgBox("SC : From > To")
            Me.txtSCFm.Focus()
            Exit Sub
        End If

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
        '------------------------------------------

        SCR00003_showSC_BOMPO(Trim(Me.txtSCFm.Text), Trim(Me.txtSCTo.Text))
    End Sub

    Public Function SCR00003_showSC_BOMPO(ByVal scFrom As String, ByVal ScTo As String) As String
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'x                                                                              x
        'x  This Function is to display BOM PO of Canceled SC                           x
        'x                                                                              x
        'x  To Call This Function : -                                                   x
        'x                                                                              x
        'x    Screen.MousePointer = vbHourglass                                         x
        'x    gsCompany = Trim(cboCoCde.Text)       'Update Company Code                x
        'x    Call Update_gs_Value(gsCompany)                                           x
        'x    If SCR00003.SCR00003_showSC_BOMPO(scFrom, scTo) = "No Record Found" Then  x
        'x          'Add Your Code Here to Handle No BOM PO Found For the SC given      x
        'x    End If                                                                    x
        'x    Screen.MousePointer = vbDefault                                           x
        'x                                                                              x
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        SCR00003_showSC_BOMPO = ""

        Dim rs_SCR00003 As New DataSet
        Dim rs_check As New DataSet

        gspStr = "sp_select_SCR00003 '" & cboCoCde.Text & "','" & scFrom & "','" & ScTo & "','" & gsUsrID & "','" & gsUsrID & "','" & strModule & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SCR00003, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00001 #001 sp_select_SCR00003 : " & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_SCORDHDR '" & cboCoCde.Text & "','" & Trim(scFrom) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00001 #002 sp_select_SCORDHDR : " & rtnStr)
            Exit Function
        End If

        If rs_SCR00003.Tables("RESULT").Rows.Count = 0 Then
            If rs_check.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No Record Found")
                Exit Function
            Else
                If rs_check.Tables("RESULT").Rows(0)("soh_ordsts").ToString <> "CAN" Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No Record Found")
                    Exit Function
                Else
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("You have no access rights to print!")
                    Exit Function
                End If
            End If
        End If

        Dim objRpt As New SCR00003Rpt
        objRpt.SetDataSource(rs_SCR00003.Tables("RESULT"))

        Dim frmReportView As New frmReport
        frmReportView.CrystalReportViewer.ReportSource = objRpt
        frmReportView.Show()

        Me.Cursor = Windows.Forms.Cursors.Default

    End Function

    Private Sub txtSC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSCFm.GotFocus, txtSCTo.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub txtSCFm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSCFm.TextChanged
        txtSCTo.Text = txtSCFm.Text
    End Sub
End Class