Public Class frmSCCarton

    Public myOwner As SCM00001

    Dim rs_SCDTLCTN_SUB As DataSet
    Dim total As Long
    Dim sFilter As String
    Private Sub frmSCCarton_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs_SCDTLCTN_SUB = myOwner.rs_SCDTLCTN.Copy()

        sFilter = "sdc_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")
        rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter
        grdSCCarton.DataSource = rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView

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
        If SCCartonVaildFromTo Then
            If SCcartonVaild() Then
                rs_SCDTLCTN_SUB.AcceptChanges()
                myOwner.rs_SCDTLCTN = rs_SCDTLCTN_SUB.Copy()
                myOwner.rs_SCDTLCTN.AcceptChanges()
                Dim dr() As DataRow = rs_SCDTLCTN_SUB.Tables("RESULT").Select("sdc_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq") & " and sdc_status <> 'Y'", "sdc_from")
                If dr.Length > 0 Then
                    myOwner.txtStartCarton.Text = dr(0)("sdc_from")
                    dr = Nothing
                    dr = rs_SCDTLCTN_SUB.Tables("RESULT").Select("sdc_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq") & " and sdc_status <> 'Y'", "sdc_to")
                    myOwner.txtEndCarton.Text = dr(dr.Length - 1)("sdc_to")
                End If
                Close()
            End If
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            cal_Total()
            With rs_SCDTLCTN_SUB.Tables("RESULT")
                For i As Integer = 0 To .DefaultView.Count - 1
                    If .DefaultView.Item(i)("sdc_status").ToString <> "Y" And .DefaultView.Item(i)("sdc_ttlctn") = 0 Then
                        grdSCCarton.Rows(i).Selected = True
                        Exit Sub
                    End If
                Next
            End With
        End If

        Dim newRow As DataRow = rs_SCDTLCTN_SUB.Tables("RESULT").NewRow
        newRow.Item("sdc_status") = " "
        newRow.Item("sdc_seq") = myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")
        newRow.Item("sdc_from") = 1
        newRow.Item("sdc_to") = 1
        newRow.Item("sdc_ttlctn") = 1
        newRow.Item("sdc_creusr") = "~*ADD*~"
        newRow.Item("sdc_credat") = Date.Now
        newRow.Item("sdc_upddat") = Date.Now
        rs_SCDTLCTN_SUB.Tables("RESULT").Rows.Add(newRow)
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        If grdSCCarton.SelectedRows.Count > 0 Then
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_status").ReadOnly = False
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_creusr").ReadOnly = False
            For i As Integer = 0 To grdSCCarton.SelectedRows.Count - 1
                If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_status").ToString = "Y" Then
                    If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_creusr").ToString = "~*NEW*~" Then
                        rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_creusr") = "~*ADD*~"
                    Else
                        rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_creusr") = "~*UPD*~"
                    End If

                    rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_status") = " "
                Else
                    If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_creusr").ToString <> "~*ADD*~" Then
                        rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_creusr") = "~*DEL*~"
                    ElseIf rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_creusr").ToString = "~*ADD*~" Then
                        rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_creusr") = "~*NEW*~"
                    End If

                    rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.SelectedRows(i).Index)("sdc_status") = "Y"
                End If
            Next
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_status").ReadOnly = True
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_creusr").ReadOnly = True

            grdSCCarton.Refresh()
            cal_Total()
        End If
    End Sub

    Private Sub LockGrd()
        Dim i As Integer
        For i = 0 To grdSCCarton.Columns.Count - 1
            grdSCCarton.Columns(i).ReadOnly = True
        Next i
    End Sub

    Private Sub cal_Total()
        total = 0
        If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            For i As Integer = 0 To rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count - 1
                If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)("sdc_status").ToString <> "Y" Then
                    total = total + rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)("sdc_ttlctn")
                End If
            Next
        End If

        txtTotal.Text = total
    End Sub

    Private Sub Display()
        With grdSCCarton
            For i As Integer = 0 To rs_SCDTLCTN_SUB.Tables("RESULT").Columns.Count - 1
                rs_SCDTLCTN_SUB.Tables("RESULT").Columns(i).ReadOnly = False
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
                        .Columns(i).HeaderText = "Number of Cartons"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Function SCcartonVaildFromTo() As Boolean
        If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            For i As Integer = 0 To rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count - 1
                If Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)("sdc_from")) > Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)("sdc_to")) And _
                   rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)(0).ToString <> "Y" Then
                    grdSCCarton.Rows(i).Selected = True
                    MsgBox("Start Carton > End Carton", MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next
            Return True
        Else
            Return True
        End If
    End Function

    Function SCcartonVaild() As Boolean
        If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count > 0 Then
            Dim dr() As DataRow
            dr = rs_SCDTLCTN_SUB.Tables("RESULT").Select("sdc_seq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq") & " and sdc_status <> 'Y'")
            If dr.Length = 0 Then
                myOwner.txtStartCarton.Enabled = True
                myOwner.txtEndCarton.Enabled = True
                Return True
            End If

            If txtTotal.Text <> myOwner.lblTotalCtn.Text Then
                myOwner.txtStartCarton.Enabled = False
                myOwner.txtEndCarton.Enabled = False
                MsgBox("Total Ship Qty not Equal to Order Qty", MsgBoxStyle.Exclamation)
                Return False
            End If

            myOwner.txtStartCarton.Enabled = False
            myOwner.txtEndCarton.Enabled = False

            Dim start_Carton As Integer
            Dim end_Carton As Integer
            For i As Integer = 0 To rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count - 1
                If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)("sdc_status").ToString <> "Y" Then
                    start_Carton = Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)("sdc_from").ToString)
                    end_Carton = Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(i)("sdc_to").ToString)
                    For j As Integer = 0 To rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Count - 1
                        If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(j)("sdc_status").ToString <> "Y" And i <> j Then
                            If (start_Carton <= Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(j)("sdc_from").ToString) And _
                               end_Carton >= Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(j)("sdc_from").ToString)) Or _
                               (start_Carton <= Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(j)("sdc_to").ToString) And _
                               end_Carton >= Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(j)("sdc_to").ToString)) Or _
                               (start_Carton >= Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(j)("sdc_from").ToString) And _
                               end_Carton <= Val(rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(j)("sdc_to").ToString)) Then
                                grdSCCarton.Rows(i).Selected = True
                                grdSCCarton.Rows(j).Selected = True
                                MsgBox("Duplicate Carton Number!", MsgBoxStyle.Exclamation)
                                Return False
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

    Private Sub grdSCCarton_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSCCarton.CellClick
        If grdSCCarton.CurrentCell.ColumnIndex = 0 Then
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_status").ReadOnly = False
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_creusr").ReadOnly = False

            If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_status").ToString = "Y" Then
                If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr").ToString = "~*NEW*~" Then
                    rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr") = "~*ADD*~"
                Else
                    rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr") = "~*UPD*~"
                End If

                rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_status") = " "
            Else
                If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr").ToString <> "~*ADD*~" Then
                    rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr") = "~*DEL*~"
                ElseIf rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr").ToString = "~*ADD*~" Then
                    rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr") = "~*NEW*~"
                End If

                rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_status") = "Y"
            End If

            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_status").ReadOnly = True
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_creusr").ReadOnly = True

            grdSCCarton.Refresh()
            cal_Total()
        End If
    End Sub

    Private Sub grdSCCarton_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdSCCarton.EditingControlShowing
        If (sender.CurrentCell.ColumnIndex = 5 Or sender.CurrentCell.ColumnIndex = 6) AndAlso TypeOf e.Control Is TextBox Then
            RemoveHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf CellKeyPress
            AddHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf CellKeyPress
        End If
    End Sub

    Private Sub CellKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Then
            Return
        ElseIf sender.Text.Length >= 10 And sender.SelectedText = "" Then
            e.KeyChar = Chr(0)
        ElseIf IsNumeric(e.KeyChar) Then
            Return
        Else
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub grdSCCarton_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSCCarton.CellEndEdit
        If grdSCCarton.CurrentCell.ColumnIndex = 5 Then
            If sender.CurrentCell.Value.ToString.Length = 0 Then
                sender.CurrentCell.Value = 1
            End If
        ElseIf grdSCCarton.CurrentCell.ColumnIndex = 6 Then
            If sender.CurrentCell.Value.ToString.Length = 0 Then
                sender.CurrentCell.Value = 1
            End If
        End If

        cal_SubTotal()
        cal_Total()

        If rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr").ToString <> "~*ADD*~" And _
           rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr").ToString <> "~*DEL*~" And _
           rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr").ToString <> "~*NEW*~" Then
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_creusr").ReadOnly = False
            rs_SCDTLCTN_SUB.Tables("RESULT").DefaultView.Item(grdSCCarton.CurrentCell.RowIndex)("sdc_creusr") = "~*UPD*~"
            rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_creusr").ReadOnly = True
        End If
    End Sub

    Private Sub cal_SubTotal()
        rs_SCDTLCTN_SUB.Tables("RESULT").Columns("sdc_ttlctn").ReadOnly = False
        grdSCCarton.Rows(grdSCCarton.CurrentCell.RowIndex).Cells("sdc_ttlctn").Value = grdSCCarton.Rows(grdSCCarton.CurrentCell.RowIndex).Cells("sdc_to").Value - grdSCCarton.Rows(grdSCCarton.CurrentCell.RowIndex).Cells("sdc_from").Value + 1
    End Sub
End Class