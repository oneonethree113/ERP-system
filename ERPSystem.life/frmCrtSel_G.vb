Public Class frmCrtSel_G

    Public myOwner As IMR00031

    Public CallFmString As String
    Public inCrtieria As String

    Dim rs_From As DataSet
    Dim RangeMode As String


    Private Sub frmCrtSel_G_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        If inCrtieria = "cocde" Then
            lblCrtName.Text = "Input Criteria : Company Code"
            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = False
            RangeMode = "Text"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(0)
        ElseIf inCrtieria = "cus1no" Then
            lblCrtName.Text = "Input Criteria : Primary Customer"
            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Combo"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(0)
        ElseIf inCrtieria = "cus2no" Then
            lblCrtName.Text = "Input Criteria : Secondary Customer"
            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Combo"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(0)
        ElseIf inCrtieria = "cuspono" Then
            lblCrtName.Text = "Input Criteria : Cust. PO No"
            tabFrame.TabPages(0).Enabled = False
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Text"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(1)
        ElseIf inCrtieria = "scno" Then
            lblCrtName.Text = "Input Criteria : SC No"
            tabFrame.TabPages(0).Enabled = False
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Text"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(1)
        ElseIf inCrtieria = "itmno" Then
            lblCrtName.Text = "Input Criteria : Item No"
            tabFrame.TabPages(0).Enabled = False
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Text"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(1)
        ElseIf inCrtieria = "cv" Then
            lblCrtName.Text = "Input Criteria : Custom Vendor"
            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Combo"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(0)
        ElseIf inCrtieria = "dv" Then
            lblCrtName.Text = "Input Criteria : Design Vendor"
            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Combo"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(0)
        ElseIf inCrtieria = "pv" Then
            lblCrtName.Text = "Input Criteria : Production Vendor"
            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Combo"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(0)
        ElseIf inCrtieria = "salesteam" Then
            lblCrtName.Text = "Input Criteria : Sales Team"
            tabFrame.TabPages(0).Enabled = True
            tabFrame.TabPages(1).Enabled = True
            RangeMode = "Combo"
            tabFrame.TabPages(2).Enabled = False
            tabFrame.SelectTab(0)
        End If

        Me.Text = lblCrtName.Text

        RangeTabEnable(RangeMode)

        FillInLstBox("ALL")
        FillExistSel()

        If tabFrame.TabPages(0).Enabled = True Then
            cmdClsSng.Enabled = True
        Else
            cmdClsSng.Enabled = False
        End If

        If tabFrame.TabPages(1).Enabled = True Then
            cmdClsRange.Enabled = True
        Else
            cmdClsRange.Enabled = False
        End If

        If tabFrame.TabPages(2).Enabled = True Then
            cmdClsPartial.Enabled = True
        Else
            cmdClsPartial.Enabled = False
        End If
    End Sub

    Private Sub RangeTabEnable(ByVal Mode As String)
        If Mode = "Text" Then
            txtRangeFm1.Enabled = True
            txtRangeTo1.Enabled = True
            txtRangeFm1.Visible = True
            txtRangeTo1.Visible = True

            txtRangeFm2.Enabled = True
            txtRangeTo2.Enabled = True
            txtRangeFm2.Visible = True
            txtRangeTo2.Visible = True

            txtRangeFm3.Enabled = True
            txtRangeTo3.Enabled = True
            txtRangeFm3.Visible = True
            txtRangeTo3.Visible = True

            cboFm1.Enabled = False
            cboTo1.Enabled = False
            cboFm1.Visible = False
            cboTo1.Visible = False

            cboFm2.Enabled = False
            cboTo2.Enabled = False
            cboFm2.Visible = False
            cboTo2.Visible = False

            cboFm3.Enabled = False
            cboTo3.Enabled = False
            cboFm3.Visible = False
            cboTo3.Visible = False
        Else
            txtRangeFm1.Enabled = False
            txtRangeTo1.Enabled = False
            txtRangeFm1.Visible = False
            txtRangeTo1.Visible = False

            txtRangeFm2.Enabled = False
            txtRangeTo2.Enabled = False
            txtRangeFm2.Visible = False
            txtRangeTo2.Visible = False

            txtRangeFm3.Enabled = False
            txtRangeTo3.Enabled = False
            txtRangeFm3.Visible = False
            txtRangeTo3.Visible = False

            cboFm1.Enabled = True
            cboTo1.Enabled = True
            cboFm1.Visible = True
            cboTo1.Visible = True

            cboFm2.Enabled = True
            cboTo2.Enabled = True
            cboFm2.Visible = True
            cboTo2.Visible = True

            cboFm3.Enabled = True
            cboTo3.Enabled = True
            cboFm3.Visible = True
            cboTo3.Visible = True
        End If

    End Sub

    Private Sub FillInLstBox(ByRef Mode As String)

        Select Case inCrtieria
            Case "cocde"
                gspStr = "sp_select_SYMUSRCO '" & gsCompany & "','" & gsUsrID & "'"
            Case "cus1no"
                gspStr = "sp_list_CUBASINF '" & gsCompany & "','PA'"
            Case "cus2no"
                gspStr = "sp_list_CUBASINF '" & gsCompany & "','P'"
            Case "cuspono"
                gspStr = ""
            Case "scno"
                gspStr = ""
            Case "itmno"
                gspStr = ""
            Case "cv"
                gspStr = "sp_list_VNBASINF '" & gsCompany & "'"
            Case "dv"
                gspStr = "sp_list_VNBASINF '" & gsCompany & "'"
            Case "pv"
                gspStr = "sp_list_VNBASINF '" & gsCompany & "'"
            Case "salesteam"
                gspStr = "sp_list_SYSALREP_CUR00002 '" & gsCompany & "','" & gsUsrID & "'"
        End Select

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If gspStr <> "" Then
            rs_From = Nothing
            rtnLong = execute_SQLStatement(gspStr, rs_From, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading frmCrtSel_G #001 " & Split(gspStr, "'")(0) & " : " & rtnStr)
                gspStr = ""
                Exit Sub
            End If
            gspStr = ""
            FillLstBox(Mode)
        End If
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub FillLstBox(ByRef Mode As String)

        Dim sList As String

        If rs_From.Tables("RESULT").Rows.Count > 0 Then

            If Mode = "ALL" Or Mode = "SNGVAL" Then
                lstFrom.Visible = False
                lstFrom.Items.Clear()
                lstTo.Items.Clear()
            End If

            For i As Integer = 0 To rs_From.Tables("RESULT").Rows.Count - 1
                sList = ""
                Select Case inCrtieria
                    Case "cocde"
                        If gsDefaultCompany = "MS" Then
                            If rs_From.Tables("RESULT").Rows(i)("yuc_cocde") = "MS" Then
                                sList = rs_From.Tables("RESULT").Rows(i)("yuc_cocde") & " - " & rs_From.Tables("RESULT").Rows(i)("yco_shtnam")
                            Else
                                sList = ""
                            End If
                        Else
                            If rs_From.Tables("RESULT").Rows(i)("yuc_cocde") <> "MS" Then
                                sList = rs_From.Tables("RESULT").Rows(i)("yuc_cocde") & " - " & rs_From.Tables("RESULT").Rows(i)("yco_shtnam")
                            Else
                                sList = ""
                            End If
                        End If
                    Case "cus1no"
                        If rs_From.Tables("RESULT").Rows(i)("cbi_cusno") > "50000" Then
                            sList = rs_From.Tables("RESULT").Rows(i)("cbi_cusno") & " - " & rs_From.Tables("RESULT").Rows(i)("cbi_cussna")
                        End If
                    Case "cus2no"
                        If rs_From.Tables("RESULT").Rows(i)("cbi_cusno") > "60000" Then
                            sList = rs_From.Tables("RESULT").Rows(i)("cbi_cusno") & " - " & rs_From.Tables("RESULT").Rows(i)("cbi_cussna")
                        End If
                    Case "cuspono"
                        sList = ""
                    Case "scno"
                        sList = ""
                    Case "itmno"
                        sList = ""
                    Case "cv"
                        sList = rs_From.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_From.Tables("RESULT").Rows(i)("vbi_vensna")
                    Case "dv"
                        sList = rs_From.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_From.Tables("RESULT").Rows(i)("vbi_vensna")
                    Case "pv"
                        sList = rs_From.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_From.Tables("RESULT").Rows(i)("vbi_vensna")
                    Case "salesteam"
                        sList = rs_From.Tables("RESULT").Rows(i)("ysr_saltem") & " - Sales Team " & rs_From.Tables("RESULT").Rows(i)("ysr_saltem")
                End Select

                If sList <> "" Then
                    If Mode = "ALL" Then
                        lstFrom.Items.Add(sList)
                        cboFm1.Items.Add(sList)
                        cboTo1.Items.Add(sList)
                        cboFm2.Items.Add(sList)
                        cboTo2.Items.Add(sList)
                        cboFm3.Items.Add(sList)
                        cboTo3.Items.Add(sList)
                    ElseIf Mode = "SNGVAL" Then
                        lstFrom.Items.Add(sList)
                    ElseIf Mode = "RANGE" Then
                        cboFm1.Items.Add(sList)
                        cboTo1.Items.Add(sList)
                        cboFm2.Items.Add(sList)
                        cboTo2.Items.Add(sList)
                        cboFm3.Items.Add(sList)
                        cboTo3.Items.Add(sList)
                    End If
                End If
            Next

            If Mode = "ALL" Or Mode = "SNGVAL" Then
                lstFrom.Visible = True
            End If

        End If

    End Sub

    Private Sub FillExistSel()

        Dim splitSel() As String
        Dim strTemp As String

        If CallFmString <> "" Then
            splitSel = Split(CallFmString, ",")

            For i As Integer = 0 To UBound(splitSel)
                If InStr(splitSel(i), "~") > 0 Then
                    txtRange.Text = txtRange.Text & "," & splitSel(i)
                    If Trim(cboFm1.Text) = "" Then

                        If inCrtieria = "prdLne" Then
                            cboFm1.Text = Split(splitSel(i), "~")(0)
                            cboTo1.Text = Split(splitSel(i), "~")(1)
                        Else
                            For j As Integer = cboFm1.Items.Count - 1 To 0 Step -1
                                strTemp = cboFm1.Items(j)
                                If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(0) Then
                                    cboFm1.Text = strTemp
                                End If
                            Next j

                            For j As Integer = cboTo1.Items.Count - 1 To 0 Step -1
                                strTemp = cboTo1.Items(j)
                                If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(1) Then
                                    cboTo1.Text = strTemp
                                End If
                            Next j
                        End If

                    ElseIf Trim(cboFm2.Text) = "" Then

                        If inCrtieria = "prdLne" Then
                            cboFm2.Text = Split(splitSel(i), "~")(0)
                            cboTo2.Text = Split(splitSel(i), "~")(1)
                        Else
                            For j As Integer = cboFm2.Items.Count - 1 To 0 Step -1
                                strTemp = cboFm2.Items(j)
                                If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(0) Then
                                    cboFm2.Text = strTemp
                                End If
                            Next j

                            For j As Integer = cboTo2.Items.Count - 1 To 0 Step -1
                                strTemp = cboTo2.Items(j)
                                If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(1) Then
                                    cboTo2.Text = strTemp
                                End If
                            Next j
                        End If

                    ElseIf Trim(cboFm3.Text) = "" Then
                        If inCrtieria = "prdLne" Then
                            cboFm3.Text = Split(splitSel(i), "~")(0)
                            cboTo3.Text = Split(splitSel(i), "~")(1)
                        Else
                            For j As Integer = cboFm3.Items.Count - 1 To 0 Step -1
                                strTemp = cboFm3.Items(j)
                                If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(0) Then
                                    cboFm3.Text = strTemp
                                End If
                            Next j

                            For j As Integer = cboTo3.Items.Count - 1 To 0 Step -1
                                strTemp = cboTo3.Items(j)
                                If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(1) Then
                                    cboTo3.Text = strTemp
                                End If
                            Next j
                        End If

                    End If
                ElseIf Microsoft.VisualBasic.Right(splitSel(i), 1) = "%" And Microsoft.VisualBasic.Left(splitSel(i), 1) = "%" Then
                    txtPartial.Text = txtPartial.Text & "," & splitSel(i)
                    If Trim(txtPartial1.Text) = "" Then
                        txtPartial1.Text = Mid(splitSel(i), 2, Len(splitSel(i)) - 2)
                    ElseIf Trim(txtPartial2.Text) = "" Then
                        txtPartial2.Text = Mid(splitSel(i), 2, Len(splitSel(i)) - 2)
                    ElseIf Trim(txtPartial3.Text) = "" Then
                        txtPartial3.Text = Mid(splitSel(i), 2, Len(splitSel(i)) - 2)
                    End If
                Else 'handle as single values
                    txtSngVal.Text = txtSngVal.Text + "," + splitSel(i)

                    If inCrtieria = "prdLne" Then
                        For j As Integer = lstFrom.Items.Count - 1 To 0 Step -1
                            'For j = 1 To lstFrom.ListCount - 1
                            strTemp = lstFrom.Items(j)
                            If strTemp = splitSel(i) Then
                                lstFrom.SetSelected(j, False)
                                lstTo.Items.Add(strTemp)
                                lstFrom.Items.RemoveAt(j)
                            End If
                        Next j
                    Else
                        For j As Integer = lstFrom.Items.Count - 1 To 0 Step -1
                            strTemp = lstFrom.Items(j)
                            If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(0) Then
                                lstFrom.SetSelected(j, False)
                                lstTo.Items.Add(strTemp)
                                lstFrom.Items.RemoveAt(j)
                            End If
                        Next j
                    End If
                End If
            Next i
        End If


        If txtRange.Text <> "" Then
            txtRange.Text = Microsoft.VisualBasic.Right(txtRange.Text, Len(txtRange.Text) - 1)
        End If
        If txtPartial.Text <> "" Then
            txtPartial.Text = Microsoft.VisualBasic.Right(txtPartial.Text, Len(txtPartial.Text) - 1)
        End If

    End Sub

    Private Sub cmdClsSng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClsSng.Click
        txtSngVal.Text = ""
        lstFrom.Items.Clear()
        lstTo.Items.Clear()
        FillInLstBox("SNGVAL")
    End Sub

    Private Sub cmdClsRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClsRange.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        txtRange.Text = ""
        cboFm1.Text = ""
        cboTo1.Text = ""
        cboFm2.Text = ""
        cboTo2.Text = ""
        cboFm3.Text = ""
        cboTo3.Text = ""
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdClsPartial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClsPartial.Click
        txtPartial.Text = ""
        txtPartial1.Text = ""
        txtPartial2.Text = ""
        txtPartial3.Text = ""
    End Sub

    Private Sub cmdAllCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllCls.Click
        cmdClsPartial.PerformClick()
        cmdClsRange.PerformClick()
        cmdClsSng.PerformClick()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim tmpStr As String

        setTxtList()

        If (cboFm1.Text > cboTo1.Text) Then
            MsgBox("From value should be smaller than To value in range of row 1!")
            tabFrame.SelectTab(1)
            cboFm1.Focus()
            cboFm1.SelectAll()
            Exit Sub
        End If

        If (cboFm2.Text > cboTo2.Text) Then
            MsgBox("From value should be smaller than To value in range of row 2!")
            tabFrame.SelectTab(1)
            cboFm2.Focus()
            cboFm2.SelectAll()
            Exit Sub
        End If

        If (cboFm3.Text > cboTo3.Text) Then
            MsgBox("From value should be smaller than To value in range of row 3!")
            tabFrame.SelectTab(1)
            cboFm3.Focus()
            cboFm3.SelectAll()
            Exit Sub
        End If



        tmpStr = Trim(txtSngVal.Text) + "," + Trim(txtRange.Text) + "," + Trim(txtPartial.Text)
        While tmpStr.Substring(0, 1) = "," 'Left(tmpStr, 1) = ","
            tmpStr = tmpStr.Substring(1, tmpStr.Length - 1) 'Right(tmpStr, Len(tmpStr) - 1)
        End While
        While tmpStr.Substring(tmpStr.Length - 1, 1) = "," 'Right(tmpStr, 1) = ","
            tmpStr = tmpStr.Substring(0, tmpStr.Length - 1) 'Left(tmpStr, Len(tmpStr) - 1)
        End While


        If myOwner.Name.ToString = "IMR00031" Then
            If inCrtieria = "cocde" Then
                myOwner.txtCocde.Text = ""
                myOwner.txtCocde.Text = tmpStr
            ElseIf inCrtieria = "cus1no" Then
                myOwner.txtCus1no.Text = ""
                myOwner.txtCus1no.Text = tmpStr
            ElseIf inCrtieria = "cus2no" Then
                myOwner.txtCus2no.Text = ""
                myOwner.txtCus2no.Text = tmpStr
            ElseIf inCrtieria = "cuspono" Then
                myOwner.txtCusPONo.Text = ""
                myOwner.txtCusPONo.Text = tmpStr
            ElseIf inCrtieria = "scno" Then
                myOwner.txtSCNo.Text = ""
                myOwner.txtSCNo.Text = tmpStr
            ElseIf inCrtieria = "itmno" Then
                myOwner.txtItmNo.Text = ""
                myOwner.txtItmNo.Text = tmpStr
            ElseIf inCrtieria = "cv" Then
                myOwner.txtCV.Text = ""
                myOwner.txtCV.Text = tmpStr
            ElseIf inCrtieria = "dv" Then
                myOwner.txtDV.Text = ""
                myOwner.txtDV.Text = tmpStr
            ElseIf inCrtieria = "pv" Then
                myOwner.txtPV.Text = ""
                myOwner.txtPV.Text = tmpStr
            ElseIf inCrtieria = "salesteam" Then
                myOwner.txtSalesTeam.Text = ""
                myOwner.txtSalesTeam.Text = tmpStr
            End If
        Else
        End If

        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'Dim i As Integer
        'Dim strTemp As String

        If (lstFrom.SelectedIndices.Count + lstTo.SelectedIndices.Count) > 100 Then
            MsgBox("The Result List will be more than 100 Records" & Environment.NewLine & "It Is Not Allowed!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If lstFrom.SelectedItems.Count > 0 Then
            While lstFrom.SelectedIndices.Count > 0
                lstTo.Items.Add(lstFrom.Items(lstFrom.SelectedIndices(0)))
                lstFrom.Items.RemoveAt(lstFrom.SelectedIndices(0))
            End While
        End If
        setTxtList()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If lstTo.SelectedItems.Count > 0 Then
            While lstTo.SelectedIndices.Count > 0
                lstFrom.Items.Add(lstTo.Items(lstTo.SelectedIndices(0)))
                lstTo.Items.RemoveAt(lstTo.SelectedIndices(0))
            End While
            setTxtList()
        End If
    End Sub

    Private Sub setTxtList()
        Dim i As Integer

        Me.txtSngVal.Text = ""
        For i = 0 To lstTo.Items.Count - 1
            txtSngVal.Text = txtSngVal.Text & "," & Split(lstTo.Items(i), " - ")(0)
        Next i
        If txtSngVal.Text <> "" Then
            txtSngVal.Text = Microsoft.VisualBasic.Right(txtSngVal.Text, Len(txtSngVal.Text) - 1)
        End If

        Me.txtRange.Text = ""
        If RangeMode = "Combo" Then
            If Trim(cboFm1.Text) <> "" And Trim(cboTo1.Text) <> "" Then
                txtRange.Text = txtRange.Text & "," & Split(cboFm1.Text, " - ")(0) & "~" & Split(cboTo1.Text, " - ")(0)
            End If
            If Trim(cboFm2.Text) <> "" And Trim(cboTo2.Text) <> "" Then
                txtRange.Text = txtRange.Text & "," & Split(cboFm2.Text, " - ")(0) & "~" & Split(cboTo2.Text, " - ")(0)
            End If
            If Trim(cboFm3.Text) <> "" And Trim(cboTo3.Text) <> "" Then
                txtRange.Text = txtRange.Text & "," & Split(cboFm3.Text, " - ")(0) & "~" & Split(cboTo3.Text, " - ")(0)
            End If
            If Me.txtRange.Text <> "" Then
                Me.txtRange.Text = Microsoft.VisualBasic.Right(txtRange.Text, Len(txtRange.Text) - 1)
            End If
        Else
            If Trim(txtRangeFm1.Text) <> "" And Trim(txtRangeTo1.Text) <> "" Then
                txtRange.Text = txtRange.Text & "," & txtRangeFm1.Text & "~" & txtRangeTo1.Text
            End If
            If Trim(txtRangeFm2.Text) <> "" And Trim(txtRangeTo2.Text) <> "" Then
                txtRange.Text = txtRange.Text & "," & txtRangeFm2.Text & "~" & txtRangeTo2.Text
            End If
            If Trim(txtRangeFm3.Text) <> "" And Trim(txtRangeTo3.Text) <> "" Then
                txtRange.Text = txtRange.Text & "," & txtRangeFm3.Text & "~" & txtRangeTo3.Text
            End If
            If Me.txtRange.Text <> "" Then
                Me.txtRange.Text = Microsoft.VisualBasic.Right(txtRange.Text, Len(txtRange.Text) - 1)
            End If
        End If

        Me.txtPartial.Text = ""
        If Trim(Me.txtPartial1.Text) <> "" Then
            txtPartial.Text = txtPartial.Text & "," & "%" & txtPartial1.Text & "%"
        End If
        If Trim(Me.txtPartial2.Text) <> "" Then
            txtPartial.Text = txtPartial.Text & "," & "%" & txtPartial2.Text & "%"
        End If
        If Trim(Me.txtPartial3.Text) <> "" Then
            txtPartial.Text = txtPartial.Text & "," & "%" & txtPartial3.Text & "%"
        End If
        If txtPartial.Text <> "" Then
            txtPartial.Text = Microsoft.VisualBasic.Right(txtPartial.Text, Len(txtPartial.Text) - 1)
        End If

    End Sub

    Private Sub txtRangeFmChanges(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRangeFm1.TextChanged, txtRangeFm1.Click, txtRangeFm2.TextChanged, txtRangeFm2.Click, txtRangeFm3.TextChanged, txtRangeFm3.Click
        If sender.Name.ToString = "txtRangeFm1" Then
            txtRangeTo1.Text = txtRangeFm1.Text
        ElseIf sender.Name.ToString = "txtRangeFm2" Then
            txtRangeTo2.Text = txtRangeFm2.Text
        ElseIf sender.Name.ToString = "txtRangeFm3" Then
            txtRangeTo3.Text = txtRangeFm3.Text
        End If
        setTxtList()
    End Sub

    Private Sub txtRangeToChanges(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRangeTo1.TextChanged, txtRangeTo1.Click, txtRangeTo2.TextChanged, txtRangeTo2.Click, txtRangeTo3.TextChanged, txtRangeTo3.Click
        setTxtList()
    End Sub

    Private Sub cboRangesFmChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFm1.TextChanged, cboFm1.Click, cboFm2.TextChanged, cboFm2.Click, cboFm3.TextChanged, cboFm3.Click
        If sender.Name.ToString = "cboFm1" Then
            cboTo1.Text = cboFm1.Text
        ElseIf sender.Name.ToString = "cboFm2" Then
            cboTo2.Text = cboFm2.Text
        ElseIf sender.Name.ToString = "cboFm3" Then
            cboTo3.Text = cboFm3.Text
        End If
        setTxtList()
    End Sub

    Private Sub cboRangesToChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTo1.TextChanged, cboTo1.Click, cboTo2.TextChanged, cboTo2.Click, cboTo3.TextChanged, cboTo3.Click
        setTxtList()
    End Sub
End Class