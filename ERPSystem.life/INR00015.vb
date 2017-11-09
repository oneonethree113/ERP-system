
Imports Excel = Microsoft.Office.Interop.Excel
Public Class INR00015

    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As DataSet
    Public rs_SYLNEINF As DataSet
    Public rs_SYCATCDE_level4 As DataSet

    Private Sub INR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()
    End Sub

    Private Sub Form_Load()
        Call Formstartup(Me.Name)

        Cursor = Cursors.WaitCursor

        initializeCombobox()

        Cursor = Cursors.Default
    End Sub
#Region "InitializeCombobox"
    Private Sub initializeCombobox()
        getComboboxCentent()

        fillCombobox()
    End Sub

    Private Sub getComboboxCentent()
        gspStr = "sp_list_VNBASINF  '' "
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on Form_Load  sp_list_VNBASINF  :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYLNEINF"
        rtnLong = execute_SQLStatement(gspStr, rs_SYLNEINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Form_Load sp_list_SYLNEINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYCATCDE_level '',4"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATCDE_level4, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Form_Load sp_select_SYCATCDE_level :" & rtnStr)
            Exit Sub
        End If
    End Sub

    Private Sub fillCombobox()
        FillcboVen()
        FillcboPrdLne()
        FillcboCategory()
    End Sub

    Private Sub FillcboVen()
        cboVenTo.Items.Clear()
        cboVenTo.Items.Add("")

        cboVenFm.Items.Clear()
        cboVenFm.Items.Add("")
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                cboVenTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
            Next
        End If
    End Sub

    Private Sub FillcboPrdLne()
        Dim i As Integer
        Dim strList As String

        cboPrdLneTo.Items.Clear()
        cboPrdLneTo.Items.Add("")

        cboPrdLneFrm.Items.Clear()
        cboPrdLneFrm.Items.Add("")

        If rs_SYLNEINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYLNEINF.Tables("RESULT").Rows.Count - 1
                strList = rs_SYLNEINF.Tables("RESULT").Rows(i).Item("yli_lnecde")
                If strList <> "" Then
                    cboPrdLneTo.Items.Add(strList)
                    cboPrdLneFrm.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub FillcboCategory()
        Dim i As Integer
        Dim strList As String

        cboCategoryFrm.Items.Clear()
        cboCategoryFrm.Items.Add("")
        cboCategoryTo.Items.Clear()
        cboCategoryTo.Items.Add("")

        If rs_SYCATCDE_level4.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCATCDE_level4.Tables("RESULT").Rows.Count - 1
                strList = rs_SYCATCDE_level4.Tables("RESULT").Rows(i).Item("ycc_catcde") & " - " & rs_SYCATCDE_level4.Tables("RESULT").Rows(i).Item("ycc_catdsc")
                If strList <> "" Then
                    cboCategoryFrm.Items.Add(strList)
                    cboCategoryTo.Items.Add(strList)
                End If
            Next i
        End If
    End Sub
#End Region
#Region "Small Function of control"
    Private Sub cboVenFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenFm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cboVenFm_LostFocus() Handles cboVenFm.LostFocus
        cboVenTo.Text = cboVenFm.Text
    End Sub

    Private Sub cboVenTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cboVenTo_GotFocus() Handles cboVenTo.GotFocus
        Me.cboVenTo.SelectionStart = 0
        Me.cboVenTo.SelectionLength = Len(Me.cboVenTo.Text)
    End Sub


    Private Sub cboPrdLneFrm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrdLneFrm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cboPrdLneFrm_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdLneFrm.LostFocus
        cboPrdLneTo.Text = cboPrdLneFrm.Text
    End Sub

    Private Sub cboPrdLneTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrdLneTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cboPrdLneTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdLneTo.GotFocus
        Me.cboPrdLneTo.SelectionStart = 0
        Me.cboPrdLneTo.SelectionLength = Len(Me.cboPrdLneTo.Text)
    End Sub


    Private Sub cboCategoryFrm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCategoryFrm.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cboCategoryFrm_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategoryFrm.LostFocus
        cboCategoryTo.Text = cboCategoryFrm.Text
    End Sub

    Private Sub cboCategoryTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCategoryTo.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cboCategoryTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategoryTo.GotFocus
        Me.cboCategoryTo.SelectionStart = 0
        Me.cboCategoryTo.SelectionLength = Len(Me.cboCategoryTo.Text)
    End Sub


    Private Sub ckbItemno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbItemno.CheckedChanged
        If txtItmnoTo.Enabled = True Then
            txtItmnoTo.Enabled = False
            txtItmnoTo.Text = ""
        Else
            txtItmnoTo.Enabled = True
        End If
    End Sub

    Private Sub ckbChiDesc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbChiDesc.CheckedChanged
        If txtChiDescTo.Enabled = True Then
            txtChiDescTo.Enabled = False
            txtChiDescTo.Text = ""
        Else
            txtChiDescTo.Enabled = True
        End If
    End Sub

    Private Sub ckbEngDesc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbEngDesc.CheckedChanged
        If txtEngDescTo.Enabled = True Then
            txtEngDescTo.Enabled = False
            txtEngDescTo.Text = ""
        Else
            txtEngDescTo.Enabled = True
        End If
    End Sub

    Private Sub cboStatus_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboStatus.KeyUp
        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Delete Then
            Call auto_search_combo(sender)
        End If
    End Sub
#End Region


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If Not validInput() Then
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Dim rs_INR00015 As New ADODB.Recordset
        Dim getDataSuccess As Boolean
        getDataSuccess = getItemDescPhoto(rs_INR00015)

        If Not getDataSuccess Then
            MsgBox("Fail to get data!")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If rs_INR00015.RecordCount = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        generateReportExcel(rs_INR00015)

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Function validInput() As Boolean

        If Me.cboVenFm.Text > Me.cboVenTo.Text Then
            MsgBox("Vendor No : From > To")
            cboVenFm.Focus()
            Return False
        End If

        If ckbItemno.Checked And txtItmnoFrm.Text = "" Then
            MsgBox("Item no field must be filled in the partial mode")
            txtItmnoFrm.Focus()
            Return False
        End If

        If ckbItemno.Checked = False And Me.txtItmnoFrm.Text > Me.txtItmnoTo.Text Then
            MsgBox("Item No : From > To")
            txtItmnoFrm.Focus()
            Return False
        End If

        If ckbChiDesc.Checked And txtChiDescFrm.Text = "" Then
            MsgBox("Chinese description field must be filled in the partial mode")
            txtItmnoFrm.Focus()
            Return False
        End If

        If ckbChiDesc.Checked = False And Me.txtChiDescFrm.Text > Me.txtChiDescTo.Text Then
            MsgBox("Chinese description : From > To")
            txtItmnoFrm.Focus()
            Return False
        End If


        If ckbEngDesc.Checked And txtEngDescFrm.Text = "" Then
            MsgBox("English description field must be filled in the partial mode")
            txtEngDescFrm.Focus()
            Return False
        End If

        If ckbEngDesc.Checked = False And Me.txtEngDescFrm.Text > Me.txtEngDescTo.Text Then
            MsgBox("English description : From > To")
            txtChiDescFrm.Focus()
            Return False
        End If

        If cboPrdLneFrm.Text > cboPrdLneTo.Text Then
            MsgBox("Product Line Code From > To!")
            cboPrdLneFrm.Focus()
            Return False
        End If

        If cboCategoryFrm.Text > cboCategoryTo.Text Then
            MsgBox("Category Code From > To!")
            cboCategoryFrm.Focus()
            Return False
        End If

        If Not IsDate(txtUpddatFm.Text) Then
            MsgBox("Invalid Transaction Date", MsgBoxStyle.Information, "Invalid Input Parameter")
            txtUpddatFm.Focus()
            txtUpddatFm.SelectAll()
            Return False
        End If

        If Not IsDate(txtUpddatTo.Text) Then
            MsgBox("Invalid Transaction Date", MsgBoxStyle.Information, "Invalid Input Parameter")
            txtUpddatTo.Focus()
            txtUpddatTo.SelectAll()
            Return False
        End If

        If CDate(txtUpddatFm.Text) > CDate(txtUpddatTo.Text) Then
            MsgBox("Transaction End Date must be later or equal to Start Date", MsgBoxStyle.Information, "Invalid Input Parameter")
            txtUpddatTo.Focus()
            txtUpddatTo.SelectAll()
            Return False
        End If

        Return True
    End Function

    Function getItemDescPhoto(ByRef rs_INR00015 As ADODB.Recordset) As Boolean
        gspStr = "sp_select_INR00015 '" _
                    & Trim(Replace(Split(cboVenFm.Text, " - ")(0), "'", "''")) & "','" _
                    & Trim(Replace(Split(cboVenTo.Text, " - ")(0), "'", "''")) & "','" _
                    & Trim(Replace(txtItmnoFrm.Text, "'", "''")) & "','" _
                    & Trim(Replace(txtItmnoTo.Text, "'", "''")) & "','" _
                    & IIf(ckbItemno.Checked, "Y", "N") & "','" _
                    & Trim(Replace(txtChiDescFrm.Text, "'", "''")) & "','" _
                    & Trim(Replace(txtChiDescTo.Text, "'", "''")) & "','" _
                    & IIf(ckbChiDesc.Checked, "Y", "N") & "','" _
                    & Trim(Replace(txtEngDescFrm.Text, "'", "''")) & "','" _
                    & Trim(Replace(txtEngDescTo.Text, "'", "''")) & "','" _
                    & IIf(ckbEngDesc.Checked, "Y", "N") & "','" _
                    & Replace(Split(cboStatus.Text, " - ")(0), "'", "''") & "','" _
                    & Trim(Replace(cboPrdLneFrm.Text, "'", "''")) & "','" _
                    & Trim(Replace(cboPrdLneTo.Text, "'", "''")) & "','" _
                    & Trim(Replace(Split(cboCategoryFrm.Text, " - ")(0), "'", "''")) & "','" _
                    & Trim(Replace(Split(cboCategoryTo.Text, " - ")(0), "'", "''")) & "','" _
                    & txtUpddatFm.Text & "','" _
                    & txtUpddatTo.Text & "','" _
                    & IIf(ckbWithPhoto.Checked, "Y", "N") & "'"
        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs_INR00015, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading INR00015 sp_select_INR00015 : " & rtnStr)
            Return False
        End If

        Return True
    End Function

    Private Sub generateReportExcel(ByRef rs_INR00015 As ADODB.Recordset)
        ''''Start: Dont care about this part. This is the code farmat to call a excel'''''''
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet
        ''''End: Dont care about this part. This is the code farmat to call a excel''''''''''''
        Const HeaderRow As Integer = 1
        Const FirstCol As Integer = 1
        fillContentToExcel(xlsApp, HeaderRow, FirstCol, rs_INR00015)
        setExcelFormat(xlsApp, HeaderRow, FirstCol, rs_INR00015)

        Me.Cursor = Windows.Forms.Cursors.Default
        xlsApp.Visible = True
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing
    End Sub

    Private Sub fillContentToExcel(ByVal xlsApp As Excel.Application, ByVal HeaderRow As Integer, ByVal curCol As Integer, ByRef rs_INR00015 As ADODB.Recordset)
        xlsApp.Cells(HeaderRow + 1, curCol).copyfromrecordset(rs_INR00015)
    End Sub

    Private Sub setExcelFormat(ByVal xlsApp As Excel.Application, ByVal HeaderRow As Integer, ByVal curCol As Integer, ByRef rs_INR00015 As ADODB.Recordset)
        With xlsApp
            'Header Initialization

            .Cells(HeaderRow, curCol).Value = "Item No."
            .Columns(curCol).ColumnWidth = 17
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

            .Cells(HeaderRow + 1, curCol + 1).Select() 'Freeze cell
            .ActiveWindow.FreezePanes = True

            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "Item Status"
            .Columns(curCol).ColumnWidth = 10
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "DV"
            .Columns(curCol).ColumnWidth = 5
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "Eng Desc"
            .Columns(curCol).ColumnWidth = 50
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Columns(curCol).WrapText = True
            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "Chin Desc"
            .Columns(curCol).ColumnWidth = 50
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Columns(curCol).WrapText = True
            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "Product Line"
            .Columns(curCol).ColumnWidth = 12
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "Category L4"
            .Columns(curCol).ColumnWidth = 15
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "Category L4 Name"
            .Columns(curCol).ColumnWidth = 50
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(HeaderRow, curCol).Value = "Item W/ Photo"
            .Columns(curCol).ColumnWidth = 14
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Range(xlsApp.Cells(HeaderRow, 1), xlsApp.Cells(HeaderRow, curCol)).AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)

            .Range(.Columns(1), .Columns(curCol)).VerticalAlignment = Excel.Constants.xlCenter
        End With
    End Sub

End Class
