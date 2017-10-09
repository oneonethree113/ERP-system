Imports Microsoft.Office.Interop
Imports System.IO

Imports System.Data
Imports System.Data.SqlClient

Public Class MPR00003

    Dim rs_MPR00003 As New DataSet  'recordset for resulting data

    Const optPck As String = "1"
    Const optInv As String = "2"
    Const optCust As String = "3"
    Const OPTRPT As String = "4"


    Dim strBillTo As String     '賬號
    Dim strCar As String        '運輸工具
    Dim strTO As String
    Dim strFm As String
    Dim strGRNNo As String
    Dim strCC As String
    Dim strDlvDat As String
    Dim strCTRNO As String
    Dim ynPrtGrp As String

    Dim sNumberText() As String


    Dim rs_MPR00003_recvdept As New DataSet

    Const xlContinuous = 1
    Const xlDiagonalDown = 5
    Const xlDiagonalUp = 6
    Const xlEdgeLeft = 7
    Const xlEdgeTop = 8
    Const xlEdgeBottom = 9
    Const xlEdgeRight = 10
    Const xlInsideVertical = 11
    Const xlInsideHorizontal = 12
    Const xlHairLine = 1
    Const xlSolid = 1
    Const xlThin = 2
    Const xlAutomatic = -4105
    Const xlCenter = -4108
    Const xlNone = -4142
    Const xlDown = -4121
    Const xlUp = -4162
    Const xlMedium = -4138
    Const xlLeft = -4131
    Const xlRight = -4152
    Const xlToLeft = -4159
    Const xlToRight = -4161
    Const xlShiftToLeft = -4159
    Const xTop = -4160
    Const xlLastCell = 11
    Const xlAscending = 1
    Const xlGuess = 0
    Const xlTopToBottom = 1
    Const xlSortNormal = 0

    Enum XLS_enu
        DUMMY_xls   '0
        A_xls       '1
        B_xls       '2
        C_xls       '3
        D_xls       '4
        E_xls       '5
        F_xls       '6
        G_xls       '7
        h_xls       '8
        I_xls       '9
        J_xls       '10
        K_xls       '11
        L_xls       '12
        M_xls       '13
        N_xls       '14
        O_xls       '15
        P_xls       '16
        Q_xls       '17
        R_xls       '18
        S_xls       '19
        T_xls       '20
        U_xls       '21
        V_xls       '22
        W_xls       '23
        X_xls       '24
        Y_xls       '25
        Z_xls       '26
        AA_xls
        AB_xls
    End Enum


    Enum MPR03_enu
        ShpPlc_enum
        Car_enum
        GrnNo_enum
        Seq_enum
        itmNo_enum
        ItmNam_enum
        shpqty_enum
        ShpUM_enum
        NW_enum
        NW_UM_enum
        PckWgt_enum
        PckUM_enum
        Grp_enum
        CtnTtl_enum
        CtnUM_enum
        RevDept_enum
        CtnFm_enum
        CtnTo_enum
        PONo_enum
        To_enum
        Fm_enum
        BillTo_enum
        CC_enum
        Grh_DlvDat_enum
        CustCat_enum
        dummy01_enum
        dummy02_enum
        DtlRmk_enum
        ' Added by Mark Lau 20090910
        CustUM_enum
        InvUM_enum
        SAP_RecvDept
        CTRNO
    End Enum



    Private Sub cboReport_Click()
        If Me.cboReport.Text <> "" Then
            If Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optInv Then
                Me.optShow.Enabled = True
                Me.optHidden.Enabled = True
                Me.cboDP.Enabled = True
                Frame2.Enabled = True
                Frame3.Enabled = True
                Me.cboInvUm.Enabled = True
                Frame4.Enabled = True
            ElseIf Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optCust Then
                Me.optShow.Enabled = True
                Me.optHidden.Enabled = True
                Me.cboDP.Enabled = True
                Frame2.Enabled = True
                Frame3.Enabled = True
                Me.cboInvUm.Enabled = False
                Frame4.Enabled = False
            Else
                Me.optShow.Enabled = False
                Me.optHidden.Enabled = False
                Me.cboDP.Enabled = False
                Frame2.Enabled = False
                Frame3.Enabled = False
                Me.cboInvUm.Enabled = False
                Frame4.Enabled = False
            End If
        End If

        ' Added by Mark Lau 20090617
        If Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = OPTRPT Then
            optFormat0.Visible = True
            optFormat1.Visible = True
            optFormat0.Checked = True
        Else
            optFormat0.Visible = False
            optFormat1.Visible = False
        End If

        ' Frankie Cheung 20091016
        If Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optPck Or Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optInv Then
            chkPrtGrp.Visible = True
        Else
            chkPrtGrp.Visible = False
        End If

    End Sub

    Private Sub cmdShow_Click()

        Dim AscDesc As String

        Dim S As String
        Dim S2 As String
        Dim rs As DataSet
        Dim ReportName(0) As String
        Dim ReportRS(0) As DataSet

        Dim GRNFM As String
        Dim GRNTO As String
        Dim strRpt As String

        Dim strAmount As String
        Dim strCurr As String
        Dim dblAmount As Double

        GRNFM = UCase(Trim(Me.txtGrnNoFm.Text))
        GRNTO = UCase(Trim(Me.txtGrnNoTo.Text))

        Me.txtGrnNoFm.Text = GRNFM
        Me.txtGrnNoTo.Text = GRNTO

        If Me.txtGrnNoFm.Text = "" And Me.txtGrnNoTo.Text <> "" Then
            MsgBox("Please Input GRN No From!")
            Me.txtGrnNoFm.Focus()
            Exit Sub
        End If

        If Me.txtGrnNoTo.Text = "" And Me.txtGrnNoFm.Text <> "" Then
            MsgBox("Please Input GRN No To!")
            Me.txtGrnNoTo.Focus()
            Exit Sub
        End If

        If txtGrnNoFm.Text > txtGrnNoTo.Text Then
            MsgBox("GRN No: To < From!")
            Me.txtGrnNoTo.Focus()
            Exit Sub
        End If

        If Me.cboReport.Text = "" Then
            MsgBox("Please select report type!")
            Me.cboReport.Focus()
            Exit Sub
        End If

        strRpt = Microsoft.VisualBasic.Left(Me.cboReport.Text, 1)

        If strRpt = OPTRPT Then
            If txtGrnNoFm.Text <> txtGrnNoTo.Text Then
                MsgBox(Me.cboReport.Text & vbCrLf & "Each time for one GRN record only!")
                Me.txtGrnNoFm.Focus()
                Exit Sub
            End If
        End If

        Dim intDP As Integer
        Dim hidden As Integer
        Dim invum As Integer
        intDP = CInt(Me.cboDP.Text)
        hidden = IIf(Me.optShow.Checked = True, 1, 0)
        invum = cboInvUm.SelectedIndex

        'Frankie Cheung 20091028 Add Print Group
        If chkPrtGrp.Checked = 0 Then
            ynPrtGrp = "N"
        Else
            ynPrtGrp = "Y"
        End If

        If strRpt = optPck Then
            S = "sp_list_MPR00003_pck '','" & GRNFM & "','" & GRNTO & "','" & intDP & "','" & hidden & "','" & ynPrtGrp & "','" & gsUsrID & "'"
        ElseIf strRpt = optInv Then
            S = "sp_list_MPR00003_inv '','" & GRNFM & "','" & GRNTO & "','" & intDP & "','" & hidden & "','" & invum & "','" & ynPrtGrp & "','" & gsUsrID & "'"
        ElseIf strRpt = optCust Then
            S = "sp_list_MPR00003_cust '','" & GRNFM & "','" & GRNTO & "','" & intDP & "','" & hidden & "','" & gsUsrID & "'"
        ElseIf strRpt = OPTRPT Then
            S = "sp_list_MPR00003_rpt '','" & GRNFM & "','" & GRNTO & "','" & intDP & "','" & hidden & "','" & gsUsrID & "'"
            S2 = "sp_list_MPR00003_rpt_recvdept '','" & GRNFM & "','" & GRNTO & "','" & intDP & "','" & hidden & "','" & gsUsrID & "'"
        Else
            MsgBox("Invalid report type!")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        gsCompany = "ALL"

        Call Update_gs_Value(gsCompany)

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_MPR00003, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        End If
        With rs_MPR00003
            For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                .Tables("RESULT").Columns(i2).ReadOnly = False
            Next i2
        End With


        If strRpt = OPTRPT Then
            gspStr = S2
            rtnLong = execute_SQLStatement(gspStr, rs_MPR00003_recvdept, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp  :" & rtnStr)
                Exit Sub
            End If
        End If

        Cursor = Cursors.Default


        If rs_MPR00003.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Record not found!")
            Exit Sub
        Else

            If strRpt = optInv Then
                With rs_MPR00003
                    If .Tables("RESULT").Rows.Count > 0 Then


                        strCurr = Trim(IIf(IsDBNull(.Tables("RESULT").Rows(0)("strAmt")), "", .Tables("RESULT").Rows(0)("strCurr")))
                        strAmount = Trim(IIf(IsDBNull(.Tables("RESULT").Rows(0)("strAmt")), "", .Tables("RESULT").Rows(0)("strAmt")))
                        If InStr(strAmount, ".") > 0 Then
                            strAmount = Format(CDbl(strAmount), "#########.##")

                            Do While (Microsoft.VisualBasic.Right(strAmount, 1) = "0")
                                strAmount = Microsoft.VisualBasic.Left(strAmount, Len(strAmount) - 1)
                            Loop
                        End If
                        If Len(strAmount) > 0 Then
                            strAmount = UCase(NumberAsText(strAmount, ""))
                            If Not InStr(strAmount, "POINT") > 0 Then
                                strAmount = strAmount & " ONLY"
                            End If
                        End If


                        For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                            .Tables("RESULT").Rows(index)("strAmt") = strCurr & " " & strAmount

                        Next

                    End If

                End With
            End If
            'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            If strRpt = optPck Then
                Dim objRpt As New MPR00003_pck
                objRpt.SetDataSource(rs_MPR00003.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

            ElseIf strRpt = optInv Then
                Dim objRpt As New MPR00003_inv
                objRpt.SetDataSource(rs_MPR00003.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

            ElseIf strRpt = optCust Then
                Dim objRpt As New MPR00003_cust
                objRpt.SetDataSource(rs_MPR00003.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

            ElseIf strRpt = OPTRPT Then


                ' Added by Mark Lau 20090616
                If optFormat0.Checked = True Then

                    If rs_MPR00003_recvdept.Tables("RESULT").Rows.Count > 0 Then

                        If DirExists("C:\出倉報表\") = False Then
                            MkDir("C:\出倉報表\")
                        End If

                        For index As Integer = 0 To rs_MPR00003_recvdept.Tables("RESULT").Rows.Count - 1

                            rs_MPR00003.Tables("result").DefaultView.RowFilter = " grd_grnno = '" & rs_MPR00003_recvdept.Tables("RESULT").Rows(index)("grd_grnno") & "' " & _
                                                    " and RecvDept = '" & rs_MPR00003_recvdept.Tables("RESULT").Rows(index)("RecvDept") & "' "

                            Call ExportToExcel_Rpt(rs_MPR00003_recvdept.Tables("RESULT").Rows(index)("grd_grnno") & _
                                                    IIf(rs_MPR00003_recvdept.Tables("RESULT").Rows(index)("RecvDept") = "", "", "_" & rs_MPR00003_recvdept.Tables("RESULT").Rows(index)("RecvDept")) & ".xls")

                            rs_MPR00003.Tables("result").DefaultView.RowFilter = ""

                        Next

                        MsgBox("Files are exported to C:\出倉報表")
                    End If


                ElseIf optFormat1.Checked = True Then
                    Dim objRpt As New MPR00003_rpt
                    objRpt.SetDataSource(rs_MPR00003.Tables("RESULT"))

                    Dim frmReportView As New frmReport
                    frmReportView.CrystalReportViewer.ReportSource = objRpt
                    frmReportView.Show()

                End If

                rs_MPR00003 = Nothing
                rs_MPR00003_recvdept = Nothing
            End If

        End If

    End Sub

    Private Sub Form_Load()

        Cursor = Cursors.WaitCursor

        txtGrnNoFm.MaxLength = 20
        txtGrnNoTo.MaxLength = 20

        Me.cboDP.Items.Clear()
        Me.cboDP.Items.Add("0")
        Me.cboDP.Items.Add("1")
        Me.cboDP.Items.Add("2")
        Me.cboDP.SelectedIndex = 0

        Me.cboInvUm.Items.Clear()
        Me.cboInvUm.Items.Add("Cust Qty")
        Me.cboInvUm.Items.Add("N.W.")
        Me.cboInvUm.SelectedIndex = 1


        Me.cboReport.Items.Clear()
        Me.cboReport.Items.Add(optPck & " - Packing List")
        Me.cboReport.Items.Add(optInv & " - Invoice")
        Me.cboReport.Items.Add(optCust & " - 報關清單")
        Me.cboReport.Items.Add(OPTRPT & " - 出倉報表")
        Me.cboReport.SelectedIndex = 0

        Me.KeyPreview = True
        Call Formstartup(Me.Name)   'Set the form Sartup position

        'Lester Wu 2006-03-20
        Call BuildArray()

        Cursor = Cursors.Default

    End Sub

    Private Sub optFormat_Click(ByVal Index As Integer)

    End Sub

    Private Sub optHidden_Click()

    End Sub

    Private Sub txtGrnNoFm_Change()

    End Sub

    Private Sub txtGrnNoFm_GotFocus()
    End Sub

    Private Sub txtGrnNoTo_GotFocus()
    End Sub

    Private Sub ExportToExcel_Rpt(ByVal strFileName As String)

        On Error GoTo Err_Handler

        Cursor = Cursors.WaitCursor ' Change mouse pointer to hourglass.
        Dim xlApp As Excel.Application
        Dim xlWb As Excel.Workbook
        Dim xlWs As Excel.Worksheet

        Dim recArray As Object
        Dim lngRecCount As Long

        Dim fldCount As Integer
        Dim recCount As Long

        Dim iCol As Long
        Dim iRow As Long

        Dim rowHeader As Long
        Dim rowContent As Long

        Dim GRN_LastRow As Long
        Dim Group_LastRow As Long
        Dim CTN_LastRow As Long
        '----------------------------------
        Dim GrnNo As String
        Dim GrnSeq As Long
        Dim tmpGrnNo As String
        Dim tmpGrnSeq As Long

        Dim ctnFm As String
        Dim ctnTo As String
        Dim tmpCtnFm As String
        Dim tmpCtnTo As String

        Dim strGroup As String
        Dim tmpGroup As String

        Dim dblPckWgt As Double
        Dim dblTtlPckWgt As Double
        '----------------------------------

        Dim strUnit As String
        Dim strUM As String
        Dim strCTN As String
        rowHeader = 1
        rowContent = 10
        '---------------------------------------------------------------------------------
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        lngRecCount = rs_MPR00003.Tables("RESULT").Rows.Count + rowContent
        If lngRecCount > 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '----------------------------------------------------------------------------------


        xlApp = CreateObject("Excel.Application")
        xlWb = xlApp.Workbooks.Add
        xlWs = xlWb.Worksheets(1)

        xlApp.Visible = True
        xlApp.UserControl = True


        recCount = rs_MPR00003.Tables("RESULT").Rows.Count
        strBillTo = ""
        strCar = ""
        strTO = ""
        strFm = ""
        strGRNNo = ""

        With xlWs
            If rs_MPR00003.Tables("RESULT").Rows.Count > 0 Then

                iRow = rowContent
                strGroup = ""
                tmpGroup = ""

                GrnNo = ""
                tmpGrnNo = ""
                GrnSeq = 0
                tmpGrnSeq = 0

                strBillTo = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.BillTo_enum)
                strCar = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.Car_enum)
                strTO = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.To_enum)
                strFm = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.Fm_enum)
                strGRNNo = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.GrnNo_enum)
                strCC = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.CC_enum)
                strDlvDat = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.Grh_DlvDat_enum)
                strCTRNO = rs_MPR00003.Tables("RESULT").Rows(0)(MPR03_enu.CTRNO)
                Call setwidth(xlWs)
                Call showHeader(xlWs, rowHeader - 1)


                For index As Integer = 0 To rs_MPR00003.Tables("RESULT").Rows.Count - 1
                    tmpGrnNo = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.GrnNo_enum)
                    tmpGrnSeq = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.Seq_enum)
                    tmpCtnFm = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnFm_enum)
                    tmpCtnTo = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTo_enum)
                    tmpGroup = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.Grp_enum)

                    dblPckWgt = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.PckWgt_enum)

                    If GrnNo <> tmpGrnNo Then
                        If GrnNo <> "" Then
                            'Show Footer
                            .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow, XLS_enu.L_xls)).Borders(xlInsideHorizontal).LineStyle = xlContinuous
                            .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow, XLS_enu.L_xls)).Borders(xlInsideHorizontal).Weight = xlThin
                            .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow - 1, XLS_enu.L_xls)).Borders(xlInsideVertical).LineStyle = xlContinuous
                            .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow - 1, XLS_enu.L_xls)).Borders(xlInsideVertical).Weight = xlThin
                            rowContent = rowHeader + 14
                            rowHeader = rowHeader + iRow + 4
                        End If
                        'Show header
                        '                    strBillTo = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.ShpPlc_enum)
                        '                    strCar = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.Car_enum)
                        '                    Call showHeader(xlWs, rowHeader - 1)
                        GrnNo = tmpGrnNo
                    End If

                    '物品編號
                    .Range(.Cells(iRow, XLS_enu.A_xls), .Cells(iRow, XLS_enu.A_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.itmNo_enum)

                    '物品名稱
                    .Range(.Cells(iRow, XLS_enu.B_xls), .Cells(iRow, XLS_enu.B_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.ItmNam_enum)
                    .Range(.Cells(iRow, XLS_enu.B_xls), .Cells(iRow, XLS_enu.B_xls)).WrapText = True

                    '總重量
                    .Range(.Cells(iRow, XLS_enu.C_xls), .Cells(iRow, XLS_enu.C_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.NW_enum) * rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTtl_enum)

                    '單位
                    .Range(.Cells(iRow, XLS_enu.D_xls), .Cells(iRow, XLS_enu.D_xls)).Value = "KG"

                    '==========================================================================================================
                    '++++++++++++++++++++ Check GRN No and GRN Seq +++++++++++++++++++++++++++++++++START++++++++++++++++++++++
                    If GrnNo = tmpGrnNo And GrnSeq = tmpGrnSeq Then
                        '件數 (Total Carton)
                        .Range(.Cells(GRN_LastRow, XLS_enu.G_xls), .Cells(iRow, XLS_enu.G_xls)).Merge()
                        '件數 (單位)
                        .Range(.Cells(GRN_LastRow, XLS_enu.h_xls), .Cells(iRow, XLS_enu.h_xls)).Merge()

                        '排列 (Carton Range)
                        .Range(.Cells(GRN_LastRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Merge()

                        '備注
                        '.Range(.Cells(GRN_LastRow, XLS_enu.K_xls), .Cells(iRow, XLS_enu.K_xls)).merge
                    Else
                        '件數 (Total Carton)
                        .Range(.Cells(iRow, XLS_enu.G_xls), .Cells(iRow, XLS_enu.G_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTtl_enum)
                        '件數 (單位)
                        .Range(.Cells(iRow, XLS_enu.h_xls), .Cells(iRow, XLS_enu.h_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnUM_enum)

                        '排列 (Carton Range)
                        If rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnFm_enum) <> rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTo_enum) Then
                            .Range(.Cells(iRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Value = "C/NO " & rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnFm_enum) & " - " & rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTo_enum)
                        Else
                            .Range(.Cells(iRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Value = "C/NO " & rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnFm_enum)
                        End If
                        '備注
                        '.Range(.Cells(iRow, XLS_enu.K_xls), .Cells(iRow, XLS_enu.K_xls)) = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.XXXXXXXXXXX)
                        GrnNo = tmpGrnNo
                        GrnSeq = tmpGrnSeq
                        GRN_LastRow = iRow
                    End If
                    '++++++++++++++++++++ Check GRN No and GRN Seq ++++++++++++++++++++++++++++++++++END+++++++++++++++++++++++

                    '數量   -- base on group
                    .Range(.Cells(iRow, XLS_enu.E_xls), .Cells(iRow, XLS_enu.E_xls)).Value = Format(dblPckWgt, "###,###.###0")
                    '數量 (單位)
                    .Range(.Cells(iRow, XLS_enu.F_xls), .Cells(iRow, XLS_enu.F_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.PckUM_enum)

                    '==========================================================================================================
                    '++++++++++++++++++++ Check GROUP and Calculate Total Weight++++++++++++++++++++START++++++++++++++++++++++
                    If tmpGroup <> "" And tmpGroup = strGroup Then
                        '件數 (Total Carton)
                        .Range(.Cells(GRN_LastRow, XLS_enu.G_xls), .Cells(iRow, XLS_enu.G_xls)).Merge()
                        '件數 (單位)
                        .Range(.Cells(GRN_LastRow, XLS_enu.h_xls), .Cells(iRow, XLS_enu.h_xls)).Merge()

                        '排列 (Carton Range)
                        .Range(.Cells(GRN_LastRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Merge()
                    Else
                        Group_LastRow = iRow
                        strGroup = tmpGroup
                    End If
                    '++++++++++++++++++++ Check GROUP and Calculate Total Weight++++++++++++++++++++++END++++++++++++++++++++++

                    '取貨部門
                    ' Changed by Mark Lau 20090910
                    '.Range(.Cells(iRow, XLS_enu.I_xls), .Cells(iRow, XLS_enu.I_xls)) = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.RevDept_enum)
                    .Range(.Cells(iRow, XLS_enu.I_xls), .Cells(iRow, XLS_enu.I_xls)).Value = IIf(rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.RevDept_enum) <> "", rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.RevDept_enum), rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.SAP_RecvDept))

                    If ctnFm = tmpCtnFm And ctnTo = tmpCtnTo Then
                        .Range(.Cells(CTN_LastRow, XLS_enu.G_xls), .Cells(iRow, XLS_enu.G_xls)).Value = ""
                        .Range(.Cells(CTN_LastRow, XLS_enu.h_xls), .Cells(iRow, XLS_enu.h_xls)).Value = ""
                        .Range(.Cells(CTN_LastRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Value = ""


                        .Range(.Cells(CTN_LastRow, XLS_enu.G_xls), .Cells(iRow, XLS_enu.G_xls)).Merge()
                        .Range(.Cells(CTN_LastRow, XLS_enu.h_xls), .Cells(iRow, XLS_enu.h_xls)).Merge()
                        .Range(.Cells(CTN_LastRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Merge()

                        '件數 (Total Carton)
                        .Range(.Cells(CTN_LastRow, XLS_enu.G_xls), .Cells(iRow, XLS_enu.G_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTtl_enum)
                        '件數 (單位)
                        .Range(.Cells(CTN_LastRow, XLS_enu.h_xls), .Cells(iRow, XLS_enu.h_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnUM_enum)

                        '排列 (Carton Range)
                        If rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnFm_enum) <> rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTo_enum) Then
                            .Range(.Cells(CTN_LastRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Value = "C/NO " & rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnFm_enum) & " - " & rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnTo_enum)
                        Else
                            .Range(.Cells(CTN_LastRow, XLS_enu.J_xls), .Cells(iRow, XLS_enu.J_xls)).Value = "C/NO " & rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.CtnFm_enum)
                        End If

                    Else
                        CTN_LastRow = iRow
                        ctnFm = tmpCtnFm
                        ctnTo = tmpCtnTo
                    End If

                    '訂單編號
                    .Range(.Cells(iRow, XLS_enu.L_xls), .Cells(iRow, XLS_enu.L_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.PONo_enum)

                    '備注
                    .Range(.Cells(iRow, XLS_enu.K_xls), .Cells(iRow, XLS_enu.K_xls)).Value = rs_MPR00003.Tables("RESULT").Rows(index)(MPR03_enu.DtlRmk_enum)
                    iRow = iRow + 1
                    'rs_MPR00003.MoveNext()

                Next

                If GrnNo <> "" Then
                    'Show Footer
                    .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow, XLS_enu.L_xls)).Borders(xlInsideHorizontal).LineStyle = xlContinuous
                    .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow, XLS_enu.L_xls)).Borders(xlInsideHorizontal).Weight = xlThin
                    .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow - 1, XLS_enu.L_xls)).Borders(xlInsideVertical).LineStyle = xlContinuous
                    .Range(.Cells(rowContent, XLS_enu.A_xls), .Cells(iRow - 1, XLS_enu.L_xls)).Borders(xlInsideVertical).Weight = xlThin
                    rowContent = rowHeader + 14
                    rowHeader = rowHeader + iRow + 4
                End If
            End If
        End With

        'xlApp.selection.CurrentRegion.Columns.AutoFit




        Dim lngPages As Long


        lngPages = recCount / 20 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If

        With xlWs.PageSetup
            .PrintTitleRows = "$1:$9"
            .PrintTitleColumns = ""
            .CenterFooter = "Page &P of &N"
            .Zoom = False
            .TopMargin = 10
            .LeftMargin = 0.2
            .RightMargin = 0.2
            .FitToPagesWide = 1
            .FitToPagesTall = lngPages
            .Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape
        End With

        ' Rem by Mark Lau 20090616
        'Set rs_MPR00003 = Nothing

        xlApp.DisplayAlerts = False 'No prompts to overwrite file
        xlWb.SaveAs("C:\出倉報表\" + strFileName)
        xlWb.Close(SaveChanges:=False)
        xlApp.Quit()

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing

        Cursor = Cursors.Default ' Return mouse pointer to normal.

        Exit Sub
Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Cursor = Cursors.Default ' Return mouse pointer to normal.
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_MPR00003 = Nothing

        xlWs = Nothing
        xlWb = Nothing
        xlApp = Nothing


    End Sub

    Private Sub setwidth(ByRef xls As Excel.Worksheet)

        With xls
            .Range("A:A").NumberFormat = "@"
            .Range("L:L").NumberFormat = "@"

            .Columns("A:A").ColumnWidth = 17
            .Columns("B:B").ColumnWidth = 40
            .Columns("C:C").ColumnWidth = 10
            .Columns("D:D").ColumnWidth = 12
            .Columns("E:E").ColumnWidth = 18
            .Columns("F:F").ColumnWidth = 6
            .Columns("G:G").ColumnWidth = 18
            .Columns("H:H").ColumnWidth = 6
            .Columns("I:I").ColumnWidth = 12
            .Columns("J:J").ColumnWidth = 20
            .Columns("K:K").ColumnWidth = 24
            .Columns("L:L").ColumnWidth = 19
        End With
    End Sub

    Private Sub showHeader(ByRef xls As Excel.Worksheet, ByVal rowHeader As Long)
        Dim iRow As Long

        iRow = rowHeader

        With xls
            '.Range(.Cells(iRow + 2, XLS_enu.A_xls), .Cells(iRow + 2, XLS_enu.A_xls)).Merge
            .Range(.Cells(iRow + 2, XLS_enu.A_xls), .Cells(iRow + 2, XLS_enu.A_xls)).Value = "TO : "
            .Range(.Cells(iRow + 2, XLS_enu.A_xls), .Cells(iRow + 2, XLS_enu.A_xls)).Font.Bold = True


            '.Range(.Cells(iRow + 3, XLS_enu.A_xls), .Cells(iRow + 3, XLS_enu.A_xls)).Merge
            .Range(.Cells(iRow + 3, XLS_enu.A_xls), .Cells(iRow + 3, XLS_enu.A_xls)).Value = "FM : "
            .Range(.Cells(iRow + 3, XLS_enu.A_xls), .Cells(iRow + 3, XLS_enu.A_xls)).Font.Bold = True


            '.Range(.Cells(iRow + 4, XLS_enu.A_xls), .Cells(iRow + 4, XLS_enu.A_xls)).Merge
            .Range(.Cells(iRow + 4, XLS_enu.A_xls), .Cells(iRow + 4, XLS_enu.A_xls)).Value = "賬號 : "
            .Range(.Cells(iRow + 4, XLS_enu.A_xls), .Cells(iRow + 4, XLS_enu.A_xls)).Font.Bold = True


            .Range(.Cells(iRow + 2, XLS_enu.B_xls), .Cells(iRow + 2, XLS_enu.C_xls)).Merge()
            .Range(.Cells(iRow + 2, XLS_enu.B_xls), .Cells(iRow + 2, XLS_enu.C_xls)).Value = strTO


            .Range(.Cells(iRow + 3, XLS_enu.B_xls), .Cells(iRow + 3, XLS_enu.C_xls)).Merge()
            .Range(.Cells(iRow + 3, XLS_enu.B_xls), .Cells(iRow + 3, XLS_enu.C_xls)).Value = strFm


            '.Range(.Cells(iRow + 4, XLS_enu.B_xls), .Cells(iRow + 4, XLS_enu.B_xls)).Merge
            .Range(.Cells(iRow + 4, XLS_enu.B_xls), .Cells(iRow + 4, XLS_enu.B_xls)).Value = strBillTo


            .Range(.Cells(iRow + 4, XLS_enu.C_xls), .Cells(iRow + 4, XLS_enu.D_xls)).Merge()
            .Range(.Cells(iRow + 4, XLS_enu.C_xls), .Cells(iRow + 4, XLS_enu.D_xls)).Value = "運輸工具 : "
            .Range(.Cells(iRow + 4, XLS_enu.C_xls), .Cells(iRow + 4, XLS_enu.D_xls)).Font.Bold = True


            .Range(.Cells(iRow + 4, XLS_enu.G_xls), .Cells(iRow + 4, XLS_enu.G_xls)).Value = "櫃號 : "
            .Range(.Cells(iRow + 4, XLS_enu.G_xls), .Cells(iRow + 4, XLS_enu.G_xls)).Font.Bold = True

            .Range(.Cells(iRow + 4, XLS_enu.h_xls), .Cells(iRow + 4, XLS_enu.J_xls)).Merge()
            .Range(.Cells(iRow + 4, XLS_enu.h_xls), .Cells(iRow + 4, XLS_enu.J_xls)).Value = strCTRNO

            .Range(.Cells(iRow + 4, XLS_enu.E_xls), .Cells(iRow + 4, XLS_enu.F_xls)).Merge()
            .Range(.Cells(iRow + 4, XLS_enu.E_xls), .Cells(iRow + 4, XLS_enu.F_xls)).Value = strCar


            .Range(.Cells(iRow + 6, XLS_enu.D_xls), .Cells(iRow + 6, XLS_enu.h_xls)).Merge()
            .Range(.Cells(iRow + 6, XLS_enu.D_xls), .Cells(iRow + 6, XLS_enu.h_xls)).Value = "出倉報表"
            .Range(.Cells(iRow + 6, XLS_enu.D_xls), .Cells(iRow + 6, XLS_enu.h_xls)).HorizontalAlignment = xlCenter
            .Range(.Cells(iRow + 6, XLS_enu.D_xls), .Cells(iRow + 6, XLS_enu.h_xls)).Font.Size = 36
            .Range(.Cells(iRow + 6, XLS_enu.D_xls), .Cells(iRow + 6, XLS_enu.h_xls)).Font.Bold = True
            .Range(.Cells(iRow + 6, XLS_enu.D_xls), .Cells(iRow + 6, XLS_enu.h_xls)).Borders(xlEdgeBottom).LineStyle = -4119
            .Range(.Cells(iRow + 6, XLS_enu.D_xls), .Cells(iRow + 6, XLS_enu.h_xls)).Borders(xlEdgeBottom).Weight = 4


            .Range(.Cells(iRow + 2, XLS_enu.G_xls), .Cells(iRow + 2, XLS_enu.G_xls)).Value = "CC : "
            .Range(.Cells(iRow + 2, XLS_enu.G_xls), .Cells(iRow + 2, XLS_enu.G_xls)).Font.Bold = True

            .Range(.Cells(iRow + 2, XLS_enu.h_xls), .Cells(iRow + 2, XLS_enu.J_xls)).Merge()
            .Range(.Cells(iRow + 2, XLS_enu.h_xls), .Cells(iRow + 2, XLS_enu.J_xls)).Value = strCC

            .Range(.Cells(iRow + 6, XLS_enu.L_xls), .Cells(iRow + 6, XLS_enu.L_xls)).Value = strDlvDat
            ''        .Range(.Cells(iRow + 6, XLS_enu.L_xls), .Cells(iRow + 6, XLS_enu.L_xls)).value= _
            ''        right("0" & str(month(Now())), 2) & "月" & right("0" & str(day(Now())), 2) & "日" & str(year(Now())) & "年"

            .Range(.Cells(iRow + 6, XLS_enu.L_xls), .Cells(iRow + 6, XLS_enu.L_xls)).HorizontalAlignment = xlLeft

            .Range(.Cells(iRow + 7, XLS_enu.L_xls), .Cells(iRow + 7, XLS_enu.L_xls)).Value = "GRN # : " & strGRNNo
            .Range(.Cells(iRow + 7, XLS_enu.L_xls), .Cells(iRow + 7, XLS_enu.L_xls)).HorizontalAlignment = xlLeft

            .Rows(iRow + 8).RowHeight = 50
            .Rows(iRow + 9).RowHeight = 50

            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.A_xls)).Merge()
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.A_xls)).Value = "物品編號"

            .Range(.Cells(iRow + 8, XLS_enu.B_xls), .Cells(iRow + 9, XLS_enu.B_xls)).Merge()
            .Range(.Cells(iRow + 8, XLS_enu.B_xls), .Cells(iRow + 9, XLS_enu.B_xls)).Value = "物品名稱"

            .Range(.Cells(iRow + 9, XLS_enu.C_xls), .Cells(iRow + 9, XLS_enu.C_xls)).Value = "總重量"

            .Range(.Cells(iRow + 9, XLS_enu.D_xls), .Cells(iRow + 9, XLS_enu.D_xls)).Value = "單位"
            .Range(.Cells(iRow + 9, XLS_enu.D_xls), .Cells(iRow + 9, XLS_enu.D_xls)).Orientation = -4166

            '.Range(.Cells(iRow + 9, XLS_enu.D_xls), .Cells(iRow + 9, XLS_enu.D_xls)).Orientation = -90
            '            .Range(.Cells(iRow + 9, XLS_enu.D_xls), .Cells(iRow + 9, XLS_enu.D_xls)).Orientation = xlVertical

            .Range(.Cells(iRow + 9, XLS_enu.E_xls), .Cells(iRow + 9, XLS_enu.F_xls)).Merge()
            .Range(.Cells(iRow + 9, XLS_enu.E_xls), .Cells(iRow + 9, XLS_enu.F_xls)).Value = "數量"

            .Range(.Cells(iRow + 9, XLS_enu.G_xls), .Cells(iRow + 9, XLS_enu.h_xls)).Merge()
            .Range(.Cells(iRow + 9, XLS_enu.G_xls), .Cells(iRow + 9, XLS_enu.h_xls)).Value = "件數"

            .Range(.Cells(iRow + 8, XLS_enu.C_xls), .Cells(iRow + 8, XLS_enu.h_xls)).Merge()
            .Range(.Cells(iRow + 8, XLS_enu.C_xls), .Cells(iRow + 8, XLS_enu.h_xls)).Value = "出倉報表"

            .Range(.Cells(iRow + 8, XLS_enu.I_xls), .Cells(iRow + 9, XLS_enu.I_xls)).Merge()
            .Range(.Cells(iRow + 8, XLS_enu.I_xls), .Cells(iRow + 9, XLS_enu.I_xls)).Value = "取貨部門"

            .Range(.Cells(iRow + 8, XLS_enu.J_xls), .Cells(iRow + 9, XLS_enu.J_xls)).Merge()
            .Range(.Cells(iRow + 8, XLS_enu.J_xls), .Cells(iRow + 9, XLS_enu.J_xls)).Value = "箱號"

            .Range(.Cells(iRow + 8, XLS_enu.K_xls), .Cells(iRow + 9, XLS_enu.K_xls)).Merge()
            .Range(.Cells(iRow + 8, XLS_enu.K_xls), .Cells(iRow + 9, XLS_enu.K_xls)).Value = "備注"

            .Range(.Cells(iRow + 8, XLS_enu.L_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Merge()
            .Range(.Cells(iRow + 8, XLS_enu.L_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Value = "訂單編號"

            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Font.Size = 12
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlDiagonalDown).LineStyle = xlNone
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlDiagonalUp).LineStyle = xlNone
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlEdgeLeft).LineStyle = xlNone
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlEdgeTop).LineStyle = xlContinuous
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlEdgeTop).Weight = 4

            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlEdgeBottom).LineStyle = xlContinuous
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlEdgeBottom).Weight = 4
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlEdgeRight).LineStyle = xlNone
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlInsideVertical).LineStyle = xlContinuous
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlInsideVertical).Weight = xlThin
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlInsideHorizontal).LineStyle = xlContinuous
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).Borders(xlInsideHorizontal).Weight = xlThin

            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).HorizontalAlignment = xlCenter
            .Range(.Cells(iRow + 8, XLS_enu.A_xls), .Cells(iRow + 9, XLS_enu.L_xls)).VerticalAlignment = xlCenter

        End With

    End Sub





    '-----------------------------------------------------------------------
    'Function List
    '-----------------------------------------------------------------------
    'BuildArray(String)
    'IsBounded(Variant) as boolean
    'HundredsTensUnits(Integer,Optional Boolean) as String
    'NumberAsText(Variant,Optional String) as String
    '-----------------------------------------------------------------------
    '-----------------------------------------------------------------------
    'Variable List
    '-----------------------------------------------------------------------
    'sNumberText() As String
    '
    '
    '
    '-----------------------------------------------------------------------



    ''Private Sub Command1_Click()
    ''   value = Text1(0).Text
    ''   Text1(1).Text = NumberAsText(value, "")
    ''End Sub


    Private Sub BuildArray()
        '    Private Sub BuildArray(ByVal sNumberText() As String)

        ReDim Preserve sNumberText(27)

        sNumberText(0) = "Zero"
        sNumberText(1) = "One"
        sNumberText(2) = "Two"
        sNumberText(3) = "Three"
        sNumberText(4) = "Four"
        sNumberText(5) = "Five"
        sNumberText(6) = "Six"
        sNumberText(7) = "Seven"
        sNumberText(8) = "Eight"
        sNumberText(9) = "Nine"
        sNumberText(10) = "Ten"
        sNumberText(11) = "Eleven"
        sNumberText(12) = "Twelve"
        sNumberText(13) = "Thirteen"
        sNumberText(14) = "Fourteen"
        sNumberText(15) = "Fifteen"
        sNumberText(16) = "Sixteen"
        sNumberText(17) = "Seventeen"
        sNumberText(18) = "Eighteen"
        sNumberText(19) = "Nineteen"
        sNumberText(20) = "Twenty"
        sNumberText(21) = "Thirty"
        sNumberText(22) = "Forty"
        sNumberText(23) = "Fifty"
        sNumberText(24) = "Sixty"
        sNumberText(25) = "Seventy"
        sNumberText(26) = "Eighty"
        sNumberText(27) = "Ninety"

    End Sub


    Private Function IsBounded(ByVal vntArray As Object) As Boolean

        'note: the application in the IDE will stop
        'at this line when first run if the IDE error
        'mode is not set to "Break on Unhandled Errors"
        '(Tools/Options/General/Error Trapping)
        On Error Resume Next
        IsBounded = IsNumeric(UBound(vntArray))

    End Function


    Private Function HundredsTensUnits(ByVal TestValue As Integer, _
                                       Optional ByVal bUseAnd As Boolean = False) As String

        Dim CardinalNumber As Integer

        If TestValue > 99 Then
            CardinalNumber = TestValue \ 100
            HundredsTensUnits = sNumberText(CardinalNumber) & " Hundred "
            TestValue = TestValue - (CardinalNumber * 100)
        End If

        If bUseAnd = True Then
            HundredsTensUnits = HundredsTensUnits & "and "
        End If

        If TestValue > 20 Then
            CardinalNumber = TestValue \ 10
            HundredsTensUnits = HundredsTensUnits & _
                                sNumberText(CardinalNumber + 18) & " "
            TestValue = TestValue - (CardinalNumber * 10)
        End If

        If TestValue > 0 Then
            HundredsTensUnits = HundredsTensUnits & sNumberText(TestValue) & " "
        End If

    End Function


    Private Function NumberAsText(ByVal NumberIn As Object, _
                                  Optional ByVal AND_or_CHECK_or_DOLLAR As String = "") As String
        Dim cnt As Long
        Dim DecimalPoint As Long
        Dim CardinalNumber As Long
        Dim CommaAdjuster As Long
        Dim TestValue As Long
        Dim CurrValue As String
        '        Dim CurrValue As Currency
        Dim CentsString As String
        Dim NumberSign As String
        Dim WholePart As String
        Dim BigWholePart As String
        Dim DecimalPart As String
        Dim tmp As String
        Dim sStyle As String
        Dim bUseAnd As Boolean
        Dim bUseCheck As Boolean
        Dim bUseDollars As Boolean

        sStyle = LCase(AND_or_CHECK_or_DOLLAR)

        bUseAnd = sStyle = "and"

        bUseDollars = sStyle = "dollar"

        bUseCheck = (sStyle = "check") Or (sStyle = "dollar")

        If Not IsBounded(sNumberText) Then
            Call BuildArray()
            '            Call BuildArray(sNumberText)
        End If

        NumberIn = Trim$(NumberIn)

        If Not IsNumeric(NumberIn) Then

            NumberAsText = "Error - Number improperly formed"
            Exit Function

        Else

            DecimalPoint = InStr(NumberIn, ".")

            If DecimalPoint > 0 Then

                DecimalPart = Mid$(NumberIn, DecimalPoint + 1)
                WholePart = Microsoft.VisualBasic.Left(NumberIn, DecimalPoint - 1)

            Else

                DecimalPoint = Len(NumberIn) + 1
                WholePart = NumberIn

            End If

            If InStr(NumberIn, ",,") Or _
               InStr(NumberIn, ",.") Or _
               InStr(NumberIn, ".,") Or _
               InStr(DecimalPart, ",") Then

                NumberAsText = "Error - Improper use of commas"
                Exit Function

            ElseIf InStr(NumberIn, ",") Then

                CommaAdjuster = 0
                WholePart = ""

                For cnt = DecimalPoint - 1 To 1 Step -1

                    If Not Mid$(NumberIn, cnt, 1) Like "[,]" Then

                        WholePart = Mid$(NumberIn, cnt, 1) & WholePart

                    Else

                        CommaAdjuster = CommaAdjuster + 1

                        If (DecimalPoint - cnt - CommaAdjuster) Mod 3 Then

                            NumberAsText = "Error - Improper use of commas"
                            Exit Function

                        End If 'If
                    End If  'If Not
                Next  'For cnt
            End If  'If InStr
        End If  'If Not


        If Microsoft.VisualBasic.Left(WholePart, 1) Like "[+-]" Then
            NumberSign = IIf(Microsoft.VisualBasic.Left(WholePart, 1) = "-", "Minus ", "Plus ")
            WholePart = Mid$(WholePart, 2)
        End If


        '----------------------------------------
        'Begin code to assure decimal portion of
        'check value is not inadvertently rounded
        '----------------------------------------
        If bUseCheck = True Then


            CurrValue = (Val("." & DecimalPart)).ToString
            DecimalPart = Mid$(Format$(CurrValue, "0.00"), 3, 2)

            If CurrValue >= 0.995 Then

                If WholePart = StrDup(Len(WholePart), "9") Then

                    WholePart = "1" & StrDup(Len(WholePart), "0")

                Else

                    For cnt = Len(WholePart) To 1 Step -1

                        If Mid$(WholePart, cnt, 1) = "9" Then
                            Mid$(WholePart, cnt, 1) = "0"
                        Else
                            Mid$(WholePart, cnt, 1) = CStr(Val(Mid$(WholePart, cnt, 1)) + 1)
                            Exit For
                        End If

                    Next

                End If  'If WholePart
            End If  'If CurrValue
        End If  'If bUseCheck

        '----------------------------------------
        'Final prep step - this assures number
        'within range of formatting code below
        '----------------------------------------
        If Len(WholePart) > 9 Then

            BigWholePart = Microsoft.VisualBasic.Left(WholePart, Len(WholePart) - 9)
            WholePart = Microsoft.VisualBasic.Right(WholePart, 9)
        End If

        If Len(BigWholePart) > 9 Then

            NumberAsText = "Error - Number too large"
            Exit Function

        ElseIf Not WholePart Like StrDup(Len(WholePart), "#") Or _
              (Not BigWholePart Like StrDup(Len(BigWholePart), "#") _
               And Len(BigWholePart) > 0) Then

            NumberAsText = "Error - Number improperly formed"
            Exit Function

        End If

        '----------------------------------------
        'Begin creating the output string
        '----------------------------------------

        'Very Large values
        TestValue = Val(BigWholePart)

        If TestValue > 999999 Then
            CardinalNumber = TestValue \ 1000000
            tmp = HundredsTensUnits(CardinalNumber) & "Quadrillion "
            TestValue = TestValue - (CardinalNumber * 1000000)
        End If

        If TestValue > 999 Then
            CardinalNumber = TestValue \ 1000
            tmp = tmp & HundredsTensUnits(CardinalNumber) & "Trillion "
            TestValue = TestValue - (CardinalNumber * 1000)
        End If

        If TestValue > 0 Then
            tmp = tmp & HundredsTensUnits(TestValue) & "Billion "
        End If

        'Lesser values
        TestValue = Val(WholePart)

        If TestValue = 0 And BigWholePart = "" Then tmp = "Zero "

        If TestValue > 999999 Then
            CardinalNumber = TestValue \ 1000000
            tmp = tmp & HundredsTensUnits(CardinalNumber) & "Million "
            TestValue = TestValue - (CardinalNumber * 1000000)
        End If

        If TestValue > 999 Then
            CardinalNumber = TestValue \ 1000
            tmp = tmp & HundredsTensUnits(CardinalNumber) & "Thousand "
            TestValue = TestValue - (CardinalNumber * 1000)
        End If

        If TestValue > 0 Then
            If Val(WholePart) < 99 And BigWholePart = "" Then bUseAnd = False
            tmp = tmp & HundredsTensUnits(TestValue, bUseAnd)
        End If

        'If in dollar mode, assure the text is the correct plurality
        If bUseDollars = True Then

            CentsString = HundredsTensUnits(DecimalPart)

            If tmp = "One " Then
                tmp = tmp & "Dollar"
            Else
                tmp = tmp & "Dollars"
            End If

            If Len(CentsString) > 0 Then

                tmp = tmp & " and " & CentsString

                If CentsString = "One " Then
                    tmp = tmp & "Cent"
                Else
                    tmp = tmp & "Cents"
                End If

            End If

        ElseIf bUseCheck = True Then

            tmp = tmp & "and " & Microsoft.VisualBasic.Left(DecimalPart & "00", 2)
            tmp = tmp & "/100"

        Else

            If Len(DecimalPart) > 0 Then

                tmp = tmp & "Point"

                For cnt = 1 To Len(DecimalPart)
                    tmp = tmp & " " & sNumberText(Mid$(DecimalPart, cnt, 1))
                Next

            End If  'If DecimalPart
        End If   'If bUseDollars


        'done!
        NumberAsText = NumberSign & tmp

    End Function


    Function DirExists(ByVal DName As String) As Boolean

        Dim sDummy As String

        On Error Resume Next

        If Microsoft.VisualBasic.Right(DName, 1) <> "\" Then DName = DName & "\"
        sDummy = Dir$(DName & "*.*", vbDirectory)
        DirExists = Not (sDummy = "")

    End Function



    Private Sub MPR00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form_Load()
    End Sub

    Private Sub txtGrnNoFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGrnNoFm.GotFocus
        txtGrnNoFm.SelectionStart = 0
        txtGrnNoFm.SelectionLength = Len(txtGrnNoFm.Text)

    End Sub

    Private Sub txtGrnNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrnNoFm.TextChanged
        Me.txtGrnNoTo.Text = Me.txtGrnNoFm.Text
    End Sub

    Private Sub txtGrnNoTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGrnNoTo.GotFocus
        txtGrnNoTo.SelectionStart = 0
        txtGrnNoTo.SelectionLength = Len(txtGrnNoTo.Text)

    End Sub

    Private Sub txtGrnNoTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrnNoTo.TextChanged

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        cmdShow_Click()
    End Sub

    Private Sub cboReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReport.SelectedIndexChanged
        If Me.cboReport.Text <> "" Then
            If Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optInv Then
                Me.optShow.Enabled = True
                Me.optHidden.Enabled = True
                Me.cboDP.Enabled = True
                Frame2.Enabled = True
                Frame3.Enabled = True
                Me.cboInvUm.Enabled = True
                Frame4.Enabled = True
            ElseIf Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optCust Then
                Me.optShow.Enabled = True
                Me.optHidden.Enabled = True
                Me.cboDP.Enabled = True
                Frame2.Enabled = True
                Frame3.Enabled = True
                Me.cboInvUm.Enabled = False
                Frame4.Enabled = False
            Else
                Me.optShow.Enabled = False
                Me.optHidden.Enabled = False
                Me.cboDP.Enabled = False
                Frame2.Enabled = False
                Frame3.Enabled = False
                Me.cboInvUm.Enabled = False
                Frame4.Enabled = False
            End If
        End If

        ' Added by Mark Lau 20090617
        If Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = OPTRPT Then
            optFormat0.Visible = True
            optFormat1.Visible = True
            optFormat0.Checked = True
        Else
            optFormat0.Visible = False
            optFormat1.Visible = False
        End If

        ' Frankie Cheung 20091016
        If Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optPck Or Microsoft.VisualBasic.Left(Me.cboReport.Text, 1) = optInv Then
            chkPrtGrp.Visible = True
        Else
            chkPrtGrp.Visible = False
        End If


    End Sub
End Class
