Imports System.IO


Public Class SHM00001_3
    Public rs_SHDTLCTN_Sub As New DataSet
    Dim total As Integer
    Dim dup(50) As String
    Public sReadingIndexC As String = 0
    Public ma As SHM00001

    Private Sub cmdCancel_Click()
    End Sub

    Private Sub cmdDelRow_Click()
    End Sub

    Private Sub cmdInsRow_Click()

    End Sub

    Private Sub cmdOK_Click()
    End Sub

    Function SHCartonSC() As Boolean
        Dim Flag_inRange As Boolean
        Dim Flag_EachRow As Boolean

        Dim rs As DataSet
        Dim msg As String

        Flag_EachRow = False
        Flag_inRange = False
        msg = ""

        rs = ma.rs_SCDTLCTN
        If rs.Tables("RESULT").Rows.Count <= 0 Or rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count <= 0 Then
            Flag_inRange = True
            SHCartonSC = True
            Exit Function
        End If

        For i As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
            For j As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count - 1
                If rs.Tables("RESULT").Rows(i)("sdc_from") <= rs_SHDTLCTN_Sub.Tables("RESULT").Rows(j)("hdc_from") And _
                    rs.Tables("RESULT").Rows(i)("sdc_to") >= rs_SHDTLCTN_Sub.Tables("RESULT").Rows(j)("hdc_to") Then
                    Flag_inRange = True
                End If
            Next
            Flag_EachRow = Flag_inRange
            If Flag_EachRow = False Then GoTo NotMatch
            Flag_inRange = False
        Next


        'rs_SHDTLCTN_Sub.MoveFirst()
        'For i As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1  '
        '    rs.MoveFirst()
        '    While Not rs.EOF
        '        If rs("sdc_from") <=  rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("hdc_from") And _
        '            rs("sdc_to") >=  rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("hdc_to") Then
        '            Flag_inRange = True
        '        End If
        '        rs.MoveNext()
        '    End While
        '    Flag_EachRow = Flag_inRange
        '    If Flag_EachRow = False Then GoTo NotMatch
        '    Flag_inRange = False
        '    rs_SHDTLCTN_Sub.MoveNext()
        'End While



NotMatch:
        If Not Flag_EachRow Then
            msg = "Carton Seq. don't match with SC Carton Seq. OK?" + Chr(13) + "========================================" + Chr(13) + Chr(13)

            Dim s1 As String
            Dim s2 As String
            For i As Integer = 0 To 20 - Len(Str(rs.Tables("RESULT").Rows(i)("sdc_from"))) - 1
                s1 = s1 + " "
            Next
            For i As Integer = 0 To 20 - Len(Str(rs.Tables("RESULT").Rows(i)("sdc_to"))) - 1
                s2 = s2 + " "
            Next

            For i As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
                msg = msg + s1 + Str(rs.Tables("RESULT").Rows(i)("sdc_from")) + "                   to " + s2 + Str(rs.Tables("RESULT").Rows(i)("sdc_to")) + Chr(13)
            Next

        End If


        If Not Flag_EachRow Then
            If MsgBox(msg, vbYesNo, "System Message") = vbYes Then
                SHCartonSC = True
            Else
                SHCartonSC = False
            End If
        Else
            SHCartonSC = True
        End If
    End Function

    Private Sub Form_Load()
    End Sub

    Private Sub Display()

        If rs_SHDTLCTN_Sub.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        grdSHCarton.DataSource = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView

        Dim i As Integer
        For i = 0 To grdSHCarton.Columns.Count - 1
            grdSHCarton.Columns(i).Width = 0
            grdSHCarton.Columns(i).Visible = False
        Next

        With grdSHCarton

            .Columns(0).Width = 420 / 12
            .Columns(0).HeaderText = "Del"
            .Columns(0).Visible = True
            '.Columns(0).Locked = True
            '''
            '.Columns(0).Button = True

            '.Columns(1).Width = 0
            '.Columns(2).Width = 0
            '.Columns(3).Width = 0
            '.Columns(4).Width = 0

            .Columns(5).Width = 2500 / 12
            .Columns(5).HeaderText = "From"
            .Columns(5).Visible = True

            .Columns(6).Width = 2500 / 12
            .Columns(6).HeaderText = "To"
            .Columns(6).Visible = True

            .Columns(7).Width = 3580 / 12
            '.Columns(7).Locked = True
            .Columns(7).HeaderText = "Number of Carton"
            .Columns(7).Visible = True


            '.Columns(8).Width = 0 'Creusr
            '.Columns(9).Width = 0
            '.Columns(10).Width = 0
            '.Columns(11).Width = 0
            '.Columns(12).Width = 0

        End With
    End Sub



    Private Sub grdSHCarton_AfterColUpdate(ByVal ColIndex As Integer)
    End Sub

    Private Sub cal_Total()
        total = 0
        If rs_SHDTLCTN_Sub.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count > 0 Then

            For i As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1
                If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(i)("DEL") <> "Y" Then
                    total = total + rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(i)("hdc_ttlctn")
                End If
            Next
        End If

        txtTotal.Text = total
    End Sub

    Private Sub grdSHCarton_ButtonClick(ByVal ColIndex As Integer)
        If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then
            Select Case ColIndex
                Case 0
                    Call grdSHCarton_DblClick()
            End Select
        End If
    End Sub
    Private Sub grdSHCarton_DblClick()
        'If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then
        '    'If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 And Not rs_SHDTLCTN_Sub.EOF Then

        '    If grdSHCarton.col = 0 Then
        '        If rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("DEL") = "Y" Then
        '            grdSHCarton.Columns(0).Text = " "

        '            If rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("hdc_creusr") = "~*NEW*~" Then
        '                rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("hdc_creusr") = "~*ADD*~"
        '            Else
        '                rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("hdc_creusr") = "~*UPD*~"
        '            End If
        '            Call cal_Total()
        '        End If

        '    End If

        'End If

    End Sub


    Private Sub grdSHCarton_KeyDown(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'If KeyCode = vbKeyV And Shift = 2 Then
        '    KeyCode = 0
        'ElseIf KeyCode = vbKeyInsert And Shift = 1 Then
        '    KeyCode = 0
        'End If
    End Sub



    Private Sub grdSHCarton_KeyPress(ByVal KeyAscii As Integer)
        'If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then
        '    On Error Resume Next

        '    If grdSHCarton.col = 5 Then
        '        If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '            KeyAscii = 0
        '        ElseIf (Len(grdSHCarton.Columns(5).Text) + 1 > 9) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '            KeyAscii = 0
        '        End If
        '    ElseIf grdSHCarton.col = 6 Then
        '        If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '            KeyAscii = 0
        '        ElseIf (Len(grdSHCarton.Columns(6).Text) + 1 > 9) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '            KeyAscii = 0
        '        End If

        '    End If
        '    If KeyAscii = 32 Then
        '        grdSHCarton_ButtonClick(grdSHCarton.col)
        '    End If
        'End If
    End Sub

    Function SHCartonVaild() As Boolean
        'Dim book As Integer
        'temp
        Dim rs_SHDTLCTN_Sub2 As DataSet

        rs_SHDTLCTN_Sub2 = rs_SHDTLCTN_Sub.Copy

        SHCartonVaild = True

        Dim i As Integer, X As Integer
        X = 1
        If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then
            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "' and DEL = ' ' "
            If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then

                If txtTotal.Text <> ma.txtTtlCtnD.Text Then
                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
                    ma.txtCtnStr.Enabled = False
                    ma.txtCtnEnd.Enabled = False
                    MsgBox("The total carton number is incorrect!")
                    SHCartonVaild = False
                    If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
                    Exit Function
                End If


                rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
                rs_SHDTLCTN_Sub2.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
                For index9 As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1
                    For index99 As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1
                        If index9 <> index99 Then
                            ''                        If Not IsDBNull(rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index9)("hdc_ctnseq")) And Not IsDBNull(rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index99)("hdc_ctnseq")) Then
                            ''If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index9)("hdc_ctnseq") <> rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index99)("hdc_ctnseq") Then
                            If ((rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index9)("hdc_from") >= rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index99)("hdc_from") _
                            And rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index9)("hdc_from") <= rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index99)("hdc_to") Or _
                             (rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index9)("hdc_to") >= rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index99)("hdc_from") _
                            And rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index9)("hdc_to") <= rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index99)("hdc_to")))) _
                            And (rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index9)("del") <> "Y" And rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(index99)("del") <> "Y") Then
                                MsgBox("The total carton number range is overlapped with each other!")
                                SHCartonVaild = False
                                If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()

                                Exit Function
                            End If

                            ''End If

                            ''End If


                        End If
                    Next
                Next
                'cross check


            End If
        End If

    End Function

    'Function SHCartonVaild() As Boolean
    '    'Dim book As Integer
    '    Dim i As Integer, X As Integer
    '    X = 1
    '    If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then

    '        rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "' and DEL = ' ' "

    '        If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then


    '            If txtTotal.Text <> ma.txtTtlCtnD.Text Then

    '                rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '                ma.txtCtnStr.Enabled = False
    '                ma.txtCtnEnd.Enabled = False
    '                MsgBox("M00332")
    '                SHCartonVaild = False
    '                If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
    '                Exit Function
    '            End If
    '        Else

    '            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '            SHCartonVaild = True

    '            If GetCtrlValue(ma.cboShpSts) = "REL" Or GetCtrlValue(ma.cboShpSts) = "CLO" Then
    '                ma.txtCtnStr.Enabled = False
    '                ma.txtCtnEnd.Enabled = False
    '            Else
    '                ma.txtCtnStr.Enabled = True
    '                ma.txtCtnEnd.Enabled = True
    '            End If

    '            Exit Function
    '        End If

    '        rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"

    '        'rs_SHDTLCTN_Sub.MoveFirst()
    '        'book = rs_SHDTLCTN_Sub.AbsolutePosition

    '        For i As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1

    '        Next
    '        '
    '        'book = rs_SHDTLCTN_Sub.AbsolutePosition

    '        rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_from <= '" & rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("hdc_from") & "' and hdc_to >= '" & _
    '                                 rs_SHDTLCTN_Sub.Tables("RESULT").Rows(i)("hdc_from") & "' and DEL = ' ' and " & _
    '                                "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"


    '        If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 1 Then

    '            'rs_SHDTLCTN_Sub.MoveFirst()

    '            'Erase dup
    '            'For i = 1 To rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count
    '            '    dup(i) = rs_SHDTLCTN_Sub.Bookmark
    '            '    'rs_SHDTLCTN_Sub.MoveNext()
    '            'Next

    '            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '            grdSHCarton.DataSource = rs_SHDTLCTN_Sub

    '            Call Display()

    '            'rs_SHDTLCTN_Sub.MoveFirst()

    '            'While dup(X) <> ""
    '            '    grdSHCarton.SelBookmarks.Add(dup(X) + 1 - 1)
    '            '    X = X + 1
    '            'NEXT

    '            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"

    '            MsgBox("M00333")

    '            SHCartonVaild = False
    '            If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
    '            Exit Function
    '        Else
    '            ma.txtCtnStr.Enabled = False
    '            ma.txtCtnEnd.Enabled = False
    '            SHCartonVaild = True
    '            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '            'rs_SHDTLCTN_Sub.AbsolutePosition = book
    '        End If

    '        'rs_SHDTLCTN_Sub.MoveNext()
    '        NEXT

    '        grdSHCarton.DataSource = rs_SHDTLCTN_Sub
    '        Call Display()

    '        SHCartonVaild = True
    '    Else
    '        If GetCtrlValue(ma.cboShpSts) = "REL" Or GetCtrlValue(ma.cboShpSts) = "CLO" Then
    '            ma.txtCtnStr.Enabled = False
    '            ma.txtCtnEnd.Enabled = False
    '        Else
    '            ma.txtCtnStr.Enabled = True
    '            ma.txtCtnEnd.Enabled = True
    '        End If
    '        SHCartonVaild = True
    '    End If
    'End Function

    Private Sub Sub_total()
        If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If
        rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(sReadingIndexC)("hdc_ttlctn") = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(sReadingIndexC)("hdc_to") - rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(sReadingIndexC)("hdc_from") + 1


    End Sub


    'Function SHCartonVaildFromTo() As Boolean
    '    Dim i As Integer, X As Integer
    '    SHCartonVaildFromTo = True

    '    'X = 1
    '    'If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then

    '    '    For index As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count - 1

    '    '        rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_ttlctn <= 0 and DEL = ' ' and " & _
    '    '                "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '    '        '''
    '    '        If rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count > 0 Then
    '    '            For i As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1

    '    '            Next

    '    '            Erase dup

    '    '            For i = 1 To rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count
    '    '                dup(i) = rs_SHDTLCTN_Sub.Bookmark
    '    '                rs_SHDTLCTN_Sub.MoveNext()
    '    '            Next

    '    '            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '    '            grdSHCarton.DataSource = rs_SHDTLCTN_Sub
    '    '            Call Display()
    '    '            rs_SHDTLCTN_Sub.MoveFirst()
    '    '            While dup(X) <> ""
    '    '                grdSHCarton.SelBookmarks.Add(dup(X) + 1 - 1)


    '    '                X = X + 1
    '    '            End While
    '    '            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '    '            MsgBox("M00334")
    '    '            SHCartonVaildFromTo = False
    '    '            If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
    '    '            Exit Function
    '    '        Else
    '    '            SHCartonVaildFromTo = True
    '    '            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '    '            rs_SHDTLCTN_Sub.AbsolutePosition = book
    '    '        End If


    '    '    Next

    '    '    For i As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1
    '    '        rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_ttlctn <= 0 and DEL = ' ' and " & _
    '    '                                "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "'"
    '    '    Next
    '    '    '

    '    '    grdSHCarton.DataSource = rs_SHDTLCTN_Sub
    '    '    Call Display()

    '    '    SHCartonVaildFromTo = True
    '    'Else
    '    '    SHCartonVaildFromTo = True
    '    'End If
    'End Function




    Private Function GetCtrlValue(ByVal Ctrl As Control) As String
        If TypeOf Ctrl Is ComboBox Then
            If Ctrl.Text <> "" Then
                If UBound(Split(Ctrl.Text, " - ")) > 0 Then
                    GetCtrlValue = Split(Ctrl.Text, " - ")(0)
                Else
                    GetCtrlValue = Ctrl.Text
                End If
            Else
                GetCtrlValue = ""
            End If
        ElseIf TypeOf Ctrl Is ListBox Then
            'If Ctrl.List(Ctrl.ListIndex) <> "" Then
            '    If UBound(Split(Ctrl.List(Ctrl.ListIndex), " - ")) > 0 Then
            '        GetCtrlValue = Split(Ctrl.List(Ctrl.ListIndex), " - ")(0)
            '    Else
            '        GetCtrlValue = Ctrl.List(Ctrl.ListIndex)
            '    End If
            'Else
            '    GetCtrlValue = ""
            'End If
        End If
    End Function




    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        If rs_SHDTLCTN_Sub.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        Dim index As Integer
        Dim max_ctnseqno As Integer

        max_ctnseqno = 0
        For i As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1
            If max_ctnseqno <= rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(i)("hdc_ctnseq") Then
                max_ctnseqno = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(i)("hdc_ctnseq")
            End If
        Next
        max_ctnseqno = max_ctnseqno + 1

        '   rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_ttlctn = 0"
        index = rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count

        '      If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count >= 0 Then
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Add()
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("DEL") = "N"
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_shpno") = ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpno")
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_shpseq") = ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq")

        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_ctnseq") = max_ctnseqno

        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_from") = 1
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_to") = 1
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_ttlctn") = 1
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_creusr") = "~*ADD*~"
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_credat") = Format(Date.Today, "MM/dd/yyyy").ToString
        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(index)("hdc_upddat") = Format(Date.Today, "MM/dd/yyyy").ToString
        Call Sub_total()
        Call cal_Total()

        ''    grdSHCarton.ColumnCount = 5
        ''?
        If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()

        'Else
        'MsgBox("Please input data.")
        'If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
        'End If
        grdSHCarton.DataSource = rs_SHDTLCTN_Sub.Tables("RESULT")

        Call Display()

    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click

        If Not rs_SHDTLCTN_Sub.Tables("RESULT").Rows.Count = 0 Then
            '
            If rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("DEL") = "Y" Then
                If rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") <> "~*ADD*~" Then

                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") = "~*UPD*~"
                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("DEL") = "N"

                ElseIf rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") = "~*ADD*~" Then

                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") = "~*NEW*~"
                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("DEL") = "N"

                End If
                Call cal_Total()


                '
                ''                grdSHCarton.col = 0
                'Call grdSHCarton_DblClick()
                ''              rs_SHDTLCTN_Sub.AbsolutePosition = book
                ''            grdSHCarton.col = 5
                If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
                '
            Else
                If rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") <> "~*ADD*~" Then

                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") = "~*DEL*~"
                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("DEL") = "Y"

                ElseIf rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") = "~*ADD*~" Then

                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("hdc_creusr") = "~*NEW*~"
                    rs_SHDTLCTN_Sub.Tables("RESULT").Rows(sReadingIndexC)("DEL") = "Y"

                End If
                Call cal_Total()

                'rs_SHDTLCTN_Sub.AbsolutePosition = book
                'grdSHCarton.col = 5
                If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
            End If
        Else
            MsgBox("M00065")
        End If


    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ma.Recordstatus_Dtl = False
        Me.Close()

    End Sub

    Private Sub grdSHCarton_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSHCarton.CellClick
        sReadingIndexC = e.RowIndex

        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            If grdSHCarton.Columns(e.ColumnIndex).ReadOnly = False Then
                If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("Del").ToString = "Y" Then
                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "N"

                    If rs_SHDTLCTN_Sub.Tables("RESULT").Rows(e.RowIndex).Item("hdc_creusr") <> "~*ADD*~" And rs_SHDTLCTN_Sub.Tables("RESULT").Rows(e.RowIndex).Item("hdc_creusr") <> "~*NEW*~" Then
                        rs_SHDTLCTN_Sub.Tables("RESULT").Rows(e.RowIndex).Item("hdc_creusr") = "~*UPD*~"
                    End If

                Else
                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "Y"
                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("hdc_creusr") = "~*DEL*~"

                End If
                rs_SHDTLCTN_Sub.Tables("RESULT").AcceptChanges()
            End If
        End If




    End Sub

    Private Sub grdSHCarton_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSHCarton.CellContentClick



    End Sub

    Private Sub grdSHCarton_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSHCarton.CellEndEdit
        If sReadingIndexC < 0 Then
            Exit Sub

        End If
        If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(sReadingIndexC)("hdc_creusr") <> "~*ADD*~" And _
           rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(sReadingIndexC)("hdc_creusr") <> "~*DEL*~" And _
           rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(sReadingIndexC)("hdc_creusr") <> "~*NEW*~" Then
            rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(sReadingIndexC)("hdc_creusr") = "~*UPD*~"

        End If
        Select Case e.ColumnIndex

            Case 5
                If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("hdc_from").ToString = "" Then
                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("hdc_from") = "1"
                End If

                'If grdSHCarton.Columns(5).ToString Then = "" Then
                '    'grdSHCarton.col = 0
                '    grdSHCarton.Columns(5) = 1
                'End If


            Case 6
                If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("hdc_to").ToString = "" Then
                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(e.RowIndex)("hdc_to") = "1"
                End If

                'If grdSHCarton.Columns(6).ToString = "" Then
                '    'grdSHCarton.col = 5
                '    grdSHCarton.Columns(6) = grdSHCarton.Columns(5) + 1

                'End If

        End Select
        Call Sub_total()
        Call cal_Total()
        'rs_SHDTLCTN_Sub.AbsolutePosition = book
        If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.Focus()
 

        'Call cal_Total()
        ' Call Display()

        ma.Recordstatus = True


    End Sub

    Private Sub grdSHCarton_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSHCarton.CellLeave

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim tmp_count As Integer

        If SHCartonVaildFromTo() Then

            cal_Total() '20141203

            If SHCartonVaild() Then
                If SHCartonSC() Then
                    ma.rs_SHDTLCTN = (rs_SHDTLCTN_Sub.Copy)
                    ''sort & display

                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & "'" & ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq") & "' and DEL <> 'Y'"
                    rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Sort = "hdc_from"
                    tmp_count = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count - 1

                    If rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.Count > 0 Then

                        ma.txtCtnStr.Text = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(0)("hdc_from")
                        ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_ctnstr") = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(0)("hdc_from")

                        ma.txtCtnEnd.Text = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(tmp_count)("hdc_to")
                        ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_ctnend") = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView(tmp_count)("hdc_to")

                    End If
                    ma.Recordstatus_Dtl = True
                    Me.Close()
                End If
            End If
        End If



    End Sub

    Private Sub SHM00001_3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tmp_shpseq As Integer

        Call Formstartup(Me.Name)
        If GetCtrlValue(ma.cboShpSts) = "REL" Or GetCtrlValue(ma.cboShpSts) = "CLO" Then
            'grdSHCarton.AllowUpdate = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdOK.Enabled = False
        Else
            'grdSHCarton.AllowUpdate = True
            cmdInsRow.Enabled = True
            cmdDelRow.Enabled = True
            cmdOK.Enabled = True
        End If

        rs_SHDTLCTN_Sub = Nothing
        grdSHCarton.DataSource = Nothing

        rs_SHDTLCTN_Sub = ma.rs_SHDTLCTN.Copy
        For i2 As Integer = 0 To rs_SHDTLCTN_Sub.Tables("RESULT").Columns.Count - 1
            rs_SHDTLCTN_Sub.Tables("RESULT").Columns(i2).ReadOnly = False
        Next i2

        '''filtering by the shpseq  & display
        ''' 
        tmp_shpseq = ma.rs_SHIPGDTL.Tables("RESULT").Rows(ma.sReadingIndexS)("hid_shpseq")
        rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView.RowFilter = "hdc_shpseq = " & tmp_shpseq



        grdSHCarton.DataSource = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView

        Call Display()

        Call cal_Total()
        Call Display()
        cmdCancel.Focus()
        'Me.ActiveControl = cmdCancel




    End Sub

    Private Sub grdSHCarton_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdSHCarton.CellValidating
        Dim strNewVal As String
        Dim row As DataGridViewRow = grdSHCarton.CurrentRow

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim
        Select Case e.ColumnIndex
            Case 5, 6
                '            Case 5, 6, 7


                If Not IsNumeric(strNewVal) Then
                    MsgBox("Please input Numeric value!")
                    e.Cancel = True
                    Exit Sub
                End If

                If Not (strNewVal >= 0) Then
                    MsgBox("Please input positive value!")
                    e.Cancel = True
                    Exit Sub
                End If

        End Select



    End Sub

    Private Sub grdSHCarton_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdSHCarton.Validating

    End Sub


    Function SHCartonVaildFromTo() As Boolean
        SHCartonVaildFromTo = True

        Dim book As Integer
        Dim i As Integer, X As Integer
        X = 1

        If rs_SHDTLCTN_Sub.Tables("result").DefaultView.Count > 0 Then

            For index9 As Integer = 0 To rs_SHDTLCTN_Sub.Tables("result").DefaultView.Count - 1
                If rs_SHDTLCTN_Sub.Tables("result").DefaultView(index9)("hdc_from") > rs_SHDTLCTN_Sub.Tables("result").DefaultView(index9)("hdc_to") Then
                    MsgBox("Carton Form > Carton TO !")
                    SHCartonVaildFromTo = False
                    Exit Function
                End If
            Next
        End If


        ''If rs_SHDTLCTN_Sub.Tables("result").Rows.Count > 0 Then
        ''    For index9 As Integer = 0 To 1

        ''        hdc_from()

        ''    Next
        ''End If


        'If rs_SHDTLCTN_Sub.recordCount > 0 Then

        '    rs_SHDTLCTN_Sub.MoveFirst()
        '    While Not rs_SHDTLCTN_Sub.EOF
        '        book = rs_SHDTLCTN_Sub.AbsolutePosition

        '        rs_SHDTLCTN_Sub.Filter = "hdc_ttlctn <= 0 and DEL = ' ' and " & _
        '                                "hdc_shpseq = " & "'" & SHM00001.rs_SHIPGDTL("hid_shpseq").Value & "'"


        '        If rs_SHDTLCTN_Sub.recordCount > 0 Then
        '            rs_SHDTLCTN_Sub.MoveFirst()
        '            Erase dup
        '            For i = 1 To rs_SHDTLCTN_Sub.recordCount
        '                dup(i) = rs_SHDTLCTN_Sub.bookmark
        '                rs_SHDTLCTN_Sub.MoveNext()
        '            Next
        '            rs_SHDTLCTN_Sub.Filter = "hdc_shpseq = " & "'" & SHM00001.rs_SHIPGDTL("hid_shpseq").Value & "'"
        '            grdSHCarton.DataSource = rs_SHDTLCTN_Sub
        '            Call Display()
        '            rs_SHDTLCTN_Sub.MoveFirst()
        '            While dup(X) <> ""
        '                grdSHCarton.SelBookmarks.Add(dup(X) + 1 - 1)
        '                X = X + 1
        '            End While
        '            rs_SHDTLCTN_Sub.Filter = "hdc_shpseq = " & "'" & SHM00001.rs_SHIPGDTL("hid_shpseq").Value & "'"
        '            msg("M00334")
        '            SHCartonVaildFromTo = False
        '            If grdSHCarton.Enabled And grdSHCarton.Visible Then grdSHCarton.SetFocus()
        '            Exit Function
        '        Else
        '            SHCartonVaildFromTo = True
        '            rs_SHDTLCTN_Sub.Filter = "hdc_shpseq = " & "'" & SHM00001.rs_SHIPGDTL("hid_shpseq").Value & "'"
        '            rs_SHDTLCTN_Sub.AbsolutePosition = book
        '        End If
        '        rs_SHDTLCTN_Sub.MoveNext()
        '    End While

        grdSHCarton.DataSource = rs_SHDTLCTN_Sub.Tables("RESULT").DefaultView

        Call Display()

        'SHCartonVaildFromTo = True
        'Else
        'SHCartonVaildFromTo = True
        'End If
    End Function



End Class