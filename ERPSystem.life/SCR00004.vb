Imports Excel = Microsoft.Office.Interop.Excel
Public Class SCR00004

    Dim Del_right_local As Boolean
    Dim Enq_right_local As Boolean

    Dim rs_SCR00004 As DataSet
    Dim rs_SYMUSRCO As DataSet

    Dim HdrApvSeq As Integer
    Dim HdrPrcTrmApvSeq As Integer
    Dim HdrPayTrmApvSeq As Integer
    Dim HdrRepOrdApvSeq As Integer
    Dim HdrCloOrdApvSeq As Integer
    Dim HdrApvCheckSeq As Integer
    Dim HdrApvMsgSeq As Integer

    Dim HdrApvSelAllSeq As Integer
    Dim HdrPrcTrmApvSelAllSeq As Integer
    Dim HdrPayTrmApvSelAllSeq As Integer
    Dim HdrRepOrdApvSelAllSeq As Integer
    Dim HdrCloOrdApvSelAllSeq As Integer
    Dim HdrKeepSelectSeq As Integer

    Dim DtlApvSeq As Integer
    Dim DtlMOQApvSeq As Integer
    Dim DtlMinMUApvSeq As Integer
    Dim DtlChgFtyCstApvSeq As Integer
    Dim DtlOneTimeApvSeq As Integer
    Dim DtlApvCheckSeq As Integer
    Dim DtlApvMsgSeq As Integer
    Dim DtlChgUntPrcApvSeq As Integer

    Dim DtlApvSelAllSeq As Integer
    Dim DtlMOQApvSelAllSeq As Integer
    Dim DtlMinMUApvSelAllSeq As Integer
    Dim DtlChgFtyCstApvSelAllSeq As Integer
    Dim DtlOneTimeApvSelAllSeq As Integer
    Dim DtlChgUntPrcApvSelAllSeq As Integer
    Dim DtlKeepSelectSeq As Integer


    Private Sub SCR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setStatus()
    End Sub



    Private Sub SCR00004_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub




    Private Sub setStatus()
        txt_S_CoCde.Text = ""
        txt_S_PriCustAll.Text = ""
        txt_S_SecCustAll.Text = ""
        txt_S_SCNo.Text = ""
        txt_S_CustPONo.Text = ""

        txtSCRvsdatFm.Text = Format(DateAdd(DateInterval.Month, -1, Date.Now), "MM/dd/yyyy")
        txtSCRvsdatTo.Text = Format(Date.Now, "MM/dd/yyyy")

        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SCR00004_Load #001 sp_select_SYMUSRCO : " & rtnStr)
        Else
            Dim i As Integer
            Dim strCocde As String
            strCocde = ""

            If rs_SYMUSRCO.Tables("RESULT").Rows.Count > 0 Then
                For i = 0 To rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1
                    If rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") <> "MS" Then
                        If i <> rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1 Then
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") + ","
                        Else
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde")
                        End If
                    End If
                Next i
            End If

            Me.txt_S_CoCde.Text = strCocde
        End If
    End Sub



    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_frmS(Me.cmd_S_CoCde)
    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCustAll.Name
        frmComSearch.callFmString = txt_S_SecCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCust)
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
        frmComSearch.callFmCriteria = txt_S_CustPONo.Name
        frmComSearch.callFmString = txt_S_CustPONo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        'If checkFocus(Me) Then Exit Sub
        Dim cocde As String
        Dim cus1no As String
        Dim cus2no As String
        Dim ordno As String
        Dim itmno As String
        Dim rvsdatFm As String
        Dim rvsdatTo As String

        'If gsUsrRank > 4 And gsUsrGrp <> "MGT-S" Then
        '    MsgBox("You do not have the rights to use this feature.", MsgBoxStyle.Critical, "SCR00004 - Access Rights")
        '    Exit Sub
        'End If

        If txt_S_CoCde.Text = "" Then
            MsgBox("Company Code List cannot be empty")
            txt_S_CoCde.Focus()
            Exit Sub
        Else
            If txt_S_CoCde.Text.Length > 1000 Then
                MsgBox("Company Code List is too long (1000 Char)")
                txt_S_CoCde.Focus()
                txt_S_CoCde.SelectAll()
                Exit Sub
            Else
                cocde = Replace(Trim(txt_S_CoCde.Text), "'", "''")
            End If
        End If

        If txt_S_PriCustAll.Text.Length > 1000 Then
            MsgBox("Primary Customer List is too long (1000 Char)")
            txt_S_PriCustAll.Focus()
            txt_S_PriCustAll.SelectAll()
            Exit Sub
        Else
            cus1no = Replace(Trim(txt_S_PriCustAll.Text), "'", "''")
        End If

        If txt_S_SecCustAll.Text.Length > 1000 Then
            MsgBox("Secondary Customer List is too long (1000 Char)")
            txt_S_SecCustAll.Focus()
            txt_S_SecCustAll.SelectAll()
            Exit Sub
        Else
            cus2no = Replace(Trim(txt_S_SecCustAll.Text), "'", "''")
        End If

        If txt_S_SCNo.Text.Length > 1000 Then
            MsgBox("SC No List is too long (1000 Char)")
            txt_S_SCNo.Focus()
            txt_S_SCNo.SelectAll()
            Exit Sub
        Else
            ordno = Replace(Trim(txt_S_SCNo.Text), "'", "''")
        End If

        If txt_S_CustPONo.Text.Length > 1000 Then
            MsgBox("Item No List is too long (1000 Char)")
            txt_S_CustPONo.Focus()
            txt_S_CustPONo.SelectAll()
            Exit Sub
        Else
            itmno = Replace(Trim(txt_S_CustPONo.Text), "'", "''")
        End If

        If txtSCRvsdatFm.Text = "  /  /" Then
            MsgBox("SC Issue Date (From) cannot be empty")
            txtSCRvsdatFm.Focus()
            txtSCRvsdatFm.SelectAll()
            Exit Sub
        Else
            If txtSCRvsdatFm.Text.Length <> 10 Or IsDate(txtSCRvsdatFm.Text) = False Then
                MsgBox("Invalid SC Issue Date (From)")
                txtSCRvsdatFm.Focus()
                txtSCRvsdatFm.SelectAll()
                Exit Sub
            End If
        End If

        If txtSCRvsdatTo.Text = "  /  /" Then
            MsgBox("SC Issue Date (To) cannot be empty")
            txtSCRvsdatTo.Focus()
            txtSCRvsdatTo.SelectAll()
            Exit Sub
        Else
            If txtSCRvsdatTo.Text.Length <> 10 Or IsDate(txtSCRvsdatTo.Text) = False Then
                MsgBox("Invalid SC Issue Date (To)")
                txtSCRvsdatTo.Focus()
                txtSCRvsdatTo.SelectAll()
                Exit Sub
            End If
        End If

        If CDate(txtSCRvsdatFm.Text) > CDate(txtSCRvsdatTo.Text) Then
            MsgBox("SC Issue Date (From) > SC Issue End Date (To)")
            txtSCRvsdatFm.Focus()
            txtSCRvsdatFm.SelectAll()
            Exit Sub
        End If

        rvsdatFm = txtSCRvsdatFm.Text
        rvsdatTo = txtSCRvsdatTo.Text

        Dim Status As String = "HLD"
        If optStsHLD.Checked = True Then
            Status = "HLD"
        ElseIf optStsALL.Checked = True Then
            Status = "ALL"
        End If

        gspStr = "sp_select_SCR00004 '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                 ordno & "','" & itmno & "','" & rvsdatFm & "','" & rvsdatTo & "','" & gsUsrID & "','" & Status & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SCR00004, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCR00004 #001 sp_select_SCR00004 : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_SCR00004.Tables("RESULT").Columns.Count - 1
                rs_SCR00004.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        If rs_SCR00004.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No record found")
            Exit Sub
        End If


        If rs_SCR00004.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No detail record found")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        GenSCApvRpt()

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Private Sub GenSCApvRpt()
        If rs_SCR00004 Is Nothing Then
            Exit Sub
        End If
        ExportToExcel(0, rs_SCR00004)
    End Sub

    Private Sub ExportToExcel(ByVal RptType As Integer, ByVal rs_EXCEL As DataSet)
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
        xlsWs.Name = "Approval List"
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

            With xlsApp.Cells
                .Rows("1:" + lngRecCount.ToString()).Style.Font.Name = "Arial"
                .Rows("1:1").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
                .Rows("1:1").WrapText = True
                .Rows("1:1").VerticalAlignment = Excel.XlVAlign.xlVAlignTop
                .Rows("2:" + lngRecCount.ToString()).WrapText = False
                .Cells(1, "F").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "I").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "L").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "M").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "S").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "V").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "W").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "X").Interior.Color = RGB(255, 255, 153)
                .Cells(1, "AC").Interior.Color = RGB(255, 255, 153)

                .Columns("F").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("I").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("L").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("M").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("S").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("V").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("W").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("X").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("Y").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("AC").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Columns("AD").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                .Columns("A").ColumnWidth = 15
                .Columns("B").ColumnWidth = 12
                .Columns("C").ColumnWidth = 20
                .Columns("D").ColumnWidth = 32
                .Columns("E").ColumnWidth = 32
                .Columns("F").ColumnWidth = 10
                .Columns("G").ColumnWidth = 30
                .Columns("H").ColumnWidth = 30
                .Columns("I").ColumnWidth = 10
                .Columns("J").ColumnWidth = 25
                .Columns("K").ColumnWidth = 25
                .Columns("L").ColumnWidth = 10
                .Columns("M").ColumnWidth = 10
                .Columns("N").ColumnWidth = 5
                .Columns("O").ColumnWidth = 19
                .Columns("P").ColumnWidth = 19
                .Columns("Q").ColumnWidth = 19
                .Columns("R").ColumnWidth = 30
                .Columns("S").ColumnWidth = 10
                .Columns("T").ColumnWidth = 7
                .Columns("U").ColumnWidth = 7
                .Columns("V").ColumnWidth = 10
                .Columns("W").ColumnWidth = 10
                .Columns("X").ColumnWidth = 10
                .Columns("Y").ColumnWidth = 6
                .Columns("Z").ColumnWidth = 13
                .Columns("AA").ColumnWidth = 13
                .Columns("AB").ColumnWidth = 13
                .Columns("AC").ColumnWidth = 10
                .Columns("AD").ColumnWidth = 6
                .Columns("AE").ColumnWidth = 13
                .Columns("AF").ColumnWidth = 13
                .Columns("AG").ColumnWidth = 13
                .Columns("AH").ColumnWidth = 13

                .Columns("C").NumberFormatLocal = "@"
                .Columns("D").NumberFormatLocal = "@"
                .Columns("E").NumberFormatLocal = "@"
                .Columns("G").NumberFormatLocal = "@"
                .Columns("H").NumberFormatLocal = "@"
                .Columns("J").NumberFormatLocal = "@"
                .Columns("K").NumberFormatLocal = "@"
                .Columns("O").NumberFormatLocal = "@"
                .Columns("P").NumberFormatLocal = "@"
                .Columns("Q").NumberFormatLocal = "@"
                .Columns("R").NumberFormatLocal = "@"

                .Columns("Z").NumberFormat = "#,##0.0000_);(#,##0.0000)"
                .Columns("AA").NumberFormat = "#,##0.0000_);(#,##0.0000)"
                .Columns("AB").NumberFormat = "#,##0.0000_);(#,##0.0000)"
                .Columns("AE").NumberFormat = "#,##0.0000_);(#,##0.0000)"
                .Columns("AF").NumberFormat = "#,##0.0000_);(#,##0.0000)"
                .Columns("AH").NumberFormat = "#,##0.0000_);(#,##0.0000)"
                .Columns("AG").NumberFormat = "#,##0.0000_);(#,##0.0000)"
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Or ex.Message = "Exception from HRESULT: 0x800A03EC" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWs = Nothing
                    xlsWb = Nothing
                    xlsApp = Nothing
                    ExportToExcel(RptType, rs_EXCEL)
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