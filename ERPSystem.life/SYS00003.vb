Public Class SYS00003

    Inherits System.Windows.Forms.Form
    Dim rs_syusrfun As New DataSet
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYS00003_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            gspStr = "sp_list_SYUSRFUN '" & gsCompany & "','" & gsUsrID & "','" & gsCompanyGroup & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syusrfun, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00003 sp_list_SYUSRFUN : " & rtnStr)
            Else
                Call displayGrid()
                Call setStatus("Init")
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_syusrfun.Tables("RESULT").DefaultView

        With DataGrid
            .DataSource = Nothing
            .DataSource = dv
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 2
                        .Columns(i).Width = 200
                        .Columns(i).HeaderText = "User Function"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 400
                        .Columns(i).HeaderText = "Function Description"
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "(Short Code)"
                        .Columns(i).ReadOnly = True
                        .Columns(i).DisplayIndex = 3
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "yuf_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yuf_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yuf_upddat"), "MM/dd/yyyy") & " " & drv.Item("yuf_updusr")

            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = False
            mmdSearch.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            Call SetStatusBar(mode)
        End If
    End Sub

    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "InsRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Row"
        ElseIf mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf mode = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If

    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()

    End Sub
End Class