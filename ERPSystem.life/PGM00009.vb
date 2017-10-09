Public Class PGM00009
    Dim txtbox As TextBox = Nothing
    Dim rs_VNBASINF As DataSet
    Dim rs_PKIMBAIF As DataSet
    Dim rs_PKINVHDR As DataSet
    Dim rs_syswasge As DataSet
    Dim rs_TOSCDETAIL As DataSet
    Dim rs_TOSCDETAIL_tmp As DataSet
    Dim rs_VNBASINF_02 As DataSet
    Dim rs_SCORDHDR As DataSet
    Dim rs_TOORDHDR As DataSet
    Dim rs_VNCNTINF As DataSet
    Dim rs_VNCTNPER As DataSet
    Dim rs_ListPkinvhdr As DataSet
    Dim rs_InvStock As DataSet
    Dim dgPkgITem_cocde As Integer
    Dim dgPkgITem_ordno As Integer
    Dim dgPkgITem_seq As Integer
    Dim dgPkgITem_realitem As Integer
    Dim dgPkgITem_tempitem As Integer
    Dim dgPkgITem_venno As Integer
    Dim dgPkgITem_venitem As Integer
    Dim dgPkgITem_stqty As Integer
    Dim dgPkgItem_colcde As Integer
    Dim dgPkgITem_um As Integer
    Dim dgPkgITem_inr As Integer
    Dim dgPkgITem_mst As Integer
    Dim dgPkgItem_cft As Integer
    Dim dgPkgITem_ftyprctrm As Integer
    Dim dgPkgITem_hkprctrm As Integer
    Dim dgPkgITem_trantrm As Integer
    Dim dgPkgITem_Terms As Integer
    Dim dgPkgITem_curcde As Integer
    Dim dgPkgITem_Scno As Integer
    Dim dgPkgITem_ScSeq As Integer
    Dim dgPkgITem_ScItem As Integer
    Dim dgPkgItem_ScQty As Integer
    Dim dgPkgITem_cusitem As Integer
    Dim dgPkgITem_sku As Integer
    Dim dgPkgItem_assitem As Integer
    Dim dgPKGITEM_GEN As Integer
    Dim dgPkgITem_ordqty As Integer
    Dim dgPkgITem_conftr As Integer
    Dim dgPkgITem_flag As Integer

    Dim rs_pkmltshp As DataSet
    Dim rs_pkordrec As DataSet
    Dim rs_VNBASINF_MS As DataSet
    Dim rs_PKINVHDR2 As DataSet
    Dim rs_PKIMBAIF2 As DataSet
    Dim rs_TOSCDETAIL_C As DataSet
    Dim flag_grdDetail_keypress As Boolean
    Dim flag_grdDetail_summary_keypress As Boolean
    Dim NewOrderNo As String
    Dim NewPKGREQHDR As String

    Dim dgMltShpEditCellRow As Integer
    Dim dgMltShpEditCellCol As Integer




    Private Sub PGM00009_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sFirstYear As String
        Dim sSecondYear As String
        Dim sSecondMonth As String
        Dim sSecondDay As String

        optStatusG.Checked = True
        optStatusN.Checked = False

        btcPGM00009.SelectTab(0)
        btcPGM00009.TabPages(1).Enabled = False
        btcPGM00009.TabPages(2).Enabled = False
        btcPGM00009.TabPages(0).Enabled = True
        txtOrdQty.Enabled = False
        cboVendor.Enabled = False
        cboAddress.Enabled = False
        cboCntPer.Enabled = False
        gp_search.Enabled = False


        sFirstYear = (Today.Year().ToString)
        sFirstYear = sFirstYear - 1
        sSecondYear = sFirstYear + 1

        sSecondMonth = (Today.Month().ToString)
        If sSecondMonth.Length = 1 Then
            sSecondMonth = "0" & sSecondMonth
        End If
        sSecondDay = (Today.Day().ToString)
        If sSecondDay.Length = 1 Then
            sSecondDay = "0" & sSecondDay
        End If
        '        txt_S_SCIssdatFm.Text = Format(Today.Date, "MM/dd/yyyy")
        txt_S_SCIssdatFm.Text = sSecondMonth & "/" & sSecondDay & "/" & sFirstYear
        txt_S_SCIssdatTo.Text = sSecondMonth & "/" & sSecondDay & "/" & sSecondYear

        FillCompCombo(gsUsrID, cboCoCde)        'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Starup position
        cmdApply.Enabled = False
        grdDetail.Enabled = False
        'grdDetailSet.Enabled = False
        Me.Cursor = Windows.Forms.Cursors.Default


        gspStr = "sp_select_PKMTLSHP '" & cboCoCde.Text & "','" & "efwfwfbhqe3ref37" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_pkmltshp, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading PGM00009_Load sp_select_PKMLTSHP :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_VNBASINF_PD ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading PGM00009_Load sp_list_VNBASINF_PD :" & rtnStr)
            Exit Sub
        End If



        gspStr = "sp_list_VNBASINF_PKG02 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_02, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading PGM00009_Load sp_list_VNBASINF_PKG02 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNCNTINF_PG09 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading PGM00009_Load sp_list_VNCNTINF_PG09 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNCTNPER_PG09 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCTNPER, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading PGM00009_Load sp_list_VNCTNPER_PG09 :" & rtnStr)
            Exit Sub
        End If







        format_cboVendor()
        AddHandler grdDetail.EditingControlShowing, AddressOf grdDetail_EditingControlShowing
        AddHandler grdDetail.CellLeave, AddressOf grdDetail_CellLeave


        AddHandler grdDetail_summary.EditingControlShowing, AddressOf grdDetail_summary_EditingControlShowing
        AddHandler grdDetail_summary.CellLeave, AddressOf grdDetail_summary_CellLeave


        txtPkgItem.Select()

        gspStr = "sp_list_VNBASINF_NOT_PD ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_MS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00009_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If

        panelMoveTimer = New Timer()
        panelMoveTimer.Interval = 2
        panelMoveTimer.Enabled = True

        AddHandler panelMoveTimer.Tick, AddressOf panelMoveTimer_Tick
        'AddHandler grdDetailSet.EditingControlShowing, AddressOf grdDetailSet_EditingControlShowing
        'AddHandler grdDetailSet.CellLeave, AddressOf grdDetailSet_CellLeave
    End Sub

    Private Sub format_cboVendor()
        Dim i As Integer
        Dim strList As String

        cboVendor.Items.Clear()
        cboVendor.Items.Add("")

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboVendor.Items.Add(strList)

                End If
            Next i
        End If



    End Sub

   
    Private Sub grdDetailSet_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'if the editing control is not nothing, unsubscribe the KeyPressevent
        If Not (txtbox Is Nothing) Then
            RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
        End If




    End Sub

    Private Sub grdDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.ColumnIndex = dgPKGITEM_GEN Then
            If grdDetail.Item(dgPKGITEM_GEN, grdDetail.CurrentCell.RowIndex).Value = "N" Then
                grdDetail.Item(dgPKGITEM_GEN, grdDetail.CurrentCell.RowIndex).Value = "Y"
            ElseIf grdDetail.Item(dgPKGITEM_GEN, grdDetail.CurrentCell.RowIndex).Value = "Y" Then
                grdDetail.Item(dgPKGITEM_GEN, grdDetail.CurrentCell.RowIndex).Value = "N"
            Else
                grdDetail.Item(dgPKGITEM_GEN, grdDetail.CurrentCell.RowIndex).Value = "N"
            End If

            Call cal_grip_qty()

        End If








    End Sub




    Private Sub grdDetail_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDetail.EditingControlShowing

        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            If grdDetail.CurrentCell.ColumnIndex = 9 Or grdDetail.CurrentCell.ColumnIndex = 13 Then
                txtbox.MaxLength = 9
                AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
            End If

            If grdDetail.CurrentCell.ColumnIndex = 13 Then
                AddHandler txtbox.TextChanged, AddressOf txt_grdDetail_TextChanged

            End If

        End If
    End Sub
    Private Sub txt_grdDetail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call cal_grip_qty()
    End Sub


    Private Sub grdDetail_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellLeave

        'if the editing control is not nothing, unsubscribe the KeyPressevent

        '        Call cal_grip_qty()

        If Not (txtbox Is Nothing) Then
            RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
        End If

        'rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(8) = rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(6) + rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(7)


    End Sub
    Private Sub grdDetailSet_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            txtbox.MaxLength = 4
            AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress

        End If
    End Sub

    Private Sub txtBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If grdDetail.col = 6 Or grdDetail.col = 7 Then
        '    If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '        KeyAscii = 0
        '    End If



        If Not (e.KeyChar = vbBack Or e.KeyChar = ChrW(Keys.Delete) Or e.KeyChar = ChrW(Keys.Enter) Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If

        'If grdDetail.col = 6 Then
        '    If (Len(grdDetail.Columns(6).Text) + 1 > 4) And KeyAscii > 31 Then
        '        'Msg ("M00018")
        '        KeyAscii = 0
        '        grdDetail.SetFocus()
        '    End If
        'ElseIf grdDetail.col = 7 Then
        '    If (Len(grdDetail.Columns(7).Text) + 1 > 4) And KeyAscii > 31 Then
        '        'Msg ("M00018")
        '        KeyAscii = 0
        '        grdDetail.SetFocus()
        '    End If
        'End If
        Dim iRow As Integer = grdDetail.CurrentCell.RowIndex
        Dim iCol As Integer = grdDetail.CurrentCell.ColumnIndex

        If iCol = 13 Then
            flag_grdDetail_keypress = True
        End If


    End Sub

    Private Sub cboVendor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendor.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If Trim(cboVendor.Text) = "" Then
                MsgBox("Please select vendor.")
                Exit Sub
            End If

            If checkValidCombo(cboVendor, cboVendor.Text) = False Then
                MsgBox("Data Invalid")
                cboVendor.Text = ""
                Exit Sub
            End If


            cboVendor.Enabled = False
            cboAddress.Enabled = False
            cboCntPer.Enabled = False
            gp_search.Enabled = True
            cboCoCde.Focus()

        End If


    End Sub

    Private Sub cboVendor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVendor.KeyUp
        auto_search_combo(cboVendor, e.KeyCode)
    End Sub

    Private Sub cboVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendor.SelectedIndexChanged
        Dim dr() As DataRow
        dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & Split(cboVendor.Text, " - ")(0) & "'")

        If dr.Length <> 0 Then

            txtPkgUnitPriCur.Text = dr(0)("vbi_curcde").ToString
            txtTtlAmtCur.Text = dr(0)("vbi_curcde").ToString

        End If

        cboAddress.Items.Clear()
        cboAddress.Items.Add("")
        cboAddress.Text = ""
        Dim dr_address() As DataRow
        dr_address = rs_VNCNTINF.Tables("RESULT").Select("vci_venno = '" & Split(cboVendor.Text, " - ")(0) & "'")
        If dr_address.Length <> 0 Then 
            For i As Integer = 0 To dr_address.Length - 1
                cboAddress.Items.Add(dr_address(i)("vci_adr"))
            Next
        End If

        If dr_address.Length <> 0 Then
            cboAddress.SelectedIndex = 1
        End If



        cboCntPer.Items.Clear()
        cboCntPer.Items.Add("")
        cboCntPer.Text = ""
        Dim dr_CTNPER() As DataRow
        dr_CTNPER = rs_VNCTNPER.Tables("RESULT").Select("vci_venno = '" & Split(cboVendor.Text, " - ")(0) & "'")
        If dr_CTNPER.Length <> 0 Then
            For i As Integer = 0 To dr_CTNPER.Length - 1
                cboCntPer.Items.Add(dr_CTNPER(i)("vci_cntctp"))
            Next
        End If

        Dim def_CTNPER() As DataRow
        def_CTNPER = rs_VNCTNPER.Tables("RESULT").Select("vci_cntdef = 'Y' and vci_cnttyp = 'SALE' and vci_venno = '" & Split(cboVendor.Text, " - ")(0) & "'")
        If def_CTNPER.Length <> 0 Then
            cboCntPer.Text = def_CTNPER(0)("vci_cntctp")
        End If


        If Trim(cboVendor.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboVendor, cboVendor.Text) = False Then
            MsgBox("Data Invalid")
            cboVendor.Text = ""
            Exit Sub
        End If




    End Sub

    Private Sub cboVendor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVendor.Validated
        If Trim(cboVendor.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboVendor, cboVendor.Text) = False Then
            MsgBox("Data Invalid")
            cboVendor.Text = ""
            Exit Sub
        End If

    End Sub

    Private Sub rdoIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoIn.CheckedChanged
        'Call cal_stk_and_ttlordqty()

    End Sub

    Private Sub rdoIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoIn.Click
        txtStkQty.Text = 0
        Call cal_grip_qty2()

        'If IsNumeric(txtStkQty.Text) = False Then
        '    Exit Sub
        'End If

        'If rdoIn.Checked = True Then


        '    Dim current As Integer = txtStkQty.Text

        '    If current > 0 Then
        '        Exit Sub
        '    Else
        '        txtStkQty.Text = current * -1
        '    End If


        'ElseIf rdoOut.Checked = True Then

        '    Dim current As Integer = txtStkQty.Text

        '    If current >= 0 Then
        '        txtStkQty.Text = current * -1
        '    Else
        '        Exit Sub
        '    End If


        'End If




    End Sub

    Private Sub rdoOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOut.CheckedChanged
        'Call cal_stk_and_ttlordqty()
    End Sub

    Private Sub rdoOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoOut.Click
        Call cal_stk_and_ttlordqty()
        Call cal_grip_qty2()

        'If IsNumeric(txtStkQty.Text) = False Then
        '    Exit Sub
        'End If

        'If rdoIn.Checked = True Then


        '    Dim current As Integer = txtStkQty.Text

        '    If current > 0 Then
        '        Exit Sub
        '    Else
        '        txtStkQty.Text = current * -1
        '    End If


        'ElseIf rdoOut.Checked = True Then

        '    Dim current As Integer = txtStkQty.Text

        '    If current >= 0 Then
        '        txtStkQty.Text = current * -1
        '    Else
        '        Exit Sub
        '    End If


        'End If
    End Sub

    Private Sub txtStkQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStkQty.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 13) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
    End Sub

    Private Sub txtStkQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStkQty.TextChanged
        cal_grip_qty3()
    End Sub

    Private Sub txtStkQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStkQty.Validated

        If IsNumeric(txtStkQty.Text) = False Then
            Exit Sub
        End If

        If rdoIn.Checked = True Then


            Dim current As Integer = txtStkQty.Text

            If current > 0 Then
                Exit Sub
            Else
                txtStkQty.Text = current * -1
            End If


        ElseIf rdoOut.Checked = True Then

            Dim ttlordqty As Integer
            Dim wasqty As Integer

            If txtOrdQty.Text <> "" Then
                ttlordqty = txtOrdQty.Text
            Else
                ttlordqty = 0
            End If

            If txtWasQty.Text <> "" Then
                wasqty = txtWasQty.Text
            Else
                wasqty = 0
            End If




            Dim temp_sum As Integer

            Dim index1 As Integer
            'gspStr = "sp_select_PKINVDTL ''"
            'rtnLong = execute_SQLStatement(gspStr, rs_PKINVHDR2, rtnStr)
            'If rtnLong <> RC_SUCCESS Then
            '    Cursor = Cursors.Default
            '    MsgBox("Error on loading cmdFind_Click sp_list_PKINVHDR :" & rtnStr)
            '    Exit Sub
            'End If

            For index1 = 0 To rs_PKINVHDR2.Tables("RESULT").Rows.Count - 1
                If UCase(rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_pkgitm")) = UCase(txtPkgItem.Text) Then
                    temp_sum = temp_sum + rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_avlqty")
                End If
            Next





            Dim currentStkqty As Integer
            currentStkqty = txtStkQty.Text
            If Not currentStkqty >= 0 Then
                currentStkqty = currentStkqty * -1
            End If


            If currentStkqty > ttlordqty + wasqty Then
                txtStkQty.Text = ttlordqty + wasqty
            End If

            If currentStkqty > temp_sum Then
                txtStkQty.Text = temp_sum
            End If


            Dim current As Integer = txtStkQty.Text

            If current >= 0 Then
                txtStkQty.Text = current * -1
            Else
                Exit Sub
            End If


        End If
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Dim strMsg As String

        If Trim(txt_S_SCNo.Text) <> "" And Trim(txt_S_TONo.Text) = "" Then
            strMsg = "The following Sales Conf.(s) will be used as search criteria" & vbCrLf & _
                   vbCrLf & "       Sales Conf. :" & txt_S_SCNo.Text & vbCrLf & _
                  vbCrLf & strMsg & _
                  vbCrLf & vbCrLf & "" & vbCrLf & _
                  "Are you sure to search?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "") = MsgBoxResult.No Then
                Exit Sub

            End If

        ElseIf Trim(txt_S_SCNo.Text) = "" And Trim(txt_S_TONo.Text) <> "" Then
            strMsg = "The following Tentative Order(s) will be used as search criteria" & vbCrLf & _
                 vbCrLf & "Tentative Order :" & txt_S_TONo.Text & vbCrLf & _
                  vbCrLf & strMsg & _
                  vbCrLf & vbCrLf & "" & vbCrLf & _
                  "Are you sure to search?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "") = MsgBoxResult.No Then
                Exit Sub

            End If

        ElseIf Trim(txt_S_SCNo.Text) <> "" And Trim(txt_S_TONo.Text) <> "" Then

            strMsg = "The following Sales Conf.(s) and Tentative Order(s) will be used as search criteria" & vbCrLf & _
                   vbCrLf & "       Sales Conf. :" & txt_S_SCNo.Text & vbCrLf & _
                   vbCrLf & "Tentative Order :" & txt_S_TONo.Text & vbCrLf & _
                  vbCrLf & strMsg & _
                  vbCrLf & vbCrLf & "" & vbCrLf & _
                  "Are you sure to search?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "") = MsgBoxResult.No Then
                Exit Sub

            End If

        End If





        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        Dim SCIssdatFM As String
        Dim SCIssdatTO As String
        Dim SCNO As String
        Dim TONO As String
        Dim ITMNOLIST As String
        Dim flagcheck As Integer
        flagcheck = 0


        If Trim(Me.txt_S_PriCust.Text) = "" Then
            CUS1NOLIST = ""
        Else
            If Len(Me.txt_S_PriCust.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            CUS1NOLIST = removeduplicateItem(Trim(Me.txt_S_PriCust.Text))
            CUS1NOLIST = CUS1NOLIST.Replace("'", "''")
        End If

        If Trim(Me.txt_S_SecCust.Text) = "" Then
            CUS2NOLIST = ""
        Else
            If Len(Me.txt_S_SecCust.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Secondary Customer List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            CUS2NOLIST = Trim(Me.txt_S_SecCust.Text)
            CUS2NOLIST = CUS2NOLIST.Replace("'", "''")
        End If
        'CUS2NOLIST = ""

        If Me.txt_S_SCIssdatFm.Text <> "__/__/____" Then
            If Not IsDate(Me.txt_S_SCIssdatFm.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SCIssdatFm.Focus()
                flagcheck = 1
                Exit Sub
            End If
        Else
            MsgBox("Please input the issue date range.")
        End If


        If Mid(txt_S_SCIssdatFm.Text, 7) > Mid(txt_S_SCIssdatTo.Text, 7) Then
            MsgBox("Issue Date: End Date < Start date ! (YY)")
            txt_S_SCIssdatFm.Focus()
            Exit Sub
        ElseIf Mid(txt_S_SCIssdatFm.Text, 7) = Mid(txt_S_SCIssdatTo.Text, 7) Then
            If Strings.Left(txt_S_SCIssdatFm.Text, 2) > Strings.Left(txt_S_SCIssdatTo.Text, 2) Then
                MsgBox("Issue Date: End Date < Start date ! (MM)")
                txt_S_SCIssdatFm.Focus()
                Exit Sub
            ElseIf Strings.Left(txt_S_SCIssdatFm.Text, 2) = Strings.Left(txt_S_SCIssdatTo.Text, 2) Then
                If Mid(txt_S_SCIssdatFm.Text, 4, 2) > Mid(txt_S_SCIssdatTo.Text, 4, 2) Then
                    MsgBox("Issue Date: End Date < Start date ! (DD)")
                    txt_S_SCIssdatFm.Focus()
                    Exit Sub
                End If
            End If
        End If




        If txt_S_SCIssdatFm.Text <> "  /  /" Then
            If IsDate(txt_S_SCIssdatFm.Text) = False Then
                MsgBox("Invalid Enter in Issue Date!")
                txt_S_SCIssdatFm.Focus()
                Exit Sub
            End If
        End If

        If txt_S_SCIssdatTo.Text <> "  /  /" Then
            If IsDate(txt_S_SCIssdatTo.Text) = False Then
                MsgBox("Invalid Enter in Issue Date!")
                txt_S_SCIssdatTo.Focus()
                Exit Sub
            End If
        End If


        If Me.txt_S_SCIssdatTo.Text <> "__/__/____" Then
            If Not IsDate(Me.txt_S_SCIssdatTo.Text) And flagcheck = 0 Then
                MsgBox("Invalid Date Format")
                Me.txt_S_SCIssdatTo.Focus()
                flagcheck = 1
                Exit Sub
            End If
        Else
            MsgBox("Please input the issue date range.")
        End If

        If Mid(Me.txt_S_SCIssdatFm.Text, 7) > Mid(Me.txt_S_SCIssdatTo.Text, 7) And flagcheck = 0 Then
            MsgBox("Claim by Customer Confirmed Date: End Date < Start Date (YY)")
            Me.txt_S_SCIssdatFm.Focus()
            flagcheck = 1
            Exit Sub
        ElseIf Mid(Me.txt_S_SCIssdatFm.Text, 7) = Mid(Me.txt_S_SCIssdatTo.Text, 7) Then
            If Me.txt_S_SCIssdatFm.Text.Substring(0, 2) > Me.txt_S_SCIssdatTo.Text.Substring(0, 2) And flagcheck = 0 Then
                MsgBox("Claim by Customer Confirmed Date: End Date < Start Date (MM)")
                Me.txt_S_SCIssdatFm.Focus()
                flagcheck = 1
                Exit Sub
            ElseIf Me.txt_S_SCIssdatFm.Text.Substring(0, 2) = Me.txt_S_SCIssdatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SCIssdatFm.Text.Substring(3, 2) > Me.txt_S_SCIssdatTo.Text.Substring(3, 2) And flagcheck = 0 Then
                    MsgBox("Claim by Customer Confirmed Date: End Date < Start Date (DD)")
                    Me.txt_S_SCIssdatFm.Focus()
                    flagcheck = 1
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_SCIssdatFm.Text = "__/__/____" Then
            SCIssdatFM = "01/01/1900"
        Else
            SCIssdatFM = Me.txt_S_SCIssdatFm.Text
        End If

        If Me.txt_S_SCIssdatTo.Text = "__/__/____" Then
            SCIssdatTO = "01/01/1900"
        Else
            SCIssdatTO = Me.txt_S_SCIssdatTo.Text
        End If




        If Trim(Me.txt_S_SCNo.Text) = "" Then
            SCNO = ""
        Else
            If Len(Me.txt_S_SCNo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The SC No is too long (1000 char)")
                flagcheck = 1
                Exit Sub
            End If
            SCNO = removeduplicateItem(Trim(Me.txt_S_SCNo.Text))
            SCNO = SCNO.Replace("'", "''")
        End If

        If Trim(Me.txt_S_TONo.Text) = "" Then
            TONO = ""
        Else
            If Len(Me.txt_S_TONo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The PO No is too long (1000 char)")
                flagcheck = 1
                Exit Sub
            End If
            TONO = removeduplicateItem(Trim(Me.txt_S_TONo.Text))
            TONO = TONO.Replace("'", "''")
        End If


        If Trim(Me.txt_S_ItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(Me.txt_S_ItmNo.Text) > 1000 And flagcheck = 0 Then
                MsgBox("The Item No List is too long (1000 char)")
                flagcheck = 1
                'Exit Sub
            End If
            ITMNOLIST = removeduplicateItem(Trim(Me.txt_S_ItmNo.Text))
            ITMNOLIST = ITMNOLIST.Replace("'", "''")
        End If

        ''''''''''''''

        If Trim(txtPkgItem.Text) = "" Then
            Me.Cursor = Cursors.Default
            MsgBox("Please input Packaging Item.")
            txtPkgItem.Focus()
            Exit Sub
        End If

        If cboVendor.Text = "" Then
            Me.Cursor = Cursors.Default
            MsgBox("Please select Vendor.")
            cboVendor.Focus()
            Exit Sub
        End If

        'If txtScFrm.Text <> "" And txtScTo.Text <> "" Then

        'ElseIf txtToFrm.Text <> "" And txtToTo.Text <> "" Then

        'Else
        '    Me.Cursor = Cursors.Default
        '    txtScFrm.Focus()
        '    MsgBox("Please input SC/TO.")
        '    Exit Sub
        'End If

        'If Trim(txtOrdQty.Text) = "" Then
        '    Me.Cursor = Cursors.Default
        '    txtOrdQty.Focus()
        '    MsgBox("Please input Order Qty.")
        '    Exit Sub
        'End If

        'If txtStkQty.Text = "" Then
        '    txtStkQty.Text = 0
        'Else
        '    If IsNumeric(txtStkQty.Text) = False Then
        '        Me.Cursor = Cursors.Default
        '        txtStkQty.Focus()
        '        MsgBox("Please input valid Stock Qty")
        '        Exit Sub
        '    End If
        'End If

        'If Trim(txtUnitPrc.Text) = "" Then
        '    Me.Cursor = Cursors.Default
        '    txtOrdQty.Focus()
        '    MsgBox("Please input Unit Price.")
        '    Exit Sub

        'End If



        gspStr = "sp_select_PKIMBAIF '" & txtPkgItem.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKIMBAIF :" & rtnStr)
            Exit Sub
        End If

        If rs_PKIMBAIF.Tables("RESULT").Rows.Count <> 0 Then

            Dim ordqty As Integer
            Dim stkqty As Integer

            ordqty = Val(txtOrdQty.Text)
            stkqty = Val(txtStkQty.Text)

            If stkqty < 0 Then

                gspStr = "sp_select_PKINVHDR '" & txtPkgItem.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_PKINVHDR, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_select_PKINVHDR :" & rtnStr)
                    Exit Sub
                End If

                If rs_PKINVHDR.Tables("RESULT").Rows.Count <> 0 Then

                    Dim checkstkqty As Integer

                    checkstkqty = stkqty * -1


                    If rs_PKINVHDR.Tables("RESULT").Rows(0).Item("pih_avlqty") < checkstkqty Then
                        Me.Cursor = Cursors.Default
                        MsgBox("Inventory Stock Qty is " & rs_PKINVHDR.Tables("RESULT").Rows(0).Item("pih_avlqty") & " , Please reduce the Qty of taking out Stock.")
                        Exit Sub
                    End If

                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("Packaging Item not found in Inventory , Please check or reset Stock Qty.")
                    Exit Sub

                End If

            End If

        End If

        gspStr = "sp_list_pkwasge_02 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_syswasge, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_list_pkwasge :" & rtnStr)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor


        gspStr = "sp_select_TOORDDTL_PKG09  '" & _
        cboCoCde.Text & "','" & _
CUS1NOLIST & "','" & _
CUS2NOLIST & "','" & _
SCIssdatFM & "','" & _
SCIssdatTO & "','" & _
                   SCNO & "','" & _
                    TONO & "','" & _
                    ITMNOLIST & "','" & _
                    txtPkgItem.Text & "','" & _
        gsUsrID & "'"

        'rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
        rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL_C, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading txtToNo_KeyPress sp_select_TOORDDTL_PKG02 :" & rtnStr)
            Exit Sub
        End If

        'If rs_TOSCDETAIL.Tables("result").Rows.Count = 0 Then
        If rs_TOSCDETAIL_C.Tables("result").Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            MsgBox("Record not found!")
            Exit Sub
        End If

        'grdDetail.DataSource = rs_TOSCDETAIL.Tables("RESULT").DefaultView

        ''20140404

        '        btcQUXLS001.SelectedIndex = 1
        resetdisplay("ADD")

        btcPGM00009.SelectTab(1)
        btcPGM00009.TabPages(0).Enabled = True
        btcPGM00009.TabPages(2).Enabled = False
        btcPGM00009.TabPages(1).Enabled = True


        If chkSC.Checked = True And chkTO.Checked = False Then
            Dim sFilter As String
            sFilter = "flag = " & "'sc'"
            rs_TOSCDETAIL_C.Tables("RESULT").DefaultView.RowFilter = sFilter

        ElseIf chkSC.Checked = False And chkTO.Checked = True Then
            Dim sFilter As String
            sFilter = "flag = " & "'to'"
            rs_TOSCDETAIL_C.Tables("RESULT").DefaultView.RowFilter = sFilter
        End If


        SetdgPkgITem()





        Me.Cursor = Cursors.Default
    End Sub


    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            Call clearAllDisplay(Me)
        End If



        Call resetdisplay(m)



    End Sub

    Private Sub clearAllDisplay(ByVal fv As Control)
        Dim v As Control
        For Each v In fv.Controls

            If TypeOf v Is BaseTabControl Then
                Dim btc As BaseTabControl
                btc = v
                Dim i As Integer
                For i = 0 To btc.TabPages.Count - 1
                    Call clearAllDisplay(btc.TabPages(i))
                Next i
            ElseIf TypeOf v Is GroupBox Then
                Call clearAllDisplay(v)
                v.Enabled = False
            Else
                If TypeOf v Is TextBox Or TypeOf v Is MaskedTextBox Or TypeOf v Is ComboBox Or TypeOf v Is RichTextBox Then
                    v.Text = ""
                    v.Enabled = False
                ElseIf TypeOf v Is ListBox Then
                    Dim lb As ListBox
                    lb = v
                    lb.Items.Clear()
                    v.Enabled = False
                ElseIf TypeOf v Is CheckBox Then
                    Dim cb As CheckBox
                    cb = v
                    cb.Checked = False
                    v.Enabled = False
                ElseIf TypeOf v Is DataGridView Then
                    Dim dg As DataGridView
                    dg = v
                    dg.DataSource = Nothing
                End If
            End If
        Next v

    End Sub


    Private Sub resetdisplay(ByVal mode As String)
        If mode = "INIT" Then
            gp_search.Enabled = False
            txtPkgItem.Text = ""
            cboVendor.Text = ""
            txtScFrm.Text = ""
            txtScTo.Text = ""
            txtToFrm.Text = ""
            txtToTo.Text = ""
            txtOrdQty.Text = ""
            txtStkQty.Text = ""
            txtPkgWastPer.Text = ""
            txtWasQty.Text = ""
            txtTtlOrdQty.Text = ""
            txtRemain.Text = ""
            txtPkgUnitPriCur.Text = ""
            txtTtlAmtCur.Text = ""
            txtUnitPrc.Text = ""
            txtTtlAmt.Text = ""
            txtRemain.Text = ""
            txtStandWasage.Text = ""
            txtInvStkqty.Text = ""
            txtWasFrm.Text = ""
            txtWasTo.Text = ""
            chkSC.Checked = False
            chkTO.Checked = False

            txtPkgItem.Enabled = True
            cboVendor.Enabled = False
            cboAddress.Enabled = False
            cboCntPer.Enabled = False
            txtScFrm.Enabled = True
            txtScTo.Enabled = True
            txtToFrm.Enabled = True
            txtToTo.Enabled = True
            'txtOrdQty.Enabled = True
            txtStkQty.Enabled = True
            rdoIn.Enabled = True
            rdoOut.Enabled = True
            txtPkgWastPer.Enabled = False
            txtWasQty.Enabled = True
            txtTtlOrdQty.Enabled = False
            grdDetail.Enabled = False
            cmdFind.Enabled = True
            cboCoCde.Enabled = True
            txtPkgUnitPriCur.Enabled = False
            txtTtlAmtCur.Enabled = False
            txtUnitPrc.Enabled = True
            txtTtlAmt.Enabled = False
            txtRemain.Enabled = False
            txtStandWasage.Enabled = False
            txtInvStkqty.Enabled = False

            PelInvDtl.Visible = False
            cmdCloseInvdtl.Enabled = True
            PelInvDtl.Enabled = True
            dgInvDtl.Enabled = True
            cmdWasApp.Enabled = True
            chkByWas.Checked = False
            txtWasQty.Enabled = True
        ElseIf mode = "ReadOnly" Then
            gp_search.Enabled = False




        ElseIf mode = "UPDATE" Then


            txtPkgItem.Enabled = False
            cboVendor.Enabled = False
            cboAddress.Enabled = False
            cboCntPer.Enabled = False
            txtScFrm.Enabled = False
            txtScTo.Enabled = False
            txtToFrm.Enabled = False
            txtToTo.Enabled = False
            txtOrdQty.Enabled = False
            txtStkQty.Enabled = False
            txtPkgWastPer.Enabled = False
            txtWasQty.Enabled = True
            txtTtlOrdQty.Enabled = False
            rdoIn.Enabled = False
            rdoOut.Enabled = False
            grdDetail.Enabled = True
            cmdFind.Enabled = False
            cboCoCde.Enabled = False
            txtPkgUnitPriCur.Enabled = False
            txtTtlAmtCur.Enabled = False
            txtUnitPrc.Enabled = False
            txtTtlAmt.Enabled = False
            txtRemain.Enabled = False
            txtStandWasage.Enabled = False
            txtInvStkqty.Enabled = False
            PelInvDtl.Visible = False
            cmdCloseInvdtl.Enabled = True
            PelInvDtl.Enabled = True
            dgInvDtl.Enabled = True
            cmdApply.Enabled = True
            chkByWas.Checked = False
            txtWasQty.Enabled = True
        ElseIf mode = "ADD" Then

            gp_search.Enabled = True

            txtPkgItem.Enabled = False
            cboVendor.Enabled = False
            cboAddress.Enabled = False
            cboCntPer.Enabled = False
            txtScFrm.Enabled = False
            txtScTo.Enabled = False
            txtToFrm.Enabled = False
            txtToTo.Enabled = False
            txtOrdQty.Enabled = False

            txtStkQty.Enabled = True
            txtPkgWastPer.Enabled = False
            txtWasQty.Enabled = True
            txtTtlOrdQty.Enabled = False
            rdoIn.Enabled = True
            rdoOut.Enabled = True
            grdDetail.Enabled = True
            cmdFind.Enabled = True
            cboCoCde.Enabled = False 'True

            txtPkgUnitPriCur.Enabled = False
            txtTtlAmtCur.Enabled = False
            txtUnitPrc.Enabled = True
            txtTtlAmt.Enabled = False
            txtRemain.Enabled = False
            txtStandWasage.Enabled = False

            txtInvStkqty.Enabled = False
            PelInvDtl.Visible = False
            cmdCloseInvdtl.Enabled = True
            PelInvDtl.Enabled = True
            dgInvDtl.Enabled = True
            cmdWasApp.Enabled = True
            chkByWas.Checked = False
            txtWasQty.Enabled = True
        ElseIf mode = "CLEAR" Then
            dgMltShp.DataSource = Nothing
            grdDetail_summary.DataSource = Nothing
            grdDetail.DataSource = Nothing
            rs_TOSCDETAIL = Nothing
            grdDetail_summary.Refresh()
            PelInvDtl.Visible = False

            gp_search.Enabled = False

            cboCoCde.SelectedIndex = 0
            'txtCoNam.Text = ""
            chkSC.Checked = False
            chkTO.Checked = False
            txt_S_PriCust.Text = ""
            txt_S_SecCust.Text = ""
            txt_S_SCNo.Text = ""
            txt_S_TONo.Text = ""
            txt_S_ItmNo.Text = ""

            txtPkgItem.Text = ""
            cboVendor.Text = ""
            txtScFrm.Text = ""
            txtScTo.Text = ""
            txtToFrm.Text = ""
            txtToTo.Text = ""
            txtOrdQty.Text = ""
            txtStkQty.Text = ""
            txtPkgWastPer.Text = ""
            txtWasQty.Text = ""
            txtTtlOrdQty.Text = ""
            txtRemain.Text = ""
            txtPkgUnitPriCur.Text = ""
            txtTtlAmtCur.Text = ""
            txtUnitPrc.Text = ""
            txtTtlAmt.Text = ""
            txtRemain.Text = ""
            txtStandWasage.Text = ""
            txtInvStkqty.Text = ""
            txtWasFrm.Text = ""
            txtWasTo.Text = ""

            txtPkgItem.Enabled = True
            cboVendor.Enabled = False
            cboAddress.Enabled = False
            cboCntPer.Enabled = False
            txtScFrm.Enabled = True
            txtScTo.Enabled = True
            txtToFrm.Enabled = True
            txtToTo.Enabled = True
            'txtOrdQty.Enabled = True
            txtStkQty.Enabled = True
            rdoIn.Enabled = True
            rdoOut.Enabled = True
            txtPkgWastPer.Enabled = False
            txtWasQty.Enabled = True
            txtTtlOrdQty.Enabled = False
            grdDetail.Enabled = False
            cmdFind.Enabled = True
            cboCoCde.Enabled = True
            txtPkgUnitPriCur.Enabled = False
            txtTtlAmtCur.Enabled = False
            txtUnitPrc.Enabled = True
            txtTtlAmt.Enabled = False
            txtRemain.Enabled = False
            txtStandWasage.Enabled = False
            cmdCloseInvdtl.Enabled = True
            txtInvStkqty.Enabled = False
            PelInvDtl.Enabled = True
            dgInvDtl.Enabled = True
            rdoUntPri.Checked = True
            txtUnitPrc.Enabled = True
            txtTtlAmt.Enabled = False
            cmdWasApp.Enabled = True
            chkByWas.Checked = False
            txtWasQty.Enabled = True
        End If



    End Sub
    Private Sub unionRecord()
        If rs_TOSCDETAIL Is Nothing Then
            Dim tmp_td As New DataTable
            tmp_td.TableName = "RESULT"
            tmp_td = rs_TOSCDETAIL_C.Tables("RESULT").DefaultView.ToTable.Copy
            rs_TOSCDETAIL = New DataSet
            rs_TOSCDETAIL.Tables.Add(tmp_td)

        End If

        Dim tmp_rs_TOSCDETAIL_C As DataView
        tmp_rs_TOSCDETAIL_C = rs_TOSCDETAIL_C.Tables("RESULT").DefaultView

        If Not tmp_rs_TOSCDETAIL_C Is Nothing Then
            Dim dr() As DataRow
            Dim newRow As DataRow
            For i As Integer = 0 To tmp_rs_TOSCDETAIL_C.Count - 1
                dr = Nothing
                dr = rs_TOSCDETAIL.Tables("RESULT").Select("ordno = '" & tmp_rs_TOSCDETAIL_C.Item(i)("ordno") & "' and seq = " & tmp_rs_TOSCDETAIL_C.Item(i)("seq"))
                newRow = Nothing

                If dr.Length = 0 Then

                    Dim dr_req() As DataRow
                    dr_req = rs_TOSCDETAIL_C.Tables("RESULT").Select("ordno = '" & tmp_rs_TOSCDETAIL_C.Item(i)("ordno") & "' and seq = " & tmp_rs_TOSCDETAIL_C.Item(i)("seq"))


                    For x As Integer = 0 To dr_req.Length - 1
                        newRow = rs_TOSCDETAIL.Tables("RESULT").NewRow
                        newRow("Counter") = dr_req(x)("Counter")
                        newRow("Gen") = dr_req(x)("Gen")
                        newRow("cocde") = dr_req(x)("cocde")
                        newRow("ordno") = dr_req(x)("ordno")
                        newRow("seq") = dr_req(x)("seq")
                        newRow("realitem") = dr_req(x)("realitem")
                        newRow("assitem") = dr_req(x)("assitem")
                        newRow("custitm") = dr_req(x)("custitm")
                        'newRow("pod_reqno") = rs_PGM00005C.Tables("RESULT").Rows(i)("pod_reqno")
                        'newRow("pod_reqseq") = rs_PGM00005C.Tables("RESULT").Rows(i)("pod_reqseq")
                        newRow("sku") = dr_req(x)("sku")
                        newRow("tempitem") = dr_req(x)("tempitem")
                        newRow("venitem") = dr_req(x)("venitem")
                        newRow("venitemno") = dr_req(x)("venitemno")
                        newRow("vbi_vensna") = dr_req(x)("vbi_vensna")
                        newRow("colcde") = dr_req(x)("colcde")
                        newRow("ordqty") = dr_req(x)("ordqty")
                        newRow("wasqty") = dr_req(x)("wasqty")
                        newRow("stqty") = dr_req(x)("stqty")
                        newRow("um") = dr_req(x)("um")
                        newRow("inr") = dr_req(x)("inr")
                        newRow("mst") = dr_req(x)("mst")
                        newRow("cft") = dr_req(x)("cft")
                        newRow("ftyprctrm") = dr_req(x)("ftyprctrm")
                        newRow("hkprctrm") = dr_req(x)("hkprctrm")
                        newRow("trantrm") = dr_req(x)("trantrm")
                        newRow("Terms") = dr_req(x)("Terms")
                        newRow("curcde") = dr_req(x)("curcde")
                        newRow("conftr") = dr_req(x)("conftr")
                        newRow("flag") = dr_req(x)("flag")
                        rs_TOSCDETAIL.Tables("RESULT").Rows.Add(newRow)
                        rs_TOSCDETAIL.AcceptChanges()

                        'recordStatus = True
                    Next
                End If
            Next
        End If
    End Sub
    Private Sub SetdgPkgITem()




        If rs_TOSCDETAIL_C.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        unionRecord()

        'rs_TOSCDETAIL = rs_TOSCDETAIL_C.Copy()



        rs_TOSCDETAIL.Tables("RESULT").DefaultView.Sort = "ordno,seq"

        '''20140410
        Dim i As Integer

        For i = 0 To rs_TOSCDETAIL.Tables("RESULT").Columns.Count - 1
            rs_TOSCDETAIL.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        For index As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count - 1
            rs_TOSCDETAIL.Tables("RESULT").DefaultView(index)("counter") = index + 1
        Next
        txtFromApply.Text = "1"
        txtToApply.Text = Val(rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count)


        grdDetail.RowHeadersWidth = 18
        grdDetail.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdDetail.ColumnHeadersHeight = 18
        grdDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdDetail.AllowUserToResizeColumns = True
        grdDetail.AllowUserToResizeRows = False
        grdDetail.RowTemplate.Height = 18

        grdDetail.DataSource = rs_TOSCDETAIL.Tables("RESULT").DefaultView


        'grdDetail.RowHeadersWidth = 18
        'grdDetail.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        'grdDetail.ColumnHeadersHeight = 18
        'grdDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'grdDetail.AllowUserToResizeColumns = True
        'grdDetail.AllowUserToResizeRows = False
        'grdDetail.RowTemplate.Height = 18



        'If mode = "UPDATE" Or mode = "ADD" Then


        'End If
        i = 0
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Count"
        grdDetail.Columns(i).Width = 40
        'grdDetail.Columns(i).ReadOnly = True
        i = 1
        dgPKGITEM_GEN = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Gen"
        grdDetail.Columns(i).Width = 40
        grdDetail.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_cocde = i

        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_ordno = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Ord No"
        grdDetail.Columns(i).Width = 70
        'grdDetail.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_seq = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Seq"
        grdDetail.Columns(i).Width = 40
        'grdDetail.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_realitem = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Item No"
        grdDetail.Columns(i).Width = 90
        'grdDetail.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgItem_assitem = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Ass. Item"
        grdDetail.Columns(i).Width = 80
        'grdDetail.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_cusitem = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Cust.Item#"
        grdDetail.Columns(i).Width = 60
        'grdDetail.Columns(i).ReadOnly = True


        i = i + 1
        dgPkgITem_sku = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "SKU#"
        grdDetail.Columns(i).Width = 60
        'grdDetail.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_tempitem = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Tmp.Item No"
        grdDetail.Columns(i).Width = 49
        'grdDetail.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_venitem = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Ven.Item No"
        grdDetail.Columns(i).Width = 49
        'grdDetail.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_venno = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Vendor No"
        grdDetail.Columns(i).Width = 49
        i = i + 1
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Vendor Name"
        grdDetail.Columns(i).Width = 49

        'grdDetail.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgItem_colcde = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Color Code"
        grdDetail.Columns(i).Width = 60
        'grdDetail.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_ordqty = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "PKG Ord Qty"
        grdDetail.Columns(i).Width = 60
        grdDetail.Columns(i).ReadOnly = True

        i = i + 1
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "PKG Was Qty"
        grdDetail.Columns(i).Width = 60
        grdDetail.Columns(i).ReadOnly = True


        i = i + 1
        dgPkgITem_stqty = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "SC/TO Ord Qty"
        grdDetail.Columns(i).Width = 60
        grdDetail.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_um = i
        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_inr = i
        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_mst = i
        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgItem_cft = i
        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_ftyprctrm = i
        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_hkprctrm = i
        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_trantrm = i
        grdDetail.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_Terms = i
        grdDetail.Columns(i).Visible = True
        grdDetail.Columns(i).HeaderText = "Terms"
        grdDetail.Columns(i).Width = 200
        'grdDetail.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_curcde = i
        grdDetail.Columns(i).Visible = False

        i = i + 1
        dgPkgITem_conftr = i
        grdDetail.Columns(i).Visible = False

        i = i + 1
        dgPkgITem_flag = i
        grdDetail.Columns(i).Visible = False


        'i = i + 1
        'dgPkgITem_Scno = i
        'grdDetail.Columns(i).Visible = True
        'grdDetail.Columns(i).HeaderText = "SC Order NO."
        'grdDetail.Columns(i).Width = 90
        ''grdDetail.Columns(i).ReadOnly = True

        'i = i + 1
        'dgPkgITem_ScSeq = i
        'grdDetail.Columns(i).Visible = True
        'grdDetail.Columns(i).HeaderText = "SC Order Seq"
        'grdDetail.Columns(i).Width = 60
        ''grdDetail.Columns(i).ReadOnly = True

        'i = i + 1
        'dgPkgITem_ScItem = i
        'grdDetail.Columns(i).Visible = True
        'grdDetail.Columns(i).HeaderText = "SC Item"
        'grdDetail.Columns(i).Width = 120
        ''grdDetail.Columns(i).ReadOnly = True


        'i = i + 1
        'dgPkgItem_ScQty = i
        'grdDetail.Columns(i).Visible = True
        'grdDetail.Columns(i).HeaderText = "SC Order Qty"
        'grdDetail.Columns(i).Width = 60
        ''grdDetail.Columns(i).ReadOnly = True



        Dim ii As Integer

        For ii = 0 To grdDetail.Columns.Count - 1

            grdDetail.Columns(ii).SortMode = DataGridViewColumnSortMode.Automatic


        Next ii






    End Sub
    Private Sub SetdgPkgITem_summary()
        If rs_TOSCDETAIL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If


        grdDetail_summary.DataSource = rs_TOSCDETAIL.Tables("RESULT").DefaultView


        'grdDetail_summary.RowHeadersWidth = 18
        'grdDetail_summary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        'grdDetail_summary.ColumnHeadersHeight = 18
        'grdDetail_summary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'grdDetail_summary.AllowUserToResizeColumns = True
        'grdDetail_summary.AllowUserToResizeRows = False
        'grdDetail_summary.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_TOSCDETAIL.Tables("RESULT").Columns.Count - 1
            rs_TOSCDETAIL.Tables("RESULT").Columns(i).ReadOnly = True
        Next i

        rs_TOSCDETAIL.Tables("RESULT").Columns(15).ReadOnly = False
        rs_TOSCDETAIL.Tables("RESULT").Columns(14).ReadOnly = False
        rs_TOSCDETAIL.Tables("RESULT").Columns(1).ReadOnly = False

        'End If
        i = 0
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Count"
        grdDetail_summary.Columns(i).Width = 40
        grdDetail_summary.Columns(i).ReadOnly = True
        i = 1
        dgPKGITEM_GEN = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Gen"
        grdDetail_summary.Columns(i).Width = 40
        grdDetail_summary.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_cocde = i

        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_ordno = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Ord No"
        grdDetail_summary.Columns(i).Width = 70
        grdDetail_summary.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_seq = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Seq"
        grdDetail_summary.Columns(i).Width = 40
        grdDetail_summary.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_realitem = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Item No"
        grdDetail_summary.Columns(i).Width = 90
        grdDetail_summary.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgItem_assitem = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Ass. Item"
        grdDetail_summary.Columns(i).Width = 50
        grdDetail_summary.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_cusitem = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Cust. Item#"
        grdDetail_summary.Columns(i).Width = 50
        grdDetail_summary.Columns(i).ReadOnly = True


        i = i + 1
        dgPkgITem_sku = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "SKU#"
        grdDetail_summary.Columns(i).Width = 40
        grdDetail_summary.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_tempitem = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Tmp.Item No"
        grdDetail_summary.Columns(i).Width = 40
        grdDetail_summary.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_venitem = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Ven.Item No"
        grdDetail_summary.Columns(i).Width = 40
        grdDetail_summary.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_venno = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Vendor No"
        grdDetail_summary.Columns(i).Width = 40
        grdDetail_summary.Columns(i).ReadOnly = True

        i = i + 1

        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Vendor Name"
        grdDetail_summary.Columns(i).Width = 50
        grdDetail_summary.Columns(i).ReadOnly = True


        i = i + 1
        dgPkgItem_colcde = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Color Code"
        grdDetail_summary.Columns(i).Width = 60
        grdDetail_summary.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_ordqty = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "PKG Ord Qty"
        grdDetail_summary.Columns(i).Width = 70
        grdDetail_summary.Columns(i).ReadOnly = False


        i = i + 1
        '  dgPkgITem_ordqty = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "PKG Was Qty"
        grdDetail_summary.Columns(i).Width = 70
        grdDetail_summary.Columns(i).ReadOnly = False



        i = i + 1
        dgPkgITem_stqty = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "SC/TO Ord Qty"
        grdDetail_summary.Columns(i).Width = 60
        '
        grdDetail_summary.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_um = i
        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_inr = i
        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_mst = i
        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgItem_cft = i
        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_ftyprctrm = i
        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_hkprctrm = i
        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_trantrm = i
        grdDetail_summary.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_Terms = i
        grdDetail_summary.Columns(i).Visible = True
        grdDetail_summary.Columns(i).HeaderText = "Terms"
        grdDetail_summary.Columns(i).Width = 200
        grdDetail_summary.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_curcde = i
        grdDetail_summary.Columns(i).Visible = False

        i = i + 1
        dgPkgITem_conftr = i
        grdDetail_summary.Columns(i).Visible = False

        i = i + 1
        dgPkgITem_flag = i
        grdDetail_summary.Columns(i).Visible = False
        'i = i + 1
        'dgPkgITem_Scno = i
        'grdDetail_summary.Columns(i).Visible = True
        'grdDetail_summary.Columns(i).HeaderText = "SC Order NO."
        'grdDetail_summary.Columns(i).Width = 90
        ''grdDetail_summary.Columns(i).ReadOnly = True

        'i = i + 1
        'dgPkgITem_ScSeq = i
        'grdDetail_summary.Columns(i).Visible = True
        'grdDetail_summary.Columns(i).HeaderText = "SC Order Seq"
        'grdDetail_summary.Columns(i).Width = 60
        ''grdDetail_summary.Columns(i).ReadOnly = True

        'i = i + 1
        'dgPkgITem_ScItem = i
        'grdDetail_summary.Columns(i).Visible = True
        'grdDetail_summary.Columns(i).HeaderText = "SC Item"
        'grdDetail_summary.Columns(i).Width = 120
        ''grdDetail_summary.Columns(i).ReadOnly = True


        'i = i + 1
        'dgPkgItem_ScQty = i
        'grdDetail_summary.Columns(i).Visible = True
        'grdDetail_summary.Columns(i).HeaderText = "SC Order Qty"
        'grdDetail_summary.Columns(i).Width = 60
        ''grdDetail_summary.Columns(i).ReadOnly = True



        Dim ii As Integer

        For ii = 0 To grdDetail_summary.Columns.Count - 1

            grdDetail_summary.Columns(ii).SortMode = DataGridViewColumnSortMode.Automatic

        Next ii


    End Sub

    Private Sub txtPkgItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPkgItem.KeyDown

    End Sub

    Private Sub txtPkgItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPkgItem.KeyPress

        'e.KeyChar = UCase(e.KeyChar)


        If e.KeyChar.Equals(Chr(13)) Then
            txtPkgItem.Text = UCase(txtPkgItem.Text)
            gspStr = "sp_select_PKIMBAIF '" & txtPkgItem.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_PKIMBAIF :" & rtnStr)
                Exit Sub
            End If

            If rs_PKIMBAIF.Tables("RESULT").Rows.Count = 0 Then
                Select Case MsgBox("Packaging Item not found. Do you want to create the new Packaging Item now?", MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes

                        Dim frmPGM00010 As New PGM00010

                        frmPGM00010.keyName = txtPkgItem.Name
                        'frmSYM00018.strModule = "PK"

                        frmPGM00010.show_frmPGM00010(Me)



                        Me.Cursor = Cursors.Default

                        ''
                        gspStr = "sp_select_PKIMBAIF '" & txtPkgItem.Text & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF2, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Cursors.Default
                            MsgBox("Error on loading cmdFind_Click sp_select_PKIMBAIF :" & rtnStr)
                            Exit Sub
                        End If

                        If rs_PKIMBAIF2.Tables("RESULT").Rows.Count = 0 Then
                            MsgBox("Packaging Item not found. ")
                            resetdisplay("CLEAR")
                            Exit Sub
                        End If

                        ''
                    Case MsgBoxResult.No
                        Exit Sub
                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select


            Else

                If rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate") <> "HTG" And rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate") <> "LBL" Then
                    MsgBox("Please entry Hang Tag or Label category Packaging Item.")
                    Exit Sub
                End If





                gspStr = "sp_select_PKINVDTL ''"
                rtnLong = execute_SQLStatement(gspStr, rs_PKINVHDR2, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_list_PKINVHDR :" & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_list_PKINVHDR ''"
                rtnLong = execute_SQLStatement(gspStr, rs_ListPkinvhdr, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_list_PKINVHDR :" & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_select_PKINVDTL ''"
                rtnLong = execute_SQLStatement(gspStr, rs_InvStock, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_list_PKINVHDR :" & rtnStr)
                    Exit Sub
                End If

                display_dgInvDtl(UCase(txtPkgItem.Text))

                Dim dr_Inv() As DataRow
                Dim item As String = UCase(txtPkgItem.Text)
                dr_Inv = rs_ListPkinvhdr.Tables("RESULT").Select("pih_pkgitm = '" & item & "'")
                If dr_Inv.Length <> 0 Then
                    txtInvStkQty.Text = dr_Inv(0)("pih_avlqty")
                Else
                    txtInvStkQty.Text = 0
                End If



                txtPkgItem.Enabled = False
                cboVendor.Focus()


            End If


            cboVendor.Enabled = True
            cboVendor.Focus()
            cboAddress.Enabled = True
            cboCntPer.Enabled = True


            txtPkgItem.Enabled = False

        End If




    End Sub
    Private Sub display_dgInvDtl(ByVal ItemName As String)
        If rs_InvStock.Tables.Count = 0 Then
            Exit Sub
        End If

        If rs_InvStock.Tables("RESULT").Rows.Count > 0 Then
            Dim sFilter As String
            sFilter = "pih_pkgitm = '" & ItemName & "'"
            rs_InvStock.Tables("RESULT").DefaultView.RowFilter = sFilter

            'dgMShp.DataSource = rs_TODTLSHP.Tables("RESULT").DefaultView
        End If



        dgInvDtl.DataSource = rs_InvStock.Tables("RESULT").DefaultView

        dgInvDtl.RowHeadersWidth = 18
        dgInvDtl.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgInvDtl.ColumnHeadersHeight = 18
        dgInvDtl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgInvDtl.AllowUserToResizeColumns = True
        dgInvDtl.AllowUserToResizeRows = False
        dgInvDtl.RowTemplate.Height = 18

        Dim i As Integer

        For i = 0 To rs_InvStock.Tables("RESULT").Columns.Count - 1
            rs_InvStock.Tables("RESULT").Columns(i).ReadOnly = False
        Next


        For i = 0 To dgInvDtl.Columns.Count - 1

            Select Case i



                Case 0
                    dgInvDtl.Columns(i).HeaderText = "Order No"
                    dgInvDtl.Columns(i).Width = 100
                    dgInvDtl.Columns(i).Visible = True
                    dgInvDtl.Columns(i).ReadOnly = True

                Case 1

                    dgInvDtl.Columns(i).HeaderText = "Seq"
                    dgInvDtl.Columns(i).Width = 50
                    dgInvDtl.Columns(i).Visible = True
                    dgInvDtl.Columns(i).ReadOnly = True
                Case 2
                    dgInvDtl.Columns(i).HeaderText = "Stock Qty"
                    dgInvDtl.Columns(i).Width = 70
                    dgInvDtl.Columns(i).Visible = True
                    dgInvDtl.Columns(i).ReadOnly = True

                Case 3
                    dgInvDtl.Columns(i).HeaderText = "Packaging Item"
                    dgInvDtl.Columns(i).Width = 150
                    dgInvDtl.Columns(i).Visible = True
                    dgInvDtl.Columns(i).ReadOnly = True

                Case Else
                    dgInvDtl.Columns(i).Visible = False
            End Select






        Next

    End Sub
    Private Sub txtPkgItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgItem.TextChanged

    End Sub

    Private Sub txtScFrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScFrm.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtScFrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScFrm.TextChanged
        txtToFrm.Text = ""
        txtToTo.Text = ""
        txtScTo.Text = txtScFrm.Text
    End Sub

    Private Sub txtToFrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToFrm.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtToFrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToFrm.TextChanged
        txtScFrm.Text = ""
        txtScTo.Text = ""
        txtToTo.Text = txtToFrm.Text
    End Sub

    Private Sub txtScTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScTo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtScTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScTo.TextChanged
        txtToFrm.Text = ""
        txtToTo.Text = ""
    End Sub

    Private Sub txtToTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToTo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtToTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToTo.TextChanged
        txtScFrm.Text = ""
        txtScTo.Text = ""
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        gsDefaultCompany = Trim(cboCoCde.Text)
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        resetdisplay("CLEAR")

        btcPGM00009.SelectTab(0)
        btcPGM00009.TabPages(1).Enabled = False
        btcPGM00009.TabPages(2).Enabled = False
        btcPGM00009.TabPages(0).Enabled = True

        grdDetail.DataSource = Nothing
        rs_VNBASINF = Nothing
        rs_PKIMBAIF = Nothing
        rs_PKINVHDR = Nothing
        rs_syswasge = Nothing
        rs_TOSCDETAIL = Nothing
        grdDetail.Enabled = False

        '''
        rs_pkmltshp = Nothing
        gspStr = "sp_select_PKMTLSHP '" & cboCoCde.Text & "','" & "efwfwfbhqe3ref37" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_pkmltshp, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKMLTSHP :" & rtnStr)
            Exit Sub
        End If


        cmdGen.Enabled = True


        txtPkgItem.Focus()
    End Sub


    Private Sub grdDetail_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDetail.CellValidating

        Dim row As DataGridViewRow = grdDetail.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex





                Case dgPkgITem_ordqty
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal.ToString.Contains(".") = True Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal < 0 Then
                        MsgBox("Order qty Cannot be Negative number")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        End If
    End Sub


    Private Sub grdDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellEndEdit


        Select Case e.ColumnIndex

            Case dgPkgITem_ordqty



                Dim ttlordqty As Integer = Val(txtOrdQty.Text)
                Dim ordqty As Integer

                '20140404
                'call a fun

                'For i As Integer = 0 To grdDetail.Rows.Count - 1

                '    If grdDetail.Item(dgPKGITEM_GEN, i).Value = "Y" Then
                '        ordqty = ordqty + grdDetail.Item(dgPkgITem_ordqty, i).Value
                '    End If
                'Next

                'txtRemain.Text = ttlordqty - ordqty

        End Select




    End Sub




    Private Function checkZeroqty(ByVal rs_tmp_toscdetail As DataSet) As Boolean
        'Check 0
        Dim strMsg As String

        strMsg = ""
        checkZeroqty = True
        If Not rs_tmp_toscdetail Is Nothing Then
            Dim dr_tmp_toscdetail() As DataRow = rs_tmp_toscdetail.Tables("RESULT").Select("ordqty = 0 and Gen='Y'", "ordno,seq")
            'dr_tmp_quotation(0).Item("ibi_itmsts")


            'rs_tmp_quotation.Filter = "qud_smpqty=0"
            If dr_tmp_toscdetail.Length > 0 Then
                'rs_tmp_quotation.Sort = "quh_cocde,qud_qutno,qud_qutseq"
                'rs_tmp_quotation.MoveFirst()
                'Do While Not rs_tmp_quotation.EOF
                For i As Integer = 0 To dr_tmp_toscdetail.Length - 1
                    If dr_tmp_toscdetail(i).Item("ordqty") = 0 Then
                        strMsg = strMsg & dr_tmp_toscdetail(i).Item("ordno") & "         " & dr_tmp_toscdetail(i).Item("seq") & "             " & dr_tmp_toscdetail(i).Item("realitem") & "\" & dr_tmp_toscdetail(i).Item("assitem") & "\" & dr_tmp_toscdetail(i).Item("tempitem") & _
                        "\" & dr_tmp_toscdetail(i).Item("venitem") & "\" & dr_tmp_toscdetail(i).Item("venitemno") & vbCrLf
                    End If
                Next

                'rs_tmp_quotation.MoveNext()
                'Loop
            Else
                checkZeroqty = False
            End If
        End If
        If strMsg <> "" Then
            strMsg = "The Order Qty of the following reocord(s) is/are Zero:        " & vbCrLf & _
                     vbCrLf & "Order #      Seq #       Item #    " & vbCrLf & _
                    vbCrLf & strMsg & _
                    vbCrLf & vbCrLf & "Records with Zero Order Qty will not be generated." & vbCrLf & _
                    "Continue Order Generation?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "Zero Order Quantity") = vbYes Then
                checkZeroqty = False
            End If
        End If
    End Function

    Private Sub txtOrdQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
    End Sub



    Private Sub txtOrdQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtUnitPrc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitPrc.KeyPress

        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 13) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        If txtUnitPrc.Text.Contains(".") = True Then
            If Asc(e.KeyChar) = 46 Then
                e.KeyChar = Chr(0)
                MsgBox("Please input integer value.")
            End If
        End If





    End Sub

    Private Sub txtUnitPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitPrc.TextChanged
 

        If rdoTtlAmt.Checked = True Then
            Exit Sub
        End If

        txtTtlAmt.Text = round(round(Val(txtUnitPrc.Text), 5) * Val(txtTtlOrdQty.Text), 2)

    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)

    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCust)

    End Sub

    Private Function removeduplicateItem(ByVal s As String) As String
        Return s
    End Function

    Private Sub grdDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellContentClick

    End Sub

    Private Sub txtWasQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWasQty.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 13) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
    End Sub

    Private Sub txtWasQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWasQty.TextChanged
        cal_grip_qty3()
        If txtStandWasage.Text <> txtWasQty.Text Then
            txtWasQty.ForeColor = Color.Red
        Else
            txtWasQty.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtPkgWastPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgWastPer.TextChanged
        cal_grip_qty2()

    End Sub

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        frmComSearch.show_frmS(Me.cmd_S_SCNo)
    End Sub

    Private Sub cmd_S_TONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_TONo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_TONo.Name
        frmComSearch.callFmString = txt_S_TONo.Text

        frmComSearch.show_frmS(Me.cmd_S_TONo)
    End Sub
    Private Function check_valid() As Boolean

        If rs_pkmltshp.Tables("RESULT").Rows.Count = 0 Then
            Return True
            Exit Function
        End If


        For i As Integer = 0 To rs_pkmltshp.Tables("RESULT").Rows.Count - 1  ''Mult Ship Checking 

            If rs_pkmltshp.Tables("RESULT").Rows(i).Item("Del") = "Y" Then
                Continue For
            End If

            If IsDate(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpstrdat")) = False Then
                'IsDate(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpenddat")) = False Then


                MsgBox(("Please Input valid Ship Date For Multiple Shipment [MM/dd/yyyy]"))
                Return False
                Exit Function



            End If


            If IsNumeric(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpqty")) = False Or _
            rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpqty").ToString.Contains(".") = True Or _
            rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpqty") = 0 Then


                MsgBox(("Please Input valid Ship Qty For Multiple Shipment and Qty cannot be 0"))
                Return False
                Exit Function



            End If


            If rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_fty") = "" Then



                MsgBox(("Please select Factory For Multiple Shipment"))
                Return False
                Exit Function



            End If



        Next










        Return True


    End Function

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        Dim msg As String = ""


        If check_valid() = False Then
            Exit Sub
        End If


        If check_ttlgoods() = False Then
            Exit Sub
        End If

        If rdoUntPri.Checked = True Then
            If txtUnitPrc.Text.Trim = "" Then
                MsgBox("Please Input Unit Price!")
                txtUnitPrc.Focus()

                Exit Sub
            Else
                Dim checkunit As Decimal
                checkunit = txtUnitPrc.Text
                If checkunit = 0 Then
                    MsgBox("Please input Unit Price!")
                    Exit Sub
                End If

            End If
        End If

        If rdoTtlAmt.Checked = True Then
            If txtTtlAmt.Text.Trim = "" Then
                MsgBox("Please Input Total Amount!")
                txtTtlAmt.Focus()

                Exit Sub
            Else
                Dim checkunit As Decimal
                checkunit = txtTtlAmt.Text
                If checkunit = 0 Then
                    MsgBox("Please input Total Amount!")
                    Exit Sub
                End If

            End If
        End If

        If Val(txtOrdQty.Text) = 0 Then
            MsgBox("Order Quantity should not be zero!")
            Exit Sub
        End If






        Me.Cursor = Cursors.WaitCursor
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)






        Dim rs_Temp_TOSCDETAIL As DataSet

        If Not Me.grdDetail.DataSource Is Nothing Then
            rs_TOSCDETAIL_tmp = rs_TOSCDETAIL.Copy
        Else
            MsgBox("No Detail Found.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If



        Dim remainqty As Integer

        'If txtRemain.Text = "" Then
        '    Me.Cursor = Cursors.Default
        '    MsgBox("Remain qty invalid , please check.")
        '    Exit Sub
        'Else
        '    remainqty = txtRemain.Text
        'End If

        '20140404 test
        remainqty = 0

        If remainqty > 0 Then
            MsgBox("Please assign all remain qty.")
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf remainqty < 0 Then
            MsgBox("Please do not assign over order qty.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If




        Dim dr_vendor() As DataRow
        dr_vendor = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & Split(cboVendor.Text, " - ")(0) & "'")


        If dr_vendor.Length = 0 Then
            Me.Cursor = Cursors.Default
            MsgBox("Vendor detail not found , Please check.")

            Exit Sub
        End If

        Dim total_wasage As Integer = 0
 


        If Not rs_TOSCDETAIL_tmp Is Nothing Then

            Dim dr_TOSCDETAIL() As DataRow
            dr_TOSCDETAIL = rs_TOSCDETAIL_tmp.Tables("RESULT").Select("Gen = 'Y'")

            If dr_TOSCDETAIL.Length = 0 Then
                Me.Cursor = Cursors.Default
                MsgBox("No record selected for generate, please try again.")
                Exit Sub
            Else
                Dim FirstTime As Boolean = True
                rs_Temp_TOSCDETAIL = rs_TOSCDETAIL_tmp.Copy

                If checkZeroqty(rs_Temp_TOSCDETAIL) Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                rs_TOSCDETAIL_tmp.Tables("RESULT").DefaultView.Sort = _
                "cocde,ordno,seq"

                Dim rs_TOSCDETAIL_tmp_sorttable As DataTable = _
                rs_TOSCDETAIL_tmp.Tables("RESULT").DefaultView.ToTable

                Dim currentOrderNO As String = ""

                Dim in_was As String

                If chkByWas.Checked = True Then
                    in_was = "Y"
                Else
                    in_was = "N"
                End If
                '                Dim NewOrderNo As String
                For i As Integer = 0 To rs_TOSCDETAIL_tmp_sorttable.Rows.Count - 1

                    If rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("Gen") = "Y" And rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordqty") <> 0 Then

                        If FirstTime = True Then



                            FirstTime = False



                            gspStr = "sp_select_DOC_GEN '" & gsCompany & "','KG','" & LCase(gsUsrID) & "'"
                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                Me.Cursor = Cursors.Default
                                MsgBox("Error on loading PGM00005 #003 sp_select_DOC_GEN : " & rtnStr)
                                Exit Sub

                            End If


                            NewOrderNo = rs.Tables("RESULT").Rows(0)(0)








                            Dim poh_cocde As String = gsCompany
                            Dim poh_ordno As String = NewOrderNo
                            Dim poh_ver As Integer = 1
                            Dim poh_issdat As DateTime = DateTime.Now.ToShortDateString
                            Dim poh_revdat As DateTime = DateTime.Now.ToShortDateString
                            Dim poh_status As String = "OPE"
                            Dim poh_cus1no As String = ""
                            Dim poh_cus2no As String = ""
                            Dim poh_saldiv As String = ""
                            Dim poh_saltem As String = ""
                            Dim poh_salrep As String = ""
                            Dim poh_ToNo As String = ""
                            Dim poh_ToVer As Integer = 0
                            Dim poh_ToSts As String = ""
                            Dim poh_ToIsdat As DateTime = "1900/01/01"
                            Dim poh_ToRevdat As DateTime = "1900/01/01"
                            Dim poh_ToRefqut As String = ""
                            Dim poh_potyp As String = ""
                            Dim poh_ScNo As String = ""
                            Dim poh_ScVer As Integer = 0
                            Dim poh_ScSts As String = ""
                            Dim poh_ScIsdat As DateTime = "1900/01/01"
                            Dim poh_ScRevdat As DateTime = "1900/01/01"
                            Dim poh_ScPodat As DateTime = "1900/01/01"
                            Dim poh_ScCandat As DateTime = "1900/01/01"
                            Dim poh_ScShpdatstr As DateTime = "1900/01/01"
                            Dim poh_ScShpdatend As DateTime = "1900/01/01"
                            Dim poh_ScRemark As String = ""
                            Dim poh_Reqno As String = ""
                            Dim poh_Pkgven As String = Split(cboVendor.Text, " - ")(0)
                            'Dim poh_dvydat As DateTime = "1900/01/01"
                            'Dim poh_dremark As String = ""
                            Dim poh_address As String = cboAddress.Text
                            Dim poh_ttlamt As Decimal = txtTtlAmt.Text
                            Dim poh_ctnper As String = cboCntPer.Text
                            Dim poh_tel As String
                            Dim poh_Delamt As Decimal = 0
                            Dim poh_TtlDelamt As Decimal = round(Convert.ToDecimal(txtTtlAmt.Text), 2)

                            Dim dr_tel() As DataRow

                            dr_tel = rs_VNCTNPER.Tables("RESULT").Select("vci_venno = '" & Split(cboVendor.Text, " - ")(0) & "' and vci_cntctp = '" & cboCntPer.Text & "'")
                            If dr_tel.Length <> 0 Then
                                poh_tel = dr_tel(0)("vci_cntphn")
                            Else
                                poh_tel = ""
                            End If

                            Dim poh_GenFlag As String

                            If rdoTtlAmt.Checked = True Then
                                poh_GenFlag = "TA"
                            ElseIf rdoUntPri.Checked = True Then
                                poh_GenFlag = "UP"
                            Else
                                poh_GenFlag = ""
                            End If

                            Dim poh_GenType As String = "Ord"

                            Dim poh_apvcnt As Integer = 0


                            rs = Nothing

                            gspStr = "sp_insert_PKORDHDR '" & poh_cocde & "','" & poh_ordno & "'," & poh_ver & ",'" & _
                            poh_issdat & "','" & poh_revdat & "','" & poh_status & "','" & poh_cus1no & "','" & _
                            poh_cus2no & "','" & poh_saldiv & "','" & poh_saltem & "','" & poh_salrep & "','" & _
                            poh_ToNo & "','" & poh_ToVer & "','" & poh_ToSts & "','" & poh_ToIsdat & "','" & _
                            poh_ToRevdat & "','" & poh_ToRefqut & "','" & poh_potyp & "','" & poh_ScNo & "','" & _
                            poh_ScVer & "','" & poh_ScSts & "','" & poh_ScIsdat & "','" & poh_ScRevdat & "','" & _
                            poh_ScPodat & "','" & poh_ScCandat & "','" & poh_ScShpdatstr & "','" & poh_ScShpdatend & "','" & _
                            poh_ScRemark & "','" & poh_Reqno & "','" & poh_Pkgven & "','" & poh_address & "'," & _
                            poh_ttlamt & ",'" & poh_ctnper & "','" & poh_tel & "'," & poh_Delamt & "," & poh_TtlDelamt & ",'" & _
                            poh_GenFlag & "','" & poh_GenType & "'," & poh_apvcnt & ",'" & gsUsrID & "'"

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                Me.Cursor = Cursors.Default
                                MsgBox("Error on loading PGM00009 sp_insert_PKORDHDR : " & rtnStr)
                                Exit Sub
                            Else
                                msg = msg & " Packaging Order#: " & poh_ordno & " created" & Environment.NewLine
                            End If





                            Dim pod_cocde As String = gsCompany
                            Dim pod_ordno As String = NewOrderNo
                            Dim pod_seq As Integer = 1
                            Dim pod_status As String = "OPE"
                            'Dim pod_itemno
                            'Dim pod_tmpitmno
                            'Dim pod_venno
                            'Dim pod_venitm
                            'Dim pod_pckunt
                            'Dim pod_inrqty
                            'Dim pod_mtrqty
                            'Dim pod_cft
                            'Dim pod_colcde
                            'Dim pod_ftyprctrm
                            'Dim pod_hkprctrm
                            'Dim pod_trantrm
                            If rs_PKIMBAIF.Tables("RESULT").Rows.Count = 0 Then
                                MsgBox("Item not found!")
                                Exit Sub
                            End If

                            Dim pod_pkgitm As String = txtPkgItem.Text
                            Dim pod_pkgven As String = Split(cboVendor.Text, " - ")(0)
                            Dim pod_cate As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate")
                            Dim pod_chndsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_chndsc"), "'", "''")
                            Dim pod_engdsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_engdsc"), "'", "''")
                            Dim pod_remark As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_remark"), "'", "''")
                            Dim pod_EInchL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchL") '
                            Dim pod_EInchW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchW")
                            Dim pod_EInchH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchH")
                            Dim pod_EcmL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmL")
                            Dim pod_EcmW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmW")
                            Dim pod_EcmH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmH")
                            Dim pod_FInchL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchL")
                            Dim pod_FinchW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FinchW")
                            Dim pod_FinchH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FinchH")
                            Dim pod_FcmL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmL")
                            Dim pod_FcmW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmW")
                            Dim pod_FcmH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmH")
                            Dim pod_matral As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matral")
                            Dim pod_tiknes As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tiknes")
                            Dim pod_prtmtd As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtmtd")
                            Dim pod_clrfot As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrfot")
                            Dim pod_clrbck As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrbck")
                            Dim pod_finish As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish"), "'", "''")
                            Dim pod_matDsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matDsc"), "'", "''")
                            Dim pod_tikDsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tikDsc"), "'", "''")
                            Dim pod_prtDsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtDsc"), "'", "''")
                            Dim pod_rmtnce As String = ""
                            Dim pod_addres As String = Replace(dr_vendor(0).Item("vci_address").ToString, "'", "''")
                            Dim pod_state As String = dr_vendor(0).Item("vci_stt").ToString
                            Dim pod_cntry As String = dr_vendor(0).Item("vci_cty").ToString
                            Dim pod_zip As String = dr_vendor(0).Item("vci_zip").ToString
                            Dim pod_Tel As String = dr_vendor(0).Item("vci_cntphn").ToString
                            Dim pod_cntper As String = dr_vendor(0).Item("vci_cntctp").ToString
                            Dim pod_sctoqty As Integer = 0
                            Dim pod_qtyum As String = ""
                            Dim pod_curcde As String = dr_vendor(0).Item("vbi_curcde")
                            Dim pod_multip As Integer = 0
                            Dim pod_ordqty As Integer = Val(txtOrdQty.Text)
                            Dim pod_stkqty As Integer = Val(txtStkQty.Text)
                            Dim pod_wasper As Integer

                            If txtPkgWastPer.Text = "" Then
                                pod_wasper = 0
                            Else
                                pod_wasper = txtPkgWastPer.Text
                            End If

                            Dim pod_wasqty As Integer = Val(txtStandWasage.Text)
                            Dim pod_ttlordqty As Integer = Val(txtTtlOrdQty.Text)
                            Dim pod_untprc As Decimal = round(Val(txtUnitPrc.Text), 5)
                            Dim pod_ttlamtqty As Decimal = round(Val(txtTtlAmt.Text), 2)
                            Dim pod_receqty As Integer = 0
                            Dim pod_Reqno As String = ""
                            Dim pod_Reqseq As Integer = 0
                            Dim pod_Conmak As String = ""
                            Dim pod_bonqty As Integer = Val(txtWasQty.Text)
                            Dim pod_InWas As String = in_was 'Handel by SQL
                            Dim pod_MOA As Integer = 0 'Handel by SQL





                            gspStr = "sp_insert_PKORDDTL_09 '" & pod_cocde & "','" & pod_ordno & "'," & pod_seq & ",'" & _
                           pod_status & "','" & pod_pkgitm & "','" & pod_pkgven & "','" & pod_cate & "','" & _
                           pod_chndsc & "','" & pod_engdsc & "','" & pod_remark & "'," & pod_EInchL & "," & _
                           pod_EInchW & "," & pod_EInchH & "," & pod_EcmL & "," & pod_EcmW & "," & _
                           pod_EcmH & "," & pod_FInchL & "," & pod_FinchW & "," & pod_FinchH & "," & _
                           pod_FcmL & "," & pod_FcmW & "," & pod_FcmH & ",'" & pod_matral & "','" & _
                           pod_tiknes & "','" & pod_prtmtd & "','" & pod_clrfot & "','" & pod_clrbck & "','" & _
                           pod_finish & "','" & pod_matDsc & "','" & pod_tikDsc & "','" & pod_prtDsc & "','" & _
                           pod_rmtnce & "','" & pod_addres & "','" & pod_state & "','" & pod_cntry & "','" & _
                           pod_zip & "','" & pod_Tel & "','" & pod_cntper & "'," & pod_sctoqty & ",'" & _
                           pod_qtyum & "','" & pod_curcde & "'," & pod_multip & "," & pod_ordqty & "," & _
                           pod_stkqty & "," & pod_wasper & "," & pod_wasqty & "," & pod_ttlordqty & "," & _
                           pod_untprc & "," & pod_ttlamtqty & "," & pod_receqty & ",'" & pod_Reqno & "'," & _
                           pod_Reqseq & ",'" & pod_Conmak & "'," & pod_bonqty & ",'" & pod_InWas & "','" & gsUsrID & "'"

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                Me.Cursor = Cursors.Default
                                MsgBox("Error on loading cmdGen_Click sp_insert_PKORDDTL_09 : " & rtnStr)
                                Exit Sub

                            End If


                            If rdoIn.Checked = True Then


                                If txtStkQty.Text <> "0" Then


                                    gspStr = "sp_insert_PKINVDTL_09 '','" & Trim(txtPkgItem.Text) & "','" & NewOrderNo & "'," & 1 & "," & _
                                    txtOrdQty.Text & "," & Val(txtStkQty.Text) & "," & Val(txtWasQty.Text) & "," & txtTtlOrdQty.Text & ",'" & gsUsrID & "'"


                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        Me.Cursor = Cursors.Default
                                        MsgBox("Error on loading cmdGen_Click sp_insert_PKINVDTL_09 : " & rtnStr)
                                        Exit Sub

                                    End If

                                End If






                            ElseIf rdoOut.Checked = True Then


                                If txtStkQty.Text <> "0" Then


                                    gspStr = "sp_insert_PKINVDTL_09 '','" & Trim(txtPkgItem.Text) & "','" & NewOrderNo & "'," & 1 & "," & _
                                    txtOrdQty.Text & "," & Val(txtStkQty.Text) & "," & Val(txtWasQty.Text) & "," & txtTtlOrdQty.Text & ",'" & gsUsrID & "'"


                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        Me.Cursor = Cursors.Default
                                        MsgBox("Error on loading cmdGen_Click sp_insert_PKINVDTL_09 : " & rtnStr)
                                        Exit Sub

                                    End If

                                End If


                            End If

                        End If


                        If currentOrderNO <> rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno") Then

                            '  If txtScFrm.Text <> "" And txtScTo.Text <> "" Then
                            If rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("flag") = "sc" Then

                                gspStr = "sp_select_SCORDHDR_PKG02 '" & cboCoCde.Text & "','" & rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno") & "'"
                                rtnLong = execute_SQLStatement(gspStr, rs_SCORDHDR, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    Cursor = Cursors.Default
                                    MsgBox("Error on loading cmdGen_Click sp_select_SCORDHDR_PKG02 :" & rtnStr)
                                    Exit Sub
                                End If


                                gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','KR','" & gsUsrID & "'"
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                                If rtnLong <> RC_SUCCESS Then
                                    Me.Cursor = Cursors.Default
                                    MsgBox("Error on loading cmdGen_Click sp_select_DOC_GEN :" & rtnStr)
                                    Exit Sub
                                End If

                                NewPKGREQHDR = rs.Tables("RESULT").Rows(0).Item(0)



                                Dim cocde As String = cboCoCde.Text
                                Dim reqno As String = NewPKGREQHDR
                                Dim ver As Integer = 1
                                Dim issdat As String = DateTime.Now.ToShortDateString
                                Dim revdat As String = DateTime.Now.ToShortDateString
                                Dim status As String = "REL"
                                Dim cus1no As String = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_cus1no")
                                Dim cus2no As String = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_cus2no")
                                Dim saldiv As String = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_saldiv")
                                Dim saltem As String = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_saltem")
                                Dim salrep As String = Split(rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_srname"), " - ")(0)
                                Dim ToNo As String = ""
                                Dim ToVer As String = ""
                                Dim ToSts As String = ""
                                Dim ToIsdat As Object = "1900/01/01"
                                Dim ToRevdat As Object = "1900/01/01"
                                Dim ToRefqut As String = ""
                                Dim potyp As String = ""
                                Dim ScNo As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno")
                                Dim ScVer As String = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_verno")
                                Dim ScSts As String = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_ordsts")
                                Dim ScIsdat As Object = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_issdat")
                                Dim ScRevdat As Object = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_rvsdat")
                                Dim ScPodat As Object = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_cpodat")
                                Dim ScCandat As Object = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_candat")
                                Dim ScShpDatstr As Object = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_shpstr")
                                Dim ScShpdatend As Object = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_shpend")
                                Dim ScRemark As String = rs_SCORDHDR.Tables("RESULT").Rows(0).Item("soh_rmk")
                                Dim flagHdr As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate")

                                gspStr = "sp_insert_PKREQHDR '" & cocde & "','" & reqno & "'," & ver & ",'" & issdat & "','" & revdat & "','" & _
                                          status & "','" & cus1no & "','" & cus2no & "','" & saldiv & "','" & saltem & "','" & _
                                          salrep & "','" & ToNo & "','" & ToVer & "','" & ToSts & "','" & ToIsdat & "','" & _
                                          ToRevdat & "','" & ToRefqut & "','" & potyp & "','" & ScNo & "','" & ScVer & "','" & _
                                          ScSts & "','" & ScIsdat & "','" & ScRevdat & "','" & ScPodat & "','" & ScCandat & "','" & _
                                          ScShpDatstr & "','" & ScShpdatend & "','" & Replace(ScRemark, "'", "''") & "','" & flagHdr & "','" & gsUsrID & "'"


                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    Me.Cursor = Cursors.Default
                                    MsgBox("Error on loading cmdGen_click sp_insert_PKREQHDR :" & rtnStr)

                                    Exit Sub
                                Else
                                    msg = msg & " Packaging Request#: " & NewPKGREQHDR & " created for SC " & rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno") & Environment.NewLine
                                End If



                                '    ElseIf txtToFrm.Text <> "" And txtToTo.Text <> "" Then
                            ElseIf rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("flag") = "to" Then


                                gspStr = "sp_select_TOORDHDR_PKG02 '" & cboCoCde.Text & "','" & rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno") & "'"
                                rtnLong = execute_SQLStatement(gspStr, rs_TOORDHDR, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    Cursor = Cursors.Default
                                    MsgBox("Error on loading cmdGen_click sp_select_TOORDHDR_PKG02 :" & rtnStr)
                                    Exit Sub
                                End If


                                gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','KR','" & gsUsrID & "'"
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                                If rtnLong <> RC_SUCCESS Then
                                    Me.Cursor = Cursors.Default
                                    MsgBox("Error on loading cmdGen_Click sp_select_DOC_GEN :" & rtnStr)
                                    Exit Sub
                                End If

                                NewPKGREQHDR = rs.Tables("RESULT").Rows(0).Item(0)



                                Dim cocde As String = cboCoCde.Text  'do here
                                Dim reqno As String = NewPKGREQHDR
                                Dim ver As Integer = 1
                                Dim issdat As String = DateTime.Now.ToShortDateString
                                Dim revdat As String = DateTime.Now.ToShortDateString
                                Dim status As String = "REL"
                                Dim cus1no As String = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus1no")
                                Dim cus2no As String = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_cus2no")
                                Dim saldiv As String = Split(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_saltem"), " ")(1)
                                Dim saltem As String = Split(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_saltem"), " ")(3).Substring(0, 1)
                                Dim salrep As String = Split(rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_salrep"), " - ")(0)
                                Dim ToNo As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno")
                                Dim ToVer As String = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_verno")
                                Dim ToSts As String = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_ordsts")
                                Dim ToIsdat As Object = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_issdat")
                                Dim ToRevdat As Object = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_rvsdat")
                                Dim ToRefqut As String = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_refqut")
                                Dim potyp As String = ""
                                Dim ScNo As String = ""
                                Dim ScVer As String = 0
                                Dim ScSts As String = ""
                                Dim ScIsdat As Object = "1900/01/01"
                                Dim ScRevdat As Object = "1900/01/01"
                                Dim ScPodat As Object = "1900/01/01"
                                Dim ScCandat As Object = "1900/01/01"
                                Dim ScShpDatstr As Object = "1900/01/01"
                                Dim ScShpdatend As Object = "1900/01/01"
                                Dim ScRemark As String = ""
                                Dim flagHdr As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate")


                                gspStr = "sp_insert_PKREQHDR '" & cocde & "','" & NewPKGREQHDR & "'," & ver & ",'" & issdat & "','" & revdat & "','" & _
                                          status & "','" & cus1no & "','" & cus2no & "','" & saldiv & "','" & saltem & "','" & _
                                          salrep & "','" & ToNo & "','" & ToVer & "','" & ToSts & "','" & ToIsdat & "','" & _
                                          ToRevdat & "','" & ToRefqut & "','" & potyp & "','" & ScNo & "','" & ScVer & "','" & _
                                          ScSts & "','" & ScIsdat & "','" & ScRevdat & "','" & ScPodat & "','" & ScCandat & "','" & _
                                          ScShpDatstr & "','" & ScShpdatend & "','" & Replace(ScRemark, "'", "''") & "','" & flagHdr & "','" & gsUsrID & "'"


                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    Me.Cursor = Cursors.Default
                                    MsgBox("Error on loading cmdGen_click sp_insert_PKREQHDR :" & rtnStr)

                                    Exit Sub
                                Else
                                    msg = msg & " Packaging Request#: " & NewPKGREQHDR & " created for TO " & rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno") & Environment.NewLine
                                End If


                            End If

                            '''20140409
                            'gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & NewOrderNo & "','" & NewOrderNo & "'," & _
                            '            i + 1 & ",'" & _
                            '            NewPKGREQHDR & "'," & _
                            '            "1" & ",'" & _
                            '            LCase(gsUsrID) & "'"
                            'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            'rs = Nothing
                            'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            'Me.Cursor = Windows.Forms.Cursors.Default
                            'If rtnLong <> RC_SUCCESS Then
                            '    MsgBox("Error on saving PGM00009 #004 sp_insert_PKGRPDTL : " & rtnStr)
                            '    Exit Sub
                            'End If



                        End If

                        Dim reqdtl_cocde As String = cboCoCde.Text
                        Dim reqdtl_reqno As String = NewPKGREQHDR
                        'dim reqdtl_seq As Integer ---------------Seq handled by sql
                        Dim reqdtl_itemno As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("realitem")
                        Dim reqdtl_assitm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("assitem")
                        Dim reqdtl_tmpitmno As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("tempitem")
                        Dim reqdtl_venno As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("venitemno")
                        Dim reqdtl_venitm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("venitem")
                        Dim reqdtl_pckunt As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("um")
                        Dim reqdtl_inrqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("inr")
                        Dim reqdtl_mtrqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("mst")
                        Dim reqdtl_cft As Decimal = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("cft")
                        Dim reqdtl_colcde As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("colcde")
                        Dim reqdtl_conftr As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("conftr")
                        Dim reqdtl_ftyprctrm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ftyprctrm")
                        Dim reqdtl_hkprctrm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("hkprctrm")
                        Dim reqdtl_trantrm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("trantrm")
                        Dim reqdtl_pkgitm As String = txtPkgItem.Text
                        Dim reqdtl_pkgven As String = Split(cboVendor.Text, " - ")(0)
                        Dim reqdtl_cate As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate")
                        Dim reqdtl_chndsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_chndsc"), "'", "''")
                        Dim reqdtl_engdsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_engdsc"), "'", "''")
                        Dim reqdtl_remark As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_remark"), "'", "''")
                        Dim reqdtl_EinchL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchL")
                        Dim reqdtl_EinchW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchW")
                        Dim reqdtl_EinchH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchH")
                        Dim reqdtl_EcmL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmL")
                        Dim reqdtl_EcmW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmW")
                        Dim reqdtl_EcmH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmH")
                        Dim reqdtl_FinchL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchL")
                        Dim reqdtl_FinchW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FinchW")
                        Dim reqdtl_FinchH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FinchH")
                        Dim reqdtl_FcmL As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmL")
                        Dim reqdtl_FcmW As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmW")
                        Dim reqdtl_FcmH As Decimal = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmH")
                        Dim reqdtl_matral As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matral")
                        Dim reqdtl_tiknes As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tiknes")
                        Dim reqdtl_prtmtd As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtmtd")
                        Dim reqdtl_clrfot As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrfot")
                        Dim reqdtl_clrbck As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrbck")
                        Dim reqdtl_finish As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish"), "'", "''")
                        Dim reqdtl_matdsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matDsc"), "'", "''")
                        Dim reqdtl_tckdsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tikDsc"), "'", "''")
                        Dim reqdtl_prtdsc As String = Replace(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtDsc"), "'", "''")
                        'dim reqdtl_finfot As String
                        'dim reqdtl_finbck As String
                        Dim reqdtl_rmtnce As String = ""
                        Dim reqdtl_addres As String = Replace(dr_vendor(0).Item("vci_address").ToString, "'", "''")
                        Dim reqdtl_state As String = dr_vendor(0).Item("vci_stt").ToString
                        Dim reqdtl_cntry As String = dr_vendor(0).Item("vci_cty").ToString
                        Dim reqdtl_zip As String = dr_vendor(0).Item("vci_zip").ToString
                        Dim reqdtl_Tel As String = dr_vendor(0).Item("vci_cntphn").ToString
                        Dim reqdtl_cntper As String = dr_vendor(0).Item("vci_cntctp").ToString
                        Dim reqdtl_sctoqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("stqty")
                        Dim reqdtl_qtyum As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("um")
                        Dim reqdtl_curcde As String = dr_vendor(0).Item("vbi_curcde")
                        Dim reqdtl_multip As Integer = 0
                        Dim reqdtl_ordqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordqty")
                        Dim reqdtl_wasper As Decimal = Calculate_Req_Wasqty(reqdtl_ordqty, "PER")
                        Dim reqdtl_wasqty As Integer = Calculate_Req_Wasqty(reqdtl_ordqty, "QTY")
                        Dim reqdtl_ttlordqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordqty") + rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("wasqty")  'Bug Fix for sum up qty should be plus bon_qty
                        Dim reqdtl_untprc As Decimal = round(Val(txtUnitPrc.Text), 5)
                        Dim reqdtl_ttlamtqty As Decimal = round((rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordqty") + rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("wasqty")) * round(Val(txtUnitPrc.Text), 5), 2) 'Bug Fix for sum up qty should be plus bon_qty
                        Dim reqdtl_receqty As Integer = 0
                        Dim reqdtl_ordno As String = NewOrderNo
                        Dim reqdtl_ScToNo As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno")
                        Dim reqdtl_ScToSeq As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("seq")
                        Dim flagDtl As String = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate")
                        Dim reqdtl_sku As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("sku")
                        Dim reqdtl_cusitm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("custitm")
                        Dim reqdtl_bonqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("wasqty")

                        gspStr = "sp_insert_PKREQDTL_09 '" & reqdtl_cocde & "','" & NewPKGREQHDR & "'," & 0 & ",'" & reqdtl_itemno & "','" & reqdtl_assitm & "','" & reqdtl_tmpitmno & "','" & _
                                                   reqdtl_venno & "','" & reqdtl_venitm & "','" & reqdtl_pckunt & "'," & reqdtl_inrqty & "," & reqdtl_mtrqty & "," & reqdtl_cft & ",'" & reqdtl_colcde & "'," & reqdtl_conftr & ",'" & _
                                                   reqdtl_ftyprctrm & "','" & reqdtl_hkprctrm & "','" & reqdtl_trantrm & "','" & reqdtl_pkgitm & "','" & reqdtl_pkgven & "','" & _
                                                   reqdtl_cate & "','" & reqdtl_chndsc & "','" & reqdtl_engdsc & "','" & reqdtl_remark & "'," & reqdtl_EinchL & "," & _
                                                   reqdtl_EinchW & "," & reqdtl_EinchH & "," & reqdtl_EcmL & "," & reqdtl_EcmW & "," & reqdtl_EcmH & "," & _
                                                   reqdtl_FinchL & "," & reqdtl_FinchW & "," & reqdtl_FinchH & "," & reqdtl_FcmL & "," & reqdtl_FcmW & "," & _
                                                      reqdtl_FcmH & ",'" & reqdtl_matral & "','" & reqdtl_tiknes & "','" & reqdtl_prtmtd & "','" & reqdtl_clrfot & "','" & _
                                                   reqdtl_clrbck & "','" & reqdtl_finish & "','" & reqdtl_matdsc & "','" & reqdtl_tckdsc & "','" & reqdtl_prtdsc & "','" & reqdtl_rmtnce & "','" & reqdtl_addres & "','" & reqdtl_state & "','" & _
                                                   reqdtl_cntry & "','" & reqdtl_zip & "','" & reqdtl_Tel & "','" & reqdtl_cntper & "'," & reqdtl_sctoqty & ",'" & _
                                                   reqdtl_qtyum & "','" & reqdtl_curcde & "'," & reqdtl_multip & "," & reqdtl_ordqty & "," & reqdtl_wasper & "," & _
                                                   reqdtl_wasqty & "," & reqdtl_ttlordqty & "," & reqdtl_untprc & "," & reqdtl_ttlamtqty & "," & reqdtl_receqty & ",'" & flagDtl & "','" & reqdtl_ordno & "','" & _
                                                   reqdtl_ScToNo & "'," & reqdtl_ScToSeq & ",'" & reqdtl_sku & "','" & reqdtl_cusitm & "'," & reqdtl_bonqty & ",'" & gsUsrID & "'"

                        '''                                                   reqdtl_wasqty & "," & reqdtl_ttlordqty & "," & reqdtl_untprc & "," & reqdtl_ttlamtqty & "," & reqdtl_receqty & ",'" & flagDtl & "','" & NewOrderNo & "','" & _

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Cursors.Default
                            MsgBox("Error on loading cmdGen_Click sp_insert_PKREQDTL_09 :" & rtnStr)

                            Exit Sub
                        End If
                        Dim temp_prd_reqno As String = rs.Tables("RESULT").Rows(0).Item("prd_reqno")
                        Dim temp_prd_seq As String = rs.Tables("RESULT").Rows(0).Item("prd_seq")

                        gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & NewOrderNo & "','" & NewOrderNo & "'," & _
                                       i + 1 & ",'" & _
                                       rs.Tables("RESULT").Rows(0).Item("prd_reqno") & "'," & _
                                       rs.Tables("RESULT").Rows(0).Item("prd_seq") & ",'" & _
                                       LCase(gsUsrID) & "'"


                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rs = Nothing
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on saving PGM00009 #004 sp_insert_PKGRPDTL : " & rtnStr)
                            Exit Sub
                        End If


                        rs = Nothing

                        gspStr = "sp_insert_PKMAPDTL '" & cboCoCde.Text & "','" & "9" & "','" & NewOrderNo & "'," & _
                                                    1 & ",'" & _
                                                   temp_prd_reqno & "'," & _
                                                  temp_prd_seq & ",'" & _
                                                   LCase(gsUsrID) & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rs = Nothing
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKMAPDTL : " & rtnStr)
                            Exit Sub
                        End If



                        currentOrderNO = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno")



                        Dim pgs_cocde As String = cboCoCde.Text
                        Dim pgs_pkordno As String = NewOrderNo
                        Dim pgs_Count As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("Counter")
                        Dim pgs_Gen As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("Gen")
                        Dim pgs_ordno As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordno")
                        Dim pgs_seq As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("seq")
                        Dim pgs_item As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("realitem")
                        Dim pgs_assitm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("assitem")
                        Dim pgs_custitm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("custitm")
                        Dim pgs_sku As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("sku")
                        Dim pgs_tmpitm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("tempitem")
                        Dim pgs_venitm As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("venitem")
                        Dim pgs_venno As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("venitemno")
                        Dim pgs_colcde As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("colcde")
                        Dim pgs_ordqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("ordqty")
                        Dim pgs_wasqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("wasqty")
                        Dim pgs_sctoqty As Integer = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("stqty")
                        Dim pgs_Terms As String = rs_TOSCDETAIL_tmp_sorttable.Rows(i).Item("Terms")
                        Dim pgs_usrid As String = gsUsrID

                        gspStr = "sp_insert_PKGENST '" & pgs_cocde & "','" & pgs_pkordno & "'," & pgs_Count & ",'" & pgs_Gen & "','" & pgs_ordno & "'," & pgs_seq & ",'" & _
                                                   pgs_item & "','" & pgs_assitm & "','" & pgs_custitm & "','" & pgs_sku & "','" & pgs_tmpitm & "','" & pgs_venitm & "','" & pgs_venno & "','" & pgs_colcde & "'," & _
                                                   pgs_ordqty & "," & pgs_wasqty & "," & pgs_sctoqty & ",'" & pgs_Terms & "','" & pgs_usrid & "'"



                        '''                                                   reqdtl_wasqty & "," & reqdtl_ttlordqty & "," & reqdtl_untprc & "," & reqdtl_ttlamtqty & "," & reqdtl_receqty & ",'" & flagDtl & "','" & NewOrderNo & "','" & _

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Cursors.Default
                            MsgBox("Error on loading cmdGen_Click sp_insert_PKGENST :" & rtnStr)

                            Exit Sub
                        End If



                    End If


                    'Do it here


                Next

                If msg = "" Then
                    Call cmdClear_Click(sender, e)
                    txtReqNo.Text = "No Packaging Request/Order has been Create"
                Else
                    'Call cmdClear_Click(sender, e)
                    txtReqNo.Text = msg
                    'MsgBox(msg)
                End If
            End If

            If save_pkmtlshp() = True Then

            Else
                MsgBox("Multiple Shipment Save Fail")
                Exit Sub
            End If

            If save_PKGENQP() = True Then
            Else
                MsgBox("Cost & Price Save Fail")
                Exit Sub
            End If


        End If

        If msg <> "" Then
            MsgBox(msg)
        End If

        cmdGen.Enabled = False

        cmdBackToResultPage.Enabled = False


    End Sub

    Private Function Calculate_Req_Wasqty(ByVal Ordqty As Integer, ByVal type As String) As Integer

        Dim result As Integer = 0

        If type = "PER" Then

          
            Dim cate As String = Split(txtPkgItem.Text, "-")(0)

            Dim dr() As DataRow
            dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & Ordqty & " and pwa_qtyto >= " & Ordqty)

            If dr.Length <> 0 Then
                If dr(0)("pwa_um") = "%" Then

                    result = Fix(dr(0).Item("pwa_wasage"))
                    ''txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    '' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    'txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                Else
                    result = 0
                    ''txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
                    'txtStandWasage.Text = Fix(dr(0).Item("pwa_wasage"))
                End If

            End If

        ElseIf type = "QTY" Then

            Dim cate As String = Split(txtPkgItem.Text, "-")(0)

            Dim dr() As DataRow
            dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & Ordqty & " and pwa_qtyto >= " & Ordqty)

            If dr.Length <> 0 Then
                If dr(0)("pwa_um") = "%" Then

                    result = Math.Round(Ordqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                    ''txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    '' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    'txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                Else
                    result = Fix(dr(0).Item("pwa_wasage"))
                    ''txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
                    'txtStandWasage.Text = Fix(dr(0).Item("pwa_wasage"))
                End If

            End If

        End If

        Return result


    End Function

    
    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        'If BaseTabControl1.SelectedIndex = 1 Then
        '    If Got_Focus_Grid = "GoodsRec" Then

        Dim rowcount As Integer
        If rs_pkmltshp Is Nothing Then

            Exit Sub
        End If
        rowcount = rs_pkmltshp.Tables("RESULT").Rows.Count
        'Dim dr() As DataRow = rs_TODTLSHP.Tables("RESULT").Select("tds_toordno = ''")
        Dim dr() As DataRow = rs_pkmltshp.Tables("RESULT").Select("pms_shpqty = 0 and pms_ordseq = " & "1")
        Dim dr2() As DataRow = rs_pkmltshp.Tables("RESULT").Select("pms_ordseq = " & "1", "pms_shpseq ASC")
        'sFilter = "tds_toordseq = " & seq & " and tds_verno = " & ver

        Dim maxseq As Integer

        Dim tb As New DataTable
        tb = rs_pkmltshp.Tables("RESULT").Clone

        Dim datar As DataRow

        For Each datar In dr2
            tb.ImportRow(datar)
        Next

        Dim seqObject As Object = tb.Compute("Max(pms_shpseq)", "")
        Dim seq As Integer
        If IsDBNull(seqObject) Then
            seq = 0 + 1
        Else
            seq = Convert.ToInt32(seqObject) + 1
        End If

        For index2 As Integer = 0 To rs_pkmltshp.Tables("RESULT").Columns.Count - 1
            rs_pkmltshp.Tables("RESULT").Columns(index2).ReadOnly = False
        Next

        If dr.Length = 0 Then
            rs_pkmltshp.Tables("RESULT").Rows.Add()

            '  rs_pkordrec.Tables("RESULT").Rows(rowcount).Item("Gen") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("Del") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_cocde") = cboCoCde.Text
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_ordno") = NewOrderNo 'txtReqNo.Text
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_ordseq") = "1"
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_shpseq") = seq
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_shpstrdat") = DBNull.Value
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_shpenddat") = DBNull.Value
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_shpqty") = 0
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_um") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_fty") = ""

            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_address") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_state") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_cntry") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_zip") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_cntper") = ""
            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_tel") = ""

            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_remark") = ""



            rs_pkmltshp.Tables("RESULT").Rows(rowcount).Item("pms_creusr") = "~*ADD*~"

            display_dgMLTSHP(1)
            dgMltShp.CurrentCell = dgMltShp.Rows(seq - 1).Cells(5)
            dgMltShp.BeginEdit(True)


        End If



        'recordstatus = True

        '    End If
        'End If

    End Sub


    Private Sub display_dgMLTSHP(ByVal seq As Integer)
        If rs_PKMLTSHP.Tables.Count = 0 Then
            Exit Sub

        End If

        rs_PKMLTSHP.Tables("RESULT").DefaultView.Sort = "pms_ordseq , pms_shpseq"



        dgMltShp.DataSource = rs_PKMLTSHP.Tables("RESULT").DefaultView

        If rs_PKMLTSHP.Tables("RESULT").Rows.Count > 0 Then
            Dim sFilter As String
            sFilter = "pms_ordseq = " & seq
            rs_PKMLTSHP.Tables("RESULT").DefaultView.RowFilter = sFilter
            'dgMShp.DataSource = rs_TODTLSHP.Tables("RESULT").DefaultView
        End If




        dgMltShp.RowHeadersWidth = 18
        dgMltShp.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgMltShp.ColumnHeadersHeight = 18
        dgMltShp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgMltShp.AllowUserToResizeColumns = True
        dgMltShp.AllowUserToResizeRows = False
        dgMltShp.RowTemplate.Height = 18

        Dim i As Integer

        For i = 0 To rs_PKMLTSHP.Tables("RESULT").Columns.Count - 1
            rs_PKMLTSHP.Tables("RESULT").Columns(i).ReadOnly = False
        Next


        For i = 0 To dgMltShp.Columns.Count - 1

            Select Case i

                Case 0

                    dgMltShp.Columns(i).HeaderText = "Del"
                    dgMltShp.Columns(i).Width = 30

                Case 1

                    dgMltShp.Columns(i).HeaderText = "Company code"

                    dgMltShp.Columns(i).Visible = False

                Case 2
                    dgMltShp.Columns(i).HeaderText = "Order no"

                    dgMltShp.Columns(i).Visible = False

                Case 3
                    dgMltShp.Columns(i).HeaderText = "Order seq"

                    dgMltShp.Columns(i).Visible = False
                Case 4
                    dgMltShp.Columns(i).HeaderText = "Seq"
                    dgMltShp.Columns(i).Width = 40
                    dgMltShp.Columns(i).ReadOnly = True
                Case 5
                    dgMltShp.Columns(i).HeaderText = "Delivery Date"
                    dgMltShp.Columns(i).Width = 90
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 6
                    dgMltShp.Columns(i).HeaderText = "Ship End Date"
                    'dgMltShp.Columns(i).Width = 95
                    'If "ReadOnly"  = "ReadOnly" Then
                    '    dgMltShp.Columns(i).ReadOnly = False
                    'End If
                    dgMltShp.Columns(i).Visible = False
                Case 7
                    dgMltShp.Columns(i).HeaderText = "Qty"
                    dgMltShp.Columns(i).Width = 60
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 8
                    dgMltShp.Columns(i).HeaderText = "um"
                    dgMltShp.Columns(i).Visible = False

                Case 9
                    dgMltShp.Columns(i).HeaderText = "Fty"
                    dgMltShp.Columns(i).Width = 120
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 10
                    dgMltShp.Columns(i).HeaderText = "Address"
                    dgMltShp.Columns(i).Width = 250
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 11
                    dgMltShp.Columns(i).HeaderText = "State"
                    dgMltShp.Columns(i).Width = 120
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 12
                    dgMltShp.Columns(i).HeaderText = "Country"
                    dgMltShp.Columns(i).Width = 90
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 13
                    dgMltShp.Columns(i).HeaderText = "Zip"
                    dgMltShp.Columns(i).Width = 80
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 14
                    dgMltShp.Columns(i).HeaderText = "Tel"
                    dgMltShp.Columns(i).Width = 120
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If
                Case 15
                    dgMltShp.Columns(i).HeaderText = "Contact Person"
                    dgMltShp.Columns(i).Width = 120
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If

                Case 16
                    dgMltShp.Columns(i).HeaderText = "Remark"
                    dgMltShp.Columns(i).Width = 200
                    If "ReadOnly" = "ReadOnly" Then
                        dgMltShp.Columns(i).ReadOnly = False
                    End If


                Case Else
                    dgMltShp.Columns(i).Visible = False
            End Select



        Next

    End Sub

    Private Sub dgMltShp_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMltShp.CellBeginEdit
        dgMltShpEditCellRow = sender.CurrentCell.RowIndex
        dgMltShpEditCellCol = sender.CurrentCell.ColumnIndex

    End Sub
    'Private Sub display_dgMLTSHP(ByVal seq As Integer)

    '    If rs_pkmltshp.Tables.Count = 0 Then
    '        Exit Sub
    '    End If

    '    'If rs_pkmltshp.Tables("RESULT").Rows.Count > 0 Then
    '    '    Dim sFilter As String
    '    '    sFilter = "pms_ordseq = " & seq
    '    '    rs_pkmltshp.Tables("RESULT").DefaultView.RowFilter = sFilter
    '    '    'dgMShp.DataSource = rs_TODTLSHP.Tables("RESULT").DefaultView
    '    'End If



    '    dgMltShp.DataSource = rs_pkmltshp.Tables("RESULT").DefaultView

    '    dgMltShp.RowHeadersWidth = 18
    '    dgMltShp.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
    '    dgMltShp.ColumnHeadersHeight = 18
    '    dgMltShp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '    dgMltShp.AllowUserToResizeColumns = True
    '    dgMltShp.AllowUserToResizeRows = False
    '    dgMltShp.RowTemplate.Height = 18

    '    Dim i As Integer

    '    For i = 0 To rs_pkmltshp.Tables("RESULT").Columns.Count - 1
    '        rs_pkmltshp.Tables("RESULT").Columns(i).ReadOnly = False
    '    Next


    '    For i = 0 To dgMltShp.Columns.Count - 1

    '        Select Case i

    '            Case 0

    '                dgMltShp.Columns(i).HeaderText = "Del"
    '                dgMltShp.Columns(i).Width = 30
    '                dgMltShp.Columns(i).ReadOnly = True
    '            Case 1

    '                dgMltShp.Columns(i).HeaderText = "Company code"

    '                dgMltShp.Columns(i).Visible = False

    '            Case 2
    '                dgMltShp.Columns(i).HeaderText = "Order no"

    '                dgMltShp.Columns(i).Visible = False

    '            Case 3
    '                dgMltShp.Columns(i).HeaderText = "Order seq"

    '                dgMltShp.Columns(i).Visible = False
    '            Case 4
    '                dgMltShp.Columns(i).HeaderText = "Seq"
    '                dgMltShp.Columns(i).Width = 40
    '                dgMltShp.Columns(i).ReadOnly = True
    '            Case 5
    '                dgMltShp.Columns(i).HeaderText = "Delivery Date"
    '                dgMltShp.Columns(i).Width = 90
    '                'If mode <> "ReadOnly" Then
    '                dgMltShp.Columns(i).ReadOnly = False
    '                'End If
    '            Case 6
    '                dgMltShp.Columns(i).HeaderText = "Ship End Date"
    '                dgMltShp.Columns(i).Width = 95
    '                '                    If mode <> "ReadOnly" Then
    '                'dgMltShp.Columns(i).ReadOnly = False
    '                dgMltShp.Columns(i).Visible = False
    '                'End If
    '            Case 7
    '                dgMltShp.Columns(i).HeaderText = "Qty"
    '                dgMltShp.Columns(i).Width = 60
    '                'If mode <> "ReadOnly" Then
    '                dgMltShp.Columns(i).ReadOnly = False
    '                'End If
    '            Case 8
    '                dgMltShp.Columns(i).HeaderText = "um"
    '                dgMltShp.Columns(i).Visible = False

    '            Case 9
    '                dgMltShp.Columns(i).HeaderText = "Fty"
    '                dgMltShp.Columns(i).Width = 120

    '            Case 10
    '                dgMltShp.Columns(i).HeaderText = "Remark"
    '                dgMltShp.Columns(i).Width = 200
    '                'If mode <> "ReadOnly" Then
    '                dgMltShp.Columns(i).ReadOnly = False
    '                'End If


    '            Case Else
    '                dgMltShp.Columns(i).Visible = False
    '        End Select



    '    Next

    'End Sub

    Private Sub dgMltShp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMltShp.CellClick
        'If mode = "ReadOnly" Then
        '    Exit Sub
        'End If '

        If dgMltShp.RowCount = 0 Then
            Exit Sub
        End If

        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
            Exit Sub
        End If

        If dgMltShp.RowCount > 0 Then
            If dgMltShp.CurrentCell.ColumnIndex = 9 Then
                comboBoxCell(dgMltShp, "VN")
            End If
            If dgMltShp.CurrentCell.ColumnIndex = 10 Then
                comboBoxCell(dgMltShp, "AD")
            End If
            If dgMltShp.CurrentCell.ColumnIndex = 15 Then
                comboBoxCell(dgMltShp, "CT")
            End If
        End If


    End Sub


    Private Sub dgMltShp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMltShp.CellContentClick

    End Sub

    Private Sub dgMltShp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMltShp.CellDoubleClick
        'If mode = "ReadOnly" Then
        '    Exit Sub
        'End If

        If dgMltShp.RowCount = 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = -1 Or e.RowIndex = -1 Then
            Exit Sub
        End If

        If dgMltShp.RowCount > 0 Then


            If dgMltShp.CurrentCell.ColumnIndex = 0 Then
                Dim iCol As Integer = dgMltShp.CurrentCell.ColumnIndex
                Dim iRow As Integer = dgMltShp.CurrentCell.RowIndex
                Dim curvalue As String
                curvalue = IIf(IsDBNull(dgMltShp.CurrentCell.Value), "", dgMltShp.CurrentCell.Value)
                If Trim(curvalue) = "" Then

                    dgMltShp.Item(0, iRow).Value = "Y"

                Else
                    dgMltShp.Item(0, iRow).Value = ""
                End If


                'If dgMltShp.Item(dgMShp_tds_creusr, iRow).Value <> "~*ADD*~" Then
                '    dgMltShp.Item(dgMShp_tds_creusr, iRow).Value = "~*UPD*~"
                'recordstatus = True
                'End If

            End If
        End If

    End Sub

    Private Sub dgMltShp_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMltShp.CellEndEdit
        If IsDBNull(dgMltShp.Item(7, dgMltShp.CurrentCell.RowIndex).Value) = True Then
            dgMltShp.Item(7, dgMltShp.CurrentCell.RowIndex).Value = 0
        End If

        If IsDBNull(dgMltShp.Item(9, dgMltShp.CurrentCell.RowIndex).Value) = True Then
            dgMltShp.Item(9, dgMltShp.CurrentCell.RowIndex).Value = ""
        End If




        If dgMltShpEditCellCol = 9 Then

            dgMltShp.Rows(e.RowIndex).Cells(10).Value = ""
            dgMltShp.Rows(e.RowIndex).Cells(11).Value = ""
            dgMltShp.Rows(e.RowIndex).Cells(12).Value = ""
            dgMltShp.Rows(e.RowIndex).Cells(13).Value = ""
            dgMltShp.Rows(e.RowIndex).Cells(14).Value = ""
            dgMltShp.Rows(e.RowIndex).Cells(15).Value = ""
            '            cboHdrAdd_dtl.Items.Clear()
            '           cboHdrCtn_dtl.Items.Clear()

            Dim dr() As DataRow
            If dgMltShp.Rows(e.RowIndex).Cells(9).Value <> "" Then

                dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & Split(dgMltShp.Rows(e.RowIndex).Cells(9).Value, " - ")(1) & "'")
                If dr.Length <> 0 Then
                    'For j As Integer = 0 To dr.Length - 1
                    '    cboHdrAdd_dtl.Items.Add(dr(j)("vci_address").ToString)
                    'Next
                    dgMltShp.Rows(e.RowIndex).Cells(10).Value = dr(0)("vci_address").ToString

                    dgMltShp.Rows(e.RowIndex).Cells(11).Value = dr(0)("vci_stt").ToString
                    dgMltShp.Rows(e.RowIndex).Cells(12).Value = dr(0)("vci_cty").ToString
                    dgMltShp.Rows(e.RowIndex).Cells(13).Value = dr(0)("vci_zip").ToString
                    dgMltShp.Rows(e.RowIndex).Cells(14).Value = dr(0)("vci_cntphn").ToString

                    'For j As Integer = 0 To dr.Length - 1
                    '    cboHdrCtn_dtl.Items.Add(dr(j)("vci_cntctp").ToString)
                    'Next
                    dgMltShp.Rows(e.RowIndex).Cells(15).Value = dr(0)("vci_cntctp").ToString
                End If
            End If




        End If



        If Not IsDBNull(dgMltShp.Item(11, e.RowIndex).Value) Then

            If dgMltShp.Item(17, e.RowIndex).Value <> "~*ADD*~" Then
                dgMltShp.Item(17, e.RowIndex).Value = "~*UPD*~"

            End If

        End If


        '        recordstatus = True

    End Sub

    Private Sub dgMltShp_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMltShp.CellValidated
        Try
            Dim txtCell As New DataGridViewTextBoxCell
            Select Case dgMltShp.CurrentCell.ColumnIndex

                Case 9
                    'dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value = Split(dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value, " - ")(0)
                    dgMltShp.Item(9, dgMltShp.CurrentCell.RowIndex) = txtCell


            End Select
        Catch
        End Try
    End Sub

    Private Sub dgMltShp_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgMltShp.CellValidating
        'Dim row As DataGridViewRow = dgMltShp.CurrentRow
        'Dim strNewVal As String

        'strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        'If row.Cells(e.ColumnIndex).IsInEditMode Then
        '    Select Case e.ColumnIndex




        '        Case 5, 6 'Date

        '            If strNewVal = "" Then
        '                Exit Sub
        '            End If


        '            If strNewVal.Length <> 10 Or IsDate(strNewVal) = False Then

        '                'If e.ColumnIndex = 4 Then
        '                MsgBox("Please Input valid Date [MM/dd/yyyy]")
        '                e.Cancel = True
        '                'End If




        '                Exit Sub
        '                'ElseIf Convert.ToDateTime(strNewVal).Year < 2000 And strNewVal <> "01/01/1900" Then

        '                '    If e.ColumnIndex = dgMltShp_tds_ftyshpstr Then
        '                '        MsgBox("Please Input valid Fty Ship Start Date [MM/dd/yyyy] & Year must be larger than 2000!")
        '                '        e.Cancel = True
        '                '    ElseIf e.ColumnIndex = dgMltShp_tds_ftyshpend Then
        '                '        MsgBox("Please Input valid Fty Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
        '                '        e.Cancel = True
        '                '    ElseIf e.ColumnIndex = dgMltShp_tds_cushpstr Then
        '                '        MsgBox("Please Input valid Cust Ship Start Date [MM/dd/yyyy] & Year must be larger than 2000!")
        '                '        e.Cancel = True
        '                '    ElseIf e.ColumnIndex = dgMltShp_tds_cushpend Then
        '                '        MsgBox("Please Input valid Cust Ship End Date [MM/dd/yyyy] & Year must be larger than 2000!")
        '                '        e.Cancel = True

        '                '    End If

        '            End If




        '        Case 7


        '            If strNewVal = "" Then

        '                Exit Sub
        '            End If


        '            If Not IsNumeric(strNewVal) Then
        '                MsgBox("Invalid Quantity!")
        '                e.Cancel = True
        '                Exit Sub
        '            End If

        '            If strNewVal.Contains(".") = True Then
        '                MsgBox("Invalid Quantity!")
        '                e.Cancel = True
        '                Exit Sub
        '            End If

        '            'Dim dtlqty As Integer = txtPrjQty.Text
        '            'Dim currentqty As Integer = dgMltShp.Item(dgMltShp_tds_shpqty, dgMltShp.CurrentCell.RowIndex).Value
        '            'Dim sumqty As Integer = 0
        '            'Dim newqty As Integer = strNewVal
        '            'Dim i As Integer

        '            'For i = 0 To dgMltShp.Rows.Count - 1
        '            '    sumqty = sumqty + dgMltShp.Item(dgMltShp_tds_shpqty, i).Value

        '            'Next

        '            'If (sumqty + newqty - currentqty) > dtlqty Then
        '            '    MsgBox("Multiple Ship QTY must not over than Projected QTY!")
        '            '    e.Cancel = True
        '            'End If





        '    End Select
        'End If

        Dim row As DataGridViewRow = dgMltShp.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex




                Case 5, 6 'Date

                    If strNewVal = "" Then
                        Exit Sub
                    End If


                    If strNewVal.Length <> 10 Or IsDate(strNewVal) = False Then


                        MsgBox("Please Input valid Date format [MM/dd/yyyy]")
                        e.Cancel = True
                        Exit Sub


                    Else




                        If Convert.ToDateTime(Now.Date) > Convert.ToDateTime(strNewVal) Then
                            MsgBox("Ship Date cannot earlier than System Date")
                            e.Cancel = True
                            Exit Sub
                        End If

                        If e.ColumnIndex = 5 Then


                            'If IsDate(dgMltShp.Item(6, e.RowIndex).Value) = True Then

                            '    If Convert.ToDateTime(strNewVal) > Convert.ToDateTime(dgMltShp.Item(6, e.RowIndex).Value) Then
                            '        MsgBox("Ship Start Date must be earlier than Ship End Date!")
                            '        e.Cancel = True
                            '        Exit Sub
                            '    End If

                            'End If

                        ElseIf e.ColumnIndex = 6 Then


                            'If IsDate(dgMltShp.Item(5, e.RowIndex).Value) = True Then

                            '    If Convert.ToDateTime(strNewVal) < Convert.ToDateTime(dgMltShp.Item(5, e.RowIndex).Value) Then
                            '        MsgBox("Ship End Date must be later than Ship Str Date!")
                            '        e.Cancel = True
                            '        Exit Sub
                            '    End If

                            'End If

                        End If



                    End If




                Case 7


                    If strNewVal = "" Then

                        Exit Sub
                    End If




                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid Quantity!")
                        e.Cancel = True
                        Exit Sub
                    End If


                    If strNewVal.Contains(".") = True Then
                        MsgBox("Invalid Quantity!")
                        e.Cancel = True
                        Exit Sub
                    End If


                    If Convert.ToInt32(strNewVal) < 0 Then
                        MsgBox("Quantity cannot be Negative.")
                        e.Cancel = True
                        Exit Sub
                    End If

                    'Dim ttlqty As Integer = Val(txtTtlOrdQty.Text)
                    'Dim dgMltShp_tds_shpqty As Integer = 1
                    ''Dim dtlqty As Integer = txtPrjQty.Text
                    'Dim currentqty As Integer = dgMltShp.Item(dgMltShp_tds_shpqty, dgMltShp.CurrentCell.RowIndex).Value
                    'Dim sumqty As Integer = 0
                    'Dim newqty As Integer = strNewVal
                    'Dim i As Integer

                    'For i = 0 To dgMltShp.Rows.Count - 1
                    '    sumqty = sumqty + dgMltShp.Item(dgMltShp_tds_shpqty, i).Value
                    'Next

                    'If (sumqty + newqty - currentqty) <> ttlqty Then
                    '    MsgBox("Multiple Ship QTY must not over than Projected QTY!")
                    '    e.Cancel = True
                    'End If

            End Select
        End If


    End Sub

    Private Sub dgMltShp_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMltShp.DataError
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgMltShp_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgMltShp.EditingControlShowing

        'If sender.Focused = False Then
        '    Exit Sub
        'End If

        Select Case dgMltShp.CurrentCell.ColumnIndex
            Case 5, 6
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    AddHandler txtbox.KeyPress, AddressOf txt_datagridDates_KeyPress2
                    'AddHandler txtbox.TextChanged, AddressOf txt_dgSummary_TextChanged
                End If
            Case 9
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                    End If
                End If
            Case 16
                'Case Else
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    RemoveHandler txtbox.KeyPress, AddressOf txt_datagridDates_KeyPress2
                End If
        End Select


    End Sub


    Private Function save_pkmtlshp() As Boolean

        If rs_pkmltshp.Tables("RESULT") Is Nothing Then
            Return True
            Exit Function
        End If

        If rs_pkmltshp.Tables("RESULT").Rows.Count = 0 Then
            Return True
            Exit Function
        End If

        Dim del As String
        Dim pms_cocde As String
        Dim pms_ordno As String
        Dim pms_ordseq As Integer
        Dim pms_shpseq As Integer
        Dim pms_shpstrdat As DateTime
        Dim pms_shpenddat As DateTime
        Dim pms_shpqty As Integer
        Dim pms_um As String
        Dim pms_fty As String
        Dim pms_remark As String
        Dim pms_creusr As String
        Dim count As Integer

        Dim pms_address As String
        Dim pms_state As String
        Dim pms_cntry As String
        Dim pms_zip As String
        Dim pms_cntper As String
        Dim pms_tel As String

        For i As Integer = 0 To rs_pkmltshp.Tables("RESULT").Rows.Count - 1
            count = 0
            del = rs_pkmltshp.Tables("RESULT").Rows(i).Item("Del")
            pms_cocde = rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_cocde")
            pms_ordno = NewOrderNo ' rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_ordno")
            pms_ordseq = rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_ordseq")
            pms_shpseq = rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpseq")
            pms_shpstrdat = IIf(IsDBNull(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpstrdat")), "01/01/1900", rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpstrdat"))
            pms_shpenddat = "1900/01/01" 'IIf(IsDBNull(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpenddat")), "01/01/1900", rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpenddat"))
            pms_shpqty = rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_shpqty")
            pms_um = rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_um")
            count = CountCharacter(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_fty"), " - ")
            pms_fty = Split(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_fty"), " - ")(count)

            pms_address = Replace(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_address"), "'", "''")
            pms_state = Replace(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_state"), "'", "''")
            pms_cntry = Replace(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_cntry"), "'", "''")
            pms_zip = Replace(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_zip"), "'", "''")
            pms_cntper = Replace(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_cntper"), "'", "''")
            pms_tel = Replace(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_tel"), "'", "''")


            pms_remark = Replace(rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_remark"), "'", "''")
            pms_creusr = rs_pkmltshp.Tables("RESULT").Rows(i).Item("pms_creusr")

            If del = "Y" Then
                gspStr = "sp_Physical_Delete_PKMTLSHP '" & pms_cocde & "','" & pms_ordno & "'," & pms_ordseq & "," & pms_shpseq

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_pkmtlshp sp_Physical_Delete_PKMTLSHP :" & rtnStr)
                    Return False
                    Exit Function
                End If


            ElseIf pms_creusr = "~*ADD*~" Then
                gspStr = "sp_insert_PKMTLSHP '" & pms_cocde & "','" & pms_ordno & "'," & pms_ordseq & "," & pms_shpseq & ",'" & pms_shpstrdat & "','" & _
                                           pms_shpenddat & "'," & pms_shpqty & ",'" & pms_um & "','" & pms_fty & _
                                           "','" & pms_address & _
                                           "','" & pms_state & _
                                           "','" & pms_cntry & _
                                           "','" & pms_zip & _
                                           "','" & pms_cntper & _
                                           "','" & pms_tel & _
                                           "','" & pms_remark & _
                                           "','" & gsUsrID & "'"

                '    gspStr = "sp_insert_PKMTLSHP '" & pms_cocde & "','" & pms_ordno & "'," & pms_ordseq & "," & pms_shpseq & ",'" & pms_shpstrdat & "','" & _
                '                                   pms_shpenddat & "'," & pms_shpqty & ",'" & pms_um & "','" & pms_fty & "','" & pms_remark & "','" & gsUsrID & "'"



                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_pkmtlshp sp_insert_PKMTLSHP :" & rtnStr)
                    Return False
                    Exit Function
                End If

                gspStr = "sp_insert_PKGENMD '" & pms_cocde & "','" & pms_ordno & "','" & "N" & "'," & pms_shpseq & ",'" & pms_shpstrdat & "'," & _
                                                  pms_shpqty & ",'" & pms_fty & "','" & pms_remark & "','" & gsUsrID & "'"



                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_pkmtlshp sp_insert_PKGENMD :" & rtnStr)
                    Return False
                    Exit Function
                End If



            ElseIf pms_creusr = "~*UPD*~" Then
                gspStr = "sp_update_PKMTLSHP '" & pms_cocde & "','" & pms_ordno & "'," & pms_ordseq & "," & pms_shpseq & ",'" & pms_shpstrdat & "','" & _
                                 pms_shpenddat & "'," & pms_shpqty & ",'" & pms_um & "','" & pms_fty & _
                                                                                 "','" & pms_address & _
                                "','" & pms_state & _
                                "','" & pms_cntry & _
                                "','" & pms_zip & _
                                "','" & pms_cntper & _
                               "','" & pms_tel & _
                                 "','" & pms_remark & "','" & gsUsrID & "'"


                ' gspStr = "sp_update_PKMTLSHP '" & pms_cocde & "','" & pms_ordno & "'," & pms_ordseq & "," & pms_shpseq & ",'" & pms_shpstrdat & "','" & _
                '                                 pms_shpenddat & "'," & pms_shpqty & ",'" & pms_um & "','" & pms_fty & "','" & pms_remark & "','" & gsUsrID & "'"



                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_pkmtlshp sp_update_PKMTLSHP :" & rtnStr)
                    Return False
                    Exit Function
                End If
            End If

        Next

        Return True


    End Function


    Private Function save_PKGENQP() As Boolean


        Dim pgq_cocde As String = cboCoCde.Text
        Dim pgq_pkordno As String = NewOrderNo
        Dim pgq_ordqty As Integer

        If Trim(txtOrdQty.Text) = "" Then
            pgq_ordqty = 0
        Else
            pgq_ordqty = txtOrdQty.Text
        End If


        Dim pgq_wasqty As Integer
        If Trim(txtStandWasage.Text) = "" Then
            pgq_wasqty = 0
        Else
            pgq_wasqty = txtStandWasage.Text
        End If


        Dim pgq_bonqty As Integer
        If Trim(txtWasQty.Text) = "" Then
            pgq_bonqty = 0
        Else
            pgq_bonqty = txtWasQty.Text
        End If


        Dim pgq_stkqty As Integer

        If Trim(txtStkQty.Text) = "" Then
            pgq_stkqty = 0
        Else
            pgq_stkqty = txtStkQty.Text
        End If

        Dim pgq_ttlordqty As Integer

        If Trim(txtTtlOrdQty.Text) = "" Then
            pgq_ttlordqty = 0
        Else
            pgq_ttlordqty = txtTtlOrdQty.Text
        End If



        Dim pgq_unitprc As Decimal

        If Trim(txtUnitPrc.Text) = "" Then
            pgq_unitprc = 0
        Else
            pgq_unitprc = txtUnitPrc.Text
            pgq_unitprc = round(pgq_unitprc, 5)
        End If

        Dim pgq_ttlamt As Decimal

        If Trim(txtTtlAmt.Text) = "" Then
            pgq_ttlamt = 0
        Else
            pgq_ttlamt = txtTtlAmt.Text
            pgq_ttlamt = round(pgq_ttlamt, 2)
        End If



        Dim pgq_genflag As String

        If rdoUntPri.Checked = True Then
            pgq_genflag = "UP"
        ElseIf rdoTtlAmt.Checked = True Then
            pgq_genflag = "TA"
        End If

        Dim pgq_usrid As String = gsUsrID


        gspStr = "sp_insert_PKGENQP '" & pgq_cocde & "','" & pgq_pkordno & "'," & pgq_ordqty & "," & pgq_wasqty & "," & pgq_bonqty & "," & _
                                                pgq_stkqty & "," & pgq_ttlordqty & "," & pgq_unitprc & "," & pgq_ttlamt & ",'" & pgq_genflag & "','" & gsUsrID & "'"



        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading save_pkmtlshp sp_insert_PKGENQP :" & rtnStr)
            Return False
            Exit Function
        End If

        Return True

    End Function





    Private Function CountCharacter(ByVal value As String, ByVal ch As String) As Integer
        Dim counter As Integer
        Dim a As Array
        a = Split(value, " - ")
        counter = a.Length - 1
        Return counter
    End Function
    Private Sub comboBoxCell(ByVal dgv As DataGridView, ByVal typ As String)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = dgv.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgv.CurrentCell.RowIndex

        Dim row As DataGridViewRow = dgv.CurrentRow

        'dgv.Rows(iRow).Cells(iCol).ReadOnly = True

        Dim i As Integer

        Select Case typ
            Case "VN"
                cboCell.Items.Clear()
                cboCell.Items.Add("")
                Dim dr() As DataRow
                dr = rs_VNBASINF_MS.Tables("RESULT").Select("vbi_vensts = 'A'", "vbi_vensna")


                For i = 0 To dr.Length - 1
                    'If rs_VNBASINF_MS.Tables("RESULT").Rows(i).Item("vbi_vensts") = "A" Then
                    cboCell.Items.Add(dr(i).Item("vbi_vensna") & " - " & dr(i).Item("vbi_venno"))

                    'End If
                Next i

            Case "AD"
                cboCell.Items.Clear()
                cboCell.Items.Add("")

                Dim dr() As DataRow
                dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & Split(dgMltShp.Rows(dgMltShpEditCellRow).Cells(9).Value, " - ")(1) & "'")

                'For i = 0 To dr.Length - 1
                '    cboCell.Items.Add(dr(i).Item("vbi_vensna") & " - " & dr(i).Item("vbi_venno"))
                'Next i
                If dr.Length <> 0 Then
                    For j As Integer = 0 To dr.Length - 1
                        cboCell.Items.Add(dr(j)("vci_address").ToString)
                    Next
                    'For j As Integer = 0 To dr.Length - 1
                    '    cboHdrCtn_dtl.Items.Add(dr(j)("vci_cntctp").ToString)
                    'Next
                End If


            Case "CT"
                cboCell.Items.Clear()
                cboCell.Items.Add("")

                Dim dr() As DataRow
                dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & Split(dgMltShp.Rows(dgMltShpEditCellRow).Cells(9).Value, " - ")(1) & "'")

                'For i = 0 To dr.Length - 1
                '    cboCell.Items.Add(dr(i).Item("vbi_vensna") & " - " & dr(i).Item("vbi_venno"))
                'Next i
                If dr.Length <> 0 Then
                    'For j As Integer = 0 To dr.Length - 1
                    '    cboCell.Items.Add(dr(j)("vci_address").ToString)
                    'Next
                    For j As Integer = 0 To dr.Length - 1
                        cboCell.Items.Add(dr(j)("vci_cntctp").ToString)
                    Next
                End If


        End Select

        cboCell.DropDownWidth = 200
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub

    Private Sub txt_datagridDates_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbBack Or (dgMltShp.CurrentCell.ColumnIndex <> 5 And dgMltShp.CurrentCell.ColumnIndex <> 6) Then

            Exit Sub
        End If

        Dim curvalue As String = sender.Text.ToString

        If curvalue = "" Then
            Exit Sub
        ElseIf curvalue.Length = 10 Then
            e.KeyChar = ""
        ElseIf Split(sender.Text, "/").Length > 2 And e.KeyChar = "/" Then
            e.KeyChar = ""
        End If

        If Replace(curvalue, "/", "").Length = 2 Then
            If sender.Text.ToString.Substring(sender.Text.Length - 1, 1) <> "/" Then
                sender.Text = sender.Text + "/"
            End If
            sender.Select(sender.Text.Length, 0)
        ElseIf Replace(curvalue, "/", "").Length = 4 Then
            If sender.Text.ToString.Substring(sender.Text.Length - 1, 1) <> "/" Then
                sender.Text = sender.Text + "/"
            End If
            sender.Select(sender.Text.Length, 0)
        End If







    End Sub

    Private Sub grdDetail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdDetail.Validating
        '        Call cal_grip_qty()

    End Sub

    Private Sub cal_grip_qty()

        Dim ordqty As Integer



        'For i As Integer = 0 To grdDetail.Rows.Count - 1

        '    If grdDetail.Item(dgPKGITEM_GEN, i).Value = "Y" Then
        '        ordqty = ordqty + grdDetail.Item(dgPkgITem_ordqty, i).Value
        '    End If
        'Next
        Dim iRow As Integer = grdDetail.CurrentCell.RowIndex
        Dim iCol As Integer = grdDetail.CurrentCell.ColumnIndex

        Dim curvalue As String = grdDetail.CurrentCell.EditedFormattedValue
        If Not IsNumeric(curvalue) Then
            curvalue = 0
        End If


        If flag_grdDetail_keypress = True Then
            flag_grdDetail_keypress = False
            'rs_TOSCDETAIL.Tables("RESULT").Rows(iRow).Item("ordqty") = curvalue

            For i As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").Rows.Count - 1
                If rs_TOSCDETAIL.Tables("RESULT").Rows(i).Item("Gen") = "Y" Then
                    If i = iRow Then
                        ordqty = ordqty + curvalue
                    Else
                        ordqty = ordqty + rs_TOSCDETAIL.Tables("RESULT").Rows(i).Item("ordqty")

                    End If

                End If
            Next

            txtOrdQty.Text = ordqty

            Dim temp_flag_inout As Integer
            If rdoIn.Checked = True Then
                temp_flag_inout = 1
            Else
                temp_flag_inout = 1
            End If

            txtTtlOrdQty.Text = ordqty + temp_flag_inout * Val(txtStkQty.Text) + Val(txtWasQty.Text)


            If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
                txtTtlAmt.Text = round(Val(txtTtlOrdQty.Text) * round(Val(txtUnitPrc.Text), 5), 2)



            End If

            'txtTtlAmt.Text = Val(txtTtlOrdQty.Text) * Val(txtUnitPrc.Text)



        End If
    End Sub
    Private Sub cal_grip_qty2()

        Dim ttlordqty As Integer
        Dim ordqty As Integer


        ordqty = Val(txtOrdQty.Text)

        Dim temp_flag_inout As Integer
        If rdoIn.Checked = True Then
            temp_flag_inout = 1
        Else
            temp_flag_inout = 1
        End If


        '        txtWasQty.Text = round(Val((ordqty + temp_flag_inout * Val(txtStkQty.Text)) * Val(txtPkgWastPer.Text) / 100 + 0.4999999), 0)
        Dim stkqty As Integer = Val(txtStkQty.Text)
        Dim sumqty As Integer = ordqty
        Dim cate As String = Split(txtPkgItem.Text, "-")(0)

        Dim dr() As DataRow
        dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & sumqty & " and pwa_qtyto >= " & sumqty)

        If dr.Length <> 0 Then
            If dr(0)("pwa_um") = "%" Then

                txtPkgWastPer.Text = Fix(dr(0).Item("pwa_wasage"))
                ' txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                ' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
            Else
                txtPkgWastPer.Text = ""
                'txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
                txtStandWasage.Text = Fix(dr(0).Item("pwa_wasage"))
            End If

        End If



        txtTtlOrdQty.Text = ordqty + temp_flag_inout * Val(txtStkQty.Text) + Val(txtWasQty.Text)



        If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
            txtTtlAmt.Text = round(Val(txtTtlOrdQty.Text) * round(Val(txtUnitPrc.Text), 5), 2)
        End If

        ' txtTtlAmt.Text = Val(txtTtlOrdQty.Text) * Val(txtUnitPrc.Text)




    End Sub
    Private Sub cal_grip_qty3()

        Dim ttlordqty As Integer
        Dim ordqty As Integer


        ordqty = Val(txtOrdQty.Text)

        Dim temp_flag_inout As Integer
        If rdoIn.Checked = True Then
            temp_flag_inout = 1
        Else
            temp_flag_inout = 1
        End If

        'If rdoOut.Checked = True Then
        '    Dim wasqty As Integer = Val(txtWasQty.Text)
        '    Dim stkqty As Integer = Val(txtStkQty.Text) * -1

        '    If stkqty > wasqty + ordqty Then
        '        txtStkQty.Text = (wasqty + ordqty) * -1

        '    End If

        'End If



        '        txtWasQty.Text = round(Val((ordqty + temp_flag_inout * Val(txtStkQty.Text)) * Val(txtPkgWastPer.Text) / 100 + 0.4999999), 0)

        txtTtlOrdQty.Text = ordqty + temp_flag_inout * Val(txtStkQty.Text) + Val(txtWasQty.Text)

        'txtTtlAmt.Text = Val(txtTtlOrdQty.Text) * Val(txtUnitPrc.Text)

        If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
            txtTtlAmt.Text = round(Val(txtTtlOrdQty.Text) * round(Val(txtUnitPrc.Text), 5), 2)
        Else
            txtUnitPrc.Text = round(txtTtlAmt.Text / txtTtlOrdQty.Text, 5)
        End If


    End Sub

    Private Sub txtPkgUnitPriCur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgUnitPriCur.TextChanged
        txtTtlAmtCur.Text = txtPkgUnitPriCur.Text
    End Sub

    Private Sub txtTtlOrdQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTtlOrdQty.TextChanged

        If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
        Else
            Exit Sub
        End If

        txtTtlAmt.Text = round(round(Val(txtUnitPrc.Text), 5) * Val(txtTtlOrdQty.Text), 2)


    End Sub

    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

        If Value = 0 Then S = "0"
        If Value = 1 Then S = "0.0"
        If Value = 2 Then S = "0.00"
        If Value = 3 Then S = "0.000"
        If Value = 4 Then S = "0.0000"
        If Value = 5 Then S = "0.00000"
        If Value = 6 Then S = "0.000000"
        If Value = 7 Then S = "0.0000000"
        If Value = 8 Then S = "0.00000000"
        If Value = 9 Then S = "0.000000000"
        If Value = 10 Then S = "0.0000000000"

        round = CDbl(Format(a, S))
    End Function


    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        btcPGM00009.SelectTab(2)
        btcPGM00009.TabPages(0).Enabled = False
        btcPGM00009.TabPages(1).Enabled = False
        btcPGM00009.TabPages(2).Enabled = True


        dgInvDtl.Enabled = True
        PelInvDtl.Enabled = True

        txtReqNo.Text = ""
        Me.txtReqNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical

        Dim sFilter As String

        sFilter = "Gen= 'Y'"
        rs_TOSCDETAIL.Tables("RESULT").DefaultView.RowFilter = sFilter
        rs_TOSCDETAIL.Tables("RESULT").DefaultView.Sort = "ordno,seq"
        sFilter = ""



        txtUnitPrc.Text = 0
        txtTtlAmt.Text = 0

        Call SetdgPkgITem_summary()

        'grdDetail_summary.DataSource = rs_TOSCDETAIL.Tables("RESULT").DefaultView
        Call Display_Default_Summary()

        cmdBackToResultPage.Enabled = True

        txtWasFrm.Text = txtFromApply.Text
        txtWasTo.Text = txtToApply.Text
    End Sub


    Private Sub grdDetail_summary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail_summary.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.ColumnIndex = dgPKGITEM_GEN Then
            If grdDetail_summary.Item(dgPKGITEM_GEN, grdDetail_summary.CurrentCell.RowIndex).Value = "N" Then
                grdDetail_summary.Item(dgPKGITEM_GEN, grdDetail_summary.CurrentCell.RowIndex).Value = "Y"
            ElseIf grdDetail_summary.Item(dgPKGITEM_GEN, grdDetail_summary.CurrentCell.RowIndex).Value = "Y" Then
                grdDetail_summary.Item(dgPKGITEM_GEN, grdDetail_summary.CurrentCell.RowIndex).Value = "N"
            Else
                grdDetail_summary.Item(dgPKGITEM_GEN, grdDetail_summary.CurrentCell.RowIndex).Value = "N"
            End If

            Call cal_grip_qty_summary()

        End If

    End Sub

    Private Sub grdDetail_summary_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDetail_summary.EditingControlShowing

        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            If grdDetail_summary.CurrentCell.ColumnIndex = 9 Or grdDetail_summary.CurrentCell.ColumnIndex = 14 Or grdDetail_summary.CurrentCell.ColumnIndex = 15 Then
                txtbox.MaxLength = 9
                AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress_summary
            End If

            If grdDetail_summary.CurrentCell.ColumnIndex = 14 Then
                RemoveHandler txtbox.TextChanged, AddressOf txt_grdDetail_summary_TextChanged
                RemoveHandler txtbox.TextChanged, AddressOf txt_grdDetail_summary_Was_TextChanged
                AddHandler txtbox.TextChanged, AddressOf txt_grdDetail_summary_TextChanged
                e.CellStyle.BackColor = Color.White
            End If

            If grdDetail_summary.CurrentCell.ColumnIndex = 15 Then
                RemoveHandler txtbox.TextChanged, AddressOf txt_grdDetail_summary_TextChanged
                RemoveHandler txtbox.TextChanged, AddressOf txt_grdDetail_summary_Was_TextChanged
                AddHandler txtbox.TextChanged, AddressOf txt_grdDetail_summary_Was_TextChanged
                e.CellStyle.BackColor = Color.White
            End If

        End If
    End Sub
    Private Sub txt_grdDetail_summary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call cal_grip_qty_summary()
    End Sub

    Private Sub txt_grdDetail_summary_Was_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call cal_grip_qty_summary_Wasqty()
    End Sub


    Private Sub grdDetail_summary_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail_summary.CellLeave

        'if the editing control is not nothing, unsubscribe the KeyPressevent

        '        Call cal_grip_qty_summary()

        If Not (txtbox Is Nothing) Then
            RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress_summary
        End If

        'rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(8) = rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(6) + rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(7)


    End Sub
    '''

    Private Sub txtBox_KeyPress_summary(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If grdDetail_summary.col = 6 Or grdDetail_summary.col = 7 Then
        '    If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '        KeyAscii = 0
        '    End If
        If Not (e.KeyChar = vbBack Or e.KeyChar = ChrW(Keys.Delete) Or e.KeyChar = ChrW(Keys.Enter) Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If

        'If grdDetail_summary.col = 6 Then
        '    If (Len(grdDetail_summary.Columns(6).Text) + 1 > 4) And KeyAscii > 31 Then
        '        'Msg ("M00018")
        '        KeyAscii = 0
        '        grdDetail_summary.SetFocus()
        '    End If
        'ElseIf grdDetail_summary.col = 7 Then
        '    If (Len(grdDetail_summary.Columns(7).Text) + 1 > 4) And KeyAscii > 31 Then
        '        'Msg ("M00018")
        '        KeyAscii = 0
        '        grdDetail_summary.SetFocus()
        '    End If
        'End If
        Dim iRow As Integer = grdDetail_summary.CurrentCell.RowIndex
        Dim iCol As Integer = grdDetail_summary.CurrentCell.ColumnIndex

        If iCol = 14 Or iCol = 15 Then
            flag_grdDetail_summary_keypress = True
        End If


    End Sub


    Private Sub grdDetail_summary_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDetail_summary.CellValidating

        Dim row As DataGridViewRow = grdDetail_summary.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case dgPkgITem_ordqty
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal.ToString.Contains(".") = True Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal < 0 Then
                        MsgBox("Order qty Cannot be Negative number")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case 15
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal.ToString.Contains(".") = True Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal < 0 Then
                        MsgBox("Order qty Cannot be Negative number")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        End If
    End Sub

    Private Sub grdDetail_summary_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail_summary.CellEndEdit


        Select Case e.ColumnIndex

            Case dgPkgITem_ordqty



                Dim ttlordqty As Integer = Val(txtOrdQty.Text)
                Dim ordqty As Integer

                '20140404
                'call a fun

                'For i As Integer = 0 To grdDetail_summary.Rows.Count - 1

                '    If grdDetail_summary.Item(dgPKGITEM_GEN, i).Value = "Y" Then
                '        ordqty = ordqty + grdDetail_summary.Item(dgPkgITem_ordqty, i).Value
                '    End If
                'Next

                'txtRemain.Text = ttlordqty - ordqty

        End Select




    End Sub





    '''''


    Private Sub cal_grip_qty_summary_Wasqty()

        Dim ttlordqty As Integer
        Dim ordqty As Integer
        Dim wasqty As Integer
        Dim currentWasqtyt As Integer

        If IsNumeric(txtStandWasage.Text) = True Then
            currentWasqtyt = txtStandWasage.Text
        Else
            currentWasqtyt = 0
        End If

        If IsNumeric(txtOrdQty.Text) = True Then
            ordqty = txtOrdQty.Text
        Else
            ordqty = 0
        End If



        'For i As Integer = 0 To grdDetail_summary.Rows.Count - 1

        '    If grdDetail_summary.Item(dgPKGITEM_GEN, i).Value = "Y" Then
        '        ordqty = ordqty + grdDetail_summary.Item(dgPkgITem_ordqty, i).Value
        '    End If
        'Next
        Dim iRow As Integer = grdDetail_summary.CurrentCell.RowIndex
        Dim iCol As Integer = grdDetail_summary.CurrentCell.ColumnIndex

        Dim curvalue As String

        curvalue = grdDetail_summary.CurrentCell.Value
        curvalue = grdDetail_summary.CurrentCell.EditedFormattedValue




        If Not IsNumeric(curvalue) Then
            curvalue = 0
        End If


        If flag_grdDetail_summary_keypress = True Then
            flag_grdDetail_summary_keypress = False
            'rs_TOSCDETAIL.Tables("RESULT").Rows(iRow).Item("ordqty") = curvalue

            For i As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count - 1
                If rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("Gen") = "Y" Then
                    If i = iRow Then
                        wasqty = wasqty + curvalue
                    Else
                        wasqty = wasqty + Val(rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("wasqty"))

                    End If

                End If
            Next

            'For i As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").Rows.Count - 1
            '    If rs_TOSCDETAIL.Tables("RESULT").Rows(i).Item("Gen") = "Y" Then
            '        If i = iRow Then
            '            ordqty = ordqty + curvalue
            '        Else
            '            ordqty = ordqty + rs_TOSCDETAIL.Tables("RESULT").Rows(i).Item("ordqty")

            '        End If

            '    End If
            'Next
            txtWasQty.Text = wasqty



            If rdoOut.Checked = True Then


                Dim temp_sum As Integer

                Dim index1 As Integer

                Dim sumsumqty As Integer

                If txtOrdQty.Text = "" Then
                    sumsumqty = 0
                Else
                    sumsumqty = txtOrdQty.Text
                End If

                For index1 = 0 To rs_PKINVHDR2.Tables("RESULT").Rows.Count - 1
                    If UCase(rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_pkgitm")) = UCase(txtPkgItem.Text) Then
                        temp_sum = temp_sum + rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_avlqty")
                    End If
                Next

                Dim waswasqty As Integer

                If txtWasQty.Text = "" Then
                    waswasqty = 0
                Else
                    waswasqty = txtWasQty.Text
                End If


                Dim currentstkqty As Integer
                If txtStkQty.Text = "" Then
                    currentstkqty = 0
                Else
                    currentstkqty = txtStkQty.Text
                End If


                If currentstkqty < 0 Then
                    currentstkqty = currentstkqty * -1
                End If

                If sumsumqty + wasqty <= currentstkqty Then
                    txtStkQty.Text = (sumsumqty + waswasqty) * -1
                End If

                If temp_sum < currentstkqty Then
                    txtStkQty.Text = temp_sum * -1
                End If



            End If





            Dim temp_flag_inout As Integer
            If rdoIn.Checked = True Then
                temp_flag_inout = 1
            Else
                temp_flag_inout = 1
            End If

            txtTtlOrdQty.Text = ordqty + temp_flag_inout * Val(txtStkQty.Text) + Val(txtWasQty.Text)



            ' txtTtlAmt.Text = Val(txtTtlOrdQty.Text) * Val(txtUnitPrc.Text)
            If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
                txtTtlAmt.Text = round(Val(txtTtlOrdQty.Text) * round(Val(txtUnitPrc.Text), 5), 2)
            Else
                txtUnitPrc.Text = round(txtTtlAmt.Text / txtTtlOrdQty.Text, 5)
            End If







            If txtWasQty.Text <> txtStandWasage.Text Then
                txtWasQty.ForeColor = Color.Red
            Else
                txtWasQty.ForeColor = Color.Black
            End If


            '''20140411
            '            Call cal_stk_and_ttlordqty()


        End If
    End Sub


    Private Sub cal_grip_qty_summary()

        Dim ttlordqty As Integer
        Dim ordqty As Integer



        'For i As Integer = 0 To grdDetail_summary.Rows.Count - 1

        '    If grdDetail_summary.Item(dgPKGITEM_GEN, i).Value = "Y" Then
        '        ordqty = ordqty + grdDetail_summary.Item(dgPkgITem_ordqty, i).Value
        '    End If
        'Next
        Dim iRow As Integer = grdDetail_summary.CurrentCell.RowIndex
        Dim iCol As Integer = grdDetail_summary.CurrentCell.ColumnIndex

        Dim curvalue As String

        curvalue = grdDetail_summary.CurrentCell.Value
        curvalue = grdDetail_summary.CurrentCell.EditedFormattedValue




        If Not IsNumeric(curvalue) Then
            curvalue = 0
        End If


        If flag_grdDetail_summary_keypress = True Then
            flag_grdDetail_summary_keypress = False
            'rs_TOSCDETAIL.Tables("RESULT").Rows(iRow).Item("ordqty") = curvalue

            For i As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count - 1
                If rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("Gen") = "Y" Then
                    If i = iRow Then
                        ordqty = ordqty + curvalue
                    Else
                        ordqty = ordqty + Val(rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("ordqty"))

                    End If

                End If
            Next

            'For i As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").Rows.Count - 1
            '    If rs_TOSCDETAIL.Tables("RESULT").Rows(i).Item("Gen") = "Y" Then
            '        If i = iRow Then
            '            ordqty = ordqty + curvalue
            '        Else
            '            ordqty = ordqty + rs_TOSCDETAIL.Tables("RESULT").Rows(i).Item("ordqty")

            '        End If

            '    End If
            'Next

            txtOrdQty.Text = ordqty


            Dim stkqty As Integer = Val(txtStkQty.Text)
            Dim sumqty As Integer = ordqty
            Dim cate As String = Split(txtPkgItem.Text, "-")(0)

            Dim dr() As DataRow
            dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & sumqty & " and pwa_qtyto >= " & sumqty)

            If dr.Length <> 0 Then
                If dr(0)("pwa_um") = "%" Then

                    txtPkgWastPer.Text = Fix(dr(0).Item("pwa_wasage"))
                    'txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    ' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                Else
                    txtPkgWastPer.Text = ""
                    'txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
                    txtStandWasage.Text = Fix(dr(0).Item("pwa_wasage"))
                End If

            End If


            If rdoOut.Checked = True Then


                Dim temp_sum As Integer

                Dim index1 As Integer


                For index1 = 0 To rs_PKINVHDR2.Tables("RESULT").Rows.Count - 1
                    If UCase(rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_pkgitm")) = UCase(txtPkgItem.Text) Then
                        temp_sum = temp_sum + rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_avlqty")
                    End If
                Next

                Dim wasqty As Integer

                If txtWasQty.Text = "" Then
                    wasqty = 0
                Else
                    wasqty = txtWasQty.Text
                End If


                Dim currentstkqty As Integer
                If txtStkQty.Text = "" Then
                    currentstkqty = 0
                Else
                    currentstkqty = txtStkQty.Text
                End If


                If currentstkqty < 0 Then
                    currentstkqty = currentstkqty * -1
                End If

                If sumqty + wasqty <= currentstkqty Then
                    txtStkQty.Text = (sumqty + wasqty) * -1
                End If

                If temp_sum < currentstkqty Then
                    txtStkQty.Text = temp_sum * -1
                End If



            End If





            Dim temp_flag_inout As Integer
            If rdoIn.Checked = True Then
                temp_flag_inout = 1
            Else
                temp_flag_inout = 1
            End If


            txtTtlOrdQty.Text = ordqty + temp_flag_inout * Val(txtStkQty.Text) + Val(txtWasQty.Text)

            If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
                txtTtlAmt.Text = round(Val(txtTtlOrdQty.Text) * round(Val(txtUnitPrc.Text), 5), 2)
            Else
                txtUnitPrc.Text = round(txtTtlAmt.Text / txtTtlOrdQty.Text, 5)
            End If

            'txtWasQty.ForeColor = Color.Black

            '''20140411
            '            Call cal_stk_and_ttlordqty()


        End If
    End Sub
    Private Sub cal_grip_qty_summary2()

        Dim ttlordqty As Integer
        Dim ordqty As Integer


        ordqty = Val(txtOrdQty.Text)

        Dim temp_flag_inout As Integer
        If rdoIn.Checked = True Then
            temp_flag_inout = 1
        Else
            temp_flag_inout = 1
        End If

        txtWasQty.Text = round(Val((ordqty + temp_flag_inout * Val(txtStkQty.Text)) * Val(txtPkgWastPer.Text) / 100 + 0.4999999), 0)

        txtTtlOrdQty.Text = ordqty + temp_flag_inout * Val(txtStkQty.Text) + Val(txtWasQty.Text)

        'txtTtlAmt.Text = Val(txtTtlOrdQty.Text) * Val(txtUnitPrc.Text)

        If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
            txtTtlAmt.Text = round(Val(txtTtlOrdQty.Text) * round(Val(txtUnitPrc.Text), 5), 2)
        End If


    End Sub




    Private Sub cmdFind_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

    End Sub

    Private Sub cboVendor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVendor.Validating
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboVendor.Items.Count
        If cboVendor.Text <> "" And cboVendor.Enabled = True And cboVendor.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboVendor.Text = cboVendor.Items(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Vendor - Data is Invalid, please select in Drop Down List.")
                e.Cancel = True

                cboVendor.Text = ""
                cboVendor.Focus()

            Else
            End If
        End If

    End Sub

    Private Sub cboCoCde_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged

    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click

    End Sub

    Private Sub cmdApply_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply_ok.Click
        Dim opt As String
        Dim intFm As Long
        Dim intTo As Long

        If rs_TOSCDETAIL.Tables.Count = 0 Then Exit Sub
        If rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        If Val(txtFromApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            Cursor = Cursors.Default

            txtFromApply.SelectAll()
            Exit Sub
        End If

        If Not IsNumeric(txtFromApply.Text) Then
            MsgBox("The apply range should be integers!")
            Cursor = Cursors.Default
            txtFromApply.SelectAll()
            Exit Sub
        End If

        If Val(txtToApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        If Not IsNumeric(txtToApply.Text) Then
            MsgBox("The apply range should be integers!")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        txtFromApply.Text = CInt(txtFromApply.Text)
        txtToApply.Text = CInt(txtToApply.Text)


        If Val(txtToApply.Text) > rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count Then
            MsgBox("The apply range cannot larger than the total number of records.")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        If Val(txtFromApply.Text) > Val(txtToApply.Text) Then
            MsgBox("The apply range is invalid.")
            txtFromApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        intFm = CLng(txtFromApply.Text)
        intTo = CLng(txtToApply.Text)

        If intTo > rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count Then
            intTo = rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count
        End If

        ''apply

        For index As Integer = intFm To intTo
            If optStatusG.Checked = True Then
                rs_TOSCDETAIL.Tables("RESULT").DefaultView(index - 1)("Gen") = "Y"
            Else
                rs_TOSCDETAIL.Tables("RESULT").DefaultView(index - 1)("Gen") = "N"
            End If

        Next

        rs_TOSCDETAIL.Tables("RESULT").AcceptChanges()

    End Sub

    Public Sub cal_stk_and_ttlordqty()
        Dim temp_sum As Integer

        Dim index1 As Integer
        'gspStr = "sp_select_PKINVDTL ''"
        'rtnLong = execute_SQLStatement(gspStr, rs_PKINVHDR2, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    Cursor = Cursors.Default
        '    MsgBox("Error on loading cmdFind_Click sp_list_PKINVHDR :" & rtnStr)
        '    Exit Sub
        'End If

        For index1 = 0 To rs_PKINVHDR2.Tables("RESULT").Rows.Count - 1
            If UCase(rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_pkgitm")) = UCase(txtPkgItem.Text) Then
                temp_sum = temp_sum + rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_avlqty")
            End If
        Next


        'If temp_sum < 0 Then
        '    temp_sum = 0
        'Else
        '    temp_sum = temp_sum * -1
        'End If



        'txtStkQty.Text = temp_sum

        txtStkQty.Text = temp_sum


        Dim current As Integer = Val(txtStkQty.Text)



        If rdoIn.Checked = True Then
            If current > 0 Then
                Exit Sub
            Else
                txtStkQty.Text = current * (-1)
            End If
        ElseIf rdoOut.Checked = True Then
            If current >= 0 Then

                Dim ordqty As Integer = Val(txtOrdQty.Text)
                Dim wasqty As Integer = Val(txtWasQty.Text)

                If ordqty + wasqty < current Then
                    txtStkQty.Text = (ordqty + wasqty) * -1

                Else
                    txtStkQty.Text = current * (-1)
                End If



            Else


                Exit Sub
            End If
        End If
        '20140411
        Call cal_grip_qty2()


    End Sub

    Private Function check_ttlgoods() As Boolean
        If rs_pkmltshp.Tables("RESULT").Rows.Count = 0 Then
            Return True
            Exit Function
        End If


        For index As Integer = 0 To rs_pkmltshp.Tables("RESULT").Rows.Count - 1

            If Not IsDate(rs_pkmltshp.Tables("RESULT").Rows(index).Item("pms_shpstrdat")) Then
                MsgBox("row " & index + 1 & ": Invalid Ship Start Date!")
                Return False
                Exit Function
            End If
            'If Not IsDate(rs_pkmltshp.Tables("RESULT").Rows(index).Item("pms_shpenddat")) Then
            '    MsgBox("row " & index + 1 & ": Invalid Ship End Date!")
            '    Return False
            '    Exit Function
            'End If

        Next



        Dim ttlordqty As Integer
        Dim ordqty As Integer = txtOrdQty.Text
        Dim wasqty As Integer
        Dim stkqty As Integer

        If txtWasQty.Text = "" Then
            wasqty = 0
        Else
            wasqty = txtWasQty.Text
        End If

        If txtStkQty.Text = "" Then
            stkqty = 0
        Else
            stkqty = txtStkQty.Text
        End If


        If rdoIn.Checked = True Then
            ttlordqty = ordqty + wasqty + stkqty
        ElseIf rdoOut.Checked = True Then
            ttlordqty = ordqty + wasqty
        End If


        Dim sum As Integer = 0
        For index As Integer = 0 To rs_pkmltshp.Tables("RESULT").Rows.Count - 1
            sum = sum + rs_pkmltshp.Tables("RESULT").Rows(index).Item("pms_shpqty")
        Next

        If sum <> ttlordqty Then
            MsgBox("Multiple Shipment Total Qty must equal to Order Qty Plus Wasage Qty.")
            Return False
        End If

        Return True

    End Function

    Private Sub grdDetail_summary_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail_summary.CellContentClick

    End Sub

    Private Sub cboAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAddress.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If Trim(cboVendor.Text) = "" Then
                MsgBox("Please select vendor.")
                Exit Sub
            End If

            If checkValidCombo(cboVendor, cboVendor.Text) = False Then
                MsgBox("Vendor Data Invalid")
                cboVendor.Text = ""
                Exit Sub
            End If


            cboVendor.Enabled = False
            cboAddress.Enabled = False
            cboCntPer.Enabled = False
            gp_search.Enabled = True
            cboCoCde.Focus()

        End If
    End Sub

    Private Sub cboAddress_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddress.SelectedIndexChanged

    End Sub

    Private Sub cboAddress_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAddress.Validated
        If Trim(cboAddress.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboAddress, cboAddress.Text) = False Then
            MsgBox("Data Invalid")
            cboAddress.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboCntPer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCntPer.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If Trim(cboVendor.Text) = "" Then
                MsgBox("Please select vendor.")
                Exit Sub
            End If

            If checkValidCombo(cboVendor, cboVendor.Text) = False Then
                MsgBox("Vendor Data Invalid")
                cboVendor.Text = ""
                Exit Sub
            End If


            cboVendor.Enabled = False
            cboAddress.Enabled = False
            cboCntPer.Enabled = False
            gp_search.Enabled = True
            cboCoCde.Focus()

        End If
    End Sub

    Private Sub cboCntPer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCntPer.SelectedIndexChanged

    End Sub

    Private Sub cboCntPer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCntPer.Validated
        If Trim(cboCntPer.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboCntPer, cboCntPer.Text) = False Then
            MsgBox("Data Invalid")
            cboCntPer.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub txtWasQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWasQty.Validated
        Dim temp_sum As Integer

        Dim index1 As Integer

        Dim sumqty As Integer

        Dim ordqty As Integer
        Dim wasqty As Integer

        If txtOrdQty.Text = "" Then
            ordqty = 0
        Else
            ordqty = txtOrdQty.Text
        End If

        If txtWasQty.Text = "" Then
            wasqty = 0
        Else
            wasqty = txtWasQty.Text
        End If



        sumqty = ordqty + wasqty






        Dim currentstkqty As Integer
        If txtStkQty.Text = "" Then
            currentstkqty = 0
        Else
            currentstkqty = txtStkQty.Text
        End If


        If currentstkqty < 0 Then
            currentstkqty = currentstkqty * -1
        End If

        If sumqty <= currentstkqty Then
            txtStkQty.Text = sumqty * -1
        End If






    End Sub


    Private Sub cmdInvStkqty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvStkqty.Click

        PelInvDtl.Visible = True
        PelInvDtl.BringToFront()
        PelInvDtl.Top = 4
        PelInvDtl.Left = 481
        PelInvDtl.Width = 434
        PelInvDtl.Height = 218
        dgInvDtl.Enabled = False
        dgInvDtl.Enabled = True
    End Sub

    Private Sub cmdCloseInvdtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseInvdtl.Click
        PelInvDtl.Visible = False
    End Sub

    Private Sub Display_Default_Summary()

        '' Gen Y TOTAL QTY




        Dim dr_GenY() As DataRow
        dr_GenY = rs_TOSCDETAIL.Tables("RESULT").Select("Gen = 'Y'")

        Dim ordqty As Integer
        Dim wasqty As Integer

        For i As Integer = 0 To dr_GenY.Length - 1
            ordqty = ordqty + dr_GenY(i)("ordqty")
            wasqty = wasqty + dr_GenY(i)("wasqty")
        Next



        txtOrdQty.Text = ordqty
        txtWasQty.Text = wasqty


        Dim stkqty As Integer = Val(txtStkQty.Text)
        Dim sumqty As Integer = ordqty
        Dim cate As String = Split(txtPkgItem.Text, "-")(0)

        Dim dr() As DataRow
        dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & sumqty & " and pwa_qtyto >= " & sumqty)

        If dr.Length <> 0 Then
            If dr(0)("pwa_um") = "%" Then

                txtPkgWastPer.Text = Fix(dr(0).Item("pwa_wasage"))
                'txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                ' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
            Else
                txtPkgWastPer.Text = ""
                'txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
                txtStandWasage.Text = Fix(dr(0).Item("pwa_wasage"))
            End If

        End If







    End Sub





    Private Sub rdoUntPri_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUntPri.CheckedChanged

    End Sub

    Private Sub rdoUntPri_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoUntPri.Click
        cal_grip_qty3()


        txtTtlAmt.Enabled = False
        txtUnitPrc.Enabled = True


        txtUnitPrc.Text = 0
        txtTtlAmt.Text = 0
    End Sub

    Private Sub rdoTtlAmt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTtlAmt.CheckedChanged

    End Sub

    Private Sub rdoTtlAmt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoTtlAmt.Click

        txtUnitPrc.Text = 0
        txtTtlAmt.Text = 0

        txtTtlAmt.Enabled = True
        txtUnitPrc.Enabled = False

        Dim unitprice As Decimal
        Dim Ttlamt As Decimal
        Dim Ttlqty As Integer

        If Trim(txtTtlOrdQty.Text) <> "" Then
            Ttlqty = txtTtlOrdQty.Text
        Else
            Ttlqty = 0
        End If

        If Trim(txtTtlAmt.Text) <> "" Then
            Ttlamt = txtTtlAmt.Text
        Else
            Ttlamt = 0
        End If

        unitprice = round(Ttlamt / Ttlqty, 5)

        txtUnitPrc.Text = unitprice




    End Sub

    Private Sub txtTtlAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTtlAmt.KeyPress

        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 13) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        If txtTtlAmt.Text.Contains(".") = True Then
            If Asc(e.KeyChar) = 46 Then
                e.KeyChar = Chr(0)
                MsgBox("Please input integer value.")
            End If
        End If
    End Sub



    Private Sub txtTtlAmt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTtlAmt.Validated
        Dim ttlamtA As Decimal
        If Trim(txtTtlAmt.Text) = "" Then
            ttlamtA = 0
        Else
            ttlamtA = txtTtlAmt.Text
        End If

        txtTtlAmt.Text = ttlamtA



        Dim unitprice As Decimal
        Dim Ttlamt As Decimal
        Dim Ttlqty As Integer

        If Trim(txtTtlOrdQty.Text) <> "" Then
            Ttlqty = txtTtlOrdQty.Text
        Else
            Ttlqty = 0
        End If

        If Trim(txtTtlAmt.Text) <> "" Then
            If Trim(txtTtlAmt.Text) = "." Then
                Ttlamt = 0
            Else
                Ttlamt = txtTtlAmt.Text
            End If

        Else
            Ttlamt = 0
        End If



        If Ttlamt = 0 Or Ttlqty = 0 Then
            unitprice = 0
        Else
            unitprice = round(Ttlamt / Ttlqty, 5)

            txtUnitPrc.Text = unitprice
        End If

    End Sub



    Private Sub cmdWasApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWasApp.Click
        Dim opt As String
        Dim intFm As Long
        Dim intTo As Long


        If rs_TOSCDETAIL.Tables.Count = 0 Then Exit Sub
        If rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        If Val(txtWasFrm.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            Cursor = Cursors.Default

            txtWasFrm.SelectAll()
            Exit Sub
        End If

        If Not IsNumeric(txtWasFrm.Text) Then
            MsgBox("The apply range should be integers!")
            Cursor = Cursors.Default
            txtWasFrm.SelectAll()
            Exit Sub
        End If

        If Val(txtWasTo.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            txtWasTo.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        If Not IsNumeric(txtWasTo.Text) Then
            MsgBox("The apply range should be integers!")
            txtWasTo.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        txtWasFrm.Text = CInt(txtWasFrm.Text)
        txtWasTo.Text = CInt(txtWasTo.Text)


        'If Val(txtWasTo.Text) - 1 > rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count Then
        '    MsgBox("The apply range cannot larger than the total number of records.")
        '    txtWasTo.SelectAll()
        '    Cursor = Cursors.Default

        '    Exit Sub
        'End If

        If Val(txtWasFrm.Text) > Val(txtWasTo.Text) Then
            MsgBox("The apply range is invalid.")
            txtWasFrm.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        intFm = CLng(txtWasFrm.Text)
        intTo = CLng(txtWasTo.Text)

        'If intTo > rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count Then
        '    intTo = rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count
        'End If

        ''apply

        For index As Integer = intFm To intTo
            'rs_TOSCDETAIL .Tables ("RESULT").DefaultView .Find (

            For i As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count - 1
                If rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("Counter") = index Then
                    rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("wasqty") = 0
                End If
            Next
        Next

        rs_TOSCDETAIL.Tables("RESULT").AcceptChanges()


        '-----------------------------------------------------------------------------------------------------'

        Dim ttlordqty As Integer
        Dim ordqty As Integer
        Dim wasqty As Integer
        Dim currentWasqtyt As Integer

        If IsNumeric(txtStandWasage.Text) = True Then
            currentWasqtyt = txtStandWasage.Text
        Else
            currentWasqtyt = 0
        End If

        If IsNumeric(txtOrdQty.Text) = True Then
            ordqty = txtOrdQty.Text
        Else
            ordqty = 0
        End If




        For i As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").DefaultView.Count - 1
            If rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("Gen") = "Y" Then

                wasqty = wasqty + Val(rs_TOSCDETAIL.Tables("RESULT").DefaultView(i)("wasqty"))

            End If
        Next



        txtWasQty.Text = wasqty



        If rdoOut.Checked = True Then


            Dim temp_sum As Integer

            Dim index1 As Integer

            Dim sumsumqty As Integer

            If txtOrdQty.Text = "" Then
                sumsumqty = 0
            Else
                sumsumqty = txtOrdQty.Text
            End If

            For index1 = 0 To rs_PKINVHDR2.Tables("RESULT").Rows.Count - 1
                If UCase(rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_pkgitm")) = UCase(txtPkgItem.Text) Then
                    temp_sum = temp_sum + rs_PKINVHDR2.Tables("RESULT").Rows(index1)("pih_avlqty")
                End If
            Next

            Dim waswasqty As Integer

            If txtWasQty.Text = "" Then
                waswasqty = 0
            Else
                waswasqty = txtWasQty.Text
            End If


            Dim currentstkqty As Integer
            If txtStkQty.Text = "" Then
                currentstkqty = 0
            Else
                currentstkqty = txtStkQty.Text
            End If


            If currentstkqty < 0 Then
                currentstkqty = currentstkqty * -1
            End If

            If sumsumqty + wasqty <= currentstkqty Then
                txtStkQty.Text = (sumsumqty + waswasqty) * -1
            End If

            If temp_sum < currentstkqty Then
                txtStkQty.Text = temp_sum * -1
            End If



        End If


        Dim temp_flag_inout As Integer
        If rdoIn.Checked = True Then
            temp_flag_inout = 1
        Else
            temp_flag_inout = 1
        End If

        txtTtlOrdQty.Text = ordqty + temp_flag_inout * Val(txtStkQty.Text) + Val(txtWasQty.Text)

        ' txtTtlAmt.Text = Val(txtTtlOrdQty.Text) * Val(txtUnitPrc.Text)
        If rdoTtlAmt.Checked = False And rdoUntPri.Checked = True Then
            txtTtlAmt.Text = round(Val(txtTtlOrdQty.Text) * round(Val(txtUnitPrc.Text), 5), 2)
        Else
            txtUnitPrc.Text = round(txtTtlAmt.Text / txtTtlOrdQty.Text, 5)
        End If


        If txtWasQty.Text <> txtStandWasage.Text Then
            txtWasQty.ForeColor = Color.Red
        Else
            txtWasQty.ForeColor = Color.Black
        End If






    End Sub

   

    Private Sub chkByWas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkByWas.Click

        If chkByWas.Checked = True Then
            Dim dr_GenY() As DataRow
            dr_GenY = rs_TOSCDETAIL.Tables("RESULT").Select("Gen = 'Y'")


            Dim wasqty As Integer

            For i As Integer = 0 To dr_GenY.Length - 1

                wasqty = wasqty + dr_GenY(i)("wasqty")
            Next


            txtWasQty.Text = wasqty
            txtWasQty.Enabled = False
        Else
            txtWasQty.Enabled = True
        End If


    End Sub
 
    Private Sub cmdBackToResultPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackToResultPage.Click
        btcPGM00009.SelectTab(1)
        btcPGM00009.TabPages(0).Enabled = True
        btcPGM00009.TabPages(1).Enabled = True
        btcPGM00009.TabPages(2).Enabled = false

        Dim sFilter As String

        sFilter = ""
        rs_TOSCDETAIL.Tables("RESULT").DefaultView.RowFilter = sFilter
        rs_TOSCDETAIL.Tables("RESULT").DefaultView.Sort = "ordno,seq"
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdApply_ok_selected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply_ok_selected.Click
        Dim i As Integer
        Dim counter As Integer

        For i = 0 To grdDetail.RowCount - 1
            If grdDetail.Rows(i).Selected = True Then
                'counter = grdDetail.Item(0, i).Value - 1
                counter = getcounter(grdDetail.Item(0, i).Value)
                If counter <> -1 Then

                    If optStatusG.Checked = True Then
                        '                    grdDetail.Item(dgPKGITEM_GEN, i).Value = "Y"
                        rs_TOSCDETAIL.Tables("RESULT").Rows(counter).Item("Gen") = "Y"
                    Else
                        '                    grdDetail.Item(dgPKGITEM_GEN, i).Value = "N"
                        rs_TOSCDETAIL.Tables("RESULT").Rows(counter).Item("Gen") = "N"
                    End If
                End If
            End If
        Next i
    End Sub

    Private Function getcounter(ByVal index As Integer) As Integer
        Dim i As Integer
        For i = 0 To rs_TOSCDETAIL.Tables("RESULT").Rows.Count - 1
            If index = rs_TOSCDETAIL.Tables("RESULT").Rows(i).Item(0) Then
                Return i
            End If
        Next i
        Return -1
    End Function

#Region "Movable Panel"

    Dim ProgramPosition, CursorPoint As Point
    Dim movePanel As String
    Dim panelMoveTimer As Timer
    Private Sub RenewPanel(ByVal panel As Panel)
        ProgramPosition = panel.Location
        CursorPoint = Cursor.Position
    End Sub

    Private Sub SetPanelPosition(ByVal panel As Panel)
        Dim X As Integer = 0
        Dim Y As Integer = 0


        Dim Xlimit As Integer
        Dim Ylimit As Integer
        If Me.FormBorderStyle = FormBorderStyle.FixedDialog Then

            Xlimit = Me.Width - panel.Width - SystemInformation.HorizontalResizeBorderThickness
            Ylimit = Me.Height - panel.Height - SystemInformation.VerticalResizeBorderThickness - SystemInformation.MenuHeight - SystemInformation.VerticalFocusThickness * 3
        Else
            Xlimit = Me.Width - panel.Width - SystemInformation.HorizontalResizeBorderThickness * 2
            Ylimit = Me.Height - panel.Height - SystemInformation.VerticalResizeBorderThickness * 2 - SystemInformation.MenuHeight - SystemInformation.VerticalFocusThickness * 3

        End If

        If (ProgramPosition - CursorPoint + Cursor.Position).X > 0 And (ProgramPosition - CursorPoint + Cursor.Position).X < Xlimit Then
            X = (ProgramPosition - CursorPoint + Cursor.Position).X
        ElseIf (ProgramPosition - CursorPoint + Cursor.Position).X <= 0 Then
            X = 0
        Else
            X = Xlimit
        End If

        If (ProgramPosition - CursorPoint + Cursor.Position).Y > 0 And (ProgramPosition - CursorPoint + Cursor.Position).Y < Ylimit Then
            Y = (ProgramPosition - CursorPoint + Cursor.Position).Y
        ElseIf (ProgramPosition - CursorPoint + Cursor.Position).Y <= 0 Then
            Y = 0
        Else
            Y = Ylimit
        End If

        panel.Location = New Point(X, Y)
    End Sub

    Private Sub panelMoveTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Select Case movePanel
            Case PelInvDtl.Name
                SetPanelPosition(PelInvDtl)
        End Select


    End Sub

    Private Sub PelInvDtl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PelInvDtl.MouseDown, dgInvDtl.MouseDown
        movePanel = PelInvDtl.Name
        panelMoveTimer.Enabled = True
        panelMoveTimer.Start()
        RenewPanel(PelInvDtl)
    End Sub

    Private Sub PelInvDtl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PelInvDtl.MouseUp, dgInvDtl.MouseUp
        panelMoveTimer.Stop()
        RenewPanel(PelInvDtl)
        movePanel = ""
    End Sub
#End Region

End Class

