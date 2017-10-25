Public Class IMR00027
    Dim rs_IMR00027a As DataSet
    Private Sub IMR00027_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 
 

        cboAOPrdLne.Items.Add("AND")
        cboAOPrdLne.Items.Add("OR")
        cboAOPrdLne.SelectedIndex = 0

        cboAOItmno.Items.Add("AND")
        cboAOItmno.Items.Add("OR")
        cboAOItmno.SelectedIndex = 0

        cboAOItmDsc.Items.Add("AND")
        cboAOItmDsc.Items.Add("OR")
        cboAOItmDsc.SelectedIndex = 0

        cboAOColDsc.Items.Add("AND")
        cboAOColDsc.Items.Add("OR")
        cboAOColDsc.SelectedIndex = 0

        cboAOVenno.Items.Add("AND")
        cboAOVenno.Items.Add("OR")
        cboAOVenno.SelectedIndex = 0

        cboAOItmNat.Items.Add("AND")
        cboAOItmNat.Items.Add("OR")
        cboAOItmNat.SelectedIndex = 0

        cboAOPrdsze.Items.Add("AND")
        cboAOPrdsze.Items.Add("OR")
        cboAOPrdsze.SelectedIndex = 0

        cboAOPrdGrp.Items.Add("AND")
        cboAOPrdGrp.Items.Add("OR")
        cboAOPrdGrp.SelectedIndex = 0

        cboAOPrdIcon.Items.Add("AND")
        cboAOPrdIcon.Items.Add("OR")
        cboAOPrdIcon.SelectedIndex = 0

        cboAOMatL.Items.Add("AND")
        cboAOMatL.Items.Add("OR")
        cboAOMatL.SelectedIndex = 0

        cmbImageOnly.Items.Add("Excel")
        cmbImageOnly.SelectedIndex = 0


        Dim grp As String = Split(gsUsrGrp, "-")(0)

        If grp = "MIS" Or grp = "DGN" Then
            optHighRel.Enabled = True
            optLowRel.Enabled = True
            optHighRel.Checked = True
        Else
            optHighRel.Enabled = False
            optLowRel.Enabled = True
            optLowRel.Checked = True
        End If

        lblNote.Text = "1. Command Symbol" + vbCrLf & _
                          "   [,] - to separate value (e.g. A,B,C)" + vbCrLf & _
                          "   [~] - to indicate range (e.g. A~B)" + vbCrLf & _
                          "   [%] - to indicate similar (e.g. %RING%)" + vbCrLf & _
                          "2. Combination Symbol" + vbCrLf & _
                          "   (e.g. WOOD, %RING%, ZA~ZZ) " + vbCrLf & _
                          "3. Product Size Input format" + vbCrLf & _
                          "   D 52 INCH - Diameter, 52, INCH"

        Call Formstartup(Me.Name)
    End Sub
    Private Function removeDuplicateItem(ByVal strInput As String) As String

        Dim intCount As Integer
        Dim strResult As String
        Dim strTemp As String
        Dim strArray() As String
        Dim i As Integer
        Dim j As Integer

        strResult = strInput
        intCount = UBound(Split(strInput, ","))
        If intCount > 0 Then
            ReDim strArray(intCount)
            For i = 0 To intCount
                strArray(i) = Split(strInput, ",")(i)
            Next i
            For i = 0 To UBound(strArray)
                strTemp = strArray(i)
                If strTemp <> "" Then
                    For j = 0 To UBound(strArray)
                        If (i <> j And strArray(j) <> "" And strTemp = strArray(j)) Then
                            strArray(j) = ""
                        End If
                    Next j
                End If
            Next i
            strResult = ""
            For i = 0 To UBound(strArray)
                strResult = strResult & IIf(strArray(i) = "", "", IIf(strResult = "", strArray(i), "," & strArray(i)))
            Next i
        End If
        removeDuplicateItem = strResult

    End Function
    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
      
        Dim PRDLNELIST As String

        Dim ITMNOLIST As String
        Dim PRDSZELIST As String

        Dim ITMDSCFM As String
        Dim ITMDSCTO As String
        Dim ITMDSCPARTIAL As String

        Dim COLDSCFM As String
        Dim COLDSCTO As String
        Dim COLDSCPARTIAL As String

        Dim VENCDEFM As String
        Dim VENCDETO As String

        Dim VENTYP As String
        Dim ITMTYP As String
        Dim PRDTYP As String
        Dim RESOL As String

        Dim ITMDSCLIST As String
        Dim COLDSCLIST As String
        Dim VENCDELIST As String
        Dim ITMNATLIST As String
        Dim PRDGRPLIST As String
        Dim PRDICNLIST As String
        Dim PRDMATLIST As String

        'PRDLNEFM = Trim(cboPLFm.Text)
        'PRDLNETO = Trim(cboPLTo.Text)

        'If (PRDLNEFM > PRDLNETO) Then
        '    MsgBox ("Range of Product Line From should be smaller then Product Line To!")
        '    cboPLFm.Focus
        '    Exit Sub
        'End If

        If Trim(Me.txtPrdLne.Text) = "" Then
            PRDLNELIST = ""
        Else
            If Len(Me.txtPrdLne.Text) > 1000 Then
                MsgBox("The Product Line List Is Too Long")
                Exit Sub
            End If
            PRDLNELIST = removeDuplicateItem(Trim(Me.txtPrdLne.Text))
            PRDLNELIST = Replace(PRDLNELIST, "'", "''")
        End If

        If Trim(Me.txtItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(Me.txtItmNo.Text) > 1000 Then
                MsgBox("The Item List Is Too Long!")
                Exit Sub
            End If
            If InStr(Me.txtItmNo.Text, "%") <> 0 Then
                MsgBox("No char % should be in Item number criteria list.")
                Me.txtItmNo.Focus()
                Exit Sub
            End If
            ITMNOLIST = removeDuplicateItem(Trim(Me.txtItmNo.Text))
            ITMNOLIST = Replace(ITMNOLIST, "'", "''")
        End If

        If Trim(Me.txtItmDsc.Text) = "" Then
            ITMDSCLIST = ""
        Else
            If Len(Me.txtItmDsc.Text) > 1000 Then
                MsgBox("The Item Description List Is Too Long!")
                Exit Sub
            End If
            ITMDSCLIST = removeDuplicateItem(Trim(Me.txtItmDsc.Text))
            ITMDSCLIST = Replace(ITMDSCLIST, "'", "''")
        End If


        If Trim(Me.txtColDsc.Text) = "" Then
            COLDSCLIST = ""
        Else
            If Len(Me.txtColDsc.Text) > 1000 Then
                MsgBox("The Color Description List Is Too Long!")
                Exit Sub
            End If
            COLDSCLIST = removeDuplicateItem(Trim(Me.txtColDsc.Text))
            COLDSCLIST = Replace(COLDSCLIST, "'", "''")
        End If

        If Trim(Me.txtVencde.Text) = "" Then
            VENCDELIST = ""
        Else
            If Len(Me.txtVencde.Text) > 1000 Then
                MsgBox("The Vendor Code List Is Too Long")
                Exit Sub
            End If
            If InStr(Me.txtVencde.Text, "%") <> 0 Then
                MsgBox("No char % should be in default vendor criteria list.")
                Me.txtVencde.Focus()
                Exit Sub
            End If
            VENCDELIST = removeDuplicateItem(Trim(Me.txtVencde.Text))
            VENCDELIST = Replace(VENCDELIST, "'", "''")
        End If

        If Trim(Me.txtItmnat.Text) = "" Then
            ITMNATLIST = ""
        Else
            If Len(Me.txtItmnat.Text) > 1000 Then
                MsgBox("The Item Nature Code List Is Too Long")
                Exit Sub
            End If
            If InStr(Me.txtItmnat.Text, "%") <> 0 Then
                MsgBox("No char % should be in item nature criteria list.")
                Me.txtItmnat.Focus()
                Exit Sub
            End If
            ITMNATLIST = removeDuplicateItem(Trim(Me.txtItmnat.Text))
            ITMNATLIST = Replace(ITMNATLIST, "'", "''")
        End If


        If Trim(Me.txtPrdsze.Text) = "" Then
            PRDSZELIST = ""
        Else
            If Len(Me.txtPrdsze.Text) > 1000 Then
                MsgBox("The Product Size Code List Is Too Long")
                Exit Sub
            End If
            If InStr(Me.txtPrdsze.Text, "%") <> 0 Then
                MsgBox("No char % should be in product size criteria list.")
                Me.txtPrdsze.Focus()
                Exit Sub
            End If
            PRDSZELIST = removeDuplicateItem(Trim(Me.txtPrdsze.Text))
            PRDSZELIST = Replace(PRDSZELIST, "'", "''")
        End If


        If Trim(Me.txtPrdGrp.Text) = "" Then
            PRDGRPLIST = ""
        Else
            If Len(Me.txtPrdGrp.Text) > 1000 Then
                MsgBox("The Product Group List Is Too Long")
                Exit Sub
            End If
            If InStr(Me.txtPrdGrp.Text, "%") <> 0 Then
                MsgBox("No char % should be in product group criteria list.")
                Me.txtPrdGrp.Focus()
                Exit Sub
            End If
            PRDGRPLIST = removeDuplicateItem(Trim(Me.txtPrdGrp.Text))
            PRDGRPLIST = Replace(PRDGRPLIST, "'", "''")
        End If


        If Trim(Me.txtPrdIcon.Text) = "" Then
            PRDICNLIST = ""
        Else
            If Len(Me.txtPrdIcon.Text) > 1000 Then
                MsgBox("The Product Icon List Is Too Long")
                Exit Sub
            End If
            If InStr(Me.txtPrdIcon.Text, "%") <> 0 Then
                MsgBox("No char % should be in product icon criteria list.")
                Me.txtPrdIcon.Focus()
                Exit Sub
            End If
            PRDICNLIST = removeDuplicateItem(Trim(Me.txtPrdIcon.Text))
            PRDICNLIST = Replace(PRDICNLIST, "'", "''")
        End If

        If Trim(Me.txtMatL.Text) = "" Then
            PRDMATLIST = ""
        Else
            If Len(Me.txtMatL.Text) > 1000 Then
                MsgBox("The Product Material List Is Too Long")
                Exit Sub
            End If
            If InStr(Me.txtMatL.Text, "%") <> 0 Then
                MsgBox("No char % should be in product material criteria list.")
                Me.txtMatL.Focus()
                Exit Sub
            End If
            PRDMATLIST = removeDuplicateItem(Trim(Me.txtMatL.Text))
            PRDMATLIST = Replace(PRDMATLIST, "'", "''")
        End If


        'If PRDLNEFM = "" And ITMNOFM = "" And VENCDEFM = "" And ITMNOLIST = "" And ITMDSCFM = "" And COLDSCFM = "" Then
        '    MsgBox ("At least one of the criteria [Prod Line | Item No/Dsc/Color | Vendor Code] should be selected")
        '    Exit Sub
        'End If




        VENTYP = ""

        If chkVT_I.Checked = True Then
            VENTYP = VENTYP + "Y"
        Else
            VENTYP = VENTYP + "N"
        End If

        If chkVT_J.Checked = True Then
            VENTYP = VENTYP + "Y"
        Else
            VENTYP = VENTYP + "N"
        End If

        If chkVT_E.Checked = True Then
            VENTYP = VENTYP + "Y"
        Else
            VENTYP = VENTYP + "N"
        End If


        If VENTYP = "NNN" Then
            MsgBox("At least one Vendor Type should be selected!")
            Exit Sub
        End If

        ITMTYP = ""

        If chkIT_REG.Checked = True Then
            ITMTYP = ITMTYP + "Y"
        Else
            ITMTYP = ITMTYP + "N"
        End If

        If chkIT_ASS.Checked = True Then
            ITMTYP = ITMTYP + "Y"
        Else
            ITMTYP = ITMTYP + "N"
        End If

        If chkIT_BOM.Checked = True Then
            ITMTYP = ITMTYP + "Y"
        Else
            ITMTYP = ITMTYP + "N"
        End If

        If chkIT_OTH.Checked = True Then
            ITMTYP = ITMTYP + "Y"
        Else
            ITMTYP = ITMTYP + "N"
        End If

        If ITMTYP = "NNNN" Then
            MsgBox("At least one Item Type should be selected!")
            Exit Sub
        End If



        PRDTYP = ""

        If chkPT_SR.Checked = True Then
            PRDTYP = PRDTYP + "Y"
        Else
            PRDTYP = PRDTYP + "N"
        End If

        If chkPT_OEM.Checked = True Then
            PRDTYP = PRDTYP + "Y"
        Else
            PRDTYP = PRDTYP + "N"
        End If

        If chkPT_MD.Checked = True Then
            PRDTYP = PRDTYP + "Y"
        Else
            PRDTYP = PRDTYP + "N"
        End If

        If chkPT_OEMSR.Checked = True Then
            PRDTYP = PRDTYP + "Y"
        Else
            PRDTYP = PRDTYP + "N"
        End If

        If chkPT_OTH.Checked = True Then
            PRDTYP = PRDTYP + "Y"
        Else
            PRDTYP = PRDTYP + "N"
        End If

        If PRDTYP = "NNNNN" Then
            MsgBox("At least one Product Type should be selected!")
            Exit Sub
        End If

        If optLowRel.Checked = True Then
            RESOL = "L"
        Else
            RESOL = "H"
        End If




        'S = "㊣IMR00027','L','" & _
        '    PRDLNEFM & "','" & PRDLNETO & "','" & PRDLNELIST & "','" & _
        '    ITMNOFM & "','" & ITMNOTO & "','" & ITMNOLIST & "','" & _
        '    ITMDSCFM & "','" & ITMDSCTO & "','" & ITMDSCPARTIAL & "','" & _
        '    COLDSCFM & "','" & COLDSCTO & "','" & COLDSCPARTIAL & "','" & _
        '    VENCDEFM & "','" & VENCDETO & "','" & _
        '    VENTYP & "','" & ITMTYP & "','" & PRDTYP & "','X"
        Dim PRDLNEFM As String
        Dim PRDLNETO As String
        Dim ITMNOFM As String
        Dim ITMNOTO As String

        gspStr = "sp_list_IMR00027 '','" & _
            PRDLNEFM & "','" & PRDLNETO & "','" & PRDLNELIST & "','" & cboAOPrdLne.Text & "','" & _
            ITMNOFM & "','" & ITMNOTO & "','" & ITMNOLIST & "','" & cboAOItmno.Text & "','" & _
            ITMDSCFM & "','" & ITMDSCTO & "','" & ITMDSCLIST & "','" & cboAOItmDsc.Text & "','" & _
            COLDSCFM & "','" & COLDSCTO & "','" & COLDSCLIST & "','" & cboAOColDsc.Text & "','" & _
            VENCDEFM & "','" & VENCDETO & "','" & VENCDELIST & "','" & cboAOVenno.Text & "','" & _
            ITMNATLIST & "','" & cboAOItmNat.Text & "','" & _
            PRDSZELIST & "','" & cboAOPrdsze.Text & "','" & _
            PRDGRPLIST & "','" & cboAOPrdGrp.Text & "','" & _
            PRDICNLIST & "','" & cboAOPrdIcon.Text & "','" & _
            PRDMATLIST & "','" & cboAOMatL.Text & "','" & _
            VENTYP & "','" & ITMTYP & "','" & PRDTYP & "','" & RESOL & "','X'"


        Me.Cursor = Cursors.WaitCursor
        'Debug.Print Replace(Replace(Replace(S, "','", "','"), "㊣", "exec sp_list_"), "','L'", " ''") & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00027a, rtnStr)

        Me.Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading sp_select_MSR00001:" & rtnStr)
        Else
            '   MsgBox ("After SP")
            'rs_IMR00027a = rs(1)
            If rs_IMR00027a.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found")
                Exit Sub
            Else
                '        MsgBox (rs_IMR00027a.recordCount)
                Call ExportExcel()
                '        Set Rpt_IMR00027a = New IMR00027aRpt
                '        Rpt_IMR00027a.Database.SetDataSource rs_IMR00027a
                '        Set frmCR.Report = Rpt_IMR00027a
                '
                '        frmCR.Show

            End If
        End If

    End Sub
    Public Sub InsertPictureInRange(ByVal PictureFileName As String, ByVal TargetCells As Microsoft.Office.Interop.Excel.Range, ByRef xls As Microsoft.Office.Interop.Excel.Worksheet)
        Dim p As Object, t As Double, l As Double, W As Double, H As Double


        If Dir(PictureFileName) = "" Then Exit Sub

        With xls
            If Dir(PictureFileName) <> "" Then
                p = .Pictures.Insert(PictureFileName)

                ' determine positions
                With TargetCells
                    t = .Top
                    l = .Left
                    'w = .Offset(0, .Columns.count).left - .left
                    'h = .Offset(.rows.count, 0).top - .top
                    H = .Offset(0, .Columns.Count).Left - .Left
                    W = .Offset(.Rows.Count, 0).Top - .Top
                End With
                ' position picture

                '            MsgBox p.Height
                '            MsgBox p.width

                If p.Height >= p.width Then
                    H = 160
                    W = 120
                Else
                    W = 120
                    H = 90
                End If

                With p
                    .Top = t + 1
                    .Left = l
                    .width = W
                    .Height = H
                End With
                p = Nothing
            End If
        End With
    End Sub
    Private Function ExportExcel()

        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet

        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True

        xlApp.UserControl = True

        Dim col As Integer
        Dim row As Integer

        Dim excelrow As Integer


        Dim res_reccnt1_flag As Boolean
        Dim res_reccnt2_flag As Boolean
        Dim res_reccnt3_flag As Boolean



        With xlWs

            '------------------------------------------------------------------
            ' HEADER INFORMATION / PAGE SETUP
            '------------------------------------------------------------------
            .PageSetup.LeftHeader = "Export Item Image to Excel"
            .PageSetup.CenterHeader = ""
            .PageSetup.RightHeader = "Print Date: " & Date.Now
            .PageSetup.LeftFooter = ""
            .PageSetup.CenterFooter = "&P/&N"
            .PageSetup.RightFooter = ""
            .PageSetup.LeftMargin = 20
            .PageSetup.RightMargin = 20
            .PageSetup.TopMargin = 40
            .PageSetup.BottomMargin = 40
            .PageSetup.HeaderMargin = 20
            .PageSetup.FooterMargin = 20
            .PageSetup.PrintHeadings = False
            .PageSetup.PrintGridlines = False
            .PageSetup.PrintComments = Microsoft.Office.Interop.Excel.XlPrintLocation.xlPrintNoComments
            .PageSetup.PrintQuality = 600
            .PageSetup.CenterHorizontally = False
            .PageSetup.CenterVertically = False
            .PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait
            .PageSetup.Draft = False
            .PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4
            .PageSetup.FirstPageNumber = Microsoft.Office.Interop.Excel.Constants.xlAutomatic
            .PageSetup.Order = Microsoft.Office.Interop.Excel.XlOrder.xlDownThenOver
            .PageSetup.BlackAndWhite = False
            .PageSetup.Zoom = 100




            '------------------------------------------------------------------
            ' DETAIL INFORMATION
            '------------------------------------------------------------------
            'For row = 1 To rs_IMR00027a.recordCount
            For row = 0 To rs_IMR00027a.Tables("RESULT").Rows.Count - 1
                If row = 0 Then
                    excelrow = row + 1
                End If

                'Draw line
                .Range(.Cells(excelrow, 1), .Cells(excelrow, 6)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(excelrow, 1), .Cells(excelrow, 6)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin

                For col = 1 To 6
                    Dim sResultString As String = ""
                    Select Case col
                        Case 1
                            'Record No. 1
                            res_reccnt1_flag = False
                            If rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_reccnt1") > 0 Then
                                sResultString = "'" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_reccnt1") & "."
                                res_reccnt1_flag = True
                            End If
                        Case 2
                            'photo 1
                            If res_reccnt1_flag Then
                                sResultString = rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_imgpth1")
                                If sResultString <> "" Then
                                    Call InsertPictureInRange(sResultString, .Range(.Cells(excelrow, col), .Cells(excelrow, col)), xlWs)
                                End If
                            End If
                        Case 3
                            'Record No. 2
                            res_reccnt2_flag = False
                            If rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_reccnt2") > 0 Then
                                sResultString = "'" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_reccnt2") & "."
                                res_reccnt2_flag = True
                            End If
                        Case 4
                            'photo 2
                            If res_reccnt2_flag Then
                                sResultString = rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_imgpth2")
                                If sResultString <> "" Then
                                    Call InsertPictureInRange(sResultString, .Range(.Cells(excelrow, col), .Cells(excelrow, col)), xlWs)
                                End If
                            End If
                        Case 5
                            'Record No. 3
                            res_reccnt3_flag = False
                            If rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_reccnt3") > 0 Then
                                sResultString = "'" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_reccnt3") & "."
                                res_reccnt3_flag = True
                            End If
                        Case 6
                            'photo 3
                            If res_reccnt3_flag Then
                                sResultString = rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_imgpth3")
                                If sResultString <> "" Then
                                    Call InsertPictureInRange(sResultString, .Range(.Cells(excelrow, col), .Cells(excelrow, col)), xlWs)
                                End If
                            End If
                    End Select

                    If col = 1 Or col = 3 Or col = 5 Then
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Value = sResultString

                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Size = 10
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Bold = True

                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlTop

                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 162
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).ColumnWidth = 10
                    Else
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 162
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).ColumnWidth = 20
                    End If
                Next col


                excelrow = excelrow + 1

                For col = 1 To 6
                    Dim sResultString As String = ""
                    Select Case col
                        Case 1
                            If res_reccnt1_flag Then
                                sResultString = "Item No. :"
                            End If
                        Case 2
                            'Item No. 1
                            If res_reccnt1_flag Then
                                sResultString = "'" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmno1")
                            End If
                        Case 3
                            If res_reccnt2_flag Then
                                sResultString = "Item No. :"
                            End If
                        Case 4
                            'Item No. 2
                            If res_reccnt2_flag Then
                                sResultString = "'" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmno2")
                            End If
                        Case 5
                            If res_reccnt3_flag Then
                                sResultString = "Item No. :"
                            End If
                        Case 6
                            'Item No. 3
                            If res_reccnt3_flag Then
                                sResultString = "'" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmno3")
                            End If
                    End Select

                    '                If col = 1 Or col = 3 Or col = 5 Then
                    '                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Value = sResultString
                    '                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 15
                    '                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Size = 10
                    '                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Bold = False
                    '                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).HorizontalAlignment = xlLeft
                    '                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).VerticalAlignment = xlTop
                    '                Else
                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Value = sResultString
                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 15
                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Size = 10
                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Bold = False
                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                    .Range(.Cells(excelrow, col), .Cells(excelrow, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlTop
                    '                End If
                Next col


                excelrow = excelrow + 1


                For col = 1 To 6
                    Dim sResultString As String = ""
                    Select Case col
                        Case 1
                            If res_reccnt1_flag Then
                                sResultString = "Item Desc. :"
                            End If
                        Case 2
                            'Item Desc 1
                            If res_reccnt1_flag Then
                                sResultString = rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmdsc1")
                            End If
                        Case 3
                            If res_reccnt2_flag Then
                                sResultString = "Item Desc. :"
                            End If
                        Case 4
                            'Item Desc 2
                            If res_reccnt2_flag Then
                                sResultString = rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmdsc2")
                            End If
                        Case 5
                            If res_reccnt3_flag Then
                                sResultString = "Item Desc. :"
                            End If
                        Case 6
                            'Item Desc 3
                            If res_reccnt3_flag Then
                                sResultString = rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmdsc3")
                            End If
                    End Select

                    If col = 1 Or col = 3 Or col = 5 Then
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Value = sResultString
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 45
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Size = 10
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Bold = False
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlTop
                    Else
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Value = sResultString
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 45
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Size = 10
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Bold = False
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlTop
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).WrapText = True
                    End If
                Next col


                excelrow = excelrow + 1


                For col = 1 To 6
                    Dim sResultString As String = ""
                    Select Case col
                        Case 1
                            If res_reccnt1_flag Then
                                sResultString = "BarCode :"
                            End If
                        Case 2
                            'Item No 1 for barcode
                            If res_reccnt1_flag Then
                                sResultString = "*" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmno1") & "*"
                            End If
                        Case 3
                            If res_reccnt2_flag Then
                                sResultString = "BarCode :"
                            End If
                        Case 4
                            'Item No 2 for barcode
                            If res_reccnt2_flag Then
                                sResultString = "*" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmno2") & "*"
                            End If
                        Case 5
                            If res_reccnt3_flag Then
                                sResultString = "BarCode :"
                            End If
                        Case 6
                            'Item No 3 for barcode
                            If res_reccnt3_flag Then
                                sResultString = "*" & rs_IMR00027a.Tables("RESULT").Rows(row).Item("res_itmno3") & "*"
                            End If
                    End Select

                    If col = 1 Or col = 3 Or col = 5 Then
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Value = sResultString
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 15
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Size = 10
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Bold = False
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlTop
                    Else
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Value = sResultString
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).RowHeight = 15
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Name = "3 of 9 Barcode"
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Size = 10
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).Font.Bold = False
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
                        .Range(.Cells(excelrow, col), .Cells(excelrow, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlTop


                    End If
                Next col

                excelrow = excelrow + 1

                'rs_IMR00027a.MoveNext()
            Next row

            'Define Column width


        End With


    End Function

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlPrdLne.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtPrdLne.Name
        frmComSearch.callFmString = txtPrdLne.Text

        frmComSearch.show_frmS(Me.cmdtlPrdLne)
    End Sub

    Private Sub cmdtlItmno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlItmno.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtItmNo.Name
        frmComSearch.callFmString = txtItmNo.Text

        frmComSearch.show_frmS(Me.cmdtlItmno)
    End Sub

    Private Sub cmdtlItmDsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlItmDsc.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtItmDsc.Name
        frmComSearch.callFmString = txtItmDsc.Text

        frmComSearch.show_frmS(Me.cmdtlItmDsc)
    End Sub

    Private Sub cmdtlColDsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlColDsc.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtColDsc.Name
        frmComSearch.callFmString = txtColDsc.Text

        frmComSearch.show_frmS(Me.cmdtlColDsc)
    End Sub

    Private Sub cmdtlvencde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlvencde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtVencde.Name
        frmComSearch.callFmString = txtVencde.Text

        frmComSearch.show_frmS(Me.cmdtlvencde)
    End Sub

    Private Sub cmdtlItmnat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlItmnat.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtItmnat.Name
        frmComSearch.callFmString = txtItmnat.Text

        frmComSearch.show_frmS(Me.cmdtlItmnat)
    End Sub

    Private Sub cndtlPrdsze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cndtlPrdsze.Click


        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtPrdsze.Name
        frmComSearch.callFmString = txtPrdsze.Text

        frmComSearch.show_frmS(Me.cndtlPrdsze)

    End Sub

    Private Sub cmdtlPrdGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlPrdGrp.Click



        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtPrdGrp.Name
        frmComSearch.callFmString = txtPrdGrp.Text

        frmComSearch.show_frmS(Me.cmdtlPrdGrp)

    End Sub

    Private Sub cmdtlPrdIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlPrdIcon.Click



        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtPrdIcon.Name
        frmComSearch.callFmString = txtPrdIcon.Text

        frmComSearch.show_frmS(Me.cmdtlPrdIcon)
    End Sub

    Private Sub cmdtlMatL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtlMatL.Click


        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtMatL.Name
        frmComSearch.callFmString = txtMatL.Text

        frmComSearch.show_frmS(Me.cmdtlMatL)
    End Sub
End Class