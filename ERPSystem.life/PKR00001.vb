Imports Microsoft.Office.Interop
Imports System.IO

Public Class PKR00001

    Public rs_PKR00001A As DataSet
    Public rs_PKR00001 As DataSet

    Public rs_INR00001SUBA As DataSet
    Public rs_INR00001SUB As DataSet

    Public rs_INR00001 As DataSet

    Public companycode As String
    Public dr() As DataRow


    Private Sub PKR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        'loadComboBox()

        'Call format_cboSC()

        'Call FillcboCust()
        'GetDefaultCompany(cboCoCde, txtCoNam)

        cboCoCde.Text = "UC-G"
        txtCoNam.Text = "UNITED CHINESE GROUP"

        cboRptFmt.Items.Add("Packing List Standard Format")
        cboRptFmt.Items.Add("Packing List (Wal-Mart USA Format)")
        cboRptFmt.Items.Add("Packing List (Wal-Mart Canada Format)")
        cboRptFmt.Items.Add("Packing List (MM Team - Target Format)")
        '        cboRptFmt.Items.Add("Packing List (MM Team - Target Canada Format)")
        '       cboRptFmt.Items.Add("Packing List (MM Team - Target DotCom Format)")
        cboRptFmt.Items.Add("Packing List  (PB Air Shipment Format USA)")
        cboRptFmt.Items.Add("Packing List  (PB Air Shipment Format Australia)")
        cboRptFmt.Items.Add("Packing List  (PB  Middle East Format)")
        cboRptFmt.Items.Add("Packing List  (Ballard Format)")
        cboRptFmt.Items.Add("Packing List  (Sams Mexico Format)")

        cboRptFmt.Items.Add("Packing List  (TJX  Format)")

        cboRptFmt.Items.Add("Packing List  (CB INTL  Format)")
        cboRptFmt.Items.Add("Packing List  (CB USA  Format)")

        cboRptFmt.Items.Add("Combine Packing List Standard Format (Not Available)")

        cboRptFmt.SelectedIndex = 0



        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        '        cboCoCde.Items.Add("ALL")
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        cboCoCde.Text = "ALL"
        Cursor = Cursors.Default

        optQTYY.Checked = True
        optQTYN.Checked = False

        optCub.Checked = False
        Option8.Checked = True

        txtCoNam.BackColor = Color.White
        txtFromQuotNo.BackColor = Color.White
        txtToQuotNo.BackColor = Color.White



        If companycode <> "" Then
            cboCoCde.Text = companycode
        End If

    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Cursor = Cursors.WaitCursor



        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        Dim cocde As String
        cocde = cboCoCde.Text

        If cboRptFmt.SelectedIndex = 0 Then
            '''' Standard

            Dim hdr As String
            Dim itm As String
            Dim cub As String
            Dim gnw As String
            Dim job As String
            Dim Sku As String
            Dim CTR As String
            Dim printGroup As String
            Dim PrintAlias As String
            Dim two As String
            Dim thr As String
            Dim fou As String
            Dim fiv As String
            Dim optUCP As String


            If opt2.Checked = True Then
                two = "Y"
            Else
                two = "N"
            End If


            If optQTYY.Checked = True Then
                thr = "Y"
            Else
                thr = "N"
            End If

            If optRPOY.Checked = True Then
                fou = "Y"
            Else
                fou = "N"
            End If


            If optItm.Checked = True Then
                itm = "Y"
            Else
                itm = "N"
            End If

            If optCub.Checked = True Then
                fiv = "Y"
            Else
                fiv = "N"
            End If

            If optUCPY.Checked = True Then
                optUCP = "Y"
            Else
                optUCP = "N"
            End If


            hdr = 1

            cub = "Y"
            gnw = "Y"
            job = "Y"
            Sku = "N"
            CTR = "N"
            PrintAlias = 1
            printGroup = 1

            If OptCTRY.Checked = True Then
                CTR = "Y"
            Else
                CTR = "N"
            End If

            gspStr = "sp_select_pkr00001_NET '" & _
            cocde & "','" & hdr & "','" & itm & "','" & cub & "','" & gnw & "','" & job & "','" & Sku & "','" & CTR & "','" & two & "','" & thr & "','" & fou & "','" & fiv & "','" & optUCP & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & printGroup & "','" & PrintAlias & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_PKR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading pkr00001 : " & rtnStr)
                Exit Sub
            End If

            ''2
            gspStr = " sp_select_INR00001SUBA_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & printGroup & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUBA, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If


            If rs_PKR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("PKR00001 No Record!")
                Exit Sub

            Else  'has record

                'picture
                Dim colCompLogo As DataColumn
                Dim compLogo As Byte() = imageToByteArray(rs_PKR00001.Tables("RESULT").Rows(0)("logoimgpth"))
                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_PKR00001.Tables("RESULT").Columns.Add(colCompLogo)
                rs_PKR00001.Tables("RESULT").Columns("compLogo").ReadOnly = False
                For i As Integer = 0 To rs_PKR00001.Tables("RESULT").Rows.Count - 1
                    rs_PKR00001.Tables("RESULT").Rows(i)("compLogo") = compLogo
                Next
                rs_PKR00001.Tables("RESULT").Columns("compLogo").ReadOnly = True


                Dim objRpt As New PKR00001Rpt_ftr2
                'Dim objRpt As New INR00001Rpt


                objRpt.SetDataSource(rs_PKR00001.Tables("RESULT"))
                'objRpt.Subreports.Item("INR00001SUBA").SetDataSource(rs_INR00001SUBA.Tables("RESULT"))
                objRpt.Subreports.Item("INR00001SUBA01").SetDataSource(rs_INR00001SUBA.Tables("RESULT"))
                objRpt.Subreports.Item("sub1").SetDataSource(rs_INR00001SUBA.Tables("RESULT"))
                objRpt.Subreports.Item("sub2").SetDataSource(rs_INR00001SUBA.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

                Me.Cursor = Windows.Forms.Cursors.Default

            End If

            '''


        ElseIf cboRptFmt.SelectedIndex = 3 Then
            '''S  
            '' MM Team Target Form
            Dim hdr As String
            Dim itm As String
            Dim cub As String
            Dim gnw As String
            Dim job As String
            Dim Sku As String
            Dim CTR As String
            Dim printGroup As String
            Dim PrintAlias As String

            hdr = 1
            itm = "Y"
            cub = "Y"
            gnw = "Y"
            job = "Y"
            Sku = "N"
            CTR = "N"
            PrintAlias = 1
            printGroup = 1

            gspStr = "sp_select_pkr00001A_NET '" & _
            cocde & "','" & hdr & "','" & itm & "','" & cub & "','" & gnw & "','" & job & "','" & Sku & "','" & CTR & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & printGroup & "','" & PrintAlias & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_PKR00001A, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading pkr00001A : " & rtnStr)
                Exit Sub
            End If

            ''2
            gspStr = " sp_select_INR00001SUBA_NET '" & _
                            cocde & "','" & _
              txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "','" & printGroup & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUBA, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If


            If rs_PKR00001A.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("PKR00001A No Record!")
                Exit Sub

            Else  'has record

                'picture
                Dim colCompLogo As DataColumn
                Dim compLogo As Byte() = imageToByteArray(rs_PKR00001A.Tables("RESULT").Rows(0)("logoimgpth"))
                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_PKR00001A.Tables("RESULT").Columns.Add(colCompLogo)
                rs_PKR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = False
                For i As Integer = 0 To rs_PKR00001A.Tables("RESULT").Rows.Count - 1
                    rs_PKR00001A.Tables("RESULT").Rows(i)("compLogo") = compLogo
                Next
                rs_PKR00001A.Tables("RESULT").Columns("compLogo").ReadOnly = True


                Dim objRpt As New PKR00001ARpt
                'Dim objRpt As New INR00001ARpt


                objRpt.SetDataSource(rs_PKR00001A.Tables("RESULT"))
                objRpt.Subreports.Item("INR00001SUBA").SetDataSource(rs_INR00001SUBA.Tables("RESULT"))
                'objRpt.Subreports.Item("INR00001SUBA01").SetDataSource(rs_INR00001SUBA.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()

                Me.Cursor = Windows.Forms.Cursors.Default

            End If
            '''E
        ElseIf cboRptFmt.SelectedIndex = 1 Then

            '' wal mart USA format
            Dim rs_PKR00001B As DataSet

            gspStr = "sp_select_PKR00001B_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"
            rs_PKR00001B = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_PKR00001B, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading " & Me.Name & " sp_select_PKR00001B : " & rtnStr)
                Exit Sub
            Else
                For i As Integer = 0 To rs_PKR00001B.Tables("RESULT").Columns.Count - 1
                    rs_PKR00001B.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If

            If rs_PKR00001B.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            Else
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim colCompLogo As DataColumn
                Dim compLogo As Byte() = imageToByteArray(rs_PKR00001B.Tables("RESULT").Rows(0)("yco_logoimgpth"))
                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_PKR00001B.Tables("RESULT").Columns.Add(colCompLogo)
                rs_PKR00001B.Tables("RESULT").Columns("complogo").ReadOnly = False
                For j As Integer = 0 To rs_PKR00001B.Tables("RESULT").Rows.Count - 1
                    rs_PKR00001B.Tables("RESULT").Rows(j)("compLogo") = compLogo
                Next
                Me.Cursor = Windows.Forms.Cursors.Default

                Dim objRpt As New PKR00001B1Rpt
                objRpt.Database.Tables("PKR00001B").SetDataSource(rs_PKR00001B.Tables("RESULT"))
                ''Export to PDF
                'objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "C:\" & txtFromQuotNo.Text & ".pdf")
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
                Me.Cursor = Windows.Forms.Cursors.Default
            End If


        ElseIf cboRptFmt.SelectedIndex = 2 Then
            '' wal mart Canada format

            Dim rs_PKR00001B As DataSet

            gspStr = "sp_select_PKR00001B_NET '" & cboCoCde.Text & "','" & txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"
            rs_PKR00001B = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_PKR00001B, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading " & Me.Name & " sp_select_PKR00001B : " & rtnStr)
                Exit Sub
            Else
                For i As Integer = 0 To rs_PKR00001B.Tables("RESULT").Columns.Count - 1
                    rs_PKR00001B.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If

            If rs_PKR00001B.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            Else
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim colCompLogo As DataColumn
                Dim compLogo As Byte() = imageToByteArray(rs_PKR00001B.Tables("RESULT").Rows(0)("yco_logoimgpth"))
                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_PKR00001B.Tables("RESULT").Columns.Add(colCompLogo)
                rs_PKR00001B.Tables("RESULT").Columns("complogo").ReadOnly = False
                For j As Integer = 0 To rs_PKR00001B.Tables("RESULT").Rows.Count - 1
                    rs_PKR00001B.Tables("RESULT").Rows(j)("compLogo") = compLogo
                Next
                Me.Cursor = Windows.Forms.Cursors.Default

                Dim objRpt As New PKR00001B2Rpt
                objRpt.Database.Tables("PKR00001B").SetDataSource(rs_PKR00001B.Tables("RESULT"))
                ''Export to PDF
                'objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "C:\" & txtFromQuotNo.Text & ".pdf")
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
                Me.Cursor = Windows.Forms.Cursors.Default
            End If

        ElseIf cboRptFmt.SelectedIndex = 9 Then
            'tjx
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001_NET '" & _
                cocde & "','N','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','Y','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            gspStr = " sp_select_INR00001SUB_NET '" & _
                         cocde & "','" & _
           txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUB, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
                rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            Next
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001FRpt

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))

            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default


        ElseIf cboRptFmt.SelectedIndex = 8 Then
            'Mexico
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001_NET '" & _
                cocde & "','N','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','Y','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
                rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            Next
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001ERpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))

            '            objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))

            '     objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub1").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub2").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("INR00001DP.rpt").SetDataSource(rs_INR00001DP.Tables("RESULT"))
            '      objRpt.Subreports.Item("subdetail").SetDataSource(rs_INR00001.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default

        ElseIf cboRptFmt.SelectedIndex = 6 Then
            'PB  mid
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001_NET '" & _
                cocde & "','N','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','Y','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
                rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            Next
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001DRpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))

            '     objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub1").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub2").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("INR00001DP.rpt").SetDataSource(rs_INR00001DP.Tables("RESULT"))
            '      objRpt.Subreports.Item("subdetail").SetDataSource(rs_INR00001.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default
        ElseIf cboRptFmt.SelectedIndex = 4 Then

            'PB  air USA
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001G_NET '" & _
                cocde & "','N','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','Y','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
                rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            Next
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001GRpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))

            '     objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub1").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub2").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("INR00001DP.rpt").SetDataSource(rs_INR00001DP.Tables("RESULT"))
            '      objRpt.Subreports.Item("subdetail").SetDataSource(rs_INR00001.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default

        ElseIf cboRptFmt.SelectedIndex = 5 Then

            'PB  air Austra
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001G_NET '" & _
                cocde & "','Y','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','Y','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
                rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            Next
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001GRpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))

            '     objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub1").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("sub2").SetDataSource(rs_INR00001SUB.Tables("RESULT"))
            'objRpt.Subreports.Item("INR00001DP.rpt").SetDataSource(rs_INR00001DP.Tables("RESULT"))
            '      objRpt.Subreports.Item("subdetail").SetDataSource(rs_INR00001.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default


        ElseIf cboRptFmt.SelectedIndex = 7 Then
            'Ball 
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001H_NET '" & _
                cocde & "','N','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','P','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            gspStr = " sp_select_INR00001HSUB_NET '" & _
                         cocde & "','" & _
           txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUB, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If

            'picture
            'Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            'Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            'colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            'rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            'rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            'For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
            '    rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            'Next
            'rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001HRpt

            'Dim frmReportView As New frmReport
            'frmReportView.CrystalReportViewer.ReportSource = objRpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))
            objRpt.Subreports.Item("INR00001SUB").SetDataSource(rs_INR00001SUB.Tables("RESULT"))

            ' objRpt.Subreports.Item("INR00001SUB").SetDataSource(rs_INR00001SUB.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt


            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default

        ElseIf cboRptFmt.SelectedIndex = 10 Then
            'CB INTL
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001_NET_CB '" & _
                cocde & "','N','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','Y','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            gspStr = " sp_select_INR00001SUB_NET '" & _
                         cocde & "','" & _
           txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUB, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
                rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            Next
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001CIpt

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))
            'objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))

            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default

        ElseIf cboRptFmt.SelectedIndex = 11 Then
            'CB USA 
            Me.optItm.Checked = False

            gspStr = "sp_select_INR00001_NET_CB '" & _
                cocde & "','N','N','N','C','N','Y','N','" & _
                 txtFromQuotNo.Text & "','" & _
                txtToQuotNo.Text & "','0','CUSITM','1','1','N','N','N','Y','Y','Y','" & _
            gsUsrGrp & "'"



            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001 : " & rtnStr)
                Exit Sub
            End If

            If rs_INR00001.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("INR00001 No Record!")
                Exit Sub
            End If

            gspStr = " sp_select_INR00001SUB_NET '" & _
                         cocde & "','" & _
           txtFromQuotNo.Text & "','" & txtToQuotNo.Text & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_INR00001SUB, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading INR00001SUB : " & rtnStr)
                Exit Sub
            End If

            'picture
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_INR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            colCompLogo = New DataColumn("Complogo", System.Type.GetType("System.Byte[]"))
            rs_INR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = False
            For i As Integer = 0 To rs_INR00001.Tables("RESULT").Rows.Count - 1
                rs_INR00001.Tables("RESULT").Rows(i)("Complogo") = compLogo
            Next
            rs_INR00001.Tables("RESULT").Columns("Complogo").ReadOnly = True



            Dim objRpt As New PKR00001CUpt

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            objRpt.SetDataSource(rs_INR00001.Tables("RESULT"))
            ' objRpt.Subreports.Item("INR00001SUB.rpt").SetDataSource(rs_INR00001SUB.Tables("RESULT"))

            frmReportView.Show()


            Me.Cursor = Windows.Forms.Cursors.Default
        Else

        End If

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub cboCoCdeClick()
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Call getDefault_Path()

    End Sub


    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub txtFromQuotNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromQuotNo.LostFocus
        txtToQuotNo.Text = txtFromQuotNo.Text.Trim

    End Sub

    Private Sub txtFromQuotNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromQuotNo.TextChanged

    End Sub
    Private Sub txtToQuotNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToQuotNo.TextChanged

    End Sub
    Private Function imageToByteArray(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If ImageFilePath = "" Then
            Return Nothing
        End If
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        Call cboCoCdeClick()
    End Sub




End Class