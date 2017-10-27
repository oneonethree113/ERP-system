Public Class INR00015

    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As Dataset



    Private Sub cboVenFm_LostFocus()
        'Call ValidateCombo(cboVenFm)
        If ValidateCombo(cboVenFm) = True Then
            cboVenTo.Text = cboVenFm.Text
        End If
    End Sub

    Private Sub cboVenTo_GotFocus()
        Me.cboVenTo.selectionStart = 0
        Me.cboVenTo.SelectionLength = Len(Me.cboVenTo.Text)
    End Sub

    Private Sub cboVenTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenTo, KeyCode)
    End Sub
    Private Sub cboVenTo_LostFocus()
        Call ValidateCombo(cboVenTo)
    End Sub


    Private Sub Form_Load()

        Cursor = Cursors.WaitCursor
    


        Cursor = Cursors.WaitCursor


        gspStr = "sp_list_VNBASINF  '' "
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboVen()
        End If



        Cursor = Cursors.Default
    End Sub

    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then

            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
            Next

        End If
    End Sub

    Private Sub INR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cboVenFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenFm.LostFocus
        If ValidateCombo(cboVenFm) = True Then
            cboVenTo.Text = cboVenFm.Text
        End If

    End Sub


    Private Sub cboVenTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub








End Class
