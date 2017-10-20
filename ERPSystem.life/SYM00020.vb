Public Class SYM00020

    Inherits System.Windows.Forms.Form

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean


    Dim EditModeHdr As String

    Dim CanModify As Boolean ' Check for access right
    Dim save_ok As Boolean

    Dim Current_TimeStamp As Long 'For current record's time stamp
    Dim Catcde_timestamp As Long

    Public rs_SYMCATCDE As DataSet

    Public save_grid As String
    Public rs_SYMCATCDE_check As DataSet
    Public level As String

    Dim Add_flag As Boolean '***Check for Add Record

    Dim Recordstatus As Boolean '***Check the Current record is modified or not
    '***This flag must used in each fields of the Scree

    Public Save_flag As Boolean '****Reject enter to RowColchange event
    Dim readingindex As Integer



    Private Sub cmdClear_Click()

        Dim YNC As Integer

        If rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            '            If rs_SYMCATCDE.EOF = True Or rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        Else

            rs_SYMCATCDE.Tables("RESULT").DefaultView.RowFilter = "ymc_creusr = " & "'" & "~*ADD*~" & "'" & _
                                       "or ymc_creusr = " & "'" & "~*UPD*~" & "'" & _
                                       "or ymc_creusr = " & "'" & "~*DEL*~" & "'" & _
                                       "or ymc_creusr = " & "'" & "~*NEW*~" & "'"

            If rs_SYMCATCDE.Tables("RESULT").DefaultView.Count > 0 Then
                rs_SYMCATCDE.Tables("RESULT").DefaultView.RowFilter = "" 'Lester Wu 2004/09/15 Restore Datagrid
                Call Display()

                YNC = MsgBox("Record modified, do you want to save before clear?", MsgBoxStyle.YesNo)
                If YNC = vbYes Then

                    If Enq_right_local = True Then
                        Call CmdSave_Click()
                        If save_ok = False Then
                            Exit Sub
                        End If
                    Else
                        MsgBox("Sorry! You do not right to save!")
                    End If

                    rs_SYMCATCDE = Nothing
                    Call Form_Load()
                    Cbolevel.Enabled = True
                ElseIf YNC = vbNo Then
                    rs_SYMCATCDE = Nothing
                    Call Form_Load()
                    Cbolevel.Enabled = True
                ElseIf YNC = vbCancel Then
                    rs_SYMCATCDE.Tables("RESULT").DefaultView.RowFilter = ""
                    'Set Grdmrkfml.DataSource = rs_SYMRKFML
                    Call Display()
                    'Cbolevel.Enabled = True
                    Exit Sub

                End If
            End If

        End If

        'goto
    End Sub

    Private Sub cmdDelRow_Click()

        If Not rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            'If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex )("ymc_creusr") = "~*ADD*~" Or rs_SYMCATCDE.Tables("RESULT").Rows(readingindex )("ymc_creusr") = "~*NEW*~" Then
            If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") <> "~*DEL*~" Then

                If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*ADD*~" Then

                    If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " " Then
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr")
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*NEW*~"
                        'rs_SYMCATCDE.Tables("RESULT").Rows(readingindex )("ymc_creusr") = "~*DEL*~"
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y"
                        cmdFind.Enabled = False
                        Cbolevel.Enabled = False
                        cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                    ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y" Then
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr")
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " "
                    End If

                ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*NEW*~" Then

                    If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " " Then
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr")

                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y"
                        cmdFind.Enabled = False
                        Cbolevel.Enabled = False
                        cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                    ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y" Then
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr")
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " "
                    End If

                Else

                    If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " " Then
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr")
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*DEL*~"
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y"
                        cmdFind.Enabled = False
                        Cbolevel.Enabled = False
                        cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                    ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y" Then
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr")
                        rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " "
                    End If

                End If

            Else
                If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " " Then
                    rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr")
                    rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*DEL*~"
                    rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y"
                    cmdFind.Enabled = False
                    Cbolevel.Enabled = False
                    cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y" Then
                    rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_updusr")
                    rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = " "
                End If
            End If


        End If
    End Sub

    Private Sub CmdExit_Click()

        Me.Close()

    End Sub

    Private Sub cmdFind_Click()
        '*** perform query on database after user input an item number
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        readingindex = 0

        If (Trim(Cbolevel.Text) = "") Then      '********** Check empty
            Cbolevel.Focus()
            MsgBox("Please select category!")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else

            level = Microsoft.VisualBasic.Left(Cbolevel.Text, 1)
        End If

        '    Cbolevel.Enabled = False

        Dim rs As DataSet
        Dim S As String
        Dim i As Integer

        '*** query item master header
        S = "sp_select_SYMCATCDE_level '','" & level & "'"
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYMCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00130 sp_select_SYSALTQC : " & rtnStr)
        Else
            With rs_SYMCATCDE
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2
            End With

        End If

        If rs_SYMCATCDE.Tables("RESULT").Rows.Count > 0 Then
            Catcde_timestamp = rs_SYMCATCDE.Tables("RESULT").Rows(0)("ymc_timstp")
            For index As Integer = 0 To rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1
                rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_status") = " "
            Next
        End If

        If rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Record not found!")
            Cbolevel.Focus()
            Call Display()
            cmdInsRow.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            cmdDelRow.Enabled = Del_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            cmdInsRow.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            cmdDelRow.Enabled = Del_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001

            Current_TimeStamp = rs_SYMCATCDE.Tables("RESULT").Rows(0)("ymc_timstp")
            Call Display()
        End If


        cmdInsRow.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
        cmdDelRow.Enabled = Del_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdInsRow_Click()

        Add_flag = True

        If Not rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then

            '            rs_SYMCATCDE.MoveFirst()
            If rs_SYMCATCDE.Tables("RESULT").Rows(0)(3) = "" Then
                MsgBox("Column 3 Data could not be empty!")

                GrdCat.CurrentCell = GrdCat.Item(3, 0)
                GrdCat.BeginEdit(True)

                Exit Sub
            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            'rs_SYMCATCDE.MoveLast()
            If rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)(3) = "" Then
                MsgBox("Column 3 Data could not be empty!")

                GrdCat.CurrentCell = GrdCat.Item(3, rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)
                GrdCat.BeginEdit(True)
                Exit Sub
            End If

        End If
        cmdFind.Enabled = False
        Cbolevel.Enabled = False

        Call setStatus("InsRow")

        rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_creusr") = "~*ADD*~"

        '======================================
        rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_creusr_ori") = gsUsrID
        rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_credat") = Now
        rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_upddat") = Now
        '--------------------------------------
        '======================================

        rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)(4) = ""
        rs_SYMCATCDE.Tables("RESULT").AcceptChanges()

        rs_SYMCATCDE.Tables("RESULT").Columns(3).readonly = False
        GrdCat.Columns(3).ReadOnly = False


        GrdCat.CurrentCell = GrdCat.Item(3, rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)
        GrdCat.BeginEdit(True)

    End Sub
    Private Sub freelock()
        'On Error Resume Next
        If readingindex = -1 Then
            Exit Sub
        End If
        If Not rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*ADD*~" Then
                'tempzzzzzz
                GrdCat.Columns(3).ReadOnly = False

            Else
                GrdCat.Columns(3).ReadOnly = True

            End If
        End If
    End Sub
    Private Sub Form_KeyPress(ByVal KeyAscii As Integer)

    End Sub

    Private Sub Form_Load()
        Dim v

        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Save_flag = False
        Dim S As String
        Dim rs As DataSet

        S = "sp_select_SYMCATCDE_level '','" & "#" & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYMCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00130 sp_select_SYSALTQC : " & rtnStr)
        Else
            With rs_SYMCATCDE
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2
            End With

            Call Display()
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

        'Call fillvenno          ---------------Show the cbo box
        Cbolevel.Items.Clear()
        Cbolevel.Items.Add("0 - Item Category")
        Cbolevel.Items.Add("1 - Custom Category")
        CanModify = True

        Me.KeyPreview = True

        Call setStatus("Init")

        Call Formstartup(Me.Name)   'Set the form Sartup position

        Me.Cursor = Windows.Forms.Cursors.Default


    End Sub

    Private Sub CmdSave_Click()

        'If msgbox("M00129") = vbNo Then
        '    Exit Sub
        'End If
        save_ok = True
        If Not rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            For index As Integer = 0 To rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1
                If Not rs_SYMCATCDE.Tables("RESULT").Rows(index)(0) = "Y" Then
                    If rs_SYMCATCDE.Tables("RESULT").Rows(index)(3) = "" Then
                        MsgBox("Column 3 Data could not be empty!")
                        GrdCat.CurrentCell = GrdCat.Item(3, index)
                        GrdCat.BeginEdit(True)
                    End If
                End If
            Next
            Cbolevel.Enabled = True

            Save_flag = True
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Not Add_flag Then
                '***check timeStamp is equal
                If Not ChecktimeStamp() Then
                    MsgBox("The data has been modified by others, could not save!")
                    Me.Cursor = Windows.Forms.Cursors.Default
                    save_ok = False
                    Exit Sub
                End If
            End If
        End If


        Dim S As String
        Dim rs As DataSet

        Dim IsUpdated As Boolean
        IsUpdated = False






        If Not rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            For index As Integer = 0 To rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1

                S = ""
                If rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_creusr") = "~*ADD*~" Then
                    S = "sp_insert_SYMCATCDE '','" & level & "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(3) & "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(4) & _
                    "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(5) & "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(6) & "','" & gsUsrID & "'"
                    '-------------------------------------------------------------------------------------------------------
                ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_creusr") = "~*UPD*~" Then
                    S = "sp_update_SYMCATCDE '','" & level & "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(3) & "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(4) & _
                    "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(5) & "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(6) & "','" & gsUsrID & "'"
                    '-------------------------------------------------------------------------------------------------------
                ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_creusr") = "~*DEL*~" Then
                    If rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catcde") = "" Then
                        rs_SYMCATCDE.Tables("RESULT").Rows(index)(3) = ""
                        '                        rs_SYMCATCDE.Tables("RESULT").Rows(index)(3) = " "
                    End If
                    S = "sp_physical_delete_SYMCATCDE  '','" & level & "','" & rs_SYMCATCDE.Tables("RESULT").Rows(index)(3) & "'"
                ElseIf rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_creusr") = "~*NEW*~" Then
                    IsUpdated = True
                End If

                If S <> "" Then  '*** if there is something to do with s ...
                    gspStr = S
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        IsUpdated = False
                        MsgBox("Error on    saving  " & S & ":" & rtnStr)
                        Exit Sub
                    Else
                        IsUpdated = True
                    End If
                End If


            Next
        End If








        ' Write your code for Save
        ' for both detail and header ...
        ' >
        '   ...
        ' <

        If IsUpdated Then
            Call setStatus("Save")
            '            GrdCat.CurrentCell = GrdCat.Item(1, 0)
            '           GrdCat.BeginEdit(True)
            '          GrdCat.Focus()
        Else
            save_ok = False
            MsgBox("No update for save!")
        End If

        Call cmdFind_Click()
        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub
    Private Sub Display()

        GrdCat.DataSource = rs_SYMCATCDE.Tables("RESULT").DefaultView


        GrdCat.Columns(0).HeaderText = "Del"

        If level = "1" Then
            With GrdCat
                .Columns(0).Width = 40
                .Columns(0).ReadOnly = True

                .Columns(1).Width = 0
                .Columns(1).Visible = False

                .Columns(2).Width = 0
                .Columns(2).Visible = False

                .Columns(3).HeaderText = "Category Name"
                .Columns(3).Width = 130 / 1.73
                '.Columns(3).Button = True
                GrdCat.Columns(3).ReadOnly = True        '---------Temp Locked for key field

                .Columns(4).HeaderText = "Category Description"
                .Columns(4).Width = 400 / 1.73

                .Columns(5).HeaderText = "Category Display"
                .Columns(5).Width = 400 / 1.73
                .Columns(5).Visible = True

                .Columns(6).HeaderText = "Cloth (Y/N)"
                .Columns(6).Width = 40
                .Columns(6).ReadOnly = True
                .Columns(6).Visible = True

                .Columns(7).Width = 0
                .Columns(7).Visible = False

                .Columns(8).Width = 0
                .Columns(8).Visible = False

                .Columns(9).Width = 0
                .Columns(9).Visible = False


                .Columns(10).Width = 0
                .Columns(10).Visible = False

                .Columns(11).Width = 0
                .Columns(11).Visible = False

                .Columns(12).Width = 0
                .Columns(12).Visible = False


                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            End With
        Else
            With GrdCat
                .Columns(0).Width = 40
                .Columns(0).ReadOnly = True

                .Columns(1).Width = 0
                .Columns(1).Visible = False
                .Columns(2).Width = 0
                .Columns(2).Visible = False

                .Columns(3).HeaderText = "Category Name"
                .Columns(3).Width = 130 / 1.7
                '.Columns(3).Button = True
                .Columns(3).ReadOnly = True        '---------Temp Locked for key field

                .Columns(4).HeaderText = "Category Description"
                .Columns(4).Width = 540 / 1.7

                .Columns(5).HeaderText = "Category Display"
                .Columns(5).Width = 0
                .Columns(5).Visible = False



                .Columns(6).HeaderText = "Cloth (Y/N)"
                .Columns(6).ReadOnly = False
                .Columns(6).Width = 0
                .Columns(6).Visible = False


                .Columns(7).Width = 0
                .Columns(7).Visible = False

                .Columns(8).Width = 0
                .Columns(8).Visible = False

                .Columns(9).Width = 0
                .Columns(9).Visible = False


                .Columns(10).Width = 0
                .Columns(10).Visible = False

                .Columns(11).Width = 0
                .Columns(11).Visible = False

                .Columns(12).Width = 0
                .Columns(12).Visible = False


                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            End With
        End If

        If Not rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            StatusBar.Panels(0).Text = Format(rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(9), "dd/MM/yyyy") & " " & Format(rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(10), "dd/MM/yyyy") & " " & rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(5)
        End If

    End Sub
    Private Sub display_formload()
        GrdCat.DataSource = Nothing
        With GrdCat
            .Columns(0).HeaderText = "Category Name"
            .Columns(0).Width = 300
            .Columns(1).HeaderText = "Category description"
            .Columns(1).Width = 490

        End With

    End Sub
    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            'Call SetInputBoxesStatus("DisableAll")
            'CmdAdd.Enabled = Enq_right 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False 'Enq_right 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            cmdFind.Enabled = True
            'CmdLookup.Enabled = False   'True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False   'True
            'cmdspecial.Enabled = False  'True
            'cmdbrowlist.Enabled = False 'True

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrev.Enabled = False

            'cboitmstatus.readonly= True
            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)

            '*** Enable key field(s) in header
            'txtitmno.Enabled = True

            '***Reset the flag
            Recordstatus = False
            Add_flag = False
            'Add your codes here

        ElseIf Mode = "Clear" Then
            Call display_formload()
            Cbolevel.Enabled = True
            Cbolevel.Focus()
            Call setStatus("Init")
            Call SetStatusBar(Mode)


        ElseIf Mode = "Save" Then
            MsgBox("Record Saved!")
            'MsgBox("M00214")
            Call SetStatusBar(Mode)
            Call setStatus("Init")
            Call cmdFind_Click()

        ElseIf Mode = "DelRow" Then
            Call SetStatusBar("Delete")
            'rs_SYLNECOL.Delete

        ElseIf Mode = "InsRow" Then
            rs_SYMCATCDE.Tables("RESULT").Rows.Add()
            'rs_SYMCATCDE.AddNew()
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_status") = " "             '------New
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_cocde") = ""
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_type") = ""

            rs_SYMCATCDE.Tables("RESULT").Columns(3).ReadOnly = False
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_catcde") = ""

            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_catdsc") = ""
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_catdis") = ""
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_cloth") = ""
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_creusr") = gsUsrID
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_updusr") = gsUsrID
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_credat") = "01/01/1900"
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_upddat") = "01/01/1900"
            rs_SYMCATCDE.Tables("RESULT").Rows(rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1)("ymc_timstp") = 0



            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            'CmdLookup.Enabled = False
            Cbolevel.Enabled = False
            cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            cmdDelRow.Enabled = Del_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001


            Call SetStatusBar(Mode)
        ElseIf Mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)

            'MsgBox "Record Saved!"

            ' If GrdHarCde.Columns(1) = "" Or GrdHarCde.Columns(2) = "" Then
            'MsgBox "Can't accept empty! Type again!"
            'CmdSave.Enabled = True
            'Exit Sub
            'Else
            Call setStatus("init")
            Call Form_Load()
            'End If


        ElseIf Mode = "DelRow" Then

            Call SetStatusBar(Mode)
            'rs_.Delete

        End If

        If Not CanModify Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            ''CmdLookup.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            Call SetStatusBar("ReadOnly")
        End If

    End Sub
    Private Sub ResetDefaultDisp()

        If Save_flag = True Then
            cmdInsRow.Enabled = Enq_right_local 'True'*** For Access Right use, added by Tommy on 5 Oct 2001
            cmdDelRow.Enabled = Del_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            Save_flag = False
            Exit Sub
        Else
            'Cbolevel.Text = ""

            StatusBar.Panels(0).Text = ""
            StatusBar.Panels(1).Text = ""
        End If
        'Reset other fields
        'Add codes here..........

    End Sub

    Private Function ChecktimeStamp() As Boolean
        '***Add Codes here***
        'Compare the current record's timestamp and the DB timestamp
        Dim Save_TimeStamp As Long
        Dim S As String
        Dim rs As DataSet
        S = "sp_select_SYMCATCDE_level '','" & level & "'"
        gspStr = S
        Cursor = Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_SYMCATCDE_check, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_MPM00002  :" & rtnStr)
            Exit Function
        Else
            Save_TimeStamp = rs_SYMCATCDE_check.Tables("RESULT").Rows(0)("ymc_timstp")
        End If
        Cursor = Cursors.Default

        If Current_TimeStamp <> Save_TimeStamp Then
            ChecktimeStamp = False
        Else
            ChecktimeStamp = True
        End If


    End Function
    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "Init" Then
            StatusBar.Panels(0).Text = "Init"
            '        StatusBar.Panels(1) = rs_SYLNEINF(4) & " " & Left(rs_SYLNEINF(6), 10)

        ElseIf Mode = "ADD" Then
            StatusBar.Panels(0).Text = "ADD"
            '       StatusBar.Panels(1) = rs_SYLNEINF(4) & " " & Left(rs_SYLNEINF(6), 10)

        ElseIf Mode = "Updating" Then
            StatusBar.Panels(0).Text = "Updating"
            '      StatusBar.Panels(1) = rs_SYLNEINF(4) & " " & Left(rs_SYLNEINF(6), 10)

        ElseIf Mode = "Save" Then
            StatusBar.Panels(0).Text = "Record Saved"
            '     StatusBar.Panels(1) = rs_SYLNEINF(4) & " " & Left(rs_SYLNEINF(6), 10)

        ElseIf Mode = "Delete" Then
            StatusBar.Panels(0).Text = "Record Deleted"
            '    StatusBar.Panels(1) = rs_SYLNEINF(4) & " " & Left(rs_SYLNEINF(6), 10)

        ElseIf Mode = "ReadOnly" Then
            StatusBar.Panels(0).Text = "Read Only"
            '   StatusBar.Panels(1) = rs_SYLNEINF(4) & " " & Left(rs_SYLNEINF(6), 10)

        ElseIf Mode = "Clear" Then
            StatusBar.Panels(0).Text = "Clear Screen"
            '  StatusBar.Panels(1) = rs_SYLNEINF(4) & " " & Left(rs_SYLNEINF(6), 10)
        End If
    End Sub

    Private Sub Form_Unload(ByVal Cancel As Integer)

    End Sub

    Private Sub GrdCat_AfterColUpdate(ByVal ColIndex As Integer)

    End Sub



    Private Sub GrdCat_ButtonClick(ByVal ColIndex As Integer)


    End Sub




    Private Sub GrdCat_DblClick()
    End Sub

    Private Sub GrdCat_Error(ByVal DataError As Integer, ByVal Response As Integer)

        'If DataError = 7007 Then
        '    MsgBox("M00018")
        '    Response = 0
        '    Exit Sub

        'End If
    End Sub

    Private Sub GrdCat_HeadClick(ByVal ColIndex As Integer)
    End Sub

    Private Sub GrdCat_KeyDown(ByVal KeyCode As Integer, ByVal Shift As Integer)
    End Sub

    Private Sub GrdCat_KeyPress(ByVal KeyAscii As Integer)

    End Sub

    Private Sub GrdCat_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)



    End Sub

    Private Sub SYM00020_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim YNC, book As Integer

        'If rs_SYMCATCDE.EOF = True Then
        '    Cancel = False
        'Else

        'book = rs_SYMCATCDE.AbsolutePosition

        rs_SYMCATCDE.Tables("RESULT").DefaultView.RowFilter = "ymc_creusr = " & "'" & "~*ADD*~" & "'" & _
                                  "or ymc_creusr = " & "'" & "~*UPD*~" & "'" & _
                                  "or ymc_creusr = " & "'" & "~*DEL*~" & "'" & _
                                  "or ymc_creusr = " & "'" & "~*NEW*~" & "'"

        If rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then
            e.Cancel = False
        Else
            rs_SYMCATCDE.Tables("RESULT").DefaultView.RowFilter = ""
            Call Display()


            YNC = MsgBox("Save records before exit?", MsgBoxStyle.YesNo)
            If YNC = vbYes Then
                If Enq_right_local = True Then
                    Call CmdSave_Click()
                    If save_ok = True Then
                        e.Cancel = False
                    Else
                        rs_SYMCATCDE.Tables("RESULT").DefaultView.RowFilter = ""
                        Call Display()
                        e.Cancel = True
                    End If
                Else
                    MsgBox("Sorry! You do not right to save!")
                End If
            ElseIf YNC = vbNo Then
                e.Cancel = False
                Exit Sub
            ElseIf YNC = vbCancel Then
                rs_SYMCATCDE.Tables("RESULT").DefaultView.RowFilter = ""
                Call Display()
                e.Cancel = True
                Exit Sub
            End If
            Exit Sub
        End If

    End Sub

    Private Sub SYM00020_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If Asc(e.KeyChar) = 13 Then
            e.KeyChar = Chr(9)
        End If
    End Sub


    Private Sub SYM00020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Call cmdFind_Click()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call CmdSave_Click()

    End Sub

    Private Sub GrdCat_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCat.CellClick
        Dim df_readingindex As Integer
        Dim ColIndex As Integer
        df_readingindex = e.RowIndex
        ColIndex = e.ColumnIndex
        Call freelock()

        If ColIndex = 0 Then
            If rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(0) = " " Then
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(0) = "Y"
                If rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr") = "~*ADD*~" Then
                    rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr") = "~*NEW*~"
                Else
                    rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr") = "~*DEL*~"
                End If
                cmdFind.Enabled = False
                Cbolevel.Enabled = False
                cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            Else
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(0) = " "
                If rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr") = "~*NEW*~" Then
                    rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr") = "~*ADD*~"
                Else
                    rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr") = "~*UPD*~"
                End If
            End If
        End If

        If ColIndex = 6 And level = "1" Then
            If Trim(rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(6)) = "" Then
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(6) = "Y"
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_cloth") = "Y"
                cmdFind.Enabled = False
                Cbolevel.Enabled = False
                cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            ElseIf Trim(rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(6)) = "Y" Then
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(6) = "P"
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_cloth") = "P"
                cmdFind.Enabled = False
                Cbolevel.Enabled = False
                cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            Else
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)(6) = " "
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_cloth") = ""
                cmdFind.Enabled = False
                Cbolevel.Enabled = False
                cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            End If
            If Trim(rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr")) <> "~*ADD*~" And _
                Trim(rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr")) <> "~*NEW*~" And _
                Trim(rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr")) <> "~*DEL*~" And _
                Trim(rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr")) <> "~*UPD*~" Then
                rs_SYMCATCDE.Tables("RESULT").DefaultView(df_readingindex)("ymc_creusr") = "~*UPD*~"
            End If
        End If

        rs_SYMCATCDE.Tables("RESULT").AcceptChanges()
        Call Display()

    End Sub

    Private Sub GrdCat_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCat.CellContentClick

    End Sub

    Private Sub GrdCat_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCat.CellDoubleClick

        readingindex = e.RowIndex

        If e.ColumnIndex = 0 Then

            If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_status") = "Y" Then
                'GrdHarCde.Columns(0) = "No"
                rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(0) = " "
                rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = " "
            End If
        End If


        If e.ColumnIndex = 6 And level = "1" Then
            '            If rs_SYMCATCDE.EOF <> True Then
            If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_cloth") = "Y" Then
                rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(0) = " "
                'clo 0?
                '                GrdCat.Columns(0) = " "
                rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = " "
            End If
            'End If

        End If



    End Sub

    Private Sub GrdCat_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCat.CellEndEdit
        Dim tmp As String
        Dim tmpBookMark As Integer
        Dim old_filter
        Dim current_pos As Integer
        Dim ColIndex As Integer
        readingindex = e.RowIndex
        ColIndex = e.ColumnIndex

        If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") <> "~*ADD*~" Then
            rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*UPD*~"
            cmdFind.Enabled = False
            Cbolevel.Enabled = False
            cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
        End If

        Dim lngMOQMOA As Long
        If Not rs_SYMCATCDE.Tables("RESULT").Rows.Count = 0 Then

            If ColIndex = 3 And rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(3) <> "" Then

                If ColIndex = 3 Then
                    rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(3) = Trim(UCase(rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(3)))
                    '                    GrdCat.Columns(3) = Trim(UCase(GrdCat.Columns(3)))
                End If

                '                current_pos = rs_SYMCATCDE.AbsolutePosition  'Lester Wu 2004/09/16
                '               tmpBookMark = rs_SYMCATCDE.bookmark

                tmp = rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_catcde")

                For index As Integer = 0 To rs_SYMCATCDE.Tables("RESULT").Rows.Count - 1
                    If index <> readingindex Then

                        If tmp = rs_SYMCATCDE.Tables("RESULT").Rows(index)("ymc_catcde") Then
                            MsgBox("This grid have " & tmp & " Category Name!", vbInformation)
                            rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(3) = ""
                            Exit Sub
                        End If
                    End If


                Next

            End If
        End If

    End Sub

    Private Sub GrdCat_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdCat.ColumnHeaderMouseClick
        Dim ColIndex As Integer
        ColIndex = e.ColumnIndex

        If rs_SYMCATCDE Is Nothing Then Exit Sub
        If rs_SYMCATCDE.Tables("RESULT").Rows.Count <= 0 Then Exit Sub

        If ColIndex = 3 Then
            rs_SYMCATCDE.Tables("result").DefaultView.Sort = "ymc_catcde"
        ElseIf ColIndex = 4 Then
            rs_SYMCATCDE.Tables("result").DefaultView.Sort = "ymc_catdsc"
        ElseIf ColIndex = 5 And level = "1" Then
            rs_SYMCATCDE.Tables("result").DefaultView.Sort = "ymc_catdis"
        ElseIf ColIndex = 6 And level = "1" Then
            rs_SYMCATCDE.Tables("result").DefaultView.Sort = "ymc_cloth"
        End If


    End Sub

    Private Sub GrdCat_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdCat.CurrentCellChanged
        '    Call freelock()

    End Sub

    '  Private Sub GrdCat_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GrdCat.EditingControlShowing

    '    AddHandler e.Control.KeyPress, AddressOf CheckCellreggrr
    '   AddHandler e.Control.KeyDown, AddressOf CheckCellreggrrrwer


    ' End Sub

    Private Sub CheckCellreggrr(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = Asc(e.KeyChar)

        'If KeyAscii = 32 Then

        '    If Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "A" Then
        '        rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "R"

        '    ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "R" Then
        '        rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "W"

        '    ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "W" Then
        '        rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "A"

        '    End If
        '    Recordstatus = True


        '    e.Handled = True

        '        End If









        If KeyAscii = 9 Then
            Exit Sub
        End If
        If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*DEL*~" Or _
            rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*NEW*~" Then
            e.KeyChar = Chr(0)
            Exit Sub
        End If

        If KeyAscii = 22 Then
            e.KeyChar = Chr(0)
        End If

        If rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") <> "~*ADD*~" Then
            rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)("ymc_creusr") = "~*UPD*~"
            cmdFind.Enabled = False
            Cbolevel.Enabled = False
            cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
        End If


        If GrdCat.CurrentCell.ColumnIndex = 0 Then
            If KeyAscii = 32 Then
                Call GrdCat_DblClick()
            End If
        End If

        If GrdCat.CurrentCell.ColumnIndex = 3 And (Len(rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(3)) + 1) > 20 And KeyAscii > 31 Then
            e.KeyChar = Chr(0)
        End If

        If GrdCat.CurrentCell.ColumnIndex = 4 And (Len(rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(4)) + 1) > 200 And KeyAscii > 31 Then
            e.KeyChar = Chr(0)
        End If

        If GrdCat.CurrentCell.ColumnIndex = 5 And (Len(rs_SYMCATCDE.Tables("RESULT").Rows(readingindex)(5)) + 1) > 200 And KeyAscii > 31 Then
            e.KeyChar = Chr(0)
        End If


        'If GrdCat.CurrentCell.ColumnIndex= 10 Or GrdCat.CurrentCell.ColumnIndex= 11 Then
        If GrdCat.CurrentCell.ColumnIndex = 10 Then
            e.KeyChar = Chr(0)

        End If






        If Asc(e.KeyChar) = 86 And Control.ModifierKeys = Keys.Control Then
            e.KeyChar = Chr(0)
        ElseIf Asc(e.KeyChar) = 45 And Control.ModifierKeys = Keys.Shift Then
            e.KeyChar = Chr(0)
        End If

    End Sub




    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Call cmdInsRow_Click()
    End Sub

    Private Sub Cbolevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbolevel.SelectedIndexChanged
        Call cmdFind_Click()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call cmdClear_Click()

    End Sub
End Class

