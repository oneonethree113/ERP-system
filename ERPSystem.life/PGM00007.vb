Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource

Public Class PGM00007
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim rs_PGMExcel As DataSet
    Dim rs_EXCEL As DataSet
    Dim rs_check As DataSet
    Dim rs_DISPRM As DataSet
    Public company As String

    Const imgMaxHeight As Integer = 847 '907 '840
    Const imgMaxWidth As Integer = 650 '680 '630

    Private Sub PGM00007_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Sartup position
        Cursor = Cursors.Default

        'txt_S_PKGNo.MaxLength = 20


        If GetDefaultCompany_Local() = "UCPP" Then
            'Opt_yes.Enabled = False
            'Opt_no.Checked = True
            'optPrintVenN.Checked = True
        End If

        Combo1.Items.Add("Export to Standard Report")
        Combo1.Items.Add("Export to Supplmentory Excel Sheet")
        '  Combo1.Items.Add("Export to Excel Sheet(By Vendor)")
        Combo1.SelectedIndex = 0

        If company <> "" Then
            cboCoCde.Text = company
        End If

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

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        Dim AscDesc As String

        If txt_S_PKGNo.Text = "" Then
            MsgBox("Please input Packaging Order No.", vbCritical, "Warning")
            txt_S_PKGNo.SelectAll()
            Exit Sub
        End If

        'S = "㊣QUR00001Status※S※" & txtFromQuotNo.Text & "※" & txtToQuotNo.Text
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        'gspStr = "sp_select_QUR00001Status '" & gsCompany & "','" & txtFromQuotNo.Text & "','" & txtFromQuotNo.Text & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_QUR00001Status, rtnStr)
        'gspStr = ""

        Cursor = Cursors.Default

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading cmdShow_Click sp_select_QUR00001Status :" & rtnStr)
        '    Exit Sub
        'End If

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
        Dim rs As New ADODB.Recordset
        If Combo1.SelectedIndex = 0 Then
            gspStr = "sp_select_PGM00007 '" & gsCompany & "','" & txt_S_PKGNo.Text & "'"
            message = "SP_SELECT_PGM00007_EXCEL"
            rtnLong = execute_SQLStatement(gspStr, rs_PGMExcel, rtnStr)

            gspStr = "sp_select_PGM00007_disprm '" & gsCompany & "','" & txt_S_PKGNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_DISPRM, rtnStr)


        Else
            gspStr = "sp_select_PGM00007_excel '" & gsCompany & "','" & txt_S_PKGNo.Text & "'"
            message = "SP_SELECT_PGM00007_EXCEL"
            rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
        End If


        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SP_SELECT_PGM00007_EXCEL " & message & " :" & rtnStr)
            Exit Sub
        End If


        If Combo1.SelectedIndex = 1 Then

            If rs_EXCEL.Tables("RESULT").Rows.Count <> 0 Then
                If rs_EXCEL.Tables("RESULT").Rows(0).Item("Pkg No") = "XXX" Then
                    MsgBox(rs_EXCEL.Tables("RESULT").Rows(0).Item("message"))
                    Exit Sub
                End If
            End If

            Call ExportToExcel()
            Exit Sub
        End If


        If rs_PGMExcel.Tables("RESULT").Rows.Count = 0 Then


            gspStr = "sp_select_PGM00007_check '" & gsCompany & "','" & txt_S_PKGNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
            If rs_check IsNot Nothing Then
                If rs_check.Tables("RESULT").Rows.Count <> 0 Then
                    MsgBox("Order not in Approved Status , Please Check.")
                    Exit Sub
                Else
                    MsgBox("No Record Found!")
                    Exit Sub
                End If

            Else
                MsgBox("Order not in Approved Status , Please Check.")
                Exit Sub
            End If


        Else

            If rs_PGMExcel.Tables("RESULT").Rows(0).Item("yco_conam") = "XXX" Then
                MsgBox(rs_PGMExcel.Tables("RESULT").Rows(0).Item("message"))
                Exit Sub
            End If


            If rs_PGMExcel.Tables("RESULT").Rows.Count > 30000 Then
                Dim answer As String = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                If answer = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If


            Dim colCompLogo, colItm As DataColumn
            Dim compLogo, itm As Byte()

            colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
            rs_PGMExcel.Tables("RESULT").Columns.Add(colCompLogo)
            rs_PGMExcel.Tables("RESULT").Columns("compLogo").ReadOnly = False

            colItm = New DataColumn("itm", System.Type.GetType("System.Byte[]"))
            rs_PGMExcel.Tables("RESULT").Columns.Add(colItm)
            rs_PGMExcel.Tables("RESULT").Columns("itm").ReadOnly = False

            For i As Integer = 0 To rs_PGMExcel.Tables("RESULT").Rows.Count - 1
                compLogo = imageToByteArray(rs_PGMExcel.Tables("RESULT").Rows(i)("yco_logoimgpth"))
                rs_PGMExcel.Tables("RESULT").Rows(i)("compLogo") = compLogo

                ' Check if the image exists or not
                If System.IO.File.Exists(rs_PGMExcel.Tables("RESULT").Rows(i)("pib_img").ToString) = False Then
                    rs_PGMExcel.Tables("RESULT").Columns("pib_img").ReadOnly = False
                    'rs_PGMExcel.Tables("RESULT").Rows(i)("pib_img") = ""
                    rs_PGMExcel.Tables("RESULT").Rows(i)("pib_img") = "\\Uchkimgsrv\Pkgimg\Blank.jpg"
                    rs_PGMExcel.Tables("RESULT").Columns("pib_img").ReadOnly = True
                End If

                itm = resizeImageToByteArray(rs_PGMExcel.Tables("RESULT").Rows(i)("pib_img"))
                rs_PGMExcel.Tables("RESULT").Rows(i)("itm") = itm
            Next

            rs_PGMExcel.Tables("RESULT").Columns("compLogo").ReadOnly = True
            rs_PGMExcel.Tables("RESULT").Columns("itm").ReadOnly = True

            rs_PGMExcel.Tables("RESULT").Columns("pod_clrfot").ReadOnly = False
            rs_PGMExcel.Tables("RESULT").Columns("pod_clrbck").ReadOnly = False
            rs_PGMExcel.Tables("RESULT").Columns("pod_matral").ReadOnly = False
            rs_PGMExcel.Tables("RESULT").Columns("pod_prtmtd").ReadOnly = False
            rs_PGMExcel.Tables("RESULT").Columns("pod_tiknes").ReadOnly = False
            rs_PGMExcel.Tables("RESULT").Columns("REVISED").ReadOnly = False

            For i As Integer = 0 To rs_PGMExcel.Tables("RESULT").Rows.Count - 1
                For x As Integer = 0 To rs_PGMExcel.Tables("RESULT").Columns.Count - 1
                    If rs_PGMExcel.Tables("RESULT").Columns(x).ToString = "pod_clrfot" Then

                        If Not rs_PGMExcel.Tables("RESULT").Rows(i).Item(x).ToString = "" Then
                            rs_PGMExcel.Tables("RESULT").Rows(i).Item(x) = Split(rs_PGMExcel.Tables("RESULT").Rows(i).Item(x), " - ")(1)
                        End If
                    End If

                    If rs_PGMExcel.Tables("RESULT").Columns(x).ToString = "pod_clrbck" Then

                        If Not rs_PGMExcel.Tables("RESULT").Rows(i).Item(x).ToString = "" Then
                            rs_PGMExcel.Tables("RESULT").Rows(i).Item(x) = Split(rs_PGMExcel.Tables("RESULT").Rows(i).Item(x), " - ")(1)
                        End If
                    End If

                    If rs_PGMExcel.Tables("RESULT").Columns(x).ToString = "pod_matral" Then

                        If Not rs_PGMExcel.Tables("RESULT").Rows(i).Item(x).ToString = "" Then
                            rs_PGMExcel.Tables("RESULT").Rows(i).Item(x) = Split(rs_PGMExcel.Tables("RESULT").Rows(i).Item(x), " - ")(1)
                        End If
                    End If

                    If rs_PGMExcel.Tables("RESULT").Columns(x).ToString = "pod_prtmtd" Then

                        If Not rs_PGMExcel.Tables("RESULT").Rows(i).Item(x).ToString = "" Then
                            rs_PGMExcel.Tables("RESULT").Rows(i).Item(x) = Split(rs_PGMExcel.Tables("RESULT").Rows(i).Item(x), " - ")(1)
                        End If
                    End If


                    If rs_PGMExcel.Tables("RESULT").Columns(x).ToString = "pod_tiknes" Then

                        If Not rs_PGMExcel.Tables("RESULT").Rows(i).Item(x).ToString = "" Then
                            rs_PGMExcel.Tables("RESULT").Rows(i).Item(x) = Split(rs_PGMExcel.Tables("RESULT").Rows(i).Item(x), " - ")(1)
                        End If
                    End If

                    If rs_PGMExcel.Tables("RESULT").Columns(x).ToString = "poh_ver" Then
                        If rs_PGMExcel.Tables("RESULT").Rows(i).Item(x) > 1 Then
                            For c As Integer = 0 To rs_PGMExcel.Tables("RESULT").Rows.Count - 1
                                rs_PGMExcel.Tables("RESULT").Rows(c).Item("REVISED") = "(REVISED)"
                            Next
                        End If
                    End If

                Next
            Next

            rs_PGMExcel.Tables("RESULT").Columns("pod_clrfot").ReadOnly = True
            rs_PGMExcel.Tables("RESULT").Columns("pod_clrbck").ReadOnly = True
            rs_PGMExcel.Tables("RESULT").Columns("pod_matral").ReadOnly = True
            rs_PGMExcel.Tables("RESULT").Columns("pod_prtmtd").ReadOnly = True
            rs_PGMExcel.Tables("RESULT").Columns("pod_tiknes").ReadOnly = True
            rs_PGMExcel.Tables("RESULT").Columns("REVISED").ReadOnly = True



            If Combo1.SelectedIndex = 0 Then
                'Call exportExcel_ExportToExcel()

                Dim objRpt As New PGM00007RptA
                'objRpt.SetDataSource(rs_PGMExcel.Tables("RESULT"))
                'Add Subreport report source
                objRpt.Database.Tables("PGM00007Rpt").SetDataSource(rs_PGMExcel.Tables("RESULT"))
                objRpt.Database.Tables("PGM00007_Disprm").SetDataSource(rs_DISPRM.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()



            End If


        End If
    End Sub


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

        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application



        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")



        xlsWB = xlsApp.Workbooks.Open(Application.StartupPath + "\PackagingTemplate\P.O. info(TEMP)" & cboCoCde.Text & ".xls")


        xlsWS = xlsWB.ActiveSheet


        Dim entry(60) As Object

        Try
            Dim ttlamt As Decimal
            Dim ordseq As Integer = -1
            For i As Integer = 0 To rs_PGMExcel.Tables("RESULT").Rows.Count - 1
                If ordseq <> rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_seq") Then
                    ttlamt = ttlamt + rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_ttlamtqty")
                    ordseq = rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_seq")
                End If
            Next

            xlsApp.Range("L27").Value = ttlamt
            xlsApp.Range("K27").Value = "Total Amount : " & rs_PGMExcel.Tables("RESULT").Rows(0).Item("vbi_curcde")


            Dim dt_table As DataTable
            dt_table = rs_PGMExcel.Tables("RESULT").DefaultView.ToTable(True, "pod_seq")




            With xlsApp
                For i As Integer = 0 To dt_table.Rows.Count - 2
                    '.Range("A12:AR12").Copy()

                    '.Range("A" + (i + 13).ToString).Select()
                    'xlsWS.Paste()

                    For ii As Integer = 0 To 8
                        xlsWS.Rows(22).Insert()
                        xlsWS.Range("N22:P22").Merge()
                        xlsWS.Range("K22:M22").Merge()
                        xlsWS.Range("A22:I22").Merge()
                        xlsWS.Range("N22").NumberFormat = "[$$-409]0.00"
                        xlsWS.Range("Q22").NumberFormat = "[$$-409]0.00"
                    Next



                Next

                .Range("A88:A88").Copy()

            End With

            Dim ucpitemcount As Integer = 0
            Dim currentordseq As Integer = -1

            With xlsApp
                .Range("K7").Value = rs_PGMExcel.Tables("RESULT").Rows(0).Item("cbi_cussna")
                .Range("Q3").Value = Now.Date
                .Range("K3").Value = UCase(txt_S_PKGNo.Text)
                .Range("Q11").Value = "Amount (" & rs_PGMExcel.Tables("RESULT").Rows(0).Item("vbi_curcde") & "$)"

                .Range("A34").Value = rs_PGMExcel.Tables("RESULT").Rows(0).Item("poh_dremark")

                '.Range("B2").Value = rs_TOExcel.Tables("RESULT").Rows(0).Item("toh_cc")
                '.Range("B4").Value = rs_TOExcel.Tables("RESULT").Rows(0).Item("toh_fm")

                For i As Integer = 0 To rs_PGMExcel.Tables("RESULT").Rows.Count - 1

                    If rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_seq") <> currentordseq Then


                        .Range("A" + (ucpitemcount + 13 + (i * 10)).ToString).Value = "Seq " & rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_seq")
                        .Range("K" + (ucpitemcount + 13 + (i * 10)).ToString).Value = rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_ttlordqty")
                        .Range("N" + (ucpitemcount + 13 + (i * 10)).ToString).Value = rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_untprc")
                        .Range("Q" + (ucpitemcount + 13 + (i * 10)).ToString).Value = rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_ttlamtqty")

                        .Range("A" + (ucpitemcount + 14 + (i * 10)).ToString).Value = rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_pkgitm") & " (" & rs_PGMExcel.Tables("RESULT").Rows(i).Item("ypc_pakna") & ")"
                        .Range("A" + (ucpitemcount + 15 + (i * 10)).ToString).Value = rs_PGMExcel.Tables("RESULT").Rows(i).Item("pkgitm")
                        .Range("A" + (ucpitemcount + 16 + (i * 10)).ToString).Value = "Expanded size(Inch) : " & rs_PGMExcel.Tables("RESULT").Rows(i).Item("Einch")
                        .Range("A" + (ucpitemcount + 17 + (i * 10)).ToString).Value = "描述 : " & rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_chndsc")
                        .Range("A" + (ucpitemcount + 18 + (i * 10)).ToString).Value = "Desc : " & rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_engdsc")
                        .Range("A" + (ucpitemcount + 19 + (i * 10)).ToString).Value = "UCP Item"

                        .Range("A" + (ucpitemcount + 19 + (i * 10)).ToString).Style.Font.Underline = Font.Underline

                        Dim dr() As DataRow = rs_PGMExcel.Tables("RESULT").Select("pod_seq = " & rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_seq"))



                        For ii As Integer = 0 To dr.Length - 1
                            Dim currentrow As Integer = ucpitemcount + 22 + (i * 10)
                            xlsWS.Rows(currentrow).Insert()
                            xlsWS.Range("N" & currentrow & ":P" & currentrow).Merge()
                            xlsWS.Range("K" & currentrow & ":M" & currentrow).Merge()
                            xlsWS.Range("A" & currentrow & ":I" & currentrow).Merge()
                            xlsWS.Range("N" & currentrow).NumberFormat = "[$$-409]0.00"
                            xlsWS.Range("Q" & currentrow).NumberFormat = "[$$-409]0.00"

                            .Range("A" + (ucpitemcount + ii + 20 + (i * 10)).ToString).Value = dr(ii)("item")

                        Next

                        ucpitemcount = dr.Length
                        currentordseq = rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_seq")
                        '.Range("A" + (20 + (i * 10)).ToString).Value = "Finishing : " & rs_PGMExcel.Tables("RESULT").Rows(i).Item("pod_finish")



                        '    If rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordseq") <> seq Then
                        '        .Range("A" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordno") & " - " & _
                        '                                                rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordseq")



                        '        .Range("B" + (i + 12).ToString).Value = Format(rs_TOExcel.Tables("RESULT").Rows(i)("tod_credat"), "MM/dd/yyyy")

                        '        .Range("C" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_customer")




                        '        .Range("D" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cus1no")
                        '        .Range("E" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cus2no")
                        '        .Range("F" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_buyer")
                        '        .Range("G" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_category")
                        '        .Range("H" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_jobno")


                        '        .Range("I" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ftyitmno")
                        '        .Range("J" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_itmsku")

                        '        'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_expdat"))
                        '        'test_DateTime = DateTime.Parse(test_str)

                        '        .Range("K" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ftytmpitmno")

                        '        '.Range("L" + (i + 2).ToString).NumberFormat = "@"

                        '        .Range("L" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_itmdsc")

                        '        .Range("M" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_colcde")

                        '        .Range("N" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_inrqty")


                        '        .Range("O" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_mtrqty")

                        '        'If temp_flag_is_ass = 1 Then
                        '        '    .Range("O" + (i + 3).ToString).Value = "PC"
                        '        'Else
                        '        '    .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_untcde")
                        '        'End If

                        '        .Range("P" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_pckunt")
                        '        .Range("Q" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_conftr")

                        '        .Range("R" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cft")

                        '        'If temp_flag_is_ass = 1 Then
                        '        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft") / temp_qud_conftr
                        '        'Else
                        '        '    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_cft")
                        '        'End If

                        '        Dim year As String = Convert.ToDateTime(rs_TOExcel.Tables("RESULT").Rows(i)("tod_period")).Year
                        '        Dim month As String = Split(Format(Convert.ToDateTime(rs_TOExcel.Tables("RESULT").Rows(i)("tod_period")), "MM/dd/yyyy"), "/")(0)

                        '        If year = "1900" Then
                        '            .Range("S" + (i + 12).ToString).Value = ""
                        '        Else
                        '            .Range("S" + (i + 12).ToString).Value = year + "-" + month
                        '        End If

                        '        '.Range("S" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_period")
                        '        '
                        '        '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qpe_curcde")
                        '        .Range("T" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_fobport")

                        '        'Dim temp_cur As String
                        '        'temp_cur = .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").Rows(i)("qud_fcurcde").ToString.Trim


                        '        .Range("U" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_retail")
                        '        .Range("V" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_projqty")
                        '        .Range("W" + (i + 12).ToString).Value = Format(rs_TOExcel.Tables("RESULT").Rows(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        '        .Range("X" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_dsgven")
                        '        .Range("Y" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_prdven")
                        '        .Range("Z" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cusven")




                        '        .Range("AB" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_sapno")
                        '        .Range("AC" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cuspono")
                        '        .Range("AD" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_rmk")
                        '        .Range("AE" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_upc")
                        '        .Range("AF" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnL")
                        '        .Range("AG" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnW")
                        '        .Range("AH" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnH")
                        '        .Range("AI" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ctnupc")
                        '        .Range("AK" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_venstk")
                        '        .Range("AL" + (i + 12).ToString).Value = Format(rs_TOExcel.Tables("RESULT").Rows(i)("tod_cushpdatstr"), "MM/dd/yyyy")
                        '        .Range("AM" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_ftycst")

                        '        .Range("AN" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_curcde")

                        '        .Range("AO" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_qtyb_cuspo")

                        '        .Range("AP" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_qtyb_ordqty")
                        '        '''TRAN TERM
                        '        .Range("AQ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_podat")

                        '        .Range("AR" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_pcktyp")

                        '        .Range("AS" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tod_cntctp")
                        '    Else
                        '        .Range("A" + (i + 12).ToString + ":AS" + (i + 12).ToString).Value = ""
                        '    End If
                        '    '分隔
                        '    .Range("AT" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpseq")
                        '    .Range("AU" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpstr")
                        '    .Range("AV" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_ftyshpend")
                        '    .Range("AW" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpstr")
                        '    .Range("AX" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_cushpend")
                        '    .Range("AY" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_shpqty")
                        '    .Range("AZ" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_pckunt")
                        '    If rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat") = "#1/1/1900#" Then
                        '        .Range("BA" + (i + 12).ToString).Value = ""
                        '    Else
                        '        .Range("BA" + (i + 12).ToString).Value = rs_TOExcel.Tables("RESULT").Rows(i)("tds_podat")
                        '    End If




                        '    seq = rs_TOExcel.Tables("RESULT").Rows(i).Item("tod_toordseq")
                    End If
                Next







            End With


            With xlsApp

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
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_TOM00005 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try
            xlsWB.SaveAs(Filename:="C:\" + txt_S_PKGNo.Text, FileFormat:=52)

        Catch ex As Exception
            MsgBox("File " + "C:\" + txt_S_PKGNo.Text + ".xls already exist. Please delete it before export a new one.")
        End Try

        ' xlsWB.SaveAs(Filename:="C:\" + txtFromQuotNo.Text, ReadOnlyRecommended:=False)

        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference
        ' rs_TOExcel = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
    End Sub



    Private Sub ExportToExcel()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_EXCEL.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim headerRow As Integer = 1
        Dim headerCol As Integer = 1

        Try
            With xlsApp
                headerCol = 0
                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Columns.Count - 1
                    headerCol += 1
                    .Cells(headerRow, headerCol) = rs_EXCEL.Tables("RESULT").Columns(i).ColumnName.ToString

                    'If optRptSCSH.Checked = False Then 'Report Type = SC
                    '    If i = 3 Or i = 4 Or i = 13 Or i = 14 Then
                    '        .Columns(i + 1).NumberFormat = "MM/dd/yyyy"
                    '    ElseIf i = 10 Or i = 11 Or i = 16 Or i = 18 Or i = 19 Or i = 20 Or i = 32 Or i = 34 Or i = 36 Then
                    '        .Columns(i + 1).NumberFormat = "@"
                    '    End If
                    'End If
                Next
                .Range(.Cells(headerRow, 1), .Cells(headerRow, headerCol)).Font.Bold = True
                .Range(.Cells(headerRow, 1), .Cells(headerRow, headerCol)).Font.Size = 10

                For i As Integer = 1 To rs_EXCEL.Tables("RESULT").Columns.Count
                    Select Case i
                        'Case 8, 9, 12, 13, 14, 15, 16, 32, 33, 34, 35, 36
                        Case 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 33, 34, 35, 36, 37
                            .Columns(i).NumberFormat = "@"
                    End Select
                Next

                Dim entry(rs_EXCEL.Tables("RESULT").Columns.Count - 1) As Object
                For i As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                    For j As Integer = 0 To rs_EXCEL.Tables("RESULT").Columns.Count - 1
                        entry(j) = IIf(IsDBNull(rs_EXCEL.Tables("RESULT").Rows(i)(j)), "", rs_EXCEL.Tables("RESULT").Rows(i)(j))
                    Next
                    .Range(.Cells(headerRow + i + 1, 1), .Cells(headerRow + i + 1, headerCol)).Value = entry
                Next

                'Styling

                For i As Integer = 1 To rs_EXCEL.Tables("RESULT").Columns.Count
                    'If i = 18 Then
                    '    .Columns(i).WrapText = False
                    '    .Columns(i).EntireColumn.AutoFit()
                    '    .Columns(i).WrapText = True
                    '    .Columns(i).EntireColumn.AutoFit()
                    'Else
                    '    .Columns(i).EntireColumn.AutoFit()
                    'End If

                    Select Case i
                        Case 8, 9, 12, 13, 14, 15, 16, 32, 33, 34, 35, 36
                            .Columns(i).NumberFormat = "@"
                            .Columns(i).EntireColumn.AutoFit()
                        Case Else
                            .Columns(i).EntireColumn.AutoFit()
                    End Select
                Next
                .Rows(headerRow + 1 & ":" & headerRow + rs_EXCEL.Tables("RESULT").Rows.Count).EntireRow.AutoFit()
                .Rows(headerRow).RowHeight = 24
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Or ex.Message = "Exception from HRESULT: 0x800A03EC" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    ExportToExcel()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, Me.Name.ToString & " - Excel Error")
            End If
        End Try

        ' Release reference
        rs_EXCEL = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub


    Private Sub cmd_S_PKGNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PKGNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PKGNo.Name
        frmComSearch.callFmString = txt_S_PKGNo.Text

        frmComSearch.show_frmS(Me.cmd_S_PKGNo)
    End Sub


End Class