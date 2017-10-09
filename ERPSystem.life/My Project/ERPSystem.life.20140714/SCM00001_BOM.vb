Public Class SCM00001_BOM
    Inherits System.Windows.Forms.Form

    Public myOwner As SCM00001

    Public rs_SCBOMINF_SUB As DataSet
    Dim rs_SCBOMINF_SUB_BAK As DataSet

    Dim Enq_right_local As Boolean
    Dim lng_colBOMPOFlg As Integer

    Private Sub SCM00001_BOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs_SCBOMINF_SUB = myOwner.rs_SCBOMINF.Copy()

        Dim sFilter As String
        sFilter = "sbi_ordseq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")

        rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter

        grdBOM.DataSource = rs_SCBOMINF_SUB.Tables("RESULT").DefaultView
        Enq_right_local = Enq_right

        Display_BOM()
        If (Split(myOwner.cboSCStatus.Text, " - ")(0) = "ACT" Or Split(myOwner.cboSCStatus.Text, " - ")(0) = "HLD") And myOwner.cmdSave.Enabled = True Then
            cmdOK.Enabled = True

            If (gsUsrRank <= 4 And Enq_right_local) Or gsUsrGrp = "MGT-S" Then
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
        Dim dr() As DataRow

        If rs_SCBOMINF_SUB.Tables("RESULT").Rows.Count > 0 Then
            rs_SCBOMINF_SUB_BAK = rs_SCBOMINF_SUB.Copy()
            myOwner.UpdBOMItm()
            rs_SCBOMINF_SUB = Nothing
            rs_SCBOMINF_SUB = myOwner.rs_SCBOMINF.Copy()
            Dim sFilter As String
            sFilter = "sbi_ordseq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")
            rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter

            rs_SCBOMINF_SUB.Tables("RESULT").Columns(lng_colBOMPOFlg).ReadOnly = False
            If rs_SCBOMINF_SUB.Tables.Count > 0 Then
                If myOwner.rs_SCBOMINF.Tables.Count > 0 Then
                    With rs_SCBOMINF_SUB.Tables("RESULT").DefaultView
                        For i As Integer = 0 To .Count - 1
                            dr = Nothing
                            dr = rs_SCBOMINF_SUB_BAK.Tables("RESULT").Select("sbi_ordno = '" & .Item(i)("sbi_ordno") & "' and sbi_ordseq = " & .Item(i)("sbi_ordseq") & " and sbi_itmno = '" & .Item(i)("sbi_itmno") & "' and sbi_assitm = '" & .Item(i)("sbi_assitm") & "' and sbi_colcde = '" & .Item(i)("sbi_colcde") & "'")
                            If dr.Length > 0 Then
                                .Item(i)(lng_colBOMPOFlg) = dr(0).Item(lng_colBOMPOFlg)
                            End If
                        Next
                    End With
                End If
            End If
            rs_SCBOMINF_SUB.Tables("RESULT").Columns(lng_colBOMPOFlg).ReadOnly = True
            myOwner.chkUpdatePO.Checked = True
            Display_BOM()
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        rs_SCBOMINF_SUB.AcceptChanges()
        myOwner.rs_SCBOMINF = rs_SCBOMINF_SUB.Copy()
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Public Sub setDataSet(ByVal ds As DataSet)
        rs_SCBOMINF_SUB = ds.Copy()
    End Sub

    Private Sub Display_BOM()
        With grdBOM
            'sbi_ordno(--0)
            'sbi_ordseq(--1)
            'sbi_itmno(--2)
            'sbi_assitm(--3)
            'sbi_assinrqty(--4)
            'sbi_mtrqty(--5)
            'sbi_bomitm(--6)
            'sbi_venno(--7)
            'sbi_bomdsce(--8)
            'sbi_bomdscc(--9)
            'sbi_colcde(--10)
            'sbi_coldsc(--11)
            'sbi_pckunt(--12)
            'sbi_ordqty(--13)
            'sbi_fcurcde(--14)
            'sbi_ftyprc(--15)
            'sbi_bcurcde(--16)
            'sbi_bomcst(--17)
            'sbi_obcurcde(--18)
            'sbi_obomcst(--19)
            'sbi_obomprc(--20)
            'sbi_creusr(--21)

            For i As Integer = 0 To rs_SCBOMINF_SUB.Tables("RESULT").Columns.Count - 1
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 3
                        .Columns(i).HeaderText = "Assorted Item #"
                        .Columns(i).Width = 140
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "BOM Item #"
                        .Columns(i).Width = 140
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Vendor No."
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "English Description"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Chinese Description"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Color Code"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Color Description"
                        .Columns(i).Width = 140
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "BOM IM Period"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "Qty"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 15
                        .Columns(i).HeaderText = "CUR"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 16
                        .Columns(i).HeaderText = "Current Fty Cost"
                        .Columns(i).Width = 125
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 17
                        .Columns(i).HeaderText = "CUR"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 18
                        .Columns(i).HeaderText = "Current BOM Cost"
                        .Columns(i).Width = 125
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 19
                        .Columns(i).HeaderText = "[Stored in IM] CUR"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 20
                        .Columns(i).HeaderText = "[Stored in IM] BOM Cost"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 21
                        .Columns(i).HeaderText = "[Stored in IM] BOM Price"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 24
                        .Columns(24).HeaderText = "BOM PO Flg"
                        .Columns(24).Width = 100
                        .Columns(24).ReadOnly = True
                        .Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        lng_colBOMPOFlg = i
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Private Sub LockGrd()
        Dim i As Integer
        For i = 0 To grdBOM.Columns.count - 1
            grdBOM.Columns(i).ReadOnly = True
        Next i
    End Sub


    Private Sub grdBOM_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBOM.CellClick
        If grdBOM.SelectedCells.Count = 1 Then
            If grdBOM.CurrentCell.ColumnIndex = 24 Then
                rs_SCBOMINF_SUB.Tables("RESULT").Columns(lng_colBOMPOFlg).ReadOnly = False
                'rs_SCBOMINF_SUB.Tables("RESULT").Columns("sbi_creusr").ReadOnly = False
                If rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.Item(grdBOM.CurrentCell.RowIndex)(lng_colBOMPOFlg).ToString = "Y" Then
                    rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.Item(grdBOM.CurrentCell.RowIndex)(lng_colBOMPOFlg) = "N"
                Else
                    rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.Item(grdBOM.CurrentCell.RowIndex)(lng_colBOMPOFlg) = "Y"
                End If
                'If rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.Item(grdBOM.CurrentCell.RowIndex)("sbi_creusr").ToString <> "~*ADD*~" And _
                '   rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.Item(grdBOM.CurrentCell.RowIndex)("sbi_creusr").ToString <> "~*DEL*~" And _
                '   rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.Item(grdBOM.CurrentCell.RowIndex)("sbi_creusr").ToString <> "~*NEW*~" Then
                '    rs_SCBOMINF_SUB.Tables("RESULT").DefaultView.Item(grdBOM.CurrentCell.RowIndex)("sbi_creusr") = "~*UPD*~"
                'End If
                grdBOM.Refresh()
                rs_SCBOMINF_SUB.Tables("RESULT").Columns(lng_colBOMPOFlg).ReadOnly = True
                'rs_SCBOMINF_SUB.Tables("RESULT").Columns("sbi_creusr").ReadOnly = True
            End If
        End If
    End Sub
End Class