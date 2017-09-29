Public Class PGM00003
    Public companycode As String
    Dim rs_PKESHDR As DataSet
    Private Sub PGM00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        txtResult.Text = ""


        If companycode <> "" Then
            cboCoCde.Text = companycode
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
        Dim currentString As String
        Dim checkpoint As Boolean = True
        If optStr = "REL" Then
            gspStr = "sp_select_PKESHDR_PGM0003 '" & cboCoCde.Text & "','" & txtFrom.Text & "','" & txtTo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading PGM00003 sp_select_PKESHDR_PGM0003 : " & rtnStr)
                Exit Sub
            End If

            For i As Integer = 0 To rs_PKESHDR.Tables("RESULT").Rows.Count - 1
                If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_price") = 0 And rs_PKESHDR.Tables("RESULT").Rows(i).Item("est_count") > 0 Then
                    checkpoint = False

                    If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_reqno") <> currentString Then
                        temp = temp & "Please Entry Estimated Cost for Request " & rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_reqno") & "(" & rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_itemno") & ") - "
                    End If
                    currentString = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_reqno")
                End If
            Next
            If checkpoint = False Then
                temp = Replace(temp, " - ", Environment.NewLine)
                'temp = Replace(temp, Environment.NewLine, "", 1, 1)
                txtResult.Text = temp
                MsgBox(temp)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            End If

        End If

        gspStr = "sp_update_PKREQHDR_PGM00003 '" & cboCoCde.Text & "','" & txtFrom.Text & "','" & txtTo.Text & "','" & optStr & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading PGM00003 sp_update_PKREQHDR_PGM00003 : " & rtnStr)
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
                txtResult.Text = "No Packaging Request has been Release/Unrelease"
            End If

            'MsgBox("Operation Successful")
        End If




        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class