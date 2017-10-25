Public Class BSP00004
    Public frmLL As frmLneList

    Public rs_SYLNEINF As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF_DSG As DataSet

    Public rs_BSP00004a As New DataSet

    '    Dim Rpt_BSP00004a As BSP00004aRpt

    'Dim objBSGate As Object

    Private Function StrExist(ByVal strCheck As String, ByVal strInput As String) As Boolean
        'True If A Char In strCheck Exist In strInput
        Dim i As Integer
        For i = 0 To Len(strCheck) - 1
            If InStr(Mid(strCheck, i, 1), strInput) > 0 Then
                StrExist = True
                Exit For
            End If
        Next i
    End Function

    Private Sub cboPLFm_Change()
        cboPLTo.Text = cboPLFm.Text
    End Sub

    Private Sub cboPLFm_Click()
        cboPLTo.Text = cboPLFm.Text
    End Sub

    Private Sub cboPLFm_LostFocus()
        If cboPLFm.Text <> "" And Me.txtPLneList.Text <> "" Then
            Me.txtPLneList.Text = ""
        End If
    End Sub

    Private Sub cboPLTo_LostFocus()
        If cboPLTo.Text <> "" And Me.txtPLneList.Text <> "" Then
            Me.txtPLneList.Text = ""
        End If
    End Sub

    Public Function checkInCombo(ByRef cboItm As ComboBox) As Boolean
        Dim i As Integer
        Dim Y As Integer
        Dim bolIn As Boolean
        bolIn = True
        If cboItm.Text <> "" Then
            bolIn = False
            i = cboItm.Items.Count
            If cboItm.Text <> "" And cboItm.Enabled = True And cboItm.Items.Count > 0 Then
                For Y = 0 To i - 1
                    If cboItm.Text = cboItm.Items(Y) Then
                        bolIn = True
                        Exit For
                    End If
                Next

                If bolIn = False Then
                    MsgBox(" Data is Invalid, please select in Drop Down List.")
                    cboItm.Focus()
                    Exit Function
                End If
            End If
        End If
        checkInCombo = bolIn

    End Function

    Private Sub cboVenFm_Change()
        cboVenTo.Text = cboVenFm.Text
    End Sub

    Private Sub cboVenFm_Click()
        cboVenTo.Text = cboVenFm.Text
    End Sub

    Private Sub cboVenFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenFm, KeyCode)
    End Sub

    Private Sub cboVenFm_LostFocus()
        If Me.checkInCombo(cboVenFm) = True Then
            Me.cboVenTo.Text = Me.cboVenFm.Text
        End If
    End Sub

    Private Sub cboVenTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenTo, KeyCode)
    End Sub

    Private Sub cboVenTo_LostFocus()
        Call Me.checkInCombo(cboVenTo)
    End Sub

    Private Sub cmdFindPLne_Click()
        'Dim strTemp As String
        'frmListBox.txtBox = Me.txtPLneList
        'frmListBox.Show(vbModal)
        'tempz

    End Sub


    Private Sub cmdFindPLne_LostFocus()
        If Me.txtPLneList.Text <> "" And (Me.cboPLFm.Text <> "" Or Me.cboPLTo.Text <> "") Then
            Me.cboPLFm.Text = ""
            Me.cboPLTo.Text = ""
        End If
    End Sub

    Private Function removeDuplicateItem(ByVal strInput As String) As String
        Dim intCount As Integer
        Dim strResult As String
        Dim strTemp As String
        Dim strArray() As String
        Dim i As Integer
        Dim j As Integer
        strResult = strInput
        intCount = UBound(Split(strInput, ","))
        If intCount > 0 Then
            ReDim strArray(intCount)
            For i = 0 To intCount
                strArray(i) = Split(strInput, ",")(i)
            Next i
            For i = 0 To UBound(strArray)
                strTemp = strArray(i)
                If strTemp <> "" Then
                    For j = 0 To UBound(strArray)
                        If (i <> j And strArray(j) <> "" And strTemp = strArray(j)) Then
                            strArray(j) = ""
                        End If
                    Next j
                End If
            Next i
            strResult = ""
            For i = 0 To UBound(strArray)
                strResult = strResult & IIf(strArray(i) = "", "", IIf(strResult = "", strArray(i), "," & strArray(i)))
            Next i
        End If
        removeDuplicateItem = strResult
    End Function


    Private Sub cmdShow_Click()

        Dim S As String
        Dim rs As DataSet


        Dim ITMDTEFM As String
        Dim ITMDTETO As String

        Dim SCIDTEFM As String
        Dim SCIDTETO As String

        Dim VENCDEFM As String
        Dim VENCDETO As String

        Dim VITMNOFM As String
        Dim VITMNOTO As String
        Dim VITMNOLIST As String

        Dim PRDLNEFM As String
        Dim PRDLNETO As String
        Dim PRDLNELIST As String

        Dim DSGFM As String
        Dim DSGTO As String

        Dim TITLE As String

        Dim PRINTAMT As String
        Dim ORDERBY As String


        Dim SHOWCUST As String



        '---- Validate Information ----

        If txtItmDateFm.Text <> "  /  /" Then
            If IsDate(txtItmDateFm.Text) = False Then
                MsgBox("Invalid Enter in Item Create Date!")
                txtItmDateFm.Focus()
                Exit Sub
            End If
        End If

        If txtItmDateTo.Text <> "  /  /" Then
            If IsDate(txtItmDateTo.Text) = False Then
                MsgBox("Invalid Enter in Item Create Date!")
                txtItmDateTo.Focus()
                Exit Sub
            End If
        End If

        If txtItmDateFm.Text <> "  /  /" And txtItmDateTo.Text <> "  /  /" Then
            If Mid(txtItmDateFm.Text, 7) > Mid(txtItmDateTo.Text, 7) Then
                MsgBox("Item Create Date: End Date < Start date ! (YY)")
                txtItmDateFm.Focus()
                Call HighlightMask(txtItmDateFm)
                Exit Sub
            ElseIf Mid(txtItmDateFm.Text, 7) = Mid(txtItmDateTo.Text, 7) Then
                If Microsoft.VisualBasic.Left(txtItmDateFm.Text, 2) > Microsoft.VisualBasic.Left(txtItmDateTo.Text, 2) Then
                    MsgBox("Item Create Date: End Date < Start date ! (MM)")
                    txtItmDateFm.Focus()
                    Call HighlightMask(txtItmDateFm)
                    Exit Sub
                ElseIf Microsoft.VisualBasic.Left(txtItmDateFm.Text, 2) = Microsoft.VisualBasic.Left(txtItmDateTo.Text, 2) Then
                    If Mid(txtItmDateFm.Text, 4, 2) > Mid(txtItmDateTo.Text, 4, 2) Then
                        MsgBox("Item Create Date: End Date < Start date ! (DD)")
                        txtItmDateFm.Focus()
                        Call HighlightMask(txtItmDateFm)
                        Exit Sub
                    End If
                End If
            End If
        End If

        If txtItmDateFm.Text = "  /  /" Then
            '    ITMDTEFM = "01/01/1980" + " 00:00:00.000"
            MsgBox("Item Create Date From is empty!")
            txtItmDateFm.Focus()
            Call HighlightMask(txtItmDateFm)
            Exit Sub
        Else
            ITMDTEFM = txtItmDateFm.Text + " 00:00:00.000"
        End If

        If txtItmDateTo.Text = "  /  /" Then
            '    ITMDTETO = "12/31/2049" + " 23:59:59"
            MsgBox("Item Create Date To is empty!")
            txtItmDateTo.Focus()
            Call HighlightMask(txtItmDateTo)
            Exit Sub
        Else
            ITMDTETO = txtItmDateTo.Text + " 23:59:59"
        End If


        If txtSCIssDateFm.Text <> "  /  /" And txtSCIssDateTo.Text <> "  /  /" Then
            If Mid(txtSCIssDateFm.Text, 7) > Mid(txtSCIssDateTo.Text, 7) Then
                MsgBox("S/C Issue Date: End Date < Start date ! (YY)")
                txtSCIssDateFm.Focus()
                Call HighlightMask(txtSCIssDateFm)
                Exit Sub
            ElseIf Mid(txtSCIssDateFm.Text, 7) = Mid(txtSCIssDateTo.Text, 7) Then
                If Microsoft.VisualBasic.Left(txtSCIssDateFm.Text, 2) > Microsoft.VisualBasic.Left(txtSCIssDateTo.Text, 2) Then
                    MsgBox("S/C Issue Date : End Date < Start date ! (MM)")
                    txtSCIssDateFm.Focus()
                    Call HighlightMask(txtSCIssDateFm)
                    Exit Sub
                ElseIf Microsoft.VisualBasic.Left(txtSCIssDateFm.Text, 2) = Microsoft.VisualBasic.Left(txtSCIssDateTo.Text, 2) Then
                    If Mid(txtSCIssDateFm.Text, 4, 2) > Mid(txtSCIssDateTo.Text, 4, 2) Then
                        MsgBox("S/C Issue Date: End Date < Start date ! (DD)")
                        txtSCIssDateFm.Focus()
                        Call HighlightMask(txtSCIssDateFm)
                        Exit Sub
                    End If
                End If
            End If
        End If

        If txtSCIssDateFm.Text = "  /  /" Then
            SCIDTEFM = "01/01/1998 00:00:00.000"
        Else
            SCIDTEFM = txtSCIssDateFm.Text + " 00:00:00.000"
        End If

        If txtSCIssDateTo.Text = "  /  /" Then
            SCIDTETO = "01/01/2050 23:59:59"
        Else
            SCIDTETO = txtSCIssDateTo.Text + " 23:59:59"
        End If


        If InStr(Me.cboVenFm.Text, " - ") <> 0 Then
            VENCDEFM = Trim(Split(Me.cboVenFm.Text, " - ")(0))
        Else
            VENCDEFM = Trim(Me.cboVenFm.Text)
        End If

        If InStr(Me.cboVenTo.Text, " - ") <> 0 Then
            VENCDETO = Trim(Split(Me.cboVenTo.Text, " - ")(0))
        Else
            VENCDETO = Trim(Me.cboVenTo.Text)
        End If

        VITMNOFM = Trim(txtItmNoFm.Text)
        VITMNOTO = Trim(txtItmNoTo.Text)

        If (VITMNOFM > VITMNOTO) Then
            MsgBox("Range of Vendor Item No From should be smaller than Vendor Item No To!")
            txtItmNoFm.Focus()
            Exit Sub
        End If

        If Trim(Me.txtItmList.Text) = "" Then
            VITMNOLIST = ""
        Else
            If Len(Me.txtItmList.Text) > 1000 Then
                MsgBox("The Item List Is Too Long!")
                Exit Sub
            End If
            VITMNOLIST = removeDuplicateItem(Trim(Me.txtItmList.Text))
            VITMNOLIST = Replace(VITMNOLIST, "'", "''")
        End If

        PRDLNEFM = Trim(cboPLFm.Text)
        PRDLNETO = Trim(cboPLTo.Text)

        If (PRDLNEFM > PRDLNETO) Then
            MsgBox("Range of Product Line From should be smaller then Product Line To!")
            cboPLFm.Focus()
            Exit Sub
        End If

        If Trim(Me.txtPLneList.Text) = "" Then
            PRDLNELIST = ""
        Else
            If Len(Me.txtPLneList.Text) > 1000 Then
                MsgBox("The Product Line List Is Too Long")
                Exit Sub
            End If
            PRDLNELIST = removeDuplicateItem(Trim(Me.txtPLneList.Text))
            PRDLNELIST = Replace(PRDLNELIST, "'", "''")
        End If


        If Me.cboDsg_Fm.Text = "" Then
            DSGFM = ""
        ElseIf InStr(Me.cboDsg_Fm.Text, " - ") <> 0 Then
            DSGFM = Trim(Split(Me.cboDsg_Fm.Text, " - ")(0))
        Else
            DSGFM = Trim(Me.cboDsg_Fm.Text)
        End If

        If Me.cboDsg_To.Text = "" Then
            DSGTO = ""
        ElseIf InStr(Me.cboDsg_To.Text, "-") <> 0 Then
            DSGTO = Trim(Split(Me.cboDsg_To.Text, " - ")(0))
        Else
            DSGTO = Trim(Me.cboDsg_To.Text)
        End If


        TITLE = Trim(txtTitle.Text)

        If optByQty.checked = True Then
            ORDERBY = "Q"
        Else
            ORDERBY = "A"
        End If

        Dim PRINTAMOUNT

        If optPrintAmountYes.Checked = True Then
            PRINTAMOUNT = "Y"
        Else
            PRINTAMOUNT = "N"
        End If


        If optShowCustYes.Checked = True Then
            SHOWCUST = "Y"
        Else
            SHOWCUST = "N"
        End If


        S = "sp_list_BSP00004a   '','" & _
            ITMDTEFM & "','" & ITMDTETO & "','" & _
            SCIDTEFM & "','" & SCIDTETO & "','" & _
            VENCDEFM & "','" & VENCDETO & "','" & "" & "','" & _
            VITMNOFM & "','" & VITMNOTO & "','" & VITMNOLIST & "','" & _
            PRDLNEFM & "','" & PRDLNETO & "','" & PRDLNELIST & "','" & _
            DSGFM & "','" & DSGTO & "','" & _
            ORDERBY & "','" & PRINTAMOUNT & "','" & TITLE & "','" & SHOWCUST & "','X'"



        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_BSP00004a, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            If rs_BSP00004a.Tables("RESULT").Rows.Count = 0 Then
                Cursor = Cursors.Default
                MsgBox("No Record Found!")
                Exit Sub
            Else
                Dim objRpt As New BSP00004aRpt
                objRpt.SetDataSource(rs_BSP00004a.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

            End If
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub FillcboVenCde()
        cboVenFm.Items.Clear()
        cboVenTo.Items.Clear()

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            With rs_VNBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                    cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                Next
            End With


        End If
    End Sub

    Private Sub Form_Load()

        Me.Icon = ERP00000new.Icon

        Dim S As String
        Dim rs As DataSet

        '#If useMTS Then
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        Call Formstartup(Me.Name)

        Cursor = Cursors.WaitCursor

        S = "sp_list_SYLNEINF '' "
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYLNEINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboLneinf()
        End If

        S = "sp_list_VNBASINF '' "
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboVenCde()
        End If

        S = "sp_select_SYLNEINF '' , 15 "
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_DSG, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboDsg()
        End If

        cmbImageOnly.Items.Add("With Photo")
        cmbImageOnly.Items.Add("Text Only")
        cmbImageOnly.SelectedIndex = 0

        Cursor = Cursors.Default


    End Sub

    Private Sub optShowCustNo_Click()

    End Sub

    Private Sub txtItmNoFm_Change()
        txtItmNoTo.Text = txtItmNoFm.Text
    End Sub

    'Private Sub txtPrdLneFm_Change()
    '    txtPrdLneTo.Text = txtPrdLneFm.Text
    'End Sub

    Private Sub txtItmNoFm_GotFocus()
        Call HighlightText(txtItmNoFm)
    End Sub

    Private Sub txtItmNoFm_LostFocus()
        If Me.txtItmNoFm.Text <> "" And Me.txtItmList.Text <> "" Then
            Me.txtItmList.Text = ""
        End If
    End Sub

    Private Sub txtItmNoTo_GotFocus()
        Call HighlightText(txtItmNoTo)
    End Sub

    Private Sub txtItmNoTo_LostFocus()
        If Me.txtItmNoTo.Text <> "" And Me.txtItmList.Text <> "" Then
            Me.txtItmList.Text = ""
        End If
    End Sub


    Private Sub txtPLneList_LostFocus()
        If Me.txtPLneList.Text <> "" And (Me.cboPLFm.Text <> "" Or Me.cboPLTo.Text <> "") Then
            Me.cboPLFm.Text = ""
            Me.cboPLTo.Text = ""
        End If
    End Sub

    Private Sub txtItmDateFm_Change()
        txtItmDateTo.Text = txtItmDateFm.Text
    End Sub

    Private Sub FillcboLneinf()
        If rs_SYLNEINF.Tables("RESULT").Rows.Count > 0 Then
            With rs_SYLNEINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboPLFm.Items.Add(rs_SYLNEINF.Tables("RESULT").Rows(index)("yli_lnecde"))
                    cboPLTo.Items.Add(rs_SYLNEINF.Tables("RESULT").Rows(index)("yli_lnecde"))
                Next
            End With

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
            'If Ctrl.List(Ctrl.SelectedIndex) <> "" Then
            '    If UBound(Split(Ctrl.List(Ctrl.SelectedIndex), " - ")) > 0 Then
            '        GetCtrlValue = Split(Ctrl.List(Ctrl.SelectedIndex), " - ")(0)
            '    Else
            '        GetCtrlValue = Ctrl.List(Ctrl.SelectedIndex)
            '    End If
            'Else
            '    GetCtrlValue = ""
            'End If
        End If
    End Function

    Private Sub txtItmDateFm_GotFocus()
        Call HighlightMask(txtItmDateFm)
    End Sub

    Private Sub txtItmDateTo_GotFocus()
        Call HighlightMask(txtItmDateTo)
    End Sub

    Private Sub txtItmList_LostFocus()
        If Me.txtItmList.Text <> "" And Me.txtItmNoFm.Text <> "" Then
            Me.txtItmNoFm.Text = ""
            Me.txtItmNoTo.Text = ""
        End If
    End Sub


    Private Sub cboDsg_Fm_Change()
        cboDsg_To.Text = cboDsg_Fm.Text
    End Sub

    Private Sub cboDsg_Fm_Click()
        cboDsg_To.Text = cboDsg_Fm.Text
    End Sub

    Private Sub cboDsg_Fm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboDsg_Fm, KeyCode)
    End Sub

    Private Sub cboDsg_Fm_LostFocus()
        If Me.checkInCombo(cboDsg_Fm) = True Then
            Me.cboDsg_To.Text = Me.cboDsg_Fm.Text
        End If
    End Sub

    Private Sub cboDsg_To_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboDsg_To, KeyCode)
    End Sub


    Private Sub FillcboDsg()
        cboDsg_Fm.Items.Clear()
        cboDsg_To.Items.Clear()
        If rs_SYSETINF_DSG.Tables("RESULT").Rows.Count > 0 Then

            With rs_SYSETINF_DSG
                For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                    cboDsg_Fm.Items.Add(rs_SYSETINF_DSG.Tables("RESULT").Rows(index)("yli_lnecde") & " - " & rs_SYSETINF_DSG.Tables("RESULT").Rows(index)("yli_lnedsc"))
                    cboDsg_To.Items.Add(rs_SYSETINF_DSG.Tables("RESULT").Rows(index)("yli_lnecde") & " - " & rs_SYSETINF_DSG.Tables("RESULT").Rows(index)("yli_lnedsc"))
                Next
            End With

        End If
    End Sub



    Private Sub BSP00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        cmdShow_Click()

    End Sub

    Private Sub optPrintAmountYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPrintAmountYes.CheckedChanged

    End Sub

    Private Sub optPrintAmountNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPrintAmountNo.CheckedChanged

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub optByAmt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optByAmt.CheckedChanged

    End Sub

    Private Sub optByQty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optByQty.CheckedChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cmbImageOnly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbImageOnly.SelectedIndexChanged

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub cboPLFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPLFm.LostFocus
        If cboPLFm.Text <> "" And Me.txtPLneList.Text <> "" Then
            Me.txtPLneList.Text = ""
        End If

    End Sub

    Private Sub cboPLFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPLFm.SelectedIndexChanged
        cboPLTo.Text = cboPLFm.Text

    End Sub

    Private Sub cboPLTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPLTo.LostFocus
        If cboPLTo.Text <> "" And Me.txtPLneList.Text <> "" Then
            Me.txtPLneList.Text = ""
        End If

    End Sub

    Private Sub cboPLTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPLTo.SelectedIndexChanged

    End Sub

    Private Sub txtItmNoFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNoFm.GotFocus
        Call HighlightText(txtItmNoFm)
    End Sub

    Private Sub txtItmNoFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNoFm.LostFocus
        If Me.txtItmNoFm.Text <> "" And Me.txtItmList.Text <> "" Then
            Me.txtItmList.Text = ""
        End If

    End Sub

    Private Sub txtItmNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNoFm.TextChanged
        cboVenTo.Text = cboVenFm.Text

    End Sub

    Private Sub cboVenFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenFm.LostFocus
        If Me.checkInCombo(cboVenFm) = True Then
            Me.cboVenTo.Text = Me.cboVenFm.Text
        End If

    End Sub

    Private Sub cboVenFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenFm.SelectedIndexChanged
        cboVenTo.Text = cboVenFm.Text

    End Sub

    Private Sub cboVenTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenTo.LostFocus
        Call Me.checkInCombo(cboVenTo)

    End Sub

    Private Sub cboVenTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenTo.SelectedIndexChanged

    End Sub

    Private Sub cmdFindPLne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindPLne.Click
        Dim strTemp As String
        'frmListBox.txtBox = Me.txtPLneList
        'frmListBox.Show(vbModal)

        frmLL = New frmLneList
        frmLL.ma = Me
        frmLL.txtBox = Me.txtPLneList

        frmLL.ShowDialog()

    End Sub

    Private Sub cmdFindPLne_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFindPLne.LostFocus
        If Me.txtPLneList.Text <> "" And (Me.cboPLFm.Text <> "" Or Me.cboPLTo.Text <> "") Then
            Me.cboPLFm.Text = ""
            Me.cboPLTo.Text = ""
        End If

    End Sub

    Private Sub txtItmNoTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNoTo.GotFocus
        Call HighlightText(txtItmNoTo)

    End Sub

    Private Sub txtItmNoTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNoTo.LostFocus
        If Me.txtItmNoTo.Text <> "" And Me.txtItmList.Text <> "" Then
            Me.txtItmList.Text = ""
        End If

    End Sub

    Private Sub txtItmNoTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNoTo.TextChanged

    End Sub

    Private Sub txtPLneList_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPLneList.LostFocus
        If Me.txtPLneList.Text <> "" And (Me.cboPLFm.Text <> "" Or Me.cboPLTo.Text <> "") Then
            Me.cboPLFm.Text = ""
            Me.cboPLTo.Text = ""
        End If

    End Sub

    Private Sub txtPLneList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLneList.TextChanged

    End Sub

    Private Sub txtItmDateFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmDateFm.GotFocus
        Call HighlightMask(txtItmDateFm)

    End Sub

    Private Sub txtItmDateFm_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtItmDateFm.MaskInputRejected

    End Sub

    Private Sub txtItmDateFm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmDateFm.TextChanged
        txtItmDateTo.Text = txtItmDateFm.Text

    End Sub

    Private Sub txtItmDateTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmDateTo.GotFocus
        Call HighlightMask(txtItmDateTo)

    End Sub

    Private Sub txtItmDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtItmDateTo.MaskInputRejected

    End Sub

    Private Sub txtItmList_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmList.LostFocus
        If Me.txtItmList.Text <> "" And Me.txtItmNoFm.Text <> "" Then
            Me.txtItmNoFm.Text = ""
            Me.txtItmNoTo.Text = ""
        End If

    End Sub

    Private Sub txtItmList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmList.TextChanged

    End Sub

    Private Sub cboDsg_Fm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDsg_Fm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboDsg_Fm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDsg_Fm.LostFocus
        If Me.checkInCombo(cboDsg_Fm) = True Then
            Me.cboDsg_To.Text = Me.cboDsg_Fm.Text
        End If

    End Sub

    Private Sub cboDsg_Fm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDsg_Fm.SelectedIndexChanged
        cboDsg_To.Text = cboDsg_Fm.Text

    End Sub

    Private Sub cboDsg_To_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDsg_To.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboDsg_To_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDsg_To.SelectedIndexChanged

    End Sub
End Class
