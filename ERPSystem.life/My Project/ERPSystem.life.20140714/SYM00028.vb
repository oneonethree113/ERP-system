Public Class SYM00028

    Const dgSalMgr_Del As Integer = 0
    Const dgSalMgr_SalDiv As Integer = 1
    Const dgSalMgr_SalMgr As Integer = 2
    Const dgSalMgr_UsrNam As Integer = 3
    Const dgSalMgr_Status As Integer = 4
    Const dgSalTeam_Del As Integer = 0
    Const dgSalTeam_SalTem As Integer = 1
    Const dgSalTeam_SalDiv As Integer = 2
    Const dgSalTeam_Status As Integer = 3
    Const dgSalRep_Del As Integer = 0
    Const dgSalRep_SalTem As Integer = 1
    Const dgSalRep_SalDiv As Integer = 2
    Const dgSalRep_SalMgr As Integer = 3
    Const dgSalRep_SalRep As Integer = 4
    Const dgSalRep_UsrNam As Integer = 5
    Const dgSalRep_Default As Integer = 6
    Const dgSalRep_Status As Integer = 7

    Const tabFrame_SalRep As Integer = 0
    Const tabFrame_SalMngr As Integer = 1
    Const tabFrame_SalTeam As Integer = 2

    Dim Del_right_local As Boolean
    Dim Enq_right_local As Boolean
    Dim recordStatus As Boolean

    Dim rs_SYSALINF_MGR As DataSet
    Dim rs_SYSALINF_MGR_load As DataSet
    Dim rs_SYSALINF_TEAM As DataSet
    Dim rs_SYSALINF_TEAM_load As DataSet
    Dim rs_SYSALREL As DataSet
    Dim rs_SYSALREL_load As DataSet
    Dim rs_SYUSRPRF_MGR As DataSet
    Dim rs_SYUSRPRF_REP As DataSet

    Private Sub SYM00028_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If recordStatus = True Then
            Dim answer As Integer
            answer = MsgBox("Do you want to save the changes made before exiting?", MsgBoxStyle.YesNoCancel)
            If answer = MsgBoxResult.Yes Then
                cmdSave.PerformClick()
            ElseIf answer = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub SYM00028_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
        Call AccessRight(Me.Name)

        Enq_right_local = Enq_right
        Del_right_local = Del_right

        setStatus("INIT")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If SaveSalesTeam() = False Then
            Exit Sub
        End If

        If SaveSalesMgr() = False Then
            Exit Sub
        End If

        If SaveSalesRep() = False Then
            Exit Sub
        End If

        MsgBox("Record Saved")
        setStatus("INIT")
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If MsgBox("Confirm to clear all unsaved entries", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            setStatus("INIT")
        End If
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Select Case tabFrame.SelectedIndex
            Case tabFrame_SalRep
                freeze_TabControl(tabFrame_SalRep)
                displayPanel(tabFrame_SalRep, "INS")
                grpSalRep.Enabled = False
            Case tabFrame_SalMngr
                freeze_TabControl(tabFrame_SalMngr)
                displayPanel(tabFrame_SalMngr, "INS")
                grpSalMngr.Enabled = False
            Case tabFrame_SalTeam
                freeze_TabControl(tabFrame_SalTeam)
                displayPanel(tabFrame_SalTeam, "INS")
                grpSalTeam.Enabled = False
        End Select
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Close()
    End Sub

    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = False
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = Enq_right_local
            cmdInsRow.Enabled = Del_right_local
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True

            rs_SYSALINF_MGR_load = Nothing
            rs_SYSALINF_TEAM_load = Nothing
            rs_SYSALREL_load = Nothing

            rs_SYSALINF_MGR = Nothing
            rs_SYSALINF_TEAM = Nothing
            rs_SYSALREL = Nothing

            cmdPanSalRepCancel.PerformClick()
            cmdPanSalMngrCancel.PerformClick()
            cmdPanSalTeamCancel.PerformClick()

            tabFrame.SelectedIndex = tabFrame_SalRep

            recordStatus = False

            fillcboSalesDiv()
            fillcboSalesMgr()
            fillcboSalesRep()

            loadSYSALREL()
            loadSYSALINF_MGR()
            loadSYSALINF_TEAM()

            display_dgSalRep()
            display_dgSalMgr()
            display_dgSalTeam()
        End If
    End Sub

    Private Sub fillcboSalesDiv()
        cboPanSalMngrSalDiv.Items.Clear()
        cboPanSalMngrSalDiv.Items.Add("1 - Sales Division 1")
        cboPanSalMngrSalDiv.Items.Add("2 - Sales Division 2")
        cboPanSalMngrSalDiv.Items.Add("3 - Sales Division 3")
        cboPanSalMngrSalDiv.Items.Add("4 - Sales Division 4")
        cboPanSalMngrSalDiv.Items.Add("S - Sales Division S")

        cboPanSalTeamSalDiv.Items.Clear()
        cboPanSalTeamSalDiv.Items.Add("1 - Sales Division 1")
        cboPanSalTeamSalDiv.Items.Add("2 - Sales Division 2")
        cboPanSalTeamSalDiv.Items.Add("3 - Sales Division 3")
        cboPanSalTeamSalDiv.Items.Add("4 - Sales Division 4")
        cboPanSalTeamSalDiv.Items.Add("S - Sales Division S")
    End Sub

    Private Sub fillcboSalesMgr()
        gspStr = "sp_list_SYUSRPRF_SYM00028 '','MGR'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_Mgr, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillcboSalesMgr #001 sp_list_SYUSRPRF_SYM00028 :" & rtnStr)
            Exit Sub
        End If

        cboPanSalMngrSalMngr.Items.Clear()
        For i As Integer = 0 To rs_SYUSRPRF_Mgr.Tables("RESULT").Rows.Count - 1
            cboPanSalMngrSalMngr.Items.Add(rs_SYUSRPRF_Mgr.Tables("RESULT").Rows(i)("yup_usrid").ToString & " - " & rs_SYUSRPRF_Mgr.Tables("RESULT").Rows(i)("yup_usrnam").ToString)
        Next
    End Sub

    Private Sub fillcboSalesRep()
        gspStr = "sp_list_SYUSRPRF_SYM00028 '','ALL'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_Rep, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillcboSalesRep #001 sp_list_SYUSRPRF_SYM00028 :" & rtnStr)
            Exit Sub
        End If

        cboPanSalRepSalRep.Items.Clear()
        For i As Integer = 0 To rs_SYUSRPRF_Rep.Tables("RESULT").Rows.Count - 1
            cboPanSalRepSalRep.Items.Add(rs_SYUSRPRF_Rep.Tables("RESULT").Rows(i)("yup_usrid") & " - " & rs_SYUSRPRF_Rep.Tables("RESULT").Rows(i)("yup_usrnam"))
        Next
    End Sub

    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
        Dim i As Integer
        For i = 0 To tabFrame.TabPages.Count - 1
            If i = tabpageno Then
                Me.tabFrame.TabPages(i).Enabled = True
            Else
                Me.tabFrame.TabPages(i).Enabled = False
            End If
        Next i
    End Sub

    Private Sub release_TabControl()
        Dim i As Integer
        For i = 0 To tabFrame.TabPages.Count - 1
            tabFrame.TabPages(i).Enabled = True
        Next i
    End Sub

    Private Sub displayPanel(ByVal panel As Integer, ByVal mode As String)
        If panel = tabFrame_SalRep Then
            If panSalRep.Visible = True Then
                Exit Sub
            End If

            panSalRep.Visible = True

            cboPanSalRepSalTeam.Items.Clear()
            Dim dr() As DataRow = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_del <> 'Y'", "ssi_saltem")
            If dr.Length = 0 Then
                MsgBox("No teams are currently available")
                cmdPanSalRepCancel.PerformClick()
            Else
                Dim dr_mgr() As DataRow
                For i As Integer = 0 To dr.Length - 1
                    dr_mgr = Nothing
                    dr_mgr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & dr(i).Item("ssi_saldiv") & "' and ssi_del = ''")
                    If dr_mgr.Length = 0 Then
                        MsgBox("Sales Division (" & dr(i).Item("ssi_saldiv") & ") is missing Sales Manager")
                        Continue For
                    End If
                    cboPanSalRepSalTeam.Items.Add(dr(i).Item("ssi_saltem") & " - Team " & dr(i).Item("ssi_saltem"))
                Next
            End If

            If mode = "INS" Then
                cmdPanSalRepInsert.Enabled = True

                enable_DropDownCombo(cboPanSalRepSalTeam, True)
                enable_DropDownCombo(cboPanSalRepSalRep, True)
                chkPanSalRepDefault.Checked = False

                cboPanSalRepSalTeam.SelectedIndex = -1
                cboPanSalRepSalTeam.Text = ""
                cboPanSalRepSalRep.SelectedIndex = -1
                cboPanSalRepSalRep.Text = ""
            Else
                cmdPanSalRepInsert.Enabled = False

                enable_DropDownCombo(cboPanSalRepSalTeam, True)
                enable_DropDownCombo(cboPanSalRepSalRep, True)
                If dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y" Then
                    chkPanSalRepDefault.Checked = True
                Else
                    chkPanSalRepDefault.Checked = False
                End If

                cboPanSalRepSalTeam.SelectedIndex = -1
                cboPanSalRepSalRep.SelectedIndex = -1

                display_combo(dgSalRep.CurrentRow.Cells(dgSalRep_SalTem).Value, cboPanSalRepSalTeam)
                display_combo(dgSalRep.CurrentRow.Cells(dgSalRep_SalRep).Value, cboPanSalRepSalRep)

                If cboPanSalRepSalTeam.SelectedIndex = -1 Then
                    MsgBox("The selected Sales Division is no longer available")
                End If

                If cboPanSalRepSalRep.SelectedIndex = -1 Then
                    MsgBox("The selected Sales Rep is no longer available")
                End If
            End If
        ElseIf panel = tabFrame_SalMngr Then
            If panSalMngr.Visible = True Then
                Exit Sub
            End If

            panSalMngr.Visible = True
            If mode = "INS" Then
                cmdPanSalMngrInsert.Enabled = True
                cmdPanSalMngrUpdate.Enabled = False

                enable_DropDownCombo(cboPanSalMngrSalDiv, True)
                enable_DropDownCombo(cboPanSalMngrSalMngr, True)

                cboPanSalMngrSalDiv.SelectedIndex = -1
                cboPanSalMngrSalDiv.Text = ""
                cboPanSalMngrSalMngr.SelectedIndex = -1
                cboPanSalMngrSalMngr.Text = ""
            Else
                cmdPanSalMngrInsert.Enabled = False
                cmdPanSalMngrUpdate.Enabled = True

                enable_DropDownCombo(cboPanSalMngrSalDiv, False)
                enable_DropDownCombo(cboPanSalMngrSalMngr, True)

                cboPanSalMngrSalDiv.SelectedIndex = -1
                cboPanSalMngrSalMngr.SelectedIndex = -1

                display_combo(dgSalMgr.CurrentRow.Cells(dgSalMgr_SalDiv).Value, cboPanSalMngrSalDiv)
                display_combo(dgSalMgr.CurrentRow.Cells(dgSalMgr_SalMgr).Value, cboPanSalMngrSalMngr)

                If cboPanSalMngrSalDiv.SelectedIndex = -1 Then
                    MsgBox("The selected Sales Division is no longer available")
                End If

                If cboPanSalMngrSalMngr.SelectedIndex = -1 Then
                    MsgBox("The selected Sales Manager is no longer available")
                End If
            End If
        ElseIf panel = tabFrame_SalTeam Then
            If panSalTeam.Visible = True Then
                Exit Sub
            End If

            panSalTeam.Visible = True
            If mode = "INS" Then
                cmdPanSalTeamInsert.Enabled = True
                cmdPanSalTeamUpdate.Enabled = False

                enable_DropDownCombo(cboPanSalTeamSalDiv, True)
                txtPanSalTeamSalTeam.Enabled = True

                cboPanSalTeamSalDiv.SelectedIndex = -1
                cboPanSalTeamSalDiv.Text = ""
                txtPanSalTeamSalTeam.Text = ""
            Else
                cmdPanSalTeamInsert.Enabled = False
                cmdPanSalTeamUpdate.Enabled = True

                enable_DropDownCombo(cboPanSalTeamSalDiv, True)
                txtPanSalTeamSalTeam.Enabled = False

                cboPanSalTeamSalDiv.SelectedIndex = -1
                display_combo(dgSalTeam.CurrentRow.Cells(dgSalTeam_SalDiv).Value, cboPanSalTeamSalDiv)
                txtPanSalTeamSalTeam.Text = dgSalTeam.CurrentRow.Cells(dgSalTeam_SalTem).Value

                If cboPanSalTeamSalDiv.SelectedIndex = -1 Then
                    MsgBox("The selected Sales Division is no longer available")
                End If
            End If
        End If
    End Sub

    Private Sub loadSYSALREL()
        gspStr = "sp_list_SYSALREL '" & gsCompany & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading loadSYSALREL #001 sp_list_SYSALREL :" & rtnStr)
            Exit Sub
        End If
        rs_SYSALREL_load = rs_SYSALREL.Copy()
    End Sub

    Private Sub loadSYSALINF_MGR()
        gspStr = "sp_list_SYSALINF '" & gsCompany & "','MGR'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALINF_MGR, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading loadSYSALINF_MGR #001 sp_list_SYSALINF :" & rtnStr)
            Exit Sub
        End If
        rs_SYSALINF_MGR_load = rs_SYSALINF_MGR.Copy()
    End Sub

    Private Sub loadSYSALINF_TEAM()
        gspStr = "sp_list_SYSALINF '" & gsCompany & "','TEAM'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALINF_TEAM, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading loadSYSALINF_MGR #001 sp_list_SYSALINF :" & rtnStr)
            Exit Sub
        End If
        rs_SYSALINF_TEAM_load = rs_SYSALINF_TEAM.Copy()
    End Sub

    Private Sub display_dgSalRep()
        If rs_SYSALREL.Tables.Count = 0 Then
            Exit Sub
        End If

        cboSalesTeam.Items.Clear()
        cboSalesTeam.Items.Add("[ALL]")
        For i As Integer = 0 To rs_SYSALINF_TEAM_load.Tables("RESULT").Rows.Count - 1
            cboSalesTeam.Items.Add(rs_SYSALINF_TEAM_load.Tables("RESULT").Rows(i)("ssi_saltem"))
        Next
        cboSalesTeam.Sorted = True
        cboSalesTeam.SelectedIndex = 0

        dgSalRep.DataSource = rs_SYSALREL.Tables("RESULT").DefaultView

        dgSalRep.RowHeadersWidth = 20
        dgSalRep.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgSalRep.ColumnHeadersHeight = 20
        dgSalRep.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgSalRep.AllowUserToResizeColumns = False
        dgSalRep.AllowUserToResizeRows = False
        dgSalRep.RowTemplate.Height = 20

        With dgSalRep
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case dgSalRep_Del
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).Width = 50
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case dgSalRep_SalTem
                        .Columns(i).HeaderText = "Sales Team"
                        .Columns(i).Width = 100
                    Case dgSalRep_SalRep
                        .Columns(i).HeaderText = "Sales Rep ID"
                        .Columns(i).Width = 150
                    Case dgSalRep_UsrNam
                        .Columns(i).HeaderText = "Sales Rep Name"
                        .Columns(i).Width = 200
                    Case dgSalRep_Default
                        .Columns(i).HeaderText = "Default"
                        .Columns(i).Width = 80
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
            .ClearSelection()
        End With
    End Sub

    Private Sub display_dgSalMgr()
        If rs_SYSALINF_MGR.Tables.Count = 0 Then
            Exit Sub
        End If

        dgSalMgr.DataSource = rs_SYSALINF_MGR.Tables("RESULT").DefaultView

        dgSalMgr.RowHeadersWidth = 20
        dgSalMgr.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgSalMgr.ColumnHeadersHeight = 20
        dgSalMgr.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgSalMgr.AllowUserToResizeColumns = False
        dgSalMgr.AllowUserToResizeRows = False
        dgSalMgr.RowTemplate.Height = 20

        With dgSalMgr
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case dgSalMgr_Del
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).Width = 50
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case dgSalMgr_SalDiv
                        .Columns(i).HeaderText = "Sales Division"
                        .Columns(i).Width = 100
                    Case dgSalMgr_SalMgr
                        .Columns(i).HeaderText = "Sales Manager ID"
                        .Columns(i).Width = 150
                    Case dgSalMgr_UsrNam
                        .Columns(i).HeaderText = "Sales Manager Name"
                        .Columns(i).Width = 200
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
            .ClearSelection()
        End With
    End Sub

    Private Sub display_dgSalTeam()
        If rs_SYSALINF_TEAM.Tables.Count = 0 Then
            Exit Sub
        End If

        dgSalTeam.DataSource = rs_SYSALINF_TEAM.Tables("RESULT").DefaultView

        dgSalTeam.RowHeadersWidth = 20
        dgSalTeam.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgSalTeam.ColumnHeadersHeight = 20
        dgSalTeam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgSalTeam.AllowUserToResizeColumns = False
        dgSalTeam.AllowUserToResizeRows = False
        dgSalTeam.RowTemplate.Height = 20

        With dgSalTeam
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case dgSalTeam_Del
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).Width = 50
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case dgSalTeam_SalTem
                        .Columns(i).HeaderText = "Sales Team"
                        .Columns(i).Width = 100
                    Case dgSalTeam_SalDiv
                        .Columns(i).HeaderText = "Sales Division"
                        .Columns(i).Width = 100
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
            .ClearSelection()
        End With
    End Sub

    Private Sub dgSalMgr_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgSalMgr.RowHeaderMouseDoubleClick
        If cmdInsRow.Enabled = False Then
            Exit Sub
        End If

        If e.RowIndex >= 0 Then
            freeze_TabControl(tabFrame_SalMngr)
            displayPanel(tabFrame_SalMngr, "UPD")
            grpSalMngr.Enabled = False
        End If
    End Sub

    Private Sub dgSalTeam_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgSalTeam.RowHeaderMouseDoubleClick
        If cmdInsRow.Enabled = False Then
            Exit Sub
        End If

        If e.RowIndex >= 0 Then
            freeze_TabControl(tabFrame_SalTeam)
            displayPanel(tabFrame_SalTeam, "UPD")
            grpSalTeam.Enabled = False
        End If
    End Sub

    Private Sub dgSalRep_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSalRep.CellDoubleClick
        If cmdInsRow.Enabled = False Then
            Exit Sub
        End If

        Dim dr() As DataRow

        If e.ColumnIndex = dgSalRep_Del Then
            rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Del).ReadOnly = False
            rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Status).ReadOnly = False

            If dgSalRep.CurrentRow.Cells(dgSalRep_Del).Value = "" Then
                If dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y" Then
                    dr = Nothing
                    dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & dgSalRep.CurrentRow.Cells(dgSalRep_SalTem).Value & "' and " & _
                                                             "ssr_salrep <> '" & dgSalRep.CurrentRow.Cells(dgSalRep_SalRep).Value & "' and " & _
                                                             "ssr_del = ''")
                    If dr.Length > 0 Then
                        MsgBox("Default Sales Rep cannot be deleted")
                        rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Del).ReadOnly = True
                        rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Status).ReadOnly = True
                        Exit Sub
                    Else
                        dgSalRep.CurrentCell.Value = "Y"
                        If dgSalRep.CurrentRow.Cells(dgSalRep_Status).Value = "~*ADD*~" Then
                            dgSalRep.CurrentRow.Cells(dgSalRep_Status).Value = "~*DEL*~"
                        End If
                        Exit Sub
                    End If
                Else
                    dgSalRep.CurrentCell.Value = "Y"
                    If dgSalRep.CurrentRow.Cells(dgSalRep_Status).Value = "~*ADD*~" Then
                        dgSalRep.CurrentRow.Cells(dgSalRep_Status).Value = "~*DEL*~"
                    End If
                End If
            Else
                dr = Nothing
                dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & dgSalRep.CurrentRow.Cells(dgSalRep_SalTem).Value & "' and " & _
                                                         "ssr_salrep <> '" & dgSalRep.CurrentRow.Cells(dgSalRep_SalRep).Value & "' and " & _
                                                         "ssr_default = 'Y' and " & _
                                                         "ssr_del = ''")
                rs_SYSALREL.Tables("RESULT").Columns("ssr_default").ReadOnly = False
                If dr.Length > 0 Then
                    If dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y" Then
                        If MsgBox("A default Sales Rep has already been assigned." & Environment.NewLine & _
                          "Confirm to change default Sales Rep", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            dr(0).Item("ssr_default") = "N"
                            dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y"
                        Else
                            dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "N"
                        End If
                    End If
                Else
                    dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y"
                End If
                rs_SYSALREL.Tables("RESULT").Columns("ssr_default").ReadOnly = True

                dgSalRep.CurrentCell.Value = ""
                If dgSalRep.CurrentRow.Cells(dgSalRep_Status).Value = "~*DEL*~" Then
                    dgSalRep.CurrentRow.Cells(dgSalRep_Status).Value = "~*ADD*~"
                End If
            End If
            rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Del).ReadOnly = True
            rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Status).ReadOnly = True

            
            recordStatus = True
            cmdSave.Enabled = True
        ElseIf e.ColumnIndex = dgSalRep_Default Then
            If dgSalRep.CurrentRow.Cells(dgSalRep_Del).Value = "" Then
                If dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y" Then
                    MsgBox("Sales Team must have a default Sales Rep")
                    Exit Sub
                Else
                    dr = Nothing
                    dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & dgSalRep.CurrentRow.Cells(dgSalRep_SalTem).Value & "' and " & _
                                                             "ssr_salrep <> '" & dgSalRep.CurrentRow.Cells(dgSalRep_SalRep).Value & "' and " & _
                                                             "ssr_default = 'Y' and " & _
                                                             "ssr_del = ''")
                    rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Default).ReadOnly = False
                    If dr.Length > 0 Then

                        If MsgBox("A default Sales Rep has already been assigned." & Environment.NewLine & _
                          "Confirm to change default Sales Rep", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            dr(0).Item("ssr_default") = "N"
                            dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y"
                        Else
                            dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "N"
                        End If
                    Else
                        dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y"
                    End If
                    rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Default).ReadOnly = True
                End If
            End If

            recordStatus = True
            cmdSave.Enabled = True
        End If
    End Sub

    Private Sub dgSalMgr_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSalMgr.CellDoubleClick
        If cmdInsRow.Enabled = False Then
            Exit Sub
        End If

        Dim dr() As DataRow

        If e.ColumnIndex = dgSalMgr_Del Then
            rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Del).ReadOnly = False
            rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Status).ReadOnly = False
            If dgSalMgr.CurrentCell.Value = "" Then
                dgSalMgr.CurrentCell.Value = "Y"
                If dgSalMgr.CurrentRow.Cells(dgSalMgr_Status).Value = "~*ADD*~" Then
                    dgSalMgr.CurrentRow.Cells(dgSalMgr_Status).Value = "~*DEL*~"
                End If
            Else
                dr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & dgSalMgr.CurrentRow.Cells(dgSalMgr_SalDiv).Value & _
                                                             "' and ssi_salmgr <> '" & dgSalMgr.CurrentRow.Cells(dgSalMgr_SalMgr).Value & _
                                                             "' and ssi_del = ''")
                If dr.Length > 0 Then
                    MsgBox("Sales Division is already affiliated with another Sales Manager")
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Del).ReadOnly = True
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Status).ReadOnly = True
                    Exit Sub
                End If

                dgSalMgr.CurrentCell.Value = ""
                If dgSalMgr.CurrentRow.Cells(dgSalMgr_Status).Value = "~*DEL*~" Then
                    dgSalMgr.CurrentRow.Cells(dgSalMgr_Status).Value = "~*ADD*~"
                End If
            End If
            rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Del).ReadOnly = True
            rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Status).ReadOnly = True

            recordStatus = True
            cmdSave.Enabled = True
        End If
    End Sub

    Private Sub dgSalTeam_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSalTeam.CellDoubleClick
        If cmdInsRow.Enabled = False Then
            Exit Sub
        End If

        Dim dr() As DataRow

        If e.ColumnIndex = dgSalTeam_Del Then
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Del).ReadOnly = False
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Status).ReadOnly = False
            If dgSalTeam.CurrentCell.Value = "" Then
                dgSalTeam.CurrentCell.Value = "Y"
                If dgSalTeam.CurrentRow.Cells(dgSalTeam_Status).Value = "~*ADD*~" Then
                    dgSalTeam.CurrentRow.Cells(dgSalTeam_Status).Value = "~*DEL*~"
                End If
            Else
                dr = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_saltem = '" & dgSalTeam.CurrentRow.Cells(dgSalTeam_SalTem).Value & "' and " & _
                                                              "ssi_saldiv <> '" & dgSalTeam.CurrentRow.Cells(dgSalTeam_SalDiv).Value & "' and " & _
                                                              "ssi_del = ''")
                If dr.Length > 0 Then
                    MsgBox("Sales Team is already affiliated with another Sales Division")
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Del).ReadOnly = True
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Status).ReadOnly = True
                    Exit Sub
                End If

                dgSalTeam.CurrentCell.Value = ""
                If dgSalTeam.CurrentRow.Cells(dgSalTeam_Status).Value = "~*DEL*~" Then
                    dgSalTeam.CurrentRow.Cells(dgSalTeam_Status).Value = "~*ADD*~"
                End If
            End If
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Del).ReadOnly = True
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Status).ReadOnly = True

            recordStatus = True
            cmdSave.Enabled = True
        End If
    End Sub

    Private Sub cmdPanSalMngrInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalMngrInsert.Click
        If panSalMngr_Verify("INS") = False Then
            Exit Sub
        End If
        Dim count As Integer = rs_SYSALINF_MGR.Tables("RESULT").Rows.Count

        For i As Integer = 0 To rs_SYSALINF_MGR.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_MGR.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_SYSALINF_MGR.Tables("RESULT").Rows.Add()
        rs_SYSALINF_MGR.Tables("RESULT").Rows(count)("ssi_del") = ""
        rs_SYSALINF_MGR.Tables("RESULT").Rows(count)("ssi_saldiv") = Trim(Split(cboPanSalMngrSalDiv.Text, " - ")(0))
        rs_SYSALINF_MGR.Tables("RESULT").Rows(count)("ssi_salmgr") = Trim(Split(cboPanSalMngrSalMngr.Text, " - ")(0))
        rs_SYSALINF_MGR.Tables("RESULT").Rows(count)("ssi_usrnam") = Trim(Split(cboPanSalMngrSalMngr.Text, " - ")(1))
        rs_SYSALINF_MGR.Tables("RESULT").Rows(count)("ssi_status") = "~*ADD*~"

        For i As Integer = 0 To rs_SYSALINF_MGR.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_MGR.Tables("RESULT").Columns(i).ReadOnly = True
        Next

        dgSalMgr.ClearSelection()

        recordStatus = True
        cmdSave.Enabled = True
        cmdPanSalMngrCancel.PerformClick()
    End Sub

    Private Sub cmdPanSalMngrUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalMngrUpdate.Click
        If panSalMngr_Verify("UPD") = False Then
            Exit Sub
        End If

        For i As Integer = 0 To rs_SYSALINF_MGR.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_MGR.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        dgSalMgr.CurrentRow.Cells(dgSalMgr_Del).Value = ""
        dgSalMgr.CurrentRow.Cells(dgSalMgr_SalDiv).Value = Trim(Split(cboPanSalMngrSalDiv.Text, " - ")(0))
        dgSalMgr.CurrentRow.Cells(dgSalMgr_SalMgr).Value = Trim(Split(cboPanSalMngrSalMngr.Text, " - ")(0))
        dgSalMgr.CurrentRow.Cells(dgSalMgr_UsrNam).Value = Trim(Split(cboPanSalMngrSalMngr.Text, " - ")(1))
        dgSalMgr.CurrentRow.Cells(dgSalMgr_Status).Value = ""


        For i As Integer = 0 To rs_SYSALINF_MGR.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_MGR.Tables("RESULT").Columns(i).ReadOnly = True
        Next

        Dim dr() As DataRow = rs_SYSALREL.Tables("RESULT").Select("ssr_saldiv = '" & dgSalMgr.CurrentRow.Cells(dgSalMgr_SalDiv).Value & "'")
        If dr.Length > 0 Then
            rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = False
            For i As Integer = 0 To dr.Length - 1
                dr(i).Item("ssr_salmgr") = Trim(Split(cboPanSalMngrSalMngr.Text, " - ")(0))
            Next
            rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = True
        End If

        recordStatus = True
        cmdSave.Enabled = True
        cmdPanSalMngrCancel.PerformClick()
    End Sub

    Private Sub cmdPanSalMngrCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalMngrCancel.Click
        panSalMngr.Visible = False
        release_TabControl()
        grpSalMngr.Enabled = True
    End Sub

    Private Sub cmdPanSalTeamInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalTeamInsert.Click
        txtPanSalTeamSalTeam.Text = UCase(Trim(txtPanSalTeamSalTeam.Text))

        If panSalTeam_Verify("INS") = False Then
            Exit Sub
        End If
        Dim count As Integer = rs_SYSALINF_TEAM.Tables("RESULT").Rows.Count

        For i As Integer = 0 To rs_SYSALINF_TEAM.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_SYSALINF_TEAM.Tables("RESULT").Rows.Add()
        rs_SYSALINF_TEAM.Tables("RESULT").Rows(count)("ssi_del") = ""
        rs_SYSALINF_TEAM.Tables("RESULT").Rows(count)("ssi_saldiv") = Trim(Split(cboPanSalTeamSalDiv.Text, " - ")(0))
        rs_SYSALINF_TEAM.Tables("RESULT").Rows(count)("ssi_saltem") = Trim(txtPanSalTeamSalTeam.Text)
        rs_SYSALINF_TEAM.Tables("RESULT").Rows(count)("ssi_status") = "~*ADD*~"

        For i As Integer = 0 To rs_SYSALINF_TEAM.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(i).ReadOnly = True
        Next

        dgSalTeam.ClearSelection()

        recordStatus = True
        cmdSave.Enabled = True
        cmdPanSalTeamCancel.PerformClick()
    End Sub

    Private Sub cmdPanSalTeamUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalTeamUpdate.Click
        txtPanSalTeamSalTeam.Text = UCase(Trim(txtPanSalTeamSalTeam.Text))

        If panSalTeam_Verify("UPD") = False Then
            Exit Sub
        End If

        For i As Integer = 0 To rs_SYSALINF_TEAM.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        dgSalTeam.CurrentRow.Cells(dgSalTeam_Del).Value = ""
        dgSalTeam.CurrentRow.Cells(dgSalTeam_SalDiv).Value = Trim(Split(cboPanSalTeamSalDiv.Text, " - ")(0))
        dgSalTeam.CurrentRow.Cells(dgSalTeam_SalTem).Value = Trim(txtPanSalTeamSalTeam.Text)
        dgSalTeam.CurrentRow.Cells(dgSalTeam_Status).Value = ""

        For i As Integer = 0 To rs_SYSALINF_TEAM.Tables("RESULT").Columns.Count - 1
            rs_SYSALINF_TEAM.Tables("RESULT").Columns(i).ReadOnly = True
        Next

        ' Update Related Sales Rep entries with new updated Sales Division / Manager Based on Sales Team
        Dim dr_SYSALREL() As DataRow
        dr_SYSALREL = Nothing
        dr_SYSALREL = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Trim(txtPanSalTeamSalTeam.Text) & "'")
        If dr_SYSALREL.Length > 0 Then
            Dim dr_SALMGR() As DataRow = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Trim(Split(cboPanSalTeamSalDiv.Text, " - ")(0)) & "' and ssi_del <> 'Y'")
            If dr_SALMGR.Length > 0 Then
                rs_SYSALREL.Tables("RESULT").Columns("ssr_saldiv").ReadOnly = False
                rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = False
                For i As Integer = 0 To dr_SYSALREL.Length - 1
                    dr_SYSALREL(i).Item("ssr_saldiv") = dr_SALMGR(0).Item("ssi_saldiv")
                    dr_SYSALREL(i).Item("ssr_salmgr") = dr_SALMGR(0).Item("ssi_salmgr")
                Next
                rs_SYSALREL.Tables("RESULT").Columns("ssr_saldiv").ReadOnly = True
                rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = True
            End If
        End If

        recordStatus = True
        cmdSave.Enabled = True
        cmdPanSalTeamCancel.PerformClick()
    End Sub

    Private Sub cmdPanSalTeamCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalTeamCancel.Click
        panSalTeam.Visible = False
        release_TabControl()
        grpSalTeam.Enabled = True
    End Sub

    Private Sub cmdPanSalRepInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalRepInsert.Click
        If panSalRep_Verify("INS") = False Then
            Exit Sub
        End If
        Dim count As Integer = rs_SYSALREL.Tables("RESULT").Rows.Count
        Dim dr() As DataRow
        Dim dr_mgr() As DataRow

        For i As Integer = 0 To rs_SYSALREL.Tables("RESULT").Columns.Count - 1
            rs_SYSALREL.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_SYSALREL.Tables("RESULT").Rows.Add()
        rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_del") = ""
        dr = Nothing
        dr = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and ssi_del = ''")
        dr_mgr = Nothing
        dr_mgr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & dr(0).Item("ssi_saldiv") & "' and ssi_del = ''")

        rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_saldiv") = dr(0).Item("ssi_saldiv")
        rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_salmgr") = dr_mgr(0).Item("ssi_salmgr")
        rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_saltem") = Split(cboPanSalRepSalTeam.Text, " - ")(0)
        rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_salrep") = Split(cboPanSalRepSalRep.Text, " - ")(0)
        rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_usrnam") = Split(cboPanSalRepSalRep.Text, " - ")(1)


        dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
                                                 "ssr_default = 'Y'")
        If dr.Length = 0 Then
            rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_default") = "Y"
        Else
            If chkPanSalRepDefault.Checked = True Then
                If MsgBox("A default Sales Rep has already been assigned." & Environment.NewLine & _
                          "Confirm to change default Sales Rep", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    dr(0).Item("ssr_default") = "N"
                    rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_default") = "Y"
                Else
                    rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_default") = "N"
                End If
            Else
                rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_default") = "N"
            End If
        End If
        rs_SYSALREL.Tables("RESULT").Rows(count)("ssr_status") = "~*ADD*~"

        For i As Integer = 0 To rs_SYSALREL.Tables("RESULT").Columns.Count - 1
            rs_SYSALREL.Tables("RESULT").Columns(i).ReadOnly = True
        Next

        recordStatus = True
        cmdSave.Enabled = True
        cmdPanSalRepCancel.PerformClick()
    End Sub

    'Private Sub cmdPanSalRepUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If panSalRep_Verify("UPD") = False Then
    '        Exit Sub
    '    End If

    '    Dim dr() As DataRow

    '    For i As Integer = 0 To rs_SYSALREL.Tables("RESULT").Columns.Count - 1
    '        rs_SYSALREL.Tables("RESULT").Columns(i).ReadOnly = False
    '    Next

    '    dgSalRep.CurrentRow.Cells(dgSalRep_Del).Value = ""
    '    dr = Nothing
    '    dr = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
    '                                                  "ssi_del = ''")
    '    dgSalRep.CurrentRow.Cells(dgSalRep_SalDiv).Value = dr(0).Item("ssi_saldiv")
    '    dgSalRep.CurrentRow.Cells(dgSalRep_SalTem).Value = Split(cboPanSalRepSalTeam.Text, " - ")(0)
    '    dgSalRep.CurrentRow.Cells(dgSalRep_SalRep).Value = Split(cboPanSalRepSalRep.Text, " - ")(0)
    '    dgSalRep.CurrentRow.Cells(dgSalRep_UsrNam).Value = Split(cboPanSalRepSalRep.Text, " - ")(1)
    '    dr = Nothing
    '    dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
    '                                             "ssr_default = 'Y'")
    '    If dr.Length = 0 Then
    '        dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y"
    '    Else
    '        If chkPanSalRepDefault.Checked = True Then
    '            If MsgBox("The selected Sales Team already has a default Sales Rep." & Environment.NewLine & _
    '                      "Confirm to change default Sales Rep", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                dr(0).Item("ssr_default") = "N"
    '                dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "Y"
    '            End If
    '        Else
    '            dgSalRep.CurrentRow.Cells(dgSalRep_Default).Value = "N"
    '        End If
    '    End If
    '    dgSalRep.CurrentRow.Cells(dgSalMgr_Status).Value = ""

    '    For i As Integer = 0 To rs_SYSALREL.Tables("RESULT").Columns.Count - 1
    '        rs_SYSALREL.Tables("RESULT").Columns(i).ReadOnly = True
    '    Next

    '    recordStatus = True
    '    cmdSave.Enabled = True
    '    cmdPanSalRepCancel.PerformClick()
    'End Sub

    Private Sub cmdPanSalRepCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanSalRepCancel.Click
        panSalRep.Visible = False
        release_TabControl()
        grpSalRep.Enabled = True
    End Sub

    Private Sub comboboxValidation(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPanSalRepSalRep.Validating, cboPanSalTeamSalDiv.Validating, cboPanSalRepSalTeam.Validating, cboPanSalMngrSalMngr.Validating, cboPanSalMngrSalDiv.Validating
        If sender.Text <> "" Then
            If sender.Items.Contains(sender.Text) = False Then
                e.Cancel = True
                MsgBox("Input does not exist from the specified choices")
            End If
        End If
    End Sub

    Private Sub autoSearch_combobox(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPanSalRepSalRep.KeyUp, cboPanSalRepSalTeam.KeyUp, cboPanSalMngrSalMngr.KeyUp, cboPanSalMngrSalDiv.KeyUp, cboPanSalTeamSalDiv.KeyUp
        If sender.Text <> "" And (e.KeyValue <> 8) Then
            auto_search_combo(sender)
        End If
    End Sub

    Private Function panSalRep_Verify(ByVal mode As String) As Boolean
        If cboPanSalRepSalTeam.Text = "" Then
            MsgBox("Sales Team cannot be empty")
            Return False
        End If

        If cboPanSalRepSalTeam.Items.Contains(cboPanSalRepSalTeam.Text) = False Then
            MsgBox("The selected Sales Team is no longer available")
            Return False
        End If

        If cboPanSalRepSalRep.Text = "" Then
            MsgBox("Sales Rep cannot be empty")
            Return False
        End If

        If cboPanSalRepSalRep.Items.Contains(cboPanSalRepSalRep.Text) = False Then
            MsgBox("The selected Sales Rep is no longer available")
            Return False
        End If

        Dim dr() As DataRow
        Dim dr_default() As DataRow

        If mode = "INS" Then
            If rs_SYSALREL.Tables("RESULT").Rows.Count = 0 Then
                Return True
            End If

            dr = Nothing
            dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
                                                     "ssr_salrep = '" & Split(cboPanSalRepSalRep.Text, " - ")(0) & "' and " & _
                                                     "ssr_del = ''")
            If dr.Length > 0 Then
                MsgBox("Sales Team / Sales Rep already exists")
                Return False
            Else
                dr = Nothing
                dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
                                                     "ssr_salrep = '" & Split(cboPanSalRepSalRep.Text, " - ")(0) & "'")
                If dr.Length = 0 Then
                    Return True
                Else
                    If dr(0).Item("ssr_del") = "Y" Then
                        dr_default = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
                                                                 "ssr_default = 'Y'")
                        rs_SYSALREL.Tables("RESULT").Columns("ssr_default").ReadOnly = False
                        If dr_default.Length > 0 Then
                            If chkPanSalRepDefault.Checked = True Then
                                If MsgBox("A default Sales Rep has already been assigned." & Environment.NewLine & _
                                      "Confirm to change default Sales Rep", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                    dr_default(0).Item("ssr_default") = "N"
                                    dr(0).Item("ssr_default") = "Y"
                                Else
                                    dr(0).Item("ssr_default") = "N"
                                End If
                            Else
                                dr(0).Item("ssr_default") = "N"
                            End If
                        Else
                            dr(0).Item("ssr_default") = "Y"
                        End If
                        rs_SYSALREL.Tables("RESULT").Columns("ssr_default").ReadOnly = True

                        rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Del).ReadOnly = False
                        rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Status).ReadOnly = False
                        dr(0).Item("ssr_del") = ""
                        If dr(0).Item("ssr_status").ToString = "~*DEL*~" Then
                            dr(0).Item("ssr_status") = "~*ADD*~"
                        End If
                        rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Del).ReadOnly = True
                        rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Status).ReadOnly = True

                        recordStatus = True
                        cmdSave.Enabled = True
                        cmdPanSalRepCancel.PerformClick()
                        Return False
                    Else
                        Return False
                    End If
                End If
            End If
        ElseIf mode = "UPD" Then
            If rs_SYSALREL.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No entry is selected")
                Return False
            End If

            dr = Nothing
            dr = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
                                                     "ssr_salrep = '" & Split(cboPanSalRepSalRep.Text, " - ")(0) & "'")
            If dr.Length = 0 Then
                Return True
            Else
                If dr(0).Item("ssr_del") = "" Then
                    MsgBox("Sales Team / Sales Rep already exists")
                    Return False
                End If

                dr_default = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Split(cboPanSalRepSalTeam.Text, " - ")(0) & "' and " & _
                                                                 "ssr_default = 'Y'")
                rs_SYSALREL.Tables("RESULT").Columns("ssr_default").ReadOnly = False
                If dr_default.Length = 0 Then
                    dr(0).Item("ssr_default") = "Y"
                Else
                    If chkPanSalRepDefault.Checked = True Then
                        If MsgBox("A default Sales Rep has already been assigned." & Environment.NewLine & _
                              "Confirm to change default Sales Rep", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            dr_default(0).Item("ssr_default") = "N"
                            dr(0).Item("ssr_default") = "Y"
                        Else
                            dr(0).Item("ssr_default") = "N"
                        End If
                    Else
                        dr(0).Item("ssr_default") = "N"
                    End If
                End If
                rs_SYSALREL.Tables("RESULT").Columns("ssr_default").ReadOnly = True

                rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Del).ReadOnly = False
                rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Status).ReadOnly = False
                dr(0).Item("ssr_del") = ""
                If dr(0).Item("ssr_status").ToString = "~*DEL*~" Then
                    dr(0).Item("ssr_status") = "~*ADD*~"
                End If
                rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Del).ReadOnly = True
                rs_SYSALREL.Tables("RESULT").Columns(dgSalRep_Status).ReadOnly = True

                recordStatus = True
                cmdSave.Enabled = True
                cmdPanSalRepCancel.PerformClick()
                Return False
            End If
        End If
    End Function

    Private Function panSalMngr_Verify(ByVal mode As String) As Boolean
        If cboPanSalMngrSalDiv.Text = "" Then
            MsgBox("Sales Division cannot be empty")
            Return False
        End If

        If cboPanSalMngrSalDiv.Items.Contains(cboPanSalMngrSalDiv.Text) = False Then
            MsgBox("The selected Sales Division is no longer available")
            Return False
        End If

        If cboPanSalMngrSalMngr.Text = "" Then
            MsgBox("Sales Manager cannot be empty")
            Return False
        End If

        If cboPanSalMngrSalMngr.Items.Contains(cboPanSalMngrSalMngr.Text) = False Then
            MsgBox("The selected Sales Manager is no longer available")
            Return False
        End If

        Dim dr() As DataRow
        Dim dr_SYSALREL() As DataRow

        If mode = "INS" Then
            If rs_SYSALINF_MGR.Tables("RESULT").Rows.Count = 0 Then
                Return True
            End If

            dr = Nothing
            dr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Split(cboPanSalMngrSalDiv.Text, " - ")(0) & "'")
            If dr.Length = 0 Then
                Return True
            End If

            dr = Nothing
            dr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Split(cboPanSalMngrSalDiv.Text, " - ")(0) & "' and " & _
                                                         "ssi_salmgr <> '" & Split(cboPanSalMngrSalMngr.Text, " - ")(0) & "' and " & _
                                                         "ssi_del = ''")
            If dr.Length > 0 Then
                MsgBox("Sales Division is already affiliated with another Sales Manager")
                Return False
            End If

            dr = Nothing
            dr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Split(cboPanSalMngrSalDiv.Text, " - ")(0) & "' and " & _
                                                         "ssi_salmgr = '" & Split(cboPanSalMngrSalMngr.Text, " - ")(0) & "'")
            If dr.Length = 0 Then
                Return True
            Else
                If dr(0).Item("ssi_del") = "" Then
                    MsgBox("Sales Division / Sales Manager already exists")
                    Return False
                Else
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Del).ReadOnly = False
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Status).ReadOnly = False
                    dr(0).Item("ssi_del") = ""
                    If dr(0).Item("ssi_status").ToString = "~*DEL*~" Then
                        dr(0).Item("ssi_status") = "~*ADD*~"
                    End If
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Del).ReadOnly = True
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Status).ReadOnly = True

                    dr_SYSALREL = Nothing
                    dr_SYSALREL = rs_SYSALREL.Tables("RESULT").Select("ssr_saldiv = '" & Split(cboPanSalMngrSalMngr.Text, " - ")(0) & "'")
                    If dr_SYSALREL.Length > 0 Then
                        rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = False
                        For i As Integer = 0 To dr_SYSALREL.Length - 1
                            dr_SYSALREL(i).Item("ssr_salmgr") = Trim(Split(cboPanSalMngrSalMngr.Text, " - ")(0))
                        Next
                        rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = True
                    End If

                    recordStatus = True
                    cmdSave.Enabled = True
                    cmdPanSalMngrCancel.PerformClick()
                    Return False
                End If
            End If
        ElseIf mode = "UPD" Then
            If rs_SYSALINF_MGR.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No entry is selected")
                Return False
            End If

            dr = Nothing
            dr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Split(cboPanSalMngrSalDiv.Text, " - ")(0) & "' and " & _
                                                         "ssi_salmgr <> '" & Split(cboPanSalMngrSalMngr.Text, " - ")(0) & "' and " & _
                                                         "ssi_salmgr <> '" & dgSalMgr.CurrentRow.Cells(dgSalMgr_SalMgr).Value & "' and " & _
                                                         "ssi_del = ''")
            If dr.Length > 0 Then
                MsgBox("Sales Division is already affiliated with another Sales Manager")
                Return False
            End If

            dr = Nothing
            dr = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Split(cboPanSalMngrSalDiv.Text, " - ")(0) & "' and " & _
                                                         "ssi_salmgr = '" & Split(cboPanSalMngrSalMngr.Text, " - ")(0) & "'")
            If dr.Length > 0 Then
                If dr(0).Item("ssi_del") = "" Then
                    MsgBox("Sales Division / Sales Manager already exists")
                    Return False
                Else
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Del).ReadOnly = False
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Status).ReadOnly = False
                    If dr(0).Item("ssi_salmgr").ToString <> dgSalMgr.CurrentRow.Cells(dgSalMgr_SalMgr).Value.ToString Then
                        dgSalMgr.CurrentRow.Cells(dgSalMgr_Del).Value = "Y"
                        If dgSalMgr.CurrentRow.Cells(dgSalMgr_Status).Value = "~*ADD*~" Then
                            dgSalMgr.CurrentRow.Cells(dgSalMgr_Status).Value = "~*DEL*~"
                        End If
                    End If

                    dr(0).Item("ssi_del") = ""
                    If dr(0).Item("ssi_status").ToString = "~*DEL*~" Then
                        dr(0).Item("ssi_status") = "~*ADD*~"
                    End If
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Del).ReadOnly = True
                    rs_SYSALINF_MGR.Tables("RESULT").Columns(dgSalMgr_Status).ReadOnly = True

                    dr_SYSALREL = Nothing
                    dr_SYSALREL = rs_SYSALREL.Tables("RESULT").Select("ssr_saldiv = '" & Split(cboPanSalMngrSalMngr.Text, " - ")(0) & "'")
                    If dr_SYSALREL.Length > 0 Then
                        rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = False
                        For i As Integer = 0 To dr_SYSALREL.Length - 1
                            dr_SYSALREL(i).Item("ssr_salmgr") = Trim(Split(cboPanSalMngrSalMngr.Text, " - ")(0))
                        Next
                        rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = True
                    End If

                    recordStatus = True
                    cmdSave.Enabled = True
                    cmdPanSalMngrCancel.PerformClick()
                    Return False
                End If
            Else
                    Return True
            End If
        End If
    End Function

    Private Function panSalTeam_Verify(ByVal mode As String) As Boolean
        If cboPanSalTeamSalDiv.Text = "" Then
            MsgBox("Sales Division cannot be empty")
            Return False
        End If

        If cboPanSalTeamSalDiv.Items.Contains(cboPanSalTeamSalDiv.Text) = False Then
            MsgBox("The selected Sales Division is no longer available")
            Return False
        End If

        Dim dr() As DataRow

        If mode = "INS" Then
            If rs_SYSALINF_TEAM.Tables("RESULT").Rows.Count = 0 Then
                Return True
            End If

            dr = Nothing
            dr = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_saldiv <> '" & Split(cboPanSalTeamSalDiv.Text, " - ")(0) & "' and " & _
                                                          "ssi_saltem = '" & Trim(txtPanSalTeamSalTeam.Text) & "' and " & _
                                                          "ssi_del = ''")
            If dr.Length > 0 Then
                MsgBox("Sales Team is already affiliated with another Sales Division")
                Return False
            End If

            dr = Nothing
            dr = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_saldiv = '" & Split(cboPanSalTeamSalDiv.Text, " - ")(0) & "' and " & _
                                                          "ssi_saltem = '" & Trim(txtPanSalTeamSalTeam.Text) & "'")
            If dr.Length = 0 Then
                Return True
            Else
                If dr(0).Item("ssi_del").ToString = "Y" Then
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Del).ReadOnly = False
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Status).ReadOnly = False
                    dr(0).Item("ssi_del") = ""
                    If dr(0).Item("ssi_status").ToString = "~*DEL*~" Then
                        dr(0).Item("ssi_status") = "~*ADD*~"
                    End If
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Del).ReadOnly = True
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Status).ReadOnly = True

                    ' Update Related Sales Rep entries with new updated Sales Division / Manager Based on Sales Team
                    Dim dr_SYSALREL() As DataRow
                    dr_SYSALREL = Nothing
                    dr_SYSALREL = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Trim(txtPanSalTeamSalTeam.Text) & "'")
                    If dr_SYSALREL.Length > 0 Then
                        Dim dr_SALMGR() As DataRow = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Trim(Split(cboPanSalTeamSalDiv.Text, " - ")(0)) & "' and ssi_del <> 'Y'")
                        If dr_SALMGR.Length > 0 Then
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_saldiv").ReadOnly = False
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = False
                            For i As Integer = 0 To dr_SYSALREL.Length - 1
                                dr_SYSALREL(i).Item("ssr_saldiv") = dr_SALMGR(0).Item("ssi_saldiv")
                                dr_SYSALREL(i).Item("ssr_salmgr") = dr_SALMGR(0).Item("ssi_salmgr")
                            Next
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_saldiv").ReadOnly = True
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = True
                        End If
                    End If

                    recordStatus = True
                    cmdSave.Enabled = True
                    cmdPanSalTeamCancel.PerformClick()
                    Return False
                Else
                    MsgBox("Sales Division / Sales Team already exists")
                    Return False
                End If
            End If
        ElseIf mode = "UPD" Then
            If rs_SYSALINF_TEAM.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No entry is selected")
                Return False
            End If

            dr = Nothing
            dr = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_saldiv <> '" & dgSalTeam.CurrentRow.Cells(dgSalTeam_SalDiv).Value & "' and " & _
                                                          "ssi_saltem = '" & Trim(txtPanSalTeamSalTeam.Text) & "' and " & _
                                                          "ssi_del = ''")
            If dr.Length > 0 Then
                MsgBox("Sales Team is already affiliated with another Sales Division")
                Return False
            End If

            dr = Nothing
            dr = rs_SYSALINF_TEAM.Tables("RESULT").Select("ssi_saldiv = '" & Split(cboPanSalTeamSalDiv.Text, " - ")(0) & "' and " & _
                                                          "ssi_saltem = '" & Trim(txtPanSalTeamSalTeam.Text) & "'")
            If dr.Length = 0 Then
                Return True
            Else
                If dr(0).Item("ssi_del").ToString = "Y" Then
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Del).ReadOnly = False
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Status).ReadOnly = False
                    dr(0).Item("ssi_del") = ""
                    If dr(0).Item("ssi_status").ToString = "~*DEL*~" Then
                        dr(0).Item("ssi_status") = "~*ADD*~"
                    End If
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Del).ReadOnly = True
                    rs_SYSALINF_TEAM.Tables("RESULT").Columns(dgSalTeam_Status).ReadOnly = True

                    ' Update Related Sales Rep entries with new updated Sales Division / Manager Based on Sales Team
                    Dim dr_SYSALREL() As DataRow
                    dr_SYSALREL = Nothing
                    dr_SYSALREL = rs_SYSALREL.Tables("RESULT").Select("ssr_saltem = '" & Trim(txtPanSalTeamSalTeam.Text) & "'")
                    If dr_SYSALREL.Length > 0 Then
                        Dim dr_SALMGR() As DataRow = rs_SYSALINF_MGR.Tables("RESULT").Select("ssi_saldiv = '" & Trim(Split(cboPanSalTeamSalDiv.Text, " - ")(0)) & "' and ssi_del <> 'Y'")
                        If dr_SALMGR.Length > 0 Then
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_saldiv").ReadOnly = False
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = False
                            For i As Integer = 0 To dr_SYSALREL.Length - 1
                                dr_SYSALREL(i).Item("ssr_saldiv") = dr_SALMGR(0).Item("ssi_saldiv")
                                dr_SYSALREL(i).Item("ssr_salmgr") = dr_SALMGR(0).Item("ssi_salmgr")
                            Next
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_saldiv").ReadOnly = True
                            rs_SYSALREL.Tables("RESULT").Columns("ssr_salmgr").ReadOnly = True
                        End If
                    End If

                    recordStatus = True
                    cmdSave.Enabled = True
                    cmdPanSalTeamCancel.PerformClick()
                    Return False
                Else
                    MsgBox("Sales Division / Sales Team already exists")
                    Return False
                End If
            End If
        End If
    End Function

    Private Sub enable_DropDownCombo(ByVal combo As ComboBox, ByVal mode As Boolean)
        If mode = True Then
            combo.Enabled = True
            combo.DropDownStyle = ComboBoxStyle.DropDown
        Else
            combo.DropDownStyle = ComboBoxStyle.DropDownList
            combo.Enabled = False
        End If
    End Sub

    Private Sub cmdSave_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.EnabledChanged
        If cmdSave.Enabled = True Then
            cmdClear.Enabled = True
        Else
            cmdClear.Enabled = False
        End If
    End Sub

    Private Function SaveSalesRep() As Boolean
        Dim dr() As DataRow

        For i As Integer = 0 To rs_SYSALREL.Tables("RESULT").Rows.Count - 1
            If rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_del") = "Y" Then
                gspStr = "sp_physical_delete_SYSALREL '','" & Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_saltem"), "'", "''") & _
                         "','" & Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_salrep"), "'", "''") & "','" & gsUsrID & "'"
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on saving SaveSalesRep #001 sp_physical_delete_SYSALREL :" & rtnStr)
                    Return False
                End If
            Else
                dr = Nothing
                dr = rs_SYSALREL_load.Tables("RESULT").Select("ssr_saltem = '" & rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_saltem") & "' and " & _
                                                              "ssr_salrep = '" & rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_salrep") & "'")
                If dr.Length > 0 Then
                    ' Check if update is necessary
                    Dim flag_Update As Boolean = False
                    For j As Integer = 1 To rs_SYSALREL.Tables("RESULT").Columns.Count - 2
                        If dr(0).Item(j).ToString <> rs_SYSALREL.Tables("RESULT").Rows(i)(j).ToString Then
                            flag_Update = True
                            Exit For
                        End If
                    Next

                    If flag_Update = True Then
                        gspStr = "sp_update_SYSALREL '','" & Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_saltem"), "'", "''") & "','" & _
                                 Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_saldiv"), "'", "''") & "','" & _
                                 Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_salmgr"), "'", "''") & "','" & _
                                 Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_salrep"), "'", "''") & "','" & _
                                 Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_default"), "'", "''") & "','" & gsUsrID & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on saving SaveSalesRep #002 sp_update_SYSALREL :" & rtnStr)
                            Return False
                        End If
                    End If
                Else
                    ' Insert New Entry
                    gspStr = "sp_insert_SYSALREL '','" & Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_saltem"), "'", "''") & "','" & _
                             Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_saldiv"), "'", "''") & "','" & _
                             Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_salmgr"), "'", "''") & "','" & _
                             Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_salrep"), "'", "''") & "','" & _
                             Replace(rs_SYSALREL.Tables("RESULT").Rows(i)("ssr_default"), "'", "''") & "','" & gsUsrID & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on saving SaveSalesRep #003 sp_insert_SYSALREL :" & rtnStr)
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Function SaveSalesMgr() As Boolean
        Dim dr() As DataRow

        For i As Integer = 0 To rs_SYSALINF_MGR.Tables("RESULT").Rows.Count - 1
            If rs_SYSALINF_MGR.Tables("RESULT").Rows(i)("ssi_del") = "Y" Then
                ' Delete Entry
                gspStr = "sp_physical_delete_SYSALINF_MGR '','" & Replace(rs_SYSALINF_MGR.Tables("RESULT").Rows(i)("ssi_saldiv"), "'", "''") & "','" & gsUsrID & "'"
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on saving SaveSalesMgr #001 sp_physical_delete_SYSALINF_MGR :" & rtnStr)
                    Return False
                End If
            Else
                dr = Nothing
                dr = rs_SYSALINF_MGR_load.Tables("RESULT").Select("ssi_saldiv = '" & rs_SYSALINF_MGR.Tables("RESULT").Rows(i)("ssi_saldiv") & "'")
                If dr.Length > 0 Then
                    ' Check if update is necessary
                    Dim flag_Update As Boolean = False
                    For j As Integer = 1 To rs_SYSALINF_MGR.Tables("RESULT").Columns.Count - 2
                        If dr(0).Item(j).ToString <> rs_SYSALINF_MGR.Tables("RESULT").Rows(i)(j).ToString Then
                            flag_Update = True
                            Exit For
                        End If
                    Next

                    If flag_Update = True Then
                        gspStr = "sp_update_SYSALINF_MGR '','" & Replace(rs_SYSALINF_MGR.Tables("RESULT").Rows(i)("ssi_saldiv"), "'", "''") & "','" & _
                                 Replace(rs_SYSALINF_MGR.Tables("RESULT").Rows(i)("ssi_salmgr"), "'", "''") & "','" & gsUsrID & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on saving SaveSalesMgr #002 sp_update_SYSALINF_MGR :" & rtnStr)
                            Return False
                        End If
                    End If
                Else
                    ' Insert New Entry
                    gspStr = "sp_insert_SYSALINF_MGR '','" & Replace(rs_SYSALINF_MGR.Tables("RESULT").Rows(i)("ssi_saldiv"), "'", "''") & "','" & _
                             Replace(rs_SYSALINF_MGR.Tables("RESULT").Rows(i)("ssi_salmgr"), "'", "''") & "','" & gsUsrID & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on saving SaveSalesMgr #003 sp_insert_SYSALINF_MGR :" & rtnStr)
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Function SaveSalesTeam() As Boolean
        Dim dr() As DataRow

        For i As Integer = 0 To rs_SYSALINF_TEAM.Tables("RESULT").Rows.Count - 1
            If rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_del") = "Y" Then
                ' Delete Entry
                gspStr = "sp_physical_delete_SYSALINF_TEAM '','" & Replace(rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_saltem"), "'", "''") & "','" & gsUsrID & "'"
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on saving SaveSalesTeam #001 sp_physical_delete_SYSALINF_TEAM :" & rtnStr)
                    Return False
                End If
            Else
                dr = Nothing
                dr = rs_SYSALINF_TEAM_load.Tables("RESULT").Select("ssi_saltem = '" & rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_saltem") & "'")
                If dr.Length > 0 Then
                    ' Check if update is necessary
                    Dim flag_update As Boolean = False
                    For j As Integer = 1 To rs_SYSALINF_TEAM.Tables("RESULT").Columns.Count - 2
                        ' Update if discrepency is found between load and save
                        If dr(0).Item(j).ToString <> rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)(j).ToString Then
                            flag_update = True
                            Exit For
                        End If
                    Next
                    If flag_update = True Then
                        gspStr = "sp_update_SYSALINF_TEAM '','" & Replace(rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_saldiv"), "'", "''") & "','" & _
                                 Replace(rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_saltem"), "'", "''") & "','" & gsUsrID & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on saving SaveSalesTeam #002 sp_update_SYSALINF_TEAM :" & rtnStr)
                            Return False
                        End If
                    End If
                Else
                    ' Insert New Entry
                    gspStr = "sp_insert_SYSALINF_TEAM '','" & Replace(rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_saldiv"), "'", "''") & "','" & _
                             Replace(rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_saltem"), "'", "''") & "','" & gsUsrID & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnLong)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on saving SaveSalesTeam #003 sp_insert_SYSALINF_TEAM :" & rtnStr)
                        Return False
                    End If
                End If
            End If
        Next
        Return True
    End Function

    Private Sub cboSalesTeam_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesTeam.SelectionChangeCommitted
        Select Case sender.Text
            Case "[ALL]"
                rs_SYSALREL.Tables("RESULT").DefaultView.RowFilter = ""
            Case Else
                rs_SYSALREL.Tables("RESULT").DefaultView.RowFilter = "ssr_saltem = '" & sender.Text & "'"
        End Select
    End Sub

    Private Sub tabFrame_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tabFrame.Selecting
        If e.TabPageIndex = 0 Then
            Dim team As String = cboSalesTeam.Text

            cboSalesTeam.Items.Clear()
            cboSalesTeam.Items.Add("[ALL]")
            For i As Integer = 0 To rs_SYSALINF_TEAM.Tables("RESULT").Rows.Count - 1
                cboSalesTeam.Items.Add(rs_SYSALINF_TEAM.Tables("RESULT").Rows(i)("ssi_saltem"))
            Next
            cboSalesTeam.Sorted = True
            display_combo(team, cboSalesTeam)
        End If
    End Sub
End Class