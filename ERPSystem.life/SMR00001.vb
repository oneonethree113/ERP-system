Imports Excel = Microsoft.Office.Interop.Excel

Public Class SMR00001

    Dim objBSGate As Object

    Public rs_EXCEL As DataSet
    Public rs_CUBASINF As DataSet
    Public rs_VNBASINF As DataSet

    Private Enq_right_local As Boolean
    Private Del_right_local As Boolean

    Private Enum enu_SMR
        hiv_invno
        inv_dat
        cust_cde
        cust_po
        pod_scno
        pod_jobord
        pod_itmno
        sod_ordqty
        hid_shpqty
        pod_untcde
        sod_curcde
        sod_untprc
        poh_purord
        pod_ordqty
        poh_curcde
        pod_ftyprc
        fty
        poh_discnt
        po_disc
        po_prem
    End Enum

    Private Sub FillcboCust()
        Dim strFromCust As String
        Dim strToCust As String

        Dim dr() As DataRow

        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '60000'")

            For i As Integer = 0 To dr.Length - 1
                cboCustNoFm.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
                cboCustNoTo.Items.Add(dr(i)("cbi_cusno") & " - " & dr(i)("cbi_cussna"))
            Next

            cboCustNoFm.SelectedIndex = 0
            cboCustNoTo.SelectedIndex = cboCustNoTo.Items.Count - 1
        End If




    End Sub
    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboPVenNoFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboPVenNoTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboVenNoFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboVenNoTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            Next
        End If
    End Sub



    Private Sub selComboBox(ByRef cbo As ComboBox)
        If cbo.Enabled = True Then
            If cbo.Text <> "" Then
                cbo.SelectionStart = 0
                cbo.SelectionLength = Len(cbo.Text)
            End If
        End If
    End Sub


    Public Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If

        ValidateCombo = False

        Dim i As Integer
        Dim S As String

        S = Combo1.Text

        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items.Item(i)) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next

        If Not ValidateCombo Then
            MsgBox("Invalid Data! Please try again.")
        End If
    End Function


    Private Function isEmptyForm() As Boolean
        isEmptyForm = False
        If Trim(Me.cboCustNoFm.Text) <> "" Or Trim(Me.cboCustNoTo.Text) <> "" Then Exit Function
        If Trim(Me.cboVenNoFm.Text) <> "" Or Trim(Me.cboVenNoTo.Text) <> "" Then Exit Function
        If Trim(Me.cboPVenNoFm.Text) <> "" Or Trim(Me.cboPVenNoTo.Text) <> "" Then Exit Function
        If Trim(Me.txtCustPOFm.Text) <> "" Or Trim(Me.txtCustPOTo.Text) <> "" Then Exit Function
        If Trim(Me.txtSCFm.Text) <> "" Or Trim(Me.txtSCTo.Text) <> "" Then Exit Function
        If Trim(Me.txtPOFm.Text) <> "" Or Trim(Me.txtPOTo.Text) <> "" Then Exit Function
        If Trim(Me.txtItemFm.Text) <> "" Or Trim(Me.txtItemTo.Text) <> "" Then Exit Function
        If Trim(Me.txtJobNoFm.Text) <> "" Or Trim(Me.txtJobNoTo.Text) <> "" Then Exit Function
        If Trim(Me.txtInvFm.Text) <> "" Or Trim(Me.txtInvTo.Text) <> "" Then Exit Function
        If Trim(Me.txtIssDatFm.Text) <> "__/__/____" Or Trim(Me.txtIssDatTo.Text) <> "__/__/____" Then Exit Function
        If Trim(Me.txtEtdDatFm.Text) <> "__/__/____" Or Trim(Me.txtEtdDatTo.Text) <> "__/__/____" Then Exit Function
        isEmptyForm = True
    End Function
    Private Function validateForm() As Boolean
        validateForm = False


        If isEmptyForm() = True Then
            MsgBox("Please provide one/more selection criteria!")
            Exit Function
        End If
        'Customer No
        If Trim(Me.cboCustNoFm.Text) <> "" And Trim(Me.cboCustNoTo.Text) = "" Then
            Me.cboCustNoTo.Text = Trim(Me.cboCustNoFm.Text)
        End If
        If Trim(Me.cboCustNoFm.Text) = "" And Trim(Me.cboCustNoTo.Text) <> "" Then
            Me.cboCustNoFm.Text = Trim(Me.cboCustNoTo.Text)
        End If
        'Vendor No
        If Trim(Me.cboVenNoFm.Text) <> "" And Trim(Me.cboVenNoTo.Text) = "" Then
            Me.cboVenNoTo.Text = Trim(Me.cboVenNoFm.Text)
        End If
        If Trim(Me.cboVenNoFm.Text) = "" And Trim(Me.cboVenNoTo.Text) <> "" Then
            Me.cboVenNoFm.Text = Trim(Me.cboVenNoTo.Text)
        End If
        'P Vendor No
        If Trim(Me.cboPVenNoFm.Text) <> "" And Trim(Me.cboPVenNoTo.Text) = "" Then
            Me.cboPVenNoTo.Text = Trim(Me.cboPVenNoFm.Text)
        End If
        If Trim(Me.cboPVenNoFm.Text) = "" And Trim(Me.cboPVenNoTo.Text) <> "" Then
            Me.cboPVenNoFm.Text = Trim(Me.cboPVenNoTo.Text)
        End If
        'Customer PO No
        If Trim(Me.txtCustPOFm.Text) <> "" And Trim(Me.txtCustPOTo.Text) = "" Then
            Me.txtCustPOTo.Text = Trim(Me.txtCustPOFm.Text)
        End If
        If Trim(Me.txtCustPOFm.Text) = "" And Trim(Me.txtCustPOTo.Text) <> "" Then
            Me.txtCustPOFm.Text = Trim(Me.txtCustPOTo.Text)
        End If

        'S/C No
        If Trim(Me.txtSCFm.Text) <> "" And Trim(Me.txtSCTo.Text) = "" Then
            Me.txtSCTo.Text = Me.txtSCFm.Text
        End If
        If Trim(Me.txtSCFm.Text) = "" And Trim(Me.txtSCTo.Text) <> "" Then
            Me.txtSCFm.Text = Trim(Me.txtSCTo.Text)
        End If

        'Vendor PO No
        If Trim(Me.txtPOFm.Text) <> "" And Trim(Me.txtPOTo.Text) = "" Then
            Me.txtPOTo.Text = Trim(Me.txtPOFm.Text)
        End If
        If Trim(Me.txtPOFm.Text) = "" And Trim(Me.txtPOTo.Text) <> "" Then
            Me.txtPOFm.Text = Trim(Me.txtPOTo.Text)
        End If
        'Item No
        If Trim(Me.txtItemFm.Text) <> "" And Trim(Me.txtItemTo.Text) = "" Then
            Me.txtItemTo.Text = Trim(Me.txtItemFm.Text)
        End If
        If Trim(Me.txtItemFm.Text) = "" And Trim(Me.txtItemTo.Text) <> "" Then
            Me.txtItemFm.Text = Trim(Me.txtItemTo.Text)
        End If
        'Job No
        If Trim(Me.txtJobNoFm.Text) <> "" And Trim(Me.txtJobNoTo.Text) = "" Then
            Me.txtJobNoTo.Text = Trim(Me.txtJobNoFm.Text)
        End If
        If Trim(Me.txtJobNoFm.Text) = "" And Trim(Me.txtJobNoTo.Text) <> "" Then
            Me.txtJobNoFm.Text = Trim(Me.txtJobNoTo.Text)
        End If
        'Invoice No
        If Trim(Me.txtInvFm.Text) <> "" And Trim(Me.txtInvTo.Text) = "" Then
            Me.txtInvTo.Text = Trim(Me.txtInvFm.Text)
        End If
        If Trim(Me.txtInvFm.Text) = "" And Trim(Me.txtInvTo.Text) <> "" Then
            Me.txtInvFm.Text = Trim(Me.txtInvTo.Text)
        End If
        'Invoice Issue Date
        If Trim(Me.txtIssDatFm.Text) <> "__/__/____" And Trim(Me.txtIssDatTo.Text) = "__/__/____" Then
            Me.txtIssDatTo.Text = Trim(Me.txtIssDatFm.Text)
        End If
        If Me.txtIssDatFm.Text = "__/__/____" And Me.txtIssDatTo.Text <> "__/__/____" Then
            Me.txtIssDatFm.Text = Me.txtIssDatTo.Text
        End If
        'ETD Date
        If Trim(Me.txtEtdDatFm.Text) <> "__/__/____" And Trim(Me.txtEtdDatTo.Text) = "__/__/____" Then
            Me.txtEtdDatTo.Text = Trim(Me.txtEtdDatFm.Text)
        End If
        If Me.txtEtdDatFm.Text = "__/__/____" And Me.txtEtdDatTo.Text <> "__/__/____" Then
            Me.txtEtdDatFm.Text = Me.txtEtdDatTo.Text
        End If

        'DoEvents()

        If Trim(Me.cboCustNoFm.Text) > Trim(Me.cboCustNoTo.Text) Then
            MsgBox("Customer No : From > To !")
            Me.cboCustNoFm.Focus()
            Exit Function
        End If
        If Trim(Me.cboVenNoFm.Text) > Trim(Me.cboVenNoTo.Text) Then
            MsgBox("Vendor No : From > To !")
            Me.cboVenNoFm.Focus()
            Exit Function
        End If
        If Trim(Me.cboPVenNoFm.Text) > Trim(Me.cboPVenNoTo.Text) Then
            MsgBox("P Vendor No : From > To !")
            Me.cboPVenNoFm.Focus()
            Exit Function
        End If
        If Trim(Me.txtCustPOFm.Text) > Trim(Me.txtCustPOTo.Text) Then
            MsgBox("Customer PO No : From > To !")
            Me.txtCustPOFm.Focus()
            Exit Function
        End If
        If Trim(Me.txtSCFm.Text) > Trim(Me.txtSCTo.Text) Then
            MsgBox("S/C No : From > To !")
            Me.txtSCFm.Focus()
            Exit Function
        End If
        If Trim(Me.txtPOFm.Text) > Trim(Me.txtPOTo.Text) Then
            MsgBox("Vendor PO No : From > To !")
            Me.txtPOFm.Focus()
            Exit Function
        End If
        If Trim(Me.txtItemFm.Text) > Trim(Me.txtItemTo.Text) Then
            MsgBox("Item No : From > To !")
            Me.txtItemFm.Focus()
            Exit Function
        End If
        If Trim(Me.txtJobNoFm.Text) > Trim(Me.txtJobNoTo.Text) Then
            MsgBox("Job No : From > To !")
            Me.txtJobNoFm.Focus()
            Exit Function
        End If
        If Trim(Me.txtInvFm.Text) > Trim(Me.txtInvTo.Text) Then
            MsgBox("Invoice No : From > To !")
            Me.txtInvFm.Focus()
            Exit Function
        End If
        If Me.txtIssDatFm.Text <> "  /  /" And Me.txtIssDatTo.Text <> "  /  /" Then
            If IsDate(Me.txtIssDatFm.Text) = False Then
                MsgBox("Invalid Issue Date From!")
                Me.txtIssDatFm.Focus()
                Exit Function
            End If
            If IsDate(Trim(Me.txtIssDatTo.Text)) = False Then
                MsgBox("Invalid Issue Date To!")
                Me.txtIssDatTo.Focus()
                Exit Function
            End If
            If CDate(Trim(Me.txtIssDatFm.Text)) > CDate(Trim(Me.txtIssDatTo.Text)) Then
                MsgBox("Invoice Issue Date : From > To !")
                Me.txtIssDatFm.Focus()
                Exit Function
            End If
        End If
        If Me.txtEtdDatFm.Text <> "  /  /" And Me.txtEtdDatTo.Text <> "  /  /" Then
            If IsDate(Me.txtEtdDatFm.Text) = False Then
                MsgBox("Invalid ETD Date From!")
                Me.txtEtdDatFm.Focus()
                Exit Function
            End If
            If IsDate(Trim(Me.txtEtdDatTo.Text)) = False Then
                MsgBox("Invalid ETD Date To!")
                Me.txtEtdDatTo.Focus()
                Exit Function
            End If
            If CDate(Trim(Me.txtEtdDatFm.Text)) > CDate(Trim(Me.txtEtdDatTo.Text)) Then
                MsgBox("ETD Date : From > To !")
                Me.txtEtdDatFm.Focus()
                Exit Function
            End If
        End If
        If Me.txtEtdDatFm.Text = "  /  /" And Me.txtEtdDatTo.Text = "  /  /" Then
            MsgBox("Shippment Date is manadatory field!")
            Me.txtEtdDatFm.Focus()
            Exit Function
        End If

        validateForm = True
    End Function

    Private Function getComboValue(ByRef cbo As ComboBox) As String
        Dim strTemp As String
        getComboValue = ""
        strTemp = Trim(cbo.Text)
        If InStr(strTemp, " - ") > 0 Then
            'strTemp = Left(strTemp, InStr(strTemp, " - ") - 1)
            strTemp = Split(strTemp, " - ")(0)
        End If
        getComboValue = strTemp
    End Function


    Private Sub ExportToExcel()
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

        lngRecCount = rs_EXCEL.Tables("RESULT").Rows.Count + 1
        If rs_EXCEL.Tables("RESULT").Rows.Count + 1 > 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
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


        'xlApp = CreateObject("Excel.Application")
        'xlWb = xlApp.Workbooks.Add
        'xlWs = xlWb.Worksheets(1)

        'xlApp.Visible = True
        'xlApp.UserControl = True

        'fldCount = rs_EXCEL.Fields.count

        fldCount = rs_EXCEL.Tables("RESULT").Columns.Count

        For iCol = 1 To fldCount
            'xlsWs.Cells(1, iCol).Value = rs_EXCEL.Fields(iCol - 1).Name
            'xlsWs.Cells(1, iCol).value = rs_EXCEL.Tables("RESULT").Columns(iCol - 1).name
            xlsWs.Rows(1).Font.Bold = True
            xlsWs.Rows(1).Font.Size = 10
            'xlWs.Rows(1).Font.Underline = True
        Next

        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Set Form Style

        With xlsWs
            'header's format
            .Range(.Cells(1, 1), .Cells(1, fldCount)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
            'content's format
            .Range(.Cells(2, enu_SMR.pod_itmno + 1), .Cells(lngRecCount, enu_SMR.pod_itmno + 1)).NumberFormatLocal = "@"
            .Range(.Cells(2, enu_SMR.poh_purord + 1), .Cells(lngRecCount, enu_SMR.poh_purord + 1)).NumberFormatLocal = "@"
            .Range(.Cells(2, enu_SMR.sod_untprc + 1), .Cells(lngRecCount, enu_SMR.sod_untprc + 1)).NumberFormatLocal = "0.0000"
            .Range(.Cells(2, enu_SMR.pod_ftyprc + 1), .Cells(lngRecCount, enu_SMR.pod_ftyprc + 1)).NumberFormatLocal = "0.0000"
            .Range(.Cells(2, enu_SMR.poh_discnt + 1), .Cells(lngRecCount, enu_SMR.poh_discnt + 1)).NumberFormatLocal = "0.000"

            .Range(.Cells(2, 4 + 7), .Cells(lngRecCount, 8)).NumberFormatLocal = "@"    'Item NO
            .Range(.Cells(2, 4 + 1), .Cells(lngRecCount, 4 + 1)).NumberFormatLocal = "@"    'Customer PO No
            .Range(.Cells(2, 32), .Cells(lngRecCount, 33)).NumberFormatLocal = "@" 'customer Payment Term
            .Range(.Cells(2, 34), .Cells(lngRecCount, 35)).NumberFormatLocal = "@" 'PV Payment Term
            .Range(.Cells(2, 36), .Cells(lngRecCount, 37)).NumberFormatLocal = "@" 'Invoice Payment Term

        End With

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------

        Dim entry(rs_EXCEL.Tables("RESULT").Rows.Count, fldCount - 1) As Object
        With xlsApp
            'Initializing Header Row'
            For i As Integer = 0 To fldCount - 1
                entry(0, i) = rs_EXCEL.Tables("RESULT").Columns(i).ColumnName.ToString
            Next

            'Populating Data
            For j As Integer = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                For i As Integer = 0 To fldCount - 1
                    entry(j + 1, i) = rs_EXCEL.Tables("RESULT").Rows(j)(i)
                Next
            Next

            .Range(.Cells(1, 1), .Cells(rs_EXCEL.Tables("RESULT").Rows.Count + 1, fldCount)).Value = entry
        End With

        'Not done yet
        'If Val(Mid(xlsApp.Version, 1, InStr(1, xlsApp.Version, ".") - 1)) > 8 Then
        '    'EXCEL 2000 or 2002: Use CopyFromRecordset
        '    xlsWs.Cells(2, 1).CopyFromRecordset(rs_EXCEL)
        'Else
        '    'EXCEL 97 or earlier: Use GetRows then copy array to Excel
        '    recArray = rs_EXCEL.GetRows
        '    recCount = UBound(recArray, 2) + 1
        '    For iCol = 0 To fldCount - 1
        '        For iRow = 0 To recCount - 1
        '            If IsDate(recArray(iCol, iRow)) Then
        '                recArray(iCol, iRow) = Format(recArray(iCol, iRow))
        '            ElseIf IsArray(recArray(iCol, iRow)) Then
        '                recArray(iCol, iRow) = "Array Field"
        '            End If
        '        Next iRow
        '    Next iCol

        '    xlWs.Cells(2, 1).resize(recCount, fldCount).Value = recArray

        'End If

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        xlsWs.Rows(1).RowHeight = 25
        xlsApp.Visible = True

        rs_EXCEL = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default

        Exit Sub
Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Cursor = Cursors.Default
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_EXCEL = Nothing

        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing


    End Sub
    '==================================================================
    '==================================================================



    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        If cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
    End Sub


    Private Sub cboCustNoFm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoFm.SelectedIndexChanged
        cboCustNoTo.Text = cboCustNoFm.Text
    End Sub

    Private Sub cboCustNoFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoFm.GotFocus
        Call selComboBox(cboCustNoFm)
    End Sub

    Private Sub cboCustNoFm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoFm.KeyUp
        Call auto_search_combo(cboCustNoFm)
    End Sub

    Private Sub cboCustNoFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCustNoFm.Validating
        If ValidateCombo(cboCustNoFm) = False Then
            e.Cancel = True
        End If
    End Sub


    Private Sub cboCustNoTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustNoTo.GotFocus
        Call selComboBox(cboCustNoTo)
    End Sub

    Private Sub cboCustNoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustNoTo.KeyUp
        Call auto_search_combo(cboCustNoTo)
    End Sub

    Private Sub cboCustNoTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCustNoTo.Validating
        If ValidateCombo(cboCustNoTo) = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cboVenNoFm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenNoFm.SelectedIndexChanged
        cboVenNoTo.Text = cboVenNoFm.Text
    End Sub


    Private Sub cboVenNoFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenNoFm.GotFocus
        Call selComboBox(cboVenNoFm)
    End Sub

    Private Sub cboVenNoFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoFm.KeyUp
        Call auto_search_combo(cboVenNoFm)
    End Sub

    Private Sub cboVenNoFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenNoFm.Validating
        If ValidateCombo(cboVenNoFm) = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cboVenNoTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenNoTo.GotFocus
        Call selComboBox(cboVenNoTo)
    End Sub

    Private Sub cboVenNoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoTo.KeyUp
        auto_search_combo(cboVenNoTo)
    End Sub

    Private Sub cboVenNoTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenNoTo.Validating
        If ValidateCombo(cboVenNoTo) = False Then
            e.Cancel = True
        End If
    End Sub



    Private Sub cboPVenNoFm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPVenNoFm.SelectedIndexChanged
        cboPVenNoTo.Text = cboPVenNoFm.Text
    End Sub


    Private Sub cboPVenNoFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPVenNoFm.GotFocus
        Call selComboBox(cboPVenNoFm)
    End Sub

    Private Sub cboPVenNoFm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPVenNoFm.KeyUp
        Call auto_search_combo(cboPVenNoFm)
    End Sub

    Private Sub cboPVenNoFm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPVenNoFm.Validating
        If ValidateCombo(cboPVenNoFm) = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPVenNoTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPVenNoTo.GotFocus
        Call selComboBox(cboVenNoTo)
    End Sub

    Private Sub cboPVenNoTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPVenNoTo.KeyUp
        auto_search_combo(cboPVenNoTo)
    End Sub

    Private Sub cboPVenNoTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPVenNoTo.Validating
        If ValidateCombo(cboPVenNoTo) = False Then
            e.Cancel = True
        End If
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim S As String
        Dim rs As DataSet

        If validateForm() = False Then
            Exit Sub
        End If

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        Dim layout As String
        If optRptLayout000.Checked Then
            layout = "000"
        Else
            layout = "001"
        End If

        gspStr = "sp_select_SMR00001 '" & IIf(cboCoCde.Text = "UC-G", "ALL", cboCoCde.Text) & "','" & _
            getComboValue(Me.cboCustNoFm) & "','" & getComboValue(Me.cboCustNoTo) & "','" & _
            getComboValue(Me.cboVenNoFm) & "','" & getComboValue(Me.cboVenNoTo) & "','" & _
            getComboValue(Me.cboPVenNoFm) & "','" & getComboValue(Me.cboPVenNoTo) & "','" & _
            Trim(Me.txtCustPOFm.Text) & "','" & Trim(Me.txtCustPOTo.Text) & "','" & _
            Trim(Me.txtSCFm.Text) & "','" & Trim(Me.txtSCTo.Text) & "','" & _
            Trim(Me.txtPOFm.Text) & "','" & Trim(Me.txtPOTo.Text) & "','" & _
            Trim(Me.txtItemFm.Text) & "','" & Trim(Me.txtItemTo.Text) & "','" & _
            Trim(Me.txtJobNoFm.Text) & "','" & Trim(Me.txtJobNoTo.Text) & "','" & _
            Trim(Me.txtInvFm.Text) & "','" & Trim(Me.txtInvTo.Text) & "','" & _
            IIf(Trim(Me.txtIssDatFm.Text) = "/  /", "", Trim(Me.txtIssDatFm.Text)) & "','" & IIf(Trim(Me.txtIssDatTo.Text) = "/  /", "", Trim(Me.txtIssDatTo.Text)) & "','" & _
            IIf(Trim(Me.txtEtdDatFm.Text) = "/  /", "", Trim(Me.txtEtdDatFm.Text)) & "','" & IIf(Trim(Me.txtEtdDatTo.Text) = "/  /", "", Trim(Me.txtEtdDatTo.Text)) & "','" & _
            IIf(optVentyp_1.Checked, "I", IIf(optVentyp_2.Checked, "E", "B")) & "','" & _
            Me.cboSortBy.Text & "','" & _
            layout & "'"

        If optDataSource_P.Checked = True Then
            rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
        Else
            rtnLong = execute_SQLStatementRPT(gspStr, rs_EXCEL, rtnStr)
        End If

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdShow_Click sp_select_SMR00001 :" & rtnStr)
            Exit Sub
        End If


        Cursor = Cursors.WaitCursor

        'If optDataSource_P.Value = True Then
        '    rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        'Else
        '    rs = objBSGate.Enquire(gsConnStrRpt, "sp_general", S)
        'End If


        'rs_EXCEL = rs(1)
        If rs_EXCEL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
        Else
            Call ExportToExcel()
        End If
        Cursor = Cursors.Default
    End Sub



 

    Private Sub txtCustPOFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustPOFm.TextChanged
        Me.txtCustPOTo.Text = Me.txtCustPOFm.Text
    End Sub

    Private Sub txtCustPOFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustPOFm.GotFocus
        Call HighlightText(txtCustPOFm)
    End Sub



    Private Sub txtCustPOTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustPOTo.GotFocus
        Call HighlightText(txtCustPOTo)
    End Sub


    Private Sub txtInvFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvFm.TextChanged
        txtInvTo.Text = txtInvFm.Text
    End Sub

    Private Sub txtInvFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvFm.GotFocus
        Call HighlightText(txtInvFm)
    End Sub


    Private Sub txtInvTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvTo.GotFocus
        Call HighlightText(txtInvTo)
    End Sub


    Private Sub txtIssdatFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssDatFm.GotFocus
        Me.txtIssDatTo.Text = Me.txtIssDatFm.Text
    End Sub

    Private Sub txtIssdatFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssDatFm.GotFocus
        Call HighlightText(txtIssDatFm)
    End Sub

    Private Sub txtIssdatTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssDatTo.GotFocus
        Call HighlightText(txtIssDatTo)
    End Sub
 

    Private Sub txtEtddatFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEtdDatFm.TextChanged
        Me.txtEtdDatTo.Text = Me.txtEtdDatFm.Text
    End Sub


    Private Sub txtEtddatFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEtdDatFm.GotFocus
        Call HighlightText(txtEtdDatFm)
    End Sub

    Private Sub txtEtddatTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEtdDatTo.GotFocus
        Call HighlightText(txtEtdDatTo)
    End Sub


    Private Sub txtItemFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemFm.TextChanged
        Me.txtItemTo.Text = Me.txtItemFm.Text
    End Sub

    Private Sub txtItemFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemFm.GotFocus
        Call HighlightText(txtItemFm)
    End Sub

    Private Sub txtItemTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemTo.GotFocus
        Call HighlightText(txtItemTo)
    End Sub


    Private Sub txtJobNoFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNoFm.TextChanged
        Me.txtJobNoTo.Text = Me.txtJobNoFm.Text
    End Sub

    Private Sub txtJobNoFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNoFm.GotFocus
        Call HighlightText(txtJobNoFm)
    End Sub

    Private Sub txtJobNoTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNoTo.GotFocus
        Call HighlightText(txtJobNoTo)
    End Sub


    Private Sub txtPOFm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOFm.TextChanged
        Me.txtPOTo.Text = Me.txtPOFm.Text
    End Sub


    Private Sub txtPOFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOFm.GotFocus
        Call HighlightText(txtPOFm)
    End Sub


    Private Sub txtPOTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOTo.GotFocus
        Call HighlightText(txtPOTo)
    End Sub


    Private Sub txtSCfm_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCFm.TextChanged
        Me.txtSCTo.Text = Me.txtSCFm.Text
    End Sub


    Private Sub txtSCfm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCFm.GotFocus
        Call HighlightText(txtSCFm)
    End Sub

    Private Sub txtSCto_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCTo.GotFocus
        Call HighlightText(txtSCTo)
    End Sub





    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Public Sub HighlightText(ByVal t As MaskedTextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub




    Private Sub SMR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rs As DataSet

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        If gsDefaultCompany <> "MS" Then
            cboCoCde.Items.Add("UC-G")
        End If
        '    If gsConnStr = "" Then
        '    gsConnStr = getConnectionString()
        '    End If

        cboSortBy.Items.Clear()
        cboSortBy.Items.Add("Customer No. / Name")
        cboSortBy.Items.Add("PV - Vendor No. / Name")
        cboSortBy.Items.Add("Item No")
        cboSortBy.Items.Add("S/C No")
        cboSortBy.Items.Add("Customer PO No")
        cboSortBy.Items.Add("Vendor PO No")
        cboSortBy.Items.Add("Job No")
        cboSortBy.Items.Add("Invoice No")
        cboSortBy.Items.Add("Invoice Issue Date")
        cboSortBy.Items.Add("Shipment Date")
        cboSortBy.SelectedIndex = 0

        'Me.optVen(0).Value = True
        optVentyp_1.Checked = True
        'Fill in Customer No and Vendor No

        gspStr = "sp_list_CUBASINF '" & cboCoCde.Text & "','PA'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SMR00001 sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNBASINF '" & cboCoCde.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SMR00001 sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If

        Call FillcboCust()
        Call FillcboVen()
        '================================
        Call Formstartup(Me.Name)

    End Sub
End Class