Public Class frmPOAss
    Public Sub New(ByVal rs_PODTLASS As DataSet, ByVal txtPurSeq As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()


        For i As Integer = 0 To rs_PODTLASS.Tables("RESULT").Columns.Count - 1
            rs_PODTLASS.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        rs_PODTLASS.Tables("RESULT").DefaultView.AllowNew = False
        rs_PODTLASS.Tables("RESULT").DefaultView.RowFilter = "pda_seq = '" & txtPurSeq & "'"
        grdPOAss.DataSource = rs_PODTLASS.Tables("RESULT").DefaultView
        Display_GrdPOAss()


    End Sub

    Private Sub Display_GrdPOAss()
        'Dim ii As Integer

        With grdPOAss

            '***** Change colume width to fit data ******  Lewis To on 6 Mar 2003
            .Columns(0).HeaderCell.Value = "Assorted Item"
            '.Columns(0).Width = 1300
            '.Columns(0).Locked = True

            .Columns(1).HeaderCell.Value = "Description"
            .Columns(1).Width = 180
            '.Columns(1).Locked = True

            .Columns(2).HeaderCell.Value = "Item No."
            '.Columns(2).Width = 1400
            '.Columns(2).Locked = True

            .Columns(3).HeaderCell.Value = "Color Code"
            '.Columns(3).Width = 1000
            '.Columns(3).Locked = True


            .Columns(4).HeaderCell.Value = "SKU No."
            '.Columns(4).Width = 1000
            '.Columns(4).Locked = True

            .Columns(5).HeaderCell.Value = "UPC/EAN"
            '.Columns(5).Width = 1000
            '.Columns(5).Locked = True

            .Columns(6).HeaderCell.Value = "Retail"
            '.Columns(6).Width = 1000
            '.Columns(6).Locked = True

            .Columns(7).HeaderCell.Value = "Assd IM Period"
            '.Columns(7).Width = 1200
            '.Columns(7).Locked = True

            .Columns(8).HeaderCell.Value = "UM"
            '.Columns(8).Width = 1000
            '.Columns(7).Locked = True

            .Columns(9).HeaderCell.Value = "Inner"
            '.Columns(9).Width = 1000
            '.Columns(8).Locked = True

            .Columns(10).HeaderCell.Value = "Master"
            '.Columns(10).Width = 1000
            '.Columns(9).Locked = True

            .Columns(11).Visible = False '.Columns(11).Width = 0

        End With

        ' Allan Yuen add checking
        'If cboPOStatus.ListIndex = 0 Then
        '    For ii = 0 To 10
        '        If ii <> 7 Then
        '            frmPOAss.grdPOAss.Columns(ii).Locked = False
        '        End If
        '    Next ii
        'Else
        '    For ii = 0 To 10
        '        frmPOAss.grdPOAss.Columns(ii).Locked = True
        '    Next ii
        'End If


    End Sub


    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class