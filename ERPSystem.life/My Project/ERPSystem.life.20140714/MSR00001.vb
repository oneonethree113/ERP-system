Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Public Class MSR00001
    Dim rs_CUBASINF As DataSet
    Dim rs_CUBASINF2 As DataSet
    Dim rs_VNBASINF As DataSet
    Dim rs_SYSETINF As DataSet
    Dim rs_SYLNEINF As DataSet
    Dim rs_SYSALREP As DataSet
    Dim rs_MSR00001 As DataSet
    Dim rs_EXCEL As DataSet

    Dim cocde_enu As Integer = 0
    Dim opt1Fm_enu As Integer = 1
    Dim opt1To_enu As Integer = 2
    Dim opt2Fm_enu As Integer = 3
    Dim opt2To_enu As Integer = 4
    Dim STFm_enu As Integer = 5
    Dim STTo_enu As Integer = 6
    Dim opt3Fm_enu As Integer = 7
    Dim opt3To_enu As Integer = 8
    Dim opt4Fm_enu As Integer = 9
    Dim opt4To_enu As Integer = 10
    Dim seccnf_enu As Integer = 11
    Dim seccnt_enu As Integer = 12
    Dim opt5Fm_enu As Integer = 13
    Dim opt5To_enu As Integer = 14
    Dim opt6Fm_enu As Integer = 15
    Dim opt6To_enu As Integer = 16
    Dim opt7Fm_enu As Integer = 17
    Dim opt7To_enu As Integer = 18
    Dim opt9Fm_enu As Integer = 19
    Dim opt9To_enu As Integer = 20
    Dim opt10_enu As Integer = 21
    Dim opt11_enu As Integer = 22
    Dim opt12Fm_enu As Integer = 23
    Dim opt12To_enu As Integer = 24
    Dim cbi_cusno_enu As Integer = 25
    Dim cbi_cussna_enu As Integer = 26
    Dim Seccustno_enu As Integer = 27
    Dim secCustName_enu As Integer = 28
    Dim soh_curcde_enu As Integer = 29
    Dim sod_ordno_enu As Integer = 30
    Dim sod_cuspo_enu As Integer = 31
    Dim sod_cusitm_enu As Integer = 32
    Dim pod_venitm_enu As Integer = 33
    Dim sod_itmno_enu As Integer = 34
    Dim sod_itmdsc_enu As Integer = 35
    Dim pod_jobord_enu As Integer = 36
    Dim outstandQty_enu As Integer = 37
    Dim sod_pckunt_enu As Integer = 38
    Dim outstandCtn_enu As Integer = 39
    Dim sod_untprc_enu As Integer = 40
    Dim sod_untprcStr_enu As Integer = 41
    Dim outstandAmt_enu As Integer = 42
    Dim outstandAmtStr_enu As Integer = 43
    Dim sod_shpstr_enu As Integer = 44
    Dim sod_shpend_enu As Integer = 45
    Dim sod_subcde_enu As Integer = 46
    Dim ysi_dsc_enu As Integer = 47
    Dim vbi_vensna_enu As Integer = 48
    Dim sod_venno_enu As Integer = 49
    Dim sod_balcbm As Integer = 50
    Dim compName As Integer = 51
    Dim sod_candat_enu As Integer = 52
    Dim sod_resppo_enu As Integer = 53
    Private Sub MSR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        cboSortBy.Items.Add("Customer PO#")
        cboSortBy.Items.Add("Ship Start Date")
        cboSortBy.SelectedIndex = 0

        'Set Date to Input Date
        'txtIssdatFm = Format(Date, "MM/DD/YYYY")
        'txtIssdatTo = Format(Date, "MM/DD/YYYY")
        'txtShipFm = Format(Date, "MM/DD/YYYY")
        'txtShipTo = Format(Date, "MM/DD/YYYY")

        '*** Multi-Company Name Display.
        Call FillCompCombo(gsUsrID, cboCocde)
        '*** ADD PRINT ALL COMPANY ***
        ' 2004/02/11
        'Lester Wu 2005-03-21 - Replace "ALL" with "UC-G"
        'Me.cboCoCde.AddItem "ALL"
        If gsDefaultCompany <> "MS" Then
            cboCocde.Items.Add("UC-G")
        End If
        '*****************************
        Call GetDefaultCompany(cboCocde, txtCoNam)

        Call Formstartup(Me.Name)






        '-- Retrieving Customer ,Ventor and SubCode data ----------


        Me.Cursor = Cursors.WaitCursor
        gspStr = "sp_list_CUBASINF '','PA'"

        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_CUBASINF:" & rtnStr)
            Exit Sub
        Else
            FillcboCust()
        End If




        gspStr = "sp_list_CUBASINF '','P'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF2, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_CUBASINF 2:" & rtnStr)
            Exit Sub
        Else

            Call FillcboCust2()
        End If


        gspStr = "sp_list_VNBASINF ''"

        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_VNBASINF:" & rtnStr)
            Exit Sub
        Else

            Call FillcboVen()
        End If


        If gsCompany = "UCP" Then

            gspStr = "sp_select_SUBCDE"

            rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)


            If rtnLong <> RC_SUCCESS Then  '*** An error has occured
                MsgBox("Error on loading sp_select_SUBCDE:" & rtnStr)
                Exit Sub
            Else

                Call FillcboSubCde()
            End If
        End If



        gspStr = "sp_list_SYLNEINF"

        rtnLong = execute_SQLStatement(gspStr, rs_SYLNEINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading sp_list_SYLNEINF:" & rtnStr)
            Exit Sub
        Else

            Call FillcboLneinf()
        End If

        '2004/02/16 Lester Wu
        gspStr = "sp_list_SYSALREP_CUR00002 '','" & gsUsrID & "'"    ' select distinct sales team, not user oriented
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading sp_list_SYSALREP_CUR00002:" & rtnStr)
            Exit Sub
        Else

            Call FillcboSalesTeam()
        End If
        '--------------------------------------------------------------


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FillcboCust()
        cboCustNoFm.Items.Clear()
        cboCustNoFm.Items.Add("")
        cboCustNoTo.Items.Clear()
        cboCustNoTo.Items.Add("")

        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_CUBASINF.Tables("RESULT").Rows.Count - 1
                cboCustNoFm.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cussna"))
                cboCustNoTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(i).Item("cbi_cussna"))

            Next
        End If
    End Sub
    Private Sub FillcboCust2()

        cboCust2NoFm.Items.Clear()
        cboCust2NoFm.Items.Add("")
        cboCust2NoTo.Items.Clear()
        cboCust2NoTo.Items.Add("")
        If rs_CUBASINF2.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_CUBASINF2.Tables("RESULT").Rows.Count - 1
                cboCust2NoFm.Items.Add(rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cussna"))
                cboCust2NoTo.Items.Add(rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF2.Tables("RESULT").Rows(i).Item("cbi_cussna"))

            Next
        End If
    End Sub
    Private Sub FillcboVen()
        cboVenNoFm.Items.Clear()
        cboVenNoFm.Items.Add("")
        cboVenNoTo.Items.Clear()
        cboVenNoTo.Items.Add("")
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenNoFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))
                cboVenNoTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))

            Next
        End If
    End Sub


    Private Sub FillcboSubCde()
        cboSubCdeFm.Items.Clear()
        cboSubCdeFm.Items.Add("")
        cboSubCdeTo.Items.Clear()
        cboSubCdeTo.Items.Add("")
        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_SYSETINF.Tables("RESULT").Rows.Count - 1
                cboSubCdeFm.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("subcde"))
                cboSubCdeTo.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("subcde"))

            Next
        End If
    End Sub


    Private Sub FillcboLneinf()
        cboPLFm.Items.Clear()
        cboPLFm.Items.Add("")
        cboPLTo.Items.Clear()
        cboPLTo.Items.Add("")
        If rs_SYLNEINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_SYLNEINF.Tables("RESULT").Rows.Count - 1
                cboPLFm.Items.Add(rs_SYLNEINF.Tables("RESULT").Rows(i).Item("yli_lnecde"))
                cboPLTo.Items.Add(rs_SYLNEINF.Tables("RESULT").Rows(i).Item("yli_lnecde"))

            Next
        End If
    End Sub
    Private Sub FillcboSalesTeam()
        Dim i As Integer
        cboSalesTeamFm.Items.Clear()
        cboSalesTeamTo.Items.Clear()
        cboSalesTeamFm.Items.Add("")
        cboSalesTeamTo.Items.Add("")
        If rs_SYSALREP.Tables("RESULT").Rows.Count > 0 Then

            For i = 0 To rs_SYSALREP.Tables("RESULT").Rows.Count - 1
                cboSalesTeamFm.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(i).Item("ysr_saltem")) ' & " - " & rs_SYSALREP("ysr_")
                cboSalesTeamTo.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(i).Item("ysr_saltem")) ' & " - " & rs_SYSALREP("ysr_")

            Next
        End If
        rs_SYSALREP = Nothing
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------




        'Upper Case validation -------------------
        '        txtOrderFm.Text = UCase(txtOrderFm.Text)
        '        txtOrderTo.Text = UCase(txtOrderTo.Text)
        '
        '        txtItemFm.Text = UCase(txtItemFm.Text)
        '        txtItemTo.Text = UCase(txtItemTo.Text)
        '
        '        cboPLFm.Text = UCase(cboPLFm.Text)
        '        cboPLTo.Text = UCase(cboPLTo.Text)


        '-- Default Combo box Range of Value -----------------------------------

        '            If cboCustNoFm.Text = "" And cboCustNoTo.Text = "" Then
        '                cboCustNoFm.ListIndex = 0
        '                cboCustNoTo.ListIndex = cboCustNoTo.ListCount - 1
        '            End If
        '
        '            If cboVenNoFm.Text = "" And cboVenNoTo.Text = "" Then
        '                cboVenNoFm.ListIndex = 0
        '                cboVenNoTo.ListIndex = cboVenNoTo.ListCount - 1
        '            End If
        '
        '            If gsCompany = "UCP" Then
        '                If cboSubCdeFm.Text = "" And cboSubCdeTo.Text = "" Then
        '                    cboSubCdeFm.ListIndex = 0
        '                    cboSubCdeTo.ListIndex = cboSubCdeTo.ListCount - 1
        '                End If
        '            End If
        '
        '            If cboPLFm.Text = "" And cboPLTo.Text = "" Then
        '                cboPLFm.ListIndex = 0
        '                cboPLTo.ListIndex = cboPLTo.ListCount - 1
        '            End If


        '-- Validation ===================================

        If checkValidCombo(cboCustNoFm, cboCustNoFm.Text) = False And cboCustNoFm.Text <> "" Then
            MsgBox("Invalid Value")
            cboCustNoFm.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboCustNoTo, cboCustNoTo.Text) = False And cboCustNoTo.Text <> "" Then
            MsgBox("Invalid Value")
            cboCustNoTo.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboCust2NoFm, cboCust2NoFm.Text) = False And cboCust2NoFm.Text <> "" Then
            MsgBox("Invalid Value")
            cboCust2NoFm.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboCust2NoTo, cboCust2NoTo.Text) = False And cboCust2NoTo.Text <> "" Then
            MsgBox("Invalid Value")
            cboCust2NoTo.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboPLFm, cboPLFm.Text) = False And cboPLFm.Text <> "" Then
            MsgBox("Invalid Value")
            cboPLFm.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboPLTo, cboPLTo.Text) = False And cboPLTo.Text <> "" Then
            MsgBox("Invalid Value")
            cboPLTo.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboSortBy, cboSortBy.Text) = False And cboSortBy.Text <> "" Then
            MsgBox("Invalid Value")
            cboSortBy.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboSubCdeFm, cboSubCdeFm.Text) = False And cboSubCdeFm.Text <> "" Then
            MsgBox("Invalid Value")
            cboSubCdeFm.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboSubCdeTo, cboSubCdeTo.Text) = False And cboSubCdeTo.Text <> "" Then
            MsgBox("Invalid Value")
            cboSubCdeTo.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboVenNoFm, cboVenNoFm.Text) = False And cboVenNoFm.Text <> "" Then
            MsgBox("Invalid Value")
            cboVenNoFm.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboVenNoTo, cboVenNoTo.Text) = False And cboVenNoTo.Text <> "" Then
            MsgBox("Invalid Value")
            cboVenNoTo.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboSalesTeamFm, cboSalesTeamFm.Text) = False And cboSalesTeamFm.Text <> "" Then
            MsgBox("Invalid Value")
            cboSalesTeamFm.Focus()
            Exit Sub
        End If
        If checkValidCombo(Me.cboSalesTeamTo, cboSalesTeamTo.Text) = False And cboSalesTeamTo.Text <> "" Then
            MsgBox("Invalid Value")
            cboSalesTeamTo.Focus()
            Exit Sub
        End If


        If cboPLFm.Text > cboPLTo.Text Then
            MsgBox("Product Line: To < From!")
            cboPLFm.Focus()
            Exit Sub
        End If


        If txtOrderFm.Text > txtOrderTo.Text Then
            MsgBox("Order No: To < From!")
            txtOrderFm.Focus()
            Exit Sub
        End If

        If txtItemFm.Text > txtItemTo.Text Then
            MsgBox("Item No: To < From!")
            txtItemFm.Focus()
            Exit Sub
        End If

        If cboCustNoFm.Text <> "" And cboCustNoTo.Text <> "" Then
            If Split(cboCustNoFm.Text, " - ")(0) > Split(cboCustNoTo.Text, " - ")(0) Then
                MsgBox("Customer No: To < From!")
                cboCustNoFm.Focus()
                Exit Sub
            End If
        End If
        ' 2004/02/11 Lester Wu --

        If cboCust2NoFm.Text <> "" And cboCust2NoTo.Text <> "" Then
            If Split(cboCust2NoFm.Text, " - ")(0) > Split(cboCust2NoTo.Text, " - ")(0) Then
                MsgBox("Secondary Customer No: To < From!")
                cboCust2NoFm.Focus()
                Exit Sub
            End If
        End If
        '--------------------------
        If txtCPOTo.Text < txtCPOFm.Text Then
            MsgBox("Customer PO To must <= Customer PO From")
            'InputIsVaild = False
            txtCPOTo.Focus()
            Exit Sub
        End If


        If cboVenNoFm.Text <> "" And cboVenNoTo.Text <> "" Then
            If Split(cboVenNoFm.Text, " - ")(0) > Split(cboVenNoTo.Text, " - ")(0) Then
                MsgBox("Vendor No: To < From!")
                cboVenNoFm.Focus()
                Exit Sub
            End If
        End If




        If gsCompany = "UCP" Then
            If cboSubCdeFm.Text > cboSubCdeTo.Text Then
                MsgBox("Sub Code: To < From!")
                cboSubCdeFm.Focus()
                Exit Sub
            End If
        End If


        ' Issue Date Validation -------------------------------
        '            If txtIssdatFm.Text > txtIssdatTo.Text Then
        '                MsgBox ("Issue Date: End Date < Start date !")
        '                txtIssdatFm.SetFocus
        '                Exit Sub
        '            End If


        ' 2004/02/16 Lester Wu
        If Me.cboSalesTeamFm.Text <> "" And Me.cboSalesTeamTo.Text <> "" Then
            If Me.cboSalesTeamFm.Text > Me.cboSalesTeamTo.Text Then
                MsgBox("Sales Team: To < From!")
            End If
        End If
        '------------------------------------


        If Mid(txtIssdatFm.Text, 7) > Mid(txtIssdatTo.Text, 7) Then
            MsgBox("Issue Date: End Date < Start date ! (YY)")
            txtIssdatFm.Focus()
            Exit Sub
        ElseIf Mid(txtIssdatFm.Text, 7) = Mid(txtIssdatTo.Text, 7) Then
            If Strings.Left(txtIssdatFm.Text, 2) > Strings.Left(txtIssdatTo.Text, 2) Then
                MsgBox("Issue Date: End Date < Start date ! (MM)")
                txtIssdatFm.Focus()
                Exit Sub
            ElseIf Strings.Left(txtIssdatFm.Text, 2) = Strings.Left(txtIssdatTo.Text, 2) Then
                If Mid(txtIssdatFm.Text, 4, 2) > Mid(txtIssdatTo.Text, 4, 2) Then
                    MsgBox("Issue Date: End Date < Start date ! (DD)")
                    txtIssdatFm.Focus()
                    Exit Sub
                End If
            End If
        End If




        If txtIssdatFm.Text <> "  /  /" Then
            If IsDate(txtIssdatFm.Text) = False Then
                MsgBox("Invalid Enter in Issue Date!")
                txtIssdatFm.Focus()
                Exit Sub
            End If
        End If

        If txtIssdatTo.Text <> "  /  /" Then
            If IsDate(txtIssdatTo.Text) = False Then
                MsgBox("Invalid Enter in Issue Date!")
                txtIssdatTo.Focus()
                Exit Sub
            End If
        End If


        ' Ship Date Validation -------------------------------
        '            If txtShipFm.Text > txtShipTo.Text Then
        '                MsgBox ("Ship Date: End Date < Start Date !")
        '                txtShipFm.SetFocus
        '                Exit Sub
        '            End If

        If Mid(txtShipFm.Text, 7) > Mid(txtShipTo.Text, 7) Then
            MsgBox("Ship Date: End Date < Start date ! (YY)")
            txtShipFm.Focus()
            Exit Sub

        ElseIf Mid(txtShipFm.Text, 7) = Mid(txtShipTo.Text, 7) Then
            If Strings.Left(txtShipFm.Text, 2) > Strings.Left(txtShipTo.Text, 2) Then
                MsgBox("Ship Date: End Date < Start date ! (MM)")
                txtShipFm.Focus()
                Exit Sub
            ElseIf Strings.Left(txtShipFm.Text, 2) = Strings.Left(txtShipTo.Text, 2) Then
                If Mid(txtShipFm.Text, 4, 2) > Mid(txtShipTo.Text, 4, 2) Then
                    MsgBox("Ship Date: End Date < Start date ! (DD)")
                    txtShipFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If txtShipFm.Text <> "  /  /" Then
            If IsDate(txtShipFm.Text) = False Then
                MsgBox("Invalid Enter in Ship Date!")
                txtShipFm.Focus()
                Exit Sub
            End If
        End If

        If txtShipTo.Text <> "  /  /" Then
            If IsDate(txtShipTo.Text) = False Then
                MsgBox("Invalid Enter in Ship Date!")
                txtShipTo.Focus()
                Exit Sub
            End If
        End If

        '===============================================================

        Dim CNF As String
        Dim cnt As String
        Dim VNF As String
        Dim VNT As String

        If cboCustNoFm.Text = "" Then
            CNF = ""
        Else
            CNF = Split(cboCustNoFm.Text, " - ")(0)
        End If

        If cboCustNoTo.Text = "" Then
            cnt = ""
        Else
            cnt = Split(cboCustNoTo.Text, " - ")(0)
        End If

        If cboVenNoFm.Text = "" Then
            VNF = ""
        Else
            VNF = Split(cboVenNoFm.Text, " - ")(0)
        End If

        If cboVenNoTo.Text = "" Then
            VNT = ""
        Else
            VNT = Split(cboVenNoTo.Text, " - ")(0)
        End If

        '2004/02/11 Lester Wu
        Dim secCNF As String
        Dim seccnt As String
        If cboCust2NoFm.Text = "" Then
            secCNF = ""
        Else
            secCNF = Split(cboCust2NoFm.Text, " - ")(0)
        End If

        If cboCust2NoTo.Text = "" Then
            seccnt = ""
        Else
            seccnt = Split(cboCust2NoTo.Text, " - ")(0)
        End If


        ' Set Issue Date & Ship Date to empty then there is "__/__/____"
        Dim IDF As String
        Dim IDT As String
        Dim SDF As String
        Dim SDT As String

        If txtIssdatFm.Text = "  /  /" Then
            'IDF = CDate("01/01/1900")
            IDF = ""

        Else
            IDF = txtIssdatFm.Text + " 00:00:00.000"
        End If

        If txtIssdatTo.Text = "  /  /" Then
            'IDT = CDate(Format(Date, "MM/DD/YYYY"))
            IDT = ""
        Else
            IDT = txtIssdatTo.Text + " 23:59:59.000"
        End If

        If txtShipFm.Text = "  /  /" Then
            'SDF = CDate("01/01/1900")
            SDF = ""
        Else
            SDF = txtShipFm.Text + " 00:00:00.000"
        End If

        If txtShipTo.Text = "  /  /" Then
            'SDT = CDate(Format(Date, "MM/DD/YYYY"))
            SDT = ""
        Else
            SDT = txtShipTo.Text + " 23:59:59.000"
        End If



        ' SubCode --------------------------------------------
        Dim subcdeFm As String
        Dim SubCdeTo As String

        If gsCompany = "UCP" Then
            If cboSubCdeFm.Text = "" Then
                subcdeFm = ""
            Else
                subcdeFm = Split(cboSubCdeFm.Text, " - ")(0)
            End If

            If cboSubCdeTo.Text = "" Then
                SubCdeTo = ""
            Else
                SubCdeTo = Split(cboSubCdeTo.Text, " - ")(0)
            End If

        Else
            subcdeFm = cboSubCdeFm.Text
            SubCdeTo = cboSubCdeTo.Text

        End If


        ' Print Unit Price or not----------------------------
        Dim UP As String
        If optYes.Checked = True Then
            UP = "Y"
        Else
            UP = "N"
        End If

        ' Sort by -------------------------------------------
        Dim SORTBY As String
        If cboSortBy.Text = "Customer PO#" Then
            SORTBY = "C"
        Else
            SORTBY = "S"
        End If



        '--------------------------------------------------------------------------------------------------------------



        '                S = "㊣MSR00001※S※" & cboPLFm & "※" & cboPLTo & _
        '                    "※" & subcdeFm & "※" & SubCdeTo & _
        '                    "※" & VNF & "※" & VNT & _
        '                    "※" & CNF & "※" & cnt & _
        '                    "※" & txtCPOFm.Text & "※" & txtCPOTo.Text & _
        '                    "※" & txtOrderFm & "※" & txtOrderTo & _
        '                    "※" & IDF & "※" & IDT & _
        '                    "※" & SDF & "※" & SDT & _
        '                    "※" & txtItemFm & "※" & txtItemTo & _
        '                    "※" & UP & "※" & SortBy
        '
        '' 2004/02/11 Lester Wu
        '                S = "㊣MSR00001※S※" & cboPLFm & "※" & cboPLTo & _
        '                    "※" & subcdeFm & "※" & SubCdeTo & _
        '                    "※" & VNF & "※" & VNT & _
        '                    "※" & CNF & "※" & cnt & _
        '                    "※" & secCNF & "※" & secCNT & _
        '                    "※" & txtCPOFm.Text & "※" & txtCPOTo.Text & _
        '                    "※" & txtOrderFm & "※" & txtOrderTo & _
        '                    "※" & IDF & "※" & IDT & _
        '                    "※" & SDF & "※" & SDT & _
        '                    "※" & txtItemFm & "※" & txtItemTo & _
        '                    "※" & UP & "※" & SortBy

        ' 2004/02/16 Lester Wu
        '                S = "㊣MSR00001※S※" & cboPLFm & "※" & cboPLTo & _
        '                    "※" & subcdeFm & "※" & SubCdeTo & _
        '                    "※" & Me.cboSalesTeamFm & "※" & Me.cboSalesTeamTo & _
        '                    "※" & VNF & "※" & VNT & _
        '                    "※" & CNF & "※" & cnt & _
        '                    "※" & secCNF & "※" & seccnt & _
        '                    "※" & txtCPOFm.Text & "※" & txtCPOTo.Text & _
        '                    "※" & txtOrderFm & "※" & txtOrderTo & _
        '                    "※" & IDF & "※" & IDT & _
        '                    "※" & SDF & "※" & SDT & _
        '                    "※" & txtItemFm & "※" & txtItemTo & _
        '                    "※" & UP & "※" & SortBy

        ' 2004/03/08 Lester Wu (ADD Access Right Control in store procedure - gsSaltem)
        ' 2004/03/16 Lester Wu (ADD Partial Cust PO selection - Me.txtP_PO.Text)
        '                S = "㊣MSR00001※S※" & cboPLFm & "※" & cboPLTo & _
        '                    "※" & subcdeFm & "※" & SubCdeTo & _
        '                    "※" & Me.cboSalesTeamFm & "※" & Me.cboSalesTeamTo & _
        '                    "※" & VNF & "※" & VNT & _
        '                    "※" & CNF & "※" & cnt & _
        '                    "※" & secCNF & "※" & seccnt & _
        '                    "※" & txtCPOFm.Text & "※" & txtCPOTo.Text & _
        '                    "※" & Me.txtP_PO.Text & _
        '                    "※" & txtOrderFm & "※" & txtOrderTo & _
        '                    "※" & IDF & "※" & IDT & _
        '                    "※" & SDF & "※" & SDT & _
        '                    "※" & txtItemFm & "※" & txtItemTo & _
        '                    "※" & UP & "※" & SORTBY & _
        '       "※" & "_" & gsSaltem
        ' 2004/03/16 Lester Wu (ADD Partial Cust PO selection - Me.txtP_PO.Text)
        'Frankie Cheung 20120316 Allow user with dual team rights to see report
        Dim cocde As String = cboCocde.Text

        gspStr = "sp_select_MSR00001_NET '" & cocde & "','" & _
        cboPLFm.Text & "','" & cboPLTo.Text & "','" & _
        subcdeFm & "','" & SubCdeTo & "','" & _
        cboSalesTeamFm.Text & "','" & cboSalesTeamTo.Text & "','" & _
        VNF & "','" & VNT & "','" & _
        CNF & "','" & cnt & "','" & _
        secCNF & "','" & seccnt & "','" & _
        txtCPOFm.Text & "','" & txtCPOTo.Text & "','" & _
        txtP_PO.Text & "','" & _
        txtOrderFm.Text & "','" & txtOrderTo.Text & "','" & _
        IDF & "','" & IDT & "','" & _
        SDF & "','" & SDT & "','" & _
        txtItemFm.Text & "','" & txtItemTo.Text & "','" & _
        UP & "','" & SORTBY & "','" & _
        gsUsrID & "','" & gsSalTem & "'"




        ''S = "㊣MSR00001※S※" & cboPLFm & "※" & cboPLTo & _
        ''    "※" & subcdeFm & "※" & SubCdeTo & _
        ''    "※" & Me.cboSalesTeamFm & "※" & Me.cboSalesTeamTo & _
        ''    "※" & VNF & "※" & VNT & _
        ''    "※" & CNF & "※" & cnt & _
        ''    "※" & secCNF & "※" & seccnt & _
        ''    "※" & txtCPOFm.Text & "※" & txtCPOTo.Text & _
        ''    "※" & Me.txtP_PO.Text & _
        ''    "※" & txtOrderFm & "※" & txtOrderTo & _
        ''    "※" & IDF & "※" & IDT & _
        ''    "※" & SDF & "※" & SDT & _
        ''    "※" & txtItemFm & "※" & txtItemTo & _
        ''    "※" & UP & "※" & SORTBY & _
        ''    "※" & gsUsrID & "※" & "_" & gsSalTem


        Me.Cursor = Cursors.WaitCursor
        'Relocation to report server
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        rtnLong = execute_SQLStatement(gspStr, rs_MSR00001, rtnStr)

        Me.Cursor = Cursors.Default

        '*** An error has occured
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_MSR00001:" & rtnStr)
            Exit Sub
        Else

            'Kenny Add on 18-10-2002
            '                    If SortBy = "C" Then
            '                        'rs_MSR00001.sort = "sod_cuspo,sod_ordno, sod_cusitm, pod_venitm, sod_itmno"
            '                        rs_MSR00001.sort = "sod_cuspo,sod_itmno,sod_shpstr"
            '                    Else
            '                        'rs_MSR00001.sort = "sod_shpstr,sod_ordno, sod_cusitm, pod_venitm, sod_itmno"
            '                        rs_MSR00001.sort = "sod_shpstr,sod_cuspo,sod_itmno"
            '                    End If
        End If


        If rs_MSR00001.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            MsgBox("No record found !")
            Exit Sub
        Else


            '---------------------------------------------------------

            'Set Sorting
            '                    If cboSortBy.Text = "Customer.PO#" Then
            '                        rs_MSR00001.sort = "sod_cuspo"
            '                    Else
            '                         rs_MSR00001.sort = "sod_shpstr"
            '
            '                    End If
            If OptExcelN.Checked = True Then
                Dim objRpt As New MSR00001Rpt
                objRpt.SetDataSource(rs_MSR00001.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            Else

                rs_EXCEL = rs_MSR00001
                Call CmdExportExcel_Click()
            End If
        End If


    End Sub



    Private Function CmdExportExcel_Click()

        On Error GoTo Err_Handler

        Me.Cursor = Cursors.WaitCursor  ' Change mouse pointer to hourglass.
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet

        Dim recArray As Object

        Dim fldCount As Long
        Dim recCount As Long
        Dim iCol As Integer
        Dim iRow As Integer

        'xxxxxxxxxxx
        Dim contRow As Long
        Dim HdrRow As Long
        Dim DtlRow As Long


        Dim HdrCol As Long
        Dim DtlCol As Long
        Dim i As Long
        Dim indexCol As Long
        Dim intGroup As Long
        Dim strGroup As String
        Dim tmpGroup As String
        Dim dblOS_Amt As Double
        Dim lngOS_Ctn As Long
        Dim strCurr As String
        Dim bolFtyPrice As Boolean
        'Dim bolPO As Boolean
        Dim strCompany As String
        Dim strTitle As String

        Dim dblOS_CBM As Double

        dblOS_CBM = 0
        strCurr = ""
        dblOS_Amt = 0
        lngOS_Ctn = 0
        intGroup = 0
        indexCol = 1
        HdrRow = 8
        DtlRow = 10
        'xxxxxxxxxxx


        'Create an instance of Excel and add a workbook
        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        'Display Excel and give user control of Excel's lifetime
        xlApp.Visible = True
        xlApp.UserControl = True





        bolFtyPrice = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(21) = "Y", True, False) '21col
        '==========================================================
        'xxxxxxxxxxxxxxxxxxxxx< Title Start >xxxxxxxxxxxxxxxxxxxxxx
        strCompany = ""
        strTitle = "Outstanding Order Report by Sales Confirmation"


        'Lester Wu 2005-03-21 Retrieve company information informaiton from database
        'Select Case rs_EXCEL.Fields(enuSC.cocde_enu)
        '    Case "UCP"
        '            strCompany = "UCP INTERNATIONAL CO., LTD."
        '    Case "UCPP"
        '            strCompany = "UNITED CHINESE PLASTICS PRODUCTS CO., LTD."
        '    Case "PG"
        '            strCompany = "Pacific Global Enterprises Limited"
        '    Case "ALL"
        '            strCompany = "UNITED CHINESE GROUP"
        'End Select

        strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item(51) '51col

        With xlWs
            '
            'Report ID
            .Cells(1, 14) = "Report ID"
            .Cells(1, 15) = ":"
            .Cells(1, 16) = "MSR00001"

            'Date
            .Cells(2, 14) = "Date"
            .Cells(2, 15) = ":"
            .Cells(2, 16) = Format(Now, "MM/dd/yyyy")
            .Range(.Cells(2, 16), .Cells(2, 16)).NumberFormatLocal = "mm/dd/yyyy"
            'Time
            .Cells(3, 14) = "Time"
            .Cells(3, 15) = ":"
            .Cells(3, 16) = Format(Now, "HH:mm:ss")
            .Range(.Cells(3, 16), .Cells(3, 16)).NumberFormatLocal = "HH:MM:SS"
            'Page
            .Cells(4, 14) = "Page"
            .Cells(4, 15) = ":"
            .Cells(4, 16) = "1 of 1"

            'Input Parameter
            'Customer
            .Cells(4, 1) = "Customer"
            .Cells(4, 2) = ":"
            .Cells(4, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt4Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt4To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt4Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt4To_enu))
            'subcode
            .Cells(5, 1) = "Customer PO No"
            .Cells(5, 2) = ":"
            .Cells(5, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt12Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt12To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt12Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt12To_enu))

            'PO NO
            .Cells(6, 1) = "Sales Order No"
            .Cells(6, 2) = ":"
            .Cells(6, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt5Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt5To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt5Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt5To_enu))

            'Product Line
            .Cells(7, 1) = "Product Line"
            .Cells(7, 2) = ":"
            .Cells(7, 3) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt1Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt1To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt1Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt1To_enu))

            'Sec. Customer
            .Cells(4, 5) = "Sec. Customer"
            .Cells(4, 6) = ":"
            .Cells(4, 7) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(seccnf_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(seccnt_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(seccnf_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(seccnt_enu))

            'Item#
            .Cells(5, 5) = "Item #"
            .Cells(5, 6) = ":"
            .Cells(5, 7) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt9Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt9To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt9Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt9To_enu))

            'Vendor No
            .Cells(6, 5) = "Vendor No"
            .Cells(6, 6) = ":"
            .Cells(6, 7) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt3Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt3To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt3Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt3To_enu))

            'Sub Code
            .Cells(7, 5) = "Sub Code"
            .Cells(7, 6) = ":"
            .Cells(7, 7) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt2Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt2To_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt2Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt2To_enu))

            'Sales Team
            .Cells(4, 9) = "Sales Team"
            .Cells(4, 10) = ":"
            .Cells(4, 11) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(STFm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(STTo_enu) = "", "ALL", rs_EXCEL.Tables("RESULT").Rows(0).Item(STFm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(STTo_enu))

            'Issue Date
            .Cells(5, 9) = "Issue Date"
            .Cells(5, 10) = ":"
            .Cells(5, 11) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt6Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt6To_enu) = "", "--/--/---- - --/--/----", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt6Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt6To_enu))

            'Ship Date Range
            .Cells(6, 9) = "Ship Date Range"
            .Cells(6, 10) = ":"
            .Cells(6, 11) = IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(opt7Fm_enu) = "" And rs_EXCEL.Tables("RESULT").Rows(0).Item(opt7To_enu) = "", "--/--/---- - --/--/----", rs_EXCEL.Tables("RESULT").Rows(0).Item(opt7Fm_enu) & " - " & rs_EXCEL.Tables("RESULT").Rows(0).Item(opt7To_enu))

            'Sort By
            .Cells(7, 9) = "Sort By"
            .Cells(7, 10) = ":"
            Select Case rs_EXCEL.Tables("RESULT").Rows(0).Item(opt11_enu)
                Case "C"
                    .Cells(7, 11) = "Customer PO #"
                Case Else
                    .Cells(7, 11) = "Ship Start Date"
            End Select



            'defalut aligment
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 17)).HorizontalAlignment = 2
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 17)).VerticalAlignment = 3
            .Range(.Cells(1, 1), .Cells(HdrRow - 1, 17)).Font.Size = 10

            'COmpany
            .Range(.Cells(1, 4), .Cells(1, 13)).Merge()
            .Range(.Cells(1, 4), .Cells(1, 13)).Value = strCompany
            .Range(.Cells(1, 4), .Cells(1, 13)).RowHeight = 25
            .Range(.Cells(1, 4), .Cells(1, 13)).Font.Size = 12
            .Range(.Cells(1, 4), .Cells(1, 13)).Font.Bold = True
            .Range(.Cells(1, 4), .Cells(1, 13)).HorizontalAlignment = 3
            'Report Title
            .Range(.Cells(2, 4), .Cells(2, 13)).Merge()
            .Range(.Cells(2, 4), .Cells(2, 13)).Value = strTitle
            .Range(.Cells(2, 4), .Cells(2, 13)).Font.Size = 10
            .Range(.Cells(2, 4), .Cells(2, 13)).HorizontalAlignment = 3

        End With
        'xxxxxxxxxxxxxxxxxxxxx< Title End >xxxxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        '==========================================================
        'xxxxxxxxxxxxxxxxxxxx< Row Header Start>xxxxxxxxxxxxxxxxxxxx
        With xlWs

            .Cells(HdrRow + 1, indexCol) = "S/C#"
            .Cells(HdrRow + 1, indexCol + 1) = "Cust. PO#"
            .Cells(HdrRow + 1, indexCol + 2) = "Resp. PO#"
            .Cells(HdrRow + 1, indexCol + 3) = "Vendor Item#"
            .Cells(HdrRow + 1, indexCol + 4) = "Item #"
            .Cells(HdrRow + 1, indexCol + 5) = "Cust. Item#"
            .Cells(HdrRow + 1, indexCol + 6) = "Description"
            'Lester Wu 2004/06/23
            '.Cells(HdrRow + 1, indexCol + 12) = "O/S Qty"
            '.Cells(HdrRow + 1, indexCol + 13) = ""
            '.Cells(HdrRow + 1, indexCol + 14) = "O/S Carton"
            .Cells(HdrRow + 1, indexCol + 7) = "O/S Qty"
            .Cells(HdrRow + 1, indexCol + 8) = "Unit of Measure"
            .Cells(HdrRow + 1, indexCol + 9) = "O/S Carton"
            .Cells(HdrRow + 1, indexCol + 10) = "O/S CBM"
            '-----------------------------------------------

            If bolFtyPrice = True Then
                '.Cells(HdrRow + 1, indexCol + 15) = ""
                .Cells(HdrRow + 1, indexCol + 15) = "Unit Price"
                .Cells(HdrRow + 1, indexCol + 16) = "Total Amount"
            End If
            'Frankie Cheung 20090821
            .Columns(ColumnLetter(indexCol + 11) & ":" & ColumnLetter(indexCol + 11)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            .Cells(HdrRow + 1, indexCol + 11) = "Ship Window"
            .Columns(ColumnLetter(indexCol + 11) & ":" & ColumnLetter(indexCol + 12)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            .Cells(HdrRow + 1, indexCol + 12) = "Cancel Date"
            .Cells(HdrRow + 1, indexCol + 13) = "Vendor"

            .Cells(HdrRow + 1, indexCol + 14) = "Currency"
            '--------------------

            'Lester Wu 2004/06/23
            '.Range(.Cells(HdrRow + 1, indexCol + 12), .Cells(HdrRow + 1, indexCol + 12)).HorizontalAlignment = 4    'O/S Qty
            '.Range(.Cells(HdrRow + 1, indexCol + 14), .Cells(HdrRow + 1, indexCol + 14)).HorizontalAlignment = 4    'O/S Carton
            .Range(.Cells(HdrRow + 1, indexCol + 7), .Cells(HdrRow + 1, indexCol + 7)).HorizontalAlignment = 4    'O/S Qty
            .Range(.Cells(HdrRow + 1, indexCol + 9), .Cells(HdrRow + 1, indexCol + 9)).HorizontalAlignment = 4    'O/S Carton
            .Range(.Cells(HdrRow + 1, indexCol + 10), .Cells(HdrRow + 1, indexCol + 10)).HorizontalAlignment = 4    'O/S CBM

            .Range(.Cells(HdrRow + 1, indexCol + 14), .Cells(HdrRow + 1, indexCol + 14)).HorizontalAlignment = 4    'Currency
            .Range(.Cells(HdrRow + 1, indexCol + 15), .Cells(HdrRow + 1, indexCol + 15)).HorizontalAlignment = 4    'Unit Price
            .Range(.Cells(HdrRow + 1, indexCol + 16), .Cells(HdrRow + 1, indexCol + 16)).HorizontalAlignment = 4    'Total Amount

            .Range(.Cells(HdrRow + 1, indexCol + 8), .Cells(HdrRow + 1, indexCol + 8)).HorizontalAlignment = 4    'unit of material
            '--------------------

            '---------------------
        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Header End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        'xxxxxxxxxxxxxxxxxxxx< Row Detail Start >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................
        recCount = rs_EXCEL.Tables("RESULT").Rows.Count - 1
        With xlWs

            strGroup = ""
            tmpGroup = ""
            For i = 0 To recCount
                '"Customer :  " + Trim ({MSR00001_ttx.cbi_cusno}) + "     " + Trim ({MSR00001_ttx.cbi_cussna})  +  " ( " + Trim({MSR00001_ttx.seccusno}) + "     " + Trim ({MSR00001_ttx.seccussna}) + " ) "
                tmpGroup = rs_EXCEL.Tables("RESULT").Rows(i).Item(cbi_cusno_enu) & "_" & rs_EXCEL.Tables("RESULT").Rows(i).Item(Seccustno_enu)
                If strGroup <> tmpGroup Then
                    'Show Total Field
                    '.............................................................................................
                    If strGroup <> "" Then
                        '.Cells(intGroup + DtlRow + i + 1, indexCol + 13) = "Total : "   '--Unit Code
                        .Cells(intGroup + DtlRow + i + 1, indexCol + 8) = "Total : "   '--Unit Code
                        If bolFtyPrice = True Then
                            .Cells(intGroup + DtlRow + i + 1, indexCol + 14) = strCurr 'IIf(bolFtyPrice, strCurr, "") 'Currency
                            .Cells(intGroup + DtlRow + i + 1, indexCol + 15) = dblOS_Amt 'IIf(bolFtyPrice, dblOS_Amt, "")  'Total O/S Amount
                        End If
                        '.Cells(intGroup + DtlRow + i + 1, indexCol + 14) = lngOS_Ctn     'Total O/S Ctn
                        .Cells(intGroup + DtlRow + i + 1, indexCol + 9) = lngOS_Ctn     'Total O/S Ctn
                        .Cells(intGroup + DtlRow + i + 1, indexCol + 10) = dblOS_CBM     'Total O/S Ctn
                        '.Range(.Cells(intGroup + DtlRow + i + 1, indexCol + 14), .Cells(intGroup + DtlRow + i + 1, indexCol + 14)).NumberFormatLocal = "#,##0.0000_ "
                        dblOS_CBM = 0
                        strCurr = ""
                        dblOS_Amt = 0
                        lngOS_Ctn = 0
                        intGroup = intGroup + 1
                    End If
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    strGroup = tmpGroup
                    .Cells(intGroup + DtlRow + i + 1, indexCol) = "Customer : " + rs_EXCEL.Tables("RESULT").Rows(i).Item(cbi_cusno_enu) & "    " & rs_EXCEL.Tables("RESULT").Rows(i).Item(cbi_cussna_enu) & _
                                                            IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(Seccustno_enu) = "", "", " (" & rs_EXCEL.Tables("RESULT").Rows(i).Item(Seccustno_enu) & "    " & rs_EXCEL.Tables("RESULT").Rows(i).Item(secCustName_enu) & ")")
                    .Range(.Cells(intGroup + DtlRow + i + 1, indexCol), .Cells(intGroup + DtlRow + i + 1, indexCol)).Font.Bold = True
                    intGroup = intGroup + 2
                End If
                .Cells(intGroup + DtlRow + i, indexCol) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_ordno_enu) 'S/C#
                .Cells(intGroup + DtlRow + i, indexCol + 1) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_cuspo_enu) 'Cust. PO#
                .Cells(intGroup + DtlRow + i, indexCol + 5) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_cusitm_enu) 'Cust. Item#
                .Cells(intGroup + DtlRow + i, indexCol + 3) = rs_EXCEL.Tables("RESULT").Rows(i).Item(pod_venitm_enu) 'Vendor Item#
                .Cells(intGroup + DtlRow + i, indexCol + 4) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_itmno_enu) 'Item #
                '.Range(.Cells(DtlRow + i, indexCol + 9), .Cells(DtlRow + i, indexCol + 11)).Merge
                '.Range(.Cells(DtlRow + i, indexCol + 9), .Cells(DtlRow + i, indexCol + 11)) = Left(rs_excel.Fields(enuSC.sod_itmdsc_enu), 20) 'Description
                .Cells(intGroup + DtlRow + i, indexCol + 6) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_itmdsc_enu) 'Description
                'Lester Wu 2004/06/23
                '.Cells(intGroup + DtlRow + i, indexCol + 12) = rs_excel.Fields(enuSC.outstandQty_enu) 'O/S Qty
                '.Cells(intGroup + DtlRow + i, indexCol + 13) = rs_excel.Fields(enuSC.ysi_dsc_enu) 'unit code
                '.Cells(intGroup + DtlRow + i, indexCol + 14) = rs_excel.Fields(enuSC.outstandCtn_enu) 'O/S Carton

                .Cells(intGroup + DtlRow + i, indexCol + 7) = rs_EXCEL.Tables("RESULT").Rows(i).Item(outstandQty_enu) 'O/S Qty
                .Cells(intGroup + DtlRow + i, indexCol + 8) = rs_EXCEL.Tables("RESULT").Rows(i).Item(ysi_dsc_enu) 'unit code
                .Cells(intGroup + DtlRow + i, indexCol + 9) = rs_EXCEL.Tables("RESULT").Rows(i).Item(outstandCtn_enu) 'O/S Carton
                .Cells(intGroup + DtlRow + i, indexCol + 10) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_balcbm) 'O/S CBM
                .Cells(intGroup + DtlRow + i, indexCol + 2) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_resppo_enu) 'Resp. PO#

                If bolFtyPrice = True Then
                    .Cells(intGroup + DtlRow + i, indexCol + 14) = rs_EXCEL.Tables("RESULT").Rows(i).Item(soh_curcde_enu)   'Currency
                    .Cells(intGroup + DtlRow + i, indexCol + 15) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_untprcStr_enu) 'Unit Price
                    .Cells(intGroup + DtlRow + i, indexCol + 16) = rs_EXCEL.Tables("RESULT").Rows(i).Item(outstandAmt_enu) 'Total Amount
                End If
                '.Cells(intGroup + DtlRow + i, indexCol + 18) = rs_EXCEL.Fields(enuSC.sod_shpstr_enu)
                'Frankie Cheung 20090821 - add ship end date to become ship window
                If rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_shpstr_enu) <> rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_shpend_enu) Then
                    .Cells(intGroup + DtlRow + i, indexCol + 11) = CDate(rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_shpstr_enu)) & " - " & CDate(rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_shpend_enu))   'Ship Start Date
                Else
                    .Cells(intGroup + DtlRow + i, indexCol + 11) = "'" & CStr(CDate(rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_shpstr_enu)))
                End If
                'Frankie Cheung 20090821 - Add cancel date
                '.Cells(intGroup + DtlRow + i, indexCol + 19) = IIf(Trim(rs_EXCEL.Fields(enuSC.sod_candat_enu)) = "01/01/1900", "", CDate(rs_EXCEL.Fields(enuSC.sod_candat_enu)))
                .Cells(intGroup + DtlRow + i, indexCol + 12) = rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_candat_enu)
                .Cells(intGroup + DtlRow + i, indexCol + 13) = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(cocde_enu) = "UCP" And rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_venno_enu) = "0005", rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_subcde_enu), rs_EXCEL.Tables("RESULT").Rows(i).Item(vbi_vensna_enu)) 'Vendor / Sub Code
                ''Group Total Field
                ''-------------------------------------------------------------
                strCurr = rs_EXCEL.Tables("RESULT").Rows(i).Item(soh_curcde_enu)
                dblOS_Amt = dblOS_Amt + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i).Item(outstandAmt_enu)), 0, rs_EXCEL.Tables("RESULT").Rows(i).Item(outstandAmt_enu))
                lngOS_Ctn = lngOS_Ctn + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i).Item(outstandCtn_enu)), 0, rs_EXCEL.Tables("RESULT").Rows(i).Item(outstandCtn_enu))
                dblOS_CBM = dblOS_CBM + IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_balcbm)), 0, rs_EXCEL.Tables("RESULT").Rows(i).Item(sod_balcbm))
                ''xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            Next

            'Show Total Field
            '.............................................................................................
            If strGroup <> "" Then
                '.Cells(intGroup + DtlRow + i + 1, indexCol + 13) = "Total : "   '--Unit Code
                .Cells(intGroup + DtlRow + i + 1, indexCol + 8) = "Total : "   '--Unit Code
                If bolFtyPrice = True Then
                    .Cells(intGroup + DtlRow + i + 1, indexCol + 14) = strCurr 'Currency
                    .Cells(intGroup + DtlRow + i + 1, indexCol + 16) = dblOS_Amt 'IIf(bolFtyPrice, dblOS_Amt, "")  'Total O/S Amount
                End If
                '.Cells(intGroup + DtlRow + i + 1, indexCol + 14) = lngOS_Ctn     'Total O/S Ctn
                .Cells(intGroup + DtlRow + i + 1, indexCol + 9) = lngOS_Ctn     'Total O/S Ctn
                .Cells(intGroup + DtlRow + i + 1, indexCol + 10) = dblOS_CBM     'Total O/S Ctn
                '.Range(.Cells(intGroup + DtlRow + i + 1, indexCol + 14), .Cells(intGroup + DtlRow + i + 1, indexCol + 14)).NumberFormatLocal = "#,##0.0000_ "
                dblOS_CBM = 0
                strCurr = ""
                dblOS_Amt = 0
                lngOS_Ctn = 0
                intGroup = intGroup + 1
            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            .Range(.Cells(DtlRow, indexCol + 14), .Cells(intGroup + DtlRow + recCount, indexCol + 10)).NumberFormatLocal = "0.0000_ " 'O/S CBM

            'Frankie Cheung 20080824
            '.Range(.Cells(DtlRow, indexCol + 18), .Cells(intGroup + DtlRow + recCount, indexCol + 18)).NumberFormatLocal = "mm/dd/yyyy" 'Ship Start Date
            '
            .Range(.Cells(DtlRow, indexCol + 17), .Cells(intGroup + DtlRow + recCount, indexCol + 16)).NumberFormatLocal = "0.00_ " 'Total Amount


            '.Range(.Cells(DtlRow, indexCol + 12), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 12)).HorizontalAlignment = 4 'O/S Qty
            '.Range(.Cells(DtlRow, indexCol + 14), .Cells(intGroup + DtlRow + recount + 1, indexCol + 14)).HorizontalAlignment = 4 'O/S Carton
            .Range(.Cells(DtlRow, indexCol + 7), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 7)).HorizontalAlignment = 4 'O/S Qty
            .Range(.Cells(DtlRow, indexCol + 9), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 9)).HorizontalAlignment = 4 'O/S Carton
            .Range(.Cells(DtlRow, indexCol + 10), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 10)).HorizontalAlignment = 4 'O/S CBM


            .Range(.Cells(DtlRow, indexCol + 14), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 14)).HorizontalAlignment = 4 'Currency
            .Range(.Cells(DtlRow, indexCol + 15), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 15)).HorizontalAlignment = 4 'Unit Price
            .Range(.Cells(DtlRow, indexCol + 16), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 16)).HorizontalAlignment = 4 'Total Amount


            .Range(.Cells(DtlRow, indexCol + 14), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 14)).HorizontalAlignment = 4 'Currency
            .Range(.Cells(DtlRow, indexCol + 15), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 15)).HorizontalAlignment = 4 'Unit Price
            .Range(.Cells(DtlRow, indexCol + 16), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 16)).HorizontalAlignment = 4 'Total Amount

            .Range(.Cells(DtlRow, indexCol + 15), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 15)).NumberFormatLocal = "#,##0.0000_ " 'Unit Price
            .Range(.Cells(DtlRow, indexCol + 16), .Cells(intGroup + DtlRow + recCount + 1, indexCol + 16)).NumberFormatLocal = "#,##0.00_ " 'Total Amount


        End With
        'xxxxxxxxxxxxxxxxxxxx< Row Detail End >xxxxxxxxxxxxxxxxxxxxxx
        '..........................................................


        'xxxxxxxxxxxxxxxxxxxx< Detail Style Start>xxxxxxxxxxxxxxxxxxxxxx
        '============================================================
        With xlWs

            .Columns.ColumnWidth = 10
            '    'Column Header
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 1, indexCol + 16)).Font.Bold = True
            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 1, indexCol + 16)).Font.Size = 9

            .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 1, indexCol + 16)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            'Row Detail
            '.Cells(intGroup + DtlRow + 2 * recCount + 4, indexCol).Value = "Recod Number: " & (recCount + 1)
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 2, indexCol + 16)).Font.Size = 8
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 4, indexCol + 16)).Font.Size = 8
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 4, indexCol + 16)).RowHeight = 15

            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 2, indexCol + 16)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft '"xlLeft"
            .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 4, indexCol + 16)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
        End With

        'xxxxxxxxxxxxxxxxxxxx< Detail Style End >xxxxxxxxxxxxxxxxxxxxxx
        '............................................................

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'all the information is in the same HorizontalAlignment
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim a As Integer

        'recCount = rs_EXCEL.recordCount - 1
        'With xlWs
        'For a = 1 To 25
        '    .Range(.Cells(HdrRow + 1, indexCol), .Cells(HdrRow + 1, indexCol + 16)).HorizontalAlignment = xlLeft
        'Next a
        '    .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount + 4, indexCol + 16)).HorizontalAlignment = xlLeft
        ' For i = 0 To recCount
        '    For a = 1 To 17
        '   .Cells(intGroup + DtlRow + i, indexCol + a).HorizontalAlignment = xlLeft
        ' Next a
        'Next i
        'End With
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        Dim lngPages As Long

        'Max FitToPagesTall of Excel = 9999
        lngPages = recCount / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If
        'Set print options
        With xlWs.PageSetup
            .Zoom = False
            .TopMargin = 10
            .FitToPagesWide = 1
            .FitToPagesTall = lngPages
            .Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape 'xlLandscape
        End With
        xlApp.Selection.CurrentRegion.Columns.AutoFit()
        xlWs.Columns("S").AutoFit()
        xlWs.Columns("T").AutoFit()





        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


        'With Screen
        '    Me.Move (.Width - Width) \ 2, (.Height - Height) \ 2
        'End With

        Me.Cursor = Cursors.Default ' Return mouse pointer to normal.

        Exit Function

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Me.Cursor = Cursors.Default ' Return mouse pointer to normal.

        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing


        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Function

    Function ColumnLetter(ByVal ColumnNumber As Integer) As String
        If ColumnNumber > 26 Then

            ' 1st character:  Subtract 1 to map the characters to 0-25,
            '                 but you don't have to remap back to 1-26
            '                 after the 'Int' operation since columns
            '                 1-26 have no prefix letter

            ' 2nd character:  Subtract 1 to map the characters to 0-25,
            '                 but then must remap back to 1-26 after
            '                 the 'Mod' operation by adding 1 back in
            '                 (included in the '65')

            ColumnLetter = Chr(Int((ColumnNumber - 1) / 26) + 64) & _
                           Chr(((ColumnNumber - 1) Mod 26) + 65)
        Else
            ' Columns A-Z
            ColumnLetter = Chr(ColumnNumber + 64)
        End If
    End Function

    Private Sub cboCocde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCocde.KeyUp
        auto_search_combo(cboCocde)
    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text = "UC-G" Then
            txtCoNam.Text = "UNITED CHINESE GROUP"
            Exit Sub
        End If

        txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
    End Sub

    Private Sub cboCustNoFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoFm.KeyUp
        auto_search_combo(cboCustNoFm)
    End Sub

    Private Sub cboCustNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SelectedIndexChanged

    End Sub

    Private Sub cboCustNoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoTo.KeyUp
        auto_search_combo(cboCustNoTo)
    End Sub

    Private Sub cboCustNoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustNoTo.SelectedIndexChanged

    End Sub

    Private Sub cboCust2NoFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCust2NoFm.KeyUp
        auto_search_combo(cboCust2NoFm)
    End Sub

    Private Sub cboCust2NoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCust2NoFm.SelectedIndexChanged

    End Sub

    Private Sub cboCust2NoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCust2NoTo.KeyUp
        auto_search_combo(cboCust2NoTo)
    End Sub

    Private Sub cboCust2NoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCust2NoTo.SelectedIndexChanged

    End Sub

    Private Sub cboPLFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPLFm.KeyUp
        auto_search_combo(cboPLFm)
    End Sub

    Private Sub cboPLFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPLFm.SelectedIndexChanged

    End Sub

    Private Sub cboPLTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPLTo.KeyUp
        auto_search_combo(cboPLTo)
    End Sub

    Private Sub cboPLTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPLTo.SelectedIndexChanged

    End Sub

    Private Sub cboVenNoFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoFm.KeyUp
        auto_search_combo(cboVenNoFm)
    End Sub

    Private Sub cboVenNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenNoFm.SelectedIndexChanged

    End Sub

    Private Sub cboVenNoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoTo.KeyUp
        auto_search_combo(cboVenNoTo)
    End Sub

    Private Sub cboVenNoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenNoTo.SelectedIndexChanged

    End Sub

    Private Sub cboSubCdeFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubCdeFm.KeyUp
        auto_search_combo(cboSubCdeFm)
    End Sub

    Private Sub cboSubCdeFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCdeFm.SelectedIndexChanged

    End Sub

    Private Sub cboSubCdeTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubCdeTo.KeyUp
        auto_search_combo(cboSubCdeTo)
    End Sub

    Private Sub cboSubCdeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCdeTo.SelectedIndexChanged

    End Sub

    Private Sub cboSalesTeamFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSalesTeamFm.KeyUp
        auto_search_combo(cboSalesTeamFm)
    End Sub

    Private Sub cboSalesTeamFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesTeamFm.SelectedIndexChanged

    End Sub

    Private Sub cboSalesTeamTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSalesTeamTo.KeyUp
        auto_search_combo(cboSalesTeamTo)
    End Sub

    Private Sub cboSalesTeamTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesTeamTo.SelectedIndexChanged

    End Sub
End Class