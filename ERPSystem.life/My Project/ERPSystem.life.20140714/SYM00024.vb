Public Class SYM00024
    Public strITEMNO As String
    Dim rs_SYM00024 As New DataSet

    Private Sub SYM00024_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        If Len(strITEMNO) > 0 Then
            If isNewItemFormat(strITEMNO, True) Then
                Call Search()
            Else
                strITEMNO = ""
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Search()
        Dim i As Integer
        i = 0
        gspStr = "sp_select_SYM00024 '', '" & strITEMNO.Substring(0, 11) & "','" & strITEMNO & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYM00024, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Search sp_select_SYM00024 :" & rtnStr)
            Exit Sub
        Else
            If rs_SYM00024.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found!")
                Exit Sub
            Else
                rs_SYM00024.Tables("RESULT").Columns(0).ReadOnly = False
                For i = 0 To rs_SYM00024.Tables("RESULT").Rows.Count - 1
                    rs_SYM00024.Tables("RESULT").Rows(i).Item("Upd") = "N"
                Next i
                Call display_dgResult()
            End If
        End If
    End Sub

    Private Sub display_dgResult()
        If rs_SYM00024.Tables.Count = 0 Then
            Exit Sub
        End If

        dgResult.DataSource = rs_SYM00024.Tables("RESULT").DefaultView
        
        dgResult.RowHeadersWidth = 18
        dgResult.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgResult.ColumnHeadersHeight = 18
        dgResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'dgResult.AllowUserToResizeColumns = False
        dgResult.AllowUserToResizeRows = False
        dgResult.RowTemplate.Height = 18

        Dim i As Integer
        i = 0
        dgResult.Columns(i).HeaderText = "Upd"
        dgResult.Columns(i).Width = 30
        dgResult.Columns(i).ReadOnly = True
        dgResult.Columns(i).Visible = True
        i = i + 1 '1
        dgResult.Columns(i).HeaderText = "Sts"
        dgResult.Columns(i).Width = 60
        dgResult.Columns(i).ReadOnly = True
        dgResult.Columns(i).Visible = True
        i = i + 1 '2
        dgResult.Columns(i).HeaderText = "Item Number"
        dgResult.Columns(i).Width = 100
        dgResult.Columns(i).ReadOnly = True
        dgResult.Columns(i).Visible = True
        i = i + 1 '3
        dgResult.Columns(i).HeaderText = "Color Code"
        dgResult.Columns(i).Width = 100
        dgResult.Columns(i).ReadOnly = True
        dgResult.Columns(i).Visible = True
        i = i + 1 '4
        dgResult.Columns(i).HeaderText = "Curr. Rmk"
        dgResult.Columns(i).Width = 180
        dgResult.Columns(i).ReadOnly = True
        dgResult.Columns(i).Visible = True
        i = i + 1 '5
        dgResult.Columns(i).HeaderText = "Upd. Rmk"
        dgResult.Columns(i).Width = 180
        dgResult.Columns(i).ReadOnly = True
        dgResult.Columns(i).Visible = True
        i = i + 1 '6
        dgResult.Columns(i).HeaderText = "timestamp"
        dgResult.Columns(i).Width = 0
        dgResult.Columns(i).ReadOnly = True
        dgResult.Columns(i).Visible = False
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        strITEMNO = ""
        Me.Close()
    End Sub

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

    Private Sub dgResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellContentClick
        Dim iRow As Integer

        iRow = dgResult.CurrentCell.RowIndex

        If dgResult.CurrentCell.ColumnIndex = 0 Then
            If dgResult.Item(0, iRow).Value = "N" Then
                dgResult.Item(0, iRow).Value = "Y"
            Else
                dgResult.Item(0, iRow).Value = "N"
            End If
        End If

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim i As Integer
        i = 0

        Dim dr_SYM00024() As DataRow
        dr_SYM00024 = rs_SYM00024.Tables("RESULT").Select("Upd = 'Y'")


        Dim ICF_ITMNO As String
        Dim ICF_COLCDE As String
        Dim NEWRMK As String
        Dim ICF_TIMSTP As String


        ICF_ITMNO = ""
        ICF_COLCDE = ""
        NEWRMK = ""
        ICF_TIMSTP = ""

        If dr_SYM00024.Length > 0 Then
            If MsgBox("Are you sure to update?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For i = 0 To dr_SYM00024.Length - 1
                    ICF_ITMNO = dr_SYM00024(i).Item("icf_itmno")
                    ICF_COLCDE = dr_SYM00024(i).Item("icf_colcde")
                    NEWRMK = dr_SYM00024(i).Item("NewRmk")
                    ICF_TIMSTP = dr_SYM00024(i).Item("icf_timstp")

                    gspStr = "sp_select_SYM00024_TimStp '', '" & ICF_ITMNO & "','" & ICF_COLCDE & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdUpdate_Click sp_select_SYM00024_TimStp :" & rtnStr)
                        Exit Sub
                    End If

                    If ICF_TIMSTP = rs.Tables("RESULT").Rows(0).Item("icf_timstp") Then
                        gspStr = "sp_update_SYM00024 '', '" & ICF_ITMNO & "','" & NEWRMK & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdUpdate_Click sp_update_SYM00024 :" & rtnStr)
                            Exit Sub
                        End If
                    Else
                        MsgBox("Item " & rs.Tables("RESULT").Rows(0).Item("icf_itmno").Value & " has been modified by " & rs.Tables("RESULT").Rows(0).Item("icf_updusr").Value & ". Update Failed.")
                    End If
                Next i
                MsgBox("Batch Update Finish.")
                Call cmdCancel_Click(sender, e)
            End If
        Else
            MsgBox("No item is selected. Please choose item for update.")
        End If
    End Sub
End Class