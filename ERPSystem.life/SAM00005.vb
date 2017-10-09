Public Class SAM00005
    Dim current_row As Integer
    Dim rs_SAORDDTL As DataSet
    Dim rs_SAORDDTL_SET As DataSet
    Dim rs_SAORDDTL_SET_tmp As DataSet
    Dim rs_SAORDDTL_tmp As DataSet
    Dim merge_rs_SAORDDTL_SET As DataSet
    Dim txtbox As TextBox = Nothing
    Dim rs_tmp As DataSet
    Dim SERVER_DATE As Date
    Dim rs_SERVER_DATE As DataSet

    Dim strCurExRat As String
    Dim strCurExEffDat As String
    Dim rs_insert_SAINVHDR As DataSet
    Dim invno As String
    Dim sp_insert_SAINVDTL2 As DataSet

    Private Sub SAM00005_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillCompCombo(gsUsrID, cboCoCde)        'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Starup position
        grdDetail.Enabled = False
        grdDetailSet.Enabled = False
        Me.Cursor = Windows.Forms.Cursors.Default

        gspStr = "sp_select_SERVER_DATE '" & gsCompany & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SERVER_DATE, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 rs_SERVER_DATE : " & rtnStr)
        Else
            If rs_SERVER_DATE.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else

                SERVER_DATE = Format(rs_SERVER_DATE.Tables("RESULT").Rows(0).Item("SERVER_DATE"), "MM/dd/yyyy")
                '    SERVER_DATE = Format(rs_SERVER_DATE(0), "MM/DD/YYYY")
            End If
        End If


    End Sub

  

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub cmdFind_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
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



        gspStr = "sp_select_SAM00005 '" & gsCompany & "','" & txtQutNo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SAM00005 cmdFind_Click rs_SAORDDTL : " & rtnStr)
        End If

        'gspStr = "sp_select_SAREQDTL_created '" & gsCompany & "','" & txtQutNo.Text & "'" 'Print log <<<<<<<<<<
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'rtnLong = execute_SQLStatement(gspStr, rs_SAREQDTL, rtnStr)
        'Me.Cursor = Windows.Forms.Cursors.Default
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading SAM00004 cmdFind_Click rs_SAREQDTL : " & rtnStr)
        'Else


        txtReqNo.Text = ""
        txtReqNoSet.Text = ""
        'If rs_SAREQDTL.Tables("RESULT").Rows.Count > 0 Then
        '    For i As Integer = 0 To rs_SAREQDTL.Tables("RESULT").Rows.Count - 1
        '        txtReqNo.Text = txtReqNo.Text + IIf(txtReqNo.Text = "", "", " ;" + Chr(13) + Chr(10)) + "Sample Request No. " + rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srd_reqno") + " created on " + Format(rs_SAREQDTL.Tables("RESULT").Rows(i).Item("srh_credat"), "MM/dd/yyyy")
        '    Next
        'End If
        If rs_SAORDDTL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Find! The Reason May be wrong QU/Company Code or Sample Order Qty in the Quotation or Items is Discontinued or Inactive or Item is Old Item or To be confirmed.", vbInformation, "Information")

            txtQutNo.Focus()
            Exit Sub
            'ElseIf gsSalTem <> rs_SAORDDTL.Tables("RESULT").Rows(current_row).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then

            'rights select need but insert????<<<<<<<

            'gspStr = "sp_select_SYUSRRIGHT_Check '" & cboCoCde.Text & "','" & gsUsrID & "','" & txtQutNo.Text & "','" & "QU" & "'"
            'rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)
            'gspStr = ""

            'Cursor = Cursors.Default

            'If rtnLong <> RC_SUCCESS Then
            '    MsgBox("Error on loading cmdFind_Click sp_select_SYUSRRIGHT_Check :" & rtnStr)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
            '    MsgBox("You have no right to Generate this document.")
            '    cmdApply.Enabled = False
            '    Me.chkZeroQty.Enabled = True
            '    Me.cmdSearch.Enabled = True
            '    txtQutNo.Focus()
            '    Exit Sub
            'End If
        End If

        'rs_QUOTNDTL.Tables("RESULT").Columns("cbi_cus2na").ReadOnly = False
        'If IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na")) Then
        '    rs_QUOTNDTL.Tables("RESULT").Rows(current_row).Item("cbi_cus2na") = ""
        'End If
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
        'End If   ------- Customer Active?


        txtCus1Na.Text = rs_SAORDDTL.Tables("RESULT").Rows(current_row).Item("quh_cus1no") & " - " & rs_SAORDDTL.Tables("RESULT").Rows(current_row).Item("quh_cus1na")
        txtCus2Na.Text = IIf((rs_SAORDDTL.Tables("RESULT").Rows(current_row).Item("quh_cus2no")) Is Nothing, "", rs_SAORDDTL.Tables("RESULT").Rows(current_row).Item("quh_cus2no") & " - " & rs_SAORDDTL.Tables("RESULT").Rows(current_row).Item("quh_cus2na"))
        If txtCus2Na.Text = " - " Then
            txtCus2Na.Text = ""
        End If
        current_row = 0 'rs_QUOTNDTL.MoveFirst()


        current_row = 0 'rs_QUOTNDTL.MoveFirst()
        For i As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Columns.Count - 1
            rs_SAORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        For i As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
            rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_seqno") = i + 1
        Next
        grdDetail.DataSource = rs_SAORDDTL.Tables("RESULT").DefaultView



        For i As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
            Dim shipqty As New Integer
            Dim chgqty As New Integer

            shipqty = rs_SAORDDTL.Tables("RESULT").Rows(i).Item(11)
            chgqty = rs_SAORDDTL.Tables("RESULT").Rows(i).Item(12)

            If chgqty > shipqty Then
                chgqty = shipqty
                rs_SAORDDTL.Tables("RESULT").Rows(i).Item(12) = chgqty
            End If


        Next

        Dim strDate As String
        Dim dblRate As Double

        For i As Integer = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
            dblRate = GetSelRat(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_curcde"), rs_SAORDDTL.Tables("RESULT").Rows(i).Item("cpi_curcde"), strDate)
            strCurExRat = CStr(dblRate)
            strCurExEffDat = strDate

            rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_smpselprc") = round2(rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_smpselprc") * dblRate)

        Next



        calculateDetailFreeQtyField()

        Call Display_Detail(grdDetail)
        Dim drv As DataRowView = rs_SAORDDTL.Tables("RESULT").DefaultView(0)
        StatusBar.Items("lblRight").Text = Format(drv.Item("sad_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("sad_upddat"), "MM/dd/yyyy") & " " & drv.Item("sad_updusr")




        grdDetail.Enabled = True
        txtQutNo.Enabled = False
        cmdFind.Enabled = False
        cboCoCde.Enabled = False


        'End If

        '*** Assortment Item 
        ' What the purpose for s_Inovice

        'gspStr = "sp_select_QUASSINF '" & gsCompany & "','" & txtQutNo.Text & "'"
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)
        'Me.Cursor = Windows.Forms.Cursors.Default
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading SAM00004 cmdFind_Click rs_QUASSINF : " & rtnStr)
        'End If


    End Sub
    Public Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String = ""
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
    Public Function round2(ByVal Value As Double) As Double
        Dim tmp As String

        Value = round(Value, 4)

        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If Len(Strings.Right(tmp, Len(tmp) - InStr(tmp, "."))) > 2 Then
                'If CDec(right(right(tmp, Len(tmp) - InStr(tmp, ".")), Len(right(tmp, Len(tmp) - InStr(tmp, "."))) - 2)) > 0 Then
                If CDec(Strings.Right(Strings.Left(Strings.Right(tmp, Len(tmp) - InStr(tmp, ".")), 3), 1)) > 0 Then
                    round2 = CDec(tmp) + 0.01
                    round2 = CDec(Strings.Left(CStr(round2), InStr(round2, ".") + 2))
                    '*********************** unknow exit error  remark by Lewis ********************
                    'Exit Function
                Else
                    round2 = round(CDec(tmp), 4)
                    Exit Function
                End If
            Else
                round2 = CDec(tmp)
                Exit Function
            End If
        Else
            round2 = CDec(tmp)
            Exit Function
        End If


    End Function
    Public Function GetSelRat(ByVal strFrmCur As String, ByVal strToCur As String, ByRef strEffDat As String) As Double
        Dim rs As DataSet


        If strEffDat = "" Then
            gspStr = "sp_select_SYCUREX_transaction '" & gsCompany & "','" & strFrmCur & "','" & strToCur & "','1900-01-01','X'"
        Else
            gspStr = "sp_select_SYCUREX_transaction '" & gsCompany & "','" & strFrmCur & "','" & strToCur & "','" & strEffDat & "','X'"
        End If




        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 rs : " & rtnStr)
            GetSelRat = 0
        Else

            If rs.Tables("RESULT").Rows.Count > 0 Then
                If strEffDat = "" Then
                    strEffDat = Format(rs.Tables("RESULT").Rows(0).Item("yce_effdat"), "yyyy-MM-dd")
                End If
                GetSelRat = CDbl(rs.Tables("RESULT").Rows(0).Item("yce_selrat"))
            Else
                GetSelRat = 0
            End If
        End If


    End Function


    Private Sub calculateDetailFreeQtyField()
        If rs_SAORDDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim sampleFreeQty As Long
        Dim i As Integer
        Dim shippedQty As Long
        Dim chargedQty As Long
        Dim remainSampleFreeQty As Long


        For i = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
            sampleFreeQty = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_freqty")
            shippedQty = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_shpqty")
            chargedQty = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_shpchgqty")

            remainSampleFreeQty = sampleFreeQty - (shippedQty - chargedQty)


            shippedQty = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_osdqty")
            chargedQty = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_chgqty")
            If (shippedQty < chargedQty) Then
                rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_shipfreqty") = 0
                rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_balfreqty") = 0
            Else
                rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_balfreqty") = remainSampleFreeQty - (shippedQty - chargedQty)
                rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sas_shipfreqty") = shippedQty - chargedQty
            End If


        Next










    End Sub

    Private Sub EndEditcalculateDetailFreeQtyField(ByVal rs As DataSet, ByVal loc As Integer)
        If rs.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim sampleFreeQty As Long

        Dim shippedQty As Long
        Dim chargedQty As Long
        Dim remainSampleFreeQty As Long

        sampleFreeQty = rs.Tables("RESULT").Rows(loc).Item("sas_freqty")
        shippedQty = rs.Tables("RESULT").Rows(loc).Item("sas_shpqty")
        chargedQty = rs.Tables("RESULT").Rows(loc).Item("sas_shpchgqty")
        remainSampleFreeQty = sampleFreeQty - (shippedQty - chargedQty)

        shippedQty = rs.Tables("RESULT").Rows(loc).Item("sas_osdqty")
        chargedQty = rs.Tables("RESULT").Rows(loc).Item("sas_chgqty")

        If (shippedQty < chargedQty) Then
            rs.Tables("RESULT").Rows(loc).Item("sas_shipfreqty") = 0
            rs.Tables("RESULT").Rows(loc).Item("sas_balfreqty") = 0
        Else
            rs.Tables("RESULT").Rows(loc).Item("sas_balfreqty") = remainSampleFreeQty - (shippedQty - chargedQty)
            rs.Tables("RESULT").Rows(loc).Item("sas_shipfreqty") = shippedQty - chargedQty
        End If



        ' rs.Tables("RESULT").AcceptChanges()







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

            .Columns(1).Visible = False
            .Columns(2).Visible = False


            .Columns(3).HeaderCell.Value = "Seq."
            .Columns(3).ReadOnly = True
            '.Columns(1).Width = 500
            .Columns(3).Width = 40

            .Columns(4).HeaderCell.Value = "Item No."
            .Columns(4).ReadOnly = True
            '.Columns(2).Width = 1500

            .Columns(5).HeaderCell.Value = "Temp Item"
            .Columns(5).ReadOnly = True

            .Columns(6).HeaderCell.Value = "Vendor"
            .Columns(6).ReadOnly = True

            .Columns(7).HeaderCell.Value = "Vendor Item"
            .Columns(7).ReadOnly = True

            .Columns(8).HeaderCell.Value = "Item Desc."
            .Columns(8).ReadOnly = True
            '.Columns(3).Width = 2500

            '.Columns(4).Caption = "VD. Color Code"
            .Columns(9).HeaderCell.Value = "Color Code"
            .Columns(9).ReadOnly = True
            '.Columns(4).Width = 1500

            .Columns(10).HeaderCell.Value = "Packing & Terms & Quotation No."
            .Columns(10).ReadOnly = True
            .Columns(10).Width = 280
            '.Columns(5).Width = 1500

            .Columns(11).HeaderCell.Value = "Shipped Qty"
            .Columns(11).ReadOnly = False

            .Columns(12).HeaderCell.Value = "Charged Qty"
            .Columns(12).ReadOnly = False

            .Columns(13).HeaderCell.Value = "Shipped Free Qty"
            .Columns(13).ReadOnly = True

            .Columns(14).HeaderCell.Value = "Balance Free Qty"
            .Columns(14).ReadOnly = True

            .Columns(15).Visible = False ' sad_untcde
            .Columns(16).Visible = False ' sad_inrqty
            .Columns(17).Visible = False ' sad_mtrqty
            .Columns(18).Visible = False ' sad_cft
            .Columns(19).Visible = False ' sad_imu_cus1no
            .Columns(20).Visible = False 'sad_imu_cus2no
            .Columns(21).Visible = False 'sad_imu_hkprctrm
            .Columns(22).Visible = False 'sad_imu_ftyprctrm
            .Columns(23).Visible = False 'sad_imu_trantrm
            .Columns(24).Visible = False 'sas_smpunt
            .Columns(25).Visible = False ' sad_smpftyprc
            .Columns(26).Visible = False 'sad_smpselprc
            .Columns(27).Visible = False 'sas_outchgqty
            .Columns(28).Visible = False 'sas_outshqty
            .Columns(29).Visible = False 'sad_imu_effdat
            .Columns(30).Visible = False ' sad_imu_expdat
            .Columns(31).Visible = False ' sad_fcurcde
            .Columns(32).Visible = False ' quh_qutno
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

        End With
    End Sub

    Private Sub grdDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellClick
        If e.ColumnIndex = 0 Then

            If (e.RowIndex = -1) Then
                Exit Sub
            End If

            Dim currentvalue As String
            currentvalue = grdDetail.CurrentCell.Value

            If Trim(currentvalue) = "N" Then
                grdDetail.Item(0, grdDetail.CurrentCell.RowIndex).Value = "Y"
            Else
                grdDetail.Item(0, grdDetail.CurrentCell.RowIndex).Value = "N"
            End If




        End If
    End Sub

    Private Sub grdDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellContentClick

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        txtCus1Na.Text = ""
        txtCus2Na.Text = ""
        'txtReqNo.Text = ""
        grdDetail.DataSource = Nothing
        rs_SAORDDTL_tmp = Nothing
        'rs_QUOTNDTL = Nothing
        rs_SAORDDTL = Nothing

        'rs_QUASSINF = Nothing
        grdDetail.Enabled = False
        txtQutNo.Enabled = True
        cmdFind.Enabled = True
        cboCoCde.Enabled = True
        txtQutNo.Focus()
    End Sub

    Private Sub cmdInsertItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertItem.Click
        If rs_SAORDDTL Is Nothing Then
            Exit Sub
        End If

        If rs_SAORDDTL_SET Is Nothing Then
            rs_SAORDDTL_SET = rs_SAORDDTL.Clone
        End If

        rs_SAORDDTL_tmp = rs_SAORDDTL.Copy
        rs_SAORDDTL_SET_tmp = rs_SAORDDTL_SET.Copy

        Dim dr_SAORDDTL() As DataRow = rs_SAORDDTL_tmp.Tables("RESULT").Select("gen='Y'")
        If dr_SAORDDTL.Length() = 0 Then
            MsgBox("No record selected for insert, please try again.", vbInformation + vbOKOnly + vbDefaultButton1)
            Exit Sub
        End If


        Dim strMsg As String
        Me.txtReqNoSet.Text = ""
        merge_rs_SAORDDTL_SET = rs_SAORDDTL.Clone

        If Not rs_SAORDDTL_SET_tmp Is Nothing Then
            If dr_SAORDDTL.Length > 0 Then

                strMsg = ""
                Me.txtReqNoSet.Text = ""
                For i As Integer = 0 To dr_SAORDDTL.Length - 1
                    Dim dr_SAORDDTL_SET() As DataRow = rs_SAORDDTL_SET_tmp.Tables("RESULT").Select("quh_qutno='" & dr_SAORDDTL(i).Item("quh_qutno") & "' and sad_seqno=" & dr_SAORDDTL(i).Item("sad_seqno"))

                    If dr_SAORDDTL_SET.Length() > 0 Then
                        strMsg = strMsg & "Quotation #: " & dr_SAORDDTL(i).Item("quh_qutno") & "       Seq #: " & dr_SAORDDTL(i).Item("sad_seqno") & vbCrLf
                    Else
                        merge_rs_SAORDDTL_SET.Tables("RESULT").ImportRow(dr_SAORDDTL(i))
                    End If
                Next

                If strMsg <> "" Then
                    Me.txtReqNoSet.Text = "The following record(s) is/are already inserted :--" & vbCrLf & strMsg
                    Me.txtReqNoSet.ForeColor = System.Drawing.Color.Red
                    Exit Sub
                End If


            End If
        End If

        rs_SAORDDTL_SET.Merge(merge_rs_SAORDDTL_SET)

        If Me.grdDetailSet.DataSource Is Nothing Then
            For i As Integer = 0 To rs_SAORDDTL_SET.Tables("RESULT").Columns.Count - 1
                rs_SAORDDTL_SET.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            rs_SAORDDTL_SET.Tables("RESULT").DefaultView.AllowNew = False
            Me.grdDetailSet.DataSource = rs_SAORDDTL_SET.Tables("RESULT").DefaultView
            Call Display_Detail(grdDetailSet)
        End If
        grdDetailSet.Enabled = True


    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click

        Dim CoCde As String
        Dim cus1no_ As String
        Dim cus2no As String
        Dim venno As String
        Dim subcde As String

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        rs_SAORDDTL_tmp = Nothing
        Dim i As Integer
        If Not Me.grdDetailSet.DataSource Is Nothing Then
            rs_SAORDDTL_tmp = rs_SAORDDTL_SET.Copy 'rs_QUOTNDTL_tmp = CopyRS(rs_QUOTNDTL_SET)

        ElseIf Not Me.grdDetail.DataSource Is Nothing Then
            rs_SAORDDTL_tmp = rs_SAORDDTL.Copy 'rs_QUOTNDTL_tmp = CopyRS(rs_QUOTNDTL)

        Else
            Exit Sub
        End If



        If Not rs_SAORDDTL_tmp Is Nothing Then
            Dim dr_SAORDDTL() As DataRow = rs_SAORDDTL_tmp.Tables("RESULT").Select("gen='Y'")


            If dr_SAORDDTL.Length() = 0 Then
                MsgBox("No record selected for generate, please try again.")
                Exit Sub
            End If
        Else
            MsgBox("No record selected for generate, please try again.")
            Exit Sub
        End If

        Dim TtlAmtI As Double

        For i = 0 To rs_SAORDDTL_tmp.Tables("RESULT").Rows.Count - 1
            If rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("gen") = "Y" Then
                TtlAmtI = rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sad_smpselprc") * rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_chgqty")

                rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("ttlamt") = round(TtlAmtI, 4)
                rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("netamt") = round2(round(TtlAmtI, 4) * Convert.ToDouble(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("yst_chgval")) / 100)
            End If
        Next 'sad_smpselprc



        Dim auth As Boolean
        Dim YesNoCancel As Integer

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)


        'For i = 0 To rs_SAORDDTL_tmp.Tables("RESULT").Rows.Count - 1
        '    rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("")
        'Next

        If Not InputIsValid() Then
            ' save_ok = False
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If


        For i = 0 To rs_SAORDDTL_tmp.Tables("RESULT").Rows.Count - 1
            If rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("gen") = "Y" Then
                Dim cus1na As String = rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("quh_cus1no")
                Dim netamt As Decimal = rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("netamt")

                gspStr = "sp_select_CUPRCINF '" & gsCompany & "','" & cus1na & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then

                    MsgBox("Error on loading cmdSave_Click sp_select_CUPRCINF :" & rtnStr)
                Else

                    If CDec(netamt) > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtlmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_cdtuse") Then
                        If gsUsrRank > 4 Then
                            If vbYes = MsgBox("Net Amount exceed Credit and the status will be 'HLD'", vbYesNo, "Question") Then
                                auth = True
                            Else
                                auth = False
                                Me.Cursor = Windows.Forms.Cursors.Default
                                Exit Sub
                            End If
                        Else
                            YesNoCancel = MsgBox("Net Amount exceed Credit, Confirm to Save and update Customer Credit Used?", vbYesNoCancel, "Question")

                            If YesNoCancel = vbCancel Then
                                Me.Cursor = Windows.Forms.Cursors.Default
                                Exit Sub
                            ElseIf YesNoCancel = vbNo Then
                                rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("status") = "HLD - Waiting for Approval"
                            End If


                        End If
                    End If

                    '********** Add Check Risk Limit By Lewis on 15 May 2003 ****************
                    If CDec(netamt) > rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rsklmt") - rs_tmp.Tables("RESULT").Rows(0).Item("cpi_rskuse") Then
                        If gsUsrRank >= 2 Then
                            If vbYes = MsgBox("Net Amount exceed Risk and the status will be 'HLD'", vbYesNo, "Question") Then
                                auth = True
                            Else
                                auth = False
                                Me.Cursor = Windows.Forms.Cursors.Default
                                Exit Sub
                            End If
                        Else
                            If vbYes = MsgBox("Sample Invoice will Hold (Exceed Risk Limit)'", vbYesNo, "Question") Then
                                auth = True
                            Else
                                auth = False
                                Me.Cursor = Windows.Forms.Cursors.Default
                                Exit Sub
                            End If

                        End If
                    End If
                    '****************  End Add ************************************************



                End If
            End If

        Next


        rs_SAORDDTL_tmp.Tables("RESULT").DefaultView.Sort = "quh_cocde,quh_cus1no,quh_cus2no"

        Dim rs_SAORDDTL_tmp_sorttable As DataTable = rs_SAORDDTL_tmp.Tables("RESULT").DefaultView.ToTable()

        If Not rs_SAORDDTL_tmp_sorttable Is Nothing Then
            For i = 0 To rs_SAORDDTL_tmp_sorttable.Rows.Count - 1
                If rs_SAORDDTL_tmp_sorttable.Rows(i).Item("gen") = "Y" Then
                    ' If LTrim(CoCde) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cocde")) Or LTrim(cus1no_) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")) Or LTrim(cus2no) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")) Or LTrim(venno) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cusven")) Or LTrim(subcde) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cussub")) Then
                    If LTrim(CoCde) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cocde")) Or LTrim(cus1no_) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")) Or LTrim(cus2no) <> LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")) Then
                        gsCompany = Trim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cocde"))
                        Call Update_gs_Value(gsCompany)

                        Dim rs1 As DataSet

                        Call Update_gs_Value(gsCompany)
                        gspStr = "sp_select_DOC_GEN '" & gsCompany & "','SI', '" & gsUsrID & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs1, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then

                            MsgBox("Error on loading cmdSave_Click sp_select_DOC_GEN :" & rtnStr)
                        Else
                            invno = rs1.Tables("RESULT").Rows(0).Item(0)
                        End If

                        Dim saldiv As String
                        Dim salmgt As String
                        Dim tmp_rs As DataSet
                        gspStr = "sp_list_SYUSRPRF_2 '" & "" & "','" & rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_saldivtem").ToString & "'"
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

                        Dim cus1no As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")
                        Dim doctyp As String = "B/L #"
                        Dim smpPrd As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cpi_smpprd").ToString, "'", "''")
                        Dim smpFgt As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cpi_smpfgt").ToString, "'", "''")
                        Dim curcde As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cpi_curcde").ToString, "'", "''")
                        Dim Ttlamt As Double
                        Dim NetTtlamt As Double
                        Dim discount As Double
                        Dim ttlctn As Integer = 0
                        Dim prctrm As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cpi_prctrm")


                        Ttlamt = CacultateTtlAmt(rs_SAORDDTL_tmp_sorttable, rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cocde") _
                                        , rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus1no"), rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus2no"), _
                                        rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cusven"), rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cussub"))
                        discount = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("yst_chgval")
                        NetTtlamt = round2(round(Ttlamt, 4) * discount / 100)
                        discount = 100 - rs_SAORDDTL_tmp_sorttable.Rows(i).Item("yst_chgval")

                        Dim cbocus2no As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")
                        Dim txtCus1Ad As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntadr").ToString, "'", "''")
                        Dim txtCus2AD As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntadr2").ToString, "'", "''")
                        Dim txtCus1St As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntstt").ToString, "'", "''")
                        Dim cboCus1Cy As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntcty").ToString, "'", "''")
                        Dim txtCus1Zp As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntpst").ToString, "'", "''")
                        Dim txtCus2St As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntstt2").ToString, "'", "''")
                        Dim cboCus2Cy As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntcty2").ToString, "'", "''")
                        Dim txtCus2Zp As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("cci_cntpst2").ToString, "'", "''")
                        Dim cboCus1Cp As String = ""
                        Dim cboCus2Cp As String = ""
                        Dim cboSalRep As String = ""
                        Dim cboCusAgt As String = ""
                        Dim txtCourier As String = ""
                        Dim txtDocNo As String = ""
                        Dim TxtTtlCtnI As Integer = 0
                        Dim txtShpRmk As String = ""
                        Dim txtRmk As String = ""
                        Dim txtHdrRmk As String = ""

                        Dim srname As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_srname").ToString
                        Dim saltem As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_saldivtem").ToString




                        gspStr = "sp_insert_SAINVHDR '" & gsCompany & "','" & invno & "','" & SERVER_DATE & "','" & SERVER_DATE & "','" & _
                                           IIf(auth = True, "HLD", "OPE") & "','" & _
                                           cus1no & "','" & cbocus2no & "','" & _
                                           txtCus1Ad & "','" & txtCus2AD & "','" & _
                                           txtCus1St & "','" & cboCus1Cy & "','" & _
                                           txtCus1Zp & "','" & _
                                          txtCus2St & "','" & cboCus2Cy & "','" & _
                                           txtCus2Zp & "','" & _
                                           cboCus1Cp & "','" & _
                                           cboCus2Cp & "','" & _
                                           cboSalRep & "','" & _
                                           saltem & "','" & _
                                           saldiv & "','" & _
                                           salmgt & "','" & _
                                           srname & "','" & _
                                           cboCusAgt & "','" & _
                                           txtCourier & "','" & doctyp & "','" & _
                                           txtDocNo & "','" & _
                                           smpPrd & "','" & _
                                           smpFgt & "','" & _
                                           curcde & "','" & Ttlamt & "','" & _
                                           TxtTtlCtnI & "','" & _
                                           txtShpRmk & "','" & txtRmk & "','" & _
                                           prctrm & "','" & _
                                           txtHdrRmk & "','" & _
                                           discount & "','" & _
                                           NetTtlamt & "','" & strCurExRat & "','" & strCurExEffDat & "','" & gsUsrID & "'"

                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs_insert_SAINVHDR, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SAM00004 cmdGen_Click  sp_insert_SAREQHDR : " & rtnStr)
                        Else
                            ' reqno = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
                        End If
                        'txtReqNoSet.Text = txtReqNoSet.Text + IIf(txtReqNoSet.Text = "", invno, "; " + invno) + " for Vendor - " + rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cusven") + IIf(Len(RTrim(LTrim(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cussub")))) = 0, "", " Sub Code - " + rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cussub"))
                        txtReqNoSet.Text = txtReqNoSet.Text + IIf(txtReqNoSet.Text = "", invno, "; " + invno) + " Sample Invoice Created."

                    End If

                    Dim invseq As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_seqno")
                    Dim itmno As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_itmno")
                    Dim cusitm As String = ""
                    Dim itmdsc As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_itmdsc"), "'", "''")
                    Dim colcde As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_colcde")
                    Dim alsitmno As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_alsitmno")
                    Dim alscolcde As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_alscolcde")
                    Dim pckunt As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_untcde")
                    Dim inrqty As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_inrqty")
                    Dim mtrqty As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_mtrqty")
                    Dim cft As Double = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cft")
                    Dim cuscol As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cuscol")
                    Dim cussmppo As String = ""
                    Dim coldsc As String = Replace(rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_coldsc"), "'", "''")
                    Dim curcde1 As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_curcde")
                    Dim smpselprc As Double = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_smpselprc")
                    Dim smpuntcde As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_smpuntcde")
                    Dim ttlamt1 As Double = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("ttlamt")
                    Dim smpunt As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_smpunt")
                    Dim shpqty As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_osdqty")
                    Dim balfreqty As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_balfreqty")
                    Dim chgqty As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_chgqty")
                    Dim rmk As String = ""
                    Dim itmtyp As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_itmtyp")
                    Dim reqno As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_reqno")
                    Dim reqseq As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_reqseq")
                    Dim qutno As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_qutno")
                    Dim qutseq As Integer = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_qutseq")
                    Dim venno1 As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_venno")
                    Dim subcde1 As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_subcde")
                    Dim cusven As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cusven")
                    Dim cussub As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cussub")
                    Dim fcurcde As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_fcurcde")
                    Dim ftyprc As Double = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_smpftyprc")
                    Dim cus1no1 As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")
                    Dim cus2no1 As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")
                    Dim hkprctrm As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_imu_hkprctrm")
                    Dim ftyprctrm As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_imu_ftyprctrm")
                    Dim trantrm As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_imu_trantrm")
                    Dim effdat As DateTime = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_imu_effdat")
                    Dim expdat As DateTime = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_imu_expdat")
                    Dim itmnotmp As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_itmnotmp")
                    Dim itmnoven As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_itmnoven")
                    Dim itmnovenno As String = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sas_itmnovenno")


                    gspStr = "sp_insert_SAINVDTL3 '" & gsCompany & "','" & _
                         invno & "','" & _
                          invseq & "','" & itmno & "','" & cusitm & "','" & _
                          itmdsc & "','" & _
                          colcde & "','" & alsitmno & "','" & alscolcde & "','" & _
                          pckunt & "','" & inrqty & "','" & mtrqty & "','" & _
                          cft & "','" & _
                          cuscol & "','" & _
                          cussmppo & "','" & _
                         coldsc & "','" & _
                         curcde1 & "','" & _
                          smpselprc & "','" & _
                         smpuntcde & "','" & _
                          ttlamt1 & "','" & _
                          smpunt & "','" & shpqty & "','" & balfreqty & "','" & chgqty & "','" & _
                          rmk & "','" & itmtyp & "','" & _
                          reqno & "','" & reqseq & "','" & _
                         qutno & "','" & qutseq & "','" & _
                         venno1 & "','" & subcde1 & "','" & cusven & "','" & cussub & "','" & _
                          fcurcde & "','" & ftyprc & "','" & _
                          cus1no1 & "','" & cus2no1 & "','" & _
                          hkprctrm & "','" & ftyprctrm & "','" & _
                         trantrm & "','" & effdat & "','" & _
                          expdat & "','" & _
                          itmnotmp & "','" & _
                          itmnoven & "','" & _
                          itmnovenno & "','" & _
                          gsUsrID & "'"

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, sp_insert_SAINVDTL2, rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SAM00003 sp_insert_SAINVDTL3 : " & rtnStr)

                    End If


                    CoCde = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cocde")
                    cus1no_ = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus1no")
                    cus2no = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("quh_cus2no")
                    venno = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cusven")
                    subcde = rs_SAORDDTL_tmp_sorttable.Rows(i).Item("sad_cussub")

                End If
            Next

            '--- Reset Company Code after execute ---
            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)
            '------------------------------------------
            If Me.txtReqNoSet.Text = "" Then
                Me.txtReqNoSet.Text = "No Sample Invoice Generated"
            Else
                Call cmdClearAll_Click(sender, e)
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
        Else
            MsgBox("No record selected for generate, please try again.")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If


    End Sub


    Private Function CacultateTtlAmt(ByVal RS As DataTable, _
                                     ByVal cocde As String, _
                                     ByVal cusno1 As String, _
                                     ByVal cusno2 As String, _
                                     ByVal cusven As String, _
                                     ByVal cussub As String) As Double
        Dim i As Integer
        Dim TTlAmt As Double
        Dim dr_SAORDDTL_tmp_sorttable() As DataRow = RS.Select("gen = 'y' and quh_cocde = '" & cocde & "' and quh_cus1no = '" & cusno1 & "' and quh_cus2no = '" & cusno2 & "' and sad_cusven = '" & cusven & "' and sad_cussub = '" & cussub & "'")

        For i = 0 To dr_SAORDDTL_tmp_sorttable.Length - 1
            TTlAmt += dr_SAORDDTL_tmp_sorttable(i)("ttlamt")

        Next

        Return TTlAmt
    End Function

    Private Function InputIsValid() As Boolean
        Dim Err As String
        Dim isValid As Boolean
        isValid = True
        InputIsValid = True

        isValid = Valid_ChgQty()

        If isValid = True Then
            InputIsValid = True
        Else
            InputIsValid = False
        End If
    End Function

    Private Function Valid_ChgQty() As Boolean
        Valid_ChgQty = True
        Dim i As Integer

        For i = 0 To rs_SAORDDTL_tmp.Tables("RESULT").Rows.Count - 1
            If rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("gen") = "Y" Then
                If Convert.ToString(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_chgqty")) = "" Then
                    rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_chgqty") = 0
                End If

                If rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_outshqty") - rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_osdqty") < 0 Then
                    MsgBox("Exceed the outstanding Ship Qty = " & (Convert.ToString(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_outshqty"))))
                    Valid_ChgQty = False
                    Exit Function
                End If

                If rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_chgqty") > rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_outchgqty") Then
                    MsgBox("Exceed the outstanding Charge Qty " & (Convert.ToString(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_outchgqty"))))
                    Valid_ChgQty = False
                    Exit Function
                End If

                If rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_osdqty") = 0 Then
                    MsgBox("Shipped Qty cannot be 0")
                    Valid_ChgQty = False
                    Exit Function
                End If

                If CLng(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_chgqty")) > CLng(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_osdqty")) Then
                    MsgBox("Charge Qty should be smaller than or equal to Ship Qty")
                    Valid_ChgQty = False
                    Exit Function
                End If

                If CLng(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_osdqty")) <> _
                    (CLng(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_chgqty")) + _
                    CLng(rs_SAORDDTL_tmp.Tables("RESULT").Rows(i).Item("sas_shipfreqty"))) Then

                    MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
                    Valid_ChgQty = False
                    Exit Function
                End If
            End If
        Next

        'Dim curshippqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(Loc).Item(11)
        'Dim curchgqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(Loc).Item(12)
        'Dim outchgqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(Loc).Item(27)
        'Dim outshipqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(Loc).Item(28)

        'Dim curoutfreqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(Loc).Item(13)


        'rs_SAINVDTL.Tables("RESULT").Rows(current_row).Item("sid_chgqty") = txtChgQty.Text

        'txtBalFreQty.Text = CLng(txtShpQty.Text) - CLng(txtChgQty.Text)
        'rs_SAINVDTL.Tables("RESULT").Rows(current_row).Item("sid_balfreqty") = txtBalFreQty.Text

        'txtTtlAmtD.Text = round(CDbl(txtSelPrcD.Text) * CDbl(txtChgQty.Text), 4)
        'rs_SAINVDTL.Tables("RESULT").Rows(current_row).Item("sid_ttlamt") = txtTtlAmtD.Text

        'If CLng(txtShpQty.Text) <> (CLng(txtChgQty.Text) + CLng(txtBalFreQty.Text)) Then
        '    MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
        '    If txtShpQty.Enabled Then
        '        txtShpQty.Focus()
        '    End If
        '    txtShpQty.SelectionStart = 0
        '    txtShpQty.SelectionLength = Len(txtShpQty.Text)
        '    Valid_ChgQty = False
        '    Exit Function
        'End If

        'If CLng(txtChgQty.Text) > CLng(txtShpQty.Text) Then
        '    MsgBox("Charge Qty should be smaller than or equal to Ship Qty")
        '    If txtChgQty.Enabled Then
        '        txtChgQty.Focus()
        '    End If
        '    txtChgQty.SelectionStart = 0
        '    txtChgQty.SelectionLength = Len(txtChgQty.Text)
        '    Valid_ChgQty = False
        '    Exit Function
        'End If

        'For i As Integer = 0 To rs_SAINVDTL.Tables("RESULT").Columns.Count - 1
        '    rs_SAINVDTL.Tables("RESULT").Columns(i).ReadOnly = False
        'Next
        'If txtShpQty.Text = 0 Then
        '    If txtChgQty.Text = 0 Then
        '        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_chgqty") = 0
        '        txtBalFreQty.Text = 0
        '        rs_SAINVDTL.Tables("RESULT").Rows(current_Row).Item("sid_balfreqty") = 0
        '        Valid_ChgQty = False
        '        Exit Function
        '    End If
        'End If

        'Dim tmpshpqty As Long
        'Dim tmpchgqty As Long
        'Dim tmpbalfreqty As Long

        'tmpshpqty = CLng(txtOutShpQty.Text)
        'tmpchgqty = CLng(txtOutChgQty.Text) '+ CLng(txtOutFreQty.Text)
        'tmpbalfreqty = CLng(txtOutFreQty.Text) ' + CLng(txtOutChgQty.Text)

        'Dim Bkmark As Integer
        'Dim rs As New ADOR.Recordset
        'rs = CopyRS(rs_SAINVDTL)
        'If rs.RecordCount > 0 Then
        '    Bkmark = rs.AbsolutePosition
        '    rs.MoveFirst()
        '    While Not rs.EOF
        '        If rs("sid_itmcol") = cboItmCol.Text Then
        '            If rs.AbsolutePosition <> Bkmark Then
        '                If rs("sid_creusr") <> "~*DEL*~" And rs("sid_creusr") <> "~*NEW*~" Then
        '                    tmpshpqty = tmpshpqty - (rs("sid_shpqty") - rs("sid_orgshpqty"))
        '                    tmpchgqty = tmpchgqty - (rs("sid_chgqty") - rs("sid_orgchgqty")) + (rs("sid_balfreqty") - rs("sid_orgfreqty"))
        '                    tmpbalfreqty = tmpbalfreqty - (rs("sid_balfreqty") - rs("sid_orgfreqty")) + (rs("sid_chgqty") - rs("sid_orgchgqty"))
        '                End If
        '            End If
        '        End If
        '        rs.MoveNext()
        '    End While
        '    rs.Close()
        'End If

        'Dim rs As DataSet = rs_SAINVDTL.Copy
        'If rs.Tables("RESULT").Rows.Count > 0 Then
        '    For i As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
        '        If rs.Tables("RESULT").Rows(i).Item("sid_itmcol") = cboItmCol.Text Then
        '            If i = current_Row Then
        '                If rs.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*DEL*~" And rs.Tables("RESULT").Rows(i).Item("sid_creusr") <> "~*NEW*~" Then
        '                    tmpshpqty = tmpshpqty - (rs.Tables("RESULT").Rows(i).Item("sid_shpqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgshpqty"))
        '                    tmpchgqty = tmpchgqty - (rs.Tables("RESULT").Rows(i).Item("sid_chgqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgchgqty")) + (rs.Tables("RESULT").Rows(i).Item("sid_balfreqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgfreqty"))
        '                    tmpbalfreqty = tmpbalfreqty - (rs.Tables("RESULT").Rows(i).Item("sid_balfreqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgfreqty")) + (rs.Tables("RESULT").Rows(i).Item("sid_chgqty") - rs.Tables("RESULT").Rows(i).Item("sid_orgchgqty"))
        '                End If
        '            End If
        '        End If
        '    Next
        'End If


        'If tmpchgqty < (CLng(txtChgQty.Text) - CLng(txtOrgChgQty.Text)) Then
        '    MsgBox "Exceed the outstanding Charge Qty " & tmpchgqty + CLng(txtOrgChgQty.Text)
        '    txtChgQty.SetFocus
        '    txtChgQty.SelStart = 0
        '    txtChgQty.SelLength = Len(txtChgQty.Text)
        '    Valid_ChgQty = False
        '    Exit Function
        'End If





        'If CLng(txtBalFreQty.Text) > (tmpbalfreqty + CLng(txtOrgFreQty.Text)) Then
        '    'MsgBox "Free Qty should be smaller than or equal to " & (tmpbalfreqty + CLng(txtOrgFreQty.Text))
        '    'MsgBox "Invoice will be held for approval"

        '    'txtChgQty.Text = 0
        '    'rs_SAINVDTL("sid_chgqty") = 0

        '    'txtBalFreQty.Text = 0
        '    'rs_SAINVDTL("sid_balfreqty") = 0

        '    'txtShpQty.SetFocus
        '    'txtShpQty.SelStart = 0
        '    'txtShpQty.SelLength = Len(txtShpQty.Text)
        'End If
    End Function


    Private Sub grdDetailSet_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellClick
        If e.ColumnIndex = 0 Then

            If (e.RowIndex = -1) Then
                Exit Sub
            End If

            Dim currentvalue As String
            currentvalue = grdDetailSet.CurrentCell.Value

            If Trim(currentvalue) = "N" Then
                grdDetailSet.Item(0, grdDetailSet.CurrentCell.RowIndex).Value = "Y"
            Else
                grdDetailSet.Item(0, grdDetailSet.CurrentCell.RowIndex).Value = "N"
            End If




        End If
    End Sub

    Private Sub grdDetailSet_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellContentClick

    End Sub

    Private Sub grdDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellEndEdit
        Dim tmpseq As String
        Dim curseq As String
        tmpseq = ""
        curseq = grdDetail.Item(3, e.RowIndex).Value

        Dim i As Integer
        Dim loc As Integer

        loc = -1

        For i = 0 To rs_SAORDDTL.Tables("RESULT").Rows.Count - 1
            tmpseq = rs_SAORDDTL.Tables("RESULT").Rows(i).Item("sad_seqno")
            If tmpseq = curseq Then
                loc = i
                Exit For
            End If
        Next i

        If loc = -1 Then
            Exit Sub
        End If


        EndEditcalculateDetailFreeQtyField(rs_SAORDDTL, loc)


        Dim curshippqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(11)
        Dim curchgqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(12)
        Dim outchgqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(27)
        Dim outshipqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(28)

        Dim curoutfreqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13)
        Dim newcuroutfreqty As Integer = curshippqty - curchgqty

        If newcuroutfreqty < 0 Then
            rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13) = 0
        Else
            rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13) = newcuroutfreqty
        End If



        Dim outfreqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13)




        ' rs_SAORDDTL .Tables ("RESULT").Rows(loc).Item = 
        If e.ColumnIndex = 11 Then
            If outshipqty - curshippqty < 0 Then
                MsgBox("Exceed the outstanding Ship Qty = " & (Convert.ToString(outshipqty)))
                ' rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(11) = 0
                Exit Sub
            End If
        ElseIf e.ColumnIndex = 12 Then

            If curchgqty > outchgqty Then
                MsgBox("Exceed the outstanding Charge Qty " & curchgqty)
                Exit Sub
            End If

            If curchgqty > curshippqty Then
                MsgBox("Charge Qty should be smaller than or equal to Ship Qty")
                Exit Sub
            End If

        End If


        If curshippqty <> curchgqty + outfreqty Then
            MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
            '  rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(11) = 0
            '  rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(12) = 0
            Exit Sub
        End If


    End Sub

    Private Sub grdDetail_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellLeave

        If Not (txtbox Is Nothing) Then
            RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
        End If

    End Sub

    Private Sub txtBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)



        If Not (e.KeyChar = vbBack Or e.KeyChar = ChrW(Keys.Delete) Or e.KeyChar = ChrW(Keys.Enter) Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If



    End Sub

    Private Sub grdDetail_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellValidated




    End Sub

    Private Sub grdDetail_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDetail.EditingControlShowing
        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            txtbox.MaxLength = 4
            AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress

        End If
    End Sub

    Private Sub grdDetailSet_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellEndEdit
        Dim tmpqut As String
        Dim tmpseq As String
        Dim curqut As String
        Dim curseq As String
        tmpqut = ""
        tmpseq = ""

        curqut = grdDetailSet.Item(36, e.RowIndex).Value
        curseq = grdDetailSet.Item(3, e.RowIndex).Value

        Dim i As Integer
        Dim loc As Integer

        loc = -1

        For i = 0 To rs_SAORDDTL_SET.Tables("RESULT").Rows.Count - 1
            tmpqut = rs_SAORDDTL_SET.Tables("RESULT").Rows(i).Item("quh_qutno")
            tmpseq = rs_SAORDDTL_SET.Tables("RESULT").Rows(i).Item("sad_seqno")
            If tmpqut = curqut And tmpseq = curseq Then
                loc = i
                Exit For
            End If
        Next i

        If loc = -1 Then
            Exit Sub
        End If

        EndEditcalculateDetailFreeQtyField(rs_SAORDDTL_SET, loc)


        Dim curshippqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(11)
        Dim curchgqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(12)
        Dim outchgqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(27)
        Dim outshipqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(28)

        Dim curoutfreqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13)
        Dim newcuroutfreqty As Integer = curshippqty - curchgqty

        If newcuroutfreqty < 0 Then
            rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13) = 0
        Else
            rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13) = newcuroutfreqty
        End If



        Dim outfreqty As Integer = rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(13)




        ' rs_SAORDDTL .Tables ("RESULT").Rows(loc).Item = 
        If e.ColumnIndex = 11 Then
            If outshipqty - curshippqty < 0 Then
                MsgBox("Exceed the outstanding Ship Qty = " & (Convert.ToString(outshipqty)))
                ' rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(11) = 0
                Exit Sub
            End If
        ElseIf e.ColumnIndex = 12 Then

            If curchgqty > outchgqty Then
                MsgBox("Exceed the outstanding Charge Qty " & curchgqty)
                Exit Sub
            End If

            If curchgqty > curshippqty Then
                MsgBox("Charge Qty should be smaller than or equal to Ship Qty")
                Exit Sub
            End If

        End If


        If curshippqty <> curchgqty + outfreqty Then
            MsgBox("Ship Qty should be equal to Charge Qty + Free Qty!")
            '  rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(11) = 0
            '  rs_SAORDDTL.Tables("RESULT").Rows(loc).Item(12) = 0
            Exit Sub
        End If
    End Sub

    Private Sub grdDetailSet_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetailSet.CellLeave
        If Not (txtbox Is Nothing) Then
            RemoveHandler txtbox.KeyPress, AddressOf txtBox_KeyPress
        End If

    End Sub

    Private Sub grdDetailSet_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDetailSet.EditingControlShowing
        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            txtbox.MaxLength = 4
            AddHandler txtbox.KeyPress, AddressOf txtBox_KeyPress

        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        Me.grdDetailSet.DataSource = Nothing
        Me.grdDetailSet.Enabled = False
        Me.grdDetail.DataSource = Nothing
        Me.grdDetail.Enabled = False
        rs_SAORDDTL_SET = Nothing
        rs_SAORDDTL_SET_tmp = Nothing
        rs_SAORDDTL_SET = Nothing
        rs_SAORDDTL_tmp = Nothing
        'txtReqNoSet.Text = ""
        Call cmdClear_Click(sender, e)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtQutNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQutNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click_1(sender, e)
        End If
    End Sub

    Private Sub txtQutNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQutNo.TextChanged
      
    End Sub
End Class