Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource

Public Class QUR00003

    Public rs_QUR0000A As New DataSet
    Public rs_QUR0000excel As New DataSet

    Const strModule As String = "QU"

    Const imgMaxHeight As Integer = 847 '907 '840
    Const imgMaxWidth As Integer = 650 '680 '630

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim rs_QUR00001Status As New DataSet
    Dim rs_QUPRCEMT_MU As New DataSet
    Public rs_QUASSINF As New DataSet ' for Assortment Item information

    Dim rs_lightspec As New DataSet




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


        If GetDefaultCompany_Local() = "UCPP" Then
            'Opt_yes.Enabled = False
            'Opt_no.Checked = True
            'optPrintVenN.Checked = True
        End If

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
            'txtToQuotNo.Text = txtFromQuotNo.Text
        End If
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        


        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        Dim AscDesc As String

        If txtFromQuotNo.Text = "" Then
            MsgBox("Please input Quotation No.", vbCritical, "Warning")
            txtFromQuotNo.SelectAll()
            Exit Sub
        End If

        'S = "㊣QUR00001Status※S※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUR00001Status '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtFromQuotNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QUR00001Status, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdShow_Click sp_select_QUR00001Status :" & rtnStr)
            Exit Sub
        End If

        ' ''If rs_QUR00001Status.Tables("RESULT").Rows.Count > 0 Then
        ' ''    Cursor = Cursors.Default
        ' ''    MsgBox("At least one of Quotations is not in 'Active' status, so it can't print Quotation.")
        ' ''    Exit Sub
        ' ''End If

        Dim ReportName As String
        Dim ReportRS As New DataSet

        'If txtFromQuotNo.Text > txtToQuotNo.Text Then
        '    MsgBox("Invalid Input! (From Item No. <= To Item No!)")
        '    txtFromQuotNo.SelectAll()
        '    Exit Sub
        'End If

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

        PrintCusals = "1"


        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Dim message As String = ""



        gspStr = "sp_select_QURExporttoExcel '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtFromQuotNo.Text & "','" & sorting & "'"
        message = "sp_select_QURExporttoExcel"
        rtnLong = execute_SQLStatement(gspStr, rs_QUR0000excel, rtnStr)

        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QURExporttoExcel " & message & " :" & rtnStr)
            Exit Sub
        End If



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
                MsgBox("No Recod  or You have no access rights to print!")
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

            'Call exportExcel_QUR0000excel()
            Call exportExcel_QURExportToExcel_int()
            Call exportExcel_QURExportToExcel_ext()

            'ReDim ReportName(0) As String
            'ReDim ReportRS(0) As ADOR.Recordset
            '   ReportName(0) = "QUR0000excel.rpt"
            '   ReportRS(0) = rs_QUR0000excel

            'Call CmdExportExcel_Click()
            Cursor = Cursors.Default

            Exit Sub
        End If
        Cursor = Cursors.Default

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
        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
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
                    entry(0) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Code")
                    entry(1) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Primary Customer")
                    entry(2) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Primary Cust Name")
                    entry(3) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Quotation No")
                    entry(4) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Sequence No")
                    entry(5) = Convert.ToDateTime(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Revised Date")).ToShortDateString
                    entry(6) = Convert.ToDateTime(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Validity Date")).ToShortDateString
                    entry(7) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Item #")
                    entry(8) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Customer Alias No.")
                    entry(9) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Cust Item #")
                    entry(10) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Old Item #")
                    entry(11) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Old VD. Color Code")
                    entry(12) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Item Desc").ToString().Trim()
                    entry(13) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("VD. Color Code")
                    entry(14) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Cust Color Code")
                    entry(15) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Color Desc").ToString().Trim()
                    entry(16) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Inner")
                    entry(17) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Master")
                    entry(18) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("UM")
                    entry(19) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("CFT")
                    entry(20) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Currency")
                    entry(21) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Primary Discounted Price")
                    entry(22) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("PriceTerm")
                    entry(23) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("MOQ")
                    entry(24) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("MOA")
                    entry(25) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Note").ToString().Trim()
                    entry(26) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("HSTU #")
                    entry(27) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Duty")
                    entry(28) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Cust Retail: USD")
                    entry(29) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Cust Retail CAD")
                    entry(30) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Inner Dim - d (in)")
                    entry(31) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Inner Dim - w (in)")
                    entry(32) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Inner Dim - h (in)")
                    entry(33) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Inner Dim - d (cm)")
                    entry(34) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Inner Dim - w (cm)")
                    entry(35) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Inner Dim - h (cm)")
                    entry(36) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Master Dim - d (in)")
                    entry(37) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Master Dim - w (in)")
                    entry(38) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Master Dim - h (in)")
                    entry(39) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Master Dim - d (cm)")
                    entry(40) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Master Dim - w (cm)")
                    entry(41) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Master Dim - h (cm)")
                    entry(42) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("GW")
                    entry(43) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("NW")
                    entry(44) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Const Method")
                    entry(45) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Comp BreakDown")
                    entry(46) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Custom Vendor #")
                    entry(47) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Custom Vendor Short Name")
                    entry(48) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Vendor #")
                    entry(49) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Vendor Short Name")
                    entry(50) = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("Vendor Item #")

                    .Range(.Cells(hdrRow + 1 + i, 1), .Cells(hdrRow + 1 + i, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
                Next
            End With

            ' Configuring XLS Style
            With xlsApp
                .Rows("1:1").Font.Bold = True
                .Rows("1:1").Font.Underline = True
                .Rows("1:1").Font.Size = 10

                .Columns("A:AY").WrapText = False
                .Columns("A:AY").EntireColumn.AutoFit()

                For index As Integer = 1 To entry.Length
                    If .Columns(index).ColumnWidth > 50 Then
                        .Columns(index).ColumnWidth = 50
                    End If
                Next
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    'exportExcel_QURExportToexcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_QUR000011 - Excel Error")
            End If
        End Try

        'Show the excel after creating process is completed
        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        rs_QUR0000excel = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
    End Sub

    Private Sub exportExcel_QURExportToExcel_int()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_QUR0000excel.Tables("RESULT").Rows.Count >= 3000 Then
            MsgBox("There are more than 3000 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Dim sFilter As String
        Dim temp_qud_venno As String

        Cursor = Cursors.WaitCursor


        sFilter = " ( qud_venno >= 'A' and qud_venno <='Z' )  OR   ( qud_venno >= 'a' and qud_venno <='z')  "
        rs_QUR0000excel.Tables("RESULT").DefaultView.RowFilter = sFilter
        rs_QUR0000excel.Tables("RESULT").DefaultView.Sort = "qud_qutseq"
        sFilter = ""

        If rs_QUR0000excel.Tables("RESULT").DefaultView.Count = 0 Then
            Exit Sub
        End If




        xlsApp = New Excel.Application

        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        ''xlsWB = xlsApp.Workbooks.Open("C:\QU_6.xlsx")

        ''xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\QUTemplate\QU_6.xlsx")

        xlsApp.Sheets(1).Activate()

        xlsWS = xlsWB.ActiveSheet

        'For int & ext
        '        temp_qud_venno = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_venno").ToString.Trim

        Try

            With xlsApp
                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 2

                    .Range("A3:BZ3").Copy()

                    .Range("A" + (i + 4).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            With xlsApp
                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 1



                    Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc"))
                    Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")), 1, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr"))


                    Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp"))
                    Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde"))
                    Dim temp_flag_is_ass As Integer

                    Dim test_str As String
                    Dim test_DateTime As Date

                    temp_flag_is_ass = 0

                    If Not IsNumeric(temp_qud_conftr) Then
                        temp_qud_conftr = 1
                    End If

                    ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                    If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                        temp_flag_is_ass = 1
                    End If

                    'New Template     
                    '                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("ibi_catlvl3")

                    '## Either "XMASTREE"


                    tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat"))
                    If tmp_cat = "XMASTREE" Then
                        tmp_cat = "XMAS TREE"
                    End If
                    .Range("A" + (i + 3).ToString).Value = tmp_cat




                    .Range("B" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_imrmk")

                    'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat"))
                    'may need another filed for DTL input date
                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_credat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                    .Range("D" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus1no")
                    .Range("E" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus2no")

                    .Range("G" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_venno")
                    .Range("H" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_vensna")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")) Then
                        ' If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat") <> "" Then

                        test_str = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")
                        test_DateTime = DateTime.Parse(test_str)

                        .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        'Else
                        'End If
                    End If


                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("K" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd")

                    .Range("L" + (i + 3).ToString).NumberFormat = "@"
                    .Range("L" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno")

                    ''assortment #s
                    gspStr = "sp_select_QUASSINF '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_QUASSINF, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading  sp_select_QUASSINF :" & rtnStr)
                        'Exit Sub
                    End If


                    sFilter = ""
                    sFilter = "qai_itmno= '" & .Range("L" + (i + 3).ToString).Value.ToString.Trim & "'"
                    rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter

                    rs_QUASSINF.Tables("RESULT").DefaultView.Sort = "qai_assitm"

                    Dim temp_ass_num As String
                    temp_ass_num = ""


                    For index2 As Integer = 0 To rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1
                        If index2 = rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1 Then
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            End If
                        Else
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            End If
                        End If
                    Next


                    .Range("F" + (i + 3).ToString).Value = temp_ass_num



                    .Range("M" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_colcde")

                    .Range("N" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmdsc")



                    ''
                    If temp_flag_is_ass = 1 Then
                        .Range("I" + (i + 3).ToString).Value = "ST" & temp_qud_conftr.ToString
                    Else
                        .Range("I" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If


                    If temp_flag_is_ass = 1 Then
                        .Range("O" + (i + 3).ToString).Value = "PC"
                    Else
                        .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If

                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                        .Range("P" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                            .Range("P" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty") * temp_qud_conftr
                            Else
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")
                            End If
                        End If
                    End If



                    '.Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mtrqty")
                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                        .Range("Q" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                            .Range("Q" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty") * temp_qud_conftr
                            Else
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")
                            End If
                        End If
                    End If

                    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cft")


                    .Range("S" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")
                    If temp_flag_is_ass = 1 Then
                        .Range("S" + (i + 3).ToString).Value = 1
                    End If
                    '
                    '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")
                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_fcurcde")
                    If .Range("T" + (i + 3).ToString).Value = "" Then
                        .Range("T" + (i + 3).ToString).Value = "USD"
                    End If


                    Dim temp_cur As String
                    temp_cur = .Range("T" + (i + 3).ToString).Value

                    .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA")
                    .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB")
                    .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC")



                    .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD")
                    .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstE")
                    .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran")
                    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack")
                    If temp_flag_is_ass = 1 Then
                        .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA") / temp_qud_conftr
                        .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB") / temp_qud_conftr
                        .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC") / temp_qud_conftr
                        .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD") / temp_qud_conftr
                        .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstE") / temp_qud_conftr
                        .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran") / temp_qud_conftr
                        .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack") / temp_qud_conftr
                    End If

                    If temp_flag_is_ass = 1 Then
                        .Range("AB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycst") / temp_qud_conftr
                    Else
                        .Range("AB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycst")
                    End If


                    Dim temp_ftyprc As Double

                    If temp_flag_is_ass = 1 Then
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")) / temp_qud_conftr
                    Else
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc"))
                    End If

                    Dim temp_FTY_cost As Decimal
                    Dim temp_FTY_mu As Decimal

                    temp_FTY_cost = Val(.Range("AB" + (i + 3).ToString).Value)

                    If IsNumeric(temp_FTY_cost) And IsNumeric(temp_ftyprc) Then
                        If Val(temp_FTY_cost) <> 0 Then

                            'If temp_flag_is_ass = 1 Then
                            '    .Range("AM" + (i + 3).ToString).Value = temp_qud_conftr * Val(temp_ftyprc) / Val(temp_FTY_cost)
                            '    temp_FTY_mu = .Range("AM" + (i + 3).ToString).Value
                            '    .Range("AM" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            'Else
                            .Range("AM" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(temp_FTY_cost)
                            temp_FTY_mu = .Range("AM" + (i + 3).ToString).Value
                            .Range("AM" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            'End If

                        End If
                    End If


                    .Range("AN" + (i + 3).ToString).Value = temp_ftyprc



                    If temp_FTY_cost <> 0 Then
                        '   temp_ftyprc = temp_FTY_cost * temp_FTY_mu
                    Else
                        temp_FTY_mu = 0

                        '.Range("AN" + (i + 3).ToString).Value = temp_ftyprc
                        .Range("AB" + (i + 3).ToString).Value = 0
                    End If


                    Dim temp_basprc As Decimal


                    If temp_flag_is_ass = 1 Then
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")) / temp_qud_conftr
                    Else
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc"))
                    End If




                    'for cal
                    Dim temp_hk_mu As Decimal

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") <> "USD" Then
                            'assuem HKD ,same cur
                        Else
                            If temp_cur = "HKD" And rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") = "USD" Then
                                temp_ftyprc = temp_ftyprc / 7.75
                            End If

                        End If
                    End If

                    If temp_ftyprc <> 0 Then
                        temp_hk_mu = temp_basprc / temp_ftyprc
                    Else
                        temp_hk_mu = 1
                    End If


                    .Range("AO" + (i + 3).ToString).Value = round(temp_hk_mu, 2)


                    'If temp_flag_is_ass = 1 Then
                    '    temp_basprc = temp_basprc / temp_qud_conftr
                    'End If
                    'If temp_flag_is_ass = 1 Then
                    '    .Range("AP" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc") / temp_qud_conftr
                    'Else
                    '    .Range("AP" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")
                    'End If


                    .Range("AC" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_pckitr")
                    .Range("AD" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrdin")
                    .Range("AE" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrwin")
                    .Range("AF" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrhin")
                    .Range("AG" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrdin")
                    .Range("AH" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrwin")
                    .Range("AI" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrhin")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec") <> "" Then
                            .Range("AL" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")
                        Else
                            gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno") & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                            gspStr = ""
                            Cursor = Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                                Exit Sub
                            End If

                            If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                                .Range("AL" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                            Else
                                .Range("AL" + (i + 3).ToString).Value = ""
                            End If

                        End If
                    End If


                    ' .Range("AM" + (i + 3).ToString).Value = "1.18"
                    '.Range("AN" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")
                    ' .Range("AO" + (i + 3).ToString).Value = "1.15"

                    .Range("AQ" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_prctrm")
                    '''TRAN TERM
                    .Range("AR" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_trantrm")

                    'New Template     
                    '                    .Range("AT" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg") <> "Z" Then
                            .Range("AT" + (i + 3).ToString).Value = "N"
                        Else
                            .Range("AT" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                        End If
                    Else
                        .Range("AT" + (i + 3).ToString).Value = "N"
                    End If


                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_subttlper")) Then
                    '    .Range("AU" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_subttlper") / 100
                    'Else
                    '    .Range("AU" + (i + 3).ToString).Value = "0"
                    'End If



                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")) Then
                        .Range("AV" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AV" + (i + 3).ToString).Value = .Range("AV" + (i + 3).ToString).Value / temp_qud_conftr
                        End If

                    Else
                        .Range("AV" + (i + 3).ToString).Value = "0"
                    End If

                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_comper")) Then
                    '    .Range("AW" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_comper") / 100
                    'Else
                    '    .Range("AW" + (i + 3).ToString).Value = "0"
                    'End If


                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")) Then
                        .Range("AX" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AX" + (i + 3).ToString).Value = .Range("AX" + (i + 3).ToString).Value / temp_qud_conftr
                        End If
                    Else
                        .Range("AX" + (i + 3).ToString).Value = 0

                    End If


                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_cushcstbufper")) Then
                    '    .Range("BA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_cushcstbufper") / 100
                    'Else
                    '    .Range("BA" + (i + 3).ToString).Value = "0"
                    'End If

                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_othdisper")) Then
                    '    .Range("BB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_othdisper") / 100
                    'Else
                    '    .Range("BB" + (i + 3).ToString).Value = "0"
                    'End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu")) Then
                        .Range("BE" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu") / 100
                    Else
                        .Range("BE" + (i + 3).ToString).Value = "0"
                    End If

                    .Range("BG" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_ftyshpstr")
                    .Range("BH" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_ftyshpend")

                    '''special handle
                    If DateDiff("d", .Range("BG" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '.Range("BG" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BG" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BH" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '                        .Range("BH" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BH" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BG" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '.Range("BG" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BG" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BH" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '                        .Range("BH" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BH" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BG" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '.Range("BG" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BG" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BH" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '                        .Range("BH" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BH" + (i + 3).ToString).Value = ""
                    End If

                    '''20140224
                    .Range("BI" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cushpstr")
                    .Range("BJ" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cushpend")

                    '''special handle
                    If DateDiff("d", .Range("BI" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '.Range("BI" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BI" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BJ" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '                        .Range("BJ" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BJ" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BI" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '.Range("BI" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BI" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BJ" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '                        .Range("BJ" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BJ" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BI" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '.Range("BI" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BI" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BJ" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '                        .Range("BJ" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BJ" + (i + 3).ToString).Value = ""
                    End If




                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_toqty")) Then
                        .Range("BK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_toqty")
                    Else
                        .Range("BK" + (i + 3).ToString).Value = "0"
                    End If

                    .Range("BL" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_toshipport")
                    .Range("BM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_tormk")

                    '.Range(.Cells(hdrRow + 1 + i, 1), .Cells(hdrRow + 1 + i, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
                Next



                'Mark Up Table Sheet

                gspStr = "sp_select_QUPRCEMT_MU '" & .Range("D3").Value.ToString.Trim & "','INT'"
                Message = "sp_select_QUPRCEMT_MU"
                rtnLong = execute_SQLStatement(gspStr, rs_QUPRCEMT_MU, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdShow_Click " & Message & " :" & rtnStr)
                    Exit Sub
                End If

                If rs_QUPRCEMT_MU.Tables("result").Rows.Count > 0 Then

                    'MarkUp Page
                    .Sheets(2).Activate()

                    For i As Integer = 0 To rs_QUPRCEMT_MU.Tables("result").Rows.Count - 1




                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("D17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                     .Range("D19").Value = .Range("D17").Value + .Range("D18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("E17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                      .Range("E19").Value = .Range("D17").Value + .Range("E18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("F17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                       .Range("F19").Value = .Range("D17").Value + .Range("F18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("G17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                        .Range("G19").Value = .Range("D17").Value + .Range("G18").Value
                        End If

                        '2
                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("I17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                         .Range("I19").Value = .Range("I17").Value + .Range("I18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("J17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                          .Range("J19").Value = .Range("I17").Value + .Range("J18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("K17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                           .Range("K19").Value = .Range("I17").Value + .Range("K18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("L17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                            .Range("L19").Value = .Range("I17").Value + .Range("L18").Value
                        End If

                        'CAT, Same Value

                        If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" Then

                            .Range("D4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("D5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("D6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("D8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("D9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("D10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("D11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("D13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("D14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("D15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("D20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("D22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If

                        '2
                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") Then

                            .Range("I4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("I5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("I6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("I8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("I9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("I10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("I11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("I13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("I14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("I15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("I20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("I22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If

                    Next

                Else
                    'no markup price
                End If



            End With

            'Remark
            'With xlsApp
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 3, 1)).Value = "Remarks:"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 1)).Value = "1)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 1)).Value = "2)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 1)).Value = "3)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 1)).Value = "4)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 1)).Value = "5)"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 4, 4)).Value = "Added Column G ""Original UM""   "
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 5, 4)).Value = "For assortment item, generate information in UM PC with Inner, master multiple with conversion factor and price with divided by conversion factor"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 6, 4)).Value = "For assortment item, information in UM ST will not be generated"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 7, 4)).Value = "For regular item with multiple UM, display as row 4 with multiple UM"
            '    .Range(.Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4), .Cells(rs_QUR0000excel.Tables("RESULT").Rows.Count + 8, 4)).Value = "Column AO ""Vendor Location"" change to ""Vendor covers all transportation cost"", with Y/N flag.  Default ""N""  "
            'End With

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
                    exportExcel_QURExportToExcel_int()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_QUR000011 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try

            Dim Yourpath As String
            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
            Else
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_int", FileFormat:=52)
            End If

        Catch ex As Exception
            MsgBox("File " + "C:\" + txtFromQuotNo.Text + "_int" + ".xls already exist. Please delete it before export a new one.")
        End Try

        ' xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, ReadOnlyRecommended:=False)

        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        ' rs_QUR0000excel = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
    End Sub


    Private Sub exportExcel_QURExportToExcel_ext()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim Message As String
        Dim tmp_cat As String

        If rs_QUR0000excel.Tables("RESULT").Rows.Count >= 3000 Then
            MsgBox("There are more than 3000 records!")
            rs_QUR0000excel = Nothing
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Dim sFilter As String
        Dim temp_qud_venno As String

        Cursor = Cursors.WaitCursor

        ''' not
        sFilter = " not (( qud_venno >= 'A' and qud_venno <='Z' )  OR   ( qud_venno >= 'a' and qud_venno <='z')  )"
        rs_QUR0000excel.Tables("RESULT").DefaultView.RowFilter = sFilter
        rs_QUR0000excel.Tables("RESULT").DefaultView.Sort = "qud_qutseq"
        sFilter = ""

        If rs_QUR0000excel.Tables("RESULT").DefaultView.Count = 0 Then
            Exit Sub
        End If




        xlsApp = New Excel.Application

        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        '
        'xlsWB = xlsApp.Workbooks.Open("C:\QU_8.xlsx")
        'xlsWB = xlsApp.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\QUTemplate\QU_8.xlsx")

        xlsApp.Sheets(1).Activate()

        xlsWS = xlsWB.ActiveSheet

        'For int & ext
        '        temp_qud_venno = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_venno").ToString.Trim

        Try



            With xlsApp
                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 2
                    .Range("A3:BZ3").Copy()

                    .Range("A" + (i + 4).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            With xlsApp
                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 1



                    Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc"))
                    Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")), 1, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr"))


                    Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp"))
                    Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde"))
                    Dim temp_flag_is_ass As Integer

                    Dim test_str As String
                    Dim test_DateTime As Date

                    temp_flag_is_ass = 0

                    If Not IsNumeric(temp_qud_conftr) Then
                        temp_qud_conftr = 1
                    End If

                    ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                    If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                        temp_flag_is_ass = 1
                    End If

                    'New Template     
                    '                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("ibi_catlvl3")

                    '## Either "XMASTREE"


                    tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat"))
                    If tmp_cat = "XMASTREE" Then
                        tmp_cat = "XMAS TREE"
                    End If
                    .Range("A" + (i + 3).ToString).Value = tmp_cat




                    .Range("B" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_imrmk")

                    'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat"))
                    'may need another filed for DTL input date
                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_credat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                    .Range("D" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus1no")
                    .Range("E" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus2no")

                    .Range("G" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_venno")
                    .Range("H" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_vensna")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")) Then
                        ' If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat") <> "" Then

                        test_str = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")
                        test_DateTime = DateTime.Parse(test_str)

                        .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        'Else
                        'End If
                    End If


                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("K" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd")

                    .Range("L" + (i + 3).ToString).NumberFormat = "@"
                    .Range("L" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno")

                    ''assortment #s
                    rs_QUASSINF.Tables.Clear()

                    gspStr = "sp_select_QUASSINF '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_QUASSINF, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading  sp_select_QUASSINF :" & rtnStr)
                        'Exit Sub
                    End If


                    sFilter = ""
                    sFilter = "qai_itmno= '" & .Range("L" + (i + 3).ToString).Value.ToString.Trim & "'"
                    rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter

                    rs_QUASSINF.Tables("RESULT").DefaultView.Sort = "qai_assitm"

                    Dim temp_ass_num As String
                    temp_ass_num = ""

                    For index2 As Integer = 0 To rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1
                        If index2 = rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1 Then
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            End If
                        Else
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            End If
                        End If
                    Next


                    .Range("F" + (i + 3).ToString).Value = temp_ass_num




                    .Range("M" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_colcde")

                    .Range("N" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmdsc")



                    ''
                    If temp_flag_is_ass = 1 Then
                        .Range("I" + (i + 3).ToString).Value = "ST" & temp_qud_conftr.ToString
                    Else
                        .Range("I" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If


                    If temp_flag_is_ass = 1 Then
                        .Range("O" + (i + 3).ToString).Value = "PC"
                    Else
                        .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If

                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                        .Range("P" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                            .Range("P" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty") * temp_qud_conftr
                            Else
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")
                            End If
                        End If
                    End If



                    '.Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mtrqty")
                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                        .Range("Q" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                            .Range("Q" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty") * temp_qud_conftr
                            Else
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")
                            End If
                        End If
                    End If

                    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cft")


                    .Range("S" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")
                    If temp_flag_is_ass = 1 Then
                        .Range("S" + (i + 3).ToString).Value = 1
                    End If
                    '
                    '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")
                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fcurcde")
                    If .Range("T" + (i + 3).ToString).Value = "" Then
                        .Range("T" + (i + 3).ToString).Value = "USD"
                    End If


                    Dim temp_cur As String
                    temp_cur = .Range("T" + (i + 3).ToString).Value

                    .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA")
                    .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB")
                    .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC")

                    .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD")
                    .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstE")
                    .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran")
                    .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack")
                    If temp_flag_is_ass = 1 Then
                        .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA") / temp_qud_conftr
                        .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB") / temp_qud_conftr
                        .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC") / temp_qud_conftr
                        .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD") / temp_qud_conftr
                        .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstE") / temp_qud_conftr
                        .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran") / temp_qud_conftr
                        .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack") / temp_qud_conftr
                    End If

                    If temp_flag_is_ass = 1 Then
                        .Range("AB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycst") / temp_qud_conftr
                    Else
                        .Range("AB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycst")
                    End If


                    Dim temp_ftyprc As Double

                    If temp_flag_is_ass = 1 Then
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")) / temp_qud_conftr
                    Else
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc"))
                    End If

                    Dim temp_FTY_cost As Decimal
                    Dim temp_FTY_mu As Decimal

                    temp_FTY_cost = Val(.Range("AB" + (i + 3).ToString).Value)

                    If IsNumeric(temp_FTY_cost) And IsNumeric(temp_ftyprc) Then
                        If Val(temp_FTY_cost) <> 0 Then

                            'If temp_flag_is_ass = 1 Then
                            '    .Range("AM" + (i + 3).ToString).Value = temp_qud_conftr * Val(temp_ftyprc) / Val(temp_FTY_cost)
                            '    temp_FTY_mu = .Range("AM" + (i + 3).ToString).Value
                            '    .Range("AM" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            'Else
                            .Range("AM" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(temp_FTY_cost)
                            temp_FTY_mu = .Range("AM" + (i + 3).ToString).Value
                            .Range("AM" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            'End If

                        End If
                    End If


                    .Range("AN" + (i + 3).ToString).Value = temp_ftyprc



                    If temp_FTY_cost <> 0 Then
                        '   temp_ftyprc = temp_FTY_cost * temp_FTY_mu
                    Else
                        temp_FTY_mu = 0

                        '.Range("AN" + (i + 3).ToString).Value = temp_ftyprc
                        .Range("AB" + (i + 3).ToString).Value = 0
                    End If


                    Dim temp_basprc As Decimal


                    If temp_flag_is_ass = 1 Then
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")) / temp_qud_conftr
                    Else
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc"))
                    End If




                    'for cal
                    Dim temp_hk_mu As Decimal

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") <> "USD" Then
                            'assuem HKD ,same cur
                        Else
                            If temp_cur = "HKD" And rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") = "USD" Then
                                temp_ftyprc = temp_ftyprc / 7.75
                            End If

                        End If
                    End If

                    If temp_ftyprc <> 0 Then
                        temp_hk_mu = temp_basprc / temp_ftyprc
                    Else
                        temp_hk_mu = 1
                    End If


                    .Range("AO" + (i + 3).ToString).Value = round(temp_hk_mu, 2)


                    'If temp_flag_is_ass = 1 Then
                    '    temp_basprc = temp_basprc / temp_qud_conftr
                    'End If
                    'If temp_flag_is_ass = 1 Then
                    '    .Range("AP" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc") / temp_qud_conftr
                    'Else
                    '    .Range("AP" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")
                    'End If


                    .Range("AC" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_pckitr")
                    .Range("AD" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrdin")
                    .Range("AE" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrwin")
                    .Range("AF" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrhin")
                    .Range("AG" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrdin")
                    .Range("AH" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrwin")
                    .Range("AI" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrhin")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec") <> "" Then
                            .Range("AL" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")
                        Else
                            gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno") & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                            gspStr = ""
                            Cursor = Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                                Exit Sub
                            End If

                            If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                                .Range("AL" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                            Else
                                .Range("AL" + (i + 3).ToString).Value = ""
                            End If

                        End If
                    End If


                    ' .Range("AM" + (i + 3).ToString).Value = "1.18"
                    '.Range("AN" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")
                    ' .Range("AO" + (i + 3).ToString).Value = "1.15"

                    .Range("AQ" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_prctrm")
                    '''TRAN TERM
                    .Range("AR" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_trantrm")

                    'New Template     
                    '                    .Range("AT" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg") <> "Z" Then
                            .Range("AT" + (i + 3).ToString).Value = "N"
                        Else
                            .Range("AT" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                        End If
                    Else
                        .Range("AT" + (i + 3).ToString).Value = "N"
                    End If


                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_subttlper")) Then
                    '    .Range("AU" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_subttlper") / 100
                    'Else
                    '    .Range("AU" + (i + 3).ToString).Value = "0"
                    'End If



                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")) Then
                        .Range("AV" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AV" + (i + 3).ToString).Value = .Range("AV" + (i + 3).ToString).Value / temp_qud_conftr
                        End If

                    Else
                        .Range("AV" + (i + 3).ToString).Value = "0"
                    End If

                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_comper")) Then
                    '    .Range("AW" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_comper") / 100
                    'Else
                    '    .Range("AW" + (i + 3).ToString).Value = "0"
                    'End If


                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")) Then
                        .Range("AX" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AX" + (i + 3).ToString).Value = .Range("AX" + (i + 3).ToString).Value / temp_qud_conftr
                        End If
                    Else
                        .Range("AX" + (i + 3).ToString).Value = 0

                    End If


                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_cushcstbufper")) Then
                    '    .Range("BA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_cushcstbufper") / 100
                    'Else
                    '    .Range("BA" + (i + 3).ToString).Value = "0"
                    'End If

                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_othdisper")) Then
                    '    .Range("BB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_othdisper") / 100
                    'Else
                    '    .Range("BB" + (i + 3).ToString).Value = "0"
                    'End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu")) Then
                        .Range("BE" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu") / 100
                    Else
                        .Range("BE" + (i + 3).ToString).Value = "0"
                    End If

                    .Range("BG" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_ftyshpstr")
                    .Range("BH" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_ftyshpend")

                    '''special handle
                    If DateDiff("d", .Range("BG" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '.Range("BG" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BG" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BH" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '                        .Range("BH" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BH" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BG" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '.Range("BG" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BG" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BH" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '                        .Range("BH" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BH" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BG" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '.Range("BG" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BG" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BH" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '                        .Range("BH" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BH" + (i + 3).ToString).Value = ""
                    End If

                    '''20140224
                    .Range("BI" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cushpstr")
                    .Range("BJ" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cushpend")

                    '''special handle
                    If DateDiff("d", .Range("BI" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '.Range("BI" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BI" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BJ" + (i + 3).ToString).Value, "01/01/1900") = 0 Then
                        '                        .Range("BJ" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BJ" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BI" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '.Range("BI" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BI" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BJ" + (i + 3).ToString).Value, "11/19/2000") = 0 Then
                        '                        .Range("BJ" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BJ" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BI" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '.Range("BI" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BI" + (i + 3).ToString).Value = ""
                    End If
                    If DateDiff("d", .Range("BJ" + (i + 3).ToString).Value, "11/19/00") = 0 Then
                        '                        .Range("BJ" + (i + 3).ToString).Value = "01/01/1900"
                        .Range("BJ" + (i + 3).ToString).Value = ""
                    End If




                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_toqty")) Then
                        .Range("BK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_toqty")
                    Else
                        .Range("BK" + (i + 3).ToString).Value = "0"
                    End If

                    .Range("BL" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_toshipport")
                    .Range("BM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_tormk")

                    '.Range(.Cells(hdrRow + 1 + i, 1), .Cells(hdrRow + 1 + i, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
                Next



                'Mark Up Table Sheet


                gspStr = "sp_select_QUPRCEMT_MU '" & .Range("D3").Value.ToString.Trim & "','EXT'"
                Message = "sp_select_QUPRCEMT_MU"
                rtnLong = execute_SQLStatement(gspStr, rs_QUPRCEMT_MU, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdShow_Click " & Message & " :" & rtnStr)
                    Exit Sub
                End If

                If rs_QUPRCEMT_MU.Tables("result").Rows.Count > 0 Then

                    'MarkUp Page
                    .Sheets(2).Activate()

                    For i As Integer = 0 To rs_QUPRCEMT_MU.Tables("result").Rows.Count - 1


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("D17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                     .Range("D19").Value = .Range("D17").Value + .Range("D18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("E17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                      .Range("E19").Value = .Range("D17").Value + .Range("E18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("F17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                       .Range("F19").Value = .Range("D17").Value + .Range("F18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("G17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                        .Range("G19").Value = .Range("D17").Value + .Range("G18").Value
                        End If

                        '2FLORAL FTY			

                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("I17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                         .Range("I19").Value = .Range("I17").Value + .Range("I18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("J17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                          .Range("J19").Value = .Range("I17").Value + .Range("J18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("K17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                           .Range("K19").Value = .Range("I17").Value + .Range("K18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("L17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                            .Range("L19").Value = .Range("I17").Value + .Range("L18").Value
                        End If

                        '''3MAGICSILK			
                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("N17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                         .Range("I19").Value = .Range("I17").Value + .Range("I18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("O17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                          .Range("J19").Value = .Range("I17").Value + .Range("J18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("P17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                           .Range("K19").Value = .Range("I17").Value + .Range("K18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("Q17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                            .Range("L19").Value = .Range("I17").Value + .Range("L18").Value
                        End If


                        '''''''''''''''''''''''''''''''''''
                        'CAT, Same Value

                        If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" Then

                            .Range("D4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")

                            ''2 margin value
                            If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm") = "FCL" Then
                                .Range("D5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")
                            End If
                            If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm") = "LCL" Then
                                .Range("F5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")
                            End If

                            .Range("D6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("D8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("D9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("D10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("D11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("D13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("D14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("D15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("D20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("D22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If

                        '2
                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") Then

                            .Range("I4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("I5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("I6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("I8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("I9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("I10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("I11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("I13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("I14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("I15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("I20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("I22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If


                        '3

                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") Then

                            .Range("N4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("N5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("N6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("N8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("N9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("N10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("N11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("N13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("N14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("N15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("N20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("N22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If


                    Next

                Else
                    'no markup price
                End If



            End With


            With xlsApp

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    exportExcel_QURExportToExcel_ext()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_QUR00003 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            Dim Yourpath As String
            Yourpath = "C:\" & saveto_folder.Text
            If (Not System.IO.Directory.Exists(Yourpath)) Then
                System.IO.Directory.CreateDirectory(Yourpath)
            End If

            If saveto_folder.Text.Trim = "" Then
                xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text + "_ext", FileFormat:=52)
            Else
                xlsWB.SaveAs(Filename:="C:\" + saveto_folder.Text.Trim + "\" + txtFromQuotNo.Text + "_ext", FileFormat:=52)
            End If


        Catch ex As Exception
            MsgBox("File " + "C:\" + txtFromQuotNo.Text + "_ext" + ".xls already exist. Please delete it before export a new one.")
        End Try

        ' xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, ReadOnlyRecommended:=False)

        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        rs_QUR0000excel = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
    End Sub


    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

        If Value = 0 Then S = "0"
        If Value = 1 Then S = "0.0"
        If Value = 2 Then S = "0.00"
        If Value = 3 Then S = "0.000"
        If Value = 4 Then S = "0.0000"
        If Value = 5 Then S = "0.00000"
        If Value = 6 Then S = "0.000000"
        If Value = 7 Then S = "0.0000000"
        If Value = 8 Then S = "0.00000000"
        If Value = 9 Then S = "0.000000000"
        If Value = 10 Then S = "0.0000000000"

        round = CDbl(Format(a, S))
    End Function


    Private Sub saveto_folder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveto_folder.TextChanged

    End Sub
End Class
