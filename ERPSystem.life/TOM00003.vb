Imports System.Data.SqlClient

Public Class TOM00003

    Const strModule As String = "SC"
    Public public_cboCoCde_Text As String

    Private Sub TOM00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tmp_cocde As String

        Formstartup(Me.Name)
        tmp_cocde = cboCoCde.Text.Trim
        tmp_cocde = public_cboCoCde_Text

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)


        If Trim(tmp_cocde) <> "" Then

            cboCoCde.Text = tmp_cocde
        End If

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
            optStr = "REL"
        ElseIf optRel.Checked = False And optUnr.Checked = False Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Missing Release/Unrelease Action")
            Exit Sub
        Else
            optStr = "OPE"
        End If

        gspStr = "sp_update_TOORDHDR_TOM00003 '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading TOM00003 sp_update_TOORDHDR_TOM00003 : " & rtnStr)
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
                txtResult.Text = "No Tentative Order has been Release/Unrelease"
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

    Public Sub callbyTOM01(ByVal TONo As String, ByVal Cocde As String,ByVal relsts As String)
        txtFromFactory.Text = TONo 'TOM00001.txtTONo.Text.Trim
        txtFromFactory.Enabled = False
        txtToFactory.Text = TONo 'TOM00001.txtTONo.Text.Trim
        txtToFactory.Enabled = False
        public_cboCoCde_Text = Cocde 'TOM00001.cboCoCde.Text.Trim
        If relsts = "REL - Released" Then
            optUnr.Checked = True
        Else
            optRel.Checked = True
        End If
        grpDocNo.Enabled = False
        cboCoCde.Enabled = False
        ShowDialog()
    End Sub
End Class
