Public Class MSR00027
    Dim textboxlist As New Collection()
    Dim rs_EXCEL As DataSet
    Dim rs_MSR00027 As DataSet

    Dim ETDFm As String
    Dim ETDTo As String

    Private Sub MSR00027_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        InitSortCombo()
        UpdateETDDate()
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub InitSortCombo()
        cb_sort.Items.Clear()
        cb_sort.Items.Add(New GenericListItem(Of String)("S/C No", "S"))
        cb_sort.Items.Add(New GenericListItem(Of String)("Job No", "J"))
        cb_sort.Items.Add(New GenericListItem(Of String)("Container No", "C"))
        cb_sort.Items.Add(New GenericListItem(Of String)("Invoice No", "I"))

        cb_sort.SelectedIndex = 0
    End Sub

    Private Sub UpdateETDDate()

        txtETDTo.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Dim NextMonth As Date = DateAdd(DateInterval.Month, -3, DateTime.Now)
        txtETDFm.Text = NextMonth.ToString("MM/dd/yyyy")
    End Sub

    ''sync user input to "To" text box
    'Private Sub txtFrom_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    'Dim tmp_name As String = sender.name

    'If tmp_name = "txtFromContainer" Then
    '    txtToContainer.Text = sender.Text
    'ElseIf tmp_name = "txtFromSC" Then
    '    txtToSC.Text = sender.Text
    'ElseIf tmp_name = "txtFromcsitem" Then
    '    txtTocsitem.Text = sender.text
    'ElseIf tmp_name = "txtFromitem" Then
    '    txtToitem.Text = sender.text
    'ElseIf tmp_name = "txtFromjob" Then
    '    txtTojob.Text = sender.text
    'End If
    'End Sub


    'Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
    '    'Dim flg_valid As Boolean

    'Dim rs_Result As DataSet
    'Dim sort_by As String = cb_sort.SelectedItem.value

    ''Update Company Code before execute
    'gsCompany = Trim(cboCoCde.Text)
    'Call Update_gs_Value(gsCompany)

    'Me.Cursor = Windows.Forms.Cursors.WaitCursor

    'flg_valid = DataValidate()

    'If flg_valid = False Then
    '    MsgBox("Show Report Fail!")
    'ElseIf flg_valid = True Then
    '    'Start Generate Report

    '    gspStr = "sp_select_MSR00027_NET '" & gsCompany & "','" & _
    '                txtFromContainer.Text & "','" & _
    '                txtToContainer.Text & "','" & _
    '                txtFromSC.Text & "','" & _
    '                txtToSC.Text & "','" & _
    '                txtFromjob.Text & "','" & _
    '                txtTojob.Text & "','" & _
    '                txtFromitem.Text & "','" & _
    '                txtToitem.Text & "','" & _
    '                txtFromcsitem.Text & "','" & _
    '                txtTocsitem.Text & "','" & _
    '                sort_by & "','" & _
    '                gsUsrID & "'"

    '    rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading sp_select_MSR00027_NET : " & rtnStr)
    '        Me.Cursor = Windows.Forms.Cursors.Default
    '        Exit Sub
    '    End If

    '    If rs_Result.Tables("Result").Rows.Count = 0 Then
    '        Me.Cursor = Windows.Forms.Cursors.Default
    '        MsgBox("No results found")
    '        Exit Sub
    '    Else
    '        Dim objRpt As New MSR00027Rpt
    '        objRpt.SetDataSource(rs_Result.Tables("RESULT"))
    '        'Add Subreport report source
    '        Dim frmReportView As New frmReport
    '        frmReportView.CrystalReportViewer.ReportSource = objRpt
    '        frmReportView.Show()
    '    End If

    'End If


    '    Me.Cursor = Windows.Forms.Cursors.Default
    'End Sub

    'Private Function DataValidate() As Boolean

    'If txtFromContainer.Text > txtToContainer.Text Then
    '    MsgBox("Container No: To < From!")
    '    Return False
    'End If

    'If txtFromcsitem.Text > txtTocsitem.Text Then
    '    MsgBox("Customer item No: To < From!")
    '    Return False
    'End If

    'If txtFromitem.Text > txtToitem.Text Then
    '    MsgBox("Item No: To < From!")
    '    Return False
    'End If

    'If txtFromjob.Text > txtTojob.Text Then
    '    MsgBox("Job No: To < From!")
    '    Return False
    'End If

    'If txtFromSC.Text > txtToSC.Text Then
    '    MsgBox("SC No: To < From!")
    '    Return False
    '    'End If

    '    Return True
    'End Function
	
	 Public Class GenericListItem(Of T)
        Private _Text As String
        Private _Value As T

        Public Sub New(ByVal Text As String, ByVal Value As T)
            _Text = Text
            _Value = Value
        End Sub

        Public Property Text() As String
            Get
                Return _Text
            End Get
            Set(ByVal Text As String)
                _Text = Text
            End Set
        End Property

        Public Property Value() As T
            Get
                Return _Value
            End Get
            Set(ByVal Value As T)
                _Value = Value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return _Text
        End Function
    End Class

    Private Sub AddSearchBtnHandler()
        textboxlist.Add(txt_S_ContainNo, "cmd_S_ContainNo")
        textboxlist.Add(txt_S_PriCustAll, "cmd_S_PriCustAll")
        textboxlist.Add(txt_S_SecCustAll, "cmd_S_SecCustAll")
        textboxlist.Add(txt_S_SCNo, "cmd_S_SCNo")
        textboxlist.Add(txt_S_ItmNo, "cmd_S_ItmNo")
        textboxlist.Add(txt_S_CustItmNo, "cmd_S_CustItmNo")
        textboxlist.Add(txt_S_PriceTerm, "cmd_S_PriceTerm")
        textboxlist.Add(txt_S_CustPONo, "cmd_S_CustPONo")


        'AddHandler cmd_S_ContainNo.Click, AddressOf cmd_S_Click
        'AddHandler txt_S_PriCustAll.Click, AddressOf cmd_S_Click
        'AddHandler txt_S_SecCustAll.Click, AddressOf cmd_S_Click
        'AddHandler txt_S_SCNo.Click, AddressOf cmd_S_Click
        'AddHandler txt_S_ItmNo.Click, AddressOf cmd_S_Click
        'AddHandler txt_S_CustItmNo.Click, AddressOf cmd_S_Click
        'AddHandler txt_S_PriceTerm.Click, AddressOf cmd_S_Click
        'AddHandler txt_S_CustPONo.Click, AddressOf cmd_S_Click


    End Sub

    'Private Sub cmd_S_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim trigger_btn As Button = CType(sender, Button)
    '    Dim btn_name As String = trigger_btn.Name
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = textboxlist(btn_name).Name
    '    frmComSearch.callFmString = textboxlist(btn_name).Text
    '    frmComSearch.show_MSR00027(trigger_btn)
    'End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim flg_exit As Boolean = False

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        'Check any invalid Input and escape special character
        If CheckUsrInput() Then
            MsgBox("Generate Report Fail!")
            Exit Sub
        End If

        Dim ContainList As String = txt_S_ContainNo.Text.Replace("'", "''")
        Dim PriCusList As String = txt_S_PriCustAll.Text.Replace("'", "''")
        Dim SecCustList As String = txt_S_SecCustAll.Text.Replace("'", "''")
        Dim SCNoList As String = txt_S_SCNo.Text.Replace("'", "''")
        Dim ItmList As String = txt_S_ItmNo.Text.Replace("'", "''")
        Dim CustItemList As String = txt_S_CustItmNo.Text.Replace("'", "''")
        Dim PriceTermList As String = txt_S_PriceTerm.Text.Replace("'", "''")
        Dim CustPOList As String = txt_S_CustPONo.Text.Replace("'", "''")

        Dim opt_sort As String
        If cb_sort.Text = "S/C No" Then
            opt_sort = "S"
        ElseIf cb_sort.Text = "Job No" Then
            opt_sort = "J"
        ElseIf cb_sort.Text = "Container No" Then
            opt_sort = "C"
        Else
            opt_sort = "I"
        End If

        ETDFm = txtETDFm.Text()
        ETDTo = txtETDTo.Text

        gspStr = "sp_select_MSR00027_A '" & gsCompany & "','" & _
                    ContainList & "','" & _
                    PriCusList & "','" & _
                    SecCustList & "','" & _
                    SCNoList & "','" & _
                    ItmList & "','" & _
                    CustItemList & "','" & _
                    PriceTermList & "','" & _
                    CustPOList & "','" & _
                    ETDFm & "','" & _
                    ETDTo & "','" & _
                    opt_sort & "','" & _
                    gsUsrID & "','" & _
                    gsSalTem & "'"

        Me.Cursor = Cursors.WaitCursor
        'Relocation to report server
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        rtnLong = execute_SQLStatementRPT(gspStr, rs_MSR00027, rtnStr)

        Me.Cursor = Cursors.Default

        '*** An error has occured
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_MSR00027_A:" & rtnStr)
            Exit Sub
        End If

        If rs_MSR00027.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No record found !")
            Exit Sub
        Else

            rs_EXCEL = rs_MSR00027
            Call GenExcel()


        End If




    End Sub


    Private Function CheckUsrInput() As Boolean
        For i As Integer = 1 To textboxlist.Count
            If (textboxlist(i).Text.Length > 1000) Then
                Dim tmp_labelname As String = "SLabel_" + i.ToString


                'Me.Controls.Find(tmp_labelname, True)
                MsgBox(" exceeds 1000 characters")
                Return True
            End If
        Next

        If txtETDFm.Text <> "  /  /" Then
            If Not IsDate(txtETDTo.Text) Then
                MsgBox("Invalid Date Format: ETD Ship Start Date From")
                txtETDFm.Focus()
                Return True
            End If
        Else

        End If

        If txtETDTo.Text <> "  /  /" Then
            If Not IsDate(txtETDTo.Text) Then
                MsgBox("Invalid Date Format: ETD Ship Start Date To")
                txtETDFm.Focus()
                Return True
            End If
        End If


        ETDFm = If(txtETDFm.Text = "  /  /", "01/01/1900", txtETDFm.Text)
        ETDTo = If(txtETDTo.Text = "  /  /", "01/01/2100", txtETDTo.Text)



        If CDate(ETDFm) > CDate(ETDTo) Then
            MsgBox("ETD Ship Start Date From > ETD Ship Start Date To")
            txtETDFm.Focus()
            Return True
        End If



        Return False
    End Function
    Private Sub GenExcel()
        On Error GoTo Err_Handler

        Me.Cursor = Cursors.WaitCursor  ' Change mouse pointer to hourglass.
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet


        Dim my_table As DataTable = rs_EXCEL.Tables("RESULT")


        Dim prev_SC As String = "-1"
        Dim cnt_emptyrow As Integer = 0
        'Dim my_datarow() As DataRow = my_table.Select("sod_ordno, sod_ordseq, sod_shpstr, sod_shpend,sds_scfrom,sds_scto, sds_dest")

        'Display Excel and give user control of Excel's lifetime
        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)
        xlApp.Visible = True
        xlApp.UserControl = True

        Dim strCompany As String

        Dim header_row As Integer = 5
        Dim datastart_row As Integer = 6

        'strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item("compName")

        With xlWs
            .Cells(1, 1) = "Report ID:"
            .Cells(1, 2) = "MSR00027"
            .Cells(1, 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight


            .Cells(2, 1) = "Print Date: "
            .Cells(2, 2) = Format(Now, "MM/dd/yyyy")
            .Range(.Cells(2, 2), .Cells(2, 2)).NumberFormatLocal = "mm/dd/yyyy"

            .Cells(3, 1) = "Print Time: "
            .Cells(3, 2) = Format(Now, "HH:mm:ss")
            .Range(.Cells(3, 2), .Cells(3, 2)).NumberFormatLocal = "HH:MM:SS"



            For i As Integer = 0 To excel_header.Length - 1
                .Cells(header_row, i + 1) = excel_header(i)
            Next

            For i As Integer = 0 To my_table.Rows.Count - 1
                'If i > 0 Then
                '    If my_table.Rows(i).Item("sod_ordno") <> prev_SC Then
                '        cnt_emptyrow = cnt_emptyrow + 1
                '    End If
                'End If

                For j As Integer = 0 To excel_header.Length - 1
                    .Cells(i + datastart_row + cnt_emptyrow, j + 1) = my_table.Rows(i).Item(excel_sqlcolname(j))
                Next
                prev_SC = my_table.Rows(i).Item("sod_ordno")
            Next
            'Input Data End

            'Apply Style Start
            xlWs.Cells(header_row, 1).EntireRow.Font.Bold = True
            xlWs.Cells.EntireColumn.AutoFit()

            Dim col_Desc As Integer = 10 'The DESCRIPTION Column
            xlWs.Cells(header_row, col_Desc).EntireColumn.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom

            'Apply Style End
        End With





        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        Me.Cursor = Cursors.Default
        Exit Sub

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Me.Cursor = Cursors.Default ' Return mouse pointer to normal.

        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing


        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing
    End Sub

    Dim excel_header As String() = { _
                                    "Shipping no.", _
                                    "Pri Customer no.", _
                                    "Sec Customer no.", _
                                    "Container no.", _
                                    "Seal no.", _
                                    "Container Size", _
                                    "Invoice no.", _
                                    "SC no.", _
                                    "Job no.", _
                                    "Purchase Order no.", _
                                    "Customer PO", _
                                    "Customer Item no.", _
                                    "Item no.", _
                                    "Item Description", _
                                    "Order Qty.", _
                                    "Shipped Qty.", _
                                    "Shipped Ctn.", _
                                    "Shipped CBM", _
                                    "Vessel", _
                                    "Voyage", _
                                    "Price Term", _
                                    "ETD", _
                                    "ETA", _
                                    "Loading Port", _
                                    "Destination", _
                                    "PV", _
                                    "FA" _
    }

    Dim excel_sqlcolname As String() = { _
        "hid_shpno", _
        "hih_cus1no", _
        "hih_cus2no", _
        "hid_ctrcfs", _
        "hid_sealno", _
        "hid_ctrsiz", _
        "hid_invno", _
        "sod_ordno", _
        "hid_jobno", _
        "hid_purord", _
        "sod_cuspo", _
        "hid_cusitm", _
        "hid_itmno", _
        "hid_itmdsc", _
        "sod_ordqty", _
        "hid_shpqty", _
        "hid_ttlctn", _
        "hid_ttlvol", _
        "hih_ves", _
        "hih_voy", _
        "ysi_dsc", _
        "hih_slnonb", _
        "hih_arrdat", _
        "hih_potloa", _
        "hih_dst", _
        "sod_venno", _
        "sod_examven" _
    }

    Private Sub cmd_S_ContainNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ContainNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ContainNo.Name
        frmComSearch.callFmString = txt_S_ContainNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ContainNo)
    End Sub

    Private Sub cmd_S_PriCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCustAll)
    End Sub

    Private Sub cmd_S_SecCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCustAll.Name
        frmComSearch.callFmString = txt_S_SecCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCustAll)

    End Sub

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        frmComSearch.show_frmS(Me.cmd_S_SCNo)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch
        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmd_S_CustItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustItmNo.Click
        Dim frmComSearch As New frmComSearch
        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CustItmNo.Name
        frmComSearch.callFmString = txt_S_CustItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_CustItmNo)
    End Sub

    Private Sub cmd_S_PriceTerm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriceTerm.Click
        Dim frmComSearch As New frmComSearch
        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriceTerm.Name
        frmComSearch.callFmString = txt_S_PriceTerm.Text

        frmComSearch.show_frmS(Me.cmd_S_PriceTerm)
    End Sub

    Private Sub cmd_S_CustPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustPONo.Click
        Dim frmComSearch As New frmComSearch
        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CustPONo.Name
        frmComSearch.callFmString = txt_S_CustPONo.Text

        frmComSearch.show_frmS(Me.cmd_S_CustPONo)
    End Sub
End Class