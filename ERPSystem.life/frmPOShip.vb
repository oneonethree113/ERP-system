Public Class frmPOShip
    Public temp_rs_PODTLSHP As DataSet
    Public totalQty As Long
    Public temp_txtPurSeq As String
    Dim temp_RecordStatus As Boolean = False

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If temp_RecordStatus = True Then
            RaiseEvent returnSelectedRecords(Me, temp_RecordStatus, temp_rs_PODTLSHP)
        End If

        Me.Close()
    End Sub

    Public Sub New(ByVal rs_PODTLSHP As DataSet, ByVal cboPOStatus As ComboBox, ByVal txtPurSeq As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()


        If cboPOStatus.SelectedIndex = 0 Then
            grdPOShip.Enabled = True
            cmdInsRow.Visible = True
            'cmdDelRow.Visible = True
        Else
            grdPOShip.Enabled = False
            cmdInsRow.Visible = False
            'cmdDelRow.Visible = False
        End If

        temp_txtPurSeq = txtPurSeq
        temp_rs_PODTLSHP = rs_PODTLSHP.Copy()
        'grdAss.DataSource = rs_SAREQASS_SUB.Tables("RESULT").DefaultView
        Call cal_Total()
        For i As Integer = 0 To temp_rs_PODTLSHP.Tables("RESULT").Columns.Count - 1
            temp_rs_PODTLSHP.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        temp_rs_PODTLSHP.Tables("RESULT").DefaultView.AllowNew = False
        temp_rs_PODTLSHP.Tables("RESULT").DefaultView.RowFilter = "pds_seq = '" & txtPurSeq & "'"
        grdPOShip.DataSource = temp_rs_PODTLSHP.Tables("RESULT").DefaultView
        Display_GrdPOShip()


    End Sub

    '20150608 - Write a new constructor. The above one is not generic, some invoker amy not have cboPOStatus
    Public Sub New(ByVal rs_PODTLSHP As DataSet, ByVal txtPurseq As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        grdPOShip.Enabled = True
        cmdInsRow.Visible = False

        temp_txtPurSeq = txtPurseq
        temp_rs_PODTLSHP = rs_PODTLSHP.Copy()
        'grdAss.DataSource = rs_SAREQASS_SUB.Tables("RESULT").DefaultView
        Call cal_Total()
        For i As Integer = 0 To temp_rs_PODTLSHP.Tables("RESULT").Columns.Count - 1
            temp_rs_PODTLSHP.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        temp_rs_PODTLSHP.Tables("RESULT").DefaultView.AllowNew = False
        temp_rs_PODTLSHP.Tables("RESULT").DefaultView.RowFilter = "pds_seq = '" & txtPurseq & "'"
        grdPOShip.DataSource = temp_rs_PODTLSHP.Tables("RESULT").DefaultView
        Display_GrdPOShip()

    End Sub




    Private Sub Display_GrdPOShip()

        With grdPOShip
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Date From"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Date To"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Ord Qty"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Ctn Str"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Ctn End"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "# of Ctn"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Destination"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Remark"
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                        ' Remove when PODTLSHP is ready
                        .Columns(i).Visible = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next

            Dim totalCtn As Integer = 0
            For i As Integer = 0 To .Rows.Count - 1
                totalCtn = totalCtn + .Rows(i).Cells("pds_ttlctn").Value
            Next
            txtTotal.Text = totalCtn
        End With

    End Sub
    Public Event returnSelectedRecords(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal temp_rs_PODTLSHP As DataSet)

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Private Sub cal_Total()
        totalQty = 0
        If temp_rs_PODTLSHP.Tables("RESULT").Rows.Count > 0 Then
            'POM00001.rs_PODTLSHP.MoveFirst()
            'While Not POM00001.rs_PODTLSHP.EOF
            For i As Integer = 0 To temp_rs_PODTLSHP.Tables("RESULT").Rows.Count - 1

                If temp_rs_PODTLSHP.Tables("RESULT").Rows(i).Item("pds_status").ToString <> "Y" Then
                    totalQty = totalQty + temp_rs_PODTLSHP.Tables("RESULT").Rows(i).Item("pds_ttlctn")
                End If
            Next

            'POM00001.rs_PODTLSHP.MoveNext()
            'End While
        End If

        txtTotal.Text = totalQty
    End Sub

    'Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
    '    Dim book As Integer

    '    'If Not POM00001.rs_PODTLSHP.EOF Then
    '    grdPOShip.SelectedRows.ToString()
    '    book = POM00001.rs_PODTLSHP.AbsolutePosition
    '    If temp_rs_PODTLSHP_FILTER.Tables("RESULT").Rows(grdPOShip.SelectedRows).Item("pds_status") = "Y" Then
    '        grdPOShip.col = 0
    '        Call grdPOShip_DblClick()
    '    Else
    '        If POM00001.rs_PODTLSHP("pds_creusr") <> "~*ADD*~" Then

    '            POM00001.rs_PODTLSHP("pds_creusr") = "~*DEL*~"
    '            POM00001.rs_PODTLSHP("pds_status") = "Y"

    '        ElseIf POM00001.rs_PODTLSHP("pds_creusr") = "~*ADD*~" Then

    '            POM00001.rs_PODTLSHP("pds_creusr") = "~*NEW*~"
    '            POM00001.rs_PODTLSHP("pds_status") = "Y"

    '        End If
    '        Call cal_Total()
    '        POM00001.rs_PODTLSHP.AbsolutePosition = book

    '    End If
    '    'Else
    '    'msg("M00065")
    '    'End If
    'End Sub


    



    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click, cmdDelRow.Click
        'Dim book As Integer
        temp_RecordStatus = True
        If temp_rs_PODTLSHP.Tables("RESULT").Rows.Count > 0 Then
            Call cal_Total()
            'POM00001.rs_PODTLSHP.MoveFirst()
            'POM00001.rs_PODTLSHP.Find("pds_ttlctn = 0")
        End If

        'If POM00001.rs_PODTLSHP.EOF Then
        temp_rs_PODTLSHP.Tables("RESULT").Rows.Add()
        'book = POM00001.rs_PODTLSHP.AbsolutePosition
        '==
        Dim new_row_index As Integer = temp_rs_PODTLSHP.Tables("RESULT").Rows.Count - 1
        temp_rs_PODTLSHP.Tables("RESULT").Rows(new_row_index).Item("pds_seq") = temp_txtPurSeq
        temp_rs_PODTLSHP.Tables("RESULT").Rows(new_row_index).Item("pds_from") = Format(Now, "MM/dd/yyyy")
        temp_rs_PODTLSHP.Tables("RESULT").Rows(new_row_index).Item("pds_to") = Format(Now.AddDays(1), "MM/dd/yyyy")
        temp_rs_PODTLSHP.Tables("RESULT").Rows(new_row_index).Item("pds_ttlctn") = 0
        temp_rs_PODTLSHP.Tables("RESULT").Rows(new_row_index).Item("pds_creusr") = "~*ADD*~"
        temp_rs_PODTLSHP.Tables("RESULT").Rows(new_row_index).Item("pds_credat") = Format(Now, "MM/dd/yyyy")
        temp_rs_PODTLSHP.Tables("RESULT").Rows(new_row_index).Item("pds_upddat") = Format(Now, "MM/dd/yyyy")
        '==
        'POM00001.rs_PODTLSHP.Update()
        'POM00001.rs_PODTLSHP.AbsolutePosition = book
        'grdPOShip.col = 3
        grdPOShip.Focus()
        'Else
        'msg("M00331")
        'grdPOShip.SetFocus()
        'End If
    End Sub

    Private Sub grdPOShip_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPOShip.CellClick
        temp_RecordStatus = True
        If e.ColumnIndex = 0 Then

            temp_rs_PODTLSHP.Tables("RESULT").Columns("pds_status").ReadOnly = False
            temp_rs_PODTLSHP.Tables("RESULT").Columns("pds_creusr").ReadOnly = False

            If temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_status").ToString = "Y" Then 'del:  Y -> N
                temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_status") = ""
                If temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_creusr").ToString = "~*NEW*~" Then
                    temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_creusr") = "~*ADD*~"
                Else
                    temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_creusr") = "~*UPD*~"
                End If
                Call cal_Total()
            ElseIf temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_status").ToString = "" Then 'del:  N -> Y
                If temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_creusr") <> "~*ADD*~" Then

                    temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_creusr") = "~*DEL*~"
                    temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_status") = "Y"

                ElseIf temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_creusr") = "~*ADD*~" Then

                    temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_creusr") = "~*NEW*~"
                    temp_rs_PODTLSHP.Tables("RESULT").Rows(e.RowIndex).Item("pds_status") = "Y"

                End If

            End If


        End If
    End Sub

    Private Sub frmPOShip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class