Public Class SYM00029

    Dim rs_SYUM As DataSet

    Private Sub SYM00029_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)

        setStatus("INIT")
        mmdFind.PerformClick()

    End Sub
    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        gspStr = "sp_select_SYUM '','" & LCase(gsUsrID) & "'"
        rs_SYUM = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_SYUM, rtnStr)
        If rtnLong <> RC_SUCCESS Then

        Else
            setStatus("LOAD")
            display_SYUM()
        End If
    End Sub

 
    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        setStatus("INIT")
        mmdFind.PerformClick()
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
                    dgSYUM.Columns(i).Width = 120
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
               mmdAdd.Enabled = False
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                mmdCopy.Enabled = False
                mmdFind.Enabled = True
                mmdClear.Enabled = False
                mmdSearch.Enabled = False
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                mmdPrint.Enabled = False
                mmdAttach.Enabled = False
                mmdFunction.Enabled = False
                mmdLink.Enabled = False
                mmdExit.Enabled = True



                rs_SYUM = Nothing
            Case Else
 

                mmdAdd.Enabled = False
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                mmdCopy.Enabled = False
                mmdFind.Enabled = False
                mmdClear.Enabled = False
                mmdSearch.Enabled = False
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                mmdExit.Enabled = True


        End Select
    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        Close()
    End Sub


End Class