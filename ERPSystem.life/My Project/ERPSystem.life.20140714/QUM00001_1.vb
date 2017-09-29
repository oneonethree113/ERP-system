Public Class QUM00001_1
    Inherits System.Windows.Forms.Form

    Dim rs_QUASSINF_SUB As New DataSet
    Dim seq As String
    Dim mode As String

    Public Sub New(ByVal p_rs_QUASSINF As DataSet, ByVal p_seq As String, ByVal p_Mode As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If Not p_rs_QUASSINF Is Nothing Then
            If Not p_rs_QUASSINF.Tables("RESULT") Is Nothing Then
                rs_QUASSINF_SUB = p_rs_QUASSINF.Copy
            End If
        End If

        If Not String.IsNullOrEmpty(p_seq) Then
            seq = p_seq
        End If

        If Not String.IsNullOrEmpty(p_Mode) Then
            mode = p_Mode
        End If
    End Sub

    Private Sub QUM00001_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgASS.DataSource = Nothing

        Dim sFilter As String

        'rs_QUASSINF_SUB = Nothing
        'rs_QUASSINF_SUB = QUM00001.rs_QUASSINF.Copy

        sFilter = "qai_qutseq = " & seq & " and mode <> 'DEL'"
        rs_QUASSINF_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter

        dgAss.DataSource = rs_QUASSINF_SUB.Tables("RESULT").DefaultView

        Call Display_Assortment()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If mode <> "NEW" Then
            mode = "UPD"
        End If

        Dim i As Integer
        For i = 0 To rs_QUASSINF_SUB.Tables("RESULT").Rows.Count - 1
            If rs_QUASSINF_SUB.Tables("RESULT").Rows(i).Item("qai_creusr") <> "~*ADD*~" And rs_QUASSINF_SUB.Tables("RESULT").Rows(i).Item("qai_creusr") <> "~*NEW*~" Then
                rs_QUASSINF_SUB.Tables("RESULT").Rows(i).Item("qai_creusr") = "~*UPD*~"
            End If
        Next i

        RaiseEvent returnSelectedRecords(Me, rs_QUASSINF_SUB, mode)

        Me.Close()
    End Sub

    Public Event returnSelectedRecords(ByVal sender As Object, _
                                        ByVal TableToReturn As DataSet, _
                                        ByVal TableToReturn_Mode As String)

    Private Sub Display_Assortment()

        Dim i As Integer

        i = 0

        With dgAss
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Visible = False
            i = i + 1
            '4
            .Columns(i).HeaderText = "Assorted Item"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 100
            i = i + 1
            '5
            .Columns(i).HeaderText = "Assorted Item Description"
            .Columns(i).ReadOnly = False
            .Columns(i).Width = 150
            i = i + 1
            '6
            .Columns(i).HeaderText = "Cust. Item"
            .Columns(i).ReadOnly = False
            .Columns(i).Width = 85
            i = i + 1
            '7 new
            .Columns(i).HeaderText = "Cust. Style"
            .Columns(i).ReadOnly = False
            .Columns(i).Width = 85
            i = i + 1
            '8
            .Columns(i).HeaderText = "Color Code"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 85
            i = i + 1
            '9
            .Columns(i).HeaderText = "Color Desc."
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 150
            i = i + 1
            '10
            .Columns(i).HeaderText = "Alias No."
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 0
            .Columns(i).Visible = False
            i = i + 1
            '11
            .Columns(i).HeaderText = "Alias Color Code"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 0
            .Columns(i).Visible = False
            i = i + 1
            '12
            .Columns(i).HeaderText = "IM Period"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 70
            i = i + 1
            '13
            .Columns(i).HeaderText = "Item Status"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 120
            i = i + 1
            '14
            .Columns(i).HeaderText = "SKU #"
            .Columns(i).Width = 80
            i = i + 1
            '15
            .Columns(i).HeaderText = "UPC/EAN #"
            .Columns(i).Width = 80
            i = i + 1
            '16
            .Columns(i).HeaderText = "Cust. Retail"
            .Columns(i).Width = 75
            i = i + 1
            '17
            .Columns(i).HeaderText = "UM"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 40
            i = i + 1
            '18
            .Columns(i).HeaderText = "Inner"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 50
            i = i + 1
            '19
            .Columns(i).HeaderText = "Master"
            .Columns(i).ReadOnly = True
            .Columns(i).Width = 50
            i = i + 1
            '20
            .Columns(i).Visible = False
        End With
    End Sub

    Private Sub dgAss_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgASS.CellEndEdit
        'Private Sub dgAss_AfterColUpdate(ByVal ColIndex As Integer)
        If rs_QUASSINF_SUB.Tables("RESULT").DefaultView(e.RowIndex)("mode").ToString <> "NEW" Then
            rs_QUASSINF_SUB.Tables("RESULT").DefaultView(e.RowIndex)("mode") = "UPD"
        End If
    End Sub

    Private Sub dgAss_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgASS.EditingControlShowing
        If (dgASS.CurrentCell.ColumnIndex = 5 Or dgASS.CurrentCell.ColumnIndex = 6 Or dgASS.CurrentCell.ColumnIndex = 9 Or _
            dgASS.CurrentCell.ColumnIndex = 10 Or dgASS.CurrentCell.ColumnIndex = 14 Or dgASS.CurrentCell.ColumnIndex = 15) AndAlso TypeOf e.Control Is TextBox Then
            RemoveHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf txtBox_dgAss_KeyPress
            AddHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf txtBox_dgAss_KeyPress
        End If
    End Sub

    Private Sub txtBox_dgAss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim rowIndex As Integer = dgASS.CurrentCell.RowIndex
        Dim colIndex As Integer = dgASS.CurrentCell.ColumnIndex
        Dim i As Integer

        i = 3

        If rs_QUASSINF_SUB.Tables("RESULT").Rows.Count > 0 Then
            Dim assdsc As Integer = 800
            Dim cusitm As Integer = 20
            Dim coldsc As Integer = 300
            Dim cussku As Integer = 39
            Dim upcean As Integer = 20
            Dim cusrtl As Integer = 15

            'assdsc = rs_QUASSINF_SUB.Tables("RESULT").Columns(5).MaxLength
            'cusitm = rs_QUASSINF_SUB.Tables("RESULT").Columns(6).MaxLength
            'coldsc = rs_QUASSINF_SUB.Tables("RESULT").Columns(8).MaxLength
            'cussku = rs_QUASSINF_SUB.Tables("RESULT").Columns(9 + i).MaxLength
            'upcean = rs_QUASSINF_SUB.Tables("RESULT").Columns(10 + i).MaxLength
            'cusrtl = rs_QUASSINF_SUB.Tables("RESULT").Columns(11 + i).MaxLength

            If colIndex = 5 Then
                If (sender.text.length + 1 > assdsc) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
                    e.KeyChar = Chr(0)
                End If
            ElseIf colIndex = 6 Then
                If (sender.text.length + 1 > cusitm) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
                    e.KeyChar = Chr(0)
                End If
            ElseIf colIndex = 9 Then
                If (sender.text.length + 1 > coldsc) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
                    e.KeyChar = Chr(0)
                End If
            ElseIf colIndex = 10 + i Then
                If (sender.text.length + 1 > cussku) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
                    e.KeyChar = Chr(0)
                End If
            ElseIf colIndex = 11 + i Then
                If (sender.text.length + 1 > upcean) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
                    e.KeyChar = Chr(0)
                End If
            ElseIf colIndex = 12 + i Then
                If (sender.text.length + 1 > cusrtl) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
                    e.KeyChar = Chr(0)
                End If
            End If
        End If
    End Sub
End Class