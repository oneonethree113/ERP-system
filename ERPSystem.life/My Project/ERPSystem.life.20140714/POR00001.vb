Public Class POR00001

    Const strModule As String = "PO"
    Const strDir As String = "C:\ERP PDF"

    Dim rs_POR00001 As New DataSet
    Dim rs_POR00001_shipment As New DataSet
    Dim rs_POR00001_carton As New DataSet
    Dim rs_POR00001_disprm As New DataSet
    Dim rs_POR00001_assortment As New DataSet
    Dim rs_check As New DataSet

    Dim POcheck As String

    Private Enq_right_local As Boolean
    Private Del_right_local As Boolean

    Private Sub POR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        cboReportFormat.Items.Add("Purchase Order Format")
        cboReportFormat.Items.Add("Purchase Order PDF Format")
        cboReportFormat.SelectedIndex = 0

        POcheck = "Y"

        If Not ((gsUsrGrp = "AUD-S") Or (gsUsrGrp = "CED-G") Or (gsUsrGrp = "CED-G2") Or (gsUsrGrp = "CED-S") Or _
                (gsUsrGrp = "EDP-G") Or (gsUsrGrp = "EDP-G1") Or (gsUsrGrp = "EDP-S") Or (gsUsrGrp = "SAL-ZS") Or _
                (gsUsrGrp = "SAL-ZE") Or (gsUsrGrp = "SAL-ZG") Or (gsUsrGrp = "SAL-ZP") Or (gsUsrGrp = "MAUD-S") Or _
                (gsUsrGrp = "MGT-S") Or (gsUsrGrp = "MIS-S") Or (gsUsrGrp = "MSAL-A")) Then
            optAmtN.Checked = True
            optAmtY.Enabled = False
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
End Class