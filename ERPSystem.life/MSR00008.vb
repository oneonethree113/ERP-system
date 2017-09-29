Public Class MSR00008
    '*** Program ID     :MSR00008
    '*** Author         :Kenny Chan
    '*** Creation Date  :26-04-2002
    '*** Description    :
    '*** Logic          :
    '***

    '***************************************************************************************************************************************
    '*** Modification History
    '***************************************************************************************************************************************
    '*** Modified by        Modified on         Description:
    '***************************************************************************************************************************************
    '*** Lester Wu          Feb 16, 2004        ADD "ALL" COMPANY SELECTION
    '*** Lester Wu          31st Mar, 2005      Replace ALL with UC-G, not show UC-G for MS Company's users
    '***************************************************************************************************************************************

    Public rs_MSR00008 As DataSet
    Public rs_CUBASINF As Dataset
    Public rs_VNBASINF As Dataset

    Private Sub cboCoCde_Click()
        If Me.cboCocde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
        'XXXXXXXXXXXXXXXXXXXXX
    End Sub

    Private Sub cboCuFm_Click()
        cboCuTo.Text = cboCuFm.Text
    End Sub

    Private Sub cboCuFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCuFm, KeyCode)
        cboCuTo.Text = cboCuFm.Text
    End Sub

    Private Sub cboVnFm_Click()
        cboVnTo.Text = cboVnFm.Text
    End Sub

    Private Sub cboVnFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVnFm, KeyCode)
        cboVnTo.Text = cboVnFm.Text
    End Sub

    Private Sub cmdShow_Click()
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------



        If InputIsValid = False Then
            Exit Sub
        End If

        Dim S As String
        'Dim Co As String
        Dim CuFm As String
        Dim CuTo As String
        Dim VnFm As String
        Dim VnTo As String
        Dim rs As DataSet
        Dim ReportName As String
        Dim ReportRS As Dataset

        Cursor = Cursors.WaitCursor

        'If CoUCP.checked = true Then
        '    Co = "UCP"
        'Else
        '    Co = "UCPP"
        'End If

        If cboVnFm.Text = "" Then
            VnFm = ""
        Else
            VnFm = Split(cboVnFm.Text, " - ")(0)
        End If
        If cboVnTo.Text = "" Then
            VnTo = ""
        Else
            VnTo = Split(cboVnTo.Text, " - ")(0)
        End If
        If cboCuFm.Text = "" Then
            CuFm = ""
        Else
            CuFm = Split(cboCuFm.Text, " - ")(0)
        End If
        If cboCuTo.Text = "" Then
            CuTo = ""
        Else
            CuTo = Split(cboCuTo.Text, " - ")(0)
        End If

        '    S = "sp_select_MSR00008','S','" & "UCP" & _
        '        "','" & VnFm & _
        '        "','" & VnTo & _
        '        "','" & CuFm & _
        '        "','" & CuTo & _
        '        "','" & UCase(txtInvnoFrom.Text) & _
        '        "','" & UCase(txtInvnoTo.Text) & _
        '        "','" & cboMonth.Text & _
        '        "','" & txtYear.Text

        S = "sp_select_MSR00008   '" & cboCocde.Text.ToString.Trim & _
               "','" & VnFm & _
               "','" & VnTo & _
               "','" & CuFm & _
               "','" & CuTo & _
               "','" & UCase(txtInvnoFrom.Text) & _
               "','" & UCase(txtInvnoTo.Text) & _
               "','" & cboMonth.Text & _
               "','" & txtYear.Text & "'"

        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_MSR00008, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            If rs_MSR00008.Tables("RESULT").Rows.Count = 0 Then
                Cursor = Cursors.Default
                MsgBox("No Record Found!")
                Exit Sub
            Else
                Dim objRpt As New MSR00008rpt
                objRpt.SetDataSource(rs_MSR00008.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

                'ReportName = "MSR00008.rpt"
                'ReportRS = rs_MSR00008
                'frmReport.Show()

            End If
        End If

        Cursor = Cursors.Default
    End Sub

    'Private Sub CoUCP_Click()
    ''--------------------------------------
    ''rem by Lester Wu on 2004/02/03
    ''    cboVnFm.Text = "0005 - Elliwell"
    ''    cboVnTo.Text = "0005 - Elliwell"
    ''    cboCuFm.Text = ""
    ''    cboCuTo.Text = ""
    ''    cboVnFm.Enabled = False
    ''    cboVnTo.Enabled = False
    ''    cboCuFm.Enabled = False
    ''    cboCuTo.Enabled = False
    ''--------------------------------------
    'End Sub

    'Private Sub CoUCPP_Click()
    ''-------------------------------
    ''rem by Lester Wu on 2004/02/03
    ''    cboVnFm.Text = ""
    ''    cboVnTo.Text = ""
    ''    cboVnFm.Enabled = True
    ''    cboVnTo.Enabled = True
    ''    cboCuFm.Enabled = True
    ''    cboCuTo.Enabled = True
    ''-------------------------------
    'End Sub

    Private Sub Form_Load()

        '#If useMTS Then
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        Cursor = Cursors.WaitCursor
        '*************Default****************
        '*** Multi-Company Name Display.
        Call FillCompCombo(gsUsrID, cbococde)
        '*** ADD PRINT ALL COMPANY ***
        ' 2004/02/11
        'Lester Wu 2005-03-31, replace ALL with UC-G, not show UC-G for MS Company's users
        If gsDefaultCompany <> "MS" Then
            'Me.cboCoCde.Items.add "ALL"
            Me.cboCocde.Items.Add("UC-G")
        End If
        '*****************************
        Call GetDefaultCompany(me.cboCocde,Me.txtCoNam)

        Call Formstartup(Me.Name)

        Dim S As String
        Dim rs As DataSet

        Cursor = Cursors.WaitCursor

        S = "sp_list_CUBASINF  '','PA' "

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboCust()
        End If


        S = "sp_list_VNBASINF  ''"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboVen()
        End If

        '*************Month******************
        cboMonth.Items.Add("1 - January")
        cboMonth.Items.Add("2 - February")
        cboMonth.Items.Add("3 - March")
        cboMonth.Items.Add("4 - April")
        cboMonth.Items.Add("5 - May")
        cboMonth.Items.Add("6 - June")
        cboMonth.Items.Add("7 - July")
        cboMonth.Items.Add("8 - August")
        cboMonth.Items.Add("9 - September")
        cboMonth.Items.Add("10 - October")
        cboMonth.Items.Add("11 - November")
        cboMonth.Items.Add("12 - December")
        '***********************************
        txtYear.Text = Year(Date.Today)

        Call display_combo(Month(Date.Today), cboMonth)
        Cursor = Cursors.Default
    End Sub
    Private Sub FillcboCust()
        If rs_CUBASINF.Tables("RESULT").rows.count > 0 Then
            With rs_CUBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboCuFm.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                    cboCuTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                Next
            End With

        End If
    End Sub

    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").rows.count > 0 Then

            With rs_VNBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboVnFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                    cboVnTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                Next
            End With


        End If
    End Sub



    Private Sub txtInvNoFrom_Change()
        txtInvnoTo.Text = txtInvnoFrom.Text
    End Sub
    Private Sub txtInvNoFrom_GotFocus()
        Call HighlightText(txtInvnoFrom)
    End Sub
    Private Sub txtInvNoTo_GotFocus()
        Call HighlightText(txtInvnoTo)
    End Sub
    Private Sub txtYear_GotFocus()
        Call HighlightMask(txtYear)
    End Sub
    Function InputIsValid() As Boolean

        If cboCuTo.Text < cboCuFm.Text Then
            InputIsValid = False
            MsgBox("Customer No: To < From !")
            cboCuTo.Focus()
            Exit Function
        End If
        If cboVnTo.Text < cboVnFm.Text Then
            InputIsValid = False
            MsgBox("Vendor No: To < From !")
            cboVnTo.Focus()
            Exit Function
        End If
        If Trim(txtInvnoFrom.Text) = "" And Trim(txtInvnoTo.Text) <> "" Then
            InputIsValid = False
            MsgBox("Please input Vendor No from!")
            txtInvnoFrom.Focus()
            Exit Function
        ElseIf Trim(txtInvnoFrom.Text) <> "" And Trim(txtInvnoTo.Text) = "" Then
            InputIsValid = False
            MsgBox("Please input Vendor No To!")
            txtInvnoTo.Focus()
            Exit Function
        ElseIf cboMonth.Text = "" Then
            InputIsValid = False
            MsgBox("Please Select Month!")
            cboMonth.Focus()
            Exit Function
        ElseIf Trim(txtYear.Text) = "" Then
            InputIsValid = False
            MsgBox("Please input Year!")
            txtYear.Focus()
            Exit Function
        End If
        InputIsValid = True
    End Function


    Private Sub MSR00008_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        cmdShow_Click()

    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If Me.cboCocde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        End If

    End Sub

    Private Sub cboCuFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCuFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

        cboCuTo.Text = cboCuFm.Text

    End Sub

    Private Sub cboCuFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuFm.SelectedIndexChanged
        cboCuTo.Text = cboCuFm.Text

    End Sub

    Private Sub cboVnFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVnFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

        cboVnTo.Text = cboVnFm.Text

    End Sub

    Private Sub cboVnFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVnFm.SelectedIndexChanged
        cboVnTo.Text = cboVnFm.Text

    End Sub

    Private Sub txtInvnoFrom_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvnoFrom.GotFocus
        Call HighlightText(txtInvnoFrom)

    End Sub

    Private Sub txtInvnoFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvnoFrom.TextChanged
        txtInvnoTo.Text = txtInvnoFrom.Text

    End Sub

    Private Sub txtInvnoTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvnoTo.GotFocus
        Call HighlightText(txtInvnoTo)

    End Sub

    Private Sub txtInvnoTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvnoTo.TextChanged

    End Sub

    Private Sub txtYear_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.GotFocus
        Call HighlightMask(txtYear)

    End Sub

    Private Sub txtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub cboVnFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVnFm.Validating
        If ValidateCombo(cboVnFm) <> True Then
            cboVnFm.Focus()
        End If

    End Sub

    Private Sub cboVnTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVnTo.SelectedIndexChanged

    End Sub

    Private Sub cboVnTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVnTo.Validating
        If ValidateCombo(cboVnTo) <> True Then
            cboVnTo.Focus()
        End If

    End Sub

    Private Sub cboCuFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCuFm.Validating
        If ValidateCombo(cboCuFm) <> True Then
            cboCuFm.Focus()
        End If
    End Sub

    Private Sub cboCuTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuTo.SelectedIndexChanged

    End Sub

    Private Sub cboCuTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCuTo.Validating
        If ValidateCombo(cboCuTo) <> True Then
            cboCuTo.Focus()
        End If

    End Sub
End Class
