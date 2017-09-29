

Partial Public Class SAR00007Report
    Partial Class SAR00007DataTable

        Private Sub SAR00007DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.yco_logoimgpthColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
