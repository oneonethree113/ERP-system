Imports Excel = Microsoft.Office.Interop.Excel

Public Class QCM00006
    'Search Tab Related
    Dim textboxlist As New Collection() 'a dictionary storing the index and the textbox object
    Dim POShipDateFm As String
    Dim POShipDateTo As String
    Dim SCShipDateFm As String
    Dim SCShipdateto As String



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
        textboxlist.Add(txt_S_PV, "cmd_S_PV")
        textboxlist.Add(txt_S_CV, "cmd_S_CV")
        textboxlist.Add(txt_S_FA, "cmd_S_FA")
        textboxlist.Add(txt_S_SCNo, "cmd_S_SCNo")
        textboxlist.Add(txt_S_PONo, "cmd_S_PONo")
        textboxlist.Add(txt_S_CustPONo, "cmd_S_CustPONo")


        AddHandler cmd_S_PriCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SecCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PV.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_CV.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_FA.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SCNo.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PONo.Click, AddressOf cmd_S_Click
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
        'For i As Integer = 1 To textboxlist.Count
        '    If (textboxlist(i).Text.Length > 1000) Then
        '        Dim tmp_labelname As String = "SLabel_" + i.ToString
        '        Dim label() As Control = GroupBox_Search.Controls.Find(tmp_labelname, True)
        '        MsgBox(Label(0).Text + " exceeds 1000 characters")
        '        Return False
        '    End If
        'Next


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


    Private Sub QCM00006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(cboCocde, txtCoNam)

        Call AddSearchBtnHandler()
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click


        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)

        If Not CheckSearchCriteria() Then
            MsgBox("Search Fail!")
            Exit Sub
        End If

        Dim PriCustList As String = txt_S_PriCustAll.Text.Replace("'", "''")
        Dim SecCustList As String = txt_S_SecCustAll.Text.Replace("'", "''")
        Dim PVList As String = txt_S_PV.Text.Replace("'", "''")
        Dim CVList As String = txt_S_CV.Text.Replace("'", "''")
        Dim FAList As String = txt_S_FA.Text.Replace("'", "''")
        Dim SCNoList As String = txt_S_SCNo.Text.Replace("'", "''")
        Dim PONoList As String = txt_S_PONo.Text.Replace("'", "''")
        Dim CustPOList As String = txt_S_CustPONo.Text.Replace("'", "''")


        gspStr = "sp_select_QCM00006 '" & gsCompany & "','" & _
                    PriCustList & "','" & _
                    SecCustList & "','" & _
                    PVList & "','" & _
                    CVList & "','" & _
                    FAList & "','" & _
                    SCNoList & "','" & _
                    PONoList & "','" & _
                    CustPOList & "','" & _
                    POShipDateFm & "','" & _
                    POShipDateTo & "','" & _
                    SCShipDateFm & "','" & _
                    SCShipdateto & "','" & _
                    gsUsrID & "'"

        Me.Cursor = Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        Me.Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QCM00006:" & rtnStr)
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
        genExcel = False

        On Error GoTo Err_Handler
        Cursor = Cursors.WaitCursor
        'Screen.MousePointer = vbHourglass ' Change mouse pointer to hourglass.
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWb As Excel.Workbook = Nothing
        Dim xlsWs As Excel.Worksheet = Nothing

        'Dim xlApp As Excel.Application
        'Dim xlWb As Excel.Workbook
        'Dim xlWs As Excel.Worksheet

        Dim recArray As Object
        Dim lngRecCount As Long
        Dim fldCount As Integer
        Dim recCount As Long
        Dim iCol As Long
        Dim iRow As Long

        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        lngRecCount = rs.Tables("RESULT").Rows.Count + 1
        If rs.Tables("RESULT").Rows.Count + 1 > 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Function
        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------

        xlsApp = New Excel.Application
        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWb = xlsApp.Workbooks.Add()
        xlsWs = xlsWb.ActiveSheet


 
        fldCount = rs.Tables("RESULT").Columns.Count

        For iCol = 1 To fldCount

            xlsWs.Rows(1).Font.Bold = True
            xlsWs.Rows(1).Font.Size = 10
        Next

        'For i As Integer = 1 To fldCount

        '    If i = 11 Or i = 12 Or i = 13 Or i = 14 Or i = 16 Or i = 17 Then
        '        xlsWs.Columns(i).WrapText = True
        '        xlsWs.Columns(i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        '        xlsWs.Columns(i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        '        xlsWs.Rows(1).WrapText = False
        '    End If
        'Next

        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Set Form Style


        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------

        Dim entry(rs.Tables("RESULT").Rows.Count, fldCount - 1) As Object
        With xlsApp
            'Initializing Header Row'
            For i As Integer = 0 To fldCount - 1
                entry(0, i) = rs.Tables("RESULT").Columns(i).ColumnName.ToString
            Next

            'Populating Data
            For j As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
                For i As Integer = 0 To fldCount - 1
                    entry(j + 1, i) = rs.Tables("RESULT").Rows(j)(i)
                Next
            Next

            .Range(.Cells(1, 1), .Cells(rs.Tables("RESULT").Rows.Count + 1, fldCount)).Value = entry
        End With

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()

        'xlsWs.Rows(1).RowHeight = 25


        MsgBox("Excel Generation Complete.")

        xlsApp.Visible = True

        rs = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default


        Exit Function
Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Cursor = Cursors.Default
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing


        genExcel = True
    End Function

End Class