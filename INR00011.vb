Public Class INR00011
    '*** Program ID     :SCR00002
    '*** Author         :Kenny Chan
    '*** Creation Date  :19-12-2001
    '*** Description    :SC
    '*** Logic          :
    '***
    '***
    '*** Modification History
    '***    Modified by  +   Modified on   +  Modification description:
    '------------------------------------------------------------------------------------
    '       Lester Wu       2004/05/29
    '***    Lester Wu       2005/03/30        replace ALL with UC-G, exclude MS from UC-G
    '***                                      show MS company data in a separate report
    '***                                      show 0002 and K factory for MS company's user
    'Option Explicit


    ''Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Public rs_VNBASINF As Dataset
    Public rs_SYSETINF As Dataset
    Public rs_SYCATCDE As Dataset
    Public rs_CUBASINF As DataSet
    Dim flag_cboCatlevel_GotFocus As Boolean


    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        '    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'replace ALL with UC-G
        'If cboCocde.Text <> "ALL" Then
        If cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If

    End Sub






    Private Sub ChkALL_Click()
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

    Private Sub chkCustAll_Click()
        Dim ii As Integer
        If chkCustAll.Checked = True Then
            For ii = 0 To lstCust.Items.Count - 1
                lstCust.Items(ii).Selected = True
            Next
        Else
            For ii = 0 To lstCust.Items.Count - 1
                lstCust.Items(ii).Selected = False
            Next
        End If
    End Sub





    Private Sub lstCust_MouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
    End Sub

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
        If ValidateCombo(cboSCFm) = True Then
            cboSCTo.Text = cboSCFm.Text
        End If
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

        S = "sp_list_SYCATCDE_MSR00015 '','" + GetCtrlValue(cboCatlevel) + "','" + gsUsrID & "'"
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        Else
            Call FillCatLevel()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub cboCatlevel_Fm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCatlevel_Fm, KeyCode)
        'cboCatlevel_To.Text = cboCatlevel_Fm.Text
    End Sub
    Private Sub cboCatlevel_Fm_LostFocus()
        If ValidateCombo(cboCatlevel_Fm) = True Then
            Me.cboCatlevel_To.Text = Me.cboCatlevel_Fm.Text
        End If
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
        gsCompany = Trim(cboCoCde.Text)
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

        'Lester Wu 2004/05/29
        Dim strCust As String
        Dim strCust_label As String

        Dim Arr(1000) As String

        'If cboSCFm.Text = "" And cboSCTo.Text = "" Then
        '    cboSCFm.SelectedIndex = 0
        '    cboSCTo.SelectedIndex = cboSCTo.Items.Count - 1
        'End If

        If cboCatlevel_Fm.Text = "" And cboCatlevel_To.Text <> "" Then
            cboCatlevel_To.Text = cboCatlevel_Fm.Text
        End If


        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


        If Not InputIsVaild() Then
            Exit Sub
        End If

        Dim intCount As Integer
        intCount = 0
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        For j = 0 To lstVendorFrom.SelectedItems.Count - 1
            VendorString = VendorString + Split(lstVendorFrom.SelectedItems(j).ToString, " - ")(0) & ","
            VendorString_Lable = VendorString_Lable & Replace(lstVendorFrom.SelectedItems(j).ToString, "'", "''") & IIf((intCount + 1) Mod IIf(Me.optActShip0.Checked = True, 6, 4) = 0, Chr(13) & Chr(10), StrDup(Math.Abs(20 - Len(lstVendorFrom.Items(j).ToString.Trim)), " "))
            intCount = intCount + 1
        Next



        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        If VendorString = "" Then
            MsgBox("No Vendor selected")
            Exit Sub
        End If



        VendorString = Microsoft.VisualBasic.Left(VendorString, Len(VendorString) - 1)

        '==lstCust=========================================================
        'If not choose any customer

        If Me.chkCustAll.Checked = True Then
            strCust = ""
        Else
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            intCount = 0
            For j = 0 To lstCust.SelectedItems.Count - 1
                strCust = strCust + Split(lstCust.SelectedItems(j).ToString, " - ")(0) & ","

                strCust_label = strCust_label & Replace(lstCust.SelectedItems(j).ToString, "'", "''") & IIf((intCount + 1) Mod IIf(Me.optActShip0.Checked = True, 6, 4) = 0, Chr(13) & Chr(10), StrDup(Math.Abs(20 - Len(lstCust.Items(j).ToString.Trim)), " "))

                intCount = intCount + 1
            Next
            If intCount > 50 Then
                'average length of cbi_cusno & " - " & cbi_cussna = 17
                Cursor = Cursors.Default
                MsgBox("Number of Selected Customer cannot More 50")
                Exit Sub
            End If
            If strCust = "" Then
                MsgBox("No Customer Selected!")
                Exit Sub
            End If
        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        If strCust <> "" Then
            strCust = Microsoft.VisualBasic.Left(strCust, Len(strCust) - 1)
        End If
        '===========================================================


        If ChkALL.Checked = True Then
            VendorString_Lable = "ALL Vendors"
        End If

        DateFrom = CDate(txtDateFrom.Text)
        DateTo = CDate(txtDateTo.Text)


        '   sp_select_INR00011 for Half-month Format
        '   sp_select_INR00011b for Monthly Format
        '
        '    VendorString = "0001"
        '   strCust = "50100"

        S = "sp_select_INR00011 '" & cboCoCde.Text.ToString.Trim & _
            "','" & VendorString & _
            "','" & VendorString_Lable & _
            "','" & cboSCFm.Text & _
            "','" & cboSCTo.Text & _
            "','" & GetCtrlValue(cboCatlevel) & _
            "','" & GetCtrlValue(cboCatlevel_Fm) & _
            "','" & GetCtrlValue(cboCatlevel_To) & _
            "','" & DateFrom & " 00:00:00" & _
            "','" & DateTo & " 23:59:59" & _
            "','" & strCust & _
            "','" & strCust_label & _
            "','" & IIf(Me.optYrTitle0.Checked = True, "Y", "N") & _
            "','" & IIf(Me.optActShip0.Checked = True, "Y", "N") & _
            "','" & IIf(Me.optPeriod0.Checked = True, "H", IIf(Me.optPeriod1.Checked = True, "M", "Y")) & "'"

        'terminate execution if length of S > 4000
        'coz the string will be truncated when pass to db
        '    If Len(S) > 4000 Then
        '        Cursor = Cursors.Default
        '        MsgBox "String pass to sp_general is too long"
        '        Exit Sub
        '    End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


        '    S = "sp_select_INR00011','S','" & VendorString & _
        '        "','" & VendorString_Lable & _
        '        "','" & cboSCFm.Text & _
        '        "','" & cboSCTo.Text & _
        '        "','" & GetCtrlValue(cboCatlevel) & _
        '        "','" & GetCtrlValue(cboCatlevel_Fm) & _
        '        "','" & GetCtrlValue(cboCatlevel_To) & _
        '        "','" & DateFrom & " 00:00:00" & _
        '        "','" & DateTo & " 23:59:59"

        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_Date, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            If rs_Date.Tables("result").Rows.Count = 0 Then
                MsgBox("Record not found!")
                Exit Sub

            End If
        End If

        '*****************
        'Generate report
        '*****************

        'Dim ReportName(0 To 1) As String
        'ReDim ReportRS(0 To 1) As Dataset

        If Me.optActShip0.Checked = True Then
            Dim objRpt As New INR00011brpt
            objRpt.SetDataSource(rs_Date.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()

        Else
            Dim objRpt As New INR00011rpt
            objRpt.SetDataSource(rs_Date.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()

        End If





        Cursor = Cursors.Default
    End Sub
    Private Function InputIsVaild() As Boolean
        'If lstVendorFrom.Text = "" And cboVendorTo.Text = "" Then
        '    lstVendorFrom.SelectedIndex = 0
        '    cboVendorTo.SelectedIndex = cboVendorTo.Items.Count - 1
        'End If

        'If lstVendorFrom.Text = "" Then
        '   Msg ("M00414")
        '    InputIsVaild = False
        '    lstVendorFrom.SetFocus
        '    Exit Function
        'End If

        'If cboVendorTo.Text = "" Then
        '    Msg ("M00414")
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
        Call FillCompCombo(gsUsrID, cboCoCde)
        If gsDefaultCompany <> "MS" Then
            '*** Add print all company ***
            'Lester Wu 2005-03-30 replace ALL with UC-G
            'cboCocde.Items.add "ALL"
            cboCoCde.Items.Add("UC-G")
            '*****************************
        End If

        Call GetDefaultCompany(Me.cboCoCde, Me.txtCoNam)

        Call Formstartup(Me.Name)

        txtDateFrom.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        txtDateTo.Text = Format(Date.Today, "MM/dd/yyyy").ToString

        Dim S As String
        Dim rs As DataSet

        S = "sp_list_VNBASINF_All ''"

        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboVendor()
        End If


        S = "sp_list_CUBASINF '','PA'"
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillLstCust()
        End If



        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        S = "sp_select_SUBCDE ''  "

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
        cboCatlevel.SelectedIndex = 0

        Dim ii As Integer

        For ii = 0 To lstCust.Items.Count - 1
            lstCust.SetSelected(ii, True)
        Next


        Cursor = Cursors.Default
        txtCoNam.BackColor = Color.White



    End Sub

    Private Sub FillLstCust()
        If rs_CUBASINF Is Nothing Then
            Exit Sub
        End If

        'Lester Wu 2005-04-28, only show primary customer only
        If gsDefaultCompany = "MS" Then
            rs_CUBASINF.Tables("result").DefaultView.RowFilter = "cbi_cusno like '7%'"
        Else
            rs_CUBASINF.Tables("result").DefaultView.RowFilter = "cbi_cusno like '5%'"
        End If

        If rs_CUBASINF.Tables("RESULT").DefaultView.Count > 0 Then
            Me.lstCust.Items.Clear()
            With rs_CUBASINF
                For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    Me.lstCust.Items.Add(rs_CUBASINF.Tables("RESULT").DefaultView(index9)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").DefaultView(index9)("cbi_cussna"))
                Next
            End With

            Me.chkCustAll.Checked = True
        End If

    End Sub

    Private Sub FillcboVendor()
        'Lester Wu 2005-03-30, show 0002 and K factory for MS company's user
        If gsDefaultCompany = "MS" Then
            If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
                rs_VNBASINF.Tables("result").DefaultView.RowFilter = "vbi_venno = '0002' or vbi_venno = 'K'"
            End If
        End If

        If rs_VNBASINF.Tables("RESULT").DefaultView.Count > 0 Then

            With rs_VNBASINF
                For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    lstVendorFrom.Items.Add(rs_VNBASINF.Tables("RESULT").DefaultView(index9)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").DefaultView(index9)("vbi_vensna"))
                Next
            End With

        End If
    End Sub
    Private Sub FillcboSC()
        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then

            For index As Integer = 0 To rs_SYSETINF.Tables("RESULT").Rows.Count - 1
                cboSCFm.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
                cboSCTo.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(index)("subcde"))
            Next

        End If
    End Sub
    Private Sub FillCatLevel()
        cboCatlevel_Fm.Items.Clear()
        cboCatlevel_To.Items.Clear()

        If rs_SYCATCDE.Tables("RESULT").Rows.Count > 0 Then

            For index As Integer = 0 To rs_SYCATCDE.Tables("RESULT").Rows.Count - 1
                cboCatlevel_Fm.Items.Add(rs_SYCATCDE.Tables("RESULT").Rows(index)("ycc_catcde"))
                cboCatlevel_To.Items.Add(rs_SYCATCDE.Tables("RESULT").Rows(index)("ycc_catcde"))
            Next

        End If
    End Sub

    Private Sub lstVendorFrom_MouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Single, ByVal Y As Single)
        'If lstVendorFrom.Selected(lstVendorFrom.SelectedIndex) = False Then
        '    ChkALL.Checked = False
        'End If
    End Sub

    Private Sub optPeriod_Click(ByVal Index As Integer)

    End Sub

    Private Sub optYrTitle_Click(ByVal Index As Integer)

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
            'tempzz,
            If Trim(Ctrl.Text) <> "" Then
                If UBound(Split(Ctrl.Text, " - ")) > 0 Then
                    GetCtrlValue = Split(Ctrl.Text, " - ")(0)
                Else
                    GetCtrlValue = Ctrl.Text
                End If
            Else
                GetCtrlValue = ""
            End If
        End If
    End Function



    Private Sub INR00011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShow_Click()

    End Sub

    Private Sub lstCust_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstCust.MouseUp
        If lstCust.Items.Count = lstCust.SelectedItems.Count + 1 Then
            chkCustAll.Checked = False
            Call chkCustAll_clicking()

        End If


    End Sub

    Private Sub lstCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCust.SelectedIndexChanged

    End Sub

    Private Sub cboSCFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCFm.LostFocus
        cboSCTo.Text = cboSCFm.Text

        'If ValidateCombo(cboSCFm) = True Then
        '    cboSCTo.Text = cboSCFm.Text
        'End If

    End Sub

    Private Sub cboSCFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCFm.SelectedIndexChanged
        cboSCTo.Text = cboSCFm.Text

    End Sub

    Private Sub cboSCTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCTo.LostFocus
        '        Call ValidateCombo(cboSCTo)

    End Sub

    Private Sub cboSCTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCTo.SelectedIndexChanged

    End Sub

    Private Sub cboCatlevel_Fm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCatlevel_Fm.LostFocus
        Me.cboCatlevel_To.Text = Me.cboCatlevel_Fm.Text

        'If ValidateCombo(cboCatlevel_Fm) = True Then
        '    Me.cboCatlevel_To.Text = Me.cboCatlevel_Fm.Text
        'End If


    End Sub

    Private Sub cboCatlevel_Fm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel_Fm.SelectedIndexChanged
        cboCatlevel_To.Text = cboCatlevel_Fm.Text

    End Sub

    Private Sub cboCatlevel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCatlevel.GotFocus
        flag_cboCatlevel_GotFocus = True

    End Sub

    Private Sub cboCatlevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel.SelectedIndexChanged

        If flag_cboCatlevel_GotFocus = True Then
            flag_cboCatlevel_GotFocus = False
            cboCatlevel_click()

        End If

    End Sub

    Private Sub cboCatlevel_To_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCatlevel_To.LostFocus
        'Call ValidateCombo(cboCatlevel_To)

    End Sub

    Private Sub cboCatlevel_To_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatlevel_To.SelectedIndexChanged

    End Sub

    Private Sub lstVendorFrom_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstVendorFrom.MouseUp

        If lstVendorFrom.Items.Count = lstVendorFrom.SelectedItems.Count + 1 Then
            ChkALL.Checked = False
            Call chkall_clicking()
        End If
        'If lstVendorFrom.Items(lstVendorFrom.SelectedIndex).Selected = False Then

        '    ChkALL.Checked = False
        'End If

    End Sub

    Private Sub lstVendorFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVendorFrom.SelectedIndexChanged

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
        '    ChkALL_Click()
    End Sub

    Private Sub ChkALL_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkALL.Click
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

    Private Sub chkCustAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustAll.CheckedChanged
    End Sub

    Private Sub chkCustAll_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCustAll.Click
        Dim ii As Integer
        If chkCustAll.Checked = True Then
            For ii = 0 To lstCust.Items.Count - 1
                lstCust.SetSelected(ii, True)
            Next
        Else
            For ii = 0 To lstCust.Items.Count - 1
                lstCust.SetSelected(ii, False)
            Next
        End If


    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        '*** Multi-Company Name Display.
        '    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'XXXXXXXXXXXXXXXXXXXXX
        ' 2004/02/11 Lester Wu
        'Lester Wu 2005-03-21 Replace "ALL" with "UC-G"
        If Me.cboCoCde.Text <> "UC-G" Then
            'If Me.cboCoCde.Text <> "ALL" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
        'XXXXXXXXXXXXXXXXXXXXX

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

    Function chkCustAll_clicking()
        Dim ii As Integer
        If chkCustAll.Checked = True Then
            For ii = 0 To lstCust.Items.Count - 1
                lstCust.SetSelected(ii, True)
            Next
        Else
            For ii = 0 To lstCust.Items.Count - 1
                lstCust.SetSelected(ii, False)
            Next
        End If


    End Function

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

    Private Sub cboCatlevel_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCatlevel.Validating
        If ValidateCombo(cboCatlevel) <> True Then
            cboCatlevel.Focus()
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInt.CheckedChanged

    End Sub

    Private Sub ChkInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInt.Click
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
End Class
