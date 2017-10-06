Imports CrystalDecisions.Shared

Public Class SCR00001

    Public rs_SCR00001 As New DataSet
    Public rs_SCR00001_shipment As New DataSet
    Public rs_SCR00001_matbkd As New DataSet
    Public rs_SCR00001_carton As New DataSet
    Public rs_SCR00001_disprm As New DataSet
    Public rs_SCR00001_assortment As New DataSet
    Public rs_check As New DataSet

    Const strModule As String = "SC"

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim strDir As String
    Dim psFile As String
    Dim strBatPath As String
    Dim strPrinterName As String
    Public init_SCNo As String = ""
    Public init_cocde As String = ""

    Private Sub SCR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        optFacY.Enabled = False
        optFacN.Checked = True

        cboReportFormat.Items.Add("Sales Confirmation Standard Format")
        cboReportFormat.Items.Add("Sales Confirmation PDF Format")
        cboReportFormat.Items.Add("Sales Confirmation Standard Format (with Photo)")
        cboReportFormat.SelectedIndex = 0

        If init_cocde <> "" Then
            cboCoCde.Text = init_cocde
            cboCoCde.Enabled = False
        End If
        If init_SCNo <> "" Then
            txtFromSCNo.Text = init_SCNo
            txtFromSCNo.ReadOnly = True
            txtToSCNo.Text = init_SCNo
            txtToSCNo.ReadOnly = True
        End If


        psFile = "" 'App.path & "\Tmp_SC.ps"
        strBatPath = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName & "\Tmp_SC.bat"
        strDir = "C:\SC PDF"
        strPrinterName = "ERP PDF Printer"
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
        '------------------------------------------

        If cboReportFormat.SelectedIndex = -1 Then
            MsgBox("Please Select Report Format !")
            Exit Sub
        End If


        'Dim hPrinter As Long
        'Dim pd As PRINTER_DEFAULTS

        'On Error Resume Next

        'If cboReportFormat.SelectedIndex = 1 Then
        '    With pd
        '        .pDevMode = 0&
        '        .pDatatype = "RAW"
        '        .DesiredAccess = PRINTER_ALL_ACCESS
        '    End With

        '    If OpenPrinter(strPrinterName, hPrinter, pd) = 0 Then
        '        ' Add Printer Method
        '        If InstallPrinter(strPrinterName, "Apple LaserWriter II NTX v47.0", "FILE:", "", "This is temporary printer for ERP. This can be deleted.") = False Then
        '            MsgBox("Cannot find " & strPrinterName & " !")
        '            Exit Sub
        '        End If
        '    End If


        '    If hPrinter = 0 And mlngPrinter = 0 Then
        '        MsgBox(strPrinterName & " Not Found !")
        '        Exit Sub
        '    End If



        '    If strDir = "" Then
        '        strDir = GetDirectory("Please select a directory to save the SC")
        '        'Exit Sub
        '    End If

        'End If


        Dim printPDF As String
        If cboReportFormat.SelectedIndex = 0 Then
            printPDF = "N"
        ElseIf cboReportFormat.SelectedIndex = 1 Then
            printPDF = "Y"
        End If
        'printPDF = "N"

        '-- * Check have any entry
        If txtFromSCNo.Text = "" Or txtToSCNo.Text = "" Then
            MsgBox("Sales Confirmation empty !")
            Exit Sub
        End If

        '-- * Past parameter to store port (Heading)
        Dim heading As String
        If optCO.Checked = True Then
            heading = "CO"
        Else
            heading = "PI"
        End If

        '-- * Past parameter to store port (Factory Info)
        Dim fty As String
        If optFacY.Checked = True Then
            fty = "YES"
        Else
            fty = "NO"
        End If

        '-- * Past parameter to store port (Ship Date Format)
        Dim shipFormat As String
        If optApprox.Checked = True Then
            shipFormat = "APPROX"
        Else
            shipFormat = "EXACT"
        End If

        '-- * Past parameter to store port (Unit Measure)
        Dim um As String
        If optOrg.Checked = True Then
            um = "ORG"
        Else
            um = "CON"
        End If

        '-- * Past parameter to store port (Suppress ZERO Qty)
        Dim Sup0 As String
        If optSupY.Checked = True Then
            Sup0 = "Y"
        Else
            Sup0 = "N"
        End If

        '-- * Past parameter to Revised Option
        Dim Rvs As String
        If optRvsY.Checked = True Then
            Rvs = "Y"
        Else
            Rvs = "N"
        End If

        Dim HTSU As String
        If optHSTUY.Checked = True Then
            HTSU = "Y"
        Else
            HTSU = "N"
        End If

        Dim CV As String
        If optCVY.Checked = True Then
            CV = "Y"
        Else
            CV = "N"
        End If

        '-- * Past parameter to store port (Suppress ZERO Qty)
        Dim CRmk As String
        If optChnY.Checked = True Then
            CRmk = "Y"
        Else
            CRmk = "N"
        End If

        '-- * Past parameter to store port (Sort By)
        Dim SORTBY As String
        If optCust.Checked = True Then
            SORTBY = "CUST"
        Else
            SORTBY = "ITEM"
        End If


        Dim pritype As String
        If optPTy.Checked = True Then
            pritype = "Net First Cost"
        Else
            pritype = "Unit Price"
        End If
        '----------------------------------------------------------

        Dim PrintCusals As String
        'If optPrintCusalsY.Value = True Then
        '    PrintCusals = "1"
        'Else
        '    PrintCusals = "0"
        'End If
        PrintCusals = "1"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If cboReportFormat.SelectedIndex = 0 Or cboReportFormat.SelectedIndex = 2 Then
            If PrintCusals = "1" Then
                gspStr = "sp_select_SCR00001_ca '" & cboCoCde.Text & "','" & heading & "','" & fty & "','" & shipFormat & _
                         "','" & Sup0 & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "','" & SORTBY & "','" & um & _
                         "','" & CRmk & "','" & Rvs & "','" & HTSU & "','" & CV & "','" & PrintCusals & "','" & printPDF & _
                         "','" & gsUsrID & "','" & strModule & "','" & pritype & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SCR00001, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading SCR00001 #001 sp_select_SCR00001_ca : " & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_select_SCR00001_shipment '" & cboCoCde.Text & "','" & shipFormat & "','" & _
                         txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_shipment, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading SCR00001 #002 sp_select_SCR00001_shipment : " & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_select_SCR00001_matbkd '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
                rs_SCR00001_matbkd = Nothing
                rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_matbkd, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading SCR00001 #020 sp_select_SCR00001_matbkd : " & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_select_SCR00001_disprm '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_disprm, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading SCR00001 #004 sp_select_SCR00001_disprm : " & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_select_SCR00001_assortment_ca '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "','" & PrintCusals & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_assortment, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading SCR00001 #005 sp_select_SCR00001_assortment_ca : " & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_select_SCORDHDR '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading SCR00001 #006 sp_select_SCORDHDR : " & rtnStr)
                    Exit Sub
                End If
            Else
                'gspStr = "sp_select_SCR00001 '" & cboCoCde.Text & "','" & heading & "','" & fty & "','" & shipFormat & _
                '         "','" & Sup0 & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "','" & SORTBY & "','" & _
                '         um & "','" & CRmk & "','" & Rvs & "','" & printPDF & "','" & gsUsrID & "','" & strModule & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    Me.Cursor = Windows.Forms.Cursors.Default
                '    MsgBox("Error on loading SCR00001 #001 sp_select_SCR00001_ca : " & rtnStr)
                '    Exit Sub
                'End If

                'gspStr = "sp_select_SCR00001_shipment '" & cboCoCde.Text & "','" & shipFormat & "','" & _
                '         txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_shipment, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    Me.Cursor = Windows.Forms.Cursors.Default
                '    MsgBox("Error on loading SCR00001 #002 sp_select_SCR00001_shipment : " & rtnStr)
                '    Exit Sub
                'End If

                ''gspStr = "sp_select_SCR00001_carton '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
                ''rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_carton, rtnStr)
                ''If rtnLong <> RC_SUCCESS Then
                ''    Me.Cursor = Windows.Forms.Cursors.Default
                ''    MsgBox("Error on loading SCR00001 #003 sp_select_SCR00001_carton : " & rtnStr)
                ''    Exit Sub
                ''End If

                'gspStr = "sp_select_SCR00001_disprm '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_disprm, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    Me.Cursor = Windows.Forms.Cursors.Default
                '    MsgBox("Error on loading SCR00001 #004 sp_select_SCR00001_disprm : " & rtnStr)
                '    Exit Sub
                'End If

                'gspStr = "sp_select_SCR00001_assortment '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "','" & txtToSCNo.Text & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_assortment, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    Me.Cursor = Windows.Forms.Cursors.Default
                '    MsgBox("Error on loading SCR00001 #005 sp_select_SCR00001_assortment_ca : " & rtnStr)
                '    Exit Sub
                'End If

                'gspStr = "sp_select_SCORDHDR '" & cboCoCde.Text & "','" & txtFromSCNo.Text & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    Me.Cursor = Windows.Forms.Cursors.Default
                '    MsgBox("Error on loading SCR00001 #006 sp_select_SCORDHDR : " & rtnStr)
                '    Exit Sub
                'End If
            End If

            Me.Cursor = Windows.Forms.Cursors.Default

            'Dim strvalue As String
            If rs_SCR00001.Tables("RESULT").Rows.Count = 0 Then
                If rs_check.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No record found !")
                    Exit Sub
                Else
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("You have no access rights to print!")
                    Exit Sub
                End If
            Else

                Dim dv As DataView = rs_SCR00001.Tables("RESULT").DefaultView
                If optCust.Checked = True Then
                    dv.Sort = "sod_ordno,sod_cusitm,sodKey,sod_cusitm,sod_cuscol, sod_coldsc"
                Else
                    dv.Sort = "sod_ordno,sodKey,suffix,sod_cusitm,sod_cuscol, sod_coldsc"
                End If
                rs_SCR00001.Tables.Remove("RESULT")
                rs_SCR00001.Tables.Add(dv.ToTable)


                ' Data Manipulation
                ' Change shipmark and company Logo filepath to Byte[]
                Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
                Dim compLogo As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("logoimgpth"))
                Dim shpmrkM As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("psm_imgpth_M"))
                Dim shpmrkS As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("psm_imgpth_S"))
                Dim shpmrkI As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("psm_imgpth_I"))
                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                colshpmrkM = New DataColumn("shpmrkM", System.Type.GetType("System.Byte[]"))
                colshpmrkS = New DataColumn("shpmrkS", System.Type.GetType("System.Byte[]"))
                colshpmrkI = New DataColumn("shpmrkI", System.Type.GetType("System.Byte[]"))
                rs_SCR00001.Tables("RESULT").Columns.Add(colCompLogo)
                rs_SCR00001.Tables("RESULT").Columns.Add(colshpmrkM)
                rs_SCR00001.Tables("RESULT").Columns.Add(colshpmrkS)
                rs_SCR00001.Tables("RESULT").Columns.Add(colshpmrkI)
                rs_SCR00001.Tables("RESULT").Columns("compLogo").ReadOnly = False
                rs_SCR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = False
                rs_SCR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = False
                rs_SCR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = False
                For i As Integer = 0 To rs_SCR00001.Tables("RESULT").Rows.Count - 1
                    rs_SCR00001.Tables("RESULT").Rows(i)("compLogo") = compLogo
                    rs_SCR00001.Tables("RESULT").Rows(i)("shpmrkM") = shpmrkM
                    rs_SCR00001.Tables("RESULT").Rows(i)("shpmrkS") = shpmrkS
                    rs_SCR00001.Tables("RESULT").Rows(i)("shpmrkI") = shpmrkI
                Next
                rs_SCR00001.Tables("RESULT").Columns("compLogo").ReadOnly = True
                rs_SCR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = True
                rs_SCR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = True
                rs_SCR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = True

                If cboReportFormat.SelectedIndex = 2 Then
                    Dim colItemImage As DataColumn
                    colItemImage = New DataColumn("itemimage", System.Type.GetType("System.Byte[]"))
                    rs_SCR00001.Tables("RESULT").Columns.Add(colItemImage)
                    rs_SCR00001.Tables("RESULT").Columns("itemimage").ReadOnly = False

                    Dim tmp_image As Byte()
                    For i As Integer = 0 To rs_SCR00001.Tables("RESULT").Rows.Count - 1
                        tmp_image = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(i)("ibi_imgpth"))
                        rs_SCR00001.Tables("RESULT").Rows(i)("itemimage") = tmp_image
                    Next
                End If


                If cboReportFormat.SelectedIndex = 0 Then

                    Dim objRpt As New SCR00001Rpt
                    objRpt.Database.Tables("SCR00001").SetDataSource(rs_SCR00001.Tables("RESULT"))
                    objRpt.Database.Tables("SCR00001_assortment").SetDataSource(rs_SCR00001_assortment.Tables("RESULT"))
                    objRpt.Database.Tables("SCR00001_disprm").SetDataSource(rs_SCR00001_disprm.Tables("RESULT"))
                    objRpt.Database.Tables("SCR00001_shipment").SetDataSource(rs_SCR00001_shipment.Tables("RESULT"))
                    objRpt.Database.Tables("SCR00001_matbkd").SetDataSource(rs_SCR00001_matbkd.Tables("RESULT"))
                    objRpt.Database.Tables("SCR00001_carton").SetDataSource(rs_SCR00001_carton.Tables("RESULT"))
                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()
                Else
                    Dim objRpt2 As New SCR00001RptHH
                    objRpt2.Database.Tables("SCR00001").SetDataSource(rs_SCR00001.Tables("RESULT"))
                    objRpt2.Database.Tables("SCR00001_assortment").SetDataSource(rs_SCR00001_assortment.Tables("RESULT"))
                    objRpt2.Database.Tables("SCR00001_disprm").SetDataSource(rs_SCR00001_disprm.Tables("RESULT"))
                    objRpt2.Database.Tables("SCR00001_shipment").SetDataSource(rs_SCR00001_shipment.Tables("RESULT"))
                    objRpt2.Database.Tables("SCR00001_matbkd").SetDataSource(rs_SCR00001_matbkd.Tables("RESULT"))
                    objRpt2.Database.Tables("SCR00001_carton").SetDataSource(rs_SCR00001_carton.Tables("RESULT"))
                    Dim frmReportView2 As New frmReport
                    frmReportView2.CrystalReportViewer.ReportSource = objRpt2
                    frmReportView2.Show()
                End If
            End If
        ElseIf cboReportFormat.SelectedIndex = 1 Then

            Dim dir As New IO.DirectoryInfo(strDir)
            If dir.Exists = False Then
                MsgBox("The Following Directory Does not exist: " & strDir)
                Exit Sub
            End If

            Dim rs_SCR00001_PDF As DataSet

            gspStr = "sp_select_SQL '','select soh_ordno from SCORDHDR where soh_ordno between ''" & txtFromSCNo.Text & "'' and ''" & txtToSCNo.Text & "'' and soh_cocde = ''" & cboCoCde.Text & "'''"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_PDF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading SCR00001 #007 sp_select_SQL : " & rtnStr)
                Exit Sub
            End If

            If rs_SCR00001_PDF.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No Record Found!")
                Exit Sub
            End If

            Try
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                For i As Integer = 0 To rs_SCR00001_PDF.Tables("RESULT").Rows.Count - 1
                    Dim SC_no As String = rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno")
                    If PrintCusals = "1" Then
                        gspStr = "sp_select_SCR00001_ca '" & cboCoCde.Text & "','" & heading & "','" & fty & "','" & shipFormat & _
                                 "','" & Sup0 & "','" & SC_no & "','" & SC_no & "','" & SORTBY & "','" & um & _
                                 "','" & CRmk & "','" & Rvs & "','" & HTSU & "','" & CV & "','" & PrintCusals & "','" & printPDF & _
                                 "','" & gsUsrID & "','" & strModule & "','" & pritype & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_SCR00001, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("Error on loading SCR00001 #008 sp_select_SCR00001_ca : " & rtnStr)
                            Exit Sub
                        End If

                        gspStr = "sp_select_SCR00001_shipment '" & cboCoCde.Text & "','" & shipFormat & "','" & _
                                 rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_shipment, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("Error on loading SCR00001 #009 sp_select_SCR00001_shipment : " & rtnStr)
                            Exit Sub
                        End If

                        gspStr = "sp_select_SCR00001_matbkd '" & cboCoCde.Text & "','" & _
                                 rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "','" & _
                                 rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        rs_SCR00001_matbkd = Nothing
                        rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_matbkd, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("Error on loading SCR00001 #021 sp_select_SCR00001_matbkd : " & rtnStr)
                            Exit Sub
                        End If

                        'gspStr = "sp_select_SCR00001_carton '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & _
                        '         "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_carton, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #010 sp_select_SCR00001_carton : " & rtnStr)
                        '    Exit Sub
                        'End If

                        gspStr = "sp_select_SCR00001_disprm '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & _
                                 "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_disprm, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("Error on loading SCR00001 #011 sp_select_SCR00001_disprm : " & rtnStr)
                            Exit Sub
                        End If

                        gspStr = "sp_select_SCR00001_assortment_ca '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & _
                                 "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "','" & PrintCusals & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_assortment, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("Error on loading SCR00001 #012 sp_select_SCR00001_assortment_ca : " & rtnStr)
                            Exit Sub
                        End If

                        gspStr = "sp_select_SCORDHDR '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("Error on loading SCR00001 #013 sp_select_SCORDHDR : " & rtnStr)
                            Exit Sub
                        End If
                    Else
                        'gspStr = "sp_select_SCR00001 '" & cboCoCde.Text & "','" & heading & "','" & fty & "','" & shipFormat & _
                        '         "','" & Sup0 & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "','" & _
                        '         rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "','" & SORTBY & "','" & _
                        '         um & "','" & CRmk & "','" & Rvs & "','" & printPDF & "','" & gsUsrID & "','" & strModule & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #014 sp_select_SCR00001 : " & rtnStr)
                        '    Exit Sub
                        'End If

                        'gspStr = "sp_select_SCR00001_shipment '" & cboCoCde.Text & "','" & shipFormat & "','" & _
                        '         rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "','" & _
                        '         rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_shipment, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #015 sp_select_SCR00001_shipment : " & rtnStr)
                        '    Exit Sub
                        'End If

                        'gspStr = "sp_select_SCR00001_matbkd '" & cboCoCde.Text & "','" & _
                        '         rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "','" & _
                        '         rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        'rs_SCR00001_matbkd = Nothing
                        'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_matbkd, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #022 sp_select_SCR00001_matbkd : " & rtnStr)
                        '    Exit Sub
                        'End If

                        'gspStr = "sp_select_SCR00001_carton '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & _
                        '         "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_carton, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #016 sp_select_SCR00001_carton : " & rtnStr)
                        '    Exit Sub
                        'End If

                        'gspStr = "sp_select_SCR00001_disprm '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & _
                        '         "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_disprm, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #017 sp_select_SCR00001_disprm : " & rtnStr)
                        '    Exit Sub
                        'End If

                        'gspStr = "sp_select_SCR00001_assortment '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & _
                        '         "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_SCR00001_assortment, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #018 sp_select_SCR00001_assortment_ca : " & rtnStr)
                        '    Exit Sub
                        'End If

                        'gspStr = "sp_select_SCORDHDR '" & cboCoCde.Text & "','" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    MsgBox("Error on loading SCR00001 #019 sp_select_SCORDHDR : " & rtnStr)
                        '    Exit Sub
                        'End If
                    End If

                    Me.Cursor = Windows.Forms.Cursors.Default

                    'Dim strvalue As String
                    If rs_SCR00001.Tables("RESULT").Rows.Count = 0 Then
                        If rs_check.Tables("RESULT").Rows.Count = 0 Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("No record found !")
                            Exit Sub
                        Else
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("You have no access rights to print!")
                            Exit Sub
                        End If
                    Else

                        Dim dv As DataView = rs_SCR00001.Tables("RESULT").DefaultView
                        If optCust.Checked = True Then
                            dv.Sort = "sod_ordno,sod_cusitm,sodKey,sod_cusitm,sod_cuscol, sod_coldsc"
                        Else
                            dv.Sort = "sod_ordno,sodKey,suffix,sod_cusitm,sod_cuscol, sod_coldsc"
                        End If
                        rs_SCR00001.Tables.Remove("RESULT")
                        rs_SCR00001.Tables.Add(dv.ToTable)


                        Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
                        Dim compLogo As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("logoimgpth"))
                        Dim shpmrkM As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("psm_imgpth_M"))
                        Dim shpmrkS As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("psm_imgpth_S"))
                        Dim shpmrkI As Byte() = imageToByteArray(rs_SCR00001.Tables("RESULT").Rows(0)("psm_imgpth_I"))
                        colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                        colshpmrkM = New DataColumn("shpmrkM", System.Type.GetType("System.Byte[]"))
                        colshpmrkS = New DataColumn("shpmrkS", System.Type.GetType("System.Byte[]"))
                        colshpmrkI = New DataColumn("shpmrkI", System.Type.GetType("System.Byte[]"))
                        rs_SCR00001.Tables("RESULT").Columns.Add(colCompLogo)
                        rs_SCR00001.Tables("RESULT").Columns.Add(colshpmrkM)
                        rs_SCR00001.Tables("RESULT").Columns.Add(colshpmrkS)
                        rs_SCR00001.Tables("RESULT").Columns.Add(colshpmrkI)
                        rs_SCR00001.Tables("RESULT").Columns("compLogo").ReadOnly = False
                        rs_SCR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = False
                        rs_SCR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = False
                        rs_SCR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = False
                        For j As Integer = 0 To rs_SCR00001.Tables("RESULT").Rows.Count - 1
                            rs_SCR00001.Tables("RESULT").Rows(j)("compLogo") = compLogo
                            rs_SCR00001.Tables("RESULT").Rows(j)("shpmrkM") = shpmrkM
                            rs_SCR00001.Tables("RESULT").Rows(j)("shpmrkS") = shpmrkS
                            rs_SCR00001.Tables("RESULT").Rows(j)("shpmrkI") = shpmrkI
                        Next
                        rs_SCR00001.Tables("RESULT").Columns("compLogo").ReadOnly = True
                        rs_SCR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = True
                        rs_SCR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = True
                        rs_SCR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = True


                        'Dim objRpt As New SCR00001Rpt
                        'objRpt.Database.Tables("SCR00001").SetDataSource(rs_SCR00001.Tables("RESULT"))
                        'objRpt.Database.Tables("SCR00001_assortment").SetDataSource(rs_SCR00001_assortment.Tables("RESULT"))
                        ''Add Subreport report source
                        'objRpt.Subreports.Item("SCR00001_disprm").SetDataSource(rs_SCR00001_disprm.Tables("RESULT"))
                        'objRpt.Subreports.Item("SCR00001_shipment").SetDataSource(rs_SCR00001_shipment.Tables("RESULT"))
                        'objRpt.Subreports.Item("SCR00001_matbkd").SetDataSource(rs_SCR00001_matbkd.Tables("RESULT"))
                        'objRpt.Subreports.Item("SCR00001_carton").SetDataSource(rs_SCR00001_carton.Tables("RESULT"))

                        Dim objRpt As New SCR00001Rpt
                        objRpt.Database.Tables("SCR00001").SetDataSource(rs_SCR00001.Tables("RESULT"))
                        objRpt.Database.Tables("SCR00001_assortment").SetDataSource(rs_SCR00001_assortment.Tables("RESULT"))
                        objRpt.Database.Tables("SCR00001_disprm").SetDataSource(rs_SCR00001_disprm.Tables("RESULT"))
                        objRpt.Database.Tables("SCR00001_shipment").SetDataSource(rs_SCR00001_shipment.Tables("RESULT"))
                        objRpt.Database.Tables("SCR00001_matbkd").SetDataSource(rs_SCR00001_matbkd.Tables("RESULT"))
                        objRpt.Database.Tables("SCR00001_carton").SetDataSource(rs_SCR00001_carton.Tables("RESULT"))

                        'Export to PDF
                        objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, strDir & "\" & rs_SCR00001_PDF.Tables("RESULT").Rows(i)("soh_ordno").ToString & ".pdf")
                    End If
                Next
            Catch ex As Exception
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("An Error has occurred in the process : " + ex.ToString, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try

            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Total " & rs_SCR00001_PDF.Tables("RESULT").Rows.Count & " SC(s) has/have been converted successfully.")
        End If
    End Sub

    Private Sub txtFromSCNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromSCNo.TextChanged
        txtToSCNo.Text = txtFromSCNo.Text
    End Sub

    Private Function imageToByteArray(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If ImageFilePath = "" Then
            Return Nothing
        End If
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub cboReportFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportFormat.SelectedIndexChanged
        If cboReportFormat.SelectedIndex = 2 Then
            optNewY.Checked = False
            optNewY.Enabled = False
            optNewN.Checked = True
            optNewN.Enabled = True
        Else
            optNewY.Checked = True
            optNewY.Enabled = True
            optNewN.Checked = False
            optNewN.Enabled = False
        End If
    End Sub
End Class