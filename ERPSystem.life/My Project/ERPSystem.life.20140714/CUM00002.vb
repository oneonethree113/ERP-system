Public Class CUM00002

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim EditModeHdr As String

    Dim CanModify As Boolean ' Check for access right

    Dim Current_TimeStamp As Long 'For current record's time stamp

    Dim sort_cusitm_sum As Boolean
    Dim sort_itmno_sum As Boolean

    Dim sort_cusitm_dtl As Boolean
    Dim sort_itmno_dtl As Boolean

    Dim rs_CUBASINF_CR As New DataSet
    Dim rs_SYTIESTR As New DataSet
    Dim rs_SYUSRRIGHT As New DataSet

    Public rs_CUBASINF As New DataSet
    Public rs_CUITMSUM As New DataSet

    Public rs_CUITMDTL As New DataSet

    Private Sub CUM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call AccessRight(Me.Name)

        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Cursor = Cursors.WaitCursor

        '*** Folder 1   **********
        txtCusNo.MaxLength = 6
        txtItmNo.MaxLength = 20
        txtCusNo.MaxLength = 20

        '*** Folder 2   **********

        CanModify = True

        Me.KeyPreview = True

        Call setStatus("Init")

        Call Formstartup(Me.Name)   'Set the form Sartup position

        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call setStatus("Clear")
        If txtCusItm.Text <> "" And txtCusItm.Enabled = True Then
            txtCusItm.SelectAll()
        ElseIf txtItmNo.Text <> "" And txtItmNo.Enabled = True Then
            txtItmNo.SelectAll()
        ElseIf txtCusNo.Enabled = True Then
            txtCusNo.SelectAll()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ResetDefaultDisp()
        txtCusNam.Text = ""
        txtSecSna.Text = ""
        chbAlias.Enabled = True
        chbAlias.Checked = True
        grdCuItmSum.DataSource = Nothing
        grdCuItmDtl.DataSource = Nothing

        StatusBar.Panels(0).Text = ""
        StatusBar.Panels(1).Text = ""
    End Sub

    Private Sub setStatus(ByVal Mode As String)
        If Mode = "Init" Then
            'Call SetInputBoxesStatus("DisableAll")
            cmdAdd.Enabled = Enq_right
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = Enq_right
            cmdFind.Enabled = True
            'CmdLookup.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True
            'cmdspecial.Enabled = False
            'cmdbrowlist.Enabled = True

            cmdAdd.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False

            txtCusNo.Enabled = True
            txtSecCus.Enabled = True
            txtCusNam.Enabled = False
            txtSecSna.Enabled = False
            txtItmNo.Enabled = True
            txtCusItm.Enabled = True
            txtCusStyNo.Enabled = True
            chbAlias.Enabled = False
            btcCUM00002.SelectedIndex = 0
            Call ResetDefaultDisp()

            '*** Enable key field(s) in header
            txtCusNo.Enabled = True

            cmdBrowse.Enabled = True
            cmdMapping.Enabled = True
        ElseIf Mode = "Updating" Then
            'Call SetInputBoxesStatus("EnableAll")
            cmdBrowse.Enabled = True
            cmdMapping.Enabled = True

            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right
            cmdDelete.Enabled = Del_right
            cmdCopy.Enabled = Enq_right
            cmdFind.Enabled = False
            'CmdLookup.Enabled = True
            cmdInsRow.Enabled = Enq_right
            cmdDelRow.Enabled = Del_right
            cmdExit.Enabled = True
            cmdClear.Enabled = True

            cmdSave.Enabled = False
            cmdDelete.Enabled = False

            txtCusNo.Enabled = False
            txtSecCus.Enabled = False
            txtCusNam.Enabled = False
            txtSecSna.Enabled = False
            txtItmNo.Enabled = False
            txtCusItm.Enabled = False
            txtCusStyNo.Enabled = False
            chbAlias.Enabled = False

            If EditModeHdr = "ADD" Then
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
            ElseIf EditModeHdr = "Updating" Then
                cmdAdd.Enabled = False
            End If

            grdCuItmSum.Focus()
            'grdCuItmSum_Click()
        ElseIf Mode = "Clear" Then
            Call ResetDefaultDisp()
            Call setStatus("Init")
            txtCusNo.SelectAll()
        End If

        'Check for access right
        If Not CanModify Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
        End If
    End Sub

    '*** Set which input boxes are disabled according to "Mode"
    Private Sub SetInputBoxesStatus(ByVal Mode As String)
        Dim v As Object

        If Mode = "EnableAll" Then
            '*** (1) If Mode = "EnableAll", enable all controls
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = True
                End If
            Next

            If EditModeHdr = "ADD" Then
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
            ElseIf EditModeHdr = "Updating" Then
                cmdAdd.Enabled = False
            End If
        ElseIf Mode = "DisableAll" Then
            '*** (2) If Mode = "DisableAll", disable all controls
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = False
                End If
            Next
        End If
    End Sub

    '*** check whether the object "v" is an input box
    Private Function IsInputBoxes(ByVal v As Object) As Boolean
        If (TypeOf v Is TextBox) Or (TypeOf v Is CheckBox) Or _
           (TypeOf v Is ComboBox) Or (TypeOf v Is Button) Or _
           (TypeOf v Is RichTextBox) Or _
           (TypeOf v Is ListBox) Or (TypeOf v Is RadioButton) Or _
           (TypeOf v Is DataGridView) Or (TypeOf v Is BaseTabControl) Or _
           (TypeOf v Is MaskedTextBox) Or (TypeOf v Is TabControl) Or _
           (TypeOf v Is GroupBox) Then
            IsInputBoxes = True
        Else
            IsInputBoxes = False
        End If
    End Function

    Private Sub btcCUM00002_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btcCUM00002.SelectedIndexChanged
        If btcCUM00002.SelectedIndex = 0 Then
            If grdCuItmSum.Enabled Then grdCuItmSum.Focus()
            'grdCuItmSum_Click()
        ElseIf btcCUM00002.SelectedIndex = 1 Then
            If grdCuItmDtl.Enabled Then grdCuItmDtl.Focus()
            'grdCuItmDtl_Click()
        End If
    End Sub

    Private Sub txtCusItm_GotFocus()
        txtCusItm.SelectAll()
    End Sub

    Private Sub txtCusItm_LostFocus()
        txtCusItm.Text = UCase(txtCusItm.Text)
    End Sub

    Private Sub txtCusNo_GotFocus()
        txtCusNo.SelectAll()
    End Sub

    Private Sub txtCusNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusNo.KeyPress
        If e.KeyChar = Chr(13) Then
            Call cmdFindClick()
        End If
    End Sub

    Private Sub txtCusNo_LostFocus()
        txtCusno.Text = UCase(txtCusno.Text)
    End Sub

    Private Sub txtItmNo_GotFocus()
        txtItmNo.SelectAll()
    End Sub

    Private Sub txtItmNo_LostFocus()
        txtItmNo.Text = UCase(txtItmNo.Text)
    End Sub

    Private Sub txtSecCus_GotFocus()
        txtSecCus.SelectAll()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Call cmdFindClick()
    End Sub

    Private Sub cmdFindClick()
        Dim lngDtl As Integer
        Dim lngSum As Integer
        lngDtl = 0
        lngSum = 0

        If (Trim(txtCusNo.Text) = "") Then
            txtCusNo.Focus()
            MsgBox("Please input Customer No.")
            Exit Sub
        End If

        '*** query Primary Customer
        'S = "㊣CUBASINF※S※" & txtCusNo.Text
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUBASINF '" & gsCompany & "','" & txtCusNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFindClick sp_select_CUBASINF 1 :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
            MsgBox("Customer Not Found!")
            txtCusNo.SelectAll()
            Exit Sub
        Else
            If gsSalTem <> rs_CUBASINF.Tables("RESULT").Rows(0)("ysr_saltem").ToString And _
                gsSalTem <> "" And gsSalTem <> "S" Then

                'S = "㊣SYUSRRIGHT_Check※S※" & gsUsrID & "※" & txtCusNo.Text & "※CU"
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gspStr = "sp_select_SYUSRRIGHT_Check '" & gsCompany & "','" & gsUsrID & "','" & txtCusNo.Text & "','CU'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFindClick sp_select_SYUSRRIGHT_Check :" & rtnStr)
                    Exit Sub
                End If

                If rs_SYUSRRIGHT.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("You have no Right access this document.")
                    Exit Sub
                End If
            End If

            txtCusNo.Text = rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_cusno")
            txtCusNam.Text = rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_cusnam_id")

            If txtSecCus.Text <> "" Then
                '*** query Secondary Customer
                'S = "㊣CUBASINF※S※" & txtSecCus.Text
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gspStr = "sp_select_CUBASINF '" & gsCompany & "','" & txtSecCus.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFindClick sp_select_CUBASINF 2 :" & rtnStr)
                    Exit Sub
                End If

                If rs_CUBASINF.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                    MsgBox("Customer Not Found!")
                    txtSecCus.SelectAll()
                    Exit Sub
                Else
                    txtSecSna.Text = rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_cusnam_id")
                End If
            End If

            StatusBar.Panels(1).Text = Format(rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_credat"), "MM/dd/yyyy") & " " & _
                                        Format(rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_upddat"), "MM/dd/yyyy") & " " & _
                                        rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_updusr")

            '***************************************************
            '*** Get Customer Details record  ******************
            '***************************************************
            Dim message As String = ""

            Cursor = Cursors.WaitCursor

            If chbAlias.Checked = False Then
                'S = "㊣CUITMDTL2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMDTL '" & gsCompany & "','" & _
                                                  txtItmNo.Text & "','" & _
                                                  txtCusItm.Text & "','" & _
                                                  txtSecCus.Text & "','" & _
                                                  txtCusNo.Text & "','" & _
                                                  txtCusStyNo.Text & "','" & _
                                                  gsFlgCst & "','" & _
                                                  gsFlgCstExt & "'"
                message = "sp_select_CUITMDTL"
            Else
                'S = "㊣CUITMDTL_alias2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMDTL_alias '" & gsCompany & "','" & _
                                                        txtItmNo.Text & "','" & _
                                                        txtCusItm.Text & "','" & _
                                                        txtSecCus.Text & "','" & _
                                                        txtCusNo.Text & "','" & _
                                                        txtCusStyNo.Text & "','" & _
                                                        gsFlgCst & "','" & _
                                                        gsFlgCstExt & "'"
                message = "sp_select_CUITMDTL_alias"
            End If
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            rtnLong = execute_SQLStatement(gspStr, rs_CUITMDTL, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFindClick " & message & " :" & rtnStr)
                Exit Sub
            End If

            '*** check record count
            lngDtl = rs_CUITMDTL.Tables("RESULT").DefaultView.Count
            '***************************************************
            '*** Get Customer Details record end ***************
            '***************************************************

            '***************************************************
            '*** Get Customer Summary record  ******************
            '***************************************************
            If chbAlias.Checked = False Then
                'S = "㊣CUITMSUM2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMSUM '" & gsCompany & "','" & _
                                                  txtItmNo.Text & "','" & _
                                                  txtCusItm.Text & "','" & _
                                                  txtSecCus.Text & "','" & _
                                                  txtCusNo.Text & "','" & _
                                                  txtCusStyNo.Text & "','" & _
                                                  gsFlgCst & "','" & _
                                                  gsFlgCstExt & "'"
                message = "sp_select_CUITMSUM"
            Else
                'S = "㊣CUITMSUM_alias2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMSUM_alias '" & gsCompany & "','" & _
                                                        txtItmNo.Text & "','" & _
                                                        txtCusItm.Text & "','" & _
                                                        txtSecCus.Text & "','" & _
                                                        txtCusNo.Text & "','" & _
                                                        txtCusStyNo.Text & "','" & _
                                                        gsFlgCst & "','" & _
                                                        gsFlgCstExt & "'"
                message = "sp_select_CUITMSUM_alias"
            End If
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            rtnLong = execute_SQLStatement(gspStr, rs_CUITMSUM, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFindClick " & message & " :" & rtnStr)
                Exit Sub
            End If

            '*** check record count
            lngSum = rs_CUITMSUM.Tables("RESULT").DefaultView.Count
            '***************************************************
            '*** Get Customer Summary record end ***************
            '***************************************************

            Call Display()
            Call setStatus("Updating")

            grdCuItmSum.Focus()
        End If

        If lngDtl = 0 And lngSum = 0 Then
            MsgBox("No record found!")
        End If
    End Sub

    Private Sub Display()
        '*** Folder 1
        'Retrieve MOQ/MOA
        Call cal_MOQMOA()

        grdCuItmSum.DataSource = rs_CUITMSUM.Tables("RESULT").DefaultView

        Call Display_grdCuItmSum()

        '*** Folder 2
        grdCuItmDtl.DataSource = rs_CUITMDTL.Tables("RESULT").DefaultView

        Call Display_grdCuItmDtl()
    End Sub

    Private Sub cal_MOQMOA()
        '*** A function to retrieve MOQ/MOA of each Item in record set
        If rs_CUITMSUM.Tables.Count = 0 Then Exit Sub
        If rs_CUITMSUM.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        Dim moq As Long
        Dim moa As Long
        Dim cur As String

        Call Update_gs_Value(GetDefaultCompany_CUM00002)

        'S = "㊣CUBASINF_P※S" & "※Currency Rate"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUBASINF_P '" & gsCompany & "','Currency Rate'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CR, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cal_MOQMOA sp_select_CUBASINF_P :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF_CR.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
            MsgBox("No Currency in System.")
            Exit Sub
        End If

        For index As Integer = 0 To rs_CUITMSUM.Tables("RESULT").DefaultView.Count - 1
            moq = 0
            moa = 0
            cur = ""

            'S = "㊣ItemMaster_moq_moa※S※" & Me.txtCusNo.Text & "※" & Me.txtSecCus.Text & "※" & rs_CUITMSUM("Item_No").Value & _
            '"※" & rs_CUITMSUM("U/M").Value & "※" & rs_CUITMSUM("U/M Factor").Value & "※" & rs_CUITMSUM("Master").Value & "※" & rs_CUITMSUM("Inner").Value
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gspStr = "sp_select_ItemMaster_moq_moa '" & gsCompany & "','" & _
                                                        txtCusNo.Text & "','" & _
                                                        txtSecCus.Text & "','" & _
                                                        rs_CUITMSUM.Tables("RESULT").DefaultView(index)("Item_No") & "','" & _
                                                        rs_CUITMSUM.Tables("RESULT").DefaultView(index)("U/M") & "','" & _
                                                        rs_CUITMSUM.Tables("RESULT").DefaultView(index)("U/M Factor") & "','" & _
                                                        rs_CUITMSUM.Tables("RESULT").DefaultView(index)("Master") & "','" & _
                                                        rs_CUITMSUM.Tables("RESULT").DefaultView(index)("Inner") & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYTIESTR, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cal_MOQMOA sp_select_ItemMaster_moq_moa :" & rtnStr)
                Exit Sub
            End If

            If rs_SYTIESTR.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No MOQ & MOA found of this Item")
            Else
                moq = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ")), 0, Val(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ")))
                cur = rs_CUITMSUM.Tables("RESULT").DefaultView(index)("CCY")

                If rs_CUITMSUM.Tables("RESULT").DefaultView(index)("CCY") <> rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE") And _
                    rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") > 0 Then
                    Dim dr() As DataRow

                    dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")
                    If rs_CUITMSUM.Tables("RESULT").DefaultView(index)("CCY") = dr(0)("ysi_cde") Then
                        dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE") & "'")
                        moa = Format(roundup(Val(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")) * dr(0)("ysi_selrat")), "#,###,##0")
                    Else
                        dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_CUITMSUM.Tables("RESULT").DefaultView(index)("CCY") & "'")
                        moa = Format(roundup(Val(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")) / dr(0)("ysi_selrat")), "#,###,##0")
                    End If
                Else
                    moa = Format(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA"), "#,###,##0")
                End If
            End If

            rs_CUITMSUM.Tables("RESULT").Columns("Comp MOQ").ReadOnly = False
            rs_CUITMSUM.Tables("RESULT").Columns("Comp MOA").ReadOnly = False
            rs_CUITMSUM.Tables("RESULT").Columns("Comp MOA Currency").ReadOnly = False
            rs_CUITMSUM.Tables("RESULT").DefaultView(index)("Comp MOQ") = IIf(moq = 0, "", CStr(moq))
            rs_CUITMSUM.Tables("RESULT").DefaultView(index)("Comp MOA") = IIf(moa = 0, "", Format(moa, "###,###,##0"))
            rs_CUITMSUM.Tables("RESULT").DefaultView(index)("Comp MOA Currency") = IIf(moa = 0, "", cur)
            rs_CUITMSUM.Tables("RESULT").Columns("Comp MOQ").ReadOnly = True
            rs_CUITMSUM.Tables("RESULT").Columns("Comp MOA").ReadOnly = True
            rs_CUITMSUM.Tables("RESULT").Columns("Comp MOA Currency").ReadOnly = True
        Next
    End Sub

    Public Function GetDefaultCompany_CUM00002() As String
        '*** Retrieve Default Company of User

        GetDefaultCompany_CUM00002 = IIf(gsCompany = "" Or gsCompany = "All", "UCPP", gsCompany)

        If rs_SYUSRPRF.Tables.Count = 0 Then Exit Function
        If rs_SYUSRPRF.Tables("RESULT").Rows.Count <= 0 Then Exit Function

        '*** Display Default Company *****
        For index As Integer = 0 To rs_SYUSRPRF.Tables("RESULT").Rows.Count
            If rs_SYUSRPRF.Tables("RESULT").Rows(index)("yuc_flgdef").ToString = "Y" Then
                GetDefaultCompany_CUM00002 = rs_SYUSRPRF.Tables("RESULT").Rows(index)("yuc_cocde")
                Exit Function
            End If
        Next
    End Function

    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

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

    Private Function roundup(ByVal Value As Double) As Double
        Dim tmp As String

        Value = round(Value, 5)
        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If Len(Microsoft.VisualBasic.Right(tmp, Len(tmp) - InStr(tmp, "."))) > 4 Then
                roundup = CDec(tmp) + 0.0001
                roundup = CDec(Microsoft.VisualBasic.Left(CStr(roundup), InStr(roundup, ".") + 4))
                Exit Function
            Else
                roundup = CDec(tmp)
                Exit Function
            End If
        Else
            roundup = CDec(tmp)
            Exit Function
        End If
    End Function

    Private Sub Display_grdCuItmSum()
        Dim col As Integer

        With grdCuItmSum
            For i As Integer = 0 To rs_CUITMSUM.Tables("RESULT").Columns.Count - 1
                .Columns(i).ReadOnly = True
            Next

            col = 0

            .Columns(col).Width = 60    'Company Code
            col = col + 1

            If chbAlias.Checked = True Then
                .Columns(col).Width = 60    'Pri. Cust (Previous)
                .Columns(col).Visible = True
            Else
                .Columns(col).Width = 0    'Pri. Cust (Previous)
                .Columns(col).Visible = False
            End If

            col = col + 1
            .Columns(col).Width = 80    'Sec. Cust.
            col = col + 1

            If chbAlias.Checked = True Then
                .Columns(col).Width = 85    'Sec. Cust. (Previous)
                .Columns(col).Visible = True
            Else
                .Columns(col).Width = 0    'Sec. Cust. (Previous)
                .Columns(col).Visible = False
            End If

            col = col + 1
            .Columns(col).Width = 100   'Sec. Cust. Name
            col = col + 1
            .Columns(col).Width = 100   'Cust_Item_No
            col = col + 1
            .Columns(col).Width = 100   'Item_No
            col = col + 1
            .Columns(col).Width = 100   'Cust_Style_No
            col = col + 1
            .Columns(col).Width = 100   'Fty_Temp_No
            col = col + 1
            .Columns(col).Width = 80    'Item Status
            col = col + 1
            .Columns(col).Width = 100   'Ven_Item_No
            col = col + 1
            .Columns(col).Width = 80    'Vendor Status
            col = col + 1
            .Columns(col).Width = 120   'Item Desc.
            col = col + 1
            .Columns(col).Width = 60    'Color Code
            col = col + 1
            .Columns(col).Width = 120   'Color Desc.
            col = col + 1
            .Columns(col).Width = 40    'CCY
            col = col + 1
            .Columns(col).HeaderText = "Basic Price (I/M)"
            .Columns(col).Width = 80
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 60    'Selling Price
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).HeaderText = "QU Period"
            .Columns(col).Width = 70
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 70    'MOQ Charges %
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 90    'Price Key - Cust 1
            col = col + 1
            .Columns(col).Width = 90    'Price Key - Cust 2
            col = col + 1
            .Columns(col).Width = 110   'Price Key - HK Price Term
            col = col + 1
            .Columns(col).Width = 110   'Price Key - FTY Price Term
            col = col + 1
            .Columns(col).Width = 110   'Price Key - Transport Term
            col = col + 1
            .Columns(col).Width = 100   'Price Key - Effective Date
            .Columns(col).DefaultCellStyle.Format = "MM/dd/yyyy"
            col = col + 1
            .Columns(col).Width = 100   'Price Key - Expiry Date
            .Columns(col).DefaultCellStyle.Format = "MM/dd/yyyy"
            col = col + 1
            .Columns(col).Width = 90    'Net Selling Price
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 50    'Factory CCY
            col = col + 1
            .Columns(col).Width = 50    'Factory Cost
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).HeaderText = "Item Cost"
            .Columns(col).Width = 50
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 40    'Comp MOQ
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 90    'Comp MOA Currency
            col = col + 1
            .Columns(col).Width = 80    'Comp MOA
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 70    'CIH MOQ
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 80    'CIH MOQ Unt
            col = col + 1
            .Columns(col).Width = 80    'CIH MOA Currency
            col = col + 1
            .Columns(col).Width = 70    'CIH MOA
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 50    'U/M
            col = col + 1
            .Columns(col).Width = 50    'Inner
            col = col + 1
            .Columns(col).Width = 50    'Master
            col = col + 1
            .Columns(col).Width = 50    'CFT
            col = col + 1
            .Columns(col).Width = 50    'CBM
            col = col + 1
            .Columns(col).Width = 80    'Cust. SKU No.
            col = col + 1
            .Columns(col).Width = 70    'Ref. Doc.
            col = col + 1
            .Columns(col).Width = 90    'Last Doc. Date
            .Columns(col).DefaultCellStyle.Format = "MM/dd/yyyy"
            col = col + 1
            .Columns(col).Width = 90    'Custom Color
            col = col + 1
            .Columns(col).Width = 70    'HSTY / Tariff #
            col = col + 1
            .Columns(col).Width = 50    'Duty %
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Department
            col = col + 1
            .Columns(col).Width = 50    'EAN or UPC
            col = col + 1
            .Columns(col).Width = 100   'Code 1
            col = col + 1
            .Columns(col).Width = 100   'Code 2
            col = col + 1
            .Columns(col).Width = 100   'Code 3
            col = col + 1
            .Columns(col).Width = 100   'Customer Retail (USD)
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 100   'Customer Retail (CAD)
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 70    'Inner L (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner W (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner H (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master L (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master W (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master H (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner L (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner W (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner H (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master L (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master W (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master H (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 60    'Order Qty
            col = col + 1
            .Columns(col).Width = 100   'Packing Instruction
            col = col + 1
            .Columns(col).Width = 60    'U/M Factor
            col = col + 1
            .Columns(col).Width = 60    'Convert To PC
            col = col + 1
            .Columns(col).Width = 70    'Price For PC
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 100    'Create Date
            col = col + 1
            .Columns(col).Width = 100    'Update Date
            col = col + 1
        End With
    End Sub

    Private Sub Display_grdCuItmDtl()
        Dim col As Integer

        With grdCuItmDtl
            For i As Integer = 0 To rs_CUITMDTL.Tables("RESULT").Columns.Count - 1
                .Columns(i).ReadOnly = True
            Next

            col = 0

            .Columns(col).Width = 60    'Company Code
            col = col + 1

            If chbAlias.Checked = True Then
                .Columns(col).Width = 60    'Pri. Cust (Previous)
                .Columns(col).Visible = True
            Else
                .Columns(col).Width = 0    'Pri. Cust (Previous)
                .Columns(col).Visible = False
            End If

            col = col + 1
            .Columns(col).Width = 80    'Sec. Cust.
            col = col + 1

            If chbAlias.Checked = True Then
                .Columns(col).Width = 85    'Sec. Cust. (Previous)
                .Columns(col).Visible = True
            Else
                .Columns(col).Width = 0    'Sec. Cust. (Previous)
                .Columns(col).Visible = False
            End If

            col = col + 1
            .Columns(col).Width = 100   'Sec. Cust. Name
            col = col + 1
            .Columns(col).Width = 100   'Cust_Item_No
            col = col + 1
            .Columns(col).Width = 100   'Item_No
            col = col + 1
            .Columns(col).HeaderText = "Cust_Style_No"
            .Columns(col).Width = 100   'Cust. Style No.
            col = col + 1
            .Columns(col).HeaderText = "Fty_Temp_No"
            .Columns(col).Width = 100   'Fty Temp No
            col = col + 1
            .Columns(col).Width = 80    'Cust. SKU No.
            col = col + 1
            .Columns(col).Width = 120   'Item Desc.
            col = col + 1
            .Columns(col).HeaderText = "Color Code"
            .Columns(col).Width = 60    'Color_Code
            col = col + 1
            .Columns(col).Width = 120    'Color Desc.
            col = col + 1
            .Columns(col).Width = 120   'Cust. Color Code
            col = col + 1
            .Columns(col).Width = 70   'Ref. Doc.
            col = col + 1
            .Columns(col).Width = 90   'Last Doc. Date
            .Columns(col).DefaultCellStyle.Format = "MM/dd/yyyy"
            col = col + 1
            .Columns(col).Width = 60    'Order Qty
            col = col + 1
            .Columns(col).Width = 40    'OTP
            col = col + 1
            .Columns(col).Width = 40    'CCY
            col = col + 1
            .Columns(col).Width = 60   'Selling Price
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 70   'MOQ Charges
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 90   'Price Key - Cust 1
            col = col + 1
            .Columns(col).Width = 90   'Price Key - Cust 2
            col = col + 1
            .Columns(col).Width = 110   'Price Key - HK Price Term
            col = col + 1
            .Columns(col).Width = 110   'Price Key - FTY Price Term
            col = col + 1
            .Columns(col).Width = 110   'Price Key - Transport Term
            col = col + 1
            .Columns(col).Width = 100   'Price Key - Effective Date
            .Columns(col).DefaultCellStyle.Format = "MM/dd/yyyy"
            col = col + 1
            .Columns(col).Width = 100   'Price Key - Expiry Date
            .Columns(col).DefaultCellStyle.Format = "MM/dd/yyyy"
            col = col + 1
            .Columns(col).Width = 90    'Net Selling Price
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 50    'Factory CCY
            col = col + 1
            .Columns(col).HeaderText = "Item Cost"
            .Columns(col).Width = 50
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 50    'Factory Price
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 50    'UM
            col = col + 1
            .Columns(col).Width = 50    'Inner
            col = col + 1
            .Columns(col).Width = 50    'Master
            col = col + 1
            .Columns(col).Width = 50    'CFT
            col = col + 1
            .Columns(col).Width = 50    'CBM
            col = col + 1
            .Columns(col).HeaderText = "QU Period"
            .Columns(col).Width = 70
            col = col + 1
            .Columns(col).Width = 70    'HSTU / Tariff #
            col = col + 1
            .Columns(col).Width = 50   'Duty %
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70   'Dept.
            col = col + 1
            .Columns(col).Width = 50   'EAN or UPC
            col = col + 1
            .Columns(col).Width = 100   'Code 1
            col = col + 1
            .Columns(col).Width = 100   'Code 2
            col = col + 1
            .Columns(col).Width = 100   'Code 3
            col = col + 1
            .Columns(col).Width = 100    'Customer Retail (USD)
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 100    'Customer Retail (CAD)
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 70    'Inner L (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner W (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner H (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master L (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master W (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master H (cm)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner L (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner W (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Inner H (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master L (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master W (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 70    'Master H (in)
            .Columns(col).DefaultCellStyle.Format = "#0.##"
            col = col + 1
            .Columns(col).Width = 100   'Packing Instruction
            col = col + 1
            .Columns(col).Width = 60   'U/M Factor
            col = col + 1
            .Columns(col).Width = 60   'Convert To PC
            col = col + 1
            .Columns(col).Width = 70   'Price For PC
            .Columns(col).DefaultCellStyle.Format = "#0.####"
            col = col + 1
            .Columns(col).Width = 40   'Seq
            col = col + 1
            .Columns(col).Width = 100   'Create Date
            col = col + 1
        End With
    End Sub

    Private Sub grdCuItmDtl_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdCuItmDtl.ColumnHeaderMouseClick
        If e.ColumnIndex = 5 Then
            If sort_cusitm_dtl = False Then
                rs_CUITMDTL.Tables("RESULT").DefaultView.Sort = "Cust_Item_No, [Cust.Color Code], UM, Inner, Master, Seq desc"
                sort_cusitm_dtl = True
            Else
                rs_CUITMDTL.Tables("RESULT").DefaultView.Sort = "Cust_Item_No desc, [Cust.Color Code], UM, Inner, Master, Seq desc"
                sort_cusitm_dtl = False
            End If
        ElseIf e.ColumnIndex = 6 Then
            If sort_itmno_dtl = False Then
                rs_CUITMDTL.Tables("RESULT").DefaultView.Sort = "Item_No, Color_Code, UM, Inner, Master, Seq desc"
                sort_itmno_dtl = True
            Else
                rs_CUITMDTL.Tables("RESULT").DefaultView.Sort = "Item_No desc, Color_Code, UM, Inner, Master, Seq desc"
                sort_itmno_dtl = False
            End If
        End If
    End Sub

    Private Sub grdCuItmSum_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdCuItmSum.ColumnHeaderMouseClick
        If e.ColumnIndex = 5 Then
            If sort_cusitm_sum = False Then
                rs_CUITMSUM.Tables("RESULT").DefaultView.Sort = "Cust_Item_No"
                sort_cusitm_sum = True
            Else
                rs_CUITMSUM.Tables("RESULT").DefaultView.Sort = "Cust_Item_No desc"
                sort_cusitm_sum = False
            End If

        ElseIf e.ColumnIndex = 6 Then
            If sort_itmno_sum = False Then
                rs_CUITMSUM.Tables("RESULT").DefaultView.Sort = "Item_No"
                sort_itmno_sum = True
            Else
                rs_CUITMSUM.Tables("RESULT").DefaultView.Sort = "Item_No desc"
                sort_itmno_sum = False
            End If
        End If
    End Sub

    Private Sub cmdMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMapping.Click
        gsSearchKey = ""
        If txtItmNo.Text <> "" Then
            Dim frm_SYM00022 As New SYM00022(txtItmNo.Text)

            frm_SYM00022.MdiParent = Me.MdiParent

            If domapping_value = 1 Then
                frm_SYM00022.Show()
                AddHandler frm_SYM00022.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
            End If
        End If
    End Sub

    Private Sub returnSelectedRecordsHandler(ByVal sender As Object)
        If Len(gsSearchKey) > 0 And txtItmNo.Enabled = True Then
            txtItmNo.Text = gsSearchKey
            txtItmNo.Refresh()
            txtCusItm.Focus()
        End If
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        gsSearchKey = ""
        If txtItmNo.Text <> "" Then
            Dim frm_SYM00021 As New SYM00021(txtItmNo.Text)

            frm_SYM00021.MdiParent = Me.MdiParent

            If SYM00021_Value = 1 Then
                frm_SYM00021.Show()
                AddHandler frm_SYM00021.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
            End If
        End If
    End Sub
End Class