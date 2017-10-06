Imports System.Data.SqlClient

Public Class SHR00002

    Const strModule As String = "SC"

    Private Sub SHR00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        txtResult.Text = ""
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
            optStr = "Y"
        ElseIf optRel.Checked = False And optUnr.Checked = False Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Missing Release/Unrelease Action")
            Exit Sub
        Else
            optStr = "N"
        End If

        gspStr = "sp_select_SCORDHDRR '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SHR00002 #001 sp_select_SCORDHDRR : " & rtnStr)
            Exit Sub
        End If

        If rs_Result.Tables("RESULT").Rows.Count > 0 Then
            temp = ""
            For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
                temp = temp & rs_Result.Tables("RESULT").Rows(i)("soh_ordno") & " " & rs_Result.Tables("RESULT").Rows(i)("soh_ordsts") & Environment.NewLine
            Next
            txtResult.Text = temp
            temp = ""

            Me.Cursor = Windows.Forms.Cursors.Default
            If optStr = "Y" Then
                MsgBox("All SC No. to be released must be active", MsgBoxStyle.Exclamation, "Warning")
            Else
                MsgBox("All SC No. to be unreleased must be released", MsgBoxStyle.Exclamation, "Warning")
            End If
            Exit Sub
        Else
            ' Added by Joe on 2010514
            gspStr = "sp_select_SYUSRRIGHT_Rel_Check '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & _
                     txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "','" & strModule & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_Right, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading SHR00002 #002 sp_select_SYUSRRIGHT_Rel_Check : " & rtnStr)
                Exit Sub
            Else
                If Not rs_Right.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("All SC No. should have access rights", MsgBoxStyle.Exclamation, "Warning")
                    Exit Sub
                End If
            End If
        End If

        gspStr = "sp_select_SCM00002 '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & _
                 "','" & optStr & "','" & gsUsrID & "'"

        t = "sp_select_SHR00002 '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','0'"
        r = ", PO is Generated "

        If gspStr <> "" Then  '*** if there is something to do with s ...
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then  '*** An error has occured
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading SHR00002 #003 sp_select_SCM00002 : " & rtnStr)
                Exit Sub
            Else
                If rs.Tables.Count > 0 Then
                    If rs.Tables("RESULT").Rows.Count > 0 Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Operation Fail - " & rs.Tables("RESULT").Rows(0)(0), MsgBoxStyle.Information, "Information")
                        Exit Sub
                    End If
                End If
                If t <> "" Then  '*** if there is something to do with s ...
                    gspStr = t
                    rs_Result = Nothing
                    rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading SHR00002 #004 sp_select_SHR00002 : " & rtnStr)
                        Exit Sub
                    End If

                    For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
                        temp = temp & _
                               "Pri Cust: " & rs_Result.Tables("RESULT").Rows(i)(0).ToString.PadRight(6) & _
                               "Sec Cust: " & rs_Result.Tables("RESULT").Rows(i)(1).ToString.PadRight(6) & _
                               "SC No.: " & rs_Result.Tables("RESULT").Rows(i)(2).ToString.PadRight(14) & _
                               "PO No.: " & rs_Result.Tables("RESULT").Rows(i)(3).ToString.PadRight(14) & _
                               "CV: " & rs_Result.Tables("RESULT").Rows(i)(4).ToString.PadRight(10) & _
                               "PV: " & rs_Result.Tables("RESULT").Rows(i)(5).ToString & _
                               Environment.NewLine
                    Next
                End If
                txtResult.Text = temp
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Operation Successful " & r)
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub txtFromFactory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromFactory.TextChanged
        txtToFactory.Text = txtFromFactory.Text
    End Sub
End Class