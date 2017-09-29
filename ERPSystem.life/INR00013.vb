Public Class INR00013

    '*** Program ID     :SCR00002
    '*** Author         :Kenny Chan
    '*** Creation Date  :19-12-2001
    '*** Description    :SC
    '*** Logic          :
    '***
    '***************************************************************************************************************
    '*** Modification History
    '***************************************************************************************************************
    '*** Modified by        Modified on         Description:
    '***************************************************************************************************************
    '*** Lester Wu          2005-03-31          Replace ALL with UC-G, exclude MS Company data from UC-G
    '***                                        show only factory 0002 and K for MS Company,
    '***************************************************************************************************************


    '    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Public rs_VNBASINF As Dataset
    Public rs_SYSETINF As Dataset
    Public rs_SYCATCDE As Dataset

    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        '    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Lester Wu 2005-03-31, replace ALL with UC-G
        'If cboCocde.Text <> "ALL" Then
        If cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If

    End Sub

    Private Sub ChkIntClick()
        If ChkALL.Checked = True Then
            ChkALL.Checked = False
            Call ChkALL_Click()
        End If

        Dim ii As Integer

        If ChkInt.Checked = True Then
            For ii = 0 To lstVendorFrom.Items.Count - 1
                Select Case Split(lstVendorFrom.Items(ii), " - ")(0)
                    Case "0005", "0006", "0007", "0008", "0009", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
                        lstVendorFrom.SetSelected(ii, True)
                    Case Else
                        lstVendorFrom.SetSelected(ii, False)
                End Select
            Next
        Else
            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SetSelected(ii, False)
            Next
        End If

    End Sub


    Private Sub ChkALL_Click()
        If ChkInt.Checked = True Then
            ChkInt.Checked = False
            Call ChkIntClick()
        End If

        Dim ii As Integer
        If ChkALL.Checked = True Then

            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SetSelected(ii, True)
            Next
        Else
            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SetSelected(ii, False)
            Next
        End If
    End Sub
    'Private Sub ChkALL_Click()
    '    Dim ii As Integer
    '    If ChkALL.checked = True Then
    '        For ii = 0 To lstVendorFrom.Items.Count - 1
    '            lstVendorFrom.SelectedItems(ii) = True
    '        Next
    '    Else
    '        For ii = 0 To lstVendorFrom.Items.Count - 1
    '            lstVendorFrom.SelectedItems(ii) = False
    '        Next
    '    End If
    'End Sub
    Private Sub lstVendorFrom_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        ''Call AutoSearch(lstVendorFrom, KeyCode)
    End Sub

    Private Sub lstVendorFrom_LostFocus()
        'Call ValidateCombo(lstVendorFrom)
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

    Private Sub cboCatlevel_Fm_Click()
        cboCatlevel_To.Text = cboCatlevel_Fm.Text
    End Sub
    Private Sub cboCatlevel_click()

        Dim S As String
        Dim rs As DataSet

        Cursor = Cursors.WaitCursor

        S = "sp_list_SYCATCDE_MSR00015  '','" + GetCtrlValue(cboCatlevel) + "','" + gsUsrID & "'"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillCatLevel()
        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub cboCatlevel_Fm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCatlevel_Fm, KeyCode)
        cboCatlevel_To.Text = cboCatlevel_Fm.Text
    End Sub
    Private Sub cboCatlevel_Fm_LostFocus()
        Call ValidateCombo(cboCatlevel_Fm)
    End Sub

    Private Sub cboCatlevel_To_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCatlevel_To, KeyCode)
    End Sub

    Private Sub cboCatlevel_To_LostFocus()
        Call ValidateCombo(cboCatlevel_To)
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

        Dim S As String
        Dim rs As DataSet
        Dim ReportName As String
        Dim ReportRS As DataSet
        Dim DateFrom As Date
        Dim DateTo As Date
        Dim i As Integer
        Dim Z As Integer
        Dim j As Integer

        Dim rs_Temp As New DataSet
        Dim rs_Date As New DataSet

        Dim VendorString As String
        Dim VendorString_Lable As String

        Dim Arr(1000) As String

        'If cboSCFm.Text = "" And cboSCTo.Text = "" Then
        '    cboSCFm.selectedIndex = 0
        '    cboSCTo.selectedIndex = cboSCTo.Items.Count - 1
        'End If

        If cboCatlevel_Fm.Text = "" And cboCatlevel_To.Text <> "" Then
            cboCatlevel_To.Text = cboCatlevel_Fm.Text
        End If

        If Not InputIsVaild() Then
            Exit Sub
        End If

        Dim counter As Integer
        counter = 0



        For i = 0 To lstVendorFrom.SelectedItems.Count - 1
            VendorString = VendorString + Split(lstVendorFrom.SelectedItems(i), " - ")(0) & ","
            VendorString_Lable = VendorString_Lable & lstVendorFrom.SelectedItems(i) & IIf((counter + 1) Mod 4 = 0, Chr(13) & Chr(10), StrDup(Math.Abs(20 - Len(lstVendorFrom.SelectedItems(i))), " "))
            counter = counter + 1
        Next
        If VendorString = "" Then
            MsgBox("No Vendor selected")
            Exit Sub
        End If
        VendorString = Microsoft.VisualBasic.Left(VendorString, Len(VendorString) - 1)

        If ChkALL.Checked = True Then
            VendorString_Lable = "ALL Vendors"
        End If

        DateFrom = CDate(txtDateFrom.Text)
        DateTo = CDate(txtDateTo.Text)

        S = "sp_select_INR00013       '" & cboCocde.Text.Trim() & "'  ,'" & VendorString & _
            "','" & VendorString_Lable & _
            "','" & cboSCFm.Text & _
            "','" & cboSCTo.Text & _
            "','" & GetCtrlValue(cboCatlevel) & _
            "','" & GetCtrlValue(cboCatlevel_Fm) & _
            "','" & GetCtrlValue(cboCatlevel_To) & _
            "','" & DateFrom + " 00:00:00" & _
            "','" & DateTo + " 23:59:59" & "'"

        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_Date, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        End If

        '    rs_Date.Delete
        '*****************
        'Generate report
        '*****************

        Dim objRpt As New INR00013rpt
        objRpt.SetDataSource(rs_Date.Tables("RESULT"))

        Dim frmReportView As New frmReport
        frmReportView.CrystalReportViewer.ReportSource = objRpt
        frmReportView.Show()


        'Dim ReportName(0 To 1) As String
        'ReDim ReportRS(0 To 1) As Dataset
        'ReportName = "INR00013.rpt"
        'ReportRS = rs_Date
        ''ReportName(1) = "subreport00004"
        ''Set ReportRS(1) = rs_QUR0000A
        'frmReport.Show()

        Cursor = Cursors.Default
    End Sub
    Private Function InputIsVaild() As Boolean
        'If lstVendorFrom.Text = "" And cboVendorTo.Text = "" Then
        '    lstVendorFrom.selectedIndex = 0
        '    cboVendorTo.selectedIndex = cboVendorTo.Items.Count - 1
        'End If

        'If lstVendorFrom.Text = "" Then
        '   Msg .Tables("RESULT").Rows(index)("M00414")
        '    InputIsVaild = False
        '    lstVendorFrom.SetFocus
        '    Exit Function
        'End If

        'If cboVendorTo.Text = "" Then
        '    Msg .Tables("RESULT").Rows(index)("M00414")
        '    InputIsVaild = False
        '    cboVendorTo.SetFocus
        '    Exit Function
        'End If

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
        '*** Add print all company ***
        'Lester Wu 2005-03-31, replace ALL with UC-G and not show UC-G for MS company's users
        If gsDefaultCompany <> "MS" Then
            'cboCocde.Items.add "ALL"
            cboCoCde.Items.Add("UC-G")
        End If
        '*****************************
        Call GetDefaultCompany(Me.cboCocde, Me.txtCoNam)

        Call Formstartup(Me.Name)
        txtDateFrom.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        txtDateTo.Text = Format(Date.Today, "MM/dd/yyyy").ToString

        Dim S As String
        Dim rs As DataSet

        S = "sp_list_VNBASINF_All  '' "

        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboVendor()
        End If


        S = "sp_select_SUBCDE   '' "
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboSC()
        End If


        cboCatlevel.Items.Clear()
        cboCatlevel.Items.Add("0 - Category 0")
        cboCatlevel.Items.Add("1 - Category 1")
        cboCatlevel.Items.Add("2 - Category 2")
        cboCatlevel.Items.Add("3 - Category 3")
        cboCatlevel.Items.Add("4 - Category 4")
        cboCatlevel.selectedIndex = 0

        Cursor = Cursors.Default
        txtCoNam.BackColor = Color.White
        cmdShow.Text = "&Show Report"
    End Sub
    Private Sub FillcboVendor()
        '------------------------------------------------------------------
        'Show factory 0002 and K for MS company
        If gsDefaultCompany = "MS" Then
            If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
                rs_VNBASINF.Tables("RESULT").DefaultView.RowFilter = "vbi_venno = '0002' or vbi_venno = 'K'"
            End If
        End If
        '------------------------------------------------------------------
        If rs_VNBASINF.Tables("RESULT").DefaultView.Count > 0 Then

            With rs_VNBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    lstVendorFrom.Items.Add(rs_VNBASINF.Tables("RESULT").DefaultView(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").DefaultView(index)("vbi_vensna"))
                Next
            End With

        End If
    End Sub

    'Private Sub FillcboVendor()
    '    'Lester Wu 2005-03-31, show only factory 0002 and K for MS company
    '    If gsDefaultCompany = "MS" Then
    '        If rs_VNBASINF.Tables("RESULT").rows.count > 0 Then
    '            rs_VNBASINF.Tables("RESULT").DefaultView.RowFilter = "vbi_venno='0002' or vbi_venno='K'"
    '        End If
    '    End If

    '    If rs_VNBASINF.Tables("RESULT").rows.count > 0 Then
    '        While Not rs_VNBASINF.EOF
    '            lstVendorFrom.Items.add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
    '            rs_VNBASINF.MoveNext()
    '        End While
    '    End If
    'End Sub
    Private Sub FillcboSC()
        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then
            With rs_SYSETINF
                For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                    cboSCFm.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                    cboSCTo.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                Next
            End With
        End If
    End Sub
    Private Sub FillCatLevel()
        cboCatlevel_Fm.Items.Clear()
        cboCatlevel_To.Items.Clear()

        If rs_SYCATCDE.Tables("RESULT").Rows.Count > 0 Then
            With rs_SYCATCDE
                For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                    cboCatlevel_Fm.Items.Add(rs_SYCATCDE.Tables("RESULT").Rows(index)("ycc_catcde"))
                    cboCatlevel_To.Items.Add(rs_SYCATCDE.Tables("RESULT").Rows(index)("ycc_catcde"))
                Next
            End With

        End If
    End Sub

    Private Sub lstVendorFrom_MouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
        If lstVendorFrom.Items.Count <> lstVendorFrom.SelectedItems.Count Then
            ChkALL.Checked = False
        End If
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
    Private Function GetCtrlValue(ByVal Ctrl As Control) As String
        If TypeOf Ctrl Is ComboBox Then
            If Ctrl.Text <> "" Then
                If UBound(Split(Ctrl.Text, " - ")) > 0 Then
                    GetCtrlValue = Split(Ctrl.Text, " - ")(0)
                Else
                    GetCtrlValue = Ctrl.Text
                End If
            Else
                GetCtrlValue = ""
            End If
        ElseIf TypeOf Ctrl Is ListBox Then
            'If Ctrl.List(Ctrl.selectedIndex) <> "" Then
            '    If UBound(Split(Ctrl.List(Ctrl.selectedIndex), " - ")) > 0 Then
            '        GetCtrlValue = Split(Ctrl.List(Ctrl.selectedIndex), " - ")(0)
            '    Else
            '        GetCtrlValue = Ctrl.List(Ctrl.selectedIndex)
            '    End If
            'Else
            '    GetCtrlValue = ""
            'End If
        End If


    End Function



    Private Sub INR00013_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShow_Click()

    End Sub

    Private Sub lstVendorFrom_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstVendorFrom.KeyUp
        'If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab  and e.KeyCode <>  Keys.Delete Then
        '    Call auto_search_combo(sender)
        'End If

    End Sub

    Private Sub lstVendorFrom_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVendorFrom.LostFocus
        'Call ValidateCombo(lstVendorFrom)
    End Sub

    Private Sub lstVendorFrom_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstVendorFrom.MouseUp
        If lstVendorFrom.Items.Count = lstVendorFrom.SelectedItems.Count + 1 Then
            ChkALL.Checked = False
            Call ChkALL_Clicking()

        End If

    End Sub

    Private Sub lstVendorFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVendorFrom.SelectedIndexChanged

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

    Private Sub cboCatlevel_Fm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCatlevel_Fm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

        cboCatlevel_To.Text = cboCatlevel_Fm.Text
    End Sub

    Private Sub cboCatlevel_Fm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCatlevel_Fm.LostFocus
        'Call ValidateCombo(cboCatlevel_Fm)

    End Sub

    Private Sub cboCatlevel_Fm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel_Fm.SelectedIndexChanged
        cboCatlevel_To.Text = cboCatlevel_Fm.Text

    End Sub

    Private Sub cboCatlevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel.SelectedIndexChanged
        cboCatlevel_click()
    End Sub

    Private Sub cboCatlevel_To_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCatlevel_To.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboCatlevel_To_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCatlevel_To.LostFocus
        'Call ValidateCombo(cboCatlevel_To)

    End Sub

    Private Sub cboCatlevel_To_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel_To.SelectedIndexChanged

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

    Private Sub ChkALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkALL.CheckedChanged
        'Call ChkALL_Click()
    End Sub

    Private Sub ChkALL_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkALL.Click
        Call ChkALL_Click()
    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Function chkall_clicking()
        Dim ii As Integer
        If ChkALL.Checked = True Then

            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SetSelected(ii, True)
            Next
        Else
            For ii = 0 To lstVendorFrom.Items.Count - 1
                lstVendorFrom.SetSelected(ii, False)
            Next
        End If

    End Function

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

    Private Sub cboSCFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSCFm.Validating
        If ValidateCombo(cboSCFm) <> True Then
            cboSCFm.Focus()
        End If

    End Sub

    Private Sub cboSCTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSCTo.Validating
        If ValidateCombo(cboSCTo) <> True Then
            cboSCTo.Focus()
        End If
    End Sub

    Private Sub cboCatlevel_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCatlevel_Fm.Validating

        If ValidateCombo(cboCatlevel_Fm) <> True Then
            cboCatlevel_Fm.Focus()
        End If

    End Sub

    Private Sub cboCatlevel_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCatlevel_To.Validating
        If ValidateCombo(cboCatlevel_To) <> True Then
            cboCatlevel_To.Focus()
        End If
    End Sub

 
    Private Sub ChkInt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInt.CheckedChanged

    End Sub

    Private Sub ChkInt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkInt.Click
        Call ChkIntClick()
    End Sub
End Class