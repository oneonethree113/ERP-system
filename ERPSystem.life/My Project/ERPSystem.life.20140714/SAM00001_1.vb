Public Class SAM00001_1
    Dim temp_rs_SAREQASS As DataSet
    Dim temp_RecordStatus As Boolean
    Dim temp_ChangeMode As Boolean

    Private Sub cmdCancel_Click()
        Me.Close()
    End Sub


    Public Sub New(ByVal rs_SAREQASS As DataSet)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        temp_rs_SAREQASS = rs_SAREQASS.Copy()
        'grdAss.DataSource = rs_SAREQASS_SUB.Tables("RESULT").DefaultView

        For i As Integer = 0 To temp_rs_SAREQASS.Tables("RESULT").Columns.Count - 1
            temp_rs_SAREQASS.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        temp_rs_SAREQASS.Tables("RESULT").DefaultView.AllowNew = False
        grdAss.DataSource = temp_rs_SAREQASS.Tables("RESULT").DefaultView


        Call Display_Assortment()
    End Sub

    Public Event returnSelectedRecords(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal temp_ChangeMode As Boolean, ByVal temp_rs_SAREQASS As DataSet)


    Private Sub Display_Assortment()
        With grdAss

            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False

            .Columns(3).Visible = False

            .Columns(4).HeaderCell.Value = "Assorted Item"
            .Columns(4).ReadOnly = True
            '.Columns(4).Width = 1300

            .Columns(5).HeaderCell.Value = "Assorted Item Description"
            .Columns(5).ReadOnly = False
            '.Columns(5).Width = 1900

            .Columns(6).HeaderCell.Value = "Cust. Item"
            .Columns(6).ReadOnly = False
            '.Columns(6).Width = 1300

            .Columns(7).HeaderCell.Value = "Color Code"
            .Columns(7).ReadOnly = True
            '.Columns(7).Width = 1400

            .Columns(8).HeaderCell.Value = "SKU #"
            .Columns(8).ReadOnly = False
            '.Columns(8).Width = 1100

            .Columns(9).HeaderCell.Value = "UPC/EAN #"
            .Columns(9).ReadOnly = False
            '.Columns(9).Width = 1100

            .Columns(10).HeaderCell.Value = "Cust. Retail"
            .Columns(10).ReadOnly = False
            '.Columns(10).Width = 900

            .Columns(11).HeaderCell.Value = "UM"
            .Columns(11).ReadOnly = True
            '.Columns(11).Width = 700

            .Columns(12).HeaderCell.Value = "Inner"
            .Columns(12).ReadOnly = True
            '.Columns(12).Width = 800

            .Columns(13).HeaderCell.Value = "Master"
            .Columns(13).ReadOnly = True
            '.Columns(13).Width = 800

            .Columns(14).Visible = False
        End With
    End Sub



    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'SAM00001.rs_SAREQASS = CopyRS(rs_SAREQASS_SUB)
        'If SAM00001.rs_SAREQDTL("mode") <> "NEW" Then
        '    SAM00001.rs_SAREQDTL("mode").Value = "UPD"
        'End If
        If temp_RecordStatus = True Then
            RaiseEvent returnSelectedRecords(Me, temp_RecordStatus, temp_ChangeMode, temp_rs_SAREQASS)
        End If
        Me.Close()
    End Sub


    Private Sub grdAss_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAss.CellDoubleClick
        temp_RecordStatus = True
        temp_ChangeMode = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub


    Private Sub grdAss_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAss.CellContentClick

    End Sub
End Class