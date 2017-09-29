Public Class SHR00003
    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Dim IsUpdated As Boolean
    ' Added by Joe on 20100514
    Dim strModule As String
    '==
    Dim rs_check As DataSet
    Dim rs_Result As DataSet
    Dim rs_SYUSRRIGHT_Rel_Check As DataSet
    Dim rs_S As DataSet
    Public init_fromFactory As String = ""
    Public init_toFactory As String = ""


    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub SHR00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)          'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        Call Formstartup(Me.Name)
        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        'If gsConnStr = "" Then
        '    gsConnStr = getConnectionString()
        'End If
        cboDocTyp.Items.Add("Sales Confirmation")
        cboDocTyp.Items.Add("Purchase Order")
        cboDocTyp.Items.Add("Shipment")
        cboDocTyp.Items.Add("Credit Note")
        cboDocTyp.Items.Add("Debit Note")

        txtResult.Text = ""
        txtFromFactory.Text = init_fromFactory
        txtToFactory.Text = init_toFactory
    End Sub

    Private Sub txtFromFactory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromFactory.TextChanged
        txtToFactory.Text = txtFromFactory.Text
    End Sub

    Private Sub cboDocTyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocTyp.SelectedIndexChanged
        If cboDocTyp.SelectedIndex = 0 Or cboDocTyp.SelectedIndex = 1 Then
            optRel.Enabled = True
            optUnr.Enabled = True
        Else
            optRel.Enabled = False
            optUnr.Enabled = False
        End If
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        txtResult.Text = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        Dim S As String
        Dim t As String
        Dim r As String
        'Dim i As String
        Dim X As String
        Dim recfnd As Boolean

        'Dim rs() As ADOR.Recordset
        'Dim rs1() As ADOR.Recordset
        'Dim rec() As ADOR.Recordset
        'Dim rs_Result As ADOR.Recordset
        'Dim rs_check As ADOR.Recordset
        'Dim rs_right() As ADOR.Recordset
        Dim temp As String
        Dim optStr As String

        recfnd = True
        If optRel.Checked = True Then
            optStr = "Y"
        Else
            optStr = "N"
        End If

        cboDocTyp.SelectedIndex = 1
        If cboDocTyp.SelectedIndex = 0 Then
            strModule = "SC"

            gspStr = "sp_select_SCORDHDRR '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHR00003 cmdShow_Click sp_select_SCORDHDRR : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            End If


            If rs_Result.Tables("RESULT").Rows.Count > 0 Then
                'rs_Result.MoveFirst()
                For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
                    temp = temp & rs_Result.Tables("RESULT").Rows(i).Item("soh_ordno") & " " & rs_Result.Tables("RESULT").Rows(i).Item("soh_ordsts") & Chr(13) + Chr(10)
                Next


                txtResult.Text = temp
                temp = ""

                Me.Cursor = Windows.Forms.Cursors.Default
                If optStr = "Y" Then
                    MsgBox("All SC No. to be released must be active", vbExclamation, "Warning")
                Else
                    MsgBox("All SC No. to be unreleased must be released", vbExclamation, "Warning")
                End If
                Exit Sub
            Else
                'rs_right = objBSGate.Enquire(gsConnStr, "sp_general", S)
                gspStr = "sp_select_SYUSRRIGHT_Rel_Check '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "','" & strModule & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Rel_Check, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SHR00003 cmdShow_Click sp_select_SYUSRRIGHT_Rel_Check : " & rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    Exit Sub
                Else
                    If Not rs_SYUSRRIGHT_Rel_Check.Tables("RESULT").Rows.Count = 0 Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("All SC No. should have access rights", vbExclamation, "Warning")
                        Exit Sub
                    End If
                End If

            End If

        ElseIf cboDocTyp.SelectedIndex = 1 Then

            strModule = "PO"


            gspStr = "sp_select_POORDHDRR '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHR00003 cmdShow_Click sp_select_POORDHDRR : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            End If

            If rs_Result.Tables("RESULT").Rows.Count > 0 Then
                'rs_Result.MoveFirst()

                For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
                    temp = temp & rs_Result.Tables("RESULT").Rows(i).Item("poh_purord") & " " & rs_Result.Tables("RESULT").Rows(i).Item("poh_pursts") & Chr(13) + Chr(10)
                Next

                txtResult.Text = temp
                temp = ""

                Me.Cursor = Windows.Forms.Cursors.Default
                If optStr = "Y" Then
                    MsgBox("All PO No. to be released must be open", vbExclamation, "Warning")
                Else
                    MsgBox("All PO No. to be unreleased must be released", vbExclamation, "Warning")
                End If
                Exit Sub
            Else
                gspStr = "sp_select_SYUSRRIGHT_Rel_Check '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "','" & strModule & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Rel_Check, rtnStr)


                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SHR00003 cmdShow_Click sp_select_SYUSRRIGHT_Rel_Check : " & rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    Exit Sub
                Else
                    If Not rs_SYUSRRIGHT_Rel_Check.Tables("RESULT").Rows.Count = 0 Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("All PO No. should have access rights", vbExclamation, "Warning")
                        Exit Sub
                    End If
                End If

            End If
        End If

        If cboDocTyp.SelectedIndex = 0 Then
            'If gsCompany = "UCPP" Then
            S = "sp_select_SCM00002 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "'"
            'Else
            'S = "sp_select_SCM00002 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "'"
            'End If
            t = "sp_select_SHR00002 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','0'"
            r = ", PO is Generated "
        ElseIf cboDocTyp.SelectedIndex = 1 Then
            S = "sp_select_POM00004 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "'"
            t = "sp_select_SHR00002 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','1'"
            r = ", Job Order, Running No and/or BOM PO is Generated "
        ElseIf cboDocTyp.SelectedIndex = 2 Then
            S = "sp_select_SHM03 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','Y'"
            X = "sp_select_SHIPGHDR_check '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "'"
            t = X

            rtnLong = execute_SQLStatement(X, rs_check, rtnStr)


            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHR00003 cmdShow_Click sp_select_SHIPGHDR_check : " & rtnStr)
                IsUpdated = False
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If Not rs_SYUSRRIGHT_Rel_Check.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("All PO No. should have access rights", vbExclamation, "Warning")
                    Exit Sub
                End If

                'rs_check = rs1(1)
                If rs_check.Tables("RESULT").Rows.Count <= 0 Then
                    MsgBox("Shipping Record Not Found", vbInformation, "Warning")
                    IsUpdated = False
                    Me.Cursor = Windows.Forms.Cursors.Default
                    Exit Sub
                End If

            End If

        ElseIf cboDocTyp.SelectedIndex = 3 Then
            S = "sp_select_SHM02 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','C'"
        ElseIf cboDocTyp.SelectedIndex = 4 Then
            S = "sp_select_SHM02 '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','D'"
        End If
        If S <> "" Then  '*** if there is something to do with s ...

            rtnLong = execute_SQLStatement(S, rs_S, rtnStr)

            'MsgBox("count = " & rs_S.Tables.Count)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHR00003 cmdShow_Click rs_S : " & rtnStr)
                IsUpdated = False
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub

            Else
                If rs_S.Tables.Count > 0 Then
                    IsUpdated = False
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Operation Fail - " & rs_S.Tables("RESULT").Rows(0)(0), MsgBoxStyle.Information, "Information")
                    Exit Sub
                End If


                If t <> "" Then  '*** if there is something to do with s ...
                    rtnLong = execute_SQLStatement(t, rs_Result, rtnStr)
                    'rs_Result = rec(1)
                    If rs_Result.Tables("RESULT").Rows.Count > 0 Then
                        'rs_Result.MoveFirst()
                    End If
                    For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
                        Select Case cboDocTyp.SelectedIndex
                            Case Is = 1
                                temp = temp & "PO:" & rs_Result.Tables("RESULT").Rows(i).Item(0) & New String(" ", Math.Abs(10 - Len(rs_Result.Tables("RESULT").Rows(i).Item(0)))) & _
                                              rs_Result.Tables("RESULT").Rows(i).Item(1) & New String(" ", Math.Abs(10 - Len(rs_Result.Tables("RESULT").Rows(i).Item(1)))) & _
                                              "Jo: " & rs_Result.Tables("RESULT").Rows(i).Item(2) & New String(" ", Math.Abs(15 - Len(rs_Result.Tables("RESULT").Rows(i).Item(2)))) & _
                                              "Run#: " & rs_Result.Tables("RESULT").Rows(i).Item(3) & New String(" ", Math.Abs(10 - Len(rs_Result.Tables("RESULT").Rows(i).Item(3)))) & _
                                              "Bom Po:" & rs_Result.Tables("RESULT").Rows(i).Item(4) & New String(" ", Math.Abs(15 - Len(rs_Result.Tables("RESULT").Rows(i).Item(4)))) & _
                                              rs_Result.Tables("RESULT").Rows(i).Item(5) & New String(" ", Math.Abs(10 - Len(rs_Result.Tables("RESULT").Rows(i).Item(5)))) & Chr(13) + Chr(10)

                            Case 2
                                temp = temp & "Shipment No " & rs_Result.Tables("RESULT").Rows(i).Item(1) & " has Released. " & Chr(13) + Chr(10)
                            Case 0, Is > 2
                                temp = temp & "Pri Cust:" & rs_Result.Tables("RESULT").Rows(i).Item(0) & New String(" ", Math.Abs(6 - Len(rs_Result.Tables("RESULT").Rows(i).Item(0)))) & _
                                            "Sec Cust:" & rs_Result.Tables("RESULT").Rows(i).Item(1) & New String(" ", Math.Abs(6 - Len(rs_Result.Tables("RESULT").Rows(i).Item(1)))) & _
                                            "SC No.:" & rs_Result.Tables("RESULT").Rows(i).Item(2) & New String(" ", Math.Abs(15 - Len(rs_Result.Tables("RESULT").Rows(i).Item(2)))) & _
                                            "PO No:" & rs_Result.Tables("RESULT").Rows(i).Item(3) & New String(" ", Math.Abs(15 - Len(rs_Result.Tables("RESULT").Rows(i).Item(3)))) & _
                                            "CV:" & rs_Result.Tables("RESULT").Rows(i).Item(4) & New String(" ", Math.Abs(10 - Len(rs_Result.Tables("RESULT").Rows(i).Item(4)))) & _
                                            "PV:" & rs_Result.Tables("RESULT").Rows(i).Item(5) & Chr(13) + Chr(10)
                        End Select
                    Next

                End If
                txtResult.Text = temp
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Operation Successful " & r) 'MsgBox("Operation Successful " & r & i)
                IsUpdated = True
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub
End Class