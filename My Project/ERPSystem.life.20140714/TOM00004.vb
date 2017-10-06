Public Class TOM00004

    Public rs_TOITMSUM As DataSet
    Public rs_TOITMDTL As DataSet
    Dim rs_CUBASINF_P As DataSet
    Dim rs_CUBASINF_S As DataSet

    Dim sort_itm_sum As Boolean
    Dim sort_orgitm_dtl As Boolean
    Dim sort_fnlitm_dtl As Boolean
    Dim Temp_CusNo As String

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        If Trim(cboCus1No.Text) = "" And Trim(txtToNo.Text) = "" Then
            MsgBox("Please input Primary Customer No or Tentative No.")
            cboCus1No.Focus()
            Exit Sub
        End If

        'If txtUpdDat.Text <> "" Then
        '    If CheckDate(txtUpdDat.Text) = False Then
        '        MsgBox("Data format invalid!") 'msg("M00044")
        '        txtUpdDat.Focus()
        '        Exit Sub
        '    End If

        '    If Mid(txtUpdDat.Text, 3, 1) <> "/" And Mid(txtUpdDat.Text, 6, 1) <> "/" Then
        '        MsgBox("Data format invalid!") 'msg("M00044")
        '        txtUpdDat.Focus()
        '        Exit Sub
        '    End If
        'End If

        'cboCus1No.Text = UCase(cboCus1No.Text)
        txtItmNo.Text = UCase(txtItmNo.Text)


        If txtToNo.Text <> "" Then
            gspStr = "sp_select_TOITMDTL_TO '" & txtToNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_TOITMDTL, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading TOM00004 cmdFind_Click sp_select_TOITMDTL: " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If rs_TOITMDTL.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No Record Found!") 'msg("M00071")
                Else
                    'If gsSalTem <> rs_TOITMDTL.Tables("RESULT").Rows(0).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then
                    '    Me.Cursor = Windows.Forms.Cursors.Default
                    '    MsgBox("You have no Right access this document.") 'msg ("M00371")
                    '    Exit Sub
                    'End If


                    Me.Cursor = Windows.Forms.Cursors.Default
                End If
            End If

            gspStr = "sp_select_TOITMSUM_TO '" & txtToNo.Text & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_TOITMSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading TOM00004 cmdFind_Click sp_select_TOITMSUM: " & rtnStr)
            Else
                If rs_TOITMSUM.Tables("RESULT").Rows.Count > 0 Then
                    Call Display()
                    Call setStatus("Updating")
                End If
            End If

            Exit Sub

        End If


        If rdbitmno.Checked = True Then


            gspStr = "sp_select_TOITMDTL '" & gsCompany & "','" & cboCus1No.Text & "','" & cboCus2No.Text & "','" & txtItmNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_TOITMDTL, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading TOM00004 cmdFind_Click sp_select_TOITMDTL: " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If rs_TOITMDTL.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No Record Found!") 'msg("M00071")
                Else
                    'If gsSalTem <> rs_TOITMDTL.Tables("RESULT").Rows(0).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then
                    '    Me.Cursor = Windows.Forms.Cursors.Default
                    '    MsgBox("You have no Right access this document.") 'msg ("M00371")
                    '    Exit Sub
                    'End If


                    Me.Cursor = Windows.Forms.Cursors.Default
                End If
            End If

            gspStr = "sp_select_TOITMSUM '" & gsCompany & "','" & cboCus1No.Text & "','" & cboCus2No.Text & "','" & txtItmNo.Text & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_TOITMSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading TOM00004 cmdFind_Click sp_select_TOITMSUM: " & rtnStr)
            Else
                If rs_TOITMSUM.Tables("RESULT").Rows.Count > 0 Then
                    Call Display()
                    Call setStatus("Updating")
                End If
            End If


        Else

            gspStr = "sp_select_TOITMDTL_VN '" & gsCompany & "','" & cboCus1No.Text & "','" & cboCus2No.Text & "','" & txtVenItmNo.Text & "','" & txtVendor.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_TOITMDTL, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading TOM00004 cmdFind_Click sp_select_TOITMDTL_VN: " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If rs_TOITMDTL.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No Record Found!") 'msg("M00071")
                Else
                    'If gsSalTem <> rs_TOITMDTL.Tables("RESULT").Rows(0).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then
                    '    Me.Cursor = Windows.Forms.Cursors.Default
                    '    MsgBox("You have no Right access this document.") 'msg ("M00371")
                    '    Exit Sub
                    'End If

                    Me.Cursor = Windows.Forms.Cursors.Default
                End If
            End If

            gspStr = "sp_select_TOITMSUM_VN '" & gsCompany & "','" & cboCus1No.Text & "','" & cboCus2No.Text & "','" & txtVenItmNo.Text & "','" & txtVendor.Text & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_TOITMSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading TOM00004 cmdFind_Click sp_select_TOITMSUM_VN: " & rtnStr)
            Else
                If rs_TOITMSUM.Tables("RESULT").Rows.Count > 0 Then
                    Call Display()
                    Call setStatus("Updating")
                End If
            End If




        End If


        ''*** query item master header
        'S = "㊣SAORDSUM※S※" & cboCus1No.Text & "※" & txtItmNo.Text & "※" & txtColCde.Text & "※" & txtUpdDat.Text & "※" & gsUsrID & _
        '    "㊣SAORDDTL※S※" & cboCus1No.Text & "※" & txtItmNo.Text & "※" & txtColCde.Text & "※" & txtUpdDat.Text & "※" & gsUsrID & "※" & gsFlgCst & "※" & gsFlgCstExt

        'Screen.MousePointer = vbHourglass
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)


        ''******************************************************************************************************
        ''****************************Query SCORDHDR Hearder****************************************************
        ''******************************************************************************************************
        'If rs(0)(0) <> "0" Then
        '    MsgBox(rs(0)(0))
        '    Screen.MousePointer = vbDefault
        '    Exit Sub
        'Else
        '    If rs(2).RecordCount = 0 Then
        '        Screen.MousePointer = vbDefault
        '        msg("M00071")
        '    Else
        '        If gsSalTem <> rs(2)("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then
        '            Screen.MousePointer = vbDefault
        '            msg("M00371")
        '            Exit Sub
        '        End If
        '        rs_TOITMSUM = rs(1)
        '        rs_TOITMDTL = rs(2)
        '        Call Display()
        '        Call setStatus("Updating")
        '        Screen.MousePointer = vbDefault
        '    End If
        'End If

        'Screen.MousePointer = vbDefault

    End Sub

    Private Sub SAM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        'Timer1.Enabled = False
        Dim v
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        For Each v In Me.Controls

            If IsDataGrid(v) Then
                v.TabAction = 1
                v.RowHeight = 190
                v.TabStop = True
                v.WrapCellPointer = False
            End If
        Next
        Me.KeyPreview = True
        Me.TabPageMain.SelectedIndex = 0
        Call setStatus("Init")
        Call Formstartup(Me.Name)   'Set the form Sartup position
        checkraido()
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Public Function IsDataGrid(ByVal v As Object) As Boolean
        If (TypeOf v Is DataGrid) Then
            IsDataGrid = True
        End If
    End Function
    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            Me.TabPageMain.SelectedIndex = 0
            Call SetInputBoxesStatus("DisableAll")
            'freeze_TabControl(-1)

            'Me.TabPageMain.TabPages(0).Enabled = False
            'Me.TabPageMain.TabPages(1).Enabled = False
            'TabPageMain.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelete.Enabled = False
            cmdFind.Enabled = True
            cmdExit.Enabled = True
            txtCusNo.Enabled = True
            txtItmNo.Enabled = True
            cmd_S_ItmNo.Enabled = True
            cmd_S_ItmNo2.Enabled = True
            txtCus2no.Enabled = True
            'txtUpdDat.Enabled = True
            txtCusNo.Text = Temp_CusNo
            'txtCusNo.BackColor = vbWhite
            cboCoCde.Enabled = True
            cmdMapping.Enabled = True
            rdbvenitm.Enabled = True
            rdbitmno.Enabled = True
            txtToNo.Enabled = True
            cboCus1No.Enabled = True
            cboCus2No.Enabled = True
            txtVenItmNo.Enabled = True
            txtVendor.Enabled = True
        ElseIf Mode = "Updating" Then
            Call SetInputBoxesStatus("EnableAll")

            'release_TabControl()
            'TabPageMain.Enabled = True
            'Me.TabPageMain.TabPages(0).Enabled = True
            'Me.TabPageMain.TabPages(1).Enabled = False
            'Me.TabPageMain.TabPages(1).Enabled = True
            'grdDtl.Focus()
            'grdDtl.Enabled = True
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdCopy.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelete.Enabled = False
            cmdDelRow.Enabled = False
            cmdFind.Enabled = False
            cmd_S_ItmNo.Enabled = True
            cmd_S_ItmNo2.Enabled = True
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            txtCusNo.Enabled = False
            txtItmNo.Enabled = False
            txtCus2no.Enabled = False
            'txtUpdDat.Enabled = False
            cboCoCde.Enabled = False
            txtCoNam.Enabled = False
            rdbitmno.Enabled = False
            rdbvenitm.Enabled = False
            cmdMapping.Enabled = True
            grdDtl.Enabled = True
            txtToNo.Enabled = False
            cboCus1No.Enabled = False
            cboCus2No.Enabled = False
            txtVenItmNo.Enabled = False
            txtVendor.Enabled = False
            Call SetStatusBar(Mode)
        ElseIf Mode = "Save" Then
            Call SetStatusBar(Mode)
            Call setStatus("Init")
        ElseIf Mode = "Delete" Then
            Call SetStatusBar(Mode)
        ElseIf Mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)
            Call setStatus("Init")
            txtCusNo.Focus()
        End If
        If cmdSave.Enabled = False And cmdAdd.Enabled = False Then
            Call SetStatusBar("ReadOnly")
        End If

    End Sub
    Private Sub SetStatusBar(ByVal Mode As String)
        If Mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Please Enter a Qu No."
        ElseIf Mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "ADD"
        ElseIf Mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf Mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf Mode = "Delete" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Deleted"
        ElseIf Mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf Mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If
    End Sub
    Private Sub SetInputBoxesStatus(ByVal Mode As String)
        Dim v
        '*** (1) If Mode = "EnableAll", enable all controls
        If Mode = "EnableAll" Then
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = True
                End If
            Next
            '*** (2) If Mode = "DisableAll", disable all controls
        ElseIf Mode = "DisableAll" Then
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = False
                End If
            Next
        End If
    End Sub
    Public Function IsInputBoxes(ByVal v As Object) As Boolean
        If (TypeOf v Is TextBox) Or (TypeOf v Is CheckBox) Or _
           (TypeOf v Is ComboBox) Or (TypeOf v Is Button) Or _
           (TypeOf v Is DataGrid) Then
            IsInputBoxes = True
        Else
            IsInputBoxes = False
        End If
    End Function
    Private Sub ResetDefaultDisp()
        'txtCusNo.Text = ""
        '  txtCus2no.Text = ""
        
        'txtUpdDat.Text = ""
        grdSum.DataSource = Nothing
        grdDtl.DataSource = Nothing
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
    Public Function CheckDate(ByVal theDate As String) As Boolean
        Dim month%, day%, year%
        Dim mm$, dd$, yyyy$
        Dim valid As Boolean

        valid = True
        mm$ = Mid(theDate, 1, 2)
        dd$ = Mid(theDate, 4, 2)
        yyyy$ = Mid(theDate, 7, 4)

        If IsDate(theDate) = False Then
            valid = False
            GoTo result
        End If
        ' Only accept either all date fields filled or all date fields empty
        If Not ((mm$ = "  " And dd$ = "  " And yyyy$ = "    ") Or (mm$ <> "  " And dd$ <> "  " And yyyy$ <> "    ")) Then
            valid = False
            GoTo result
        End If

        month% = Val(mm$)   ' Convert the date into numbers
        day% = Val(dd$)
        year% = Val(yyyy$)

        If month% > 12 Then    ' Check the month
            valid = False
            GoTo result
        End If
        If month% = 1 Or month% = 3 Or _
           month% = 5 Or month% = 7 Or _
           month% = 8 Or month% = 10 Or _
           month% = 12 Then             ' Check the day
            'If Date% > 31 Then
            If day% > 31 Then
                valid = False
                GoTo result
            End If
        End If
        If month% = 2 Or month% = 4 Or _
           month% = 6 Or month% = 9 Or _
           month% = 11 Then             ' Check the day
            'If Date% > 30 Then
            If day% > 30 Then
                valid = False
                GoTo result
            End If
        End If
        If month% = 2 And day% > 28 And _
           year% Mod 4 <> 0 Then ' Check the leap year
            valid = False
            GoTo result
        End If
        '*** Add to check Date is in valid year by Lewis on 15/04/2003 ********************
        If year% < 1950 Or year% > 2049 Then
            valid = False
            GoTo result
        End If
        '**********************************************************************************
result:
        CheckDate = valid
    End Function
    Private Sub Display()
        'txtCusNo.Text = rs_TOITMDTL.Tables("RESULT").Rows(0).Item("sad_pri")

        grdSum.DataSource = rs_TOITMSUM.Tables("RESULT").DefaultView
        Call Display_Sum()
        grdDtl.DataSource = rs_TOITMDTL.Tables("RESULT").DefaultView
        Call Display_Dtl()
    End Sub
    Private Sub Display_Sum()
        Dim X As Integer
        With grdSum
            For X = 0 To .Columns.Count - 1
                .Columns(X).ReadOnly = True
                '.Columns(X).Width = 0
            Next X

            .Columns(0).Width = 50
            .Columns(0).HeaderCell.Value = "Comp"
            .Columns(1).Width = 70
            .Columns(1).HeaderCell.Value = "Prim.Cust"
            .Columns(2).Width = 70
            .Columns(2).HeaderCell.Value = "Sec.Cust"
            .Columns(3).Width = 70
            .Columns(3).HeaderCell.Value = "Year"
            .Columns(4).Width = 70
            .Columns(4).HeaderCell.Value = "Item Type"
            .Columns(5).Width = 110
            .Columns(5).HeaderCell.Value = "Ass.Item"
            .Columns(6).Width = 110
            .Columns(6).HeaderCell.Value = "Item.No"
            .Columns(7).Width = 110
            .Columns(7).HeaderCell.Value = "TempItem.No"
            .Columns(8).Width = 70
            .Columns(8).HeaderCell.Value = "Ven.No"
            .Columns(9).Width = 110
            .Columns(9).HeaderCell.Value = "VenItem.No"
            .Columns(10).Width = 70
            .Columns(10).HeaderCell.Value = "UM"
            .Columns(11).Width = 70
            .Columns(11).HeaderCell.Value = "TO Qty"
            .Columns(12).Width = 70
            .Columns(12).HeaderCell.Value = "SO Qty"
            .Columns(13).Width = 70
            .Columns(13).HeaderCell.Value = "OS Qty"
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False
        End With
    End Sub
    Private Sub Display_Dtl()
        Dim X As Integer
        With grdDtl
            For X = 0 To .Columns.Count - 1
                .Columns(X).ReadOnly = True
            Next X

           



            .Columns(0).Width = 50
            .Columns(0).HeaderCell.Value = "Comp"
            .Columns(1).Width = 70
            .Columns(1).HeaderCell.Value = "Prim.Cust"
            .Columns(2).Width = 70
            .Columns(2).HeaderCell.Value = "Sec.Cust"
            .Columns(3).Width = 70
            .Columns(3).HeaderCell.Value = "Year"
            .Columns(4).Width = 70
            .Columns(4).HeaderCell.Value = "Item Type"
            .Columns(5).Width = 110
            .Columns(5).HeaderCell.Value = "Ass.Item"
            .Columns(6).Width = 110
            .Columns(6).HeaderCell.Value = "Item.No."
            .Columns(7).Width = 110
            .Columns(7).HeaderCell.Value = "TempItem.No."
            .Columns(8).Width = 70
            .Columns(8).HeaderCell.Value = "Ven.No."
            .Columns(9).Width = 110
            .Columns(9).HeaderCell.Value = "VenItem.No."
            .Columns(10).Width = 70
            .Columns(10).HeaderCell.Value = "UM"
            .Columns(11).Width = 70
            .Columns(11).HeaderCell.Value = "TO Qty"
            .Columns(12).Width = 70
            .Columns(12).HeaderCell.Value = "SO Qty"
            .Columns(13).Width = 90
            .Columns(13).HeaderCell.Value = "Tent.No"
            .Columns(14).Width = 70
            .Columns(14).HeaderCell.Value = "Tent.Seq"
            .Columns(15).Width = 70
            .Columns(15).HeaderCell.Value = "Verson No"
            .Columns(16).Width = 90
            .Columns(16).HeaderCell.Value = "Quot.No"
            .Columns(17).Width = 70
            .Columns(17).HeaderCell.Value = "Quot.Seq"
            .Columns(18).Visible = False
            .Columns(19).Visible = False
            .Columns(20).Visible = False
            .Columns(21).Visible = False
            .Columns(22).Visible = False


            
        End With



        'Lester Wu 2005/03/12 Amend the datetime format show to be "MM/DD/YYYY"
        'StatusBar.Panels(2).Text = Format(rs_TOITMDTL("sad_credat"), "DD/MM/YYYY") & " " & Format(rs_TOITMDTL("sad_upddat"), "DD/MM/YYYY") & _
        '                              " " & rs_TOITMDTL("sad_updusr")
        'Me.StatusBar.Items("lblRight").Text = Format(rs_TOITMDTL.Tables("RESULT").Rows(0).Item("sad_credat"), "MM/dd/yyyy") & " " & Format(rs_TOITMDTL.Tables("RESULT").Rows(0).Item("sad_upddat"), "MM/dd/yyyy") & _
        '                              " " & rs_TOITMDTL.Tables("RESULT").Rows(0).Item("sad_updusr")

    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Call fillParameter()
    End Sub

    Private Sub fillParameter()
       

        '*** For Primary Customer Combo Box

        'gspStr = "sp_select_CUBASINF_SAM00003_01 '" & gsCompany & "','" & gsSalTem & "','Primary'"
        gspStr = "sp_select_CUBASINF_PC '" & gsCompany & "','" & gsUsrID & "','QU','Primary'"       ' from quotation

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_select_CUBASINF_SAM00003_01 : " & rtnStr)
        Else
            If rs_CUBASINF_P.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else
                Call fillCus1No() '*** Fill up Currency combo box
            End If
        End If


        '*** For Secondary Customer Combo Box
        gspStr = "sp_list_CUBASINF_SAM00003_1 '" & gsCompany & "','S'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00003 sp_list_CUBASINF_SAM00003_1 : " & rtnStr)
        End If


       







    End Sub
    Private Sub fillCus1No()
        'Dim sFilter As String
        ' Marco added 20031028 start
        Dim add_flag As Boolean = True
        cboCus1No.Items.Clear()
        cboCus1No.Items.Add("")
        cboCus1No.Text = ""
        If Add_flag = True Then
            'sFilter = "cbi_cusno >= '50000'"
            Dim drCUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
            If Not drCUBASINF_P Is Nothing Then
                For i As Integer = 0 To drCUBASINF_P.Length - 1
                    'filter the discontinue and inactive customer 
                    If Not (drCUBASINF_P(i).Item("cbi_cussna").ToString.Contains("Discontinue") Or drCUBASINF_P(i).Item("cbi_cussna").ToString.Contains("Inactive")) Then
                        'MsgBox(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)

                        cboCus1No.Items.Add(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)
                    End If
                Next
            End If
        Else
            For i As Integer = 0 To rs_CUBASINF_P.Tables("RESULT").Rows.Count - 1
                cboCus1No.Items.Add(rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno").ToString & " - " & rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString)
            Next
        End If
        'Marco added 20031028 start
        'If Add_flag = True Then
        'sFilter = ""
        'rs_CUBASINF_P.Tables("RESULT").DefaultView.RowFilter = sFilter
        'End If
        'Marco added 20031028 end
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Temp_CusNo = txtCusNo.Text
        Call setStatus("Clear")
        checkraido()
    End Sub
    Private Sub returnSelectedRecordsHandler(ByVal sender As Object)
        If Len(gsSearchKey) > 0 And txtItmNo.Enabled = True Then
            Me.txtItmNo.Text = gsSearchKey
            Me.txtItmNo.Refresh()
            Me.txtCus2no.Focus()
        End If

    End Sub
    Private Sub cmdMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMapping.Click
        'gsSearchKey = ""
        'If Me.txtItmNo.Text <> "" Then
        '    SYM00022.strITEMNO = Me.txtItmNo.Text
        '    If SYM00022.domapping = 1 Then
        '        SYM00022.Show(vbModal)
        '        If Len(gsSearchKey) > 0 And txtItmNo.Enabled = True Then
        '            Me.txtItmNo.Text = gsSearchKey
        '            Me.txtItmNo.Refresh()
        '            Me.txtColCde.SetFocus()
        '        End If
        '    End If
        'End If
        gsSearchKey = ""
        If Me.txtItmNo.Text <> "" Then
            Dim frm_SYM00022 As New SYM00022(Me.txtItmNo.Text)
            frm_SYM00022.MdiParent = Me.MdiParent
            If domapping_value = 1 Then
                frm_SYM00022.Show()
                AddHandler frm_SYM00022.returnSelectedRecords, AddressOf returnSelectedRecordsHandler

            End If
        End If
    End Sub


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cboCoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.Click
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub DefinedKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If (KeyCode = vbKeyF3) And (cmdClear.Enabled = True) Then
        '    Call cmdClear_Click()     'Hot Key for Clear (F3)

        'ElseIf (KeyCode = vbKeyF5) And (cmdfirst.Enabled = True) Then
        '    Call cmdfirst_Click()     'Hot Key for Move First (F5)

        'ElseIf (KeyCode = vbKeyF6) And (cmdPrv.Enabled = True) Then
        '    Call cmdPrv_Click()       'Hot Key for Move Previous (F6)

        'ElseIf (KeyCode = vbKeyF7) And (cmdNext.Enabled = True) Then
        '    Call cmdNext_Click()      'Hot Key for Move Next (F7)

        'ElseIf (KeyCode = vbKeyF8) And (cmdlast.Enabled = True) Then
        '    Call cmdlast_Click()      'Hot Key for Move Last (F8)
        'End If

        If (e.KeyCode = 114) And (cmdClear.Enabled = True) Then
            Call cmdClear_Click(sender, e)     'Hot Key for Clear (F3)
        End If

    End Sub


    Private Sub SAM00002_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode >= 112 And e.KeyCode <= 123 Then
            Call DefinedKey(sender, e)
        End If
    End Sub

    Private Sub cboCoCde_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.Enter
        HighlightText(txtCus2no)
    End Sub

    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub txtCusNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusNo.Enter
        HighlightText(txtCusNo)
    End Sub

    Private Sub txtCusNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub txtItmNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNo.Enter
        HighlightText(txtItmNo)
    End Sub

    'Private Sub txtUpdDat_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpdDat.Enter
    '    HighlightText(txtUpdDat)
    'End Sub

    'Private Sub txtUpdDat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUpdDat.KeyPress
    '    If Not e.KeyChar.Equals(Chr(8)) Then
    '        If Len(txtUpdDat.Text) = 2 Then
    '            txtUpdDat.Text = txtUpdDat.Text + "/"
    '            txtUpdDat.SelectionStart = 3
    '        ElseIf Len(txtUpdDat.Text) = 5 Then
    '            txtUpdDat.Text = txtUpdDat.Text + "/"
    '            txtUpdDat.SelectionStart = 6
    '        End If
    '    End If

    '    If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
    '        e.KeyChar = ""
    '    End If


    '    'Dim KeyAscii As Long = Asc(e.KeyChar)
    '    'If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
    '    '    KeyAscii = 0
    '    'ElseIf (Len(txtUpdDat.Text) + 1 > 10) And (KeyAscii > 31 Or KeyAscii < 0) Then
    '    '    KeyAscii = 0
    '    'End If
    'End Sub

    'Private Sub txtUpdDat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpdDat.Leave
    '    If txtUpdDat.Text <> "" Then
    '        If CheckDate(txtUpdDat.Text) = False Then
    '            MsgBox("Data format invalid!") 'msg("M00044")
    '            txtUpdDat.Focus()
    '            Exit Sub
    '        End If

    '        If Mid(txtUpdDat.Text, 3, 1) <> "/" And Mid(txtUpdDat.Text, 6, 1) <> "/" Then
    '            MsgBox("Data format invalid!") 'msg("M00044")
    '            txtUpdDat.Focus()
    '            Exit Sub
    '        End If
    '    End If
    'End Sub

    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged


        If Me.TabPageMain.SelectedIndex = 0 Then
            grdSum.Focus()
        ElseIf Me.TabPageMain.SelectedIndex = 1 Then
            grdDtl.Focus()
            grdDtl_ColumnHeaderMouseClick(Nothing, Nothing)
        End If

    End Sub

    Private Sub grdDtl_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDtl.ColumnHeaderMouseClick
        grdDtl.Focus()
    End Sub

    Private Sub SAM00002_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If (e.Alt) Then
            If e.KeyCode = Keys.D1 Then
                Me.TabPageMain.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 Then
                Me.TabPageMain.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtItmNo.Name
        frmComSearch.callFmString = txtItmNo.Text

        'frmComSearch.show_TOM00004(Me)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grdSum.Columns(4).DisplayIndex = 5
    End Sub

    Private Sub checkraido()
        If rdbitmno.Checked = True Then
            txtItmNo.Enabled = True
            txtVendor.Enabled = False
            txtVenItmNo.Enabled = False
            txtVendor.Text = ""
            txtVenItmNo.Text = ""
        Else
            txtItmNo.Enabled = False
            txtItmNo.Text = ""
            txtVendor.Enabled = True
            txtVenItmNo.Enabled = True
        End If


    End Sub

    Private Sub rdbitmno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbitmno.CheckedChanged

    End Sub

    Private Sub rdbitmno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbitmno.Click
        checkraido()
    End Sub

    Private Sub rdbvenitm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbvenitm.CheckedChanged

    End Sub

    Private Sub rdbvenitm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbvenitm.Click
        checkraido()
    End Sub

    Private Sub cmd_S_ItmNo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo2.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtVenItmNo.Name
        frmComSearch.callFmString = txtVenItmNo.Text

        'frmComSearch.show_TOM00004(Me)
    End Sub

    Private Sub cboCus1No_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCus1No.KeyPress
        fillCus2No(cboCus1No.Text)
    End Sub


    Private Sub fillCus2No(ByVal prmcus As String)
        'cboCus1No.Items.Clear()
        'If Add_flag = True Then
        '    Dim drCUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        '    For i As Integer = 0 To drCUBASINF_P.Length - 1
        '        cboCus1No.Items.Add(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)
        '    Next
        'Else
        '    For i As Integer = 0 To rs_CUBASINF_P.Tables("RESULT").Rows.Count - 1
        '        cboCus1No.Items.Add(rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno").ToString & " - " & rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString)
        '    Next
        'End If


        '======
        cboCus2No.Items.Clear()
        cboCus2No.Text = ""
        Dim drCUBASINF_S() As DataRow = rs_CUBASINF_S.Tables("RESULT").Select("cbi_cus1no = '" + Split(prmcus, " - ")(0) + "'")
        If drCUBASINF_S.Length > 0 Then
            'rs_CUBASINF_S.MoveFirst()
            cboCus2No.Items.Clear()
            '    cboCus2No.AddItem ""

            'While Not rs_CUBASINF_S.EOF
            For i As Integer = 0 To drCUBASINF_S.Length - 1
                'cboCus2No.Items.Add(Trim(rs_CUBASINF_S("cbi_cus2no")) + " - " + Trim(rs_CUBASINF_S("cbi_cussna")))
                cboCus2No.Items.Add(Trim(drCUBASINF_S(i).Item("cbi_cus2no").ToString) + " - " + Trim(drCUBASINF_S(i).Item("cbi_cussna").ToString))
                'rs_CUBASINF_S.MoveNext()
            Next

            'End While
        End If
        'rs_CUBASINF_S.Filter = ""
        '=====
        'If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
        '    Dim drCUBASINF_S() As DataRow = rs_CUBASINF_S.Tables("RESULT").Select("cbi_cus1no = '" + Split(prmcus, " - ")(0) + "'")
        '    For i As Integer = 0 To drCUBASINF_S.Length - 1
        '        cboCus2No.Items.Add(Trim(drCUBASINF_S(i).Item("cbi_cus2no").ToString) + " - " + Trim(drCUBASINF_S(i).Item("cbi_cussna").ToString))
        '    Next
        'Else
        '    For i As Integer = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
        '        cboCus2No.Items.Add(Trim(rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cus2no").ToString) + " - " + Trim(rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString))
        '    Next
        'End If
        'rs_CUBASINF_S.Tables("RESULT").DefaultView.RowFilter = ""
    End Sub

    Private Sub cboCus1No_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus1No.KeyUp
        auto_search_combo(cboCus1No, e.KeyCode)
    End Sub

    Private Sub cboCus1No_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCus1No.Leave

        If cboCus1No.Text <> "" And Validate() = True Then

            Dim ee As New System.Windows.Forms.KeyPressEventArgs(Chr(13)) 'Enter
            cboCus1No_KeyPress(sender, ee)
        End If
    End Sub
 
    Private Sub cboCus1No_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1No.SelectedIndexChanged

    End Sub

    Private Sub cboCus2No_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus2No.KeyUp
        auto_search_combo(cboCus2No, e.KeyCode)
    End Sub

    Private Sub cboCus2No_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus2No.SelectedIndexChanged

    End Sub
End Class