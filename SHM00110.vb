Public Class SHM00110
    Dim flg_firstenter As Boolean = True
    Dim flg_search As Boolean = False
    Dim ENQ_right_local As Boolean
    Dim del_right_local As Boolean

    'User input value
    Dim _custno As String
    Dim _itemno As String
    Dim _packterm As String

    Dim ds_custno As New DataSet
    Dim ds_ship As New DataSet
    Dim ds_carton As New DataSet

    Dim dr_ship() As DataRow

    Dim shipindex As New ArrayList
    Dim shiprange As New ArrayList
    'Dim bindsrcHis As New BindingSource

    Dim his_header() As String

    Dim current_shipindex As Integer = 0
    Dim current_shipno As String
    Dim current_shipseq As Integer

    Private Sub SHM00110_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            ENQ_right_local = Enq_right
            del_right_local = Del_right

            'Only run once when initial loading
            If flg_firstenter Then
                'Load Customer list
                FillCustCombo()
                SetHisHeader()

                flg_firstenter = False
            End If


        Finally
            Me.Cursor = Windows.Forms.Cursors.Default

        End Try
    End Sub

    'Customer No related Start
    Private Sub FillCustCombo()
        gspStr = "sp_list_CUBASINF '" & gsCompany & "','" & "PA" & "'"
        rtnLong = execute_SQLStatement(gspStr, ds_custno, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00036 sp_list_CUBASINF : " & rtnStr & vbCrLf & "gspStr = " & gspStr)
            Exit Sub
        Else
            Dim dr As DataRowCollection
            dr = ds_custno.Tables("RESULT").Rows
            If dr.Count > 0 Then
                For Each tmp_dr As DataRow In dr
                    cboCusNo.Items.Add(tmp_dr.Item("cbi_cusno") + " - " + tmp_dr.Item("cbi_cussna"))
                Next
            End If
        End If
    End Sub

    Private Sub cb_custno_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCusNo.KeyUp
        If e.KeyCode <> Keys.Back Then
            Call auto_search_combo(sender)
        End If
    End Sub

    Private Sub cb_custno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCusNo.Validating
        Dim tmpbox As ComboBox = CType(sender, ComboBox)
        If tmpbox.Text = "" Then
            Exit Sub
        ElseIf tmpbox.Items.Contains(tmpbox.Text) = False Then
            MsgBox("Invalid Customer No.! Pls try again.")
            e.Cancel = True
        End If
    End Sub
    'Customer No related End

    Private Sub txt_itmno_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_itmno.KeyUp
        If e.KeyCode = Keys.Enter Then
            Call btn_packfind_Click(Nothing, Nothing)
        End If
    End Sub

    'DataGrid Control Start
    Private Sub dg_historyMouseup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_history.MouseUp
        Dim hit As DataGridView.HitTestInfo = dg_history.HitTest(e.X, e.Y)
        If hit.RowIndex <> -1 Then
            current_shipno = dg_history.Rows(hit.RowIndex).Cells("hpd_shpno").Value
            current_shipseq = dg_history.Rows(hit.RowIndex).Cells("hpd_shpseq").Value
            txt_shipno.Text = current_shipno
            txt_shipseq.Text = current_shipseq

            current_shipindex = lookup_shipindex(hit.RowIndex)

        End If

    End Sub

    'Button Control Start
    Private Sub btn_packfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_packfind.Click
        ds_ship.Reset()
        cbopackterms.Items.Clear()
        shipindex.Clear()
        shiprange.Clear()

        _custno = If(cboCusNo.Text = "", "", cboCusNo.Text.Substring(0, 5))
        _itemno = txt_itmno.Text

        gspStr = "sp_select_SHM00110 '','" & _custno & "','" & _itemno & "'"
        rtnLong = execute_SQLStatement(gspStr, ds_ship, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading MSR00036 sp_select_SHM00110 : " & rtnStr & vbCrLf & "gspStr = " & gspStr)
            Exit Sub
        Else
            Dim dr As DataRowCollection
            Dim tmp_table As DataTable = ds_ship.Tables("RESULT").DefaultView.ToTable(True, "packterms")

            Dim current_table As DataTable = ds_ship.Tables("RESULT")

            dr = tmp_table.Rows
            If dr.Count > 0 Then
                For Each tmp_dr As DataRow In dr
                    cbopackterms.Items.Add(tmp_dr.Item("packterms"))
                Next
            Else
                MsgBox("No Packing Terms found")
            End If
        End If

    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        If cbopackterms.Text = "" Then
            MsgBox("Packing Terms cannot be empty!")
            Exit Sub
        End If



        _packterm = cbopackterms.Text

        dr_ship = ds_ship.Tables("RESULT").Select("packterms = '" + cbopackterms.Text + "'")
        ds_carton.Reset()

        Dim rowcount As Boolean = get_Dataset_Carton()

        If rowcount = 0 Then
            MsgBox("No result found")
            Exit Sub
        End If

        Call set_dgHistory()
        Call set_uppercontrol(False)

        TabControl1.SelectedIndex = 0
        GroupBox3.Visible = True

        flg_search = True

        current_shipno = shipindex(0).ShipNo
        current_shipseq = shipindex(0).ShipSeq
        txt_shipno.Text = current_shipno
        txt_shipseq.Text = current_shipseq

    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        dg_history.DataSource = Nothing
        dg_detail.DataSource = Nothing
        cbopackterms.Items.Clear()

        current_shipindex = 0

        flg_search = False
        Call set_uppercontrol(True)
        GroupBox3.Visible = False

    End Sub

    Private Sub btn_previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_previous.Click
        If current_shipindex <> 0 Then
            'While (shiprange(current_shipindex) = shiprange(current_shipindex - 1))
            '    current_shipindex = current_shipindex - 1
            '    If current_shipindex = 0 Then
            '        Exit While
            '    End If
            'End While

            current_shipindex = current_shipindex - 1

            current_shipno = shipindex(current_shipindex).ShipNo
            current_shipseq = shipindex(current_shipindex).ShipSeq
            txt_shipno.Text = current_shipno
            txt_shipseq.Text = current_shipseq

            If TabControl1.SelectedIndex = 0 Then
                dg_history.ClearSelection()
                dg_history.Rows(lookup_rowno(current_shipindex)).Selected = True
                dg_history.CurrentCell = dg_history.Rows(lookup_rowno(current_shipindex)).Cells(1)
            Else
                Call set_dgDetail()
            End If

        End If
    End Sub

    Private Sub btn_next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
        If current_shipindex <> shipindex.Count - 1 Then

            'While (shiprange(current_shipindex) = shiprange(current_shipindex + 1))
            '    current_shipindex = current_shipindex + 1
            '    If current_shipindex = shipindex.Count - 1 Then
            '        Exit While
            '    End If
            'End While

            current_shipindex = current_shipindex + 1
            current_shipno = shipindex(current_shipindex).ShipNo
            current_shipseq = shipindex(current_shipindex).ShipSeq
            txt_shipno.Text = current_shipno
            txt_shipseq.Text = current_shipseq

            If TabControl1.SelectedIndex = 0 Then
                dg_history.ClearSelection()
                dg_history.Rows(lookup_rowno(current_shipindex)).Selected = True
                dg_history.CurrentCell = dg_history.Rows(lookup_rowno(current_shipindex)).Cells(1)
            Else
                Call set_dgDetail()
            End If

        End If
    End Sub

    'Button Control End

    'Get And Set Start
    Private Function get_Dataset_Carton() As Integer
        Dim count As Integer = 0
        Dim rowcount As Integer = 0
        Dim tmp_ds As New DataSet

        ds_carton.Reset()
        shipindex.Clear()
        shiprange.Clear()

        For Each tmp_dr As DataRow In dr_ship
            Dim tmp_pd As Integer() = get_pdnum(tmp_dr.Item("cartonfactor"))

            gspStr = "sp_select_SHM00110_2 '" & tmp_dr.Item("shipno") & _
                    "'," & tmp_dr.Item("shipseq").ToString & _
                    "," & tmp_pd(0).ToString & _
                    "," & tmp_pd(1).ToString

            If count = 0 Then
                rtnLong = execute_SQLStatement(gspStr, ds_carton, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading MSR00036 sp_select_SHM00110_2 : " & rtnStr & vbCrLf & "gspStr = " & gspStr)
                    Exit Function
                End If

                If ds_carton.Tables("Result").Rows.Count > 0 Then
                    rowcount = rowcount + ds_carton.Tables("Result").Rows.Count
                    shipindex.Add(New SHM00110_ShipUnit(ds_carton.Tables("Result").Rows(0).Item("hpd_shpno"), ds_carton.Tables("Result").Rows(0).Item("hpd_shpseq")))
                    shiprange.Add(rowcount)
                End If

            Else
                tmp_ds.Clear()
                rtnLong = execute_SQLStatement(gspStr, tmp_ds, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading MSR00036 sp_select_SHM00110_2 : " & rtnStr & vbCrLf & "gspStr = " & gspStr)
                    Exit Function
                Else
                    If tmp_ds.Tables("Result").Rows.Count > 0 Then
                        rowcount = rowcount + tmp_ds.Tables("Result").Rows.Count
                        shipindex.Add(New SHM00110_ShipUnit(tmp_ds.Tables("Result").Rows(0).Item("hpd_shpno"), tmp_ds.Tables("Result").Rows(0).Item("hpd_shpseq")))
                        shiprange.Add(rowcount)
                        ds_carton.Tables("Result").Merge(tmp_ds.Tables("Result"))
                    Else
                    End If
                End If
            End If
            count = count + 1
        Next

        Return rowcount

    End Function

    Private Function get_pdnum(ByVal carton_factor As Integer) As Integer()
        Dim tmp_pd(2) As Integer
        Select Case carton_factor
            Case 1
                tmp_pd = New Integer() {5, 6}
            Case 2
                tmp_pd = New Integer() {1, 4}
            Case 3
                tmp_pd = New Integer() {7, 12}
            Case 4
                tmp_pd = New Integer() {13, 20}
            Case 5
                tmp_pd = New Integer() {21, 30}
        End Select
        Return tmp_pd
    End Function

    Private Sub set_dgHistory()
        Dim dv As DataView = ds_carton.Tables("Result").DefaultView

        With dg_history
            .DataSource = dv
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).Width = 43
                .Columns(i).HeaderText = his_header(i)
                .Columns(i).Visible = True
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

                Select Case i
                    Case 0 'Shipping Name
                        .Columns(i).Width = 100
                    Case 2 'Pd Num
                        .Columns(i).Visible = False
                    Case 6 'Carton Number
                        .Columns(i).Visible = False
                    Case .Columns.Count - 1
                        .Columns(i).Width = 130
                End Select
            Next
            '.Columns.width = 50
            'For i As Integer = 0 To .Columns.Count - 1
            '    .Columns(i).Width = 30
            '    .Columns(i).HeaderText = his_header(i)
            '    Select Case i
            '    End Select

            'Next
        End With


    End Sub

    Private Sub set_dgDetail()
        Dim tmp_table As DataTable = ds_carton.Tables("Result").Copy
        Dim dv As DataView = tmp_table.DefaultView
        dv.RowFilter = "hpd_shpno = '" + current_shipno + "' AND hpd_shpseq = " + current_shipseq.ToString

        With dg_detail
            .DataSource = dv
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).Width = 43
                .Columns(i).HeaderText = his_header(i)
                .Columns(i).Visible = True
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

                Select Case i
                    Case 0 'Shipping Name
                        .Columns(i).Width = 100
                    Case 2 'Pd Num
                        .Columns(i).Visible = False
                    Case 6 'Carton Number
                        .Columns(i).Visible = False
                    Case .Columns.Count - 1
                        .Columns(i).Width = 130
                End Select
            Next

        End With
    End Sub


    Private Sub set_uppercontrol(ByVal flg_enable As Boolean)
        cboCusNo.Enabled = flg_enable
        cbopackterms.Enabled = flg_enable
        txt_itmno.Enabled = flg_enable
        btn_search.Enabled = flg_enable
        btn_packfind.Enabled = flg_enable
        btn_clear.Enabled = Not flg_enable
    End Sub

    Private Sub SetHisHeader()
        his_header = New String() {"Ship No", _
                                    "Ship Seq", _
                                    "PD NUM", _
                                    "Type", _
                                    "Name", _
                                    "Desc", _
                                    "Ctn", _
                                    "L (cm)", _
                                    "W (cm)", _
                                    "H (cm)", _
                                    "CBM (cm)", _
                                    "TTl CBM (cm)", _
                                    "GW (kg)", _
                                    "TtlGW (kg)", _
                                    "NW (kg)", _
                                    "TtlNW (kg)", _
                                    "L (in)", _
                                    "W (in)", _
                                    "H (in)", _
                                    "CBM (in)", _
                                    "TtlCBM (in)", _
                                    "GW (lb)", _
                                    "TtlGW (lb)", _
                                    "NW (lb)", _
                                    "TtlNw (lb)", _
                                    "Create Date" _
                                  }

    End Sub
    'Get And Set End

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If flg_search Then
            If TabControl1.SelectedIndex = 0 Then
                dg_history.ClearSelection()
                dg_history.Rows(lookup_rowno(current_shipindex)).Selected = True
                dg_history.CurrentCell = dg_history.Rows(lookup_rowno(current_shipindex)).Cells(1)
            Else
                current_shipno = txt_shipno.Text
                current_shipseq = txt_shipseq.Text
                Call set_dgDetail()

            End If
        End If
    End Sub

    Private Function lookup_shipindex(ByVal current_rowno As Integer) As Integer
        Dim tmp_index As Integer = 0
        For i As Integer = 0 To shiprange.Count - 1
            If i = 0 Then
                If current_rowno < shiprange(i) Then
                    tmp_index = i
                    Exit For
                End If
            Else
                If (current_rowno >= shiprange(i - 1) And current_rowno < shiprange(i)) Then
                    tmp_index = i
                    Exit For
                End If
            End If
        Next

        Return tmp_index

    End Function

    Private Function lookup_rowno(ByVal shipindex As Integer) As Integer
        If shipindex = 0 Then
            Return 0
        Else
            Return shiprange(shipindex - 1)
        End If
    End Function


    'Private class
    Private Class SHM00110_ShipUnit
        Private _ShipNo As String
        Private _ShipSeq As Integer

        Public Sub New(ByVal ShipNo As String, ByVal ShipSeq As Integer)
            _ShipNo = ShipNo
            _ShipSeq = ShipSeq
        End Sub

        Public ReadOnly Property ShipNo() As String
            Get
                Return _ShipNo
            End Get
        End Property

        Public ReadOnly Property ShipSeq() As String
            Get
                Return _ShipSeq
            End Get
        End Property
    End Class

End Class

