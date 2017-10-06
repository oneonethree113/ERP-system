
Public Class QUM00005
    Inherits System.Windows.Forms.Form

    Public rs_SYMUSRCO As New DataSet
    Public rs_QUM00005_HDR As New DataSet
    Public rs_QUM00005_DTL As New DataSet
    Public rs_QUM00005_HDR_AppList As New DataSet
    Public rs_QUM00005_DTL_AppList As New DataSet
    Public rs_QUM00005_HDR_update As New DataSet
    Public rs_QUM00005_DTL_update As New DataSet

    Dim dsNewRow As DataRow
    Dim mode As String
    Dim bInDTL As Boolean = False
    Dim flag_detail_click As Boolean



    Private Sub QUM00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            flag_detail_click = False


            gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading QUM00005_Load sp_select_SYMUSRCO : " & rtnStr)
            Else
                Dim strCocde As String

                strCocde = ""

                If rs_SYMUSRCO.Tables("RESULT").Rows.Count > 0 Then
                    For i As Integer = 0 To rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1
                        If rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") <> "MS" Then
                            If i <> rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1 Then
                                strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") + ","
                            Else
                                strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde")
                            End If
                        End If
                    Next i
                End If

                txt_S_CoCde.Text = strCocde
            End If

            txt_S_QuCreDateFm.Text = Today.AddMonths(-1)
            txt_S_QuCreDateTo.Text = Today


            txt_S_QuCreDateFm.Text = Format(CDate(txt_S_QuCreDateFm.Text), "MM/dd/yyyy")
            txt_S_QuCreDateTo.Text = Format(CDate(txt_S_QuCreDateTo.Text), "MM/dd/yyyy")



            mode = "INIT"
            Call formInit(mode)

            Formstartup(Name)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            cmdClear.Enabled = True

            cmdSearch.Enabled = False

            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False

            cmdExit.Enabled = True

            btcQUM00005.TabPages(0).Enabled = True
            btcQUM00005.TabPages(1).Enabled = True
            btcQUM00005.TabPages(1).Enabled = False
            btcQUM00005.TabPages(2).Enabled = True
            btcQUM00005.TabPages(2).Enabled = False
            btcQUM00005.SelectedIndex = 0

            rs_QUM00005_HDR.Clear()
            rs_QUM00005_DTL.Clear()
            dgHeader.ClearSelection()
            dgDetail.ClearSelection()

            rs_QUM00005_HDR_AppList.Clear()
            rs_QUM00005_DTL_AppList.Clear()
            dgHDRApproved.ClearSelection()
            dgDTLApproved.ClearSelection()

            txtHDRResult.Items.Clear()
            txtDTLResult.Items.Clear()
        ElseIf m = "MODIFY" Then
            cmdAdd.Enabled = False
            '20130909 cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True

            cmdSearch.Enabled = False

            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = True
            cmdPrevious.Enabled = True
            cmdNext.Enabled = True
            cmdLast.Enabled = True

            cmdExit.Enabled = True

            btcQUM00005.TabPages(0).Enabled = False
            btcQUM00005.TabPages(1).Enabled = False
            btcQUM00005.TabPages(1).Enabled = True
            btcQUM00005.TabPages(2).Enabled = False
            btcQUM00005.TabPages(2).Enabled = True

            btcQUM00005.SelectedIndex = 1
        End If
    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Name
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_frmS(cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

        frmComSearch.show_frmS(cmd_S_SecCust)
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        Dim QUNOLIST As String
        Dim ITMNOLIST As String
        Dim QUCREDATFM As String
        Dim QUCREDATTO As String

        flag_detail_click = False

        If Trim(txt_S_CoCde.Text) = "" Then
            MsgBox("The Company Code List is empty!")
            Exit Sub
        Else
            If Len(txt_S_CoCde.Text) > 1000 Then
                MsgBox("The Company Code List is too long (1000 char)")
                Exit Sub
            End If
            COCDELIST = Trim(txt_S_CoCde.Text)
            COCDELIST = Replace(COCDELIST, "'", "''")
        End If

        If Trim(txt_S_PriCust.Text) = "" Then
            MsgBox("The Primary Customer Number List is empty!")
            Exit Sub

            CUS1NOLIST = ""
        Else
            If Len(txt_S_PriCust.Text) > 1000 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                Exit Sub
            End If
            CUS1NOLIST = Trim(txt_S_PriCust.Text)
            CUS1NOLIST = Replace(CUS1NOLIST, "'", "''")
        End If

        If Trim(txt_S_SecCust.Text) = "" Then
            CUS2NOLIST = ""
        Else
            If Len(txt_S_SecCust.Text) > 1000 Then
                MsgBox("The Secondary Customer List is too long (1000 char)")
                Exit Sub
            End If
            CUS2NOLIST = Trim(txt_S_SecCust.Text)
            CUS2NOLIST = Replace(CUS2NOLIST, "'", "''")
        End If

        If Trim(txt_S_QuNo.Text) = "" Then
            QUNOLIST = ""
        Else
            If Len(txt_S_QuNo.Text) > 1000 Then
                MsgBox("The Quotation No List is too long (1000 char)")
                Exit Sub
            End If
            QUNOLIST = Trim(txt_S_QuNo.Text)
            QUNOLIST = Replace(QUNOLIST, "'", "''")
        End If

        If Trim(txt_S_ItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(txt_S_ItmNo.Text) > 1000 Then
                MsgBox("The Item No List is too long (1000 char)")
                Exit Sub
            End If
            ITMNOLIST = Trim(txt_S_ItmNo.Text)
            ITMNOLIST = Replace(ITMNOLIST, "'", "''")
        End If

        If txt_S_QuCreDateFm.Text <> "__/__/____" Then
            If Not IsDate(txt_S_QuCreDateFm.Text) Then
                MsgBox("Invalid Date Format: Quotaion Create Date From")
                txt_S_QuCreDateFm.Focus()
                Exit Sub
            End If
        End If

        If txt_S_QuCreDateTo.Text <> "__/__/____" Then
            If Not IsDate(txt_S_QuCreDateTo.Text) Then
                MsgBox("Invalid Date Format: Quotation Create Date To")
                txt_S_QuCreDateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(txt_S_QuCreDateFm.Text, 7) > Mid(txt_S_QuCreDateTo.Text, 7) Then
            MsgBox("Quotation Create Date: To Date < From Date (YY)")
            txt_S_QuCreDateFm.Focus()
            Exit Sub
        ElseIf Mid(txt_S_QuCreDateFm.Text, 7) = Mid(txt_S_QuCreDateTo.Text, 7) Then
            If txt_S_QuCreDateFm.Text.Substring(0, 2) > txt_S_QuCreDateTo.Text.Substring(0, 2) Then
                MsgBox("Quotation Create Date: To Date < From Date (MM)")
                txt_S_QuCreDateFm.Focus()
                Exit Sub
            ElseIf txt_S_QuCreDateFm.Text.Substring(0, 2) = txt_S_QuCreDateTo.Text.Substring(0, 2) Then
                If txt_S_QuCreDateFm.Text.Substring(4, 2) > txt_S_QuCreDateTo.Text.Substring(4, 2) Then
                    MsgBox("Quotation Create Date: To Date < From Date (DD)")
                    txt_S_QuCreDateFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If txt_S_QuCreDateFm.Text = "__/__/____" Then
            QUCREDATFM = "01/01/1900"
        Else
            QUCREDATFM = txt_S_QuCreDateFm.Text
        End If

        If txt_S_QuCreDateTo.Text = "__/__/____" Then
            QUCREDATTO = "01/01/1900"
        Else
            QUCREDATTO = txt_S_QuCreDateTo.Text
        End If

        Try
            '*** For Header Tab
            Cursor = Cursors.WaitCursor



            QUCREDATTO = Microsoft.VisualBasic.Left(QUCREDATTO, 10) & " 23:59:59.000"


            gspStr = "sp_select_QUM00005_HDR '" & _
                        COCDELIST & "','" & _
                        CUS1NOLIST & "','" & _
                        CUS2NOLIST & "','" & _
                        QUNOLIST & "','" & _
                        ITMNOLIST & "','" & _
                        QUCREDATFM & "','" & _
                        QUCREDATTO & "','" & _
                        gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_QUM00005_HDR, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmd Find sp_select_QUM00005_HDR : " & rtnStr)
            Else
                If rs_QUM00005_HDR.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Record found!")
                Else
                    dgHeader.DataSource = rs_QUM00005_HDR.Tables("RESULT").DefaultView
                    dgHeader.Columns("Act").SortMode = DataGridViewColumnSortMode.NotSortable
                    rs_QUM00005_HDR.Tables("RESULT").Columns("Act").ReadOnly = False

                    Call format_dgHeader()

                    '*** For Detail Tab
                    Cursor = Cursors.WaitCursor

                    gspStr = "sp_select_QUM00005_DTL '" & _
                                COCDELIST & "','" & _
                                CUS1NOLIST & "','" & _
                                CUS2NOLIST & "','" & _
                                QUNOLIST & "','" & _
                                ITMNOLIST & "','" & _
                                QUCREDATFM & "','" & _
                                QUCREDATTO & "','" & _
                                gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_QUM00005_DTL, rtnStr)
                    gspStr = ""

                    Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdFind_Click sp_select_QUM00005_DTL : " & rtnStr)
                    Else
                        If rs_QUM00005_DTL.Tables("RESULT").Rows.Count > 0 Then

                            dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView

                            dgDetail.Columns("Act").SortMode = DataGridViewColumnSortMode.NotSortable

                            rs_QUM00005_DTL.Tables("RESULT").Columns("Act").ReadOnly = False

                            Call format_dgDetail()
                        End If
                    End If

                    mode = "MODIFY"
                    Call formInit(mode)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub format_dgHeader()
        'Dim i As Integer
        'i = 0
        'With dgHeader
        '    .Columns(i).Width = 30
        '    .Columns(i).HeaderText = "Act"
        '    i = i + 1
        '    .Columns(i).Width = 32
        '    .Columns(i).HeaderText = "App Sts"
        '    i = i + 1
        '    .Columns(i).Width = 32
        '    .Columns(i).HeaderText = "App Cnt"
        '    i = i + 1
        '    .Columns(i).Visible = False
        '    i = i + 1
        '    .Columns(i).Width = 42
        '    .Columns(i).HeaderText = "Comp"
        '    i = i + 1
        '    .Columns(i).Width = 68
        '    .Columns(i).HeaderText = "PO No"
        '    i = i + 1
        '    .Columns(i).Width = 35
        '    .Columns(i).HeaderText = "PO Sts"
        '    i = i + 1
        '    .Columns(i).Width = 42
        '    .Columns(i).HeaderText = "Pri Cust"
        '    i = i + 1
        '    .Columns(i).Width = 90
        '    .Columns(i).HeaderText = "Pri Cust Name"
        '    i = i + 1
        '    .Columns(i).Width = 42
        '    .Columns(i).HeaderText = "Sec Cust"
        '    i = i + 1
        '    .Columns(i).Width = 55
        '    .Columns(i).HeaderText = "Sec Cust Name"
        '    i = i + 1
        '    .Columns(i).Width = 80
        '    .Columns(i).HeaderText = "Cust PO No"
        '    i = i + 1
        '    .Columns(i).Width = 68
        '    .Columns(i).HeaderText = "SC No"
        '    i = i + 1
        '    .Columns(i).Width = 36
        '    .Columns(i).HeaderText = "CV"
        '    i = i + 1
        '    .Columns(i).Width = 65
        '    .Columns(i).HeaderText = "CV Name"

        'End With

        For index As Integer = 0 To dgHeader.ColumnCount - 1
            dgHeader.Columns(index).Width = 80
        Next

        dgHeader.Columns(0).Width = 49
        dgHeader.Columns(1).Width = 60
        dgHeader.Columns(2).Width = 50
        dgHeader.Columns(4).Width = 60
        dgHeader.Columns(5).Width = 130
        dgHeader.Columns(6).Width = 60
        dgHeader.Columns(7).Width = 130
        dgHeader.Columns(8).Width = 130

    End Sub

    Private Sub format_dgDetail()
        Dim i As Integer
        i = 0
        With dgDetail
            '0
            .Columns(i).Width = 40
            '.Columns(i).HeaderText = "Seq"
            '1
            ' ''i = i + 1
            ' ''.Columns(i).Width = 0
            '.Columns(i).HeaderText = "Seq"
            '2
            i = i + 1
            .Columns(i).Width = 40
            '.Columns(i).HeaderText = "Item"
            '3
            i = i + 1
            .Columns(i).Width = 60
            i = i + 1
            .Columns(i).Width = 130
            i = i + 1
            .Columns(i).Width = 60
            i = i + 1
            .Columns(i).Width = 120

            i = i + 1
            .Columns(i).Width = 79
            '.Columns(i).HeaderText = "Job No"
            '4
            i = i + 1
            '5
            .Columns(i).Width = 30

            i = i + 1

            .Columns(i).Width = 99
            '.Columns(i).HeaderText = "Ven Item No"
            i = i + 1
            '6
            .Columns(i).Width = 99
            '.Columns(i).HeaderText = "Cust Item No"
            i = i + 1
            '7
            .Columns(i).Width = 130
            i = i + 1
            '8
            .Columns(i).Width = 55
            i = i + 1
            '9
            .Columns(i).Width = 80
            '.Columns(i).HeaderText = "Cust Color"
            i = i + 1
            '10
            i = i + 1
            '11
            .Columns(i).Width = 85
            i = i + 1
            .Columns(i).Width = 55
            i = i + 1
            .Columns(i).Width = 90
            i = i + 1
            .Columns(i).Width = 130
            'i = i + 1
            '.Columns(i).Width = 0

        End With

        ''For index As Integer = 0 To dgDetail.ColumnCount - 1
        ''    dgDetail.Columns(index).Width = 80
        ''Next
    End Sub


    'Private Sub format_dgDetail()
    '    Dim i As Integer
    '    i = 0
    '    With dgDetail
    '        '0
    '        .Columns(i).Width = 40
    '        '.Columns(i).HeaderText = "Seq"
    '        '1
    '        i = i + 1
    '        .Columns(i).Width = 99
    '        '.Columns(i).HeaderText = "Seq"
    '        '2
    '        i = i + 1
    '        .Columns(i).Width = 40
    '        '.Columns(i).HeaderText = "Item"
    '        '3
    '        i = i + 1
    '        .Columns(i).Width = 79
    '        '.Columns(i).HeaderText = "Job No"
    '        '4
    '        i = i + 1
    '        '5
    '        .Columns(i).Width = 30
    '        i = i + 1
    '        .Columns(i).Width = 30

    '        .Columns(i).Width = 99
    '        '.Columns(i).HeaderText = "Ven Item No"
    '        i = i + 1
    '        '6
    '        .Columns(i).Width = 79
    '        '.Columns(i).HeaderText = "Cust Item No"
    '        i = i + 1
    '        '7
    '        .Columns(i).Width = 99
    '        i = i + 1
    '        '8
    '        .Columns(i).Width = 40
    '        i = i + 1
    '        '9
    '        .Columns(i).Width = 80
    '        '.Columns(i).HeaderText = "Cust Color"
    '        i = i + 1
    '        '10
    '        i = i + 1
    '        '11
    '        .Columns(i).Width = 99
    '        i = i + 1
    '        .Columns(i).Width = 80
    '        '12
    '        'i = i + 1

    '        ''13
    '        'i = i + 1
    '        ''14
    '        '.Columns(i).Width = 80
    '        ''.Columns(i).HeaderText = "Curr"
    '        'i = i + 1
    '        ''15
    '        '.Columns(i).Width = 80
    '        ''.Columns(i).HeaderText = "FtyPrc"
    '        'i = i + 1

    '        '    Dim j As Integer
    '        '    For j = i To dgDetail.Columns.Count - 1
    '        '        .Columns(j).Visible = False
    '        '    Next j
    '    End With

    '    ''For index As Integer = 0 To dgDetail.ColumnCount - 1
    '    ''    dgDetail.Columns(index).Width = 80
    '    ''Next
    'End Sub



    Private Sub cmdHDRSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHDRSelectAll.Click
        dgHeader.SelectAll()
    End Sub

    Private Sub cmdDTLSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDTLSelectAll.Click
        dgDetail.SelectAll()
    End Sub

    Private Sub cmdHDRShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHDRShowAll.Click
        If rs_QUM00005_HDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        rs_QUM00005_HDR.Tables("RESULT").DefaultView.RowFilter = ""
        dgHeader.DataSource = rs_QUM00005_HDR.Tables("RESULT").DefaultView
    End Sub
    Private Sub cmdDTLShowAllClick()
        If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        dgHeader.ClearSelection()
        rs_QUM00005_DTL.Tables("RESULT").DefaultView.RowFilter = ""
        dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView



        txt_D_CoCde.Text = ""
        txt_D_CaOrdNo.Text = ""
        txtcus1no.Text = ""
        txtcus2no.Text = ""

    End Sub

    'Private Sub cmdDTLShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDTLShowAll.Click
    '    If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
    '        Exit Sub
    '    End If
    '    dgHeader.ClearSelection()
    '    rs_QUM00005_DTL.Tables("RESULT").DefaultView.RowFilter = ""
    '    dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView



    '    txt_D_CoCde.Text = ""
    '    txt_D_CaOrdNo.Text = ""
    '    txtcus1no.Text = ""
    '    txtcus2no.Text = ""

    'End Sub

    Private Sub btcQUM00005_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcQUM00005.SelectedIndexChanged
        Dim sQuCocde As String = ""
        Dim sQuOrdNo As String = ""
        Dim sFilter As String = ""

        If btcQUM00005.SelectedIndex = 0 Then
            formInit("INIT")
        ElseIf btcQUM00005.SelectedIndex = 1 Then
            '20140124
            '' ''If mode = "MODIFY" Then
            '' ''    If dgDetail.RowCount > 0 Then

            '' ''        If dgDetail.CurrentCell Is Nothing Then
            '' ''            sQuCocde = "'"
            '' ''            sQuOrdNo = "'"
            '' ''        Else
            '' ''            sQuCocde = "'" + Trim(dgDetail.Item(2, dgDetail.CurrentCell.RowIndex).Value) + "'"
            '' ''            sQuOrdNo = "'" + Trim(dgDetail.Item(3, dgDetail.CurrentCell.RowIndex).Value) + "'"
            '' ''        End If


            '' ''        'If dgDetail.SelectedRows.Count <> 1 Then
            '' ''        '    sQuCocde = "''"
            '' ''        '    sQuOrdNo = "''"
            '' ''        'Else
            '' ''        '    sQuCocde = "'" + Trim(dgDetail.SelectedRows(0).Cells("COMP").Value.ToString) + "'"
            '' ''        '    sQuOrdNo = "'" + Trim(dgDetail.SelectedRows(0).Cells("Quotation No").Value.ToString) + "'"
            '' ''        'End If
            '' ''        If Not rs_QUM00005_HDR.Tables("RESULT") Is Nothing Then
            '' ''            If flag_detail_click = False Then
            '' ''                sFilter = ""
            '' ''            Else
            '' ''                sFilter = " [Comp] = " + sQuCocde + " and [Quotation No] = " + sQuOrdNo
            '' ''            End If

            '' ''            rs_QUM00005_HDR.Tables("RESULT").DefaultView.RowFilter = sFilter
            '' ''            dgHeader.DataSource = rs_QUM00005_HDR.Tables("RESULT").DefaultView

            '' ''        End If
            '' ''        If dgHeader.SelectedRows.Count <> 1 Then
            '' ''            'rbHDRAPV1.Enabled = False
            '' ''            'rbHDRCANL.Enabled = False
            '' ''            'rbHDRCLOS.Enabled = False
            '' ''            'rbHDRNoUpd.Enabled = False
            '' ''            'rbHDROPEN.Enabled = False
            '' ''        End If
            '' ''    End If
            'If dgDetail.SelectedRows.Count <> 1 Then
            '    cmdHDRShowAll_Click(sender, e)
            'End If

            '''20140122
            cmdDTLShowAllClick()
            ' ''End If

        Else
            'If mode = "MODIFY" Then
            If dgHeader.RowCount > 0 Then
                'If dgHeader.SelectedRows.Count <> 1 Then
                '    sQuCocde = "''"
                '    sQuOrdNo = "''"
                '    txt_D_CaOrdNo.Text = ""
                '    txt_D_CaSts.Text = ""
                '    txt_D_CoCde.Text = ""
                '    rbDTLAPV1.Enabled = False
                '    rbDTLNoUpd.Enabled = False
                'Else
                If dgHeader.CurrentCell Is Nothing Then
                    sQuCocde = "'"
                    sQuOrdNo = "'"
                Else
                    sQuCocde = "'" + Trim(dgHeader.Item(2, dgHeader.CurrentCell.RowIndex).Value.ToString) + "'"
                    sQuOrdNo = "'" + Trim(dgHeader.Item(3, dgHeader.CurrentCell.RowIndex).Value.ToString) + "'"
                    txt_D_CaOrdNo.Text = dgHeader.Item(3, dgHeader.CurrentCell.RowIndex).Value
                    txt_D_CaSts.Text = dgHeader.Item(1, dgHeader.CurrentCell.RowIndex).Value
                    If txt_D_CaSts.Text = "W" Then
                        txt_D_CaSts.Text = " W -  Wait for Approval"
                    End If
                    If txt_D_CaSts.Text = "A" Then
                        txt_D_CaSts.Text = " A -  Active"
                    End If
                    If txt_D_CaSts.Text = "C" Then
                        txt_D_CaSts.Text = " C -  Cancel"
                    End If

                    txtcus1no.Text = dgHeader.Item(4, dgHeader.CurrentCell.RowIndex).Value & " - " & dgHeader.Item(5, dgHeader.CurrentCell.RowIndex).Value
                    txtcus2no.Text = dgHeader.Item(6, dgHeader.CurrentCell.RowIndex).Value & " - " & dgHeader.Item(7, dgHeader.CurrentCell.RowIndex).Value
                    If Trim(txtcus2no.Text) = "-" Then
                        txtcus2no.Text = ""
                    End If

                    txt_D_CoCde.Text = dgHeader.Item(2, dgHeader.CurrentCell.RowIndex).Value

                End If


                'sQuCocde = "'" + Trim(dgHeader.SelectedRows(0).Cells("COMP").Value.ToString) + "'"
                'sQuOrdNo = "'" + Trim(dgHeader.SelectedRows(0).Cells("Quotation No").Value.ToString) + "'"
                'txt_D_CaOrdNo.Text = Trim(dgHeader.SelectedRows(0).Cells("Quotation No").Value.ToString)
                'txt_D_CaSts.Text = Trim(dgHeader.SelectedRows(0).Cells("Approval Status").Value.ToString)
                'txt_D_CoCde.Text = Trim(dgHeader.SelectedRows(0).Cells("COMP").Value.ToString)
                'End If
                sFilter = " [Comp] = " + sQuCocde + " and [Quotation No] = " + sQuOrdNo
                rs_QUM00005_DTL.Tables("RESULT").DefaultView.RowFilter = sFilter
                dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView

                If bInDTL Then
                    cmdDTLShowAllClick()
                End If
                bInDTL = False
                'End If
            End If
        End If
    End Sub

    Private Sub dgHeader_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgHeader.CellMouseUp


        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then

            'dgHeader.Columns(e.ColumnIndex).ReadOnly = False

            'If dgHeader.Columns(e.ColumnIndex).ReadOnly = False Then
            If rs_QUM00005_HDR.Tables("RESULT").DefaultView(e.RowIndex)("ACT").ToString = "Y" Then
                rs_QUM00005_HDR.Tables("RESULT").DefaultView(e.RowIndex)("ACT") = "N"

                Call set_dtls_n(rs_QUM00005_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Quotation No"))
            Else

                rs_QUM00005_HDR.Tables("RESULT").DefaultView(e.RowIndex)("ACT") = "Y"
                Call set_dtls(rs_QUM00005_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Quotation No"))
                'rs_QUM00005_HDR.Tables("RESULT").DefaultView(e.RowIndex)("qud_creusr") = "~*DEL*~"

            End If
            rs_QUM00005_HDR.Tables("RESULT").AcceptChanges()

            'End If
        End If





        'rbHDRAPV1.Enabled = False
        'rbHDROPEN.Enabled = False
        'rbHDRCANL.Enabled = False
        'rbHDRCLOS.Enabled = False
        'rbHDRNoUpd.Enabled = False
        'cmdHDRApply.Enabled = False
        ''cmdHDRApprove.Enabled = False
        'rbHDRAPV1.Checked = True
        'rbHDROPEN.Checked = False
        'rbHDRCANL.Checked = False
        'rbHDRCLOS.Checked = False
        'rbHDRNoUpd.Checked = False

        'If dgHeader.SelectedRows.Count > 0 Then
        '    If dgHeader.SelectedRows.Count > 1 Then
        '        For i As Integer = 1 To dgHeader.SelectedRows.Count - 1
        '            If dgHeader.SelectedRows(0).Cells("Approval Status").Value <> dgHeader.SelectedRows(i).Cells("Approval Status").Value Then
        '                rbHDRAPV1.Enabled = False
        '                rbHDROPEN.Enabled = False
        '                rbHDRCANL.Enabled = True
        '                rbHDRCLOS.Enabled = False
        '                rbHDRNoUpd.Enabled = True
        '                cmdHDRApply.Enabled = True
        '                rbHDRAPV1.Checked = False
        '                rbHDROPEN.Checked = False
        '                rbHDRCANL.Checked = False
        '                rbHDRCLOS.Checked = False
        '                rbHDRNoUpd.Checked = True
        '                Exit For
        '            End If
        '        Next i
        '    End If

        '    If dgHeader.SelectedRows(0).Cells("Approval Status").Value = "W" Then
        '        'If dgHeader.SelectedRows(0).Cells("Approval Status").Value = "OPEN" Then
        '        rbHDRAPV1.Enabled = True
        '        rbHDROPEN.Enabled = False
        '        rbHDRCANL.Enabled = True
        '        rbHDRCLOS.Enabled = False
        '        rbHDRNoUpd.Enabled = True
        '        cmdHDRApply.Enabled = True
        '        rbHDRAPV1.Checked = True
        '        rbHDROPEN.Checked = False
        '        rbHDRCANL.Checked = False
        '        rbHDRCLOS.Checked = False
        '        rbHDRNoUpd.Checked = False
        '    ElseIf dgHeader.SelectedRows(0).Cells("Approval Status").Value = "APV1" Then
        '        rbHDRAPV1.Enabled = False
        '        rbHDROPEN.Enabled = True
        '        rbHDRCANL.Enabled = True
        '        rbHDRCLOS.Enabled = False
        '        rbHDRNoUpd.Enabled = True
        '        cmdHDRApply.Enabled = True
        '        rbHDRAPV1.Checked = False
        '        rbHDROPEN.Checked = True
        '        rbHDRCLOS.Checked = False
        '        rbHDRCANL.Checked = False
        '        rbHDRNoUpd.Checked = False
        '    ElseIf dgHeader.SelectedRows(0).Cells("Approval Status").Value = "CANL" Then
        '        rbHDRAPV1.Enabled = False
        '        rbHDROPEN.Enabled = False
        '        rbHDRCANL.Enabled = False
        '        rbHDRCLOS.Enabled = False
        '        rbHDRNoUpd.Enabled = True
        '        cmdHDRApply.Enabled = True
        '        rbHDRAPV1.Checked = False
        '        rbHDROPEN.Checked = False
        '        rbHDRCLOS.Checked = False
        '        rbHDRCANL.Checked = False
        '        rbHDRNoUpd.Checked = True
        '    Else
        '        rbHDRAPV1.Enabled = False
        '        rbHDROPEN.Enabled = False
        '        rbHDRCANL.Enabled = False
        '        rbHDRCLOS.Enabled = False
        '        rbHDRNoUpd.Enabled = True
        '        cmdHDRApply.Enabled = False
        '        rbHDRAPV1.Checked = False
        '        rbHDROPEN.Checked = False
        '        rbHDRCANL.Checked = False
        '        rbHDRCLOS.Checked = False
        '        rbHDRNoUpd.Checked = True
        '    End If

        '    For j As Integer = 0 To dgHeader.SelectedRows.Count - 1
        '        If dgHeader.SelectedRows(j).Cells("Act").Value <> "N" Then
        '            'cmdHDRApprove.Enabled = True
        '            Exit For
        '        End If
        '    Next j
        'End If
    End Sub

    Private Sub dgDetail_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellClick
        flag_detail_click = True


    End Sub

    Private Sub dgDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgDetail.CellMouseUp


        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then

            dgHeader.Columns(e.ColumnIndex).ReadOnly = False

            'If dgHeader.Columns(e.ColumnIndex).ReadOnly = False Then
            If rs_QUM00005_DTL.Tables("RESULT").DefaultView(e.RowIndex)("ACT").ToString = "Y" Then
                rs_QUM00005_DTL.Tables("RESULT").DefaultView(e.RowIndex)("ACT") = "N"

            Else
                rs_QUM00005_DTL.Tables("RESULT").DefaultView(e.RowIndex)("ACT") = "Y"
                ' rs_QUM00005_DTL.Tables("RESULT").DefaultView(e.RowIndex)("qud_creusr") = "~*DEL*~"

            End If
            rs_QUM00005_DTL.Tables("RESULT").AcceptChanges()

            'End If
        End If


        'rbDTLAPV1.Enabled = False
        'rbDTLNoUpd.Enabled = False
        'cmdDTLApply.Enabled = False
        ''cmdDTLApprove.Enabled = False
        'rbDTLAPV1.Checked = True
        'rbDTLNoUpd.Checked = False

        'If dgDetail.SelectedRows.Count > 0 Then
        '    If dgDetail.SelectedRows.Count > 1 Then
        '        For i As Integer = 1 To dgDetail.SelectedRows.Count - 1
        '            If dgDetail.SelectedRows(0).Cells("Approval Status").Value <> dgDetail.SelectedRows(i).Cells("Approval Status").Value Then
        '                rbDTLAPV1.Enabled = False
        '                rbDTLNoUpd.Enabled = True
        '                cmdDTLApply.Enabled = True
        '                rbDTLAPV1.Checked = False
        '                rbDTLNoUpd.Checked = True
        '                Exit For
        '            End If
        '        Next i
        '    End If

        '    If dgDetail.SelectedRows(0).Cells("Approval Status").Value = "N" Then
        '        'If dgDetail.SelectedRows(0).Cells("Approval Status").Value = "" Then
        '        rbDTLAPV1.Enabled = True
        '        rbDTLNoUpd.Enabled = True
        '        cmdDTLApply.Enabled = True
        '        rbDTLAPV1.Checked = True
        '        rbDTLNoUpd.Checked = False
        '    Else
        '        rbDTLAPV1.Enabled = False
        '        rbDTLNoUpd.Enabled = True
        '        cmdDTLApply.Enabled = False
        '        rbDTLAPV1.Checked = False
        '        rbDTLNoUpd.Checked = True
        '    End If

        '    For j As Integer = 0 To dgDetail.SelectedRows.Count - 1
        '        If dgDetail.SelectedRows(j).Cells("Act").Value <> "N" Then
        '            'cmdDTLApprove.Enabled = True
        '            Exit For
        '        End If
        '    Next j

        '    If txt_D_CaSts.Text = "CANL" Or txt_D_CaSts.Text = "CLOS" Then
        '        rbDTLAPV1.Enabled = False
        '        rbDTLNoUpd.Enabled = False
        '        cmdDTLApply.Enabled = False
        '        'cmdDTLApprove.Enabled = False
        '        rbDTLAPV1.Checked = True
        '        rbDTLNoUpd.Checked = False
        '    End If
        'End If
    End Sub

    Private Sub cmdHDRApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHDRApply.Click

        If rbHDRAPV1.Checked = True Then
            For index As Integer = 0 To rs_QUM00005_HDR.Tables("RESULT").DefaultView.Count - 1
                rs_QUM00005_HDR.Tables("RESULT").DefaultView(index)("ACT") = "Y"
                Call set_dtls(rs_QUM00005_HDR.Tables("RESULT").DefaultView(index)("Quotation No"))

            Next
        ElseIf rbHDRNoUpd.Checked = True Then
            For index As Integer = 0 To rs_QUM00005_HDR.Tables("RESULT").DefaultView.Count - 1
                rs_QUM00005_HDR.Tables("RESULT").DefaultView(index)("ACT") = "N"
            Next
        End If
        'rs_QUM00005_HDR.AcceptChanges()
        rs_QUM00005_HDR.Tables("RESULT").AcceptChanges()

        dgHeader.DataSource = rs_QUM00005_HDR.Tables("RESULT").DefaultView



        'Dim i As Integer
        'Dim cont As Boolean = True
        'Dim status As String = "N"
        'Dim reason As String = ""

        'If dgHeader.SelectedRows.Count > 0 Then
        '    If dgHeader.SelectedRows.Count > 1 Then
        '        If Not rbHDRCANL.Checked Then
        '            For i = 1 To dgHeader.SelectedRows.Count - 1
        '                If dgHeader.SelectedRows(0).Cells("Approval Status").Value <> dgHeader.SelectedRows(i).Cells("Approval Status").Value And Not rbHDRNoUpd.Checked Then
        '                    cont = False
        '                    MsgBox("Cannot update different type of Quotation Status at the same time")
        '                    Exit For
        '                End If
        '            Next i
        '        End If
        '    End If

        '    If cont Then
        '        If rbHDROPEN.Checked Then
        '            status = "OPEN"
        '        ElseIf rbHDRAPV1.Checked Then
        '            status = "APPV"
        '            'status = "APV1"
        '        ElseIf rbHDRCLOS.Checked Then
        '            status = "CLOS"
        '        ElseIf rbHDRCANL.Checked Then
        '            status = "CANL"
        '            reason = InputBox("Please enter a reason", "Reason Entry Form", "Enter your messge here", 200, 200)
        '            reason = "Quotation Canceled at " & DateTime.Today.Year & "-" & DateTime.Today.Month & "-" & DateTime.Today.Day _
        '                    & vbCrLf & "Reason: " & reason & vbCrLf & vbCrLf
        '        Else
        '            status = "N"
        '        End If

        '        rs_QUM00005_HDR.Tables("RESULT").Columns("Act").ReadOnly = False

        '        ' rs_QUM00005_HDR.Tables("RESULT").Columns("Remark").ReadOnly = False

        '        dgHeader.Columns("Act").ReadOnly = False
        '        'dgHeader.Columns("Remark").ReadOnly = False

        '        For i = 0 To dgHeader.SelectedRows.Count - 1
        '            dgHeader.SelectedRows(i).Cells("Act").Value = status
        '            'dgHeader.SelectedRows(i).Cells("Remark").Value = reason & dgHeader.SelectedRows(i).Cells("Remark").Value

        '        Next i
        '        rs_QUM00005_HDR.Tables("RESULT").Columns("Act").ReadOnly = False
        '        'rs_QUM00005_HDR.Tables("RESULT").Columns("Remark").ReadOnly = false
        '        'dgHeader.Columns("Act").ReadOnly = false
        '        'dgHeader.Columns("Remark").ReadOnly = false
        '        'cmdHDRApprove.Enabled = True
        '    End If
        'End If
    End Sub

    Private Sub cmdDTLApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDTLApply.Click

        If rbDTLAPV1.Checked = True Then
            For index As Integer = 0 To rs_QUM00005_DTL.Tables("RESULT").DefaultView.Count - 1
                rs_QUM00005_DTL.Tables("RESULT").DefaultView(index)("ACT") = "Y"
            Next
        ElseIf rbDTLNoUpd.Checked = True Then
            For index As Integer = 0 To rs_QUM00005_DTL.Tables("RESULT").DefaultView.Count - 1
                rs_QUM00005_DTL.Tables("RESULT").DefaultView(index)("ACT") = "N"
            Next
        End If

        'rs_QUM00005_DTL.AcceptChanges()
        rs_QUM00005_DTL.Tables("RESULT").AcceptChanges()

        dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView



        'Dim i As Integer
        'Dim cont As Boolean = True
        'Dim status As String = "N"

        'If dgDetail.SelectedRows.Count > 0 Then
        '    If txt_D_CaSts.Text = "CANL" Or txt_D_CaSts.Text = "CLOS" Then
        '        MsgBox("The Quotation Header is " & If(txt_D_CaSts.Text = "CANL", "canceled", "closed"))
        '    Else
        '        If dgDetail.SelectedRows.Count > 1 Then
        '            For i = 1 To dgDetail.SelectedRows.Count - 1
        '                If dgDetail.SelectedRows(0).Cells("Approval Status").Value <> dgDetail.SelectedRows(i).Cells("Approval Status").Value Then
        '                    cont = False
        '                    MsgBox("Cannot update different type of Quotation Status at the same time")
        '                    Exit For
        '                End If
        '            Next i
        '        End If

        '        If cont Then
        '            If rbDTLAPV1.Checked Then
        '                status = "APV1"
        '            End If

        '            rs_QUM00005_DTL.Tables("RESULT").Columns("Act").ReadOnly = False
        '            dgDetail.Columns("Act").ReadOnly = False

        '            For i = 0 To dgDetail.SelectedRows.Count - 1
        '                dgDetail.SelectedRows(i).Cells("Act").Value = status
        '            Next i

        '            rs_QUM00005_DTL.Tables("RESULT").Columns("Act").ReadOnly = False
        '            dgDetail.Columns("Act").ReadOnly = False
        '            'cmdDTLApprove.Enabled = True

        '        End If
        '    End If
        'End If
    End Sub


    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click

    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click

    End Sub

    Private Sub cmd_S_QuNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_QuNo.Click

    End Sub

    Private Sub cmd_S_CustPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustPONo.Click

    End Sub

    Private Sub txt_S_QuCreDateFm_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txt_S_QuCreDateFm.MaskInputRejected

    End Sub

    Private Sub txt_S_QuCreDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txt_S_QuCreDateTo.MaskInputRejected

    End Sub

    Private Sub cmdHDRApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        '''20130909
        Dim sQuCocde As String
        Dim sQuOrdNo As String
        Dim sFilter As String
        Dim tmp_quh_qutsts As String
        Dim tmp_qud_qutno As String
        Dim tmp_qud_seq As String

        '''For rs_QUM00005_HDR 
        '''rs_QUM00005_HDR.Tables("RESULT").Rows(0)("qud_qutsts") = "A - Active"

        If rs_QUM00005_HDR.Tables("RESULT") Is Nothing Then
            MsgBox("no records saved!")
            Exit Sub
        End If

        For index As Integer = 0 To rs_QUM00005_HDR.Tables("RESULT").Rows.Count - 1

            sQuCocde = rs_QUM00005_HDR.Tables("RESULT").Rows(index)("COMP")
            sQuOrdNo = rs_QUM00005_HDR.Tables("RESULT").Rows(index)("Quotation No")
            tmp_qud_qutno = rs_QUM00005_HDR.Tables("RESULT").Rows(index)("Quotation No")

            tmp_quh_qutsts = set_qutsts(sQuCocde, sQuOrdNo)

            ''''write a function to update hdr sts
            If tmp_quh_qutsts = "A" Then
                gspStr = "sp_update_QUM00005_HDR  '" & tmp_qud_qutno & "'"

                rtnLong = execute_SQLStatement(gspStr, rs_QUM00005_HDR_update, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading sp_update_QUM00005_HDR : " & rtnStr)
                End If
            End If

        Next
        ''For rs_QUM00005_DTL 
        'rs_QUM00005_DTL.Tables("RESULT").Rows(0)("qud_qutsts") = "A - Active"

        For index As Integer = 0 To rs_QUM00005_DTL.Tables("RESULT").Rows.Count - 1
            If rs_QUM00005_DTL.Tables("RESULT").Rows(index)("ACT") = "Y" Then
                'tmp_cocde = rs_QUM00005_DTL.Tables("RESULT").Rows(index)("qud_apprve")
                tmp_qud_qutno = rs_QUM00005_DTL.Tables("RESULT").Rows(index)("Quotation No")
                tmp_qud_seq = rs_QUM00005_DTL.Tables("RESULT").Rows(index)("Seq")

                gspStr = "sp_update_QUM00005_DTL  '" & tmp_qud_qutno & "'," & tmp_qud_seq

                rtnLong = execute_SQLStatement(gspStr, rs_QUM00005_DTL_update, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading sp_update_QUM00005_DTL : " & rtnStr)
                End If

            End If

        Next



        MsgBox("Status Saved!")

        ''re-find


        flag_detail_click = False

        rs_QUM00005_DTL.Clear()
        rs_QUM00005_HDR.Clear()

        If rs_QUM00005_HDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_QUM00005_HDR.Tables("RESULT").Rows.Count > 1 Then
            dgHeader.DataSource = rs_QUM00005_HDR.Tables("RESULT").DefaultView
        End If

        If rs_QUM00005_DTL.Tables("RESULT").Rows.Count > 1 Then
            dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView
        End If


        btcQUM00005.SelectedIndex = 0
        btcQUM00005.TabPages(0).Enabled = True
        btcQUM00005.TabPages(1).Enabled = False
        btcQUM00005.TabPages(2).Enabled = False



    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txt_S_PriCust.Text = ""
        txt_S_SecCust.Text = ""
        txt_S_QuNo.Text = ""
        txt_S_ItmNo.Text = ""
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click

    End Sub

    Private Sub btcQUM00005_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcQUM00005_2.Click

    End Sub

    Private Sub dgHeader_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellContentClick

    End Sub

    Private Sub cmdRefind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefind.Click

        flag_detail_click = False

        rs_QUM00005_DTL.Clear()
        rs_QUM00005_HDR.Clear()

        If rs_QUM00005_HDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_QUM00005_HDR.Tables("RESULT").Rows.Count > 1 Then
            dgHeader.DataSource = rs_QUM00005_HDR.Tables("RESULT").DefaultView
        End If

        If rs_QUM00005_DTL.Tables("RESULT").Rows.Count > 1 Then
            dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView
        End If


        btcQUM00005.SelectedIndex = 0
        btcQUM00005.TabPages(0).Enabled = True
        btcQUM00005.TabPages(1).Enabled = False
        btcQUM00005.TabPages(2).Enabled = False
    End Sub
    Function set_qutsts(ByVal cocde, ByVal qutno) As String
        Dim sFilter As String
        Dim count_sts_N As Integer

        'sFilter = " [Comp] = '" + cocde + "' and [Quotation No] = '" + qutno + "'"
        'rs_QUM00005_DTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        count_sts_N = 0

        If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
            Exit Function
        End If

        'If rs_QUM00005_DTL.Tables("RESULT").DefaultView.Count > 0 Then
        '    For index As Integer = 0 To rs_QUM00005_DTL.Tables("RESULT").DefaultView.Count - 1
        '        'check sts from dtl
        '        If rs_QUM00005_DTL.Tables("RESULT").DefaultView(index)("ACT") = "N" Then
        '            count_sts_N = count_sts_N + 1
        '        End If
        '    Next
        'End If


        If rs_QUM00005_DTL.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_QUM00005_DTL.Tables("RESULT").Rows.Count - 1
                If rs_QUM00005_DTL.Tables("RESULT").Rows(index)("ACT") = "N" Then

                    count_sts_N = count_sts_N + 1
                End If
            Next
        End If





        If count_sts_N > 0 Then
            set_qutsts = "W"
        Else
            set_qutsts = "A"
        End If

    End Function
    Sub set_dtls(ByVal qutno)
        Dim sFilter As String
        Dim count_sts_N As Integer

        'sFilter = " [Quotation No] = '" + qutno + "'"
        'rs_QUM00005_DTL.Tables("RESULT").DefaultView.RowFilter = sFilter


        If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        'rs_QUOTNDTL.Tables("RESULT").Rows(sReadingIndexQ)("qud_basprc")

        If rs_QUM00005_DTL.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_QUM00005_DTL.Tables("RESULT").Rows.Count - 1
                If rs_QUM00005_DTL.Tables("RESULT").Rows(index)("Quotation No") = qutno Then
                    rs_QUM00005_DTL.Tables("RESULT").Rows(index)("ACT") = "Y"
                End If
            Next
        End If

    End Sub
    Sub set_dtls_n(ByVal qutno)
        Dim sFilter As String
        Dim count_sts_N As Integer

        'sFilter = " [Quotation No] = '" + qutno + "'"
        'rs_QUM00005_DTL.Tables("RESULT").DefaultView.RowFilter = sFilter


        If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        'rs_QUOTNDTL.Tables("RESULT").Rows(sReadingIndexQ)("qud_basprc")

        If rs_QUM00005_DTL.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_QUM00005_DTL.Tables("RESULT").Rows.Count - 1
                If rs_QUM00005_DTL.Tables("RESULT").Rows(index)("Quotation No") = qutno Then
                    rs_QUM00005_DTL.Tables("RESULT").Rows(index)("ACT") = "N"
                End If
            Next
        End If

    End Sub


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()


    End Sub

    Private Sub dgDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellContentClick

    End Sub

    Private Sub txt_S_QuCreDateFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_S_QuCreDateFm.Validating
        Dim tmpstr As String
        tmpstr = txt_S_QuCreDateFm.Text


        If Not IsDate(tmpstr) And Trim(tmpstr) <> Trim("  /  /    ") Then
            MsgBox("Not a valid date!")
            txt_S_QuCreDateFm.Focus()
        End If

    End Sub

    Private Sub txt_S_QuCreDateTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_S_QuCreDateTo.Validating
        Dim tmpstr As String
        tmpstr = txt_S_QuCreDateTo.Text


        If Not IsDate(tmpstr) And Trim(tmpstr) <> Trim("  /  /    ") Then
            MsgBox("Not a valid date!")
            txt_S_QuCreDateTo.Focus()
        End If


    End Sub

    Private Sub txtcus1no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcus1no.TextChanged

    End Sub

    Private Sub btcQUM00005_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcQUM00005_3.Click

    End Sub

    Private Sub cmdDTLShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDTLShowAll.Click
        If rs_QUM00005_DTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        dgHeader.ClearSelection()
        rs_QUM00005_DTL.Tables("RESULT").DefaultView.RowFilter = ""
        dgDetail.DataSource = rs_QUM00005_DTL.Tables("RESULT").DefaultView



        txt_D_CoCde.Text = ""
        txt_D_CaOrdNo.Text = ""
        txtcus1no.Text = ""
        txtcus2no.Text = ""

    End Sub
End Class