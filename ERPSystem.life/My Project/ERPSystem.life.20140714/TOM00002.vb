Public Class TOM00002
    Dim min_seq As Integer
    Dim max_seq As Integer

    Dim sort_seq As Boolean
    Dim sort_itm As Boolean
    Dim sort_stkqty As Boolean
    Dim sort_custqty As Boolean
    Dim sort_smpqty As Boolean
    Dim sort_qutno As Boolean

    Dim sort_set_seq As Boolean
    Dim sort_set_itm As Boolean
    Dim sort_set_stkqty As Boolean
    Dim sort_set_custqty As Boolean
    Dim sort_set_smpqty As Boolean
    Dim sort_set_qutno As Boolean

    Dim current_row As Integer
    Dim txtbox As TextBox = Nothing

    Dim currentDtlVerno As Integer

    Dim rs_TOORDHDR As DataSet
    Dim rs_TOORDDTL As DataSet

    Public rs_QUOTNDTL As DataSet    ' for retrieve Quotation Details information
    Public rs_QUOTNDTL_tmp As DataSet    ' tempory RS for keep the gen (Y) and sort by Vendor
    Public rs_QUASSINF As DataSet    ' for retrieve Quotation Details (Assorted Item) information
    Public rs_SAREQDTL As DataSet    ' for list the Sample Request created from Quotation

    Public rs_QUOTNDTL_SET As DataSet
    Public rs_QUOTNDTL_SET_tmp As DataSet
    Public rs_QUASSINF_SET As DataSet
    Public rs_QUASSINF_tmp As DataSet
    Public merge_rs_QUOTNDTL_SET As DataSet
    Public rs_DOC_GEN As DataSet
    Public rs_insert_SAREQHDR As DataSet
    Public rs_ABUASST As DataSet
    Public rs_insert_SAREQDTL2 As DataSet
    Public rs_insert_SAREQASS As DataSet

    Public Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------
        current_row = 0



        If (Trim(txtQutNo.Text) = "") Then
            txtQutNo.Focus()
            MsgBox("Pls input Quotation No.")
            Exit Sub
        End If

        txtQutNo.Text = UCase(txtQutNo.Text)

        Dim rs() As ADOR.Recordset
        Dim S As String

        '*** Detail
        Dim optZeroQty As String
        optZeroQty = "N"

        If Me.chkZeroQty.Checked = True Then
            optZeroQty = "Y"
        End If

        gspStr = "sp_select_TOM00002 '" & gsCompany & "','" & txtQutNo.Text & "','" & optZeroQty & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_QUOTNDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00002 cmdFind_Click rs_QUOTNDTL : " & rtnStr)
        End If

        gspStr = "sp_select_TOORDHDR '" & gsCompany & "','" & "T" & txtQutNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_TOORDHDR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00002 cmdFind_Click sp_select_TOORDHDR : " & rtnStr)
        End If

        If rs_TOORDHDR.Tables("RESULT").Rows.Count > 0 Then
            If rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_ordsts") <> "OPE" Then
                MsgBox("Tentative order status is Release.")
                Exit Sub
            End If
        End If

        gspStr = "sp_select_TOORDDTL '" & gsCompany & "','" & "T" & txtQutNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_TOORDDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00002 cmdFind_Click sp_select_TOORDDTL : " & rtnStr)
        End If

        


        gspStr = "sp_select_SAREQDTL_created '" & gsCompany & "','" & txtQutNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAREQDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If 1 <> 1 Then
            MsgBox("Error on loading TOM00002 cmdFind_Click rs_SAREQDTL : " & rtnStr)
        Else
            Me.cmdSearch.Enabled = False
            Me.chkZeroQty.Enabled = False
            txtReqNo.Text = ""
            txtReqNoSet.Text = ""
            'If rs_SAREQDTL.Tables("RESULT").Rows.Count > 0 Then
            '    For i As Integer = 0 To rs_SAREQDTL.Tables("RESULT").Rows.Count - 1
            '        txtReqNo.Text = txtReqNo.Text + IIf(txtReqNo.Text = "", "", " ;" + Chr(13) + Chr(10)) + "Sample Request No. " + rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqno") + " created on " + Format(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srh_credat"), "MM/dd/yyyy")
            '    Next
            'End If
            If rs_QUOTNDTL.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Tentative Order Qty in the Quotation or Items is Discontinued or Inactive or Item is Old Item or To be confirmed.", vbInformation, "Information")
                cmdApply.Enabled = False
                Me.chkZeroQty.Enabled = True
                Me.cmdSearch.Enabled = True
                txtQutNo.Focus()
                Exit Sub
                'ElseIf gsSalTem <> rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then
                '    MsgBox("You have no right to Generate this document.")
                '    cmdApply.Enabled = False
                '    Me.chkZeroQty.Enabled = True
                '    Me.cmdSearch.Enabled = True
                '    txtQutNo.Focus()
                '    Exit Sub
            Else
                rs_QUOTNDTL.Tables("RESULT").Columns("cbi_cus2na").ReadOnly = False
                If IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na") = ""
                End If
                'If rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na") <> "" Then
                '    If Strings.Right(Trim(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus1na")), 8) <> "(Active)" Or Strings.Right(Trim(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na")), 8) <> "(Active)" Then
                '        MsgBox("Customer is not Active, cannot generate Sample Request.", vbCritical, "Warning")
                '        cmdApply.Enabled = False
                '        Me.chkZeroQty.Enabled = True
                '        Me.cmdSearch.Enabled = True
                '        txtQutNo.Focus()
                '        Exit Sub
                '    End If
                'Else
                '    If Strings.Right(Trim(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus1na")), 8) <> "(Active)" Then
                '        MsgBox("Customer is not Active, cannot generate Sample Request.", vbCritical, "Warning")
                '        cmdApply.Enabled = False
                '        Me.chkZeroQty.Enabled = True
                '        Me.cmdSearch.Enabled = True
                '        txtQutNo.Focus()
                '        Exit Sub
                '    End If
                'End If

                cmdApply.Enabled = True
                txtCus1Na.Text = rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus1na")
                txtCus2Na.Text = IIf((rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na")) Is Nothing, "", rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na"))
                current_row = 0 'rs_QUOTNDTL.MoveFirst()
                min_seq = rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("qud_qutseq")
                txtFrom.Text = min_seq
                current_row = rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1 'rs_QUOTNDTL.MoveLast()
                max_seq = rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("qud_qutseq")
                txtTo.Text = max_seq
                current_row = 0 'rs_QUOTNDTL.MoveFirst()
                For i As Integer = 0 To rs_QUOTNDTL.Tables("RESULT").Columns.Count - 1
                    rs_QUOTNDTL.Tables("RESULT").Columns(i).ReadOnly = False
                Next
                grdDetail.DataSource = rs_QUOTNDTL.Tables("RESULT").DefaultView
                Call Display_Detail(grdDetail)

                grdDetail.Enabled = True
                txtQutNo.Enabled = False
                cmdFind.Enabled = False

            End If
        End If

        '*** Assortment Item

        'gspStr = "sp_select_QUASSINF '" & gsCompany & "','" & txtQutNo.Text & "'"
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'rtnLong = execute_SQLStatement(gspStr, rs_QUASSINF, rtnStr)
        'Me.Cursor = Windows.Forms.Cursors.Default
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading TOM00002 cmdFind_Click rs_QUASSINF : " & rtnStr)
        'End If


    End Sub

    Private Sub TOM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)        'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Starup position
        cmdApply.Enabled = False
        grdDetail.Enabled = False
        grdDetailSet.Enabled = False
        Me.Cursor = Windows.Forms.Cursors.Default


        AddHandler grdDetail.EditingControlShowing, AddressOf grdDetail_EditingControlShowing
        AddHandler grdDetail.CellLeave, AddressOf grdDetail_CellLeave

        AddHandler grdDetailSet.EditingControlShowing, AddressOf grdDetailSet_EditingControlShowing
        AddHandler grdDetailSet.CellLeave, AddressOf grdDetailSet_CellLeave



    End Sub



    Private Sub txtQutNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQutNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click(sender, e)
        End If

    End Sub

    Private Sub Display_Detail(ByVal grd As DataGridView)
        'With grdDetail
        grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grd.ColumnHeadersHeight = 18


        With grd

            .Columns(0).HeaderCell.Value = "Gen"
            '.Columns(0).Button = True
            .Columns(0).ReadOnly = True
            '.Columns(0).Width = 500
            .Columns(0).Width = 40

            .Columns(1).HeaderCell.Value = "Seq."
            .Columns(1).ReadOnly = True
            '.Columns(1).Width = 500
            .Columns(1).Width = 40

            .Columns(2).HeaderCell.Value = "Item No."
            .Columns(2).ReadOnly = True
            '.Columns(2).Width = 1500

            .Columns(3).HeaderCell.Value = "Temp Item No."
            .Columns(3).ReadOnly = True
            '.Columns(3).Width = 2500

            .Columns(4).HeaderCell.Value = "Ven Item No."
            .Columns(4).ReadOnly = True

            .Columns(5).HeaderCell.Value = "Ven No."
            .Columns(5).ReadOnly = True

            .Columns(6).HeaderCell.Value = "Item Desc"
            .Columns(6).ReadOnly = True

            '.Columns(4).Caption = "VD. Color Code"
            .Columns(7).HeaderCell.Value = "Color Code"
            .Columns(7).ReadOnly = True
            '.Columns(4).Width = 1500

            .Columns(8).HeaderCell.Value = "Projected Qty"
            .Columns(8).ReadOnly = False

            .Columns(9).HeaderCell.Value = "Packing"
            .Columns(9).ReadOnly = True
            '.Columns(5).Width = 1500

            .Columns(10).HeaderCell.Value = "Fty Shp Srt"
            .Columns(10).ReadOnly = True

            .Columns(11).HeaderCell.Value = "Fty Shp End"
            .Columns(11).ReadOnly = True


            .Columns(12).HeaderCell.Value = "Cus Shp Srt"
            .Columns(12).ReadOnly = True

            .Columns(13).HeaderCell.Value = "Cus Shp End"
            .Columns(13).ReadOnly = True


            
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False


            .Columns(19).Visible = False
            '.Columns(20).Width = 600


            .Columns(20).Visible = False
            .Columns(21).Visible = False
            .Columns(22).Visible = False
            .Columns(23).Visible = False
            .Columns(24).Visible = False
            .Columns(25).Visible = False
            .Columns(26).Visible = False
            .Columns(27).Visible = False
            .Columns(28).Visible = False
            .Columns(29).Visible = False
            .Columns(30).Visible = False
            .Columns(31).Visible = False
            .Columns(32).Visible = False
            .Columns(33).Visible = False
            .Columns(34).Visible = False
            .Columns(35).Visible = False
            .Columns(36).Visible = False
            .Columns(37).Visible = False
            .Columns(38).Visible = False
            .Columns(39).Visible = False
            .Columns(40).Visible = False
            .Columns(41).Visible = False
            .Columns(42).Visible = False
            .Columns(43).Visible = False
            .Columns(44).Visible = False

            .Columns(45).Visible = False
            .Columns(46).Visible = False
            .Columns(47).Visible = False
            .Columns(48).Visible = False
            .Columns(49).Visible = False
            .Columns(50).Visible = False
            .Columns(51).Visible = False
            .Columns(52).Visible = False
            .Columns(53).Visible = False
            .Columns(54).Visible = False
            .Columns(55).Visible = False
            .Columns(56).Visible = False
            .Columns(57).Visible = False
            .Columns(58).Visible = False
            .Columns(59).Visible = False
            .Columns(60).Visible = False
            .Columns(61).Visible = False
            .Columns(62).Visible = False
            .Columns(63).Visible = False
            .Columns(64).Visible = False
            .Columns(65).Visible = False
            .Columns(66).Visible = False
            .Columns(67).Visible = False
            .Columns(68).Visible = False
            .Columns(69).Visible = False

            .Columns(70).Visible = False
            .Columns(71).Visible = False
            .Columns(72).Visible = False
            .Columns(73).Visible = False
            .Columns(74).Visible = False
            .Columns(75).Visible = False
            .Columns(76).Visible = False
            .Columns(77).Visible = False
            .Columns(78).Visible = False
            .Columns(79).Visible = False
            .Columns(80).Visible = False

           

            '.Columns(47).HeaderCell.Value = "Sample Price"
            '.Columns(47).ReadOnly = True
            ''.Columns(47).Width = 1000

            '.Columns(46).Visible = False
            '.Columns(45).Visible = False
            '.Columns(48).Visible = False
            '.Columns(49).Visible = False
            '.Columns(50).Visible = False
            '.Columns(51).Visible = False
            '.Columns(52).Visible = False
            '.Columns(53).Visible = False
            '.Columns(54).Visible = False
            '.Columns(57).HeaderCell.Value = "Pri Customer"
            '.Columns(57).ReadOnly = True
            ''.Columns(57).Width = 1500
            '.Columns(58).HeaderCell.Value = "Sec Customer"
            '.Columns(58).ReadOnly = True
            ''.Columns(58).Width = 1500
            '.Columns(55).Visible = False
            '.Columns(56).Visible = False

            ''Added by Mark Lau 20070618
            '.Columns(59).Visible = False
            '.Columns(60).Visible = False
            '.Columns(61).Visible = False
            '.Columns(62).Visible = False
            '.Columns(63).Visible = False

            ''*********Carlos Lui added on 2012/08/29*********
            '.Columns(64).HeaderCell.Value = "Price Pri Customer"
            '.Columns(64).ReadOnly = True
            ''.Columns(64).Width = 1500
            '.Columns(65).HeaderCell.Value = "Price Sec Customer"
            '.Columns(65).ReadOnly = True
            ''.Columns(65).Width = 1500
            '.Columns(66).HeaderCell.Value = "Price HK Price Term"
            '.Columns(66).ReadOnly = True
            ''.Columns(66).Width = 1500
            '.Columns(67).HeaderCell.Value = "Price Fty Price Term"
            '.Columns(67).ReadOnly = True
            ''.Columns(67).Width = 1500
            '.Columns(68).HeaderCell.Value = "Price Transport Term"
            '.Columns(68).ReadOnly = True
            ''.Columns(68).Width = 1500
            '.Columns(69).HeaderCell.Value = "Price Effect Date"
            '.Columns(69).ReadOnly = True
            ''.Columns(69).Width = 1500
            '.Columns(70).HeaderCell.Value = "Price Expiry Date"
            '.Columns(70).ReadOnly = True
            ''.Columns(70).Width = 1500
            ''*********Carlos Lui added on 2012/08/29*********
        End With
    End Sub


    Private Sub grdDetail_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellClick
        'change gen from Y to N /from N to Y

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.ColumnIndex = 0 Then
            rs_QUOTNDTL.Tables("RESULT").Columns(0).ReadOnly = False 'column 0: gen
            If rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(0) = "Y" Then
                rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(0) = "N"
            ElseIf rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(0) = "N" Then
                rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(0) = "Y"
            End If
        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        Me.grdDetailSet.DataSource = Nothing
        Me.grdDetailSet.Enabled = False
        rs_TOORDHDR = Nothing
        rs_QUOTNDTL_SET = Nothing
        rs_QUOTNDTL_SET_tmp = Nothing
        rs_QUASSINF_SET = Nothing
        rs_QUASSINF_tmp = Nothing
        'txtReqNoSet.Text = ""
        Call cmdClear_Click(sender, e)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'txtQutNo.Text = ""
        Me.cmdSearch.Enabled = True
        Me.chkZeroQty.Enabled = True
        txtFrom.Text = ""
        txtTo.Text = ""
        txtStkQty.Text = ""
        txtCusQty.Text = ""
        txtCus1Na.Text = ""
        txtCus2Na.Text = ""
        'txtReqNo.Text = ""
        rs_TOORDHDR = Nothing
        grdDetail.DataSource = Nothing
        rs_QUOTNDTL_tmp = Nothing
        rs_QUOTNDTL = Nothing
        rs_SAREQDTL = Nothing
        rs_QUASSINF = Nothing
        grdDetail.Enabled = False
        txtQutNo.Enabled = True
        cmdFind.Enabled = True
        txtQutNo.Focus()
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Dim j As Integer
        Dim stkqty As Integer
        Dim cusqty As Integer

        If Val(txtFrom.Text) < min_seq Then
            MsgBox("The apply range cannot smaller than min of Seq. No.")
            txtFrom.Focus()
            Exit Sub
        End If

        If Val(txtTo.Text) > max_seq Then
            MsgBox("The apply range cannot larger than max of Seq. No.")
            txtTo.Focus()
            Exit Sub
        End If

        If Val(txtFrom.Text) > Val(txtTo.Text) Then
            MsgBox("The apply range is invalid.")
            txtTo.Focus()
            Exit Sub
        End If

        rs_QUOTNDTL.Tables("RESULT").Columns("gen").ReadOnly = False

        For i As Integer = 0 To grdDetail.RowCount - 1
            If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") >= Val(txtFrom.Text) And rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") <= Val(txtTo.Text) Then
                rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("gen") = "Y"
            End If
        Next
        grdDetail.DataSource = rs_QUOTNDTL.Tables("RESULT").DefaultView
        grdDetail.Refresh()


        'Dim j As Integer
        'Dim stkqty As Integer
        'Dim cusqty As Integer

        'If Val(txtFrom.Text) < min_seq Then
        '    MsgBox("The apply range cannot smaller than min of Seq. No.")
        '    txtFrom.Focus()
        '    Exit Sub
        'End If

        'If Val(txtTo.Text) > max_seq Then
        '    MsgBox("The apply range cannot larger than max of Seq. No.")
        '    txtTo.Focus()
        '    Exit Sub
        'End If

        'If Val(txtFrom.Text) > Val(txtTo.Text) Then
        '    MsgBox("The apply range is invalid.")
        '    txtTo.Focus()
        '    Exit Sub
        'End If

        'rs_QUOTNDTL.Tables("RESULT").Columns("gen").ReadOnly = False
        'If grdDetail.SelectedRows.Count <= 0 Then
        '    For i As Integer = 0 To grdDetail.RowCount - 1
        '        If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") >= Val(txtFrom.Text) And rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") <= Val(txtTo.Text) Then
        '            If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("gen") = "N" Then
        '                rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("gen") = "Y"
        '            Else
        '                rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("gen") = "N"
        '            End If

        '            If txtStkQty.Text <> "" Then
        '                rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_stkqty") = Val(txtStkQty.Text)
        '                rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_smpqty") = Val(txtStkQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_cusqty")
        '            End If

        '            If txtCusQty.Text <> "" Then
        '                rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_cusqty") = Val(txtCusQty.Text)
        '                rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_smpqty") = Val(txtCusQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_stkqty")
        '            End If
        '        End If
        '    Next
        'Else
        '    For i As Integer = 0 To grdDetail.SelectedRows.Count - 1

        '        If rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("gen") = "N" Then
        '            rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("gen") = "Y"
        '        Else
        '            rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("gen") = "N"
        '        End If

        '        If txtStkQty.Text <> "" Then
        '            rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_stkqty") = Val(txtStkQty.Text)
        '            rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_smpqty") = Val(txtStkQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_cusqty")
        '        End If

        '        If txtCusQty.Text <> "" Then
        '            rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_cusqty") = Val(txtCusQty.Text)
        '            rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_smpqty") = Val(txtCusQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_stkqty")
        '        End If

        '    Next
        'End If
    End Sub

    Private Sub cmdInsertItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertItem.Click

        If rs_QUOTNDTL Is Nothing Then
            Exit Sub
        End If

        If rs_QUOTNDTL_SET Is Nothing Then
            rs_QUOTNDTL_SET = rs_QUOTNDTL.Clone 'rs_QUOTNDTL_SET = CopyRS_Struct(rs_QUOTNDTL)
        End If
        If rs_QUASSINF_SET Is Nothing Then
            rs_QUASSINF_SET = rs_QUASSINF.Clone 'rs_QUASSINF_SET = CopyRS_Struct(rs_QUASSINF)
        End If


        rs_QUOTNDTL_tmp = rs_QUOTNDTL.Copy 'rs_QUOTNDTL_tmp = CopyRS(rs_QUOTNDTL)
        rs_QUOTNDTL_SET_tmp = rs_QUOTNDTL_SET.Copy 'rs_QUOTNDTL_SET_tmp = CopyRS(rs_QUOTNDTL_SET)

        Dim dr_QUOTNDTL() As DataRow = rs_QUOTNDTL_tmp.Tables("RESULT").Select("gen='Y'")
        If dr_QUOTNDTL.Length() = 0 Then
            MsgBox("No record selected for insert, please try again.", vbInformation + vbOKOnly + vbDefaultButton1)
            Exit Sub
        End If

        'Block Duplicate Records
        'Call ValidateQuotationSource(rs_QUOTNDTL_tmp / dr_QUOTNDTL, rs_QUOTNDTL_SET_tmp) ' 20121102 try not to use this function,  validate the dataset directly
        Dim strMsg As String
        Me.txtReqNoSet.Text = ""
        merge_rs_QUOTNDTL_SET = rs_QUOTNDTL.Clone
        'Dim row As DataRow

        If Not rs_QUOTNDTL_SET_tmp Is Nothing Then
            If dr_QUOTNDTL.Length() > 0 Then
                'rsSource.MoveFirst()
                strMsg = ""
                Me.txtReqNoSet.Text = ""
                For i As Integer = 0 To dr_QUOTNDTL.Length() - 1
                    Dim dr_QUOTNDTL_SET() As DataRow = rs_QUOTNDTL_SET_tmp.Tables("RESULT").Select("qud_qutno='" & dr_QUOTNDTL(i).Item("qud_qutno") & "' and qud_qutseq=" & dr_QUOTNDTL(i).Item("qud_qutseq"))

                    If dr_QUOTNDTL_SET.Length() > 0 Then
                        strMsg = strMsg & "Quotation #: " & dr_QUOTNDTL(i).Item("qud_qutno") & "       Seq #: " & dr_QUOTNDTL(i).Item("qud_qutseq") & vbCrLf
                        'dr_QUOTNDTL(i).Item("gen") = "N"
                    Else
                        'row = merge_rs_QUOTNDTL_SET.Tables("RESULT").NewRow()
                        'row = dr_QUOTNDTL(i)
                        merge_rs_QUOTNDTL_SET.Tables("RESULT").ImportRow(dr_QUOTNDTL(i))
                    End If
                    'rsDestination.Filter = ""
                    'rsSource.MoveNext()
                Next

                If strMsg <> "" Then
                    Me.txtReqNoSet.Text = "The following record(s) is/are already inserted :--" & vbCrLf & strMsg
                    Me.txtReqNoSet.ForeColor = System.Drawing.Color.Red 'Me.txtReqNoSet.ForeColor = &HFF&
                End If
                'rsSource.Filter = "gen='Y'"

            End If
        End If








        'If dr_QUOTNDTL.Length() = 0 Then
        'Exit Sub
        'End If
        rs_QUOTNDTL_SET.Merge(merge_rs_QUOTNDTL_SET) 'Call AppendRS(rs_QUOTNDTL_tmp, rs_QUOTNDTL_SET)

        rs_QUASSINF_tmp = rs_QUASSINF.Copy 'rs_QUASSINF_tmp = CopyRS(rs_QUASSINF)

        'Call ExtractAssortment(rs_QUASSINF_tmp, rs_QUOTNDTL_tmp) try not to use this function,  validate the dataset directly

        Dim strQutSeq As String
        If Not rs_QUOTNDTL_tmp Is Nothing Then
            strQutSeq = ""
            For i As Integer = 0 To rs_QUOTNDTL_tmp.Tables("RESULT").Rows.Count - 1
                strQutSeq = IIf(strQutSeq = "", strQutSeq & "qai_qutseq='" & rs_QUOTNDTL_tmp.Tables("RESULT").Rows(i).Item("qud_qutseq") & "'", strQutSeq & " or qai_qutseq='" & rs_QUOTNDTL_tmp.Tables("RESULT").Rows(i).Item("qud_qutseq") & "'")
            Next

            Dim dr_QUASSINF() As DataRow = rs_QUASSINF_tmp.Tables("RESULT").Select(strQutSeq)
            'rsAssortment.Filter = ""
            'rsAssortment.Filter = strQutSeq
            rs_QUASSINF_SET.Merge(dr_QUASSINF) 'Call AppendRS(rs_QUASSINF_tmp, rs_QUASSINF_SET)
        End If


        If Me.grdDetailSet.DataSource Is Nothing Then
            For i As Integer = 0 To rs_QUOTNDTL_SET.Tables("RESULT").Columns.Count - 1
                rs_QUOTNDTL_SET.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            rs_QUOTNDTL_SET.Tables("RESULT").DefaultView.AllowNew = False
            Me.grdDetailSet.DataSource = rs_QUOTNDTL_SET.Tables("RESULT").DefaultView
            Call Display_Detail(grdDetailSet)
        End If
        grdDetailSet.Enabled = True

    End Sub

    'Public Function ValidateQuotationSource(ByRef rsSource As DataSet, ByRef rsDestination As DataSet)
    '    Dim rowCount As Integer
    '    Dim i As Integer, j As Integer
    '    Dim current_pos As Integer
    '    Dim old_filter
    '    Dim strMsg As String
    '    rsSource.Filter = "gen='Y'"
    '    Me.txtReqNoSet.Text = ""
    '    If rsDestination Is Nothing Then
    '        Exit Function
    '    Else

    '        If rsSource.RecordCount > 0 Then
    '            rsSource.MoveFirst()
    '            strMsg = ""
    '            Me.txtReqNoSet.Text = ""
    '            For i = 0 To rsSource.RecordCount - 1
    '                rsDestination.Filter = "qud_qutno='" & rsSource.Fields("qud_qutno") & "' and qud_qutseq=" & rsSource.Fields("qud_qutseq")
    '                If rsDestination.RecordCount > 0 Then
    '                    strMsg = strMsg & "Quotation #: " & rsSource("qud_qutno") & "       Seq #: " & rsSource("qud_qutseq") & vbCrLf
    '                    rsSource.Fields("gen") = "N"
    '                End If
    '                rsDestination.Filter = ""
    '                rsSource.MoveNext()
    '            Next

    '            If strMsg <> "" Then
    '                Me.txtReqNoSet.Text = "The following record(s) is/are already inserted :--" & vbCrLf & strMsg
    '                Me.txtReqNoSet.ForeColor = System.Drawing.Color.Red 'Me.txtReqNoSet.ForeColor = &HFF&
    '            End If
    '            rsSource.Filter = "gen='Y'"

    '        End If

    '    End If
    'End Function

    Private Sub grdDetailSet_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellClick
        'change gen from Y to N /from N to Y
        If e.ColumnIndex = 0 Then
            rs_QUOTNDTL_SET.Tables("RESULT").Columns(0).ReadOnly = False 'column 0: gen
            If rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "Y" Then
                rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "N"
            ElseIf rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "N" Then
                rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "Y"
            End If
        End If
    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------


        Dim CoCde As String = ""
        Dim reqno As String = ""
        Dim cus1no As String = ""
        Dim cus2no As String = ""
        Dim venno As String = ""
        Dim subcde As String = ""
        Dim reqseq As Integer = 0
        Dim rs_tmp_quotation As DataSet

        txtReqNoSet.Text = ""
        'txtReqNoSet.ForeColor = &H80000008

        rs_QUASSINF_tmp = Nothing
        rs_QUOTNDTL_tmp = Nothing

        Dim Firsttime As Boolean = True

        If Not Me.grdDetailSet.DataSource Is Nothing Then
            rs_QUOTNDTL_tmp = rs_QUOTNDTL_SET.Copy 'rs_QUOTNDTL_tmp = CopyRS(rs_QUOTNDTL_SET)
            rs_QUASSINF_tmp = rs_QUASSINF_SET.Copy 'rs_QUASSINF_tmp = CopyRS(rs_QUASSINF_SET)
        ElseIf Not Me.grdDetail.DataSource Is Nothing Then
            rs_QUOTNDTL_tmp = rs_QUOTNDTL.Copy 'rs_QUOTNDTL_tmp = CopyRS(rs_QUOTNDTL)
            '      rs_QUASSINF_tmp = rs_QUASSINF.Copy 'rs_QUASSINF_tmp = CopyRS(rs_QUASSINF)
        Else
            Exit Sub
        End If


        If Not rs_QUOTNDTL_tmp Is Nothing Then
            Dim dr_QUOTNDTL() As DataRow = rs_QUOTNDTL_tmp.Tables("RESULT").Select("gen='Y'") 'rs_QUOTNDTL_tmp.Filter = "gen = 'Y'"


            If dr_QUOTNDTL.Length() = 0 Then
                MsgBox("No record selected for generate, please try again.")
                Exit Sub
            Else

                rs_tmp_quotation = rs_QUOTNDTL_tmp.Copy 'rs_tmp_quotation = CopyRS(rs_QUOTNDTL_tmp)

                If checkZeroqty(rs_tmp_quotation) Then
                    Exit Sub
                End If

                'rs_QUOTNDTL_tmp.Tables("RESULT").DefaultView.Sort = "quh_cocde,quh_cus1no,quh_cus2no,qud_cusven,qud_cussub"

                Dim rs_QUOTNDTL_tmp_sorttable As DataTable = rs_QUOTNDTL_tmp.Tables("RESULT").DefaultView.ToTable()
                For i As Integer = 0 To rs_QUOTNDTL_tmp_sorttable.Rows.Count - 1

                    Dim a As Integer = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_toqty").ToString
                    If rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_toqty") >= 0 And rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("gen") = "Y" Then

                        '--- Update Company Code before execute ---
                        gsCompany = Trim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cocde"))
                        Call Update_gs_Value(gsCompany)


                        'gspStr = "sp_select_DOC_GEN '" & gsCompany & "','" & "SR" & "','" & gsUsrID & "'"

                        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        'rtnLong = execute_SQLStatement(gspStr, rs_DOC_GEN, rtnStr)
                        'Me.Cursor = Windows.Forms.Cursors.Default
                        'If rtnLong <> RC_SUCCESS Then
                        '    MsgBox("Error on loading TOM00002 cmdGen_Click  sp_select_DOC_GEN : " & rtnStr)
                        'Else
                        '    reqno = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
                        'End If
                        If Firsttime = True Then

                            Firsttime = False

                            Dim toh_ordsts As String = "OPE"
                            Dim toh_issdat As DateTime = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_issdat")
                            Dim toh_rvsdat As DateTime = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_rvsdat")
                            Dim toh_verno As Integer = 1
                            Dim toh_saldiv As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_saldiv")
                            Dim toh_saltem As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_saldivtem")
                            Dim toh_salrep As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_srname")
                            Dim toh_custcde As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_custcde")
                            Dim toh_buyer As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_buyer")
                            Dim toh_year As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_year")
                            Dim toh_cus1no As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")
                            Dim toh_cus2no As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")
                            Dim toh_refqut As String = Trim(txtQutNo.Text)
                            Dim toh_to As String = ""
                            Dim toh_cc As String = ""
                            Dim toh_fm As String = ""
                            Dim toh_rmk As String = ""
                            Dim toh_season As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_season")


                            If rs_TOORDHDR.Tables("RESULT").Rows.Count > 0 Then
                                'update

                                gspStr = "sp_update_TOORDHDR '" & gsCompany & "','" & "T" + Trim(txtQutNo.Text) & "','" & gsUsrID & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQHDR, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading TOM00002 cmdGen_Click  sp_update_TOORDHDR : " & rtnStr)
                                Else
                                    'reqno = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
                                End If
                                txtReqNo.Text = "T" + Trim(txtQutNo.Text) + " Created"
                                'txtReqNo.Text = "T" + Trim(txtQutNo.Text) + " for Vendor - " + rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven") + IIf(Len(RTrim(LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub")))) = 0, "", " Sub Code - " + rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub"))
                            Else
                                gspStr = "sp_insert_TOORDHDR '" & gsCompany & "','" & "T" + Trim(txtQutNo.Text) & "','" & toh_ordsts & _
                                "','" & toh_issdat & "','" & toh_rvsdat & "'," & toh_verno & ",'" & toh_saldiv & "','" & toh_saltem & "','" & toh_salrep & _
                                "','" & toh_custcde & "','" & toh_buyer & "','" & toh_year & "','" & toh_cus1no & "','" & toh_cus2no & _
                                "','" & toh_refqut & "','" & toh_to & "','" & toh_cc & "','" & toh_fm & "','" & toh_rmk & "','" & toh_season & "','" & gsUsrID & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQHDR, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading TOM00002 cmdGen_Click  sp_insert_TOORDHDR : " & rtnStr)
                                Else
                                    'reqno = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
                                End If
                                txtReqNo.Text = "T" + Trim(txtQutNo.Text) + " Created"
                                'txtReqNo.Text = "T" + Trim(txtQutNo.Text) + " for Vendor - " + rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven") + IIf(Len(RTrim(LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub")))) = 0, "", " Sub Code - " + rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub"))
                            End If
                        End If



                        Dim tod_toordno As String = "T" + Trim(txtQutNo.Text)
                        Dim tod_toordseq As Integer  '3
                        Dim tod_verno As Integer = 1 '3 '4
                        Dim tod_latest As String = "Y" '3'5
                        Dim tod_refno As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_refno") '3 '6
                        Dim tod_sts As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmsts") '3'7
                        Dim tod_todat As DateTime = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_todat")  '3'8 
                        Dim tod_customer As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_customer") '3'9
                        Dim tod_cus1no As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus1no") '3 '10
                        Dim tod_cus2no As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")  '3'11
                        Dim tod_buyer As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_buyer") '3 '12 
                        Dim tod_category As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_category") '3 '13
                        Dim tod_jobno As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_jobno") '3'14
                        Dim tod_ftyitmno As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnoreal") '3 '15
                        Dim tod_itmsku As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmsku") '3'16
                        Dim tod_ftytmpitmno As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnotmp") '3'17
                        Dim tod_itmdsc As String = Replace(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmdsc").ToString, "'", "''") '3'18
                        Dim tod_venno As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnovenno")  '3'19  
                        Dim tod_venitm As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnoven") '3'20 
                        Dim tod_colcde As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_colcde")  '3'21
                        Dim tod_inrqty As Integer = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_inrqty")  '3'22
                        Dim tod_mtrqty As Integer = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_mtrqty") '3'23
                        Dim tod_pckunt As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_untcde") '324 
                        Dim tod_conftr As Integer = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_conftr") '3'25   
                        Dim tod_cft As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cft") '3'26
                        Dim tod_cbm As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cbm")  '3'27 
                        Dim tod_ftyprctrm As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftyprctrm") '3'28
                        Dim tod_hkprctrm As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_prctrm") '3'29
                        Dim tod_trantrm As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_trantrm") '3'30 
                        Dim tod_period As String = Format(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_period"), "MM/dd/yyyy") '3 '31
                        Dim tod_fobport As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_fobport") '3'32 
                        Dim tod_retail As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_retail")  '3'33  
                        Dim tod_projqty As Integer = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_toqty") '3 '34
                        Dim tod_ftyshpdatstr As DateTime = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftyshpstr") '3'35
                        Dim tod_ftyshpdatend As DateTime = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftyshpend")  '3'36
                        Dim tod_dsgven As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_dsgven").ToString   '3'37
                        Dim tod_prdven As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_prdven") '3'38
                        Dim tod_cusven As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven")  '3'39
                        Dim tod_imgpth As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_imgpth") '3'40 
                        Dim tod_s2apno As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_sapno") '3 '41 
                        Dim tod_cuspono As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cuspono") '3 '42
                        Dim tod_rmk As String = Replace(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_rmk").ToString, "'", "''") '3 '43 
                        Dim tod_upc As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_upc") '3 '44
                        Dim tod_ctnL As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ctnL") '3'45
                        Dim tod_ctnW As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ctnW")  '3'46
                        Dim tod_ctnH As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ctnH") '3 '47
                        Dim tod_ctnupc As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ctnupc") '3'48 
                        Dim tod_venstk As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_venstk") '3'49
                        Dim tod_cushpdatstr As DateTime = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cushpstr")  '3'50
                        Dim tod_cushpdatend As DateTime = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cushpend") '3'51
                        Dim tod_fcurcde As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_fcurcde") '3'52 
                        Dim tod_ftycst As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftycst")  '3'53 
                        Dim tod_curcde As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_curcde") '3'54 
                        Dim tod_selprc As Decimal = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_selprc") '3'55 
                        Dim tod_qtyb_cuspo As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qtyb_cuspo") '3'56
                        Dim tod_qtyb_ordqty As Integer = 0 '3'57
                        'Dim tod_podat As DateTime = "1900/01/01"  '3'58 
                        Dim tod_podat As DateTime = "1900/01/01"  '3'58 
                        Dim tod_pcktyp As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_pcktyp")  '3'59
                        Dim tod_basprc As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_basprc")  '3'59
                        Dim tod_qutitmsts As String = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutitmsts")  '3'59


                        Dim tod_qutno As String = txtQutNo.Text  '3'60
                        Dim tod_qutseq As Integer = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutseq") '3'61


                        '''20140116  tbc zero prc
                        ''' 
                        If rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutitmsts") = "TBC" Then
                            tod_ftycst = 0
                            tod_selprc = 0
                            tod_basprc = 0
                        End If


                        If checkToodrdtl(Trim(txtQutNo.Text), rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutseq")) = True Then
                            If rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_verno") > currentDtlVerno Then
                                'Insert seq <> 0
                                tod_toordseq = GetSeqno(Trim(txtQutNo.Text), rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutseq"))
                                tod_verno = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_verno")

                                gspStr = "sp_insert_TOORDDTL '" & gsCompany & "','" & tod_toordno & "'," & tod_toordseq & "," & tod_verno & ",'" & _
                                    tod_latest & "','" & tod_refno & "','" & _
                                    tod_sts & "','" & tod_todat & "','" & tod_customer & "','" & _
                                    tod_cus1no & "','" & tod_cus2no & "','" & tod_buyer & "','" & _
                                    tod_category & "','" & tod_jobno & "','" & tod_ftyitmno & "','" & _
                                    tod_itmsku & "','" & tod_ftytmpitmno & "','" & tod_itmdsc & "','" & _
                                    tod_venno & "','" & tod_venitm & "','" & tod_colcde & "'," & _
                                    tod_inrqty & "," & tod_mtrqty & ",'" & tod_pckunt & "'," & tod_conftr & "," & _
                                    tod_cft & "," & tod_cbm & ",'" & tod_ftyprctrm & "','" & _
                                    tod_hkprctrm & "','" & tod_trantrm & "','" & tod_period & "','" & _
                                    tod_fobport & "'," & _
                                    tod_retail & "," & _
                                    tod_projqty & ",'" & tod_ftyshpdatstr & "','" & _
                                    tod_ftyshpdatend & "','" & _
                                    tod_dsgven & "','" & tod_prdven & "','" & _
                                    tod_cusven & "','" & tod_imgpth & "','" & tod_s2apno & "','" & _
                                    tod_cuspono & "','" & _
                                    tod_rmk & "','" & tod_upc & "'," & _
                                    tod_ctnL & "," & tod_ctnW & "," & _
                                    tod_ctnH & ",'" & tod_ctnupc & "','" & _
                                    tod_venstk & "','" & tod_cushpdatstr & "','" & _
                                    tod_cushpdatend & "','" & tod_fcurcde & "'," & _
                                    tod_ftycst & ",'" & tod_curcde & "'," & tod_selprc & ",'" & _
                                    tod_qtyb_cuspo & "'," & tod_qtyb_ordqty & ",'" & tod_podat & "','" & _
                                    tod_pcktyp & "','" & tod_basprc & "','" & tod_qutitmsts & "','" & tod_qutno & "'," & tod_qutseq & ",'" & _
                                    gsUsrID & "'"

                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQDTL2, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading TOM00002 cmdGen_Click  sp_insert_TOORDDT : " & rtnStr)
                                Else
                                    'reqseq = rs_insert_SAREQDTL2.Tables("RESULT").Rows(0).Item(0)

                                End If


                            Else
                                'Update
                                tod_toordseq = GetSeqno(Trim(txtQutNo.Text), rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutseq"))

                                gspStr = "sp_update_TOORDDTL_2 '" & gsCompany & "','" & tod_toordno & "'," & tod_verno & "," & tod_toordseq & "," & tod_projqty & ",'" & tod_ftyshpdatstr & "','" & _
                                            tod_ftyshpdatend & "','" & tod_cushpdatstr & "','" & tod_cushpdatend & "','" & tod_rmk & "','" & _
                                            tod_dsgven & "','" & tod_prdven & "','" & tod_cusven & "'," & tod_ftycst & "," & tod_selprc & "," & tod_basprc & ",'" & tod_qutitmsts & "','" & tod_itmdsc & "','" & gsUsrID & "'"

                                'gspStr = "sp_update_TOORDDTL_2 '" & gsCompany & "','" & tod_toordno & "'," & tod_verno & "," & tod_toordseq & "," & tod_projqty & ",'" & tod_ftyshpdatstr & "','" & _
                                '            tod_ftyshpdatend & "','" & tod_cushpdatstr & "','" & tod_cushpdatend & "','" & tod_rmk & "','" & _
                                '            tod_dsgven & "','" & tod_prdven & "','" & tod_cusven & "','" & gsUsrID & "'"

                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQDTL2, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading TOM00002 cmdGen_Click  sp_insert_TOORDDT : " & rtnStr)
                                Else
                                    'reqseq = rs_insert_SAREQDTL2.Tables("RESULT").Rows(0).Item(0)

                                End If

                            End If
                        Else
                            'Insert seq =0
                            If rs_TOORDHDR.Tables("RESULT").Rows.Count <> 0 Then
                                tod_verno = rs_TOORDHDR.Tables("RESULT").Rows(0).Item("toh_verno")
                            Else
                                tod_verno = 1
                            End If
                            tod_toordseq = 0
                            gspStr = "sp_insert_TOORDDTL '" & gsCompany & "','" & tod_toordno & "'," & tod_toordseq & "," & tod_verno & ",'" & _
                                    tod_latest & "','" & tod_refno & "','" & _
                                    tod_sts & "','" & tod_todat & "','" & tod_customer & "','" & _
                                    tod_cus1no & "','" & tod_cus2no & "','" & tod_buyer & "','" & _
                                    tod_category & "','" & tod_jobno & "','" & tod_ftyitmno & "','" & _
                                    tod_itmsku & "','" & tod_ftytmpitmno & "','" & tod_itmdsc & "','" & _
                                    tod_venno & "','" & tod_venitm & "','" & tod_colcde & "'," & _
                                    tod_inrqty & "," & tod_mtrqty & ",'" & tod_pckunt & "'," & tod_conftr & "," & _
                                    tod_cft & "," & tod_cbm & ",'" & tod_ftyprctrm & "','" & _
                                    tod_hkprctrm & "','" & tod_trantrm & "','" & tod_period & "','" & _
                                    tod_fobport & "'," & _
                                    tod_retail & "," & _
                                    tod_projqty & ",'" & tod_ftyshpdatstr & "','" & _
                                    tod_ftyshpdatend & "','" & _
                                    tod_dsgven & "','" & tod_prdven & "','" & _
                                    tod_cusven & "','" & tod_imgpth & "','" & tod_s2apno & "','" & _
                                    tod_cuspono & "','" & _
                                    tod_rmk & "','" & tod_upc & "'," & _
                                    tod_ctnL & "," & tod_ctnW & "," & _
                                    tod_ctnH & ",'" & tod_ctnupc & "','" & _
                                    tod_venstk & "','" & tod_cushpdatstr & "','" & _
                                    tod_cushpdatend & "','" & tod_fcurcde & "'," & _
                                    tod_ftycst & ",'" & tod_curcde & "'," & tod_selprc & ",'" & _
                                    tod_qtyb_cuspo & "'," & tod_qtyb_ordqty & ",'" & tod_podat & "','" & _
                                    tod_pcktyp & "','" & tod_basprc & "','" & tod_qutitmsts & "','" & tod_qutno & "'," & tod_qutseq & ",'" & _
                                    gsUsrID & "'"

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQDTL2, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading TOM00002 cmdGen_Click  sp_insert_TOORDDT : " & rtnStr)
                            Else
                                'reqseq = rs_insert_SAREQDTL2.Tables("RESULT").Rows(0).Item(0)

                            End If

                        End If




                    End If
                Next
            End If


            '--- Reset Company Code after execute ---
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            '------------------------------------------
            If Me.txtReqNo.Text = "" Or Me.txtReqNo.Text = "No Tentative Order Generated" Then
                Me.txtReqNo.Text = "No Tentative Order Generated"
            Else
                Call cmdClearAll_Click(sender, e)
            End If
        Else
            MsgBox("No record selected for generate, please try again.")
            Exit Sub
        End If
    End Sub


    Private Function GetSeqno(ByVal qutno As String, ByVal seqno As Integer) As Integer

        

        Dim dr() As DataRow
        dr = rs_TOORDDTL.Tables("RESULT").Select("tod_qutno='" & qutno & "' and tod_qutseq=" & seqno)

        If dr.Length = 0 Then
            Return 1 'MAX
        Else
            Return dr(0)("tod_toordseq")
        End If


    End Function


    Private Function GetVerno(ByVal qutno As String, ByVal seqno As Integer) As Integer
        If rs_TOORDDTL.Tables("RESULT").Rows.Count = 0 Then
            Return 1
        End If




        Dim dr() As DataRow
        dr = rs_TOORDDTL.Tables("RESULT").Select("tod_qutno='" & qutno & "' and tod_qutseq=" & seqno)

        If dr.Length = 0 Then
            Return 1
        Else
            Return dr(0)("tod_verno") + 1
        End If
    End Function

    Private Function checkToodrdtl(ByVal qutno As String, ByVal seqno As Integer) As Boolean
        If rs_TOORDDTL.Tables("RESULT").Rows.Count = 0 Then
            Return False
        End If

        Dim dr() As DataRow
        dr = rs_TOORDDTL.Tables("RESULT").Select("tod_qutno ='" & qutno & "' and tod_qutseq=" & seqno & " and tod_latest = 'Y'")

        If dr.Length = 0 Then
            Return False
        ElseIf dr.Length <> 0 Then
            currentDtlVerno = dr(0)("tod_verno")
            Return True
        End If

    End Function

    Private Function checkZeroqty(ByVal rs_tmp_quotation As DataSet) As Boolean
        'Check 0
        Dim strMsg As String

        strMsg = ""
        checkZeroqty = True
        If Not rs_tmp_quotation Is Nothing Then
            Dim dr_tmp_quotation() As DataRow = rs_tmp_quotation.Tables("RESULT").Select("qud_toqty=0 and Gen='Y'", "qud_cocde,qud_qutno,qud_qutseq")
            'dr_tmp_quotation(0).Item("ibi_itmsts")


            'rs_tmp_quotation.Filter = "qud_smpqty=0"
            If dr_tmp_quotation.Length > 0 Then
                'rs_tmp_quotation.Sort = "quh_cocde,qud_qutno,qud_qutseq"
                'rs_tmp_quotation.MoveFirst()
                'Do While Not rs_tmp_quotation.EOF
                For i As Integer = 0 To dr_tmp_quotation.Length - 1
                    If dr_tmp_quotation(i).Item("qud_toqty") = 0 Then
                        strMsg = strMsg & dr_tmp_quotation(i).Item("qud_qutno") & "         " & dr_tmp_quotation(i).Item("qud_qutseq") & "             " & dr_tmp_quotation(i).Item("qud_itmnoreal") & "\" & dr_tmp_quotation(i).Item("qud_itmnotmp") & _
                        "\" & dr_tmp_quotation(i).Item("qud_itmnoven") & "\" & dr_tmp_quotation(i).Item("qud_itmnovenno") & vbCrLf
                    End If
                Next

                'rs_tmp_quotation.MoveNext()
                'Loop
            Else
                checkZeroqty = False
            End If
        End If
        If strMsg <> "" Then
            strMsg = "The Tentative Order Qty of the following reocord(s) is/are Zero:        " & vbCrLf & _
                     vbCrLf & "Quotation #      Seq #       Item #    " & vbCrLf & _
                    vbCrLf & strMsg & _
                    vbCrLf & vbCrLf & "Records with Zero Tentative Order Qty will not be generated." & vbCrLf & _
                    "Continue Tentative Order Request Generation?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "Zero Tentative Quantity") = vbYes Then
                checkZeroqty = False
            End If
        End If
    End Function
    Public Function isABUAssortment(ByVal itmNo As String) As Boolean


        isABUAssortment = False



        gspStr = "SP_SELECT_CHECK_ASST_FOR_PC '" & gsCompany & "','" & IIf(itmNo = "", "X", itmNo) & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_ABUASST, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading TOM00002 isABUAssortment rs_ABUASST : " & rtnStr)
        Else
            If rs_ABUASST.Tables("RESULT").Rows.Count > 0 Then
                isABUAssortment = True
            Else
                isABUAssortment = False
            End If
        End If



    End Function

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub cboCoCde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCoCde.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If Me.txtQutNo.Enabled = True Then
                Me.txtQutNo.Focus()
            End If
        End If
    End Sub

    Private Sub txtQutNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQutNo.Enter
        Call HighlightText(txtQutNo)

    End Sub
    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub txtFrom_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom.Enter
        Call HighlightText(txtFrom)
    End Sub

    Private Sub txtTo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTo.Enter
        Call HighlightText(txtTo)
    End Sub




    Private Sub grdDetailSet_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDetailSet.EditingControlShowing
        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            txtbox.MaxLength = 4
            AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress

        End If
    End Sub





    Private Sub grdDetailSet_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellLeave
        'if the editing control is not nothing, unsubscribe the KeyPressevent
        If Not (txtbox Is Nothing) Then
            RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
        End If




    End Sub


    Private Sub grdDetail_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDetail.EditingControlShowing




        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            If grdDetail.CurrentCell.ColumnIndex = 8 Then
                txtbox.MaxLength = 8
                AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
            End If
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



    End Sub




    Private Sub grdDetail_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellLeave
        'if the editing control is not nothing, unsubscribe the KeyPressevent



        If Not (txtbox Is Nothing) Then
            RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
        End If

        'rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(8) = rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(6) + rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(7)


    End Sub
    Private Sub grdDetail_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellEndEdit
        ' rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(8) = rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(6) + rs_QUOTNDTL.Tables("RESULT").Rows(e.RowIndex).Item(7)
    End Sub



    Private Sub grdDetailSet_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellEndEdit
        rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(8) = rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(6) + rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(7)
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtQutNo.Name
        frmSYM00018.strModule = "QU"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub grdDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellContentClick

    End Sub

    Private Sub grdDetail_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDetail.CellValidating
        Dim row As DataGridViewRow = grdDetail.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case 10, 11, 12, 13
                    If strNewVal.Length <> 10 Or IsDate(strNewVal) = False Then
                        MsgBox("Invalid Effective Date [MM/dd/yyyy]!")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case 8
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid Quantity!")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        End If
    End Sub

    Private Sub cmdApplyA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyA.Click

        For index As Integer = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
            rs_QUOTNDTL.Tables("RESULT").Rows(index).Item(0) = "Y"
        Next

        grdDetail.DataSource = rs_QUOTNDTL.Tables("RESULT").DefaultView
        grdDetail.Refresh()


    End Sub

    Private Sub lblStkQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStkQty.Click

    End Sub

    Private Sub txtStkQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStkQty.TextChanged

    End Sub
End Class