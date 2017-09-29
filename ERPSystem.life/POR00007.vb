Imports Excel = Microsoft.Office.Interop.Excel

Public Class POR00007
    Public rs_EXCEL As DataSet
    Public rs_CUBASINF As DataSet
    Public rs_VNBASINF As DataSet

    Dim dr() As DataRow

    Private Enq_right_local As Boolean
    Private Del_right_local As Boolean

    Private Sub POR00007_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company

        cboCoCde.Items.Add("ALL")

        Call GetDefaultCompany(cboCoCde, txtCoNam)

        'Set Default BOM PO Status
        optAll.Checked = True
        optZeroN.Checked = True

        'Fill Available Report Type
        cboRptType.Items.Clear()
        cboRptType.Items.Add("PO Information")
        cboRptType.Items.Add("BOM Information")
        cboRptType.Items.Add("Both")
        cboRptType.SelectedIndex = 0

        'Fill in Customer No and Vendor No
        Cursor = Cursors.WaitCursor

        gspStr = "sp_list_CUBASINF '" & cboCoCde.Text & "','PA'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00007_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        gspStr = "sp_list_VNBASINF '" & cboCoCde.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POR00007_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If

        Call FillcboCust()
        Call FillcboVen()

        Call Formstartup(Me.Name)

        Cursor = Cursors.Default
    End Sub

    Private Sub FillcboCust()
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
                cboVenNoFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
                cboVenNoTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i)("vbi_vensna"))
            Next
        End If
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        If cboCoCde.Text <> "ALL" Then
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

    Private Sub txtBomPONoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBomPONoFm.TextChanged
        txtBomPONoTo.Text = txtBomPONoFm.Text
    End Sub

    Private Sub txtBomPONoFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBomPONoFm.GotFocus
        Call HighlightText(txtBomPONoFm)
    End Sub

    Private Sub txtBomPONoTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBomPONoTo.GotFocus
        Call HighlightText(txtBomPONoTo)
    End Sub

    Private Sub txtJobNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNoFm.TextChanged
        txtJobNoTo.Text = txtJobNoFm.Text
    End Sub

    Private Sub txtJobNoFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNoFm.GotFocus
        Call HighlightText(txtJobNoFm)
    End Sub

    Private Sub txtJobNoTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNoTo.GotFocus
        Call HighlightText(txtJobNoTo)
    End Sub

    Private Sub txtBomItemNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBomItemNoFm.TextChanged
        txtBomItemNoTo.Text = txtBomItemNoFm.Text
    End Sub

    Private Sub txtBomItemNoFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBomItemNoFm.GotFocus
        Call HighlightText(txtBomItemNoFm)
    End Sub

    Private Sub txtBomItemNoTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBomItemNoTo.GotFocus
        Call HighlightText(txtBomItemNoTo)
    End Sub

    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub txtIssDatFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssDatFm.TextChanged
        txtIssDatTo.Text = txtIssDatFm.Text
    End Sub

    Private Sub txtIssDatFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssDatFm.GotFocus
        Call selMaskEdBox(txtIssDatFm)
    End Sub

    Private Sub txtIssDatTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssDatTo.GotFocus
        Call selMaskEdBox(txtIssDatTo)
    End Sub

    Private Sub txtRevDatFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevDatFm.TextChanged
        txtRevDatTo.Text = txtRevDatFm.Text
    End Sub

    Private Sub txtRevDatFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevDatFm.GotFocus
        Call selMaskEdBox(txtRevDatFm)
    End Sub

    Private Sub txtRevDatTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevDatTo.GotFocus
        Call selMaskEdBox(txtRevDatTo)
    End Sub

    Private Sub txtShpDatFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpDatFm.TextChanged
        txtShpDatTo.Text = txtShpDatFm.Text
    End Sub

    Private Sub txtShpDatFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpDatFm.GotFocus
        Call selMaskEdBox(txtShpDatFm)
    End Sub

    Private Sub txtShpDatTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpDatTo.GotFocus
        Call selMaskEdBox(txtShpDatTo)
    End Sub

    Private Sub selMaskEdBox(ByRef Mbox As MaskedTextBox)
        If Mbox.Enabled = True Then
            Mbox.SelectionStart = 0
            Mbox.SelectionLength = Mbox.MaxLength
        End If
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim optStatus As String
        Dim optZero As String
        Dim RptType As Integer

        If validateForm() = False Then
            Exit Sub
        End If

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        If optOpen.Checked = True Then
            optStatus = "OPE"
        ElseIf optCancel.Checked = True Then
            optStatus = "CAN"
        ElseIf optClose.Checked = True Then
            optStatus = "CLO"
        Else
            optStatus = "ALL"
        End If

        If optZeroY.Checked = True Then
            optZero = "Y"
        Else
            optZero = "N"
        End If

        RptType = cboRptType.SelectedIndex

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_POR00007 '" & Trim(cboCoCde.Text) & "','" & _
                                        getComboValue(cboCustNoFm) & "','" & _
                                        getComboValue(cboCustNoTo) & "','" & _
                                        getComboValue(cboVenNoFm) & "','" & _
                                        getComboValue(cboVenNoTo) & "','" & _
                                        Trim(txtBomPONoFm.Text) & "','" & _
                                        Trim(txtBomPONoTo.Text) & "','" & _
                                        Trim(txtJobNoFm.Text) & "','" & _
                                        Trim(txtJobNoTo.Text) & "','" & _
                                        Trim(txtBomItemNoFm.Text) & "','" & _
                                        Trim(txtBomItemNoTo.Text) & "','" & _
                                        IIf(Trim(txtIssDatFm.Text) <> "/  /", txtIssDatFm.Text, "") & "','" & _
                                        IIf(Trim(txtIssDatTo.Text) <> "/  /", txtIssDatTo.Text, "") & "','" & _
                                        IIf(Trim(txtRevDatFm.Text) <> "/  /", txtRevDatFm.Text, "") & "','" & _
                                        IIf(Trim(txtRevDatTo.Text) <> "/  /", txtRevDatTo.Text, "") & "','" & _
                                        IIf(Trim(txtShpDatFm.Text) <> "/  /", txtShpDatFm.Text, "") & "','" & _
                                        IIf(Trim(txtShpDatTo.Text) <> "/  /", txtShpDatTo.Text, "") & "','" & _
                                        optStatus & "','" & _
                                        optZero & "','" & _
                                        RptType & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdShow_Click sp_select_POR00007 :" & rtnStr)
            Exit Sub
        End If

        If rs_EXCEL.Tables("RESULT").Rows.Count <= 0 Then
            MsgBox("No Record Found!")
        Else
            Call ExportToExcel(RptType)
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function validateForm() As Boolean
        validateForm = False

        If isEmptyForm() = True Then
            MsgBox("Please provide one/more selection criteria!")
            Exit Function
        End If

        'Customer NO
        If cboCustNoFm.Text <> "" And cboCustNoTo.Text = "" Then
            cboCustNoTo.Text = cboCustNoFm.Text
        ElseIf cboCustNoFm.Text = "" And cboCustNoTo.Text <> "" Then
            cboCustNoFm.Text = cboCustNoTo.Text
        End If

        'Vendor No
        If cboVenNoFm.Text <> "" And cboVenNoTo.Text = "" Then
            cboVenNoTo.Text = cboVenNoFm.Text
        ElseIf cboVenNoFm.Text = "" And cboVenNoTo.Text <> "" Then
            cboVenNoFm.Text = cboVenNoTo.Text
        End If

        'BOM PO No
        If Trim(txtBomPONoFm.Text) <> "" And Trim(txtBomPONoTo.Text) = "" Then
            txtBomPONoTo.Text = txtBomPONoFm.Text
        ElseIf Trim(txtBomPONoFm.Text) = "" And Trim(txtBomPONoTo.Text) <> "" Then
            txtBomPONoFm.Text = txtBomPONoTo.Text
        End If

        'Job No
        If Trim(txtJobNoFm.Text) <> "" And Trim(txtJobNoTo.Text) = "" Then
            txtJobNoTo.Text = txtJobNoFm.Text
        ElseIf Trim(txtJobNoFm.Text) = "" And Trim(txtJobNoFm.Text) <> "" Then
            txtJobNoFm.Text = txtJobNoTo.Text
        End If

        'BOM Item No
        If Trim(txtBomItemNoFm.Text) <> "" And Trim(txtBomItemNoTo.Text) = "" Then
            txtBomItemNoTo.Text = txtBomItemNoFm.Text
        ElseIf Trim(txtBomItemNoFm.Text) = "" And Trim(txtBomItemNoTo.Text) <> "" Then
            txtBomItemNoFm.Text = txtBomItemNoTo.Text
        End If

        'BOM PO Issue Date
        If Trim(txtIssDatFm.Text) <> "/  /" And Trim(txtIssDatTo.Text) = "/  /" Then
            txtIssDatTo.Text = txtIssDatFm.Text
        ElseIf Trim(txtIssDatFm.Text) = "/  /" And Trim(txtIssDatTo.Text) <> "/  /" Then
            txtIssDatFm.Text = txtIssDatTo.Text
        End If

        'BOM PO Revise Date
        If Trim(txtRevDatFm.Text) <> "/  /" And Trim(txtRevDatTo.Text) = "/  /" Then
            txtRevDatTo.Text = txtRevDatFm.Text
        ElseIf Trim(txtRevDatFm.Text) = "/  /" And Trim(txtRevDatTo.Text) <> "/  /" Then
            txtRevDatFm.Text = txtRevDatTo.Text
        End If

        'BOM PO Ship Date
        If Trim(txtShpDatFm.Text) <> "/  /" And Trim(txtShpDatTo.Text) = "/  /" Then
            txtShpDatTo.Text = txtShpDatFm.Text
        ElseIf Trim(txtShpDatFm.Text) = "/  /" And Trim(txtShpDatTo.Text) <> "/  /" Then
            txtShpDatFm.Text = txtShpDatTo.Text
        End If

        'check range valid
        If cboCustNoFm.Text > cboCustNoTo.Text Then
            MsgBox("Customer No: From > To")
            cboCustNoFm.Focus()
            Exit Function
        End If

        If cboVenNoFm.Text > cboVenNoTo.Text Then
            MsgBox("Vendor NO: From > To")
            cboVenNoFm.Focus()
            Exit Function
        End If

        If txtBomPONoFm.Text > txtBomPONoTo.Text Then
            MsgBox("BOM PO No: From > To")
            txtBomPONoFm.Focus()
            Exit Function
        End If

        If txtJobNoFm.Text > txtJobNoTo.Text Then
            MsgBox("Job No:From > To")
            txtJobNoFm.Focus()
            Exit Function
        End If

        If txtBomItemNoFm.Text > txtBomItemNoTo.Text Then
            MsgBox("BOM Item No:From > To")
            txtBomItemNoFm.Focus()
            Exit Function
        End If

        If Trim(txtIssDatFm.Text) <> "/  /" And Trim(txtIssDatTo.Text) <> "/  /" Then
            If Not IsDate(txtIssDatFm.Text) Then
                MsgBox("Invalid BOM PO Issue Date From")
                txtIssDatFm.Focus()
                Exit Function
            End If
            If Not IsDate(txtIssDatTo.Text) Then
                MsgBox("Invalid BOM PO Issue Date To")
                txtIssDatTo.Focus()
                Exit Function
            End If
            If CDate(txtIssDatFm.Text) > CDate(txtIssDatTo.Text) Then
                MsgBox("BOM PO Issue Date: From > To")
                Exit Function
            End If
        End If

        If Trim(txtRevDatFm.Text) <> "/  /" And Trim(txtRevDatTo.Text) <> "/  /" Then
            If Not IsDate(txtRevDatFm.Text) Then
                MsgBox("Invalid BOM PO Revise Date From")
                txtRevDatFm.Focus()
                Exit Function
            End If
            If Not IsDate(txtRevDatTo.Text) Then
                MsgBox("Invalid BOM PO Revise Date To")
                txtRevDatTo.Focus()
                Exit Function
            End If
            If CDate(txtRevDatFm.Text) > CDate(txtRevDatTo.Text) Then
                MsgBox("BOM PO Revise Date: From > To")
                Exit Function
            End If
        End If

        If Trim(txtShpDatFm.Text) <> "/  /" And Trim(txtShpDatTo.Text) <> "/  /" Then
            If Not IsDate(txtShpDatFm.Text) Then
                MsgBox("Invalid BOM PO Ship Date From")
                txtShpDatFm.Focus()
                Exit Function
            End If
            If Not IsDate(txtShpDatTo.Text) Then
                MsgBox("Invalid BOM PO Ship Date To")
                txtShpDatTo.Focus()
                Exit Function
            End If
            If CDate(txtShpDatFm.Text) > CDate(txtShpDatTo.Text) Then
                MsgBox("BOM PO Ship Date: From > To")
                Exit Function
            End If
        End If
        validateForm = True
    End Function

    Private Function isEmptyForm() As Boolean
        isEmptyForm = False

        If cboCustNoFm.Text <> "" Or cboCustNoTo.Text <> "" Then Exit Function
        If cboVenNoFm.Text <> "" Or cboVenNoTo.Text <> "" Then Exit Function
        If Trim(txtBomPONoFm.Text) <> "" Or Trim(txtBomPONoTo.Text) <> "" Then Exit Function
        If Trim(txtJobNoFm.Text) <> "" Or Trim(txtJobNoTo.Text) <> "" Then Exit Function
        If Trim(txtBomItemNoFm.Text) <> "" Or Trim(txtBomItemNoTo.Text) <> "" Then Exit Function
        If Trim(txtIssDatFm.Text) <> "/  /" Or Trim(txtIssDatTo.Text) <> "/  /" Then Exit Function
        If Trim(txtRevDatFm.Text) <> "/  /" Or Trim(txtRevDatTo.Text) <> "/  /" Then Exit Function
        If Trim(txtShpDatFm.Text) <> "/  /" Or Trim(txtShpDatTo.Text) <> "/  /" Then Exit Function

        isEmptyForm = True
    End Function

    Private Function getComboValue(ByRef cbo As ComboBox) As String
        Dim strTemp As String

        getComboValue = ""
        strTemp = Trim(cbo.Text)

        If InStr(strTemp, " - ") > 0 Then
            strTemp = Strings.Left(strTemp, InStr(strTemp, " - ") - 1)
        End If

        getComboValue = strTemp
    End Function

    Private Sub ExportToExcel(ByVal RptType As Integer)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWb As Excel.Workbook = Nothing
        Dim xlsWs As Excel.Worksheet = Nothing

        Dim lngRecCount As Integer
        Dim fldCount As Integer

        lngRecCount = rs_EXCEL.Tables("RESULT").Rows.Count + 1
        If rs_EXCEL.Tables("RESULT").Rows.Count + 1 > 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application
        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWb = xlsApp.Workbooks.Add()
        xlsWs = xlsWb.ActiveSheet

        fldCount = rs_EXCEL.Tables("RESULT").Columns.Count

        Dim hdrRow As Integer = 1
        Dim entry(rs_EXCEL.Tables("RESULT").Rows.Count, fldCount - 1) As Object

        Try
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

                .Range(.Cells(hdrRow, 1), .Cells(rs_EXCEL.Tables("RESULT").Rows.Count + 1, fldCount)).Value = entry
            End With

            With xlsApp
                .Rows("1:1").Font.Bold = True
                .Rows("1:1").Font.Size = 10
                .Rows("1:1").RowHeight = 25
                .Rows("1:1").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1

                .Range(.Cells(2, 3), .Cells(lngRecCount, 3)).NumberFormatLocal = "@"

                If RptType = 0 Then ' PO Information
                    .Range(.Cells(2, 12), .Cells(lngRecCount, 13)).HorizontalAlignment = 4

                    .Range(.Cells(2, 10), .Cells(lngRecCount, 10)).NumberFormatLocal = "@"

                    .Range(.Cells(2, 12), .Cells(lngRecCount, 13)).NumberFormatLocal = "MM-DD-YYYY"
                ElseIf RptType = 1 Then ' Report Type = BOM Information
                    .Range(.Cells(2, 15), .Cells(lngRecCount, 18)).HorizontalAlignment = 4

                    .Range(.Cells(2, 5), .Cells(lngRecCount, 6)).NumberFormatLocal = "@"

                    .Range(.Cells(2, 13), .Cells(lngRecCount, 14)).NumberFormatLocal = "0.0000"

                    .Range(.Cells(2, 15), .Cells(lngRecCount, 17)).NumberFormatLocal = "MM-DD-YYYY"
                    .Range(.Cells(2, 18), .Cells(lngRecCount, 18)).NumberFormatLocal = "MM-DD-YYYY HH:MM:SS"
                ElseIf RptType = 2 Then ' Report Type = BOTH
                    .Range(.Cells(2, 11), .Cells(lngRecCount, 12)).HorizontalAlignment = 4
                    .Range(.Cells(2, 25), .Cells(lngRecCount, 28)).HorizontalAlignment = 4

                    .Range(.Cells(2, 15), .Cells(lngRecCount, 16)).NumberFormatLocal = "@"

                    .Range(.Cells(2, 23), .Cells(lngRecCount, 24)).NumberFormatLocal = "0.0000"

                    .Range(.Cells(2, 11), .Cells(lngRecCount, 12)).NumberFormatLocal = "MM-DD-YYYY"
                    .Range(.Cells(2, 25), .Cells(lngRecCount, 27)).NumberFormatLocal = "MM-DD-YYYY"
                    .Range(.Cells(2, 28), .Cells(lngRecCount, 28)).NumberFormatLocal = "MM-DD-YYYY HH:MM:SS"
                End If

                If RptType = 0 Then ' PO Information
                    .Columns("A:M").WrapText = False
                    .Columns("A:M").EntireColumn.AutoFit()
                ElseIf RptType = 1 Then ' Report Type = BOM Information
                    .Columns("A:R").WrapText = False
                    .Columns("A:R").EntireColumn.AutoFit()
                ElseIf RptType = 2 Then ' Report Type = BOTH
                    .Columns("A:AB").WrapText = False
                    .Columns("A:AB").EntireColumn.AutoFit()
                End If

                For index As Integer = 1 To fldCount
                    If .Columns(index).ColumnWidth > 50 Then
                        .Columns(index).ColumnWidth = 50
                    End If
                Next
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Or ex.Message = "Exception from HRESULT: 0x800A03EC" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWs = Nothing
                    xlsWb = Nothing
                    xlsApp = Nothing
                    ExportToExcel(RptType)
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, Me.Name.ToString & " - Excel Error")
            End If
        End Try

        'Show the excel after creating process is completed
        xlsApp.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        rs_EXCEL = Nothing
        xlsWs = Nothing
        xlsWb = Nothing
        xlsApp = Nothing

        Cursor = Cursors.Default
    End Sub
End Class