Public Class PCM00001

    Dim bindSrc As New BindingSource
    Dim bindSrc2 As New BindingSource
    Dim bindSrc3 As New BindingSource


    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"

    Dim EditModeHdr As String

    Dim CanModify As Boolean ' Check for access right

    Dim Current_TimeStamp As Long 'For current record's time stamp

    '***********************************************************************
    '*** Define RecordSet variable Here
    Public rs_PCMDV As DataSet
    Public rs_PCMAGYCRG As DataSet
    Public rs_PCMDEVCRG As DataSet
    Public rs_PCMAC As DataSet

    Public rs_PCMDV_empty As DataSet
    Public rs_PCMAGYCRG_empty As DataSet
    Public rs_PCMDEVCRG_empty As DataSet
    Public rs_PCMAC_empty As DataSet
    'Public rs_PCMDV_PCM00001_empty As DataSet

    '------2003/11/26------------
    'add a recordset for checking
    Public rs_PCMDV_PCM00001 As DataSet
    '----------------------------
    Public rs_sycominf As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_SYFMLINF As DataSet
    '11/02/2003 add code to show customer
    'By lester
    Public rs_CUBASINF As DataSet
    'end
    '12/15/2003 use dropdown list for pcno instead of textbox
    Public rs_PCMAC_PCNO As DataSet

    Public rs_ACEDIBAT As DataSet


    'end
    '***********************************************************************

    '***********************************************************************
    '*** Define other variable Here

    '***********************************************************************
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim Recordstatus As Boolean '*** Check the Current record is modified or not

    Dim ActionMode As String

    Dim save_ok As Boolean
    Dim IsUpdated As Boolean
    Dim Grid_Got_Focus As String

    Dim Vendor_LongList As New ArrayList
    Dim Vendor_ShortList As New ArrayList

    Dim CompanyList As New ArrayList
    Dim Cust_LongList As New ArrayList
    Dim Cust_ShortList As New ArrayList
    Dim ChargeList As New ArrayList

    Private Sub setVendorList()
        Dim dr() As DataRow = rs_VNBASINF.Tables(0).Select("vbi_venno >= 'A'")

        Dim tmp_string_short As String
        Dim tmp_string_long As String

        For i As Integer = 0 To dr.Length - 1
            tmp_string_short = dr(i).Item("vbi_venno").ToString.Trim
            tmp_string_long = tmp_string_short + " - " + dr(i).Item("vbi_vensna").ToString.Trim
            Vendor_ShortList.Add(tmp_string_short)
            Vendor_LongList.Add(tmp_string_long)
        Next
    End Sub




    Public Function txtInCombo(ByVal cboTemp As ComboBox) As Boolean
        Dim i, Y As Integer
        Dim inCombo As Boolean

        'i = cboTemp.ListCount
        i = cboTemp.Items.Count
        inCombo = True
        If cboTemp.Enabled = True And cboTemp.Text <> "" And cboTemp.Items.Count > 0 Then
            inCombo = False
            For Y = 0 To i - 1
                'If cboTemp.Text = cboTemp.List(Y) Then
                If cboTemp.Text = cboTemp.Items(Y) Then
                    inCombo = True
                    Exit For
                End If
            Next

            '        If cboTemp.Enabled = True And inCombo = False Then
            '            MsgBox ("Data is Invalid, please select in Drop Down List.")
            '            cboTemp.Enabled = True
            '            cboTemp.SetFocus
            '
            '            Exit Sub
            '        End If
        End If
        txtInCombo = inCombo
    End Function
    Private Sub cboPCNo_LostFocus()
        If (txtInCombo(Me.cboPCNo) = False) Then
            MsgBox("Data is Invalid, please select in Drop Down List.")
            cboPCNo.Enabled = True
            cboPCNo.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ActionMode = "Add"
        Cursor = Cursors.WaitCursor
        '    If (Trim(txtPftCtr.Text) = "") Then
        '        Msg "M00012"
        '        txtPftCtr.SetFocus

        '        Exit Sub
        '    End If
        'txtPftCtr.Text = "A"
        Me.cboPCNo.Text = "A"

        Call func_ReadRecordset()

        '    If rs_PCMDV.recordCount > 0 Or rs_PCMAGYCRG.recordCount > 0 Or rs_PCMDEVCRG.recordCount > 0 Or rs_PCMAC.recordCount > 0 Then
        Call Display()
        Call setStatus("Adding")
        'txtPftCtr.Text = ""
        Me.cboPCNo.Text = ""
        '    Else
        '        MsgBox "Profit Center Number not found!"
        '        txtPftCtr.SetFocus
        '        Call ResetDefaultDisp
        '        Cursor = cursors.Default
        '        Exit Sub
        '    End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ActionMode = ""
        Call ResetDefaultDisp()
        Call setStatus("Clear")
    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        ActionMode = "Del"
        Dim txtPCNO As String
        txtPCNO = Me.cboPCNo.Text

        'If txtPftCtr.Text = "STD" Then
        If UCase(Me.cboPCNo.Text) = "STANDARD" Then
            MsgBox("Profit Center STD cannot be deleted!")
            ActionMode = "Chg"
            Exit Sub
        End If

        Dim del As Integer

        'del = MsgBox("Are you sure to delete Profit Center : " & txtPftCtr.Text & " ?", vbOKCancel)
        del = MsgBox("Are you sure to delete Profit Center : " & txtPCNO & " ?", vbOKCancel)

        If del = vbOK Then
            Call func_SaveRecordset()
            Call cmdClear_Click("", EventArgs.Empty)
            Call FillInComboBox()
        End If
    End Sub

    'Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
    '    If SSTabPC.SelectedIndex = 0 And Grid_Got_Focus = "grdAssDgnVen" Then
    '        If rs_PCMDV.Tables(0).Rows.Count > 0 Then
    '            grdAssDgnVen_ButtonClick(0)
    '        End If
    '    ElseIf SSTabPC.SelectedIndex = 1 And Grid_Got_Focus = "grdAgyChrg" Then
    '        If rs_PCMAGYCRG.Tables(0).Rows.Count > 0 Then
    '            grdAgyChrg_ButtonClick(0)
    '        End If
    '    ElseIf SSTabPC.SelectedIndex = 2 And Grid_Got_Focus = "grdDevChrg" Then
    '        If rs_PCMDEVCRG.Tables(0).Rows.Count > 0 Then
    '            grdDevChrg_ButtonClick(0)
    '        End If
    '    End If
    'End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub



    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        If SSTabPC.SelectedIndex = 0 Then
            'And Grid_Got_Focus = "grdAssDgnVen" Then
            'If rs_PCMDV.RecordCount > 0 Then
            '    rs_PCMDV.MoveFirst()
            'End If
            Dim dt As DataTable
            Dim dr As DataRow

            dt = rs_PCMDV.Tables("RESULT")
            For Each dr In dt.Rows
                If dr.Item("pdv_vencde").ToString.Trim = "" Then
                    MsgBox("Please input Vendor code.")
                    Exit Sub
                End If
            Next

            dr = dt.NewRow
            dr.Item("pdv_del") = ""
            dr.Item("pdv_pcno") = Me.cboPCNo.Text
            dr.Item("pdv_vencde") = ""
            dr.Item("pdv_vennam") = ""
            dr.Item("pdv_creusr") = "~*ADD*~"
            dr.Item("pdv_status") = ""
            dt.Rows.Add(dr)

            'For Each drr As DataGridViewRow In grdAssDgnVen.Rows
            '    If IsDBNull(drr.Cells(2).Value) Or drr.Cells(2).Value = "" Then
            '        grdAssDgnVen.CurrentCell = drr.Cells(2)
            '        createComboBoxCell_grdAssDgnVen(grdAssDgnVen.CurrentCell)
            '        grdAssDgnVen.BeginEdit(True)
            '    End If
            'Next


            'rs_PCMDV.Find("pdv_vencde = ''")
            'If rs_PCMDV.EOF Then
            '    If rs_PCMDV.RecordCount < lstVenCde.ListCount Then
            '        rs_PCMDV.AddNew()

            '        rs_PCMDV("pdv_del") = ""
            '        If ActionMode = "Chg" Then
            '            '                    rs_PCMDV("pdv_pcno") = txtPftCtr.Text
            '            rs_PCMDV("pdv_pcno") = Me.cboPCNo.Text
            '        Else
            '            rs_PCMDV("pdv_pcno") = ""
            '        End If
            '        rs_PCMDV("pdv_vencde") = ""
            '        rs_PCMDV("pdv_vennam") = ""
            '        rs_PCMDV("pdv_creusr") = "~*ADD*~"
            '        rs_PCMDV("pdv_status") = ""

            '        rs_PCMDV.Update()
            '        grdAssDgnVen.Focus()
            '        grdAssDgnVen.col = 2
            '    Else
            '        MsgBox("No more assoicated design vendor can be added")
            '    End If
            'End If
        ElseIf SSTabPC.SelectedIndex = 1 Then
            'And Grid_Got_Focus = "grdAgyChrg"
            'If rs_PCMAGYCRG.Tables(0).Rows.Count > 0 Then
            'rs_PCMAGYCRG.MoveFirst()
            'End If

            Dim dt As DataTable
            Dim dr As DataRow

            dt = rs_PCMAGYCRG.Tables("RESULT")

            For Each dr In dt.Rows
                If dr.Item("pac_cocde").ToString.Trim = "" Then
                    MsgBox("Please input Company Code.")
                    Exit Sub
                End If
            Next

            dr = dt.NewRow
            dr.Item("pac_del") = ""
            dr.Item("pac_pcno") = Me.cboPCNo.Text
            dr.Item("pac_cocde") = ""
            dr.Item("pac_cusno") = ""
            dr.Item("pac_cusnam") = ""
            dr.Item("pac_hdcfmlopt") = ""
            dr.Item("pac_hdcfml") = ""
            dr.Item("pac_creusr") = "~*ADD*~"
            dr.Item("pac_status") = ""
            dt.Rows.Add(dr)



            'rs_PCMAGYCRG.Find("pac_cocde = ''")
            'If rs_PCMAGYCRG.EOF Then
            '    'If rs_PCMAGYCRG.recordCount < lstCoCde.ListCount Then
            '    rs_PCMAGYCRG.AddNew()

            '    rs_PCMAGYCRG("pac_del") = ""
            '    If ActionMode = "Chg" Then
            '        'rs_PCMAGYCRG("pac_pcno") = txtPftCtr.Text
            '        rs_PCMAGYCRG("pac_pcno") = Me.cboPCNo.Text
            '    Else
            '        rs_PCMAGYCRG("pac_pcno") = ""
            '    End If
            '    rs_PCMAGYCRG("pac_cocde") = ""
            '    rs_PCMAGYCRG("pac_cusno") = ""
            '    rs_PCMAGYCRG("pac_cusnam") = ""
            '    rs_PCMAGYCRG("pac_hdcfmlopt") = ""
            '    rs_PCMAGYCRG("pac_hdcfml") = ""
            '    rs_PCMAGYCRG("pac_creusr") = "~*ADD*~"
            '    rs_PCMAGYCRG("pac_status") = ""

            '    rs_PCMAGYCRG.Update()
            '    grdAgyChrg.Focus()
            '    grdAgyChrg.col = 2
            '            Else
            '                MsgBox "No more Company can be added"
            '            End If
            'End If
        ElseIf SSTabPC.SelectedIndex = 2 Then
            'And Grid_Got_Focus = "grdDevChrg"
            'If rs_PCMDEVCRG.RecordCount > 0 Then
            '    rs_PCMDEVCRG.MoveFirst()
            'End If




            Dim dt As DataTable
            Dim dr As DataRow

            dt = rs_PCMDEVCRG.Tables("RESULT")

            For Each dr In dt.Rows
                If dr.Item("pdc_facde").ToString.Trim = "" Then
                    MsgBox("Please input vendor Code.")
                    Exit Sub
                End If
            Next

            dr = dt.NewRow
            dr.Item("pdc_del") = ""
            dr.Item("pdc_pcno") = Me.cboPCNo.Text
            dr.Item("pdc_facde") = ""
            dr.Item("pdc_fanam") = ""
            dr.Item("pdc_cusno") = ""
            dr.Item("pdc_cusnam") = ""
            dr.Item("pdc_decfmlopt") = ""
            dr.Item("pdc_decfml") = ""
            dr.Item("pdc_creusr") = "~*ADD*~"
            dr.Item("pdc_status") = ""
            dt.Rows.Add(dr)






            'rs_PCMDEVCRG.Find("pdc_facde = ''")
            'If rs_PCMDEVCRG.EOF Then
            '    'If rs_PCMDEVCRG.recordCount < lstVenCde.ListCount Then
            '    rs_PCMDEVCRG.AddNew()

            '    rs_PCMDEVCRG("pdc_del") = ""
            '    If ActionMode = "Chg" Then
            '        '                    rs_PCMDEVCRG("pdc_pcno") = txtPftCtr.Text
            '        rs_PCMDEVCRG("pdc_pcno") = Me.cboPCNo.Text
            '    Else
            '        rs_PCMDEVCRG("pdc_pcno") = ""
            '    End If
            '    rs_PCMDEVCRG("pdc_facde") = ""
            '    rs_PCMDEVCRG("pdc_fanam") = ""
            '    rs_PCMDEVCRG("pdc_cusno") = ""
            '    rs_PCMDEVCRG("pdc_cusnam") = ""
            '    rs_PCMDEVCRG("pdc_decfmlopt") = ""
            '    rs_PCMDEVCRG("pdc_decfml") = ""
            '    rs_PCMDEVCRG("pdc_creusr") = "~*ADD*~"
            '    rs_PCMDEVCRG("pdc_status") = ""

            '    rs_PCMDEVCRG.Update()
            '    grdDevChrg.Focus()
            '    grdDevChrg.col = 2
            '            Else
            '                MsgBox "No more Vendor can be added"
            '            End If
        End If

    End Sub

    Private Sub cmdNext_Click()
        'Add Code here
        'Check for the browser list recordset
        MsgBox("Next")
    End Sub

    'Private Sub CmdLookup_Click()
    '    frmlookup.Show(vbModal)
    'End Sub

    Private Function HaveDuplicateDV() As Boolean

        'Dim arrDV As Object
        'Dim arrDVCheck As Object
        Dim strTempDV As String
        Dim strErrMsg As String
        Dim i, j As Integer
        HaveDuplicateDV = True
        strErrMsg = ""
        If rs_PCMDV.Tables(0).Rows.Count > 0 And rs_PCMDV_PCM00001.Tables(0).Rows.Count > 0 Then
            Dim arrDV(rs_PCMDV.Tables(0).Rows.Count) As String
            Dim arrDVCheck(rs_PCMDV_PCM00001.Tables(0).Rows.Count) As String
            'rs_PCMDV.MoveFirst()
            For i = 0 To rs_PCMDV.Tables(0).Rows.Count - 1
                arrDV(i) = rs_PCMDV.Tables(0).Rows(i).Item("pdv_vencde")
            Next i

            For i = 0 To rs_PCMDV_PCM00001.Tables(0).Rows.Count - 1
                arrDVCheck(i) = rs_PCMDV_PCM00001.Tables(0).Rows(i).Item("pdv_vencde")
            Next i

            For i = 0 To UBound(arrDV) - 1
                For j = 0 To UBound(arrDVCheck) - 1
                    If arrDV(i) = arrDVCheck(j) Then
                        Exit Function
                        'strErrMsg = strErrMsg & vbCrLf & arrDV(i)
                    End If
                Next j
            Next i
            '        If strErrMsg <> "" Then
            '            MsgBox "The following Company Code(s) is/are assigned to other profit centre" & strErrMsg
            '            Exit Function
            '        End If
        End If
        HaveDuplicateDV = False
    End Function


    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        '***check all Input is vaild
        If Not InputIsValid() Then
            Cursor = Cursors.Default
            save_ok = False
            Exit Sub
        End If

        '    '----------2003/11/27------------
        '    'check a single design vendor is not assigned to more than one profit centre
        '    If HaveDuplicateDV Then
        '        Cursor = cursors.Default
        '        save_ok = False
        '        Exit Sub
        '    End If
        '    '------------end-----------------

        '    Call printRecordSetInfo

        Call func_SaveRecordset()


        If ActionMode = "Add" Then
            '        MsgBox "A new profit center " & txtPftCtr.Text & " is created"
            MsgBox("A new profit center " & Me.cboPCNo.Text & " is created")
            Call FillInComboBox()
        Else
            MsgBox("M00025")
        End If

        ActionMode = ""
        Call ResetDefaultDisp()
        Call setStatus("Clear")

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        'gsSearchKey = ""

        'SYM00018.Module = "PC"
        'SYM00018.Show(1)


        ''    txtPftCtr.Text = gsSearchKey
        'Me.cboPCNo.Text = gsSearchKey

        'gsSearchKey = ""
        ''    txtPftCtr.SelStart = 0
        ''    txtPftCtr.SelLength = Len(txtPftCtr.Text)
        'Me.cboPCNo.selStart = 0
        'Me.cboPCNo.SelLength = Len(Me.cboPCNo.Text)
        '    If txtPftCtr.Text <> "" Then
        '        Timer1.Enabled = True
        '    End If
    End Sub


    'Private Sub Command1_Click()
    '    If rs_VNBASINF.RecordCount > 0 Then
    '        rs_VNBASINF.MoveFirst()
    '        While Not rs_VNBASINF.EOF
    '            Grid_Got_Focus = "grdAssDgnVen"
    '            SSTabPC.SelectedIndex = 0
    '            '            Grid_Got_Focus = "grdDevChrg"
    '            '            SSTabPC.SelectedIndex = 2
    '            cmdInsRow_Click()

    '            rs_PCMDV.Fields("pdv_vencde") = rs_VNBASINF("vbi_venno")
    '            rs_PCMDV.Fields("pdv_vennam") = rs_VNBASINF("vbi_vensna")


    '            '            rs_PCMDEVCRG.Fields("pdc_facde") = rs_VNBASINF("vbi_venno")
    '            '            rs_PCMDEVCRG.Fields("pdc_fanam") = rs_VNBASINF("vbi_vensna")
    '            '            rs_PCMDEVCRG.Fields("pdc_decfmlopt") = "B01"
    '            '            rs_PCMDEVCRG.Fields("pdc_decfml") = "B01"


    '            rs_VNBASINF.MoveNext()
    '        End While
    '    End If
    'End Sub

  




    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then

            cmdAdd.Enabled = Enq_right
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            'CmdLookup.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True
            'cmdspecial.Enabled = False
            'cmdbrowlist.Enabled = False

            cmdfirst.Enabled = False
            cmdlast.Enabled = False
            cmdNext.Enabled = False
            cmdPrv.Enabled = False

            SSTabPC.SelectedIndex = 0
            GroupBox3.Enabled = True

            RadioButton1_CheckedChanged("", EventArgs.Empty)

        ElseIf Mode = "Adding" Then

            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdInsRow.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local

            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False

            SSTabPC.SelectedIndex = 0
            GroupBox3.Enabled = False

        ElseIf Mode = "Updating" Then

            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelete.Enabled = Del_right_local
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdInsRow.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False

            SSTabPC.SelectedIndex = 0
            GroupBox3.Enabled = False

        ElseIf Mode = "Clear" Then

            Call setStatus("Init")
        End If

        'Check for access right
        If Not CanModify Then
            cmdAdd.Enabled = False
            cmdCopy.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
        End If


    End Sub


    Private Sub ResetDefaultStatus()
        'StatusBar.Panels(1).Text = ""
        'StatusBar.Panels(2).Text = ""
    End Sub


    Public Sub Display()
        Call func_SetGrid()
        Call func_SetAcctInf()
        'txtPftCtr.Enabled = False
        Me.cboPCNo.Enabled = False
        SSTabPC.Enabled = True
    End Sub


    Private Function func_SetGrid()

        'grdAssDgnVen.DataSource = rs_PCMDV.Tables(0).DefaultView
        bindSrc.DataSource = rs_PCMDV.Tables(0).DefaultView
        With grdAssDgnVen
            .DataSource = Nothing
            .DataSource = bindSrc
        End With
        For i As Integer = 0 To rs_PCMDV.Tables(0).Columns.Count - 1
            rs_PCMDV.Tables(0).Columns(i).ReadOnly = False
            grdAssDgnVen.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Call SetgrdAssDgnVen()


        'grdAgyChrg.DataSource = rs_PCMAGYCRG.Tables(0).DefaultView
        bindSrc2.DataSource = rs_PCMAGYCRG.Tables(0).DefaultView
        With grdAgyChrg
            .DataSource = Nothing
            .DataSource = bindSrc2
        End With
        For i As Integer = 0 To rs_PCMAGYCRG.Tables(0).Columns.Count - 1
            rs_PCMAGYCRG.Tables(0).Columns(i).ReadOnly = False
            grdAgyChrg.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Call SetgrdAgyChrg()


        bindSrc3.DataSource = rs_PCMDEVCRG.Tables(0).DefaultView
        'grdDevChrg.DataSource = rs_PCMDEVCRG.Tables(0).DefaultView
        With grdDevChrg
            .DataSource = Nothing
            .DataSource = bindSrc3
        End With
        For i As Integer = 0 To rs_PCMDEVCRG.Tables(0).Columns.Count - 1
            rs_PCMDEVCRG.Tables(0).Columns(i).ReadOnly = False
            grdDevChrg.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Call SetgrdDevChrg()

    End Function

    Private Function func_SetAcctInf()
        If rs_PCMAC.Tables(0).Rows.Count > 0 Then
            'rs_PCMAC.MoveFirst()
            txtInvActNo.Text = rs_PCMAC.Tables(0).Rows(0).Item("pma_invacno")
            txtSamInvActNo.Text = rs_PCMAC.Tables(0).Rows(0).Item("pma_siacno")
            txtInvAdjActNo.Text = rs_PCMAC.Tables(0).Rows(0).Item("pma_iaacno")
            txtSamTerActNo.Text = rs_PCMAC.Tables(0).Rows(0).Item("pma_stacno")
        End If
    End Function


    Private Function func_getNewPCNO() As String
        Dim rs As DataSet
        Dim S As String
        Dim i As Integer
        Dim pcno As String




        gspStr = "sp_select_PCMAC_PCNO '', ''"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Cursor = Cursors.WaitCursor
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_PCMAC_PCNO:" & rtnStr)
            Exit Function
        End If

        Cursor = Cursors.Default




        'S = "㊣PCMAC_PCNO※S※N"

        'Cursor = Cursors.WaitCursor

        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.Default

        'If rs(0)(0) <> "0" Then  '*** An error has occured
        '    MsgBox(rs(0)(0))
        'Else
        '    pcno = rs(1).Fields("pma_pcno")
        'End If

        pcno = rs.Tables(0).Rows(0).Item("pma_pcno")
        For i = 0 To 1 - Len(pcno)
            pcno = "0" & pcno
        Next i

        func_getNewPCNO = "PC" & pcno

    End Function



    Private Function func_ReadRecordset()
        'Dim rs() As DataSet
        Dim S As String
        Dim i As Integer
        Dim txtPCNO As String

        txtPCNO = Me.cboPCNo.Text

        '    S = "㊣PCMDV※S※" & txtPftCtr.Text & _
        '        "㊣PCMAGYCRG※S※" & txtPftCtr.Text & _
        '        "㊣PCMDEVCRG※S※" & txtPftCtr.Text & _
        '        "㊣PCMAC※S※" & txtPftCtr.Text & _
        '        "㊣PCMDV_PCM00001※S※" & txtPftCtr.Text

        Cursor = Cursors.WaitCursor
        'S = "㊣PCMDV※S※" & txtPCNO & _
        '    "㊣PCMAGYCRG※S※" & txtPCNO & _
        '    "㊣PCMDEVCRG※S※" & txtPCNO & _
        '    "㊣PCMAC※S※" & txtPCNO & _
        '    "㊣PCMDV_PCM00001※S※" & txtPCNO


        gspStr = "sp_select_PCMDV '', '" & txtPCNO & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PCMDV, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_PCMDV:" & rtnStr)
            Exit Function
        End If



        gspStr = "sp_select_PCMAGYCRG '', '" & txtPCNO & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PCMAGYCRG, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_PCMAGYCRG:" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_PCMDEVCRG '', '" & txtPCNO & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PCMDEVCRG, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_PCMDEVCRG:" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_PCMAC '', '" & txtPCNO & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PCMAC, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_PCMAC:" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_PCMDV_PCM00001 '', '" & txtPCNO & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PCMDV_PCM00001, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_PCMDV_PCM00001:" & rtnStr)
            Exit Function
        End If

        Cursor = Cursors.Default




        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        'Cursor = Cursors.Default

        'If rs(0)(0) <> "0" Then  '*** An error has occured
        '    MsgBox(rs(0)(0))
        'Else

        'rs_PCMDV = CopyRS(rs(1))
        'rs_PCMAGYCRG = CopyRS(rs(2))
        'rs_PCMDEVCRG = CopyRS(rs(3))
        'rs_PCMAC = CopyRS(rs(4))
        'rs_PCMDV_PCM00001 = CopyRS(rs(5))
        'End If
    End Function

    'Private Sub func_ReadEmptyRecordset()
    '    Dim txtPCNO As String = ""

    '    gspStr = "sp_select_PCMDV 'EMPTY', ''"
    '    rtnLong = execute_SQLStatement(gspStr, rs_PCMDV_empty, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        Cursor = Cursors.Default
    '        MsgBox("Error on loading sp_select_PCMDV:" & rtnStr)
    '        Exit Sub
    '    End If

    '    gspStr = "sp_select_PCMAGYCRG 'EMPTY', ''"
    '    rtnLong = execute_SQLStatement(gspStr, rs_PCMAGYCRG_empty, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        Cursor = Cursors.Default
    '        MsgBox("Error on loading sp_select_PCMAGYCRG:" & rtnStr)
    '        Exit Sub
    '    End If


    '    gspStr = "sp_select_PCMDEVCRG 'EMPTY', '" & txtPCNO & "'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_PCMDEVCRG_empty, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        Cursor = Cursors.Default
    '        MsgBox("Error on loading sp_select_PCMDEVCRG:" & rtnStr)
    '        Exit Sub
    '    End If

    '    gspStr = "sp_select_PCMAC 'EMPTY', '" & txtPCNO & "'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_PCMAC_empty, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        Cursor = Cursors.Default
    '        MsgBox("Error on loading sp_select_PCMAC:" & rtnStr)
    '        Exit Sub
    '    End If


    '    'gspStr = "sp_select_PCMDV_PCM00001 'EMPTY', '" & txtPCNO & "'"
    '    'rtnLong = execute_SQLStatement(gspStr, rs_PCMDV_PCM00001_empty, rtnStr)
    '    'If rtnLong <> RC_SUCCESS Then
    '    '    Cursor = Cursors.Default
    '    '    MsgBox("Error on loading sp_select_PCMDV_PCM00001:" & rtnStr)
    '    '    Exit Sub
    '    'End If




    'End Sub






    Private Sub SetgrdAssDgnVen()



        With grdAssDgnVen

            .Columns(0).Width = 38
            .Columns(0).HeaderText = "Del"
            '.Columns(0).Button = True
            '.Columns(0).Locked = True

            '.Columns(1).Width = 0
            .Columns(1).Visible = False

            .Columns(2).Width = 70
            .Columns(2).HeaderText = "Vendor Code"
            '.Columns(2).Button = True
            '.Columns(2).Locked = True

            .Columns(3).Width = 100
            .Columns(3).HeaderText = "Vendor Name"
            '.Columns(3).Button = True
            '.Columns(3).Locked = True

            '.Columns(4).Width = 0
            .Columns(4).Visible = False

            '.Columns(5).Width = 0
            .Columns(5).Visible = False

        End With

    End Sub


    Private Sub SetgrdAgyChrg()
        'If rs_PCMAGYCRG.Tables(0).Rows.Count = 0 Then
        '    Exit Sub
        'End If

        With grdAgyChrg

            ' .AllowUpdate = True

            .Columns(0).Width = 38
            .Columns(0).HeaderText = "Del"
            '.Columns(0).Button = True
            '.Columns(0).Locked = True

            '.Columns(1).Width = 0
            .Columns(1).Visible = False

            .Columns(2).Width = 100
            .Columns(2).HeaderText = "Company Code"
            ' .Columns(2).Button = True
            ' .Columns(2).Locked = True

            .Columns(3).Width = 100
            .Columns(3).HeaderText = "Customer Code"
            '.Columns(3).Button = True
            '.Columns(3).Locked = True

            .Columns(4).Width = 150
            .Columns(4).HeaderText = "Customer Name"
            '.Columns(4).Button = True
            '.Columns(4).Locked = True

            '.Columns(5).Width = 0
            '.Columns(5).Visible = False



            .Columns(5).Width = 150
            .Columns(5).HeaderText = "Handling Charge Formula"

            .Columns(6).Visible = False
            '.Columns(6).Width = 150
            '.Columns(6).HeaderText = "Handling Charge Formula"
            '.Columns(6).Button = True
            '.Columns(6).Locked = True

            '.Columns(7).Width = 0
            .Columns(7).Visible = False

            '.Columns(8).Width = 0
            .Columns(8).Visible = False
        End With

    End Sub


    Private Sub SetgrdDevChrg()
        'If rs_PCMDEVCRG.Tables(0).Rows.Count = 0 Then
        '    Exit Sub
        'End If

        With grdDevChrg

            '.AllowUpdate = True

            .Columns(0).Width = 38
            .Columns(0).HeaderText = "Del"
            '.Columns(0).Button = True
            '.Columns(0).Locked = True

            '.Columns(1).Width = 0
            .Columns(1).Visible = False

            .Columns(2).Width = 100
            .Columns(2).HeaderText = "Factory Code"
            '.Columns(2).Button = True
            '.Columns(2).Locked = True

            .Columns(3).Width = 150
            .Columns(3).HeaderText = "Factory Name"
            '.Columns(3).Button = True
            '.Columns(3).Locked = True

            .Columns(4).Width = 150
            .Columns(4).HeaderText = "Customer Code"
            '.Columns(4).Button = True
            '.Columns(4).Locked = True

            .Columns(5).Width = 150
            .Columns(5).HeaderText = "Customer Name"
            '.Columns(5).Button = True
            '.Columns(5).Locked = True

            '.Columns(6).Width = 0
            '.Columns(6).Visible = False
            .Columns(6).Width = 150
            .Columns(6).HeaderText = "Development Charge Formula"



            .Columns(7).Visible = False
            '.Columns(7).Width = 150
            '.Columns(7).HeaderText = "Development Charge Formula"
            '.Columns(7).Button = True
            '.Columns(7).Locked = True

            '.Columns(8).Width = 0
            .Columns(8).Visible = False

            '.Columns(9).Width = 0
            .Columns(9).Visible = False

        End With

    End Sub


    Private Sub FillInComboBox()
        Dim S As String
        'Dim rs() As Dataset

        gspStr = "sp_list_PCMAC_PCNO ''"
        rtnLong = execute_SQLStatement(gspStr, rs_PCMAC_PCNO, rtnStr)
        Cursor = Cursors.WaitCursor
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_list_PCMAC_PCNO:" & rtnStr)
            Exit Sub
        End If

        cboPCNo.Items.Clear()
        For i As Integer = 0 To rs_PCMAC_PCNO.Tables("RESULT").Rows.Count - 1
            cboPCNo.Items.Add(rs_PCMAC_PCNO.Tables("RESULT").Rows(i).Item("pma_pcno"))
        Next

        Cursor = Cursors.Default

    End Sub

    Private Sub FillcboCust()
        'If rs_CUBASINF.recordCount > 0 Then
        '    While Not rs_CUBASINF.EOF
        '        cboCustNoFm.AddItem rs_CUBASINF("cbi_cusno") & " - " & rs_CUBASINF("cbi_cussna")
        '        cboCustNoTo.AddItem rs_CUBASINF("cbi_cusno") & " - " & rs_CUBASINF("cbi_cussna")
        '        rs_CUBASINF.MoveNext
        '    Wend
        'End If
    End Sub

    Private Function FillInListBox()
        Dim rs() As Dataset
        Dim S As String
        Dim i As Integer

        'S = "㊣SYCOMINF_M※S※ALL" & _
        '    "㊣VNBASINF※L" & _
        '    "㊣SYFMLINF※S" & _
        '    "㊣CUBASINF※L※PA" ' show all primary customer info in agency charge folder






        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_SYCOMINF_M '', 'ALL'"
        rtnLong = execute_SQLStatement(gspStr, rs_sycominf, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_SYCOMINF_M:" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_list_VNBASINF:" & rtnStr)
            Exit Function
        End If

        setVendorList()

        gspStr = "sp_select_SYFMLINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYFMLINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_SYFMLINF:" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_CUBASINF '','PA'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_list_CUBASINF:" & rtnStr)
            Exit Function
        End If


        Cursor = Cursors.Default

        CompanyList.Clear()
        CompanyList.Add("STANDARD")
        If rs_sycominf.Tables(0).Rows.Count > 0 Then
            For j As Integer = 0 To rs_sycominf.Tables(0).Rows.Count - 1
                CompanyList.Add(rs_sycominf.Tables(0).Rows(j).Item("yco_cocde"))
            Next
        End If

        Cust_LongList.Clear()
        Cust_ShortList.Clear()
        Cust_ShortList.Add("STANDARD")
        Cust_LongList.Add("STANDARD")
        For j As Integer = 0 To rs_CUBASINF.Tables(0).Rows.Count - 1
            Cust_ShortList.Add(rs_CUBASINF.Tables(0).Rows(j).Item("cbi_cusno"))
            Cust_LongList.Add(rs_CUBASINF.Tables(0).Rows(j).Item("cbi_cussna"))

        Next

        ChargeList.Clear()
        For j As Integer = 0 To rs_SYFMLINF.Tables(0).Rows.Count - 1
            ChargeList.Add(Trim(rs_SYFMLINF.Tables(0).Rows(j).Item("yfi_fmlopt")) + " - " + Trim(rs_SYFMLINF.Tables(0).Rows(j).Item("yfi_fml")))
        Next

        ''set a list of primary customers
        'Me.lstCustName.Clear()
        'Me.lstCustNo.Clear()
        'lstCustName.AddItem("STANDARD")
        'lstCustNo.AddItem("STANDARD")
        'If rs_CUBASINF.RecordCount > 0 Then
        '    rs_CUBASINF.MoveFirst()
        '    While Not rs_CUBASINF.EOF
        '        lstCustName.AddItem(rs_CUBASINF("cbi_cusno") & " - " & rs_CUBASINF("cbi_cussna"))
        '        lstCustNo.AddItem(rs_CUBASINF("cbi_cusno") & " - " & rs_CUBASINF("cbi_cussna"))
        '        rs_CUBASINF.MoveNext()
        '    End While
        'End If

        'lstVenCde.Clear()
        'lstFtyCde.Clear()
        'lstFtyCde.AddItem("STANDARD")
        'rs_VNBASINF.Filter = "vbi_venno >= 'A'"
        'If rs_VNBASINF.RecordCount > 0 Then
        '    rs_VNBASINF.MoveFirst()
        '    While Not rs_VNBASINF.EOF
        '        lstVenCde.AddItem(Trim(rs_VNBASINF("vbi_venno")) + " - " + Trim(rs_VNBASINF("vbi_vensna")))
        '        lstFtyCde.AddItem(Trim(rs_VNBASINF("vbi_venno")) + " - " + Trim(rs_VNBASINF("vbi_vensna")))
        '        rs_VNBASINF.MoveNext()
        '    End While
        'End If

        'lstHdChrgFml.Clear()
        'lstDevChrgFml.Clear()
        'If rs_SYFMLINF.RecordCount > 0 Then
        '    rs_SYFMLINF.MoveFirst()
        '    While Not rs_SYFMLINF.EOF
        '        lstHdChrgFml.AddItem(Trim(rs_SYFMLINF("yfi_fmlopt")) + " - " + Trim(rs_SYFMLINF("yfi_fml")))
        '        lstDevChrgFml.AddItem(Trim(rs_SYFMLINF("yfi_fmlopt")) + " - " + Trim(rs_SYFMLINF("yfi_fml")))
        '        rs_SYFMLINF.MoveNext()
        '    End While
        'End If

    End Function



    Private Sub ResetDefaultDisp()
        '    txtPftCtr.Enabled = True
        Me.cboPCNo.Enabled = True
        'Tab 1 Associated Design Vendor
        grdAssDgnVen.DataSource = Nothing
        'lstVenCde.Visible = False

        'Tab 2 Agency Charge
        grdAgyChrg.DataSource = Nothing
        'lstCoCde.Visible = False
        ' lstHdChrgFml.Visible = False

        'Tab 3 Development Charge
        grdDevChrg.DataSource = Nothing
        'lstFtyCde.Visible = False
        'lstDevChrgFml.Visible = False

        'Tab 4 Account Interface
        txtInvActNo.Text = ""
        txtSamInvActNo.Text = ""
        txtInvAdjActNo.Text = ""
        txtSamTerActNo.Text = ""

        SSTabPC.Enabled = False

    End Sub



    Private Sub grdAgyChrg_AfterColUpdate(ByVal ColIndex As Integer)

        'If rs_PCMAGYCRG.recordCount > 0 Then
        '    If rs_PCMAGYCRG.Fields("pac_creusr") <> "~*ADD*~" And _
        '        rs_PCMAGYCRG.Fields("pac_creusr") <> "~*DEL*~" And _
        '        rs_PCMAGYCRG.Fields("pac_creusr") <> "~*NEW*~" And _
        '        rs_PCMAGYCRG.Fields("pac_creusr") <> "~*UPD*~" _
        '        Then
        '        If (ColIndex = 0 Or ColIndex = 1 Or ColIndex = 2 Or ColIndex = 3 Or ColIndex = 4 Or ColIndex = 5) And rs_PCMAGYCRG.Fields("pac_creusr") <> "~*ADD*~" And rs_PCMAGYCRG.Fields("pac_creusr") <> "~*DEL*~" Then
        '            rs_PCMAGYCRG.Fields("pac_creusr") = "~*UPD*~"
        '            Recordstatus = True
        '        End If
        '        Recordstatus = True
        '    End If
        'End If
        'grdAgyChrg.Focus()

    End Sub

    Private Function isAgyEssential(ByVal row As Integer) As Boolean
        isAgyEssential = False
        If (rs_PCMAGYCRG.Tables(0).Rows(row).Item("pac_cocde") = "STANDARD" And rs_PCMAGYCRG.Tables(0).Rows(row).Item("pac_cusno") = "STANDARD") Then
            'Or rs_PCMAGYCRG.Fields("pac_cusno") = "STANDARD" Then
            'Not sure there ar records like "STANDARD","00005","","B*1"
            isAgyEssential = True
            MsgBox("Cannot Delete This Record")
        End If
    End Function

    Private Function isDevEssential(ByVal row As Integer) As Boolean
        isDevEssential = False
        If (rs_PCMDEVCRG.Tables(0).Rows(row).Item("pdc_facde") = "STANDARD" And rs_PCMDEVCRG.Tables(0).Rows(row).Item("pdc_cusno") = "STANDARD") Then
            'Or rs_PCMDEVCRG.Fields("pdc_cusno") = "STANDARD" Then
            'Not sure there ar records like "STANDARD","00005","","B*1"
            isDevEssential = True
            MsgBox("Cannot Delete This Record")
        End If
    End Function

    Private Sub grdAgyChrg_ButtonClick(ByVal ColIndex As Integer)
        'If ColIndex = 0 Then
        '    If rs_PCMAGYCRG.Fields("pac_del") = "" Then
        '        If isAgyEssential() Then
        '            Exit Sub
        '        End If
        '        rs_PCMAGYCRG.Fields("pac_del") = "Y"
        '        If rs_PCMAGYCRG.Fields("pac_creusr") <> "~*ADD*~" And _
        '            rs_PCMAGYCRG.Fields("pac_creusr") <> "~*DEL*~" And _
        '            rs_PCMAGYCRG.Fields("pac_creusr") <> "~*NEW*~" Then
        '            rs_PCMAGYCRG.Fields("pac_creusr") = "~*DEL*~"
        '        End If
        '    Else
        '        rs_PCMAGYCRG.Fields("pac_del") = ""
        '        If rs_PCMAGYCRG.Fields("pac_creusr") = "~*DEL*~" Then
        '            rs_PCMAGYCRG.Fields("pac_creusr") = "~*UPD*~"
        '        End If
        '    End If
        'ElseIf ColIndex = 2 Then
        '    If rs_PCMAGYCRG.Fields("pac_creusr") <> "~*ADD*~" And _
        '        rs_PCMAGYCRG.Fields("pac_creusr") <> "~*DEL*~" And _
        '        rs_PCMAGYCRG.Fields("pac_creusr") <> "~*NEW*~" Then
        '        '            And _
        '        '            rs_PCMAGYCRG.Fields("pac_creusr") <> "~*UPD*~" Then

        '        MsgBox("Cannot change Profit Center Company")
        '        Exit Sub
        '    Else
        '        If lstCoCde.Visible = False Then
        '            lstCoCde.Visible = True
        '            lstCoCde.Focus()
        '        lstCoCde.Move (grdAgyChrg.Columns(2).Left + grdAgyChrg.Left), (grdAgyChrg.RowTop(grdAgyChrg.row) + grdAgyChrg.Columns(2).Top + grdAgyChrg.Top)
        '        Else
        '            lstCoCde.Visible = False
        '        End If

        '        If lstHdChrgFml.Visible = True Then
        '            lstHdChrgFml.Visible = False
        '        End If
        '        If Me.lstCustName.Visible = True Then
        '            Me.lstCustName.Visible = False
        '        End If

        '    End If
        'ElseIf ColIndex = 3 Or ColIndex = 4 Then ' customer name
        '    If rs_PCMAGYCRG.Fields("pac_creusr") <> "~*ADD*~" And _
        '        rs_PCMAGYCRG.Fields("pac_creusr") <> "~*DEL*~" And _
        '        rs_PCMAGYCRG.Fields("pac_creusr") <> "~*NEW*~" Then
        '        '            And _
        '        '            rs_PCMAGYCRG.Fields("pac_creusr") <> "~*UPD*~" Then

        '        MsgBox("Cannot change Profit Center Customer")
        '        Exit Sub
        '    Else
        '        If lstCustName.Visible = False Then
        '            lstCustName.Visible = True
        '            lstCustName.Focus()
        '        lstCustName.Move (grdAgyChrg.Columns(ColIndex).Left + grdAgyChrg.Left), (grdAgyChrg.RowTop(grdAgyChrg.row) + grdAgyChrg.Columns(ColIndex).Top + grdAgyChrg.Top)
        '        Else
        '            lstCustName.Visible = False
        '        End If

        '        If Me.lstCoCde.Visible = True Then
        '            Me.lstCoCde.Visible = False
        '        End If

        '        If lstHdChrgFml.Visible = True Then
        '            lstHdChrgFml.Visible = False
        '        End If

        '    End If
        'ElseIf ColIndex = 6 Then
        '    If lstHdChrgFml.Visible = False Then
        '        lstHdChrgFml.Visible = True
        '        lstHdChrgFml.Focus()
        '    lstHdChrgFml.Move (grdAgyChrg.Columns(ColIndex).Left + grdAgyChrg.Left), (grdAgyChrg.RowTop(grdAgyChrg.row) + grdAgyChrg.Columns(ColIndex).Top + grdAgyChrg.Top)
        '    Else
        '        lstHdChrgFml.Visible = False
        '    End If

        '    If lstCoCde.Visible = True Then
        '        lstCoCde.Visible = False
        '    End If

        '    If Me.lstCustName.Visible = True Then
        '        Me.lstCustName.Visible = False
        '    End If


        'End If
    End Sub

    Private Sub grdAgyChrg_Click()

        'If grdAgyChrg.col <> 2 Then
        '    If lstCoCde.Visible = True Then
        '        lstCoCde.Visible = False
        '    End If
        'End If
        'If grdAgyChrg.col <> 3 Or grdAgyChrg.col <> 4 Then
        '    If lstCustName.Visible = True Then
        '        lstCustName.Visible = False
        '    End If
        'End If
        'If grdAgyChrg.col <> 5 Then
        '    If lstHdChrgFml.Visible = True Then
        '        lstHdChrgFml.Visible = False
        '    End If
        'End If

    End Sub

    Private Sub grdAgyChrg_GotFocus()
        Grid_Got_Focus = "grdAgyChrg"
    End Sub

    Private Sub grdAssDgnVen_AfterColUpdate(ByVal ColIndex As Integer)
        'If rs_PCMDV.recordCount > 0 Then
        '    If rs_PCMDV.Fields("pdv_creusr") <> "~*ADD*~" And _
        '        rs_PCMDV.Fields("pdv_creusr") <> "~*DEL*~" And _
        '        rs_PCMDV.Fields("pdv_creusr") <> "~*NEW*~" And _
        '        rs_PCMDV.Fields("pdv_creusr") <> "~*UPD*~" _
        '        Then
        '        If (ColIndex = 0 Or ColIndex = 1 Or ColIndex = 2 Or ColIndex = 3 Or ColIndex = 4 Or ColIndex = 5 Or ColIndex = 6 Or _
        '             ColIndex = 7) And rs_PCMDV.Fields("pdv_creusr") <> "~*ADD*~" And rs_PCMDV.Fields("pdv_creusr") <> "~*DEL*~" Then
        '            rs_PCMDV.Fields("pdv_creusr") = "~*UPD*~"
        '            Recordstatus = True
        '        End If
        '        Recordstatus = True
        '    End If
        'End If
        grdAssDgnVen.Focus()
    End Sub

   


    Private Sub grdAssDgnVen_Click()
        'If grdAssDgnVen.col <> 2 And grdAssDgnVen.col <> 3 Then
        '    If lstVenCde.Visible = True Then
        '        lstVenCde.Visible = False
        '    End If
        'End If
    End Sub

    Private Sub grdAssDgnVen_GotFocus()
        Grid_Got_Focus = "grdAssDgnVen"
    End Sub

    Private Sub grdDevChrg_AfterColUpdate(ByVal ColIndex As Integer)
        'If rs_PCMDEVCRG.recordCount > 0 Then
        '    If rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*ADD*~" And _
        '        rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*DEL*~" And _
        '        rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*NEW*~" And _
        '        rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*UPD*~" _
        '        Then
        '        If (ColIndex = 0 Or ColIndex = 1 Or ColIndex = 2 Or ColIndex = 3 Or ColIndex = 4 Or ColIndex = 5 Or ColIndex = 6 Or _
        '             ColIndex = 7) And rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*ADD*~" And rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*DEL*~" Then
        '            rs_PCMDEVCRG.Fields("pdc_creusr") = "~*UPD*~"
        '            Recordstatus = True
        '        End If
        '        Recordstatus = True
        '    End If
        'End If
        'grdDevChrg.Focus()
    End Sub

    Private Sub grdDevChrg_ButtonClick(ByVal ColIndex As Integer)
        'If ColIndex = 0 Then
        '    If rs_PCMDEVCRG.Fields("pdc_del") = "" Then
        '        If isDevEssential() Then
        '            Exit Sub
        '        End If

        '        rs_PCMDEVCRG.Fields("pdc_del") = "Y"
        '        If rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*ADD*~" And rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*DEL*~" And _
        '            rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*NEW*~" Then
        '            rs_PCMDEVCRG.Fields("pdc_creusr") = "~*DEL*~"
        '        End If
        '    Else
        '        rs_PCMDEVCRG.Fields("pdc_del") = ""
        '        If rs_PCMDEVCRG.Fields("pdc_creusr") = "~*DEL*~" Then
        '            rs_PCMDEVCRG.Fields("pdc_creusr") = "~*UPD*~"
        '        End If
        '    End If
        'ElseIf ColIndex = 2 Or ColIndex = 3 Then
        '    If rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*ADD*~" And _
        '        rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*DEL*~" And _
        '        rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*NEW*~" Then
        '        'rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*UPD*~" Then

        '        MsgBox("Cannot change Profit Center Factory")
        '        Exit Sub
        '    Else
        '        If lstFtyCde.Visible = False Then
        '            lstFtyCde.Visible = True
        '            lstFtyCde.Focus()
        '        lstFtyCde.Move (grdDevChrg.Columns(2).Left + grdDevChrg.Left), (grdDevChrg.RowTop(grdDevChrg.row) + grdDevChrg.Columns(2).Top + grdDevChrg.Top)
        '        Else
        '            lstFtyCde.Visible = False
        '        End If

        '        If lstDevChrgFml.Visible = True Then
        '            lstDevChrgFml.Visible = False
        '        End If

        '    End If
        'ElseIf ColIndex = 4 Or ColIndex = 5 Then
        '    If rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*ADD*~" And _
        '        rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*DEL*~" And _
        '        rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*NEW*~" Then
        '        'rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*UPD*~" Then

        '        MsgBox("Cannot change Profit Center Factory")
        '        Exit Sub
        '    Else
        '        If lstCustNo.Visible = False Then
        '            lstCustNo.Visible = True
        '            lstCustNo.Focus()
        '        lstCustNo.Move (grdDevChrg.Columns(ColIndex).Left + grdDevChrg.Left), (grdDevChrg.RowTop(grdDevChrg.row) + grdDevChrg.Columns(ColIndex).Top + grdDevChrg.Top)
        '        Else
        '            lstFtyCde.Visible = False
        '        End If

        '        If lstDevChrgFml.Visible = True Then
        '            lstDevChrgFml.Visible = False
        '        End If

        '    End If
        'ElseIf ColIndex = 7 Then
        '    If lstDevChrgFml.Visible = False Then
        '        lstDevChrgFml.Visible = True
        '        lstDevChrgFml.Focus()
        '    lstDevChrgFml.Move (grdDevChrg.Columns(ColIndex).Left + grdDevChrg.Left), (grdDevChrg.RowTop(grdDevChrg.row) + grdDevChrg.Columns(ColIndex).Top + grdDevChrg.Top)
        '    Else
        '        lstDevChrgFml.Visible = False
        '    End If

        '    If lstFtyCde.Visible = True Then
        '        lstFtyCde.Visible = False
        '    End If

        'End If
    End Sub

    Private Sub grdDevChrg_Click()
        'If grdDevChrg.col <> 2 And grdDevChrg.col <> 3 Then
        '    If lstFtyCde.Visible = True Then
        '        lstFtyCde.Visible = False
        '    End If
        'End If

        'If grdDevChrg.col <> 5 Then
        '    If lstHdChrgFml.Visible = True Then
        '        lstHdChrgFml.Visible = False
        '    End If
        'End If

    End Sub

    Private Sub grdDevChrg_GotFocus()
        Grid_Got_Focus = "grdDevChrg"
    End Sub

    Private Sub lblPftCtr_Click()

    End Sub

    Private Sub lstCoCde_Click()

        'Dim pos As Integer
        'Dim orgCoCde As String
        'Dim orgCoNam As String
        'Dim newCoCde As String
        'Dim newCoNam As String

        'pos = rs_PCMAGYCRG.AbsolutePosition
        'orgCoCde = rs_PCMAGYCRG.Fields("pac_cocde")
        ''orgCoNam = rs_PCMAGYCRG.Fields("pac_conam")
        'If InStr(lstCoCde.Text, " - ") > 0 Then
        '    newCoCde = Mid(lstCoCde.Text, 1, InStr(lstCoCde.Text, " - ") - 1)
        'Else
        '    newCoCde = "STANDARD"
        'End If
        ''newCoNam = Mid(lstCoCde.Text, InStr(lstCoCde.Text, " - ") + 3)

        'rs_PCMAGYCRG.Fields("pac_cocde") = newCoCde
        ''rs_PCMAGYCRG.Fields("pac_conam") = newCoNam

        'If InvalidArgCrgLevel = True Then
        '    MsgBox("Incorrect Combination of Company Code and Customer Name")
        '    Call gotorecord(rs_PCMAGYCRG, pos)
        '    rs_PCMAGYCRG.Fields("pac_cocde") = orgCoCde
        '    Exit Sub
        'ElseIf HaveDuplicateAgencyCharge = True Then
        '    MsgBox("Duplicate Company Code and Customer Name")
        '    Call gotorecord(rs_PCMAGYCRG, pos)

        '    rs_PCMAGYCRG.Fields("pac_cocde") = orgCoCde
        '    'rs_PCMAGYCRG.Fields("pac_conam") = orgCoNam

        '    Exit Sub
        'Else
        '    Call gotorecord(rs_PCMAGYCRG, pos)

        '    Call grdAgyChrg_AfterColUpdate(2)
        '    'Call grdAgyChrg_AfterColUpdate(3)
        'End If



        'lstCoCde.Visible = False
        'grdAgyChrg.Focus()
    End Sub

    Private Sub lstCoCde_LostFocus()
        'lstCoCde.Visible = False
    End Sub
    Private Function getValue(ByVal para As Object) As Object
        'If Not IsNull(para) Then
        If Not para Is Nothing Then
            getValue = para
        Else
            getValue = ""
        End If
    End Function


    Private Function InvalidArgCrgLevel(ByVal row As Integer) As Boolean
        InvalidArgCrgLevel = False
        If rs_PCMAGYCRG.Tables(0).Rows(row).Item("pac_cocde") = "STANDARD" And rs_PCMAGYCRG.Tables(0).Rows(row).Item("pac_cusno") <> "" And rs_PCMAGYCRG.Tables(0).Rows(row).Item("pac_cusno") <> "STANDARD" Then
            InvalidArgCrgLevel = True
        End If
    End Function

    Private Function InvalidDevCrgLevel(ByVal row As Integer) As Boolean
        InvalidDevCrgLevel = False
        If rs_PCMDEVCRG.Tables(0).Rows(row).Item("pdc_facde") = "STANDARD" And rs_PCMDEVCRG.Tables(0).Rows(row).Item("pdc_cusno") <> "" And rs_PCMDEVCRG.Tables(0).Rows(row).Item("pdc_cusno") <> "STANDARD" Then
            InvalidDevCrgLevel = True
        End If
    End Function

    Private Sub lstCustName_Click()

        'Dim pos As Integer
        'Dim orgCusNam As String
        'Dim orgCusCode As String

        'Dim newCusNam As String
        'Dim newCusCode As String

        'pos = rs_PCMAGYCRG.AbsolutePosition
        'orgCusCode = getValue(rs_PCMAGYCRG.Fields("pac_cusno"))
        'orgCusNam = rs_PCMAGYCRG.Fields("pac_cusnam")
        'If (InStr(lstCustName.Text, " - ") > 0) Then
        '    newCusCode = Mid(lstCustName.Text, 1, InStr(lstCustName.Text, " - ") - 1)
        '    newCusNam = Mid(lstCustName.Text, InStr(lstCustName.Text, " - ") + 3)
        'Else
        '    newCusCode = "STANDARD"
        '    newCusNam = Trim(lstCustName.Text)
        'End If

        'rs_PCMAGYCRG.Fields("pac_cusnam") = newCusNam
        'rs_PCMAGYCRG.Fields("pac_cusno") = newCusCode
        'If InvalidArgCrgLevel = True Then
        '    MsgBox("Incorrect Combination of Company Code and Customer Name")
        '    Call gotorecord(rs_PCMAGYCRG, pos)
        '    rs_PCMAGYCRG.Fields("pac_cusnam") = orgCusNam
        '    rs_PCMAGYCRG.Fields("pac_cusno") = orgCusCode
        '    Exit Sub
        'ElseIf HaveDuplicateAgencyCharge = True Then
        '    MsgBox("Duplicate Company Code and Customer Name")
        '    Call gotorecord(rs_PCMAGYCRG, pos)
        '    rs_PCMAGYCRG.Fields("pac_cusnam") = orgCusNam
        '    rs_PCMAGYCRG.Fields("pac_cusno") = orgCusCode
        '    Exit Sub
        'Else
        '    Call gotorecord(rs_PCMAGYCRG, pos)
        '    Call grdAgyChrg_AfterColUpdate(4)
        '    Call grdAgyChrg_AfterColUpdate(3)
        'End If



        'lstCustName.Visible = False
        'grdAgyChrg.Focus()
    End Sub

    Private Sub lstCustName_LostFocus()
        'lstCustName.Visible = False
    End Sub

    Private Sub lstCustNo_Click()

        'Dim pos As Integer
        'Dim orgCusCde As String
        'Dim orgCusNam As String
        'Dim newCusCde As String
        'Dim newCusNam As String


        'pos = rs_PCMDEVCRG.AbsolutePosition

        'orgCusCde = getValue(rs_PCMDEVCRG.Fields("pdc_cusno"))
        'orgCusNam = getValue(rs_PCMDEVCRG.Fields("pdc_cusnam"))
        'If (InStr(lstCustNo.Text, " - ") > 0) Then
        '    newCusCde = Mid(lstCustNo.Text, 1, InStr(lstCustNo.Text, " - ") - 1)
        '    newCusNam = Mid(lstCustNo.Text, InStr(lstCustNo.Text, " - ") + 3)
        'Else
        '    newCusCde = "STANDARD"
        '    newCusNam = "STANDARD"
        'End If
        'rs_PCMDEVCRG.Fields("pdc_cusno") = newCusCde
        'rs_PCMDEVCRG.Fields("pdc_cusnam") = newCusNam

        'If InvalidDevCrgLevel = True Then
        '    MsgBox("Incorrect Combination of Factory Code and Customer Name")
        '    Call gotorecord(rs_PCMDEVCRG, pos)

        '    rs_PCMDEVCRG.Fields("pdc_cusno") = orgCusCde
        '    rs_PCMDEVCRG.Fields("pdc_cusnam") = orgCusNam

        '    Exit Sub
        'ElseIf HaveDuplicateDevelopCharge = True Then
        '    MsgBox("Duplicate Factory Code and Customer Name")
        '    Call gotorecord(rs_PCMDEVCRG, pos)

        '    rs_PCMDEVCRG.Fields("pdc_cusno") = orgCusCde
        '    rs_PCMDEVCRG.Fields("pdc_cusnam") = orgCusNam

        '    Exit Sub
        'Else

        '    Call gotorecord(rs_PCMDEVCRG, pos)

        '    Call grdDevChrg_AfterColUpdate(4)
        '    Call grdDevChrg_AfterColUpdate(5)
        'End If

        'lstCustNo.Visible = False
        'grdDevChrg.Focus()
    End Sub

    Private Sub lstCustNo_LostFocus()
        'lstCustNo.Visible = False
    End Sub

    Private Sub lstDevChrgFml_Click()
        'If (InStr(lstDevChrgFml.Text, " - ") > 0) Then
        '    rs_PCMDEVCRG.Fields("pdc_decfmlopt") = Mid(lstDevChrgFml.Text, 1, InStr(lstDevChrgFml.Text, " - "))
        '    'rs_PCMDEVCRG.Fields("pdc_decfml") = Mid(lstDevChrgFml.Text, InStr(lstDevChrgFml.Text, " - ") + 3)
        '    rs_PCMDEVCRG.Fields("pdc_decfml") = lstDevChrgFml.Text
        '    Call grdDevChrg_AfterColUpdate(4)
        '    Call grdDevChrg_AfterColUpdate(5)
        'End If

        'lstDevChrgFml.Visible = False
        'grdDevChrg.Focus()
    End Sub

    Private Sub lstDevChrgFml_LostFocus()
        'lstDevChrgFml.Visible = False
    End Sub

    Private Sub lstFtyCde_Click()

        'Dim pos As Integer
        'Dim orgFtyCde As String
        'Dim orgFtyNam As String
        'Dim newFtyCde As String
        'Dim newFtyNam As String


        'pos = rs_PCMDEVCRG.AbsolutePosition
        'orgFtyCde = rs_PCMDEVCRG.Fields("pdc_facde")
        'orgFtyNam = rs_PCMDEVCRG.Fields("pdc_fanam")
        'If InStr(lstFtyCde.Text, " - ") > 0 Then
        '    newFtyCde = Mid(lstFtyCde.Text, 1, InStr(lstFtyCde.Text, " - ") - 1)
        '    newFtyNam = Mid(lstFtyCde.Text, InStr(lstFtyCde.Text, " - ") + 3)
        'Else
        '    newFtyCde = "STANDARD"
        '    newFtyNam = "STANDARD"
        'End If

        'rs_PCMDEVCRG.Fields("pdc_facde") = newFtyCde
        'rs_PCMDEVCRG.Fields("pdc_fanam") = newFtyNam

        'If InvalidDevCrgLevel = True Then
        '    MsgBox("Incorrect Combination of Factory Code and Customer Code")
        '    Call gotorecord(rs_PCMDEVCRG, pos)
        '    rs_PCMDEVCRG.Fields("pdc_facde") = orgFtyCde
        '    rs_PCMDEVCRG.Fields("pdc_fanam") = orgFtyNam

        '    Exit Sub


        'ElseIf HaveDuplicateDevelopCharge = True Then
        '    MsgBox("Duplicate Factory Code and Customer Code")
        '    Call gotorecord(rs_PCMDEVCRG, pos)

        '    rs_PCMDEVCRG.Fields("pdc_facde") = orgFtyCde
        '    rs_PCMDEVCRG.Fields("pdc_fanam") = orgFtyNam

        '    Exit Sub
        'Else

        '    Call gotorecord(rs_PCMDEVCRG, pos)

        '    Call grdDevChrg_AfterColUpdate(2)
        '    Call grdDevChrg_AfterColUpdate(3)
        'End If



        'lstFtyCde.Visible = False
        'grdDevChrg.Focus()
    End Sub

    Private Sub lstFtyCde_LostFocus()
        'lstFtyCde.Visible = False
    End Sub

    Private Sub lstHdChrgFml_Click()
        'If (InStr(lstHdChrgFml.Text, " - ") > 0) Then
        '    rs_PCMAGYCRG.Fields("pac_hdcfmlopt") = Mid(lstHdChrgFml.Text, 1, InStr(lstHdChrgFml.Text, " - "))
        '    'rs_PCMAGYCRG.Fields("pac_hdcfml") = Mid(lstHdChrgFml.Text, InStr(lstHdChrgFml.Text, " - ") + 3)
        '    rs_PCMAGYCRG.Fields("pac_hdcfml") = lstHdChrgFml.Text
        '    Call grdAgyChrg_AfterColUpdate(5)
        '    Call grdAgyChrg_AfterColUpdate(6)
        'End If

        'lstHdChrgFml.Visible = False
        'grdAgyChrg.Focus()
    End Sub

    Private Sub lstHdChrgFml_LostFocus()
        ' lstHdChrgFml.Visible = False
    End Sub

    'Private Sub lstVenCde_Click()
    'If (InStr(lstVenCde.Text, " - ") > 0) Then
    '    Dim pos As Integer
    '    Dim orgVenCde As String
    '    Dim orgVenNam As String
    '    Dim newVenCde As String
    '    Dim newVenNam As String

    '    pos = rs_PCMDV.AbsolutePosition
    '    orgVenCde = rs_PCMDV.Fields("pdv_vencde")
    '    orgVenNam = rs_PCMDV.Fields("pdv_vennam")
    '    newVenCde = Mid(lstVenCde.Text, 1, InStr(lstVenCde.Text, " - ") - 1)
    '    newVenNam = Mid(lstVenCde.Text, InStr(lstVenCde.Text, " - ") + 3)

    '    rs_PCMDV.Fields("pdv_vencde") = newVenCde
    '    rs_PCMDV.Fields("pdv_vennam") = newVenNam

    '    If HaveDuplicateAssociateVendor = True Then
    '        MsgBox("Duplicate Vendor Code")
    '        Call gotorecord(rs_PCMDV, pos)

    '        rs_PCMDV.Fields("pdv_vencde") = orgVenCde
    '        rs_PCMDV.Fields("pdv_vennam") = orgVenNam

    '        Exit Sub
    '        '----------2003/11/27-------------------
    '        'check if company code is assigned to other profit centre
    '    ElseIf HaveDuplicateDV Then
    '        MsgBox("Vendor Code is already assigned to other profit centre")
    '        Call gotorecord(rs_PCMDV, pos)

    '        rs_PCMDV.Fields("pdv_vencde") = orgVenCde
    '        rs_PCMDV.Fields("pdv_vennam") = orgVenNam

    '        Exit Sub
    '        '----------------------------------------
    '    Else
    '        Call gotorecord(rs_PCMDV, pos)

    '        Call grdAssDgnVen_AfterColUpdate(2)
    '        Call grdAssDgnVen_AfterColUpdate(3)
    '    End If

    'End If

    'lstVenCde.Visible = False
    'grdAssDgnVen.Focus()
    ' End Sub




    'Private Sub txtPftCtr_GotFocus()
    '    Call HighlightText(txtPftCtr)
    'End Sub
    '
    '
    'Private Sub txtPftCtr_KeyDown(KeyCode As Integer, Shift As Integer)
    '    If KeyCode = 13 Then
    '        txtPftCtr.Text = UCase(txtPftCtr.Text)
    '        Call CmdFind_Click
    '    End If
    'End Sub



    Private Function HaveDuplicateAgencyCharge() As Boolean
        Dim have As Boolean
        have = False

        'Dim AgyDel As Object
        'Dim AgyCoCde As Object
        'Dim AgyCustNo As Object

        Dim counter As Integer
        Dim counterI As Integer
        Dim counterJ As Integer

        counter = 0
        counterI = 0
        counterJ = 0

        If rs_PCMAGYCRG.Tables(0).Rows.Count > 0 Then
            Dim AgyDel(rs_PCMAGYCRG.Tables(0).Rows.Count) As String
            Dim AgyCoCde(rs_PCMAGYCRG.Tables(0).Rows.Count) As String
            Dim AgyCustNo(rs_PCMAGYCRG.Tables(0).Rows.Count) As String

            'rs_PCMAGYCRG.MoveFirst()
            For counter = 0 To rs_PCMAGYCRG.Tables(0).Rows.Count - 1
                AgyDel(counter) = rs_PCMAGYCRG.Tables(0).Rows(counter).Item("pac_del")
                AgyCoCde(counter) = rs_PCMAGYCRG.Tables(0).Rows(counter).Item("pac_cocde")
                AgyCustNo(counter) = rs_PCMAGYCRG.Tables(0).Rows(counter).Item("pac_cusno")
                'rs_PCMAGYCRG.MoveNext()
            Next counter

            For counterI = 0 To rs_PCMAGYCRG.Tables(0).Rows.Count - 1
                '            If AgyDel(counterI) <> "Y" Then
                For counterJ = counterI + 1 To rs_PCMAGYCRG.Tables(0).Rows.Count - 1
                    '                    If AgyDel(counterJ) <> "Y" Then
                    If (AgyCoCde(counterI) = AgyCoCde(counterJ)) And (AgyCustNo(counterI) = AgyCustNo(counterJ)) Then
                        have = True
                    End If
                    '                    End If
                Next counterJ
                '            End If
            Next counterI
        End If

        HaveDuplicateAgencyCharge = have

    End Function

    Private Function HaveDuplicateDevelopCharge() As Boolean
        Dim have As Boolean
        have = False

        'Dim DevDel As Object
        'Dim DevFtyCde As Object
        'Dim DevCusNo As Object

        Dim counter As Integer
        Dim counterI As Integer
        Dim counterJ As Integer

        counter = 0
        counterI = 0
        counterJ = 0

        If rs_PCMDEVCRG.Tables(0).Rows.Count > 0 Then
            Dim DevDel(rs_PCMDEVCRG.Tables(0).Rows.Count) As String
            Dim DevFtyCde(rs_PCMDEVCRG.Tables(0).Rows.Count) As String
            Dim DevCusNo(rs_PCMDEVCRG.Tables(0).Rows.Count) As String

            '            rs_PCMDEVCRG.MoveFirst()
            For counter = 0 To rs_PCMDEVCRG.Tables(0).Rows.Count - 1
                DevDel(counter) = rs_PCMDEVCRG.Tables(0).Rows(counter).Item("pdc_del")
                DevFtyCde(counter) = rs_PCMDEVCRG.Tables(0).Rows(counter).Item("pdc_facde")
                DevCusNo(counter) = rs_PCMDEVCRG.Tables(0).Rows(counter).Item("pdc_cusno")
                'rs_PCMDEVCRG.MoveNext()
            Next counter

            For counterI = 0 To rs_PCMDEVCRG.Tables(0).Rows.Count - 1
                '            If DevDel(counterI) <> "Y" Then
                For counterJ = counterI + 1 To rs_PCMDEVCRG.Tables(0).Rows.Count - 1
                    '                    If DevDel(counterJ) <> "Y" Then
                    If DevFtyCde(counterI) = DevFtyCde(counterJ) And DevCusNo(counterI) = DevCusNo(counterJ) Then
                        have = True
                    End If
                    '                    End If
                Next counterJ
                '            End If
            Next counterI
        End If

        HaveDuplicateDevelopCharge = have

    End Function


    Private Function HaveDuplicateAssociateVendor() As Boolean
        Dim have As Boolean
        have = False

        'Dim AsdDel As Object
        'Dim AsdVenCde As Object

        Dim counter As Integer
        Dim counterI As Integer
        Dim counterJ As Integer

        counter = 0
        counterI = 0
        counterJ = 0

        If rs_PCMDV.Tables(0).Rows.Count > 0 Then
            Dim AsdDel(rs_PCMDV.Tables(0).Rows.Count) As String
            Dim AsdVenCde(rs_PCMDV.Tables(0).Rows.Count) As String
            '            rs_PCMDV.MoveFirst()
            For counter = 0 To rs_PCMDV.Tables(0).Rows.Count - 1
                AsdDel(counter) = rs_PCMDV.Tables(0).Rows(counter).Item("pdv_del")
                AsdVenCde(counter) = rs_PCMDV.Tables(0).Rows(counter).Item("pdv_vencde")
                'rs_PCMDV.MoveNext()
            Next counter

            For counterI = 0 To rs_PCMDV.Tables(0).Rows.Count - 1
                '            If AsdDel(counterI) <> "Y" Then
                For counterJ = counterI + 1 To rs_PCMDV.Tables(0).Rows.Count - 1
                    '                    If DevDel(counterJ) <> "Y" Then
                    If AsdVenCde(counterI) = AsdVenCde(counterJ) Then
                        have = True
                    End If
                    '                    End If
                Next counterJ
                '            End If
            Next counterI
        End If

        HaveDuplicateAssociateVendor = have

    End Function


    Private Sub gotorecord(ByVal rs As DataSet, ByVal recno As Integer)
        'If recno >= rs.recordCount Then
        '    rs.MoveLast()
        'Else
        '    rs.MoveFirst()
        '    While rs.AbsolutePosition <> recno
        '        rs.MoveNext()
        '    End While
        'End If

    End Sub



    Private Function InputIsValid() As Boolean

        InputIsValid = False

        If rs_PCMDV.Tables(0).Rows.Count > 0 Then
            'rs_PCMDV.MoveFirst()

            For i As Integer = 0 To rs_PCMDV.Tables(0).Rows.Count - 1
                If rs_PCMDV.Tables(0).Rows(i).Item("pdv_del") <> "Y" Then
                    If rs_PCMDV.Tables(0).Rows(i).Item("pdv_vencde") = "" Then
                        SSTabPC.SelectedIndex = 0
                        MsgBox("Associated Design Vendor code is blank")
                        Exit Function
                    End If
                End If
            Next


            'While Not rs_PCMDV.EOF
            '    If rs_PCMDV("pdv_del") <> "Y" Then
            '        If rs_PCMDV("pdv_vencde") = "" Then
            '            SSTabPC.SelectedIndex = 0
            '            grdAssDgnVen.Focus()
            '            grdAssDgnVen.col = 2
            '            MsgBox("Associated Design Vendor code is blank")
            '            Exit Function
            '        End If

            '    End If
            '    'rs_PCMDV.MoveNext()
            'End While
        End If

        If rs_PCMAGYCRG.Tables(0).Rows.Count > 0 Then

            For i As Integer = 0 To rs_PCMAGYCRG.Tables(0).Rows.Count - 1
                If rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_del") <> "Y" Then
                    If rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_cocde") = "" Then
                        SSTabPC.SelectedIndex = 1
                        MsgBox("Company Code is blank")
                        Exit Function
                    ElseIf rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_cusno") = "" Then
                        SSTabPC.SelectedIndex = 1
                        MsgBox("Customer Code is blank")
                        Exit Function
                    ElseIf rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_hdcfmlopt") = "" Then
                        SSTabPC.SelectedIndex = 1
                        MsgBox("Handling Charge Formula is blank")
                        Exit Function
                    End If
                End If
            Next

            'rs_PCMAGYCRG.MoveFirst()
            'While Not rs_PCMAGYCRG.EOF
            '    If rs_PCMAGYCRG("pac_del") <> "Y" Then
            '        If rs_PCMAGYCRG("pac_cocde") = "" Then
            '            SSTabPC.SelectedIndex = 1
            '            grdAgyChrg.Focus()
            '            grdAgyChrg.col = 2
            '            MsgBox("Company Code is blank")
            '            Exit Function
            '        ElseIf rs_PCMAGYCRG("pac_cusno") = "" Then
            '            SSTabPC.SelectedIndex = 1
            '            grdAgyChrg.Focus()
            '            grdAgyChrg.col = 3
            '            MsgBox("Customer Code is blank")
            '            Exit Function
            '        ElseIf rs_PCMAGYCRG("pac_hdcfmlopt") = "" Then
            '            SSTabPC.SelectedIndex = 1
            '            grdAgyChrg.Focus()
            '            grdAgyChrg.col = 6
            '            MsgBox("Handling Charge Formula is blank")
            '            Exit Function
            '        End If
            '    End If
            '    rs_PCMAGYCRG.MoveNext()
            'End While
        End If

        If rs_PCMDEVCRG.Tables(0).Rows.Count > 0 Then
            'rs_PCMDEVCRG.MoveFirst()

            For i As Integer = 0 To rs_PCMDEVCRG.Tables(0).Rows.Count - 1
                If rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_del") <> "Y" Then
                    If rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_facde") = "" Then
                        SSTabPC.SelectedIndex = 2
                        'grdDevChrg.Focus()
                        'grdDevChrg.col = 2
                        MsgBox("Factory Code is blank")
                        Exit Function
                    ElseIf rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_cusno") = "" Then
                        SSTabPC.SelectedIndex = 2
                        'grdDevChrg.Focus()
                        'grdDevChrg.col = 4
                        MsgBox("Customer Code is blank")
                        Exit Function

                    ElseIf rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_decfmlopt") = "" Then
                        SSTabPC.SelectedIndex = 2
                        'grdDevChrg.Focus()
                        'grdDevChrg.col = 7
                        MsgBox("Development Charge Formula is blank")
                        Exit Function
                    End If
                End If
            Next



            'While Not rs_PCMDEVCRG.EOF
            '    If rs_PCMDEVCRG("pdc_del") <> "Y" Then
            '        If rs_PCMDEVCRG("pdc_facde") = "" Then
            '            SSTabPC.SelectedIndex = 2
            '            grdDevChrg.Focus()
            '            grdDevChrg.col = 2
            '            MsgBox("Factory Code is blank")
            '            Exit Function
            '        ElseIf rs_PCMDEVCRG("pdc_cusno") = "" Then
            '            SSTabPC.SelectedIndex = 2
            '            grdDevChrg.Focus()
            '            grdDevChrg.col = 4
            '            MsgBox("Customer Code is blank")
            '            Exit Function

            '        ElseIf rs_PCMDEVCRG("pdc_decfmlopt") = "" Then
            '            SSTabPC.SelectedIndex = 2
            '            grdDevChrg.Focus()
            '            grdDevChrg.col = 7
            '            MsgBox("Development Charge Formula is blank")
            '            Exit Function
            '        End If
            '    End If
            '    rs_PCMDEVCRG.MoveNext()
            'End While
        End If

        InputIsValid = True

    End Function

    Public Function func_SaveRecordset()
        Dim S As String
        Dim rs As DataSet
        Dim strCustName As String
        Dim txtPCNO As String
        If ActionMode = "Add" Then
            'txtPftCtr.Text = func_getNewPCNO
            txtPCNO = func_getNewPCNO()
            Me.cboPCNo.Text = txtPCNO
        End If

        '=================
        '=== Save PCADVEN
        '=================
        If rs_PCMDV.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To rs_PCMDV.Tables(0).Rows.Count - 1
                If rs_PCMDV.Tables(0).Rows(i).Item("pdv_creusr") = "~*ADD*~" And rs_PCMDV.Tables(0).Rows(i).Item("pdv_del") <> "Y" And ActionMode <> "Del" Then
                    If ActionMode = "Add" Then
                        rs_PCMDV.Tables(0).Rows(i).Item("pdv_pcno") = Me.cboPCNo.Text
                    End If
                    gspStr = "sp_insert_PCMDV '', '" & _
                        rs_PCMDV.Tables(0).Rows(i).Item("pdv_pcno") & "','" & _
                        rs_PCMDV.Tables(0).Rows(i).Item("pdv_vencde") & "','" & _
                        gsUsrID & "'"

                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_insert_PCMDV:" & rtnStr)
                        Exit Function
                    End If

                ElseIf rs_PCMDV.Tables(0).Rows(i).Item("pdv_creusr") = "~*DEL*~" Or ActionMode = "Del" Then
                    gspStr = "sp_physical_delete_PCMDV '', '" & _
                        rs_PCMDV.Tables(0).Rows(i).Item("pdv_pcno") & "','" & _
                        rs_PCMDV.Tables(0).Rows(i).Item("pdv_vencde") & "'"

                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_physical_delete_PCMDV:" & rtnStr)
                        Exit Function
                    End If
                End If
               
            Next
        End If




        'If rs_PCMDV.recordCount > 0 Then
        '    rs_PCMDV.MoveFirst()
        '    While Not rs_PCMDV.EOF
        '        S = ""

        '        If rs_PCMDV("pdv_creusr") = "~*ADD*~" And rs_PCMDV("pdv_del") <> "Y" And ActionMode <> "Del" Then
        '            If ActionMode = "Add" Then
        '                rs_PCMDV("pdv_pcno") = Me.cboPCNo.Text
        '            End If
        '            S = "㊣PCMDV※A※" & rs_PCMDV("pdv_pcno") & "※" & rs_PCMDV("pdv_vencde") & "※" & gsUsrID
        '        ElseIf rs_PCMDV("pdv_creusr") = "~*DEL*~" Or ActionMode = "Del" Then
        '            S = "㊣PCMDV※P※" & rs_PCMDV("pdv_pcno") & "※" & rs_PCMDV("pdv_vencde")
        '        End If

        '        If S > "" Then  '*** if there is something to do with s ...
        '            rs = objBSGate.Modify(gsConnStr, "sp_general", S)
        '            If rs(0) <> "0" Then  '*** An error has occured
        '                MsgBox(rs(0))
        '                Exit Function
        '            Else
        '                IsUpdated = True
        '            End If
        '        End If

        '        rs_PCMDV.MoveNext()
        '    End While
        'End If
        ' ''-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        ''=================
        ''=== Save PCAGCRG
        ''=================

        If rs_PCMAGYCRG.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To rs_PCMAGYCRG.Tables(0).Rows.Count - 1
                strCustName = rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_cusno")

                If rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_creusr") = "~*ADD*~" And rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_del") <> "Y" And ActionMode <> "Del" Then
                    If ActionMode = "Add" Then
                        rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_pcno") = Me.cboPCNo.Text
                    End If
                    gspStr = "sp_insert_PCMAGYCRG '', '" & rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_pcno") & "','" & _
                        rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_cocde") & "','" & _
                        Split(rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_hdcfmlopt"), " - ")(0) & "','" & _
                        strCustName & "','" & _
                        gsUsrID & "'"

                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_insert_PCMAGYCRG:" & rtnStr)
                        Exit Function
                    End If


                ElseIf rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_creusr") = "~*UPD*~" And ActionMode <> "Del" Then
                    gspStr = "sp_update_PCMAGYCRG '', '" & rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_pcno") & "','" & _
                        rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_cocde") & "','" & _
                        Split(rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_hdcfmlopt"), " - ")(0) & "','" & _
                        strCustName & "','" & _
                        gsUsrID & "'"

                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_update_PCMAGYCRG:" & rtnStr)
                        Exit Function
                    End If

 
                ElseIf rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_creusr") = "~*DEL*~" Or ActionMode = "Del" Then
                    gspStr = "sp_physical_delete_PCMAGYCRG '', '" & rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_pcno") & "','" & _
                        rs_PCMAGYCRG.Tables(0).Rows(i).Item("pac_cocde") & "','" & _
                        strCustName & "'"

                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_physical_delete_PCMAGYCRG:" & rtnStr)
                        Exit Function
                    End If
                End If

            Next

        End If


        'If rs_PCMAGYCRG.recordCount > 0 Then
        '    rs_PCMAGYCRG.MoveFirst()
        '    While Not rs_PCMAGYCRG.EOF
        '        'strCustName = CStr(rs_PCMAGYCRG("pac_cusnam"))
        '        '            strCustName = "STD"
        '        '            If (InStr(rs_PCMAGYCRG("pac_cusno"), " - ") > 0) Then
        '        '                strCustName = Mid(rs_PCMAGYCRG("pac_cusnam"), 1, InStr(rs_PCMAGYCRG("pac_cusnam"), " - ") - 1)
        '        '            End If
        '        strCustName = rs_PCMAGYCRG("pac_cusno")
        '        S = ""

        '        If rs_PCMAGYCRG("pac_creusr") = "~*ADD*~" And rs_PCMAGYCRG("pac_del") <> "Y" And ActionMode <> "Del" Then
        '            If ActionMode = "Add" Then
        '                rs_PCMAGYCRG("pac_pcno") = Me.cboPCNo.Text
        '            End If
        '            S = "㊣PCMAGYCRG※A※" & rs_PCMAGYCRG("pac_pcno") & "※" & rs_PCMAGYCRG("pac_cocde") & "※" & _
        '                rs_PCMAGYCRG("pac_hdcfmlopt") & "※" & strCustName & "※" & gsUsrID
        '        ElseIf rs_PCMAGYCRG("pac_creusr") = "~*UPD*~" And ActionMode <> "Del" Then
        '            S = "㊣PCMAGYCRG※U※" & rs_PCMAGYCRG("pac_pcno") & "※" & rs_PCMAGYCRG("pac_cocde") & "※" & _
        '                rs_PCMAGYCRG("pac_hdcfmlopt") & "※" & strCustName & "※" & gsUsrID
        '        ElseIf rs_PCMAGYCRG("pac_creusr") = "~*DEL*~" Or ActionMode = "Del" Then
        '            S = "㊣PCMAGYCRG※P※" & rs_PCMAGYCRG("pac_pcno") & "※" & rs_PCMAGYCRG("pac_cocde") & "※" & strCustName
        '        End If

        '        If S > "" Then  '*** if there is something to do with s ...
        '            rs = objBSGate.Modify(gsConnStr, "sp_general", S)
        '            If rs(0) <> "0" Then  '*** An error has occured
        '                MsgBox(rs(0))
        '                Exit Function
        '            Else
        '                IsUpdated = True
        '            End If
        '        End If

        '        rs_PCMAGYCRG.MoveNext()
        '    End While
        'End If
        ''-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        ''=================
        ''=== Save PCDVCRG
        ''=================

        If rs_PCMDEVCRG.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To rs_PCMDEVCRG.Tables(0).Rows.Count - 1
                If rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_creusr") = "~*ADD*~" And rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_del") <> "Y" And ActionMode <> "Del" Then
                    If ActionMode = "Add" Then
                        rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_pcno") = Me.cboPCNo.Text
                    End If
                    gspStr = "sp_insert_PCMDEVCRG '', '" & rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_pcno") & "','" & _
                        rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_facde") & "','" & _
                         Split(rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_decfmlopt"), " - ")(0) & "','" & _
                         rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_cusno") & "','" & _
                         gsUsrID & "'"

                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_insert_PCMDEVCRG:" & rtnStr)
                        Exit Function
                    End If


                ElseIf rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_creusr") = "~*UPD*~" And ActionMode <> "Del" Then
                    gspStr = "sp_update_PCMDEVCRG '', '" & rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_pcno") & "','" & _
                        rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_facde") & "','" & _
                         Split(rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_decfmlopt"), " - ")(0) & "','" & _
                         rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_cusno") & "','" & _
                         gsUsrID & "'"


                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_update_PCMDEVCRG:" & rtnStr)
                        Exit Function
                    End If

                ElseIf rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_creusr") = "~*DEL*~" Or ActionMode = "Del" Then
                    gspStr = "sp_physical_delete_PCMDEVCRG '', '" & rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_pcno") & "','" & _
                        rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_facde") & "','" & _
                         rs_PCMDEVCRG.Tables(0).Rows(i).Item("pdc_cusno") & "'"

                    Cursor = Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_physical_delete_PCMDEVCRG:" & rtnStr)
                        Exit Function
                    End If
                End If
            Next

        End If

        'If rs_PCMDEVCRG.recordCount > 0 Then
        '    rs_PCMDEVCRG.MoveFirst()
        '    While Not rs_PCMDEVCRG.EOF

        '        S = ""

        '        If rs_PCMDEVCRG("pdc_creusr") = "~*ADD*~" And rs_PCMDEVCRG("pdc_del") <> "Y" And ActionMode <> "Del" Then
        '            If ActionMode = "Add" Then
        '                rs_PCMDEVCRG("pdc_pcno") = Me.cboPCNo.Text
        '            End If
        '            S = "㊣PCMDEVCRG※A※" & rs_PCMDEVCRG("pdc_pcno") & "※" & rs_PCMDEVCRG("pdc_facde") & "※" & _
        '                rs_PCMDEVCRG("pdc_decfmlopt") & "※" & rs_PCMDEVCRG("pdc_cusno") & "※" & gsUsrID
        '        ElseIf rs_PCMDEVCRG("pdc_creusr") = "~*UPD*~" And ActionMode <> "Del" Then
        '            S = "㊣PCMDEVCRG※U※" & rs_PCMDEVCRG("pdc_pcno") & "※" & rs_PCMDEVCRG("pdc_facde") & "※" & _
        '                rs_PCMDEVCRG("pdc_decfmlopt") & "※" & rs_PCMDEVCRG("pdc_cusno") & "※" & gsUsrID
        '        ElseIf rs_PCMDEVCRG("pdc_creusr") = "~*DEL*~" Or ActionMode = "Del" Then
        '            S = "㊣PCMDEVCRG※P※" & rs_PCMDEVCRG("pdc_pcno") & "※" & rs_PCMDEVCRG("pdc_facde") & "※" & rs_PCMDEVCRG("pdc_cusno")
        '        End If

        '        If S > "" Then  '*** if there is something to do with s ...
        '            rs = objBSGate.Modify(gsConnStr, "sp_general", S)
        '            If rs(0) <> "0" Then  '*** An error has occured
        '                MsgBox(rs(0))
        '                Exit Function
        '            Else
        '                IsUpdated = True
        '            End If
        '        End If

        '        rs_PCMDEVCRG.MoveNext()
        '    End While
        'End If
        ''-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        txtPCNO = Me.cboPCNo.Text

        S = ""

        If ActionMode = "Add" Then
            gspStr = "sp_insert_PCMAC '', '" & txtPCNO & "','" & _
                txtInvActNo.Text & "','" & _
                txtSamInvActNo.Text & "','" & _
                txtInvAdjActNo.Text & "','" & _
                txtSamTerActNo.Text & "','" & _
                gsUsrID & "'"
            'S = "㊣PCMAC※A※" & txtPCNO & "※" & txtInvActNo.Text & "※" & txtSamInvActNo.Text & "※" & _
            '        txtInvAdjActNo.Text & "※" & txtSamTerActNo.Text & "※" & gsUsrID
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_insert_PCMAC:" & rtnStr)
                Exit Function
            End If
        ElseIf ActionMode <> "Del" Then
            gspStr = "sp_update_PCMAC '', '" & txtPCNO & "','" & _
                txtInvActNo.Text & "','" & _
                txtSamInvActNo.Text & "','" & _
                txtInvAdjActNo.Text & "','" & _
                txtSamTerActNo.Text & "','" & _
                gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_update_PCMAC:" & rtnStr)
                Exit Function
            End If

        ElseIf ActionMode = "Del" Then
            gspStr = "sp_physical_delete_PCMAC '', '" & txtPCNO & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_physical_delete_PCMAC:" & rtnStr)
                Exit Function
            End If
            'S = "㊣PCMAC※P※" & txtPCNO
        End If


        Cursor = Cursors.Default

    End Function



    Private Sub printRecordSetInfo()

        'Debug.Print(" ")
        'Debug.Print("***********************************************")
        'Debug.Print("rs_PCMDV   : " & rs_PCMDV.recordCount)
        'If rs_PCMDV.recordCount > 0 Then
        '    rs_PCMDV.MoveFirst()
        '    While Not rs_PCMDV.EOF
        '        Debug.Print(rs_PCMDV("pdv_del") + " : " + rs_PCMDV("pdv_pcno") + " : " + rs_PCMDV("pdv_vencde") + " : " + rs_PCMDV("pdv_vennam") + " : " + rs_PCMDV("pdv_creusr") + " : " + rs_PCMDV("pdv_status"))
        '        rs_PCMDV.MoveNext()
        '    End While
        'End If

        'Debug.Print(" ")
        'Debug.Print("rs_PCMAGYCRG   : " & rs_PCMAGYCRG.recordCount)
        'If rs_PCMAGYCRG.recordCount > 0 Then
        '    rs_PCMAGYCRG.MoveFirst()
        '    While Not rs_PCMAGYCRG.EOF
        '        Debug.Print(rs_PCMAGYCRG("pac_del") + " : " + rs_PCMAGYCRG("pac_pcno") + " : " + rs_PCMAGYCRG("pac_cocde") + " : " + rs_PCMAGYCRG("pac_conam") + " : " + rs_PCMAGYCRG("pac_hdcfmlopt") + " : " + rs_PCMAGYCRG("pac_hdcfml") + " : " + rs_PCMAGYCRG("pac_creusr") + " : " + rs_PCMAGYCRG("pac_status"))
        '        rs_PCMAGYCRG.MoveNext()
        '    End While
        'End If

        'Debug.Print(" ")
        'Debug.Print("rs_PCMDEVCRG   : " & rs_PCMDEVCRG.recordCount)
        'If rs_PCMDEVCRG.recordCount > 0 Then
        '    rs_PCMDEVCRG.MoveFirst()
        '    While Not rs_PCMDEVCRG.EOF
        '        Debug.Print(rs_PCMDEVCRG("pdc_del") + " : " + rs_PCMDEVCRG("pdc_pcno") + " : " + rs_PCMDEVCRG("pdc_facde") + " : " + rs_PCMDEVCRG("pdc_fanam") + " : " + rs_PCMDEVCRG("pdc_decfmlopt") + " : " + rs_PCMDEVCRG("pdc_decfml") + " : " + rs_PCMDEVCRG("pdc_creusr") + " : " + rs_PCMDEVCRG("pdc_status"))
        '        rs_PCMDEVCRG.MoveNext()
        '    End While
        'End If

    End Sub











    Private Sub PCM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Dim v

        'func_ReadEmptyRecordset()

        Cursor = Cursors.WaitCursor

        Call ResetDefaultDisp()
        Call ResetDefaultStatus()

        Call FillInComboBox()

        Call FillInListBox()

        '***Get the Current User's access right form the DB
        '    If (DB Value = CanModify) Then  'Get the Value from Database
        CanModify = True
        '    Else
        '        CanModify = False
        '    End If

        Me.KeyPreview = True

        Call setStatus("Init")

        Call Formstartup(Me.Name)   'Set the form Sartup position

        Call setgrdPstDat()

        RadioButton2.Checked = True
        RadioButton1.Checked = True



        Cursor = Cursors.Default
    End Sub

    Private Sub setgrdPstDat()
        gspStr = "sp_select_ACEDIBAT"

        rtnLong = execute_SQLStatement(gspStr, rs_ACEDIBAT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_ACEDIBAT:" & rtnStr)
            Exit Sub
        End If

        grdPstDat.DataSource = rs_ACEDIBAT.Tables(0).DefaultView

        grdPstDat.Columns(0).HeaderText = "Company"
        grdPstDat.Columns(1).HeaderText = "Posting Date"


    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        PCM_Find()
    End Sub

    Private Function PCM_Find() As Boolean
        PCM_Find = False

        ActionMode = "Chg"
        Cursor = Cursors.WaitCursor

        If (Trim(Me.cboPCNo.Text) = "") Then
            MsgBox("M00012")
            Me.cboPCNo.Focus()
            Exit Function
        End If

        Call func_ReadRecordset()

        If rs_PCMDV.Tables(0).Rows.Count > 0 Or rs_PCMAGYCRG.Tables(0).Rows.Count > 0 Or rs_PCMDEVCRG.Tables(0).Rows.Count > 0 Or rs_PCMAC.Tables(0).Rows.Count > 0 Then
            Call Display()
            Call setStatus("Updating")
        Else
            MsgBox("Profit Center Number not found!")
            'txtPftCtr.SetFocus
            Me.cboPCNo.Focus()
            Call ResetDefaultDisp()
            Cursor = Cursors.Default
            Exit Function
        End If



        PCM_Find = True
    End Function


    Private Sub cboPCNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPCNo.KeyPress
        If e.KeyChar = Chr(13) And cmdFind.Enabled = True Then
            PCM_Find()
        End If
    End Sub


    Private Sub cboPCNo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        Call auto_search_combo(cboPCNo, KeyCode)
    End Sub

    'Private Sub grdAssDgnVen_ButtonClick(ByVal ColIndex As Integer)
    'If ColIndex = 0 Then
    '    If rs_PCMDV.Fields("pdv_del") = "" Then
    '        rs_PCMDV.Fields("pdv_del") = "Y"
    '        If rs_PCMDV.Fields("pdv_creusr") <> "~*ADD*~" And rs_PCMDV.Fields("pdv_creusr") <> "~*DEL*~" And _
    '            rs_PCMDV.Fields("pdv_creusr") <> "~*NEW*~" Then
    '            rs_PCMDV.Fields("pdv_creusr") = "~*DEL*~"
    '        End If
    '    Else
    '        rs_PCMDV.Fields("pdv_del") = ""
    '        If rs_PCMDV.Fields("pdv_creusr") = "~*DEL*~" Then
    '            rs_PCMDV.Fields("pdv_creusr") = "~*UPD*~"
    '        End If
    '    End If
    'ElseIf ColIndex = 2 Or ColIndex = 3 Then
    '    If rs_PCMDV.Fields("pdv_creusr") <> "~*ADD*~" And _
    '        rs_PCMDV.Fields("pdv_creusr") <> "~*DEL*~" And _
    '        rs_PCMDV.Fields("pdv_creusr") <> "~*NEW*~" And _
    '        rs_PCMDV.Fields("pdv_creusr") <> "~*UPD*~" Then

    '        MsgBox("Cannot change Profit Center Associated Design Vendor")
    '        Exit Sub
    '    Else
    '        If lstVenCde.Visible = False Then
    '            lstVenCde.Visible = True
    '            lstVenCde.Focus()
    '        lstVenCde.Move (grdAssDgnVen.Columns(2).Left + grdAssDgnVen.Left), (grdAssDgnVen.RowTop(grdAssDgnVen.row) + grdAssDgnVen.Columns(2).Top + grdAssDgnVen.Top)
    '        Else
    '            lstVenCde.Visible = False
    '        End If
    '    End If
    'End If

    'End Sub


#Region "Tab 1 Related"
    Private Sub grdAssDgnVen_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAssDgnVen.CellClick
        Dim row As DataGridViewRow = grdAssDgnVen.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                'toggle Del
                If rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_del") = "" Then
                    rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_del") = "Y"
                    If rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") <> "~*ADD*~" And rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") <> "~*DEL*~" And _
                        rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") <> "~*NEW*~" Then
                        rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") = "~*DEL*~"
                    End If
                Else
                    rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_del") = ""
                    If rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") = "~*DEL*~" Then
                        rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") = "~*UPD*~"
                    End If
                End If

            ElseIf e.ColumnIndex = 2 Then
                If rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") <> "~*ADD*~" And _
                     rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") <> "~*DEL*~" And _
                     rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") <> "~*NEW*~" And _
                     rs_PCMDV.Tables(0).Rows(e.RowIndex).Item("pdv_creusr") <> "~*UPD*~" Then

                    MsgBox("Cannot change Profit Center Associated Design Vendor")
                    Exit Sub
                Else
                    If TypeOf (grdAssDgnVen.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell_grdAssDgnVen(grdAssDgnVen.CurrentCell)
                        grdAssDgnVen.BeginEdit(True)

                    End If
                End If

            End If



        End If
    End Sub

    Private Sub createComboBoxCell_grdAssDgnVen(ByVal cell As DataGridViewCell)
        Dim cbocell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        If iCol = 2 Then
            'Dim dr() As DataRow = rs_VNBASINF.Tables(0).Select("vbi_venno >= 'A'")


            'For i As Integer = 0 To dr.Length - 1
            '    cbocell.Items.Add(Trim(dr(i).Item("vbi_venno")) + " - " + Trim(dr(i).Item("vbi_vensna")))
            'Next
            cbocell.DataSource = Vendor_ShortList

        End If

        cbocell.DropDownWidth = 150
        cbocell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cbocell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False

        'If iCol = 1 Then
        '    For Each dr As DataRow In rs_syusrfun.Tables("RESULT").Rows
        '        cbocell.Items.Add(dr.Item("yuf_usrfun").ToString.Trim)
        '    Next
        'ElseIf iCol = 3 Then
        '    cbocell.Items.Add("MWD - Maintenace with Delete")
        '    cbocell.Items.Add("MOD - Maintenance without Delete")
        '    cbocell.Items.Add("ENQ - Enquiry Only")
        'End If
        'cbocell.DropDownWidth = 150
        'cbocell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        'dgView.Rows(iRow).Cells(iCol) = cbocell
        'dgView.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub

    Private Sub grdAssDgnVen_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdAssDgnVen.EditingControlShowing
        If grdAssDgnVen.CurrentCell.ColumnIndex = 2 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then

                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAssDgnVen_SelectedIndexChanged
                    RemoveHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAssDgnVen_SelectionChangeCommitted
                    RemoveHandler cboBox.Click, AddressOf cbogrdAssDgnVen_click
                    Dim tmp_index = cboBox.SelectedIndex
                    cboBox.DataSource = Vendor_LongList
                    cboBox.SelectedIndex = tmp_index
                    cboBox.Width = 400
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAssDgnVen_SelectedIndexChanged
                    AddHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAssDgnVen_SelectionChangeCommitted
                    AddHandler cboBox.Click, AddressOf cbogrdAssDgnVen_click

                End If
            End If
        End If
    End Sub

    Private Sub cbogrdAssDgnVen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = grdAssDgnVen.CurrentCell.RowIndex
        Dim iCol As Integer = grdAssDgnVen.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.grdAssDgnVen.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAssDgnVen_SelectedIndexChanged
                ' User has changed the function
                If iCol = 2 Then
                    Me.grdAssDgnVen.Rows(iRow).Cells(iCol).Value = strSelItem
                    'Me.grdAssDgnVen.Rows(iRow).Cells(iCol + 1).Value = fun_long_list(cboBox.SelectedIndex)
                    Me.grdAssDgnVen.Rows(iRow).Cells(iCol + 1).Value = Split(Vendor_LongList(cboBox.SelectedIndex), " - ")(1)
                    'Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_syusrfun.Tables("RESULT").Select("yuf_usrfun = '" & strSelItem & "'")(0).Item("yuf_fundsc").ToString
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAssDgnVen_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub cbogrdAssDgnVen_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbobox As ComboBox = CType(sender, ComboBox)
        If grdAssDgnVen.CurrentCell.ColumnIndex = 2 Then
            If Not cbobox Is Nothing AndAlso Not cbobox.SelectedItem Is Nothing Then
                Dim tmp_index = cbobox.SelectedIndex
                cbobox.DataSource = Vendor_ShortList
                cbobox.SelectedIndex = tmp_index

            End If
        End If
    End Sub

    Private Sub cbogrdAssDgnVen_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbobox As ComboBox = CType(sender, ComboBox)
        If grdAssDgnVen.CurrentCell.ColumnIndex = 2 Then
            If Not cbobox Is Nothing AndAlso Not cbobox.SelectedItem Is Nothing Then
                Dim tmp_index = cbobox.SelectedIndex
                cbobox.DataSource = Vendor_ShortList
                cbobox.SelectedIndex = tmp_index
                cbobox.Width = 400
            End If
        End If
    End Sub

    Private Sub grdAssDgnVen_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdAssDgnVen.DataError

    End Sub


    Private Sub grdAssDgnVen_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdAssDgnVen.CellValidating
        Dim row As DataGridViewRow = grdAssDgnVen.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 2 Then

                If HaveDuplicateAssociateVendor() = True Then
                    MsgBox("Duplicate Vendor Code")
                    'Call gotorecord(rs_PCMDV, pos)
                    e.Cancel = True
                    'rs_PCMDV.Fields("pdv_vencde") = orgVenCde
                    ' rs_PCMDV.Fields("pdv_vennam") = orgVenNam

                    Exit Sub
                    '----------2003/11/27-------------------
                    'check if company code is assigned to other profit centre
                ElseIf HaveDuplicateDV() Then
                    MsgBox("Vendor Code is already assigned to other profit centre")
                    'Call gotorecord(rs_PCMDV, pos)

                    'rs_PCMDV.Fields("pdv_vencde") = orgVenCde
                    'rs_PCMDV.Fields("pdv_vennam") = orgVenNam
                    e.Cancel = True

                    Exit Sub
                End If



            End If


        End If

    End Sub

#End Region

#Region "Tab 2 Related"
    Private Sub grdAgyChrg_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAgyChrg.CellClick
        If Not e.RowIndex = -1 Then
            If e.ColumnIndex = 0 Then
                If rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_del") = "" Then
                    If isAgyEssential(e.RowIndex) Then
                        Exit Sub
                    End If
                    rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_del") = "Y"
                    If rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*ADD*~" And _
                        rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*DEL*~" And _
                        rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*NEW*~" Then
                        rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") = "~*DEL*~"
                    End If
                Else
                    rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_del") = ""
                    If rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") = "~*DEL*~" Then
                        rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") = "~*UPD*~"
                    End If
                End If
            ElseIf e.ColumnIndex = 2 Then
                If rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*ADD*~" And _
                    rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*DEL*~" And _
                    rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*NEW*~" Then
                    '            And _
                    '            rs_PCMAGYCRG.Fields("pac_creusr") <> "~*UPD*~" Then

                    MsgBox("Cannot change Profit Center Company")
                    Exit Sub
                Else

                    'ToDo: Change to Comboboxgrid
                    If TypeOf (grdAgyChrg.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell_grdAgyChrg(grdAgyChrg.CurrentCell)
                        grdAssDgnVen.BeginEdit(True)

                    End If
                    'If lstCoCde.Visible = False Then
                    '    lstCoCde.Visible = True
                    '    lstCoCde.Focus()
                    'lstCoCde.Move (grdAgyChrg.Columns(2).Left + grdAgyChrg.Left), (grdAgyChrg.RowTop(grdAgyChrg.row) + grdAgyChrg.Columns(2).Top + grdAgyChrg.Top)
                    'Else
                    '    lstCoCde.Visible = False
                    'End If

                    'If lstHdChrgFml.Visible = True Then
                    '    lstHdChrgFml.Visible = False
                    'End If
                    'If Me.lstCustName.Visible = True Then
                    '    Me.lstCustName.Visible = False
                    'End If

                End If
            ElseIf e.ColumnIndex = 3 Then ' customer name
                If rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*ADD*~" And _
                    rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*DEL*~" And _
                    rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*NEW*~" Then
                    '            And _
                    '            rs_PCMAGYCRG.Fields("pac_creusr") <> "~*UPD*~" Then

                    MsgBox("Cannot change Profit Center Customer")
                    Exit Sub
                Else
                    'Todo: Change to comboxboxgrid
                    If TypeOf (grdAgyChrg.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell_grdAgyChrg(grdAgyChrg.CurrentCell)
                        grdAssDgnVen.BeginEdit(True)

                    End If



                    'If lstCustName.Visible = False Then
                    '    lstCustName.Visible = True
                    '    lstCustName.Focus()
                    'lstCustName.Move (grdAgyChrg.Columns(ColIndex).Left + grdAgyChrg.Left), (grdAgyChrg.RowTop(grdAgyChrg.row) + grdAgyChrg.Columns(ColIndex).Top + grdAgyChrg.Top)
                    'Else
                    '    lstCustName.Visible = False
                    'End If

                    'If Me.lstCoCde.Visible = True Then
                    '    Me.lstCoCde.Visible = False
                    'End If

                    'If lstHdChrgFml.Visible = True Then
                    '    lstHdChrgFml.Visible = False
                    'End If

                End If
            ElseIf e.ColumnIndex = 5 Then

                If TypeOf (grdAgyChrg.CurrentCell) Is DataGridViewTextBoxCell Then


                    If rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*ADD*~" And rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") <> "~*DEL*~" Then
                        rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_creusr") = "~*UPD*~"
                    End If

                    createComboBoxCell_grdAgyChrg(grdAgyChrg.CurrentCell)
                    grdAssDgnVen.BeginEdit(True)

                End If



                'If lstHdChrgFml.Visible = False Then
                '    lstHdChrgFml.Visible = True
                '    lstHdChrgFml.Focus()
                'lstHdChrgFml.Move (grdAgyChrg.Columns(ColIndex).Left + grdAgyChrg.Left), (grdAgyChrg.RowTop(grdAgyChrg.row) + grdAgyChrg.Columns(ColIndex).Top + grdAgyChrg.Top)
                'Else
                '    lstHdChrgFml.Visible = False
                'End If

                'If lstCoCde.Visible = True Then
                '    lstCoCde.Visible = False
                'End If

                'If Me.lstCustName.Visible = True Then
                '    Me.lstCustName.Visible = False
                'End If


            End If
        End If
    End Sub

    Private Sub createComboBoxCell_grdAgyChrg(ByVal cell As DataGridViewCell)
        Dim cbocell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        If iCol = 2 Then


            'For i As Integer = 0 To dr.Length - 1
            '    cbocell.Items.Add(Trim(dr(i).Item("vbi_venno")) + " - " + Trim(dr(i).Item("vbi_vensna")))
            'Next
            cbocell.DataSource = CompanyList
        ElseIf iCol = 3 Then
            cbocell.DataSource = Cust_ShortList
        ElseIf iCol = 5 Then
            cbocell.DataSource = ChargeList
        End If

        cbocell.DropDownWidth = 150
        cbocell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cbocell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub



    Private Sub grdAgyChrg_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdAgyChrg.CellValidating
        Dim row As DataGridViewRow = grdAssDgnVen.CurrentRow
        Dim strNewVal As String

        If row Is Nothing Then
            Exit Sub
        End If

        If e.ColumnIndex <> 6 Then
            strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim
        End If


        If e.ColumnIndex = 2 Then

            If InvalidArgCrgLevel(e.RowIndex) = True Then
                MsgBox("Incorrect Combination of Company Code and Customer Name")
                e.Cancel = True
                Exit Sub
            ElseIf HaveDuplicateAgencyCharge() = True Then
                MsgBox("Duplicate Company Code and Customer Name")
                e.Cancel = True

                Exit Sub
            End If

        ElseIf e.ColumnIndex = 3 Then
            If InvalidArgCrgLevel(e.RowIndex) = True Then
                MsgBox("Incorrect Combination of Company Code and Customer Name")

                e.Cancel = True
                Exit Sub
            ElseIf HaveDuplicateAgencyCharge() = True Then
                MsgBox("Duplicate Company Code and Customer Name")
                e.Cancel = True
                Exit Sub

            End If

        ElseIf e.ColumnIndex = 5 Then

            'If (InStr(lstHdChrgFml.Text, " - ") > 0) Then
            'rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_hdcfmlopt") = Mid(lstHdChrgFml.Text, 1, InStr(lstHdChrgFml.Text, " - "))
            'rs_PCMAGYCRG.Fields("pac_hdcfml") = Mid(lstHdChrgFml.Text, InStr(lstHdChrgFml.Text, " - ") + 3)
            'rs_PCMAGYCRG.Fields("pac_hdcfml") = lstHdChrgFml.Text
            'Call grdAgyChrg_AfterColUpdate(5)
            'Call grdAgyChrg_AfterColUpdate(6)
            'End If

        End If


    End Sub

    Private Sub grdAgyChrg_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdAgyChrg.EditingControlShowing
        If grdAgyChrg.CurrentCell.ColumnIndex = 3 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then

                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAgyChrg_SelectedIndexChanged
                    'RemoveHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'RemoveHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                    Dim tmp_index = cboBox.SelectedIndex
                    cboBox.DataSource = Cust_ShortList
                    cboBox.SelectedIndex = tmp_index
                    cboBox.Width = 400
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAgyChrg_SelectedIndexChanged
                    'AddHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'AddHandler cboBox.Click, AddressOf cbogrdAgyChrg_click

                End If
            End If
        ElseIf grdAgyChrg.CurrentCell.ColumnIndex = 5 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then

                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAgyChrg_SelectedIndexChanged
                    'RemoveHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'RemoveHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                    Dim tmp_index = cboBox.SelectedIndex
                    cboBox.DataSource = ChargeList
                    cboBox.SelectedIndex = tmp_index
                    cboBox.Width = 400
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAgyChrg_SelectedIndexChanged
                    'AddHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'AddHandler cboBox.Click, AddressOf cbogrdAgyChrg_click

                End If
            End If
        End If
    End Sub

    Private Sub cbogrdAgyChrg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = grdAgyChrg.CurrentCell.RowIndex
        Dim iCol As Integer = grdAgyChrg.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.grdAgyChrg.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAssDgnVen_SelectedIndexChanged
                ' User has changed the function
                If iCol = 3 Then
                    Me.grdAgyChrg.Rows(iRow).Cells(iCol).Value = strSelItem
                    'Me.grdAssDgnVen.Rows(iRow).Cells(iCol + 1).Value = fun_long_list(cboBox.SelectedIndex)
                    Me.grdAgyChrg.Rows(iRow).Cells(iCol + 1).Value = Cust_LongList(cboBox.SelectedIndex)
                    'Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_syusrfun.Tables("RESULT").Select("yuf_usrfun = '" & strSelItem & "'")(0).Item("yuf_fundsc").ToString
                ElseIf iCol = 5 Then
                    Me.grdAgyChrg.Rows(iRow).Cells(iCol).Value = ChargeList(cboBox.SelectedIndex)
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdAgyChrg_SelectedIndexChanged

            End If
        End If
    End Sub

    'Private Sub cbogrdAgyChrg_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim cbobox As ComboBox = CType(sender, ComboBox)
    '    If grdAgyChrg.CurrentCell.ColumnIndex = 3 Then
    '        If Not cbobox Is Nothing AndAlso Not cbobox.SelectedItem Is Nothing Then
    '            Dim tmp_index = cbobox.SelectedIndex
    '            cbobox.DataSource = Cust_ShortList
    '            cbobox.SelectedIndex = tmp_index

    '        End If
    '    End If
    'End Sub

    Private Sub cbogrdAgyChrg_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbobox As ComboBox = CType(sender, ComboBox)
        If grdAgyChrg.CurrentCell.ColumnIndex = 3 Then
            If Not cbobox Is Nothing AndAlso Not cbobox.SelectedItem Is Nothing Then
                Dim tmp_index = cbobox.SelectedIndex
                cbobox.DataSource = Cust_ShortList
                cbobox.SelectedIndex = tmp_index
                cbobox.Width = 400
            End If
        ElseIf grdAgyChrg.CurrentCell.ColumnIndex = 5 Then
            If Not cbobox Is Nothing AndAlso Not cbobox.SelectedItem Is Nothing Then
                Dim tmp_index = cbobox.SelectedIndex
                cbobox.DataSource = ChargeList
                cbobox.SelectedIndex = tmp_index
                cbobox.Width = 400
            End If
        End If
    End Sub

#End Region

  
    Private Sub createComboBoxCell_grdDevChrg(ByVal cell As DataGridViewCell)
        Dim cbocell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        If iCol = 2 Then


            'For i As Integer = 0 To dr.Length - 1
            '    cbocell.Items.Add(Trim(dr(i).Item("vbi_venno")) + " - " + Trim(dr(i).Item("vbi_vensna")))
            'Next
            cbocell.DataSource = Vendor_ShortList
        ElseIf iCol = 4 Then
            cbocell.DataSource = Cust_ShortList
        ElseIf iCol = 6 Then
            cbocell.DataSource = ChargeList
        End If

        cbocell.DropDownWidth = 150
        cbocell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cbocell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub


    Private Sub grdDevChrg_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDevChrg.CellClick
        If Not e.RowIndex = -1 Then
            If e.ColumnIndex = 0 Then
                If rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_del") = "" Then
                    If isDevEssential(e.RowIndex) Then
                        Exit Sub
                    End If
                    rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_del") = "Y"
                    If rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*ADD*~" And _
                        rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*DEL*~" And _
                        rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*NEW*~" Then
                        rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") = "~*DEL*~"
                    End If
                Else
                    rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_del") = ""
                    If rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") = "~*DEL*~" Then
                        rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") = "~*UPD*~"
                    End If
                End If
            ElseIf e.ColumnIndex = 2 Then
                If rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*ADD*~" And _
                    rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*DEL*~" And _
                    rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*NEW*~" Then
                    'rs_PCMDEVCRG.Fields("pdc_creusr") <> "~*UPD*~" Then

                    MsgBox("Cannot change Profit Center Factory")
                    Exit Sub
                Else
                    If TypeOf (grdDevChrg.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell_grdDevChrg(grdDevChrg.CurrentCell)
                        grdDevChrg.BeginEdit(True)

                    End If
                End If

            ElseIf e.ColumnIndex = 4 Then ' customer name
                If rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*ADD*~" And _
                    rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*DEL*~" And _
                    rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*NEW*~" Then
                    '            And _
                    '            rs_PCMAGYCRG.Fields("pac_creusr") <> "~*UPD*~" Then

                    MsgBox("Cannot change Profit Center Customer")
                    Exit Sub
                Else
                    'Todo: Change to comboxboxgrid
                    If TypeOf (grdDevChrg.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell_grdDevChrg(grdDevChrg.CurrentCell)
                        grdDevChrg.BeginEdit(True)

                    End If
                End If
            ElseIf e.ColumnIndex = 6 Then

                If TypeOf (grdDevChrg.CurrentCell) Is DataGridViewTextBoxCell Then
                    If rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*ADD*~" And rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") <> "~*DEL*~" Then
                        rs_PCMDEVCRG.Tables(0).Rows(e.RowIndex).Item("pdc_creusr") = "~*UPD*~"
                    End If
                    createComboBoxCell_grdDevChrg(grdDevChrg.CurrentCell)
                    grdDevChrg.BeginEdit(True)

                End If
                End If
        End If
    End Sub

    Private Sub grdDevChrg_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDevChrg.CellValidating
        Dim row As DataGridViewRow = grdAssDgnVen.CurrentRow
        Dim strNewVal As String

        If row Is Nothing Then
            Exit Sub
        End If


        If e.ColumnIndex = 2 Then
            strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

            If InvalidDevCrgLevel(e.RowIndex) = True Then
                MsgBox("Incorrect Combination of Factory Code and Customer Code")
                'Call gotorecord(rs_PCMDEVCRG, pos)
                e.Cancel = True
                Exit Sub


            ElseIf HaveDuplicateDevelopCharge() = True Then
                MsgBox("Duplicate Factory Code and Customer Code")
                'Call gotorecord(rs_PCMDEVCRG, pos)
                e.Cancel = True

                Exit Sub

            End If

        ElseIf e.ColumnIndex = 4 Then
            strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim
            If InvalidDevCrgLevel(e.RowIndex) = True Then
                MsgBox("Incorrect Combination of Factory Code and Customer Name")
                e.Cancel = True

                Exit Sub
            ElseIf HaveDuplicateDevelopCharge() = True Then
                MsgBox("Duplicate Factory Code and Customer Name")
                e.Cancel = True
                Exit Sub
            End If

        ElseIf e.ColumnIndex = 6 Then

            'If (InStr(lstHdChrgFml.Text, " - ") > 0) Then
            'rs_PCMAGYCRG.Tables(0).Rows(e.RowIndex).Item("pac_hdcfmlopt") = Mid(lstHdChrgFml.Text, 1, InStr(lstHdChrgFml.Text, " - "))
            'rs_PCMAGYCRG.Fields("pac_hdcfml") = Mid(lstHdChrgFml.Text, InStr(lstHdChrgFml.Text, " - ") + 3)
            'rs_PCMAGYCRG.Fields("pac_hdcfml") = lstHdChrgFml.Text
            'Call grdAgyChrg_AfterColUpdate(5)
            'Call grdAgyChrg_AfterColUpdate(6)
            'End If

        End If
    End Sub

    Private Sub grdDevChrg_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDevChrg.EditingControlShowing
        If grdDevChrg.CurrentCell.ColumnIndex = 2 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then

                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged
                    'RemoveHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'RemoveHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                    Dim tmp_index = cboBox.SelectedIndex
                    cboBox.DataSource = Vendor_ShortList
                    cboBox.SelectedIndex = tmp_index
                    cboBox.Width = 400
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged
                    'AddHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'AddHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                End If
            End If
        ElseIf grdDevChrg.CurrentCell.ColumnIndex = 4 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then

                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged
                    'RemoveHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'RemoveHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                    Dim tmp_index = cboBox.SelectedIndex
                    cboBox.DataSource = Cust_ShortList
                    cboBox.SelectedIndex = tmp_index
                    cboBox.Width = 400
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged
                    'AddHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'AddHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                End If
            End If
        ElseIf grdDevChrg.CurrentCell.ColumnIndex = 6 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then

                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged
                    'RemoveHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'RemoveHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                    Dim tmp_index = cboBox.SelectedIndex
                    cboBox.DataSource = ChargeList
                    cboBox.SelectedIndex = tmp_index
                    cboBox.Width = 400
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged
                    'AddHandler cboBox.SelectionChangeCommitted, AddressOf cbogrdAgyChrg_SelectionChangeCommitted
                    'AddHandler cboBox.Click, AddressOf cbogrdAgyChrg_click
                End If


            End If
        End If
    End Sub

    Private Sub cbogrdDevChrg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = grdDevChrg.CurrentCell.RowIndex
        Dim iCol As Integer = grdDevChrg.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.grdDevChrg.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged
                ' User has changed the function
                If iCol = 2 Then
                    Me.grdDevChrg.Rows(iRow).Cells(iCol).Value = strSelItem
                    'Me.grdAssDgnVen.Rows(iRow).Cells(iCol + 1).Value = fun_long_list(cboBox.SelectedIndex)
                    Me.grdDevChrg.Rows(iRow).Cells(iCol + 1).Value = Split(Vendor_LongList(cboBox.SelectedIndex), " - ")(1)
                    'Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_syusrfun.Tables("RESULT").Select("yuf_usrfun = '" & strSelItem & "'")(0).Item("yuf_fundsc").ToString
                ElseIf iCol = 4 Then
                    Me.grdDevChrg.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.grdDevChrg.Rows(iRow).Cells(iCol + 1).Value = Cust_LongList(cboBox.SelectedIndex)
                ElseIf iCol = 6 Then
                    Me.grdDevChrg.Rows(iRow).Cells(iCol).Value = strSelItem
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cbogrdDevChrg_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub grdDevChrg_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDevChrg.DataError

    End Sub

    Private Sub grdAgyChrg_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdAgyChrg.DataError

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim answer As Integer = MsgBox("Are you sure to change Posting Date?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then
            gspStr = "sp_update_ACEDIBAT_pstdat '" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Update Fail! " & rtnStr)
                Exit Sub
            Else
                MsgBox("Update Success")
                setgrdPstDat()
            End If

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            GroupBox1.Enabled = False
            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
            Label2.ForeColor = Color.Blue
            Label8.ForeColor = Color.Black

            cmdClear.Enabled = False
            cmdAdd.Enabled = False
            cmdSearch.Enabled = False
            cmdFind.Enabled = False
        Else
            GroupBox1.Enabled = True
            GroupBox2.Enabled = False
            GroupBox3.Enabled = True

            Label2.ForeColor = Color.Black
            Label8.ForeColor = Color.Blue

            cmdAdd.Enabled = True
            cmdSearch.Enabled = True
            cmdFind.Enabled = True


        End If
    End Sub

    
End Class