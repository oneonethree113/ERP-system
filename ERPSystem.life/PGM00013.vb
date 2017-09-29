Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Public Class PGM00013
    Dim Del_right_local As Boolean
    Dim Enq_right_local As Boolean
    Dim rs_pkg00004 As DataSet

    Dim rs_PGM00013_dtl As DataSet
    Dim rs_PGM00013_hdr As DataSet

    Dim rs_EXCEL_dtl As ADODB.Recordset
    Dim rs_EXCEL_hdr As ADODB.Recordset



    Private Sub PGM00013_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '        txtSCIssdatFm.Text = sFirstMonth & "/" & sSecondDay & "/" & sSecondYear
        '        txtSCIssdatTo.Text = sSecondMonth & "/" & sSecondDay & "/" & sSecondYear
        Dim dateNow = DateTime.Now

        txtSCIssdatFm.Text = "01/01/" & Year(dateNow)
        txtSCIssdatTo.Text = "12/31/" & Year(dateNow)


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
        '        Dim ordno As String
        Dim itmno As String
        '        Dim PV As String
        '        Dim PackItmno As String
        Dim SClist As String
        Dim Tolist As String
        Dim issdatFm As String
        Dim issdatTo As String

        Dim scpkgcst As String
        Dim pkgestcst As String
        Dim pcknetpo As String

        Dim txtype As String

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

        'If txt_S_PKGNo.Text.Length > 1000 Then
        '    MsgBox("Order No List is too long (1000 Char)")
        '    txt_S_PKGNo.Focus()
        '    txt_S_PKGNo.SelectAll()
        '    Exit Sub
        'Else
        '    ordno = Microsoft.VisualBasic.Replace(Trim(txt_S_PKGNo.Text), "'", "''")
        'End If

        If txt_S_ItmNo.Text.Length > 1000 Then
            MsgBox("Item No List is too long (1000 Char)")
            txt_S_ItmNo.Focus()
            txt_S_ItmNo.SelectAll()
            Exit Sub
        Else
            itmno = Microsoft.VisualBasic.Replace(Trim(txt_S_ItmNo.Text), "'", "''")
        End If


        'If txt_S_PV_PC.Text.Length > 1000 Then
        '    MsgBox("PV List is too long (1000 Char)")
        '    txt_S_PV_PC.Focus()
        '    txt_S_PV_PC.SelectAll()
        '    Exit Sub
        'Else
        '    PV = Microsoft.VisualBasic.Replace(Trim(txt_S_PV_PC.Text), "'", "''")
        'End If


        'If txt_S_PkItmNo.Text.Length > 1000 Then
        '    MsgBox("Packaging Item List is too long (1000 Char)")
        '    txt_S_PkItmNo.Focus()
        '    txt_S_PkItmNo.SelectAll()
        '    Exit Sub
        'Else
        '    PackItmno = Microsoft.VisualBasic.Replace(Trim(txt_S_PkItmNo.Text), "'", "''")
        'End If

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


        If cbscpkgcst.Checked = True Then
            scpkgcst = "Y"
        Else
            scpkgcst = "N"
        End If

        If cbpkgestcst.Checked = True Then
            pkgestcst = "Y"
        Else
            pkgestcst = "N"
        End If

        If cbpcknetpo.Checked = True Then
            pcknetpo = "Y"
        Else
            pcknetpo = "N"
        End If


        If rbSCTO_SC.Checked = True Then
            txtype = "SC"
        ElseIf rbSCTO_TO.Checked = True Then
            txtype = "TO"
        Else
            txtype = "ALL"
        End If



        gspStr = "sp_list_PackagingReport '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                SClist & "','" & Tolist & "','" & itmno & "','" & issdatFm & "','" & issdatTo & "','" & scpkgcst & "','" & pkgestcst & "','" & pcknetpo & "','" & txtype & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_PGM00013_dtl, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading PGM00006 #001 sp_select_PGM00006_HDR : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_PackagingReport_hdr '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                SClist & "','" & Tolist & "','" & itmno & "','" & issdatFm & "','" & issdatTo & "','" & scpkgcst & "','" & pkgestcst & "','" & pcknetpo & "','" & txtype & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_PGM00013_hdr, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading PGM00006 #001 sp_select_PGM00006_HDR : " & rtnStr)
            Exit Sub
        End If

        ''''''''''''''''''

        gspStr = "sp_list_PackagingReport '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                SClist & "','" & Tolist & "','" & itmno & "','" & issdatFm & "','" & issdatTo & "','" & scpkgcst & "','" & pkgestcst & "','" & pcknetpo & "','" & txtype & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement_ADO(gspStr, rs_EXCEL_dtl, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00005 #001 sp_list_DYR00005 : " & rtnStr)
        Else
        End If

        ''''''''''''''''''

        gspStr = "sp_list_PackagingReport_hdr '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                SClist & "','" & Tolist & "','" & itmno & "','" & issdatFm & "','" & issdatTo & "','" & scpkgcst & "','" & pkgestcst & "','" & pcknetpo & "','" & txtype & "','" & gsUsrID & "'"


        rtnLong = execute_SQLStatement_ADO(gspStr, rs_EXCEL_hdr, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00005 #001 sp_list_DYR00005 : " & rtnStr)
        Else
        End If



        '''''''''''''''''''
        If rs_PGM00013_dtl.Tables("RESULT").Rows.Count <> 0 Then
            Call exportExcel_ExportToExcel()
        Else
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Detail No Record Found")
            Exit Sub
        End If

        If rs_PGM00013_hdr Is Nothing Then
            Exit Sub
        End If
        If rs_PGM00013_hdr.Tables("RESULT").Rows.Count <> 0 Then
            '           Call exportExcel_ExportToExcel_hdr()
        Else
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Summary No Record Found")
            Exit Sub
        End If



        Me.Cursor = Cursors.Default


        ''''''''''''''


        Me.Cursor = Cursors.Default



    End Sub




    Private Sub exportExcel_ExportToExcel()

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

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tmp_PGM00013_dtl As DataTable


        tmp_PGM00013_dtl = rs_PGM00013_dtl.Tables("RESULT").DefaultView.ToTable

        PBar.Maximum = rs_PGM00013_dtl.Tables("RESULT").DefaultView.Count + rs_PGM00013_hdr.Tables("RESULT").DefaultView.Count
        PBar.Value = 0

        'If PBar.Maximum > 3000 Then
        '    MsgBox("Record Count Over 3000, please input again.")
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If

        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application



        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = True
        xlsApp.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        ' xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

        ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
        'xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\PKGTemplate\PGR00001_2.xlsx")
        xlsWB = xlsApp.Workbooks.Add

        With xlsWB
            With .Styles("Normal")
                .Font.Name = "新細明體"
                .Font.Size = "12"
            End With
        End With

        xlsApp.Sheets(2).Activate()
        xlsWS = xlsWB.ActiveSheet
        xlsWS.Name = "Detail"

        xlsApp.ActiveWindow.Zoom = 70


        Try


            Dim seq As Integer = -1
            With xlsApp


                '''''''''                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = ""  'AA1

                ' ''For i As Integer = 0 To tmp_PGM00013_dtl.Rows.Count - 1
                ' ''    PBar.Value = PBar.Value + 1
                ' ''    For j As Integer = 0 To tmp_PGM00013_dtl.Columns.Count - 1
                ' ''        If 65 + j <= 90 Then
                ' ''            .Range(Chr(65 + j).ToString + (i + 2).ToString).Value = tmp_PGM00013_dtl.Rows(i)(j)
                ' ''        Else
                ' ''            .Range("A" + Chr(65 - 26 + j).ToString + (i + 2).ToString).Value = tmp_PGM00013_dtl.Rows(i)(j)
                ' ''        End If
                ' ''    Next
                ' ''Next


                xlsApp.Cells(2, 1).copyfromrecordset(rs_EXCEL_dtl)



                Dim l As Integer
                l = 0
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC/TO" 'A1
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC/To No."
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Sc Seq"
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Primary Customer"
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Secondary Customer"  'E
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "UCP Item No." 'F
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Item Type" 'G
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC Season" 'H
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "UM" 'I
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Factor" 'J
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Inner" 'K
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Master" 'L
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC Order Qty" 'M
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "USD" 'N
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC Unt Prc" 'O

                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC Pkg Cst" 'O
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC Pkg Cst Ttl" 'P
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Est Curr" 'Q
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Est Cst" 'R
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Est Cst Total" 'S
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Pkg Req" 'T
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Pkg Req seq" 'U
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Pkg Item" 'V
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Req Qty" 'w
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Req Wastage" 'X
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Req Curr" 'Y
                l = l + 1
                ''                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Req Unt Price" 'Z
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Req Unt Price" 'Z

                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Pkg Order" 'AA
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Order Type" 'AB
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Printer" 'AC
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Curr" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Additional Charge" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Discount" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Premium" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Seq" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Pkg Item" 'AI
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Pkg Season"
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Pkg UM" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Pkg Order Qty" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Pkg Wastage" 'AM
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Pkg Order Qty Ttl" 'AN
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Divide Wastage" 'AO
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Pkg Unit Price" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO MOA" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO MOA unit Price" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Ttl Amt" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Wastage Amt" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Divide Wastage Amt" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Divide Discount Amt" 'A1
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "PO Divide Premium Amt" 'A1




            End With

            xlsApp.Range("A1:CA" + tmp_PGM00013_dtl.Rows.Count.ToString).Columns.AutoFit()
            xlsApp.Range("A1:CA" + tmp_PGM00013_dtl.Rows.Count.ToString).Rows.AutoFit()


        


            ' Configuring XLS Style
            With xlsApp
                '.Rows("1:1").Font.Bold = True
                '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
                '.Rows("1:200").Font.Name = "Arial"
                '.Rows("1:200").Format.Align = 2

                With xlsApp.Rows("1:1").Borders(9)
                    .LineStyle = 1
                    .Weight = 2
                End With
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

            ''''''''''''''''''
            Dim tmp_PGM00013_hdr As DataTable


            tmp_PGM00013_hdr = rs_PGM00013_hdr.Tables("RESULT").DefaultView.ToTable

            '  PBar.Maximum = rs_PGM00013_hdr.Tables("RESULT").DefaultView.Count
            ' PBar.Value = 0

            'If PBar.Maximum > 3000 Then
            '    MsgBox("Record Count Over 3000, please input again.")
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim xlsApp As New Excel.ApplicationClass
            'Dim xlsWB As Excel.Workbook = Nothing
            'Dim xlsWS As Excel.Worksheet = Nothing
            'Dim Message As String
            'Dim tmp_cat As String

            'If rs_TOExcel.Tables("RESULT").Rows.Count >= 100 Then
            '    MsgBox("There are more than 100 records!")
            '    Exit Sub
            'End If

            hdrRow = 1
            type = ""

            Cursor = Cursors.WaitCursor

            'xlsApp = New Excel.Application
            ''Set the excel invisible to prevent user interrupt the process of creating the excel
            'xlsApp.Visible = False
            'xlsApp.UserControl = False

            '            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            '' xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

            ' ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
            ''xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\PKGTemplate\PGR00001_2.xlsx")
            'xlsWB = xlsApp.Workbooks.Add


            xlsApp.Sheets(1).Activate()
            xlsWS = xlsWB.ActiveSheet
            xlsWS.Name = "Summary"
            xlsApp.ActiveWindow.Zoom = 70

            'Columns("A").ColumnWidth = 25

            'Try

            seq = -1
            With xlsApp

                ' ''For i As Integer = 0 To tmp_PGM00013_hdr.Rows.Count - 1
                ' ''    PBar.Value = PBar.Value + 1
                ' ''    For j As Integer = 0 To tmp_PGM00013_hdr.Columns.Count - 1
                ' ''        If 65 + j <= 90 Then
                ' ''            .Range(Chr(65 + j).ToString + (i + 2).ToString).Value = tmp_PGM00013_hdr.Rows(i)(j)
                ' ''        Else
                ' ''            .Range("A" + Chr(65 - 26 + j).ToString + (i + 2).ToString).Value = tmp_PGM00013_hdr.Rows(i)(j)
                ' ''        End If
                ' ''    Next
                ' ''Next


                xlsApp.Cells(2, 1).copyfromrecordset(rs_EXCEL_hdr)

                Dim l As Integer
                l = 0
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Line No." 'A 
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC/To No." 'A 
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Sc" + vbLf + "Seq"
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Primary Customer"
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Sec." + vbLf + "Custo" + vbLf + " mer" 'D
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "UCP Item No." 'E
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Item" + vbLf + "Type" 'F
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC Season" 'G
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC" + vbLf + "Order" + vbLf + "qty" 'H
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "UM" 'I
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Fac" + vbLf + "tor" 'J
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Inn" + vbLf + "er" 'K
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Mast" + vbLf + "er" 'L
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC" + vbLf + "Curr" 'M
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "(1) SC" + vbLf + "Pkg Cst" 'N
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Est." + vbLf + "Curr" 'O
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Est. Cst" 'P
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Pkg" + vbLf + "Curr" 'Q
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Box/Tray" + vbLf + "/PDQ" + vbLf + "Order" + vbLf + "(A)" 'R
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Label/Stick" + vbLf + "er/Handtag" + vbLf + "Order (B)" 'S
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "(2) Cal.Ttl" + vbLf + "Cst (A+B)" 'T
                l = l + 1
                'U
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Re-" + vbLf + "print" + vbLf + "Order" + vbLf + "'(C)" 'V
                l = l + 1
                'W
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Box/Tray" + vbLf + "/PDQ" + vbLf + "Order" + vbLf + "Wastage" + vbLf + "(A1)" 'X
                l = l + 1
                .Range(Chr(65 + l).ToString + (1).ToString).Value = "Label/Stick" + vbLf + "er/Handtag " + vbLf + "Order" + vbLf + "Wastage" + vbLf + "(B1)" 'Y
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Re-print" + vbLf + "Order" + vbLf + "Wastage" + vbLf + "(C1)" 'Z
                l = l + 1
                'AA
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "(3) Total" + vbLf + "Actual" + vbLf + " (A+B+C+A" + vbLf + "1+B1+C1)" 'AB
                l = l + 1
                'AC
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Box/Tray" + vbLf + "/PDQ " + vbLf + "Order" + vbLf + "Wastage" + vbLf + "% (A1/A)" 'AD

                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Label/Stick" + vbLf + "er/Handtag" + vbLf + "Order" + vbLf + "Wastage" + vbLf + "% (B1/B)" 'AE
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Re-print" + vbLf + "Order" + vbLf + "Wastage" + vbLf + "% (C1/C)" 'AF
                l = l + 1
                'AG
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Excess" + vbLf + "included" + vbLf + "Pkg Cost" + vbLf + "per order" + vbLf + "(1-2)" 'AH
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Excess" + vbLf + "included" + vbLf + "Pkg Cost" + vbLf + "per" + vbLf + "actual (1-" + vbLf + "3)" 'AI
                l = l + 1
                'AJ
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Excess" + vbLf + "included" + vbLf + "Pkg Cost" + vbLf + "per" + vbLf + "actual %" + vbLf + "(1-3)/1"
                l = l + 1
                'AL
                l = l + 1
                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = "Total" + vbLf + "Actual" + vbLf + "Used" + vbLf + " (A+B+C+A1" + vbLf + "+B1+C1) " + vbLf + "* sc qty "
                .Columns("A" + Chr(65 - 26 + l).ToString).NumberFormatLocal = "#,##0.00"
            End With

            xlsApp.Range("A1:CA1").Columns.AutoFit()
            xlsApp.Range("A1:CA1").Rows.AutoFit()

            xlsApp.Range("A1:CA" + tmp_PGM00013_hdr.Rows.Count.ToString).Columns.AutoFit()
            xlsApp.Range("A1:CA" + tmp_PGM00013_hdr.Rows.Count.ToString).Rows.AutoFit()


            ' Configuring XLS Style
            With xlsApp.Rows("1:1").Borders(9)
                .LineStyle = 1
                .Weight = 2

            End With
            xlsApp.Rows("1:1").VerticalAlignment = -4160

            xlsApp.Columns("E").columnwidth = 8.89
            xlsApp.Columns("U").columnwidth = 10.22
            xlsApp.Columns("AA").columnwidth = 8.22
            xlsApp.Columns("Y").columnwidth = 10.22
            xlsApp.Columns("S").columnwidth = 10.44
            xlsApp.Columns("T").columnwidth = 12.22
            xlsApp.Columns("Z").columnwidth = 13
            xlsApp.Columns("AC").columnwidth = 11.2
            xlsApp.Columns("AN").columnwidth = 12
            xlsApp.Columns("AM").columnwidth = 3
            xlsApp.Columns("AK").columnwidth = 3
            xlsApp.Columns("AH").columnwidth = 3
            xlsApp.Columns("AD").columnwidth = 3
            xlsApp.Columns("AB").columnwidth = 3
            xlsApp.Columns("X").columnwidth = 3
            xlsApp.Columns("V").columnwidth = 3
            xlsApp.Rows("1:1").RowHeight = 102


            'With Worksheets("Sheet1").Range("B2").Borders(xlEdgeBottom)
            '    .LineStyle = xlContinuous
            '    .Weight = xlThin
            '    .ColorIndex = 3
            'End With

            For i As Integer = 0 To rs_PGM00013_hdr.Tables("RESULT").DefaultView.Count - 1

                xlsWS.Range("A" + (i + 2).ToString).Value = (i + 1).ToString
            Next




        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_ExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_PGR00001 - Excel Error")
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
            '            xlsWB.Application.DisplayAlerts = False
            xlsWB.SaveAs(Filename:="C:\ERP_Excel\" + "PGM00013_Excel", FileFormat:=52)




        Catch ex As Exception
            MsgBox("File " + "C:\ERP_Excel\" + "PGR00001_Excel" + ".xls already exist. Please delete it before export a new one.")
        End Try


        xlsApp.Visible = True
        ' xlsWB.SaveAs(Filename:="C:\" + "PGR00001_2", ReadOnlyRecommended:=False, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)



        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        rs_PGM00013_dtl = Nothing
        tmp_PGM00013_dtl = Nothing
        rs_PGM00013_hdr = Nothing
        'tmp_PGM00013_hdr = Nothing

        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
        PBar.Value = 0
        MsgBox("Generate Excel Complete.")
    End Sub
    'Private Sub exportExcel_ExportToExcel_hdr()
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim tmp_PGM00013_hdr As DataTable


    '    tmp_PGM00013_hdr = rs_PGM00013_hdr.Tables("RESULT").DefaultView.ToTable

    '    '  PBar.Maximum = rs_PGM00013_hdr.Tables("RESULT").DefaultView.Count
    '    PBar.Value = 0

    '    'If PBar.Maximum > 3000 Then
    '    '    MsgBox("Record Count Over 3000, please input again.")
    '    '    Cursor = Cursors.Default
    '    '    Exit Sub
    '    'End If

    '    'Dim xlsApp As New Excel.ApplicationClass
    '    'Dim xlsWB As Excel.Workbook = Nothing
    '    'Dim xlsWS As Excel.Worksheet = Nothing
    '    'Dim Message As String
    '    'Dim tmp_cat As String

    '    'If rs_TOExcel.Tables("RESULT").Rows.Count >= 100 Then
    '    '    MsgBox("There are more than 100 records!")
    '    '    Exit Sub
    '    'End If

    '    Dim hdrRow As Integer = 1
    '    Dim type As String = ""

    '    Cursor = Cursors.WaitCursor

    '    'xlsApp = New Excel.Application


    '    ''Set the excel invisible to prevent user interrupt the process of creating the excel
    '    'xlsApp.Visible = False
    '    'xlsApp.UserControl = False


    '    Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
    '    'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

    '    '' xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

    '    ' ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
    '    ''xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\PKGTemplate\PGR00001_2.xlsx")
    '    'xlsWB = xlsApp.Workbooks.Add


    '    xlsApp.Sheets(1).Activate()
    '    xlsWS = xlsWB.ActiveSheet
    '    xlsWS.Name = "Summary"

    '    'Columns("A").ColumnWidth = 25

    '    Dim entry(60) As Object

    '    Try


    '        'Copy  Data
    '        'With xlsApp
    '        '    For i As Integer = 0 To rs_PGM00013_hdr.Tables("RESULT").DefaultView.Count - 1
    '        '        .Range("A5:AA5").Copy()

    '        '        .Range("A" + (i + 5).ToString).Select()
    '        '        xlsWS.Paste()


    '        '    Next

    '        '    .Range("A88:A88").Copy()

    '        'End With

    '        'Clear Data
    '        With xlsApp

    '        End With


    '        Dim seq As Integer = -1
    '        With xlsApp


    '            '''''''''                .Range("A" + Chr(65 - 26 + l).ToString + (1).ToString).Value = ""  'AA1

    '            For i As Integer = 0 To tmp_PGM00013_hdr.Rows.Count - 1
    '                PBar.Value = PBar.Value + 1
    '                For j As Integer = 0 To tmp_PGM00013_hdr.Columns.Count - 1
    '                    If 65 + j <= 90 Then
    '                        .Range(Chr(65 + j).ToString + (i + 2).ToString).Value = tmp_PGM00013_hdr.Rows(i)(j)
    '                    Else
    '                        .Range("A" + Chr(65 - 26 + j).ToString + (i + 2).ToString).Value = tmp_PGM00013_hdr.Rows(i)(j)
    '                    End If
    '                Next
    '            Next

    '            Dim l As Integer
    '            l = 0
    '            .Range(Chr(65 + l).ToString + (1).ToString).Value = "SC/To No." 'A1
    '            l = l + 1
    '            .Range(Chr(65 + l).ToString + (1).ToString).Value = "Sc Seq"
    '            l = l + 1
    '            .Range(Chr(65 + l).ToString + (1).ToString).Value = "Primary Customer"

    '        End With

    '        xlsApp.Range("A1:CA" + tmp_PGM00013_hdr.Rows.Count.ToString).Columns.AutoFit()
    '        xlsApp.Range("A1:CA" + tmp_PGM00013_hdr.Rows.Count.ToString).Rows.AutoFit()


    '        ' Configuring XLS Style
    '        With xlsApp
    '            '.Rows("1:1").Font.Bold = True
    '            '.Rows("1:1").Interior.Color = RGB(200, 160, 35)
    '            '.Rows("1:200").Font.Name = "Arial"
    '            '.Rows("1:200").Format.Align = 2

    '            .Rows("1:1").Font.Underline = True
    '            '.Rows("1:1").Font.Size = 10

    '            '.Columns("A:AY").WrapText = False
    '            '.Columns("A:AY").EntireColumn.AutoFit()

    '            ''.Columns("V:V").
    '            ''.Range("F2").Formula = "=SUM(D2;E2)"
    '            'For index As Integer = 1 To entry.Length
    '            'If .Columns(index).ColumnWidth > 50 Then
    '            '.Columns(index).ColumnWidth = 50
    '            'End If
    '            'Next

    '        End With

    '    Catch ex As Exception
    '        If ex.Message = "Exception from HRESULT: 0x800AC472" Then
    '            If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
    '                xlsWS = Nothing
    '                xlsWB = Nothing
    '                xlsApp = Nothing
    '                exportExcel_ExportToExcel()
    '            End If
    '        Else
    '            MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_PGR00001 - Excel Error")
    '        End If
    '    End Try




    '    'Show the excel after creating process is completed
    '    Try
    '        Dim Yourpath As String
    '        Yourpath = "C:\ERP_Excel"
    '        If (Not System.IO.Directory.Exists(Yourpath)) Then
    '            System.IO.Directory.CreateDirectory(Yourpath)
    '        End If


    '        '    xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
    '        xlsWB.Application.DisplayAlerts = False
    '        xlsWB.SaveAs(Filename:="C:\ERP_Excel\" + "PGR00001_Excel", FileFormat:=52)




    '    Catch ex As Exception
    '        MsgBox("File " + "C:\ERP_Excel\" + "PGR00001_Excel" + ".xls already exist. Please delete it before export a new one.")
    '    End Try



    '    'xlsWB.SaveAs(Filename:="C:\" + "PGR00001_2", ReadOnlyRecommended:=False, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)

    '    xlsApp.Visible = True

    '    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    '    ' Release reference
    '    rs_PGM00013_hdr = Nothing
    '    tmp_PGM00013_hdr = Nothing
    '    xlsWS = Nothing
    '    xlsWB = Nothing
    '    xlsApp = Nothing

    '    Cursor = Cursors.Default
    '    PBar.Value = 0
    '    MsgBox("Generate Excel Complete.")
    'End Sub


    'Private Sub ExportToExcel(ByVal rs_EXCEL As ADODB.Recordset)
    '    Dim xlsApp As New Excel.ApplicationClass
    '    Dim xlsWB As Excel.Workbook = Nothing
    '    Dim xlsWS As Excel.Worksheet = Nothing
    '    Dim iRow As Integer
    '    Dim iCol As Integer
    '    Dim strCocde As String = String.Empty

    '    If rs_EXCEL.RecordCount >= 65535 Then
    '        MsgBox("There are more than 65535 records!")
    '        Exit Sub
    '    End If


    '    Me.Cursor = Cursors.WaitCursor

    '    xlsApp = New Excel.Application
    '    xlsApp.Visible = True
    '    xlsApp.UserControl = True

    '    Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
    '    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

    '    xlsWB = xlsApp.Workbooks.Add()
    '    xlsWS = xlsWB.ActiveSheet

    '    Dim i As Integer
    '    For i = 0 To rs_EXCEL.Fields.Count - 1
    '        xlsApp.Cells(1, i + 1) = rs_EXCEL.Fields(i).Name
    '    Next
    '    xlsWS.Rows(1).Font.Bold = True


    '    xlsApp.Cells(2, 1).copyfromrecordset(rs_EXCEL)

    '    xlsApp.Selection.CurrentRegion.Columns.AutoFit()
    '    xlsApp.Selection.CurrentRegion.rows.AutoFit()

    '    'For i = 0 To rs_EXCEL.Fields.Count - 1
    '    '    If xlsApp.Columns(i + 1).Width > 100 Then
    '    '        'xlsWS.Columns(i + 1).Width = 100.0
    '    '    End If
    '    'Next
    'End Sub


    Private Sub txtSCIssdatFm_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtSCIssdatFm.MaskInputRejected

    End Sub

    Private Sub txtSCIssdatFm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSCIssdatFm.TextChanged
        txtSCIssdatTo.Text = txtSCIssdatFm.Text


    End Sub
End Class