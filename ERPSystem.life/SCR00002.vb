Public Class SCR00002

    '*** Program ID     :SCR00002
    '*** Author         :Kenny Chan
    '*** Creation Date  :19-12-2001
    '*** Description    :SC
    '*** Logic          :
    '***
    '******************************************************************************************************************
    '*** Modification History
    '******************************************************************************************************************
    '*** Modified by        Modified on     Description:
    '******************************************************************************************************************
    '*** Lester Wu          2005-04-06      Replace ALL with UC-G, not show UC-G for MS company's users
    '*** Lestser Wu         2005-06-16      Set "Date" label to "S/C Issue Date" when "Order Amt", "Outstanding Order Amt"
    '***                                    or "Purchase Amt" is selected
    '***                                    set to "Ship. Inv. Date" when "Shipped Amt" is selected
    '******************************************************************************************************************
    'Option Explicit


    'Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    'Dim Rpt_SCR00002 As SCR00002Rpt    '**** Remark by Lewis
    'Dim Rpt_SCR00002A As SCR00002RptA
    'Dim Rpt_SCR00002B As SCR00002RptB
    Public rs_SCR00002 As DataSet '**** Add by Lewis on 20 Jun 2003
    Public rs_CUBASINF As Dataset
    Public rs_VNBASINF As Dataset
    Public rs_SYSETINF As Dataset
    Public rs_SYSALREP As Dataset
    ' Added by Joe on 20100513
    Dim strModule As String

    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        'If cboCocde.Text <> "ALL" Then
        If cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
    End Sub

    Private Sub cboCustFrom_Click()
        cboCustTo.Text = cboCustFrom.Text
    End Sub

    Private Sub cboCustFrom_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)

        'Call AutoSearch(cboCustFrom, KeyCode)

        cboCustTo.Text = cboCustFrom.Text
        'Call AutoSearch(cboCustTo, KeyCode)
    End Sub

    Private Sub cboCustFrom_LostFocus()
        Call ValidateCombo(cboCustFrom)
    End Sub
    Private Sub cboCustTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCustTo, KeyCode)
    End Sub
    Private Sub cboCustTo_LostFocus()
        Call ValidateCombo(cboCustTo)
    End Sub

    Private Sub cboSCFm_Click()
        cboSCTo.Text = cboSCFm.Text
    End Sub

    Private Sub cboSCFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSCFm, KeyCode)
    End Sub

    Private Sub cboSCFm_LostFocus()
        Call ValidateCombo(cboSCFm)
        cboSCTo.Text = cboSCFm.Text
    End Sub

    Private Sub cboSCTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSCTo, KeyCode)
    End Sub

    Private Sub cboSCTo_LostFocus()
        Call ValidateCombo(cboSCTo)
    End Sub

    Private Sub cboSTFm_Click()
        cboSTTo.Text = cboSTFm.Text
    End Sub

    Private Sub cboSTFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSTFm, KeyCode)
        cboSTTo.Text = cboSTFm.Text
    End Sub

    Private Sub cboVenFm_Click()
        cboVenTo.Text = cboVenFm.Text
    End Sub
    Private Sub cboVenFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenFm, KeyCode)
    End Sub
    Private Sub cboVenFm_LostFocus()
        Call ValidateCombo(cboVenFm)
        cboVenTo.Text = cboVenFm.Text
    End Sub
    Private Sub cboVenTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenTo, KeyCode)
    End Sub
    Private Sub cboVenTo_LostFocus()
        Call ValidateCombo(cboVenTo)
    End Sub

    Private Sub cmdShow_Click()
        If (txtDateFrom.Text = "  /  /" Or txtDateTo.Text = "  /  /") Then
            MsgBox("Please input Date!")
            Exit Sub
        End If

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------


        Dim ReportName As String
        Dim ReportRS As DataSet

        If cboCustFrom.Text = "" And cboCustTo.Text = "" Then
            cboCustFrom.SelectedIndex = 0
            cboCustTo.SelectedIndex = cboCustTo.Items.Count - 1
        End If


        If cboSTTo.Text = "" And cboSTFm.Text <> "" Then
            cboSTTo.Text = cboSTFm.Text
        End If


        'If cboVenFm.Text = "" And cboVenTo.Text = "" Then
        '    cboVenFm.SelectedIndex = 0
        '    cboVenTo.SelectedIndex = cboVenTo.items.count - 1
        'End If

        'If cboSCFm.Text = "" And cboSCTo.Text = "" Then
        '    cboSCFm.SelectedIndex = 0
        '    cboSCTo.SelectedIndex = cboSCTo.items.count - 1
        'End If

        If Not InputIsVaild() Then
            Exit Sub
        End If

        Dim S As String
        Dim rs As DataSet
        Dim rs_data As DataSet
        Dim VENTYP As String

        If optVentyp1.Checked = True Then VENTYP = "I"
        If optVentyp2.Checked = True Then VENTYP = "E"
        If optVentyp3.Checked = True Then VENTYP = "B"


        If optLevel0.Checked = True Then



            ' Modified by Joe on 20100513
            S = "sp_select_SCR00002Rpt '" & cboCocde.Text.Trim() & "','" & Split(cboCustFrom.Text, " - ")(0) & _
                "','" & Split(cboCustTo.Text, " - ")(0) & _
                "','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
                "','" & Format(txtDateTo.Text, "MM/dd/yyyy") & _
                "','" & gsUsrID & "','" & strModule & "'"

            'S = "sp_select_SCR00002Rpt','S','" & Split(cboCustFrom.Text, " - ")(0) & _
            '"','" & Split(cboCustTo.Text, " - ")(0) & _
            '        "','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
            '"','" & Format(txtDateTo.Text, "MM/dd/yyyy")

            Cursor = Cursors.WaitCursor
            gspStr = S
            rtnLong = execute_SQLStatementRPT(gspStr, rs_CUBASINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp  :" & rtnStr)
            Else
                If rs_CUBASINF.Tables("result").Rows.Count = 0 Then
                    Cursor = Cursors.Default
                    MsgBox("No Record Found!")
                    Exit Sub
                Else
                    'Set Rpt_SCR00002 = New SCR00002Rpt
                    'Rpt_SCR00002.Database.SetDataSource rs_CUBASINF
                    'Set frmCR.Report = Rpt_SCR00002
                    'frmCR.Show
                    rs_data = rs_CUBASINF.Copy

                    ''ReportRS = rs_data
                    ''ReportName = "SCR00009.rpt"
                    ''frmReport.Show()

                End If

            End If

            '**********************************************
        ElseIf optLevel1.Checked = True Then
            ' Modified by Joe on 20100513
            'S = "sp_select_SCR00002Rpt_A','S','" & Split(cboCustFrom.Text, " - ")(0) & _
            '        "','" & Split(cboCustTo.Text, " - ")(0) & _
            '       "','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
            '      "','" & Format(txtDateTo.Text, "MM/dd/yyyy")

            S = "sp_select_SCR00002Rpt_A '" & cboCocde.Text.Trim() & "','" & Split(cboCustFrom.Text, " - ")(0) & _
                "','" & Split(cboCustTo.Text, " - ")(0) & _
                "','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
                "','" & Format(txtDateTo.Text, "MM/dd/yyyy") & _
                "','" & gsUsrID & "','" & strModule & "'"

            Cursor = Cursors.WaitCursor
            gspStr = S
            rtnLong = execute_SQLStatementRPT(gspStr, rs_CUBASINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp  :" & rtnStr)
            Else
                If rs_CUBASINF.Tables("result").Rows.Count = 0 Then
                    Cursor = Cursors.Default
                    MsgBox("No Record Found!")
                    Exit Sub
                Else
                    Dim objRpt As New SCR00002RptA
                    objRpt.SetDataSource(rs_CUBASINF.Tables("RESULT"))

                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()


                    ''Rpt_SCR00002A = New SCR00002RptA
                    ''Rpt_SCR00002A.Database.SetDataSource(rs_CUBASINF)
                    ''frmCR.Report = Rpt_SCR00002A
                    ''frmCR.Show()
                End If

            End If


        Else
            '*************Kenny Add on 07-10-2002
            If optAmt.Checked = True Then
                ' Modified by joe on 20100514
                'S = "sp_select_SCR00002Rpt_B','S','" & Split(cboCustFrom.Text, " - ")(0) & _
                '"','" & Split(cboCustTo.Text, " - ")(0) & _
                '"','" & cboVenFm.Text & _
                '"','" & cboVenTo.Text & _
                '"','" & cboSCFm.Text & _
                '"','" & cboSCTo.Text & _
                '"','" & cboSTFm.Text & _
                '"','" & cboSTTo.Text & _
                '"','" & VENTYP & _
                '"','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
                '"','" & Format(txtDateTo.Text, "MM/dd/yyyy")
                S = "sp_select_SCR00002Rpt_B   '" & cboCocde.Text.Trim() & "' ,'" & Split(cboCustFrom.Text, " - ")(0) & _
                    "','" & Split(cboCustTo.Text, " - ")(0) & _
                    "','" & cboVenFm.Text & _
                    "','" & cboVenTo.Text & _
                    "','" & cboSCFm.Text & _
                    "','" & cboSCTo.Text & _
                    "','" & cboSTFm.Text & _
                    "','" & cboSTTo.Text & _
                    "','" & VENTYP & _
                    "','" & txtDateFrom.Text & _
                    "','" & txtDateTo.Text & _
                    "','" & gsUsrID & "','" & strModule & "'"
            ElseIf OptOSAmt.Checked = True Then
                ' Modified by Joe on 20100514
                'S = "sp_select_SCR00002Rpt_OS','S','" & Split(cboCustFrom.Text, " - ")(0) & _
                '            "','" & Split(cboCustTo.Text, " - ")(0) & _
                '           "','" & cboVenFm.Text & _
                '          "','" & cboVenTo.Text & _
                '         "','" & cboSCFm.Text & _
                '        "','" & cboSCTo.Text & _
                '       "','" & cboSTFm.Text & _
                '      "','" & cboSTTo.Text & _
                '     "','" & VENTYP & _
                '    "','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
                '   "','" & Format(txtDateTo.Text, "MM/dd/yyyy")
                S = "sp_select_SCR00002Rpt_OS   '" & cboCocde.Text.Trim() & "','" & Split(cboCustFrom.Text, " - ")(0) & _
                    "','" & Split(cboCustTo.Text, " - ")(0) & _
                    "','" & cboVenFm.Text & _
                    "','" & cboVenTo.Text & _
                    "','" & cboSCFm.Text & _
                    "','" & cboSCTo.Text & _
                    "','" & cboSTFm.Text & _
                    "','" & cboSTTo.Text & _
                    "','" & VENTYP & _
                    "','" & txtDateFrom.Text & _
                    "','" & txtDateTo.Text & _
                    "','" & gsUsrID & "','" & strModule & "'"
            ElseIf OptPURAmt.Checked = True Then
                ' Modified by Joe on 20100514
                'S = "sp_select_SCR00002Rpt_c','S','" & Split(cboCustFrom.Text, " - ")(0) & _
                '"','" & Split(cboCustTo.Text, " - ")(0) & _
                '"','" & cboVenFm.Text & _
                '"','" & cboVenTo.Text & _
                '"','" & cboSCFm.Text & _
                '"','" & cboSCTo.Text & _
                '"','" & cboSTFm.Text & _
                '"','" & cboSTTo.Text & _
                '"','" & VENTYP & _
                '"','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
                '"','" & Format(txtDateTo.Text, "MM/dd/yyyy")
                S = "sp_select_SCR00002Rpt_c  '" & cboCocde.Text.Trim() & "','" & Split(cboCustFrom.Text, " - ")(0) & _
                    "','" & Split(cboCustTo.Text, " - ")(0) & _
                    "','" & cboVenFm.Text & _
                    "','" & cboVenTo.Text & _
                    "','" & cboSCFm.Text & _
                    "','" & cboSCTo.Text & _
                    "','" & cboSTFm.Text & _
                    "','" & cboSTTo.Text & _
                    "','" & VENTYP & _
                    "','" & txtDateFrom.Text & _
                    "','" & txtDateTo.Text & _
                    "','" & gsUsrID & "','" & strModule & "'"
            ElseIf OptSHPAmt.Checked = True Then
                'S = "sp_select_SCR00002Rpt_d','S','" & Split(cboCustFrom.Text, " - ")(0) & _
                '"','" & Split(cboCustTo.Text, " - ")(0) & _
                '"','" & cboVenFm.Text & _
                '"','" & cboVenTo.Text & _
                '"','" & cboSCFm.Text & _
                '"','" & cboSCTo.Text & _
                '"','" & cboSTFm.Text & _
                '"','" & cboSTTo.Text & _
                '"','" & VENTYP & _
                '"','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
                '"','" & Format(txtDateTo.Text, "MM/dd/yyyy")
                S = ""

                S = "sp_select_SCR00002Rpt_d  '" & cboCocde.Text.Trim() & "', '" & Split(cboCustFrom.Text, " - ")(0) & _
                    "','" & Split(cboCustTo.Text, " - ")(0) & _
                    "','" & cboVenFm.Text & _
                    "','" & cboVenTo.Text & _
                    "','" & cboSCFm.Text & _
                    "','" & cboSCTo.Text & _
                    "','" & cboSTFm.Text & _
                    "','" & cboSTTo.Text & _
                    "','" & VENTYP & _
                    "','" & txtDateFrom.Text & _
                    "','" & txtDateTo.Text & _
                    "','" & gsUsrID & "','" & strModule & "'"

                '               "','" & Format(txtDateFrom.Text, "MM/dd/yyyy") & _
                '"','" & Format(txtDateTo.Text, "MM/dd/yyyy") & _

            End If
            Cursor = Cursors.WaitCursor
            gspStr = S
            rtnLong = execute_SQLStatementRPT(gspStr, rs_CUBASINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp  :" & rtnStr)
            Else
                If rs_CUBASINF.Tables("result").Rows.Count = 0 Then
                    Cursor = Cursors.Default
                    MsgBox("No Record Found!")
                    Exit Sub
                Else

                    Dim objRpt As New SCR00002RptB
                    objRpt.SetDataSource(rs_CUBASINF.Tables("RESULT"))

                    If optAmt.Checked = True Then
                        Dim TextObject1 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject1 = objRpt.Section2.ReportObjects("Text2")
                        TextObject1.Text = "Sales Confirmation Analysis Report (Order)"

                        Dim TextObject2 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject2 = objRpt.Section2.ReportObjects("txtDate")
                        TextObject2.Text = "S/C Issue Date"

                    ElseIf OptOSAmt.Checked = True Then


                        Dim TextObject1 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject1 = objRpt.Section2.ReportObjects("Text2")
                        TextObject1.Text = "Sales Confirmation Analysis Report (Outstanding)"
                        TextObject1.Left = TextObject1.Left - 300

                        Dim TextObject2 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject2 = objRpt.Section2.ReportObjects("txtDate")
                        TextObject2.Text = "S/C Issue Date"

                    ElseIf OptPURAmt.Checked = True Then
                        Dim TextObject1 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject1 = objRpt.Section2.ReportObjects("Text2")
                        TextObject1.Text = "Purchase Order Analysis Report (Order)"
                        TextObject1.Left = TextObject1.Left - 300

                        Dim TextObject2 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject2 = objRpt.Section2.ReportObjects("txtDate")
                        TextObject2.Text = "S/C Issue Date"


                    ElseIf OptSHPAmt.Checked = True Then

                        Dim TextObject1 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject1 = objRpt.Section2.ReportObjects("Text2")
                        TextObject1.Text = "Sales Confirmation Analysis Report (Shipped Amt)"
                        TextObject1.Left = TextObject1.Left - 300

                        Dim TextObject2 As CrystalDecisions.CrystalReports.Engine.TextObject
                        TextObject2 = objRpt.Section2.ReportObjects("txtDate")
                        TextObject2.Text = "Ship. Inv. Date"
                    End If


                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()

                    ''Rpt_SCR00002B = New SCR00002RptB
                    ''Rpt_SCR00002B.Database.SetDataSource(rs_CUBASINF)
                    ' ''*************Kenny Add on 07-10-2002
                    ''frmCR.Report = Rpt_SCR00002B
                    ''frmCR.Show()
                End If
            End If

        End If
        Cursor = Cursors.Default
    End Sub
    Private Function InputIsVaild() As Boolean

        If cboCustFrom.Text = "" Then
            MsgBox("Please Input Customer Range!")
            InputIsVaild = False
            cboCustFrom.Focus()
            Exit Function
        End If

        If cboCustTo.Text = "" Then
            MsgBox("Please Input Customer Range!")
            InputIsVaild = False
            cboCustTo.Focus()
            Exit Function
        End If

        If cboVenTo.Text < cboVenFm.Text Then
            MsgBox("Vendor No. To must >= Vendor No. From", vbExclamation, "Error")
            InputIsVaild = False
            cboVenTo.Focus()
            Exit Function
        End If

        If cboSCTo.Text < cboSCFm.Text Then
            MsgBox("Sub-Code No. To must >= Sub-Code No. From", vbExclamation, "Error")
            InputIsVaild = False
            cboSCTo.Focus()
            Exit Function
        End If

        If CDate(txtDateFrom.Text) > CDate(Me.txtDateTo.Text) Then
            MsgBox("Start Date > End Date")
            InputIsVaild = False
            txtDateFrom.Focus()
            Exit Function
        End If

        InputIsVaild = True
    End Function

    Private Sub cmdShow_KeyDown(ByVal KeyCode As Integer, ByVal Shift As Integer)
        If cboCustFrom.Text = "" And cboCustTo.Text = "" Then
            cboCustFrom.SelectedIndex = 0
            cboCustTo.SelectedIndex = cboCustTo.items.count - 1
        End If

    End Sub

    Private Sub cmdShow_MouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
        If cboCustFrom.Text = "" And cboCustTo.Text = "" Then
            cboCustFrom.SelectedIndex = 0
            cboCustTo.SelectedIndex = cboCustTo.items.count - 1
        End If

    End Sub

    Private Sub Form_Load()
        '#If useMTS Then
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        Cursor = Cursors.WaitCursor

        strModule = "SC"
        Call FillCompCombo(gsUsrID, cbococde)
        Call GetDefaultCompany(Me.cboCocde, Me.txtCoNam)


        '*** Add print all company ***
        'Lester Wu 2005-04-06, replace ALL with UC-G, not show UC-G to MS company's users
        If gsDefaultCompany <> "MS" Then
            'cboCoCde.Items.add "ALL"
            cboCocde.Items.Add("UC-G")
        End If
        '*****************************

        '*************Default****************




        Call Formstartup(Me.Name)
        txtDateFrom.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        txtDateTo.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        optLevel2.checked = True
        Dim S As String
        Dim rs As DataSet

        S = "sp_list_CUBASINF  '','PA'"
        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboCust()
        End If

        S = "sp_list_VNBASINF ''"
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboVen()
        End If


        S = "sp_select_SUBCDE  '' "
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboSC()
        End If



        S = "sp_list_SYSALREP_MSR00013  ''"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboST()
        End If

        optVentyp1.Checked = True

        Cursor = Cursors.Default
    End Sub

    Private Sub FillcboCust()
        If rs_CUBASINF.Tables("result").Rows.Count > 0 Then
            With rs_CUBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboCustFrom.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                    cboCustTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                Next
            End With

        End If
    End Sub
    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("result").Rows.Count > 0 Then
            With rs_VNBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                    cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                Next
            End With

        End If
    End Sub
    Private Sub FillcboSC()
        If rs_SYSETINF.Tables("result").Rows.Count > 0 Then
            With rs_SYSETINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboSCFm.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                    cboSCTo.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                Next
            End With
        End If
    End Sub

    Private Sub OptPURAmt_Click()

    End Sub

    Private Sub txtDateFrom_GotFocus()
        Call HighlightMask(txtDateFrom)
    End Sub

    Private Sub txtDateFrom_LostFocus()
        If Not IsDate(txtDateFrom.Text) Then
            MsgBox("Date is Invalid !")
            txtDateFrom.Focus()
        End If

    End Sub
    Private Sub txtDateTo_GotFocus()
        Call HighlightMask(txtDateTo)
    End Sub

    Private Sub txtDateTo_LostFocus()
        If Not IsDate(txtDateTo.Text) Then
            MsgBox("Date is Invalid !")
            txtDateTo.Focus()
        End If
    End Sub
    Private Sub FillcboST()
        If rs_SYSALREP.Tables("result").Rows.Count > 0 Then
            With rs_SYSALREP
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboSTFm.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(index)("ysr_saltem"))
                    cboSTTo.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(index)("ysr_saltem"))
                Next
            End With

        End If
    End Sub


    Private Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If
        ValidateCombo = False
        Dim i As Integer
        Dim S As String
        S = Combo1.Text
        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items(i).ToString) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next
        If Not ValidateCombo Then
            MsgBox("Invalid Data! Please try again.")
            On Error Resume Next
            Combo1.Focus()
            On Error GoTo 0
        End If
    End Function

    Private Sub SCR00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShow_Click()

    End Sub

    Private Sub cboCustFrom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustFrom.GotFocus
        'flag_cboCustFrom_GotFocus = True

    End Sub

    Private Sub cboCustFrom_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustFrom.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCustFrom_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustFrom.LostFocus

        'If flag_cboCustFrom_GotFocus = True Then
        '    flag_cboCustFrom_GotFocus = False
        '    Call ValidateCombo(cboCustFrom)
        'End If


    End Sub

    Private Sub cboCustFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustFrom.SelectedIndexChanged
        cboCustTo.Text = cboCustFrom.Text

    End Sub

    Private Sub cboCustTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCustTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustTo.LostFocus
        'Call ValidateCombo(cboCustTo)

    End Sub

    Private Sub cboCustTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustTo.SelectedIndexChanged

    End Sub

    Private Sub cboSCFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSCFm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSCFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCFm.LostFocus
        'Call ValidateCombo(cboSCFm)
        cboSCTo.Text = cboSCFm.Text

    End Sub

    Private Sub cboSCFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCFm.SelectedIndexChanged
        cboSCTo.Text = cboSCFm.Text

    End Sub

    Private Sub cboSCTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSCTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSCTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCTo.LostFocus
        'Call ValidateCombo(cboSCTo)

    End Sub

    Private Sub cboSCTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCTo.SelectedIndexChanged

    End Sub

    Private Sub cboSTFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSTFm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSTFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSTFm.SelectedIndexChanged
        cboSTTo.Text = cboSTFm.Text

    End Sub

    Private Sub cboVenFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenFm.LostFocus
        'Call ValidateCombo(cboVenFm)
        cboVenTo.Text = cboVenFm.Text

    End Sub

    Private Sub cboVenFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenFm.SelectedIndexChanged
        cboVenTo.Text = cboVenFm.Text

    End Sub

    Private Sub cboVenTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenTo.LostFocus
        'Call ValidateCombo(cboVenTo)

    End Sub

    Private Sub cboVenTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenTo.SelectedIndexChanged

    End Sub

    Private Sub cmdShow_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdShow.KeyDown
        If cboCustFrom.Text = "" And cboCustTo.Text = "" Then
            cboCustFrom.SelectedIndex = 0
            cboCustTo.SelectedIndex = cboCustTo.Items.Count - 1
        End If

    End Sub

    Private Sub cmdShow_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdShow.KeyUp

    End Sub

    Private Sub cmdShow_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdShow.MouseDown
        If cboCustFrom.Text = "" And cboCustTo.Text = "" Then
            cboCustFrom.SelectedIndex = 0
            cboCustTo.SelectedIndex = cboCustTo.Items.Count - 1
        End If

    End Sub

    Private Sub txtDateFrom_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.GotFocus
        Call HighlightMask(txtDateFrom)

    End Sub

    Private Sub txtDateFrom_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.LostFocus
        If Not IsDate(txtDateFrom.Text) Then
            MsgBox("Date is Invalid !")
            txtDateFrom.Focus()
        End If

    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub txtDateTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateTo.GotFocus
        Call HighlightMask(txtDateTo)

    End Sub

    Private Sub txtDateTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateTo.LostFocus
        If Not IsDate(txtDateTo.Text) Then
            MsgBox("Date is Invalid !")
            txtDateTo.Focus()
        End If

    End Sub

    Private Sub txtDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateTo.MaskInputRejected

    End Sub

    Private Sub cboCustFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCustFrom.Validating
        Call ValidateCombo(cboCustFrom)

    End Sub

    Private Sub cboCustTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCustTo.Validating
        Call ValidateCombo(cboCustTo)
    End Sub

    Private Sub cboSCFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSCFm.Validating
        Call ValidateCombo(cboSCFm)
    End Sub

    Private Sub cboSCTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSCTo.Validating
        Call ValidateCombo(cboSCTo)
    End Sub

    Private Sub cboVenFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenFm.Validating
        Call ValidateCombo(cboVenFm)
    End Sub

    Private Sub cboVenTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenTo.Validating
        Call ValidateCombo(cboVenTo)
    End Sub

    Private Sub cboSTFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSTFm.Validating
        ValidateCombo(cboSTFm)
    End Sub

    Private Sub cboSTTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSTTo.SelectedIndexChanged

    End Sub

    Private Sub cboSTTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSTTo.Validating
        ValidateCombo(cboSTTo)
    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        '*** Multi-Company Name Display.
        '    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'XXXXXXXXXXXXXXXXXXXXX
        ' 2004/02/11 Lester Wu
        'Lester Wu 2005-03-21 Replace "ALL" with "UC-G"
        If Me.cboCocde.Text <> "UC-G" Then
            'If Me.cboCoCde.Text <> "ALL" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
        'XXXXXXXXXXXXXXXXXXXXX

    End Sub
End Class

