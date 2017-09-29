Imports Microsoft.Office.Interop
Imports System.IO
Public Class INR00001


    Public rs_CUBASINF As DataSet
    Public rs_CUBASINF_S As DataSet

    Public rs_INR00001A As DataSet
    Public rs_INR00001 As DataSet
    Public rs_INR00001SUB As DataSet
    Public rs_INR00001DP As DataSet
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



        ' Validation Inv. No ------------------------------------

        If txtFromQuotNo.Text > txtToQuotNo.Text Then
            MsgBox("Inv. No. : From > To !")
            Exit Sub
        End If

        If txtFromQuotNo.Text = "" And txtToQuotNo.Text <> "" Then
            MsgBox("Inv. No. Empty (From) !")
            Exit Sub
        End If

        If txtFromQuotNo.Text <> "" And txtToQuotNo.Text = "" Then
            MsgBox("Inv. No. Empty (To) !")
            Exit Sub
        End If

        '-------------------------------------------------
        ' Set Issue Date value to empty then there is "  /  /    "
        Dim IDF As String
        Dim IDT As String

        ' Customer No --------------------------------------
        Dim status As String

        Dim sort As String
        If optCust.Checked = True Then
            sort = "Customer"
        Else
            sort = "Inv. No."
        End If

        Dim S As String
        Dim rs As New DataSet
        Me.Cursor = Windows.Forms.Cursors.WaitCursor




        'S = "㊣INR00001','S','" & _
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

        'rs_INR00001 = rs.Copy
        ' ''should copy only row one

        'If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    '                msg("M00071")
        '    Exit Sub
        'Else

        '    '************Sorting***********************
        '    If OptCust.Checked = True Then
        '        rs_INR00001.Tables("RESULT").DefaultView.Sort = "Pri_Cust,Sec_Cust"
        '    Else
        '        rs_INR00001.Tables("RESULT").DefaultView.Sort = "sih_invno"
        '    End If


        '    If (cboVenCdeFm.Text = "" And cboVenCdeTo.Text = "" And cboVenTypFm.Text = "" And cboVenTypTo.Text = "") Then
        '        '''ReportName(0) = "INR00001.rpt"
        '    Else
        '        '''ReportName(0) = "INR00001B.rpt"
        '    End If


        '    '''ReportRS(0) = rs_INR00001
        ''    frmReport.Show()

        'End If

        'End If

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub Form_Load()

        If gsCompany = "UCPP" Then
            OptJobNoY.Checked = True
        Else
            OptJobNoY.Checked = False
        End If

    End Sub






    Private Sub txtFromItmno_Change()
        txtToQuotNo.Text = txtFromQuotNo.Text
    End Sub

    Private Sub cboCustNoFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCustNoFm, KeyCode)
    End Sub

    Private Sub cboCustNoTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboCustNoTo, KeyCode)
    End Sub



    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------
        Dim one As String
        Dim two As String
        Dim thr As String
        Dim laf As String
        Dim fou As String
        Dim fiv As String
        Dim Six As String
        Dim printGroup As String
        Dim PrintAlias As String
        Dim printAss As String

        If opt1.Checked = True Then
            one = "Y"
        Else
            one = "N"
        End If

        If opt2.Checked = True Then
            two = "Y"
        Else
            two = "N"
        End If

        If opt3.Checked = True Then
            thr = "Y"
        Else
            thr = "N"
        End If

        laf = "C"
        '20140509
        'If optA.checked = True Then
        '    laf = "A"
        'ElseIf optB.checked = True Then
        '    laf = "B"
        'Else
        '    laf = "C"
        'End If

        If OptQtyY.Checked = True Then
            fiv = "Y"
        Else
            fiv = "N"
        End If

        If OptJobNoY.Checked = True Then
            fou = "Y"
        Else
            fou = "N"
        End If

        If SkuY.Checked = True Then
            Six = "Y"
        Else
            Six = "N"
        End If

        If optGroupY.Checked = True Then
            printGroup = "1"
        Else
            printGroup = "0"
        End If

        If optAliasY.Checked = True Then
            PrintAlias = "1"
        Else
            PrintAlias = "0"
        End If

        Dim AccOnlyUsrGrp = "Y"

        'If optAccY.checked = True Then
        '    AccOnlyUsrGrp = "Y"
        'Else
        '    AccOnlyUsrGrp = "N"
        'End If

        If optAssY.Checked = True Then
            printAss = "Y"
        Else
            printAss = "N"
        End If

        If txtFromQuotNo.Text > txtToQuotNo.Text Then
            MsgBox("Inv. No. : From > To !")
            Exit Sub
        End If

        If txtFromQuotNo.Text = "" And txtToQuotNo.Text <> "" Then
            MsgBox("Inv. No. Empty (From) !")
            Exit Sub
        End If

        If txtFromQuotNo.Text <> "" And txtToQuotNo.Text = "" Then
            MsgBox("Inv. No. Empty (To) !")
            Exit Sub
        End If


        Dim cocde As String
        cocde = cboCoCde.Text

        If cboRptFmt.SelectedIndex = 0 Then
            '************************
            '*** Standard Invoice ***
            '************************
            '***********************************
            '*** New format Invoice (Target) ***
            '***********************************
        ElseIf cboRptFmt.SelectedIndex = 2 Then
            '20140509
            Me.optInv.Checked = False
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001A_NET '" & _
                            cocde & "','" & _
                            one & "','" & _
                            two & "','" & _
                            thr & "','" & _
                            laf & "','" & _
                            fou & "','" & _
                            fiv & "','" & _
                            Six & "','" & _
                             txtFromQuotNo.Text & "','" & _
                            txtToQuotNo.Text & "','" & _
                        IIf(Me.optInv.Checked = True, 0, 1) & _
                        "','" & IIf(Me.optItm.Checked = True, "ITM", "CUSITM") & "','" & _
                        printGroup & "','" & PrintAlias & "','" & printAss & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001A, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001A : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001A.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001A No Record!")
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001A.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001A.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001A.Tables("RESULT").Rows.Count - 1
                rs_INR00001A.Tables("RESULT").Rows(i)("compLogo") = compLogo
            Next
            rs_INR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = True




            'INR00001 
            gspStr = "sp_select_INR00001_NET '" & _
                cocde & "','" & _
                one & "','" & _
                two & "','" & _
                thr & "','" & _
                laf & "','" & _
                fou & "','" & _
                fiv & "','" & _
                Six & "','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','" & _
            IIf(Me.optInv.Checked = True, 0, 1) & _
            "','" & IIf(Me.optItm.Checked = True, "ITM", "CUSITM") & "','" & _
            printGroup & "','" & PrintAlias & "','" & AccOnlyUsrGrp & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001A : " & rtnStr)
                Exit Sub
            End If

            ''2
            gspStr = " sp_select_INR00001SUB_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUB, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If

            ''3
            gspStr = " sp_select_INR00001DP_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001DP, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001DP : " & rtnStr)
                Exit Sub
            End If





            Dim objRpt As New INR00001ARpt
            'objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))


            'objRpt.Database.Tables("INR00001A").SetDataSource(rs_INR00001A.Tables("RESULT"))
            objRpt.SetDataSource(rs_INR00001A.Tables("RESULT"))

            objRpt.Subreports.Item("INR00001SUB").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001DP").SetDataSource(rs_INR00001DP.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001ASS").SetDataSource(rs_INR00001.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default


            ''' TARGET CANADA
        ElseIf cboRptFmt.SelectedIndex = 3 Then
            Me.optInv.Checked = False
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001A_NET '" & _
                            cocde & "','" & _
                            one & "','" & _
                            two & "','" & _
                            thr & "','" & _
                            laf & "','" & _
                            fou & "','" & _
                            fiv & "','" & _
                            Six & "','" & _
                             txtFromQuotNo.Text & "','" & _
                            txtToQuotNo.Text & "','" & _
                        IIf(Me.optInv.Checked = True, 0, 1) & _
                        "','" & IIf(Me.optItm.Checked = True, "ITM", "CUSITM") & "','" & _
                        printGroup & "','" & PrintAlias & "','" & printAss & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001A, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001A : " & rtnStr)
                Exit Sub
            End If




            'INR00001 
            gspStr = "sp_select_INR00001_NET '" & _
                cocde & "','" & _
                one & "','" & _
                two & "','" & _
                thr & "','" & _
                laf & "','" & _
                fou & "','" & _
                fiv & "','" & _
                Six & "','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','" & _
            IIf(Me.optInv.Checked = True, 0, 1) & _
            "','" & IIf(Me.optItm.Checked = True, "ITM", "CUSITM") & "','" & _
            printGroup & "','" & PrintAlias & "','" & AccOnlyUsrGrp & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001A : " & rtnStr)
                Exit Sub
            End If

            ''2
            gspStr = " sp_select_INR00001SUB_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUB, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If

            ''3
            gspStr = " sp_select_INR00001DP_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001DP, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001DP : " & rtnStr)
                Exit Sub
            End If




            If rs_INR00001A.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001A No Record!")
                Exit Sub
            End If


            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001A.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001A.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001A.Tables("RESULT").Rows.Count - 1
                rs_INR00001A.Tables("RESULT").Rows(i)("compLogo") = compLogo
            Next
            rs_INR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = True



            Dim objRpt As New INR00001A2Rpt
            'objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))


            'objRpt.Database.Tables("INR00001A").SetDataSource(rs_INR00001A.Tables("RESULT"))
            objRpt.SetDataSource(rs_INR00001A.Tables("RESULT"))

            objRpt.Subreports.Item("INR00001SUB").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001DP").SetDataSource(rs_INR00001DP.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001ASS").SetDataSource(rs_INR00001.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default
            ''
            ''' TARGET 
        ElseIf cboRptFmt.SelectedIndex = 4 Then
            Me.optInv.Checked = False
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001A_NET '" & _
                            cocde & "','" & _
                            one & "','" & _
                            two & "','" & _
                            thr & "','" & _
                            laf & "','" & _
                            fou & "','" & _
                            fiv & "','" & _
                            Six & "','" & _
                             txtFromQuotNo.Text & "','" & _
                            txtToQuotNo.Text & "','" & _
                        IIf(Me.optInv.Checked = True, 0, 1) & _
                        "','" & IIf(Me.optItm.Checked = True, "ITM", "CUSITM") & "','" & _
                        printGroup & "','" & PrintAlias & "','" & printAss & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001A, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001A : " & rtnStr)
                Exit Sub
            End If

            'INR00001 
            gspStr = "sp_select_INR00001_NET '" & _
                cocde & "','" & _
                one & "','" & _
                two & "','" & _
                thr & "','" & _
                laf & "','" & _
                fou & "','" & _
                fiv & "','" & _
                Six & "','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','" & _
            IIf(Me.optInv.Checked = True, 0, 1) & _
            "','" & IIf(Me.optItm.Checked = True, "ITM", "CUSITM") & "','" & _
            printGroup & "','" & PrintAlias & "','" & AccOnlyUsrGrp & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001A : " & rtnStr)
                Exit Sub
            End If

            ''2
            gspStr = " sp_select_INR00001SUB_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUB, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If

            ''3
            gspStr = " sp_select_INR00001DP_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001DP, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001DP : " & rtnStr)
                Exit Sub
            End If




            If rs_INR00001A.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001A No Record!")
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001A.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001A.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001A.Tables("RESULT").Rows.Count - 1
                rs_INR00001A.Tables("RESULT").Rows(i)("compLogo") = compLogo
            Next
            rs_INR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = True





            Dim objRpt As New INR00001A3Rpt
            'objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))


            'objRpt.Database.Tables("INR00001A").SetDataSource(rs_INR00001A.Tables("RESULT"))
            objRpt.SetDataSource(rs_INR00001A.Tables("RESULT"))

            objRpt.Subreports.Item("INR00001SUB").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001DP").SetDataSource(rs_INR00001DP.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001ASS").SetDataSource(rs_INR00001.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default



            '************************
            '*** Wal-Mart Invoice ***
            '************************
        ElseIf cboRptFmt.SelectedIndex = 5 Then
            Dim rs_INR00001B As DataSet
            Dim rs_INR00001B_ASSORT As DataSet
            Dim rs_INR00001B_CPTBKD As DataSet

            gspStr = "sp_select_INR00001B_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & _
                     "Y" & "','" & "Y" & "','" & "Y" & "','" & "C" & "','" & "Y" & "','" & "Y" & "','" & "Y" & "','" & _
                     "1" & "','" & "ITM" & "','" & "1" & "','" & "1" & "','" & "Y" & "'"
            rs_INR00001B = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001B, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading " & Me.Name & " sp_select_INR00001B : " & rtnStr)
                Exit Sub
            Else
                For i As Integer = 0 To rs_INR00001B.Tables("RESULT").Columns.Count - 1
                    rs_INR00001B.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If

            If rs_INR00001B.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            Else
                gspStr = "sp_select_INR00001B_ASSORT_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"
                rs_INR00001B_ASSORT = Nothing
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_INR00001B_ASSORT, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading " & Me.Name & " sp_select_INR00001B_ASSORT : " & rtnStr)
                    Exit Sub
                Else
                    For i As Integer = 0 To rs_INR00001B_ASSORT.Tables("RESULT").Columns.Count - 1
                        rs_INR00001B_ASSORT.Tables("RESULT").Columns(i).ReadOnly = False
                    Next
                End If

                gspStr = "sp_select_INR00001B_CPTBKD_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"
                rs_INR00001B_CPTBKD = Nothing
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_INR00001B_CPTBKD, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading " & Me.Name & " sp_select_INR00001B_CPTBKD : " & rtnStr)
                    Exit Sub
                Else
                    For i As Integer = 0 To rs_INR00001B_CPTBKD.Tables("RESULT").Columns.Count - 1
                        rs_INR00001B_CPTBKD.Tables("RESULT").Columns(i).ReadOnly = False
                    Next
                End If

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim colCompLogo As DataColumn
                Dim compLogo As Byte() = imageToByteArray(rs_INR00001B.Tables("RESULT").Rows(0)("yco_logoimgpth"))
                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_INR00001B.Tables("RESULT").Columns.Add(colCompLogo)
                rs_INR00001B.Tables("RESULT").Columns("complogo").ReadOnly = False
                For j As Integer = 0 To rs_INR00001B.Tables("RESULT").Rows.Count - 1
                    rs_INR00001B.Tables("RESULT").Rows(j)("compLogo") = compLogo
                Next
                Me.Cursor = Windows.Forms.Cursors.Default

                Dim objRpt As New INR00001B1Rpt
                objRpt.Database.Tables("INR00001B").SetDataSource(rs_INR00001B.Tables("RESULT"))
                objRpt.Database.Tables("INR00001B_ASSORT").SetDataSource(rs_INR00001B_ASSORT.Tables("RESULT"))
                objRpt.Database.Tables("INR00001B_CPTBKD").SetDataSource(rs_INR00001B_CPTBKD.Tables("RESULT"))
                ''Export to PDF
                'objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "C:\" & txtFromQuotNo.Text & ".pdf")
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
                Me.Cursor = Windows.Forms.Cursors.Default
            End If

        ElseIf cboRptFmt.SelectedIndex = 6 Then
            Dim rs_INR00001B As DataSet
            Dim rs_INR00001B_ASSORT As DataSet
            Dim rs_INR00001B_CPTBKD As DataSet

            gspStr = "sp_select_INR00001B_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & _
                     "Y" & "','" & "Y" & "','" & "Y" & "','" & "C" & "','" & "Y" & "','" & "Y" & "','" & "Y" & "','" & _
                     "1" & "','" & "ITM" & "','" & "1" & "','" & "1" & "','" & "Y" & "'"
            rs_INR00001B = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001B, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading " & Me.Name & " sp_select_INR00001B : " & rtnStr)
                Exit Sub
            Else
                For i As Integer = 0 To rs_INR00001B.Tables("RESULT").Columns.Count - 1
                    rs_INR00001B.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If

            If rs_INR00001B.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            Else
                gspStr = "sp_select_INR00001B_ASSORT_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"
                rs_INR00001B_ASSORT = Nothing
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_INR00001B_ASSORT, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading " & Me.Name & " sp_select_INR00001B_ASSORT : " & rtnStr)
                    Exit Sub
                Else
                    For i As Integer = 0 To rs_INR00001B_ASSORT.Tables("RESULT").Columns.Count - 1
                        rs_INR00001B_ASSORT.Tables("RESULT").Columns(i).ReadOnly = False
                    Next
                End If

                gspStr = "sp_select_INR00001B_CPTBKD_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"
                rs_INR00001B_CPTBKD = Nothing
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_INR00001B_CPTBKD, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading " & Me.Name & " sp_select_INR00001B_CPTBKD : " & rtnStr)
                    Exit Sub
                Else
                    For i As Integer = 0 To rs_INR00001B_CPTBKD.Tables("RESULT").Columns.Count - 1
                        rs_INR00001B_CPTBKD.Tables("RESULT").Columns(i).ReadOnly = False
                    Next
                End If

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim colCompLogo As DataColumn
                Dim compLogo As Byte() = imageToByteArray(rs_INR00001B.Tables("RESULT").Rows(0)("yco_logoimgpth"))
                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_INR00001B.Tables("RESULT").Columns.Add(colCompLogo)
                rs_INR00001B.Tables("RESULT").Columns("complogo").ReadOnly = False
                For j As Integer = 0 To rs_INR00001B.Tables("RESULT").Rows.Count - 1
                    rs_INR00001B.Tables("RESULT").Rows(j)("compLogo") = compLogo
                Next
                Me.Cursor = Windows.Forms.Cursors.Default

                Dim objRpt As New INR00001B2Rpt
                objRpt.Database.Tables("INR00001B").SetDataSource(rs_INR00001B.Tables("RESULT"))
                objRpt.Database.Tables("INR00001B_ASSORT").SetDataSource(rs_INR00001B_ASSORT.Tables("RESULT"))
                objRpt.Database.Tables("INR00001B_CPTBKD").SetDataSource(rs_INR00001B_CPTBKD.Tables("RESULT"))
                ''Export to PDF
                'objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "C:\" & txtFromQuotNo.Text & ".pdf")
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
                Me.Cursor = Windows.Forms.Cursors.Default
            End If

        Else
            '*********************************
            'Elliwell Invoice ****************
            '*********************************
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


    Private Sub INR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If gsUsrGrp = "ACT-S" Or gsUsrGrp = "ACT-G" Then
            cboRptFmt.Items.Add("Invoice Standard Format (Not Available)")
        Else
            cboRptFmt.Items.Add("Invoice Standard Format (Not Available)")
            cboRptFmt.Items.Add("Elliwell Invoice (Not Available)")
            cboRptFmt.Items.Add("Invoice (MM Team - Target Format)")
            cboRptFmt.Items.Add("Invoice (MM Team - Target Canada Format)")
            cboRptFmt.Items.Add("Invoice (MM Team - Target Dot Com Format)")
            cboRptFmt.Items.Add("Invoice (Wal-Mart USA Format)")
            cboRptFmt.Items.Add("Invoice (Wal-Mart CANADA Format)")
            cboRptFmt.Items.Add("Combine Invoice Standard Format (Not Available)")
        End If



        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        '        cboCoCde.Items.Add("ALL")
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        cboCoCde.Text = "ALL"
        Cursor = Cursors.WaitCursor

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

        Dim s2 As String
        Dim rs2 As New DataSet


        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub cboRptFmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRptFmt.KeyUp
        Call auto_search_combo(cboRptFmt, e.KeyCode)
    End Sub

    Private Sub cboRptFmt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRptFmt.SelectedIndexChanged

    End Sub

    Private Sub opt2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt2.CheckedChanged

    End Sub

    Private Sub Option8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Option8.CheckedChanged

    End Sub
    Private Function imageToByteArray(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If ImageFilePath = "" Then
            Return Nothing
        End If
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub txtFromQuotNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromQuotNo.LostFocus
        txtToQuotNo.Text = txtFromQuotNo.Text.Trim

    End Sub

    Private Sub txtFromQuotNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromQuotNo.TextChanged

    End Sub
End Class


