Public Class SYM00029

    Dim rs_SYUM As DataSet

    Private Sub SYM00029_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)

        setStatus("INIT")
        cmdFind.PerformClick()

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        gspStr = "sp_select_SYUM '','" & LCase(gsUsrID) & "'"
        rs_SYUM = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_SYUM, rtnStr)
        If rtnLong <> RC_SUCCESS Then

        Else
            setStatus("LOAD")
            display_SYUM()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        setStatus("INIT")
        cmdFind.PerformClick()
    End Sub

    Private Sub display_SYUM()
        dgSYUM.DataSource = rs_SYUM.Tables("RESULT").DefaultView
        For i As Integer = 0 To dgSYUM.Columns.Count - 1
            dgSYUM.Columns(i).ReadOnly = True

            Select Case dgSYUM.Columns(i).Name.ToString
                Case "yum_msehi"
                    dgSYUM.Columns(i).HeaderText = "SAP UM"
                    dgSYUM.Columns(i).Width = 80
                Case "yum_msehte"
                    dgSYUM.Columns(i).HeaderText = "ERP UM"
                    dgSYUM.Columns(i).Width = 80
                Case "yum_zaehl"
                    dgSYUM.Columns(i).HeaderText = "Conv. Factor"
                    dgSYUM.Columns(i).Width = 80
                Case "yum_msehle"
                    dgSYUM.Columns(i).HeaderText = "Description"
                    dgSYUM.Columns(i).Width = 200
                Case Else
                    dgSYUM.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub setStatus(ByVal mode As String)
        Select Case UCase(mode)
            Case "INIT"
                cmdAdd.Enabled = False
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdCopy.Enabled = False
                cmdFind.Enabled = True
                cmdClear.Enabled = False
                cmdSearch.Enabled = False
                cmdInsRow.Enabled = False
                cmdDelRow.Enabled = False
                cmdFirst.Enabled = False
                cmdPrevious.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
                cmdExit.Enabled = True

                rs_SYUM = Nothing
            Case Else
                cmdAdd.Enabled = False
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdCopy.Enabled = False
                cmdFind.Enabled = False
                cmdClear.Enabled = True
                cmdSearch.Enabled = False
                cmdInsRow.Enabled = False
                cmdDelRow.Enabled = False
                cmdFirst.Enabled = False
                cmdPrevious.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
                cmdExit.Enabled = True
        End Select
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Close()
    End Sub
End Class