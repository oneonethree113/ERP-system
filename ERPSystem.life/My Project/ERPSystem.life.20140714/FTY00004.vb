Public Class FTY00004
    Dim rs_FYPDOHIS As DataSet

    Dim timer As Timer

    Private Sub FTY00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)

        FillCompCombo(LCase(gsUsrID), cboCoCde)
        cboCoCde.Items.Add("")
        cboCoCde.Sorted = True

        setStatus("INIT")

        timer = New Timer()
        timer.Interval = 50
        timer.Enabled = True
        AddHandler timer.Tick, AddressOf start
    End Sub

    Private Sub start()
        timer.Enabled = False
        txtBatNoFm.Focus()
    End Sub

    Private Sub setStatus(ByVal mode As String)
        Select Case UCase(mode)
            Case "INIT"
                cmdSearch.Enabled = True
                cmdClear.Enabled = True
                cmdExit.Enabled = True

                cboCoCde.Enabled = True
                txtBatNoFm.Enabled = True
                txtBatNoTo.Enabled = True
                txtJobOrdFm.Enabled = True
                txtJobOrdTo.Enabled = True
                txtGenDatFm.Enabled = True
                txtGenDatTo.Enabled = True

                dgResults.Enabled = False
                dgResults.DataSource = Nothing

                cboCoCde.SelectedIndex = -1
                txtBatNoFm.Text = ""
                txtBatNoTo.Text = ""
                txtJobOrdFm.Text = ""
                txtJobOrdTo.Text = ""
                txtGenDatFm.Text = "  /  /"
                txtGenDatTo.Text = "  /  /"

                txtBatNoFm.Focus()
            Case "BROWSE"
                cmdSearch.Enabled = False
                cmdClear.Enabled = True
                cmdExit.Enabled = True

                cboCoCde.Enabled = False
                txtBatNoFm.Enabled = False
                txtBatNoTo.Enabled = False
                txtJobOrdFm.Enabled = False
                txtJobOrdTo.Enabled = False
                txtGenDatFm.Enabled = False
                txtGenDatTo.Enabled = False

                dgResults.Enabled = True
        End Select
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        If txtBatNoFm.Text = "" And txtBatNoTo.Text <> "" Then
            MsgBox("Batch No. Range incomplete", MsgBoxStyle.Information, "FTY00004 - Search")
            txtBatNoFm.Focus()
            Exit Sub
        ElseIf txtBatNoFm.Text <> "" And txtBatNoTo.Text = "" Then
            MsgBox("Batch No. Range incomplete", MsgBoxStyle.Information, "FTY00004 - Search")
            txtBatNoTo.Focus()
            Exit Sub
        End If

        If txtJobOrdFm.Text = "" And txtJobOrdTo.Text <> "" Then
            MsgBox("Job Order Range incomplete", MsgBoxStyle.Information, "FTY00004 - Search")
            txtJobOrdFm.Focus()
            Exit Sub
        ElseIf txtJobOrdFm.Text <> "" And txtJobOrdTo.Text = "" Then
            MsgBox("Job Order Range incomplete", MsgBoxStyle.Information, "FTY00004 - Search")
            txtJobOrdTo.Focus()
            Exit Sub
        End If

        If txtGenDatFm.Text = "  /  /" And txtGenDatTo.Text <> "  /  /" Then
            MsgBox("Generation Date Range incomplete", MsgBoxStyle.Information, "FTY00004 - Search")
            txtGenDatFm.Focus()
            Exit Sub
        ElseIf txtGenDatFm.Text <> "  /  /" And txtGenDatTo.Text = "  /  /" Then
            MsgBox("Generation Date Range incomplete", MsgBoxStyle.Information, "FTY00004 - Search")
            txtGenDatTo.Focus()
            Exit Sub
        End If

        gspStr = "sp_select_FYPDOHIS '" & cboCoCde.Text & "','" & Replace(txtBatNoFm.Text, "'", "''") & "','" & _
                 Replace(txtBatNoTo.Text, "'", "''") & "','" & Replace(txtJobOrdFm.Text, "'", "''") & "','" & _
                 Replace(txtJobOrdTo.Text, "'", "''") & "','" & IIf(txtGenDatFm.Text = "  /  /", "", txtGenDatFm.Text) & _
                 "','" & IIf(txtGenDatTo.Text = "  /  /", "", txtGenDatTo.Text) & "','" & LCase(gsUsrID) & "'"
        rs_FYPDOHIS = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_FYPDOHIS, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00004 #001 sp_select_FYPDOHIS : " & rtnStr)
            Exit Sub
        Else
            If rs_FYPDOHIS.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "FTY00004 - Result")
                Exit Sub
            End If

            setStatus("BROWSE")
            display_dgResults()
        End If
    End Sub

    Private Sub display_dgResults()
        dgResults.DataSource = rs_FYPDOHIS.Tables("RESULT").DefaultView

        With dgResults
            For i As Integer = 0 To rs_FYPDOHIS.Tables("RESULT").Columns.Count - 1
                Select Case rs_FYPDOHIS.Tables("RESULT").Columns(i).ColumnName
                    Case "fph_cocde"
                        .Columns(i).HeaderText = "Company"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case "fph_batno"
                        .Columns(i).HeaderText = "Batch No."
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case "fph_jobord"
                        .Columns(i).HeaderText = "Job Order No."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case "fph_gendat"
                        .Columns(i).HeaderText = "Created Date"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case "fph_filnam"
                        .Columns(i).HeaderText = "Filename"
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                End Select
            Next
        End With
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        setStatus("INIT")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub check_date(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtGenDatFm.Validating, txtGenDatTo.Validating
        If sender.Text = "  /  /" Or cmdClear.Focused Or cmdExit.Focused Then
            Return
        Else
            If sender.Text.Length <> 10 Then
                MsgBox("Invalid Date Format (MM/DD/YYYY)", MsgBoxStyle.Information, "FTY00004 - Invalid")
                e.Cancel = True
                sender.SelectAll()
                Exit Sub
            ElseIf IsDate(sender.Text) = False Then
                MsgBox("Invalid Generation Date", MsgBoxStyle.Information, "FTY00004 - Invalid")
                e.Cancel = True
                sender.SelectAll()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtBatNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBatNoFm.TextChanged
        txtBatNoTo.Text = txtBatNoFm.Text
    End Sub

    Private Sub txtJobOrdFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobOrdFm.TextChanged
        txtJobOrdTo.Text = txtJobOrdFm.Text
    End Sub

    Private Sub txtGenDatFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGenDatFm.TextChanged
        txtGenDatTo.Text = txtGenDatFm.Text
    End Sub

    Private Sub highlight_Text(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBatNoFm.Enter, txtBatNoTo.Enter, txtJobOrdFm.Enter, txtJobOrdTo.Enter, txtGenDatFm.Enter, txtGenDatTo.Enter
        sender.SelectAll()
    End Sub
End Class