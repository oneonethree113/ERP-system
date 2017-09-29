Public Class SCM00001_ASS

    Public myOwner As SCM00001

    Dim rs_SCASSINF_SUB As DataSet
    Dim rs_SCASSINF_SUB_ORG As DataSet

    Dim Enq_right_local As Boolean

    Private Sub SCM00001_ASS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs_SCASSINF_SUB = myOwner.rs_SCASSINF.Copy()
        rs_SCASSINF_SUB_ORG = myOwner.rs_SCASSINF.Copy()

        grdASS.DataSource = rs_SCASSINF_SUB
        Dim sFilter As String
        sFilter = "sai_ordseq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")

        rs_SCASSINF_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter

        grdASS.DataSource = rs_SCASSINF_SUB.Tables("RESULT").DefaultView
        Enq_right_local = Enq_right

        Display_Ass()
        If (Split(myOwner.cboSCStatus.Text, " - ")(0) = "ACT" Or Split(myOwner.cboSCStatus.Text, " - ")(0) = "HLD") And myOwner.cmdSave.Enabled = True Then
            cmdOK.Enabled = True

            '            If (gsUsrRank <= 4 And Enq_right_local) Or gsUsrGrp = "MGT-S" Then
            If (Enq_right_local) Or gsUsrGrp = "MGT-S" Then
                cmdUpdate.Enabled = True
            Else
                cmdUpdate.Enabled = False
            End If
        Else
            cmdOK.Enabled = False
            cmdUpdate.Enabled = False
            LockGrd()
        End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If rs_SCASSINF_SUB.Tables.Count > 0 Then
            If rs_SCASSINF_SUB.Tables("RESULT").Rows.Count > 0 Then
                myOwner.UpdASSItm()
                rs_SCASSINF_SUB = Nothing
                rs_SCASSINF_SUB = myOwner.rs_SCASSINF.Copy()

                grdASS.DataSource = rs_SCASSINF_SUB
                Dim sFilter As String
                sFilter = "sai_ordseq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")
                rs_SCASSINF_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter
                grdASS.DataSource = rs_SCASSINF_SUB.Tables("RESULT").DefaultView

                myOwner.chkUpdatePO.Checked = True
                Display_Ass()
            End If
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        rs_SCASSINF_SUB.AcceptChanges()
        myOwner.rs_SCASSINF = rs_SCASSINF_SUB.Copy()
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        myOwner.rs_SCASSINF = rs_SCASSINF_SUB_ORG.Copy()
        Close()
    End Sub

    Private Sub Display_Ass()
        With grdASS
            For i As Integer = 0 To rs_SCASSINF_SUB.Tables("RESULT").Columns.Count - 1
                rs_SCASSINF_SUB.Tables("RESULT").Columns(i).ReadOnly = False
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 3
                        .Columns(i).HeaderText = "Assorted Item #"
                        .Columns(i).Width = 140
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Item Description"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = False
                    Case 5
                        .Columns(i).HeaderText = "Cust Item #"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = False
                    Case 6
                        .Columns(i).HeaderText = "Color Code"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Color Description"
                        .Columns(i).Width = 140
                        .Columns(i).ReadOnly = False
                    Case 8
                        .Columns(i).HeaderText = "SKU #"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = False
                    Case 9
                        .Columns(i).HeaderText = "UPC#/EAN#"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = False
                    Case 10
                        .Columns(i).HeaderText = "Cust. Retail"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = False
                    Case 11
                        .Columns(i).HeaderText = "ASSd IM Period"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "Qty Per Inner"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "Qty Per Master"
                        .Columns(i).Width = 105
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Private Sub LockGrd()
        Dim i As Integer
        For i = 0 To grdASS.Columns.Count - 1
            grdASS.Columns(i).ReadOnly = True
        Next i
    End Sub
    
    Private Sub grdASS_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdASS.EditingControlShowing
        If (grdASS.CurrentCell.ColumnIndex = 4 Or grdASS.CurrentCell.ColumnIndex = 5 Or grdASS.CurrentCell.ColumnIndex = 7 Or _
            grdASS.CurrentCell.ColumnIndex = 8 Or grdASS.CurrentCell.ColumnIndex = 9 Or grdASS.CurrentCell.ColumnIndex = 10) AndAlso TypeOf e.Control Is TextBox Then
            RemoveHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf CellKeyPress
            AddHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf CellKeyPress
        End If
    End Sub

    Private Sub CellKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If grdASS.CurrentCell.ColumnIndex = 4 Then
            If sender.Text.Length >= 1600 And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
                e.KeyChar = Chr(0)
            End If
        ElseIf grdASS.CurrentCell.ColumnIndex = 5 Then
            If sender.Text.Length >= 40 And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
                e.KeyChar = Chr(0)
            End If
        ElseIf grdASS.CurrentCell.ColumnIndex = 7 Then
            If sender.Text.Length >= 600 And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
                e.KeyChar = Chr(0)
            End If
        ElseIf grdASS.CurrentCell.ColumnIndex = 8 Then
            If sender.Text.Length >= 40 And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
                e.KeyChar = Chr(0)
            End If
        ElseIf grdASS.CurrentCell.ColumnIndex = 9 Then
            If sender.Text.Length >= 30 And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
                e.KeyChar = Chr(0)
            ElseIf Asc(e.KeyChar) = 8 Then
                Return
            ElseIf Not IsNumeric(e.KeyChar) Then
                e.KeyChar = Chr(0)
            End If
        ElseIf grdASS.CurrentCell.ColumnIndex = 10 Then
            If sender.Text.Length >= 40 And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
                e.KeyChar = Chr(0)
            ElseIf Asc(e.KeyChar) = 46 Then
                If sender.Text.Contains(".") Then
                    e.KeyChar = Chr(0)
                End If
            ElseIf Asc(e.KeyChar) = 8 Then
                Return
            ElseIf Not IsNumeric(e.KeyChar) Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub grdASS_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdASS.CellEndEdit
        If rs_SCASSINF_SUB.Tables("RESULT").DefaultView.Item(grdASS.CurrentCell.RowIndex)("sai_creusr").ToString <> "~*ADD*~" And _
           rs_SCASSINF_SUB.Tables("RESULT").DefaultView.Item(grdASS.CurrentCell.RowIndex)("sai_creusr").ToString <> "~*DEL*~" And _
           rs_SCASSINF_SUB.Tables("RESULT").DefaultView.Item(grdASS.CurrentCell.RowIndex)("sai_creusr").ToString <> "~*NEW*~" Then
            rs_SCASSINF_SUB.Tables("RESULT").Columns("sai_creusr").ReadOnly = False
            rs_SCASSINF_SUB.Tables("RESULT").DefaultView.Item(grdASS.CurrentCell.RowIndex)("sai_creusr") = "~*UPD*~"
            rs_SCASSINF_SUB.Tables("RESULT").Columns("sai_creusr").ReadOnly = True
        End If
    End Sub
End Class