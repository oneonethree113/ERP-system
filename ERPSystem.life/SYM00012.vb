Public Class SYM00012
    Inherits System.Windows.Forms.Form

    Dim rs_syagtinf As New DataSet
    Dim rs_syagttir As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim Add_flag As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00012_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboAgent()
            Call FillComboCountry()
            Call FillComboComTerm()

            If Not rs_syagttir Is Nothing Then
                rs_syagttir = Nothing
            End If

            gspStr = "sp_select_SYAGTTIR '" & gsCompany & "',''"
            rtnLong = execute_SQLStatement(gspStr, rs_syagttir, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00012 sp_select_SYAGTTIR : " & rtnStr)
            Else
                For Each ctl As Control In Me.Controls
                    If TypeOf (ctl) Is TextBox Or TypeOf (ctl) Is MaskedTextBox Then
                        ctl.Text = ""
                    End If
                Next
                Add_flag = False
                Call setDataRowAttr()
                Call displayGrid()
                Call setStatus("Init")
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub displayGrid()
        Me.StatusBar.Items("lblRight").Text = ""

        Dim i As Integer
        Dim dv As DataView = rs_syagttir.Tables("RESULT").DefaultView
        bindSrc.DataSource = dv

        With DataGrid
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).Width = 250
                        .Columns(i).HeaderText = "Net Gross Margin From"
                    Case 5
                        .Columns(i).Width = 250
                        .Columns(i).HeaderText = "Net Gross Margin To"
                    Case 6
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "Rate %"
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "yat_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yat_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yat_upddat"), "MM/dd/yyyy") & " " & drv.Item("yat_updusr")

            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then


            mmdAdd.Enabled = Enq_right_local
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False


            txtAgtCde.Visible = False
            CboAgtCde.Visible = True
            CboAgtCde.Enabled = True

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "ADD" Then


            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdAdd.Enabled = False
            mmdFind.Enabled = False
            mmdCopy.Enabled = False
            mmdInsRow.Enabled = Enq_right_local


            txtAgtCde.Visible = True
            CboAgtCde.Visible = False
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then


            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            CboAgtCde.Enabled = False
            mmdAdd.Enabled = False

            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00012_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then

            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            CboAgtCde.Enabled = False

            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then


            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub

    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "InsRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Row"
        ElseIf mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf mode = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        ElseIf mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Record"
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.StatusBar.Items("lblLeft").Text = ""
    End Sub

    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_syagttir.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("yat_status") = ""
            Next
            rs_syagttir.AcceptChanges()
        End If
    End Sub

    Private Sub FillComboAgent()
        Dim rs_syagtcde As New DataSet

        Try
            gspStr = "sp_list_SYAGTINF '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syagtcde, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00012 sp_list_SYAGTINF : " & rtnStr)
            Else
                Me.CboAgtCde.Items.Clear()
                For Each dr As DataRow In rs_syagtcde.Tables("RESULT").Rows
                    Me.CboAgtCde.Items.Add(dr.Item("yai_agtcde").ToString)
                Next
            End If
        Finally
            rs_syagtcde = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboCountry()
        Dim rs_country As New DataSet

        Try
            gspStr = "sp_select_SYSETINF '" & gsCompany & "','02'"
            rtnLong = execute_SQLStatement(gspStr, rs_country, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00012 sp_select_SYSETINF : " & rtnStr)
            Else
                Me.CboCountry.Items.Clear()
                For Each dr As DataRow In rs_country.Tables("RESULT").Rows
                    Me.CboCountry.Items.Add(dr.Item("ysi_cde").ToString & " - " & dr.Item("ysi_dsc").ToString)
                Next
            End If
        Finally
            rs_country = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboComTerm()
        Dim rs_comtrm As New DataSet

        Try
            gspStr = "sp_select_SYSETINF '" & gsCompany & "','12'"
            rtnLong = execute_SQLStatement(gspStr, rs_comtrm, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00015 sp_list_SYSVNFOR : " & rtnStr)
            Else
                Me.CboCT.Items.Clear()
                For Each dr As DataRow In rs_comtrm.Tables("RESULT").Rows
                    Me.CboCT.Items.Add(dr.Item("ysi_cde").ToString & " - " & dr.Item("ysi_dsc").ToString)
                Next
            End If
        Finally
            rs_comtrm = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub CboAgtCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAgtCde.SelectedIndexChanged
        If Not CboAgtCde.SelectedItem Is Nothing Then
            Call ShowAgtDtl()
        End If
    End Sub

    Private Sub txtAgtCde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAgtCde.LostFocus
        Dim dtr() As DataRow

        If Add_flag Then
            If Not rs_syagtinf Is Nothing Then
                rs_syagtinf = Nothing
            End If

            gspStr = "sp_select_SYAGTINF '" & gsCompany & "','" & txtAgtCde.Text.Trim & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syagtinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00012 sp_select_SYAGTINF : " & rtnStr)
            Else
                dtr = rs_syagtinf.Tables("RESULT").Select("yai_agtcde = '" & txtAgtCde.Text.Trim & "'")
                If Not dtr.Length = 0 Then
                    MsgBox("Agent code already existed.")
                    txtAgtCde.Focus()
                    txtAgtCde.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub ShowAgtDtl()
        Dim dr() As DataRow
        Dim strAgt As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strAgt = Split(CboAgtCde.SelectedItem, " - ")(0).Trim

            If Not rs_syagtinf Is Nothing Then
                rs_syagtinf = Nothing
            End If

            gspStr = "sp_select_SYAGTINF '" & gsCompany & "','" & strAgt & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syagtinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00012 sp_select_SYAGTINF : " & rtnStr)
            Else
                gspStr = "sp_select_SYAGTTIR '" & gsCompany & "','" & strAgt & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_syagttir, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00012 sp_select_SYAGTTIR : " & rtnStr)
                Else
                    dr = rs_syagtinf.Tables("RESULT").Select("")
                    TxtSN.Text = dr(0).Item("yai_stnam")
                    TxtFN.Text = dr(0).Item("yai_fulnam")
                    TxtAddr.Text = dr(0).Item("yai_Addr")
                    TxtPZ.Text = dr(0).Item("yai_cntpst")
                    TxtSP.Text = dr(0).Item("yai_cntstt")
                    TxtBR.Text = dr(0).Item("yai_bscrat")
                    If dr(0).Item("yai_bsctir") = "T" Then
                        OptTier.Checked = True
                    ElseIf dr(0).Item("yai_bsctir") = "B" Then
                        OptBas.Checked = True
                    End If

                    Call DisplayCombo(CboCT, dr(0).Item("yai_comtrm"))
                    Call DisplayCombo(CboCountry, dr(0).Item("yai_cntcty"))
                    CboAgtCde.Enabled = False
                    mmdAdd.Enabled = False
                    mmdSave.Enabled = Enq_right_local

                    If rs_syagttir.Tables("RESULT").Rows.Count = 0 Then
                       
                        mmdInsRow.Enabled = Enq_right_local
                        mmdDelRow.Enabled = False
                    Else
                   
                        mmdInsRow.Enabled = False
                        mmdDelRow.Enabled = False
                        If Enq_right_local = True Then
                          
                            mmdInsRow.Enabled = Enq_right_local
                            mmdDelRow.Enabled = True
                        End If
                    End If


                    Me.StatusBar.Items("lblRight").Text = Format(dr(0).Item("yai_credat"), "MM/dd/yyyy") & " " & Format(dr(0).Item("yai_upddat"), "MM/dd/yyyy") & " " & dr(0).Item("yai_updusr")

                    Call setDataRowAttr()
                    Call displayGrid()
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub DisplayCombo(ByVal objCombo As ComboBox, ByVal strSelVal As String)
        Dim i As Integer

        objCombo.SelectedIndex = -1
        For i = 0 To objCombo.Items.Count - 1
            If Split(objCombo.Items(i).ToString, " - ")(0) = strSelVal Then
                objCombo.SelectedIndex = i
            End If
        Next
    End Sub
    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click

        For Each ctl As Control In Me.Controls
            If TypeOf (ctl) Is TextBox Then
                ctl.Text = ""
                ctl.Enabled = True
            End If
        Next
        Call SYM00012_Load(Nothing, Nothing)
        Call setStatus("ADD")
        Add_flag = True


        'CboCountry.SelectedIndex = -1
        'CboCT.SelectedIndex = -1
        'txtAgtCde.Focus()

    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For Each ctl As Control In Me.Controls
            If TypeOf (ctl) Is TextBox Then
                ctl.Text = ""
                ctl.Enabled = True
            End If
        Next
        Call SYM00012_Load(Nothing, Nothing)
        Call setStatus("ADD")
        Add_flag = True


        'CboCountry.SelectedIndex = -1
        'CboCT.SelectedIndex = -1
        'txtAgtCde.Focus()

    End Sub
    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_syagttir.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call mmdSave_Click(sender, e)

                    If save_ok Then
                        Call SYM00012_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00012_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00012_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_syagttir.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call mmdSave_Click(sender, e)

                    If save_ok Then
                        Call SYM00012_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00012_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00012_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            ' Toggle Delete
            If e.ColumnIndex = 0 Then
                If Not row.Cells("yat_agtcde").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                End If
            Else
                DataGrid.BeginEdit(True)
                mmdSave.Enabled = Enq_right_local
            End If
        End If
    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGrid.CellValidating
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("yat_ngmf"), "+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 5 Then
                If Not chkGrdCellValue(row.Cells("yat_ngmt"), "+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 6 Then
                If Not chkGrdCellValue(row.Cells("yat_rate"), "Z+Numeric") Then
                    e.Cancel = True
                ElseIf strNewVal < 0 Or strNewVal > 100 Then
                    MsgBox("Rate % should be between 0 and 100")
                    e.Cancel = True
                End If
            End If

        End If
    End Sub
    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_syagttir.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("yat_ngmf").ToString.Trim = "" Then
                MsgBox("Please input net gross margin from.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("yat_status") = ""
        dr.Item("yat_agtcde") = Me.CboAgtCde.SelectedItem
        dr.Item("yat_ngmf") = "0"
        dr.Item("yat_ngmt") = "0"
        dr.Item("yat_rate") = "0.000"
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(4).Value) Then
                DataGrid.CurrentCell = drr.Cells(4)
                DataGrid.CurrentCell.ReadOnly = False
                DataGrid.BeginEdit(True)
            End If
        Next
        Call setStatus("InsRow")
    End Sub

 

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("yat_agtcde").Value.ToString = "" Then
                If row.Cells("yat_status").Value.ToString = "" Then
                    row.Cells("yat_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yat_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
            End If
            Call setStatus("DelRow")
        End If

    End Sub


    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim strBT, strCT, strCountry, strAgt As String
        Dim dtr() As DataRow
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()

            If txtAgtCde.Text = "" And Add_flag Then
                txtAgtCde.Focus()
                save_ok = False
                MsgBox("Please input Agent Code.")

            ElseIf TxtSN.Text = "" Then
                TxtSN.Focus()
                save_ok = False
                MsgBox("Short Name Should not be NULL")

            ElseIf CboCountry.SelectedItem Is Nothing Then
                CboCountry.Focus()
                save_ok = False
                MsgBox("Please input Country.")
            End If

            If Not save_ok Then
                Exit Sub
            Else
                For Each row As DataGridViewRow In DataGrid.Rows

                    If row.Cells("yat_status").Value.ToString = "" Then

                        If Not chkGrdCellValue(row.Cells("yat_ngmf"), "+Integer") Then
                            save_ok = False

                        ElseIf Not chkGrdCellValue(row.Cells("yat_ngmt"), "+Integer") Then
                            save_ok = False

                        ElseIf Not chkGrdCellValue(row.Cells("yat_rate"), "Z+Numeric") Then
                            save_ok = False

                        ElseIf row.Cells("yat_rate").Value < 0 Or row.Cells("yat_rate").Value > 100 Then
                            MsgBox("Rate % should be between 0 and 100!")
                            save_ok = False
                            row.DataGridView.CurrentCell = row.Cells("yat_rate")

                        End If
                    End If

                    If Not save_ok Then
                        Exit For
                    End If
                Next
            End If

            If TxtBR.Text = "" Then
                TxtBR.Text = 0
            ElseIf IsNumeric(TxtBR.Text) = False Then
                MsgBox("Basic Rate is not a number")
                save_ok = False
            ElseIf IsNumeric(TxtBR.Text) = True Then
                If Convert.ToDecimal(TxtBR.Text) >= 1000 Then
                    MsgBox("Basic Rate can not larger than 1000")
                    save_ok = False
                End If
            End If


            If Not save_ok Then
                With DataGrid
                    '.BeginEdit(True)
                End With
                Exit Sub
            Else
                If OptBas.Checked Then
                    strBT = "B"
                Else
                    strBT = "T"
                End If


                strCT = Split(CboCT.SelectedItem, " - ")(0).Replace("'", "''").Trim
                strCountry = Split(CboCountry.SelectedItem, " - ")(0).Replace("'", "''").Trim
                If Add_flag Then
                    strAgt = txtAgtCde.Text.Replace("'", "''").Trim
                Else
                    strAgt = CboAgtCde.SelectedItem.ToString.Replace("'", "''").Trim
                End If

                gspStr = ""
                If Add_flag Then

                    gspStr = "sp_select_SYAGTINF '" & gsCompany & "','" & strAgt & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_syagtinf, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYM00012 sp_select_SYAGTINF : " & rtnStr)
                        save_ok = False
                        Exit Sub
                    Else
                        dtr = rs_syagtinf.Tables("RESULT").Select("yai_agtcde = '" & strAgt & "'")
                        If Not dtr.Length = 0 Then
                            MsgBox("Agent code already existed.")
                            txtAgtCde.Focus()
                            save_ok = False
                            Exit Sub
                        End If
                    End If
                    If IsNumeric(TxtBR.Text) <> True Then
                        TxtBR.Text = 0
                    End If

                    gspStr = "sp_insert_SYAGTINF '" & gsCompany & "','" & _
                                strAgt & "','" & _
                                TxtSN.Text.Replace("'", "''").Trim & "','" & _
                                TxtFN.Text.Replace("'", "''").Trim & "','" & _
                                TxtAddr.Text.Replace("'", "''").Trim & "','" & _
                                strCT & "','" & _
                                strBT & "','" & _
                                Convert.ToDecimal(TxtBR.Text) & "','" & _
                                TxtSP.Text.Replace("'", "''").Trim & "','" & _
                                strCountry & "','" & _
                                TxtPZ.Text.Replace("'", "''").Trim & "','" & _
                                gsUsrID & "'"

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00012 sp_insert_SYAGTINF : " & rtnStr)
                            flgErr = True
                            Exit Sub
                        End If
                    End If

                    gspStr = ""
                    For Each dr As DataRow In rs_syagttir.Tables("RESULT").Rows

                        If dr.RowState = DataRowState.Added And Not dr.Item("yat_status") = "Y" Then
                            If dr.Item("yat_credat").ToString.Trim = "" Then
                                gspStr = "sp_insert_SYAGTTIR '" & gsCompany & "','" & _
                                            strAgt & "','" & _
                                            dr.Item("yat_ngmf").ToString.Replace("'", "''").Trim & "','" & _
                                            dr.Item("yat_ngmt").ToString.Replace("'", "''").Trim & "'," & _
                                            dr.Item("yat_rate").ToString.Replace("'", "''").Trim & ",'" & _
                                            gsUsrID & "'"
                            End If
                        End If

                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYM00012 sp_insert_SYAGTTIR : " & rtnStr)
                                flgErr = True
                                Exit For
                            End If
                        End If
                    Next
                Else
                    ' AddFlag = False
                    gspStr = "sp_update_SYAGTINF '" & gsCompany & "','" & _
                               strAgt & "','" & _
                                TxtSN.Text.Trim.Replace("'", "''") & "','" & _
                                TxtFN.Text.Trim.Replace("'", "''") & "','" & _
                                TxtAddr.Text.Trim.Replace("'", "''") & "','" & _
                                strCT & "','" & _
                                strBT & "'," & _
                                Convert.ToDecimal(TxtBR.Text) & ",'" & _
                                TxtSP.Text.Replace("'", "''").Trim & "','" & _
                                strCountry & "','" & _
                                TxtPZ.Text.Replace("'", "''").Trim & "','" & _
                                gsUsrID & "'"

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00012 sp_update_SYAGTINF : " & rtnStr)
                            flgErr = True
                            Exit Sub
                        End If
                    End If

                    gspStr = ""
                    For Each dr As DataRow In rs_syagttir.Tables("RESULT").Rows

                        If dr.RowState = DataRowState.Modified Then
                            If dr.Item("yat_status") = "Y" Then
                                gspStr = "sp_physical_delete_SYAGTTIR '" & gsCompany & "','" & _
                                            strAgt & "'," & _
                                            dr.Item("yat_seq").ToString.Replace("'", "''").Trim
                            Else
                                gspStr = "sp_update_SYAGTTIR '" & gsCompany & "','" & _
                                            strAgt & "'," & _
                                            dr.Item("yat_seq").ToString.Replace("'", "''").Trim & ",'" & _
                                            dr.Item("yat_ngmf").ToString.Replace("'", "''").Trim & "','" & _
                                            dr.Item("yat_ngmt").ToString.Replace("'", "''").Trim & "'," & _
                                            dr.Item("yat_rate").ToString.Replace("'", "''").Trim & ",'" & _
                                            gsUsrID & "'"
                            End If

                        ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yat_status") = "Y" Then

                            If dr.Item("yat_creusr").ToString.Trim = "" Then
                                gspStr = "sp_insert_SYAGTTIR '" & gsCompany & "','" & _
                                            strAgt & "','" & _
                                            dr.Item("yat_ngmf").ToString.Replace("'", "''").Trim & "','" & _
                                            dr.Item("yat_ngmt").ToString.Replace("'", "''").Trim & "'," & _
                                            dr.Item("yat_rate").ToString.Replace("'", "''").Trim & ",'" & _
                                            gsUsrID & "'"
                            End If
                        End If

                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYM00012 sp_update_SYAGTTIR : " & rtnStr)
                                flgErr = True
                                Exit Sub
                            End If
                            gspStr = ""
                        End If
                    Next
                End If

                If Not flgErr Then
                    rs_syagttir.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_syagttir.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub SYM00012_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_syagttir.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call mmdSave_Click(sender, e)

                    If save_ok Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                e.Cancel = False
            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If

    End Sub

  

    Private Sub MmdExit_Click() Handles mmdExit.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub OptTier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptTier.CheckedChanged

    End Sub
    Private Sub OptBas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptBas.CheckedChanged

    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub
    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class