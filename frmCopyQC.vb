Public Class frmCopyQC
    Public ma As QCM00002

    Private conf_weekshown As Integer = 3
    Dim today As Date = Date.Today

    Private Sub frmCopyQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        today = Date.Today
        FillYearBox()
        'FillWeekBox2(Today.Year)
        FillWeekBox2(cbo_year.SelectedItem)
    End Sub


    Private Sub FillYearBox()
        Dim cur_year As Integer = today.Year
        cbo_year.Items.Add(cur_year)
        cbo_year.SelectedIndex = 0
        'cbo_year.Items.Add(cur_year + 1)

    End Sub


    'Private Sub FillWeekBox(ByVal _year As Integer)
    '    Dim cur_year As Integer = today.Year
    '    Dim flg_from_lastyear As Boolean = False
    '    Dim flg_overlap_nextyear As Boolean = False
    '    cbo_week.Items.Clear()

    '    Dim cur_week As Integer = GetCurrentWeek()

    '    If cur_week = -1 Then
    '        flg_from_lastyear = True
    '    End If

    '    If cur_week <= LastWeekOfYear(_year) And cur_week > LastWeekOfYear(_year) - conf_weekshown + 1 Then
    '        flg_overlap_nextyear = True
    '    End If

    '    If (_year > cur_year) Then
    '        Dim diff As Integer = DateDiff(DateInterval.Day, FirstDateOfWeekISO8601(_year, 1), Today.Date)
    '        If Math.Abs(diff) <= 14 Then
    '            For i As Integer = 0 To 1
    '                cbo_week.Items.Add(gen_WeekString(_year, i + 1))
    '                cbo_week.SelectedIndex = 0
    '            Next
    '        End If
    '        Exit Sub
    '    End If




    '    If flg_from_lastyear Then
    '        Dim _week As Integer = LastWeekOfYear(_year - 1)
    '        cbo_week.Items.Add(gen_WeekString(_year, LastWeekOfYear(_year - 1)))
    '    ElseIf flg_overlap_nextyear Then
    '        Dim week_cnt As Integer = LastWeekOfYear(_year) - cur_week + 1

    '        For i As Integer = 1 To week_cnt
    '            cbo_week.Items.Add(gen_WeekString(_year, LastWeekOfYear(_year) - week_cnt + i))
    '        Next
    '    Else
    '        For i As Integer = 0 To conf_weekshown - 1
    '            cbo_week.Items.Add(gen_WeekString(_year, cur_week + i))
    '        Next
    '    End If
    '    cbo_week.SelectedIndex = 0


    'End Sub

    Private Sub FillWeekBox2(ByVal _year As Integer)
        Dim cur_year As Integer = today.Year
        Dim flg_from_lastyear As Boolean = False
        Dim flg_overlap_nextyear As Boolean = False
        Dim flg_count_as_nextyear As Boolean = False
        cbo_week.Items.Clear()



        Dim cur_week As Integer = GetCurrentWeek()

        If cur_week <= 0 Then
            flg_from_lastyear = True
        End If

        If Not (today.AddDays(3).Year = today.Year) And (today.DayOfWeek = DayOfWeek.Monday Or today.DayOfWeek = DayOfWeek.Tuesday Or today.DayOfWeek = DayOfWeek.Wednesday) Then
            flg_count_as_nextyear = True
        End If


        If cur_week <= LastWeekOfYear(cur_year) And cur_week >= LastWeekOfYear(cur_year) - conf_weekshown + 1 And Not (flg_count_as_nextyear) Then
            flg_overlap_nextyear = True

            cbo_year.Enabled = True
        End If

        ' If (_year > cur_year) Then
        If (_year > cur_year) And flg_overlap_nextyear Then
            Dim diff As Integer = DateDiff(DateInterval.Day, FirstDateOfWeekISO8601(_year, 1), today.Date)
            If Math.Abs(diff) <= 14 And Math.Abs(diff) > 7 Then

                cbo_week.Items.Add(gen_WeekString(_year, 1))
                cbo_week.SelectedIndex = 0
            ElseIf Math.Abs(diff) <= 7 And Math.Abs(diff) > 0 Then
                For i As Integer = 0 To 1
                    cbo_week.Items.Add(gen_WeekString(_year, i + 1))
                    cbo_week.SelectedIndex = 0
                Next
            End If

            Exit Sub
        End If




        If flg_from_lastyear Then
            Dim _week As Integer = LastWeekOfYear(cur_year - 1)
            If cbo_year.Items.Contains(cur_year - 1) = False Then ' add the previous year option
                cbo_year.Items.Add(cur_year - 1)
                cbo_year.Enabled = True
            End If

            'sort the year
            If cbo_year.Items.Count() = 2 And cbo_year.Items.Item(0) > cbo_year.Items.Item(1) Then
                Dim temp As Integer = cbo_year.Items.Item(0)
                cbo_year.Items.Item(0) = cbo_year.Items.Item(1)
                cbo_year.Items.Item(1) = temp
            End If
            If cbo_year.SelectedItem = cur_year Then
                For i As Integer = 0 To conf_weekshown - 2
                    cbo_week.Items.Add(gen_WeekString(cur_year, i + 1))
                Next
            Else
                cbo_week.Items.Add(gen_WeekString(cur_year - 1, LastWeekOfYear(cur_year - 1)))
            End If

            'If cboYear_PanelAdd.SelectedItem = cur_year Then
            '    For i As Integer = 0 To conf_weekshown - 2
            '        WeekCombo.Items.Add(gen_WeekString(cur_year, i + 1))
            '    Next
            'Else
            '    WeekCombo.Items.Add(gen_WeekString(prev_year, LastWeekOfYear(prev_year)))
            'End If
        ElseIf flg_overlap_nextyear Then
            Dim week_cnt As Integer = LastWeekOfYear(_year) - cur_week + 1
            If cbo_year.Items.Contains(cur_year + 1) = False Then ' add the next year option
                cbo_year.Items.Add(cur_year + 1)
            End If

            For i As Integer = 1 To week_cnt
                cbo_week.Items.Add(gen_WeekString(_year, LastWeekOfYear(_year) - week_cnt + i))
            Next
        ElseIf flg_count_as_nextyear Then

            For i As Integer = 0 To conf_weekshown - 1
                cbo_week.Items.Add(gen_WeekString(cur_year + 1, i + 1))
            Next
            If cbo_year.SelectedItem = cur_year Then

                cbo_year.Items.Clear()
                cbo_year.Items.Add(cur_year + 1)
            End If
            cbo_year.SelectedIndex = 0
        Else
            For i As Integer = 0 To conf_weekshown - 1
                cbo_week.Items.Add(gen_WeekString(_year, cur_week + i))
            Next
        End If
        cbo_week.SelectedIndex = 0


    End Sub

    Private Sub cbo_year_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_year.SelectedIndexChanged
        FillWeekBox2(cbo_year.SelectedItem)
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim Hdrtbl As DataTable = ma.rs_QCM00002Hdr.Tables("RESULT")
        Dim Dtltbl As DataTable = ma.rs_QCM00002.Tables("RESULT")
        Dim POtbl As DataTable = ma.rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim QCNo As String = Hdrtbl.Rows(0).Item("qch_qcno")
        Dim Year As String = cbo_year.Text
        Dim Week As String = Split(Split(cbo_week.Text, " - ")(0), " ")(1)

        '20151202 Cancel not allow copy to same week
        'If Hdrtbl.Rows(0).Item("qch_inspweek").ToString = Week Then
        '    MsgBox("Cannot copy QC to same week!")
        '    Exit Sub
        'End If


        'Dim rs_docno As DataSet
        'gspStr = "sp_select_DOC_GEN '" & "','QC','" & gsUsrID & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_docno, rtnStr)

        'If rtnLong <> RC_SUCCESS Then
        '    Cursor = Cursors.Default
        '    MsgBox("Error on loading sp_select_DOC_GEN:" & rtnStr)
        '    Exit Sub
        'End If

        'Dim QCNo_new As String = rs_docno.Tables("RESULT").Rows(0).Item(0).ToString

        'QCREQHDR
        Hdrtbl.Rows(0).Item("qch_ctrlstate") = "ADD"
        Hdrtbl.Rows(0).Item("qch_qcsts") = "OPE"
        Hdrtbl.Rows(0).Item("qch_inspyear") = Year
        Hdrtbl.Rows(0).Item("qch_inspweek") = Week
        Hdrtbl.Rows(0).Item("qch_verno") = 1

        'QCPORDTL
        For i As Integer = 0 To POtbl.Rows.Count - 1
            POtbl.Rows(i).Item("qpd_ctrlstate") = "ADD"
            POtbl.Rows(i).Item("qpd_qcposeq") = i + 1
            POtbl.Rows(i).Item("qpd_del") = ""

        Next



        'QCREQDTL
        For i As Integer = 0 To Dtltbl.Rows.Count - 1
            Dtltbl.Rows(i).Item("qcd_ctrlstate") = "ADD"
            Dtltbl.Rows(i).Item("qcd_qcseq") = i + 1

            Dim PO_row() As DataRow = POtbl.Select("qpd_purord = '" + Dtltbl.Rows(i).Item("qcd_purord") + "'")
            If PO_row.Length = 0 Then
                Dtltbl.Rows(i).Item("qcd_flgpolink") = ""
            Else
                Dtltbl.Rows(i).Item("qcd_qcposeq") = PO_row(0).Item("qpd_qcposeq")
            End If
        Next





        'gspStr = "sp_copy_QC '" & gsCompany & "','" & _
        '    QCNo & "','" & _
        '    QCNo_new & "','" & _
        '    Week & "','" & _
        '    gsUsrID & "'"

        'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)



        ma.save_mode = "ADD"
        ma.saveClick()


        Dim QCNo_new As String = Hdrtbl.Rows(0).Item("qch_qcno")
        Dim puf_ordnoseq As String = QCNo_new + " - 0"

        'POULFILE
        gspStr = "sp_copy_QCAttach '" & QCNo & "','" & QCNo_new & "','" & puf_ordnoseq & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_copy_QCAttach:" & rtnStr)
            Exit Sub
        End If



        Me.Close()
    End Sub
End Class