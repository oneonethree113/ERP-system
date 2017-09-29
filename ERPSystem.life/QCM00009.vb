Imports System.IO

Public Class QCM00009
    Const strInternal As String = "Internal and Joint Venture"
    Const strExternal As String = "External"
    Const expItem As String = ""

    Dim appPath As String
    Dim gstrExtImgPath As String
    Dim gstrIntImgPath As String
    Dim gstrExtColPath As String
    Dim gstrIntColPath As String

    Dim serverName As String
    Dim defaultSource As String
    Dim defaultSourceUpload As String
    Dim defaultSourceUploaded As String
    Dim defaultSourceExp As String
    Dim defaultDest As String

    Dim validPath As Boolean
    Dim goBack As Boolean
    Dim filSourcePath As String
    Dim FilePattern As String = "*.*"

    Const strModule As String = "SC"
    'Const filePattern As String = "*.jpg"

    Public rs_POULFILE As New DataSet
    Public rs_POULFILE_old As New DataSet
    Public rs_scno As New DataSet
    Public rs_scno_bak As New DataSet
    Public rs_ath As New DataSet
    Public RsJobSmk2 As New DataSet

    Public rs_qcno As New DataSet
    Dim tbl_qcnoview As New DataTable

    'Dim picturePreview As QCM00009_ATH

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim bolskipcolrowchange As Boolean
    Dim save_ok As Boolean
    Dim bolUpdated As Boolean

    Dim Temp_SeqNo As Integer

    'Dim appPath As String
    Dim Temp_JobNo As String
    Dim g_pod_purord As String
    Dim g_pod_purseq As String
    Dim opt_opt As String

    Public ma_QCM00004 As QCM00004
    Public ma_QCM00002 As QCM00002
    Dim flg_QCM00002 As Boolean = False




    Private Sub QCM00009_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Dim sDrives As String() = System.Environment.GetLogicalDrives()
        drvSource.Items.Clear()
        Dim sDrive As String
        For Each sDrive In sDrives
            drvSource.Items.Add(sDrive)
        Next

        If getPath() = False Then
            validPath = False
            checkValidPath()
        End If

        goBack = True
        ' lblServerName.Text = "Default Server : " & serverName
        'lblFilname.Text = ""

        'lblNumFilSource.Text = filSource.Items.Count
        '        cboCoCde.Items.Add(strInternal)
        '       cboCoCde.Items.Add(strExternal)

        'setDefault()

        ''txtLog.ReadOnly = True
        ''grpFolders.Enabled = False
        ''dirDest.Enabled = False
        ''filDest.Enabled = False

        '       checkValidPath()

        '        'cmdCopyMove.Select()
        '---------------------------------------

        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)
        getDefault_Path()

        '***    default paths
        appPath = gs_PDO_localpath


        Temp_JobNo = ""
        Temp_SeqNo = 1
        '---- Additional information for archive ship mark -----

        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        '*** GET EMPTY STRUCTURE FROM FYJOBSMK
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        gspStr = "sp_list_POULFILE '" & cboCoCde.Text & "',''"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'Fixing global company code problem at 20100420
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        rs_POULFILE = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_POULFILE_old, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> "0" Then  '*** An error has occured
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading QCM00009 #001 sp_list_POULFILE : " & rtnStr)
        End If

        tabFrame.SelectTab(0)

        bolskipcolrowchange = False


        cmdClearAll.Enabled = False
        ' 'cmdSave.Enabled = False
        cmdApySCRange.Enabled = False
        cmdAppend.Enabled = True

        cmdLeft.Enabled = False
        cmdRight.Enabled = False
        cmd_Download.Enabled = False
        ''chkdelall.Enabled = False
        ''cmdDelAllSM.Enabled = False

        Me.Cursor = Windows.Forms.Cursors.Default
        txtSCFm.Focus()
        txtSCFm.Select()

        If Not ma_QCM00004 Is Nothing Then
            QCM00004_INIT()
        ElseIf Not ma_QCM00002 Is Nothing Then
            QCM00002_INIT()

        End If


    End Sub


    Private Sub QCM00004_INIT()
        cmdAppend_Click(cmdAppend, Nothing)
    End Sub

#Region "QCM00002 Related"
    Private Sub QCM00002_INIT()
        flg_QCM00002 = True
        Dim tmp_cocde As String = ma_QCM00002.rs_QCM00002Hdr.Tables(0).Rows(0).Item("qch_cocde")

        gsCompany = Trim(tmp_cocde)
        Update_gs_Value(gsCompany)
        cboCoCde.Text = gsCompany

        cmdAppend_Click(cmdAppend, Nothing)
    End Sub

    Private Sub QCM00002_Append()
        Me.Cursor = Cursors.WaitCursor

        opt_opt = "Q"

        Dim doctyp = "SC"

        gspStr = "sp_select_QCM00009_files2 '" & cboCoCde.Text & "','" & _
            txtQCNo.Text & "','" & _
            gsUsrID & "','" & _
            doctyp & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_qcno, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading QCM00009 #002 sp_select_QCM00009_files2 : " & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_QCM00009_POULFILE2 '" & cboCoCde.Text & "','" & txtQCNo.Text & "','" & gsUsrID & "'"


        rtnLong = execute_SQLStatement(gspStr, rs_POULFILE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading QCM00009 #002 sp_select_QCM00009_files : " & rtnStr)
            Exit Sub
        End If




        If rs_qcno.Tables("RESULT").Rows.Count > 0 Then

            Me.cboCoCde.Enabled = False

            rs_qcno.Tables(0).Select("typ='Q'")

            'grdNewOrder.DataSource = rs_qcno.Tables("RESULT").DefaultView
            'Set grdNewOrder.DataSource = rs_scno_bak

            QCM00002_DisplayGrid()
            'Display_grdNewOrder()

            cmdLeft.Enabled = True
            cmdRight.Enabled = True
            cmd_Download.enabled = True
            'chkdelall.Enabled = True
            'cmdDelAllSM.Enabled = True

        Else
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No record found or You have no rights to modify")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub QCM00002_DisplayGrid()
        Dim type As String



        If Opt_H.Checked = True Then
            type = "H"
        End If
        If Opt_Q.Checked = True Then
            type = "Q"
        End If
        If Opt_P.Checked = True Then
            type = "P"
        End If




        Dim rows() As DataRow = rs_qcno.Tables(0).Select("typ='" + type + "'")

        tbl_qcnoview = rs_qcno.Tables(0).Clone()
        For i As Integer = 0 To rows.Length - 1
            tbl_qcnoview.ImportRow(rows(i))
        Next

        tbl_qcnoview.Columns("pod_sel").ReadOnly = False
        grdNewOrder.DataSource = tbl_qcnoview.DefaultView
        Display_grdNewOrder()

        cmdApySCRange.Enabled = True




    End Sub



#End Region

    Private Sub cmdAppend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAppend.Click
        Dim ScFm As String
        Dim ScTo As String

        If flg_QCM00002 Then
            QCM00002_Append()
            Exit Sub
        End If




        GroupBox1.Enabled = False


        If Opt_H.Checked = True Then
            opt_opt = "H"
        End If
        If Opt_Q.Checked = True Then
            opt_opt = "Q"
        End If
        If Opt_P.Checked = True Then
            opt_opt = "P"
        End If

        ScFm = UCase(Trim(Me.txtSCFm.Text))
        ScTo = UCase(Trim(Me.txtSCTo.Text))

        txtSCFm.Text = ScFm
        txtSCTo.Text = ScTo

        If Len(ScFm) = 0 And Len(ScTo) = 0 Then
            MsgBox("Please input Order #!")
            txtSCFm.Focus()
            txtSCFm.Select()
            Exit Sub
        End If

        If ScFm > ScTo Then
            MsgBox("Order # From > To !")
            txtSCFm.Focus()
            txtSCFm.Select()
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        ''lstSelDesFiles.Items.Clear()

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        gspStr = "sp_select_QCM00009_files '" & cboCoCde.Text & "','" & ScFm & "','" & ScTo & "','" & gsUsrID & _
                 "','" & strModule & "','X','" & opt_opt & "'"
        rs_scno = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_scno, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading QCM00009 #002 sp_select_QCM00009_files : " & rtnStr)
            Exit Sub
        End If

        rs_scno_bak = rs_scno.Clone()

        gspStr = "sp_select_QCM00009_POULFILE '" & cboCoCde.Text & "','" & ScFm & "','" & ScTo & "','" & gsUsrID & _
         "','" & strModule & "','X' ,'" & opt_opt & "'"


        rtnLong = execute_SQLStatement(gspStr, rs_POULFILE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading QCM00009 #002 sp_select_QCM00009_files : " & rtnStr)
            Exit Sub
        End If



        'If rs_POULFILE.Tables("RESULT").Rows.Count > 0 Then
        '    For i As Integer = 0 To rs_POULFILE.Tables("RESULT").Rows.Count - 1
        '        rs_POULFILE.Tables("RESULT").Rows(i).Delete()
        '    Next
        '    rs_POULFILE.AcceptChanges()
        'End If
        '??

        If rs_scno.Tables("RESULT").Rows.Count > 0 Then

            Me.cboCoCde.Enabled = False

            grdNewOrder.DataSource = rs_scno.Tables("RESULT").DefaultView
            'Set grdNewOrder.DataSource = rs_scno_bak

            Display_grdNewOrder()

            cmdLeft.Enabled = True
            cmdRight.Enabled = True
            cmd_Download.enabled = True
            'chkdelall.Enabled = True
            'cmdDelAllSM.Enabled = True

        Else
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No record found or You have no rights to modify")
            Exit Sub
        End If

        save_ok = False
        tabFrame.SelectTab(0)

        'Call SetListboxScrollbar(lstNewOrder)

        txtSelSCFm.Text = txtSCFm.Text
        txtSelSCTo.Text = txtSCTo.Text

        cmdClearAll.Enabled = True
        ''cmdSave.Enabled = True
        cmdApySCRange.Enabled = True
        cmdAppend.Enabled = False
        txtSCFm.Enabled = False
        txtSCTo.Enabled = False

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        Dim intYNC As Integer
        'Try
        '    If save_ok = False Then
        '        If Not rs_POULFILE Is Nothing Then
        '            If rs_POULFILE.Tables("RESULT").Rows.Count > 0 And bolUpdated = True Then
        '                intYNC = MsgBox("Save before clear?", MsgBoxStyle.YesNoCancel, "Clear Data")
        '                If intYNC = MsgBoxResult.Cancel Then Exit Sub
        '                If intYNC = MsgBoxResult.Yes Then
        '                    save_ok = False
        '                    'cmdSave.PerformClick()
        '                    If save_ok = False Then Exit Sub
        '                End If
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
        'lstSelDesFiles.Items.Clear()





        lstSelDesFiles.Items.Clear()
        'filSource.Items.Clear()
        rs_POULFILE = rs_POULFILE.Clone
        'grdJobSM.DataSource = Nothing
        grdNewOrder.DataSource = Nothing
        RsJobSmk2 = Nothing

        'grdJobSM.Refresh()
        cboCoCde.Enabled = True
        save_ok = False

        txtSelSCFm.Text = ""
        txtSelSCTo.Text = ""

        cmdAppend.Enabled = True
        txtSCFm.Enabled = True
        txtSCTo.Enabled = True
        cmdClearAll.Enabled = False
        'cmdSave.Enabled = False
        cmdApySCRange.Enabled = False

        cmdLeft.Enabled = False
        cmdRight.Enabled = False
        cmd_Download.enabled = False
        'chkdelall.Enabled = False
        'cmdDelAllSM.Enabled = False

        bolUpdated = False
        txtSCFm.Focus()
        txtSCFm.Select()
        g_pod_purord = ""
        g_pod_purseq = ""

        'Opt_Q.Checked = True
        'opt_opt = "Q"

        GroupBox1.Enabled = True

    End Sub

    'Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim jobno As String
    '    Dim rs As New DataSet

    '    If rs_POULFILE Is Nothing Then
    '        Exit Sub
    '    Else
    '        If rs_POULFILE.Tables("RESULT").Rows.Count <= 0 Then
    '            Exit Sub
    '        End If
    '    End If

    '    If MsgBox("Confirm to save data?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
    '        Exit Sub
    '    End If

    '    Me.Cursor = Windows.Forms.Cursors.WaitCursor

    '    'rs_POULFILE.sort = "puf_ordnoseq"

    '    jobno = ""
    '    save_ok = False

    '    gsCompany = Trim(cboCoCde.Text)
    '    Call Update_gs_Value(gsCompany)

    '    For i As Integer = 0 To rs_POULFILE.Tables("RESULT").Rows.Count - 1
    '        If Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr")) <> "" And Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr")) <> "___" Then
    '            gspStr = "sp_insert_POULFILE '" & cboCoCde.Text & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordno") & _
    '                     "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordseq") & "','" & _
    '                     rs_POULFILE.Tables("RESULT").Rows(i)("puf_jobno") & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_filepath") & _
    '                     "','" & gsUsrID & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr") & "'"

    '            gsCompany = Trim(cboCoCde.Text)
    '            Update_gs_Value(gsCompany)

    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

    '            If rtnLong <> RC_SUCCESS Then
    '                Me.Cursor = Windows.Forms.Cursors.Default
    '                MsgBox("Error on saving QCM00009 #003 sp_insert_POULFILE : " & rtnStr)
    '                Exit Sub
    '            End If
    '        End If
    '    Next

    '    MsgBox("Record Saved!")
    '    save_ok = True

    '    cmdClearAll.PerformClick()
    '    Me.Cursor = Windows.Forms.Cursors.Default
    'End Sub

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

        'lstSelDesFiles.Items.Clear()

        Dim rs_qcno_mirror As DataSet = rs_qcno.Copy()
        rs_scno_mirror = rs_scno.Copy()

        Dim _rs As DataSet = If(flg_QCM00002, rs_qcno, rs_scno)
        Dim _rs_mirror As DataSet = If(flg_QCM00002, rs_qcno_mirror, rs_scno_mirror)


        'rs_scno.Tables("RESULT").DefaultView.Sort = "ordno"
        _rs.Tables("RESULT").DefaultView.Sort = "ordno"





        'rs_scno_mirror.Filter = "pod_purord >= '" & Trim(ScFm) & "' and pod_purord <= '" & Trim(ScTo) & "'"
        'If rs_scno_mirror.recordCount > 0 Then
        '    rs_scno_mirror.MoveFirst()
        '    While Not rs_scno_mirror.EOF
        '        grdNewOrder.SelBookmarks.Add(rs_scno_mirror.bookmark)
        '        rs_scno.bookmark = rs_scno_mirror.bookmark
        '        rs_scno.Fields(0) = "Y"
        '        rs_scno_mirror.MoveNext()
        '    End While

        '    rs_scno_mirror.MovePrevious()

        '    'lstSelDesFiles.Clear()
        '    rs_POULFILE.Filter = ""
        '    If rs_POULFILE.recordCount > 0 Then rs_POULFILE.MoveFirst()
        '    If Not rs_POULFILE.EOF Then
        '        Do While Not rs_POULFILE.EOF
        '            If rs_POULFILE("puf_ordno") = rs_scno_mirror.Fields("pod_purord") And rs_POULFILE("puf_ordseq") = rs_scno_mirror.Fields("pod_purseq") Then
        '                If rs_POULFILE("puf_creusr") <> "DEL" And rs_POULFILE("puf_creusr") <> "NEW" Then
        '                    'lstSelDesFiles.AddItem(rs_POULFILE("puf_filepath"))
        '                End If
        '            End If
        '            rs_POULFILE.MoveNext()
        '        Loop
        '    End If
        '    rs_POULFILE.Filter = ""

        '    rs_scno_mirror.MoveNext()
        'End If

        Dim dr() As DataRow
        'rs_scno_mirror.Tables("RESULT").DefaultView.RowFilter = "ordno >= '" & Trim(ScFm) & "' and ordno <= '" & Trim(ScTo) & "'"
        _rs_mirror.Tables("RESULT").DefaultView.RowFilter = "ordno >= '" & Trim(ScFm) & "' and ordno <= '" & Trim(ScTo) & "'"

        If _rs_mirror.Tables("RESULT").DefaultView.Count > 0 Then
            'If rs_scno_mirror.Tables("RESULT").DefaultView.Count > 0 Then
            'rs_scno.Tables("RESULT").Columns("pod_sel").ReadOnly = False
            _rs.Tables("RESULT").Columns("pod_sel").ReadOnly = False
            '            For i As Integer = 0 To rs_scno_mirror.Tables("RESULT").DefaultView.Count - 1
            For i As Integer = 0 To _rs_mirror.Tables("RESULT").DefaultView.Count - 1
                For j As Integer = 0 To grdNewOrder.Rows.Count - 1
                    'If grdNewOrder.Rows(j).Cells("ordno").Value = rs_scno_mirror.Tables("RESULT").DefaultView(i)("ordno").ToString Then
                    If grdNewOrder.Rows(j).Cells("ordno").Value = _rs_mirror.Tables("RESULT").DefaultView(i)("ordno").ToString Then
                        grdNewOrder.Rows(j).Cells("pod_sel").Value = "Y"
                        grdNewOrder.Rows(j).Selected = True

                        'lstSelDesFiles.Items.Clear()
                        dr = Nothing
                        'dr = rs_POULFILE.Tables("RESULT").Select("puf_ordno = '" & rs_scno_mirror.Tables("RESULT").DefaultView(i)("ordno") & "' and puf_ordseq = '" & rs_scno_mirror.Tables("RESULT").DefaultView(i)("ordseq") & "'")
                        dr = rs_POULFILE.Tables("RESULT").Select("puf_ordno = '" & _rs_mirror.Tables("RESULT").DefaultView(i)("ordno") & "' and puf_ordseq = '" & _rs_mirror.Tables("RESULT").DefaultView(i)("ordseq") & "'")
                        If dr.Length > 0 Then
                            For k As Integer = 0 To dr.Length - 1
                                If dr(k).Item("puf_creusr") <> "DEL" And dr(k).Item("puf_creusr") <> "NEW" Then
                                    'lstSelDesFiles.Items.Add(dr(k).Item("puf_filepath"))
                                End If
                            Next
                        End If
                    End If
                Next
            Next
            'rs_scno.Tables("RESULT").Columns("pod_sel").ReadOnly = True
            _rs.Tables("RESULT").Columns("pod_sel").ReadOnly = True
        End If

        'grdNewOrder.ClearSelection()

        '        Call showfiles()
        lstSelDesFiles.Items.Clear()

    End Sub

    Private Sub cmdLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeft.Click
        Dim cont As Boolean
        Dim bshpmrk As Boolean
        Dim intCount As Long
        Dim apos As Integer
        Dim timegenfolder(0) As String
        Dim dategenfolder(0) As String
        Static start_time As Date
        Dim stop_time As Date
        Dim strRmk As String

        Dim FilCount As Integer   '*** Number of file copied or moved
        Dim ExpCount As Integer   '*** Number of exceptions
        Dim numOfPrompt As Integer
        Dim errOccur As Integer    '*** At least 1 error has occur during the iterations
        Dim numOfExistFile As Integer
        Dim strLocSrcFolder As String '*** Variable for source folder
        Dim strLocDesFolder As String
        Dim tmp As String
        Dim subDir As String      '*** Current sub-directory
        Dim found As Boolean      '*** Found or not?
        Dim bolFileExist As Boolean
        Dim message As String
        Dim TmpItmNo As String

        Dim revFilName As String  '*** Filename revised
        Dim confirm As Integer
        Dim destpth As String     '*** high res. image Destination path
        Dim copyStatus As Integer


        Dim YesNoCancel As Integer

        YesNoCancel = MsgBox("Are you sure to delete the file(s)?", MsgBoxStyle.YesNoCancel)

        If YesNoCancel <> vbYes Then
            Cursor = Cursors.Default
            Exit Sub

        End If





        FilCount = 0
        numOfPrompt = 0
        errOccur = 0
        numOfExistFile = 0
        ExpCount = 0

        On Error Resume Next


        bolskipcolrowchange = True


        If lstSelDesFiles.Items.Count = 0 Then
            MsgBox("The PO and sequency has no file", MsgBoxStyle.Information, "Delete Error")
            Exit Sub
        ElseIf lstSelDesFiles.SelectedItems.Count = 0 Then
            MsgBox("No file has been selected for delete", MsgBoxStyle.Information, "Delete Error")
            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        bshpmrk = False

        Me.BringToFront()


        Dim varBmk As Object
        apos = 0

        '        grdNewOrder.ClearSelection()

        'For i As Integer = 0 To grdNewOrder.Rows.Count - 1
        '    If grdNewOrder.Rows(i).Cells("pod_sel").Value = "Y" Then
        '        grdNewOrder.Rows(i).Selected = True
        '    End If
        'Next


        If g_pod_purord = "" Then
            MsgBox("Please Click to select a PO and sequency! ")
            Exit Sub
        End If

        'If grdNewOrder.SelectedRows.Count = 0 Then
        '    'lstSelDesFiles.Items.Clear()
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    MsgBox("No order selected.")
        '    Me.Enabled = True
        '    bolskipcolrowchange = False
        '    Exit Sub
        'End If

        rs_POULFILE.Tables("RESULT").Columns("puf_creusr").ReadOnly = False



        For j As Integer = 0 To lstSelDesFiles.SelectedItems.Count - 1

            Dim a_file As String

            For i As Integer = 0 To rs_POULFILE.Tables("RESULT").Rows.Count - 1
                If rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordno").ToString = g_pod_purord _
                And rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordseq").ToString = g_pod_purseq Then

                    If Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_filepath").ToString) <> "" Then
                        a_file = Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_file").ToString)
                        '                        a_file = Trim(Split(rs_POULFILE.Tables("RESULT").Rows(i)("puf_filepath").ToString, "\")(2))
                    End If

                    ''''''''''''''''''''''''''''


                    If a_file = lstSelDesFiles.SelectedItems(j) Then
                        rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr") = "DEL"
                    End If
                    ''''''''''''''''''''''''''''
                End If
            Next

        Next


        Call save_path()
        Call showfiles(g_pod_purord, g_pod_purseq)


        If flg_QCM00002 Then
            QCM00002_INIT()
        End If



        Cursor = Cursors.Default



    End Sub

    Private Sub cmdRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRight.Click
        '   Call refreshFiles("source")

        Dim cont As Boolean
        Dim bshpmrk As Boolean
        Dim intCount As Long
        Dim apos As Integer
        Dim timegenfolder(0) As String
        Dim dategenfolder(0) As String
        Static start_time As Date
        Dim stop_time As Date
        Dim strRmk As String

        Dim FilCount As Integer   '*** Number of file copied or moved
        Dim ExpCount As Integer   '*** Number of exceptions
        Dim numOfPrompt As Integer
        Dim errOccur As Integer    '*** At least 1 error has occur during the iterations
        Dim numOfExistFile As Integer
        Dim strLocSrcFolder As String '*** Variable for source folder
        Dim strLocDesFolder As String
        Dim tmp As String
        Dim subDir As String      '*** Current sub-directory
        Dim found As Boolean      '*** Found or not?
        Dim bolFileExist As Boolean
        Dim message As String
        Dim TmpItmNo As String

        Dim revFilName As String  '*** Filename revised
        Dim confirm As Integer
        Dim destpth As String     '*** high res. image Destination path
        Dim destpth_short As String
        Dim copyStatus As Integer
        Dim copyStatus_a() As Integer

        Dim YesNoCancel As Integer

        'server_QC_destpth = ""

        YesNoCancel = MsgBox("Are you sure to uplaod the file(s)?", MsgBoxStyle.YesNoCancel)

        If YesNoCancel <> vbYes Then
            Cursor = Cursors.Default
            Exit Sub

        End If





        FilCount = 0
        numOfPrompt = 0
        errOccur = 0
        numOfExistFile = 0
        ExpCount = 0

        On Error Resume Next


        bolskipcolrowchange = True


        If filSource.Items.Count = 0 Then
            MsgBox("The source directory contains no file", MsgBoxStyle.Information, "Upload Error")
            Exit Sub
        ElseIf filSource.SelectedItems.Count = 0 Then
            MsgBox("No file has been selected for upload", MsgBoxStyle.Information, "Upload Error")
            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        bshpmrk = False

        Me.BringToFront()


        Dim varBmk As Object
        apos = 0

        grdNewOrder.ClearSelection()

        For i As Integer = 0 To grdNewOrder.Rows.Count - 1
            If grdNewOrder.Rows(i).Cells("pod_sel").Value = "Y" Then
                grdNewOrder.Rows(i).Selected = True
            End If
        Next

        If grdNewOrder.SelectedRows.Count = 0 Then
            'lstSelDesFiles.Items.Clear()
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No order selected.")
            Me.Enabled = True
            bolskipcolrowchange = False
            Exit Sub
        End If

        Dim dr() As DataRow
        Dim newRow As DataRow
        rs_scno.Tables("RESULT").Columns("pod_sel").ReadOnly = False
        rs_POULFILE.Tables("RESULT").Columns("puf_creusr").ReadOnly = False

        dategenfolder(0) = DateTime.Now.ToString("yyyy") & DateTime.Now.ToString("MM")
        timegenfolder(0) = DateTime.Now.ToString("yyyyMMddHHmmss") & DateTime.Now.Millisecond.ToString.PadLeft(3, "0")
        ReDim Preserve copyStatus_a(filSource.SelectedItems.Count - 1)

        For i As Integer = 0 To grdNewOrder.SelectedRows.Count - 1

            For j As Integer = 0 To filSource.SelectedItems.Count - 1

                If i = 0 Then

                    tmpCount.Text = CStr(j + 1)
                    confirm = MsgBoxResult.Yes
                    found = True

                    'destpth = server_QC_destpth & "\" & dategenfolder(0) & "\" & timegenfolder(0)
                    destpth_short = "SZ_QCFile\QCAttachment\" & dategenfolder(0) & "\" & timegenfolder(0)
                    destpth = server_QC_destpth & "\" & destpth_short


                    copyStatus = FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.SelectedItems(j), destpth, revFilName, True, "")
                    copyStatus_a(j) = copyStatus
                    '


                    If copyStatus = 0 Or copyStatus = 3 Then
                        Me.StatusBar.Items("lblLeft").Text = "Success to upload " & defaultSource & "\" & filSource.Items(j)
                    End If

                    If copyStatus = 1 Then
                        Me.StatusBar.Items("lblLeft").Text = "Failed to copy " & defaultSource & "\" & filSource.Items(j)
                        errOccur = 1
                    End If

                    If found = True Then
                        FilCount = FilCount + 1 '*** Number of files accepted

                    ElseIf copyStatus = 1 Then
                        Me.StatusBar.Items("lblLeft").Text = "Failed to copy to " & destpth + "\" & revFilName
                        errOccur = 1
                    Else
                        Me.StatusBar.Items("lblLeft").Text = "Failed to delete " & dirSource.SelectedNode.FullPath + "\" + filSource.Items(j)
                    End If

                End If
                ''''''''''''''''''''''''''''
                If copyStatus_a(j) <> 1 Then
                    'file copy success

                    dr = Nothing
                    newRow = Nothing
                    newRow = rs_POULFILE.Tables("RESULT").NewRow
                    newRow.Item("puf_ordno") = grdNewOrder.SelectedRows(i).Cells("ordno").Value
                    newRow.Item("puf_ordseq") = grdNewOrder.SelectedRows(i).Cells("ordseq").Value
                    newRow.Item("puf_ordnoseq") = grdNewOrder.SelectedRows(i).Cells("ordno").Value & " - " & grdNewOrder.SelectedRows(i).Cells("ordseq").Value
                    'newRow.Item("puf_jobno") = grdNewOrder.SelectedRows(i).Cells("pod_jobord").Value
                    newRow.Item("puf_jobno") = ""
                    'newRow.Item("puf_filepath") = dategenfolder(0) & "\" & timegenfolder(0) & "\" & filSource.SelectedItems(j)
                    newRow.Item("puf_filepath") = destpth_short & "\" & filSource.SelectedItems(j)
                    newRow.Item("puf_file") = Trim(filSource.SelectedItems(j))
                    newRow.Item("puf_creusr") = "ADD"
                    rs_POULFILE.Tables("RESULT").Rows.Add(newRow)
                    rs_POULFILE.AcceptChanges()
                End If


            Next

            grdNewOrder.SelectedRows(i).Cells("pod_sel").Value = "N"
        Next



        rs_POULFILE.Tables("RESULT").Columns("puf_creusr").ReadOnly = True
        rs_scno.Tables("RESULT").Columns("pod_sel").ReadOnly = True

        'bolskipcolrowchange = False

        grdNewOrder.ClearSelection()

        bolUpdated = True

        Me.Cursor = Windows.Forms.Cursors.Default


        filSource.Refresh()
        strRmk = "Upload Success"


        Call save_path()

        grdNewOrder.Rows(0).Selected = True
        Call showfiles(grdNewOrder.Rows(0).Cells("ordno").Value, grdNewOrder.Rows(0).Cells("ordseq").Value)


        If flg_QCM00002 Then
            QCM00002_INIT()
        End If


        Me.Cursor = Cursors.Default

    End Sub

    'Private Sub cmdDelAllSM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 'cmdDelAllSM.Click
    '    'chkdelall.Checked = True
    '    cmdRight.PerformClick()
    '    'chkdelall.Checked = False
    'End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        getDefault_Path()
        'filllstSelDesFiles()
    End Sub

    Private Sub filllstSelDesFiles(ByVal a_file As String)
        'Dim a_file As String
        Dim tmp_found As Boolean

        If Trim(a_file) <> "" Then
            '            a_file = Trim(Split(a_file, "\")(2))

            If Trim(a_file) <> "" Then
                tmp_found = False
                For i3 As Integer = 0 To lstSelDesFiles.Items.Count - 1
                    If Trim(a_file) = lstSelDesFiles.Items(i3) Then
                        tmp_found = True
                    End If
                Next

                If Not tmp_found = True Then
                    lstSelDesFiles.Items.Add(a_file)
                End If

            End If
        End If

        'If Not Directory.Exists(gs_PDO_SMImg) Then
        '    MsgBox("Directory Not Exist!" & Environment.NewLine & gs_PDO_SMImg)
        '    Exit Sub
        'End If

        'Dim Dir As New System.IO.DirectoryInfo(gs_PDO_SMImg)
        'Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        'Dim File As System.IO.FileInfo
        ''        lstSelDesFiles.Items.Clear()
        'For Each File In Files
        '    'Add the file name to the lstFiles listbox

        'Next
        lstSelDesFiles.Sorted = True
        lstSelDesFiles.Refresh()
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
        Dim opt As String

        If Opt_H.Checked = True Then
            opt = "H"
        End If
        If Opt_Q.Checked = True Then
            opt = "Q"
        End If
        If Opt_P.Checked = True Then
            opt = "P"
        End If

        With grdNewOrder
            For i As Integer = 0 To grdNewOrder.Columns.Count - 1
                .Columns(i).Visible = True
                If opt = "H" Then
                    Select Case i
                        Case 0
                            .Columns(i).HeaderText = "Sel"
                            .Columns(i).Width = 35
                            .Columns(i).ReadOnly = True
                        Case 1
                            .Columns(i).HeaderText = "PO #"
                            .Columns(i).Width = 80
                            .Columns(i).ReadOnly = True
                        Case 3
                            .Columns(i).HeaderText = "Pri. Cust"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case 4
                            .Columns(i).HeaderText = "Sec. Cust"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case 5
                            .Columns(i).HeaderText = "Factory"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                            'Case 5
                            '    .Columns(i).HeaderText = "Job Uploaded"
                            '    .Columns(i).Width = 65
                            '    .Columns(i).ReadOnly = True
                        Case Else
                            .Columns(i).Visible = False
                    End Select
                ElseIf opt = "P" Then
                    Select Case i
                        Case 0
                            .Columns(i).HeaderText = "Sel"
                            .Columns(i).Width = 35
                            .Columns(i).ReadOnly = True
                        Case 1
                            .Columns(i).HeaderText = "PO #"
                            .Columns(i).Width = 80
                            .Columns(i).ReadOnly = True
                        Case 2
                            .Columns(i).HeaderText = "PO Seq"
                            .Columns(i).Width = 50
                            .Columns(i).Visible = True
                        Case 3
                            .Columns(i).HeaderText = "Pri. Cust"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case 4
                            .Columns(i).HeaderText = "Sec. Cust"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case 5
                            .Columns(i).HeaderText = "Factory"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case 6
                            .Columns(i).HeaderText = "Customer Item #"
                            .Columns(i).Width = 80
                            .Columns(i).ReadOnly = True
                        Case 7
                            .Columns(i).HeaderText = "Item #"
                            .Columns(i).Width = 80
                            .Columns(i).ReadOnly = True
                        Case 8
                            .Columns(i).HeaderText = "Item Desc"
                            .Columns(i).Width = 120
                            .Columns(i).ReadOnly = True
                        Case Else
                            .Columns(i).Visible = False
                    End Select
                ElseIf opt = "Q" Then
                    Select Case i
                        Case 0
                            .Columns(i).HeaderText = "Sel"
                            .Columns(i).Width = 35
                            .Columns(i).ReadOnly = True
                        Case 1
                            .Columns(i).HeaderText = "QC #"
                            .Columns(i).Width = 80
                            .Columns(i).ReadOnly = True
                        Case 3
                            .Columns(i).HeaderText = "Pri. Cust"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case 4
                            .Columns(i).HeaderText = "Sec. Cust"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case 5
                            .Columns(i).HeaderText = "Factory"
                            .Columns(i).Width = 100
                            .Columns(i).ReadOnly = True
                        Case Else
                            .Columns(i).Visible = False
                    End Select
                End If
            Next
            .ClearSelection()
        End With
    End Sub

    'Private Sub lstSelDesFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSelDesFiles.SelectedIndexChanged
    '    If chkPreview.Checked Then
    '        displayPreview()
    '    End If
    'End Sub

    'Private Sub chkPreview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreview.CheckedChanged
    '    displayPreview()
    'End Sub

    'Private Sub displayPreview()
    '    If chkPreview.Checked Then
    '        If Not lstSelDesFiles.SelectedItem Is Nothing Then
    '            imgDesFiles.Load(gs_PDO_SMImg & lstSelDesFiles.SelectedItem.ToString)
    '            imgDesFiles.SizeMode = PictureBoxSizeMode.Zoom
    '            imgDesFiles.Visible = True
    '        End If
    '    Else
    '        imgDesFiles.Image = Nothing
    '        imgDesFiles.Visible = False
    '    End If
    'End Sub

    'Private Sub imgDesFiles_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDesFiles.DoubleClick
    '    picturePreview = New QCM00009_ATH
    '    picturePreview.myOwner = Me
    '    picturePreview.ShowDialog()
    'End Sub

    Private Sub grdNewOrder_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNewOrder.CellClick
        Dim _rs As DataSet = If(flg_QCM00002, rs_qcno, rs_scno)

        If grdNewOrder.SelectedCells.Count = 1 And e.RowIndex >= 0 Then
            If grdNewOrder.CurrentCell.ColumnIndex = 0 Then
                'rs_scno.Tables("RESULT").Columns("pod_sel").ReadOnly = False
                _rs.Tables("RESULT").Columns("pod_sel").ReadOnly = False
                If grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("pod_sel").Value = "N" Then
                    grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("pod_sel").Value = "Y"
                Else
                    grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("pod_sel").Value = "N"
                End If
                'rs_scno.Tables("RESULT").Columns("pod_sel").ReadOnly = True
                _rs.Tables("RESULT").Columns("pod_sel").ReadOnly = True
                grdNewOrder.ClearSelection()
                grdNewOrder.Refresh()
                'grdNewOrder.CurrentCell.Selected = False
            End If
        End If

        Call showfiles(grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("ordno").Value, grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("ordseq").Value)
        g_pod_purord = grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("ordno").Value
        g_pod_purseq = grdNewOrder.Rows(grdNewOrder.CurrentCell.RowIndex).Cells("ordseq").Value


    End Sub

    Private Sub txtSelSCFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelSCFm.TextChanged
        txtSelSCTo.Text = txtSelSCFm.Text
    End Sub

    Private Sub grdNewOrder_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNewOrder.RowEnter
        If sender.Focused = True Then
            If e.RowIndex >= 0 Then
                'lstSelDesFiles.Items.Clear()
                Dim dr() As DataRow = rs_POULFILE.Tables("RESULT").Select("puf_ordno = '" & grdNewOrder.Rows(e.RowIndex).Cells("ordno").Value & "' and puf_ordseq = '" & grdNewOrder.Rows(e.RowIndex).Cells("ordseq").Value & "'")
                If dr.Length > 0 Then
                    For i As Integer = 0 To dr.Length - 1
                        If dr(i).Item("puf_creusr") <> "DEL" And dr(i).Item("puf_creusr") <> "NEW" Then
                            'lstSelDesFiles.Items.Add(dr(i).Item("puf_filepath"))
                        End If
                    Next
                End If

                If txtSelSCFm.Text = "" Then
                    txtSelSCFm.Text = grdNewOrder.Rows(e.RowIndex).Cells("ordno").Value
                Else
                    txtSelSCTo.Text = grdNewOrder.Rows(e.RowIndex).Cells("ordno").Value
                End If
            End If
        End If
    End Sub

    Private Sub tabFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabFrame.SelectedIndexChanged
        If tabFrame.SelectedIndex = 1 Then
            RsJobSmk2 = rs_POULFILE.Copy()
            'optUpd.Checked = True
            ShowSummary("UPD")
        End If
    End Sub


    Private Sub Data_Selection_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If optUpd.Checked = True Then
        '    ShowSummary("UPD")
        'Else
        '    ShowSummary("ALL")
        'End If
    End Sub

    Private Sub ShowSummary(ByVal mode As String)
        If RsJobSmk2 Is Nothing Then
            Exit Sub
        End If

        If mode = "UPD" Then
            RsJobSmk2.Tables("RESULT").DefaultView.RowFilter = "puf_creusr = 'ADD' or puf_creusr = 'UPD'  or puf_creusr = 'DEL'"
            If RsJobSmk2.Tables("RESULT").DefaultView.Count > 0 Then
                RsJobSmk2.Tables("RESULT").DefaultView.Sort = "puf_ordnoseq,puf_filepath,puf_creusr"
            End If
        ElseIf mode = "ALL" Then
            RsJobSmk2.Tables("RESULT").DefaultView.RowFilter = ""
            If RsJobSmk2.Tables("RESULT").DefaultView.Count > 0 Then
                RsJobSmk2.Tables("RESULT").DefaultView.Sort = "puf_ordnoseq,puf_filepath,puf_creusr"
            End If
        End If

        'grdJobSM.DataSource = RsJobSmk2.Tables("RESULT").DefaultView
        'Display_grdJobSM()
    End Sub

    'Private Sub Display_grdJobSM()
    '    With grdJobSM
    '        For i As Integer = 0 To grdJobSM.Columns.Count - 1
    '            .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
    '            Select Case i
    '                Case 3
    '                    .Columns(i).HeaderText = "SC # with Seq."
    '                    .Columns(i).Width = 200
    '                    .Columns(i).ReadOnly = True
    '                Case 5
    '                    .Columns(i).HeaderText = "Transport Ship Mark"
    '                    .Columns(i).Width = 200
    '                    .Columns(i).ReadOnly = True
    '                Case 6
    '                    .Columns(i).HeaderText = "Update Flag"
    '                    .Columns(i).Width = 100
    '                    .Columns(i).ReadOnly = True
    '                Case Else
    '                    .Columns(i).Visible = False
    '            End Select
    '        Next
    '    End With
    'End Sub

    Private Sub grdNewOrder_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdNewOrder.Sorted
        sender.ClearSelection()
    End Sub

    Private Sub imgDesFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grpMaintenance_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpMaintenance.Enter

    End Sub


    'Private Sub AddDirectories(ByVal Node As TreeNode)
    '    Try
    '        'Construct a DirectoryInfo object of Node.filSourcePath
    '        Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)
    '        'Construct a DirectoryInfo object array of all the 
    '        '    folders inside Node.filSourcePath.

    '        Dim Folders As System.IO.DirectoryInfo

    '        For Each Folders In Dir.GetDirectories
    '            ' Add node for the directory.
    '            Dim NewNode As New TreeNode(Folders.Name)
    '            Node.Nodes.Add(NewNode)
    '            NewNode.Nodes.Add("*")
    '        Next
    '        'MsgBox(dirNode.filSourcePath)
    '    Catch
    '        'This error trap prevents a crash when attempting 
    '        '    to access restricted folders.
    '    End Try
    'End Sub

    '    Private Sub 'cmdCopyMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 'cmdCopyMove.Click
    '        If validPath = False Then
    '            MsgBox("Source Directory - " & defaultSource & " or destination directory - " & defaultDest & " not found, no upload will be processed, please consult system administrator.")
    '            Exit Sub
    '        End If

    '        If MsgBox("Upload images under the selected folder?", MsgBoxStyle.YesNo, "Image Upload Confirmation") = MsgBoxResult.No Then
    '            Exit Sub
    '        End If

    '        If filSource.Items.Count = 0 Then
    '            MsgBox("The source directory contains no image", MsgBoxStyle.Information, "Upload Error")
    '            Exit Sub
    '        ElseIf filSource.SelectedItems.Count = 0 Then
    '            MsgBox("No file has been selected for upload", MsgBoxStyle.Information, "Upload Error")
    '            Exit Sub
    '        End If

    '        Static start_time As Date
    '        Dim stop_time As Date
    '        Dim strRmk As String

    '        Dim FilCount As Integer   '*** Number of file copied or moved
    '        Dim ExpCount As Integer   '*** Number of exceptions
    '        Dim numOfPrompt As Integer
    '        Dim errOccur As Integer    '*** At least 1 error has occur during the iterations
    '        Dim numOfExistFile As Integer
    '        Dim strLocSrcFolder As String '*** Variable for source folder
    '        Dim strLocDesFolder As String
    '        Dim tmp As String
    '        Dim subDir As String      '*** Current sub-directory
    '        Dim found As Boolean      '*** Found or not?
    '        Dim bolFileExist As Boolean
    '        Dim message As String
    '        Dim TmpItmNo As String

    '        Dim revFilName As String  '*** Filename revised
    '        Dim confirm As Integer
    '        Dim destpth As String     '*** high res. image Destination path
    '        Dim copyStatus As Integer

    '        FilCount = 0
    '        numOfPrompt = 0
    '        errOccur = 0
    '        numOfExistFile = 0
    '        ExpCount = 0
    '        'lblOther.Text = "0"
    '        'lblDup.Text = "0"
    '        'lblNumFil.Text = "0"
    '        'lblExcept.Text = "0"

    '        'txtLog.Text = "Copying Files from " & dirSource.SelectedNode.FullPath & " to " & 'drvDest.Text & Environment.NewLine & _
    '        '                        "=================================================================================================" & Environment.NewLine
    '        start_time = DateTime.Now

    '        strLocSrcFolder = BaseName(dirSource.SelectedNode.FullPath, "\")
    '        Dim tmpMth As String = "0" & Date.Now.Month.ToString
    '        Dim tmpDay As String = "0" & Date.Now.Day.ToString
    '        strLocDesFolder = strLocSrcFolder & "_(" & Date.Now.Year.ToString & tmpMth.Substring(tmpMth.Length - 2, 2) & tmpDay.Substring(tmpDay.Length - 2, 2) & ")"

    '        Dim rs_insert As New DataSet

    '        For i As Integer = 0 To filSource.Items.Count - 1
    '            If filSource.SelectedIndices.Contains(i) Then
    '                tmpCount.Text = CStr(i + 1)

    '                '*** Revised the image file name
    '                revFilName = filSource.Items(i)
    '                revFilName = Replace(revFilName, "-", "_")
    '                revFilName = Replace(revFilName, " ", "")

    '                '*** Determine the image sub-folder name
    '                tmp = revFilName
    '                subDir = ""
    '                confirm = MsgBoxResult.Yes
    '                found = True
    '                subDir = itmExist(tmp) '*** Decide the sub-folder name

    '                If subDir <> expItem Then
    '                    destpth = 'dirDest.SelectedNode.FullPath & IIf('dirDest.SelectedNode.FullPath.Substring('dirDest.SelectedNode.FullPath.Length - 1, 1) = "\", "", "\") & subDir
    '                Else
    '                    lblStatus.Text = "Item (" & tmp & ") not exist in Item Master!"
    '                    'txtLog.Text = 'txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
    '                    errOccur = 1

    '                    If UCase(dirSource.SelectedNode.FullPath.Substring(0, defaultSourceExp.Length)) <> UCase(defaultSourceExp) Then
    '                        destpth = defaultSourceExp & IIf(defaultSourceExp.Substring(defaultSourceExp.Length - 1) = "\", "", "\") & strLocDesFolder
    '                        found = True
    '                    Else
    '                        confirm = MsgBoxResult.No
    '                    End If
    '                End If

    '                If dirSource.SelectedNode.FullPath = destpth Then
    '                    lblStatus.Text = "Failed to upload " & defaultSource & "\" & filSource.Items(i)
    '                    'txtLog.Text = 'txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") + "  " & lblStatus.Text & Environment.NewLine & _
    '                                  "(Source and Destination Folders are the same)" & Environment.NewLine
    '                    confirm = MsgBoxResult.No
    '                End If

    '                '*** Start to copy or move the file to the destination folder
    '                'If confirm = vbYes And chkPrompt.Value = 1 Then
    '                bolFileExist = False
    '                If confirm = MsgBoxResult.Yes Then
    '                    If Dir(destpth + "\" + revFilName) <> "" Then '*** If file is existed
    '                        If 'chkOverwrite.Checked = False Then
    '                            bolFileExist = True
    '                            message = "Are you sure to replace low res. image " & Environment.NewLine & _
    '                                      "'" & destpth & "\" & revFilName & "'" & Environment.NewLine & _
    '                                      "File Size: " & Format(FileLen(destpth & "\" & revFilName), "##,###") & " KB " & Environment.NewLine & _
    '                                      "Last Modified On: " & Format(FileDateTime(destpth & "\" & revFilName), "MM/dd/yyyy HH:mm:ss") & "with" & Environment.NewLine & _
    '                                      "'" & dirSource.SelectedNode.FullPath & filSource.Items(i) & "'" & Environment.NewLine & _
    '                                      "File Size: " & Format(FileLen(dirSource.SelectedNode.FullPath & "\" & filSource.Items(i)), "##,###") & " KB " & Environment.NewLine & _
    '                                      "Last Modified On: " & Format(FileDateTime(dirSource.SelectedNode.FullPath + "\" + filSource.Items(i)), "MM/dd/yyyy HH:mm:ss") & "?"
    '                            confirm = MsgBox(message, MsgBoxStyle.YesNoCancel, "Overwrite Prompt")
    '                        Else
    '                            confirm = MsgBoxResult.Yes
    '                        End If

    '                        If confirm = MsgBoxResult.Yes Then
    '                            numOfExistFile = numOfExistFile + 1
    '                            'lblDup.Text = CStr(numOfExistFile)
    '                        End If
    '                    End If
    '                End If

    '                If confirm = MsgBoxResult.Cancel Then
    '                    strRmk = "Cancel By User"
    '                    GoTo jump
    '                End If

    '                If confirm = MsgBoxResult.Yes Then
    '                    lblStatus.Text = "Copying file " & Trim(Str(i + 1)) & ": " & destpth & "\" & revFilName

    '                    If found = True Then
    '                        copyStatus = FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), destpth, revFilName, True, _
    '                            defaultSourceUploaded & IIf(defaultSourceUploaded.Substring(defaultSourceUploaded.Length - 1, 1) = "\", "", "\") & strLocDesFolder)
    '                    Else
    '                        copyStatus = FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), destpth, revFilName, True, "")
    '                    End If

    '                    If copyStatus = 0 Or copyStatus = 3 Then
    '                        If found = True Then
    '                            lblStatus.Text = "Success to upload " & defaultSource & "\" & filSource.Items(i)
    '                            'txtLog.Text = 'txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
    '                        End If

    '                        If copyStatus = 3 Then
    '                            lblStatus.Text = "Failed to copy " & defaultSource & "\" & filSource.Items(i)
    '                            'txtLog.Text = 'txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
    '                            errOccur = 1
    '                        End If

    '                        If found = True Then
    '                            FilCount = FilCount + 1 '*** Number of files accepted

    '                            TmpItmNo = Replace(filSource.Items(i), " ", "")
    '                            TmpItmNo = Replace(TmpItmNo, "-", "_")
    '                            TmpItmNo = Replace(TmpItmNo, ".JPG", "")
    '                            TmpItmNo = Replace(TmpItmNo, ".jpg", "")
    '                            TmpItmNo = Replace(TmpItmNo, "/", "_")
    '                            TmpItmNo = Replace(TmpItmNo, "\", "")

    '                            gspStr = "sp_insert_IMAGE_UPLOAD '','" & filSource.Items(i) & "','" & destpth & "\" & revFilName & _
    '                                     "','" & IIf(bolFileExist = True, "Y", "N") & "','" & gsUsrID & "','" & _
    '                                     IIf(cboCoCde.Text = strInternal, "I", "E") & "'"

    '                            Me.Cursor = Windows.Forms.Cursors.WaitCursor

    '                            rtnLong = execute_SQLStatement(gspStr, rs_insert, rtnStr)

    '                            Me.Cursor = Windows.Forms.Cursors.Default

    '                            If rtnLong <> RC_SUCCESS Then
    '                                lblStatus.Text = "Failed to update image info (" & filSource.Items(i) & ") to IM"
    '                                'txtLog.Text = 'txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
    '                                errOccur = 1
    '                                'cmdCopyMove.Enabled = True
    '                                MsgBox("Error on inserting IMG00002 #002 sp_insert_IMAGE_UPLOAD : " & rtnStr)
    '                                strRmk = "Cannot Update Image Path/Save Upload Record, Exist"
    '                                GoTo jump
    '                            End If

    '                            lblStatus.Text = "Success to update image info (" & filSource.Items(i) & ") to IM"
    '                            'txtLog.Text = 'txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
    '                        Else
    '                            ExpCount = ExpCount + 1 '*** Number of files excepted
    '                        End If
    '                    ElseIf copyStatus = 1 Then
    '                        lblStatus.Text = "Failed to copy to " & destpth + "\" & revFilName
    '                        'txtLog.Text = 'txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
    '                        errOccur = 1
    '                    Else
    '                        lblStatus.Text = "Failed to delete " & dirSource.SelectedNode.FullPath + "\" + filSource.Items(i)
    '                        'txtLog.Text = 'txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
    '                        errOccur = 1
    '                    End If
    '                End If
    '            End If
    '        Next
    '        filSource.Refresh()
    '        strRmk = "Upload Success"

    'jump:
    '        '*** Refresh the source and destination
    '        'cmdRefresh.PerformClick()
    '        'lblNumFil.Text = CStr(FilCount)
    '        'lblExcept.Text = CStr(ExpCount)
    '        'lblOther.Text = CInt(Trim('lblNumFilSource.Text)) - CInt('lblNumFil.Text) - CInt('lblExcept.Text) - CInt('lblDup.Text)

    '        stop_time = DateTime.Now

    '        If (stop_time - start_time).TotalSeconds >= 1 Then
    '            Call Image_upload_audit(strRmk, (stop_time - start_time).TotalSeconds)
    '        Else
    '            Call Image_upload_audit(strRmk, 0)
    '        End If

    '        'cmdCopyMove.Enabled = True
    '        lblStatus.Text = "File Copied"
    '    End Sub

    Private Function getPath() As String

        Dim S As String
        appPath = ""

        Try
            Using sr As New StreamReader("path.ini")
                While sr.Peek <> -1
                    'S = sr.ReadToEnd().ToString
                    S = sr.ReadLine().ToString

                    If S.IndexOf(" = ") > 0 Then
                        If gsCompanyGroup = "MSG" Then
                            Select Case S.Substring(0, S.IndexOf(" = ")).ToUpper
                                Case "MS_EXT_IMG_PATH"
                                    gstrExtImgPath = Trim(Split(S, " = ")(1))
                                Case "MS_INT_IMG_PATH"
                                    gstrIntImgPath = Trim(Split(S, " = ")(1))
                                Case "UPLOADED_PATH"
                                    appPath = Trim(Split(S, " = ")(1))
                            End Select
                        Else
                            Select Case UCase(Split(S, " = ")(0))
                                Case "EXT_IMG_PATH"
                                    gstrExtImgPath = Trim(Split(S, " = ")(1))
                                Case "INT_IMG_PATH"
                                    gstrIntImgPath = Trim(Split(S, " = ")(1))
                                Case "UPLOADED_PATH"
                                    appPath = Trim(Split(S, " = ")(1))
                            End Select
                        End If
                    End If

                End While
            End Using
        Catch ex As Exception
            MsgBox("Unable to determine file path: path.ini")
            Return False
        End Try

        If gstrExtImgPath = "" Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "EXT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If gstrIntImgPath = "" Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "INT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If Not Directory.Exists(gstrExtImgPath) Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "EXT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If Not Directory.Exists(gstrIntImgPath) Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "INT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        Return True
    End Function

    Private Sub setDefault()
        If rs_SYUSRPRF.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_SYUSRPRF.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        For i As Integer = 0 To rs_SYUSRPRF.Tables("RESULT").Rows.Count - 1
            If rs_SYUSRPRF.Tables("RESULT").Rows(i)("yuc_flgdef") = "Y" Then
                If rs_SYUSRPRF.Tables("RESULT").Rows(i)("yuc_cocde") = "UCP" Then
                    cboCoCde.Text = strExternal
                Else
                    cboCoCde.Text = strInternal
                End If
                setCompany()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub setCompany()
        serverName = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.IndexOf("\") + 1)
        If appPath <> "" Then
            serverName = IIf(appPath.Substring(appPath.Length - 1, 1) = "\", appPath.Substring(0, appPath.Length - 1), appPath)
        End If

        If cboCoCde.Text = strInternal Then
            defaultSource = serverName & "\Image_Upload\Internal_and_Joint_Venture"
            defaultSourceUpload = defaultSource & "\Upload"
            defaultSourceUploaded = defaultSource & "\Uploaded"
            defaultSourceExp = defaultSource & "\ExpItem"
            defaultDest = gstrIntImgPath
        ElseIf cboCoCde.Text = strExternal Then
            defaultSource = serverName & "\Image_Upload\External"
            defaultSourceUpload = defaultSource & "\Upload"
            defaultSourceUploaded = defaultSource & "\Uploaded"
            defaultSourceExp = defaultSource & "\ExpItem"
            defaultDest = gstrExtImgPath
        End If

        validPath = True

        'optUploadImgFolder.PerformClick()
    End Sub

    'Private Sub optOper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 'optUploadImgFolder.Click, optExceptImgFolder.Click
    '    Dim strSrcTgc As String

    '    If 'optUploadImgFolder.Checked = True Then
    '        If goBack = True Then
    '            strSrcTgc = "src"
    '            drvSource.SelectedIndex = drvSource.Items.IndexOf(defaultSourceUpload.Substring(0, defaultSourceUpload.IndexOf("\\") + 1))
    '            dirSource.Nodes(0).Expand()
    '            dirSource.SelectedNode = getNode(parsePath(defaultSourceUpload & "\", True), dirSource.Nodes, True)

    '            If dirSource.SelectedNode Is Nothing Then
    '                MsgBox("Source Directory '" & defaultSourceUpload & "\' Not Found!")
    '                validPath = False
    '                checkValidPath()
    '            Else
    '                validPath = True
    '            End If
    '        End If
    '        strSrcTgc = "tgc"
    '        'drvDest.Items.Clear()
    '        'drvDest.Items.Add(defaultDest)
    '        'drvDest.SelectedIndex = 'drvDest.Items.IndexOf(defaultDest)
    '    ElseIf optExceptImgFolder.Checked = True Then
    '        If goBack = True Then
    '            strSrcTgc = "src"
    '            drvSource.SelectedIndex = drvSource.Items.IndexOf(defaultSourceExp.Substring(0, defaultSourceExp.IndexOf("\\") + 1))
    '            dirSource.Nodes(0).Expand()
    '            dirSource.SelectedNode = getNode(parsePath(defaultSourceExp & "\", True), dirSource.Nodes, True)

    '            If dirSource.SelectedNode Is Nothing Then
    '                MsgBox("Source Directory '" & defaultSourceExp & "\' Not Found!")
    '                validPath = False
    '                checkValidPath()
    '            Else
    '                validPath = True
    '            End If
    '        End If
    '        strSrcTgc = "tgc"
    '        'drvDest.Items.Clear()
    '        'drvDest.Items.Add(defaultDest)
    '        'drvDest.SelectedIndex = 'drvDest.Items.IndexOf(defaultDest)
    '    End If
    'End Sub

    Private Sub checkValidPath()
        If validPath = False Then
            drvSource.Enabled = False
            dirSource.Enabled = False
            filSource.Enabled = False
            'drvDest.Enabled = False
            'dirDest.Enabled = False
            'filDest.Enabled = False
            'cmdDefSource.Enabled = False
            'cmdRefresh.Enabled = False
            'chkOverwrite.Enabled = False
            'cmdCopyMove.Enabled = False
            'chkView.Enabled = False
            'chkViewCont.Enabled = False
            'cmdRefreshLst.Enabled = False
            cmdSelectAll.Enabled = False
            cboCoCde.Enabled = False
            'grpFolders.Enabled = False
            'chkOverwrite.Checked = False
            'chkView.Checked = False
            'chkViewCont.Checked = False
        End If
    End Sub

    Private Sub drvSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drvSource.TextChanged

        Cursor.Current = Cursors.WaitCursor
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        Cursor.Current = Cursors.Default

        lbl_dir.Text = drvSource.Text

        Try
            dirSource.Nodes(0).Expand()
            filSourcePath = drvSource.Text
            dirSource.SelectedNode = dirSource.Nodes(0)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dirSource_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles dirSource.BeforeExpand

        If e.Node.Nodes(0).Text = "*" Then
            ' Disable redraw.
            dirSource.SelectedNode = e.Node
            dirSource.BeginUpdate()

            e.Node.Nodes.Clear()
            AddDirectories(e.Node)

            ' Enable redraw.
            dirSource.EndUpdate()

        End If

        expandDir(True, e.Node)
    End Sub



    Private Sub expandDir(ByVal src As Boolean, ByVal node As TreeNode)
        'Construct a DirectoryInfo object of 
        '    the selected Node.
        Dim Dir As New  _
            System.IO.DirectoryInfo(node.FullPath)
        'Construct a FileInfo object array of all the 
        '    files inside e.Node.filSourcePath that match
        '    FilePattern.
        On Error GoTo FILE_ACCESS_ERROR
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)
        'filSourcePath = Dir.FullName

        'Create a FileInfo object (File) for the 
        '    For-Each loop and clear the lstFiles 
        '    listbox before filling it.
        Dim File As System.IO.FileInfo

        If src = True Then
            filSource.Items.Clear()
            For Each File In Files
                'Add the file name to the lstFiles listbox
                filSource.Items.Add(File.Name)
            Next

            filSourcePath = node.FullPath
            'lblNumFilSource.Text = filSource.Items.Count
        Else
            'filDest.Items.Clear()
            For Each File In Files
                'Add the file name to the lstFiles listbox
                'filDest.Items.Add(File.Name)
            Next
        End If

        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")
    End Sub

    Private Sub AddDirectories(ByVal Node As TreeNode)
        Try
            'Construct a DirectoryInfo object of Node.filSourcePath
            Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)
            'Construct a DirectoryInfo object array of all the 
            '    folders inside Node.filSourcePath.

            Dim Folders As System.IO.DirectoryInfo

            For Each Folders In Dir.GetDirectories
                ' Add node for the directory.
                Dim NewNode As New TreeNode(Folders.Name)
                Node.Nodes.Add(NewNode)
                NewNode.Nodes.Add("*")
            Next
            'MsgBox(dirNode.filSourcePath)
        Catch
            'This error trap prevents a crash when attempting 
            '    to access restricted folders.
        End Try
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For i As Integer = 0 To filSource.Items.Count - 1
            filSource.SetSelected(i, True)
        Next
    End Sub



    Private Function parsePath(ByVal path As String, ByVal src As Boolean) As ArrayList
        Dim nodeTree As New ArrayList
        If src = True Then
            nodeTree.Add(drvSource.Text)
            path = path.Substring(drvSource.Text.Length + 1, path.Length - drvSource.Text.Length - 1)
        Else
            'path = Replace(path, "\\", "")
            'nodeTree.Add("\\" & path.Substring(0, path.IndexOf("\")))
            'nodeTree.Add('drvDest.Text)
            'path = path.Substring('drvDest.Text.Length + 1, path.Length - 'drvDest.Text.Length - 1)
            'path = path.Substring(nodeTree.Item(nodeTree.Count - 1).length, path.Length - nodeTree.Item(nodeTree.Count - 1).length)
        End If
        Dim temp As String
        While (path.IndexOf("\") < path.Length And path.IndexOf("\") <> -1)
            temp = path.Substring(0, path.IndexOf("\"))
            nodeTree.Add(temp)
            path = path.Substring(temp.Length + 1, path.Length - temp.Length - 1)
        End While
        Return nodeTree
    End Function

    Private Function getNode(ByVal list As ArrayList, ByVal nodes As TreeNodeCollection, ByVal source As Boolean) As TreeNode
        For i As Integer = 0 To nodes.Count - 1
            If nodes(i).Text = list.Item(0) Then
                nodes(i).Expand()
                list.RemoveAt(0)
                getNode = nodes(i)
                If list.Count > 0 Then
                    getNode = getNode(list, nodes(i).Nodes, True)
                End If
                Return getNode
            End If
        Next
    End Function




    Private Sub filSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filSource.SelectedIndexChanged
    End Sub

    'Private Sub pBxImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pBxImage.DoubleClick
    '    If filSource.SelectedItem Is Nothing Then
    '        Exit Sub
    '    End If

    '    Try
    '        frmImage.pbImage.Load(dirSource.SelectedNode.FullPath & "\" & filSource.SelectedItem.ToString)
    '    Catch ex As Exception

    '    End Try

    '    frmImage.ShowDialog()
    'End Sub

    Private Function BaseName(ByVal str As String, ByVal strDelimiter As String) As String
        On Error GoTo Err_No_Deliminator
        If str.Substring(str.Length - 1, 1) = "\" Then
            str = str.Substring(0, str.Length - 1)
        End If
        BaseName = Trim(Split(str, strDelimiter)(UBound(Split(str, strDelimiter))))
        Exit Function
Err_No_Deliminator:
        BaseName = ""
        Err.Clear()
    End Function

    Private Function itmExist(ByVal TmpItmNo As String) As String
        '*** Distribute the item images to appropriate folders
        '*** Return the sub-folder name if exist; else return the subfolder for exception
        Dim rs As New DataSet

        TmpItmNo = Replace(TmpItmNo, " ", "")
        TmpItmNo = Replace(TmpItmNo, "-", "_")
        TmpItmNo = Replace(TmpItmNo, ".JPG", "")
        TmpItmNo = Replace(TmpItmNo, ".jpg", "")
        TmpItmNo = Replace(TmpItmNo, "/", "_")
        TmpItmNo = Replace(TmpItmNo, "\", "")

        gspStr = "sp_select_IMAGE_UPLOAD '','" & TmpItmNo & "','" & IIf(cboCoCde.Text = strInternal, "I", "E")

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMG00001 #001 sp_select_IMAGE_UPLOAD : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Return ""
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            If cboCoCde.Text = strInternal Then
                itmExist = Replace(Replace(Replace(rs.Tables("RESULT").Rows(0)("ibi_lnecde"), " ", ""), "-", "_"), "/", "_")
            Else
                itmExist = Replace(Replace(Replace(rs.Tables("RESULT").Rows(0)("ibi_venno"), " ", ""), "-", "_"), "/", "_")
            End If
        Else
            itmExist = expItem  '*** Exception
        End If

        If itmExist = "" Then
            '*** The UCPP line code or the UCP vendor code has not been etnered yet
            itmExist = expItem  '*** Exception
        End If
    End Function



    Private Sub Image_upload_audit(ByVal strRmk As String, ByVal elpTime As Double)
        Dim rs As New DataSet
        Dim ttlimg As Integer
        Dim cpyimg As Integer
        Dim expimg As Integer
        Dim dupimg As Integer
        Dim otherimg As Integer
        Dim lastimg As Integer


        'ttlimg = CInt(Trim(IIf('lblNumFilSource.Text = "", "0", 'lblNumFilSource.Text)))
        'cpyimg = CInt(Trim(IIf('lblNumFil.Text = "", "0", 'lblNumFil.Text)))
        'expimg = CInt(Trim(IIf('lblExcept.Text = "", "0", 'lblExcept.Text)))
        'dupimg = CInt(Trim(IIf('lblDup.Text = "", "0", 'lblDup.Text)))
        'otherimg = CInt(Trim(IIf('lblOther.Text = "", "0", 'lblOther.Text)))
        lastimg = CInt(Trim(IIf(tmpCount.Text = "", "0", tmpCount.Text)))

        gspStr = "sp_insert_Image_Upload_aud '','" & ttlimg & "','" & cpyimg & "','" & expimg & "','" & dupimg & "','" & _
                 otherimg & "','" & lastimg & "','" & elpTime & "','" & strRmk & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on inserting IMG00002 #003 sp_insert_Image_Upload_aud : " & rtnStr)
            Exit Sub
        End If

    End Sub

    Private Function FileCopy_Move(ByVal sourcepth As String, ByVal sourcefil As String, _
                           ByVal destpth As String, ByVal destfil As String, _
                           ByVal Move As Boolean, ByVal uploadpath As String, Optional ByVal flag1 As Boolean = True) As Integer
        Dim strDate As String


        If flag1 Then
            sourcepth = Replace(sourcepth, "\\", "\") 'Some Case when using remote ip, it sucks. E.g. \\192.168.1.x => \192.168.1.x
        End If

        If Dir(destpth, vbDirectory) = "" Then
            MkDir(destpth)
        End If
        '*** Copy the file from source folder to destination folder
        On Error GoTo on_Error_Filecopy_Move1
        '****    Add for check file exist of not while copy file by Lewis on 20 May 2003 ***********************
        If Dir(destpth, vbDirectory) <> "" Then
            File.Copy(sourcepth & "\" & sourcefil, destpth & "\" & sourcefil, True)
            '            FileCopy(sourcepth & "\" & sourcefil, destpth & "\" & destfil)
            On Error GoTo 0
        End If

        If uploadpath <> "" Then
            On Error GoTo on_Error_Filecopy_Move3
            If Dir(uploadpath, vbDirectory) = "" Then
                MkDir(uploadpath)
            End If
            If Dir(uploadpath, vbDirectory) <> "" Then
                FileCopy(sourcepth & "\" & sourcefil, uploadpath & "\" & sourcefil)
                On Error GoTo 0
            End If
        End If


        '     MsgBox "From " + sourcepth + "\" + sourcefil + " to " + destpth + "\" + destfil
        '*** If the move option is on, delete the file in the source

        'If Move = True And dirSource.SelectedNode.FullPath <> uploadpath Then
        '    On Error GoTo on_Error_Filecopy_Move2
        '    Kill(dirSource.SelectedNode.FullPath & "\" & sourcefil)
        '    On Error GoTo 0
        'End If

        FileCopy_Move = 0
        Exit Function

on_Error_Filecopy_Move1:
        FileCopy_Move = 1
        MsgBox("Could not find the file!")
        Exit Function
on_Error_Filecopy_Move2:
        FileCopy_Move = 2
        Exit Function
on_Error_Filecopy_Move3:
        FileCopy_Move = 3
        Exit Function
    End Function
    Sub showfiles(ByVal the_order, ByVal the_seq)
        Dim cont As Boolean
        Dim bshpmrk As Boolean
        Dim intCount As Long
        Dim apos As Integer
        Dim timegenfolder As String
        Dim dategenfolder As String
        Static start_time As Date
        Dim stop_time As Date
        Dim strRmk As String

        Dim FilCount As Integer   '*** Number of file copied or moved
        Dim ExpCount As Integer   '*** Number of exceptions
        Dim numOfPrompt As Integer
        Dim errOccur As Integer    '*** At least 1 error has occur during the iterations
        Dim numOfExistFile As Integer
        Dim strLocSrcFolder As String '*** Variable for source folder
        Dim strLocDesFolder As String
        Dim tmp As String
        Dim subDir As String      '*** Current sub-directory
        Dim found As Boolean      '*** Found or not?
        Dim bolFileExist As Boolean
        Dim message As String
        Dim TmpItmNo As String

        Dim revFilName As String  '*** Filename revised
        Dim confirm As Integer
        Dim destpth As String     '*** high res. image Destination path
        Dim copyStatus As Integer

        FilCount = 0
        numOfPrompt = 0
        errOccur = 0
        numOfExistFile = 0
        ExpCount = 0

        On Error Resume Next
        lstSelDesFiles.Items.Clear()
        For i As Integer = 0 To rs_POULFILE.Tables("RESULT").Rows.Count - 1
            If rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordno").ToString = the_order _
            And rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordseq").ToString = the_seq _
            And rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr").ToString <> "DEL" Then
                ''''''''''''''''''''''''''''
                filllstSelDesFiles(rs_POULFILE.Tables("RESULT").Rows(i)("puf_file").ToString)
                ''''''''''''''''''''''''''''
            End If
        Next

    End Sub

    Private Sub save_path()
        Dim jobno As String
        Dim rs As New DataSet
        Dim a_file As String

        If rs_POULFILE Is Nothing Then
            Exit Sub
        Else
            If rs_POULFILE.Tables("RESULT").Rows.Count <= 0 Then
                Exit Sub
            End If
        End If



        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'rs_POULFILE.sort = "puf_ordnoseq"

        jobno = ""
        save_ok = False

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        For i As Integer = 0 To rs_POULFILE.Tables("RESULT").Rows.Count - 1

            If Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_filepath").ToString) <> "" Then
                a_file = Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_file").ToString)
                '                a_file = Trim(Split(rs_POULFILE.Tables("RESULT").Rows(i)("puf_filepath").ToString, "\")(2))
            End If


            If Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr")) = "ADD" Or Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr")) = "DEL" Then
                gspStr = "sp_insert_POULFILE '" & cboCoCde.Text & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordno") & _
                         "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordseq") & "','" & _
                         rs_POULFILE.Tables("RESULT").Rows(i)("puf_jobno") & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_filepath") & _
                         "','" & a_file & "','" & opt_opt & "','" & gsUsrID & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr") & "'"

                gsCompany = Trim(cboCoCde.Text)
                Update_gs_Value(gsCompany)

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on saving SCM00004 #003 sp_insert_SCTPSMRK : " & rtnStr)
                    Exit Sub
                End If
            End If
        Next

        MsgBox("Record and File(s) Updated!")
        save_ok = True


    End Sub
    Private Sub delete_file()
        Dim jobno As String
        Dim rs As New DataSet

        If rs_POULFILE Is Nothing Then
            Exit Sub
        Else
            If rs_POULFILE.Tables("RESULT").Rows.Count <= 0 Then
                Exit Sub
            End If
        End If



        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'rs_POULFILE.sort = "puf_ordnoseq"

        jobno = ""
        save_ok = False

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        For i As Integer = 0 To rs_POULFILE.Tables("RESULT").Rows.Count - 1
            If Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr")) <> "" And Trim(rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr")) <> "___" Then
                gspStr = "sp_insert_POULFILE '" & cboCoCde.Text & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordno") & _
                         "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_ordseq") & "','" & _
                         rs_POULFILE.Tables("RESULT").Rows(i)("puf_jobno") & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_filepath") & _
                         "','" & gsUsrID & "','" & rs_POULFILE.Tables("RESULT").Rows(i)("puf_creusr") & "'"

                gsCompany = Trim(cboCoCde.Text)
                Update_gs_Value(gsCompany)

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on saving SCM00004 #003 sp_insert_SCTPSMRK : " & rtnStr)
                    Exit Sub
                End If
            End If
        Next

        MsgBox("File(s) deleted!")
        save_ok = True


    End Sub

    Private Sub cmdRefreshLst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshLst.Click
        refreshFiles("source")
    End Sub

    Private Sub refreshFiles(ByVal location As String)
        If location = "source" Then
            If (dirSource.SelectedNode Is Nothing) Then
                MsgBox("Directory Not Selected")
                Exit Sub
            End If

            '*** Refresh the source
            filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")
        Else
            'If (dirDest.SelectedNode Is Nothing) Then
            '    MsgBox("Directory Not Selected")
            '    Exit Sub
            'End If

            '*** Refresh the source
            'filSourcePath = dirDest.SelectedNode.FullPath
        End If

        'Construct a DirectoryInfo object of 
        '    the selected Node.
        Dim Dir As New  _
            System.IO.DirectoryInfo(filSourcePath)
        'Construct a FileInfo object array of all the 
        '    files inside e.Node.filSourcePath that match
        '    FilePattern.
        Dim Files As System.IO.FileInfo() = _
                Dir.GetFiles(FilePattern)

        'Create a FileInfo object (File) for the 
        '    For-Each loop and clear the lstFiles 
        '    listbox before filling it.
        Dim File As System.IO.FileInfo

        If location = "source" Then
            filSource.Items.Clear()
            For Each File In Files
                'Add the file name to the lstFiles listbox
                filSource.Items.Add(File.Name)
            Next
            filSource.Refresh()
            lblNumFilSource.Text = filSource.Items.Count
        Else
            'filDest.Items.Clear()
            'For Each File In Files
            '    'Add the file name to the lstFiles listbox
            '    filDest.Items.Add(File.Name)
            'Next
            'filDest.Refresh()
        End If
    End Sub





    Private Sub Opt_type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opt_Q.Click, Opt_H.Click, Opt_P.Click
        Dim name As String = CType(sender, RadioButton).Name

        If name = "Opt_Q" Then
            Label3.Text = "QC From"
            opt_opt = "Q"
        ElseIf name = "Opt_H" Then
            Label3.Text = "PO From"
            opt_opt = "H"
        ElseIf name = "Opt_P" Then
            Label3.Text = "PO From"
            opt_opt = "P"
        End If


        If flg_QCM00002 Then
            QCM00002_DisplayGrid()
            txtSelSCFm.Text = grdNewOrder.Rows(0).Cells("ordno").Value
        End If



    End Sub

    Private Sub cmd_Download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Download.Click
        Cursor = Cursors.WaitCursor
        Dim tbl_file As DataTable = rs_POULFILE.Tables(0)

        Dim YesNoCancel As Integer

        YesNoCancel = MsgBox("Are you sure to download the file(s)?", MsgBoxStyle.YesNoCancel)

        If YesNoCancel <> vbYes Then
            Cursor = Cursors.Default
            Exit Sub

        End If


        Dim timegenfolder(0) As String
        Dim dategenfolder(0) As String
        dategenfolder(0) = DateTime.Now.ToString("yyyy") & DateTime.Now.ToString("MM")
        timegenfolder(0) = DateTime.Now.ToString("yyyyMMddhhmmss") & DateTime.Now.Millisecond.ToString

        Dim arr_key As String() = {"puf_ordno", "puf_ordseq", "puf_type"}
        Dim key_tbl As DataTable = tbl_file.DefaultView.ToTable(True, arr_key)

        For i As Integer = 0 To key_tbl.Rows.Count - 1
            Dim row As DataRow = key_tbl.Rows(i)

            Dim tmp_str As String = "puf_ordno='" & row(0) & "' And " & _
                "puf_ordseq='" & row(1) & "' And " & _
                "puf_type='" & row(2) & "'"


            Dim result_row() As DataRow = tbl_file.Select(tmp_str)

            For j As Integer = 0 To result_row.Length - 1
                Dim srcpath As String = server_QC_destpth & "\" & result_row(j).Item("puf_filepath")
                Dim destpath As String = "C:\QCAttach\" & timegenfolder(0) & "\" & result_row(j).Item("puf_ordno")


                Dim token As String() = Split(srcpath, result_row(j).Item("puf_file"))

                FileCopy_Move(token(0), result_row(j).Item("puf_file"), destpath, result_row(j).Item("puf_file"), False, "", False)

                'FileCopy_Move(srcpath, 

            Next
        Next


        MsgBox("Download Success." & vbCrLf & "Dirctory: " & "C:\QCAttach\" & timegenfolder(0) & "\")

        Cursor = Cursors.Default
    End Sub

    Private Sub dirSource_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles dirSource.AfterSelect
        lbl_dir.Text = dirSource.SelectedNode.FullPath
    End Sub

End Class