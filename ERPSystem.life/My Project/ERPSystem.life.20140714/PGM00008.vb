﻿Public Class PGM00008
    Public company As String
    Private Sub PGM00008_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        txtResult.Text = ""

        If company <> "" Then
            cboCoCde.Text = company
        End If


    End Sub
    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub txtFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom.TextChanged
        txtTo.Text = txtFrom.Text
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        Dim rs_Result As DataSet
        Dim rs_Right As DataSet

        Dim optStr As String
        Dim temp As String
        Dim t As String
        Dim r As String

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
        '------------------------------------------

        txtResult.Text = ""
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If optRel.Checked = True Then
            optStr = "REL"
        ElseIf optRel.Checked = False And optUnr.Checked = False Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Missing Release/Unrelease Action")
            Exit Sub
        Else
            optStr = "OPE"
        End If

        gspStr = "sp_update_PKREQHDR_PGM00008 '" & cboCoCde.Text & "','" & txtFrom.Text & "','" & txtTo.Text & "','" & optStr & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading PGM00008 sp_update_PKREQHDR_PGM00008 : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1

                temp = temp & rs_Result.Tables("RESULT").Rows(i).Item(0)

            Next

            If temp <> "" Then
                temp = Replace(temp, " - ", Environment.NewLine)
                temp = Replace(temp, Environment.NewLine, "", 1, 1)
                txtResult.Text = temp
            Else
                txtResult.Text = "No Packaging Order has been Release/Unrelease"
            End If

            'MsgBox("Operation Successful")
        End If




        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class