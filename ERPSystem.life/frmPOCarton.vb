Public Class frmPOCarton
    Dim temp_RecordStatus As Boolean = False
    Dim rs_PODTLCTN_temp As DataSet
    Dim validFlag As Boolean

    Public Sub New(ByVal rs_PODTLCTN As DataSet, ByVal cboPOStatus As ComboBox, ByVal rs_POORDDTL As DataSet, ByVal current_row As Integer, ByVal txtPurSeq As Integer)
        MyBase.New()
        'This call is required by the Windows Form Designer.



        InitializeComponent()

        txtTotal.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_ttlctn")


        If cboPOStatus.SelectedIndex = 0 Then
            grdPOCarton.Enabled = True
        Else
            grdPOCarton.Enabled = False
        End If

        'Dim drPODTLCTN() As DataRow = rs_PODTLCTN.Tables("RESULT").Select("pdc_seq = '" & txtPurSeq & "'")
        rs_PODTLCTN_temp = rs_PODTLCTN.Copy

        rs_PODTLCTN_temp.Tables("RESULT").DefaultView.AllowNew = False
        rs_PODTLCTN_temp.Tables("RESULT").DefaultView.RowFilter = "pdc_seq = '" & txtPurSeq & "'"
        grdPOCarton.DataSource = rs_PODTLCTN_temp.Tables("RESULT").DefaultView
        Display_GrdPOCarton()


    End Sub


    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        CheckDate()

        If temp_RecordStatus = True And validFlag = True Then
            RaiseEvent returnSelectedRecords(Me, temp_RecordStatus, rs_PODTLCTN_temp)
        End If

        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Public Event returnSelectedRecords(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal rs_PODTLCTN As DataSet)

    Private Sub Display_GrdPOCarton()

        With grdPOCarton




            .Columns(0).Visible = False '.Columns(0).Width = 0

            .Columns(1).Visible = False '.Columns(1).Width = 0

            .Columns(2).HeaderCell.Value = "Start"
            '.Columns(2).Width = 2500
            .Columns(2).ReadOnly = True


            .Columns(3).HeaderCell.Value = "End"
            '.Columns(3).Width = 2500
            .Columns(3).ReadOnly = True


            .Columns(4).HeaderCell.Value = "Number of Carton"
            '.Columns(4).Width = 3500
            .Columns(4).ReadOnly = True


            .Columns(5).Visible = False '.Columns(5).Width = 0





        End With

    End Sub

    Private Sub grdPOCarton_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPOCarton.CellEndEdit
        temp_RecordStatus = True
    End Sub
    Private Sub CheckDate()
        validFlag = True
        Dim qty As Integer
        Dim preTo As Integer
        Dim chkTo As Boolean
        ' MsgBox preTo
        chkTo = False
        'POM00001.rs_PODTLCTN.MoveFirst()
        'While Not POM00001.rs_PODTLCTN.EOF
        For i As Integer = 0 To rs_PODTLCTN_temp.Tables("RESULT").Rows.Count - 1
            If chkTo Then

                If preTo >= rs_PODTLCTN_temp.Tables("RESULT").Rows(i).Item("pdc_from") Then
                    validFlag = False
                    MsgBox("Carton No. Range cannot be overlapped") 'msg("M00270")
                    Exit Sub
                End If
            End If


            If rs_PODTLCTN_temp.Tables("RESULT").Rows(i).Item("pdc_from") > rs_PODTLCTN_temp.Tables("RESULT").Rows(i).Item("pdc_to") Then
                validFlag = False
                MsgBox("From Carton No cannot be greater than To Carton No") 'msg("M00269")
                Exit Sub
            End If

            If Not (rs_PODTLCTN_temp.Tables("RESULT").Rows(i).Item("pdc_ttlctn")) Is Nothing Then
                qty = qty + rs_PODTLCTN_temp.Tables("RESULT").Rows(i).Item("pdc_ttlctn")
            End If

            If Not (rs_PODTLCTN_temp.Tables("RESULT").Rows(i).Item("pdc_to")) Is Nothing Then
                chkTo = True
                preTo = rs_PODTLCTN_temp.Tables("RESULT").Rows(i).Item("pdc_to")
            Else
                chkTo = False
            End If

        Next
        

        'POM00001.rs_PODTLCTN.MoveNext()
        'End While



        If qty <> CInt(txtTotal.Text) Then
            validFlag = False
            MsgBox("Total No. of Carton not match") 'msg("M00268")

        End If


    End Sub


End Class