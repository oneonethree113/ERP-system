Public Class SYM00036
    Inherits System.Windows.Forms.Form

    Dim rs_SYFWDINF As New DataSet
    'Dim rs_syfwdtir As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim Add_flag As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00036_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Add_flag = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboForwarder()
            Call FillComboCountry()

            Call setStatus("Init")
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            mmdAdd.Enabled = Enq_right_local
            'cmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False

            txtFWDCde.Visible = False
            CboFWDCde.Visible = True
            CboFWDCde.Enabled = True

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False


            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "ADD" Then
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdAdd.Enabled = False
            mmdFind.Enabled = False
            mmdCopy.Enabled = False
            mmdInsRow.Enabled = False
            txtFWDCde.Visible = True
            CboFWDCde.Visible = False
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            CboFWDCde.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00036_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = False
            CboFWDCde.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            mmdAdd.Enabled = False
            'cmdSave.Enabled = False
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

    Private Sub FillComboForwarder()
        Dim rs_syfwdcde As New DataSet

        Try
            gspStr = "sp_list_SYFWDINF '" & "" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syfwdcde, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00036 sp_list_SYFWDINF : " & rtnStr)
            Else
                Me.CboFWDCde.Items.Clear()
                For Each dr As DataRow In rs_syfwdcde.Tables("RESULT").Rows
                    Me.CboFWDCde.Items.Add(dr.Item("yfi_FWDCde").ToString)
                Next
            End If
        Finally
            rs_syfwdcde = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboCountry()
        Dim rs_country As New DataSet

        Try
            gspStr = "sp_select_SYSETINF '" & gsCompany & "','02'"
            rtnLong = execute_SQLStatement(gspStr, rs_country, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00036 sp_select_SYSETINF : " & rtnStr)
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


    Private Sub CboFWDCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboFWDCde.SelectedIndexChanged
        If Not CboFWDCde.SelectedItem Is Nothing Then
            Call ShowFWDDtl()
        End If
    End Sub

    Private Sub txtFWDCde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFWDCde.LostFocus
        Dim dtr() As DataRow

        If Add_flag Then
            If Not rs_SYFWDINF Is Nothing Then
                rs_SYFWDINF = Nothing
            End If

            gspStr = "sp_select_SYFWDINF '" & gsCompany & "','" & txtFWDCde.Text.Trim & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYFWDINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00036 sp_select_SYFWDINF : " & rtnStr)
            Else
                dtr = rs_SYFWDINF.Tables("RESULT").Select("yfi_FWDCde = '" & txtFWDCde.Text.Trim & "'")
                If Not dtr.Length = 0 Then
                    MsgBox("Forwarder code already existed.")
                    txtFWDCde.Focus()
                    txtFWDCde.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub ShowFWDDtl()
        Dim dr() As DataRow
        Dim strfwd As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strfwd = Split(CboFWDCde.SelectedItem, " - ")(0).Trim

            If Not rs_SYFWDINF Is Nothing Then
                rs_SYFWDINF = Nothing
            End If

            gspStr = "sp_select_SYFWDINF '" & "" & "','" & strfwd & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYFWDINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00036 sp_select_SYFWDINF : " & rtnStr)
            Else
                dr = rs_SYFWDINF.Tables("RESULT").Select("")
                TxtSN.Text = dr(0).Item("yfi_stnam")
                TxtFN.Text = dr(0).Item("yfi_fulnam")
                TxtAddr.Text = dr(0).Item("yfi_Addr")
                TxtSP.Text = dr(0).Item("yfi_cntstt")
                TxtPZ.Text = dr(0).Item("yfi_cntpst")

                Call DisplayCombo(CboCountry, dr(0).Item("yfi_cntcty"))
                CboFWDCde.Enabled = False
                mmdSave.Enabled = Enq_right_local

            End If

            Dim dv As DataView = rs_SYFWDINF.Tables("RESULT").DefaultView
            If Not dv.Count = 0 Then
                dv.Sort = "yfi_upddat desc"
                Dim drv As DataRowView = dv(0)
                If drv.Item("yfi_credat").ToString = "" Then
                    Me.StatusBar.Items("lblRight").Text = ""
                Else
                    Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yfi_upddat"), "MM/dd/yyyy") & " " & Format(drv.Item("yfi_upddat"), "MM/dd/yyyy") & " " & drv.Item("yfi_updusr")
                End If
                dv.Sort = Nothing
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
        Call SYM00036_Load(Nothing, Nothing)
        Call setStatus("ADD")
        Add_flag = True


        'CboCountry.SelectedIndex = -1
        'CboCT.SelectedIndex = -1
        'txtFWDCde.Focus()

    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False


        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call mmdSave_Click(sender, e)

                    If save_ok Then
                        Call SYM00036_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00036_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00036_Load(Nothing, Nothing)
        End If

    End Sub



    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        Call setStatus("InsRow")
    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click

        Dim cellStyle As New DataGridViewCellStyle
        Call setStatus("DelRow")
        '' Toggle Delete
        'If Not row Is Nothing Then
        '    If Not row.Cells("yat_FWDCde").Value.ToString = "" Then
        '        If row.Cells("yat_status").Value.ToString = "" Then
        '            row.Cells("yat_status").Value = "Y"
        '            cellStyle.BackColor = Color.LightBlue
        '        Else
        '            row.Cells("yat_status").Value = ""
        '            cellStyle.BackColor = Nothing
        '        End If
        '        row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
        '    End If
        '    Call setStatus("DelRow")
        'End If

    End Sub

    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Dim strBT, strCT, strCountry, strfwd As String
        Dim dtr() As DataRow
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()

            If txtFWDCde.Text = "" And Add_flag Then
                txtFWDCde.Focus()
                save_ok = False
                MsgBox("Please input Forwarder Code.")

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
                'For Each row As DataGridViewRow In DataGrid.Rows

                '    If row.Cells("yat_status").Value.ToString = "" Then

                '        If Not chkGrdCellValue(row.Cells("yat_ngmf"), "+Integer") Then
                '            save_ok = False

                '        ElseIf Not chkGrdCellValue(row.Cells("yat_ngmt"), "+Integer") Then
                '            save_ok = False

                '        ElseIf Not chkGrdCellValue(row.Cells("yat_rate"), "Z+Numeric") Then
                '            save_ok = False

                '        ElseIf row.Cells("yat_rate").Value < 0 Or row.Cells("yat_rate").Value > 100 Then
                '            MsgBox("Rate % should be between 0 and 100!")
                '            save_ok = False
                '            row.DataGridView.CurrentCell = row.Cells("yat_rate")

                '        End If
                '    End If

                '    If Not save_ok Then
                '        Exit For
                '    End If
                'Next
            End If



            If Not save_ok Then

                Exit Sub
            Else



                strCountry = Split(CboCountry.SelectedItem, " - ")(0).Replace("'", "''").Trim
                If Add_flag Then
                    strfwd = txtFWDCde.Text.Replace("'", "''").Trim
                Else
                    strfwd = CboFWDCde.SelectedItem.ToString.Replace("'", "''").Trim
                End If

                gspStr = ""
                If Add_flag Then

                    gspStr = "sp_select_SYFWDINF '" & gsCompany & "','" & strfwd & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_SYFWDINF, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYM00036 sp_select_SYFWDINF : " & rtnStr)
                        save_ok = False
                        Exit Sub
                    Else
                        dtr = rs_SYFWDINF.Tables("RESULT").Select("yfi_FWDCde = '" & strfwd & "'")
                        If Not dtr.Length = 0 Then
                            MsgBox("Forwarder code already existed.")
                            txtFWDCde.Focus()
                            save_ok = False
                            Exit Sub
                        End If
                    End If

                    gspStr = "sp_insert_SYFWDINF '" & gsCompany & "','" & _
                                strfwd & "','" & _
                                TxtSN.Text.Replace("'", "''").Trim & "','" & _
                                TxtFN.Text.Replace("'", "''").Trim & "','" & _
                                TxtAddr.Text.Replace("'", "''").Trim & "','" & _
                                TxtSP.Text.Replace("'", "''").Trim & "','" & _
                                strCountry & "','" & _
                                TxtPZ.Text.Replace("'", "''").Trim & "','" & _
                                gsUsrID & "'"

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00036 sp_insert_SYFWDINF : " & rtnStr)
                            flgErr = True
                            Exit Sub
                        End If
                    End If

                    gspStr = ""

                Else
                    ' AddFlag = False
                    gspStr = "sp_update_SYFWDINF '" & gsCompany & "','" & _
                               strfwd & "','" & _
                                TxtSN.Text.Trim.Replace("'", "''") & "','" & _
                                TxtFN.Text.Trim.Replace("'", "''") & "','" & _
                                TxtAddr.Text.Trim.Replace("'", "''") & "','" & _
                                TxtSP.Text.Replace("'", "''").Trim & "','" & _
                                strCountry & "','" & _
                                TxtPZ.Text.Replace("'", "''").Trim & "','" & _
                                gsUsrID & "'"

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00036 sp_update_SYFWDINF : " & rtnStr)
                            flgErr = True
                            Exit Sub
                        End If
                    End If

                    gspStr = ""
                End If

                Call setStatus("Save")
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00036_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()

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

    Private Sub mmdExit_Click() Handles mmdExit.Click
        Me.Close()
    End Sub

    Private Sub StatusBar_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusBar.ItemClicked

    End Sub

    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click

    End Sub
End Class