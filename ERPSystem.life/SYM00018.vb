Public Class SYM00018

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim rs_SYSCHCON As DataSet
    Dim rs_Result As DataSet

    Public frmS As Form

    Public strModule As String
    Public keyName As String

    Const EMPTY As String = " "

    Public Sub show_frmSYM00018(ByVal frm As Form)
        frmS = frm
        Me.ShowDialog()
    End Sub

    Private Sub SYM00018_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        rs_Result = Nothing
        gspStr = "sp_list_SYSCHCON '" & gsCompany & "','" & strModule & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_SYSCHCON = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_SYSCHCON, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00018 #001 sp_list_SYSCHCON : " & rtnStr)
            Exit Sub
        End If

        If rs_SYSCHCON.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Search Criteria Found!")
            Close()
        Else
            fillcboCriteria()
        End If
    End Sub

    Private Function check_ItemSearch(ByVal criterialstr As String, ByVal dr_SYSCHCON As DataRow) As Boolean
        check_ItemSearch = False

        Select Case strModule
            Case "IM"
                If dr_SYSCHCON.Item("ssc_Field").ToString = "ibi_itmno" Then
                    check_ItemSearch = True
                End If
            Case "QU"
                If dr_SYSCHCON.Item("ssc_Field") = "qud_itmno" Then
                    check_ItemSearch = True
                End If
            Case "SA"
                If dr_SYSCHCON.Item("ssc_Field") = "sid_itmno" Then
                    check_ItemSearch = True
                End If
            Case "SC"
                If dr_SYSCHCON.Item("ssc_Field") = "sod_itmno" Then
                    check_ItemSearch = True
                End If
            Case "SH"
                If dr_SYSCHCON.Item("ssc_Field") = "hid_itmno" Then
                    check_ItemSearch = True
                End If
            Case "SR"
                If dr_SYSCHCON.Item("ssc_Field") = "srd_itmno" Then
                    check_ItemSearch = True
                End If
        End Select
    End Function

    Private Function check_PriCustSearch(ByVal criterialstr As String, ByVal dr_SYSCHCON As DataRow) As Boolean
        check_PriCustSearch = False

        Select Case strModule
            Case "QU"
                If dr_SYSCHCON.Item("ssc_Field") = "quh_cus1no" Then
                    check_PriCustSearch = True
                End If
            Case "SR"
                If dr_SYSCHCON.Item("ssc_Field") = "srh_cus1no" Then
                    check_PriCustSearch = True
                End If
            Case "SA"
                If dr_SYSCHCON.Item("ssc_Field") = "sih_cus1no" Then
                    check_PriCustSearch = True
                End If
            Case "SC"
                If dr_SYSCHCON.Item("ssc_Field") = "soh_cus1no" Then
                    check_PriCustSearch = True
                End If
            Case "PO"
                If dr_SYSCHCON.Item("ssc_Field") = "soh_cus1no" Then
                    check_PriCustSearch = True
                End If
            Case "SH"
                If dr_SYSCHCON.Item("ssc_Field") = "hih_cus1no" Then
                    check_PriCustSearch = True
                End If
        End Select
    End Function

    Private Function check_SecCustSearch(ByVal criterialstr As String, ByVal dr_SYSCHCON As DataRow) As Boolean
        check_SecCustSearch = False

        Select Case strModule
            Case "QU"
                If dr_SYSCHCON.Item("ssc_Field") = "quh_cus2no" Then
                    check_SecCustSearch = True
                End If
            Case "SR"
                If dr_SYSCHCON.Item("ssc_Field") = "srh_cus2no" Then
                    check_SecCustSearch = True
                End If
            Case "SA"
                If dr_SYSCHCON.Item("ssc_Field") = "sih_cus2no" Then
                    check_SecCustSearch = True
                End If
            Case "SC"
                If dr_SYSCHCON.Item("ssc_Field") = "soh_cus2no" Then
                    check_SecCustSearch = True
                End If
            Case "PO"
                If dr_SYSCHCON.Item("ssc_Field") = "soh_cus2no" Then
                    check_SecCustSearch = True
                End If
            Case "SH"
                If dr_SYSCHCON.Item("ssc_Field") = "hih_cus2no" Then
                    check_SecCustSearch = True
                End If
        End Select
    End Function

    Private Function check_RespPOSearch(ByVal criterialstr As String, ByVal dr_SYSCHCON As DataRow) As Boolean
        check_RespPOSearch = False

        Select Case strModule
            Case "SC"
                If dr_SYSCHCON.Item("ssc_Field") = "sod_resppo" Then
                    check_RespPOSearch = True
                End If
            Case "SH"
                If dr_SYSCHCON.Item("ssc_Field") = "sod_resppo" Then
                    check_RespPOSearch = True
                End If
        End Select
    End Function


    Private Function combine_optstring(ByVal ItemSearch As Boolean, ByVal PriCusSearch As Boolean, ByVal SecCusSearch As Boolean, ByVal RespPOSearch As Boolean, ByVal chkNum As Integer, ByVal dr_SYSCHCON As DataRow) As String
        combine_optstring = ""
        Dim chkvalue As Boolean
        chkvalue = False

        Dim fmstr As String
        Dim tostr As String
        fmstr = ""
        tostr = ""

        Select Case chkNum
            Case 1
                If chkPartial1.Checked = True Then
                    chkvalue = True
                End If
                fmstr = Trim(txtFrom1.Text)
                tostr = Trim(txtTo1.Text)
            Case 2
                If chkPartial2.Checked = True Then
                    chkvalue = True
                End If
                fmstr = Trim(txtFrom2.Text)
                tostr = Trim(txtTo2.Text)
            Case 3
                If chkPartial3.Checked = True Then
                    chkvalue = True
                End If
                fmstr = Trim(txtFrom3.Text)
                tostr = Trim(txtTo3.Text)
        End Select

        If ItemSearch = False And PriCusSearch = False And SecCusSearch = False And RespPOSearch = False Then
            If chkvalue = True Then
                combine_optstring = " " & dr_SYSCHCON.Item("ssc_Field") & " like '%" & Replace(Trim(fmstr), "'", "''") & "%'"
            Else
                If dr_SYSCHCON.Item("ssc_type") = "N" Then
                    combine_optstring = " " & dr_SYSCHCON.Item("ssc_Field") & " between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "'"
                ElseIf dr_SYSCHCON.Item("ssc_type") = "D" Then
                    combine_optstring = " " & dr_SYSCHCON.Item("ssc_Field") & " between '" & Replace(Trim(fmstr), "'", "''") & " 00:00:00'  and '" & Replace(Trim(tostr), "'", "''") & " 23:59:59.998'"
                Else
                    combine_optstring = " " & dr_SYSCHCON.Item("ssc_Field") & " between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "'"
                End If
            End If
        ElseIf RespPOSearch = True Then
            If chkvalue = True Then
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " like '%" & Replace(Trim(fmstr), "'", "''") & "%' or soh_resppo like '%" & Replace(Trim(fmstr), "'", "''") & "%')"
            Else
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "' " & _
                                    " or soh_resppo between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "')"
            End If
        ElseIf ItemSearch = True Then
            If chkvalue = True Then
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " like '%" & Replace(Trim(fmstr), "'", "''") + "%' " & _
                                    " or ibi_alsitmno like '%" & Replace(Trim(fmstr), "'", "''") & "%' " & _
                                    " or v_ibi_itmno like '%" & Replace(Trim(fmstr), "'", "''") & "%')"
            Else
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " between '" & Replace(Trim(fmstr), "'", "''") + "' and '" & Replace(Trim(tostr), "'", "''") & "' " & _
                                    " or ibi_alsitmno between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "' " & _
                                    " or v_ibi_itmno between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "')"
            End If
        ElseIf PriCusSearch = True Then
            If chkvalue = True Then
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " like '%" & Replace(Trim(fmstr), "'", "''") + "%' " & _
                                    " or Pri.cbi_cusali like '%" & Replace(Trim(fmstr), "'", "''") & "%' " & _
                                    " or PriCus.v_cbi_cusno like '%" & Replace(Trim(fmstr), "'", "''") & "%')"
            Else
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " between '" & Replace(Trim(fmstr), "'", "''") + "' and '" & Replace(Trim(tostr), "'", "''") & "' " & _
                                    " or Pri.cbi_cusali between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "' " & _
                                    " or PriCus.v_cbi_cusno between '" & Replace(Trim(fmstr), "'", "''") & "'and '" & Replace(Trim(tostr), "'", "''") & "')"
            End If
        ElseIf SecCusSearch = True Then
            If chkvalue = True Then
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " like '%" & Replace(Trim(fmstr), "'", "''") + "%' " & _
                                    " or Sec.cbi_cusali like '%" & Replace(Trim(fmstr), "'", "''") & "%' " & _
                                    " or SecCus.v_cbi_cusno like '%" & Replace(Trim(fmstr), "'", "''") & "%')"
            Else
                combine_optstring = " (" & dr_SYSCHCON.Item("ssc_Field") & " between '" & Replace(Trim(fmstr), "'", "''") + "' and '" & Replace(Trim(tostr), "'", "''") & "' " & _
                                    " or Sec.cbi_cusali between '" & Replace(Trim(fmstr), "'", "''") & "' and '" & Replace(Trim(tostr), "'", "''") & "' " & _
                                    " or SecCus.v_cbi_cusno between '" & Replace(Trim(fmstr), "'", "''") & "'and '" & Replace(Trim(tostr), "'", "''") & "')"
            End If
        Else

        End If

    End Function


    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Dim rs_SYSCHSQL As New DataSet

        Dim sql As String


        If Not InputIsValid() Then
            Exit Sub
        End If

        gspStr = "sp_list_SYSCHSQL '" & gsCompany & "','" & strModule & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_SYSCHSQL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdApply_Click sp_list_SYSCHSQL :" & rtnStr)
            Exit Sub
        End If

        If rs_SYSCHSQL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record found!")
            Exit Sub
        End If

        Dim ItemSearch As Boolean
        Dim PriCusSearch As Boolean
        Dim SecCusSearch As Boolean
        Dim RespPOSearch As Boolean
        ItemSearch = False
        PriCusSearch = False
        SecCusSearch = False
        RespPOSearch = False

        Dim opt1 As String
        Dim opt2 As String
        Dim opt3 As String

        opt1 = ""
        opt2 = ""
        opt3 = ""
        Dim dr_SYSCHCON() As DataRow

        If cboCriteria1.Text <> "" And cboCriteria1.Text <> EMPTY Then
            dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria1.Text & "'")
            ItemSearch = check_ItemSearch(cboCriteria1.Text, dr_SYSCHCON(0))
            PriCusSearch = check_PriCustSearch(cboCriteria1.Text, dr_SYSCHCON(0))
            SecCusSearch = check_SecCustSearch(cboCriteria1.Text, dr_SYSCHCON(0))
            RespPOSearch = check_RespPOSearch(cboCriteria1.Text, dr_SYSCHCON(0))
            opt1 = combine_optstring(ItemSearch, PriCusSearch, SecCusSearch, RespPOSearch, 1, dr_SYSCHCON(0))
        End If

        If cboCriteria2.Text <> "" And cboCriteria2.Text <> EMPTY Then
            dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria2.Text & "'")
            ItemSearch = check_ItemSearch(cboCriteria2.Text, dr_SYSCHCON(0))
            PriCusSearch = check_PriCustSearch(cboCriteria2.Text, dr_SYSCHCON(0))
            SecCusSearch = check_SecCustSearch(cboCriteria2.Text, dr_SYSCHCON(0))
            RespPOSearch = check_RespPOSearch(cboCriteria2.Text, dr_SYSCHCON(0))
            opt2 = combine_optstring(ItemSearch, PriCusSearch, SecCusSearch, RespPOSearch, 2, dr_SYSCHCON(0))
        End If

        If cboCriteria3.Text <> "" And cboCriteria3.Text <> EMPTY Then
            dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria3.Text & "'")
            ItemSearch = check_ItemSearch(cboCriteria3.Text, dr_SYSCHCON(0))
            PriCusSearch = check_PriCustSearch(cboCriteria3.Text, dr_SYSCHCON(0))
            SecCusSearch = check_SecCustSearch(cboCriteria3.Text, dr_SYSCHCON(0))
            RespPOSearch = check_RespPOSearch(cboCriteria3.Text, dr_SYSCHCON(0))
            opt3 = combine_optstring(ItemSearch, PriCusSearch, SecCusSearch, RespPOSearch, 3, dr_SYSCHCON(0))
        End If

        If strModule = "IM" Or strModule = "CU" Or strModule = "VN" Or strModule = "PC" Or strModule = "PK" Or strModule = "QC" Then
            sql = rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_select") & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_from") & " WHERE " & Chr(13) & Chr(10)
        Else
            sql = rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_select") & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_from") & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_where") & _
                    "'" & gsCompany & "' and " & Chr(13) & Chr(10)
        End If

        If opt1 = "" And opt2 = "" And opt3 = "" Then
            sql = sql.Substring(0, Len(sql) - 6) & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_order")
        Else
            If opt1 <> "" Then
                sql = sql & opt1 & " and " & Chr(13) & Chr(10)
            End If
            If opt2 <> "" Then
                sql = sql & opt2 & " and " & Chr(13) & Chr(10)
            End If
            If opt3 <> "" Then
                sql = sql & opt3 & " and " & Chr(13) & Chr(10)
            End If

            sql = sql.Substring(0, Len(sql) - 6) & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_order")
        End If

        Dim txtSQL As String

        txtSQL = Replace(sql, "'", "''")


        gspStr = "sp_list_SYSCHSQL_01 '" & gsCompany & "','" & txtSQL & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdApply_Click sp_list_SYSCHSQL_01 :" & rtnStr)
            Exit Sub
        Else
            If rs.Tables("RESULT").Rows.Count = 0 Then
                If strModule = "IM" Then
                    sql = showIMHisInfo(opt1, opt2, opt3)
                    'DisplayDataGrid1(sql)
                Else
                    MsgBox("No Record found!")
                    grdResult.DataSource = rs.Tables("RESULT").DefaultView
                    grdResult.Columns(0).Visible = False
                End If
            Else
                If rs.Tables("RESULT").Rows.Count >= 500 Then
                    MsgBox("Over 500 records found! Only 500 records shown")
                End If
                grdResult.DataSource = rs.Tables("RESULT").DefaultView
                grdResult.Columns(0).Visible = False
                If strModule = "IM" Then
                    DisplayDataGrid1(sql)
                End If
            End If
        End If
    End Sub

    Private Function showIMHisInfo(ByVal opt1 As String, ByVal opt2 As String, ByVal opt3 As String) As String
        Dim rs_SYSCHSQL As New DataSet

        Dim sql As String

        sql = ""
        showIMHisInfo = ""


        gspStr = "sp_list_SYSCHSQL '" & gsCompany & "', 'IH', '" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_SYSCHSQL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdApply_Click sp_list_SYSCHSQL_01 :" & rtnStr)
            Exit Function
        Else
            If rs_SYSCHSQL.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record found!")
                Exit Function
            Else
                sql = rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_select") & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_from") & "WHERE" & Chr(13) & Chr(10)
                If opt1 = "" And opt2 = "" And opt3 = "" Then
                    sql = sql.Substring(1, Len(sql) - 6) & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_order")
                Else
                    If opt1 <> "" Then
                        sql = sql & opt1 & " and " & Chr(13) & Chr(10)
                    End If
                    If opt2 <> "" Then
                        sql = sql & opt2 & " and " & Chr(13) & Chr(10)
                    End If
                    If opt3 <> "" Then
                        sql = sql & opt3 & " and " & Chr(13) & Chr(10)
                    End If

                    sql = sql.Substring(0, Len(sql) - 6) & rs_SYSCHSQL.Tables("RESULT").Rows(0).Item("scs_order")
                End If

                Dim txtSQL As String

                txtSQL = Replace(sql, "'", "''")

                gspStr = "sp_list_SYSCHSQL_01 '" & gsCompany & "','" & txtSQL & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading showIMHisInfo sp_list_SYSCHSQL_01 :" & rtnStr)
                    Exit Function
                Else
                    If rs.Tables("RESULT").Rows.Count >= 500 Then
                        MsgBox("Over 500 records found! Only 500 records shown")
                    End If
                    grdResult.DataSource = rs.Tables("RESULT").DefaultView
                    grdResult.Columns(0).Visible = False
                End If

            End If
        End If

        showIMHisInfo = sql

    End Function



    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If grdResult.RowCount = 0 Then
            Exit Sub
        End If

        Dim tmpstr As String
        If grdResult.CurrentCell Is Nothing Then
            tmpstr = grdResult.Item(0, 0).Value()
        Else
            tmpstr = grdResult.Item(0, grdResult.CurrentCell.RowIndex).Value()
        End If

        Dim ctn() As Control = frmS.Controls.Find(keyName, True)
        ctn(0).Text = tmpstr



        Dim ctnFind() As Control = frmS.Controls.Find("cmdFind", True)
        Dim tmpargs(1) As Object

        tmpargs(0) = sender
        tmpargs(1) = e

        If ctnFind.Length = 0 Then
            CallByName(frmS, "mmdFind_Click", CallType.Method, tmpargs)
        Else
            CallByName(frmS, "cmdFind_Click", CallType.Method, tmpargs)
        End If

        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        grdResult.DataSource = Nothing

        cboCriteria1.Items.Clear()
        cboCriteria2.Items.Clear()
        cboCriteria3.Items.Clear()

        chkPartial1.Checked = False
        chkPartial2.Checked = False
        chkPartial3.Checked = False

        txtFrom1.Text = ""
        txtFrom2.Text = ""
        txtFrom3.Text = ""

        txtTo1.Text = ""
        txtTo2.Text = ""
        txtTo3.Text = ""

        Close()
    End Sub

    Private Sub fillcboCriteria()
        cboCriteria1.Items.Clear()
        cboCriteria2.Items.Clear()
        cboCriteria3.Items.Clear()

        cboCriteria1.Items.Add(EMPTY)
        cboCriteria2.Items.Add(EMPTY)
        cboCriteria3.Items.Add(EMPTY)

        For i As Integer = 0 To rs_SYSCHCON.Tables("RESULT").Rows.Count - 1
            cboCriteria1.Items.Add(rs_SYSCHCON.Tables("RESULT").Rows(i)("ssc_display"))
            cboCriteria2.Items.Add(rs_SYSCHCON.Tables("RESULT").Rows(i)("ssc_display"))
            cboCriteria3.Items.Add(rs_SYSCHCON.Tables("RESULT").Rows(i)("ssc_display"))
        Next
        cboCriteria1.SelectedIndex = -1
        cboCriteria2.SelectedIndex = -1
        cboCriteria3.SelectedIndex = -1
    End Sub

    Private Sub chkPartial_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPartial1.CheckedChanged, chkPartial2.CheckedChanged, chkPartial3.CheckedChanged
        Dim dr_SYSCHCON() As DataRow

        If sender.Name.ToString = "chkPartial1" Then
            If cboCriteria1.Text <> "" Then
                dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria1.Text & "'")

                If dr_SYSCHCON.Length > 0 Then
                    If dr_SYSCHCON(0).Item("ssc_type") = "C" Then
                        If sender.Checked = False Then
                            txtTo1.Enabled = True
                        Else
                            txtTo1.Text = ""
                            txtTo1.Enabled = False
                        End If
                    Else
                        If sender.Checked = True Then
                            MsgBox("Only Charater String field allows partial search!")
                            sender.Checked = False
                        End If
                    End If
                End If
            Else
                If sender.Checked = True Then
                    sender.Checked = False
                End If
            End If
        ElseIf sender.Name.ToString = "chkPartial2" Then
            If cboCriteria2.Text <> "" Then
                dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria2.Text & "'")

                If dr_SYSCHCON.Length > 0 Then
                    If dr_SYSCHCON(0).Item("ssc_type") = "C" Then
                        If sender.Checked = False Then
                            txtTo2.Enabled = True
                        Else
                            txtTo2.Text = ""
                            txtTo2.Enabled = False
                        End If
                    Else
                        If sender.Checked = True Then
                            MsgBox("Only Charater String field allows partial search!")
                            sender.Checked = False
                        End If
                    End If
                End If
            Else
                If sender.Checked = True Then
                    sender.Checked = False
                End If
            End If
        Else
            If cboCriteria3.Text <> "" Then
                dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria3.Text & "'")

                If dr_SYSCHCON.Length > 0 Then
                    If dr_SYSCHCON(0).Item("ssc_type") = "C" Then
                        If sender.Checked = False Then
                            txtTo3.Enabled = True
                        Else
                            txtTo3.Text = ""
                            txtTo3.Enabled = False
                        End If
                    Else
                        If sender.Checked = True Then
                            MsgBox("Only Charater String field allows partial search!")
                            sender.Checked = False
                        End If
                    End If
                End If
            Else
                If sender.Checked = True Then
                    sender.Checked = False
                End If
            End If
        End If
    End Sub


    Private Function InputIsValid() As Boolean
        Dim dr_SYSCHCON() As DataRow

        InputIsValid = True

        If (cboCriteria1.Text = "" Or cboCriteria1.Text = EMPTY) _
            And (cboCriteria2.Text = "" Or cboCriteria2.Text = EMPTY) _
            And (cboCriteria3.Text = "" Or cboCriteria3.Text = EMPTY) Then
            MsgBox("Please select criteria first!")
            InputIsValid = False
            Exit Function
        End If

        'Check CboCriterial1
        If cboCriteria1.Text <> "" And cboCriteria1.Text <> EMPTY Then
            If chkPartial1.Checked = True Then
                If Trim(txtFrom1.Text) = "" Then
                    MsgBox("Please Input Value")
                    txtFrom1.Select()
                End If
            Else
                If Trim(txtFrom1.Text) <> "" And Trim(txtTo1.Text) = "" Then
                    txtTo1.Text = txtFrom1.Text
                ElseIf Trim(txtFrom1.Text) = "" And Trim(txtTo1.Text) = "" Then
                    MsgBox("Please Input Value")
                    InputIsValid = False
                    txtFrom1.Select()
                    Exit Function
                Else
                    If cboCriteria1.Text <> "" Then
                        dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria1.Text & "'")
                        If dr_SYSCHCON.Length > 0 Then
                            If dr_SYSCHCON(0).Item("ssc_type") = "C" Then
                                If Trim(txtFrom1.Text) > Trim(txtTo1.Text) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom1.Select()
                                    Exit Function
                                End If
                            ElseIf dr_SYSCHCON(0).Item("ssc_type") = "N" Then
                                If CDbl(Trim(txtFrom1.Text)) > CDbl(Trim(txtTo1.Text)) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom1.Select()
                                    Exit Function
                                End If
                            ElseIf dr_SYSCHCON(0).Item("ssc_type") = "D" Then
                                If Not IsDate(Trim(txtFrom1.Text)) Then
                                    MsgBox("Invalid Date! (MM/DD/YYYY)")
                                    InputIsValid = False
                                    txtFrom1.Select()
                                    Exit Function
                                End If

                                If Not IsDate(Trim(txtTo1.Text)) Then
                                    MsgBox("Invalid Date! (MM/DD/YYYY)")
                                    InputIsValid = False
                                    txtTo1.Select()
                                    Exit Function
                                End If

                                If CDate(txtTo1.Text) < CDate(txtFrom1.Text) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom1.Select()
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If


        'Check CboCriterial2
        If cboCriteria2.Text <> "" And cboCriteria2.Text <> EMPTY Then
            If chkPartial2.Checked = True Then
                If Trim(txtFrom2.Text) = "" Then
                    MsgBox("Please Input Value")
                    txtFrom2.Select()
                End If
            Else
                If Trim(txtFrom2.Text) <> "" And Trim(txtTo2.Text) = "" Then
                    txtTo2.Text = txtFrom2.Text
                ElseIf Trim(txtFrom2.Text) = "" And Trim(txtTo2.Text) = "" Then
                    MsgBox("Please Input Value")
                    InputIsValid = False
                    txtFrom2.Select()
                    Exit Function
                Else
                    If cboCriteria2.Text <> "" Then
                        dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria2.Text & "'")
                        If dr_SYSCHCON.Length > 0 Then
                            If dr_SYSCHCON(0).Item("ssc_type") = "C" Then
                                If Trim(txtFrom2.Text) > Trim(txtTo2.Text) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom2.Select()
                                    Exit Function
                                End If
                            ElseIf dr_SYSCHCON(0).Item("ssc_type") = "N" Then
                                If CDbl(Trim(txtFrom2.Text)) > CDbl(Trim(txtTo2.Text)) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom2.Select()
                                    Exit Function
                                End If
                            ElseIf dr_SYSCHCON(0).Item("ssc_type") = "D" Then
                                If Not IsDate(Trim(txtFrom2.Text)) Then
                                    MsgBox("Invalid Date! (MM/DD/YYYY)")
                                    InputIsValid = False
                                    txtFrom2.Select()
                                    Exit Function
                                End If

                                If Not IsDate(Trim(txtTo2.Text)) Then
                                    MsgBox("Invalid Date! (MM/DD/YYYY)")
                                    InputIsValid = False
                                    txtTo2.Select()
                                    Exit Function
                                End If

                                If CDate(txtTo2.Text) < CDate(txtFrom2.Text) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom2.Select()
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        'Check CboCriterial3
        If cboCriteria3.Text <> "" And cboCriteria3.Text <> EMPTY Then
            If chkPartial3.Checked = True Then
                If Trim(txtFrom3.Text) = "" Then
                    MsgBox("Please Input Value")
                    txtFrom3.Select()
                End If
            Else
                If Trim(txtFrom3.Text) <> "" And Trim(txtTo3.Text) = "" Then
                    txtTo3.Text = txtFrom3.Text
                ElseIf Trim(txtFrom3.Text) = "" And Trim(txtTo3.Text) = "" Then
                    MsgBox("Please Input Value")
                    InputIsValid = False
                    txtFrom3.Select()
                    Exit Function
                Else
                    If cboCriteria3.Text <> "" Then
                        dr_SYSCHCON = rs_SYSCHCON.Tables("RESULT").Select("ssc_display = '" & cboCriteria3.Text & "'")
                        If dr_SYSCHCON.Length > 0 Then
                            If dr_SYSCHCON(0).Item("ssc_type") = "C" Then
                                If Trim(txtFrom3.Text) > Trim(txtTo3.Text) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom3.Select()
                                    Exit Function
                                End If
                            ElseIf dr_SYSCHCON(0).Item("ssc_type") = "N" Then
                                If CDbl(Trim(txtFrom3.Text)) > CDbl(Trim(txtTo3.Text)) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom3.Select()
                                    Exit Function
                                End If
                            ElseIf dr_SYSCHCON(0).Item("ssc_type") = "D" Then
                                If Not IsDate(Trim(txtFrom3.Text)) Then
                                    MsgBox("Invalid Date! (MM/DD/YYYY)")
                                    InputIsValid = False
                                    txtFrom3.Select()
                                    Exit Function
                                End If

                                If Not IsDate(Trim(txtTo3.Text)) Then
                                    MsgBox("Invalid Date! (MM/DD/YYYY)")
                                    InputIsValid = False
                                    txtTo3.Select()
                                    Exit Function
                                End If

                                If CDate(txtTo3.Text) < CDate(txtFrom3.Text) Then
                                    MsgBox("<From> value should be smaller than <To> value!")
                                    InputIsValid = False
                                    txtFrom3.Select()
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If


    End Function

    Private Sub DisplayDataGrid1(ByVal SqlStr As String)

        If SqlStr = "" Then Exit Sub

        Dim tmpsqlstr() As String

        tmpsqlstr = Split(SqlStr, "--▲")
        tmpsqlstr = Split(SqlStr, "▲--")

        If tmpsqlstr.Length = 0 Then Exit Sub

        tmpsqlstr = Split(SqlStr, "▲")

        Dim i As Integer
        i = 0

        For i = 1 To tmpsqlstr.Length - 2
            grdResult.Columns(i - 1).Width = CLng(tmpsqlstr(i))
        Next
    End Sub

    Private Sub grdResult_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdResult.CellMouseDoubleClick
        If grdResult.RowCount = 0 Then
            Exit Sub
        End If

        Dim tmpstr As String
        tmpstr = grdResult.Item(0, grdResult.CurrentCell.RowIndex).Value()

        Dim ctn() As Control = frmS.Controls.Find(keyName, True)
        ctn(0).Text = tmpstr

        Dim ctnFind() As Control = frmS.Controls.Find("cmdFind", True)
        Dim tmpargs(1) As Object

        tmpargs(0) = sender
        tmpargs(1) = e

        If ctnFind.Length = 0 Then
            CallByName(frmS, "mmdFind_Click", CallType.Method, tmpargs)
        Else
            CallByName(frmS, "cmdFind_Click", CallType.Method, tmpargs)
        End If


        Me.Close()
    End Sub

    Private Sub txtFrom1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom1.LostFocus
        txtFrom1.Text = UCase(txtFrom1.Text)
    End Sub

    Private Sub txtFrom1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom1.TextChanged
        If chkPartial1.Checked = False Then
            txtTo1.Text = txtFrom1.Text
        End If
    End Sub

    Private Sub txtFrom2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom2.LostFocus
        txtFrom2.Text = UCase(txtFrom2.Text)
    End Sub

    Private Sub txtFrom2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom2.TextChanged
        If chkPartial2.Checked = False Then
            txtTo2.Text = txtFrom2.Text
        End If
    End Sub

    Private Sub txtFrom3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom3.LostFocus
        txtFrom3.Text = UCase(txtFrom3.Text)
    End Sub

    Private Sub txtFrom3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom3.TextChanged
        If chkPartial3.Checked = False Then
            txtTo3.Text = txtFrom3.Text
        End If
    End Sub

    Private Sub txtTo1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTo1.LostFocus
        txtTo1.Text = UCase(txtTo1.Text)
    End Sub

    Private Sub txtTo2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTo2.LostFocus
        txtTo2.Text = UCase(txtTo2.Text)
    End Sub

    Private Sub txtTo3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTo3.LostFocus
        txtTo3.Text = UCase(txtTo3.Text)
    End Sub


    Private Sub cboCriteria1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCriteria1.SelectedValueChanged
        chkPartial1.Checked = False
        txtFrom1.Text = ""
        txtTo1.Text = ""
    End Sub

    Private Sub cboCriteria2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCriteria2.SelectedValueChanged
        chkPartial2.Checked = False
        txtFrom2.Text = ""
        txtTo2.Text = ""
    End Sub

    Private Sub cboCriteria3_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCriteria3.SelectedValueChanged
        chkPartial3.Checked = False
        txtFrom3.Text = ""
        txtTo3.Text = ""
    End Sub

    Private Sub grdResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdResult.CellContentClick

    End Sub

    Private Sub cboCriteria1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCriteria1.SelectedIndexChanged

    End Sub
End Class