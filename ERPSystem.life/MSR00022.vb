Public Class MSR00022


    Public rs_CUBASINF As DataSet
    Public rs_MSR00022 As DataSet
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

        If Not IsDate(txtDateFrom.Text) Then
            MsgBox(" Issue Date Invalid (From) !")
            Exit Sub
        End If

        If Not IsDate(txtDateTo.Text) Then
            MsgBox(" Issue Date Invalid (To) !")
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




        '-------------------------------------------------



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
            IDT = txtDateTo.Text
        End If





        ' Customer No --------------------------------------
        Dim CNF As String
        Dim cnt As String



        'Dim sort As String
        'If OptCust.Checked = True Then
        '    sort = "Customer"
        'Else
        '    sort = "S/C No."
        'End If

        Dim S As String
        Dim rs As New DataSet
        Me.Cursor = Windows.Forms.Cursors.WaitCursor




        'S = "㊣MSR00022','S','" & _
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

        'rs_MSR00022 = rs.Copy
        ' ''should copy only row one

        'If rs_MSR00022.Tables("RESULT").Rows.Count = 0 Then
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    '                msg("M00071")
        '    Exit Sub
        'Else

        '    '************Sorting***********************
        '    If OptCust.Checked = True Then
        '        rs_MSR00022.Tables("RESULT").DefaultView.Sort = "Pri_Cust,Sec_Cust"
        '    Else
        '        rs_MSR00022.Tables("RESULT").DefaultView.Sort = "sih_invno"
        '    End If


        '    If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
        '        '''ReportName(0) = "MSR00022.rpt"
        '    Else
        '        '''ReportName(0) = "MSR00022B.rpt"
        '    End If


        '    '''ReportRS(0) = rs_MSR00022
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

        'If rs_CUBASINF Is Nothing Then
        '    Exit Sub
        'End If

        'If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
        '    dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '60000'")

        '    For i As Integer = 0 To dr.Length - 1
        '        cboCustNoFm.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
        '        cboCustNoTo.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
        '    Next

        '    cboCustNoFm.SelectedIndex = 0
        '    cboCustNoTo.SelectedIndex = cboCustNoTo.Items.Count - 1
        'End If
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


        '-------------------------------------------------

        'If cboSIStatus = "" Then
        '    MsgBox("Please Select the Invoice Status!")
        '    cboSIStatus.SetFocus()
        '    Exit Sub
        'End If




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
            IDT = txtDateTo.Text
        End If

        ' Customer No --------------------------------------
        Dim CNF As String
        Dim cnt As String




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


        If txtDateFrom.Text = "  /  /    " Then
            IDF = ""

        Else
            IDF = txtDateFrom.Text + " 00:00:00.000"
        End If

        If txtDateTo.Text = "  /  /    " Then
            IDT = ""

        Else
            IDT = txtDateTo.Text + " 23:59:59.990"
        End If



        ' Set Ship Date value to empty then there is "  /  /    "
        Dim SDF As String
        Dim SDT As String



        'XXXXXXXXXXX Lester Wu 2004/02/05 XXXXXXXXXXXXXXXXX
        Dim CUF As String
        Dim CUT As String


        Dim SORTBY As String
        Dim POstatus As String

        'SORTBY = "P" 'PO No
        'If Me.cboSortBy.ListIndex = 1 Then
        '    SORTBY = "C" 'Customer
        'End If


        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX




        'ReDim ReportName(0) As String
        'ReDim ReportRS(0) As ADOR.Recordset
        '        Dim VenFrom As String
        '        Dim VenTo As String

        '        If ValidateCombo(cboVenFrom) = False Then
        '            Exit Sub
        '        End If

        '        If ValidateCombo(cboVenTo) = False Then
        '            Exit Sub
        '        End If

        '        If cboVenFrom.Text = "" And cboVenTo.Text <> "" Then
        '            cboVenFrom.Text = cboVenTo.Text
        '        End If
        '        If cboVenTo.Text = "" And cboVenFrom.Text <> "" Then
        '            cboVenTo.Text = cboVenFrom.Text
        '        End If

        '        If txtDateFrom.Text = "  /  /    " And txtDateTo.Text <> "  /  /    " Then
        '            txtDateFrom.Text = "01/01/1900"
        '        End If
        '        If txtDateTo.Text = "  /  /    " And txtDateFrom.Text <> "  /  /    " Then
        '            txtDateTo.Text = txtDateFrom.Text
        '        End If

        '        VenFrom = cboVenFrom.Text
        '        VenTo = cboVenTo.Text

        '        If Len(Trim(VenFrom)) > 0 Then
        '            VenFrom = Split(cboVenFrom.Text, " - ")(0)
        '        Else
        '            VenFrom = ""
        '        End If

        '        If Len(Trim(VenTo)) > 0 Then
        '            VenTo = Split(cboVenTo.Text, " - ")(0)
        '        Else
        '            VenTo = ""
        '        End If

        '        If Not InputIsVaild Then
        '            Exit Sub
        '        End If

        '        Dim S As String
        '        Dim rs() As ADOR.Recordset
        '        Screen.MousePointer = vbHourglass

        '        S = "㊣MSR00022','S','" & VenFrom & _
        '            "','" & VenTo & _
        '            "','" & UCase(cboVenCdeFm.Text) & _
        '            "','" & UCase(cboVenCdeTo.Text) & _
        '            "','" & IIf(txtDateFrom.Text = "  /  /    " And txtDateTo.Text = "  /  /    ", "", Format(txtDateFrom.Text, "MM/DD/YYYY")) & _
        '            "','" & IIf(txtDateFrom.Text = "  /  /    " And txtDateTo.Text = "  /  /    ", "", Format(txtDateTo.Text, "MM/DD/YYYY")) & _
        '            "','" & IIf(optVendor.Value = True, "V", "P") & "','" & gsUsrID

        '        rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        '        If rs(0)(0) <> "0" Then
        '            MsgBox(rs(0)(0)) '*** An error has occured
        '        Else
        '            rs_MSR00022 = rs(1)
        '            If rs_MSR00022.recordCount = 0 Then
        '                Screen.MousePointer = vbDefault
        '                msg("M00071")
        '                Exit Sub
        '            Else

        '                ReportName(0) = "MSR00022.rpt"
        '                ReportRS(0) = rs_MSR00022

        '                frmReport.Show()

        '            End If
        '        End If

        '        Screen.MousePointer = vbDefault


        '''''''''''''''''''

        ' gspStr = "sp_select_MSR00022 '" & cboCoCde.Text & _
        '"','" & VNF & "','" & VNT & _
        '"','" & txtPOFm.Text & "','" & txtPOTo.Text & _
        '"','" & IDF & "','" & IDT & _
        '"','" & SDF & "','" & SDT & _
        '"','" & CUF & "','" & CUT & _
        '"','" & POstatus & "','" & SORTBY & _
        '"','" & gsUsrID

        ' gspStr = " sp_select_MSR00022   'UCP','','','','','03/01/2013 00:00:00.000','12/01/2013 23:59:59.999','03/01/2013 00:00:00.000','12/01/2013 23:59:59.000','50001','59999','','','mis'"

        Dim temp_date_from As String
        Dim temp_date_to As String
        temp_date_from = txtDateFrom.Text
        temp_date_to = txtDateTo.Text

        If Trim(temp_date_from) = Trim("/  /") Or Not IsDate(temp_date_from) Then
            temp_date_from = ""
        Else
            temp_date_from = temp_date_from
        End If

        If Trim(temp_date_to) = Trim("/  /") Or Not IsDate(temp_date_to) Then
            temp_date_to = ""
        Else
            temp_date_to = temp_date_to + " 23:59:59.990"
        End If


        gspStr = "temp_sp_select_MSR00022 '" & cboCoCde.Text & _
             "','" & VNF & _
            "','" & VNT & _
            "','" & UCase(txtPOFm.Text) & _
            "','" & UCase(txtPOTo.Text) & _
            "','" & temp_date_from & _
            "','" & temp_date_to & _
            "','" & IIf(optVendor.Checked = True, "V", "P") & "','" & gsUsrID & "'"


        'gspStr = "        sp_select_MSR00022  'UCP','','','','','03/01/2012 00:00:00.000','03/01/2013 23:59:59.999','V','mis'"


        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_MSR00022, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00022 : " & rtnStr)
            Exit Sub
        End If


        If rs_MSR00022.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("MSR00022")
            Exit Sub
        Else

            '************Sorting***********************
            ' ''If OptCust.Value = True Then
            ' ''    rs_MSR00022.sort = "Pri_Cust,Sec_Cust"
            ' ''Else
            ' ''    rs_MSR00022.sort = "sih_invno"
            ' ''End If


            'If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
            '    ReportName(0) = "MSR00022.rpt"
            'Else
            '    ReportName(0) = "MSR00022B.rpt"
            'End If


            'ReportRS(0) = rs_MSR00022
            'frmReport.Show()

            Dim objRpt As New MSR00022Rpt
            objRpt.SetDataSource(rs_MSR00022.Tables("RESULT"))

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


    Private Sub MSR00022_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Me.Width = 760
        'Me.Height = 372

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

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtPOFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOFm.TextChanged

    End Sub

    Private Sub txtDateFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub txtPOTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOTo.TextChanged

    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub cboVenCdeFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenCdeFm.KeyUp
        Call auto_search_combo(cboVenCdeFm, e.KeyCode)

    End Sub

    Private Sub cboVenCdeFm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenCdeFm.LostFocus
        cboVenCdeTo.Text = cboVenCdeFm.Text
        cboVenCdeTo.Focus()
        cboVenCdeTo.SelectAll()

    End Sub

    Private Sub cboVenCdeFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCdeFm.SelectedIndexChanged

    End Sub

    Private Sub cboVenCdeTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenCdeTo.KeyUp
        Call auto_search_combo(cboVenCdeTo, e.KeyCode)

    End Sub

    Private Sub cboVenCdeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCdeTo.SelectedIndexChanged

    End Sub
End Class



''Public Class MSR00022

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