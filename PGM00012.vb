Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Public Class PGM00012
    Dim Del_right_local As Boolean
    Dim Enq_right_local As Boolean
    Dim rs_pkg00004 As DataSet




    Private Sub PGM00012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right




        ' setStatus("INIT")


        Dim rs_load As DataSet
        Dim strCocde As String = ""

        gspStr = "sp_select_SYMUSRCO '" & gsCompany & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_load = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_load, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading #001 sp_select_SYMUSRCO : " & rtnStr)
            Exit Sub
        Else
            If rs_load.Tables("RESULT").Rows.Count > 0 Then
                For i As Integer = 0 To rs_load.Tables("RESULT").Rows.Count - 1
                    If rs_load.Tables("RESULT").Rows(i)("yuc_cocde") <> "MS" Then
                        strCocde = strCocde & IIf(strCocde.Length > 0, ",", "") & rs_load.Tables("RESULT").Rows(i)("yuc_cocde")
                        If gsCompany = "" Then
                            gsCompany = rs_load.Tables("RESULT").Rows(i)("yuc_cocde")
                        End If
                    ElseIf gsDefaultCompany = "MS" Then
                        strCocde = "MS"
                    End If
                Next
            End If
        End If

        If gsDefaultCompany = "MS" Then
            txt_S_CoCde.Text = "MS"
            gsCompany = "MS"
        Else
            txt_S_CoCde.Text = strCocde
        End If



        Dim sFirstYear As String
        Dim sSecondYear As String
        Dim sSecondMonth As String
        Dim sSecondDay As String
        Dim sFirstMonth As String

       
        sFirstYear = (Today.Year().ToString)
        sFirstYear = sFirstYear - 1
        sSecondYear = sFirstYear + 1

        sSecondMonth = (Today.Month().ToString)
        If sSecondMonth.Length = 1 Then
            sSecondMonth = "0" & sSecondMonth
        End If

        sFirstMonth = Convert.ToInt32(sSecondMonth) - 1

        If sFirstMonth.Length = 1 Then
            sFirstMonth = "0" & sFirstMonth
        End If

        If Convert.ToInt32(sFirstMonth) = 0 Then
            sFirstMonth = sSecondMonth
        End If

        sSecondDay = (Today.Day().ToString)
        If sSecondDay.Length = 1 Then
            sSecondDay = "0" & sSecondDay
        End If
        '        txt_S_SCIssdatFm.Text = Format(Today.Date, "MM/dd/yyyy")
        txtSCIssdatFm.Text = sFirstMonth & "/" & sSecondDay & "/" & sSecondYear
        txtSCIssdatTo.Text = sSecondMonth & "/" & sSecondDay & "/" & sSecondYear

        PBar.Value = 0

    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_frmS(Me.cmd_S_CoCde)
    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmcomsearch As New frmComSearch

        frmcomsearch.callFmForm = Me.Name
        frmcomsearch.callFmCriteria = txt_S_SecCustAll.Name
        frmcomsearch.callFmString = txt_S_SecCustAll.Text

        frmcomsearch.show_frmS(Me.cmd_S_SecCust)
    End Sub

    Private Sub cmd_S_PKGNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PKGNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PKGNo.Name
        frmComSearch.callFmString = txt_S_PKGNo.Text

        frmComSearch.show_frmS(Me.cmd_S_PKGNo)
    End Sub

    Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PV_PC.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PV_PC.Name
        frmComSearch.callFmString = txt_S_PV_PC.Text

        frmComSearch.show_frmS(Me.cmd_S_PV_PC)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmd_S_SC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        frmComSearch.show_frmS(Me.cmd_S_SCNo)
    End Sub

    Private Sub cmd_S_TONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_TONo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_TONo.Name
        frmComSearch.callFmString = txt_S_TONo.Text

        frmComSearch.show_frmS(Me.cmd_S_TONo)
    End Sub

    Private Sub cmd_S_PkItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PkItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PkItmNo.Name
        frmComSearch.callFmString = txt_S_PkItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_PkItmNo)
    End Sub




    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim cocde As String
        Dim cus1no As String
        Dim cus2no As String
        Dim ordno As String
        Dim itmno As String
        Dim PV As String
        Dim PackItmno As String
        Dim SClist As String
        Dim Tolist As String
        Dim issdatFm As String
        Dim issdatTo As String

        'If gsUsrRank > 4 And gsUsrGrp <> "MGT-S" Then
        '    MsgBox("You do not have the rights to use this feature.", MsgBoxStyle.Critical, "SCM00006 - Access Rights")
        '    Exit Sub
        'End If

        If txt_S_CoCde.Text = "" Then
            MsgBox("Company Code List cannot be empty")
            txt_S_CoCde.Focus()
            Exit Sub
        Else
            If txt_S_CoCde.Text.Length > 1000 Then
                MsgBox("Company Code List is too long (1000 Char)")
                txt_S_CoCde.Focus()
                txt_S_CoCde.SelectAll()
                Exit Sub
            Else
                cocde = Microsoft.VisualBasic.Replace(Trim(txt_S_CoCde.Text), "'", "''")

            End If
        End If

        If txt_S_PriCustAll.Text.Length > 1000 Then
            MsgBox("Primary Customer List is too long (1000 Char)")
            txt_S_PriCustAll.Focus()
            txt_S_PriCustAll.SelectAll()
            Exit Sub
        Else
            cus1no = Microsoft.VisualBasic.Replace(Trim(txt_S_PriCustAll.Text), "'", "''")
        End If

        If txt_S_SecCustAll.Text.Length > 1000 Then
            MsgBox("Secondary Customer List is too long (1000 Char)")
            txt_S_SecCustAll.Focus()
            txt_S_SecCustAll.SelectAll()
            Exit Sub
        Else
            cus2no = Microsoft.VisualBasic.Replace(Trim(txt_S_SecCustAll.Text), "'", "''")
        End If

        If txt_S_PKGNo.Text.Length > 1000 Then
            MsgBox("Order No List is too long (1000 Char)")
            txt_S_PKGNo.Focus()
            txt_S_PKGNo.SelectAll()
            Exit Sub
        Else
            ordno = Microsoft.VisualBasic.Replace(Trim(txt_S_PKGNo.Text), "'", "''")
        End If

        If txt_S_ItmNo.Text.Length > 1000 Then
            MsgBox("Item No List is too long (1000 Char)")
            txt_S_ItmNo.Focus()
            txt_S_ItmNo.SelectAll()
            Exit Sub
        Else
            itmno = Microsoft.VisualBasic.Replace(Trim(txt_S_ItmNo.Text), "'", "''")
        End If


        If txt_S_PV_PC.Text.Length > 1000 Then
            MsgBox("PV List is too long (1000 Char)")
            txt_S_PV_PC.Focus()
            txt_S_PV_PC.SelectAll()
            Exit Sub
        Else
            PV = Microsoft.VisualBasic.Replace(Trim(txt_S_PV_PC.Text), "'", "''")
        End If


        If txt_S_PkItmNo.Text.Length > 1000 Then
            MsgBox("Packaging Item List is too long (1000 Char)")
            txt_S_PkItmNo.Focus()
            txt_S_PkItmNo.SelectAll()
            Exit Sub
        Else
            PackItmno = Microsoft.VisualBasic.Replace(Trim(txt_S_PkItmNo.Text), "'", "''")
        End If

        If txt_S_SCNo.Text.Length > 1000 Then
            MsgBox("SC List is too long (1000 Char)")
            txt_S_SCNo.Focus()
            txt_S_SCNo.SelectAll()
            Exit Sub
        Else
            SClist = Microsoft.VisualBasic.Replace(Trim(txt_S_SCNo.Text), "'", "''")
        End If


        If txt_S_TONo.Text.Length > 1000 Then
            MsgBox("TO List is too long (1000 Char)")
            txt_S_TONo.Focus()
            txt_S_TONo.SelectAll()
            Exit Sub
        Else
            Tolist = Microsoft.VisualBasic.Replace(Trim(txt_S_TONo.Text), "'", "''")
        End If

        If txtSCIssdatFm.Text = "  /  /" Then
            MsgBox("Issue Date (From) cannot be empty")
            txtSCIssdatFm.Focus()
            txtSCIssdatFm.SelectAll()
            Exit Sub
        Else
            If txtSCIssdatFm.Text.Length <> 10 Or IsDate(txtSCIssdatFm.Text) = False Then
                MsgBox("Invalid Issue Date (From)")
                txtSCIssdatFm.Focus()
                txtSCIssdatFm.SelectAll()
                Exit Sub
            End If
        End If

        If txtSCIssdatTo.Text = "  /  /" Then
            MsgBox("Issue Date (To) cannot be empty")
            txtSCIssdatTo.Focus()
            txtSCIssdatTo.SelectAll()
            Exit Sub
        Else
            If txtSCIssdatTo.Text.Length <> 10 Or IsDate(txtSCIssdatTo.Text) = False Then
                MsgBox("Invalid Issue Date (To)")
                txtSCIssdatTo.Focus()
                txtSCIssdatTo.SelectAll()
                Exit Sub
            End If
        End If





        If CDate(txtSCIssdatFm.Text) > CDate(txtSCIssdatTo.Text) Then
            MsgBox("Issue Date (From) > Issue End Date (To)")
            txtSCIssdatFm.Focus()
            txtSCIssdatFm.SelectAll()
            Exit Sub
        End If



        issdatFm = txtSCIssdatFm.Text
        issdatTo = txtSCIssdatTo.Text



        gspStr = "sp_select_PKA00004 '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                ordno & "','" & PackItmno & "','" & PV & "','" & SClist & "','" & Tolist & "','" & issdatFm & "','" & issdatTo & "','" & itmno & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_pkg00004, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading PGM00006 #001 sp_select_PGM00006_HDR : " & rtnStr)
            Exit Sub
        End If

        If rs_pkg00004.Tables("RESULT").Rows.Count <> 0 Then
            Call exportExcel_ExportToExcel()
        Else
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No Record Found")
            Exit Sub
        End If

    End Sub




    Private Sub exportExcel_ExportToExcel()

        Dim filter As String
        Dim tmp_pkg00004 As DataTable

        If Trim(txt_S_SCNo.Text) <> "" And Trim(txt_S_TONo.Text) = "" Then

            filter = "rpttype = " & "'SC'"
            rs_pkg00004.Tables("RESULT").DefaultView.RowFilter = filter

        ElseIf Trim(txt_S_TONo.Text) <> "" And Trim(txt_S_SCNo.Text) = "" Then

            filter = "rpttype = " & "'TO'"
            rs_pkg00004.Tables("RESULT").DefaultView.RowFilter = filter

        Else
            'filter = "rpttype = " & "'TO' and rpttype = 'SC'"
            filter = "rpttype in ('TO','SC')"
            rs_pkg00004.Tables("RESULT").DefaultView.RowFilter = filter
        End If

        tmp_pkg00004 = rs_pkg00004.Tables("RESULT").DefaultView.ToTable

        PBar.Maximum = rs_pkg00004.Tables("RESULT").DefaultView.Count
        PBar.Value = 0

        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        'If rs_TOExcel.Tables("RESULT").Rows.Count >= 100 Then
        '    MsgBox("There are more than 100 records!")
        '    Exit Sub
        'End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application



        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        ' xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

        ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\PKGTemplate\PGM00012_2.xlsx")


        xlsWS = xlsWB.ActiveSheet


        Dim entry(60) As Object

        Try


            ''Copy  Data
            'With xlsApp
            '    For i As Integer = 0 To rs_pkg00004.Tables("RESULT").DefaultView.Count - 2
            '        .Range("A3:BD3").Copy()

            '        .Range("A" + (i + 3).ToString).Select()
            '        xlsWS.Paste()


            '    Next

            '    .Range("A88:A88").Copy()

            'End With

            'Clear Data
            With xlsApp
                .Range("A3:BE9999").Clear()


                'Add color 
                Dim C_P As Integer = .Range("P2").Interior.ColorIndex
                .Range("P3:P9999").Interior.ColorIndex = C_P
                Dim C_R As Integer = .Range("R2").Interior.ColorIndex
                .Range("R3:R9999").Interior.ColorIndex = C_R
                Dim C_AO As Integer = .Range("AO2").Interior.ColorIndex
                .Range("AO3:AO9999").Interior.ColorIndex = C_AO
                Dim C_AQ As Integer = .Range("AQ2").Interior.ColorIndex
                .Range("AQ3:AQ9999").Interior.ColorIndex = C_AQ
                Dim C_AR As Integer = .Range("AR2").Interior.ColorIndex
                .Range("AR3:AR9999").Interior.ColorIndex = C_AR
                Dim C_AU As Integer = .Range("AU2").Interior.ColorIndex
                .Range("AU3:AU9999").Interior.ColorIndex = C_AU
                Dim C_AV As Integer = .Range("AV2").Interior.ColorIndex
                .Range("AV3:AV9999").Interior.ColorIndex = C_AV
                Dim C_BB As Integer = .Range("BB2").Interior.ColorIndex
                .Range("BB3:BB9999").Interior.ColorIndex = C_BB
                Dim C_BD As Integer = .Range("BD2").Interior.ColorIndex
                .Range("BD3:BD9999").Interior.ColorIndex = C_BD
                Dim C_BE As Integer = .Range("BE2").Interior.ColorIndex
                .Range("BE3:BE9999").Interior.ColorIndex = C_BE

            End With


            Dim seq As Integer = -1
            With xlsApp

                For i As Integer = 0 To tmp_pkg00004.Rows.Count - 1

                    PBar.Value = PBar.Value + 1
                    '.Range("A" + (i + 3).ToString).Value = rs_pkg00004.Tables("RESULT").DefaultView.item(i).Item("sod_ordno")
                    .Range("A" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_ordno")


                    .Range("B" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("soh_cus1na")

                    .Range("C" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("soh_cus2na")




                    .Range("D" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_itmno")
                    .Range("E" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_assitm")
                    .Range("F" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_itmsku")
                    .Range("G" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_cusitm")
                    .Range("H" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_colcde")

                    .Range("I" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_itmdsc")
                    .Range("J" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_pckunt")

                    'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView.item(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView.item(i)("qud_expdat"))
                    'test_DateTime = DateTime.Parse(test_str)

                    .Range("K" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_conftr")

                    '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                    .Range("L" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_inrqty")

                    .Range("M" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_mtrqty")

                    .Range("N" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_ordqty")


                    .Range("O" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("sod_curcde")

                    'If temp_flag_is_ass = 1 Then
                    '    .Range("O" + (i + 3).ToString).Value = "PC"
                    'Else
                    '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView.item(i)("qpe_untcde")
                    'End If

                    .Range("P" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("ttlpkgcost?")
                    .Range("R" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("estcost?")
                    .Range("Q" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("estcur")

                    .Range("S" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_ordno")

                    'If temp_flag_is_ass = 1 Then
                    '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView.item(i)("qud_cft") / temp_qud_conftr
                    'Else
                    '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView.item(i)("qud_cft")
                    'End If



                    .Range("T" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_status")


                    '.Range("S" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").DefaultView.item(i)("tod_period")
                    '
                    '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView.item(i)("qpe_curcde")
                    .Range("U" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("PCO")

                    'Dim temp_cur As String
                    'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView.item(i)("qud_fcurcde").ToString.Trim


                    .Range("V" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("ysi_dsc")
                    .Range("W" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_seq")
                    .Range("X" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_pkgitm")
                    .Range("Y" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_engdsc")
                    .Range("Z" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pib_remark")
                    .Range("AA" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_EInchL")



                    .Range("AB" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_EInchW")
                    .Range("AC" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_EInchH")
                    .Range("AD" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_EcmL")
                    .Range("AE" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_EcmW")
                    .Range("AF" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_EcmH")
                    .Range("AG" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_matral")
                    .Range("AH" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_tiknes")
                    .Range("AI" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_prtmtd")
                    .Range("AJ" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_clrfot")
                    .Range("AK" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_finish")
                    .Range("AL" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("WT THE moacur")
                    .Range("AM" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("WT THE MOA")
                    .Range("AN" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("MOQ")



                    ' .Range("AL" + (i + 3).ToString).Value = "1.18"
                    '.Range("AM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView.Item("qpe_ftyprc")
                    .Range("AO" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_ordqty")

                    .Range("AP" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_wasqty")

                    .Range("AQ" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_bonqty")
                    '''TRAN TERM
                    .Range("AR" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_ttlordqty")

                    .Range("AS" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("UM")
                    .Range("AT" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_curcde")
                    .Range("AU" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_untprc")
                    .Range("AV" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("poh_TtlDelamt")
                    .Range("AW" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("poh_dremark")
                    .Range("AX" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pod_Conmak")
                    .Range("AY" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("HdrVen")
                    .Range("AZ" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("DtlVen")
                    .Range("BA" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("prd_reqno")
                    .Range("BB" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("prd_ordqty")
                    .Range("BC" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("was")
                    .Range("BD" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("bon")
                    .Range("BE" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("prd_ttlordqty")
                    .Range("BF" + (i + 3).ToString).Value = tmp_pkg00004.Rows(i).Item("pro_repord")


                Next







            End With


            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                '.Rows("1:1").Font.Underline = True
                '.Rows("1:1").Font.Size = 10

                '.Columns("A:AY").WrapText = False
                '.Columns("A:AY").EntireColumn.AutoFit()

                ''.Columns("V:V").
                ''.Range("F2").Formula = "=SUM(D2;E2)"
                'For index As Integer = 1 To entry.Length
                'If .Columns(index).ColumnWidth > 50 Then
                '.Columns(index).ColumnWidth = 50
                'End If
                'Next

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_ExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_PGM00012 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Yourpath = "C:\ERP_Excel"
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If


            '    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
            xlsWB.Application.DisplayAlerts = False
            xlsWB.SaveAs(Filename:="C:\ERP_Excel\" + "PGM00012_Excel", FileFormat:=52)
            



        Catch ex As Exception
            MsgBox("File " + "C:\ERP_Excel\" + "PGM00012_Excel" + ".xls already exist. Please delete it before export a new one.")
        End Try



        'xlsWB.SaveAs(Filename:="C:\" + "PGM00012_2", ReadOnlyRecommended:=False, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)

        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        rs_pkg00004 = Nothing
        tmp_pkg00004 = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
        PBar.Value = 0
        MsgBox("Generate Excel Complete.")
    End Sub



End Class