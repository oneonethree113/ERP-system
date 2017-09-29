Imports word = Microsoft.Office.Interop.Word
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class POR00005
    Public rs_POR00005 As New DataSet
    Public rs_POR00005_shipment As New DataSet
    Public rs_POR00005_carton As New DataSet
    Public rs_POR00005_shipmark As New DataSet
    Public rs_POR00005_assortment As New DataSet

    Public rs_POR00005_EDI_Hdr As New DataSet
    Public rs_POR00005_EDI_Dtl As New DataSet
    Public rs_POR00005_EDI_SM As New DataSet
    Public rs_POR00005_EDI_ASM As New DataSet

    Public rsFYPRTFYO_EDI As New DataSet

    Public rs_PJDHONG As New DataSet
    Public rs_Assortment As New DataSet

    'Dim RptVer02_POR00005 As POR00005RptVer02

    Public Assortment As String
    Public GenFileNameEDI As String

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim sJPR As String
    Dim sFm As String
    Dim sTo As String

    Private Sub POR00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)

        optBat.Enabled = False
        txtBatNo.Enabled = False

        txtPOFm.Enabled = False
        txtPOTo.Enabled = False

        Call Formstartup(Me.Name)

        If ((gsUsrGrp = "SAL-ZS") Or (gsUsrGrp = "SAL-ZE") Or (gsUsrGrp = "SAL-ZG")) Then
            optRunNo.Enabled = False
            optBat.Enabled = False
            txtRunNoFm.Enabled = False
            txtRunNoTo.Enabled = False
            txtBatNo.Enabled = False
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
    End Sub

    Private Sub optJob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optJob.CheckedChanged
        txtFm.Enabled = True
        txtTo.Enabled = True
        txtPOFm.Enabled = False
        txtPOTo.Enabled = False
        txtRunNoFm.Enabled = False
        txtRunNoTo.Enabled = False
        txtBatNo.Enabled = False

        txtPOFm.Text = ""
        txtPOTo.Text = ""
        txtRunNoFm.Text = ""
        txtRunNoTo.Text = ""
        txtBatNo.Text = ""

        optALL.Enabled = False
        optSAP.Enabled = False
    End Sub

    Private Sub optPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPO.CheckedChanged
        txtFm.Enabled = False
        txtTo.Enabled = False
        txtPOFm.Enabled = True
        txtPOTo.Enabled = True
        txtRunNoFm.Enabled = False
        txtRunNoTo.Enabled = False
        txtBatNo.Enabled = False

        txtFm.Text = ""
        txtTo.Text = ""
        txtRunNoFm.Text = ""
        txtRunNoTo.Text = ""
        txtBatNo.Text = ""

        optALL.Enabled = False
        optSAP.Enabled = False
    End Sub

    Private Sub optRunNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRunNo.CheckedChanged
        txtFm.Enabled = False
        txtTo.Enabled = False
        txtPOFm.Enabled = False
        txtPOTo.Enabled = False
        txtRunNoFm.Enabled = True
        txtRunNoTo.Enabled = True
        txtBatNo.Enabled = False

        txtFm.Text = ""
        txtTo.Text = ""
        txtPOFm.Text = ""
        txtPOTo.Text = ""
        txtBatNo.Text = ""

        optALL.Enabled = False
        optSAP.Enabled = False
    End Sub

    Private Sub optBat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBat.CheckedChanged
        txtFm.Enabled = False
        txtTo.Enabled = False
        txtPOFm.Enabled = False
        txtPOTo.Enabled = False
        txtRunNoFm.Enabled = False
        txtRunNoTo.Enabled = False
        txtBatNo.Enabled = True

        txtFm.Text = ""
        txtTo.Text = ""
        txtPOFm.Text = ""
        txtPOTo.Text = ""
        txtRunNoFm.Text = ""
        txtRunNoTo.Text = ""

        optALL.Enabled = True
        optSAP.Enabled = True
        optALL.Checked = True
    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged
        txtTo.Text = txtFm.Text
    End Sub

    Private Sub txtPOFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOFm.TextChanged
        txtPOTo.Text = txtPOFm.Text
    End Sub

    Private Sub txtRunNoFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRunNoFm.TextChanged
        txtRunNoTo.Text = txtRunNoFm.Text
    End Sub

    Private Sub txtBatNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatNo.GotFocus
        optBat.Checked = True
    End Sub

    Private Sub txtFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.GotFocus
        optJob.Checked = True
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        'If optSAP.Checked = True Then
        '    Call exportEDI_SAP()
        '    Exit Sub
        'End If

        'Dim rtfpath As String
        'Dim Tmppath As String
        'Dim XMLOutput As String
        'Dim DummyText As String
        'Dim BatchNo As String
        'Dim Runno As String
        'Dim ii As Integer

        'rtfpath = "c:\pdo\new\"
        'Tmppath = "c:\pdo\temp\"

        Cursor = Cursors.WaitCursor

        'Dim wd As New word.Application

        Dim printGroup As String

        If optGroupY.Checked = True Then
            printGroup = "1"
        Else
            printGroup = "0"
        End If

        If optJob.Checked = True Or optPO.Checked = True Or optRunNo.Checked = True Then
            If optJob.Checked = True Then
                If txtFm.Text = "" Or txtTo.Text = "" Then
                    Cursor = Cursors.Default
                    MsgBox("Job No empty!")
                    Exit Sub
                End If

                sJPR = "J"
                sFm = txtFm.Text
                sTo = txtTo.Text
            ElseIf optPO.Checked = True Then
                If txtPOFm.Text = "" Or txtPOTo.Text = "" Then
                    Cursor = Cursors.Default
                    MsgBox("PO No empty!")
                    Exit Sub
                End If

                sJPR = "P"
                sFm = txtPOFm.Text
                sTo = txtPOTo.Text
            Else
                If txtRunNoFm.Text = "" Or txtRunNoTo.Text = "" Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Running No empty!")
                    Exit Sub
                End If

                sJPR = "R"
                sFm = txtRunNoFm.Text
                sTo = txtRunNoTo.Text
            End if

            Cursor = Cursors.WaitCursor

            gspStr = "sp_select_POR00005 '" & cboCoCde.Text & "','" & sJPR & "','" & sFm & "','" & sTo & "','" & printGroup & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00005, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdShow_Click sp_select_POR00005 for " & sJPR & ":" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gspStr = "sp_select_POR00005_shipment '" & cboCoCde.Text & "','" & sJPR & "','" & sFm & "','" & sTo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00005_shipment, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdShow_Click sp_select_POR00005_shipment for " & sJPR & ":" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gspStr = "sp_select_POR00005_carton '" & cboCoCde.Text & "','" & sJPR & "','" & sFm & "','" & sTo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00005_carton, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdShow_Click sp_select_POR00005_carton for " & sJPR & ":" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gspStr = "sp_select_POR00005_assortment '" & cboCoCde.Text & "','" & sJPR & "','" & sFm & "','" & sTo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_POR00005_assortment, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdShow_Click sp_select_POR00005_assortment for " & sJPR & ":" & rtnStr)
                Exit Sub
            End If

            If rs_POR00005.Tables("RESULT").Rows.Count = 0 Then
                Cursor = Cursors.Default
                MsgBox("No record found !")
                Exit Sub
            Else
                Dim colCompLogo, colshpmrkM, colshpmrkS, colshpmrkI As DataColumn
                Dim compLogo, shpmrkM, shpmrkS, shpmrkI As Byte()

                colCompLogo = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
                rs_POR00005.Tables("RESULT").Columns.Add(colCompLogo)
                rs_POR00005.Tables("RESULT").Columns("compLogo").ReadOnly = False

                colshpmrkM = New DataColumn("shpmrkM", System.Type.GetType("System.Byte[]"))
                rs_POR00005.Tables("RESULT").Columns.Add(colshpmrkM)
                rs_POR00005.Tables("RESULT").Columns("shpmrkM").ReadOnly = False

                colshpmrkS = New DataColumn("shpmrkS", System.Type.GetType("System.Byte[]"))
                rs_POR00005.Tables("RESULT").Columns.Add(colshpmrkS)
                rs_POR00005.Tables("RESULT").Columns("shpmrkS").ReadOnly = False

                colshpmrkI = New DataColumn("shpmrkI", System.Type.GetType("System.Byte[]"))
                rs_POR00005.Tables("RESULT").Columns.Add(colshpmrkI)
                rs_POR00005.Tables("RESULT").Columns("shpmrkI").ReadOnly = False

                For i As Integer = 0 To rs_POR00005.Tables("RESULT").Rows.Count - 1
                    compLogo = imageToByteArray(rs_POR00005.Tables("RESULT").Rows(i)("logoimgpth"))
                    rs_POR00005.Tables("RESULT").Rows(i)("compLogo") = compLogo

                    ' Check if the image exists or not
                    If System.IO.File.Exists(rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_M").ToString) = False Then
                        rs_POR00005.Tables("RESULT").Columns("psm_imgpth_M").ReadOnly = False
                        rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_M") = ""
                        rs_POR00005.Tables("RESULT").Columns("psm_imgpth_M").ReadOnly = True
                    End If

                    shpmrkM = imageToByteArray(rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_M"))
                    rs_POR00005.Tables("RESULT").Rows(i)("shpmrkM") = shpmrkM

                    ' Check if the image exists or not
                    If System.IO.File.Exists(rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_S").ToString) = False Then
                        rs_POR00005.Tables("RESULT").Columns("psm_imgpth_S").ReadOnly = False
                        rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_S") = ""
                        rs_POR00005.Tables("RESULT").Columns("psm_imgpth_S").ReadOnly = True
                    End If

                    shpmrkS = imageToByteArray(rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_S"))
                    rs_POR00005.Tables("RESULT").Rows(i)("shpmrkS") = shpmrkS

                    ' Check if the image exists or not
                    If System.IO.File.Exists(rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_I").ToString) = False Then
                        rs_POR00005.Tables("RESULT").Columns("psm_imgpth_I").ReadOnly = False
                        rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_I") = ""
                        rs_POR00005.Tables("RESULT").Columns("psm_imgpth_I").ReadOnly = True
                    End If

                    shpmrkI = imageToByteArray(rs_POR00005.Tables("RESULT").Rows(i)("psm_imgpth_I"))
                    rs_POR00005.Tables("RESULT").Rows(i)("shpmrkI") = shpmrkI
                Next

                rs_POR00005.Tables("RESULT").Columns("compLogo").ReadOnly = True
                rs_POR00005.Tables("RESULT").Columns("shpmrkM").ReadOnly = True
                rs_POR00005.Tables("RESULT").Columns("shpmrkS").ReadOnly = True
                rs_POR00005.Tables("RESULT").Columns("shpmrkI").ReadOnly = True

                Dim objRpt As New POR00005Rpt
                Dim dv As DataView = rs_POR00005.Tables("RESULT").DefaultView
                dv.Sort = "poh_purord, pod_itmno, pod_coldsc, pod_Key, poh_venno, pod_jobord"
                rs_POR00005.Tables.Remove("RESULT")
                rs_POR00005.Tables.Add(dv.ToTable)

                objRpt.Database.Tables("POR00005").SetDataSource(rs_POR00005.Tables("RESULT"))
                objRpt.Database.Tables("POR00005_assortment").SetDataSource(rs_POR00005_assortment.Tables("RESULT"))

                'Add Subreport report source
                objRpt.Subreports.Item("POR00005_shipment.rpt").SetDataSource(rs_POR00005_shipment.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_carton.rpt").SetDataSource(rs_POR00005_carton.Tables("RESULT"))
                'objRpt.Subreports.Item("POR00005_assortment.rpt").SetDataSource(rs_POR00005_assortment.Tables("RESULT"))

                Dim frmReportView As New frmReport
                frmReportView.CrystalReportViewer.ReportSource = objRpt
                frmReportView.Show()
            End If
        Else

        End If

        Cursor = Cursors.Default
    End Sub

    Private Function PackAssortStr() As String
        Dim Assitm As String
        Dim CustItm As String
        Dim colcde As String
        Dim Sku As String
        Dim Upc As String
        Dim Rtl As String

        Assitm = ""
        CustItm = ""
        colcde = ""
        PackAssortStr = ""

        If rs_Assortment.Tables("RESULT").Rows.Count > 0 Then
            PackAssortStr = "Style" + Space(50 - Len("Style")) + _
                            "Unit/Inner/Master" + Space(40 - Len("Unit/Inner/Master")) + _
                            Environment.NewLine
            PackAssortStr = PackAssortStr + "-----" + _
                            Space(50 - Len("-----")) + "-----------------" + _
                            Space(40 - Len("-----------------")) + _
                            Environment.NewLine

            Dim index As Integer = 0

            While index < rs_Assortment.Tables("RESULT").Rows.Count
                If Assitm <> rs_Assortment.Tables("RESULT").Rows(index)("pda_assitm").ToString Or _
                        CustItm <> rs_Assortment.Tables("RESULT").Rows(index)("pda_cusitm").ToString Then
                    If rs_Assortment.Tables("RESULT").Rows(index)("ivi_venitm").ToString <> "" Then
                        PackAssortStr = PackAssortStr + rs_Assortment.Tables("RESULT").Rows(index)("ivi_venitm").ToString + _
                                        Space(50 - Len(rs_Assortment.Tables("RESULT").Rows(index)("ivi_venitm").ToString)) + _
                                        IIf(Val(rs_Assortment.Tables("RESULT").Rows(index)("noofcolor")) <= 1, UnitInnerMaster(index), "") + Environment.NewLine
                    End If

                    If rs_Assortment.Tables("RESULT").Rows(index)("pda_cusitm").ToString <> "" Then
                        PackAssortStr = PackAssortStr + rs_Assortment.Tables("RESULT").Rows(index)("pda_cusitm").ToString + Environment.NewLine
                    End If

                    If rs_Assortment.Tables("RESULT").Rows(index)("pda_assdsc").ToString <> "" Then
                        PackAssortStr = PackAssortStr + rs_Assortment.Tables("RESULT").Rows(index)("pda_assdsc").ToString + Environment.NewLine
                    End If

                    Assitm = rs_Assortment.Tables("RESULT").Rows(index)("pda_assitm")
                    CustItm = rs_Assortment.Tables("RESULT").Rows(index)("pda_cusitm")
                End If

                PackAssortStr = PackAssortStr + ColDesc(index) + Space(50 - Len(ColDesc(index))) + _
                                IIf(Val(rs_Assortment.Tables("RESULT").Rows(index)("noofcolor")) > 1, UnitInnerMaster(index), "") + Environment.NewLine

                Sku = rs_Assortment.Tables("RESULT").Rows(index)("pda_cussku")
                Upc = rs_Assortment.Tables("RESULT").Rows(index)("pda_upcean")
                Rtl = rs_Assortment.Tables("RESULT").Rows(index)("pda_cusrtl")

                index += 1

                If Not index < rs_Assortment.Tables("RESULT").Rows.Count Then
                    If Assitm <> rs_Assortment.Tables("RESULT").Rows(index)("pda_assitm").ToString Then
                        If Sku <> "" Then
                            PackAssortStr = PackAssortStr + "SKU#         :" + Sku + Environment.NewLine
                        End If

                        If Upc <> "" Then
                            If rs_POR00005.Tables("RESULT").Rows(0)("pod_typcode").ToString = "E" Then
                                PackAssortStr = PackAssortStr + "EAN#         :" + Upc + Environment.NewLine
                            Else
                                PackAssortStr = PackAssortStr + "UPC#         :" + Upc + Environment.NewLine
                            End If
                        End If

                        If Rtl <> "" And Rtl <> "0" Then
                            PackAssortStr = PackAssortStr + "Cust.Retail  :" + Rtl + Environment.NewLine
                        End If

                        PackAssortStr = PackAssortStr + "  " + Chr(-23620) + "  " + Environment.NewLine
                    End If
                End If
            End While
        End If

        If Sku <> "" Then
            PackAssortStr = PackAssortStr + "SKU#         :" + Sku + Environment.NewLine
        End If

        If Upc <> "" Then
            If rs_POR00005.Tables("RESULT").Rows(0)("pod_typcode") = "E" Then
                PackAssortStr = PackAssortStr + "EAN#         :" + Upc + Environment.NewLine
            Else
                PackAssortStr = PackAssortStr + "UPC#         :" + Upc + Environment.NewLine
            End If
        End If

        If Rtl <> "" And Rtl <> "0" Then
            PackAssortStr = PackAssortStr + "Cust.Retail  :" + Rtl + Environment.NewLine
        End If
    End Function

    Private Function UnitInnerMaster(ByVal index As Integer) As String
        Dim tmp As String

        tmp = ""

        tmp = Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_pckunt").ToString) + "/" + _
                Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_inrqty").ToString) + "/" + _
                Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_mtrqty").ToString)

        tmp = Trim(tmp) + Space(40 - Len(tmp))
        UnitInnerMaster = tmp
    End Function

    Private Function ColDesc(ByVal index As Integer) As String
        Dim tmp As String

        tmp = ""

        If Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_colcde").ToString) <> "" And _
            Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_coldsc").ToString) = "" Then
            tmp = rs_Assortment.Tables("RESULT").Rows(index)("pda_colcde")
        ElseIf Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_colcde").ToString) = "" And _
            Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_coldsc").ToString) <> "" Then
            tmp = rs_Assortment.Tables("RESULT").Rows(index)("pda_coldsc")
        Else
            tmp = Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_colcde").ToString) + " - " + _
                Trim(rs_Assortment.Tables("RESULT").Rows(index)("pda_coldsc").ToString)
        End If

        ColDesc = Trim(tmp)
    End Function

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