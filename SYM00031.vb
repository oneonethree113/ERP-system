Public Class SYM00031

    Dim rs_fmlInf As New DataSet
    Dim rs_sycstset As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim rs_SYPAKCAT As New DataSet
    Dim rs_PKWASGE As New DataSet

    Dim Got_Focus_Grid As String

    Dim recordstatus As Boolean = False


    Private Sub SYM00031_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right



            If Not rs_SYPAKCAT Is Nothing Then
                rs_SYPAKCAT = Nothing
            End If


            If Not rs_PKWASGE Is Nothing Then
                rs_PKWASGE = Nothing
            End If


            gspStr = "sp_list_SYPAKCAT"
            rtnLong = execute_SQLStatement(gspStr, rs_SYPAKCAT, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00031_Load sp_list_SYPAKCAT : " & rtnStr)
            Else

            End If

            gspStr = "sp_list_PKWASGE"
            rtnLong = execute_SQLStatement(gspStr, rs_PKWASGE, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00031_Load sp_list_PKWASGE : " & rtnStr)
            Else

                For i As Integer = 0 To rs_SYPAKCAT.Tables("RESULT").Columns.Count - 1
                    rs_SYPAKCAT.Tables("RESULT").Columns(i).ReadOnly = False
                Next

                For i As Integer = 0 To rs_PKWASGE.Tables("RESULT").Columns.Count - 1
                    rs_PKWASGE.Tables("RESULT").Columns(i).ReadOnly = False
                Next

                Call displayGrid()
                Call setStatus("Init")
            End If




            'gspStr = "sp_select_SYCSTSET '" & gsCompany & "','','',''"
            'rtnLong = execute_SQLStatement(gspStr, rs_sycstset, rtnStr)
            'If rtnLong <> RC_SUCCESS Then
            '    MsgBox("Error on loading SYM00023 sp_select_SYCSTSET : " & rtnStr)
            'Else
            '    'Call setDataRowAttr()
            '    Call displayGrid()
            '    Call setStatus("Init")
            'End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub displayGrid()
        setGrdSYMPKGCAT()


        'Dim dr() As DataRow
        'dr = rs_PKWASGE.Tables("RESULT").Select("pwa_code = '@@!#'")




        setGrdCATWAG("pwa_code = '@@!#'")
    End Sub

    Private Sub setGrdCATWAG(ByVal filter As String)


        rs_PKWASGE.Tables("RESULT").DefaultView.RowFilter = filter


        Dim i As Integer

        With grdCATWAG
            .DataSource = Nothing
            .DataSource = rs_PKWASGE.Tables("RESULT").DefaultView

            For i = 0 To .Columns.Count - 1
                Select Case i

                    Case 0
                        .Columns(i).Width = 30

                        .Columns(i).ReadOnly = True
                        .Columns(i).HeaderText = "Del"
                    Case 1
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = " "
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).Width = 140
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Qty From"
                        .Columns(i).ReadOnly = False
                    Case 4
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Qty To"
                        .Columns(i).ReadOnly = False
                    Case 5
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "Wastage"
                        .Columns(i).ReadOnly = False
                    Case 6
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).Width = 140
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).Width = 80
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).Width = 140
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).Width = 80
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next



        End With

    End Sub

    Private Sub setGrdSYMPKGCAT()
        Dim i As Integer
        Dim dv As DataView = rs_SYPAKCAT.Tables("RESULT").DefaultView
        grdSYMPKGCAT.DataSource = dv

        With grdSYMPKGCAT
            .DataSource = Nothing
            .DataSource = dv
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True

                    Case 1
                        .Columns(i).Width = 70
                        .Columns(i).HeaderText = "PKG Code"
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Component List"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "MOQ"
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).Width = 350
                        .Columns(i).HeaderText = "Description"
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).Width = 80
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).Width = 60
                        .Columns(i).Visible = False
                    Case 7
                        .Columns(i).Width = 140
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).Width = 80
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).Width = 80
                        .Columns(i).Visible = False
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With
        Me.StatusBar.Items("lblRight").Text = ""
        If Not rs_PKWASGE.Tables("RESULT").Rows.Count = 0 Then
            Dim dv_PKWASGE As DataView
            dv_PKWASGE = rs_PKWASGE.Tables("RESULT").DefaultView

            dv_PKWASGE.Sort = "pwa_upddat desc"
            Dim drv As DataRowView = dv_PKWASGE(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("pwa_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("pwa_upddat"), "MM/dd/yyyy") & " " & drv.Item("pwa_updusr")

            dv_PKWASGE.Sort = Nothing
        End If
    End Sub



    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False



            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False


            Call ResetDefaultDisp()
            Call SetStatusBar(mode)


        ElseIf mode = "InsRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            'Call SYM00023_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local


            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub
    Private Sub ResetDefaultDisp()
        Me.StatusBar.Items("lblLeft").Text = ""
    End Sub
    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "InsRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Row"
        ElseIf mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf mode = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If

    End Sub

    Private Sub grdSYMPKGCAT_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSYMPKGCAT.CellClick
        Dim value As String
        value = grdSYMPKGCAT.Item(1, grdSYMPKGCAT.CurrentCell.RowIndex).Value

        setGrdCATWAG("pwa_code = '" & value & "'")


        Label2.Text = "Wastage Setup - " & value

        mmdInsRow.Enabled = True

    End Sub

    Private Sub grdSYMPKGCAT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSYMPKGCAT.CellDoubleClick
        'Dim value As String
        'value = grdSYMPKGCAT.Item(1, grdSYMPKGCAT.CurrentCell.RowIndex).Value

        'setGrdCATWAG("pwa_code = '" & value & "'")

    End Sub


    Private Sub add_CATWAG()
        Dim rowcount As Integer
        rowcount = rs_PKWASGE.Tables("RESULT").Rows.Count

        Dim dr() As DataRow = rs_PKWASGE.Tables("RESULT").Select("pwa_code = '" & Split(Label2.Text, " - ")(1) & "' and pwa_wasage = 0")

        If dr.Length = 0 Then
            recordstatus = True
            rs_PKWASGE.Tables("RESULT").Rows.Add()

            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_cocde") = ""
            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_code") = Split(Label2.Text, " - ")(1)
            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_qtyfrm") = 0
            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_qtyto") = 0
            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_wasage") = 0
            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_seq") = -1
            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_um") = "PC"
            rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_creusr") = "~*ADD*~"
        End If

    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim rowcount As Integer
        rowcount = rs_PKWASGE.Tables("RESULT").Rows.Count
        rs_PKWASGE.Tables("RESULT").Rows.Add()

        rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_code") = "BAG"

    End Sub

  

    Private Sub grdCATWAG_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCATWAG.CellDoubleClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdCATWAG.RowCount > 0 Then
            Dim iCol As Integer = grdCATWAG.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdCATWAG.CurrentCell.RowIndex
            Dim curvalue As String


            If grdCATWAG.CurrentCell.ColumnIndex = 0 Then
                curvalue = grdCATWAG.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    'counter = 0
                    'For i = 0 To grdVnCntInf.RowCount - 1
                    '    If Trim(grdVnCntInf.Item(grdVnCntInf_vci_status, i).Value) = "" Then
                    '        counter = counter + 1
                    '    End If
                    'Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdCATWAG.Item(0, iRow).Value = "Y"
                    'End If
                    recordstatus = True
                Else
                    grdCATWAG.Item(0, iRow).Value = ""

                    recordstatus = True
                End If

            ElseIf grdCATWAG.CurrentCell.ColumnIndex = 6 Then
                curvalue = grdCATWAG.CurrentCell.Value
                If Trim(curvalue) = "PC" Then
                    grdCATWAG.Item(6, iRow).Value = "%"
                Else
                    grdCATWAG.Item(6, iRow).Value = "PC"
                End If

                If grdCATWAG.Item(7, iRow).Value <> "~*ADD*~" Then
                    grdCATWAG.Item(7, iRow).Value = "~*UPD*~"

                End If
                recordstatus = True
            End If



        End If


    End Sub

    Private Sub grdCATWAG_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCATWAG.CellEndEdit
        If grdCATWAG.RowCount = 0 Then
            Exit Sub
        End If


        Dim strvalue As String = Trim(grdCATWAG.Item(1, grdCATWAG.CurrentCell.RowIndex).Value.ToString)

        Dim currentrow As Integer = grdCATWAG.CurrentCell.RowIndex

        Dim currentcolum As Integer = grdCATWAG.CurrentCell.ColumnIndex

        Select Case e.ColumnIndex

            Case 3, 4

                rs_PKWASGE.Tables("RESULT").AcceptChanges()

                If strvalue <> "" Then





                    If IsDBNull(grdCATWAG.Item(currentcolum, currentrow).Value) = True Then
                        grdCATWAG.Item(currentcolum, currentrow).Value = 0
                        Exit Sub
                    End If



                    Dim currentqty As Integer = grdCATWAG.Item(currentcolum, currentrow).Value

                    If currentqty = 0 Then
                        Exit Sub
                    End If



                    If grdCATWAG.Item(4, currentrow).Value = 0 Or grdCATWAG.Item(3, currentrow).Value = 0 Then
                        Exit Sub
                    End If

                    'pwa_qtyfrm()

                    'pwa_qtyto()

                    Dim drr() As DataRow = rs_PKWASGE.Tables("RESULT").Select("pwa_code = '" & strvalue & "' and pwa_qtyfrm <= " & currentqty & " and " & currentqty & " <= pwa_qtyto") ' and pwa_qtyto <> 999999999



                    If drr.Length > 1 Then
                        MsgBox("Duplicate Formula Qty Range")
                        grdCATWAG.Item(currentcolum, currentrow).Value = 0
                    End If


                    If e.ColumnIndex = 3 Then



                        If currentqty >= grdCATWAG.Item(4, currentrow).Value Then
                            MsgBox("Invalid Qty Range")
                            grdCATWAG.Item(currentcolum, currentrow).Value = 0
                        End If

                    ElseIf e.ColumnIndex = 4 Then

                        If currentqty <= grdCATWAG.Item(3, currentrow).Value Then
                            MsgBox("Invalid Qty Range")
                            grdCATWAG.Item(currentcolum, currentrow).Value = 0
                        End If


                    End If

                End If

        End Select



        ' grdExcCus.Columns(grdAgent_cai_cusagt).ReadOnly = True




        'rs_VNEXCCUS.Tables("RESULT").AcceptChanges()
        'If strvalue <> "" Then
        '    Dim drr() As DataRow = rs_VNEXCCUS.Tables("RESULT").Select("vec_cusno = '" & strvalue & "'")

        '    If drr.Length > 1 Then

        '        MsgBox("Duplicate Customer Code")
        '        grdExcCus.Item(grdExcCus_vec_cusno, currentrow).Value = ""



        '    End If

        'End If

        'grdExcCus.Columns(grdExcCus_vec_cusno).ReadOnly = True



    End Sub

    Private Sub grdCATWAG_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCATWAG.CellValidating
        Dim row As DataGridViewRow = grdCATWAG.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case 3, 4, 5

                    If strNewVal = "" Then
                        Exit Sub
                    End If

                    If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                        If strNewVal.Contains(".") = True Then
                            MsgBox("Invalid Quantity!")
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If

                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid Quantity!")
                        e.Cancel = True
                        Exit Sub
                    End If



            End Select

        End If

    End Sub

    Private Sub grdSYMPKGCAT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSYMPKGCAT.GotFocus
        Label1.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "grdSYMPKGCAT"
    End Sub

    Private Sub grdSYMPKGCAT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSYMPKGCAT.LostFocus
        Label1.ForeColor = Color.Blue
    End Sub

    Private Sub grdCATWAG_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCATWAG.EditingControlShowing
        If grdCATWAG.Item(7, grdCATWAG.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
            grdCATWAG.Item(7, grdCATWAG.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
        recordstatus = True
    End Sub

    Private Sub grdCATWAG_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCATWAG.GotFocus
        Label2.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "grdCATWAG"
    End Sub
    Private Sub grdCATWAG_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCATWAG.LostFocus
        Label2.ForeColor = Color.Blue
    End Sub




    Private Function save_PKWASGE()


        Dim pwa_cocde As String
        Dim pwa_code As String
        Dim pwa_qtyfrm As Integer
        Dim pwa_qtyto As Integer
        Dim pwa_wasage As Decimal
        Dim pwa_um As String
        Dim user As String
        Dim seq As Integer

        For i As Integer = 0 To rs_PKWASGE.Tables("RESULT").Rows.Count - 1
            pwa_cocde = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_cocde").ToString
            pwa_code = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_code").ToString
            pwa_qtyfrm = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_qtyfrm")
            pwa_qtyto = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_qtyto")
            pwa_wasage = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_wasage")
            pwa_um = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_um").ToString
            user = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_creusr").ToString
            seq = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_seq")


            If pwa_cocde = "Y" Then
                gspStr = "sp_physical_delete_PKWASGE '','" & pwa_code & "'," & seq
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKWASGE sp_physical_delete_PKWASGE:" & rtnStr)
                    save_PKWASGE = False
                    Exit Function

                End If

            ElseIf user = "~*ADD*~" Then


                gspStr = "sp_insert_PKWASGE '" & "" & "','" & pwa_code & "'," & pwa_qtyfrm & "," & pwa_qtyto & "," & _
                pwa_wasage & ",'" & pwa_um & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKWASGE sp_insert_PKWASGE :" & rtnStr)
                    save_PKWASGE = False
                    Exit Function

                End If




            ElseIf user = "~*UPD*~" Then


                gspStr = "sp_update_PKWASGE '" & "" & "','" & pwa_code & "'," & seq & "," & pwa_qtyfrm & "," & pwa_qtyto & "," & _
                pwa_wasage & ",'" & pwa_um & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKWASGE sp_update_PKWASGE :" & rtnStr)
                    save_PKWASGE = False
                    Exit Function

                End If


            End If






        Next i

        save_PKWASGE = True


    End Function


    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If recordstatus = True And Enq_right_local Then
            Select Case MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    If Enq_right_local Then
                        Call mmdSave_Click(sender, e)
                    Else
                        MsgBox("You have no Save record rights!")
                    End If
                    Me.Cursor = Cursors.Default
                Case MsgBoxResult.No
                    Me.Close()
                    Me.Cursor = Cursors.Default
                    recordstatus = False
            End Select
        Else
            Me.Close()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        'Dim rowcount As Integer
        'rowcount = rs_PKWASGE.Tables("RESULT").Rows.Count
        'rs_PKWASGE.Tables("RESULT").Rows.Add()

        'rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_code") = "BAG"
        'rs_PKWASGE.Tables("RESULT").Rows(rowcount).Item("pwa_qtyfrm") = DBNull.Value


        'Select Case Got_Focus_Grid
        '    Case "grdCATWAG"
        Call add_CATWAG()

        'End Select

    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        For i As Integer = 0 To rs_PKWASGE.Tables("RESULT").Rows.Count - 1
            If rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_qtyfrm") = 0 Or rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_qtyto") = 0 Then
                MsgBox("Wastage Setup Invalid , Please Check.")
                Dim code As String = rs_PKWASGE.Tables("RESULT").Rows(i).Item("pwa_code").ToString
                Label2.Text = "Wastage Setup - " & code
                setGrdCATWAG("pwa_code = '" & code & "'")
                Exit Sub
            End If
        Next





        If save_PKWASGE() Then
            MsgBox("Record Saved.")
            recordstatus = False
            SYM00031_Load(sender, e)
        End If


    End Sub
End Class
