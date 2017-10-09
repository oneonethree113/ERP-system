Imports Excel = Microsoft.Office.Interop.Excel

Public Class QCM00010
    'Search Tab Related
    Dim textboxlist As New Collection() 'a dictionary storing the index and the textbox object
    Dim POShipDateFm As String
    Dim POShipDateTo As String
    Dim SCShipDateFm As String
    Dim SCShipdateto As String

    Dim APP As New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim workbook As Excel.Workbook
    Dim xlRange As Excel.Range

    Dim CanShowFlag As String = "F"


#Region "Search Criteria Related"
    'Search Tab Related Start
    Private Sub cboCocde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCocde.KeyUp
        auto_search_combo(cboCocde)
    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text = "UC-G" Then
            txtCoNam.Text = "UNITED CHINESE GROUP"
        Else
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        End If

    End Sub

    Private Sub AddSearchBtnHandler()
        textboxlist.Add(txt_S_PriCustAll, "cmd_S_PriCustAll")
        textboxlist.Add(txt_S_SecCustAll, "cmd_S_SecCustAll")
        textboxlist.Add(txt_S_CV, "cmd_S_CV")
        'textboxlist.Add(txt_S_CV, "cmd_S_CV")
        'textboxlist.Add(txt_S_FA, "cmd_S_FA")
        'textboxlist.Add(txt_S_SCNo, "cmd_S_SCNo")
        'textboxlist.Add(txt_S_PONo, "cmd_S_PONo")
        textboxlist.Add(txt_S_CustPONo, "cmd_S_CustPONo")


        AddHandler cmd_S_PriCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SecCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_CV.Click, AddressOf cmd_S_Click
        'AddHandler cmd_S_CV.Click, AddressOf cmd_S_Click
        'AddHandler cmd_S_FA.Click, AddressOf cmd_S_Click
        'AddHandler cmd_S_SCNo.Click, AddressOf cmd_S_Click
        'AddHandler cmd_S_PONo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_CustPONo.Click, AddressOf cmd_S_Click



    End Sub


    Private Sub cmd_S_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim trigger_btn As Button = CType(sender, Button)
        Dim btn_name As String = trigger_btn.Name
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = textboxlist(btn_name).Name
        frmComSearch.callFmString = textboxlist(btn_name).Text
        frmComSearch.show_frmS(trigger_btn)
    End Sub

    Private Function CheckSearchCriteria() As Boolean
        CheckSearchCriteria = True
        For i As Integer = 1 To textboxlist.Count
            If (textboxlist(i).Text.Length > 1000) Then
                Dim tmp_labelname As String = "SLabel_" + i.ToString

                MsgBox(" exceeds 1000 characters")
                Return False
            End If
        Next


        If txtSCShipDateFm.Text <> "  /  /" Then
            If Not IsDate(txtSCShipDateFm.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date From")
                txtSCShipDateFm.Focus()
                Return True
            End If
        Else

        End If

        If txtSCShipDateTo.Text <> "  /  /" Then
            If Not IsDate(txtSCShipDateTo.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date To")
                txtSCShipDateTo.Focus()
                Return True
            End If
        End If

        SCShipDateFm = If(txtSCShipDateFm.Text = "  /  /", "01/01/1900", txtSCShipDateFm.Text)
        SCShipdateto = If(txtSCShipDateTo.Text = "  /  /", "01/01/2100", txtSCShipDateTo.Text)





        If txtPOShipDateFm.Text <> "  /  /" Then
            If Not IsDate(txtPOShipDateFm.Text) Then
                MsgBox("Invalid Date Format: PO Ship Start Date From")
                txtPOShipDateFm.Focus()
                Return True
            End If
        Else

        End If

        If txtPOShipDateTo.Text <> "  /  /" Then
            If Not IsDate(txtPOShipDateTo.Text) Then
                MsgBox("Invalid Date Format: PO Ship Start Date To")
                txtPOShipDateTo.Focus()
                Return True
            End If
        End If

        POShipDateFm = If(txtPOShipDateFm.Text = "  /  /", "01/01/1900", txtPOShipDateFm.Text)
        POShipDateTo = If(txtPOShipDateTo.Text = "  /  /", "01/01/2100", txtPOShipDateTo.Text)



    End Function


    'Search Criteria Related End
#End Region


    Private Sub QCM00010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(cboCocde, txtCoNam)

        Call AddSearchBtnHandler()
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click


        CanShowFlag = "F"
        If chkCanPo.Checked = True Then
            CanShowFlag = "T"
        End If




        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)

        If Not CheckSearchCriteria() Then
            MsgBox("Search Fail!")
            Exit Sub
        End If

        Dim PriCustList As String = txt_S_PriCustAll.Text.Replace("'", "''")
        Dim SecCustList As String = txt_S_SecCustAll.Text.Replace("'", "''")
        Dim CVList As String = txt_S_CV.Text.Replace("'", "''")
        'Dim CVList As String = txt_S_CV.Text.Replace("'", "''")
        'Dim FAList As String = txt_S_FA.Text.Replace("'", "''")
        'Dim SCNoList As String = txt_S_SCNo.Text.Replace("'", "''")
        'Dim PONoList As String = txt_S_PONo.Text.Replace("'", "''")
        Dim CustPOList As String = txt_S_CustPONo.Text.Replace("'", "''")


        gspStr = "sp_select_QCM00010 '" & gsCompany & "','" & _
                    PriCustList & "','" & _
                    SecCustList & "','" & _
                    CVList & "','" & _
                    CustPOList & "','" & _
                    POShipDateFm & "','" & _
                    POShipDateTo & "','" & _
                    CanShowFlag & "','" & _
                    gsUsrID & "'"

        '& "','" & _
        'SCShipDateFm & "','" & _
        'SCShipdateto & "','"

        Me.Cursor = Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        Me.Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QCM00010:" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Records Found")
            Exit Sub
        End If



        If Not genExcel() Then
            Exit Sub
        End If



    End Sub

    Private Function genExcel() As Boolean
        Dim relpath As String = My.Application.Info.DirectoryPath
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim tmpfileTime As String = ""


        Dim tmp_cussna As String = ""
        Dim tmp_cuspo As String = ""
        Dim tmp_vennam As String = ""
        Dim tmp_candat As String = ""
        Dim tmp_venno As String = ""
        Dim tmp_now As String = ""

        Dim FinishFlag As Boolean = False

        Dim APP As New Excel.Application
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWb As Excel.Workbook = Nothing
        Dim xlsWs As Excel.Worksheet = Nothing

        Dim currentIndex As Integer = 0

        Dim rowIndex As Integer = 14

        Try
            For index As Integer = currentIndex To rs.Tables("RESULT").Rows.Count - 1 Step 1


                tmpfileTime = DateTime.Now.ToString("yyyyMMddHHmm")
                workbook = APP.Workbooks.Open(relpath & "\QCTemplate\qcm_10.xlsx")
                worksheet = workbook.Worksheets("InspectionCertificate by Vendor")

                genExcel = False

                Cursor = Cursors.WaitCursor
                'Screen.MousePointer = vbHourglass ' Change mouse pointer to hourglass.

                rowIndex = 14
                While (FinishFlag = False)

                    tmp_cussna = rs.Tables("RESULT").Rows(index)("tmp_cussna")
                    tmp_cuspo = rs.Tables("RESULT").Rows(index)("tmp_cuspo")
                    tmp_vennam = rs.Tables("RESULT").Rows(index)("tmp_vennam")
                    tmp_candat = rs.Tables("RESULT").Rows(index)("tmp_candat")
                    tmp_venno = rs.Tables("RESULT").Rows(index)("tmp_venno")
                    tmp_now = rs.Tables("RESULT").Rows(index)("tmp_nowgetdate")

                    Dim tmp_candat_2 As String = tmp_candat.Replace(" ", "-")
                    tmp_now = tmp_now.Replace(" ", "-")

                    worksheet.Range("C9").Value = tmp_cussna
                    worksheet.Range("F9").Value = tmp_cuspo

                    worksheet.Range("C11").Value = tmp_vennam
                    worksheet.Range("J11").Value = tmp_candat_2
                    worksheet.Range("J3").Value = tmp_now




                    If rowIndex >= 47 Then
                        worksheet.Rows(rowIndex).Insert()
                        worksheet.Range(worksheet.Range("B" & rowIndex.ToString), worksheet.Range("E" & rowIndex.ToString)).Merge()
                        worksheet.Range(worksheet.Range("G" & rowIndex.ToString), worksheet.Range("H" & rowIndex.ToString)).Merge()
                        worksheet.Range(worksheet.Range("I" & rowIndex.ToString), worksheet.Range("K" & rowIndex.ToString)).Merge()


                        worksheet.Range(("A" & rowIndex.ToString), ).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        worksheet.Range(("B" & rowIndex.ToString), ("E" & rowIndex.ToString)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        worksheet.Range(("F" & rowIndex.ToString)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        worksheet.Range(("G" & rowIndex.ToString), ("H" & rowIndex.ToString)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        worksheet.Range(("I" & rowIndex.ToString), ("K" & rowIndex.ToString)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                    End If
                    worksheet.Range("A" + rowIndex.ToString).Value = rs.Tables("RESULT").Rows(index)("tmp_cussku")
                    worksheet.Range("B" + rowIndex.ToString).Value = rs.Tables("RESULT").Rows(index)("tmp_engdsc")
                    worksheet.Range("F" + rowIndex.ToString).Value = rs.Tables("RESULT").Rows(index)("tmp_ordqty")
                    worksheet.Range("G" + rowIndex.ToString).Value = rs.Tables("RESULT").Rows(index)("tmp_dest")
                    worksheet.Range("I" + rowIndex.ToString).Value = rs.Tables("RESULT").Rows(index)("tmp_prctrm")


                    'Check thie excel finish or not
                    If index <> rs.Tables("RESULT").Rows.Count - 1 Then
                        If (tmp_cussna <> rs.Tables("RESULT").Rows(index + 1)("tmp_cussna")) Or _
                            (tmp_cuspo <> rs.Tables("RESULT").Rows(index + 1)("tmp_cuspo")) Or _
                            (tmp_vennam <> rs.Tables("RESULT").Rows(index + 1)("tmp_vennam")) Or _
                            (tmp_candat <> rs.Tables("RESULT").Rows(index + 1)("tmp_candat")) Then

                            FinishFlag = True
                        End If

                    ElseIf index = rs.Tables("RESULT").Rows.Count - 1 Then
                        FinishFlag = True
                    End If

                    index = index + 1
                    rowIndex = rowIndex + 1
                End While

                FinishFlag = False
                currentIndex = index + 1

                'If CanShowFlag = "F" Then
                workbook.SaveAs(Filename:="C:\ERP_Excel\" & "Inspection Certificate Vendor Declarations FIPv1—PO#" & tmp_cuspo.ToString, FileFormat:=51, ConflictResolution:=2)
                'Else
                '    workbook.SaveAs(Filename:="C:\ERP_Excel\" & tmpfileTime & "_" & tmp_cuspo.ToString & "_" & tmp_venno.ToString & "(with Cancel PO)", FileFormat:=51, ConflictResolution:=2)

                'End If



                If workbook Is Nothing Then
                Else
                    workbook.Close(True, misValue, misValue)
                End If

            Next




        Catch ex As Exception
            ' handleError(ex.ToString())
            MsgBox("Excel Generation Error." + ex.ToString)
            Exit Function
        Finally

            APP.Quit()

            releaseObject(worksheet)
            releaseObject(workbook)
            releaseObject(APP)
        End Try

        MsgBox("Excel Generation Complete. Save as C:\ERP_Excel\")
        genExcel = True

        ' xlsApp.Visible = True




        Cursor = Cursors.Default

        rs = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing





        Exit Function



    End Function


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


End Class