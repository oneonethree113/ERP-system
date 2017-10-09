Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource

Public Class QUR00001

    Public rs_QUR0000A As New DataSet
    Public rs_QUR0000excel As New DataSet

    Const strModule As String = "QU"

    Const imgMaxHeight As Integer = 847 '907 '840
    Const imgMaxWidth As Integer = 650 '680 '630

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim rs_QUR00001Status As New DataSet

    Private Sub QUR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Sartup position
        Cursor = Cursors.Default

        txtFromQuotNo.MaxLength = 20
        txtToQuotNo.MaxLength = 20
        Opt_yes.Checked = True
        Opt_no.Checked = False
        Opt_org.Checked = True
        Opt_Con.Checked = False
        optCust.Checked = False
        optItem.Checked = True
        Opt_qayes.Checked = True
        Opt_qano.Checked = False

        If GetDefaultCompany_Local() = "UCPP" Then
            Opt_yes.Enabled = False
            Opt_no.Checked = True
            optPrintVenN.Checked = True
        End If

        Combo1.Items.Add("Quotation Standard Format w/o Photo")
        Combo1.Items.Add("Quotation Standard Format w/Photo & Color")
        Combo1.Items.Add("Quotation Standard Format w/Blank Photo")
        Combo1.Items.Add("Export to Excel Sheet")
        Combo1.SelectedIndex = 0
    End Sub

    Public Function GetDefaultCompany_Local() As String
        '*** A function to get the user's default company
        GetDefaultCompany_Local = ""

        If rs_SYUSRPRF.Tables.Count = 0 Then Exit Function
        If rs_SYUSRPRF.Tables("RESULT").Rows.Count <= 0 Then Exit Function

        For index As Integer = 0 To rs_SYUSRPRF.Tables("RESULT").Rows.Count - 1
            If rs_SYUSRPRF.Tables("RESULT").Rows(index)("yuc_flgdef").ToString = "Y" Then
                GetDefaultCompany_Local = Trim(rs_SYUSRPRF.Tables("RESULT").Rows(index)("yuc_cocde"))
                Exit Function
            End If
        Next
    End Function

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub txtFromQuotNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromQuotNo.TextChanged
        If sender.focused = True Then
            txtToQuotNo.Text = txtFromQuotNo.Text
        End If
    End Sub

    Private Sub optGroupN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optGroupN.CheckedChanged
        optGroupN.Enabled = False
        optPhotoAllN.Enabled = False
        'Label3(6).Enabled = False
        Label17.Enabled = False
        optPhotoAllY.Checked = True
    End Sub

    Private Sub optGroupY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optGroupY.CheckedChanged
        optGroupN.Enabled = True
        optPhotoAllN.Enabled = True
        'Label3(6).Enabled = True
        Label17.Enabled = True
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        Dim AscDesc As String

        If txtFromQuotNo.Text = "" And txtToQuotNo.Text = "" Then
            MsgBox("Please input Quotation No.", vbCritical, "Warning")
            txtFromQuotNo.SelectAll()
            Exit Sub
        End If

        'S = "㊣QUR00001Status※S※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUR00001Status '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QUR00001Status, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdShow_Click sp_select_QUR00001Status :" & rtnStr)
            Exit Sub
        End If

        If rs_QUR00001Status.Tables("RESULT").Rows.Count > 0 Then
            Cursor = Cursors.Default
            MsgBox("At least one of Quotations is not in 'Active' status, so it can't print Quotation.")
            Exit Sub
        End If

        Dim ReportName As String
        Dim ReportRS As New DataSet

        If txtFromQuotNo.Text > txtToQuotNo.Text Then
            MsgBox("Invalid Input! (From Item No. <= To Item No!)")
            txtFromQuotNo.SelectAll()
            Exit Sub
        End If

        Dim fty As Integer
        Dim Cftr As Integer
        Dim showqa As Integer
        Dim PrintVen As String
        Dim PrintDI As String
        Dim PrintDV As String
        Dim PrintAlias As String
        Dim printGroup As String
        Dim PrintAll As String
        Dim PrintCusals As String
        Dim sorting As String

        If Opt_yes.Checked = True Then
            fty = 1
        Else
            fty = 0
        End If

        If Opt_Con.Checked = True Then
            Cftr = 1
        Else
            Cftr = 0
        End If

        If Opt_qayes.Checked = True Then
            showqa = 1
        Else
            showqa = 0
        End If

        If optPrintVenY.Checked = True Then
            PrintVen = "1"
        Else
            PrintVen = "0"
        End If

        If optPDIY.Checked = True Then
            PrintDI = "1"
        Else
            PrintDI = "0"
        End If

        If optPDVY.Checked = True Then
            PrintDV = "1"
        Else
            PrintDV = "0"
        End If

        If optAliasY.Checked = True Then
            PrintAlias = "1"
        Else
            PrintAlias = "0"
        End If

        If optGroupY.Checked = True Then
            printGroup = "1"
        Else
            printGroup = "0"
        End If

        If optPhotoAllY.Checked = True Then
            PrintAll = "1"
        Else
            PrintAll = "0"
        End If

        PrintCusals = "1"

        If optCust.Checked = True Then
            sorting = "CUST"
        ElseIf optItem.Checked = True Then
            sorting = "ITEM"
        Else
            sorting = "SEQ"
        End If

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Dim message As String = ""

        If Combo1.SelectedIndex <> 3 Then
            If optPSY.Checked = True Then
                If PrintCusals = "1" Then
                    'S = "㊣QUR0000A_ls_ca※S※" & PrintVen & "※" & Cftr & "※" & fty & "※" & showqa & "※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text & "※" & PrintDI & "※" & PrintDV & "※" & sorting & "※" & PrintAlias & "※" & printGroup & "※" & PrintAll & "※" & PrintCusals & "※" & gsUsrID & "※" & strModule
                    gspStr = "sp_select_QUR0000A_ls_ca '" & gsCompany & "','" & PrintVen & "','" & Cftr & "','" & fty & "','" & showqa & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & PrintDI & "','" & PrintDV & "','" & sorting & "','" & PrintAlias & "','" & printGroup & "','" & PrintAll & "','" & PrintCusals & "','" & gsUsrID & "','" & strModule & "'"
                    message = "sp_select_QUR0000A_ls_ca"
                Else
                    'S = "㊣QUR0000A_ls※S※" & PrintVen & "※" & Cftr & "※" & fty & "※" & showqa & "※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text & "※" & PrintDI & "※" & PrintDV & "※" & sorting & "※" & PrintAlias & "※" & printGroup & "※" & PrintAll & "※" & gsUsrID & "※" & strModule
                    gspStr = "sp_select_QUR0000A_ls '" & gsCompany & "','" & PrintVen & "','" & Cftr & "','" & fty & "','" & showqa & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & PrintDI & "','" & PrintDV & "','" & sorting & "','" & PrintAlias & "','" & printGroup & "','" & PrintAll & "','" & gsUsrID & "','" & strModule & "'"
                    message = "sp_select_QUR0000A_ls"
                End If
            Else
                If PrintCusals = "1" Then
                    'S = "㊣QUR0000A_WO_S_ls_ca※S※" & PrintVen & "※" & Cftr & "※" & fty & "※" & showqa & "※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text & "※" & PrintDI & "※" & PrintDV & "※" & sorting & "※" & PrintAlias & "※" & printGroup & "※" & PrintAll & "※" & PrintCusals & "※" & gsUsrID & "※" & strModule
                    gspStr = "sp_select_QUR0000A_WO_S_ls_ca '" & gsCompany & "','" & PrintVen & "','" & Cftr & "','" & fty & "','" & showqa & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & PrintDI & "','" & PrintDV & "','" & sorting & "','" & PrintAlias & "','" & printGroup & "','" & PrintAll & "','" & PrintCusals & "','" & gsUsrID & "','" & strModule & "'"
                    message = "sp_select_QUR0000A_WO_S_ls_ca"
                Else
                    'S = "㊣QUR0000A_WO_S_ls※S※" & PrintVen & "※" & Cftr & "※" & fty & "※" & showqa & "※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text & "※" & PrintDI & "※" & PrintDV & "※" & sorting & "※" & PrintAlias & "※" & printGroup & "※" & PrintAll & "※" & gsUsrID & "※" & strModule
                    gspStr = "sp_select_QUR0000A_WO_S_ls '" & gsCompany & "','" & PrintVen & "','" & Cftr & "','" & fty & "','" & showqa & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & PrintDI & "','" & PrintDV & "','" & sorting & "','" & PrintAlias & "','" & printGroup & "','" & PrintAll & "','" & gsUsrID & "','" & strModule & "'"
                    message = "sp_select_QUR0000A_WO_S_ls"
                End If
            End If
        Else
            'S = "㊣QUR0000excel※S※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text & "※" & sorting & "※" & gsUsrID & "※" & strModule
            gspStr = "sp_select_QUR0000excel '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & sorting & "','" & gsUsrID & "','" & strModule & "'"
            message = "sp_select_QUR0000excel"
        End If
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        If Combo1.SelectedIndex <> 3 Then
            rtnLong = execute_SQLStatement(gspStr, rs_QUR0000A, rtnStr)
        Else
            rtnLong = execute_SQLStatement(gspStr, rs_QUR0000excel, rtnStr)
        End If

        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdShow_Click " & message & " :" & rtnStr)
            Exit Sub
        End If

        If Combo1.SelectedIndex <> 3 Then
            If rs_QUR0000A.Tables("RESULT").Rows.Count = 0 Then
                'S = "㊣QUOTNHDR※S※" & Trim(txtFromQuotNo.Text)
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
                Dim rs As New DataSet

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_QUOTNHDR '" & gsCompany & "','" & txtFromQuotNo.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdShow_Click sp_select_QUOTNHDR 1 :" & rtnStr)
                    Exit Sub
                End If

                If rs.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Record Found!")
                    Exit Sub
                Else
                    MsgBox("You have no access rights to print!")
                    Exit Sub
                End If
            Else
                Dim colCompLogo, colItm As DataColumn
                Dim compLogo, itm As Byte()

                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_QUR0000A.Tables("RESULT").Columns.Add(colCompLogo)
                rs_QUR0000A.Tables("RESULT").Columns("compLogo").ReadOnly = False

                colItm = New DataColumn("itm", System.Type.GetType("System.Byte[]"))
                rs_QUR0000A.Tables("RESULT").Columns.Add(colItm)
                rs_QUR0000A.Tables("RESULT").Columns("itm").ReadOnly = False

                For i As Integer = 0 To rs_QUR0000A.Tables("RESULT").Rows.Count - 1
                    compLogo = imageToByteArray(rs_QUR0000A.Tables("RESULT").Rows(i)("yco_logoimgpth"))
                    rs_QUR0000A.Tables("RESULT").Rows(i)("compLogo") = compLogo

                    ' Check if the image exists or not
                    If System.IO.File.Exists(rs_QUR0000A.Tables("RESULT").Rows(i)("imm.ibi_imgpth").ToString) = False Then
                        rs_QUR0000A.Tables("RESULT").Columns("imm.ibi_imgpth").ReadOnly = False
                        rs_QUR0000A.Tables("RESULT").Rows(i)("imm.ibi_imgpth") = ""
                        rs_QUR0000A.Tables("RESULT").Columns("imm.ibi_imgpth").ReadOnly = True
                    End If

                    itm = resizeImageToByteArray(rs_QUR0000A.Tables("RESULT").Rows(i)("imm.ibi_imgpth"))
                    rs_QUR0000A.Tables("RESULT").Rows(i)("itm") = itm
                Next

                rs_QUR0000A.Tables("RESULT").Columns("compLogo").ReadOnly = True
                rs_QUR0000A.Tables("RESULT").Columns("itm").ReadOnly = True

                If Combo1.SelectedIndex = 0 Then
                    If PrintCusals = "1" Then
                        Dim objRpt As New QUR00004CA
                        objRpt.SetDataSource(rs_QUR0000A.Tables("RESULT"))
                        'Add Subreport report source
                        objRpt.Subreports.Item("subreport00004").SetDataSource(rs_QUR0000A.Tables("RESULT"))

                        Dim frmReportView As New frmReport
                        frmReportView.CrystalReportViewer.ReportSource = objRpt
                        frmReportView.Show()

                        'ReDim ReportName(0 To 1) As String
                        'ReDim ReportRS(0 To 1) As ADOR.Recordset
                        'ReportName(0) = "QUR00004CA.rpt"
                        'ReportRS(0) = rs_QUR0000A
                        'ReportName(1) = "subreport00004"
                        'ReportRS(1) = rs_QUR0000A
                        'frmReport.Show()
                    Else
                        'ReDim ReportName(0 To 1) As String
                        'ReDim ReportRS(0 To 1) As ADOR.Recordset
                        'ReportName(0) = "QUR00004.rpt"
                        'ReportRS(0) = rs_QUR0000A
                        'ReportName(1) = "subreport00004"
                        'ReportRS(1) = rs_QUR0000A
                        frmReport.Show()
                    End If
                ElseIf Combo1.SelectedIndex = 1 Then
                    Dim objRpt As New QUR00001Rpt
                    objRpt.SetDataSource(rs_QUR0000A.Tables("RESULT"))
                    'Add Subreport report source
                    objRpt.Subreports.Item("QUR0000subreport").SetDataSource(rs_QUR0000A.Tables("RESULT"))

                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()

                    'ReDim ReportName(0 To 1) As String

                    'Rpt_QUR00001 = New QUR00001Rpt
                    'Rpt_QUR00001.Database.SetDataSource(rs_QUR0000A)
                    'Rpt_QUR00001.OpenSubreport("QUR0000subreport").Database.SetDataSource(rs_QUR0000A)

                    'frmCR.Report = Rpt_QUR00001
                    'frmCR.Show()
                Else
                    If PrintCusals = "1" Then
                        Dim objRpt As New QUR00006CA
                        objRpt.SetDataSource(rs_QUR0000A.Tables("RESULT"))
                        'Add Subreport report source
                        objRpt.Subreports.Item("QUR0000subreport").SetDataSource(rs_QUR0000A.Tables("RESULT"))

                        Dim frmReportView As New frmReport
                        frmReportView.CrystalReportViewer.ReportSource = objRpt
                        frmReportView.Show()

                        'ReDim ReportName(0 To 1) As String
                        'ReDim ReportRS(0 To 1) As ADOR.Recordset
                        'ReportName(0) = "QUR00006CA.rpt"
                        'ReportRS(0) = rs_QUR0000A
                        'ReportName(1) = "QUR0000subreport"
                        'ReportRS(1) = rs_QUR0000A
                        'frmReport.Show()
                    Else
                        'ReDim ReportName(0 To 1) As String
                        'ReDim ReportRS(0 To 1) As ADOR.Recordset
                        '       ReportName(0) = "QUR00006.rpt"
                        '       ReportRS(0) = rs_QUR0000A
                        '       ReportName(1) = "QUR0000subreport"
                        '       ReportRS(1) = rs_QUR0000A
                        'frmReport.Show()
                    End If
                End If
            End if
        Else
            If rs_QUR0000excel.Tables("RESULT").Rows.Count = 0 Then
                'S = "㊣QUOTNHDR※S※" & Trim(txtFromQuotNo.Text)
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
                Dim rs As New DataSet

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_QUOTNHDR '" & gsCompany & "','" & txtFromQuotNo.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdShow_Click sp_select_QUOTNHDR 2 :" & rtnStr)
                    Exit Sub
                End If

                If rs.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Record Found!")
                    Exit Sub
                Else
                    MsgBox("You have no access rights to print!")
                    Exit Sub
                End If
            Else
                '*** Open excel format option
                If rs_QUR0000excel.Tables("RESULT").Rows.Count > 30000 Then
                    Dim answer As String = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                    If answer = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
                Call exportExcel_QUR0000excel()

                'ReDim ReportName(0) As String
                'ReDim ReportRS(0) As ADOR.Recordset
                '   ReportName(0) = "QUR0000excel.rpt"
                '   ReportRS(0) = rs_QUR0000excel

                'Call CmdExportExcel_Click()
                Exit Sub
            End If
        End If
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

    Private Function resizeImageToByteArray(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing

        If ImageFilePath = "" Then
            Return Nothing
        End If

        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If

        Try
            Dim bm_source As New Bitmap(ImageFilePath)
            Dim scaleFactor As Double = 1

            Dim imageHeight As Integer = bm_source.Height
            Dim imageWidth As Integer = bm_source.Width

            If imageHeight <= imgMaxHeight And imageWidth <= imgMaxWidth Then
                'scaleFactor = 1
                If (imgMaxHeight / imageHeight) < (imgMaxWidth / imageWidth) Then
                    scaleFactor = imgMaxHeight / imageHeight
                Else
                    scaleFactor = imgMaxWidth / imageWidth
                End If
            ElseIf imageHeight > imgMaxHeight And imageWidth <= imgMaxWidth Then
                scaleFactor = imgMaxHeight / imageHeight
            ElseIf imageHeight <= imgMaxHeight And imageWidth > imgMaxWidth Then
                scaleFactor = imgMaxWidth / imageWidth
            Else
                If (imgMaxHeight / imageHeight) < (imgMaxWidth / imageWidth) Then
                    scaleFactor = imgMaxHeight / imageHeight
                Else
                    scaleFactor = imgMaxWidth / imageWidth
                End If
            End If

            Dim bm_dest As New Bitmap(CInt(bm_source.Width * scaleFactor), CInt(bm_source.Height * scaleFactor))

            ' Make a Graphics object for the result Bitmap.
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            ' Copy the source image into the destination bitmap.
            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

            Using stream As New System.IO.MemoryStream
                bm_dest.Save(stream, bm_source.RawFormat)
                _tempByte = stream.ToArray
            End Using

            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub exportExcel_QUR0000excel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        If rs_QUR0000excel.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim entry(50) As Object

        Try
            'Initializing Header Row'
            With xlsApp
                entry(0) = "Code"
                entry(1) = "Primary Customer"
                entry(2) = "Primary Cust Name"
                entry(3) = "Quotation No"
                entry(4) = "Sequence No"
                entry(5) = "Revised Date"
                entry(6) = "Validity Date"
                entry(7) = "Item #"
                entry(8) = "Customer Alias No."
                entry(9) = "Cust Item #"
                entry(10) = "Old Item #"
                entry(11) = "Old VD. Color Code"
                entry(12) = "Item Desc"
                entry(13) = "VD. Color Code"
                entry(14) = "Cust Color Code"
                entry(15) = "Color Desc"
                entry(16) = "Inner"
                entry(17) = "Master"
                entry(18) = "UM"
                entry(19) = "CFT"
                entry(20) = "Currency"
                entry(21) = "Primary Discounted Price"
                entry(22) = "PriceTerm"
                entry(23) = "MOQ"
                entry(24) = "MOA"
                entry(25) = "Note"
                entry(26) = "HSTU #"
                entry(27) = "Duty"
                entry(28) = "Cust Retail: USD"
                entry(29) = "Cust Retail CAD"
                entry(30) = "Inner Dim - d (in)"
                entry(31) = "Inner Dim - w (in)"
                entry(32) = "Inner Dim - h (in)"
                entry(33) = "Inner Dim - d (cm)"
                entry(34) = "Inner Dim - w (cm)"
                entry(35) = "Inner Dim - h (cm)"
                entry(36) = "Master Dim - d (in)"
                entry(37) = "Master Dim - w (in)"
                entry(38) = "Master Dim - h (in)"
                entry(39) = "Master Dim - d (cm)"
                entry(40) = "Master Dim - w (cm)"
                entry(41) = "Master Dim - h (cm)"
                entry(42) = "GW"
                entry(43) = "NW"
                entry(44) = "Const Method"
                entry(45) = "Comp BreakDown"
                entry(46) = "Custom Vendor #"
                entry(47) = "Custom Vendor Short Name"
                entry(48) = "Vendor #"
                entry(49) = "Vendor Short Name"
                entry(50) = "Vendor Item #"

                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
            End With

            'Populating Data
            With xlsApp
                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").Rows.Count - 1
                    entry(0) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Code")
                    entry(1) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Primary Customer")
                    entry(2) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Primary Cust Name")
                    entry(3) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Quotation No")
                    entry(4) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Sequence No")
                    entry(5) = Convert.ToDateTime(rs_QUR0000excel.Tables("RESULT").Rows(i)("Revised Date")).ToShortDateString
                    entry(6) = Convert.ToDateTime(rs_QUR0000excel.Tables("RESULT").Rows(i)("Validity Date")).ToShortDateString
                    entry(7) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Item #")
                    entry(8) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Customer Alias No.")
                    entry(9) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Cust Item #")
                    entry(10) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Old Item #")
                    entry(11) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Old VD. Color Code")
                    entry(12) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Item Desc").ToString().Trim()
                    entry(13) = rs_QUR0000excel.Tables("RESULT").Rows(i)("VD. Color Code")
                    entry(14) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Cust Color Code")
                    entry(15) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Color Desc").ToString().Trim()
                    entry(16) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Inner")
                    entry(17) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Master")
                    entry(18) = rs_QUR0000excel.Tables("RESULT").Rows(i)("UM")
                    entry(19) = rs_QUR0000excel.Tables("RESULT").Rows(i)("CFT")
                    entry(20) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Currency")
                    entry(21) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Primary Discounted Price")
                    entry(22) = rs_QUR0000excel.Tables("RESULT").Rows(i)("PriceTerm")
                    entry(23) = rs_QUR0000excel.Tables("RESULT").Rows(i)("MOQ")
                    entry(24) = rs_QUR0000excel.Tables("RESULT").Rows(i)("MOA")
                    entry(25) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Note").ToString().Trim()
                    entry(26) = rs_QUR0000excel.Tables("RESULT").Rows(i)("HSTU #")
                    entry(27) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Duty")
                    entry(28) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Cust Retail: USD")
                    entry(29) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Cust Retail CAD")
                    entry(30) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Inner Dim - d (in)")
                    entry(31) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Inner Dim - w (in)")
                    entry(32) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Inner Dim - h (in)")
                    entry(33) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Inner Dim - d (cm)")
                    entry(34) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Inner Dim - w (cm)")
                    entry(35) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Inner Dim - h (cm)")
                    entry(36) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Master Dim - d (in)")
                    entry(37) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Master Dim - w (in)")
                    entry(38) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Master Dim - h (in)")
                    entry(39) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Master Dim - d (cm)")
                    entry(40) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Master Dim - w (cm)")
                    entry(41) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Master Dim - h (cm)")
                    entry(42) = rs_QUR0000excel.Tables("RESULT").Rows(i)("GW")
                    entry(43) = rs_QUR0000excel.Tables("RESULT").Rows(i)("NW")
                    entry(44) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Const Method")
                    entry(45) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Comp BreakDown")
                    entry(46) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Custom Vendor #")
                    entry(47) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Custom Vendor Short Name")
                    entry(48) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Vendor #")
                    entry(49) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Vendor Short Name")
                    entry(50) = rs_QUR0000excel.Tables("RESULT").Rows(i)("Vendor Item #")

                    .Range(.Cells(hdrRow + 1 + i, 1), .Cells(hdrRow + 1 + i, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
                Next
            End With

            ' Configuring XLS Style
            With xlsApp
                .Rows("1:1").Font.Bold = True
                .Rows("1:1").Font.Underline = True
                .Rows("1:1").Font.Size = 10

                For index As Integer = 1 To entry.Length
                    If index = 13 Or index = 16 Or index = 26 Then
                        .Columns(index).WrapText = False
                        .Columns(index).EntireColumn.AutoFit()
                        .Columns(index).WrapText = True
                        .Columns(index).EntireColumn.AutoFit()
                    Else
                        .Columns(index).EntireColumn.AutoFit()
                    End If
                Next

                '.Columns("A:AY").EntireColumn.AutoFit()
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_QUR0000excel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "QUR00001 - Excel Error")
            End If
        End Try

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        rs_QUR0000excel = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
    End Sub
End Class