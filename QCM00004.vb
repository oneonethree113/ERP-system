Public Class QCM00004
    Dim rs_QCM00004 As DataSet
    Dim rs_QCM00004_QCPORDTL As DataSet
    Dim rs_QCM00004_QCPORDTL_seq As DataSet


    Dim dg_HeaderView As DataView
    Dim dg_POHdrView As DataView
    Dim dg_PODtlView As DataView


    Dim tbl_Header As DataTable
    Dim tbl_POHdr As DataTable
    Dim tbl_PODtl As DataTable


    Private Sub QCM00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call FillCompCombo(gsUsrID, cboCocde)
        Call GetDefaultCompany(cboCocde, txtCoNam)

        TabControl1.SelectedIndex = 0
        TabControl1.TabPages(0).Enabled = True
        TabControl1.TabPages(1).Enabled = False
        'TabControl1.TabPages(2).Enabled = False

        Dim today As Date = New Date()

        FillYearBox()
        'txt_WeekFm.Text = GetCurrentWeek()
        'txt_WeekTo.Text = GetCurrentWeek()
        FillInspBox()
        FillStatusBox()


        AddSearchBtnHandler()


        mmdAdd.Enabled = False
        mmdSave.Enabled = False
        mmdDelete.Enabled = False
        mmdCopy.Enabled = False
        mmdFind.Enabled = False
        mmdExit.Enabled = True
        mmdClear.Enabled = True
        mmdSearch.Enabled = False
        mmdInsRow.Enabled = False
        mmdDelRow.Enabled = False
        mmdPrint.Enabled = False
        mmdAttach.Enabled = False
        mmdFunction.Enabled = False
        mmdLink.Enabled = False
        StatusBar.Items("lblLeft").Text = "Init"
    End Sub


    Private Function Convert_Insptype(ByVal insptype As String) As String
        Dim ret As String
        Select Case insptype
            Case "ALL"
                ret = "ALL"
            Case "Pre-Pro"
                ret = "P"
            Case "PP Meeting"
                ret = "PP"
            Case "In-Line"
                ret = "M"
            Case "Customer In-Line"
                ret = "CM"
            Case "Customer In-line with QC"
                ret = "DCM"
            Case "Final"
                ret = "F"
            Case "Customer Final"
                ret = "CF"
            Case "Customer Final with QC"
                ret = "DCF"
            Case Else
                ret = "E"
        End Select

        Return ret
    End Function


#Region "Tabpage - Search"
    Dim textboxlist As New Collection() 'a dictionary storing the index and the textbox object
    Private Sub AddSearchBtnHandler()
        textboxlist.Add(txt_S_PriCustAll, "cmd_S_PriCustAll")
        textboxlist.Add(txt_S_SecCustAll, "cmd_S_SecCustAll")
        textboxlist.Add(txt_S_PV, "cmd_S_PV")

        AddHandler cmd_S_PriCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_SecCustAll.Click, AddressOf cmd_S_Click
        AddHandler cmd_S_PV.Click, AddressOf cmd_S_Click

    End Sub

    Private Sub cmd_S_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim trigger_btn As Button = CType(sender, Button)
        Dim btn_name As String = trigger_btn.Name
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = textboxlist(btn_name).Name
        frmComSearch.callFmString = textboxlist(btn_name).Text
        frmComSearch.show_frmS(trigger_btn)
    End Sub

    Private Sub FillYearBox()
        cbo_inspyear.Items.Clear()
        Dim cur_year As Integer = Date.Today.Year
        cbo_inspyear.Items.Add(cur_year - 1)
        cbo_inspyear.Items.Add(cur_year)
        cbo_inspyear.Items.Add(cur_year + 1)
        cbo_inspyear.SelectedIndex = 1
    End Sub

    Private Sub FillInspBox()
        cbo_insptype.Items.Clear()
        cbo_insptype.Items.Add("ALL")
        cbo_insptype.Items.Add("Pre-Pro")
        cbo_insptype.Items.Add("PP Meeting")
        cbo_insptype.Items.Add("In-Line")
        'cbo_insptype.Items.Add("Customer In-Line")
        cbo_insptype.Items.Add("Customer In-line with QC")
        cbo_insptype.Items.Add("Final")
        'cbo_insptype.Items.Add("Customer Final")
        cbo_insptype.Items.Add("Customer Final with QC")

        cbo_insptype.SelectedIndex = 0
    End Sub

    Private Sub FillStatusBox()
        cbo_status.Items.Clear()
        cbo_status.Items.Add("ALL")
        cbo_status.Items.Add("OPE")
        cbo_status.Items.Add("REL")
        cbo_status.Items.Add("CAN")

        cbo_status.SelectedIndex = 0
    End Sub


    Private Sub txtWeekFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_WeekFm.TextChanged
        txt_WeekTo.Text = txt_WeekFm.Text

    End Sub


    Private Sub txtWeekTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_WeekTo.TextChanged
    End Sub


    Private Sub cboCocde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCocde.KeyUp
        auto_search_combo(cboCocde)
    End Sub

    Private Sub cboCocde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocde.SelectedIndexChanged
        If cboCocde.Text = "UC-G" Then
            txtCoNam.Text = "UNITED CHINESE GROUP"
        Else
            txtCoNam.Text = ChangeCompany(cboCocde.Text, Me.Name)
        End If

    End Sub

#End Region

#Region "Function - Search"
  

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        If QC_Find() Then

            TabControl1.SelectedIndex = 1
            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = True
            'TabControl1.TabPages(2).Enabled = True

            SetupStyle_dg()
        End If
    End Sub

#End Region

    Dim view_header_arr As String() = { _
        "qch_qcno", _
        "qch_qcsts", _
        "view_vensna", _
        "view_pricust", _
        "view_seccust", _
        "qch_inspyear", _
        "qch_inspweek", _
        "view_inspweek", _
        "view_insptyp", _
 _
        "qch_mon", _
        "qch_tue", _
        "qch_wed", _
        "qch_thur", _
        "qch_fri", _
        "qch_sat", _
        "qch_sun" _
    }

    'Dim view_POHdr_arr As String() = { _
    '    "qcd_purord" _
    '}

    'Dim view_PODtl_arr As String() = { _
    '    "qcd_purord", _
    '    "qcd_purseq" _
    '}





    Private Sub SetupStyle_dg()
        'dg_DetailView = New DataView(rs_QCM00004.Tables("RESULT"))
        'tbl_Detail = dg_DetailView.ToTable(False, view_detail_arr)

        dg_HeaderView = New DataView(rs_QCM00004.Tables("RESULT"))
        tbl_Header = dg_HeaderView.ToTable(True, view_header_arr)
        dg_Header.DataSource = tbl_Header.DefaultView

        For i As Integer = 0 To tbl_Header.Columns.Count - 1
            tbl_Header.Columns(i).ReadOnly = False
        Next

        For i As Integer = 0 To tbl_Header.Rows.Count - 1
            Dim firstdate As Date = FirstDateOfWeekISO8601(tbl_Header.Rows(i).Item("qch_inspyear"), tbl_Header.Rows(i).Item("qch_inspweek"))
            'firstdate.ToString("MM/dd")

            tbl_Header.Rows(i).Item("view_inspweek") = tbl_Header.Rows(i).Item("qch_inspweek").ToString() + " [" + firstdate.ToString("MM/dd") + "-" + firstdate.AddDays(6).ToString("MM/dd") + "]"
            'tbl_Header.Rows(i).Item("view_inspweek") = 
        Next


        'dg_POHdrView = New DataView(rs_QCM00004.Tables("RESULT"))
        'tbl_POHdr = dg_POHdrView.ToTable(True, view_POHdr_arr)
        'dg_POHdr.DataSource = tbl_POHdr.DefaultView

        'For i As Integer = 0 To tbl_POHdr.Columns.Count - 1
        '    tbl_POHdr.Columns(i).ReadOnly = False
        'Next


        'dg_PODtlView = New DataView(rs_QCM00004.Tables("RESULT"))
        'tbl_PODtl = dg_PODtlView.ToTable(True, view_PODtl_arr)
        'dg_PODtl.DataSource = tbl_PODtl.DefaultView

        'For i As Integer = 0 To tbl_PODtl.Columns.Count - 1
        '    tbl_PODtl.Columns(i).ReadOnly = False
        'Next


        With dg_Header
            .Columns("qch_qcno").HeaderText = "QCNo"
            .Columns("qch_qcsts").HeaderText = "QCStatus"
            .Columns("view_vensna").HeaderText = "Vendor"
            .Columns("view_pricust").HeaderText = "Pri. Cust"
            .Columns("view_seccust").HeaderText = "Sec. Cust"
            .Columns("qch_inspyear").HeaderText = "Insp. Year"
            .Columns("view_inspweek").HeaderText = "Insp. Week"
            .Columns("view_insptyp").HeaderText = "Insp. Type"

            .Columns("qch_mon").HeaderText = "Mon"
            .Columns("qch_tue").HeaderText = "Tue"
            .Columns("qch_wed").HeaderText = "Wed"
            .Columns("qch_thur").HeaderText = "Thur"
            .Columns("qch_fri").HeaderText = "Fri"
            .Columns("qch_sat").HeaderText = "Sat"
            .Columns("qch_sun").HeaderText = "Sun"




            .Columns("qch_qcno").Width = 80
            .Columns("qch_qcsts").Width = 60
            .Columns("view_vensna").Width = 120
            .Columns("view_pricust").Width = 120
            .Columns("view_seccust").Width = 80
            .Columns("qch_inspyear").Width = 40
            .Columns("qch_inspweek").Visible = False
            .Columns("view_inspweek").Width = 100
            .Columns("view_insptyp").Width = 50

            .Columns("qch_mon").Width = 35
            .Columns("qch_tue").Width = 35
            .Columns("qch_wed").Width = 35
            .Columns("qch_thur").Width = 35
            .Columns("qch_fri").Width = 35
            .Columns("qch_sat").Width = 35
            .Columns("qch_sun").Width = 35
        End With

        'With dg_POHdr
        '    .Columns("qcd_purord").Width = 80
        '    .Columns("qcd_purord").HeaderText = "PO No"
        'End With

        'With dg_PODtl
        '    .Columns("qcd_purord").Width = 80
        '    .Columns("qcd_purseq").Width = 60

        '    .Columns("qcd_purord").HeaderText = "PO No"
        '    .Columns("qcd_purseq").HeaderText = "PO Seq"

        'End With

    End Sub

#Region "Function - Core"
    Private Function QC_Find() As Boolean
        QC_Find = False

        If Not QC_Find_Check() Then
            Exit Function
        End If

        gspStr = "sp_select_QCM00004 '" & gsCompany & "','" & _
            txt_S_PriCustAll.Text & "','" & _
            txt_S_SecCustAll.Text & "','" & _
            txt_S_PV.Text & "','" & _
            cbo_inspyear.Text & "','" & _
            txt_WeekFm.Text & "','" & _
            txt_WeekTo.Text & "','" & _
            Convert_Insptype(cbo_insptype.Text) & "','" & _
            cbo_status.Text & "','" & _
            gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_QCM00004, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QCM00004:" & rtnStr)
            Exit Function
        End If

        If rs_QCM00004.Tables(0).Rows.Count = 0 Then
            MsgBox("No Records found OR No Access Rights!")
            Exit Function
        End If

        StatusBar.Items("lblLeft").Text = "ReadOnly"

        Me.StatusBar.Items("lblRight").Text = ""
        Dim dv2 As DataView = rs_QCM00004.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "qcd_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("qcd_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("qcd_upddat"), "MM/dd/yyyy") & " " & drv.Item("qcd_updusr")

            dv2.Sort = Nothing
        End If

        QC_Find = True
    End Function

    Private Function QC_Find_Check() As Boolean
        QC_Find_Check = False

        Dim weekfm As Integer
        Dim weekto As Integer
        If txt_WeekFm.Text <> "" And Not Int32.TryParse(txt_WeekFm.Text, weekfm) Then
            MsgBox("Invalid Week From!")
            Exit Function
        End If

        If txt_WeekTo.Text <> "" And Not Int32.TryParse(txt_WeekTo.Text, weekto) Then
            MsgBox("Invalid Week To!")
            Exit Function
        End If


        If weekto < weekfm Then
            MsgBox("Week To < Week From!")
            txt_WeekFm.Focus()
            Exit Function
        End If


        QC_Find_Check = True
    End Function


#End Region

    Private Sub dg_Header_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_Header.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim QCNo As String = dg_Header.Rows(e.RowIndex).Cells("qch_qcno").Value.ToString

            Load_QCM00002(QCNo)

        End If
    End Sub


    'Private Sub dg_POHdr_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.RowIndex >= 0 Then
    '        Dim PONo As String = dg_POHdr.Rows(e.RowIndex).Cells("qcd_purord").Value.ToString
    '        Load_QCM00009(PONo, "hdr")
    '    End If
    'End Sub


    'Private Sub dg_PODtl_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.RowIndex >= 0 Then
    '        Dim PONo As String = dg_POHdr.Rows(e.RowIndex).Cells("qcd_purord").Value.ToString
    '        Load_QCM00009(PONo, "dtl")
    '    End If
    'End Sub

#Region "Function - InitQCM00002"
    Private Sub Load_QCM00002(ByVal QCNo As String)
        Dim frm_QCM00002 As QCM00002 = New QCM00002
        frm_QCM00002.ma_QCM00004 = Me
        frm_QCM00002.txtQCno.Text = QCNo
        frm_QCM00002.ShowDialog()

        'frm_QCM00002.QCFind(QCNo)
    End Sub
#End Region

#Region "Function - InitQCM00009"
    Private Sub Load_QCM00009(ByVal PONo As String, ByVal opt As String)
        Dim frm_QCM00009 As QCM00009 = New QCM00009

        frm_QCM00009.ma_QCM00004 = Me

        frm_QCM00009.GroupBox1.Enabled = False
        frm_QCM00009.grpSC.Enabled = False
        frm_QCM00009.txtSCFm.Text = PONo
        frm_QCM00009.txtSCTo.Text = PONo

        If opt = "hdr" Then
            frm_QCM00009.Opt_H.Checked = True
        ElseIf opt = "dtl" Then
            frm_QCM00009.Opt_P.Checked = True
        End If

        frm_QCM00009.ShowDialog()



    End Sub
#End Region

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim answer As Integer = MsgBox("All Unsave data will be clear. Are you srue?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then

            TabControl1.SelectedIndex = 0
            TabControl1.TabPages(0).Enabled = True
            TabControl1.TabPages(1).Enabled = False
            'TabControl1.TabPages(2).Enabled = False

            dg_Header.DataSource = ""
            'dg_PODtl.DataSource = ""
            'dg_POHdr.DataSource = ""
        End If
    End Sub


    Private Sub txt_DateFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_DateFm.TextChanged
        txt_DateTo.Text = txt_DateFm.Text
    End Sub

    Private Sub txt_DateFm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DateFm.Validating
        Dim tmpstr As String
        tmpstr = txt_DateFm.Text

        If tmpstr = "  /  /" Then
            Exit Sub
        End If

        If Not IsDate(tmpstr) Then
            MsgBox("Not a valid date!")
            txt_DateFm.Focus()
        Else
            Dim tmpdate As Date = CDate(txt_DateFm.Text)

            If cbo_inspyear.Text <> tmpdate.Year Then
                MsgBox("Year not matched")
                txt_DateFm.Focus()
                Exit Sub
            End If

            Dim Week As Integer = GetWeekByDate(tmpdate)
            txt_WeekFm.Text = Week
        End If
    End Sub



    Private Sub txt_DateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DateTo.Validating
        Dim tmpstr As String
        tmpstr = txt_DateTo.Text

        If tmpstr = "  /  /" Then
            Exit Sub
        End If

        If Not IsDate(tmpstr) Then
            MsgBox("Not a valid date!")
            txt_DateTo.Focus()
        Else
            Dim tmpdate As Date = CDate(txt_DateTo.Text)

            If cbo_inspyear.Text <> tmpdate.Year Then
                MsgBox("Year not matched")
                txt_DateTo.Focus()
                Exit Sub
            End If

            Dim Week As Integer = GetWeekByDate(tmpdate)
            txt_WeekTo.Text = Week
        End If
    End Sub




    Private Sub cbo_inspyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_inspyear.SelectedIndexChanged
        txt_DateFm.Text = "  /  /"
        txt_DateTo.Text = "  /  /"
    End Sub

End Class