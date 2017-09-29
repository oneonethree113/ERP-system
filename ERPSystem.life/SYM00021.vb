Public Class SYM00021

    Public strITEMNO As String
    Public rs_Result As New DataSet

    Public Sub New(ByVal txtItmNo As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        strITEMNO = txtItmNo

        If Len(strITEMNO) > 0 Then
            If isNewItemFormat(strITEMNO, True) Then
                Call Search()
            Else
                strITEMNO = ""
            End If
        End If

        If rs_Result.Tables.Count = 0 Then
            MsgBox("No Record Found!")
            SYM00021_Value = 0
            grdResult.DataSource = Nothing
            rs_Result.Tables.Clear()
        Else
            If rs_Result.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found!")
                SYM00021_Value = 0
                grdResult.DataSource = Nothing
                rs_Result.Tables.Clear()
            Else
                SYM00021_Value = 1
                grdResult.DataSource = rs_Result.Tables("RESULT").DefaultView
                Call Display()
            End If
        End If
    End Sub

    'Private Sub SYM00021_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Cursor = Cursors.WaitCursor

    '    If Len(strITEMNO) > 0 Then
    '        If isNewItemFormat(strITEMNO, True) Then
    '            Call Search()
    '        Else
    '            strITEMNO = ""
    '        End If
    '    End If

    '    Cursor = Cursors.Default
    'End Sub

    Private Function isNewItemFormat(ByVal strItem As String, Optional ByVal bolShow As Boolean = False) As Boolean
        If gsCompanyGroup = "MSG" Then
            isNewItemFormat = False
        Else
            isNewItemFormat = False
            strItem = UCase(strItem)

            If bolShow = True Then
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function

                If UCase(Mid(strItem, 7, 2)) = "AS" And _
                    Microsoft.VisualBasic.Right(strItem, 2) <> "00" And _
                    UCase(Mid(strItem, 3, 1)) <> "C" And _
                    UCase(Mid(strItem, 3, 1)) <> "D" Then Exit Function

                If UCase(Mid(strItem, 7, 2)) <> "AS" Then
                    If UCase(Mid(strItem, 3, 1)) = "U" Then
                        Exit Function
                    End If

                    If UCase(Mid(strItem, 3, 1)) = "A" Then

                    End If

                    '*** Plant CDTXV
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
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function
            End If
            isNewItemFormat = True
        End If
    End Function

    Private Sub Search()
        Dim i As Integer

        Dim itm11In_TEMPCONVERSIONTABLE As Boolean
        Dim itm13In_TEMPCONVERSIONTABLE As Boolean
        Dim tmp_new_itmno As String
        Dim tmp_old_itmno As String

        ' Added by Marco 20100105 handle 2864 item change number
        'S = "㊣SQL※S※select tmp_old_itmno, tmp_new_itmno from TEMP_CONVERSION_TABLE Where left(tmp_old_itmno,11) = '" & Left(strITEMNO, 11) & "' or left(tmp_new_itmno,11) = '" & Left(strITEMNO, 11) & "' "
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_SQL '" & gsCompany & "','select tmp_old_itmno, tmp_new_itmno from TEMP_CONVERSION_TABLE Where left(tmp_old_itmno,11) = """ & Microsoft.VisualBasic.Left(strITEMNO, 11) & """ or left(tmp_new_itmno,11) = """ & Microsoft.VisualBasic.Left(strITEMNO, 11) & """'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Search sp_select_SQL 1 :" & rtnStr)
            rs_Result = Nothing
            Exit Sub
        End If

        If rs_Result.Tables("RESULT").Rows.Count = 0 Then
            itm11In_TEMPCONVERSIONTABLE = False
        Else
            itm11In_TEMPCONVERSIONTABLE = True

            tmp_new_itmno = rs_Result.Tables("RESULT").Rows(0)("tmp_new_itmno")
            tmp_old_itmno = rs_Result.Tables("RESULT").Rows(0)("tmp_old_itmno")
        End If

        'S = "㊣SQL※S※select tmp_old_itmno, tmp_new_itmno from TEMP_CONVERSION_TABLE Where tmp_old_itmno = '" & strITEMNO & "' or tmp_new_itmno = '" & strITEMNO & "' "
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_SQL '" & gsCompany & "','select tmp_old_itmno, tmp_new_itmno from TEMP_CONVERSION_TABLE Where tmp_old_itmno = """ & strITEMNO & """ or tmp_new_itmno = """ & strITEMNO & """'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Search sp_select_SQL 2 :" & rtnStr)
            rs_Result = Nothing
            Exit Sub
        End If

        If rs_Result.Tables("RESULT").Rows.Count = 0 Then
            itm13In_TEMPCONVERSIONTABLE = False
        Else
            itm13In_TEMPCONVERSIONTABLE = True

            tmp_new_itmno = rs_Result.Tables("RESULT").Rows(0)("tmp_new_itmno")
            tmp_old_itmno = rs_Result.Tables("RESULT").Rows(0)("tmp_old_itmno")
        End If

        Cursor = Cursors.WaitCursor

        Dim message As String = ""

        If itm13In_TEMPCONVERSIONTABLE = True Then
            'handle 2864 item in conversion table
            'S = "㊣SQL※S※select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_old_itmno, 11) & "' and icf_itmno <> '" & tmp_old_itmno & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_new_itmno, 11) & "' and icf_itmno <> '" & tmp_new_itmno & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + "Select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_old_itmno, 11) & "' and icf_itmno <> '" & tmp_old_itmno & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_new_itmno, 11) & "' and icf_itmno <> '" & tmp_new_itmno & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + "Select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINF (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_old_itmno, 11) & "' and icf_itmno <> '" & tmp_old_itmno & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINFH (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_new_itmno, 11) & "' and icf_itmno <> '" & tmp_new_itmno & "' and ibi_itmsts <> 'OLD' "

            gspStr = "sp_select_SQL '" & gsCompany & "','select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_old_itmno, 11) & """ and icf_itmno <> """ & tmp_old_itmno & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_new_itmno, 11) & """ and icf_itmno <> """ & tmp_new_itmno & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_old_itmno, 11) & """ and icf_itmno <> """ & tmp_old_itmno & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_new_itmno, 11) & """ and icf_itmno <> """ & tmp_new_itmno & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINF (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_old_itmno, 11) & """ and icf_itmno <> """ & tmp_old_itmno & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINFH (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_new_itmno, 11) & """ and icf_itmno <> """ & tmp_new_itmno & """ and ibi_itmsts <> ""OLD""'"
            message = "sp_select_SQL 3"
        ElseIf itm11In_TEMPCONVERSIONTABLE = True Then
            'S = "㊣SQL※S※select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_old_itmno, 11) & "' and icf_itmno <> '" & strITEMNO & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_new_itmno, 11) & "' and icf_itmno <> '" & strITEMNO & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_old_itmno, 11) & "' and icf_itmno <> '" & strITEMNO & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_new_itmno, 11) & "' and icf_itmno <> '" & strITEMNO & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINF (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_old_itmno, 11) & "' and icf_itmno <> '" & strITEMNO & "' and ibi_itmsts <> 'OLD' "
            'S = S + " Union "
            'S = S + " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINFH (nolock) "
            'S = S + " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = '" & Left(tmp_new_itmno, 11) & "' and icf_itmno <> '" & strITEMNO & "' and ibi_itmsts <> 'OLD' "

            gspStr = "sp_select_SQL '" & gsCompany & "','select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_old_itmno, 11) & """ and icf_itmno <> """ & strITEMNO & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINF (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_new_itmno, 11) & """ and icf_itmno <> """ & strITEMNO & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_old_itmno, 11) & """ and icf_itmno <> """ & strITEMNO & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINFH (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_new_itmno, 11) & """ and icf_itmno <> """ & strITEMNO & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH (nolock), IMBASINF (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_old_itmno, 11) & """ and icf_itmno <> """ & strITEMNO & """ and ibi_itmsts <> ""OLD""" & _
                     " Union " & _
                     " select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF (nolock), IMBASINFH (nolock) " & _
                     " Where ibi_itmno = icf_itmno and left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(tmp_new_itmno, 11) & """ and icf_itmno <> """ & strITEMNO & """ and ibi_itmsts <> ""OLD""'"
            message = "sp_select_SQL 4"
        Else
            'S = "㊣SQL※S※select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF Where left(icf_itmno,11) = '" & Left(strITEMNO, 11) & "' and icf_itmno <> '" & strITEMNO & "'"
            'S = S + " Union "
            'S = S + "select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH Where left(icf_itmno,11) = '" & Left(strITEMNO, 11) & "' and icf_itmno <> '" & strITEMNO & "'"

            gspStr = "sp_select_SQL '" & gsCompany & "','select icf_itmno,icf_colcde,icf_coldsc from IMCOLINF Where left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(strITEMNO, 11) & """ and icf_itmno <> """ & strITEMNO & """" & _
                     " Union " & _
                     "select icf_itmno,icf_colcde,icf_coldsc from IMCOLINFH Where left(icf_itmno,11) = """ & Microsoft.VisualBasic.Left(strITEMNO, 11) & """ and icf_itmno <> """ & strITEMNO & """'"
            message = "sp_select_SQL 5"
        End If
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Search " & message & " :" & rtnStr)
            rs_Result = Nothing
            Exit Sub
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub Display()
        Dim intCol As Integer

        With grdResult
            intCol = 0
            .Columns(intCol).HeaderText = "Item Number"
            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Color Code"
            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Color Description"
        End With
    End Sub

    Public Event returnSelectedRecords(ByVal sender As Object)

    Private Sub grdResult_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdResult.DoubleClick
        If grdResult.SelectedRows.Count = 1 Then

            If callBy = "IMM00001" Then
                Dim tmpstr = grdResult.SelectedRows(0).Cells(0).Value.ToString
                Dim ctn() As Control = frmS.Controls.Find("txtItmNo", True)
                ctn(0).Text = tmpstr

                Dim tmpargs(1) As Object

                tmpargs(0) = sender
                tmpargs(1) = e
                CallByName(frmS, "cmdFind_Click", CallType.Method, tmpargs)
            Else
                Call getItemNo(grdResult.SelectedRows(0).Cells(0).Value.ToString)
                grdResult.DataSource = Nothing
                RaiseEvent returnSelectedRecords(Me)
            End If
        End If
        Me.Close()
    End Sub

    Private Sub getItemNo(ByVal itmNo As String)
        If rs_Result.Tables.Count <> 0 Then
            gsSearchKey = itmNo
        End If
        Me.Close()
    End Sub


    Public frmS As Form
    Public callBy As String

    Public Sub show_frmSYM00021(ByVal frm As Form)
        frmS = frm
        Me.ShowDialog()
    End Sub

    Private Sub grdResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdResult.CellContentClick

    End Sub
End Class