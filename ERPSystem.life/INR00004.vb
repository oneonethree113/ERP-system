Public Class INR00004

    '*** Program ID     :SCR00002
    '*** Author         :Kenny Chan
    '*** Creation Date  :19-12-2001
    '*** Description    :SC
    '*** Logic          :
    '***
    '*****************************************************************************************************************************
    '*** Modification History
    '*****************************************************************************************************************************
    '*** Modified By        Modified on         Description
    '*****************************************************************************************************************************
    '*** Lester Wu          2004/05/24          Retrieve CBM Delivery in the previous of input year value
    '*** Lester Wu          2005/03/29          Use "UC-G" instead of "ALL", guard MS company user from acccess UC-G company
    '***
    '*****************************************************************************************************************************

    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As Dataset

    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        'Lester Wu 2005-03-29 use "UC-G" instead of "ALL"
        'If cboCoCde.Text <> "ALL" Then
        If cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
    End Sub

    Private Sub cboSCFm_Click()
        cboSCTo.Text = cboSCFm.Text
    End Sub
    Private Sub cboSCFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSCFm, KeyCode)
    End Sub

    Private Sub cboSCFm_LostFocus()
        'Call ValidateCombo(cboSCFm)
        If ValidateCombo(cboSCFm) = True Then
            cboSCTo.Text = cboSCFm.Text
        End If
    End Sub

    Private Sub cboSCTo_GotFocus()
        Me.cboSCTo.selectionStart = 0
        Me.cboSCTo.SelectionLength = Len(Me.cboSCTo.Text)
    End Sub

    Private Sub cboSCTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSCTo, KeyCode)
    End Sub

    Private Sub cboSCTo_LostFocus()
        Call ValidateCombo(cboSCTo)
    End Sub

    Private Sub cboVenFm_Click()
        '    cboVenTo.Text = cboVenFm.Text
    End Sub
    Private Sub cboVenFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenFm, KeyCode)
    End Sub
    Private Sub cboVenFm_LostFocus()
        'Call ValidateCombo(cboVenFm)
        If ValidateCombo(cboVenFm) = True Then
            cboVenTo.Text = cboVenFm.Text
        End If
    End Sub

    Private Sub cboVenTo_GotFocus()
        Me.cboVenTo.selectionStart = 0
        Me.cboVenTo.SelectionLength = Len(Me.cboVenTo.Text)
    End Sub

    Private Sub cboVenTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenTo, KeyCode)
    End Sub
    Private Sub cboVenTo_LostFocus()
        Call ValidateCombo(cboVenTo)
    End Sub


    Private Sub cmdShow_Click()
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------


        Dim S As String
        Dim rs As DataSet
        Dim ReportName As String
        Dim ReportRS As Dataset

        Dim rs_Year As New Dataset
        Dim i As Integer
        Dim rs_Ordered As New Dataset
        Dim rs_Ordered1 As New Dataset
        Dim rs_Delivery As New Dataset

        'Lester Wu 2004/05/24
        'Add to save CBM Delivery in previous year
        Dim rs_Delivery1 As New Dataset
        '-----------------------------------------

        'If cboVenFm.Text = "" And cboVenTo.Text = "" Then
        '    cboVenFm.selectedIndex = 0
        '    cboVenTo.selectedIndex = cboVenTo.ListCount - 1
        'End If

        'If cboSCFm.Text = "" And cboSCTo.Text = "" Then
        '    cboSCFm.selectedIndex = 0
        '    cboSCTo.selectedIndex = cboSCTo.ListCount - 1
        'End If

        If Not InputIsVaild() Then
            Exit Sub
        End If

        '-------------------------------------------------------------------
        S = "sp_select_INR00004_0    '" & cboCocde.Text.ToString.Trim & "', '" & cboVenFm.Text & _
        "','" & cboVenTo.Text & _
        "','" & cboSCFm.Text & _
        "','" & cboSCTo.Text & _
        "','" & Trim(txtYear.Text) & "'"

        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_Ordered, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else

        End If
        '-------------------------------------------------------------------

        '-------------------------------------------------------------------
        S = "sp_select_INR00004_2     '" & cboCocde.Text.ToString.Trim & "','" & cboVenFm.Text & _
        "','" & cboVenTo.Text & _
        "','" & cboSCFm.Text & _
        "','" & cboSCTo.Text & _
        "','" & Trim(txtYear.Text) & "'"

        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_Ordered1, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        End If
        '-------------------------------------------------------------------

        Dim scFM As String
        Dim ScTo As String
        Dim VenFm As String
        Dim VenTo As String

        scFM = cboSCFm.Text
        ScTo = cboSCTo.Text
        VenFm = cboVenFm.Text
        VenTo = cboVenTo.Text

        S = "sp_select_INR00004_1     '" & cboCocde.Text.ToString.Trim & "','" & cboVenFm.Text & _
        "','" & cboVenTo.Text & _
        "','" & cboSCFm.Text & _
        "','" & cboSCTo.Text & _
        "','" & Trim(txtYear.Text) & "'"

        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_Delivery, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            With rs_Delivery
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2
            End With


        End If

        Dim compName As String


        '2004/05/27
        'Retrieve CBM Delivery in the previous year
        '-------------------------------------------------
        S = "sp_select_INR00004_3   '" & cboCocde.Text.ToString.Trim & "',' " & cboVenFm.Text & _
        "','" & cboVenTo.Text & _
        "','" & cboSCFm.Text & _
        "','" & cboSCTo.Text & _
        "','" & Trim(txtYear.Text) & "'"

        Cursor = Cursors.WaitCursor
        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_Delivery1, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        End If



        '---------------------------------------------------
        If rs_Ordered.Tables("RESULT").Rows.Count > 0 Then
            compName = rs_Ordered.Tables("RESULT").Rows(0)("compName")
            For index As Integer = 0 To rs_Ordered.Tables("RESULT").Rows.Count - 1
                rs_Delivery.Tables("RESULT").Rows.Add()
                i = 0
                For i = 0 To rs_Delivery.Tables("RESULT").Columns.Count - 1
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)(i) = rs_Ordered.Tables("RESULT").Rows(index)(i)
                Next
            Next


        End If





        If rs_Ordered1.Tables("RESULT").Rows.Count > 0 Then
            compName = rs_Ordered1.Tables("RESULT").Rows(0)("compName")
            For index As Integer = 0 To rs_Ordered1.Tables("RESULT").Rows.Count - 1
                rs_Delivery.Tables("RESULT").DefaultView.RowFilter = "Month = " & "'" & Trim(Str(rs_Ordered1.Tables("RESULT").Rows(index)("F7"))) & "'"

                If rs_Delivery.Tables("RESULT").DefaultView.Count > 0 Then
                    For i2 As Integer = 0 To rs_Delivery.Tables("RESULT").DefaultView.Count - 1
                        rs_Delivery.Tables("RESULT").DefaultView(i2)("MonDesc") = Trim(rs_Delivery.Tables("RESULT").DefaultView(i2)("MonDesc")) & "(" & Microsoft.VisualBasic.Right(Space(6) & Format(rs_Ordered1.Tables("RESULT").Rows(index)("F9"), "##,##0"), 6)
                        'TEMPZZZZ

                    Next

                Else

                    rs_Delivery.Tables("RESULT").Rows.Add()

                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Cocde") = rs_Ordered1.Tables("RESULT").Rows(index)("F0")
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Order_Delivery") = "CBM Delivery"
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Year") = rs_Ordered1.Tables("RESULT").Rows(index)("F6")
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Month") = rs_Ordered1.Tables("RESULT").Rows(index)("F7")
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("MonDesc") = Trim(rs_Ordered1.Tables("RESULT").Rows(index)("F8")) & "(" & Microsoft.VisualBasic.Right(Space(6) & Format(rs_Ordered1.Tables("RESULT").Rows(index)("F9"), "##,##0"), 6)
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("CBM") = 0

                    '------------------------------------------
                    rs_Delivery.Tables("RESULT").Rows.Add()

                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Cocde") = rs_Ordered1.Tables("RESULT").Rows(index)("F0")
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Order_Delivery") = "CBM Ordered"
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Year") = rs_Ordered1.Tables("RESULT").Rows(index)("F6")
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Month") = rs_Ordered1.Tables("RESULT").Rows(index)("F7")
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("MonDesc") = Trim(rs_Ordered1.Tables("RESULT").Rows(index)("F8")) & "(" & Microsoft.VisualBasic.Right(Space(6) & Format(rs_Ordered1.Tables("RESULT").Rows(index)("F9"), "##,##0"), 6)
                    rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("CBM") = 0
                End If
            Next

        End If

        'Append CBM Delivery in previous year the month string (F8)
        'Separating the CBM Ordered in previous year and CBM Delivery in previous year by "/"
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        If rs_Delivery1.Tables("RESULT").Rows.Count > 0 Then


            For index As Integer = 0 To rs_Delivery1.Tables("RESULT").Rows.Count - 1

                rs_Delivery.Tables("RESULT").DefaultView.RowFilter = "Month = " & "'" & Str(rs_Delivery1.Tables("RESULT").Rows(index)("F7")) & "'"

                If rs_Delivery.Tables("RESULT").DefaultView.Count > 0 Then
                    For i2 As Integer = 0 To rs_Delivery.Tables("RESULT").DefaultView.Count - 1
                        rs_Delivery.Tables("RESULT").DefaultView(i2)("MonDesc") = Trim(rs_Delivery.Tables("RESULT").DefaultView(i2)("MonDesc")) & "/" & Microsoft.VisualBasic.Right(Space(6) & Format(rs_Delivery1.Tables("RESULT").Rows(index)("F9"), "##,##0"), 6) & ")"
                    Next
                End If

            Next

        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        For i = 1 To 12
            rs_Delivery.Tables("RESULT").DefaultView.RowFilter = "Month = '" & i & "'"
            'month
            If rs_Delivery.Tables("RESULT").DefaultView.Count <= 0 Then
                rs_Delivery.Tables("RESULT").Rows.Add()

                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Cocde") = Me.cboCocde.Text
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Order_Delivery") = "CBM Delivery"
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("VenFm") = VenFm
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("VenTo") = VenTo
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("SCFm") = scFM
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("SCTo") = ScTo

                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Year") = Me.txtYear.Text.Trim
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Month") = Str(i)
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("MonDesc") = Microsoft.VisualBasic.Right("00" & Trim(Str(i)), 2) & "(" & Microsoft.VisualBasic.Right(Space(6) & Format(0, "##,##0"), 6) & "/" & Microsoft.VisualBasic.Right(Space(6) & Format(0, "##,##0"), 6) & ")"
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("CBM") = 0
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("compName") = compName
                '------------------------------------------

                rs_Delivery.Tables("RESULT").Rows.Add()

                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Cocde") = Me.cboCocde.Text
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("VenFm") = VenFm
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("VenTo") = VenTo
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("SCFm") = scFM
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("SCTo") = ScTo
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Order_Delivery") = "CBM Ordered"
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Year") = Me.txtYear.Text.Trim
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("Month") = Str(i)
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("MonDesc") = Microsoft.VisualBasic.Right("00" & Trim(Str(i)), 2) & "(" & Microsoft.VisualBasic.Right(Space(6) & Format(0, "##,##0"), 6) & "/" & Microsoft.VisualBasic.Right(Space(6) & Format(0, "##,##0"), 6) & ")"
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("CBM") = 0
                rs_Delivery.Tables("RESULT").Rows(rs_Delivery.Tables("RESULT").Rows.Count - 1)("compName") = compName
            End If
        Next

        rs_Delivery.Tables("RESULT").DefaultView.RowFilter = ""

        If rs_Delivery.Tables("RESULT").DefaultView.Count > 0 Then

            For i2 As Integer = 0 To rs_Delivery.Tables("RESULT").DefaultView.Count - 1
                'For i2 As Integer = 0 To rs_Delivery.Tables("RESULT").DefaultView.Count - 1

                If Len(Trim(rs_Delivery.Tables("RESULT").DefaultView(i2)("MonDesc"))) = 2 Then
                    rs_Delivery.Tables("RESULT").DefaultView(i2)("MonDesc") = Microsoft.VisualBasic.Right("00" & Trim(rs_Delivery.Tables("RESULT").DefaultView(i2)("MonDesc")), 2) & "(" & Microsoft.VisualBasic.Right(Space(6) & Format(0, "##,##0"), 6) & "/" & Microsoft.VisualBasic.Right(Space(6) & Format(0, "##,##0"), 6) & ")"
                End If
            Next

        End If

        rs_Delivery.Tables("RESULT").DefaultView.RowFilter = ""

        '-------------------------------------------------------------------
        '       If rs_Ordered1.Tables("RESULT").rows.count  > 0 Then
        '            rs_Ordered1.MoveFirst
        '            While Not rs_Ordered1.EOF
        '                rs_Delivery.AddNew
        '                i = 0
        '                For i = 0 To rs_Delivery.Tables("RESULT").Rows.count - 1
        '                    rs_Delivery(i).value = rs_Ordered1(i)
        '                Next
        '                rs_Delivery.Update
        '                rs_Ordered1.MoveNext
        '            Wend
        '        End If
        '-------------------------------------------------------------------





        rs_Delivery.Tables("RESULT").DefaultView.Sort = "Year asc ,Month asc ,Order_Delivery desc"
        '        rs_Delivery.sort = "F6 asc ,F7 asc "
        '*****************
        'Generate report
        '*****************
        'Dim ReportName(0 To 1) As String
        'ReDim ReportRS(0 To 1) As Dataset
        '        ReportName = "INR00004_2.rpt"


        Dim objRpt As New INR00004RptA




        objRpt.SetDataSource(rs_Delivery.Tables("RESULT").DefaultView)

        Dim frmReportView As New frmReport
        frmReportView.CrystalReportViewer.ReportSource = objRpt
        frmReportView.Show()


        Cursor = Cursors.Default
    End Sub
    Private Function InputIsVaild() As Boolean
        'If lstVendorFrom.Text = "" And cboVendorTo.Text = "" Then
        '    lstVendorFrom.selectedIndex = 0
        '    cboVendorTo.selectedIndex = cboVendorTo.ListCount - 1
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

        'If CDate(txtDateFrom.Text) > CDate(Me.txtDateTo.Text) Then
        '    Msg .Tables("RESULT").Rows(index)("Start Date > End Date")
        '    InputIsVaild = False
        '    txtDateFrom.SetFocus
        '    Exit Function
        'End If

        If Trim(Len(txtYear.Text)) < 4 Then
            MsgBox("Invalid Year")
            InputIsVaild = False
            txtYear.Focus()
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
        Call FillCompCombo(gsUsrID, cboCocde)

        'Use UC-G instead of ALL, guard MS company from access "UC-G"
        If gsDefaultCompany <> "MS" Then
            '*** Add print all company ***
            'cboCocde.Items.add "ALL"
            cboCocde.Items.Add("UC-G")
            '*****************************
        End If

        Call GetDefaultCompany(Me.cboCocde, txtCoNam)
        Call Formstartup(Me.Name)
        txtYear.Text = Year(Today)

        Dim S As String
        Dim rs As DataSet

        Cursor = Cursors.WaitCursor

        S = "sp_list_VNBASINF  '' "

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

        txtYear.Enabled = True

        Cursor = Cursors.Default
    End Sub

    'Private Sub FillcboVendor()
    'If rs_VNBASINF.Tables("RESULT").rows.count  > 0 Then
    '    While Not rs_VNBASINF.EOF
    '        lstVendorFrom.Items.add rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna")
    '    rs_VNBASINF.MoveNext
    '    Wend
    'End If
    'End Sub

    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then

            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
            Next

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





    Private Sub txtYear_Change()

    End Sub

    Private Sub INR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShow_Click()

    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If

    End Sub

    Private Sub cboSCFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCFm.LostFocus
        If ValidateCombo(cboSCFm) = True Then
            cboSCTo.Text = cboSCFm.Text
        End If

    End Sub

    Private Sub cboSCFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCFm.SelectedIndexChanged
        cboSCTo.Text = cboSCFm.Text

    End Sub

    Private Sub cboSCTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCTo.GotFocus
        Me.cboSCTo.SelectionStart = 0
        Me.cboSCTo.SelectionLength = Len(Me.cboSCTo.Text)

    End Sub

    Private Sub cboSCTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCTo.LostFocus
        Call ValidateCombo(cboSCTo)

    End Sub

    Private Sub cboSCTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCTo.SelectedIndexChanged

    End Sub

    Private Sub cboVenFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenFm.LostFocus
        If ValidateCombo(cboVenFm) = True Then
            cboVenTo.Text = cboVenFm.Text
        End If

    End Sub

    Private Sub cboVenFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenFm.SelectedIndexChanged

    End Sub

    Private Sub cboVenTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenTo.GotFocus
        Me.cboVenTo.SelectionStart = 0
        Me.cboVenTo.SelectionLength = Len(Me.cboVenTo.Text)

    End Sub

    Private Sub cboVenTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenTo.LostFocus
        Call ValidateCombo(cboVenTo)

    End Sub

    Private Sub cboVenTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenTo.SelectedIndexChanged

    End Sub









End Class
