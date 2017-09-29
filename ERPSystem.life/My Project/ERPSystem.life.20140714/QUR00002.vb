Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource

Public Class QUR00002

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

        If rs_QUR00001Status.Tables("RESULT").Rows.Count > 0 Then
            Cursor = Cursors.Default
            MsgBox("At least one of Quotations is not in 'Active' status, so it can't print Quotation.")
            Exit Sub
        End If

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

        'S = "㊣QUR0000excel※S※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text & "※" & sorting & "※" & gsUsrID & "※" & strModule
        'gspStr = "sp_select_QUR0000excel '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & sorting & "','" & gsUsrID & "','" & strModule & "'"
        gspStr = "sp_select_QURExporttoExcel '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtFromQuotNo.Text & "','" & sorting & "'"
        message = "sp_select_QURExporttoExcel"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        rtnLong = execute_SQLStatement(gspStr, rs_QUR0000excel, rtnStr)
        
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdShow_Click " & message & " :" & rtnStr)
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

            'Call exportExcel_QUR0000excel()
            Call exportExcel_QURExportToExcel()

            'ReDim ReportName(0) As String
            'ReDim ReportRS(0) As ADOR.Recordset
            '   ReportName(0) = "QUR0000excel.rpt"
            '   ReportRS(0) = rs_QUR0000excel

            'Call CmdExportExcel_Click()
            Exit Sub
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
                    exportExcel_QURExportToexcel()
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

    Private Sub exportExcel_QURExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        If rs_QUR0000excel.Tables("RESULT").Rows.Count >= 100 Then
            MsgBox("There are more than 100 records!")
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

        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\QUTemplate\QU_6.xls")

        xlsWS = xlsWB.ActiveSheet


        Dim entry(60) As Object

        Try

            '            With xlsApp
            '    entry(0) = ""
            '    entry(1) = ""
            '    entry(2) = ""
            '    entry(3) = ""
            '    entry(4) = ""
            '    entry(5) = ""
            '    entry(6) = ""
            '    entry(7) = ""
            '    entry(8) = ""
            '    entry(9) = ""
            '    entry(10) = ""
            '    entry(11) = ""
            '    entry(12) = ""
            '    entry(13) = "A"
            '    entry(14) = ""
            '    entry(15) = "B"
            '    entry(16) = ""
            '    entry(17) = ""
            '    entry(18) = "C"
            '    entry(19) = "D"
            '    entry(20) = "E"
            '    entry(21) = "F"
            '    entry(22) = "G=(B/(1-C)+ D)/(1-E)+F"
            '    entry(23) = "H"
            '    entry(24) = "J"
            '    entry(25) = "K = H+J"
            '    entry(26) = "L"
            '    entry(27) = " M=(B/(1-L)+D)/(1-E)+ F "

            '    .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
            'End With


            ''Initializing Header Row'
            'With xlsApp
            '    entry(0) = "Pri Cust"
            '    entry(1) = "Org. UM"
            '    entry(2) = "Period (YYYY-MM)"
            '    entry(3) = "Item No."
            '    entry(4) = "Description"
            '    entry(5) = "UM"
            '    entry(6) = "Inner"
            '    entry(7) = "Master"
            '    entry(8) = "CFT"
            '    entry(9) = "Conversion Factor To PCs"
            '    entry(10) = "CCY"
            '    entry(11) = "FTY Cost (Total)"
            '    entry(12) = "FTY MU"
            '    entry(13) = "FTY Price"
            '    entry(14) = "HK MU"
            '    entry(15) = "Basic Price (USD)"
            '    entry(16) = "Price Term"
            '    entry(17) = "Vendor covers all transportation cost (Y/N)"
            '    entry(18) = "Markup %"
            '    entry(19) = "Packaging Cost"
            '    entry(20) = "Commission"
            '    entry(21) = "Item Comm Amt"
            '    entry(22) = "Standard Price (USD)"
            '    entry(23) = "Cushion & Costing Buffer"
            '    entry(24) = "Other Discount Limit"
            '    entry(25) = "Max. Discount Limit"
            '    entry(26) = "Adjusted Markup"
            '    entry(27) = " Adjusted Price (USD) "


            '    .Range(.Cells(hdrRow + 1, 1), .Cells(hdrRow + 1, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
            'End With

            'Copy  Data
            With xlsApp
                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").Rows.Count - 2
                    .Range("A2:BA2").Copy()

                    .Range("A" + (i + 3).ToString).Select()
                    xlsWS.Paste()


                Next

                .Range("A88:A88").Copy()

            End With


            With xlsApp
                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").Rows.Count - 1

                    Dim temp_qud_contopc = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_contopc")
                    Dim temp_qud_conftr = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr")
                    Dim temp_qud_itmtyp = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmtyp")
                    Dim temp_qud_um = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")
                    Dim temp_flag_is_ass As Integer
                    temp_flag_is_ass = 0

                    If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                        temp_flag_is_ass = 1
                    End If

                    .Range("A" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("ibi_catlvl3")
                    .Range("D" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("quh_cus1no")
                    .Range("G" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")

                    Dim test_str As String
                    Dim test_DateTime As Date

                    test_str = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_qutdat")
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("H" + (i + 2).ToString).Value = Mid(test_DateTime.ToString("yyyy-MM-dd"), 1, 7)

                    .Range("J" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmno")
                    .Range("K" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_itmdsc")
                    .Range("L" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_untcde")
                    .Range("M" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_inrqty")
                    .Range("N" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_mtrqty")

                    If temp_flag_is_ass = 1 Then
                        .Range("O" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                    Else
                        .Range("O" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                    End If

                    .Range("P" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_conftr")
                    .Range("Q" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_curcde")

                    If temp_flag_is_ass = 1 Then
                        .Range("X" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_ftycst") / temp_qud_conftr
                    Else
                        .Range("X" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_ftycst")
                    End If

                    .Range("AI" + (i + 2).ToString).Value = "1.18"
                    '.Range("AJ" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ftyprc")
                    .Range("AK" + (i + 2).ToString).Value = "1.15"

                    .Range("AM" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_prctrm")
                    .Range("AO" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_ventran")
                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_subttlper")) Then
                        .Range("AP" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_subttlper") / 100
                    Else
                        .Range("AP" + (i + 2).ToString).Value = "0"
                    End If


                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_pkgper")) Then
                        .Range("AQ" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_pkgper") / 100
                    Else
                        .Range("AQ" + (i + 2).ToString).Value = "0"
                    End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_comper")) Then
                        .Range("AR" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_comper") / 100
                    Else
                        .Range("AR" + (i + 2).ToString).Value = "0"
                    End If

                    .Range("AS" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_icmper")

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_cushcstbufper")) Then
                        .Range("AV" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_cushcstbufper") / 100
                    Else
                        .Range("AV" + (i + 2).ToString).Value = "0"
                    End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_othdisper")) Then
                        .Range("AW" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_othdisper") / 100
                    Else
                        .Range("AW" + (i + 2).ToString).Value = "0"
                    End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_mu")) Then
                        .Range("AZ" + (i + 2).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_mu") / 100
                    Else
                        .Range("AZ" + (i + 2).ToString).Value = "0"
                    End If
 
                    '.Range(.Cells(hdrRow + 1 + i, 1), .Cells(hdrRow + 1 + i, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
                Next
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
                    exportExcel_QURExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_QUR000011 - Excel Error")
            End If
        End Try

        'Show the excel after creating process is completed
        Try
            xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text)

        Catch ex As Exception
            MsgBox("File " + "C:\" + txtFromQuotNo.Text + ".xls already exist. Please delete it before export a new one.")
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
End Class