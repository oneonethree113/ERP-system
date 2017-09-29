Public Class SYM00001
    Inherits System.Windows.Forms.Form

    Dim rs_sysetinf As New DataSet
    Dim rs_sycominf As New DataSet
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Add_flag As Boolean
    Dim first_add As Boolean
    Dim option_flag As String = ""
    Dim Recordstatus As Boolean
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer

        GroupBox3.Enabled = False
        GroupBox3.Visible = False
        Cbocur.Items.Clear()


        Txtaddr.MaxLength = 200
        txtCoNam.MaxLength = 50
        txtShtNam.MaxLength = 25
        Txtaddr_c.MaxLength = 200
        txtCoNam_c.MaxLength = 50
        txtShtNam_c.MaxLength = 25
        txtPhone.MaxLength = 50
        txtFax.MaxLength = 50
        txtLogoPth.MaxLength = 100

        Call FillCompCombo(gsUsrID, CboCoCde)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        CanModify = True

        If Not rs_sysetinf Is Nothing Then
            rs_sysetinf = Nothing
        End If

        gspStr = "sp_select_SYSETINF '" & gsCompany & "','06'"
        rtnLong = execute_SQLStatement(gspStr, rs_sysetinf, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00001 sp_select_SYSETINF : " & rtnStr)
            Exit Sub
        Else
            If Not rs_sysetinf.Tables("RESULT").Rows.Count = 0 Then
                For Each drr As DataRow In rs_sysetinf.Tables("RESULT").Rows
                    Cbocur.Items.Add(drr.Item("ysi_cde").ToString)
                Next
            End If
        End If

        gspStr = "sp_select_SYCOMINF_M '" & gsCompany & "','ALL'"
        rtnLong = execute_SQLStatement(gspStr, rs_sycominf, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00001 sp_select_SYCOMINF_M : " & rtnStr)
            Exit Sub
        Else
            dt = rs_sycominf.Tables("RESULT")
            If Not dt Is Nothing Then
                For Each dc As DataColumn In dt.Columns
                    dc.ReadOnly = False
                Next
            End If

            If dt.Rows.Count = 0 Then

                dr = dt.NewRow
                For i = 1 To 12
                    cboMonth.Items.Add(i.ToString)
                Next i
                CboIVM.Items.Add("FIFO - First In First Out")
                CboIVM.Items.Add("LIFO - Last In First Out")
                CboIVM.Items.Add("AVG - Average Cost")

                Txtaddr.Text = dr.Item("yco_addr").ToString
                Call DisplayCombo(cboMonth, dr.Item("yco_mfystr"))
                Txtcuryrs.Text = dr.Item("yco_curyer").ToString
                Txtdatfmt.Text = dr.Item("yco_datfmt").ToString
                Txtdatfmt.Enabled = False

                Call DisplayCombo(CboIVM, dr.Item("yco_ivmth"))

                Txtsystim.Text = dr.Item("yco_systim")
                Txtinactive.Text = dr.Item("yco_irday")
                Txtinactive1.Text = dr.Item("yco_ir2day")
                TxtMOQ.Text = dr.Item("yco_moq")
                Call DisplayCombo(Cbocur, dr.Item("yco_curcde"))
                TxtMOA.Text = FormatNumber(dr.Item("yco_moa"), 2)

                Txtcomrat.Text = dr.Item("yco_bscrat")
                Txtexpiry.Text = dr.Item("yco_expday")

                If dr.Item("yco_commth") = "W" Then
                    option_flag = "W"
                    OptWacc.Checked = True
                Else
                    option_flag = "M"
                    OptMax.Checked = True
                End If

                dr.Item("yco_datrme1") = "01/01"
                dr.Item("yco_datrme2") = "04/01"
                dr.Item("yco_datrme3") = "07/01"
                dr.Item("yco_datrme4") = "11/01"
                dr.Item("yco_year") = 0
                dr.Item("yco_prctle") = 2

                TxtPriTce.Text = dr.Item("yco_prctle")
                DTdate1.Value = dr.Item("yco_datrme1") & "/" & Txtcuryrs.Text
                DTdate2.Value = dr.Item("yco_datrme2") & "/" & Txtcuryrs.Text
                DTdate3.Value = dr.Item("yco_datrme3") & "/" & Txtcuryrs.Text
                DTdate4.Value = dr.Item("yco_datrme4") & "/" & Txtcuryrs.Text

                txtAcInv.Text = dr.Item("yco_acinv")
                txtAcSam.Text = dr.Item("yco_acsam")
                txtAcInvAdj.Text = dr.Item("yco_acinvadj")
                txtAcSamTrm.Text = dr.Item("yco_acsamtrm")
                Txtcuryrs.Enabled = False

                dt.Rows.Add(dr)
                Call setStatus("init")
                Call Formstartup(Me.Name)
                Exit Sub
            Else
                first_add = False
                CboCoCde.Items.Clear()
                For Each drr As DataRow In dt.Rows
                    CboCoCde.Items.Add(drr.Item("yco_cocde").ToString)
                Next
            End If
        End If
        Call setStatus("init")
        Call Formstartup(Me.Name)
        CboCoCde.SelectedIndex = 0

    End Sub

    Private Sub setStatus(ByVal Mode As String)

        If Mode = "init" Then
            'cmdAdd.Enabled = Enq_right_local
            mmdAdd.Enabled = Enq_right_local
            'cmdDelete.Enabled = False
            mmdDelete.Enabled = False
            'cmdCopy.Enabled = False
            mmdCopy.Enabled = False
            'cmdSave.Enabled = False
            mmdSave.Enabled = False
            'cmdFind.Enabled = False
            mmdFind.Enabled = False
            'cmdClear.Enabled = False
            mmdClear.Enabled = False
            'cmdSearch.Enabled = False
            mmdSearch.Enabled = False
            'cmdInsRow.Enabled = False
            mmdInsRow.Enabled = False
            'cmdDelRow.Enabled = False
            mmdDelRow.Enabled = False
            'cmdfirst.Enabled = False
            'cmdNext.Enabled = False
            'cmdPrevious.Enabled = False
            'cmdlast.Enabled = False
            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            Add_flag = False
            Me.cboCoCde.Visible = True
            Me.txtCocde.Visible = False
            If gsUsrGrp = "MIS-S" Then
                Me.txtLogoPth.Enabled = True
            Else
                Me.txtLogoPth.Enabled = False
            End If

            Call SetStatusBar("init")
            Recordstatus = False

        ElseIf Mode = "Save" Then
            'cmdAdd.Enabled = Enq_right_local
            mmdAdd.Enabled = Enq_right_local
            'cmdDelete.Enabled = False
            mmdDelete.Enabled = False
            'cmdCopy.Enabled = False
            mmdCopy.Enabled = False
            'cmdSave.Enabled = Enq_right_local
            mmdSave.Enabled = Enq_right_local
            'cmdFind.Enabled = False
            mmdFind.Enabled = False
            'cmdClear.Enabled = False
            mmdClear.Enabled = False
            'cmdSearch.Enabled = False
            mmdSearch.Enabled = False
            'cmdInsRow.Enabled = False
            mmdInsRow.Enabled = False
            'cmdDelRow.Enabled = False
            mmdDelRow.Enabled = False
            'cmdfirst.Enabled = False
            'cmdNext.Enabled = False
            'cmdPrevious.Enabled = False
            'cmdLast.Enabled = False
            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            MsgBox("Record Saved!")
            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)
            Call SYM00001_Load(Nothing, Nothing)

        ElseIf Mode = "ADD" Then
            'cmdAdd.Enabled = False
            mmdAdd.Enabled = False
            'cmdClear.Enabled = True
            mmdClear.Enabled = True
            'cmdSave.Enabled = Enq_right_local
            mmdSave.Enabled = Enq_right_local

            cboCoCde.Text = ""
            txtCoNam.Text = ""
            txtShtNam.Text = ""
            TxtAddr.Text = ""
            Txtcuryrs.Text = ""
            Txtdatfmt.Text = ""
            Txtsystim.Text = ""
            Txtinactive.Text = ""
            Txtinactive1.Text = ""
            txtMOQ.Text = ""
            TxtMOA.Text = ""
            Txtcomrat.Text = ""
            Txtexpiry.Text = ""
            txtYear.Text = "7"
            Call ResetDefaultDisp()
            OptWacc.Checked = True

            If gsUsrGrp = "MIS-S" Then
                Me.txtLogoPth.Enabled = True
            Else
                Me.txtLogoPth.Enabled = False
            End If
            Call SetStatusBar(Mode)

        End If
        If Not CanModify Then
        End If
    End Sub

    Private Sub ResetDefaultDisp()
        txtCocde.Text = ""
        txtCoNam.Text = ""
        txtShtNam.Text = ""
        Txtaddr.Text = ""
        cboMonth.Text = "1"
        Txtcuryrs.Text = Now.Year.ToString
        Txtdatfmt.Text = "MM/DD/YYYY"
        Txtdatfmt.Enabled = False
        Txtsystim.Text = "60"
        Txtinactive.Text = "360"
        Txtinactive1.Text = "0"
        TxtMOQ.Text = "0"
        Cbocur.Text = "USD"
        TxtMOA.Text = "500"
        Txtcomrat.Text = "0"
        Txtexpiry.Text = "90"
        TxtPriTce.Text = "2"
        Txtyear.Text = "7"
        txtAcInv.Text = ""
        txtAcSam.Text = ""
        txtAcInvAdj.Text = ""
        txtAcSamTrm.Text = ""
    End Sub

    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "init" Then
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
        End If
    End Sub

    Public Function DisplayCombo(ByVal Combo As ComboBox, ByVal Cde As String) As Boolean
        Dim i As Integer
        DisplayCombo = False

        If Combo.Items.Count > 0 Then
            For i = 0 To Combo.Items.Count - 1
                If Split(Combo.Items(i), " - ")(0).ToString = Cde Then
                    Combo.SelectedIndex = i
                    Return True
                    Exit For
                End If
            Next i
        End If
    End Function

    Private Sub CboCoCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCoCde.SelectedIndexChanged

        Try
            If Not CboCoCde.SelectedItem Is Nothing Then

                If Not rs_sycominf Is Nothing Then
                    rs_sycominf = Nothing
                End If

                gspStr = "sp_select_SYCOMINF_M '" & gsCompany & "','" & CboCoCde.SelectedItem & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_sycominf, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYN00001 sp_select_SYCOMINF_M : " & rtnStr)
                Else
                    'cmdAdd.Enabled = False
                    mmdAdd.Enabled = False
                    If rs_sycominf.Tables("RESULT").Rows.Count > 0 Then
                        'cmdSave.Enabled = Enq_right_local
                        mmdSave.Enabled = Enq_right_local
                        'cmdClear.Enabled = True
                        mmdClear.Enabled = True
                        Call Display()
                        CboCoCde.Enabled = False
                    Else
                        MsgBox("Company Detail Not Found!")
                        CboCoCde.Focus()
                    End If
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub Display()
        Dim i As Integer

        If cboMonth.Items.Count = 0 Then

            For i = 1 To 12
                cboMonth.Items.Add(i.ToString)
            Next i
        End If

        If CboIVM.Items.Count = 0 Then
            CboIVM.Items.Add("FIFO - First In First Out")
            CboIVM.Items.Add("LIFO - Last In First Out")
            CboIVM.Items.Add("AVG - Average Cost")
        End If

        If Cbocur.Items.Count = 0 Then
            If Not rs_sysetinf.Tables("RESULT").Rows.Count = 0 Then
                For Each drr As DataRow In rs_sysetinf.Tables("RESULT").Rows
                    Cbocur.Items.Add(drr.Item("ysi_cde").ToString)
                Next
            End If
        End If

        Dim dr As DataRow = rs_sycominf.Tables("RESULT").Rows(0)
        txtCoNam.Text = dr.Item("yco_conam").ToString
        txtShtNam.Text = dr.Item("yco_shtnam").ToString
        Txtaddr.Text = dr.Item("yco_addr").ToString
        txtCoNam_c.Text = dr.Item("yco_conamc").ToString
        txtShtNam_c.Text = dr.Item("yco_shtnamc").ToString
        Txtaddr_c.Text = dr.Item("yco_addrc").ToString
        txtPhone.Text = dr.Item("yco_phoneno").ToString
        txtFax.Text = dr.Item("yco_faxno").ToString
        txtLogoPth.Text = dr.Item("yco_logoimgpth").ToString
        Call DisplayCombo(cboMonth, dr.Item("yco_mfystr").ToString)
        Txtcuryrs.Text = dr.Item("yco_curyer").ToString
        Txtdatfmt.Text = dr.Item("yco_datfmt").ToString
        Txtdatfmt.Enabled = False

        Call DisplayCombo(CboIVM, dr.Item("yco_ivmth").ToString)

        Txtsystim.Text = dr.Item("yco_systim").ToString
        Txtinactive.Text = dr.Item("yco_irday").ToString

        If IsDBNull(dr.Item("yco_ir2day")) Then
            dr.Item("yco_ir2day") = 0
            Txtinactive1.Text = 0
        Else
            Txtinactive1.Text = dr.Item("yco_ir2day").ToString
        End If

        TxtMOQ.Text = dr.Item("yco_moq").ToString
        Call DisplayCombo(Cbocur, dr.Item("yco_curcde").ToString)
        TxtMOA.Text = FormatNumber(dr.Item("yco_moa").ToString, 2)

        Txtcomrat.Text = dr.Item("yco_bscrat").ToString
        Txtexpiry.Text = dr.Item("yco_expday").ToString

        If dr.Item("yco_commth").ToString = "W" Then
            option_flag = "W"
            OptWacc.Checked = True
        Else
            option_flag = "M"
            OptMax.Checked = True
        End If

        TxtPriTce.Text = dr.Item("yco_prctle").ToString
        DTdate1.Value = dr.Item("yco_datrme1").ToString & "/" & Txtcuryrs.Text
        DTdate2.Value = dr.Item("yco_datrme2").ToString & "/" & Txtcuryrs.Text
        DTdate3.Value = dr.Item("yco_datrme3").ToString & "/" & Txtcuryrs.Text
        DTdate4.Value = dr.Item("yco_datrme4").ToString & "/" & Txtcuryrs.Text
        Txtyear.Text = dr.Item("yco_year").ToString

        txtAcInv.Text = dr.Item("yco_acinv").ToString
        txtAcSam.Text = dr.Item("yco_acsam").ToString
        txtAcInvAdj.Text = dr.Item("yco_acinvadj").ToString
        txtAcSamTrm.Text = dr.Item("yco_acsamtrm").ToString

        Txtcuryrs.Enabled = False

        If Not rs_sycominf.Tables("RESULT").Rows.Count = 0 Then
            Me.StatusBar.Items("lblRight").Text = Format(dr.Item("yco_credat"), "MM/dd/yyyy") & " " & Format(dr.Item("yco_upddat"), "MM/dd/yyyy") & " " & dr.Item("yco_updusr")
            'cmdSave.Enabled = Enq_right_local
            mmdSave.Enabled = Enq_right_local
        End If
    End Sub

    Private Function Chkdatavalid() As Boolean

        Chkdatavalid = False
        If CboCoCde.Text = "" Then
            MsgBox("Please enter Company Code!")
            If CboCoCde.Visible = True Then
                CboCoCde.Focus()
            Else
                txtCocde.Focus()
            End If
            Exit Function
        End If
        If Txtaddr.Text = "" Then
            MsgBox("Please enter Company Address")
            Txtaddr.Focus()
            Exit Function
        End If
        If cboMonth.Text = "" Then
            MsgBox("Invalid Start Month")
            cboMonth.Focus()
            Exit Function
        End If
        If Txtcuryrs.Text = "" Then
            MsgBox("Invalid Current Year")
            Txtcuryrs.Focus()
            Exit Function
        End If
        If Txtsystim.Text = "" Then
            MsgBox("Invalid Timeout value")
            Txtsystim.Focus()
            Exit Function
        End If
        If Txtinactive.Text = "" Then
            MsgBox("Invalid Incative record time, No order")
            Txtinactive.Focus()
            Exit Function
        End If
        If Txtinactive1.Text = "" Then
            MsgBox("Invalid Incative record time, No Transaction")
            Txtinactive1.Focus()
            Exit Function
        End If
        If TxtMOQ.Text = "" Then
            MsgBox("Invlaid MOQ")
            TxtMOQ.Focus()
            Exit Function
        End If
        If Cbocur.Text = "" Then
            MsgBox("Invalid Currency")
            Cbocur.Focus()
            Exit Function
        End If
        If TxtMOA.Text = "" Then
            MsgBox("Invalid MOA")
            TxtMOA.Focus()
            Exit Function
        End If
        If Txtcomrat.Text = "" Then
            MsgBox("Invalid Commition rate")
            Txtcomrat.Focus()
            Exit Function
        End If

        If Split(CboIVM.Text, " - ")(0) = "" Then
            MsgBox("Invalid IVM")
            CboIVM.Focus()
            Exit Function
        End If
        If TxtPriTce.Text = "" Then
            Exit Function
        End If
        If Txtexpiry.Text = "" Then
            MsgBox("Invalid Quotation expire days")
            Txtexpiry.Focus()
            Exit Function
        End If
        If Txtyear.Text = "" Then
            MsgBox("Invalid purge year")
            Txtyear.Focus()
            Exit Function
        End If

        If txtCoNam.Text = "" Then
            MsgBox("Invalid Company Name")
            txtCoNam.Focus()
            Exit Function
        End If
        If txtShtNam.Text = "" Then
            MsgBox("Invalid Company Short Name")
            txtShtNam.Focus()
            Exit Function
        End If

        If Trim(txtPhone.Text) = "" Then
            MsgBox("Please enter Phone No.")
            txtPhone.Focus()
            Exit Function
        End If

        If Trim(txtFax.Text) = "" Then
            MsgBox("Please enter Fax No.")
            txtFax.Focus()
            Exit Function
        End If
        Chkdatavalid = True
    End Function

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click

        If Add_flag Then
            If MsgBox("Clear Modified Company data?", vbYesNo) = vbNo Then
                txtCoNam.Focus()
                Exit Sub
            End If
        End If
        'cmdClear.Enabled = False
        mmdClear.Enabled = False
        'cmdAdd.Enabled = True
        mmdAdd.Enabled = True
        txtCocde.Text = ""
        CboCoCde.Enabled = True
        CboCoCde.Visible = True
        CboCoCde.Focus()
        CboCoCde.Text = ""
        txtCoNam.Text = ""
        txtShtNam.Text = ""
        Txtaddr.Text = ""
        txtCoNam_c.Text = ""
        txtShtNam_c.Text = ""
        Txtaddr_c.Text = ""
        txtPhone.Text = ""
        txtFax.Text = ""
        txtLogoPth.Text = ""
        Txtsystim.Text = ""
        Txtinactive.Text = ""
        Txtinactive1.Text = ""
        TxtMOQ.Text = ""
        TxtMOA.Text = ""
        Txtcomrat.Text = ""
        Txtexpiry.Text = ""
        TxtPriTce.Text = ""
        txtAcInv.Text = ""
        txtAcSam.Text = ""
        txtAcInvAdj.Text = ""
        txtAcSamTrm.Text = ""

        Txtyear.Text = ""
        Add_flag = False
        Call setStatus("init")
        Call ResetDefaultDisp()
    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        Dim i As Integer

        Add_flag = True
        'cmdSave.Enabled = Enq_right_local
        mmdSave.Enabled = Enq_right_local
        CboCoCde.Visible = False
        txtCocde.Visible = True
        If cboMonth.Items.Count <= 0 Then
            For i = 1 To 12
                cboMonth.Items.Add(i.ToString)
            Next i
        End If
        cboMonth.Text = "1"
        If CboIVM.Items.Count <= 0 Then
            CboIVM.Items.Add("FIFO - First In First Out")
            CboIVM.Items.Add("LIFO - Last In First Out")
            CboIVM.Items.Add("AVG - Average Cost")
        End If

        If Cbocur.Items.Count <= 0 Then
            If Not rs_sysetinf.Tables("RESULT").Rows.Count = 0 Then
                For Each drr As DataRow In rs_sysetinf.Tables("RESULT").Rows
                    Cbocur.Items.Add(drr.Item("ysi_cde").ToString)
                Next
            End If
        End If
        Call setStatus("ADD")
        txtCocde.Focus()
    End Sub

    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim flgErr As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            save_ok = True

            If DTdate1.Text <> "" Then
                If IsDate(DTdate1.Text & "/" & Txtcuryrs.Text) = False Then
                    MsgBox("Data format invalid!")
                    DTdate1.Focus()
                    Exit Sub
                End If
            End If

            If DTdate2.Text <> "" Then
                If IsDate(DTdate2.Text & "/" & Txtcuryrs.Text) = False Then
                    MsgBox("Data format invalid!")
                    DTdate1.Focus()
                    Exit Sub
                End If
            End If

            If DTdate3.Text <> "" Then
                If IsDate(DTdate3.Text & "/" & Txtcuryrs.Text) = False Then
                    MsgBox("Data format invalid!")
                    DTdate1.Focus()
                    Exit Sub
                End If
            End If

            If DTdate4.Text <> "" Then
                If IsDate(DTdate4.Text & "/" & Txtcuryrs.Text) = False Then
                    MsgBox("Data format invalid!")
                    DTdate1.Focus()
                    Exit Sub
                End If
            End If
            If Not Chkdatavalid() Then
                Exit Sub
            End If

            If Not Add_flag Then
                gspStr = "sp_update_SYCOMINF '" & gsCompany & "','" & _
                            CboCoCde.SelectedItem.ToString.Replace("'", "''").Trim & "','" & _
                            Txtaddr.Text.Replace("'", "''").Trim & "'," & _
                            cboMonth.SelectedItem.ToString.Replace("'", "''").Trim & "," & _
                            Txtcuryrs.Text.Replace("'", "''").Trim & "," & _
                            Txtsystim.Text.Replace("'", "''").Trim & "," & _
                            Txtinactive.Text.Replace("'", "''").Trim & "," & _
                            Txtinactive1.Text.Replace("'", "''").Trim & "," & _
                            TxtMOQ.Text.Replace("'", "''").Trim & ",'" & _
                            Cbocur.SelectedItem.ToString.Replace("'", "''").Trim & "'," & _
                            TxtMOA.Text.Replace("'", "''").Trim & ",'" & _
                            Txtcomrat.Text.Replace("'", "''").Trim & "','" & _
                            Txtdatfmt.Text.Replace("'", "''").Trim & "','" & _
                            Split(CboIVM.Text, " - ")(0).Replace("'", "''").Trim & "','" & _
                            option_flag & "','" & _
                            TxtPriTce.Text.Replace("'", "''").Trim & "'," & _
                            Txtexpiry.Text.Replace("'", "''").Trim & ",'" & _
                            DTdate1.Text.Replace("'", "''").Trim & "','" & _
                            DTdate2.Text.Replace("'", "''").Trim & "','" & _
                            DTdate3.Text.Replace("'", "''").Trim & "','" & _
                            DTdate4.Text.Replace("'", "''").Trim & "'," & _
                            Txtyear.Text.Replace("'", "''").Trim & ",'" & _
                            txtAcInv.Text.Replace("'", "''").Trim & "','" & _
                            txtAcSam.Text.Replace("'", "''").Trim & "','" & _
                            txtAcInvAdj.Text.Replace("'", "''").Trim & "','" & _
                            txtAcSamTrm.Text.Replace("'", "''").Trim & "','" & _
                            gsUsrID & "','" & _
                            txtCoNam.Text.Replace("'", "''").Trim & "','" & _
                            txtShtNam.Text.Replace("'", "''").Trim & "','" & _
                            txtCoNam_c.Text.Replace("'", "''").Trim & "','" & _
                            txtShtNam_c.Text.Replace("'", "''").Trim & "','" & _
                            Txtaddr_c.Text.Replace("'", "''").Trim & "','" & _
                            txtPhone.Text.Replace("'", "''").Trim & "','" & _
                            txtFax.Text.Replace("'", "''").Trim & "','" & _
                            txtLogoPth.Text.Replace("'", "''").Trim & "','D'"
            Else
                gspStr = "sp_insert_SYCOMINF '" & gsCompany & "','" & _
                            txtCocde.Text.ToString.Replace("'", "''").Trim & "','" & _
                            Txtaddr.Text.Replace("'", "''").Trim & "'," & _
                            cboMonth.SelectedItem.ToString.Replace("'", "''").Trim & "," & _
                            Txtcuryrs.Text.Replace("'", "''").Trim & "," & _
                            Txtsystim.Text.Replace("'", "''").Trim & "," & _
                            Txtinactive.Text.Replace("'", "''").Trim & "," & _
                            Txtinactive1.Text.Replace("'", "''").Trim & "," & _
                            TxtMOQ.Text.Replace("'", "''").Trim & ",'" & _
                            Cbocur.SelectedItem.ToString.Replace("'", "''").Trim & "'," & _
                            TxtMOA.Text.Replace("'", "''").Trim & ",'" & _
                            Txtcomrat.Text.Replace("'", "''").Trim & "','" & _
                            Txtdatfmt.Text.Replace("'", "''").Trim & "','" & _
                            Split(CboIVM.Text, " - ")(0).Replace("'", "''").Trim & "','" & _
                            option_flag & "','" & _
                            TxtPriTce.Text.Replace("'", "''").Trim & "'," & _
                            Txtexpiry.Text.Replace("'", "''").Trim & ",'" & _
                            DTdate1.Text.Replace("'", "''").Trim & "','" & _
                            DTdate2.Text.Replace("'", "''").Trim & "','" & _
                            DTdate3.Text.Replace("'", "''").Trim & "','" & _
                            DTdate4.Text.Replace("'", "''").Trim & "'," & _
                            Txtyear.Text.Replace("'", "''").Trim & ",'" & _
                            txtAcInv.Text.Replace("'", "''").Trim & "','" & _
                            txtAcSam.Text.Replace("'", "''").Trim & "','" & _
                            txtAcInvAdj.Text.Replace("'", "''").Trim & "','" & _
                            txtAcSamTrm.Text.Replace("'", "''").Trim & "','" & _
                            gsUsrID & "','" & _
                            txtCoNam.Text.Replace("'", "''").Trim & "','" & _
                            txtShtNam.Text.Replace("'", "''").Trim & "','" & _
                            txtCoNam_c.Text.Replace("'", "''").Trim & "','" & _
                            txtShtNam_c.Text.Replace("'", "''").Trim & "','" & _
                            Txtaddr_c.Text.Replace("'", "''").Trim & "','" & _
                            txtPhone.Text.Replace("'", "''").Trim & "','" & _
                            txtFax.Text.Replace("'", "''").Trim & "','" & _
                            txtLogoPth.Text.Replace("'", "''").Trim & "','" & _
                            gsCompanyGroup & "','D'"
            End If

            If gspStr <> "" Then
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00001 sp_insert_SYCOMINF OR sp_update_SYCOMINF : " & rtnStr)
                    flgErr = True
                End If
            End If

            If Not flgErr Then
                Call setStatus("Save")
            Else
                save_ok = False
                MsgBox("Record Not Updated!")
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub mmdExit_Click() Handles mmdExit.Click
        Me.Close()
    End Sub

    Private Sub OptCM_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptWacc.CheckedChanged
        If OptWacc.Checked = True Then
            option_flag = "W"
        Else
            option_flag = "M"
        End If
    End Sub

    Private Sub lblRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRight.Click

    End Sub
    Private Sub lblLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLeft.Click

    End Sub
    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub
    Private Sub Label24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label24.Click

    End Sub
    Private Sub Label35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label35.Click

    End Sub
    Private Sub Label34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label34.Click

    End Sub
    Private Sub Label33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label33.Click

    End Sub
    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label32.Click

    End Sub
    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub
    Private Sub DTdate1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTdate1.ValueChanged

    End Sub
    Private Sub DTdate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTdate2.ValueChanged

    End Sub
    Private Sub DTdate3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTdate3.ValueChanged

    End Sub
    Private Sub DTdate4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTdate4.ValueChanged

    End Sub
    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click

    End Sub
    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub
    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub
    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub
    Private Sub OptMax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptMax.CheckedChanged

    End Sub
    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub
    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click

    End Sub
    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click

    End Sub
    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label29.Click

    End Sub
    Private Sub Cbocur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbocur.SelectedIndexChanged

    End Sub
    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label28.Click

    End Sub
    Private Sub Label27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label27.Click

    End Sub
    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click

    End Sub
    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub
    Private Sub Label23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label23.Click

    End Sub
    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub
    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub
    Private Sub CboIVM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboIVM.SelectedIndexChanged

    End Sub
    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged

    End Sub
    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub
    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class