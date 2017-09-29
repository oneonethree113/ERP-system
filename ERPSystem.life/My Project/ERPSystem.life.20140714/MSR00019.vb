Imports Microsoft.Office.Interop
Imports System.IO
Public Class MSR00019


    Public rs_CUBASINF As DataSet
    Public rs_CUBASINF_S As DataSet

    Public rs_MSR00019 As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As DataSet
    Public objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Public dr() As DataRow

    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        '    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'XXXXXXXXXXXXXXXXXXXXX
        ' 2004/02/11 Lester Wu
        'Lester Wu 2005-04-04, replace ALL with UC-G
        'If Me.cboCoCde.Text <> "ALL" Then
        ''If Me.cboCoCde.Text <> "UC-G" Then
        ''    txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        ''Else
        ''    Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        ''End If
        'XXXXXXXXXXXXXXXXXXXXX
    End Sub

    Private Sub cboCustNoFm_LostFocus()
        'Call ValidateCombo(cboCustNoFm)
    End Sub

    Private Sub cboCustNoTo_LostFocus()
        'Call ValidateCombo(cboCustNoTo)
    End Sub



    Private Sub cboSIStatus_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSIStatus, KeyCode)
    End Sub

    Private Sub cboSIStatus_LostFocus()
        'Call ValidateCombo(cboSIStatus)
    End Sub


    Private Sub cmdShow_Click()
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------



        ' Validation Issue Date------------------------------------

        If txtDateFrom.Text = "  /  /    " And txtDateTo.Text <> "  /  /    " Then
            MsgBox("Issue Date Empty (From) !")
            Exit Sub
        End If


        If txtDateFrom.Text <> "  /  /    " And txtDateTo.Text = "  /  /    " Then
            MsgBox("Issue Date Empty (To) !")
            Exit Sub
        End If


        If txtDateFrom.Text <> "  /  /    " Then
            'If CheckDate(txtDateFrom.Text) = False Then
            '    MsgBox("Issue Date invalid !")
            '    'txtDateFrom.SetFocus()
            '    Exit Sub
            'End If
        End If


        'If txtDateTo.Text <> "  /  /    " Then
        '    'If CheckDate(txtDateTo.Text) = False Then
        '    '    MsgBox("Issue Date invalid !")
        '    '    'txtDateTo.SetFocus()
        '    '    Exit Sub
        '    'End If
        'End If





        If txtDateFrom.Text <> "  /  /    " And txtDateTo.Text <> "  /  /    " Then
            If Mid(txtDateFrom.Text, 7) > Mid(txtDateTo.Text, 7) Then
                MsgBox("Issue Date: End Date < Start date ! (YY)")
                'txtDateFrom.SetFocus()
                Exit Sub
            ElseIf Mid(txtDateFrom.Text, 7) = Mid(txtDateTo.Text, 7) Then
                If Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) > Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    MsgBox("Issue Date: End Date < Start date ! (MM)")
                    'txtDateFrom.SetFocus()
                    Exit Sub
                ElseIf Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) = Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    If Mid(txtDateFrom.Text, 4, 2) > Mid(txtDateTo.Text, 4, 2) Then
                        MsgBox("Issue Date: End Date < Start date ! (DD)")
                        'txtDateFrom.SetFocus()
                        Exit Sub
                    End If
                End If
            End If
        End If


        ' Validation S/C No ------------------------------------

        If txtSCFm.Text > txtSCTo.Text Then
            MsgBox("S/C No. : From > To !")
            Exit Sub
        End If

        If txtSCFm.Text = "" And txtSCTo.Text <> "" Then
            MsgBox("S/C No. Empty (From) !")
            Exit Sub
        End If

        If txtSCFm.Text <> "" And txtSCTo.Text = "" Then
            MsgBox("S/C No. Empty (To) !")
            Exit Sub
        End If


        ' Validation Customer Code ------------------------------------
        If cboCustNoFm.Text > cboCustNoTo.Text Then
            MsgBox("Customer : From > To !")
            'cboCustNoFm.SetFocus()
            Exit Sub
        End If

        If cboCustNoFm.Text = "" And cboCustNoTo.Text <> "" Then
            MsgBox("Customer Code Empty (From) !")
            'cboCustNoFm.SetFocus()
            Exit Sub
        End If

        If cboCustNoFm.Text <> "" And cboCustNoTo.Text = "" Then
            MsgBox("Customer Code Empty (To) !")
            'cboCustNoFm.SetFocus()
            Exit Sub
        End If


        '-------------------------------------------------

        If cboScStatus.Text = "" Then
            MsgBox("Please Select the Invoice Status!")
            'cboSIStatus.SetFocus()
            Exit Sub
        End If


        'ReDim ReportName(0) As String
        'ReDim ReportRS(0)  As DataSet



        ' Set Issue Date value to empty then there is "  /  /    "
        Dim IDF As String
        Dim IDT As String

        If txtDateFrom.Text = "  /  /    " Then
            IDF = ""

        Else
            IDF = txtDateFrom.Text
        End If

        If txtDateTo.Text = "  /  /    " Then
            IDT = ""

        Else
            IDT = txtDateTo.Text + " 23:59:59.990"
        End If





        ' Customer No --------------------------------------
        Dim CNF As String
        Dim cnt As String


        If cboCustNoFm.Text = "" Then
            CNF = ""
        Else
            CNF = Split(cboCustNoFm.Text, " - ")(0)
        End If

        If cboCustNoTo.Text = "" Then
            cnt = ""
        Else
            cnt = Split(cboCustNoTo.Text, " - ")(0)
        End If

        Dim status As String

        If cboScStatus.Text <> "" Then
            status = Split(cboScStatus.Text, " - ")(0)
        End If

        Dim sort As String
        If OptCust.Checked = True Then
            sort = "Customer"
        Else
            sort = "S/C No."
        End If

        Dim S As String
        Dim rs As New DataSet
        Me.Cursor = Windows.Forms.Cursors.WaitCursor




        'S = "㊣MSR00019','S','" & _
        '    CNF & "','" & cnt & _
        '    "','" & txtFromItmno.Text & "','" & txtToItmno.Text & _
        '    "','" & VENCDEFM & "','" & VENCDETO & _
        '    "','" & VenSubCdeFm & "','" & VenSubCdeTo & _
        '    "','" & VenTypFm & "','" & VenTypTo & _
        '    "','" & IDF & "','" & IDT & _
        '    "','" & status & _
        '    "','" & sort & "','" & gsUsrID

        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)



        'If rs.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    MsgBox(rs.Tables("RESULT").Rows(0).Item(0).ToString) '*** An error has occured
        '    Exit Sub
        'Else

        'rs_MSR00019 = rs.Copy
        ' ''should copy only row one

        'If rs_MSR00019.Tables("RESULT").Rows.Count = 0 Then
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    '                msg("M00071")
        '    Exit Sub
        'Else

        '    '************Sorting***********************
        '    If OptCust.Checked = True Then
        '        rs_MSR00019.Tables("RESULT").DefaultView.Sort = "Pri_Cust,Sec_Cust"
        '    Else
        '        rs_MSR00019.Tables("RESULT").DefaultView.Sort = "sih_invno"
        '    End If


        '    If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
        '        '''ReportName(0) = "MSR00019.rpt"
        '    Else
        '        '''ReportName(0) = "MSR00019B.rpt"
        '    End If


        '    '''ReportRS(0) = rs_MSR00019
        ''    frmReport.Show()

        'End If

        'End If

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub Form_Load()

        ' ''Me.Width = 10800
        ' ''Me.Height = 7000

        '' ''#If useMTS Then
        '' ''        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '' ''#Else
        '' ''        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '' ''#End If


        ' ''Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        ' ''cboCoCde.Items.Add("ALL")
        ' ''Call GetDefaultCompany(cboCoCde, txtCoNam)







        ' ''Call FillcboCust()
        ' ''Call FillcboVen()



        ' ''Me.Cursor = Windows.Forms.Cursors.WaitCursor
        '' ''*************Default****************
        '' ''*** Multi-Company Name Display.

        ''''''Call FillCompCombo(gsUsrID, Me)

        '' ''*** ADD PRINT ALL COMPANY ***
        '' '' 2004/02/11
        '' ''Lester Wu 2005-04-04, replace ALL with UC-G, not show UC-G to MS company's users
        ' ''If gsDefaultCompany <> "MS" Then
        ' ''    'Me.cboCoCde.Items.Add "ALL"
        ' ''    Me.cboCoCde.Items.Add("UC-G")
        ' ''End If
        '' ''*****************************
        ''''''Call GetDefaultCompany(Me)

        ' ''Call Formstartup(Me.Name)

        '''''''''''''''''''''''
        ' ''Dim S As String
        ' ''Dim rs As New DataSet

        ' ''Me.Cursor = Windows.Forms.Cursors.WaitCursor

        ' ''S = "㊣CUBASINF','L','PA"

        ' ''rs = objBSGate.Enquire(gsConnStr, "sp_general", S)


        ' ''If rs.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then  '*** An error has occured
        ' ''    MsgBox(rs.Tables("RESULT").Rows(0).Item(0).ToString)
        ' ''Else
        ' ''    rs_CUBASINF = rs.Copy
        ' ''    '''should  copy row one
        ' ''    ''' 
        ' ''    Call FillcboCust()
        ' ''End If


        ' ''Dim s2 As String
        ' ''Dim rs2 As New DataSet

        ' ''s2 = "㊣VNBASINF','L"

        ' ''rs2 = objBSGate.Enquire(gsConnStr, "sp_general", s2)

        ' ''If rs2.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then  '*** An error has occured
        ' ''    MsgBox(rs2.Tables("RESULT").Rows(0).Item(0).ToString)
        ' ''Else
        ' ''    rs_VNBASINF = rs2.Copy
        ' ''    ''shoyuld copy row one only

        ' ''    '''Call FillcboVenCde()
        ' ''End If


        ' ''Dim S3 As String
        ' ''Dim rs3 As New DataSet

        ' ''S3 = "㊣SYSETINF','L"

        ' ''rs3 = objBSGate.Enquire(gsConnStr, "sp_general", S3)

        ' ''If rs3.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then
        ' ''    MsgBox(rs3.Tables("RESULT").Rows(0).Item(0).ToString)
        ' ''Else
        ' ''    rs_SYSETINF = rs3.Copy
        ' ''    '''shoyuld ciopy row one only

        ' ''    Call FillcboVenSubCde()
        ' ''End If


        ' ''cboVenSubCdeFm.Enabled = False
        ' ''cboVenSubCdeTo.Enabled = False
        ' ''cboSIStatus.Items.Add("ALL - All Status")

        ' ''cboSIStatus.Items.Add("OPE - OPEN")
        ' ''cboSIStatus.Items.Add("REL - Released")
        ' ''cboSIStatus.Items.Add("CLO - Close")

        ' ''cboSIStatus.SelectedIndex = 0


        ' ''cboVenTypFm.Items.Clear()

        ' ''cboVenTypFm.Items.Add("E - External")
        ' ''cboVenTypFm.Items.Add("I - Internal")
        ' ''cboVenTypFm.Items.Add("J - Joint-Venture")
        ' ''cboVenTypFm.SelectedIndex = 0
        ' ''cboVenTypFm.Text = ""

        ' ''cboVenTypTo.Items.Clear()
        ' ''cboVenTypTo.Items.Add("E - External")
        ' ''cboVenTypTo.Items.Add("I - Internal")
        ' ''cboVenTypTo.Items.Add("J - Joint-Venture")
        ' ''cboVenTypTo.SelectedIndex = 0
        ' ''cboVenTypTo.Text = ""


        ' ''Me.Cursor = Windows.Forms.Cursors.Default

    End Sub




    Private Sub FillcboCust()

        If rs_CUBASINF Is Nothing Then
            Exit Sub
        End If


        cboCustNoFm.Items.Clear()
        cboCustNoTo.Items.Clear()
        cboCustNoFm.Items.Add("")
        cboCustNoTo.Items.Add("")

        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '60000'")

            For i As Integer = 0 To dr.Length - 1
                cboCustNoFm.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
                cboCustNoTo.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
            Next

            cboCustNoFm.SelectedIndex = 0
            cboCustNoTo.SelectedIndex = 0
        End If
    End Sub


    Private Sub FillcboCust2()
        cboCustNo2Fm.Text = ""
        cboCustNo2Fm.Items.Clear()
        cboCustNo2To.Text = ""
        cboCustNo2To.Items.Clear()

        cboCustNo2Fm.Items.Add("")
        cboCustNo2To.Items.Add("")
        If cboCustNoFm.Text.Trim = "" Then
            Exit Sub
        End If
        gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCustNoFm.Text, InStr(cboCustNoFm.Text, " - ") - 1) & "','Secondary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00007_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If


        If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
            '            dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= '50000' and csc_seccus < '60000'")
            dr = rs_CUBASINF_S.Tables("RESULT").Select("1=1")

            For i As Integer = 0 To dr.Length - 1
                cboCustNo2Fm.Items.Add(dr(i)("csc_seccus") & " - " & dr(i)("cbi_cussna"))
                cboCustNo2To.Items.Add(dr(i)("csc_seccus") & " - " & dr(i)("cbi_cussna"))
            Next

            cboCustNo2Fm.SelectedIndex = 0
            cboCustNo2To.SelectedIndex = 0
        End If
    End Sub




    Private Sub txtDateFrom_Change()
        '        txtDateTo.Text = txtDateFrom.Text
    End Sub

    Private Sub txtFromItmno_Change()
        txtSCTo.Text = txtSCFm.Text
    End Sub

    Private Sub cboCustNoFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCustNoFm, KeyCode)
    End Sub

    Private Sub cboCustNoTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCustNoTo, KeyCode)
    End Sub

    Private Sub cboCustNoFm_click()
        cboCustNoTo.Text = cboCustNoFm.Text
    End Sub

    Private Sub txtFromItmno_GotFocus()
        'Call HighlightText(txtFromItmno)
    End Sub

    Private Sub txtToItmno_GotFocus()
        ''Call HighlightText(txtToItmno)
    End Sub

    Private Sub txtDateFrom_GotFocus()
        'Call HighlightMask(txtDateFrom)
    End Sub

    Private Sub txtDateTo_GotFocus()
        'Call HighlightMask(txtDateTo)
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------



        ' Validation Issue Date------------------------------------

        If txtDateFrom.Text = "  /  /    " And txtDateTo.Text <> "  /  /    " Then
            MsgBox("Issue Date Empty (From) !")
            Exit Sub
        End If


        If txtDateFrom.Text <> "  /  /    " And txtDateTo.Text = "  /  /    " Then
            MsgBox("Issue Date Empty (To) !")
            Exit Sub
        End If


        If Trim(txtDateFrom.Text) <> Trim("  /  /    ") Then
            If Not IsDate(txtDateFrom.Text) Then
                MsgBox(" Issue Date Invalid (From) !")
                Exit Sub
            End If
        End If

        If Trim(txtDateTo.Text) <> Trim("  /  /    ") Then
            If Not IsDate(txtDateTo.Text) Then
                MsgBox(" Issue Date Invalid (To) !")
                Exit Sub
            End If
        End If


        If Trim(DtShpStr.Text) <> Trim("  /  /    ") Then
            If Not IsDate(DtShpStr.Text) Then
                MsgBox(" Ship Date Invalid (From) !")
                Exit Sub
            End If
        End If

        If Trim(DtShpEnd.Text) <> Trim("  /  /    ") Then
            If Not IsDate(DtShpEnd.Text) Then
                MsgBox(" Ship Date Invalid (To) !")
                Exit Sub
            End If
        End If



        'If txtDateFrom.Text <> "  /  /    " Then
        '    If CheckDate(txtDateFrom.Text) = False Then
        '    MsgBox ("Issue Date invalid !")
        '        'txtDateFm.SetFocus()
        '        Exit Sub
        '    End If
        'End If


        'If txtDateTo.Text <> "  /  /    " Then
        '    If CheckDate(txtDateTo.Text) = False Then
        '    MsgBox ("Issue Date invalid !")
        '        'txtDateTo.Text.SetFocus()
        '        Exit Sub
        '    End If
        'End If





        If txtDateFrom.Text <> "  /  /    " And txtDateTo.Text <> "  /  /    " Then
            If Mid(txtDateFrom.Text, 7) > Mid(txtDateTo.Text, 7) Then
                MsgBox("Issue Date: End Date < Start date ! (YY)")
                'txtDateFm.SetFocus()
                Exit Sub
            ElseIf Mid(txtDateFrom.Text, 7) = Mid(txtDateTo.Text, 7) Then
                If Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) > Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    MsgBox("Issue Date: End Date < Start date ! (MM)")
                    'txtDateFm.SetFocus()
                    Exit Sub
                ElseIf Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) = Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    If Mid(txtDateFrom.Text, 4, 2) > Mid(txtDateTo.Text, 4, 2) Then
                        MsgBox("Issue Date: End Date < Start date ! (DD)")
                        'txtDateFm.SetFocus()
                        Exit Sub
                    End If
                End If
            End If
        End If


        ' Validation S/C No ------------------------------------

        If txtSCFm.Text > txtSCTo.Text Then
            MsgBox("S/C No. : From > To !")
            Exit Sub
        End If

        If txtSCFm.Text = "" And txtSCTo.Text <> "" Then
            MsgBox("S/C No. Empty (From) !")
            Exit Sub
        End If

        If txtSCFm.Text <> "" And txtSCTo.Text = "" Then
            MsgBox("S/C No. Empty (To) !")
            Exit Sub
        End If


        ' Validation Customer Code ------------------------------------
        If cboCustNoFm.Text > cboCustNoTo.Text Then
            MsgBox("Customer : From > To !")
            ' cboCustNoFm.SetFocus()
            Exit Sub
        End If

        If cboCustNoFm.Text = "" And cboCustNoTo.Text <> "" Then
            MsgBox("Customer Code Empty (From) !")
            ' cboCustNoFm.SetFocus()
            Exit Sub
        End If

        If cboCustNoFm.Text <> "" And cboCustNoTo.Text = "" Then
            MsgBox("Customer Code Empty (To) !")
            ' cboCustNoFm.SetFocus()
            Exit Sub
        End If


        '-------------------------------------------------

        'If cboSIStatus = "" Then
        '    MsgBox("Please Select the Invoice Status!")
        '    cboSIStatus.SetFocus()
        '    Exit Sub
        'End If




        ' Set Issue Date value to empty then there is "  /  /    "
        Dim IDF As String
        Dim IDT As String

        If Trim(txtDateFrom.Text) = Trim("  /  /    ") Then
            IDF = ""

        Else
            IDF = txtDateFrom.Text
        End If

        If Trim(txtDateTo.Text) = Trim("  /  /    ") Then
            IDT = ""
        Else
            IDT = txtDateTo.Text + " 23:59:59.990"
        End If


        Dim SDF As String
        Dim SDT As String


        If Trim(DtShpStr.Text) = Trim("  /  /    ") Then
            SDF = ""

        Else
            SDF = DtShpStr.Text
        End If

        If Trim(DtShpEnd.Text) = Trim("  /  /    ") Then
            SDT = ""

        Else
            SDT = DtShpEnd.Text + " 23:59:59.990"
        End If



        ' Customer No --------------------------------------
        Dim CNF As String
        Dim cnt As String

        If cboCustNoFm.Text = "" Then
            CNF = ""
        Else
            CNF = Split(cboCustNoFm.Text, " - ")(0)
        End If

        If cboCustNoTo.Text = "" Then
            cnt = ""
        Else
            cnt = Split(cboCustNoTo.Text, " - ")(0)
        End If


        Dim CNF2 As String
        Dim cnt2 As String

        If cboCustNo2Fm.Text = "" Then
            CNF2 = ""
        Else
            CNF2 = Split(cboCustNo2Fm.Text, " - ")(0)
        End If

        If cboCustNo2To.Text = "" Then
            cnt2 = ""
        Else
            cnt2 = Split(cboCustNo2To.Text, " - ")(0)
        End If

        Dim PayTrm As String
        Dim PRINTAMT As String

        If OptPayY.Checked = True Then
            PayTrm = "Y"
        Else
            PayTrm = "N"
        End If

        If optPrintAmtY.Checked = True Then
            PRINTAMT = "Y"
        Else
            PRINTAMT = "N"
        End If


        Dim sort As String
        If OptCust.Checked = True Then
            sort = "Customer Name"
        ElseIf OptSC.Checked = True Then
            sort = "SC No."
        Else
            sort = "Ship Date"
        End If

        Dim RptType As String
        If cboReportType.Text = "Cystal Report Format" Then
            RptType = "REPORT"
        Else
            RptType = "EXCEL"
        End If



        gspStr = "temp_sp_select_MSR00019 '" & cboCoCde.Text & _
        "','" & txtSCFm.Text & "','" & txtSCTo.Text & _
            "','" & IDF & "','" & IDT & _
            "','" & CNF & "','" & cnt & _
            "','" & CNF2 & "','" & cnt2 & _
            "','" & PayTrm & _
            "','" & PRINTAMT & _
            "','" & SDF & "','" & SDT & "','" & sort & _
            "','" & Split(cboScStatus.Text, " - ")(0) & "','" & RptType & "','" & gsUsrID & "'"

        'gspStr = "sp_select_MSR00019  'UCP','','','09/09/2013',''12/01/2013','50001','59999','','','N','N','03/01/2000','12/01/2013','SC No.','ALL','','mis'"

        'gspStr = "sp_select_MSR00019 'UCP','50000','59999','','','','','','','','','03/01/2009','03/01/2013','ALL','','mis'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_MSR00019, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00019 : " & rtnStr)
            Exit Sub
        End If

        If RptType = "EXCEL" Then
            Call CmdExportExcel_Click()
            Exit Sub
        End If


        If rs_MSR00019.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("MSR00019 No Record!")
            Exit Sub
        Else

            '************Sorting***********************
            ' ''If OptCust.Value = True Then
            ' ''    rs_MSR00019.sort = "Pri_Cust,Sec_Cust"
            ' ''Else
            ' ''    rs_MSR00019.sort = "sih_invno"
            ' ''End If


            'If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
            '    ReportName(0) = "MSR00019.rpt"
            'Else
            '    ReportName(0) = "MSR00019B.rpt"
            'End If


            'ReportRS(0) = rs_MSR00019
            'frmReport.Show()

            Dim objRpt As New MSR00019Rpt
            objRpt.SetDataSource(rs_MSR00019.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()



        End If



        Me.Cursor = Windows.Forms.Cursors.Default


    End Sub

    Private Sub cboCoCde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoCde.KeyUp

        Call auto_search_combo(cboCoCde, e.KeyCode)

    End Sub





    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        Call cboCoCdeClick()
    End Sub

    Private Sub cboCoCde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.LostFocus

    End Sub
    Private Sub cboCoCdeClick()
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Call getDefault_Path()

    End Sub
    Public Function ChangeCompany(ByVal CoCde As String, ByVal FormName As String) As String
        Dim dr() As DataRow

        ChangeCompany = ""
        gsCompany = CoCde

        dr = rs_SYCOMINF_NAME.Tables("RESULT").Select("yco_cocde = '" & gsCompany & "'")
        If Not dr.Length > 0 Then
            'MsgBox("Invalid Company Name")
            If cboCoCde.Text.Trim = "UC-G" Then
                ChangeCompany = "UNITED CHINESE GROUP"
            End If

        Else
            ChangeCompany = dr(0)("yco_conam").ToString
        End If
        Call Update_gs_Value(gsCompany)
        Call AccessRight(FormName)
    End Function



    'Public Function ChangeCompany(ByVal CoCde As String, ByVal FormName As String) As String
    '    Dim dr() As DataRow

    '    ChangeCompany = ""
    '    gsCompany = CoCde

    '    dr = rs_SYCOMINF_NAME.Tables("RESULT").Select("yco_cocde = '" & gsCompany & "'")
    '    If Not dr.Length > 0 Then
    '        'MsgBox("Invalid Company Name")
    '    Else
    '        ChangeCompany = dr(0)("yco_conam").ToString
    '    End If
    '    Call Update_gs_Value(gsCompany)
    '    Call AccessRight(FormName)
    'End Function


    Private Sub MSR00019_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.Width = 760
        '        Me.Height = 516

        cboReportType.Items.Clear()
        cboReportType.Items.Add("Cystal Report Format")
        cboReportType.Items.Add("Excel")



        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If


        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        '        cboCoCde.Items.Add("ALL")
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        'Fill in Customer No and Vendor No
        Cursor = Cursors.WaitCursor

        cboCoCde.Text = "ALL"

        gspStr = "sp_list_CUBASINF '" & cboCoCde.Text & "','PA'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00007_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Cursor = Cursors.WaitCursor

        gspStr = "sp_list_VNBASINF '" & cboCoCde.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00007_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        Call FillcboCust()
        '        Call FillcboCust2()
        cboReportType.Text = "Cystal Report Format"
        cboCustNo2Fm.Text = ""
        cboCustNo2To.Text = ""


        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        '*************Default****************
        '*** Multi-Company Name Display.

        '''Call FillCompCombo(gsUsrID, Me)

        '*** ADD PRINT ALL COMPANY ***
        ' 2004/02/11
        'Lester Wu 2005-04-04, replace ALL with UC-G, not show UC-G to MS company's users
        If gsDefaultCompany <> "MS" Then
            'Me.cboCoCde.Items.Add "ALL"
            Me.cboCoCde.Items.Add("UC-G")
        End If
        '*****************************
        '''Call GetDefaultCompany(Me)

        Call Formstartup(Me.Name)

        ''''''''''''''''''''
        Dim S As String
        Dim rs As New DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'S = "㊣CUBASINF','L','PA"

        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)


        'If rs.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then  '*** An error has occured
        '    MsgBox(rs.Tables("RESULT").Rows(0).Item(0).ToString)
        'Else
        '    rs_CUBASINF = rs.Copy
        '    '''should  copy row one
        '    ''' 
        '    Call FillcboCust()
        'End If


        Dim s2 As String
        Dim rs2 As New DataSet

        's2 = "㊣VNBASINF','L"

        'rs2 = objBSGate.Enquire(gsConnStr, "sp_general", s2)

        'If rs2.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then  '*** An error has occured
        '    MsgBox(rs2.Tables("RESULT").Rows(0).Item(0).ToString)
        'Else
        '    rs_VNBASINF = rs2.Copy
        '    ''shoyuld copy row one only

        '    '''Call FillcboVenCde()
        'End If


        'Dim S3 As String
        'Dim rs3 As New DataSet

        'S3 = "㊣SYSETINF','L"

        'rs3 = objBSGate.Enquire(gsConnStr, "sp_general", S3)

        'If rs3.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then
        '    MsgBox(rs3.Tables("RESULT").Rows(0).Item(0).ToString)
        'Else
        '    rs_SYSETINF = rs3.Copy
        '    '''shoyuld ciopy row one only

        '    Call FillcboVenSubCde()
        'End If

        cboScStatus.Items.Add("ALL - All Status")

        cboScStatus.Items.Add("ACT - Active")
        cboScStatus.Items.Add("HLD - Waiting for Approval")
        cboScStatus.Items.Add("REL - Released")
        cboScStatus.Items.Add("CAN - Cancel")
        cboScStatus.Items.Add("CLO - Close")

        cboScStatus.SelectedIndex = 0


        If ((gsUsrGrp = "SAL-ZE") Or (gsUsrGrp = "SAL-ZG")) Then
            optPrintAmtN.Checked = True
            optPrintAmtY.Enabled = False
            optPrintAmtN.Enabled = False
        Else
            optPrintAmtY.Checked = True
            optPrintAmtY.Enabled = False
            optPrintAmtN.Enabled = False
        End If





        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub



    ' ''Private Sub FillcboCust()
    ' ''    If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
    ' ''        dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '60000'")

    ' ''        For i As Integer = 0 To dr.Length - 1
    ' ''            cboCustNoFm.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
    ' ''            cboCustNoTo.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
    ' ''        Next

    ' ''        cboCustNoFm.SelectedIndex = 0
    ' ''        cboCustNoTo.SelectedIndex = cboCustNoTo.Items.Count - 1
    ' ''    End If

    ' ''End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub

    Private Sub txtDateFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.LostFocus

        txtDateTo.Text = txtDateFrom.Text
        txtDateTo.Focus()
        txtDateTo.SelectAll()


    End Sub

    Private Sub DtShpStr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtShpStr.LostFocus

        DtShpEnd.Text = DtShpStr.Text
        DtShpEnd.Focus()
        DtShpEnd.SelectAll()

    End Sub

    Private Sub DtShpStr_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles DtShpStr.MaskInputRejected

    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub DtShpEnd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtShpEnd.GotFocus
        DtShpEnd.SelectAll()

    End Sub

    Private Sub DtShpEnd_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles DtShpEnd.MaskInputRejected

    End Sub







    Private Sub CmdExportExcel_Click()

        On Error GoTo Err_Handler

        Cursor = Cursors.WaitCursor


        If rs_MSR00019.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Record not found!")
            Cursor = Cursors.Default
            Exit Sub
        End If


        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        '        Dim recArray As Object

        Dim fldCount As Integer
        Dim recCount As Long
        Dim iCol As Integer
        Dim iRow As Integer

        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True

        xlWs.Cells(1, 1) = "S/C No."
        xlWs.Cells(1, 2) = "Status"
        xlWs.Cells(1, 3) = "Version No."
        xlWs.Cells(1, 4) = "Pri Cust No."
        xlWs.Cells(1, 5) = "Primary Customer"
        xlWs.Cells(1, 6) = "Sec Cust No."
        xlWs.Cells(1, 7) = "Secondary Customer"
        xlWs.Cells(1, 8) = "Customer PO No."
        xlWs.Cells(1, 9) = "Issue Date"
        xlWs.Cells(1, 10) = "Customer PO Date"
        xlWs.Cells(1, 11) = "Payment Term"
        xlWs.Cells(1, 12) = "Ship Start & End Date"
        xlWs.Cells(1, 13) = "Currency"
        xlWs.Cells(1, 14) = "Total Amount"
        xlWs.Cells(1, 15) = "Total Cube (CBM)"
        xlWs.Cells(1, 16) = "Total Carton"
        xlWs.Cells(1, 17) = "Main Ship Mark"
        xlWs.Cells(1, 18) = "Side Ship Mark"
        xlWs.Cells(1, 19) = "Inner Ship Mark"
        xlWs.Cells(1, 20) = "Contact Person"

        xlWs.Rows(1).Font.Bold = True

        xlWs.Range(xlWs.Cells(2, 1), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 1)).NumberFormat = "@"


        xlWs.Range(xlWs.Cells(2, 4), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 4)).NumberFormat = "@"

        xlWs.Range(xlWs.Cells(2, 8), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 10)).NumberFormat = "@"
        xlWs.Range(xlWs.Cells(2, 8), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 10)).HorizontalAlignment = 2

        For col As Integer = 0 To rs_MSR00019.Tables("RESULT").Columns.Count - 1
            For row As Integer = 0 To rs_MSR00019.Tables("RESULT").Rows.Count - 1
                xlWs.Cells(row + 1 + 1, col + 1 - 0) = rs_MSR00019.Tables("RESULT").Rows(row).ItemArray(col)

            Next

        Next

        xlWs.Range(xlWs.Cells(2, 1), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 1)).NumberFormat = "@"


        xlWs.Range(xlWs.Cells(2, 4), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 4)).NumberFormat = "@"

        '        xlWs.Range(xlWs.Cells(2, 8), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 10)).NumberFormat = "@"
        xlWs.Range(xlWs.Cells(2, 8), xlWs.Cells(rs_MSR00019.Tables("RESULT").Rows.Count + 1, 10)).HorizontalAlignment = 2



        xlWs.Cells.EntireColumn.AutoFit()

        '        xlWs.Range("A1:E1").Columns.AutoFit()



        '        // Copy the values from a DataTable to an Excel Sheet (cell-by-cell)
        'for (int col = 0; col < dataTable.Columns.Count; col++)
        '{
        '    for (int row = 0; row < dataTable.Rows.Count; row++)
        '    {
        '        excelSheet.Cells[row + 1, col + 1] = 
        '                dataTable.Rows[row].ItemArray[col];
        '    }
        '}


        ' ''fldCount = rs_MSR00019.Tables("RESULT").Rows.Count

        ' ''For iCol = 1 To fldCount

        ' ''    ''Just input the names here

        ' ''    ''            xlWs.Cells(1, iCol).Value = rs_MSR00019.Fields(iCol - 1).Name
        ' ''    xlWs.Rows(1).Font.Bold = True
        ' ''    xlWs.Rows(1).Font.Size = 10
        ' ''    xlWs.Rows(1).Font.Underline = True
        ' ''Next

        ' ''If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then
        ' ''    xlWs.Cells(2, 1).CopyFromRecordset(rs_MSR00019)
        ' ''Else

        ' ''    MsgBox("This Option only works with EXCEL 2000 or 2002.", vbExclamation)
        ' ''    'recArray = rs_MSR00019.GetRows


        ' ''    Dim recArray(rs_MSR00019.Tables("RESULT").Rows.Count - 1, rs_MSR00019.Tables("RESULT").Columns.Count - 1) As String '(row,col)
        ' ''    For intRow As Integer = 0 To rs_MSR00019.Tables("RESULT").Rows.Count - 1
        ' ''        For intCol As Integer = 0 To rs_MSR00019.Tables("RESULT").Columns.Count - 1
        ' ''            recArray(intRow, intCol) = CStr(rs_MSR00019.Tables("RESULT").Rows(intRow).Item(intCol))
        ' ''        Next intCol
        ' ''    Next intRow


        ' ''    recCount = UBound(recArray, 2) + 1 '+ 1 since 0-based array
        ' ''    For iCol = 0 To fldCount - 1
        ' ''        For iRow = 0 To recCount - 1
        ' ''            If IsDate(recArray(iCol, iRow)) Then
        ' ''                recArray(iCol, iRow) = Format(recArray(iCol, iRow))
        ' ''            ElseIf IsArray(recArray(iCol, iRow)) Then
        ' ''                recArray(iCol, iRow) = "Array Field"
        ' ''            End If
        ' ''        Next iRow 'next record
        ' ''    Next iCol 'next field

        ' ''    xlWs.Cells(2, 1).resize(recCount, fldCount).Value = recArray

        ' ''End If

        xlApp.Selection.CurrentRegion.Columns.AutoFit()
        xlApp.Selection.CurrentRegion.rows.AutoFit()

        xlWs.Rows(1).RowHeight = 25

        rs_MSR00019 = Nothing


        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        'With Screen
        '  Me.Move (.width - width) \ 2, (.Height - Height) \ 2
        'End With

        Cursor = Cursors.Default

        Exit Sub

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If

        Cursor = Cursors.Default


        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        rs_MSR00019 = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub

    Private Sub cboCustNoFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoFm.KeyUp
        Call auto_search_combo(cboCustNoFm, e.KeyCode)
    End Sub

    Private Sub cboCustNoFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoFm.LostFocus

        cboCustNoTo.Text = cboCustNoFm.Text


    End Sub




    Private Sub cboCustNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SelectedIndexChanged

        Call FillcboCust2()

    End Sub

    Private Sub cboCustNoTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoTo.GotFocus

        cboCustNoTo.SelectAll()


    End Sub

    Private Sub cboCustNoTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoTo.KeyUp
        Call auto_search_combo(cboCustNoTo, e.KeyCode)

    End Sub

    Private Sub cboCustNoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoTo.SelectedIndexChanged

    End Sub

    Private Sub cboCustNo2Fm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNo2Fm.KeyUp
        Call auto_search_combo(cboCustNo2Fm, e.KeyCode)

    End Sub

    Private Sub cboCustNo2Fm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNo2Fm.SelectedIndexChanged

    End Sub

    Private Sub cboCustNo2To_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNo2To.KeyUp
        Call auto_search_combo(cboCustNo2To, e.KeyCode)
    End Sub

    Private Sub cboCustNo2To_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNo2To.SelectedIndexChanged

    End Sub

    Private Sub cboScStatus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboScStatus.KeyUp
        Call auto_search_combo(cboScStatus, e.KeyCode)
    End Sub

    Private Sub cboScStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScStatus.SelectedIndexChanged

    End Sub

    Private Sub cboReportType_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboReportType.KeyUp
        Call auto_search_combo(cboReportType, e.KeyCode)
    End Sub

    Private Sub cboReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportType.SelectedIndexChanged

    End Sub

    Private Sub txtDateTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateTo.GotFocus
        txtDateTo.SelectAll()

    End Sub

    Private Sub txtDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateTo.MaskInputRejected

    End Sub

    Private Sub grpSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpSearch.Enter

    End Sub

    Private Sub Label18_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub OptShpDat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptShpDat.CheckedChanged

    End Sub
End Class



''Public Class MSR00019

''    Dim rs_VNBASINF As DataSet
''    Dim rs_CUBASINF As DataSet

''    Private Sub MSR00032_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
''        Formstartup(Me.Name)

''        loadComboBox()

''        GetDefaultCompany(cboCoCde, txtCoNam)
''    End Sub

''    Private Sub loadComboBox()
''        FillCompCombo(gsUsrID, cboCoCde)
''        cboCoCde.Items.Add("UC-G")

''        gspStr = "sp_list_VNBASINF ''"
''        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
''        If rtnLong <> RC_SUCCESS Then
''            MsgBox("Error on loading IMR00017_Load #001 sp_list_VNBASINF_vensna :" & rtnStr)
''        End If

''        format_cboVen()

''    End Sub

''    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

''    End Sub

''    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
''        If cboCoCde.Text <> "UC-G" Then
''            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
''        Else
''            txtCoNam.Text = "UNITED CHINESE GROUP"
''        End If
''    End Sub

''    Private Sub format_cboVen()
''        cboVenFm.Items.Items.Clear()
''        cboVenTo.Items.Items.Clear()

''        cboVenFm.Items.Add("")
''        cboVenTo.Items.Add("")

''        For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
''            cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
''            cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
''        Next
''    End Sub
''End Class