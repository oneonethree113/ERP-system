Public Class SCM00001_ShpmrkAtchmt

    Const strModule As String = "SC"

    Dim rs_ScTpSmk As DataSet
    Dim rs_scno As DataSet
    Dim init As Boolean = False

    Private Sub SCM00001_Atchmt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getDefault_Path()

        gspStr = "sp_list_SCTPSMRK '" & cboCoCde.Text & "','XXX'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_ScTpSmk, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> "0" Then  '*** An error has occured
            MsgBox("Error on loading SCM00004 #001 sp_list_SCTPSMRK : " & rtnStr)
            Close()
        Else
            For i As Integer = 0 To rs_ScTpSmk.Tables("RESULT").Columns.Count - 1
                rs_ScTpSmk.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        init = True
        imgShipMark.Image = Nothing
        cmdFind()
        init = False
    End Sub

    Public Sub setCompanyCode(ByVal cocde As String, ByVal conam As String)
        If cboCoCde.Text <> cocde Then
            If cboCoCde.Items.Contains(cocde) = False Then
                cboCoCde.Items.Add(cocde)
            End If
            cboCoCde.Text = cocde
            txtCoNam.Text = conam
        End If
    End Sub

    Public Sub setSCNo(ByVal scNo As String)
        txtSCNo.Text = scNo
    End Sub

    Private Sub cmdFind()
        Dim rs_ATH As DataSet
        Dim SCNo As String = UCase(Trim(Me.txtSCNo.Text))

        If SCNo.Length = 0 Then
            MsgBox("Missing SC No.")
            Close()
        End If

        lstSelShipMark.Items.Clear()

        gspStr = "sp_select_SCM00004_SM '" & cboCoCde.Text & "','" & SCNo & "','" & SCNo & "','" & gsUsrID & _
                 "','" & strModule & "','X'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_scno, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00001_Atchmt #001 sp_select_SCM00004_SM : " & rtnStr)
            Exit Sub
        End If

        If rs_scno.Tables("RESULT").Rows.Count > 0 Then
            gspStr = "sp_select_SCM00004_ATH '" & cboCoCde.Text & "','" & SCNo & "','" & SCNo & "','" & gsUsrID & _
                     "','" & strModule & "','X'"
            rs_ATH = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_ATH, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading SCM00001_Atchmt #002 sp_select_SCM00004_ATH : " & rtnStr)
                Exit Sub
            Else
                If rs_ATH.Tables("RESULT").Rows.Count > 0 Then
                    For i As Integer = 0 To rs_ATH.Tables("RESULT").Rows.Count - 1
                        rs_ScTpSmk.Tables("RESULT").Rows.Add()
                        rs_ScTpSmk.Tables("RESULT").Rows(rs_ScTpSmk.Tables("RESULT").Rows.Count - 1)("stm_cocde") = rs_ATH.Tables("RESULT").Rows(i)("stm_cocde")
                        rs_ScTpSmk.Tables("RESULT").Rows(rs_ScTpSmk.Tables("RESULT").Rows.Count - 1)("stm_ordnoseq") = rs_ATH.Tables("RESULT").Rows(i)("scseq")
                        rs_ScTpSmk.Tables("RESULT").Rows(rs_ScTpSmk.Tables("RESULT").Rows.Count - 1)("stm_ordno") = Trim(Split(rs_ATH.Tables("RESULT").Rows(i)("scseq"), "-")(0))
                        rs_ScTpSmk.Tables("RESULT").Rows(rs_ScTpSmk.Tables("RESULT").Rows.Count - 1)("stm_ordseq") = Trim(Split(rs_ATH.Tables("RESULT").Rows(i)("scseq"), "-")(1))
                        rs_ScTpSmk.Tables("RESULT").Rows(rs_ScTpSmk.Tables("RESULT").Rows.Count - 1)("stm_smkno") = rs_ATH.Tables("RESULT").Rows(i)("stm_smkno")
                        rs_ScTpSmk.Tables("RESULT").Rows(rs_ScTpSmk.Tables("RESULT").Rows.Count - 1)("stm_creusr") = rs_ATH.Tables("RESULT").Rows(i)("stm_creusr")
                        rs_ScTpSmk.AcceptChanges()
                    Next
                End If
            End If


            cboCoCde.Enabled = False
            grdNewOrder.DataSource = rs_scno.Tables("RESULT").DefaultView
            Display_grdNewOrder()
        Else
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No record found")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub Display_grdNewOrder()
        With grdNewOrder
            For i As Integer = 0 To grdNewOrder.Columns.Count - 1
                Select Case i
                    Case 2
                        .Columns(i).HeaderText = "Seq No."
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Job No."
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Item No."
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Uploaded"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
            .ClearSelection()
        End With
    End Sub

    Private Sub grdNewOrder_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdNewOrder.Sorted
        sender.ClearSelection()
    End Sub

    Private Sub grdNewOrder_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNewOrder.RowEnter
        'If sender.Focused = True Then
        If init <> True Then
            If e.RowIndex >= 0 Then
                lstSelShipMark.Items.Clear()
                Dim dr() As DataRow = rs_ScTpSmk.Tables("RESULT").Select("stm_ordno = '" & grdNewOrder.Rows(e.RowIndex).Cells("sod_ordno").Value & "' and stm_ordseq = '" & grdNewOrder.Rows(e.RowIndex).Cells("sod_ordseq").Value & "'")
                If dr.Length > 0 Then
                    For i As Integer = 0 To dr.Length - 1
                        If dr(i).Item("stm_creusr") <> "DEL" And dr(i).Item("stm_creusr") <> "NEW" Then
                            lstSelShipMark.Items.Add(dr(i).Item("stm_smkno"))
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub chkPreview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreview.CheckedChanged
        displayPreview()
    End Sub

    Private Sub displayPreview()
        If chkPreview.Checked Then
            If Not lstSelShipMark.SelectedItem Is Nothing Then
                imgShipMark.Load(gs_PDO_SMImg & lstSelShipMark.SelectedItem.ToString)
                imgShipMark.SizeMode = PictureBoxSizeMode.Zoom
                imgShipMark.Visible = True
            End If
        Else
            imgShipMark.Image = Nothing
            imgShipMark.Visible = False
        End If
    End Sub

    Private Sub lstSelShipMark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSelShipMark.SelectedIndexChanged
        If chkPreview.Checked Then
            displayPreview()
        End If
    End Sub

    Private Sub imgShipMark_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgShipMark.DoubleClick
        If lstSelShipMark.SelectedItems.Count > 0 Then
            Dim imgPreview As New frmImgPrevw
            imgPreview.setImagePath(gs_PDO_SMImg & lstSelShipMark.SelectedItem.ToString)
            imgPreview.ShowDialog()
        End If
    End Sub
End Class