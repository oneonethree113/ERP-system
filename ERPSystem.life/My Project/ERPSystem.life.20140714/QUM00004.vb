Public Class QUM00004

    Dim drNewRow As DataRow
    Dim sFilter As String
    Dim dr() As DataRow
    Dim ErrMsg As String
    Dim DateFrom As String
    Dim DateTo As String
    Dim gsCompany1 As String

    Private Const sMODULE As String = "QU"

    Private Const cERRMSG_01 As String = "Invalid Company Code"
    Private Const cERRMSG_02 As String = "Item Not Found"
    Private Const cERRMSG_03 As String = "Item In History"
    Private Const cERRMSG_04 As String = "Item Status is Hold"
    Private Const cERRMSG_05 As String = "Item Status is Close"
    Private Const cERRMSG_06 As String = "Item Status is Discontinue"
    Private Const cERRMSG_07 As String = "Item Status is Inactive"
    Private Const cERRMSG_08 As String = "Item Status is To be confirmed"
    Private Const cERRMSG_09 As String = "Item Status is Old Item"
    Private Const cERRMSG_10 As String = "PDA basic price difference"
    Private Const cERRMSG_11 As String = "Primary Customer Not Found"
    Private Const cERRMSG_12 As String = "Primary and Secondary Customer without Relation"
    Private Const cERRMSG_13 As String = "Item Cannot Quot By This Company"
    Private Const cERRMSG_14 As String = "Missing Customer Price Information"
    Private Const cERRMSG_15 As String = "Missing Exchange Rate for Currency Code"

    Dim qud_cu1pri As Double
    Dim qud_cu2pri As Double
    Dim qud_basprc As Double
    Dim IsUpdated As Boolean

    Public rs_TempQ As New DataSet
    Public rs_TempAss As New DataSet
    Public rs_DistinctQ As New DataSet
    Public rs_PriCust As New DataSet
    Public rs_SecCust As New DataSet
    Public rs_Result As New DataSet
    Dim objBSGate As Object

    Public rs_Quot As New DataSet
    Public rs_fQuot As New DataSet
    Public rs_QuotH As New DataSet
    Public rs_Assort As New DataSet
    Dim Quot_no(100) As String
    Dim cus2na As String
    Dim colcde(100) As String     'for color
    Dim n, colnum As Integer    'for color
    Public PathString As String
    Public DtlValid As Boolean
    Dim ErrCnt As Integer

    Dim sort_seq As Boolean
    Dim sort_seq_Ass As Boolean

    Dim rs_CUBASINF_CR As New DataSet
    Dim rs_SYTIESTR As New DataSet

    Dim rs_MARKUP_prc As New DataSet   ' For Primary Customer's Selling Price

    Dim strQutsts As String
    Dim flgHold As Boolean

    Dim result As String

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub QUM00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btcPDA.TabPages(2).Enabled = False
        btcPDA.TabPages(1).Enabled = False
        btcPDA.TabPages(0).Enabled = True
        btcPDA.SelectedIndex = 0

        txtTmpQutNo.Text = ""
        txtDateFrom.Text = Format(Now(), "MM/dd/yyyy")
        txtDateTo.Text = Format(Now(), "MM/dd/yyyy")

        'S = "㊣CUBASINF_PC※S※" & gsUsrID & "※" & strModule & "※Primary"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUBASINF_PC_QUM00004 '','" & gsUsrID & "','" & sMODULE & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_PriCust, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QUM00004_Load sp_select_CUBASINF_PC_QUM00004 :" & rtnStr)
            Exit Sub
        End If

        If rs_PriCust.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
            MsgBox("There is no function, please contact EDP or System Administrator.")
            Exit Sub
        Else
            If rs_PriCust.Tables("RESULT").Rows.Count > 0 Then
                cboPriCust.Items.Clear()
            End If

            sFilter = "cbi_cusno >= '50000'"
            rs_PriCust.Tables("RESULT").DefaultView.RowFilter = sFilter

            For index As Integer = 0 To rs_PriCust.Tables("RESULT").DefaultView.Count - 1
                cboPriCust.Items.Add(rs_PriCust.Tables("RESULT").DefaultView(index)("cbi_cusno") + " - " + _
                                     rs_PriCust.Tables("RESULT").DefaultView(index)("cbi_cussna"))
            Next

            sFilter = ""
            rs_PriCust.Tables("RESULT").DefaultView.RowFilter = sFilter
        End If

        btnUpload.Enabled = False
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cboPriCust.Enabled = True
        cboSecCust.Enabled = True
        txtDateFrom.Enabled = True
        txtDateTo.Enabled = True
        txtTmpQutNo.Enabled = True
        btnLoad.Enabled = True
        btnClear.Enabled = False
        btnUpload.Enabled = False
        dgTempQ.DataSource = Nothing
        dgTempAss.DataSource = Nothing
        dgResult.DataSource = Nothing

        txtTmpQutNo.Text = ""
        txtDateFrom.Text = Format(Now(), "MM/dd/yyyy")
        txtDateTo.Text = Format(Now(), "MM/dd/yyyy")

        rs_TempQ.Tables.Clear()
        rs_DistinctQ.Tables.Clear()
        rs_Result.Tables.Clear()
        'rs_TempQ = Nothing
        'rs_DistinctQ = Nothing
        'rs_Result = Nothing

        btcPDA.TabPages(2).Enabled = False
        btcPDA.TabPages(1).Enabled = False
        btcPDA.TabPages(0).Enabled = True
        btcPDA.SelectedIndex = 0
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Call btnLoadClick()
    End Sub

    Private Sub btnLoadClick()
        lblProgress.Text = ""
        Me.Refresh()

        If (txtDateFrom.Text = "  /  /" Or txtDateTo.Text = "  /  /") And _
            Trim(txtTmpQutNo.Text) = "" And cboPriCust.Text = "" And cboSecCust.Text = "" Then
            MsgBox("Please input at least 1 searching criteria.")
            Exit Sub
        End If

        If txtDateFrom.Text <> "  /  /" Then
            DateFrom = Format(CDate(txtDateFrom.Text), "yyyyMMdd")
        Else
            DateFrom = "  /  /    "
        End If

        If txtDateTo.Text <> "  /  /" Then
            DateTo = Format(CDate(txtDateTo.Text), "yyyyMMdd")
        Else
            DateTo = "  /  /    "
        End If

        Call LoadData()

        If rs_TempQ.Tables.Count > 0 Then
            If rs_TempQ.Tables("RESULT").DefaultView.Count > 0 Then
                dgTempQ.DataSource = rs_TempQ.Tables("RESULT").DefaultView
                Call DisplayTempQ()

                cboPriCust.Enabled = False
                cboSecCust.Enabled = False
                txtDateFrom.Enabled = False
                txtDateTo.Enabled = False
                txtTmpQutNo.Enabled = False
                btnLoad.Enabled = False
                btnClear.Enabled = True
                btnUpload.Enabled = True
            Else
                MsgBox("No quotation found.")
            End If
        End If
    End Sub

    Private Sub LoadData()
        Dim strCus1No As String
        Dim strCus2No As String

        rs_TempQ.Tables.Clear()
        rs_DistinctQ.Tables.Clear()
        dgTempQ.DataSource = Nothing

        If Trim(cboPriCust.Text) = "" Then
            strCus1No = ""
        Else
            strCus1No = Trim(Split(cboPriCust.Text, "-")(0))
        End If

        If Trim(cboSecCust.Text) = "" Then
            strCus2No = ""
        Else
            strCus2No = Trim(Split(cboSecCust.Text, "-")(0))
        End If

        'S = "㊣PDA_Quot※S※※" & gsUsrID & "※" & strCus1No & "※" & strCus2No & "※" & Format(txtDateFrom.Text, "yyyymmdd") & "※" & Format(txtDateTo.Text, "yyyymmdd") & "※" & IIf(txtTmpQutNo.Text = "", "", txtTmpQutNo.Text) & "※1"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_PDA_Quot '','','" & gsUsrID & "','" & strCus1No & "','" & strCus2No & "','" & DateFrom & "','" & DateTo & "','" & IIf(txtTmpQutNo.Text = "", "", txtTmpQutNo.Text) & "','1'"
        rtnLong = execute_SQLStatement(gspStr, rs_TempQ, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading LoadData sp_select_PDA_Quot 1 :" & rtnStr)
            Exit Sub
        End If

        For index1 As Integer = 0 To rs_TempQ.Tables("RESULT").Columns.Count - 1
            rs_TempQ.Tables("RESULT").Columns(index1).ReadOnly = False
        Next

        'S = "㊣PDA_Quot※S※※" & gsUsrID & "※" & strCus1No & "※" & strCus2No & "※" & Format(txtDateFrom.Text, "yyyymmdd") & "※" & Format(txtDateTo.Text, "yyyymmdd") & "※" & IIf(txtTmpQutNo.Text = "", "", txtTmpQutNo.Text) & "※2"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_PDA_Quot '','','" & gsUsrID & "','" & strCus1No & "','" & strCus2No & "','" & DateFrom & "','" & DateTo & "','" & IIf(txtTmpQutNo.Text = "", "", txtTmpQutNo.Text) & "','2'"
        rtnLong = execute_SQLStatement(gspStr, rs_DistinctQ, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading LoadData sp_select_PDA_Quot 2 :" & rtnStr)
            Exit Sub
        End If

        For index1 As Integer = 0 To rs_DistinctQ.Tables("RESULT").Columns.Count - 1
            rs_DistinctQ.Tables("RESULT").Columns(index1).ReadOnly = False
        Next
    End Sub

    Private Sub DisplayTempQ()
        Dim intCol As Integer

        intCol = 0

        With dgTempQ
            .Columns(intCol).HeaderText = "Del"
            '.Columns(intCol).Button = True
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Co. Code"
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Temp. Qut. No."
            .Columns(intCol).Width = 180
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Seq."
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Item No."
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Col. Cde."
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Alias Item No."
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Alias Col. Cde."
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Pck Seq."
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "UM"
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Inr."
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Mtr."
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "CFT"
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Pri. Cust."
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Pri. Cust. Name"
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Sec. Cust."
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Sec. Cust. Name"
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Rel."
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Cur. Cde."
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Pri. Std. Price"
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Sec. Std. Price"
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "MU / GM"
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Rate"
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "MOQ"
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "MOA"
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Smp. Qty."
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Disc."
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Note"
            .Columns(intCol).Width = 200
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Modify"
            .Columns(intCol).Width = 60
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Period"
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Cre. User"
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Cre. Dat."
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            .Columns(intCol).DefaultCellStyle.Format = "MM/dd/yyyy"
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Upd. User"
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Last Upd. Dat."
            .Columns(intCol).Width = 220
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            .Columns(intCol).DefaultCellStyle.Format = "MM/dd/yyyy"
            intCol = intCol + 1

            For i As Integer = intCol To rs_TempQ.Tables("RESULT").Columns.Count - 1
                .Columns(i).Width = 0
                .Columns(i).ReadOnly = True
                .Columns(i).Visible = False
            Next

            'For iCol As Integer = 1 To rs_TempQ.Tables("RESULT").Columns.Count - 1
            '    .Columns(iCol).ReadOnly = False
            'Next
        End With
    End Sub

    Private Sub UploadQuotation()
        dgTempQ.DataSource = Nothing
        dgTempAss.DataSource = Nothing
        dgResult.DataSource = Nothing

        Call UpdateApproveStatus()

        Call LoadData()

        result = ""
        If rs_DistinctQ.Tables("RESULT").DefaultView.Count > 0 Then
            For index As Integer = 0 To rs_DistinctQ.Tables("RESULT").DefaultView.Count - 1
                Call SaveQuotation(rs_DistinctQ.Tables("RESULT").DefaultView(index)("qud_tmpqutno"))
            Next

            Call GetResult()
        End If
    End Sub

    Private Sub UpdateApproveStatus()
        If rs_TempQ.Tables("RESULT").DefaultView.Count = 0 Then
            Exit Sub
        End If

        Dim rs As New DataSet

        For index As Integer = 0 To rs_TempQ.Tables("RESULT").DefaultView.Count - 1
            If rs_TempQ.Tables("RESULT").DefaultView(index)("Upd").ToString = "Y" Or _
                rs_TempQ.Tables("RESULT").DefaultView(index)("Del").ToString = "Y" Then
                'S = "㊣PDA_QUOT※U※" & rs_TempQ("qud_cocde").Value & "※" & rs_TempQ("qud_cus1no").Value & "※" & rs_TempQ("qud_cus2no").Value & "※" & _
                '    rs_TempQ("qud_tmpqutno").Value & "※" & rs_TempQ("qud_seq").Value & "※" & rs_TempQ("qud_itmno").Value & "※" & _
                '    IIf(rs_TempQ("Del").Value = "Y", "D", "") & "※※※" & gsUsrID
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gspStr = "sp_update_PDA_QUOT '','" & _
                                            rs_TempQ.Tables("RESULT").DefaultView(index)("qud_cocde") & "','" & _
                                            rs_TempQ.Tables("RESULT").DefaultView(index)("qud_cus1no") & "','" & _
                                            rs_TempQ.Tables("RESULT").DefaultView(index)("qud_cus2no") & "','" & _
                                            rs_TempQ.Tables("RESULT").DefaultView(index)("qud_tmpqutno") & "','" & _
                                            Val(rs_TempQ.Tables("RESULT").DefaultView(index)("qud_seq")) & "','" & _
                                            rs_TempQ.Tables("RESULT").DefaultView(index)("qud_itmno") & "','" & _
                                            IIf(rs_TempQ.Tables("RESULT").DefaultView(index)("Del").ToString = "Y", "D", "") & "','','','" & _
                                            gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading UpdateApproveStatus sp_update_PDA_QUOT :" & rtnStr)
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub SaveQuotation(ByVal strTmpQutNo As String)
        Dim no As Integer

        Dim cus1string As String
        Dim cus2string As String

        If rs_TempQ.Tables("RESULT").DefaultView.Count <= 0 Then
            MsgBox("No record for uploading.")
            Exit Sub
        End If

        no = 0
        ErrCnt = 0
        strQutsts = ""
        flgHold = False

        Cursor = Cursors.WaitCursor

        Dim MDBrs As New DataSet
        Dim MDB_Filter As New DataSet
        Dim Assortrs As New DataSet
        Dim QuotH As New DataSet
        Dim DelQuotD As New DataSet
        Dim DelQuotSD As New DataSet
        Dim rs_cus2na As New DataSet
        Dim cnstr As String
        Dim Number As Integer

        Dim dblCus1SP As String   '*** Declare variable for Priamry Customer's Selling Price
        Dim strCus1No As String
        Dim strCus2No As String

        If Trim(cboPriCust.Text) = "" Then
            strCus1No = ""
        Else
            strCus1No = Trim(Split(cboPriCust.Text, "-")(0))
        End If

        If Trim(cboSecCust.Text) = "" Then
            strCus2No = ""
        Else
            strCus2No = Trim(Split(cboSecCust.Text, "-")(0))
        End If

        '*** All Details
        'S = "㊣PDA_Quot※S※※" & gsUsrID & "※" & strCus1No & "※" & strCus2No & "※" & Format(txtDateFrom.Text, "yyyymmdd") & "※" & Format(txtDateTo.Text, "yyyymmdd") & "※" & strTmpQutNo & "※3"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_PDA_Quot '','','" & gsUsrID & "','" & strCus1No & "','" & strCus2No & "','" & DateFrom & "','" & DateTo & "','" & strTmpQutNo & "','3'"
        rtnLong = execute_SQLStatement(gspStr, MDBrs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SaveQuotation sp_select_PDA_Quot 1 :" & rtnStr)
            Exit Sub
        End If

        For index As Integer = 0 To MDBrs.Tables("RESULT").Columns.Count - 1
            MDBrs.Tables("RESULT").Columns(index).ReadOnly = False
        Next

        '*** Distinct Cocde, Cus1no, Cus2no
        'S = "㊣PDA_Quot※S※※" & gsUsrID & "※" & strCustNo & "※" & strCus2No & "※" & Format(txtDateFrom.Text, "yyyymmdd") & "※" & Format(txtDateTo.Text, "yyyymmdd") & "※" & strTmpQutNo & "※4"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_PDA_Quot '','','" & gsUsrID & "','" & strCus1No & "','" & strCus2No & "','" & DateFrom & "','" & DateTo & "','" & strTmpQutNo & "','4'"
        rtnLong = execute_SQLStatement(gspStr, MDB_Filter, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SaveQuotation sp_select_PDA_Quot 2 :" & rtnStr)
            Exit Sub
        End If

        For index As Integer = 0 To MDB_Filter.Tables("RESULT").Columns.Count - 1
            MDB_Filter.Tables("RESULT").Columns(index).ReadOnly = False
        Next

        '*** Distinct Header
        'S = "㊣PDA_Quot※S※※" & gsUsrID & "※" & strCustNo & "※" & strCus2No & "※" & Format(txtDateFrom.Text, "yyyymmdd") & "※" & Format(txtDateTo.Text, "yyyymmdd") & "※" & strTmpQutNo & "※5"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_PDA_Quot '','','" & gsUsrID & "','" & strCus1No & "','" & strCus2No & "','" & DateFrom & "','" & DateTo & "','" & strTmpQutNo & "','5'"
        rtnLong = execute_SQLStatement(gspStr, QuotH, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SaveQuotation sp_select_PDA_Quot 2 :" & rtnStr)
            Exit Sub
        End If

        For index As Integer = 0 To QuotH.Tables("RESULT").Columns.Count - 1
            QuotH.Tables("RESULT").Columns(index).ReadOnly = False
        Next

        'S = "㊣PDA_Quot_Ass※S※※" & strCus1No & "※" & strCus2No & "※" & strTmpQutNo & "※※2"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_PDA_Quot_Ass '','','" & strCus1No & "','" & strCus2No & "','" & strTmpQutNo & "','','2'"
        rtnLong = execute_SQLStatement(gspStr, Assortrs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SaveQuotation sp_select_PDA_Quot_Ass :" & rtnStr)
            Exit Sub
        End If

        For index As Integer = 0 To Assortrs.Tables("RESULT").Columns.Count - 1
            Assortrs.Tables("RESULT").Columns(index).ReadOnly = False
        Next

        If MDBrs.Tables("RESULT").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("Your DB is empty!", MsgBoxStyle.Information, "Message")
            MDBrs.Tables.Clear()
            MDB_Filter.Tables.Clear()
            Assortrs.Tables.Clear()
            QuotH.Tables.Clear()
            Exit Sub
        ElseIf MDB_Filter.Tables("RESULT").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("Your DB is empty!", MsgBoxStyle.Information, "Message")
            MDBrs.Tables.Clear()
            MDB_Filter.Tables.Clear()
            Assortrs.Tables.Clear()
            QuotH.Tables.Clear()
            Exit Sub
        Else
            '************** Insert Primary Customer and Sec Customer into Array *****************
            Dim X As Integer
            Dim cus1no(200) As String
            Dim cus2no(200) As String
            Dim CoCde(200) As String

            X = 0

            For index As Integer = 0 To MDB_Filter.Tables("RESULT").Rows.Count - 1
                cus1no(X) = MDB_Filter.Tables("RESULT").Rows(index)("qud_cus1no")
                '********** Handle of Sec Customer is Null ***************
                If IsDBNull(MDB_Filter.Tables("RESULT").Rows(index)("qud_cus2no")) = True Or _
                    IIf(IsDBNull(MDB_Filter.Tables("RESULT").Rows(index)("qud_cus2no")) = True, "", MDB_Filter.Tables("RESULT").Rows(index)("qud_cus2no").ToString.Trim) = "" Then
                    cus2no(X) = ""
                Else
                    cus2no(X) = MDB_Filter.Tables("RESULT").Rows(index)("qud_cus2no")
                End If

                CoCde(X) = MDB_Filter.Tables("RESULT").Rows(index)("qud_cocde")
                X = X + 1
            Next

            MDB_Filter.Tables.Clear()

            Dim real_seq As Integer
            Dim sqlrs As New DataSet
            Dim sqlrs1 As New DataSet
            Dim sqlrs2 As New DataSet
            Dim sqlQ As New DataSet
            Dim rsAS As New DataSet

            Dim ST As String
            Dim sh As String

            rs_Quot = MDBrs.Copy
            rs_QuotH = QuotH.Copy
            rs_Assort = Assortrs.Copy

            '*** Variable to store MOQ/MOA & Currency
            Dim moq As Long
            Dim moa As Long
            Dim strCurr As String
            Dim rs_moq_moa As New DataSet
            '*** Delcare variables for original moq, moa and moq/moa flag
            Dim ORI_MOFLAG As String
            Dim ORI_MOQ As Long
            Dim ORI_MOA As Double

            Dim strMOQUNTTYP As String

            '*** Declare variable for Primary selling price
            Dim rs_Cus2SP As New DataSet
            Dim rs_qrs As New DataSet

            If rs_Quot.Tables("RESULT").Rows.Count > 0 Then
                'rs_Quot.MoveFirst()
                'rs_QuotH.MoveFirst()

                'If rs_Assort.recordCount > 0 Then
                '    rs_Assort.MoveFirst()
                'End If

                '**********                 Check Valid Quotation               ************
                Dim tempcocde

                For index As Integer = 0 To rs_Quot.Tables("RESULT").Rows.Count - 1
                    If Microsoft.VisualBasic.Left(rs_Quot.Tables("RESULT").Rows(index)("qud_itmno").ToString, 4) <> "ASST" Then
                        tempcocde = gsCompany1
                        gsCompany1 = rs_Quot.Tables("RESULT").Rows(index)("qud_CoCde")
                        'gsConnStr = Split(gsConnStr, "※")(0) & "※" & rs_Quot("qud_CoCde")
                        Call Detailvalid(index)
                    Else
                        Call Write_Ass_Log(index)
                    End If
                Next

                'gsConnStr = Split(gsConnStr, "※")(0) & "※" & tempcocde
                gsCompany1 = tempcocde
                'rs_Quot.MoveFirst()

                Dim Y As Integer
                Dim cuscount As Integer

                cuscount = X - 1

                tempcocde = gsCompany1       '*** Remember current Company Code

                For Y = 0 To cuscount
                    strQutsts = ""
                    flgHold = False

                    '*************************** Auto Gen  Quot No. ***************************
                    Dim s1, Quotno As String

                    '*** Put quotation Company Code to gscompany
                    'gsConnStr = Split(gsConnStr, "※")(0) & "※" & CoCde(Y)
                    gsCompany1 = CoCde(Y)
                    '*** Gen Quotation No.
                    's1 = "㊣DOC_GEN※S※QO※" & gsUsrID
                    'rs = objBSGate.Enquire(gsConnStr, "sp_general", s1)

                    Cursor = Cursors.WaitCursor

                    gspStr = "sp_select_DOC_GEN '" & gsCompany1 & "','QO','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    gspStr = ""

                    Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SaveQuotation sp_select_DOC_GEN :" & rtnStr)
                        Exit Sub
                    Else
                        If rs.Tables("RESULT").Rows.Count > 0 Then
                            Quotno = rs.Tables("RESULT").Rows(0)(0)
                        End If
                    End If

                    rs.Tables.Clear()

                    '*************************** Insert Quot Header ***************************
                    If rs_QuotH.Tables("RESULT").DefaultView.Count > 0 And Quotno <> "" Then
                        rs_QuotH.Tables("RESULT").DefaultView.Sort = " qud_seq asc"
                        If rs_QuotH.Tables("RESULT").DefaultView(0)("qud_seq") <> 0 Then
                            '***************** Record Which Quot was Created ************
                            Quot_no(no) = Quotno

                            cus1string = rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus1no")

                            '********** Handle of Sec Customer is Null ********************
                            If IsDBNull(rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus2no")) = True Then
                                cus2string = ""
                            Else
                                cus2string = rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus2no")
                            End If

                            strCurr = rs_QuotH.Tables("RESULT").DefaultView(0)("qud_curcde") '*** Obtain Currency Code

                            'sh = "㊣QUOTNHDR_QUOTD※A※" & Quotno & "※" & rs_QuotH("qud_cus1no") & _
                            '                        "※" & rs_QuotH("qud_cus2no") & "※" & rs_QuotH("qud_currel") & _
                            '                        "※" & rs_QuotH("qud_curcde") & "※" & rs_QuotH("qud_creusr") '& "※" & strQutsts
                            'sqlrs2 = objBSGate.Modify(gsConnStr, "sp_general", sh)

                            Cursor = Cursors.WaitCursor

                            'gspStr = "sp_insert_QUOTNHDR_QUOTD '" & rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cocde") & "','" & _
                            '                                        Quotno & "','" & _
                            '                                        rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus1no") & "','" & _
                            '                                        rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus2no") & "','" & _
                            '                                        rs_QuotH.Tables("RESULT").DefaultView(0)("qud_currel") & "','" & _
                            '                                        rs_QuotH.Tables("RESULT").DefaultView(0)("qud_curcde") & "','" & _
                            '                                        rs_QuotH.Tables("RESULT").DefaultView(0)("qud_creusr") & "'"
                            gspStr = "sp_insert_QUOTNHDR_QUOTD '" & gsCompany1 & "','" & _
                                                                    Quotno & "','" & _
                                                                    rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus1no") & "','" & _
                                                                    rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus2no") & "','" & _
                                                                    rs_QuotH.Tables("RESULT").DefaultView(0)("qud_currel") & "','" & _
                                                                    rs_QuotH.Tables("RESULT").DefaultView(0)("qud_curcde") & "','" & _
                                                                    rs_QuotH.Tables("RESULT").DefaultView(0)("qud_creusr") & "'"
                            rtnLong = execute_SQLStatement(gspStr, sqlrs2, rtnStr)
                            gspStr = ""

                            Cursor = Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SaveQuotation sp_insert_QUOTNHDR_QUOTD :" & rtnStr)
                                IsUpdated = False
                                Exit Sub
                            Else
                                IsUpdated = True
                                no = no + 1
                            End If

                            sqlrs2.Tables.Clear()
                        End If
                    End If

                    '*************************** Insert Quot Detail ***************************
                    Dim flgHasOldItm As Boolean = False

                    strQutsts = ""

                    Dim rs_checkhold As New DataSet

                    rs_checkhold = rs_Quot.Copy

                    If rs_checkhold.Tables("RESULT").Rows.Count > 0 Then
                        For index As Integer = 0 To rs_checkhold.Tables("RESULT").Rows.Count - 1
                            If rs_checkhold.Tables("RESULT").Rows(index)("qud_cus1no").ToString = cus1string And _
                                cus1no(Y) <> "" And _
                                rs_checkhold.Tables("RESULT").Rows(index)("qud_cus2no").ToString = cus2string And _
                                rs_checkhold.Tables("RESULT").Rows(index)("qud_del").ToString = "O" And _
                                rs_checkhold.Tables("RESULT").Rows(index)("qud_cocde").ToString = CoCde(Y) Then
                                strQutsts = "H"
                                Exit For
                            Else
                                strQutsts = "A"
                            End If
                        Next
                    End If

                    rs_checkhold.Tables.Clear()

                    For index As Integer = 0 To rs_Quot.Tables("RESULT").Rows.Count - 1
                        If IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no")) Then
                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") = ""
                        End If

                        If rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no").ToString = cus1string And _
                            cus1no(Y) <> "" And _
                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no").ToString = cus2string And _
                            (rs_Quot.Tables("RESULT").Rows(index)("qud_del").ToString = "N" Or _
                             rs_Quot.Tables("RESULT").Rows(index)("qud_del").ToString = "O") And _
                            rs_Quot.Tables("RESULT").Rows(index)("qud_cocde").ToString = CoCde(Y) Then

                            'Erase colcde     '*** release array
                            For index1 As Integer = 0 To 99
                                colcde(index1) = ""
                            Next

                            '*** Set the Quotation Status to HLD when  flgHasOldItm = True
                            If flgHasOldItm = False Then
                                If rs_Quot.Tables("RESULT").Rows(index)("qud_del").ToString = "O" Then
                                    If setHold(CStr(Quotno)) = 1 Then
                                        IsUpdated = True
                                    Else
                                        IsUpdated = False
                                    End If

                                    flgHasOldItm = True
                                End If
                            End If

                            colnum = 0
                            n = 0

                            Dim tempColr As String
                            Dim ColSeq As Integer

                            If IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_colcde")) = False Then
                                Number = UBound(Split(rs_Quot.Tables("RESULT").Rows(index)("qud_colcde").ToString, ";"))
                                Number = Number - 1

                                If Number >= 0 Then
                                    For n = 0 To Number
                                        tempColr = Split(rs_Quot.Tables("RESULT").Rows(index)("qud_colcde").ToString, ";")(n)
                                        If tempColr <> "" Then
                                            colcde(colnum) = Split(rs_Quot.Tables("RESULT").Rows(index)("qud_colcde").ToString, ";")(n)
                                            colnum = colnum + 1     '*** count Numer of Color is this Item
                                        End If
                                    Next n
                                End If
                            End If

                            n = 0
                            colnum = colnum - 1

                            If colnum <= 0 Then
                                colnum = 0
                            End If

                            For n = 0 To colnum
                                If IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no")) = True Or _
                                    IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no")) = False, rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no"), "") = "" Then
                                    rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") = ""
                                    rs_Quot.Tables("RESULT").Rows(index)("qud_cus2na") = ""
                                End If

                                'XXXXXXXXXXXXXXXXXXXX New Method to Obtain MOQ/MOA -- Start XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                                '*** Calcualte Primary Customer's Selling Price
                                dblCus1SP = CDbl(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_basprc")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_basprc")))

                                If dblCus1SP <> 0 Then
                                    'S = "㊣MarkupFml_qu※S※" & rs_Quot("qud_cus1no") & "※" & rs_Quot("qud_itmno") & "※" & dblCus1SP
                                    'rs_Cus2SP = objBSGate.Enquire(gsConnStr, "sp_general", S)

                                    Cursor = Cursors.WaitCursor

                                    gspStr = "sp_select_MarkupFml_qu '','" & _
                                                                            rs_QuotH.Tables("RESULT").DefaultView(0)("qud_cus1no") & "','" & _
                                                                            rs_QuotH.Tables("RESULT").DefaultView(0)("qud_itmno") & "','" & _
                                                                            dblCus1SP & "'"
                                    rtnLong = execute_SQLStatement(gspStr, rs_MARKUP_prc, rtnStr)
                                    gspStr = ""

                                    Cursor = Cursors.Default

                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading SaveQuotation sp_select_MarkupFml_qu :" & rtnStr)
                                    End If

                                    If rs_MARKUP_prc.Tables("RESULT").Rows.Count > 0 Then
                                        dblCus1SP = CDbl(IIf(IsDBNull(rs_MARKUP_prc.Tables("RESULT").Rows(0)(0)), 0, rs_MARKUP_prc.Tables("RESULT").Rows(0)(0)))
                                    End If
                                End If

                                '*** split the color code and calculate the MOQ/MOA separately
                                'S = "㊣ItemMaster_moq_moa_qu_wunttyp※S※" & rs_Quot("qud_cus1no").Value & "※" & rs_Quot("qud_cus2no").Value & "※" & _
                                '    rs_Quot("qud_itmno").Value & "※" & _
                                '    rs_Quot("qud_untcde").Value & "※" & rs_Quot("qud_conftr").Value & "※" & _
                                '    IIf(IsNull(rs_Quot("qud_inrqty")) = True, 0, rs_Quot("qud_inrqty")) & "※" & _
                                '    IIf(IsNull(rs_Quot("qud_mtrqty")) = True, 0, rs_Quot("qud_mtrqty")) & "※" & _
                                '    colcde(n) & "※" & dblCus1SP & "※" & strCurr
                                'rs_moq_moa = objBSGate.Enquire(gsConnStr, "sp_general", S)

                                Cursor = Cursors.WaitCursor

                                gspStr = "sp_select_ItemMaster_moq_moa_qu_wunttyp '" & gsCompany1 & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_untcde") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_conftr") & "','" & _
                                                                            IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_inrqty")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_inrqty")) & "','" & _
                                                                            IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_mtrqty")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_mtrqty")) & "','" & _
                                                                            colcde(n) & "','" & _
                                                                            dblCus1SP & "','" & _
                                                                            strCurr & "'"
                                rtnLong = execute_SQLStatement(gspStr, rs_SYTIESTR, rtnStr)
                                gspStr = ""

                                Cursor = Cursors.Default

                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SaveQuotation sp_select_ItemMaster_moq_moa_qu_wunttyp :" & rtnStr)
                                End If

                                '*** pre-set MOQ, MOA and MOQ/MOA Flag
                                ORI_MOFLAG = ""
                                ORI_MOQ = 0
                                ORI_MOA = 0
                                strMOQUNTTYP = ""
                                moq = 0
                                moa = 0

                                If rs_SYTIESTR.Tables("RESULT").Rows.Count = 0 Then
                                    MsgBox("No MOQ & MOA found of this Item")
                                Else
                                    ORI_MOFLAG = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOFLAG")), "", rs_SYTIESTR.Tables("RESULT").Rows(0)("MOFLAG"))
                                    '*** Store MOQ value in ORI_MOQ
                                    ORI_MOQ = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ")), 0, rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ"))
                                    strMOQUNTTYP = "CTN"

                                    If IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")) = False And _
                                        IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE")) = False Then
                                        If strCurr <> rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE").ToString And _
                                            rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") > 0 Then
                                            For index1 As Integer = 0 To rs_SYTIESTR.Tables("RESULT").Rows.Count - 1
                                                dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")
                                                If strCurr = dr(0)("ysi_cde").ToString Then
                                                    dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE") + "'")

                                                    '*** Store MOQ value in ORI_MOQ
                                                    ORI_MOA = CLng(roundup(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") * dr(0)("ysi_selrat")))
                                                Else
                                                    dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + strCurr + "'")

                                                    '*** Store MOQ value in ORI_MOQ
                                                    ORI_MOA = CLng(roundup(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") / dr(0)("ysi_selrat")))
                                                End If
                                            Next
                                        Else
                                            '*** Store MOQ value in ORI_MOQ
                                            ORI_MOA = CDec(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA"))
                                        End If
                                    End If
                                End If

                                '*** set moq, moa value base on MOQ/MOA Flag
                                If ORI_MOFLAG = "Q" Then
                                    moq = ORI_MOQ
                                    moa = 0
                                    ORI_MOA = 0
                                ElseIf ORI_MOFLAG = "A" Then
                                    moq = ORI_MOQ
                                    moa = ORI_MOA
                                End If
                                'XXXXXXXXXXXXXXXXXXXX New Method to Obtain MOQ/MOA -- End XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

                                'S = "㊣QUOTNDTL_QUOTD_insert※S※" & Quotno & "※" & rs_Quot("qud_itmno") & _
                                '             "※" & colcde(n) & "※" & rs_Quot("qud_alsitmno") & "※" & rs_Quot("qud_alscolcde") & "※" & rs_Quot("qud_pckseq") & _
                                '             "※" & IIf(IsNull(rs_Quot("qud_inrqty")) = True, 0, rs_Quot("qud_inrqty")) & "※" & IIf(IsNull(rs_Quot("qud_mtrqty")) = True, 0, rs_Quot("qud_mtrqty")) & _
                                '             "※" & IIf(IsNull(rs_Quot("qud_cft")) = True, 0, rs_Quot("qud_cft")) & _
                                '             "※" & ORI_MOFLAG & "※" & ORI_MOQ & "※" & ORI_MOA & _
                                '             "※" & moq & "※" & moa & "※" & rs_Quot("qud_untcde") & _
                                '             "※" & strCurr & "※" & IIf(IsNull(rs_Quot("qud_cu1pri")) = True, 0, rs_Quot("qud_cu1pri")) & _
                                '             "※" & IIf(IsNull(rs_Quot("qud_cu2pri")) = True, 0, rs_Quot("qud_cu2pri")) & "※" & IIf(IsNull(rs_Quot("qud_disc")) = True, 0, rs_Quot("qud_disc")) & _
                                '             "※" & IIf(IsNull(rs_Quot("qud_smpqty")) = True, 0, rs_Quot("qud_smpqty")) & _
                                '             "※" & IIf(IsNull(rs_Quot("qud_smpunt")) = True, 0, rs_Quot("qud_smpunt")) & _
                                '             "※" & rs_Quot("qud_note") & _
                                '             "※" & rs_Quot("qud_img") & "※" & rs_Quot("qud_modify") & _
                                '             "※" & IIf(IsNull(rs_Quot("qud_prcsec")) = True, 0, rs_Quot("qud_prcsec")) & "※" & IIf(IsNull(rs_Quot("qud_grsmgn")) = True, 0, rs_Quot("qud_grsmgn")) & _
                                '             "※" & rs_Quot("qud_creusr") & "※" & rs_Quot("qud_cus2no") & _
                                '             "※" & rs_Quot("qud_cus2na") & "※" & rs_Quot("qud_cus1no") & _
                                '             "※" & IIf(IsNull(rs_Quot("qud_basprc")) = True, 0, rs_Quot("qud_basprc")) & "※" & strMOQUNTTYP & "※" & strQutsts & "※" & rs_Quot("qud_qutdat") & _
                                '             "※" & rs_Quot("qud_imu_cus1no") & _
                                '             "※" & rs_Quot("qud_imu_cus2no") & _
                                '             "※" & rs_Quot("qud_imu_hkprctrm") & _
                                '             "※" & rs_Quot("qud_imu_ftyprctrm") & _
                                '             "※" & rs_Quot("qud_imu_trantrm") & _
                                '             "※" & rs_Quot("qud_imu_effdat") & _
                                '             "※" & rs_Quot("qud_imu_expdat")
                                'rs_qrs() = objBSGate.Enquire(gsConnStr, "sp_general", S)

                                Cursor = Cursors.WaitCursor

                                gspStr = "sp_select_QUOTNDTL_QUOTD_insert '" & rs_Quot.Tables("RESULT").Rows(index)("qud_cocde") & "','" & Quotno & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "','" & colcde(n) & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_alsitmno") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_alscolcde") & "','" & _
                                                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_pckseq")) & "','" & Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_inrqty")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_inrqty"))) & "','" & _
                                                                            Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_mtrqty")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_mtrqty"))) & "','" & Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_cft")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_cft"))) & "','" & _
                                                                            ORI_MOFLAG & "','" & ORI_MOQ & "','" & _
                                                                            ORI_MOA & "','" & moq & "','" & _
                                                                            moa & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_untcde") & "','" & _
                                                                            strCurr & "','" & Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_cu1pri")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_cu1pri"))) & "','" & _
                                                                            Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_cu2pri")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_cu2pri"))) & "','" & Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_disc")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_disc"))) & "','" & _
                                                                            Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_smpqty")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_smpqty"))) & "','" & IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_smpunt")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_smpunt")) & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_note") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_img") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_modify") & "','" & IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_prcsec")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_prcsec")) & "','" & _
                                                                            Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_grsmgn")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_grsmgn"))) & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_creusr") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus2na") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "','" & Val(IIf(IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_basprc")) = True, 0, rs_Quot.Tables("RESULT").Rows(index)("qud_basprc"))) & "','" & _
                                                                            strMOQUNTTYP & "','" & strQutsts & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_qutdat") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_imu_cus1no") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_imu_cus2no") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_imu_hkprctrm") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_imu_ftyprctrm") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_imu_trantrm") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_imu_effdat") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_imu_expdat") & "'"
                                rtnLong = execute_SQLStatement(gspStr, rs_qrs, rtnStr)
                                gspStr = ""

                                Cursor = Cursors.Default

                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SaveQuotation sp_select_QUOTNDTL_QUOTD_insert :" & rtnStr)
                                    IsUpdated = False
                                    Exit Sub
                                Else
                                    IsUpdated = True
                                    '********Check Item Master's Item Status **********
                                    If rs_qrs.Tables("RESULT").Rows(0)(0).ToString <> "HLD" Then
                                        real_seq = rs_qrs.Tables("RESULT").Rows(0)(0)

                                        'S = "㊣PDA_QUOT※U※" & rs_Quot("qud_cocde").Value & "※" & rs_Quot("qud_cus1no").Value & "※" & rs_Quot("qud_cus2no").Value & "※" & _
                                        'strTmpQutNo & "※" & rs_Quot("qud_seq").Value & "※" & rs_Quot("qud_itmno").Value & "※" & _
                                        '"G" & "※" & Quotno & "※" & real_seq & "※" & gsUsrID
                                        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                                        Cursor = Cursors.WaitCursor

                                        gspStr = "sp_update_PDA_QUOT '','" & rs_Quot.Tables("RESULT").Rows(index)("qud_cocde") & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") & "','" & _
                                                                            strTmpQutNo & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_seq")) & "','" & _
                                                                            rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "','G'" & ",'" & _
                                                                            Quotno & "','" & real_seq & "','" & _
                                                                            gsUsrID & "'"
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        gspStr = ""

                                        Cursor = Cursors.Default

                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on loading SaveQuotation sp_update_PDA_QUOT :" & rtnStr)
                                        End If
                                    End If
                                End If
                                '**************************************************

                                '******************* Insert Quot Detail Assort Item ***************
                                If rs_Assort.Tables("RESULT").DefaultView.Count > 0 And rs_qrs.Tables("RESULT").Rows(0)(0).ToString <> "HLD" Then
                                    For index1 As Integer = 0 To rs_Assort.Tables("RESULT").DefaultView.Count - 1
                                        If IsDBNull(rs_Assort.Tables("RESULT").DefaultView(index1)("qud_cus2no")) = True Then
                                            rs_Assort.Tables("RESULT").DefaultView(index1)("qud_cus2no") = ""
                                        End If
                                    Next

                                    sFilter = "qud_assitm = '" & rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & _
                                                "' and qud_cus1no = '" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & _
                                                "' and qud_cus2no = '" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") & "'"
                                    rs_Assort.Tables("RESULT").DefaultView.RowFilter = sFilter

                                    Dim flgNeedHLD As Boolean
                                    Dim flgNewFormat As Boolean
                                    Dim flgOldFormat As Boolean
                                    Dim rscheckcheck As New DataSet

                                    flgNeedHLD = False
                                    flgNewFormat = False
                                    flgOldFormat = False

                                    For index1 As Integer = 0 To rs_Assort.Tables("RESULT").DefaultView.Count - 1
                                        '**************Check Old Item and Format************
                                        '*** Check Old Item
                                        If flgNeedHLD = False Then
                                            'strCheck = "㊣IMBASINF※S※" & rs_Assort("qud_itmno")
                                            'rscheckcheck = objBSGate.Enquire(gsConnStr, "sp_general", strCheck)

                                            Cursor = Cursors.WaitCursor

                                            gspStr = "sp_select_IMBASINF '','" & rs_Assort.Tables("RESULT").DefaultView(index1)("qud_itmno") & "'"
                                            rtnLong = execute_SQLStatement(gspStr, rscheckcheck, rtnStr)
                                            gspStr = ""

                                            Cursor = Cursors.Default

                                            If rtnLong <> RC_SUCCESS Then
                                                MsgBox("Error on loading SaveQuotation sp_select_IMBASINF :" & rtnStr)
                                                Exit Sub
                                            End If

                                            If rscheckcheck.Tables("RESULT").Rows.Count > 0 Then
                                                If Microsoft.VisualBasic.Left(rscheckcheck.Tables("RESULT").Rows(0)("ibi_itmsts").ToString, 3) = "OLD" Then
                                                    If setHold(Quotno) = 1 Then
                                                        IsUpdated = True
                                                    Else
                                                        IsUpdated = False
                                                    End If
                                                    flgNeedHLD = True
                                                End If
                                            End If
                                        End If

                                        '*** Check Format
                                        If flgNeedHLD = False Then
                                            If isNewItemFormat(rs_Assort.Tables("RESULT").DefaultView(index1)("qud_itmno").ToString, False) Then
                                                flgNewFormat = True
                                            Else
                                                flgOldFormat = True
                                            End If

                                            If flgOldFormat = True And flgNewFormat = True Then
                                                If setHold(Quotno) = 1 Then
                                                    IsUpdated = True
                                                Else
                                                    IsUpdated = False
                                                End If
                                                flgNeedHLD = True
                                            End If
                                        End If

                                        '******************************************************************
                                        '*** alias item no and color code
                                        'ST = "㊣QUASSINF_QUOTSD※A※" & Quotno & "※" & rs_Assort("qud_assitm") & "※" & real_seq & _
                                        '                      "※" & rs_Assort("qud_itmno") & "※" & rs_Assort("qud_colcde") & "※" & rs_Assort("qud_alsitmno") & "※" & rs_Assort("qud_alscolcde") & _
                                        '                      "※" & IIf(IsNull(rs_Assort("qud_inrqty")) = True, 0, rs_Assort("qud_inrqty")) & "※" & IIf(IsNull(rs_Assort("qud_mtrqty")) = True, 0, rs_Assort("qud_mtrqty")) & _
                                        '                      "※" & rs_Assort("qud_untcde") & "※" & rs_Assort("qud_creusr")
                                        'sqlrs1 = objBSGate.Modify(gsConnStr, "sp_general", ST)

                                        Cursor = Cursors.WaitCursor

                                        gspStr = "sp_insert_QUASSINF_QUOTSD '" & gsCompany1 & "','" & Quotno & "','" & _
                                                                                    rs_Assort.Tables("RESULT").DefaultView(index1)("qud_assitm") & "','" & real_seq & "','" & _
                                                                                    rs_Assort.Tables("RESULT").DefaultView(index1)("qud_itmno") & "','" & rs_Assort.Tables("RESULT").DefaultView(index1)("qud_colcde") & "','" & _
                                                                                    rs_Assort.Tables("RESULT").DefaultView(index1)("qud_alsitmno") & "','" & rs_Assort.Tables("RESULT").DefaultView(index1)("qud_alscolcde") & "','" & _
                                                                                    Val(IIf(IsDBNull(rs_Assort.Tables("RESULT").DefaultView(index1)("qud_inrqty")) = True, 0, rs_Assort.Tables("RESULT").DefaultView(index1)("qud_inrqty"))) & "','" & Val(IIf(IsDBNull(rs_Assort.Tables("RESULT").DefaultView(index1)("qud_mtrqty")) = True, 0, rs_Assort.Tables("RESULT").DefaultView(index1)("qud_mtrqty"))) & "','" & _
                                                                                    rs_Assort.Tables("RESULT").DefaultView(index1)("qud_untcde") & "','" & rs_Assort.Tables("RESULT").DefaultView(index1)("qud_creusr") & "'"
                                        rtnLong = execute_SQLStatement(gspStr, rscheckcheck, rtnStr)
                                        gspStr = ""

                                        Cursor = Cursors.Default

                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on loading SaveQuotation sp_insert_QUASSINF_QUOTSD :" & rtnStr)
                                            IsUpdated = False
                                            Exit Sub
                                        Else
                                            IsUpdated = True
                                        End If

                                        sqlrs1.Tables.Clear()

                                        '***************** Write Assortment  Detail To Log File **************
                                        'S = "㊣QUXERPDA※A※" & rs_Assort("qud_assitm") & "※" & "" & "※" & "" & "※" & real_seq & "※" & _
                                        '                                rs_Assort("qud_itmno") & "※" & "" & "※" & "" & "※" & "" & "※" & _
                                        '                                rs_Assort("qud_colcde") & "※" & 0 & "※" & rs_Assort("qud_inrqty") & "※" & rs_Assort("qud_mtrqty") & "※" & _
                                        '                                0 & "※" & 0 & "※" & 0 & "※" & rs_Assort("qud_untcde") & "※" & _
                                        '                                0 & "※" & 0 & "※" & " " & "※" & 0 & "※" & _
                                        '                                0 & "※" & " " & "※" & " " & "※" & 0 & "※" & _
                                        '                                0 & "※" & 0 & "※" & " " & "※" & " " & "※" & _
                                        '                                " " & "※" & rs_Assort("qud_alsitmno") & "※" & rs_Assort("qud_alscolcde") & "※" & " " & "※" & " " & "※" & " " & "※" & _
                                        '                                rs_Assort("qud_creusr") & "※" & Date & "※" & Me.Name
                                        'rsAS = objBSGate.Modify(gsConnStr, "sp_general", S)

                                        Cursor = Cursors.WaitCursor

                                        gspStr = "sp_insert_QUXERPDA '" & gsCompany1 & "','" & _
                                                                            rs_Assort.Tables("RESULT").Rows(index)("qud_assitm") & "',''," & _
                                                                            "'','" & real_seq & "','" & _
                                                                            rs_Assort.Tables("RESULT").Rows(index)("qud_itmno") & "',''," & _
                                                                            "'',''" & _
                                                                            rs_Assort.Tables("RESULT").Rows(index)("qud_colcde") & "','0','" & _
                                                                            Val(rs_Assort.Tables("RESULT").Rows(index)("qud_inrqty")) & "','" & Val(rs_Assort.Tables("RESULT").Rows(index)("qud_mtrqty")) & "'," & _
                                                                            "'0','0'," & _
                                                                            "'0','" & rs_Assort.Tables("RESULT").Rows(index)("qud_untcde") & "'," & _
                                                                            "'0','0'," & _
                                                                            "'','0'," & _
                                                                            "'0',''," & _
                                                                            "'','0'," & _
                                                                            "'0','0'," & _
                                                                            "'',''," & _
                                                                            "'','" & rs_Assort.Tables("RESULT").Rows(index)("qud_alsitmno") & "','" & _
                                                                            rs_Assort.Tables("RESULT").Rows(index)("qud_alscolcde") & "',''," & _
                                                                            "'','','" & _
                                                                            rs_Assort.Tables("RESULT").Rows(index)("qud_creusr") & "','" & DateTime.Now & "','" & _
                                                                            Me.Name & "'"
                                        rtnLong = execute_SQLStatement(gspStr, rsAS, rtnStr)
                                        gspStr = ""

                                        Cursor = Cursors.Default

                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on loading SaveQuotation sp_insert_QUXERPDA :" & rtnStr)
                                        End If
                                    Next
                                End If
                            Next n
                        End If
                    Next

                    Dim QUCPTBKD As String

                    'QUCPTBKD = "㊣QUCPTBKD_PDA※A※" & Quotno
                    'sqlQ = objBSGate.Modify(gsConnStr, "sp_general", QUCPTBKD)

                    Cursor = Cursors.WaitCursor

                    gspStr = "sp_insert_QUCPTBKD_PDA '" & gsCompany1 & "','" & Quotno & "'"
                    rtnLong = execute_SQLStatement(gspStr, sqlQ, rtnStr)
                    gspStr = ""

                    Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SaveQuotation sp_insert_QUCPTBKD_PDA :" & rtnStr)
                        IsUpdated = False
                    Else
                        IsUpdated = True
                    End If

                    sqlQ.Tables.Clear()
                Next Y
            End If
        End If

        MDBrs.Tables.Clear()
        MDB_Filter.Tables.Clear()
        rs_Quot.Tables.Clear()
        rs_fQuot.Tables.Clear()
        rs_Assort.Tables.Clear()
        rs_QuotH.Tables.Clear()

        Dim m As Integer

        'result = result & strSessId & Chr(13) + Chr(10)
        result = result & Chr(13) & Chr(10)

        For m = 0 To no - 1
            result = result & "Quotation No. : " & Quot_no(m) & Chr(13) & Chr(10)
        Next m
        result = result & Chr(13) + Chr(10)

        If IsUpdated = True Then
            DelQuotD.Tables.Clear()
            DelQuotSD.Tables.Clear()
        End If

        Cursor = Cursors.Default

        Me.KeyPreview = True
    End Sub

    Private Sub GetResult()
        Dim strCus1No As String
        Dim strCus2No As String

        rs_Result.Tables.Clear()
        dgResult.DataSource = Nothing

        If Trim(cboPriCust.Text) = "" Then
            strCus1No = ""
        Else
            strCus1No = Trim(Split(cboPriCust.Text, "-")(0))
        End If

        If Trim(cboSecCust.Text) = "" Then
            strCus2No = ""
        Else
            strCus2No = Trim(Split(cboSecCust.Text, "-")(0))
        End If

        'S = "㊣PDA_Quot※S※※" & gsUsrID & "※" & strCus1No & "※" & strCus2No & "※" & Format(txtDateFrom.Text, "yyyymmdd") & "※" & Format(txtDateTo.Text, "yyyymmdd") & "※" & IIf(txtTmpQutNo.Text = "", "", txtTmpQutNo.Text) & "※6"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_PDA_Quot '','','" & gsUsrID & "','" & strCus1No & "','" & strCus2No & "','" & DateFrom & "','" & DateTo & "','" & IIf(txtTmpQutNo.Text = "", "", txtTmpQutNo.Text) & "','6'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading GetResult sp_select_PDA_Quot :" & rtnStr)
            Exit Sub
        End If

        If rs_Result.Tables("RESULT").DefaultView.Count > 0 Then
            Dim i, j As Integer
            Dim flgFound As Boolean

            Dim dr() As DataRow

            dr = rs_Result.Tables("RESULT").Select("")

            For i = 0 To dr.Length - 1
                flgFound = False

                For j = 0 To rs_DistinctQ.Tables("RESULT").DefaultView.Count - 1
                    If rs_DistinctQ.Tables("RESULT").DefaultView(j)("qud_tmpqutno") = dr(i)("qud_tmpqutno") Then
                        flgFound = True
                        Exit For
                    End If
                Next

                If flgFound = False Then
                    dr(i).Delete()
                    dr(i).AcceptChanges()
                End If
            Next

            'For i = 0 To rs_Result.Tables("RESULT").DefaultView.Count - 1
            '    flgFound = False

            '    For j = 0 To rs_DistinctQ.Tables("RESULT").DefaultView.Count - 1
            '        If rs_DistinctQ.Tables("RESULT").DefaultView(j)("qud_tmpqutno") = rs_Result.Tables("RESULT").DefaultView(i)("qud_tmpqutno") Then
            '            flgFound = True
            '            Exit For
            '        End If
            '    Next

            '    If flgFound = False Then
            '        rs_Result.Tables("RESULT").DefaultView(i).Delete()
            '        i += 1
            '    End If
            '    rs_Result.Tables("RESULT").AcceptChanges()
            'Next
            dgResult.DataSource = rs_Result.Tables("RESULT").DefaultView

            Call DisplayResult()
            btcPDA.TabPages(2).Enabled = False
            btcPDA.TabPages(2).Enabled = True
            btcPDA.TabPages(1).Enabled = False
            btcPDA.TabPages(0).Enabled = False
            btcPDA.SelectedIndex = 2
        End If
    End Sub

    Private Sub DisplayResult()
        Dim intCol As Integer

        intCol = 0

        With dgResult
            .Columns(intCol).HeaderText = "Co. Cde."
            .Columns(intCol).Width = 60
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Pri. Cust."
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Sec. Cust."
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Temp. Qut. No."
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Qut. No."
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            'For iCol As Integer = 0 To intCol - 1
            '    .Columns(iCol).ReadOnly = False
            '    .Columns(iCol).Visible = False
            'Next
        End With
    End Sub

    Private Sub Update_Price(ByVal rate As Double, ByVal sign As String)
        If sign = "/" Then
            qud_cu1pri = qud_cu1pri / rate
            qud_cu2pri = qud_cu2pri / rate
            qud_basprc = qud_basprc / rate
        Else
            qud_cu1pri = qud_cu1pri * rate
            qud_cu2pri = qud_cu2pri * rate
            qud_basprc = qud_basprc * rate
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        lblProgress.Text = "Uploading Quotation. Please Wait."
        Me.Refresh()

        Call UploadQuotation()

        lblProgress.Text = ""
        Me.Refresh()
    End Sub

    Private Sub cboPriCust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPriCust.KeyPress
        If e.KeyChar = Chr(13) Then
            Call cboPriCustPress()
        End If
    End Sub

    Private Sub cboPriCustPress()
        Dim strCus1No As String
        Dim strCus2No As String

        txtTmpQutNo.Text = ""
        txtDateFrom.Text = Format(Now(), "MM/dd/yyyy")
        txtDateTo.Text = Format(Now(), "MM/dd/yyyy")

        cboSecCust.Items.Clear()

        If Trim(cboPriCust.Text) = "" Then
            strCus1No = ""
            Exit Sub
        Else
            strCus1No = Trim(Split(cboPriCust.Text, "-")(0))
        End If

        'S = "㊣CUBASINF_Q※S※" & strCus1No & "※Secondary"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUBASINF_Q '','" & strCus1No & "','Secondary'"
        rtnLong = execute_SQLStatement(gspStr, rs_SecCust, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cboPriCust_KeyPress sp_select_CUBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_SecCust.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_SecCust.Tables("RESULT").Rows.Count - 1
                cboSecCust.Items.Add(rs_SecCust.Tables("RESULT").Rows(index)("csc_seccus") + " - " + _
                                     rs_SecCust.Tables("RESULT").Rows(index)("cbi_cussna"))
            Next
        End If
    End Sub

    Private Sub cboPriCust_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriCust.KeyUp
        Call auto_search_combo(cboPriCust)
    End Sub

    Private Sub cboPriCust_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriCust.LostFocus
        If ValidateCombo(cboPriCust) = True Then
            Call cboPriCustPress()
        End If
    End Sub

    Private Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If
        ValidateCombo = False
        Dim i As Integer
        Dim S As String
        S = Combo1.Text
        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items(i).ToString) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next
        If Not ValidateCombo Then
            MsgBox("Invalid Data! Please try again.")
            On Error Resume Next
            Combo1.Focus()
            On Error GoTo 0
        End If
    End Function

    Private Sub dgTempAss_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTempAss.CellClick
        If rs_TempAss.Tables("RESULT").DefaultView.Count > 0 Then
            If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
                Dim hasChanged As Boolean

                hasChanged = False

                If rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("Del").ToString = "N" Then
                    Dim iCnt As Integer

                    iCnt = 0

                    For index As Integer = 0 To rs_TempAss.Tables("RESULT").DefaultView.Count - 1
                        If rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("Del").ToString = "Y" Then
                            iCnt = iCnt + 1
                        End If
                    Next

                    If rs_TempAss.Tables("RESULT").DefaultView.Count - iCnt = 1 Then
                        MsgBox("This item is the last assorted item. It can't be deleted.")
                        Exit Sub
                    Else
                        rs_TempAss.Tables("RESULT").Columns("Del").ReadOnly = False
                        rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "Y"
                        rs_TempAss.Tables("RESULT").Columns("Del").ReadOnly = True
                        hasChanged = True
                    End If

                Else
                    rs_TempAss.Tables("RESULT").Columns("Del").ReadOnly = False
                    rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "N"
                    rs_TempAss.Tables("RESULT").Columns("Del").ReadOnly = True
                    hasChanged = True
                End If

                Call SetUpdateStatus("A", e.RowIndex)

                If rs_TempAss.Tables("RESULT").DefaultView.Count = 0 Then
                    Exit Sub
                Else
                    If hasChanged = True Then
                        Dim rs As New DataSet

                        'S = "㊣PDA_QUOT_ASS※U※※" & rs_TempAss("qud_cus1no").Value & "※" & rs_TempAss("qud_cus2no").Value & "※" & _
                        'rs_TempAss("qud_tmpqutno").Value & "※" & rs_TempAss("qud_assitm").Value & "※" & rs_TempAss("qud_seq").Value & "※" & rs_TempAss("qud_itmno").Value & "※" & _
                        'IIf(rs_TempAss("Del").Value = "Y", "D", "") & "※" & gsUsrID
                        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                        Cursor = Cursors.WaitCursor

                        gspStr = "sp_update_PDA_QUOT_ASS '','" & _
                                                                rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("qud_cus1no") & "','" & _
                                                                rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("qud_cus2no") & "','" & _
                                                                rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("qud_tmpqutno") & "','" & _
                                                                rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("qud_assitm") & "','" & _
                                                                Val(rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("qud_seq")) & "','" & _
                                                                rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("qud_itmno") & "','" & _
                                                                IIf(rs_TempAss.Tables("RESULT").DefaultView(e.RowIndex)("Del").ToString = "Y", "D", "") & "','" & _
                                                                gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        gspStr = ""

                        Cursor = Cursors.Default

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading dgTempAss_CellClick sp_select_CUBASINF_Q :" & rtnStr)
                            Exit Sub
                        End If
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub SetUpdateStatus(ByVal rs As String, ByVal index As Integer)
        If rs = "Q" Then
            rs_TempQ.Tables("RESULT").Columns("Upd").ReadOnly = False
            rs_TempQ.Tables("RESULT").DefaultView(index)("Upd") = "Y"
            rs_TempQ.Tables("RESULT").AcceptChanges()
            rs_TempQ.Tables("RESULT").Columns("Upd").ReadOnly = True
        ElseIf rs = "A" Then
            rs_TempAss.Tables("RESULT").Columns("Upd").ReadOnly = False
            rs_TempAss.Tables("RESULT").DefaultView(index)("Upd") = "Y"
            rs_TempAss.Tables("RESULT").AcceptChanges()
            rs_TempAss.Tables("RESULT").Columns("Upd").ReadOnly = True
        End If
    End Sub

    Private Sub dgTempAss_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgTempAss.ColumnHeaderMouseClick
        If e.ColumnIndex = 1 Then
            If sort_seq_Ass = False Then
                rs_TempAss.Tables("RESULT").DefaultView.Sort = " qud_itmno"
                sort_seq_Ass = True
            Else
                rs_TempAss.Tables("RESULT").DefaultView.Sort = " qud_itmno desc"
                sort_seq_Ass = False
            End If
        End If

        If e.ColumnIndex = 2 Then
            If sort_seq_Ass = False Then
                rs_TempAss.Tables("RESULT").DefaultView.Sort = " qud_venitm"
                sort_seq_Ass = True
            Else
                rs_TempAss.Tables("RESULT").DefaultView.Sort = " qud_venitm desc"
                sort_seq_Ass = False
            End If
        End If
    End Sub

    Private Sub dgTempQ_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTempQ.CellClick
        If rs_TempQ.Tables("RESULT").DefaultView.Count > 0 Then
            If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
                rs_TempQ.Tables("RESULT").Columns(e.ColumnIndex).ReadOnly = False
                If rs_TempQ.Tables("RESULT").DefaultView(e.RowIndex)("Del").ToString = "N" Then
                    rs_TempQ.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "Y"
                Else
                    rs_TempQ.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "N"
                End If
                rs_TempQ.Tables("RESULT").AcceptChanges()
                rs_TempQ.Tables("RESULT").Columns(e.ColumnIndex).ReadOnly = True

                Call SetUpdateStatus("Q", e.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgTempQ_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgTempQ.ColumnHeaderMouseClick
        If e.ColumnIndex = 2 Then
            If sort_seq = False Then
                rs_TempQ.Tables("RESULT").DefaultView.Sort = " qud_tmpqutno"
                sort_seq = True
            Else
                rs_TempQ.Tables("RESULT").DefaultView.Sort = " qud_tmpqutno desc"
                sort_seq = False
            End If
        End If

        If e.ColumnIndex = 3 Then
            If sort_seq = False Then
                rs_TempQ.Tables("RESULT").DefaultView.Sort = " qud_seq"
                sort_seq = True
            Else
                rs_TempQ.Tables("RESULT").DefaultView.Sort = " qud_seq desc"
                sort_seq = False
            End If
        End If

        If e.ColumnIndex = 4 Then
            If sort_seq = False Then
                rs_TempQ.Tables("RESULT").DefaultView.Sort = " qud_itmno"
                sort_seq = True
            Else
                rs_TempQ.Tables("RESULT").DefaultView.Sort = " qud_itmno desc"
                sort_seq = False
            End If
        End If
    End Sub

    Private Sub dgTempQ_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTempQ.SelectionChanged
        If rs_TempQ.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        If dgTempQ.SelectedRows.Count > 0 Then
            Dim index As Integer

            index = dgTempQ.CurrentRow.Index

            If Microsoft.VisualBasic.Left(rs_TempQ.Tables("RESULT").DefaultView(index)("qud_itmno"), 5).ToString = "ASST-" Then
                btcPDA.TabPages(1).Enabled = False
                btcPDA.TabPages(1).Enabled = True

                Dim strCus1No As String
                Dim strCus2No As String

                rs_TempAss.Tables.Clear()

                If Trim(cboPriCust.Text) = "" Then
                    strCus1No = ""
                Else
                    strCus1No = Trim(Split(cboPriCust.Text, "-")(0))
                End If

                strCus2No = ""

                'S = "㊣PDA_Quot_Ass※S※※" & strCus1No & "※" & strCus2No & "※" & rs_TempQ("qud_tmpqutno").Value & "※" & rs_TempQ("qud_itmno").Value & "※1"
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gspStr = "sp_select_PDA_Quot_Ass '','','" & _
                                                        strCus1No & "','" & _
                                                        strCus2No & "','" & _
                                                        rs_TempQ.Tables("RESULT").DefaultView(index)("qud_tmpqutno") & "','" & _
                                                        rs_TempQ.Tables("RESULT").DefaultView(index)("qud_itmno") & "','1'"
                rtnLong = execute_SQLStatement(gspStr, rs_TempAss, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading dgTempQ_SelectionChanged sp_select_PDA_Quot_Ass :" & rtnStr)
                    Exit Sub
                End If

                For index1 As Integer = 0 To rs_TempAss.Tables("RESULT").Columns.Count - 1
                    rs_TempAss.Tables("RESULT").Columns(index1).ReadOnly = False
                Next

                dgTempAss.DataSource = rs_TempAss.Tables("RESULT").DefaultView
                Call DisplayTempAss()
            Else
                btcPDA.TabPages(1).Enabled = True
                btcPDA.TabPages(1).Enabled = False
            End If
        End If
    End Sub

    Private Sub DisplayTempAss()
        Dim intCol As Integer

        intCol = 0

        With dgTempAss
            .Columns(intCol).HeaderText = "Del"
            '.Columns(intCol).Button = True
            .Columns(intCol).Width = 50
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Item No."
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Ven. Itm."
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Col. Cde."
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "UM"
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Inr."
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Mtr."
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Vendor"
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Als. Itm. No."
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Als. Col. Cde."
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            Dim i As Integer

            For i = intCol To rs_TempAss.Tables("RESULT").Columns.Count - 1
                .Columns(i).Width = 0
                .Columns(i).ReadOnly = True
                .Columns(i).Visible = False
            Next

            'Dim iCol As Integer

            'For iCol = 1 To rs_TempAss.Tables("RESULT").Columns.Count - 1
            '    .Columns(iCol).ReadOnly = False
            'Next
        End With
    End Sub

    Private Sub txtDateFrom_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDateFrom.KeyUp
        txtDateTo.Text = txtDateFrom.Text
    End Sub

    Private Sub Write_Ass_Log(ByVal index As Integer)
        Dim rs As New DataSet

        'S = "㊣QUXERPDA※A※" & rs_Quot("qud_cus1no") & "※" & rs_Quot("qud_cus2no") & "※" & rs_Quot("qud_cus2na") & "※" & rs_Quot("qud_seq") & "※" & _
        '                        rs_Quot("qud_itmno") & "※" & "" & "※" & rs_Quot("qud_del") & "※" & rs_Quot("qud_currel") & "※" & _
        '                        rs_Quot("qud_colcde") & "※" & rs_Quot("qud_pckseq") & "※" & rs_Quot("qud_inrqty") & "※" & rs_Quot("qud_mtrqty") & "※" & _
        '                        rs_Quot("qud_cft") & "※" & rs_Quot("qud_moq") & "※" & rs_Quot("qud_moa") & "※" & rs_Quot("qud_untcde") & "※" & _
        '                        rs_Quot("qud_smpqty") & "※" & rs_Quot("qud_disc") & "※" & rs_Quot("qud_curcde") & "※" & rs_Quot("qud_cu1pri") & "※" & _
        '                        rs_Quot("qud_cu2pri") & "※" & rs_Quot("qud_note") & "※" & rs_Quot("qud_modify") & "※" & rs_Quot("qud_prcsec") & "※" & _
        '                        rs_Quot("qud_grsmgn") & "※" & 0 & "※" & rs_Quot("qud_smpunt") & "※" & rs_Quot("qud_venitm") & "※" & _
        '                        rs_Quot("qud_aliitm") & "※" & rs_Quot("qud_alsitmno") & "※" & rs_Quot("qud_alscolcde") & "※" & rs_Quot("qud_ventyp") & "※" & rs_Quot("qud_cat") & "※" & ErrMsg & "※" & rs_Quot("qud_creusr") & "※" & _
        '                        Format(rs_Quot("qud_credat"), "yyyy-MM-dd HH:mm:ss") & "※" & Me.Name
        'rs = objBSGate.Modify(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_insert_QUXERPDA '" & gsCompany1 & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus2na") & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_seq")) & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "','','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_del") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_currel") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_colcde") & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_pckseq")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_inrqty")) & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_mtrqty")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_cft")) & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_moq")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_moa")) & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_untcde") & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_smpqty")) & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_disc")) & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_curcde") & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_cu1pri")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_cu2pri")) & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_note") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_modify") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_prcsec") & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_grsmgn")) & "','0','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_smpunt") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_venitm") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_aliitm") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_alsitmno") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_alscolcde") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_ventyp") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cat") & "','" & ErrMsg & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_creusr") & "','" & Format(rs_Quot.Tables("RESULT").Rows(index)("qud_credat"), "yyyy-MM-dd HH:mm:ss") & "','" & _
                                            Me.Name & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TempAss, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Write_Ass_Log sp_insert_QUXERPDA :" & rtnStr)
        End If
    End Sub

    Private Function setHold(ByVal strQutNo As String) As Integer
        Dim rsSetH As New DataSet

        'strSetH = "㊣QUM00003_Set_Hold※U※" & strQutNo
        'rsSetH() = objBSGate.Enquire(gsConnStr, "sp_general", strSetH)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_update_QUM00003_Set_Hold '','" & strQutNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rsSetH, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading setHold sp_update_QUM00003_Set_Hold :" & rtnStr)
            setHold = -1
            Exit Function
        Else
            setHold = 1
            Exit Function
        End If
    End Function

    Private Sub txtTmpQutNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTmpQutNo.KeyPress
        cboPriCust.Text = ""
        cboSecCust.Text = ""
        txtDateFrom.Text = "  /  /    "
        txtDateTo.Text = "  /  /    "

        If e.KeyChar = Chr(13) Then
            Call btnLoadClick()
        End If
    End Sub

    Private Sub Detailvalid(ByVal index As Integer)
        Dim rs As New DataSet

        '******************************** Check Detail valid ******************
        DtlValid = False
        '*************************************** Check  Quot Company  ********
        If rs_Quot.Tables("RESULT").Rows(index)("qud_cocde").ToString = "" Then
            ErrMsg = cERRMSG_01
            Call save_invalid(ErrMsg, index)

            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
            rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
            Exit Sub
        End If

        '*************************************** Check IM ********************
        'S = "㊣IMBASINF※S※" & rs_Quot("qud_itmno")
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_IMBASINF '','" & rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Detailvalid sp_select_IMBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count = 0 Then
            'S = "㊣IMBASINFH※S※" & rs_Quot("qud_itmno")
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gspStr = "sp_select_IMBASINFH '','" & rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading Detailvalid sp_select_IMBASINFH :" & rtnStr)
                Exit Sub
            End If

            If rs.Tables("RESULT").Rows.Count = 0 Then
                ErrMsg = cERRMSG_02
                Call save_invalid(ErrMsg, index)
            Else
                ErrMsg = cERRMSG_03
                Call save_invalid(ErrMsg, index)
            End If

            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
            rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
            Exit Sub
        Else
            Select Case Microsoft.VisualBasic.Left(rs.Tables("RESULT").Rows(0)("ibi_itmsts").ToString, 3)
                Case Is = "HLD"
                    ErrMsg = cERRMSG_04
                    Call save_invalid(ErrMsg, index)

                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                    Exit Sub
                Case Is = "CLO"
                    ErrMsg = cERRMSG_05
                    Call save_invalid(ErrMsg, index)

                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                    Exit Sub
                Case Is = "DIS"
                    ErrMsg = cERRMSG_06
                    Call save_invalid(ErrMsg, index)

                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                    Exit Sub
                Case Is = "INA"
                    ErrMsg = cERRMSG_07
                    Call save_invalid(ErrMsg, index)

                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                    Exit Sub
                Case Is = "TBC"
                    ErrMsg = cERRMSG_08
                    Call save_invalid(ErrMsg, index)

                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                    Exit Sub

                    '*** Set del to "O" to indicate it is an old item and set the Quotation to Status "H"
                Case Is = "OLD"
                    ErrMsg = cERRMSG_09
                    Call save_invalid(ErrMsg, index)

                    rs_Quot.Tables("RESULT").Columns("qud_note").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_note") = ErrMsg
                    rs_Quot.Tables("RESULT").Columns("qud_note").ReadOnly = True

                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "O"
                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
            End Select
        End If

        '-----------------------Check BP difference--------------------------------
        'S = "㊣IM_BasPrc_QU※S※" & rs_Quot("qud_curcde") & "※" & _
        '                             rs_Quot("qud_itmno") & "※" & _
        '                             rs_Quot("qud_untcde") & "※" & _
        '                             rs_Quot("qud_mtrqty") & "※" & _
        '                             rs_Quot("qud_inrqty") & "※" & _
        '                             rs_Quot("qud_basprc") & "※" & _
        '                             rs_Quot("qud_imu_cus1no") & "※" & _
        '                             rs_Quot("qud_imu_cus2no") & "※" & _
        '                             rs_Quot("qud_imu_hkprctrm") & "※" & _
        '                             rs_Quot("qud_imu_ftyprctrm") & "※" & _
        '                             rs_Quot("qud_imu_trantrm") & "※" & _
        '                             rs_Quot("qud_imu_effdat") & "※" & _
        '                             rs_Quot("qud_imu_expdat")
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_IM_BasPrc_QU '','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_curcde") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_untcde") & "','" & _
                                                Val(rs_Quot.Tables("RESULT").Rows(index)("qud_mtrqty")) & "','" & _
                                                Val(rs_Quot.Tables("RESULT").Rows(index)("qud_inrqty")) & "','" & _
                                                Val(rs_Quot.Tables("RESULT").Rows(index)("qud_basprc")) & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_imu_cus1no") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_imu_cus2no") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_imu_hkprctrm") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_imu_ftyprctrm") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_imu_trantrm") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_imu_effdat") & "','" & _
                                                rs_Quot.Tables("RESULT").Rows(index)("qud_imu_expdat") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Detailvalid sp_select_IM_BasPrc_QU :" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            If rs.Tables("RESULT").Rows(0)("qud_pdabpdiff").ToString = "Y" Then
                ErrMsg = cERRMSG_10
                Call save_invalid(ErrMsg, index)

                rs_Quot.Tables("RESULT").Columns("qud_note").ReadOnly = False
                rs_Quot.Tables("RESULT").Rows(index)("qud_note") = ErrMsg
                rs_Quot.Tables("RESULT").Columns("qud_note").ReadOnly = True

                rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "O"
                rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
            End If
        End If

        '*************************************Check Customer and Pri/Sec Relation *************
        'S = "㊣CUBASINF※S※" & rs_Quot("qud_cus1no")
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUBASINF '','" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Detailvalid sp_select_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count = 0 Then
            ErrMsg = cERRMSG_11
            Call save_invalid(ErrMsg, index)

            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
            rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
            Exit Sub
        Else
            If IsDBNull(rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no")) = False Then
                If rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no").ToString <> "" Then
                    'S = "㊣CUSUBCUS※S※" & rs_Quot("qud_cus1no") & "※" & "P"
                    'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                    Cursor = Cursors.WaitCursor

                    gspStr = "sp_select_CUSUBCUS '','" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "','P'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    gspStr = ""

                    Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading Detailvalid sp_select_CUSUBCUS :" & rtnStr)
                        Exit Sub
                    End If

                    If rs.Tables("RESULT").Rows.Count = 0 Then
                        ErrMsg = cERRMSG_12
                        Call save_invalid(ErrMsg, index)

                        rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                        rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                        rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                        Exit Sub
                    Else
                        Dim seccnt As Integer = 0

                        For index1 As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
                            If rs.Tables("RESULT").Rows(index1)("csc_seccus") = rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") Then
                                seccnt = seccnt + 1
                                Exit For
                            End If
                        Next

                        If seccnt = 0 Then
                            ErrMsg = cERRMSG_12
                            Call save_invalid(ErrMsg, index)

                            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                            rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If

        '************************************* Check Item can be Quot by Company *********
        'S = "㊣IMXCHK※S※" & rs_Quot("qud_cus1no") & "※" & "X" & "※" & rs_Quot("qud_itmno")
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_IMXCHK '" & gsCompany1 & "','" & _
                                        rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "','X','" & _
                                        rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Detailvalid sp_select_IMXCHK :" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count = 0 Then
            ErrMsg = cERRMSG_13
            Call save_invalid(ErrMsg, index)

            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
            rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
            Exit Sub
        End If

        '************************************Check Currency Code **************************
        'S = "㊣CUPRCINF※S※" & rs_Quot("qud_cus1no")
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUPRCINF '" & gsCompany1 & "','" & _
                                        rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Detailvalid sp_select_CUPRCINF :" & rtnStr)
            Exit Sub
        End If

        Dim rs1 As New DataSet

        If rs.Tables("RESULT").Rows.Count = 0 Then
            ErrMsg = cERRMSG_14
            Call save_invalid(ErrMsg, index)

            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
            rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
            rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
            Exit Sub
        Else
            If rs.Tables("RESULT").Rows(0)("cpi_curcde") <> rs_Quot.Tables("RESULT").Rows(index)("qud_curcde") Then
                'S = "㊣SYSETINF※S※" & "HKD" & "※ 06"
                'rs1 = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gspStr = "sp_select_SYSETINF '" & gsCompany1 & "','HKD','06'"
                rtnLong = execute_SQLStatement(gspStr, rs1, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading Detailvalid sp_select_SYSETINF :" & rtnStr)
                    Exit Sub
                End If

                If rs1.Tables("RESULT").Rows.Count <> 0 Then
                    If rs.Tables("RESULT").Rows(0)("cpi_curcde") = "HKD" Then
                        Call Update_Price(rs1.Tables("RESULT").Rows(0)("ysi_buyrat"), "/")
                    Else
                        Call Update_Price(rs1.Tables("RESULT").Rows(0)("ysi_selrat"), "*")
                    End If

                    rs_Quot.Tables("RESULT").Rows(index)("qud_curcde") = rs.Tables("RESULT").Rows(0)("cpi_curcde")
                Else
                    ErrMsg = cERRMSG_15
                    Call save_invalid(ErrMsg, index)

                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = False
                    rs_Quot.Tables("RESULT").Rows(index)("qud_del") = "Y"
                    rs_Quot.Tables("RESULT").Columns("qud_del").ReadOnly = True
                    Exit Sub
                End If
            End If
        End If

        DtlValid = True

        ErrMsg = ""
        Call save_invalid(ErrMsg, index)
    End Sub

    Private Sub save_invalid(ByVal ErrMsg As String, ByVal index As Integer)
        Dim rs As New DataSet

        'S = "㊣QUXERPDA※A※" & rs_Quot("qud_cus1no") & "※" & rs_Quot("qud_cus2no") & "※" & rs_Quot("qud_cus2na") & "※" & rs_Quot("qud_seq") & "※" & _
        '                        rs_Quot("qud_itmno") & "※" & rs_Quot("qud_img") & "※" & rs_Quot("qud_del") & "※" & rs_Quot("qud_currel") & "※" & _
        '                        rs_Quot("qud_colcde") & "※" & rs_Quot("qud_pckseq") & "※" & rs_Quot("qud_inrqty") & "※" & rs_Quot("qud_mtrqty") & "※" & _
        '                        rs_Quot("qud_cft") & "※" & rs_Quot("qud_moq") & "※" & rs_Quot("qud_moa") & "※" & rs_Quot("qud_untcde") & "※" & _
        '                        rs_Quot("qud_smpqty") & "※" & rs_Quot("qud_disc") & "※" & rs_Quot("qud_curcde") & "※" & rs_Quot("qud_cu1pri") & "※" & _
        '                        rs_Quot("qud_cu2pri") & "※" & rs_Quot("qud_note") & "※" & rs_Quot("qud_modify") & "※" & rs_Quot("qud_prcsec") & "※" & _
        '                        rs_Quot("qud_grsmgn") & "※" & rs_Quot("qud_basprc") & "※" & rs_Quot("qud_smpunt") & "※" & rs_Quot("qud_venitm") & "※" & _
        '                        rs_Quot("qud_aliitm") & "※" & rs_Quot("qud_alsitmno") & "※" & rs_Quot("qud_alscolcde") & "※" & rs_Quot("qud_ventyp") & "※" & rs_Quot("qud_cat") & "※" & ErrMsg & "※" & rs_Quot("qud_creusr") & "※" & _
        '                        Format(rs_Quot("qud_credat"), "yyyy-MM-dd HH:mm:ss") & "※" & Me.Name
        'rs = objBSGate.Modify(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_insert_QUXERPDA '','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus1no") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_cus2no") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cus2na") & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_seq")) & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_itmno") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_img") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_del") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_currel") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_colcde") & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_pckseq")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_inrqty")) & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_mtrqty")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_cft")) & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_moq")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_moa")) & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_untcde") & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_smpqty")) & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_disc")) & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_curcde") & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_cu1pri")) & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_cu2pri")) & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_note") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_modify") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_prcsec") & "','" & _
                                            Val(rs_Quot.Tables("RESULT").Rows(index)("qud_grsmgn")) & "','" & Val(rs_Quot.Tables("RESULT").Rows(index)("qud_basprc")) & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_smpunt") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_venitm") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_aliitm") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_alsitmno") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_alscolcde") & "','" & rs_Quot.Tables("RESULT").Rows(index)("qud_ventyp") & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_cat") & "','" & ErrMsg & "','" & _
                                            rs_Quot.Tables("RESULT").Rows(index)("qud_creusr") & "','" & Format(rs_Quot.Tables("RESULT").Rows(index)("qud_credat"), "yyyy-MM-dd HH:mm:ss") & "','" & _
                                            Me.Name & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TempAss, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading save_invalid sp_insert_QUXERPDA :" & rtnStr)
        End If

        If ErrMsg <> "" Then
            ErrCnt = ErrCnt + 1
        End If
    End Sub

    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

        If Value = 0 Then S = "0"
        If Value = 1 Then S = "0.0"
        If Value = 2 Then S = "0.00"
        If Value = 3 Then S = "0.000"
        If Value = 4 Then S = "0.0000"
        If Value = 5 Then S = "0.00000"
        If Value = 6 Then S = "0.000000"
        If Value = 7 Then S = "0.0000000"
        If Value = 8 Then S = "0.00000000"
        If Value = 9 Then S = "0.000000000"
        If Value = 10 Then S = "0.0000000000"

        round = CDbl(Format(a, S))
    End Function

    Private Function roundup(ByVal Value As Double) As Double
        Dim tmp As String

        Value = round(Value, 5)
        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If Len(Microsoft.VisualBasic.Right(tmp, Len(tmp) - InStr(tmp, "."))) > 4 Then
                roundup = CDec(tmp) + 0.0001
                roundup = CDec(Microsoft.VisualBasic.Left(CStr(roundup), InStr(roundup, ".") + 4))
                Exit Function
            Else
                roundup = CDec(tmp)
                Exit Function
            End If
        Else
            roundup = CDec(tmp)
            Exit Function
        End If
    End Function

    Private Function isNewItemFormat(ByVal strItem As String, Optional ByVal bolShow As Boolean = False) As Boolean
        If gsCompanyGroup = "MSG" Then
            isNewItemFormat = False
        Else
            isNewItemFormat = False
            strItem = UCase(strItem)

            If bolShow = True Then
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function

                If UCase(Mid(strItem, 7, 2)) = "AS" And _
                    Microsoft.VisualBasic.Right(strItem, 2) <> "00" And _
                    UCase(Mid(strItem, 3, 1)) <> "C" And _
                    UCase(Mid(strItem, 3, 1)) <> "D" Then Exit Function

                If UCase(Mid(strItem, 7, 2)) <> "AS" Then
                    If UCase(Mid(strItem, 3, 1)) = "U" Then
                        Exit Function
                    End If

                    If UCase(Mid(strItem, 3, 1)) = "A" Then

                    End If

                    '*** Plant CDTXV
                    If UCase(Mid(strItem, 3, 1)) = "C" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "D" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "T" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "V" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "X" Then

                    End If

                    If UCase(Mid(strItem, 3, 1)) = "B" Then
                        If (Mid(strItem, 4, 1) >= "0" And Mid(strItem, 4, 1) <= "9") Then
                            If Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9" Then
                                If (Mid(strItem, 6, 1) >= "0" And Mid(strItem, 6, 1) <= "9") Then
                                    isNewItemFormat = True
                                    Exit Function
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End If

                        If Mid(strItem, 4, 1) >= "A" And Mid(strItem, 4, 1) <= "Z" Then
                            If Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9" Then
                                If Mid(strItem, 6, 1) >= "0" And Mid(strItem, 6, 1) <= "9" Then
                                    isNewItemFormat = True
                                    Exit Function
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End If
                    End If
                Else
                    Exit Function
                End If
            Else
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function
            End If
            isNewItemFormat = True
        End If
    End Function




End Class