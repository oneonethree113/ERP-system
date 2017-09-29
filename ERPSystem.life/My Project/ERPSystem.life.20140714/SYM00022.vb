Public Class SYM00022
    Public rs_Result As DataSet
    Public strITEMNO As String
    Public Mode As String

    Public Sub New(ByVal txtItmNo As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        strITEMNO = txtItmNo
        domapping_value = domapping()


    End Sub

    Public Function domapping() As Integer

        Dim strType As String
        Dim itmIn_TEMPCONVERSIONTABLE As Boolean
        Dim tmp_new_itmno As String
        Dim tmp_old_itmno As String
        strType = ""
        domapping = -1
        itmIn_TEMPCONVERSIONTABLE = False
        tmp_new_itmno = ""
        tmp_old_itmno = ""

        'ini()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If Len(strITEMNO) <= 0 Then
            domapping = -1
            Me.Cursor = Windows.Forms.Cursors.Default
        End If


        gspStr = "sp_select_SQL '" & gsCompany & "', 'select tmp_old_itmno, tmp_new_itmno from TEMP_CONVERSION_TABLE Where tmp_old_itmno = """ & strITEMNO & """'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00022 domapping sp_select_SQL : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            strType = ""
            strITEMNO = ""
            grdResult.DataSource = Nothing
            domapping = -1
            Exit Function
        Else
            If rs_Result.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                itmIn_TEMPCONVERSIONTABLE = False
            Else
                Me.Cursor = Windows.Forms.Cursors.Default
                itmIn_TEMPCONVERSIONTABLE = True
                tmp_new_itmno = rs_Result.Tables("RESULT").Rows(0).Item("tmp_new_itmno")
                tmp_old_itmno = rs_Result.Tables("RESULT").Rows(0).Item("tmp_old_itmno")
            End If
        End If



        If isNewItemFormat(strITEMNO, False) And itmIn_TEMPCONVERSIONTABLE = False Then
            gspStr = "sp_select_SQL '" & gsCompany & "', 'select isnull(ibi_alsitmno,"""") as ""ibi_alsitmno"", isnull(ibi_alscolcde,"""") as ""ibi_alscolcde"" from IMBASINF Where ibi_itmno = """ & strITEMNO & """"

            ' Added by Mark Lau 20090415, Add History Item
            gspStr = gspStr + " union select isnull(ibi_alsitmno,"""") as ""ibi_alsitmno"", isnull(ibi_alscolcde,"""") as ""ibi_alscolcde"" from IMBASINFH Where ibi_itmno = """ & strITEMNO & """ order by 1 '"


            strType = "NEW"
        Else
            gspStr = "sp_select_SQL '" & gsCompany & "', 'select isnull(icf_itmno,""""),isnull(icf_colcde,""""), isnull(icf_coldsc,"""")  from IMBASINF bas , IMBASINF als , imcolinf " & _
                "where bas.ibi_itmsts = ""OLD"" " & _
                "and bas.ibi_itmno = als.ibi_alsitmno " & _
                "and als.ibi_itmno = icf_itmno " & _
                "and bas.ibi_itmno = """ & strITEMNO & """ "

            ' Added by Mark Lau 20090415, Add History Item

            gspStr = gspStr + " union select isnull(icf_itmno,""""),isnull(icf_colcde,""""), isnull(icf_coldsc,"""")  from IMBASINFH bas , IMBASINF als , imcolinf " & _
             "where bas.ibi_itmsts = ""OLD"" " & _
                    "and bas.ibi_itmno = als.ibi_alsitmno " & _
                    "and als.ibi_itmno = icf_itmno " & _
                    "and bas.ibi_itmno = """ & strITEMNO & """ "

            gspStr = gspStr + " union select isnull(icf_itmno,""""),isnull(icf_colcde,""""), isnull(icf_coldsc,"""")  from IMBASINFH bas , IMBASINFH als , imcolinfH " & _
                "where bas.ibi_itmsts = ""OLD"" " & _
                "and bas.ibi_itmno = als.ibi_alsitmno " & _
                "and als.ibi_itmno = icf_itmno " & _
                "and bas.ibi_itmno = """ & strITEMNO & """ "

            gspStr = gspStr + " union select isnull(icf_itmno,""""),isnull(icf_colcde,""""), isnull(icf_coldsc,"""")  from IMBASINF bas , IMBASINFH als , imcolinfH " & _
                "where bas.ibi_itmsts = ""OLD"" " & _
                "and bas.ibi_itmno = als.ibi_alsitmno " & _
                "and als.ibi_itmno = icf_itmno " & _
                "and bas.ibi_itmno = """ & strITEMNO & """ order by 1'"

            strType = "OLD"
        End If
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00022 domapping sp_select_SQL : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            strType = ""
            strITEMNO = ""
            grdResult.DataSource = Nothing
            domapping = -1
            Exit Function
        Else
            If rs_Result.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No mapping can be found.", vbInformation, "Item Mapping")
                strType = ""
                strITEMNO = ""
                grdResult.DataSource = Nothing
                domapping = -1
                Exit Function
            Else
                Me.Cursor = Windows.Forms.Cursors.Default
                grdResult.DataSource = rs_Result.Tables("RESULT").DefaultView
                Display(strType)
                'grdResult.col = 0
                'grdResult.row = 0
                domapping = 1
                Exit Function
            End If
        End If

    End Function

    Public Event returnSelectedRecords(ByVal sender As Object)

    Public Function isNewItemFormat(ByVal strItem As String, Optional ByVal bolShow As Boolean = False) As Boolean

        If gsCompanyGroup = "MSG" Then
            isNewItemFormat = False
        Else
            'Lester Wu 2006-08-28
            isNewItemFormat = False
            strItem = UCase(strItem)
            If bolShow = True Then
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                ' Plant CDTXV added by Mark Lau 20080516
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or UCase(Mid(strItem, 3, 1)) = "B" Or UCase(Mid(strItem, 3, 1)) = "U" Or UCase(Mid(strItem, 3, 1)) = "C" Or UCase(Mid(strItem, 3, 1)) = "D" Or UCase(Mid(strItem, 3, 1)) = "T" Or UCase(Mid(strItem, 3, 1)) = "X" Or UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function

                If UCase(Mid(strItem, 7, 2)) = "AS" And Strings.Right(strItem, 2) <> "00" And UCase(Mid(strItem, 3, 1)) <> "C" And UCase(Mid(strItem, 3, 1)) <> "D" Then Exit Function

                If UCase(Mid(strItem, 7, 2)) <> "AS" Then

                    If UCase(Mid(strItem, 3, 1)) = "U" Then
                        Exit Function
                    End If

                    If UCase(Mid(strItem, 3, 1)) = "A" Then
                        'NNX
                        'If Not (Mid(strItem, 4, 1) >= "0" And Mid(strItem, 4, 1) <= "9" And _
                        '        Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9") Then Exit Function
                        ' If Not (Mid(strItem, 6, 1) >= "A" And Mid(strItem, 6, 1) <= "Z") Then Exit Function

                    End If

                    ' Plant CDTXV added by Mark Lau 20080516
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
                ' Plant CDTXV added by Mark Lau 20080516
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or UCase(Mid(strItem, 3, 1)) = "B" Or UCase(Mid(strItem, 3, 1)) = "U" Or UCase(Mid(strItem, 3, 1)) = "C" Or UCase(Mid(strItem, 3, 1)) = "D" Or UCase(Mid(strItem, 3, 1)) = "T" Or UCase(Mid(strItem, 3, 1)) = "X" Or UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function

                '''''        If UCase(Mid(strItem, 7, 2)) <> "AS" Then
                '''''            'NNX'
                '''''            If UCase(Mid(strItem, 3, 1)) = "A" Then
                '''''                If Not (Mid(strItem, 4, 1) >= "0" And Mid(strItem, 4, 1) <= "9" And _
                '''''                        Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9") Then Exit Function
                '''''                If Not (Mid(strItem, 6, 1) >= "A" And Mid(strItem, 6, 1) <= "Z") Then Exit Function
                '''''            End If
                '''''            'NXX
                '''''            If UCase(Mid(strItem, 3, 1)) = "B" Then
                '''''                If Not (Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9") Then Exit Function
                '''''                If Not (Mid(strItem, 6, 1) >= "0" And Mid(strItem, 6, 1) <= "9") Then Exit Function
                '''''            End If
                '''''
                '''''        End If
                '''''        If Len(strItem) = 13 And Mid(strItem, 7, 2) = "AS" And Right(strItem, 2) = "00" Then Exit Function
                '''''
            End If
            isNewItemFormat = True
        End If


    End Function

    Private Sub Display(ByVal strType As String)
        'Dim intCol As Long
        With grdResult
            If strType = "NEW" Then

                .Columns(0).HeaderCell.Value = "Old Item No."
                .Columns(1).HeaderCell.Value = "Old Item Color Code"



            ElseIf strType = "OLD" Then

                .Columns(0).HeaderCell.Value = "Item No."
                .Columns(1).HeaderCell.Value = "Color Code"
                .Columns(1).Width = 80
                .Columns(2).HeaderCell.Value = "Color Desc."
                .Columns(2).Width = 120


            End If

        End With
    End Sub

    Private Sub grdResult_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdResult.DoubleClick
        getItemNo()
        grdResult.DataSource = Nothing
        RaiseEvent returnSelectedRecords(Me)
        Me.Close()

    End Sub

    Private Sub getItemNo()
        If Not rs_Result Is Nothing Then
            'If Not (rs_Result.BOF Or rs_Result.EOF) Then
            'gsSearchKey = grdResult.Columns(0)
            gsSearchKey = grdResult.Item(0, 0).Value
            'End If
        End If
        Me.Close()
    End Sub
End Class