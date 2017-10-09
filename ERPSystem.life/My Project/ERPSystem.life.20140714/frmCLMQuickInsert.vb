Public Class frmCLMQuickInsert

    Public rs_SYMUSRCO As New DataSet
    Public rs_frmCLMQuickInsert_Item As New DataSet
    Public rs_frmCLMQuickInsert As New DataSet
    Dim nSearchBy As Integer
    Dim mode As String
    Dim recordSelected As Integer = 0
    Dim gs_cliam_period As String

    Public Sub New(ByVal iniClaimPeriod As String, ByVal iniPriCust As String, _
                   ByVal iniSecCust As String, ByVal iniPV As String, ByVal iniSearchBy As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If Not String.IsNullOrEmpty(iniClaimPeriod) Then
            If iniClaimPeriod.Length > 0 Then
                txt_S_ClaimPeriod.Text = iniClaimPeriod
            End If
        End If

        If Not String.IsNullOrEmpty(iniPriCust) Then
            If iniPriCust.Length > 0 And iniPriCust.IndexOf("-") <> -1 Then
                txt_S_PriCust.Text = iniPriCust.Substring(0, (iniPriCust.IndexOf("-") - 1))
            Else
                txt_S_PriCust.Text = iniPriCust
            End If
        End If

        If Not String.IsNullOrEmpty(iniSecCust) Then
            If iniSecCust.Length > 0 And iniSecCust.IndexOf("-") <> -1 Then
                txt_S_SecCust.Text = iniSecCust.Substring(0, (iniSecCust.IndexOf("-") - 1))
            Else
                txt_S_SecCust.Text = iniSecCust
            End If
        End If

        If Not String.IsNullOrEmpty(iniPV) Then
            If iniPV.Length > 0 And iniPV.IndexOf("-") <> -1 Then
                txt_S_PV.Text = iniPV.Substring(0, (iniPV.IndexOf("-") - 1))
            Else
                txt_S_PV.Text = iniPV
            End If
        End If

        If Not String.IsNullOrEmpty(iniSearchBy) Then
            nSearchBy = iniSearchBy
        End If
    End Sub

    Private Sub frmCLMQuickInsert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading frmCLMQuickInsert sp_select_SYMUSRCO : " & rtnStr)
            Else
                Dim i As Integer
                Dim strCocde As String
                strCocde = ""

                If rs_SYMUSRCO.Tables("RESULT").Rows.Count > 0 Then
                    For i = 0 To rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1
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

            'txt_S_InvIssDateFm.Text = Today.AddMonths(-1)
            'txt_S_InvIssDateTo.Text = Today

            mode = "INIT"
            formInit(mode)

            Formstartup(Me.Name)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            tcfrmCLMQuickInsert.TabPages(0).Enabled = True
            tcfrmCLMQuickInsert.TabPages(1).Enabled = True
            ' tcfrmCLMQuickInsert.TabPages(1).Enabled = False


            tcfrmCLMQuickInsert.SelectedIndex = 0

            If nSearchBy = 0 Then
                gbSearchBy.Enabled = True
                rbSearchBy_I.Enabled = True
                rbSearchBy_S.Enabled = True
            Else
                gbSearchBy.Enabled = False
                rbSearchBy_I.Enabled = False
                rbSearchBy_S.Enabled = False
            End If

            If nSearchBy = 0 Or nSearchBy = 2 Then
                rbSearchBy_S.Checked = True
            Else
                rbSearchBy_I.Checked = True
            End If
        ElseIf m = "SEARCH" Then
            tcfrmCLMQuickInsert.TabPages(0).Enabled = False
            tcfrmCLMQuickInsert.TabPages(1).Enabled = True

            tcfrmCLMQuickInsert.SelectedIndex = 1
            chkSelectAll.Checked = False
            cmdInsert.Enabled = False
        End If
    End Sub

    'Private Sub cmdClaimPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClaimPeriod.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Name
    '    frmComSearch.callFmCriteria = txt_S_ClaimPeriod.Name
    '    frmComSearch.callFmString = txt_S_ClaimPeriod.Text

    '    frmComSearch.show_frmS(cmdClaimPeriod)
    'End Sub

    'Private Sub cmdCoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoCde.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Name
    '    frmComSearch.callFmCriteria = txt_S_CoCde.Name
    '    frmComSearch.callFmString = txt_S_CoCde.Text

    '    frmComSearch.show_frmS(cmdCoCde)
    'End Sub

    'Private Sub cmdPriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPriCust.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Name
    '    frmComSearch.callFmCriteria = txt_S_PriCust.Name
    '    frmComSearch.callFmString = txt_S_PriCust.Text

    '    frmComSearch.show_frmS(cmdPriCust)
    'End Sub

    'Private Sub cmdSecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSecCust.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Name
    '    frmComSearch.callFmCriteria = txt_S_SecCust.Name
    '    frmComSearch.callFmString = txt_S_SecCust.Text

    '    frmComSearch.show_frmS(cmdSecCust)
    'End Sub

    'Private Sub cmdPV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPV.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Name
    '    frmComSearch.callFmCriteria = txt_S_PV.Name
    '    frmComSearch.callFmString = txt_S_PV.Text

    '    frmComSearch.show_frmS(cmdPV)
    'End Sub

    Private Sub cmdItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(cmdItmNo)
    End Sub

    Private Sub cmdShipNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShipNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ShipNo.Name
        frmComSearch.callFmString = txt_S_ShipNo.Text

        frmComSearch.show_frmS(cmdShipNo)
    End Sub

    Private Sub cmdSCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSCNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        frmComSearch.show_frmS(cmdSCNo)
    End Sub

    Private Sub cmdPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPONo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PONo.Name
        frmComSearch.callFmString = txt_S_PONo.Text

        frmComSearch.show_frmS(cmdPONo)
    End Sub

    Private Sub cmdJobNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJobNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_JobNo.Name
        frmComSearch.callFmString = txt_S_JobNo.Text

        frmComSearch.show_frmS(cmdJobNo)
    End Sub

    Private Sub cmdInvNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_InvNo.Name
        frmComSearch.callFmString = txt_S_InvNo.Text

        frmComSearch.show_frmS(cmdInvNo)
    End Sub

    Private Sub cmdCustPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustPONo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CustPONo.Name
        frmComSearch.callFmString = txt_S_CustPONo.Text

        frmComSearch.show_frmS(cmdCustPONo)
    End Sub

    Private Sub cmdCustItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CustItmNo.Name
        frmComSearch.callFmString = txt_S_CustItmNo.Text

        frmComSearch.show_frmS(cmdCustItmNo)
    End Sub

    Private Sub cmdCustStyleNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustStyleNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CustStyleNo.Name
        frmComSearch.callFmString = txt_S_CustStyleNo.Text

        frmComSearch.show_frmS(cmdCustStyleNo)
    End Sub

    Private Sub rbSearchBy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSearchBy_I.CheckedChanged, rbSearchBy_S.CheckedChanged
        If rbSearchBy_I.Checked Then
            nSearchBy = 1
        Else
            nSearchBy = 2
        End If
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim CLAIMPERIODFM As String
        Dim CLAIMPERIODTO As String
        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        Dim PVLIST As String
        Dim ITMNOLIST As String
        Dim SHIPNOLIST As String
        Dim SCNOLIST As String
        Dim PONOLIST As String
        Dim JOBNOLIST As String
        Dim INVNOLIST As String
        Dim CUSPONOLIST As String
        Dim CUSITMNOLIST As String
        Dim CUSSTYLENOLIST As String
        'Dim INVISSDATFM As String
        'Dim INVISSDATTO As String

        If Trim(txt_S_ClaimPeriod.Text) = "" Then
            MsgBox("The Claim Period is empty!")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            CLAIMPERIODFM = txt_S_ClaimPeriod.Text.Split(" - ")(0)
            CLAIMPERIODTO = txt_S_ClaimPeriod.Text.Split(" - ")(2)

            If Not IsDate(CLAIMPERIODFM) Then
                MsgBox("Invalid Date Format: Claim Period Date From")
                txt_S_ClaimPeriod.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Not IsDate(CLAIMPERIODTO) Then
                MsgBox("Invalid Date Format: Claim Period Date To")
                txt_S_ClaimPeriod.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Trim(txt_S_CoCde.Text) = "" Then
            MsgBox("The Company Code List is empty!")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            If Len(txt_S_CoCde.Text) > 1000 Then
                MsgBox("The Company Code List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            COCDELIST = Trim(txt_S_CoCde.Text)
            COCDELIST = Replace(COCDELIST, "'", "''")
        End If

        If Trim(txt_S_PriCust.Text) = "" Then
            CUS1NOLIST = ""
        Else
            If Len(txt_S_PriCust.Text) > 1000 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                Me.Cursor = Cursors.Default
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
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            CUS2NOLIST = Trim(txt_S_SecCust.Text)
            CUS2NOLIST = Replace(CUS2NOLIST, "'", "''")
        End If

        If Trim(txt_S_PV.Text) = "" Then
            PVLIST = ""
        Else
            If Len(txt_S_PV.Text) > 1000 Then
                MsgBox("The Production Vendor List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            PVLIST = Trim(txt_S_PV.Text)
            PVLIST = Replace(PVLIST, "'", "''")
        End If

        If Trim(txt_S_ItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(txt_S_ItmNo.Text) > 1000 Then
                MsgBox("The Item No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            ITMNOLIST = Trim(txt_S_ItmNo.Text)
            ITMNOLIST = Replace(ITMNOLIST, "'", "''")
        End If

        If Trim(txt_S_ShipNo.Text) = "" Then
            SHIPNOLIST = ""
        Else
            If Len(txt_S_ShipNo.Text) > 1000 Then
                MsgBox("The Shipment No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            SHIPNOLIST = Trim(txt_S_ShipNo.Text)
            SHIPNOLIST = Replace(SHIPNOLIST, "'", "''")
        End If

        If Trim(txt_S_SCNo.Text) = "" Then
            SCNOLIST = ""
        Else
            If Len(txt_S_SCNo.Text) > 1000 Then
                MsgBox("The SC No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            SCNOLIST = Trim(txt_S_SCNo.Text)
            SCNOLIST = Replace(SCNOLIST, "'", "''")
        End If

        If Trim(txt_S_PONo.Text) = "" Then
            PONOLIST = ""
        Else
            If Len(txt_S_PONo.Text) > 1000 Then
                MsgBox("The PO No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            PONOLIST = Trim(txt_S_PONo.Text)
            PONOLIST = Replace(PONOLIST, "'", "''")
        End If

        If Trim(txt_S_JobNo.Text) = "" Then
            JOBNOLIST = ""
        Else
            If Len(txt_S_JobNo.Text) > 1000 Then
                MsgBox("The Job No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            JOBNOLIST = Trim(txt_S_JobNo.Text)
            JOBNOLIST = Replace(JOBNOLIST, "'", "''")
        End If

        If Trim(txt_S_InvNo.Text) = "" Then
            INVNOLIST = ""
        Else
            If Len(txt_S_InvNo.Text) > 1000 Then
                MsgBox("The Invoice No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            INVNOLIST = Trim(txt_S_InvNo.Text)
            INVNOLIST = Replace(INVNOLIST, "'", "''")
        End If

        If Trim(txt_S_CustPONo.Text) = "" Then
            CUSPONOLIST = ""
        Else
            If Len(txt_S_CustPONo.Text) > 1000 Then
                MsgBox("The Customer PO No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            CUSPONOLIST = Trim(txt_S_CustPONo.Text)
            CUSPONOLIST = Replace(CUSPONOLIST, "'", "''")
        End If

        If Trim(txt_S_CustItmNo.Text) = "" Then
            CUSITMNOLIST = ""
        Else
            If Len(txt_S_CustItmNo.Text) > 1000 Then
                MsgBox("The Custom Item No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            CUSITMNOLIST = Trim(txt_S_CustItmNo.Text)
            CUSITMNOLIST = Replace(CUSITMNOLIST, "'", "''")
        End If

        If Trim(txt_S_CustStyleNo.Text) = "" Then
            CUSSTYLENOLIST = ""
        Else
            If Len(txt_S_CustStyleNo.Text) > 1000 Then
                MsgBox("Then Custom Style No List is too long (1000 char)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            CUSSTYLENOLIST = Trim(txt_S_CustStyleNo.Text)
            CUSSTYLENOLIST = Replace(CUSSTYLENOLIST, "'", "''")
        End If


        '        strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

        'If Me.txt_S_InvIssDateFm.Text <> "__/__/____" Then
        '    If Not IsDate(Me.txt_S_InvIssDateFm.Text) Then
        '        MsgBox("Invalid Date Format: Invoice Issue Date From")
        '        Me.txt_S_InvIssDateFm.Focus()
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If
        'End If

        'If Me.txt_S_InvIssDateTo.Text <> "__/__/____" Then
        '    If Not IsDate(Me.txt_S_InvIssDateTo.Text) Then
        '        MsgBox("Invalid Date Format: Invoice Issue Date To")
        '        Me.txt_S_InvIssDateTo.Focus()
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If
        'End If

        'If Mid(Me.txt_S_InvIssDateFm.Text, 7) > Mid(Me.txt_S_InvIssDateTo.Text, 7) Then
        '    MsgBox("Invoice Date: End Date < Start Date (YY)")
        '    Me.txt_S_InvIssDateFm.Focus()
        '    Me.Cursor = Cursors.Default
        '    Exit Sub
        'ElseIf Mid(Me.txt_S_InvIssDateFm.Text, 7) = Mid(Me.txt_S_InvIssDateTo.Text, 7) Then
        '    If Me.txt_S_InvIssDateFm.Text.Substring(0, 2) > Me.txt_S_InvIssDateTo.Text.Substring(0, 2) Then
        '        MsgBox("Invoice Date: End Date < Start Date (MM)")
        '        Me.txt_S_InvIssDateFm.Focus()
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    ElseIf Me.txt_S_InvIssDateFm.Text.Substring(0, 2) = Me.txt_S_InvIssDateTo.Text.Substring(0, 2) Then
        '        If Me.txt_S_InvIssDateFm.Text.Substring(3, 2) > Me.txt_S_InvIssDateTo.Text.Substring(3, 2) Then
        '            MsgBox("Invoice Date: End Date < Start Date (DD)")
        '            Me.txt_S_InvIssDateFm.Focus()
        '            Me.Cursor = Cursors.Default
        '            Exit Sub
        '        End If
        '    End If
        'End If

        'If Me.txt_S_InvIssDateFm.Text = "__/__/____" Then
        '    INVISSDATFM = "01/01/1900"
        'Else
        '    INVISSDATFM = Me.txt_S_InvIssDateFm.Text
        'End If

        'If Me.txt_S_InvIssDateTo.Text = "__/__/____" Then
        '    INVISSDATTO = "01/01/1900"
        'Else
        '    INVISSDATTO = Me.txt_S_InvIssDateTo.Text
        'End If

        Try
            'gspStr = "sp_list_frmCLMQuickInsert '" & _
            '            COCDELIST & "','" & _
            '            CUS1NOLIST & "','" & _
            '            CUS2NOLIST & "','" & _
            '            PVLIST & "','" & _
            '            ITMNOLIST & "','" & _
            '            SCNOLIST & "','" & _
            '            PONOLIST & "','" & _
            '            JOBNOLIST & "','" & _
            '            INVNOLIST & "','" & _
            '            CUSPONOLIST & "','" & _
            '            CUSITMNOLIST & "','" & _
            '            CUSSTYLENOLIST & "','" & _
            '            INVISSDATFM & "','" & _
            '            INVISSDATTO & "','" & _
            '            gsUsrID & "'"

            'gspStr = "sp_list_frmCLMQuickInsert_Item '" & _
            '            CLAIMPERIODFM & "','" & _
            '            CLAIMPERIODTO & "','" & _
            '            COCDELIST & "','" & _
            '            CUS1NOLIST & "','" & _
            '            CUS2NOLIST & "','" & _
            '            PVLIST & "','" & _
            '            ITMNOLIST & "','" & _
            '            SHIPNOLIST & "','" & _
            '            SCNOLIST & "','" & _
            '            PONOLIST & "','" & _
            '            JOBNOLIST & "','" & _
            '            INVNOLIST & "','" & _
            '            CUSPONOLIST & "','" & _
            '            CUSITMNOLIST & "','" & _
            '            CUSSTYLENOLIST & "','" & _
            '            gsUsrID & "'"

            Dim cliam_period_start As String
            Dim cliam_period_end As String
            'Split(cboPriCust.Text, " - ")(0).ToString()
            cliam_period_start = Split(gs_cliam_period, " - ")(0).ToString.Trim
            cliam_period_end = Split(gs_cliam_period, " - ")(1).ToString.Trim


            If rbSearchBy_S.Checked = False Then
                '''
                gspStr = "sp_list_frmCLMQuickInsert_Item '" & _
                            COCDELIST & "','" & _
                            CUS1NOLIST & "','" & _
                            CUS2NOLIST & "','" & _
                            PVLIST & "','" & _
                            ITMNOLIST & "','" & _
                            SCNOLIST & "','" & _
                            PONOLIST & "','" & _
                            JOBNOLIST & "','" & _
                            INVNOLIST & "','" & _
                            CUSPONOLIST & "','" & _
                            CUSITMNOLIST & "','" & _
                            CUSSTYLENOLIST & "','" & _
                            "03/31/2012" & "','" & _
                            "09/09/2029" & " ','" & _
                            cliam_period_start & "','" & _
                            cliam_period_end & " ','" & _
                            gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs_frmCLMQuickInsert_Item, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading frmCLMQuickInsert sp_list_frmCLMQuickInsert_Item : " & rtnStr)
                    Exit Sub
                Else
                    If rs_frmCLMQuickInsert_Item.Tables("RESULT").Rows.Count = 0 Then
                        MsgBox("No Record found for Item Searching!")
                    Else
                    End If
                End If

                dgResult.DataSource = rs_frmCLMQuickInsert_Item.Tables("RESULT").DefaultView
                rs_frmCLMQuickInsert_Item.Tables("RESULT").Columns("Add").ReadOnly = False
                dgResult.Columns("Add").ReadOnly = False
                format_dgResult_Item()

                '''get the 2nd rs at the same time
                gspStr = "sp_list_frmCLMQuickInsert '" & _
                            COCDELIST & "','" & _
                            CUS1NOLIST & "','" & _
                            CUS2NOLIST & "','" & _
                            PVLIST & "','" & _
                            ITMNOLIST & "','" & _
                            SCNOLIST & "','" & _
                            PONOLIST & "','" & _
                            JOBNOLIST & "','" & _
                            INVNOLIST & "','" & _
                            CUSPONOLIST & "','" & _
                            CUSITMNOLIST & "','" & _
                            CUSSTYLENOLIST & "','" & _
                            "03/31/2012" & "','" & _
                            "09/09/2029" & " ','" & _
                            cliam_period_start & "','" & _
                            cliam_period_end & " ','" & _
                            gsUsrID & "'"


                rtnLong = execute_SQLStatement(gspStr, rs_frmCLMQuickInsert, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading frmCLMQuickInsert sp_list_frmCLMQuickInsert : " & rtnStr)
                Else
                    If rs_frmCLMQuickInsert.Tables("RESULT").Rows.Count = 0 Then
                        MsgBox("No Record found for Shipment Searhing!")
                    Else
                    End If
                End If

            Else
                '''
                gspStr = "sp_list_frmCLMQuickInsert '" & _
                            COCDELIST & "','" & _
                            CUS1NOLIST & "','" & _
                            CUS2NOLIST & "','" & _
                            PVLIST & "','" & _
                            ITMNOLIST & "','" & _
                            SCNOLIST & "','" & _
                            PONOLIST & "','" & _
                            JOBNOLIST & "','" & _
                            INVNOLIST & "','" & _
                            CUSPONOLIST & "','" & _
                            CUSITMNOLIST & "','" & _
                            CUSSTYLENOLIST & "','" & _
                            "03/31/2012" & "','" & _
                            "09/09/2029" & " ','" & _
                            cliam_period_start & "','" & _
                            cliam_period_end & " ','" & _
                            gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs_frmCLMQuickInsert, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading frmCLMQuickInsert sp_list_frmCLMQuickInsert : " & rtnStr)
                Else
                    If rs_frmCLMQuickInsert.Tables("RESULT").Rows.Count = 0 Then
                        MsgBox("No Record found for Shipment Searhing!")
                    Else
                    End If
                End If
                dgResult.DataSource = rs_frmCLMQuickInsert.Tables("RESULT").DefaultView
                rs_frmCLMQuickInsert.Tables("RESULT").Columns("Add").ReadOnly = False
                dgResult.Columns("Add").ReadOnly = False
                format_dgResult()
            End If


            'If nSearchBy = 1 Then
            'Else
            'End If



            mode = "SEARCH"
            formInit(mode)


            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub format_dgResult_Item()
        dgResult.Columns(0).Width = 32
        dgResult.Columns(0).HeaderText = "Add"
        dgResult.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

        dgResult.Columns(1).Width = 50
        dgResult.Columns(1).HeaderText = "Comp"

        dgResult.Columns(2).Width = 110
        dgResult.Columns(2).HeaderText = "Item No"

        dgResult.Columns(3).Width = 40
        dgResult.Columns(3).HeaderText = "Type"

        dgResult.Columns(4).Width = 250
        dgResult.Columns(4).HeaderText = "Desc"

        dgResult.Columns(5).Width = 98
        dgResult.Columns(5).HeaderText = "Cust Item No"

        dgResult.Columns(6).Width = 101
        dgResult.Columns(6).HeaderText = "Cust Style No"

        ''dgResult.Columns(7).Width = 115
        ''dgResult.Columns(7).HeaderText = "Vendor Item No"

        ''dgResult.Columns(8).Width = 90
        ''dgResult.Columns(8).HeaderText = "PV"

        ''dgResult.Columns(9).Width = 38
        ''dgResult.Columns(9).HeaderText = "Type"

        ''dgResult.Columns(3).Visible = False
        'dgResult.Columns(3).Width = 38
        'dgResult.Columns(3).HeaderText = "UM"

        ''dgResult.Columns(4).Visible = False
        'dgResult.Columns(4).Width = 80
        'dgResult.Columns(4).HeaderText = "Ship Qty"
    End Sub

    Private Sub format_dgResult()
        Dim i As Integer

        'temp comment 20140219
        'If nSearchBy = 1 Then
        If nSearchBy = 2 Then

            i = 0
            dgResult.Columns(i).Width = 32
            dgResult.Columns(i).HeaderText = "Add"
            dgResult.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Comp"

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Ord. No"

            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Seq"

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Pur. No"

            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Seq"

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Job Ord."

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Issue Date"

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "hih_slnonb"

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Arrival Date"

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Invoice No."

            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Ship No."

            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Seq"


            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "UM"

            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Ship Qty"
            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Unit Amt"
            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Total Amt"
            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Item No."
            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Item Type"
            i = i + 1
            dgResult.Columns(i).Width = 300
            dgResult.Columns(i).HeaderText = "Item Desc"
            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Customer PO"
            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Customer Item"
            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Cust Style No."
            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Vendor Item"
            i = i + 1
            dgResult.Columns(i).Width = 100
            dgResult.Columns(i).HeaderText = "Prod. Vendor"
            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Ven. Type"
            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Cur. Code"
            i = i + 1
            dgResult.Columns(i).Width = 60
            dgResult.Columns(i).HeaderText = "Sell Price"
            i = i + 1
            dgResult.Columns(i).Width = 60
            dgResult.Columns(i).HeaderText = "Unit Price"
            i = i + 1
            dgResult.Columns(i).Width = 60
            dgResult.Columns(i).HeaderText = "Net U. Price"
            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "Cur. Code"
            i = i + 1
            dgResult.Columns(i).Width = 60
            dgResult.Columns(i).HeaderText = "FTY Price"

            i = i + 1
            dgResult.Columns(i).Width = 50
            dgResult.Columns(i).HeaderText = "UM"
            i = i + 1
            dgResult.Columns(i).Width = 60
            dgResult.Columns(i).HeaderText = "Ord. Qty"
            i = i + 1
            dgResult.Columns(i).Width = 60
            dgResult.Columns(i).HeaderText = "Ship Qty"


            ''''20140219
            '' ''    'dgResult.Columns(3).Width = 40
            '' ''    'dgResult.Columns(3).HeaderText = "Type"

            '' ''    'dgResult.Columns(4).Width = 250
            '' ''    'dgResult.Columns(4).HeaderText = "Desc"

            '' ''    'dgResult.Columns(5).Width = 98
            '' ''    'dgResult.Columns(5).HeaderText = "Cust Item No"

            '' ''    'dgResult.Columns(6).Width = 101
            '' ''    'dgResult.Columns(6).HeaderText = "Cust Style No"

            '' ''    'dgResult.Columns(7).Width = 115
            '' ''    'dgResult.Columns(7).HeaderText = "Vendor Item No"

            '' ''    'dgResult.Columns(8).Width = 90
            '' ''    'dgResult.Columns(8).HeaderText = "PV"

            '' ''    'dgResult.Columns(9).Width = 38
            '' ''    'dgResult.Columns(9).HeaderText = "Type"

            '' ''    'dgResult.Columns(3).Visible = False
            '' ''    dgResult.Columns(3).Width = 38
            '' ''    dgResult.Columns(3).HeaderText = "UM"

            '' ''    'dgResult.Columns(4).Visible = False
            '' ''    dgResult.Columns(4).Width = 80
            '' ''    dgResult.Columns(4).HeaderText = "Ship Qty"
            '' ''Else
            '' ''    dgResult.Columns(0).Width = 32
            '' ''    dgResult.Columns(0).HeaderText = "Add"
            '' ''    dgResult.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

            '' ''    dgResult.Columns(1).Width = 50
            '' ''    dgResult.Columns(1).HeaderText = "Comp"

            '' ''    dgResult.Columns(2).Width = 65
            '' ''    dgResult.Columns(2).HeaderText = "SC No"

            '' ''    dgResult.Columns(3).Width = 38
            '' ''    dgResult.Columns(3).HeaderText = "Seq"

            '' ''    dgResult.Columns(4).Width = 68
            '' ''    dgResult.Columns(4).HeaderText = "PO No"

            '' ''    dgResult.Columns(5).Width = 38
            '' ''    dgResult.Columns(5).HeaderText = "Seq"

            '' ''    dgResult.Columns(6).Width = 98
            '' ''    dgResult.Columns(6).HeaderText = "Job No"

            '' ''    dgResult.Columns(7).Width = 85
            '' ''    dgResult.Columns(7).HeaderText = "Invoice No"

            '' ''    dgResult.Columns(8).Width = 85
            '' ''    dgResult.Columns(8).HeaderText = "Issue Date"

            '' ''    'dgResult.Columns(9).Visible = False
            '' ''    dgResult.Columns(9).Width = 85
            '' ''    dgResult.Columns(9).HeaderText = "ETD Date"

            '' ''    'dgResult.Columns(10).Visible = False
            '' ''    dgResult.Columns(10).Width = 85
            '' ''    dgResult.Columns(10).HeaderText = "ETA Date"

            '' ''    dgResult.Columns(11).Width = 110
            '' ''    dgResult.Columns(11).HeaderText = "Item No"

            '' ''    dgResult.Columns(12).Width = 40
            '' ''    dgResult.Columns(12).HeaderText = "Type"

            '' ''    dgResult.Columns(13).Width = 250
            '' ''    dgResult.Columns(13).HeaderText = "Desc"

            '' ''    dgResult.Columns(14).Width = 95
            '' ''    dgResult.Columns(14).HeaderText = "Cust PO No"

            '' ''    dgResult.Columns(15).Width = 98
            '' ''    dgResult.Columns(15).HeaderText = "Cust Item No"

            '' ''    dgResult.Columns(16).Width = 101
            '' ''    dgResult.Columns(16).HeaderText = "Cust Style No"

            '' ''    dgResult.Columns(17).Width = 115
            '' ''    dgResult.Columns(17).HeaderText = "Vendor Item No"

            '' ''    dgResult.Columns(18).Width = 90
            '' ''    dgResult.Columns(18).HeaderText = "PV"

            '' ''    dgResult.Columns(19).Width = 38
            '' ''    dgResult.Columns(19).HeaderText = "Type"

            '' ''    dgResult.Columns(20).Width = 38
            '' ''    dgResult.Columns(20).HeaderText = "Curr"

            '' ''    dgResult.Columns(21).Width = 80
            '' ''    dgResult.Columns(21).HeaderText = "Sell Price"
            '' ''    dgResult.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '' ''    'dgResult.Columns(22).Visible = False
            '' ''    dgResult.Columns(22).Width = 80
            '' ''    dgResult.Columns(22).HeaderText = "Unit Price"

            '' ''    'dgResult.Columns(23).Visible = False
            '' ''    dgResult.Columns(23).Width = 80
            '' ''    dgResult.Columns(23).HeaderText = "Net Unit Price"

            '' ''    dgResult.Columns(24).Width = 38
            '' ''    dgResult.Columns(24).HeaderText = "Curr"

            '' ''    dgResult.Columns(25).Width = 80
            '' ''    dgResult.Columns(25).HeaderText = "Item Cost"
            '' ''    dgResult.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '' ''    dgResult.Columns(26).Width = 90
            '' ''    dgResult.Columns(26).HeaderText = "Order Unit"

            '' ''    dgResult.Columns(27).Width = 90
            '' ''    dgResult.Columns(27).HeaderText = "Order Qty"

            '' ''    'dgResult.Columns(28).Visible = False
            '' ''    dgResult.Columns(28).Width = 90
            '' ''    dgResult.Columns(28).HeaderText = "Ship Unit"

            '' ''    dgResult.Columns(29).Width = 90
            '' ''    dgResult.Columns(29).HeaderText = "Ship Qty"

            '' ''    dgResult.Columns(30).Width = 75
            '' ''    dgResult.Columns(30).HeaderText = "Ship No"
            '' ''    dgResult.Columns(30).DisplayIndex = 1

            '' ''    dgResult.Columns(31).Width = 38
            '' ''    dgResult.Columns(31).HeaderText = "Seq"
            '' ''    dgResult.Columns(31).DisplayIndex = 2
        End If
    End Sub

    Private Sub dgResult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellClick
        If Not (e.ColumnIndex = -1 Or e.RowIndex = -1) Then
            'If e.ColumnIndex = 0 Then
            Dim cell As DataGridViewCell = dgResult.Item(0, e.RowIndex)

            dgResult.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If cell.Value <> "Y" Then
                cell.Value = "Y"
                recordSelected = recordSelected + 1
                dgResult.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                cell.Value = ""
                recordSelected = recordSelected - 1
                dgResult.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If

            If recordSelected > 0 Then
                Me.cmdInsert.Enabled = True
            Else
                Me.cmdInsert.Enabled = False
            End If
            'End If
        End If
    End Sub

    Private Sub dgResult_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgResult.Sorted
        For Each r As DataGridViewRow In dgResult.Rows
            If r.Cells("Add").Value.ToString.Equals("Y") Then
                r.DefaultCellStyle.BackColor = Color.LightBlue
            End If
        Next
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged

        If chkSelectAll.Checked Then
            For Each r As DataGridViewRow In dgResult.Rows
                r.Cells("Add").Value = "Y"
                r.DefaultCellStyle.BackColor = Color.LightBlue
            Next
            recordSelected = dgResult.RowCount
            Me.cmdInsert.Enabled = True
        Else
            For Each r As DataGridViewRow In dgResult.Rows
                r.Cells("Add").Value = ""
                r.DefaultCellStyle.BackColor = Color.Empty
            Next
            recordSelected = 0
            Me.cmdInsert.Enabled = False
        End If

    End Sub



    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click


        Try
            'If Not chkSelectAll.Checked Then
            '    Dim sItmList As String = String.Empty

            '    sItmList = get_selected_ItemNo()

            '    If nSearchBy = 1 Then
            '        RaiseEvent returnSelectedRecords(Me, _
            '                                             rs_frmCLMQuickInsert.Tables("RESULT").Select("sod_itmno IN (" + sItmList + ")"), _
            '                                             rs_frmCLMQuickInsert_Item.Tables("RESULT").Select("Add = 'Y'"), _
            '                                             nSearchBy)
            '    Else
            '        RaiseEvent returnSelectedRecords(Me, _
            '                                             rs_frmCLMQuickInsert.Tables("RESULT").Select("Add = 'Y'"), _
            '                                             rs_frmCLMQuickInsert_Item.Tables("RESULT").Select("sod_itmno = '" + sItmList + "'"), _
            '                                             nSearchBy)
            '    End If
            'Else
            '    RaiseEvent returnSelectedRecords(Me, _
            '                                         rs_frmCLMQuickInsert.Tables("RESULT").Select(), _
            '                                         rs_frmCLMQuickInsert_Item.Tables("RESULT").Select(), _
            '                                         nSearchBy)
            'End If
            If Not chkSelectAll.Checked Then
                Dim sItmList As String = String.Empty

                sItmList = get_selected_ItemNo()

                ''Item
                If nSearchBy = 1 Then
                    RaiseEvent returnSelectedRecords(Me, _
                                                         rs_frmCLMQuickInsert.Tables("RESULT").Select("sod_itmno IN (" + sItmList + ")"), _
                                                         nSearchBy)
                Else
                    '''ship
                    RaiseEvent returnSelectedRecords(Me, _
                                                         rs_frmCLMQuickInsert.Tables("RESULT").Select("Add = 'Y'"), _
                                                         nSearchBy)
                End If
            Else
                RaiseEvent returnSelectedRecords(Me, _
                                                     rs_frmCLMQuickInsert.Tables("RESULT").Select(), _
                                                     nSearchBy)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            Me.Close()
        End Try
    End Sub

    Private Function get_selected_ItemNo() As String
        Dim sOldItmNo As String = String.Empty
        Dim sNewItmNo As String = String.Empty
        Dim sItmNoList As String = String.Empty

        For index As Integer = 0 To dgResult.RowCount - 1
            If dgResult.Rows(index).Cells("Add").Value = "Y" Then
                sNewItmNo = dgResult.Rows(index).Cells(2).Value
                If sOldItmNo <> sNewItmNo Then
                    sItmNoList = sItmNoList + "'" + sNewItmNo + "',"
                End If
                sOldItmNo = sNewItmNo
            End If
        Next
        sItmNoList = sItmNoList.Substring(0, sItmNoList.Length - 1)

        Return sItmNoList
    End Function

    'Public Event returnSelectedRecords(ByVal sender As Object, _
    '                                   ByVal TableToReturn As DataRow(), _
    '                                   ByVal TableToReturn_Item As DataRow(), _
    '                                   ByVal TableToReturn_SearchBy As Integer)
    Public Event returnSelectedRecords(ByVal sender As Object, _
                                   ByVal TableToReturn As DataRow(), _
                                   ByVal TableToReturn_SearchBy As Integer)


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        mode = "INIT"
        formInit(mode)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit1.Click, cmdExit2.Click
        Me.Close()
    End Sub

    'Private Sub txt_S_InvIssDateFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txt_S_InvIssDateFm.SelectAll()
    'End Sub

    'Private Sub txt_S_InvIssDateTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txt_S_InvIssDateTo.SelectAll()
    'End Sub

    'Private Sub txt_S_InvIssDateFm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar.Equals(Chr(13)) Then
    '        Me.txt_S_InvIssDateTo.Focus()
    '    End If
    'End Sub

    'Private Sub txt_S_InvIssDateFm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.txt_S_InvIssDateTo.Text <> "__/__/____" Then
    '        If Not IsDate(Me.txt_S_InvIssDateFm.Text) Then
    '            MsgBox("Invalid Date Format: Invoice Issue Date From")
    '            Me.txt_S_InvIssDateFm.Focus()
    '        Else
    '            Me.txt_S_InvIssDateTo.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub txt_S_InvIssDateTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar.Equals(Chr(13)) Then
    '        Me.cmdSearch.Focus()
    '    End If
    'End Sub

    'Private Sub txt_S_InvIssDateTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.txt_S_InvIssDateTo.Text <> "__/__/____" Then
    '        If Not IsDate(Me.txt_S_InvIssDateTo.Text) Then
    '            MsgBox("Invalid Date Format: Invoice Issue Date To")
    '            Me.txt_S_InvIssDateTo.Focus()
    '        Else
    '            Me.cmdSearch.Focus()
    '        End If
    '    End If
    'End Sub

    Private Sub cmdClaimPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClaimPeriod.Click

    End Sub

    Private Sub lblClaimPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClaimPeriod.Click

    End Sub

    Private Sub lblShipNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShipNo.Click

    End Sub

    Private Sub txt_S_ShipNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_ShipNo.TextChanged

    End Sub

    Public Function get_date_range(ByVal get_period As String)

        'MsgBox(get_period)
        'Split(cboPriCust.Text, " - ")(0).ToString()
        gs_cliam_period = get_period

    End Function

End Class
























