Public Class ERP00002

    Private Sub ERP00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsrnam.Text = LCase(gsUsrID)
        txtUsrnam.Enabled = False
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim rs_SYUSRPRF As DataSet
        Dim rs_Version As DataSet

        gspStr = "sp_select_SYUSRPRF_1 'UCPP','" & txtUsrnam.Text.Trim & "'"
        rs_SYUSRPRF = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rs_SYUSRPRF.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("User ID not found, please try again", MsgBoxStyle.Information, "")
            Exit Sub
        Else
            ' Check Password
            Dim lenpwd As Integer
            Dim Y, i As Integer
            Dim x As String
            Dim password As String

            Dim pwd As String
            pwd = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yup_paswrd")

            password = ""
            lenpwd = Len(pwd)
            Y = 1

            For i = 0 To lenpwd - 1
                If Y <= lenpwd Then
                    x = Mid(pwd, Y, 1)
                    password = password + Chr(Mid(pwd, Y + 1, x))
                    Y = Y + x + 1
                End If
            Next

            If password <> txtPaswrd.Text Then
                MsgBox("User ID or Password is incorrect, please try again")
                txtPaswrd.Focus()
                txtPaswrd.SelectAll()
                Exit Sub
            End If

            ' Check Version Number
            gspStr = "sp_select_LOGIN 'UCPP','1'"
            rs_Version = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_Version, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("ERP Version Validation Failed." & Environment.NewLine & "Please contact your local administrator", MsgBoxStyle.Information, "")
                Exit Sub
            End If

            Dim tmpERPVer As String
            tmpERPVer = rs_Version.Tables("RESULT").Rows(0).Item("ERP_VERSION")
            If tmpERPVer <> gsERPVer Then
                MsgBox("Your current ERP version was outdated, please upgrade!")
                Me.Owner.Close()
                ERP00000.Close()
                Me.Close()
            End If
        End If

        Close()
    End Sub

    Private Sub txtPaswrd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaswrd.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cmdOK.PerformClick()
        End If
    End Sub
End Class