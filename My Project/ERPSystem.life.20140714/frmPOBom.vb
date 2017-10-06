Public Class frmPOBom

    Dim temp_RecordStatus As Boolean = False
    Dim temp_rs_PODTLBOM As DataSet
    Public Sub New(ByVal rs_PODTLBOM As DataSet, ByVal txtPurSeq As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'temp_rs_PODTLBOM_FILTER = rs_PODTLBOM_FILTER.Copy()
        'grdAss.DataSource = rs_SAREQASS_SUB.Tables("RESULT").DefaultView

        temp_rs_PODTLBOM = rs_PODTLBOM.Copy
        For i As Integer = 0 To temp_rs_PODTLBOM.Tables("RESULT").Columns.Count - 1
            temp_rs_PODTLBOM.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        temp_rs_PODTLBOM.Tables("RESULT").DefaultView.AllowNew = False
        temp_rs_PODTLBOM.Tables("RESULT").DefaultView.RowFilter = "pdb_seq ='" & txtPurSeq & "'"
        'grdPOBom.DataSource = (temp_rs_PODTLBOM.Tables("RESULT").DefaultView.RowFilter = "pdb_seq ='" & txtPurSeq & "'")
        grdPOBom.DataSource = temp_rs_PODTLBOM.Tables("RESULT").DefaultView
        Display_GrdPOBOM()


    End Sub
    Public Event returnSelectedRecords(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal temp_rs_PODTLBOM As DataSet)

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If temp_RecordStatus = True Then
            RaiseEvent returnSelectedRecords(Me, temp_RecordStatus, temp_rs_PODTLBOM)
        End If
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub



    Private Sub grdPOBom_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPOBom.CellEndEdit
        temp_RecordStatus = True
    End Sub


    Private Sub Display_GrdPOBOM()
        'Dim ii As Integer
        With grdPOBom

            .Columns(0).Visible = False '.Columns(0).Width = 0

            .Columns(1).HeaderCell.Value = "Assorted Item"
            '.Columns(1).Width = 1300
            .Columns(1).ReadOnly = True


            .Columns(2).HeaderCell.Value = "BOM Item"
            '.Columns(2).Width = 1300
            .Columns(2).ReadOnly = True

            .Columns(3).HeaderCell.Value = "Color Code"
            '.Columns(3).Width = 1000
            .Columns(3).ReadOnly = True

            .Columns(4).HeaderCell.Value = "Item Description"
            '.Columns(4).Width = 2000
            .Columns(4).ReadOnly = True

            .Columns(5).HeaderCell.Value = "BOM Qty"
            '.Columns(5).Width = 800
            .Columns(5).ReadOnly = True
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(6).HeaderCell.Value = "BOM IM Period"
            '.Columns(6).Width = 1200
            .Columns(6).ReadOnly = True

            .Columns(7).HeaderCell.Value = "U/M"
            .Columns(7).Width = 80
            .Columns(7).ReadOnly = True

            .Columns(8).HeaderCell.Value = "Vendor"
            .Columns(8).Width = 80
            .Columns(8).ReadOnly = True


            .Columns(9).HeaderCell.Value = "Currency"
            '.Columns(9).Button = False
            .Columns(9).Width = 80
            .Columns(9).ReadOnly = False

            .Columns(10).HeaderCell.Value = "BOM Factory Cost"
            '.Columns(10).Button = False
            '.Columns(10).Width = 1500
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(10).ReadOnly = False

            .Columns(11).Visible = False '.Columns(11).Width = 0

            .Columns(12).HeaderCell.Value = "Order Qty"
            '.Columns(12).Button = False
            '.Columns(12).Width = 1200
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(12).ReadOnly = False

            .Columns(13).Visible = False '.Columns(13).Width = 0

            .Columns(14).HeaderCell.Value = "BOM PO Flag"
            '.Columns(14).Width = 1200
            .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(14).ReadOnly = True


        End With

        ' Allan Yuen add checking
        'If cboPOStatus.ListIndex = 0 Then
        '    For ii = 0 To 12
        '        frmPOBom.grdPOBom.Columns(ii).readonly = False
        '    Next ii
        'Else
        '    For ii = 0 To 12
        '        frmPOBom.grdPOBom.Columns(ii).readonly = True
        '    Next ii
        'End If

    End Sub
End Class