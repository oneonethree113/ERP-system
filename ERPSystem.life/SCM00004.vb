Imports System.IO

Public Class SCM00004

    Const strModule As String = "SC"
    Const filePattern As String = "*.jpg"

    Public rs_ScTpSmk As New DataSet
    Public rs_scno As New DataSet
    Public rs_scno_bak As New DataSet
    Public rs_ath As New DataSet
    Public RsJobSmk2 As New DataSet
    Public rs_Smkfiles As New DataSet

    Dim picturePreview As SCM00004_ATH

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim bolskipcolrowchange As Boolean
    Dim save_ok As Boolean
    Dim bolUpdated As Boolean

    Dim Temp_SeqNo As Integer

    Dim appPath As String
    Dim Temp_JobNo As String
    Dim recordStatus As Boolean
    Dim appendStatus As Boolean
    Dim exitFlag As Boolean
    Public init_SCNo As String = ""
    Public init_cocde As String = ""

    Private Sub SCM00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        recordStatus = False
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)
        getDefault_Path()

        '***    default paths
        appPath = gs_PDO_localpath
        filllstShipMark()

        Temp_JobNo = ""
        Temp_SeqNo = 1
        '---- Additional information for archive ship mark -----

        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        '*** GET EMPTY STRUCTURE FROM FYJOBSMK
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        gspStr = "sp_list_SCTPSMRK '" & cboCoCde.Text & "','XXX'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'Fixing global company code problem at 20100420
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        rs_ScTpSmk = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_ScTpSmk, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> "0" Then  '*** An error has occured
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00004 #001 sp_list_SCTPSMRK : " & rtnStr)
        End If

        tabFrame.SelectTab(0)

        bolskipcolrowchange = False


        cmdClearAll.Enabled = False
        cmdSave.Enabled = False
        cmdApySCRange.Enabled = False
        cmdAppend.Enabled = True

        cmdLeft.Enabled = False
        cmdRight.Enabled = False
        chkdelall.Enabled = False
        cmdDelAllSM.Enabled = False

        If init_cocde <> "" Then
            cboCoCde.Text = init_cocde
        End If
        If init_SCNo <> "" Then
            txtSCFm.Text = init_SCNo
            txtSCTo.Text = init_SCNo
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
        txtSCFm.Focus()
        txtSCFm.Select()

    End Sub

    Private Sub cmdAppend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAppend.Click
        Dim ScFm As String
        Dim ScTo As String

        ScFm = UCase(Trim(Me.txtSCFm.Text))
        ScTo = UCase(Trim(Me.txtSCTo.Text))

        txtSCFm.Text = ScFm
        txtSCTo.Text = ScTo

        If Len(ScFm) = 0 And Len(ScTo) = 0 Then
            MsgBox("Please input SC #!")
            txtSCFm.Focus()
            txtSCFm.Select()
            Exit Sub
        End If

        If ScFm > ScTo Then
            MsgBox("SC # From > To !")
            txtSCFm.Focus()
            txtSCFm.Select()
            Exit Sub
        End If

        If checkSCAppended(ScFm, ScTo) Then
            MsgBox("SC # duplicate!")
            txtSCFm.Focus()
            txtSCFm.Select()
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        lstSelShipMark.Items.Clear()

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        gspStr = "sp_select_SCM00004_SM '" & cboCoCde.Text & "','" & ScFm & "','" & ScTo & "','" & gsUsrID & _
                 "','" & strModule & "','X'"
        'rs_scno = Nothing
        Dim rs_scno_temp As New DataSet

        rtnLong = execute_SQLStatement(gspStr, rs_scno_temp, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00004 #002 sp_select_SCM00004_SM : " & rtnStr)
            Exit Sub
        End If
        If rs_scno Is Nothing Then
            rs_scno = rs_scno_temp.Copy()
        Else
            rs_scno.Merge(rs_scno_temp, False)
        End If

        gspStr = "sp_select_SCM00004_ATH '" & cboCoCde.Text & "','" & ScFm & "','" & ScTo & "','" & gsUsrID & _
                 "','" & strModule & "','X'"
        Dim rs_ath_temp As New DataSet
        rtnLong = execute_SQLStatement(gspStr, rs_ath_temp, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00004 #003 sp_select_SCM00004_ATH : " & rtnStr)
            Exit Sub
        End If
        If rs_ath Is Nothing Then
            rs_ath = rs_ath_temp.Copy()
        Else
            rs_ath.Merge(rs_ath_temp, False)
        End If

        rs_scno_bak = rs_scno.Clone()

        If rs_ScTpSmk.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_ScTpSmk.Tables("RESULT").Rows.Count - 1
                rs_ScTpSmk.Tables("RESULT").Rows(i).Delete()
            Next
            rs_ScTpSmk.AcceptChanges()
        End If

        If rs_ath.Tables("RESULT").Rows.Count > 0 Then
            Dim newRow As DataRow
            For i As Integer = 0 To rs_ath.Tables("RESULT").Rows.Count - 1
                If rs_scno_bak.Tables("RESULT").Rows.Count <= 0 Then
                    newRow = rs_ScTpSmk.Tables("RESULT").NewRow
                    newRow.Item("stm_cocde") = rs_ath.Tables("RESULT").Rows(i)("stm_cocde")
                    newRow.Item("stm_ordnoseq") = rs_ath.Tables("RESULT").Rows(i)("scseq")
                    newRow.Item("stm_ordno") = Trim(Split(rs_ath.Tables("RESULT").Rows(i)("scseq"), "-")(0))
                    newRow.Item("stm_ordseq") = Trim(Split(rs_ath.Tables("RESULT").Rows(i)("scseq"), "-")(1))
                    newRow.Item("stm_smkno") = rs_ath.Tables("RESULT").Rows(i)("stm_smkno")
                    newRow.Item("stm_creusr") = rs_ath.Tables("RESULT").Rows(i)("stm_creusr")
                    rs_ScTpSmk.Tables("RESULT").Rows.Add(newRow)
                    rs_ScTpSmk.AcceptChanges()
                End If
            Next
        End If

        If rs_scno.Tables("RESULT").Rows.Count > 0 Then

            Me.cboCoCde.Enabled = False

            grdNewOrder.DataSource = rs_scno.Tables("RESULT").DefaultView
            'Set grdNewOrder.DataSource = rs_scno_bak

            Display_grdNewOrder()

            cmdLeft.Enabled = True
            cmdRight.Enabled = True
            chkdelall.Enabled = True
            cmdDelAllSM.Enabled = True

        Else
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No record found")
            Exit Sub
        End If

        save_ok = False
        tabFrame.SelectTab(0)

        'Call SetListboxScrollbar(lstNewOrder)

        Dim SelScFm As String = UCase(Trim(Me.txtSelSCFm.Text))
        Dim SelScTo As String = UCase(Trim(Me.txtSelSCTo.Text))

        If ScFm < SelScFm Or txtSelSCFm.Text = "" Then
            txtSelSCFm.Text = txtSCFm.Text
        End If

        If ScTo > SelScTo Or txtSelSCTo.Text = "" Then
            txtSelSCTo.Text = txtSCTo.Text
        End If

        cmdClearAll.Enabled = True
        cmdSave.Enabled = True
        cmdApySCRange.Enabled = True
        'cmdAppend.Enabled = False
        'txtSCFm.Enabled = False
        'txtSCTo.Enabled = False
        recordStatus = True
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Private Function checkSCAppended(ByVal ScFm As String, ByVal ScTo As String) As Boolean
        If rs_scno Is Nothing Then
            Return False
        End If
        If rs_scno.Tables("RESULT") Is Nothing Then
            Return False
        End If

        Dim table As DataTable = rs_scno.Tables("RESULT")

        Dim result() As DataRow = table.Select(" sod_ordno >= '" & ScFm & "' and sod_ordno <= '" & ScTo & "' ")

        If result.Length > 0 Then
            Return True
        End If
        Return False
    End Function
    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        recordStatus = False
        Dim intYNC As Integer
        Try
            If save_ok = False Then
                If Not rs_ScTpSmk Is Nothing Then
                    If rs_ScTpSmk.Tables("RESULT").Rows.Count > 0 And bolUpdated = True Then
                        intYNC = MsgBox("Save before clear?", MsgBoxStyle.YesNoCancel, "Clear Data")
                        If intYNC = MsgBoxResult.Cancel Then Exit Sub
                        If intYNC = MsgBoxResult.Yes Then
                            save_ok = False
                            cmdSave.PerformClick()
                            If save_ok = False Then Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        lstSelShipMark.Items.Clear()
        rs_ScTpSmk = rs_ScTpSmk.Clone
        grdJobSM.DataSource = Nothing
        grdNewOrder.DataSource = Nothing
        RsJobSmk2 = Nothing
        rs_scno = Nothing
        rs_ath = Nothing
        grdJobSM.Refresh()
        cboCoCde.Enabled = True
        save_ok = False

        txtSelSCFm.Text = ""
        txtSelSCTo.Text = ""

        cmdAppend.Enabled = True
        txtSCFm.Enabled = True
        txtSCTo.Enabled = True
        cmdClearAll.Enabled = False
        cmdSave.Enabled = False
        cmdApySCRange.Enabled = False

        cmdLeft.Enabled = False
        cmdRight.Enabled = False
        chkdelall.Enabled = False
        cmdDelAllSM.Enabled = False

        bolUpdated = False
        txtSCFm.Focus()
        txtSCFm.Select()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If rs_ScTpSmk Is Nothing Then
            Exit Sub
        Else
            If rs_ScTpSmk.Tables("RESULT").Rows.Count <= 0 Then
                Exit Sub
            End If
        End If

        If MsgBox("Confirm to save data?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        save()
    End Sub

    Private Function save() As Boolean
        Dim jobno As String
        Dim rs As New DataSet
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'rs_ScTpSmk.sort = "stm_ordnoseq"

        jobno = ""
        save_ok = False

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        For i As Integer = 0 To rs_ScTpSmk.Tables("RESULT").Rows.Count - 1
            If Trim(rs_ScTpSmk.Tables("RESULT").Rows(i)("stm_creusr")) <> "" And Trim(rs_ScTpSmk.Tables("RESULT").Rows(i)("stm_creusr")) <> "___" Then
                gspStr = "sp_insert_SCTPSMRK '" & cboCoCde.Text & "','" & rs_ScTpSmk.Tables("RESULT").Rows(i)("stm_ordno") & _
                         "','" & rs_ScTpSmk.Tables("RESULT").Rows(i)("stm_ordseq") & "','" & _
                         rs_ScTpSmk.Tables("RESULT").Rows(i)("stm_jobno") & "','" & rs_ScTpSmk.Tables("RESULT").Rows(i)("stm_smkno") & _
                         "','" & gsUsrID & "','" & rs_ScTpSmk.Tables("RESULT").Rows(i)("stm_creusr") & "'"

                gsCompany = Trim(cboCoCde.Text)
                Update_gs_Value(gsCompany)

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on saving SCM00004 #003 sp_insert_SCTPSMRK : " & rtnStr)
                    Return False
                    Exit Function
                End If
            End If
        Next
        rs_scno = Nothing
        rs_ath = Nothing
        MsgBox("Record Saved!")
        save_ok = True

        cmdClearAll.PerformClick()
        recordStatus = False
        Me.Cursor = Windows.Forms.Cursors.Default
        Return True
    End Function

    Private Sub cmdApySCRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApySCRange.Click
        Dim ScFm As String
        Dim ScTo As String

        Dim rs_scno_mirror As DataSet

        ScFm = UCase(Trim(txtSelSCFm.Text))
        ScTo = UCase(Trim(txtSelSCTo.Text))


        If ScFm = "" Then
            MsgBox("Item From not selected.")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If ScTo = "" Then
            MsgBox("Item To not selected.")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If ScFm > ScTo Then
            MsgBox("To value smaller than From value.")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        grdNewOrder.Rows(0).Cells(1).Selected = True
        grdNewOrder.ClearSelection()
        grdNewOrder.Refresh()

        lstSelShipMark.Items.Clear()

        rs_scno.Tables("RESULT").DefaultView.Sort = "sod_ordno"

        rs_scno_mirror = rs_scno.Copy()

        'rs_scno_mirror.Filter = "sod_ordno >= '" & Trim(ScFm) & "' and sod_ordno <= '" & Trim(ScTo) & "'"
        'If rs_scno_mirror.recordCount > 0 Then
        '    rs_scno_mirror.MoveFirst()
        '    While Not rs_scno_mirror.EOF
        '        grdNewOrder.SelBookmarks.Add(rs_scno_mirror.bookmark)
        '        rs_scno.bookmark = rs_scno_mirror.bookmark
        '        rs_scno.Fields(0) = "Y"
        '        rs_scno_mirror.MoveNext()
        '    End While

        '    rs_scno_mirror.MovePrevious()

        '    lstSelShipMark.Clear()
        '    rs_ScTpSmk.Filter = ""
        '    If rs_ScTpSmk.recordCount > 0 Then rs_ScTpSmk.MoveFirst()
        '    If Not rs_ScTpSmk.EOF Then
        '        Do While Not rs_ScTpSmk.EOF
        '            If rs_ScTpSmk("stm_ordno") = rs_scno_mirror.Fields("sod_ordno") And rs_ScTpSmk("stm_ordseq") = rs_scno_mirror.Fields("sod_ordseq") Then
        '                If rs_ScTpSmk("stm_creusr") <> "DEL" And rs_ScTpSmk("stm_creusr") <> "NEW" Then
        '                    lstSelShipMark.AddItem(rs_ScTpSmk("stm_smkno"))
        '                End If
        '            End If
        '            rs_ScTpSmk.MoveNext()
        '        Loop
        '    End If
        '    rs_ScTpSmk.Filter = ""

        '    rs_scno_mirror.MoveNext()
        'End If

        Dim dr() As DataRow
        rs_scno_mirror.Tables("RESULT").DefaultView.RowFilter = "sod_ordno >= '" & Trim(ScFm) & "' and sod_ordno <= '" & Trim(ScTo) & "'"
        If rs_scno_mirror.Tables("RESULT").DefaultView.Count > 0 Then
            rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = False
            For i As Integer = 0 To rs_scno_mirror.Tables("RESULT").DefaultView.Count - 1
                For j As Integer = 0 To grdNewOrder.Rows.Count - 1
                    If grdNewOrder.Rows(j).Cells("sod_ordno").Value = rs_scno_mirror.Tables("RESULT").DefaultView(i)("sod_ordno").ToString Then
                        grdNewOrder.Rows(j).Cells("sod_sel").Value = "Y"
                        grdNewOrder.Rows(j).Selected = True

                        lstSelShipMark.Items.Clear()
                        dr = Nothing
                        dr = rs_ScTpSmk.Tables("RESULT").Select("stm_ordno = '" & rs_scno_mirror.Tables("RESULT").DefaultView(i)("sod_ordno") & "' and stm_ordseq = '" & rs_scno_mirror.Tables("RESULT").DefaultView(i)("sod_ordseq") & "'")
                        If dr.Length > 0 Then
                            For k As Integer = 0 To dr.Length - 1
                                If dr(k).Item("stm_creusr") <> "DEL" And dr(k).Item("stm_creusr") <> "NEW" Then
                                    lstSelShipMark.Items.Add(dr(k).Item("stm_smkno"))
                                End If
                            Next
                        End If
                    End If
                Next
            Next
            rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = True
        End If

        'grdNewOrder.ClearSelection()

    End Sub

    Private Sub cmdLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeft.Click
        Dim cont As Boolean
        Dim bshpmrk As Boolean
        Dim intCount As Long
        Dim apos As Integer

        On Error Resume Next

        bolskipcolrowchange = True

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        bshpmrk = False

        Me.BringToFront()

        For i As Integer = 0 To lstShipMark.SelectedItems.Count - 1
            cont = True
            bshpmrk = True
            For j As Integer = 0 To lstSelShipMark.Items.Count - 1
                If lstSelShipMark.Items(j) = lstShipMark.SelectedItems(i) Then
                    cont = False
                    Exit For
                End If
            Next
            If cont = True Then
                lstSelShipMark.Items.Add(lstShipMark.SelectedItems(i))
            End If
        Next

        If bshpmrk = False Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No shipmark selected.")
            Me.Enabled = True
            bolskipcolrowchange = False
            Exit Sub
        End If

        Dim varBmk As Object
        apos = 0

        grdNewOrder.ClearSelection()

        For i As Integer = 0 To grdNewOrder.Rows.Count - 1
            If grdNewOrder.Rows(i).Cells("sod_sel").Value = "Y" Then
                grdNewOrder.Rows(i).Selected = True
            End If
        Next

        If grdNewOrder.SelectedRows.Count = 0 Then
            lstSelShipMark.Items.Clear()
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No order selected.")
            Me.Enabled = True
            bolskipcolrowchange = False
            Exit Sub
        End If

        Dim dr() As DataRow
        Dim newRow As DataRow
        rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = False
        rs_ScTpSmk.Tables("RESULT").Columns("stm_creusr").ReadOnly = False
        For i As Integer = 0 To grdNewOrder.SelectedRows.Count - 1
            For j As Integer = 0 To lstShipMark.SelectedItems.Count - 1
                dr = Nothing
                dr = rs_ScTpSmk.Tables("RESULT").Select("stm_ordno = '" & grdNewOrder.SelectedRows(i).Cells("sod_ordno").Value & "' and stm_ordseq = '" & grdNewOrder.SelectedRows(i).Cells("sod_ordseq").Value & "' and stm_smkno = '" & lstShipMark.SelectedItems.Item(j) & "'")
                If dr.Length <= 0 Then
                    newRow = Nothing
                    newRow = rs_ScTpSmk.Tables("RESULT").NewRow
                    newRow.Item("stm_ordno") = grdNewOrder.SelectedRows(i).Cells("sod_ordno").Value
                    newRow.Item("stm_ordseq") = grdNewOrder.SelectedRows(i).Cells("sod_ordseq").Value
                    newRow.Item("stm_ordnoseq") = grdNewOrder.SelectedRows(i).Cells("sod_ordno").Value & " - " & grdNewOrder.SelectedRows(i).Cells("sod_ordseq").Value
                    newRow.Item("stm_jobno") = grdNewOrder.SelectedRows(i).Cells("pod_jobord").Value
                    newRow.Item("stm_smkno") = lstShipMark.SelectedItems(j)
                    newRow.Item("stm_creusr") = "ADD"
                    rs_ScTpSmk.Tables("RESULT").Rows.Add(newRow)
                    rs_ScTpSmk.AcceptChanges()
                ElseIf dr(0).Item("stm_creusr") = "NEW" Then
                    dr(0).Item("stm_creusr") = "ADD"
                Else
                    dr(0).Item("stm_creusr") = "UPD"
                End If
            Next
            grdNewOrder.SelectedRows(i).Cells("sod_sel").Value = ""
        Next
        rs_ScTpSmk.Tables("RESULT").Columns("stm_creusr").ReadOnly = True
        rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = True

        bolskipcolrowchange = False

        grdNewOrder.ClearSelection()

        bolUpdated = True

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRight.Click
        bolskipcolrowchange = True

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        grdNewOrder.ClearSelection()
        grdNewOrder.Refresh()

        For i As Integer = 0 To grdNewOrder.Rows.Count - 1
            If grdNewOrder.Rows(i).Cells("sod_sel").Value = "Y" Then
                grdNewOrder.Rows(i).Selected = True
            End If
        Next

        If grdNewOrder.SelectedRows.Count = 0 Then
            lstSelShipMark.Items.Clear()
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No order selected.")
            bolskipcolrowchange = False
            Exit Sub
        End If

        'bshpmrk = False
        If lstSelShipMark.SelectedItems.Count = 0 And chkdelall.Checked = False Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No shipmark selected.")
            grdNewOrder.ClearSelection()
            grdNewOrder.Refresh()
            bolskipcolrowchange = False
            Exit Sub
        End If

        If chkdelall.Checked = True Then
            If MsgBox("All shipmark in selected order will be delete (Y/N)", MsgBoxStyle.YesNo, " please confirm.") = MsgBoxResult.No Then
                Me.Cursor = Windows.Forms.Cursors.Default
                grdNewOrder.ClearSelection()
                grdNewOrder.Refresh()
                bolskipcolrowchange = False
                Exit Sub
            End If
        End If

        Dim dr() As DataRow
        rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = False
        rs_ScTpSmk.Tables("RESULT").Columns("stm_creusr").ReadOnly = False
        For i As Integer = 0 To grdNewOrder.SelectedRows.Count - 1
            If chkdelall.Checked = False Then
                For j As Integer = 0 To lstSelShipMark.SelectedItems.Count - 1
                    dr = Nothing
                    dr = rs_ScTpSmk.Tables("RESULT").Select("stm_ordno = '" & grdNewOrder.SelectedRows(i).Cells("sod_ordno").Value & "' and stm_ordseq = '" & grdNewOrder.SelectedRows(i).Cells("sod_ordseq").Value & "' and stm_smkno = '" & lstSelShipMark.SelectedItems(j) & "'")
                    If dr.Length > 0 Then
                        If dr(0).Item("stm_creusr").ToString = "___" Then
                            dr(0).Item("stm_creusr") = "DEL"
                        ElseIf dr(0).Item("stm_creusr").ToString = "ADD" Then
                            dr(0).Item("stm_creusr") = "NEW"
                        ElseIf dr(0).Item("stm_creusr") = "UPD" Then
                            dr(0).Item("stm_creusr") = "DEL"
                        End If
                    End If
                Next
            Else
                dr = Nothing
                dr = rs_ScTpSmk.Tables("RESULT").Select("stm_ordno = '" & grdNewOrder.SelectedRows(i).Cells("sod_ordno").Value & "' and stm_ordseq = '" & grdNewOrder.SelectedRows(i).Cells("sod_ordseq").Value & "'")
                For j As Integer = 0 To dr.Length - 1
                    If dr(i).Item("stm_creusr").ToString = "___" Then
                        dr(i).Item("stm_creusr") = "DEL"
                    ElseIf dr(i).Item("stm_creusr").ToString = "ADD" Then
                        dr(i).Item("stm_creusr") = "NEW"
                    ElseIf dr(i).Item("stm_creusr") = "UPD" Then
                        dr(i).Item("stm_creusr") = "DEL"
                    End If
                Next
            End If
            grdNewOrder.SelectedRows(i).Cells("sod_sel").Value = ""
        Next
        rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = True
        rs_ScTpSmk.Tables("RESULT").Columns("stm_creusr").ReadOnly = True

        For i As Integer = 0 To lstSelShipMark.SelectedItems.Count - 1
            lstSelShipMark.Items.Remove(lstSelShipMark.SelectedItems(0))
        Next

        If chkdelall.Checked = True Then
            chkdelall.Checked = False
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

        grdNewOrder.ClearSelection()
        grdNewOrder.Refresh()

        bolUpdated = True

        bolskipcolrowchange = False
    End Sub

    Private Sub cmdDelAllSM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelAllSM.Click
        chkdelall.Checked = True
        cmdRight.PerformClick()
        chkdelall.Checked = False
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged

        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        getDefault_Path()
        filllstShipMark()
    End Sub

    Private Sub filllstShipMark()
        If Not Directory.Exists(gs_PDO_SMImg) Then
            MsgBox("Directory Not Exist!" & Environment.NewLine & gs_PDO_SMImg)
            Exit Sub
        End If

        Dim Dir As New System.IO.DirectoryInfo(gs_PDO_SMImg)
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(filePattern)
        Dim File As System.IO.FileInfo
        lstShipMark.Items.Clear()
        rs_Smkfiles = New DataSet
        Dim dt As DataTable = New DataTable
        dt.Columns().Add("Item")
        For Each File In Files
            'Add the file name to the lstFiles listbox
            Dim dr As DataRow = dt.NewRow()
            dr("Item") = File.Name
            dt.Rows.Add(dr)
        Next
        rs_Smkfiles.Tables.Add(dt)
        For i As Integer = 0 To rs_Smkfiles.Tables(0).Rows.Count - 1
            lstShipMark.Items.Add(rs_Smkfiles.Tables(0).Rows(i)("Item"))
        Next
        lstShipMark.Sorted = True
        lstShipMark.Refresh()
    End Sub

    Private Sub txtSCTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSCTo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdAppend.PerformClick()
        End If
    End Sub

    Private Sub UpperCaseText(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSCFm.LostFocus, txtSCTo.LostFocus, txtSelSCFm.LostFocus, txtSelSCTo.LostFocus
        sender.Text = UCase(sender.Text)
    End Sub

    Private Sub txtSCFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCFm.TextChanged
        txtSCTo.Text = txtSCFm.Text
    End Sub

    Private Sub Display_grdNewOrder()
        With grdNewOrder
            For i As Integer = 0 To grdNewOrder.Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Sel"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "SC #"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "Seq#"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Job #"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Item #"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Uploaded"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
            .ClearSelection()
        End With
    End Sub

    Private Sub lstShipMark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstShipMark.SelectedIndexChanged
        If chkPreview.Checked Then
            displayPreview()
        End If
    End Sub

    Private Sub chkPreview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreview.CheckedChanged
        displayPreview()
    End Sub

    Private Sub displayPreview()
        If chkPreview.Checked Then
            If Not lstShipMark.SelectedItem Is Nothing Then
                imgShipMark.Load(gs_PDO_SMImg & lstShipMark.SelectedItem.ToString)
                imgShipMark.SizeMode = PictureBoxSizeMode.Zoom
                imgShipMark.Visible = True
            End If
        Else
            imgShipMark.Image = Nothing
            imgShipMark.Visible = False
        End If
    End Sub

    Private Sub imgShipMark_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgShipMark.DoubleClick
        picturePreview = New SCM00004_ATH
        picturePreview.myOwner = Me
        picturePreview.ShowDialog()
    End Sub

    Private Sub grdNewOrder_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNewOrder.CellClick
        If grdNewOrder.SelectedCells.Count = 1 And e.RowIndex >= 0 Then
            If grdNewOrder.CurrentCell.ColumnIndex = 0 Then
                rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = False
                If grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("sod_sel").Value = "" Then
                    grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("sod_sel").Value = "Y"
                Else
                    grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("sod_sel").Value = ""
                End If
                rs_scno.Tables("RESULT").Columns("sod_sel").ReadOnly = True
                grdNewOrder.ClearSelection()
                grdNewOrder.Refresh()
                'grdNewOrder.CurrentCell.Selected = False
            End If
        End If
    End Sub

    Private Sub txtSelSCFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelSCFm.TextChanged

    End Sub

    Private Sub grdNewOrder_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNewOrder.RowEnter
        If sender.Focused = True Then
            If e.RowIndex >= 0 Then
                lstSelShipMark.Items.Clear()
                Dim dr() As DataRow = rs_ScTpSmk.Tables("RESULT").Select("stm_ordno = '" & grdNewOrder.Rows(e.RowIndex).Cells("sod_ordno").Value & "' and stm_ordseq = '" & grdNewOrder.Rows(e.RowIndex).Cells("sod_ordseq").Value & "'")
                If dr.Length > 0 Then
                    For i As Integer = 0 To dr.Length - 1
                        If dr(i).Item("stm_creusr") <> "DEL" And dr(i).Item("stm_creusr") <> "NEW" Then
                            lstSelShipMark.Items.Add(dr(i).Item("stm_smkno"))
                        End If
                    Next
                End If

                If txtSelSCFm.Text = "" Then
                    txtSelSCFm.Text = grdNewOrder.Rows(e.RowIndex).Cells("sod_ordno").Value
                Else
                    txtSelSCTo.Text = grdNewOrder.Rows(e.RowIndex).Cells("sod_ordno").Value
                End If
            End If
        End If
    End Sub

    Private Sub tabFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabFrame.SelectedIndexChanged
        If tabFrame.SelectedIndex = 1 Then
            RsJobSmk2 = rs_ScTpSmk.Copy()
            optUpd.Checked = True
            ShowSummary("UPD")
        End If
    End Sub


    Private Sub Data_Selection_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUpd.CheckedChanged
        If optUpd.Checked = True Then
            ShowSummary("UPD")
        Else
            ShowSummary("ALL")
        End If
    End Sub

    Private Sub ShowSummary(ByVal mode As String)
        If RsJobSmk2 Is Nothing Then
            Exit Sub
        End If
        
        If mode = "UPD" Then
            RsJobSmk2.Tables("RESULT").DefaultView.RowFilter = "stm_creusr = 'ADD' or stm_creusr = 'UPD'  or stm_creusr = 'DEL'"
            If RsJobSmk2.Tables("RESULT").DefaultView.Count > 0 Then
                RsJobSmk2.Tables("RESULT").DefaultView.Sort = "stm_ordnoseq,stm_smkno,stm_creusr"
            End If
        ElseIf mode = "ALL" Then
            RsJobSmk2.Tables("RESULT").DefaultView.RowFilter = ""
            If RsJobSmk2.Tables("RESULT").DefaultView.Count > 0 Then
                RsJobSmk2.Tables("RESULT").DefaultView.Sort = "stm_ordnoseq,stm_smkno,stm_creusr"
            End If
        End If

        grdJobSM.DataSource = RsJobSmk2.Tables("RESULT").DefaultView
        Display_grdJobSM()
    End Sub

    Private Sub Display_grdJobSM()
        With grdJobSM
            For i As Integer = 0 To grdJobSM.Columns.Count - 1
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 3
                        .Columns(i).HeaderText = "SC # with Seq."
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Transport Ship Mark"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Update Flag"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Private Sub grdNewOrder_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdNewOrder.Sorted
        sender.ClearSelection()
    End Sub

    Private Sub txtShipMarkFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipMarkFilter.TextChanged
        Dim dv As DataView = rs_Smkfiles.Tables(0).DefaultView
        If txtShipMarkFilter.Text.Trim() <> "" Then
            dv.RowFilter = "[Item] like '" & EscapeLikeValue(txtShipMarkFilter.Text.Trim().Replace("'", "''")) & "%'"
        Else
            dv.RowFilter = ""
        End If
        lstShipMark.Items.Clear()
        For i As Integer = 0 To dv.Count - 1
            lstShipMark.Items.Add(dv(i)("Item"))
        Next
        lstShipMark.Sorted = True
        lstShipMark.Refresh()
    End Sub
    Public Function EscapeLikeValue(ByVal valueWithoutWildcards As String) As String
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
        For i As Integer = 0 To valueWithoutWildcards.Length - 1

            Dim c As Char = valueWithoutWildcards(i)
            If c = "*" Or c = "%" Or c = "[" Or c = "]" Then
                sb.Append("[").Append(c).Append("]")
            ElseIf (c = "\'") Then
                sb.Append("''")
            Else
                sb.Append(c)
            End If
           
        Next
        Return sb.ToString()

    End Function

    Private Sub txtSelSCFm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSelSCFm.KeyUp
        txtSelSCTo.Text = txtSelSCFm.Text
    End Sub

    Private Sub txtSCTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCTo.TextChanged

    End Sub

    Private Sub txtSelSCTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelSCTo.TextChanged

    End Sub

    Private Sub SCM00004_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim YesNoCancel As MsgBoxResult
        If recordStatus = True Then
            If rs_ScTpSmk Is Nothing Then
                Exit Sub
            Else
                If rs_ScTpSmk.Tables("RESULT").Rows.Count <= 0 Then
                    Exit Sub
                End If
            End If

            YesNoCancel = MsgBox("Record has been modified. Do you want to save before exit?", MsgBoxStyle.YesNoCancel)
            If YesNoCancel = MsgBoxResult.Yes Then
                If cmdSave.Enabled Then
                    exitFlag = True

                    If save() = True Then
                        Me.Close()
                        Exit Sub
                    Else
                        exitFlag = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    exitFlag = False
                    MsgBox("You are not allow to save record!", MsgBoxStyle.Exclamation, "Access Denied")
                    e.Cancel = True
                    Exit Sub
                End If

            ElseIf YesNoCancel = MsgBoxResult.No Then
                'ResetDefaultDisp()
                Exit Sub

            ElseIf YesNoCancel = vbCancel Then
                exitFlag = False
                e.Cancel = True
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub
End Class