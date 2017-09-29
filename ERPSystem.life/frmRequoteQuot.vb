Public Class frmRequoteQuot
    Public ma As QUM00001   'QUM0001 object, init in QUM00001, **must provide**

    'DataSet
    Dim rs_QUOTDTL_REQ As DataSet
    Dim rs_IMPRCINF As DataSet
    Dim rs_IMCOLINF As DataSet


    'DataTable
    Dim tbl_QUOTNDTL_REQ As DataTable
    Dim tbl_QUOTNDTL As DataTable
    Dim tbl_QUOTNHDR As DataTable

    'ComboCell Collection
    Dim Packing_hash As New Hashtable
    Dim Color_hash As New HashTable


    Public Quotno As String

    Dim PriCust As String
    Dim SecCust As String

    Public crit_stage As Integer
    Public crit_message As String
    Public crit_quit As Boolean


    Private Sub frmRequoteQuot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        tbl_QUOTNDTL = ma.rs_QUOTNDTL.Tables("RESULT")
        tbl_QUOTNHDR = ma.rs_QUOTNHDR.Tables("RESULT")

        If tbl_QUOTNDTL.Rows.Count = 0 Then
            MsgBox("No Records in this QUOTNDL")
            ExitForm()
        Else
            If Split(tbl_QUOTNHDR.Rows(0).Item("quh_qutsts"), " - ")(0) <> "R" Then
                MsgBox("No Items need to requote")
                ExitForm()
            End If
        End If

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Quotno = Trim(ma.txtQutNo.Text)
        PriCust = ""
        SecCust = ""

        PriCust = Trim(Split(ma.cboCus1No.Text, "-")(0))
        SecCust = If(Trim(Split(ma.cboCus2No.Text, "-")(0)) = "", "", Trim(Split(ma.cboCus2No.Text, "-")(0)))

        gspStr = "sp_list_QUOTNDTL_REQitm '" & gsCompany & "','" & Quotno & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QUOTDTL_REQ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_QUOTNDTL_REQitm DTL :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If


        Call showRequoteItm()


        Cursor = Cursors.Default
    End Sub

    Private Sub showRequoteItm()
        tbl_QUOTNDTL_REQ = rs_QUOTDTL_REQ.Tables("RESULT")

        For i As Integer = 0 To tbl_QUOTNDTL_REQ.Columns.Count - 1
            tbl_QUOTNDTL_REQ.Columns(i).ReadOnly = False

        Next

        For i As Integer = 0 To tbl_QUOTNDTL_REQ.Rows.Count - 1
            If tbl_QUOTNDTL_REQ.Rows(i).Item("Packing & Terms") = "" Then
                'Get ALL Possible Price
                gspStr = "sp_select_QUOTNDTL_REQitm '" & "Y" & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("Item No") & "','" & _
                    PriCust & "','" & _
                    SecCust & "'"
            Else
                'Get Maximum one Price 
                'not used now
                gspStr = "sp_select_QUOTNDTL_REQitm '" & "N" & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("Item No") & "','" & _
                    PriCust & "','" & _
                    SecCust & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("qud_untcde") & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("qud_inrqty") & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("qud_mtrqty") & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("qud_prctrm") & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("qud_ftyprctrm") & "','" & _
                    tbl_QUOTNDTL_REQ.Rows(i).Item("qud_trantrm") & "'"
            End If
            rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_select_QUOTNDTL_REQitm :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If

            'Filtering and set tbl_QUOTNDTL_REQ
            If rs_IMPRCINF.Tables("RESULT").Rows.Count = 0 Then
                tbl_QUOTNDTL_REQ.Rows(i).Item("IM Found") = "N"
                tbl_QUOTNDTL_REQ.Rows(i).Item("Message") = "Cannot find item with valid price in IM"
            Else
                tbl_QUOTNDTL_REQ.Rows(i).Item("IM Found") = "Y"
                tbl_QUOTNDTL_REQ.Rows(i).Item("Message") = ""


                'Set Packing
                If tbl_QUOTNDTL_REQ.Rows(i).Item("Packing & Terms") = "" Then
                    'createComboBoxCell(i, 3)
                    Dim list As New ArrayList
                    For j As Integer = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                        Dim tmp_itm As New itm_PRCINF
                        Dim tmp_row As DataRow = rs_IMPRCINF.Tables("RESULT").Rows(j)
                        tmp_itm.setVal(tmp_row.Item("imu_packing"), tmp_row.Item("imu_cus1no"), tmp_row.Item("imu_cus2no"))
                        list.Add(tmp_itm)
                        'createComboBoxCell(i, 3)
                    Next
                    Packing_hash.Add(i, list)
                Else
                    tbl_QUOTNDTL_REQ.Rows(i).Item("PriceKey (Pri)") = rs_IMPRCINF.Tables("RESULT").Rows(0).Item("imu_cus1no")
                    tbl_QUOTNDTL_REQ.Rows(i).Item("PriceKey (Sec)") = rs_IMPRCINF.Tables("RESULT").Rows(0).Item("imu_cus2no")
                End If

                'Set Color
                gspStr = "sp_select_IMCOLINF '" & "" & "','" & tbl_QUOTNDTL_REQ.Rows(i).Item("Item No") & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading sp_select_IMCOLINF :" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                If rs_IMCOLINF.Tables("RESULT").Rows.Count = 1 Then
                    tbl_QUOTNDTL_REQ.Rows(i).Item("Color") = rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_colcde")
                ElseIf rs_IMCOLINF.Tables("RESULT").Rows.Count > 1 Then
                    Dim list As New ArrayList
                    For j As Integer = 0 To rs_IMCOLINF.Tables("RESULT").Rows.Count - 1
                        Dim tmp_itm As New itm_COLINF
                        Dim tmp_row As DataRow = rs_IMCOLINF.Tables("RESULT").Rows(j)
                        tmp_itm.setCol(tmp_row.Item("icf_colcde"))
                        list.Add(tmp_itm)
                    Next
                    Color_hash.Add(i, list)
                End If
            End If


        Next

        'Set up DataGrid Cell Style
        SetupStyle_dgResult()

    End Sub



    Private Sub dgValid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellClick
        Dim row As Integer = dgResult.CurrentCell.RowIndex
        Dim col As Integer = dgResult.CurrentCell.ColumnIndex


        If col = 0 Then
            UpdateUPDval(row)
        ElseIf col = 4 Then
            createComboBoxCell(row, 4) 'Pack & Terms
        ElseIf col = 5 Then
            createComboBoxCell(row, 5) 'Color
        End If
    End Sub

    Private Sub createComboBoxCell(ByVal row As Integer, ByVal col As Integer)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim currentrow As ArrayList


        If col = 4 Then
            currentrow = Packing_hash.Item(row)
            If currentrow Is Nothing Then
                Exit Sub
            End If

            cboCell.Items.Add("")
            For i As Integer = 0 To currentrow.Count - 1 '.Tables("RESULT").Rows.Count - 1
                'cboCell.Items.Add(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_packing").ToString.Trim)
                cboCell.Items.Add(currentrow.Item(i).Packing)
            Next
        ElseIf col = 5 Then
            currentrow = Color_hash.Item(row)
            If currentrow Is Nothing Then
                Exit Sub
            End If
            For i As Integer = 0 To currentrow.Count - 1
                cboCell.Items.Add(currentrow.Item(i).Color)
            Next
        End If
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        dgResult.Rows(row).Cells(col) = cboCell
        dgResult.Rows(row).Cells(col).ReadOnly = False

    End Sub

    Private Sub dgResult_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgResult.EditingControlShowing
        If dgResult.CurrentCell.ColumnIndex = 4 Or dgResult.CurrentCell.ColumnIndex = 5 Then
            If TypeName(dgResult.CurrentCell) = "DataGridViewComboBoxCell" Then
                Dim combo As ComboBox
                combo = CType(e.Control, ComboBox)
                RemoveHandler combo.SelectedIndexChanged, New EventHandler(AddressOf Combo_SelectedIndexChange)
                AddHandler combo.SelectedIndexChanged, New EventHandler(AddressOf Combo_SelectedIndexChange)
            End If

        End If
    End Sub

    Private Sub Combo_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rownum = dgResult.CurrentCell.RowIndex
        Dim colnum = dgResult.CurrentCell.ColumnIndex
        Dim rowseq As Integer = getdgResult_SeqNum(rownum)
        Dim currentrow As ArrayList
        Dim selectindex As Integer = DirectCast(sender, ComboBox).SelectedIndex

        Dim cboBox As ComboBox = CType(sender, ComboBox)



        RemoveHandler cboBox.SelectedIndexChanged, AddressOf Combo_SelectedIndexChange
        If colnum = 4 Then
            currentrow = Packing_hash.Item(rownum)

            If currentrow Is Nothing Then
                Exit Sub
            End If

            If selectindex <> -1 Then
                ma.rs_QUOTNDTL.Tables("RESULT").Rows(rowseq - 1).RejectChanges()
                If selectindex = 0 Then
                    dgResult.Rows(rownum).Cells("Packing & Terms").Value = ""
                    dgResult.Rows(rownum).Cells("PriceKey (Pri)").Value = ""
                    dgResult.Rows(rownum).Cells("PriceKey (Sec)").Value = ""
                    dgResult.Rows(rownum).Cells("UPD").Value = "N"
                    'tbl_QUOTNDTL_REQ.Rows(rownum).Item("PriceKey (Pri)") = ""
                    'tbl_QUOTNDTL_REQ.Rows(rownum).Item("PriceKey (Sec)") = ""
                Else
                    dgResult.Rows(rownum).Cells("Packing & Terms").Value = currentrow.Item(selectindex - 1).Packing
                    dgResult.Rows(rownum).Cells("PriceKey (Pri)").Value = currentrow.Item(selectindex - 1).Pri_key
                    dgResult.Rows(rownum).Cells("PriceKey (Sec)").Value = currentrow.Item(selectindex - 1).Sec_key
                    dgResult.Rows(rownum).Cells("UPD").Value = "N"
                    UpdateUPDval(rownum)
                End If

                AddHandler cboBox.SelectedIndexChanged, AddressOf Combo_SelectedIndexChange
            End If
        ElseIf colnum = 5 Then
            currentrow = Color_hash.Item(rownum)
            If currentrow Is Nothing Then
                Exit Sub
            End If
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(rowseq - 1).RejectChanges()
            dgResult.Rows(rownum).Cells("Color").Value = currentrow.Item(selectindex).Color
        End If

    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        'Reject All Changes
        For i As Integer = 0 To ma.rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(i).RejectChanges()
        Next

        ma.Recordstatus = False

        ExitForm()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim result As Integer = MessageBox.Show("Are you sure to update?", "", MessageBoxButtons.YesNo)


        If result = DialogResult.Yes Then
            Dim tmp_cnt = 0

            If cmdUpdate_Check() = False Then
                Cursor = Cursors.Default
                Exit Sub
            End If

            ma.flag_frmRequote_crit = True

            Call ma.set_qutsts() 'Make sure quotation header show correct header

            ExitForm()
        End If
    End Sub

    'Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
    '    Cursor = Cursors.WaitCursor
    '    cmdUpdate.Enabled = False

    '    'Dim confirm_ret As Integer = MessageBox.Show("Press Yes to confirm update", "", MessageBoxButtons.YesNo)
    '    'If confirm_ret = DialogResult.No Then
    '    '    Exit Sub
    '    'End If

    '    If cmdUpdate_Check() = False Then
    '        Cursor = Cursors.Default
    '        cmdUpdate.Enabled = True
    '        Exit Sub
    '    End If


    '    'ma.flag_frmRequote_crit = True
    '    For i As Integer = 0 To dgResult.Rows.Count - 1
    '        'Need to handle tab problem and seq number problem
    '        Update_single_QUOTNDTL(i)
    '    Next

    '    'SAVE 
    '    'Call ma.cmdSaveClick()
    '    'ma.flag_frmRequote_crit = False

    '    Cursor = Cursors.Default
    '    ExitForm()
    'End Sub

    Private Function cmdUpdate_Check() As Boolean
        Dim count_UPD As Integer = 0

        cmdUpdate_Check = False
        dgResult.ClearSelection()

        For i As Integer = 0 To dgResult.Rows.Count - 1
            If dgResult.Rows(i).Cells("UPD").Value = "Y" Then
                count_UPD = count_UPD + 1
                If dgResult.Rows(i).Cells("Packing & Terms").Value = "" Then
                    MsgBox("Please select Packing & Terms of Seq " & dgResult.Rows(i).Cells("Seq").Value.ToString)
                    dgResult.Rows(i).Cells("Packing & Terms").Selected = True
                    Exit Function
                End If
                If dgResult.Rows(i).Cells("Color").Value = "" Then
                    MsgBox("Please select Color of Seq " & dgResult.Rows(i).Cells("Seq").Value.ToString)
                    dgResult.Rows(i).Cells("Color").Selected = True
                    Exit Function
                End If
            End If
        Next

        If count_UPD = 0 Then
            MsgBox("No Items need to update")
            Exit Function
        End If

        cmdUpdate_Check = True
    End Function


    Private Sub ExitForm()
        Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub SetupStyle_dgResult()
        dgResult.DataSource = tbl_QUOTNDTL_REQ.DefaultView
        For i As Integer = 0 To tbl_QUOTNDTL_REQ.Columns.Count - 1
            If i < 10 Then
                dgResult.Columns(i).Visible = True
                dgResult.Columns(i).ReadOnly = True
                dgResult.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Else
                dgResult.Columns(i).Visible = False
            End If
        Next

        With dgResult
            .Columns("UPD").Width = 40
            .Columns("Seq").Width = 40
            .Columns("Item No").Width = 110
            .Columns("Packing & Terms").Width = 170
            .Columns("Color").Width = 80
            .Columns("PriceKey (Pri)").Width = 90
            .Columns("PriceKey (Sec)").Width = 90
            .Columns("IM Found").Width = 60
            .Columns("Message").Width = 200
            .Columns("P&T(apps)").Width = 170
        End With
    End Sub

    Private Sub UpdateUPDval(ByVal row As Integer)
        If dgResult.Rows(row).Cells("Packing & Terms").Value Is DBNull.Value Then
            dgResult.Rows(row).Cells("Packing & Terms").Value = ""
        End If

        'UPD col index = 0
        If dgResult.Rows(row).Cells("UPD").Value = "N" Then
            If dgResult.Rows(row).Cells("IM Found").Value = "Y" And dgResult.Rows(row).Cells("Packing & Terms").Value <> "" And dgResult.Rows(row).Cells("Color").Value <> "" Then
                Cursor = Cursors.WaitCursor
                dgResult.Rows(row).Cells("UPD").Value = "Y"

                If Update_single_QUOTNDTL(row) = False Then
                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(getdgResult_SeqNum(row) - 1).RejectChanges()
                    MsgBox(crit_message)
                    dgResult.Rows(row).Cells("UPD").Value = "N"
                End If
                Cursor = Cursors.Default
            End If
        ElseIf dgResult.Rows(row).Cells(0).Value = "Y" Then
            dgResult.Rows(row).Cells("UPD").Value = "N"
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(getdgResult_SeqNum(row) - 1).RejectChanges()
        End If
    End Sub


    Private Function Update_single_QUOTNDTL(ByVal row As Integer) As Boolean
        Update_single_QUOTNDTL = False
        If Update_single_QUOTNDTL_CHECK(row) = False Then
            Cursor = Cursors.Default
            dgResult.Rows(row).Cells("UPD").Value = "N"
            Exit Function
        End If

        If dgResult.Rows(row).Cells("UPD").Value = "Y" Then
            'Reset critical info
            ma.flag_frmRequote_crit = True
            crit_stage = 0
            crit_message = ""
            crit_quit = False


            Dim cur_dgRow As DataGridViewRow = dgResult.Rows(row)
            Dim cur_itm As String = cur_dgRow.Cells("Item No").Value
            Dim cur_pckinfo As ArrayList = Packing_hash.Item(row)

            Dim cur_priprc As String = cur_dgRow.Cells("PriceKey (Pri)").Value
            Dim cur_secprc As String = cur_dgRow.Cells("PriceKey (Sec)").Value

            Dim cur_dgpck As String = cur_dgRow.Cells("Packing & Terms").Value
            Dim cur_unit As String = cur_dgpck.Split("/")(0)
            Dim cur_inrqty As Integer = cur_dgpck.Split("/")(1)
            Dim cur_mtrqty As Integer = cur_dgpck.Split("/")(2)

            Dim cur_col As String = cur_dgRow.Cells("Color").Value

            Dim QUOTNDTL_seq As Integer = getdgResult_SeqNum(row) 'ma.sReadingIndexQ
            ma.sReadingIndexQ = (QUOTNDTL_seq - 1).ToString


            'Critical moment Start

            ma.insert_QUOTNDTL(False)
            ma.display_Detail(QUOTNDTL_seq.ToString)

            ma.reset_detail_control("Detail_Init", "All")
            ma.reset_detail_data("Detail_Init", "All")

            ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_creusr") = "~*UPD*~" 'ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_creusr")

            ma.txtItmNoReal.Text = cur_itm
            ma.txtItmNo.Text = cur_itm
            ma.txtItmNo_Press()

            ma.fill_QUOTNDTL()


            'Get and Set the correct packing
            Dim tmp_arrpck() As DataRow = ma.rs_IMPRCINF_NewAddItem.Tables("RESULT").Select("imu_pckunt='" & cur_unit & "' AND imu_inrqty=" & cur_inrqty & " AND imu_mtrqty=" & cur_mtrqty & " AND imu_cus1no='" & cur_priprc & "' AND imu_cus2no='" & cur_secprc & "'")
            Dim tmp_pck As DataRow
            If tmp_arrpck.Length = 0 Then
                MsgBox("No packing found")
                'omg need to handle
            Else
                tmp_pck = tmp_arrpck(0)
            End If


            If ma.cboPcking.SelectedIndex <> ma.rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows.IndexOf(tmp_pck) Then
                ma.cboPcking.SelectedIndex = ma.rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows.IndexOf(tmp_pck) 'Will trigger cboPcking_SelectedIndexChange event in QUM00001
                If crit_stage >= 3 Then
                    Exit Function
                End If
            Else
                If crit_stage > 0 Then
                    Exit Function
                End If
            End If

            'Get and Set the correct color
            Dim tmp_arrcol() As DataRow = ma.rs_IMCOLINF.Tables("RESULT").Select("icf_colcde='" & cur_col & "'")
            Dim tmp_col As DataRow
            If tmp_arrcol.Length = 0 Then
                MsgBox("No Color found")
                'omg need to handle
            Else
                tmp_col = tmp_arrcol(0)
            End If
            ma.cboColCde.SelectedIndex = ma.rs_IMCOLINF.Tables("RESULT").Rows.IndexOf(tmp_col) 'Will trigger cboColCde_SelectedIndexChanged event in QUM00001


            ma.flag_frmRequote_crit = False
            'ma.rs_QUOTNHDR.Tables("RESULT").Rows(0)("quh_qutsts") = "R"
            'Critical moment End
        End If

        'Need to handle if somethings happens in Requote
        'Need a flag to represent if error happens in QUOTNDTL.vb
        'Fallback to QUOTNDTL backup and set a UPD to "F"

        Update_single_QUOTNDTL = True


    End Function

    Private Function Update_single_QUOTNDTL_CHECK(ByVal row As Integer)

        Update_single_QUOTNDTL_CHECK = False
        dgResult.ClearSelection()


        If dgResult.Rows(row).Cells("UPD").Value = "Y" Then

            If dgResult.Rows(row).Cells("Packing & Terms").Value = "" Then
                MsgBox("Please select Packing & Terms of Seq " & dgResult.Rows(row).Cells("Seq").Value.ToString)
                dgResult.Rows(row).Cells("Packing & Terms").Selected = True
                Exit Function
            End If
            If dgResult.Rows(row).Cells("Color").Value = "" Then
                MsgBox("Please select Color of Seq " & dgResult.Rows(row).Cells("Seq").Value.ToString)
                dgResult.Rows(row).Cells("Color").Selected = True
                Exit Function
            End If
        End If

        Update_single_QUOTNDTL_CHECK = True
    End Function

    Private Function getdgResult_SeqNum(ByVal row As Integer) As Integer
        Dim seq As Integer = dgResult.Rows(row).Cells("Seq").Value.ToString
        Return seq
    End Function



    Private Class itm_PRCINF
        Public Packing As String
        Public Pri_key As String
        Public Sec_key As String

        Public Sub setVal(ByVal _Packing, ByVal _key1, ByVal _key2)
            Packing = _Packing
            Pri_key = _key1
            Sec_key = _key2
        End Sub

    End Class

    Private Class itm_COLINF
        Public Color As String
        Public Sub setCol(ByVal _Color)
            Color = _Color
        End Sub
    End Class




End Class
