Public Class SAR00005
    Public rs_SAR00005 As DataSet

    Dim CoCde As String
    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub SAR00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)       'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        Call Formstartup(Me.Name)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged
        txtTo.Text = txtFm.Text
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        If txtFm.Text = "" Or txtTo.Text = "" Then
            MsgBox("Invoice No empty !")
            Exit Sub
        End If

        Dim optGroup As String
        optGroup = ""
        If optGroupYes.Checked = True Then
            optGroup = "1"
        Else
            optGroup = "0"
        End If

        Dim PrintAlias As String
        If optAliasYes.Checked = True Then
            PrintAlias = "1"
        Else
            PrintAlias = "0"
        End If


        gspStr = "sp_select_SAR00005 '" & gsCompany & "','" & txtFm.Text & "','" & _
       txtTo.Text & "','" & optGroup & "','" & PrintAlias & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SAR00005, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading rs_SAR00005 cmdShow_Click : " & rtnStr)
            Exit Sub
        End If
        If rs_SAR00005.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            'rs_SAR00005.Tables("RESULT").Columns(13).ColumnName = "@stage"
            'rs_SAR00005.Tables("RESULT").Columns(14).ColumnName = "@fromvenno"
            'rs_SAR00005.Tables("RESULT").Columns(15).ColumnName = "@tovenno"
            'rs_SAR00005.Tables("RESULT").Columns(16).ColumnName = "@fromcredat"
            'rs_SAR00005.Tables("RESULT").Columns(17).ColumnName = "@tocredat"
            'TextBox1.Text = ""
            'For i As Integer = 0 To rs_SAR00005.Tables("RESULT").Columns.Count - 1
            '    TextBox1.Text = TextBox1.Text + rs_SAR00005.Tables("RESULT").Columns(i).ColumnName + " (" + i.ToString + ")= " + rs_SAR00005.Tables("RESULT").Rows(0).Item(i).ToString + vbCrLf
            'Next
            rs_SAR00005.Tables("RESULT").Columns(22).ColumnName = "sod_cuscol"
            rs_SAR00005.Tables("RESULT").Columns(23).ColumnName = "sod_coldsc"
            rs_SAR00005.Tables("RESULT").Columns(44).ColumnName = "pckunt"
            rs_SAR00005.Tables("RESULT").Columns(46).ColumnName = "untcde"
            rs_SAR00005.Tables("RESULT").Columns(47).ColumnName = "sysCy"
            rs_SAR00005.Tables("RESULT").Columns(57).ColumnName = "@yco_conam"
            rs_SAR00005.Tables("RESULT").Columns(58).ColumnName = "@yco_addr"
            rs_SAR00005.Tables("RESULT").Columns(59).ColumnName = "@yco_phoneno"
            rs_SAR00005.Tables("RESULT").Columns(60).ColumnName = "@yco_faxno"
            rs_SAR00005.Tables("RESULT").Columns(48).ColumnName = "ttlamt"
            rs_SAR00005.Tables("RESULT").Columns(49).ColumnName = "sec.cbi_cusnam"
            rs_SAR00005.Tables("RESULT").Columns(50).ColumnName = "discount"
            rs_SAR00005.Tables("RESULT").Columns(51).ColumnName = "netamt"
            rs_SAR00005.Tables("RESULT").Columns(55).ColumnName = "bolDtlRmk"
            rs_SAR00005.Tables("RESULT").Columns(19).ColumnName = "sid_alsitmno"
            rs_SAR00005.Tables("RESULT").Columns(43).ColumnName = "prctrm"
            rs_SAR00005.Tables("RESULT").Columns(54).ColumnName = "memo_sih_shprmk"
            rs_SAR00005.Tables("RESULT").Columns(12).ColumnName = "sih_shprmk"
            rs_SAR00005.Tables("RESULT").Columns(19).ColumnName = "sid_alsitmno"
            rs_SAR00005.Tables("RESULT").Columns(45).ColumnName = "smpunt"
            rs_SAR00005.Tables("RESULT").Columns(56).ColumnName = "memo_sid_rmk"
            rs_SAR00005.Tables("RESULT").Columns(61).ColumnName = "@yco_logoimgpth"

            Dim newColumn As DataColumn
            newColumn = Nothing
            Dim compLogo As Byte() = imageToByteArray(rs_SAR00005.Tables("RESULT").Rows(0)("@yco_logoimgpth"))
            'Dim shpmrkM As Byte() = imageToByteArray(rs_SAR00007.Tables("RESULT").Rows(0)("psm_imgpth_M"))
            newColumn = New DataColumn("compLogo", System.Type.GetType("System.Byte[]"))
            rs_SAR00005.Tables("RESULT").Columns.Add(newColumn)
            rs_SAR00005.Tables("RESULT").Columns("compLogo").ReadOnly = False
            For i As Integer = 0 To rs_SAR00005.Tables("RESULT").Rows.Count - 1
                rs_SAR00005.Tables("RESULT").Rows(i)("compLogo") = compLogo
            Next
            rs_SAR00005.Tables("RESULT").Columns("compLogo").ReadOnly = True



            Dim objRpt As New SAR00005Rpt
            objRpt.SetDataSource(rs_SAR00005.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        End If

        '==========================================================================================
        'S = "㊣SAR00005※S※" & txtFm & "※" & txtTo & "※" & optGroup & "※" & PrintAlias
        'Screen.MousePointer = vbHourglass
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        'Screen.MousePointer = vbDefault
        ''*** An error has occured
        'If rs(0)(0) <> "0" Then
        '    MsgBox(rs(0)(0))
        'Else
        '    rs_SAR00005 = rs(1)
        'End If
        'If rs_SAR00005.recordCount = 0 Then
        '    Screen.MousePointer = vbDefault
        '    MsgBox("No record found !")
        '    Exit Sub
        'Else
        'Rpt_SAR00005 = New SAR00005Rpt
        'Rpt_SAR00005.Database.SetDataSource(rs_SAR00005)
        'frmCR.Report = Rpt_SAR00005
        'frmCR.Show()
        'End If
        '==========================================================================================
        'vb.net example from IMR00018
        'gspStr = "sp_select_IMR00018 '','" & txtRecSts & "','" & Trim(txtFromVenNc.Text) & "','" & _
        ' Trim(txtToVenNc.Text) & "','" & fromdate & "','" & todate & "','" & gsUsrID & "'"

        'Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'rtnLong = execute_SQLStatement(gspStr, rs_IMR00018, rtnStr)

        'Me.Cursor = Windows.Forms.Cursors.Default

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMR00018 #001 sp_select_IMR00018 : " & rtnStr)
        '    Exit Sub
        'End If
        'If rs_IMR00018.Tables("RESULT").Rows.Count = 0 Then
        '    MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        'Else
        '    rs_IMR00018.Tables("RESULT").Columns(13).ColumnName = "@stage"
        '    rs_IMR00018.Tables("RESULT").Columns(14).ColumnName = "@fromvenno"
        '    rs_IMR00018.Tables("RESULT").Columns(15).ColumnName = "@tovenno"
        '    rs_IMR00018.Tables("RESULT").Columns(16).ColumnName = "@fromcredat"
        '    rs_IMR00018.Tables("RESULT").Columns(17).ColumnName = "@tocredat"
        '    Dim objRpt As New IMR00018Rpt
        '    objRpt.SetDataSource(rs_IMR00018.Tables("RESULT"))

        '    Dim frmReportView As New frmReport
        '    frmReportView.CrystalReportViewer.ReportSource = objRpt
        '    frmReportView.Show()
        'End If



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

    Public Sub callbySAM03(ByVal SAIno As String, ByVal ComparyCode As String)
        txtFm.Text = SAIno
        txtTo.Text = SAIno
        CoCde = ComparyCode
        'Hints: In .net, 'Shown' event is called after 'Load' event
        AddHandler Me.Shown, AddressOf callbySAM03AfterLoading
        Me.ShowDialog()
    End Sub

    Private Sub callbySAM03AfterLoading()
        cboCoCde.SelectedItem = CoCde
        txtFm.Enabled = False
        txtTo.Enabled = False
        cboCoCde.Enabled = False
        RemoveHandler Me.Shown, AddressOf callbySAM03AfterLoading
    End Sub
End Class