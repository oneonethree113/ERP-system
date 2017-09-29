Public Class SYM00030
    Dim flg_firstenter As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim ds_pricust As New DataSet
    Dim ds_seccust As New DataSet
    Dim ds_deftype As New DataSet
    Dim ds_defvalue As New DataSet

    Dim dt_pricust As New DataTable
    Dim dt_seccust As New DataTable

    Dim bindsrcS As New BindingSource
    Dim bindsrcI As New BindingSource
    Dim bindsrcP As New BindingSource
    Dim bindsrcL As New BindingSource

    Dim bindsrcUSV As New BindingSource

    Dim pri_cust As String
    Dim sec_cust As String
    Dim cust_mode As String
    Dim field_len As Integer

    Dim current_module As String = "Shipping"
    Dim gll_index As Integer


    Private Sub SYM00030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Formstartup(Me.Name)
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right


            cbo_fielddesc.Items.Clear()
            cbo_fielddesc.Items.Add("Header Respective PO #")
            cbo_fielddesc.Items.Add("Header Customer PO#")
            cbo_fielddesc.Items.Add("Detail Customer Item Number")
            cbo_fielddesc.Items.Add("Detail Cust SKU#")



            Call setStatus("Init")
            If (gsUsrID = "mis") Then
                chk_globalview.Visible = True
                Call chk_globalview_CheckedChanged(Nothing, Nothing)
            End If

            If flg_firstenter Then
                'Load Primary and Secondary customer list
                gspStr = "sp_list_CUBASINF '" & gsCompany & "','" & "PA" & "'"
                rtnLong = execute_SQLStatement(gspStr, ds_pricust, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00030 sp_list_CUBASINF : " & rtnStr & vbCrLf & "gspStr: " & gspStr)
                End If
                gspStr = "sp_list_CUBASINF '" & gsCompany & "','" & "P" & "'"
                rtnLong = execute_SQLStatement(gspStr, ds_seccust, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00030 sp_list_CUBASINF : " & rtnStr & vbCrLf & "gspStr: " & gspStr)
                End If

                'Load DefType
                gspStr = "sp_select_SHRMKTYP ''"
                rtnLong = execute_SQLStatement(gspStr, ds_deftype, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00030 sp_select_SHRMKTYP : " & rtnStr & vbCrLf & "gspStr: " & gspStr)
                End If

                dt_pricust = ds_pricust.Tables("RESULT")
                dt_seccust = ds_seccust.Tables("RESULT")

                flg_firstenter = False
            End If


        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    'Button Control
    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Dim tmp_text As String

        pri_cust = Txt_PriCustno.Text
        sec_cust = Txt_SecCustno.Text
        cust_mode = ""
        RemoveHandler Txt_PriCustno.KeyUp, AddressOf Txt_Custno_KeyPress
        RemoveHandler Txt_SecCustno.KeyUp, AddressOf Txt_Custno_KeyPress
        TabControl1.SelectedIndex = 0

        Try
            'Do checking Start
            If chk_globalview.Checked Then
                cust_mode = "G"
            ElseIf pri_cust = "" And sec_cust = "" Then
                MsgBox("Primary Customer No. and Secondary Customer No. cannot be both empty")
                Exit Sub
            ElseIf pri_cust <> "" And sec_cust = "" Then
                If dt_pricust.Select("cbi_cusno = '" + pri_cust + "'").Length = 0 Then
                    MsgBox("This is not a valid Primary Customer No.")
                    Exit Sub
                Else
                    cust_mode = "P"
                    tmp_text = Txt_PriCustno.Text + " - " + dt_pricust.Select("cbi_cusno = '" + pri_cust + "'")(0).Item("cbi_cussna").ToString
                    Txt_PriCustno.Text = tmp_text
                End If
            ElseIf pri_cust = "" And sec_cust <> "" Then
                If dt_seccust.Select("cbi_cusno = '" + sec_cust + "'").Length = 0 Then
                    MsgBox("This is not a valid Secondary Customer No.")
                    Exit Sub
                Else
                    cust_mode = "S"
                    tmp_text = Txt_SecCustno.Text + " - " + dt_seccust.Select("cbi_cusno = '" + sec_cust + "'")(0).Item("cbi_cussna").ToString
                    Txt_SecCustno.Text = tmp_text
                End If
            ElseIf pri_cust <> "" And sec_cust <> "" Then
                If dt_pricust.Select("cbi_cusno = '" + pri_cust + "'").Length = 0 Then
                    MsgBox("This is not a valid Primary Customer No.")
                    Exit Sub
                ElseIf dt_seccust.Select("cbi_cusno = '" + sec_cust + "'").Length = 0 Then
                    MsgBox("This is not a valid Secondary Customer No.")
                    Exit Sub
                Else
                    cust_mode = "S"

                    tmp_text = Txt_PriCustno.Text + " - " + dt_pricust.Select("cbi_cusno = '" + pri_cust + "'")(0).Item("cbi_cussna").ToString
                    Txt_PriCustno.Text = tmp_text
                    tmp_text = Txt_SecCustno.Text + " - " + dt_seccust.Select("cbi_cusno = '" + sec_cust + "'")(0).Item("cbi_cussna").ToString
                    Txt_SecCustno.Text = tmp_text

                    pri_cust = ""
                End If
            End If
            'Do checking End
            If cust_mode <> "" Then
               mmdClear.Enabled = True
                mmdFind.Enabled = False
                Txt_PriCustno.Enabled = False
                Txt_SecCustno.Enabled = False
                chk_globalview.Enabled = False
                'Showing GridView
                Call ShowTabDtl()
                Call Set_ds_defvalue()
            End If

        Finally
            AddHandler Txt_PriCustno.KeyUp, AddressOf Txt_Custno_KeyPress
            AddHandler Txt_SecCustno.KeyUp, AddressOf Txt_Custno_KeyPress
        End Try


    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        dg_usv.DataSource = Nothing
        Call resume_custno()

        Call SYM00030_Load(Nothing, Nothing)
    End Sub


    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Dim flgErr As Boolean = False
        Dim flgSave As Boolean = True
        Dim local_default As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            dg_usv.Update()

            For Each dr As DataRow In ds_defvalue.Tables("Result").Rows
                gspStr = ""
                If dr.RowState = DataRowState.Modified Then
                    If dr.Item("Del").ToString = "Y" Then
                        gspStr = "sp_physical_delete_SHRMKVAL '" & dr.Item("hrt_typ").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_mod").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_rmkcde").ToString.Replace("'", "''").Trim & "'," & _
                                dr.Item("hrt_rmkid") & ",'" & _
                                dr.Item("hrt_pricustno") & "','" & _
                                dr.Item("hrt_seccustno") & "'"
                    Else
                        'local_default = If(dr.Item("isDefault").ToString = "Y", "1", "0")

                        gspStr = "sp_update_SHRMKVAL '" & dr.Item("hrt_typ").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_mod").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_rmkcde").ToString.Replace("'", "''").Trim & "'," & _
                                dr.Item("hrt_rmkid") & ",'" & _
                                dr.Item("hrt_rmkval").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_rmkdsc").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_flgdef").ToString & "','" & _
                                dr.Item("hrt_pricustno") & "','" & _
                                dr.Item("hrt_seccustno") & "','" & _
                                gsUsrID & "'"

                    End If

                ElseIf dr.RowState = DataRowState.Added And Not dr.Item(9).ToString = "Y" Then
                    'local_default = If(dr.Item("isDefault").ToString = "Y", "1", "0")

                    gspStr = "sp_insert_SHRMKVAL '" & dr.Item("hrt_typ").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_mod").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_rmkcde").ToString.Replace("'", "''").Trim & "'," & _
                                dr.Item("hrt_rmkid") & ",'" & _
                                dr.Item("hrt_rmkval").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_rmkdsc").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("hrt_flgdef").ToString & "','" & _
                                dr.Item("hrt_pricustno") & "','" & _
                                dr.Item("hrt_seccustno") & "','" & _
                                gsUsrID & "'"

                End If

                If gspStr <> "" Then
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYM00030 sql. " & vbCrLf & "gspStr: " & gspStr & vbCrLf & rtnStr)
                        flgErr = True
                        Exit For
                    End If
                    gspStr = ""
                End If

                If dr.RowState <> DataRowState.Added Then
                    lblRight.Text = Format(dr.Item("hrt_credat").ToString, "MM/dd/yyyy") & " " & Format(dr.Item("hrt_upddat").ToString, "MM/dd/yyyy") & " " & dr.Item("hrt_updusr").ToString
                Else
                    lblRight.Text = ""
                End If
            Next

            If Not flgErr Then
                ds_defvalue.AcceptChanges()
                Call resume_custno()
                Call setStatus("Save")

            Else
                ds_defvalue.RejectChanges()
                MsgBox("Record Not Updated!")
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    
    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Call Show_mypanel("insert")

    End Sub

    'Button Control End

    Private Sub setStatus(ByVal mode As String)
        If mode = "Init" Then

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = True
            mmdExit.Enabled = True
            mmdClear.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False


            chk_globalview.Enabled = True

            Txt_PriCustno.Enabled = True
            Txt_SecCustno.Enabled = True
            pri_cust = ""
            sec_cust = ""
            txt_valuepreview.Clear()

            dg_invoice.DataSource = Nothing
            dg_shipping.DataSource = Nothing
            dg_label.DataSource = Nothing
            dg_packing.DataSource = Nothing

            dg_usv.DataSource = Nothing
        ElseIf mode = "Edit" Then
            mmdInsRow.Enabled = True
            mmdSave.Enabled = True
        ElseIf mode = "EditCancel" Then
            mmdInsRow.Enabled = False
        ElseIf mode = "EditPanel" Then
            TabControl1.Enabled = False
            mmdSave.Enabled = False
            mmdClear.Enabled = False
            mmdInsRow.Enabled = False
        ElseIf mode = "LeaveEditPanel" Then
            TabControl1.Enabled = True
           mmdSave.Enabled = True
            mmdClear.Enabled = True
            mmdInsRow.Enabled = True
        ElseIf mode = "Save" Then
            MsgBox("Record Saved!")
            Call SYM00030_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub ShowTabDtl()
        For Each tmp_tab As TabPage In TabControl1.TabPages
            If tmp_tab.Text = "Shipping" Then
                ShowGrdDtl(tmp_tab.Text, bindsrcS, dg_shipping)
            ElseIf tmp_tab.Text = "Invoice" Then
                ShowGrdDtl(tmp_tab.Text, bindsrcI, dg_invoice)
            ElseIf tmp_tab.Text = "Packing" Then
                ShowGrdDtl(tmp_tab.Text, bindsrcP, dg_packing)
            ElseIf tmp_tab.Text = "Label" Then
                ShowGrdDtl(tmp_tab.Text, bindsrcL, dg_label)
            End If

        Next
    End Sub

    Private Sub ShowGrdDtl(ByVal module_name As String, ByVal bindSrc As BindingSource, ByVal dgView As DataGridView)
        Dim tmp_dv As DataView
        Dim tmp_table As DataTable
        tmp_table = ds_deftype.Tables("Result").Copy

        tmp_dv = tmp_table.DefaultView
        tmp_dv.RowFilter = "hrt_mod = '" + module_name + "'"

        bindSrc.DataSource = tmp_dv
        With dgView
            .DataSource = Nothing
            .DataSource = bindSrc
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 2
                        .Columns(i).Width = 160
                        .Columns(i).HeaderText = "Field Name"
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With
    End Sub

    Private Sub ShowGridusv(ByVal field As String)
        Dim dv As DataView = ds_defvalue.Tables("Result").DefaultView
        dv.RowFilter = "hrt_rmkcde = '" + field + "' AND hrt_mod = '" + current_module + "'"

        bindsrcUSV.DataSource = dv
        With dg_usv
            .DataSource = Nothing
            .DataSource = bindsrcUSV
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    'Case 0
                    '    .Columns(i).Width = 50
                    '    .Columns(i).HeaderText = "Type"
                    '    .Columns(i).DisplayIndex = 1
                    '    .Columns(i).ReadOnly = True
                    'Case 4
                    '    .Columns(i).Width = 200
                    '    .Columns(i).HeaderText = "Field Value"
                    '    .Columns(i).DisplayIndex = 1
                    '    .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).Width = 530
                        .Columns(i).HeaderText = "Description"
                        .Columns(i).DisplayIndex = 1
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).Width = 50
                        .Columns(i).HeaderText = "Default"
                        .Columns(i).DisplayIndex = 2
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 13
                        .Columns(i).Width = 50
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).DisplayIndex = 0
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        'Case 14
                        '    .Columns(i).Width = 50
                        '    .Columns(i).HeaderText = "Default"
                        '    .Columns(i).DisplayIndex = 4
                        '    .Columns(i).ReadOnly = True
                        '    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else

                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        End With

        'If dv.Count <> 0 Then
        '    Dim default_row As Integer = get_default_row(dv)
        '    If default_row <> -1 Then
        '        dv.Item(default_row).Item(14) = "Y"
        '    End If

        'End If


        'dg_usv.BeginEdit(True)
        'ds_defvalue.Tables("Result").Rows(0).Item(7) = "Y"
    End Sub

    Private Sub Show_mypanel(ByVal mode As String)
        mypanel.Visible = True

        If gll_index = 3 Then
            cbo_fielddesc.Visible = True
            cbo_fielddesc.Enabled = True
            txt_fielddesc.Visible = False
            txt_fielddesc.Enabled = False
        Else
            cbo_fielddesc.Visible = False
            cbo_fielddesc.Enabled = False
            txt_fielddesc.Visible = True
            txt_fielddesc.Enabled = True
        End If

        txt_fieldvalue.Clear()
        txt_fielddesc.Clear()
        Call setStatus("EditPanel")

        Dim current_row As DataGridViewRow = dg_usv.CurrentRow

        If mode = "insert" Then
            cmdPanConfim.Text = "Insert"
        ElseIf mode = "modify" Then
            cmdPanConfim.Text = "Update"
            txt_fieldvalue.Text = current_row.Cells(4).Value
            txt_fielddesc.Text = current_row.Cells(5).Value

        End If


    End Sub

    Private Sub Set_ds_defvalue()
        ds_defvalue.Reset()
        gspStr = "sp_select_SHRMKVAL '" & "','" & _
                    cust_mode & "','" & _
                    pri_cust & "','" & _
                    sec_cust & "'"
        rtnLong = execute_SQLStatement(gspStr, ds_defvalue, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00030 sp_select_CUS_DEFVALUE : " & rtnStr & vbCrLf & "gspStr: " & gspStr)
        End If

        Dim dt_defvalue As DataTable = ds_defvalue.Tables("Result")
        dt_defvalue.Columns.Add("Del", Type.GetType("System.String"))
        'dt_defvalue.Columns.Add("isDefault", Type.GetType("System.String"))


        If Not ds_defvalue.Tables("RESULT") Is Nothing Then
            For Each dc As DataColumn In ds_defvalue.Tables("RESULT").Columns
                dc.ReadOnly = False
            Next
            ds_defvalue.AcceptChanges()
        End If

    End Sub
    Private Sub DataGridLeft_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_shipping.MouseUp, dg_invoice.MouseUp, dg_packing.MouseUp, dg_label.MouseUp
        Dim hit As DataGridView.HitTestInfo = dg_shipping.HitTest(e.X, e.Y)
        '***** should sperate four case if other's no's of item is more than shipping
        Dim dgv As DataGridView = CType(sender, DataGridView)
        '******hit.Type = DataGridViewHitTestType.RowHeader
        If hit.Type = DataGridViewHitTestType.RowHeader Then
            Dim tmp_field As String = dgv.Rows(hit.RowIndex).Cells("hrt_rmkcde").Value
            'Dim tmp_field As String = "exporter_info"
            field_len = dgv.Rows(hit.RowIndex).Cells("hrt_rmklen").Value
            'field_len = 2000

            'Dim tmp_fieldname As String = dg_shipping.Rows(hit.RowIndex).Cells("field_name").Value
            ShowGridusv(tmp_field)
            setStatus("Edit")
        ElseIf hit.Type = DataGridViewHitTestType.None Then
            dg_usv.DataSource = Nothing
            dgv.ClearSelection()
            setStatus("EditCancel")
        Else
            dg_usv.DataSource = Nothing
            setStatus("EditCancel")
        End If

        txt_fieldvalue.Text = ""

    End Sub

    Private Sub Txt_Custno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PriCustno.KeyUp, Txt_SecCustno.KeyUp
        If e.KeyCode.Equals(Keys.Enter) Then
            Call mmdFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim tmp_index As Integer = CType(sender, TabControl).SelectedIndex
        gll_index = tmp_index
        current_module = CType(sender, TabControl).TabPages(tmp_index).Text

       mmdInsRow.Enabled = False

        dg_shipping.ClearSelection()
        dg_label.ClearSelection()
        dg_packing.ClearSelection()
        dg_invoice.ClearSelection()
        txt_valuepreview.Clear()
        setStatus("EditCancel")
        dg_usv.DataSource = Nothing

        'Call ShowTabDtl()

    End Sub

    Private Function get_default_row(ByVal dv As DataView) As Integer
        Dim is_default_row As Integer

        'Check type equal itself
        For i As Integer = 0 To dv.Count - 1
            If dv.Item(i).Item(0) = cust_mode Then
                If dv.Item(i).Item(6) = "Y" Then
                    is_default_row = i
                    Return is_default_row
                End If
            End If
        Next

        'does not find any default, return -1
        is_default_row = -1
        Return is_default_row

    End Function

    Private Sub dg_usv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_usv.CellClick
        Dim current_row As DataGridViewRow = dg_usv.CurrentRow
        txt_valuepreview.Text = ""
        If e.RowIndex <> -1 Then
            txt_valuepreview.Text = current_row.Cells(4).Value

            If current_row.Cells("hrt_credat").Value.Equals(DBNull.Value) Then
                lblRight.Text = ""
            Else
                lblRight.Text = Format(current_row.Cells("hrt_credat").Value, "MM/dd/yyyy") & " " & _
                Format(current_row.Cells("hrt_upddat").Value, "MM/dd/yyyy") & " " & _
                current_row.Cells("hrt_updusr").Value
            End If

            If e.ColumnIndex = 13 Then   'Del
                If current_row.Cells(e.ColumnIndex).Value.ToString = "" Then
                    current_row.Cells(e.ColumnIndex).Value = "Y"
                Else
                    current_row.Cells(e.ColumnIndex).Value = ""
                End If
            ElseIf e.ColumnIndex = 6 Then  'Default'
                If current_row.Cells(e.ColumnIndex).Value.ToString = "N" Then
                    For i As Integer = 0 To dg_usv.Rows.Count - 1
                        dg_usv.Rows(i).Cells(e.ColumnIndex).Value = "N"
                    Next
                    current_row.Cells(e.ColumnIndex).Value = "Y"
                Else
                    current_row.Cells(e.ColumnIndex).Value = "N"
                End If
            End If
        End If

    End Sub


    Private Sub dg_usv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_usv.CellDoubleClick
        Dim current_row As DataGridViewRow = dg_usv.CurrentRow

        If e.ColumnIndex = -1 And e.RowIndex <> -1 Then
            Call Show_mypanel("modify")
        End If
    End Sub

    Private Sub dg_usv_Mouseup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_usv.MouseUp
        Dim hit As DataGridView.HitTestInfo = dg_usv.HitTest(e.X, e.Y)

        If hit.Type = DataGridViewHitTestType.None Then
            txt_valuepreview.Text = ""
            dg_usv.ClearSelection()
        End If

    End Sub

    'Private Sub dg_usv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dg_usv.CellValidating
    '    Dim current_row As DataGridViewRow = dg_usv.CurrentRow
    '    Dim edit_value As String = current_row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

    '    If current_row.Cells(e.ColumnIndex).IsInEditMode Then
    '        If e.ColumnIndex = 3 Then
    '            For Each dr As DataGridViewRow In dg_usv.Rows
    '                If dr.Index <> e.RowIndex Then
    '                    If dr.Cells(3).Value = edit_value Then
    '                        MsgBox("Duplicate field value!")
    '                        e.Cancel = True
    '                        Exit For
    '                    End If
    '                End If
    '            Next
    '        End If
    '    End If
    'End Sub


    Private Sub cmdPanCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCancel.Click
        setStatus("LeaveEditPanel")
        mypanel.Visible = False
    End Sub


    Private Sub cmdPanins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanConfim.Click
        Dim dt As DataTable = ds_defvalue.Tables("Result")
        Dim dr As DataRow

        Dim current_field As String

        If (current_module = "Shipping") Then
            current_field = dg_shipping.CurrentRow.Cells("hrt_rmkcde").Value.ToString
        ElseIf (current_module = "Invoice") Then
            current_field = dg_invoice.CurrentRow.Cells("hrt_rmkcde").Value.ToString
        ElseIf (current_module = "Packing") Then
            current_field = dg_packing.CurrentRow.Cells("hrt_rmkcde").Value.ToString
        ElseIf (current_module = "Label") Then
            current_field = dg_label.CurrentRow.Cells("hrt_rmkcde").Value.ToString
        End If

        If txt_fieldvalue.TextLength > field_len Then
            MsgBox("Field Value Length cannot excced " + field_len.ToString + vbCrLf + "Insert/Update Fails!")
            Exit Sub
        End If


        If cmdPanConfim.Text = "Insert" Then
            Dim compute_string As String = "hrt_mod = '" + current_module + "' AND hrt_rmkcde = '" + current_field + "'"
            Dim curr_max_num As Integer = SYM00030_convertInteger(dt.Compute("max(hrt_rmkid)", compute_string))

            dr = dt.NewRow
            dr.Item("hrt_typ") = cust_mode
            dr.Item("hrt_mod") = current_module
            dr.Item("hrt_rmkcde") = current_field
            dr.Item("hrt_rmkid") = curr_max_num + 1
            dr.Item("hrt_rmkval") = txt_fieldvalue.Text
            dr.Item("hrt_rmkdsc") = txt_fielddesc.Text
            dr.Item("hrt_flgdef") = "N"
            dr.Item("hrt_pricustno") = pri_cust
            dr.Item("hrt_seccustno") = sec_cust

            dt.Rows.Add(dr)
            txt_valuepreview.Text = txt_fieldvalue.Text
        ElseIf cmdPanConfim.Text = "Update" Then
            Dim current_row As DataGridViewRow = dg_usv.CurrentRow
            Dim tmp_string As String = ""

            If txt_fieldvalue.Lines.Length <> 0 Then
                For i As Integer = 0 To txt_fieldvalue.Lines.Length - 1
                    If i = txt_fieldvalue.Lines.Length - 1 Then
                        tmp_string = tmp_string + txt_fieldvalue.Lines(i)
                    Else
                        tmp_string = tmp_string + txt_fieldvalue.Lines(i) + vbCrLf
                    End If
                Next
            End If
            current_row.Cells(4).Value = tmp_string
            current_row.Cells(5).Value = txt_fielddesc.Text
            txt_valuepreview.Text = current_row.Cells(4).Value

            bindsrcUSV.EndEdit()
        End If

        setStatus("LeaveEditPanel")
        mypanel.Visible = False

    End Sub
    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()
    End Sub



    Private Function SYM00030_convertInteger(ByVal intInteger As Object) As Integer
        If intInteger.Equals(DBNull.Value) Then
            Return -1
        End If
        Return intInteger
    End Function

    Private Sub chk_globalview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_globalview.CheckedChanged
        If chk_globalview.Checked Then
            Txt_PriCustno.Clear()
            Txt_SecCustno.Clear()
            Txt_PriCustno.Enabled = False
            Txt_SecCustno.Enabled = False
        Else
            Txt_PriCustno.Enabled = True
            Txt_SecCustno.Enabled = True
        End If
    End Sub

    Private Sub resume_custno()
        'Change custnomer full name to customer no only
        If cust_mode = "P" Then
            Txt_PriCustno.Text = pri_cust
            Txt_SecCustno.Text = ""
        ElseIf cust_mode = "S" Then
            Txt_PriCustno.Text = ""
            Txt_SecCustno.Text = sec_cust
        End If
    End Sub

    Private Sub cbo_fielddesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fielddesc.SelectedIndexChanged
        txt_fielddesc.Text = cbo_fielddesc.Text.Trim
    End Sub

    Private Sub dg_shipping_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_shipping.CellContentClick

    End Sub
End Class

