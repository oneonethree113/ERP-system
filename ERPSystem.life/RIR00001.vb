Imports Excel = Microsoft.Office.Interop.Excel


Public Class RIR00001

    Dim textboxlist As New Collection() 'a dictionary storing the index and the textbox object

    Dim QutCreDatFrom As String
    Dim QutCreDatTo As String

    Dim rs_Result As DataSet



    Private Sub MSR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(cboCocde, txtCoNam)

        'If gsDefaultCompany <> "MS" Then
        '    cboCocde.Items.Add("UC-G")
        'End If

        Call AddSearchBtnHandler()
        Call Formstartup(Me.Name)
    End Sub

    'Company Box Start
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
    'Company Box End



    Private Sub AddSearchBtnHandler()
        textboxlist.Add(txt_S_PriCustAll, "cmd_S_PriCustAll")
        textboxlist.Add(txt_S_SecCustAll, "cmd_S_SecCustAll")
        textboxlist.Add(txt_S_QutNo, "cmd_S_QutNo")

        AddHandler cmd_S_PriCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SecCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_QutNo.Click, AddressOf cmd_S_Click

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

    Private Function CheckUsrInput() As Boolean
        CheckUsrInput = False

        For i As Integer = 1 To textboxlist.Count
            If (textboxlist(i).Text.Length > 1000) Then
                'Dim tmp_labelname As String = "SLabel_" + i.ToString
                'Dim label() As Control = Controls.Find(tmp_labelname, True)

                'Me.Controls.Find(tmp_labelname, True)
                MsgBox("Textbox exceeds 1000 characters")
                Exit Function
            End If
        Next

        If txtQutdatFm.Text <> "  /  /" Then
            If Not IsDate(txtQutdatFm.Text) Then
                MsgBox("Invalid Date Format: Qut Create Date From")
                txtQutdatFm.Focus()
                Exit Function
            End If
        Else

        End If

        If txtQutdatTo.Text <> "  /  /" Then
            If Not IsDate(txtQutdatTo.Text) Then
                MsgBox("Invalid Date Format: Qut Create Date To")
                txtQutdatFm.Focus()
                Exit Function
            End If
        End If


        QutCreDatFrom = If(txtQutdatFm.Text = "  /  /", "01/01/1900", txtQutdatFm.Text)
        QutCreDatTo = If(txtQutdatTo.Text = "  /  /", "01/01/2100", txtQutdatTo.Text)



        If CDate(QutCreDatFrom) > CDate(QutCreDatTo) Then
            MsgBox("Qut Create Date From > Qut Create Date To")
            txtQutdatFm.Focus()
            Exit Function
        End If

        CheckUsrInput = True
    End Function



    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCocde.Text)
        Call Update_gs_Value(gsCompany)

        'Check any invalid Input and escape special character
        If CheckUsrInput() = False Then
            MsgBox("Generate Report Fail!")
            Exit Sub
        End If

        Dim PriCustList As String = txt_S_PriCustAll.Text.Replace("'", "''")
        Dim SecCustList As String = txt_S_SecCustAll.Text.Replace("'", "''")
        Dim QutNoList As String = txt_S_QutNo.Text.Replace("'", "''")

        gspStr = "sp_select_RIR00001 '" & gsCompany & "','" & _
            PriCustList & "','" & _
            SecCustList & "','" & _
            QutNoList & "','" & _
            QutCreDatFrom & "','" & _
            QutCreDatTo & "'"


        Me.Cursor = Cursors.WaitCursor
        'rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        rtnLong = execute_SQLStatementRPT(gspStr, rs_Result, rtnStr)

        Me.Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_RIR00001:" & rtnStr)
            Exit Sub
        End If

        If rs_Result.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No record found !")
            Exit Sub
        End If


        Call GenExcel()



    End Sub

    Private Sub GenExcel()
        On Error GoTo Err_Handler


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook = Nothing
        Dim xlWs As Excel.Worksheet = Nothing

        'Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")

        Dim my_table As DataTable = rs_Result.Tables("RESULT")

        xlApp = New Excel.Application
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)
        xlApp.Visible = True
        xlApp.UserControl = True




        Dim header_row As Integer = 1
        Dim datastart_row As Integer = 2

        With xlApp
            For i As Integer = 0 To excel_header.Length - 1
                .Cells(header_row, i + 1) = excel_header(i)
            Next

            'Insert Data Start
            For i As Integer = 0 To my_table.Rows.Count - 1

                For j As Integer = 0 To excel_header.Length - 1
                    .Cells(i + datastart_row, j + 1) = my_table.Rows(i).Item(j)
                Next
            Next


            'Apply Style Start
            .Cells(header_row, 1).EntireRow.Font.Bold = True
            .Cells.EntireColumn.AutoFit()

            Dim col_Desc As Integer = 10 'The DESCRIPTION Column
            .Cells(header_row, col_Desc).EntireColumn.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
        End With


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
        rs_Result = Nothing

        ' Release Excel references
        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub

    Dim excel_header As String() = { _
        "Quotation No", _
        "Item No", _
        "Packing & Terms" _
    }



End Class