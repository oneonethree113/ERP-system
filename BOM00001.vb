Public Class BOM00001
    Dim BOMReport As POR00003

    Public rs_POBOMHDR As DataSet
    Public rs_POBOMDTL As DataSet
    Public rs_SYSETINF As DataSet
    Public rs_CVNCNTINF As DataSet
    Public rs_SYUSRRIGHT As DataSet

    Public rs_VNCNTINF As DataSet    'Lester Wu Vendor Contact Address

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim IsUpdated As Boolean
    Dim save_ok As Boolean
    Dim Current_TimeStamp As Long
    Dim Recordstatus As Boolean
    Dim flag_displayDetail As Boolean

    Dim befVenAddr As String    'Lester Wu 2004/10/04 Vendor Address Before Change
    ' Added by Joe 20100513
    Public strModule As String

    '===
    Dim current_row As Integer
    Dim PreviousTab As Integer
    Dim default_date As Date = Format(DateTime.Parse("01/01/1900"), "MM/dd/yyyy")

    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        'If checkFocus(Me) Then Exit Sub
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        If txtBOMNo.Text = "" Then
            MsgBox("Please Input the BOM PO No.") 'msg("M00439")
            Exit Sub
        End If


        'S = "㊣POBOMHDR※S※" & txtBOMNo.Text & _
        '    "㊣POBOMDTL※L※" & txtBOMNo.Text

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = "sp_list_POBOMDTL '" & gsCompany & "','" & txtBOMNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POBOMDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BOM00001 mmdFind_Click sp_list_POBOMDTL : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_POCNTINF = CopyRS(rs(1))
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = "sp_select_POBOMHDR '" & gsCompany & "','" & txtBOMNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POBOMHDR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BOM00001 mmdFind_Click sp_select_POBOMHDR : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_POCNTINF = CopyRS(rs(1))
        End If


        If rs_POBOMHDR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!") 'msg("M00097")
        Else

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            gspStr = "sp_select_SYUSRRIGHT_Check '" & gsCompany & "','" & gsUsrID & "','" & rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_purord") & "','" & strModule & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading BOM00001 mmdFind_Click sp_select_SYUSRRIGHT_Check : " & rtnStr)
                Exit Sub
            Else
                If rs_SYUSRRIGHT.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("You have no Right access this document.") 'msg("M00371")
                    Exit Sub
                Else

                    'MsgBox(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_timstp"))

                    Current_TimeStamp = BitConverter.ToInt64(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_timstp"), 0)
                    Call Display()
                    Call FillContactPerson()
                    Call display_combo(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ctp1"), cboCtp1)
                    Call display_combo(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ctp2"), cboCtp2)
                    Call setStatus("Updating")
                    grdSummary.DataSource = rs_POBOMDTL.Tables("RESULT").DefaultView
                    Call Display_Summary()
                    If gsUsrRank <= 4 Then
                        txtDisPrc.Enabled = True
                    End If
                    Recordstatus = False
                    Call displayStatusBar(0)   'Lester Wu 2004/09/17 Display Create Date, Update Date & Create User
                End If
            End If


        End If

    End Sub

    Private Sub BOM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strModule = "PO"
        'Me.Icon = ERP00000.Icon

        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)

        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001 'AccessRight_1 (Me.Name)

        Enq_right_local = Enq_right
        Del_right_local = Del_right
        Call Formstartup(Me.Name)
        cboBOMStatus.Items.Add("OPE - OPEN")
        cboBOMStatus.Items.Add("CLO - Closed")
        cboBOMStatus.Items.Add("CAN - Cancel")

        Dim S As String
        Dim rs() As ADOR.Recordset

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = "sp_list_SYSETINF '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BOM00001 BOM00001_Load sp_select_SCORDHDRR : " & rtnStr)
            Exit Sub
        Else
            If rs_SYSETINF.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No Record in SYSTEMINF") 'msg("M00110")
                Call setStatus("Init")
                Exit Sub
            Else
                Call fillcountry()

                Call fillcboPayTrm()
                Call fillcboPrcTrm()
            End If
        End If

        'Timer1.Enabled = False
        Me.KeyPreview = True
        Me.TabPageMain.SelectedIndex = 0
        Call setStatus("Init")
        Me.Cursor = Windows.Forms.Cursors.Default


    End Sub

    Private Sub setStatus(ByVal Mode As String)
        If Mode = "Init" Then
            cboVenAddr.Text = ""
            Me.cboVenAddr.Items.Clear() 'Lester Wu Clear Vendor Address Dropdown Menu

            txtBOMNo.Enabled = True
            Me.TabPageMain.SelectedIndex = 0
            freeze_TabControl(-1) 'SSTab1.Enabled = False
            'Call SetStatusBar(Mode)
            cboCoCde.Enabled = True
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdCopy.Enabled = False
            mmdInsRow.Enabled = False

            mmdDelete.Enabled = False
            mmdDelRow.Enabled = False


            'mmdAdd.Enabled = True
            'mmdCopy.Enabled = True
            mmdFind.Enabled = True
            'CmdLookup.Enabled = False

            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = True
            'cmdspecial.Enabled = False
            'cmdbrowlist.Enabled = False

            'cmdfirst.Enabled = False
            'cmdlast.Enabled = False
            'cmdNext.Enabled = False
            'cmdPrv.Enabled = False
            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False
            txtDisPrc.Enabled = False
            cboCtp1.Text = ""
            cboCtp1.Items.Clear()
            Call ClearScreen()
            Recordstatus = False

            current_row = 0

        ElseIf Mode = "Updating" Then

            If gsUsrRank <= 4 Then
                txtDisPrc.Enabled = True
            End If

            mmdFind.Enabled = False
            mmdSearch.Enabled = False
            cboCoCde.Enabled = False

            txtBOMNo.Enabled = False
            Dim drAccess() As DataRow = rs_SYUSRGRP_right.Tables("RESULT").Select("yug_usrfun = 'POR00003' and yug_usrgrp = '" & gsUsrGrp & "'")
            If drAccess.Length = 0 Then
                mmdPrint.Enabled = False
            Else
                mmdPrint.Enabled = True
            End If
            release_TabControl() 'SSTab1.Enabled = True

            mmdSave.Enabled = Enq_right_local

        ElseIf Mode = "Save" Then

            Call setStatus("Init")
            MsgBox("Record Saved!") 'msg("M00025")
            txtBOMNo.Focus()

        End If

    End Sub
    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            If i = tabpageno Then
                Me.TabPageMain.TabPages(i).Enabled = True
            Else
                Me.TabPageMain.TabPages(i).Enabled = False
            End If
        Next i
    End Sub

    Private Sub release_TabControl()
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            Me.TabPageMain.TabPages(i).Enabled = True
        Next i
    End Sub
    Private Sub ClearScreen()

        Call display_combo("", cboBOMStatus)
        DTIssDat.Text = Format(Now, "MM/dd/yyyy")
        DTRevDat.Text = Format(Now, "MM/dd/yyyy")
        txtBVenno.Text = ""
        txtRmtAdr.Text = ""
        Call display_combo("", cboBVCty)
        txtBVStt.Text = ""
        txtBVPst.Text = ""
        txtCur1.Text = ""
        txtCur2.Text = ""
        txtTtlAmt.Text = ""
        txtDisPrc.Text = ""

        txtOriVen.Text = ""

        txtOriPO.Text = ""
        txtOPOCanDat.Text = ""
        txtOPOShpStr.Text = ""
        txtOPOShpEnd.Text = ""

        txtShpAdr.Text = ""
        Call display_combo("", cboOVCty)
        txtOVStt.Text = ""
        txtOVPst.Text = ""
        txtNetAmt.Text = ""

        Call display_combo("", cboPrcTrm)
        Call display_combo("", cboPayTrm)

        txtCpoDat.Text = Format(Now, "MM/dd/yyyy")
        txtRefno.Text = ""
        txtCusPo.Text = ""

        txtCanDat.Text = Format(Now, "MM/dd/yyyy")
        txtShpStr.Text = Format(Now, "MM/dd/yyyy")
        txtShpEnd.Text = Format(Now, "MM/dd/yyyy")
        txtRmk.Text = ""


    End Sub
    Private Sub fillcountry()


        Dim drSYSETINF() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='02'", "ysi_cde")
        If drSYSETINF.Length() > 0 Then
            For i As Integer = 0 To drSYSETINF.Length() - 1
                cboBVCty.Items.Add(drSYSETINF(i).Item("ysi_cde") & " - " & drSYSETINF(i).Item("ysi_dsc"))
                cboOVCty.Items.Add(drSYSETINF(i).Item("ysi_cde") & " - " & drSYSETINF(i).Item("ysi_dsc"))
            Next

        End If
    End Sub

    Private Sub fillcboPayTrm()


        Dim drSYSETINF() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='04'", "ysi_cde")
        If drSYSETINF.Length() <> 0 Then
            For i As Integer = 0 To drSYSETINF.Length() - 1
                cboPayTrm.Items.Add(drSYSETINF(i).Item("ysi_cde") & " - " & drSYSETINF(i).Item("ysi_dsc"))
            Next
        End If
    End Sub

    Private Sub fillcboPrcTrm()



        Dim drSYSETINF() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='03'", "ysi_cde")
        If drSYSETINF.Length() <> 0 Then
            For i As Integer = 0 To drSYSETINF.Length() - 1
                cboPrcTrm.Items.Add(drSYSETINF(i).Item("ysi_cde") & " - " & drSYSETINF(i).Item("ysi_dsc"))
            Next
        End If
    End Sub

    Private Sub Display()

        Call display_combo(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_bomsts"), cboBOMStatus)
        DTIssDat.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_issdat")), "MM/dd/yyyy")
        'DTRevDat.Value = rs_POBOMHDR("pbh_rvsdat").Value
        DTRevDat.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_rvsdat")), "MM/dd/yyyy")
        txtBVenno.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_bvenno") & " - " & rs_POBOMHDR.Tables("RESULT").Rows(0).Item("vbi_vensna1")
        '----------------------------------------------
        Call Display_VenAddr()    'Lester Wu 2004/09/28
        If rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_bomsts") = "OPE" Then
            Me.cboVenAddr.Enabled = True
        Else
            Me.cboVenAddr.Enabled = False
        End If
        '----------------------------------------------
        txtRmtAdr.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_bvenadr")
        Call display_combo(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_bvencty"), cboBVCty)
        txtBVStt.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_bvenstt")
        txtBVPst.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_bvenpst")
        txtCur1.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_curcde")
        txtCur2.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_curcde")
        txtTtlAmt.Text = Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ttlamt"), "######0.00")
        txtDisPrc.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_disprc")

        txtOriVen.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_oriven") & " - " & rs_POBOMHDR.Tables("RESULT").Rows(0).Item("vbi_vensna2")

        txtOriPO.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_purord")
        'txtOPOCanDat.Text = Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ocndat") , "MM/dd/yyyy")
        txtOPOCanDat.Text = IIf(Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ocndat")), "MM/dd/yyyy") = "01/01/1900", "", Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ocndat"), "MM/dd/yyyy"))

        txtOPOShpStr.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ostdat")), "MM/dd/yyyy")
        txtOPOShpEnd.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_oeddat")), "MM/dd/yyyy")

        txtShpAdr.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpadr")
        Call display_combo(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ovencty"), cboOVCty)
        txtOVStt.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ovenstt")
        txtOVPst.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_ovenpst")
        txtNetAmt.Text = Format(txtTtlAmt.Text - roundup((txtTtlAmt.Text * txtDisPrc.Text) / 100), "######0.00")


        Call display_combo(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_prctrm"), cboPrcTrm)
        Call display_combo(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_paytrm"), cboPayTrm)

        txtCpoDat.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_cpodat")), "MM/dd/yyyy")
        txtRefno.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_refno")
        txtCusPo.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_cuspo")
        txtCanDat.Text = IIf(Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat"), "MM/dd/yyyy") = "01/01/1900", "", Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat"), "MM/dd/yyyy")) 'Lester Wu 2004/09/17 show empty for Null Cancel Date

        'TextBox1.Text = txtCanDat.Text

        txtShpStr.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpstr")), "MM/dd/yyyy")
        txtShpEnd.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpend")), "MM/dd/yyyy")
        txtRmk.Text = rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_rmk")

        If rs_POBOMDTL.Tables("RESULT").Rows.Count > 0 Then
            'rs_POBOMDTL.MoveFirst()
            Call DisplayBOMDetail()


            checkBackNext()
            'If rs_POBOMDTL.AbsolutePosition <> rs_POBOMDTL.recordCount Then
            '    CmdDtlNext.Enabled = True
            'Else
            '    CmdDtlNext.Enabled = False
            'End If

        End If

    End Sub
    Public Function roundup(ByVal Value As Double) As Double
        Dim tmp As String

        Value = round(Value, 5)

        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If Len(Strings.Right(tmp, Len(tmp) - InStr(tmp, "."))) > 4 Then
                roundup = CDec(tmp) + 0.0001
                roundup = CDec(Strings.Left(CStr(roundup), InStr(roundup, ".") + 4))
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
    Public Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String
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

    Private Sub Display_VenAddr()

        Dim venno As String
        cboVenAddr.Items.Clear()
        If Me.txtBVenno.Text = "" Then Exit Sub
        venno = Trim(Strings.Left(Me.txtBVenno.Text, InStr(Me.txtBVenno.Text, " - ")))
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_list_VNCNTINF '" & gsCompany & "','" & venno & "','M','ADR'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BOM00001 Display_VenAddr sp_list_VNCNTINF : " & rtnStr)
            Exit Sub
        ElseIf rs_VNCNTINF.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No vendor address found!")
            Exit Sub
        End If
        Me.cboVenAddr.Items.Add("")
        For i As Integer = 0 To rs_VNCNTINF.Tables("RESULT").Rows.Count - 1
            Me.cboVenAddr.Items.Add(Trim(rs_VNCNTINF.Tables("RESULT").Rows(i).Item("vci_adr")))
        Next

    End Sub

    Private Sub FillContactPerson()
        gspStr = "sp_list_CVNCNTINF '" & gsCompany & "','" & Split(txtBVenno.Text, " - ")(0) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CVNCNTINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BOM00001 FillContactPerson rs_CVNCNTINF : " & rtnStr)
            Exit Sub
        Else
            '    rs_CVNCNTINF = CopyRS(rs(1))
        End If

        If rs_CVNCNTINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_CVNCNTINF.Tables("RESULT").Rows.Count - 1
                cboCtp1.Items.Add(rs_CVNCNTINF.Tables("RESULT").Rows(i).Item("vci_cntctp"))
                cboCtp2.Items.Add(rs_CVNCNTINF.Tables("RESULT").Rows(i).Item("vci_cntctp"))
            Next

        End If

    End Sub
    Private Sub Display_Summary()
        Dim X As Integer
        With grdSummary

            'While X < rs_POBOMDTL.Tables("RESULT").Columns.Count
            '    grdSummary.Columns(X).Width = 0
            '    '        grdSummary.AllowUpdate = False
            '    'grdSummary.Columns(X).Locked = True
            '    X = X + 1
            'End While
            For X = 0 To rs_POBOMDTL.Tables("RESULT").Columns.Count - 1
                .Columns(X).Visible = False
            Next

            '.Columns(0).width = 0

            .Columns(2).Visible = True
            .Columns(2).Width = 40 '.Columns(2).width = 500
            .Columns(2).HeaderCell.Value = "SEQ"

            .Columns(4).Visible = True
            '.Columns(4).width = 1500
            .Columns(4).HeaderCell.Value = "Vendor Item No."

            .Columns(5).Visible = True
            '.Columns(5).width = 1500
            .Columns(5).HeaderCell.Value = "Original Item #"

            .Columns(6).Visible = True
            '.Columns(6).width = 1500
            .Columns(6).HeaderCell.Value = "Assorted Item #"

            .Columns(7).Visible = True
            '.Columns(7).width = 1000
            .Columns(7).HeaderCell.Value = "Color Code"

            .Columns(8).Visible = True
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns(8).width = 1500
            .Columns(8).HeaderCell.Value = "Adjusted Order Qty"

            .Columns(9).Visible = True
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns(9).width = 1000
            .Columns(9).HeaderCell.Value = "Order Qty"

            .Columns(10).Visible = True
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns(10).width = 1000
            .Columns(10).HeaderCell.Value = "Currency"

            .Columns(11).Visible = True
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns(11).width = 1300
            .Columns(11).HeaderCell.Value = "Negotiated Price"

            .Columns(12).Visible = True
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns(12).width = 1200
            .Columns(12).HeaderCell.Value = "BOM Fty Cost"

            .Columns(13).Visible = True
            '.Columns(13).width = 1500
            .Columns(13).HeaderCell.Value = "Ship Start Date"

            .Columns(14).Visible = True
            '.Columns(14).width = 1500
            .Columns(14).HeaderCell.Value = "Ship End Date"

            .Columns(15).Visible = True
            '.Columns(15).width = 1500
            .Columns(15).HeaderCell.Value = "Cancel Date"

            .Columns(0).Visible = False
        End With

    End Sub

    Private Sub displayStatusBar(ByVal Index As Integer)
        'Lester Wu 2004/09/17 Display Create Date, Update Date & Create User
        Select Case Index
            Case 0
                If rs_POBOMHDR Is Nothing Then Exit Sub
                If rs_POBOMHDR.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
                StatusBar.Items("lblRight2").Text = Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_credat"), "MM/dd/yyyy") & " " & Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_upddat"), "MM/dd/yyyy") & " " & rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_creusr")
                '    Case 1
                '        If rs_POBOMDTL Is Nothing Then Exit Sub
                '        If rs_POBOMDTL.recordCount <= 0 Then Exit Sub
                '        If rs_POBOMDTL.BOF Or rs_POBOMDTL.EOF Then Exit Sub
                '        StatusBar.Panels(2).Text = Format(rs_POBOMDTL("pbd_credat"), "MM/dd/yyyy") & " " & Format(rs_POBOMDTL("pbd_upddat"), "MM/dd/yyyy") & " " & rs_POBOMDTL("pbd_creusr")
                '    Case 2
                '        If rs_POBOMDTL Is Nothing Then Exit Sub
                '        If rs_POBOMDTL.recordCount <= 0 Then Exit Sub
                '        If rs_POBOMDTL.BOF Or rs_POBOMDTL.EOF Then Exit Sub
                '        StatusBar.Panels(2).Text = Format(rs_POBOMDTL("pbd_credat"), "MM/dd/yyyy") & " " & Format(rs_POBOMDTL("pbd_upddat"), "MM/dd/yyyy") & " " & rs_POBOMDTL("pbd_creusr")
        End Select
    End Sub
    Private Sub checkBackNext()
        If rs_POBOMDTL.Tables("RESULT").Rows.Count <= 0 Then
            CmdDtlPre.Enabled = False
            CmdDtlNext.Enabled = False
        Else
            If current_row = 0 Then
                CmdDtlPre.Enabled = False
            Else
                CmdDtlPre.Enabled = True
            End If

            If current_row = rs_POBOMDTL.Tables("RESULT").Rows.Count - 1 Then
                CmdDtlNext.Enabled = False
            Else
                CmdDtlNext.Enabled = True
            End If
        End If


    End Sub
    Private Sub DisplayBOMDetail()
        flag_displayDetail = True

        txtBomSeq.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_bomseq")
        txtItmNo.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_itmno")
        txtVenitm.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_venitm")
        txtRVenItm.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_rvenitm")
        txtEngDsc.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_engdsc")
        If Not rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_chndsc") Is Nothing Then
            txtChnDsc.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_chndsc")
        End If

        txtVenCol.Text = ""
        If Not rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_vencol") Is Nothing Then
            txtVenCol.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_vencol")
        End If
        txtVcoDsc.Text = ""
        If Not rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_vcodsc") Is Nothing Then
            txtVcoDsc.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_vcodsc")
        End If
        txtAdjQty.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_adjqty")
        txtOrdQty.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_ordqty")
        txtCur3.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbh_curcde")
        txtCur4.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbh_curcde")
        txtCur5.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbh_curcde")

        'txtFtyPrc.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).item("pbd_ftyprc") 
        txtFtyPrc.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_bomcst")
        txtUntCde.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_untcde")
        txtNegPrc.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_negprc")

        txtWastage.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_wastage")
        txtOrgOrdQty.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_orgordqty")

        txtDShpStr.Text = Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_shpstr")), "MM/dd/yyyy")
        txtDShpEnd.Text = Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_shpend")), "MM/dd/yyyy")



        If Not IsDate(rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_candat")) Then
            txtDCanDat.Text = ""
        Else
            txtDCanDat.Text = Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_candat")), "MM/dd/yyyy")
        End If


        txtRegItm.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_regitm")
        txtAssItm.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_assitm")
        txtEngRid.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_engrid")
        txtChnRid.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_chnrid")
        txtColCde.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_colcde")
        If Not rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_coldsc") Is Nothing Then
            txtColDsc.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_coldsc")
        End If
        txtRioQty.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_rioqty")
        txtPqBOM.Text = rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_pqbom")

        flag_displayDetail = False

    End Sub



    Private Sub CmdDtlPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlPre.Click

        Update_BOMDtl()
        If current_row = 0 Then
            'msgbox("should not happen")
        Else
            CmdDtlNext.Enabled = True
            current_row = current_row - 1
            checkBackNext()
        End If
        DisplayBOMDetail()

    End Sub

    Private Sub CmdDtlNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlNext.Click
        Update_BOMDtl()
        If current_row = rs_POBOMDTL.Tables("RESULT").Rows.Count - 1 Then
            'msgbox("should not happen")
        Else
            CmdDtlNext.Enabled = True
            current_row = current_row + 1
            checkBackNext()
        End If
        DisplayBOMDetail()
    End Sub

    Private Sub Update_BOMDtl()
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_adjqty").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_negprc").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_rvenitm").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_candat").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_shpstr").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_shpend").ReadOnly = False

        If Trim(txtBOMNo.Text) <> "" Then
            rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_adjqty") = txtAdjQty.Text
            rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_negprc") = txtNegPrc.Text
            rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_rvenitm") = txtRVenItm.Text
            rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_candat") = txtDCanDat.Text
            rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_shpstr") = txtDShpStr.Text
            rs_POBOMDTL.Tables("RESULT").Rows(current_row).Item("pbd_shpend") = txtDShpEnd.Text
            'rs_POBOMDTL.Update()
        End If

        rs_POBOMDTL.Tables("RESULT").Columns("pbd_adjqty").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_negprc").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_rvenitm").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_candat").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_shpstr").ReadOnly = False
        rs_POBOMDTL.Tables("RESULT").Columns("pbd_shpend").ReadOnly = False
    End Sub


    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        Me.Close()
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        'Dim YesNoCancel As Integer
        If Recordstatus = True Then

            'YesNoCancel = msg("M00248")
            Dim YesNoCancel As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)

            If YesNoCancel = MsgBoxResult.Cancel Then
                Exit Sub
            ElseIf YesNoCancel = MsgBoxResult.Yes Then
                Call mmdSave_Click(sender, e)
                If save_ok = False Then Exit Sub
            End If
        End If
        Call setStatus("Init")
        If txtBOMNo.Visible = True And txtBOMNo.Enabled = True Then txtBOMNo.Focus()
    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If Me.txtRmtAdr.Text = "" Then
            Me.TabPageMain.SelectedIndex = 0
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Please Select BOM Vendor Address.")
            If Me.cboVenAddr.Visible = True And Me.cboVenAddr.Enabled = True Then Me.cboVenAddr.Focus()
            save_ok = False
            Exit Sub
        End If


        If Not ChkDate() Then
            Me.Cursor = Windows.Forms.Cursors.Default
            save_ok = False
            Exit Sub
        End If

        If Not ChecktimeStamp() Then
            MsgBox("The record has been modified by other users, please clear and try again.") 'msg("M00064")
            Me.Cursor = Windows.Forms.Cursors.Default
            save_ok = False
            Exit Sub
        End If


        Dim S As String
        Call Update_BOMDtl()

        If Not IsDate(txtCanDat.Text) Then
            txtCanDat.Text = default_date
        End If


        rs_POBOMHDR.Tables("RESULT").Columns("pbh_candat").ReadOnly = False
        If Not IsDate(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat")) Then
            rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat") = default_date
        End If

        Dim YesNoCancel As Microsoft.VisualBasic.MsgBoxResult 'Dim YesNo As Integer'Dim intYesNo As Integer
        If Me.txtCanDat.Text <> IIf(IsDate(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat")), Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat")), "MM/dd/yyyy"), "  /  /") Or Me.txtShpStr.Text <> Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpstr")), "MM/dd/yyyy") Or Me.txtShpEnd.Text <> Format(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpend"), "MM/dd/yyyy") Then
            YesNoCancel = MsgBox("Cancel or Ship Date in Header has been modified, details will be updated. Are you sure?", MsgBoxStyle.YesNoCancel)
            If YesNoCancel = MsgBoxResult.Cancel Then
                Me.Cursor = Windows.Forms.Cursors.Default
                save_ok = False
                Exit Sub
            End If

        End If

        'rs_POBOMDTL.MoveFirst()
        For i As Integer = 0 To rs_POBOMDTL.Tables("RESULT").Rows.Count - 1
            'While Not rs_POBOMDTL.EOF
            S = ""

            rs_POBOMDTL.Tables("RESULT").Columns("pbd_candat").ReadOnly = False
            If Not IsDate(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_candat")) Then
                rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_candat") = default_date
            End If




            If (YesNoCancel = MsgBoxResult.No Or (Me.txtCanDat.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat")), "MM/dd/yyyy") And Me.txtShpStr.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpstr")), "MM/dd/yyyy") And Me.txtShpEnd.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpend")), "MM/dd/yyyy"))) Then
                S = "sp_Update_POBOMDTL  '" & gsCompany & "','" & UCase(txtBOMNo.Text) & "','" & rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_bomseq") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_rvenitm") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_adjqty") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_negprc") & "','" & _
                            IIf(Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_candat")), "MM/dd/yyyy") = default_date, "", Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_candat")), "MM/dd/yyyy")) & "','" & _
                            Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_shpstr")), "MM/dd/yyyy") & "','" & _
                            Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_shpend")), "MM/dd/yyyy") & "','" & gsUsrID & "'"



            ElseIf (Me.txtCanDat.Text <> Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat")), "MM/dd/yyyy") And Me.txtShpStr.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpstr")), "MM/dd/yyyy") And Me.txtShpEnd.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpend")), "MM/dd/yyyy")) Then

                S = "sp_Update_POBOMDTL  '" & gsCompany & "','" & UCase(txtBOMNo.Text) & "','" & rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_bomseq") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_rvenitm") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_adjqty") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_negprc") & "','" & _
                            IIf(txtCanDat.Text = default_date, "", txtCanDat.Text) & "','" & _
                            Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_shpstr")), "MM/dd/yyyy") & "','" & _
                            Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_shpend")), "MM/dd/yyyy") & "','" & gsUsrID & "'"


            ElseIf (Me.txtCanDat.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_candat")), "MM/dd/yyyy") And (Me.txtShpStr.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpstr")), "MM/dd/yyyy") Or Me.txtShpEnd.Text = Format(DateTime.Parse(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_shpend")), "MM/dd/yyyy"))) Then
                S = "sp_Update_POBOMDTL  '" & gsCompany & "','" & UCase(txtBOMNo.Text) & "','" & rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_bomseq") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_rvenitm") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_adjqty") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_negprc") & "','" & _
                            IIf(Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_candat")), "MM/dd/yyyy") = default_date, "", Format(DateTime.Parse(rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_candat")), "MM/dd/yyyy")) & "','" & _
                            txtShpStr.Text & "','" & _
                            txtShpEnd.Text & "','" & gsUsrID & "'"

            Else
                S = "sp_Update_POBOMDTL  '" & gsCompany & "','" & UCase(txtBOMNo.Text) & "','" & rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_bomseq") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_rvenitm") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_adjqty") & "','" & _
                            rs_POBOMDTL.Tables("RESULT").Rows(i).Item("pbd_negprc") & "','" & _
                            IIf(txtCanDat.Text = default_date, "", txtCanDat.Text) & "','" & _
                            txtShpStr.Text & "','" & _
                            txtShpEnd.Text & "','" & gsUsrID & "'"
            End If

            If S <> "" Then  '*** if there is something to do with s ...


                rtnLong = execute_SQLStatement(S, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading BOM00001 mmdSave_Click sp_Update_POBOMDTL : " & rtnStr)
                    IsUpdated = False
                Else
                    IsUpdated = True
                End If


            End If
            'rs_POBOMDTL.MoveNext()
            'End While
        Next






        gspStr = "sp_Update_POBOMHDR '" & gsCompany & "','" & UCase(txtBOMNo.Text) & _
              "','" & DTIssDat.Text & _
              "','" & cboCtp1.Text & _
              "','" & IIf(txtCanDat.Text = default_date, "", txtCanDat.Text) & _
              "','" & txtShpStr.Text & _
              "','" & txtShpEnd.Text & _
              "','" & Replace(txtRmk.Text, "'", "''") & _
              "','" & txtDisPrc.Text & _
              "','" & txtNetAmt.Text & _
              "','" & txtRmtAdr.Text & _
              "','" & txtBVStt.Text & _
              "','" & Split(cboBVCty.Text, " - ")(0) & _
              "','" & txtBVPst.Text & _
              "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)


        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading BOM00001 mmdSave_Click sp_Update_POBOMHDR : " & rtnStr)
            IsUpdated = False
            Exit Sub
        Else
            IsUpdated = True
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

        If IsUpdated Then
            Call setStatus("Save")
        End If
    End Sub
    Private Function ChkDate() As Boolean
        ChkDate = False
        If CDate(txtShpEnd.Text) < CDate(txtShpStr.Text) Then
            MsgBox("Ship Start Date cannot be later than Ship End Date")
            txtShpStr.Focus()
            Exit Function
        End If
        If CDate(txtDShpEnd.Text) < CDate(txtDShpStr.Text) Then
            If TabPageMain.TabPages(1).Visible = True And TabPageMain.TabPages(1).Enabled = True Then Me.TabPageMain.SelectedIndex = 1 'If SSTab1.Visible = True And SSTab1.Enabled = True Then SSTab1.Tab = 1
            MsgBox("Ship Start Date cannot be later than Ship End Date")
            txtDShpStr.Focus()
            Exit Function
        End If
        If IsDate(txtDCanDat.Text) Then 'If txtDCanDat.Text <> "__/__/____" Then

            If CDate(txtDCanDat.Text) < CDate(txtDShpEnd.Text) Or CDate(txtDCanDat.Text) < CDate(txtDShpStr.Text) Then
                If TabPageMain.TabPages(1).Visible = True And TabPageMain.TabPages(1).Enabled = True Then Me.TabPageMain.SelectedIndex = 1 'If SSTab1.Visible = True And SSTab1.Enabled = True Then SSTab1.Tab = 1
                MsgBox("BOM PO Cancel Date must be later than Ship Date")
                If txtDCanDat.Visible = True And txtDCanDat.Enabled = True Then txtDCanDat.Focus()
                Exit Function
            End If
        End If
        If IsDate(txtCanDat.Text) Then 'If txtCanDat.Text <> "__/__/____" Then
            If CDate(txtCanDat.Text) < CDate(txtShpEnd.Text) Then
                MsgBox("BOM PO Cancel Date must be later than Ship Date")
                txtCanDat.Focus()
                Exit Function
            End If
            If CDate(txtCanDat.Text) < CDate(DTIssDat.Text) Then
                MsgBox("BOM PO Cancel Date must be later than Issue Date")
                txtCanDat.Focus()
                Exit Function
            End If
        End If
        ChkDate = True
    End Function
    Private Function ChecktimeStamp() As Boolean
        Dim Save_TimeStamp As Long
        gspStr = "sp_select_POBOMHDR '" & gsCompany & "','" & txtBOMNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POBOMHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading BOM00001 ChecktimeStamp sp_select_POBOMHDR : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Function
        ElseIf rs_POBOMHDR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("RFO") 'msg("M00232")
            ChecktimeStamp = False
            Exit Function
        Else
            Save_TimeStamp = BitConverter.ToInt64(rs_POBOMHDR.Tables("RESULT").Rows(0).Item("pbh_timstp"), 0)
        End If

        If Current_TimeStamp <> Save_TimeStamp Then
            ChecktimeStamp = False
        Else
            ChecktimeStamp = True
        End If

    End Function

    Private Sub txtNegPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNegPrc.TextChanged
        If Not flag_displayDetail Then Recordstatus = True
        If Trim(txtNegPrc.Text) <> "" And Trim(txtFtyPrc.Text) <> "" Then

            If CDbl(txtNegPrc.Text) > CDbl(txtFtyPrc.Text) Then
                MsgBox("Negotiated Price cannot be greater than BOM Factory Price")
                txtNegPrc.Text = txtFtyPrc.Text
            End If
            calcal()
        End If

        If Trim(txtNegPrc.Text) = "" Then
            txtNegPrc.Text = "0"
        End If
    End Sub


    Private Sub calcal()
        If txtNegPrc.Text <> "" And txtAdjQty.Text <> "" Then
            'txtDTtlAmt.Text = txtAdjQty.Text * txtNegPrc.Text
            txtDTtlAmt.Text = Format(roundup(txtAdjQty.Text * txtNegPrc.Text), "######0.00")
        End If
    End Sub

    Private Sub cboBOMStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBOMStatus.SelectedIndexChanged
        chkstatus()
    End Sub
    Private Sub chkstatus()
        If cboBOMStatus.SelectedIndex <> 0 Then

            txtCanDat.Enabled = False
            txtShpStr.Enabled = False
            txtShpEnd.Enabled = False
            txtRmk.Enabled = True
            txtRmk.ReadOnly = True
            txtAdjQty.Enabled = False
            txtNegPrc.Enabled = False
            txtDCanDat.Enabled = False
            txtDShpStr.Enabled = False
            txtDShpEnd.Enabled = False
            txtRVenItm.Enabled = False
        Else

            txtCanDat.Enabled = True
            txtShpStr.Enabled = True
            txtShpEnd.Enabled = True
            txtRmk.Enabled = True
            txtRmk.ReadOnly = False
            txtAdjQty.Enabled = True
            txtNegPrc.Enabled = True
            txtDCanDat.Enabled = True
            txtDShpStr.Enabled = True
            txtDShpEnd.Enabled = True
            txtRVenItm.Enabled = True
        End If

        txtEngDsc.Enabled = True
        txtEngDsc.ReadOnly = True
        txtChnDsc.Enabled = True
        txtChnDsc.ReadOnly = True
        txtVcoDsc.Enabled = True
        txtVcoDsc.ReadOnly = True
        txtEngRid.Enabled = True
        txtEngRid.ReadOnly = True
        txtChnRid.Enabled = True
        txtChnRid.ReadOnly = True
        txtColDsc.Enabled = True
        txtColDsc.ReadOnly = True
    End Sub

    Private Sub cboBVCty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBVCty.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
    End Sub

    Private Sub cboCtp1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtp1.SelectedIndexChanged
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub cboCtp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtp1.Click
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub cboVenAddr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.SelectedIndexChanged
        Recordstatus = True

        If Me.cboVenAddr.Text = "" Then
            txtRmtAdr.Text = ""
            txtBVStt.Text = ""
            Call display_combo("", cboBVCty)
            txtBVPst.Text = ""
            Exit Sub
        End If

        If rs_VNCNTINF Is Nothing Then Exit Sub
        If rs_VNCNTINF.Tables("RESULT").Rows.Count = 0 Then Exit Sub

        Dim dr_VNCNTINF() As DataRow = rs_VNCNTINF.Tables("RESULT").Select("vci_adr='" & Trim(Me.cboVenAddr.Text) & "'")

        If dr_VNCNTINF.Length > 0 Then
            txtRmtAdr.Text = dr_VNCNTINF(0).Item("vci_adr")
            txtBVStt.Text = dr_VNCNTINF(0).Item("vci_stt")
            Call display_combo(CStr(Split(dr_VNCNTINF(0).Item("vci_cty"), " - ")(0)), cboBVCty)
            txtBVPst.Text = dr_VNCNTINF(0).Item("vci_zip")
        End If

        'rs_VNCNTINF.Filter = ""

    End Sub

    Private Sub cboVenAddr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.Enter
        befVenAddr = Me.cboVenAddr.Text
    End Sub

    Private Sub cboVenAddr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVenAddr.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            cboVenAddr_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cboVenAddr_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenAddr.KeyUp
        auto_search_combo(cboVenAddr)
    End Sub

    Private Sub cboVenAddr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.Leave
        If ValidateCombo(Me.cboVenAddr) = False Then
            Exit Sub
        End If
        If befVenAddr <> Me.cboVenAddr.Text Then
            Call cboVenAddr_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Public Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If
        ValidateCombo = False
        Dim i As Integer
        Dim S As String
        S = Combo1.Text
        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items.Item(i)) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next
        If Not ValidateCombo Then
            'MsgBox("Invalid Data! Please try again.") 'msg("M00018")
            MsgBox("The text is not in the combo list.")
            On Error Resume Next
            Combo1.Focus()
            On Error GoTo 0
        End If
    End Function

    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged
        If PreviousTab = 1 Then
            If Not rs_POBOMDTL Is Nothing Then
                If rs_POBOMDTL.Tables("RESULT").Rows.Count > 0 Then
                    Call Update_BOMDtl()
                End If
            End If
        End If

        If Me.TabPageMain.SelectedIndex = 1 Then
            Me.CmdDtlPre.Enabled = False
            Me.CmdDtlNext.Enabled = False

            Call DisplayBOMDetail()
            checkBackNext()
            'If rs_POBOMDTL.Tables("RESULT").Rows.Count > 1 Then
            '    If rs_POBOMDTL.AbsolutePosition > 1 Then
            '        Me.CmdDtlPre.Enabled = True
            '    End If
            '    If rs_POBOMDTL.AbsolutePosition < rs_POBOMDTL.recordCount Then
            '        Me.CmdDtlNext.Enabled = True
            '    End If
            'End If
            If txtAdjQty.Visible = True And txtAdjQty.Enabled = True Then txtAdjQty.Focus()
        ElseIf Me.TabPageMain.SelectedIndex = 2 Then
            grdSummary.Refresh()
        End If
    End Sub

    Private Sub TabPageMain_Deselected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabPageMain.Deselected
        PreviousTab = e.TabPageIndex
    End Sub

    Private Sub txtAdjQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjQty.TextChanged
        calcal()
        If Trim(txtAdjQty.Text) = "" Then
            txtAdjQty.Text = "0"
        End If
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub txtAdjQty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjQty.Enter
        Call HighlightText(txtAdjQty)
    End Sub
    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub txtAdjQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdjQty.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) >= 48 And Microsoft.VisualBasic.Asc(e.KeyChar) <= 57) Or e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = ChrW(Keys.Tab) Then

        Else
            e.KeyChar = ""
            Exit Sub
        End If
    End Sub

    Private Sub txtBOMNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBOMNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            mmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub txtBVPst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBVPst.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtBVStt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBVStt.TextChanged
        Recordstatus = True
    End Sub



    Private Sub txtCanDat_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanDat.Enter
        Call HighlightMask(txtCanDat)
    End Sub
    Public Sub HighlightMask(ByVal t As MaskedTextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub txtCanDat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanDat.Leave
        If Me.txtCanDat.Text = "__/__/____" Or txtCanDat.Text = "  /  /" Then Exit Sub 'Lester Wu 2004/09/17 Allow Empty Cancel Date

        If Not IsDate(txtCanDat.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            txtCanDat.Focus()
        End If
    End Sub

    Private Sub txtCanDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanDat.TextChanged
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub txtChnDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnDsc.Enter
        Call HighlightText(txtChnDsc)
        txtChnDsc.Height = txtChnDsc.Height + 30
        'txtChnDsc.ZOrder(0)
    End Sub

    Private Sub txtChnDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnDsc.Leave
        txtChnDsc.Height = txtChnDsc.Height - 30
    End Sub

    Private Sub txtDCanDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDCanDat.TextChanged
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub txtDCanDat_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDCanDat.Enter
        HighlightMask(txtDCanDat)
    End Sub

    Private Sub txtDCanDat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDCanDat.Leave
        If Me.txtDCanDat.Text = "__/__/____" Or txtDCanDat.Text = "  /  /" Then Exit Sub 'Lester Wu 2004/09/17 Allow Empty Cancel Date

        If Not IsDate(txtDCanDat.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            txtDCanDat.Focus()
        End If
    End Sub

    Private Sub txtDisPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisPrc.TextChanged
        If Not flag_displayDetail Then Recordstatus = True
        If Trim(txtDisPrc.Text) = "" Then
            txtDisPrc.Text = "0"
        End If
    End Sub

    Private Sub txtDisPrc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisPrc.Enter
        Call HighlightText(txtDisPrc)
    End Sub

    Private Sub txtDisPrc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisPrc.Leave
        If txtDisPrc.Text <> "0" Then
            txtNetAmt.Text = Format(roundup(Val(txtTtlAmt.Text) - ((Val(txtTtlAmt.Text) / 100) * Val(txtDisPrc.Text))), "######0.00")
        End If
    End Sub


    Private Sub txtShpStr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpStr.TextChanged
        If Not flag_displayDetail Then Recordstatus = True
    End Sub


    Private Sub txtShpStr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpStr.Enter
        Call HighlightMask(txtShpStr)
    End Sub

    Private Sub txtShpStr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpStr.Leave
        If Not IsDate(txtShpStr.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            txtShpStr.Focus()

        End If
    End Sub



    Private Sub txtEngDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngDsc.Enter
        Call HighlightText(txtEngDsc)
        'txtEngDsc.ZOrder(0)
        txtEngDsc.Height = txtEngDsc.Height + 30
    End Sub

    Private Sub txtEngDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngDsc.Leave
        txtEngDsc.Height = txtEngDsc.Height - 30
    End Sub

    Private Sub txtNegPrc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNegPrc.Enter
        Call HighlightText(txtNegPrc)
    End Sub

    Private Sub txtRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.Enter
        txtRmk.Top = txtRmk.Top - 30
        txtRmk.Height = txtRmk.Height + 30
        Call HighlightText(txtRmk)
    End Sub

    Private Sub txtRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.Leave
        txtRmk.Top = txtRmk.Top + 30
        txtRmk.Height = txtRmk.Height - 30
    End Sub

    Private Sub txtRmtAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmtAdr.TextChanged
        Recordstatus = True
    End Sub
    Private Sub txtDShpEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDShpEnd.TextChanged
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub txtDShpEnd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDShpEnd.Enter
        Call HighlightMask(txtDShpEnd)
    End Sub

    Private Sub txtDShpEnd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDShpEnd.Leave
        If Not IsDate(txtDShpEnd.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            txtDShpEnd.Focus()
        End If
    End Sub

    Private Sub txtShpEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpEnd.TextChanged
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub txtShpEnd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpEnd.Enter
        Call HighlightMask(txtShpEnd)
    End Sub

    Private Sub txtShpEnd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpEnd.Leave
        If Not IsDate(txtShpEnd.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            txtShpEnd.Focus()
        End If
    End Sub

    Private Sub txtDShpStr_StyleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDShpStr.StyleChanged
        If Not flag_displayDetail Then Recordstatus = True
    End Sub

    Private Sub txtDShpStr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDShpStr.Enter
        Call HighlightMask(txtDShpStr)
    End Sub

    Private Sub txtDShpStr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDShpStr.Leave
        If Not IsDate(txtDShpStr.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            txtDShpStr.Focus()

        End If
    End Sub

    Private Sub BOM00001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If (e.Alt) Then
            If e.KeyCode = Keys.D1 Then
                Me.TabPageMain.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 Then
                Me.TabPageMain.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.D3 Then
                Me.TabPageMain.SelectedIndex = 2
            End If
        End If
    End Sub

    Private Sub grdSummary_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellEnter
        If e.RowIndex >= 0 Then
            Dim dr() As DataRow = rs_POBOMDTL.Tables("RESULT").Select("", "pbd_bomseq")
            For index As Integer = 0 To dr.Length - 1
                If rs_POBOMDTL.Tables("RESULT").DefaultView(e.RowIndex)("pbd_bomseq") = dr(index)("pbd_bomseq") Then
                    current_row = index
                End If
            Next
        End If
    End Sub

    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        If checkFocus(Me) Then Exit Sub
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtBOMNo.Name
        frmSYM00018.strModule = "BM"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub mmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdPrint.Click
        If checkFocus(Me) Then Exit Sub
        BOMReport = New POR00003
        BOMReport.init_PONo = txtBOMNo.Text
        BOMReport.init_cocde = cboCoCde.Text
        BOMReport.ShowDialog()
    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCopy.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAttach.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFunction.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdLink.Click
        If checkFocus(Me) Then Exit Sub
    End Sub
End Class