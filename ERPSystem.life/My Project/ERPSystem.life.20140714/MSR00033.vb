Public Class MSR00033


    Public rs_CUBASINF As DataSet
    Public rs_MSR00033 As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As DataSet
    Public objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Public dr() As DataRow
    'Public rs_SYCOMINF_NAME As New DataSet

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


    Private Sub cboVenCdeFm_Change()
        cboVenCdeTo.Text = cboVenCdeFm.Text
        cboVenSubCdeFm.Text = ""
        cboVenSubCdeTo.Text = ""
    End Sub

    Private Sub cboVenCdeFm_Click()
        cboVenCdeTo.Text = cboVenCdeFm.Text
        Call DisplayVenSubCde()
    End Sub


    Private Sub cboVenCdeTo_Change()
        cboVenSubCdeFm.Text = ""
        cboVenSubCdeTo.Text = ""
        Call DisplayVenSubCde()
    End Sub

    Private Sub cboVenCdeTo_Click()
        cboVenSubCdeFm.Text = ""
        cboVenSubCdeTo.Text = ""
        Call DisplayVenSubCde()
    End Sub

    Private Sub cboVenTypFm_Change()
        cboVenTypTo.Text = cboVenTypFm.Text
    End Sub

    Private Sub cboVenTypFm_Click()
        cboVenTypTo.Text = cboVenTypFm.Text
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

        If txtSIFm.Text > txtSITo.Text Then
            MsgBox("Sample Invoice No. : From > To !")
            Exit Sub
        End If

        If txtSIFm.Text = "" And txtSITo.Text <> "" Then
            MsgBox("Sample Invoice No. Empty (From) !")
            Exit Sub
        End If

        If txtSIFm.Text <> "" And txtSITo.Text = "" Then
            MsgBox("Sample Invoice No. Empty (To) !")
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

        If cboSIStatus.Text = "" Then
            MsgBox("Please Select the Invoice Status!")
            'cboSIStatus.SetFocus()
            Exit Sub
        End If


        Dim VENCDEFM As String
        Dim VENCDETO As String

        If (cboVenCdeFm.Text <> "") And (cboVenCdeTo.Text <> "") Then
            If (InStr(cboVenCdeFm.Text, " - ") > 0) Then
                VENCDEFM = Mid(cboVenCdeFm.Text, 1, InStr(cboVenCdeFm.Text, " - ") - 1)
            Else
                VENCDEFM = cboVenCdeFm.Text
            End If

            If (InStr(cboVenCdeTo.Text, " - ") > 0) Then
                VENCDETO = Mid(cboVenCdeTo.Text, 1, InStr(cboVenCdeTo.Text, " - ") - 1)
            Else
                VENCDETO = cboVenCdeTo.Text
            End If
        Else
            VENCDEFM = cboVenCdeFm.Text
            VENCDETO = cboVenCdeTo.Text
        End If


        Dim VenSubCdeFm As String
        Dim VenSubCdeTo As String

        If (cboVenSubCdeFm.Text <> "") And (cboVenSubCdeTo.Text <> "") Then
            If (InStr(cboVenSubCdeFm.Text, " - ") > 0) Then
                VenSubCdeFm = Mid(cboVenSubCdeFm.Text, 1, InStr(cboVenSubCdeFm.Text, " - ") - 1)
            Else
                VenSubCdeFm = cboVenSubCdeFm.Text
            End If

            If (InStr(cboVenSubCdeTo.Text, " - ") > 0) Then
                VenSubCdeTo = Mid(cboVenSubCdeTo.Text, 1, InStr(cboVenSubCdeTo.Text, " - ") - 1)
            Else
                VenSubCdeTo = cboVenSubCdeTo.Text
            End If
        Else
            VenSubCdeFm = cboVenSubCdeFm.Text
            VenSubCdeTo = cboVenSubCdeTo.Text
        End If


        Dim VenTypFm As String
        Dim VenTypTo As String

        If (cboVenTypFm.Text <> "") And (cboVenTypTo.Text <> "") Then
            If (InStr(cboVenTypFm.Text, " - ") > 0) Then
                VenTypFm = Mid(cboVenTypFm.Text, 1, InStr(cboVenTypFm.Text, " - ") - 1)
            Else
                VenTypFm = cboVenTypFm.Text
            End If

            If (InStr(cboVenTypTo.Text, " - ") > 0) Then
                VenTypTo = Mid(cboVenTypTo.Text, 1, InStr(cboVenTypTo.Text, " - ") - 1)
            Else
                VenTypTo = cboVenTypTo.Text
            End If
        Else
            VenTypFm = cboVenTypFm.Text
            VenTypTo = cboVenTypTo.Text
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

        If cboSIStatus.Text <> "" Then
            status = Split(cboSIStatus.Text, " - ")(0)
        End If

        Dim sort As String
        If OptCust.Checked = True Then
            sort = "Customer"
        Else
            sort = "Sample Invoice No."
        End If

        Dim S As String
        Dim rs As New DataSet
        Me.Cursor = Windows.Forms.Cursors.WaitCursor




        S = "㊣MSR00033','S','" & _
            CNF & "','" & cnt & _
            "','" & txtSIFm.Text & "','" & txtSITo.Text & _
            "','" & VENCDEFM & "','" & VENCDETO & _
            "','" & VenSubCdeFm & "','" & VenSubCdeTo & _
            "','" & VenTypFm & "','" & VenTypTo & _
            "','" & IDF & "','" & IDT & _
            "','" & status & _
            "','" & sort & "','" & gsUsrID

        rs = objBSGate.Enquire(gsConnStr, "sp_general", S)



        If rs.Tables("RESULT").Rows(0).Item(0).ToString <> "0" Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox(rs.Tables("RESULT").Rows(0).Item(0).ToString) '*** An error has occured
            Exit Sub
        Else

            rs_MSR00033 = rs.Copy
            ''should copy only row one

            If rs_MSR00033.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                '                msg("M00071")
                Exit Sub
            Else

                '************Sorting***********************
                If OptCust.Checked = True Then
                    rs_MSR00033.Tables("RESULT").DefaultView.Sort = "Pri_Cust,Sec_Cust"
                Else
                    rs_MSR00033.Tables("RESULT").DefaultView.Sort = "sih_invno"
                End If


                If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
                    '''ReportName(0) = "MSR00033.rpt"
                Else
                    '''ReportName(0) = "MSR00033B.rpt"
                End If


                '''ReportRS(0) = rs_MSR00033
                frmReport.Show()

            End If

        End If

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

    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenCdeFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboVenCdeTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            Next
        End If
    End Sub
    Private Sub FillcboVenSubCde()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenSubCdeFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboVenSubCdeTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            Next
        End If
    End Sub

    Private Sub DisplayVenSubCde()
        Dim VENCDEFM As String
        Dim VENCDETO As String

        If (cboVenCdeFm.Text <> "") And (cboVenCdeTo.Text <> "") Then
            If (InStr(cboVenCdeFm.Text, " - ") > 0) Then
                VENCDEFM = Mid(cboVenCdeFm.Text, 1, InStr(cboVenCdeFm.Text, " - ") - 1)
            Else
                VENCDEFM = cboVenCdeFm.Text
            End If

            If (InStr(cboVenCdeTo.Text, " - ") > 0) Then
                VENCDETO = Mid(cboVenCdeTo.Text, 1, InStr(cboVenCdeTo.Text, " - ") - 1)
            Else
                VENCDETO = cboVenCdeTo.Text
            End If
        Else
            VENCDEFM = cboVenCdeFm.Text
            VENCDETO = cboVenCdeTo.Text
        End If

        If VENCDEFM = "0005" And VENCDETO = "0005" Then
            cboVenSubCdeFm.Enabled = True
            cboVenSubCdeTo.Enabled = True
        Else
            cboVenSubCdeFm.Enabled = False
            cboVenSubCdeTo.Enabled = False
        End If
    End Sub


    Private Sub txtDateFrom_Change()
        txtDateTo.Text = txtDateFrom.Text
    End Sub

    Private Sub txtSIfm_Change()
        txtSITo.Text = txtSIFm.Text
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

    Private Sub txtSIfm_GotFocus()
        'Call HighlightText(txtSIFm)
    End Sub

    Private Sub txtSITo_GotFocus()
        ''Call HighlightText(txtSITo)
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

        If Not IsDate(txtDateFrom.Text) Then
            MsgBox(" Issue Date Invalid (From) !")
            Exit Sub
        End If

        If Not IsDate(txtDateTo.Text) Then
            MsgBox(" Issue Date Invalid (To) !")
            Exit Sub
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

        If txtSIFm.Text > txtSITo.Text Then
            MsgBox("Sample Invoice No. : From > To !")
            Exit Sub
        End If

        If txtSIFm.Text = "" And txtSITo.Text <> "" Then
            MsgBox("Sample Invoice No. Empty (From) !")
            Exit Sub
        End If

        If txtSIFm.Text <> "" And txtSITo.Text = "" Then
            MsgBox("Sample Invoice No. Empty (To) !")
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


        Dim VENCDEFM As String
        Dim VENCDETO As String

        If (cboVenCdeFm.Text <> "") And (cboVenCdeTo.Text <> "") Then
            If (InStr(cboVenCdeFm.Text, " - ") > 0) Then
                VENCDEFM = Mid(cboVenCdeFm.Text, 1, InStr(cboVenCdeFm.Text, " - ") - 1)
            Else
                VENCDEFM = cboVenCdeFm.Text
            End If

            If (InStr(cboVenCdeTo.Text, " - ") > 0) Then
                VENCDETO = Mid(cboVenCdeTo.Text, 1, InStr(cboVenCdeTo.Text, " - ") - 1)
            Else
                VENCDETO = cboVenCdeTo.Text
            End If
        Else
            VENCDEFM = cboVenCdeFm.Text
            VENCDETO = cboVenCdeTo.Text
        End If


        Dim VenSubCdeFm As String
        Dim VenSubCdeTo As String

        If (cboVenSubCdeFm.Text <> "") And (cboVenSubCdeTo.Text <> "") Then
            If (InStr(cboVenSubCdeFm.Text, " - ") > 0) Then
                VenSubCdeFm = Mid(cboVenSubCdeFm.Text, 1, InStr(cboVenSubCdeFm.Text, " - ") - 1)
            Else
                VenSubCdeFm = cboVenSubCdeFm.Text
            End If

            If (InStr(cboVenSubCdeTo.Text, " - ") > 0) Then
                VenSubCdeTo = Mid(cboVenSubCdeTo.Text, 1, InStr(cboVenSubCdeTo.Text, " - ") - 1)
            Else
                VenSubCdeTo = cboVenSubCdeTo.Text
            End If
        Else
            VenSubCdeFm = cboVenSubCdeFm.Text
            VenSubCdeTo = cboVenSubCdeTo.Text
        End If


        Dim VenTypFm As String
        Dim VenTypTo As String

        If (cboVenTypFm.Text <> "") And (cboVenTypTo.Text <> "") Then
            If (InStr(cboVenTypFm.Text, " - ") > 0) Then
                VenTypFm = Mid(cboVenTypFm.Text, 1, InStr(cboVenTypFm.Text, " - ") - 1)
            Else
                VenTypFm = cboVenTypFm.Text
            End If

            If (InStr(cboVenTypTo.Text, " - ") > 0) Then
                VenTypTo = Mid(cboVenTypTo.Text, 1, InStr(cboVenTypTo.Text, " - ") - 1)
            Else
                VenTypTo = cboVenTypTo.Text
            End If
        Else
            VenTypFm = cboVenTypFm.Text
            VenTypTo = cboVenTypTo.Text
        End If


        'ReDim ReportName(0) As String
        'ReDim ReportRS(0) As ADOR.Recordset



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

        If cboSIStatus.Text <> "" Then
            status = Split(cboSIStatus.Text, " - ")(0)
        End If

        Dim sort As String
        If OptCust.Checked = True Then
            sort = "C"
        Else
            sort = "I"
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor


        gspStr = "temp_sp_select_MSR00033 '" & cboCoCde.Text & _
            "','" & CNF & "','" & cnt & _
            "','" & txtSIFm.Text & "','" & txtSITo.Text & _
            "','" & VENCDEFM & "','" & VENCDETO & _
            "','" & VenSubCdeFm & "','" & VenSubCdeTo & _
            "','" & VenTypFm & "','" & VenTypTo & _
            "','" & IDF & "','" & IDT & _
            "','" & status & _
            "','" & sort & "','" & gsUsrID & "'"

        'gspStr = "sp_select_MSR00033 'UCP','50000','59999','','','','','','','','','03/01/2009','03/01/2013','ALL','','mis'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_MSR00033, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00033 : " & rtnStr)
            Exit Sub
        End If


        If rs_MSR00033.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("M00033")
            Exit Sub
        Else

            '************Sorting***********************
            ' ''If OptCust.Value = True Then
            ' ''    rs_MSR00033.sort = "Pri_Cust,Sec_Cust"
            ' ''Else
            ' ''    rs_MSR00033.sort = "sih_invno"
            ' ''End If


            'If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
            '    ReportName(0) = "MSR00033.rpt"
            'Else
            '    ReportName(0) = "MSR00033B.rpt"
            'End If


            'ReportRS(0) = rs_MSR00033
            'frmReport.Show()

            '''
            If sort = "C" Then
                rs_MSR00033.Tables("RESULT").DefaultView.Sort = "Pri_Cust,Sec_Cust"
            Else
                rs_MSR00033.Tables("RESULT").DefaultView.Sort = "sih_invno"
            End If

            Dim objRpt As New MSR00033Rpt
            Dim objRptB As New MSR00033BRpt


            If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
                objRpt.SetDataSource(rs_MSR00033.Tables("RESULT").DefaultView)

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

            Else
                objRptB.SetDataSource(rs_MSR00033.Tables("RESULT").DefaultView)

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRptB
                frmReportView.Show()

            End If



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

    '    If rs_SYCOMINF_NAME.Tables("RESULT") Is Nothing Then
    '        Exit Function
    '    End If

    '    dr = rs_SYCOMINF_NAME.Tables("RESULT").Select("yco_cocde = '" & gsCompany & "'")
    '    If Not dr.Length > 0 Then
    '        'MsgBox("Invalid Company Name")
    '    Else
    '        ChangeCompany = dr(0)("yco_conam").ToString
    '    End If
    '    Call Update_gs_Value(gsCompany)
    '    Call AccessRight(FormName)
    'End Function


    Private Sub MSR00033_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.Width = 790
        'Me.Height = 583



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

        ' cboCoCde.Text = "ALL"

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


        cboVenSubCdeFm.Enabled = False
        cboVenSubCdeTo.Enabled = False

        cboSIStatus.Items.Add("ALL - All Status")

        cboSIStatus.Items.Add("OPE - OPEN")
        cboSIStatus.Items.Add("REL - Released")
        cboSIStatus.Items.Add("CLO - Close")

        cboSIStatus.SelectedIndex = 0


        cboVenTypFm.Items.Clear()

        cboVenTypFm.Items.Add("E - External")
        cboVenTypFm.Items.Add("I - Internal")
        cboVenTypFm.Items.Add("J - Joint-Venture")
        cboVenTypFm.SelectedIndex = 0
        cboVenTypFm.Text = ""

        cboVenTypTo.Items.Clear()
        cboVenTypTo.Items.Add("E - External")
        cboVenTypTo.Items.Add("I - Internal")
        cboVenTypTo.Items.Add("J - Joint-Venture")
        cboVenTypTo.SelectedIndex = 0
        cboVenTypTo.Text = ""


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

    Private Sub txtDateFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.LostFocus
        Me.txtDateTo.Text = Me.txtDateFrom.Text
        txtDateTo.Focus()
        txtDateTo.SelectAll()

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub cboCustNoFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoFm.KeyUp
        Call auto_search_combo(cboCustNoFm, e.KeyCode)

    End Sub

    Private Sub cboCustNoFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoFm.LostFocus

        cboCustNoTo.Text = cboCustNoFm.Text
        cboCustNoTo.Focus()
        cboCustNoTo.SelectAll()

    End Sub
    Private Sub cboCustNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SelectedIndexChanged

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub cboCustNoTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoTo.KeyUp
        Call auto_search_combo(cboCustNoTo, e.KeyCode)

    End Sub
    Private Sub cboCustNoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoTo.SelectedIndexChanged

    End Sub

    Private Sub cboCustNoFm_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SizeChanged

    End Sub

    Private Sub cboVenCdeFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenCdeFm.KeyUp

        Call auto_search_combo(cboVenCdeFm, e.KeyCode)

    End Sub

    Private Sub cboVenCdeFm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenCdeFm.LostFocus
        cboVenCdeTo.Text = cboVenCdeFm.Text

    End Sub

    Private Sub cboVenCdeFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCdeFm.SelectedIndexChanged

    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub txtDateTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateTo.GotFocus
        txtDateTo.SelectAll()

    End Sub

    Private Sub txtDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateTo.MaskInputRejected

    End Sub

    Private Sub cboVenCdeTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenCdeTo.KeyUp
        Call auto_search_combo(cboVenCdeTo, e.KeyCode)

    End Sub

    Private Sub cboVenCdeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenCdeTo.SelectedIndexChanged


    End Sub
End Class



''Public Class MSR00033

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