Public Class frmSCShip

    Public myOwner As SCM00001

    Public rs_SCDTLSHP_SUB As New DataSet
    Dim total As Long
    Dim dup() As Integer

    Dim sFilter As String

    Private Sub frmSCShip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs_SCDTLSHP_SUB = myOwner.rs_SCDTLSHP.Copy()

        sFilter = "sds_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")
        rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter
        grdSCShip.DataSource = rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView

        If (Split(myOwner.cboSCStatus.Text, " - ")(0) = "ACT" Or Split(myOwner.cboSCStatus.Text, " - ")(0) = "HLD") And myOwner.cmdSave.Enabled = True Then

            cmdOK.Enabled = True
            cmdDelRow.Enabled = True
            cmdInsRow.Enabled = True
        Else
            cmdOK.Enabled = False
            cmdDelRow.Enabled = False
            cmdInsRow.Enabled = False
            LockGrd()
        End If

        cal_Total()
        Display()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If SCshipVaildFromTo Then
            If SCshipVaild() Then
                rs_SCDTLSHP_SUB.AcceptChanges()
                myOwner.rs_SCDTLSHP = rs_SCDTLSHP_SUB.Copy()
                myOwner.rs_SCDTLSHP.AcceptChanges()
                Dim dr() As DataRow = rs_SCDTLSHP_SUB.Tables("RESULT").Select("sds_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq") & " and sds_status <> 'Y'", "sds_from")
                If dr.Length > 0 Then
                    myOwner.txtStartShip.Text = Format(CDate(dr(0)("sds_from")), "MM/dd/yyyy")
                    dr = Nothing
                    dr = rs_SCDTLSHP_SUB.Tables("RESULT").Select("sds_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq") & " and sds_status <> 'Y'", "sds_to")
                    myOwner.txtEndShip.Text = Format(CDate(dr(dr.Length - 1)("sds_to")), "MM/dd/yyyy")
                End If
                Close()
            End If
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            cal_Total()
            With rs_SCDTLSHP_SUB.Tables("RESULT")
                For i As Integer = 0 To .DefaultView.Count - 1
                    If .DefaultView.Item(i)("sds_status").ToString <> "Y" And .DefaultView.Item(i)("sds_ttlctn") = 0 Then
                        grdSCShip.Rows(i).Selected = True
                        Exit Sub
                    End If
                Next
            End With
        End If

        Dim newRow As DataRow = rs_SCDTLSHP_SUB.Tables("RESULT").NewRow
        newRow.Item("sds_status") = " "
        newRow.Item("sds_seq") = myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")
        newRow.Item("sds_from") = Format(Date.Now, "MM/dd/yyyy")
        newRow.Item("sds_to") = Format(DateAdd(DateInterval.Day, 1, Date.Now), "MM/dd/yyyy")
        newRow.Item("sds_ttlctn") = 0
        newRow.Item("sds_creusr") = "~*ADD*~"
        newRow.Item("sds_credat") = Date.Now
        newRow.Item("sds_upddat") = Date.Now
        rs_SCDTLSHP_SUB.Tables("RESULT").Rows.Add(newRow)
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        If grdSCShip.SelectedRows.Count > 0 Then
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_status").ReadOnly = False
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_creusr").ReadOnly = False
            For i As Integer = 0 To grdSCShip.SelectedRows.Count - 1
                If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_status").ToString = "Y" Then
                    If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_creusr").ToString = "~*NEW*~" Then
                        rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_creusr") = "~*ADD*~"
                    Else
                        rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_creusr") = "~*UPD*~"
                    End If

                    rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_status") = " "
                Else
                    If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_creusr").ToString <> "~*ADD*~" Then
                        rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_creusr") = "~*DEL*~"
                    ElseIf rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_creusr").ToString = "~*ADD*~" Then
                        rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_creusr") = "~*NEW*~"
                    End If

                    rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.SelectedRows(i).Index)("sds_status") = "Y"
                End If
            Next
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_status").ReadOnly = True
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_creusr").ReadOnly = True

            grdSCShip.Refresh()
            cal_Total()
        End If
    End Sub

    Private Sub LockGrd()
        Dim i As Integer
        For i = 0 To grdSCShip.Columns.Count - 1
            grdSCShip.Columns(i).ReadOnly = True
        Next i
    End Sub

    Private Sub cal_Total()
        total = 0
        If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            For i As Integer = 0 To rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count - 1
                If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_status").ToString <> "Y" Then
                    total = total + rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_ttlctn")
                End If
            Next
        End If

        txtTotal.Text = total
    End Sub

    Private Sub Display()
        With grdSCShip
            For i As Integer = 0 To rs_SCDTLSHP_SUB.Tables("RESULT").Columns.Count - 1
                rs_SCDTLSHP_SUB.Tables("RESULT").Columns(i).ReadOnly = False
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "From"
                        .Columns(i).Width = 164
                        .Columns(i).ReadOnly = False
                    Case 6
                        .Columns(i).HeaderText = "To"
                        .Columns(i).Width = 164
                        .Columns(i).ReadOnly = False
                    Case 7
                        .Columns(i).HeaderText = "Quantity"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Function SCshipVaildFromTo() As Boolean
        If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            For i As Integer = 0 To rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count - 1
                If CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_from")) > CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_to")) And _
                   rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)(0).ToString <> "Y" Then
                    grdSCShip.Rows(i).Selected = True
                    MsgBox("Start Date > End Date", MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next
            Return True
        Else
            Return True
        End If
    End Function

    Function SCshipVaild() As Boolean
        If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            Dim dr() As DataRow
            dr = rs_SCDTLSHP_SUB.Tables("RESULT").Select("sds_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq") & " and sds_status <> 'Y'")
            If dr.Length = 0 Then
                myOwner.txtStartShip.Enabled = True
                myOwner.txtEndShip.Enabled = True
                Return True
            End If

            For i As Integer = 0 To rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count - 1
                If Val(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_ttlctn").ToString) = 0 And _
                   rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)(0).ToString <> "Y" Then
                    MsgBox("Please Input the Ship Qty!", MsgBoxStyle.Information)
                    Return False
                End If
            Next

            If txtTotal.Text <> myOwner.txtOrdQty.Text Then
                myOwner.txtStartShip.Enabled = False
                myOwner.txtEndShip.Enabled = False
                MsgBox("Total Ship Qty not Equal to Order Qty", MsgBoxStyle.Exclamation)
                Return False
            End If

            myOwner.txtStartShip.Enabled = False
            myOwner.txtEndShip.Enabled = False

            Dim start_Date As Date
            Dim end_Date As Date
            For i As Integer = 0 To rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count - 1
                If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_status").ToString <> "Y" Then
                    start_Date = CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_from").ToString)
                    end_Date = CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(i)("sds_to").ToString)
                    For j As Integer = 0 To rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Count - 1
                        If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(j)("sds_status").ToString <> "Y" And i <> j Then
                            If (start_Date <= CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(j)("sds_from").ToString) And _
                               end_Date >= CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(j)("sds_from").ToString)) Or _
                               (start_Date <= CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(j)("sds_to").ToString) And _
                               end_Date >= CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(j)("sds_to").ToString)) Or _
                               (start_Date >= CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(j)("sds_from").ToString) And _
                               end_Date <= CDate(rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(j)("sds_to").ToString)) Then
                                grdSCShip.Rows(i).Selected = True
                                grdSCShip.Rows(j).Selected = True
                                ' Commented by David Yue on 2013-05-14 with request from Anita Leung
                                'MsgBox("Duplicate Ship Date!", MsgBoxStyle.Exclamation)
                                'Return False
                            End If
                        End If
                    Next
                End If
            Next

            Return True
        Else
            myOwner.txtStartShip.Enabled = True
            myOwner.txtEndShip.Enabled = True
            Return True
        End If
    End Function

    Private Sub grdSCShip_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSCShip.CellClick
        If grdSCShip.CurrentCell.ColumnIndex = 0 Then
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_status").ReadOnly = False
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_creusr").ReadOnly = False

            If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_status").ToString = "Y" Then
                If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr").ToString = "~*NEW*~" Then
                    rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr") = "~*ADD*~"
                Else
                    rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr") = "~*UPD*~"
                End If

                rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_status") = " "
            Else
                If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr").ToString <> "~*ADD*~" Then
                    rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr") = "~*DEL*~"
                ElseIf rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr").ToString = "~*ADD*~" Then
                    rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr") = "~*NEW*~"
                End If

                rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_status") = "Y"
            End If

            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_status").ReadOnly = True
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_creusr").ReadOnly = True

            grdSCShip.Refresh()
            cal_Total()
        End If
    End Sub

    Private Sub grdSCShip_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdSCShip.EditingControlShowing
        If (sender.CurrentCell.ColumnIndex = 5 Or sender.CurrentCell.ColumnIndex = 6 Or sender.CurrentCell.ColumnIndex = 7) AndAlso TypeOf e.Control Is TextBox Then
            RemoveHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf CellKeyPress
            AddHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf CellKeyPress
        End If
    End Sub

    Private Sub CellKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If grdSCShip.CurrentCell.ColumnIndex = 5 Or grdSCShip.CurrentCell.ColumnIndex = 6 Then
            If Asc(e.KeyChar) = 8 Then
                Return
            ElseIf sender.Text.Length >= 10 And sender.SelectedText = "" Then
                e.KeyChar = Chr(0)
            ElseIf Asc(e.KeyChar) = 47 Then
                If Split(sender.Text, "/").Length < 3 And sender.Text.Length >= 2 Then
                    If IsNumeric(sender.Text.substring(sender.selectionstart - 2, 2)) Then
                        Return
                    Else
                        e.KeyChar = Chr(0)
                    End If
                Else
                    e.KeyChar = Chr(0)
                End If
            ElseIf IsNumeric(e.KeyChar) Then
                If Split(sender.Text, "/").Length = 1 Then
                    If sender.Text.Length >= 2 Then
                        e.KeyChar = Chr(0)
                    Else
                        Return
                    End If
                ElseIf Split(sender.Text, "/").Length = 2 Then
                    If Split(sender.Text, "/")(0).Length < 2 Then
                        Return
                    ElseIf IsNumeric(sender.Text.substring(sender.selectionstart - 2, 2)) Then
                        e.KeyChar = Chr(0)
                    Else
                        Return
                    End If
                Else
                    If Split(sender.Text, "/")(0).Length < 2 Then
                        Return
                    ElseIf Split(sender.Text, "/")(1).Length < 2 Then
                        Return
                    ElseIf IsNumeric(sender.Text.Substring(sender.Text.Length - 4, 4)) Then
                        e.KeyChar = Chr(0)
                    Else
                        Return
                    End If
                End If
                Return
            Else
                e.KeyChar = Chr(0)
            End If
        ElseIf grdSCShip.CurrentCell.ColumnIndex = 7 Then
            If Asc(e.KeyChar) = 8 Then
                Return
            ElseIf IsNumeric(e.KeyChar) Then
                Return
            Else
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub grdSCShip_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSCShip.CellEndEdit
        If grdSCShip.CurrentCell.ColumnIndex = 5 Then
            If sender.CurrentCell.Value.ToString.Length = 0 Then
                sender.CurrentCell.Value = Format(Date.Today, "MM/dd/yyyy")
            End If
        ElseIf grdSCShip.CurrentCell.ColumnIndex = 6 Then
            If sender.CurrentCell.Value.ToString.Length = 0 Then
                sender.CurrentCell.Value = Format(DateAdd(DateInterval.Day, 1, Date.Today), "MM/dd/yyyy")
            End If
        ElseIf grdSCShip.CurrentCell.ColumnIndex = 7 Then
            If sender.CurrentCell.Value.ToString = "" Or sender.CurrentCell.Value.ToString = "0" Then
                sender.CurrentCell.Value = "0"
            End If
            If Not IsNumeric(sender.CurrentCell.Value) Then
                MsgBox("Invalid Quantity")
                Exit Sub
            End If
            cal_Total()
        End If

        If rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr").ToString <> "~*ADD*~" And _
           rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr").ToString <> "~*DEL*~" And _
           rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr").ToString <> "~*NEW*~" Then
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_creusr").ReadOnly = False
            rs_SCDTLSHP_SUB.Tables("RESULT").DefaultView.Item(grdSCShip.CurrentCell.RowIndex)("sds_creusr") = "~*UPD*~"
            rs_SCDTLSHP_SUB.Tables("RESULT").Columns("sds_creusr").ReadOnly = True
        End If
    End Sub

    Private Sub grdSCShip_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdSCShip.DataError
        If grdSCShip.CurrentCell.ColumnIndex = 5 Or grdSCShip.CurrentCell.ColumnIndex = 6 Then
            MsgBox("Invalid Date or Date Format (MM/DD/YYYY)")
            grdSCShip.CurrentCell = grdSCShip.CurrentCell
            grdSCShip.BeginEdit(True)
        End If
    End Sub
End Class