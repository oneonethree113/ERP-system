Public Class MSR00020


    Public rs_CUBASINF As DataSet
    Public rs_MSR00020 As DataSet
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
            '    ''txtDateFrom.SetFocus()
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
                ''txtDateFrom.SetFocus()
                Exit Sub
            ElseIf Mid(txtDateFrom.Text, 7) = Mid(txtDateTo.Text, 7) Then
                If Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) > Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    MsgBox("Issue Date: End Date < Start date ! (MM)")
                    ''txtDateFrom.SetFocus()
                    Exit Sub
                ElseIf Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) = Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    If Mid(txtDateFrom.Text, 4, 2) > Mid(txtDateTo.Text, 4, 2) Then
                        MsgBox("Issue Date: End Date < Start date ! (DD)")
                        ''txtDateFrom.SetFocus()
                        Exit Sub
                    End If
                End If
            End If
        End If


        ' Validation S/C No ------------------------------------

        If txtPOFm.Text > txtPOTo.Text Then
            MsgBox("S/C No. : From > To !")
            Exit Sub
        End If

        If txtPOFm.Text = "" And txtPOTo.Text <> "" Then
            MsgBox("S/C No. Empty (From) !")
            Exit Sub
        End If

        If txtPOFm.Text <> "" And txtPOTo.Text = "" Then
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

        If cboPOStatus.Text = "" Then
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

        If cboPOStatus.Text <> "" Then
            status = Split(cboPOStatus.Text, " - ")(0)
        End If

        If status = "ALL" Then
            status = ""
        End If

        'Dim sort As String
        'If OptCust.Checked = True Then
        '    sort = "Customer"
        'Else
        '    sort = "S/C No."
        'End If

        Dim S As String
        Dim rs As New DataSet
        Me.Cursor = Windows.Forms.Cursors.WaitCursor




        'S = "㊣MSR00020','S','" & _
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

        'rs_MSR00020 = rs.Copy
        ' ''should copy only row one

        'If rs_MSR00020.Tables("RESULT").Rows.Count = 0 Then
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    '                msg("M00071")
        '    Exit Sub
        'Else

        '    '************Sorting***********************
        '    If OptCust.Checked = True Then
        '        rs_MSR00020.Tables("RESULT").DefaultView.Sort = "Pri_Cust,Sec_Cust"
        '    Else
        '        rs_MSR00020.Tables("RESULT").DefaultView.Sort = "sih_invno"
        '    End If


        '    If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
        '        '''ReportName(0) = "MSR00020.rpt"
        '    Else
        '        '''ReportName(0) = "MSR00020B.rpt"
        '    End If


        '    '''ReportRS(0) = rs_MSR00020
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




    Private Sub txtDateFrom_Change()
        txtDateTo.Text = txtDateFrom.Text
    End Sub

    Private Sub txtFromItmno_Change()
        txtPOTo.Text = txtPOFm.Text
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

        'If Not IsDate(txtDateFrom.Text) Then
        '    MsgBox(" Issue Date Invalid (From) !")
        '    Exit Sub
        'End If

        'If Not IsDate(txtDateTo.Text) Then
        '    MsgBox(" Issue Date Invalid (To) !")
        '    Exit Sub
        'End If



        If Trim(txtDateFrom.Text) <> Trim("  /  /    ") Then
            If CheckDate(txtDateFrom.Text) = False Then
                MsgBox("Issue Date invalid !")
                txtDateFrom.Focus()

                Exit Sub
            End If
        End If

        If Trim(txtDateTo.Text) <> Trim("  /  /    ") Then
            If CheckDate(txtDateTo.Text) = False Then
                MsgBox("Issue Date invalid !")
                txtDateTo.Focus()

                Exit Sub
            End If
        End If


        If Trim(DtShpStr.Text) <> Trim("  /  /    ") Then
            If CheckDate(DtShpStr.Text) = False Then
                MsgBox("Issue Date invalid !")
                DtShpStr.Focus()

                Exit Sub
            End If
        End If

        If Trim(DtShpEnd.Text) <> Trim("  /  /    ") Then
            If CheckDate(DtShpEnd.Text) = False Then
                MsgBox("Issue Date invalid !")
                DtShpEnd.Focus()

                Exit Sub
            End If
        End If

        'If txtDateFrom.Text <> "  /  /    " Then
        '    If CheckDate(txtDateFrom.Text) = False Then
        '    MsgBox ("Issue Date invalid !")
        '        ''txtDateFrom.SetFocus()
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
                ''txtDateFrom.SetFocus()
                Exit Sub
            ElseIf Mid(txtDateFrom.Text, 7) = Mid(txtDateTo.Text, 7) Then
                If Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) > Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    MsgBox("Issue Date: End Date < Start date ! (MM)")
                    ''txtDateFrom.SetFocus()
                    Exit Sub
                ElseIf Microsoft.VisualBasic.Left(txtDateFrom.Text, 2) = Microsoft.VisualBasic.Left(txtDateTo.Text, 2) Then
                    If Mid(txtDateFrom.Text, 4, 2) > Mid(txtDateTo.Text, 4, 2) Then
                        MsgBox("Issue Date: End Date < Start date ! (DD)")
                        ''txtDateFrom.SetFocus()
                        Exit Sub
                    End If
                End If
            End If
        End If


        ' Validation S/C No ------------------------------------

        If txtPOFm.Text > txtPOTo.Text Then
            MsgBox("S/C No. : From > To !")
            Exit Sub
        End If

        If txtPOFm.Text = "" And txtPOTo.Text <> "" Then
            MsgBox("S/C No. Empty (From) !")
            Exit Sub
        End If

        If txtPOFm.Text <> "" And txtPOTo.Text = "" Then
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
            IDF = txtDateFrom.Text + " 00:00:00.000"
        End If

        If Trim(txtDateTo.Text) = Trim("  /  /    ") Then
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


        'Dim CNF2 As String
        'Dim cnt2 As String

        'If cboCustNo2Fm.Text = "" Then
        '    CNF2 = ""
        'Else
        '    CNF2 = Split(cboCustNo2Fm.Text, " - ")(0)
        'End If

        'If cboCustNo2To.Text = "" Then
        '    cnt2 = ""
        'Else
        '    cnt2 = Split(cboCustNo2To.Text, " - ")(0)
        'End If

        'Dim PayTrm As String
        'Dim PRINTAMT As String

        'If OptPayY.Checked = True Then
        '    PayTrm = "Y"
        'Else
        '    PayTrm = "N"
        'End If

        'If optPrintAmtY.Checked = True Then
        '    PRINTAMT = "Y"
        'Else
        '    PRINTAMT = "N"
        'End If


        'Dim sort As String
        'If OptCust.Checked = True Then
        '    sort = "Customer"
        'ElseIf OptSC.Checked = True Then
        '    sort = "SC No."
        'Else
        '    sort = "Ship Date"
        'End If

        'Dim RptType As String
        'If cboReportType.Text = "Cystal Report Format" Then
        '    RptType = "REPORT"
        'Else
        '    RptType = "EXCEL"
        'End If


        '''''''''''''''''''
        '    txtPOFm.Text = UCase(txtPOFm.Text)
        '    txtPOTo.Text = UCase(txtPOTo.Text)

        ' Vendor Validation ---
        If cboCustNoFm.Text = "" And cboCustNoTo.Text = "" And cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And txtPOFm.Text = "" And txtPOTo.Text = "" And txtDateFrom.Text = "  /  /    " And txtDateTo.Text = "  /  /    " And DtShpStr.Text = "  /  /    " And DtShpEnd.Text = "  /  /    " Then
            MsgBox("Have not any data input !")
            Exit Sub
        End If

        ''Lester Wu 2004/02/05 XXXXXXXX
        'If (ValidateCombo(Me.cboCustNoFm) = False) Then
        '    Exit Sub
        'End If
        'If (ValidateCombo(Me.cboCustNoTo) = False) Then
        '    Exit Sub
        'End If
        'If (ValidateCombo(Me.cboVenCdeFm) = False) Then
        '    Exit Sub
        'End If
        'If (ValidateCombo(Me.cboVenCdeTo) = False) Then
        '    Exit Sub
        'End If

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


        '-------------------------------------------------


        ' Validation ------------------------------------

        If cboVenCdeFm.Text > cboVenCdeTo.Text Then
            MsgBox("Vendor : From > To !")
            Exit Sub
        End If

        If txtPOFm.Text > txtPOTo.Text Then
            MsgBox("P/O No. : From > To !")
            Exit Sub
        End If

        ''Issue Date Validation ---
        'If txtDateFrom.Text <> "  /  /    " Then
        '    If CheckDate(txtDateFrom.Text) = False Then
        '        MsgBox("Issue Date invalid !")
        '        'txtDateFrom.SetFocus()
        '        Exit Sub
        '    End If
        'End If

        'If txtDateTo.Text <> "  /  /    " Then
        '    If CheckDate(txtDateTo.Text) = False Then
        '        MsgBox("Issue Date invalid !")
        '        txtDateTo.SetFocus()
        '        Exit Sub
        '    End If
        'End If

        'If txtDateFrom.Text <> "  /  /    " And txtDateTo.Text <> "  /  /    " Then
        '    If Mid(txtDateFrom.Text, 7) > Mid(txtDateTo.Text, 7) Then
        '        MsgBox("Issue Date: End Date < Start date ! (YY)")
        '        'txtDateFrom.SetFocus()
        '        Exit Sub
        '    ElseIf Mid(txtDateFrom.Text, 7) = Mid(txtDateTo.Text, 7) Then
        '        If Left(txtDateFrom.Text, 2) > Left(txtDateTo.Text, 2) Then
        '            MsgBox("Issue Date: End Date < Start date ! (MM)")
        '            'txtDateFrom.SetFocus()
        '            Exit Sub
        '        ElseIf Left(txtDateFrom.Text, 2) = Left(txtDateTo.Text, 2) Then
        '            If Mid(txtDateFrom.Text, 4, 2) > Mid(txtDateTo.Text, 4, 2) Then
        '                MsgBox("Issue Date: End Date < Start date ! (DD)")
        '                'txtDateFrom.SetFocus()
        '                Exit Sub
        '            End If
        '        End If
        '    End If
        'End If



        ''Ship Date Validation ---
        'If DtShpStr.Text <> "  /  /    " Then
        '    If CheckDate(DtShpStr.Text) = False Then
        '        MsgBox("Ship Date invalid !")
        '        'DtShpStr.SetFocus()
        '        Exit Sub
        '    End If
        'End If

        'If DtShpEnd.Text <> "  /  /    " Then
        '    If CheckDate(DtShpEnd.Text) = False Then
        '        MsgBox("Ship Date invalid !")
        '        'DtShpEnd.SetFocus()
        '        Exit Sub
        '    End If
        'End If

        'If DtShpStr.Text <> "  /  /    " And DtShpEnd.Text <> "  /  /    " Then
        '    If Mid(DtShpStr.Text, 7) > Mid(DtShpEnd.Text, 7) Then
        '        MsgBox("Ship Date: End Date < Start date ! (YY)")
        '        'DtShpStr.SetFocus()
        '        Exit Sub
        '    ElseIf Mid(DtShpStr.Text, 7) = Mid(DtShpEnd.Text, 7) Then
        '        If Left(DtShpStr.Text, 2) > Left(DtShpEnd.Text, 2) Then
        '            MsgBox("Ship Date: End Date < Start date ! (MM)")
        '            'DtShpStr.SetFocus()
        '            Exit Sub
        '        ElseIf Left(DtShpStr.Text, 2) = Left(DtShpEnd.Text, 2) Then
        '            If Mid(DtShpStr.Text, 4, 2) > Mid(DtShpEnd.Text, 4, 2) Then
        '                MsgBox("Ship Date: End Date < Start date ! (DD)")
        '                'DtShpStr.SetFocus()
        '                Exit Sub
        '            End If
        '        End If
        '    End If
        'End If





        ' Set Vendor Code value to empty then there is "  /  /    "
        Dim VNF As String
        Dim VNT As String

        If cboVenCdeFm.Text = "" Then
            VNF = ""
        Else
            VNF = Split(cboVenCdeFm.Text, " - ")(0)
        End If

        If cboVenCdeTo.Text = "" Then
            VNT = ""
        Else
            VNT = Split(cboVenCdeTo.Text, " - ")(0)
        End If


        ' Set Issue Date value to empty then there is "  /  /    "
        'Dim IDF As String
        'Dim IDT As String


        If Trim(txtDateFrom.Text) = Trim("  /  /    ") Then
            IDF = ""

        Else
            IDF = txtDateFrom.Text + " 00:00:00.000"
        End If

        If Trim(txtDateTo.Text) = Trim("  /  /    ") Then
            IDT = ""

        Else
            IDT = txtDateTo.Text + " 23:59:59.990"
        End If



        ' Set Ship Date value to empty then there is "  /  /    "
        Dim SDF As String
        Dim SDT As String


        If Trim(DtShpStr.Text) = Trim("  /  /    ") Then
            SDF = ""

        Else
            SDF = DtShpStr.Text + " 00:00:00.000"
        End If

        If Trim(DtShpEnd.Text) = Trim("  /  /    ") Then
            SDT = ""

        Else
            SDT = DtShpEnd.Text + " 23:59:59.000"
        End If

        'XXXXXXXXXXX Lester Wu 2004/02/05 XXXXXXXXXXXXXXXXX
        Dim CUF As String
        Dim CUT As String

        If cboCustNoFm.Text = "" Then
            CUF = ""
        Else
            CUF = Split(cboCustNoFm.Text, " - ")(0)
        End If

        If cboCustNoTo.Text = "" Then
            CUT = ""
        Else
            CUT = Split(cboCustNoTo.Text, " - ")(0)
        End If

        Dim SORTBY As String
        Dim POstatus As String

        SORTBY = "P" 'PO No
        If Me.cboSortBy.SelectedIndex = 1 Then
            SORTBY = "C" 'Customer
        End If


        SORTBY = cboSortBy.Text

        POstatus = ""
        If InStr(Me.cboPOStatus.Text, "-") <> 0 Then
            POstatus = Trim(Split(Me.cboPOStatus.Text, "-")(0))
        End If

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


        '''''''''''''''''''
        If POstatus = "ALL" Then
            POstatus = ""
        End If
        gspStr = "temp_sp_select_MSR00020 '" & cboCoCde.Text & _
       "','" & VNF & "','" & VNT & _
       "','" & txtPOFm.Text & "','" & txtPOTo.Text & _
       "','" & IDF & "','" & IDT & _
       "','" & SDF & "','" & SDT & _
       "','" & CUF & "','" & CUT & _
       "','" & POstatus & "','" & SORTBY & _
       "','" & gsUsrID & "'"

        'gspStr = " sp_select_MSR00020   'UCP','','','','','03/01/2013 00:00:00.000','12/01/2013 23:59:59.999','03/01/2013 00:00:00.000','12/01/2013 23:59:59.000','50001','59999','','','mis'"


        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_MSR00020, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00020 : " & rtnStr)
            Exit Sub
        End If


        If rs_MSR00020.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Record not found!")
            Exit Sub
        Else

            '************Sorting***********************
            ' ''If OptCust.Value = True Then
            ' ''    rs_MSR00020.sort = "Pri_Cust,Sec_Cust"
            ' ''Else
            ' ''    rs_MSR00020.sort = "sih_invno"
            ' ''End If


            'If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
            '    ReportName(0) = "MSR00020.rpt"
            'Else
            '    ReportName(0) = "MSR00020B.rpt"
            'End If


            'ReportRS(0) = rs_MSR00020
            'frmReport.Show()

            Dim objRpt As New MSR00020Rpt
            objRpt.SetDataSource(rs_MSR00020.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()



        End If



        Me.Cursor = Windows.Forms.Cursors.Default


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


    Private Sub MSR00020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.Width = 760
        'Me.Height = 490


        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If


        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        'cboCoCde.Items.Add("ALL")
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
        Call FillcboVen()



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

        cboPOStatus.Items.Add("ALL - All Status")

        cboPOStatus.Items.Add("OPE - OPEN")
        cboPOStatus.Items.Add("REL - Released")
        cboPOStatus.Items.Add("CLO - Close")
        cboPOStatus.Items.Add("CAN - Cancelled")

        cboPOStatus.SelectedIndex = 0

        cboSortBy.Items.Add("PO No")
        cboSortBy.Items.Add("Customer")
        cboSortBy.SelectedIndex = 0




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

    Private Sub txtPOFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOFm.TextChanged

    End Sub

    Private Sub txtDateFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub cboVenCdeFm_Change()
        cboVenCdeTo.Text = cboVenCdeFm.Text
    End Sub

    Private Sub cboVenCdeFm_Click()
        cboVenCdeTo.Text = cboVenCdeFm.Text
    End Sub



    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenCdeFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboVenCdeTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            Next
        End If
    End Sub

    Private Sub txtDateFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.LostFocus
        Me.txtDateTo.Text = Me.txtDateFrom.Text
        txtDateTo.Focus()
        txtDateTo.SelectAll()

    End Sub
    Private Sub DtShpStr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtShpStr.LostFocus
        Me.DtShpEnd.Text = Me.DtShpStr.Text
        DtShpEnd.Focus()
        DtShpEnd.SelectAll()

    End Sub

    Public Function CheckDate(ByVal theDate As String) As Boolean
        Dim month%, day%, year%
        Dim mm$, dd$, yyyy$
        Dim valid As Boolean

        valid = True
        mm$ = Mid(theDate, 1, 2)
        dd$ = Mid(theDate, 4, 2)
        yyyy$ = Mid(theDate, 7, 4)

        If IsDate(theDate) = False Then
            valid = False
            GoTo result
        End If
        ' Only accept either all date fields filled or all date fields empty
        If Not ((mm$ = "  " And dd$ = "  " And yyyy$ = "    ") Or (mm$ <> "  " And dd$ <> "  " And yyyy$ <> "    ")) Then
            valid = False
            GoTo result
        End If

        month% = val(mm$)   ' Convert the date into numbers
        day% = val(dd$)
        year% = val(yyyy$)

        If month% > 12 Then    ' Check the month
            valid = False
            GoTo result
        End If
        If month% = 1 Or month% = 3 Or _
           month% = 5 Or month% = 7 Or _
           month% = 8 Or month% = 10 Or _
           month% = 12 Then             ' Check the day
            'If Date% > 31 Then
            If day% > 31 Then
                valid = False
                GoTo result
            End If
        End If
        If month% = 2 Or month% = 4 Or _
           month% = 6 Or month% = 9 Or _
           month% = 11 Then             ' Check the day
            'If Date% > 30 Then
            If day% > 30 Then
                valid = False
                GoTo result
            End If
        End If
        If month% = 2 And day% > 28 And _
           year% Mod 4 <> 0 Then ' Check the leap year
            valid = False
            GoTo result
        End If
        '*** Add to check Date is in valid year by Lewis on 15/04/2003 ********************
        If year% < 1950 Or year% > 2049 Then
            valid = False
            GoTo result
        End If
        '**********************************************************************************
result:
        CheckDate = valid
    End Function

    Private Sub txtDateTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateTo.GotFocus
        txtDateTo.SelectAll()

    End Sub

    Private Sub txtDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateTo.MaskInputRejected

    End Sub

    Private Sub DtShpEnd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtShpEnd.GotFocus
        DtShpEnd.SelectAll()

    End Sub

    Private Sub DtShpEnd_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles DtShpEnd.MaskInputRejected

    End Sub

    Private Sub cboCustNoFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoFm.KeyUp
        Call auto_search_combo(cboCustNoFm, e.KeyCode)

    End Sub

    Private Sub cboCustNoFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoFm.LostFocus
        cboCustNoTo.Text = cboCustNoFm.Text
    End Sub

    Private Sub cboCustNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SelectedIndexChanged

    End Sub

    Private Sub cboCustNoTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoTo.GotFocus
        cboCustNoTo.SelectAll()

    End Sub

    Private Sub cboCustNoTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoTo.KeyUp
        Call auto_search_combo(cboCustNoTo, e.KeyCode)
    End Sub

    Private Sub cboCustNoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoTo.SelectedIndexChanged

    End Sub

    Private Sub cboVenCdeFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenCdeFm.KeyUp
        Call auto_search_combo(cboVenCdeFm, e.KeyCode)
    End Sub

    Private Sub cboVenCdeFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCdeFm.SelectedIndexChanged

    End Sub

    Private Sub cboVenCdeTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenCdeTo.KeyUp
        Call auto_search_combo(cboVenCdeTo, e.KeyCode)
    End Sub

    Private Sub cboVenCdeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCdeTo.SelectedIndexChanged

    End Sub

    Private Sub cboPOStatus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPOStatus.KeyUp
        Call auto_search_combo(cboPOStatus, e.KeyCode)

    End Sub

    Private Sub cboPOStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPOStatus.SelectedIndexChanged

    End Sub

    Private Sub cboSortBy_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSortBy.KeyUp
        Call auto_search_combo(cboSortBy, e.KeyCode)
    End Sub

    Private Sub cboSortBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSortBy.SelectedIndexChanged

    End Sub

    Private Sub grpSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpSearch.Enter

    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub DtShpStr_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles DtShpStr.MaskInputRejected

    End Sub
End Class



''Public Class MSR00020

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
Partial Class dsMSR00020
End Class
