Imports Excel = Microsoft.Office.Interop.Excel
Public Class POR00001

    Const strModule As String = "PO"
    Const strDir As String = "C:\ERP PDF"

    Dim rs_POR00001 As New DataSet
    Dim rs_Excel As New DataSet
    Dim rs_POR00001_shipment As New DataSet
    Dim rs_POR00001_carton As New DataSet
    Dim rs_POR00001_disprm As New DataSet
    Dim rs_POR00001_assortment As New DataSet
    Dim rs_check As New DataSet

    Dim POcheck As String

    Private Enq_right_local As Boolean
    Private Del_right_local As Boolean

    Public init_PONo As String = ""
    Public init_cocde As String = ""

    Private Sub POR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        cboReportFormat.Items.Add("Purchase Order Format")
        cboReportFormat.Items.Add("Purchase Order PDF Format")
        'cboReportFormat.Items.Add("Purchase Order LAIFEI Format (Excel)")


        POcheck = "Y"

        If Not ((gsUsrGrp = "AUD-S") Or (gsUsrGrp = "CED-G") Or (gsUsrGrp = "CED-G2") Or (gsUsrGrp = "CED-S") Or _
                (gsUsrGrp = "EDP-G") Or (gsUsrGrp = "EDP-G1") Or (gsUsrGrp = "EDP-S") Or (gsUsrGrp = "SAL-ZS") Or _
                (gsUsrGrp = "SAL-ZE") Or (gsUsrGrp = "SAL-ZG") Or (gsUsrGrp = "SAL-ZP") Or (gsUsrGrp = "MAUD-S") Or _
                (gsUsrGrp = "MGT-S") Or (gsUsrGrp = "MIS-S") Or (gsUsrGrp = "MSAL-A")) Then
            optAmtN.Checked = True
            optAmtY.Enabled = False
        Else
            cboReportFormat.Items.Add("Purchase Order LAIFEI Format (Excel)")
        End If

        cboReportFormat.SelectedIndex = 0
        If init_cocde <> "" Then
            cboCoCde.Text = init_cocde
            cboCoCde.Enabled = False
        End If
        If init_PONo <> "" Then
            txtFm.Text = init_PONo
            txtFm.ReadOnly = True
            txtTo.Text = init_PONo
            txtTo.ReadOnly = True
        End If
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged
        txtTo.Text = txtFm.Text
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        If cboReportFormat.SelectedIndex = -1 Then
            MsgBox("Please Select Output Format !")
            Exit Sub
        End If

        Dim shipFormat As String
        If optApprox.Checked = True Then
            shipFormat = "A"
        Else
            shipFormat = "E"
        End If

        '-- * Past parameter to store port (Suppress ZERO Qty)
        Dim Sup0 As String
        If optSupY.Checked = True Then
            Sup0 = "Y"
        Else
            Sup0 = "N"
        End If

        '-- * Past parameter to store port (Sort By)
        Dim SORTBY As String
        If optCust.Checked = True Then
            SORTBY = "CUST"
        Else
            SORTBY = "ITEM"
        End If

        '-- * Check have any entry
        If txtFm.Text = "" Or txtTo.Text = "" Then
            MsgBox("Purchase Order empty !")
            Exit Sub
        End If

        '-- * Past parameter for revised option
        Dim Rvs As String
        If optRvsYes.Checked = True Then
            Rvs = "Y"
        Else
            Rvs = "N"
        End If

        Dim printGroup As String
        If optGroupY.Checked = True Then
            printGroup = "1"
        Else
            printGroup = "0"
        End If

        Dim PRINTAMT As String
        If optAmtY.Checked = True Then
            PRINTAMT = "1"
        Else
            PRINTAMT = "0"
        End If

        '03/04/2016 New SC PO Approval
        'check PO in ERL and Final Approval flag
        gspStr = "sp_select_POR00001_check '" & cboCoCde.Text & "','" & txtFm.Text & "','" & txtTo.Text & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading POR00001 #001 sp_select_POR00001_check : " & rtnStr)
            Exit Sub
        Else
            If rs.Tables("RESULT").Rows.Count = 1 Then
                If rs.Tables("RESULT").Rows(0).Item("invalid_count") > 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Not all PO in CLO or REL Status with Final Approved")
                    Exit Sub
                End If
            End If
        End If


        If cboReportFormat.SelectedIndex = 0 Then

            gspStr = "sp_select_POR00001 '" & cboCoCde.Text & "','" & Sup0 & "','" & txtFm.Text & "','" & txtTo.Text & "','" & Rvs & "','" & SORTBY & "','" & printGroup & "','" & PRINTAMT & "','" & POcheck & "','" & gsUsrID & "','" & strModule & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_POR00001, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading POR00001 #001 sp_select_POR00001 : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_POR00001_shipment '" & cboCoCde.Text & "','" & shipFormat & "','" & txtFm.Text & "','" & txtTo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00001_shipment, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading POR00001 #002 sp_select_POR00001_shipment : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_POR00001_carton '" & cboCoCde.Text & "','" & txtFm.Text & "','" & txtTo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00001_carton, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading POR00001 #003 sp_select_POR00001_carton : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_POR00001_disprm '" & cboCoCde.Text & "','" & txtFm.Text & "','" & txtTo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00001_disprm, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading POR00001 #004 sp_select_POR00001_disprm : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_POR00001_assortment '" & cboCoCde.Text & "','" & txtFm.Text & "','" & txtTo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00001_assortment, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading POR00001 #005 sp_select_POR00001_disprm : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_POORDHDR '" & cboCoCde.Text & "','" & txtFm.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POR00001 #006 sp_select_POORDHDR : " & rtnStr)
                Exit Sub
            End If

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If rs_POR00001.Tables("RESULT").Rows.Count = 0 Then
                If rs_check.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No record found !")
                    Exit Sub
                Else
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("You have no access rights to print!")
                    Exit Sub
                End If
            End If

            Dim dv As DataView = rs_POR00001.Tables("RESULT").DefaultView
            If optCust.Checked = True Then
                dv.Sort = "pod_purord,pod_cusitm,podKey,pod_venitm, pod_vencol, pod_engdsc,pod_inrctn,pod_mtrctn,pod_cubcft,pod_cuscol , pod_coldsc"
            Else
                dv.Sort = "pod_purord,podKey,pod_venitm, pod_vencol, pod_engdsc,pod_inrctn,pod_mtrctn,pod_cubcft,pod_cuscol , pod_coldsc"
            End If
            rs_POR00001.Tables.Remove("RESULT")
            rs_POR00001.Tables.Add(dv.ToTable)

            ' Data Manipulation
            ' Change shipmark and company Logo filepath to Byte[]
            Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
            Dim compLogo As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("logoimgpth"))
            Dim shpmrkM As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("psm_imgpth_M"))
            Dim shpmrkS As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("psm_imgpth_S"))
            Dim shpmrkI As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("psm_imgpth_I"))
            colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
            colshpmrkM = New DataColumn("shpmrkM", System.Type.GetType("System.Byte[]"))
            colshpmrkS = New DataColumn("shpmrkS", System.Type.GetType("System.Byte[]"))
            colshpmrkI = New DataColumn("shpmrkI", System.Type.GetType("System.Byte[]"))
            rs_POR00001.Tables("RESULT").Columns.Add(colCompLogo)
            rs_POR00001.Tables("RESULT").Columns.Add(colshpmrkM)
            rs_POR00001.Tables("RESULT").Columns.Add(colshpmrkS)
            rs_POR00001.Tables("RESULT").Columns.Add(colshpmrkI)
            rs_POR00001.Tables("RESULT").Columns("compLogo").ReadOnly = False
            rs_POR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = False
            rs_POR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = False
            rs_POR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = False
            For i As Integer = 0 To rs_POR00001.Tables("RESULT").Rows.Count - 1
                rs_POR00001.Tables("RESULT").Rows(i)("compLogo") = compLogo
                rs_POR00001.Tables("RESULT").Rows(i)("shpmrkM") = shpmrkM
                rs_POR00001.Tables("RESULT").Rows(i)("shpmrkS") = shpmrkS
                rs_POR00001.Tables("RESULT").Rows(i)("shpmrkI") = shpmrkI
            Next
            rs_POR00001.Tables("RESULT").Columns("compLogo").ReadOnly = True
            rs_POR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = True
            rs_POR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = True
            rs_POR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = True

            Dim objRpt As New POR00001Rpt
            objRpt.Database.Tables("POR00001").SetDataSource(rs_POR00001.Tables("RESULT"))
            objRpt.Database.Tables("POR00001_assortment").SetDataSource(rs_POR00001_assortment.Tables("RESULT"))
            objRpt.Database.Tables("POR00001_disprm").SetDataSource(rs_POR00001_disprm.Tables("RESULT"))
            objRpt.Database.Tables("POR00001_shipment").SetDataSource(rs_POR00001_shipment.Tables("RESULT"))
            objRpt.Database.Tables("POR00001_carton").SetDataSource(rs_POR00001_carton.Tables("RESULT"))
            'Add Subreport report source
            'objRpt.Subreports.Item("POR00001_assortment.rpt").SetDataSource(rs_POR00001_disprm.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()

            Me.Cursor = Windows.Forms.Cursors.Default
        ElseIf cboReportFormat.SelectedIndex = 1 Then
            Dim dir As New IO.DirectoryInfo(strDir)
            If dir.Exists = False Then
                MsgBox("The Following Directory Does not exist: " & strDir)
                Exit Sub
            End If

            Dim rs_POR00001_PDF As New DataSet

            gspStr = "sp_select_POR00001_PDF '" & cboCoCde.Text & "','" & Sup0 & "','" & txtFm.Text & "','" & txtTo.Text & _
                     "','" & Rvs & "','" & SORTBY & "','" & printGroup & "','" & PRINTAMT & "','" & POcheck & "','" & _
                     gsUsrID & "','" & strModule & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00001_PDF, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POR00001 #007 sp_select_POR00001_PDF : " & rtnStr)
                Exit Sub
            End If

            If rs_POR00001_PDF.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No Record Found!")
                Exit Sub
            End If

            Try
                For i As Integer = 0 To rs_POR00001_PDF.Tables("RESULT").Rows.Count - 1
                    gspStr = "sp_select_POR00001 '" & cboCoCde.Text & "','" & Sup0 & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "','" & Rvs & "','" & SORTBY & "','" & printGroup & "','" & PRINTAMT & "','" & POcheck & "','" & gsUsrID & "','" & strModule & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs_POR00001, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading POR00001 #001 sp_select_POR00001 : " & rtnStr)
                        Exit Sub
                    End If

                    gspStr = "sp_select_POR00001_shipment '" & cboCoCde.Text & "','" & shipFormat & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_POR00001_shipment, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading POR00001 #002 sp_select_POR00001_shipment : " & rtnStr)
                        Exit Sub
                    End If

                    gspStr = "sp_select_POR00001_carton '" & cboCoCde.Text & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_POR00001_carton, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading POR00001 #003 sp_select_POR00001_carton : " & rtnStr)
                        Exit Sub
                    End If

                    gspStr = "sp_select_POR00001_disprm '" & cboCoCde.Text & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_POR00001_disprm, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading POR00001 #004 sp_select_POR00001_disprm : " & rtnStr)
                        Exit Sub
                    End If

                    gspStr = "sp_select_POR00001_assortment '" & cboCoCde.Text & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_POR00001_assortment, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading POR00001 #005 sp_select_POR00001_disprm : " & rtnStr)
                        Exit Sub
                    End If

                    gspStr = "sp_select_POORDHDR '" & cboCoCde.Text & "','" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading POR00001 #006 sp_select_POORDHDR : " & rtnStr)
                        Exit Sub
                    End If

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    If rs_POR00001.Tables("RESULT").Rows.Count = 0 Then
                        If rs_check.Tables("RESULT").Rows.Count = 0 Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("No record found !")
                            Exit Sub
                        Else
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("You have no access rights to print!")
                            Exit Sub
                        End If
                    End If

                    Dim dv As DataView = rs_POR00001.Tables("RESULT").DefaultView
                    If optCust.Checked = True Then
                        dv.Sort = "pod_purord,pod_cusitm,podKey,pod_venitm, pod_vencol, pod_engdsc,pod_inrctn,pod_mtrctn,pod_cubcft,pod_cuscol , pod_coldsc"
                    Else
                        dv.Sort = "pod_purord,podKey,pod_venitm, pod_vencol, pod_engdsc,pod_inrctn,pod_mtrctn,pod_cubcft,pod_cuscol , pod_coldsc"
                    End If
                    rs_POR00001.Tables.Remove("RESULT")
                    rs_POR00001.Tables.Add(dv.ToTable)

                    ' Data Manipulation
                    ' Change shipmark and company Logo filepath to Byte[]
                    Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
                    Dim compLogo As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("logoimgpth"))
                    Dim shpmrkM As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("psm_imgpth_M"))
                    Dim shpmrkS As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("psm_imgpth_S"))
                    Dim shpmrkI As Byte() = imageToByteArray(rs_POR00001.Tables("RESULT").Rows(0)("psm_imgpth_I"))
                    colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                    colshpmrkM = New DataColumn("shpmrkM", System.Type.GetType("System.Byte[]"))
                    colshpmrkS = New DataColumn("shpmrkS", System.Type.GetType("System.Byte[]"))
                    colshpmrkI = New DataColumn("shpmrkI", System.Type.GetType("System.Byte[]"))
                    rs_POR00001.Tables("RESULT").Columns.Add(colCompLogo)
                    rs_POR00001.Tables("RESULT").Columns.Add(colshpmrkM)
                    rs_POR00001.Tables("RESULT").Columns.Add(colshpmrkS)
                    rs_POR00001.Tables("RESULT").Columns.Add(colshpmrkI)
                    rs_POR00001.Tables("RESULT").Columns("compLogo").ReadOnly = False
                    rs_POR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = False
                    rs_POR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = False
                    rs_POR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = False
                    For j As Integer = 0 To rs_POR00001.Tables("RESULT").Rows.Count - 1
                        rs_POR00001.Tables("RESULT").Rows(j)("compLogo") = compLogo
                        rs_POR00001.Tables("RESULT").Rows(j)("shpmrkM") = shpmrkM
                        rs_POR00001.Tables("RESULT").Rows(j)("shpmrkS") = shpmrkS
                        rs_POR00001.Tables("RESULT").Rows(j)("shpmrkI") = shpmrkI
                    Next
                    rs_POR00001.Tables("RESULT").Columns("compLogo").ReadOnly = True
                    rs_POR00001.Tables("RESULT").Columns("shpmrkM").ReadOnly = True
                    rs_POR00001.Tables("RESULT").Columns("shpmrkS").ReadOnly = True
                    rs_POR00001.Tables("RESULT").Columns("shpmrkI").ReadOnly = True

                    Dim objRpt As New POR00001Rpt
                    objRpt.Database.Tables("POR00001").SetDataSource(rs_POR00001.Tables("RESULT"))
                    objRpt.Database.Tables("POR00001_assortment").SetDataSource(rs_POR00001_assortment.Tables("RESULT"))
                    'Add Subreport report source
                    objRpt.Subreports.Item("POR00001_disprm").SetDataSource(rs_POR00001_disprm.Tables("RESULT"))
                    objRpt.Subreports.Item("POR00001_shipment").SetDataSource(rs_POR00001_shipment.Tables("RESULT"))
                    objRpt.Subreports.Item("POR00001_carton").SetDataSource(rs_POR00001_carton.Tables("RESULT"))

                    'Export to PDF
                    objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strDir & "\" & rs_POR00001_PDF.Tables("RESULT").Rows(i)("poh_purord").ToString & ".pdf")
                Next
            Catch ex As Exception
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("An Error has occurred during the data extraction process", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try

            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Total " & rs_POR00001_PDF.Tables("RESULT").Rows.Count & " PO(s) has/have been converted successfully.")
        ElseIf cboReportFormat.SelectedIndex = 2 Then

            gspStr = "sp_select_POR00001 '" & cboCoCde.Text & "','" & Sup0 & "','" & txtFm.Text & "','" & txtFm.Text & "','" & Rvs & "','" & SORTBY & "','" & printGroup & "','" & PRINTAMT & "','" & POcheck & "','" & gsUsrID & "','" & strModule & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_Excel, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading POR00001 #001 sp_select_POR00001 : " & rtnStr)
                Exit Sub
            End If


            Call CmdExportExcel_Click()


        End If
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


    Private Sub CmdExportExcel_Click()
        On Error GoTo Err_Handler
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.ApplicationClass
        Dim xlWB As Excel.Workbook = Nothing
        Dim xlWS As Excel.Worksheet = Nothing



        xlApp = New Excel.Application
        xlApp.Visible = True
        xlApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlWB = xlApp.Workbooks.Add()
        xlWS = xlWB.ActiveSheet


        Dim colcount As Integer
        Dim rowcount As Integer

        colcount = 1


        'Header Section
        rowcount = 1
        xlWS.Cells(rowcount, 1).value = "Customer Name : " & rs_Excel.Tables("RESULT").Rows(0).Item("cbi_cussna_new")

        xlWS.Cells(rowcount, 14).value = "Issue Date : "
        xlWS.Cells(rowcount, 16).value = rs_Excel.Tables("RESULT").Rows(0).Item("poh_issdat")

        rowcount = 2

        Dim strPONo As String
        If optRvsYes.Checked = True Then
            xlWS.Cells(rowcount, 1).value = "Purchase Order No. : " & rs_Excel.Tables("RESULT").Rows(0).Item("poh_purord") & " (Revised)"
        Else
            xlWS.Cells(rowcount, 1).value = "Purchase Order No. : " & rs_Excel.Tables("RESULT").Rows(0).Item("poh_purord")
        End If

        xlWS.Cells(rowcount, 14).value = "Revised Date :"
        xlWS.Cells(rowcount, 16).value = rs_Excel.Tables("RESULT").Rows(0).Item("poh_upddat")

        rowcount = 3
        xlWS.Cells(rowcount, 1).value = "Cust. Order No. : " & rs_Excel.Tables("RESULT").Rows(0).Item("poh_cuspno")

        xlWS.Cells(rowcount, 14).value = "Cust. Order Date :"
        xlWS.Cells(rowcount, 16).value = rs_Excel.Tables("RESULT").Rows(0).Item("poh_cpodat")


        'Body Section
        rowcount = 5
        xlWS.Cells(rowcount, 1).value = "Item No." & vbCrLf & "本行貨號"
        xlWS.Range("A:A").NumberFormat = "@"
        xlWS.Range("A:A").ColumnWidth = 15

        xlWS.Cells(rowcount, 2).value = "Vendor Item No." & vbCrLf & "廠家貨號"
        xlWS.Range("B:B").NumberFormat = "@"
        xlWS.Range("B:B").ColumnWidth = 20

        xlWS.Cells(rowcount, 3).value = "Cust. Item No." & vbCrLf & "客人貨號"
        xlWS.Range("C:C").NumberFormat = "@"
        xlWS.Range("C:C").ColumnWidth = 20

        xlWS.Cells(rowcount, 4).value = "Description" & vbCrLf & "品稱"
        xlWS.Range("D:D").NumberFormat = "@"
        xlWS.Range("D:D").ColumnWidth = 30

        xlWS.Cells(rowcount, 5).value = "Color" & vbCrLf & "顏色"
        xlWS.Range("E:E").NumberFormat = "@"
        xlWS.Range("E:E").ColumnWidth = 10

        xlWS.Cells(rowcount, 6).value = "Unit" & vbCrLf & "單位"
        xlWS.Range("F:F").NumberFormat = "@"
        xlWS.Range("F:F").ColumnWidth = 6

        xlWS.Cells(rowcount, 7).value = "Inner" & vbCrLf & "內盒"
        xlWS.Range("G:G").NumberFormat = "0"
        xlWS.Range("G:G").ColumnWidth = 6

        xlWS.Cells(rowcount, 8).value = "Master" & vbCrLf & "外箱"
        xlWS.Range("H:H").NumberFormat = "0"
        xlWS.Range("H:H").ColumnWidth = 6

        xlWS.Cells(rowcount, 9).value = "Cft" & vbCrLf & "材尺"
        xlWS.Range("I:I").NumberFormat = "0.0000"
        xlWS.Range("I:I").ColumnWidth = 8

        xlWS.Cells(rowcount, 10).value = "Curr." & vbCrLf & "貨幣"
        xlWS.Range("J:J").NumberFormat = "@"
        xlWS.Range("J:J").ColumnWidth = 8

        xlWS.Cells(rowcount, 11).value = "Unit Price" & vbCrLf & "單價"
        xlWS.Range("K:K").NumberFormat = "0.00"
        xlWS.Range("K:K").ColumnWidth = 6

        xlWS.Cells(rowcount, 12).value = "Qty" & vbCrLf & "數量"
        xlWS.Range("L:L").NumberFormat = "0"
        xlWS.Range("L:L").ColumnWidth = 6

        xlWS.Cells(rowcount, 13).value = "Ctn" & vbCrLf & "箱數"
        xlWS.Range("M:M").NumberFormat = "0"
        xlWS.Range("M:M").ColumnWidth = 6

        xlWS.Cells(rowcount, 14).value = "Amount" & vbCrLf & "金額"
        xlWS.Range("N:N").NumberFormat = "0.00"
        xlWS.Range("N:N").ColumnWidth = 10

        xlWS.Cells(rowcount, 15).value = "Total Cft" & vbCrLf & "總立方尺"
        xlWS.Range("O:O").NumberFormat = "0.0000"
        xlWS.Range("O:O").ColumnWidth = 10

        xlWS.Cells(rowcount, 16).value = "Delivery" & vbCrLf & "貨期"
        xlWS.Range("P:P").NumberFormat = "MM/dd/YYYY"
        xlWS.Range("P:P").ColumnWidth = 10

        xlWS.Cells(rowcount, 17).value = "Remark" & vbCrLf & "備註"
        xlWS.Range("Q:Q").NumberFormat = "@"
        xlWS.Range("Q:Q").ColumnWidth = 35

        xlWS.Cells(rowcount, 18).value = "PV" & vbCrLf & "生產工廠"
        xlWS.Range("R:R").NumberFormat = "@"
        xlWS.Range("R:R").ColumnWidth = 30

        xlWS.Cells(rowcount, 19).value = "Job No." & vbCrLf & "生產單號"
        xlWS.Range("S:S").NumberFormat = "@"
        xlWS.Range("S:S").ColumnWidth = 15


        rowcount = 6

        Dim i As Integer
        For i = 0 To rs_Excel.Tables("RESULT").Rows.Count - 1
            xlWS.Cells(rowcount + i, 1).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_itmno")
            xlWS.Cells(rowcount + i, 2).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_venitm")
            xlWS.Cells(rowcount + i, 3).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_cusitm")
            xlWS.Cells(rowcount + i, 4).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_engdsc")
            xlWS.Cells(rowcount + i, 5).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_vencol")
            xlWS.Cells(rowcount + i, 6).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_untcde")
            xlWS.Cells(rowcount + i, 7).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_inrctn")
            xlWS.Cells(rowcount + i, 8).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_mtrctn")
            xlWS.Cells(rowcount + i, 9).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_cubcft")
            xlWS.Cells(rowcount + i, 10).value = rs_Excel.Tables("RESULT").Rows(i).Item("poh_curcde")
            xlWS.Cells(rowcount + i, 11).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_ftyprc")
            xlWS.Cells(rowcount + i, 12).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_ordqty")
            xlWS.Cells(rowcount + i, 13).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_ttlctn")
            xlWS.Cells(rowcount + i, 14).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_lneamt")
            xlWS.Cells(rowcount + i, 15).value = rs_Excel.Tables("RESULT").Rows(i).Item("lne_cft")
            xlWS.Cells(rowcount + i, 16).value = rs_Excel.Tables("RESULT").Rows(i).Item("shipstr")
            xlWS.Cells(rowcount + i, 17).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_rmk")
            xlWS.Cells(rowcount + i, 18).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_pvnam")
            xlWS.Cells(rowcount + i, 19).value = rs_Excel.Tables("RESULT").Rows(i).Item("pod_jobord")
        Next i

        'Footer Section
        rowcount = rowcount + rs_Excel.Tables("RESULT").Rows.Count + 1
        xlWS.Cells(rowcount, 1).value = "Total CFT 總立方尺 : " & Decimal.Round(rs_Excel.Tables("RESULT").Rows(0).Item("poh_ttlcbm"), 2) & "'"
        rowcount = rowcount + 1
        xlWS.Cells(rowcount, 1).value = "Payment Term : " & rs_Excel.Tables("RESULT").Rows(0).Item("paytrmDesc")

        Dim strRmk As String

        strRmk = ""

        If rs_Excel.Tables("RESULT").Rows(0).Item("poh_rmk_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("poh_rmk_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("poh_rmk_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("MainEngRmk_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("MainEngRmk_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("MainEngRmk_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("MainChn_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("MainChn_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("MainChn_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("MainChnRmk_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("MainChnRmk_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("MainChnRmk_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("SideEngRmk_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("SideEngRmk_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("SideEngRmk_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("SideChn_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("SideChn_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("SideChn_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("SideChnRmk_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("SideChnRmk_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("SideChnRmk_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("InnerEngRmk_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("InnerEngRmk_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("InnerEngRmk_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("InnerChn_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("InnerChn_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("InnerChn_Memo")
            End If
        End If

        If rs_Excel.Tables("RESULT").Rows(0).Item("InnerChnRmk_Memo") <> "" Then
            If strRmk = "" Then
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("InnerChnRmk_Memo") & vbCrLf
            Else
                strRmk = strRmk & rs_Excel.Tables("RESULT").Rows(0).Item("InnerChnRmk_Memo")
            End If
        End If


        rowcount = rowcount + 1
        xlWS.Range(xlWS.Cells(rowcount, 1), xlWS.Cells(rowcount, 18)).Merge()
        xlWS.Range(xlWS.Cells(rowcount, 1), xlWS.Cells(rowcount, 18)).HorizontalAlignment = 2
        xlWS.Range(xlWS.Cells(rowcount, 1), xlWS.Cells(rowcount, 18)).VerticalAlignment = 1
        xlWS.Range(xlWS.Cells(rowcount, 1), xlWS.Cells(rowcount, 18)).RowHeight = 250
        xlWS.Range(xlWS.Cells(rowcount, 1), xlWS.Cells(rowcount, 18)).NumberFormat = ""
        xlWS.Cells(rowcount, 1).value = "Remarks : " & strRmk



        '        xlWS.Cells(1, 16).numberformat = "MM/dd/YYYY"
        '        xlWS.Cells(2, 16).numberformat = "MM/dd/YYYY"
        '        xlWS.Cells(3, 16).numberformat = "MM/dd/YYYY"

        'rowcount = rowcount + 1

        'xlWS.Range(xlWS.Cells(rowcount, 1), xlWS.Cells(rowcount, 8)).Merge()
        'xlWS.Range(xlWS.Cells(rowcount, 1), xlWS.Cells(rowcount, 8)).HorizontalAlignment = 2
        'xlWS.Cells(rowcount, 1).value = "Remark : " & remarkStr

        '    .Range(.Cells(1, 1), .Cells(1, 16)).Value = strCompany
        '    .Range(.Cells(1, 1), .Cells(1, 10)).RowHeight = 35
        '    .Range(.Cells(1, 1), .Cells(1, 10)).Font.Size = 20
        '    .Range(.Cells(1, 1), .Cells(1, 10)).Font.Bold = True
        '    .Range(.Cells(1, 1), .Cells(1, 10)).HorizontalAlignment = 2









        'Dim recCount As Long

        ''xxxxxxxxxxx
        'Dim strCocde As String
        'Dim DtlRow As Long

        'Dim i As Long
        'Dim indexCol As Long
        'Dim intGroup As Long
        'Dim strGroup As String
        'Dim tmpGroup As String
        ''Dim bolPO As Boolean
        'Dim strCompany As String
        'Dim strTitle1 As String
        'Dim strTitle2 As String

        'Dim strAddress1 As String
        'Dim strAddress2 As String

        'Dim objCell As Object
        'Dim objVbreaks As Object

        'Dim intIndex As Integer
        'Dim strSort As String
        'Dim intRow As Integer
        'Dim intRowLength As Integer
        'Dim strShipRmk As String

        'strSort = ""
        'intGroup = 0
        'indexCol = 1
        'DtlRow = 8











        ''        '==========================================================
        ''        'xxxxxxxxxxxxxxxxxxxxx< Title Start >xxxxxxxxxxxxxxxxxxxxxx

        'strTitle1 = "樣品通知書"
        'strTitle2 = "SAMPLE REQUEST"
        'strSort = "(This sample request is print in " & IIf(rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.sort_enum) = "ITM", "Item #", "Input") & " sequence)"
        'strCocde = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.srh_cocde_enum)


        'strCompany = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_conam_enum)
        'If strCocde = "UCP" Then
        '    strAddress1 = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_addrc_enum) + _
        '                    "   電話: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_phoneno_enum) + _
        '                    "   傳真: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_faxno_enum)
        '    strAddress2 = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_addr_enum) + _
        '                    "   Tel: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_phoneno_enum) + _
        '                    "   Fax: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_faxno_enum)
        'Else
        '    strAddress1 = rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_addr_enum)
        '    strAddress2 = "Tel: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_phoneno_enum) + _
        '                    "   Fax: " + rs_EXCEL.Tables("RESULT").Rows(0).Item(SAREQ_enum.yco_faxno_enum)
        'End If
        'xlApp.UserControl = True

        'With xlWS

        '    'COmpany Name
        '    .Range(.Cells(1, 1), .Cells(1, 16)).Merge()
        '    .Range(.Cells(1, 1), .Cells(1, 16)).Value = strCompany
        '    .Range(.Cells(1, 1), .Cells(1, 10)).RowHeight = 35
        '    .Range(.Cells(1, 1), .Cells(1, 10)).Font.Size = 20
        '    .Range(.Cells(1, 1), .Cells(1, 10)).Font.Bold = True
        '    .Range(.Cells(1, 1), .Cells(1, 10)).HorizontalAlignment = 2
        '    'Company Address
        '    .Range(.Cells(2, 1), .Cells(2, 10)).Merge()
        '    .Range(.Cells(2, 1), .Cells(2, 10)).Value = strAddress1
        '    .Range(.Cells(2, 1), .Cells(2, 10)).Font.Size = 8
        '    .Range(.Cells(2, 1), .Cells(2, 10)).HorizontalAlignment = 2
        '    .Range(.Cells(3, 1), .Cells(3, 10)).Merge()
        '    .Range(.Cells(3, 1), .Cells(3, 10)).Value = strAddress2
        '    .Range(.Cells(3, 1), .Cells(3, 10)).Font.Size = 8
        '    .Range(.Cells(3, 1), .Cells(3, 10)).HorizontalAlignment = 2
        '    'Report Title
        '    .Range(.Cells(5, 6), .Cells(5, 10)).Merge()
        '    .Range(.Cells(5, 6), .Cells(5, 10)).Value = strTitle1
        '    .Range(.Cells(5, 6), .Cells(5, 10)).Font.Size = 22
        '    .Range(.Cells(5, 6), .Cells(5, 10)).HorizontalAlignment = 3
        '    .Range(.Cells(5, 6), .Cells(5, 10)).RowHeight = 30
        '    .Range(.Cells(6, 6), .Cells(6, 10)).Merge()
        '    .Range(.Cells(6, 6), .Cells(6, 10)).Value = strTitle2
        '    .Range(.Cells(6, 6), .Cells(6, 10)).Font.Size = 22
        '    .Range(.Cells(6, 6), .Cells(6, 10)).HorizontalAlignment = 3
        '    .Range(.Cells(6, 6), .Cells(6, 10)).RowHeight = 30
        'End With
        ''xxxxxxxxxxxxxxxxxxxxx< Title End >xxxxxxxxxxxxxxxxxxxxxxxx
        ''..........................................................


        ''==========================================================
        ''xxxxxxxxxxxxxxxxxxxx< Row Header Start>xxxxxxxxxxxxxxxxxxxx

        ''xxxxxxxxxxxxxxxxxxxx< Row Header End >xxxxxxxxxxxxxxxxxxxxxx
        ''..........................................................


        ''xxxxxxxxxxxxxxxxxxxx< Row Detail Start >xxxxxxxxxxxxxxxxxxxxxx
        ''..........................................................



        'recCount = rs_EXCEL.Tables("RESULT").Rows.Count - 1

        'With xlWS

        '    strGroup = ""
        '    tmpGroup = ""
        '    'lnghead = intGroup + i + DtlRow + 1


        '    For i = 0 To recCount

        '        tmpGroup = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_reqno_enum)
        '        If strGroup <> tmpGroup Then
        '            'Show Footer
        '            '.............................................................................................

        '            If strGroup <> "" Then
        '                'add code to show group footer here
        '                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Merge()
        '                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Value = strSort

        '                If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) <> "UCPP" Then
        '                    .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Merge()
        '                    .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Value = _
        '                    "1.  每隻樣品請貴廠用白色招紙寫上客號/本行貨號貼/掛在樣品上不可寫廠號或有廠之招紙或吊牌。" & vbCrLf & _
        '                    "2.  箱外請寫上客名及收貨人以供識別。" & vbCrLf & _
        '                    "3.  請貼  ''MADE IN CHINA''  招紙於樣品上。"
        '                    intGroup = intGroup + 7
        '                End If
        '                intGroup = intGroup + 4
        '            End If
        '            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        '            strGroup = tmpGroup
        '            intIndex = 0
        '            '+++++++++++++++ Address to Ship Mark ++++++++++++++++++++++++++++
        '            '   Top Right
        '            .Cells(intGroup + i + DtlRow, indexCol + 12) = "辦單編號"
        '            .Cells(intGroup + i + DtlRow, indexCol + 13) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow, indexCol + 14), .Cells(intGroup + i + DtlRow, indexCol + 15)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow, indexCol + 14), .Cells(intGroup + i + DtlRow, indexCol + 15)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ysr_saltem_enum) & " - " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_reqno_enum)
        '            .Range(.Cells(intGroup + i + DtlRow, indexCol + 14), .Cells(intGroup + i + DtlRow, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1


        '            .Cells(intGroup + i + DtlRow + 1, indexCol + 12) = "SCS REF#"
        '            .Cells(intGroup + i + DtlRow + 1, indexCol + 13) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 14), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 14), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1


        '            .Cells(intGroup + i + DtlRow + 2, indexCol + 12) = "辦單日期"
        '            .Cells(intGroup + i + DtlRow + 2, indexCol + 13) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = Format(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rvsdat_enum), "MM/dd/yyyy")
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).NumberFormatLocal = "MM/dd/yyyy"
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).HorizontalAlignment = 2
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1

        '            If strCocde = "UCPP" Then
        '                .Cells(intGroup + i + DtlRow + 3, indexCol + 12) = "辦到日期"
        '                .Cells(intGroup + i + DtlRow + 3, indexCol + 13) = ":"
        '                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).Merge()
        '                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).Value = Format(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_vendeldat_enum), "MM/dd/yyyy")
        '                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).NumberFormatLocal = "MM/dd/yyyy"
        '                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).HorizontalAlignment = 2
        '                .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 14), .Cells(intGroup + i + DtlRow + 3, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '            End If

        '            '   Left Hand Side
        '            .Cells(intGroup + i + DtlRow + 1, indexCol) = "工廠"
        '            .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Value = IIf(strCocde = "UCPP", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_vensna_enum), _
        '                                                                                                                        rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_vennam_enum) & IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_venno_enum) = "0005", " (" & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_subcde_enum) & ")", ""))
        '            .Cells(intGroup + i + DtlRow + 2, indexCol) = "致"
        '            .Cells(intGroup + i + DtlRow + 2, indexCol + 1) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 2), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 2), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 2), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_venctp_enum)

        '            .Cells(intGroup + i + DtlRow + 3, indexCol) = "由"
        '            .Cells(intGroup + i + DtlRow + 3, indexCol + 1) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 2), .Cells(intGroup + i + DtlRow + 3, indexCol + 6)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 2), .Cells(intGroup + i + DtlRow + 3, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 2), .Cells(intGroup + i + DtlRow + 3, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.salPeron_enum) & IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ysr_saltem_enum) = "S", "", " - " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ysr_saltem_enum))


        '            '   Right Hand Side

        '            .Cells(intGroup + i + DtlRow + 2, indexCol + 7) = "客人名稱"
        '            .Cells(intGroup + i + DtlRow + 2, indexCol + 8) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 9), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 9), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 9), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.cbi_cussna_enum), _
        '                                                                                                                        IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_venno_enum) = "0005" Or rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.vbi_venno_enum) = "0007", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.cbi_cussna_enum), _
        '                                                                                                                       rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cus1no_enum)))

        '            .Cells(intGroup + i + DtlRow + 3, indexCol + 7) = "客人單號"
        '            .Cells(intGroup + i + DtlRow + 3, indexCol + 8) = ":"
        '            .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 9), .Cells(intGroup + i + DtlRow + 3, indexCol + 11)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 9), .Cells(intGroup + i + DtlRow + 3, indexCol + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 3, indexCol + 9), .Cells(intGroup + i + DtlRow + 3, indexCol + 11)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cussmppo_enum)

        '            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        '            'Column Header

        '            intGroup = intGroup + 3

        '            If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.ShowCnt_enum) = "Y" Then
        '                .Cells(intGroup + i + DtlRow + 1, indexCol) = "電話號碼"
        '                .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Merge()
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_tel_enum)

        '                .Cells(intGroup + i + DtlRow + 1, indexCol + 7) = "傳真號碼"
        '                .Cells(intGroup + i + DtlRow + 1, indexCol + 8) = ":"
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 9), .Cells(intGroup + i + DtlRow + 1, indexCol + 13)).Merge()
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 9), .Cells(intGroup + i + DtlRow + 1, indexCol + 13)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 9), .Cells(intGroup + i + DtlRow + 1, indexCol + 13)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_fax_enum)

        '                intGroup = intGroup + 1
        '            End If


        '            If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.optSrh_Rmk_enum) = "Y" Then
        '                .Cells(intGroup + i + DtlRow + 1, indexCol) = "整體備註"
        '                .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 1), .Cells(intGroup + i + DtlRow + 1, indexCol + 1)).HorizontalAlignment = 2
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Merge()
        '                '.Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).NumberFormatLocal = "@"
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rmk_enum)
        '                intRow = getRowCount(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rmk_enum))
        '                intRowLength = Len(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_rmk_enum)) / 100
        '                If intRow > 1 Or intRowLength > 1 Then
        '                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).RowHeight = 17 * IIf(intRow >= intRowLength, intRow, intRowLength) + 20
        '                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).WrapText = True
        '                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).VerticalAlignment = 1
        '                End If
        '                intGroup = intGroup + 1
        '            End If



        '            If strCocde = "UCPP" Then
        '                If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.optSrh_Rmk_enum) = "N" Then
        '                    .Cells(intGroup + i + DtlRow + 1, indexCol) = "整體備註"
        '                    .Cells(intGroup + i + DtlRow + 1, indexCol + 1) = ":"
        '                    .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 1), .Cells(intGroup + i + DtlRow + 1, indexCol + 1)).HorizontalAlignment = 2
        '                End If
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol + 2), .Cells(intGroup + i + DtlRow + 1, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '                intGroup = intGroup + 1
        '            Else
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
        '                .Range(.Cells(intGroup + i + DtlRow + 1, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = _
        '                "下列各項為本公司寄客戶之新樣品/客戶落單後要求之先行樣品在 " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_vendeldatMM_enum) & _
        '                " 月 " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_vendeldatDD_enum) & " 日 前交本 行.   (寄送本公司樣品 希請列出要求樣品客戶名字)"
        '                intGroup = intGroup + 1
        '            End If


        '            .Cells(intGroup + i + DtlRow + 2, indexCol) = "編碼"

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", "廠貨號" & vbCrLf & "(永久)", "廠家貨號")

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", "廠貨號" & vbCrLf & "(作參考用須更改)", "本行貨號")


        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Value = "客人貨號"

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Value = "品稱"

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Value = "顏色"

        '            .Cells(intGroup + i + DtlRow + 2, indexCol + 12) = "數量"

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 13), .Cells(intGroup + i + DtlRow + 2, indexCol + 13)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 13), .Cells(intGroup + i + DtlRow + 2, indexCol + 13)).Value = "生產工廠"

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = "備註"

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1

        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).RowHeight = 40
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).HorizontalAlignment = 3

        '            intGroup = intGroup + 1

        '        End If
        '        intIndex = intIndex + 1
        '        .Cells(intGroup + i + DtlRow + 2, indexCol) = intIndex

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Merge()
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 1), .Cells(intGroup + i + DtlRow + 2, indexCol + 2)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_venitm_enum)

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Merge()
        '        If strCocde <> "UCPP" Then
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_itmno_enum)
        '        Else
        '            '{SAR00006_ttx.srd_tbm} <> "N" ;
        '            If rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_tbm_enum) <> "N" Then
        '                .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 3), .Cells(intGroup + i + DtlRow + 2, indexCol + 4)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_venitm_enum)
        '            End If
        '        End If

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).NumberFormatLocal = "@"

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Merge()
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 5), .Cells(intGroup + i + DtlRow + 2, indexCol + 6)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_cusitm_enum)

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Merge()
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 7), .Cells(intGroup + i + DtlRow + 2, indexCol + 9)).Value = rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_engdsc_enum)

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Merge()
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 10), .Cells(intGroup + i + DtlRow + 2, indexCol + 11)).Value = "" & IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) = "" Or rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) = "N/A", "", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) & _
        '                                                                                                                    IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_vencol_enum) <> "" And rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum) <> "", vbCrLf, "")) & _
        '                                                                                                                    IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum) = "" Or rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum) = "N/A", "", " " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_coldsc_enum))

        '        .Cells(intGroup + i + DtlRow + 2, indexCol + 12) = Trim(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.samplesQty_enum)) & " " & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.Unit_enum)

        '        .Cells(intGroup + i + DtlRow + 2, indexCol + 13) = Trim(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.prdvensna_enum))

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Merge()
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol + 14), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Value = IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srh_cocde_enum) = "UCPP", rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum), _
        '                                                                                                                     IIf(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_tbm_enum) = "Y", "Ref# :" & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_venitm_enum) & vbCrLf & rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum), rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum)))

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).RowHeight = 60
        '        intRow = getRowCount(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum))
        '        intRowLength = Len(rs_EXCEL.Tables("RESULT").Rows(i).Item(SAREQ_enum.srd_note_enum)) / 25
        '        If intRow > 4 Or intRowLength > 4 Then
        '            .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).RowHeight = 15 * IIf(intRow >= intRowLength, intRow, intRowLength)
        '        End If
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).HorizontalAlignment = 3
        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).VerticalAlignment = 3

        '        .Range(.Cells(intGroup + i + DtlRow + 2, indexCol), .Cells(intGroup + i + DtlRow + 2, indexCol + 15)).WrapText = True



        '        'rs_EXCEL.MoveNext()

        '    Next

        '    'Show Footer
        '    '.............................................................................................
        '    If strGroup <> "" Then
        '        'add code to show group footer here
        '        'xlApp.ActiveSheet.HPageBreaks.Add .Cells(intGroup + i + DtlRow + 3, indexCol + 10)
        '        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Merge()
        '        .Range(.Cells(intGroup + i + DtlRow + 3, indexCol), .Cells(intGroup + i + DtlRow + 3, indexCol + 10)).Value = strSort

        '        If strCocde <> "UCPP" Then
        '            .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Merge()
        '            .Range(.Cells(intGroup + i + DtlRow + 5, indexCol), .Cells(intGroup + i + DtlRow + 7, indexCol + 10)).Value = _
        '            "1.  每隻樣品請貴廠用白色招紙寫上客號/本行貨號貼/掛在樣品上不可寫廠號或有廠之招紙或吊牌。" & vbCrLf & _
        '            "2.  箱外請寫上客名及收貨人以供識別。" & vbCrLf & _
        '            "3.  請貼  ''MADE IN CHINA''  招紙於樣品上。"
        '            intGroup = intGroup + 7
        '        End If
        '        intGroup = intGroup + 4
        '    End If
        '    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        'End With
        ''xxxxxxxxxxxxxxxxxxxx< Row Detail End >xxxxxxxxxxxxxxxxxxxxxx
        ''..........................................................



        ''++++++++++++++++++++< Detail Style Start>+++++++++++++++++++
        ''============================================================
        'With xlWS
        '    .Columns.ColumnWidth = 10
        '    .Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount, indexCol + 15)).Font.Size = 10

        '    '.Range(.Cells(DtlRow, indexCol), .Cells(intGroup + DtlRow + recCount, indexCol + 9)).HorizontalAlignment = 2
        '    '.Range(.Cells(DtlRow, indexCol + 5), .Cells(intGroup + DtlRow + recCount, indexCol + 5)).HorizontalAlignment = 3
        'End With
        ''++++++++++++++++++++< Detail Style End  >+++++++++++++++++++
        ''............................................................




        'Dim lngPages As Long

        ''Max FitToPagesTall of Excel = 9999
        'lngPages = recCount / 6 + 2
        'If lngPages > 9999 Then
        '    lngPages = 9999
        'End If
        ''Set print options

        ''With xlWS.PageSetup
        ''.Zoom = False
        ''    .TopMargin = 5

        ''    .FitToPagesWide = 1
        ''    .FitToPagesTall = lngPages
        ''    .Orientation = Excel.XlPageOrientation.xlLandscape
        ''    .CenterFooter = "Page  &P  of  &N "
        ''End With

        ''xlWs.Close
        ''xlApp.Quit


        rs_Excel = Nothing

        ' Release Excel references
        xlWS = Nothing
        xlWB = Nothing
        xlApp = Nothing



        'With Screen
        '    Me.Move (.Width - Width) \ 2, (.Height - Height) \ 2
        'End With

        Me.Cursor = Windows.Forms.Cursors.Default ' Return mouse pointer to normal.

        Exit Sub

Err_Handler:
        If Err.Number = -2147417851 Then
            Resume Next
        End If
        Me.Cursor = Windows.Forms.Cursors.Default ' Return mouse pointer to normal.

        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        rs_Excel = Nothing


        ' Release Excel references
        xlWS = Nothing
        xlWB = Nothing
        xlApp = Nothing
    End Sub

    Private Sub cboReportFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportFormat.SelectedIndexChanged
        If cboReportFormat.SelectedIndex = 2 Then
            optGroupN.Checked = True
            optGroupY.Enabled = False
            optGroupN.Enabled = False
        Else
            optGroupY.Checked = True
            optGroupY.Enabled = True
            optGroupN.Enabled = True
        End If
    End Sub
End Class