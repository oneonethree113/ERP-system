Public Class SAM00004
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

    Public rs_SYUSRRIGHT_Check As New DataSet

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
        optZeroQty = "Y"

        If Me.chkZeroQty.Checked = True Then
            optZeroQty = "Y"
        End If

        gspStr = "sp_select_SAM00004_2 '" & gsCompany & "','" & txtQutNo.Text & "','" & optZeroQty & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_QUOTNDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00004 cmdFind_Click rs_QUOTNDTL : " & rtnStr)
        End If

        gspStr = "sp_select_SAREQDTL_created '" & gsCompany & "','" & txtQutNo.Text & "'" 'Print log
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAREQDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00004 cmdFind_Click rs_SAREQDTL : " & rtnStr)
        Else
            Me.cmdSearch.Enabled = False
            Me.chkZeroQty.Enabled = False
            txtReqNo.Text = ""
            txtReqNoSet.Text = ""
            If rs_SAREQDTL.Tables("RESULT").Rows.Count > 0 Then
                For i As Integer = 0 To rs_SAREQDTL.Tables("RESULT").Rows.Count - 1
                    txtReqNo.Text = txtReqNo.Text + IIf(txtReqNo.Text = "", "", " ;" + Chr(13) + Chr(10)) + "Sample Request No. " + rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqno") + " created on " + Format(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srh_credat"), "MM/dd/yyyy")
                Next
            End If
            If rs_QUOTNDTL.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Sample Order Qty in the Quotation or Items is Discontinued or Inactive or Item is Old Item or To be confirmed.", vbInformation, "Information")
                cmdApply.Enabled = False
                Me.chkZeroQty.Enabled = True
                Me.cmdSearch.Enabled = True
                txtQutNo.Focus()
                Exit Sub
            ElseIf gsSalTem <> rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then

                gspStr = "sp_select_SYUSRRIGHT_Check '" & cboCoCde.Text & "','" & gsUsrID & "','" & txtQutNo.Text & "','" & "QU" & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFind_Click sp_select_SYUSRRIGHT_Check :" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("You have no right to Generate this document.")
                    cmdApply.Enabled = False
                    Me.chkZeroQty.Enabled = True
                    Me.cmdSearch.Enabled = True
                    txtQutNo.Focus()
                    Exit Sub
                End If
            End If

            rs_QUOTNDTL.Tables("RESULT").Columns("cbi_cus2na").ReadOnly = False
                If IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na") = ""
                End If
                If rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na") <> "" Then
                    If Strings.Right(Trim(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus1na")), 8) <> "(Active)" Or Strings.Right(Trim(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na")), 8) <> "(Active)" Then
                        MsgBox("Customer is not Active, cannot generate Sample Request.", vbCritical, "Warning")
                        cmdApply.Enabled = False
                        Me.chkZeroQty.Enabled = True
                        Me.cmdSearch.Enabled = True
                        txtQutNo.Focus()
                        Exit Sub
                    End If
                Else
                    If Strings.Right(Trim(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus1na")), 8) <> "(Active)" Then
                        MsgBox("Customer is not Active, cannot generate Sample Request.", vbCritical, "Warning")
                        cmdApply.Enabled = False
                        Me.chkZeroQty.Enabled = True
                        Me.cmdSearch.Enabled = True
                        txtQutNo.Focus()
                        Exit Sub
                    End If
                End If

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
            cboCoCde.Enabled = False

        End If

        '*** Assortment Item

        gspStr = "sp_select_QUASSINF '" & gsCompany & "','" & txtQutNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_QUASSINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00004 cmdFind_Click rs_QUASSINF : " & rtnStr)
        End If


    End Sub

    Private Sub SAM00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)        'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Starup position
        cmdApply.Enabled = False
        grdDetail.Enabled = False
        grdDetailSet.Enabled = False
        Me.Cursor = Windows.Forms.Cursors.Default


        'AddHandler grdDetail.EditingControlShowing, AddressOf grdDetail_EditingControlShowing
        ' AddHandler grdDetail.CellLeave, AddressOf grdDetail_CellLeave

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

            .Columns(3).HeaderCell.Value = "Temp Item"
            .Columns(3).ReadOnly = True

            .Columns(4).HeaderCell.Value = "Vendor"
            .Columns(4).ReadOnly = True

            .Columns(5).HeaderCell.Value = "Vendor Item No"
            .Columns(5).ReadOnly = True

            .Columns(6).HeaderCell.Value = "Item Desc."
            .Columns(6).ReadOnly = True
            '.Columns(3).Width = 2500

            '.Columns(4).Caption = "VD. Color Code"
            .Columns(7).HeaderCell.Value = "Color Code"
            .Columns(7).ReadOnly = True
            '.Columns(4).Width = 1500

            .Columns(8).HeaderCell.Value = "Packing & Terms"
            .Columns(8).ReadOnly = True
            .Columns(8).Width = 200
            '.Columns(5).Width = 1500

            .Columns(9).HeaderCell.Value = "Sample Stock Qty"
            '.Columns(6).Width = 800
            .Columns(9).Width = 60
            .Columns(9).ReadOnly = False

            .Columns(10).HeaderCell.Value = "Cust Sample Qty"
            '.Columns(7).Width = 800
            .Columns(10).Width = 60
            .Columns(10).ReadOnly = False

            .Columns(11).HeaderCell.Value = "Total Sample Qty"
            .Columns(11).ReadOnly = True
            '.Columns(8).Width = 1000
            .Columns(11).Width = 60

            .Columns(12).HeaderCell.Value = "Sample UM"
            .Columns(12).ReadOnly = True
            '.Columns(9).Width = 800
            .Columns(12).Width = 80

            .Columns(13).HeaderCell.Value = "Quotation#"
            .Columns(13).ReadOnly = True
            '.Columns(10).Width = 1000

            '.Columns(10).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False
            .Columns(19).Visible = False
            .Columns(20).Visible = False
            .Columns(21).Visible = False
            .Columns(22).Visible = False

            .Columns(23).HeaderCell.Value = "CCY"
            .Columns(23).ReadOnly = True
            '.Columns(20).Width = 600
            .Columns(23).Width = 60

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

            .Columns(50).HeaderCell.Value = "Sample Price"
            .Columns(50).ReadOnly = True
            '.Columns(47).Width = 1000

            .Columns(49).Visible = False
            .Columns(48).Visible = False
            .Columns(51).Visible = False
            .Columns(52).Visible = False
            .Columns(53).Visible = False
            .Columns(54).Visible = False
            .Columns(55).Visible = False
            .Columns(56).Visible = False
            .Columns(57).Visible = False
            .Columns(60).HeaderCell.Value = "Pri Customer"
            .Columns(60).ReadOnly = True
            '.Columns(57).Width = 1500
            .Columns(61).HeaderCell.Value = "Sec Customer"
            .Columns(61).ReadOnly = True
            '.Columns(58).Width = 1500
            .Columns(58).Visible = False
            .Columns(59).Visible = False

            'Added by Mark Lau 20070618
            .Columns(62).Visible = False
            .Columns(63).Visible = False
            .Columns(64).Visible = False
            .Columns(65).Visible = False
            .Columns(66).Visible = False

            '*********Carlos Lui added on 2012/08/29*********
            .Columns(67).HeaderCell.Value = "Price Pri Customer"
            .Columns(67).ReadOnly = True
            '.Columns(64).Width = 1500
            .Columns(68).HeaderCell.Value = "Price Sec Customer"
            .Columns(68).ReadOnly = True
            '.Columns(65).Width = 1500
            .Columns(69).HeaderCell.Value = "Price HK Price Term"
            .Columns(69).ReadOnly = True
            '.Columns(66).Width = 1500
            .Columns(70).HeaderCell.Value = "Price Fty Price Term"
            .Columns(70).ReadOnly = True
            '.Columns(67).Width = 1500
            .Columns(71).HeaderCell.Value = "Price Transport Term"
            .Columns(71).ReadOnly = True
            '.Columns(68).Width = 1500
            .Columns(72).HeaderCell.Value = "Price Effect Date"
            .Columns(72).ReadOnly = True
            '.Columns(69).Width = 1500
            .Columns(73).HeaderCell.Value = "Price Expiry Date"
            .Columns(73).ReadOnly = True
            '.Columns(70).Width = 1500
            '*********Carlos Lui added on 2012/08/29*********

            .Columns(74).Visible = False 'Item Type
            
            .Columns(75).Visible = False 'Sale Maneger

            .Columns(76).Visible = False
            .Columns(77).Visible = False
            .Columns(78).Visible = False

        End With
    End Sub


    Private Sub grdDetail_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellClick


        'change gen from Y to N /from N to Y
        If e.ColumnIndex = 0 Then

            If (e.RowIndex = -1) Then
                Exit Sub
            End If

            Dim tmpseq As String
            Dim curseq As String
            tmpseq = ""
            curseq = grdDetail.Item(1, e.RowIndex).Value

            Dim i As Integer
            Dim loc As Integer

            loc = -1

            For i = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
                tmpseq = rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq")
                If tmpseq = curseq Then
                    loc = i
                    Exit For
                End If
            Next i

            If loc = -1 Then
                Exit Sub
            End If

            rs_QUOTNDTL.Tables("RESULT").Columns(0).ReadOnly = False 'column 0: gen
            If rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item(0) = "Y" Then
                rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item(0) = "N"
            ElseIf rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item(0) = "N" Then
                rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item(0) = "Y"
            End If
        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        Me.grdDetailSet.DataSource = Nothing
        Me.grdDetailSet.Enabled = False
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
        grdDetail.DataSource = Nothing
        rs_QUOTNDTL_tmp = Nothing
        rs_QUOTNDTL = Nothing
        rs_SAREQDTL = Nothing
        rs_QUASSINF = Nothing
        grdDetail.Enabled = False
        txtQutNo.Enabled = True
        cmdFind.Enabled = True
        cboCoCde.Enabled = True
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
        If grdDetail.SelectedRows.Count <= 0 Then
            For i As Integer = 0 To grdDetail.RowCount - 1
                If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") >= Val(txtFrom.Text) And rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") <= Val(txtTo.Text) Then
                    If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("gen") = "N" Then
                        rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("gen") = "Y"
                    Else
                        rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("gen") = "N"
                    End If

                    If txtStkQty.Text <> "" Then
                        rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_stkqty") = Val(txtStkQty.Text)
                        rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_smpqty") = Val(txtStkQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_cusqty")
                    End If

                    If txtCusQty.Text <> "" Then
                        rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_cusqty") = Val(txtCusQty.Text)
                        rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_smpqty") = Val(txtCusQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_stkqty")
                    End If
                End If
            Next
        Else
            For i As Integer = 0 To grdDetail.SelectedRows.Count - 1

                If rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("gen") = "N" Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("gen") = "Y"
                Else
                    rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("gen") = "N"
                End If

                If txtStkQty.Text <> "" Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_stkqty") = Val(txtStkQty.Text)
                    rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_smpqty") = Val(txtStkQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_cusqty")
                End If

                If txtCusQty.Text <> "" Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_cusqty") = Val(txtCusQty.Text)
                    rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_smpqty") = Val(txtCusQty.Text) + rs_QUOTNDTL.Tables("RESULT").Rows(grdDetail.SelectedRows.Item(i).Index).Item("qud_stkqty")
                End If

            Next
        End If
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
                    Exit Sub 'BN BUG FIX 2 20130418
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
                If rs_QUOTNDTL_tmp.Tables("RESULT").Rows(i).Item("gen") = "Y" Then 'BN BUG FIX 1 20130418
                    strQutSeq = IIf(strQutSeq = "", strQutSeq & "qai_qutseq='" & rs_QUOTNDTL_tmp.Tables("RESULT").Rows(i).Item("qud_qutseq") & "'", strQutSeq & " or qai_qutseq='" & rs_QUOTNDTL_tmp.Tables("RESULT").Rows(i).Item("qud_qutseq") & "'")
                End If
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


        If e.ColumnIndex = 0 Then

            Dim tmpseq As String
            Dim curseq As String
            tmpseq = ""
            curseq = grdDetail.Item(1, e.RowIndex).Value

            Dim i As Integer
            Dim loc As Integer

            loc = -1

            For i = 0 To rs_QUOTNDTL_SET.Tables("RESULT").Rows.Count - 1
                tmpseq = rs_QUOTNDTL_SET.Tables("RESULT").Rows(i).Item("qud_qutseq")
                If tmpseq = curseq Then
                    loc = i
                    Exit For
                End If
            Next i

            If loc = -1 Then
                Exit Sub
            End If

            rs_QUOTNDTL_SET.Tables("RESULT").Columns(0).ReadOnly = False 'column 0: gen
            If rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(0) = "Y" Then
                rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(0) = "N"
            ElseIf rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(0) = "N" Then
                rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(0) = "Y"
            End If
        End If

        ''change gen from Y to N /from N to Y <<What the fuck!>>
        'If e.ColumnIndex = 0 Then
        '    rs_QUOTNDTL_SET.Tables("RESULT").Columns(0).ReadOnly = False 'column 0: gen
        '    If rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "Y" Then
        '        rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "N"
        '    ElseIf rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "N" Then
        '        rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(0) = "Y"
        '    End If
        'End If
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


        If Not Me.grdDetailSet.DataSource Is Nothing Then
            rs_QUOTNDTL_tmp = rs_QUOTNDTL_SET.Copy 'rs_QUOTNDTL_tmp = CopyRS(rs_QUOTNDTL_SET)
            rs_QUASSINF_tmp = rs_QUASSINF_SET.Copy 'rs_QUASSINF_tmp = CopyRS(rs_QUASSINF_SET)
        ElseIf Not Me.grdDetail.DataSource Is Nothing Then
            rs_QUOTNDTL_tmp = rs_QUOTNDTL.Copy 'rs_QUOTNDTL_tmp = CopyRS(rs_QUOTNDTL)
            rs_QUASSINF_tmp = rs_QUASSINF.Copy 'rs_QUASSINF_tmp = CopyRS(rs_QUASSINF)
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

                rs_QUOTNDTL_tmp.Tables("RESULT").DefaultView.Sort = "quh_cocde,quh_cus1no,quh_cus2no,qud_cusven,qud_cussub"

                Dim rs_QUOTNDTL_tmp_sorttable As DataTable = rs_QUOTNDTL_tmp.Tables("RESULT").DefaultView.ToTable()
                For i As Integer = 0 To rs_QUOTNDTL_tmp_sorttable.Rows.Count - 1
                    Dim a As Integer = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_smpqty").ToString
                    If rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_smpqty") > 0 Then
                        If LTrim(CoCde) <> LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cocde")) Or LTrim(cus1no) <> LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")) Or LTrim(cus2no) <> LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")) Or LTrim(venno) <> LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven")) Or LTrim(subcde) <> LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub")) Then
                            '--- Update Company Code before execute ---
                            gsCompany = Trim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cocde"))
                            Call Update_gs_Value(gsCompany)


                            gspStr = "sp_select_DOC_GEN '" & gsCompany & "','" & "SR" & "','" & gsUsrID & "'"

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, rs_DOC_GEN, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SAM00004 cmdGen_Click  sp_select_DOC_GEN : " & rtnStr)
                            Else
                                reqno = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
                            End If

                            Dim saldiv As String
                            Dim salmgt As String
                            Dim tmp_rs As DataSet
                            gspStr = "sp_list_SYUSRPRF_2 '" & "" & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_saldivtem").ToString & "'"
                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, tmp_rs, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SAM00004 cmdGen_Click  sp_list_SYUSRPRF_2 : " & rtnStr)
                            Else
                                If Not tmp_rs.Tables("RESULT").Rows.Count = 0 Then
                                    saldiv = tmp_rs.Tables("RESULT").Rows(0).Item(0)
                                    salmgt = tmp_rs.Tables("RESULT").Rows(0).Item(4)
                                Else
                                    saldiv = ""
                                    salmgt = ""
                                End If
                            End If
                            'quh_saldiv
                            'quh_salmgt
                            gspStr = "sp_insert_SAREQHDR '" & gsCompany & "','" & reqno & "','" & _
                            rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven") & "','" & _
                            rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub") & "','" & _
                            rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("vci_adr") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("vci_stt") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("vci_cty") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("vci_zip") & _
                            "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("vci_cntctp") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_salrep") & "','" & _
                            rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus1no") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus2no") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_prctrm") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_rmk") _
                            & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_saldivtem") & "','" & saldiv & "','" & salmgt & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_srname") & "','" & gsUsrID & "'"
                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQHDR, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SAM00004 cmdGen_Click  sp_insert_SAREQHDR : " & rtnStr)
                            Else
                                reqno = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
                            End If
                            txtReqNoSet.Text = txtReqNoSet.Text + IIf(txtReqNoSet.Text = "", reqno, "; " + reqno) + " for Vendor - " + rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven") + IIf(Len(RTrim(LTrim(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub")))) = 0, "", " Sub Code - " + rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub"))


                        End If

                        Dim flgABUAsst As Boolean
                        flgABUAsst = False

                        If isABUAssortment(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnoreal")) = True Then
                            flgABUAsst = True
                        End If

                        '   ""  < for Sample Stage cancel?
                        gspStr = "sp_insert_SAREQDTL2 '" & gsCompany & "','" & reqno & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnoreal") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnotyp") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnoreal") & _
                                    "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnotmp") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnoven") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmnovenno") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("Packing & Terms") & "','" & _
                                    "" & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmsts") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_alsitmno") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_alscolcde") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_venitm") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmdsc").Replace("'", "''") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("ibi_chndsc").Replace("'", "''") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_colcde") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cuscol") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_coldsc") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_pckseq") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_untcde") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_inrqty") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_mtrqty") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cft") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_smpqty") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_stkqty") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusqty") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_fcurcde") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftyprc") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftycst") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_smpunt") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_note").Replace("'", "''") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_tbm") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutno") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutseq") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("icf_vencol") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus1no") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus2no") & "','" & _
                                    Replace(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("cus1na"), "'", "''") & "','" & _
                                    Replace(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("cus2na"), "'", "''") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_smpprc") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftyprc") & "','" & _
                                    IIf(flgABUAsst = True, rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_conftr"), Convert.ToInt32(rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("ycf_value"))) & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutitmsts") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_curcde") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("yst_charge") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("yst_chgval") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_itmtyp") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusitm") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_venno") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_subcde") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cus1no") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cus2no") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_prctrm") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_ftyprctrm") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_trantrm") & "','" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_effdat") & "','" & _
                                    rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_expdat") & "','" & _
                                    gsUsrID & "'"

                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQDTL2, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SAM00004 cmdGen_Click  sp_insert_SAREQDTL2 : " & rtnStr)
                        Else
                            reqseq = rs_insert_SAREQDTL2.Tables("RESULT").Rows(0).Item(0)

                        End If


                        If rs_QUASSINF_tmp.Tables("RESULT").Rows.Count > 0 Then
                            Dim dr_QUASSINF_tmp() As DataRow = rs_QUASSINF_tmp.Tables("RESULT").Select("qai_qutno='" & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutno") & "' and qai_qutseq = " & rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_qutseq"))

                            If dr_QUASSINF_tmp.Length > 0 Then
                                For j As Integer = 0 To dr_QUASSINF_tmp.Length - 1
                                    gspStr = "sp_insert_SAREQASS '" & gsCompany & "','" & reqno & "','" & reqseq & "','" & _
                                                UCase(dr_QUASSINF_tmp(j).Item("qai_itmno")) & "','" & UCase(dr_QUASSINF_tmp(j).Item("qai_assitm")) & "','" & _
                                                Replace(dr_QUASSINF_tmp(j).Item("qai_assdsc"), "'", "''") & "','" & dr_QUASSINF_tmp(j).Item("qai_cusitm") & "','" & _
                                                dr_QUASSINF_tmp(j).Item("qai_colcde") & "','" & _
                                                dr_QUASSINF_tmp(j).Item("qai_alsitmno") & "','" & dr_QUASSINF_tmp(j).Item("qai_alscolcde") & "','" & _
                                                dr_QUASSINF_tmp(j).Item("qai_cussku") & "','" & _
                                                dr_QUASSINF_tmp(j).Item("qai_upcean") & "','" & dr_QUASSINF_tmp(j).Item("qai_cusrtl") & "','" & _
                                                dr_QUASSINF_tmp(j).Item("qai_untcde") & "','" & dr_QUASSINF_tmp(j).Item("qai_inrqty") & "','" & _
                                                dr_QUASSINF_tmp(j).Item("qai_mtrqty") & "','" & gsUsrID & "'"

                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs_insert_SAREQASS, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading SAM00004 cmdGen_Click sp_insert_SAREQASS : " & rtnStr)

                                    End If
                                Next


                            End If
                        End If
                        CoCde = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cocde")
                        cus1no = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")
                        cus2no = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")
                        'Marco 2005/05/21
                        venno = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cusven")
                        subcde = rs_QUOTNDTL_tmp_sorttable.Rows(i).Item("qud_cussub")

                    End If
                Next
            End If


            '--- Reset Company Code after execute ---
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            '------------------------------------------
            If Me.txtReqNoSet.Text = "" Then
                Me.txtReqNoSet.Text = "No Sample Request Generated"
            Else
                Call cmdClearAll_Click(sender, e)
            End If
        Else
            MsgBox("No record selected for generate, please try again.")
            Exit Sub
        End If
    End Sub

    Private Function checkZeroqty(ByVal rs_tmp_quotation As DataSet) As Boolean
        Dim strMsg As String

        strMsg = ""
        checkZeroqty = True
        If Not rs_tmp_quotation Is Nothing Then
            Dim dr_tmp_quotation() As DataRow = rs_tmp_quotation.Tables("RESULT").Select("qud_smpqty=0", "quh_cocde,qud_qutno,qud_qutseq")
            'dr_tmp_quotation(0).Item("ibi_itmsts")


            'rs_tmp_quotation.Filter = "qud_smpqty=0"
            If dr_tmp_quotation.Length > 0 Then
                'rs_tmp_quotation.Sort = "quh_cocde,qud_qutno,qud_qutseq"
                'rs_tmp_quotation.MoveFirst()
                'Do While Not rs_tmp_quotation.EOF
                For i As Integer = 0 To dr_tmp_quotation.Length - 1
                    If dr_tmp_quotation(i).Item("qud_smpqty") = 0 Then
                        strMsg = strMsg & dr_tmp_quotation(i).Item("qud_qutno") & "      " & dr_tmp_quotation(i).Item("qud_qutseq") & "             " & dr_tmp_quotation(i).Item("qud_itmnoreal") & _
                        " / " & dr_tmp_quotation(i).Item("qud_itmnotmp") & " / " & dr_tmp_quotation(i).Item("qud_itmnoven") & " / " & dr_tmp_quotation(i).Item("qud_itmnovenno") & vbCrLf
                    End If
                Next
                
                'rs_tmp_quotation.MoveNext()
                'Loop
            Else
                checkZeroqty = False
            End If
        End If
        If strMsg <> "" Then
            strMsg = "The Sample Qty of the following reocord(s) is/are Zero:        " & vbCrLf & _
                     vbCrLf & "Quotation #      Seq #       Item #    " & vbCrLf & _
                    vbCrLf & strMsg & _
                    vbCrLf & vbCrLf & "Records with Zero Sample Qty will not be generated." & vbCrLf & _
                    "Continue Sample Request Generation?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "Zero Sample Quantity") = vbYes Then
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
            MsgBox("Error on loading SAM00004 isABUAssortment rs_ABUASST : " & rtnStr)
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
        e.CellStyle.BackColor = Color.White
        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            txtbox.MaxLength = 4
            AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
            AddHandler txtbox.TextChanged, AddressOf txtBoxDetailSet_TextChanged
        End If
    End Sub





    Private Sub grdDetailSet_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellLeave
        'if the editing control is not nothing, unsubscribe the KeyPressevent
        'If Not (txtbox Is Nothing) Then
        '    RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
        'End If




    End Sub


    Private Sub grdDetail_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDetail.EditingControlShowing
        If grdDetail.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White
        Select Case grdDetail.CurrentCell.ColumnIndex
            Case 9, 10
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    txtbox.MaxLength = 4
                    AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
                    AddHandler txtbox.TextChanged, AddressOf txtBoxDetail_TextChanged
                End If
        End Select


    End Sub

    Private Sub txtBoxDetail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = grdDetail.CurrentCell.RowIndex
        Dim iCol As Integer = grdDetail.CurrentCell.ColumnIndex

        Dim curvalue As String = grdDetail.CurrentCell.EditedFormattedValue
        Dim SampleStock As Integer
        Dim CustSample As Integer



        Select Case grdDetail.CurrentCell.ColumnIndex
            Case 9, 10

                If grdDetail.CurrentCell.ColumnIndex = 9 Then
                    If IsNumeric(curvalue) Then
                        SampleStock = curvalue
                    Else
                        SampleStock = 0
                    End If
                Else
                    If IsNumeric(grdDetail.Item(9, iRow).Value) Then
                        SampleStock = grdDetail.Item(9, iRow).Value
                    Else
                        SampleStock = 0
                    End If
                End If


                If grdDetail.CurrentCell.ColumnIndex = 10 Then
                    If IsNumeric(curvalue) Then
                        CustSample = curvalue
                    Else
                        CustSample = 0
                    End If
                Else
                    If IsNumeric(grdDetail.Item(10, iRow).Value) Then
                        CustSample = grdDetail.Item(10, iRow).Value
                    Else
                        CustSample = 0
                    End If
                End If

                grdDetail.Item(11, iRow).Value = SampleStock + CustSample


        End Select



    End Sub

    Private Sub txtBoxDetailSet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = grdDetailSet.CurrentCell.RowIndex
        Dim iCol As Integer = grdDetailSet.CurrentCell.ColumnIndex

        Dim curvalue As String = grdDetailSet.CurrentCell.EditedFormattedValue
        Dim SampleStock As Integer
        Dim CustSample As Integer



        Select Case grdDetailSet.CurrentCell.ColumnIndex
            Case 9, 10

                If grdDetailSet.CurrentCell.ColumnIndex = 9 Then
                    If IsNumeric(curvalue) Then
                        SampleStock = curvalue
                    Else
                        SampleStock = 0
                    End If
                Else
                    If IsNumeric(grdDetailSet.Item(9, iRow).Value) Then
                        SampleStock = grdDetailSet.Item(9, iRow).Value
                    Else
                        SampleStock = 0
                    End If
                End If


                If grdDetailSet.CurrentCell.ColumnIndex = 10 Then
                    If IsNumeric(curvalue) Then
                        CustSample = curvalue
                    Else
                        CustSample = 0
                    End If
                Else
                    If IsNumeric(grdDetailSet.Item(10, iRow).Value) Then
                        CustSample = grdDetailSet.Item(10, iRow).Value
                    Else
                        CustSample = 0
                    End If
                End If

                grdDetailSet.Item(11, iRow).Value = SampleStock + CustSample


        End Select


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









    Private Sub grdDetailSet_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellEndEdit
        'Dim tmpqut As String
        'Dim tmpseq As String
        'Dim curqut As String
        'Dim curseq As String
        'tmpqut = ""
        'tmpseq = ""

        'curqut = grdDetailSet.Item(13, e.RowIndex).Value
        'curseq = grdDetailSet.Item(1, e.RowIndex).Value

        'Dim i As Integer
        'Dim loc As Integer

        'loc = -1

        'For i = 0 To rs_QUOTNDTL_SET.Tables("RESULT").Rows.Count - 1
        '    tmpqut = rs_QUOTNDTL_SET.Tables("RESULT").Rows(i).Item("qud_qutno")
        '    tmpseq = rs_QUOTNDTL_SET.Tables("RESULT").Rows(i).Item("qud_qutseq")
        '    If tmpqut = curqut And tmpseq = curseq Then
        '        loc = i
        '        Exit For
        '    End If
        'Next i

        'If loc = -1 Then
        '    Exit Sub
        'End If


        'Dim Vsample As Integer
        'Dim Csample As Integer

        'If IsDBNull(rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(9)) = True Then
        '    Vsample = 0
        'Else
        '    Vsample = rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(9)
        'End If

        'If IsDBNull(rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(10)) = True Then
        '    Csample = 0
        'Else
        '    Csample = rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(10)
        'End If


        'rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(9) = Vsample
        'rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(10) = Csample
        'rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(11) = Vsample + Csample


        '        rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(11) = rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(9) + rs_QUOTNDTL_SET.Tables("RESULT").Rows(loc).Item(10)


        'rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(8) = rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(6) + rs_QUOTNDTL_SET.Tables("RESULT").Rows(e.RowIndex).Item(7)
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtQutNo.Name
        frmSYM00018.strModule = "QU"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub grdDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellContentClick

    End Sub

    Private Sub grdDetailSet_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellContentClick

    End Sub

    Private Sub txtQutNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQutNo.TextChanged

    End Sub

    Private Sub grdDetail_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDetail.CellValidating
        Dim row As DataGridViewRow = grdDetail.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex
                Case 9, 10
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Qty must be numeric!")
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select
        End If
    End Sub

    Private Sub grdDetailSet_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDetailSet.CellValidating
        Dim row As DataGridViewRow = grdDetailSet.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex
                Case 9, 10
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Qty must be numeric!")
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grdDetail.EndEdit()
        grdDetail.ClearSelection()
        txtbox.Clear()
    End Sub
End Class